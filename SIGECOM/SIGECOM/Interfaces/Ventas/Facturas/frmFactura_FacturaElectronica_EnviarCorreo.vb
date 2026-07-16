Imports System.ServiceModel
Imports System.Xml
Imports System.IO
Imports System.Net.Mail
Imports System.Text.RegularExpressions

Public Class frmFactura_FacturaElectronica_EnviarCorreo

    Private oFacturaDigitalService As New FacturaDigitalService.FacturaDigitalServiceClient
    Private oUsuarioClienteService As New UsuarioClienteService.UsuarioClienteServiceClient

    Private oFacturaService As New FacturaService.FacturaServiceClient

    Public CodSerie As String
    Public NumDoc As String
    Public IdFactura As Integer
    Public IdCliente As Integer

    Private Documento As String = ""

    Private Sub frmFactura_FacturaElectronica_EnviarCorreo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oFacturaDigitalService.Close()
            oUsuarioClienteService.Close()
        Catch ex As TimeoutException
            oFacturaDigitalService.Abort()
            oUsuarioClienteService.Abort()
        Catch ex As CommunicationException
            oFacturaDigitalService.Abort()
            oUsuarioClienteService.Abort()
        End Try
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub frmFactura_FacturaElectronica_EnviarCorreo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub frmFactura_FacturaElectronica_EnviarCorreo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Dim NombreCarpeta As String = ""
        Documento = CodSerie + "-" + NumDoc


        If Not Directory.Exists("D:\Documentos_Electronicos\Facturas_Electronicas\" & Documento) Then
            Directory.CreateDirectory("D:\Documentos_Electronicos\Facturas_Electronicas\" & Documento)
        End If

        DescargarPDF()
        DescargarXML()

        DescargarCDRXML()

        ListarArchivos()

        CargarCorreo()


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
            txtAsunto.Text = Session.sDesEmp & " - Factura Electronica: " & Documento '"DETROIT DIESEL MTU PERU SAC - Factura Electronica: " & Documento
            txtMensaje.Text = "Envio de Factura Electronica c/Adjunto xml, pdf" & Environment.NewLine & Environment.NewLine & "No Contestar el correo porque es una cuenta desatendida"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Correo")
        End Try

    End Sub

    Private Sub DescargarPDF()

        Try
            Dim pdfDoc() As Byte
            'Dim NombreCarpeta As String = ""
            'NombreCarpeta = CodSerie + "-" + NumDoc

            pdfDoc = oFacturaDigitalService.DescargarPdf(IdFactura)

            Dim NombreXMLPDF As String = oFacturaDigitalService.ObtenerNombre(IdFactura)

            System.IO.File.WriteAllBytes("D:\Documentos_Electronicos\Facturas_Electronicas\" & Documento & "\" & NombreXMLPDF & ".pdf", pdfDoc)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear el pdf")
        End Try

    End Sub

    Private Sub DescargarXML()

        Try

            'Dim NombreCarpeta As String = ""
            'NombreCarpeta = CodSerie + "-" + NumDoc

            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(New StringReader(oFacturaDigitalService.Descargar(IdFactura)))

            Dim NombreXMLPDF As String = oFacturaDigitalService.ObtenerNombre(IdFactura)

            xmlDoc.Save("D:\Documentos_Electronicos\Facturas_Electronicas\" & Documento & "\" & NombreXMLPDF & ".xml")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear al xml")
        End Try

    End Sub

    Private Sub DescargarCDRXML()

        Try

            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(New StringReader(oFacturaDigitalService.DescargarCDR(IdFactura)))

            Dim NombreXMLPDF As String = oFacturaDigitalService.ObtenerNombre(IdFactura)

            xmlDoc.Save("D:\Documentos_Electronicos\Facturas_Electronicas\" & Documento & "\R-" & NombreXMLPDF & ".xml")


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear al xml")
        End Try

    End Sub


    Private Sub ListarArchivos()
        Try
            Dim d As New DirectoryInfo("D:\Documentos_Electronicos\Facturas_Electronicas\" & Documento)

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

                'Dim destdir As String = "D:\Documentos_Electronicos\Facturas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-01-" & Documento & ".zip"
                Dim xmldir As String = "D:\Documentos_Electronicos\Facturas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-01-" & Documento & ".xml"
                Dim pdfdir As String = "D:\Documentos_Electronicos\Facturas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-01-" & Documento & ".pdf"
                Dim xmlcdrdir As String = "D:\Documentos_Electronicos\Facturas_Electronicas\" & Documento & "\R-" & Session.sRucEmp & "-01-" & Documento & ".xml"

                'Dim destdir As String = "D:\Documentos_Electronicos\Facturas_Electronicas\" & Documento & "\20100020441-01-" & Documento & ".zip"
                'Dim xmldir As String = "D:\Documentos_Electronicos\Facturas_Electronicas\" & Documento & "\20100020441-01-" & Documento & ".xml"
                'Dim pdfdir As String = "D:\Documentos_Electronicos\Facturas_Electronicas\" & Documento & "\20100020441-01-" & Documento & ".pdf"

                Dim attachFile As Attachment = New Attachment(xmldir)
                MyMessage.Attachments.Add(attachFile)
                Dim attachFile1 As Attachment = New Attachment(pdfdir)
                MyMessage.Attachments.Add(attachFile1)
                Dim attachFile2 As Attachment = New Attachment(xmlcdrdir)
                MyMessage.Attachments.Add(attachFile2)

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

                'Dim emailClient As SmtpClient = New SmtpClient("mail.equimap.com.pe")
                'emailClient.Send(MyMessage)
                'MyMessage.Dispose()
                'MsgBox("Se envio el correo correctamente", MsgBoxStyle.Information)

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
                'ElseIf ValidaEMail(LCase(txtDe.Text)) = False Then
                '    MsgBox("Dirección de correo electronico no valida, verificar", MsgBoxStyle.Information,
                '    "Información")
                '    txtDe.Focus()
                '    txtDe.SelectAll()
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

    Private Sub btnVerFactura_Click(sender As Object, e As EventArgs) Handles btnVerFactura.Click
        Try

            Dim NombreXMLPDF As String = oFacturaDigitalService.ObtenerNombre(IdFactura)

            System.Diagnostics.Process.Start("D:\Documentos_Electronicos\Facturas_Electronicas\" & Documento & "\" & NombreXMLPDF & ".pdf")


        Catch ex As Exception
            MsgBox("Error al visualizar el documento: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

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

    'Public Function validar_Mail(ByVal sMail As String) As Boolean
    '    ' retorna true o false   
    '    Return Regex.IsMatch(sMail,
    '              "^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-  
    '           9-]+)*(\.[a-z]{2,4})$")
    'End Function

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

End Class