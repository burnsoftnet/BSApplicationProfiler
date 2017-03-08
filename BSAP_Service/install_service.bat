SET APPPATH=%CD%
cd "%APPPATH%"
installutil BSAP_Service.exe
net start BSAP
pause.


