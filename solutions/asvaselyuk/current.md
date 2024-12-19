# Общее

Синтаксис STX1.

Год создания 2024.

# Прикладной уровень

Прикладной уровень предоставляет услуги прикладному процессу и использует услуги уровня представления.

Термином "ассоциация" называется логическая связь между объектами разных уровней. То есть A_ASSOCIATE следует воспринимать аналогом T_CONNECT, S_CONNECT и P_CONNECT.

На прикладном уровне вводится третья система - справочник ("Guide"), которая является аналогом DNS сервера.

Предполагается, что прикладной уровень разделён на 3 части: основную часть (ЭСУА), справочная служба (СС, Guide System, GS), служба передачи данных (Data Transfer, DT). ЭСУА отвечает за услуги A_ASSOCIATE, A_RELEASE, A_U_ABORT, A_P_ABORT, а GS и DT являются пользователями этих услуг, как и прикладной процесс, поэтому у них всех есть параметр apcon, принимающий значения "GS", "DT" и "AP" (прикладной процесс).

Прикладной процесс нигде не передаёт прикладному уровню адрес второй системы, только имя системы, так что нужно реализовать аналог DNS. В справке по уровню описывается функция locguide, которая позволяет по имени получить адрес или по адресу имя, это аналог файла hosts. Кроме него известно имя "Guide" справочной службы, которая является аналогом DNS сервера.

Сначала прикладной процесс посылает событие A_TRANSFER_INIT.REQ и указывает своё имя и имя второй стороны. Нужно попытаться узнать адрес второй стороны сначала от locguide(), а при неудаче от "Guide" (то есть узнать адрес от locguide, установить с ним P-соединение, передать строку с именем, получить буфер с ответом, закрыть P-соединение, обработать ответ). После этого надо установить P-соединение со второй стороной.

## A_INIT.REQ

```
namer_addr declare integer
namer_name declare string
namei_addr declare integer
namei_name declare string

dummy_timer declare integer
tmp_data declare buffer
tmp_data1 declare buffer
tmp_data2 declare buffer
tmp_data3 declare buffer
tmp_data4 declare buffer
tmp_addr declare integer
tmp_type declare integer
tmp_time1 declare integer
tmp_time2 declare integer
tmp_char1 declare string
tmp_char2 declare string
tmp_str declare string

esua_apcon declare string
esua_address declare integer
esua_quality declare buffer
esua_context declare buffer
esua_demand declare buffer

gs_apcon declare string
gs_name declare string
gs_other_addr declare integer
set 0 gs_other_addr
gs_addr declare buffer

dt_namer declare string
dt_namei declare string
dt_namei_addr declare integer
dt_context declare buffer
dt_quality declare buffer
dt_userdata declare buffer
dt_want_data_token declare integer
dt_want_sync_token declare integer

CODE_APCON_REQ declare integer
CODE_APCON_RESP declare integer
set 1 CODE_APCON_REQ
set 2 CODE_APCON_RESP
```

## ЭСУА

### A_ASSOCIATE.REQ

Эту операцию могут инициировать прикладной процесс (AP) напрямую,
через справочную службу (GS) вызовом A_RESOLVE.REQ
или через службу передачи данных (DT) вызовом A_TRANSFER_INIT.REQ,
что определяется параметром apcon.

```
;параметры: namer (буфер), namei (буфер), quality (буфер), demand (буфер), context (буфер), apcon (строка)
unbuffer namer namer_addr 1 namer_name sizeof(namer)-1
unbuffer namei namei_addr 1 namei_name sizeof(namei)-1
out CurrentSystemName() " A_ASSOCIATE.REQ namer " $namer_addr $namer_name " namei " $namei_addr $namei_name " quality " $quality " demand " $demand " context " $context " apcon " $apcon

set $apcon esua_apcon
set $demand esua_demand
generatedown P_CONNECT.REQ address $namer_addr quality $quality demand $demand context $context
```

### A_ASSOCIATE.RESP
```
;параметры: namei (буфер), context (буфер), quality (буфер), apcon (строка)
unbuffer namei namei_addr 1 namei_name sizeof(namei)-1
out CurrentSystemName() " A_ASSOCIATE.RESP namei " $namei_addr $namei_name " quality " $quality " context " $context " apcon " $apcon

generatedown P_CONNECT.RESP address $namei_addr quality $quality context $context
```

### A_RELEASE.REQ
```
;параметры: apcon (строка)
out "A_RELEASE.REQ apcon " $apcon

generatedown P_RELEASE.REQ
```

### A_RELEASE.RESP
```
;параметры: apcon (строка)
out "A_RELEASE.RESP apcon " $apcon

generatedown P_RELEASE.RESP
```

### A_U_ABORT.REQ
```
;параметры: apcon (строка)
out "A_U_ABORT.REQ apcon " $apcon

generatedown P_U_ABORT.REQ
```

### P_CONNECT.CONF
Когда соединение установлено нужно либо "передать управление" GS (A_ASSOCIATE.IND.GS) или DT (A_ASSOCIATE.IND.DT), либо сообщить эту радостную весть AP (A_ASSOCIATE.IND).
```
;параметры:  quality (буфер), context (буфер)
out CurrentSystemName() " P_CONNECT.CONF quality " $quality " context " $context

gs if $esua_apcon == "GS"
dt if $esua_apcon == "DT"
ap:
eventup A_ASSOCIATE.CONF context $context quality $quality demand $esua_demand
return
gs:
A_ASSOCIATE.CONF.GS dummy_timer 0 settimer context $context quality $quality demand $esua_demand
return
dt:
; A_ASSOCIATE.CONF.DT context $context quality $quality demand $esua_demand
eventup A_TRANSFER_INIT.CONF context $context quality $quality
;A_ASSOCIATE.CONF.DT dummy_timer 0 settimer context $context quality $quality demand $esua_demand
return
```

### P_CONNECT.IND
В A_ASSOCIATE.IND нужно передать apcon, который можно передать через P_EXPEDITED_DATA.
P_EXPEDITED_DATA можно использовать до завершения установки P-соединения,
поэтому тут просто сохраняются все данные для передачи в A_ASSOCIATE.IND
и запрашивается apcon.

```
;параметры:  address (число), quality (буфер), demand (буфер)
out CurrentSystemName() " P_CONNECT.IND address " $address " quality " $quality " demand " $demand

; Guide give correct answer only once so I need to save SystemB/SystemA address instead of repeatedly ask for the same address
set $address gs_other_addr
set $address esua_address
set $quality esua_quality
set $demand esua_demand
2 4 1 $CODE_APCON_REQ 1 pack tmp_data
generatedown P_EXPEDITED_DATA.REQ userdata $tmp_data
```

### P_P_ABORT.IND
```
;параметры:  нет
dt if $esua_apcon == "DT"
gs if $esua_apcon == "GS"
ap:
eventup A_P_ABORT.IND apcon "AP"
return
dt:
A_P_ABORT.IND.DT dummy_timer 0 settimer apcon "DT"
return
gs:
A_P_ABORT.IND.GS dummy_timer 0 settimer apcon "GS"
return
```

