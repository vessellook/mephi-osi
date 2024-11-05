# Общее

Синтаксис STX1.

Год создания 2024.

# Сетевой уровень

Скопировано из avramenko

## ФОРМАТ ПАКЕТА
<тип пакета|1 слово><данные>

и в зависимости от типа <данные> это

1:<quality_size| 1 слово><demand_size| 1 слово><quality| quality_size слов><demand | demand_size слов> - параметры запроса на соединение
2:<quality_size| 1 слово><quality| quality_size слов> - параметры ответа на запрос на соединение
3:пустой буфер - запрос о разъединении
4:[<crc| 1 слово>]<userdata> - запрос на передачу данных, crc присутствует для соединений с защитой, вроде бы такой совет даёт преподаватель
5:[<crc| 1 слово>]<userdata> - запрос на передачу срочных данных, crc присутствует для соединений с защитой, вроде бы такой совет даёт преподаватель
6:пустой буфер - запрос на упорядоченное разъединение
7:пустой буфер - ответ на запрос на упорядоченное разъединение
11:пустой буфер - запрос на главную синхронизацию
12:пустой буфер - ответ на запрос о синхронизации
13:<token| 1 слово> - запрос на рассинхронизацию
14:<token| 1 слово> - ответ на запрос на рассинхронизацию
21:<token| 1 слово> - запрос на маркер
22:<token| 1 слово> - передача маркера

буфер quality имеет формат <protect_flag| 1 слово><main_sync_flag| 1 слово>

буфер demand имеет формат <marker| 1 слово>



## S_INIT.REQ
```
addr declare integer
type declare integer
quality_size declare integer
demand_size declare integer
protect_flag declare integer
main_sync_flag declare integer
current_crc declare integer
current_calc_crc declare integer
queue_flag declare integer
current_timer integer
current_token declare integer
is_server declare integer
marker declare integer

current_quality declare buffer
current_demand declare buffer
current_buffer declare buffer

current_queue declare queue
total_queue declare queue

set 0 queue_flag
set 0 is_server
set 0 marker
```

## S_CONNECT.REQ
```
;параметры:  address (число), quality (буфер), demand (буфер)
set $quality current_quality
set $demand current_demand
unbuffer demand marker 1
generatedown T_CONNECT.REQ address $address
```

## S_CONNECT.RESP
```
;параметры:  address (число), quality (буфер)
set $quality current_quality
sizeof(current_quality)+2 2 1 sizeof(current_quality) 1 $current_quality sizeof(current_quality) pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
```

## S_DATA.REQ
```
;параметры:   userdata (буфер)
ok if ((($is_server == 1) && (($marker == 4)||($marker == 2))) ||(($is_server == 0) && (($marker == 1)||($marker == 3))))
out "S_DATA REQ NEED TOKEN " CurrentSystemName() " " 1
eventup S_P_EXCEPTION.IND error 1
eventup S_P_EXCEPTION.IND error 3
sizeof(token)+1 21 1 $token sizeof(token) pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
goto end
ok:
unbuffer current_quality protect_flag sizeof(protect_flag) main_sync_flag sizeof(main_sync_flag)
with_protect if $protect_flag == 1
goto without_protect

with_protect:
current_crc varcrc $userdata
sizeof(userdata)+2 4 1 $current_crc sizeof(current_crc) $userdata sizeof(userdata) pack current_buffer
goto send

without_protect:
sizeof(userdata)+1 4 1 $userdata sizeof(userdata) pack current_buffer
goto send

send:
queue  current_queue $current_buffer
end if $queue_flag == 1
set 1 queue_flag
S_TIMER 2 timeevent current_timer 
end:
```

## S_EXPEDITED_DATA.REQ
```
;параметры:   userdata (буфер)

unbuffer current_quality protect_flag sizeof(protect_flag) main_sync_flag sizeof(main_sync_flag)
with_protect if $protect_flag == 1
goto without_protect

with_protect:
current_crc varcrc $userdata
sizeof(userdata)+2 5 1 $current_crc sizeof(current_crc) $userdata sizeof(userdata) pack current_buffer
goto send

without_protect:
sizeof(userdata)+1 5 1 $userdata sizeof(userdata) pack current_buffer
goto send

send:
generatedown T_DATA.REQ userdata $current_buffer
```

