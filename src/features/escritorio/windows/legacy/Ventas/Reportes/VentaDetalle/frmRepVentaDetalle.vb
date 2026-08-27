Imports System.ServiceModel

Public Class frmRepVentaDetalle
    Private oReporteVentaService As New ReporteVentaService.ReporteVentaServiceClient
    Private oMaestro As New MaestroService.MaestroClient
    Private oLocacionClienteService As New LocacionClienteService.LocacionClienteServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oProductoService As New ProductoService.ProductoServiceClient

    Dim IdCliente As String
    Dim Documento As String
    Dim IdPer As String
    Dim Tipo As String
    Dim dtOficinas As DataTable
    Dim dtAlmacenes As DataTable
    Dim dtVendedor As DataTable
    Dim dtRubros As DataTable
    Dim dtLocaciones As DataTable


    Private Sub frmRepVentaDetalle_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestro.Close()
            oReporteVentaService.Close()
            oLocacionClienteService.Close()
            oSeguridadService.Close()
            oPersonaService.Close()
            oProductoService.Close()
        Catch ex As TimeoutException
            oMaestro.Abort()
            oReporteVentaService.Abort()
            oLocacionClienteService.Abort()
            oSeguridadService.Abort()
            oPersonaService.Abort()
            oProductoService.Abort()
        Catch ex As CommunicationException
            oMaestro.Abort()
            oReporteVentaService.Abort()
            oLocacionClienteService.Abort()
            oSeguridadService.Abort()
            oPersonaService.Abort()
            oProductoService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmRepVentaDetalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            cbFecInicio.KeyPress _
                        , cbFecFinal.KeyPress _
                        , rbBuscarCliente.KeyPress _
                        , rbDetallado.KeyPress _
                        , rbMercaderia.KeyPress _
                        , rbTodos.KeyPress _
                        , cmbIdLocacion.KeyPress _
                        , cmbOficinas.KeyPress _
                        , cmbCodRub.KeyPress
        ', cmbVendedor.KeyPress
        ', txtCliente.KeyPress _
        ', txtCodMer.KeyPress _
        ', rbCliente.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub frmRepVentaDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            e.Handled = True
        End If
    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnBuscarCliente_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    Private Sub txtCodMer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMer.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnBuscarMercaderia_Click(sender, e)
            e.Handled = True
        End If
    End Sub
    Private Sub txtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            rbMercaderia.Focus()
        End If
    End Sub
    Private Sub rbCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbCliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnAceptar.Focus()
        End If
    End Sub
    Private Sub txtCodMer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodMer.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            rbDetallado.Focus()
        End If
    End Sub

    Private Sub frmRepVentaDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 32)
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
        llenarCombos()
        cbFecInicio.Select()

        rbExportExcel.Enabled = IIf(oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = True, True, False)

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
        Try
            fila(4) = "(Todos)"
        Catch ex As Exception

        End Try
      
        Try
            fila(5) = "(Todos)"
        Catch ex As Exception

        End Try

        Return fila
    End Function
    Private Function getRowAsignado(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = 1
        Catch ex As Exception

        End Try
        Try
            fila(1) = "ASIGNADO A OFICINA"
        Catch ex As Exception

        End Try

        Return fila
    End Function

    Private Function getRowLocacion(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = 0
        Catch ex As Exception
        End Try
      
        Try
            fila(4) = "(Todos)"
        Catch ex As Exception
        End Try

        Return fila
    End Function
   
    Private Sub llenarCombos()
        Try
            '======================================= OFICINAS ================================================
            dtOficinas = oMaestro.MostrarOficinas(Session.sCodUsu).Tables(0)
            dtOficinas.Rows.InsertAt(getRowTodos(dtOficinas), 0)
            cmbOficinas.DataSource = dtOficinas
            'cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing
            '======================================= VENDEDOR ===========================================
            dtVendedor = oPersonaService.MostrarVendedores(Session.sCodEmp).Tables(0)
            dtVendedor.Rows.InsertAt(getRowAsignado(dtVendedor), 0)
            cmbVendedor.DataSource = dtVendedor
            cmbVendedor.DropDownList.DataMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.DropDownList.DisplayMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.DropDownList.ValueMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedor.DropDownList.Columns(0).DataMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedor.DropDownList.Columns(1).DataMember = dtVendedor.Columns("ApeNom").ToString
            dtVendedor = Nothing
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

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Sub listarLocacionesCliente()
        '======================================= LOCACIONES DEL CLIENTE ================================================
        dtLocaciones = oLocacionClienteService.Mostrar(IdCliente).Tables(0)
        dtLocaciones.Rows.InsertAt(getRowLocacion(dtLocaciones), 0)
        cmbIdLocCli.DataSource = dtLocaciones
        cmbIdLocCli.DropDownList.DataMember = dtLocaciones.Columns("Nombre").ToString
        cmbIdLocCli.DropDownList.DisplayMember = dtLocaciones.Columns("Nombre").ToString
        cmbIdLocCli.DropDownList.ValueMember = dtLocaciones.Columns("IdLocCli").ToString
        cmbIdLocCli.DropDownList.Columns(0).DataMember = dtLocaciones.Columns("IdLocCli").ToString
        cmbIdLocCli.DropDownList.Columns(1).DataMember = dtLocaciones.Columns("Nombre").ToString
        cmbIdLocCli.SelectedIndex = 0
        dtLocaciones = Nothing
  
    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim dtReporte2 As New DataView

            If rbCliente.Checked Then
                Dim reporte As New rpRepVentaDetalleCliente
                Dim reporteunit As New rpRepVentaDetalleClienteUnit
                oReporteVentaService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(5)
                dtReporte = oReporteVentaService.VentaDetalle(Session.sCodEmp, cmbOficinas.Value, IIf(cmbIdLocacion.Text = "(Todos)", "", cmbIdLocacion.Value), cbFecInicio.Value, _
                                                                                      cbFecFinal.Value, IIf(rbBuscarCliente.Checked = True, 0, IdCliente), IIf(rbTodoVendedor.Checked, 0, cmbVendedor.Value), _
                                                                                      IIf(txtCodMer.Text = "", "", txtCodMer.Text), Documento, cmbCodRub.Value, cmbIdLocCli.Value, Tipo).Tables(0)
                DataGridView1.DataSource = dtReporte
                dtReporte2 = dtReporte.DefaultView

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else

                    If rbExportExcel.Checked Then
                        Dim Export As Boolean
                        If rbExpDetallado.Checked = True Then
                            Export = ExportarExcel(DataGridView1)
                        ElseIf rbExpResumido.Checked = True Then
                            Dim dataset1 As DataSet
                            'Dim myColumn As DataColumn
                            '--------------------------------Se cambia para que cuando se escoja la opción EXPORTAR ---> RESUMIDO se ponga por defecto el TIPO 4 (25/06/2014) ---- Sr Percy-------------------------------
                            dataset1 = oReporteVentaService.VentaDetalle(Session.sCodEmp, cmbOficinas.Value, IIf(cmbIdLocacion.Text = "(Todos)", "", cmbIdLocacion.Value), cbFecInicio.Value, _
                                                                                                cbFecFinal.Value, IIf(rbBuscarCliente.Checked = True, 0, IdCliente), IIf(rbTodoVendedor.Checked, 0, cmbVendedor.Value), _
                                                                                                IIf(txtCodMer.Text = "", "", txtCodMer.Text), Documento, cmbCodRub.Value, cmbIdLocCli.Value, 4)
                            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                            '  dataset1.Tables(0).Columns.Remove("CodEmp")
                            dataset1.Tables(0).Columns.Remove("DesEmp")
                            dataset1.Tables(0).Columns.Remove("RucEmp")
                            ' dataset1.Tables(0).Columns.Remove("CodOfi")
                            ' dataset1.Tables(0).Columns.Remove("CodAlm")
                            'dataset1.Tables(0).Columns.Remove("DesRub")
                            '  dataset1.Tables(0).Columns.Remove("IdCliente")
                            dataset1.Tables(0).Columns.Remove("RucCli")
                            dataset1.Tables(0).Columns.Remove("DniCli")
                            dataset1.Tables(0).Columns.Remove("FecDoc")
                            dataset1.Tables(0).Columns.Remove("NumDoc")
                            '  dataset1.Tables(0).Columns.Remove("TipDoc")
                            dataset1.Tables(0).Columns.Remove("IdPer")
                            dataset1.Tables(0).Columns.Remove("CodMot")
                            dataset1.Tables(0).Columns.Remove("DesMot")
                            dataset1.Tables(0).Columns.Remove("Venta")
                            dataset1.Tables(0).Columns.Remove("Clase")
                            '  dataset1.Tables(0).Columns.Remove("PrecioCoreUS")
                            '  dataset1.Tables(0).Columns.Remove("PrecioCoreNS")

                            DataGridView1.DataSource = dataset1.Tables(0)
                            Export = ExportarExcel(DataGridView1)
                        End If

                        If Export Then
                            MsgBox("Se realizó la exportación correctamente")
                        End If
                    ElseIf rbPantalla.Checked Then

                        If rbDetalladoUnit.Checked Then

                            If rbPorMercaderia.Checked Then
                                dtReporte2.Sort = "CodMer Asc"
                            ElseIf rbPorFechaCliente.Checked Then
                                dtReporte2.Sort = "FecDoc Asc"
                            End If

                            reporteunit.SetDataSource(dtReporte2)
                            '----
                            'reporte.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteunit

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            forma.Text = "Reporte de Ventas Detalle"
                            reporteunit.SetParameterValue("FecInicio", cbFecInicio.Value)
                            reporteunit.SetParameterValue("FecFinal", cbFecFinal.Value)
                            reporteunit.SetParameterValue("Oficina", cmbOficinas.Text)
                            reporteunit.SetParameterValue("Almacen", cmbIdLocacion.Text)
                            reporteunit.SetParameterValue("Vendedor", cmbVendedor.Text)
                            reporteunit.SetParameterValue("Rubro", cmbCodRub.Text)
                            reporteunit.SetParameterValue("LocCliente", IIf(cmbIdLocCli.Value = 0, "", cmbIdLocCli.Text))

                            If rbTodos.Checked Then
                                reporteunit.SetParameterValue("Documento", "Todos")
                            ElseIf rbFacturacion.Checked Then
                                reporteunit.SetParameterValue("Documento", "Ventas Totales")
                            ElseIf rbFacturadosSinEx.Checked Then
                                reporteunit.SetParameterValue("Documento", "Ventas sin Exportación")
                            ElseIf rbExportaciones.Checked Then
                                reporteunit.SetParameterValue("Documento", "Ventas de Exportación")
                            End If
                            'If rbDetallado.Checked Then
                            '    reporte.SetParameterValue("Codigo", "Deta")
                            '    If rbResumen.Checked Then
                            '        reporte.SetParameterValue("Codigo", "Resu")
                            '    End If
                            'End If
                            forma.ShowDialog()

                        Else

                            '----
                            If rbPorMercaderia.Checked Then
                                dtReporte2.Sort = "CodMer Asc"
                            ElseIf rbPorFechaCliente.Checked Then
                                dtReporte2.Sort = "FecDoc Asc"
                            End If

                            reporte.SetDataSource(dtReporte2)
                            '----
                            'reporte.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            forma.Text = "Reporte de Ventas Detalle"
                            reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                            reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                            reporte.SetParameterValue("Oficina", cmbOficinas.Text)
                            reporte.SetParameterValue("Almacen", cmbIdLocacion.Text)
                            reporte.SetParameterValue("Vendedor", cmbVendedor.Text)
                            reporte.SetParameterValue("Rubro", cmbCodRub.Text)
                            reporte.SetParameterValue("LocCliente", IIf(cmbIdLocCli.Value = 0, "", cmbIdLocCli.Text))

                            If rbTodos.Checked Then
                                reporte.SetParameterValue("Documento", "Todos")
                            ElseIf rbFacturacion.Checked Then
                                reporte.SetParameterValue("Documento", "Ventas Totales")
                            ElseIf rbFacturadosSinEx.Checked Then
                                reporte.SetParameterValue("Documento", "Ventas sin Exportación")
                            ElseIf rbExportaciones.Checked Then
                                reporte.SetParameterValue("Documento", "Ventas de Exportación")
                            End If
                            'If rbDetallado.Checked Then
                            '    reporte.SetParameterValue("Codigo", "Deta")
                            '    If rbResumen.Checked Then
                            '        reporte.SetParameterValue("Codigo", "Resu")
                            '    End If
                            'End If
                            forma.ShowDialog()

                        End If

                    End If

                    End If

            ElseIf rbMerca.Checked Then
                If rbResumen.Checked Then
                    MsgBox("No Existe Reporte para esta Opción", MsgBoxStyle.Information, "No hay Reporte")
                Else
                    Dim reporte As New rpRepVentaDetalleMerca
                    dtReporte = oReporteVentaService.VentaDetalle(Session.sCodEmp, cmbOficinas.Value, IIf(cmbIdLocacion.Text = "(Todos)", "", cmbIdLocacion.Value), cbFecInicio.Value, _
                                                                                          cbFecFinal.Value, IIf(rbBuscarCliente.Checked = True, 0, IdCliente), IIf(cmbVendedor.Text = "(Todos)", 0, cmbVendedor.Value), _
                                                                                          IIf(txtCodMer.Text = "", "", txtCodMer.Text), Documento, cmbCodRub.Value, cmbIdLocCli.Value, Tipo).Tables(0)
                    DataGridView1.DataSource = dtReporte
                    dtReporte2 = dtReporte.DefaultView

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else

                        If rbExportExcel.Checked Then
                            Dim Export As Boolean
                            If rbExpDetallado.Checked = True Then
                                Export = ExportarExcel(DataGridView1)
                            ElseIf rbExpResumido.Checked = True Then
                                Dim dataset1 As DataSet
                                'Dim myColumn As DataColumn
                                '--------------------------------Se cambia para que cuando se escoja la opción EXPORTAR ---> RESUMIDO se ponga por defecto el TIPO 4 (25/06/2014) ---- Sr Percy-------------------------------
                                dataset1 = oReporteVentaService.VentaDetalle(Session.sCodEmp, cmbOficinas.Value, IIf(cmbIdLocacion.Text = "(Todos)", "", cmbIdLocacion.Value), cbFecInicio.Value, _
                                                                                                    cbFecFinal.Value, IIf(rbBuscarCliente.Checked = True, 0, IdCliente), IIf(rbTodoVendedor.Checked, 0, cmbVendedor.Value), _
                                                                                                    IIf(txtCodMer.Text = "", "", txtCodMer.Text), Documento, cmbCodRub.Value, cmbIdLocCli.Value, 4)
                                '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                ' dataset1.Tables(0).Columns.Remove("CodEmp")
                                dataset1.Tables(0).Columns.Remove("DesEmp")
                                dataset1.Tables(0).Columns.Remove("RucEmp")
                                '  dataset1.Tables(0).Columns.Remove("CodOfi")
                                '  dataset1.Tables(0).Columns.Remove("CodAlm")
                                'dataset1.Tables(0).Columns.Remove("DesRub")
                                '  dataset1.Tables(0).Columns.Remove("IdCliente")
                                dataset1.Tables(0).Columns.Remove("RucCli")
                                dataset1.Tables(0).Columns.Remove("DniCli")
                                dataset1.Tables(0).Columns.Remove("FecDoc")
                                dataset1.Tables(0).Columns.Remove("NumDoc")
                                dataset1.Tables(0).Columns.Remove("TipDoc")
                                dataset1.Tables(0).Columns.Remove("IdPer")
                                dataset1.Tables(0).Columns.Remove("CodMot")
                                dataset1.Tables(0).Columns.Remove("DesMot")
                                dataset1.Tables(0).Columns.Remove("Venta")
                                dataset1.Tables(0).Columns.Remove("Clase")
                                ' dataset1.Tables(0).Columns.Remove("PrecioCoreUS")
                                ' dataset1.Tables(0).Columns.Remove("PrecioCoreNS")

                                DataGridView1.DataSource = dataset1.Tables(0)
                                Export = ExportarExcel(DataGridView1)
                            End If
                            'Dim Export As Boolean = ExportarExcel(DataGridView1)

                            If Export Then
                                MsgBox("Se realizó la exportación correctamente")
                            End If
                        ElseIf rbPantalla.Checked Then

                            '----
                            If rbPorCliente.Checked Then
                                dtReporte2.Sort = "DesCli Asc"
                            ElseIf rbPorFechaMerca.Checked Then
                                dtReporte2.Sort = "FecDoc Asc"
                            End If

                            reporte.SetDataSource(dtReporte2)
                            '---
                            'reporte.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            'forma.crvReportes.RefreshReport = False
                            forma.Text = "Reporte de Ventas Detalle"
                            reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                            reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                            reporte.SetParameterValue("Oficina", cmbOficinas.Text)
                            reporte.SetParameterValue("Almacen", cmbIdLocacion.Text)
                            reporte.SetParameterValue("Vendedor", cmbVendedor.Text)
                            reporte.SetParameterValue("Rubro", cmbCodRub.Text)
                            reporte.SetParameterValue("LocCliente", IIf(cmbIdLocCli.Value = 0, "", cmbIdLocCli.Text))
                            'reporte.SetParameterValue("CodOficina", cmbOficinas.Value)
                            'reporte.SetParameterValue("CodAlmacen", IIf(cmbIdLocacion.Text = "(Todos)", "", cmbIdLocacion.Value))
                            If rbTodos.Checked Then
                                reporte.SetParameterValue("Documento", "Todos")
                            ElseIf rbFacturacion.Checked Then
                                reporte.SetParameterValue("Documento", "Ventas Totales")
                            ElseIf rbFacturadosSinEx.Checked Then
                                reporte.SetParameterValue("Documento", "Ventas sin Exportación")
                            ElseIf rbExportaciones.Checked Then
                                reporte.SetParameterValue("Documento", "Ventas de Exportación")
                            End If

                            forma.ShowDialog()
                        End If
                      
                        End If
                End If
            End If
            'Me.DataGridView1.DataSource = dtReporte

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub rbDocumento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTodos.CheckedChanged, rbFacturacion.CheckedChanged, rbFacturadosSinEx.CheckedChanged, rbExportaciones.CheckedChanged
        If rbTodos.Checked Then
            Documento = "1"
        ElseIf rbFacturacion.Checked Then
            Documento = "2"
        ElseIf rbFacturadosSinEx.Checked Then
            Documento = "3"
        ElseIf rbExportaciones.Checked Then
            Documento = "4"
        End If
    End Sub


    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm As New frmBuscarLocacionMercaderia
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            rbMercaderia.Checked = False
            txtCodMer.Text = frm.codigo
            txtCodMer.BackColor = System.Drawing.SystemColors.Window

        End If
        txtCodMer.Select()
    End Sub


    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        Try

            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestro.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            dtAlmacenes.Rows.InsertAt(getRowTodos(dtAlmacenes), 0)
            cmbIdLocacion.DataSource = dtAlmacenes
            'cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("CodAlm").ToString
            cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("CodAlm").ToString
            cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
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


    Private Sub rbMercaderia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMercaderia.CheckedChanged
        txtCodMer.Text = ""
    End Sub

   

    Private Sub txtCodMer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodMer.TextChanged
        rbMercaderia.Checked = False
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(32, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub rbTipo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDetallado.CheckedChanged, rbResumen.CheckedChanged
        If rbDetallado.Checked Then
            Tipo = "1"
        ElseIf rbResumen.Checked Then
            Tipo = "2"
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
            If IdCliente > 0 Then
                lblLocCliente.Enabled = True
                cmbIdLocCli.Enabled = True
                listarLocacionesCliente()
            Else
                cmbIdLocCli.Value = 0
                lblLocCliente.Enabled = False
                cmbIdLocCli.Enabled = False
            End If
        End If
        txtCliente.Select()
    End Sub

    'Private Sub btnBuscarPersonal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim frm As New frmBuscarPersonal
    '    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '        rbBuscarPersonal.Checked = False
    '        txtPersonal.Text = frm.descripcion
    '        'txtPersonal.ReadOnly = True
    '        'txtPersonal.BackColor = System.Drawing.SystemColors.Control
    '        IdPer = frm.codigo
    '    End If
    'End Sub

    Private Sub rbBuscarCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarCliente.CheckedChanged
        txtCliente.Text = ""
        IdCliente = 0
        lblLocCliente.Enabled = False
        cmbIdLocCli.Enabled = False
        cmbIdLocCli.Value = 0
    End Sub

    Private Sub cmbVendedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbVendedor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            rbBuscarCliente.Focus()
        End If
    End Sub

    'Private Sub rbBuscarPersonal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    txtPersonal.Text = ""
    'End Sub
    Private Sub rbTodoVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTodoVendedor.CheckedChanged
        If rbTodoVendedor.Checked Then
            cmbVendedor.Clear()
            cmbVendedor.ReadOnly = True
        Else
            cmbVendedor.Clear()
            cmbVendedor.ReadOnly = False
        End If

    End Sub

    Private Sub rbExportExcel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbExportExcel.CheckedChanged
        If rbExportExcel.Checked = True Then
            gbExportar.Enabled = True
            rbExpDetallado.Checked = True
            gbTipoReporte.Enabled = False
            rbDetallado.Checked = True
            gbReporteAgrupado.Enabled = False
            rbCliente.Checked = True
        End If
    End Sub

    Private Sub rbPantalla_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPantalla.CheckedChanged
        If rbPantalla.Checked = True Then
            gbExportar.Enabled = False
            rbExpDetallado.Checked = True
            gbTipoReporte.Enabled = True
            gbReporteAgrupado.Enabled = True

        End If
    End Sub

    Private Sub rbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCliente.CheckedChanged
        If rbCliente.Checked = True Then
            gbOrdenMerca.Enabled = False
            gbOrdenCliente.Enabled = True
        End If
    End Sub

    Private Sub rbMerca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMerca.CheckedChanged
        If rbMerca.Checked = True Then
            gbOrdenCliente.Enabled = False
            gbOrdenMerca.Enabled = True
        End If
    End Sub


End Class