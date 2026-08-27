Imports System.Windows.Forms

Public Class frmPedido

  Public state_button As Boolean              'True: Modificar    False: nuevo
  Public type_process As String               'update     insert      delete
  Private oMaestroService As New MaestroService.MaestroClient
  Private oPedidoService As New PedidoService.PedidoServiceClient
    Private oPedidoDetService As New PedidoDetService.PedidoDetServiceClient
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
  Private dtDatos As DataTable
  '====================================================================================================================
  '============================================ PARAMETROS LOCALES ====================================================
  '====================================================================================================================
  Private dtSupervisores As DataTable

    Public IdLocacion As String
    Private DesLocacion As String
    Public IdCliente As String

    Private DirFile As String
    Private fileExt As String
    Private dtLimite As Integer
    Private Sub txtTecnico_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTecnico.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGuardar1.Enabled = True Then
                biGuardar1.Select()
                biGuardar1_Click(sender, e)
                e.Handled = True
            Else
                dgvDatos.Select()
            End If
        End If
    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.F12 Then
            If Button1.Enabled = True Then
                Button1_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtFecha.KeyPress _
                          , txtCliente.KeyPress _
                          , cmbIdPer.KeyPress _
                          , txtIdPedido.KeyPress _
                          , txtTotNeto.KeyPress _
                          , txtSerMot.KeyPress _
                          , txtNumJob.KeyPress _
                          , txtInterprete.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmPedido_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            biCerrar_Click(sender, e)
            e.Handled = True
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.CancelButton = Me.btnCancelar
        Dim estilo As New Estilo
        estilo.cargaEstiloDataDrid(dgvDatos)
        llenarCombos()

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        If state_button Then    'Modificar
            'Me.btnGuardar.Location = New System.Drawing.Point(445, 134)
            'Me.btnEliminar.Location = New System.Drawing.Point(519, 134)
            'Me.btnCancelar.Location = New System.Drawing.Point(593, 134)
            txtIdPedido.ReadOnly = True
            txtIdPedido.TabStop = False
            ObtenerRegistro()
            gbEstado.Visible = True
            gbTotal.Visible = True
            'btnVerDetalle.Visible = True
            'Me.gbDatos.Size = New System.Drawing.Size(661, 127)
            'Me.Size = New System.Drawing.Size(680, 196)
            btnBuscarCliente.Enabled = False
            cmbIdPer.ReadOnly = True
            cmbIdPer.BackColor = System.Drawing.SystemColors.Control
            txtTecnico.ReadOnly = True
            txtFecha.ReadOnly = True
            Button1.Enabled = False
            txtSerMot.ReadOnly = True
            txtInterprete.ReadOnly = True
            txtNumOrden.ReadOnly = True
            txtObservacion.ReadOnly = True

            listaDatos()
            dgvDatos.ReadOnly = False
            Me.cIdPedidoDet.ReadOnly = True
            Me.cCodMer.ReadOnly = True
            Me.cDesMer.ReadOnly = True
            Me.cCanPed.ReadOnly = True
            Me.cCanAte.ReadOnly = True
            Me.cPreMer.ReadOnly = True
            Me.cTotalFila.ReadOnly = True

            If lblEstado.Text = "VISUALIZADO" Or lblEstado.Text = "VS" Then
                biGenerar1.Enabled = True
                rbSeleccionrTodos.Visible = True
                cmOpcionesAtender.Enabled = True
                Me.cAtender.ReadOnly = False

            Else
                biGenerar1.Enabled = False
                rbSeleccionrTodos.Visible = False
                cmOpcionesAtender.Enabled = False
                Me.cAtender.ReadOnly = True
            End If

            Me.Text = "Pedido Nº " + Chr(34) + txtIdPedido.Text.ToString + Chr(34)
        Else                    'Nuevo

            'Me.btnGuardar.Location = New System.Drawing.Point(519, 116)
            'Me.btnCancelar.Location = New System.Drawing.Point(593, 116)
            txtIdPedido.ReadOnly = True
            txtIdPedido.TabStop = False
            gbEstado.Visible = False
            gbTotal.Visible = False
            'btnVerDetalle.Visible = False
            'Me.gbDatos.Size = New System.Drawing.Size(661, 109)
            Me.Size = New System.Drawing.Size(790, 270)
            btnBuscarCliente.Visible = True
            biGenerar1.Enabled = False
            biCambiarEstado1.Enabled = False
            biEditar1.Enabled = False
            biDeshacer1.Enabled = True
            biDescargarExcel.Enabled = False
            biImportarExcel.Enabled = False
            biCerrar.Enabled = False
            Me.Text = "Registrar nuevo Pedido"
            txtFecha.Value = Today
        End If

    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oPedidoService) = False Then
                oPedidoService.Close()
            End If
            If isClosed(oPedidoDetService) = False Then
                oPedidoDetService.Close()
            End If
            If isClosed(oCotizacionServicioService) = False Then
                oCotizacionServicioService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                           txtIdPedido.KeyUp
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
    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIdPedido.KeyPress
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
    Private Sub RowPossesion(ByVal lista As DataGridView, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
        Try
            'tabla.DefaultView.Sort = nombreCampo
            'lista.FirstDisplayedScrollingRowIndex = dtDatos.DefaultView.Find(codigo)
            'lista.Rows(dtDatos.DefaultView.Find(codigo)).Selected = True
            'lista.CurrentCell = lista.Rows(dtDatos.DefaultView.Find(codigo)).Cells(1)
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miActualizarCodigo.Enabled = False
            biGuardar1.Enabled = False
            biDeshacer1.Enabled = False
            'biEditar1.Enabled = False
            biGenerar1.Enabled = False
            biCambiarEstado1.Enabled = False

            If state_button = True And (toBlank(lblEstado.Text) = "GENERADO" Or toBlank(lblEstado.Text) = "GN") Then
                biDescargarExcel.Enabled = True
                biImportarExcel.Enabled = True
            Else
                biDescargarExcel.Enabled = False
                biImportarExcel.Enabled = False

            End If

        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = True
            biGuardar1.Enabled = False
            biDeshacer1.Enabled = False
            biEditar1.Enabled = False
            biGenerar1.Enabled = False

            If state_button = True And (toBlank(lblEstado.Text) = "GENERADO" Or toBlank(lblEstado.Text) = "GN") Then

                miNuevo.Enabled = True
                miEliminar.Enabled = True
                biEditar1.Enabled = True
                biDeshacer1.Enabled = False
                biDescargarExcel.Enabled = True
                biImportarExcel.Enabled = True

            Else
                miNuevo.Enabled = False
                miEliminar.Enabled = False
                miActualizar.Enabled = False
                miMostrar.Enabled = False
                biGuardar1.Enabled = False
                biEditar1.Enabled = False
                biDeshacer1.Enabled = False
                biDescargarExcel.Enabled = False
                biImportarExcel.Enabled = False
            End If

            If state_button = True And (toBlank(lblEstado.Text) = "VISUALIZADO" Or toBlank(lblEstado.Text) = "PEDIDO" Or toBlank(lblEstado.Text) = "RECHAZADO") Then
                biCambiarEstado1.Enabled = False
            End If

            If state_button = True And (toBlank(lblEstado.Text) = "GENERADO") Then
                biCambiarEstado1.Enabled = True
            End If

            If state_button = True And (toBlank(lblEstado.Text) = "VISUALIZADO") Then
                biGenerar1.Enabled = True
            End If

            If lblEstado.Text = "GENERADO" Then
                'sslError.Text = "Enviar el Pedido Actual"
                biCambiarEstado1.Text = "Enviar"
                biCambiarEstado1.ToolTipText = "Enviar"
                biCambiarEstado1.Image = SIGECOM.My.Resources.Resources.Enviar_Pr
            Else
                'sslError.Text = "Aprobar el Pedido Actual"
                biCambiarEstado1.Text = "Aprobar"
                biCambiarEstado1.ToolTipText = "Aprobar"
                biCambiarEstado1.Image = SIGECOM.My.Resources.Resources.Aceptar
            End If

            If (toBlank(lblEstado.Text) <> "PEDIDO") Then
                miActualizarCodigo.Enabled = True
            Else
                miActualizarCodigo.Enabled = False
            End If

        End If
    End Sub

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            Dim registro As New PedidoService.Pedido
            registro.IdPedido = toNull(txtIdPedido.Text)
            If state_button = True And toNumber(txtIdPedido.Text) = 0 Then
                MsgBox("Debe Ingresar el número del Pedido", MsgBoxStyle.Information, "Información")
                txtIdPedido.BackColor = Color.Red
                txtIdPedido.Focus()
                Return False
                'ElseIf toNumber(IdLocacion) = 0 Then
                '  MsgBox("Debe Ingresar la locación del Pedido", MsgBoxStyle.Information, "Información")
                '          'txtalmacen.BackColor = Color.Red
                '          'btnBuscarAlmacen.Focus()
                '  Return False
            ElseIf toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar el cliente del Pedido", MsgBoxStyle.Information, "Información")
                txtCliente.BackColor = Color.Red
                txtCliente.Focus()
                Return False
            ElseIf toNull(txtFecha.Text) = Nothing Then
                MsgBox("Debe Ingresar la fecha del Pedido", MsgBoxStyle.Information, "Información")
                txtFecha.BackColor = Color.Red
                txtFecha.Focus()
                Return False
            ElseIf toNumber(cmbIdPer.Value) = 0 Then
                MsgBox("Debe Ingresar el supervisor del Pedido", MsgBoxStyle.Information, "Información")
                txtFecha.BackColor = Color.Red
                txtFecha.Focus()
                Return False
            ElseIf state_button = True And toBlank(lblEstado.Text) <> "GENERADO" And toBlank(lblEstado.Text) <> "GN" Then
                MsgBox("Pedido ya no se puede modificar...!" + vbCr + "Debido que ya no se encuentra en el estado generado...!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As PedidoService.Pedido)
        Try
            Dim estado_process As Integer
            estado_process = oPedidoService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                txtIdPedido.Text = estado_process
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As PedidoService.Pedido)
        Try
            Dim estado_process As Boolean
            estado_process = oPedidoService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                'Me.DialogResult = Windows.Forms.DialogResult.OK
                '--------------------------------
                txtIdPedido.ReadOnly = True
                txtIdPedido.TabStop = False
                ObtenerRegistro()
                gbEstado.Visible = True
                gbTotal.Visible = True

                btnBuscarCliente.Enabled = False
                cmbIdPer.ReadOnly = True
                txtTecnico.ReadOnly = True
                txtFecha.ReadOnly = True
                Button1.Enabled = False
                txtSerMot.ReadOnly = True
                txtInterprete.ReadOnly = True
                txtNumOrden.ReadOnly = True
                txtObservacion.ReadOnly = True

                listaDatos()
                dgvDatos.ReadOnly = False
                Me.cIdPedidoDet.ReadOnly = True
                Me.cCodMer.ReadOnly = True
                Me.cDesMer.ReadOnly = True
                Me.cCanPed.ReadOnly = True
                Me.cCanAte.ReadOnly = True
                Me.cPreMer.ReadOnly = True
                Me.cTotalFila.ReadOnly = True

                If lblEstado.Text = "VISUALIZADO" Or lblEstado.Text = "VS" Then
                    biGenerar1.Enabled = True
                    rbSeleccionrTodos.Visible = True
                    cmOpcionesAtender.Enabled = True
                    Me.cAtender.ReadOnly = False
                Else
                    biGenerar1.Enabled = False
                    rbSeleccionrTodos.Visible = False
                    cmOpcionesAtender.Enabled = False
                    Me.cAtender.ReadOnly = True
                End If

                Me.Text = "Pedido Nº " + Chr(34) + txtIdPedido.Text.ToString + Chr(34)
                '------------------------
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Eliminar(ByVal registro As PedidoService.Pedido)
        Try
            Dim estado_process As Boolean
            estado_process = oPedidoService.Borrar(registro)
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
            Dim registro As PedidoService.Pedido
            registro = oPedidoService.MostrarPorId(toNumber(txtIdPedido.Text))

            txtIdPedido.Text = registro.IdPedido
            IdLocacion = registro.Locacion.IdLocacion
            DesLocacion = registro.Locacion.Almacen.DesAlm
            'txtalmacen.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.Almacenes", "DesAlm", "CodAlm", oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", IdLocacion)) _
            '                    & " - " & oMaestroService.MostrarDato("SIGECOM.Maestro.Oficinas", "DesOfi", "CodOfi", oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodOfi", "IdLocacion", IdLocacion))
            'txtalmacen.Text = registro.Locacion.Oficina.DesOfi & " - " & registro.Locacion.Almacen.DesAlm
            IdCliente = registro.Cliente.IdCliente
            'txtCliente.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.Clientes", "DesCli", "IdCliente", IdCliente)
            txtCliente.Text = registro.Cliente.DesCli
            txtFecha.Text = registro.Fecha
            txtSerMot.Text = toBlank(registro.SerMot)
            txtNumJob.Text = toBlank(registro.NumJob)
            txtNumOrden.Text = toBlank(registro.NumOrden)
            txtObservacion.Text = toBlank(registro.Observacion)
            cmbIdPer.Value = registro.Persona.IdPer

            txtInterprete.Text = toBlank(registro.Interprete)
            txtTecnico.Text = toBlank(registro.Tecnico)
            txtTotNeto.Text = toBlank(registro.TotNeto)
            lblEstado.Text = toBlank(registro.Estado)
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= PROVEEDORES ================================================
            dtSupervisores = oCotizacionServicioService.MostrarSupervisores(Session.sCodEmp).Tables(0)
            dtSupervisores.Rows.InsertAt(getRowTodos(dtSupervisores), 0)
            cmbIdPer.DataSource = dtSupervisores
            cmbIdPer.DropDownList.DataMember = dtSupervisores.Columns("ApeNom").ToString
            cmbIdPer.DropDownList.DisplayMember = dtSupervisores.Columns("ApeNom").ToString
            cmbIdPer.DropDownList.ValueMember = dtSupervisores.Columns("IdPer").ToString
            cmbIdPer.DropDownList.Columns(0).DataMember = dtSupervisores.Columns("IdPer").ToString
            cmbIdPer.DropDownList.Columns(1).DataMember = dtSupervisores.Columns("ApeNom").ToString
            cmbIdPer.SelectedIndex = 0
            dtSupervisores = Nothing
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            dtDatos = oPedidoDetService.Mostrar(toNumber(txtIdPedido.Text)).Tables(0)
            dgvDatos.DataSource = dtDatos
            cIdPedidoDet.DataPropertyName = dtDatos.Columns("IdPedidoDet").ColumnName
            cCodMer.DataPropertyName = dtDatos.Columns("CodMer").ColumnName
            cCodMerAnt.DataPropertyName = dtDatos.Columns("CodMerAnt").ColumnName
            cDesMer.DataPropertyName = dtDatos.Columns("DesMer").ColumnName
            cCanPed.DataPropertyName = dtDatos.Columns("CanPed").ColumnName
            cCanAte.DataPropertyName = dtDatos.Columns("CanAte").ColumnName
            cAtender.DataPropertyName = dtDatos.Columns("Atender").ColumnName
            cPreMer.DataPropertyName = dtDatos.Columns("PreMer").ColumnName
            cTotalFila.DataPropertyName = dtDatos.Columns("TotalFila").ColumnName
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [INFO-007]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmAgregarDetalle_Pedido
                frm.state_button = False
                frm.IdPedido = toNumber(txtIdPedido.Text)
                frm.estado_pedido = "GN"
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()

                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, dtDatos, "CodMer", frm.txtCodMer.Text.Trim)
                    End If
                Else
                    lLog = False
                End If
            End While

            biCambiarEstado1.Enabled = True
        Catch ex As Exception
            MsgBox("ERROR [INFO-008]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.Item("cCodMer", dgvDatos.CurrentRow.Index).Value.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                Dim registro As New PedidoDetService.PedidoDet
                Dim pedido As New PedidoDetService.Pedido

                registro.IdPedidoDet = toNumber(dgvDatos.Item("cIdPedidoDet", dgvDatos.CurrentRow.Index).Value)
                pedido.IdPedido = toNumber(txtIdPedido.Text)
                registro.Pedido = pedido
                estado_process = oPedidoDetService.Borrar(registro)

                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                    If dgvDatos.RowCount = 0 Then
                        biCambiarEstado1.Enabled = False
                    End If
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
            Dim frm As New frmAgregarDetalle_Pedido
            frm.state_button = True
            frm.IdPedidoDet = dgvDatos.Item("cIdPedidoDet", dgvDatos.CurrentRow.Index).Value
            frm.estado_pedido = toBlank(lblEstado.Text)

            dgvDatos.Rows(dgvDatos.CurrentRow.Index).Selected = True
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, dtDatos, "CodMer", frm.txtCodMer.Text.Trim)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
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
            ElseIf dgvDatos.CurrentRow.Index < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.Item(0, dgvDatos.CurrentRow.Index).Value = Nothing Then
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
                codigo = dgvDatos.Item("cCodMer", dgvDatos.CurrentRow.Index).Value
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, dtDatos, "CodMer", codigo)
            End If

        Catch ex As Exception
            MsgBox("ERROR [INFO-012]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub activar()
        biGuardar1.Enabled = True
        biEditar1.Enabled = False
        biDeshacer1.Enabled = True
        btnBuscarCliente.Enabled = True
        cmbIdPer.ReadOnly = False
        cmbIdPer.BackColor = System.Drawing.SystemColors.Window
        txtTecnico.ReadOnly = False
        txtFecha.ReadOnly = False
        Button1.Enabled = True
        txtSerMot.ReadOnly = False
        txtInterprete.ReadOnly = False
        txtNumOrden.ReadOnly = False
        txtObservacion.ReadOnly = False
        biCambiarEstado1.Enabled = False
    End Sub
    Private Sub desactivar()
        biGuardar1.Enabled = False
        biEditar1.Enabled = True
        biDeshacer1.Enabled = False
        btnBuscarCliente.Enabled = False
        cmbIdPer.ReadOnly = True
        cmbIdPer.BackColor = System.Drawing.SystemColors.Control
        txtTecnico.ReadOnly = True
        txtFecha.ReadOnly = True
        Button1.Enabled = False
        txtSerMot.ReadOnly = True
        txtInterprete.ReadOnly = True
        txtNumOrden.ReadOnly = True
        txtObservacion.ReadOnly = True
    End Sub
    Private Function actualizaListaDetalle() As Integer
        Dim nroItem As Integer = 0
        For i As Integer = 0 To dtDatos.Rows.Count - 1
            dtDatos.Rows(i).Item(6) = dgvDatos.Item("cAtender", i).Value
            If toNumber(dtDatos.Rows(i).Item(6)) > 0 Then
                nroItem = nroItem + 1
            End If
        Next
        Return nroItem
    End Function

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmBuscarJob
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.Text = frm.cod_job
        End If
    End Sub
    'Private Sub btnVerDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerDetalle.Click
    '    If btnVerDetalle.Text = "Ver Detalle" Then
    '        Me.Size = New System.Drawing.Size(678, 444)
    '        Me.btnVerDetalle.Image = Global.SIGECOM.My.Resources.Resources.Derecha
    '        btnVerDetalle.Text = "Ocultar Detalle"
    '        btnVerDetalle.Size = New System.Drawing.Size(102, 25)

    '        listaDatos()
    '        dgvDatos.ReadOnly = False
    '        Me.cIdPedidoDet.ReadOnly = True
    '        Me.cCodMer.ReadOnly = True
    '        Me.cDesMer.ReadOnly = True
    '        Me.cCanPed.ReadOnly = True
    '        Me.cCanAte.ReadOnly = True
    '        Me.cPreMer.ReadOnly = True
    '        Me.cTotalFila.ReadOnly = True

    '        If lblEstado.Text = "VISUALIZADO" Or lblEstado.Text = "VS" Then
    '            biGenerar1.Enabled = True
    '            rbSeleccionrTodos.Visible = True
    '            cmOpcionesAtender.Enabled = True
    '            Me.cAtender.ReadOnly = False
    '        Else
    '            biGenerar1.Enabled = False
    '            rbSeleccionrTodos.Visible = False
    '            cmOpcionesAtender.Enabled = False
    '            Me.cAtender.ReadOnly = True
    '        End If
    '    Else
    '        Me.Size = New System.Drawing.Size(678, 194)
    '        Me.btnVerDetalle.Image = Global.SIGECOM.My.Resources.Resources.Derecha
    '        btnVerDetalle.Text = "Ver Detalle"
    '        btnVerDetalle.Size = New System.Drawing.Size(85, 25)

    '        dtDatos = Nothing
    '        dgvDatos.DataSource = Nothing

    '        biGenerar1.Enabled = False
    '    End If
    'End Sub

    Private Sub btnAgregarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If state_button = True And (toBlank(lblEstado.Text) = "GENERADO" Or toBlank(lblEstado.Text) = "GN") Then
            NuevoDetalle()
        End If

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
        If state_button = True And (toBlank(lblEstado.Text) = "GENERADO" Or toBlank(lblEstado.Text) = "GN") Then
            NuevoDetalle()
        End If
    End Sub

    Private Sub dgvDatos_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvDatos.CellFormatting
        If Me.dgvDatos.Columns(e.ColumnIndex).Name = "cAtender" Then
            e.CellStyle.BackColor = Color.Wheat
        End If
    End Sub
    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub

    Private Sub dgvDatos_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvDatos.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub
    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = dgvDatos.CurrentCell.ColumnIndex
        If columna = 5 Or columna = 6 Then
            Dim caracter As Char = e.KeyChar
            If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False Then
                e.KeyChar = Chr(0)
            Else
                Dim campo As TextBox = sender
                If (e.KeyChar <> ChrW(Keys.Back)) Then
                    Dim porAtender As Integer = 0
                    Try
                        porAtender = CInt(campo.Text + e.KeyChar.ToString)
                    Catch ex As Exception
                        porAtender = toNumber(campo.Text)
                    End Try
                    Dim margen As Integer
                    margen = toNumber(dgvDatos.Item("cCanPed", dgvDatos.CurrentRow.Index).Value.ToString) - toNumber(dgvDatos.Item("cCanAte", dgvDatos.CurrentRow.Index).Value.ToString)
                    If porAtender > margen Then
                        MsgBox("La cantidad a atender no puede ser mayor que la cantidad por atender", MsgBoxStyle.Exclamation)
                        e.KeyChar = Chr(0)
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub rbSeleccionrTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSeleccionrTodos.CheckedChanged
        seleccionaTodos(rbSeleccionrTodos.Checked)
    End Sub
    Private Sub seleccionaTodos(ByVal condicion As Boolean)
        For i As Integer = 0 To dtDatos.Rows.Count - 1
            If condicion = True Then

                dgvDatos.Item("cAtender", i).Value = dgvDatos.Item("cCanPed", i).Value
            Else
                dgvDatos.Item("cAtender", i).Value = 0
            End If
        Next
    End Sub

    Private Sub miSeleccionarTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeleccionarTodo.Click
        seleccionaTodos(True)
    End Sub
    Private Sub miSeterCEROTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeterCEROTodos.Click
        seleccionaTodos(False)
    End Sub

    Private Sub biGenerar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerar1.Click
        Try
            If actualizaListaDetalle() > 0 Then
                Dim frm As New frmGenerarPedido_PedidoInterno
                frm.dtListaDetalles = dtDatos
                frm.IdLocacion = IdLocacion
                frm.txtalmacen.Text = DesLocacion
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then

                Else
                    rbSeleccionrTodos.Checked = False
                End If
                actualizar()
            Else
                MsgBox("Debe se pedir por lo menos un detalle del pedido ", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox("ERROR [GENERAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCambiarEstado1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCambiarEstado1.Click
        Try
            Dim frm As New frmCambiarEstado_PedidoInterno
            frm.IdPedido = toNumber(txtIdPedido.Text)
            frm.estado = lblEstado.Text

            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                lblEstado.Text = frm.estado
                ObtenerRegistro()
                listaDatos()
            Else
                lblEstado.Text = frm.estado
                ObtenerRegistro()
                listaDatos()
            End If

            If lblEstado.Text = "VISUALIZADO" Then
                biGenerar1.Enabled = True
                rbSeleccionrTodos.Visible = True
                cmOpcionesAtender.Enabled = True
                Me.cAtender.ReadOnly = False
            End If

        Catch ex As Exception
            MsgBox("ERROR [CAMBIAR ESTADO]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar1.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
        And ValidaCampos() Then

            Dim registro As New PedidoService.Pedido
            Dim locacion As New PedidoService.Locacion
            Dim cliente As New PedidoService.Cliente
            Dim persona As New PedidoService.Persona            

            registro.IdPedido = IIf(toNumber(txtIdPedido.Text) = 0, Nothing, toNumber(txtIdPedido.Text))
            locacion.IdLocacion = IIf(toNumber(IdLocacion) = 0, Nothing, toNumber(IdLocacion))
            registro.Locacion = locacion
            cliente.IdCliente = IdCliente
            registro.Cliente = cliente
            registro.Fecha = toNull(txtFecha.Text)
            registro.SerMot = toNull(txtSerMot.Text)
            registro.NumJob = IIf(toNull(txtNumJob.Text) = "", Nothing, txtNumJob.Text)
            persona.IdPer = IIf(toNumber(cmbIdPer.Value) = 0, Nothing, toNumber(cmbIdPer.Value))
            registro.Persona = persona
            registro.NumOrden = toNull(txtNumOrden.Text)
            registro.Observacion = toNull(txtObservacion.Text)
            registro.Interprete = toNull(txtInterprete.Text)
            registro.Tecnico = toNull(txtTecnico.Text)
            registro.CodUsu = toNull(Session.sCodUsu)


            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        If MsgBox("¿Desea Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Select()

        End If
    End Sub

    Private Sub biEditar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar1.Click
        activar()

    End Sub

    Private Sub biDeshacer1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer1.Click
        If MsgBox("¿Desea Deshacer los Cambios Realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()

            Else
                desactivar()
                ObtenerRegistro()

                If state_button = True And (toBlank(lblEstado.Text) = "GENERADO") Then
                    biCambiarEstado1.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub biEditar1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar1.MouseEnter
        sslError.Text = "Editar la Cabecera del Pedido."
    End Sub

    Private Sub biGuardar1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar1.MouseEnter
        sslError.Text = "Grabar los Cambios Hechos en el Pedido."
    End Sub
    Private Sub biDeshacer1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer1.MouseEnter
        sslError.Text = "Deshacer los Cambios Hechos en la Cabecera del Pedido."
    End Sub
    Private Sub biCerrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario Pedido."
    End Sub
    Private Sub biCambiarEstado1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCambiarEstado1.MouseEnter
        sslError.Text = "Cambiar de Estado."
    End Sub
    Private Sub biGenerar1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerar1.MouseEnter
        sslError.Text = "Generar Documento."
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
          biCerrar.MouseLeave, biGenerar1.MouseLeave, _
        miNuevo.MouseLeave, miMostrar.MouseLeave, miEliminar.MouseLeave, miActualizar.MouseLeave, biGuardar1.MouseLeave, biEditar1.MouseLeave, biDeshacer1.MouseLeave, biCambiarEstado1.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub miActualizarCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizarCodigo.Click
        Try


            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmPedido_ActualizarCodigo
                frm.IdPedidoDet = toNumber(dgvDatos.Item("cIdPedidoDet", dgvDatos.CurrentRow.Index).Value)
                frm.IdPedido = txtIdPedido.Text  'toNumber(dgvDatos.Item("cIdPedido", dgvDatos.CurrentRow.Index).Value)
                frm.CodMer = toBlank(dgvDatos.Item("cCodMer", dgvDatos.CurrentRow.Index).Value)
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    miActualizar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ACTUALIZAR el Código: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biDescargarExcel_Click(sender As System.Object, e As System.EventArgs) Handles biDescargarExcel.Click

        Dim dtExcel As New DataTable("tabla2")
        dtExcel.Columns.Add(New DataColumn("CodMer", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("DesMer", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("CanPed", Type.GetType("System.Int32")))
        dtExcel.Columns.Add(New DataColumn("PreMer", Type.GetType("System.Double")))
        dtExcel.Columns.Add(New DataColumn("Destino", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))

        dtExcel.Rows.Add(New Object() {"", "", "0", "0.00", "", ""})
        DataGridView2.DataSource = dtExcel
        Dim Export As Boolean
        Export = ExportarExcel(DataGridView2)

        If Export Then
            MsgBox("Se descargo el excel correctamente")
        End If

    End Sub

    Private Sub biImportarExcel_Click(sender As System.Object, e As System.EventArgs) Handles biImportarExcel.Click

        OpenFileDialog1.InitialDirectory = "d:\"
        OpenFileDialog1.Filter = "xlsx|*.xlsx"
        'OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirFile = OpenFileDialog1.FileName
            CargadoFinal()
        End If

    End Sub

    Private Sub CargadoFinal()


        If Not OpenFileDialog1.FileName Is Nothing And OpenFileDialog1.FileName.Length > 0 Then
            'Dim fileExt As String
            fileExt = System.IO.Path.GetExtension(OpenFileDialog1.FileName)
            If (fileExt <> ".xlsx") Then '' (fileExt <> ".xls") Then
                MsgBox("Solo se aceptan archivos de Excel, tenga cuidado !!!", MsgBoxStyle.Information)
                Exit Sub
            Else
                CargarGrilla()
            End If
            'CreacionTable()
            If dgvDatos.RowCount >= 280 Then
                MsgBox("Solo se permiten 279 filas para un Ingreso Masivo !!!", MsgBoxStyle.Information)
            Else
                InsertarMasivo()
            End If
        End If

    End Sub

    Private Sub CargarGrilla()
        DataGridView1.DataSource = GetDataExcel(DirFile, fileExt)
    End Sub

    Private Sub InsertarMasivo()
        Try
            For i As Integer = 0 To DataGridView1.Rows.Count - 2

                If IsDBNull(DataGridView1.Item(0, i).Value) = False Then

                    Dim registro As New PedidoDetService.PedidoDet
                    Dim pedido As New PedidoDetService.Pedido

                    registro.IdPedidoDet = Nothing
                    pedido.IdPedido = toNumber(txtIdPedido.Text)
                    registro.Pedido = pedido
                    registro.CodMer = toNull(Trim(DataGridView1.Item(0, i).Value))
                    registro.DesMer = IIf(IsDBNull(DataGridView1.Item(1, i).Value), Nothing, DataGridView1.Item(1, i).Value)
                    registro.CanPed = toNull(Trim(DataGridView1.Item(2, i).Value))
                    registro.PreMer = toNull(Trim(DataGridView1.Item(3, i).Value))
                    registro.Destino = IIf(IsDBNull(DataGridView1.Item(4, i).Value), Nothing, DataGridView1.Item(4, i).Value)
                    registro.Observacion = IIf(IsDBNull(DataGridView1.Item(5, i).Value), Nothing, DataGridView1.Item(5, i).Value)
                    'registro.CanMer = IIf(IsDBNull(DataGridView1.Item(6, i).Value), Nothing, DataGridView1.Item(6, i).Value)

                    Insertar(registro)

                End If
            Next

            listaDatos()

        Catch ex As Exception
            MsgBox("Error al Cargar Excel : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As PedidoDetService.PedidoDet)

        Try
            Dim estado_process As Integer
            estado_process = oPedidoDetService.Insertar(registro)

            If estado_process > 0 Then


            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub


End Class

