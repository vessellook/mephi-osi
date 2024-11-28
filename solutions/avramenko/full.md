# Синтаксис

Синтаксис STX2.

Год создания 2021.

Исходное название лабы reborn_new_archive_var1_z4_new_era_not_nice_another_last_try_curr_etalon_ultra_mega_nice.lab

# Прикладной уровень
## A_INIT.REQ
```
declare a_namer string
declare a_namei string
declare a_namer_buf buffer
declare a_namei_buf buffer
declare a_context buffer
declare a_quality buffer
declare a_demand buffer
declare a_apcon string
declare resolve_type integer
declare req_t1 integer
declare req_t2 integer
declare req_s1 string
declare req_s2 string
declare req_apcon string
declare res_name string
declare res_id integer
declare package_type integer
declare data buffer
declare a_address integer
declare a_address_buf buffer
declare time_start integer
declare time_stop integer
declare release_req_timer integer
declare release_ind_timer integer
declare release_resp_timer integer
declare release_conf_timer integer
declare terminate_req_timer integer
declare size integer
declare size2 integer
declare size3 integer
declare type integer
declare dict_flag integer
declare req_name string
declare terminate_resp_timer integer
declare change_from string
declare change_to string
declare package_buffer buffer
declare package_queue queue
declare asked_for_token integer

declare resolve_req_timer integer
declare resolve_ind_timer integer
declare associate_req_timer integer
declare associate_ind_timer integer
declare associate_resp_timer integer
declare associate_conf_timer integer

declare sync_timer integer

declare hack_address integer
declare current_demand buffer
1 1 1 bufferit current_demand

declare dict_name string
declare dict_buffer buffer

declare current_queue queue

0 varset hack_address 
```

## A_ASSOCIATE.CONF
```
;параметры:  address (число), quality (буфер), demand (буфер), context (буфер)
out "A_ASSOCIATE.CONF"
untimer $associate_conf_timer 
if $a_apcon == "GS" gs
if $a_apcon == "DT" dt

goto done
gs:
sizeof(a_namer)+1 3 1 $a_namer sizeof(a_namer) bufferit package_buffer
P_DATA.REQ senddown userdata $package_buffer
out "gd P_DATA.REQ " $a_address
A_SYNC_MAJOR_TIMER 0 timeevent sync_timer
goto done
dt:
context $context quality $quality sendup A_TRANSFER_INIT.CONF
goto done
done:
```

## A_ASSOCIATE.IND
```
untimer $associate_ind_timer 
namei $a_namei quality $quality sendup A_TRANSFER_INIT.IND
```

## A_ASSOCIATE.REQ
```
untimer $associate_req_timer 
$apcon varset a_apcon
P_CONNECT.REQ senddown address $a_address quality $quality demand $demand context $context
```

## A_ASSOCIATE.RESP
```
untimer $associate_resp_timer
P_CONNECT.RESP senddown address $a_address quality $quality context $context
```

## A_DATA.REQ
```
out "A_DATA.REQ"
queue package_queue $userdata
if $asked_for_token == 1 done
; else - ask for token
out "PLEASE_TOKENS.REQ"
P_PLEASE_TOKENS.REQ senddown token 1
1 varset asked_for_token
goto done
done:
```

## A_RELEASE.CONF
```
untimer $release_conf_timer 
if $apcon == "GS" gs
if $apcon == "DT" dt

goto done
gs:
4 $resolve_type 1 $a_address 1 $change_from 1 $change_to 1 bufferit a_address_buf
A_RESOLVE.IND 0 address $a_address_buf timeevent resolve_ind_timer
goto done
dt:
address $a_address sendup A_TERMINATE.CONF
goto done
done:
```

## A_RELEASE.IND
```
untimer $release_ind_timer 
sendup A_TERMINATE.IND
```

## A_RELEASE.REQ
```
untimer $release_req_timer 
$apcon varset a_apcon
P_RELEASE.REQ senddown
```

## A_RELEASE.RESP
```
untimer $release_resp_timer 
P_RELEASE.RESP senddown
```

## A_RESOLVE.IND
```
untimer $resolve_ind_timer
unpack resolve_type 1 a_address 1 change_from 1 change_to 1 address
sizeof(a_namer)+1 $a_namer sizeof(a_namer) $a_address 1 bufferit a_namer_buf
out "A_RESOLVE.IND " $resolve_type " " $a_address
A_ASSOCIATE.REQ 0 namer $a_namer namei $a_namei_buf quality $a_quality demand $a_demand context $a_context apcon "DT" timeevent associate_req_timer 
```

## A_RESOLVE.REQ
```
untimer $resolve_req_timer 
locguide($name) varset data
unpack resolve_type 1 a_address 1 time_start 1 time_stop 1 change_from 1 change_to 1 data
if $resolve_type == 3 not_found

;goto hack

goto type

hack:
$hack_address varset a_address 
goto type_0


type:
if $resolve_type == 0 type_0
if $resolve_type == 1 type_1
if $resolve_type == 2 type_2
if $resolve_type == 3 type_3
if $resolve_type == 4 type_4
goto end

type_0:
"DT" varset current_apcon
$current_apcon varset req_apcon
sizeof(total_name) + 1 $a_address 1 $total_name sizeof(total_name) bufferit current_buffer
sizeof(req_name) + 1 $req_address 1 $req_name sizeof(req_name) bufferit current_buffer2
sizeof(current_buffer) + sizeof(current_buffer2) + sizeof(current_quality) + sizeof(current_demand) + sizeof(current_context) + sizeof(current_apcon) + 3 sizeof(current_buffer) 1 sizeof(current_buffer2) 1 sizeof(current_context) 1 $current_buffer sizeof(current_buffer) $current_buffer2 sizeof(current_buffer2) $current_quality sizeof(current_quality) $current_demand sizeof(current_demand) $current_context sizeof(current_context) $current_apcon sizeof(current_apcon) bufferit current_buffer
A_RESOLVE.IND  1 address $current_buffer  timeevent current_timer
goto end

type_1:
A_RESOLVE.REQ $current_t1+100 name $total_name  timeevent current_timer 
goto end

type_2:
A_RESOLVE.REQ $current_t1+100  name $total_name timeevent current_timer 
goto end


type_4:
out "NEED TO FIX NAME"
goto end


not_found:
locguide("Guide") varset data
out "NOT FOUND"
unpack resolve_type 1 a_address 1 time_start 1 time_stop 1 change_from 1 change_to 1 data
1 1 1 bufferit a_demand
6 "Guide" 5 $a_address 1 bufferit a_namer_buf
sizeof(a_namei)+1 $a_namei sizeof(a_namei) locguide($a_namei) 1 bufferit a_namei_buf
A_ASSOCIATE.REQ 0 namer $a_namer_buf namei $a_namei_buf quality $a_quality demand $a_demand context $a_context apcon "GS" timeevent associate_req_timer

goto end
end:
```

