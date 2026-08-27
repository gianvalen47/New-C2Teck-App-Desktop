Imports System.ServiceModel

Public Class frmDespachoEstados

    Private oDespachoCabService As New DespachoCabService.DespachoCabServiceClient

    Public IdDespachoCab As String
    Private dtEstados As DataTable

    Private Sub frmDespachoEstados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        listaDatos()

    End Sub

    Private Sub frmDespachoEstados_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmDespachoEstados_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oDespachoCabService.Close()
        Catch ex As TimeoutException
            oDespachoCabService.Abort()
        Catch ex As CommunicationException
            oDespachoCabService.Abort()
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtEstados = oDespachoCabService.ConsultarEstados(IdDespachoCab).Tables(0)
            dgvDatos.DataSource = dtEstados
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class