### P_RELEASE.CONF
```
;параметры:  нет
out CurrentSystemName() " P_RELEASE.CONF"
gs if $esua_apcon == "GS"
dt if $esua_apcon == "DT"
ap:
eventup A_RELEASE.CONF apcon "AP"
return

gs:
; A_RELEASE.CONF.GS
gs_dt if $gs_apcon == "DT"
gs_ap:
eventup A_RESOLVE.IND address $gs_addr
return
gs_dt:
set "AP" gs_apcon
A_RESOLVE.IND.DT dummy_timer 0 settimer address $gs_addr
return

dt:
; A_RELEASE.CONF.DT
eventup A_TERMINATE.CONF
```

### P_RELEASE.IND
```
;параметры:  нет
out CurrentSystemName() " P_RELEASE.IND"
gs if $esua_apcon == "GS"
dt if $esua_apcon == "DT"

ap:
eventup A_ASSOCIATE.IND apcon "AP"
return

gs:
; A_RELEASE.IND.GS
generatedown P_RELEASE.RESP
return

dt:
; A_RELEASE.IND.DT
eventup A_TERMINATE.IND
return
```

### P_U_ABORT.IND
```
;параметры:  нет
dt if $current_apcon == "DT"
gs if $current_apcon == "GS"
ap:
eventup A_P_ABORT.IND apcon $apcon
return
dt:
A_P_ABORT.IND.DT dummy_timer 0 settimer apcon $apcon
return
gs:
A_P_ABORT.IND.GS dummy_timer 0 settimer apcon $apcon
```

## GS

### A_ASSOCIATE.CONF.GS
```
;параметры: context (буфер), quality (буфер), demand (буфер)
out CurrentSystemName() " A_ASSOCIATE.CONF.GS"
sizeof(gs_name)+1 3 1 $gs_name sizeof(gs_name) pack tmp_data

A_DATA.REQ dummy_timer 0 settimer userdata $tmp_data
```

### A_ASSOCIATE.IND.GS
Справочная служба при индикации соединения отвечает на него
```
```

### A_RELEASE.CONF.GS
```
```

### A_RELEASE.IND.GS
```
```

### A_RESOLVE.REQ
Адрес либо вернётся из locguide(), либо нужно будет установить ассоциацию (т.е. соединение) с Guide
и спросить у Guide адрес. Обработчик очень похож на A_ASSOCIATE.REQ
```
;параметры: name (строка)
out CurrentSystemName() " A_RESOLVE.REQ name " $name

give_saved_address if $gs_other_addr != 0

check_locguide:
set locguide($name) tmp_data
unbuffer tmp_data tmp_type 1 tmp_addr 1 tmp_time1 1 tmp_time2 1 tmp_char1 1 tmp_char2 1

out CurrentSystemName() " A_RESOLVE.REQ locguide(" $name ") = " $tmp_type "," $tmp_addr "," $tmp_time1 "," $tmp_time2 "," $tmp_char1 "," $tmp_char2
name_found if $tmp_type == 0
name_wait_time1 if $tmp_type == 1
name_wait_time12 if $tmp_type == 2
name_not_found_locally if $tmp_type == 3
name_suggest_replace if $tmp_type == 4
return

give_saved_address:
4 0 1 $gs_other_addr 1  "<" 1 ">" 1 pack tmp_data
resolve_dt if $gs_apcon == "DT"
goto resolve_ap

name_found:
4 0 1 $tmp_addr 1 "<" 1 ">" 1 pack tmp_data
resolve_dt if $gs_apcon == "DT"
resolve_ap:
eventup A_RESOLVE.IND address $tmp_data
return
resolve_dt:
A_RESOLVE.IND.DT dummy_timer 0 settimer address $tmp_data
return

name_wait_time1:
name_wait_time2:
A_RESOLVE.REQ dummy_timer $tmp_time1 settimer name $name
return

name_not_found_locally:
name_suggest_replace:
set $name gs_name
set locguide("Guide") tmp_data
unbuffer tmp_data tmp_type 1 tmp_addr 1 tmp_time1 1 tmp_time2 1 tmp_char1 1 tmp_char2 1
out CurrentSystemName() " A_RESOLVE.REQ locguide(Guide) = " $tmp_type "," $tmp_addr "," $tmp_time1 "," $tmp_time2 "," $tmp_char1 "," $tmp_char2
6 $tmp_addr 1 "Guide" 5 pack tmp_data

set CurrentSystemName() tmp_str
set locguide($tmp_str) tmp_data1
unbuffer tmp_data1 tmp_type 1 tmp_addr 1 tmp_time1 1 tmp_time2 1 tmp_char1 1 tmp_char2 1
out "A_RESOLVE.REQ locguide(" $tmp_str ") = " $tmp_type "," $tmp_addr "," $tmp_time1 "," $tmp_time2 "," $tmp_char1 "," $tmp_char2
1+sizeof(tmp_str) $tmp_addr 1 $tmp_str sizeof(tmp_str) pack tmp_data1

2 0 1 0 1 pack tmp_data2
1 1 1 pack tmp_data3
4 "<" 1 ">" 1 1 1 2 1 pack tmp_data4
A_ASSOCIATE.REQ dummy_timer 0 settimer namer $tmp_data namei $tmp_data1 quality $tmp_data2 demand $tmp_data3 context $tmp_data4 apcon "GS"
return
```

### A_P_ABORT.IND.GS
```
;параметры: apcon (строка)
out "A_P_ABORT.IND.GS apcon " $apcon
```

### A_U_ABORT.IND.GS
```
;параметры: apcon (строка)
out "A_U_ABORT.IND.GS apcon " $apcon
```

## DT

### A_ASSOCIATE.CONF.DT
```
;параметры: context (буфер), quality (буфер), demand (буфер)
out CurrentSystemName() " A_ASSOCIATE.CONF.DT"
eventup A_TRANSFER_INIT.CONF context $context quality $quality
```

### A_DATA.REQ
```
;параметры: userdata (буфер)
out "A_DATA.REQ userdata " $userdata
set $userdata dt_userdata
generatedown P_DATA.REQ userdata $userdata
A_SYNC_MAJOR.REQ dummy_timer 5 settimer
```

### A_P_ABORT.IND.DT
```
;параметры: apcon (строка)
eventup A_TRANSFER_ABORT.IND
```

### A_RELEASE.CONF.DT
```
;параметры: apcon (строка)
eventup A_TERMINATE.CONF
```

### A_RELEASE.IND.DT
```
;параметры: apcon (строка)
eventup A_TERMINATE.IND
```

### A_RESOLVE.IND.DT
```
;параметры: address (буфер)
unbuffer address tmp_type 1 tmp_addr 1 tmp_char1 1 tmp_char2 1
out CurrentSystemName() " P_RELEASE.CONF A_RESOLVE.IND.DT address " $tmp_type "," $tmp_addr "," $tmp_char1 "," $tmp_char2
1+sizeof(dt_namer) $tmp_addr 1 $dt_namer sizeof(dt_namer) pack tmp_data

set locguide($dt_namei) tmp_data1
unbuffer tmp_data1 tmp_type 1 tmp_addr 1 tmp_time1 1 tmp_time2 1 tmp_char1 1 tmp_char2 1
out "A_RESOLVE.REQ locguide(" $dt_namei ") = " $tmp_type "," $tmp_addr "," $tmp_time1 "," $tmp_time2 "," $tmp_char1 "," $tmp_char2
1+sizeof(dt_namei) $tmp_addr 1 $dt_namei sizeof(dt_namei) pack tmp_data1

1 1 1 pack tmp_data2
A_ASSOCIATE.REQ dummy_timer 0 settimer namer $tmp_data namei $tmp_data1 quality $dt_quality demand $tmp_data2 context $dt_context apcon "DT"
```

