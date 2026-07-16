Imports System.Windows.Forms
Imports System.ServiceModel

Public Class frmEstadoCliente

    Private oReporteVentaService As New ReporteVentaService.ReporteVentaServiceClient
    Private oClienteService As New ClienteService.ClienteServiceClient
    Private oOcurrenciaClienteService As New OcurrenciaClienteService.OcurrenciaClienteServiceClient
    Private oContactoService As New ContactoService.ContactoServiceClient
    Private oCondicionPagoClienteService As New CondicionPagoClienteService.CondicionPagoClienteServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private IdCliente As Integer
    Dim dtTable As DataTable
    Dim dtTable2 As DataTable
    Dim row As DataRow
    Dim col As DataColumn
    Dim dtReporte As New DataTable
    Dim MesesNoCompra As Integer
    Dim MesesNoCompraInd As Integer

    Private Sub frmEstadoCliente_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oReporteVentaService.Close()
            oClienteService.Close()
            oOcurrenciaClienteService.Close()
            oContactoService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oReporteVentaService.Abort()
            oClienteService.Abort()
            oOcurrenciaClienteService.Abort()
            oContactoService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oReporteVentaService.Abort()
            oClienteService.Abort()
            oOcurrenciaClienteService.Abort()
            oContactoService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmEstadoCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F2 Then
            TbOpciones.SelectedIndex = "1"
        ElseIf e.KeyCode = Keys.F3 Then
            TbOpciones.SelectedIndex = "2"
        ElseIf e.KeyCode = Keys.F4 Then
            TbOpciones.SelectedIndex = "3"
        ElseIf e.KeyCode = Keys.F4 Then
            TbOpciones.SelectedIndex = "3"
        End If
    End Sub

    Private Sub frmEstadoCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 293)
        '/*************************************************************************************/

        tbVentas.Enabled = False
        tbEstadisticas.Enabled = False
        tbIndicadores.Enabled = False
        tbOcurrencias.Enabled = False
    End Sub

    Private Sub TabOpciones_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.Tab.TabEventArgs) Handles TbOpciones.SelectedTabChanged
        SeleccionTab(tbOpciones.SelectedIndex)
    End Sub

    Private Sub SeleccionTab(ByVal Indice As Int16)
        Select Case tbOpciones.SelectedIndex
            Case 0
                '------ TabPage de Cliente
            Case 1
                '------ TabPage de Ventas
                Try
                    Dim dtVentas As New DataTable
                    Dim Date1 As Date
                    Dim Date2 As Date
                    Dim totalAntes As Integer = 0
                    Dim totalEnFecha As Integer = 0
                    Dim totalDespues As Integer = 0
                    Dim totalNoVencido As Integer = 0
                    Dim totalVencido As Integer = 0

                    dtVentas = oReporteVentaService.TarjetaCliente(Session.sFecha.Year, txtCodCli.Text, 1).Tables(0)

                    dtTable = dtVentas.Copy
                    dtTable.Clear()

                    For i = 0 To dtVentas.Rows.Count - 1
                        If dtVentas.Rows(i).Item(16) = "1" Or dtVentas.Rows(i).Item(16) = "2" Or dtVentas.Rows(i).Item(16) = "3" Then
                            Date1 = dtVentas.Rows(i).Item(15)
                            Date2 = dtVentas.Rows(i).Item(2)


                            row = dtTable.NewRow
                            row(0) = dtVentas.Rows(i).Item(0)
                            row(1) = dtVentas.Rows(i).Item(1)
                            row(2) = dtVentas.Rows(i).Item(2)
                            row(3) = dtVentas.Rows(i).Item(3)
                            row(4) = dtVentas.Rows(i).Item(4)
                            row(5) = dtVentas.Rows(i).Item(5)
                            row(6) = dtVentas.Rows(i).Item(6)
                            row(7) = dtVentas.Rows(i).Item(7)
                            row(8) = dtVentas.Rows(i).Item(8)
                            row(9) = dtVentas.Rows(i).Item(9)
                            row(10) = dtVentas.Rows(i).Item(10)
                            row(11) = dtVentas.Rows(i).Item(11)
                            row(12) = dtVentas.Rows(i).Item(12)
                            row(13) = dtVentas.Rows(i).Item(13)
                            row(14) = DateDiff(DateInterval.Day, Date1, Date2)
                            row(15) = dtVentas.Rows(i).Item(15)
                            row(16) = dtVentas.Rows(i).Item(16)

                            dtTable.Rows.Add(row)
                        Else
                            row = dtTable.NewRow
                            row(0) = dtVentas.Rows(i).Item(0)
                            row(1) = dtVentas.Rows(i).Item(1)
                            row(2) = dtVentas.Rows(i).Item(2)
                            row(3) = dtVentas.Rows(i).Item(3)
                            row(4) = dtVentas.Rows(i).Item(4)
                            row(5) = dtVentas.Rows(i).Item(5)
                            row(6) = dtVentas.Rows(i).Item(6)
                            row(7) = dtVentas.Rows(i).Item(7)
                            row(8) = dtVentas.Rows(i).Item(8)
                            row(9) = dtVentas.Rows(i).Item(9)
                            row(10) = dtVentas.Rows(i).Item(10)
                            row(11) = dtVentas.Rows(i).Item(11)
                            row(12) = dtVentas.Rows(i).Item(12)
                            row(13) = dtVentas.Rows(i).Item(13)
                            row(14) = dtVentas.Rows(i).Item(14)
                            row(15) = dtVentas.Rows(i).Item(15)
                            row(16) = dtVentas.Rows(i).Item(16)

                            dtTable.Rows.Add(row)
                        End If

                        If dtVentas.Rows(i).Item(16) = "1" Then
                            totalAntes = totalAntes + 1
                        ElseIf dtVentas.Rows(i).Item(16) = "2" Then
                            totalEnFecha = totalEnFecha + 1
                        ElseIf dtVentas.Rows(i).Item(16) = "3" Then
                            totalDespues = totalDespues + 1
                        ElseIf dtVentas.Rows(i).Item(16) = "4" Then
                            totalNoVencido = totalNoVencido + 1
                        ElseIf dtVentas.Rows(i).Item(16) = "5" Then
                            totalVencido = totalVencido + 1
                        End If

                    Next i

                    lblAntes.Text = "Antes (" & totalAntes & ")"
                    lblEnFecha.Text = "En Fecha (" & totalEnFecha & ")"
                    lblDespues.Text = "Después (" & totalDespues & ")"
                    lblNoVencido.Text = "No Vencido (" & totalNoVencido & ")"
                    lblVencido.Text = "Vencido (" & totalVencido & ")"

                    dgvVentas.DataSource = dtTable

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
                End Try

            Case 2
                '------ TabPage de Estadisticas
                Try
                    Dim dtEstadisticas As New DataTable
                    Dim totalAntesE As Integer = 0
                    Dim totalEnFechaE As Integer = 0
                    Dim totalDespuesE As Integer = 0
                    Dim totalNoVencidoE As Integer = 0
                    Dim totalVencidoE As Integer = 0
                    Dim totalPagoAntes As Double = 0.0
                    Dim totalPagoEnFecha As Double = 0.0
                    Dim totalPagoDespues As Double = 0.0
                    Dim totalPendienteNoVencido As Double = 0.0
                    Dim totalPendienteVencido As Double = 0.0
                    Dim I As Integer

                    dtEstadisticas = oReporteVentaService.TarjetaCliente(Session.sFecha.Year, txtCodCli.Text, 1).Tables(0)
                    'DataGridView1.DataSource = dtEstadisticas

                    For i = 0 To dtEstadisticas.Rows.Count - 1

                        If dtEstadisticas.Rows(I).Item("Tipo") = "1" Then
                            totalAntesE = totalAntesE + 1
                            totalPagoAntes = totalPagoAntes + dtEstadisticas.Rows(I).Item("TotalDol")
                        ElseIf dtEstadisticas.Rows(I).Item("Tipo") = "2" Then
                            totalEnFechaE = totalEnFechaE + 1
                            totalPagoEnFecha = totalPagoEnFecha + dtEstadisticas.Rows(I).Item("TotalDol")
                        ElseIf dtEstadisticas.Rows(I).Item("Tipo") = "3" Then
                            totalDespuesE = totalDespuesE + 1
                            totalPagoDespues = totalPagoDespues + dtEstadisticas.Rows(I).Item("TotalDol")
                        ElseIf dtEstadisticas.Rows(I).Item("Tipo") = "4" Then
                            totalNoVencidoE = totalNoVencidoE + 1
                            totalPendienteNoVencido = totalPendienteNoVencido + dtEstadisticas.Rows(I).Item("TotalDol") - dtEstadisticas.Rows(I).Item("PagosDol")
                        ElseIf dtEstadisticas.Rows(I).Item("Tipo") = "5" Then
                            totalVencidoE = totalVencidoE + 1
                            totalPendienteVencido = totalPendienteVencido + dtEstadisticas.Rows(I).Item("TotalDol") - dtEstadisticas.Rows(I).Item("PagosDol")
                        End If

                        'If dtEstadisticas.Rows(I).Item(16) = "1" Then
                        '    totalAntesE = totalAntesE + 1
                        '    totalPagoAntes = totalPagoAntes + dtEstadisticas.Rows(I).Item(12)
                        'ElseIf dtEstadisticas.Rows(I).Item(16) = "2" Then
                        '    totalEnFechaE = totalEnFechaE + 1
                        '    totalPagoEnFecha = totalPagoEnFecha + dtEstadisticas.Rows(I).Item(12)
                        'ElseIf dtEstadisticas.Rows(I).Item(16) = "3" Then
                        '    totalDespuesE = totalDespuesE + 1
                        '    totalPagoDespues = totalPagoDespues + dtEstadisticas.Rows(I).Item(12)
                        'ElseIf dtEstadisticas.Rows(I).Item(16) = "4" Then
                        '    totalNoVencidoE = totalNoVencidoE + 1
                        '    totalPendienteNoVencido = totalPendienteNoVencido + dtEstadisticas.Rows(I).Item(12) - dtEstadisticas.Rows(I).Item(13)
                        'ElseIf dtEstadisticas.Rows(I).Item(16) = "5" Then
                        '    totalVencidoE = totalVencidoE + 1
                        '    totalPendienteVencido = totalPendienteVencido + dtEstadisticas.Rows(I).Item(12) - dtEstadisticas.Rows(I).Item(13)
                        'End If

                    Next i

                    lblPagadoAntes.Text = "Antes (" & totalAntesE & ")"
                    lblPagadoEnFecha.Text = "En Fecha (" & totalEnFechaE & ")"
                    lblPagadoDespues.Text = "Después (" & totalDespuesE & ")"
                    lblPendientesNoVencido.Text = "No Vencido (" & totalNoVencidoE & ")"
                    lblPendientesEnFecha.Text = "Vencido (" & totalVencidoE & ")"

                    txtPagadosAntes.Text = totalPagoAntes
                    txtPagadosEnFecha.Text = totalPagoEnFecha
                    txtPagadosDespués.Text = totalPagoDespues
                    txtPendientesNoVencido.Text = totalPendienteNoVencido
                    txtPendientesVencido.Text = totalPendienteVencido

                    txtTotalesSaldo.Text = totalPendienteNoVencido + totalPendienteVencido
                    txtTotalesPagado.Text = totalPagoAntes + totalPagoEnFecha + totalPagoDespues
                    txtTotalesVentas.Text = totalPagoAntes + totalPagoEnFecha + totalPagoDespues + totalPendienteNoVencido + totalPendienteVencido

                    txtCliente.Text = txtCodCli.Text & "  -  " & txtDesCli.Text

                    rbBloques.Checked = True

                    '------------- Codigo de Llenado para la Grafica MsCHART6.0

                    dtReporte = oReporteVentaService.TarjetaCliente(Session.sFecha.Year, txtCodCli.Text, 2).Tables(0)

                    If dtReporte.Rows.Count = 0 Then
                        ChartEstadistica.Visible = False
                    Else
                        ChartEstadistica.Visible = True
                        ChartEstadistica.chartType = MSChart20Lib.VtChChartType.VtChChartType2dBar
                        ChartEstadistica.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).Labels(1).Format = "0"

                        ChartEstadistica.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY2).Labels(1).Format = "0"

                        ChartEstadistica.RowCount = 13
                        ChartEstadistica.ColumnCount = 1
                        ChartEstadistica.Title.Text = "    VENTAS MENSUALES DESDE " & UCase(dtReporte.Rows(0).Item(2)) & " " & Session.sFecha.Year - 1 & " A " & UCase(dtReporte.Rows(0).Item(2)) & " " & Session.sFecha.Year & ""

                        lblEstadisticas.Text = "La Información pertenece al Historial Crediticio del Cliente desde " & UCase(dtReporte.Rows(0).Item(2)) & " del " & dtReporte.Rows(0).Item(0) & " hasta la fecha."

                        ChartEstadistica.Plot.SeriesCollection(1).LegendText = "VENTAS"

                        dgvGrafica.DataSource = dtReporte

                        For I = 0 To dgvGrafica.Rows.Count - 2

                            ChartEstadistica.Row = I + 1
                            ChartEstadistica.RowLabel = dgvGrafica.Rows(I).Cells("NombreMes").Value()

                            ChartEstadistica.Column = 1
                            ChartEstadistica.Data = dgvGrafica.Rows(I).Cells("Total").Value()
                        Next


                    End If

                    '------------- For para Obtener los Meses que No Compra

                    For I = 0 To dgvGrafica.Rows.Count - 2

                        If dgvGrafica.Rows(I).Cells("Total").Value = 0 Then

                            MesesNoCompra = MesesNoCompra + 1

                        End If
                    Next

                    txtMensualFact.Text = (txtTotalesVentas.Text) / ((dgvGrafica.Rows.Count - 1) - MesesNoCompra)

                    '------

                    'For I = 0 To 12

                    '    If dgvGrafica.Rows(I).Cells("Total").Value = 0 Then

                    '        ChartEstadistica.Row = I + 1
                    '        ChartEstadistica.RowLabel = dgvGrafica.Rows(I).Cells("NombreMes").Value()

                    '        ChartEstadistica.Column = 1
                    '        ChartEstadistica.Data = 0
                    '    Else
                    '        ChartEstadistica.Row = I + 1
                    '        ChartEstadistica.RowLabel = dgvGrafica.Rows(I).Cells("NombreMes").Value()

                    '        ChartEstadistica.Column = 1
                    '        ChartEstadistica.Data = dgvGrafica.Rows(I).Cells("Total").Value()

                    '    End If
                    'Next
                    '------------ Esta bien solo falta el dgvgrafica

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
                End Try
            Case 3
                '------ TabPage de Indicadores
                Try
                    Dim dtEstadisticasInd As New DataTable
                    Dim totalAntesEInd As Integer = 0
                    Dim totalEnFechaEInd As Integer = 0
                    Dim totalDespuesEInd As Integer = 0
                    Dim totalNoVencidoEInd As Integer = 0
                    Dim totalVencidoEInd As Integer = 0
                    Dim totalPagoAntesInd As Double = 0.0
                    Dim totalPagoEnFechaInd As Double = 0.0
                    Dim totalPagoDespuesInd As Double = 0.0
                    Dim totalPendienteNoVencidoInd As Double = 0.0
                    Dim totalPendienteVencidoInd As Double = 0.0

                    Dim I As Integer

                    dtEstadisticasInd = oReporteVentaService.TarjetaCliente(Session.sFecha.Year, txtCodCli.Text, 1).Tables(0)


                    For I = 0 To dtEstadisticasInd.Rows.Count - 1

                        If dtEstadisticasInd.Rows(I).Item(16) = "1" Then
                            totalAntesEInd = totalAntesEInd + 1
                            totalPagoAntesInd = totalPagoAntesInd + dtEstadisticasInd.Rows(I).Item(12)
                        ElseIf dtEstadisticasInd.Rows(I).Item(16) = "2" Then
                            totalEnFechaEInd = totalEnFechaEInd + 1
                            totalPagoEnFechaInd = totalPagoEnFechaInd + dtEstadisticasInd.Rows(I).Item(12)
                        ElseIf dtEstadisticasInd.Rows(I).Item(16) = "3" Then
                            totalDespuesEInd = totalDespuesEInd + 1
                            totalPagoDespuesInd = totalPagoDespuesInd + dtEstadisticasInd.Rows(I).Item(12)
                        ElseIf dtEstadisticasInd.Rows(I).Item(16) = "4" Then
                            totalNoVencidoEInd = totalNoVencidoEInd + 1
                            totalPendienteNoVencidoInd = totalPendienteNoVencidoInd + dtEstadisticasInd.Rows(I).Item(12) - dtEstadisticasInd.Rows(I).Item(13)
                        ElseIf dtEstadisticasInd.Rows(I).Item(16) = "5" Then
                            totalVencidoEInd = totalVencidoEInd + 1
                            totalPendienteVencidoInd = totalPendienteVencidoInd + dtEstadisticasInd.Rows(I).Item(12) - dtEstadisticasInd.Rows(I).Item(13)
                        End If

                    Next I

                    dtReporte = oReporteVentaService.TarjetaCliente(Session.sFecha.Year, txtCodCli.Text, 2).Tables(0)

                    dgvgrafica2.DataSource = dtReporte

                    txtVentasAcumuladas.Text = totalPagoAntesInd + totalPagoEnFechaInd + totalPagoDespuesInd + totalPendienteNoVencidoInd + totalPendienteVencidoInd

                    txtCuentasporCobrar.Text = totalPendienteNoVencidoInd + totalPendienteVencidoInd

                    txtClienteInd.Text = txtCodCli.Text & "  -  " & txtDesCli.Text

                    For I = 0 To 12
                        If dgvgrafica2.Rows(I).Cells("Total").Value = 0 Then
                            MesesNoCompraInd = MesesNoCompraInd + 1
                        End If
                    Next

                    txtDiasTranscurridos.Text = DateDiff(DateInterval.Day, CDate("01/01/" + utils.toBlank(Year(Today))), Today.Date) - (30 * MesesNoCompraInd)

                    txtIndicadorDVPC.Text = CInt((txtCuentasporCobrar.Text / txtVentasAcumuladas.Text) * CInt(txtDiasTranscurridos.Text))

                    txtPlazoAutorizado.Text = CInt(oCondicionPagoClienteService.ObtenerDiasCondicion(txtCodCli.Text))

                    txtPlazoenExceso.Text = txtIndicadorDVPC.Text - txtPlazoAutorizado.Text

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
                End Try

            Case 4
                '------ TabPage de Ocurrencias
                Dim dtOcurrencias As New DataTable
                Dim dtprueba As New DataTable

                dtprueba = oReporteVentaService.TarjetaCliente(Session.sFecha.Year, txtCodCli.Text, 2).Tables(0)

                dtOcurrencias = oOcurrenciaClienteService.MostrarPorCliente(txtCodCli.Text).Tables(0)

                If dtOcurrencias.Rows.Count = 0 Then
                    dgvOcurrencias.DataSource = Nothing
                    txtOcurrenciaDetalle.Text = ""
                Else
                    dgvOcurrencias.DataSource = dtOcurrencias
                End If

        End Select
    End Sub


    Private Sub dgvVentas_FormattingRow(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles dgvVentas.FormattingRow

        Dim rowCol As New Janus.Windows.GridEX.GridEXFormatStyle
        Dim rowCol1 As New Janus.Windows.GridEX.GridEXFormatStyle
        Dim rowCol2 As New Janus.Windows.GridEX.GridEXFormatStyle
        Dim rowCol3 As New Janus.Windows.GridEX.GridEXFormatStyle
        Dim rowCol4 As New Janus.Windows.GridEX.GridEXFormatStyle

        rowCol.BackColor = Color.Green
        rowCol1.BackColor = Color.GreenYellow
        rowCol2.BackColor = Color.Yellow
        rowCol3.BackColor = Color.Orange
        rowCol4.BackColor = Color.Red

        If e.Row.Cells(16).Value = "1" Then
            e.Row.RowStyle = rowCol
            e.Row.RowStyle.ForeColor = Color.WhiteSmoke
        ElseIf e.Row.Cells(16).Value = "2" Then
            e.Row.RowStyle = rowCol1
        ElseIf e.Row.Cells(16).Value = "3" Then
            e.Row.RowStyle = rowCol2
        ElseIf e.Row.Cells(16).Value = "4" Then
            e.Row.RowStyle = rowCol3
        ElseIf e.Row.Cells(16).Value = "5" Then
            e.Row.RowStyle = rowCol4
            e.Row.RowStyle.ForeColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            IdCliente = frm.codigo
            txtCodCli.Text = frm.codigo
            MostrarCliente()
        End If
    End Sub

    Private Sub MostrarCliente()
        Dim oClienteService As New ClienteService.ClienteServiceClient
        Dim cliente As New ClienteService.Cliente
        Dim dtContactos As New DataTable
        cliente = oClienteService.MostrarPorID(txtCodCli.Text)
        txtDesCli.Text = cliente.DesCli
        txtRuc.Text = cliente.RucCli
        txtDNI.Text = cliente.DniCli
        ' txtDir.Text = cliente.DirCli
        txtTelf.Text = cliente.TelCli
        txtFax.Text = cliente.FaxCli
        txtCodEco.Text = cliente.SectorCliente.CodSec
        txtDesEco.Text = cliente.SectorCliente.DesSec
        txtObservaciones.Text = cliente.ObsCli
        txtCodCli.Select()
        ActivarTabs()

        dtContactos = oContactoService.Mostrar(utils.toNumber(txtCodCli.Text)).Tables(0)
        dgvContactos.DataSource = dtContactos

    End Sub

    Private Sub ActivarTabs()
        tbVentas.Enabled = True
        tbEstadisticas.Enabled = True
        tbIndicadores.Enabled = True
        tbOcurrencias.Enabled = True
    End Sub


    Private Sub txtCodCli_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCli.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    MostrarCliente()
        'End If
    End Sub

    Private Sub btnOcurSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOcurSalir.Click
        TbOpciones.SelectedIndex = "0"
    End Sub

    Private Sub btnSalirEst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirEst.Click
        TbOpciones.SelectedIndex = "0"
    End Sub

    Private Sub btnSalirVen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirVen.Click
        TbOpciones.SelectedIndex = "0"
    End Sub

    Private Sub btnSalirCli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirCli.Click
        Me.Close()
    End Sub

    Private Sub dgvOcurrencias_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvOcurrencias.SelectionChanged

        Dim IdOcurrencia As String

        If dgvOcurrencias.RowCount <> 0 Then
            IdOcurrencia = dgvOcurrencias.CurrentRow.Cells("IdOcurrencia").Value
            ObtenerOcurrencia()
        End If
    End Sub

    Private Sub ObtenerOcurrencia()
        txtOcurrenciaDetalle.Text = dgvOcurrencias.CurrentRow.Cells("Observacion").Value
    End Sub

    Private Sub rbLineas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbLineas.CheckedChanged
        Try
            dtReporte = oReporteVentaService.TarjetaCliente(Session.sFecha.Year, txtCodCli.Text, 2).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                ChartEstadistica.Visible = False
            Else
                ChartEstadistica.Visible = True
                ChartEstadistica.chartType = MSChart20Lib.VtChChartType.VtChChartType2dLine
                ChartEstadistica.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).Labels(1).Format = "0"
                ChartEstadistica.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY2).Labels(1).Format = "0"

                ChartEstadistica.RowCount = 13
                ChartEstadistica.ColumnCount = 1
                ChartEstadistica.Title.Text = "    VENTAS MENSUALES DESDE " & UCase(dtReporte.Rows(0).Item(2)) & " " & Session.sFecha.Year - 1 & " A " & UCase(dtReporte.Rows(0).Item(2)) & " " & Session.sFecha.Year & ""

                ChartEstadistica.Plot.SeriesCollection(1).LegendText = "VENTAS"

                dgvGrafica.DataSource = dtReporte

                For I = 0 To dgvGrafica.Rows.Count - 2

                    ChartEstadistica.Row = I + 1
                    ChartEstadistica.RowLabel = dgvGrafica.Rows(I).Cells("NombreMes").Value()

                    ChartEstadistica.Column = 1
                    ChartEstadistica.Data = 0
                Next

                For I = 0 To dgvGrafica.Rows.Count - 2

                    ChartEstadistica.Row = I + 1
                    ChartEstadistica.RowLabel = dgvGrafica.Rows(I).Cells("NombreMes").Value()

                    ChartEstadistica.Column = 1
                    ChartEstadistica.Data = dgvGrafica.Rows(I).Cells("Total").Value()
                Next

            End If

            For I = 0 To dgvGrafica.Rows.Count - 2

                If dgvGrafica.Rows(I).Cells("Total").Value = 0 Then
                    MesesNoCompra = MesesNoCompra + 1
                End If
            Next

            txtMensualFact.Text = (txtTotalesVentas.Text) / ((dgvGrafica.Rows.Count - 1) - MesesNoCompra)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try

    End Sub

    Private Sub rbBloques_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBloques.CheckedChanged
        Try
            dtReporte = oReporteVentaService.TarjetaCliente(Session.sFecha.Year, txtCodCli.Text, 2).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                ChartEstadistica.Visible = False
            Else
                ChartEstadistica.Visible = True
                ChartEstadistica.chartType = MSChart20Lib.VtChChartType.VtChChartType2dBar
                ChartEstadistica.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).Labels(1).Format = "0"
                ChartEstadistica.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY2).Labels(1).Format = "0"

                ChartEstadistica.RowCount = 13
                ChartEstadistica.ColumnCount = 1
                ChartEstadistica.Title.Text = "    VENTAS MENSUALES DESDE " & UCase(dtReporte.Rows(0).Item(2)) & " " & Session.sFecha.Year - 1 & " A " & UCase(dtReporte.Rows(0).Item(2)) & " " & Session.sFecha.Year & ""

                ChartEstadistica.Plot.SeriesCollection(1).LegendText = "VENTAS"

                dgvGrafica.DataSource = dtReporte

                For I = 0 To dgvGrafica.Rows.Count - 2

                    ChartEstadistica.Row = I + 1
                    ChartEstadistica.RowLabel = dgvGrafica.Rows(I).Cells("NombreMes").Value()

                    ChartEstadistica.Column = 1
                    ChartEstadistica.Data = 0
                Next

                For I = 0 To dgvGrafica.Rows.Count - 2

                    ChartEstadistica.Row = I + 1
                    ChartEstadistica.RowLabel = dgvGrafica.Rows(I).Cells("NombreMes").Value()

                    ChartEstadistica.Column = 1
                    ChartEstadistica.Data = dgvGrafica.Rows(I).Cells("Total").Value()
                Next

            End If

            For I = 0 To dgvGrafica.Rows.Count - 2

                If dgvGrafica.Rows(I).Cells("Total").Value = 0 Then
                    MesesNoCompra = MesesNoCompra + 1
                End If
            Next

            txtMensualFact.Text = (txtTotalesVentas.Text) / ((dgvGrafica.Rows.Count - 1) - MesesNoCompra)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try
    End Sub

    Private Sub rbCircular_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCircular.CheckedChanged
        Try
            dtReporte = oReporteVentaService.TarjetaCliente(Session.sFecha.Year, txtCodCli.Text, 2).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                ChartEstadistica.Visible = False
            Else
                ChartEstadistica.Visible = True
                ChartEstadistica.chartType = MSChart20Lib.VtChChartType.VtChChartType2dArea
                ChartEstadistica.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).Labels(1).Format = "0"
                ChartEstadistica.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY2).Labels(1).Format = "0"

                ChartEstadistica.RowCount = 13
                ChartEstadistica.ColumnCount = 1
                ChartEstadistica.Title.Text = "    VENTAS MENSUALES DESDE " & UCase(dtReporte.Rows(0).Item(2)) & " " & Session.sFecha.Year - 1 & " A " & UCase(dtReporte.Rows(0).Item(2)) & " " & Session.sFecha.Year & ""

                ChartEstadistica.Plot.SeriesCollection(1).LegendText = "VENTAS"

                dgvGrafica.DataSource = dtReporte

                For I = 0 To dgvGrafica.Rows.Count - 2

                    ChartEstadistica.Row = I + 1
                    ChartEstadistica.RowLabel = dgvGrafica.Rows(I).Cells("NombreMes").Value()

                    ChartEstadistica.Column = 1
                    ChartEstadistica.Data = 0
                Next

                For I = 0 To dgvGrafica.Rows.Count - 2

                    ChartEstadistica.Row = I + 1
                    ChartEstadistica.RowLabel = dgvGrafica.Rows(I).Cells("NombreMes").Value()

                    ChartEstadistica.Column = 1
                    ChartEstadistica.Data = dgvGrafica.Rows(I).Cells("Total").Value()
                Next

            End If

            For I = 0 To dgvGrafica.Rows.Count - 2

                If dgvGrafica.Rows(I).Cells("Total").Value = 0 Then
                    MesesNoCompra = MesesNoCompra + 1
                End If
            Next

            txtMensualFact.Text = (txtTotalesVentas.Text) / ((dgvGrafica.Rows.Count - 1) - MesesNoCompra)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try
    End Sub

    Private Sub btnSalirInd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirInd.Click
        TbOpciones.SelectedIndex = "0"
    End Sub

    Private Sub txtPlazoAutorizado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPlazoAutorizado.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPlazoenExceso.Text = txtIndicadorDVPC.Text - txtPlazoAutorizado.Text
        End If
    End Sub

    Private Sub txtCodCli_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodCli.TextChanged

    End Sub

    Private Sub txtPlazoAutorizado_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPlazoAutorizado.TextChanged
        txtPlazoenExceso.Text = txtIndicadorDVPC.Text - txtPlazoAutorizado.Text
    End Sub

    Private Sub lblTotalesSaldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTotalesSaldo.Click

    End Sub
End Class