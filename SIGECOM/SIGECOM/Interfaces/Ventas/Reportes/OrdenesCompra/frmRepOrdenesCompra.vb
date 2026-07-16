Imports System.ServiceModel

Public Class frmRepOrdenesCompra

    Private oOrdenCompra As New OrdenCompraService.OrdenCompraServiceClient
    Private oMaestro As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oMercaderia As New MercaderiaService.MercaderiaServiceClient
    Dim dtOficinas As DataTable
    Dim dtAlmacenes As DataTable
    Dim dtEstados As DataTable
    Dim dtReporte As DataTable
    Dim dtVendedor As DataTable
    Dim IdCliente As String
    Dim IdVendedor As String
    Dim IdMercaderia As String
    Private dtRubros As DataTable

    Private Sub frmRepOrdenesCompra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestro.Close()
            oOrdenCompra.Close()
            oSeguridadService.Close()
            oPersonaService.Close()
            oMercaderia.Close()
        Catch ex As TimeoutException
            oMaestro.Abort()
            oOrdenCompra.Abort()
            oSeguridadService.Abort()
            oPersonaService.Abort()
            oMercaderia.Abort()
        Catch ex As CommunicationException
            oMaestro.Abort()
            oOrdenCompra.Abort()
            oSeguridadService.Abort()
            oPersonaService.Abort()
            oMercaderia.Abort()
        End Try
    End Sub

    Private Sub frmRepOrdenesCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepVentaDetalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            cbFecInicio.KeyPress _
                        , cbFecFinal.KeyPress _
                        , rbBuscarCliente.KeyPress _
                        , rbDetallado.KeyPress _
                        , rbTodos.KeyPress _
                        , cmbIdLocacion.KeyPress _
                        , cmbOficinas.KeyPress _
                        , cmbEstados.KeyPress _
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

    Private Sub frmRepOrdenesCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 146)
        '/*************************************************************************************/

        cbFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        cbFecFinal.Value = Date.Today
        llenarCombos()
        cmbOficinas.Text = ""
        cmbIdLocacion.Text = ""
        cmbEstados.Text = ""
        rbSeparado.Checked = False
        rbPantalla.Checked = True

        rbExcel.Enabled = IIf(oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = True, True, False)

    End Sub

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
            fila(2) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(3) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(4) = "(Todos)"
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

    Private Sub llenarCombos()
        Try
            '======================================= Oficinas ================================================
            dtOficinas = oMaestro.MostrarOficinas(Session.sCodUsu).Tables(0)
            'dtOficinas.Rows.InsertAt(getRowTodos(dtOficinas), 0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

            '======================================= Estados ================================================
            dtEstados = oOrdenCompra.MostrarEstados()
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstados.DataSource = dtEstados
            cmbEstados.DropDownList.DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstados.DropDownList.DisplayMember = dtEstados.Columns("Descripcion").ToString
            cmbEstados.DropDownList.ValueMember = dtEstados.Columns("Estado").ToString
            cmbEstados.DropDownList.Columns(0).DataMember = dtEstados.Columns("Estado").ToString
            cmbEstados.DropDownList.Columns(1).DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstados.SelectedIndex = 0
            dtEstados = Nothing

            '======================================= Vendedor ===========================================
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
            dtRubros = oMercaderia.MostrarRubrosEmpresa(Session.sCodEmp).Tables(0) 'oMaestro.MostrarRubros.Tables(0)
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

    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        Try
            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestro.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            'dtAlmacenes.Rows.InsertAt(getRowTodos(dtAlmacenes), 0)
            cmbIdLocacion.DataSource = dtAlmacenes
            cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
            If dtAlmacenes.Rows.Count > 0 Then
                cmbIdLocacion.SelectedIndex = 0
            Else
                cmbIdLocacion.Value = 0
            End If
            dtAlmacenes = Nothing

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
        txtCliente.Select()
    End Sub

    Private Sub rbBuscarCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarCliente.CheckedChanged
        txtCliente.Text = ""
        IdCliente = 0
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(146, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        If validarData() = True Then
            If rbTotalizado.Checked Then
                MostrarReporteTotalizado()
            ElseIf rbDetallado.Checked Then
                MostrarReporteDetallado()
            ElseIf rbAtendidos.Checked Then
                MostrarReporteAtendidos()
            End If
        End If

    End Sub

    Private Function validarData() As Boolean

        If cmbOficinas.Text = "" Then
            MsgBox("Debe ingresar la oficina")
            cmbOficinas.Focus()
            Return False
        ElseIf cmbIdLocacion.Text = "" Then
            MsgBox("Debe Ingresar la Locacion")
            cmbIdLocacion.Focus()
            Return False
        ElseIf cmbEstados.Text = "" Then
            MsgBox("Debe Ingresar el Estado")
            cmbEstados.Focus()
            Return False
        ElseIf cbFecInicio.Value > cbFecFinal.Value Then
            MsgBox("La Fecha Inicial no puede ser mayor a la Fecha Final")
            cbFecInicio.Focus()
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub MostrarReporteTotalizado()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpRepOrdCompraTotalizado

            If rbTodoVendedor.Checked = True Then
                IdVendedor = 0
            Else
                IdVendedor = cmbVendedor.Value
            End If

            dtReporte = oOrdenCompra.ReporteOrdenCompra(Session.sCodEmp, 1, cbFecInicio.Value, cbFecFinal.Value, IdCliente, cmbIdLocacion.Value, cmbEstados.Value, IdVendedor, 0, "", cmbCodRub.Value).Tables(0)
            DataGridView1.DataSource = dtReporte

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                If rbExcel.Checked Then
                    Dim Export As Boolean
                    Export = ExportarExcel(DataGridView1)
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

                    forma.Text = "Reporte de Orden de Compra Totalizado"

                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    reporte.SetParameterValue("pOficina", cmbOficinas.Text)
                    reporte.SetParameterValue("pAlmacen", cmbIdLocacion.Text)
                    reporte.SetParameterValue("pEstados", IIf(cmbEstados.Value = "", "(Todos)", cmbEstados.Text))
                    reporte.SetParameterValue("pCliente", IIf(txtCliente.Text = "", "(Todos)", txtCliente.Text))
                    reporte.SetParameterValue("DesEmp", Session.sDesEmp)
                    reporte.SetParameterValue("RucEmp", oMaestro.MostrarDato("Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp))
                    reporte.SetParameterValue("TipCam", Session.sTipCam)
                    reporte.SetParameterValue("Vendedor", IIf(IdVendedor = 0, "(Todos)", cmbVendedor.Text))

                    reporte.SetParameterValue("Reporte", "Reporte de Orden de Compra Totalizado")

                    forma.ShowDialog()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub MostrarReporteDetallado()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpRepOrdCompraDetallado
            Dim Condicion As Integer

            If rbTodoVendedor.Checked = True Then
                IdVendedor = 0
            Else
                IdVendedor = cmbVendedor.Value
            End If

            If rbSeparado.Checked = True Then
                Condicion = 1
            ElseIf rbTodos.Checked = True Then
                Condicion = 2
            End If

            dtReporte = oOrdenCompra.ReporteOrdenCompra(Session.sCodEmp, 2, cbFecInicio.Value, cbFecFinal.Value, IdCliente, cmbIdLocacion.Value, cmbEstados.Value, IdVendedor, Condicion, IdMercaderia, cmbCodRub.Value).Tables(0)
            DataGridView1.DataSource = dtReporte

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                If rbExcel.Checked Then
                    Dim Export As Boolean
                    Export = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente ")
                    End If
                ElseIf rbPantalla.Checked Then

                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte de Orden de Compra Detallado"

                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    reporte.SetParameterValue("pOficina", cmbOficinas.Text)
                    reporte.SetParameterValue("pAlmacen", cmbIdLocacion.Text)
                    reporte.SetParameterValue("pEstados", IIf(cmbEstados.Value = "", "(Todos)", cmbEstados.Text))
                    reporte.SetParameterValue("pCliente", IIf(txtCliente.Text = "", "(Todos)", txtCliente.Text))
                    reporte.SetParameterValue("pMercaderia", IIf(txtSerie.Text = "", "(Todos)", txtSerie.Text))
                    reporte.SetParameterValue("DesEmp", Session.sDesEmp)
                    reporte.SetParameterValue("RucEmp", oMaestro.MostrarDato("Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp))
                    reporte.SetParameterValue("Vendedor", IIf(IdVendedor = 0, "(Todos)", cmbVendedor.Text))

                    reporte.SetParameterValue("Reporte", "Reporte de Orden de Compra Detallado")

                    forma.ShowDialog()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub MostrarReporteAtendidos()

        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpRepOrdCompraTotalizado

            If rbTodoVendedor.Checked = True Then
                IdVendedor = 0
            Else
                IdVendedor = cmbVendedor.Value
            End If

            dtReporte = oOrdenCompra.ReporteOrdenesGuiados(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, IdCliente, cmbIdLocacion.Value, cmbEstados.Value, IdVendedor, IdMercaderia, cmbCodRub.Value).Tables(0)
            DataGridView1.DataSource = dtReporte

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                If rbExcel.Checked Then
                    Dim Export As Boolean
                    Export = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente ")
                    End If
                    'ElseIf rbPantalla.Checked Then
                    '    reporte.SetDataSource(dtReporte)
                    '    forma.crvReportes.ReportSource = reporte

                    '    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    '        forma.crvReportes.ShowExportButton = True
                    '    Else
                    '        forma.crvReportes.ShowExportButton = False
                    '    End If
                    '    'forma.crvReportes.RefreshReport = False
                    '    'forma.crvReportes.DisplayGroupTree = False

                    '    forma.Text = "Reporte de Orden de Compra Totalizado"

                    '    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    '    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    '    reporte.SetParameterValue("pOficina", cmbOficinas.Text)
                    '    reporte.SetParameterValue("pAlmacen", cmbIdLocacion.Text)
                    '    reporte.SetParameterValue("pEstados", IIf(cmbEstados.Value = "", "(Todos)", cmbEstados.Text))
                    '    reporte.SetParameterValue("pCliente", IIf(txtCliente.Text = "", "(Todos)", txtCliente.Text))
                    '    reporte.SetParameterValue("DesEmp", Session.sDesEmp)
                    '    reporte.SetParameterValue("RucEmp", oMaestro.MostrarDato("Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp))
                    '    reporte.SetParameterValue("TipCam", Session.sTipCam)
                    '    reporte.SetParameterValue("Vendedor", IIf(IdVendedor = 0, "(Todos)", cmbVendedor.Text))

                    '    reporte.SetParameterValue("Reporte", "Reporte de Orden de Compra Totalizado")

                    '    forma.ShowDialog()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub


    Private Sub rbTodoVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTodoVendedor.CheckedChanged
        If rbTodoVendedor.Checked Then
            cmbVendedor.Clear()
            cmbVendedor.ReadOnly = True
        Else
            cmbVendedor.Clear()
            cmbVendedor.ReadOnly = False
        End If
    End Sub

    Private Sub rbTotalizado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTotalizado.CheckedChanged
        If rbTotalizado.Checked = True Then
            rbDetallado.Checked = False
            rbAtendidos.Checked = False
            rbTodos.Enabled = False
            rbSeparado.Enabled = False
            rbTodos.Checked = False
            rbSeparado.Checked = False
            gbMercaderia.Enabled = False
            txtSerie.Text = ""
            IdMercaderia = ""
            rbPantalla.Enabled = True
            rbExcel.Enabled = True
            rbPantalla.Checked = True
        End If
    End Sub

    Private Sub rbDetallado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDetallado.CheckedChanged
        If rbDetallado.Checked = True Then
            rbTotalizado.Checked = False
            rbAtendidos.Checked = False
            rbTodos.Enabled = True
            rbSeparado.Enabled = True
            rbTodos.Checked = False
            rbSeparado.Checked = True
            gbMercaderia.Enabled = True
            rbPantalla.Enabled = True
            rbExcel.Enabled = True
            rbPantalla.Checked = True
        End If
    End Sub

    Private Sub btnMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMercaderia.Click

        Dim frm As New frmBuscarMercaderia
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            IdMercaderia = frm.codigo
            txtSerie.Text = frm.codigo
            rbBuscarMercaderia.Checked = False
        End If
        txtSerie.Select()
       
    End Sub

    Private Sub rbBuscarMercaderia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarMercaderia.CheckedChanged
        If rbBuscarMercaderia.Checked = True Then
            txtSerie.Text = ""
            IdMercaderia = ""
        End If
    End Sub

    Private Sub rbAtendidos_CheckedChanged(sender As Object, e As EventArgs) Handles rbAtendidos.CheckedChanged
        If rbAtendidos.Checked = True Then
            rbTotalizado.Checked = False
            rbDetallado.Checked = False
            rbTodos.Enabled = False
            rbSeparado.Enabled = False
            rbTodos.Checked = False
            rbSeparado.Checked = False
            gbMercaderia.Enabled = True
            rbPantalla.Enabled = False
            rbExcel.Enabled = True
            rbExcel.Checked = True
        End If
    End Sub
End Class