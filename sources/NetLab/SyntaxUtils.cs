// Decompiled with JetBrains decompiler
// Type: ad
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using System;
using System.Collections;
using System.IO;
using System.Text;

public static class SyntaxUtils
{
  public static string ReadLine(MemoryStream memoryStream)
  {
    bool isNotEOL = true;
    byte[] numArray = new byte[1024];
    int index = -1;
    bool isNotEOF;
    do
    {
      ++index;
      numArray[index] = Convert.ToByte(memoryStream.ReadByte());
      if (!isNotEOL)
      {
        isNotEOF = numArray[index] > (byte) 0;
      }
      else
      {
        isNotEOF = true;
        isNotEOL = numArray[index] != (byte) 10;
      }
    }
    while (isNotEOL | isNotEOF);
    return new UnicodeEncoding().GetString(numArray, 0, Array.FindLastIndex<byte>(numArray, new Predicate<byte>(SyntaxUtils.IsCR))).Replace("\r", "");
  }

  private static bool IsCR(byte ch) => ch == (byte) 10;

  public static void WriteLine(MemoryStream memoryStream, string line)
  {
    UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
    memoryStream.Write(unicodeEncoding.GetBytes(line + "\n"), 0, unicodeEncoding.GetByteCount(line + "\n"));
  }

  public static string ConvertToBaseSyntax(string textToParseArgument, int syntaxNumber)
  {
    if (syntaxNumber == 0)
      return textToParseArgument;
    ArrayList operands = new ArrayList();
    string textToParse = textToParseArgument;
    string label = "";
    while (true)
    {
      SyntaxUtils.TrimLeftSpaces(ref textToParse);
      if (!(textToParse == "") && textToParse[0] != ';')
        operands.Add((object) SyntaxUtils.SeparateFunctionArgument(ref textToParse));
      else
        break;
    }
    if (operands.Count > 0)
    {
      textToParse = (string) operands[0];
      if (textToParse[textToParse.Length - 1] == ':')
      {
        label = (string) operands[0];
        operands.RemoveAt(0);
      }
    }
    if (operands.Count > 0 && !operands.Contains((object) "declare"))
    {
      for (int index = 0; index < operands.Count; ++index)
      {
        if (MainWindow.baseKeywords.IndexOf(operands[index]) >= 0 && MainWindow.keywords.IndexOf(operands[index]) < 0)
          ++MainWindow.baseSyntaxErrorFlag;
        if (MainWindow.ae.IndexOf(operands[index]) >= 0)
          ++MainWindow.forbiddenWordFlag;
      }
    }
    int keywordIndexInSyntaxDesc = -1;
    if (operands.IndexOf((object) "declare") >= 0)
    {
      operands.Remove((object) "declare");
      int declareIndexInSyntaxDesc = MainWindow.keywords.IndexOf((object) "declare");
      string declareResult = label + " " + (string) MainWindow.baseKeywords[declareIndexInSyntaxDesc];
      foreach (char ch in (string) MainWindow.operandOrders[declareIndexInSyntaxDesc])
      {
        switch (ch)
        {
          case 'f':
            if (operands.Count > 0)
            {
              declareResult = declareResult + " " + operands[0]?.ToString();
              operands.RemoveAt(0);
              break;
            }
            break;
          case 'l':
            if (operands.Count > 0)
            {
              declareResult = declareResult + " " + operands[operands.Count - 1]?.ToString();
              operands.RemoveAt(operands.Count - 1);
              break;
            }
            break;
          case 'r':
            if (operands.Count > 0)
            {
              for (int index3 = 0; index3 < operands.Count; ++index3)
                declareResult = declareResult + " " + operands[index3]?.ToString();
              operands.Clear();
              break;
            }
            break;
        }
      }
      return declareResult;
    }
    for (int keywordIndex = 0; keywordIndex < operands.Count; ++keywordIndex)
    {
      keywordIndexInSyntaxDesc = MainWindow.keywords.IndexOf(operands[keywordIndex]);
      if (keywordIndexInSyntaxDesc >= 0)
      {
        operands.RemoveAt(keywordIndex);
        string keywordIndexUnused = (string) MainWindow.operandOrders[keywordIndexInSyntaxDesc];
        label = label + " " + (string) MainWindow.baseKeywords[keywordIndexInSyntaxDesc];
        foreach (char ch in (string) MainWindow.operandOrders[keywordIndexInSyntaxDesc])
        {
          switch (ch)
          {
            case 'f':
              if (operands.Count > 0)
              {
                label = label + " " + operands[0]?.ToString();
                operands.RemoveAt(0);
                break;
              }
              break;
            case 'l':
              if (operands.Count > 0)
              {
                label = label + " " + operands[operands.Count - 1]?.ToString();
                operands.RemoveAt(operands.Count - 1);
                break;
              }
              break;
            case 'r':
              if (operands.Count > 0)
              {
                for (int index5 = 0; index5 < operands.Count; ++index5)
                  label = label + " " + operands[index5]?.ToString();
                operands.Clear();
                break;
              }
              break;
          }
        }
      }
    }
    if (keywordIndexInSyntaxDesc < 0 && operands.Count > 0)
    {
      for (int index = 0; index < operands.Count; ++index)
        label = label + " " + operands[index]?.ToString();
    }
    return label;
  }

