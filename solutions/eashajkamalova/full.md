# Общее

Синтаксис STX5

Год создания 2021

# Прикладной уровень

## A_INIT.REQ
```
declare aNamer string
declare aNamei string
declare aNamerBuf buffer
declare aNameiBuf buffer
declare aContext buffer
declare aQuality buffer
declare aDemand buffer
declare aApcon string
declare resolveType integer
declare packageType integer
declare data buffer
declare aAddress integer
declare aAddressBuf buffer
declare timeStart integer
declare timeStop integer
declare changeFrom string
declare changeTo string
declare packageBuffer buffer
declare packageQueue queue
declare askedForToken integer

declare resolveReqTimer integer
declare resolveIndTimer integer
declare associateReqTimer integer
declare associateIndTimer integer
declare associateRespTimer integer
declare associateConfTimer integer
declare releaseReqTimer integer
declare releaseIndTimer integer
declare releaseRespTimer integer
declare releaseConfTimer integer
declare terminateReqTimer integer
declare terminateRespTimer integer
declare syncTimer integer
```

## A_ASSOCIATE.CONF
```
;параметры:  address (число), quality (буфер), demand (буфер), context (буфер)
out "A_ASSOCIATE.CONF"
0 varset associateConfTimer 
if $aApcon == "GS" gs
if $aApcon == "DT" dt
	out "AAAAAAAAAAAAAAAAAAA"
	goto done
gs:
	sizeof(aNamer)+1 3 1 $aNamer sizeof(aNamer) bufferit packageBuffer
	P_DATA.REQ generatedown userdata $packageBuffer
	out "gd P_DATA.REQ"
	A_SYNC_MAJOR_TIMER 1 timeevent syncTimer
	goto done
dt:
	context $context quality $quality generateup A_TRANSFER_INIT.CONF
	goto done
done:
```

## A_ASSOCIATE.IND
```
0 varset associateIndTimer 
namei $aNamei quality $quality generateup A_TRANSFER_INIT.IND
```

## A_ASSOCIATE.REQ
```
0 varset associateReqTimer 
$apcon varset aApcon
P_CONNECT.REQ generatedown address $aAddress quality $quality demand $demand context $context
```

## A_ASSOCIATE.RESP
```
0 varset associateRespTimer
P_CONNECT.RESP generatedown address $aAddress quality $quality context $context
```

## A_DATA.REQ
```
out "A_DATA.REQ"
queue packageQueue $userdata
if $askedForToken == 1 done
; else - ask for token
	out "PLEASE_TOKENS.REQ"
	P_PLEASE_TOKENS.REQ generatedown token 1
	1 varset askedForToken
	goto done
done:
```

## A_RELEASE.CONF
```
0 varset releaseConfTimer 
if $apcon == "GS" gs
if $apcon == "DT" dt
	out "AAAAAAAAAAAAAAAAAAAA"
	goto done
gs:
	4 $resolveType 1 $aAddress 1 $changeFrom 1 $changeTo 1 bufferit aAddressBuf
	A_RESOLVE.IND 0 address $aAddressBuf timeevent resolveIndTimer
	goto done
dt:
	address $aAddress generateup A_TERMINATE.CONF
	goto done
done:
```

## A_RELEASE.IND
```
0 varset releaseIndTimer 
generateup A_TERMINATE.IND
```

## A_RELEASE.REQ
```
0 varset releaseReqTimer 
$apcon varset aApcon
P_RELEASE.REQ generatedown
```

## A_RELEASE.RESP
```
0 varset releaseRespTimer 
P_RELEASE.RESP generatedown
```

## A_RESOLVE.IND
```
0 varset resolveIndTimer
unpack resolveType 1 aAddress 1 changeFrom 1 changeTo 1 address
sizeof(aNamer)+1 $aNamer sizeof(aNamer) $aAddress 1 bufferit aNamerBuf
A_ASSOCIATE.REQ 0 namer $aNamer namei $aNameiBuf quality $aQuality demand $aDemand context $aContext apcon "DT" timeevent associateReqTimer 
```

## A_RESOLVE.REQ
```
0 varset resolveReqTimer 
locguide($name) varset data
unpack resolveType 1 aAddress 1 timeStart 1 timeStop 1 changeFrom 1 changeTo 1 data
;out $resolveType 
;out $aAddress 
;out $timeStart 
;out $timeStop 
;out $changeFrom 
;out $changeTo
if $resolveType == 3 notFound
goto done
notFound:
	locguide("Guide") varset data
	unpack resolveType 1 aAddress 1 timeStart 1 timeStop 1 changeFrom 1 changeTo 1 data
	; global DNS is always known, so don't check the type
	; give both tokens to us
	1 1 1 bufferit aDemand
	6 "Guide" 5 $aAddress 1 bufferit aNamerBuf
	sizeof(aNamei)+1 $aNamei sizeof(aNamei) locguide($aNamei) 1 bufferit aNameiBuf
	A_ASSOCIATE.REQ 0 namer $aNamerBuf namei $aNameiBuf quality $aQuality demand $aDemand context $aContext apcon "GS" timeevent associateReqTimer
	goto done
done:
```

## A_SYNC_MAJOR_TIMER
```
0 varset syncTimer
P_SYNC_MAJOR.REQ generatedown
```

## A_TERMINATE.CONF
```
0 varset terminateConfTimer
```

## A_TERMINATE.REQ
```
A_RELEASE.REQ 0 apcon $aApcon timeevent releaseReqTimer
```

## A_TERMINATE.RESP
```
0 varset terminateRespTimer 
A_RELEASE.RESP 0 apron "DT" timeevent releaseRespTimer
```

## A_TRANSFER_INIT.REQ
```
$namer varset aNamer
$namei varset aNamei
$context varset aContext
$quality varset aQuality
A_RESOLVE.REQ 0 name $namer timeevent resolveReqTimer
```

## A_TRANSFER_INIT.RESP
```
A_ASSOCIATE.RESP 0 namei $aNameiBuf context $context quality $quality apcon "DT" timeevent associateRespTimer
```

## A_U_ABORT.REQ
```
;параметры: apcon (строка)
P_U_ABORT.REQ generatedown
```

## P_CONNECT.CONF
```
A_ASSOCIATE.CONF 0 context $aContext quality $aQuality demand $aDemand timeevent associateConfTimer
```

## P_CONNECT.IND
```
$address varset aAddress
locguide($address) varset aNamei
sizeof(aNamei)+1 $address 1 $aNamei sizeof(aNamei) bufferit aNameiBuf
A_ASSOCIATE.IND 1 namei $aNameiBuf quality $quality demand $demand timeevent associateIndTimer
```

## P_DATA.IND
```
out "P_DATA.IND"
if $aApcon == "GS" gs
; else - normal data
	out "A_DATA.IND"
	userdata $userdata generateup A_DATA.IND
	goto done
gs:
	out "gs"
	unpack packageType 1 resolveType 1 aAddress 1 timeStart 1 timeStop 1 changeFrom 1 changeTo 1 userdata
	;out $resolveType 
	;out $aAddress 
	;out $timeStart 
	;out $timeStop 
	;out $changeFrom 
	;out $changeTo
	if $resolveType == 0 gotAddress
		out "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"
		goto done
	gotAddress:
		A_RELEASE.REQ 0 apcon "GS" timeevent releaseReqTimer
		goto done
done:
```

