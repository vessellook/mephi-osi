# Общее

Год создания 2024.

# Уровень представления

Скопировано из asvaselyuk

## P_INIT.REQ

```
declare integer CODE_SYNTAX_REQ
declare integer CODE_SYNTAX_RESP
declare integer CODE_EXPEDITED_DATA
declare integer CODE_P_P_ABORT

setto 1 CODE_SYNTAX_REQ
setto 2 CODE_SYNTAX_RESP
setto 3 CODE_EXPEDITED_DATA
setto 4 CODE_P_P_ABORT

declare string TERMINAL
setto "!&" TERMINAL

declare integer code_pac
declare string left_border
declare string right_border
declare buffer allowed_syntaxes
declare integer current_syntax
declare integer syntax_pac
declare integer syntax_pac2
declare buffer current_buffer
declare buffer current_quality
declare string tmp
declare integer wait_s_u_abort
declare buffer sizes
declare buffer prefix
declare buffer output
declare integer curr_len
declare integer count_len
declare integer loops
declare integer pos_1
declare integer pos_2
```

## P_CONNECT.REQ

```
;параметры:  address (число), quality (буфер), demand (буфер), context (буфер)
left_border 1 right_border 1 allowed_syntaxes sizeof(context)-2 unpack context
generatedown S_CONNECT.REQ address $address quality $quality demand $demand
```

## P_CONNECT.RESP

```
;параметры:  address (число), quality (буфер), context (буфер)
left_border 1 right_border 1 allowed_syntaxes sizeof(context)-2 unpack context
generatedown S_CONNECT.RESP address $address quality $quality
```

## P_DATA.REQ
TODO: нужно конвертацию сделать
```
;параметры:  userdata (буфер)
code_pac 1 current_buffer sizeof(userdata)-1 unpack userdata
if struct $code_pac == 1
no_struct:
if sized_no_struct $current_syntax == 1
output pack sizeof(current_buffer)+1+sizeof(TERMINAL) $code_pac 1 $current_buffer sizeof(current_buffer) $TERMINAL sizeof(TERMINAL)
goto send

sized_no_struct:
output pack sizeof(current_buffer)+1 sizeof(current_buffer) 1 $current_buffer sizeof(current_buffer)
goto send

struct:
setto 0 loops
sizes pack 0
tmp 1 current_buffer sizeof(current_buffer)-1 unpack current_buffer
setto 0 pos_1
setto 0 pos_2
loop:
setto $loops+1 loops
if break_loop $loops >= 5
tmp $pos_2 current_buffer sizeof(current_buffer)-$pos_2 unpack current_buffer
tmp sizeof(current_buffer) unpack current_buffer
setto pos($left_border,tmp) pos_1
setto pos($right_border,tmp) pos_2
if break_loop ($pos_2 == 0) && ($pos_1 == 0)
;empty if $pos_2 <= $pos_1 + 1
tmp $pos_1 prefix $pos_2-$pos_1-1 unpack current_buffer
goto append

append:
if sized_append $current_syntax == 1
prefix pack sizeof(prefix)+sizeof(TERMINAL) $prefix sizeof(prefix) $TERMINAL sizeof(TERMINAL)
output pack sizeof(output)+sizeof(prefix) $output sizeof(output) $prefix sizeof(prefix)
goto loop

sized_append:
output pack sizeof(prefix)+1+sizeof(output) $output sizeof(output) sizeof(prefix) 1 $prefix sizeof(prefix)
goto loop

break_loop:
if send $current_syntax == 2
output pack sizeof(output)+1 sizeof(output) 1 $output sizeof(output)

send:
output pack sizeof(output)+1 $code_pac 1 $output sizeof(output)
generatedown S_DATA.REQ userdata $output
```

