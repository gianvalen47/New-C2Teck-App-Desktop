Imports System.ServiceModel
Public Class frmReportePedidos
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPedidoService As New PedidoService.PedidoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtOficina As DataTable
    Private dtAlmacen As DataTable
    Private dtReporte As DataTable
    Dim IdCliente As String

    Private Sub frmReportPedido_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oPedidoService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oPedidoService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oPedidoService.Abort()
            oSeguridadService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F12 Then
            btnBuscarCliente_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    Private Sub rbBuscarCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarCliente.CheckedChanged
        txtCliente.Text = ""
        IdCliente = 0
        txtFechaInicio.Value = Today
        txtFechaFin.Value = Today
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If
        txtCliente.Select()
    End Sub

    Private Sub frmReportePedidos_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 289)
        '/*************************************************************************************/

        LlenarCombos()

        rbExportExcel.Enabled = IIf(oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = True, True, False)

    End Sub

    Private Sub LlenarCombos()
        Try           

            '========================================== OFICINA ===================================================
            dtOficina = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            Dim row As DataRow = dtOficina.NewRow
            row(0) = ""
            row(1) = "(Todos)"
            dtOficina.Rows.InsertAt(row, 0)
            cbOficina.DataSource = dtOficina
            cbOficina.DisplayMember = "DesOfi"
            cbOficina.ValueMember = "CodOfi"
            cbOficina.DropDownList.Columns(0).DataMember = "CodOfi"
            cbOficina.DropDownList.Columns(1).DataMember = "DesOfi"
            cbOficina.SelectedIndex = 0
            dtOficina = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try

    End Sub

    Private Sub cbOficina_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOficina.ValueChanged
        dtAlmacen = oMaestroService.MostrarLocaciones(Session.sCodEmp, cbOficina.Value, Session.sCodUsu).Tables(0)
        Dim row As DataRow = dtAlmacen.NewRow
        row(0) = 0
        row("DesAlm") = "(Todos)"
        dtAlmacen.Rows.InsertAt(row, 0)
        cbAlmacen.DataSource = dtAlmacen
        cbAlmacen.DisplayMember = "DesAlm"
        cbAlmacen.ValueMember = "IdLocacion"
        cbAlmacen.DropDownList.Columns(0).DataMember = "CodAlm"
        cbAlmacen.DropDownList.Columns(1).DataMember = "DesAlm"
        cbAlmacen.SelectedIndex = 0
        dtAlmacen = Nothing
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpPedidoInternoDet

            dtReporte = oPedidoService.ReportePedidoDetalle(cbAlmacen.Value, IdCliente, txtFechaInicio.Value, txtFechaFin.Value, txtNumJob.Text, txtNumOrden.Text).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                If rbExportExcel.Checked Then
                    DataGridView1.DataSource = dtReporte
                    Dim Export As Boolean = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente")
                    End If
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    reporte.SetParameterValue("pDesOfi", cbOficina.Text)
                    reporte.SetParameterValue("pDesAlm", cbAlmacen.Text)
                    reporte.SetParameterValue("pDesCli", IIf(IdCliente = 0, "Todos", txtCliente.Text))
                    reporte.SetParameterValue("pFecIni", txtFechaInicio.Value.ToString)
                    reporte.SetParameterValue("pFecFin", txtFechaFin.Value.ToString)
                    reporte.SetParameterValue("pNumJob", txtNumJob.Text)
                    reporte.SetParameterValue("pNumOrden", txtNumOrden.Text)
                    forma.Text = "Reporte de Pedido Interno para Importar"

                    forma.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
    Private Sub frmReporteImport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class