### A_TERMINATE.REQ
```
;параметры: нет
out "A_TERMINATE.REQ"

A_RELEASE.REQ dummy_timer 0 settimer apcon "DT"
```

### A_TERMINATE.RESP
```
;параметры: нет
out "A_TERMINATE.RESP"

A_RELEASE.RESP dummy_timer 0 settimer apcon "DT"
```

### A_TRANSFER_ABORT.REQ
```
;параметры: нет
out "A_TRANSFER_ABORT.REQ"
A_U_ABORT.REQ dummy_timer 0 settimer apcon "DT"
```

### A_TRANSFER_INIT.REQ
```
;параметры: namer (строка), namei (строка), context (буфер), quality (буфер)
out "A_TRANSFER_INIT.REQ namer " $namer " namei " $namei " quality " $quality " context " $context
set "DT" gs_apcon
set $namer dt_namer
set $namei dt_namei
set $context dt_context
set $quality dt_quality
A_RESOLVE.REQ dummy_timer 0 settimer name $namer
```

### A_TRANSFER_INIT.RESP
```
;параметры: namei (строка), context (буфер), quality (буфер)
out CurrentSystemName() " A_TRANSFER_INIT.RESP namei " $namei " quality " $quality " context " $context

1+sizeof(namei) $dt_namei_addr 1 $namei sizeof(namei) pack tmp_data
A_ASSOCIATE.RESP dummy_timer 0 settimer namei $tmp_data context $context quality $quality apcon "DT"
```

### A_U_ABORT.IND.DT
```
;параметры: apcon (строка)
eventup A_TRANSFER_ABORT.IND
```

## Общее

### A_SYNC_MAJOR.REQ
```
generatedown P_SYNC_MAJOR.REQ
```

### P_DATA.IND
```
;параметры:  userdata (буфер)
out CurrentSystemName() " P_DATA.IND userdata " $userdata

gs if $esua_apcon == "GS"
dt if $esua_apcon == "DT"
ap:
return

gs:
unbuffer userdata tmp_data 1 tmp_type 1 tmp_addr 1 tmp_time1 1 tmp_time2 1 tmp_char1 1 tmp_char2 1
out CurrentSystemName() " P_DATA.IND Guide received for " $gs_name " " $tmp_type "," $tmp_addr "," $tmp_time1 "," $tmp_time2 "," $tmp_char1 "," $tmp_char2

gs_time if ($tmp_type == 1) || ($tmp_type == 2)
gs_resolve if ($tmp_type == 3) || ($tmp_type == 4)
save_systemb_addr:
; Guide give correct answer only once so I need to save SystemB/SystemA address instead of repeatedly ask for the same address
set $tmp_addr gs_other_addr
gs_resolve:
4 $tmp_type/2 1 $tmp_addr 1 $tmp_char1 1 $tmp_char2 1 pack gs_addr
generatedown P_RELEASE.REQ
return

gs_time:
sizeof(gs_name)+1 3 1 $gs_name sizeof(gs_name) pack tmp_data
A_DATA.REQ dummy_timer $tmp_time1 settimer userdata $tmp_data
return

set locguide($gs_name) tmp_data
unbuffer tmp_data tmp_type 1 tmp_addr 1 tmp_time1 1 tmp_time2 1 tmp_char1 1 tmp_char2 1
out CurrentSystemName() " P_DATA.IND locguide(" $gs_name ") = " $tmp_type "," $tmp_addr "," $tmp_time1 "," $tmp_time2 "," $tmp_char1 "," $tmp_char2
return

dt:
eventup A_DATA.IND userdata $userdata
return
```

### P_EXPEDITED_DATA.IND
Через P_EXPEDITED_DATA передаются управляющие сообщения:

- запрос на получение apcon
- сообщение с apcon для выполнения A_ASSOCIATE.IND

```
;параметры:  userdata (буфер)
unbuffer userdata tmp_data1 1 tmp_type 1 tmp_data sizeof(userdata)-2
out CurrentSystemName() " P_EXPEDITED_DATA.IND userdata " $userdata "(" $tmp_data1 "," $tmp_type "," $tmp_data ")"
apcon_req if $tmp_type == $CODE_APCON_REQ
apcon_resp if $tmp_type == $CODE_APCON_RESP
return

apcon_req:
2+sizeof(esua_apcon) 4 1 $CODE_APCON_RESP 1 $esua_apcon sizeof(esua_apcon) pack tmp_data
generatedown P_EXPEDITED_DATA.REQ userdata $tmp_data
return

apcon_resp:
unbuffer tmp_data esua_apcon sizeof(tmp_data)
set locguide($esua_address) tmp_str
1+sizeof(tmp_str) $esua_address 1 $tmp_str sizeof(tmp_str) pack tmp_data
associate_ind_gs if $esua_apcon == "GS"
associate_ind_dt if $esua_apcon == "DT"

associate_ind_ap:
eventup A_ASSOCIATE.IND namei $tmp_data quality $esua_quality apcon $esua_apcon
return

associate_ind_gs:
; A_ASSOCIATE.IND.GS namei $tmp_data quality $esua_quality apcon $esua_apcon
out "A_ASSOCIATE.IND for GS - impossible, it must be on the Guide side"
return

associate_ind_dt:
; A_ASSOCIATE.IND.DT namei $tmp_data quality $esua_quality apcon $esua_apcon
unbuffer tmp_data dt_namei_addr 1 dt_namei sizeof(tmp_data)-1
eventup A_TRANSFER_INIT.IND namei $dt_namei quality $esua_quality
return
```

### P_GIVE_TOKENS.IND
```
;параметры:  token (число)
resend if ($token == 1) && ($dt_want_data_token == 1)
sync if ($token == 2) && ($dt_want_sync_token == 1)
resend:
A_DATA.REQ dummy_timer 0 settimer userdata $dt_userdata
set 0 dt_want_data_token
return
sync:
A_SYNC_MAJOR.REQ dummy_timer 0 settimer
set 0 dt_want_data_token
return
```

### P_P_EXCEPTION.IND
```
;параметры:  error (число)
resynchronize if $error == 3
sync if $error == 2
data:
set 1 dt_want_data_token
generatedown P_PLEASE_TOKENS.REQ token 1
return
sync:
set 1 dt_want_sync_token
generatedown P_PLEASE_TOKENS.REQ token 2
return
resynchronize:
generatedown P_RESYNCHRONIZE.REQ token 1
return
```

### P_PLEASE_TOKENS.IND
```
;параметры:  token (число)
out CurrentSystemName() " P_PLEASE_TOKENS.IND token " $token
generatedown P_GIVE_TOKENS.REQ token $token
```

### P_RESYNCHRONIZE.CONF
```
;параметры:  token (число)
out CurrentSystemName() " P_RESYNCHRONIZE.CONF token " $token
```

### P_RESYNCHRONIZE.IND
```
;параметры:  token (число)
out CurrentSystemName() " P_RESYNCHRONIZE.IND token " $token
generatedown P_RESYNCHRONIZE.RESP
```

### P_SYNC_MAJOR.CONF
```
;параметры:  нет
out CurrentSystemName() " P_SYNC_MAJOR.CONF"
```

