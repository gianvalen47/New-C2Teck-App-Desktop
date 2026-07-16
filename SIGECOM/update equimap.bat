@echo off
REM === Configurar colores del fondo y texto de la ventana
REM === Fondo negro (0) + Texto verde claro (A)
color 0A
setlocal
REM === Configurar tamaño de la ventana (Columnas x Filas) ===
REM mode con: cols=100 lines=50
REM === Parámetros ===
set ORIGEN="\\192.168.10.252\systeck\SYSTECK"
set DESTINO="D:\EQUIMAP"
set hora=%time: =0%
set LOGFILE=log_upd_sys_equimap_%date:~6,4%-%date:~3,2%-%date:~0,2%_%hora:~0,2%_%hora:~3,2%.log

REM https://patorjk.com/software/taag/
REM Gracefull
echo  =====================================================================================
echo       ___  ____  ____  ____  ___  __ _           ____  __   _  _  __  _  _   __   ____ 
echo      / __)(___ \(_  _)(  __)/ __)(  / )   ___   (  __)/  \ / )( \(  )( \/ ) / _\ (  _ \
echo     ( (__  / __/  )(   ) _)( (__  )  (   (___)   ) _)(  O )) \/ ( )( / \/ \/    \ ) __/
echo      \___)(____) (__) (____)\___)(__\_)         (____)\__\)\____/(__)\_)(_/\_/\_/(__)  
echo.
echo  =====================================================================================
echo       INICIANDO COPIA CON ROBOCOPY
echo       Origen: %ORIGEN%
echo       Destino: %DESTINO%
echo       Log: %LOGFILE%
echo  =====================================================================================

REM ============== Ejecutar Robocopy ===============
robocopy %ORIGEN% %DESTINO% /MIR /COPY:DAT /R:3 /W:5 /MT:8 /LOG:%LOGFILE%

echo.
echo =====================================================================================
echo       ____  _  _  ____  ____  ____  ___  __ _ 
echo      / ___)( \/ )/ ___)(_  _)(  __)/ __)(  / )
echo      \___ \ )  / \___ \  )(   ) _)( (__  )  ( 
echo      (____/(__/  (____/ (__) (____)\___)(__\_)
echo.
echo =====================================================================================
echo        COPIA FINALIZADA
echo        Revisa el log en: %LOGFILE%
echo =====================================================================================
echo.
pause