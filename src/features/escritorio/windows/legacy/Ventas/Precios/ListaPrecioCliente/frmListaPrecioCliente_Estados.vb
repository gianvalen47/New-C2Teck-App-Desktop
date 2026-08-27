Imports System.ServiceModel

Public Class frmListaPrecioCliente_Estados

    Private oListaPrecioClienteService As New ListaPrecioClienteService.ListaPrecioClienteServiceClient

    '======================Declaración de Variables==============================   
    Public IdLista As Integer
    Private dtDatos As DataTable

    Private Sub frmListaPrecioCliente_Estados_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oListaPrecioClienteService.Close()
        Catch ex As TimeoutException
            oListaPrecioClienteService.Abort()
        Catch ex As CommunicationException
            oListaPrecioClienteService.Abort()
        End Try
    End Sub

    Private Sub frmListaPrecioCliente_Estados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmListaPrecioCliente_Estados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oListaPrecioClienteService.ConsultarEstados(IdLista).Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class