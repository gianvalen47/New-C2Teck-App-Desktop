Imports System.ServiceModel

Public Class frmJob_ActualizarEstado

    Private oJobService As New JobService.JobServiceClient

    Public NumJob As String

    Private Sub frmJob_ActualizarEstado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
        End Try
    End Sub

    Private Sub frmJob_ActualizarEstado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmJob_ActualizarEstado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lblNumJob.Text = NumJob

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If txtObservacion.Text = "" Then
            MsgBox("Debe ingresar una observación, tenga cuidado", MsgBoxStyle.Information)
        Else
            If MsgBox("¿Está seguro de actualizar al estado inicial?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                ActualizarEstadoJob()
            End If
        End If

    End Sub

    Private Sub ActualizarEstadoJob()

        If oJobService.ActualizarEstadoJob(NumJob, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp) Then
            MsgBox("Se actualizo al estado inicial", MsgBoxStyle.Information)
            'Limpiar()
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Else
            MsgBox("Error en el proceso, comunicarse con el área de TI")
        End If

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class