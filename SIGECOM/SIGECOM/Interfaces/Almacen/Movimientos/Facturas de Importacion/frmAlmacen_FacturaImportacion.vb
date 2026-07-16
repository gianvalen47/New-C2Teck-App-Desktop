Imports System.Windows.Forms

Public Class frmAlmacen_FacturaImportacion


    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMaestroService As New MaestroService.MaestroClient
    Private oImportacionService As New ImportacionService.ImportacionServiceClient
    Private oImportacionDetService As New ImportacionDetService.ImportacionDetServiceClient
    Private oFacturaImportacion As New FacturaImportDetService.FacturaImportDetServiceClient
    Private oFacturaImportService As New FacturaImportService.FacturaImportServiceClient

    Private dtDatos As DataTable
    Private importacion As Boolean
    'Private IdDetPedidoImp As Integer
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdImportacion As Integer
    Public IdCliente As Integer
    Public idNumDoc As Int64
    Public IdLocacion As Integer
    Public IdProvider As Integer
    Public IdSerieimp As Integer
    Private estadoImportar_PI As Boolean = False

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarProveedor.Enabled = True Then
                btnBuscarProveedor_Click(sender, e)
                e.Handled = True
            Else
                dgvDatos.Select()
            End If
        End If
    End Sub
    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtNumDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumDoc.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarFacturaImportacion.Enabled = True Then
                btnBuscarPedidoImportacion_Click(sender, e)
                e.Handled = True
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            ComprobarFactura()
        End If
    End Sub

    Private Sub txtNumDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnBuscarProveedor.Select()
        End If
    End Sub
    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                      txtProveedor.KeyPress
        ', txtNumDoc.KeyPress
        ', txtFecDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtFecDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGuardar.Enabled = True Then
                biGuardar.Select()
                biGuardar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub frmAlmacen_FacturaImportacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            biSalir_Click(sender, e)
            e.Handled = True
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.CancelButton = Me.btnCancelar
        ToolTip1.SetToolTip(btnBuscarFacturaImportacion, "Buscar Factura de Importación")
        ToolTip1.SetToolTip(btnBuscarPedidoImportacion, "Buscar Pedido de Importación")

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        llenarCombos()
        If state_button Then    'Modificar
            'Me.btnGuardar.Location = New System.Drawing.Point(354, 81)
            'Me.btnEliminar.Location = New System.Drawing.Point(428, 81)
            gbEstado.Visible = True
            gbDetalles.Visible = True
            ObtenerRegistro()
            desactivar()
            enableOpciones()
            listaDatos()
            'btnVerDetalle.Visible = True

            If (lblEstado.Text = "GENERADO" Or lblEstado.Text = "GN") Then
                'btnGuardar.Enabled = True
                'btnTransferirAlmacen.Enabled = True
                rbSeleccionarTodos.Enabled = True
                rbSeleccionarTodos.Visible = True
                dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[True]
                dgvDatos.RootTable.Columns("CanMer").EditType = Janus.Windows.GridEX.EditType.TextBox
            Else
                'btnGuardar.Enabled = False
                'btnEliminar.Enabled = False
                'btnTransferirAlmacen.Enabled = False
                rbSeleccionarTodos.Enabled = False
                rbSeleccionarTodos.Visible = False                
                If lblEstado.Text = "TRANSITO" Or lblEstado.Text = "TR" Then
                    biEditar.Enabled = True
                    rbSeleccionarTodos.Enabled = True
                    rbSeleccionarTodos.Visible = True
                    dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[True]
                    dgvDatos.RootTable.Columns("CanMer").EditType = Janus.Windows.GridEX.EditType.TextBox
                Else
                    biEditar.Enabled = False
                    dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
                    dgvDatos.RootTable.Columns("CanMer").EditType = Janus.Windows.GridEX.EditType.NoEdit
                End If
            End If
            Me.Text = "Factura de Importación Nº " + Chr(34) + txtNumDoc.Text.ToString + Chr(34)
        Else                    'Nuevo

            'Me.btnGuardar.Location = New System.Drawing.Point(428, 81)
            gbEstado.Visible = False
            gbDetalles.Visible = False
            'btnVerDetalle.Visible = False
            'btnTransferirAlmacen.Visible = False
            biEditar.Enabled = False
            biSalir.Enabled = False
            txtNumDoc.Select()
            Me.Size = New System.Drawing.Point(630, 214)
            Me.Text = "Registrar Nueva Factura de Importación"
        End If

    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oImportacionService) = False Then
                oImportacionService.Close()
            End If
            If isClosed(oImportacionDetService) = False Then
                oImportacionDetService.Close()
            End If
            If isClosed(oFacturaImportacion) = False Then
                oFacturaImportacion.Close()
            End If
            If isClosed(oFacturaImportService) = False Then
                oFacturaImportService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumDoc.KeyUp
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
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdDetImportacion").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
        Else
            If state_button = True And (toBlank(lblEstado.Text) = "GENERADO" Or toBlank(lblEstado.Text) = "GN") Then
                miNuevo.Enabled = True
                miEliminar.Enabled = True
                miMostrar.Enabled = True
                miEliminar.Enabled = True

                If oMaestroService.MostrarDato("SIGECOM.Almacen.Importaciones", "IdFactura", "IdImportacion", IdImportacion) <> Nothing Then
                    miNuevo.Enabled = False
                    miEliminar.Enabled = False
                    estadoImportar_PI = False
                Else
                    miNuevo.Enabled = True
                    miEliminar.Enabled = True
                    estadoImportar_PI = True
                End If
            Else
                miNuevo.Enabled = False
                miEliminar.Enabled = False
                miMostrar.Enabled = False
                miActualizar.Enabled = False
            End If
        End If
    End Sub
    Private Sub seleccionaTodos(ByVal condicion As Boolean)
        For i As Integer = 0 To dtDatos.Rows.Count - 1
            If condicion = True Then
                dgvDatos.GetRow(i).Cells("CanMer").Text = dgvDatos.GetRow(i).Cells("CanFac").Text
                ModificarItem(i)
            Else
                dgvDatos.GetRow(i).Cells("CanMer").Text = 0
                oImportacionDetService.ChequearCantidad(dgvDatos.GetRow(i).Cells(0).Text, 0)
            End If
        Next
        listaDatos()
    End Sub

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtNumDoc.Text) = "" Then
                MsgBox("Debe Ingresar el número de la factura", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
                'ElseIf estadoImportar_PI = False And toNumber(IdLocacion) = 0 Then
                '  MsgBox("Debe Ingresar la locación del factura", MsgBoxStyle.Information, "Información")
                '  txtalmacen.BackColor = Color.Red
                '  btnBuscarAlmacen.Focus()
                Return False
            ElseIf toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar del proveedor de la factura", MsgBoxStyle.Information, "Información")
                txtProveedor.BackColor = Color.Red
                btnBuscarProveedor.Focus()
                Return False
            ElseIf toNull(txtFecDoc.Text) = Nothing Then
                MsgBox("Debe Ingresar la fecha de la factura", MsgBoxStyle.Information, "Información")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
            ElseIf state_button = False And oImportacionService.Buscar(oImportacionService.MostrarSerieDocumentoId(IdLocacion), toNumber(txtNumDoc.Text)) = True Then
                Select Case MsgBox("Ya existe el Numero de Documento para este proveedor , ¿Está seguro de volver a registrarlo?", MsgBoxStyle.YesNo, "Advertencia")
                    Case MsgBoxResult.Yes
                        Return True
                    Case MsgBoxResult.No
                        txtNumDoc.Focus()
                        Return False
                End Select
                'ElseIf estadoImportar_PI = False And state_button = False And oImportacionService.Buscar(oImportacionService.MostrarSerieDocumentoId(IdLocacion), toNumber(txtNumDoc.Text)) = True Then
                '    MsgBox("El númedo de la factura " + txtNumDoc.Text + " ya existe...!", MsgBoxStyle.Information, "Información")
                '    txtNumDoc.Text = ""
                '    txtNumDoc.Focus()
                '    Return False
            ElseIf state_button = True And toBlank(lblEstado.Text) <> "GENERADO" And toBlank(lblEstado.Text) <> "TRANSITO" Then
                MsgBox("Pedido ya no se puede modificar...!" + vbCr + "Debido que ya no se encuentra en el estado generado...!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
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

    Private Sub Insertar(ByVal registro As ImportacionService.Importacion)
        Try
            Dim estado_process As Integer
            If estadoImportar_PI Then
                Try
                    estado_process = oImportacionService.IngresarFacturaImportacion(IdLocacion, IdCliente, txtFecDoc.Text, txtNumDoc.Text, txtObservacion.Text, idNumDoc, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    IdLocacion = oImportacionService.MostrarIdLocacion(estado_process)
                Catch ex As Exception
                    MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
                End Try
                importacion = oFacturaImportacion.BuscarCodigoSinTarjeta(idNumDoc)
                If importacion = True Then
                    frmAlmacen_FacturaImportacionGrilla.NumDocum = idNumDoc
                    If frmAlmacen_FacturaImportacionGrilla.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                        If frmAlmacen_FacturaImportacionGrilla.resultadoGrilla = True Then
                            estado_process = oImportacionService.IngresarFacturaImportacion(IdLocacion, IdCliente, txtFecDoc.Text, txtNumDoc.Text, txtObservacion.Text, idNumDoc, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        End If
                    End If
                End If
            Else
                estado_process = oImportacionService.Insertar(registro)
            End If
            type_process = "insert"
            If estado_process > 0 Then
                IdImportacion = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As ImportacionService.Importacion)
        Try
            Dim estado_process As Boolean
            estado_process = oImportacionService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                desactivar()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If

        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oImportacionService.Borrar(IdImportacion, Session.sCodUsu)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As ImportacionService.Importacion
            registro = oImportacionService.MostrarPorId(IdImportacion)
            IdImportacion = registro.IdImportacion
            txtNumDoc.Text = registro.NumDoc
            txtFecDoc.Text = registro.FecDoc
            IdCliente = registro.Proveedor.IdProveedor
            txtProveedor.Text = registro.Proveedor.DesProv
            txtObservacion.Text = registro.Observacion
            IdLocacion = registro.Locacion.IdLocacion
            'txtalmacen.Text = registro.SerieDocumento.Locacion.Almacen.DesAlm + "-" + registro.SerieDocumento.Locacion.Oficina.DesOfi
            lblEstado.Text = registro.Estado

        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            dtDatos = oImportacionDetService.Mostrar(IdImportacion).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [INFO-007]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmAlmacen_FacturaImportacion_AgregarDetalle
                frm.state_button = False
                frm.IdImportacion = IdImportacion
                frm.estado_pedido = "GN"
                'frm.IdDetPedidoImp = IdDetPedidoImp
                If dgvDatos.RowCount > 0 Then
                    frm.txtItem.Text = toNumber(dgvDatos.GetRow(dgvDatos.RowCount - 1).Cells("Item").Text) + 1
                Else
                    frm.txtItem.Text = 1
                End If
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdDetImportacion)
                        ' IdDetPedidoImp = frm.IdDetPedidoImp
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
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("CodMer").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oImportacionDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdDetImportacion").Text), IdImportacion)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
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
            Dim frm As New frmAlmacen_FacturaImportacion_AgregarDetalle
            frm.state_button = True
            frm.IdDetImportacion = dgvDatos.CurrentRow.Cells("IdDetImportacion").Text
            frm.IdImportacion = IdImportacion
            frm.txtDescripcion.Text = dgvDatos.CurrentRow.Cells("IdDetImportacion").Text
            frm.estado_pedido = toBlank(lblEstado.Text)

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdDetImportacion)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-010]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                codigo = dgvDatos.CurrentRow.Cells("IdDetImportacion").Text
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-012]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ModificarItem(ByVal fila As Integer)
        Try
            If dgvDatos.GetRow(fila).Cells("CanMer").Text >= 0 Then
                oImportacionDetService.ChequearCantidad(dgvDatos.GetRow(fila).Cells(0).Text, dgvDatos.GetRow(fila).Cells("CanMer").Text)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-0010]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            If toNumber(IdImportacion) > 0 Then
                Eliminar()
            Else
                MsgBox("Debe Ingresar el Código...!!!", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
            End If
        End If
    End Sub

    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Dim frm As New frmBuscarProveedor
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtProveedor.Text = frm.descripcion
            txtProveedor.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If
        txtProveedor.Select()
    End Sub

    Private Sub btnAgregarContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        NuevoDetalle()
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
        NuevoDetalle()
    End Sub
    Private Sub activar()

        If (lblEstado.Text = "TRANSITO" Or lblEstado.Text = "TR") Then
            btnBuscarProveedor.Enabled = False
            txtFecDoc.Enabled = False
        Else
            btnBuscarProveedor.Enabled = True
            txtFecDoc.Enabled = True
        End If
        'btnBuscarProveedor.Enabled = True
        'txtFecDoc.ReadOnly = False
        'txtFecDoc.Enabled = True
        txtObservacion.ReadOnly = False
        biGuardar.Enabled = True
        biEditar.Enabled = False
        biDeshacer.Enabled = True

        If (lblEstado.Text = "GENERADO" Or lblEstado.Text = "GN") Then
            ComprobarFactura()
        End If

    End Sub

    Private Sub ComprobarFactura()
        Dim registro As New FacturaImportService.FacturaImport
        Dim registro2 As New FacturaImportService.FacturaImport
        Dim serieImp As New FacturaImportService.SerieImportacion
        Dim IdFactura As Integer
        serieImp.IdSerieImp = 1
        registro.SerieImportacion = serieImp
        registro.NumDoc = toNull(txtNumDoc.Text)

        If oFacturaImportService.Buscar(registro) = True Then
            btnBuscarProveedor.Enabled = False

            IdFactura = oFacturaImportService.ObtenerIdFactura(1, txtNumDoc.Text)
            registro2 = oFacturaImportService.MostrarPorId(IdFactura)

            IdCliente = registro2.Proveedor.IdProveedor
            txtProveedor.Text = registro2.Proveedor.DesProv

        Else
            btnBuscarProveedor.Enabled = True
        End If
    End Sub

    Private Sub desactivar()
        gbEstado.Visible = True
        biGuardar.Enabled = False
        biDeshacer.Enabled = False
        btnBuscarFacturaImportacion.Enabled = False
        btnBuscarPedidoImportacion.Enabled = False
        btnBuscarProveedor.Enabled = False
        txtNumDoc.ReadOnly = True
        'txtFecDoc.ReadOnly = True
        txtFecDoc.Enabled = False
        txtProveedor.ReadOnly = True
        btnBuscarProveedor.Enabled = False
        txtObservacion.ReadOnly = True
        biEditar.Enabled = True
        biDeshacer.Enabled = False
        biGuardar.Enabled = False
    End Sub
    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub
    Private Sub dgvDatos_EditModeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.EditModeChanged
        Try
            ModificarItem(dgvDatos.CurrentRow.RowIndex)
        Catch ex As Exception
            MsgBox("ERROR [INFO-0010]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub dgvDatos_CellUpdated(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.CellUpdated
        Try
            ModificarItem(dgvDatos.CurrentRow.RowIndex)
        Catch ex As Exception
            MsgBox("ERROR [INFO-0010]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub rbSeleccionrTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSeleccionarTodos.CheckedChanged
        seleccionaTodos(rbSeleccionarTodos.Checked)
    End Sub
    Private Sub btnBuscarPedidoImportacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarFacturaImportacion.Click
        Dim frm As New frmBuscarFacruraImportacion
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            'txtNumDoc.BackColor = System.Drawing.SystemColors.Control
            txtNumDoc.Text = frm.numero
            idNumDoc = frm.codigo
            IdCliente = frm.IdProveedor
            txtProveedor.Text = frm.DesProv
            estadoImportar_PI = True
            'IdProvider = frm.IdProveedor
            'txtProveedor.Text = frm.DesProv
            IdSerieimp = frm.IdSerieImp

        End If
        txtNumDoc.Select()

        Dim registro As New FacturaImportService.FacturaImport
        Dim serieImp As New FacturaImportService.SerieImportacion
        serieImp.IdSerieImp = IdSerieimp
        registro.SerieImportacion = serieImp
        registro.NumDoc = toNull(txtNumDoc.Text)

        If oFacturaImportService.Buscar(registro) = True Then
            btnBuscarProveedor.Enabled = False
        Else
            btnBuscarProveedor.Enabled = True
        End If

    End Sub

    Public Function validaCantidades() As Integer
        listaDatos()
        Dim nroItem As Integer = 0
        For i As Integer = 0 To dtDatos.Rows.Count - 1
            dtDatos.Rows(i).Item(6) = dgvDatos.GetRow(i).Cells("CanMer").Text
            If toNumber(dtDatos.Rows(i).Item(6)) > 0 Then
                nroItem = nroItem + 1
            End If
        Next
        Return nroItem
    End Function

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
      And ValidaCampos() Then

            Dim registro As New ImportacionService.Importacion
            Dim proveedor As New ImportacionService.Proveedor
            Dim serie As New ImportacionService.SerieDocumento
            Dim moneda As New ImportacionService.Moneda
            Dim locacion As New ImportacionService.Locacion

            registro.IdImportacion = IdImportacion           
            registro.NumDoc = txtNumDoc.Text.ToString
            registro.FecDoc = txtFecDoc.Text
            proveedor.IdProveedor = IdCliente
            registro.Proveedor = proveedor
            'If estadoImportar_PI = False Then
            locacion.IdLocacion = IdLocacion
            registro.Locacion = locacion
            serie.IdSerieDoc = oImportacionService.MostrarSerieDocumentoId(IdLocacion)
            'End If
            registro.SerieDocumento = serie
            moneda.CodMon = "US"
            registro.Moneda = moneda
            registro.CodUsu = Session.sCodUsu
            registro.Observacion = txtObservacion.Text

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                biEditar.MouseLeave, biGuardar.MouseLeave, biDeshacer.MouseLeave, biSalir.MouseLeave, _
                                miNuevo.MouseLeave, miMostrar.MouseLeave, miEliminar.MouseLeave, miActualizar.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub biGuardar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.MouseEnter
        sslError.Text = "Grabar los cambios hechos en la Factura de Importación."
    End Sub
    Private Sub biDeshacer_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.MouseEnter
        sslError.Text = "Deshacer los Cambios Hechos en la Factura de Importación."
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario Factura de Importación."
    End Sub

    Private Sub biEditar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.MouseEnter
        sslError.Text = "Editar la Cabecera de la Factura de Importación."
    End Sub

    Private Sub miNuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Detalle en la Factura de Importación."
    End Sub
    Private Sub miMostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.MouseEnter
        sslError.Text = "Modificar Detalle actual."
    End Sub
    Private Sub miEliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.MouseEnter
        sslError.Text = "Eliminar Detalle actual."
    End Sub
    Private Sub miActualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.MouseEnter
        sslError.Text = "Actualizar Detalles de la Factura de Importación."
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub biEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.Click
        activar()
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub btnAgregarPedido_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPedidoImportacion.Click
        Try
            If txtNumDoc.Text = "" Then
                MsgBox("Debe ingresar el Número de Factura...!")
            ElseIf IdCliente = 0 Then
                MsgBox("Debe ingresar el Proveedor...!")
            Else
                Dim frm As New frmBuscarPedidoImportacion
                frm.IdLocacion = IdLocacion
                frm.IdProveedor = IdCliente
                frm.DesProv = txtProveedor.Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    Dim estado_process As Integer = 1
                    estado_process = oImportacionService.IngresarPedido(frm.IdLocacion, IdCliente, txtFecDoc.Value, txtNumDoc.Text, frm.codigo, Session.sCodUsu)
                    If estado_process > 0 Then
                        type_process = "insert"
                        IdImportacion = estado_process
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("Error al ingresar Pedido...!")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL AGREGAR PEDIDO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class