### P_SYNC_MAJOR.IND
```
;параметры:  нет
out CurrentSystemName() " P_SYNC_MAJOR.IND"
generatedown P_SYNC_MAJOR.RESP
```

# Уровень представления

## P_INIT.REQ

```
CODE_SYNTAX_REQ declare integer
CODE_SYNTAX_RESP declare integer
CODE_EXPEDITED_DATA declare integer
CODE_P_P_ABORT declare integer

set 1 CODE_SYNTAX_REQ
set 2 CODE_SYNTAX_RESP
set 3 CODE_EXPEDITED_DATA
set 4 CODE_P_P_ABORT

TERMINAL declare string
set "!&" TERMINAL

code_pac declare integer
left_border declare string
right_border declare string
allowed_syntaxes declare buffer
current_syntax declare integer
syntax_pac declare integer
syntax_pac2 declare integer
current_buffer declare buffer
current_quality declare buffer
tmp declare string
wait_s_u_abort declare integer
sizes declare buffer
prefix declare buffer
output declare buffer
curr_len declare integer
count_len declare integer
loops declare integer
pos_1 declare integer
pos_2 declare integer
```

## P_CONNECT.REQ
Здесь устанавливается синтаксис 1 для того, чтобы до окончания установления соединения верхний уровень мог что-то отправлять через срочные данные. Получается такой синтаксис по умолчанию
```
;параметры:  address (число), quality (буфер), demand (буфер), context (буфер)
set 1 current_syntax
unbuffer context left_border 1 right_border 1 allowed_syntaxes sizeof(context)-2
generatedown S_CONNECT.REQ address $address quality $quality demand $demand
```

## P_CONNECT.RESP

```
;параметры:  address (число), quality (буфер), context (буфер)
unbuffer context left_border 1 right_border 1 allowed_syntaxes sizeof(context)-2
generatedown S_CONNECT.RESP address $address quality $quality
```

## P_DATA.REQ
```
;параметры:  userdata (буфер)
unbuffer userdata tmp sizeof(userdata)
unbuffer userdata code_pac 1 current_buffer sizeof(userdata)-1
out "P_DATA.REQ userdata " $userdata " (" $tmp ") current_syntax " $current_syntax " code_pac " $code_pac
struct if $code_pac == 1
no_struct:
out "P_DATA.REQ no_struct code_pac " $code_pac
sized_no_struct if $current_syntax == 1
sizeof(current_buffer)+sizeof(TERMINAL) $current_buffer sizeof(current_buffer) $TERMINAL sizeof(TERMINAL) pack output
goto send

sized_no_struct:
out "P_DATA.REQ sized_no_struct code_pac " $code_pac
sizeof(current_buffer)+1 sizeof(current_buffer) 1 $current_buffer sizeof(current_buffer) pack output
goto send

struct:
out "P_DATA.REQ struct code_pac " $code_pac
set 5 loops
0 pack sizes
unbuffer current_buffer tmp 1 current_buffer sizeof(current_buffer)-1
set 0 pos_1
set 0 pos_2
loop:
out "P_DATA.REQ loop code_pac " $code_pac
set $loops-1 loops
break_loop if $loops <= 0
unbuffer current_buffer tmp $pos_2 current_buffer sizeof(current_buffer)-$pos_2
unbuffer current_buffer tmp sizeof(current_buffer)
set pos($left_border,tmp) pos_1
set pos($right_border,tmp) pos_2
break_loop if ($pos_2 == 0) && ($pos_1 == 0)
;empty if $pos_2 <= $pos_1 + 1
unbuffer current_buffer tmp $pos_1 prefix $pos_2-$pos_1-1
goto append
;empty:
;0 pack prefix
;goto append

append:
out "P_DATA.REQ append tmp " $tmp " code_pac " $code_pac
sized_append if $current_syntax == 1
sizeof(prefix)+sizeof(TERMINAL) $prefix sizeof(prefix) $TERMINAL sizeof(TERMINAL) pack prefix
sizeof(output)+sizeof(prefix) $output sizeof(output) $prefix sizeof(prefix) pack output
goto loop

sized_append:
out "P_DATA.REQ sized_append code_pac " $code_pac
init_sizes if sizeof(sizes) == 0
sizeof(sizes)+1 $sizes sizeof(sizes) sizeof(prefix) 1 pack sizes
goto after_init_sizes
init_sizes:
unbuffer output code_pac 1 tmp sizeof(output)-1
out "P_DATA.REQ init_sizes code_pac " $code_pac
1 sizeof(prefix) 1 pack sizes
after_init_sizes:
out "P_DATA.REQ after_init_sizes code_pac " $code_pac
sizeof(prefix)+sizeof(output) $output sizeof(output) $prefix sizeof(prefix) pack output
goto loop

break_loop:
out "P_DATA.REQ break_loop code_pac " $code_pac
send if $current_syntax == 2
sizeof(output)+1+sizeof(sizes) sizeof(sizes) 1 $sizes sizeof(sizes) $output sizeof(output) pack output

send:
sizeof(output)+1 $code_pac 1 $output sizeof(output) pack output
unbuffer output code_pac 1 tmp sizeof(output)-1
out "P_DATA.REQ send output " $tmp " code_pac " $code_pac
generatedown S_DATA.REQ userdata $output
```

## P_EXPEDITED_DATA.REQ
```
;параметры:  userdata (буфер)
out "P_EXPEDITED_DATA.REQ userdata " $userdata
unbuffer userdata code_pac 1 current_buffer sizeof(userdata)-1
struct if $code_pac == 1
no_struct:
sized_no_struct if $current_syntax == 1
sizeof(current_buffer)+1+sizeof(TERMINAL) $code_pac 1 $current_buffer sizeof(current_buffer) $TERMINAL sizeof(TERMINAL) pack output
goto send

sized_no_struct:
sizeof(current_buffer)+2 $code_pac 1 sizeof(current_buffer) 1 $current_buffer sizeof(current_buffer) pack output
goto send

struct:
set 5 loops
0 pack sizes
0 pack output
unbuffer current_buffer tmp 1 current_buffer sizeof(current_buffer)-2
set 0 pos_1
set 0 pos_2
loop:
set $loops-1 loops
break_loop if $loops <= 0
unbuffer current_buffer tmp $pos_2 current_buffer sizeof(current_buffer)-$pos_2
unbuffer current_buffer tmp sizeof(current_buffer)
set pos($left_border,tmp) pos_1
set pos($right_border,tmp) pos_2break_loop if ($pos_2 == 0) && ($pos_1 == 0)
;empty if $pos_2 <= $pos_1 + 1
unbuffer current_buffer tmp $pos_1 prefix $pos_2-$pos_1-1
goto append
;empty:
;0 pack prefix
;goto append

append:
sized_append if $current_syntax == 1
sizeof(prefix)+sizeof(TERMINAL) $prefix sizeof(prefix) $TERMINAL sizeof(TERMINAL) pack prefix
set_output if sizeof(output) == 0
sizeof(output)+sizeof(prefix) $output sizeof(output) $prefix sizeof(prefix) pack output
goto loop

sized_append:
init_sizes if sizeof(sizes) == 0
sizeof(sizes)+1 $sizes sizeof(sizes) sizeof(prefix) 1 pack sizes
goto after_init_sizes
init_sizes:
1 sizeof(prefix) 1 pack sizes
after_init_sizes:
set_output if sizeof(output) == 0
sizeof(prefix)+sizeof(output) $output sizeof(output) $prefix sizeof(prefix) pack output
goto loop
set_output:
set $prefix output
goto loop

break_loop:
send if $current_syntax == 2
sizeof(output)+1+sizeof(sizes) sizeof(sizes) 1 $sizes sizeof(sizes) $output sizeof(output) pack output

send:
unbuffer output tmp sizeof(output)
out "P_EXPEDITED_DATA.IND send output " $tmp
sizeof(code_pac)+sizeof(output) $CODE_EXPEDITED_DATA sizeof(code_pac) $output sizeof(output) pack current_buffer
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
eventup P_P_ABORT.IND
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
set $quality current_quality
sizeof(code_pac)+sizeof(allowed_syntaxes) $CODE_SYNTAX_REQ sizeof(code_pac) $allowed_syntaxes sizeof(allowed_syntaxes) pack current_buffer
generatedown S_EXPEDITED_DATA.REQ userdata $current_buffer
```

