param(
    [string]$Host = "192.168.10.252",
    [int]$Port = 808,
    [string]$EndpointAddress = "net.tcp://192.168.10.252/ServicioBLL/GuiaRemisionService/",
    [string]$AssemblyPath = "",
    [string]$ClientType = "GuiaRemisionService.GuiaRemisionServiceClient",
    [string]$Namespace = "GuiaRemisionService"
)

Write-Host "Verificando acceso WCF SIGECOM..." -ForegroundColor Cyan

try {
    $result = Test-NetConnection -ComputerName $Host -Port $Port -ErrorAction Stop
    if ($result.TcpTestSucceeded) {
        Write-Host "OK: host responde en $Host:$Port" -ForegroundColor Green
    }
    else {
        Write-Host "ERROR: no hubo respuesta TCP en $Host:$Port" -ForegroundColor Red
        exit 1
    }
}
catch {
    Write-Host "ERROR: fallo la verificacion de red: $($_.Exception.Message)" -ForegroundColor Red
    exit 1
}

Add-Type -AssemblyName System.ServiceModel
Add-Type -AssemblyName System.Net

if (-not [string]::IsNullOrWhiteSpace($AssemblyPath)) {
    if (Test-Path $AssemblyPath) {
        Write-Host "Cargando assembly: $AssemblyPath" -ForegroundColor Yellow
        try {
            Add-Type -Path $AssemblyPath
            Write-Host "OK: assembly cargado" -ForegroundColor Green
        }
        catch {
            Write-Host "ERROR: no se pudo cargar el assembly: $($_.Exception.Message)" -ForegroundColor Red
            exit 1
        }
    }
    else {
        Write-Host "ERROR: no existe el assembly: $AssemblyPath" -ForegroundColor Red
        exit 1
    }
}

$bindingType = [System.ServiceModel.NetTcpBinding]
if (-not $bindingType) {
    Write-Host "ERROR: System.ServiceModel.NetTcpBinding no está disponible" -ForegroundColor Red
    exit 1
}

$binding = New-Object System.ServiceModel.NetTcpBinding
$binding.Security.Mode = [System.ServiceModel.SecurityMode]::Transport
$binding.Security.Transport.ClientCredentialType = [System.ServiceModel.TcpClientCredentialType]::Windows
$endpoint = New-Object System.ServiceModel.EndpointAddress($EndpointAddress)

Write-Host "Endpoint listo: $EndpointAddress" -ForegroundColor Cyan

try {
    $clientType = [Type]::GetType($ClientType)
    if (-not $clientType) {
        Write-Host "ERROR: no se encontro el tipo $ClientType en esta sesion. Carga el assembly generado del proyecto SIGECOM antes de ejecutar esta prueba." -ForegroundColor Red
        Write-Host "Ejemplo: Add-Type -Path 'C:\ruta\al\SIGECOM.dll'" -ForegroundColor Yellow
        exit 1
    }

    $client = New-Object $ClientType($binding, $endpoint)
    $client.ClientCredentials.Windows.ClientCredential = [System.Net.CredentialCache]::DefaultNetworkCredentials

    Write-Host "Llamando a Filtrar(0,0,0,0,0,'',0) ..." -ForegroundColor Cyan
    $ds = $client.Filtrar(0,0,0,0,0,"",0)

    if ($null -ne $ds -and $ds.Tables.Count -gt 0) {
        $count = $ds.Tables[0].Rows.Count
        Write-Host "OK: filas reales devueltas por el servicio = $count" -ForegroundColor Green
    }
    else {
        Write-Host "OK: el servicio respondió, pero no devolvió tablas" -ForegroundColor Yellow
    }
}
catch {
    Write-Host "ERROR al invocar el cliente WCF: $($_.Exception.Message)" -ForegroundColor Red
    if ($_.Exception.InnerException) {
        Write-Host "Inner: $($_.Exception.InnerException.Message)" -ForegroundColor Red
    }
    exit 1
}
