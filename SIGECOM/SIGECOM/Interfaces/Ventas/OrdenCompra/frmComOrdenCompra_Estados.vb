Imports System.ServiceModel
Public Class frmComOrdenCompra_Estados

    '===========================Servicios====================================
    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient

    '======================Declaración de Variables==============================   
    Public IdOrden As Integer
    Private dtDatos As DataTable

    Private Sub frmComOrdenCompra_Estados_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oOrdenesCompraService.Close()
        Catch ex As TimeoutException
            oOrdenesCompraService.Abort()
        Catch ex As CommunicationException
            oOrdenesCompraService.Abort()
        End Try
    End Sub

    Private Sub frmComOrdenCompra_Estados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComOrdenCompra_Estados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oOrdenesCompraService.ConsultarEstados(IdOrden).Tables(0)            
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class