Imports System.ServiceModel

Public Class frmComSolicitudCompra_VerCotizacion

    Private oSolicitudCompraDetService As New SolicitudCompraDetService.SolicitudCompraDetServiceClient

    Private dtDatos As DataTable
    Public IdSolicitud As Integer
    Public IdSolicitudDet As Integer
    Public IdCotizacionDet As Integer
    Public CodMer As String

    Private Sub frmComSolicitudCompra_VerCotizacion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            oSolicitudCompraDetService.Close()

        Catch ex As TimeoutException
            oSolicitudCompraDetService.Abort()

        Catch ex As CommunicationException
            oSolicitudCompraDetService.Abort()

        End Try
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmComSolicitudCompra_VerCotizacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComSolicitudCompra_VerCotizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Estilo As New Estilo
        Estilo.cargaEstiloGrid_Bucadores(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        Me.Text = "Cotizaciones de proveedores para el Código N°:" & CodMer
        listaDatos()
        If IdCotizacionDet <> 0 Then
            RowPossesion(dgvDatos, IdCotizacionDet)
        Else
            txtCotizacion.Select()
        End If
        'RowPossesion(dgvDatos, IdSolicitudDet)

    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)

        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows

        For Each row In rows

            If CInt(row.Cells("IdCotizacionDet").Value) = codigo Then
                lista.Row = row.Position
                lista.Col = 1

            End If
        Next

    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oSolicitudCompraDetService.MostrarCotizaciones(IdSolicitud, IdSolicitudDet).Tables(0)
            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox("Error al listar datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        txtDesPrv.Text = dgvDatos.CurrentRow.Cells("DesProv").Text
        txtCotizacion.Text = dgvDatos.CurrentRow.Cells("NumCotizacion").Text
        txtPreMer.Value = dgvDatos.CurrentRow.Cells("PreMer").Text
        txtDsctoMer.Value = dgvDatos.CurrentRow.Cells("DscMer").Text
        txtObservacion.Text = dgvDatos.CurrentRow.Cells("Observacion").Text
    End Sub
End Class