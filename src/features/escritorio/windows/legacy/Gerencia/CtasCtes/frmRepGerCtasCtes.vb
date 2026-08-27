Imports System.ServiceModel
Public Class frmRepGerCtasCtes
    Private oDocumentosCtasCtesService As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private Sub frmRepCreditos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try

            oDocumentosCtasCtesService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException

            oDocumentosCtasCtesService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException

            oDocumentosCtasCtesService.Abort()
            oSeguridadService.Abort()
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmRepCreditos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        cbFecInicio.KeyPress _
   , cbFecFinal.KeyPress, rb041.KeyPress, rb042.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmRepGerCtasCtes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepCreditos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 92)
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

    Private Sub MostrarReporte041()
        Try
            Dim forma As New frmReportes
            Dim reporte As New rpRepGerCreditos
            Dim dtReporte As New DataTable

            dtReporte = oDocumentosCtasCtesService.ReporteGerencial(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 1).Tables(0)
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
                forma.crvReportes.DisplayGroupTree = False
                'forma.crvReportes.RefreshReport = False


                reporte.SetParameterValue("FecInicio", cbFecInicio.Text)
                reporte.SetParameterValue("FecFinal", cbFecFinal.Text)
                forma.Text = "Reporte Gerencial de Créditos y Cobranzas"
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub MostrarReporte042()
        Try
            Try
                Dim forma As New frmReportes
                Dim reporte As New rpRepGerCreditos2
                Dim dtReporte As New DataTable
                Dim total As Double
                Dim cantidad As Integer
                Dim Fecha1 As Date
                Dim Fecha2 As Date
                Dim Anio As Integer
                oDocumentosCtasCtesService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(10)
                dtReporte = oDocumentosCtasCtesService.ReporteGerencial(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 2).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    total = CDbl(dtReporte.Compute("Sum(TotCob)", "").ToString())
                    cantidad = CInt(dtReporte.Compute("Count(TotCob)", "").ToString())
                    'For Each Fila As DataRow In dtReporte.Rows
                    '    Dim contador As Double
                    '    contador = Fila.Item("TotCob")
                    '    total = total + contador
                    'Next

                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.crvReportes.DisplayGroupTree = False
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Text)
                    reporte.SetParameterValue("TotalCobranza", total)
                    reporte.SetParameterValue("Cantidad", cantidad)

                    Anio = Year(cbFecFinal.Value)
                    Fecha1 = "01/01/ " & Trim(Anio)
                    Fecha2 = cbFecFinal.Value
                    reporte.SetParameterValue("Dias", Fecha2.Subtract(Fecha1).TotalDays() + 1)

                    'forma.crvReportes.RefreshReport = False

                    forma.Text = "Reporte Gerencial de Créditos y Cobranzas"
                    forma.ShowDialog()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
            End Try
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(92, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        If rb041.Checked Then
            MostrarReporte041()
        ElseIf rb042.Checked Then
            MostrarReporte042()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnConsolidado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsolidado.Click
        Dim Reporte1 As New frmConsolidadoReportes
        Dim dtReporte As DataTable

        If rb041.Checked = True Then
            dtReporte = oDocumentosCtasCtesService.ReporteGerencial(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 1).Tables(0)

            If dtReporte.Rows.Count > 0 Then
                Reporte1.FechaInicio16 = cbFecInicio.Value
                Reporte1.FechaFinal16 = cbFecFinal.Value
                Reporte1.Tipo16 = True
            Else
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Reporte1.FechaInicio16 = "01/07/2012"
                Reporte1.FechaFinal16 = "31/07/2012"
                Reporte1.Tipo16 = False
            End If
        End If
    End Sub
End Class