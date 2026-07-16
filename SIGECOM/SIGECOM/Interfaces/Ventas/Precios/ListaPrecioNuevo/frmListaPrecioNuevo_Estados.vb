Imports System.ServiceModel

Public Class frmListaPrecioNuevo_Estados

    Private oListaPrecioCabService As New ListaPrecioCabService.ListaPrecioCabServiceClient

    '======================Declaración de Variables==============================   
    Public IdLista As Integer
    Private dtDatos As DataTable

    Private Sub frmListaPrecioNuevo_Estados_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oListaPrecioCabService.Close()
        Catch ex As TimeoutException
            oListaPrecioCabService.Abort()
        Catch ex As CommunicationException
            oListaPrecioCabService.Abort()
        End Try
    End Sub

    Private Sub frmListaPrecioNuevo_Estados_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmListaPrecioNuevo_Estados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        listaDatos()
        Me.Size = New System.Drawing.Size(728, 222)
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oListaPrecioCabService.ConsultarEstados(IdLista).Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class