# Общее

Синтаксис STX3.

Год создания 2024.

# Прикладной уровень

## A_INIT.REQ
```
declare string apcon_

;перемнные для transfer init
declare string namei_str
declare string namer_str

;для прикладного контекста
declare string apcon_current


;перемнные для resolve
declare integer resolve_timer
declare integer GC_id 
declare buffer resolve_buffer
declare integer address_resolve
declare integer time1_resolve
declare integer time2_resolve
declare string bad_char
declare string good_char
declare buffer resolve_ind_buffer

declare buffer addri
declare integer addres_i

declare buffer addrr
declare integer addres_r

declare buffer GS_data_buffer

;запуск ассоциации
declare integer associate_timer 
declare buffer namei_buff
declare buffer namer_buff
declare buffer context_
declare buffer quality_
declare buffer demand_
1 1 1 buffer demand_
declare integer address_ 
declare buffer associate_data_buff

;для данных 
declare integer data_id
declare integer data_int

;для упорядоченного разъединения
declare integer release_timer

;чтобы было
declare integer sync_timer
declare integer p_data_timer
declare integer isInit
set 0 isInit

;для доп проверки DT
declare integer DT_con
set 0 DT_con
```

## A_ASSOCIATE.CONF
```
;параметры: context (буфер), quality (буфер), demand (буфер)
associate_timer timer 500 context $context quality $quality temp
;A_TRANSFER_INIT.CONF eventup context $context quality $quality
```

## A_ASSOCIATE.IND
```
;параметры: namei (буфер), quality (буфер), apcon (строка)
set $apcon apcon_
A_TRANSFER_INIT.IND eventup namei $namei quality $quality
```

## A_ASSOCIATE.REQ
```
;параметры: namer (буфер), namei (буфер), quality (буфер), demand (буфер), context (буфер), apcon (строка)
;set $apcon apcon

unbuffer address_ 1 namer
out "Ассоциация с адресом " $address_ ", прикладной контекст " $apcon
set $apcon apcon_
associate_timer timer 200 address $address_ quality $quality demand $demand context $context p_connect_req

;P_CONNECT.REQ eventdown address $address_ quality $quality demand $demand context $context
```

## A_ASSOCIATE.RESP
```
;параметры: namei (буфер), context (буфер), quality (буфер), apcon (строка)
out "Дожили"
unbuffer addres_i 1 namei
P_CONNECT.RESP eventdown address $addres_i quality $quality context $context
```

## A_DATA.REQ
```
;параметры: userdata(буфер)

p_data_timer timer 50 userdata $userdata p_data_req
;sync_timer timer 100 Sync
out $isInit
```

## A_RELEASE.CONF
```
;параметры: apcon (строка)
if $apcon == "GS" gs
if $apcon == "DT" dt

gs:
	associate_timer timer 30 namer $namer_buff namei $namei_buff  quality $quality_ demand $demand_ context $context_ apcon "DT" A_ASSOCIATE.REQ
dt:
	set 0 DT_con
```

## A_RELEASE.IND
```
;параметры: apcon (строка)
if $apcon=="DT" dt_release
return

dt_release:
	A_TERMINATE.IND eventup
```

## A_RELEASE.REQ
```
;параметры: apcon (строка)
if $apcon=="GS" gs

gs:
	P_RELEASE.REQ eventdown
```

## A_RELEASE.RESP
```
;параметры: apcon (строка)
if $apcon=="DT" dt_release
return

dt_release:
	P_RELEASE.RESP eventdown
```

## A_RESOLVE.IND
```
;параметры: address (буфер)
unbuffer GC_id 1 address

if $GC_id==0 GC_0
if $GC_id==1 GC_1
if $GC_id==2 GC_2

GC_0:
	unbuffer GC_id 1 address_resolve 1 address
	$address_resolve 1 $namer_str sizeof(namer_str) 1+sizeof(namer_str) buffer namer_buff
	associate_timer timer 0 namer $namer_buff namei $namei_buff  quality $quality_ demand $demand_ context $context_ apcon "DT" A_ASSOCIATE.REQ
	return
GC_1:
	out "надо заменить символ"
	return
GC_2:
	out "Нельзя найти"
```

## A_RESOLVE.REQ
```
;параметры: name (строка)
out "Попытка определить адрес " $name
set locguide($name) addrr

unbuffer GC_id 1 address_resolve 1 time1_resolve 1  time2_resolve 1 bad_char 1 good_char 1 addrr

if $GC_id==0 GC_0
if $GC_id==1 GC_1
if $GC_id==2 GC_2
if $GC_id==3 GC_3
if $GC_id==4 GC_4

GC_0:
	
	0 1 $address_resolve sizeof(address_resolve) 1+sizeof(address_resolve buffer resolve_ind_buffer
	resolve_timer timer 0 address $resolve_ind_buffer A_RESOLVE.IND
	return
GC_1:
	resolve_timer timer $time1_resolve name $name A_RESOLVE.REQ
	return
GC_2:
	resolve_timer timer $time1_resolve name $name A_RESOLVE.REQ
	return
GC_3:
	out "Ничего не нашли"
	;2 1 1 buffer resolve_ind_buffer
	set locguide("Guide") resolve_ind_buffer
	unbuffer GC_id 1 address_resolve 1 resolve_ind_buffer
	$address_resolve 1 $namer_str sizeof(namer_str) 1+sizeof(namer_str) buffer namer_buff
	associate_timer timer 0 namer $namer_buff namei $namei_buff  quality $quality_ demand $demand_ context $context_ apcon "GS" A_ASSOCIATE.REQ
	return
	;resolve_timer timer 0 address $resolve_ind_buffer A_RESOLVE.IND
GC_4:
	1 1 -1 1 bad_char 1 good_char 1 4 buffer resolve_ind_buffer
	resolve_timer timer 0 address $resolve_ind_buffer A_RESOLVE.IND
```

## A_TERMINATE.REQ

```
;параметры: нет
release_timer timer 0 apcon "DT" A_RELEASE.REQ 
```

## A_TERMINATE.RESP

```
release_timer timer 0 apcon "DT" A_RELEASE.RESP 
```

## A_TRANSFER_INIT.REQ

```
;параметры: namer (строка), namei (строка), context (буфер), quality (буфер)
set $namer namer_str
set $namei namei_str
set $context context_
set $quality quality_

set locguide($namei) addri
unbuffer GC_id 1 addres_i 1 addri
$addres_i 1 $namei sizeof(namei) 1+sizeof(namei) buffer namei_buff 

resolve_timer timer 0 name $namer A_RESOLVE.REQ

set 1 isInit
```

## A_TRANSFER_INIT.RESP

```
;параметры: namei (строка), context (буфер), quality (буфер)
associate_timer timer 0  namei $namei_buff context $context quality $quality apcon "DT" A_ASSOCIATE.RESP
set 1 DT_con 
```

## P_CONNECT.CONF

```
;параметры:  quality (буфер), context (буфер)
if $apcon_=="GS" GS_conf
if $apcon_=="DT" DT_conf

GS_conf:
	3 1 $namer_str sizeof(namer_str) 1+sizeof(namer_str) buffer associate_data_buff
	P_DATA.REQ eventdown userdata $associate_data_buff
	sync_timer timer 20 Sync
	return
DT_conf:
	out "Подтверждение DT соединения от представления"
	associate_timer timer 50 context $context quality $quality demand $demand_ A_ASSOCIATE.CONF 
```

