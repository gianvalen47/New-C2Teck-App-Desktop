Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports System.ServiceModel

Public Class frmCliente_Usuario

    Private oClienteService As New ClienteService.ClienteServiceClient
    Private oUsuarioClienteService As New UsuarioClienteService.UsuarioClienteServiceClient
    Private oCliente As New ClienteService.Cliente

    Public IdCliente As Integer
    Public UsuarioCliente As String

    Public Actualizar As Boolean

    Private Sub frmCliente_Usuario_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmCliente_Usuario_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Actualizar = True Then
            Me.Text = "Crear Usuario de Cliente"
        Else
            Me.Text = "Actualizar Correo Electrónico"
        End If
        oCliente = oClienteService.MostrarPorID(IdCliente)
        txtCorreo.Focus()
    End Sub

    Public Function IsValidEmail(ByVal email As String) As Boolean
        Try
            If email = String.Empty Then Return False
            Dim re As Regex = New Regex("^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")
            Dim m As Match = re.Match(email)
            Return (m.Captures.Count <> 0)
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR EMAIL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Finalizar()
        Try
            oClienteService.Close()
            oUsuarioClienteService.Close()
        Catch ex As TimeoutException
            oClienteService.Abort()
            oUsuarioClienteService.Abort()
        Catch ex As CommunicationException
            oClienteService.Abort()
            oUsuarioClienteService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            oCliente = oClienteService.MostrarPorID(IdCliente)
            If oCliente.TipoContribuyente.IdTipoCon = 1 And toBlank(oCliente.RucCli) = "" Then
                MsgBox("¡Este Cliente no tiene RUC registrado, Verificar!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf oCliente.TipoContribuyente.IdTipoCon = 2 And toBlank(oCliente.DniCli) = "" Then
                MsgBox("¡Este Cliente no tiene DNI registrado, Verificar!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf oCliente.TipoContribuyente.IdTipoCon = 3 And toBlank(oCliente.RucCli) = "" Then
                MsgBox("¡Este Cliente no tiene RUC registrado, Verificar!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(txtCorreo.Text) = "" Then
                MsgBox("Debe Ingresar el Correo Electrónico del Cliente", MsgBoxStyle.Information, "Información")
                txtCorreo.Focus()
                Return False
            ElseIf IsValidEmail(txtCorreo.Text) = False Then
                MsgBox("Dirección de correo electronico no valida,el correo debe tener el formato: nombre@dominio.com", MsgBoxStyle.Information, "Información")
                txtCorreo.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnGuardar_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            If Actualizar = True Then

                Dim estado_process As Boolean
                estado_process = oUsuarioClienteService.ActualizarCorreo(IdCliente, txtCorreo.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process Then
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If

            Else
                If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    If ValidaCampos() Then
                        Dim registro As New UsuarioClienteService.UsuarioCliente
                        Dim cliente As New UsuarioClienteService.Cliente
                        Dim empresa As New UsuarioClienteService.Empresa
                        empresa.CodEmp = Session.sCodEmp
                        oCliente = oClienteService.MostrarPorID(IdCliente)
                        registro.Empresa = empresa
                        If oCliente.TipoContribuyente.IdTipoCon = 1 Then
                            registro.Usuario = Trim(oCliente.RucCli)
                        ElseIf oCliente.TipoContribuyente.IdTipoCon = 2 Then
                            registro.Usuario = Trim(oCliente.DniCli)
                        ElseIf oCliente.TipoContribuyente.IdTipoCon = 3 Then
                            registro.Usuario = Trim(oCliente.RucCli)
                        End If

                        registro.Correo = Trim(txtCorreo.Text)
                        cliente.IdCliente = IdCliente
                        registro.Cliente = cliente
                        registro.CodUsu = Session.sCodUsu
                        registro.NomPc = Session.sNomPc
                        registro.DirIp = Session.sDirIp

                        Insertar(registro)

                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR USUARIO CLIENTE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As UsuarioClienteService.UsuarioCliente)
        Try
            Dim estado_process As Boolean
            estado_process = oUsuarioClienteService.Insertar(registro)
            If estado_process Then
                UsuarioCliente = registro.Usuario
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR USUARIO CLIENTE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class