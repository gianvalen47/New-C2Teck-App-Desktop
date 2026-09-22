# Family WCF probe for SIGECOM

This probe validates the main service families exposed by the legacy SIGECOM WCF host.

## Supported families

- SeguridadService
- ClienteService
- GuiaRemisionService
- FacturaService
- BoletaService
- SunatService

## Run examples

```powershell
dotnet run --project .\tools\wcf-family-probe\wcf-family-probe.csproj -- SeguridadService
dotnet run --project .\tools\wcf-family-probe\wcf-family-probe.csproj -- ClienteService
dotnet run --project .\tools\wcf-family-probe\wcf-family-probe.csproj -- GuiaRemisionService
dotnet run --project .\tools\wcf-family-probe\wcf-family-probe.csproj -- FacturaService
dotnet run --project .\tools\wcf-family-probe\wcf-family-probe.csproj -- BoletaService
dotnet run --project .\tools\wcf-family-probe\wcf-family-probe.csproj -- SunatService
```

## Environment override

```powershell
$env:SIGECOM_TARGET_SERVICE = "SeguridadService"
$env:SIGECOM_USERNAME = "grios"
$env:SIGECOM_PASSWORD = "123"
$env:SIGECOM_COD_EMP = "08"
$env:SIGECOM_DOMAIN = ""
```

## Expected result

If the service is up on the original machine, the probe prints the DataSet rows or authentication result.

If the endpoint is down, the probe fails with `EndpointNotFoundException`, which confirms the WCF service is not listening in the current environment.