## P_EXPIRED_DATA.IND
```
```

## P_GIVE_TOKENS.IND
```
out "P_GIVE_TOKENS"
if $token == 1 sendPackage
if $token == 2 sync
sendPackage:
	if qcount(packageQueue) == 0 askForToken
	; else
		P_DATA.REQ generatedown userdata dequeue(packageQueue)
		out "gd P_DATA.REQ"
		goto sendPackage
	askForToken:
	0 varset askedForToken
	P_PLEASE_TOKENS.REQ generatedown token 2
	goto done
sync:
	P_SYNC_MAJOR.REQ generatedown
	goto done
done:
```

## P_P_ABORT.IND
```
apcon $aApcon generateup A_P_ABORT.IND
```

## P_P_EXCEPTION.IND
```
;параметры:  error (число)
if ($error == 1) needDataMarker
if ($error == 2) needSyncMarker
if ($error == 3) needResync
out "p_pe.i : unexpected error"
goto end

needDataMarker:
P_GIVE_TOKENS.REQ generatedown token 1
goto end

needSyncMarker:
P_GIVE_TOKENS.REQ generatedown token 1
goto end

needResync:
P_RESYNCHRONIZE.REQ generatedown token 4
goto end


end:
```

## P_PLEASE_TOKENS.IND
```
P_GIVE_TOKENS.REQ generatedown token $token
```

## P_RELEASE.CONF
```
A_RELEASE.CONF 0 apcon $aApcon timeevent releaseConfTimer
```

## P_RELEASE.IND
```
A_RELEASE.IND 0 apcon "DT" timeevent releaseIndTimer
```

## P_RESYNCHRONIZE.CONF
```
;параметры:  token (число)
```

## P_RESYNCHRONIZE.IND
```
;параметры:  token (число)
```

## P_SYNC_MAJOR.CONF
```
;параметры:  нет
```

## P_SYNC_MAJOR.IND
```
;параметры:  нет
P_SYNC_MAJOR.RESP generatedown
```

## P_U_ABORT.IND
```
;параметры:  нет
```

# Уровень представления

## P_INIT.REQ
```
declare p_address integer
declare p_quality buffer
declare p_context buffer
declare sound string
declare action string
declare colour string
declare scent string
declare size integer

declare op_brack string
declare cl_brack string

declare our_synt integer
declare in_synt integer
declare fin_synt integer

declare pack_buf buffer
declare pack_type integer

declare tmp buffer
declare w_string string

declare data buffer
```

## P_CONNECT.REQ
```
;параметры:  address (число), quality (буфер), demand (буфер), context (буфер)
$address varset p_address
unpack op_brack 1 cl_brack 1 data sizeof(context)-2 context
if sizeof(data) == 2 both
unpack our_synt 1 data
goto end
both:
3 varset our_synt
end:
S_CONNECT.REQ generatedown address $address quality $quality demand $demand
```

## P_CONNECT.RESP
```
;параметры:  address (число), quality (буфер), context (буфер)
$address varset p_address
unpack op_brack 1 cl_brack 1 data sizeof(context)-2 context
if sizeof(data) == 2 both
unpack our_synt 1 data
goto end
both:
3 varset our_synt
end:
S_CONNECT.RESP generatedown address $address quality $quality
```

## P_DATA.REQ
```
;параметры:  userdata (буфер)
unpack pack_type 1 w_string sizeof(userdata)-1 userdata
if $pack_type == 1 p_struct
if $pack_type == 2 p_numb
if $pack_type == 3 p_string
if $pack_type == 4 p_buf
p_struct:
copy(w_string, 3, sizeof(w_string)-2) varset w_string
copy(w_string, 1, pos($cl_brack, w_string)-1) varset sound
copy(w_string, sizeof(sound)+3, sizeof(w_string)-sizeof(sound)-2) varset w_string
copy(w_string, 1, pos($cl_brack, w_string)-1) varset action
copy(w_string, sizeof(action)+3, sizeof(w_string)-sizeof(action)-2) varset w_string
copy(w_string, 1, pos($cl_brack, w_string)-1) varset colour
copy(w_string, sizeof(colour)+3, sizeof(w_string)-sizeof(colour)-2) varset w_string
copy(w_string, 1, pos($cl_brack, w_string)-1) varset scent
if $fin_synt == 1 struct_len
	(sizeof(sound)+5) 10 1 $sound sizeof(sound) "1234" 4 bufferit data
	(sizeof(data)+sizeof(action)+5) $data sizeof(data) 20 1 $action sizeof(action) "1234" 4 bufferit data
	(sizeof(data)+sizeof(colour)+5) $data sizeof(data) 30 1 $colour sizeof(colour) "1234" 4 bufferit data
	(sizeof(data)+sizeof(scent )+5) $data sizeof(data) 40 1 $scent sizeof(scent ) "1234" 4 bufferit data
	(sizeof(data)+5) 1 1 $data sizeof(data)  "1234" 4 bufferit data
	goto end
struct_len:
	(sizeof(sound)+2) 10 1 sizeof(sound) 1 $sound sizeof(sound) bufferit data
	(sizeof(data)+sizeof(action)+2) $data sizeof(data) 20 1 sizeof(action) 1 $action sizeof(action) bufferit data
	(sizeof(data)+sizeof(colour)+2) $data sizeof(data) 30 1 sizeof(colour) 1 $colour sizeof(colour) bufferit data
	(sizeof(data)+sizeof(scent)+2) $data sizeof(data) 40 1 sizeof(scent) 1 $scent sizeof(scent) bufferit data
	(sizeof(data)+2) 1 1 sizeof(data) 1 $data sizeof(data) bufferit data
	goto end

p_numb:
if $fin_synt == 1 numb_len
	6 $userdata 2 "1234" 4 bufferit data
	goto end
numb_len:
	unpack pack_type 1 tmp 1 userdata
	6 2 1 1 1 $tmp 1 bufferit data
	goto end

p_string:
if $fin_synt == 1 str_len
	(sizeof(userdata)+4) $userdata sizeof(userdata) "1234" 4 bufferit data
	goto end
str_len:
	unpack pack_type 1 tmp sizeof(userdata)-1 userdata
	(sizeof(tmp)+2) 3 1 sizeof(tmp) 1 $tmp sizeof(tmp) bufferit data
	goto end

p_buf:
if $fin_synt == 1 buf_len
	(sizeof(userdata)+4) $userdata sizeof(userdata) "1234" 4 bufferit data
	goto end
buf_len:
unpack pack_type 1 tmp sizeof(userdata)-1 userdata
(sizeof(tmp)+2) 4 1 sizeof(tmp) 1 $tmp sizeof(tmp) bufferit data
goto end
end:
S_DATA.REQ generatedown userdata $data
```

