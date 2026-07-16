Imports System.ServiceModel
Public Class frmContPerContrato_Det

    '===========================Servicios====================================================
    Private oContratoPersonaService As New ContratoPersonaService.ContratoPersonaServiceClient

    '======================Declaración de Variables==============================================
    Public IdCon As Integer
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public IdPersona As Integer
    Public ApeNom As String

    Private Sub frmContContrato_Det_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oContratoPersonaService.Close()
        Catch ex As TimeoutException
            oContratoPersonaService.Abort()
        Catch ex As CommunicationException
            oContratoPersonaService.Abort()
        End Try
    End Sub

    Private Sub frmContContrato_Det_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            desactivar()
            ObtenerRegistro()
            txtColaborador.Focus()
        Else                                      'Nuevo          
            activar()
            txtColaborador.Text = ApeNom
            txtFecha.Value = Today
            txtFecInicio.Value = Today
            txtFecFinal.Value = Today
            txtFecha.Focus()
        End If
        EnableOptions()
    End Sub

    Private Sub frmContContrato_Det_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub llenarCombos()
        Try

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
        txtColaborador.ReadOnly = True
        txtColaborador.BackColor = System.Drawing.SystemColors.Control
        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        txtPeriodo.ReadOnly = False
        txtPeriodo.BackColor = System.Drawing.SystemColors.Window
        txtFecInicio.ReadOnly = False
        txtFecInicio.BackColor = System.Drawing.SystemColors.Window
        txtFecFinal.ReadOnly = False
        txtFecFinal.BackColor = System.Drawing.SystemColors.Window
        txtFecha.Focus()
        btnGuardar.Enabled = True
    End Sub

    Private Sub desactivar()
        txtColaborador.ReadOnly = True
        txtColaborador.BackColor = System.Drawing.SystemColors.Control
        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        txtFecInicio.ReadOnly = False
        txtFecInicio.BackColor = System.Drawing.SystemColors.Window
        txtFecFinal.ReadOnly = False
        txtFecFinal.BackColor = System.Drawing.SystemColors.Window
        txtFecha.Focus()
        btnGuardar.Enabled = True
    End Sub

    Private Sub Insertar(ByVal registro As ContratoPersonaService.PeriodosContrato)
        Try
            Dim estado_process As Integer
            estado_process = oContratoPersonaService.InsertarPeriodosContrato(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdCon = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR PERIODO CONTRATO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ContratoPersonaService.PeriodosContrato)
        Try
            Dim estado_process As Boolean
            estado_process = oContratoPersonaService.ActualizarPeriodosContrato(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR PERIODO CONTRATO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ContratoPersonaService.PeriodosContrato
            registro = oContratoPersonaService.ObtenerPeriodosContrato(IdCon)

            IdCon = registro.IdContrato
            IdPersona = registro.Persona.IdPer
            txtColaborador.Text = registro.Persona.ApeNom
            txtFecha.Value = registro.Fecha
            txtPeriodo.Text = registro.Periodo
            txtFecInicio.Value = registro.FecInicio
            txtFecFinal.Value = registro.FecFinal

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

            Dim registro As New ContratoPersonaService.PeriodosContrato
            Dim Persona As New ContratoPersonaService.Persona

            registro.IdContrato = IdCon
            Persona.IdPer = IdPersona
            registro.Persona = Persona
            registro.Fecha = txtFecha.Value
            registro.Periodo = IIf(txtPeriodo.Text = "", Nothing, txtPeriodo.Text)
            registro.FecInicio = txtFecInicio.Value
            registro.FecFinal = txtFecFinal.Value

            registro.CodUsu = Session.sCodUsu
            registro.DirIp = Session.sDirIp
            registro.NomPc = Session.sNomPc

            If state_button Then        'Modificar
                Modificar(registro)
            Else                              'Nuevo
                registro.FecReg = Today
                Insertar(registro)
            End If
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdPersona) = 0 Then
                MsgBox("Debe Seleccionar al Colaborador. ", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(txtFecha.Value) = "" Then
                MsgBox("Debe Ingresar la Fecha. ", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf toBlank(txtFecInicio.Value) = "" Then
                MsgBox("Debe Ingresar la Fecha Inicio. ", MsgBoxStyle.Information, "Información")
                txtFecInicio.Focus()
                Return False
            ElseIf toBlank(txtFecFinal.Value) = "" Then
                MsgBox("Debe Ingresar la Fecha Final. ", MsgBoxStyle.Information, "Información")
                txtFecFinal.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                       txtFecha.KeyPress _
                     , txtPeriodo.KeyPress _
                     , txtFecInicio.KeyPress 
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtFecFinal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecFinal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub

    Private Sub btnBuscarColaborador_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersona = frm.codigo
                    txtColaborador.Text = frm.descripcion
                    txtFecha.Focus()
                Else
                    IdPersona = 0
                    txtColaborador.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class