## P_CONNECT.IND
```
;параметры:  address (число), quality (буфер), demand (буфер)
out "Идентификация уровня представления со второй стороны" $address
set "SystemA" namei_str
$address 1 $namei_str sizeof(namei_str) sizeof(namei_str)+1 buffer namei_buff 
associate_timer timer 0  namei $namei_buff quality $quality apcon "DT" A_ASSOCIATE.IND
;P_CONNECT.RESP eventdown address $address quality $quality demand $demand 
```

## p_connect_req
```
break
out "tut"
P_CONNECT.REQ eventdown address $address_ quality $quality demand $demand context $context
```

## P_DATA.IND
```
;параметры:  userdata (буфер)

out "пришли данные"
if $apcon_=="GS" gs
if $apcon_=="DT" dt
unbuffer data_id 1 userdata

;if $data_id==1 get_int

get_int:
	
	return

gs:
	unbuffer data_id 1 GS_data_buffer sizeof(userdata)-1 userdata
	;out $GC_id " " $address_resolve " " $time1_resolve " " $time2_resolve " " $bad_char " " $good_char
	;out "Получили адрес " $addres_r
	;$addres_r 1 $namer_str sizeof(namer_str) 1+sizeof(namer_str) buffer namer_buff
	;associate_timer timer 0 namer $namer_buff namei $namei_buff  quality $quality_ demand $demand_ context $context_ apcon "DT" A_ASSOCIATE.REQ
	release_timer timer 0 apcon "GS" A_RELEASE.REQ
	
dt:
	out "Получили пакет, отправляем процессу" 
	A_DATA.IND eventup userdata $userdata
```

## p_data_req
```
out "Пробуем отправить"
if $DT_con==1 send_req
out "Соединение не готово"
p_data_timer timer 50 userdata $userdata p_data_req
return
send_req:
	out "Соединения готово"
	P_DATA.REQ eventdown userdata $userdata
	sync_timer timer 100 Sync
```

## P_GIVE_TOKENS.IND
```
;параметры:  token (число)
```

## P_PLEASE_TOKENS.IND
```
;параметры:  token (число)
out "Просят токен на прикладном" $token
P_GIVE_TOKENS.REQ eventdown token $token
```

## P_RELEASE.CONF
```
;параметры:  нет
if $apcon_=="GS" gs
return
gs:
	out "Разорвались c прикладным контекстом " $apcon_
	;A_RELEASE.CONF eventup apcon "GS"
	resolve_timer timer 0 address $GS_data_buffer A_RESOLVE.IND
	;associate_timer timer 0 namer $namer_buff namei $namei_buff  quality $quality_ demand $demand_ context $context_ apcon "DT" A_ASSOCIATE.REQ
```

## P_RELEASE.IND
```
;параметры:  нет
release_timer timer 0 apcon "DT" A_RELEASE.IND
```

## P_SYNC_MAJOR.CONF
```
;параметры:  нет
```

## P_SYNC_MAJOR.IND
```
;параметры:  нет
```

## Sync
```
P_SYNC_MAJOR.REQ eventdown
```

## temp
```

A_TRANSFER_INIT.CONF eventup context $context quality $quality
out "Указываем, что соединение готово"
set 1 DT_con
```

# Уровень представления

## P_INIT.REQ
```
;описание контекста
declare buffer context_buffer
declare integer context_size

declare string innerOpenSymb
declare string innerCloseSymb
declare integer Syntaxis1
declare integer Syntaxis2
set 0 Syntaxis1
set 0 Syntaxis2

declare integer finalSyntaxis

;буффер для качества
declare buffer final_quality 

;буффер для отправки контекста
declare buffer context_send_buffer
;буффер для отправки прочих срочных данных
declare buffer expedited_send_buffer
;буффер для получения срочных данных
declare buffer expedited_data_buffer

;таймеры
declare integer timer1

;статус срочной информации
declare integer expedited_status

;переменные для отправки информации
declare integer data_id
declare buffer send_data_buffer

;ненужные перменные
declare string outerOpenSymb
declare string outerCloseSymb

; переменные для кодирования
declare integer data_size ;для размера не структурированных данных
declare integer code_num
declare string code_string
declare buffer code_buffer

;а теперь отдельно структуры)))
declare string structure_string
declare string sound
declare string move
declare string color
declare string smell
;индексы для концов структуры
declare integer sound0
declare integer sound1
declare integer move0
declare integer move1
declare integer color0
declare integer color1
declare integer smell0
declare integer smell1
declare integer struct_data_id
declare integer struct_data_len

declare string universal_end_symb ;универсальный символ остановки
set #255 universal_end_symb

declare integer data_len ;перемнная для хранения длины

declare string decoding_string
declare integer end_symb_index

declare string help
declare buffer userdata1
```

## P_CONNECT.REQ
```
;параметры:  address (число), quality (буфер), demand (буфер), context (буфер)
out "Начинаем соединяться на уровне представления с адресом " $address 
set $context context_buffer
set sizeof(context) context_size
;out $context_size 
S_CONNECT.REQ eventdown address $address quality $quality demand $demand

if ($context_size==4) four_params

unbuffer innerOpenSymb 1 innerCloseSymb 1 Syntaxis1 1 context
return 

four_params:
	unbuffer innerOpenSymb 1 innerCloseSymb 1 Syntaxis1 1 Syntaxis2 1 context
	return
```

## P_CONNECT.RESP
```
;параметры:  address (число), quality (буфер), context (буфер)

unbuffer innerOpenSymb 1 innerCloseSymb 1 finalSyntaxis 1 context

S_CONNECT.RESP eventdown address $address quality $quality 

timer1 timer 50 context $context SEND_CONTEXT
```