## P_EXPEDITED_DATA.REQ
```
unpack pack_type 1 w_string sizeof(userdata)-1 userdata
if $pack_type == 1 p_struct
if $pack_type == 2 p_numb
if $pack_type == 3 p_string
if $pack_type == 4 p_buf
p_struct:
copy(w_string, 3, sizeof(w_string)-2) varset w_string
copy(w_string, 1, pos($cl_brack, w_string)-1) varset sound
copy(w_string, sizeof(sound)+3, sizeof(w_string)-sizeof(sound)-2) varset w_string
copy(w_string, 1, pos($cl_brack, w_string)-1) varset action
copy(w_string, sizeof(action)+3, sizeof(w_string)-sizeof(action)-2) varset w_string
copy(w_string, 1, pos($cl_brack, w_string)-1) varset colour
copy(w_string, sizeof(colour)+3, sizeof(w_string)-sizeof(colour)-2) varset w_string
copy(w_string, 1, pos($cl_brack, w_string)-1) varset scent
if $fin_synt == 1 struct_len
	(sizeof(sound)+5) 10 1 $sound sizeof(sound) "1234" 4 bufferit data
	(sizeof(data)+sizeof(action)+5) $data sizeof(data) 20 1 $action sizeof(action) "1234" 4 bufferit data
	(sizeof(data)+sizeof(colour)+5) $data sizeof(data) 30 1 $colour sizeof(colour) "1234" 4 bufferit data
	(sizeof(data)+sizeof(scent )+5) $data sizeof(data) 40 1 $scent sizeof(scent ) "1234" 4 bufferit data
	(sizeof(data)+5) 1 1 $data sizeof(data)  "1234" 4 bufferit data
	goto end
struct_len:
	(sizeof(sound)+2) 10 1 sizeof(sound) 1 $sound sizeof(sound) bufferit data
	(sizeof(data)+sizeof(action)+2) $data sizeof(data) 20 1 sizeof(action) 1 $action sizeof(action) bufferit data
	(sizeof(data)+sizeof(colour)+2) $data sizeof(data) 30 1 sizeof(colour) 1 $colour sizeof(colour) bufferit data
	(sizeof(data)+sizeof(scent)+2) $data sizeof(data) 40 1 sizeof(scent) 1 $scent sizeof(scent) bufferit data
	(sizeof(data)+2) 1 1 sizeof(data) 1 $data sizeof(data) bufferit data
	goto end

p_numb:
if $fin_synt == 1 numb_len
	6 $userdata 2 "1234" 4 bufferit data
	goto end
numb_len:
	unpack pack_type 1 tmp 1 userdata
	6 2 1 1 1 $tmp 1 bufferit data
	goto end

p_string:
if $fin_synt == 1 str_len
	(sizeof(userdata)+4) $userdata sizeof(userdata) "1234" 4 bufferit data
	goto end
str_len:
	unpack pack_type 1 tmp sizeof(userdata)-1 userdata
	(sizeof(tmp)+2) 3 1 sizeof(tmp) 1 $tmp sizeof(tmp) bufferit data
	goto end

p_buf:
if $fin_synt == 1 buf_len
	(sizeof(userdata)+4) $userdata sizeof(userdata) "1234" 4 bufferit data
	goto end
buf_len:
	unpack pack_type 1 tmp sizeof(userdata)-1 userdata
	(sizeof(tmp)+2) 3 1 sizeof(tmp) 1 $tmp sizeof(tmp) bufferit data
	goto end
end:
S_EXPEDITED_DATA.REQ generatedown userdata $data
```

## P_GIVE_TOKENS.REQ
```
;параметры:  token (число)
S_GIVE_TOKENS.REQ generatedown token $token
```

## P_PLEASE_TOKENS.REQ
```
;параметры:  token (число)
S_PLEASE_TOKENS.REQ generatedown token $token
```

## P_RELEASE.REQ
```
;параметры:  нет
S_RELEASE.REQ generatedown
```

## P_RELEASE.RESP
```
;параметры:  нет
S_RELEASE.RESP generatedown
```

## P_RESYNCHRONIZE.REQ
```
;параметры:  token (число)
S_RESYNCHRONIZE.REQ generatedown token $token
```

## P_RESYNCHRONIZE.RESP
```
;параметры:  token (число)
S_RESYNCHRONIZE.RESP generatedown token $token
```

## P_SYNC_MAJOR.REQ
```
;параметры:  нет
S_SYNC_MAJOR.REQ generatedown
```

## P_SYNC_MAJOR.RESP
```
;параметры:  нет
S_SYNC_MAJOR.RESP generatedown
```

## P_U_ABORT.REQ
```
;параметры:  нет
S_U_ABORT.REQ generatedown
```

## S_CONNECT.CONF
```
$quality varset p_quality
2 100 1 $our_synt 1 bufferit pack_buf
S_EXPEDITED_DATA.REQ generatedown userdata $pack_buf
```

## S_CONNECT.IND
```
;параметры:  address (число), quality (буфер), demand (буфер)
address $address quality $quality demand $demand generateup P_CONNECT.IND
```

## S_DATA.IND
```
;параметры:  userdata (буфер)
unpack pack_type 1 w_string sizeof(userdata)-1 userdata
if $pack_type == 1 p_struct
if $pack_type == 2 p_numb
if $pack_type == 3 p_string
if $pack_type == 4 p_buf
p_struct:
if $fin_synt == 1 struct_len
	copy(w_string, 2, pos("1234", w_string)-2) varset sound
	copy(w_string, pos("1234", w_string)+4, sizeof(w_string)-sizeof(sound)-5) varset w_string
	copy(w_string, 2, pos("1234", w_string)-2) varset action
	copy(w_string, pos("1234", w_string)+4, sizeof(w_string)-sizeof(action)-5) varset w_string
	copy(w_string, 2, pos("1234", w_string)-2) varset colour
	copy(w_string, pos("1234", w_string)+4, sizeof(w_string)-sizeof(colour)-5) varset w_string
	copy(w_string, 2, pos("1234", w_string)-2) varset scent
	goto pack_it
struct_len:
	unpack pack_type 1 tmp 2 size 1 data sizeof(userdata)-4 userdata
	unpack sound $size tmp 1 size 1 data sizeof(data)-sizeof(sound)-2 data
	unpack action $size tmp 1 size 1 data sizeof(data)-sizeof(action)-2 data
	unpack colour $size tmp 1 size 1 data sizeof(data)-sizeof(colour)-2 data
	unpack scent $size tmp sizeof(data)-sizeof(scent) data
	goto pack_it
pack_it:
(sizeof(sound)+2) $op_brack 1 $sound sizeof(sound) $cl_brack 1 bufferit data
(sizeof(data)+sizeof(action)+2) $data sizeof(data) $op_brack 1 $action sizeof(action) $cl_brack 1 bufferit data
(sizeof(data)+sizeof(colour)+2) $data sizeof(data) $op_brack 1 $colour sizeof(colour) $cl_brack 1 bufferit data
(sizeof(data)+sizeof(scent)+2) $data sizeof(data) $op_brack 1 $scent sizeof(scent) $cl_brack 1 bufferit data
(sizeof(data)+3) 1 1 $op_brack 1 $data sizeof(data) $cl_brack 1 bufferit data
goto end	

p_numb:
if $fin_synt == 1 numb_len
unpack data 2 tmp 4 userdata
goto end
numb_len:
	unpack pack_type 1 size 1 data 1 userdata
	($size+1) $pack_type 1 $data $size bufferit data
	goto end

p_string:
	if $fin_synt == 1 str_len
	unpack data sizeof(userdata)-4 tmp 4 userdata
	goto end
str_len:
	unpack pack_type 1 size 1 data sizeof(userdata)-2 userdata
	($size+1) $pack_type 1 $data $size bufferit data
	goto end
p_buf:
if $fin_synt == 1 buf_len
	unpack data sizeof(userdata)-4 tmp 4 userdata
	goto end
buf_len:
	unpack pack_type 1 size 1 data sizeof(userdata)-2 userdata
	($size+1) $pack_type 1 $data $size bufferit data
	goto end
end:
userdata $data generateup P_DATA.IND
```