## A_SYNC_MAJOR_TIMER
```
;untimer sync_timer
P_SYNC_MAJOR.REQ senddown
```

## A_TERMINATE.CONF
```
untimer $terminate_conf_timer
```

## A_TERMINATE.REQ
```
A_RELEASE.REQ 0 apcon $a_apcon timeevent release_req_timer
```

## A_TERMINATE.RESP
```
untimer $terminate_resp_timer 
A_RELEASE.RESP 0 apron "DT" timeevent release_resp_timer
```

## A_TRANSFER_INIT.REQ
```
$namer varset a_namer
$namei varset a_namei
$context varset a_context
$quality varset a_quality
A_RESOLVE.REQ 0 name $namer timeevent resolve_req_timer
```

## A_TRANSFER_INIT.RESP
```
A_ASSOCIATE.RESP 0 namei $a_namei_buf context $context quality $quality apcon "DT" timeevent associate_resp_timer
```

## A_U_ABORT.REQ
```
;параметры: apcon (строка)
P_U_ABORT.REQ senddown
```

## P_CONNECT.CONF
```
A_ASSOCIATE.CONF 0 context $a_context quality $a_quality demand $a_demand timeevent associate_conf_timer
```

## P_CONNECT.IND
```
$address varset a_address
locguide($address) varset a_namei
sizeof(a_namei)+1 $address 1 $a_namei sizeof(a_namei) bufferit a_namei_buf
A_ASSOCIATE.IND 1 namei $a_namei_buf quality $quality demand $demand timeevent associate_ind_timer
```

## P_DATA.IND
```
out "P_DATA.IND " $a_apcon 
if $a_apcon == "GS" gs
if  $a_apcon == "TD" td
"TD" varset a_apcon
goto td
goto done
td:
userdata $userdata sendup A_DATA.IND
goto done
gs:

unpack package_type 1 resolve_type 1 a_address 1 time_start 1 time_stop 1 change_from 1 change_to 1 userdata
out "RESOLVE TYPE " $package_type " " $resolve_type " " $a_address " " $time_start " " $time_stop " " $change_from " " $change_to
if $resolve_type == 2 wait
if $resolve_type == 1 wait
if $resolve_type == 3 ultra_wait
$a_address varset hack_address 
A_RELEASE.REQ 0 apcon "GS" timeevent release_req_timer
goto done

wait:
out "WAIT"
A_RESOLVE.REQ $time_start +100 name "SystemB" timeevent release_req_timer
goto done

ultra_wait:
out "ULTRA WAIT"
$hack_address varset  a_address 
A_RELEASE.REQ 0 apcon "GS" timeevent release_req_timer
goto done
A_RESOLVE.REQ 1000 name "SystemB" timeevent release_req_timer
goto done

done:
```

## P_GIVE_TOKENS.IND
```
out "P_GIVE_TOKENS.IND"
if $token == 1 loop
P_SYNC_MAJOR.REQ senddown
goto done
loop:
if qcount(package_queue) == 0 break
P_DATA.REQ senddown userdata dequeue(package_queue)
goto loop

break:
0 varset asked_for_token
P_PLEASE_TOKENS.REQ senddown token 2
goto done

done:
```

## P_P_ABORT.IND
```
apcon $a_apcon sendup A_P_ABORT.IND
```

## P_P_EXCEPTION.IND
```
;параметры:  error (число)
if ($error == 1) need_data_marker
if ($error == 2) need_sync_marker
if ($error == 3) need_resync
out "p_pe.i : unexpected error"
goto end

need_data_marker:
P_GIVE_TOKENS.REQ senddown token 1
goto end

need_sync_marker:
P_GIVE_TOKENS.REQ senddown token 2
goto end

need_resync:
P_RESYNCHRONIZE.REQ senddown token 4
goto end

end:
```

## P_PLEASE_TOKENS.IND
```
P_GIVE_TOKENS.REQ senddown token $token
```

## P_RELEASE.CONF
```
A_RELEASE.CONF 0 apcon $a_apcon timeevent release_conf_timer
```

## P_RELEASE.IND
```
A_RELEASE.IND 0 apcon "DT" timeevent release_ind_timer
```

## P_SYNC_MAJOR.CONF
```
;параметры:  нет
```

## P_SYNC_MAJOR.IND
```
;параметры:  нет
P_SYNC_MAJOR.RESP senddown
```

## P_U_ABORT.IND
```
;параметры:  нет
```

# Уровень представления

## P_INIT.REQ
```
declare state integer
declare exchange integer
declare curr_address integer
declare type integer
declare syntax integer
declare req_sp integer
declare res_sp integer
declare data_type integer
declare tmp_str string
declare tmp_res_str string
declare str_1 string
declare str_2 string
declare str_3 string
declare str_4 string
declare len_1 integer
declare len_2 integer
declare len_3 integer
declare len_4 integer
declare curr_len integer
declare pos_1 integer
declare pos_2 integer
declare loops integer
declare count_len integer
declare queue_flag integer
declare m_timer integer
declare curr_buffer buffer
declare req_syntax buffer
declare res_syntax buffer
declare open string
declare close string
declare curr_str string
declare curr_quality buffer
declare curr_demand buffer
declare tmp_buf_sizes buffer
declare tmp_buf_strs buffer
declare tmp buffer
declare m_queue queue
declare struct_type_with_size integer
declare struct_type_with_no_size integer
declare no_struct_type_with_size integer
declare no_struct_type_with_no_size integer
declare max_loops integer

declare struct_type integer
declare with_size integer
declare data_ind integer
5 varset max_loops 
16 varset data_ind 
32 varset with_size 
64 varset struct_type 

($data_ind | $with_size | $struct_type) varset struct_type_with_size 
($data_ind | $struct_type) varset struct_type_with_no_size 
($data_ind | $with_size ) varset no_struct_type_with_size 
($data_ind) varset no_struct_type_with_no_size 

0 varset state
```

## P_CONNECT.REQ
```
;параметры:  address (число), quality (буфер), demand (буфер), context (буфер)
0 varset state

unpack open 1 close 1 req_syntax sizeof(context) - 2 context
$quality varset curr_quality
$demand varset curr_demand
$address varset curr_address

S_CONNECT.REQ senddown address $address quality $quality demand $demand
```

## P_CONNECT.RESP
```
;параметры:  address (число), quality (буфер), context (буфер)

unpack open 1 close 1 res_syntax sizeof(context) - 2 context

if sizeof(req_syntax) == 1 req_sp_point
3 varset req_sp
goto to_res_sp

req_sp_point:
unpack req_sp 1 req_syntax



to_res_sp:
if sizeof(res_syntax) == 1 res_sp_point
3 varset res_sp
goto calculate_syntax

res_sp_point:
unpack res_sp 1 res_syntax



calculate_syntax:
if ($req_sp & $res_sp) == 1 syntax_to_1
if ($req_sp & $res_sp) == 2 syntax_to_2
goto exposed

syntax_to_1:
1 varset syntax
goto send

syntax_to_2:
2 varset syntax

goto send
exposed:
out "SYNTAX ERR " $req_sp " & " $res_sp
got exit

send:
4 2 1 $curr_quality 2 $syntax 1 bufferit curr_buffer
S_EXPEDITED_DATA.REQ senddown userdata $curr_buffer

exit:
```

