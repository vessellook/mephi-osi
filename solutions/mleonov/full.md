# Общее

Синтаксис STX6.

Год создания 2024.

# Прикладной уровень

## A_ASSOCIATE.CONF
```
;параметры: context (буфер), quality (буфер), demand (буфер)

untimer $ass_conf_timer 


$target_apcon == "GS" if gs
$target_apcon == "DT" if dt

gs: 

out CurrentSystemName() " A_ASS.CONF"

data bufferit sizeof(target_namer)+1 3 1 $target_namer sizeof(target_namer)
out "gd P_DATA.REQ " $target_address " NAME " $target_namer 

P_DATA.REQ eventdown userdata $data

SYNC_TIMER timer sync_timer 5

return 

dt: 

A_TRANSFER_INIT.CONF generateup context $context quality  $quality 

return
```
## A_ASSOCIATE.IND
```
;параметры: namei (буфер), quality (буфер), apcon (строка)

untimer $ass_ind_timer

A_TRANSFER_INIT.IND generateup namei $target_namei quality $quality 
```
## A_ASSOCIATE.REQ
```
;параметры: namer (буфер), namei (буфер), quality (буфер), demand (буфер), context (буфер), apcon (строка)

untimer $ass_req_timer 

$apcon varset target_apcon
out CurrentSystemName() " TRY TO CONNECT " $target_address
P_CONNECT.REQ eventdown address $target_address quality $quality demand  $demand context $context 
```
## A_ASSOCIATE.RESP
```
;параметры: namei (буфер), context (буфер), quality (буфер), apcon (строка)

out CurrentSystemName() " A_ASS,RESP " $apcon
$apcon varset target_apcon
untimer $ass_resp_timer
P_CONNECT.RESP eventdown address $target_address quality $quality context $context 
```
## A_DATA.REQ
```
;параметры: userdata(буфер)

out CurrentSystemName() " A_DATA.REQ "

queue data_q $userdata

$is_data_token  == 1 if skip

P_PLEASE_TOKENS.REQ eventdown token 1 
1 varset is_data_token 

return

skip:

```
## A_INIT.REQ
```


target_namer declare string 
target_namei declare string 
target_context declare buffer 
target_quality declare buffer 

resolve_req_timer declare integer
resolve_ind_timer declare integer

ass_req_timer declare integer
ass_conf_timer declare integer
sync_timer declare integer

ass_ind_timer declare integer
ass_resp_timer declare integer

release_req_timer declare integer
release_conf_timer declare integer

release_ind_timer declare integer
release_resp_timer declare integer

data_type declare integer

resolve_id declare integer
start_time declare integer
end_time declare integer
change_from declare string
change_to declare string

target_address declare integer
namei_address declare string

target_apcon declare string

data declare buffer
data_q declare queue

guide_buff declare buffer
target_demand declare buffer

namei_buff declare buffer
namer_buff declare buffer

is_data_token declare integer
is_first_exception declare integer

```
## A_RELEASE.CONF
```
;параметры: apcon (строка)

out CurrentSystemName() " A_RELEASE.CONF " $apcon

untimer $release_conf_timer

$apcon == "GS" if gs 
$apcon == "DT" if dt 

gs: 

data bufferit 4 $resolve_id 1 $target_address 1 $change_from 1 $change_to 1

A_RESOLVE.IND timer resolve_ind_timer 0 address $data 

return 


dt: 
A_TERMINATE.CONF generateup address $target_address
return
```
## A_RELEASE.IND
```
;параметры: apcon (строка)

untimer $release_ind_timer 

0 varset release_ind_timer  

A_TERMINATE.IND generateup
```
## A_RELEASE.REQ
```
;параметры: apcon (строка)

untimer $release_req_timer 

0 varset release_req_timer 

$apcon varset target_apcon
P_RELEASE.REQ eventdown
```
## A_RELEASE.RESP
```
;параметры: apcon (строка)

untimer $release_resp_timer

0 varset release_resp_timer

P_RELEASE.RESP eventdown
```
## A_RESOLVE.IND
```


untimer $resolve_ind_timer

0 varset resolve_ind_timer

unbufferit address resolve_id  1 target_address 1 change_from 1 change_to 1 

namer_buff bufferit sizeof(target_namer)+1 $target_namer sizeof(target_namer) $target_address 1 

out " A_RESOLVE.IND " $resolve_id " ADRESS " $target_address

A_ASSOCIATE.REQ timer ass_req_timer 0 namer $namer_buff namei $namei_buff quality $target_quality demand $target_demand context $target_context apcon "DT" 

```
## A_RESOLVE.REQ
```
;параметры: name (строка)

out "A_RESOLVE.REQ" 

untimer $resolve_req_timer 

locguide($name) varset data 

unbufferit data resolve_id  1 target_address 1 start_time 1 end_time 1 change_from 1 change_to 1 


$resolve_id == 1 if type_0
$resolve_id == 2 if type_1
$resolve_id == 3 if type_3
$resolve_id == 4 if type_4


type_0: 
P_CONNECT.REQ eventdown address $target_address quality $target_quality context $target_context


type_3: 

locguide("Guide") varset data 
unbufferit data resolve_id  1 target_address 1 start_time 1 end_time 1 change_from 1 change_to 1 
guide_buff bufferit 6 "Guide" 5 $target_address 1 

locguide($target_namei) varset data 
unbufferit data resolve_id  1 namei_address 1 start_time 1 end_time 1 change_from 1 change_to 1 
namei_buff bufferit sizeof(target_namei) + 1 $target_namei sizeof(target_namei) $namei_address 1 

target_demand bufferit 1 1 1


A_ASSOCIATE.REQ timer ass_req_timer 0 namer $guide_buff namei $namei_buff quality $target_quality demand $target_demand context $target_context apcon "GS" 
return
```
## A_TERMINATE.CONF
```


out CurrentSystemName() " A_TERMINATE.CONF"
```
## A_TERMINATE.REQ
```
;параметры: нет


A_RELEASE.REQ timer release_req_timer 0 apcon $target_apcon
```
## A_TERMINATE.RESP
```


out CurrentSystemName() " A_TERMINATE.RESP "

A_RELEASE.RESP timer release_resp_timer 0 apcon "DT"
```
## A_TRANSFER_INIT.REQ
```
;параметры: namer (строка), namei (строка), context (буфер), quality (буфер)

$namer varset target_namer
$namei varset target_namei
$context varset target_context
$quality varset target_quality

A_RESOLVE.REQ timer resolve_req_timer 0 name $namer
```
## A_TRANSFER_INIT.RESP
```
;параметры: namei (строка), context (буфер), quality (буфер)

A_ASSOCIATE.RESP timer ass_resp_timer 0 namei $namei_buff context $context quality $quality apcon "DT"
```
## P_CONNECT.CONF
```
;параметры:  quality (буфер), context (буфер)

A_ASSOCIATE.CONF  timer ass_conf_timer 0  context $target_context quality $target_quality demand $target_demand 
```
## P_CONNECT.IND
```
;параметры:  address (число), quality (буфер), demand (буфер)

out CurrentSystemName() " P_CONNECT.IND"

$address varset target_address 

locguide($address) varset target_namei

namei_buff bufferit sizeof(target_namei)+1 $address 1 $target_namei sizeof(target_namei)

A_ASSOCIATE.IND timer ass_ind_timer 1 namei $namei_buff quality $quality demand $demand 
```
## P_DATA.IND
```
;параметры:  userdata (буфер)

out CurrentSystemName() " P_DATA.IND " $target_apcon

$target_apcon == "GS" if gs 

$target_apcon == "DT" if dt 

gs: 

unbufferit userdata data_type 1 resolve_id  1 target_address 1 start_time 1 end_time 1 change_from 1 change_to 1 

out "RESOLVE TYPE " $data_type " " $resolve_id " " $target_address " " $start_time " " $end_time " " $change_from " " $change_to

$resolve_id == 1 if wait_class
$resolve_id == 2 if wait_end
$resolve_id == 3 if skip
$resolve_id == 4 if skip 

out CurrentSystemName() " GOOD DATA IND TYPE " $resolve_id " ADDRESS "  $target_address

A_RELEASE.REQ timer release_req_timer 0 apcon "GS"

return

wait_class:
out CurrentSystemName() "  WAIT"
A_RESOLVE.REQ timer release_req_timer $start_time+10 name "SystemB"

return

wait_end:
out CurrentSystemName() "  WAIT"
A_RESOLVE.REQ timer release_req_timer $start_time+($end_time-$start_time-10) name "SystemB"

return

skip: 
out CurrentSystemName() " SKIP " $resolve_id
return

dt: 
A_DATA.IND generateup userdata $userdata
```
## P_GIVE_TOKENS.IND
```
;параметры:  token (число)

out CurrentSystemName() " P_GIVE_TOKENS.IND "

$token == 1 if send_data 
P_SYNC_MAJOR.REQ eventdown 

return

send_data: 

qcount(data_q) == 0 if end
P_DATA.REQ eventdown userdata dequeue(data_q)
goto send_data 

end: 

0 varset is_data_token
P_PLEASE_TOKENS.REQ eventdown token 2

return
```
## P_P_EXCEPTION.IND
```
;параметры:  error (число)

out CurrentSystemName() " P_P_EXCEPTION.IND " $error

$error == 3 if resync
$error != 3 if skip

resync:

$is_first_exception == 0 if  skip
1 varset is_first_exception
qcount(data_q) == 0 if end
qcount(data_q) > 0 if send_data

return

send_data: 
qcount(data_q) == 0 if end
P_DATA.REQ eventdown userdata dequeue(data_q)
goto send_data 

end: 
0 varset is_first_exception
P_SYNC_MAJOR.REQ eventdown

return

skip:
```
## P_PLEASE_TOKENS.IND
```
;параметры:  token (число)

P_GIVE_TOKENS.REQ eventdown token $token 
```
## P_RELEASE.CONF
```
;параметры:  нет

;A_RELEASE.CONF  timer release_conf_timer 0 apcon "GS"

A_RELEASE.CONF  timer release_conf_timer 0 apcon $target_apcon

```
## P_RELEASE.IND
```
;параметры:  нет

A_RELEASE.IND timer release_ind_timer  0 apcon "DT"
```
## P_RESYNCHRONIZE.CONF
```
;параметры:  token (число)
```
## P_RESYNCHRONIZE.IND
```
;параметры:  token (число)

out CurrentSystemName() " P_RESYNC.IND "
```
## P_SYNC_MAJOR.CONF
```
;параметры:  нет
```
## P_SYNC_MAJOR.IND
```
;параметры:  нет

P_SYNC_MAJOR.RESP eventdown
```
## P_U_ABORT.IND
```
;параметры:  нет

;A_U_ABORT.IND generateup
```
## SYNC_TIMER
```
P_SYNC_MAJOR.REQ eventdown
```

