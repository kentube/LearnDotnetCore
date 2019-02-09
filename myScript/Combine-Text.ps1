Param(
	[Parameter(Mandatory=$true)][string]$WorkFolder)

$currPath = (Resolve-Path .\).Path
write-host "CurrPath is $currPath"
$workPath = (Resolve-Path $WorkFolder).Path
write-host "WorkPath is $workPath"

New-Item -ItemType file $workPath\screen_all_3.txt –force
Get-Content $workPath\screen_*_2.dat.txt | Add-Content $workPath\screen_all_3.txt