## S_EXPEDITED_DATA.IND
```
;параметры:  userdata (буфер)
unpack pack_type 1 data sizeof(userdata)-1 userdata
unpack pack_type 1 w_string sizeof(userdata)-1 userdata
if $pack_type == 1 p_struct
if $pack_type == 2 p_numb
if $pack_type == 3 p_string
if $pack_type == 4 p_buf
if $pack_type == 100 con_req
if $pack_type == 101 con_resp
p_struct:
if $fin_synt == 1 struct_len
	copy(w_string, 2, pos("1234", w_string)-2) varset sound
	copy(w_string, pos("1234", w_string)+4, sizeof(w_string)-sizeof(sound)-5) varset w_string
	copy(w_string, 2, pos("1234", w_string)-2) varset action
	copy(w_string, pos("1234", w_string)+4, sizeof(w_string)-sizeof(action)-5) varset w_string
	copy(w_string, 2, pos("1234", w_string)-2) varset colour
	copy(w_string, pos("1234", w_string)+4, sizeof(w_string)-sizeof(colour)-5) varset w_string
	copy(w_string, 2, pos("1234", w_string)-2) varset scent
	goto pack_it
struct_len:
	unpack pack_type 1 tmp 2 size 1 data sizeof(userdata)-4 userdata
	unpack sound $size tmp 1 size 1 data sizeof(data)-sizeof(sound)-2 data
	unpack action $size tmp 1 size 1 data sizeof(data)-sizeof(action)-2 data
	unpack colour $size tmp 1 size 1 data sizeof(data)-sizeof(colour)-2 data
	unpack scent $size tmp sizeof(data)-sizeof(scent) data
	goto pack_it
pack_it:
(sizeof(sound)+2) $op_brack 1 $sound sizeof(sound) $cl_brack 1 bufferit data
(sizeof(data)+sizeof(action)+2) $data sizeof(data) $op_brack 1 $action sizeof(action) $cl_brack 1 bufferit data
(sizeof(data)+sizeof(colour)+2) $data sizeof(data) $op_brack 1 $colour sizeof(colour) $cl_brack 1 bufferit data
(sizeof(data)+sizeof(scent)+2) $data sizeof(data) $op_brack 1 $scent sizeof(scent) $cl_brack 1 bufferit data
(sizeof(data)+3) 1 1 $op_brack 1 $data sizeof(data) $cl_brack 1 bufferit data
goto send_pack	

p_numb:
if $fin_synt == 1 numb_len
	unpack data 2 tmp 4 userdata
	goto send_pack
numb_len:
	unpack pack_type 1 size 1 data 1 userdata
	($size+1) $pack_type 1 $data $size bufferit data
	goto send_pack

p_string:
if $fin_synt == 1 str_len
	unpack data sizeof(userdata)-4 tmp 4 userdata
	goto send_pack
str_len:
	unpack pack_type 1 size 1 data sizeof(userdata)-2 userdata
	($size+1) $pack_type 1 $data $size bufferit data
	goto send_pack

p_buf:
if $fin_synt == 1 buf_len
	unpack data sizeof(userdata)-4 tmp 4 userdata
	goto send_pack
buf_len:
	unpack pack_type 1 size 1 data sizeof(userdata)-2 userdata
	($size+1) $pack_type 1 $data $size bufferit data
	goto send_pack
con_req:
unpack in_synt 1 data
$in_synt & $our_synt varset fin_synt
if $fin_synt != 3 continue
	1 varset fin_synt
continue: 
2 101 1 $fin_synt 1 bufferit pack_buf 
P_EXPEDITED_DATA.REQ generatedown userdata $pack_buf
goto end
con_resp:
unpack fin_synt 1 data
out "final syntax"
out $fin_synt
3 $op_brack 1 $cl_brack 1 $fin_synt 1 bufferit pack_buf
quality $p_quality context $pack_buf generateup P_CONNECT.CONF
goto end

send_pack:
userdata $data generateup S_EXPEDITED_DATA.IND

end:
```

## S_GIVE_TOKENS.IND
```
;параметры:  token (число)
out "S_GIVE_TOKENS.IND : gu P_GIVE_TOKENS.IND"
token $token generateup P_GIVE_TOKENS.IND
```

## S_P_ABORT.IND
```
;параметры:  нет
generateup P_P_ABORT.IND
```

## S_P_EXCEPTION.IND
```
;параметры:  error (число)
error $error generateup P_P_EXCEPTION.IND
```

## S_PLEASE_TOKENS.IND
```
;параметры:  token (число)
token $token generateup P_PLEASE_TOKENS.IND
```

## S_RELEASE.CONF
```
;параметры:  нет
generateup P_RELEASE.CONF
```

## S_RELEASE.IND
```
;параметры:  нет
generateup P_RELEASE.IND
```

## S_RESYNCHRONIZE.CONF
```
;параметры:  token (число)
token $token generateup P_RESYNCHRONIZE.CONF
```

## S_RESYNCHRONIZE.IND
```
;параметры:  token (число)
token $token generateup P_RESYNCHRONIZE.IND
```

## S_SYNC_MAJOR.CONF
```
;параметры:  нет
generateup P_SYNC_MAJOR.CONF
```

## S_SYNC_MAJOR.IND
```
;параметры:  нет
generateup P_SYNC_MAJOR.IND
```

## S_U_ABORT.IND
```
;параметры:  нет
generateup P_U_ABORT.IND
```

