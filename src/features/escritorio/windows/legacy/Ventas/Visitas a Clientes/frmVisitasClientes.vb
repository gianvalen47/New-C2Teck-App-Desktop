Public Class frmVisitasClientes

    Private oMaestroService As New MaestroService.MaestroClient
    Private oVisitaClienteService As New VisitaClienteService.VisitaClienteServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Private IdCliente As Integer
    Private dtGruposVenta As DataTable
    Private dtClientes As DataTable
    Private dtTiposVentas As DataTable
    Private dtEstados As DataTable
    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                          cmbIdTipoVisita.KeyPress _
                        , cmbGruVen.KeyPress _
                        , txtIdCliente.KeyPress _
                        , dgvDatos.KeyPress _
                        , txtFecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                          cmbIdTipoVisita.KeyPress _
                        , txtIdCliente.KeyPress _
                        , cmbGruVen.KeyPress _
                        , txtFecha.KeyPress _
                        , btnBuscar.KeyPress _
                        , dgvDatos.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdVisita").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            'MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmVisitasClientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 26)
        '/*************************************************************************************/

        chkCliente.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkCliente, "Limpiar Cliente")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Cliente")

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        state_Search = False
        txtFecha.Text = Date.Today
        llenarCombos()
        IdCliente = 0
        txtIdCliente.Text = "(Todos)"
        state_Search = True
        listaDatos()
        dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
        dgvDatos.Select()
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oVisitaClienteService) = False Then
                oVisitaClienteService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal tipo_venta As Integer, ByVal grupo_venta As String)
        If type_process = "update" Or type_process = "insert" Then
            cmbIdTipoVisita.Value = tipo_venta
            cmbGruVen.Value = grupo_venta
            txtFecha.Text = ""
        End If
    End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miActualizar.Enabled = False
            miCancelar.Enabled = False
            miReprogramar.Enabled = False

            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biActualizar.Enabled = False
            biCancelar.Enabled = False
            biReprogramar.Enabled = False

        Else
            Dim lestado As String
            lestado = dgvDatos.CurrentRow.Cells("Estado").Text
            miMostrar.Enabled = True
            miActualizar.Enabled = True
            miEliminar.Enabled = IIf(lestado = "PROGRAMADO", True, False)
            miCancelar.Enabled = IIf(lestado = "PROGRAMADO", True, False)
            miReprogramar.Enabled = IIf(lestado = "NO EJECUTADO", True, False)

            biMostrar.Enabled = True
            biActualizar.Enabled = True
            biEliminar.Enabled = IIf(lestado = "PROGRAMADO", True, False)
            biCancelar.Enabled = IIf(lestado = "PROGRAMADO", True, False)
            biReprogramar.Enabled = IIf(lestado = "NO EJECUTADO", True, False)
        End If
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
            fila(2) = "(Todos)"
        End Try

        Return fila
    End Function

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Sub mostrar()
        Try
            Dim frm As New frmVistaCliente
            frm.state_button = True
            frm.IdVisita = dgvDatos.CurrentRow.Cells("IdVisita").Text

            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    'limpiaOpcionesBusqueda("update", frm.cmbIdTipoVisita.Value, frm.cmbGruVen.Value)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdVisita)
                ElseIf frm.type_process = "resultado" Then
                    MsgBox("Se atendió la visita correctamente.", MsgBoxStyle.Information)
                    'limpiaOpcionesBusqueda("update", frm.cmbIdTipoVisita.Value, frm.cmbGruVen.Value)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdVisita)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub eliminar()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("IdVisita").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oVisitaClienteService.Borrar(dgvDatos.CurrentRow.Cells("IdVisita").Text)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-002]:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oVisitaClienteService.Filtrar(toNumber(cmbIdTipoVisita.Value), toBlank(cmbGruVen.Value), toNumber(IdCliente), IIf(toBlank(txtFecha.Text) = "", Nothing, txtFecha.Text), cmbEstado.Value).Tables(0)
                dgvDatos.SetDataBinding(dtDatos, 0)
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Nuevo()
        Try
            Dim frm As New frmVistaCliente
            frm.state_button = False
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                'limpiaOpcionesBusqueda("insert", frm.cmbIdTipoVisita.Value, frm.cmbGruVen.Value)
                listaDatos()
                If frm.type_process = "insert" Then
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdVisita)
                    'mostrar()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
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
            ElseIf dgvDatos.CurrentRow.Cells("IdVisita").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub llenarCombos()
        Try
            '======================================= GRUPOS DE VENTA ================================================
            dtGruposVenta = oMaestroService.MostrarGrupoVentas.Tables(0)
            dtGruposVenta.Rows.InsertAt(getRowTodos(dtGruposVenta), 0)
            cmbGruVen.DataSource = dtGruposVenta
            cmbGruVen.DropDownList.DataMember = dtGruposVenta.Columns("DesVen").ToString
            cmbGruVen.DropDownList.DisplayMember = dtGruposVenta.Columns("DesVen").ToString
            cmbGruVen.DropDownList.ValueMember = dtGruposVenta.Columns("GruVen").ToString
            cmbGruVen.DropDownList.Columns(0).DataMember = dtGruposVenta.Columns("GruVen").ToString
            cmbGruVen.DropDownList.Columns(1).DataMember = dtGruposVenta.Columns("DesVen").ToString
            cmbGruVen.SelectedIndex = 0
            dtGruposVenta = Nothing
            '======================================= TIPO DE VENTA ================================================
            dtTiposVentas = oVisitaClienteService.MostrarTipoVisita.Tables(0)
            dtTiposVentas.Rows.InsertAt(getRowTodos(dtTiposVentas), 0)
            cmbIdTipoVisita.DataSource = dtTiposVentas
            cmbIdTipoVisita.DropDownList.DataMember = dtTiposVentas.Columns("DesTipo").ToString
            cmbIdTipoVisita.DropDownList.DisplayMember = dtTiposVentas.Columns("DesTipo").ToString
            cmbIdTipoVisita.DropDownList.ValueMember = dtTiposVentas.Columns("IdTipoVisita").ToString
            cmbIdTipoVisita.DropDownList.Columns(0).DataMember = dtTiposVentas.Columns("IdTipoVisita").ToString
            cmbIdTipoVisita.DropDownList.Columns(1).DataMember = dtTiposVentas.Columns("DesTipo").ToString
            cmbIdTipoVisita.SelectedIndex = 0
            dtTiposVentas = Nothing
            '======================================= ESTADO ================================================
            dtEstados = oVisitaClienteService.MostrarEstados
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        listaDatos()
    End Sub
    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click
        Nuevo()
    End Sub
    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub miMuestra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Nuevo()
    End Sub
    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                       cmbIdTipoVisita.ValueChanged _
                     , cmbGruVen.ValueChanged _
                     ,cmbEstado .ValueChanged _

        listaDatos()
    End Sub
    Private Sub txtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecha.ValueChanged
        listaDatos()
    End Sub
    Private Sub txtIdCliente_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdCliente.ButtonClick
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            chkCliente.Checked = False
            If toNull(frm.codigo) <> Nothing Then
                txtIdCliente.Text = frm.descripcion
                IdCliente = frm.codigo
            Else
                txtIdCliente.Text = "(Todos)"
                IdCliente = 0
            End If
            listaDatos()
        End If
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdVisita").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub biCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCancelar.Click, miCancelar.Click
        'If MsgBox("¿Esta seguro de cancelar la Visita  ... ?", MsgBoxStyle.YesNo, "Cancelar") = MsgBoxResult.Yes And ValidaCodigoSeleccionado() Then
        Dim frm As New frmVistaCliente
        frm.state_button = True
        frm.cancelado = True
        frm.IdVisita = dgvDatos.CurrentRow.Cells("IdVisita").Text
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            MsgBox("Se cancelo la visita...")
            'limpiaOpcionesBusqueda("update", frm.cmbIdTipoVisita.Value, frm.cmbGruVen.Value)
            biActualizar_Click(sender, e)
        End If
        'End If
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub biReprogramar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biReprogramar.Click, miReprogramar.Click
        Dim frm As New frmVisitaCliente_Reprogramar
        frm.IdVisita = dgvDatos.CurrentRow.Cells("IdVisita").Text
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            MsgBox("Se reprogramó la visita correctamente.")
            biActualizar_Click(sender, e)
        End If
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear nueva visita."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar visita actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar visita actual actual."
    End Sub
    Private Sub Cancelar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCancelar.MouseEnter, miCancelar.MouseEnter
        sslError.Text = "Cancelar visita actual."
    End Sub
    Private Sub Reprogramar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biReprogramar.MouseEnter, miReprogramar.MouseEnter
        sslError.Text = "Reprogramar visita cancelada."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar formulario actual."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Actualizar formulario actual."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                     biNuevo.MouseLeave, biMostrar.MouseLeave, biCancelar.MouseLeave, biActualizar.MouseLeave, _
                                     biEliminar.MouseLeave, biReprogramar.MouseLeave, biSalir.MouseLeave, _
                                     miNuevo.MouseLeave, miMostrar.MouseLeave, miCancelar.MouseLeave, miActualizar.MouseLeave, _
                                     miEliminar.MouseLeave, biReprogramar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub chkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If txtIdCliente.Text <> "(Todos)" Then
            chkCliente.Enabled = False
            txtIdCliente.Text = "(Todos)"
            IdCliente = 0
            listaDatos()
        Else
            chkCliente.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub
End Class