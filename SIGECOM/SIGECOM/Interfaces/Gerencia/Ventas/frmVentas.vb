Imports System.ServiceModel

Public Class frmVentas
    Private oVentaService As New ReporteVentaService.ReporteVentaServiceClient
    Private oDocumentoCostoService As New DocumentoCostoService.DocumentoCostoServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Dim dtReporte As New DataTable
    Dim reporteVenta As New rptGerencialRegVentas
    Dim reporteGarantia As New rptGerencialResumGarantias
    Dim reporteAdelantos As New rptGerencialAdelantos
    Dim reporteServiciosSinIGV As New rptGerencialServicioSinIGV
    Dim reporteConsolVentas As New rptGerencialConsolVentas
    Dim reporteMotoresVenta As New rptMotoresVenta
    Dim reporteJobs As New rptGerencialJobsVenta
    Dim reporteJobsFacturados As New rptGerenciaJobFacturados
    Dim reporteVentaPresupuesto As New rptGerenciaVentaPresupuesto
    Dim reporteGuiasPendientes As New rptGerenciaVentaGuias
    Dim reportePresupuestoAnual As New rptGerencialPresupuestoAnual
    Dim forma As New frmReportes
    Dim row As DataRow
    Dim MarcaAgua As String = ""
    Private dtMoment As DataTable
    Private dtMonedas As DataTable

    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oVentaService.Close()
            oDocumentoCostoService.Close()
            oJobService.Close()
            oSeguridadService.close()
        Catch ex As TimeoutException
            oVentaService.Abort()
            oDocumentoCostoService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oVentaService.Abort()
            oDocumentoCostoService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmVentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 88)
        '/*************************************************************************************/

        Dim Mes, Anio, meses As Integer
        Dim Fecha As Date

        LlenarComboMoneda()
        cmbMoneda.Value = "US"
        rbMoneda.Checked = False
        rbMoneda.Enabled = False
        cmbMoneda.Enabled = False

        Fecha = Today
        meses = Month(Today) 'IIf(Month(Fecha) = 1, 12, Month(Fecha))
        If meses = 1 Then
            Mes = Month(Today)
            Anio = Year(Today)
        Else
            Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
            Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        End If

        cbMarcaAgua.Visible = False
        cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        cbFecFinal.Value = Fecha
        cbFecInicio.Select()
    End Sub

    Private Sub LlenarComboMoneda()

        Try
            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub MostrarReporte()
        Try
            oSeguridadService.RegistrarVisitaOpciones(88, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If rbtGerenConsolidado.Checked = True Then
                dtReporte = oVentaService.ReporteGerVenta(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 0, 1).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")

                Else
                    reporteVenta.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteVenta
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False
                    reporteVenta.SetParameterValue("FechaInicio", cbFecInicio.Value)
                    reporteVenta.SetParameterValue("FechaFin", cbFecFinal.Value)
                    forma.Text = "Reporte de Gerencial Reg. Venta"
                    forma.ShowDialog()
                End If
            ElseIf rbtnGerenGarantias.Checked = True Then
                dtReporte = oVentaService.ReporteGerVenta(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 0, 2).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")

                Else
                    reporteGarantia.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteGarantia
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False
                    reporteGarantia.SetParameterValue("FechaInicio", cbFecInicio.Value)
                    reporteGarantia.SetParameterValue("FechaFin", cbFecFinal.Value)
                    forma.Text = "Reporte de Gerencial Resumen Garantías"
                    forma.ShowDialog()
                End If
            ElseIf rbtAdelantos.Checked = True Then
                dtReporte = oVentaService.ReporteGerVenta(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 0, 3).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")

                Else
                    reporteAdelantos.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteAdelantos
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False
                    reporteAdelantos.SetParameterValue("FechaInicio", cbFecInicio.Value)
                    reporteAdelantos.SetParameterValue("FechaFin", cbFecFinal.Value)
                    forma.Text = "Reporte de Gerencial Adelantos"
                    forma.ShowDialog()
                End If
            ElseIf rbtnServicioSinIGV.Checked = True Then
                dtReporte = oVentaService.ReporteGerVenta(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 0, 4).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")

                Else
                    reporteServiciosSinIGV.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteServiciosSinIGV
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False
                    reporteServiciosSinIGV.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporteServiciosSinIGV.SetParameterValue("FecFin", cbFecFinal.Value)
                    forma.Text = "Reporte  Gerencial Servicios sin IGV"
                    forma.ShowDialog()
                End If
            ElseIf rbtnConsoVentas.Checked = True Then
                dtReporte = oVentaService.ReporteGerVenta(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 0, 5).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique. !!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporteConsolVentas.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteConsolVentas
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.DisplayGroupTree = False
                    reporteConsolVentas.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporteConsolVentas.SetParameterValue("FecFin", cbFecFinal.Value)
                    forma.Text = "Reporte Gerencial de Consolidado de Ventas"
                    forma.ShowDialog()
                End If
            ElseIf rbtnVentasCliente.Checked = True Then
                Dim frm As New frmGClientes
                frm.fechaInicio = cbFecInicio.Value
                frm.fechaFin = cbFecFinal.Value
                frm.TipoReporte = "VentaCliente"
                frm.ShowDialog()
            ElseIf rbtnMotoresVenta.Checked = True Then
                dtReporte = oDocumentoCostoService.ReporteMotoresVendidos(0, cbFecInicio.Text, cbFecFinal.Text).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")

                Else
                    reporteMotoresVenta.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteMotoresVenta
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False
                    reporteMotoresVenta.SetParameterValue("cbFecInicio", cbFecInicio.Value)
                    reporteMotoresVenta.SetParameterValue("cbFecFinal", cbFecFinal.Value)
                    reporteMotoresVenta.SetParameterValue("Titulo", "MOTORES")
                    forma.Text = "Reporte  Gerencial de Motores Vendidos"
                    forma.ShowDialog()

                End If

            ElseIf rbtnConsJobs.Checked = True Then
                dtReporte = oVentaService.ReporteGerVenta(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 0, 7).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")

                Else
                    reporteJobs.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteJobs
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.DisplayGroupTree = False
                    reporteJobs.SetParameterValue("cbFecInicio", cbFecInicio.Value)
                    reporteJobs.SetParameterValue("cbFecFin", cbFecFinal.Value)
                    forma.Text = "Reporte  Gerencial de OTs de Venta"
                    forma.ShowDialog()
                End If
            ElseIf rbtnJobFac.Checked = True Then

                Dim frm As New frmGClientes
                frm.fechaInicio = cbFecInicio.Value
                frm.fechaFin = cbFecFinal.Value
                frm.Moneda = cmbMoneda.Value
                frm.TipoReporte = "JobFac"
                frm.ShowDialog()

                'dtReporte = oJobService.ReporteGerencialServicios(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 1).Tables(0)
                'If dtReporte.Rows.Count = 0 Then
                '    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")

                'Else
                '    reporteJobsFacturados.SetDataSource(dtReporte)
                '    forma.crvReportes.ReportSource = reporteJobsFacturados
                '    forma.crvReportes.DisplayGroupTree = False
                '    reporteJobsFacturados.SetParameterValue("cbFecInicio", cbFecInicio.Value)
                '    reporteJobsFacturados.SetParameterValue("cbFecFinal", cbFecFinal.Value)
                '    forma.Text = "Reporte  Gerencial de Jobs Facturados"
                '    forma.ShowDialog()
                'End If


            ElseIf rbtnPresupuesto.Checked = True Then
                dtReporte = oVentaService.ReporteGerVenta(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 0, 8).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")

                Else

                    reporteVentaPresupuesto.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteVentaPresupuesto
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.DisplayGroupTree = False
                    ' reporteJobsFacturados.SetParameterValue("cbFecInicio", cbFecInicio.Value)
                    ' reporteJobsFacturados.SetParameterValue("cbFecFinal", cbFecFinal.Value)
                    reporteVentaPresupuesto.SetParameterValue("MarcaAgua", MarcaAgua)
                    forma.Text = "Reporte  Gerencial de Ventas vs Presupuesto"
                    forma.ShowDialog()
                End If


            ElseIf rbtnGuiasPendientes.Checked Then
                dtReporte = oVentaService.VentaGuias(Session.sCodEmp, 0, cbFecInicio.Value, cbFecFinal.Value, 0, "", 0, 1, 1).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")

                Else
                    reporteGuiasPendientes.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteGuiasPendientes
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte de Guias de Ventas / Guias sin Facturar"
                    reporteGuiasPendientes.SetParameterValue("Motivo", "(Todos)")
                    reporteGuiasPendientes.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporteGuiasPendientes.SetParameterValue("FecFinal", cbFecFinal.Value)
                    reporteGuiasPendientes.SetParameterValue("Vendedor", "(Todos)")
                    reporteGuiasPendientes.SetParameterValue("Reporte", "Reporte de Guías Pendientes de Facturación")

                    ' reporteJobsFacturados.SetParameterValue("cbFecInicio", cbFecInicio.Value)
                    ' reporteJobsFacturados.SetParameterValue("cbFecFinal", cbFecFinal.Value)
                    forma.ShowDialog()
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        MostrarReporte()
        'dtMoment = oVentaService.ReporteGerVenta(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 0, 4).Tables(0)
        'DataGridView1.DataSource = dtMoment
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub frmVentas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub btnConsolidado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsolidado.Click
        Dim Reporte1 As New frmConsolidadoReportes

        If rbtGerenConsolidado.Checked = True Then
            dtReporte = oVentaService.ReporteGerVenta(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 0, 1).Tables(0)

            If dtReporte.Rows.Count > 0 Then
                Reporte1.FechaInicio1 = cbFecInicio.Value
                Reporte1.FechaFinal1 = cbFecFinal.Value
                Reporte1.Tipo1 = True

            Else
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Reporte1.FechaInicio1 = "01/01/2012"
                Reporte1.FechaFinal1 = "01/09/2012"
                Reporte1.Tipo1 = False
            End If
        End If
    End Sub

    Private Sub btnConsolidado1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsolidado1.Click
        Dim Reporte1 As New frmConsolidadoReportes

        If rbtnGerenGarantias.Checked = True Then
            dtReporte = oVentaService.ReporteGerVenta(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 0, 2).Tables(0)

            If dtReporte.Rows.Count > 0 Then
                Reporte1.FechaInicio2 = cbFecInicio.Value
                Reporte1.FechaFinal2 = cbFecFinal.Value
                Reporte1.Tipo2 = True
            Else
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Reporte1.FechaInicio2 = "01/01/2012"
                Reporte1.FechaFinal2 = "01/09/2012"
                Reporte1.Tipo2 = False
            End If
        End If
    End Sub

    Private Sub btnConsolidado2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsolidado2.Click
        Dim Reporte1 As New frmConsolidadoReportes
        If rbtAdelantos.Checked = True Then
            dtReporte = oVentaService.ReporteGerVenta(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 0, 3).Tables(0)

            If dtReporte.Rows.Count > 0 Then
                Reporte1.FechaInicio3 = cbFecInicio.Value
                Reporte1.FechaFinal3 = cbFecFinal.Value
                Reporte1.Tipo3 = True
            Else
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Reporte1.FechaInicio3 = "01/01/2012"
                Reporte1.FechaFinal3 = "01/09/2012"
                Reporte1.Tipo3 = False
            End If
        End If
    End Sub

    Private Sub btnConsolidado3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsolidado3.Click
        Dim Reporte1 As New frmConsolidadoReportes
        If rbtnServicioSinIGV.Checked = True Then
            dtReporte = oVentaService.ReporteGerVenta(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 0, 4).Tables(0)

            If dtReporte.Rows.Count > 0 Then
                Reporte1.FechaInicio4 = cbFecInicio.Value
                Reporte1.FechaFinal4 = cbFecFinal.Value
                Reporte1.Tipo4 = True
            Else
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Reporte1.FechaInicio4 = "01/01/2012"
                Reporte1.FechaFinal4 = "01/09/2012"
                Reporte1.Tipo4 = False
            End If
        End If
    End Sub

    Private Sub btnConsolidado4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsolidado4.Click
        Dim Reporte1 As New frmConsolidadoReportes
        If rbtnConsoVentas.Checked = True Then
            dtReporte = oVentaService.ReporteGerVenta(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 0, 5).Tables(0)

            If dtReporte.Rows.Count > 0 Then
                Reporte1.FechaInicio5 = cbFecInicio.Value
                Reporte1.FechaFinal5 = cbFecFinal.Value
                Reporte1.Tipo5 = True
            Else
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Reporte1.FechaInicio5 = "01/01/2012"
                Reporte1.FechaFinal5 = "01/09/2012"
                Reporte1.Tipo5 = False
            End If
        End If
    End Sub

    Private Sub btnConsolidado5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsolidado5.Click
        Dim Reporte1 As New frmConsolidadoReportes
        If rbtnMotoresVenta.Checked = True Then
            dtReporte = oDocumentoCostoService.ReporteMotoresVendidos(0, cbFecInicio.Text, cbFecFinal.Text).Tables(0)

            If dtReporte.Rows.Count > 0 Then
                Reporte1.FechaInicio7 = cbFecInicio.Value
                Reporte1.FechaFinal7 = cbFecFinal.Value
                Reporte1.Tipo7 = True
            Else
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Reporte1.FechaInicio7 = "01/01/2012"
                Reporte1.FechaFinal7 = "01/09/2012"
                Reporte1.Tipo7 = False
            End If
        End If
    End Sub

    Private Sub btnConsolidado6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsolidado6.Click
        Dim Reporte1 As New frmConsolidadoReportes
        If rbtnConsJobs.Checked = True Then
            dtReporte = oVentaService.ReporteGerVenta(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 0, 7).Tables(0)

            If dtReporte.Rows.Count > 0 Then
                Reporte1.FechaInicio8 = cbFecInicio.Value
                Reporte1.FechaFinal8 = cbFecFinal.Value
                Reporte1.Tipo8 = True
            Else
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Reporte1.FechaInicio8 = "01/01/2012"
                Reporte1.FechaFinal8 = "01/09/2012"
                Reporte1.Tipo8 = False
            End If
        End If
    End Sub

    Private Sub btnConsolidado7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsolidado7.Click
        'Dim Reporte1 As New frmConsolidadoReportes
        'If rbtnJobFac.Checked = True Then
        '    dtReporte = oJobService.ReporteGerencialServicios(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 1).Tables(0)

        '    If dtReporte.Rows.Count > 0 Then
        '        Reporte1.FechaInicio9 = cbFecInicio.Value
        '        Reporte1.FechaFinal9 = cbFecFinal.Value
        '        Reporte1.Tipo9 = True
        '    Else
        '        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
        '        Reporte1.FechaInicio9 = "01/01/2012"
        '        Reporte1.FechaFinal9 = "01/09/2012"
        '        Reporte1.Tipo9 = False
        '    End If
        'End If
    End Sub

    Private Sub btnConsolidado8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsolidado8.Click
        Dim Reporte1 As New frmConsolidadoReportes
        If rbtnPresupuesto.Checked = True Then
            dtReporte = oVentaService.ReporteGerVenta(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 0, 8).Tables(0)

            If dtReporte.Rows.Count > 0 Then
                Reporte1.FechaInicio10 = cbFecInicio.Value
                Reporte1.FechaFinal10 = cbFecFinal.Value
                Reporte1.Tipo10 = True
            Else
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Reporte1.FechaInicio10 = "01/01/2012"
                Reporte1.FechaFinal10 = "01/09/2012"
                Reporte1.Tipo10 = False
            End If
        End If
    End Sub

    Private Sub btnImprimirPresAnual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirPresAnual.Click
        Try
            dtReporte = oVentaService.ReporteGerVenta(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 0, 9).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")

            Else
                reportePresupuestoAnual.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reportePresupuestoAnual
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                forma.crvReportes.DisplayGroupTree = False
                ' reporteJobsFacturados.SetParameterValue("cbFecInicio", cbFecInicio.Value)
                ' reporteJobsFacturados.SetParameterValue("cbFecFinal", cbFecFinal.Value)
                forma.Text = "Reporte Presupuesto Anual"
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub rbtnPresupuesto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnPresupuesto.CheckedChanged
        If rbtnPresupuesto.Checked Then
            btnImprimirPresAnual.Enabled = True
            cbMarcaAgua.Visible = True
        Else
            btnImprimirPresAnual.Enabled = False
            cbMarcaAgua.Visible = False
        End If
    End Sub

    Private Sub rbtnJobFac_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnJobFac.CheckedChanged
        If rbtnJobFac.Checked = True Then
            rbMoneda.Checked = True
            cmbMoneda.Enabled = True
        Else
            rbMoneda.Checked = False
            cmbMoneda.Enabled = False
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

    Private Sub Reporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            cbFecInicio.KeyPress _
                          , cbFecFinal.KeyPress, rbtGerenConsolidado.KeyPress, rbtnGerenGarantias.KeyPress, rbtAdelantos.KeyPress _
                          , rbtnServicioSinIGV.KeyPress, rbtnConsoVentas.KeyPress, rbtnVentasCliente.KeyPress, rbtnMotoresVenta.KeyPress _
                          , rbtnConsJobs.KeyPress, rbtnJobFac.KeyPress, rbtnPresupuesto.KeyPress, rbtnGuiasPendientes.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class