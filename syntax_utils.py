import re

# in base syntax these operators can have several pairs of operands at the end
variadic_operators = {'buffer': 2, 'unbuffer': 1, 'up': 1, 'down': 1, 'timer': 3, 'out': 0}

def split_syntax_desc(desc: str):
    orders = {'return': '0', 'break': '0', 'clearqueue': 'r0'}
    keywords = {'return': 'return', 'break': 'break', 'clearqueue': 'clearqueue'}
    for line in desc.split("\n"):
        if ':' not in line:
            continue
        keyword, line = line.split(':', maxsplit=1)
        if ';' not in line:
            continue
        base_keyword, order = line.split(';', maxsplit=1)
        keywords[base_keyword] = keyword
        orders[base_keyword] = order
    return keywords, orders


def convert_to_base_syntax(operands: list[str], keywords: dict[str, str], orders: dict[str, str]):
    if 'declare' in operands:
        index = operands.index('declare')
        operands.pop(index)
        base_keyword = 'declare'
        keyword = 'declare'
        order = orders['declare']
    else:
        for base_keyword, keyword in keywords.items():
            for index, operand in enumerate(operands):
                if operand == keyword:
                    break
            else:
                continue
            order = orders[base_keyword]
            operands.pop(index)
            break
        else:
            raise RuntimeError(f"keyword not found: {operands}, {keywords}, {orders}")
    base_operands = [base_keyword]
    for ch in order:
        if ch == "f":
            base_operands.append(operands[0])
            operands = operands[1:]
        elif ch == "l":
            base_operands.append(operands[-1])
            operands = operands[:-1]
        elif ch == "r":
            base_operands.extend(operands)
            operands = []
    return base_operands


def convert_from_base_syntax(base_operands: list[str], keywords: dict[str, str], orders: dict[str, str]):
    base_keyword = base_operands[0]
    base_operands = base_operands[1:]

    order = orders[base_keyword]
    keyword_index = int(order[-1])
    order = order[:-1]

    first = []
    last = []
    variadic = []
    for index, ch in enumerate(order):
        if ch == "f":
            first.append(base_operands[0])
            base_operands = base_operands[1:]
        elif ch == "l":
            last.append(base_operands[0])
            base_operands = base_operands[1:]
        elif ch == "r":
            if base_keyword in variadic_operators:
                fixed_operands_count = variadic_operators[base_keyword]
                offset = fixed_operands_count - index
                first.extend(base_operands[:offset])
                variadic = base_operands[offset:]
            else:
                first.extend(base_operands)
            break
    last = last[::-1]
    if base_keyword not in variadic_operators:
        operands = first + last
        return operands[:keyword_index] + [keywords[base_keyword]] + operands[keyword_index:]
    if len(first) >= keyword_index:
        return first[:keyword_index] + [keywords[base_keyword]] + first[keyword_index:] + variadic + last
    last_index = keyword_index - len(first) - 1
    return first + variadic + last[:last_index] + [keywords[base_keyword]] + last[last_index:]


def convert_syntax(text_to_parse: str, src_syntax_desc: str, dst_syntax_desc: str):
    operands = []
    prefix = ""
    suffix = ""
    while True:
        text_to_parse = text_to_parse.lstrip()
        if text_to_parse == "":
            break
        if text_to_parse[0] == ";":
            suffix = text_to_parse
            break
        operand, text_to_parse = separate_expression(text_to_parse)
        operands.append(operand)
    if len(operands) > 0:
        if operands[0][-1] == ":":
            prefix = operands[0]
            operands.pop(0)
    if len(operands) == 0:
        return prefix + suffix
    src_keywords, src_orders = split_syntax_desc(src_syntax_desc)
    dst_keywords, dst_orders = split_syntax_desc(dst_syntax_desc)
    base_operands = convert_to_base_syntax(operands, src_keywords, src_orders)
    result_operands = convert_from_base_syntax(base_operands, dst_keywords, dst_orders)
    return prefix + ' '.join(result_operands) + suffix