## P_EXPEDITED_DATA.REQ
TODO: нужно конвертацию сделать
```
;параметры:  userdata (буфер)
code_pac 1 current_buffer sizeof(userdata)-1 unpack userdata
if struct $code_pac == 1
no_struct:
if sized_no_struct $current_syntax == 1
output pack sizeof(current_buffer)+1+sizeof(TERMINAL) $code_pac 1 $current_buffer sizeof(current_buffer) $TERMINAL sizeof(TERMINAL)
goto send

sized_no_struct:
output pack sizeof(current_buffer)+1 sizeof(current_buffer) 1 $current_buffer sizeof(current_buffer)
goto send

struct:
setto 0 loops
sizes pack 0
output pack 0
tmp 1 current_buffer sizeof(current_buffer)-2 unpack current_buffer
setto 0 pos_1
setto 0 pos_2
loop:
setto $loops+1 loops
if break_loop $loops >= 5
tmp $pos_2 current_buffer sizeof(current_buffer)-$pos_2 unpack current_buffer
tmp sizeof(current_buffer) unpack current_buffer
setto pos($left_border,tmp) pos_1
setto pos($right_border,tmp) pos_2break_loop if ($pos_2 == 0) && ($pos_1 == 0)
;empty if $pos_2 <= $pos_1 + 1
tmp $pos_1 prefix $pos_2-$pos_1-1 unpack current_buffer
goto append
;empty:
;0 pack prefix
;goto append

append:
if sized_append $current_syntax == 1
prefix pack sizeof(prefix)+sizeof(TERMINAL) $prefix sizeof(prefix) $TERMINAL sizeof(TERMINAL)
output pack sizeof(output)+sizeof(prefix) $output sizeof(output) $prefix sizeof(prefix)
goto loop

sized_append:
output pack sizeof(prefix)+1+sizeof(output) $output sizeof(output) sizeof(prefix) 1 $prefix sizeof(prefix)
goto loop

break_loop:
if send $current_syntax == 1
output pack sizeof(output)+1 sizeof(output) 1 output sizeof(output)

send:
current_buffer pack sizeof(code_pac)+sizeof(output) $CODE_EXPEDITED_DATA sizeof(code_pac) $output sizeof(output)
generatedown S_EXPEDITED_DATA.REQ userdata $current_buffer
```

## P_GIVE_TOKENS.REQ
```
;параметры:  token (число)
generatedown S_GIVE_TOKENS.REQ token $token
```

## P_P_ABORT.IND
```
;параметры:  нет
up P_P_ABORT.IND
```

## P_PLEASE_TOKENS.REQ
```
;параметры:  token (число)
generatedown S_PLEASE_TOKENS.REQ token $token
```

## P_RELEASE.REQ
```
;параметры:  нет
generatedown S_RELEASE.REQ
```

## P_RELEASE.RESP
```
;параметры:  нет
generatedown S_RELEASE.RESP
```

## P_RESYNCHRONIZE.REQ
```
;параметры:  token (число)
generatedown S_RESYNCHRONIZE.REQ token $token
```

## P_RESYNCHRONIZE.RESP
```
;параметры:  token (число)
generatedown S_RESYNCHRONIZE.RESP token $token
```

## P_SYNC_MAJOR.REQ
```
;параметры:  нет
generatedown S_SYNC_MAJOR.REQ
```

## P_SYNC_MAJOR.RESP
```
;параметры:  нет
generatedown S_SYNC_MAJOR.RESP
```

## P_U_ABORT.REQ
```
;параметры:  нет
generatedown S_U_ABORT.REQ
```

## S_CONNECT.CONF
После получении подтверждения S соединения происходит обмен допустимыми синтаксисами
```
;параметры:  quality (буфер)
setto $quality current_quality
current_buffer pack sizeof(code_pac)+sizeof(allowed_syntaxes) $CODE_SYNTAX_REQ sizeof(code_pac) $allowed_syntaxes sizeof(allowed_syntaxes)
generatedown S_EXPEDITED_DATA.REQ userdata $current_buffer
```

## S_CONNECT.IND
```
;параметры:  address (число), quality (буфер), demand (буфер)
address $address quality $quality demand $demand up P_CONNECT.IND
```

