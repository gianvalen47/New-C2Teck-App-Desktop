Imports System.Windows.Forms

Public Class frmDocumento

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMaestroService As New MaestroService.MaestroClient
    Private oFacturaImportService As New FacturaImportService.FacturaImportServiceClient
    Private oFacturaImportDetService As New FacturaImportDetService.FacturaImportDetServiceClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public dtDocumentos As DataTable
    Public dtPrecios As DataTable
    Public dtMedios As DataTable

    Public IdFactura As String
    Private IdClienteSold As String
    Private IdClienteShip As String
    Public estado As String
    Private Referencia As String
    Private Subtotal As Double
    Public IdSerieImp As String

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


    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            cmbPrecio.KeyPress _
                          , txtOrders.KeyPress _
                          , txtMarks.KeyPress _
                          , txtFecDoc.KeyPress _
                          , txtNumDoc.KeyPress _
                          , txtTerms.KeyPress _
                          , txtDireccionShip.KeyPress _
                          , txtdireccionSold.KeyPress _
                          , txtShip.KeyPress _
                          , txtGastos.KeyPress _
                          , txtDepNuc.KeyPress _
                          , txtGesCom.KeyPress _
                          , txtFleInt.KeyPress _
                          , txtTotalNeto.KeyPress
        ', txtSold.KeyPress _
        ', cmbMedio.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub frmDocumento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            biSalir_Click(sender, e)
            e.Handled = True
        End If
    End Sub
    Private Sub txtGastos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGastos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGuardar.Enabled = True Then
                biGuardar.Select()
                biGuardar_Click(sender, e)
            Else
                dgvDatos.Select()
            End If
        End If
    End Sub
    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown

        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                dgvDatos_DoubleClick(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.CancelButton = Me.btnCancelar
        llenarCombos()
        'Me.Size = New System.Drawing.Size(710, 254)
        If state_button Then    'Modificar
            'Me.btnGuardar.Location = New System.Drawing.Point(469, 192)
            'Me.btnEliminar.Location = New System.Drawing.Point(543, 192)
            txtNumDoc.ReadOnly = True
            txtNumDoc.TabStop = False
            ObtenerRegistro()
            'btnVerDetalle.Visible = True
            'biModificarReferencia.Enabled = True
            btnBuscarShip.Enabled = False
            btnBuscarSold.Enabled = False
            txtTerms.ReadOnly = True
            txtMarks.ReadOnly = True
            txtOrders.ReadOnly = True
            txtFecDoc.ReadOnly = True
            cmbPrecio.ReadOnly = True
            cmbMedio.ReadOnly = True
            txtDepNuc.ReadOnly = True
            txtFleInt.ReadOnly = True
            txtGesCom.ReadOnly = True
            txtGastos.ReadOnly = True
            biGuardar.Enabled = False
            biDeshacer.Enabled = False
            listaDatos()
            enableOpciones()
            dgvDatos.Select()
            Me.Text = "Documento Nº " + Chr(34) + txtNumDoc.Text.ToString + Chr(34)
        Else                    'Nuevo
            'btnEliminar.Visible = False
            'Me.btnGuardar.Location = New System.Drawing.Point(543, 192)
            txtNumDoc.ReadOnly = False
            txtNumDoc.TabStop = True
            'btnVerDetalle.Visible = False
            biModificarReferencia.Enabled = False
            biGenerarDocumento.Enabled = False
            biEditar.Enabled = False
            biSalir.Enabled = False
            gbTotal.Visible = False

            Me.Size = New System.Drawing.Size(710, 280)
            Me.Text = "Registrar nuevo Documento"
        End If
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oFacturaImportService) = False Then
                oFacturaImportService.Close()
            End If
            If isClosed(oFacturaImportDetService) = False Then
                oFacturaImportDetService.Close()
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
                          , txtNumDoc.KeyUp _
                          , txtTerms.KeyUp _
                          , txtDireccionShip.KeyUp _
                          , txtdireccionSold.KeyUp _
                          , txtShip.KeyUp _
                          , txtGastos.KeyUp _
                          , txtDepNuc.KeyUp _
                          , txtGesCom.KeyUp _
                          , txtFleInt.KeyUp _
                          , txtTotalNeto.KeyUp
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

   
    Private Sub setColor_BlankCombo(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                            cmbMedio.ValueChanged _
                         , cmbPrecio.ValueChanged
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
    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub
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
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
        Try
            tabla.DefaultView.Sort = nombreCampo
            'lista.FirstRow = dtDatos.DefaultView.Find(codigo)
            lista.Row = dtDatos.DefaultView.Find(codigo)
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            biGenerarDocumento.Enabled = False

        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = True
        End If
        If state_button = True And (toBlank(estado) = "GENERADO" Or toBlank(estado) = "GN") Then
            miNuevo.Enabled = True
            miActualizar.Enabled = True

        Else
            miNuevo.Enabled = False
            miActualizar.Enabled = False
            'miMostrar.Enabled = False
            miEliminar.Enabled = False

            biEditar.Enabled = False
            biGenerarDocumento.Enabled = False
            biModificarReferencia.Enabled = False



        End If
    End Sub
    Private Function SumarSubTotal(ByVal campo As String, ByVal nro_columna As Integer) As Double
        Dim total As Double = 0
        For i As Integer = 0 To dtDatos.Rows.Count - 1
            Dim r As DataRow
            r = dtDatos.Rows.Item(i)
            total = total + CDbl(r.Item(nro_columna))
        Next
        Return total
    End Function
    Private Function calculateTotal() As Double
        dtDatos = Nothing
        dtDatos = oFacturaImportDetService.Mostrar(toNumber(IdFactura)).Tables(0)
        txtTotalNeto.Text = toDouble(txtFleInt.Text) + toDouble(txtGesCom.Text) + toDouble(txtDepNuc.Text) + toDouble(txtGastos.Text) + SumarSubTotal("Total", 20)
        dtDatos = Nothing
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
            If toNumber(txtNumDoc.Text) = 0 Then
                MsgBox("Debe Ingresar el Invoice ", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
            ElseIf toNumber(cmbPrecio.Value) = 0 Then
                MsgBox("Debe Ingresar el precio ", MsgBoxStyle.Information, "Información")
                cmbPrecio.BackColor = Color.Red
                cmbPrecio.Focus()
                Return False
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
            ElseIf toBlank(txtTerms.Text) = "" Then
                MsgBox("Debe Ingresar el Terms ", MsgBoxStyle.Information, "Información")
                txtTerms.BackColor = Color.Red
                txtTerms.Focus()
                Return False
            ElseIf toBlank(txtMarks.Text) = "" Then
                MsgBox("Debe Ingresar la Marks ", MsgBoxStyle.Information, "Información")
                txtMarks.BackColor = Color.Red
                txtMarks.Focus()
                Return False
            ElseIf toBlank(txtOrders.Text) = "" Then
                MsgBox("Debe Ingresar el Orders ", MsgBoxStyle.Information, "Información")
                txtOrders.BackColor = Color.Red
                txtOrders.Focus()
                Return False
                'ElseIf toNumber(cmbIdSerieImp.Value) = 0 Then
                '    MsgBox("Debe Ingresar el documento ", MsgBoxStyle.Information, "Información")
                '    cmbIdSerieImp.BackColor = Color.Red
                '    cmbIdSerieImp.Focus()
                '    Return False
            ElseIf state_button = False And oFacturaImportService.Buscar(registro) = True Then
                MsgBox("Numero de Invoice ya existe...!", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf state_button = True And estado <> "GN" Then
                MsgBox("Ya no se puede modificar los datos...!" + vbCr + "Debido que ya no se encuentra en el estado generado...!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As FacturaImportService.FacturaImport)
        Try
            Dim estado_process As Integer
            estado_process = oFacturaImportService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdFactura = estado_process
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As FacturaImportService.FacturaImport)
        Try
            Dim estado_process As Boolean
            estado_process = oFacturaImportService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Eliminar(ByVal registro As FacturaImportService.FacturaImport)
        Try
            Dim estado_process As Boolean
            estado_process = oFacturaImportService.Borrar(registro)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As FacturaImportService.FacturaImport
            registro = oFacturaImportService.MostrarPorId(toNumber(IdFactura))

            IdFactura = registro.IdFactura
            IdSerieImp = registro.SerieImportacion.IdSerieImp
            txtNumDoc.Text = registro.NumDoc
            txtFecDoc.Text = registro.FecDoc
            IdClienteSold = registro.ClienteSold.IdCliente
            txtSold.Text = registro.ClienteSold.DesCli
            txtdireccionSold.Text = registro.ClienteSold.DirCli
            IdClienteShip = registro.ClienteShip.IdCliente
            txtShip.Text = registro.ClienteShip.DesCli
            txtDireccionShip.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.Clientes", "DirCli", "IdCliente", IdClienteShip)
            txtDireccionShip.Text = registro.ClienteShip.DirCli
            txtTerms.Text = registro.Terms
            txtMarks.Text = registro.Marks
            txtOrders.Text = registro.Orders
            cmbMedio.Value = registro.Medio
            txtGastos.Text = registro.Gastos
            txtFleInt.Text = registro.FleInt
            txtDepNuc.Text = registro.DepNuc
            txtGesCom.Text = registro.GesCom
            txtTotalNeto.Text = registro.TotalNeto
            Referencia = registro.Referencia
            cmbPrecio.Value = registro.Precio
            estado = registro.Estado
            Subtotal = registro.Total


        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= PRECIOS ================================================
            dtPrecios = New DataTable
            dtPrecios.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtPrecios.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtPrecios.Rows.Add(New Object() {"3", "Dealer"})
            dtPrecios.Rows.Add(New Object() {"4", "Dist_Dom"})
            dtPrecios.Rows.Add(New Object() {"5", "Dist_Int"})

            cmbPrecio.DataSource = dtPrecios
            cmbPrecio.DropDownList.DataMember = dtPrecios.Columns("nombre").ToString
            cmbPrecio.DropDownList.DisplayMember = dtPrecios.Columns("nombre").ToString
            cmbPrecio.DropDownList.ValueMember = dtPrecios.Columns("codigo").ToString
            cmbPrecio.DropDownList.Columns(0).DataMember = dtPrecios.Columns("codigo").ToString
            cmbPrecio.DropDownList.Columns(1).DataMember = dtPrecios.Columns("nombre").ToString
            dtPrecios = Nothing
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
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            dtDatos = oFacturaImportDetService.Mostrar(toNumber(IdFactura)).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)

            txtTotal.Text = oMaestroService.MostrarDato("SIGECOM.Importaciones.FacturaImport", "Total", "IdFactura", IdFactura)
            txtTotalNeto.Text = oMaestroService.MostrarDato("SIGECOM.Importaciones.FacturaImport", "TotalNeto", "IdFactura", IdFactura)

            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [INFO-007]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmAgregarDetalle_Documento
                frm.state_button = False
                frm.IdFactura = IdFactura
                frm.precioEvaluado = cmbPrecio.Value
                If dgvDatos.RowCount > 0 Then
                    frm.txtItem.Text = toNumber(dgvDatos.GetRow(dgvDatos.RowCount - 1).Cells("Item").Text) + 1
                Else
                    frm.txtItem.Text = 1
                End If

                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    dgvDatos.DataSource = Nothing
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, dtDatos, "IdDetFactura", frm.IdDetFactura)
                    End If
                Else
                    lLog = False
                End If
            End While
           
        Catch ex As Exception
            MsgBox("ERROR [INFO-008]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("CodMer").Text.ToString, MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                Dim registro As New FacturaImportDetService.FacturaImportDet
                Dim facturaImport As New FacturaImportDetService.FacturaImport

                registro.IdDetFactura = CInt(dgvDatos.CurrentRow.Cells("IdDetFactura").Text)
                facturaImport.IdFactura = IdFactura
                registro.FacturaImport = facturaImport
                estado_process = oFacturaImportDetService.Borrar(registro)

                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se elimino correctamente el registro...!!!", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-009]:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmAgregarDetalle_Documento
            frm.state_button = True
            frm.IdDetFactura = dgvDatos.CurrentRow.Cells("IdDetFactura").Text
            frm.IdFactura = IdFactura
            frm.estado = estado
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                dgvDatos.DataSource = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, dtDatos, "IdDetFactura", frm.IdDetFactura)
                Else
                    MsgBox("Se elimino el registro correctamente...!!!", MsgBoxStyle.Information)
                End If

            End If

        Catch ex As Exception
            MsgBox("ERROR [INFO-010]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-011]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                codigo = dgvDatos.CurrentRow.Cells("IdDetFactura").Text
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, dtDatos, "IdDetFactura", codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-012]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub activar()
        btnBuscarShip.Enabled = True
        btnBuscarSold.Enabled = True
        txtTerms.ReadOnly = False
        txtMarks.ReadOnly = False
        txtOrders.ReadOnly = False
        txtFecDoc.ReadOnly = False
        cmbPrecio.ReadOnly = False
        cmbMedio.ReadOnly = False
        txtDepNuc.ReadOnly = False
        txtFleInt.ReadOnly = False
        txtGesCom.ReadOnly = False
        txtGastos.ReadOnly = False

        biGuardar.Enabled = True
        biEditar.Enabled = False
        biDeshacer.Enabled = True

    End Sub
    Private Sub desactivar()
        btnBuscarShip.Enabled = False
        btnBuscarSold.Enabled = False
        txtTerms.ReadOnly = True
        txtMarks.ReadOnly = True
        txtOrders.ReadOnly = True
        txtFecDoc.ReadOnly = True
        cmbPrecio.ReadOnly = True
        cmbMedio.ReadOnly = True
        txtDepNuc.ReadOnly = True
        txtFleInt.ReadOnly = True
        txtGesCom.ReadOnly = True
        txtGastos.ReadOnly = True

        biGuardar.Enabled = False
        biEditar.Enabled = True
        biDeshacer.Enabled = False
    End Sub
    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnBuscarSold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarSold.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtSold.Text = frm.descripcion
            txtSold.BackColor = System.Drawing.SystemColors.Control
            IdClienteSold = frm.codigo
            txtdireccionSold.Text = frm.direccion
        End If
        txtSold.Select()
    End Sub
    Private Sub btnBuscarShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarShip.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtShip.Text = frm.descripcion
            txtShip.BackColor = System.Drawing.SystemColors.Control
            IdClienteShip = frm.codigo
            txtDireccionShip.Text = frm.direccion
        End If
        txtShip.Select()
    End Sub
    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub
    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminarDetalle()
        End If
    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()
    End Sub
    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        If state_button = True And (toBlank(estado) = "GENERADO" Or toBlank(estado) = "GN") Then
            NuevoDetalle()
        End If
    End Sub
    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub
    'Private Sub cmbIdSerieImp_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIdSerieImp.ValueChanged
    '    txtNumDoc.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.SerieImportacion", "NumDoc", "IdSerieImp", IdSerieImp)
    'End Sub
    
    Private Sub calculatetolta_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                           txtGastos.KeyUp _
                          , txtDepNuc.KeyUp _
                          , txtGesCom.KeyUp _
                          , txtFleInt.KeyUp

        Try
            calculateTotal()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
   

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
           And ValidaCampos() Then

            Dim registro As New FacturaImportService.FacturaImport
            Dim clienteShip As New FacturaImportService.Cliente
            Dim clienteShop As New FacturaImportService.Cliente
            Dim serieImp As New FacturaImportService.SerieImportacion

            registro.IdFactura = IdFactura
            serieImp.IdSerieImp = IdSerieImp
            registro.SerieImportacion = serieImp
            registro.NumDoc = txtNumDoc.Text
            registro.FecDoc = txtFecDoc.Text
            clienteShop.IdCliente = IdClienteSold
            registro.ClienteSold = clienteShop
            clienteShip.IdCliente = IdClienteShip
            registro.ClienteShip = clienteShip
            registro.Terms = txtTerms.Text
            registro.Marks = txtMarks.Text
            registro.Orders = txtOrders.Text
            registro.Medio = cmbMedio.Value
            registro.Gastos = txtGastos.Text
            registro.FleInt = txtFleInt.Text
            registro.DepNuc = txtDepNuc.Text
            registro.GesCom = txtGesCom.Text
            registro.Precio = cmbPrecio.Value

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        If MsgBox("Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub biGenerarDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerarDocumento.Click
        Try
            Dim frm As New frmGenerarDocumento
            frm.IdFactura = IdFactura
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                If MsgBox("Se genero el Documento " + toBlank(frm.txtNumDoc.Text) + " ( " + oMaestroService.MostrarDato("SIGECOM.Maestro.SerieImportacion", "Descripcion", "IdSerieImp", frm.cmbDocaumentos.Value) + " ) " _
                          & vbLf & " ¿Desea ir a documento generado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                    type_process = "generated"
                    tipoDocGenerated = frm.cmbDocaumentos.Value
                    NumeroDocGenerated = frm.txtNumDoc.Text
                    FacturaGenerated = frm.facturaGenerated
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End If
            End If

        Catch ex As Exception
            MsgBox("ERROR [GENERAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biModificarReferencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biModificarReferencia.Click
        Dim frm As New frmModicarReferencia
        frm.txtReferencia.Text = toBlank(Referencia)
        frm.estado_form = toBlank(estado)
        frm.IdFactura = IdFactura
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            Referencia = toBlank(frm.txtReferencia.Text)

        End If
    End Sub
    Private Sub biEditar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.MouseEnter
        sslError.Text = "Editar la Cabecera del Documento."
    End Sub

    Private Sub biGuardar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.MouseEnter
        sslError.Text = "Grabar los Cambios Hechos en el Documento."
    End Sub
    Private Sub biDeshacer_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.MouseEnter
        sslError.Text = "Deshacer los Cambios Hechos en la Cabecera del Documento."
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario Documento."
    End Sub
   
    Private Sub biGenerarDocumento_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerarDocumento.MouseEnter
        sslError.Text = "Generar Documento."
    End Sub
    Private Sub biModificarReferencia_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biModificarReferencia.MouseEnter
        sslError.Text = "Modificar Referencia ."
    End Sub
    Private Sub miNuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Detalle."
    End Sub
    Private Sub miMostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.MouseEnter
        sslError.Text = "Modificar Detalle Actual."
    End Sub
    Private Sub miEliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.MouseEnter
        sslError.Text = "Eliminar Detalle Actual."
    End Sub
    Private Sub miActualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.MouseEnter
        sslError.Text = "Actualizar Detalles del Formulario."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        biEditar.MouseLeave, biGuardar.MouseLeave, biSalir.MouseLeave, biDeshacer.MouseLeave, biGenerarDocumento.MouseLeave, _
        miNuevo.MouseLeave, miMostrar.MouseLeave, miEliminar.MouseLeave, miActualizar.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub biEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.Click
        activar()

    End Sub
    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        If MsgBox("Desea Deshacer los Cambios Realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()

            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub
End Class
