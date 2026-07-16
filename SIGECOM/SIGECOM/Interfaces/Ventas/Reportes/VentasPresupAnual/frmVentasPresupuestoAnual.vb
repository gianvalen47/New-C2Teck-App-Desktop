Imports System.ServiceModel

Public Class frmVentasPresupuestoAnual

    Private oVentaService As New ReporteVentaService.ReporteVentaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Dim dtReporte As New DataTable

    Dim forma As New frmReportes

    Dim reportePresupuestoAnual As New rptGerencialPresupuestoAnual
    Dim reporteVentaPresupuesto As New rptGerenciaVentaPresupuesto
    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click

        Try
            oSeguridadService.RegistrarVisitaOpciones(260, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If rbPresupuestoAnual.Checked = True Then
                dtReporte = oVentaService.ReporteGerVenta(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 0, 9).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")

                Else
                    reportePresupuestoAnual.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reportePresupuestoAnual

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    'forma.crvReportes.DisplayGroupTree = False
                    ' reporteJobsFacturados.SetParameterValue("cbFecInicio", cbFecInicio.Value)
                    ' reporteJobsFacturados.SetParameterValue("cbFecFinal", cbFecFinal.Value)
                    forma.Text = "Reporte Presupuesto Anual"
                    forma.ShowDialog()
                End If

            ElseIf rbVentasvsPresupuesto.Checked = True Then
                dtReporte = oVentaService.ReporteGerVenta(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 0, 8).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")

                Else
                    reporteVentaPresupuesto.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteVentaPresupuesto

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    'forma.crvReportes.DisplayGroupTree = False
                    ' reporteJobsFacturados.SetParameterValue("cbFecInicio", cbFecInicio.Value)
                    ' reporteJobsFacturados.SetParameterValue("cbFecFinal", cbFecFinal.Value)
                    reporteVentaPresupuesto.SetParameterValue("MarcaAgua", "")
                    forma.Text = "Reporte  Gerencial de Ventas vs Presupuesto"
                    forma.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmVentasPresupuestoAnual_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oVentaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oVentaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oVentaService.Abort()
            oSeguridadService.Abort()
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmVentasPresupuestoAnual_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmVentasPresupuestoAnual_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 260)
        '/*************************************************************************************/

        Dim Mes, Anio, meses As Integer
        Dim Fecha As Date

        Fecha = Today
        meses = Month(Today) 'IIf(Month(Fecha) = 1, 12, Month(Fecha))
        If meses = 1 Then
            Mes = Month(Today)
            Anio = Year(Today)
        Else
            Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
            Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        End If

        cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        cbFecFinal.Value = Fecha
        cbFecInicio.Select()
    End Sub

    Private Sub frmRepVentaComisiones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
    rbPresupuestoAnual.KeyPress _
           , rbVentasvsPresupuesto.KeyPress _
           , cbFecInicio.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtFechaFin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbFecFinal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            btnAceptar.Select()
            '            e.Handled = True
        End If
    End Sub

End Class