$users = (Invoke-WebRequest -UseBasicParsing 'http://localhost:5005/api/v1/auth/users?vigente=true').Content | ConvertFrom-Json
$out = @()
foreach ($u in $users) {
    try {
        $url = ('http://localhost:5005/api/v1/auth/perfil/check?username={0}' -f $u.username)
        $chk = (Invoke-WebRequest -UseBasicParsing $url).Content | ConvertFrom-Json
    } catch { $chk = $null }
    $code = if ($chk -and $chk.perfil) { $chk.perfil.codigo } else { $null }
    $name = if ($chk -and $chk.perfil) { $chk.perfil.nombre } else { $null }
    $obj = [PSCustomObject]@{ username=$u.username; fullName=$u.fullName; perfilCodigo=$code; perfilNombre=$name }
    $out += $obj
}
$filtered = $out | Where-Object { $_.perfilCodigo -ne $null -and ([int]$_.perfilCodigo) -ge 1 -and ([int]$_.perfilCodigo) -le 64 }
$filtered | ConvertTo-Json -Depth 6 | Out-File -FilePath inference_users_perfiles.json -Encoding utf8
Get-Content inference_users_perfiles.json
