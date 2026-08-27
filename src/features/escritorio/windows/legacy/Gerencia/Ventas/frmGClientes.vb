Imports System.ServiceModel
Public Class frmGClientes

    Private oVentaService As New ReporteVentaService.ReporteVentaServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtReporte As DataTable
    Private reporteVentasSegunCliente As New rptVentasSegunCliente
    Private reporteJobsFacturados As New rptGerenciaJobFacturados
    Private forma As New frmReportes
    Private IdCliente As Integer
    Dim Ruc As String
    Public fechaInicio As Date
    Public fechaFin As Date
    Public TipoReporte As String
    Public Moneda As String
    Dim MarcaAgua As String = ""

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oVentaService.Close()
            oSeguridadService.Close()
            oJobService.Close()

        Catch ex As TimeoutException
            oVentaService.Abort()
            oSeguridadService.Abort()
            oJobService.Abort()

        Catch ex As CommunicationException
            oVentaService.Abort()
            oSeguridadService.Abort()
            oJobService.Abort()
        End Try
    End Sub

    Private Sub frmGClientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            rbBuscarCliente.Checked = False
            txtCliente.Text = frm.descripcion
            'txtCliente.ReadOnly = True
            'txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
            Ruc = frm.Ruc
        End If
        txtCliente.Select()
    End Sub

    Private Sub rbBuscarCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarCliente.CheckedChanged
        txtCliente.Text = ""
        IdCliente = 0
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            oSeguridadService.RegistrarVisitaOpciones(88, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If TipoReporte = "VentaCliente" Then

                dtReporte = oVentaService.ReporteGerVenta(Session.sCodEmp, fechaInicio, fechaFin, IIf(rbBuscarCliente.Checked = True, 0, IdCliente), 6).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique. !!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporteVentasSegunCliente.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteVentasSegunCliente
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.DisplayGroupTree = False
                    reporteVentasSegunCliente.SetParameterValue("MarcaAgua", MarcaAgua)
                    reporteVentasSegunCliente.SetParameterValue("FecInicio", fechaInicio)
                    reporteVentasSegunCliente.SetParameterValue("FechaFin", fechaFin)
                    forma.Text = "Reporte Gerencial Ventas Según Cliente"
                    forma.ShowDialog()
                End If
            ElseIf TipoReporte = "JobFac" Then
                dtReporte = oJobService.ReporteGerencialServicios(Session.sCodEmp, fechaInicio, fechaFin, Moneda, IIf(rbBuscarCliente.Checked = True, 0, IdCliente), 1).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporteJobsFacturados.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteJobsFacturados
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.DisplayGroupTree = False
                    reporteJobsFacturados.SetParameterValue("Moneda", IIf(Moneda = "US", "EXPRESADO EN DÓLARES", "EXPRESADO EN SOLES"))
                    reporteJobsFacturados.SetParameterValue("MarcaAgua", MarcaAgua)
                    reporteJobsFacturados.SetParameterValue("cbFecInicio", fechaInicio)
                    reporteJobsFacturados.SetParameterValue("cbFecFinal", fechaFin)
                    forma.Text = "Reporte  Gerencial de Jobs Facturados"
                    forma.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub frmGClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rbBuscarCliente.Checked = True
        txtCliente.Clear()
        IdCliente = 0
    End Sub

    Private Sub btnConsolidado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsolidado.Click

        If TipoReporte = "VentaCliente" Then


            Dim Reporte1 As New frmConsolidadoReportes
            dtReporte = oVentaService.ReporteGerVenta(Session.sCodEmp, fechaInicio, fechaFin, IIf(rbBuscarCliente.Checked = True, 0, IdCliente), 6).Tables(0)

            If dtReporte.Rows.Count > 0 Then
                Reporte1.FechaInicio6 = fechaInicio
                Reporte1.FechaFinal6 = fechaFin
                Reporte1.Cliente6 = IIf(rbBuscarCliente.Checked = True, 0, IdCliente)
                Reporte1.Tipo6 = True
            Else
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Reporte1.FechaInicio6 = "01/01/2012"
                Reporte1.FechaFinal6 = "01/09/2012"
                Reporte1.Cliente6 = 0
                Reporte1.Tipo6 = False
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
End Class