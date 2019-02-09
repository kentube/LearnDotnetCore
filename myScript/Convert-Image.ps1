Param(
	[Parameter(Mandatory=$true)][string]$WorkFolder, 
	[string]$CropSetting="1340x650+5+28")

$currPath = (Resolve-Path .\).Path
write-host "CurrPath is $currPath"
$workPath = (Resolve-Path $WorkFolder).Path
write-host "WorkPath is $workPath"

$magick = "C:\Program Files\ImageMagick-7.0.8-Q8\magick"
$ocrexe = "c:\Program Files (x86)\Tesseract-OCR\tesseract.exe"

Get-ChildItem $workPath\screen_*_0.png | ForEach-Object {
	$imgSrc = $workPath + "\" + $_.name
	write-host $imgSrc
	$imgResult = $workPath + "\" + $_.name.Replace("_0.png","_1.png")
	$txtResult = $workPath + "\" + $_.name.Replace("_0.png","_2.dat")
	&  $magick $imgSrc `
		-crop $CropSetting `
		-set colorspace Gray -separate -evaluate-sequence Mean `
		-threshold 50% -negate `
		$imgResult
	&  $ocrexe `
		-c preserve_interword_spaces=1 `
		-c page_separator=  `
		$imgResult $txtResult
}

<#
	$imgResult = $_.name.Replace("screen_","result_")
	
Get-ChildItem $workPath\screen*0131-035745.png | ForEach-Object {

	&  $magick $imgSrc `
		-crop $CropSetting `
		-set colorspace Gray -separate -evaluate-sequence Mean -negate `
		$imgResult
#>