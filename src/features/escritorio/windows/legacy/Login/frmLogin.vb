Imports System.ServiceModel
Imports System.Net
Imports System.Net.Sockets
Imports System.Management
Imports System.IO

Public Class frmLogin
    Private ObjSeguridad As New SeguridadService.SeguridadClient
    Private ObjMaestro As New MaestroService.MaestroClient
    Private oEncuestaSistema As New EncuestaService.EncuestaServiceClient
    Private oSeguridadTI As New LicenciaService.LicenciaServiceSoapClient
    Dim user As New SeguridadService.Usuario
    Dim Intentos As Integer = 0
    Dim EncuestaActiva As Integer


    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        '0 = No existe usuario registrado en la base de datos
        '1 = El usuario esta registrado pero no tiene acceso al sistema mencionado
        '2 = Tiene acceso al sistema 
        '3 = Tiene acceso al sistema y tambien puede ingresar tipo de cambio

        Try


            ValidarEquipo(Trim(txtUsuario.Text))



            Dim Opcion As Int16 = ObjSeguridad.ValidarAccesoUsuario(Trim(txtUsuario.Text), Trim(txtClave.Text), 1)
            Dim NomPc As String = Dns.GetHostName
            'Dim DirIp As IPAddress = Dns.GetHostEntry(My.Computer.Name).AddressList.FirstOrDefault(Function(f) f.AddressFamily.Equals(AddressFamily.InterNetwork))
            Dim DirIp = New List(Of IPAddress)(Dns.GetHostEntry(NomPc).AddressList).Find(Function(f) f.AddressFamily = Sockets.AddressFamily.InterNetwork)

            Session.sNomPc = NomPc
            Session.sDirIp = DirIp.ToString

            Dim Vigencia As Boolean
            Dim Desactivar As Boolean
            Dim BuscarUsuario As Boolean
            Dim IdPersona As Integer
            Dim empresa As New SeguridadService.Empresa

            BuscarUsuario = ObjSeguridad.BuscarUsuario(txtUsuario.Text)


            If Opcion = 0 Or Opcion = 1 Then
                Intentos = Intentos + 1
            End If

            If Intentos = 4 Then
                If BuscarUsuario = True Then
                    Desactivar = ObjSeguridad.DesactivarUsuario(txtUsuario.Text, Session.sNomPc, Session.sDirIp)
                    MsgBox("Usted es un intruso." & Environment.NewLine &
                           "Su cuenta se encuentra Bloqueada." & Environment.NewLine &
                           "Comunicarse con el Administrador de Sistemas.", MsgBoxStyle.Information, "Alerta")
                End If
                Me.Close()
            End If

            If BuscarUsuario = True Then
                Vigencia = ObjSeguridad.BuscarVigencia(txtUsuario.Text)
                If Vigencia = True Then
                    Select Case Opcion
                        Case 0
                            MsgBox("No esta registrado el Usuario, Verifique......", MsgBoxStyle.Information, "No Existe")
                            txtUsuario.Select()
                        Case 1
                            MsgBox("Este usuario no tiene acceso a este Sistema" & Chr(13) & "Comunicarse con el Administrador del Sistema.", MsgBoxStyle.Information, "No Tiene Acceso")
                            txtUsuario.Select()
                        Case 2
                            If txtTipoCambio.Text > 0 Then

                                Session.sCodUsu = txtUsuario.Text
                                user = ObjSeguridad.MostrarUsuarioPorCodigo(Session.sCodUsu)
                                IdPersona = user.Persona.IdPer

                                Dim frm As New frmEmpresas
                                If ObjSeguridad.AccesoMultiEmpresa(Session.sCodUsu) Then
                                    frm.CodUsu = txtUsuario.Text
                                    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                                        Session.sCodEmp = frm.CodEmp
                                        Session.sDesEmp = ObjMaestro.MostrarDato("Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp)
                                    End If
                                Else
                                    Session.sCodEmp = ObjSeguridad.ObtenerCodEmp(Session.sCodUsu)
                                    Session.sDesEmp = ObjMaestro.MostrarDato("Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp)
                                End If

                                '///////OBTENER DATOS SUNAT////////
                                empresa = ObjSeguridad.ObtenerEmpresa(Session.sCodEmp)
                                Session.sUsuarioSunat = empresa.UsuarioSOL
                                Session.sClaveSunat = empresa.ClaveSOL
                                Session.sNombreCertificado = empresa.NombreCertificado
                                Session.sClaveCertificado = empresa.ClaveCertificado
                                Session.sRucEmp = empresa.RucEmp
                                Session.sCodUbigeo = empresa.Ubigeo.CodUbigeo
                                Session.sDireccion = empresa.DirEmp
                                Session.sDepartamento = empresa.Ubigeo.Departamento.NomDpto
                                Session.sProvincia = empresa.Ubigeo.Provincia.NomProv
                                Session.sDistrito = empresa.Ubigeo.Distrito.NomDist
                                Session.sIGV = empresa.Igv
                                Session.sUsuarioOSE = empresa.UsuarioOSE
                                Session.sClaveOSE = empresa.ClaveOSE
                                Session.sAplicaOSE = empresa.AplicaOSE
                                Session.sCorreoEmisor = empresa.CorreoEmisor
                                Session.sClaveCorreoEmisor = empresa.ClaveCorreoEmisor
                                Session.sMailHost = empresa.MailHost
                                Session.sUrlApiSunat = empresa.UrlApiSunat
                                Session.sIdApiSunat = empresa.IdApiSunat
                                Session.sClaveApiSunat = empresa.ClaveApiSunat
                                'Session.sLogo = empresa.Logo
                                '//////////////////////////////////


                                'Finalizar movido

                                EncuestaActiva = oEncuestaSistema.MostrarVigente(1)
                                Dim frmEncuesta As New frmResultadosEncuestaSis_Nuevo

                                If user.Seteo = False Then
                                    Session.sFecha = cbFecha.Value
                                    Session.sTipCam = txtTipoCambio.Text
                                    If frm.Salir = False Then
                                        'Agregado para Encuesta

                                        If EncuestaActiva <> 0 Then
                                            Me.Hide()
                                            'If oEncuestaSistema.BuscarResultado(1, EncuestaActiva, IdPersona) = False Then
                                            If oEncuestaSistema.BuscarVigenteUsuario(EncuestaActiva, Session.sCodUsu) Then
                                                If frmEncuesta.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                                                    MDIPrincipal.Show()
                                                Else
                                                    Me.Close()
                                                End If
                                            Else
                                                MDIPrincipal.Show()

                                            End If

                                            'Agregado para Encuesta
                                            'frmResultadosEncuestaSis_Nuevo.Show()
                                            'MDIPrincipal.Show()
                                        Else
                                            MDIPrincipal.Show()
                                        End If
                                    End If
                                Else
                                    If frm.Salir = False Then
                                        If frmCambioClave.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                                            Me.Close()
                                        End If
                                    Else
                                        Me.Close()
                                    End If

                                End If

                                Finalizar()
                            Else
                                MsgBox("No Existe Tipo de Cambio para esta fecha, no puede ingresar.", MsgBoxStyle.Information, "Tipo de Cambio en Cero")
                                txtTipoCambio.Select()
                            End If

                        Case 3

                            If txtTipoCambio.Text > 0 Then
                                Session.sCodUsu = txtUsuario.Text
                                user = ObjSeguridad.MostrarUsuarioPorCodigo(Session.sCodUsu)
                                IdPersona = user.Persona.IdPer

                                Dim frm As New frmEmpresas
                                If ObjSeguridad.AccesoMultiEmpresa(Session.sCodUsu) Then
                                    frm.CodUsu = txtUsuario.Text
                                    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                                        Session.sCodEmp = frm.CodEmp
                                        Session.sDesEmp = ObjMaestro.MostrarDato("Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp)
                                    End If
                                Else
                                    Session.sCodEmp = ObjSeguridad.ObtenerCodEmp(Session.sCodUsu)
                                    Session.sDesEmp = ObjMaestro.MostrarDato("Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp)

                                End If

                                '///////OBTENER DATOS SUNAT////////
                                empresa = ObjSeguridad.ObtenerEmpresa(Session.sCodEmp)
                                Session.sUsuarioSunat = empresa.UsuarioSOL
                                Session.sClaveSunat = empresa.ClaveSOL
                                Session.sNombreCertificado = empresa.NombreCertificado
                                Session.sClaveCertificado = empresa.ClaveCertificado
                                Session.sRucEmp = empresa.RucEmp
                                Session.sCodUbigeo = empresa.Ubigeo.CodUbigeo
                                Session.sDireccion = empresa.DirEmp
                                Session.sDepartamento = empresa.Ubigeo.Departamento.NomDpto
                                Session.sProvincia = empresa.Ubigeo.Provincia.NomProv
                                Session.sDistrito = empresa.Ubigeo.Distrito.NomDist
                                Session.sIGV = empresa.Igv
                                Session.sUsuarioOSE = empresa.UsuarioOSE
                                Session.sClaveOSE = empresa.ClaveOSE
                                Session.sAplicaOSE = empresa.AplicaOSE
                                Session.sCorreoEmisor = empresa.CorreoEmisor
                                Session.sClaveCorreoEmisor = empresa.ClaveCorreoEmisor
                                Session.sMailHost = empresa.MailHost
                                Session.sUrlApiSunat = empresa.UrlApiSunat
                                Session.sIdApiSunat = empresa.IdApiSunat
                                Session.sClaveApiSunat = empresa.ClaveApiSunat
                                'Session.sLogo = empresa.Logo
                                '//////////////////////////////////


                                'Finalizar

                                EncuestaActiva = oEncuestaSistema.MostrarVigente(1)
                                Dim frmEncuesta As New frmResultadosEncuestaSis_Nuevo

                                If user.Seteo = False Then
                                    Session.sFecha = cbFecha.Value
                                    Session.sTipCam = txtTipoCambio.Text
                                    If frm.Salir = False Then
                                        'Agregado para Encuesta

                                        If EncuestaActiva <> 0 Then
                                            Me.Hide()
                                            'If oEncuestaSistema.BuscarResultado(1, EncuestaActiva, IdPersona) = False Then
                                            If oEncuestaSistema.BuscarVigenteUsuario(EncuestaActiva, Session.sCodUsu) Then
                                                If frmEncuesta.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                                                    MDIPrincipal.Show()
                                                Else
                                                    Me.Close()
                                                End If
                                            Else
                                                MDIPrincipal.Show()

                                            End If

                                            'Agregado para Encuesta
                                            'frmResultadosEncuestaSis_Nuevo.Show()
                                            'MDIPrincipal.Show()
                                        Else
                                            MDIPrincipal.Show()
                                        End If
                                    End If
                                Else
                                    If frm.Salir = False Then
                                        If frmCambioClave.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                                            Me.Close()
                                        End If
                                    Else
                                        Me.Close()
                                    End If

                                End If

                                Finalizar()
                            Else
                                Session.sCodUsu = txtUsuario.Text
                                Session.sFecha = cbFecha.Value

                                Dim frm As New frmEmpresas
                                If ObjSeguridad.AccesoMultiEmpresa(Session.sCodUsu) Then
                                    frm.CodUsu = txtUsuario.Text
                                    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                                        Session.sCodEmp = frm.CodEmp
                                        Session.sDesEmp = ObjMaestro.MostrarDato("Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp)
                                    End If
                                Else
                                    Session.sCodEmp = ObjSeguridad.ObtenerCodEmp(Session.sCodUsu)
                                    Session.sDesEmp = ObjMaestro.MostrarDato("Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp)
                                End If

                                '///////OBTENER DATOS SUNAT////////
                                empresa = ObjSeguridad.ObtenerEmpresa(Session.sCodEmp)
                                Session.sUsuarioSunat = empresa.UsuarioSOL
                                Session.sClaveSunat = empresa.ClaveSOL
                                Session.sNombreCertificado = empresa.NombreCertificado
                                Session.sClaveCertificado = empresa.ClaveCertificado
                                Session.sRucEmp = empresa.RucEmp
                                Session.sCodUbigeo = empresa.Ubigeo.CodUbigeo
                                Session.sDireccion = empresa.DirEmp
                                Session.sDepartamento = empresa.Ubigeo.Departamento.NomDpto
                                Session.sProvincia = empresa.Ubigeo.Provincia.NomProv
                                Session.sDistrito = empresa.Ubigeo.Distrito.NomDist
                                Session.sIGV = empresa.Igv
                                Session.sUsuarioOSE = empresa.UsuarioOSE
                                Session.sClaveOSE = empresa.ClaveOSE
                                Session.sAplicaOSE = empresa.AplicaOSE
                                Session.sCorreoEmisor = empresa.CorreoEmisor
                                Session.sClaveCorreoEmisor = empresa.ClaveCorreoEmisor
                                Session.sMailHost = empresa.MailHost
                                Session.sUrlApiSunat = empresa.UrlApiSunat
                                Session.sIdApiSunat = empresa.IdApiSunat
                                Session.sClaveApiSunat = empresa.ClaveApiSunat
                                'Session.sLogo = empresa.Logo
                                '//////////////////////////////////


                                Finalizar()
                                If frm.Salir = False Then
                                    If frmTipoCambio.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                                        Me.Close()
                                    End If
                                Else
                                    Me.Close()
                                End If

                            End If

                    End Select

                Else
                    MsgBox("Su cuenta se encuentra Bloqueada." & Environment.NewLine &
                           "Comunicarse con el Administrador de Sistemas.", MsgBoxStyle.Information, "Alerta")
                End If

            Else
                MsgBox("No esta registrado el Usuario, Verifique......", MsgBoxStyle.Information, "No Existe")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Acceso")
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Finalizar()
        Me.Close()
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cbFecha.Value = Today
            txtTipoCambio.Text = ObjSeguridad.MostrarTipoCambio("US", Today)
            txtUsuario.Select()

            '///////////VALIDAR VERSION DEL SISTEMA////////////
            If ObjSeguridad.BuscarVersion(1, Application.ProductVersion.ToString) = False Then
                MsgBox("Existe una nueva versión, actualice el sistema.", MsgBoxStyle.Information, "Sistema Desactualizado")
                Finalizar()
                Close()
            End If
            '//////////////////////////////////////////////////

            '///////////VALIDAR VIGENCIA DEL SISTEMA////////////
            If oSeguridadTI.ValidarLicencia("05") = False Then
                MsgBox("La empresa no tiene licencia para usar el Sistema, comunicarse con la Empresa responsable", MsgBoxStyle.Information, "Lo Siento")
                Finalizar()
                Close()
                System.Diagnostics.Process.Start("WELCOMESISTECK.EXE")
                'BorrarCarpeta()
                'Dim ruta As String = System.AppDomain.CurrentDomain.BaseDirectory & "Inicio\WELCOMESISTECK.exe"
                'Shell(ruta, AppWinStyle.NormalFocus)

            End If
            '//////////////////////////////////////////////////




        Catch ex As CommunicationException
            MsgBox("No hay Conexión, Comuniquese con el Departamento de Sistemas", MsgBoxStyle.Critical, "Error de Comunicacion")
            Finalizar()
            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Datos")
        End Try

    End Sub

    Public Function BorrarCarpeta() As Boolean

        'Dim ruta = New DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName
        Dim ruta As String = My.Application.Info.DirectoryPath

        If Directory.Exists(ruta) Then
            My.Computer.FileSystem.DeleteDirectory(ruta, FileIO.DeleteDirectoryOption.DeleteAllContents)
            'Directory.Delete(ruta)
            'Else
            '    'Es archivo
            '    My.Computer.FileSystem.DeleteFile(ruta)
            '    'IO.File.Delete(ruta)
        End If

    End Function


    Private Sub Finalizar()
        Try
            ObjSeguridad.Close()
            ObjMaestro.Close()
            oEncuestaSistema.Close()
            oSeguridadTI.Close()
        Catch ex As TimeoutException
            ObjSeguridad.Abort()
            ObjMaestro.Abort()
            oEncuestaSistema.Abort()
            oSeguridadTI.Abort()
        Catch ex As CommunicationException
            ObjSeguridad.Abort()
            ObjMaestro.Abort()
            oEncuestaSistema.Abort()
            oSeguridadTI.Abort()
        End Try
        'Me.Dispose(True)
        Me.Hide()

    End Sub

    Private Sub cbFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFecha.ValueChanged
        Try
            txtTipoCambio.Text = ObjSeguridad.MostrarTipoCambio("US", cbFecha.Value)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Acceso")
        End Try

    End Sub

    Private Sub txtClave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClave.KeyPress
        Select Case e.KeyChar
            Case ChrW(Keys.Enter)
                cbFecha.Focus()
                e.Handled = True
            Case ChrW(Keys.Back)
                If txtClave.Text = "" Then
                    txtUsuario.Focus()
                End If
        End Select
    End Sub

    Private Sub txtUsuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsuario.KeyPress
        Select Case e.KeyChar
            Case ChrW(Keys.Enter)
                txtClave.Focus()
                e.Handled = True
        End Select
    End Sub
    Private Sub cbFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbFecha.KeyPress
        Select Case e.KeyChar
            Case ChrW(Keys.Enter)
                txtTipoCambio.Focus()
                e.Handled = True
            Case ChrW(Keys.Back)
                txtClave.Focus()
        End Select
    End Sub

    Private Sub txtTipoCambio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipoCambio.KeyPress
        Select Case e.KeyChar
            Case ChrW(Keys.Enter)
                OK.Select()
                e.Handled = True
            Case ChrW(Keys.Back)
                cbFecha.Select()
        End Select
    End Sub

    Sub ValidarEquipo(pCodUsu As String)

        If ObjSeguridad.LibreLicencia(pCodUsu) = False Then
            ':::Obtenemos el serial de la Board
            'Dim serial As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_BaseBoard") 
            'Dim serialBoard As String = ""
            'For Each serialB As ManagementObject In serial.Get()
            '    serialBoard = (serialB.GetPropertyValue("SerialNumber").ToString)
            'Next

            Dim serialBoard As String = ""
            Try
                Dim serial As ManagementObjectCollection = New ManagementClass("Win32_BaseBoard").GetInstances()
                Dim mbEnum As ManagementObjectCollection.ManagementObjectEnumerator = serial.GetEnumerator()
                mbEnum.MoveNext()
                serialBoard = DirectCast(mbEnum.Current, ManagementObject).Properties("SerialNumber").Value.ToString()

                Select Case Trim(serialBoard)
                    Case "To be filled by O.E.M."
                        serialBoard = "Vacio"
                    Case "Default string"
                        serialBoard = "Vacio"
                    Case "*"
                        serialBoard = "Vacio"
                    Case ""
                        serialBoard = "Vacio"
                End Select

            Catch ex As Exception
                serialBoard = "Vacio"
            End Try

            Select Case serialBoard
                Case "Vacio"
                    Dim nomusu As String
                    nomusu = System.Security.Principal.WindowsIdentity.GetCurrent.Name
                    If ObjSeguridad.BuscarUsuarioPC(pCodUsu, nomusu) = False Then
                        MsgBox("Este Usuario no esta habilitado para usar en este equipo el Sistema, Comunicarse con el Administrador del Sistema", MsgBoxStyle.Information, "Alerta")
                        Me.Close()
                    End If
                Case Else
                    If ObjSeguridad.BuscarEquipo(pCodUsu, serialBoard) = False Then
                        MsgBox("Este Usuario no esta habilitado para usar en este equipo el Sistema, Comunicarse con el Administrador del Sistema", MsgBoxStyle.Information, "Alerta")
                        Me.Close()
                    End If
            End Select


        End If

    End Sub



    Private Sub lblCambioClave_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblCambioClave.LinkClicked
        Try
            Dim NomPc As String = Dns.GetHostName
            Dim DirIp = New List(Of IPAddress)(Dns.GetHostEntry(NomPc).AddressList).Find(Function(f) f.AddressFamily = Sockets.AddressFamily.InterNetwork)
            Dim frm As New frmRecuperaClave
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Dim usuarioCambio As String = frm.txtUsusarioActual.Text
                Dim correo As String = ObjSeguridad.ObtenerCorreo(usuarioCambio)
                If ObjSeguridad.BuscarUsuario(usuarioCambio) Then
                    ObjSeguridad.RecuperarClave(usuarioCambio, NomPc, DirIp.ToString)
                    MsgBox("Su nueva clave a sido enviada a su correo electronico registrado " + correo, MsgBoxStyle.Information, "Clave Recuperada")
                    txtUsuario.Text = usuarioCambio
                    txtClave.Select()
                Else
                    MsgBox("El usuario ingresado no esta regitrado en nuestro sistema, verifique!!!!!!", MsgBoxStyle.Information, "Clave Recuperada")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")

        End Try


    End Sub
End Class
