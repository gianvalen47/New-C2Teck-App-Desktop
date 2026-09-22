$users = Invoke-RestMethod 'http://localhost:5005/api/v1/auth/users?vigente=true'
$list = @()
foreach ($u in $users) {
  $url = "http://localhost:5005/api/v1/auth/perfil/check?username=$($u.username)"
  $res = Invoke-RestMethod $url
  $list += [PSCustomObject]@{
    username = $u.username
    fullName = $u.fullName
    roleType = $res.roleType
    isAdmin = $res.isAdmin
    isConsultor = $res.isConsultor
    perfilCodigo = $res.perfilCodigo
    perfilNombre = $res.perfilNombre
  }
}
$list | ConvertTo-Json -Depth 5
