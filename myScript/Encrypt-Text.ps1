<#
start "" powershell -command "& { . .\Encrypt-Text.ps1 . }"
#>
Param(
	[Parameter(Mandatory=$true)][string]$WorkFolder)

$currPath = (Resolve-Path .\).Path
#write-host "CurrPath is $currPath"
$workPath = (Resolve-Path $WorkFolder).Path
#write-host "WorkPath is $workPath"

	function doEncrypt($input1, $mode1) {
		$result1 = & echo $input1 | C:\Users\Public\openssl\openssl.exe aes-256-cbc -a $mode1 -pass pass:myP_zzw8rd | Out-String
		return $result1
	}
	
	[reflection.assembly]::LoadWithPartialName("System.Windows.Forms") | Out-Null

	$label = New-Object Windows.Forms.Label
	$label.Location = New-Object Drawing.Point 50,30
	$label.Size = New-Object Drawing.Point 250,15
	$label.text = "Enter text to encrypt / decrypt :"
	
	$textfield = New-Object Windows.Forms.TextBox
	$textfield.Location = New-Object Drawing.Point 50,60
	$textfield.Size = New-Object Drawing.Point 200,40
	
	$encryptButton = New-Object Windows.Forms.Button
	$encryptButton.text = "Encrypt"
	$encryptButton.Location = New-Object Drawing.Point 50,90
	$encryptButton.Size = New-Object Drawing.Point 70,30
	$encryptButton.add_click({
		$return2 = doEncrypt $textfield.text "-e"
		write-host "return2 is $return2"
	})
	
	$decryptButton = New-Object Windows.Forms.Button
	$decryptButton.text = "Decrypt"
	$decryptButton.Location = New-Object Drawing.Point 150,90
	$decryptButton.Size = New-Object Drawing.Point 70,30
	$decryptButton.add_click({
		$return1 = doEncrypt $textfield.text "-d"
		write-host "return1 is $return1"
	})
	
	$form = New-Object Windows.Forms.Form
	$form.text = "Encrypt Helper"
	$form.controls.add($label)
	$form.controls.add($textfield)
	$form.controls.add($encryptButton)
	$form.controls.add($decryptButton)
	$form.ShowDialog()
	
	