  private static bool IsSpace(char ch) => ch == ' ' || ch == '\t';

  private static bool IsSpecialCharacter(char ch)
  {
    return ch == ' ' || ch == '\t' || ch == ';' || ch == ',' || ch == '(' || ch == ')' || ch == '$' || ch == '+' || ch == '-' || ch == '*' || ch == '/' || ch == '%' || ch == '|' || ch == '&' || ch == '!' || ch == '=' || ch == '<' || ch == '>' || ch == '#';
  }

  public static void TrimLeftSpaces(ref string textToParse)
  {
    int num = 0;
    while (num < textToParse.Length && SyntaxUtils.IsSpace(textToParse[num]))
      ++num;
    if (textToParse.Length > 0 && textToParse[0] == ';')
      textToParse = "";
    else
      textToParse = textToParse.Substring(num);
  }

  public static string FindNextOperator(string textToParse)
  {
    string str = "";
    if (textToParse.Length >= 2)
    {
      if (textToParse[0] == '&' && textToParse[1] == '&')
        str = "&&";
      if (textToParse[0] == '|' && textToParse[1] == '|')
        str = "||";
      if (textToParse[0] == '=' && textToParse[1] == '=')
        str = "==";
      if (textToParse[0] == '!' && textToParse[1] == '=')
        str = "!=";
      if (textToParse[0] == '>' && textToParse[1] == '=')
        str = ">=";
      if (textToParse[0] == '<' && textToParse[1] == '=')
        str = "<=";
      if (textToParse[0] == '!' && textToParse[1] == '!')
        str = "!!";
    }
    if (str == "" && textToParse.Length >= 1)
    {
      switch (textToParse[0])
      {
        case '!':
          str = "!";
          break;
        case '%':
          str = "%";
          break;
        case '&':
          str = "&";
          break;
        case '*':
          str = "*";
          break;
        case '+':
          str = "+";
          break;
        case '-':
          str = "-";
          break;
        case '/':
          str = "/";
          break;
        case '<':
          str = "<";
          break;
        case '>':
          str = ">";
          break;
        case '|':
          str = "|";
          break;
      }
    }
    return str;
  }

  public static string FindNextNonSpecialSequence(string textToParse)
  {
    SyntaxUtils.TrimLeftSpaces(ref textToParse);
    string str = textToParse;
    int num = 0;
    while (num < str.Length && !SyntaxUtils.IsSpecialCharacter(str[num]))
      ++num;
    return str.Substring(0, num);
  }

  public static string SeparateNextNonSpecialSequence(ref string textToParse)
  {
    SyntaxUtils.TrimLeftSpaces(ref textToParse);
    string str = SyntaxUtils.FindNextNonSpecialSequence(textToParse);
    textToParse = textToParse.Remove(0, str.Length);
    return str;
  }

  public static string SeparateFunctionArgument(ref string textToParse)
  {
    SyntaxUtils.TrimLeftSpaces(ref textToParse);
    string argument;
    if (textToParse[0] == '$' || textToParse[0] == '(' || textToParse[0] == '"' || textToParse[0] == '#' || SyntaxUtils.IsDigit(textToParse[0]) || SyntaxUtils.IsUnaryOperator(textToParse))
    {
      argument = SyntaxUtils.SeparateNextToken(ref textToParse);
    }
    else
    {
      string nonSpecialSequence = SyntaxUtils.FindNextNonSpecialSequence(textToParse);
      if (SyntaxUtils.IsFunction(nonSpecialSequence))
        argument = SyntaxUtils.SeparateNextToken(ref textToParse);
      else if (nonSpecialSequence.Length == 0)
      {
        argument = textToParse;
        textToParse = "";
        ++MainWindow.syntaxErrorFlag;
      }
      else
      {
        textToParse = textToParse.Remove(0, nonSpecialSequence.Length);
        argument = nonSpecialSequence;
      }
    }
    return argument;
  }

