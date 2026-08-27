Imports System.ServiceModel
Public Class frmHoraMotor_Mant

    '============================Servicios===================================
    Private oHorasMotorService As New HorasMotorService.HorasMotorServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: modificar    False: nuevo
    Public type_process As String            'update     insert      delete    
    Public CodMantenimiento As String
    Public CodMer As String
    Public IdPlan As Integer
    Public Fecha As Date
    Private dtTipoMantenimiento As DataTable

    Private Sub frmHoraMotor_Mant_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmHoraMotor_Mant_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            txtHrsTotales.Focus()
        Else                                      'Nuevo
            activar()
            txtFecha.Value = Today
            cmbTipoMantenimiento.Focus()
        End If
        EnableOptions()
    End Sub

    Private Sub frmHoraMotor_Mant_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oHorasMotorService.Close()
        Catch ex As TimeoutException
            oHorasMotorService.Abort()
        Catch ex As CommunicationException
           oHorasMotorService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cmbTipoMantenimiento.Value) = "" Then
                MsgBox("Debe ingresar el Tipo de Mantenimiento.", MsgBoxStyle.Information, "Información")
                cmbTipoMantenimiento.Focus()
                Return False
            ElseIf state_button = False And oHorasMotorService.BuscarMantenimiento(CodMer, toBlank(cmbTipoMantenimiento.Value), txtFecha.Value) Then
                MsgBox("El Tipo de Mantenimiento seleccionado ya fue ingresado en esta fecha.", MsgBoxStyle.Information, "Información")
                cmbTipoMantenimiento.Focus()
                Return False
            ElseIf toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha Fín de Garantía.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf toDouble(txtHrsTotales.Value) = 0 Then
                MsgBox("Debe Ingresar el Total de Horas.", MsgBoxStyle.Information, "Información")
                txtHrsTotales.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub EnableOptions()
        'If iPagado = False Then
        '    btnGuardar.Enabled = True
        'Else
        '    btnGuardar.Enabled = False
        '    desactivar()
        'End If
    End Sub

    Private Sub activar()
        cmbTipoMantenimiento.ReadOnly = False
        cmbTipoMantenimiento.BackColor = System.Drawing.SystemColors.Window
        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        cbReparacion.Enabled = False
        txtHrsTotales.ReadOnly = False
        txtHrsTotales.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        txtNumero.Enabled = False
        txtNumero.BackColor = System.Drawing.SystemColors.Window
        btnGuardar.Enabled = True
    End Sub

    Private Sub desactivar()
        cmbTipoMantenimiento.ReadOnly = True
        cmbTipoMantenimiento.BackColor = System.Drawing.SystemColors.Control
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        cbReparacion.Enabled = False
        txtHrsTotales.ReadOnly = False
        txtHrsTotales.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        txtNumero.ReadOnly = False
        txtNumero.BackColor = System.Drawing.SystemColors.Window

        btnGuardar.Enabled = True
    End Sub

    Private Sub Insertar(ByVal registro As HorasMotorService.MantenimientosMotor)
        Try
            Dim estado_process As Boolean
            estado_process = oHorasMotorService.InsertarMantenimiento(registro)
            type_process = "insert"
            If estado_process = True Then
                CodMantenimiento = toBlank(cmbTipoMantenimiento.Value)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As HorasMotorService.MantenimientosMotor)
        Try
            Dim estado_process As Boolean
            estado_process = oHorasMotorService.ActualizarMantenimiento(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As HorasMotorService.MantenimientosMotor
            registro = oHorasMotorService.ObtenerMantenimiento(CodMer, CodMantenimiento, Fecha)

            CodMantenimiento = registro.TipoMantenimiento.CodMantenimiento
            CodMer = registro.HorasMotor.Motor.NumSerie
            cmbTipoMantenimiento.Value = registro.TipoMantenimiento.CodMantenimiento
            txtFecha.Value = registro.Fecha
            cbReparacion.Checked = registro.Reparacion
            txtHrsTotales.Value = registro.TotalHoras
            txtObservacion.Text = registro.Observacion
            txtNumero.Text = registro.NumReparacion
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            ''======================================= TIPOS MANTENIMIENTO===========================================
            dtTipoMantenimiento = oHorasMotorService.MostrarPlanMantenimiento(toNumber(IdPlan)).Tables(0)
            'dtTipoMantenimiento.Rows.InsertAt(getRowNinguno(dtTipoMantenimiento), 0)
            cmbTipoMantenimiento.DataSource = dtTipoMantenimiento
            cmbTipoMantenimiento.DropDownList.DataMember = dtTipoMantenimiento.Columns("DesMantenimiento").ToString
            cmbTipoMantenimiento.DropDownList.DisplayMember = dtTipoMantenimiento.Columns("DesMantenimiento").ToString
            cmbTipoMantenimiento.DropDownList.ValueMember = dtTipoMantenimiento.Columns("CodMantenimiento").ToString
            cmbTipoMantenimiento.DropDownList.Columns(0).DataMember = dtTipoMantenimiento.Columns("CodMantenimiento").ToString
            cmbTipoMantenimiento.DropDownList.Columns(1).DataMember = dtTipoMantenimiento.Columns("DesMantenimiento").ToString
            cmbTipoMantenimiento.SelectedIndex = 0
            dtTipoMantenimiento = Nothing

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
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
            Dim registro As New HorasMotorService.MantenimientosMotor
            Dim Motor As New HorasMotorService.Motor
            Dim HorasMotor As New HorasMotorService.HorasMotor
            Dim TipoMantenimiento As New HorasMotorService.TipoMantenimiento

            Motor.NumSerie = CodMer
            HorasMotor.Motor = Motor
            registro.HorasMotor = HorasMotor

            TipoMantenimiento.CodMantenimiento = cmbTipoMantenimiento.Value
            registro.TipoMantenimiento = TipoMantenimiento

            registro.Fecha = txtFecha.Value
            registro.Reparacion = cbReparacion.Checked
            registro.TotalHoras = txtHrsTotales.Value
            registro.Observacion = IIf(txtObservacion.Text = "", Nothing, txtObservacion.Text)
            registro.NumReparacion = txtNumero.Text
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
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            cmbTipoMantenimiento.KeyPress _
                           , txtFecha.KeyPress _
                           , txtHrsTotales.KeyPress _
                           , cbReparacion.KeyPress
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

    Private Sub cmbTipoMantenimiento_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoMantenimiento.ValueChanged
        cbReparacion.Checked = oHorasMotorService.BuscarTipoReparacion(IdPlan, cmbTipoMantenimiento.Value)
    End Sub
End Class