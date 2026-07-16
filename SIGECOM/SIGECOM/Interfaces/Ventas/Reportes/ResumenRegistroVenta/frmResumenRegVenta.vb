Imports System.ServiceModel
Public Class frmResumenRegVenta
    Private oReporteVentaService As New ReporteVentaService.ReporteVentaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oMaestro As New MaestroService.MaestroClient
    Private dtReporte As DataTable
    Dim IdCliente As String
    Dim CodTipo As String


    Private Sub frmResumenRegVenta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestro.Close()
            oReporteVentaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMaestro.Abort()
            oReporteVentaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestro.Abort()
            oReporteVentaService.Abort()
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

    Private Sub frmResumenRegVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        cbFecInicio.KeyPress _
                        , rbVentas.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub frmResumenRegVenta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            e.Handled = True
        End If
    End Sub
    Private Sub frmResumenRegVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 31)
        '/*************************************************************************************/

        Dim Mes, Anio, meses As Integer
        Dim Fecha As Date

        Fecha = Today
        meses = Month(Today)
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

        rbExportExcel.Enabled = IIf(oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = True, True, False)

    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim reporte As New rpResumenRegVenta            
            Dim reporte1 As New rpResumenRegVentaxCliente

            dtReporte = oReporteVentaService.RegistroResumenVenta(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, "US", IdCliente, CodTipo).Tables(0)
            DataGridView1.DataSource = dtReporte

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                If rbExportExcel.Checked Then
                    Dim Export As Boolean = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente ")
                    End If
                ElseIf rbPantalla.Checked Then
                    If CodTipo = 6 Then
                        reporte1.SetDataSource(dtReporte)
                        reporte1.SetParameterValue("Cliente", IIf(txtCliente.Text = "", "", txtCliente.Text))
                        reporte1.SetParameterValue("FecInicio", cbFecInicio.Value)
                        reporte1.SetParameterValue("FecFinal", cbFecFinal.Value)
                        reporte1.SetParameterValue("Motivo", IIf(CodTipo = 4, "EXPORTACION", IIf(CodTipo = 5, "TRANSF..GRATUITA", IIf(CodTipo = 6, "AGRUPADO POR CLIENTE", ""))))
                        forma.crvReportes.ReportSource = reporte1
                    Else
                        reporte.SetDataSource(dtReporte)
                        reporte.SetParameterValue("Cliente", IIf(txtCliente.Text = "", "", txtCliente.Text))
                        reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                        reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                        reporte.SetParameterValue("Motivo", IIf(CodTipo = 4, "EXPORTACION", IIf(CodTipo = 5, "TRANSF..GRATUITA", IIf(CodTipo = 6, "AGRUPADO POR CLIENTE", ""))))
                        reporte.SetParameterValue("CodTipo", CodTipo)
                        forma.crvReportes.ReportSource = reporte
                    End If

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Reporte Resumido de Ventas"
                    forma.ShowDialog()

                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(31, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub rbResumen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbVentas.CheckedChanged, rbExportacion.CheckedChanged, rbTransGrat.CheckedChanged, rbAgrupxCliente.CheckedChanged
        If rbVentas.Checked Then
            CodTipo = "3"
        ElseIf rbExportacion.Checked Then
            CodTipo = "4"
        ElseIf rbTransGrat.Checked Then
            CodTipo = "5"
        ElseIf rbAgrupxCliente.Checked Then
            CodTipo = "6"
        End If
    End Sub

    Private Sub rbBuscarCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarCliente.CheckedChanged
        txtCliente.Text = ""
        IdCliente = 0
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

    Private Sub cbFecFinal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbFecFinal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnAceptar.Select()
            'btnAceptar_Click(sender, e)
        End If
    End Sub
End Class