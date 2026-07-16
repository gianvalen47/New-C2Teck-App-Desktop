Imports System.ServiceModel
Public Class frmAsignacionHE

    '=========================== Servicios ===================================================
    Private oAsignacionHoraExtraService As New AsignacionHoraExtraService.AsignacionHoraExtraServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private Persona As New PersonaService.Persona
    Private oJobService As New JobService.JobServiceClient
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Private dtDatos As DataTable
    Public IdPersona As Integer
    Public IdAsignacion As Integer
    Private dtPerAutoriza As DataTable
    Public iProcesado As Boolean            'Campo procesado de la Asignación seleccionada

    Public iIdPersona As Integer = 0           'IdPersona de colaborador seleccionado en la ventana anterior
    Public iFecha As Date

    Private Sub frmAsignacionHE_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmAsignacionHE_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()
 
        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            txtColaborador.TabStop = False
            txtFecha.TabStop = False
            txtNumJob.Focus()
        Else                                      'Nuevo
            txtHoraInicio.Text = Now().ToString("HH:mm:ss")
            txtHoraFinal.Text = Now().ToString("HH:mm:ss")
            activar()
            If iIdPersona <> 0 Then
                ObtenerPersona()
                txtColaborador.TabStop = True
                txtFecha.TabStop = True
                txtColaborador.Focus()
            Else
                txtFecha.TabStop = True
                btnBuscarColaborador.TabStop = True
                btnBuscarColaborador.Select()
            End If
            'txtColaborador.TabStop = True
            'txtFecha.TabStop = True
            'txtColaborador.Focus()

        End If
        EnableOptions()
    End Sub

    Private Sub ObtenerPersona()
        Persona = oPersonaService.Obtener(iIdPersona)
        IdPersona = iIdPersona
        txtColaborador.Text = Persona.ApeNom
    End Sub

    Private Sub frmAsignacionHE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oAsignacionHoraExtraService.Close()
            oPersonaService.Close()
            oJobService.Close()
            oAsignacionJefesService.Close()
        Catch ex As TimeoutException
            oAsignacionHoraExtraService.Abort()
            oPersonaService.Abort()
            oJobService.Abort()
            oAsignacionJefesService.Abort()
        Catch ex As CommunicationException
            oAsignacionHoraExtraService.Abort()
            oPersonaService.Abort()
            oJobService.Abort()
            oAsignacionJefesService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdPersona) = 0 Then
                MsgBox("Debe ingresar el Colaborador. ", MsgBoxStyle.Information, "Información")
                txtColaborador.Focus()
                Return False
            ElseIf toBlank(txtFecha.Value) = "" Then
                MsgBox("Debe ingresar la fecha", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf Not (txtHoraInicio.MaskFull) Or Not (txtHoraFinal.MaskFull) Then
                MsgBox("Debe de Ingresar las horas.", MsgBoxStyle.Information, "Información")
                txtHoraInicio.Focus()
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

    Private Sub EnableOptions()

    End Sub

    Private Sub activar()
        txtColaborador.ReadOnly = True
        txtColaborador.BackColor = System.Drawing.SystemColors.Control
        btnBuscarColaborador.Enabled = True
        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        txtNumJob.ReadOnly = False
        txtNumJob.BackColor = System.Drawing.SystemColors.Window
        btnBuscarJob.Enabled = True
        txtHoraInicio.ReadOnly = False
        txtHoraInicio.BackColor = System.Drawing.SystemColors.Window
        txtHoraFinal.ReadOnly = False
        txtHoraFinal.BackColor = System.Drawing.SystemColors.Window
        cmbPerAutoriza.ReadOnly = False
        cmbPerAutoriza.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        cbProcesado.Visible = False
        btnGuardar.Enabled = True
    End Sub

    Private Sub desactivar()
        If iProcesado = True Then
            txtColaborador.ReadOnly = True
            txtColaborador.BackColor = System.Drawing.SystemColors.Control
            btnBuscarColaborador.Enabled = False
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.ReadOnly = True
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            btnBuscarJob.Enabled = False
            txtHoraInicio.ReadOnly = True
            txtHoraInicio.BackColor = System.Drawing.SystemColors.Control
            txtHoraFinal.ReadOnly = True
            txtHoraFinal.BackColor = System.Drawing.SystemColors.Control
            cmbPerAutoriza.ReadOnly = True
            cmbPerAutoriza.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control
            cbProcesado.Visible = True
            btnGuardar.Enabled = False
        Else
            txtColaborador.ReadOnly = True
            txtColaborador.BackColor = System.Drawing.SystemColors.Control
            btnBuscarColaborador.Enabled = False
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.ReadOnly = False
            txtNumJob.BackColor = System.Drawing.SystemColors.Window
            btnBuscarJob.Enabled = True
            txtHoraInicio.ReadOnly = False
            txtHoraInicio.BackColor = System.Drawing.SystemColors.Window
            txtHoraFinal.ReadOnly = False
            txtHoraFinal.BackColor = System.Drawing.SystemColors.Window
            cmbPerAutoriza.ReadOnly = False
            cmbPerAutoriza.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            cbProcesado.Visible = True
            btnGuardar.Enabled = True
        End If
    End Sub

    Private Sub Insertar(ByVal registro As AsignacionHoraExtraService.AsignacionHoraExtra)
        Try
            Dim estado_process As Integer
            estado_process = oAsignacionHoraExtraService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdAsignacion = estado_process
                iFecha = txtFecha.Value
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR ASIGNACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As AsignacionHoraExtraService.AsignacionHoraExtra)
        Try
            Dim estado_process As Boolean
            estado_process = oAsignacionHoraExtraService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR ASIGNACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As AsignacionHoraExtraService.AsignacionHoraExtra
            registro = oAsignacionHoraExtraService.Obtener(IdAsignacion)

            IdAsignacion = registro.IdAsignacion
            IdPersona = registro.Persona.IdPer
            txtColaborador.Text = registro.Persona.ApeNom
            txtFecha.Value = registro.Fecha
            txtNumJob.Text = registro.Job.CodJob
            txtHoraInicio.Text = registro.HoraInicio.ToString("HH:mm:ss")
            txtHoraFinal.Text = registro.HoraFinal.ToString("HH:mm:ss")
            cmbPerAutoriza.Value = registro.PersonaAutoriza.IdPer
            txtObservacion.Text = registro.Observacion
            cbProcesado.Checked = registro.Procesado

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtColaborador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtColaborador.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarColaborador.Enabled = True Then
                e.Handled = True
                btnBuscarColaborador_Click(sender, e)
            End If
        End If
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

            ObtenerHoras()
        End If
    End Sub

    Private Sub llenarCombos()
        Try

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
                Dim registro As New AsignacionHoraExtraService.AsignacionHoraExtra
                Dim Persona As New AsignacionHoraExtraService.Persona
                Dim PersonaAutoriza As New AsignacionHoraExtraService.Persona
                Dim Job As New AsignacionHoraExtraService.Job

                registro.IdAsignacion = IdAsignacion
                registro.Fecha = txtFecha.Value
                Persona.IdPer = IdPersona
                registro.Persona = Persona
                Job.CodJob = IIf(txtNumJob.Text = "", Nothing, txtNumJob.Text)
                registro.Job = Job
                registro.HoraInicio = txtHoraInicio.Text
                registro.HoraFinal = txtHoraFinal.Text
                PersonaAutoriza.IdPer = cmbPerAutoriza.Value
                registro.PersonaAutoriza = PersonaAutoriza
                registro.Observacion = txtObservacion.Text

                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR ASIGNACIÓN DE HORAS EXTRA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtColaborador.KeyPress _
                           , txtFecha.KeyPress _
                           , cmbPerAutoriza.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNumJob_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumJob.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtHoraInicio.Focus()
            txtHoraInicio.SelectAll()
        End If
    End Sub

    Private Sub txtHoraInicio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHoraInicio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtHoraFinal.Focus()
            txtHoraFinal.SelectAll()
        End If
    End Sub

    Private Sub txtHoraFinal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHoraFinal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            cmbPerAutoriza.Focus()
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
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
                    txtHoraInicio.Focus()
                End If
            Else
                txtHoraInicio.Focus()
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
                    txtHoraInicio.Focus()
                End If
            Else
                txtHoraInicio.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL JOB: " + ex.Message)
        End Try
    End Sub

    Private Sub txtFecha_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecha.ValueChanged
        ObtenerHoras()
    End Sub

    Private Sub ObtenerHoras()
        Try
            If IdPersona <> 0 And toBlank(txtFecha.Value) <> "" Then
                txtHoraInicio.Text = oAsignacionHoraExtraService.SugerirInicio(IdPersona, txtFecha.Value)
                txtHoraFinal.Text = oAsignacionHoraExtraService.SugerirSalida(IdPersona, txtFecha.Value)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL SUGERIR HORA INICIO Y HORA FINAL: " + ex.Message)
        End Try
    End Sub
End Class