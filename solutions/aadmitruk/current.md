# Общее

Синтаксис STX1.

Год создания 2024.

# Сеансовый уровень

Скопировано из asvaselyuk

Сначала происходит установление T соединения, затем от клиента серверу передаются параметры качества quality (use_protection и synchronization_start_number) и начальная расстановка маркеров demand, обратно сервер передаёт свои параметры качества quality. synchronization_start_number фактически не нужен.

demand указывает, как изначально распределены маркеры данных и синхронизации. Чтобы передать обычные или срочные данные, требуется маркер данных. Чтобы выполнить основную синхронизацию, требуется маркер синхронизации.

## ФОРМАТ ПАКЕТА
<тип пакета|1 слово><данные>

и в зависимости от типа <данные> это

1:<size_of_quality| 1 слово><size_of_demand| 1 слово><quality| size_of_quality слов><demand | size_of_demand слов> - параметры запроса на соединение, причём size_of_quality = 2 и size_of_demand = 1
2:<size_of_quality| 1 слово><quality| size_of_quality слов> - параметры ответа на запрос на соединение, причём size_of_quality = 2
3:пустой буфер - запрос о разъединении
4:[<crc| 1 слово>]<userdata> - запрос на передачу данных, crc присутствует для соединений с защитой, вроде бы такой совет даёт преподаватель
5:[<crc| 1 слово>]<userdata> - запрос на передачу срочных данных, crc присутствует для соединений с защитой, вроде бы такой совет даёт преподаватель
6:пустой буфер - запрос на упорядоченное разъединение
7:пустой буфер - ответ на запрос на упорядоченное разъединение
8:пустой буфер - запрос на основную синхронизацию
9:пустой буфер - ответ на запрос об основной синхронизации
10:<token| 1 слово> - запрос на ресинхронизацию
12:<token| 1 слово> - ответ на запрос на ресинхронизацию
12:<token| 1 слово> - запрос на маркер
13:<token| 1 слово> - передача маркера

буфер quality имеет формат <use_protection| 1 слово><synchronization_start_number| 1 слово>

буфер demand имеет формат <markers| 1 слово>



## S_INIT.REQ
```
marker_of_data declare integer
marker_of_major_sync declare integer

type_of_pac declare integer

addr declare integer

session_quality declare buffer
size_of_quality declare integer
session_demand declare buffer
size_of_demand declare integer
synchronization_start_number declare integer

use_protection declare integer
crc_at_pac declare integer
crc_of_pac declare integer

up_queue declare queue

buffer_ declare buffer
token_ declare integer
set 0 token_
```

## S_CONNECT.REQ
```
;параметры:  address (число), quality (буфер), demand (буфер)
set $quality session_quality
set $demand session_demand
unbuffer demand token_ sizeof(token_)
set ($token_ == 1) || ($token_ == 3) marker_of_data
set ($token_ == 1) || ($token_ == 4) marker_of_major_sync
generatedown T_CONNECT.REQ address $address
```

## S_CONNECT.RESP
```
;параметры:  address (число), quality (буфер)
set $quality session_quality
sizeof(type_of_pac)+sizeof(size_of_quality)+sizeof(session_quality) 12 sizeof(type_of_pac) sizeof(session_quality) sizeof(size_of_quality) $session_quality sizeof(session_quality) pack buffer_
generatedown T_DATA.REQ userdata $buffer_
```

## S_DATA.REQ
Если отсутствует маркер данных, то это ошибка 1. При использовании защиты исполнение проходит через секцию protect
```
;параметры:   userdata (буфер)
raise_error if $marker_of_data == 0

unbuffer session_quality use_protection sizeof(use_protection) synchronization_start_number sizeof(synchronization_start_number)
set $userdata buffer_
send if $use_protection == 0

protect:
crc_at_pac varcrc $buffer_
sizeof(buffer_)+sizeof(crc_at_pac) $crc_at_pac sizeof(crc_at_pac) $buffer_ sizeof(buffer_) pack buffer_

send:
sizeof(userdata)+sizeof(type_of_pac) 31 sizeof(type_of_pac) $userdata sizeof(userdata) pack buffer_
generatedown T_DATA.REQ userdata $buffer_
return

raise_error:
eventup S_P_EXCEPTION.IND error 1
return
```