## S_DATA.IND
```
;параметры:  userdata (буфер)
code_pac sizeof(code_pac) current_buffer sizeof(userdata)-1 unpack userdata
if struct $code_pac == 1
no_struct:
if sized_no_struct $current_syntax == 1
tmp sizeof(current_buffer) unpack current_buffer
setto pos($TERMINAL, tmp) pos_1
output $pos_1-1 unpack current_buffer
goto send

sized_no_struct:
curr_len 1 current_buffer sizeof(current_buffer)-1 unpack current_buffer
output $curr_len unpack current_buffer
goto send

struct:
if sized_struct $current_syntax == 1
output pack sizeof(left_border)+1 $code_pac 1 $left_border sizeof(left_border)
terminated_loop:
tmp sizeof(current_buffer) unpack current_buffer
setto pos($TERMINAL,tmp) pos_1
if terminated_loop_break $pos_1 == 0
prefix $pos_1-1 tmp 2 current_buffer sizeof(current_buffer)-$pos_1-1 unpack current_buffer
output pack sizeof(output)+sizeof(left_border)+sizeof(prefix)+sizeof(right_border) $output sizeof(output) $left_border sizeof(left_border) $prefix sizeof(prefix) $right_border sizeof(right_border)
goto terminated_loop

terminated_loop_break:
output pack sizeof(output)+sizeof(right_border) $output sizeof(output) $right_border sizeof(right_border)
goto send

sized_struct:
tmp 1 current_buffer sizeof(current_buffer)-1 unpack current_buffer
output pack sizeof(left_border) $left_border sizeof(left_border)
sized_loop:
if sized_loop_break sizeof(current_buffer) == 0
count_len 1 current_buffer sizeof(current_buffer)-1 unpack current_buffer
if sized_loop_break sizeof(current_buffer) < $count_len
prefix $count_len current_buffer sizeof(current_buffer)-$count_len unpack current_buffer
output pack sizeof(output)+sizeof(left_border)+sizeof(prefix)+sizeof(right_border) $output sizeof(output) $left_border sizeof(left_border) $prefix sizeof(prefix) $right_border sizeof(right_border)
goto sized_loop

sized_loop_break:
output pack sizeof(output)+sizeof(right_border) $output sizeof(output) $right_border sizeof(right_border)
goto send

send:
output pack sizeof(output)+1 $code_pac 1 $output sizeof(output)
userdata $output up P_DATA.IND
return
```

