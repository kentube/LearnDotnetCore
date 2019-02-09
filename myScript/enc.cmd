@echo off
if "%1"=="" goto :menu
C:\Users\Public\openssl\openssl.exe aes-256-cbc -a %*
goto :end

:menu
echo.
echo To encrypt:
echo. echo test string 1 ^| %0 -e
echo.
echo To decrypt:
echo. echo U2FsdGVkX1929mp4NXZc2xpBZw8r4Iey+E3otpV6QKHtsOw8l0uPiIK72x7Fs64p ^| %0 -d
:end
@echo on