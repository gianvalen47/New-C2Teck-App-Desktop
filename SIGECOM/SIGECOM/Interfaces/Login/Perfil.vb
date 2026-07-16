Public Class Perfil
    Private pcod_perfil As String '= "02"

    Public Property cod_perfil() As String
        Get
            Return pcod_perfil
        End Get
        Set(ByVal value As String)
            pcod_perfil = value
        End Set
    End Property
End Class
