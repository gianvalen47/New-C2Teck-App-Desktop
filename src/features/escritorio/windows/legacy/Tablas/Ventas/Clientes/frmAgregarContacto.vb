Imports System.Windows.Forms

Public Class frmAgregarContacto
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oContactoServise As New ContactoService.ContactoServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Private dtTipoContacto As DataTable
    Private dtSexos As DataTable

    Public IdCliente As String
    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            cmbIdTipoContacto.KeyPress _
                          , txtNombres.KeyPress _
                          , txtIdContacto.KeyPress _
                          , cbEmailProm.KeyPress _
                          , cbVigente.KeyPress _
                          , txtApellidos.KeyPress _
                          , cmbTitulo.KeyPress _
                          , cmbSexo.KeyPress _
                          , txtFecNac.KeyPress _
                          , txtFax.KeyPress _
                          , txtTelMovil.KeyPress _
                          , txtTelefonos.KeyPress _
                          , txtDireccion.KeyPress _
                          , txtEmail.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()
        If state_button Then    'Modificar
            txtIdContacto.ReadOnly = True
            txtIdContacto.TabStop = False
            ObtenerRegistro()
        Else                    'Nuevo
            txtIdContacto.ReadOnly = True
            txtIdContacto.TabStop = False
            cbVigente.Checked = True
        End If
    End Sub

    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If isClosed(oContactoServise) = False Then
            oContactoServise.Close()
        End If
        If isClosed(oMaestroService) = False Then
            oMaestroService.Close()
        End If
    End Sub

    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                            txtNombres.KeyUp _
                          , txtIdContacto.KeyUp _
                          , txtApellidos.KeyUp _
                          , txtFecNac.KeyUp 
                          ', txtDireccion.KeyUp
        ', txtEmail.KeyUp
        ', txtTelefonos.KeyUp _
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
            If campo.Text.Trim.Length > 0 Then
                campo.BackColor = Color.White
            Else
                campo.BackColor = Color.Red
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            Dim registro As New ContactoService.Contacto
            registro.IdContacto = toNumber(txtIdContacto.Text)
            If state_button = True And toNumber(txtIdContacto.Text) = 0 Then
                MsgBox("Debe Ingresar el código del Contacto", MsgBoxStyle.Information, "Información")
                txtIdContacto.BackColor = Color.Red
                txtIdContacto.Focus()
                Return False
            ElseIf toNumber(cmbIdTipoContacto.Value) = 0 Then
                MsgBox("Debe Ingresar el tipo del Contacto", MsgBoxStyle.Information, "Información")
                cmbIdTipoContacto.BackColor = Color.Red
                cmbIdTipoContacto.Focus()
                Return False
            ElseIf toBlank(cmbTitulo.Text) = "" Then
                MsgBox("Debe Ingresar el título del Contacto", MsgBoxStyle.Information, "Información")
                cmbTitulo.BackColor = Color.Red
                cmbTitulo.Focus()
                Return False
            ElseIf toNumber(cmbSexo.Value) = 0 Then
                MsgBox("Debe Ingresar el sexo del Contacto", MsgBoxStyle.Information, "Información")
                cmbSexo.BackColor = Color.Red
                cmbSexo.Focus()
                Return False
            ElseIf txtNombres.Text.Trim.Length < 1 Then
                MsgBox("Debe Ingresar el nombre del Contacto", MsgBoxStyle.Information, "Información")
                txtNombres.BackColor = Color.Red
                txtNombres.Focus()
                Return False
            ElseIf txtApellidos.Text.Trim.Length < 1 Then
                MsgBox("Debe Ingresar los apellidos del Contacto", MsgBoxStyle.Information, "Información")
                txtApellidos.BackColor = Color.Red
                txtApellidos.Focus()
                Return False
                'ElseIf txtEmail.Text.Trim.Length < 1 Then
                '    MsgBox("Debe Ingresar el email del Contacto", MsgBoxStyle.Information, "Información")
                '    txtEmail.BackColor = Color.Red
                '    txtEmail.Focus()
                '    Return False
                'ElseIf txtTelefonos.Text.Trim.Length < 1 Then
                '    MsgBox("Debe Ingresar el telefono del Contacto", MsgBoxStyle.Information, "Información")
                '    txtTelefonos.BackColor = Color.Red
                '    txtTelefonos.Focus()
                '    Return False
                'ElseIf txtDireccion.Text.Trim.Length < 1 Then
                '    MsgBox("Debe Ingresar la dirección del Contacto", MsgBoxStyle.Information, "Información")
                '    txtDireccion.BackColor = Color.Red
                '    txtDireccion.Focus()
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Insertar(ByVal registro As ContactoService.Contacto)
        Try
            Dim estado_process As Integer
            estado_process = oContactoServise.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                txtIdContacto.Text = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ContactoService.Contacto)
        Try
            Dim estado_process As Boolean
            estado_process = oContactoServise.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ContactoService.Contacto
            registro = oContactoServise.MostrarPorID(toNull(txtIdContacto.Text))

            txtIdContacto.Text = toBlank(registro.IdContacto)
            IdCliente = registro.Cliente.IdCliente
            cmbIdTipoContacto.Value = registro.TipoContacto.IdTipoContacto
            cmbTitulo.Text = toBlank(registro.Titulo)
            txtNombres.Text = toBlank(registro.Nombres)
            txtApellidos.Text = toBlank(registro.Apellidos)
            txtFecNac.Text = registro.FecNac
            cmbSexo.Value = CStr(registro.Sexo)
            txtDireccion.Text = toBlank(registro.Direccion)
            txtEmail.Text = toBlank(registro.Email)
            cbEmailProm.Checked = registro.EmailProm
            txtTelefonos.Text = toBlank(registro.Telefonos)
            txtTelMovil.Text = toBlank(registro.TelMovil)
            txtFax.Text = toBlank(registro.Fax)
            cbVigente.Checked = registro.Vigente
        Catch ex As Exception
            MsgBox("ERROR [AGRE-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= SEXO ================================================
            dtSexos = New DataTable
            dtSexos.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtSexos.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtSexos.Rows.Add(New Object() {"1", "Masculino"}) ', New DateTime(2008, 2, 5)
            dtSexos.Rows.Add(New Object() {"2", "Femenino"})

            cmbSexo.DataSource = dtSexos
            cmbSexo.DropDownList.DataMember = dtSexos.Columns("nombre").ToString
            cmbSexo.DropDownList.DisplayMember = dtSexos.Columns("nombre").ToString
            cmbSexo.DropDownList.ValueMember = dtSexos.Columns("codigo").ToString
            cmbSexo.DropDownList.Columns(0).DataMember = dtSexos.Columns("codigo").ToString
            cmbSexo.DropDownList.Columns(1).DataMember = dtSexos.Columns("nombre").ToString
            dtSexos = Nothing

            '======================================= TIPOS DE CONTACTO ================================================
            dtTipoContacto = oMaestroService.MostrarTipoContacto.Tables(0)
            cmbIdTipoContacto.DataSource = dtTipoContacto
            cmbIdTipoContacto.DropDownList.DataMember = dtTipoContacto.Columns("NomTipo").ToString
            cmbIdTipoContacto.DropDownList.DisplayMember = dtTipoContacto.Columns("NomTipo").ToString
            cmbIdTipoContacto.DropDownList.ValueMember = dtTipoContacto.Columns("IdTipoContacto").ToString
            cmbIdTipoContacto.DropDownList.Columns(0).DataMember = dtTipoContacto.Columns("IdTipoContacto").ToString
            cmbIdTipoContacto.DropDownList.Columns(1).DataMember = dtTipoContacto.Columns("NomTipo").ToString
            dtTipoContacto = Nothing
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New ContactoService.Contacto
            Dim cliente As New ContactoService.Cliente
            Dim tipoContacto As New ContactoService.TipoContacto

            registro.IdContacto = toNull(txtIdContacto.Text)
            cliente.IdCliente = toNull(IdCliente)
            registro.Cliente = cliente
            tipoContacto.IdTipoContacto = toNull(cmbIdTipoContacto.Value)
            registro.TipoContacto = tipoContacto
            registro.Titulo = toNull(cmbTitulo.Text)
            registro.Nombres = toNull(txtNombres.Text)
            registro.Apellidos = toNull(txtApellidos.Text)
            registro.FecNac = toNull(txtFecNac.Text)
            registro.Sexo = toNull(cmbSexo.Value)
            registro.Direccion = toNull(txtDireccion.Text)
            registro.Email = toNull(txtEmail.Text)
            registro.EmailProm = cbEmailProm.Checked
            registro.Telefonos = toNull(txtTelefonos.Text)
            registro.TelMovil = toNull(txtTelMovil.Text)
            registro.Fax = toNull(txtFax.Text)
            registro.Vigente = cbVigente.Checked
            registro.CodUsu = Session.sCodUsu
            registro.DirIp = Session.sDirIp
            registro.NomPc = Session.sNomPc

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub

    Private Sub cmbTitulo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTitulo.SelectedValueChanged
        If cmbTitulo.Text = "Sr." Or cmbTitulo.Text = "Mr." Then
            cmbSexo.Value = "1"
            cmbSexo.ReadOnly = True
            cmbSexo.BackColor = System.Drawing.SystemColors.Control
        ElseIf cmbTitulo.Text = "Sra." Or cmbTitulo.Text = "Ms." Or cmbTitulo.Text = "Srta." Then
            cmbSexo.Value = "2"
            cmbSexo.ReadOnly = True
            cmbSexo.BackColor = System.Drawing.SystemColors.Control
        ElseIf cmbTitulo.Text = "Ing." Then
            cmbSexo.Value = "1"
            cmbSexo.ReadOnly = False
            cmbSexo.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub
End Class
