SET APPPATH=%CD%
cd "%APPPATH%"
net stop BSAPM
installutil /u BSAP_MonitorService.exe
pause.


