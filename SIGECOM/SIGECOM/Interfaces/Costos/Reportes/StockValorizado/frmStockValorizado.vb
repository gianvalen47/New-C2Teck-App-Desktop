Imports System.ServiceModel
Public Class frmStockValorizado
    Private ObjCierre As New CierreMesService.CierreMesServiceClient
    Private ObjMaestro As New MaestroService.MaestroClient
    Private ObjLocMerca As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oMaestro As New MaestroService.MaestroClient
    Private oLocacionService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtOficina As New DataTable
    Private dtAlmacen As New DataTable
    'Private IdClase As Integer
    Private dtRubros As DataTable
    Private dtMovimientos As DataTable
    Private oProductoService As New ProductoService.ProductoServiceClient

    Private Sub frmStockValorizado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            cbAlmacen.KeyPress _
            , cbFecha.KeyPress _
            , cbOficina.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmStockValorizado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            ObjCierre.Close()
            ObjMaestro.Close()
            ObjLocMerca.Close()
            oMaestro.Close()
            oLocacionService.Close()
            oSeguridadService.Close()
            oProductoService.Close()
        Catch ex As TimeoutException
            ObjCierre.Abort()
            ObjMaestro.Abort()
            ObjLocMerca.Abort()
            oMaestro.Abort()
            oLocacionService.Abort()
            oSeguridadService.Abort()
            oProductoService.Abort()
        Catch ex As CommunicationException
            ObjCierre.Abort()
            ObjMaestro.Abort()
            ObjLocMerca.Abort()
            oMaestro.Abort()
            oLocacionService.Abort()
            oSeguridadService.Abort()
            oProductoService.Abort()
        End Try
    End Sub

    Private Sub frmStockValorizado_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmStockValorizado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 63)
        '/*************************************************************************************/

        Dim Anio As Integer
        Dim Fecha As Date
        Fecha = Today
        Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        'Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha) - 1)
        'Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
        cbFecha.Value = Fecha

        LlenarCombos()
        If Session.sCodEmp = "03" Then
            Desactivar()
        End If
    End Sub

    Private Sub Desactivar()
        Try
            gbOpciones.Enabled = False
            gbTipoReporte.Enabled = False
            gbExportar.Enabled = False
            ckLibro.Enabled = False
            gbTipStock.Enabled = False
            gbAgrupacion.Enabled = False
        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub Finalizar()
    '    Try
    '        ObjCierre.Close()
    '        ObjMaestro.Close()

    '    Catch ex As TimeoutException
    '        ObjCierre.Abort()
    '        ObjMaestro.Abort()
    '    Catch ex As CommunicationException
    '        ObjCierre.Abort()
    '        ObjMaestro.Abort()

    '    End Try
    '    Me.Dispose(True)
    '    GC.SuppressFinalize(Me)
    'End Sub

    Private Sub LlenarCombos()
        Try

            '====================================== OFICINAS ================================================
            dtOficina = ObjMaestro.MostrarOficinasEmpresa(Session.sCodEmp, Session.sCodUsu).Tables(0)
            dtOficina.Rows.InsertAt(getRowTodos(dtOficina), 0)
            cbOficina.DataSource = dtOficina
            cbOficina.DisplayMember = "DesOfi"
            cbOficina.ValueMember = "CodOfi"
            cbOficina.DropDownList.Columns(0).DataMember = "CodOfi"
            cbOficina.DropDownList.Columns(1).DataMember = "DesOfi"
            cbOficina.SelectedIndex = 0
            dtOficina = Nothing

            '======================================= RUBROS ================================================
            dtRubros = oProductoService.MostrarRubrosEmpresa(Session.sCodEmp).Tables(0)
            dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
            cmbCodRub.DataSource = dtRubros
            cmbCodRub.DropDownList.DataMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.DropDownList.DisplayMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.DropDownList.ValueMember = dtRubros.Columns("CodRub").ToString
            cmbCodRub.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRub").ToString
            cmbCodRub.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.SelectedIndex = 0
            dtRubros = Nothing

            '======================================= MOVIMIENTOS ===============================================
            dtMovimientos = oMaestro.MostrarMovimiento.Tables(0)
            dtMovimientos.Rows.InsertAt(getRowTodos(dtMovimientos), 0)
            cmbCodMov.DataSource = dtMovimientos
            cmbCodMov.DropDownList.DataMember = dtMovimientos.Columns("DesMov").ToString
            cmbCodMov.DropDownList.DisplayMember = dtMovimientos.Columns("DesMov").ToString
            cmbCodMov.DropDownList.ValueMember = dtMovimientos.Columns("CodMov").ToString
            cmbCodMov.DropDownList.Columns(0).DataMember = dtMovimientos.Columns("CodMov").ToString
            cmbCodMov.DropDownList.Columns(1).DataMember = dtMovimientos.Columns("DesMov").ToString
            cmbCodMov.SelectedIndex = 0
            dtMovimientos = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Sub cbOficina_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOficina.ValueChanged
        Try
            dtAlmacen = ObjMaestro.MostrarLocaciones(Session.sCodEmp, cbOficina.Value, Session.sCodUsu).Tables(0)
            dtAlmacen.Rows.InsertAt(getRowTodos(dtAlmacen), 0)
            cbAlmacen.DataSource = dtAlmacen
            cbAlmacen.DisplayMember = "DesAlm"
            cbAlmacen.ValueMember = "IdLocacion"
            cbAlmacen.DropDownList.Columns(0).DataMember = "CodAlm"
            cbAlmacen.DropDownList.Columns(1).DataMember = "DesAlm"
            'cbAlmacen.SelectedIndex = 0
            If dtAlmacen.Rows.Count > 0 Then
                cbAlmacen.SelectedIndex = 0
            Else
                cbAlmacen.Value = ""
            End If
            dtAlmacen = Nothing
        Catch ex As Exception
            MsgBox("Error al Cargar Almacenes", MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    'Private Sub txtIdClase_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdClase.ButtonClick
    '    Dim frm As New frmBuscarClase
    '    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '        If toNull(frm.codigo) <> Nothing Then
    '            txtIdClase.Text = frm.descripcion
    '            IdClase = frm.codigo
    '        End If
    '        'listaDatos()
    '    End If
    'End Sub
    Private Function getRowTodos(ByVal data As DataTable)
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

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim dtStockValorizado As New DataView
            Dim dtClase As New DataTable
            Dim mifecha As Date
            Dim mifecharestada As Date
            Dim forma As New frmReportes

            oSeguridadService.RegistrarVisitaOpciones(63, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            If Session.sCodEmp = "03" Then

                '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '---------------------------------------------------------------------------- CAIRO -------------------------------------------------------------------------------
                '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                If utils.toNumber(cbAlmacen.Value) = 0 Then
                    MsgBox("Debe Seleccionar un Almacén", MsgBoxStyle.Information, "Seleccionar")
                Else
                    ObjCierre.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(60)
                    dtStockValorizado = ObjCierre.StockValorizado(Session.sCodEmp, toNumber(cbAlmacen.Value), cbFecha.Value, cmbCodRub.Value, IIf(cmbCodMov.Text = "(Todos)", "", cmbCodMov.Value)).Tables(0).DefaultView
                    Dim reporte As New rpStockValorizadoCairo

                    reporte.SetDataSource(dtStockValorizado)
                    forma.crvReportes.ReportSource = reporte

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    reporte.SetParameterValue("Fecha", cbFecha.Value)
                    reporte.SetParameterValue("pOficina", cbOficina.Text)
                    reporte.SetParameterValue("pAlmacen", cbAlmacen.Text)

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Registro de Inventario Permanente Valorizado"
                    forma.ShowDialog()

                End If


            Else
                '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '------------------------------------------------------------------- OTRAS EMPRESAS --------------------------------------------------------------------
                '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                If rbDetalle.Checked And utils.toNumber(cbAlmacen.Value) = 0 Then
                    MsgBox("Debe Seleccionar un Almacén", MsgBoxStyle.Information, "Seleccionar")
                    'ElseIf rbDetalle.Checked And rbSaldoInicio.Checked And utils.toNumber(cbAlmacen.Value) = 0 Then
                    '    MsgBox("Debe Seleccionar un Almacen", MsgBoxStyle.Information, "Seleccionar")
                Else
                    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    '=============================== REPORTE GERENCIAL ==================================
                    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

                    '***************************************** Agregado el 22/02/2012 (Percy Brown) **********************************************
                    If rbGerencial.Checked Then
                        '----------------------------------------------------------PANTALLA--------------------------------------------------------------------
                        If rbPantalla.Checked Then
                            Dim reporte As New rpStockGerencial
                            Dim dtReporte As New DataTable
                            Dim dtSubreporte As DataTable

                            'dtSubreporte = ObjLocMerca.ReporteGerencialInventarios(Session.sCodEmp, "", cbFecha.Value, cbFecha.Value, 0, 4).Tables(0)
                            'dtSubreporte = ObjLocMerca.ReporteGerencialInventarios(Session.sCodEmp, "", cbFecha.Value, cbFecha.Value, 0, 5).Tables(0)
                            'DataGridView1.DataSource = dtSubreporte
                            ObjLocMerca.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(60)
                            dtReporte = ObjLocMerca.ReporteGerencialInventarios(Session.sCodEmp, "", cbFecha.Value, cbFecha.Value, 0, 4).Tables(0)
                            dtSubreporte = ObjLocMerca.ReporteGerencialInventarios(Session.sCodEmp, "", cbFecha.Value, cbFecha.Value, 0, 5).Tables(0)
                            dgvGerencial.DataSource = dtReporte

                            '//Hallamos el Costo de Dolares Total del Reporte para calcular el porcentaje en el cuadro resumido del reporte//
                            Dim TotalDolares As Double = 0
                            If dgvGerencial.RowCount <> 0 Then
                                For i As Integer = 0 To dgvGerencial.RowCount - 1
                                    If Not (IsDBNull(dgvGerencial.Item("CostoDolares".ToLower, i).Value)) Then
                                        TotalDolares = TotalDolares + CDbl(dgvGerencial.Item("CostoDolares".ToLower, i).Value)
                                    End If
                                Next
                            End If
                            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                            If reporte.Subreports.Count > 0 Then
                                reporte.Subreports(0).SetDataSource(dtSubreporte)
                            End If

                            reporte.SetDataSource(dtReporte)
                            reporte.SetParameterValue("pTotalDolares", TotalDolares)
                            forma.crvReportes.ReportSource = reporte

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            forma.Text = "Reporte de Stock Valorizado"
                            forma.ShowDialog()

                            '-------------------------------------------------------- EXPORTAR ---------------------------------------------------------------------

                        Else
                            Dim Export As Boolean
                            Dim dataset1 As DataSet
                            'Dim myColumn As DataColumn
                            ObjLocMerca.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(60)
                            dataset1 = ObjLocMerca.ReporteGerencialInventarios(Session.sCodEmp, "", cbFecha.Value, cbFecha.Value, 0, 4)
                            dataset1.Tables(0).Columns.Remove("CodEmp")
                            dataset1.Tables(0).Columns.Remove("DesEmp")
                            dataset1.Tables(0).Columns.Remove("RucEmp")
                            dataset1.Tables(0).Columns.Remove("CodOfi")
                            dataset1.Tables(0).Columns.Remove("CodAlm")
                            dataset1.Tables(0).Columns.Remove("CodRub")
                            dgvGerencial.DataSource = dataset1.Tables(0)
                            Export = ExportarExcel(dgvGerencial)
                            If Export Then
                                MsgBox("Se realizó la exportación correctamente")
                            End If
                        End If
                        '**************************************************************************************************************************************
                    Else
                        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                        '========================== REPORTE DETALLE Ó TOTAL GENERAL RESUMEN===========================
                        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                        '----------------------------------------------------------------------------
                        '/// OPCIÓN : STOCK A LA FECHA -----------------------------------------------
                        '----------------------------------------------------------------------------

                        If rbStockFecha.Checked Then
                            ObjCierre.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(60)
                            dtStockValorizado = ObjCierre.StockValorizado(Session.sCodEmp, IIf(rbTotalGeneralAnt.Checked, 0, cbAlmacen.Value), cbFecha.Value, cmbCodRub.Value, IIf(cmbCodMov.Text = "(Todos)", "", cmbCodMov.Value)).Tables(0).DefaultView

                            If rbDetalle.Checked Then
                                '---------------------------------------- Por Rubro ----------------------------------------------
                                If rbPorRubros.Checked Then

                                    If ckLibro.Checked Then

                                        Dim reporte As New rpStockValorizadoLibro

                                        If rbSinCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock <> 0"
                                        ElseIf rbPositivos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock > 0"
                                        ElseIf rbNegativos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock < 0"
                                        ElseIf rbCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock = 0"
                                        End If

                                        reporte.SetDataSource(dtStockValorizado)
                                        forma.crvReportes.ReportSource = reporte

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                        reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("movimiento", cmbCodMov.Text)

                                    Else
                                        Dim reporte As New rpStockValorizado
                                        If rbSinCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock <> 0"
                                        ElseIf rbPositivos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock > 0"
                                        ElseIf rbNegativos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock < 0"
                                        ElseIf rbCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock = 0"
                                        End If
                                        reporte.SetDataSource(dtStockValorizado)
                                        forma.crvReportes.ReportSource = reporte

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                        reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("movimiento", cmbCodMov.Text)
                                    End If
                                    '-------------------------------------------------Por Clase ----------------------------------------
                                ElseIf rbPorClase.Checked Then

                                    If ckLibro.Checked Then

                                        Dim reporte As New rpStockValorizadoLibroPorClase

                                        If rbSinCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock <> 0"
                                        ElseIf rbPositivos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock > 0"
                                        ElseIf rbNegativos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock < 0"
                                        ElseIf rbCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock = 0"
                                        End If
                                        reporte.SetDataSource(dtStockValorizado)
                                        forma.crvReportes.ReportSource = reporte

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                        'reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("movimiento", cmbCodMov.Text)

                                    Else
                                        Dim reporte As New rpStockValorizadoPorClase
                                        If rbSinCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock <> 0"
                                        ElseIf rbPositivos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock > 0"
                                        ElseIf rbNegativos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock < 0"
                                        ElseIf rbCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock = 0"
                                        End If
                                        reporte.SetDataSource(dtStockValorizado)
                                        forma.crvReportes.ReportSource = reporte

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                        reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("movimiento", cmbCodMov.Text)
                                    End If
                                    '-------------------------------------------------Por Marca ------------------------------------------------------
                                ElseIf rbPorMarca.Checked Then

                                    If ckLibro.Checked Then
                                        Dim reporte As New rpStockValorizadoLibroPorMarca
                                        If rbSinCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock <> 0"
                                        ElseIf rbPositivos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock > 0"
                                        ElseIf rbNegativos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock < 0"
                                        ElseIf rbCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock = 0"
                                        End If
                                        reporte.SetDataSource(dtStockValorizado)
                                        forma.crvReportes.ReportSource = reporte

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                        reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("movimiento", cmbCodMov.Text)

                                    Else
                                        Dim reporte As New rpStockValorizadoPorMarca
                                        If rbSinCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock <> 0"
                                        ElseIf rbPositivos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock > 0"
                                        ElseIf rbNegativos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock < 0"
                                        ElseIf rbCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock = 0"
                                        End If
                                        reporte.SetDataSource(dtStockValorizado)
                                        forma.crvReportes.ReportSource = reporte

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                        reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("movimiento", cmbCodMov.Text)
                                    End If
                                    '-------------------------------------------------Por Proveedor ------------------------------------------------------
                                ElseIf rbPorProveedor.Checked Then

                                    If ckLibro.Checked Then

                                        Dim reporte As New rpStockValorizadoLibroPorProveedor

                                        If rbSinCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock <> 0"
                                        ElseIf rbPositivos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock > 0"
                                        ElseIf rbNegativos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock < 0"
                                        ElseIf rbCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock = 0"
                                        End If
                                        reporte.SetDataSource(dtStockValorizado)
                                        forma.crvReportes.ReportSource = reporte

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                        reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("movimiento", cmbCodMov.Text)
                                    Else
                                        Dim reporte As New rpStockValorizadoPorProveedor
                                        If rbSinCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock <> 0"
                                        ElseIf rbPositivos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock > 0"
                                        ElseIf rbNegativos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock < 0"
                                        ElseIf rbCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock = 0"
                                        End If
                                        reporte.SetDataSource(dtStockValorizado)
                                        forma.crvReportes.ReportSource = reporte

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                        reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("movimiento", cmbCodMov.Text)
                                    End If

                                End If

                                '======================================== Tipo Reporte : Reporte Detallado =============================================
                            ElseIf rbRepTotalGeneral.Checked Then
                                Dim reporte As New rpStockValorizadoDetalle
                                If rbSinCeros.Checked Then
                                    dtStockValorizado.RowFilter = "Stock <> 0"
                                ElseIf rbPositivos.Checked Then
                                    dtStockValorizado.RowFilter = "Stock > 0"
                                ElseIf rbNegativos.Checked Then
                                    dtStockValorizado.RowFilter = "Stock < 0"
                                ElseIf rbCeros.Checked Then
                                    dtStockValorizado.RowFilter = "Stock = 0"
                                End If
                                reporte.SetDataSource(dtStockValorizado)
                                forma.crvReportes.ReportSource = reporte

                                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                    forma.crvReportes.ShowExportButton = True
                                Else
                                    forma.crvReportes.ShowExportButton = False
                                End If
                                'forma.crvReportes.RefreshReport = False
                                'forma.crvReportes.DisplayGroupTree = False

                                reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                reporte.SetParameterValue("Rubro", IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Text))
                                reporte.SetParameterValue("Movimiento", IIf(cmbCodMov.Text = "(Todos)", "", cmbCodMov.Text))

                                'reporte.SetParameterValue("rubro", cmbCodRub.Text)

                                '======================================== Tipo Reporte : Reporte Resumen =============================================
                            ElseIf rbRepResumen.Checked Then
                                Dim reporte As New rpStockValorizadoResumen
                                If rbSinCeros.Checked Then
                                    dtStockValorizado.RowFilter = "Stock <> 0"
                                ElseIf rbPositivos.Checked Then
                                    dtStockValorizado.RowFilter = "Stock > 0"
                                ElseIf rbNegativos.Checked Then
                                    dtStockValorizado.RowFilter = "Stock < 0"
                                ElseIf rbCeros.Checked Then
                                    dtStockValorizado.RowFilter = "Stock = 0"
                                End If
                                reporte.SetDataSource(dtStockValorizado)
                                forma.crvReportes.ReportSource = reporte

                                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                    forma.crvReportes.ShowExportButton = True
                                Else
                                    forma.crvReportes.ShowExportButton = False
                                End If
                                'forma.crvReportes.RefreshReport = False
                                'forma.crvReportes.DisplayGroupTree = False

                                reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                reporte.SetParameterValue("Rubro", IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Text))
                                reporte.SetParameterValue("Movimiento", IIf(cmbCodMov.Text = "(Todos)", "", cmbCodMov.Text))

                                '======================================== Tipo Reporte : Total General =============================================
                            ElseIf rbTotalGeneralAnt.Checked Then
                                Dim reporte As New rpStockValorizadoGeneral
                                If rbSinCeros.Checked Then
                                    dtStockValorizado.RowFilter = "Stock <> 0"
                                ElseIf rbPositivos.Checked Then
                                    dtStockValorizado.RowFilter = "Stock > 0"
                                ElseIf rbNegativos.Checked Then
                                    dtStockValorizado.RowFilter = "Stock < 0"
                                ElseIf rbCeros.Checked Then
                                    dtStockValorizado.RowFilter = "Stock = 0"
                                End If
                                reporte.SetDataSource(dtStockValorizado)
                                forma.crvReportes.ReportSource = reporte

                                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                    forma.crvReportes.ShowExportButton = True
                                Else
                                    forma.crvReportes.ShowExportButton = False
                                End If
                                'forma.crvReportes.RefreshReport = False
                                'forma.crvReportes.DisplayGroupTree = False

                                reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                reporte.SetParameterValue("Rubro", IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Text))
                                reporte.SetParameterValue("Movimiento", IIf(cmbCodMov.Text = "(Todos)", "", cmbCodMov.Text))

                                '======================================== Tipo Reporte : Indicadores =============================================
                            ElseIf rbIndicadores.Checked Then

                                Dim reporte As New rpStockValorizadoGenIndicador
                                If rbSinCeros.Checked Then
                                    dtStockValorizado.RowFilter = "Stock <> 0"
                                ElseIf rbPositivos.Checked Then
                                    dtStockValorizado.RowFilter = "Stock > 0"
                                ElseIf rbNegativos.Checked Then
                                    dtStockValorizado.RowFilter = "Stock < 0"
                                ElseIf rbCeros.Checked Then
                                    dtStockValorizado.RowFilter = "Stock = 0"
                                End If

                                Dim DiasTrans As Integer
                                Dim I1 As Double
                                Dim CV As Double

                                oLocacionService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(60)
                                If rbStockFecha.Checked Then
                                    DiasTrans = DateDiff(DateInterval.Day, CDate("01/01/" + utils.toBlank(Year(cbFecha.Value))), cbFecha.Value)
                                    I1 = oLocacionService.ObtenerSaldoInicio(Session.sCodEmp, CDate("01/01/" + utils.toBlank(Year(Today))))
                                    CV = oLocacionService.ObtenerCostoVenta(Session.sCodEmp, cbFecha.Value, "NS")
                                ElseIf rbStockActual.Checked Then
                                    DiasTrans = DateDiff(DateInterval.Day, CDate("01/01/" + utils.toBlank(Year(Today))), Today.Date)
                                    I1 = oLocacionService.ObtenerSaldoInicio(Session.sCodEmp, CDate("01/01/" + utils.toBlank(Year(Today))))
                                    CV = oLocacionService.ObtenerCostoVenta(Session.sCodEmp, Today.Date, "NS")
                                ElseIf rbSaldoInicio.Checked Then
                                    DiasTrans = DateDiff(DateInterval.Day, CDate("01/01/" + utils.toBlank(Year(Today))), Today.Date)
                                    I1 = oLocacionService.ObtenerSaldoInicio(Session.sCodEmp, CDate("01/01/" + utils.toBlank(Year(Today))))
                                    CV = oLocacionService.ObtenerCostoVenta(Session.sCodEmp, Today.Date, "NS")
                                End If
                                'DiasTrans = DateDiff(DateInterval.Day, CDate("01/01/" + utils.toBlank(Year(Today))), Today.Date)
                                'I1 = oLocacionService.ObtenerSaldoInicio(Session.sCodEmp, CDate("01/01/" + utils.toBlank(Year(Today))))
                                'CV = oLocacionService.ObtenerCostoVenta(Session.sCodEmp, Today.Date, "NS")


                                reporte.SetDataSource(dtStockValorizado)
                                forma.crvReportes.ReportSource = reporte

                                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                    forma.crvReportes.ShowExportButton = True
                                Else
                                    forma.crvReportes.ShowExportButton = False
                                End If
                                'forma.crvReportes.RefreshReport = False
                                'forma.crvReportes.DisplayGroupTree = False

                                reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                'reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                reporte.SetParameterValue("D", DiasTrans)
                                reporte.SetParameterValue("CV", CV)
                                reporte.SetParameterValue("I1", I1)

                            End If
                            '----------------------------------------------------------------------------
                            '/// OPCIÓN : SALDO DE INICIO -----------------------------------------------
                            '----------------------------------------------------------------------------
                        ElseIf rbSaldoInicio.Checked Then
                            ObjCierre.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(60)
                            dtStockValorizado = ObjCierre.MostrarSaldoInicio(Session.sCodEmp, IIf(rbTotalGeneralAnt.Checked, 0, cbAlmacen.Value), cbFecha.Value, cmbCodRub.Value, cmbCodMov.Value).Tables(0).DefaultView
                            'dgvGerencial.DataSource = dtStockValorizado
                            'Restando fechas
                            mifecha = cbFecha.Text
                            mifecharestada = DateAdd(DateInterval.Day, -1, mifecha)
                            'MessageBox.Show("Fecha " & mifecharestada)
                            If rbDetalle.Checked Then
                                '---------------------------------------- Por Rubro ----------------------------------------------
                                If rbPorRubros.Checked Then

                                    If ckLibro.Checked Then
                                        Dim reporte As New rpStockValorizadoLibro
                                        If rbSinCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock <> 0"
                                        ElseIf rbPositivos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock > 0"
                                        ElseIf rbNegativos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock < 0"
                                        ElseIf rbCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock = 0"
                                        End If
                                        reporte.SetDataSource(dtStockValorizado)
                                        forma.crvReportes.ReportSource = reporte

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, mifecharestada))
                                        reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("movimiento", cmbCodMov.Text)
                                    Else
                                        Dim reporte As New rpStockValorizado
                                        If rbSinCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock <> 0"
                                        ElseIf rbPositivos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock > 0"
                                        ElseIf rbNegativos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock < 0"
                                        ElseIf rbCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock = 0"
                                        End If
                                        reporte.SetDataSource(dtStockValorizado)
                                        forma.crvReportes.ReportSource = reporte

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, mifecharestada))
                                        reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("movimiento", cmbCodMov.Text)
                                    End If
                                    '-------------------------------------------------Por Clase ----------------------------------------
                                ElseIf rbPorClase.Checked Then

                                    If ckLibro.Checked Then
                                        Dim reporte As New rpStockValorizadoLibroPorClase
                                        If rbSinCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock <> 0"
                                        ElseIf rbPositivos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock > 0"
                                        ElseIf rbNegativos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock < 0"
                                        ElseIf rbCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock = 0"
                                        End If
                                        reporte.SetDataSource(dtStockValorizado)
                                        forma.crvReportes.ReportSource = reporte

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, mifecharestada))
                                        reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("movimiento", cmbCodMov.Text)
                                    Else
                                        Dim reporte As New rpStockValorizadoPorClase
                                        If rbSinCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock <> 0"
                                        ElseIf rbPositivos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock > 0"
                                        ElseIf rbNegativos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock < 0"
                                        ElseIf rbCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock = 0"
                                        End If
                                        reporte.SetDataSource(dtStockValorizado)
                                        forma.crvReportes.ReportSource = reporte

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, mifecharestada))
                                        reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("movimiento", cmbCodMov.Text)
                                    End If
                                ElseIf rbPorMarca.Checked Then

                                    If ckLibro.Checked Then
                                        Dim reporte As New rpStockValorizadoLibroPorMarca
                                        If rbSinCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock <> 0"
                                        ElseIf rbPositivos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock > 0"
                                        ElseIf rbNegativos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock < 0"
                                        ElseIf rbCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock = 0"
                                        End If
                                        reporte.SetDataSource(dtStockValorizado)
                                        forma.crvReportes.ReportSource = reporte

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, mifecharestada))
                                        reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("movimiento", cmbCodMov.Text)
                                    Else
                                        Dim reporte As New rpStockValorizadoPorClase
                                        If rbSinCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock <> 0"
                                        ElseIf rbPositivos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock > 0"
                                        ElseIf rbNegativos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock < 0"
                                        ElseIf rbCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock = 0"
                                        End If
                                        reporte.SetDataSource(dtStockValorizado)
                                        forma.crvReportes.ReportSource = reporte

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, mifecharestada))
                                        reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("movimiento", cmbCodMov.Text)
                                    End If

                                    '-------------------------------------------------Por Proveedor ----------------------------------------
                                ElseIf rbPorProveedor.Checked Then

                                    If ckLibro.Checked Then
                                        Dim reporte As New rpStockValorizadoLibroPorProveedor
                                        If rbSinCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock <> 0"
                                        ElseIf rbPositivos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock > 0"
                                        ElseIf rbNegativos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock < 0"
                                        ElseIf rbCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock = 0"
                                        End If
                                        reporte.SetDataSource(dtStockValorizado)
                                        forma.crvReportes.ReportSource = reporte

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, mifecharestada))
                                        reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("movimiento", cmbCodMov.Text)
                                    Else
                                        Dim reporte As New rpStockValorizadoPorProveedor
                                        If rbSinCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock <> 0"
                                        ElseIf rbPositivos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock > 0"
                                        ElseIf rbNegativos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock < 0"
                                        ElseIf rbCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock = 0"
                                        End If
                                        reporte.SetDataSource(dtStockValorizado)
                                        forma.crvReportes.ReportSource = reporte

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, mifecharestada))
                                        reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("movimiento", cmbCodMov.Text)
                                    End If

                                End If

                                '======================================== Tipo Reporte : Total Detallado =============================================
                            ElseIf rbRepTotalGeneral.Checked Then
                                Dim reporte As New rpStockValorizadoDetalle
                                If rbSinCeros.Checked Then
                                    dtStockValorizado.RowFilter = "Stock <> 0"
                                ElseIf rbPositivos.Checked Then
                                    dtStockValorizado.RowFilter = "Stock > 0"
                                ElseIf rbNegativos.Checked Then
                                    dtStockValorizado.RowFilter = "Stock < 0"
                                ElseIf rbCeros.Checked Then
                                    dtStockValorizado.RowFilter = "Stock = 0"
                                End If
                                reporte.SetDataSource(dtStockValorizado)
                                forma.crvReportes.ReportSource = reporte

                                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                    forma.crvReportes.ShowExportButton = True
                                Else
                                    forma.crvReportes.ShowExportButton = False
                                End If
                                'forma.crvReportes.RefreshReport = False
                                'forma.crvReportes.DisplayGroupTree = False

                                reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, mifecharestada))
                                reporte.SetParameterValue("Rubro", IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Text))
                                reporte.SetParameterValue("Movimiento", IIf(cmbCodMov.Text = "(Todos)", "", cmbCodMov.Text))

                                'reporte.SetParameterValue("rubro", cmbCodRub.Text)

                                '======================================== Tipo Reporte : Total Resumen =============================================
                            ElseIf rbRepResumen.Checked Then
                                Dim reporte As New rpStockValorizadoResumen
                                If rbSinCeros.Checked Then
                                    dtStockValorizado.RowFilter = "Stock <> 0"
                                ElseIf rbPositivos.Checked Then
                                    dtStockValorizado.RowFilter = "Stock > 0"
                                ElseIf rbNegativos.Checked Then
                                    dtStockValorizado.RowFilter = "Stock < 0"
                                ElseIf rbCeros.Checked Then
                                    dtStockValorizado.RowFilter = "Stock = 0"
                                End If
                                reporte.SetDataSource(dtStockValorizado)
                                forma.crvReportes.ReportSource = reporte

                                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                    forma.crvReportes.ShowExportButton = True
                                Else
                                    forma.crvReportes.ShowExportButton = False
                                End If
                                'forma.crvReportes.RefreshReport = False
                                'forma.crvReportes.DisplayGroupTree = False

                                reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, mifecharestada))
                                reporte.SetParameterValue("Rubro", IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Text))
                                reporte.SetParameterValue("Movimiento", IIf(cmbCodMov.Text = "(Todos)", "", cmbCodMov.Text))

                                'reporte.SetParameterValue("rubro", cmbCodRub.Text)

                                '======================================== Tipo Reporte : Total General =============================================
                            ElseIf rbTotalGeneralAnt.Checked Then
                                Dim reporte As New rpStockValorizadoGeneral
                                If rbSinCeros.Checked Then
                                    dtStockValorizado.RowFilter = "Stock <> 0"
                                ElseIf rbPositivos.Checked Then
                                    dtStockValorizado.RowFilter = "Stock > 0"
                                ElseIf rbNegativos.Checked Then
                                    dtStockValorizado.RowFilter = "Stock < 0"
                                ElseIf rbCeros.Checked Then
                                    dtStockValorizado.RowFilter = "Stock = 0"
                                End If
                                reporte.SetDataSource(dtStockValorizado)
                                forma.crvReportes.ReportSource = reporte

                                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                    forma.crvReportes.ShowExportButton = True
                                Else
                                    forma.crvReportes.ShowExportButton = False
                                End If
                                'forma.crvReportes.RefreshReport = False
                                'forma.crvReportes.DisplayGroupTree = False

                                reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, mifecharestada))
                                reporte.SetParameterValue("Rubro", IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Text))
                                reporte.SetParameterValue("Movimiento", IIf(cmbCodMov.Text = "(Todos)", "", cmbCodMov.Text))

                                'reporte.SetParameterValue("rubro", cmbCodRub.Text)

                                '======================================== Tipo Reporte : Indicadores =============================================
                            ElseIf rbIndicadores.Checked Then

                                Dim reporte As New rpStockValorizadoGenIndicador
                                If rbSinCeros.Checked Then
                                    dtStockValorizado.RowFilter = "Stock <> 0"
                                ElseIf rbPositivos.Checked Then
                                    dtStockValorizado.RowFilter = "Stock > 0"
                                ElseIf rbNegativos.Checked Then
                                    dtStockValorizado.RowFilter = "Stock < 0"
                                ElseIf rbCeros.Checked Then
                                    dtStockValorizado.RowFilter = "Stock = 0"
                                End If

                                Dim DiasTrans As Integer
                                Dim I1 As Double
                                Dim CV As Double

                                oLocacionService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(60)
                                If rbStockFecha.Checked Then
                                    DiasTrans = DateDiff(DateInterval.Day, CDate("01/01/" + utils.toBlank(Year(cbFecha.Value))), cbFecha.Value)
                                    I1 = oLocacionService.ObtenerSaldoInicio(Session.sCodEmp, CDate("01/01/" + utils.toBlank(Year(Today))))
                                    CV = oLocacionService.ObtenerCostoVenta(Session.sCodEmp, cbFecha.Value, "NS")
                                ElseIf rbStockActual.Checked Then
                                    DiasTrans = DateDiff(DateInterval.Day, CDate("01/01/" + utils.toBlank(Year(Today))), Today.Date)
                                    I1 = oLocacionService.ObtenerSaldoInicio(Session.sCodEmp, CDate("01/01/" + utils.toBlank(Year(Today))))
                                    CV = oLocacionService.ObtenerCostoVenta(Session.sCodEmp, Today.Date, "NS")
                                ElseIf rbSaldoInicio.Checked Then
                                    DiasTrans = DateDiff(DateInterval.Day, CDate("01/01/" + utils.toBlank(Year(Today))), Today.Date)
                                    I1 = oLocacionService.ObtenerSaldoInicio(Session.sCodEmp, CDate("01/01/" + utils.toBlank(Year(Today))))
                                    CV = oLocacionService.ObtenerCostoVenta(Session.sCodEmp, Today.Date, "NS")
                                End If
                                'DiasTrans = DateDiff(DateInterval.Day, CDate("01/01/" + utils.toBlank(Year(Today))), Today.Date)
                                'I1 = oLocacionService.ObtenerSaldoInicio(Session.sCodEmp, CDate("01/01/" + utils.toBlank(Year(Today))))
                                'CV = oLocacionService.ObtenerCostoVenta(Session.sCodEmp, Today.Date, "NS")


                                reporte.SetDataSource(dtStockValorizado)
                                forma.crvReportes.ReportSource = reporte

                                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                    forma.crvReportes.ShowExportButton = True
                                Else
                                    forma.crvReportes.ShowExportButton = False
                                End If
                                'forma.crvReportes.RefreshReport = False
                                'forma.crvReportes.DisplayGroupTree = False

                                reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                'reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                reporte.SetParameterValue("D", DiasTrans)
                                reporte.SetParameterValue("CV", CV)
                                reporte.SetParameterValue("I1", I1)

                            End If
                            '----------------------------------------------------------------------------
                            '/// OPCIÓN : STOCK ACTUAL -----------------------------------------------
                            '----------------------------------------------------------------------------
                        ElseIf rbStockActual.Checked Then
                            ObjLocMerca.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(60)
                            dtStockValorizado = ObjLocMerca.Mostrar(Session.sCodEmp, IIf(rbTotalGeneralAnt.Checked, 0, cbAlmacen.Value), cmbCodRub.Value, cmbCodMov.Value).Tables(0).DefaultView
                            'dgvGerencial.DataSource = dtStockValorizado
                            If rbDetalle.Checked Then
                                '---------------------------------------- Por Rubro ----------------------------------------------
                                If rbPorRubros.Checked Then
                                    If ckLibro.Checked Then
                                        Dim reporte As New rpStockValorizadoLibro
                                        If rbSinCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock <> 0"
                                        ElseIf rbPositivos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock > 0"
                                        ElseIf rbNegativos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock < 0"
                                        ElseIf rbCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock = 0"
                                        End If
                                        reporte.SetDataSource(dtStockValorizado)
                                        forma.crvReportes.ReportSource = reporte

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                        reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("movimiento", cmbCodMov.Text)
                                    Else
                                        Dim reporte As New rpStockValorizado
                                        If rbSinCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock <> 0"
                                        ElseIf rbPositivos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock > 0"
                                        ElseIf rbNegativos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock < 0"
                                        ElseIf rbCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock = 0"
                                        End If
                                        reporte.SetDataSource(dtStockValorizado)
                                        forma.crvReportes.ReportSource = reporte

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                        reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("movimiento", cmbCodMov.Text)
                                    End If
                                    '-------------------------------------------------Por Clase ----------------------------------------
                                ElseIf rbPorClase.Checked Then
                                    If ckLibro.Checked Then
                                        Dim reporte As New rpStockValorizadoLibroPorClase
                                        If rbSinCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock <> 0"
                                        ElseIf rbPositivos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock > 0"
                                        ElseIf rbNegativos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock < 0"
                                        ElseIf rbCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock = 0"
                                        End If
                                        reporte.SetDataSource(dtStockValorizado)
                                        forma.crvReportes.ReportSource = reporte

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                        reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("movimiento", cmbCodMov.Text)
                                    Else
                                        Dim reporte As New rpStockValorizadoPorClase
                                        If rbSinCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock <> 0"
                                        ElseIf rbPositivos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock > 0"
                                        ElseIf rbNegativos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock < 0"
                                        ElseIf rbCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock = 0"
                                        End If
                                        reporte.SetDataSource(dtStockValorizado)
                                        forma.crvReportes.ReportSource = reporte

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                        reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("movimiento", cmbCodMov.Text)
                                    End If
                                    '-------------------------------------------------Por Marca ------------------------------------------------------
                                ElseIf rbPorMarca.Checked Then
                                    If ckLibro.Checked Then
                                        Dim reporte As New rpStockValorizadoLibroPorMarca
                                        If rbSinCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock <> 0"
                                        ElseIf rbPositivos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock > 0"
                                        ElseIf rbNegativos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock < 0"
                                        ElseIf rbCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock = 0"
                                        End If
                                        reporte.SetDataSource(dtStockValorizado)
                                        forma.crvReportes.ReportSource = reporte

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                        reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("movimiento", cmbCodMov.Text)
                                    Else
                                        Dim reporte As New rpStockValorizadoPorMarca
                                        If rbSinCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock <> 0"
                                        ElseIf rbPositivos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock > 0"
                                        ElseIf rbNegativos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock < 0"
                                        ElseIf rbCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock = 0"
                                        End If
                                        reporte.SetDataSource(dtStockValorizado)
                                        forma.crvReportes.ReportSource = reporte

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                        reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("movimiento", cmbCodMov.Text)
                                    End If
                                    '-------------------------------------------------Por Proveedor ------------------------------------------------------
                                ElseIf rbPorProveedor.Checked Then

                                    If ckLibro.Checked Then
                                        Dim reporte As New rpStockValorizadoLibroPorProveedor
                                        If rbSinCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock <>0"
                                        ElseIf rbPositivos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock > 0"
                                        ElseIf rbNegativos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock < 0"
                                        ElseIf rbCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock = 0"
                                        End If
                                        reporte.SetDataSource(dtStockValorizado)
                                        forma.crvReportes.ReportSource = reporte

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                        'reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("movimiento", cmbCodMov.Text)
                                    Else
                                        Dim reporte As New rpStockValorizadoPorProveedor
                                        If rbSinCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock <> 0"
                                        ElseIf rbPositivos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock > 0"
                                        ElseIf rbNegativos.Checked Then
                                            dtStockValorizado.RowFilter = "Stock < 0"
                                        ElseIf rbCeros.Checked Then
                                            dtStockValorizado.RowFilter = "Stock = 0"
                                        End If
                                        reporte.SetDataSource(dtStockValorizado)
                                        forma.crvReportes.ReportSource = reporte

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                        reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                        reporte.SetParameterValue("movimiento", cmbCodMov.Text)
                                    End If

                                End If
                                '======================================== Tipo Reporte : Total Detalle =============================================
                            ElseIf rbRepTotalGeneral.Checked Then
                                Dim reporte As New rpStockValorizadoDetalle
                                If rbSinCeros.Checked Then
                                    dtStockValorizado.RowFilter = "Stock <> 0"
                                ElseIf rbPositivos.Checked Then
                                    dtStockValorizado.RowFilter = "Stock > 0"
                                ElseIf rbNegativos.Checked Then
                                    dtStockValorizado.RowFilter = "Stock < 0"
                                ElseIf rbCeros.Checked Then
                                    dtStockValorizado.RowFilter = "Stock = 0"
                                End If
                                reporte.SetDataSource(dtStockValorizado)
                                forma.crvReportes.ReportSource = reporte

                                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                    forma.crvReportes.ShowExportButton = True
                                Else
                                    forma.crvReportes.ShowExportButton = False
                                End If
                                'forma.crvReportes.RefreshReport = False
                                'forma.crvReportes.DisplayGroupTree = False

                                reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                reporte.SetParameterValue("Rubro", IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Text))
                                reporte.SetParameterValue("Movimiento", IIf(cmbCodMov.Text = "(Todos)", "", cmbCodMov.Text))
                                'reporte.SetParameterValue("rubro", cmbCodRub.Text)

                                '======================================== Tipo Reporte : Total General =============================================
                            ElseIf rbTotalGeneralAnt.Checked Then
                                Dim reporte As New rpStockValorizadoGeneral
                                If rbSinCeros.Checked Then
                                    dtStockValorizado.RowFilter = "Stock <> 0"
                                ElseIf rbPositivos.Checked Then
                                    dtStockValorizado.RowFilter = "Stock > 0"
                                ElseIf rbNegativos.Checked Then
                                    dtStockValorizado.RowFilter = "Stock < 0"
                                ElseIf rbCeros.Checked Then
                                    dtStockValorizado.RowFilter = "Stock = 0"
                                End If
                                reporte.SetDataSource(dtStockValorizado)
                                forma.crvReportes.ReportSource = reporte

                                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                    forma.crvReportes.ShowExportButton = True
                                Else
                                    forma.crvReportes.ShowExportButton = False
                                End If
                                'forma.crvReportes.RefreshReport = False
                                'forma.crvReportes.DisplayGroupTree = False

                                reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                reporte.SetParameterValue("Rubro", IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Text))
                                reporte.SetParameterValue("Movimiento", IIf(cmbCodMov.Text = "(Todos)", "", cmbCodMov.Text))
                                'reporte.SetParameterValue("rubro", cmbCodRub.Text)


                                '======================================== Tipo Reporte : Total Resumen =============================================
                            ElseIf rbRepResumen.Checked Then
                                Dim reporte As New rpStockValorizadoResumen
                                If rbSinCeros.Checked Then
                                    dtStockValorizado.RowFilter = "Stock <> 0"
                                ElseIf rbPositivos.Checked Then
                                    dtStockValorizado.RowFilter = "Stock > 0"
                                ElseIf rbNegativos.Checked Then
                                    dtStockValorizado.RowFilter = "Stock < 0"
                                ElseIf rbCeros.Checked Then
                                    dtStockValorizado.RowFilter = "Stock = 0"
                                End If
                                reporte.SetDataSource(dtStockValorizado)
                                forma.crvReportes.ReportSource = reporte

                                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                    forma.crvReportes.ShowExportButton = True
                                Else
                                    forma.crvReportes.ShowExportButton = False
                                End If
                                'forma.crvReportes.RefreshReport = False
                                'forma.crvReportes.DisplayGroupTree = False

                                reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                reporte.SetParameterValue("Rubro", IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Text))
                                reporte.SetParameterValue("Movimiento", IIf(cmbCodMov.Text = "(Todos)", "", cmbCodMov.Text))
                                'reporte.SetParameterValue("rubro", cmbCodRub.Text)

                                '======================================== Tipo Reporte : Indicadores =============================================
                            ElseIf rbIndicadores.Checked Then

                                Dim reporte As New rpStockValorizadoGenIndicador
                                If rbSinCeros.Checked Then
                                    dtStockValorizado.RowFilter = "Stock <> 0"
                                ElseIf rbPositivos.Checked Then
                                    dtStockValorizado.RowFilter = "Stock > 0"
                                ElseIf rbNegativos.Checked Then
                                    dtStockValorizado.RowFilter = "Stock < 0"
                                ElseIf rbCeros.Checked Then
                                    dtStockValorizado.RowFilter = "Stock = 0"
                                End If

                                Dim DiasTrans As Integer
                                Dim I1 As Double
                                Dim CV As Double

                                oLocacionService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(60)
                                If rbStockFecha.Checked Then
                                    DiasTrans = DateDiff(DateInterval.Day, CDate("01/01/" + utils.toBlank(Year(cbFecha.Value))), cbFecha.Value)
                                    I1 = oLocacionService.ObtenerSaldoInicio(Session.sCodEmp, CDate("01/01/" + utils.toBlank(Year(Today))))
                                    CV = oLocacionService.ObtenerCostoVenta(Session.sCodEmp, cbFecha.Value, "NS")
                                ElseIf rbStockActual.Checked Then
                                    DiasTrans = DateDiff(DateInterval.Day, CDate("01/01/" + utils.toBlank(Year(Today))), Today.Date)
                                    I1 = oLocacionService.ObtenerSaldoInicio(Session.sCodEmp, CDate("01/01/" + utils.toBlank(Year(Today))))
                                    CV = oLocacionService.ObtenerCostoVenta(Session.sCodEmp, Today.Date, "NS")
                                ElseIf rbSaldoInicio.Checked Then
                                    DiasTrans = DateDiff(DateInterval.Day, CDate("01/01/" + utils.toBlank(Year(Today))), Today.Date)
                                    I1 = oLocacionService.ObtenerSaldoInicio(Session.sCodEmp, CDate("01/01/" + utils.toBlank(Year(Today))))
                                    CV = oLocacionService.ObtenerCostoVenta(Session.sCodEmp, Today.Date, "NS")
                                End If
                                'DiasTrans = DateDiff(DateInterval.Day, CDate("01/01/" + utils.toBlank(Year(Today))), Today.Date)
                                'I1 = oLocacionService.ObtenerSaldoInicio(Session.sCodEmp, CDate("01/01/" + utils.toBlank(Year(Today))))
                                'CV = oLocacionService.ObtenerCostoVenta(Session.sCodEmp, Today.Date, "NS")

                                reporte.SetDataSource(dtStockValorizado)
                                forma.crvReportes.ReportSource = reporte

                                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                    forma.crvReportes.ShowExportButton = True
                                Else
                                    forma.crvReportes.ShowExportButton = False
                                End If
                                'forma.crvReportes.RefreshReport = False
                                'forma.crvReportes.DisplayGroupTree = False

                                reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                                'reporte.SetParameterValue("rubro", cmbCodRub.Text)
                                reporte.SetParameterValue("D", DiasTrans)
                                reporte.SetParameterValue("CV", CV)
                                reporte.SetParameterValue("I1", I1)
                            End If

                        End If

                        If dtStockValorizado.Count = 0 Then
                            MsgBox("No hay datos que Mostrar, Verfique los parametros.", MsgBoxStyle.Information, "No Hay Datos")
                        Else
                            '/////FILTRAR STOCK/////
                            '///////////////////////

                            'forma.crvReportes.DisplayGroupTree = False
                            forma.Text = "Reporte de Stock Valorizado"
                            forma.ShowDialog()

                        End If
                        '=======================================================================
                    End If
                End If


            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Consulta")
        End Try
    End Sub

    Private Sub rdTotalAlmacen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ckLibro.Visible = False
        ckLibro.Checked = False
    End Sub

    Private Sub rbTotalGeneral_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTotalGeneralAnt.CheckedChanged
        ckLibro.Visible = False
        ckLibro.Checked = False

        gpAlmacenes.Enabled = False
        gbRubro.Enabled = True
        gbOpciones.Enabled = True
        If rbStockActual.Checked Then
            gbFecha.Enabled = False
        ElseIf rbSaldoInicio.Checked Then
            'Cambiado 09-10-13
            gbFecha.Enabled = True
            'gpFecha.Enabled = False
        Else
            gbFecha.Enabled = True
        End If
        'gpFecha.Enabled = True
        gbTipStock.Enabled = True
        gbExportar.Enabled = False

        gbAgrupacion.Enabled = False
        gbMovimiento.Enabled = True
    End Sub

    Private Sub rbReporte1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRepTotalGeneral.CheckedChanged
        ckLibro.Visible = False
        ckLibro.Checked = False

        gpAlmacenes.Enabled = False
        gbRubro.Enabled = True
        gbOpciones.Enabled = True
        If rbStockActual.Checked Then
            gbFecha.Enabled = False
        ElseIf rbSaldoInicio.Checked Then
            'Cambiado 09-10-13
            gbFecha.Enabled = True
            'gpFecha.Enabled = False
        Else
            gbFecha.Enabled = True
        End If
        'gpFecha.Enabled = True
        gbTipStock.Enabled = True
        gbExportar.Enabled = False

        gbAgrupacion.Enabled = False
        gbMovimiento.Enabled = True
    End Sub

    Private Sub rbReporte2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRepResumen.CheckedChanged
        ckLibro.Visible = False
        ckLibro.Checked = False

        gpAlmacenes.Enabled = False
        gbRubro.Enabled = True
        gbOpciones.Enabled = True
        If rbStockActual.Checked Then
            gbFecha.Enabled = False
        ElseIf rbSaldoInicio.Checked Then
            'Cambiado 09-10-13
            gbFecha.Enabled = True
            'gpFecha.Enabled = False
        Else
            gbFecha.Enabled = True
        End If
        'gpFecha.Enabled = True
        gbTipStock.Enabled = True
        gbExportar.Enabled = False

        gbAgrupacion.Enabled = False
        gbMovimiento.Enabled = True
    End Sub

    Private Sub rbDetalle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDetalle.CheckedChanged
        ckLibro.Visible = True

        gpAlmacenes.Enabled = True
        gbRubro.Enabled = True
        gbOpciones.Enabled = True
        If rbStockActual.Checked Then
            gbFecha.Enabled = False
        ElseIf rbSaldoInicio.Checked Then
            gbFecha.Enabled = True
        Else
            gbFecha.Enabled = True
        End If
        'gpFecha.Enabled = True
        gbTipStock.Enabled = True
        gbExportar.Enabled = False

        gbAgrupacion.Enabled = True
        gbMovimiento.Enabled = True
    End Sub

    Private Sub rbGerencial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbGerencial.CheckedChanged
        If rbGerencial.Checked = True Then
            ckLibro.Visible = False
            ckLibro.Checked = False

            gpAlmacenes.Enabled = False
            gbRubro.Enabled = False
            gbOpciones.Enabled = False
            gbFecha.Enabled = False
            gbTipStock.Enabled = False
            gbExportar.Enabled = IIf(oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = True, True, False)

            gbAgrupacion.Enabled = False
            gbMovimiento.Enabled = False
        End If
    End Sub

    Private Sub rbIndicadores_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbIndicadores.CheckedChanged
        If rbIndicadores.Checked = True Then
            ckLibro.Visible = False
            ckLibro.Checked = False

            gpAlmacenes.Enabled = True
            gbRubro.Enabled = True
            gbOpciones.Enabled = True
            'gpFecha.Enabled = True
            If rbStockActual.Checked Then
                gbFecha.Enabled = False
            ElseIf rbSaldoInicio.Checked Then
                gbFecha.Enabled = False
            Else
                gbFecha.Enabled = True
            End If
            gbTipStock.Enabled = True
            gbExportar.Enabled = False

            gbAgrupacion.Enabled = False
            gbMovimiento.Enabled = False
        End If
    End Sub

    Private Sub rbStockActual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbStockActual.CheckedChanged
        gbFecha.Enabled = False
    End Sub

    Private Sub rbSaldoInicio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSaldoInicio.CheckedChanged
        gbFecha.Enabled = True
    End Sub

    Private Sub rbStockFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbStockFecha.CheckedChanged
        gbFecha.Enabled = True
    End Sub


End Class