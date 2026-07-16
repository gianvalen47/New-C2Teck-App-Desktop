Imports System.ServiceModel
Public Class frmContAfp_Det

    '===========================Servicios====================================================
    Private oMaestroService As New MaestroService.MaestroClient
    Private oContratoPersonaService As New ContratoPersonaService.ContratoPersonaServiceClient
    Private oAfpService As New AfpService.AfpServiceClient

    '======================Declaración de Variables==============================================
    Public IdAfp As Integer
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public IdPersona As Integer
    Private dtAFPs As DataTable
    Private dtModalidad As DataTable
    Public NumCuenta As String

    Private Sub frmContAfpDetalle_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oContratoPersonaService.Close()
            oMaestroService.Close()
            oAfpService.Close()
        Catch ex As TimeoutException
            oContratoPersonaService.Abort()
            oMaestroService.Abort()
            oAfpService.Abort()
        Catch ex As CommunicationException
            oContratoPersonaService.Abort()
            oMaestroService.Abort()
            oAfpService.Abort()
        End Try
    End Sub

    Private Sub frmContAfpDetalle_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            desactivar()
            ObtenerRegistro()
            cmbAFP.TabStop = False
            txtFecha.Focus()
        Else                                      'Nuevo          
            activar()
            txtFecha.Value = Today
            txtNumCuenta.Text = NumCuenta
            cmbAFP.TabStop = True
            cmbAFP.Focus()
        End If
        EnableOptions()
    End Sub

    Private Sub frmContAfpDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub llenarCombos()
        Try

            '========================================== AFPS ===============================================
            dtAFPs = oContratoPersonaService.MostrarAfp().Tables(0)
            cmbAFP.DataSource = dtAFPs
            cmbAFP.DropDownList.DataMember = dtAFPs.Columns("DesAfp").ToString
            cmbAFP.DropDownList.DisplayMember = dtAFPs.Columns("DesAfp").ToString
            cmbAFP.DropDownList.ValueMember = dtAFPs.Columns("IdAfp").ToString
            cmbAFP.DropDownList.Columns(0).DataMember = dtAFPs.Columns("IdAfp").ToString
            cmbAFP.DropDownList.Columns(1).DataMember = dtAFPs.Columns("DesAfp").ToString
            cmbAFP.SelectedIndex = 0
            dtAFPs = Nothing

            '======================================== MODALIDAD ============================================
            dtModalidad = oAfpService.MostrarModalidad().Tables(0)
            cmbModalidad.DataSource = dtModalidad
            cmbModalidad.DropDownList.DataMember = dtModalidad.Columns("AbrModalidad").ToString
            cmbModalidad.DropDownList.DisplayMember = dtModalidad.Columns("AbrModalidad").ToString
            cmbModalidad.DropDownList.ValueMember = dtModalidad.Columns("IdModalidad").ToString
            cmbModalidad.DropDownList.Columns(0).DataMember = dtModalidad.Columns("IdModalidad").ToString
            cmbModalidad.DropDownList.Columns(1).DataMember = dtModalidad.Columns("AbrModalidad").ToString
            cmbModalidad.SelectedIndex = 0
            dtModalidad = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOptions()
        'If estado = 1 Or estado = 2 Or estado = 3 Then
        '    btnGuardar.Enabled = True
        'Else
        '    btnGuardar.Enabled = False
        '    desactivar()
        'End If
    End Sub

    Private Sub activar()
        cmbAFP.ReadOnly = False
        cmbAFP.BackColor = System.Drawing.SystemColors.Window
        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        cmbModalidad.ReadOnly = False
        cmbModalidad.BackColor = System.Drawing.SystemColors.Window
        txtNumCuenta.ReadOnly = False
        txtNumCuenta.BackColor = System.Drawing.SystemColors.Window
        cmbAFP.Focus()
        btnGuardar.Enabled = True
    End Sub

    Private Sub desactivar()
        'If estado = 1 Then
        'activar()
        'Else
        cmbAFP.ReadOnly = True
        cmbAFP.BackColor = System.Drawing.SystemColors.Control
        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        cmbModalidad.ReadOnly = False
        cmbModalidad.BackColor = System.Drawing.SystemColors.Window
        txtNumCuenta.ReadOnly = False
        txtNumCuenta.BackColor = System.Drawing.SystemColors.Window
        txtFecha.Focus()
        btnGuardar.Enabled = True
        'End If
    End Sub

    Private Sub Insertar(ByVal registro As ContratoPersonaService.AfpPersona)
        Try
            Dim estado_process As Boolean
            estado_process = oContratoPersonaService.InsertarAfpPersona(registro)
            type_process = "insert"
            If estado_process Then
                IdAfp = cmbAFP.Value
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR AFP : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ContratoPersonaService.AfpPersona)
        Try
            Dim estado_process As Boolean
            estado_process = oContratoPersonaService.ActualizarAfpPersona(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR AFP : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ContratoPersonaService.AfpPersona
            registro = oContratoPersonaService.ObtenerAfpPersona(IdAfp, IdPersona)

            txtFecha.Value = registro.Fecha
            cmbAFP.Value = registro.Afp.IdAfp
            cmbModalidad.Value = registro.ModalidadCobroAfp.IdModalidad
            txtNumCuenta.Text = registro.NumCuenta

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New ContratoPersonaService.AfpPersona
            Dim AFP As New ContratoPersonaService.Afp
            Dim Persona As New ContratoPersonaService.Persona
            Dim ModalidadCobro As New ContratoPersonaService.ModalidadCobroAfp

            AFP.IdAfp = cmbAFP.Value
            registro.Afp = AFP
            ModalidadCobro.IdModalidad = cmbModalidad.Value
            registro.ModalidadCobroAfp = ModalidadCobro
            Persona.IdPer = IdPersona
            registro.Persona = Persona
            registro.NumCuenta = txtNumCuenta.Text
            registro.Fecha = txtFecha.Value

            If state_button Then        'Modificar
                Modificar(registro)
            Else                              'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cmbAFP.Value) = "" Then
                MsgBox("Debe de Ingresar el AFP.", MsgBoxStyle.Information, "Información")
                cmbAFP.Focus()
                Return False
            ElseIf toBlank(txtFecha.Value) = "" Then
                MsgBox("Debe Ingresar la Fecha. ", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf toBlank(cmbModalidad.Value) = "" Then
                MsgBox("Debe de Ingresar la Modalidad de AFP.", MsgBoxStyle.Information, "Información")
                cmbModalidad.Focus()
                Return False
            ElseIf toBlank(txtNumCuenta.Text) = "" Then
                MsgBox("Debe de ingresar el Nº de Cuenta.", MsgBoxStyle.Information, "Información")
                txtNumCuenta.Focus()
                Return False
                'ElseIf oMaestroService.MostrarTipoCambio("US", txtFecha.Text) = 0 Then
                '    MsgBox("Esta Fecha no tiene Tipo de Cambio, Verifique", MsgBoxStyle.Information, "Información")
                '    txtFecha.Focus()
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub cmbAFP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbAFP.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtFecha.Focus()
        End If
    End Sub

    Private Sub txtFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbModalidad.Focus()
        End If
    End Sub

    Private Sub cmbModalidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbModalidad.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtNumCuenta.Focus()
        End If
    End Sub

    Private Sub txtNumCuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumCuenta.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub
End Class