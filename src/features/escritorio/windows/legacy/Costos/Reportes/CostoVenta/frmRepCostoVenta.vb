Imports System.ServiceModel
Public Class frmRepCostoVenta
    Private oDocumentoCostoService As New DocumentoCostoService.DocumentoCostoServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oReporteVentaService As New ReporteVentaService.ReporteVentaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oMaestro As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oProductoService As New ProductoService.ProductoServiceClient
    Private dtAlmacenes As DataTable
    Private dtOficinas As DataTable
    Private dtMonedas As DataTable
    Private dtRubros As DataTable
    Private dtVendedor As DataTable
    Private dtMotivos As DataTable
    Private Formato As Integer
    Private Tipo As Integer
    Dim IdCliente As Integer
    Dim CodMer As String

    Private dtDatosN As DataTable
    Private dtDatosN2 As DataTable

    Private Sub frmRepCostoVenta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oSeguridadService.Close()
            oDocumentoCostoService.Close()
            oReporteVentaService.Close()
            oMaestro.Close()
            oPersonaService.Close()
            oProductoService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oDocumentoCostoService.Abort()
            oReporteVentaService.Abort()
            oMaestro.Abort()
            oPersonaService.Abort()
            oProductoService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oDocumentoCostoService.Abort()
            oReporteVentaService.Abort()
            oMaestro.Abort()
            oPersonaService.Abort()
            oProductoService.Abort()
        End Try
    End Sub

    Private Sub frmRepCostoVenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepCostoVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtCliente.KeyPress _
            , cbCodMon.KeyPress _
            , cbFecFinal.KeyPress _
            , cbFecInicio.KeyPress _
            , cmbIdLocacion.KeyPress _
            , cmbOficinas.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub frmRepCostoVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 66)
        '/*************************************************************************************/

        Dim Mes, Anio As Integer
        Dim Fecha As Date

        Fecha = Today
        Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha) - 1)
        Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        cbFecFinal.Value = DateSerial(Year(Fecha), (Month(Fecha) - 1) + 1, 0)
        llenarCombos()
        cbFecInicio.Focus()
        IdCliente = 0
        cbCodMon.Value = "NS"
        Dim dtReporte As New DataTable

        rbExportExcel.Enabled = IIf(oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = True, True, False)
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
            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cbCodMon.DataSource = dtMonedas
            cbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            cbCodMon.SelectedIndex = 0
            dtMonedas = Nothing
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

            '======================================= Vendedor ===========================================
            dtVendedor = oPersonaService.MostrarVendedores(Session.sCodEmp).Tables(0)
            dtVendedor.Rows.InsertAt(getRowTodos(dtVendedor), 0)
            cmbVendedor.DataSource = dtVendedor
            cmbVendedor.DropDownList.DataMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.DropDownList.DisplayMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.DropDownList.ValueMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedor.DropDownList.Columns(0).DataMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedor.DropDownList.Columns(1).DataMember = dtVendedor.Columns("ApeNom").ToString
            dtVendedor = Nothing

            '======================================= MOTIVOS ================================================
            dtMotivos = oReporteVentaService.MostrarMotivosVenta.Tables(0) ' oMaestroService.MostrarMotivos.Tables(0)
            dtMotivos.Rows.InsertAt(getRowTodos(dtMotivos), 0)
            cmbCodMot.DataSource = dtMotivos
            cmbCodMot.DropDownList.DataMember = dtMotivos.Columns("DesMot").ToString
            cmbCodMot.DropDownList.DisplayMember = dtMotivos.Columns("DesMot").ToString
            cmbCodMot.DropDownList.ValueMember = dtMotivos.Columns("CodMot").ToString
            cmbCodMot.DropDownList.Columns(0).DataMember = dtMotivos.Columns("CodMot").ToString
            cmbCodMot.DropDownList.Columns(1).DataMember = dtMotivos.Columns("DesMot").ToString
            cmbCodMot.SelectedIndex = 0
            dtMotivos = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
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
            ' fila(0) = 0
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

    Private Sub MostrarReporteAntiguo()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            oDocumentoCostoService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
            If rbCosVenta.Checked Then
                If rbAcumulado.Checked Then
                    Dim reporte As New rpRepCostoVentaAcum
                    dtReporte = oDocumentoCostoService.ReporteCostoVenta(Session.sCodEmp, IIf(cmbOficinas.Text = "(Todos)", 0, cmbIdLocacion.Value), cbFecInicio.Text, cbFecFinal.Text, cbCodMon.Value, IdCliente, Formato, Tipo, toBlank(txtCodMer.Text), IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Value), 0, cmbCodMot.Value).Tables(0)
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
                            reporte.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            reporte.SetParameterValue("FecInicio", cbFecInicio.Text)
                            reporte.SetParameterValue("FecFinal", cbFecFinal.Text)
                            reporte.SetParameterValue("Cliente", txtCliente.Text)
                            reporte.SetParameterValue("CodMer", toBlank(txtCodMer.Text))

                            If cbCodMon.Value = "US" Then
                                reporte.SetParameterValue("Moneda", "DÓLARES")
                            ElseIf cbCodMon.Value = "NS" Then
                                reporte.SetParameterValue("Moneda", "SÓLES")
                            ElseIf cbCodMon.Value = "EU" Then
                                reporte.SetParameterValue("Moneda", "EUROS")
                            End If
                            forma.Text = "Reporte de Costo de Venta Acumulado"
                            forma.ShowDialog()
                        End If
                    End If

                ElseIf rbDetalle.Checked Then
                    Dim reporte As New rpRepCostoVentaDet
                    dtReporte = oDocumentoCostoService.ReporteCostoVenta(Session.sCodEmp, IIf(cmbOficinas.Text = "(Todos)", 0, cmbIdLocacion.Value), cbFecInicio.Text, cbFecFinal.Text, cbCodMon.Value, IdCliente, Formato, Tipo, toBlank(txtCodMer.Text), IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Value), toNumber(cmbVendedor.Value), cmbCodMot.Value).Tables(0)
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
                            reporte.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            reporte.SetParameterValue("FecInicio", cbFecInicio.Text)
                            reporte.SetParameterValue("FecFinal", cbFecFinal.Text)
                            reporte.SetParameterValue("Cliente", txtCliente.Text)
                            reporte.SetParameterValue("Vendedor", IIf(cmbVendedor.Value = 0, "", cmbVendedor.Text))
                            If cbCodMon.Value = "US" Then
                                reporte.SetParameterValue("Moneda", "DÓLARES")
                            ElseIf cbCodMon.Value = "NS" Then
                                reporte.SetParameterValue("Moneda", "SÓLES")
                            ElseIf cbCodMon.Value = "EU" Then
                                reporte.SetParameterValue("Moneda", "EUROS")
                            End If
                            forma.Text = "Reporte de Costo de Venta Detallado"
                            forma.ShowDialog()
                        End If
                    End If

                End If


            ElseIf rbCosvsVal.Checked Then
                If rbAcumulado.Checked Then
                    Dim reporte As New rpRepCostoVenta
                    dtReporte = oDocumentoCostoService.ReporteCostoVenta(Session.sCodEmp, IIf(cmbOficinas.Text = "(Todos)", 0, cmbIdLocacion.Value), cbFecInicio.Text, cbFecFinal.Text, cbCodMon.Value, IdCliente, Formato, Tipo, CodMer, IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Value), 0, cmbCodMot.Value).Tables(0)
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
                            reporte.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            reporte.SetParameterValue("cbFecInicio", cbFecInicio.Text)
                            reporte.SetParameterValue("cbFecFinal", cbFecFinal.Text)
                            reporte.SetParameterValue("Cliente", txtCliente.Text)
                            If cbCodMon.Value = "US" Then
                                reporte.SetParameterValue("Moneda", "DÓLARES")
                            ElseIf cbCodMon.Value = "NS" Then
                                reporte.SetParameterValue("Moneda", "SÓLES")
                            ElseIf cbCodMon.Value = "EU" Then
                                reporte.SetParameterValue("Moneda", "EUROS")
                            End If
                            forma.Text = "Reporte de Costo de Venta vs Valor de Venta"
                            forma.ShowDialog()
                        End If
                    End If

                End If


            ElseIf rbCosVentaGer.Checked Then
                If rbAcumulado.Checked Then
                    Dim reporte As New rpRepCostoVentaGerAcum
                    dtReporte = oDocumentoCostoService.ReporteCostoVentaGerencial(Session.sCodEmp, IIf(cmbOficinas.Text = "(Todos)", 0, cmbIdLocacion.Value), cbFecInicio.Text, cbFecFinal.Text, IdCliente, cbCodMon.Value, IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Value), 2).Tables(0)
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
                            reporte.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            reporte.SetParameterValue("FecInicio", cbFecInicio.Text)
                            reporte.SetParameterValue("FecFinal", cbFecFinal.Text)
                            reporte.SetParameterValue("Cliente", txtCliente.Text)
                            If cbCodMon.Value = "US" Then
                                reporte.SetParameterValue("Moneda", "DÓLARES")
                            ElseIf cbCodMon.Value = "NS" Then
                                reporte.SetParameterValue("Moneda", "SÓLES")
                            ElseIf cbCodMon.Value = "EU" Then
                                reporte.SetParameterValue("Moneda", "EUROS")
                            End If
                            forma.Text = "Reporte de Costo Gerencial Acumulado"
                            forma.ShowDialog()
                        End If
                    End If

                ElseIf rbDetalle.Checked Then
                    Dim reporte As New rpRepCostoVentaGerDet
                    dtReporte = oDocumentoCostoService.ReporteCostoVentaGerencial(Session.sCodEmp, IIf(cmbOficinas.Text = "(Todos)", 0, cmbIdLocacion.Value), cbFecInicio.Text, cbFecFinal.Text, IdCliente, cbCodMon.Value, IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Value), 3).Tables(0)
                    DataGridView1.DataSource = dtReporte
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
                            reporte.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            reporte.SetParameterValue("FecInicio", cbFecInicio.Text)
                            reporte.SetParameterValue("FecFinal", cbFecFinal.Text)
                            reporte.SetParameterValue("Cliente", txtCliente.Text)
                            If cbCodMon.Value = "US" Then
                                reporte.SetParameterValue("Moneda", "DÓLARES")
                            ElseIf cbCodMon.Value = "NS" Then
                                reporte.SetParameterValue("Moneda", "SÓLES")
                            ElseIf cbCodMon.Value = "EU" Then
                                reporte.SetParameterValue("Moneda", "EUROS")
                            End If
                            forma.Text = "Reporte de Costo Gerencial Detallado"
                            forma.ShowDialog()
                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub MostrarReporte1()

        Dim rowP As DataRow

        Dim dtCopia As New DataTable("tabla")
        dtCopia.Columns.Add(New DataColumn("DesEmp", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("RucEmp", Type.GetType("System.String")))       'datetime
        dtCopia.Columns.Add(New DataColumn("CodOfi", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("DesOfi", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("CodAlm", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("DesAlm", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("IdSerieDoc", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("AbrDoc", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("CodSerie", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("CodRub", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("DesRub", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("Costo", Type.GetType("System.Double")))
        dtCopia.Columns.Add(New DataColumn("Venta", Type.GetType("System.Double")))

        dtCopia.Rows.Add(New Object() {"1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "0.00", "0.00"})

        dtDatosN = dtCopia.Copy
        dtDatosN.Clear()

        Dim forma As New frmReportes
        Dim reporte As New rpRepInventario
        Dim dtReporte As New DataTable

        If rbCosVenta.Checked Then
            If rbAcumulado.Checked Then
                dtReporte = oDocumentoCostoService.ReporteCostoVenta(Session.sCodEmp, IIf(cmbOficinas.Text = "(Todos)", 0, cmbIdLocacion.Value), cbFecInicio.Text, cbFecFinal.Text, cbCodMon.Value, IdCliente, Formato, Tipo, toBlank(txtCodMer.Text), IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Value), 0, cmbCodMot.Value).Tables(0)
            ElseIf rbDetalle.Checked Then
                dtReporte = oDocumentoCostoService.ReporteCostoVenta(Session.sCodEmp, IIf(cmbOficinas.Text = "(Todos)", 0, cmbIdLocacion.Value), cbFecInicio.Text, cbFecFinal.Text, cbCodMon.Value, IdCliente, Formato, Tipo, toBlank(txtCodMer.Text), IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Value), toNumber(cmbVendedor.Value), cmbCodMot.Value).Tables(0)
            End If

        ElseIf rbCosvsVal.Checked Then
            If rbAcumulado.Checked Then
                dtReporte = oDocumentoCostoService.ReporteCostoVenta(Session.sCodEmp, IIf(cmbOficinas.Text = "(Todos)", 0, cmbIdLocacion.Value), cbFecInicio.Text, cbFecFinal.Text, cbCodMon.Value, IdCliente, Formato, Tipo, CodMer, IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Value), 0, cmbCodMot.Value).Tables(0)

            End If
        ElseIf rbCosVentaGer.Checked Then
            If rbAcumulado.Checked Then
                dtReporte = oDocumentoCostoService.ReporteCostoVentaGerencial(Session.sCodEmp, IIf(cmbOficinas.Text = "(Todos)", 0, cmbIdLocacion.Value), cbFecInicio.Text, cbFecFinal.Text, IdCliente, cbCodMon.Value, IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Value), 2).Tables(0)
            ElseIf rbDetalle.Checked Then
                dtReporte = oDocumentoCostoService.ReporteCostoVentaGerencial(Session.sCodEmp, IIf(cmbOficinas.Text = "(Todos)", 0, cmbIdLocacion.Value), cbFecInicio.Text, cbFecFinal.Text, IdCliente, cbCodMon.Value, IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Value), 3).Tables(0)
            End If
        End If

        DataGridView2.DataSource = dtReporte

        For i As Integer = 0 To DataGridView2.Rows.Count - 2

            For j As Integer = 0 To DataGridView3.Rows.Count - 2

                If DataGridView3.Item("CodRub", j).Value = DataGridView2.Item("CodRub", i).Value Then

                    rowP = dtDatosN.NewRow

                    rowP(0) = DataGridView2.Item(0, i).Value
                    rowP(1) = DataGridView2.Item(1, i).Value
                    rowP(2) = DataGridView2.Item(2, i).Value
                    rowP(3) = DataGridView2.Item(3, i).Value
                    rowP(4) = DataGridView2.Item(4, i).Value
                    rowP(5) = DataGridView2.Item(5, i).Value
                    rowP(6) = DataGridView2.Item(6, i).Value
                    rowP(7) = DataGridView2.Item(7, i).Value
                    rowP(8) = DataGridView2.Item(8, i).Value
                    rowP(9) = DataGridView2.Item(9, i).Value
                    rowP(10) = DataGridView2.Item(10, i).Value
                    rowP(11) = DataGridView2.Item(11, i).Value
                    rowP(12) = CDbl(DataGridView2.Item(12, i).Value)
                    rowP(13) = CDbl(DataGridView2.Item(13, i).Value)

                    dtDatosN.Rows.Add(rowP)

                End If
            Next
        Next

        MostrarReporte()

    End Sub

    Private Sub MostrarReporte()

        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            oDocumentoCostoService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
            If rbCosVenta.Checked Then
                If rbAcumulado.Checked Then
                    Dim reporte As New rpRepCostoVentaAcum

                    'dtReporte = oDocumentoCostoService.ReporteCostoVenta(Session.sCodEmp, IIf(cmbOficinas.Text = "(Todos)", 0, cmbIdLocacion.Value), cbFecInicio.Text, cbFecFinal.Text, cbCodMon.Value, IdCliente, Formato, Tipo, toBlank(txtCodMer.Text), IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Value), 0, cmbCodMot.Value).Tables(0)
                    dtReporte = dtDatosN.Copy
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
                            reporte.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            reporte.SetParameterValue("FecInicio", cbFecInicio.Text)
                            reporte.SetParameterValue("FecFinal", cbFecFinal.Text)
                            reporte.SetParameterValue("Cliente", txtCliente.Text)
                            reporte.SetParameterValue("CodMer", toBlank(txtCodMer.Text))

                            If cbCodMon.Value = "US" Then
                                reporte.SetParameterValue("Moneda", "DÓLARES")
                            ElseIf cbCodMon.Value = "NS" Then
                                reporte.SetParameterValue("Moneda", "SÓLES")
                            ElseIf cbCodMon.Value = "EU" Then
                                reporte.SetParameterValue("Moneda", "EUROS")
                            End If
                            forma.Text = "Reporte de Costo de Venta Acumulado"
                            forma.ShowDialog()
                        End If
                    End If

                ElseIf rbDetalle.Checked Then
                    Dim reporte As New rpRepCostoVentaDet

                    'dtReporte = oDocumentoCostoService.ReporteCostoVenta(Session.sCodEmp, IIf(cmbOficinas.Text = "(Todos)", 0, cmbIdLocacion.Value), cbFecInicio.Text, cbFecFinal.Text, cbCodMon.Value, IdCliente, Formato, Tipo, toBlank(txtCodMer.Text), IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Value), toNumber(cmbVendedor.Value), cmbCodMot.Value).Tables(0)
                    dtReporte = dtDatosN.Copy
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
                            reporte.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            reporte.SetParameterValue("FecInicio", cbFecInicio.Text)
                            reporte.SetParameterValue("FecFinal", cbFecFinal.Text)
                            reporte.SetParameterValue("Cliente", txtCliente.Text)
                            reporte.SetParameterValue("Vendedor", IIf(cmbVendedor.Value = 0, "", cmbVendedor.Text))
                            If cbCodMon.Value = "US" Then
                                reporte.SetParameterValue("Moneda", "DÓLARES")
                            ElseIf cbCodMon.Value = "NS" Then
                                reporte.SetParameterValue("Moneda", "SÓLES")
                            ElseIf cbCodMon.Value = "EU" Then
                                reporte.SetParameterValue("Moneda", "EUROS")
                            End If
                            forma.Text = "Reporte de Costo de Venta Detallado"
                            forma.ShowDialog()
                        End If
                    End If

                End If


            ElseIf rbCosvsVal.Checked Then
                If rbAcumulado.Checked Then
                    Dim reporte As New rpRepCostoVenta

                    'dtReporte = oDocumentoCostoService.ReporteCostoVenta(Session.sCodEmp, IIf(cmbOficinas.Text = "(Todos)", 0, cmbIdLocacion.Value), cbFecInicio.Text, cbFecFinal.Text, cbCodMon.Value, IdCliente, Formato, Tipo, CodMer, IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Value), 0, cmbCodMot.Value).Tables(0)
                    dtReporte = dtDatosN.Copy
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
                            reporte.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            reporte.SetParameterValue("cbFecInicio", cbFecInicio.Text)
                            reporte.SetParameterValue("cbFecFinal", cbFecFinal.Text)
                            reporte.SetParameterValue("Cliente", txtCliente.Text)
                            If cbCodMon.Value = "US" Then
                                reporte.SetParameterValue("Moneda", "DÓLARES")
                            ElseIf cbCodMon.Value = "NS" Then
                                reporte.SetParameterValue("Moneda", "SÓLES")
                            ElseIf cbCodMon.Value = "EU" Then
                                reporte.SetParameterValue("Moneda", "EUROS")
                            End If
                            forma.Text = "Reporte de Costo de Venta vs Valor de Venta"
                            forma.ShowDialog()
                        End If
                    End If

                End If


            ElseIf rbCosVentaGer.Checked Then
                If rbAcumulado.Checked Then
                    Dim reporte As New rpRepCostoVentaGerAcum

                    'dtReporte = oDocumentoCostoService.ReporteCostoVentaGerencial(Session.sCodEmp, IIf(cmbOficinas.Text = "(Todos)", 0, cmbIdLocacion.Value), cbFecInicio.Text, cbFecFinal.Text, IdCliente, cbCodMon.Value, IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Value), 2).Tables(0)
                    dtReporte = dtDatosN.Copy
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
                            reporte.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            reporte.SetParameterValue("FecInicio", cbFecInicio.Text)
                            reporte.SetParameterValue("FecFinal", cbFecFinal.Text)
                            reporte.SetParameterValue("Cliente", txtCliente.Text)
                            If cbCodMon.Value = "US" Then
                                reporte.SetParameterValue("Moneda", "DÓLARES")
                            ElseIf cbCodMon.Value = "NS" Then
                                reporte.SetParameterValue("Moneda", "SÓLES")
                            ElseIf cbCodMon.Value = "EU" Then
                                reporte.SetParameterValue("Moneda", "EUROS")
                            End If
                            forma.Text = "Reporte de Costo Gerencial Acumulado"
                            forma.ShowDialog()
                        End If
                    End If

                ElseIf rbDetalle.Checked Then
                    Dim reporte As New rpRepCostoVentaGerDet

                    'dtReporte = oDocumentoCostoService.ReporteCostoVentaGerencial(Session.sCodEmp, IIf(cmbOficinas.Text = "(Todos)", 0, cmbIdLocacion.Value), cbFecInicio.Text, cbFecFinal.Text, IdCliente, cbCodMon.Value, IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Value), 3).Tables(0)
                    dtReporte = dtDatosN.Copy
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
                            reporte.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            reporte.SetParameterValue("FecInicio", cbFecInicio.Text)
                            reporte.SetParameterValue("FecFinal", cbFecFinal.Text)
                            reporte.SetParameterValue("Cliente", txtCliente.Text)
                            If cbCodMon.Value = "US" Then
                                reporte.SetParameterValue("Moneda", "DÓLARES")
                            ElseIf cbCodMon.Value = "NS" Then
                                reporte.SetParameterValue("Moneda", "SÓLES")
                            ElseIf cbCodMon.Value = "EU" Then
                                reporte.SetParameterValue("Moneda", "EUROS")
                            End If
                            forma.Text = "Reporte de Costo Gerencial Detallado"
                            forma.ShowDialog()
                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub


    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        Try
            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            cmbIdLocacion.DataSource = dtAlmacenes
            'cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
            If dtAlmacenes.Rows.Count > 0 Then
                cmbIdLocacion.SelectedIndex = 0
            Else
                cmbIdLocacion.Value = ""
            End If
            dtAlmacenes = Nothing
            If cmbOficinas.Text = "(Todos)" Then
                lblAlmacen.Enabled = False
                cmbIdLocacion.Enabled = False
            Else
                lblAlmacen.Enabled = True
                cmbIdLocacion.Enabled = True
            End If

        Catch ex As Exception
            MsgBox("Error al Cargar Almacenes", MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            rbBuscarCliente.Checked = False
            txtCliente.Text = frm.descripcion
            'txtCliente.ReadOnly = True
            'txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If
        txtCliente.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Year(cbFecInicio.Value) <> Year(cbFecFinal.Value) Then
            MsgBox("La fecha de inicio y la fecha de fin deben pertenecer al mismo año.", MsgBoxStyle.Information)
        Else
            oSeguridadService.RegistrarVisitaOpciones(66, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            ChequearMarcados()
            If DataGridView3.Rows.Count > 1 And cbRubro.Checked Then
                MostrarReporte1()
            Else
                MostrarReporteAntiguo()
            End If

            'MostrarReporte()
        End If
    End Sub

    Private Sub rbBuscarCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarCliente.CheckedChanged
        txtCliente.Clear()
        IdCliente = 0
    End Sub

    Private Sub rbCosVenta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCosVenta.CheckedChanged, rbCosvsVal.CheckedChanged
        If rbCosVenta.Checked Then
            rbAcumulado.Checked = True
            rbDetalle.Enabled = True
            Tipo = 1
            gbMercaderia.Enabled = True
            cmbCodRub.Enabled = True
            gbMotivo.Enabled = True
        ElseIf rbCosvsVal.Checked Then
            rbAcumulado.Checked = True
            rbDetalle.Enabled = False
            Tipo = 2
            gbMercaderia.Enabled = False
            txtCodMer.Text = ""
            cmbCodRub.Enabled = False
            gbMotivo.Enabled = True
        ElseIf rbCosVentaGer.Checked = True Then
            rbAcumulado.Checked = True
            rbDetalle.Enabled = True
            gbMercaderia.Enabled = False
            txtCodMer.Text = ""
            cmbCodRub.Enabled = True
            gbMotivo.Enabled = False
        End If
    End Sub

    Private Sub rbAcumulado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAcumulado.CheckedChanged, rbDetalle.CheckedChanged
        If rbAcumulado.Checked Then
            Formato = 1
            gbVendedor.Enabled = False
        ElseIf rbDetalle.Checked Then
            Formato = 2
            gbVendedor.Enabled = True
        End If
    End Sub

    Private Sub rbMercaderia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMercaderia.CheckedChanged
        If rbMercaderia.Checked Then
            txtCodMer.Text = ""
        End If
    End Sub

    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm As New frmBuscarMercaderia
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            txtCodMer.Text = frm.codigo
            rbMercaderia.Checked = False
        End If
        txtCodMer.Select()
    End Sub


    Private Sub txtCodMer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodMer.TextChanged
        rbMercaderia.Checked = False
    End Sub

    Private Sub cbRubro_CheckedChanged(sender As Object, e As EventArgs) Handles cbRubro.CheckedChanged
        If cmbCodRub.Value = "" Then
            If cbRubro.Checked Then
                gbRubro.Visible = True
                llenarGrillaRubro()
            Else
                gbRubro.Visible = False
            End If
        End If
    End Sub

    Private Sub llenarGrillaRubro()

        '======================================= RUBROS ================================================
        dtRubros = oProductoService.MostrarRubrosEmpresa(Session.sCodEmp).Tables(0)
        dgvRubro.DataSource = dtRubros
        dtRubros = Nothing

    End Sub

    Private Sub cmbCodRub_ValueChanged(sender As Object, e As EventArgs) Handles cmbCodRub.ValueChanged
        If cmbCodRub.Value = "" Then
            cbRubro.Visible = True
            'gbRubro.Visible = True
        Else
            cbRubro.Visible = False
            cbRubro.Checked = False
            gbRubro.Visible = False
        End If
    End Sub

    Private Sub ChequearMarcados()

        Dim dtSeleccionados As New DataTable("tabla")
        dtSeleccionados.Columns.Add(New DataColumn("CodRub", Type.GetType("System.String")))
        dtSeleccionados.Columns.Add(New DataColumn("DesRub", Type.GetType("System.String")))

        dtSeleccionados.Rows.Add(New Object() {"1", "1"})
        dtDatosN2 = dtSeleccionados.Copy
        dtDatosN2.Clear()

        Dim row As DataRow

        Dim rows() As Janus.Windows.GridEX.GridEXRow
        Dim Cadena As String = ""
        rows = dgvRubro.GetCheckedRows()
        Dim row2 As Janus.Windows.GridEX.GridEXRow
        If rows.Count <> 0 Then
            For Each row2 In rows
                row = dtDatosN2.NewRow
                row(0) = row2.Cells("CodRub").Text
                row(1) = row2.Cells("DesRub").Text
                dtDatosN2.Rows.Add(row)
            Next
        End If

        DataGridView3.DataSource = dtDatosN2


    End Sub
End Class