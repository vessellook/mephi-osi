# Общее

Синтаксис STX3.

Год создания 2024.

# Уровень представления
## P_CONNECT.REQ
```
;параметры:  address (число), quality (буфер), demand (буфер), context (буфер)
out "P " CurrentSystemName() ": P_CONNECT.REQ: " 
set $address  adres_
unbuffer oBracket 1 cBracket 1 data_ sizeof(context)-2  context
if (sizeof(data_)==2)  two
one:
unbuffer lSyn 1  data_
goto continue
two:
set 3 lSyn
continue:
S_CONNECT.REQ eventdown address $address quality $qual_ demand $demand
```
## P_CONNECT.RESP
```
;параметры:  address (число), quality (буфер), context (буфер)
out "P " CurrentSystemName() ": P_CONNECT.RESP: "
set $address adres_
unbuffer oBracket 1 cBracket 1 data_ sizeof(context)-2  context
if (sizeof(data_)==2) two
one:
unbuffer lSyn 1  data_
goto continue
two:
set 3  lSyn
continue:
S_CONNECT.RESP eventdown address $address quality $quality
```
## P_DATA.REQ
```
;параметры:  userdata (буфер)
out "P " CurrentSystemName() ": P_DATA.REQ: " 
unbuffer typ 1 str sizeof(userdata)-1  userdata
if ($typ==1)  passstruct
if ($typ==2)  passnum
if ($typ==3)  passstr
if ($typ==4)  passbuf
passstruct:
set copy(str, 3, pos($cBracket, str)-3)  first_
set copy(str, sizeof(first_)+5, sizeof(str)-sizeof(first_)-5)  str
set copy(str, 1, pos($cBracket, str)-1)  second_
set copy(str, pos($oBracket, str)+1, sizeof(str)-sizeof(second_)-2)  third_
set copy(third_, 1, pos($cBracket, str)-3)  third_
set copy(str, sizeof(third_)+sizeof(second_)+5, sizeof(str)-(sizeof(third_)+sizeof(second_)+5))  fourth_
if ($fSyn==1)  structlen
$first_ sizeof(first_) $string_end 4 $second_ sizeof(second_) $string_end 4 $third_ sizeof(third_) $string_end 4 $fourth_ sizeof(fourth_) $string_end 4 (sizeof(first_)+4+sizeof(second_)+4+sizeof(third_)+4+sizeof(fourth_)+4)  buffer data_
1 1 $data_ sizeof(data_)  $string_end 4 (sizeof(data_)+5) buffer data_
goto end
structlen:
sizeof(first_) 1 $first_ sizeof(first_) sizeof(second_) 1 $second_ sizeof(second_) sizeof(third_) 1 $third_ sizeof(third_) sizeof(fourth_) 1 $fourth_ sizeof(fourth_) (sizeof(first_)+1+sizeof(second_)+1+sizeof(third_)+1+sizeof(fourth_)+1)  buffer data_
1 1 sizeof(data_) 1 $data_ sizeof(data_) (sizeof(data_)+2) buffer data_
goto end
passnum:
if ($fSyn==1)  numberlen
$userdata 2 $string_end 4 6 buffer data_
goto end
numberlen:
unbuffer typ 1 tmp_ 1  userdata
2 1 1 1 $tmp_ 1 6 buffer data_
goto end
passstr:
if ($fSyn==1)  strlen
$userdata sizeof(userdata) $string_end 4 (sizeof(userdata)+4) buffer data_
goto end
strlen:
unbuffer typ 1 tmp_ sizeof(userdata)-1  userdata
3 1 sizeof(tmp_) 1 $tmp_ sizeof(tmp_) (sizeof(tmp_)+2)  buffer data_
goto end
passbuf:
if ($fSyn==1)  bufferlen
$userdata sizeof(userdata) $string_end 4 (sizeof(userdata)+4)  buffer data_
goto end
bufferlen:
unbuffer typ 1 tmp_ sizeof(userdata)-1  userdata
4 1 sizeof(tmp_) 1 $tmp_ sizeof(tmp_) (sizeof(tmp_)+2) buffer data_
		
end:
S_DATA.REQ eventdown userdata $data_
```
## P_EXPEDITED_DATA.REQ
```
out "P " CurrentSystemName() ": P_EXPEDITED_DATA.REQ: " 
unbuffer typ 1 str sizeof(userdata)-1  userdata
if ($typ==1)  passstruct
if ($typ==2)  passnum
if ($typ==3)  passstr
if ($typ==4)  passbuf
passstruct:
set copy(str, 3, pos($cBracket, str)-3)  first_
set copy(str, sizeof(first_)+5, sizeof(str)-sizeof(first_)-5)  str
set copy(str, 1, pos($cBracket, str)-1)  second_
set copy(str, pos($oBracket, str)+1, sizeof(str)-sizeof(second_)-2)  third_
set copy(third_, 1, pos($cBracket, str)-3)  third_
set copy(str, sizeof(third_)+sizeof(second_)+5, sizeof(str)-(sizeof(third_)+sizeof(second_)+5))  fourth_
if ($fSyn==1)  structlen
$first_ sizeof(first_) $string_end 4 $second_ sizeof(second_) $string_end 4 $third_ sizeof(third_) $string_end 4 $fourth_ sizeof(fourth_) $string_end 4 (sizeof(first_)+4+sizeof(second_)+4+sizeof(third_)+4+sizeof(fourth_)+4)  buffer data_
1 1 $data_ sizeof(data_)  $string_end 4 (sizeof(data_)+5) buffer data_
goto end
structlen:
sizeof(first_) 1 $first_ sizeof(first_) sizeof(second_) 1 $second_ sizeof(second_) sizeof(third_) 1 $third_ sizeof(third_) sizeof(fourth_) 1 $fourth_ sizeof(fourth_) (sizeof(first_)+1+sizeof(second_)+1+sizeof(third_)+1+sizeof(fourth_)+1)  buffer data_
1 1 sizeof(data_) 1 $data_ sizeof(data_) (sizeof(data_)+2) buffer data_
goto end
passnum:
if ($fSyn==1)  numberlen
$userdata 2 $string_end 4 6 buffer data_
goto end
numberlen:
unbuffer typ 1 tmp_ 1  userdata
2 1 1 1 $tmp_ 1 6 buffer data_
goto end
passstr:
if ($fSyn==1) strlen
$userdata sizeof(userdata) $string_end 4 (sizeof(userdata)+4)  buffer data_
goto end
strlen:
unbuffer typ 1 tmp_ sizeof(userdata)-1  userdata
3 1 sizeof(tmp_) 1 $tmp_ sizeof(tmp_) (sizeof(tmp_)+2) buffer data_
goto end
passbuf:
if ($fSyn==1) bufferlen
$userdata sizeof(userdata) $string_end 4 (sizeof(userdata)+4) buffer data_
goto end
bufferlen:
unbuffer typ 1 tmp_ sizeof(userdata)-1  userdata
3 1 sizeof(tmp_) 1 $tmp_ sizeof(tmp_) (sizeof(tmp_)+2)  buffer data_
		
end:
S_EXPEDITED_DATA.REQ eventdown userdata $data_
```
## P_GIVE_TOKENS.REQ
```
out "P " CurrentSystemName() ": P_GIVE_TOKENS.REQ: " 
;параметры:  token (число)
S_GIVE_TOKENS.REQ eventdown token $token
```
## P_INIT.REQ
```
declare integer adres_ 
declare buffer qual_ 
declare string oBracket 
declare string cBracket 
declare integer lSyn 
declare integer passSyn 
declare integer fSyn 
declare buffer packet 
declare integer typ 
declare buffer data_
declare buffer tmp_ 
declare string str 
declare string first_ 
declare string second_ 
declare string third_ 
declare string fourth_ 
declare integer size 
declare string string_end
set "2214" string_end
```
## P_PLEASE_TOKENS.REQ
```
out "P " CurrentSystemName() ": P_PLEASE_TOKENS.REQ: " 
;параметры:  token (число)
S_PLEASE_TOKENS.REQ eventdown token $token
```
## P_RELEASE.REQ
```
out "P " CurrentSystemName() ": P_RELEASE.REQ: " 
;параметры:  нет
S_RELEASE.REQ eventdown
```
## P_RELEASE.RESP
```
;параметры:  нет
out "P " CurrentSystemName() ": P_RELEASE.RESP: " 
S_RELEASE.RESP eventdown
```
## P_RESYNCHRONIZE.REQ
```
;параметры:  token (число)
out "P " CurrentSystemName() ": P_RESYNCHRONIZE.REQ" 
S_RESYNCHRONIZE.REQ eventdown token $token
```
## P_RESYNCHRONIZE.RESP
```
;параметры:  token (число)
out "P " CurrentSystemName() ": P_RESYNCHRONIZE.RESP" 
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
set $quality qual_
100 1 $lSyn 1 2 buffer packet
S_EXPEDITED_DATA.REQ eventdown userdata $packet
```
## S_CONNECT.IND
```
;параметры:  address (число), quality (буфер), demand (буфер)
P_CONNECT.IND eventup address $address quality $quality demand $demand 
```
## S_DATA.IND
```
;параметры:  userdata (буфер)
unbuffer typ 1 str sizeof(userdata)-1  userdata
if ($typ==1)  passstruct
if ($typ==2)  passnum
if ($typ==3)  passstr
if ($typ==4)  passbuf
passstruct:
if ($fSyn==1) structlen
set copy(str, 1, pos($string_end, str)-1) first_
set copy(str, pos($string_end, str)+4, sizeof(str)-sizeof(first_)-4) str
set copy(str, 1, pos($string_end, str)-1) second_
set copy(str, pos($string_end, str)+4, sizeof(str)-sizeof(second_)-4) str
set copy(str, 1, pos($string_end, str)-1) third_
set copy(str, pos($string_end, str), sizeof(str)-sizeof(third_)) str
set copy(str, 1, pos($string_end, str)-1) fourth_
goto packit
structlen:
unbuffer typ 1 size 1 data_ sizeof(userdata)-2  userdata
unbuffer size 1 first_ $size data_ sizeof(data_)-1-sizeof(first_) data_
unbuffer size 1 second_ $size data_ sizeof(data_)-1-sizeof(second_) data_
unbuffer size 1 third_ $size data_ sizeof(data_)-1-sizeof(third_) data_
unbuffer size 1 fourth_ $size data_ sizeof(data_)-1-sizeof(fourth_) data_
packit:
$oBracket 1 $first_ sizeof(first_) $cBracket 1 $oBracket 1 $second_ sizeof(second_) $cBracket 1 $oBracket 1 $third_ sizeof(third_) $cBracket 1 $oBracket 1 $fourth_ sizeof(fourth_) $cBracket 1 (sizeof(first_)+2+sizeof(second_)+2+sizeof(third_)+2+sizeof(fourth_)+2) buffer data_
1 1 $oBracket 1 $data_ sizeof(data_) $cBracket 1 (sizeof(data_)+3) buffer data_
goto end
	
passnum:
if ($fSyn==1)  numberlen
unbuffer data_ 2 tmp_ 4  userdata
goto end
numberlen:
unbuffer typ 1 size 1 data_ 1  userdata
$typ 1 $data_ $size ($size+1) buffer data_
goto end
passstr:
if ($fSyn==1) strlen
unbuffer data_ sizeof(userdata)-4 tmp_ 4  userdata
goto end
strlen:
unbuffer typ 1 size 1 data_ sizeof(userdata)-2  userdata
$typ 1 $data_ $size ($size+1)  buffer data_
goto end
passbuf:
if ($fSyn==1)  bufferlen
unbuffer data_ sizeof(userdata)-4 tmp_ 4  userdata
goto end
bufferlen:
unbuffer typ 1 size 1 data_ sizeof(userdata)-2  userdata
$typ 1 $data_ $size ($size+1) buffer data_
		
end:
P_DATA.IND eventup userdata $data_ 
```
## S_EXPEDITED_DATA.IND
```
;параметры:  userdata (буфер)
unbuffer typ 1 data_ sizeof(userdata)-1  userdata
unbuffer typ 1 str sizeof(userdata)-1  userdata
if ($typ==1)  passstruct
if ($typ==2)  passnum
if ($typ==3)  passstr
if ($typ==4)  passbuf
if ($typ==100)  connreq
if ($typ==101)  connresp
passstruct:
if ($fSyn==1)  structlen
set copy(str, 1, pos($string_end, str)-1) first_
set copy(str, pos($string_end, str)+4, sizeof(str)-sizeof(first_)-4) str
set copy(str, 1, pos($string_end, str)-1) second_
set copy(str, pos($string_end, str)+4, sizeof(str)-sizeof(second_)-4) str
set copy(str, 1, pos($string_end, str)-1) third_
set copy(str, pos($string_end, str), sizeof(str)-sizeof(third_)) str
set copy(str, 1, pos($string_end, str)-1) fourth_
goto packit
structlen:
unbuffer typ 1 size1 1 data_ sizeof(userdata)-2  userdata
unbuffer first_ $size1 size2 1 second_ $size2 size3 1 third_ $size3  size4 1 fourth_ $size4  sizeof(data_)-sizeof(fourth_)-sizeof(third_)-1-sizeof(second_)-1-sizeof(first_)-1   data_
goto packit
packit:
$oBracket 1 $first_ sizeof(first_) $cBracket 1 $oBracket 1 $second_ sizeof(second_) $cBracket 1 $oBracket 1 $third_ sizeof(third_) $cBracket 1 $oBracket 1 $fourth_ sizeof(fourth_) $cBracket 1 (sizeof(data_)+sizeof(first_)+2+sizeof(second_)+2+sizeof(third_)+2+sizeof(fourth_)+2) buffer data_
1 1 $oBracket 1 $data_ sizeof(data_) $cBracket 1 (sizeof(data_)+3)  buffer data_
goto sendpack	
passnum:
if ($fSyn==1) numberlen
unbuffer data_ 2 tmp_ 4  userdata
goto sendpack
numberlen:
unbuffer typ 1 size 1 data_ 1  userdata
$typ 1 $data_ $size ($size+1) buffer data_
goto sendpack
passstr:
if ($fSyn==1) strlen
unbuffer data_ sizeof(userdata)-4 tmp_ 4  userdata
goto sendpack
strlen:
unbuffer typ 1 size 1 data_ sizeof(userdata)-2  userdata
$typ 1 $data_ $size ($size+1)  buffer data_
goto sendpack
passbuf:
if ($fSyn==1) bufferlen
unbuffer data_ sizeof(userdata)-4 tmp_ 4  userdata
goto sendpack
bufferlen:
unbuffer typ 1 size 1 data_ sizeof(userdata)-2  userdata
$typ 1 $data_ $size ($size+1)  buffer data_
goto sendpack
connreq:
unbuffer passSyn 1  data_
set $passSyn & $lSyn fSyn
if ($fSyn != 3)  next
set 1 fSyn
next: 
101 1 $fSyn 1 2 packet buffer 
S_EXPEDITED_DATA.REQ eventdown userdata $packet
goto end
connresp:
unbuffer fSyn 1  data_
$oBracket 1 $cBracket 1 $fSyn 1 3 buffer packet
P_CONNECT.CONF eventup quality $qual_ context $packet 
goto end
sendpack:
P_EXPEDITED_DATA.IND eventup userdata $data_ 
end:
```
## S_GIVE_TOKENS.IND
```
;параметры:  token (число)
P_GIVE_TOKENS.IND eventup token $token 
```
## S_P_ABORT.IND
```
;параметры:  нет
eventup P_P_ABORT.IND
```
## S_P_EXCEPTION.IND
```
;параметры:  error (число)
P_P_EXCEPTION.IND eventup error $error 
```
## S_PLEASE_TOKENS.IND
```
;параметры:  token (число)
P_PLEASE_TOKENS.IND eventup token $token 
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
out "P " CurrentSystemName() ": S_RESYNCHRONIZE.CONF" 
P_RESYNCHRONIZE.CONF eventup token $token
```
## S_RESYNCHRONIZE.IND
```
;параметры:  token (число)
out "P " CurrentSystemName() ": S_RESYNCHRONIZE.IND" 
P_RESYNCHRONIZE.IND eventup token $token 
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
eventup P_U_ABORT.IND
```
# Прикладной уровень
## A_ASSOCIATE.CONF
```
;параметры: context (буфер), quality (буфер), demand (буфер)
out "A_ASSOCIATE.CONF"
if $req_appcon==$GS guideservice
if $req_appcon==$DT datatransfer
goto exit
guideservice:
3 1 $name_resp sizeof(name_resp) sizeof(name_resp)+1 buffer cur_buf
P_DATA.REQ eventdown userdata $cur_buf
timerT timer 10  TIMER_SYNCRON
goto exit
datatransfer:
A_TRANSFER_INIT.CONF eventup context $context quality $quality
goto exit
exit:
```
## A_ASSOCIATE.IND
```
;параметры: namei (буфер), quality (буфер), apcon (строка)
out "A_ASSOCIATE.IND"
A_TRANSFER_INIT.IND eventup namei $local_name quality $quality
```
## A_ASSOCIATE.REQ
```
;параметры: namer (буфер), namei (буфер), quality (буфер), demand (буфер), context (буфер), apcon (строка)
out "A " CurrentSystemName() " | ЭСУА: A_ASSOCIATE.REQ: " $apcon " " $local_addr 
set $apcon req_appcon
set $req_appcon local_appcon
P_CONNECT.REQ eventdown address $local_addr quality $quality demand $demand context $context
```
## A_ASSOCIATE.RESP
```
;параметры: namei (буфер), context (буфер), quality (буфер), apcon (строка)
out "A_ASSOCIATE.RESP"
unbuffer local_addr 1 local_name sizeof(namei)-1 namei
P_CONNECT.RESP eventdown address $local_addr quality $quality context $context
```
## A_DATA.REQ
```
;параметры: userdata(буфер)
out "A_DATA.REQ"
cur_queue queuevalue $userdata
P_PLEASE_TOKENS.REQ eventdown token 1
```
## A_INIT.REQ
```
declare integer dict_flag 
set 0 dict_flag
declare string total_name 
declare integer current_id 
declare integer current_t1 
declare integer current_t2 
declare string current_s1 
declare string current_s2 
declare string req_appcon 
declare buffer cur_buf 
declare buffer cur_buf_2 
declare integer reqID 
declare integer reqAddr 
declare integer T1_req 
declare integer T2_req 
declare string S1_req 
declare string S2_req 
declare integer respId 
declare integer respAddr 
declare integer T1resp 
declare integer T2resp 
declare string S1resp 
declare string S2resp 
declare integer local_addr 
declare string local_name 
declare buffer local_context 
declare buffer local_quality_ 
declare buffer local_dem 
1 1 1  buffer local_dem
declare string local_appcon 
declare string name_req 
declare string name_resp 
declare integer timerT 
declare integer ttimerT 
declare integer size 
declare integer size2 
declare integer size3 
declare integer type 
declare queue cur_queue 
declare integer givenId 
declare integer givenAddr 
declare string given_name 
declare integer T1_given 
declare integer T2_given 
declare string S1_given 
declare string S2_given 
declare buffer ssBuf 
declare integer idSS 
declare integer ssAddr 
declare integer ssT1 
declare integer ssT2 
declare string ssS1 
declare string ssS2 
declare buffer namer_ 
declare buffer namei_ 
declare string GS 
set "GS" GS
declare string DT 
set "DT" DT
declare string AP 
set "AP" AP
declare string name_dict 
set "Guide" name_dict
set locguide($name_dict) cur_buf
unbuffer current_id 1 local_addr 1 current_t1 1 current_t2 1 current_s1 1 current_s2 1 cur_buf
declare buffer dict_buffer 
$local_addr 1 $name_dict sizeof(name_dict) sizeof(name_dict)+1 buffer dict_buffer
```
## A_RELEASE.CONF
```
;параметры: apcon (строка)
out "A_RELEASE.CONF"
if $apcon==$GS guideservice
if $apcon==$DT datatransfer
guideservice:
set 1 dict_flag
$current_id 1 $respAddr 1 $current_s1 1 $current_s2 1 4 buffer cur_buf
timerT timer 1 address $cur_buf A_RESOLVE.IND
goto exit
datatransfer:
A_TERMINATE.CONF eventup address $respAddr
exit:
```
## A_RELEASE.IND
```
;параметры: apcon (строка)
out "A_RELEASE.IND"
eventup A_TERMINATE.IND
```
## A_RELEASE.REQ
```
;параметры: apcon (строка)
out "A " CurrentSystemName() " | ЭСУА: A_RELEASE.REQ: " $req_appcon
set $apcon req_appcon
eventdown P_RELEASE.REQ
```
## A_RELEASE.RESP
```
;параметры: apcon (строка)
out "A_RELEASE.RESP"
eventdown P_RELEASE.RESP
```
## A_RESOLVE.IND
```
;параметры: address (буфер)
out "A_RESOLVE.IND"
unbuffer respId 1 respAddr 1 S1resp 1 S2resp 1 address
$name_resp sizeof(name_resp) $respAddr 1 sizeof(name_resp)+1 buffer cur_buf
$name_req sizeof(name_req) $reqAddr 1 sizeof(name_req)+1 buffer cur_buf_2
timerT timer 1 namer $cur_buf namei $cur_buf_2 quality $local_quality_ demand $local_dem context $local_context apcon $DT A_ASSOCIATE.REQ
```
## A_RESOLVE.REQ
```
;параметры: name (строка)
if $dict_flag==1 saved_address
set locguide($name) cur_buf
set $name total_name
unbuffer current_id 1 respAddr 1 current_t1 1 current_t2 1 current_s1 1 current_s2 1 cur_buf
out "A " CurrentSystemName() " | СЭПС СС: A_RESOLVE.REQ: " $total_name " " $current_id " " $respAddr 
goto type
saved_address:
set $given_name total_name
set $givenAddr respAddr
set $givenId current_id
out "A " CurrentSystemName() " | СЭПС СС: A_RESOLVE.REQ: saved_address " $total_name " " $current_id " " $respAddr 
type:
if $current_id==0 ok
if $current_id==1 aftertime
if $current_id==2 betweentime
if $current_id==3 notime
if $current_id==4 bracketswap
goto exit
ok:
set $DT req_appcon
set $DT local_appcon
locguide($name_req) 1 $name_req sizeof(name_req) sizeof(name_req)+1 buffer cur_buf_2
timerT timer 1 namer $dict_buffer namei $cur_buf_2 quality $local_quality_ demand $local_dem context $local_context apcon "DT" A_ASSOCIATE.REQ
goto exit
aftertime:
betweentime:
timerT timer $current_t1 name $total_name A_RESOLVE.REQ
goto exit
notime:
set $GS local_appcon
locguide($name_req) 1 $name_req sizeof(name_req) sizeof(name_req)+1 buffer namei_
timerT timer 1 namer $namer_ namei $namei_ quality $local_quality_ demand $local_dem context $local_context apcon "GS" A_ASSOCIATE.REQ
goto exit
bracketswap:
timerT timer 1 name (copy(total_name, 1, pos($current_s1, total_name)-1)+$current_s2+copy(total_name, pos($current_s1, total_name)+1,  sizeof(total_name)-pos($current_s1, total_name)))  A_RESOLVE.REQ
exit:
```
## A_TERMINATE.REQ
```
;параметры: нет
out "A " CurrentSystemName() " | СЭПС DT: A_TERMINATE.REQ: " $name_req " " $respAddr
timerT timer 1 apcon $req_appcon A_RELEASE.REQ
```
## A_TERMINATE.RESP
```
out "A_TERMINATE.RESP"
timerT timer 1 apcon "DT" A_RELEASE.RESP
```
## A_TRANSFER_INIT.REQ
```
;параметры: namer (строка), namei (строка), context (буфер), quality (буфер)
out "A " CurrentSystemName() " | СЭПС DT: A_TRANSFER_INIT.REQ: " $namei " " $namer
set locguide($namei) cur_buf
set $namei name_req
unbuffer reqID 1 reqAddr 1 T1_req 1 T2_req 1 S1_req 1 S2_req 1 cur_buf
set locguide($namer) cur_buf
set $namer name_resp
unbuffer respId 1 respAddr 1 T1resp 1 T2resp 1 S1resp 1 S2resp 1 cur_buf
set $quality local_quality_
set $context local_context
timerT timer 1 name $namer  A_RESOLVE.REQ
```
## A_TRANSFER_INIT.RESP
```
;параметры: namei (строка), context (буфер), quality (буфер)
out "A_TRANSFER_INIT.RESP"
set locguide($namei) cur_buf
set $quality local_quality_
set $context local_context
unbuffer reqID 1 reqAddr 1 T1_req 1 T2_req 1 S1_req 1 S2_req 1 cur_buf
$respAddr 1 $name_resp sizeof(name_resp) sizeof(name_resp)+1 buffer cur_buf
timerT timer 1 namei $cur_buf context $local_context quality $local_quality_ apcon $local_appcon A_ASSOCIATE.RESP
```
## P_CONNECT.CONF
```
;параметры:  quality (буфер), context (буфер)
out "A " CurrentSystemName() " | ЭСУА: P_CONNECT.CONF: "
timerT timer 1 context $context quality $quality demand $local_dem A_ASSOCIATE.CONF
```
## P_CONNECT.IND
```
;параметры:  address (число), quality (буфер), demand (буфер)
out "P_CONNECT.IND"
set locguide($address) name_resp
set $address respAddr
set $DT local_appcon
$address 1 $name_resp sizeof(name_resp) sizeof(name_resp)+1 buffer cur_buf
timerT timer 1 namei $cur_buf quality $quality apcon $local_appcon A_ASSOCIATE.IND
```
## P_DATA.IND
```
;параметры:  userdata (буфер)
if $local_appcon==$GS guideservice
if $local_appcon==$DT datatransfer
goto exit
guideservice:
unbuffer type 1 current_id 1 local_addr 1 current_t1 1 current_t2 1 current_s1 1 current_s2 1 userdata
out "A " CurrentSystemName() " | ПРИКЛАДНОЙ: P_DATA.IND: " $local_appcon " " $name_resp  " " $local_addr
if $current_id==0 ok
if $current_id==1 aftertime
if $current_id==2 betweentime
if $current_id==3 err1
if $current_id==4 err2
goto exit
ok:
set $current_id givenId
set $local_addr givenAddr
timerT timer 1 apcon $GS A_RELEASE.REQ
goto exit
aftertime:
betweentime:
out "A " CurrentSystemName() " | ПРИКЛАДНОЙ: P_DATA.IND: aftertime betweentime " $current_t1 " " $current_t2
3 1 $name_resp sizeof(name_resp) sizeof(name_resp)+1 buffer cur_buf
timerT timer 1 token 1 TIMER_MARKERS
timerT timer 3 token 2 TIMER_MARKERS
timerT timer $current_t1+1 userdata $cur_buf TIMER_DATA
ttimerT timer $current_t1+11  TIMER_SYNCRON
goto exit
err1:
out "Error! Name is unknown"
goto exit
err2:
out "Parenthesis error!"
goto exit
datatransfer:
out "A " CurrentSystemName() " | ПРИКЛАДНОЙ: P_DATA.IND: sendup A_DATA.IND"
A_DATA.IND eventup userdata $userdata
goto exit
exit:
```
## P_GIVE_TOKENS.IND
```
;параметры:  token (число)
out "A " CurrentSystemName() " | ПРИКЛАДНОЙ: P_GIVE_TOKENS.IND " $token
if $token==2 sync
data:
if ((qcount(cur_queue))==0) pleaseTokens
P_DATA.REQ eventdown userdata (dequeue(cur_queue))
out "A " CurrentSystemName() " | ПРИКЛАДНОЙ: P_GIVE_TOKENS.IND " $token " send data"
goto data
pleaseTokens:
P_PLEASE_TOKENS.REQ eventdown token 2
goto exit
sync:
eventdown P_SYNC_MAJOR.REQ
exit:
```
## P_P_ABORT.IND
```
;параметры:  нет
out "A " CurrentSystemName() " P_P_ABORT.IND: " $req_appcon
A_P_ABORT.IND eventup apcon $req_appcon
```
## P_PLEASE_TOKENS.IND
```
;параметры:  token (число)
out "A " CurrentSystemName() " | ПРИКЛАДНОЙ: P_PLEASE_TOKENS.IND: " $token 
P_GIVE_TOKENS.REQ eventdown token $token
```
## P_RELEASE.CONF
```
;параметры:  нет
out "P_RELEASE.CONF"
timerT timer 1 apcon $req_appcon A_RELEASE.CONF
```
## P_RELEASE.IND
```
;параметры:  нет
out "P_RELEASE.IND"
timerT timer 1 apcon $DT A_RELEASE.IND
```
## P_SYNC_MAJOR.CONF
```
;параметры:  нет
out "A " CurrentSystemName() " | ПРИКЛАДНОЙ: P_SYNC_MAJOR.CONF: "
```
## P_SYNC_MAJOR.IND
```
;параметры:  нет
out "A " CurrentSystemName() " | ПРИКЛАДНОЙ: P_SYNC_MAJOR.IND: "
eventdown P_SYNC_MAJOR.RESP
```
## TIMER_DATA
```
out "A " CurrentSystemName() " | ПРИКЛАДНОЙ: TIMER_SENDDATA: "
P_DATA.REQ eventdown userdata $userdata
```
## TIMER_MARKERS
```
; параметр token (integer)
out "A " CurrentSystemName() " | ПРИКЛАДНОЙ: TIMER_SENDPLS: " $token
P_PLEASE_TOKENS.REQ eventdown token $token
```
## TIMER_SYNCRON
```
out "A " CurrentSystemName() " | ПРИКЛАДНОЙ: TIMER_SYNC: "
eventdown P_SYNC_MAJOR.REQ
```
# Сеансовый уровень
## S_CONNECT.REQ
```
;параметры:  address (число), quality (буфер), demand (буфер)
out "S " CurrentSystemName() ": S_CONNECT.REQ"
unbuffer tokens 1  demand
set $address addr
set $quality quality_
T_CONNECT.REQ eventdown address $addr 
reconnectTimer timer 260  TIMER_RECONNECT
set 1 connecting
set 1 isConnectionInit
set 1 connectionTry
```
## S_CONNECT.RESP
```
;параметры:  address (число), quality (буфер)
out "S " CurrentSystemName() ": S_CONNECT.RESP"
2 1 $quality sizeof(quality) sizeof(quality)+1 package buffer 
T_DATA.REQ eventdown userdata $package 
set 0 disconnHard
```
## S_DATA.REQ
```
;параметры:   userdata (буфер)
out "S " CurrentSystemName() ": S_DATA.REQ"
set 0 sync
set 0 resync
crc crcoutpackage $userdata 
set $sumOutCrc+$crcoutpackage sumOutCrc
outQueue queuevalue $userdata
if ($hasDataToken==0)  noDtoken
	3 1 $userdata sizeof(userdata) sizeof(userdata)+1 package buffer 
	T_DATA.REQ eventdown userdata $package 
	goto end 
noDtoken: 
	if ($sentDataToken==1)  tokenislost
	S_P_EXCEPTION.IND eventup error 1 
	set 1 sentDataToken
	goto end 
tokenislost:  
	out "S " CurrentSystemName() ": S_DATA.REQ: token_lost"
	if ($isLostToken==1)  end
		set 1 isLostToken
		out "S " CurrentSystemName() ": S_DATA.REQ: token_lost: send"
		6 1 0 1 2 package buffer 
		T_DATA.REQ eventdown userdata $package 
end:
```
## S_EXPEDITED_DATA.REQ
```
;параметры:   userdata (буфер)-данные
out "S " CurrentSystemName() ": S_EXPEDITED_DATA.REQ: "
9 1 $userdata sizeof(userdata) sizeof(userdata)+1 package buffer 
T_DATA.REQ eventdown userdata $package 
```
## S_GIVE_TOKENS.REQ
```
;параметры:  token (число)
if ($token==1)  Dtoken
if ($token==2) Stoken
Dtoken: 
	if ($hasDataToken==0)  errortoken
	set 0 hasDataToken
	set 0 sentDataToken
	set ($wait_token / 2) wait_token
	goto continue
Stoken: 
	if ($hasSyncToken==0)  errortoken
	set 0 hasSyncToken
	set 0 sentSyncToken
	set ($wait_token % 2) wait_token
	goto continue
continue: 
	out "S " CurrentSystemName() ": S_GIVE_TOKENS.REQ " $token 
	8 1 $token 1 2 package buffer 
	T_DATA.REQ eventdown userdata $package 
	goto end
errortoken: 
	out "S " CurrentSystemName() ": S_GIVE_TOKENS.REQ errortoken " $token 
	set 0 wait_token
	S_P_EXCEPTION.IND eventup error 3 
end:
```
## S_INIT.REQ
```
declare integer tokens 
declare integer hasDataToken 
declare integer hasSyncToken 
declare integer sentDataToken 
declare integer sentSyncToken 
declare integer addr 
declare integer reconnectTimer
declare integer connectionTry 
declare buffer quality_ 
1 1 1 1 2 buffer quality_
declare buffer package 
declare integer type 
declare buffer data 
declare integer isConnectionInit 
declare integer crcoutpackage 
declare queue outQueue 
declare queue inQueue 
declare buffer inQueuedata
declare buffer outQueuedata 
declare integer upinQueuecount 
declare integer resyncoutQueuecount 
declare integer sumOutCrc 
declare integer sumInCrc 
declare integer sumReqCrc 
declare integer sendinQueuetimer  
declare integer sendoutQueuetimer  
declare integer connecting 
declare integer disconnDelayTimer 
declare integer sync 
declare integer resync 
declare integer reqToken 
declare integer givenToken 
declare integer wait_token
declare integer isLostToken
declare integer resyncTokens 
declare integer disconnUser 
declare integer initTimer 
declare integer disconnNormTimer  
declare integer disconnNormTry  
declare integer disconnHard
```
## S_PLEASE_TOKENS.REQ
```
;параметры:  token (число): 1-маркер данных, 2-маркер синхронизации
if ((($hasDataToken==1) && ($token==1)) || (($hasSyncToken==1) && ($token==2)))  givetoken
	set $token reqToken
	out "S " CurrentSystemName() ": S_PLEASE_TOKENS.REQ " $token " " $hasDataToken " " $hasSyncToken
	7 1 $token 1 2 package buffer 
	T_DATA.REQ eventdown userdata $package 
	if ($token==1)  Dtoken
	if ($token==2)  Stoken
	Dtoken: 
		set 1 sentDataToken
		goto end 
	Stoken: 
		set 1 sentSyncToken
		goto end 
givetoken: 
	S_GIVE_TOKENS.IND eventup token $token 
end:
```
## S_RELEASE.REQ
```
;параметры:  нет
set 1 disconnUser
if (qcount(outQueue)>0)  wait
	out "S " CurrentSystemName() ": S_RELEASE.REQ: send"
	12 1 0 1 2 package buffer 
	T_DATA.REQ eventdown userdata $package 
	goto end
wait: 
	out "S " CurrentSystemName() ": S_RELEASE.REQ: wait"
	disconnNormTimer timer 250  TIMER_NORM_DISCONNECT
	set 3 disconnNormTry
end:
```
## S_RELEASE.RESP
```
;параметры:  нет
if (qcount(outQueue)>0)   wait
	out "S " CurrentSystemName() ": S_RELEASE.RESP: send"
	T_DISCONNECT.REQ eventdown address $addr 
	initTimer timer 1  TIMER_INIT
	goto end 
wait: 
	out "S " CurrentSystemName() ": S_RELEASE.RESP: wait"
	disconnNormTimer timer 250  TIMER_NORM_DISCONNECT
	set 3 disconnNormTry
end:
```
## S_RESYNCHRONIZE.REQ
```
;параметры:  token (число): 1-маркер данных, 2-маркер синхронизации
out "S " CurrentSystemName() ": S_RESYNCHRONIZE.REQ: " $token 
10 1 $token 1 2 package buffer 
T_DATA.REQ eventdown userdata $package 
set 0 sumInCrc
clearqueue inQueue 
set 1 resync
```
## S_RESYNCHRONIZE.RESP
```
;параметры:  token (число): 1-маркер данных, 2-маркер синхронизации
out "S " CurrentSystemName() ": S_RESYNCHRONIZE.RESP: " $token 
11 1 $token 1 $sumOutCrc 1 3 package buffer 
T_DATA.REQ eventdown userdata $package 
subprog setTokensResync
set $token resyncTokens
set 0 resync 
return
;------------------------
; расположить маркеры, которые будут активны после ресинхронизации
; значение $token уже инвертировано при приёме resyncreq
;------------------------
substart setTokensResync
if ($token==1) Dtoken
if ($token==2) Stoken
if ($token==3)  SDtoken
if ($token==4)  notoken
SDtoken: 
	set 1 hasDataToken
	set 1 hasSyncToken
	set 1 sentDataToken
	set 1 sentSyncToken
	goto end 
notoken: 
	set 0 hasDataToken
	set 0 hasSyncToken
	set 0 sentDataToken
	set 0 sentSyncToken
	goto end 
Dtoken: 
	set 1 hasDataToken
	set 0 hasSyncToken
	set 1 sentDataToken
	set 0 sentSyncToken
	goto end 
Stoken: 
	set 0 hasDataToken
	set 1 hasSyncToken
	set 0 sentDataToken
	set 1 sentSyncToken
end:
```
## S_SYNC_MAJOR.REQ
```
;параметры:  нет
if ($resync==1)  end
if ($hasSyncToken==0) noStoken
	out "S " CurrentSystemName() ": S_SYNC_MAJOR.REQ: "
	4 1 $sumOutCrc 1 2 package buffer 
	T_DATA.REQ eventdown userdata $package 
	set 1 sync
	goto end 
noStoken: 
	if ($sentSyncToken==1)  tokenislost
		S_P_EXCEPTION.IND eventup error 2 
		set 1 sentSyncToken
		goto end 
tokenislost: 
	out "S " CurrentSystemName() ": S_SYNC_MAJOR.REQ: token_lost"
	if ($isLostToken==1)  end
		set 1 isLostToken
		out "S " CurrentSystemName() ": S_SYNC_MAJOR.REQ: token_lost: send"
		6 1 0 1 2 package buffer 
		T_DATA.REQ eventdown userdata $package 
end: 
```
## S_SYNC_MAJOR.RESP
```
;параметры:  нет
out "S " CurrentSystemName() ": S_SYNC_MAJOR.RESP: " 
5 1 1 1 2 package buffer 
T_DATA.REQ  eventdown userdata $package 
set 0 sumInCrc
```
## S_U_ABORT.REQ
```
;параметры:  нет
out "S " CurrentSystemName() ": S_U_ABORT.REQ: "
13 1 0 1 2 package buffer 
T_DATA.REQ eventdown userdata $package 
set 1 disconnHard
```
## T_CONNECT.CONF
```
;параметры:  address (число) 
out "S " CurrentSystemName() ": T_CONNECT.CONF"
1 1 $tokens 1 2 package buffer 
T_DATA.REQ eventdown userdata $package 
if ($tokens==1) DStoken
if ($tokens==2) notoken
if ($tokens==3)  Dtoken
if ($tokens==4)  Stoken
DStoken: 
	set 1 hasDataToken
	set 1 hasSyncToken
	set 1 sentDataToken
	set 1 sentSyncToken
	goto end 
notoken: 
	set 0 hasDataToken
	set 0 hasSyncToken
	goto end 
Dtoken: 
	set 1 hasDataToken
	set 0 hasSyncToken
	set 1 sentDataToken
	goto end 
Stoken: 
	set 0 hasDataToken
	set 1 hasSyncToken
	set 1 sentSyncToken
end:
```
## T_CONNECT.IND
```
;параметры:  address (число) 
out "S " CurrentSystemName() ": T_CONNECT.IND"
set $address addr
T_CONNECT.RESP eventdown address $address 
```
## T_DATA.IND
```
;параметры:  userdata (буфер)-данные
;out "S " CurrentSystemName() ": T_DATA.IND " sizeof(userdata)
if (sizeof(userdata)<2)  end
unbuffer type 1 data sizeof(userdata)-1  userdata
;out "S " CurrentSystemName() ": T_DATA.IND " $type " " $wait_token " " sizeof(userdata)
if (($type==4) || ($type==5) || ($type==7) || ($type==8) || ($type==9)) no_debug
	out "S " CurrentSystemName() ": T_DATA.IND " $type ;" " $wait_token 
no_debug:
if ($type==1)  paramoffer
if ($type==2)  paramconfirm
if ($type==3)  datapack
if ($type==4)  majorsyncreq
if ($type==5)  majorsyncconf
if ($type==6)  syncerror
if ($type==7)  tokenrequest
if ($type==8)  tokengive
if ($type==9)  expediteddata
if ($type==10)  resyncreq
if ($type==11)  resyncresp
if (($type==12) && ($disconnUser==0))  normdisconreq
if ($type==13)  unconddisconreq
out "Неизвестный тип пакета" 
goto end 
paramoffer: 
S_CONNECT.IND eventup address $addr quality $quality_ demand $data 
unbuffer tokens 1  data
if ($tokens==1)  notoken
if ($tokens==2)  DStoken
if ($tokens==3)  Stoken
if ($tokens==4)  Dtoken
DStoken: 
set 1 hasDataToken
set 1 hasSyncToken
set 1 sentDataToken
set 1 sentSyncToken
goto end 
notoken: 
set 0 hasDataToken
set 0 hasSyncToken
goto end 
Dtoken: 
set 1 hasDataToken
set 0 hasSyncToken
set 1 sentDataToken
goto end 
Stoken: 
set 0 hasDataToken
set 1 hasSyncToken
set 1 sentSyncToken
goto end 
paramconfirm: 
S_CONNECT.CONF eventup quality $data 
untimer $reconnectTimer
set 0 connecting
goto end 
datapack: 
set 0 sync
crc crcoutpackage $data 
set $sumInCrc+$crcoutpackage sumInCrc
inQueue queuevalue $data
goto end 
majorsyncreq: 
out "S " CurrentSystemName() ": T_DATA.IND " $type " " $sync
if ($sync==1)  end
	set 1 sync
	set 0 resync
	unbuffer sumReqCrc 1  data
	if ($sumReqCrc != $sumInCrc)  syncerror
		S_SYNC_MAJOR.IND eventup 
		set qcount(inQueue) upinQueuecount
		sendinQueuetimer timer 1  TIMER_SEND_INQUEUE
		goto end 
majorsyncconf: 
out "S " CurrentSystemName() ": T_DATA.IND " $type " " $sync
if ($sync==0)  end
	set 0 sumOutCrc
	clearqueue outQueue 
	S_SYNC_MAJOR.CONF eventup 
	set 0 sync
	set 0 isLostToken
	goto end 
syncerror: 
	out "S " CurrentSystemName() ": T_DATA.IND sync_error " $type
	S_P_EXCEPTION.IND eventup error 3 
	goto end 
tokenrequest: 
	unbuffer reqToken 1  data
	;out "S " CurrentSystemName() ": T_DATA.IND " $type " " $reqToken " " $wait_token " " $hasDataToken " " $hasSyncToken
	if (($reqToken==1) && (($hasDataToken==0) || (($wait_token % 2)==1))) end
	if (($reqToken==2) && (($hasSyncToken==0) || (($wait_token / 2)==1))) end
	set ($wait_token | $reqToken) wait_token	
	set 0 sync
	out "S " CurrentSystemName() ": T_DATA.IND " $type " " $reqToken
	S_PLEASE_TOKENS.IND eventup token $reqToken
	set 0 sumOutCrc
	clearqueue outQueue 
	goto end 
tokengive: 
	unbuffer givenToken 1  data
	if ((($givenToken==1) && ($hasDataToken==1)) || (($givenToken==2) && ($hasSyncToken==1)))  end
	if ($givenToken==1)  giveDtoken
	if ($givenToken==2)  giveStoken
	giveDtoken: 
		if ($hasDataToken==1)  hadtoken
			set 1 hasDataToken
			goto givetoken
	giveStoken: 
		if ($hasSyncToken==1)  hadtoken
			set 1 hasSyncToken
			goto givetoken
	givetoken: 
		out "S " CurrentSystemName() ": T_DATA.IND " $type " " $givenToken
		S_GIVE_TOKENS.IND eventup token $givenToken 
		goto end 
	hadtoken: 
		S_P_EXCEPTION.IND eventup error 3 
	goto end 
expediteddata: 
	out "S " CurrentSystemName() ": T_DATA.IND " $type
	S_EXPEDITED_DATA.IND eventup userdata $data
	goto end 
resyncreq: 
	if ($resync==1)  end
		set 0 sumOutCrc
		if ($isLostToken==1) resync_request_continue
			unbuffer resyncTokens 1  data
			out "S " CurrentSystemName() ": resyncTokens was " $resyncTokens
			subprog inverseTokens
			out "S " CurrentSystemName() ": resyncTokens become " $resyncTokens
		resync_request_continue:
			set qcount(outQueue) resyncoutQueuecount
			sendoutQueuetimer timer 1  TIMER_SEND_OUTQUEUE
			set 1 resync
			goto end 
resyncresp: 
	if ($resync==0)  end
		unbuffer resyncTokens 1 sumReqCrc 1 data
		out "S " CurrentSystemName() ": resyncTokens was " $resyncTokens
		subprog inverseTokens
		out "S " CurrentSystemName() ": resyncTokens become " $resyncTokens
		if ($sumReqCrc != $sumInCrc)  syncerror
			out "S " CurrentSystemName() ": контрольные суммы совпали"
		set 0 sync
		set 0 resync
		S_RESYNCHRONIZE.CONF eventup token $resyncTokens
		S_SYNC_MAJOR.IND eventup 
		set qcount(inQueue) upinQueuecount
		sendinQueuetimer timer 1  TIMER_SEND_INQUEUE
		subprog setTokensResync		
		return
normdisconreq: 
	set 1 disconnUser
	S_RELEASE.IND eventup 
	goto end 
unconddisconreq: 
	S_U_ABORT.IND eventup 
	T_DISCONNECT.REQ eventdown address $addr 
	initTimer timer 1  TIMER_INIT
	goto end 
end: 
	return
;------------------------
; код маркеров ресинхронизации в то, что достается этой стороне
;------------------------
substart inverseTokens
if $resyncTokens==1 inv_data_
if $resyncTokens==2 inv_sync_
if $resyncTokens==3 inv_all_
if $resyncTokens==4 inv_none_
	goto inv_end_
inv_data_:
	set 2 resyncTokens
	goto inv_end_
inv_sync_:
	set 1 resyncTokens
	goto inv_end_
inv_all_:
	set 4 resyncTokens
	goto inv_end_
inv_none_:
	set 3 resyncTokens
	goto inv_end_
inv_end_:
subend
;------------------------
; расположить маркеры, которые будут активны после ресинхронизации
; значение $token уже инвертировано при приёме resyncreq
;------------------------
substart setTokensResync
if ($resyncTokens==1)  rrDtoken
if ($resyncTokens==2)  rrStoken
if ($resyncTokens==3)  rrDStoken
if ($resyncTokens==4)  rrnotoken
rrDStoken: 
set 1 hasDataToken
set 1 hasSyncToken
set 1 sentDataToken
set 1 sentSyncToken
goto end 
rrnotoken: 
set 0 hasDataToken
set 0 hasSyncToken
set 0 sentDataToken
set 0 sentSyncToken
goto end 
rrDtoken: 
set 1 hasDataToken
set 1 sentDataToken
set 0 hasSyncToken
set 0 sentSyncToken
goto end 
rrStoken: 
set 0 hasDataToken
set 0 sentDataToken
set 1 hasSyncToken
set 1 sentSyncToken
goto end 
```
## T_DISCONNECT.IND
```
;параметры:  нет 
out "S " CurrentSystemName() ": T_DISCONNECT.IND"
if (($disconnUser==1) || ($disconnHard==1))  usersdiscon
if $connecting  end
	S_P_ABORT.IND eventup 
	initTimer timer 1  TIMER_INIT
	goto end 
usersdiscon: 
	if $disconnHard  abort
		S_RELEASE.CONF eventup 
abort: 
	initTimer timer 1  TIMER_INIT
end: 
```
## TIMER_INIT
```
out "S " CurrentSystemName() ": TIMER_INIT "
set 0 hasDataToken
set 0 hasSyncToken
untimer $reconnectTimer
untimer $disconnDelayTimer 
set 0 sumInCrc
set 0 sumOutCrc
set 0 sumReqCrc
clearqueue outQueue 
clearqueue inQueue 
untimer $sendinQueuetimer  
untimer $sendoutQueuetimer  
set 0 sync
set 0 resync
set 0 sentDataToken
set 0 sentSyncToken
set 0 disconnHard
set 0 disconnUser
set 0 initTimer
untimer $disconnNormTimer  
set 0 connecting
```
## TIMER_NORM_DISCONNECT
```
out "S " CurrentSystemName() ": TIMER_NORM_DISCONNECT "
if ($disconnNormTry==0)  stoptrytodiscon
if (qcount(outQueue)>0)   wait
if ($isConnectionInit==1)  request
	T_DISCONNECT.REQ eventdown address $addr 
	initTimer timer 1  TIMER_INIT
	goto end 
request: 
	out "S " CurrentSystemName() ": TIMER_NORM_DISCONNECT req"
	12 1 0 1 2 package buffer 
	T_DATA.REQ eventdown userdata $package 
	goto end 
wait: 
	disconnNormTimer timer 250  TIMER_NORM_DISCONNECT
	set $disconnNormTry-1 disconnNormTry
	goto end 
stoptrytodiscon: 
	if ($isConnectionInit==0)  end
		S_P_ABORT.IND eventup 
		T_DISCONNECT.REQ eventdown address $addr 
		initTimer timer 1  TIMER_INIT
end: 
```
## TIMER_RECONNECT
```
out "S " CurrentSystemName() ": TIMER_RECONNECT " $connectionTry
if ($connectionTry>3) stoptryconn
	T_DISCONNECT.REQ eventdown address $addr 
	T_CONNECT.REQ eventdown address $addr 
	reconnectTimer timer 285  TIMER_RECONNECT
	out CurrentSystemName () ": повторная попытка соединения " $connectionTry 
	set $connectionTry+1 connectionTry
	goto end 
stoptryconn: 
	S_P_ABORT.IND eventup 
end:
```
## TIMER_SEND_INQUEUE
```
out "S " CurrentSystemName() ": TIMER_SEND_INQUEUE"
if ($upinQueuecount==0)  end
	set dequeue(inQueue) inQueuedata
	S_DATA.IND eventup userdata $inQueuedata
	sendinQueuetimer timer 1  TIMER_SEND_INQUEUE
	set $upinQueuecount-1 upinQueuecount
end:
```
## TIMER_SEND_OUTQUEUE
```
out "S " CurrentSystemName() ": TIMER_SEND_OUTQUEUE"
if ($resyncoutQueuecount==0)  empty
	set dequeue(outQueue) outQueuedata
	crc crcoutpackage $outQueuedata 
	set $sumOutCrc+$crcoutpackage sumOutCrc
	outQueue queuevalue $outQueuedata
	3 1 $outQueuedata sizeof(outQueuedata) sizeof(outQueuedata)+1 package buffer 
	T_DATA.REQ eventdown userdata $package 
	sendoutQueuetimer timer 1  TIMER_SEND_OUTQUEUE
	set $resyncoutQueuecount-1 resyncoutQueuecount
	goto end 
empty: 
	if ($isLostToken==0) continue
		set 4 resyncTokens
		out "S " CurrentSystemName() ": TIMER_SEND_OUTQUEUE: lost_token "
		set 1 sync
	continue:
		S_RESYNCHRONIZE.IND eventup token $resyncTokens
end:
```
# Транспортный уровень
## N_CONNECT.CONF
```
;параметры:  address (число)
out "T " CurrentSystemName() ": N_CONNECT.CONF" 
set 1 connection
untimer $reconnectTimer
if $keepTransport==1 keep_transport
	T_CONNECT.CONF eventup address $address 
	return
keep_transport:
	out "T " CurrentSystemName() ": соединение после случайного разрыва" 
	set 1 resendTry
	set 0 keepTransport
```
## N_CONNECT.IND
```
;параметры:  address (число)
out "T " CurrentSystemName() ": N_CONNECT.IND " $keepTransport
set 0 isConnInitiator
set 1 connection
if $keepTransport==1  keep_transport
	T_CONNECT.IND eventup address $address 
	set 0 normallyDisconnected
	return
keep_transport:
	N_CONNECT.RESP eventdown address $address
	set 1 resendTry
	set 0 keepTransport
```
## N_DATA.IND
```
;параметры:  userdata (буфер)
if $connection==0  exit
if sizeof(userdata)<3  exit
	unbuffer dataCrcIn 1 package_inc sizeof(userdata)-1  userdata
	crc dataCrcCalc $package_inc
if $dataCrcIn != $dataCrcCalc  badcrc
	unbuffer type 1 num 1 data sizeof(package_inc)-2  package_inc
	if $type==1  disconn_req
	if $type==2  conf
		2 1 $num 1 0 1 3  buffer package_conf
		crc package_crc $package_conf
		$package_crc 1 $package_conf sizeof(package_conf) sizeof(package_conf)+1 buffer package_conf
		N_DATA.REQ eventdown userdata $package_conf
		if $num<$inc_num  dublicate
			out "T " CurrentSystemName() ": N_DATA.IND " $type
			set $num+1 inc_num
			out "T " CurrentSystemName() ": N_DATA.IND T_DATA.IND now" $type
			T_DATA.IND eventup userdata $data
			return
conf:
	out "T " CurrentSystemName() ": N_DATA.IND " $type " " $num 
	if $num<$inc_num_conf  dublicate
		set $num+1 inc_num_conf
		untimer $resend_timer
		if qcount (package_queue)>0  send_from_queue
			set 0 is_sending_data
			return
send_from_queue:
	out "T " CurrentSystemName() ": N_DATA.IND "  $type "send_from_queue" 
	set dequeue (package_queue) packageFromQueue
	3 1 $out_num 1 $packageFromQueue sizeof(packageFromQueue) sizeof(packageFromQueue)+2  buffer package
	set $out_num+1 out_num
	crc package_crc $package
	$package_crc 1 $package sizeof(package) sizeof(package)+1  buffer package_send
	N_DATA.REQ eventdown userdata $package_send
	resend_timer timer $time_resend TIMER_RESEND
	set 1 resendTry
	return
disconn_req:
	out "T " CurrentSystemName() ": N_DATA.IND " $type
	set 1 waitDisconn
	set 1 normallyDisconnected
	return
badcrc:
	;out "неверная контрольная сумма"
	return
dublicate:
	out "T " CurrentSystemName() ": N_DATA.IND " $type " dublicate"
exit:
```
## N_DISCONNECT.IND
```
;параметры:  нет
out "T " CurrentSystemName() ": N_DISCONNECT.IND" 
set 0 connection
if $waitDisconn==0  unexp_disconn
	initTimer timer 1 TIMER_INIT
	eventup T_DISCONNECT.IND
	return
unexp_disconn:
	out "T " CurrentSystemName() ": N_DISCONNECT.IND: unexp_disconn" 
	set 1 keepTransport
	if $isConnInitiator==0  exit
		N_CONNECT.REQ eventdown address $addr
		reconnectTimer timer $reconnectTime TIMER_RECONNECT
		set 1 resendTry
		set 1 connectionTry
		return
exit:
	return
```
## T_CONNECT.REQ
```
;параметры:  address (число)
out "T " CurrentSystemName() ": T_CONNECT.REQ" 
;break
set $address addr
initTimer timer 1 TIMER_INIT
connectTimer timer 2 TIMER_CONNECT
```
## T_CONNECT.RESP
```
;параметры:  address (число)
out "T " CurrentSystemName() ": T_CONNECT.RESP" 
set $address addr
N_CONNECT.RESP eventdown address $addr
```
## T_DATA.REQ
```
;параметры:   userdata (буфер)
if $is_sending_data==1  put_in_queue
	out "T " CurrentSystemName() ": T_DATA.REQ " $out_num 
	3 1 $out_num 1 $userdata sizeof(userdata) sizeof(userdata)+2 buffer package
	set $out_num+1 out_num
	crc package_crc $package
	$package_crc 1 $package sizeof(package) sizeof(package)+1 buffer package_send
	N_DATA.REQ eventdown userdata $package_send
	resend_timer timer $time_resend TIMER_RESEND
	set 1 resendTry
	set 1 is_sending_data
	return
put_in_queue:
	out "T " CurrentSystemName() ": T_DATA.REQ put_in_queue" 
	package_queue queuevalue $userdata
```
## T_DISCONNECT.REQ
```
;параметры:  address (число)
out "T " CurrentSystemName() ": T_DISCONNECT.REQ" 
;break
set 1 normallyDisconnected
N_DATA.REQ eventdown userdata $package_disconn
N_DATA.REQ eventdown userdata $package_disconn
N_DATA.REQ eventdown userdata $package_disconn
N_DATA.REQ eventdown userdata $package_disconn
N_DATA.REQ eventdown userdata $package_disconn
delayTimer timer $delayTime TIMER_DELAY
initTimer timer 1 TIMER_INIT
```
## T_INIT.REQ
```
declare integer reconnectTimer 
declare integer reconnectTime
set 51 reconnectTime
declare integer delayTimer 
declare integer delayTime
set 21 delayTime
declare integer initTimer 
declare integer disconnect_delayTimer 
declare integer transport_disconnectTimer 
declare integer connectionTry 
declare integer resendTry 
declare integer reconnectionLimit 
set 10 reconnectionLimit
declare integer addr 
declare buffer package 
declare integer package_crc 
declare buffer package_send 
declare buffer package_disconn 
1 1 0 1 0 1 3 buffer package_disconn
crc package_crc $package_disconn
$package_crc 1 $package_disconn sizeof(package_disconn) sizeof(package_disconn)+1 buffer package_disconn
declare buffer package_conf 
declare queue package_queue 
declare buffer packageFromQueue 
declare integer dataCrcIn 
declare integer dataCrcCalc 
declare integer type 
declare integer num
declare buffer package_inc 
declare buffer data 
declare integer isConnInitiator 
declare integer waitDisconn 
set 0 waitDisconn
declare integer connection 
set 0 connection
declare integer keepTransport 
set 0 keepTransport
declare integer is_sending_data 
declare integer out_num 
set 0 out_num
declare integer inc_num 
set 0 inc_num
; ожидаемый номер входящего пакета подтверждения
declare integer inc_num_conf 
set 0 inc_num_conf
; таймер повторной отправки данных
declare integer resend_timer 
declare integer time_resend
set 51 time_resend
; если был нормальный дисконнект, игнорируем случайные разрывы 
declare integer normallyDisconnected
; таймер коннекта
declare integer connectTimer
```
## TIMER_CONNECT
```
out "T " CurrentSystemName() ": TIMER_CONNECT" 
set 1 isConnInitiator
set 0 normallyDisconnected
set 0 keepTransport
N_CONNECT.REQ eventdown address $addr
reconnectTimer timer $reconnectTime TIMER_RECONNECT
set 1 connectionTry
```
## TIMER_DELAY
```
out "T " CurrentSystemName() ": TIMER_DELAY" 
N_DISCONNECT.REQ eventdown address $addr
```
## TIMER_DISCONNECT_DELAY
```
N_CONNECT.REQ eventdown address $addr
reconnectTimer timer $reconnectTime TIMER_RECONNECT
```
## TIMER_INIT
```
out "T " CurrentSystemName() ": TIMER_INIT" 
set 0 connection
set 0  keepTransport
set 0 out_num
set 0 inc_num
set 0 waitDisconn
set 0 is_sending_data
set 0 inc_num_conf
untimer $reconnectTimer
untimer $resend_timer
set 10 resendTry
```
## TIMER_RECONNECT
```
out "T " CurrentSystemName() ": TIMER_RECONNECT" 
if $connectionTry>$reconnectionLimit  stop_try_reconnect
	N_DISCONNECT.REQ eventdown address $addr
	disconnect_delayTimer timer 2  TIMER_DISCONNECT_DELAY
	set $connectionTry+1 connectionTry
	return
stop_try_reconnect:
	N_DATA.REQ eventdown userdata $package_disconn
	N_DATA.REQ eventdown userdata $package_disconn
	N_DATA.REQ eventdown userdata $package_disconn
	N_DATA.REQ eventdown userdata $package_disconn
	N_DATA.REQ eventdown userdata $package_disconn
	delayTimer timer $delayTime TIMER_DELAY
	initTimer timer 1 TIMER_INIT
	eventup T_DISCONNECT.IND
```
## TIMER_RESEND
```
if $normallyDisconnected  exit
if $resendTry>5  stop_try_resend
	out "T " CurrentSystemName() ": TIMER_RESEND: " $resendTry
	N_DATA.REQ eventdown userdata $package_send
	resend_timer timer $time_resend TIMER_RESEND
	set $resendTry+1 resendTry
	return
stop_try_resend:
	out "T " CurrentSystemName() ": TIMER_RESEND: stop_try_resend " qcount (package_queue)
	if qcount (package_queue)==0  exit
	set dequeue (package_queue) packageFromQueue
	3 1 $out_num 1 $packageFromQueue sizeof(packageFromQueue) sizeof(packageFromQueue)+2 buffer package
	set $out_num+1 out_num
	crc package_crc $package
	$package_crc 1 $package sizeof(package) sizeof(package)+1  buffer package_send
	N_DATA.REQ eventdown userdata $package_send
	resend_timer timer $time_resend TIMER_RESEND
	set 1 resendTry
	return
exit:
	set 0 is_sending_data
```