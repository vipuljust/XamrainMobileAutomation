@echo off

SET "filepath=%cd%"
SET "searchstring=Batchfiles"
SET "reportreplacestring="
CALL SET "reportpath=%%filepath:%searchstring%=%reportreplacestring%%%"

if exist %reportpath%\*.trx del "%reportpath%\*.trx"
if exist %reportpath%\*.trx.html del "%reportpath%\*.trx.html"

for /d %%x in (%filepath%\*) do @rd /s /q "%%x"

SET "replacestring=Q8MobileAutomation.dll"
CALL SET "modifiedpath=%%filepath:%searchstring%=%replacestring%%%"

vstest.console.exe %modifiedpath% /ResultsDirectory:%reportpath% /logger:trx;LogFileName=MobileRunResult.trx

rem ping 127.0.0.1 -n 10 > nul

exit