## P_DATA.REQ
```
;параметры:  userdata (буфер)

unbuffer data_id 1 userdata

if ($data_id==1)&&($finalSyntaxis==1) code_struct_len
if ($data_id==1)&&($finalSyntaxis==2) code_struct_end

if ($data_id==2)&&($finalSyntaxis==1)  code_num_len
if ($data_id==2)&&($finalSyntaxis==2)  code_num_end

if ($data_id==3)&&($finalSyntaxis==1) code_string_len
if ($data_id==3)&&($finalSyntaxis==2) code_string_end

if ($data_id==4)&&($finalSyntaxis==1) code_buffer_len
if ($data_id==4)&&($finalSyntaxis==2) code_buffer_end


return

code_struct_len:
	;TODO сделать перевод структуры
	unbuffer data_id 1 structure_string sizeof(userdata)-1 userdata
	set copy (structure_string, 2, sizeof(userdata)-3) structure_string
	1 1 sizeof(userdata)-1 1 2 buffer send_data_buffer 
	set pos($innerOpenSymb, structure_string) sound0
	set pos($innerCloseSymb, structure_string) sound1
	out $sound0  " " $sound1
	if $sound0 == $sound1-1 skipsound
	set copy(structure_string, $sound0+1, $sound1-2) sound 
	set copy (structure_string, $sound1+1, sizeof(structure_string)-$sound1) structure_string 
;out $sound
	$send_data_buffer sizeof(send_data_buffer) 10 1 sizeof(sound)  1 $sound sizeof(sound) sizeof(send_data_buffer)+2+sizeof(sound) buffer send_data_buffer 
	goto getmove

	skipsound:
	$send_data_buffer sizeof(send_data_buffer) 10 1 0 1  sizeof(send_data_buffer)+2 buffer send_data_buffer

	getmove:
	set pos($innerOpenSymb, structure_string) move0
	set pos($innerCloseSymb, structure_string) move1
	if $move0 == $move1-1 skipmove
	set copy (structure_string, $move0+1, $move1-2) move
	set copy (structure_string, $move1+1, sizeof(structure_string)-$move1) structure_string
	$send_data_buffer sizeof(send_data_buffer) 20 1 $move1-$move0-1  1 $move sizeof(move) sizeof(send_data_buffer)+2+sizeof(move) buffer send_data_buffer 
	goto getcolor
	skipmove:
	$send_data_buffer sizeof(send_data_buffer) 20 1 0 1 sizeof(send_data_buffer)+2 buffer send_data_buffer

	getcolor:
	set pos($innerOpenSymb, structure_string) color0
	set pos($innerCloseSymb, structure_string) color1
	if $color0 == $color1-1 skipcolor
	set copy (structure_string, $color0+1, $color1-2) color 
	set copy (structure_string, $color1+1, sizeof(structure_string)-$color1) structure_string 
;out "color"  $color1-$color0-1
	$send_data_buffer sizeof(send_data_buffer) 30 1 $color1-$color0-1  1 $color sizeof(color) sizeof(send_data_buffer)+2+sizeof(color) buffer send_data_buffer 
	goto getsmell

	skipcolor:
	$send_data_buffer sizeof(send_data_buffer) 30 1 0 1 sizeof(send_data_buffer)+2 buffer send_data_buffer

	getsmell:
	set pos($innerOpenSymb, structure_string) smell0
	set pos($innerCloseSymb, structure_string) smell1
	if $smell0 == $smell1-1 skipsmell
	set copy (structure_string, $smell0+1, $smell1-2) smell
	$send_data_buffer sizeof(send_data_buffer) 40 1 $smell1-$smell0-1  1 $smell sizeof(smell) sizeof(send_data_buffer)+2+sizeof(smell) buffer send_data_buffer 
	goto send_data
	skipsmell:	
	$send_data_buffer sizeof(send_data_buffer) 40 1 0 1 sizeof(send_data_buffer)+2 buffer send_data_buffer	

	send_data:
	unbuffer data_id 1 data_len 1 struct_data_id 1 send_data_buffer
	;out $data_id " " $data_len " " $struct_data_id
	
	S_DATA.REQ eventdown userdata $send_data_buffer
	return

code_num_len:
	unbuffer data_id 1 code_num 1 userdata
	2 1 1 1 $code_num 1 3 buffer send_data_buffer 
	S_DATA.REQ eventdown userdata $send_data_buffer
	return
code_string_len:
	unbuffer data_id 1 code_string sizeof(userdata)-1 userdata
	3 1 sizeof(userdata)-1 1 $code_string sizeof(userdata)-1 1+sizeof(userdata)  buffer send_data_buffer 
	S_DATA.REQ eventdown userdata $send_data_buffer
	return
code_buffer_len:
	unbuffer data_id 1 code_buffer sizeof(userdata)-1 userdata
	4 1 sizeof(userdata)-1 1 $code_buffer sizeof(userdata)-1 1+sizeof(userdata) buffer send_data_buffer 
	S_DATA.REQ eventdown userdata $send_data_buffer
	return

code_struct_end:
	;TODO сделать перевод структуры
;out "погнали"
	unbuffer data_id 1 structure_string sizeof(userdata)-1 userdata
	set copy (structure_string, 2, sizeof(userdata)-3) structure_string
	;$data_id 1 sizeof(userdata)-1 1 2 buffer send_data_buffer 
	set pos($innerOpenSymb, structure_string) sound0
	set pos($innerCloseSymb, structure_string) sound1

	if $sound0 == $sound1-1 skipsound1
	set copy(structure_string, $sound0+1, $sound1-2) sound 
	set copy (structure_string, $sound1+1, sizeof(structure_string)-$sound1) structure_string 
	$sound sizeof(sound) $universal_end_symb 1  1+sizeof(sound) buffer send_data_buffer 
	goto getmove1

	skipsound1:
out 5
	$universal_end_symb 1  1 buffer send_data_buffer
out 6
	getmove1:
	out 7

	set pos($innerOpenSymb, structure_string) move0
	set pos($innerCloseSymb, structure_string) move1
	if $move0 == $move1-1 skipmove1
	set copy (structure_string, $move0+1, $move1-2) move
	set copy (structure_string, $move1+1, sizeof(structure_string)-$move1) structure_string
	$send_data_buffer sizeof(send_data_buffer) $move sizeof(move) $universal_end_symb 1 sizeof(send_data_buffer)+1+sizeof(move) buffer send_data_buffer 
	goto getcolor1
	skipmove1:
	$send_data_buffer sizeof(send_data_buffer) $universal_end_symb 1 sizeof(send_data_buffer)+1 buffer send_data_buffer

	getcolor1:

	set pos($innerOpenSymb, structure_string) color0
	set pos($innerCloseSymb, structure_string) color1
	if $color0 == $color1-1 skipcolor1
	set copy (structure_string, $color0+1, $color1-2) color 
	set copy (structure_string, $color1+1, sizeof(structure_string)-$color1) structure_string
	$send_data_buffer sizeof(send_data_buffer) $color sizeof(color) $universal_end_symb 1 sizeof(send_data_buffer)+1+sizeof(color) buffer send_data_buffer 
	goto getsmell1

	skipcolor1:
	$send_data_buffer sizeof(send_data_buffer) $universal_end_symb 1 sizeof(send_data_buffer)+1 buffer send_data_buffer

	getsmell1:
	set pos($innerOpenSymb, structure_string) smell0
	set pos($innerCloseSymb, structure_string) smell1
	if $smell0 == $smell1-1 skipsmell1
	set copy (structure_string, $smell0+1, $smell1-2) smell
	$send_data_buffer sizeof(send_data_buffer) $smell sizeof(smell) $universal_end_symb 1 sizeof(send_data_buffer)+1+sizeof(smell) buffer send_data_buffer 
	goto send_data1
	skipsmell1:	
	$send_data_buffer sizeof(send_data_buffer) $universal_end_symb 1 sizeof(send_data_buffer)+2 buffer send_data_buffer	

	send_data1:
unbuffer help sizeof(send_data_buffer) send_data_buffer
out "help = " $help
	1 1 sizeof(userdata)-1 1 $help sizeof(help) sizeof(userdata)+sizeof(help) buffer send_data_buffer
	S_DATA.REQ eventdown userdata $send_data_buffer
	return


code_num_end:
	unbuffer data_id 1 code_num 1 userdata
	2 1 $code_num 1 $universal_end_symb 1 3 buffer send_data_buffer 
	S_DATA.REQ eventdown userdata $send_data_buffer
	return
code_string_end:
	unbuffer data_id 1 code_string sizeof(userdata)-1 userdata
	3 1 $code_string sizeof(userdata)-1 $universal_end_symb 1 1+sizeof(userdata) buffer send_data_buffer 
	S_DATA.REQ eventdown userdata $send_data_buffer
	return
code_buffer_end:
	unbuffer data_id 1 code_buffer sizeof(userdata)-1 userdata
	4 1 code_buffer sizeof(userdata)-1  $universal_end_symb 1 1+sizeof(userdata) buffer send_data_buffer 
	S_DATA.REQ eventdown userdata $send_data_buffer
	return
```

## P_EXPEDITED_DATA.REQ
```
; параметры  userdata (буфер)
unbuffer data_id 1 userdata

if ($data_id==1) decoding_struct

buffer 0 1 $userdata sizeof(userdata) sizeof(userdata)+1 expedited_send_buffer
S_EXPEDITED_DATA.REQ eventdown userdata $expedited_send_buffer

return

decoding_struct:
	;TODO сделать перевод структуры
	0 1 $userdata sizeof(userdata) sizeof(userdata)+1 expedited_send_buffer
	S_EXPEDITED_DATA.REQ eventdown userdata $expedited_send_buffer
```

## P_GIVE_TOKENS.REQ
```
;параметры:  token (число)
S_GIVE_TOKENS.REQ eventdown token $token
```

