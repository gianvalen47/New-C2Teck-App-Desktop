Imports System.ServiceModel
Public Class frmFaltaPersonal

    '===========================Servicios====================================================
    Private oFaltasService As New FaltasService.FaltasServiceClient
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private Persona As New PersonaService.Persona

    '======================Declaración de Variables==============================================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public IdFalta As Integer
    Public IdPersona As Integer
    Public ApeNom As String
    Private dtMotivo As DataTable
    Private dtPerAutoriza As DataTable
    Public iPagago As Boolean            'Campo pagado de la Falta seleccionada

    Public iIdPersona As Integer = 0           'IdPersona de colaborador seleccionado en la ventana anterior

    Private Sub frmFaltaPersonal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            desactivar()
            cmbMotivo.Value = "01"
            ObtenerRegistro()
            Me.Text = "Falta de: " + Chr(34) + ApeNom + Chr(34)
            txtColaborador.TabStop = False
            cmbMotivo.Focus()
        Else                                      'Nuevo
            Me.Text = "Registrar nueva Falta"
            activar()
            If iIdPersona <> 0 Then
                ObtenerPersona()
                cmbMotivo.Value = "02"
                txtColaborador.TabStop = True
                txtColaborador.Focus()
            Else
                cmbMotivo.Value = "02"
                btnBuscarColaborador.TabStop = True
                btnBuscarColaborador.Select()
                'cmbMotivo.Value = "02"
                'txtColaborador.TabStop = True
                'txtColaborador.Focus()
            End If
            'cmbMotivo.Value = "02"
            'txtColaborador.TabStop = True
            'txtColaborador.Focus()
        End If
        EnableOptions()
    End Sub

    Private Sub ObtenerPersona()
        Persona = oPersonaService.Obtener(iIdPersona)
        IdPersona = iIdPersona
        txtColaborador.Text = Persona.ApeNom
    End Sub

    Private Sub frmFaltaPersonal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oFaltasService.Close()
            oAsignacionJefesService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oFaltasService.Abort()
            oAsignacionJefesService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oFaltasService.Abort()
            oAsignacionJefesService.Abort()
            oPersonaService.Abort()
        End Try
    End Sub

    Private Sub frmFaltaPersonal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()       
    End Sub

    Private Sub llenarCombos()
        Try
            
            '======================================== MOTIVO ================================================
            dtMotivo = oFaltasService.MostrarMotivos(Session.sCodUsu).Tables(0)
            cmbMotivo.DataSource = dtMotivo
            cmbMotivo.DropDownList.DataMember = dtMotivo.Columns("DesMotivo").ToString
            cmbMotivo.DropDownList.DisplayMember = dtMotivo.Columns("DesMotivo").ToString
            cmbMotivo.DropDownList.ValueMember = dtMotivo.Columns("CodMotivo").ToString
            cmbMotivo.DropDownList.Columns(0).DataMember = dtMotivo.Columns("CodMotivo").ToString
            cmbMotivo.DropDownList.Columns(1).DataMember = dtMotivo.Columns("DesMotivo").ToString
            cmbMotivo.DropDownList.Columns(2).DataMember = dtMotivo.Columns("ValorTiempo").ToString
            cmbMotivo.SelectedIndex = 0
            dtMotivo = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOptions()

    End Sub

    Private Sub activar()      
        txtColaborador.ReadOnly = True
        txtColaborador.BackColor = System.Drawing.SystemColors.Control
        btnBuscarColaborador.Enabled = True
        cmbMotivo.ReadOnly = False
        cmbMotivo.BackColor = System.Drawing.SystemColors.Window
        txtFechaInicio.ReadOnly = False
        txtFechaInicio.BackColor = System.Drawing.SystemColors.Window
        txtFechaFinal.ReadOnly = False
        txtFechaFinal.BackColor = System.Drawing.SystemColors.Window
        cmbPerAutoriza.ReadOnly = False
        cmbPerAutoriza.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        cbPagado.Visible = False
        btnGuardar.Enabled = True
        txtColaborador.Focus()
    End Sub

    Private Sub desactivar()
        If iPagago = True Then
            txtColaborador.ReadOnly = True
            txtColaborador.BackColor = System.Drawing.SystemColors.Control
            btnBuscarColaborador.Enabled = False
            cmbMotivo.ReadOnly = True
            cmbMotivo.BackColor = System.Drawing.SystemColors.Control
            txtFechaInicio.ReadOnly = True
            txtFechaInicio.BackColor = System.Drawing.SystemColors.Control
            txtFechaFinal.ReadOnly = True
            txtFechaFinal.BackColor = System.Drawing.SystemColors.Control
            txtHoraInicio.ReadOnly = True
            txtHoraInicio.BackColor = System.Drawing.SystemColors.Control
            txtHoraFinal.ReadOnly = True
            txtHoraFinal.BackColor = System.Drawing.SystemColors.Control
            cmbPerAutoriza.ReadOnly = True
            cmbPerAutoriza.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control
            cbPagado.Visible = True
            btnGuardar.Enabled = False
            txtColaborador.Focus()
        Else
            txtColaborador.ReadOnly = True
            txtColaborador.BackColor = System.Drawing.SystemColors.Control
            btnBuscarColaborador.Enabled = False
            cmbMotivo.ReadOnly = False
            cmbMotivo.BackColor = System.Drawing.SystemColors.Window
            txtFechaInicio.ReadOnly = False
            txtFechaInicio.BackColor = System.Drawing.SystemColors.Window
            txtFechaFinal.ReadOnly = False
            txtFechaFinal.BackColor = System.Drawing.SystemColors.Window
            cmbPerAutoriza.ReadOnly = True
            cmbPerAutoriza.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            cbPagado.Visible = True
            btnGuardar.Enabled = True
            cmbMotivo.Focus()
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If IdPersona = 0 Then
                MsgBox("Debe Ingresar el Colaborador.", MsgBoxStyle.Information, "Información")
                txtColaborador.Focus()
                Return False
            ElseIf toBlank(cmbMotivo.Value) = "" Then
                MsgBox("Debe Ingresar el motivo de la falta.", MsgBoxStyle.Information, "Información")
                cmbMotivo.Focus()
                Return False
            ElseIf toBlank(cmbMotivo.Value) = "01" Then
                MsgBox("El motivo vacaciones se ingresa por el módulo de vacaciones.", MsgBoxStyle.Information, "Información")
                cmbMotivo.Focus()
                Return False
            ElseIf toBlank(txtFechaInicio.Value) = "" Or toBlank(txtFechaFinal.Value) = "" Then
                MsgBox("Debe de Ingresar las fechas de duración.", MsgBoxStyle.Information, "Información")
                txtFechaInicio.Focus()
                Return False
            ElseIf oFaltasService.ObtenerValorTiempo(toBlank(cmbMotivo.Value)) = "Horas" And (Not (txtHoraInicio.MaskFull) Or Not (txtHoraFinal.MaskFull)) Then
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

    Private Sub ObtenerRegistro()
        Try
            Dim registro As FaltasService.Faltas
            registro = oFaltasService.Obtener(IdFalta)

            IdFalta = registro.IdFalta
            IdPersona = registro.Persona.IdPer
            txtColaborador.Text = registro.Persona.ApeNom
            cmbMotivo.Value = registro.MotivoFaltas.CodMotivo
            txtFechaInicio.Value = registro.FecInicio
            txtFechaFinal.Value = registro.FecFinal
            txtHoraInicio.Text = IIf(registro.HorInicio = Nothing, "", registro.HorInicio.ToString("HH:mm:ss"))
            txtHoraFinal.Text = IIf(registro.HorFinal = Nothing, "", registro.HorFinal.ToString("HH:mm:ss"))
            cmbPerAutoriza.Value = registro.PersonaAutoriza.IdPer
            txtObservacion.Text = registro.Observacion
            cbPagado.Checked = registro.Pagado

            Me.Text = "Falta de: " + registro.Persona.ApeNom
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As FaltasService.Faltas)
        Try
            Dim estado_process As Integer
            estado_process = oFaltasService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdFalta = estado_process
                MsgBox("Se insertó la Falta Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR FALTA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As FaltasService.Faltas)
        Try
            Dim estado_process As Boolean
            estado_process = oFaltasService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR FALTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oFaltasService.Borrar(IdFalta, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR FALTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarColaborador_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarColaborador.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersona = frm.codigo
                    txtColaborador.Text = frm.descripcion
                    cmbMotivo.Focus()
                Else
                    IdPersona = 0
                    txtColaborador.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim registro As New FaltasService.Faltas
                    Dim Colaborador As New FaltasService.Persona
                    Dim PersonaAutoriza As New FaltasService.Persona
                    Dim MotivoFalta As New FaltasService.MotivoFaltas
                    Dim VacacionesDet As New FaltasService.VacacionesDet    'Para faltas que vienen de Mantenimiento Vacaciones

                    registro.IdFalta = IdFalta
                    Colaborador.IdPer = IdPersona
                    registro.Persona = Colaborador
                    MotivoFalta.CodMotivo = cmbMotivo.Value
                    registro.MotivoFaltas = MotivoFalta
                    registro.FecInicio = txtFechaInicio.Value
                    registro.FecFinal = txtFechaFinal.Value
                    registro.HorInicio = IIf(Not (txtHoraInicio.MaskFull), Nothing, txtHoraInicio.Text)
                    registro.HorFinal = IIf(Not (txtHoraFinal.MaskFull), Nothing, txtHoraFinal.Text)
                    PersonaAutoriza.IdPer = cmbPerAutoriza.Value
                    registro.PersonaAutoriza = PersonaAutoriza
                    registro.Observacion = IIf(txtObservacion.Text = "", Nothing, txtObservacion.Text)
                    VacacionesDet.IdVacacionesDet = Nothing
                    registro.VacacionesDet = VacacionesDet
                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp
                    registro.CodUsu = Session.sCodUsu
                    If state_button Then            'Modificar
                        Modificar(registro)
                    Else                                  'Nuevo
                        registro.FecReg = Today
                        Insertar(registro)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR FALTA PERSONAL: " + ex.Message, MsgBoxStyle.Exclamation)
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
            txtEmpresa.Text = Persona.Empresa.DesEmp

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
        Else
            txtEmpresa.Text = ""
            cmbPerAutoriza.SelectedIndex = 0
        End If
    End Sub

    Private Sub cmbMotivo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMotivo.ValueChanged
        If oFaltasService.ObtenerValorTiempo(cmbMotivo.Value) = "Horas" Then
            txtHoraInicio.ReadOnly = False
            txtHoraInicio.BackColor = System.Drawing.SystemColors.Window
            txtHoraFinal.ReadOnly = False
            txtHoraFinal.BackColor = System.Drawing.SystemColors.Window
            If state_button = False Then
                txtHoraInicio.Text = Now().ToString("HH:mm:ss")
                txtHoraFinal.Text = Now().ToString("HH:mm:ss")
            End If            
        Else
            txtHoraInicio.ReadOnly = True
            txtHoraInicio.BackColor = System.Drawing.SystemColors.Control
            txtHoraFinal.ReadOnly = True
            txtHoraFinal.BackColor = System.Drawing.SystemColors.Control
            txtHoraInicio.Text = ""
            txtHoraFinal.Text = ""
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtColaborador.KeyPress _
                          , txtEmpresa.KeyPress _
                          , cmbMotivo.KeyPress _
                          , txtFechaInicio.KeyPress _
                          , txtHoraFinal.KeyPress _
                          , cmbPerAutoriza.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtFechaFinal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFechaFinal.KeyPress
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

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub
End Class