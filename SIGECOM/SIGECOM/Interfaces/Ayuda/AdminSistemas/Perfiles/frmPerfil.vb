Imports System.ServiceModel
Public Class frmPerfil

    '===========================Servicios====================================
    Private oSeguridadService As New SeguridadService.SeguridadClient   

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable    
    Public CodPerfil As String
    Private dtDatos As New DataTable
    Private dtModulos As New DataTable
    Public iModificar As Boolean

    Private Sub frmPerfil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        LlenarCombos()

        If state_button Then    'Modificar 
            If iModificar = True Then
                ObtenerRegistro()
                activar()
            Else
                ObtenerRegistro()
                desactivar()
            End If
            gbDetalles.Visible = True
            actualizarDetalles()
            Me.Text = "Perfil de Usuario"
            dgvDatos.Select()
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(594, 174)

            gbDetalles.Visible = False
            Me.Text = "Nuevo Perfil de Usuario"
            activar()
            txtNombre.Select()
        End If
    End Sub

    Private Sub frmPerfil_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmPerfil_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdOpcion").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub LlenarCombos()
        Try

            '==================================== MODULOS ===================================
            dtModulos = oSeguridadService.MostrarMenuSistema().Tables(0)
            cmbModulos.DataSource = dtModulos
            cmbModulos.DropDownList.DataMember = dtModulos.Columns("DesMenu").ToString
            cmbModulos.DropDownList.DisplayMember = dtModulos.Columns("DesMenu").ToString
            cmbModulos.DropDownList.ValueMember = dtModulos.Columns("IdMenu").ToString
            cmbModulos.DropDownList.Columns(0).DataMember = dtModulos.Columns("IdMenu").ToString
            cmbModulos.DropDownList.Columns(1).DataMember = dtModulos.Columns("DesMenu").ToString
            cmbModulos.SelectedIndex = 0
            dtModulos = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(editable, True, False)
        End If
        btnAsignarPerfil.Enabled = IIf(editable And Not edicion, True, False)

        biEditar.Enabled = IIf(editable, Not edicion, False)
        biCerrar.Enabled = Not edicion
        biGuardar.Enabled = edicion
        biDeshacer.Enabled = edicion
        cmOpciones.Enabled = IIf(Not edicion, True, False)
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub activar()
        If state_button Then
            txtCodigo.ReadOnly = True
            txtCodigo.BackColor = System.Drawing.SystemColors.Control
            txtNombre.ReadOnly = False
            txtNombre.BackColor = System.Drawing.SystemColors.Window
            txtDescripcion.ReadOnly = False
            txtDescripcion.BackColor = System.Drawing.SystemColors.Window
            cbActivo.Visible = True
            cbActivo.Enabled = True

            edicion = True
            enableOpciones()
            txtNombre.Focus()
        Else
            txtCodigo.ReadOnly = False
            txtCodigo.BackColor = System.Drawing.SystemColors.Window
            txtNombre.ReadOnly = False
            txtNombre.BackColor = System.Drawing.SystemColors.Window
            txtDescripcion.ReadOnly = False
            txtDescripcion.BackColor = System.Drawing.SystemColors.Window
            cbActivo.Visible = False
            cbActivo.Enabled = True

            edicion = True
            enableOpciones()
            txtCodigo.Focus()
        End If
    End Sub

    Private Sub desactivar()
        txtCodigo.ReadOnly = True
        txtCodigo.BackColor = System.Drawing.SystemColors.Control
        txtNombre.ReadOnly = True
        txtNombre.BackColor = System.Drawing.SystemColors.Control
        txtDescripcion.ReadOnly = True
        txtDescripcion.BackColor = System.Drawing.SystemColors.Control
        cbActivo.Visible = True
        cbActivo.Enabled = False

        edicion = False
        enableOpciones()
        txtCodigo.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If txtNombre.Text = "" Then
                MsgBox("Debe Ingresar el Nombre del Perfil.", MsgBoxStyle.Information, "Información")
                txtNombre.Focus()
                Return False
            ElseIf txtDescripcion.Text = "" Then
                MsgBox("Debe ingresar la Descripción.", MsgBoxStyle.Information, "Información")
                txtDescripcion.Focus()
                Return False           
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub ObtenerRegistro()
        Try
            Dim registro As SeguridadService.Perfil
            registro = oSeguridadService.MostrarPerfilPorCodigo(CodPerfil)

            txtCodigo.Text = registro.CodPerfil
            txtNombre.Text = registro.Nombre
            txtDescripcion.Text = registro.Descripcion
            cbActivo.Checked = registro.Activo

            Me.Text = "Perfil de Usuario"
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de de ELIMINAR la opción " & dgvDatos.CurrentRow.Cells("DesOpc1").Text & "?", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oSeguridadService.BorrarPerfilOpciones(dgvDatos.CurrentRow.Cells("IdOpcion").Text, txtCodigo.Text)
                If estado_process = True Then
                    dtDatos = Nothing
                    ObtenerRegistro()
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmPerfil_Opcion
            frm.state_button = True
            frm.IdOpcion = toNumber(dgvDatos.CurrentRow.Cells("IdOpcion").Text)
            frm.CodPerfil = CodPerfil

            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ObtenerRegistro()
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdOpcion)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdOpcion)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdOpcion").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As SeguridadService.Perfil)
        Try
            Dim estado_process As Boolean
            estado_process = oSeguridadService.InsertarPerfil(registro)
            type_process = "insert"
            If estado_process = True Then
                'IdExtra = estado_process
                MsgBox("Se insertó el perfil Correctamente")
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR PERFIL DE USUARIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As SeguridadService.Perfil)
        Try
            Dim estado_process As Boolean
            estado_process = oSeguridadService.ActualizarPerfil(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó el perfil Correctamente")
                desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR PERFIL DE USUARIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oSeguridadService.BorrarPerfil(CodPerfil)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR PERFIL DE USUARIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oSeguridadService.MostrarPerfilOpciones(CodPerfil, cmbModulos.Value).Tables(0)
            dgvDatos.DataSource = dtDatos

            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim registro As New SeguridadService.Perfil
                    
                    registro.CodPerfil = txtCodigo.Text
                    registro.Nombre = txtNombre.Text
                    registro.Descripcion = txtDescripcion.Text
                    registro.Activo = cbActivo.Checked

                    If state_button Then            'Modificar
                        Modificar(registro)
                    Else                                  'Nuevo
                        Insertar(registro)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR HORA EXTRA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub biEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEditar.Click
        activar()
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()
    End Sub

    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdOpcion").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminarDetalle()
        End If
    End Sub

    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click, dgvDatos.DoubleClick
        If cmOpciones.Enabled = False Then
        Else
            If ValidaCodigoSeleccionado() Then
                mostrarDetalle()
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

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtCodigo.KeyPress _
                           , txtNombre.KeyPress _
                           , txtDescripcion.KeyPress _
                           , cbActivo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'Private Sub btnModificarOpc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarOpc.Click
    '    HabilitarDetalle()
    '    btnModificarOpc.Enabled = False
    'End Sub

    Private Sub HabilitarDetalle()
        dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
        dgvDatos.RootTable.Columns(1).EditType = Janus.Windows.GridEX.EditType.NoEdit
        dgvDatos.RootTable.Columns(2).EditType = Janus.Windows.GridEX.EditType.NoEdit
        dgvDatos.RootTable.Columns(3).EditType = Janus.Windows.GridEX.EditType.CheckBox
        dgvDatos.RootTable.Columns(4).EditType = Janus.Windows.GridEX.EditType.CheckBox
    End Sub

    Private Sub DesabilitarDetalle()
        dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
        dgvDatos.RootTable.Columns(1).EditType = Janus.Windows.GridEX.EditType.NoEdit
        dgvDatos.RootTable.Columns(2).EditType = Janus.Windows.GridEX.EditType.NoEdit
        dgvDatos.RootTable.Columns(3).EditType = Janus.Windows.GridEX.EditType.NoEdit
        dgvDatos.RootTable.Columns(4).EditType = Janus.Windows.GridEX.EditType.NoEdit
    End Sub

    'Private Sub dgvDatos_EditModeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.EditModeChanged
    '    Try
    '        Dim Fila As Integer = dgvDatos.CurrentRow.RowIndex
    '        oSeguridadService.HabilitarPermiso(dgvDatos.GetRow(Fila).Cells(0).Text, CodPerfil, dgvDatos.GetRow(Fila).Cells("Lectura").Text, dgvDatos.GetRow(Fila).Cells("Habilitado").Text)
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Al Grabar")
    '    End Try
    'End Sub

    Private Sub cbModulos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbModulos.ValueChanged
        listaDatos()
    End Sub

    Private Sub btnAsignarPerfil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignarPerfil.Click
        Dim frm As New frmAsignarPerfil
        frm.CodPerfil = txtCodigo.Text
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            listaDatos()
        End If
        listaDatos()
    End Sub

    'Protected Friend Sub NuevoRegistro()
    '    Estado = "Nuevo"
    '    txtCodigo.ReadOnly = False
    '    txtNombre.ReadOnly = False
    '    txtDescripcion.ReadOnly = False
    '    pCodPerfil = Nothing
    '    txtCodigo.Text = ""
    '    txtNombre.Text = ""
    '    txtDescripcion.Text = ""
    '    ckActivo.Checked = True

    '    LlenarDetalles()
    '    dgvDatos.Enabled = False
    '    biGuardar.Enabled = True
    '    biDeshacer.Enabled = True
    '    'btnNuevo.Enabled = False
    '    biEditar.Enabled = False
    '    biCerrar.Enabled = False
    '    btnModificarOpc.Enabled = False
    '    btnAsignarPerfil.Enabled = False

    '    txtCodigo.Focus()
    'End Sub
    'Protected Friend Sub ModificarRegistro()
    '    Estado = "Modificar"
    '    txtCodigo.ReadOnly = True
    '    txtNombre.ReadOnly = True
    '    txtDescripcion.ReadOnly = False
    '    ckActivo.Enabled = True

    '    biGuardar.Enabled = True
    '    biDeshacer.Enabled = True
    '    'btnNuevo.Enabled = False
    '    biEditar.Enabled = False
    '    biCerrar.Enabled = False

    '    btnModificarOpc.Enabled = True
    '    btnModificarOpc.Visible = True
    '    btnAsignarPerfil.Enabled = False
    '    txtDescripcion.Focus()
    'End Sub

    'Private Sub Desabilitar()
    '    Estado = ""
    '    txtCodigo.ReadOnly = True
    '    txtNombre.ReadOnly = True
    '    txtDescripcion.ReadOnly = True
    '    ckActivo.Enabled = False
    '    DesabilitarDetalle()
    '    dgvDatos.Enabled = True
    '    biGuardar.Enabled = False
    '    biDeshacer.Enabled = False
    '    'btnNuevo.Enabled = True
    '    biEditar.Enabled = True
    '    biCerrar.Enabled = True
    '    btnModificarOpc.Enabled = False
    '    btnModificarOpc.Visible = False
    '    btnAsignarPerfil.Enabled = True
    'End Sub
End Class