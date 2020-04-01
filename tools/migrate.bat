@echo off
setlocal
:PROMPT
SET /P AREYOUSURE=This will remove the old migrations folder, are you sure? (Y/[N]) 
IF /I "%AREYOUSURE%" NEQ "Y" GOTO END

@RD /S /Q "%~dp0../Lobster.Data/Migrations"

cd "%~dp0../Lobster.Data"

dotnet ef migrations add InitialCreate

:END
endlocal

pause