## S_CONNECT.IND
Здесь устанавливается синтаксис 1 для того, чтобы до окончания установления соединения верхний уровень мог что-то отправлять через срочные данные. Получается такой синтаксис по умолчанию
```
;параметры:  address (число), quality (буфер), demand (буфер)
set 1 current_syntax
eventup P_CONNECT.IND address $address quality $quality demand $demand
```

## S_DATA.IND
```
;параметры:  userdata (буфер)
unbuffer userdata code_pac sizeof(code_pac) current_buffer sizeof(userdata)-1
out "S_DATA.IND userdata " $userdata " current_syntax " $current_syntax " code_pac " $code_pac
struct if $code_pac == 1
no_struct:
out "S_DATA.IND no_struct"
sized_no_struct if $current_syntax == 1
unbuffer current_buffer tmp sizeof(current_buffer)
out "S_DATA.IND no_struct current_buffer " $tmp
set pos($TERMINAL, tmp) pos_1
out "S_DATA.IND no_struct pos_1 " $pos_1
unbuffer current_buffer current_buffer $pos_1-1
sizeof(current_buffer)+1 $code_pac 1 $current_buffer sizeof(current_buffer) pack output
goto send

sized_no_struct:
out "S_DATA.IND sized_no_struct"
unbuffer current_buffer curr_len 1 current_buffer sizeof(current_buffer)-1
unbuffer current_buffer current_buffer $curr_len
sizeof(current_buffer)+1 $code_pac 1 $current_buffer sizeof(current_buffer) pack output
goto send

struct:
out "S_DATA.IND struct"
sized_struct if $current_syntax == 1
sizeof(left_border)+1 $code_pac 1 $left_border sizeof(left_border) pack output
terminated_loop:
out "S_DATA.IND terminated_loop"
unbuffer current_buffer tmp sizeof(current_buffer)
set pos($TERMINAL,tmp) pos_1
terminated_loop_break if $pos_1 == 0
unbuffer current_buffer prefix $pos_1-1 tmp 2 current_buffer sizeof(current_buffer)-$pos_1-1
sizeof(output)+sizeof(left_border)+sizeof(prefix)+sizeof(right_border) $output sizeof(output) $left_border sizeof(left_border) $prefix sizeof(prefix) $right_border sizeof(right_border) pack output
goto terminated_loop

terminated_loop_break:
out "S_DATA.IND terminated_loop_break"
sizeof(output)+sizeof(right_border) $output sizeof(output) $right_border sizeof(right_border) pack output
goto send

sized_struct:
out "S_DATA.IND sized_struct"
unbuffer current_buffer count_len 1 prefix sizeof(current_buffer)-1
unbuffer prefix sizes $count_len current_buffer sizeof(prefix)-$count_len
sizeof(left_border) $left_border sizeof(left_border) pack output
sized_loop:
out "S_DATA.IND sized_loop"
sized_loop_break if $count_len <= 0
unbuffer sizes curr_len 1 sizes sizeof(sizes)-1
set $count_len-1 count_len
unbuffer current_buffer prefix $curr_len current_buffer sizeof(current_buffer)-$curr_len
sizeof(output)+sizeof(left_border)+sizeof(prefix)+sizeof(right_border) $output sizeof(output) $left_border sizeof(left_border) $prefix sizeof(prefix) $right_border sizeof(right_border) pack output
goto sized_loop

sized_loop_break:
out "S_DATA.IND sized_loop_break"
sizeof(output)+sizeof(right_border) $output sizeof(output) $right_border sizeof(right_border) pack output
goto send

send:
unbuffer output tmp sizeof(output)
out "S_DATA.IND send output " $tmp
eventup P_DATA.IND userdata $output
return
```

