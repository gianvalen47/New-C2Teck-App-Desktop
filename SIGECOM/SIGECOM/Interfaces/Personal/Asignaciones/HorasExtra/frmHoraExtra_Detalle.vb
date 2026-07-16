Imports System.ServiceModel
Public Class frmHoraExtra_Detalle

    '============================Servicios===================================
    Private oHoraExtraService As New HoraExtraService.HoraExtraServiceClient
    Private oHoraExtraDetService As New HoraExtraDetService.HoraExtraDetServiceClient
    Private oPlanillaSueldosDetService As New PlanillaSueldosDetService.PlanillaSueldosDetServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: modificar    False: nuevo
    Public type_process As String            'update     insert      delete    
    Public IdExtraDet As Integer
    Public IdExtra As Integer
    Private dtTipoHrsExt As DataTable
    Public iPagado As Boolean                 'Campo pagado de la Hora Extra seleccionada


    Private Sub frmHoraExtra_Detalle_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmHoraExtra_Detalle_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            cmbTipoHoraExtra.TabStop = False
            txtCanHoras.Focus()
        Else                                      'Nuevo
            activar()
            cmbTipoHoraExtra.TabStop = True
            cmbTipoHoraExtra.Focus()
        End If
        EnableOptions()        
    End Sub

    Private Sub frmHoraExtra_Detalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oHoraExtraService.Close()
            oHoraExtraDetService.Close()
            oPlanillaSueldosDetService.Close()
        Catch ex As TimeoutException
            oHoraExtraService.Abort()
            oHoraExtraDetService.Abort()
            oPlanillaSueldosDetService.Abort()
        Catch ex As CommunicationException
            oHoraExtraService.Abort()
            oHoraExtraDetService.Abort()
            oPlanillaSueldosDetService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cmbTipoHoraExtra.Value) = "" Then
                MsgBox("Debe ingresar el Tipo de hora extra.", MsgBoxStyle.Information, "Información")
                cmbTipoHoraExtra.Focus()
                Return False
            ElseIf toDouble(txtCanHoras.Value) = 0 Then
                MsgBox("Debe Ingresar la Cantidad de Horas Extras.", MsgBoxStyle.Information, "Información")
                txtCanHoras.Focus()
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
        cmbTipoHoraExtra.ReadOnly = False
        cmbTipoHoraExtra.BackColor = System.Drawing.SystemColors.Window
        txtCanHoras.ReadOnly = False
        txtCanHoras.BackColor = System.Drawing.SystemColors.Window
        txtHorasCompensar.ReadOnly = False
        txtHorasCompensar.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        btnGuardar.Enabled = True
    End Sub

    Private Sub desactivar()
        If iPagado = True Then
            cmbTipoHoraExtra.ReadOnly = True
            cmbTipoHoraExtra.BackColor = System.Drawing.SystemColors.Control
            txtCanHoras.ReadOnly = True
            txtCanHoras.BackColor = System.Drawing.SystemColors.Control
            txtHorasCompensar.ReadOnly = True
            txtHorasCompensar.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control
            btnGuardar.Enabled = False
        Else
            cmbTipoHoraExtra.ReadOnly = True
            cmbTipoHoraExtra.BackColor = System.Drawing.SystemColors.Control
            txtCanHoras.ReadOnly = False
            txtCanHoras.BackColor = System.Drawing.SystemColors.Window
            txtHorasCompensar.ReadOnly = False
            txtHorasCompensar.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            btnGuardar.Enabled = True
        End If
    End Sub

    Private Sub Insertar(ByVal registro As HoraExtraDetService.HoraExtraDet)
        Try
            Dim estado_process As Integer
            estado_process = oHoraExtraDetService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdExtraDet = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As HoraExtraDetService.HoraExtraDet)
        Try
            Dim estado_process As Boolean
            estado_process = oHoraExtraDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As HoraExtraDetService.HoraExtraDet
            registro = oHoraExtraDetService.Obtener(IdExtraDet)

            IdExtraDet = registro.IdExtraDet
            IdExtra = registro.HoraExtra.IdExtra
            cmbTipoHoraExtra.Value = registro.TipoHoraExtra.IdHoraExtra
            txtCanHoras.Value = registro.CanHoras
            txtHorasCompensar.Value = registro.HorasCompensar
            txtObservacion.Text = registro.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            ''======================================= TIPOS DE HORA EXTRA ===========================================
            dtTipoHrsExt = oPlanillaSueldosDetService.MostrarTipoHoraExtra(Session.sCodEmp).Tables(0)
            cmbTipoHoraExtra.DataSource = dtTipoHrsExt
            cmbTipoHoraExtra.DropDownList.DataMember = dtTipoHrsExt.Columns("DesHoraExtra").ToString
            cmbTipoHoraExtra.DropDownList.DisplayMember = dtTipoHrsExt.Columns("DesHoraExtra").ToString
            cmbTipoHoraExtra.DropDownList.ValueMember = dtTipoHrsExt.Columns("IdHoraExtra").ToString
            cmbTipoHoraExtra.DropDownList.Columns(0).DataMember = dtTipoHrsExt.Columns("IdHoraExtra").ToString
            cmbTipoHoraExtra.DropDownList.Columns(1).DataMember = dtTipoHrsExt.Columns("DesHoraExtra").ToString
            cmbTipoHoraExtra.SelectedIndex = 0
            dtTipoHrsExt = Nothing

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
            Dim registro As New HoraExtraDetService.HoraExtraDet
            Dim HoraExtra As New HoraExtraDetService.HoraExtra
            Dim TipoHoraExtra As New HoraExtraDetService.TipoHoraExtra

            registro.IdExtraDet = IdExtraDet
            HoraExtra.IdExtra = IdExtra
            registro.HoraExtra = HoraExtra
            TipoHoraExtra.IdHoraExtra = cmbTipoHoraExtra.Value
            registro.TipoHoraExtra = TipoHoraExtra
            registro.CanHoras = txtCanHoras.Value
            registro.HorasCompensar = txtHorasCompensar.Value
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
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            cmbTipoHoraExtra.KeyPress _
                           , txtCanHoras.KeyPress _
                           , txtHorasCompensar.KeyPress
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