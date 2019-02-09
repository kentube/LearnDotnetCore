#function Capture-Screen
#{
Param(
	[Parameter(Mandatory=$true)][string]$WorkFolder, 
	[int32]$Left, [int32]$Top, [int32]$Width, [int32]$Height,
	[int32]$CaptureWait=100, [int32]$SendKeyWait=200)

$currPath = (Resolve-Path .\).Path
write-host "CurrPath is $currPath"
$workPath = (Resolve-Path $WorkFolder).Path
write-host "WorkPath is $workPath"
		
	[reflection.assembly]::LoadWithPartialName("System.Windows.Forms")
	[Reflection.Assembly]::LoadWithPartialName("System.Drawing")
	function screenshot([Drawing.Rectangle]$bounds, $path) {	
	   $bmp = New-Object Drawing.Bitmap $bounds.width, $bounds.height
	   $graphics = [Drawing.Graphics]::FromImage($bmp)
	   $graphics.CopyFromScreen($bounds.Location, [Drawing.Point]::Empty, $bounds.size)
	   $bmp.Save($path)
	   $graphics.Dispose()
	   $bmp.Dispose()
	   write-host $path
	}
	[console]::beep(500,300)
	[console]::beep(2000,500)
	Start-Sleep -Seconds 5
	while($true) {
	
		$bounds = new-object Drawing.Rectangle $Left, $Top, $Width, $Height
		$dateandtime = Get-Date -Format MMdd-HHmmss
		$outName = $workPath + "\screen_" + $dateandtime + "_0.png"
		screenshot $bounds $outName	
		
		[console]::beep(800,100)
		Start-Sleep -milliseconds $CaptureWait
		
		Add-Type -AssemblyName System.Windows.Forms
		# [System.Windows.Forms.SendKeys]::SendWait("{PGDN}")
		[System.Windows.Forms.SendKeys]::SendWait(" ")
		[console]::beep(600,150)
		Start-Sleep -milliseconds $SendKeyWait
	}


# }

# Export-ModuleMember Capture-Screen