  public static bool IsDigit(char ch)
  {
    return ch == '1' || ch == '2' || ch == '3' || ch == '4' || ch == '5' || ch == '6' || ch == '7' || ch == '8' || ch == '9' || ch == '0';
  }

  public static bool IsUnaryOperator(string textToParse)
  {
    string str = SyntaxUtils.FindNextOperator(textToParse);
    return str == "-" || str == "!" || str == "!!";
  }

  public static bool IsFunction(string token)
  {
    return token == "sizeof" || token == "pos" || token == "peek" || token == "dequeue" || token == "qcount" || token == "CurrentSystemName" || token == "SystemTime" || token == "random" || token == "copy" || token == "locguide";
  }

  public static string SeparateFunctionBrackets(ref string textToParse)
  {
    string functionNameFirstVar = SyntaxUtils.FindNextNonSpecialSequence(textToParse);
    textToParse = textToParse.Remove(0, functionNameFirstVar.Length);
    string functionNameSecondVar = functionNameFirstVar;
    SyntaxUtils.TrimLeftSpaces(ref textToParse);
    string result;
    if (textToParse.Length > 0 && textToParse[0] == '(')
    {
      result = functionNameSecondVar + textToParse[0].ToString();
      textToParse = textToParse.Remove(0, 1);
      while (true)
      {
        SyntaxUtils.TrimLeftSpaces(ref textToParse);
        if (!(textToParse == ""))
        {
          if (textToParse[0] != ')')
          {
            if (textToParse[0] == ',')
            {
              result += textToParse[0].ToString();
              textToParse = textToParse.Remove(0, 1);
            }
            else
              result += SyntaxUtils.SeparateFunctionArgument(ref textToParse);
          }
          else
            break;
        }
        else
          goto label_9;
      }
      result += textToParse[0].ToString();
      textToParse = textToParse.Remove(0, 1);
    }
    else
    {
      ++MainWindow.syntaxErrorFlag;
      result = functionNameSecondVar + textToParse;
      textToParse = "";
    }
label_9:
    return result;
  }

