Imports System.ServiceModel

Public Class frmJob_EnviarCreditos

    Private oJobService As New JobService.JobServiceClient

    Public CodJob As String

    Private Sub frmJob_EnviarCreditos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
        Catch ex As TimeoutException
            oJobService.Close()
        Catch ex As CommunicationException
            oJobService.Close()
        End Try
    End Sub

    Private Sub frmJob_EnviarCreditos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmJob_EnviarCreditos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cbParcial.Checked = False

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click


        Try
            'cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ENVIAR la OT Nº " + CodJob + " a Créditos para su aprobación ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then

                'Dim NomPc As String = Dns.GetHostName
                'Dim DirIp As IPHostEntry = Dns.GetHostEntry(NomPc)
                Dim estado_process As Boolean
                estado_process = oJobService.EnviarCreditos(CodJob, cbParcial.Checked, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    MsgBox("La OT fue Enviada a Créditos correctamente.", MsgBoxStyle.Information)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [ENVIAR]:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
End Class