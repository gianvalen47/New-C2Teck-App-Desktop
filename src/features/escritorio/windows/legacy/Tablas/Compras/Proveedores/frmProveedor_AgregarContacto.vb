Imports System.ServiceModel
Public Class frmProveedor_AgregarContacto

    Public state_button As Boolean              'True: Modificar    False: Nuevo
    Public type_process As String                'Update     Insert      Delete
    Private oContactoProveedorService As New ContactoProveedorService.ContactoProveedorServiceClient
    Private dtDatos As DataTable

    Private dtTipoContacto As DataTable
    Private dtSexos As DataTable

    Public IdProveedor As String

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            cmbIdTipoContacto.KeyPress _
                          , txtNombres.KeyPress _
                          , txtIdContacto.KeyPress _
                          , txtApellidos.KeyPress _
                          , txtRadio.KeyPress _
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

    Private Sub frmProveedor_AgregarContacto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
        End If
    End Sub
    Private Sub frmProveedor_AgregarContacto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oContactoProveedorService.Close()
        Catch ex As TimeoutException
            oContactoProveedorService.Abort()
        Catch ex As CommunicationException
            oContactoProveedorService.Abort()
        End Try
    End Sub

    Private Sub frmProveedor_AgregarContacto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()
        If state_button Then    'Modificar
            txtIdContacto.ReadOnly = True
            txtIdContacto.TabStop = False
            ObtenerRegistro()
        Else                    'Nuevo
            txtIdContacto.ReadOnly = True
            txtIdContacto.TabStop = False
        End If
    End Sub

    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                            txtNombres.KeyUp _
                          , txtIdContacto.KeyUp _
                          , txtApellidos.KeyUp _
                          , txtFecNac.KeyUp
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
            ElseIf txtDireccion.Text.Trim.Length < 1 Then
                MsgBox("Debe Ingresar la dirección del Contacto", MsgBoxStyle.Information, "Información")
                txtDireccion.BackColor = Color.Red
                txtDireccion.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Insertar(ByVal registro As ContactoProveedorService.ContactoProveedor)
        Try
            Dim estado_process As Integer
            estado_process = oContactoProveedorService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                txtIdContacto.Text = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR CONTACTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ContactoProveedorService.ContactoProveedor)
        Try
            Dim estado_process As Boolean
            estado_process = oContactoProveedorService.Actualizar(registro)
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
            Dim registro As ContactoProveedorService.ContactoProveedor
            registro = oContactoProveedorService.Obtener(toNull(txtIdContacto.Text))

            txtIdContacto.Text = toBlank(registro.IdContacto)
            IdProveedor = registro.Proveedor.IdProveedor
            cmbIdTipoContacto.Value = registro.TipoContactoProveedor.IdTipoContacto
            cmbTitulo.Text = toBlank(registro.Titulo)
            txtNombres.Text = toBlank(registro.Nombres)
            txtApellidos.Text = toBlank(registro.Apellidos)
            txtFecNac.Text = registro.FecNac
            cmbSexo.Value = CStr(registro.Sexo)
            txtDireccion.Text = toBlank(registro.Direccion)
            txtEmail.Text = toBlank(registro.Email)
            txtRadio.Text = CStr(registro.Radio)
            txtTelefonos.Text = toBlank(registro.Telefonos)
            txtTelMovil.Text = toBlank(registro.TelMovil)
            txtFax.Text = toBlank(registro.Fax)

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
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
            dtTipoContacto = oContactoProveedorService.MostrarTipoContacto.Tables(0)
            cmbIdTipoContacto.DataSource = dtTipoContacto
            cmbIdTipoContacto.DropDownList.DataMember = dtTipoContacto.Columns("NomTipo").ToString
            cmbIdTipoContacto.DropDownList.DisplayMember = dtTipoContacto.Columns("NomTipo").ToString
            cmbIdTipoContacto.DropDownList.ValueMember = dtTipoContacto.Columns("IdTipoContacto").ToString
            cmbIdTipoContacto.DropDownList.Columns(0).DataMember = dtTipoContacto.Columns("IdTipoContacto").ToString
            cmbIdTipoContacto.DropDownList.Columns(1).DataMember = dtTipoContacto.Columns("NomTipo").ToString
            dtTipoContacto = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

            If ValidaCampos() Then

                Dim registro As New ContactoProveedorService.ContactoProveedor
                Dim proveedor As New ContactoProveedorService.Proveedor
                Dim tipoContacto As New ContactoProveedorService.TipoContactoProveedor

                registro.IdContacto = toNull(txtIdContacto.Text)
                proveedor.IdProveedor = CInt(IdProveedor)
                registro.Proveedor = proveedor
                tipoContacto.IdTipoContacto = toNull(cmbIdTipoContacto.Value)
                registro.TipoContactoProveedor = tipoContacto
                registro.Titulo = toNull(cmbTitulo.Text)
                registro.Nombres = toNull(txtNombres.Text)
                registro.Apellidos = toNull(txtApellidos.Text)
                registro.FecNac = toNull(txtFecNac.Text)
                registro.Sexo = toNull(cmbSexo.Value)
                registro.Direccion = toNull(txtDireccion.Text)
                registro.Email = toNull(txtEmail.Text)
                registro.Radio = toNull(txtRadio.Text)
                registro.Telefonos = toNull(txtTelefonos.Text)
                registro.TelMovil = toNull(txtTelMovil.Text)
                registro.Fax = toNull(txtFax.Text)

                registro.CodUsu = Session.sCodUsu

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                        'Nuevo
                    Insertar(registro)
                End If
            End If
        End If
    End Sub

    Private Sub cmbTitulo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTitulo.SelectedValueChanged
        If cmbTitulo.Text = "Sr." Or cmbTitulo.Text = "Mr." Then
            cmbSexo.Value = "1"
        ElseIf cmbTitulo.Text = "Sra." Or cmbTitulo.Text = "Ms." Or cmbTitulo.Text = "Srta." Then
            cmbSexo.Value = "2"
        End If
    End Sub

End Class