## S_EXPEDITED_DATA.IND
```
;параметры:  userdata (буфер)
unbuffer userdata code_pac sizeof(code_pac) current_buffer sizeof(userdata)-sizeof(code_pac)
syntax_req if $code_pac == $CODE_SYNTAX_REQ
syntax_res if $code_pac == $CODE_SYNTAX_RESP
abort_ind if $code_pac == $CODE_P_P_ABORT
expedited_data if $code_pac == $CODE_EXPEDITED_DATA
return

syntax_req:
unbuffer current_buffer syntax_pac sizeof(syntax_pac) current_buffer sizeof(current_buffer)-sizeof(syntax_pac)
unbuffer allowed_syntaxes current_syntax sizeof(current_syntax) allowed_syntaxes sizeof(allowed_syntaxes)-sizeof(current_syntax)
send_syntax if $current_syntax == $syntax_pac
skip_second_syntax_pac if sizeof(current_buffer) == 0
unbuffer current_buffer syntax_pac2 sizeof(syntax_pac2)
send_syntax if $current_syntax == $syntax_pac2
skip_second_syntax_pac:
abort if sizeof(allowed_syntaxes) == 0
unbuffer allowed_syntaxes current_syntax sizeof(current_syntax)
send_syntax if $current_syntax == $syntax_pac
abort if sizeof(current_buffer) == 0
send_syntax if $current_syntax == $syntax_pac2
abort:
set 1 wait_s_u_abort
eventup P_P_ABORT.IND
sizeof(code_pac) $CODE_P_P_ABORT sizeof(code_pac) pack current_buffer
generatedown S_EXPEDITED_DATA.REQ userdata $current_buffer
return
send_syntax:
sizeof(code_pac)+sizeof(current_syntax) $CODE_SYNTAX_RESP sizeof(code_pac) $current_syntax sizeof(current_syntax) pack current_buffer
generatedown S_EXPEDITED_DATA.REQ userdata $current_buffer
return

syntax_res:
unbuffer current_buffer current_syntax sizeof(current_syntax)
3 $left_border 1 $right_border 1 $current_syntax sizeof(current_syntax) pack current_buffer
eventup P_CONNECT.CONF quality $current_quality context $current_buffer
set 0 wait_s_u_abort
return

abort_ind:
eventup P_P_ABORT.IND
return

expedited_data:
unbuffer current_buffer code_pac sizeof(code_pac) current_buffer sizeof(current_buffer)-1
struct if $code_pac == 1
no_struct:
out "S_EXPEDITED_DATA.IND no_struct"
sized_no_struct if $current_syntax == 1
;unbuffer current_buffer code_pac 1 current_buffer sizeof(current_buffer)-1
unbuffer current_buffer tmp sizeof(current_buffer)
out "S_EXPEDITED_DATA.IND no_struct current_buffer " $tmp
set pos($TERMINAL,tmp) pos_1
unbuffer current_buffer current_buffer $pos_1-1
sizeof(current_buffer)+1 $code_pac 1 $current_buffer sizeof(current_buffer) pack output
goto send

sized_no_struct:
out "S_EXPEDITED_DATA.IND sized_no_struct"
unbuffer current_buffer curr_len 1 code_pac 1 current_buffer sizeof(current_buffer)-2
unbuffer current_buffer current_buffer $curr_len
sizeof(current_buffer)+1 $code_pac 1 $current_buffer sizeof(current_buffer) pack output
goto send

struct:
out "S_EXPEDITED_DATA.IND struct"
sized_struct if $current_syntax == 1
sizeof(left_border)+1 $code_pac 1 $left_border sizeof(left_border) pack output
terminated_loop:
out "S_EXPEDITED_DATA.IND terminated_loop"
unbuffer current_buffer tmp sizeof(current_buffer)
set pos($TERMINAL,tmp) pos_1
terminated_loop_break if $pos_1 == 0
unbuffer current_buffer prefix $pos_1-1 tmp 2 current_buffer sizeof(current_buffer)-$pos_1-1
sizeof(output)+sizeof(left_border)+sizeof(prefix)+sizeof(right_border) $output sizeof(output) $left_border sizeof(left_border) $prefix sizeof(prefix) $right_border sizeof(right_border) pack output
goto terminated_loop

terminated_loop_break:
out "S_EXPEDITED_DATA.IND terminated_loop_break"
sizeof(output)+sizeof(right_border) $output sizeof(output) $right_border sizeof(right_border) pack output
goto send

sized_struct:
out "S_EXPEDITED_DATA.IND sized_struct"
unbuffer current_buffer count_len 1 prefix sizeof(current_buffer)-1
unbuffer prefix sizes $count_len current_buffer sizeof(prefix)-$count_len
sizeof(left_border) $left_border sizeof(left_border) pack output
sized_loop:
out "S_EXPEDITED_DATA.IND sized_loop"
sized_loop_break if $count_len <= 0
unbuffer sizes curr_len 1 sizes sizeof(sizes)-1
set $count_len-1 count_len
unbuffer current_buffer prefix $curr_len current_buffer sizeof(current_buffer)-$curr_len
sizeof(output)+sizeof(left_border)+sizeof(prefix)+sizeof(right_border) $output sizeof(output) $left_border sizeof(left_border) $prefix sizeof(prefix) $right_border sizeof(right_border) pack output
goto sized_loop

sized_loop_break:
out "S_EXPEDITED_DATA.IND sized_loop_break $output" $output
sizeof(output)+sizeof(right_border) $output sizeof(output) $right_border sizeof(right_border) pack output
goto send

send:
unbuffer output tmp sizeof(output)
out "S_EXPEDITED_DATA.IND send output " $tmp
eventup P_EXPEDITED_DATA.IND userdata $output
return
```

## S_GIVE_TOKENS.IND
```
;параметры:  token (число)
eventup P_GIVE_TOKENS.IND token $token
```

## S_P_EXCEPTION.IND
```
;параметры:  error (число)
eventup P_P_EXCEPTION.IND error $error
```

## S_PLEASE_TOKENS.IND
```
;параметры:  token (число)
eventup P_PLEASE_TOKENS.IND token $token
```

## S_RELEASE.CONF
```
;параметры:  нет
eventup P_RELEASE.CONF
```

## S_RELEASE.IND
```
;параметры:  нет
eventup P_RELEASE.IND
```

## S_RESYNCHRONIZE.CONF
```
;параметры:  token (число)
eventup P_RESYNCHRONIZE.CONF token $token
```

## S_RESYNCHRONIZE.IND
```
;параметры:  token (число)
eventup P_RESYNCHRONIZE.IND token $token
```

## S_SYNC_MAJOR.CONF
```
;параметры:  нет
eventup P_SYNC_MAJOR.CONF
```

## S_SYNC_MAJOR.IND
```
;параметры:  нет
eventup P_SYNC_MAJOR.IND
```

## S_U_ABORT.IND
```
;параметры:  нет
skip if $wait_s_u_abort == 1
eventup P_U_ABORT.IND
skip:
```

# Сеансовый уровень

Скопировано из avramenko

Сначала происходит установление T соединения, затем от клиента серверу передаются параметры качества quality (protect_flag и initial_sync_point) и начальная расстановка маркеров demand (initial_markers), обратно сервер передаёт свои параметры качества quality. initial_sync_point фактически не нужен.

initial_markers указывает, как изначально распределены маркеры данных и синхронизации. Чтобы передать обычные или срочные данные, требуется маркер данных. Чтобы выполнить основную синхронизацию, требуется маркер синхронизации.

## ФОРМАТ ПАКЕТА
<тип пакета|1 слово><данные>

и в зависимости от типа <данные> это

```
1:<quality_size| 1 слово><demand_size| 1 слово><quality| quality_size слов><demand | demand_size слов> - параметры запроса на соединение, причём quality_size = 2 и demand_size = 1
2:<quality_size| 1 слово><quality| quality_size слов> - параметры ответа на запрос на соединение, причём quality_size = 2
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
```

буфер quality имеет формат <protect_flag| 1 слово><initial_sync_point| 1 слово>

буфер demand имеет формат <marker| 1 слово>



## S_INIT.REQ
```
CODE_CONNECT_REQ declare integer
CODE_CONNECT_RESP declare integer
CODE_ABORT declare integer
CODE_DATA declare integer
CODE_EXPEDITED_DATA declare integer
CODE_RELEASE_REQ declare integer
CODE_RELEASE_RESP declare integer
CODE_SYNC_REQ declare integer
CODE_SYNC_RESP declare integer
CODE_RESYNC_REQ declare integer
CODE_RESYNC_RESP declare integer
CODE_PLEASE_TOKENS declare integer
CODE_GIVE_TOKENS declare integer
set 1 CODE_CONNECT_REQ
set 2 CODE_CONNECT_RESP
set 3 CODE_ABORT
set 4 CODE_DATA
set 5 CODE_EXPEDITED_DATA
set 6 CODE_RELEASE_REQ
set 7 CODE_RELEASE_RESP
set 8 CODE_SYNC_REQ
set 9 CODE_SYNC_RESP
set 10 CODE_RESYNC_REQ
set 11 CODE_RESYNC_RESP
set 12 CODE_PLEASE_TOKENS
set 13 CODE_GIVE_TOKENS

addr declare integer
code_pac declare integer
quality_size declare integer
demand_size declare integer
protect_flag declare integer
initial_sync_point declare integer
current_crc declare integer
current_calc_crc declare integer
current_token declare integer
has_data_marker declare integer
has_sync_marker declare integer
initial_markers declare integer

current_quality declare buffer
current_demand declare buffer
current_buffer declare buffer

total_queue declare queue

set 0 initial_markers
```

## S_CONNECT.REQ
```
;параметры:  address (число), quality (буфер), demand (буфер)
set $quality current_quality
set $demand current_demand
unbuffer demand initial_markers sizeof(initial_markers)
set ($initial_markers == 1) || ($initial_markers == 3) has_data_marker
set ($initial_markers == 1) || ($initial_markers == 4) has_sync_marker
generatedown T_CONNECT.REQ address $address
```