def find_next_operator(text_to_parse: str):
    if len(text_to_parse) >= 2:
        prefix = text_to_parse[:2]
        if prefix in {"&&", "||", "==", "!!", ">=", "<=", "!="}:
            return prefix
    if len(text_to_parse) >= 1:
        prefix = text_to_parse[0]
        if prefix in {"&", "%", "&", "*", "+", "-", "/", "<", ">", "|"}:
            return prefix
    return None

def is_unary_operator(text_to_parse: str):
    next_operator = find_next_operator(text_to_parse)
    return next_operator in {"-", "!", "!!"}

def is_function(name: str):
    return name in {"sizeof", "pos", "peek", "dequeue", "qcount", "CurrentSystemName", "SystemName", "random", "copy", "locguide"}

def separate_expression(text_to_parse: str):
    text_to_parse = text_to_parse.lstrip()
    if text_to_parse[0] in '$("#0123456789' or is_unary_operator(text_to_parse):
        return separate_next_token(text_to_parse)
    non_special_sequence = find_next_non_special_sequence(text_to_parse)
    if is_function(non_special_sequence):
        return separate_next_token(text_to_parse)
    if non_special_sequence == "":
        raise RuntimeError(f"syntax error: {text_to_parse}")
    return non_special_sequence, text_to_parse[len(non_special_sequence):]


def find_next_non_special_sequence(text_to_parse: str):
    text_to_parse = text_to_parse.lstrip()
    m = re.match(r"[^\s;,()$+*/%|&!=<>#-]+", text_to_parse)
    if m is None:
        return ""
    return m.group(0)


def separate_function_brackets(text_to_parse: str):
    function_name = find_next_non_special_sequence(text_to_parse)
    text_to_parse = text_to_parse[len(function_name):]
    text_to_parse = text_to_parse.lstrip()
    result = ''
    if len(text_to_parse) == 0 or text_to_parse[0] != '(':
        raise RuntimeError(f"syntax error: {text_to_parse}")
    result = function_name + '('
    text_to_parse = text_to_parse[1:]
    while True:
        text_to_parse = text_to_parse.lstrip()
        if text_to_parse == "":
            return result, text_to_parse
        if text_to_parse[0] == ")":
            return result + ")", text_to_parse[1:]
        if text_to_parse[0] == ",":
            result += ","
            text_to_parse = text_to_parse[1:]
        else:
            value, text_to_parse = separate_expression(text_to_parse)
            result = f"{result} {value}"

