Public Class Datos
  Public Shared Function TituloSistema() As String
    Dim lTitulo As String
        'lTitulo = Application.ProductName.ToString + " (Versión " + Application.ProductVersion.ToString + ")  -  " + _
        '      Application.CompanyName
        lTitulo = Application.ProductName.ToString + " (Versión " + Application.ProductVersion.ToString + ")  -  " +
             Session.sDesEmp
        Return lTitulo
  End Function
End Class
