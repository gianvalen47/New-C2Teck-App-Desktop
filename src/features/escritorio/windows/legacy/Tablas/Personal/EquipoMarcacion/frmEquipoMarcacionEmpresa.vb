Imports System.ServiceModel
Public Class frmEquipoMarcacionEmpresa

    '=========================== Servicios ====================================
    Private oTablasPersonalService As New TablasPersonalService.TablasPersonalServiceClient
    Private oHorarioService As New HorarioService.HorarioServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean           'True: Modificar    False: nuevo
    Public type_process As String             'update     insert      delete
    Public IdEquipo As Integer                  'Código de Cargo seleccionado
    Private dtHorarios As New DataTable

    Private Sub frmEquipoMarcacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmEquipoMarcacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()            
            txtDesEquipo.Focus()
        Else                                      'Nuevo            
            activar()
            cbActivo.Checked = True
            txtDesEquipo.Focus()
        End If
        EnableOptions()
    End Sub

    Private Sub frmEquipoMarcacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oTablasPersonalService.Close()
            oHorarioService.Close()
        Catch ex As TimeoutException
            oTablasPersonalService.Abort()
            oHorarioService.Abort()
        Catch ex As CommunicationException
            oTablasPersonalService.Abort()
            oHorarioService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtDesEquipo.Text) = "" Then
                MsgBox("Debe ingresar la descripción del Equipo", MsgBoxStyle.Information, "Información")
                txtDesEquipo.Focus()
                Return False
            ElseIf toBlank(txtDireccionIp.Text) = "" Then
                MsgBox("Debe ingresar la dirección Ip", MsgBoxStyle.Information, "Información")
                txtDireccionIp.Focus()
                Return False
            ElseIf toBlank(txtPuerto.Text) = "" Then
                MsgBox("Debe ingresar el Puerto", MsgBoxStyle.Information, "Información")
                txtPuerto.Focus()
                Return False
            ElseIf toBlank(cmbHorario.Value) = "" Then
                MsgBox("Debe ingresar el Horario", MsgBoxStyle.Information, "Información")
                cmbHorario.Focus()
                Return False

            ElseIf toBlank(txtIdEquipo.Text) = "" Then
                MsgBox("Debe ingresar el Equipo", MsgBoxStyle.Information, "Información")
                cmbHorario.Focus()
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
        'txtIdEquipo.ReadOnly = True
        'txtIdEquipo.BackColor = System.Drawing.SystemColors.Control
        'txtDesEquipo.ReadOnly = False
        'txtDesEquipo.BackColor = System.Drawing.SystemColors.Window
        'txtDireccionIp.ReadOnly = False
        'txtDireccionIp.BackColor = System.Drawing.SystemColors.Window
        'txtPuerto.ReadOnly = False
        'txtPuerto.BackColor = System.Drawing.SystemColors.Window
        cmbHorario.ReadOnly = False
        cmbHorario.BackColor = System.Drawing.SystemColors.Window
        'txtMarca.ReadOnly = False
        'txtMarca.BackColor = System.Drawing.SystemColors.Window
        'txtModelo.ReadOnly = False
        'txtModelo.BackColor = System.Drawing.SystemColors.Window
        'cbActivo.Enabled = True     
        btnBuscarLector.Enabled = True
        btnGuardar.Enabled = True
    End Sub

    Private Sub desactivar()
        'txtIdEquipo.ReadOnly = True
        'txtIdEquipo.BackColor = System.Drawing.SystemColors.Control
        'txtDesEquipo.ReadOnly = False
        'txtDesEquipo.BackColor = System.Drawing.SystemColors.Window
        'txtDireccionIp.ReadOnly = False
        'txtDireccionIp.BackColor = System.Drawing.SystemColors.Window
        'txtPuerto.ReadOnly = False
        'txtPuerto.BackColor = System.Drawing.SystemColors.Window
        cmbHorario.ReadOnly = False
        cmbHorario.BackColor = System.Drawing.SystemColors.Window
        'txtMarca.ReadOnly = False
        'txtMarca.BackColor = System.Drawing.SystemColors.Window
        'txtModelo.ReadOnly = False
        'txtModelo.BackColor = System.Drawing.SystemColors.Window
        'cbActivo.Enabled = True
        btnBuscarLector.Enabled = False
        btnGuardar.Enabled = True
    End Sub

    Private Sub Insertar(ByVal registro As TablasPersonalService.EquipoMarcacionEmpresa)
        Try
            Dim estado_process As Boolean
            estado_process = oTablasPersonalService.InsertarLectorEmpresa(registro)
            type_process = "insert"
            If estado_process = True Then
                'IdEquipo = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EQUIPO DE MARCACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As TablasPersonalService.EquipoMarcacionEmpresa)
        Try
            Dim estado_process As Boolean
            estado_process = oTablasPersonalService.ActualizarLectorEmpresa(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR EQUIPO DE MARCACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As TablasPersonalService.EquipoMarcacionEmpresa
            registro = oTablasPersonalService.ObtenerLectorEmpresa(IdEquipo, Session.sCodEmp)

            IdEquipo = registro.EquipoMarcacion.IdEquipo
            txtIdEquipo.Text = registro.EquipoMarcacion.IdEquipo
            txtDesEquipo.Text = registro.EquipoMarcacion.DesEquipo
            txtDireccionIp.Text = registro.EquipoMarcacion.DirIp
            txtPuerto.Text = registro.EquipoMarcacion.Puerto
            cmbHorario.Value = registro.Horario.CodHor
            cbActivo.Checked = registro.EquipoMarcacion.Activo
            txtModelo.Text = registro.EquipoMarcacion.Modelo
            txtMarca.Text = registro.EquipoMarcacion.Marca

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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
                Dim registro As New TablasPersonalService.EquipoMarcacionEmpresa
                Dim Horario As New TablasPersonalService.Horario
                Dim empresa As New TablasPersonalService.Empresa
                Dim equipo As New TablasPersonalService.EquipoMarcacion

                empresa.CodEmp = Session.sCodEmp
                equipo.IdEquipo = IdEquipo
                registro.EquipoMarcacion = equipo
                registro.Empresa = empresa
                Horario.CodHor = cmbHorario.Value
                registro.Horario = Horario
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
            MsgBox("ERROR AL GUARDAR EQUIPO MARCACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtIdEquipo.KeyPress _
                           , cmbHorario.KeyPress _
                           , txtDesEquipo.KeyPress _
                           , txtDireccionIp.KeyPress _
                           , txtPuerto.KeyPress _
                           , cbActivo.KeyPress _
                           , txtModelo.KeyPress _
                           , txtMarca.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnBuscarGrupo_Click(sender As Object, e As EventArgs) Handles btnBuscarLector.Click
        Dim frm As New frmBuscarLectoresAsistencia
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            IdEquipo = frm.codigo
            txtIdEquipo.Text = frm.codigo
            txtDesEquipo.Text = frm.descripcion

            txtDireccionIp.Text = frm.dirip
            txtPuerto.Text = frm.puerto
            txtMarca.Text = frm.marca
            txtModelo.Text = frm.modelo
            cbActivo.Checked = frm.activo


        End If
        cmbHorario.Focus()
    End Sub
End Class