def separate_next_token(text_to_parse):
    if text_to_parse[0] == "$":
        text_to_parse = text_to_parse[1:]
        name = find_next_non_special_sequence(text_to_parse)
        text_to_parse = text_to_parse[len(name):]
        text_to_parse = text_to_parse.lstrip()
        next_token = "$" + name
        next_operator = find_next_operator(text_to_parse)
        if next_operator is not None:
            next_token = f"{next_token} {next_operator}"
            text_to_parse = text_to_parse[len(next_operator):]
            text_to_parse = text_to_parse.lstrip()
            if len(text_to_parse) > 0:
                subtoken, text_to_parse = separate_next_token(text_to_parse)
                next_token = f"{next_token} {subtoken}"
        return next_token, text_to_parse
    if text_to_parse[0] == "(":
        text_to_parse = text_to_parse[1:]
        text_to_parse = text_to_parse.lstrip()
        subtoken, text_to_parse = separate_next_token(text_to_parse)
        next_token = f"({subtoken}" 
        text_to_parse = text_to_parse.lstrip()
        if text_to_parse[:1] == ")":
            next_token = next_token + ")"
            text_to_parse = text_to_parse[1:]
        text_to_parse = text_to_parse.lstrip()
        next_operator = find_next_operator(text_to_parse)
        if next_operator is not None:
            next_token = f"{next_token} {next_operator}"
            text_to_parse = text_to_parse[len(next_operator):]
            text_to_parse = text_to_parse.lstrip()
            if len(text_to_parse) > 0:
                subtoken, text_to_parse = separate_next_token(text_to_parse)
                next_token = f"{next_token} {subtoken}"
        return next_token, text_to_parse
    if text_to_parse[0] == "#":
        text_to_parse = text_to_parse[1:]
        non_special_sequence = find_next_non_special_sequence(text_to_parse)
        text_to_parse = text_to_parse[len(non_special_sequence):]
        text_to_parse = text_to_parse.lstrip()
        next_token = "#" + non_special_sequence
        next_operator = find_next_operator(text_to_parse)
        if next_operator is not None:
            next_token = f"{next_token} {next_operator}"
            text_to_parse = text_to_parse[len(next_operator):]
            text_to_parse = text_to_parse.lstrip()
            if len(text_to_parse) > 0:
                subtoken, text_to_parse = separate_next_token(text_to_parse)
                next_token = f"{next_token} {subtoken}"
        return next_token, text_to_parse
    if is_unary_operator(text_to_parse):
        next_operator = find_next_operator(text_to_parse)
        next_token = next_operator
        text_to_parse = text_to_parse[len(next_operator):]
        text_to_parse = text_to_parse.lstrip()
        if len(text_to_parse) > 0:
            subtoken, text_to_parse = separate_next_token(text_to_parse)
            next_token = f"{next_token} {subtoken}"
        return next_token, text_to_parse
    if text_to_parse[0] == '"':
        next_token = '"'
        text_to_parse = text_to_parse[1:]
        index = text_to_parse.index('"')
        next_token += text_to_parse[:index+1]
        text_to_parse = text_to_parse[index+1:]
        text_to_parse = text_to_parse.lstrip()
        next_operator = find_next_operator(text_to_parse)
        if next_operator is not None:
            next_token = f"{next_token} {next_operator}"
            text_to_parse = text_to_parse[len(next_operator):]
            text_to_parse = text_to_parse.lstrip()
            if len(text_to_parse) > 0:
                subtoken, text_to_parse = separate_next_token(text_to_parse)
                next_token = f"{next_token} {subtoken}"
        return next_token, text_to_parse
    if text_to_parse[0] in "0123456789":
        next_token = find_next_non_special_sequence(text_to_parse)
        text_to_parse = text_to_parse[len(next_token):]
        text_to_parse = text_to_parse.lstrip()
        next_operator = find_next_operator(text_to_parse)
        if next_operator is not None:
            next_token = f"{next_token} {next_operator}"
            text_to_parse = text_to_parse[len(next_operator):]
            text_to_parse = text_to_parse.lstrip()
            if len(text_to_parse) > 0:
                subtoken, text_to_parse = separate_next_token(text_to_parse)
                next_token = f"{next_token} {subtoken}"
        return next_token, text_to_parse
    non_special_sequence = find_next_non_special_sequence(text_to_parse)
    if is_function(non_special_sequence):
        next_token, text_to_parse = separate_function_brackets(text_to_parse)
        text_to_parse = text_to_parse.lstrip()
        next_operator = find_next_operator(text_to_parse)
        if next_operator is not None:
            next_token = f"{next_token} {next_operator}"
            text_to_parse = text_to_parse[len(next_operator):]
            text_to_parse = text_to_parse.lstrip()
            if len(text_to_parse) > 0:
                subtoken, text_to_parse = separate_next_token(text_to_parse)
                next_token = f"{next_token} {subtoken}"
        return next_token, text_to_parse
    raise RuntimeError(f'syntax error: {text_to_parse}')


if __name__ == '__main__':
    from pathlib import Path
    dst_desc = Path('syntaxes/STX1.txt').read_text(encoding='utf-8')
    src_desc = Path('syntaxes/STX3.txt').read_text(encoding='utf-8')
    text = Path('solutions/ptokareva/full.md').read_text(encoding='utf-8')
    is_code = False
    is_valid_code = False
    lines = []
    for line in text.split('\n'):
        if line == '```':
            is_code = not is_code
            is_valid_code = True
            lines.append(line)
            continue
        if not is_code:
            lines.append(line)
            continue
        new_line = convert_syntax(line, src_desc, dst_desc)
        lines.append(new_line)
    Path('output.md').write_text('\n'.join(lines), encoding='utf-8')
