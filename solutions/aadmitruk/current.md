# Общее

Синтаксис STX1.

Год создания 2024.

# Транспортный уровень

## ТИПЫ ПАКЕТОВ
SYN = 1 - запрос соединения (ретраится до получения соответствующего ACK)
SYNRESP = 2 - подтверждение соединения (ретраится до получения соответствующего ACK)
ACK = 3 - подтверждение пакета (не ретраится, ответ на любой пакет другого типа)
DATA = 4 - обычный пакет (ретраится до получения соответствующего ACK)
FIN = 5 - запрос завершения соединения (ретраится до получения соответствующего ACK)
ретраи происходят через время 41

## ФОРМАТ ПАКЕТА
<контрольная сумма|1 байт><номер пакета|1 байт><тип пакета|1 байт><userdata>

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
