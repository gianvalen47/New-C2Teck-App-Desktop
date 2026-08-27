Imports System.ServiceModel
Public Class frmRepGmroi

    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oProductoService As New ProductoService.ProductoServiceClient
    Private dtAlmacenes As DataTable
    Private dtOficinas As DataTable
    Private dtRubros As DataTable
    Private dtReporte As New DataTable

    Private Sub frmRepGmroi_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oSeguridadService.Close()
            oLocacionMercaderiaService.Close()
            oProductoService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oLocacionMercaderiaService.Abort()
            oProductoService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oLocacionMercaderiaService.Abort()
            oProductoService.Abort()
        End Try
    End Sub

    Private Sub frmRepGmroi_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 270)
        '/*************************************************************************************/

        'Dim Mes, Anio As Integer
        'Dim Fecha As Date
        Dim Fecha As Date
        Fecha = Today
        'Fecha = Today
        'Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha) - 1)
        'Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        'cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        'cbFecFinal.Value = DateSerial(Year(Fecha), (Month(Fecha) - 1) + 1, 0)
        cbFecInicio.Value = CDate("01/01/" & Today.Year)
        cbFecFinal.Value = DateSerial(Year(Fecha), (Month(Fecha) - 1) + 1, 0)
        llenarCombos()
        cbFecInicio.Focus()

        rbExcel.Enabled = IIf(oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = True, True, False)

    End Sub

    Private Sub frmRepGmroi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepCostoVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
             cbFecFinal.KeyPress _
           , cbFecInicio.KeyPress _
           , cmbIdLocacion.KeyPress _
           , cmbOficinas.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= Oficinas ================================================
            dtOficinas = oMaestroService.MostrarOficinasEmpresa(Session.sCodEmp, Session.sCodUsu).Tables(0)
            dtOficinas.Rows.InsertAt(getRowTodos(dtOficinas), 0)
            cmbOficinas.DataSource = dtOficinas
            'cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

            '======================================= RUBROS ================================================
            dtRubros = oProductoService.MostrarRubrosEmpresa(Session.sCodEmp).Tables(0)
            dtRubros.Rows.InsertAt(getRowTodos1(dtRubros), 0)
            cmbCodRub.DataSource = dtRubros
            cmbCodRub.DropDownList.DataMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.DropDownList.DisplayMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.DropDownList.ValueMember = dtRubros.Columns("CodRub").ToString
            cmbCodRub.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRub").ToString
            cmbCodRub.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.SelectedIndex = 0
            dtRubros = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        Try
            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            dtAlmacenes.Rows.InsertAt(getRowTodos1(dtAlmacenes), 0)
            cmbIdLocacion.DataSource = dtAlmacenes
            cmbIdLocacion.DisplayMember = "DesAlm"
            cmbIdLocacion.ValueMember = "IdLocacion"
            cmbIdLocacion.DropDownList.Columns(0).DataMember = "CodAlm"
            cmbIdLocacion.DropDownList.Columns(1).DataMember = "DesAlm"
            'cbAlmacen.SelectedIndex = 0
            If dtAlmacenes.Rows.Count > 0 Then
                cmbIdLocacion.SelectedIndex = 0
            Else
                cmbIdLocacion.Value = ""
            End If
            dtAlmacenes = Nothing

        Catch ex As Exception
            MsgBox("Error al Cargar Almacenes", MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception

        End Try
        Return fila
    End Function

    Private Function getRowTodos1(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(5) = "(Todos)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub MostrarReporte()
        Try
            If rbResumenRubro.Checked Then
                If rbPantalla.Checked = True Then
                    Dim forma As New frmReportes
                    Dim dtReporte As New DataTable
                    oLocacionMercaderiaService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
                    Dim reporte As New rptRepGmroiResRub
                    dtReporte = oLocacionMercaderiaService.ReporteGMROI(Session.sCodEmp, IIf(cmbIdLocacion.SelectedIndex = 0, 0, toNumber(cmbIdLocacion.Value)), cbFecInicio.Value, cbFecFinal.Value, IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Value), 1).Tables(0)
                    'DataGridView2.DataSource = dtReporte
                    If reporte.Subreports.Count > 0 Then
                        reporte.Subreports(0).SetDataSource(dtReporte)
                    End If

                    If dtReporte.Rows.Count = 0 Then
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

                        reporte.SetParameterValue("pFecInicio", cbFecInicio.Text)
                        reporte.SetParameterValue("pFecFinal", cbFecFinal.Text)
                        reporte.SetParameterValue("pRubro", cmbCodRub.Text)
                        reporte.SetParameterValue("pOficina", cmbOficinas.Text)
                        reporte.SetParameterValue("pAlmacen", cmbIdLocacion.Text)
                        forma.Text = "Reporte de GMROI"
                        forma.ShowDialog()
                    End If
                ElseIf rbExcel.Checked = True Then
                    dtReporte = oLocacionMercaderiaService.ReporteGMROI(Session.sCodEmp, IIf(cmbIdLocacion.SelectedIndex = 0, 0, toNumber(cmbIdLocacion.Value)), cbFecInicio.Value, cbFecFinal.Value, IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Value), 1).Tables(0)
                    DataGridView1.DataSource = dtReporte
                    Dim Export As Boolean = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente")
                    End If
                End If
            ElseIf rbResumenUnidad.Checked Then
                If rbPantalla.Checked = True Then
                    Dim forma As New frmReportes
                    Dim dtReporte As New DataTable
                    oLocacionMercaderiaService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
                    Dim reporte As New rptRepGmroiResUni
                    dtReporte = oLocacionMercaderiaService.ReporteGMROI(Session.sCodEmp, IIf(cmbIdLocacion.SelectedIndex = 0, 0, toNumber(cmbIdLocacion.Value)), cbFecInicio.Value, cbFecFinal.Value, IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Value), 2).Tables(0)
                    'DataGridView2.DataSource = dtReporte
                    If dtReporte.Rows.Count = 0 Then
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

                        reporte.SetParameterValue("pFecInicio", cbFecInicio.Text)
                        reporte.SetParameterValue("pFecFinal", cbFecFinal.Text)
                        reporte.SetParameterValue("pRubro", cmbCodRub.Text)
                        reporte.SetParameterValue("pOficina", cmbOficinas.Text)
                        reporte.SetParameterValue("pAlmacen", cmbIdLocacion.Text)
                        forma.Text = "Reporte de GMROI"
                        forma.ShowDialog()
                    End If
                ElseIf rbExcel.Checked = True Then
                    dtReporte = oLocacionMercaderiaService.ReporteGMROI(Session.sCodEmp, IIf(cmbIdLocacion.SelectedIndex = 0, 0, toNumber(cmbIdLocacion.Value)), cbFecInicio.Value, cbFecFinal.Value, IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Value), 2).Tables(0)
                    DataGridView1.DataSource = dtReporte
                    Dim Export As Boolean = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente")
                    End If
                End If
            ElseIf rbDetalladoxMercaderia.Checked Then
                If rbPantalla.Checked = True Then
                    Dim forma As New frmReportes
                    Dim dtReporte As New DataTable
                    oLocacionMercaderiaService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
                    Dim reporte As New rptRepGmroiDetMer
                    dtReporte = oLocacionMercaderiaService.ReporteGMROI(Session.sCodEmp, IIf(cmbIdLocacion.SelectedIndex = 0, 0, toNumber(cmbIdLocacion.Value)), cbFecInicio.Value, cbFecFinal.Value, IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Value), 3).Tables(0)
                    'DataGridView2.DataSource = dtReporte
                    If dtReporte.Rows.Count = 0 Then
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

                        reporte.SetParameterValue("pFecInicio", cbFecInicio.Text)
                        reporte.SetParameterValue("pFecFinal", cbFecFinal.Text)
                        reporte.SetParameterValue("pRubro", cmbCodRub.Text)
                        reporte.SetParameterValue("pOficina", cmbOficinas.Text)
                        reporte.SetParameterValue("pAlmacen", cmbIdLocacion.Text)
                        forma.Text = "Reporte de GMROI"
                        forma.ShowDialog()
                    End If
                ElseIf rbExcel.Checked = True Then
                    dtReporte = oLocacionMercaderiaService.ReporteGMROI(Session.sCodEmp, IIf(cmbIdLocacion.SelectedIndex = 0, 0, toNumber(cmbIdLocacion.Value)), cbFecInicio.Value, cbFecFinal.Value, IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Value), 3).Tables(0)
                    DataGridView1.DataSource = dtReporte
                    Dim Export As Boolean = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente")
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(270, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class