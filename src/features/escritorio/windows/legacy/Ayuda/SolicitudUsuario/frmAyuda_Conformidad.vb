Imports System.Windows.Forms
Imports System.ServiceModel
Imports System.Net

Public Class frmAyuda_Conformidad

    Private oSolicitudUsuarioService As New SolicitudUsuarioService.SolicitudUsuarioServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Public IdSolicitud As Integer
    Public IdPer As Integer
    'Public Motivo As String
    Private Estado As String

    Private Sub frmAyuda_Conformidad_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oSolicitudUsuarioService) = False Then
                oSolicitudUsuarioService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmAyuda_Conformidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End If
    End Sub

    Private Sub frmAyuda_Conformidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtObservacion.Select()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If MsgBox("¿Está seguro de DAR CONFORMIDAD/DISCONFORMIDAD a la solicitud?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            Dim NomPc As String = Dns.GetHostName
            Dim DirIp As IPHostEntry = Dns.GetHostEntry(NomPc)
            Dim estado_process As Boolean
            estado_process = oSolicitudUsuarioService.Conformidad(IdSolicitud, IdPer, txtObservacion.Text, Session.sCodUsu, NomPc, DirIp.AddressList(0).ToString(), Estado)
            If estado_process Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If
        End If
    End Sub

    Private Sub rbConforme_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbConforme.CheckedChanged, rbDisconforme.CheckedChanged
        If rbConforme.Checked Then
            Estado = "CO"
        ElseIf rbDisconforme.Checked Then
            Estado = "DI"
        End If
    End Sub
End Class