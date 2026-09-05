# SIGECOM WCF client probe

This small project calls the original SIGECOM WCF service over net.tcp and prints the real DataSet as JSON.

## Run

1. Ensure the VPN is connected and you can reach `192.168.10.252:808`.
2. From a PowerShell session in this folder run:

```powershell
dotnet run --project .\sigecoom-wcf-client.csproj
```

If the VPN and internal network are correctly routed, the service should respond and print JSON from the real `GuiaRemisionService.Filtrar(...)` call.
