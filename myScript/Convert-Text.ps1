Param(
	[Parameter(Mandatory=$true)][string]$SourceFile, 
	[string]$DestFile)
	
$workPath = (Resolve-Path $WorkFolder).Path
write-host $workPath

$file = New-Object System.IO.StreamReader -Arg $SourceFile
$outstream = [System.IO.StreamWriter] $DestFile
$count = 0 

while ($line = $file.ReadLine()) {
	$count += 1
	$s = $line -replace "`n", "`r`n"
	$outstream.WriteLine($s)
}
$file.close()
$outstream.close()

Write-Host ([string] $count + ' lines have been processed. ' + $DestFile)