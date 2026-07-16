Imports System.ServiceModel
Public Class frmRepVentaAcumulada
    Private oReporteVentaService As New ReporteVentaService.ReporteVentaServiceClient
    Private oMaestro As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oProductoService As New ProductoService.ProductoServiceClient

    Dim dtAlmacenes As DataTable
    Dim dtOficinas As DataTable
    Dim dtMotivos As DataTable
    Dim dtVendedor As DataTable
    Dim dtRubros As DataTable
    Dim IdPer As String
    Dim codMar As String
    Dim Tipo As String
    Dim IdCliente As String
    Dim Ruc As String


    Private Sub frmRepVentaAcumulada_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestro.Close()
            oReporteVentaService.Close()
            oSeguridadService.Close()
            oPersonaService.Close()
            oProductoService.Close()
        Catch ex As TimeoutException
            oMaestro.Abort()
            oReporteVentaService.Abort()
            oSeguridadService.Abort()
            oPersonaService.Abort()
            oProductoService.Abort()
        Catch ex As CommunicationException
            oMaestro.Abort()
            oReporteVentaService.Abort()
            oSeguridadService.Abort()
            oPersonaService.Abort()
            oProductoService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnBuscarCliente_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    Private Sub txtMarca_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMarca.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnBuscaMarca_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    Private Sub frmRepVentaAcumulada_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         cbFecInicio.KeyPress _
                        , cbFecFinal.KeyPress _
                        , cmbCodMot.KeyPress _
                        , txtMarca.KeyPress _
                        , cmbIdLocacion.KeyPress _
                        , rbBuscarCliente.KeyPress _
                        , rbMerca.KeyPress _
                        , rbMarca.KeyPress _
                        , rbCliente.KeyPress _
                        , cmbOficinas.KeyPress _
                        , cmbCodRub.KeyPress
        ', cmbVendedor.KeyPress
        ', txtMarca.KeyPress _
        ', txtCliente.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub frmRepVentaAcumulada_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            e.Handled = True
        End If
    End Sub
    Private Sub cmbVendedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbVendedor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            rbBuscarCliente.Focus()
        End If
    End Sub
    Private Sub frmRepVentaAcumulada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 33)
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
        cmbCodMot.Value = "(Todos)"
        cmbVendedor.Value = "(Todos)"
        llenarCombos()
        cbFecInicio.Select()

        rbExcel.Enabled = IIf(oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = True, True, False)

    End Sub
    Private Function getRowTodos(ByVal data As DataTable)
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
    Private Sub llenarCombos()
        Try
            '======================================= Oficinas ================================================
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
            '======================================= Motivo ===========================================
            dtMotivos = oReporteVentaService.MostrarMotivosVenta.Tables(0)
            dtMotivos.Rows.InsertAt(getRowTodos(dtMotivos), 0)
            cmbCodMot.DataSource = dtMotivos
            cmbCodMot.DropDownList.DataMember = dtMotivos.Columns("DesMot").ToString
            cmbCodMot.DropDownList.DisplayMember = dtMotivos.Columns("DesMot").ToString
            cmbCodMot.DropDownList.ValueMember = dtMotivos.Columns("CodMot").ToString
            cmbCodMot.DropDownList.Columns(0).DataMember = dtMotivos.Columns("CodMot").ToString
            cmbCodMot.DropDownList.Columns(1).DataMember = dtMotivos.Columns("DesMot").ToString
            dtMotivos = Nothing
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
    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataView
            Dim reporte As New rpRepVentaAcumulada
            Dim reporte1 As New rpRepVentaAcumuladaCantVend

            dtReporte = oReporteVentaService.VentaAcumulada(Session.sCodEmp, cmbOficinas.Value, IIf(cmbIdLocacion.Text = "(Todos)", "", cmbIdLocacion.Value), cbFecInicio.Value, cbFecFinal.Value, _
                                                            IIf(rbBuscarCliente.Checked = True, 0, IdCliente), IIf(cmbVendedor.Text = "(Todos)", 0, cmbVendedor.Value), IIf(cmbCodMot.Text = "(Todos)", "", cmbCodMot.Value), _
                                                            IIf(rbMarca.Checked = True, "", codMar), cmbCodRub.Value, Tipo).Tables(0).DefaultView

            If dtReporte.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                If rbExcel.Checked Then

                    If rbMerca.Checked Then
                        If rbDescripcion.Checked Then

                            If rbAscendente.Checked Then
                                dtReporte.Sort = "Descripcion Asc"
                            ElseIf rbDescendente.Checked Then
                                dtReporte.Sort = "Descripcion Desc"
                            End If
                        ElseIf rbDolares.Checked Then
                            If rbAscendente.Checked Then
                                dtReporte.Sort = "TotPrecioUS Asc"
                            ElseIf rbDescendente.Checked Then
                                dtReporte.Sort = "TotPrecioUS Desc"
                            End If
                        ElseIf rbSoles.Checked Then
                            If rbAscendente.Checked Then
                                dtReporte.Sort = "TotPrecioNS Asc"
                            ElseIf rbDescendente.Checked Then
                                dtReporte.Sort = "TotPrecioNS Desc"
                            End If
                        End If

                    ElseIf rbCliente.Checked Then
                        If rbDescripcion.Checked Then

                            If rbAscendente.Checked Then
                                dtReporte.Sort = "Descripcion Asc"
                            ElseIf rbDescendente.Checked Then
                                dtReporte.Sort = "Descripcion Desc"
                            End If
                        ElseIf rbDolares.Checked Then
                            If rbAscendente.Checked Then
                                dtReporte.Sort = "TotPrecioUS Asc"
                            ElseIf rbDescendente.Checked Then
                                dtReporte.Sort = "TotPrecioUS Desc"
                            End If
                        ElseIf rbSoles.Checked Then
                            If rbAscendente.Checked Then
                                dtReporte.Sort = "TotPrecioNS Asc"
                            ElseIf rbDescendente.Checked Then
                                dtReporte.Sort = "TotPrecioNS Desc"
                            End If
                        End If


                    End If

                    'Dim dataset1 As DataSet
                    ''Dim myColumn As DataColumn
                    'dataset1 = oReporteVentaService.VentaAcumulada(Session.sCodEmp, cmbOficinas.Value, IIf(cmbIdLocacion.Text = "(Todos)", "", cmbIdLocacion.Value), cbFecInicio.Value, cbFecFinal.Value, IIf(rbBuscarCliente.Checked = True, 0, IdCliente), IIf(cmbVendedor.Text = "(Todos)", 0, cmbVendedor.Value), IIf(cmbCodMot.Text = "(Todos)", "", cmbCodMot.Value), IIf(rbMarca.Checked = True, "", codMar), cmbCodRub.Value, Tipo)
                    'dataset1.Tables(0).Columns.Remove("CodEmp")
                    'dataset1.Tables(0).Columns.Remove("DesEmp")
                    'dataset1.Tables(0).Columns.Remove("RucEmp")
                    'dataset1.Tables(0).Columns.Remove("CodOfi")
                    'dataset1.Tables(0).Columns.Remove("CodAlm")

                    'DataGridView1.DataSource = dataset1.Tables(0)
                    DataGridView1.DataSource = dtReporte
                    Dim Export As Boolean = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente")
                    End If

                ElseIf rbPantalla.Checked Then
                    If rbMerca.Checked Then
                        If rbDescripcion.Checked Then

                            If rbAscendente.Checked Then
                                dtReporte.Sort = "Descripcion Asc"
                            ElseIf rbDescendente.Checked Then
                                dtReporte.Sort = "Descripcion Desc"
                            End If
                        ElseIf rbDolares.Checked Then
                            If rbAscendente.Checked Then
                                dtReporte.Sort = "TotPrecioUS Asc"
                            ElseIf rbDescendente.Checked Then
                                dtReporte.Sort = "TotPrecioUS Desc"
                            End If
                        ElseIf rbSoles.Checked Then
                            If rbAscendente.Checked Then
                                dtReporte.Sort = "TotPrecioNS Asc"
                            ElseIf rbDescendente.Checked Then
                                dtReporte.Sort = "TotPrecioNS Desc"
                            End If
                        End If

                    ElseIf rbCliente.Checked Then
                        If rbDescripcion.Checked Then

                            If rbAscendente.Checked Then
                                dtReporte.Sort = "Descripcion Asc"
                            ElseIf rbDescendente.Checked Then
                                dtReporte.Sort = "Descripcion Desc"
                            End If
                        ElseIf rbDolares.Checked Then
                            If rbAscendente.Checked Then
                                dtReporte.Sort = "TotPrecioUS Asc"
                            ElseIf rbDescendente.Checked Then
                                dtReporte.Sort = "TotPrecioUS Desc"
                            End If
                        ElseIf rbSoles.Checked Then
                            If rbAscendente.Checked Then
                                dtReporte.Sort = "TotPrecioNS Asc"
                            ElseIf rbDescendente.Checked Then
                                dtReporte.Sort = "TotPrecioNS Desc"
                            End If
                        End If


                    End If

                    If rbCantVendidas.Checked Then

                        reporte1.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte1

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Reporte de Ventas Acumuladas"
                        reporte1.SetParameterValue("FecInicio", cbFecInicio.Value)
                        reporte1.SetParameterValue("FecFinal", cbFecFinal.Value)
                        reporte1.SetParameterValue("Oficina", cmbOficinas.Text)
                        reporte1.SetParameterValue("Almacen", cmbIdLocacion.Text)

                        forma.ShowDialog()

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

                        'forma.crvReportes.RefreshReport = False
                        forma.Text = "Reporte de Ventas Acumuladas"
                        reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                        reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                        If rbMerca.Checked Then
                            reporte.SetParameterValue("Codigo", "RUC/DNI")
                        ElseIf rbCliente.Checked Then
                            reporte.SetParameterValue("Codigo", "NRO.PARTE")
                        End If
                        reporte.SetParameterValue("Cliente", txtCliente.Text)
                        reporte.SetParameterValue("Ruc", IIf(Ruc = "", "", Ruc))
                        reporte.SetParameterValue("Vendedor", cmbVendedor.Text)
                        reporte.SetParameterValue("Motivo", cmbCodMot.Text)
                        reporte.SetParameterValue("Marca", txtMarca.Text)
                        reporte.SetParameterValue("Oficina", cmbOficinas.Text)
                        reporte.SetParameterValue("Almacen", cmbIdLocacion.Text)
                        reporte.SetParameterValue("Rubro", cmbCodRub.Text)
                        reporte.SetParameterValue("Tipo", Tipo)
                        'dtReporte.WriteXmlSchema("C:\VentaAcumulada.xml")

                        forma.ShowDialog()
                    End If
                 
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub MostrarReporteAnual()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpRepVentaAcumuladaAnios

            dtReporte = oReporteVentaService.VentaAcumulada(Session.sCodEmp, cmbOficinas.Value, IIf(cmbIdLocacion.Text = "(Todos)", "", cmbIdLocacion.Value), cbFecInicio.Value, cbFecFinal.Value, IIf(rbBuscarCliente.Checked = True, 0, IdCliente), IIf(cmbVendedor.Text = "(Todos)", 0, cmbVendedor.Value), IIf(cmbCodMot.Text = "(Todos)", "", cmbCodMot.Value), IIf(rbMarca.Checked = True, "", codMar), cmbCodRub.Value, Tipo).Tables(0)
            DataGridView1.DataSource = dtReporte

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                If rbExcel.Checked Then

                    Dim dataset1 As DataSet
                    'Dim myColumn As DataColumn
                    dataset1 = oReporteVentaService.VentaAcumulada(Session.sCodEmp, cmbOficinas.Value, IIf(cmbIdLocacion.Text = "(Todos)", "", cmbIdLocacion.Value), cbFecInicio.Value, cbFecFinal.Value, IIf(rbBuscarCliente.Checked = True, 0, IdCliente), IIf(cmbVendedor.Text = "(Todos)", 0, cmbVendedor.Value), IIf(cmbCodMot.Text = "(Todos)", "", cmbCodMot.Value), IIf(rbMarca.Checked = True, "", codMar), cmbCodRub.Value, Tipo)
                    dataset1.Tables(0).Columns.Remove("CodEmp")
                    dataset1.Tables(0).Columns.Remove("DesEmp")
                    dataset1.Tables(0).Columns.Remove("RucEmp")
                    dataset1.Tables(0).Columns.Remove("CodRub")

                    DataGridView1.DataSource = dataset1.Tables(0)
                    Dim Export As Boolean = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente")
                    End If
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

                    'forma.crvReportes.RefreshReport = False
                    forma.Text = "Reporte de Ventas Acumuladas"
                    'reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    'reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    Dim fecha As Date
                    fecha = cbFecInicio.Text
                    reporte.SetParameterValue("Venta4", Format(fecha, "yyyy"))
                    reporte.SetParameterValue("Venta3", Format(fecha, "yyyy") - 1)
                    reporte.SetParameterValue("Venta2", Format(fecha, "yyyy") - 2)
                    reporte.SetParameterValue("Venta1", Format(fecha, "yyyy") - 3)
                    'If rbMerca.Checked Then
                    '    reporte.SetParameterValue("Codigo", "RUC/DNI")
                    'ElseIf rbCliente.Checked Then
                    '    reporte.SetParameterValue("Codigo", "NRO.PARTE")
                    'End If
                    'reporte.SetParameterValue("Cliente", txtCliente.Text)
                    'reporte.SetParameterValue("Ruc", IIf(Ruc = "", "", Ruc))
                    'reporte.SetParameterValue("Vendedor", cmbVendedor.Text)
                    'reporte.SetParameterValue("Motivo", cmbCodMot.Text)
                    'reporte.SetParameterValue("Marca", txtMarca.Text)
                    'reporte.SetParameterValue("Oficina", cmbOficinas.Text)
                    'reporte.SetParameterValue("Almacen", cmbIdLocacion.Text)
                    reporte.SetParameterValue("Rubro", cmbCodRub.Text)
                    'dtReporte.WriteXmlSchema("C:\VentaAcumulada.xml")

                    forma.ShowDialog()

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

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

    'Private Sub rbBuscarPersonal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    txtPersonal.Text = ""
    'End Sub

    Private Sub btnBuscaMarca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaMarca.Click
        Dim frm As New frmBuscarMarca
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            rbMarca.Checked = False
            txtMarca.Text = frm.descripcion
            txtMarca.BackColor = System.Drawing.SystemColors.Control
            codMar = frm.codigo
        End If
        txtMarca.Select()
    End Sub

    Private Sub rbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMarca.CheckedChanged
        txtMarca.Text = ""
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(33, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        If rbAno.Checked Then
            MostrarReporteAnual()
        Else
            MostrarReporte()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
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

    Private Sub rbTipo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMerca.CheckedChanged, rbCliente.CheckedChanged, rbAno.CheckedChanged, rbCantVendidas.CheckedChanged
        If rbMerca.Checked Then
            Tipo = "1"
            'gbOrden.Enabled = True
            'gbTipoOrdenado.Enabled = True
        ElseIf rbCliente.Checked Then
            Tipo = "2"
            'gbOrden.Enabled = False
            'gbTipoOrdenado.Enabled = False
        ElseIf rbAno.Checked Then
            Tipo = "3"
        ElseIf rbCantVendidas.Checked = True Then
            Tipo = "4"
        End If
    End Sub


    Private Sub txtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            rbMerca.Focus()
        End If
    End Sub
    Private Sub txtMarca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMarca.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnAceptar.Focus()
        End If
    End Sub

    Private Sub rbAno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAno.CheckedChanged, rbMerca.CheckedChanged, rbCliente.CheckedChanged, rbCantVendidas.CheckedChanged
        If rbAno.Checked Then
            gbOrden.Enabled = False
            gbTipoOrdenado.Enabled = False
            gbMarca.Enabled = False
            gbCliente.Enabled = False
            cmbVendedor.Enabled = False
            cmbOficinas.Enabled = False
            cmbIdLocacion.Enabled = False
            cmbCodMot.Enabled = False
            cmbVendedor.SelectedIndex = 0
            cmbOficinas.SelectedIndex = 0
            cmbCodMot.SelectedIndex = 0
            cmbIdLocacion.SelectedIndex = 0
            rbBuscarCliente.Checked = True
            rbMarca.Checked = True
            cmbCodRub.Enabled = True
        ElseIf rbMerca.Checked Then
            gbOrden.Enabled = True
            gbTipoOrdenado.Enabled = True
            gbMarca.Enabled = True
            gbCliente.Enabled = True
            cmbVendedor.Enabled = True
            cmbOficinas.Enabled = True
            cmbIdLocacion.Enabled = True
            cmbCodMot.Enabled = True
            cmbCodRub.Enabled = True
        ElseIf rbCliente.Checked Then
            gbOrden.Enabled = True
            gbTipoOrdenado.Enabled = True
            gbMarca.Enabled = True
            gbCliente.Enabled = True
            cmbVendedor.Enabled = True
            cmbOficinas.Enabled = True
            cmbIdLocacion.Enabled = True
            cmbCodMot.Enabled = True
            cmbCodRub.Enabled = True
            '=========================
        ElseIf rbCantVendidas.Checked Then
            gbOrden.Enabled = False
            gbTipoOrdenado.Enabled = False
            gbMarca.Enabled = False
            gbCliente.Enabled = False
            cmbVendedor.Enabled = False
            cmbOficinas.Enabled = True
            cmbIdLocacion.Enabled = True
            cmbCodMot.Enabled = False
            cmbCodRub.Enabled = False
        End If
    End Sub


End Class