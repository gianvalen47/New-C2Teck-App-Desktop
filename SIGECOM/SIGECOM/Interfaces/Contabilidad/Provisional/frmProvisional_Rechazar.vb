Imports System.ServiceModel
Public Class frmProvisional_Rechazar

    '===========================Servicios====================================
    Private oProvisionalService As New ProvisionalService.ProvisionalServiceClient

    '======================Declaración de Variables==============================   
    Public IdProvisional As Integer

    Private Sub frmComProvisional_Aprobar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmComProvisional_Aprobar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComProvisional_Aprobar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = "Rechazar el Provisional N°:" & IdProvisional
    End Sub

    Private Sub btnRechazar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRechazar.Click
        Try
            Dim estado_process As Boolean           
            If MsgBox("¿Está seguro de RECHAZAR el Provisional N°: " & IdProvisional.ToString & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If txtObservacion.Text = "" Then
                    MsgBox("Debe ingresar la Observación")
                    txtObservacion.Focus()
                Else
                    estado_process = oProvisionalService.RechazarCajero(IdProvisional, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    MsgBox("Se rechazó correctamente el Provisional")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Rechazar el Provisional : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oProvisionalService.Close()
        Catch ex As TimeoutException
            oProvisionalService.Abort()
        Catch ex As CommunicationException
            oProvisionalService.Abort()
        End Try
    End Sub
End Class