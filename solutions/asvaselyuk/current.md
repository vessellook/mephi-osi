# Общее

Синтаксис STX1.

Год создания 2024.

# Транспортный уровень

## ФОРМАТ СООБЩЕНИЙ

Подтверждение: <контрольная сумма><тип 1><номер>
Завершение от сервера клиенту: <контрольная сумма><тип 2><номер>
Данные: <контрольная сумма><тип 3><номер><данные>

## ПЕРЕХОДЫ СОСТОЯНИЯ 

формат: <исходное состояние> <конечное состояние> <полученное событие> -> <действия>

0 - ожидание новой T сессии, исходное состояние. N соединения нет
0 1 N_CONNECT.IND -> eventup T_CONNECT.IND
0 2 T_CONNECT.REQ -> generatedown N_CONNECT.REQ

1 - огранизация входящего T соединения
1 3 T_CONNECT.RESP -> generatedown N_CONNECT.RESP
1 0 T_DISCONNECT.REQ -> generatedown N_DISCONNECT.REQ

2 - организация исходящего T соединения
2 4 N_CONNECT.CONF -> eventup T_CONNECT.CONF
2 0 N_DISCONNECT.IND -> eventup T_DISCONNECT.IND

3 - готовность передачи данных по входящему T соединению
3 3 T_DATA.REQ -> generatedown N_DATA.REQ
3 3 N_DATA.IND DATA -> eventup T_DATA.IND, generatedown N_DATA.REQ ACK
3 3 N_DATA.IND ACK -> (do nothing)
сервер никогда не посылает N_DISCONNECT.REQ,  но уведомляет клиента о намерении через сообщение "STOP"
3 5 T_DISCONNECT.REQ -> settimer T_REPEAT_STOP 0
3 7 N_DISCONNECT.IND -> settimer T_SERVER_DISCONNECT $const_MAX_TRANSFER_DELAY*2+1

4 - готовность передачи данных по исходящему T соединению
4 4 T_DATA.REQ -> generatedown N_DATA.REQ
4 4 N_DATA.IND DATA -> eventup T_DATA.IND, generatedown N_DATA.REQ ACK
4 4 N_DATA.IND ACK -> (do nothing)
4 0 N_DATA.IND STOP -> generatedown N_DISCONNECT.REQ, eventup T_DISCONNECT.IND
4 0 T_DISCONNECT.REQ -> generatedown N_DISCONNECT.REQ
сервер не посылает N_DISCONNECT.REQ, так что это случайный разрыв, клиент переподключается
4 6 N_DISCONNECT.IND -> generatedown N_CONNECT.REQ

5 - ожидание завершения соединения со стороны клиента
тут приходится терять пакет
5 5 N_DATA.IND DATA -> (skip)
5 5 N_DATA.IND ACK -> (skip)
тут приходится разрывать T соединение, пока не завершится N соединение
5 5 T_CONNECT.REQ -> eventup T_DISCONNECT.IND
5 0 N_DISCONNECT.IND -> untimer  REPEAT_STOP
5 5 T_REPEAT_STOP -> generatedown N_DATA.REQ "STOP", settimer T_REPEAT_STOP $const_MAX_TRANSFER_DELAY*2+1

6 - ожидание подтверждения переподключения
6 4 N_CONNECT.CONF -> (do nothing)
6 0 N_DISCONNECT.IND -> (do nothing)
тут приходится терять пакет (ещё можно в очередь поместить)
6 6 T_DATA.REQ -> (skip)
6 0 T_DISCONNECT.REQ -> N_DISCONNECT.REQ

7 - ожидание переподключения клиента
7 0 T_DISCONNECT.REQ -> (skip)
7 0 T_SERVER_DISCONNECT -> eventup T_DISCONNECT.IND
7 3 N_CONNECT.IND -> generatedown N_CONNECT.RESP, untimer server_disconnect_timer
тут приходится терять пакет (ещё его можно в очередь поместить)
7 7 T_DATA.REQ -> (skip)

## T_INIT.REQ
```
connstate declare string
set "0" connstate
;адрес другой стороны
addr declare integer

;номер отправляемого пакета при T_DATA.REQ
num_req declare integer
;ожидаемый номер пакета при N_DATA.IND
num_ind declare integer
; подтверждённый номер пакета
num_ack declare integer
;номер пакета в пакете при N_DATA.IND
num_pac declare integer
set 0 num_req
set 0 num_ind
set 0 num_ack

; код сообщения
; 0 - обычное сообщение
; 1 - подтверждение сообщения
; 2 - сигнал от сервера о завершении соединения
code_pac declare integer

const_MAX_TRANSFER_DELAY declare integer
set 20 const_MAX_TRANSFER_DELAY

;вычисленная контрольная сумма пакета при T_DATA.REQ и N_DATA.IND
crc_ctrl declare integer
;пришедшая контрольная сумма пакета при N_DATA.IND
crc_pac declare integer

;контрольный буфер при T_DATA.REQ и N_DATA.IND
ctrlbuf declare buffer
;отправляемый буфер в N_DATA.REQ при T_DATA.REQ
pac declare buffer
;отправляемый буфер в T_DATA.IND при N_DATA.IND
data declare buffer

server_disconnect_timer declare integer
set 0 server_disconnect_timer 
repeat_timer declare integer
set 0 repeat_timer
```