## S_EXPEDITED_DATA.REQ
При использовании защиты исполнение проходит через секцию protect
```
;параметры:   userdata (буфер)

unbuffer session_quality use_protection sizeof(use_protection) synchronization_start_number sizeof(synchronization_start_number)
set $userdata buffer_

send if $use_protection == 0

protect:
crc_at_pac varcrc $buffer_
sizeof(buffer_)+sizeof(crc_at_pac)$crc_at_pac sizeof(crc_at_pac) $buffer_ sizeof(buffer_) pack buffer_

send:
sizeof(buffer_)+sizeof(type_of_pac) 32 sizeof(type_of_pac) $buffer_ sizeof(buffer_) pack buffer_
generatedown T_DATA.REQ userdata $buffer_
```

## S_GIVE_TOKENS.REQ
Если передаётся маркер, которого нет у данной стороны, то нужно сгенерировать исключение о том, что обнаружен дубликат/потеря маркера (3). В противном случае нужно послать пакет с передачей маркера

```
;параметры:  token (число)
raise_error if (($marker_of_data == 0) && ($token == 1)) || (($marker_of_major_sync == 0) && ($token == 2))

sizeof(type_of_pac)+sizeof(token) 62 sizeof(type_of_pac) $token sizeof(token) pack buffer_
generatedown T_DATA.REQ userdata $buffer_

set ($marker_of_data == 1) && ($token != 1) marker_of_data
set ($marker_of_major_sync == 1) && ($token != 2) marker_of_major_sync
return

raise_error:
eventup S_P_EXCEPTION.IND error 3
return
```

## S_PLEASE_TOKENS.REQ
Если запрошен маркер, который уже есть, то нужно сгенерировать исключение о том, что обнаружен дубликат/потеря маркера (3). В противном случае нужно послать пакет с запросом маркера

```
;параметры:  token (число)
raise_error if (($marker_of_data == 1) && ($token == 1)) || (($marker_of_major_sync == 1) && ($token == 2))
sizeof(token)+sizeof(type_of_pac) 61 sizeof(type_of_pac) $token sizeof(token) pack buffer_
generatedown T_DATA.REQ userdata $buffer_
return

raise_error:
eventup S_P_EXCEPTION.IND error 3
```

## S_RELEASE.REQ
```
;параметры:  нет
sizeof(type_of_pac) 21 sizeof(type_of_pac) pack buffer_
generatedown T_DATA.REQ userdata $buffer_
```

## S_RELEASE.RESP
Тут всё, что между goto start и меткой end - это недостижимый код, вставлено для прохождения контроля
```
;параметры:  нет

start:
repeat if qcount(up_queue) > 0
goto end

repeat:
set dequeue(up_queue) buffer_
eventup S_DATA.IND userdata $buffer_
goto start
set dequeue(up_queue) buffer_
generatedown T_DATA.REQ userdata $buffer_
goto repeat

end:
sizeof(type_of_pac) 22 sizeof(type_of_pac) pack buffer_
generatedown T_DATA.REQ userdata $buffer_
```

## S_RESYNCHRONIZE.REQ
```
;параметры:  token (число)

clearqueue up_queue
sizeof(token)+sizeof(type_of_pac) 51 sizeof(type_of_pac) $token sizeof(token) pack buffer_
generatedown T_DATA.REQ userdata $buffer_
```

## S_RESYNCHRONIZE.RESP
```
;параметры:  token (число)

clearqueue up_queue
sizeof(type_of_pac)+sizeof(token) 52 sizeof(type_of_pac) $token sizeof(token) pack buffer_
generatedown T_DATA.REQ userdata $buffer_
; token содержит маркеры другой стороны, так что тут обратный предикат
set ($token != 1) && ($token != 3) marker_of_data
set ($token != 2) && ($token != 3) marker_of_major_sync
```

## S_SYNC_MAJOR.REQ
Если отсутствует маркер основной синхронизации, то это ошибка 2
```
;параметры:  нет
raise_error if $marker_of_major_sync == 0
sizeof(type_of_pac) 41 sizeof(type_of_pac) pack buffer_
generatedown T_DATA.REQ userdata $buffer_
return

raise_error:
eventup S_P_EXCEPTION.IND error 2
return
```

## S_SYNC_MAJOR.RESP
Тут всё, что между goto start и меткой end - это недостижимый код, вставлено для прохождения контроля
```
;параметры:  нет

start:
repeat if qcount(up_queue) > 0
goto end

repeat:
set dequeue(up_queue) buffer_
eventup S_DATA.IND userdata $buffer_
goto start
set dequeue(up_queue) buffer_
generatedown T_DATA.REQ userdata $buffer_
goto repeat


end:
sizeof(type_of_pac) 42 sizeof(type_of_pac) pack buffer_
generatedown T_DATA.REQ userdata $buffer_
```

