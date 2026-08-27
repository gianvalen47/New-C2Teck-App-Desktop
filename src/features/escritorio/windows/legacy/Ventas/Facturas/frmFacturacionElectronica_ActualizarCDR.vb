Imports System.ComponentModel
Imports System.IO
Imports System.ServiceModel
Imports System.Windows.Forms
Imports System.Xml

Public Class frmFacturacionElectronica_ActualizarCDR

    Private oFacturaDigitalService As New FacturaDigitalService.FacturaDigitalServiceClient
    Public IdFactura As Int64
    Public CodSerie As String
    Public NumDoc As String
    Private NombreArchivo As String
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click


        Try


            Dim resul As Boolean


            If txtXmlFE.Text.Trim.Length = 0 Then
                MsgBox("Debe seleccionar el archivo xml de la factura emitida", MsgBoxStyle.Critical, "Error al actualizar CDR")
                Return
            End If

            If txtPdfFE.Text.Trim.Length = 0 Then
                MsgBox("Debe seleccionar el archivo pdf de la factura emitida", MsgBoxStyle.Critical, "Error al actualizar CDR")
                Return
            End If



            Dim registro As New FacturaDigitalService.FacturaDigital
            Dim factura As New FacturaDigitalService.Factura


            Dim xmlDoc As New XmlDocument()
            xmlDoc.Load(txtXmlFE.Text)

            Dim xmlcdr As New XmlDocument()
            xmlcdr.Load(txtXmlCDR.Text)

            Dim strPath As String
            strPath = txtPdfFE.Text
            Dim ruta As New FileStream(strPath, FileMode.Open, FileAccess.Read)
            Dim binario(ruta.Length) As Byte
            ruta.Read(binario, 0, ruta.Length) 'Leo el archivo y lo convierto a binario 
            ruta.Close()

            factura.IdFactura = IdFactura
            registro.Factura = factura
            registro.NombreXml = NombreArchivo
            registro.DocumentoXml = xmlDoc.OuterXml
            registro.NumTicket = txtTicket.Text
            registro.CDRxml = xmlcdr.OuterXml
            registro.Estado = txtEstado.Text
            registro.Observacion = txtObservacion.Text
            registro.Notas = toNull(txtNotas.Text)
            registro.DocumentoPdf = binario
            registro.CodUsu = Session.sCodUsu
            registro.DirIp = Session.sDirIp
            registro.NomPc = Session.sNomPc

            resul = oFacturaDigitalService.Insertar(registro)

            If resul Then
                MsgBox("Se proceso la factura electronica correctamente", MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al actualizar CDR")
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End Try

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmFacturacionElectronica_ActualizarCDR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNumDoc.Text = CodSerie + "-" + NumDoc
        btnBuscarXml.Select()

    End Sub

    Private Sub btnBuscarXml_Click(sender As Object, e As EventArgs) Handles btnBuscarXml.Click
        Dim file As New OpenFileDialog()
        'file.Filter = "Archivo JPG|*.jpg"
        file.Filter = "XML|*.xml"
        If file.ShowDialog() = DialogResult.OK Then

            txtXmlFE.Text = file.FileName
            NombreArchivo = System.IO.Path.GetFileNameWithoutExtension(file.FileName)

        End If
    End Sub

    Private Sub btnBuscarPdf_Click(sender As Object, e As EventArgs) Handles btnBuscarPdf.Click
        Dim file As New OpenFileDialog()
        'file.Filter = "Archivo JPG|*.jpg"
        file.Filter = "PDF|*.pdf"
        If file.ShowDialog() = DialogResult.OK Then

            txtPdfFE.Text = file.FileName
            NombreArchivo = System.IO.Path.GetFileNameWithoutExtension(file.FileName)
        End If
    End Sub

    Private Sub btnBuscarXmlCDR_Click(sender As Object, e As EventArgs) Handles btnBuscarXmlCDR.Click
        Dim file As New OpenFileDialog()
        file.Filter = "XML|*.xml"
        If file.ShowDialog() = DialogResult.OK Then
            txtXmlCDR.Text = file.FileName

            ObtenerDatosXmlCDR()
        End If
    End Sub

    Private Sub ObtenerDatosXmlCDR()

        '/////////OBTENER ESTADO E INFORMACION DEL CDR SUNAT/////////////////////////
        Dim xmlDocR As New XmlDocument
        xmlDocR.Load(txtXmlCDR.Text)

        Dim namespaces As XmlNamespaceManager = New XmlNamespaceManager(xmlDocR.NameTable)
        namespaces.AddNamespace("ns", "urn:oasis:names:specification:ubl:schema:xsd:ApplicationResponse-2")
        namespaces.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")
        namespaces.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")
        namespaces.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#")
        namespaces.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")

        Dim notecompilado As String = ""
        Dim contador As Integer = 0
        Dim xnList As XmlNodeList = xmlDocR.SelectNodes("/ns:ApplicationResponse/cbc:Note", namespaces)
        For Each xn As XmlNode In xnList
            notecompilado = notecompilado & xnList.Item(contador).InnerText & ". " & Environment.NewLine
            contador = contador + 1
        Next
        Dim xPathString = "/ns:ApplicationResponse/cac:DocumentResponse/cac:Response/cbc:Description"
        Dim xPathString2 = "/ns:ApplicationResponse/cac:DocumentResponse/cac:Response/cbc:ResponseCode"
        Dim xPathString3 = "/ns:ApplicationResponse/cbc:ID"
        Dim oNode = xmlDocR.SelectSingleNode(xPathString, namespaces)
        Dim oNode2 = xmlDocR.SelectSingleNode(xPathString2, namespaces)
        Dim oNode3 = xmlDocR.SelectSingleNode(xPathString3, namespaces)
        Dim Responsecode As String = oNode2.InnerText
        Dim Descripcioncdr As String = oNode.InnerText
        Dim NumTicket As String = oNode3.InnerText

        txtTicket.Text = NumTicket
        txtEstado.Text = Responsecode
        txtObservacion.Text = Descripcioncdr
        txtNotas.Text = toNull(notecompilado)

        '///////////////////////////////////////////////////////////////////////////

    End Sub

    Private Sub frmFacturacionElectronica_ActualizarCDR_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            oFacturaDigitalService.Close()
        Catch ex As TimeoutException
            oFacturaDigitalService.Abort()
        Catch ex As CommunicationException
            oFacturaDigitalService.Abort()
        End Try
    End Sub
End Class