## N_CONNECT.CONF
```
;параметры:  address (число)
skip if $connstate == "6"
;connstate == 2
out CurrentSystemName() + " " + $connstate + " 4 N_CONNECT.CONF -> eventup T_CONNECT.CONF"
set "4" connstate
eventup T_CONNECT.CONF address $address
return
skip:
out CurrentSystemName() + " " + $connstate + " 4 N_CONNECT.CONF -> (do nothing)"
set "4" connstate
```

## N_CONNECT.IND
```
;параметры:  address (число)
resp if $connstate == "7"
; connstate == 0
out CurrentSystemName() + " " + $connstate + " 1 N_CONNECT.IND -> eventup T_CONNECT.IND"
set "1" connstate
set $address addr
eventup T_CONNECT.IND address $address
return
resp:
out CurrentSystemName() + " " + $connstate + " 3 N_CONNECT.IND -> generatedown N_CONNECT.RESP, untimer server_disconnect_timer"
set "3" connstate
untimer $server_disconnect_timer
generatedown N_CONNECT.RESP address $addr
return
```

## N_DATA.IND
```
;параметры:   userdata (буфер)
skip if $connstate == "5"
; пакет слишком мал
skip_changed if sizeof(userdata) < sizeof(crc_pac)+sizeof(num_pac)+sizeof(code_pac)
unbuffer userdata crc_pac sizeof(crc_pac) ctrlbuf sizeof(userdata)-sizeof(crc_pac)
crc_ctrl varcrc $ctrlbuf
; пакет искажён
skip_changed if $crc_ctrl != $crc_pac
unbuffer ctrlbuf num_pac sizeof(num_pac) code_pac sizeof(code_pac) data sizeof(ctrlbuf)-sizeof(num_pac)-sizeof(code_pac)
ack_ind if $code_pac == 1
; пакет слишком новый
skip_future if $num_ind < $num_pac
; надо послать подтверждение
sizeof(num_ind)+sizeof(code_pac) $num_pac sizeof(num_pac) 1 sizeof(code_pac) pack ctrlbuf
crc_ctrl varcrc $ctrlbuf
sizeof(crc_ctrl)+sizeof(ctrlbuf) $crc_ctrl sizeof(crc_ctrl) $ctrlbuf sizeof(ctrlbuf) pack pac
generatedown N_DATA.REQ userdata $pac
; пакет старый
skip_old if $num_ind > $num_pac
set $num_pac+1 num_ind
stop if ($connstate == "4") && ($code_pac == 2)
; connstate == "3" || (connstate == "4" && $code_pac != 2)
out CurrentSystemName() + " " + $connstate + " " + $connstate + " N_DATA.IND -> T_DATA.IND, N_DATA.REQ ack"
out "$num_pac="
out $num_pac
eventup T_DATA.IND userdata $data
return
ack_ind:
ack_skip if $num_ack > $num_pac
out CurrentSystemName() + " " + $connstate + " " + $connstate + " N_DATA.IND ACK -> set $num_pac+1 num_ack"
out "$num_pac="
out $num_pac
out "$num_ack="
out $num_ack
set $num_pac+1 num_ack
return
ack_skip:
out CurrentSystemName() + " " + $connstate + " " + $connstate + " N_DATA.IND ACK old -> (do nothing)"
out "$num_pac="
out $num_pac
out "$num_ack="
out $num_ack
return
stop:
out CurrentSystemName() + " " + $connstate + " 0 N_DATA.IND STOP -> generatedown N_DISCONNECT.REQ, eventup T_DISCONNECT.IND"
set "0" connstate
generatedown N_DISCONNECT.REQ
eventup T_DISCONNECT.IND
return
skip_changed:
out CurrentSystemName() + " " + $connstate + " " + $connstate + " N_DATA.IND -> (skip changed)"
return
skip_old:
out CurrentSystemName() + " " + $connstate + " " + $connstate + " N_DATA.IND -> generatedown N_DATA.REQ ACK old"
return
skip_future:
out CurrentSystemName() + " " + $connstate + " " + $connstate + " N_DATA.IND -> (skip future)"
return
skip:
out CurrentSystemName() + " " + $connstate + " " + $connstate + " N_DATA.IND -> (skip)"
```