# Уровень представления

## P_CONNECT.REQ
```
;параметры:  address (число), quality (буфер), demand (буфер), context (буфер)

out CurrentSystemName() " P_CONNECT " $address

$address varset target_address 

unbufferit context open 1 close 1 data sizeof(context) - 2

sizeof(data) == 2 if two

unbufferit data target_syntax 1
S_CONNECT.REQ eventdown  address $address quality $quality demand $demand 
return

two: 
3 varset target_syntax
S_CONNECT.REQ eventdown  address $address quality $quality demand $demand 

```
## P_CONNECT.RESP
```
;параметры:  address (число), quality (буфер), context (буфер)

$address varset target_address 

unbufferit context open 1 close 1 data sizeof(context) - 2

sizeof(data) == 2 if two

unbufferit data target_syntax 1
S_CONNECT.RESP eventdown  address $address quality $quality
return

two: 
3 varset target_syntax
S_CONNECT.RESP eventdown  address $address quality $quality


```
## P_DATA.REQ
```
;параметры:  userdata (буфер)

unbufferit userdata data_type 1 data_string sizeof(userdata)-1

out CurrentSystemName() " P_DATA.REQ " $data_type

$data_type == 1 if struct
$data_type == 2 if numb
$data_type == 3 if string
$data_type == 4 if buff


struct: 
copy(data_string, 2, sizeof(data_string) - 2) varset data_string 

copy(data_string, pos($open, data_string) + 1, pos($close, data_string) - 2) varset first 

copy(data_string, sizeof(first) + 3, sizeof(data_string) - sizeof(first) - 2) varset data_string 

copy(data_string, pos($open, data_string) + 1, pos($close, data_string) - 2) varset second 

copy(data_string, sizeof(second) + 3, sizeof(data_string) - sizeof(second) - 2) varset data_string 

copy(data_string, pos($open, data_string) + 1, pos($close, data_string) - 2) varset third 

copy(data_string, sizeof(third) + 3, sizeof(data_string) - sizeof(third) - 2) varset data_string 

copy(data_string, pos($open, data_string) + 1, pos($close, data_string) - 2) varset fourth 

;copy(data_string, sizeof(fourth ) + 3, sizeof(data_string) - sizeof(fourth ) - 2) varset data_string 


$final_syntax == 1 if struct_len
$final_syntax == 2 if struct_end

struct_len:
data bufferit sizeof(first)+2 10 1 sizeof(first) 1 $first sizeof(first)
data bufferit sizeof(data)+sizeof(second)+2 $data sizeof(data) 20 1 sizeof(second) 1 $second sizeof(second) 
data bufferit sizeof(data)+sizeof(third)+2 $data sizeof(data) 30 1 sizeof(third) 1 $third sizeof(third) 
data bufferit sizeof(data)+sizeof(fourth)+2 $data sizeof(data) 40 1 sizeof(fourth) 1 $fourth sizeof(fourth) 
data bufferit sizeof(data)+2 1 1 sizeof(data) 1 $data sizeof(data)
goto send

struct_end:
data bufferit sizeof(first)+5 10 1 $first sizeof(first) "####" 4 
data bufferit sizeof(data)+sizeof(second)+5 $data sizeof(data) 20 1 $second sizeof(second) "####" 4 
data bufferit sizeof(data)+sizeof(third)+5 $data sizeof(data) 30 1 $third sizeof(third) "####" 4 
data bufferit sizeof(data)+sizeof(fourth)+5 $data sizeof(data) 40 1 $fourth sizeof(fourth) "####" 4 
data bufferit sizeof(data)+5 1 1 $data sizeof(data) "####" 4 
goto send


numb: 
$final_syntax == 1 if numb_len
$final_syntax == 2 if numb_end

numb_len:
unbufferit userdata data_type 1 tmp_data sizeof(userdata)-1
data bufferit  3 $data_type 1 1 1 $tmp_data 1
goto send

numb_end:
data bufferit  6 $userdata 2 "####" 4 
goto send


string: 
$final_syntax == 1 if string_len
$final_syntax == 2 if string_end

string_len:
unbufferit userdata data_type 1 tmp_data sizeof(userdata)-1
data bufferit  sizeof(tmp_data)+2  $data_type 1 sizeof(tmp_data) 1 $tmp_data sizeof(tmp_data)
goto send

string_end:
data bufferit  sizeof(userdata) + 4 $userdata sizeof(userdata) "####" 4 
goto send


buff: 
$final_syntax == 1 if buff_len
$final_syntax == 2 if buff_end

buff_len:
unbufferit userdata data_type 1 tmp_data sizeof(userdata)-1
data bufferit  sizeof(tmp_data)+2  $data_type 1 sizeof(tmp_data) 1 $tmp_data sizeof(tmp_data)
goto send

buff_end:
data bufferit  sizeof(userdata) + 4 $userdata sizeof(userdata) "####" 4 
goto send

send: 
S_DATA.REQ eventdown userdata $data


```
## P_EXPEDITED_DATA.REQ
```
;параметры:  userdata (буфер)

unbufferit userdata data_type 1 data_string sizeof(userdata)-1

$data_type == 1 if struct
$data_type == 2 if numb
$data_type == 3 if string
$data_type == 4 if buff


struct: 
copy(data_string, 2, sizeof(data_string) - 2) varset data_string 
copy(data_string, pos($open, data_string) + 1, pos($close, data_string) - 2) varset first 
copy(data_string, sizeof(first) + 3, sizeof(data_string) - sizeof(first) - 2) varset data_string 
copy(data_string, pos($open, data_string) + 1, pos($close, data_string) - 2) varset second 
copy(data_string, sizeof(second) + 3, sizeof(data_string) - sizeof(second) - 2) varset data_string 
copy(data_string, pos($open, data_string) + 1, pos($close, data_string) - 2) varset third 
copy(data_string, sizeof(third) + 3, sizeof(data_string) - sizeof(third) - 2) varset data_string 
copy(data_string, pos($open, data_string) + 1, pos($close, data_string) - 2) varset fourth

$final_syntax == 1 if struct_len
$final_syntax == 2 if struct_end

struct_len:
data bufferit sizeof(first)+2 10 1 sizeof(first) 1 $first sizeof(first)
data bufferit sizeof(data)+sizeof(second)+2 $data sizeof(data) 20 1 sizeof(second) 1 $second sizeof(second) 
data bufferit sizeof(data)+sizeof(third)+2 $data sizeof(data) 30 1 sizeof(third) 1 $third sizeof(third) 
data bufferit sizeof(data)+sizeof(fourth)+2 $data sizeof(data) 40 1 sizeof(fourth) 1 $fourth sizeof(fourth) 
data bufferit sizeof(data)+2 1 1 sizeof(data) 1 $data sizeof(data)
goto send

struct_end:
data bufferit sizeof(first)+5 10 1 $first sizeof(first) "####" 4 
data bufferit sizeof(data)+sizeof(second)+5 $data sizeof(data) 20 1 $second sizeof(second) "####" 4 
data bufferit sizeof(data)+sizeof(third)+5 $data sizeof(data) 30 1 $third sizeof(third) "####" 4 
data bufferit sizeof(data)+sizeof(fourth)+5 $data sizeof(data) 40 1 $fourth sizeof(fourth) "####" 4 
data bufferit sizeof(data)+5 1 1 $data sizeof(data) "####" 4 
goto send


numb: 
$final_syntax == 1 if numb_len
$final_syntax == 2 if numb_end

numb_len:
unbufferit userdata data_type 1 tmp_data sizeof(userdata)-1
data bufferit  3 $data_type 1 1 1 $tmp_data 1
goto send

numb_end:
data bufferit  6 $userdata 2 "####" 4 
goto send


string: 
$final_syntax == 1 if string_len
$final_syntax == 2 if string_end

string_len:
unbufferit userdata data_type 1 tmp_data sizeof(userdata)-1
data bufferit  sizeof(tmp_data)+2  $data_type 1 sizeof(tmp_data) 1 $tmp_data sizeof(tmp_data)
goto send

string_end:
data bufferit  sizeof(userdata) + 4 $userdata sizeof(userdata) "####" 4 
goto send


buff: 
$final_syntax == 1 if buff_len
$final_syntax == 2 if buff_end

buff_len:
unbufferit userdata data_type 1 tmp_data sizeof(userdata)-1
data bufferit  sizeof(tmp_data)+2  $data_type 1 sizeof(tmp_data) 1 $tmp_data sizeof(tmp_data)
goto send

buff_end:
data bufferit  sizeof(userdata) + 4 $userdata sizeof(userdata) "####" 4 
goto send

send: 
S_EXPEDITED_DATA.REQ eventdown userdata $data


```
## P_GIVE_TOKENS.REQ
```
;параметры:  token (число)
S_GIVE_TOKENS.REQ eventdown token $token
```
## P_INIT.REQ
```


target_address declare integer 
target_syntax declare integer
in_syntax declare integer
final_syntax declare integer


open declare string 
close declare string

data declare buffer
data_id declare integer

data_type declare integer

len declare integer

data_string declare string
test declare string
first declare string
second declare string
third declare string
fourth declare string

tmp_data declare buffer

target_quality declare buffer
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
## P_RESYNCHRONIZE.REQ
```
;параметры:  token (число)

