Imports System.ServiceModel
Imports System.Xml
Imports System.IO
Imports System.Net.Mail

Public Class frmCotizacion_EnviarCorreo

    Private oUsuarioClienteService As New UsuarioClienteService.UsuarioClienteServiceClient

    Public NumDoc As String
    Public IdCliente As Integer

    Private Sub frmCotizacion_EnviarCorreo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oUsuarioClienteService.Close()
        Catch ex As TimeoutException
            oUsuarioClienteService.Abort()
        Catch ex As CommunicationException
            oUsuarioClienteService.Abort()
        End Try
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub frmCotizacion_EnviarCorreo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub frmCotizacion_EnviarCorreo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ListarArchivos()
        CargarCorreo()

    End Sub

    Private Sub ListarArchivos()
        Try
            Dim d As New DirectoryInfo("D:\Documentos_Electronicos\Cotizaciones\" & NumDoc)

            Dim row As DataRow
            Dim dtArchivos As DataTable

            Dim dtCopia As New DataTable("tabla")

            dtCopia.Columns.Add(New DataColumn("Nombre", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Tamano", Type.GetType("System.String")))

            dtCopia.Rows.Add(New Object() {"Nombre", "Tamano"})

            dtArchivos = dtCopia.Copy
            dtArchivos.Clear()

            For Each f As FileInfo In d.GetFiles
                row = dtArchivos.NewRow
                row(0) = f.Name
                row(1) = CInt(f.Length / 1024) & " kb."
                'If f.Extension <> ".png" And f.Extension <> ".zip" And Mid(f.Name, 1, 1) <> "R" Then
                If f.Extension <> ".png" And f.Extension <> ".zip" Then
                    dtArchivos.Rows.Add(row)
                End If
            Next
            dgvArchivosDirectorio.DataSource = dtArchivos

        Catch ex As Exception
            MsgBox("Error al listar los elementos adjuntos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub CargarCorreo()

        Try
            Dim buscarusuario As Boolean

            Dim correodestino As String = ""
            buscarusuario = oUsuarioClienteService.BuscarUsuario(IdCliente)

            If buscarusuario Then
                correodestino = oUsuarioClienteService.ObtenerCorreo(IdCliente)
            Else
                'MsgBox("Se usuario no existe", MsgBoxStyle.Information)
            End If

            txtDe.Text = Session.sCorreoEmisor  '"facturacion@ddperu.com.pe"
            txtPara.Text = correodestino
            txtAsunto.Text = Session.sDesEmp & " - Cotizacion: " & NumDoc '"DETROIT DIESEL MTU PERU SAC - Factura Electronica: " & Documento
            txtMensaje.Text = "Envio de Cotizacion c/Adjunto pdf" & Environment.NewLine & Environment.NewLine & "No Contestar el correo porque es una cuenta desatendida"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Correo")
        End Try

    End Sub

    Private Sub btnEnviarCorreo_Click(sender As Object, e As EventArgs) Handles btnEnviarCorreo.Click

        Try
            If ValidaCamposCorreo() Then
                Dim SendFrom As MailAddress = New MailAddress(txtDe.Text.Trim)
                Dim SendTo As MailAddress = New MailAddress(txtPara.Text.Trim)
                Dim MyMessage As MailMessage = New MailMessage(SendFrom, SendTo)
                If toBlank(txtcc.Text) <> "" Then
                    MyMessage.CC.Add(txtcc.Text)
                End If
                MyMessage.Subject = txtAsunto.Text.Trim
                MyMessage.Body = txtMensaje.Text.Trim

                Dim NumCotizacion As String
                NumCotizacion = "Cotización " & NumDoc

                'Dim destdir As String = "D:\Documentos_Electronicos\Facturas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-01-" & Documento & ".zip"
                Dim pdfdir As String = "D:\Documentos_Electronicos\Cotizaciones\" & NumDoc & "\" & NumCotizacion & ".pdf"

                Dim attachFile1 As Attachment = New Attachment(pdfdir)
                MyMessage.Attachments.Add(attachFile1)

                Dim smtp As New System.Net.Mail.SmtpClient
                smtp.Host = Session.sMailHost  '"mail.ddperu.com.pe"
                If Session.sCodEmp = "02" Or Session.sCodEmp = "05" Then    'equimap y equimap amazonica
                    smtp.EnableSsl = True
                End If
                smtp.Port = 587
                smtp.Credentials = New System.Net.NetworkCredential(Session.sCorreoEmisor, Session.sClaveCorreoEmisor) 'New System.Net.NetworkCredential("facturacion@ddperu.com.pe", "Facturacion$2002")
                smtp.Send(MyMessage)
                smtp.Dispose()
                MsgBox("Se envio el correo correctamente", MsgBoxStyle.Information)


                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception
            MsgBox("Error al enviar por correo : " + ex.ToString, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Function ValidaCamposCorreo() As Boolean
        Try
            If txtDe.Text = "" Then
                MsgBox("Debe Ingresar el correo emisor ", MsgBoxStyle.Information, "Información")
                txtDe.Focus()
                Return False
            ElseIf txtPara.Text = "" Then
                MsgBox("Debe Ingresar el correo receptor ", MsgBoxStyle.Information, "Información")
                txtPara.Focus()
                Return False
            ElseIf txtAsunto.Text = "" Then
                MsgBox("Debe Ingresar el asunto ", MsgBoxStyle.Information, "Información")
                txtAsunto.Focus()
                Return False
            ElseIf txtMensaje.Text = "" Then
                MsgBox("Debe Ingresar el mensaje ", MsgBoxStyle.Information, "Información")
                txtMensaje.Focus()
                Return False
            ElseIf ValidaEMail(LCase(txtPara.Text)) = False Then
                MsgBox("Dirección de correo electronico erronea, verificar.", MsgBoxStyle.Information,
                "Información")
                txtPara.Focus()
                txtPara.SelectAll()
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("Error al validar campos correo: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Function ValidaEMail(ByVal EMail As String) As Boolean

        'Como primera regla un correo electronico debe contener la @
        If Not EMail.Contains("@") Then
            Return False
        End If

        'Dividimos la cadena en secciones, obviamente estas deben ser 2
        'el usuario y el host, utilizamos como separador la @
        Dim SeccionesEMail As String() = EMail.Split(CChar("@"))

        'Ahora verificamos que evidentemente solo sean 2 secciones, ya que
        'en caso contrario eso significa que hay mas de una @ y eso es incorrecto
        If SeccionesEMail.Length <> 2 Then
            Return False
        End If

        'Ahora verificamos que la segunda seccion de la cadena de correo contenga
        'al menos un punto, ya que la seccion del dominio debe contener el punto
        'Podemos establecer un tamaño minimo para el dominio en este caso le puse 3
        If Not SeccionesEMail(1).Contains(".") Or Not SeccionesEMail(1).Length >= 3 Then
            Return False
        End If

        Return True

    End Function

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub txtMensaje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMensaje.KeyPress
        If e.KeyChar = ChrW(Keys.Tab) Then
            If btnEnviarCorreo.Enabled = True Then
                btnEnviarCorreo.Select()
                btnEnviarCorreo_Click(sender, e)
            End If
        End If
    End Sub

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtPara.KeyPress _
                          , txtcc.KeyPress _
                          , txtAsunto.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class