Imports System.ServiceModel

Public Class frmComSolicitudCompra_Aprobar

    Private oSolicitudCompraService As New SolicitudCompraService.SolicitudCompraServiceClient

    Public IdSolicitud As Integer

    Private Sub frmComSolicitudCompra_Aprobar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            oSolicitudCompraService.Close()

        Catch ex As TimeoutException
            oSolicitudCompraService.Abort()

        Catch ex As CommunicationException
            oSolicitudCompraService.Abort()

        End Try
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmComSolicitudCompra_Aprobar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        If IdSolicitud = 0 Then
            MsgBox("Debe ingresar el numero de la solicitud de compra")
            Return False
        ElseIf cbRechazar.Checked = True And toBlank(txtObservacion.Text) = "" Then
            MsgBox("Debe ingresar una observacion debido al rechazo")
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub frmComSolicitudCompra_Aprobar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Aprobar Solicitud N°:" & IdSolicitud
    End Sub

    Private Sub btnAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAprobar.Click
        Try

            Dim estado_process As Boolean

            If ValidaCampos() Then

                If cbAprobar.Checked Then
                    If MsgBox("¿Está seguro de APROBAR la solicitud N°:" & IdSolicitud & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                        estado_process = oSolicitudCompraService.Aprobar(IdSolicitud, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        MsgBox("Se aprobó la solicitud correctamente ")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If

                ElseIf cbRechazar.Checked Then
                    If MsgBox("¿Está seguro de DESAPROBAR la solicitud N°:" & IdSolicitud & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                        estado_process = oSolicitudCompraService.Rechazar(IdSolicitud, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        MsgBox("Se desaprobó la solicitud correctamente ")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If

                End If
            End If

        Catch ex As Exception
            MsgBox("Error al aprobar/desaprobar la solicitud de compra : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class