## P_DATA.REQ
```
;параметры:  userdata (буфер)

unpack data_type 1 curr_buffer sizeof(userdata) - 1 userdata

if ($data_type == 1) struct
if ($syntax == 1) no_struct_with_size

sizeof(curr_buffer) + 4 $no_struct_type_with_no_size 1 $data_type 1 $curr_buffer sizeof(curr_buffer) "\n" 2 bufferit curr_buffer
goto send

no_struct_with_size:
sizeof(curr_buffer) + 3 $no_struct_type_with_size 1 sizeof(curr_buffer) 1 $data_type 1 $curr_buffer sizeof(curr_buffer) bufferit curr_buffer
goto send




struct:

$max_loops varset loops
0 bufferit tmp_buf_sizes
0 bufferit tmp_buf_strs
unpack curr_str sizeof(curr_buffer) curr_buffer
copy(curr_str, 2, sizeof(curr_str) - 2) varset curr_str
0 varset pos_1
0 varset pos_2
loop:
$loops-1 varset loops
if $loops <= 0 break_loop
;copy(curr_str, 2, sizeof(curr_str) - 2) varset curr_str
copy(curr_str, $pos_2 + 1, sizeof(curr_str) - $pos_2) varset curr_str
out $curr_str
pos($open, curr_str) varset pos_1
pos($close, curr_str) varset pos_2
if (($pos_2 == 0) && ($pos_1 == 0)) break_loop
if $pos_2 - $pos_1 <= 1 empty
copy(curr_str, $pos_1 + 1, $pos_2 - $pos_1 - 1) varset tmp_str
goto append
empty:
"" varset tmp_str 
goto append

append:
if ($syntax == 1) append_with_size
sizeof(tmp_str) + 2 $tmp_str sizeof(tmp_str) "\n" 2 bufferit tmp
if sizeof(tmp_buf_strs) == 0 set_buf_strs
sizeof(tmp_buf_strs) + sizeof(tmp)  $tmp_buf_strs sizeof(tmp_buf_strs) $tmp sizeof(tmp)  bufferit tmp_buf_strs
goto loop

append_with_size:
if sizeof(tmp_buf_sizes) == 0 init_sizes
sizeof(tmp_buf_sizes) + 1 $tmp_buf_sizes sizeof(tmp_buf_sizes) sizeof(tmp_str) 1 bufferit tmp_buf_sizes
goto after_init_sizes
init_sizes:
1 sizeof(tmp_str) 1 bufferit tmp_buf_sizes
after_init_sizes:
sizeof(tmp_str)  $tmp_str sizeof(tmp_str) bufferit tmp
if sizeof(tmp_buf_strs) == 0 set_buf_strs
sizeof(tmp_str) + sizeof(tmp_buf_strs) $tmp_buf_strs  sizeof(tmp_buf_strs) $tmp_str sizeof(tmp_str) bufferit tmp_buf_strs
goto loop

set_buf_strs:
$tmp varset tmp_buf_strs
goto loop

break_loop:

if ($syntax == 1) struct_with_size
sizeof(tmp_buf_strs)+1 $struct_type_with_no_size 1 $tmp_buf_strs sizeof(tmp_buf_strs) bufferit curr_buffer
goto send

struct_with_size:
out "send " sizeof(tmp_buf_sizes)
sizeof(tmp_buf_strs)+sizeof(tmp_buf_sizes)+2  $struct_type_with_size 1 sizeof(tmp_buf_sizes) 1 $tmp_buf_sizes sizeof(tmp_buf_sizes) $tmp_buf_strs sizeof(tmp_buf_strs) bufferit curr_buffer
goto send

send:
queue  m_queue $curr_buffer
if $queue_flag == 1 end 
1 varset queue_flag
P_TIMER 0 timeevent m_timer 

end:
```

## P_EXPEDITED_DATA.REQ
```
;параметры:  userdata (буфер)

unpack data_type 1 curr_buffer sizeof(userdata) - 1 userdata

if ($data_type == 1) struct
if ($syntax == 1) no_struct_with_size

sizeof(curr_buffer) + 4 $no_struct_type_with_no_size 1 $data_type 1 $curr_buffer sizeof(curr_buffer) "\n" 2 bufferit curr_buffer
goto send

no_struct_with_size:
sizeof(curr_buffer) + 3 $no_struct_type_with_size 1 sizeof(curr_buffer) 1 $data_type 1 $curr_buffer sizeof(curr_buffer) bufferit curr_buffer
goto send




struct:

$max_loops varset loops
0 bufferit tmp_buf_sizes
0 bufferit tmp_buf_strs
unpack curr_str sizeof(curr_buffer) curr_buffer
copy(curr_str, 2, sizeof(curr_str) - 2) varset curr_str
0 varset pos_1
0 varset pos_2
loop:
$loops-1 varset loops
if $loops <= 0 break_loop
;copy(curr_str, 2, sizeof(curr_str) - 2) varset curr_str
copy(curr_str, $pos_2 + 1, sizeof(curr_str) - $pos_2) varset curr_str
out $curr_str
pos($open, curr_str) varset pos_1
pos($close, curr_str) varset pos_2
if (($pos_2 == 0) && ($pos_1 == 0)) break_loop
if $pos_2 - $pos_1 <= 1 empty
copy(curr_str, $pos_1 + 1, $pos_2 - $pos_1 - 1) varset tmp_str
goto append
empty:
"" varset tmp_str 
goto append

append:
if ($syntax == 1) append_with_size
sizeof(tmp_str) + 2 $tmp_str sizeof(tmp_str) "\n" 2 bufferit tmp
if sizeof(tmp_buf_strs) == 0 set_buf_strs
sizeof(tmp_buf_strs) + sizeof(tmp)  $tmp_buf_strs sizeof(tmp_buf_strs) $tmp sizeof(tmp)  bufferit tmp_buf_strs
goto loop

append_with_size:
if sizeof(tmp_buf_sizes) == 0 init_sizes
sizeof(tmp_buf_sizes) + 1 $tmp_buf_sizes sizeof(tmp_buf_sizes) sizeof(tmp_str) 1 bufferit tmp_buf_sizes
goto after_init_sizes
init_sizes:
1 sizeof(tmp_str) 1 bufferit tmp_buf_sizes
after_init_sizes:
sizeof(tmp_str)  $tmp_str sizeof(tmp_str) bufferit tmp
if sizeof(tmp_buf_strs) == 0 set_buf_strs
sizeof(tmp_str) + sizeof(tmp_buf_strs) $tmp_buf_strs  sizeof(tmp_buf_strs) $tmp_str sizeof(tmp_str) bufferit tmp_buf_strs
goto loop

set_buf_strs:
$tmp varset tmp_buf_strs
goto loop

break_loop:

if ($syntax == 1) struct_with_size
sizeof(tmp_buf_strs)+1 $struct_type_with_no_size 1 $tmp_buf_strs sizeof(tmp_buf_strs) bufferit curr_buffer
goto send

struct_with_size:
out "send " sizeof(tmp_buf_sizes)
sizeof(tmp_buf_strs)+sizeof(tmp_buf_sizes)+2  $struct_type_with_size 1 sizeof(tmp_buf_sizes) 1 $tmp_buf_sizes sizeof(tmp_buf_sizes) $tmp_buf_strs sizeof(tmp_buf_strs) bufferit curr_buffer
goto send


send:
S_EXPEDITED_DATA.REQ senddown userdata $curr_buffer

end:
```

