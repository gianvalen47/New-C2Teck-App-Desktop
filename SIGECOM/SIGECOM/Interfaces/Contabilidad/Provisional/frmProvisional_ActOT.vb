Imports System.ServiceModel

Public Class frmProvisional_ActOT

    '===========================Servicios====================================
    Private oProvisionalService As New ProvisionalService.ProvisionalServiceClient
    Private oJobService As New JobService.JobServiceClient

    Public IdProvisional As Integer

    Private Sub frmProvisional_ActOT_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oProvisionalService.Close()
            oJobService.Close()
        Catch ex As TimeoutException
            oProvisionalService.Abort()
            oJobService.Abort()
        Catch ex As CommunicationException
            oProvisionalService.Abort()
            oJobService.Abort()
        End Try
    End Sub

    Private Sub frmProvisional_ActOT_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmProvisional_ActOT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblProvisional.Text = IdProvisional
        'Me.Text = "Actualizar Fecha Termino"
        'txtFecDoc.Value = Today
        txtNumJob.Focus()
    End Sub

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        Try
            If Len(Trim(txtNumJob.Text)) > 0 Then

                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                ElseIf (oJobService.Estado(txtNumJob.Text) = 16 Or oJobService.Estado(txtNumJob.Text) = 25) And oJobService.Regularizar(txtNumJob.Text) = False Then
                    MsgBox("Número de OT Liquidado o Facturado")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    'cmbUbicacion.Focus()
                End If
            Else
                'cmbUbicacion.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL OT : " + ex.Message)
        End Try
    End Sub

    Private Sub btnBuscarJob_Click(sender As Object, e As EventArgs) Handles btnBuscarJob.Click
        Try
            Dim frm As New frmBuscarJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.cod_job) <> Nothing Then
                    txtNumJob.Text = frm.cod_job
                Else
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarJob.Enabled = True Then
                e.Handled = True
                btnBuscarJob_Click(sender, e)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                ElseIf (oJobService.Estado(txtNumJob.Text) = 16 Or oJobService.Estado(txtNumJob.Text) = 25) And oJobService.Regularizar(txtNumJob.Text) = False Then
                    MsgBox("Número de OT Liquidado o Facturado")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    'cmbUbicacion.Focus()
                End If
            Else
                'cmbUbicacion.Focus()
            End If
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Try
            Dim estado_process As Boolean

            estado_process = oProvisionalService.ActualizarCodJob(IdProvisional, txtNumJob.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            If estado_process Then
                MsgBox("Se actualizo la OT correctamente ")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If

        Catch ex As Exception
            MsgBox("Error al Actualizar la OT : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class