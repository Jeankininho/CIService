SET SOURCE_BIN=bin\Release
SET DESTI_DIR=Publish

RMDIR  /S /Q %DESTI_DIR%

SET sourceDir=%DESTI_DIR%
MKDIR %sourceDir%

xcopy CIService.Service\%SOURCE_BIN%\* %DESTI_DIR%\CIService.Service\.

del /S /F /Q %DESTI_DIR%\CIService.Service\*.xml
del /S /F /Q %DESTI_DIR%\CIService.Service\*.pdb
del /S /F /Q %DESTI_DIR%\CIService.Service\*vshost.exe*