## P_GIVE_TOKENS.REQ
```
;параметры:  token (число)
S_GIVE_TOKENS.REQ senddown token $token
```

## P_PLEASE_TOKENS.REQ
```
;параметры:  token (число)
out "P_PLEASE_TOKENS REQ " CurrentSystemName() " " $token
S_PLEASE_TOKENS.REQ senddown token $token
```

## P_RELEASE.REQ
```
;параметры:  нет
S_RELEASE.REQ senddown
```

## P_RELEASE.RESP
```
;параметры:  нет
S_RELEASE.RESP senddown
```

## P_RESYNCHRONIZE.REQ
```
;параметры:  token (число)
S_RESYNCHRONIZE.REQ senddown token $token
```

## P_RESYNCHRONIZE.RESP
```
;параметры:  token (число)
S_RESYNCHRONIZE.RESP senddown token $token
```

## P_SYNC_MAJOR.REQ
```
;параметры:  нет
S_SYNC_MAJOR.REQ senddown
```

## P_SYNC_MAJOR.RESP
```
;параметры:  нет
S_SYNC_MAJOR.RESP senddown
```

## P_TIMER
```
if (qcount (m_queue) > 0) send
0 varset queue_flag
goto end

send:
S_DATA.REQ senddown userdata dequeue (m_queue)
P_TIMER 0  timeevent m_timer

end:
```

## P_U_ABORT.REQ
```
;параметры:  нет
S_U_ABORT.REQ senddown
```

## S_CONNECT.CONF
```
;параметры:  quality (буфер)
sizeof(curr_address) + sizeof(curr_quality) + sizeof(curr_demand) +  sizeof(req_syntax) + 1 1 1 $curr_address sizeof(curr_address) $curr_quality sizeof(curr_quality) $curr_demand sizeof(curr_demand) $syntax sizeof(req_syntax) bufferit curr_buffer
S_EXPEDITED_DATA.REQ senddown userdata $curr_buffer 
```

## S_CONNECT.IND
```
;параметры:  address (число), quality (буфер), demand (буфер)
1 varset state
S_CONNECT.RESP senddown address $address quality $quality demand $demand
```

## S_DATA.IND
```
;параметры:  userdata (буфер)

unpack type 1 curr_buffer sizeof(userdata) - 1 userdata

;out "TYPE " $type
if (($type & $data_ind) != $data_ind) exit
if (($type & $struct_type) == $struct_type) struct



if (($type & $with_size) == $with_size) no_struct_with_size
unpack data_type 1 curr_str sizeof(curr_buffer) - 1 curr_buffer
pos("\n", curr_str) varset pos_1
copy(curr_str,1, pos_1 - 1) varset curr_str
out "SIMETING WITHOUT SIZE " $curr_str
sizeof(curr_str) + 1 $data_type 1 $curr_str sizeof(curr_str) bufferit curr_buffer
goto send

no_struct_with_size:
unpack len_1 1 data_type 1 curr_buffer sizeof(curr_buffer) - 2 curr_buffer
unpack curr_buffer $len_1 curr_buffer
out "SIMETING WITH SIZE " $curr_buffer " type " $data_type
if $data_type != 3 other
unpack curr_str sizeof(curr_buffer) curr_buffer
out "STRING '" $curr_str "'"
other:
sizeof(curr_buffer) + 1 $data_type 1 $curr_buffer sizeof(curr_buffer) bufferit curr_buffer
goto send

struct:

if (($type & $with_size) == $with_size) struct_with_size


unpack curr_str sizeof(curr_buffer) curr_buffer
$open varset tmp_res_str
$max_loops varset loops
no_size_loop:
$loops-1 varset loops
if $loops <= 0 break_no_size_loop
pos("\n", curr_str) varset pos_1
if $pos_1 == 0 break_no_size_loop
copy(curr_str, 1, $pos_1 - 1) varset tmp_str
copy (curr_str, $pos_1 + 2, sizeof(curr_str) - $pos_1 - 1) varset curr_str
$tmp_res_str + $open + $tmp_str + $close varset tmp_res_str
goto no_size_loop


break_no_size_loop:
$tmp_res_str+$close varset tmp_res_str

sizeof(curr_str) + 1 1 1 $curr_str sizeof(curr_str) bufferit curr_buffer

goto send


struct_with_size:
unpack count_len 1 tmp sizeof(curr_buffer)-1 curr_buffer
out "GET count_len " $count_len " where " sizeof(tmp) " of " sizeof(curr_buffer)
;$count_len-1 varset count_len
unpack tmp_buf_sizes $count_len curr_str (sizeof(tmp)-$count_len) tmp
out "GET sizes " sizeof(tmp_buf_sizes) " and " sizeof(curr_str)
out $curr_str
$max_loops varset loops
$open varset tmp_res_str
size_loop:
$loops-1 varset loops
if $loops <= 0 break_size_loop
if $count_len <= 0 break_size_loop
unpack curr_len 1 tmp_buf_sizes sizeof(tmp_buf_sizes)-1 tmp_buf_sizes
$count_len-1 varset count_len
copy(curr_str, 1, $curr_len) varset tmp_str
copy(curr_str, $curr_len+1, sizeof(curr_str)-$curr_len) varset curr_str
out "GET " $tmp_str
$tmp_res_str + $open + $tmp_str + $close varset tmp_res_str
goto size_loop

break_size_loop:

$tmp_res_str + $close varset tmp_res_str
sizeof(tmp_res_str) + 1 1 1 $tmp_res_str sizeof(tmp_res_str) bufferit curr_buffer
goto send

send:
userdata $curr_buffer sendup P_DATA.IND

exit:
```

