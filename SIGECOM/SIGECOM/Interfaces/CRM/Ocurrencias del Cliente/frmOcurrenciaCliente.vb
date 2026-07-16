Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports System.Net.Mail
Imports System.ServiceModel

Public Class frmOcurrenciaCliente

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMaestroService As New MaestroService.MaestroClient
    Private oOcurrenciaClienteService As New OcurrenciaClienteService.OcurrenciaClienteServiceClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdOcurrencia As Integer
    Public IdCliente As Integer

    Private dtGruposVenta As DataTable
    Private dtUnidades As DataTable

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                  txtCliente.KeyPress _
                ', txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmOcurrenciaCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
            e.Handled = True
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.CancelButton = Me.btnCancelar
        llenarCombos()
        If state_button Then    'Modificar
            ObtenerRegistro()
            desactivar()
            Me.Text = "Ocurrencia del cliente " + Chr(34) + txtCliente.Text + Chr(34)
        Else                    'Nuevo
            activar()
            btnBuscarCliente.Select()
            Me.Text = "Registrar nueva Ocurrencia" + Chr(34)
        End If
    End Sub

    Private Sub activar()
        btnBuscarCliente.Enabled = True
        cmbUnidad.ReadOnly = False
        cmbUnidad.BackColor = System.Drawing.SystemColors.Window
        lblFecha.Visible = False
        txtFecha.Visible = False
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        cbOportunidad.Enabled = True
        cbEnvioCorreo.Enabled = True
        btnGuardar.Enabled = True
    End Sub

    Private Sub desactivar()
        btnBuscarCliente.Enabled = False
        cmbUnidad.ReadOnly = True
        cmbUnidad.BackColor = System.Drawing.SystemColors.Control
        lblFecha.Visible = True
        txtFecha.Visible = True
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
        cbEnvioCorreo.Enabled = False
        cbOportunidad.Enabled = False
        btnGuardar.Enabled = False
        Me.Size = New System.Drawing.Size(524, 354)
        gbOcurrencia.Size = New System.Drawing.Size(499, 255)
        btnGuardar.Location = New System.Drawing.Point(344, 270)
        btnCancelar.Location = New System.Drawing.Point(428, 270)
    End Sub

    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oOcurrenciaClienteService) = False Then
                oOcurrenciaClienteService.Close()
            End If
            If isClosed(oCentroCostoService) = False Then
                oOcurrenciaClienteService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oOcurrenciaClienteService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                    txtCliente.KeyUp _
                  , txtObservacion.KeyUp _
                  , cmbUnidad.KeyUp
        Try
            Dim campo As New Object
            If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.EditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.EditBox
            ElseIf sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.NumericEditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.NumericEditBox
            ElseIf sender.GetType.ToString = "System.Windows.Forms.TextBox" Then
                campo = New TextBox
            End If
            campo = sender
            If campo.readonly = False Then
                If campo.Text.Trim.Length > 0 Then
                    campo.BackColor = Color.White
                Else
                    campo.BackColor = Color.Red
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    'Private Function getRowTodos(ByVal data As DataTable)
    '    Dim fila As DataRow = data.NewRow
    '    Try
    '        fila(0) = ""
    '    Catch ex As Exception
    '        fila(0) = 0
    '    End Try
    '    fila(1) = "(Ninguno)"
    '    Return fila
    'End Function

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar el cliente.", MsgBoxStyle.Information, "Información")
                txtCliente.BackColor = Color.Red
                btnBuscarCliente.Focus()
                Return False
            ElseIf toBlank(cmbUnidad.Value) = "" Then
                MsgBox("Debe Ingresar la Unidad de Negocio.", MsgBoxStyle.Information, "Información")
                cmbUnidad.BackColor = Color.Red
                cmbUnidad.Focus()
                Return False
            ElseIf toBlank(txtObservacion.Text) = "" Then
                MsgBox("Debe Ingresar la descripción de la Ocurrencia.", MsgBoxStyle.Information, "Información")
                txtObservacion.BackColor = Color.Red
                txtObservacion.Focus()
                Return False
            ElseIf toBlank(txtEmail.Text) = "" And cbEnvioCorreo.Checked = True Then
                MsgBox("Debe Ingresar el Correo Electrónico del Cliente", MsgBoxStyle.Information, "Información")
                txtEmail.Focus()
                Return False
            ElseIf IsValidEmail(txtEmail.Text) = False And cbEnvioCorreo.Checked = True Then
                MsgBox("Dirección de correo electronico no valida,el correo debe tener el formato: nombre@dominio.com", MsgBoxStyle.Information, "Información")
                txtEmail.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As OcurrenciaClienteService.OcurrenciaCliente)
        Try
            Dim estado_process As Integer
            estado_process = oOcurrenciaClienteService.Insertar(registro)
            If cbEnvioCorreo.Checked = True Then
                EnviarCorreo()
            End If
            type_process = "insert"
            If estado_process > 0 Then
                IdOcurrencia = estado_process
                MsgBox("Se insertó la Ocurrencia de Cliente correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As OcurrenciaClienteService.OcurrenciaCliente)
        Try
            Dim estado_process As Boolean
            estado_process = oOcurrenciaClienteService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As OcurrenciaClienteService.OcurrenciaCliente
            registro = oOcurrenciaClienteService.MostrarPorId(IdOcurrencia)

            IdOcurrencia = registro.IdOcurrencia
            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli
            cmbUnidad.Value = registro.UnidadNegocio.IdUnidad
            txtObservacion.Text = registro.Observacion
            txtFecha.Text = registro.Fecha
            cbOportunidad.Checked = registro.Oportunidad

        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '================================= UNIDADES DE NEGOCIO =========================================
            dtUnidades = oCentroCostoService.MostrarUnidadNegocio(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbUnidad.DataSource = dtUnidades
            cmbUnidad.DropDownList.DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.DisplayMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.DropDownList.ValueMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(0).DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(1).DataMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.SelectedIndex = 0
            dtUnidades = Nothing
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New OcurrenciaClienteService.OcurrenciaCliente
            Dim cliente As New OcurrenciaClienteService.Cliente
            Dim unidad As New OcurrenciaClienteService.UnidadNegocio

            registro.IdOcurrencia = IdOcurrencia
            cliente.IdCliente = IdCliente
            registro.Cliente = cliente
            unidad.IdUnidad = toNull(cmbUnidad.Value)
            registro.UnidadNegocio = unidad
            registro.Oportunidad = cbOportunidad.Checked

            If cbEnvioCorreo.Checked = True Then
                registro.Observacion = toNull(txtObservacion.Text) & vbCrLf & vbCrLf & "Esta información se envió al correo: " & txtEmail.Text
            Else
                registro.Observacion = toNull(txtObservacion.Text)
            End If

            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub
    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If
        txtCliente.Select()

    End Sub

    Private Sub cbEnvioCorreo_CheckedChanged(sender As Object, e As System.EventArgs) Handles cbEnvioCorreo.CheckedChanged
        If cbEnvioCorreo.Checked = True Then
            txtEmail.ReadOnly = False
            txtEmail.BackColor = System.Drawing.SystemColors.Window
        Else
            txtEmail.ReadOnly = True
            txtEmail.BackColor = System.Drawing.SystemColors.Control
            txtEmail.Text = ""
        End If
    End Sub

    Public Function IsValidEmail(ByVal email As String) As Boolean
        Try
            If email = String.Empty Then Return False
            Dim re As Regex = New Regex("^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")
            Dim m As Match = re.Match(email)
            Return (m.Captures.Count <> 0)
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR EMAIL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub EnviarCorreo()
        Try
            Dim usuario As New SeguridadService.Usuario
            usuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)

            Dim SendFrom As MailAddress = New MailAddress("SIGECOM - Detroit Diesel Mtu Perú S.A.C <adminbd@ddperu.com.pe>")
            Dim SendTo As MailAddress = New MailAddress(txtEmail.Text.Trim)
            Dim MyMessage As MailMessage = New MailMessage(SendFrom, SendTo)
            'If toBlank(txtcc.Text) <> "" Then
            '    MyMessage.CC.Add(txtcc.Text)
            'End If
            MyMessage.Subject = "Ocurrencia de Cliente : " & txtCliente.Text
            MyMessage.Body = "Fecha de envío " & Today() & " : " & TimeOfDay & Environment.NewLine & _
                                            "REGISTRADO POR : " & usuario.Persona.ApeNom & Environment.NewLine & Environment.NewLine & _
                                            "UNIDAD DE NEGOCIO : " & cmbUnidad.Text & Environment.NewLine & Environment.NewLine & _
                                            txtObservacion.Text & Environment.NewLine & Environment.NewLine & _
                                            "No Contestar el correo porque es una cuenta desatendida."

            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Host = "mail.ddperu.com.pe"
            smtp.Credentials = New System.Net.NetworkCredential("adminbd@ddperu.com.pe", "adminbd")
            smtp.Send(MyMessage)
            'MsgBox("Se envio el correo correctamente", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox("ERROR AL ENVIAR CORREO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnGuardar_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles btnGuardar.PreviewKeyDown

    End Sub
End Class