## S_GIVE_TOKENS.REQ
```
;параметры:  token (число)
out "S_GIVE_TOKENS REQ " $token
next if "Guide" != CurrentSystemName()
2 22 1 1 1 pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
next:
2 22 1 $token sizeof(token) pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer


marker_1 if (($is_server == 1) && ($marker == 3) && ($token == 2))
marker_1 if (($is_server == 1) && ($marker == 4) && ($token == 1))
marker_2 if (($is_server == 0) && ($marker == 3) && ($token == 1)) 
marker_2 if (($is_server == 0) && ($marker == 4) && ($token == 2))
marker_3 if (($is_server == 0) && ($marker == 1) && ($token == 2))
marker_3 if (($is_server == 1) && ($marker == 2) && ($token == 1))
marker_4 if (($is_server == 0) && ($marker == 1) && ($token == 1))
marker_4 if (($is_server == 1) && ($marker == 2) && ($token == 2))
return

marker_1:
set 1 marker
return

marker_2:
set 2 marker
return

marker_3:
set 3 marker
return

marker_4:
set 4 marker
return

end:
```

## S_PLEASE_TOKENS.REQ
```
;параметры:  token (число)
out "S_PLEASE_TOKENS REQ " CurrentSystemName() " " $token
if (("Guide" == CurrentSystemName())) next
if (($is_server == 0) && ($marker == 1)) skip 
if (($is_server == 1) && ($marker == 2)) skip 
if (($is_server == 0) && ($marker == 3) && ($token == 1)) skip 
if (($is_server == 0) && ($marker == 4) && ($token == 2)) skip 
if (($is_server == 1) && ($marker == 3) && ($token == 2)) skip 
if (($is_server == 1) && ($marker == 4) && ($token == 1)) skip 
sizeof(token)+1 21 1 $token sizeof(token) pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
return

next:
out "GIVE DATA TO GUIDE"
sizeof(token)+1 21 1 1 sizeof(token) pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
sizeof(token)+1 21 1 2 sizeof(token) pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
return

if (($is_server == 0) && ($marker == 3) && ($token== 2)) marker_1 
if (($is_server == 0) && ($marker == 4) && ($token== 1)) marker_1
if (($is_server == 1) && ($marker == 3) && ($token== 1)) marker_2 
if (($is_server == 1) && ($marker == 4) && ($token== 2)) marker_2 
if (($is_server == 1) && ($marker == 1) && ($token== 2)) marker_3 
if (($is_server == 0) && ($marker == 2) && ($token== 1)) marker_3 
if (($is_server == 1) && ($marker == 1) && ($token== 1)) marker_4 
if (($is_server == 0) && ($marker == 2) && ($token== 2)) marker_4 
return

marker_1:
set 1 marker
return

marker_2:
set 2 marker
return

marker_3:
set 3 marker
return

marker_4:
set 4 marker
return

skip:
out "S_PLEASE_TOKENS REQ SKIPED " CurrentSystemName() " " $token
token $token sendup  S_GIVE_TOKENS.IND
```

## S_RELEASE.REQ
```
;параметры:  нет
1 6 1 pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
```

## S_RELEASE.RESP
```
;параметры:  нет

start:
if qcount(total_queue) > 0 repeat 
goto end

repeat:
userdata (dequeue(total_queue)) sendup S_DATA.IND
goto start

end:
1 7 1 pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
```

## S_RESYNCHRONIZE.REQ
```
;параметры:  token (число)

clearqueue tatal_queue
sizeof(token)+1 13 1 $token sizeof(token) pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
```

## S_RESYNCHRONIZE.RESP
```
;параметры:  token (число)

clearqueue tatal_queue
sizeof(token)+1 14 1 $token sizeof(token) pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer

if (($is_server == 0) && ($current_token == 4)) marker_1 
if (($is_server == 1) && ($current_token == 3)) marker_1 
if (($is_server == 0) && ($current_token == 3)) marker_2 
if (($is_server == 1) && ($current_token == 4)) marker_2 
if (($is_server == 0) && ($current_token == 2)) marker_3 
if (($is_server == 1) && ($current_token == 1)) marker_3 
if (($is_server == 0) && ($current_token == 1)) marker_4 
if (($is_server == 1) && ($current_token == 2)) marker_4 

marker_1:
set 1 marker
return

marker_2:
set 2 marker
return

marker_3:
set 3 marker
return

marker_4:
set 4 marker
return
```