S_RESYNCHRONIZE.REQ eventdown token $token
```
## P_RESYNCHRONIZE.RESP
```
;параметры:  token (число)

S_RESYNCHRONIZE.RESP eventdown token $token
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

$quality varset target_quality 

data bufferit  2 10 1 $target_syntax 1 
S_EXPEDITED_DATA.REQ eventdown userdata $data
```
## S_CONNECT.IND
```
;параметры:  address (число), quality (буфер), demand (буфер)
out CurrentSystemName() " S_CONNECT.IND "
P_CONNECT.IND generateup address $address quality $quality demand $demand 
```
## S_DATA.IND
```
;параметры:  userdata (буфер)

unbufferit userdata data_type 1 data_string sizeof(userdata)-1

out CurrentSystemName() " S_DATA.IND " $data_type

$data_type == 1 if struct
$data_type == 2 if numb
$data_type == 3 if string
$data_type == 4 if buff

struct: 

$final_syntax == 1 if struct_len
$final_syntax == 2 if struct_end

struct_len:
unbufferit userdata data_type 1 tmp_data 2 len 1 data sizeof(userdata) - 4
unbufferit userdata first $len tmp_data 1 len 1 data sizeof(data) - sizeof(first) - 2
unbufferit userdata second $len tmp_data 1 len 1 data sizeof(data) - sizeof(second) - 2
unbufferit userdata third $len tmp_data 1 len 1 data sizeof(data) - sizeof(third) - 2
unbufferit userdata fourth $len tmp_data sizeof(data) - sizeof(fourth)

