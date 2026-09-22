# New-C2Teck-App-Desktop
Nuevo Proyecto

## Ejecutar WCF probe (SIGECOM VB.NET)

Si necesitas levantar el probe .NET que conecta con el servicio WCF legacy (proyecto usado para pruebas con SIGECOM VB.NET), hay un helper PowerShell y un script npm disponibles.

- Usar el PowerShell helper (más flexible):

```powershell
.\scripts\run-wcf-probe.ps1 -CompanyCode 08 -ProjectPath './wcf-probe/wcfprobe.csproj'
```

- Usar el script npm (Windows PowerShell):

```powershell
npm run wcf-probe
```

El script establece la variable de entorno `SIGECOM_COD_EMP` (por defecto `08`) y ejecuta `dotnet run --project <ruta>`.


## Uso de usuarios SIGECOM y variables de entorno

- Local fallback de usuarios (desarrollo): el archivo de usuarios local está en sigecoom-wcf-adapter/local_users.json.
- Ese archivo NO debe contener usuarios reales ni nombres ficticios de empresa; en esta copia se eliminó el usuario de ejemplo para evitar confusión.

- Para usar usuarios reales de SIGECOM (producción o integración con el WCF/adapter):
	- Asegúrate de que el adaptador legacy esté disponible y accesible desde tu máquina o red (ej.: `http://127.0.0.1:5000` o la URL VPN/producción).
	- Variables de entorno importantes (PowerShell examples):

```powershell
$env:SIGECOM_LEGACY_ADAPTER_BASE_URL = "http://127.0.0.1:5000"  # URL del adapter HTTP que expone la API legacy
$env:SIGECOM_WCF_BASE_URL = "http://192.168.10.252"            # (opcional) URL directa al WCF si aplica
$env:SIGECOM_ENABLE_LOCAL_FALLBACK = "0"                       # 0/false: desactiva el fallback local y obliga a usar el adapter/WCF
$env:SIGECOM_LOCAL_USERS_FILE = "C:\ruta\a\archivo\local_users.json"  # (opcional) ruta personalizada
```

- Para desarrollo rápido con usuarios definidos localmente, activa el fallback y apunta al archivo local (PowerShell):

```powershell
$env:SIGECOM_ENABLE_LOCAL_FALLBACK = "1"
$env:SIGECOM_LOCAL_USERS_FILE = "$(Resolve-Path sigecoom-wcf-adapter\local_users.json)"
```

- Notas:
	- El endpoint `/api/v1/auth/login` valida contra el adapter/WCF cuando `SIGECOM_ENABLE_LOCAL_FALLBACK` está desactivado; si el servicio legacy no está disponible, la autenticación fallará.
	- Si necesitas que cree o importe ~20 usuarios de prueba en `sigecoom-wcf-adapter/local_users.json` para desarrollo, dímelo y lo agrego automáticamente.

