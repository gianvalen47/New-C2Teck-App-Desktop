Imports System.ServiceModel

Public Class frmProvisional_ActFecTermino

    '===========================Servicios====================================
    Private oProvisionalService As New ProvisionalService.ProvisionalServiceClient

    Public IdProvisional As Integer

    Private Sub frmProvisional_ActFecTermino_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oProvisionalService.Close()
        Catch ex As TimeoutException
            oProvisionalService.Abort()
        Catch ex As CommunicationException
            oProvisionalService.Abort()
        End Try
    End Sub

    Private Sub frmProvisional_ActFecTermino_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmProvisional_ActFecTermino_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblProvisional.Text = IdProvisional
        Me.Text = "Actualizar Fecha Termino"
        txtFecDoc.Value = Today
        txtFecDoc.Focus()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Dim estado_process As Boolean

            estado_process = oProvisionalService.ActualizarFecFinal(IdProvisional, txtFecDoc.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            If estado_process Then
                MsgBox("Se actualizo la fecha de termino correctamente ")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If

        Catch ex As Exception
            MsgBox("Error al Actualizar la fecha de termino : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class