goto construct

struct_end:
copy(data_string, 2, pos("####", data_string) - 2) varset first 
copy(data_string, pos("####", data_string) + 4, sizeof(data_string) - sizeof(first) - 5) varset data_string
copy(data_string, 2, pos("####", data_string) - 2) varset second 
copy(data_string, pos("####", data_string) + 4, sizeof(data_string) - sizeof(second) - 5) varset data_string
copy(data_string, 2, pos("####", data_string) - 2) varset third
copy(data_string, pos("####", data_string) + 4, sizeof(data_string) - sizeof(third) - 5) varset data_string
copy(data_string, 2, pos("####", data_string) - 2) varset fourth

goto construct

construct:
data bufferit sizeof(first)+2 $open 1 $first sizeof(first) $close 1
data bufferit sizeof(data)+sizeof(second)+2 $data sizeof(data) $open 1 $second sizeof(second) $close 1
data bufferit sizeof(data)+sizeof(third)+2 $data sizeof(data) $open 1 $third sizeof(third) $close 1
data bufferit sizeof(data)+sizeof(fourth)+2 $data sizeof(data) $open 1 $fourth sizeof(fourth) $close 1
data bufferit sizeof(data)+3 1 1 $open 1 $data sizeof(data) $close 1

goto ind


numb: 
$final_syntax == 1 if numb_len
$final_syntax == 2 if numb_end

numb_len:
unbufferit userdata data_type 1 len 1 data sizeof(userdata) - 2 
data bufferit $len+1 $data_type 1 $data $len
goto ind

