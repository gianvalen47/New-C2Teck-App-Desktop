Imports System.ServiceModel

Public Class frmInventarios
    'Private oMaestroService As New MaestroService.MaestroClient
    Private oLocacionService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private objMaestro As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtReporte As DataTable
    Private dtReporteMotor As DataTable
    Private dtReporteBaterias As DataTable
    Private dtReporteFiltros As DataTable
    Private dtReporteRepuestos As DataView
    Private dtReporteSinMovimiento As DataTable
    Private dtReporteResumen As DataTable
    Private CodCic As String
    Dim forma As New frmReportes
    Dim reporte As New rptGerenciaInventariosCostos
    Dim reporteMotores As New rptGerenciaMotoresStock
    Dim reporteMotoresBaterias As New rptGerenciaMotoresStockBaterias
    Dim reporteSinMovimiento As New rptGerenciaSinMovimiento
    Dim reporteResumen As New rptGerenciaResumen
    Dim MarcaAgua As String = ""

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             chkMotoresStock.KeyPress, chkStockValorizado01.KeyPress, chkStockValorizado02.KeyPress, btnAceptar.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oLocacionService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(10)
        oSeguridadService.RegistrarVisitaOpciones(90, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        If chkStockValorizado01.Checked = True Then
            dtReporte = oLocacionService.ReporteGerencialValorizado(Session.sCodEmp).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Me.Close()
            Else
                'Dim DiasTrans As Integer
                'Dim I1 As Double
                'Dim CV As Double
                'DiasTrans = DateDiff(DateInterval.Day, CDate("01/01/" + utils.toBlank(Year(Today))), Today.Date)
                'I1 = oLocacionService.ObtenerSaldoInicio(Session.sCodEmp, CDate("01/01/" + utils.toBlank(Year(Today))))
                'CV = oLocacionService.ObtenerCostoVenta(Session.sCodEmp, Today.Date, "NS")

                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.DisplayGroupTree = False
                'forma.crvReportes.RefreshReport = False
                'reporte.SetParameterValue("Rt", Rt)
                'reporte.SetParameterValue("D", DiasTrans)
                'reporte.SetParameterValue("CV", CV)
                'reporte.SetParameterValue("I1", I1)
                reporte.SetParameterValue("MarcaAgua", MarcaAgua)
                reporte.SetParameterValue("TipCam", objMaestro.MostrarTipoCambio("US", Today.Date))
                forma.Text = "Reporte de Gerencia Inventarios y Costos"
                forma.ShowDialog()
            End If
        End If
        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '================================Agregado el 25/02/2012 ================================
        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        If chkStockValorizado02.Checked = True Then
            Dim reporte As New rptGerenciaInventariosCostos02
            Dim dtReporte As New DataTable
            Dim dtSubreporte As DataTable

            dtSubreporte = oLocacionService.ReporteGerencialInventarios(Session.sCodEmp, "", Today, Today, 0, 4).Tables(0)

            dtReporte = oLocacionService.ReporteGerencialInventarios(Session.sCodEmp, "", Today, Today, 0, 4).Tables(0)
            dgvGerencial.DataSource = dtReporte

            '//Hallamos el Costo de Dolares Total del Reporte para calcular el porcentaje en el cuadro resumido del reporte//
            Dim TotalDolares As Double = 0
            Dim TotalSoles As Double = 0
            If dgvGerencial.RowCount <> 0 Then
                For i As Integer = 0 To dgvGerencial.RowCount - 1
                    If Not (IsDBNull(dgvGerencial.Item("CostoDolares".ToLower, i).Value)) Then
                        TotalDolares = TotalDolares + CDbl(dgvGerencial.Item("CostoDolares".ToLower, i).Value)
                        TotalSoles = TotalSoles + CDbl(dgvGerencial.Item("CostoSoles".ToLower, i).Value)
                    End If
                Next
            End If
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            If reporte.Subreports.Count > 0 Then
                reporte.Subreports(0).SetDataSource(dtSubreporte)
            End If

            Dim DiasTrans As Integer
            Dim I1 As Double
            Dim CV As Double
            DiasTrans = DateDiff(DateInterval.Day, CDate("01/01/" + utils.toBlank(Year(Today))), Today.Date)
            I1 = oLocacionService.ObtenerSaldoInicio(Session.sCodEmp, CDate("01/01/" + utils.toBlank(Year(Today))))
            CV = oLocacionService.ObtenerCostoVenta(Session.sCodEmp, Today.Date, "NS")

            reporte.SetDataSource(dtReporte)
            reporte.SetParameterValue("pTotalDolares", TotalDolares)
            reporte.SetParameterValue("D", DiasTrans)
            reporte.SetParameterValue("CV", CV)
            reporte.SetParameterValue("I1", I1)
            reporte.SetParameterValue("TipCam", objMaestro.MostrarTipoCambio("US", Today.Date))
            forma.crvReportes.ReportSource = reporte
            ' Validar Usuario - Exportar Excel
            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                forma.crvReportes.ShowExportButton = True
            Else
                forma.crvReportes.ShowExportButton = False
            End If
            'forma.crvReportes.DisplayGroupTree = False            
            forma.Text = "Reporte de Gerencia Stock Valorizado"
            forma.ShowDialog()
        End If
        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '=================================================================================
        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        If chkMotoresStock.Checked = True Then
            dtReporteMotor = oLocacionService.ReporteGerencialStockMotores(Session.sCodEmp).Tables(0)
            If dtReporteMotor.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Me.Close()
            Else
                reporteMotores.SetDataSource(dtReporteMotor)
                forma.crvReportes.ReportSource = reporteMotores
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.DisplayGroupTree = False
                reporteMotores.SetParameterValue("Almacen", "EQUIPOS")
                forma.Text = "Reporte de Gerencia Motores en Stock"
                forma.ShowDialog()
            End If
        End If

        If chkBateriasStock.Checked = True Then
            dtReporteBaterias = oLocacionService.ReporteGerencialStockBaterias(Session.sCodEmp).Tables(0)
            If dtReporteBaterias.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Me.Close()
            Else
                reporteMotoresBaterias.SetDataSource(dtReporteBaterias)
                forma.crvReportes.ReportSource = reporteMotoresBaterias
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.DisplayGroupTree = False
                reporteMotoresBaterias.SetParameterValue("Almacen", "BATERIAS")
                forma.Text = "Reporte de Gerencia Baterias en Stock"
                forma.ShowDialog()
            End If
        End If
        If chkFiltrosStock.Checked = True Then
            dtReporteFiltros = oLocacionService.ReporteGerencialStockFiltros(Session.sCodEmp).Tables(0)
            If dtReporteFiltros.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Me.Close()
            Else
                reporteMotores.SetDataSource(dtReporteFiltros)
                forma.crvReportes.ReportSource = reporteMotores
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.DisplayGroupTree = False
                reporteMotores.SetParameterValue("Almacen", "FILTROS")
                forma.Text = "Reporte de Gerencia Filtros en Stock"
                forma.ShowDialog()
            End If
        End If
        If chkResumen.Checked = True Then
            dtReporteMotor = oLocacionService.ReporteGerencialStockMotores(Session.sCodEmp).Tables(0)
            dtReporteBaterias = oLocacionService.ReporteGerencialStockBaterias(Session.sCodEmp).Tables(0)
            dtReporteFiltros = oLocacionService.ReporteGerencialStockFiltros(Session.sCodEmp).Tables(0)

            'reporteResumen.Subreports(0).SetDataSource(dtReporteMotor)
            'reporteResumen.Subreports(1).SetDataSource(dtReporteBaterias)
            'reporteResumen.Subreports(2).SetDataSource(dtReporteFiltros)

            reporteResumen.Subreports(0).SetDataSource(dtReporteBaterias)
            reporteResumen.Subreports(1).SetDataSource(dtReporteFiltros)
            'reporteResumen.Subreports(2).SetDataSource(dtReporteFiltros)

            If dtReporteMotor.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Me.Close()
            Else
                reporteResumen.SetDataSource(dtReporteMotor)
                forma.crvReportes.ReportSource = reporteResumen
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.DisplayGroupTree = False
                reporteResumen.SetParameterValue("Almacen", "MOTORES - BATERIAS - FILTROS ")
                forma.Text = "Reporte de Gerencia Filtros en Stock"
                forma.ShowDialog()
            End If
        End If
        If chkRepuestosStock.Checked = True Then
            dtReporteRepuestos = oLocacionService.ReporteGerencialStockRepuestos(Session.sCodEmp, CodCic).Tables(0).DefaultView
            If rb2C.Checked = True Then
                dtReporteRepuestos.RowFilter = "CodCic = '2C'"
            ElseIf rb4C.Checked = True Then
                dtReporteRepuestos.RowFilter = "CodCic = '4C'"
            End If
            If dtReporteRepuestos.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Me.Close()
            Else
                reporteMotores.SetDataSource(dtReporteRepuestos)
                forma.crvReportes.ReportSource = reporteMotores
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.DisplayGroupTree = False
                reporteMotores.SetParameterValue("Almacen", "REPUESTOS")
                forma.Text = "Reporte de Gerencia Repuestos en Stock"
                forma.ShowDialog()
            End If
        End If

        If chkInventarioSinMovimiento.Checked = True Then

            dtReporteSinMovimiento = oLocacionService.ReporteGerencialInventarios(Session.sCodEmp, "", cbFecInicio.Value, cbFecFinal.Value, 0, 1).Tables(0)
            If dtReporteSinMovimiento.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Me.Close()
            Else
                reporteSinMovimiento.SetDataSource(dtReporteSinMovimiento)
                forma.crvReportes.ReportSource = reporteSinMovimiento
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.DisplayGroupTree = False
                reporteSinMovimiento.SetParameterValue("Fecha1", cbFecInicio.Value)
                reporteSinMovimiento.SetParameterValue("Fecha2", cbFecFinal.Value)
                forma.Text = "Reporte de Gerencia Stock Sin Movimiento"
                'DataGridView1.DataSource = dtReporteSinMovimiento
                forma.ShowDialog()
            End If
        End If

    End Sub

    Private Sub frmInventarios_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oLocacionService.Close()
            objMaestro.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oLocacionService.Abort()
            objMaestro.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oLocacionService.Abort()
            objMaestro.Abort()
            oSeguridadService.Abort()
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmInventarios_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmInventarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 90)
        '/*************************************************************************************/

        cbFecInicio.Value = "01/01/" & Today.Year
        cbFecFinal.Value = Today
        cbMarcaAgua.Visible = False
    End Sub

    Private Sub chkMotoresStock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMotoresStock.CheckedChanged, chkBateriasStock.CheckedChanged, chkFiltrosStock.CheckedChanged, chkRepuestosStock.CheckedChanged, chkStockValorizado01.CheckedChanged, chkInventarioSinMovimiento.CheckedChanged
        If chkMotoresStock.Checked = True Then
            gbCiclos.Enabled = False
            gbSinMovimiento.Enabled = False
            cbMarcaAgua.Visible = False
        ElseIf chkBateriasStock.Checked = True Then
            gbCiclos.Enabled = False
            gbSinMovimiento.Enabled = False
            cbMarcaAgua.Visible = False
        ElseIf chkFiltrosStock.Checked = True Then
            gbCiclos.Enabled = False
            gbSinMovimiento.Enabled = False
            cbMarcaAgua.Visible = False
        ElseIf chkRepuestosStock.Checked = True Then
            gbCiclos.Enabled = True
            gbSinMovimiento.Enabled = False
            If rbNinguno.Checked = True Then
                CodCic = "N"
            Else
                CodCic = ""
            End If
            cbMarcaAgua.Visible = False
        ElseIf chkStockValorizado01.Checked = True Then
            gbCiclos.Enabled = False
            gbSinMovimiento.Enabled = False
            cbMarcaAgua.Visible = True
        ElseIf chkStockValorizado02.Checked = True Then
            gbCiclos.Enabled = False
            gbSinMovimiento.Enabled = False
            cbMarcaAgua.Visible = False
        ElseIf chkInventarioSinMovimiento.Checked = True Then
            gbCiclos.Enabled = False
            gbSinMovimiento.Enabled = True
            cbMarcaAgua.Visible = False
        End If
    End Sub

    Private Sub rbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTodos.CheckedChanged, rb2C.CheckedChanged, rb4C.CheckedChanged, rbNinguno.CheckedChanged
        If rbTodos.Checked = True Then
            CodCic = ""
        ElseIf rb2C.Checked = True Then
            CodCic = ""
        ElseIf rb4C.Checked = True Then
            CodCic = ""
        ElseIf rbNinguno.Checked = True Then
            CodCic = "N"
        End If
    End Sub

    Private Sub btnConsolidado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsolidado.Click
        Dim Reporte1 As New frmConsolidadoReportes

        If chkStockValorizado01.Checked = True Then
            dtReporte = oLocacionService.ReporteGerencialValorizado(Session.sCodEmp).Tables(0)

            If dtReporte.Rows.Count > 0 Then
                'Reporte1.FechaInicio15 = cbFecInicio.Value
                'Reporte1.FechaFinal15 = cbFecFinal.Value
                Reporte1.Tipo15 = True
            Else
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                'Reporte1.FechaInicio15 = "01/01/2012"
                'Reporte1.FechaFinal15 = "01/09/2012"
                Reporte1.Tipo15 = False
            End If
        End If
    End Sub

    Private Sub cbMarcaAgua_CheckedChanged(sender As Object, e As EventArgs) Handles cbMarcaAgua.CheckedChanged
        If cbMarcaAgua.Checked Then
            Dim frm As New frmMarcaAgua
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                MarcaAgua = frm.txtMarcaAgua.Text
            Else
                cbMarcaAgua.Checked = False
            End If
        Else
            MarcaAgua = ""
        End If
    End Sub

    Private Sub frmRepGerInventarios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
    chkMotoresStock.KeyPress _
    , chkBateriasStock.KeyPress, chkFiltrosStock.KeyPress, chkRepuestosStock.KeyPress, chkResumen.KeyPress, chkStockValorizado01.KeyPress, chkStockValorizado02.KeyPress, chkInventarioSinMovimiento.KeyPress, cbFecInicio.KeyPress, cbFecFinal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class