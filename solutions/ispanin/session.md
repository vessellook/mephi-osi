# Общее

Синтаксис STX1.

Год создания 2024.

# Сеансовый уровень

Скопировано из avramenko

Сначала происходит установление T соединения, затем от клиента серверу передаются параметры качества quality (need_protection и major_sync_number) и начальная расстановка маркеров demand (markers_value), обратно сервер передаёт свои параметры качества quality. major_sync_number фактически не нужен.

markers_value указывает, как изначально распределены маркеры данных и синхронизации. Чтобы передать обычные или срочные данные, требуется маркер данных. Чтобы выполнить основную синхронизацию, требуется маркер синхронизации.

## ФОРМАТ ПАКЕТА
<тип пакета|1 слово><данные>

и в зависимости от типа <данные> это

```
c1:<quality_length| 1 слово><demand_length| 1 слово><quality| quality_length слов><demand | demand_length слов> - параметры запроса на соединение, причём quality_length = 2 и demand_length = 1
c2:<quality_length| 1 слово><quality| quality_length слов> - параметры ответа на запрос на соединение, причём quality_length = 2
a1:пустой буфер - запрос о разъединении
d1:[<crc| 1 слово>]<userdata> - запрос на передачу данных, crc присутствует для соединений с защитой, вроде бы такой совет даёт преподаватель
e1:[<crc| 1 слово>]<userdata> - запрос на передачу срочных данных, crc присутствует для соединений с защитой, вроде бы такой совет даёт преподаватель
r1:пустой буфер - запрос на упорядоченное разъединение
r2:пустой буфер - ответ на запрос на упорядоченное разъединение
m1:пустой буфер - запрос на основную синхронизацию
m2:пустой буфер - ответ на запрос об основной синхронизации
s1:<token| 1 слово> - запрос на ресинхронизацию
s2:<token| 1 слово> - ответ на запрос на ресинхронизацию
p1:<token| 1 слово> - запрос на маркер
g1:<token| 1 слово> - передача маркера
```

буфер quality имеет формат <need_protection| 1 слово><major_sync_number| 1 слово>

буфер demand имеет формат <marker| 1 слово>



## S_INIT.REQ
status - это ненужная переменная, предназначенная просто для заполнения T_DISCONNECT.IND и прочих мест
```
declare string status
set "IDLE" status
declare string code_pac
declare integer target_address
declare integer demand_length
declare buffer demand_buffer
declare integer quality_length
declare buffer quality_buffer
declare integer major_sync_number
declare integer need_protection
declare integer data_crc
declare integer data_crc2
declare buffer data_buffer
declare queue data_queue
declare integer token_value
; 1 бит отвечает за маркер данных
; 2 бит отвечает за маркер синхронизации
declare integer markers_state
declare integer markers_value
```

## S_CONNECT.REQ
```
;параметры:  address (число), quality (буфер), demand (буфер)

set $quality quality_buffer
set $demand demand_buffer

unbuffer markers_value sizeof(markers_value) demand
; 1 -> 3; 2 -> 0; 3 -> 1; 4 -> 2

set ($markers_value == 3) + 2 * ($markers_value == 4) + 3 * ($markers_value == 1) markers_state

T_CONNECT.REQ eventdown address $address
```

## S_CONNECT.RESP
SERBER вместо SERVER намеренно
```
;параметры:  address (число), quality (буфер)

set "SERBER" status
set $quality quality_buffer

"c2" 2 sizeof(quality_buffer) sizeof(quality_length) $quality_buffer sizeof(quality_buffer) 2+sizeof(quality_length)+sizeof(quality_buffer) buffer data_buffer

T_DATA.REQ eventdown userdata $data_buffer
```