numb_end:
unbufferit userdata data sizeof(userdata)-4 tmp_data 4
goto ind


string: 
$final_syntax == 1 if string_len
$final_syntax == 2 if string_end

string_len:
;out CurrentSystemName() " string_len " $data_type
unbufferit userdata data_type 1 len 1 data sizeof(userdata) - 2 
data bufferit $len+1 $data_type 1 $data $len
goto ind

string_end:
unbufferit userdata data sizeof(userdata)-4 tmp_data 4
goto ind


buff: 
$final_syntax == 1 if buff_len
$final_syntax == 2 if buff_end

buff_len:
unbufferit userdata data_type 1 len 1 data sizeof(userdata) - 2 
data bufferit $len+1 $data_type 1 $data $len
goto ind

buff_end:
unbufferit userdata data sizeof(userdata)-4 tmp_data 4
goto ind

ind: 
;out CurrentSystemName() " DATA.IND " $data
P_DATA.IND generateup userdata $data

```
## S_EXPEDITED_DATA.IND
```
;параметры:  userdata (буфер)

unbufferit userdata data_id 1 data sizeof(userdata)-1

$data_id == 10 if connect_req
$data_id == 11 if connect_resp

unbufferit userdata data_type 1 data_string sizeof(userdata)-1

$data_type == 1 if struct
$data_type == 2 if numb
$data_type == 3 if string
$data_type == 4 if buff

struct: 

$final_syntax == 1 if struct_len
$final_syntax == 2 if struct_end

struct_len:
unbufferit userdata data_type 1 tmp_data 2 len 1 data sizeof(userdata) - 4
unbufferit userdata first $len tmp_data 1 len 1 data sizeof(data) - sizeof(first) - 2
unbufferit userdata second $len tmp_data 1 len 1 data sizeof(data) - sizeof(second) - 2
unbufferit userdata third $len tmp_data 1 len 1 data sizeof(data) - sizeof(third) - 2
unbufferit userdata fourth $len tmp_data sizeof(data) - sizeof(fourth)

goto construct

struct_end:
copy(data_string, 2, pos("####", data_string) - 2) varset first 
copy(data_string, pos("####", data_string) + 4, sizeof(data_string) - sizeof(first) - 5) varset data_string
copy(data_string, 2, pos("####", data_string) - 2) varset second 
copy(data_string, pos("####", data_string) + 4, sizeof(data_string) - sizeof(second) - 5) varset data_string
copy(data_string, 2, pos("####", data_string) - 2) varset third
copy(data_string, pos("####", data_string) + 4, sizeof(data_string) - sizeof(third) - 5) varset data_string
copy(data_string, 2, pos("####", data_string) - 2) varset fourth

goto construct

construct:
data bufferit sizeof(first)+2 $open 1 $first sizeof(first) $close 1
data bufferit sizeof(data)+sizeof(second)+2 $data sizeof(data) $open 1 $second sizeof(second) $close 1
data bufferit sizeof(data)+sizeof(third)+2 $data sizeof(data) $open 1 $third sizeof(third) $close 1
data bufferit sizeof(data)+sizeof(fourth)+2 $data sizeof(data) $open 1 $fourth sizeof(fourth) $close 1
data bufferit sizeof(data)+3 1 1 $open 1 $data sizeof(data) $close 1

goto ind


numb: 
$final_syntax == 1 if numb_len
$final_syntax == 2 if numb_end

numb_len:
unbufferit userdata data_type 1 len 1 data sizeof(userdata) - 2 
goto ind

numb_end:
unbufferit userdata data sizeof(userdata)-4 tmp_data 4
goto ind


string: 
$final_syntax == 1 if string_len
$final_syntax == 2 if string_end

string_len:
unbufferit userdata data_type 1 len 1 data sizeof(userdata) - 2 
goto ind

string_end:
unbufferit userdata data sizeof(userdata)-4 tmp_data 4
goto ind


buff: 
$final_syntax == 1 if buff_len
$final_syntax == 2 if buff_end

buff_len:
unbufferit userdata data_type 1 len 1 data sizeof(userdata) - 2 
goto ind

buff_end:
unbufferit userdata data sizeof(userdata)-4 tmp_data 4
goto ind

ind: 
P_EXPEDITED_DATA.IND generateup userdata $data
return




connect_req:

unbufferit data in_syntax 1

$in_syntax & $target_syntax varset final_syntax

$final_syntax != 3 if send 

1 varset final_syntax 

send:
data bufferit  2 11 1 $final_syntax 1 
S_EXPEDITED_DATA.REQ eventdown userdata $data
return 


connect_resp: 
unbufferit data final_syntax 1

data bufferit  3 $open 1 $close 1 $final_syntax 1 
P_CONNECT.CONF generateup quality $target_quality context $data
return

```
## S_GIVE_TOKENS.IND
```
;параметры:  token (число)

P_GIVE_TOKENS.IND generateup token $token
```
## S_P_ABORT.IND
```
;параметры:  нет

P_P_ABORT.IND generateup
```
## S_P_EXCEPTION.IND
```
;параметры:  error (число)

P_P_EXCEPTION.IND generateup error $error
```
## S_PLEASE_TOKENS.IND
```
;параметры:  token (число)

P_PLEASE_TOKENS.IND generateup token $token
```
## S_RELEASE.CONF
```
;параметры:  нет

P_RELEASE.CONF generateup
```
## S_RELEASE.IND
```
;параметры:  нет

P_RELEASE.IND generateup
```
## S_RESYNCHRONIZE.CONF
```
;параметры:  token (число)

P_RESYNCHRONIZE.CONF generateup token $token
```
## S_RESYNCHRONIZE.IND
```
;параметры:  token (число)

P_RESYNCHRONIZE.IND generateup token $token
```
## S_SYNC_MAJOR.CONF
```
;параметры:  нет

