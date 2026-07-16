Public Class frmVale_Duplicar

    Private oValeMaterialService As New ValeMaterialService.ValeMaterialServiceClient
    Private oJobService As New JobService.JobServiceClient

    Public IdVale As String
    Private Sub frmVale_Duplicar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oJobService) = False Then
                oJobService.Close()
            End If
            If isClosed(oValeMaterialService) = False Then
                oValeMaterialService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmVale_Duplicar_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmVale_Duplicar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtNumDoc.Select()

    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
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

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        Try
            If Len(Trim(txtNumJob.Text)) > 0 Then

                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                ElseIf oJobService.Estado(txtNumJob.Text) = 1 Then
                    MsgBox("Número de OT Anulado, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    txtObservacion.Focus()
                End If
            Else
                txtObservacion.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA OT : " + ex.Message)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnDuplicar_Click(sender As Object, e As EventArgs) Handles btnDuplicar.Click
        Try

            Dim estado_process As Boolean
            estado_process = oValeMaterialService.DuplicarVale(CInt(IdVale), txtNumDoc.Text, CDate(txtFecha.Text), txtNumJob.Text, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If estado_process Then
                MsgBox("Se duplico el vale correctamente" + txtNumDoc.Text.ToString, MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
        Catch ex As Exception
            MsgBox("ERROR [GEN-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class