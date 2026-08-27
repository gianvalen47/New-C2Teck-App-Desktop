Imports System.ServiceModel
Public Class frmContPerDHMayores

    '===========================Servicios====================================================
    Private oContratoPersonaService As New ContratoPersonaService.ContratoPersonaServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private dtTipoVinculo As DataTable
    '======================Declaración de Variables==============================================

    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public IdPersona As Integer
    Public ApeNom As String
    Public IdDH As Integer

    Private Sub frmContContrato_Det_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oContratoPersonaService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oContratoPersonaService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oContratoPersonaService.Abort()
            oPersonaService.Abort()
        End Try
    End Sub

    Private Sub frmContContrato_Det_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            'desactivar()
            activar()
            ObtenerRegistro()
            txtColaborador.Focus()
        Else                                      'Nuevo          
            activar()
            cmbVinculoFam.Value = "1"
            'txtColaborador.Text = ApeNom

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
            '======================================= TIPO VÍNCULO =============================================
            dtTipoVinculo = oPersonaService.MostrarTipoVinculos.Tables(0)
            cmbVinculoFam.DataSource = dtTipoVinculo
            cmbVinculoFam.DropDownList.DataMember = dtTipoVinculo.Columns("DesVinculo").ToString
            cmbVinculoFam.DropDownList.DisplayMember = dtTipoVinculo.Columns("DesVinculo").ToString
            cmbVinculoFam.DropDownList.ValueMember = dtTipoVinculo.Columns("CodVinculo").ToString
            cmbVinculoFam.DropDownList.Columns(0).DataMember = dtTipoVinculo.Columns("CodVinculo").ToString
            cmbVinculoFam.DropDownList.Columns(1).DataMember = dtTipoVinculo.Columns("DesVinculo").ToString
            dtTipoVinculo = Nothing
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
        txtColaborador.ReadOnly = False
        txtColaborador.BackColor = System.Drawing.SystemColors.Window
        cmbVinculoFam.ReadOnly = False
        cmbVinculoFam.BackColor = System.Drawing.SystemColors.Window
        txtMonto.ReadOnly = False
        txtMonto.BackColor = System.Drawing.SystemColors.Window

        btnGuardar.Enabled = True
    End Sub

    Private Sub desactivar()
        txtColaborador.ReadOnly = True
        txtColaborador.BackColor = System.Drawing.SystemColors.Control

        cmbVinculoFam.ReadOnly = True
        cmbVinculoFam.BackColor = System.Drawing.SystemColors.Control

        txtMonto.ReadOnly = True
        txtMonto.BackColor = System.Drawing.SystemColors.Control

        btnGuardar.Enabled = True
    End Sub

    Private Sub Insertar(ByVal registro As ContratoPersonaService.DerechoHabienteMayores)
        Try
            Dim estado_process As Boolean
            estado_process = oContratoPersonaService.InsertarDH(registro)
            type_process = "insert"
            If estado_process Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR OTRO DH : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ContratoPersonaService.DerechoHabienteMayores)
        Try
            Dim estado_process As Boolean
            estado_process = oContratoPersonaService.ActualizarDH(registro)
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
            Dim registro As ContratoPersonaService.DerechoHabienteMayores
            registro = oContratoPersonaService.ObtenerDH(IdDH)
            txtID.Text = IdDH
            IdPersona = registro.Persona.IdPer
            txtColaborador.Text = registro.Nombres
            cmbVinculoFam.Value = registro.TipoVinculoFamilia.CodVinculo
            txtMonto.Value = registro.Monto

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

            Dim registro As New ContratoPersonaService.DerechoHabienteMayores
            Dim Persona As New ContratoPersonaService.Persona
            Dim vinculo As New ContratoPersonaService.TipoVinculoFamilia

            registro.IdDH = IdDH
            Persona.IdPer = IdPersona
            registro.Persona = Persona
            registro.Nombres = txtColaborador.Text
            vinculo.CodVinculo = cmbVinculoFam.Value
            registro.TipoVinculoFamilia = vinculo
            registro.Monto = txtMonto.Value
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
            ElseIf toBlank(txtColaborador.Text) = "" Then
                MsgBox("Debe Ingresar LOS NOMBRES Y APELLIDOS ", MsgBoxStyle.Information, "Información")
                txtColaborador.Focus()
                Return False
            ElseIf toDouble(txtMonto.Value) = 0 Then
                MsgBox("Debe Ingresar EL MONTO DE LA EPS. ", MsgBoxStyle.Information, "Información")
                txtMonto.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

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


End Class