# Сеансовый уровень
## S_INIT.REQ
```
;Типы пакетов транспортного уровня: 
;1 - отправка параметров, 2 - подтверждение параметров, 3 - данные, 4 - запрос главной синхронизации,
;5 - подтведждение главной синхронизации, 6 - ошибка синхронизации, 7 - запрос маркера, 8 - отправка маркера,
;9 - срочные данные, 10 - запрос на ресинхронизацию, 11 - ответ на ресинхронизацию,
;12 - запрос на упоряд. разъединение, 13 - ответ на упоряд. разъединение, 14 - запрос на безусл. разъединение

; Является ли инициатором соединения
declare is_con_init integer

; Защита на сеансовом уровне
declare protection integer
1 varset protection

; Начальный номер точки главной синхронизации
declare major_sync_start integer
1 varset major_sync_start

; Токены, полученные в требованиях по обслуживанию(demand)
declare tokens integer

; Имеет маркер данных
declare has_data_token integer

; Имеет маркер синхронизации
declare has_sync_token integer

; Адрес системы A
declare addrA integer

; Адрес системы B
declare addrB integer

; Таймер повторного соединения
declare transport_reconnect_timer integer

; Количество сделанных попыток повторного соединения
declare transport_con_try integer

; Идет попытка соединения
declare is_connecting integer

; Таймер задержки между разъединением и соединением
declare transport_discon_delay_timer integer

; Качество обслуживания
declare qos buffer
2 1 1 1 1 bufferit qos

; Отправляемый пакет транспортного уровня
declare packet buffer

; тип входящего пакета
declare type integer

; входящие данные
declare data buffer

; Контрольная сумма исходящего пакета
declare packet_crc integer

; Накапливаемая контрольная сумма исходящих пакетов для синхронизации
declare crc_sum_out integer

; Накапливаемая контрольная сумма входящих пакетов для синхронизации
declare crc_sum_in integer

; Накапливаемая контрольная сумма пакетов, полученная в запросе синхронизации
declare inc_crc_sum integer

; Исходящая очередь
declare out_queue queue

; Входящая очередь
declare in_queue queue

; Количество пакетов во входящей очереди для отправки наверх
declare send_up_count integer

; Количество пакетов в исходящей очереди для отправки при ресинхронизации
declare send_resync_count integer

; данные из очереди входящих
declare data_from_in_queue buffer

; данные из очереди исходящих
declare data_from_out_queue buffer

; Таймер отправки пакетов из входящей очереди наверх
declare send_from_in_queue_timer integer

; Таймер отправки пакетов из исходящей очереди при ресинхронизации
declare send_from_out_queue_timer integer

; Флаг синхронизации
declare sync integer

; Флаг ресинхронизации
declare resync integer

; На какой маркер пришел запрос
declare req_token integer

; Какой маркер получен
declare given_token integer

; Маркеры после ресинхронизации
declare resync_tokens integer

; Послан запрос на маркер синхронизации, но маркер еще не получен
declare should_have_data_token integer

; Отправлен маркер данных на маркер синхронизации, но подтверждение о получении еще не пришло
declare should_have_sync_token integer

; Идет нормальный разрыв соединения пользователем
declare user_normal_discon integer

; Таймер сброса переменных при разъединении
declare init_state integer

; Таймер задержки, чтобы успела закончится доставка данных перед нормальным разъединением
declare normal_discon_wait_timer integer

; Сколько раз мы будем откладывать нормальный дисконнект
declare normal_discon_wait_times integer

; Идет безусловный разрыв соединения пользователем
declare user_forced_discon integer
```

## S_CONNECT.REQ
```
;ut "пришeл запрос S_CONNECT.REQ" 
$address varset addrB 
;ut "адрес " $address 
;npack protection 1 major_sync_start 1 quality 
;ut "защита " $protection ", синх. " $major_sync_start 
unpack tokens 1 demand 
;ut "маркеры " $tokens 
T_CONNECT.REQ generatedown address $addrB 
TIMER_RECONNECT 260 timeevent transport_reconnect_timer 
1 varset transport_con_try 
1 varset is_con_init 
1 varset is_connecting 
```

## S_CONNECT.RESP
```
;ut "пришел ответ S_CONNECT.RESP" 
sizeof (quality) + 1 2 1 $quality sizeof (quality) bufferit packet 
T_DATA.REQ generatedown userdata $packet 
0 varset user_forced_discon 
```

## S_DATA.REQ
```
;reak 
0 varset sync 
0 varset resync 
calccrc packet_crc $userdata 
$crc_sum_out + $packet_crc varset crc_sum_out 
queue out_queue $userdata 
if $has_data_token == 0 no_data_token 
sizeof (userdata) + 1 3 1 $userdata sizeof (userdata) bufferit packet 
T_DATA.REQ generatedown userdata $packet 
return 
no_data_token: 
;reak 
if $should_have_data_token == 1 lost_token 
error 1 generateup S_P_EXCEPTION.IND 
;ut "no data token ! " 
1 varset should_have_data_token 
return 
lost_token: 
;reak 
2 6 1 0 1 bufferit packet 
T_DATA.REQ generatedown userdata $packet 
```

## S_EXPEDITED_DATA.REQ
```
sizeof (userdata) + 1 9 1 $userdata sizeof (userdata) bufferit packet 
T_DATA.REQ generatedown userdata $packet 
```

## S_GIVE_TOKENS.REQ
```
if $token == 1 data_token 
if $token == 2 sync_token 
data_token: 
if $has_data_token == 0 token_error 
0 varset has_data_token 
0 varset should_have_data_token 
goto continue 
sync_token: 
if $has_sync_token == 0 token_error 
0 varset has_sync_token 
0 varset should_have_sync_token 
goto continue 
continue: 
2 8 1 $token 1 bufferit packet 
;_DATA.REQ generatedown userdata $packet 
T_DATA.REQ generatedown userdata $packet 
return 
token_error: 
;reak 
error 3 generateup S_P_EXCEPTION.IND 
```

## S_PLEASE_TOKENS.REQ
```
;reak 
;if (($resync) || ($has_data_token) || ($has_sync_token)) give_token 
if (($resync) || (($has_data_token==1) && ($token==1)) || (($has_sync_token==1) && ($token==2))) give_token 
$token varset req_token 
2 7 1 $token 1 bufferit packet 
T_DATA.REQ generatedown userdata $packet 
;_DATA.REQ generatedown userdata $packet 
if $token == 1 asked_for_data 
if $token == 2 asked_for_sync 
asked_for_data: 
1 varset should_have_data_token 
return 
asked_for_sync: 
1 varset should_have_sync_token 
return 
give_token: 
token $token generateup S_GIVE_TOKENS.IND 
```

## S_RELEASE.REQ
```
;reak 
1 varset user_normal_discon 
if qcount(out_queue) > 0 wait 
2 12 1 0 1 bufferit packet 
T_DATA.REQ generatedown userdata $packet 
;ut "запрос правильного завершения соединения, исходящих нет, отравляем сразу" 
return 
wait: 
TIMER_NORMAL_DISCON_INIT 250 timeevent normal_discon_wait_timer 
3 varset normal_discon_wait_times 
;ut "запрос правильного завершения соединения, есть исходящие, ждем - " qcount(out_queue) 
```

## S_RELEASE.RESP
```
if qcount(out_queue) > 0 wait 
T_DISCONNECT.REQ generatedown address $addrB 
TIMER_DISCON_VARS_INIT 1 timeevent init_state 
;ut "ответ правильного завершения соединения" 
return 
wait: 
TIMER_NORMAL_DISCON_INIT 250 timeevent normal_discon_wait_timer 
3 varset normal_discon_wait_times 
```

## S_RESYNCHRONIZE.REQ
```
;reak 
2 10 1 $token 1 bufferit packet 
;_DATA.REQ generatedown userdata $packet 
T_DATA.REQ generatedown userdata $packet 
;ut CurrentSystemName () " :маркеры в запросе ресинхронизации " $token 
0 varset crc_sum_in 
clearqueue in_queue 
1 varset resync 
```

## S_RESYNCHRONIZE.RESP
```
2 11 1 $token 1 bufferit packet 
;_DATA.REQ generatedown userdata $packet 
T_DATA.REQ generatedown userdata $packet 
;ut CurrentSystemName () ": маркеры в ответе на ресинхронизацию " $token 
if $token == 1 sync_token 
if $token == 2 data_token 
if $token == 3 neither 
if $token == 4 both 
both: 
;reak 
1 varset has_data_token 
1 varset has_sync_token 
1 varset should_have_data_token 
1 varset should_have_sync_token 
return 
neither: 
0 varset has_data_token 
0 varset has_sync_token 
0 varset should_have_data_token 
0 varset should_have_sync_token 
return 
data_token: 
1 varset has_data_token 
0 varset has_sync_token 
1 varset should_have_data_token 
0 varset should_have_sync_token 
return 
sync_token: 
0 varset has_data_token 
1 varset has_sync_token 
0 varset should_have_data_token 
1 varset should_have_sync_token 
```