  public static string SeparateNextToken(ref string textToParse)
  {
    string emptyString = "";
    string nextToken;
    if (textToParse[0] == '$')
    {
      textToParse = textToParse.Remove(0, 1);
      string name = SyntaxUtils.FindNextNonSpecialSequence(textToParse);
      textToParse = textToParse.Remove(0, name.Length);
      SyntaxUtils.TrimLeftSpaces(ref textToParse);
      nextToken = emptyString + "$" + name;
      if (textToParse.Length > 0 && SyntaxUtils.FindNextOperator(textToParse) != "")
      {
        nextToken += SyntaxUtils.FindNextOperator(textToParse);
        textToParse = textToParse.Remove(0, SyntaxUtils.FindNextOperator(textToParse).Length);
        SyntaxUtils.TrimLeftSpaces(ref textToParse);
        if (textToParse.Length > 0)
          nextToken += SyntaxUtils.SeparateNextToken(ref textToParse);
      }
    }
    else if (textToParse[0] == '(')
    {
      string leftBracket = emptyString + textToParse[0].ToString();
      textToParse = textToParse.Remove(0, 1);
      SyntaxUtils.TrimLeftSpaces(ref textToParse);
      nextToken = leftBracket + SyntaxUtils.SeparateNextToken(ref textToParse);
      SyntaxUtils.TrimLeftSpaces(ref textToParse);
      if (textToParse.Length > 0 && textToParse[0] == ')')
      {
        nextToken += textToParse[0].ToString();
        textToParse = textToParse.Remove(0, 1);
      }
      SyntaxUtils.TrimLeftSpaces(ref textToParse);
      if (textToParse.Length > 0 && SyntaxUtils.FindNextOperator(textToParse) != "")
      {
        nextToken += SyntaxUtils.FindNextOperator(textToParse);
        textToParse = textToParse.Remove(0, SyntaxUtils.FindNextOperator(textToParse).Length);
        SyntaxUtils.TrimLeftSpaces(ref textToParse);
        if (textToParse.Length > 0)
          nextToken += SyntaxUtils.SeparateNextToken(ref textToParse);
      }
    }
    else if (textToParse[0] == '#')
    {
      textToParse = textToParse.Remove(0, 1);
      string nonSpecialSequence = SyntaxUtils.FindNextNonSpecialSequence(textToParse);
      textToParse = textToParse.Remove(0, nonSpecialSequence.Length);
      SyntaxUtils.TrimLeftSpaces(ref textToParse);
      nextToken = emptyString + "#" + nonSpecialSequence;
      if (textToParse.Length > 0 && SyntaxUtils.FindNextOperator(textToParse) != "")
      {
        nextToken += SyntaxUtils.FindNextOperator(textToParse);
        textToParse = textToParse.Remove(0, SyntaxUtils.FindNextOperator(textToParse).Length);
        SyntaxUtils.TrimLeftSpaces(ref textToParse);
        if (textToParse.Length > 0)
          nextToken += SyntaxUtils.SeparateNextToken(ref textToParse);
      }
    }
    else if (SyntaxUtils.IsUnaryOperator(textToParse))
    {
      nextToken = emptyString + SyntaxUtils.FindNextOperator(textToParse);
      textToParse = textToParse.Remove(0, SyntaxUtils.FindNextOperator(textToParse).Length);
      SyntaxUtils.TrimLeftSpaces(ref textToParse);
      if (textToParse.Length > 0)
        nextToken += SyntaxUtils.SeparateNextToken(ref textToParse);
    }
    else if (textToParse[0] == '"')
    {
      nextToken = emptyString + textToParse[0].ToString();
      textToParse = textToParse.Remove(0, 1);
      int num;
      for (num = 0; num < textToParse.Length && textToParse[num] != '"'; ++num)
        nextToken += textToParse[num].ToString();
      textToParse = textToParse.Remove(0, num);
      if (textToParse.Length >= 1 && textToParse[0] == '"')
      {
        nextToken += "\"";
        textToParse = textToParse.Remove(0, 1);
      }
      SyntaxUtils.TrimLeftSpaces(ref textToParse);
      if (textToParse.Length > 0 && SyntaxUtils.FindNextOperator(textToParse) != "")
      {
        nextToken += SyntaxUtils.FindNextOperator(textToParse);
        textToParse = textToParse.Remove(0, SyntaxUtils.FindNextOperator(textToParse).Length);
        SyntaxUtils.TrimLeftSpaces(ref textToParse);
        if (textToParse.Length > 0)
          nextToken += SyntaxUtils.SeparateNextToken(ref textToParse);
      }
    }
    else if (SyntaxUtils.IsDigit(textToParse[0]))
    {
      string nonSpecialSequence = SyntaxUtils.FindNextNonSpecialSequence(textToParse);
      textToParse = textToParse.Remove(0, nonSpecialSequence.Length);
      SyntaxUtils.TrimLeftSpaces(ref textToParse);
      nextToken = emptyString + nonSpecialSequence;
      if (textToParse.Length > 0 && SyntaxUtils.FindNextOperator(textToParse) != "")
      {
        nextToken += SyntaxUtils.FindNextOperator(textToParse);
        textToParse = textToParse.Remove(0, SyntaxUtils.FindNextOperator(textToParse).Length);
        SyntaxUtils.TrimLeftSpaces(ref textToParse);
        if (textToParse.Length > 0)
          nextToken += SyntaxUtils.SeparateNextToken(ref textToParse);
      }
    }
    else if (SyntaxUtils.IsFunction(SyntaxUtils.FindNextNonSpecialSequence(textToParse)))
    {
      nextToken = emptyString + SyntaxUtils.SeparateFunctionBrackets(ref textToParse);
      SyntaxUtils.TrimLeftSpaces(ref textToParse);
      if (textToParse.Length > 0 && SyntaxUtils.FindNextOperator(textToParse) != "")
      {
        nextToken += SyntaxUtils.FindNextOperator(textToParse);
        textToParse = textToParse.Remove(0, SyntaxUtils.FindNextOperator(textToParse).Length);
        SyntaxUtils.TrimLeftSpaces(ref textToParse);
        if (textToParse.Length > 0)
          nextToken += SyntaxUtils.SeparateNextToken(ref textToParse);
      }
    }
    else
    {
      ++MainWindow.syntaxErrorFlag;
      nextToken = emptyString + textToParse;
      textToParse = "";
    }
    return nextToken;
  }
}