## S_EXPEDITED_DATA.IND
```
;параметры:  userdata (буфер)

unpack type 1 curr_buffer sizeof(userdata) - 1 userdata

;type:
;1 - запрос на соединение
;2 - ответ на запрос на соединение
;11 - по длине, не структура
;12 - по признаку конца, не структура
;13 - по длине, структура
;14 - по признаку конца, структура
out "S_EXPEDITED_DATA.IND " $type
if $type == 1 connect_req
if $type == 2 connect_res
if (($type & $data_ind) != $data_ind) end
if (($type & $struct_type) == $struct_type) struct
if (($type & $struct_type) != $struct_type) no_struct
goto end


connect_req:
unpack curr_address 1 curr_quality 2 curr_demand 1 req_syntax sizeof(curr_buffer) - 4 curr_buffer
address $curr_address quality $curr_quality demand $curr_demand sendup P_CONNECT.IND
goto end

connect_res:
unpack curr_quality 2 syntax 1 curr_buffer
3 $open 1 $close 1 $syntax 1 bufferit curr_buffer
quality $curr_quality context $curr_buffer sendup P_CONNECT.CONF
goto end



no_struct:

if (($type & $with_size) == $with_size) no_struct_with_size
unpack data_type 1 curr_str sizeof(curr_buffer) - 1 curr_buffer
pos("\n", curr_str) varset pos_1
copy(curr_str,1, pos_1 - 1) varset curr_str
sizeof(curr_str) + 1 $data_type 1 $curr_str sizeof(curr_str) bufferit curr_buffer
goto send

no_struct_with_size:
unpack len_1 1 data_type 1 curr_buffer sizeof(curr_buffer) - 2 curr_buffer
unpack curr_buffer $len_1 curr_buffer
sizeof(curr_buffer) + 1 $data_type 1 $curr_buffer sizeof(curr_buffer) bufferit curr_buffer
goto send

struct:

if (($type & $with_size) == $with_size) struct_with_size


unpack curr_str sizeof(curr_buffer) curr_buffer
$open varset tmp_res_str
no_size_loop:
pos("\n", curr_str) varset pos_1
if $pos_1 == 0 break_no_size_loop
copy(curr_str, 1, $pos_1 - 1) varset tmp_str
copy (curr_str, $pos_1 + 2, sizeof(curr_str) - $pos_1 - 1) varset curr_str
$tmp_res_str + $open + $tmp_str + $close varset tmp_res_str
goto no_size_loop


break_no_size_loop:
$tmp_res_str+$close varset tmp_res_str

sizeof(curr_str) + 1 1 1 $curr_str sizeof(curr_str) bufferit curr_buffer

goto send


struct_with_size:
unpack count_len 1 tmp sizeof(curr_buffer)-1 curr_buffer
out "GET count_len " $count_len " where " sizeof(tmp) " of " sizeof(curr_buffer)
;$count_len-1 varset count_len
unpack tmp_buf_sizes $count_len curr_str (sizeof(tmp)-$count_len) tmp
out "GET sizes " sizeof(tmp_buf_sizes) " and " sizeof(curr_str)
out $curr_str

$open varset tmp_res_str
size_loop:
if $count_len <= 0 break_size_loop
unpack curr_len 1 tmp_buf_sizes sizeof(tmp_buf_sizes)-1 tmp_buf_sizes
$count_len-1 varset count_len
copy(curr_str, 1, $curr_len) varset tmp_str
copy(curr_str, $curr_len+1, sizeof(curr_str)-$curr_len) varset curr_str
out "GET " $tmp_str
$tmp_res_str + $open + $tmp_str + $close varset tmp_res_str
goto size_loop

break_size_loop:

$tmp_res_str + $close varset tmp_res_str
sizeof(tmp_res_str) + 1 1 1 $tmp_res_str sizeof(tmp_res_str) bufferit curr_buffer
goto send

send:
userdata $curr_buffer sendup P_EXPEDITED_DATA.IND

end:
```

## S_GIVE_TOKENS.IND
```
;параметры:  token (число)
token $token sendup P_GIVE_TOKENS.IND
```

## S_P_ABORT.IND
```
;параметры:  нет
sendup P_P_ABORT.IND
```

## S_P_EXCEPTION.IND
```
;параметры:  error (число)
error $error sendup P_P_EXCEPTION.IND
```

## S_PLEASE_TOKENS.IND
```
;параметры:  token (число)
token $token sendup P_PLEASE_TOKENS.IND
```

## S_RELEASE.CONF
```
;параметры:  нет
sendup P_RELEASE.CONF
```

## S_RELEASE.IND
```
;параметры:  нет
sendup P_RELEASE.IND
```

## S_RESYNCHRONIZE.CONF
```
;параметры:  token (число)
token $token sendup P_RESYNCHRONIZE.CONF 
```

## S_RESYNCHRONIZE.IND
```
;параметры:  token (число)
token $token sendup P_RESYNCHRONIZE.IND
```

## S_SYNC_MAJOR.CONF
```
;параметры:  нет
sendup P_SYNC_MAJOR.CONF
```

## S_SYNC_MAJOR.IND
```
;параметры:  нет
sendup P_SYNC_MAJOR.IND
```

## S_U_ABORT.IND
```
;параметры:  нет
sendup P_U_ABORT.IND
```

# Сеансовый уровень

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

буфер quality имеет формат <def_flag| 1 слово><main_sync_flag| 1 слово>

буфер demand имеет формат <marker| 1 слово>

## S_INIT.REQ
```
declare current_address integer
declare type integer
declare quality_size integer
declare demand_size integer
declare def_flag integer
declare main_sync_flag integer
declare current_crc integer
declare current_calc_crc integer
declare queue_flag integer
declare current_timer integer
declare current_token integer
declare state integer
declare marker integer

declare current_quality buffer
declare current_demand buffer
declare current_buffer buffer

declare current_queue queue
declare total_queue queue

0 varset queue_flag
0 varset  state
0 varset  marker
```

## S_CONNECT.REQ
```
;параметры:  address (число), quality (буфер), demand (буфер)
$quality varset current_quality
$demand varset current_demand
unpack  marker 1 demand
T_CONNECT.REQ senddown address $address
```

## S_CONNECT.RESP
```
;параметры:  address (число), quality (буфер)
$quality varset current_quality
sizeof(current_quality) + 2 2 1 sizeof(current_quality) 1 $current_quality sizeof(current_quality) bufferit current_buffer
T_DATA.REQ senddown userdata $current_buffer
```

## S_DATA.REQ
```
;параметры:   userdata (буфер)
if  ((($state == 1) && (($marker == 4)||($marker == 2))) ||(($state == 0) && (($marker == 1)||($marker == 3)))) ok
out "S_DATA REQ NEED TOKEN " CurrentSystemName() " " 1
error 1 sendup S_P_EXCEPTION.IND
error 3 sendup S_P_EXCEPTION.IND
sizeof(token) + 1 21 1 $token sizeof(token) bufferit current_buffer
T_DATA.REQ senddown userdata $current_buffer
goto end
ok:
unpack  def_flag 1 main_sync_flag 1 current_quality
if $def_flag == 1 with_def 
goto without_def

with_def:
calccrc  current_crc $userdata
sizeof(userdata) + 2 4 1 $current_crc 1 $userdata sizeof(userdata) bufferit current_buffer
goto send

without_def:
sizeof(userdata) + 1 4 1 $userdata sizeof(userdata) bufferit current_buffer
goto send

send:
queue  current_queue $current_buffer
if $queue_flag == 1 end 
1 varset queue_flag
S_TIMER 2 timeevent current_timer 
end:
```