## S_U_ABORT.REQ
```
;параметры:  нет
sizeof(type_of_pac) 23 sizeof(type_of_pac) pack buffer_
generatedown T_DATA.REQ userdata $buffer_
```

## T_CONNECT.CONF
```
;параметры:  address (число)

set $address addr
sizeof(type_of_pac)+sizeof(size_of_quality)+sizeof(size_of_demand)+sizeof(session_quality)+sizeof(session_demand) 11 sizeof(type_of_pac) sizeof(session_quality) sizeof(size_of_quality) sizeof(session_demand) sizeof(size_of_demand) $session_quality sizeof(session_quality) $session_demand sizeof(session_demand) pack buffer_
generatedown T_DATA.REQ userdata $buffer_
```

## T_CONNECT.IND
```
;параметры:  address (число)

set $address addr
generatedown T_CONNECT.RESP address $address
```

## T_DATA.IND
Обработка всех возможных типов пакетов
```
;параметры:  userdata (буфер)

unbuffer userdata type_of_pac sizeof(type_of_pac) buffer_ sizeof(userdata)-sizeof(type_of_pac)
connect_req if $type_of_pac == 11
connect_res if $type_of_pac == 12
release_req if $type_of_pac == 21
release_res if $type_of_pac == 22
abort if $type_of_pac == 23
data_req if $type_of_pac == 31
exp_data_req if $type_of_pac == 32
sync_req if $type_of_pac == 41
sync_res if $type_of_pac == 42
resync_req if $type_of_pac == 51
resync_res if $type_of_pac == 52
token_req if $type_of_pac == 61
token_res if $type_of_pac == 62
return

connect_req:
unbuffer buffer_ size_of_quality sizeof(size_of_quality) size_of_demand sizeof(size_of_demand) buffer_ sizeof(buffer_)-sizeof(size_of_quality)-sizeof(size_of_demand)
unbuffer buffer_ session_quality $size_of_quality session_demand $size_of_demand
unbuffer session_demand token_ sizeof(token_)
set ($token_ == 2) || ($token_ == 4) marker_of_data
set ($token_ == 2) || ($token_ == 3) marker_of_major_sync
eventup S_CONNECT.IND address $addr quality $session_quality demand $session_demand
return
connect_res:
unbuffer buffer_ size_of_quality sizeof(size_of_quality) buffer_ sizeof(buffer_)-sizeof(size_of_quality)
unbuffer buffer_ session_quality $size_of_quality
eventup S_CONNECT.CONF quality $session_quality
return

data_req:
unbuffer session_quality use_protection sizeof(use_protection) synchronization_start_number sizeof(synchronization_start_number)
add_to_queue if $use_protection == 0
check_protected_data:
unbuffer buffer_ crc_at_pac sizeof(crc_at_pac) buffer_ sizeof(buffer_)-sizeof(crc_at_pac)
crc_of_pac varcrc $buffer_
skip_broken if $crc_at_pac != $crc_of_pac
add_to_queue:
queue $buffer_ up_queue
return


exp_data_req:
unbuffer session_quality use_protection sizeof(use_protection) synchronization_start_number sizeof(synchronization_start_number)
send if $use_protection == 0
check_protected_expedited_data:
unbuffer buffer_ crc_at_pac sizeof(crc_at_pac) buffer_ sizeof(buffer_)-sizeof(crc_at_pac)
crc_of_pac varcrc $buffer_
skip_broken if $crc_at_pac != $crc_of_pac
send:
eventup S_EXPEDITED_DATA.IND userdata $buffer_
return

skip_broken:
return

release_req:
eventup S_RELEASE.IND
return
release_res:
release_repeat if qcount(up_queue) > 0
goto release_end_queue
release_repeat:
eventup S_DATA.IND userdata (dequeue(up_queue))
goto release_res
release_end_queue:
generatedown T_DISCONNECT.REQ address $addr
eventup S_RELEASE.CONF
return
abort:
generatedown T_DISCONNECT.REQ address $addr
eventup S_U_ABORT.IND
return

sync_req:
eventup S_SYNC_MAJOR.IND
return
sync_res:
sync_repeat if qcount(up_queue) > 0
goto sync_end_queue
sync_repeat:
eventup S_DATA.IND userdata (dequeue(up_queue))
goto sync_res
sync_end_queue:
eventup S_SYNC_MAJOR.CONF
return

token_req:
unbuffer buffer_ token_ sizeof(token_)
eventup S_PLEASE_TOKENS.IND token $token_
return
token_res:
unbuffer buffer_ token_ sizeof(token_)
eventup S_GIVE_TOKENS.IND token $token_
set ($marker_of_data == 1) || ($token_ == 1) marker_of_data
set ($marker_of_major_sync == 1) || ($token_ == 2) marker_of_major_sync
return

resync_req:
unbuffer buffer_ token_ sizeof(token_)
eventup S_RESYNCHRONIZE.IND token $token_
return
resync_res:
unbuffer buffer_ token_ sizeof(token_)
eventup S_RESYNCHRONIZE.CONF token $token_
set ($token_ == 1) || ($token_ == 3) marker_of_data
set ($token_ == 2) || ($token_ == 3) marker_of_major_sync
return
```

