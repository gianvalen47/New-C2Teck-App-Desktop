Public Class frmActivoFijo_Memos

    '===========================Servicios====================================================
    Private oActivoFijoService As New ActivoFijoService.ActivoFijoServiceClient
    Private dtDatos As New DataTable
    Public CodActivo As String

    Private Sub frmActivoFijo_Memos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        dtDatos = oActivoFijoService.ConsultarMemos(CodActivo).Tables(0)
        dgvDatos.DataSource = dtDatos

    End Sub
End Class