## S_EXPEDITED_DATA.IND
TODO: тут нужно сделать switch по типу пакета
```
;параметры:  userdata (буфер)
code_pac sizeof(code_pac) current_buffer sizeof(userdata)-sizeof(code_pac) unpack userdata
if syntax_req $code_pac == $CODE_SYNTAX_REQ
if syntax_res $code_pac == $CODE_SYNTAX_RESP
if abort_ind $code_pac == $CODE_P_P_ABORT
if expedited_data $code_pac == $CODE_EXPEDITED_DATA
return

syntax_req:
syntax_pac sizeof(syntax_pac) current_buffer sizeof(current_buffer)-sizeof(syntax_pac) unpack current_buffer
current_syntax sizeof(current_syntax) allowed_syntaxes sizeof(allowed_syntaxes)-sizeof(current_syntax) unpack allowed_syntaxes
if send_syntax $current_syntax == $syntax_pac
if skip_second_syntax_pac sizeof(current_buffer) == 0
syntax_pac2 sizeof(syntax_pac2) unpack current_buffer
if send_syntax $current_syntax == $syntax_pac2
skip_second_syntax_pac:
if abort sizeof(allowed_syntaxes) == 0
current_syntax sizeof(current_syntax) unpack allowed_syntaxes
if send_syntax $current_syntax == $syntax_pac
if abort sizeof(current_buffer) == 0
if send_syntax $current_syntax == $syntax_pac2
abort:
setto 1 wait_s_u_abort
up P_P_ABORT.IND
current_buffer pack sizeof(code_pac) $CODE_P_P_ABORT sizeof(code_pac)
generatedown S_EXPEDITED_DATA.REQ userdata $current_buffer
return
send_syntax:
current_buffer pack sizeof(code_pac)+sizeof(current_syntax) $CODE_SYNTAX_RESP sizeof(code_pac) $current_syntax sizeof(current_syntax)
generatedown S_EXPEDITED_DATA.REQ userdata $current_buffer
return

syntax_res:
current_syntax sizeof(current_syntax) unpack current_buffer
current_buffer pack 3 $left_border 1 $right_border 1 $current_syntax sizeof(current_syntax)
quality $current_quality context $current_buffer up P_CONNECT.CONF
setto 0 wait_s_u_abort
return

abort_ind:
up P_P_ABORT.IND
return

expedited_data:
code_pac sizeof(code_pac) current_buffer sizeof(current_buffer)-1 unpack current_buffer
if struct $code_pac == 1
no_struct:
if sized_no_struct $current_syntax == 1
;unbuffer current_buffer code_pac 1 current_buffer sizeof(current_buffer)-1
tmp sizeof(current_buffer) unpack current_buffer
setto pos($TERMINAL,tmp) pos_1
output $pos_1-1 unpack current_buffer
goto send

sized_no_struct:
curr_len 1 current_buffer sizeof(current_buffer)-1 unpack current_buffer
output $curr_len unpack current_buffer
goto send

struct:
if sized_struct $current_syntax == 1
output pack sizeof(left_border)+1 $code_pac 1 $left_border sizeof(left_border)
terminated_loop:
tmp sizeof(current_buffer) unpack current_buffer
setto pos($TERMINAL,tmp) pos_1
if terminated_loop_break $pos_1 == 0
prefix $pos_1-1 tmp 2 current_buffer sizeof(current_buffer)-$pos_1-1 unpack current_buffer
output pack sizeof(output)+sizeof(left_border)+sizeof(prefix)+sizeof(right_border) $output sizeof(output) $left_border sizeof(left_border) $prefix sizeof(prefix) $right_border sizeof(right_border)
goto terminated_loop

terminated_loop_break:
output pack sizeof(output)+sizeof(right_border) $output sizeof(output) $right_border sizeof(right_border)
goto send

sized_struct:
tmp 1 current_buffer sizeof(current_buffer)-1 unpack current_buffer
output pack sizeof(left_border) $left_border sizeof(left_border)
sized_loop:
if sized_loop_break sizeof(current_buffer) == 0
count_len 1 current_buffer sizeof(current_buffer)-1 unpack current_buffer
if sized_loop_break sizeof(current_buffer) < $count_len
prefix $count_len current_buffer sizeof(current_buffer)-$count_len unpack current_buffer
output pack sizeof(output)+sizeof(left_border)+sizeof(prefix)+sizeof(right_border) $output sizeof(output) $left_border sizeof(left_border) $prefix sizeof(prefix) $right_border sizeof(right_border)
goto sized_loop

sized_loop_break:
output pack sizeof(output)+sizeof(right_border) $output sizeof(output) $right_border sizeof(right_border)
goto send

send:
output pack sizeof(output)+1 $code_pac 1 $output sizeof(output)
userdata $output up P_EXPEDITED_DATA.IND
return
```

## S_GIVE_TOKENS.IND
```
;параметры:  token (число)
token $token up P_GIVE_TOKENS.IND
```

## S_P_EXCEPTION.IND
```
;параметры:  error (число)
error $error up P_P_EXCEPTION.IND
```

## S_PLEASE_TOKENS.IND
```
;параметры:  token (число)
token $token up P_PLEASE_TOKENS.IND
```

## S_RELEASE.CONF
```
;параметры:  нет
up P_RELEASE.CONF
```

## S_RELEASE.IND
```
;параметры:  нет
up P_RELEASE.IND
```

## S_RESYNCHRONIZE.CONF
```
;параметры:  token (число)
token $token up P_RESYNCHRONIZE.CONF
```

## S_RESYNCHRONIZE.IND
```
;параметры:  token (число)
token $token up P_RESYNCHRONIZE.IND
```

## S_SYNC_MAJOR.CONF
```
;параметры:  нет
up P_SYNC_MAJOR.CONF
```

## S_SYNC_MAJOR.IND
```
;параметры:  нет
up P_SYNC_MAJOR.IND
```

## S_U_ABORT.IND
```
;параметры:  нет
if skip $wait_s_u_abort == 1
up P_U_ABORT.IND
skip:
```

# Сеансовый уровень

Скопировано из asvaselyuk

## S_INIT.REQ
```
declare buffer quality_value
declare buffer demand_value
declare integer start_markers_value
setto 0 start_markers_value
declare integer markers_value
declare integer protection
declare integer start_point

declare integer msg_crc
declare integer crc_value

declare buffer data
declare queue receive_queue

declare integer remote_address
declare integer msg_kind
declare integer size1
declare integer size2
declare integer has_data_marker
declare integer has_sync_marker
```

