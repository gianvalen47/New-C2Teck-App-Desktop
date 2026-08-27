Imports System
Imports System.IO
Imports System.ServiceModel
Imports System.Net.Mail

Public Class frmEnvioMasivoCorreos

    '============================Servicios===================================
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oUsuarioClienteService As New UsuarioClienteService.UsuarioClienteServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Dim dtDatosInternos As DataTable
    Dim dtDatosExternos As DataTable

    Dim NombreArchivo As String
    Dim Direccion As String
    Dim Tamano As Integer

    Dim DireccionPublicidad As String

    Private Sub frmEnvioMasivoCorreos_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPersonaService.Close()
            oUsuarioClienteService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oPersonaService.Abort()
            oUsuarioClienteService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oPersonaService.Abort()
            oUsuarioClienteService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmEnvioMasivoCorreos_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmEnvioMasivoCorreos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try

            '/************************** Insertar Opciones de Session ************************/
            oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 272)
            '/*************************************************************************************/

            txtDe.Text = "" '"adminbd@ddperu.com.pe"

            If rbExterno.Checked Then
                ListarExternos()
            ElseIf rbInterno.Checked Then
                ListarInternos()
            End If
            txtAsunto.Focus()

        Catch ex As Exception
            MsgBox("Error al enviar por correo : " + ex.ToString, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ListarExternos()

        Try

            dtDatosExternos = oUsuarioClienteService.MostrarCorreos(Session.sCodEmp).Tables(0)
            dgvCorreos.DataSource = dtDatosExternos

        Catch ex As Exception
            MsgBox("Error al listar los correos externos: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub ListarInternos()

        Try
            dtDatosInternos = oPersonaService.MostrarCorreos(Session.sCodEmp).Tables(0)
            dgvCorreos.DataSource = dtDatosInternos

        Catch ex As Exception
            MsgBox("Error al listar los correos internos: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnEnviarCorreo_Click(sender As System.Object, e As System.EventArgs) Handles btnEnviarCorreo.Click
        Try
            If ValidaCamposCorreo() Then

                Dim row As Janus.Windows.GridEX.GridEXRow
                For i = 0 To Me.dgvCorreos.RowCount - 1
                    Me.dgvCorreos.Row = i
                    row = Me.dgvCorreos.GetRow()
                    EnviarCorreo(row.Cells(1).Value)
                Next

                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception
            MsgBox("Error al enviar por correo : " + ex.ToString, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnviarCorreo(correo As String)
        Try

            Dim SendFrom As MailAddress = New MailAddress(txtDe.Text.Trim)
            Dim SendTo As MailAddress = New MailAddress(correo)
            Dim MyMessage As MailMessage = New MailMessage(SendFrom, SendTo)

            MyMessage.Subject = txtAsunto.Text.Trim
            'MyMessage.Body = txtMensaje.Text.Trim + Environment.NewLine + Environment.NewLine + "No contestar el correo, porque es una cuenta desatendida. Cualquier consulta comunicarse con el area correspondiente"
            MyMessage.IsBodyHtml = True

            'Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString("<span style=""font-weight: bold; padding-left: 20px;padding-right:5px"">" & txtMensaje.Text.Trim & " <br><br><span style=""font-weight: bold; padding-left: 70px;padding-right:5px""><img src=cid:cmateu><br><br><span style=""font-weight: bold; padding-left: 20px;padding-right:5px"">No contestar el correo, porque es una cuenta desatendida. Cualquier consulta comunicarse con el area correspondiente.", Nothing, "text/html")
            If txtPublicidad.Text <> "" Then
                Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString("<span style=""font-weight: bold; padding-left: 20px;padding-right:5px"">" & txtMensaje.Text.Trim & " <br><br><span style=""font-weight: bold; padding-left: 70px;padding-right:5px""><img src=cid:logo><br><br><span style=""; padding-left: 20px;padding-right:5px"">________________________________________________________________________________________________________________<br><i><span style=""font-size:10.0pt;font-weight: bold; padding-left: 20px;padding-right:5px"">No contestar el correo, porque es una cuenta desatendida. Cualquier consulta comunicarse con el area correspondiente.", Nothing, "text/html")
                Dim logo As New LinkedResource(DireccionPublicidad, "image/jpeg")
                logo.ContentId = "logo"
                htmlView.LinkedResources.Add(logo)
                MyMessage.AlternateViews.Add(htmlView)
            Else
                Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString("<span style=""font-weight: bold; padding-left: 20px;padding-right:5px"">" & txtMensaje.Text.Trim & " <br><br><span style=""; padding-left: 20px;padding-right:5px"">________________________________________________________________________________________________________________<br><i><span style=""font-size:10.0pt;font-weight: bold; padding-left: 20px;padding-right:5px"">No contestar el correo, porque es una cuenta desatendida. Cualquier consulta comunicarse con el area correspondiente.", Nothing, "text/html")
                MyMessage.AlternateViews.Add(htmlView)
            End If
            'MyMessage.AlternateViews.Add(htmlView)

            Dim row As Janus.Windows.GridEX.GridEXRow
            For i = 0 To Me.dgvArchivosDirectorio.RowCount - 1
                Me.dgvArchivosDirectorio.Row = i
                row = Me.dgvArchivosDirectorio.GetRow()

                Dim attachFile As Attachment = New Attachment(row.Cells(2).Value)
                MyMessage.Attachments.Add(attachFile)

            Next

            'HABILITAR PARA ENVIAR CORREOS ----------------------------------------------------------------------------------------------------------------------- !!
            Dim emailClient As SmtpClient = New SmtpClient("192.168.1.251")
            emailClient.Send(MyMessage)
            MyMessage.Dispose()
            'MsgBox("Se envio el correo correctamente", MsgBoxStyle.Information)

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
            ElseIf txtAsunto.Text = "" Then
                MsgBox("Debe Ingresar el asunto ", MsgBoxStyle.Information, "Información")
                txtAsunto.Focus()
                Return False
            ElseIf txtMensaje.Text = "" Then
                MsgBox("Debe Ingresar el mensaje ", MsgBoxStyle.Information, "Información")
                txtMensaje2.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("Error al validar campos correo: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biColorFuente_Click(sender As System.Object, e As System.EventArgs) Handles biColorFuente.Click
        ColorDialog1.ShowDialog()
        txtMensaje2.SelectionColor = ColorDialog1.Color
    End Sub

    Private Sub biFuente_Click(sender As System.Object, e As System.EventArgs) Handles biFuente.Click
        FontDialog1.ShowDialog()
        txtMensaje2.SelectionFont = FontDialog1.Font
    End Sub

    Private Sub cbVineta_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbVineta.CheckedChanged
        If cbVineta.Checked Then
            txtMensaje2.SelectionBullet = True
        Else
            txtMensaje2.SelectionBullet = False
        End If
    End Sub

    Private Sub txtMensaje_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMensaje2.TextChanged
        If txtMensaje2.SelectionBullet Then
            cbVineta.Checked = True
        Else
            cbVineta.Checked = False
        End If
    End Sub

    Private Sub miVer_Click(sender As System.Object, e As System.EventArgs) Handles miVer.Click

        VerArchivo()

    End Sub

    Private Sub VerArchivo()
        Try
            Dim myProcess As New Process
            myProcess.StartInfo.FileName = dgvArchivosDirectorio.CurrentRow.Cells("Direccion1").Text
            myProcess.StartInfo.UseShellExecute = True
            myProcess.StartInfo.RedirectStandardOutput = False
            myProcess.Start()
            myProcess.Dispose()
        Catch ex As Exception
            MsgBox("Error al visualizar el archivo." + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevo_Click(sender As System.Object, e As System.EventArgs) Handles miNuevo.Click
        Dim file As New OpenFileDialog()
        'file.Filter = "Archivo JPG|*.jpg"
        'file.Filter = "XML|*.xml"
        If file.ShowDialog() = DialogResult.OK Then

            NombreArchivo = System.IO.Path.GetFileNameWithoutExtension(file.FileName)
            Tamano = FileLen(file.FileName)
            Direccion = file.FileName

            AgregarFila()

        End If
    End Sub

    Private Sub AgregarFila()
        Try
            Dim row As DataRow
            Dim dtArchivos As DataTable

            Dim dtCopia As New DataTable("tabla")

            dtCopia.Columns.Add(New DataColumn("Nombre1", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Tamano1", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Direccion1", Type.GetType("System.String")))

            dtCopia.Rows.Add(New Object() {"Nombre", "Tamano", "Direccion"})

            dtArchivos = dtCopia.Copy
            dtArchivos.Clear()

            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Rows.Count > 1 Then
                    If CStr(DataGridView1.Item(1, i).Value) <> "" Then

                        '    row = dtArchivos.NewRow

                        '    row(0) = NombreArchivo
                        '    row(1) = Tamano
                        '    row(2) = Direccion

                        '    dtArchivos.Rows.Add(row)
                        'Else
                        row = dtArchivos.NewRow

                        row(0) = DataGridView1.Item(0, i).Value
                        row(1) = DataGridView1.Item(1, i).Value
                        row(2) = DataGridView1.Item(2, i).Value

                        dtArchivos.Rows.Add(row)
                    End If
                End If
            Next

            row = dtArchivos.NewRow

            row(0) = NombreArchivo
            row(1) = CInt(Tamano / 1024)
            row(2) = Direccion

            dtArchivos.Rows.Add(row)

            DataGridView1.DataSource = dtArchivos
            dgvArchivosDirectorio.DataSource = dtArchivos

        Catch ex As Exception
            MsgBox("Error al listar los elementos adjuntos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEliminar_Click(sender As System.Object, e As System.EventArgs) Handles miEliminar.Click
        If dgvArchivosDirectorio.RowCount > 0 Then
            EliminarFila()
        End If
    End Sub

    Private Sub EliminarFila()
        Try
            Dim row As DataRow
            Dim dtArchivos As DataTable

            Dim dtCopia As New DataTable("tabla")
            Dim registroeliminar As String

            registroeliminar = dgvArchivosDirectorio.CurrentRow.Cells("Nombre1").Text

            dtCopia.Columns.Add(New DataColumn("Nombre1", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Tamano1", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Direccion1", Type.GetType("System.String")))

            dtCopia.Rows.Add(New Object() {"Nombre", "Tamano", "Direccion"})

            dtArchivos = dtCopia.Copy
            dtArchivos.Clear()

            For i As Integer = 0 To DataGridView1.Rows.Count - 2
                If DataGridView1.Rows.Count > 1 Then
                    If CStr(DataGridView1.Item(0, i).Value) <> registroeliminar Then

                        '    row = dtArchivos.NewRow

                        '    row(0) = NombreArchivo
                        '    row(1) = Tamano
                        '    row(2) = Direccion

                        '    dtArchivos.Rows.Add(row)
                        'Else
                        row = dtArchivos.NewRow

                        row(0) = DataGridView1.Item(0, i).Value
                        row(1) = DataGridView1.Item(1, i).Value
                        row(2) = DataGridView1.Item(2, i).Value

                        dtArchivos.Rows.Add(row)
                    End If
                End If
            Next


            DataGridView1.DataSource = dtArchivos
            dgvArchivosDirectorio.DataSource = dtArchivos

        Catch ex As Exception
            MsgBox("Error al listar los elementos adjuntos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub rbExterno_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbExterno.CheckedChanged
        If rbExterno.Checked Then
            ListarExternos()
        ElseIf rbInterno.Checked Then
            ListarInternos()
        End If

    End Sub

    Private Sub dgvArchivosDirectorio_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvArchivosDirectorio.DoubleClick
        If dgvArchivosDirectorio.RowCount > 0 Then
            VerArchivo()
        End If
    End Sub

    Private Sub btnBuscarPublicidad_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarPublicidad.Click
        Dim file As New OpenFileDialog()
        file.Filter = "JPG|*.jpg;*.jpeg|PNG|*.png|BMP|*.bmp"
        'file.Filter = "XML|*.xml"
        If file.ShowDialog() = DialogResult.OK Then

            txtPublicidad.Text = System.IO.Path.GetFileNameWithoutExtension(file.FileName)
            DireccionPublicidad = file.FileName

        End If
    End Sub

    Private Sub btnVerPublicidad_Click(sender As System.Object, e As System.EventArgs) Handles btnVerPublicidad.Click
        Try
            Dim myProcess As New Process
            myProcess.StartInfo.FileName = DireccionPublicidad
            myProcess.StartInfo.UseShellExecute = True
            myProcess.StartInfo.RedirectStandardOutput = False
            myProcess.Start()
            myProcess.Dispose()
        Catch ex As Exception
            MsgBox("Error al visualizar el archivo." + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles biLimpiar.Click
        txtPublicidad.Text = ""
        DireccionPublicidad = ""
    End Sub
End Class