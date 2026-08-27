Imports System.ServiceModel
Public Class frmTipoHoraExtra

    '=========================== Servicios ====================================
    Private oTablasPersonalService As New TablasPersonalService.TablasPersonalServiceClient
    Private oPlanillaSueldosDetService As New PlanillaSueldosDetService.PlanillaSueldosDetServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean           'True: Modificar    False: nuevo
    Public type_process As String             'update     insert      delete
    Public IdHoraExtra As Integer                  'Código de Cargo seleccionado
    Private dtRubroIng As New DataTable

    Private Sub frmTipoHoraExtra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmTipoHoraExtra_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            txtDesHoraExtra.Focus()
        Else                                      'Nuevo            
            activar()
            cbActivo.Checked = True
            txtDesHoraExtra.Focus()
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
            oPlanillaSueldosDetService.Close()
        Catch ex As TimeoutException
            oTablasPersonalService.Abort()
            oPlanillaSueldosDetService.Abort()
        Catch ex As CommunicationException
            oTablasPersonalService.Abort()
            oPlanillaSueldosDetService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtDesHoraExtra.Text) = "" Then
                MsgBox("Debe ingresar la descripción del Tipo de Hora Extra", MsgBoxStyle.Information, "Información")
                txtDesHoraExtra.Focus()
                Return False
            ElseIf toDouble(txtPorcentaje.Text) = 0 Then
                MsgBox("El porcentaje debe ser mayor a 0", MsgBoxStyle.Information, "Información")
                txtPorcentaje.Focus()
                Return False
            ElseIf toBlank(cmbIngreso.Value) = "" Then
                MsgBox("Debe ingresar el Rubro de Ingreso", MsgBoxStyle.Information, "Información")
                cmbIngreso.Focus()
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
        txtIdHoraExtra.ReadOnly = True
        txtIdHoraExtra.BackColor = System.Drawing.SystemColors.Control
        txtDesHoraExtra.ReadOnly = False
        txtDesHoraExtra.BackColor = System.Drawing.SystemColors.Window
        txtAbreviatura.ReadOnly = False
        txtAbreviatura.BackColor = System.Drawing.SystemColors.Window
        txtPorcentaje.ReadOnly = False
        txtPorcentaje.BackColor = System.Drawing.SystemColors.Window
        cmbIngreso.ReadOnly = False
        txtPorcentaje.BackColor = System.Drawing.SystemColors.Window
        cbActivo.Enabled = True
        btnGuardar.Enabled = True
    End Sub

    Private Sub desactivar()
        txtIdHoraExtra.ReadOnly = True
        txtIdHoraExtra.BackColor = System.Drawing.SystemColors.Control
        txtDesHoraExtra.ReadOnly = False
        txtDesHoraExtra.BackColor = System.Drawing.SystemColors.Window
        txtAbreviatura.ReadOnly = False
        txtAbreviatura.BackColor = System.Drawing.SystemColors.Window
        txtPorcentaje.ReadOnly = False
        txtPorcentaje.BackColor = System.Drawing.SystemColors.Window
        cmbIngreso.ReadOnly = False
        cmbIngreso.BackColor = System.Drawing.SystemColors.Window
        cbActivo.Enabled = True
        btnGuardar.Enabled = True
    End Sub

    Private Sub Insertar(ByVal registro As TablasPersonalService.TipoHoraExtra)
        Try
            Dim estado_process As String
            estado_process = oTablasPersonalService.InsertarTipoHoraExtra(registro)
            type_process = "insert"
            If estado_process = True Then
                IdHoraExtra = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR TIPO DE HORA EXTRA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As TablasPersonalService.TipoHoraExtra)
        Try
            Dim estado_process As Boolean
            estado_process = oTablasPersonalService.ActualizarTipoHoraExtra(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR TIPO HORA EXTRA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As TablasPersonalService.TipoHoraExtra
            registro = oTablasPersonalService.ObtenerTipoHoraExtra(IdHoraExtra)

            IdHoraExtra = registro.IdHoraExtra
            txtIdHoraExtra.Text = registro.IdHoraExtra
            txtDesHoraExtra.Text = registro.DesHoraExtra
            txtAbreviatura.Text = registro.Abreviatura
            txtPorcentaje.Value = registro.Porcentaje
            cmbIngreso.Value = registro.RubroIngresoPlanilla.IdRubroIng
            cbActivo.Checked = registro.Activo

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            ''========================================== INGRESO ===============================================
            dtRubroIng = oPlanillaSueldosDetService.MostrarRubroIngreso(Session.sCodEmp).Tables(0)
            cmbIngreso.DataSource = dtRubroIng
            cmbIngreso.DropDownList.DataMember = dtRubroIng.Columns("DesIngreso").ToString
            cmbIngreso.DropDownList.DisplayMember = dtRubroIng.Columns("DesIngreso").ToString
            cmbIngreso.DropDownList.ValueMember = dtRubroIng.Columns("IdRubroIng").ToString
            cmbIngreso.DropDownList.Columns(0).DataMember = dtRubroIng.Columns("IdRubroIng").ToString
            cmbIngreso.DropDownList.Columns(1).DataMember = dtRubroIng.Columns("DesIngreso").ToString
            cmbIngreso.SelectedIndex = 0
            dtRubroIng = Nothing

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
                Dim registro As New TablasPersonalService.TipoHoraExtra
                Dim RubroIngresoPlanilla As New TablasPersonalService.RubroIngresoPlanilla

                registro.IdHoraExtra = IdHoraExtra
                registro.DesHoraExtra = txtDesHoraExtra.Text
                registro.Abreviatura = txtAbreviatura.Text
                registro.Porcentaje = txtPorcentaje.Text
                RubroIngresoPlanilla.IdRubroIng = cmbIngreso.Value
                registro.RubroIngresoPlanilla = RubroIngresoPlanilla
                registro.Activo = cbActivo.Checked

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR TIPO HORA EXTRA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtIdHoraExtra.KeyPress _
                           , txtDesHoraExtra.KeyPress _
                           , txtAbreviatura.KeyPress _
                           , txtPorcentaje.KeyPress _
                           , cmbIngreso.KeyPress _
                           , cbActivo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class