## S_DATA.REQ
Если отсутствует маркер данных, то это ошибка 1. При использовании защиты исполнение проходит через секцию protect
```
;параметры:   userdata (буфер)

if ($markers_state & 1) data
S_P_EXCEPTION.IND eventup error 1
return

data:
unbuffer need_protection sizeof(need_protection) major_sync_number sizeof(major_sync_number) quality_buffer

set $userdata data_buffer

if !!$need_protection send

protect:
crc data_crc $data_buffer

$data_crc sizeof(data_crc) $data_buffer sizeof(data_buffer) sizeof(data_buffer)+sizeof(data_crc) buffer data_buffer

send:
"d1" 2 $userdata sizeof(data_buffer) sizeof(data_buffer)+2 buffer data_buffer

T_DATA.REQ eventdown userdata $data_buffer
return
```

## S_EXPEDITED_DATA.REQ
При использовании защиты исполнение проходит через секцию protect
```
;параметры:   userdata (буфер)

unbuffer need_protection sizeof(need_protection) major_sync_number sizeof(major_sync_number) quality_buffer

set $userdata data_buffer

if !!$need_protection send

protect:
crc data_crc $data_buffer

sizeof(data_crc) $data_buffer sizeof(data_buffer) sizeof(data_buffer)+sizeof(data_crc)$data_crc buffer data_buffer

send:
"e1" 2 $data_buffer sizeof(data_buffer) sizeof(data_buffer)+2 buffer data_buffer

T_DATA.REQ eventdown userdata $data_buffer
```

## S_GIVE_TOKENS.REQ
Если передаётся маркер, которого нет у данной стороны, то нужно сгенерировать исключение о том, что обнаружен дубликат/потеря маркера (3). В противном случае нужно послать пакет с передачей маркера

```
;параметры:  token (число)
if ($markers_state & $token) give_tokens

if $token == 1 error_1
if $token == 2 error_2
return

give_tokens:
"g1" 2 $token sizeof(token) 2+sizeof(token) buffer data_buffer

T_DATA.REQ eventdown userdata $data_buffer

set $markers_state-$token markers_state
return

error_1:
S_P_EXCEPTION.IND eventup error 1
return
error_2:
S_P_EXCEPTION.IND eventup error 2
return
```

## S_PLEASE_TOKENS.REQ
Если запрошен маркер, который уже есть, то нужно сгенерировать исключение о том, что обнаружен дубликат/потеря маркера (3). В противном случае нужно послать пакет с запросом маркера

```
;параметры:  token (число)
if ($token == 1) && ($markers_state & 1) error_1
if ($token == 2) && ($markers_state & 2) error_2

"p1" 2 $token sizeof(token) sizeof(token)+2 buffer data_buffer

T_DATA.REQ eventdown userdata $data_buffer
return

error_1:
S_P_EXCEPTION.IND eventup error 1
return
error_2:
S_P_EXCEPTION.IND eventup error 2
return
```

## S_RELEASE.REQ
```
;параметры:  нет
"r1" 2 2 buffer data_buffer

T_DATA.REQ eventdown userdata $data_buffer
```

## S_RELEASE.RESP
```
;параметры:  нет

start:
if qcount(data_queue) == 0 end

S_DATA.IND eventup userdata (dequeue(data_queue))

end:
"r2" 2 2 buffer data_buffer

T_DATA.REQ eventdown userdata $data_buffer
```

## S_RESYNCHRONIZE.REQ
```
;параметры:  token (число)

clearqueue data_queue

"s1" 2 $token sizeof(token) sizeof(token)+2 buffer data_buffer

T_DATA.REQ eventdown userdata $data_buffer
```

## S_RESYNCHRONIZE.RESP
```
;параметры:  token (число)

clearqueue data_queue

"s2" 2 $token sizeof(token) 2+sizeof(token) buffer data_buffer

T_DATA.REQ eventdown userdata $data_buffer

; 1 -> 2; 2 -> 1; 3 -> 0; 4 -> 3
set ($token == 2) + 2 * ($token == 1) + 3 * ($token == 4) markers_state
```

## S_SYNC_MAJOR.REQ
Если отсутствует маркер основной синхронизации, то это ошибка 2
```
;параметры:  нет
if ($markers_state & 2) sync_major

S_P_EXCEPTION.IND eventup error 2
return

sync_major:
"m1" 2 2 buffer data_buffer

T_DATA.REQ eventdown userdata $data_buffer
return
```