## P_PLEASE_TOKENS.REQ
```
;параметры:  token (число)
S_PLEASE_TOKENS.REQ eventdown token $token
```

## P_RELEASE.REQ
```
;параметры:  нет
S_RELEASE.REQ eventdown 
```

## P_RELEASE.RESP
```
;параметры:  нет
S_RELEASE.RESP eventdown
```

## P_SYNC_MAJOR.REQ
```
;параметры:  нет
S_SYNC_MAJOR.REQ eventdown
```

## P_SYNC_MAJOR.RESP
```
;параметры:  нет
S_SYNC_MAJOR.RESP eventdown
```

## P_U_ABORT.REQ
```
;параметры:  нет
S_U_ABORT.REQ eventdown 
```

## S_CONNECT.CONF
```
;параметры:  quality (буфер)
out "Установили сеансовое соединение"
set $quality final_quality
```

## S_CONNECT.IND
```
;параметры:  address (число), quality (буфер), demand (буфер)

out "Отправили на индикацию на уровне представления"
P_CONNECT.IND eventup address $address quality $quality demand $demand
```

## S_DATA.IND
```
;параметры:  userdata (буфер)
unbuffer data_id 1 userdata
out $finalSyntaxis
if ($data_id==1)&&($finalSyntaxis==1) decode_struct_len
if ($data_id==1)&&($finalSyntaxis==2) decode_struct_end

if ($data_id==2)&&($finalSyntaxis==1) decode_num_len
if ($data_id==2)&&($finalSyntaxis==2) decode_num_end

if ($data_id==3)&&($finalSyntaxis==1) decode_string_len
if ($data_id==3)&&($finalSyntaxis==2) decode_string_end

if ($data_id==4)&&($finalSyntaxis==1) decode_buffer_len
if ($data_id==4)&&($finalSyntaxis==2) decode_buffer_end


return

decode_struct_len:
	;TODO сделать перевод структуры
	$innerOpenSymb 1 $innerOpenSymb 1 2 buffer send_data_buffer
;out 1
	unbuffer data_id 1 data_len 1 struct_data_id 1 struct_data_len 1 userdata1 sizeof(userdata)-4 userdata
;out 2 " " $data_id " " $struct_data_id " " ($struct_data_len==0) " " $struct_data_len
	if ($struct_data_len==0) skipsound
;out 3
	unbuffer sound $struct_data_len userdata1 sizeof(userdata1)-$struct_data_len userdata1
;out 4
	$send_data_buffer sizeof(send_data_buffer) $sound sizeof(sound) sizeof(send_data_buffer)+sizeof(sound) buffer send_data_buffer
;out 5	
	skipsound:
		$send_data_buffer sizeof(send_data_buffer) $innerCloseSymb 1 $innerOpenSymb 1 sizeof(send_data_buffer)+2 buffer send_data_buffer
;out 6
	unbuffer struct_data_id 1 struct_data_len 1 userdata1 sizeof(userdata1)-2 userdata1
;out 7
	if ($struct_data_len==0) skipmove
	unbuffer move $struct_data_len userdata1 sizeof(userdata1)-$struct_data_len userdata1
;out 8
	$send_data_buffer sizeof(send_data_buffer) $move sizeof(move) sizeof(send_data_buffer)+sizeof(move) buffer send_data_buffer
	skipmove:
		$send_data_buffer sizeof(send_data_buffer) $innerCloseSymb 1 $innerOpenSymb 1 sizeof(send_data_buffer)+2  buffer send_data_buffer
	
;out 9
	unbuffer struct_data_id 1 struct_data_len 1 userdata1 sizeof(userdata1)-2 userdata1
	if ($struct_data_len==0) skipcolor
;out 10 
;out sizeof(userdata1) " " $struct_data_len " id = " $struct_data_id
	unbuffer color $struct_data_len userdata1 sizeof(userdata1)-$struct_data_len userdata1
;out 11
	$send_data_buffer sizeof(send_data_buffer) $color sizeof(color) sizeof(send_data_buffer)+sizeof(color) buffer send_data_buffer
	skipcolor:
		$send_data_buffer sizeof(send_data_buffer) $innerCloseSymb 1 $innerOpenSymb 1 sizeof(send_data_buffer)+2  buffer send_data_buffer
	
;out 12
	unbuffer struct_data_id 1 struct_data_len 1 userdata1
	if ($struct_data_len==0) skipsmell
	unbuffer struct_data_id 1 struct_data_len 1 smell $struct_data_len userdata1
	$send_data_buffer sizeof(send_data_buffer) $smell  sizeof(smell) sizeof(send_data_buffer)+sizeof(smell) buffer send_data_buffer
	skipsmell:
		$send_data_buffer sizeof(send_data_buffer) $innerCloseSymb 1 $innerCloseSymb 1 sizeof(send_data_buffer)+2 buffer send_data_buffer

	;out $color " " $sound " " $move " "
	unbuffer help sizeof(send_data_buffer) send_data_buffer
out $help
	$data_id 1 $help sizeof(help) sizeof(help)+1 buffer send_data_buffer
	P_DATA.IND eventup userdata $send_data_buffer
	return
decode_num_len:
	unbuffer data_id 1 data_len 1 userdata
	unbuffer data_id 1 data_len 1 code_num $data_len userdata
	$data_id 1 $code_num $data_len $data_len+1 buffer send_data_buffer 
	P_DATA.IND eventup userdata $send_data_buffer
	return
decode_string_len:
	unbuffer data_id 1 data_len 1 userdata
	unbuffer data_id 1 data_len 1 code_string $data_len userdata
	$data_id 1 $code_string $data_len $data_len+1 buffer send_data_buffer 
	P_DATA.IND eventup userdata $send_data_buffer
	return
decode_buffer_len:
	unbuffer data_id 1 data_len 1 userdata
	unbuffer data_id 1 data_len 1 code_buffer $data_len userdata
	$data_id 1 $code_buffer $data_len 1+$data_len buffer send_data_buffer 
	P_DATA.IND eventup userdata $send_data_buffer
	return

decode_struct_end:
	;TODO сделать перевод структуры
;out "на месте"
	$innerOpenSymb 1 $innerOpenSymb 1 2 buffer send_data_buffer
	unbuffer data_id 1 data_len 1 userdata1 sizeof(userdata)-2 userdata

	unbuffer decoding_string sizeof(userdata1) userdata1

	set pos($universal_end_symb, decoding_string) end_symb_index
	if ($end_symb_index == 1) skipsound1
	unbuffer sound $end_symb_index-1 userdata1 sizeof(userdata1)-$end_symb_index+1 userdata1
	$send_data_buffer sizeof(send_data_buffer) $sound sizeof(sound) sizeof(send_data_buffer)+sizeof(sound) buffer send_data_buffer
	skipsound1:
		unbuffer help 1 userdata1 sizeof(userdata1)-1 userdata1
		$send_data_buffer sizeof(send_data_buffer) $innerCloseSymb 1 $innerOpenSymb 1 sizeof(send_data_buffer)+2 buffer send_data_buffer
	;out $sound

	;unbuffer struct_data_id 1 userdata1 sizeof(userdata1)-1 userdata1
	unbuffer decoding_string sizeof(userdata1) userdata1
	set pos($universal_end_symb, decoding_string) end_symb_index
	if ($end_symb_index == 1)  skipmove1
	unbuffer move $end_symb_index-1  userdata1 sizeof(userdata1)-$end_symb_index+1  userdata1
	$send_data_buffer sizeof(send_data_buffer) $move sizeof(move) sizeof(send_data_buffer)+sizeof(move) buffer send_data_buffer
	skipmove1:
		unbuffer help 1 userdata1 sizeof(userdata1)-1 userdata1
		$send_data_buffer sizeof(send_data_buffer) $innerCloseSymb 1 $innerOpenSymb 1 sizeof(send_data_buffer)+2 buffer send_data_buffer
	;out $move
	;unbuffer struct_data_id 1 userdata sizeof(userdata)-1 userdata
	unbuffer decoding_string sizeof(userdata1) userdata1
	set pos($universal_end_symb, decoding_string) end_symb_index
	if ($end_symb_index == 1) skipcolor1
	unbuffer color $end_symb_index-1 userdata1 sizeof(userdata1)-$end_symb_index+1  userdata1
	$send_data_buffer sizeof(send_data_buffer) $color sizeof(color) sizeof(send_data_buffer)+sizeof(color) buffer send_data_buffer
	skipcolor1:
		unbuffer help 1 userdata1 sizeof(userdata1)-1 userdata1
		$send_data_buffer sizeof(send_data_buffer) $innerCloseSymb 1 $innerOpenSymb 1 sizeof(send_data_buffer)+2 buffer send_data_buffer
	;out $color
	;unbuffer struct_data_id 1 userdata1 sizeof(userdata1)-1 userdata1
	unbuffer decoding_string sizeof(userdata1) userdata1
	set pos($universal_end_symb, decoding_string) end_symb_index
	if ($end_symb_index == 1) skipsmell1
	unbuffer smell $end_symb_index-1  userdata1
	$send_data_buffer sizeof(send_data_buffer) $smell  sizeof(smell) sizeof(send_data_buffer)+sizeof(smell) buffer send_data_buffer
	skipsmell1:
		$send_data_buffer sizeof(send_data_buffer) $innerCloseSymb 1 $innerCloseSymb 1 sizeof(send_data_buffer)+2 buffer send_data_buffer
	;out "на месте"
	;out $color " " $sound " " $move " "
unbuffer help sizeof(send_data_buffer) send_data_buffer
out "Получили структуру на представлении = " $help
$data_id 1 $help sizeof(help) sizeof(help)+1 buffer send_data_buffer
	P_DATA.IND eventup userdata $send_data_buffer
	return
decode_num_end:
	unbuffer data_id 1 decoding_string sizeof(userdata)-1 userdata
;out $decoding_string
	set pos($universal_end_symb, decoding_string) end_symb_index
	unbuffer data_id 1 code_num $end_symb_index-1 userdata
	$data_id 1 $code_num $end_symb_index-1 $end_symb_index buffer send_data_buffer 
	P_DATA.IND eventup userdata $send_data_buffer
	return
decode_string_end:
	unbuffer data_id 1 decoding_string sizeof(userdata)-1 userdata
	set pos($universal_end_symb, decoding_string) end_symb_index
	unbuffer data_id 1 code_string $end_symb_index-1 userdata
	$data_id 1 $code_string $end_symb_index-1 $end_symb_index buffer send_data_buffer  
out "Получили строку на предствалении = "  $code_string 
	P_DATA.IND eventup userdata $send_data_buffer
	return
decode_buffer_end:
	unbuffer data_id 1 decoding_buffer sizeof(userdata)-1 userdata
	set pos($universal_end_symb, decoding_string) end_symb_index
	unbuffer data_id 1 code_buffer $end_symb_index-1 userdata
	$data_id 1 $code_buffer $end_symb_index-1 $end_symb_index buffer send_data_buffer  
	P_DATA.IND eventup userdata $send_data_buffer
	return
```