## S_EXPEDITED_DATA.REQ
```
;параметры:   userdata (буфер)

unpack  def_flag 1 main_sync_flag 1 current_quality
if $def_flag == 1 with_def 
goto without_def

with_def:
calccrc  current_crc $userdata
sizeof(userdata) + 2 5 1 $current_crc 1 $userdata sizeof(userdata) bufferit current_buffer
goto send

without_def:
sizeof(userdata) + 1 5 1 $userdata sizeof(userdata) bufferit current_buffer
goto send

send:
T_DATA.REQ senddown userdata $current_buffer
```

## S_GIVE_TOKENS.REQ
```
;параметры:  token (число)
out "S_GIVE_TOKENS REQ " $token
if "Guide" != CurrentSystemName() next
2 22 1 1 1 bufferit current_buffer
T_DATA.REQ senddown userdata $current_buffer
next:
2 22 1 $token 1 bufferit current_buffer
T_DATA.REQ senddown userdata $current_buffer


if (($state == 1) && ($marker == 3) && ($token == 2)) marker_1 
if (($state == 1) && ($marker == 4) && ($token == 1)) marker_1 
if (($state == 0) && ($marker == 3) && ($token == 1)) marker_2 
if (($state == 0) && ($marker == 4) && ($token == 2)) marker_2 
if (($state == 0) && ($marker == 1) && ($token == 2)) marker_3 
if (($state == 1) && ($marker == 2) && ($token == 1)) marker_3 
if (($state == 0) && ($marker == 1) && ($token == 1)) marker_4 
if (($state == 1) && ($marker == 2) && ($token == 2)) marker_4 
goto end

marker_1:
1 varset marker
goto end

marker_2:
2 varset marker
goto end

marker_3:
3 varset marker
goto end

marker_4:
4 varset marker
goto end

end:
```

## S_PLEASE_TOKENS.REQ
```
;параметры:  token (число)
out "S_PLEASE_TOKENS REQ " CurrentSystemName() " " $token
if (("Guide" == CurrentSystemName())) next
if (($state == 0) && ($marker == 1)) skip 
if (($state == 1) && ($marker == 2)) skip 
if (($state == 0) && ($marker == 3) && ($token == 1)) skip 
if (($state == 0) && ($marker == 4) && ($token == 2)) skip 
if (($state == 1) && ($marker == 3) && ($token == 2)) skip 
if (($state == 1) && ($marker == 4) && ($token == 1)) skip 
sizeof(token) + 1 21 1 $token sizeof(token) bufferit current_buffer
T_DATA.REQ senddown userdata $current_buffer

goto end

next:
out "GIVE DATA TO GUIDE"
sizeof(token) + 1 21 1 1 sizeof(token) bufferit current_buffer
T_DATA.REQ senddown userdata $current_buffer
sizeof(token) + 1 21 1 2 sizeof(token) bufferit current_buffer
T_DATA.REQ senddown userdata $current_buffer
goto end

if (($state == 0) && ($marker == 3) && ($token== 2)) marker_1 
if (($state == 0) && ($marker == 4) && ($token== 1)) marker_1
if (($state == 1) && ($marker == 3) && ($token== 1)) marker_2 
if (($state == 1) && ($marker == 4) && ($token== 2)) marker_2 
if (($state == 1) && ($marker == 1) && ($token== 2)) marker_3 
if (($state == 0) && ($marker == 2) && ($token== 1)) marker_3 
if (($state == 1) && ($marker == 1) && ($token== 1)) marker_4 
if (($state == 0) && ($marker == 2) && ($token== 2)) marker_4 
goto end

marker_1:
1 varset marker
goto end

marker_2:
2 varset marker
goto end

marker_3:
3 varset marker
goto end

marker_4:
4 varset marker
goto end


goto end

skip:
out "S_PLEASE_TOKENS REQ SKIPED " CurrentSystemName() " " $token
token $token sendup  S_GIVE_TOKENS.IND
goto end

end:
```

## S_RELEASE.REQ
```
;параметры:  нет
1 6 1 bufferit current_buffer
T_DATA.REQ senddown userdata $current_buffer
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
1 7 1 bufferit current_buffer
T_DATA.REQ senddown userdata $current_buffer
```

## S_RESYNCHRONIZE.REQ
```
;параметры:  token (число)

clearqueue tatal_queue
sizeof(token) + 1 13 1 $token sizeof(token) bufferit current_bufferit
T_DATA.REQ senddown userdata $current_bufferit
```

## S_RESYNCHRONIZE.RESP
```
;параметры:  token (число)

clearqueue tatal_queue
sizeof(token) + 1 14 1 $token sizeof(token) bufferit current_buffer
T_DATA.REQ senddown userdata $current_buffer

if (($state == 0) && ($current_token == 4)) marker_1 
if (($state == 1) && ($current_token == 3)) marker_1 
if (($state == 0) && ($current_token == 3)) marker_2 
if (($state == 1) && ($current_token == 4)) marker_2 
if (($state == 0) && ($current_token == 2)) marker_3 
if (($state == 1) && ($current_token == 1)) marker_3 
if (($state == 0) && ($current_token == 1)) marker_4 
if (($state == 1) && ($current_token == 2)) marker_4 

marker_1:
1 varset marker
goto end

marker_2:
2 varset marker
goto end

marker_3:
3 varset marker
goto end

marker_4:
4 varset marker
goto end

end:
```

## S_SYNC_MAJOR.REQ
```
;параметры:  нет
1 11 1 bufferit current_buffer
T_DATA.REQ senddown userdata $current_buffer
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
1 12 1 bufferit current_buffer
T_DATA.REQ senddown userdata $current_buffer
```

## S_TIMER
```
if (qcount (current_queue) > 0) send 
0 varset queue_flag
goto end

send:
T_DATA.REQ senddown userdata dequeue (current_queue)
S_TIMER 2 timeevent current_timer 

end:
```

## S_U_ABORT.REQ
```
;параметры:  нет
1 3 1 bufferit current_buffer
T_DATA.REQ senddown userdata $current_buffer
```

## T_CONNECT.CONF
```
;параметры:  address (число)

$address varset current_address
0 varset state
;0 - инициирующая сторона
sizeof(current_quality) + sizeof(current_demand) + 3 1 1 sizeof(current_quality) 1 sizeof(current_demand) 1 $current_quality sizeof(current_quality) $current_demand sizeof(current_demand) bufferit current_buffer
T_DATA.REQ senddown userdata $current_buffer
```

