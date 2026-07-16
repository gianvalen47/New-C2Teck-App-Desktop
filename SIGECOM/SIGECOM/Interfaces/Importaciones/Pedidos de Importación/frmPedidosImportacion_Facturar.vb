Imports System.Windows.Forms

Public Class frmPedidosImportacion_Facturar

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMaestroService As New MaestroService.MaestroClient
    Private oFacturaImportService As New FacturaImportService.FacturaImportServiceClient
    Private oDireccionFiscalService As New DireccionFiscalService.DireccionFiscalServiceClient
    Private oProveedorService As New ProveedorService.ProveedorServiceClient
    Private oPedidoImport As New PedidoImportService.PedidoImportServiceClient
    Private oPedidoImportDetService As New PedidoImportDetService.PedidoImportDetServiceClient

    Private dtDatos As DataTable
    Private dtLocaciones As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public dtDocumentos As DataTable
    Public dtPrecios As DataTable
    Public dtMedios As DataTable
    Private dtCondicionesPago As DataTable

    Public IdPedidoImp As Int64
    Private IdClienteSold As String
    Private IdClienteShip As String
    Private IdProvider As Integer
    Public estado As String
    Private Referencia As String
    Private Subtotal As Double
    Public IdSerieImp As String
    Public codMon As String
    'Params to documents generation
    Public tipoDocGenerated As String
    Public NumeroDocGenerated As String
    Public FacturaGenerated As String

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================

    Private Sub txtSold_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSold.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnBuscarSold_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    Private Sub txtShip_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShip.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnBuscarShip_Click(sender, e)
            e.Handled = True
        End If
    End Sub
    Private Sub cmbMedio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbMedio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnBuscarSold.Enabled = True Then
                btnBuscarSold.Select()
            End If
        End If
    End Sub
    Private Sub txtSol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSold.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnBuscarShip.Enabled = True Then
                btnBuscarShip.Select()
            End If
        End If
    End Sub
    Private Sub txtShip_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShip.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnBuscarProvider.Enabled = True Then
                btnBuscarProvider.Select()
            End If
        End If
    End Sub
    Private Sub txtProvider_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProvider.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnBuscarProvider_Click(sender, e)
            e.Handled = True
        End If
    End Sub
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtOrders.KeyPress _
                          , txtMarks.KeyPress _
                          , txtFecDoc.KeyPress _
                          , txtNumDoc.KeyPress _
                          , txtTerms.KeyPress _
 _
 _
 _
                          , txtFleInt.KeyPress _
 _
                          , txtOtrosGastos.KeyPress _
 _
                          , txtProvider.KeyPress _
                          , txtNroPqte.KeyPress _
                          , txtFecLlegadaMiami.KeyPress
        ', txtShip.KeyPress _
        ', cmbMedio.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub frmDocumento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    Private Sub txtOtrosGastos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOtrosGastos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            btnAceptar.Select()
            btnAceptar_Click(sender, e)

        End If
    End Sub

    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        llenarCombos()

        Dim estilo As New Estilo
        estilo.cargaEstiloDataDrid(dgvPrueba)
        dgvPrueba.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        dgvPrueba.Columns(20).ReadOnly = False

        txtNumDoc.ReadOnly = False
        txtNumDoc.TabStop = True
        txtmoneda.Text = codMon


        btnBuscarProvider.Enabled = True
        'Me.Size = New System.Drawing.Size(724, 329)
        Me.Text = "Facturar Orden de Pedido"

        If codMon <> "US" Then
            lblmoneda.Visible = True
            lbltipocambio.Visible = True
            txtmoneda.Visible = True
            txttipocambio.Visible = True
        Else
            lblmoneda.Visible = False
            lbltipocambio.Visible = False
            txtmoneda.Visible = False
            txttipocambio.Visible = False
        End If

        listaDatos()


    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oFacturaImportService) = False Then
                oFacturaImportService.Close()
            End If
            If isClosed(oProveedorService) = False Then
                oProveedorService.Close()
            End If
            If isClosed(oPedidoImport) = False Then
                oPedidoImport.Close()
            End If
            If isClosed(oPedidoImportDetService) = False Then
                oPedidoImportDetService.Close()
            End If


        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                            txtOrders.KeyUp _
                          , txtMarks.KeyUp _
                          , txtFecDoc.KeyUp _
                          , txtSold.KeyUp _
                          , txtTerms.KeyUp _
                          , txtNumDoc.KeyUp _
                          , txtShip.KeyUp _
 _
 _
 _
                          , txtFleInt.KeyUp

        Try
            Dim campo As New Object
            If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.EditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.EditBox
            ElseIf sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.NumericEditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.NumericEditBox
            ElseIf sender.GetType.ToString = "System.Windows.Forms.TextBox" Then
                campo = New TextBox
            End If
            campo = sender
            If campo.readonly = False Then
                If campo.Text.Trim.Length > 0 Then
                    campo.BackColor = Color.White
                Else
                    campo.BackColor = Color.Red
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oPedidoImportDetService.Mostrar(toNumber(IdPedidoImp)).Tables(0)
            'dgvDatos.SetDataBinding(dtDatos, 0)

            ''//Datagrid agregado para solucionar el problema de Columna Despacho q seteaba 0
            dgvPrueba.DataSource = dtDatos

            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        'If oOrdenCompraService.Estado(IdOrden) = "PROCESADO" Then
        '    btnGuardar.Enabled = False
        '    miSeleccionarTodo.Enabled = False
        '    miSeterCEROTodos.Enabled = False
        '    'dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
        '    dgvPrueba.ReadOnly = True
        'Else
        btnAceptar.Enabled = True
        miSeleccionarTodo.Enabled = True
        miSeterCEROTodos.Enabled = True

        'dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
        dgvPrueba.ReadOnly = False
        dgvPrueba.Columns(0).ReadOnly = True
        dgvPrueba.Columns(1).ReadOnly = True
        dgvPrueba.Columns(2).ReadOnly = True
        dgvPrueba.Columns(3).ReadOnly = True
        dgvPrueba.Columns(4).ReadOnly = True
        dgvPrueba.Columns(5).ReadOnly = True
        dgvPrueba.Columns(6).ReadOnly = True
        dgvPrueba.Columns(7).ReadOnly = True
        dgvPrueba.Columns(8).ReadOnly = True
        dgvPrueba.Columns(9).ReadOnly = True
        dgvPrueba.Columns(10).ReadOnly = True
        dgvPrueba.Columns(11).ReadOnly = True
        dgvPrueba.Columns(12).ReadOnly = True
        dgvPrueba.Columns(13).ReadOnly = True
        dgvPrueba.Columns(14).ReadOnly = True
        dgvPrueba.Columns(15).ReadOnly = True
        dgvPrueba.Columns(16).ReadOnly = True
        dgvPrueba.Columns(17).ReadOnly = True
        dgvPrueba.Columns(18).ReadOnly = True
        dgvPrueba.Columns(19).ReadOnly = True
        dgvPrueba.Columns(20).ReadOnly = False       ' campo Despacho
        'dgvDatos.RootTable.Columns(1).EditType = Janus.Windows.GridEX.EditType.NoEdit
        'dgvDatos.RootTable.Columns(2).EditType = Janus.Windows.GridEX.EditType.NoEdit
        'dgvDatos.RootTable.Columns(3).EditType = Janus.Windows.GridEX.EditType.NoEdit
        'dgvDatos.RootTable.Columns(4).EditType = Janus.Windows.GridEX.EditType.NoEdit
        'dgvDatos.RootTable.Columns(5).EditType = Janus.Windows.GridEX.EditType.NoEdit
        'dgvDatos.RootTable.Columns(6).EditType = Janus.Windows.GridEX.EditType.NoEdit
        'dgvDatos.RootTable.Columns(7).EditType = Janus.Windows.GridEX.EditType.TextBox
        'End If
    End Sub

    Private Sub miSeleccionarTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeleccionarTodo.Click
        seleccionaTodos(True)
    End Sub
    Private Sub miSeterCEROTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeterCEROTodos.Click
        seleccionaTodos(False)
    End Sub

    Private Sub seleccionaTodos(ByVal condicion As Boolean)
        ''//Codigo Comentado agregado para solucionar el problema de Columna Despacho q seteaba 0
        'For i As Integer = 0 To dtDatos.Rows.Count - 1
        '    If condicion = True Then
        '        dgvDatos.GetRow(i).Cells("Despacho").Text = dgvDatos.GetRow(i).Cells("CanPen").Text
        '    Else
        '        dgvDatos.GetRow(i).Cells("Despacho").Text = 0
        '    End If
        'Next
        For i As Integer = 0 To dtDatos.Rows.Count - 1
            If condicion = True Then
                dgvPrueba.Rows(i).Cells("Despacho").Value = dgvPrueba.Rows(i).Cells("PenFac").Value
            Else
                dgvPrueba.Rows(i).Cells("Despacho").Value = 0
            End If
        Next
    End Sub

    Private Sub dgvDatos_CellEditCanceled(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.CellEditCanceled
        If dgvDatos.RowCount < 1 Then
        ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
        ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
        Else
            dgvDatos.CurrentRow.Cells("Despacho").Text = 0
        End If
    End Sub
    Private Sub dgvDatos_CellUpdated(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.CellUpdated
        'If toNumber(IdOrden) = 0 Then
        '    MsgBox("Debe Ingresar el código de la O.C.", MsgBoxStyle.Information, "Información")
        '    actualizar()
        'Else

        If toNumber(dgvDatos.CurrentRow.Cells("Despacho").Text) > toNumber(dgvDatos.CurrentRow.Cells("PenFac").Text) Then
            MsgBox("El cantidad a despachar esta fuera de rango.", MsgBoxStyle.Information, "Información")
            actualizar()
        End If
    End Sub

    Private Sub dgvPrueba_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrueba.CellEndEdit
        If toNumber(dgvPrueba.CurrentRow.Cells("Despacho").Value) > toNumber(dgvPrueba.CurrentRow.Cells("PenFac").Value) Then
            MsgBox("El cantidad a despachar esta fuera de rango.", MsgBoxStyle.Information, "Información")
            actualizar()
        Else
        End If
    End Sub

    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            'If dgvPrueba.Rows.Count > 0 Then
            '    If IsDBNull(dgvPrueba.CurrentRow.Cells(0).Value) = False Then
            '        codigo = dgvPrueba.CurrentRow.Cells("Item").Value
            '    End If
            'End If
            dtDatos = Nothing
            'listaDatos()
            If dgvPrueba.Rows.Count > 0 Then
                dgvPrueba.CurrentRow.Cells("Despacho").Value = 0
                'RowPossesion(dgvDatos, dtDatos, "Item", codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-04]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub setColor_BlankCombo(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                            cmbMedio.ValueChanged

        Try
            Dim campo As New Object
            If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.MultiColumnCombo" Then
                campo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
            End If
            campo = sender
            If toNumber(campo.value) <> 0 Or toNull(campo.Value) <> Nothing Then
                campo.BackColor = Color.White
            Else
                campo.BackColor = Color.Red
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    'Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
    '    If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
    '        e.KeyChar = Chr(0)
    '    End If
    'End Sub
    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        fila(1) = "(Ninguno)"
        Return fila
    End Function

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            Dim registro As New FacturaImportService.FacturaImport
            Dim serieImp As New FacturaImportService.SerieImportacion
            serieImp.IdSerieImp = IdSerieImp
            registro.SerieImportacion = serieImp
            registro.NumDoc = toNull(txtNumDoc.Text)
            If Len(Trim(txtNumDoc.Text)) = 0 Then
                MsgBox("Debe Ingresar el Invoice ", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
                'ElseIf toNumber(cmbPrecio.Value) = 0 Then
                '    MsgBox("Debe Ingresar el precio ", MsgBoxStyle.Information, "Información")
                '    cmbPrecio.BackColor = Color.Red
                '    cmbPrecio.Focus()
                '    Return False
            ElseIf toBlank(cmbMedio.Value) = "" Then
                MsgBox("Debe Ingresar el medio ", MsgBoxStyle.Information, "Información")
                cmbMedio.BackColor = Color.Red
                cmbMedio.Focus()
                Return False
            ElseIf toNumber(IdClienteSold) = 0 Then
                MsgBox("Debe Ingresar el Sold ", MsgBoxStyle.Information, "Información")
                txtSold.BackColor = Color.Red
                txtSold.Focus()
                Return False
            ElseIf toNumber(IdClienteShip) = 0 Then
                MsgBox("Debe Ingresar el Ship ", MsgBoxStyle.Information, "Información")
                txtShip.BackColor = Color.Red
                txtShip.Focus()
                Return False
            ElseIf toNumber(IdProvider) = 0 Then
                MsgBox("Debe Ingresar el Provider ", MsgBoxStyle.Information, "Información")
                txtProvider.BackColor = Color.Red
                txtProvider.Focus()
                Return False
            ElseIf toBlank(txtNroPqte.Text) = "" Then
                MsgBox("Debe Ingresar el Nro de Paquete", MsgBoxStyle.Information, "Información")
                txtNroPqte.Focus()
                Return False
            ElseIf toBlank(txtFecLlegadaMiami.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha de llegada a Miami", MsgBoxStyle.Information, "Información")
                txtFecLlegadaMiami.Focus()
                Return False
                'ElseIf toBlank(txtTerms.Text) = "" Then
                '    MsgBox("Debe Ingresar el Terms ", MsgBoxStyle.Information, "Información")
                '    txtTerms.BackColor = Color.Red
                '    txtTerms.Focus()
                '    Return False
                'ElseIf toBlank(txtMarks.Text) = "" Then
                '    MsgBox("Debe Ingresar la Marks ", MsgBoxStyle.Information, "Información")
                '    txtMarks.BackColor = Color.Red
                '    txtMarks.Focus()
                '    Return False
                'ElseIf toBlank(txtOrders.Text) = "" Then
                '    MsgBox("Debe Ingresar el Orders ", MsgBoxStyle.Information, "Información")
                '    txtOrders.BackColor = Color.Red
                '    txtOrders.Focus()
                '    Return False
                'ElseIf toNumber(cmbIdSerieImp.Value) = 0 Then
                '    MsgBox("Debe Ingresar el documento ", MsgBoxStyle.Information, "Información")
                '    cmbIdSerieImp.BackColor = Color.Red
                '    cmbIdSerieImp.Focus()
                '    Return False
            ElseIf state_button = False And oFacturaImportService.Buscar(registro) = True Then
                Select Case MsgBox("Ya existe el Numero de Invoice para este proveedor , ¿Está seguro de volver a registrarlo?", MsgBoxStyle.YesNo, "Advertencia")
                    Case MsgBoxResult.Yes
                        Return True
                    Case MsgBoxResult.No
                        txtNumDoc.Focus()
                        Return False
                End Select
                'ElseIf state_button = False And oFacturaImportService.Buscar(registro) = True Then
                '    MsgBox("Numero de Invoice ya existe...!", MsgBoxStyle.Information, "Información")
                '    txtNumDoc.Focus()
                '    Return False
                'ElseIf state_button = True And estado <> "GN" Then
                '    MsgBox("Ya no se puede modificar los datos...!" + vbCr + "Debido que ya no se encuentra en el estado generado...!!", MsgBoxStyle.Information, "Información")
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub llenarCombos()
        Try
            '======================================= PRECIOS ================================================
            'dtPrecios = New DataTable
            'dtPrecios.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            'dtPrecios.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            'dtPrecios.Rows.Add(New Object() {"3", "Lista"})
            'dtPrecios.Rows.Add(New Object() {"4", "Dist_Dom"})
            'dtPrecios.Rows.Add(New Object() {"5", "Dist_Int"})

            'cmbPrecio.DataSource = dtPrecios
            'cmbPrecio.DropDownList.DataMember = dtPrecios.Columns("nombre").ToString
            'cmbPrecio.DropDownList.DisplayMember = dtPrecios.Columns("nombre").ToString
            'cmbPrecio.DropDownList.ValueMember = dtPrecios.Columns("codigo").ToString
            'cmbPrecio.DropDownList.Columns(0).DataMember = dtPrecios.Columns("codigo").ToString
            'cmbPrecio.DropDownList.Columns(1).DataMember = dtPrecios.Columns("nombre").ToString
            'dtPrecios = Nothing
            '======================================= MEDIOS ================================================
            dtMedios = New DataTable
            dtMedios.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtMedios.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtMedios.Rows.Add(New Object() {"A", "Aéreo"}) ', New DateTime(2008, 2, 5)
            dtMedios.Rows.Add(New Object() {"M", "Marinos"})
            dtMedios.Rows.Add(New Object() {"O", "Otros"})

            cmbMedio.DataSource = dtMedios
            cmbMedio.DropDownList.DataMember = dtMedios.Columns("nombre").ToString
            cmbMedio.DropDownList.DisplayMember = dtMedios.Columns("nombre").ToString
            cmbMedio.DropDownList.ValueMember = dtMedios.Columns("codigo").ToString
            cmbMedio.DropDownList.Columns(0).DataMember = dtMedios.Columns("codigo").ToString
            cmbMedio.DropDownList.Columns(1).DataMember = dtMedios.Columns("nombre").ToString
            dtMedios = Nothing
            ''======================================= DOCUMENTOS ================================================
            'dtDocumentos = oMaestroService.MostrarSerieImportacion.Tables(0)
            'cmbIdSerieImp.DataSource = dtDocumentos
            'cmbIdSerieImp.DropDownList.DataMember = dtDocumentos.Columns("Descripcion").ToString
            'cmbIdSerieImp.DropDownList.DisplayMember = dtDocumentos.Columns("Descripcion").ToString
            'cmbIdSerieImp.DropDownList.ValueMember = dtDocumentos.Columns("IdSerieImp").ToString
            'cmbIdSerieImp.DropDownList.Columns(0).DataMember = dtDocumentos.Columns("IdSerieImp").ToString
            'cmbIdSerieImp.DropDownList.Columns(1).DataMember = dtDocumentos.Columns("Descripcion").ToString
            'cmbIdSerieImp.SelectedIndex = 0
            'dtDocumentos = Nothing

            '======================================= CONDICIONES DE PAGO ===========================================
            dtCondicionesPago = oProveedorService.MostrarCondicionPago.Tables(0)
            cmbCodPag.DataSource = dtCondicionesPago
            cmbCodPag.DropDownList.DataMember = dtCondicionesPago.Columns("NomCondicion").ToString
            cmbCodPag.DropDownList.DisplayMember = dtCondicionesPago.Columns("NomCondicion").ToString
            cmbCodPag.DropDownList.ValueMember = dtCondicionesPago.Columns("IdCondicion").ToString
            cmbCodPag.DropDownList.Columns(0).DataMember = dtCondicionesPago.Columns("IdCondicion").ToString
            cmbCodPag.DropDownList.Columns(1).DataMember = dtCondicionesPago.Columns("NomCondicion").ToString
            cmbCodPag.DropDownList.Columns(2).DataMember = dtCondicionesPago.Columns("DiasPago").ToString
            cmbCodPag.SelectedIndex = 0
            dtCondicionesPago = Nothing


        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub




    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnBuscarSold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarSold.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtSold.Text = frm.descripcion
            txtSold.BackColor = System.Drawing.SystemColors.Control
            IdClienteSold = frm.codigo
            listarCombosDirFiscalSold()
            'txtdireccionSold.Text = frm.direccion
        End If
        txtSold.Select()
    End Sub

    Private Sub listarCombosDirFiscalSold()
        '======================================= DIRECCIONES FISCALES ================================================

        dtLocaciones = oDireccionFiscalService.Mostrar(IdClienteSold).Tables(0)
        cmbIdFiscalSold.DataSource = dtLocaciones
        cmbIdFiscalSold.DropDownList.DataMember = dtLocaciones.Columns("Direccion").ToString
        cmbIdFiscalSold.DropDownList.DisplayMember = dtLocaciones.Columns("Direccion").ToString
        cmbIdFiscalSold.DropDownList.ValueMember = dtLocaciones.Columns("IdFiscal").ToString
        cmbIdFiscalSold.DropDownList.Columns(0).DataMember = dtLocaciones.Columns("IdFiscal").ToString
        cmbIdFiscalSold.DropDownList.Columns(1).DataMember = dtLocaciones.Columns("Direccion").ToString
        If dtLocaciones.Rows.Count > 0 Then
            cmbIdFiscalSold.SelectedIndex = 0
        Else
            cmbIdFiscalSold.Value = ""
        End If
    End Sub

    Private Sub btnBuscarShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarShip.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtShip.Text = frm.descripcion
            txtShip.BackColor = System.Drawing.SystemColors.Control
            IdClienteShip = frm.codigo
            listarCombosDirFiscalShip()
            'txtDireccionShip.Text = frm.direccion
        End If
        txtShip.Select()
    End Sub

    Private Sub listarCombosDirFiscalShip()
        '======================================= DIRECCIONES FISCALES ================================================

        dtLocaciones = oDireccionFiscalService.Mostrar(IdClienteShip).Tables(0)
        cmbIdFiscalShip.DataSource = dtLocaciones
        cmbIdFiscalShip.DropDownList.DataMember = dtLocaciones.Columns("Direccion").ToString
        cmbIdFiscalShip.DropDownList.DisplayMember = dtLocaciones.Columns("Direccion").ToString
        cmbIdFiscalShip.DropDownList.ValueMember = dtLocaciones.Columns("IdFiscal").ToString
        cmbIdFiscalShip.DropDownList.Columns(0).DataMember = dtLocaciones.Columns("IdFiscal").ToString
        cmbIdFiscalShip.DropDownList.Columns(1).DataMember = dtLocaciones.Columns("Direccion").ToString
        If dtLocaciones.Rows.Count > 0 Then
            cmbIdFiscalShip.SelectedIndex = 0
        Else
            cmbIdFiscalShip.Value = ""
        End If
    End Sub

    Private Sub btnBuscarProvider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProvider.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdProvider = frm.codigo
                    txtProvider.Text = frm.descripcion
                Else
                    IdProvider = 0
                    txtProvider.Text = ""
                End If
            End If
            txtProvider.Select()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Dim estado_process As Int64

        'Dim dtDatos As DataTable

        Try
            If MsgBox("¿Está seguro de Generar la factura?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
           And ValidaCampos() Then

                Dim registro As New PedidoImportService.FacturaImport
                Dim clienteShip As New PedidoImportService.Cliente
                Dim clienteShop As New PedidoImportService.Cliente
                Dim serieImp As New PedidoImportService.SerieImportacion
                Dim Proveedor As New PedidoImportService.Proveedor
                Dim direccionsold As New PedidoImportService.DireccionFiscal
                Dim direccionship As New PedidoImportService.DireccionFiscal
                Dim condicion As New PedidoImportService.CondicionPagoProveedor

                registro.IdFactura = 0
                serieImp.IdSerieImp = IdSerieImp
                registro.SerieImportacion = serieImp
                registro.NumDoc = txtNumDoc.Text 'Convert.ToInt64(txtNumDoc.Text)
                registro.FecDoc = txtFecDoc.Text
                clienteShop.IdCliente = IdClienteSold
                registro.ClienteSold = clienteShop
                clienteShip.IdCliente = IdClienteShip
                registro.ClienteShip = clienteShip
                Proveedor.IdProveedor = IdProvider
                direccionsold.IdFiscal = IIf(toNumber(cmbIdFiscalSold.Value) = 0, Nothing, cmbIdFiscalSold.Value)
                registro.DireccionFiscalSold = direccionsold
                direccionship.IdFiscal = IIf(toNumber(cmbIdFiscalShip.Value) = 0, Nothing, cmbIdFiscalShip.Value)
                registro.DireccionFiscalShip = direccionship
                registro.Proveedor = Proveedor
                condicion.IdCondicion = cmbCodPag.Value
                registro.CondicionPagoProveedor = condicion
                registro.Terms = txtTerms.Text
                registro.Marks = txtMarks.Text
                registro.Orders = txtOrders.Text
                registro.Medio = cmbMedio.Value
                registro.Gastos = 0.00
                registro.FleInt = txtFleInt.Text
                '----------------------- Agregado el 12/06/2014 (Cesar) ------------------------
                registro.TotOtroGasto = txtOtrosGastos.Value
                registro.TotDscto = 0
                '-------------------------------------------------------------------------------------
                registro.NroPaquete = txtNroPqte.Text
                registro.FecLlegadaMiami = txtFecLlegadaMiami.Value
                registro.TipCam = txttipocambio.Value
                registro.DepNuc = 0.00
                registro.GesCom = 0.00
                registro.Precio = "3"
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp


                ''============================================================================================================

                'Dim estado_process As Integer
                Dim dtTable As DataTable
                Dim row As DataRow

                dtTable = dtDatos.Copy
                dtTable.Clear()
                For i As Integer = 0 To dtDatos.Rows.Count - 1
                    If dgvPrueba.Rows(i).Cells("Despacho").Value > "0" Then
                        row = dtTable.NewRow
                        row(0) = dtDatos.Rows(i).Item(0)
                        row(1) = dtDatos.Rows(i).Item(1)
                        row(2) = dtDatos.Rows(i).Item(2)
                        row(3) = dtDatos.Rows(i).Item(3)
                        row(4) = dtDatos.Rows(i).Item(4)
                        row(5) = dtDatos.Rows(i).Item(5)
                        row(6) = dtDatos.Rows(i).Item(6)
                        row(7) = dtDatos.Rows(i).Item(7)
                        row(8) = dtDatos.Rows(i).Item(8)
                        row(9) = dtDatos.Rows(i).Item(9)
                        row(10) = dtDatos.Rows(i).Item(10)
                        row(11) = dtDatos.Rows(i).Item(11)
                        row(12) = dtDatos.Rows(i).Item(12)
                        row(13) = dtDatos.Rows(i).Item(13)
                        row(14) = dtDatos.Rows(i).Item(14)
                        row(15) = dtDatos.Rows(i).Item(15)
                        row(16) = dtDatos.Rows(i).Item(16)
                        row(17) = dtDatos.Rows(i).Item(17)
                        row(18) = dtDatos.Rows(i).Item(18)
                        row(19) = dtDatos.Rows(i).Item(19)
                        row(20) = dgvPrueba.Rows(i).Cells("Despacho").Value
                        'row(21) = dtDatos.Rows(i).Item(21)
                        'row(22) = dtDatos.Rows(i).Item(22)
                        'row(23) = dtDatos.Rows(i).Item(23)
                        'row(24) = dtDatos.Rows(i).Item(24)
                        dtTable.Rows.Add(row)
                    End If
                Next



                'Nuevo
                estado_process = oPedidoImport.GenerarFactura(IdPedidoImp, registro, dtTable)

                If estado_process > 0 Then
                    MsgBox("Se Generó correctamente la Factura N° : " + txtNumDoc.Text.ToString, MsgBoxStyle.Information)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el proceso, comuníquese con el administrador...!", MsgBoxStyle.Critical)
                End If

            End If


        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            txtNumDoc.Focus()
        End If
    End Sub

    Private Sub miActualizar_Click(sender As Object, e As EventArgs) Handles miActualizar.Click
        actualizar()
    End Sub
End Class
