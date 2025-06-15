bcdedit /set useplatformtick yes

bcdedit /set disabledynamictick yes

fsutil behavior set memoryusage 2

net stop SysMain

sc config SysMain start= disabled

powercfg.exe /hibernate off

powercfg -duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61

powercfg.exe /h /type reduced

fsutil behavior set DisableDeleteNotify 0

cd %windir%\System32

start control

echo msgbox "Vc tem que ativar o novo plano de energia (ULTIMATE PERFORMANCE) manualmente no Painel de Controle do Windows", vbExclamation, "AVISO" > "%windir%\aviso.vbs" && start "" "%windir%\aviso.vbs"

timeout /t 1

del %windir%\aviso.vbs