## T_CONNECT.IND
```
;параметры:  address (число)

1 varset state
;1 - принимающая сторона
$address varset current_address
T_CONNECT.RESP senddown address $address
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

unpack  type 1 current_buffer sizeof(userdata) - 1 userdata
if $type == 1 connect_req 
if $type == 2 connect_res 
if $type == 3 disconnect_req 
if $type == 4 data_req
if $type == 5 exp_data_req 
if $type == 6 release_req 
if $type == 7 release_res 
if $type == 11 sync_req 
if $type == 12 sync_res 
if $type == 13 resync_req 
if $type == 14 resync_res 
if $type == 21 token_req 
if $type == 22 token_res 
goto end


connect_req:
unpack quality_size 1 demand_size 1 current_buffer sizeof(current_buffer) - 2  current_buffer
unpack current_quality $quality_size current_demand $demand_size  current_buffer
unpack marker 1  current_demand
address $current_address quality $current_quality demand $current_demand sendup  S_CONNECT.IND
goto end


connect_res:
unpack quality_size 1 current_buffer sizeof(current_buffer) - 1  current_buffer
unpack current_quality $quality_size  current_buffer
quality $current_quality sendup  S_CONNECT.CONF
goto end


disconnect_req:
T_DISCONNECT.REQ senddown address $current_address
sendup S_U_ABORT.IND
goto end


data_req:
unpack def_flag 1 main_sync_flag 1  current_quality
if $def_flag == 1 with_def 
goto add

with_def:
unpack current_crc 1 current_buffer sizeof(current_buffer) - 1  current_buffer
calccrc  current_calc_crc $current_buffer
if $current_crc != $current_calc_crc broken 

add:
queue total_queue $current_buffer
goto end


exp_data_req:
unpack def_flag 1 main_sync_flag 1  current_quality
if $def_flag == 1  exp_with_def 
goto send

exp_with_def:
unpack current_crc 1 current_buffer sizeof(current_buffer) - 1  current_buffer
calccrc  current_calc_crc $current_buffer
if $current_crc != $current_calc_crc broken 

send:
userdata $current_buffer sendup S_EXPEDITED_DATA.IND
goto end

broken:
out 'data was broken'
goto end


release_req:
sendup S_RELEASE.IND
goto end


release_res:
if qcount(total_queue) > 0 release_repeat 
goto release_end_queue

release_repeat:
userdata (dequeue(total_queue)) sendup S_DATA.IND
goto release_res

release_end_queue:
T_DISCONNECT.REQ senddown address $current_address
sendup S_RELEASE.CONF
goto end


sync_req:
sendup S_SYNC_MAJOR.IND
goto end


sync_res:
if qcount(total_queue) > 0 sync_repeat 
goto sync_end_queue

sync_repeat:
userdata (dequeue(total_queue)) sendup  S_DATA.IND
goto sync_res

sync_end_queue:
sendup S_SYNC_MAJOR.CONF
goto end


resync_req:
unpack current_token 1  current_buffer
token $current_token sendup  S_RESYNCHRONIZE.IND
goto end


resync_res:
unpack current_token sizeof(current_buffer)  current_buffer
token $current_token sendup  S_RESYNCHRONIZE.IND
if (($state == 0) && ($current_token == 3)) marker_1
if (($state == 1) && ($current_token == 4)) marker_1 
if (($state == 0) && ($current_token == 4)) marker_2 
if (($state == 1) && ($current_token == 3)) marker_2 
if (($state == 0) && ($current_token == 1)) marker_3 
if (($state == 1) && ($current_token == 2)) marker_3 
if (($state == 0) && ($current_token == 2)) marker_4 
if (($state == 1) && ($current_token == 1)) marker_4 
goto end


token_req:
unpack current_token 1  current_buffer 
out "T DATA GET TOKEN REQ " CurrentSystemName() " " $current_token
token $current_token sendup S_PLEASE_TOKENS.IND
goto end


token_res:
unpack current_token 1  current_buffer
out "T DATA GET TOKEN RESP  " CurrentSystemName() " " $current_token
token $current_token sendup S_GIVE_TOKENS.IND
if (($state == 0) && ($marker == 3) && ($current_token == 2)) marker_1 
if (($state == 0) && ($marker == 4) && ($current_token == 1)) marker_1
if (($state == 1) && ($marker == 3) && ($current_token == 1)) marker_2 
if (($state == 1) && ($marker == 4) && ($current_token == 2)) marker_2 
if (($state == 1) && ($marker == 1) && ($current_token == 2)) marker_3 
if (($state == 0) && ($marker == 2) && ($current_token == 1)) marker_3 
if (($state == 1) && ($marker == 1) && ($current_token == 1)) marker_4 
if (($state == 0) && ($marker == 2) && ($current_token == 2)) marker_4 
goto end

marker_1:
1 varset marker
goto end

marker_2:
2 varset marker
goto end

marker_3:
3 varset marker
goto end

marker_4:
4 varset marker
goto end

end:
```

## T_DISCONNECT.IND
```
;параметры:  нет
```

# Транспортный уровень

## T_INIT.REQ
```
declare zero_timer integer
declare t_address integer
declare tmp_buffer buffer
declare package_buffer buffer
declare package_buffer_out buffer
declare package_type  integer
declare last_received integer
declare last_sent integer
declare package_number integer
declare package_queue queue
declare pac_crc integer
declare crc_buffer integer
declare con_try integer
declare connect_try integer
declare timeout_connect integer
declare delay_timer integer
declare timeout_delay integer
declare last_sent_data integer
declare last_received_data integer
```

