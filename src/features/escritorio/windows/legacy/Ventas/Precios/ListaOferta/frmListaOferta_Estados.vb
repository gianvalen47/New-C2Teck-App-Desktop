Imports System.ServiceModel

Public Class frmListaOferta_Estados

    '===========================Servicios====================================
    Private oPrecioService As New PrecioService.PrecioServiceClient

    '======================Declaración de Variables==============================   
    Public IdLista As Integer
    Private dtDatos As DataTable

    Private Sub frmListaOferta_Estados_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPrecioService.Close()
        Catch ex As TimeoutException
            oPrecioService.Abort()
        Catch ex As CommunicationException
            oPrecioService.Abort()
        End Try
    End Sub

    Private Sub frmListaOferta_Estados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmListaOferta_Estados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        listaDatos()
    End Sub


    Private Sub listaDatos()
        Try
            dtDatos = oPrecioService.ConsultarEstadosListaOferta(IdLista).Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class