## S_SYNC_MAJOR.REQ
```
if $resync == 1 exit 
if $has_sync_token == 0 no_sync_token 
;�тправляем запрос главной синхронизации. Данные - сумма контрольных сумм по всем отправленным userdata 
2 4 1 $crc_sum_out 1 bufferit packet 
;_DATA.REQ generatedown userdata $packet 
T_DATA.REQ generatedown userdata $packet 
1 varset sync 
return 
no_sync_token: 
;reak 
if $should_have_sync_token == 1 lost_token 
error 2 generateup S_P_EXCEPTION.IND 
;ut "no sync token ! " 
1 varset should_have_sync_token 
return 
lost_token: 
;reak 
2 6 1 0 1 bufferit packet 
T_DATA.REQ generatedown userdata $packet 
exit: 
```

## S_SYNC_MAJOR.RESP
```
2 5 1 1 1 bufferit packet 
;_DATA.REQ generatedown userdata $packet 
T_DATA.REQ generatedown userdata $packet 
0 varset crc_sum_in 
```

## S_U_ABORT.REQ
```
;reak 
2 14 1 0 1 bufferit packet 
T_DATA.REQ generatedown userdata $packet 
1 varset user_forced_discon 
```

## T_CONNECT.CONF
```
;ut "пришло подтверждение T_CONNECT.CONF" 
untimer $transport_reconnect_timer 
;�тправляем параметры требования по обслуживанию (маркеры) 
2 1 1 $tokens 1 bufferit packet 
T_DATA.REQ generatedown userdata $packet 
if $tokens == 1 both 
if $tokens == 2 neither 
if $tokens == 3 data_token 
if $tokens == 4 sync_token 
both: 
1 varset has_data_token 
1 varset has_sync_token 
1 varset should_have_data_token 
1 varset should_have_sync_token 
return 
neither: 
0 varset has_data_token 
0 varset has_sync_token 
return 
data_token: 
1 varset has_data_token 
0 varset has_sync_token 
1 varset should_have_data_token 
return 
sync_token: 
0 varset has_data_token 
1 varset has_sync_token 
1 varset should_have_sync_token 
```

## T_CONNECT.IND
```
;ut "пришла индикация T_CONNECT.IND" 
$address varset addrA 
T_CONNECT.RESP generatedown address $address 
```

## T_DATA.IND
```
if sizeof (userdata) < 2 exit 
unpack type 1 data sizeof (userdata) - 1 userdata 
if $type == 1 param_propose 
if $type == 2 param_conf 
if $type == 3 userdata 
if $type == 4 sync_request 
if $type == 5 sync_conf 
if $type == 6 sync_error 
if $type == 7 token_request 
if $type == 8 token_given 
if $type == 9 exp_data 
if $type == 10 resync_request 
if $type == 11 resync_response 
if $type == 12 normal_discon_request 
if $type == 14 forced_discon_request 
out "неизвестный тип пакета ! " 
return 

param_propose: 
;ut "пришла индикация S_CONNECT.IND" 
address $addrA quality $qos demand $data generateup S_CONNECT.IND 
unpack tokens 1 data 
if $tokens == 1 neither 
if $tokens == 2 both 
if $tokens == 3 sync_token 
if $tokens == 4 data_token 
both: 
1 varset has_data_token 
1 varset has_sync_token 
1 varset should_have_data_token 
1 varset should_have_sync_token 
return 
neither: 
0 varset has_data_token 
0 varset has_sync_token 
return 
data_token: 
1 varset has_data_token 
0 varset has_sync_token 
1 varset should_have_data_token 
return 
sync_token: 
0 varset has_data_token 
1 varset has_sync_token 
1 varset should_have_sync_token 
return 

param_conf: 
;ut "пришло подтверждение S_CONNECT.CONF" 
quality $data generateup S_CONNECT.CONF 
untimer $transport_reconnect_timer 
0 varset is_connecting 
return 

userdata: 
calccrc packet_crc $data 
$crc_sum_in + $packet_crc varset crc_sum_in 
queue in_queue $data 
return 

sync_request: 
if $sync == 1 exit 
1 varset sync 
0 varset resync 
unpack inc_crc_sum 1 data 
if $inc_crc_sum != $crc_sum_in sync_error 
generateup S_SYNC_MAJOR.IND 
qcount(in_queue) varset send_up_count 
TIMER_SEND_FROM_IN_QUEUE 1 timeevent send_from_in_queue_timer 
return 

sync_conf: 
if $sync == 0 exit 
0 varset crc_sum_out 
clearqueue out_queue 
generateup S_SYNC_MAJOR.CONF 
0 varset sync 
return 

sync_error: 
;reak 
error 3 generateup S_P_EXCEPTION.IND 
return 

token_request: 
unpack req_token 1 data 
0 varset sync 
if ($req_token == 1) && ($has_data_token == 0) exit 
if ($req_token == 2) && ($has_sync_token == 0) exit 
token $req_token generateup S_PLEASE_TOKENS.IND 
;�а случай, если не пришло подтверждение синхронизации, т.к. маркер запрашивается сразу после 
0 varset crc_sum_out 
clearqueue out_queue 
return 

token_given: 
unpack given_token 1 data 
if ($given_token == 1) && ($has_data_token == 1) exit 
if ($given_token == 2) && ($has_sync_token == 1) exit 
if $given_token == 1 given_data_token 
if $given_token == 2 given_sync_token 
given_data_token: 
if $has_data_token == 1 already_has_token 
1 varset has_data_token 
goto give_token 
given_sync_token: 
if $has_sync_token == 1 already_has_token 
1 varset has_sync_token 
goto give_token 
give_token: 
token $given_token generateup S_GIVE_TOKENS.IND 
return 
already_has_token: 
;reak 
error 3 generateup S_P_EXCEPTION.IND 
return 

exp_data: 
userdata $data generateup S_EXPEDITED_DATA.IND 
return 

resync_request: 
if $resync == 1 exit 
0 varset crc_sum_out 
unpack resync_tokens 1 data 
qcount(out_queue) varset send_resync_count 
TIMER_SEND_FROM_OUT_QUEUE 1 timeevent send_from_out_queue_timer 
1 varset resync 
return 

resync_response: 
if $resync == 0 exit 
0 varset sync 
unpack resync_tokens 1 data 
token $resync_tokens generateup S_RESYNCHRONIZE.CONF 
;�сли в системе B не дергать отправку наверх сразу после ресинх., она не пошлет свой блок данных и при 
;�олучении в следующий раз сразу 2 блоков мы получим потерю и дубликат 
;ut "посылаем синхронизацию при ресинхронизации" 
generateup S_SYNC_MAJOR.IND 
qcount(in_queue) varset send_up_count 
TIMER_SEND_FROM_IN_QUEUE 1 timeevent send_from_in_queue_timer 
if $resync_tokens == 1 resync_data_token 
if $resync_tokens == 2 resync_sync_token 
if $resync_tokens == 3 resync_both 
if $resync_tokens == 4 resync_neither 
resync_both: 
1 varset has_data_token 
1 varset has_sync_token 
1 varset should_have_data_token 
1 varset should_have_sync_token 
return 
resync_neither: 
0 varset has_data_token 
0 varset has_sync_token 
0 varset should_have_data_token 
0 varset should_have_sync_token 
return 
resync_data_token: 
1 varset has_data_token 
0 varset has_sync_token 
1 varset should_have_data_token 
0 varset should_have_sync_token 
return 
resync_sync_token: 
0 varset has_data_token 
1 varset has_sync_token 
0 varset should_have_data_token 
1 varset should_have_sync_token 
return 

normal_discon_request: 
;ut CurrentSystemName () ": пришел запрос упорядоченного разъединения S_RELEASE" 
1 varset user_normal_discon 
generateup S_RELEASE.IND 
return 

forced_discon_request: 
;ut CurrentSystemName () ": пришел запрос безусловного разъединения S_U_ABORT" 
generateup S_U_ABORT.IND 
T_DISCONNECT.REQ generatedown address $addrA 
TIMER_DISCON_VARS_INIT 1 timeevent init_state 
return 
exit: 
```

