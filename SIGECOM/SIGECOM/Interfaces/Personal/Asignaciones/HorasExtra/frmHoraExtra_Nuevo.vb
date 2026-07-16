Imports System.ServiceModel
Public Class frmHoraExtra_Nuevo

    '===========================Servicios====================================
    Private oHoraExtraService As New HoraExtraService.HoraExtraServiceClient
    Private oHoraExtraDetService As New HoraExtraDetService.HoraExtraDetServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private Persona As New PersonaService.Persona
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable    
    Public IdExtra As Integer
    Public IdPersona As Integer = 0
    Public dtDatos As DataTable
    Private dtUbicacion As DataTable
    Private dtPerAutoriza As DataTable
    Public ApeNom As String
    Public iPagado As Boolean                     'Campo pagado de la Hora Extra seleccionada

    Public iIdPersona As Integer = 0           'IdPersona de colaborador seleccionado en la ventana anterior

    Private Sub frmHoraExtra_Nuevo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        llenarCombos()

        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            gbDetalles.Visible = True
            actualizarDetalles()
            Me.Text = "Hora(s) Extra de: " + Chr(34) + ApeNom + Chr(34)
            dgvDatos.Select()
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(513, 272)
            txtFecha.Value = Today

            gbDetalles.Visible = False
            Me.Text = "Nuevo registro de Hora Extra"
            activar()
            If iIdPersona <> 0 Then
                ObtenerPersona()
                txtColaborador.Select()
            Else
                btnBuscarColaborador.TabStop = True
                btnBuscarColaborador.Select()
            End If
            'txtColaborador.Select()
        End If
    End Sub

    Private Sub ObtenerPersona()
        Persona = oPersonaService.Obtener(iIdPersona)
        IdPersona = iIdPersona
        txtColaborador.Text = Persona.ApeNom
    End Sub

    Private Sub frmHoraExtra_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmHoraExtra_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oHoraExtraService.Close()
            oHoraExtraDetService.Close()
            oJobService.Close()
            oPersonaService.Close()
            oAsignacionJefesService.Close()
        Catch ex As TimeoutException
            oHoraExtraService.Abort()
            oHoraExtraDetService.Abort()
            oJobService.Abort()
            oPersonaService.Abort()
            oAsignacionJefesService.Abort()
        Catch ex As CommunicationException
            oHoraExtraService.Abort()
            oHoraExtraDetService.Abort()
            oJobService.Abort()
            oPersonaService.Abort()
            oAsignacionJefesService.Abort()
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdExtraDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(3) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub llenarCombos()
        Try

            '============================================== UBICACIÓN ========================================
            dtUbicacion = oJobService.MostrarUbicacionEquipo.Tables(0)
            dtUbicacion.Rows.InsertAt(getRowTodos(dtUbicacion), 0)
            cmbUbicacion.DataSource = dtUbicacion
            cmbUbicacion.DropDownList.DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.DisplayMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.ValueMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(0).DataMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(1).DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.SelectedIndex = 0
            dtUbicacion = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtColaborador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtColaborador.TextChanged
        If txtColaborador.Text <> "" Then
            Persona = oPersonaService.Obtener(IdPersona)

            '=================================== PERSONA AUTORIZA ==========================================
            dtPerAutoriza = oAsignacionJefesService.MostrarJefeArea(Persona.CentroCosto.CodCentro).Tables(0)
            'dtPerAutoriza.Rows.InsertAt(getRowNinguno(dtPerAutoriza), 0)
            cmbPerAutoriza.DataSource = dtPerAutoriza
            cmbPerAutoriza.DropDownList.DataMember = dtPerAutoriza.Columns("ApeNom").ToString
            cmbPerAutoriza.DropDownList.DisplayMember = dtPerAutoriza.Columns("ApeNom").ToString
            cmbPerAutoriza.DropDownList.ValueMember = dtPerAutoriza.Columns("IdPer").ToString
            cmbPerAutoriza.DropDownList.Columns(0).DataMember = dtPerAutoriza.Columns("IdPer").ToString
            cmbPerAutoriza.DropDownList.Columns(1).DataMember = dtPerAutoriza.Columns("ApeNom").ToString
            cmbPerAutoriza.SelectedIndex = 0
            dtPerAutoriza = Nothing
        End If
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miCompensarHoras.Enabled = False
        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(editable, True, False)
            miCompensarHoras.Enabled = IIf(editable, True, False)
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

    Private Sub activar()
        If state_button Then
            txtColaborador.ReadOnly = True
            txtColaborador.BackColor = System.Drawing.SystemColors.Control
            btnBuscarColaborador.Enabled = False
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            txtNumJob.ReadOnly = False
            txtNumJob.BackColor = System.Drawing.SystemColors.Window
            btnBuscarJob.Enabled = True
            cmbUbicacion.ReadOnly = False
            cmbUbicacion.BackColor = System.Drawing.SystemColors.Window
            cmbPerAutoriza.ReadOnly = False
            cmbPerAutoriza.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window

            cbPagado.Visible = True
            edicion = True
            enableOpciones()
            txtFecha.Focus()
        Else
            txtColaborador.ReadOnly = True
            txtColaborador.BackColor = System.Drawing.SystemColors.Control
            btnBuscarColaborador.Enabled = True
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            txtNumJob.ReadOnly = False
            txtNumJob.BackColor = System.Drawing.SystemColors.Window
            btnBuscarJob.Enabled = True
            cmbUbicacion.ReadOnly = False
            cmbUbicacion.BackColor = System.Drawing.SystemColors.Window
            cmbPerAutoriza.ReadOnly = False
            cmbPerAutoriza.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window

            cbPagado.Visible = False
            edicion = True
            enableOpciones()
            txtColaborador.Focus()
        End If
    End Sub

    Private Sub desactivar()        
        txtColaborador.ReadOnly = True
        txtColaborador.BackColor = System.Drawing.SystemColors.Control
        btnBuscarColaborador.Enabled = False
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        txtNumJob.ReadOnly = True
        txtNumJob.BackColor = System.Drawing.SystemColors.Control
        btnBuscarJob.Enabled = False
        cmbUbicacion.ReadOnly = True
        cmbUbicacion.BackColor = System.Drawing.SystemColors.Control
        cmbPerAutoriza.ReadOnly = True
        cmbPerAutoriza.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control

        cbPagado.Visible = True
        edicion = False
        enableOpciones()
        txtColaborador.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If IdPersona = 0 Then
                MsgBox("Debe Ingresar el Colaborador.", MsgBoxStyle.Information, "Información")
                txtColaborador.Focus()
                Return False
            ElseIf toBlank(txtFecha.Value) = "" Then
                MsgBox("Debe ingresar la fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf toBlank(cmbPerAutoriza.Value) = "" Then
                MsgBox("Debe de Ingresar la persona que autoriza.", MsgBoxStyle.Information, "Información")
                cmbPerAutoriza.Focus()
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
            Dim registro As HoraExtraService.HoraExtra
            registro = oHoraExtraService.Obtener(IdExtra)

            IdExtra = registro.IdExtra
            IdPersona = registro.Persona.IdPer
            txtColaborador.Text = registro.Persona.ApeNom
            txtFecha.Value = registro.Fecha
            txtNumJob.Text = registro.Job.CodJob
            If registro.UbicacionEquipo.CodUbicacion = "" Then
                cmbUbicacion.SelectedIndex = 0
            Else
                cmbUbicacion.Value = registro.UbicacionEquipo.CodUbicacion
            End If
            cmbPerAutoriza.Value = registro.PersonaAutoriza.IdPer
            txtObservacion.Text = registro.Observacion
            cbPagado.Checked = registro.Pagado

            Me.Text = "Hora(s) Extra de: " + Chr(34) + registro.Persona.ApeNom + Chr(34)
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmHoraExtra_Detalle
                frm.state_button = False
                frm.IdExtra = IdExtra
                frm.iPagado = iPagado

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdExtraDet)
                    End If
                Else
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
                estado_process = oHoraExtraDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdExtraDet").Value), IdExtra, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
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
            Dim frm As New frmHoraExtra_Detalle
            frm.state_button = True
            frm.IdExtraDet = dgvDatos.CurrentRow.Cells("IdExtraDet").Text
            frm.IdExtra = IdExtra
            frm.iPagado = iPagado
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                ObtenerRegistro()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdExtraDet)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdExtraDet)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdExtraDet").Text
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

    Private Sub Insertar(ByVal registro As HoraExtraService.HoraExtra)
        Try
            Dim estado_process As Integer
            estado_process = oHoraExtraService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdExtra = estado_process
                MsgBox("Se insertó la hora extra Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR HORA EXTRA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As HoraExtraService.HoraExtra)
        Try
            Dim estado_process As Boolean
            estado_process = oHoraExtraService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó la hora extra Correctamente")
                desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR HORA EXTRA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oHoraExtraService.Borrar(IdExtra, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR HORA EXTRA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oHoraExtraDetService.Mostrar(IdExtra).Tables(0)
            dgvDatos.DataSource = dtDatos

            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarColaborador_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarColaborador.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersona = frm.codigo
                    txtColaborador.Text = frm.descripcion
                    txtFecha.Focus()
                Else
                    IdPersona = 0
                    txtColaborador.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim registro As New HoraExtraService.HoraExtra
                    Dim Persona As New HoraExtraService.Persona
                    Dim Job As New HoraExtraService.Job
                    Dim PersonaAutoriza As New HoraExtraService.Persona
                    Dim UbicacionEquipo As New HoraExtraService.UbicacionEquipo
                    Dim AsignacionHE As New HoraExtraService.AsignacionHoraExtra

                    registro.IdExtra = IdExtra
                    Persona.IdPer = IdPersona
                    registro.Persona = Persona
                    registro.Fecha = txtFecha.Value
                    Job.CodJob = IIf(txtNumJob.Text = "", Nothing, txtNumJob.Text)
                    registro.Job = Job
                    UbicacionEquipo.CodUbicacion = IIf(cmbUbicacion.SelectedIndex = 0, Nothing, cmbUbicacion.Value)
                    registro.UbicacionEquipo = UbicacionEquipo
                    PersonaAutoriza.IdPer = cmbPerAutoriza.Value
                    registro.PersonaAutoriza = PersonaAutoriza
                    registro.Observacion = txtObservacion.Text

                    registro.CodUsu = Session.sCodUsu
                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp

                    If state_button Then            'Modificar
                        Modificar(registro)
                    Else                                  'Nuevo
                        registro.FecReg = Today
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
                    codigo = dgvDatos.CurrentRow.Cells("IdExtraDet").Text
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

    Private Sub txtColaborador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtColaborador.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarColaborador.Enabled = True Then
                e.Handled = True
                btnBuscarColaborador_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Try
            Dim frm As New frmBuscarJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.cod_job) <> Nothing Then
                    txtNumJob.Text = frm.cod_job
                Else
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarJob.Enabled = True Then
                e.Handled = True
                btnBuscarJob_Click(sender, e)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de Job no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    cmbUbicacion.Focus()
                End If
            Else
                cmbUbicacion.Focus()
            End If
        End If
    End Sub

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        Try
            If Len(Trim(txtNumJob.Text)) > 0 Then

                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de Job no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    cmbUbicacion.Focus()
                End If
            Else
                cmbUbicacion.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL JOB : " + ex.Message)
        End Try
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtColaborador.KeyPress _
                           , txtFecha.KeyPress _
                           , cmbUbicacion.KeyPress _
                           , cmbPerAutoriza.KeyPress _
                           , txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If
    End Sub

    Private Sub txtNumJob_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumJob.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            cmbUbicacion.Focus()
        End If
    End Sub

    Private Sub miCompensarHoras_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miCompensarHoras.Click
        Try
            If ValidaCodigoSeleccionado() Then
                If MsgBox("¿Esta seguro de COMPENSAR HORAS de la Hora Extra?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oHoraExtraDetService.CompensarHoras(IdExtra, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        MsgBox("Se Compenso las horas correctamente ")
                        actualizar()
                    Else
                        MsgBox("Error en el proceso,comuniquese con el departamento de sistemas")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class