## S_SYNC_MAJOR.RESP
```
;параметры:  нет

start:
if qcount(data_queue) == 0 end

S_DATA.IND eventup userdata (dequeue(data_queue))

goto start

end:
"m2" 2 2 buffer data_buffer

T_DATA.REQ eventdown userdata $data_buffer
```

## S_U_ABORT.REQ
```
;параметры:  нет
"a1" 2 2 buffer data_buffer
T_DATA.REQ eventdown userdata $data_buffer
set "IDLE" status
```

## T_CONNECT.CONF
```
;параметры:  address (число)
if ($status == "CLIENT") || ($status == "SERVER") skip

set $address target_address

"c1" 2 sizeof(quality_buffer) sizeof(quality_length) sizeof(demand_buffer) sizeof(demand_length) $quality_buffer sizeof(quality_buffer) $demand_buffer sizeof(demand_buffer) 2+sizeof(quality_length)+sizeof(demand_length)+sizeof(quality_buffer)+sizeof(demand_buffer) buffer data_buffer

T_DATA.REQ eventdown userdata $data_buffer
return
skip:
```

## T_CONNECT.IND
```
;параметры:  address (число)
T_CONNECT.RESP eventdown address $address
set $address target_address
```

## T_DATA.IND
Обработка всех возможных типов пакетов
CIIENT вместо CLIENT намеренно
```
;параметры:  userdata (буфер)

unbuffer code_pac 2 data_buffer sizeof(userdata)-2 userdata
if $code_pac == "a1" label_a1
if $code_pac == "c1" label_c1
if $code_pac == "c2" label_c2
if $code_pac == "d1" label_d1
if $code_pac == "e1" label_e1
if $code_pac == "g1" label_g1
if $code_pac == "m1" label_m1
if $code_pac == "m2" label_m2
if $code_pac == "p1" label_p1
if $code_pac == "r1" label_r1
if $code_pac == "r2" label_r2
if $code_pac == "s1" label_s1
if $code_pac == "s2" label_s2
skip:
return


label_a1:
T_DISCONNECT.REQ eventdown address $target_address

S_U_ABORT.IND eventup
return

label_c1:
unbuffer quality_length sizeof(quality_length) demand_length sizeof(demand_length) data_buffer sizeof(data_buffer)-sizeof(quality_length)-sizeof(demand_length) data_buffer

unbuffer quality_buffer $quality_length demand_buffer $demand_length data_buffer

unbuffer markers_value sizeof(markers_value) demand_buffer
; 1 -> 0; 2 -> 3; 3 -> 2; 4 -> 1

set ($markers_value == 4) + 2 * ($markers_value == 3) + 3 * ($markers_value == 2) markers_state

S_CONNECT.IND eventup address $target_address quality $quality_buffer demand $demand_buffer
return


label_c2:
unbuffer quality_length sizeof(quality_length) data_buffer sizeof(data_buffer)-sizeof(quality_length) data_buffer

unbuffer quality_buffer $quality_length data_buffer
set "CIIENT" status
S_CONNECT.CONF eventup quality $quality_buffer
return


label_d1:
unbuffer need_protection sizeof(need_protection) major_sync_number sizeof(major_sync_number) quality_buffer

if $need_protection label_d1_protection

data_queue queuevalue $data_buffer
return

label_d1_protection:
unbuffer data_crc sizeof(data_crc) data_buffer sizeof(data_buffer)-sizeof(data_crc) data_buffer

crc data_crc2 $data_buffer

if $data_crc != $data_crc2 skip

data_queue queuevalue $data_buffer
return


label_e1:
unbuffer need_protection sizeof(need_protection) major_sync_number sizeof(major_sync_number) quality_buffer

if $need_protection label_e1_protection

S_EXPEDITED_DATA.IND eventup userdata $data_buffer
return

label_e1_protection:
unbuffer data_crc sizeof(data_crc) data_buffer sizeof(data_buffer)-sizeof(data_crc) data_buffer

crc data_crc2 $data_buffer

if $data_crc != $data_crc2 skip

S_EXPEDITED_DATA.IND eventup userdata $data_buffer
return


label_g1:
unbuffer token_value sizeof(token_value) data_buffer

S_GIVE_TOKENS.IND eventup token $token_value

set ($markers_state | $token_value) markers_state
return

label_m1:
S_SYNC_MAJOR.IND eventup
return


label_m2:
if qcount(data_queue) == 0 label_m2_end

S_DATA.IND eventup userdata (dequeue(data_queue))

goto label_m2

label_m2_end:
S_SYNC_MAJOR.CONF eventup
return


label_p1:
unbuffer token_value sizeof(token_value) data_buffer

S_PLEASE_TOKENS.IND eventup token $token_value
return

label_r1:
S_RELEASE.IND eventup
return

label_r2:
if qcount(data_queue) == 0 label_r2_end

S_DATA.IND eventup userdata (dequeue(data_queue))

goto label_r2

label_r2_end:
T_DISCONNECT.REQ eventdown address $target_address

S_RELEASE.CONF eventup
return


label_s1:
unbuffer token_value sizeof(token_value) data_buffer

S_RESYNCHRONIZE.IND eventup token $token_value
return


label_s2:
unbuffer token_value sizeof(token_value) data_buffer

S_RESYNCHRONIZE.CONF eventup token $token_value

; 1 -> 1; 2 -> 2; 3 -> 3; 4 -> 0
set ($token_value == 1) + 2 * ($token_value == 2) + 3 * ($token_value == 3) markers_state
return
```