P_SYNC_MAJOR.CONF generateup
```
## S_SYNC_MAJOR.IND
```
;параметры:  нет

P_SYNC_MAJOR.IND generateup
```
## S_U_ABORT.IND
```
;параметры:  нет

P_U_ABORT.IND generateup
```
# Сессионный уровень

## S_CONNECT.REQ
```
;параметры:  address (число), quality (буфер), demand (буфер)

$quality varset target_quality 
$demand varset target_demand 

unbufferit demand  start_markers sizeof(start_markers)
($start_markers == 1) || ($start_markers == 3) varset is_data_marker
($start_markers == 1) || ($start_markers == 4) varset is_sync_marker

T_CONNECT.REQ eventdown  address $address
```
## S_CONNECT.RESP
```
;параметры:  address (число), quality (буфер)

$quality varset target_quality 
data bufferit sizeof(data_id)+sizeof(q_size)+sizeof(target_quality) 2 sizeof(data_id) sizeof(target_quality) sizeof(q_size) $target_quality sizeof(target_quality)
T_DATA.REQ eventdown userdata $data
```
## S_DATA.REQ
```
;параметры:   userdata (буфер)


out CurrentSystemName() " S_DATA.REQ " $is_data_marker


!!$is_data_marker if error

data bufferit sizeof(data_id)+sizeof(userdata) 3 sizeof(data_id) $userdata sizeof(userdata)
T_DATA.REQ eventdown userdata $data
return

error: 
S_P_EXCEPTION.IND generateup error 1
0 varset q_size
return
 
```
## S_EXPEDITED_DATA.REQ
```
;параметры:   userdata (буфер)

data bufferit sizeof(data_id)+sizeof(userdata) 8 sizeof(data_id) $userdata sizeof(userdata)
T_DATA.REQ eventdown userdata $data


```
## S_GIVE_TOKENS.REQ
```
;параметры:  token (число)
out CurrentSystemName() " GIVE_TOKENS.REQ"
;(!!$is_data_marker) && ($token == 1) if error
;(!!$is_sync_marker) && ($token == 2) if error

data bufferit sizeof(data_id)+sizeof(token) 7 sizeof(data_id) $token sizeof(token)
T_DATA.REQ eventdown userdata $data
out CurrentSystemName() " SEND " $token 

$is_data_marker && ($token != 1) varset is_data_marker
$is_sync_marker && ($token != 2) varset is_sync_marker 
return

;error: 
;S_P_EXCEPTION.IND generateup error 3
;return
 
```
## S_INIT.REQ
```
;CONNECTION
target_address declare integer

data declare buffer
data_id declare integer 
target_quality declare buffer
target_demand declare buffer
q_size declare integer
d_size declare integer

;MARKERS
start_markers declare integer
0 varset start_markers 

markers declare integer

is_data_marker declare integer
is_sync_marker declare integer


;DATA
receive_q declare queue



```
## S_PLEASE_TOKENS.REQ
```
;параметры:  token (число)
out CurrentSystemName() " PLEASE_TOKENS.REQ " $token
out CurrentSystemName() " CURR TOKENS DATA " $is_data_marker " SYNC " $is_sync_marker
;$is_data_marker && ($token == 1) if error
;$is_sync_marker && ($token == 2) if error

data bufferit sizeof(data_id)+sizeof(token) 6 sizeof(data_id) $token sizeof(token)
T_DATA.REQ eventdown userdata $data
return

;error: 
;S_P_EXCEPTION.IND generateup error 3
;return
 
```
## S_RELEASE.REQ
```
;параметры:  нет

data bufferit sizeof(data_id) 9 sizeof(data_id) 
T_DATA.REQ eventdown userdata $data
```
## S_RELEASE.RESP
```
;параметры:  нет

start: 
qcount(receive_q) > 0 if ind
goto end

ind: 
S_DATA.IND generateup userdata dequeue(receive_q)
goto start 
T_DATA.REQ eventdown userdata $data

end: 
data bufferit sizeof(data_id) 10 sizeof(data_id) 
T_DATA.REQ eventdown userdata $data

```
## S_RESYNCHRONIZE.REQ
```
;параметры:  token (число)

out CurrentSystemName() " S_RESYNC.REQ " $token

clearqueue receive_q

data bufferit sizeof(data_id)+sizeof(token) 11 sizeof(data_id) $token sizeof(token)
T_DATA.REQ eventdown userdata $data
```
## S_RESYNCHRONIZE.RESP
```
;параметры:  token (число)

clearqueue receive_q

data bufferit sizeof(data_id)+sizeof(token) 12 sizeof(data_id) $token sizeof(token)
T_DATA.REQ eventdown userdata $data

($token != 1) && ($token !=3) varset is_data_marker
($token != 2) && ($token !=3) varset is_sync_marker
```
## S_SYNC_MAJOR.REQ
```
;параметры:  нет

!!$is_sync_marker if error

data bufferit sizeof(data_id) 4 sizeof(data_id) 
T_DATA.REQ eventdown userdata $data
return


error: 
out CurrentSystemName() " SYNC_MAJOR.REQ - синк и дата  " $is_sync_marker $is_data_marker
S_P_EXCEPTION.IND generateup error 2
return
```
## S_SYNC_MAJOR.RESP
```
;параметры:  нет

out CurrentSystemName() " S_SYNC_MAJOR.RESP " qcount(receive_q)

start: 
qcount(receive_q) > 0 if ind
goto end

ind: 
S_DATA.IND generateup userdata dequeue(receive_q)
goto start 

end: 
data bufferit sizeof(data_id) 5 sizeof(data_id) 
T_DATA.REQ eventdown userdata $data

```
## S_U_ABORT.REQ
```
;параметры:  нет

T_DISCONNECT.REQ eventdown address $target_address
```
## T_CONNECT.CONF
```
;параметры:  address (число)


