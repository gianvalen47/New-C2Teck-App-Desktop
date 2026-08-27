Imports System.ServiceModel
Public Class frmEquipoMarcacion

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
        txtIdEquipo.ReadOnly = True
        txtIdEquipo.BackColor = System.Drawing.SystemColors.Control
        txtDesEquipo.ReadOnly = False
        txtDesEquipo.BackColor = System.Drawing.SystemColors.Window
        txtDireccionIp.ReadOnly = False
        txtDireccionIp.BackColor = System.Drawing.SystemColors.Window
        txtPuerto.ReadOnly = False
        txtPuerto.BackColor = System.Drawing.SystemColors.Window
        cmbHorario.ReadOnly = False
        cmbHorario.BackColor = System.Drawing.SystemColors.Window
        txtMarca.ReadOnly = False
        txtMarca.BackColor = System.Drawing.SystemColors.Window
        txtModelo.ReadOnly = False
        txtModelo.BackColor = System.Drawing.SystemColors.Window
        cbActivo.Enabled = True        
        btnGuardar.Enabled = True
    End Sub

    Private Sub desactivar()
        txtIdEquipo.ReadOnly = True
        txtIdEquipo.BackColor = System.Drawing.SystemColors.Control
        txtDesEquipo.ReadOnly = False
        txtDesEquipo.BackColor = System.Drawing.SystemColors.Window
        txtDireccionIp.ReadOnly = False
        txtDireccionIp.BackColor = System.Drawing.SystemColors.Window
        txtPuerto.ReadOnly = False
        txtPuerto.BackColor = System.Drawing.SystemColors.Window
        cmbHorario.ReadOnly = False
        cmbHorario.BackColor = System.Drawing.SystemColors.Window
        txtMarca.ReadOnly = False
        txtMarca.BackColor = System.Drawing.SystemColors.Window
        txtModelo.ReadOnly = False
        txtModelo.BackColor = System.Drawing.SystemColors.Window
        cbActivo.Enabled = True
        btnGuardar.Enabled = True
    End Sub

    Private Sub Insertar(ByVal registro As TablasPersonalService.EquipoMarcacion)
        Try
            Dim estado_process As String
            estado_process = oTablasPersonalService.InsertarEquipoMarcacion(registro)
            type_process = "insert"
            If estado_process = True Then
                IdEquipo = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EQUIPO DE MARCACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As TablasPersonalService.EquipoMarcacion)
        Try
            Dim estado_process As Boolean
            estado_process = oTablasPersonalService.ActualizarEquipoMarcacion(registro)
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
            Dim registro As TablasPersonalService.EquipoMarcacion
            registro = oTablasPersonalService.ObtenerEquipoMarcacion(IdEquipo)

            IdEquipo = registro.IdEquipo
            txtIdEquipo.Text = registro.IdEquipo
            txtDesEquipo.Text = registro.DesEquipo
            txtDireccionIp.Text = registro.DirIp
            txtPuerto.Text = registro.Puerto
            cmbHorario.Value = registro.Horario.CodHor
            cbActivo.Checked = registro.Activo
            txtModelo.Text = registro.Modelo
            txtMarca.Text = registro.Marca

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
                Dim registro As New TablasPersonalService.EquipoMarcacion
                Dim Horario As New TablasPersonalService.Horario
                Dim empresa As New TablasPersonalService.Empresa

                empresa.CodEmp = Session.sCodEmp
                registro.IdEquipo = IdEquipo
                registro.Empresa = empresa
                registro.DesEquipo = txtDesEquipo.Text
                registro.DirIp = txtDireccionIp.Text
                registro.Puerto = txtPuerto.Text
                Horario.CodHor = cmbHorario.Value
                registro.Horario = Horario
                registro.Activo = cbActivo.Checked
                registro.Marca = txtMarca.Text
                registro.Modelo = txtModelo.Text

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
End Class