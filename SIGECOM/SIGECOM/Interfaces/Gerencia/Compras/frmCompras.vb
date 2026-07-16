Imports System.ServiceModel
Public Class frmCompras

    '===========================Servicios====================================================
    Private oSolicitudGastoService As New SolicitudGastoService.SolicitudGastoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Dim dtReporte As New DataTable
    Dim dtSubreporte As New DataTable
    Dim forma As New frmReportes

    Dim reporteCompra As New rptGerenciaComprasPresupuesto

    Private Sub frmCompras_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudGastoService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oSolicitudGastoService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oSolicitudGastoService.Abort()
            oSeguridadService.Abort()
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmCompras_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 287)
        '/*************************************************************************************/

        Dim Mes, Anio, meses As Integer
        Dim Fecha As Date

        'LlenarComboMoneda()
        'cmbMoneda.Value = "US"
        'rbMoneda.Checked = False
        'rbMoneda.Enabled = False
        'cmbMoneda.Enabled = False

        Fecha = Today
        meses = Month(Today) 'IIf(Month(Fecha) = 1, 12, Month(Fecha))
        If meses = 1 Then
            Mes = Month(Today)
            Anio = Year(Today)
        Else
            Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
            Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        End If

        'cbMarcaAgua.Visible = False
        cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        cbFecFinal.Value = Fecha
        cbFecInicio.Select()

        'txtAnio.Value = Today.Year

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        MostrarReporte
    End Sub

    Private Sub MostrarReporte()

        If rbtnPresupuesto.Checked Then

            dtReporte = oSolicitudGastoService.ReporteGerencialPresupuestoCompras(Session.sCodEmp, Year(cbFecInicio.Value)).Tables(0)
            'dtSubreporte = oSolicitudGastoService.ReporteGerencialPresupuestoComprasPorUnidad(Session.sCodEmp, Year(cbFecInicio.Value)).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")

            Else

                'If reporteCompra.Subreports.Count > 0 Then
                '    reporteCompra.Subreports(0).SetDataSource(dtSubreporte)
                'End If

                reporteCompra.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporteCompra
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If

                'forma.crvReportes.DisplayGroupTree = False
                'forma.crvReportes.RefreshReport = False
                'reporteCompra.SetParameterValue("FechaInicio", cbFecInicio.Value)
                'reporteCompra.SetParameterValue("FechaFin", cbFecFinal.Value)
                forma.Text = "Reporte de Gerencial Reg. Compra"
                forma.ShowDialog()
            End If

        End If

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class