$address varset target_address
data bufferit sizeof(data_id)+sizeof(q_size)+sizeof(d_size)+sizeof(target_quality)+sizeof(target_demand) 1 sizeof(data_id) sizeof(target_quality) sizeof(q_size) sizeof(target_demand) sizeof(d_size) $target_quality sizeof(target_quality) $target_demand sizeof(target_demand)

;S_CONNECT.CONF generateup 
T_DATA.REQ eventdown userdata $data
```
## T_CONNECT.IND
```
;параметры:  address (число)
$address varset target_address
;S_CONNECT.IND generateup

T_CONNECT.RESP eventdown address $target_address
```
## T_DATA.IND
```
;параметры:  userdata (буфер)

unbufferit userdata data_id sizeof(data_id) data sizeof(userdata)-sizeof(data_id) 
out CurrentSystemName() " T_DATA.IND " $data_id 

$data_id == 1 if connect_ind
$data_id == 2 if connect_conf
$data_id == 3 if add_to_q
$data_id == 4 if major_sync_ind
$data_id == 5 if major_sync_conf_info
$data_id == 6 if please_token_ind
$data_id == 7 if give_token_ind
$data_id == 8 if exp_data_ind
$data_id == 9 if release_ind
$data_id == 10 if release_conf_info
$data_id == 11 if resync_ind
$data_id == 12 if resync_conf


connect_ind:
unbufferit data q_size sizeof(q_size) d_size sizeof(d_size) data sizeof(data)-sizeof(q_size)-sizeof(d_size)
unbufferit data target_quality $q_size target_demand $d_size

unbufferit target_demand start_markers sizeof(start_markers)
($start_markers == 2) || ($start_markers == 4) varset is_data_marker
($start_markers == 2) || ($start_markers == 3) varset is_sync_marker

S_CONNECT.IND generateup address $target_address quality $target_quality demand $target_demand
return

connect_conf:
unbufferit data q_size sizeof(q_size) data sizeof(data)-sizeof(q_size)
unbufferit data target_quality $q_size

S_CONNECT.CONF generateup quality $target_quality
return

major_sync_ind:
S_SYNC_MAJOR.IND generateup
return

major_sync_conf_info:
qcount(receive_q) > 0 if ind_major_sync
goto major_sync_conf

ind_major_sync: 
S_DATA.IND generateup userdata dequeue(receive_q)
goto major_sync_conf_info

major_sync_conf:
S_SYNC_MAJOR.CONF generateup
return

release_conf_info:
qcount(receive_q) > 0 if ind_release
goto release_conf

ind_release: 
S_DATA.IND generateup userdata dequeue(receive_q)
goto release_conf_info

release_conf:
T_DISCONNECT.REQ eventdown address $target_address
S_RELEASE.CONF generateup
return

please_token_ind:
unbufferit data markers sizeof(markers)
S_PLEASE_TOKENS.IND generateup token $markers
return 

give_token_ind: 
unbufferit data markers sizeof(markers)
S_GIVE_TOKENS.IND generateup token $markers
out CurrentSystemName() " GET TOKEN " $markers
$is_data_marker || ($markers == 1) varset is_data_marker
$is_sync_marker || ($markers == 2) varset is_sync_marker
return

exp_data_ind:
S_EXPEDITED_DATA.IND generateup userdata $data
return

release_ind: 
S_RELEASE.IND generateup
return

resync_ind:
out CurrentSystemName() " S_RESYNCHRONIZE.IND "
unbufferit data markers sizeof(markers)
S_RESYNCHRONIZE.IND generateup token $markers
return

resync_conf:
unbufferit data markers sizeof(markers)
S_RESYNCHRONIZE.CONF generateup token $markers

($markers == 1)  || ($markers == 3) varset is_data_marker
($markers == 2)  || ($markers == 3) varset is_sync_marker
return


add_to_q: 
queue receive_q $data
return

```
## T_DISCONNECT.IND
```
S_U_ABORT.IND generateup
```

# Транспортный уровень

## CONNECT_TIMER
```
$state == "REQ" if req

out CurrentSystemName() " connect_timer"
N_DISCONNECT.REQ eventdown  address $target_address
; задержка при разрыве соединения: 2±1
CONNECT_TIMER2 timer con_timer 3
return

req:
out CurrentSystemName() " connect_data_timer"
N_DISCONNECT.REQ eventdown  address $target_address
; задержка при разрыве соединения: 2±1
CONNECT_TIMER2 timer con_timer 3

```
## CONNECT_TIMER2
```
out CurrentSystemName() " connect_timer 2"
N_CONNECT.REQ eventdown  address $target_address
CONNECT_TIMER timer con_timer 31
```
## DISCON_TIMER
```
$discon_try < 1 if exit
out CurrentSystemName() " DISCONNECT TIMER " $discon_id
data bufferit 2 2 1 $discon_id 1 ; first elemet - code
N_DATA.REQ eventdown userdata $data
DISCON_TIMER timer discon_timer 31
$discon_try - 1 varset discon_try
return
exit:
"NONE" varset state

N_DISCONNECT.REQ eventdown address $target_address
out CurrentSystemName() " END OF DISCONNECT TIMER " $discon_id
```
## N_CONNECT.CONF
```
;параметры:  address (число)

untimer $con_timer

$state == "REQ" if skip
$is_discon_initiator == 1 if skip

"REQ" varset state
T_CONNECT.CONF generateup address $address
return

skip:
out CurrentSystemName() " CONNECT.CONF - SKIP" 

```
## N_CONNECT.IND
```
;параметры:  address (число)

$state == "RESP" if resp

out CurrentSystemName() " N_CONNECT.IND"
$address varset target_address

0 varset data_id
0 varset ind_num
0 varset max_ack
1 varset ind_disc_num

T_CONNECT.IND generateup  address $address
return


