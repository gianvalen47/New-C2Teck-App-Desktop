Public Class frmTransferenciasInterna

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMaestroService As New MaestroService.MaestroClient
    Private oDocumentoTransitoService As New DocumentoTransitoService.DocumentoTransitoServiceClient
    Private oDocumentoTransitoDetService As New DocumentoTransitoDetService.DocumentoTransitoDetServiceClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    'Public IdTransferencia As Integer
    Public IdTransito As Integer
    Private dtAlmacenes As DataTable
    Private dtTipoDocumentos As DataTable
    Private dtTipoMovimientos As DataTable
    Private dtMonedas As DataTable
    Private dtAreas As DataTable
    Private dtMotivos As DataTable

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                               txtNumDoc.KeyPress _
                             , txtUsuRec.KeyPress _
                             , txtFecIng.KeyPress
        ', txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmTransferenciasInterna_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnSalir_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloDataDrid(dgvPrueba)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvPrueba.ReadOnly = False

        dgvPrueba.Columns(0).ReadOnly = True
        dgvPrueba.Columns(1).ReadOnly = True
        dgvPrueba.Columns(2).ReadOnly = True
        dgvPrueba.Columns(3).ReadOnly = True
        dgvPrueba.Columns(4).ReadOnly = False
        dgvPrueba.Columns(5).ReadOnly = True
        dgvPrueba.Columns(6).ReadOnly = True
        dgvPrueba.Columns(7).ReadOnly = True
        'Me.CancelButton = Me.btnCancelar

        ObtenerRegistro()
        listaDatos()
        'dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
        'dgvDatos.RootTable.Columns(1).EditType = Janus.Windows.GridEX.EditType.NoEdit
        'dgvDatos.RootTable.Columns(2).EditType = Janus.Windows.GridEX.EditType.NoEdit
        'dgvDatos.RootTable.Columns(3).EditType = Janus.Windows.GridEX.EditType.NoEdit
        'dgvDatos.RootTable.Columns(4).EditType = Janus.Windows.GridEX.EditType.TextBox
        'dgvDatos.RootTable.Columns(5).EditType = Janus.Windows.GridEX.EditType.NoEdit
        'dgvDatos.RootTable.Columns(6).EditType = Janus.Windows.GridEX.EditType.NoEdit
        'dgvDatos.RootTable.Columns(7).EditType = Janus.Windows.GridEX.EditType.NoEdit

        'Activa o desactiva los botones o la modificación de las cantidades de recepción
        stateButton()
        txtFecIng.ReadOnly = True
        txtUsuRec.ReadOnly = True
        txtObservacion.ReadOnly = True
        btnGuardar.Enabled = False
        btnDeshacer.Enabled = False
    End Sub

    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oDocumentoTransitoService) = False Then
                oDocumentoTransitoService.Close()
            End If
            If isClosed(oDocumentoTransitoDetService) = False Then
                oDocumentoTransitoDetService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                           txtNumDoc.KeyUp _
                           , txtUsuRec.KeyUp
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

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
        Try
            tabla.DefaultView.Sort = nombreCampo
            lista.FirstRow = dtDatos.DefaultView.Find(codigo)
            lista.Row = dtDatos.DefaultView.Find(codigo)
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function getTotal(ByVal columna As String) As Double
        Dim total As Double = 0
        For i As Integer = 0 To dtDatos.Rows.Count - 1
            Dim r As DataRow
            r = dtDatos.Rows.Item(i)
            total = total + CDbl(r.Item(columna))
        Next
        Return total
    End Function

    Private Sub seleccionaTodos(ByVal condicion As Boolean)
        For i As Integer = 0 To dtDatos.Rows.Count - 1
            If condicion = True Then
                dgvPrueba.Rows(i).Cells("CanRec").Value = dgvPrueba.Rows(i).Cells("CanMer").Value
                ModificarItem(i)
            Else
                dgvPrueba.Rows(i).Cells("CanRec").Value = 0
                oDocumentoTransitoDetService.Actualizar(dgvPrueba.Rows(i).Cells(0).Value,  0)
            End If
        Next

        '' Agregado Grid para solucionar el problema de Grilla
        'For i As Integer = 0 To dtDatos.Rows.Count - 1
        '    If condicion = True Then
        '        dgvDatos.GetRow(i).Cells("CanRec").Text = dgvDatos.GetRow(i).Cells("CanMer").Text
        '        ModificarItem(i)
        '    Else
        '        dgvDatos.GetRow(i).Cells("CanRec").Text = 0
        '        oDocumentoTransitoDetService.Actualizar(dgvDatos.GetRow(i).Cells(0).Text, 0)
        '    End If
        'Next
    End Sub

    Public Sub stateButton()
        If state_button Then
            'btnTransferirDocumento.Enabled = False
            btnTrasladar.Enabled = False
            btnEditar.Enabled = False
            'btnEliminar.Enabled = False
            dgvPrueba.Columns(4).ReadOnly = True
            'dgvDatos.RootTable.Columns(4).EditType = Janus.Windows.GridEX.EditType.NoEdit
            miSeleccionarTodo.Enabled = False
            miSeterCEROTodos.Enabled = False
            miActualizar.Enabled = False
        Else
            'btnTransferirDocumento.Enabled = True
            btnTrasladar.Enabled = True
            btnEditar.Enabled = True
            'btnEliminar.Enabled = True
            dgvPrueba.Columns(4).ReadOnly = False
            'dgvDatos.RootTable.Columns(4).EditType = Janus.Windows.GridEX.EditType.TextBox
            miSeleccionarTodo.Enabled = True
            miSeterCEROTodos.Enabled = True
            miActualizar.Enabled = True
        End If
    End Sub

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdTransito) = 0 Then
                MsgBox("Debe Ingresar el número del documento.", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf toBlank(txtFecIng.Text) = "" Then
                MsgBox("Debe la fecha de recepción.", MsgBoxStyle.Information, "Información")
                txtFecIng.Focus()
                Return False
            ElseIf toBlank(txtUsuRec.Text) = "" Then
                MsgBox("Debe de ingresar por quien fue recepcionado.", MsgBoxStyle.Information, "Información")
                txtUsuRec.BackColor = Color.Red
                txtUsuRec.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Modificar(ByVal registro As DocumentoTransitoService.DocumentoTransito)
        Try
            Dim estado_process As Boolean
            estado_process = oDocumentoTransitoService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Timer1.Interval = 3000
                Timer1.Start()
                ToolTip1.IsBalloon = True
                ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
                ToolTip1.Show("Se grabaron los datos correctamente.!", lblRecibidoPor)
                desactivar()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If

        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oDocumentoTransitoService.Borrar(IdTransito)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ModificarItem(ByVal fila As Integer)
        Try
            'If dgvDatos.GetRow(fila).Cells("CanRec").Text > 0 Then
            '    oDocumentoTransitoDetService.Actualizar(dgvDatos.GetRow(fila).Cells(0).Text, dgvDatos.GetRow(fila).Cells("CanRec").Text)
            'End If

            If dgvPrueba.Rows(fila).Cells("CanRec").Value > 0 Then
                oDocumentoTransitoDetService.Actualizar(dgvPrueba.Rows(fila).Cells(0).Value, dgvPrueba.Rows(fila).Cells("CanRec").Value)
            End If

        Catch ex As Exception
            MsgBox("ERROR [INFO-0010]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.ToolTip1.IsBalloon = False
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None
        ToolTip1.Hide(lblRecibidoPor)
        Timer1.Stop()
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As DocumentoTransitoService.DocumentoTransito
            registro = oDocumentoTransitoService.MostrarPorId(toNumber(IdTransito))

            IdTransito = registro.IdTransito

            If registro.Tipo = 1 Then
                lblAlmacen.Text = registro.Locacion.Almacen.DesAlm + " - " + registro.Locacion.Oficina.DesOfi
                txtNumDoc.Text = toBlank(registro.Transferencia.NumDoc)
                lblFecha.Text = toBlank(registro.Transferencia.FecDoc)
                lblCliente.Text = toBlank(registro.Transferencia.Cliente.DesCli)
                lblMoneda.Text = toBlank(registro.Transferencia.Moneda.DesMon)
                lblJOb.Text = toBlank(registro.Transferencia.NumJob)
                Me.Text = "Transito de Transferencia interna Nº " + txtNumDoc.Text
                gbDatos.Text = "Transferencia Interna"
            ElseIf registro.Tipo = 2 Then
                lblAlmacen.Text = registro.Locacion.Almacen.DesAlm + " - " + registro.Locacion.Oficina.DesOfi
                txtNumDoc.Text = toBlank(registro.GuiaRemision.NumDoc)
                lblFecha.Text = toBlank(registro.GuiaRemision.FecDoc)
                lblCliente.Text = toBlank(registro.GuiaRemision.Cliente.DesCli)
                lblMoneda.Text = toBlank(registro.GuiaRemision.Moneda.DesMon)
                lblJOb.Text = toBlank(registro.GuiaRemision.NumJob)
                Me.Text = "Transito de Guía de Remisión Nº " + txtNumDoc.Text
                gbDatos.Text = "Guía de Remisión"
            End If

            If oDocumentoTransitoService.ValidarIngreso(IdTransito) = True Then
                Dim documento As DocumentoTransitoService.DocumentoTransito
                documento = oDocumentoTransitoService.MostrarPorId(IdTransito)
                txtFecIng.Text = documento.FecIng
                txtUsuRec.Text = documento.UsuRec
                txtObservacion.Text = documento.Observacion
                state_button = documento.Recibido
            Else
                state_button = False
            End If

        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            dtDatos = oDocumentoTransitoDetService.Mostrar(IdTransito).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)
            'dgvprueba agregado para solucionar el problema de columna de grill (Seleccionar Todos)
            dgvPrueba.DataSource = dtDatos

            txtTotalPrecio.Text = getTotal("PreMer")
            txtTotalDescuento.Text = getTotal("DscMer")
            txtTotalNeto.Text = getTotal("TotalFila")

        Catch ex As Exception
            MsgBox("ERROR [INFO-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvPrueba.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvPrueba.CurrentRow.Cells(0).Value < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-05]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvPrueba.RowCount > 0 Then

                If IsDBNull(dgvPrueba.CurrentRow.Cells(0).Value) = False Then
                    codigo = dgvPrueba.CurrentRow.Cells("CodMer").Value
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvPrueba.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, dtDatos, "CodMer", codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-06]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Public Function actualizaListaDetalle() As Integer
        Dim nroItem As Integer = 0
        For i As Integer = 0 To dtDatos.Rows.Count - 1
            dtDatos.Rows(i).Item(6) = dgvPrueba.Rows(i).Cells("CanRec").Value
            If toNumber(dtDatos.Rows(i).Item(6)) > 0 Then
                nroItem = nroItem + 1
            End If
        Next
        Return nroItem
    End Function
    Private Sub activar()

        txtUsuRec.ReadOnly = False
        txtObservacion.ReadOnly = False
        txtFecIng.ReadOnly = False
        btnGuardar.Enabled = True
        btnEditar.Enabled = False
        btnDeshacer.Enabled = True
        btnTrasladar.Enabled = False
    End Sub
    Private Sub desactivar()
        txtUsuRec.ReadOnly = True
        txtObservacion.ReadOnly = True
        txtFecIng.ReadOnly = True
        btnGuardar.Enabled = False
        btnEditar.Enabled = True
        btnDeshacer.Enabled = False
        btnTrasladar.Enabled = True
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================


    Private Sub miSeleccionarTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeleccionarTodo.Click
        If dgvPrueba.Rows.Count > 0 Then
            seleccionaTodos(True)
        Else
            MsgBox(gbDatos.Text + ", no tienes ningún ítem como detalle, verificar…!!!", MsgBoxStyle.Information, "Información")
        End If
    End Sub
    Private Sub miSeterCEROTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeterCEROTodos.Click
        If dgvPrueba.Rows.Count > 0 Then
            seleccionaTodos(False)
        Else
            MsgBox(gbDatos.Text + ", no tienes ningún ítem como detalle, verificar…!!!", MsgBoxStyle.Information, "Información")
        End If
    End Sub

    Private Sub dgvDatos_EditModeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.EditModeChanged
        Try
            ModificarItem(dgvDatos.CurrentRow.RowIndex)

        Catch ex As Exception
            MsgBox("ERROR [INFO-0010]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnEditar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.MouseEnter
        sslError.Text = "Editar la Cabecera de la Transferencia Interna."
    End Sub

    Private Sub btnGuardar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.MouseEnter
        sslError.Text = "Grabar los Cambios Hechos en el Documento de Tránsito."
    End Sub
    Private Sub btnDeshacer_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeshacer.MouseEnter
        sslError.Text = "Deshacer los Cambios Hechos en la Cabecera del Documento de Tránsito."
    End Sub
    Private Sub btnSalir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario Documento de Tránsito."
    End Sub
    Private Sub btnTrasladar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrasladar.MouseEnter
        sslError.Text = "Trasladar a Otro Almacén."
    End Sub

    Private Sub miSeleccionar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeleccionarTodo.MouseEnter
        sslError.Text = "Seleccionar Todos los Detalles Documento en Tránsito."
    End Sub
    Private Sub miTodos_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeterCEROTodos.MouseEnter
        sslError.Text = "Poner en Cero a Todos los Detalles del Documento en Tránsito."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        btnEditar.MouseLeave, _
        miSeleccionarTodo.MouseLeave, miSeterCEROTodos.MouseLeave, miActualizar.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        activar()
    End Sub

    Private Sub btnDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeshacer.Click
        If MsgBox("¿Desea Deshacer los Cambios Realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub btnTrasladar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrasladar.Click
        If dgvPrueba.Rows.Count > 0 Then
            If MsgBox("¿Está seguro de TRASLADAR el documento Nº " + txtNumDoc.Text + " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If oDocumentoTransitoService.ValidarIngreso(IdTransito) Then
                    If actualizaListaDetalle() > 0 Then
                        oDocumentoTransitoService.TrasladarDocumento(IdTransito, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        state_button = toBoolean(oMaestroService.MostrarDato("SIGECOM.Almacen.DocumentoTransito", "Recibido", "IdTransito", IdTransito))
                        stateButton()
                        type_process = "update"
                        listaDatos()
                        MsgBox("Se trasladó el documento correctamente de Nº " + txtNumDoc.Text + ".", MsgBoxStyle.Information)
                    Else
                        MsgBox("Debe recepcionar por lo menos un item.", MsgBoxStyle.Exclamation)
                    End If
                Else
                    MsgBox("Debe de registrar la fecha y quien recepciono el documento.", MsgBoxStyle.Exclamation)
                End If
            End If
        Else
            MsgBox(gbDatos.Text + ", no tienes ningún ítem como detalle, verificar…!!!", MsgBoxStyle.Information, "Información")
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then
            Dim registro As New DocumentoTransitoService.DocumentoTransito
            registro.IdTransito = IdTransito
            registro.FecIng = txtFecIng.Text
            registro.UsuRec = toNull(txtUsuRec.Text)
            registro.Observacion = toNull(txtObservacion.Text)
            registro.CodUsu = toNull(Session.sCodUsu)
            Modificar(registro)
        End If
    End Sub


    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnGuardar.Enabled = True Then
                'btnGuardar.Focus()
                btnGuardar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub dgvPrueba_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrueba.CellEndEdit
        Try
            ModificarItem(dgvDatos.CurrentRow.RowIndex)
        Catch ex As Exception
            MsgBox("ERROR [INFO-0010]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class