## T_DISCONNECT.IND
```
;параметры:  нет
if ($status == "CLIENT") || ($status == "SERVER") reconnect
return

reconnect:
T_CONNECT.REQ eventdown address $target_address
```

# Транспортный уровень

## T_INIT.REQ
```
declare string status
set "IDLE" status
;адрес другой стороны
declare integer target_address

declare integer write_index
;ожидаемый номер пакета при N_DATA.IND
declare integer read_index
; подтверждённый номер пакета
declare integer confirmed_index
;номер пакета в пакете при N_DATA.IND
declare integer packet_index
set 0 write_index
set 0 read_index
set 0 confirmed_index

declare integer code_pac

;отправляемый буфер в N_DATA.REQ при T_DATA.REQ
declare buffer pac
;отправляемый буфер в T_DATA.IND при N_DATA.IND
declare buffer data

declare integer server_disconnect_timer
set 0 server_disconnect_timer
declare integer reconnect_timer
set 0 reconnect_timer
declare integer repeat_timer
set 0 repeat_timer
```

## DELAY_DISCONNECT
```
;параметры:  нет
set "IDLE" status
T_DISCONNECT.IND eventup
```

## DISCONNECT_BEFORE_RECONNECT
```
; параметры: нет
N_DISCONNECT.REQ eventdown address $target_address
reconnect_timer timer 4 RECONNECT
if $status == "TRY_RECONNECT" skip
set "IDLE" status
return
skip:
```

## N_CONNECT.CONF
```
;параметры:  address (число)
if $status == "TRY_RECONNECT" skip
;status == WAIT_CONF
set "CLIENT" status
T_CONNECT.CONF eventup address $address
untimer $reconnect_timer
return
skip:
untimer $reconnect_timer
set "CLIENT" status
```

## N_CONNECT.IND
```
;параметры:  address (число)
if $status == "WAIT_FOR_RECONNECT" resp
set "WAIT_RESP" status
set $address target_address
T_CONNECT.IND eventup address $address
return
resp:
set "SERVER" status
untimer $server_disconnect_timer
N_CONNECT.RESP eventdown address $target_address
return
```