resp:
out CurrentSystemName() " N_CONNECT.IND - RESP"
N_CONNECT.RESP eventdown  address $target_address

```
## N_DATA.IND
```
;параметры:  userdata (буфер)

out CurrentSystemName() " N_DATA.IND" 

sizeof(userdata)<1 if error
sizeof(userdata)<3 if not_data

unbufferit userdata data_marker 1 msg_num 1 data sizeof(userdata)-2

out CurrentSystemName() " GET DATA "  $msg_num

$ind_num < $msg_num if skip
ack_data bufferit 2 1 1 $msg_num 1 ; first elemet - code
N_DATA.REQ eventdown userdata $ack_data

$ind_num > $msg_num if skip
out CurrentSystemName() " GET TRUE DATA "  $msg_num

T_DATA.IND generateup userdata $data 
$msg_num + 1 varset ind_num

return

not_data: 
unbufferit userdata code 1 msg_num 1

$code == 1 if ack

$code == 2 if disconnect

return

disconnect: 
$state == "NONE" if exit 

out CurrentSystemName() " DISCON DATA REQ  NUM "  $msg_num 

$msg_num != $ind_disc_num if skip
$msg_num+1 varset ind_disc_num 

$is_discon_initiator==1 if confirm_disconnect

"NONE" varset state

out CurrentSystemName() " N_DATA T_DISCONNECT.IND "
T_DISCONNECT.IND generateup
$discon_id+1 varset discon_id
5 varset discon_try
DISCON_TIMER timer discon_timer 1

return

confirm_disconnect:

$state == "NONE" if exit 

out CurrentSystemName() " N_DATA confirm_disconnect "
untimer $discon_timer
N_DISCONNECT.REQ eventdown address $target_address
"NONE" varset state
0 varset is_discon_initiator
return

ack:
out CurrentSystemName() " GET ACK  "  $msg_num 
$max_ack > $msg_num if skip
($msg_num  - $max_ack) > 4 if skip
$msg_num+1 varset max_ack

dequeue(data_q) varset trash

out CurrentSystemName() " GET ACK FOR "  $msg_num

return

oldd: 
out CurrentSystemName() " DUPLICATE " 
return

oldc:
out CurrentSystemName() " OLD ACK " 
return

error:
out CurrentSystemName() " ERROR " 
return 

skip:
out CurrentSystemName() " SKIP " $msg_num " " $ind_num " " $max_ack " " $ind_disc_num
return 

exit: 

```
## N_DISCONNECT.IND
```
;параметры:  нет
$state == "REQ" if reconnect
$state == "RESP" if wait

out CurrentSystemName() " DISCONNECT.IND - CLASSIC" 
"NONE" varset state
untimer $discon_timer
return 

wait:
out CurrentSystemName() " DISCONNECT.IND - WAIT" 

return

reconnect: 
out CurrentSystemName() " DISCONNECT.IND - RECONNECT" 

N_CONNECT.REQ eventdown  address $target_address
CONNECT_TIMER timer con_timer 31

return
```
## RESEND_TIMER
```
;$resend_try > 10 if exit

;$resend_try+1 varset resend_try

qcount(data_q) == 0 if exit

out CurrentSystemName() " resend_timer " 
;N_DATA.REQ eventdown userdata $userdata
N_DATA.REQ eventdown userdata peek(data_q)
RESEND_TIMER timer data_timer 41 
return 

exit:
```
## T_CONNECT.REQ
```
;параметры:  address (число)

out CurrentSystemName() " CONNECT.REQ" 
0 varset is_discon_initiator

untimer $discon_timer
"NONE" varset state
0 varset data_id
0 varset ind_num
0 varset max_ack
0 varset discon_id

N_CONNECT.REQ eventdown  address $address
$address varset target_address

; задержка при установлении соединения:	10±5 - макс 15. В обе стороны 30.
CONNECT_TIMER timer con_timer 31

```
## T_CONNECT.RESP
```
;параметры:  address (число)

out CurrentSystemName() " T_CONNECT.RESP"

"RESP" varset state

N_CONNECT.RESP eventdown address $address
```
## T_DATA.REQ
```
;параметры:   userdata (буфер)



out CurrentSystemName() " DATA.REQ " $data_id 

data bufferit sizeof(userdata)+2 1 1 $data_id 1 $userdata sizeof(userdata) ; fist element is data_marker
queue data_q $data
$data_id+1 varset data_id

qcount(data_q) > 1 if skip

;N_DATA.REQ eventdown userdata $data
N_DATA.REQ eventdown userdata peek(data_q)

0 varset resend_try
;RESEND_TIMER timer data_timer 31 userdata $data
RESEND_TIMER timer data_timer 41

return
skip:

```
## T_DISCONNECT.REQ
```
;параметры:  address (число)

;out CurrentSystemName() " DISCONNECT.REQ NUM " $discon_id

untimer $data_timer

1 varset is_discon_initiator

$discon_id+1 varset discon_id

10 varset discon_try
out CurrentSystemName() " DISCONNECT.REQ NUM " $discon_id
DISCON_TIMER timer discon_timer 1


```
## T_INIT.REQ
```
;addr declare integer

;CONNECTION
target_address declare integer
con_timer declare integer

;DATA AND VALIDATION
data declare buffer
trash declare buffer
data_marker declare integer 
data_q declare queue 
;trash declare buffer
data_timer declare integer

ack_data declare buffer

data_id declare integer 
0 varset data_id
ind_num declare integer
0 varset ind_num

max_ack declare integer
0 varset max_ack

msg_num declare integer

discon_id declare integer
0 varset discon_id 
ind_disc_num declare integer
1 varset ind_disc_num 

;SPECIFIC VALUES
state declare string
"NONE" varset state

code declare integer 

resend_try declare integer

discon_try declare integer

is_discon_initiator declare integer
discon_timer declare integer