## S_CONNECT.REQ
```
;параметры:  address (число), quality (буфер), demand (буфер)
setto $quality quality_value
setto $demand demand_value
start_markers_value sizeof(start_markers_value) unpack demand
setto ($start_markers_value == 1) || ($start_markers_value == 3) has_data_marker
setto ($start_markers_value == 1) || ($start_markers_value == 4) has_sync_marker
generatedown T_CONNECT.REQ address $address
```

## S_CONNECT.RESP
```
;параметры:  address (число), quality (буфер)
setto $quality quality_value
data pack sizeof(msg_kind)+sizeof(size1)+sizeof(quality_value) 2 sizeof(msg_kind) sizeof(quality_value) sizeof(size1) $quality_value sizeof(quality_value)
generatedown T_DATA.REQ userdata $data
```

## S_DATA.REQ
Если отсутствует маркер данных, то это ошибка 1. При использовании защиты исполнение проходит через секцию protect

Добавлены ненужные команды setto 1 size1 и setto 0 size1
```
;параметры:   userdata (буфер)
if error_1 !!$has_data_marker

protection sizeof(protection) start_point sizeof(start_point) unpack quality_value
setto $userdata data
if add_to_queue !!$protection
setto 1 size1

protect:
msg_crc calccrc $data
data pack sizeof(data)+sizeof(msg_crc) $msg_crc sizeof(msg_crc) $data sizeof(data)

add_to_queue:
data pack sizeof(data)+sizeof(msg_kind) 9 sizeof(msg_kind) $data sizeof(data)
generatedown T_DATA.REQ userdata $data
return

error_1:
error 1 up S_P_EXCEPTION.IND
setto 0 size1
return
```

## S_EXPEDITED_DATA.REQ
При использовании защиты исполнение проходит через секцию protect

Добавлена ненужная команда setto 1 size2
```
;параметры:   userdata (буфер)

protection sizeof(protection) start_point sizeof(start_point) unpack quality_value
setto $userdata data

if send !!$protection
setto 1 size2

protect:
msg_crc calccrc $data
data pack sizeof(data)+sizeof(msg_crc)$msg_crc sizeof(msg_crc) $data sizeof(data)

send:
data pack sizeof(data)+sizeof(msg_kind) 10 sizeof(msg_kind) $data sizeof(data)
generatedown T_DATA.REQ userdata $data
```

## S_GIVE_TOKENS.REQ
Если передаётся маркер, которого нет у данной стороны, то нужно сгенерировать исключение о том, что обнаружен дубликат/потеря маркера (3). В противном случае нужно послать пакет с передачей маркера

```
;параметры:  token (число)
if error_1 (!!$has_data_marker) && ($token == 1)
if error_2 (!!$has_sync_marker) && ($token == 2)

data pack sizeof(msg_kind)+sizeof(token) 4 sizeof(msg_kind) $token sizeof(token)
generatedown T_DATA.REQ userdata $data

setto $has_data_marker && ($token != 1) has_data_marker
setto $has_sync_marker && ($token != 2) has_sync_marker
return

error_1:
error 1 up S_P_EXCEPTION.IND
return

error_2:
error 2 up S_P_EXCEPTION.IND
return
```

## S_PLEASE_TOKENS.REQ
Если запрошен маркер, который уже есть, то нужно сгенерировать исключение о том, что обнаружен дубликат/потеря маркера (3). В противном случае нужно послать пакет с запросом маркера

```
;параметры:  token (число)
if error_1 $has_data_marker && ($token == 1)
if error_2 $has_sync_marker && ($token == 2)
data pack sizeof(token)+sizeof(msg_kind) 3 sizeof(msg_kind) $token sizeof(token)
generatedown T_DATA.REQ userdata $data
return

error_1:
error 1 up S_P_EXCEPTION.IND
return

error_2:
error 2 up S_P_EXCEPTION.IND
return
```

## S_RELEASE.REQ
```
;параметры:  нет
data pack sizeof(msg_kind) 11 sizeof(msg_kind)
generatedown T_DATA.REQ userdata $data
```

## S_RELEASE.RESP
Добавлена ненужная команда generatedown T_DATA.REQ userdata $data после goto start
```
;параметры:  нет

start:
if repeat qcount(receive_queue) > 0
goto end

repeat:
userdata (dequeue(receive_queue)) up S_DATA.IND
goto start
generatedown T_DATA.REQ userdata $data

end:
data pack sizeof(msg_kind) 12 sizeof(msg_kind)
generatedown T_DATA.REQ userdata $data
```

