@echo off
REM === Configurar colores del fondo y texto de la ventana
REM === Fondo negro (0) + Texto verde claro (A) --
color 0A
setlocal
REM === Configurar tamaño de la ventana (Columnas x Filas) ===
REM mode CON: COLS=50 LINES=50
REM === Parámetros ===
set ORIGEN="\\192.168.18.252\Sistema\SYSTECK"
set DESTINO="D:\MINSOL"
set hora=%time: =0%
set LOGFILE=log_upd_sys_minsol_%date:~6,4%-%date:~3,2%-%date:~0,2%_%hora:~0,2%_%hora:~3,2%.log

REM https://patorjk.com/software/taag/
REM Gracefull
echo  =====================================================================================
echo       ___  ____  ____  ____  ___  __ _           _  _  __  __ _  ____   __   __   
echo      / __)(___ \(_  _)(  __)/ __)(  / )   ___   ( \/ )(  )(  ( \/ ___) /  \ (  )  
echo     ( (__  / __/  )(   ) _)( (__  )  (   (___)  / \/ \ )( /    /\___ \(  O )/ (_/\
echo      \___)(____) (__) (____)\___)(__\_)         \_)(_/(__)\_)__)(____/ \__/ \____/
echo.
echo  =====================================================================================
echo		INICIANDO COPIA CON ROBOCOPY
echo		Actualizando el SYSTECK en MINSOL
echo		Origen: %ORIGEN%
echo		Destino: %DESTINO%
echo		Log: %LOGFILE%
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