## S_EXPEDITED_DATA.IND
```
;параметры:  userdata (буфер)

unbuffer expedited_status 1 expedited_data_buffer sizeof(userdata)-1 userdata

if ($expedited_status==73) get_context 

P_EXPEDITED_DATA.IND eventup userdata $expedited_data_buffer 
return

get_context:
	unbuffer outerOpenSymb 1 outerCloseSymb 1 finalSyntaxis 1 expedited_data_buffer
	P_CONNECT.CONF eventup quality $final_quality context $expedited_data_buffer
	out "Соединились на прикладном"
	;out $finalSyntaxis 
```

## S_GIVE_TOKENS.IND
```
;параметры:  token (число)
P_GIVE_TOKENS.IND eventup token $token
```

## S_PLEASE_TOKENS.IND
```
;параметры:  token (число)
P_PLEASE_TOKENS.IND eventup token $token
```

## S_RELEASE.CONF
```
;параметры:  нет

P_RELEASE.CONF eventup
```

## S_RELEASE.IND
```
;параметры:  нет
P_RELEASE.IND eventup
```

## S_SYNC_MAJOR.CONF
```
;параметры:  нет
P_SYNC_MAJOR.CONF eventup
```

## S_SYNC_MAJOR.IND
```
;параметры:  нет
P_SYNC_MAJOR.IND eventup
```

## S_U_ABORT.IND
```
;параметры:  нет
P_U_ABORT.IND eventup 
```

## SEND_CONTEXT
```
; параметры context (буфер)

73 1 $context sizeof(context) 1+sizeof(context) buffer context_send_buffer

S_EXPEDITED_DATA.REQ eventdown userdata $context_send_buffer
```

# Сеансовый уровень

## S_INIT.REQ
```
declare integer send_address

declare integer isCon
set 0 isCon

declare integer isSync
set 0 isSync

declare integer askForDK
set 0 askForDK

declare integer askForMA
set 0 askForMA

declare integer isRelease
set 0 isRelease

declare integer isResync
set 0 isResync

declare integer cant_send_data
set 0 cant_send_data

declare integer cant_send_sync
set 0 cant_send_sync

;флаг на разрыв соединения
declare integer doBreak
set 0 doBreak

;1 - инициатор
declare integer role 
set 0 role

;буферы при инициализации
declare buffer quality_buff
declare integer defend
declare integer main_sync

declare buffer demand_buff
declare integer markers

;маркер данных
declare integer DK
;маркер синхронизации
declare integer MA

;буферы для приема-отправки
declare buffer send_buff
declare buffer get_buff
declare integer contr_sum

declare queue senddata
declare queue outgoing
declare queue ingoing

declare integer syncpoint
declare integer packs_counter_input
declare integer packs_counter

declare integer tok

;тип отправляемых данных: 0 - не понял, 1001 - connection.ind, 1002 - connection.conf, 1023 - abort
declare integer status

;таймеры
declare integer timer0
set -1 timer0
declare integer timer1
set -1 timer1
declare integer timer2
set -1 timer2

;счетчик в циклах
declare integer i

declare integer k_max
set 15 k_max

declare buffer b1
```

## S_CONNECT.REQ
```
;параметры:  address (число), quality (буфер), demand (буфер)
out "Начинаем соединяться на сеансовом уровне с адресом " $address
set $demand demand_buff
set $quality quality_buff
set $address send_address
unbuffer defend 1 main_sync 1 quality_buff
unbuffer markers 1 demand_buff

set 1 role
set 0 doBreak
set 0 syncpoint
set 0 packs_counter
set 0 isSync
set 0 askForDK
set 0 askForMA
set 0 isRelease
set 0 isResync
set 0 cant_send_data
set 0 cant_send_sync
clearqueue outgoing
clearqueue ingoing

;out "markers = " $markers ", role = " $role
set (($markers%2)==($role)) DK
;out "DK = " $DK
set (((($markers-1)%2 + ($markers-1)/2)%2) != $role) MA
;out "MA = " $MA

T_CONNECT.REQ eventdown address $address
```

