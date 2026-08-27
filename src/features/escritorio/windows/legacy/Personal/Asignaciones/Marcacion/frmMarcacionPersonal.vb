Imports System.ServiceModel
Public Class frmMarcacionPersonal

    '=========================== Servicios ====================================================
    Private oMarcacionService As New MarcacionService.MarcacionServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oHorarioService As New HorarioService.HorarioServiceClient
    Private Persona As New PersonaService.Persona

    '======================Declaración de Variables==============================================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public IdMarca As Integer
    Public IdPersona As Integer = 0
    Public ApeNom As String
    Private dtEquipo As DataTable
    Private dtHorarios As New DataTable
    Public iPagago As Boolean            'Campo pagado de la Marcación seleccionada
    Public iFecha As Date                    'Fecha Ingresada en Nuevo

    Public iIdPersona As Integer = 0           'IdPersona de colaborador seleccionado en la ventana anterior

    Private Sub frmMarcacionPersonal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            desactivar()
            ObtenerRegistro()
            Me.Text = "Marcación de: " + Chr(34) + ApeNom + Chr(34)
            txtColaborador.TabStop = False
            cmbEquipo.Focus()
        Else                                      'Nuevo
            Me.Text = "Registrar nueva Marcación"
            activar()
            If iIdPersona <> 0 Then
                ObtenerPersona()
                txtColaborador.TabStop = True
                txtColaborador.Focus()
            Else
                btnBuscarColaborador.TabStop = True
                btnBuscarColaborador.Select()
                btnBuscarColaborador.Focus()
            End If
            'cmbEquipo.Value = 4
            'Comentado ---
            'txtColaborador.TabStop = True
            'txtColaborador.Focus()
            'comentado ---
            'txtFecha.Value = iFecha
        End If
        EnableOptions()
    End Sub

    Private Sub ObtenerPersona()
        Persona = oPersonaService.Obtener(iIdPersona)
        IdPersona = iIdPersona
        txtColaborador.Text = Persona.ApeNom
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
        Catch ex As TimeoutException
            oMarcacionService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oMarcacionService.Abort()
            oPersonaService.Abort()
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
            cmbEquipo.SelectedIndex = 0
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

    Private Sub EnableOptions()

    End Sub

    Private Sub activar()
        txtColaborador.ReadOnly = True
        txtColaborador.BackColor = System.Drawing.SystemColors.Control
        btnBuscarColaborador.Enabled = True
        cmbEquipo.ReadOnly = False
        cmbEquipo.BackColor = System.Drawing.SystemColors.Window
        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        txtHoraMarcaIng.ReadOnly = False
        txtHoraMarcaIng.BackColor = System.Drawing.SystemColors.Window
        txtHoraMarcaIng.Text = Now().ToString("HH:mm:ss")
        txtHoraMarcaSal.ReadOnly = False
        txtHoraMarcaSal.BackColor = System.Drawing.SystemColors.Window
        txtHoraMarcaSal.Text = Now().ToString("HH:mm:ss")
        txtHoraRealIng.ReadOnly = True
        txtHoraRealIng.BackColor = System.Drawing.SystemColors.Control
        txtHoraRealSal.ReadOnly = True
        txtHoraRealSal.BackColor = System.Drawing.SystemColors.Control
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
            cmbEquipo.ReadOnly = True
            cmbEquipo.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            txtHoraMarcaIng.ReadOnly = True
            txtHoraMarcaIng.BackColor = System.Drawing.SystemColors.Control
            txtHoraMarcaSal.ReadOnly = True
            txtHoraMarcaSal.BackColor = System.Drawing.SystemColors.Control
            txtHoraRealIng.ReadOnly = True
            txtHoraRealIng.BackColor = System.Drawing.SystemColors.Control
            txtHoraRealSal.ReadOnly = True
            txtHoraRealSal.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control
            cbPagado.Visible = True
            btnGuardar.Enabled = False
            txtColaborador.Focus()
        Else
            txtColaborador.ReadOnly = True
            txtColaborador.BackColor = System.Drawing.SystemColors.Control
            btnBuscarColaborador.Enabled = False
            cmbEquipo.ReadOnly = False
            cmbEquipo.BackColor = System.Drawing.SystemColors.Window
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            txtHoraMarcaIng.ReadOnly = True
            txtHoraMarcaIng.BackColor = System.Drawing.SystemColors.Control
            txtHoraMarcaSal.ReadOnly = True
            txtHoraMarcaSal.BackColor = System.Drawing.SystemColors.Control
            txtHoraRealIng.ReadOnly = False
            txtHoraRealIng.BackColor = System.Drawing.SystemColors.Window
            txtHoraRealSal.ReadOnly = False
            txtHoraRealSal.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            cbPagado.Visible = True
            btnGuardar.Enabled = True
            cmbEquipo.Focus()
        End If
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
            ElseIf Not (txtHoraRealIng.MaskFull) Then
                MsgBox("Debe ingresar la fecha real de ingreso.")
                txtHoraRealIng.Focus()
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub ObtenerRegistro()
        Try
            Dim registro As MarcacionService.Marcacion
            registro = oMarcacionService.Obtener(IdMarca)

            IdMarca = registro.IdMarca
            IdPersona = registro.Persona.IdPer
            txtColaborador.Text = registro.Persona.ApeNom
            cmbEquipo.Value = registro.EquipoMarcacion.IdEquipo
            cmbHorario.Value = registro.Horario.CodHor
            txtFecha.Value = registro.Fecha
            txtHoraMarcaIng.Text = registro.HoraMarcaIng.ToLongTimeString
            txtHoraMarcaSal.Text = registro.HoraMarcaSal.ToLongTimeString
            txtHoraRealIng.Text = registro.HoraRealIng.ToLongTimeString
            txtHoraRealSal.Text = registro.HoraRealSal.ToLongTimeString
            txtObservacion.Text = registro.Observacion
            cbPagado.Checked = registro.Pagado

            Me.Text = "Marcación de: " + registro.Persona.ApeNom
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As MarcacionService.Marcacion)
        Try
            Dim estado_process As Integer
            estado_process = oMarcacionService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdMarca = estado_process
                iFecha = txtFecha.Value
                MsgBox("Se insertó la Marcación Correctamente.")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR MARCACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As MarcacionService.Marcacion)
        Try
            Dim estado_process As Boolean
            estado_process = oMarcacionService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR MARCACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oMarcacionService.Borrar(IdMarca, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR MARCACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarColaborador_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarColaborador.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersona = frm.codigo
                    txtColaborador.Text = frm.descripcion
                    cmbEquipo.Focus()
                Else
                    IdPersona = 0
                    txtColaborador.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
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
                    registro.IdMarca = IdMarca
                    Colaborador.IdPer = IdPersona
                    registro.Persona = Colaborador
                    Equipo.IdEquipo = cmbEquipo.Value
                    registro.EquipoMarcacion = Equipo
                    registro.Fecha = txtFecha.Value
                    registro.HoraMarcaIng = txtHoraMarcaIng.Text
                    registro.HoraMarcaSal = txtHoraMarcaSal.Text
                    registro.HoraRealIng = txtHoraRealIng.Text
                    registro.HoraRealSal = txtHoraRealSal.Text
                    registro.Observacion = IIf(txtObservacion.Text = "", Nothing, txtObservacion.Text)
                    Horario.CodHor = toBlank(cmbHorario.Value)
                    registro.Horario = Horario
                    registro.Horario.Empresa = empresa
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
            MsgBox("ERROR AL GUARDAR MARCACIÓN DE PERSONAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
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
                          , cmbEquipo.KeyPress _
                          , txtHoraRealSal.KeyPress
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
            txtHoraMarcaSal.Focus()
            txtHoraMarcaSal.SelectAll()
        End If
    End Sub

    Private Sub txtHoraMarcaSal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHoraMarcaSal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtHoraRealIng.Focus()
            txtHoraRealIng.SelectAll()
        End If
    End Sub

    Private Sub txtHoraRealIng_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHoraRealIng.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtHoraRealSal.Focus()
            txtHoraRealSal.SelectAll()
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub

    Private Sub txtHoraMarcaIng_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHoraMarcaIng.TextChanged
        txtHoraRealIng.Text = txtHoraMarcaIng.Text
    End Sub

    Private Sub txtHoraMarcaSal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHoraMarcaSal.TextChanged
        txtHoraRealSal.Text = txtHoraMarcaSal.Text
    End Sub
End Class