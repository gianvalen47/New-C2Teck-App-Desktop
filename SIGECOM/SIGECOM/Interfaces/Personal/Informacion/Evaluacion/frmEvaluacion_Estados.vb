Imports System.ServiceModel
Public Class frmEvaluacion_Estados

    '===========================Servicios====================================
    Private oEvaluacionService As New EvaluacionService.EvaluacionServiceClient

    '======================Declaración de Variables==============================   
    Public IdEvaluacion As Integer
    Private dtDatos As DataTable

    Private Sub frmEvaluacion_Estados_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oEvaluacionService.Close()
        Catch ex As TimeoutException
            oEvaluacionService.Abort()
        Catch ex As CommunicationException
            oEvaluacionService.Abort()
        End Try
    End Sub

    Private Sub frmEvaluacion_Estados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmEvaluacion_Estados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oEvaluacionService.ConsultarEstados(IdEvaluacion).Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class