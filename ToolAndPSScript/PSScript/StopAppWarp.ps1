echo StoppingAppWarp
#Stop-Process -processname java
netstat -a -o -n | select -skip 4 | % {$a = $_ -split ' {3,}'; New-Object 'PSObject' -Property @{Original=$_;Fields=$a}} | ? {$_.Fields[1] -match ":12346"} | % {taskkill /F /PID $_.Fields[4] }
