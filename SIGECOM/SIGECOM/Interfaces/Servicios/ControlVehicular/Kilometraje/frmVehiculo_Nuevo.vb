Imports System.ServiceModel
Public Class frmVehiculo_Nuevo

    '===========================Servicios====================================================
    Private oVehiculoService As New VehiculoService.VehiculoServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable
    Private dtOficinas As DataTable
    Private dtPlaca As DataTable
    Private dtSupervisor As DataTable
    Public IdKilometraje As Integer
    Public dtDatos As DataTable

    Private Sub frmVehiculo_Nuevo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        llenarcombos()

        If state_button Then    'Modificar 
            ObtenerRegistro()
            Desactivar()
            gbDetalles.Visible = True
            actualizarDetalles()
            Me.Text = "Kilometraje"
            dgvDatos.Select()                        
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(528, 335)
            gbDetalles.Visible = False
            Me.Text = "Registrar nuevo Kilometraje"
            Activar()
            cmbVehiculo.Focus()
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                       cmbOficinas.KeyPress _
                     , txtFecha.KeyPress _
                     , cmbVehiculo.KeyPress _
                     , cmbSupervisor.KeyPress _
                     , txtKilometraje.KeyPress '_
        ', txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmVehiculo_Nuevoo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmVehiculo_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oVehiculoService.Close()
            oMaestroService.Close()
            oCotizacionServicioService.Close()
        Catch ex As TimeoutException
            oVehiculoService.Abort()
            oMaestroService.Abort()
            oCotizacionServicioService.Abort()
        Catch ex As CommunicationException
            oVehiculoService.Abort()
            oMaestroService.Abort()
            oCotizacionServicioService.Abort()
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If toBlank(row.Cells("IdGastoDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub llenarcombos()
        Try

            '=============================== OFICINAS ==================================
            dtOficinas = oMaestroService.MostrarOficinas("").Tables(0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

            '=============================== VEHÍCULO ==================================
            dtPlaca = oVehiculoService.MostrarUnidades.Tables(0)
            cmbVehiculo.DataSource = dtPlaca
            cmbVehiculo.DropDownList.DataMember = dtPlaca.Columns("Placa").ToString
            cmbVehiculo.DropDownList.DisplayMember = dtPlaca.Columns("Placa").ToString
            cmbVehiculo.DropDownList.ValueMember = dtPlaca.Columns("Placa").ToString
            cmbVehiculo.DropDownList.Columns(0).DataMember = dtPlaca.Columns("Placa").ToString
            cmbVehiculo.SelectedIndex = 0
            dtPlaca = Nothing

            '============================= SUPERVISORES ================================
            dtSupervisor = oCotizacionServicioService.MostrarSupervisores(Session.sCodEmp).Tables(0)
            cmbSupervisor.DataSource = dtSupervisor
            cmbSupervisor.DropDownList.DataMember = dtSupervisor.Columns("AbrPer").ToString
            cmbSupervisor.DropDownList.DisplayMember = dtSupervisor.Columns("AbrPer").ToString
            cmbSupervisor.DropDownList.ValueMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(0).DataMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(1).DataMember = dtSupervisor.Columns("AbrPer").ToString
            cmbSupervisor.SelectedIndex = 0
            dtSupervisor = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
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
        miNuevo.Enabled = IIf(editable, True, False)

        biEditar.Enabled = IIf(editable, Not edicion, False)
        biCerrar.Enabled = Not edicion
        biGuardar.Enabled = edicion
        biDeshacer.Enabled = edicion
        cmOpciones.Enabled = IIf(Not edicion, True, False)
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Protected Sub Activar()
        Try
            If state_button Then   'Actualizar
                cmbOficinas.ReadOnly = True
                cmbOficinas.BackColor = System.Drawing.SystemColors.Control
                cmbVehiculo.ReadOnly = True
                cmbVehiculo.BackColor = System.Drawing.SystemColors.Control
                cmbSupervisor.ReadOnly = True
                cmbSupervisor.BackColor = System.Drawing.SystemColors.Control
                txtFecha.ReadOnly = False
                txtFecha.BackColor = System.Drawing.SystemColors.Window
                txtKilometraje.ReadOnly = False
                txtKilometraje.BackColor = System.Drawing.SystemColors.Window
                txtObservacion.ReadOnly = False
                txtObservacion.BackColor = System.Drawing.SystemColors.Window
                edicion = True
                enableOpciones()
                txtFecha.Focus()
            Else                       'Nuevo
                cmbOficinas.ReadOnly = False
                cmbOficinas.BackColor = System.Drawing.SystemColors.Window
                cmbVehiculo.ReadOnly = False
                cmbVehiculo.BackColor = System.Drawing.SystemColors.Window
                cmbSupervisor.ReadOnly = False
                cmbSupervisor.BackColor = System.Drawing.SystemColors.Window
                txtFecha.ReadOnly = False
                txtFecha.BackColor = System.Drawing.SystemColors.Window
                txtKilometraje.ReadOnly = False
                txtKilometraje.BackColor = System.Drawing.SystemColors.Window
                txtObservacion.ReadOnly = False
                txtObservacion.BackColor = System.Drawing.SystemColors.Window
                edicion = True
                enableOpciones()
                cmbOficinas.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Sub Desactivar()
        Try

            cmbOficinas.ReadOnly = True
            cmbOficinas.BackColor = System.Drawing.SystemColors.Control
            cmbVehiculo.ReadOnly = True
            cmbVehiculo.BackColor = System.Drawing.SystemColors.Control
            cmbSupervisor.ReadOnly = True
            cmbSupervisor.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            txtKilometraje.ReadOnly = True
            txtKilometraje.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control
            edicion = False
            enableOpciones()
            txtFecha.Focus()

        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cmbOficinas.Value) = "" Then
                MsgBox("Debe ingresar el almacén", MsgBoxStyle.Information, "Información")
                cmbOficinas.Focus()
                Return False
            ElseIf toNull(txtFecha.Value) = Nothing Then
                MsgBox("Debe ingresar la fecha", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf toBlank(cmbVehiculo.Value) = "" Then
                MsgBox("Debe ingresar el vehículo", MsgBoxStyle.Information, "Información")
                cmbVehiculo.Focus()
                Return False
            ElseIf toDouble(txtKilometraje.Value) = 0 Then
                MsgBox("Debe ingresar el kilometraje", MsgBoxStyle.Information, "Información")
                txtKilometraje.Focus()
                Return False
            ElseIf toNumber(cmbSupervisor.Value) = 0 Then
                MsgBox("Debe ingresar el supervisor", MsgBoxStyle.Information, "Información")
                cmbSupervisor.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS : " + ex.Message)
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

    Protected Sub ObtenerRegistro()
        Try
            Dim registro As VehiculoService.Kilometraje
            registro = oVehiculoService.Obtener(IdKilometraje)

            cmbOficinas.Value = registro.Oficina.CodOfi
            txtFecha.Value = registro.Fecha
            cmbVehiculo.Value = registro.Unidad.Placa
            cmbSupervisor.Value = registro.Persona.IdPer
            txtKilometraje.Text = registro.KilometrajeMember
            txtObservacion.Text = registro.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmVehiculo_Gasto
                frm.iPlaca = cmbVehiculo.Value
                frm.IdKilometraje = IdKilometraje
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    ObtenerRegistro()
                    enableOpciones()
                    actualizarDetalles()
                Else
                    actualizarDetalles()
                    enableOpciones()
                    lLog = False
                End If
            End While

        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oVehiculoService.BorrarGasto(toNumber(dgvDatos.CurrentRow.Cells("IdGastoDet").Value), toNumber(dgvDatos.CurrentRow.Cells("IdGasto").Value), _
                                                                                       toNumber(dgvDatos.CurrentRow.Cells("IdKilometraje").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmComSolicitudGastoDetNew
            frm.state_button = True
            frm.IdGastoDet = dgvDatos.CurrentRow.Cells("IdGastoDet").Text
            frm.IdGasto = dgvDatos.CurrentRow.Cells("IdGasto").Text
            frm.estado = 5
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                actualizarDetalles()
                ObtenerRegistro()
            End If
            RowPossesion(dgvDatos, frm.IdGastoDet)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdGastoDet").Text
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

    Protected Sub Insertar(ByVal registro As VehiculoService.Kilometraje)
        Try
            Dim estado_process As Integer
            estado_process = oVehiculoService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdKilometraje = estado_process
                MsgBox("Se insertó el Kilometraje Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR KILOMETRAJE : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Protected Sub Modificar(ByVal registro As VehiculoService.Kilometraje)
        Try
            Dim estado_process As Boolean
            estado_process = oVehiculoService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó el Kilometraje Correctamente")
                Desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR KILOMETRAJE : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oVehiculoService.Borrar(IdKilometraje, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR KILOMETRAJE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oVehiculoService.MostrarGasto(IdKilometraje).Tables(0)
            dgvDatos.DataSource = dtDatos
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Protected Sub Guardar()
        Try
            If ValidaCampos() Then
                Dim registro As New VehiculoService.Kilometraje
                Dim oficina As New VehiculoService.Oficina
                Dim unidad As New VehiculoService.Unidad
                Dim persona As New VehiculoService.Persona

                registro.IdKilometraje = IdKilometraje
                oficina.CodOfi = cmbOficinas.Value
                registro.Oficina = oficina
                registro.Fecha = txtFecha.Value
                unidad.Placa = cmbVehiculo.Value
                registro.Unidad = unidad
                persona.IdPer = utils.toNumber(cmbSupervisor.Value)
                registro.Persona = persona
                registro.KilometrajeMember = CDbl(txtKilometraje.Text)
                registro.Observacion = utils.toNull(txtObservacion.Text)
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.CodUsu = Session.sCodUsu
                If state_button = True Then
                    Modificar(registro)
                Else
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
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

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            Guardar()
        End If
    End Sub

    Private Sub biEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEditar.Click
        activar()
    End Sub

    Private Sub miNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        If state_button = True Then
            NuevoDetalle()
        End If
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()
    End Sub

    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdGastoDet").Text
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
End Class