## N_DISCONNECT.IND
```
;параметры:  нет
reconnect if $connstate == "4"
server_disconnect if $connstate == "3"
stop_repeat_stop if $connstate == "5"
skip if $connstate == "6"
; constate == "2"
out CurrentSystemName() + " " + $connstate + " 0 N_DISCONNECT.IND -> eventup T_DISCONNECT.IND"
set "0" connstate
eventup T_DISCONNECT.IND
return
stop_repeat_stop:
out CurrentSystemName() + " " + $connstate + " 0 N_DISCONNECT.IND -> untimer T_REPEAT"
set "0" connstate
untimer $repeat_timer
return
server_disconnect:
out CurrentSystemName() + " " + $connstate + " 7 N_DISCONNECT.IND -> settimer T_SERVER_DISCONNECT"
set "7" connstate
T_SERVER_DISCONNECT server_disconnect_timer ($const_MAX_TRANSFER_DELAY*2+1) settimer
return
reconnect:
out CurrentSystemName() + " " + $connstate + " 2 N_DISCONNECT.IND -> generatedown N_CONNECT.REQ"
set "6" connstate
generatedown N_CONNECT.REQ address $addr
return
skip:
out CurrentSystemName() + " " + $connstate + " 0 N_DISCONNECT.IND -> (do nothing)"
set "0" connstate
```

## T_CONNECT.REQ
```
;параметры:  address (число)
reject if $connstate == "5"
; connstate == 0
out CurrentSystemName() + " " + $connstate + " 2 T_CONNECT.REQ -> N_CONNECT.REQ"
set "2" connstate
set $address addr
generatedown N_CONNECT.REQ address $address
return
reject:
out CurrentSystemName() + " " + $connstate + " 5 T_CONNECT.REQ -> T_DISCONNECT.IND"
eventup T_DISCONNECT.IND
return
```

## T_CONNECT.RESP
```
;параметры:  address (число)
; connstate == 1
out CurrentSystemName() + " " + $connstate + " 3 T_CONNECT.RESP -> N_CONNECT.RESP"
set "3" connstate
set $address addr
generatedown N_CONNECT.RESP address $address
```

## T_DATA.REQ
```
;параметры:   userdata (буфер)
;skip if ($connstate == "7") || ($connstate == "6")
; $connstate == "3" || $connstate == "4" || $connstate == "7" || $constate == "6"
out CurrentSystemName() + " " + $connstate + " " + $connstate + " T_DATA.REQ -> settimer T_REPEAT DATA 0"
sizeof(num_req)+sizeof(code_pac)+sizeof(userdata) $num_req sizeof(num_req) 0 sizeof(code_pac) $userdata sizeof(userdata) pack ctrlbuf
crc_ctrl varcrc $ctrlbuf
sizeof(crc_ctrl)+sizeof(ctrlbuf) $crc_ctrl sizeof(crc_ctrl) $ctrlbuf sizeof(ctrlbuf) pack pac
T_REPEAT repeat_timer 0 settimer cur_pac $pac cur_num $num_req
set $num_req+1 num_req
return
;skip:
;out CurrentSystemName() + " " + $connstate + " " + $connstate + " T_DATA.REQ -> (skip)"
```

## T_DISCONNECT.REQ
```
;параметры:  address (число)
skip if $connstate == "7"
repeat_stop if $connstate == "3"
; $connstate == "1" || $constate == "4"||$constate == "6"
out CurrentSystemName() + " " + $connstate + " 0 T_DISCONNECT.REQ -> N_DISCONNECT.REQ"
set "0" connstate
generatedown N_DISCONNECT.REQ address $address
return
repeat_stop:
out CurrentSystemName() + " " + $connstate + " 5 T_DISCONNECT.REQ -> settimer T_REPEAT STOP 0"
sizeof(num_req)+sizeof(code_pac) $num_req sizeof(num_req) 2 sizeof(code_pac) pack ctrlbuf
crc_ctrl varcrc $ctrlbuf
sizeof(crc_ctrl)+sizeof(ctrlbuf) $crc_ctrl sizeof(crc_ctrl) $ctrlbuf sizeof(ctrlbuf) pack pac
set "5" connstate
T_REPEAT repeat_timer 0 settimer cur_pac $pac cur_num $num_req
set $num_req+1 num_req
return
skip:
set "0" connstate
out CurrentSystemName() + " " + $connstate + " 0 T_DISCONNECT.REQ -> (skip)"
```

## T_REPEAT
```
;параметры: cur_pac(buffer), cur_num(integer)
skip if $cur_num < $num_ack
out CurrentSystemName() + " " + $connstate + " " + $connstate + " T_REPEAT -> generatedown N_DATA.REQ, settimer T_REPEAT 41"
out "$cur_num="
out $cur_num
out "$num_ack="
out $num_ack
generatedown N_DATA.REQ userdata $cur_pac
T_REPEAT repeat_timer ($const_MAX_TRANSFER_DELAY*2+1) settimer cur_pac $cur_pac cur_num $cur_num
return
skip:
out CurrentSystemName() + " " + $connstate + " " + $connstate + " T_REPEAT -> (skip)"
out "$cur_num="
out $cur_num
out "$num_ack="
out $num_ack
```

## T_SERVER_DISCONNECT
```
;параметры:  нет
; connstate == 7
out CurrentSystemName() + " " + $connstate + " 0 T_SERVER_DISCONNECT -> eventup T_DISCONNECT.IND"
setto "0" connstate
eventup T_DISCONNECT.IND
```