Imports System.ServiceModel
Public Class frmEvaluacion_Nuevo

    '===========================Servicios====================================================
    Private oEvaluacionService As New EvaluacionService.EvaluacionServiceClient
    Private oEvaluacionDetService As New EvaluacionDetService.EvaluacionDetServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient
    Private Persona As New PersonaService.Persona
    Private Jefe As New PersonaService.Persona

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable        

    Public IdEvaluacion As Integer    
    Public IdPersona As Integer = 0
    Private dtPerAutoriza As DataTable
    Public dtDatos As DataTable
    Public ApeNom As String

    Public DesCargo As String
    Public DesArea As String
    Public FecIniPlanilla As Date
    Public DesCargoJefe As String

    Public iIdPersona As Integer = 0

    Private Sub frmEvaluacion_Nuevo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            Me.Text = "Evaluación de: " + Chr(34) + ApeNom + Chr(34)
            dgvDatos.Select()
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(534, 300)
            txtFecha.Value = Today

            gbDetalles.Visible = False
            Me.Text = "Nueva Evaluación de Colaborador"
            activar()
            If iIdPersona <> 0 Then
                ObtenerPersona()
            End If
            txtColaborador.Select()
        End If
    End Sub

    Private Sub ObtenerPersona()
        Persona = oPersonaService.Obtener(iIdPersona)
        IdPersona = iIdPersona
        txtColaborador.Text = Persona.ApeNom
    End Sub

    Private Sub ObtenerDatos()
        Try
            Persona = oPersonaService.Obtener(IdPersona)
            DesArea = Persona.CentroCosto.Area.DesArea
            DesCargo = Persona.Cargo.DesCargo
            FecIniPlanilla = Persona.FecIniPlanilla

            Jefe = oPersonaService.Obtener(toNumber(cmbPerAutoriza.Value))
            DesCargoJefe = Jefe.Cargo.DesCargo
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmEvaluacion_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmEvaluacion_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oEvaluacionService.Close()
            oEvaluacionDetService.Close()
            oPersonaService.Close()
            oAsignacionJefesService.Close()
        Catch ex As TimeoutException
            oEvaluacionService.Abort()
            oEvaluacionDetService.Abort()
            oPersonaService.Abort()
            oAsignacionJefesService.Abort()
        Catch ex As CommunicationException
            oEvaluacionService.Abort()
            oEvaluacionDetService.Abort()
            oPersonaService.Abort()
            oAsignacionJefesService.Abort()
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdEvaluacionDet").Value) = codigo Then
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
        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(editable, True, False)            
        End If
        miNuevo.Enabled = IIf(editable, True, False)
        miInsertarPlantilla.Enabled = IIf(editable And dgvDatos.RowCount = 0, True, False)

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
            txtIdEvaluacion.ReadOnly = True
            txtIdEvaluacion.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            txtColaborador.ReadOnly = True
            txtColaborador.BackColor = System.Drawing.SystemColors.Control
            btnBuscarColaborador.Enabled = False
            cmbPerAutoriza.ReadOnly = False
            cmbPerAutoriza.BackColor = System.Drawing.SystemColors.Window
            txtFortalezas.ReadOnly = False
            txtFortalezas.BackColor = System.Drawing.SystemColors.Window
            txtOportunidades.ReadOnly = False
            txtOportunidades.BackColor = System.Drawing.SystemColors.Window
            txtCapacitacion.ReadOnly = False
            txtCapacitacion.BackColor = System.Drawing.SystemColors.Window

            edicion = True
            enableOpciones()
            txtFecha.Focus()
        Else
            txtIdEvaluacion.ReadOnly = True
            txtIdEvaluacion.BackColor = System.Drawing.SystemColors.Control            
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            txtColaborador.ReadOnly = True
            txtColaborador.BackColor = System.Drawing.SystemColors.Control
            btnBuscarColaborador.Enabled = True
            cmbPerAutoriza.ReadOnly = False
            cmbPerAutoriza.BackColor = System.Drawing.SystemColors.Window
            txtFortalezas.ReadOnly = False
            txtFortalezas.BackColor = System.Drawing.SystemColors.Window
            txtOportunidades.ReadOnly = False
            txtOportunidades.BackColor = System.Drawing.SystemColors.Window
            txtCapacitacion.ReadOnly = False
            txtCapacitacion.BackColor = System.Drawing.SystemColors.Window

            edicion = True
            enableOpciones()
            txtColaborador.Focus()
        End If
    End Sub

    Private Sub desactivar()
        txtIdEvaluacion.ReadOnly = True
        txtIdEvaluacion.BackColor = System.Drawing.SystemColors.Control
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        txtColaborador.ReadOnly = True
        txtColaborador.BackColor = System.Drawing.SystemColors.Control
        btnBuscarColaborador.Enabled = False
        cmbPerAutoriza.ReadOnly = True
        cmbPerAutoriza.BackColor = System.Drawing.SystemColors.Control
        txtFortalezas.ReadOnly = True
        txtFortalezas.BackColor = System.Drawing.SystemColors.Control
        txtOportunidades.ReadOnly = True
        txtOportunidades.BackColor = System.Drawing.SystemColors.Control
        txtCapacitacion.ReadOnly = True
        txtCapacitacion.BackColor = System.Drawing.SystemColors.Control

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
            Dim registro As EvaluacionService.Evaluacion
            registro = oEvaluacionService.Obtener(IdEvaluacion)

            IdEvaluacion = registro.IdEvaluacion
            txtIdEvaluacion.Text = registro.IdEvaluacion
            txtFecha.Value = registro.Fecha
            lblEstado.Text = registro.EstadosEvaluacion.DesEstado
            IdPersona = registro.Persona.IdPer
            txtColaborador.Text = registro.Persona.ApeNom
            cmbPerAutoriza.Value = registro.Jefe.IdPer
            txtFortalezas.Text = registro.Fortalezas
            txtOportunidades.Text = registro.Oportunidades
            txtCapacitacion.Text = registro.Capacitacion

            Me.Text = "Evaluación de: " + Chr(34) + registro.Persona.ApeNom + Chr(34)
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub



    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmEvaluacion_Detalle
                frm.state_button = False
                frm.IdEvaluacion = IdEvaluacion
                frm.idper = IdPersona
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdEvaluacionDet)
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
                estado_process = oEvaluacionDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdEvaluacionDet").Value), IdEvaluacion, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
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
            Dim frm As New frmEvaluacion_Detalle
            frm.state_button = True
            frm.IdEvaluacionDet = dgvDatos.CurrentRow.Cells("IdEvaluacionDet").Text
            frm.IdEvaluacion = IdEvaluacion
            frm.idper = IdPersona

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                ObtenerRegistro()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdEvaluacionDet)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdEvaluacionDet)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdEvaluacionDet").Text
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

    Private Sub Insertar(ByVal registro As EvaluacionService.Evaluacion)
        Try
            Dim estado_process As Integer
            estado_process = oEvaluacionService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdEvaluacion = estado_process
                MsgBox("Se insertó la Evaluación de colaborador correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EVALUACIÓN DE COLABORADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As EvaluacionService.Evaluacion)
        Try
            Dim estado_process As Boolean
            estado_process = oEvaluacionService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó la Evaluación de colaborador Correctamente")
                desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR EVALUACIÓN DE COLABORADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oEvaluacionService.Borrar(IdEvaluacion, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EVALUACIÓN DE COLABORADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oEvaluacionDetService.Mostrar(IdEvaluacion).Tables(0)
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
                    cmbPerAutoriza.Focus()
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
                    Dim registro As New EvaluacionService.Evaluacion
                    Dim Persona As New EvaluacionService.Persona
                    Dim Jefe As New EvaluacionService.Persona

                    registro.IdEvaluacion = IdEvaluacion
                    registro.Fecha = txtFecha.Value
                    Persona.IdPer = IdPersona
                    registro.Persona = Persona
                    Jefe.IdPer = cmbPerAutoriza.Value
                    registro.Jefe = Jefe

                    ObtenerDatos()
                    registro.DesArea = DesArea
                    registro.DesCargo = DesCargo
                    registro.TiempoServicio = oEvaluacionService.CalcularTiempoServicio(FecIniPlanilla, txtFecha.Value)
                    registro.DesCargoJefe = DesCargoJefe

                    registro.Fortalezas = txtFortalezas.Text
                    registro.Oportunidades = txtOportunidades.Text
                    registro.Capacitacion = txtCapacitacion.Text

                    registro.CodUsu = Session.sCodUsu
                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp

                    If state_button Then            'Modificar
                        Modificar(registro)
                    Else                                  'Nuevo                    
                        Insertar(registro)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR EVALUACION DE COLABORADOR: " + ex.Message, MsgBoxStyle.Exclamation)
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
                    codigo = dgvDatos.CurrentRow.Cells("IdEvaluacionDet").Text
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
                           , cmbPerAutoriza.KeyPress
        ', txtFortalezas.KeyPress _
        ', txtOportunidades.KeyPress _
        ', txtCapacitacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub miInsertarPlantilla_Click(sender As Object, e As System.EventArgs) Handles miInsertarPlantilla.Click
        If state_button = True Then
            InsertarPlanila()
        End If
    End Sub

    Private Sub InsertarPlanila()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de INSERTAR PLANTILLA de Evaluación?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oEvaluacionDetService.InsertarPlantilla(IdEvaluacion, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    MsgBox("Se insertó la plantilla correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR PLANTILLA de Evaluación: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class