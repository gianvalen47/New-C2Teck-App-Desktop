Public Class frmServicios_Cotizacion_Estado

    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private dtDatos As DataTable
    Public IdCotizacionSer As Integer

    Private Sub frmServicios_Cotizacion_Estado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oCotizacionServicioService) = False Then
                oCotizacionServicioService.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmServicios_Cotizacion_Estado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmServicios_Cotizacion_Estado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        listaDatos()
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

    End Sub
    Private Sub listaDatos()
        Try
            dtDatos = oCotizacionServicioService.ConsultarEstados(IdCotizacionSer).Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class