## S_CONNECT.RESP
```
;параметры:  address (число), quality (буфер)

unbuffer defend 1 main_sync 1 quality

set 0 doBreak
set 0 syncpoint
set 0 packs_counter
set 0 isSync
set 0 askForDK
set 0 askForMA
set 0 isRelease
set 0 isResync
set 0 cant_send_data
set 0 cant_send_sync
clearqueue outgoing
clearqueue ingoing

;out "markers = " $markers ", role = " $role
set (($markers%2)==($role)) DK
;out "DK = " $DK
set (((($markers-1)%2 + ($markers-1)/2)%2) != $role) MA
;out "MA = " $MA


timer0 timer 0 userdata $quality stat 1002 SEND_MESSAGE

;untimer $timer2
```

## S_DATA.REQ
```
;параметры:   userdata (буфер)


set $packs_counter+1 packs_counter
outgoing queuevalue $userdata

if ($DK==0) resync
break

set $outgoing senddata
send_prev_data:
	timer0 timer 0 userdata dequeue  (senddata) stat 3 SEND_MESSAGE
	if qcount (senddata)>0 send_prev_data


return

resync:
	break
	set 1 cant_send_data
	timer0 timer 0 token 1 S_PLEASE_TOKENS.REQ
	;S_P_EXCEPTION.IND eventup error 1
	out "need to recync DK"
```

## S_EXPEDITED_DATA.REQ
```
;параметры:   userdata (буфер)

break
timer0 timer 0 userdata $userdata stat 666 SEND_MESSAGE
```

## S_GIVE_TOKENS.REQ
```
;параметры:  token (число)

if $token==1 give_dk
if $token==2 give_ma
out "unknown token in S_GIVE_TOKENS.REQ = " $token " (role = " $role ")"
return

give_dk:
	set 0 DK
	goto send_tok
give_ma:
	set 0 MA
	goto send_tok

send_tok:
	clearqueue outgoing
	timer0 timer 0 userdata $token stat 7 SEND_MESSAGE
```

## S_PLEASE_TOKENS.REQ
```
;параметры:  token (число)

if $token==1 timer_dk
if $token==2 timer_ma
out "unknown token in S_PLEASE_TOKENS.REQ = " $token " (role = " $role ")"
return

timer_dk:
	clearqueue ingoing
	timer1 timer 0 userdata $token stat 8 SEND_MESSAGE

	set 1 i
	set_timer1:
		timer1 timer 100*$i userdata $token stat 8 SEND_MESSAGE
		set $i+1 i
		if $i<=$k_max set_timer1

	return

timer_ma:
	timer2 timer 0 userdata $token stat 8 SEND_MESSAGE

	set 1 i
	set_timer2:
		timer2 timer 100*$i userdata $token stat 8 SEND_MESSAGE
		set $i+1 i
		if $i<=$k_max set_timer2
```

## S_RELEASE.REQ
```
;параметры:  нет

;T_DATA.REQ eventdown userdata $send_buff 
timer1 timer 0 userdata 0 stat 9 SEND_MESSAGE

set 1 i
set_timer:
	timer1 timer 100*$i userdata 0 stat 9 SEND_MESSAGE
	set $i+1 i
	if $i<=$k_max set_timer
```

## S_RELEASE.RESP
```
;параметры:  нет

set 1 isRelease

timer1 timer 0 userdata 0 stat 10 SEND_MESSAGE
```

## S_RESYNCHRONIZE.REQ
```
;параметры:  token (число)
break

;///пока что бесполезно и, вероятно, неправильно
if ($isResync==$token) || ($isResync==3) exit

set ($token | $isResync) isResync

timer2 timer 0 userdata $token stat 5 SEND_MESSAGE

set 1 i
set_timer:
	timer2 timer 50*$i+10 userdata $token stat 5 SEND_MESSAGE
	set $i+1 i
	if $i<=$k_max set_timer

exit:
```

## S_RESYNCHRONIZE.RESP
```
;параметры:  token (число)

;///пока что бесполезно и, вероятно, неправильно

if $tok%2==1 resync_DK
if $tok==2 resync_MA
if $tok==4 exit
resync_DK:
	set 0 DK
	if $tok==1 exit
resync_MA:
	set 0 MA

exit:
	timer0 timer 0 userdata $tok stat 6 SEND_MESSAGE
```

## S_SYNC_MAJOR.REQ
```
;параметры:  нет

if ($MA==0) resync

set 1 isSync

timer1 timer 0 userdata $packs_counter stat 1 SEND_MESSAGE

set 1 i
set_timer:
	timer1 timer 100*$i userdata $packs_counter stat 1 SEND_MESSAGE
	set $i+1 i
	if $i<=$k_max set_timer

return
resync:
	break
	set 1 cant_send_sync
	;S_P_EXCEPTION.IND eventup error 2
	timer0 timer 0 token 2 S_PLEASE_TOKENS.REQ
	out "need to recync MA"
```

## S_SYNC_MAJOR.RESP
```
;параметры:  нет

timer0 timer 0 userdata $packs_counter stat 4 SEND_MESSAGE
```

## S_U_ABORT.REQ
```
;параметры:  нет

set 1 doBreak

untimer $timer1
untimer $timer2

;T_DATA.REQ eventdown userdata $send_buff 
timer1 timer 0 userdata 0 stat 1023 SEND_MESSAGE

set 1 i
set_timer:
	timer1 timer 50*$i userdata 0 stat 1023 SEND_MESSAGE
	set $i+1 i
	if $i<=$k_max set_timer
```

## SEND_MESSAGE
```
; параметры userdata(...), stat(integer)

$stat 1 $userdata sizeof(userdata) sizeof(userdata)+1 buffer send_buff
crc contr_sum $send_buff
$contr_sum 1 $send_buff sizeof(send_buff) sizeof(send_buff)+1 buffer send_buff

T_DATA.REQ eventdown userdata $send_buff
```

## T_CONNECT.CONF
```
;параметры:  address (число)

$quality_buff 2 $demand_buff 1 3 buffer send_buff

timer1 timer 0 userdata $send_buff stat 1001 SEND_MESSAGE

set 1 i
set_timer:
	timer1 timer 50*$i userdata $send_buff stat 1001 SEND_MESSAGE
	set $i+1 i
	if $i<=$k_max set_timer
;T_DATA.REQ eventdown userdata $qual_dem 
```

## T_CONNECT.IND
```
;параметры:  address (число)

set $address send_address

T_CONNECT.RESP eventdown address $address
```

