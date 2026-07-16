Imports System.ServiceModel

Public Class frmListaPrecioClienteNuevo_Estados

    Private oListaClienteCabService As New ListaClienteCabService.ListaClienteCabServiceClient

    '======================Declaración de Variables==============================   
    Public IdLista As Integer
    Private dtDatos As DataTable

    Private Sub frmListaPrecioClienteNuevo_Estados_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oListaClienteCabService.Close()
        Catch ex As TimeoutException
            oListaClienteCabService.Abort()
        Catch ex As CommunicationException
            oListaClienteCabService.Abort()
        End Try
    End Sub

    Private Sub frmListaPrecioClienteNuevo_Estados_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmListaPrecioClienteNuevo_Estados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        listaDatos()
        Me.Size = New System.Drawing.Size(734, 230)
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oListaClienteCabService.ConsultarEstados(IdLista).Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


End Class