## S_RESYNCHRONIZE.REQ
```
;параметры:  token (число)

clearqueue receive_queue
data pack sizeof(token)+sizeof(msg_kind) 5 sizeof(msg_kind) $token sizeof(token)
generatedown T_DATA.REQ userdata $data
```

## S_RESYNCHRONIZE.RESP
```
;параметры:  token (число)

clearqueue receive_queue
data pack sizeof(msg_kind)+sizeof(token) 6 sizeof(msg_kind) $token sizeof(token)
generatedown T_DATA.REQ userdata $data
; token содержит маркеры другой стороны, так что тут обратный предикат
setto ($token != 1) && ($token != 3) has_data_marker
setto ($token != 2) && ($token != 3) has_sync_marker
```

## S_SYNC_MAJOR.REQ
Если отсутствует маркер основной синхронизации, то это ошибка 2
```
;параметры:  нет
if error_2 !!$has_sync_marker
data pack sizeof(msg_kind) 7 sizeof(msg_kind)
generatedown T_DATA.REQ userdata $data
return

error_2:
error 2 up S_P_EXCEPTION.IND
return
```

## S_SYNC_MAJOR.RESP
```
;параметры:  нет

start:
if repeat qcount(receive_queue) > 0
goto end

repeat:
userdata (dequeue(receive_queue)) up S_DATA.IND
goto start

end:
data pack sizeof(msg_kind) 8 sizeof(msg_kind)
generatedown T_DATA.REQ userdata $data
```

## S_U_ABORT.REQ
```
;параметры:  нет
data pack sizeof(msg_kind) 13 sizeof(msg_kind)
generatedown T_DATA.REQ userdata $data
```

## T_CONNECT.CONF
```
;параметры:  address (число)

setto $address remote_address
data pack sizeof(msg_kind)+sizeof(size1)+sizeof(size2)+sizeof(quality_value)+sizeof(demand_value) 1 sizeof(msg_kind) sizeof(quality_value) sizeof(size1) sizeof(demand_value) sizeof(size2) $quality_value sizeof(quality_value) $demand_value sizeof(demand_value)
generatedown T_DATA.REQ userdata $data
```

## T_CONNECT.IND
```
;параметры:  address (число)

setto $address remote_address
generatedown T_CONNECT.RESP address $address
```