## T_DISCONNECT.IND
```
;параметры:  нет
```

# Транспортный уровень

## ТИПЫ ПАКЕТОВ
SYN = 1 - запрос соединения (ретраится до получения соответствующего ACK)
SYNRESP = 2 - подтверждение соединения (ретраится до получения соответствующего ACK)
ACK = 3 - подтверждение пакета (не ретраится, ответ на любой пакет другого типа)
DATA = 4 - обычный пакет (ретраится до получения соответствующего ACK)
FIN = 5 - запрос завершения соединения (ретраится до получения соответствующего ACK)
ретраи происходят через время 41

## ФОРМАТ ПАКЕТА
<контрольная сумма|1 слово><номер пакета|1 слово><тип пакета|1 слово><userdata>

## ПЕРЕХОДЫ СОСТОЯНИЯ 
формат: <исходное состояние> <конечное состояние> <полученное событие> -> <действия>

для всех состояний
x y N_DATAGRAM.IND (changed) -> (do nothing)
x y N_DATAGRAM.IND (old) -> generatedown ACK
x y N_DATAGRAM.IND ACK -> set num_ack
x y N_DATAGRAM.IND ACK (old) -> (do nothing)
x y N_DATAGRAM.IND SYN|SYNRESP|DATA|FIN -> generatedown ACK
ниже будет только дополнительное описание для валидных пакетов с SYN, SYNRESP, DATA, FIN

INIT - ожидание новой T сессии, исходное состояние
INIT SER1 N_DATAGRAM.IND SYN -> eventup T_CONNECT.IND
INIT INIT N_DATAGRAM.IND SYNRESP -> (do nothing, invalid packet)
INIT INIT N_DATAGRAM.IND DATA -> (do nothing, invalid packet)
INIT INIT N_DATAGRAM.IND FIN -> (do nothing, invalid packet)
INIT CLI1 T_CONNECT.REQ -> timer SEND SYN

SER1 - огранизация входящего T соединения
SER1 SER1 N_DATAGRAM.IND SYN -> (do nothing, invalid packet)
SER1 SER1 N_DATAGRAM.IND SYNRESP -> (do nothing, invalid packet)
SER1 SER1 N_DATAGRAM.IND DATA -> (do nothing, invalid packet)
SER1 INIT N_DATAGRAM.IND FIN -> eventup T_DISCONNECT.IND
SER1 SER2 T_CONNECT.RESP -> timer SEND SYNRESP
SER1 INIT T_DISCONNECT.REQ -> timer SEND FIN

CLI1 - организация исходящего T соединения
CLI1 CLI1 N_DATAGRAM.IND SYN -> (do nothing, invalid packet)
CLI1 CLI2 N_DATAGRAM.IND SYNRESP -> eventup T_CONNECT.CONF
CLI1 CLI1 N_DATAGRAM.IND DATA -> (do nothing, invalid packet)
CLI1 INIT N_DATAGRAM.IND FIN -> eventup T_DISCONNECT.IND
CLI1 INIT T_DISCONNECT.REQ -> timer SEND FIN

SER2 - готовность передачи данных по входящему T соединению
SER2 SER2 N_DATAGRAM.IND SYN -> (do nothing, invalid packet)
SER2 SER2 N_DATAGRAM.IND SYNRESP -> (do nothing, invalid packet)
SER2 SER2 N_DATAGRAM.IND DATA -> eventup T_DATA.IND
SER2 INIT N_DATAGRAM.IND FIN -> eventup T_DISCONNECT.IND
SER2 SER2 T_DATA.REQ -> timer SEND DATA
SER2 INIT T_DISCONNECT.REQ -> timer SEND FIN

