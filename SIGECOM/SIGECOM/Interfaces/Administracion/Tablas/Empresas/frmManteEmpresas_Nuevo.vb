Imports System.ServiceModel
Public Class frmManteEmpresas_Nuevo

    Private oSeguridadService As New EmpresaService.EmpresaServiceClient

    Private oSeguridadService1 As New LocacionService.LocacionServiceClient
    Private oSeguridad As New SerieDocumentoService.SerieDocumentoServiceClient

    Private dtSistemas As DataTable
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean ' = True                   'True: Edición      False: Vista
    Public editable As Boolean ' = True          'True: Editable     False: No Editable
    Public IdEncuesta As Integer
    Private dtDatos As DataTable
    Public CodEmp As String

    Private CodUbigeo As String
    Public IdProveedor As Integer

    Private DepartamentoC As String
    Private ProvinciaC As String
    Private DistritoC As String

    Private Sub frmManteEmpresas_Nuevo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmManteEmpresas_Nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If state_button Then    'Modificar            
            LimpiarCampos()
            ObtenerRegistro()
            desactivar()
            Me.Text = "Empresa " + Chr(34) + txtEmpresa.Text.ToString + Chr(34)
        Else 'Nuevo
            cbActivo.Checked = True
            txtEmpresa.Focus()
            LimpiarCampos()
            activar()
            Me.Size = New System.Drawing.Size(649, 563)
            Me.Text = "Registrar nueva Empresa"
            txtIgv.Text = "0"
        End If
    End Sub

    Private Sub LimpiarCampos()

        txtEmpresa.Text = ""
        txtAbvEmp.Text = ""
        txtDirEmp.Text = ""
        txtRucEmp.Text = ""
        txtUrbEmp.Text = ""
        cbActivo.Enabled = True
        txtCodEstablecimiento.Text = ""
        txtCodPais.Text = ""
        txtTelEmp.Text = ""
        txtFaxEmp.Text = ""
        txtWebEmp.Text = ""
        txtCorEmp.Text = ""
        txtIgv.Text = ""
        txtUsuarioSOL.Text = ""
        txtClaveSOL.Text = ""
        txtUsuarioOSE.Text = ""
        txtClaveOSE.Text = ""
        txtNomCert.Text = ""
        txtClaveCert.Text = ""
        txtCorEmisor.Text = ""
        txtClaveCorEmisor.Text = ""
        txtMailHost.Text = ""
        txtUrlAPI.Text = ""
        txtIDAPISunat.Text = ""
        txtClaveAPISunat.Text = ""
        CodUbigeo = ""
        IdProveedor = 0

    End Sub

    Private Sub activar()

        biEditarr.Enabled = False
        biDeshacerr.Enabled = True
        biGuardar.Enabled = True

        txtCodEmp.ReadOnly = IIf(state_button, True, False)
        txtCodEmp.BackColor = System.Drawing.SystemColors.Window
        txtEmpresa.ReadOnly = False
        txtEmpresa.BackColor = System.Drawing.SystemColors.Window
        txtAbvEmp.ReadOnly = False
        txtAbvEmp.BackColor = System.Drawing.SystemColors.Window
        txtDirEmp.ReadOnly = False
        txtDirEmp.BackColor = System.Drawing.SystemColors.Window
        txtRucEmp.ReadOnly = False
        txtRucEmp.BackColor = System.Drawing.SystemColors.Window
        cbActivo.Enabled = True
        txtUrbEmp.ReadOnly = False
        txtUrbEmp.BackColor = System.Drawing.SystemColors.Window
        'txtUbigeo.ReadOnly = False
        'txtUbigeo.BackColor = System.Drawing.SystemColors.Window
        btnUbigeo.Enabled = True
        txtCodEstablecimiento.ReadOnly = False
        txtCodEstablecimiento.BackColor = System.Drawing.SystemColors.Window
        txtCodPais.ReadOnly = False
        txtCodPais.BackColor = System.Drawing.SystemColors.Window

        txtTelEmp.ReadOnly = False
        txtTelEmp.BackColor = System.Drawing.SystemColors.Window
        txtFaxEmp.ReadOnly = False
        txtFaxEmp.BackColor = System.Drawing.SystemColors.Window
        txtWebEmp.ReadOnly = False
        txtWebEmp.BackColor = System.Drawing.SystemColors.Window
        txtCorEmp.ReadOnly = False
        txtCorEmp.BackColor = System.Drawing.SystemColors.Window
        txturldoc.ReadOnly = False
        txturldoc.BackColor = System.Drawing.SystemColors.Window
        txtIgv.ReadOnly = False
        txtIgv.BackColor = System.Drawing.SystemColors.Window
        txtIR.ReadOnly = False
        txtIR.BackColor = System.Drawing.SystemColors.Window
        txtOrden.ReadOnly = False
        txtOrden.BackColor = System.Drawing.SystemColors.Window

        cbAplicaOSE.Enabled = True
        txtUsuarioSOL.ReadOnly = False
        txtUsuarioSOL.BackColor = System.Drawing.SystemColors.Window
        txtClaveSOL.ReadOnly = False
        txtClaveSOL.BackColor = System.Drawing.SystemColors.Window
        txtUsuarioOSE.ReadOnly = False
        txtUsuarioOSE.BackColor = System.Drawing.SystemColors.Window
        txtClaveOSE.ReadOnly = False
        txtClaveOSE.BackColor = System.Drawing.SystemColors.Window
        txtNomCert.ReadOnly = False
        txtNomCert.BackColor = System.Drawing.SystemColors.Window
        txtClaveCert.ReadOnly = False
        txtClaveCert.BackColor = System.Drawing.SystemColors.Window
        txtCorEmisor.ReadOnly = False
        txtCorEmisor.BackColor = System.Drawing.SystemColors.Window
        txtClaveCorEmisor.ReadOnly = False
        txtClaveCorEmisor.BackColor = System.Drawing.SystemColors.Window
        txtMailHost.ReadOnly = False
        txtMailHost.BackColor = System.Drawing.SystemColors.Window
        txtUrlAPI.ReadOnly = False
        txtUrlAPI.BackColor = System.Drawing.SystemColors.Window
        txtIDAPISunat.ReadOnly = False
        txtIDAPISunat.BackColor = System.Drawing.SystemColors.Window
        txtClaveAPISunat.ReadOnly = False
        txtClaveAPISunat.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Private Sub desactivar()

        biEditarr.Enabled = True
        biDeshacerr.Enabled = False
        biGuardar.Enabled = False

        txtCodEmp.ReadOnly = True
        txtCodEmp.BackColor = System.Drawing.SystemColors.Control
        txtEmpresa.ReadOnly = True
        txtEmpresa.BackColor = System.Drawing.SystemColors.Control
        txtAbvEmp.ReadOnly = True
        txtAbvEmp.BackColor = System.Drawing.SystemColors.Control
        txtDirEmp.ReadOnly = True
        txtDirEmp.BackColor = System.Drawing.SystemColors.Control
        txtRucEmp.ReadOnly = True
        txtRucEmp.BackColor = System.Drawing.SystemColors.Control
        cbActivo.Enabled = False
        txtUrbEmp.ReadOnly = True
        txtUrbEmp.BackColor = System.Drawing.SystemColors.Control
        'txtUbigeo.ReadOnly = True
        'txtUbigeo.BackColor = System.Drawing.SystemColors.Control
        btnUbigeo.Enabled = False
        txtCodEstablecimiento.ReadOnly = True
        txtCodEstablecimiento.BackColor = System.Drawing.SystemColors.Control
        txtCodPais.ReadOnly = True
        txtCodPais.BackColor = System.Drawing.SystemColors.Control

        txtTelEmp.ReadOnly = True
        txtTelEmp.BackColor = System.Drawing.SystemColors.Control
        txtFaxEmp.ReadOnly = True
        txtFaxEmp.BackColor = System.Drawing.SystemColors.Control
        txtWebEmp.ReadOnly = True
        txtWebEmp.BackColor = System.Drawing.SystemColors.Control
        txturldoc.ReadOnly = True
        txturldoc.BackColor = System.Drawing.SystemColors.Control
        txtCorEmp.ReadOnly = True
        txtCorEmp.BackColor = System.Drawing.SystemColors.Control
        txtIgv.ReadOnly = True
        txtIgv.BackColor = System.Drawing.SystemColors.Control
        txtIR.ReadOnly = True
        txtIR.BackColor = System.Drawing.SystemColors.Control
        txtOrden.ReadOnly = True
        txtOrden.BackColor = System.Drawing.SystemColors.Control

        cbAplicaOSE.Enabled = False
        txtUsuarioSOL.ReadOnly = True
        txtUsuarioSOL.BackColor = System.Drawing.SystemColors.Control
        txtClaveSOL.ReadOnly = True
        txtClaveSOL.BackColor = System.Drawing.SystemColors.Control
        txtUsuarioOSE.ReadOnly = True
        txtUsuarioOSE.BackColor = System.Drawing.SystemColors.Control
        txtClaveOSE.ReadOnly = True
        txtClaveOSE.BackColor = System.Drawing.SystemColors.Control
        txtNomCert.ReadOnly = True
        txtNomCert.BackColor = System.Drawing.SystemColors.Control
        txtClaveCert.ReadOnly = True
        txtClaveCert.BackColor = System.Drawing.SystemColors.Control
        txtCorEmisor.ReadOnly = True
        txtCorEmisor.BackColor = System.Drawing.SystemColors.Control
        txtClaveCorEmisor.ReadOnly = True
        txtClaveCorEmisor.BackColor = System.Drawing.SystemColors.Control
        txtMailHost.ReadOnly = True
        txtMailHost.BackColor = System.Drawing.SystemColors.Control
        txtUrlAPI.ReadOnly = True
        txtUrlAPI.BackColor = System.Drawing.SystemColors.Control
        txtIDAPISunat.ReadOnly = True
        txtIDAPISunat.BackColor = System.Drawing.SystemColors.Control
        txtClaveAPISunat.ReadOnly = True
        txtClaveAPISunat.BackColor = System.Drawing.SystemColors.Control


    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As EmpresaService.Empresa
            registro = oSeguridadService.Obtener(CodEmp)

            txtOrden.Text = registro.Orden
            txtCodEmp.Text = registro.CodEmp
            txtEmpresa.Text = registro.DesEmp
            txtAbvEmp.Text = registro.AbrEmp
            txtDirEmp.Text = registro.DirEmp
            txtRucEmp.Text = registro.RucEmp
            cbActivo.Checked = registro.Activo
            txtUrbEmp.Text = registro.Urbanizacion
            CodUbigeo = registro.Ubigeo.CodUbigeo
            txtUbigeo.Text = registro.Ubigeo.Departamento.NomDpto & " - " & toBlank(registro.Ubigeo.Provincia.NomProv) & " - " & toBlank(registro.Ubigeo.Distrito.NomDist)

            'DepartamentoC = registro.Ubigeo.Departamento.CodDpto
            'ProvinciaC = registro.Ubigeo.Provincia.CodProv
            'DistritoC = registro.Ubigeo.Distrito.CodDist

            'btnUbigeo.Enabled = False
            txtCodEstablecimiento.Text = registro.CodEstablecimiento
            txtCodPais.Text = registro.CodPais

            txtTelEmp.Text = registro.TelEmp
            txtFaxEmp.Text = registro.FaxEmp
            txtWebEmp.Text = registro.WebEmp
            txtCorEmp.Text = registro.CorEmp
            txturldoc.Text = registro.UrlConsultaDoc
            txtIgv.Text = registro.Igv
            txtIR.Text = registro.IR

            cbAplicaOSE.Checked = registro.AplicaOSE
            txtUsuarioSOL.Text = registro.UsuarioSOL
            txtClaveSOL.Text = registro.ClaveSOL
            txtUsuarioOSE.Text = registro.UsuarioOSE
            txtClaveOSE.Text = registro.ClaveOSE
            txtNomCert.Text = registro.NombreCertificado
            txtClaveCert.Text = registro.ClaveCertificado
            txtCorEmisor.Text = registro.CorreoEmisor
            txtClaveCorEmisor.Text = registro.ClaveCorreoEmisor
            txtMailHost.Text = registro.MailHost

            txtUrlAPI.Text = registro.UrlApiSunat
            txtIDAPISunat.Text = registro.IdApiSunat
            txtClaveAPISunat.Text = registro.ClaveApiSunat

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnUbigeo_Click(sender As Object, e As EventArgs) Handles btnUbigeo.Click
        Dim frm As New frmBuscarUbigeo
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            CodUbigeo = frm.CodUbigeo
            DepartamentoC = frm.Departamento
            ProvinciaC = frm.Provincia
            DistritoC = frm.Distrito
            txtUbigeo.BackColor = System.Drawing.SystemColors.Control
            txtUbigeo.Text = frm.Nombre
        End If
        txtUbigeo.Select()
    End Sub

    Private Sub frmManteEmpresas_Nuevo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            biCerrar_Click(sender, e)
        End If
    End Sub

    Private Sub biCerrar_Click(sender As Object, e As EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biDeshacerr_Click(sender As Object, e As EventArgs) Handles biDeshacerr.Click
        If MsgBox("¿Desea Deshacer los Cambios Realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub biEditarr_Click(sender As Object, e As EventArgs) Handles biEditarr.Click
        activar()
    End Sub

    Private Sub biGuardar_Click(sender As Object, e As EventArgs) Handles biGuardar.Click

        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                 And ValidaCampos() Then

                Dim registro As New EmpresaService.Empresa
                Dim ubigeo As New EmpresaService.Ubigeo
                Dim departamento As New EmpresaService.Departamento
                Dim provincia As New EmpresaService.Provincia
                Dim distrito As New EmpresaService.Distrito
                'Dim proveedor As New EmpresaService.Proveedor

                registro.CodEmp = txtCodEmp.Text
                registro.Activo = cbActivo.Checked
                registro.DesEmp = txtEmpresa.Text
                registro.RucEmp = txtRucEmp.Text
                registro.AbrEmp = txtAbvEmp.Text

                registro.DirEmp = txtDirEmp.Text
                registro.Urbanizacion = txtUrbEmp.Text

                ubigeo.CodUbigeo = CodUbigeo
                'departamento.CodDpto = DepartamentoC
                'ubigeo.Departamento = departamento
                'provincia.CodProv = ProvinciaC
                'ubigeo.Provincia = provincia
                'distrito.CodDist = DistritoC
                'ubigeo.Distrito = distrito

                registro.Ubigeo = ubigeo

                registro.CodEstablecimiento = txtCodEstablecimiento.Text
                registro.CodPais = txtCodPais.Text
                registro.TelEmp = txtTelEmp.Text
                registro.FaxEmp = txtFaxEmp.Text
                registro.WebEmp = txtWebEmp.Text
                registro.CorEmp = txtCorEmp.Text
                registro.UrlConsultaDoc = txturldoc.Text

                'registro.IdProvedor =
                registro.Orden = txtOrden.Text
                registro.Igv = txtIgv.Text
                registro.IR = txtIR.Text
                registro.AplicaOSE = cbAplicaOSE.Checked
                registro.UsuarioSOL = txtUsuarioSOL.Text
                registro.ClaveSOL = txtClaveSOL.Text
                registro.UsuarioOSE = txtUsuarioOSE.Text
                registro.ClaveOSE = txtClaveOSE.Text
                registro.NombreCertificado = txtNomCert.Text
                registro.ClaveCertificado = txtClaveCert.Text
                registro.CorreoEmisor = txtCorEmisor.Text
                registro.ClaveCorreoEmisor = txtClaveCorEmisor.Text
                registro.MailHost = txtMailHost.Text

                registro.UrlApiSunat = txtUrlAPI.Text
                registro.IdApiSunat = txtIDAPISunat.Text
                registro.ClaveApiSunat = txtClaveAPISunat.Text

                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                        'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DATOS" + ex.Message)
        End Try

    End Sub

    Private Function ValidaCampos() As Boolean
        Try

            If toBlank(txtCodEmp.Text) = "" Then
                MsgBox("Debe Ingresar el Codigo de la Empresa", MsgBoxStyle.Information, "Información")
                txtCodEmp.BackColor = Color.Red
                txtCodEmp.Focus()
                Return False
            ElseIf txtOrden.Text = 0 Then
                MsgBox("Debe Ingresar el Orden de la Empresa", MsgBoxStyle.Information, "Información")
                txtOrden.BackColor = Color.Red
                txtOrden.Focus()
                Return False
            ElseIf toBlank(txtEmpresa.Text) = "" Then
                MsgBox("Debe Ingresar la Descripción de la Empresa", MsgBoxStyle.Information, "Información")
                txtEmpresa.BackColor = Color.Red
                txtEmpresa.Focus()
                Return False
            ElseIf toBlank(txtRucEmp.Text) = "" Then
                MsgBox("Debe Ingresar el Ruc de la Empresa", MsgBoxStyle.Information, "Información")
                txtRucEmp.BackColor = Color.Red
                txtRucEmp.Focus()
                Return False
            ElseIf toBlank(txtDirEmp.Text) = "" Then
                MsgBox("Debe Ingresar la Dirección de la Empresa", MsgBoxStyle.Information, "Información")
                txtRucEmp.BackColor = Color.Red
                txtRucEmp.Focus()
                Return False
            ElseIf toBlank(txtUbigeo.Text) = "" Then
                MsgBox("Debe Ingresar el Ubigeo de la Empresa", MsgBoxStyle.Information, "Información")
                txtRucEmp.BackColor = Color.Red
                txtRucEmp.Focus()
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function


    Private Sub Insertar(ByVal registro As EmpresaService.Empresa)
        Try
            Dim estado_process As Boolean
            estado_process = oSeguridadService.Insertar(registro)
            type_process = "insert"
            If estado_process Then
                MsgBox("Se insertó la empresa correctamente")
                CodEmp = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EMPRESA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As EmpresaService.Empresa)
        Try
            Dim estado_process As Boolean
            estado_process = oSeguridadService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                ObtenerRegistro()
                desactivar()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LA EMPRESA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class