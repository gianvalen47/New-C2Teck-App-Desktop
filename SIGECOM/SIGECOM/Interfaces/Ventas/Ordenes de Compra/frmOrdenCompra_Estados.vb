Imports System.ServiceModel
Public Class frmOrdenCompra_Estados

    '===========================Servicios====================================
    Private oOrdenCompraService As New OrdenCompraService.OrdenCompraServiceClient

    '======================Declaración de Variables==============================   
    Public IdOrden As Integer
    Private dtDatos As DataTable

    Private Sub frmOrdenCompra_Estados_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oOrdenCompraService.Close()
        Catch ex As TimeoutException
            oOrdenCompraService.Abort()
        Catch ex As CommunicationException
            oOrdenCompraService.Abort()
        End Try
    End Sub

    Private Sub frmOrdenCompra_Estados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmOrdenCompra_Estados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oOrdenCompraService.ConsultarEstados(IdOrden).Tables(0)
            dgvDatos.DataSource = dtDatos            
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class