## T_DATA.IND
```
;параметры:  userdata (буфер)

unbuffer contr_sum 1 get_buff sizeof(userdata)-1 userdata
;check crc
unbuffer status 1 get_buff

if $isCon==0 connection

if $status==0 repeat_data_req
if $status==1 major_sync_ind
if $status==2 minor_sync_ind
if $status==3 data_ind
if $status==4 major_sync_conf
if $status==5 resync_ind
if $status==6 resync_conf
if $status==7 give_toc_ind
if $status==8 please_toc_ind
if $status==9 release_ind
if $status==10 release_conf
if $status==666 expedited_ind
if $status==1013 shut_up
if $status==1022 weird_status
if $status==1023 s_u_abort

out "connection is active, but req for connection (status " $status ")"
if $status==1001 indicate
if $status==1002 confirm

out "from T_DATA.IND begin to error "
goto error

;обработка соединения
connection:
	if $status==1001 indicate
	if $status==1002 confirm
	out "from T_DATA.IND connection to error "
	break
	goto error
indicate: ;status 1001
	unbuffer status 1 get_buff 3 get_buff
	unbuffer quality_buff 2 demand_buff 1 get_buff
	unbuffer defend 1 main_sync 1 quality_buff
	unbuffer markers 1 demand_buff
	set 1 isCon
	S_CONNECT.IND eventup address $send_address quality $quality_buff demand $demand_buff
	return
confirm: ;status 1002
	untimer $timer1
	set -1 timer1
	unbuffer status 1 quality_buff 2 get_buff
	unbuffer defend 1 main_sync 1 quality_buff
	set 1 isCon
	S_CONNECT.CONF eventup quality $quality_buff 
	return

;обработка разрыва
release_ind: ;status 9
	if $isRelease==1 repeat_release_resp
	S_RELEASE.IND eventup
	return
	repeat_release_resp:
		timer0 timer 0 S_RELEASE.RESP
		return

release_conf: ;status 10
	untimer $timer1
	if $isRelease==1 exit
	set 1 isRelease
	S_RELEASE.CONF eventup
	timer0 timer 0 S_U_ABORT.REQ
	return

s_u_abort: ;status 1023
	untimer $timer1
	untimer $timer2
	set 0 isCon
	set 0 role
	T_DISCONNECT.REQ eventdown address $send_address
	if $isRelease==1 exit
	S_U_ABORT.IND eventup
	return

;обработка данных
repeat_data_req: ;status 0
	untimer $timer1
	set -1 timer1
	set $outgoing senddata
	cycle_rep_data_req:
		timer0 timer 0 userdata dequeue  (senddata) stat 3 SEND_MESSAGE
		if qcount (senddata)>0 cycle_rep_data_req

	timer0 timer 0 S_SYNC_MAJOR.REQ
	return

data_ind: ;status 3
	if ($isResync==1) || ($isResync==3) turn_off_resyncDK
	unbuffer status 1 get_buff sizeof(get_buff)-1 get_buff
	ingoing queuevalue $get_buff
	set $packs_counter+1 packs_counter
	return
	turn_off_resyncDK:
		set $isResync-1 isResync
		goto data_ind

expedited_ind: ;status 666
	unbuffer status 1 get_buff sizeof(get_buff)-1 get_buff
	S_EXPEDITED_DATA.IND eventup userdata $get_buff
	return
give_toc_ind: ;status 7
	unbuffer status 1 tok 1 get_buff
	if $tok==1 set_dk
	if $tok==2 set_ma
	out "unknown token in T_DATA_IND (stat 7) = " $token " (role = " $role ")"
	return
	set_dk:
		untimer $timer1
		if $cant_send_data send_data_from_give_toc
		if $DK==1 exit
		set 1 DK
		goto send_toc_ind
	set_ma:
		untimer $timer2
		if $cant_send_sync send_sync_from_give_toc
		if $MA==1 exit
		set 1 MA
		goto send_toc_ind
	send_toc_ind:
		S_GIVE_TOKENS.IND eventup token $tok
		return
	send_data_from_give_toc:
		set 0 cant_send_data
		set $outgoing senddata
		send_data_from_give_toc_cycle:
			timer0 timer 0 userdata dequeue  (senddata) stat 3 SEND_MESSAGE
			if qcount (senddata)>0 send_data_from_give_toc_cycle
		goto set_dk
	send_sync_from_give_toc:
		set 0 cant_send_sync
		timer0 timer 0 S_SYNC_MAJOR.REQ
		goto set_ma

		


please_toc_ind: ;status 8
	unbuffer status 1 tok 1 get_buff
	if $isSync ask_for_tokens
	if (($tok==1) && ($DK==1)) please_tok
	if (($tok==2) && ($MA==1)) please_tok
	timer0 timer 0 token $tok S_GIVE_TOKENS.REQ
	return
	please_tok:
		S_PLEASE_TOKENS.IND eventup token $tok
		return
	ask_for_tokens:
		if $tok==1 ask_for_DK
		if $tok==2 ask_for_MA
	ask_for_DK:
		set 1 askForDK
		return
	ask_for_MA:
		set 1 askForMA
		return


;обработка синхронизации

major_sync_ind: ;status 1
	;break
	if ($isResync==2) || ($isResync==3) turn_off_resyncMA
	unbuffer status 1 packs_counter_input 1 get_buff
	if $packs_counter_input==$syncpoint major_sync_success_repeat
	if $packs_counter_input==$packs_counter major_sync_success
	goto major_sync_failure
	major_sync_success:
out "синхронизировались"
		set $packs_counter syncpoint
		S_SYNC_MAJOR.IND eventup
		;out qcount (ingoing)
		break
		if qcount (ingoing)==0 cycle_data_ind_end
		cycle_data_ind:
			S_DATA.IND eventup userdata dequeue (ingoing)
			if qcount (ingoing)>0 cycle_data_ind
		cycle_data_ind_end:
		return
	major_sync_failure:
out "не синхронизировались"
out "число пакетов указано = " $packs_counter_input
out "число пакетов по факту = " $packs_counter
		set $syncpoint packs_counter
		clearqueue ingoing
		timer0 timer 0 userdata 0 stat 0 SEND_MESSAGE
		return
	major_sync_success_repeat:
out " повторно синхронизировались"
		timer0 timer 0 S_SYNC_MAJOR.RESP
		return
	turn_off_resyncMA:
		set $isResync-2 isResync
		goto major_sync_ind

major_sync_conf: ;status 4
	if $isSync==0 exit
	set 0 isSync
	untimer $timer1
	S_SYNC_MAJOR.CONF eventup
	set $packs_counter syncpoint
	clearqueue outgoing
	finish_other_process:
	if $askForDK send_DK_from_major
	if $askForMA send_MA_from_major
	return
	send_DK_from_major:
		S_PLEASE_TOKENS.IND eventup token 1
		set 0 askForDK
		goto finish_other_process
	send_MA_from_major:
		S_PLEASE_TOKENS.IND eventup token 2
		set 0 askForMA
		goto finish_other_process

minor_sync_ind:
	out "error - minor_sync_ind doesnt exist"
	return

;------------------------------------------------------------пока что бесполезно и, вероятно, неправильно
resync_ind: ;status 5
	unbuffer status 1 tok 1 get_buff
	if $isResync==$tok resync_ind_repeat
	set ($tok | $isResync) isResync
	S_RESYNCHRONIZE.IND eventup token $tok
	return
	resync_ind_repeat:
		timer0 timer 0 userdata $tok stat 6 SEND_MESSAGE
		return

resync_conf: ;status 6
	unbuffer status 1 tok 1 get_buff
	if ($isResync==0) || (($isResync<3) && ($isResync!=$tok)) exit
	set $isResync-$tok isResync
	S_RESYNCHRONIZE.CONF eventup token $tok
	if $isResync exit
	untimer $timer2
	return
;----------------------------------------------------------------------

;что-то пошло не по плану
shut_up: ;status 1013
	untimer $timer1
	return
defend:
	out "attention defend non zero!!!!" $defend
	return

weird_status: ;status 1022
	unbuffer status 1 i 1 get_buff sizeof(get_buff)-2 get_buff
	out "weird status1 = " $status ", pack_num = " $i
	unbuffer i 1 get_buff sizeof(get_buff)-1 get_buff
	unbuffer status 1 get_buff
	out "status actual  = " $status
	return


error:
	out "isCon = " $isCon ", status = " $status ", role=" $role
	out "error happens((("

exit:
```

## T_DISCONNECT.IND
```
;параметры:  нет


if $doBreak==0 restore
set 0 doBreak
set 0 isCon
set 0 role
untimer $timer1
set -1 timer1
return

restore:
	T_RECONNECT.REQ eventdown 
```

# Транспортный уровень

Не понял, зачем она реализовала обработчики сетевого уровня с соединением, если у неё сетевой уровень без соединений

