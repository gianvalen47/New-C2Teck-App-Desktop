Imports System.ServiceModel

Public Class frmRepGerImportaciones
    Private oDocumentoCostoService As New DocumentoCostoService.DocumentoCostoServiceClient
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Dim MarcaAgua As String = ""
    Private Sub frmRepGerImportaciones_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        Try
            oDocumentoCostoService.Close()
            oLocacionMercaderiaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oDocumentoCostoService.Abort()
            oLocacionMercaderiaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oDocumentoCostoService.Abort()
            oLocacionMercaderiaService.Abort()
            oSeguridadService.Abort()
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub frmRepGerImportaciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepGerImportaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        cbFecInicio.KeyPress _
        , cbFecFinal.KeyPress, rb0111.KeyPress, rb0112.KeyPress, rb0113.KeyPress, rb0114.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmRepGerImportaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 89)
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

    Private Sub MostrarReporte0111()
        Try
            Dim forma As New frmReportes
            Dim reporte As New rpRepGerImportaciones1
            Dim dtReporte As New DataTable

            dtReporte = oDocumentoCostoService.ReporteGerenciaCostos(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 1).Tables(0)
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
                reporte.SetParameterValue("MarcaAgua", MarcaAgua)
                reporte.SetParameterValue("FecInicio", cbFecInicio.Text)
                reporte.SetParameterValue("FecFinal", cbFecFinal.Text)
                forma.Text = "Reporte Gerencial de Importaciones"
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub


    Private Sub MostrarReporte0112()

        Try
            Dim forma As New frmReportes
            Dim reporte As New rpRepGerImportaciones2
            Dim dtReporte As New DataTable

            dtReporte = oDocumentoCostoService.ReporteGerenciaCostos(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 2).Tables(0)
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
                reporte.SetParameterValue("FecFinal", cbFecFinal.Text)
                reporte.SetParameterValue("FecInicio", cbFecInicio.Text)
                'forma.crvReportes.RefreshReport = False

                forma.Text = "Reporte Gerencial de Importaciones"
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub
    Private Sub MostrarReporte0113()
        Try
            Dim forma As New frmReportes
            Dim reporte As New rpRepGerImportaciones3
            Dim dtReporte As New DataTable


            dtReporte = oDocumentoCostoService.ReporteGerenciaCostos(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 3).Tables(0)
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
                reporte.SetParameterValue("FecFinal", cbFecFinal.Text)
                reporte.SetParameterValue("FecInicio", cbFecInicio.Text)
                'forma.crvReportes.RefreshReport = False

                forma.Text = "Reporte Gerencial de Importaciones"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub MostrarReporte0114()
        Try
            Dim forma As New frmReportes
            Dim reporte As New rpRepGerImportaciones4
            Dim dtReporte As New DataTable

            dtReporte = oLocacionMercaderiaService.ReporteGerencialInventarios(Session.sCodEmp, "", cbFecInicio.Value, cbFecFinal.Value, 0, 2).Tables(0)

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
                reporte.SetParameterValue("FecFinal", cbFecFinal.Text)
                reporte.SetParameterValue("FecInicio", cbFecInicio.Text)
                'forma.crvReportes.RefreshReport = False

                forma.Text = "Reporte Gerencial de Importaciones Por Proveedor"
                forma.ShowDialog()
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
        oSeguridadService.RegistrarVisitaOpciones(89, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        If rb0111.Checked Then
            MostrarReporte0111()
        ElseIf rb0112.Checked Then
            MostrarReporte0112()
        ElseIf rb0113.Checked Then
            MostrarReporte0113()
        ElseIf rb0114.Checked Then
            MostrarReporte0114()

        End If
    End Sub

    Private Sub btnConsolidado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsolidado.Click
        Dim Reporte1 As New frmConsolidadoReportes
        Dim dtReporte As DataTable

        If rb0111.Checked = True Then
            dtReporte = oDocumentoCostoService.ReporteGerenciaCostos(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 1).Tables(0)

            If dtReporte.Rows.Count > 0 Then
                Reporte1.FechaInicio11 = cbFecInicio.Value
                Reporte1.FechaFinal11 = cbFecFinal.Value
                Reporte1.Tipo11 = True
            Else
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Reporte1.FechaInicio11 = "01/07/2012"
                Reporte1.FechaFinal11 = "30/07/2012"
                Reporte1.Tipo11 = False
            End If
        End If
    End Sub

    Private Sub btnConsolidado1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsolidado1.Click
        Dim Reporte1 As New frmConsolidadoReportes
        Dim dtReporte As DataTable

        If rb0112.Checked = True Then
            dtReporte = oDocumentoCostoService.ReporteGerenciaCostos(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 2).Tables(0)

            If dtReporte.Rows.Count > 0 Then
                Reporte1.FechaInicio12 = cbFecInicio.Value
                Reporte1.FechaFinal12 = cbFecFinal.Value
                Reporte1.Tipo12 = True
            Else
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Reporte1.FechaInicio12 = "01/07/2012"
                Reporte1.FechaFinal12 = "30/07/2012"
                Reporte1.Tipo12 = False
            End If
        End If
    End Sub

    Private Sub btnConsolidado2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsolidado2.Click
        Dim Reporte1 As New frmConsolidadoReportes
        Dim dtReporte As DataTable

        If rb0113.Checked = True Then
            dtReporte = oDocumentoCostoService.ReporteGerenciaCostos(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 3).Tables(0)

            If dtReporte.Rows.Count > 0 Then
                Reporte1.FechaInicio13 = cbFecInicio.Value
                Reporte1.FechaFinal13 = cbFecFinal.Value
                Reporte1.Tipo13 = True
            Else
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Reporte1.FechaInicio13 = "01/07/2012"
                Reporte1.FechaFinal13 = "30/07/2012"
                Reporte1.Tipo13 = False
            End If
        End If
    End Sub

    Private Sub btnConsolidado3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsolidado3.Click
        Dim Reporte1 As New frmConsolidadoReportes
        Dim dtReporte As DataTable

        If rb0114.Checked = True Then
            dtReporte = oLocacionMercaderiaService.ReporteGerencialInventarios(Session.sCodEmp, "", cbFecInicio.Value, cbFecFinal.Value, 0, 2).Tables(0)

            If dtReporte.Rows.Count > 0 Then
                Reporte1.FechaInicio14 = cbFecInicio.Value
                Reporte1.FechaFinal14 = cbFecFinal.Value
                Reporte1.Tipo14 = True
            Else
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Reporte1.FechaInicio14 = "01/07/2012"
                Reporte1.FechaFinal14 = "30/07/2012"
                Reporte1.Tipo14 = False
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

    Private Sub rb0111_CheckedChanged(sender As Object, e As EventArgs) Handles rb0111.CheckedChanged
        If rb0111.Checked Then
            cbMarcaAgua.Visible = True
        Else
            cbMarcaAgua.Visible = False
        End If
    End Sub
End Class