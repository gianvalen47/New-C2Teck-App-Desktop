Imports System.ServiceModel
Public Class frmFaltaPersonalConpensarHoras

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

    Private Sub frmFaltaPersonalConpensarHoras_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar

        'Nuevo
        Me.Text = "Registrar nueva Falta por Compensación de Horas Extras"
        activar()
        If iIdPersona <> 0 Then
            ObtenerPersona()
        End If

        txtColaborador.TabStop = True
        txtColaborador.Focus()

        EnableOptions()
    End Sub

    Private Sub ObtenerPersona()
        Persona = oPersonaService.Obtener(iIdPersona)
        IdPersona = iIdPersona
        txtColaborador.Text = Persona.ApeNom
    End Sub

    Private Sub frmFaltaPersonal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub frmFaltaPersonal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Finalizar()
    End Sub


    Private Sub EnableOptions()

    End Sub

    Private Sub activar()
        txtColaborador.ReadOnly = True
        txtColaborador.BackColor = System.Drawing.SystemColors.Control
        btnBuscarColaborador.Enabled = True

        txtFechaInicio.ReadOnly = False
        txtFechaInicio.BackColor = System.Drawing.SystemColors.Window
        txtFechaFinal.ReadOnly = False
        txtFechaFinal.BackColor = System.Drawing.SystemColors.Window
        cmbPerAutoriza.ReadOnly = False
        cmbPerAutoriza.BackColor = System.Drawing.SystemColors.Window

        btnGuardar.Enabled = True
        txtColaborador.Focus()
    End Sub

    Private Sub desactivar()
        If iPagago = True Then
            txtColaborador.ReadOnly = True
            txtColaborador.BackColor = System.Drawing.SystemColors.Control
            btnBuscarColaborador.Enabled = False

            txtFechaInicio.ReadOnly = True
            txtFechaInicio.BackColor = System.Drawing.SystemColors.Control
            txtFechaFinal.ReadOnly = True
            txtFechaFinal.BackColor = System.Drawing.SystemColors.Control

            cmbPerAutoriza.ReadOnly = True
            cmbPerAutoriza.BackColor = System.Drawing.SystemColors.Control

            btnGuardar.Enabled = False
            txtColaborador.Focus()
        Else
            txtColaborador.ReadOnly = True
            txtColaborador.BackColor = System.Drawing.SystemColors.Control
            btnBuscarColaborador.Enabled = False

            txtFechaInicio.ReadOnly = False
            txtFechaInicio.BackColor = System.Drawing.SystemColors.Window
            txtFechaFinal.ReadOnly = False
            txtFechaFinal.BackColor = System.Drawing.SystemColors.Window
            cmbPerAutoriza.ReadOnly = True
            cmbPerAutoriza.BackColor = System.Drawing.SystemColors.Control

            btnGuardar.Enabled = True

        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If IdPersona = 0 Then
                MsgBox("Debe Ingresar el Colaborador.", MsgBoxStyle.Information, "Información")
                txtColaborador.Focus()
                Return False

            ElseIf toBlank(txtFechaInicio.Value) = "" Or toBlank(txtFechaFinal.Value) = "" Then
                MsgBox("Debe de Ingresar las fechas de duración.", MsgBoxStyle.Information, "Información")
                txtFechaInicio.Focus()
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

            txtFechaInicio.Value = registro.FecInicio
            txtFechaFinal.Value = registro.FecFinal

            cmbPerAutoriza.Value = registro.PersonaAutoriza.IdPer

            Me.Text = "Falta de: " + registro.Persona.ApeNom
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub btnBuscarColaborador_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarColaborador.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersona = frm.codigo
                    txtColaborador.Text = frm.descripcion
                    llenardatos()
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
                    Dim estado_process As Integer
                    estado_process = oFaltasService.GenerarCompensarHoras(Session.sCodEmp, txtFechaInicio.Value, txtFechaFinal.Value, txtFechaProceso.Value, txtHoraInicio.Text, IdPersona, cmbPerAutoriza.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    type_process = "insert"
                    If estado_process > 0 Then
                        IdFalta = estado_process
                        MsgBox("Se insertó la Falta Correctamente")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
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

            cmbPerAutoriza.SelectedIndex = 0
        End If
    End Sub


    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFechaInicio.KeyPress, txtColaborador.KeyPress, cmbPerAutoriza.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtFechaFinal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFechaFinal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True

        End If
    End Sub

    Private Sub txtHoraInicio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles txtFechaInicio.ValueChanged, txtFechaFinal.ValueChanged, btnConsultar.Click
        llenardatos()
    End Sub

    Private Sub llenardatos()
        Try
            Dim dtDetalle As DataTable
            dtDetalle = oFaltasService.ConsultarHorasCompensar(IdPersona, txtFechaInicio.Value, txtFechaFinal.Value).Tables(0)
            dgvDatos.DataSource = dtDetalle
            If dtDetalle.Rows.Count > 0 Then
                txtTotalHoras.Text = utils.ConvertirEnHoras(dtDetalle.Compute("Sum(TotalMinutos)", String.Empty))
            End If
        Catch ex As Exception
            MsgBox("ERROR AL CARGAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


End Class