## T_DISCONNECT.IND
```
;ut "пришла индикация дисконнекта T_DISCONNECT.IND" 
if ($user_normal_discon == 1) || ($user_forced_discon == 1) user_discon 
;reak 
if $is_connecting exit 
generateup S_P_ABORT.IND 
TIMER_DISCON_VARS_INIT 1 timeevent init_state 
return 
user_discon: 
if $user_forced_discon abort 
generateup S_RELEASE.CONF 
abort: 
TIMER_DISCON_VARS_INIT 1 timeevent init_state 

exit: 
```

## TIMER_DISCON_VARS_INIT
```
0 varset has_data_token 
0 varset has_sync_token 
untimer $transport_reconnect_timer 
untimer $transport_discon_delay_timer 
0 varset crc_sum_in 
0 varset crc_sum_out 
0 varset inc_crc_sum 
clearqueue out_queue 
clearqueue in_queue 
untimer $send_from_in_queue_timer 
untimer $send_from_out_queue_timer 
0 varset sync 
0 varset resync 
0 varset should_have_data_token 
0 varset should_have_sync_token 
0 varset user_forced_discon 
0 varset user_normal_discon 
0 varset init_state 
untimer $normal_discon_wait_timer 
0 varset is_connecting 
```

## TIMER_DISCONNECT_DELAY
```
T_CONNECT.REQ generatedown address $addrB 
TIMER_RECONNECT 260 timeevent transport_reconnect_timer 
```

## TIMER_NORMAL_DISCON_INIT
```
if $normal_discon_wait_times == 0 stop_try_normal_discon 
if qcount(out_queue) > 0 wait 
if $is_con_init == 1 req 
T_DISCONNECT.REQ generatedown address $addrA 
TIMER_DISCON_VARS_INIT 1 timeevent init_state 
return 
req: 
2 12 1 0 1 bufferit packet 
T_DATA.REQ generatedown userdata $packet 
return 
wait: 
TIMER_NORMAL_DISCON_INIT 250 timeevent normal_discon_wait_timer 
$normal_discon_wait_times - 1 varset normal_discon_wait_times 
return 
stop_try_normal_discon: 
if $is_con_init == 0 exit 
2 14 1 0 1 bufferit packet 
T_DATA.REQ generatedown userdata $packet 
1 varset user_forced_discon 
exit: 
```

## TIMER_RECONNECT
```
out "RECONNECT"
if $transport_con_try > 3 stop_try_reconnect 
T_DISCONNECT.REQ generatedown address $addrB 
TIMER_DISCONNECT_DELAY 25 timeevent transport_discon_delay_timer 
out CurrentSystemName () ": повторная отправка запроса на транспортное соединение " $transport_con_try 
$transport_con_try + 1 varset transport_con_try 
return 
stop_try_reconnect: 
generateup S_P_ABORT.IND 
```

## TIMER_SEND_FROM_IN_QUEUE
```
if $send_up_count == 0 all_sent 
dequeue(in_queue) varset data_from_in_queue 
userdata $data_from_in_queue generateup S_DATA.IND 
TIMER_SEND_FROM_IN_QUEUE 1 timeevent send_from_in_queue_timer 
$send_up_count - 1 varset send_up_count 
return 
all_sent: 
```

## TIMER_SEND_FROM_OUT_QUEUE
```
if $send_resync_count == 0 all_sent 
dequeue(out_queue) varset data_from_out_queue 
calccrc packet_crc $data_from_out_queue 
$crc_sum_out + $packet_crc varset crc_sum_out 
sizeof (data_from_out_queue) + 1 3 1 $data_from_out_queue sizeof (data_from_out_queue) bufferit packet 
T_DATA.REQ generatedown userdata $packet 
TIMER_SEND_FROM_OUT_QUEUE 1 timeevent send_from_out_queue_timer 
$send_resync_count - 1 varset send_resync_count 
return 
all_sent: 
token $resync_tokens generateup S_RESYNCHRONIZE.IND 
```

# Транспортный уровень
## T_INIT.REQ
```
declare reconnect_timer integer
declare delay_timer integer
declare disconnect_delay_timer integer
declare transport_disconnect_timer integer
declare con_try integer
declare resend_try integer
declare reconn_limit integer
declare addr integer
declare packet buffer
declare packet_crc integer
declare packet_send buffer
declare packet_disconn buffer
3 1 1 0 1 0 1 bufferit packet_disconn
calccrc packet_crc $packet_disconn
sizeof(packet_disconn)+1 $packet_crc 1 $packet_disconn sizeof(packet_disconn) bufferit packet_disconn
declare packet_conf buffer
declare packet_queue queue
declare data_from_queue buffer
declare data_crc_get integer
declare data_crc_calc integer
declare type integer
declare num integer
declare packet_inc buffer
declare data buffer
declare is_conn_initiator integer
declare waiting_for_disconn integer
0 varset waiting_for_disconn
declare state integer
0 varset state
declare keep_transport_conn integer
0 varset keep_transport_conn
declare is_sending_data integer
declare out_num integer
0 varset out_num
declare inc_num integer
0 varset inc_num

; номер исходящего пакета подтверждения
;declare out_num_conf integer
;0 varset out_num_conf

; ожидаемый номер входящего пакета подтверждения
declare inc_num_conf integer
0 varset inc_num_conf

; таймер повторной отправки данных
declare resend_timer integer

; если был нормальный дисконнект, игнорируем случайные разрывы 
declare normally_disconnected integer

; таймер дисконнекта перед коннектом
declare discon_before_con_timer integer

; таймер коннекта
declare connect_timer integer
```

## N_CONNECT.CONF
```
;break
1 varset state
untimer $reconnect_timer
if $keep_transport_conn == 1 keep_transport
address $address generateup T_CONNECT.CONF
return
keep_transport:
1 varset resend_try
0 varset keep_transport_conn
```

## N_CONNECT.IND
```
0 varset is_conn_initiator
1 varset state
if $keep_transport_conn == 1 keep_transport
address $address generateup  T_CONNECT.IND
0 varset normally_disconnected
return
keep_transport:
N_CONNECT.RESP generatedown address $address
1 varset resend_try
0 varset keep_transport_conn
```

