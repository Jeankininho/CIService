SET SOURCE_BIN=bin\Release
SET DESTI_DIR=Publish


dir

RMDIR  /S /Q %DESTI_DIR%

SET sourceDir=%DESTI_DIR%
MKDIR %sourceDir%

xcopy CIService.Service\%SOURCE_BIN%\* %DESTI_DIR%\CIService.Service\.  /e /i /y /s


del /S /F /Q %DESTI_DIR%\CIService.Service\*.xml
del /S /F /Q %DESTI_DIR%\CIService.Service\*.pdb
del /S /F /Q %DESTI_DIR%\CIService.Service\*vshost.exe*


move Publish $(build.artifactstagingdirectory)