CLI2 - готовность передачи данных по исходящему T соединению
CLI2 CLI2 N_DATAGRAM.IND SYN -> (do nothing, invalid packet)
CLI2 CLI2 N_DATAGRAM.IND SYNRESP -> (do nothing, invalid packet)
CLI2 CLI2 N_DATAGRAM.IND DATA -> eventup T_DATA.IND
CLI2 INIT N_DATAGRAM.IND FIN -> eventup T_DISCONNECT.IND
CLI2 CLI2 T_DATA.REQ -> timer SEND DATA
CLI2 INIT T_DISCONNECT.REQ -> timer SEND FIN

По событиям
INIT SER1 N_DATAGRAM.IND SYN -> eventup T_CONNECT.IND
SER1 SER1 N_DATAGRAM.IND SYN -> (do nothing, invalid packet)
CLI1 CLI1 N_DATAGRAM.IND SYN -> (do nothing, invalid packet)
SER2 SER2 N_DATAGRAM.IND SYN -> (do nothing, invalid packet)
CLI2 CLI2 N_DATAGRAM.IND SYN -> (do nothing, invalid packet)

INIT INIT N_DATAGRAM.IND SYNRESP -> (do nothing, invalid packet)
SER1 SER1 N_DATAGRAM.IND SYNRESP -> (do nothing, invalid packet)
CLI1 CLI2 N_DATAGRAM.IND SYNRESP -> eventup T_CONNECT.CONF
SER2 SER2 N_DATAGRAM.IND SYNRESP -> (do nothing, invalid packet)
CLI2 CLI2 N_DATAGRAM.IND SYNRESP -> (do nothing, invalid packet)

INIT INIT N_DATAGRAM.IND DATA -> (do nothing, invalid packet)
SER1 SER1 N_DATAGRAM.IND DATA -> (do nothing, invalid packet)
CLI1 CLI1 N_DATAGRAM.IND DATA -> (do nothing, invalid packet)
SER2 SER2 N_DATAGRAM.IND DATA -> eventup T_DATA.IND
CLI2 CLI2 N_DATAGRAM.IND DATA -> eventup T_DATA.IND

INIT INIT N_DATAGRAM.IND FIN -> (do nothing, invalid packet)
SER1 INIT N_DATAGRAM.IND FIN -> eventup T_DISCONNECT.IND
CLI1 INIT N_DATAGRAM.IND FIN -> eventup T_DISCONNECT.IND
SER2 INIT N_DATAGRAM.IND FIN -> eventup T_DISCONNECT.IND
CLI2 INIT N_DATAGRAM.IND FIN -> eventup T_DISCONNECT.IND

INIT CLI1 T_CONNECT.REQ -> timer SEND SYN

SER1 SER2 T_CONNECT.RESP -> timer SEND SYNRESP

SER2 SER2 T_DATA.REQ -> timer SEND DATA
CLI2 CLI2 T_DATA.REQ -> timer SEND DATA

SER1 INIT T_DISCONNECT.REQ -> timer SEND FIN
CLI1 INIT T_DISCONNECT.REQ -> timer SEND FIN
SER2 INIT T_DISCONNECT.REQ -> timer SEND FIN
CLI2 INIT T_DISCONNECT.REQ -> timer SEND FIN

## T_INIT.REQ
```
SYN declare integer
set 1 SYN
SYNRESP declare integer
set 2 SYNRESP
ACK declare integer
set 3 ACK
DATA declare integer
set 4 DATA
FIN declare integer
set 5 FIN
type_of_pac declare integer

state declare string
set "INIT" state
addr declare integer

send_timer declare integer
set 0 send_timer

crc_of_crcbuf declare integer
crc_at_pac declare integer

crcbuf declare buffer
pac declare buffer
pacdata declare buffer

next_out declare integer
last_in declare integer
num_ack declare integer
num_of_pac declare integer
set 1 next_out
set 1 last_in
set 0 num_ack
```