## N_DATA.IND
```
if $state==0 exit
if sizeof(userdata) < 3 exit
unpack data_crc_get 1 packet_inc sizeof(userdata)-1 userdata
calccrc data_crc_calc $packet_inc
if $data_crc_get != $data_crc_calc badcrc
unpack type 1 num 1 data sizeof(packet_inc)-2 packet_inc
if $type == 1 disconn_req
if $type == 2 conf
3 2 1 $num 1 0 1 bufferit packet_conf
;$out_num_conf+1 varset out_num_conf
calccrc packet_crc $packet_conf
sizeof(packet_conf)+1 $packet_crc 1 $packet_conf sizeof(packet_conf) bufferit packet_conf
N_DATA.REQ generatedown userdata $packet_conf

if $num < $inc_num exit
$num+1 varset inc_num
;$num varset out_num_conf
userdata $data generateup T_DATA.IND
return
conf:

if $num < $inc_num_conf exit
$num+1 varset inc_num_conf
untimer $resend_timer
if qcount (packet_queue) > 0 send_from_queue
0 varset is_sending_data
return
send_from_queue:
dequeue (packet_queue) varset data_from_queue
sizeof(data_from_queue)+2 3 1 $out_num 1 $data_from_queue sizeof(data_from_queue) bufferit packet
$out_num+1 varset out_num
calccrc packet_crc $packet
sizeof(packet)+1 $packet_crc 1 $packet sizeof(packet) bufferit packet_send
N_DATA.REQ generatedown userdata $packet_send
TIMER_RESEND 41 timeevent resend_timer
1 varset resend_try
return
disconn_req:
1 varset waiting_for_disconn
1 varset normally_disconnected
return
badcrc:
;out "неверная контрольная сумма"
return

bad_conf:
;break
;out  CurrentSystemName() ": неверный номер подтверждения"

exit:
```

## N_DISCONNECT.IND
```
0 varset state
if $waiting_for_disconn == 0 unexp_disconn
0 varset state
0 varset keep_transport_conn
0 varset out_num
0 varset inc_num
0 varset waiting_for_disconn
0 varset is_sending_data
0 varset inc_num_conf
untimer $reconnect_timer
untimer $resend_timer
10 varset resend_try
generateup T_DISCONNECT.IND
return
unexp_disconn:
if $normally_disconnected == 1 already_disconnected

1 varset keep_transport_conn
1 varset resend_try
if $is_conn_initiator == 0 exit
N_CONNECT.REQ generatedown address $addr
TIMER_RECONNECT 41 timeevent reconnect_timer
1 varset con_try
1 varset resend_try
return
already_disconnected:

exit:
```

## T_CONNECT.REQ
```
;break
$address varset addr
TIMER_DISCONNECT_BEFORE_CONNECT 1 timeevent discon_before_con_timer
TIMER_CONNECT 25 timeevent connect_timer
```

## T_CONNECT.RESP
```
N_CONNECT.RESP generatedown address $address
```

## T_DATA.REQ
```
if $is_sending_data == 1 put_in_queue
sizeof(userdata)+2 3 1 $out_num 1 $userdata sizeof(userdata) bufferit packet
$out_num+1 varset out_num
calccrc packet_crc $packet
sizeof(packet)+1 $packet_crc 1 $packet sizeof(packet) bufferit packet_send
N_DATA.REQ generatedown userdata $packet_send
10 varset reconn_limit
TIMER_RESEND 41 timeevent resend_timer
1 varset resend_try
1 varset is_sending_data
return
put_in_queue:
queue packet_queue $userdata
```

## T_DISCONNECT.REQ
```
;break
1 varset normally_disconnected
N_DATA.REQ generatedown userdata $packet_disconn
N_DATA.REQ generatedown userdata $packet_disconn
N_DATA.REQ generatedown userdata $packet_disconn
N_DATA.REQ generatedown userdata $packet_disconn
N_DATA.REQ generatedown userdata $packet_disconn

TIMER_DELAY 21 timeevent delay_timer

0 varset state
0 varset keep_transport_conn
0 varset out_num
0 varset inc_num
0 varset waiting_for_disconn
0 varset is_sending_data
0 varset inc_num_conf
untimer $reconnect_timer
untimer $resend_timer
10 varset resend_try
```

## TIMER_CONNECT
```
1 varset is_conn_initiator
0 varset normally_disconnected
0 varset keep_transport_conn
10 varset reconn_limit
N_CONNECT.REQ generatedown address $addr
TIMER_RECONNECT 41 timeevent reconnect_timer
1 varset con_try
```

## TIMER_DELAY
```
N_DISCONNECT.REQ generatedown address $addr
```

## TIMER_DISCONNECT_BEFORE_CONNECT
```
1 varset normally_disconnected
; уведомляем о дисконнекте
N_DATA.REQ generatedown userdata $packet_disconn
N_DATA.REQ generatedown userdata $packet_disconn
N_DATA.REQ generatedown userdata $packet_disconn
N_DATA.REQ generatedown userdata $packet_disconn
N_DATA.REQ generatedown userdata $packet_disconn
; ставим задержку перед отправкой реального дисконнекта
TIMER_DELAY 21 timeevent delay_timer
; сбрасываем переменные
0 varset state
0 varset keep_transport_conn
0 varset out_num
0 varset inc_num
0 varset waiting_for_disconn
0 varset is_sending_data
0 varset inc_num_conf
untimer $reconnect_timer
untimer $resend_timer
10 varset resend_try
```

## TIMER_DISCONNECT_DELAY
```
N_CONNECT.REQ generatedown address $addr
TIMER_RECONNECT 41 timeevent reconnect_timer
```

## TIMER_RECONNECT
```
if $con_try > $reconn_limit stop_try_reconnect
N_DISCONNECT.REQ generatedown address $addr
TIMER_DISCONNECT_DELAY 2 timeevent disconnect_delay_timer

$con_try+1 varset con_try
1 varset resend_try
return
stop_try_reconnect:

N_DATA.REQ generatedown userdata $packet_disconn
N_DATA.REQ generatedown userdata $packet_disconn
N_DATA.REQ generatedown userdata $packet_disconn
N_DATA.REQ generatedown userdata $packet_disconn
N_DATA.REQ generatedown userdata $packet_disconn

TIMER_DELAY 21 timeevent delay_timer

0 varset state
0 varset keep_transport_conn
0 varset out_num
0 varset inc_num
0 varset waiting_for_disconn
0 varset is_sending_data
0 varset inc_num_conf
untimer $reconnect_timer
untimer $resend_timer
10 varset resend_try
generateup T_DISCONNECT.IND
```

## TIMER_RESEND
```
if $normally_disconnected exit
if $resend_try > 5 stop_try_resend
N_DATA.REQ generatedown userdata $packet_send
TIMER_RESEND 41 timeevent resend_timer
$resend_try+1 varset resend_try
return
stop_try_resend:
if qcount (packet_queue) == 0 exit
dequeue (packet_queue) varset data_from_queue
sizeof(data_from_queue)+2 3 1 $out_num 1 $data_from_queue sizeof(data_from_queue) bufferit packet
$out_num+1 varset out_num
calccrc packet_crc $packet
sizeof(packet)+1 $packet_crc 1 $packet sizeof(packet) bufferit packet_send
N_DATA.REQ generatedown userdata $packet_send
TIMER_RESEND 41 timeevent resend_timer
1 varset resend_try
return
exit:
0 varset is_sending_data
```
