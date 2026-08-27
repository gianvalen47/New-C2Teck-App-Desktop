Imports System
Imports System.IO
Imports System.ServiceModel
Imports System.Net.Mail
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmQuintaCategoriaEnviarCorreoMasivo

    '============================Servicios===================================
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oQuintaCategoria As New QuintaCategoriaCabService.QuintaCategoriaCabServiceClient
    'Private oPlanillaDet As New QuintaCategoriaDetService.QuintaCategoriaDetServiceClient
    Private oPlanilla As New PlanillaSueldosService.PlanillaSueldosServiceClient
    Private parametro As New PlanillaSueldosService.ParametrosPlanilla
    Private dtArchivos As DataTable
    'Dim dtDatosInternos As DataTable
    'Dim dtDatosExternos As DataTable

    Dim NombreArchivo As String
    Dim Direccion As String
    Dim Tamano As Integer

    'Dim DireccionPublicidad As String


    Public periodo As String

    Private Sub frmEnvioMasivoCorreos_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPersonaService.Close()
            oPlanilla.Close()
            '       oPlanillaDet.Close()
            oQuintaCategoria.Close()
        Catch ex As TimeoutException
            oPersonaService.Abort()
            oPlanilla.Abort()
            '      oPlanillaDet.Abort()
            oQuintaCategoria.Abort()
        Catch ex As CommunicationException
            oPersonaService.Abort()
            oPlanilla.Abort()
            'oPlanillaDet.Abort()
            oQuintaCategoria.Abort()
        End Try
    End Sub

    Private Sub CrearCarpeta()
        Try

            If Not Directory.Exists("D:\QuintaCategoriaElectronicas\" & Session.sDesEmp & "\" & periodo.ToString()) Then
                Directory.CreateDirectory("D:\QuintaCategoriaElectronicas\" & Session.sDesEmp & "\" & periodo.ToString())
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear la carpeta")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try

    End Sub

    Private Sub GenerarPDF()

        Dim forma As New frmReportes
        Dim reporte As New rptCertificadoQuinta

        Dim dtReporte As DataTable

        Dim dtDetalle As DataTable
        'Dim registro As New PlanillaSueldosService.PlanillaSueldos
        'registro = oPlanilla.Obtener(idPlanilla)

        dtDetalle = oQuintaCategoria.Filtrar(Session.sCodEmp, periodo, 0).Tables(0)

        If dtDetalle.Rows.Count = 0 Then
            MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
        Else
            For Each Fila As DataRow In dtDetalle.Rows
                dtReporte = oQuintaCategoria.Imprimir(Session.sCodEmp, periodo, Fila.Item("IdPer")).Tables(0)
                reporte.SetDataSource(dtReporte)
                ExportToPDF(reporte, Fila.Item("IdPer"))
            Next

        End If




    End Sub

    Public Function ExportToPDF(rpt As ReportDocument, codigo As String) As String
        Dim vFileName As String = Nothing
        Dim diskOpts As New DiskFileDestinationOptions()

        Try

            diskOpts.DiskFileName = "D:\QuintaCategoriaElectronicas\" & Session.sDesEmp & "\" & periodo.ToString() & "\" & periodo & codigo & ".pdf"

            rpt.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile
            rpt.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat

            'Este es la ruta donde se guardara tu archivo.

            If File.Exists(vFileName) Then
                File.Delete(vFileName)
            End If
            'diskOpts.DiskFileName = vFileName
            rpt.ExportOptions.DestinationOptions = diskOpts
            rpt.Export()
        Catch ex As Exception
            Throw ex
        End Try

        Return vFileName
    End Function

    Private Sub ListarArchivos()
        Try
            Dim d As New DirectoryInfo("D:\QuintaCategoriaElectronicas\" & Session.sDesEmp & "\" & periodo)

            Dim row As DataRow
            Dim dtCopia As New DataTable("tabla")
            dtCopia.Columns.Add(New DataColumn("IdPer", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Nombre", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Tamano", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Correo", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Direccion", Type.GetType("System.String")))

            dtCopia.Rows.Add(New Object() {"IdPer", "Nombre", "Tamano", "Correo", "Direccion"})

            dtArchivos = dtCopia.Copy
            dtArchivos.Clear()

            Dim idPer As Integer
            Dim idper2 As String
            For Each f As FileInfo In d.GetFiles
                'idper2 = Mid(f.Name, 5, Len(f.Name) - (Len(f.Name) - 3))
                'idPer = Mid(idper2, 1, (Len(idper2) - 4))

                idPer = Mid(f.Name, 5, Len(f.Name) - (Len(f.Name) - 3))


                row = dtArchivos.NewRow
                row(0) = idPer
                row(1) = f.Name
                row(2) = CInt(f.Length / 1024) & " kb."
                row(3) = oPersonaService.ObtenerEmail(idPer)
                row(4) = d

                If f.Extension = ".pdf" Then
                    dtArchivos.Rows.Add(row)
                End If
            Next
            dgvArchivosDirectorio.DataSource = dtArchivos

            lblTotal.Text = "Total Registros : " & dtArchivos.Rows.Count().ToString

        Catch ex As Exception
            MsgBox("Error al listar los elementos adjuntos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub CargarCorreo()

        Try


            parametro = oPlanilla.ObtenerParametros(Session.sCodEmp)
            'Dim correodestino As String = oPersonaService.ObtenerEmail(idPer)

            txtDe.Text = parametro.CorreoEmisor
            'txtPara.Text = correodestino
            txtAsunto.Text = Session.sDesEmp & " Certificado de Quinta Categoria " & periodo
            'txtMensaje.Text = "Envio de Boleta de Pago de Sueldo c/Adjunto pdf" & Environment.NewLine & Environment.NewLine & "No Contestar el correo porque es una cuenta desatendida"
            txtMensaje.Text = "Envio de Certificado de Categoria c/Adjunto pdf" & Environment.NewLine & Environment.NewLine

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Correo")
        End Try

    End Sub


    Private Sub frmEnvioMasivoCorreos_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmEnvioMasivoCorreos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'CrearCarpeta()
        'GenerarPDF()
        CargarCorreo()
        ListarArchivos()
        txtAsunto.Focus()
    End Sub


    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnEnviarCorreo_Click(sender As System.Object, e As System.EventArgs) Handles btnEnviarCorreo.Click

        ProgressBar1.Value = 1
        Try
            Dim num As Integer = 1
            If ValidaCamposCorreo() Then
                Dim resul As Boolean = False

                For Each FilaVal As DataRow In dtArchivos.Rows
                    If Len(FilaVal.Item("Correo").ToString) = 0 Then
                        resul = True
                        Exit For
                    End If
                Next

                If resul Then
                    MsgBox("Hay personal sin dirección de correos, registrelo en su ficha", MsgBoxStyle.Exclamation)
                    Return
                End If
                ProgressBar1.Value = 1
                'Dim num As Integer = 1
                For Each Fila As DataRow In dtArchivos.Rows
                    EnviarCorreo(Fila.Item("Correo"), Fila.Item("Direccion"), Fila.Item("Nombre"))
                    '     oPlanillaDet.InsertarEnvioCorreo(idPlanilla, Fila.Item("IdPer"), Fila.Item("Correo"), txtCopia.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    ProgressBar1.Value = 1 + num
                    num = num + 1
                Next
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If
            ProgressBar1.Value = num

        Catch ex As Exception
            MsgBox("Error al enviar por correo : " + ex.ToString, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    'Private Sub EnviarCorreo(correo As String)
    '    Try

    '        Dim SendFrom As MailAddress = New MailAddress(txtDe.Text.Trim)
    '        Dim SendTo As MailAddress = New MailAddress(correo)
    '        Dim MyMessage As MailMessage = New MailMessage(SendFrom, SendTo)

    '        MyMessage.Subject = txtAsunto.Text.Trim
    '        'MyMessage.Body = txtMensaje.Text.Trim + Environment.NewLine + Environment.NewLine + "No contestar el correo, porque es una cuenta desatendida. Cualquier consulta comunicarse con el area correspondiente"
    '        MyMessage.IsBodyHtml = True

    '        'Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString("<span style=""font-weight: bold; padding-left: 20px;padding-right:5px"">" & txtMensaje.Text.Trim & " <br><br><span style=""font-weight: bold; padding-left: 70px;padding-right:5px""><img src=cid:cmateu><br><br><span style=""font-weight: bold; padding-left: 20px;padding-right:5px"">No contestar el correo, porque es una cuenta desatendida. Cualquier consulta comunicarse con el area correspondiente.", Nothing, "text/html")
    '        If txtPublicidad.Text <> "" Then
    '            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString("<span style=""font-weight: bold; padding-left: 20px;padding-right:5px"">" & txtMensaje.Text.Trim & " <br><br><span style=""font-weight: bold; padding-left: 70px;padding-right:5px""><img src=cid:logo><br><br><span style=""; padding-left: 20px;padding-right:5px"">________________________________________________________________________________________________________________<br><i><span style=""font-size:10.0pt;font-weight: bold; padding-left: 20px;padding-right:5px"">No contestar el correo, porque es una cuenta desatendida. Cualquier consulta comunicarse con el area correspondiente.", Nothing, "text/html")
    '            Dim logo As New LinkedResource(DireccionPublicidad, "image/jpeg")
    '            logo.ContentId = "logo"
    '            htmlView.LinkedResources.Add(logo)
    '            MyMessage.AlternateViews.Add(htmlView)
    '        Else
    '            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString("<span style=""font-weight: bold; padding-left: 20px;padding-right:5px"">" & txtMensaje.Text.Trim & " <br><br><span style=""; padding-left: 20px;padding-right:5px"">________________________________________________________________________________________________________________<br><i><span style=""font-size:10.0pt;font-weight: bold; padding-left: 20px;padding-right:5px"">No contestar el correo, porque es una cuenta desatendida. Cualquier consulta comunicarse con el area correspondiente.", Nothing, "text/html")
    '            MyMessage.AlternateViews.Add(htmlView)
    '        End If
    '        'MyMessage.AlternateViews.Add(htmlView)

    '        Dim row As Janus.Windows.GridEX.GridEXRow
    '        For i = 0 To Me.dgvArchivosDirectorio.RowCount - 1
    '            Me.dgvArchivosDirectorio.Row = i
    '            row = Me.dgvArchivosDirectorio.GetRow()

    '            Dim attachFile As Attachment = New Attachment(row.Cells(2).Value)
    '            MyMessage.Attachments.Add(attachFile)

    '        Next

    '        'HABILITAR PARA ENVIAR CORREOS ----------------------------------------------------------------------------------------------------------------------- !!
    '        Dim emailClient As SmtpClient = New SmtpClient("192.168.1.251")
    '        emailClient.Send(MyMessage)
    '        MyMessage.Dispose()
    '        'MsgBox("Se envio el correo correctamente", MsgBoxStyle.Information)

    '    Catch ex As Exception
    '        MsgBox("Error al enviar por correo : " + ex.ToString, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub EnviarCorreo(destino As String, ruta As String, nombre As String)

        Try

            Dim SendFrom As MailAddress = New MailAddress(txtDe.Text.Trim)
            Dim SendTo As MailAddress = New MailAddress(destino)
            Dim MyMessage As MailMessage = New MailMessage(SendFrom, SendTo)
            If toBlank(txtCopia.Text) <> "" Then
                MyMessage.CC.Add(txtCopia.Text)
            End If
            MyMessage.Subject = txtAsunto.Text.Trim
            'MyMessage.Body = txtMensaje.Text.Trim
            MyMessage.IsBodyHtml = True

            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString("<span style=""font-weight: bold; padding-left: 20px;padding-right:5px"">" & txtMensaje.Text.Trim & " <br><br><span style=""; padding-left: 20px;padding-right:5px"">________________________________________________________________________________________________________________<br><i><span style=""font-size:10.0pt;font-weight: bold; padding-left: 20px;padding-right:5px"">No contestar el correo, porque es una cuenta desatendida. Cualquier consulta comunicarse con el area correspondiente.", Nothing, "text/html")
            MyMessage.AlternateViews.Add(htmlView)

            'Dim pdfdir As String = "D:\BoletaSueldoElectronicas\" & Session.sDesEmp & "\" & idPlanilla & "\" & periodo & mes & idper & ".pdf"
            Dim pdfdir As String = ruta & "\" & nombre

            Dim attachFile1 As Attachment = New Attachment(pdfdir)
            MyMessage.Attachments.Add(attachFile1)

            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Host = parametro.MailHost
            smtp.EnableSsl = True
            smtp.Port = 587
            smtp.Credentials = New System.Net.NetworkCredential(parametro.CorreoEmisor, parametro.ClaveCorreoEmisor)
            smtp.Send(MyMessage)
            'MsgBox("Se envio el correo correctamente", MsgBoxStyle.Information)

            'Me.DialogResult = System.Windows.Forms.DialogResult.OK



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
        'Dim file As New OpenFileDialog()
        ''file.Filter = "Archivo JPG|*.jpg"
        ''file.Filter = "XML|*.xml"
        'If file.ShowDialog() = DialogResult.OK Then

        '    NombreArchivo = System.IO.Path.GetFileNameWithoutExtension(file.FileName)
        '    Tamano = FileLen(file.FileName)
        '    Direccion = file.FileName

        '    AgregarFila()

        'End If
    End Sub

    'Private Sub AgregarFila()
    '    Try
    '        Dim row As DataRow
    '        Dim dtArchivos As DataTable

    '        Dim dtCopia As New DataTable("tabla")

    '        dtCopia.Columns.Add(New DataColumn("Nombre1", Type.GetType("System.String")))
    '        dtCopia.Columns.Add(New DataColumn("Tamano1", Type.GetType("System.String")))
    '        dtCopia.Columns.Add(New DataColumn("Direccion1", Type.GetType("System.String")))

    '        dtCopia.Rows.Add(New Object() {"Nombre", "Tamano", "Direccion"})

    '        dtArchivos = dtCopia.Copy
    '        dtArchivos.Clear()

    '        For i As Integer = 0 To DataGridView1.Rows.Count - 1
    '            If DataGridView1.Rows.Count > 1 Then
    '                If CStr(DataGridView1.Item(1, i).Value) <> "" Then

    '                    '    row = dtArchivos.NewRow

    '                    '    row(0) = NombreArchivo
    '                    '    row(1) = Tamano
    '                    '    row(2) = Direccion

    '                    '    dtArchivos.Rows.Add(row)
    '                    'Else
    '                    row = dtArchivos.NewRow

    '                    row(0) = DataGridView1.Item(0, i).Value
    '                    row(1) = DataGridView1.Item(1, i).Value
    '                    row(2) = DataGridView1.Item(2, i).Value

    '                    dtArchivos.Rows.Add(row)
    '                End If
    '            End If
    '        Next

    '        row = dtArchivos.NewRow

    '        row(0) = NombreArchivo
    '        row(1) = CInt(Tamano / 1024)
    '        row(2) = Direccion

    '        dtArchivos.Rows.Add(row)

    '        DataGridView1.DataSource = dtArchivos
    '        dgvArchivosDirectorio.DataSource = dtArchivos

    '    Catch ex As Exception
    '        MsgBox("Error al listar los elementos adjuntos : " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub miEliminar_Click(sender As System.Object, e As System.EventArgs) Handles miEliminar.Click
        'If dgvArchivosDirectorio.RowCount > 0 Then
        '    EliminarFila()
        'End If
    End Sub

    'Private Sub EliminarFila()
    '    Try
    '        Dim row As DataRow
    '        Dim dtArchivos As DataTable

    '        Dim dtCopia As New DataTable("tabla")
    '        Dim registroeliminar As String

    '        registroeliminar = dgvArchivosDirectorio.CurrentRow.Cells("Nombre1").Text

    '        dtCopia.Columns.Add(New DataColumn("Nombre1", Type.GetType("System.String")))
    '        dtCopia.Columns.Add(New DataColumn("Tamano1", Type.GetType("System.String")))
    '        dtCopia.Columns.Add(New DataColumn("Direccion1", Type.GetType("System.String")))

    '        dtCopia.Rows.Add(New Object() {"Nombre", "Tamano", "Direccion"})

    '        dtArchivos = dtCopia.Copy
    '        dtArchivos.Clear()

    '        For i As Integer = 0 To DataGridView1.Rows.Count - 2
    '            If DataGridView1.Rows.Count > 1 Then
    '                If CStr(DataGridView1.Item(0, i).Value) <> registroeliminar Then

    '                    '    row = dtArchivos.NewRow

    '                    '    row(0) = NombreArchivo
    '                    '    row(1) = Tamano
    '                    '    row(2) = Direccion

    '                    '    dtArchivos.Rows.Add(row)
    '                    'Else
    '                    row = dtArchivos.NewRow

    '                    row(0) = DataGridView1.Item(0, i).Value
    '                    row(1) = DataGridView1.Item(1, i).Value
    '                    row(2) = DataGridView1.Item(2, i).Value

    '                    dtArchivos.Rows.Add(row)
    '                End If
    '            End If
    '        Next


    '        DataGridView1.DataSource = dtArchivos
    '        dgvArchivosDirectorio.DataSource = dtArchivos

    '    Catch ex As Exception
    '        MsgBox("Error al listar los elementos adjuntos : " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub dgvArchivosDirectorio_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvArchivosDirectorio.DoubleClick
        If dgvArchivosDirectorio.RowCount > 0 Then
            VerArchivo()
        End If
    End Sub

    'Private Sub btnBuscarPublicidad_Click(sender As System.Object, e As System.EventArgs)
    '    Dim file As New OpenFileDialog()
    '    file.Filter = "JPG|*.jpg;*.jpeg|PNG|*.png|BMP|*.bmp"
    '    'file.Filter = "XML|*.xml"
    '    If file.ShowDialog() = DialogResult.OK Then

    '        txtPublicidad.Text = System.IO.Path.GetFileNameWithoutExtension(file.FileName)
    '        '   DireccionPublicidad = file.FileName

    '    End If
    'End Sub

    Private Sub btnVerPublicidad_Click(sender As System.Object, e As System.EventArgs)
        'Try
        '    Dim myProcess As New Process
        '    myProcess.StartInfo.FileName = DireccionPublicidad
        '    myProcess.StartInfo.UseShellExecute = True
        '    myProcess.StartInfo.RedirectStandardOutput = False
        '    myProcess.Start()
        '    myProcess.Dispose()
        'Catch ex As Exception
        '    MsgBox("Error al visualizar el archivo." + ex.Message, MsgBoxStyle.Exclamation)
        'End Try
    End Sub

    Private Sub biLimpiar_Click(sender As System.Object, e As System.EventArgs)
        'txtPublicidad.Text = ""
        'DireccionPublicidad = ""
    End Sub

End Class