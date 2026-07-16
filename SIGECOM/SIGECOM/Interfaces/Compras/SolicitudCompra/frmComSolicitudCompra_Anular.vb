Imports System.ServiceModel
Public Class frmComSolicitudCompra_Anular

    '===========================Servicios====================================
    Private oSolicitudCompraService As New SolicitudCompraService.SolicitudCompraServiceClient

    '======================Declaración de Variables==============================   
    Public IdSolicitud As Integer

    Private Sub frmComSolicitudCompra_Anular_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmComSolicitudCompra_Anular_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComSolicitudCompra_Anular_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Anular Solicitud de Compra N°:" & IdSolicitud
        'Activar()
    End Sub

    Private Sub btnAprobar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        Try
            Dim estado_process As Boolean         
            If MsgBox("¿Está seguro de ANULAR la Solicitud de Compra N°: " & IdSolicitud & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If txtObservacion.Text = "" Then
                    MsgBox("Debe ingresar la Observación")
                    txtObservacion.Focus()
                Else
                    estado_process = oSolicitudCompraService.Anular(IdSolicitud, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    MsgBox("Se anuló la Solicitud de Compra correctamente ")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Anular la Solicitud de Compra : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oSolicitudCompraService.Close()
        Catch ex As TimeoutException
            oSolicitudCompraService.Abort()
        Catch ex As CommunicationException
            oSolicitudCompraService.Abort()
        End Try
    End Sub

End Class