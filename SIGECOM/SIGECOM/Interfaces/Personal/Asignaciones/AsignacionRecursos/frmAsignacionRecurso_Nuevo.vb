Imports System.Data.OleDb
Imports System.ServiceModel
Public Class frmAsignacionRecurso_Nuevo

    '===========================Servicios====================================
    Private oRecursoService As New RecursoService.RecursoServiceClient
    Private oRecursoDetService As New RecursoDetService.RecursoDetServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient


    Private Persona As New PersonaService.Persona
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable
    Public IdRecurso As Integer
    Public IdPersona As Integer = 0
    Public CodArea As String = ""
    Public CodAnio As Integer = 0
    Public dtDatos As DataTable
    Private dtPerAutoriza As DataTable
    Private dtRubros As DataTable
    Public ApeNom As String
    Public iEstado As String                         'Campo estado del asignación de recurso seleccionado
    Private iDevuelto As Boolean                   'Campo devuelto de detalles de recurso
    Private dtAreas As DataTable
    Private dtCentroCosto As DataTable

    Private DirFile As String
    Private fileExt As String
    Private dtDatosExcel As DataTable

    Private IdRubro As Integer                     'IdRubro de Recurso (cabecera) 

    Public iIdPersona As Integer = 0           'IdPersona de colaborador seleccionado en la ventana anterior

    Private Sub frmAsignacionRecurso_Nuevo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        llenarCombos()

        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            gbEstado.Visible = True
            gbDetalles.Visible = True
            actualizarDetalles()
            Me.Text = "Asignación de Recurso de: " + Chr(34) + ApeNom + Chr(34)
            dgvDatos.Select()
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(586, 306)
            txtFecha.Value = Today
            cmbCodArea.Value = CodArea
            gbEstado.Visible = False
            gbDetalles.Visible = False
            Me.Text = "Nueva Asignación de Recurso"
            activar()
            If iIdPersona <> 0 Then
                ObtenerPersona()
                txtColaborador.Select()
            Else
                btnBuscarColaborador.TabStop = True
                btnBuscarColaborador.Select()
            End If
            'txtColaborador.Select()
            SugerirNumero()
        End If
    End Sub

    Private Sub ObtenerPersona()
        Persona = oPersonaService.Obtener(iIdPersona)
        IdPersona = iIdPersona
        txtColaborador.Text = Persona.ApeNom
    End Sub

    Private Sub SugerirNumero()

        txtNumDoc.Text = oRecursoService.SugerirNumero(CodArea, CodAnio)

    End Sub

    Private Sub frmAsignacionRecurso_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oRecursoService.Close()
            oRecursoDetService.Close()
            oPersonaService.Close()
            oAsignacionJefesService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oRecursoService.Abort()
            oRecursoDetService.Abort()
            oPersonaService.Abort()
            oAsignacionJefesService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oRecursoService.Abort()
            oRecursoDetService.Abort()
            oPersonaService.Abort()
            oAsignacionJefesService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmAsignacionRecurso_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdRecursoDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            '============================================== RUBRO ========================================
            dtRubros = oRecursoService.MostrarRubros(Session.sCodUsu).Tables(0)
            cmbRubro.DataSource = dtRubros
            cmbRubro.DropDownList.DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubros.Columns("IdRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubros.Columns("IdRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.SelectedIndex = 0
            dtRubros = Nothing

            '======================================= AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbCodArea.DataSource = dtAreas
            cmbCodArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.SelectedIndex = 0
            dtAreas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbCodArea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbCodArea.Value, Session.sCodUsu).Tables(0)
            cmbCentroCosto.DataSource = dtCentroCosto
            cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.SelectedIndex = 0

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub cmbCentroCosto_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCentroCosto.ValueChanged
        Try

            '=================================== PERSONA AUTORIZA ==========================================
            dtPerAutoriza = oAsignacionJefesService.MostrarJefeArea(cmbCentroCosto.Value).Tables(0)
            cmbPerAutoriza.DataSource = dtPerAutoriza
            cmbPerAutoriza.DropDownList.DataMember = dtPerAutoriza.Columns("ApeNom").ToString
            cmbPerAutoriza.DropDownList.DisplayMember = dtPerAutoriza.Columns("ApeNom").ToString
            cmbPerAutoriza.DropDownList.ValueMember = dtPerAutoriza.Columns("IdPer").ToString
            cmbPerAutoriza.DropDownList.Columns(0).DataMember = dtPerAutoriza.Columns("IdPer").ToString
            cmbPerAutoriza.DropDownList.Columns(1).DataMember = dtPerAutoriza.Columns("ApeNom").ToString
            cmbPerAutoriza.SelectedIndex = 0
            dtPerAutoriza = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR PERSONA AUTORIZA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miDevolver.Enabled = False
            miDevolverMasivo.Enabled = False            
        Else
            iDevuelto = toBoolean(dgvDatos.CurrentRow.Cells("Devuelto").Value)
            iEstado = oRecursoService.ObtenerEstado(IdRecurso)
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(editable, True, False)
            miDevolver.Enabled = IIf(iDevuelto = False And (iEstado = "EN" Or iEstado = "DP"), True, False)
            miDevolverMasivo.Enabled = IIf(dgvDatos.RowCount > 1 And (iEstado = "EN" Or iEstado = "DP"), True, False)
        End If
        miNuevo.Enabled = IIf(editable, True, False)
        miNuevoMasivo.Enabled = IIf(editable, True, False)
        miImportarExcel.Enabled = IIf(editable, True, False)

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
            cmbRubro.ReadOnly = True
            cmbRubro.BackColor = System.Drawing.SystemColors.Control
            cmbPerAutoriza.ReadOnly = False
            cmbPerAutoriza.BackColor = System.Drawing.SystemColors.Window
            txtNumDoc.ReadOnly = True
            txtNumDoc.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window

            cmbCodArea.ReadOnly = True
            cmbCodArea.BackColor = System.Drawing.SystemColors.Control
            cmbCentroCosto.ReadOnly = True
            cmbCentroCosto.BackColor = System.Drawing.SystemColors.Control

            edicion = True
            enableOpciones()
            txtFecha.Focus()
        Else
            txtColaborador.ReadOnly = True
            txtColaborador.BackColor = System.Drawing.SystemColors.Control
            btnBuscarColaborador.Enabled = True
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            cmbRubro.ReadOnly = False
            cmbRubro.BackColor = System.Drawing.SystemColors.Window            
            cmbPerAutoriza.ReadOnly = False
            cmbPerAutoriza.BackColor = System.Drawing.SystemColors.Window
            txtNumDoc.ReadOnly = False
            txtNumDoc.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window

            cmbCodArea.ReadOnly = False
            cmbCodArea.BackColor = System.Drawing.SystemColors.Window
            cmbCentroCosto.ReadOnly = False
            cmbCentroCosto.BackColor = System.Drawing.SystemColors.Window

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
        cmbRubro.ReadOnly = True
        cmbRubro.BackColor = System.Drawing.SystemColors.Control
        cmbPerAutoriza.ReadOnly = True
        cmbPerAutoriza.BackColor = System.Drawing.SystemColors.Control
        txtNumDoc.ReadOnly = True
        txtNumDoc.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control

        cmbCodArea.ReadOnly = True
        cmbCodArea.BackColor = System.Drawing.SystemColors.Control
        cmbCentroCosto.ReadOnly = True
        cmbCentroCosto.BackColor = System.Drawing.SystemColors.Control

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
                MsgBox("Debe Ingresar la fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf toBlank(cmbRubro.Value) = "" Then
                MsgBox("Debe de Ingresar el Rubro.", MsgBoxStyle.Information, "Información")
                cmbRubro.Focus()
                Return False
            ElseIf toBlank(txtNumDoc.Text) = "" Then
                MsgBox("Debe Ingresar el número de documento.", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf toBlank(cmbPerAutoriza.Value) = "" Then
                MsgBox("Debe de Ingresar la persona que autoriza.", MsgBoxStyle.Information, "Información")
                cmbPerAutoriza.Focus()
                Return False
            ElseIf oRecursoService.Buscar(cmbCodArea.Value, toNumber(cmbRubro.Value), txtNumDoc.Text) And state_button = False Then
                MsgBox("El número de documento ya ha sido ingresado.", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
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
            Dim registro As RecursoService.Recurso
            registro = oRecursoService.Obtener(IdRecurso)

            IdRecurso = registro.IdRecurso
            IdPersona = registro.Persona.IdPer
            txtColaborador.Text = registro.Persona.ApeNom
            txtFecha.Value = registro.Fecha
            IdRubro = toNumber(registro.RubroRecurso.IdRubro)
            cmbRubro.Value = registro.RubroRecurso.IdRubro
            cmbCodArea.Value = registro.CentroCosto.Area.CodArea
            cmbCentroCosto.Value = registro.CentroCosto.CodCentro
            cmbPerAutoriza.Value = registro.PersonaAutoriza.IdPer
            txtNumDoc.Text = registro.NumDoc
            txtObservacion.Text = registro.Observacion
            lblEstado.Text = registro.Estado

            Me.Text = "Registro de Asignación de Recurso de: " + Chr(34) + registro.Persona.ApeNom + Chr(34)
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmAsignacionRecurso_Detalle
                frm.state_button = False
                frm.IdRecurso = IdRecurso
                frm.iEstado = iEstado
                frm.IdRubro = toNumber(cmbRubro.Value)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdRecursoDet)
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
                estado_process = oRecursoDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdRecursoDet").Value), IdRecurso, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
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
            Dim frm As New frmAsignacionRecurso_Detalle
            frm.state_button = True
            frm.IdRecursoDet = toNumber(dgvDatos.CurrentRow.Cells("IdRecursoDet").Text)
            frm.IdRecurso = IdRecurso
            frm.iEstado = iEstado
            frm.IdRubro = toNumber(cmbRubro.Value)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                ObtenerRegistro()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdRecursoDet)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdRecursoDet)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdRecursoDet").Text
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

    Private Sub Insertar(ByVal registro As RecursoService.Recurso)
        Try
            Dim estado_process As Integer
            estado_process = oRecursoService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdRecurso = estado_process
                MsgBox("Se insertó la asignación Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR ASIGNACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As RecursoService.Recurso)
        Try
            Dim estado_process As Boolean
            estado_process = oRecursoService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó la asignación Correctamente")
                desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR ASIGNACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oRecursoService.Borrar(IdRecurso, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR ASIGNACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oRecursoDetService.Mostrar(IdRecurso).Tables(0)
            dgvDatos.DataSource = dtDatos

            If state_button = True And IdRecurso = 2 Then
                dgvDatos.RootTable.Columns(11).Visible = True
                dgvDatos.RootTable.Columns(12).Visible = True
                dgvDatos.RootTable.Columns(13).Visible = True
                dgvDatos.RootTable.Columns(14).Visible = True
                dgvDatos.RootTable.Columns(15).Visible = True
            Else
                dgvDatos.RootTable.Columns(11).Visible = False
                dgvDatos.RootTable.Columns(12).Visible = False
                dgvDatos.RootTable.Columns(13).Visible = False
                dgvDatos.RootTable.Columns(14).Visible = False
                dgvDatos.RootTable.Columns(15).Visible = False
            End If

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

                    Dim registro As New RecursoService.Recurso
                    Dim Persona As New RecursoService.Persona
                    Dim PersonaAutoriza As New RecursoService.Persona
                    Dim RubroRecurso As New RecursoService.RubroRecurso
                    Dim CentroCosto As New RecursoService.CentroCosto

                    registro.IdRecurso = IdRecurso
                    Persona.IdPer = IdPersona
                    registro.Persona = Persona
                    registro.Fecha = txtFecha.Value
                    RubroRecurso.IdRubro = toNumber(cmbRubro.Value)
                    registro.RubroRecurso = RubroRecurso                    
                    PersonaAutoriza.IdPer = cmbPerAutoriza.Value
                    registro.PersonaAutoriza = PersonaAutoriza
                    registro.NumDoc = txtNumDoc.Text
                    registro.Observacion = txtObservacion.Text

                    CentroCosto.CodCentro = cmbCentroCosto.Value
                    registro.CentroCosto = CentroCosto

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
            MsgBox("ERROR AL GUARDAR RECURSO: " + ex.Message, MsgBoxStyle.Exclamation)
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
                    codigo = dgvDatos.CurrentRow.Cells("IdRecursoDet").Text
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

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtColaborador.KeyPress _
                           , txtFecha.KeyPress _
                           , txtNumDoc.KeyPress _
                           , cmbRubro.KeyPress _
                           , cmbPerAutoriza.KeyPress _
                           , cmbCodArea.KeyPress _
                           , cmbCentroCosto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If
    End Sub

    Private Sub miDevolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miDevolver.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmDevolver_Recurso
                frm.IdRecurso = dgvDatos.CurrentRow.Cells("IdRecurso").Text
                frm.IdRecursoDet = dgvDatos.CurrentRow.Cells("IdRecursoDet").Text
                frm.Codigo = dgvDatos.CurrentRow.Cells("Codigo").Text
                frm.Masivo = False
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    miActualizar_Click(sender, e)
                    ObtenerRegistro()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al DEVOLVER detalle seleccionado: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miDevolverMasivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miDevolverMasivo.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmDevolver_Recurso
                frm.IdRecurso = dgvDatos.CurrentRow.Cells("IdRecurso").Text
                frm.IdRecursoDet = dgvDatos.CurrentRow.Cells("IdRecursoDet").Text
                frm.Masivo = True
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    miActualizar_Click(sender, e)
                    ObtenerRegistro()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al DEVOLVER MASIVO los detalles: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miFormatoExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miFormatoExcel.Click
        FormatoExcel()
    End Sub

    Private Sub FormatoExcel()

        Dim dtExcel As New DataTable("tabla2")

        If IdRubro = 2 Then

            dtExcel.Columns.Add(New DataColumn("Cantidad", Type.GetType("System.String")))
            dtExcel.Columns.Add(New DataColumn("Codigo", Type.GetType("System.String")))
            dtExcel.Columns.Add(New DataColumn("Serie", Type.GetType("System.String")))
            dtExcel.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
            dtExcel.Columns.Add(New DataColumn("Talla", Type.GetType("System.String")))
            dtExcel.Columns.Add(New DataColumn("Modelo", Type.GetType("System.String")))
            dtExcel.Columns.Add(New DataColumn("Marca", Type.GetType("System.String")))
            dtExcel.Columns.Add(New DataColumn("UsoPersonal", Type.GetType("System.String")))
            dtExcel.Columns.Add(New DataColumn("OtroUso", Type.GetType("System.String")))
            dtExcel.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))
            dtExcel.Columns.Add(New DataColumn("Empresa", Type.GetType("System.String")))
            dtExcel.Columns.Add(New DataColumn("NumCelular", Type.GetType("System.String")))
            dtExcel.Columns.Add(New DataColumn("NumRadio", Type.GetType("System.String")))
            dtExcel.Columns.Add(New DataColumn("Plan", Type.GetType("System.String")))

            dtExcel.Rows.Add(New Object() {"1", "", "", "", "", "", "", "1", "", "", "0", "", "", ""})

        Else

            dtExcel.Columns.Add(New DataColumn("Cantidad", Type.GetType("System.String")))
            dtExcel.Columns.Add(New DataColumn("Codigo", Type.GetType("System.String")))
            dtExcel.Columns.Add(New DataColumn("Serie", Type.GetType("System.String")))
            dtExcel.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
            dtExcel.Columns.Add(New DataColumn("Talla", Type.GetType("System.String")))
            dtExcel.Columns.Add(New DataColumn("Modelo", Type.GetType("System.String")))
            dtExcel.Columns.Add(New DataColumn("Marca", Type.GetType("System.String")))
            dtExcel.Columns.Add(New DataColumn("UsoPersonal", Type.GetType("System.String")))
            dtExcel.Columns.Add(New DataColumn("OtroUso", Type.GetType("System.String")))
            dtExcel.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))

            dtExcel.Rows.Add(New Object() {"1", "", "", "", "", "", "", "1", "", ""})
        End If

        dgvFormatoExcel.DataSource = dtExcel

        Dim Export As Boolean
        Export = ExportarExcel(dgvFormatoExcel)

        If Export Then
            MsgBox("Se descargo el excel correctamente")
        End If
    End Sub

    Private Sub miImportarExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miImportarExcel.Click
        OpenFileDialog1.InitialDirectory = "d:\"
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            DirFile = OpenFileDialog1.FileName
            CargadoFinal()
        End If
    End Sub

    Private Sub CargadoFinal()
        If Not OpenFileDialog1.FileName Is Nothing And OpenFileDialog1.FileName.Length > 0 Then
            fileExt = System.IO.Path.GetExtension(OpenFileDialog1.FileName)
            If (fileExt <> ".xls") And (fileExt <> ".xlsx") Then
                MsgBox("¡Solo se aceptan archivos de Excel, tenga cuidado...!", MsgBoxStyle.Information)
                Exit Sub
            Else
                CargarGrilla()
            End If
        End If
    End Sub

    Private Sub CargarGrilla()
        Try
            If MsgBox("¿Está seguro de IMPORTAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                dgvImportarExcel.DataSource = GetDataExcel(DirFile, fileExt)
                Dim estado_process As Integer = 0

                If dgvImportarExcel.RowCount > 0 Then
                    For Each fila As DataGridViewRow In dgvImportarExcel.Rows
                        Dim registro As New RecursoDetService.RecursoDet
                        Dim Recurso As New RecursoDetService.Recurso
                        Dim EmpCom As New RecursoDetService.EmpresaComunicacion

                        Recurso.IdRecurso = IdRecurso
                        registro.Recurso = Recurso
                        registro.Cantidad = toNumber(fila.Cells("Cantidad").Value)
                        registro.Codigo = IIf(Convert.ToString(fila.Cells("Codigo").Value) = "", Nothing, Convert.ToString(fila.Cells("Codigo").Value))
                        registro.Serie = IIf(Convert.ToString(fila.Cells("Serie").Value) = "", Nothing, Convert.ToString(fila.Cells("Serie").Value))
                        registro.Descripcion = IIf(Convert.ToString(fila.Cells("Descripcion").Value) = "", Nothing, Convert.ToString(fila.Cells("Descripcion").Value))
                        registro.Talla = IIf(Convert.ToString(fila.Cells("Talla").Value) = "", Nothing, Convert.ToString(fila.Cells("Talla").Value))
                        registro.Modelo = IIf(Convert.ToString(fila.Cells("Modelo").Value) = "", Nothing, Convert.ToString(fila.Cells("Modelo").Value))
                        registro.Marca = IIf(Convert.ToString(fila.Cells("Marca").Value) = "", Nothing, Convert.ToString(fila.Cells("Marca").Value))
                        registro.UsoPersonal = IIf(toNumber(fila.Cells("UsoPersonal").Value) = 1, True, False)
                        registro.DesOtroUso = IIf(Convert.ToString(fila.Cells("OtroUso").Value) = "", Nothing, Convert.ToString(fila.Cells("OtroUso").Value))
                        registro.Observacion = IIf(Convert.ToString(fila.Cells("Observacion").Value) = "", Nothing, Convert.ToString(fila.Cells("Observacion").Value))

                        If IdRubro = 2 Then
                            EmpCom.IdEmpresa = toNumber(fila.Cells("Empresa").Value)
                            registro.EmpresaComunicacion = EmpCom
                            registro.DesPlan = Convert.ToString(fila.Cells("Plan").Value)
                            registro.NumCelular = Convert.ToString(fila.Cells("NumCelular").Value)
                            registro.NumRadio = Convert.ToString(fila.Cells("NumRadio").Value)
                        Else
                            EmpCom.IdEmpresa = Nothing
                            registro.EmpresaComunicacion = EmpCom
                            registro.DesPlan = Nothing
                            registro.NumCelular = Nothing
                            registro.NumRadio = Nothing
                        End If

                        registro.CodUsu = Session.sCodUsu
                        registro.NomPc = Session.sNomPc
                        registro.DirIp = Session.sDirIp

                        estado_process = oRecursoDetService.Insertar(registro)
                    Next

                    If estado_process > 0 Then
                        MsgBox("Se ingresó los detalles correctamente", MsgBoxStyle.Information, "Error de datos")
                        listaDatos()
                    End If
                Else
                    MsgBox("¡No existen detalles a importar...!", MsgBoxStyle.Information, "Error de datos")
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al IMPORTAR los detalles: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevoMasivo_Click(sender As Object, e As EventArgs) Handles miNuevoMasivo.Click

        Try

            Dim frm As New frmAsignacionRecurso_NuevoDetalleMasivo
            'frm.state_button = False
            frm.IdRecurso = IdRecurso
            frm.Memo = txtNumDoc.Text
            'frm.iEstado = iEstado
            'frm.IdRubro = toNumber(cmbRubro.Value)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                ObtenerRegistro()
                'If frm.type_process = "insert" Then
                '    RowPossesion(dgvDatos, frm.IdRecursoDet)
                'End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub
End Class