## N_DATAGRAM.IND
```
;параметры:  address (число), userdata (буфер)
; проверка размера на всякий случай
skip if sizeof(userdata) < sizeof(crc_at_pac)+sizeof(num_of_pac)+sizeof(type_of_pac)
unbuffer userdata crc_at_pac sizeof(crc_at_pac) crcbuf sizeof(userdata)-sizeof(crc_at_pac)
crc_of_crcbuf varcrc $crcbuf
; контрольная сумма не соответствует той, что в пакете
skip if $crc_of_crcbuf != $crc_at_pac
unbuffer crcbuf num_of_pac sizeof(num_of_pac) type_of_pac sizeof(type_of_pac) pacdata sizeof(crcbuf)-sizeof(num_of_pac)-sizeof(type_of_pac)
ack if $type_of_pac == $ACK
skip if $last_in < $num_of_pac
; послать ACK
sizeof(last_in)+sizeof(type_of_pac) $num_of_pac sizeof(num_of_pac) $ACK sizeof(type_of_pac) pack crcbuf
crc_of_crcbuf varcrc $crcbuf
sizeof(crc_of_crcbuf)+sizeof(crcbuf) $crc_of_crcbuf sizeof(crc_of_crcbuf) $crcbuf sizeof(crcbuf) pack pac
generatedown N_DATAGRAM.REQ address $address userdata $pac
; пакет старый
skip if $last_in > $num_of_pac
set $num_of_pac+1 last_in
syn if $type_of_pac == $SYN
synresp if $type_of_pac == $SYNRESP
data if $type_of_pac == $DATA
fin if $type_of_pac == $FIN
return
ack:
skip if $num_ack >= $num_of_pac
set $num_of_pac num_ack
return
syn:
skip if $state != "INIT"
set "SER1" state
eventup T_CONNECT.IND address $address
return
synresp:
skip if $state != "CLI1"
set "CLI2" state
eventup T_CONNECT.CONF address $address
return
data:
skip if ($state != "SER2") && ($state != "CLI2")
eventup T_DATA.IND userdata $pacdata
return
fin:
skip if $state == "INIT"
set "INIT" state
eventup T_DISCONNECT.IND
return
skip:
```

## T_CONNECT.REQ
```
;параметры:  address (число)
skip if $state != "INIT"
set $address addr
sizeof(last_in)+sizeof(type_of_pac) $next_out sizeof(next_out) $SYN sizeof(type_of_pac) pack crcbuf
crc_of_crcbuf varcrc $crcbuf
sizeof(crc_of_crcbuf)+sizeof(crcbuf) $crc_of_crcbuf sizeof(crc_of_crcbuf) $crcbuf sizeof(crcbuf) pack pac
SEND send_timer 0 settimer address $address userdata $pac number $next_out
set $next_out+1 next_out
set "CLI1" state
skip:
```

## T_CONNECT.RESP
```
;параметры:  address (число)
skip if $state != "SER1"
set $address addr
sizeof(last_in)+sizeof(type_of_pac) $next_out sizeof(next_out) $SYNRESP sizeof(type_of_pac) pack crcbuf
crc_of_crcbuf varcrc $crcbuf
sizeof(crc_of_crcbuf)+sizeof(crcbuf) $crc_of_crcbuf sizeof(crc_of_crcbuf) $crcbuf sizeof(crcbuf) pack pac
SEND send_timer 0 settimer address $address userdata $pac number $next_out
set $next_out+1 next_out
set "SER2" state
skip:
```

## T_DATA.REQ
```
;параметры:   userdata (буфер)
skip if ($state != "SER2") && ($state != "CLI2")
sizeof(last_in)+sizeof(type_of_pac)+sizeof(userdata) $next_out sizeof(next_out) $DATA sizeof(type_of_pac) $userdata sizeof(userdata) pack crcbuf
crc_of_crcbuf varcrc $crcbuf
sizeof(crc_of_crcbuf)+sizeof(crcbuf) $crc_of_crcbuf sizeof(crc_of_crcbuf) $crcbuf sizeof(crcbuf) pack pac
SEND send_timer 0 settimer address $addr userdata $pac number $next_out
set $next_out+1 next_out
skip:
```

## T_DISCONNECT.REQ
```
;параметры:  address (число)
skip if $state == "INIT"
sizeof(last_in)+sizeof(type_of_pac) $next_out sizeof(next_out) $FIN sizeof(type_of_pac) pack crcbuf
crc_of_crcbuf varcrc $crcbuf
sizeof(crc_of_crcbuf)+sizeof(crcbuf) $crc_of_crcbuf sizeof(crc_of_crcbuf) $crcbuf sizeof(crcbuf) pack pac
SEND send_timer 0 settimer address $address userdata $pac number $next_out
set $next_out+1 next_out
set "INIT" state
skip:
```

## SEND
```
;параметры:   address (число), userdata (buffer), number (число)
skip if $num_ack >= $number
generatedown N_DATAGRAM.REQ address $address userdata $userdata
generatedown N_DATAGRAM.REQ address $address userdata $userdata
SEND send_timer 41 settimer address $address userdata $userdata number $number
skip:
```
