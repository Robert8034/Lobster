@echo off
setlocal
:PROMPT
SET /P AREYOUSURE=This will remove the old migrations folder, are you sure? (Y/[N]) 
IF /I "%AREYOUSURE%" NEQ "Y" GOTO END

cd "%~dp0../Lobster.Data"

dotnet ef database update

:END
endlocal

pause