Imports System.ServiceModel
Public Class frmRepResuGeneral

    'Private ObjMaestro As New MaestroService.MaestroClient
    Private objDocumentoCosto As New DocumentoCostoService.DocumentoCostoServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtReporte As New DataTable
    Private dtMeses As DataTable
    Private dtdatoresumen As DataTable

    Private Sub frmRepResuGeneral_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oSeguridadService.Close()
            objDocumentoCosto.Close()

        Catch ex As TimeoutException
            oMaestroService.Abort()
            oSeguridadService.Abort()
            objDocumentoCosto.Abort()

        Catch ex As CommunicationException
            oMaestroService.Abort()
            oSeguridadService.Abort()
            objDocumentoCosto.Abort()

        End Try
    End Sub

    Private Sub frmRepResuGeneral_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepResuGeneral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 94)
        '/*************************************************************************************/

        txtanio.Value = Today.Year
        'cmbMes.Value = Today.Month
        llenarCombo()
        'dtReporte = objDocumentoCosto.ReporteCondensado(Session.sCodEmp, 2010, 10, 5).Tables(0)
        'DataGridView1.DataSource = dtReporte     
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim forma As New frmReportes
        Try
            oSeguridadService.RegistrarVisitaOpciones(94, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If rbtnCompras.Checked = True Then
                Dim reporte As New rptResumenGeneral

                dtReporte = objDocumentoCosto.ReporteCondensado(Session.sCodEmp, txtanio.Value, cmbMes.Value, 1).Tables(0)
                If dtReporte.Rows.Count < 1 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
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

                    'forma.crvReportes.RefreshReport = False
                    reporte.SetParameterValue("mes", cmbMes.Text)
                    reporte.SetParameterValue("anio", txtanio.Value)
                    forma.Text = "Reporte de Costos Resumen General"
                    forma.ShowDialog()
                End If
            ElseIf rbtnCostos.Checked = True Then
                Dim reporteCosto As New rptCostoVenta
                dtReporte = objDocumentoCosto.ReporteCondensado(Session.sCodEmp, txtanio.Value, cmbMes.Value, 2).Tables(0)
                If dtReporte.Rows.Count < 1 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporteCosto.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteCosto

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    reporteCosto.SetParameterValue("mes", cmbMes.Text)
                    reporteCosto.SetParameterValue("anio", txtanio.Value)
                    forma.Text = "Reporte de Costos Costo Venta"
                    forma.ShowDialog()
                End If
            ElseIf rbtnTransfVentas.Checked = True Then
                Dim reporteTransfVentas As New rptTransfVentas
                dtReporte = objDocumentoCosto.ReporteCondensado(Session.sCodEmp, txtanio.Value, cmbMes.Value, 3).Tables(0)
                If dtReporte.Rows.Count < 1 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporteTransfVentas.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteTransfVentas

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    reporteTransfVentas.SetParameterValue("mes", cmbMes.Text)
                    reporteTransfVentas.SetParameterValue("anio", txtanio.Value)
                    forma.Text = "Reporte de Costos Transferecias y Ventas"
                    forma.ShowDialog()
                End If
            ElseIf rbtnTransfMotores.Checked = True Then
                Dim reporteTransfMotores As New rptTransfMotores
                dtReporte = objDocumentoCosto.ReporteCondensado(Session.sCodEmp, txtanio.Value, cmbMes.Value, 4).Tables(0)
                If dtReporte.Rows.Count < 1 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporteTransfMotores.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteTransfMotores

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    reporteTransfMotores.SetParameterValue("mes", cmbMes.Text)
                    reporteTransfMotores.SetParameterValue("anio", txtanio.Value)
                    forma.Text = "Reporte de Costos Transferencias a Motores"
                    forma.ShowDialog()
                End If
            ElseIf rbtnMovResumen.Checked = True Then
                Dim reporteMovResumen As New rptMovResumen
                dtReporte = objDocumentoCosto.ReporteCondensado(Session.sCodEmp, txtanio.Value, cmbMes.Value, 5).Tables(0)
                dtdatoresumen = objDocumentoCosto.ReporteCondensado(Session.sCodEmp, txtanio.Value, cmbMes.Value, 6).Tables(0)
                Dim suma As Object = dtdatoresumen.Compute("Sum(Total)", "")


                If dtReporte.Rows.Count < 1 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporteMovResumen.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteMovResumen

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    reporteMovResumen.SetParameterValue("mes", cmbMes.Text)
                    reporteMovResumen.SetParameterValue("anio", txtanio.Value)
                    reporteMovResumen.SetParameterValue("movresumen", suma.ToString)
                    forma.Text = "Reporte de Costos Mov. Resumen vs Mov. Detalle"
                    forma.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub llenarCombo()
        '======================================= MESES ================================================
        txtanio.Value = IIf(Month(Today) = 1, Year(Today) - 1, Year(Today))
        dtMeses = oMaestroService.MostrarMeses
        cmbMes.DataSource = dtMeses
        cmbMes.DropDownList.DataMember = dtMeses.Columns("Descripcion").ToString
        cmbMes.DropDownList.DisplayMember = dtMeses.Columns("Descripcion").ToString
        cmbMes.DropDownList.ValueMember = dtMeses.Columns("Codigo").ToString
        cmbMes.DropDownList.Columns(0).DataMember = dtMeses.Columns("Codigo").ToString
        cmbMes.DropDownList.Columns(1).DataMember = dtMeses.Columns("Descripcion").ToString
        'cmbMes.SelectedIndex = 0
        cmbMes.SelectedIndex = IIf(Month(Today) = 1, 11, Month(Today) - 2)
        dtMeses = Nothing
    End Sub
End Class