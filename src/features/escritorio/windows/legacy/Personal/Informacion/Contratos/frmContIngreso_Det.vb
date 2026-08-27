Imports System.ServiceModel
Public Class frmContIngreso_Det

    '===========================Servicios====================================================
    Private oMaestroService As New MaestroService.MaestroClient
    Private oContratoPersonaService As New ContratoPersonaService.ContratoPersonaServiceClient

    '======================Declaración de Variables==============================================
    Public IdRubroIng As Integer
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public IdPersona As Integer
    Public CodMon As String                    '23/01/2012
    Private dtRubroIng As DataTable

    Private Sub frmContIngresosDet_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oContratoPersonaService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oContratoPersonaService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oContratoPersonaService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmContIngresosDet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            cmbIngreso.TabStop = False
            txtTotalImporte.Focus()
        Else                                      'Nuevo                      
            cbAplicaCalculo.Checked = True
            cbSueldo.Checked = True
            activar()
            cmbIngreso.TabStop = True
            cmbIngreso.Focus()
        End If
        EnableOptions()
    End Sub

    Private Sub frmContIngresosDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub llenarCombos()
        Try

            '========================================== AFPS ===============================================
            dtRubroIng = oContratoPersonaService.MostrarRubroIngresoPlanilla(Session.sCodEmp).Tables(0)
            cmbIngreso.DataSource = dtRubroIng
            cmbIngreso.DropDownList.DataMember = dtRubroIng.Columns("DesIngreso").ToString
            cmbIngreso.DropDownList.DisplayMember = dtRubroIng.Columns("DesIngreso").ToString
            cmbIngreso.DropDownList.ValueMember = dtRubroIng.Columns("IdRubroIng").ToString
            cmbIngreso.DropDownList.Columns(0).DataMember = dtRubroIng.Columns("IdRubroIng").ToString
            cmbIngreso.DropDownList.Columns(1).DataMember = dtRubroIng.Columns("DesIngreso").ToString
            'cmbIngreso.SelectedIndex = 0
            dtRubroIng = Nothing

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
        cmbIngreso.ReadOnly = False
        cmbIngreso.BackColor = System.Drawing.SystemColors.Window
        txtTotalImporte.ReadOnly = False
        txtTotalImporte.BackColor = System.Drawing.SystemColors.Window
        cbAplicaCalculo.Enabled = True
        cbSueldo.Enabled = True
        cmbIngreso.Focus()
    End Sub

    Private Sub desactivar()
        'If estado = 1 Then
        'activar()
        'Else
        cmbIngreso.ReadOnly = True
        cmbIngreso.BackColor = System.Drawing.SystemColors.Control
        txtTotalImporte.ReadOnly = False
        txtTotalImporte.BackColor = System.Drawing.SystemColors.Window
        cbAplicaCalculo.Enabled = True
        cbSueldo.Enabled = True
        txtTotalImporte.Focus()
        'End If
    End Sub

    Private Sub Insertar(ByVal registro As ContratoPersonaService.RubroIngresoContrato)
        Try
            Dim estado_process As Boolean
            estado_process = oContratoPersonaService.InsertarRubroIngreso(registro)
            type_process = "insert"
            If estado_process Then
                IdRubroIng = cmbIngreso.Value
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR INGRESO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ContratoPersonaService.RubroIngresoContrato)
        Try
            Dim estado_process As Boolean
            estado_process = oContratoPersonaService.ActualizarRubroIngreso(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR AFP : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ContratoPersonaService.RubroIngresoContrato
            registro = oContratoPersonaService.ObtenerRubroIngreso(IdPersona, IdRubroIng)

            cmbIngreso.Value = registro.RubroIngresoPlanilla.IdRubroIng
            txtTotalImporte.Value = registro.Monto
            cbAplicaCalculo.Checked = registro.AplicaCalculo
            cbSueldo.Checked = registro.Sueldo

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

            Dim registro As New ContratoPersonaService.RubroIngresoContrato
            Dim RubroIngresoPlanilla As New ContratoPersonaService.RubroIngresoPlanilla
            Dim Persona As New ContratoPersonaService.Persona
            Dim Moneda As New ContratoPersonaService.Moneda

            RubroIngresoPlanilla.IdRubroIng = cmbIngreso.Value
            registro.RubroIngresoPlanilla = RubroIngresoPlanilla
            Persona.IdPer = IdPersona
            registro.Persona = Persona
            Moneda.CodMon = CodMon
            registro.Moneda = Moneda
            registro.Monto = txtTotalImporte.Value
            registro.AplicaCalculo = cbAplicaCalculo.Checked
            registro.Sueldo = cbSueldo.Checked

            registro.FecReg = Today
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp
            registro.CodUsu = Session.sCodUsu

            If state_button Then        'Modificar
                Modificar(registro)
            Else                              'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cmbIngreso.Value) = "" Then
                MsgBox("Debe Ingresar el Rubro Ingreso. ", MsgBoxStyle.Information, "Información")
                cmbIngreso.Focus()
                Return False
            ElseIf Not (toDouble(txtTotalImporte.Value) > 0) Then
                MsgBox("Debe de ingresar el Importe.", MsgBoxStyle.Information, "Información")
                txtTotalImporte.Focus()
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

    Private Sub cmbIngreso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbIngreso.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtTotalImporte.Focus()
        End If
    End Sub

    Private Sub txtTotalImporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalImporte.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cbAplicaCalculo.Focus()
        End If
    End Sub

    Private Sub cbAplicaCalculo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbAplicaCalculo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cbSueldo.Focus()
        End If
    End Sub

    Private Sub cbSueldo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbSueldo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub
End Class