## S_CONNECT.RESP
```
;параметры:  address (число), quality (буфер)
set $quality current_quality
sizeof(code_pac)+sizeof(quality_size)+sizeof(current_quality) $CODE_CONNECT_RESP sizeof(code_pac) sizeof(current_quality) sizeof(quality_size) $current_quality sizeof(current_quality) pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
```

## S_DATA.REQ
Если отсутствует маркер данных, то это ошибка 1. При использовании защиты исполнение проходит через секцию protect
```
;параметры:   userdata (буфер)
error_1 if !!$has_data_marker

unbuffer current_quality protect_flag sizeof(protect_flag) initial_sync_point sizeof(initial_sync_point)
set $userdata current_buffer
send if !!$protect_flag

protect:
current_crc varcrc $current_buffer
sizeof(current_buffer)+sizeof(current_crc) $current_crc sizeof(current_crc) $current_buffer sizeof(current_buffer) pack current_buffer

send:
sizeof(current_buffer)+sizeof(code_pac) $CODE_DATA sizeof(code_pac) $current_buffer sizeof(current_buffer) pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
return

error_1:
eventup S_P_EXCEPTION.IND error 1
return
```

## S_EXPEDITED_DATA.REQ
При использовании защиты исполнение проходит через секцию protect
```
;параметры:   userdata (буфер)

unbuffer current_quality protect_flag sizeof(protect_flag) initial_sync_point sizeof(initial_sync_point)
set $userdata current_buffer

send if !!$protect_flag

protect:
current_crc varcrc $current_buffer
sizeof(current_buffer)+sizeof(current_crc)$current_crc sizeof(current_crc) $current_buffer sizeof(current_buffer) pack current_buffer

send:
sizeof(current_buffer)+sizeof(code_pac) $CODE_EXPEDITED_DATA sizeof(code_pac) $current_buffer sizeof(current_buffer) pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
```

## S_GIVE_TOKENS.REQ
Если передаётся маркер, которого нет у данной стороны, то нужно сгенерировать исключение о том, что обнаружен дубликат/потеря маркера (3). В противном случае нужно послать пакет с передачей маркера

```
;параметры:  token (число)
error_1 if (!!$has_data_marker) && ($token == 1)
error_2 if (!!$has_sync_marker) && ($token == 2)

sizeof(code_pac)+sizeof(token) $CODE_GIVE_TOKENS sizeof(code_pac) $token sizeof(token) pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer

set $has_data_marker && ($token != 1) has_data_marker
set $has_sync_marker && ($token != 2) has_sync_marker
return

error_1:
eventup S_P_EXCEPTION.IND error 1
return
error_2:
eventup S_P_EXCEPTION.IND error 2
return
```

## S_PLEASE_TOKENS.REQ
Если запрошен маркер, который уже есть, то нужно сгенерировать исключение о том, что обнаружен дубликат/потеря маркера (3). В противном случае нужно послать пакет с запросом маркера

```
;параметры:  token (число)
error_1 if $has_data_marker && ($token == 1)
error_2 if $has_sync_marker && ($token == 2)
sizeof(token)+sizeof(code_pac) $CODE_PLEASE_TOKENS sizeof(code_pac) $token sizeof(token) pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
return

error_1:
eventup S_P_EXCEPTION.IND error 1
return
error_2:
eventup S_P_EXCEPTION.IND error 2
return
```

## S_RELEASE.REQ
```
;параметры:  нет
sizeof(code_pac) $CODE_RELEASE_REQ sizeof(code_pac) pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
```

## S_RELEASE.RESP
```
;параметры:  нет

start:
end if qcount(total_queue) == 0
eventup S_DATA.IND userdata (dequeue(total_queue))
goto start
end:
sizeof(code_pac) $CODE_RELEASE_RESP sizeof(code_pac) pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
```

## S_RESYNCHRONIZE.REQ
```
;параметры:  token (число)

clearqueue total_queue
sizeof(token)+sizeof(code_pac) $CODE_RESYNC_REQ sizeof(code_pac) $token sizeof(token) pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
```

## S_RESYNCHRONIZE.RESP
```
;параметры:  token (число)

clearqueue total_queue
sizeof(code_pac)+sizeof(token) $CODE_RESYNC_RESP sizeof(code_pac) $token sizeof(token) pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
; token содержит маркеры другой стороны, так что тут обратный предикат
set ($token != 1) && ($token != 3) has_data_marker
set ($token != 2) && ($token != 3) has_sync_marker
```

## S_SYNC_MAJOR.REQ
Если отсутствует маркер основной синхронизации, то это ошибка 2
```
;параметры:  нет
error_2 if !!$has_sync_marker
sizeof(code_pac) $CODE_SYNC_REQ sizeof(code_pac) pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
return

error_2:
eventup S_P_EXCEPTION.IND error 2
return
```

## S_SYNC_MAJOR.RESP
```
;параметры:  нет

start:
end if qcount(total_queue) == 0
eventup S_DATA.IND userdata (dequeue(total_queue))
goto start
end:
sizeof(code_pac) $CODE_SYNC_RESP sizeof(code_pac) pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
```

## S_U_ABORT.REQ
```
;параметры:  нет
sizeof(code_pac) $CODE_ABORT sizeof(code_pac) pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
```

## T_CONNECT.CONF
```
;параметры:  address (число)

set $address addr
sizeof(code_pac)+sizeof(quality_size)+sizeof(demand_size)+sizeof(current_quality)+sizeof(current_demand) $CODE_CONNECT_REQ sizeof(code_pac) sizeof(current_quality) sizeof(quality_size) sizeof(current_demand) sizeof(demand_size) $current_quality sizeof(current_quality) $current_demand sizeof(current_demand) pack current_buffer
generatedown T_DATA.REQ userdata $current_buffer
```

## T_CONNECT.IND
```
;параметры:  address (число)

set $address addr
generatedown T_CONNECT.RESP address $address
```

## T_DATA.IND
Обработка всех возможных типов пакетов

Нужно сгенерировать исключение о том, что обнаружен дубликат/потеря маркера (3) в следующих случаях:

