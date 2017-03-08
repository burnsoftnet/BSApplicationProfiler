SET APPPATH=%CD%
cd "%APPPATH%"
net stop BSAP
installutil /u BSAP_Service.exe
pause.


