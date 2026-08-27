Imports System.ServiceModel
Public Class frmComSolicitudGasto_Anular

    '===========================Servicios====================================
    Private oSolicitudGastoService As New SolicitudGastoService.SolicitudGastoServiceClient

    '======================Declaración de Variables==============================   
    Public IdGasto As Integer

    Private Sub frmComSolicitudGasto_Anular_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmComSolicitudGasto_Anular_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComProvisional_Aprobar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = "Anular la Solicitud de Gastos N°:" & IdGasto
    End Sub

    Private Sub btnAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        Try
            Dim estado_process As Boolean
            If MsgBox("¿Está seguro de ANULAR la Solicitud de Gastos N°: " & IdGasto & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If txtObservacion.Text = "" Then
                    MsgBox("Debe ingresar la Observación")
                    txtObservacion.Focus()
                Else
                    estado_process = oSolicitudGastoService.Anular(IdGasto, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    MsgBox("Se anuló la solicitud de gastos correctamente ")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Anular Solicitud de Gastos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oSolicitudGastoService.Close()
        Catch ex As TimeoutException
            oSolicitudGastoService.Abort()
        Catch ex As CommunicationException
            oSolicitudGastoService.Abort()
        End Try
    End Sub
End Class