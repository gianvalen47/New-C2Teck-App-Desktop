Imports System.ServiceModel

Public Class frmProveedor_AgregarCuentaPago

    Private oMaestroService As New MaestroService.MaestroClient
    Private oProveedorService As New ProveedorService.ProveedorServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    Public state_button As Boolean              'True: Modificar    False: Nuevo
    Public type_process As String                'Update     Insert      Delete

    Private dtBancos As DataTable
    Private dtCuentaBancos As DataTable
    Private dtMonedas As DataTable
    Private dtTipoProductoBanco As DataTable
    Private dtTipoDoc As DataTable

    Public IdProveedor As String
    Public Banco As String
    Public Moneda As String

    Private Sub frmProveedor_AgregarCuentaPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CancelButton = Me.btnCancelar
        LlenarCombos()
        If state_button Then    'Modificar
            'txtIdContacto.ReadOnly = True
            'txtIdContacto.TabStop = False
            ObtenerRegistro()
        Else                    'Nuevo
            'txtIdContacto.ReadOnly = True
            'txtIdContacto.TabStop = False
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            cmbBanco.KeyPress _
                          , cmbMoneda.KeyPress _
                          , cmbTipoCuenta.KeyPress _
                          , txtNumCta.KeyPress _
                          , cmbTipoDoc.KeyPress _
                          , txtNumDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub LlenarCombos()

        '======================================= BANCOS =================================================
        dtBancos = oMaestroService.MostrarBancos.Tables(0)
        dtBancos.Rows.InsertAt(getRowTodos(dtBancos), 0)
        cmbBanco.DataSource = dtBancos
        cmbBanco.DropDownList.DataMember = dtBancos.Columns("DesBan").ToString
        cmbBanco.DropDownList.DisplayMember = dtBancos.Columns("DesBan").ToString
        cmbBanco.DropDownList.ValueMember = dtBancos.Columns("CodBan").ToString
        cmbBanco.DropDownList.Columns(0).DataMember = dtBancos.Columns("CodBan").ToString
        cmbBanco.DropDownList.Columns(1).DataMember = dtBancos.Columns("DesBan").ToString
        cmbBanco.SelectedIndex = 0
        dtBancos = Nothing

        '======================================= MONEDAS ================================================
        dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
        dtMonedas.Rows.InsertAt(getRowTodos1(dtMonedas), 0)
        cmbMoneda.DataSource = dtMonedas
        cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
        cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
        cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
        cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
        cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
        cmbMoneda.SelectedIndex = 0
        dtMonedas = Nothing

        '===================================== TIPO CUENTA ===============================================
        dtTipoProductoBanco = oProveedorService.MostrarTipoProductoBanco.Tables(0)
        dtTipoProductoBanco.Rows.InsertAt(getRowTodos1(dtTipoProductoBanco), 0)
        cmbTipoCuenta.DataSource = dtTipoProductoBanco
        cmbTipoCuenta.DropDownList.DataMember = dtTipoProductoBanco.Columns("DesTipoCuenta").ToString
        cmbTipoCuenta.DropDownList.DisplayMember = dtTipoProductoBanco.Columns("DesTipoCuenta").ToString
        cmbTipoCuenta.DropDownList.ValueMember = dtTipoProductoBanco.Columns("CodTipoCuenta").ToString
        cmbTipoCuenta.DropDownList.Columns(0).DataMember = dtTipoProductoBanco.Columns("CodTipoCuenta").ToString
        cmbTipoCuenta.DropDownList.Columns(1).DataMember = dtTipoProductoBanco.Columns("DesTipoCuenta").ToString
        cmbTipoCuenta.SelectedIndex = 0
        dtTipoProductoBanco = Nothing

        '=================================== TIPO DE DOCUMENTO ========================================
        dtTipoDoc = oPersonaService.MostrarTipoDocumento.Tables(0)
        cmbTipoDoc.DataSource = dtTipoDoc
        cmbTipoDoc.DropDownList.DataMember = dtTipoDoc.Columns("DesDoc").ToString
        cmbTipoDoc.DropDownList.DisplayMember = dtTipoDoc.Columns("DesDoc").ToString
        cmbTipoDoc.DropDownList.ValueMember = dtTipoDoc.Columns("CodDoc").ToString
        cmbTipoDoc.DropDownList.Columns(0).DataMember = dtTipoDoc.Columns("CodDoc").ToString
        cmbTipoDoc.DropDownList.Columns(1).DataMember = dtTipoDoc.Columns("DesDoc").ToString
        cmbTipoDoc.SelectedIndex = 0
        dtTipoDoc = Nothing

    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Ninguno)"
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Ninguno)"
        Catch ex As Exception
            fila(2) = "(Ninguno)"
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
            fila(3) = 0
        End Try
        Return fila
    End Function

    Private Function getRowTodos1(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Ninguno)"
        Catch ex As Exception
            fila(2) = "(Ninguno)"
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception

        End Try
        Return fila
    End Function

    Private Sub ObtenerRegistro()

        Try
            Dim registro As ProveedorService.ProveedorCuentaBanco
            registro = oProveedorService.ObtenerCuentaBanco(toNumber(IdProveedor), Banco, Moneda)

            cmbBanco.Value = registro.Banco.CodBan
            cmbMoneda.Value = registro.Moneda.CodMon
            cmbTipoCuenta.Value = registro.TipoCuentaBanco.CodTipoCuenta
            txtNumCta.Text = registro.NumCta
            cmbTipoDoc.Value = registro.TipoDocumentoId.CodDoc
            txtNumDoc.Text = registro.NumDoc
            txtCtaInterbancario.Text = registro.CtaInterbancario
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

            If ValidaCampos() Then

                Dim registro As New ProveedorService.ProveedorCuentaBanco
                Dim banco As New ProveedorService.Banco
                Dim moneda As New ProveedorService.Moneda
                Dim tipocuenta As New ProveedorService.TipoCuentaBanco
                Dim tipodocumento As New ProveedorService.TipoDocumentoId
                Dim proveedor As New ProveedorService.Proveedor

                proveedor.IdProveedor = CInt(IdProveedor)
                registro.Proveedor = proveedor

                banco.CodBan = toBlank(cmbBanco.Value)
                registro.Banco = banco

                moneda.CodMon = toBlank(cmbMoneda.Value)
                registro.Moneda = moneda

                tipocuenta.CodTipoCuenta = toBlank(cmbTipoCuenta.Value)
                registro.TipoCuentaBanco = tipocuenta

                registro.NumCta = txtNumCta.Text
                registro.CtaInterbancario = txtCtaInterbancario.Text
                tipodocumento.CodDoc = toBlank(cmbTipoDoc.Value)
                registro.TipoDocumentoId = tipodocumento

                registro.NumDoc = toBlank(txtNumDoc.Text)

                registro.CodUsu = Session.sCodUsu
                registro.DirIp = Session.sDirIp
                registro.NomPc = Session.sNomPc

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                        'Nuevo
                    Insertar(registro)
                End If
            End If
        End If
    End Sub

    Private Sub Insertar(ByVal registro As ProveedorService.ProveedorCuentaBanco)
        Try
            Dim estado_process As Boolean
            estado_process = oProveedorService.InsertarCuentaBanco(registro)
            type_process = "insert"
            If estado_process Then
                'txtIdContacto.Text = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA CUENTA BANCO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ProveedorService.ProveedorCuentaBanco)
        Try
            Dim estado_process As Boolean
            estado_process = oProveedorService.ActualizarCuentaBanco(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LA CUENTA BANCO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            'Dim registro As New ContactoService.Contacto
            'registro.IdContacto = toNumber(txtIdContacto.Text)
            'If state_button = True And toNumber(txtIdContacto.Text) = 0 Then
            '    MsgBox("Debe Ingresar el código del Contacto", MsgBoxStyle.Information, "Información")
            '    txtIdContacto.BackColor = Color.Red
            '    txtIdContacto.Focus()
            '    Return False
            If toNumber(cmbBanco.Value) = 0 Then
                MsgBox("Debe Ingresar el banco", MsgBoxStyle.Information, "Información")
                cmbBanco.BackColor = Color.Red
                cmbBanco.Focus()
                Return False
            ElseIf toBlank(cmbTipoCuenta.Text) = "" Then
                MsgBox("Debe Ingresar el tipo de cuenta", MsgBoxStyle.Information, "Información")
                cmbTipoCuenta.BackColor = Color.Red
                cmbTipoCuenta.Focus()
                Return False
            ElseIf toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe Ingresar la moneda", MsgBoxStyle.Information, "Información")
                cmbMoneda.BackColor = Color.Red
                cmbMoneda.Focus()
                Return False
            ElseIf txtNumCta.Text.Trim.Length < 1 Then
                MsgBox("Debe Ingresar el numero de cuenta", MsgBoxStyle.Information, "Información")
                txtNumCta.BackColor = Color.Red
                txtNumCta.Focus()
                Return False
            ElseIf toBlank(cmbTipoDoc.Text) = "" Then
                MsgBox("Debe Ingresar el tipo documento", MsgBoxStyle.Information, "Información")
                cmbTipoDoc.BackColor = Color.Red
                cmbTipoDoc.Focus()
                Return False
            ElseIf txtNumDoc.Text.Trim.Length < 1 Then
                MsgBox("Debe Ingresar el numero de cuenta", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmProveedor_AgregarCuentaPago_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub frmProveedor_AgregarCuentaPago_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oProveedorService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oProveedorService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oProveedorService.Abort()
            oPersonaService.Abort()
        End Try
    End Sub
End Class