## T_DATA.IND
Обработка всех возможных типов пакетов
```
;параметры:  userdata (буфер)

msg_kind sizeof(msg_kind) data sizeof(userdata)-sizeof(msg_kind) unpack userdata
if kind_1 $msg_kind == 1
if kind_2 $msg_kind == 2
if kind_3 $msg_kind == 3
if kind_4 $msg_kind == 4
if kind_5 $msg_kind == 5
if kind_6 $msg_kind == 6
if kind_7 $msg_kind == 7
if kind_8 $msg_kind == 8
if kind_9 $msg_kind == 9
if kind_10 $msg_kind == 10
if kind_11 $msg_kind == 11
if kind_12 $msg_kind == 12
if kind_13 $msg_kind == 13
return

kind_1:
size1 sizeof(size1) size2 sizeof(size2) data sizeof(data)-sizeof(size1)-sizeof(size2) unpack data
quality_value $size1 demand_value $size2 unpack data
start_markers_value sizeof(start_markers_value) unpack demand_value
setto ($start_markers_value == 2) || ($start_markers_value == 4) has_data_marker
setto ($start_markers_value == 2) || ($start_markers_value == 3) has_sync_marker
address $remote_address quality $quality_value demand $demand_value up S_CONNECT.IND
return

kind_2:
size1 sizeof(size1) data sizeof(data)-sizeof(size1) unpack data
quality_value $size1 unpack data
quality $quality_value up S_CONNECT.CONF
return

kind_3:
markers_value sizeof(markers_value) unpack data
token $markers_value up S_PLEASE_TOKENS.IND
return

kind_4:
markers_value sizeof(markers_value) unpack data
token $markers_value up S_GIVE_TOKENS.IND
setto $has_data_marker || ($markers_value == 1) has_data_marker
setto $has_sync_marker || ($markers_value == 2) has_sync_marker
return

kind_5:
markers_value sizeof(markers_value) unpack data
token $markers_value up S_RESYNCHRONIZE.IND
return

kind_6:
markers_value sizeof(markers_value) unpack data
token $markers_value up S_RESYNCHRONIZE.CONF
setto ($markers_value == 1) || ($markers_value == 3) has_data_marker
setto ($markers_value == 2) || ($markers_value == 3) has_sync_marker
return

kind_7:
up S_SYNC_MAJOR.IND
return

kind_8:
if repeat_8 qcount(receive_queue) > 0
goto finish_8

repeat_8:
userdata (dequeue(receive_queue)) up S_DATA.IND
goto kind_8

finish_8:
up S_SYNC_MAJOR.CONF
return

kind_9:
protection sizeof(protection) start_point sizeof(start_point) unpack quality_value
if add_9 !!$protection

protect_9:
msg_crc sizeof(msg_crc) data sizeof(data)-sizeof(msg_crc) unpack data
crc_value calccrc $data
if skip $msg_crc != $crc_value

add_9:
receive_queue queue $data
return

kind_10:
protection sizeof(protection) start_point sizeof(start_point) unpack quality_value
if send_10 !!$protection

protect_10:
msg_crc sizeof(msg_crc) data sizeof(data)-sizeof(msg_crc) unpack data
crc_value calccrc $data
if skip $msg_crc != $crc_value

send_10:
userdata $data up S_EXPEDITED_DATA.IND
return

skip:
return

kind_11:
up S_RELEASE.IND
return

kind_12:
if repeat_12 qcount(receive_queue) > 0
goto finish_12

repeat_12:
userdata (dequeue(receive_queue)) up S_DATA.IND
goto kind_12

finish_12:
generatedown T_DISCONNECT.REQ address $remote_address
up S_RELEASE.CONF
return

kind_13:
generatedown T_DISCONNECT.REQ address $remote_address
up S_U_ABORT.IND
return
```

## T_DISCONNECT.IND
```
;параметры:  нет
```

# Транспортный уровень

Скопировано из asvaselyuk

## T_INIT.REQ
```
declare string state
setto "S" state
;адрес другой стороны
declare integer remote_address

declare integer req_num
declare integer ind_num
declare integer max_ack
declare integer msg_num
setto 0 req_num
setto 0 ind_num
setto 0 max_ack

declare integer wait_connect_timer
setto 0 wait_connect_timer
declare integer reconnect_timer
setto 0 reconnect_timer
declare integer resend_timer
setto 0 resend_timer

declare integer msg_kind

declare buffer buffer_for_crc
declare buffer pac
declare buffer data

declare integer crc_value
declare integer msg_crc
```

## N_CONNECT.CONF
```
;параметры:  address (число)
if skip $state == "F"
setto "D" state
address $address up T_CONNECT.CONF
untimer $reconnect_timer
return
skip:
untimer $reconnect_timer
setto "D" state
```

## N_CONNECT.IND
```
;параметры:  address (число)
if resp $state == "G"
setto "A" state
setto $address remote_address
address $address up T_CONNECT.IND
return
resp:
setto "C" state
untimer $wait_connect_timer
generatedown N_CONNECT.RESP address $remote_address
```

## N_DATA.IND
```
;параметры:   userdata (буфер)
if skip $state == "E"
; на всякий случай проверка размера
if skip sizeof(userdata) < sizeof(msg_crc)+sizeof(msg_num)+sizeof(msg_kind)
msg_crc sizeof(msg_crc) buffer_for_crc sizeof(userdata)-sizeof(msg_crc) unpack userdata
crc_value calccrc $buffer_for_crc
; контрольная сумма не сошлась
if skip $crc_value != $msg_crc
msg_num sizeof(msg_num) msg_kind sizeof(msg_kind) data sizeof(buffer_for_crc)-sizeof(msg_num)-sizeof(msg_kind) unpack buffer_for_crc
if ack $msg_kind == 1
; номер пакета больше, чем ожидалось
if skip $ind_num < $msg_num
; надо послать подтверждение пакета
buffer_for_crc pack sizeof(ind_num)+sizeof(msg_kind) $msg_num sizeof(msg_num) 1 sizeof(msg_kind)
crc_value calccrc $buffer_for_crc
pac pack sizeof(crc_value)+sizeof(buffer_for_crc) $crc_value sizeof(crc_value) $buffer_for_crc sizeof(buffer_for_crc)
generatedown N_DATA.REQ userdata $pac
; номер пакета меньше, чем ожидалось
if skip $ind_num > $msg_num
if stop ($state == "D") && ($msg_kind == 2)
if skip ($msg_kind == 2)
setto $msg_num+1 ind_num
; state == "C" || (state == "D" && $msg_kind != 2)
userdata $data up T_DATA.IND
return
ack:
if skip $max_ack > $msg_num
setto $msg_num+1 max_ack
return
stop:
setto "S" state
generatedown N_DISCONNECT.REQ
up T_DISCONNECT.IND
return
skip:
```

