Imports System.ServiceModel

Public Class frmComSolicitudCompra_Estados

    Private oSolicitudCompraService As New SolicitudCompraService.SolicitudCompraServiceClient

    Public IdSolicitud As Integer
    Private dtDatos As DataTable

    Private Sub frmComSolicitudCompra_Estados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComSolicitudCompra_Estados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        listaDatos()
        Me.Text = "Estados de la Solicitud de Compra N°:" & IdSolicitud
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oSolicitudCompraService.ConsultarEstados(IdSolicitud).Tables(0)
            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox("Error al listar los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class