Imports System.Windows.Forms
Imports FacturarSunat21.aplicacion
Imports Newtonsoft.Json
Imports UblLarsen.Ubl21.Aplicacion

Public Class frmAgregarClienteSunat



    Private oDireccionFiscalService As New DireccionFiscalService.DireccionFiscalServiceClient
    Private oClienteService As New ClienteService.ClienteServiceClient
    Private oProveedorService As New ProveedorService.ProveedorServiceClient

    Private CodUbigeo As String

    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdCliente As Int64
    Public IdProveedor As Int64
    Public tipoBusqueda As Integer '(1 = Cliente, 2 Proveedor)
    Private dtTipoDoc As DataTable

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                              txtDireccion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()
        cmbTipoDoc.Value = "6"
        Limpiar()
        Activar()
        txtNroDoc.Select()


    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oDireccionFiscalService) = False Then
                oDireccionFiscalService.Close()
            End If
            If isClosed(oClienteService) = False Then
                oClienteService.Close()
            End If
            If isClosed(oProveedorService) = False Then
                oProveedorService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                             txtDireccion.KeyUp
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
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try

            If toBlank(cmbTipoDoc.Value) = "" Then
                MsgBox("Debe Ingresar el Tipo de documento", MsgBoxStyle.Information, "Información")
                cmbTipoDoc.BackColor = Color.Red
                cmbTipoDoc.Focus()
                Return False
            ElseIf txtNroDoc.Text.Trim.Length = 0 Then
                MsgBox("Debe de Ingresar Nro. de Documento", MsgBoxStyle.Information, "Información")
                txtNroDoc.Text = ""
                txtNroDoc.Focus()
                Return False
            ElseIf txtNombre.Text = "" And toBlank(cmbTipoDoc.Value) = "1" Then
                MsgBox("Debe Ingresar el Nombre", MsgBoxStyle.Information, "Información")
                txtNombre.BackColor = Color.Red
                txtNombre.Focus()
                Return False
            ElseIf txtApePat.Text = "" And toBlank(cmbTipoDoc.Value) = "1" Then
                MsgBox("Debe Ingresar el Apellido Paterno", MsgBoxStyle.Information, "Información")
                txtApePat.BackColor = Color.Red
                txtApePat.Focus()
                Return False
            ElseIf txtApeMat.Text = "" And toBlank(cmbTipoDoc.Value) = "1" Then
                MsgBox("Debe Ingresar el Apellido Materno", MsgBoxStyle.Information, "Información")
                txtApeMat.BackColor = Color.Red
                txtApeMat.Focus()
                Return False
            ElseIf toBlank(cmbTipoDoc.Value) = "6" And txtNroDoc.Text.Trim.Length <> 11 Then
                MsgBox("El R.U.C. es incorrecto...!", MsgBoxStyle.Information, "Información")
                txtNroDoc.BackColor = Color.Red
                txtNroDoc.Focus()
                Return False
            ElseIf oClienteService.BuscarRuc(toNull(Trim(txtNroDoc.Text)), Session.sCodEmp) = True And tipoBusqueda = 1 Then
                MsgBox("El Nro Documento " + txtNroDoc.Text + " ya existe...!", MsgBoxStyle.Information, "Información")
                'txtNroDoc.Text = ""
                'txtNroDoc.Focus()
                Limpiar()
                Activar()
                txtNroDoc.Select()
                Return False
            ElseIf oProveedorService.BuscarRuc(Session.sCodEmp, toNull(Trim(txtNroDoc.Text))) = True And tipoBusqueda = 2 Then
                MsgBox("El Nro Documento " + txtNroDoc.Text + " ya existe...!", MsgBoxStyle.Information, "Información")
                'txtNroDoc.Text = ""
                'txtNroDoc.Focus()
                Limpiar()
                Activar()
                txtNroDoc.Select()
                Return False
            ElseIf txtDireccion.Text.Trim.Length < 1 Then
                MsgBox("Debe Ingresar la Dirección", MsgBoxStyle.Information, "Información")
                txtDireccion.BackColor = Color.Red
                txtDireccion.Focus()
                Return False
            ElseIf txtUbigeo.Text.Trim.Length < 1 Then
                MsgBox("Debe Ingresar la Ubicacion Geografica de la Dirección", MsgBoxStyle.Information, "Información")
                txtUbigeo.BackColor = Color.Red
                btnUbigeo.Focus()
                Return False
            Else
                Return True
            End If


        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro1 As ClienteService.Cliente, ByVal registro2 As DireccionFiscalService.DireccionFiscal)
        Try

            IdCliente = oClienteService.Insertar(registro1)
            If IdCliente > 0 Then
                registro2.Cliente.IdCliente = IdCliente
                oDireccionFiscalService.Insertar(registro2)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try
            '=================================== TIPO DE DOCUMENTO ========================================
            dtTipoDoc = oClienteService.MostrarTipoDocumentoId.Tables(0)
            cmbTipoDoc.DataSource = dtTipoDoc
            cmbTipoDoc.DropDownList.DataMember = dtTipoDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.DropDownList.DisplayMember = dtTipoDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.DropDownList.ValueMember = dtTipoDoc.Columns("CodDoc").ToString
            cmbTipoDoc.DropDownList.Columns(0).DataMember = dtTipoDoc.Columns("CodDoc").ToString
            cmbTipoDoc.DropDownList.Columns(1).DataMember = dtTipoDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.SelectedIndex = 0
            dtTipoDoc = Nothing


        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
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

            If tipoBusqueda = 1 Then 'CLIENTES
                Dim registro As New ClienteService.Cliente
                Dim tipoContribuyente As New ClienteService.TipoContribuyente
                Dim sector As New ClienteService.SectorCliente
                Dim tipoCliente As New ClienteService.TipoCliente
                Dim Moneda As New ClienteService.Moneda
                Dim Empresa As New ClienteService.Empresa
                Dim MedioContacto As New ClienteService.TipoMedioContacto
                Dim tipodoc As New ClienteService.TipoDocumentoId

                registro.IdCliente = 0
                tipoContribuyente.IdTipoCon = IIf(cmbTipoDoc.Value = 6, 1, 2)
                registro.TipoContribuyente = tipoContribuyente
                tipodoc.CodDoc = cmbTipoDoc.Value
                registro.TipoDocumentoId = tipodoc
                registro.DesCli = IIf(tipoContribuyente.IdTipoCon = 1, toNull(txtDesCli.Text), Nothing)
                registro.AbrCli = toNull(txtAbrCli.Text)
                registro.RucCli = toNull(txtNroDoc.Text)
                registro.DueCli = Nothing
                registro.NumCta = Nothing
                registro.DiaPago = Nothing
                registro.HoraPago = Nothing
                registro.DniCli = Nothing
                registro.TelCli = Nothing
                registro.FaxCli = Nothing
                registro.Email = Nothing
                registro.UrlCli = Nothing
                registro.ObsCli = Nothing
                sector.CodSec = "008"
                registro.SectorCliente = sector
                registro.AprCli = False
                registro.ListaCli = False
                tipoCliente.IdTipoCliente = 3
                registro.TipoCliente = tipoCliente
                MedioContacto.IdMedio = 99
                registro.TipoMedioContacto = MedioContacto
                registro.Estado = 0
                registro.LimiteCredito = 0
                registro.Retenedor = False
                Moneda.CodMon = Nothing
                registro.Moneda = Moneda
                registro.Nombres = toNull(txtNombre.Text)
                registro.ApePat = toNull(txtApePat.Text)
                registro.ApeMat = toNull(txtApeMat.Text)
                registro.CodUsu = Session.sCodUsu
                Empresa.CodEmp = Session.sCodEmp
                registro.Empresa = Empresa


                Dim registro2 As New DireccionFiscalService.DireccionFiscal
                Dim cliente As New DireccionFiscalService.Cliente
                Dim ubigeo As New DireccionFiscalService.Ubigeo
                registro2.IdFiscal = 0
                cliente.IdCliente = toNull(IdCliente)
                registro2.Cliente = cliente
                registro2.Direccion = toNull(txtDireccion.Text)
                ubigeo.CodUbigeo = CodUbigeo
                registro2.Ubigeo = ubigeo
                registro2.Vigente = True
                registro2.DirIp = Session.sDirIp
                registro2.NomPc = Session.sNomPc
                registro2.CodUsu = Session.sCodUsu
                Insertar(registro, registro2)

            ElseIf tipoBusqueda = 2 'PROVEEDORES

                Dim registro As New ProveedorService.Proveedor
                Dim Rubro As New ProveedorService.RubroProveedor
                Dim CondicionPago As New ProveedorService.CondicionPagoProveedor
                Dim tipoContribuyente As New ProveedorService.TipoContribuyente
                Dim ubigeo As New ProveedorService.Ubigeo
                Dim empresa As New ProveedorService.Empresa
                Dim banco As New ProveedorService.Banco
                Dim moneda As New ProveedorService.Moneda
                Dim tipocuenta As New ProveedorService.TipoCuentaBanco
                Dim tipodoc As New ProveedorService.TipoDocumentoId
                Dim paisproveedor As New ProveedorService.PaisProveedor

                registro.IdProveedor = 0
                tipoContribuyente.IdTipoCon = IIf(cmbTipoDoc.Value = 6, 1, 2)
                registro.TipoContribuyente = tipoContribuyente
                tipodoc.CodDoc = cmbTipoDoc.Value
                registro.TipoDocumentoId = tipodoc
                registro.DesProv = IIf(tipoContribuyente.IdTipoCon = 1, toNull(txtDesCli.Text), Nothing)
                registro.DirProv = toNull(txtDireccion.Text)
                registro.AbrProv = toNull(txtAbrCli.Text)
                registro.RucProv = toNull(txtNroDoc.Text)
                CondicionPago.IdCondicion = 1
                registro.CondicionPagoProveedor = CondicionPago
                registro.DniProv = Nothing
                registro.Telefono = Nothing
                registro.Fax = Nothing
                registro.Email = Nothing
                registro.Url = Nothing
                registro.Observacion = Nothing
                paisproveedor.CodPais = "9589"
                registro.PaisProveedor = paisproveedor
                Rubro.IdRubro = 7
                registro.RubroProveedor = Rubro
                registro.Importacion = False
                registro.EmiteFacturaDigital = False
                ubigeo.CodUbigeo = CodUbigeo
                registro.Ubigeo = ubigeo
                registro.FecFinHomologa = Nothing
                registro.IdEstado = 0
                registro.Nombres = toNull(txtNombre.Text)
                registro.ApePat = toNull(txtApePat.Text)
                registro.ApeMat = toNull(txtApeMat.Text)
                registro.CodUsu = Session.sCodUsu
                registro.DirIp = Session.sDirIp
                empresa.CodEmp = Session.sCodEmp
                registro.Empresa = empresa
                registro.NomPc = Session.sNomPc

                InsertarProveedor(registro)

            End If

        End If
    End Sub

    Private Sub InsertarProveedor(ByVal registro As ProveedorService.Proveedor)
        Try

            IdProveedor = oProveedorService.Insertar(registro)
            If IdProveedor > 0 Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub



    Private Sub btnUbigeo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUbigeo.Click
        Dim frm As New frmBuscarUbigeo
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            CodUbigeo = frm.CodUbigeo
            txtUbigeo.BackColor = System.Drawing.SystemColors.Control
            txtUbigeo.Text = frm.Nombre
        End If
    End Sub

    Private Sub Activar()

        cmbTipoDoc.Enabled = True
        txtNroDoc.Enabled = True
        btnGuardar.Enabled = False
        btnConsultaSunat.Enabled = True
        btnLimpiar.Enabled = False
        btnUbigeo.Enabled = False
        txtDireccion.Enabled = False


    End Sub

    Private Sub Desactivar()

        cmbTipoDoc.Enabled = False
        txtNroDoc.Enabled = False
        btnConsultaSunat.Enabled = False
        btnLimpiar.Enabled = True
        btnGuardar.Enabled = True

    End Sub

    Private Sub Limpiar()

        txtDesCli.Text = ""
        txtNroDoc.Text = ""
        txtAbrCli.Text = ""
        txtNombre.Text = ""
        txtApePat.Text = ""
        txtApeMat.Text = ""
        txtDireccion.Text = ""
        txtUbigeo.Text = ""
        CodUbigeo = ""

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        Limpiar()
        Activar()
        txtNroDoc.Select()


    End Sub

    Private Sub btnConsultaSunat_Click(sender As Object, e As EventArgs) Handles btnConsultaSunat.Click


        ConsultarRucSunat()
        Desactivar()

        btnGuardar.Focus()

    End Sub



    Private Sub ConsultarRucSunat()


        If toBlank(cmbTipoDoc.Value) = "" Then
            MsgBox("Debe Ingresar el Tipo de documento del Cliente", MsgBoxStyle.Information, "Información")
            cmbTipoDoc.BackColor = Color.Red
            cmbTipoDoc.Focus()
            Return
        ElseIf txtNroDoc.Text.Trim.Length = 0 Then
            MsgBox("Debe de Ingresar Nro. de Documento", MsgBoxStyle.Information, "Información")
            txtNroDoc.Text = ""
            txtNroDoc.Focus()
            Return
        End If


        Try

            Dim cliente As New ClienteSunat()



            cliente = ConectarAPISUNAT.ConsultarRucSunat(cmbTipoDoc.Value, txtNroDoc.Value)

            If cliente.Respuesta Then
                txtNroDoc.Value = cliente.RucCli
                txtDesCli.Text = cliente.DesCli
                txtAbrCli.Text = cliente.AbrCli
                txtNombre.Text = cliente.Nombres
                txtApePat.Text = cliente.ApePat
                txtApeMat.Text = cliente.ApeMat
                txtDireccion.Text = cliente.Direccion
                CodUbigeo = cliente.CodUbigeo
                txtUbigeo.Text = IIf(cliente.NomDepartamento <> "", cliente.NomDepartamento + " - " + cliente.NomProvincia + " - " + cliente.NomDistrito, "")

                If txtDireccion.Text = "" Then
                    'CodUbigeo = "150101"
                    'txtDireccion.Text = "CASA"
                    'txtUbigeo.Text = "LIMA - LIMA - LIMA"
                    txtDireccion.Enabled = True
                    btnUbigeo.Enabled = True
                    txtDireccion.Select()
                Else
                    btnGuardar.Focus()

                End If


            Else
                MsgBox(cliente.Mensaje, "Error")
            End If

        Catch ex As Exception
            MsgBox("ERROR [INFO-007]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try




    End Sub


    Private Sub txtNroDoc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNroDoc.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then

            ConsultarRucSunat()
            Desactivar()

            btnGuardar.Focus()

        End If

    End Sub
End Class
