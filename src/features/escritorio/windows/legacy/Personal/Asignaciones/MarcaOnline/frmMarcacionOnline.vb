Imports System.ServiceModel
Public Class frmMarcacionOnline

    '=========================== Servicios ====================================================
    Private oMarcacionService As New MarcacionService.MarcacionServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oHorarioService As New HorarioService.HorarioServiceClient
    Private Persona As New PersonaService.Persona
    Private empresaUsuario As New EmpresaUsuarioService.EmpresaUsuario
    Private oEmpresaUsuario As New EmpresaUsuarioService.EmpresaUsuarioServiceClient
    '======================Declaración de Variables==============================================

    Public type_process As String                'update     insert      delete
    Public IdPersona As Integer = 0
    Private dtEquipo As DataTable
    Private dtHorarios As New DataTable


    Private Sub frmMarcacionPersonal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()

        txtFecha.Value = Today()

        Me.CancelButton = Me.btnCancelar
        Me.AcceptButton = Me.btnGuardar
        llenarCombos()
        ObtenerPersona()


        Me.Text = "Registrar nueva Marcación"
            activar()

        ObtenerPersona()
        btnGuardar.TabStop = True
        btnGuardar.Focus()

    End Sub

    Private Sub ObtenerPersona()

        empresaUsuario = oEmpresaUsuario.Obtener(Session.sCodUsu, Session.sCodEmp)
        IdPersona = empresaUsuario.Persona.IdPer
        txtColaborador.Text = empresaUsuario.Persona.ApeNom

    End Sub

    Private Sub frmMarcacionPersonall_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oMarcacionService.Close()
            oPersonaService.Close()
            oEmpresaUsuario.Close()
        Catch ex As TimeoutException
            oMarcacionService.Abort()
            oPersonaService.Abort()
            oEmpresaUsuario.Abort()
        Catch ex As CommunicationException
            oMarcacionService.Abort()
            oPersonaService.Abort()
            oEmpresaUsuario.Abort()
        End Try
    End Sub

    Private Sub frmFaltaPersonal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Finalizar()
    End Sub

    Private Sub llenarCombos()
        Try

            ''======================================== EQUIPO ================================================
            dtEquipo = oMarcacionService.MostrarLectoresEmpresa(Session.sCodEmp).Tables(0)
            'dtEquipo.Rows.InsertAt(getRowTodos(dtEquipo), 0)
            cmbEquipo.DataSource = dtEquipo
            cmbEquipo.DropDownList.DataMember = dtEquipo.Columns("DesEquipo").ToString
            cmbEquipo.DropDownList.DisplayMember = dtEquipo.Columns("DesEquipo").ToString
            cmbEquipo.DropDownList.ValueMember = dtEquipo.Columns("IdEquipo").ToString
            cmbEquipo.DropDownList.Columns(0).DataMember = dtEquipo.Columns("IdEquipo").ToString
            cmbEquipo.DropDownList.Columns(1).DataMember = dtEquipo.Columns("DesEquipo").ToString
            cmbEquipo.SelectedIndex = 1
            dtEquipo = Nothing

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

    Private Sub activar()
        txtColaborador.ReadOnly = True
        txtColaborador.BackColor = System.Drawing.SystemColors.Control

        cmbEquipo.ReadOnly = False
        cmbEquipo.BackColor = System.Drawing.SystemColors.Window
        'txtFecha.ReadOnly = False
        'txtFecha.BackColor = System.Drawing.SystemColors.Window
        'txtHoraMarcaIng.ReadOnly = False
        'txtHoraMarcaIng.BackColor = System.Drawing.SystemColors.Window
        txtHoraMarcaIng.Text = Now().ToString("HH:mm:ss")

        btnGuardar.Enabled = True
        txtColaborador.Focus()
    End Sub

    Private Sub desactivar()

        txtColaborador.ReadOnly = True
            txtColaborador.BackColor = System.Drawing.SystemColors.Control

        cmbEquipo.ReadOnly = False
            cmbEquipo.BackColor = System.Drawing.SystemColors.Window
        '    txtFecha.ReadOnly = True
        '    txtFecha.BackColor = System.Drawing.SystemColors.Control
        '    txtHoraMarcaIng.ReadOnly = True
        txtHoraMarcaIng.BackColor = System.Drawing.SystemColors.Control
        btnGuardar.Enabled = True
            cmbEquipo.Focus()

    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If IdPersona = 0 Then
                MsgBox("Debe Ingresar el Colaborador.", MsgBoxStyle.Information, "Información")
                txtColaborador.Focus()
                Return False
            ElseIf toBlank(cmbEquipo.Value) = "" Then
                MsgBox("Debe Ingresar el equipo donde se realizó la marcación.", MsgBoxStyle.Information, "Información")
                cmbEquipo.Focus()
                Return False
            ElseIf toBlank(txtFecha.Value) = "" Then
                MsgBox("Debe de Ingresar la Fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf Not (txtHoraMarcaIng.MaskFull) Then
                MsgBox("Debe ingresar la fecha de ingreso.")
                txtHoraMarcaIng.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Insertar(ByVal registro As MarcacionService.Marcacion)
        Try
            Dim estado_process As Boolean
            estado_process = oMarcacionService.InsertarMarcacionEquipo(registro)
            type_process = "insert"
            If estado_process Then
                MsgBox("Se insertó la Marcación Correctamente.")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Finalizar()
                Me.Close()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR MARCACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub



    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim registro As New MarcacionService.Marcacion
                    Dim Colaborador As New MarcacionService.Persona
                    Dim Equipo As New MarcacionService.EquipoMarcacion
                    Dim Horario As New MarcacionService.Horario    'Este dato no es alimentado en este módulo
                    Dim empresa As New MarcacionService.Empresa

                    empresa.CodEmp = Session.sCodEmp
                    registro.IdMarca = 0
                    Colaborador.IdPer = IdPersona
                    registro.Persona = Colaborador
                    Equipo.IdEquipo = cmbEquipo.Value
                    registro.EquipoMarcacion = Equipo
                    registro.Fecha = txtFecha.Value
                    registro.HoraMarcaIng = txtHoraMarcaIng.Text
                    registro.HoraMarcaSal = txtHoraMarcaIng.Text
                    registro.Observacion = "Marcación Online"
                    Horario.CodHor = toBlank(cmbHorario.Value)
                    registro.Horario = Horario
                    registro.Horario.Empresa = empresa
                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp
                    registro.CodUsu = Session.sCodUsu
                    registro.FecReg = Today
                    Insertar(registro)

                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR MARCACIÓN DE PERSONAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub


    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtColaborador.KeyPress _
                          , cmbEquipo.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbHorario.Focus()
            cmbHorario.SelectAll()
        End If
    End Sub

    Private Sub cmbHorario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbHorario.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtHoraMarcaIng.Focus()
            txtHoraMarcaIng.SelectAll()
        End If
    End Sub


    Private Sub txtHoraMarcaIng_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHoraMarcaIng.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        txtHoraMarcaIng.Text = Now().ToString("HH:mm:ss")
        lbltiempo.Text = Now().ToString("HH:mm:ss")
    End Sub
End Class