## N_DATAGRAM.IND
```
;параметры:  address (число), userdata (буфер)
if sizeof(userdata) < 3 currupted
unpack tmp_buffer sizeof(userdata)-1 pac_crc 1 userdata
unpack package_type 1 package_number 1 package_buffer sizeof(tmp_buffer )-2 tmp_buffer 

calccrc crc_buffer $tmp_buffer 
if $crc_buffer != $pac_crc currupted

if ($package_number == 1) && ($package_type == 0) && ($last_received > 1) reset_counters
goto continue
reset_counters:
	0 varset last_sent
	0 varset last_received
continue:
if $package_number <= $last_received done
$package_number varset last_received 
if $package_type == 0 connect_req
if $package_type == 1 connect_resp
if $package_type == 2 disconnect_req
if $package_type == 3 disconnect_ind
if $package_type == 4 resend
if $package_type == 10 data_req
goto done
connect_req:
	$address varset t_address
	address $address sendup  T_CONNECT.IND
	goto done
connect_resp:
	untimer $con_try
	address $address sendup  T_CONNECT.CONF
	goto done
disconnect_req:
	$last_sent + 1 varset last_sent
	2 3 1 $last_sent 1 bufferit package_buffer 
	if (qcount(package_queue) == 0) && ($delay_timer == 0) disconnect_now
	;else disconnect_later
	disconnect_later:
		queue package_queue $package_buffer 
		goto done
	disconnect_now:
		address $address sendup  T_DISCONNECT.IND
;		senddown address $address userdata $package_buffer N_DATAGRAM.REQ
		goto done
disconnect_ind:
	address $address sendup  T_DISCONNECT.IND
	goto done
data_req:
	userdata $package_buffer sendup  T_DATA.IND
	goto done
resend:
	;N_DATAGRAM.REQ senddown address $address userdata peek(package_queue )
	if qcount(package_queue ) > 0 resend_from_queue
	N_DATAGRAM.REQ senddown address $address userdata $package_buffer_out 
	goto done

resend_from_queue:
	N_DATAGRAM.REQ senddown address $address userdata peek(package_queue )
	N_DATAGRAM.REQ senddown address $address userdata peek(package_queue )
	N_DATAGRAM.REQ senddown address $address userdata $package_buffer_out 
	goto done

currupted:
	$last_sent + 1 varset last_sent
	2 4 1 $last_sent 1 bufferit package_buffer
	calccrc pac_crc $package_buffer
	sizeof(package_buffer)+1 $package_buffer sizeof(package_buffer) $pac_crc 1 bufferit tmp_buffer 
	;N_DATAGRAM.REQ senddown address $address userdata $tmp_buffer
	;N_DATAGRAM.REQ senddown address $address userdata $tmp_buffer
	goto done

done:
```

## T_CONNECT.REQ
```
;параметры:  address (число)
0 varset last_sent
0 varset last_received
0 varset last_sent_data
0 varset last_received_data
50 varset timeout_connect
10 varset timeout_delay 
5 varset connect_try 

$address varset t_address
$last_sent + 1 varset last_sent
2 0 1 $last_sent 1 bufferit package_buffer
calccrc pac_crc $package_buffer
sizeof(package_buffer)+1 $package_buffer sizeof(package_buffer) $pac_crc 1 bufferit package_buffer_out 
;N_DATAGRAM.REQ senddown address $address userdata $package_buffer_out 
;N_DATAGRAM.REQ senddown address $address userdata $package_buffer_out 
;N_DATAGRAM.REQ senddown address $address userdata $package_buffer_out 
ZERO_TIMER 0 address $t_address  package $package_buffer_out timeevent zero_timer 

CONNECT  $timeout_connect timeevent con_try 
T_DELAY_TIMER $timeout_delay  address $address timeevent delay_timer 
```

## T_CONNECT.RESP
```
;параметры:  address (число)
;0 varset last_sent
;0 varset last_received
0 varset last_sent_data
0 varset last_received_data

$last_sent + 1 varset last_sent
2 1 1 $last_sent 1 bufferit package_buffer
calccrc pac_crc $package_buffer
sizeof(package_buffer)+1 $package_buffer sizeof(package_buffer) $pac_crc 1 bufferit package_buffer_out 
;N_DATAGRAM.REQ senddown address $address userdata $package_buffer_out
$address varset t_address 
ZERO_TIMER 0 address $address package $package_buffer_out timeevent zero_timer 
```

## T_DATA.REQ
```
;параметры:   userdata (буфер)
$last_sent + 1 varset last_sent
 2+sizeof(userdata) 10 1 $last_sent 1 $userdata sizeof(userdata) bufferit package_buffer 
calccrc pac_crc $package_buffer
sizeof(package_buffer)+1 $package_buffer sizeof(package_buffer) $pac_crc 1 bufferit package_buffer_out 
;N_DATAGRAM.REQ senddown address $t_address userdata $package_buffer_out
;goto done
;out "IM HERE"
;queue package_queue $package_buffer_out
;queue package_queue $package_buffer_out
;queue package_queue $package_buffer_out
;queue package_queue $package_buffer_out

ZERO_TIMER 1 address $t_address  package $package_buffer_out timeevent zero_timer 
goto done
if $delay_timer == 0 send
if $delay_timer > 0 put_in_queue
;queue package_queue $package_buffer_out
;T_DELAY_TIMER $timeout_delay address $t_address timeevent delay_timer 
put_in_queue:
	
	goto done
send:
	 ;N_DATAGRAM.REQ senddown address $t_address userdata $package_buffer_out
	 ;N_DATAGRAM.REQ senddown address $t_address userdata $package_buffer_out
	 ;N_DATAGRAM.REQ senddown address $t_address userdata $package_buffer_out
	ZERO_TIMER 0 address $t_address  package $package_buffer_out timeevent zero_timer 
	;T_DELAY_TIMER 5 address $t_address timeevent delay_timer 
	goto done
done:
```

## T_DISCONNECT.REQ
```
;параметры:  address (число)
$last_sent + 1 varset last_sent
2 2 1 $last_sent 1 bufferit package_buffer 
calccrc pac_crc $package_buffer
sizeof(package_buffer)+1 $package_buffer sizeof(package_buffer) $pac_crc 1 bufferit package_buffer_out 
;if (qcount(package_queue) == 0) && ($delay_timer == 0)  disconnect
; else put_in_queue
;put_in_queue:
	;queue package_queue $package_buffer_out
	;goto done
;disconnect:
	;N_DATAGRAM.REQ senddown address $address userdata $package_buffer_out 
	;goto done
;done:

;queue package_queue $package_buffer_out
;queue package_queue $package_buffer_out
;queue package_queue $package_buffer_out
;queue package_queue $package_buffer_out

if $delay_timer == 0 send
if $delay_timer > 0 put_in_queue
;queue package_queue $package_buffer_out
;T_DELAY_TIMER $timeout_delay address $t_address timeevent delay_timer 
put_in_queue:
	
	goto done
send:
	ZERO_TIMER 0 address $t_address  package $package_buffer_out timeevent zero_timer 
	 ;N_DATAGRAM.REQ senddown address $t_address userdata $package_buffer_out
	 ;N_DATAGRAM.REQ senddown address $t_address userdata $package_buffer_out
	 ;N_DATAGRAM.REQ senddown address $t_address userdata $package_buffer_out
	;T_DELAY_TIMER 5 address $t_address timeevent delay_timer 
	goto done
done:
```

## T_DELAY_TIMER
```
0 varset delay_timer
if qcount(package_queue) == 0 done
; else send
send:
	;out "GAVNO"
	;out qcount(package_queue)
	dequeue(package_queue) varset package_buffer_out
	;out sizeof(package_buffer_out)
	;N_DATAGRAM.REQ senddown address $address userdata peek(package_queue)
	;N_DATAGRAM.REQ senddown address $address userdata $package_buffer_out
	ZERO_TIMER 0 address $address  package $package_buffer_out timeevent zero_timer 
	T_DELAY_TIMER $timeout_delay address $address timeevent delay_timer 
	goto done
done:
```

## ZERO_TIMER
```
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
N_DATAGRAM.REQ senddown address $address  userdata $package
```