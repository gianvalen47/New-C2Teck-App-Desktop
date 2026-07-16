Imports System.ServiceModel
Public Class frmContPerOtroEmpleador

    '===========================Servicios====================================================
    Private oContratoPersonaService As New ContratoPersonaService.ContratoPersonaServiceClient

    '======================Declaración de Variables==============================================
    Public rucEmp As String
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
        txtRazonSocial.ReadOnly = False
        txtRazonSocial.BackColor = System.Drawing.SystemColors.Window
        txtRuc.ReadOnly = False
        txtRuc.BackColor = System.Drawing.SystemColors.Window

        btnGuardar.Enabled = True
    End Sub

    Private Sub desactivar()
        txtColaborador.ReadOnly = True
        txtColaborador.BackColor = System.Drawing.SystemColors.Control

        btnGuardar.Enabled = True
    End Sub

    Private Sub Insertar(ByVal registro As ContratoPersonaService.OtroEmpleadorPersona)
        Try
            Dim estado_process As Boolean
            estado_process = oContratoPersonaService.InsertarOtroEmpleador(registro)
            type_process = "insert"
            If estado_process Then
                rucEmp = txtRuc.Text
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR OTRO EMPLEADOR : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ContratoPersonaService.OtroEmpleadorPersona)
        Try
            Dim estado_process As Boolean
            estado_process = oContratoPersonaService.ActualizarOtroEmpleador(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR OTRO EMPLEADOR : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ContratoPersonaService.OtroEmpleadorPersona
            registro = oContratoPersonaService.ObtenerOtroEmpleador(IdPersona, rucEmp)

            rucEmp = registro.RucEmp
            IdPersona = registro.Persona.IdPer
            txtColaborador.Text = ApeNom
            txtRazonSocial.Text = registro.DesEmp
            txtRuc.Text = registro.RucEmp

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

            Dim registro As New ContratoPersonaService.OtroEmpleadorPersona
            Dim Persona As New ContratoPersonaService.Persona

            registro.RucEmp = txtRuc.Text
            rucEmp = txtRuc.Text
            Persona.IdPer = IdPersona
            registro.Persona = Persona
            registro.DesEmp = txtRazonSocial.Text
            registro.CodUsu = Session.sCodUsu
            registro.DirIp = Session.sDirIp
            registro.NomPc = Session.sNomPc

            If state_button Then        'Modificar
                Modificar(registro)
            Else                              'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdPersona) = 0 Then
                MsgBox("Debe Seleccionar al Colaborador. ", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(txtRuc.Text) = "" Then
                MsgBox("Debe Ingresar EL RUC. ", MsgBoxStyle.Information, "Información")
                txtRuc.Focus()
                Return False
            ElseIf toBlank(txtRazonSocial.Text) = "" Then
                MsgBox("Debe Ingresar la RAZON SOCIAL. ", MsgBoxStyle.Information, "Información")
                txtRazonSocial.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        txtRuc.KeyPress, txtRazonSocial.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtFecFinal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
                    txtRuc.Focus()
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