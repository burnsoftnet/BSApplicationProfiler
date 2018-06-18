SET APPPATH=%CD%
cd "%APPPATH%"
installutil BSAP_MonitorService.exe
net start BSAPM
pause.


