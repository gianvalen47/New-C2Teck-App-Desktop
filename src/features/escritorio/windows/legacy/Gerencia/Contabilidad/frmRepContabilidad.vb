Imports System.ServiceModel

Public Class frmRepContabilidad
    Private oReporteVentaService As New ReporteVentaService.ReporteVentaServiceClient
    Private oSolicitudGastoService As New SolicitudGastoService.SolicitudGastoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Dim IdCliente As String
    Dim CodMon As String
    Dim MarcaAgua As String = ""
    Dim dtReporte As New DataTable

    Private Sub frmRepContabilidad_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oReporteVentaService.Close()
            oSolicitudGastoService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oReporteVentaService.Abort()
            oSolicitudGastoService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oReporteVentaService.Abort()
            oSolicitudGastoService.Abort()
            oSeguridadService.Abort()
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmRepContabilidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        cbFecInicio.KeyPress _
        , cbFecFinal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmRepContabilidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub frmRepContabilidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 91)
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
        'cbMarcaAgua.Visible = False
        cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        cbFecFinal.Value = Fecha
        cbFecInicio.Select()

    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            rbBuscarCliente.Checked = False
            txtCliente.Text = frm.descripcion
            'txtCliente.ReadOnly = True
            'txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If
        txtCliente.Select()
    End Sub
    Private Sub MostrarReporte()
        Try
            If rbtGerenCuadroVentas.Checked = True Then
                Dim forma As New frmReportes
                Dim reporte As New rpRepGerContabilidad_Nuevo4
                Dim dtReporte As New DataTable

                dtReporte = oReporteVentaService.ReporteGerCuadroVenta(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, CodMon, IIf(rbBuscarCliente.Checked = True, 0, IdCliente), 1).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
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
                    reporte.SetParameterValue("DesCli", toBlank(txtCliente.Text))
                    If CodMon = "US" Then
                        reporte.SetParameterValue("Moneda", "DOLARES USA")
                    Else
                        reporte.SetParameterValue("Moneda", "NUEVOS SOLES")
                    End If

                    'For i As Integer = 0 To dtReporte.Rows.Count - 1
                    '    If dtReporte.Rows(i).Item("Mes") = 1 Then
                    '        reporte.SetParameterValue("Mes", "ENE")
                    '    ElseIf dtReporte.Rows(i).Item("Mes") = 2 Then
                    '        reporte.SetParameterValue("Mes", "FEB")
                    '    ElseIf dtReporte.Rows(i).Item("Mes") = 3 Then
                    '        reporte.SetParameterValue("Mes", "MAR")
                    '    ElseIf dtReporte.Rows(i).Item("Mes") = 4 Then
                    '        reporte.SetParameterValue("Mes", "ABR")
                    '    ElseIf dtReporte.Rows(i).Item("Mes") = 5 Then
                    '        reporte.SetParameterValue("Mes", "MAY")
                    '    ElseIf dtReporte.Rows(i).Item("Mes") = 6 Then
                    '        reporte.SetParameterValue("Mes", "JUN")
                    '    ElseIf dtReporte.Rows(i).Item("Mes") = 7 Then
                    '        reporte.SetParameterValue("Mes", "JUL")
                    '    ElseIf dtReporte.Rows(i).Item("Mes") = 8 Then
                    '        reporte.SetParameterValue("Mes", "AGO")
                    '    ElseIf dtReporte.Rows(i).Item("Mes") = 9 Then
                    '        reporte.SetParameterValue("Mes", "SET")
                    '    ElseIf dtReporte.Rows(i).Item("Mes") = 10 Then
                    '        reporte.SetParameterValue("Mes", "OCT")
                    '    ElseIf dtReporte.Rows(i).Item("Mes") = 11 Then
                    '        reporte.SetParameterValue("Mes", "NOV")
                    '    ElseIf dtReporte.Rows(i).Item("Mes") = 12 Then
                    '        reporte.SetParameterValue("Mes", "DIC")
                    '    End If
                    'Next
                    reporte.SetParameterValue("FecInicio", cbFecInicio.Text)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Text)
                    reporte.SetParameterValue("MarcaAgua", MarcaAgua)
                    forma.Text = "Reporte de Gerencial de Contabilidad"
                    forma.ShowDialog()
                End If

            ElseIf rbtGerenGastosJob.Checked = True Then
                Dim forma As New frmReportes
                Dim reporte As New rpRepGerGastosJob
                Dim dtReporte As New DataTable

                dtReporte = oSolicitudGastoService.ReporteGerGastoJob(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, CodMon).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.DisplayGroupTree = False                    
                    If CodMon = "US" Then
                        reporte.SetParameterValue("Moneda", "DOLARES USA")
                    Else
                        reporte.SetParameterValue("Moneda", "NUEVOS SOLES")
                    End If
                    reporte.SetParameterValue("pFecInicio", cbFecInicio.Text)
                    reporte.SetParameterValue("pFecFin", cbFecFinal.Text)
                    forma.Text = "Reporte de Gerencial de Contabilidad"
                    forma.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(91, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub


    Private Sub rbSoles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSoles.CheckedChanged, rbDolares.CheckedChanged
        If rbSoles.Checked Then
            CodMon = "NS"
        ElseIf rbDolares.Checked Then
            CodMon = "US"
        End If
    End Sub

    Private Sub rbBuscarCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarCliente.CheckedChanged
        txtCliente.Text = ""
    End Sub

    Private Sub btnConsolidado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsolidado.Click
        Dim Reporte1 As New frmConsolidadoReportes

        dtReporte = oReporteVentaService.ReporteGerCuadroVenta(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, CodMon, IIf(rbBuscarCliente.Checked = True, 0, IdCliente), 1).Tables(0)

        If dtReporte.Rows.Count > 0 Then
            Reporte1.FechaInicio17 = cbFecInicio.Value
            Reporte1.FechaFinal17 = cbFecFinal.Value
            Reporte1.CodMon17 = CodMon
            Reporte1.Cliente17 = IIf(rbBuscarCliente.Checked = True, 0, IdCliente)
            Reporte1.Tipo17 = True
        Else
            MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Reporte1.FechaInicio17 = "01/01/2012"
            Reporte1.FechaFinal17 = "10/01/2012"
            Reporte1.CodMon17 = CodMon
            Reporte1.Cliente17 = IIf(rbBuscarCliente.Checked = True, 0, IdCliente)
            Reporte1.Tipo17 = False
        End If

    End Sub

    Private Sub rbtGerenCuadroVentas_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbtGerenCuadroVentas.CheckedChanged, rbtGerenGastosJob.CheckedChanged
        If rbtGerenCuadroVentas.Checked = True Then
            gbBuscarCliente.Enabled = True
            cbMarcaAgua.Visible = True
        ElseIf rbtGerenGastosJob.Checked = True Then
            gbBuscarCliente.Enabled = False
            cbMarcaAgua.Visible = False
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