- если от другой стороны передаётся маркер, который есть у данной стороны
- если другой стороной запрошен маркер, которого нет у данной стороны
- если от другой стороны передаются данные, когда маркер данных у данной стороны
- если другая сторона запросила основную синхронизация, когда маркер синхронизации у данной стороны
```
;параметры:  userdata (буфер)

unbuffer userdata code_pac sizeof(code_pac) current_buffer sizeof(userdata)-sizeof(code_pac)
connect_req if $code_pac == $CODE_CONNECT_REQ
connect_res if $code_pac == $CODE_CONNECT_RESP
disconnect_req if $code_pac == $CODE_ABORT
data_req if $code_pac == $CODE_DATA
exp_data_req if $code_pac == $CODE_EXPEDITED_DATA
release_req if $code_pac == $CODE_RELEASE_REQ
release_res if $code_pac == $CODE_RELEASE_RESP
sync_req if $code_pac == $CODE_SYNC_REQ
sync_res if $code_pac == $CODE_SYNC_RESP
resync_req if $code_pac == $CODE_RESYNC_REQ
resync_res if $code_pac == $CODE_RESYNC_RESP
token_req if $code_pac == $CODE_PLEASE_TOKENS
token_res if $code_pac == $CODE_GIVE_TOKENS
return


connect_req:
unbuffer current_buffer quality_size sizeof(quality_size) demand_size sizeof(demand_size) current_buffer sizeof(current_buffer)-sizeof(quality_size)-sizeof(demand_size)
unbuffer current_buffer current_quality $quality_size current_demand $demand_size
unbuffer current_demand initial_markers sizeof(initial_markers)
set ($initial_markers == 2) || ($initial_markers == 4) has_data_marker
set ($initial_markers == 2) || ($initial_markers == 3) has_sync_marker
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
error_3 if $has_data_marker
unbuffer current_quality protect_flag sizeof(protect_flag) initial_sync_point sizeof(initial_sync_point)
add_to_queue if !!$protect_flag

check_protected_data:
unbuffer current_buffer current_crc sizeof(current_crc) current_buffer sizeof(current_buffer)-sizeof(current_crc)
current_calc_crc varcrc $current_buffer
skip_broken if $current_crc != $current_calc_crc

add_to_queue:
queue $current_buffer total_queue
return


exp_data_req:
unbuffer current_quality protect_flag sizeof(protect_flag) initial_sync_point sizeof(initial_sync_point)
send if !!$protect_flag

check_protected_expedited_data:
unbuffer current_buffer current_crc sizeof(current_crc) current_buffer sizeof(current_buffer)-sizeof(current_crc)
current_calc_crc varcrc $current_buffer
skip_broken if $current_crc != $current_calc_crc

send:
eventup S_EXPEDITED_DATA.IND userdata $current_buffer
return

skip_broken:
out "T_DATA.IND skip_broken"
return

release_req:
eventup S_RELEASE.IND
return

release_res:
release_end if qcount(total_queue) == 0
eventup S_DATA.IND userdata (dequeue(total_queue))
release_end:
generatedown T_DISCONNECT.REQ address $addr
eventup S_RELEASE.CONF
return


sync_req:
error_3 if $has_sync_marker
eventup S_SYNC_MAJOR.IND
return

sync_res:
sync_res_end if qcount(total_queue) == 0
eventup S_DATA.IND userdata (dequeue(total_queue))
goto sync_res
sync_res_end:
eventup S_SYNC_MAJOR.CONF
return

resync_req:
unbuffer current_buffer current_token sizeof(current_token)
eventup S_RESYNCHRONIZE.IND token $current_token
return


resync_res:
unbuffer current_buffer current_token sizeof(current_token)
eventup S_RESYNCHRONIZE.CONF token $current_token
set ($current_token == 1) || ($current_token == 3) has_data_marker
set ($current_token == 2) || ($current_token == 3) has_sync_marker
return

token_req:
unbuffer current_buffer current_token sizeof(current_token)
error_1 if !!$has_data_marker && ($current_token == 1)
error_2 if !!$has_sync_marker && ($current_token == 2)
eventup S_PLEASE_TOKENS.IND token $current_token
return


token_res:
unbuffer current_buffer current_token sizeof(current_token)
error_1 if $has_data_marker && ($current_token == 1)
error_2 if $has_sync_marker && ($current_token == 2)
eventup S_GIVE_TOKENS.IND token $current_token
set $has_data_marker || ($current_token == 1) has_data_marker
set $has_sync_marker || ($current_token == 2) has_sync_marker
return

error_1:
out "T_DATA.IND error_1 code_pac " $code_pac " has_data_marker " $has_data_marker " has_sync_marker " $has_sync_marker " current_token " $current_token
eventup S_P_EXCEPTION.IND error 1
return

error_2:
out "T_DATA.IND error_2 code_pac " $code_pac " has_data_marker " $has_data_marker " has_sync_marker " $has_sync_marker " current_token " $current_token
eventup S_P_EXCEPTION.IND error 2
return

error_3:
out "T_DATA.IND error_3 code_pac " $code_pac " has_data_marker " $has_data_marker " has_sync_marker " $has_sync_marker " current_token " $current_token
eventup S_P_EXCEPTION.IND error 3
return
```

## T_DISCONNECT.IND
```
;параметры:  нет
```

# Транспортный уровень

## ФОРМАТ СООБЩЕНИЙ

```
Подтверждение: <контрольная сумма><тип 1><номер>
Завершение от сервера клиенту: <контрольная сумма><тип 2><номер>
Данные: <контрольная сумма><тип 3><номер><данные>
```

## ПЕРЕХОДЫ СОСТОЯНИЯ 

```
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
```

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
Сброс счётчиков нужен для 4 лабы, где будет добавлен третий участник Guide
```
;параметры:  address (число)
skip if $connstate == "6"
;connstate == 2
out CurrentSystemName() + " " + $connstate + " 4 N_CONNECT.CONF -> eventup T_CONNECT.CONF"
set "4" connstate
set 0 num_req
set 0 num_ind
set 0 num_ack
untimer $repeat_timer
eventup T_CONNECT.CONF address $address
return
skip:
out CurrentSystemName() + " " + $connstate + " 4 N_CONNECT.CONF -> (do nothing)"
set "4" connstate
```

## N_CONNECT.IND
Сброс счётчиков нужен для 4 лабы, где будет добавлен третий участник Guide
```
;параметры:  address (число)
resp if $connstate == "7"
; connstate == 0
out CurrentSystemName() + " " + $connstate + " 1 N_CONNECT.IND -> eventup T_CONNECT.IND"
set "1" connstate
set $address addr
set 0 num_req
set 0 num_ind
set 0 num_ack
untimer $repeat_timer
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
stop if ($connstate == "4") && ($code_pac == 2)
skip if $code_pac == 2
set $num_pac+1 num_ind
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
skip if $connstate == "0"
skip if $connstate == "1"
reconnect if $connstate == "2"
server_disconnect if $connstate == "3"
reconnect if $connstate == "4"
stop_repeat_stop if $connstate == "5"
skip if $connstate == "6"
skip if $connstate == "7"
return
;; constate == "2"
;out CurrentSystemName() + " " + $connstate + " 0 N_DISCONNECT.IND -> eventup T_DISCONNECT.IND"
;set "0" connstate
;eventup T_DISCONNECT.IND
;return
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
T_REPEAT repeat_timer 0 settimer cur_pac $pac cur_num $num_req retry_num 15
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
T_REPEAT repeat_timer 0 settimer cur_pac $pac cur_num $num_req retry_num 15
;set $num_req+1 num_req
return
skip:
set "0" connstate
out CurrentSystemName() + " " + $connstate + " 0 T_DISCONNECT.REQ -> (skip)"
```

## T_REPEAT
```
;параметры: cur_pac(buffer), cur_num(integer), retry_num(integer)
skip if ($cur_num < $num_ack) || ($retry_num <= 0)
out CurrentSystemName() + " " + $connstate + " " + $connstate + " T_REPEAT -> generatedown N_DATA.REQ, settimer T_REPEAT 41"
generatedown N_DATA.REQ userdata $cur_pac
T_REPEAT repeat_timer ($const_MAX_TRANSFER_DELAY*2+1) settimer cur_pac $cur_pac cur_num $cur_num retry_num $retry_num-1
return
skip:
out CurrentSystemName() + " " + $connstate + " " + $connstate + " T_REPEAT -> (skip)"
```

## T_SERVER_DISCONNECT
```
;параметры:  нет
; connstate == 7
out CurrentSystemName() + " " + $connstate + " 0 T_SERVER_DISCONNECT -> eventup T_DISCONNECT.IND"
set "0" connstate
eventup T_DISCONNECT.IND
```