## T_INIT.REQ
```
declare integer send_address
declare integer notIND
declare integer notCONF
set 1 notIND
set 1 notCONF

declare integer isCon
set 0 isCon

declare integer isDisLast
set 0 isDisLast

declare integer isDataLast
set 0 isDataLast

declare integer isConIndLast
set 0 isConIndLast

declare integer isConConfLast
set 0 isConConfLast

declare integer setCon
set 0 setCon

declare integer restoreConnection
set 0 restoreConnection

;буфферы
declare buffer send_buff
declare buffer s_buff
declare buffer check_buff


;для контрольнх сумм
declare integer contr_sum
declare integer input_contr_sum
declare integer hasSum
set 0 hasSum

;результат распаковки
declare integer status 
declare integer size

;данные от t_data
declare integer data

;счетчик для приема данных
declare integer k
set 0 k

;число пакетов для отправки
declare integer k_max
set 8 k_max

;счетчик для циклов
declare integer i
set 0 i

;переменная для проверки номера пакета
declare integer pack_num
```

## N_CONNECT.CONF
```
;параметры:  address (число)
out "соединились"
T_CONNECT.CONF eventup address $address
```

## N_CONNECT.IND
```
;параметры:  address (число)

T_CONNECT.RESP eventdown address $address
```

## N_DATA.IND
```
;параметры:  userdata (буфер)
T_DATA.IND eventup userdata $userdata 
```

## N_DATAGRAM.IND
```

;параметры:  address (число), userdata (буфер)
;if ($isCon==1) ifCon

unpack_data:
set $k+1 k
if sizeof(userdata)<2 drop_pack
unbuffer input_contr_sum 1 check_buff sizeof(userdata)-1 userdata
crc contr_sum $check_buff
if ($contr_sum-$input_contr_sum) drop_pack
;if sizeof(check_buff)<3 drop_pack
unbuffer status 1 pack_num 1 check_buff sizeof(check_buff)-2 check_buff

;out "Пришедший статус"
;out $status
if $status==1 connection
if $status==1022 data_extr
if $isDataLast==1 data_extr
if $status==1023 discon_ind

out "smth went wrong - crc ok, but status undefined"
drop_pack:
if $k<$k_max end
if $isDataLast==1 data_extr
if $isConIndLast==1 con_ind
if $isConConfLast==1 con_conf
if $isDisLast==1 discon_ind
if $setCon==1 connection
goto bad_connection
;goto discon_ind
connection:
	set 1 setCon
	if $notIND == 1 con_ind
	if $notCONF==1 con_conf
	goto end
bad_connection:
	if $notIND == 1 con_ind
	if $notCONF==1 con_conf
	goto discon_ind
con_ind: 
	set 1 isConIndLast
	if $k<$k_max end
;	out "begin response"
	set 0 notIND
	set 0 notCONF
	T_CONNECT.IND eventup address $address
	set 1 isCon
	goto end
con_conf: 
	set 1 isConConfLast
	if $k<$k_max end
;	out "begin conf"
	set 0 notCONF
	T_CONNECT.CONF eventup address $address
	set 1 isCon
	goto end
discon_ind:
	set 1 isDisLast
	if $k<$k_max end
;	out "begin discon ind"
	set 1 notIND
	set 1 notCONF
	if $isCon==0 nextstep
	T_DISCONNECT.IND eventup 
	set 0 isCon
	goto nextstep
restore_connection:
	set 1 restoreConnection
	set 0 notIND
	set 0 notCONF
	T_CONNECT.IND eventup address $address
	set 1 isCon
data_extr:
	if $isCon==0 restore_connection
	if ($isDataLast ==1) && ($k==$k_max) data_ind
	if ($isDataLast ==1) && ($k<$k_max) end
	set 1 isDataLast
	set $check_buff s_buff
	if $k==$k_max data_ind
	goto end
data_ind:
;	out "data ind"
	set 1 isDataLast
	T_DATA.IND eventup userdata $s_buff
	goto end
end: 
;out "in the end, k = "
;out $k
;out $pack_num
if ($k == $k_max) nextstep
return
nextstep:
	set 0 isDataLast
	set 0 isDisLast
	set 0 isConIndLast
	set 0 isConConfLast
	set 0 setCon
	set 0 k
```

## N_DISCONNECT.IND
```
;параметры:  нет
set 1 notIND
set 1 notCONF
set 1 isDisLast
T_DISCONNECT.IND eventup 
```

## T_CONNECT.REQ
```
;параметры:  address (число)
set $address send_address 

set 1 i
cycle1:
	0 1 1 buffer send_buff
	1 1 $i 1 $send_buff sizeof(send_buff) sizeof(send_buff)+2 buffer send_buff
	crc contr_sum $send_buff
	$contr_sum 1 $send_buff sizeof(send_buff) sizeof(send_buff)+1 buffer send_buff
	N_DATAGRAM.REQ eventdown address $address userdata $send_buff
	set $i+1 i
	if $i<=$k_max cycle1

set 0 notIND 
set 0 isDisLast
;N_DATAGRAM.REQ eventdown address $address userdata $send_buff
```

## T_CONNECT.RESP
```
;параметры:  address (число)
if $restoreConnection==1 end
set $address send_address
0 1 1 buffer send_buff
1 1 0 1 $send_buff sizeof(send_buff) sizeof(send_buff)+2 buffer send_buff
crc contr_sum $send_buff
$contr_sum 1 $send_buff sizeof(send_buff) sizeof(send_buff)+1 buffer send_buff

set 1 i
cycle1:
	0 1 1 buffer send_buff
	1 1 $i 1 $send_buff sizeof(send_buff) sizeof(send_buff)+2 buffer send_buff
	crc contr_sum $send_buff
	$contr_sum 1 $send_buff sizeof(send_buff) sizeof(send_buff)+1 buffer send_buff
	N_DATAGRAM.REQ eventdown address $address userdata $send_buff
	set $i+1 i
	if $i<=$k_max cycle1

set 0 isDisLast
return

end:
	set 0 restoreConnection
;N_DATAGRAM.REQ eventdown address $address userdata $send_buff
```

## T_DATA.REQ
```
;параметры:   userdata (буфер)
;out "Состояние соединения"
;out $isCon

set 1 i
cycle1:
	1022 1 $i 1 $userdata sizeof(userdata) sizeof(userdata)+2 buffer send_buff
	crc contr_sum $send_buff
	$contr_sum 1 $send_buff sizeof(send_buff) sizeof(send_buff)+1 buffer send_buff
	N_DATAGRAM.REQ eventdown address $send_address userdata $send_buff
	set $i+1 i
	if $i<=$k_max cycle1
```

## T_DATAGRAM.REQ
```
```

## T_DISCONNECT.REQ
```
;параметры:  address (число)
set 1 notIND
set 1 notCONF
set 0 isCon

;crc contr_sum $send_buff
;2 1 $contr_sum 1 2 buffer send_buff
;N_DATAGRAM.REQ eventdown address $address userdata $send_buff
;N_DATAGRAM.REQ eventdown address $address userdata $send_buff

;N_DATAGRAM.REQ eventdown address $address userdata $send_buff

set 1 i
cycle1:
	0 1 1 buffer send_buff
	1023 1 $i 1 $send_buff sizeof(send_buff) sizeof(send_buff)+2 buffer send_buff	
	crc contr_sum $send_buff
	$contr_sum 1 $send_buff sizeof(send_buff) sizeof(send_buff)+1 buffer send_buff

	N_DATAGRAM.REQ eventdown address $address userdata $send_buff
	set $i+1 i
	if $i<=$k_max cycle1
```

## T_RECONNECT.REQ
```
set 0 notIND
set 0 notCONF
set 1 isCon
```