## N_DATA.IND
```
;параметры:   userdata (буфер)
if $status == "ASK_TO_DISCONNECT" skip
; too small
if sizeof(userdata) < sizeof(packet_index)+sizeof(code_pac) skip
unbuffer packet_index sizeof(packet_index) code_pac sizeof(code_pac) data sizeof(userdata)-sizeof(packet_index)-sizeof(code_pac) userdata
if $code_pac == 1 confirm
; unexpected package
if $read_index < $packet_index skip
; confirm
$packet_index sizeof(packet_index) 1 sizeof(code_pac) sizeof(read_index)+sizeof(code_pac) buffer pac
N_DATA.REQ eventdown userdata $pac
; too old
if $read_index > $packet_index skip
if ($status == "CLIENT") && ($code_pac == 2) stop
if $code_pac == 2 skip
set $packet_index+1 read_index
T_DATA.IND eventup userdata $data
return
confirm:
if $confirmed_index > $packet_index skip
set $packet_index+1 confirmed_index
return
stop:
set "IDLE" status
N_DISCONNECT.REQ eventdown
T_DISCONNECT.IND eventup
return
skip:
```

## N_DISCONNECT.IND
```
;параметры:  нет
if $status == "IDLE" skip
if $status == "WAIT_CONF" skip
if $status == "WAIT_RESP" reconnect
if $status == "CLIENT" reconnect
if $status == "SERVER" server_disconnect
if $status == "ASK_TO_DISCONNECT" stop_repeat_stop
if $status == "TRY_RECONNECT" skip
if $status == "WAIT_FOR_RECONNECT" skip
return
stop_repeat_stop:
set "IDLE" status
untimer $repeat_timer
return
server_disconnect:
set "WAIT_FOR_RECONNECT" status
server_disconnect_timer timer 51 DELAY_DISCONNECT
return
reconnect:
set "TRY_RECONNECT" status
N_CONNECT.REQ eventdown address $target_address
reconnect_timer timer 41 DISCONNECT_BEFORE_RECONNECT
return
skip:
set "IDLE" status
```

## RECONNECT
```
; параметры: нет
N_CONNECT.REQ eventdown address $target_address
reconnect_timer timer 41 DISCONNECT_BEFORE_RECONNECT
if $status == "TRY_RECONNECT" skip
set "WAIT_CONF" status
skip:
```

## SEND_PACKAGE
```
;параметры: cur_pac(buffer), cur_num(integer), max_retry(integer)
if ($cur_num < $confirmed_index) || ($max_retry == 0) skip
N_DATA.REQ eventdown userdata $cur_pac
repeat_timer timer 51 cur_pac $cur_pac cur_num $cur_num max_retry $max_retry-1 SEND_PACKAGE
skip:
```

## T_CONNECT.REQ
```
;параметры:  address (число)
if $status == "ASK_TO_DISCONNECT" refuse_to_connect
set "WAIT_CONF" status
set $address target_address
N_CONNECT.REQ eventdown address $address
reconnect_timer timer 41 DISCONNECT_BEFORE_RECONNECT
return
refuse_to_connect:
T_DISCONNECT.IND eventup
return
```

## T_CONNECT.RESP
```
;параметры:  address (число)
set "SERVER" status
set $address target_address
N_CONNECT.RESP eventdown address $address
```

## T_DATA.REQ
```
;параметры:   userdata (буфер)
$write_index sizeof(write_index) 0 sizeof(code_pac) $userdata sizeof(userdata) sizeof(write_index)+sizeof(code_pac)+sizeof(userdata) buffer pac
repeat_timer timer 0 cur_pac $pac cur_num $write_index max_retry 15 SEND_PACKAGE
set $write_index+1 write_index
```

## T_DISCONNECT.REQ
```
;параметры:  address (число)
if $status == "WAIT_FOR_RECONNECT" skip
if $status == "SERVER" repeat_stop
set "IDLE" status
N_DISCONNECT.REQ eventdown address $address
return
repeat_stop:
$write_index sizeof(write_index) 2 sizeof(code_pac) sizeof(write_index)+sizeof(code_pac) buffer pac
set "ASK_TO_DISCONNECT" status
repeat_timer timer 0 cur_pac $pac cur_num $write_index max_retry 15 SEND_PACKAGE
;set $write_index+1 write_index
return
skip:
set "IDLE" status
```
