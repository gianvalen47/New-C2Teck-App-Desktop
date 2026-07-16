Imports System.ServiceModel
Public Class frmCronograMina
    '===========================Servicios====================================================
    Private oAsignacionHorarioService As New AsignacionHorarioService.AsignacionHorarioServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private Persona As New PersonaService.Persona

    '======================Declaración de Variables==============================================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public IdCronograma As Integer
    Public IdPersona As Integer
    Public ApeNom As String
    Private dtTipo As DataTable
    Private dtUbicacion As DataTable

    Public iIdPersona As Integer = 0
    Public iCodUbicacion As String = ""


    Private Sub frmCronograMina_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            desactivar()            
            ObtenerRegistro()
            Me.Text = "Cronograma de Mina"
            txtColaborador.TabStop = False
            cmbUbicacion.Focus()
        Else                                      'Nuevo
            Me.Text = "Registrar nuevo Cronograma de Mina"
            activar()
            If iIdPersona <> 0 Then
                ObtenerPersona()
                txtColaborador.TabStop = True
                txtColaborador.Focus()
            Else
                btnBuscarColaborador.TabStop = True
                btnBuscarColaborador.Select()
            End If

            If toBlank(iCodUbicacion) <> "" Then
                cmbUbicacion.Value = iCodUbicacion
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

    Private Sub frmCronograMinal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oAsignacionHorarioService.Close()
            oPersonaService.Close()
            oJobService.Close()
        Catch ex As TimeoutException
            oAsignacionHorarioService.Abort()
            oPersonaService.Abort()
            oJobService.Abort()
        Catch ex As CommunicationException
            oAsignacionHorarioService.Abort()
            oPersonaService.Abort()
            oJobService.Abort()
        End Try
    End Sub

    Private Sub frmCronograMina_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub llenarCombos()
        Try

            '======================================== TIPO ================================================
            dtTipo = oAsignacionHorarioService.MostrarTipoCronograma().Tables(0)
            'dtTipo.Rows.InsertAt(getRowTodos(dtTipo), 0)
            cmbTipo.DataSource = dtTipo
            cmbTipo.DropDownList.DataMember = dtTipo.Columns("DesTipo").ToString
            cmbTipo.DropDownList.DisplayMember = dtTipo.Columns("DesTipo").ToString
            cmbTipo.DropDownList.ValueMember = dtTipo.Columns("IdTipo").ToString
            cmbTipo.DropDownList.Columns(0).DataMember = dtTipo.Columns("IdTipo").ToString
            cmbTipo.DropDownList.Columns(1).DataMember = dtTipo.Columns("DesTipo").ToString
            cmbTipo.SelectedIndex = 0
            dtTipo = Nothing

            '===================================== UBICACIÓN ===============================================
            dtUbicacion = oJobService.MostrarUbicacionEquipo.Tables(0)
            'dtUbicacion.Rows.InsertAt(getRowTodos(dtUbicacion), 0)
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

    Private Sub EnableOptions()

    End Sub

    Private Sub activar()
        txtColaborador.ReadOnly = True
        txtColaborador.BackColor = System.Drawing.SystemColors.Control
        btnBuscarColaborador.Enabled = True
        cmbUbicacion.ReadOnly = False
        cmbUbicacion.BackColor = System.Drawing.SystemColors.Window
        cmbTipo.ReadOnly = False
        cmbTipo.BackColor = System.Drawing.SystemColors.Window
        txtFechaInicio.ReadOnly = False
        txtFechaInicio.BackColor = System.Drawing.SystemColors.Window
        txtFechaFinal.ReadOnly = False
        txtFechaFinal.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        btnGuardar.Enabled = True
        txtColaborador.Focus()
    End Sub

    Private Sub desactivar()      
        txtColaborador.ReadOnly = True
        txtColaborador.BackColor = System.Drawing.SystemColors.Control
        btnBuscarColaborador.Enabled = False
        cmbUbicacion.ReadOnly = False
        cmbUbicacion.BackColor = System.Drawing.SystemColors.Window
        cmbTipo.ReadOnly = False
        cmbTipo.BackColor = System.Drawing.SystemColors.Window
        txtFechaInicio.ReadOnly = False
        txtFechaInicio.BackColor = System.Drawing.SystemColors.Window
        txtFechaFinal.ReadOnly = False
        txtFechaFinal.BackColor = System.Drawing.SystemColors.Window        
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window        
        btnGuardar.Enabled = True        
        cmbUbicacion.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If IdPersona = 0 Then
                MsgBox("Debe Ingresar el Colaborador.", MsgBoxStyle.Information, "Información")
                txtColaborador.Focus()
                Return False
            ElseIf toBlank(cmbUbicacion.Value) = "" Then
                MsgBox("Debe Ingresar la Ubicación del Cronograma de Mina.", MsgBoxStyle.Information, "Información")
                cmbUbicacion.Focus()
                Return False
            ElseIf toBlank(cmbTipo.Value) = "" Then
                MsgBox("Debe Ingresar el Tipo del Cronograma de Mina.", MsgBoxStyle.Information, "Información")
                cmbTipo.Focus()
                Return False
            ElseIf toBlank(txtFechaInicio.Value) = "" Or toBlank(txtFechaFinal.Value) = "" Then
                MsgBox("Debe de Ingresar las fechas de duración.", MsgBoxStyle.Information, "Información")
                txtFechaInicio.Focus()
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
            Dim registro As AsignacionHorarioService.CronogramaMinas
            registro = oAsignacionHorarioService.ObtenerCronograma(IdCronograma)

            IdCronograma = registro.IdCronograma
            IdPersona = registro.Persona.IdPer
            txtColaborador.Text = registro.Persona.ApeNom
            cmbUbicacion.Value = registro.UbicacionEquipo.CodUbicacion
            cmbTipo.Value = toNumber(registro.TipoCronograma.IdTipo)
            txtFechaInicio.Value = registro.FecInicio
            txtFechaFinal.Value = registro.FecFinal            
            txtObservacion.Text = registro.Observacion

            Me.Text = "Cronograma de Mina"
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As AsignacionHorarioService.CronogramaMinas)
        Try
            Dim estado_process As Integer
            estado_process = oAsignacionHorarioService.InsertarCronograma(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdCronograma = estado_process
                MsgBox("Se insertó el Cronograma de Mina Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR CRONOGRAMA DE MINA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As AsignacionHorarioService.CronogramaMinas)
        Try
            Dim estado_process As Boolean
            estado_process = oAsignacionHorarioService.ActualizarCronograma(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR CRONOGRAMA DE MINA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oAsignacionHorarioService.BorrarCronograma(IdCronograma, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR CRONOGRAMA DE MINA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarColaborador_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarColaborador.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersona = frm.codigo
                    txtColaborador.Text = frm.descripcion
                    cmbUbicacion.Focus()
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

                    Dim registro As New AsignacionHorarioService.CronogramaMinas
                    Dim Colaborador As New AsignacionHorarioService.Persona                    
                    Dim Ubicacion As New AsignacionHorarioService.UbicacionEquipo
                    Dim Tipo As New AsignacionHorarioService.TipoCronograma

                    registro.IdCronograma = IdCronograma
                    Colaborador.IdPer = IdPersona
                    registro.Persona = Colaborador
                    Ubicacion.CodUbicacion = cmbUbicacion.Value
                    registro.UbicacionEquipo = Ubicacion
                    Tipo.IdTipo = cmbTipo.Value
                    registro.TipoCronograma = Tipo
                    registro.FecInicio = txtFechaInicio.Value
                    registro.FecFinal = txtFechaFinal.Value
                    registro.Observacion = IIf(txtObservacion.Text = "", Nothing, txtObservacion.Text)
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
            MsgBox("ERROR AL GUARDAR CRONOGRAMA DE MINA: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                           txtColaborador.KeyPress _
                         , cmbUbicacion.KeyPress _
                         , cmbTipo.KeyPress _
                         , txtFechaInicio.KeyPress _
                         , txtFechaFinal.KeyPress
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
End Class