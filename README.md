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

