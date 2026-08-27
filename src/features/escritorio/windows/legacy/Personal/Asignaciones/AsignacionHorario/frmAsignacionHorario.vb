Imports System.ServiceModel
Public Class frmAsignacionHorario

    '=========================== Servicios ===================================================
    Private oAsignacionHorarioService As New AsignacionHorarioService.AsignacionHorarioServiceClient
    Private oHorarioService As New HorarioService.HorarioServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private Persona As New PersonaService.Persona

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public IdPersona As Integer
    Private dtHorarios As New DataTable

    Public iIdPersona As Integer = 0           'IdPersona de colaborador seleccionado en la ventana anterior

    Private Sub frmAsignacionHorario_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmAsignacionHorario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            txtColaborador.TabStop = False
            cmbHorario.Focus()
        Else                                      'Nuevo
            txtFecInicio.Value = Today
            txtFecInicio.Value = Today
            activar()
            If iIdPersona <> 0 Then
                ObtenerPersona()
                txtColaborador.TabStop = True
                txtColaborador.Focus()
            Else
                btnBuscarColaborador.TabStop = True
                btnBuscarColaborador.Select()
            End If
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

    Private Sub frmAsignacionHorario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oAsignacionHorarioService.Close()
            oHorarioService.Close()
            oPersonaService.Close()            
        Catch ex As TimeoutException
            oAsignacionHorarioService.Abort()
            oHorarioService.Abort()
            oPersonaService.Abort()            
        Catch ex As CommunicationException
            oAsignacionHorarioService.Abort()
            oHorarioService.Abort()
            oPersonaService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdPersona) = 0 Then
                MsgBox("Debe ingresar el Colaborador. ", MsgBoxStyle.Information, "Información")
                txtColaborador.Focus()
                Return False
            ElseIf toBlank(cmbHorario.Value) = "" Then
                MsgBox("Debe de Ingresar el horario.", MsgBoxStyle.Information, "Información")
                cmbHorario.Focus()
                Return False
            ElseIf toBlank(txtFecInicio.Value) = "" Then
                MsgBox("Debe ingresar la fecha de inicio", MsgBoxStyle.Information, "Información")
                txtFecInicio.Focus()
                Return False
            ElseIf toBlank(txtFecFinal.Value) = "" Then
                MsgBox("Debe ingresar la fecha final", MsgBoxStyle.Information, "Información")
                txtFecFinal.Focus()
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
        cmbHorario.ReadOnly = False
        cmbHorario.BackColor = System.Drawing.SystemColors.Window
        cbHorarioLector.Enabled = True
        txtFecInicio.ReadOnly = False
        txtFecInicio.BackColor = System.Drawing.SystemColors.Window
        txtFecFinal.ReadOnly = False
        txtFecFinal.BackColor = System.Drawing.SystemColors.Window
        cbVigente.Enabled = True
        cbVigente.Visible = False
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        btnGuardar.Enabled = True
    End Sub

    Private Sub desactivar()        
        txtColaborador.ReadOnly = True
        txtColaborador.BackColor = System.Drawing.SystemColors.Control
        btnBuscarColaborador.Enabled = False
        cmbHorario.ReadOnly = False
        cmbHorario.BackColor = System.Drawing.SystemColors.Window
        cbHorarioLector.Enabled = True
        txtFecInicio.ReadOnly = False
        txtFecInicio.BackColor = System.Drawing.SystemColors.Window
        txtFecFinal.ReadOnly = False
        txtFecFinal.BackColor = System.Drawing.SystemColors.Window
        cbVigente.Enabled = True
        cbVigente.Visible = True
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        btnGuardar.Enabled = True
    End Sub

    Private Sub Insertar(ByVal registro As AsignacionHorarioService.AsignacionHorario)
        Try
            Dim estado_process As Boolean
            estado_process = oAsignacionHorarioService.Insertar(registro)
            type_process = "insert"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR ASIGNACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As AsignacionHorarioService.AsignacionHorario)
        Try
            Dim estado_process As Boolean
            estado_process = oAsignacionHorarioService.Actualizar(registro)
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
            Dim registro As AsignacionHorarioService.AsignacionHorario
            registro = oAsignacionHorarioService.Obtener(IdPersona)

            IdPersona = registro.Persona.IdPer
            txtColaborador.Text = registro.Persona.ApeNom
            cmbHorario.Value = registro.Horario.CodHor
            cbHorarioLector.Checked = registro.HorarioLector
            txtFecInicio.Value = registro.FecInicio
            txtFecFinal.Value = registro.FecFinal
            cbVigente.Checked = registro.Vigente
            txtObservacion.Text = registro.Observacion

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

    Private Sub llenarCombos()
        Try

            '======================================= HORARIOS =============================================
            dtHorarios = oHorarioService.Mostrar(Session.sCodEmp).Tables(0)
            cmbHorario.DataSource = dtHorarios
            cmbHorario.DropDownList.DataMember = dtHorarios.Columns("DesHor").ToString
            cmbHorario.DropDownList.DisplayMember = dtHorarios.Columns("DesHor").ToString
            cmbHorario.DropDownList.ValueMember = dtHorarios.Columns("CodHor").ToString
            cmbHorario.DropDownList.Columns(0).DataMember = dtHorarios.Columns("CodHor").ToString
            cmbHorario.DropDownList.Columns(1).DataMember = dtHorarios.Columns("DesHor").ToString
            cmbHorario.SelectedIndex = 0
            dtHorarios = Nothing

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
                Dim registro As New AsignacionHorarioService.AsignacionHorario
                Dim Persona As New AsignacionHorarioService.Persona
                Dim Horario As New AsignacionHorarioService.Horario
                Dim empresa As New AsignacionHorarioService.Empresa

                empresa.CodEmp = Session.sCodEmp
                Persona.IdPer = IdPersona
                registro.Persona = Persona
                Horario.CodHor = cmbHorario.Value
                registro.Horario = Horario
                registro.Horario.Empresa = empresa
                registro.HorarioLector = cbHorarioLector.Checked
                registro.FecInicio = txtFecInicio.Value
                registro.FecFinal = txtFecFinal.Value
                registro.Vigente = cbVigente.Checked
                registro.Observacion = IIf(txtObservacion.Text = "", Nothing, txtObservacion.Text)                

                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    registro.FecReg = Today
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR ASIGNACIÓN DE HORARIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtColaborador.KeyPress _
                           , cmbHorario.KeyPress _
                           , cbHorarioLector.KeyPress _
                           , txtFecInicio.KeyPress _
                           , txtFecFinal.KeyPress _
                           , cbVigente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
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
                    cmbHorario.Focus()
                Else
                    IdPersona = 0
                    txtColaborador.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class