## N_DISCONNECT.IND
```
;параметры:  нет
if skip $state == "S"
if skip $state == "A"
if reconnect state == "B"
if wait_connect $state == "C"
if reconnect $state == "D"
if client_disconnected_server $state == "E"
if skip $state == "F"
if skip $state == "G"
return
client_disconnected_server:
setto "S" state
untimer $resend_timer
return
wait_connect:
setto "G" state
41 timer wait_connect_timer CANCEL_WAIT
return
reconnect:
setto "F" state
generatedown N_CONNECT.REQ address $remote_address
31 timer reconnect_timer RECONNECT1
return
skip:
setto "S" state
```

## RECONNECT1
```
; параметры: нет
generatedown N_DISCONNECT.REQ address $remote_address
4 timer reconnect_timer RECONNECT2
if skip $state == "F"
; $state == "B"
setto "S" state
return
skip:
```

## RECONNECT2
```
; параметры: нет
generatedown N_CONNECT.REQ address $remote_address
31 timer reconnect_timer RECONNECT1
if skip $state == "F"
; $state == "S"
setto "B" state
return
skip:
```

## RESEND
```
;параметры: cur_pac(buffer), cur_num(integer), attempts(integer)
if skip ($cur_num < $max_ack) || ($attempts <= 0)
generatedown N_DATA.REQ userdata $cur_pac
cur_pac $cur_pac cur_num $cur_num attempts $attempts-1 41 timer resend_timer RESEND
return
skip:
```

## T_CONNECT.REQ
```
;параметры:  address (число)
if strange_state $state == "E"
; state == S
setto "B" state
setto $address remote_address
generatedown N_CONNECT.REQ address $address
31 timer reconnect_timer RECONNECT1
return
strange_state:
up T_DISCONNECT.IND
```

## T_CONNECT.RESP
```
;параметры:  address (число)
; state == 1
setto "C" state
setto $address remote_address
generatedown N_CONNECT.RESP address $address
```

## T_DATA.REQ
```
;параметры:   userdata (буфер)
buffer_for_crc pack sizeof(req_num)+sizeof(msg_kind)+sizeof(userdata) $req_num sizeof(req_num) 0 sizeof(msg_kind) $userdata sizeof(userdata)
crc_value calccrc $buffer_for_crc
pac pack sizeof(crc_value)+sizeof(buffer_for_crc) $crc_value sizeof(crc_value) $buffer_for_crc sizeof(buffer_for_crc)
cur_pac $pac cur_num $req_num attempts 10 0 timer resend_timer RESEND
setto $req_num+1 req_num
```

## T_DISCONNECT.REQ
```
;параметры:  address (число)
if skip $state == "G"
if resend $state == "C"
; $state == "A" || $state == "D"||$state == "F"
setto "S" state
generatedown N_DISCONNECT.REQ address $address
return
resend:
buffer_for_crc pack sizeof(req_num)+sizeof(msg_kind) $req_num sizeof(req_num) 2 sizeof(msg_kind)
crc_value calccrc $buffer_for_crc
pac pack sizeof(crc_value)+sizeof(buffer_for_crc) $crc_value sizeof(crc_value) $buffer_for_crc sizeof(buffer_for_crc)
setto "E" state
cur_pac $pac cur_num $req_num attempts 10 0 timer resend_timer RESEND
;setto $req_num+1 req_num
return
skip:
setto "S" state
```