## S_SYNC_MAJOR.REQ
```
;параметры:  нет
1 11 1 pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
```

## S_SYNC_MAJOR.RESP
```
;параметры:  нет

start:
if qcount(total_queue) > 0 repeat 
goto end

repeat:
userdata (dequeue(total_queue)) sendup S_DATA.IND
goto start

end:
1 12 1 pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
```

## S_TIMER
```
if (qcount (current_queue) > 0) send 
set 0 queue_flag
goto end

send:
generatedown T_DATA.REQ userdata dequeue (current_queue)
S_TIMER 2 timeevent current_timer 

end:
```

## S_U_ABORT.REQ
```
;параметры:  нет
1 3 1 pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
```

## T_CONNECT.CONF
```
;параметры:  address (число)

set $address addr
set 0 is_server
;0 - инициирующая сторона
sizeof(current_quality) + sizeof(current_demand) + 3 1 1 sizeof(current_quality) 1 sizeof(current_demand) 1 $current_quality sizeof(current_quality) $current_demand sizeof(current_demand) pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
```

## T_CONNECT.IND
```
;параметры:  address (число)

set 1 is_server
;1 - принимающая сторона
set $address addr
generatedown T_CONNECT.RESP address $address
```

## T_DATA.IND
```
;параметры:  userdata (буфер)

;type:
;1 - параметры запроса на соединение
;2 - параметры ответа на запрос на соединение
;3 - запрос о разъединении
;4 - запрос на передачу данных
;5 - запрос на передачу срочных данных
;6 - запрос на упорядоченное разъединение
;6 - ответ на запрос на упорядоченное разъединение
;11 - запрос на главную синхронизацию
;12 - ответ на запрос о синхронизации
;13 - запрос на рассинхронизацию
;14 - ответ на запрос на рассинхронизацию
;21 - запрос на маркер
;22 - передача маркера

unbuffer userdata type sizeof(type) current_buffer sizeof(userdata)-sizeof(type)
connect_req if $type == 1
connect_res if $type == 2
disconnect_req if $type == 3
data_req if $type == 4
exp_data_req if $type == 5
release_req if $type == 6
release_res if $type == 7
sync_req if $type == 11
sync_res if $type == 12
resync_req if $type == 13
resync_res if $type == 14
token_req if $type == 21
token_res if $type == 22
return


connect_req:
unbuffer current_buffer quality_size sizeof(quality_size) demand_size sizeof(demand_size) current_buffer sizeof(current_buffer)-sizeof(quality_size)-sizeof(demand_size)
unbuffer current_buffer current_quality $quality_size current_demand $demand_size
unbuffer current_demand marker sizeof(marker)
eventup S_CONNECT.IND address $addr quality $current_quality demand $current_demand
return


connect_res:
unbuffer current_buffer quality_size sizeof(quality_size) current_buffer sizeof(current_buffer)-sizeof(quality_size)
unbuffer current_buffer current_quality $quality_size
eventup S_CONNECT.CONF quality $current_quality
return


disconnect_req:
generatedown T_DISCONNECT.REQ address $addr
eventup S_U_ABORT.IND
return


data_req:
unbuffer current_quality protect_flag sizeof(protect_flag) main_sync_flag sizeof(main_sync_flag)
with_protect if $protect_flag == 1
goto add

with_protect:
unbuffer current_buffer current_crc sizeof(current_crc) current_buffer sizeof(current_buffer)-sizeof(current_crc)
current_calc_crc varcrc $current_buffer
broken if $current_crc != $current_calc_crc

add:
queue total_queue $current_buffer
return


exp_data_req:
unbuffer current_quality protect_flag sizeof(protect_flag) main_sync_flag sizeof(main_sync_flag)
exp_with_protect if $protect_flag == 1
goto send

exp_with_protect:
unbuffer current_buffer current_crc sizeof(current_crc) current_buffer sizeof(current_buffer)-sizeof(current_crc)
current_calc_crc varcrc $current_buffer
broken if $current_crc != $current_calc_crc

send:
eventup S_EXPEDITED_DATA.IND userdata $current_buffer
return

broken:
out 'data was broken'
return

release_req:
eventup S_RELEASE.IND
return

release_res:
release_repeat if qcount(total_queue) > 0
goto release_end_queue

release_repeat:
eventup S_DATA.IND userdata (dequeue(total_queue))
goto release_res

release_end_queue:
generatedown T_DISCONNECT.REQ address $addr
eventup S_RELEASE.CONF
return


sync_req:
eventup S_SYNC_MAJOR.IND
return


sync_res:
sync_repeat if qcount(total_queue) > 0
goto sync_end_queue

sync_repeat:
eventup S_DATA.IND userdata (dequeue(total_queue))
goto sync_res

sync_end_queue:
eventup S_SYNC_MAJOR.CONF
return


resync_req:
unbuffer current_buffer current_token sizeof(current_token)
eventup S_RESYNCHRONIZE.IND token $current_token
return


resync_res:
unbuffer current_buffer current_token sizeof(current_buffer)
eventup S_RESYNCHRONIZE.IND token $current_token
marker_1 if (($is_server == 0) && ($current_token == 3))
marker_1 if (($is_server == 1) && ($current_token == 4))
marker_2 if (($is_server == 0) && ($current_token == 4))
marker_2 if (($is_server == 1) && ($current_token == 3))
marker_3 if (($is_server == 0) && ($current_token == 1))
marker_3 if (($is_server == 1) && ($current_token == 2))
marker_4 if (($is_server == 0) && ($current_token == 2))
marker_4 if (($is_server == 1) && ($current_token == 1))
return


token_req:
unbuffer current_buffer current_token sizeof(current_token)
out "T DATA GET TOKEN REQ " CurrentSystemName() " " $current_token
eventup S_PLEASE_TOKENS.IND token $current_token
return


token_res:
unbuffer current_buffer current_token sizeof(current_token)
out "T DATA GET TOKEN RESP  " CurrentSystemName() " " $current_token
eventup S_GIVE_TOKENS.IND token $current_token
marker_1 if (($is_server == 0) && ($marker == 3) && ($current_token == 2))
marker_1 if (($is_server == 0) && ($marker == 4) && ($current_token == 1))
marker_2 if (($is_server == 1) && ($marker == 3) && ($current_token == 1))
marker_2 if (($is_server == 1) && ($marker == 4) && ($current_token == 2))
marker_3 if (($is_server == 1) && ($marker == 1) && ($current_token == 2))
marker_3 if (($is_server == 0) && ($marker == 2) && ($current_token == 1))
marker_4 if (($is_server == 1) && ($marker == 1) && ($current_token == 1))
marker_4 if (($is_server == 0) && ($marker == 2) && ($current_token == 2))
return

marker_1:
set 1 marker
return

marker_2:
set 2 marker
return

marker_3:
set 3 marker
return

marker_4:
set 4 marker
return
```

## T_DISCONNECT.IND
```
;параметры:  нет
```

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
T_REPEAT repeat_timer 0 settimer cur_pac $pac cur_num $num_req retry_num 5
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
T_REPEAT repeat_timer 0 settimer cur_pac $pac cur_num $num_req retry_num 5
set $num_req+1 num_req
return
skip:
set "0" connstate
out CurrentSystemName() + " " + $connstate + " 0 T_DISCONNECT.REQ -> (skip)"
```

## T_REPEAT
```
;параметры: cur_pac(buffer), cur_num(integer), retry_num(integer)
skip if ($cur_num < $num_ack) || (retry_num <= 0)
out CurrentSystemName() + " " + $connstate + " " + $connstate + " T_REPEAT -> generatedown N_DATA.REQ, settimer T_REPEAT 41"
out "$cur_num="
out $cur_num
out "$num_ack="
out $num_ack
generatedown N_DATA.REQ userdata $cur_pac
T_REPEAT repeat_timer ($const_MAX_TRANSFER_DELAY*2+1) settimer cur_pac $cur_pac cur_num $cur_num retry_num $retry_num-1
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