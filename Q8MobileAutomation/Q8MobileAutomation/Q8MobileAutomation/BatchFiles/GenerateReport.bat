@echo off

SET "filepath=%cd%"
SET "searchstring=Batchfiles"
SET "reportreplacestring="
SET "toolreplacestring=TrxerConsole.exe"
CALL SET "reportpath=%%filepath:%searchstring%=%reportreplacestring%%%"
CALL SET "modifiedpath=%%filepath:%searchstring%=%toolreplacestring%%%"

%modifiedpath% "%reportpath%\MobileRunResult.trx"

"%reportpath%\MobileRunResult.trx.html"
