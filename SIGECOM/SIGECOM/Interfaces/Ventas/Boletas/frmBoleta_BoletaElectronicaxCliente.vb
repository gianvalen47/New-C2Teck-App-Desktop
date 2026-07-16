Imports System.ServiceModel
Imports LibreriaFacturacion
Imports System.Xml
Imports System.Text
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ZXing
Imports ZXing.PDF417
Imports ZXing.PDF417.Internal

Public Class frmBoleta_BoletaElectronicaxCliente

    Private oMaestroService As New MaestroService.MaestroClient
    Private oBoletaService As New BoletaService.BoletaServiceClient
    Private oBoletaDigitalService As New BoletaDigitalService.BoletaDigitalServiceClient

    Public IdCliente As Integer
    Public DesCli As String
    Public CodSerie As String
    Public NumDoc As String
    Public IdBoleta As Integer
    Dim dtBoletas As DataTable
    Dim NombreXMLPDF As String = ""
    Dim UbicacionCodBarra As String

    Dim CodMot As String
    Dim LegalMonetaryTotal As Double
    Dim CurrencyId As String
    Dim TipoDoc As String
    Dim TaxAmount As Double
    Dim CodSerieFac As String
    Dim NumDocFac As String
    Dim DocumentoFac As String
    Dim FecDoc As Date
    Dim RucCli As String
    Dim DniCli As String
    Dim RucEmp As String
    Dim CodMon As String

    Dim ValorResumen As String
    Dim ValorFirma As String


    Private Sub frmBoleta_BoletaElectronicaxCliente_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oBoletaService.Close()
            oBoletaDigitalService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oBoletaService.Abort()
            oBoletaDigitalService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oBoletaService.Abort()
            oBoletaDigitalService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmBoleta_BoletaElectronicaxCliente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmBoleta_BoletaElectronicaxCliente_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnBuscarCliente.Select()
        txtCodSerie.Text = CodSerie
        txtNumDoc.Text = NumDoc
        txtCliente.Text = DesCli
        ListarDatos()
    End Sub

    Private Sub btnBuscarCliente_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                If toNull(frm.codigo) <> Nothing Then
                    txtCliente.Text = frm.descripcion
                    IdCliente = frm.codigo
                Else
                    txtCliente.Text = ""
                    IdCliente = 0
                End If

                'listarContactos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biActualizar_Click(sender As System.Object, e As System.EventArgs) Handles biActualizar.Click, txtCliente.TextChanged, txtCodSerie.TextChanged, txtNumDoc.TextChanged
        ListarDatos()
    End Sub

    Private Sub ListarDatos()

        dtBoletas = oBoletaDigitalService.ConsultarBoletas(IdCliente, utils.toBlank(txtCodSerie.Text), utils.toNumber(txtNumDoc.Text)).Tables(0)
        dgvDatos.DataSource = dtBoletas

        sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString

    End Sub

    Private Sub biSalir_Click(sender As System.Object, e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biDescargar_Click(sender As System.Object, e As System.EventArgs) Handles biDescargar.Click
        Try
            If dgvDatos.RowCount > 0 Then

                Dim dtImprimirDigital As New DataTable

                dtImprimirDigital = oBoletaService.ImprimirDigital(dgvDatos.CurrentRow.Cells("IdBoleta").Text).Tables(0)
                GridEx2.DataSource = dtImprimirDigital

                CodMot = GridEx2.CurrentRow.Cells("CodMot").Text
                LegalMonetaryTotal = GridEx2.CurrentRow.Cells("LegalMonetaryTotal").Text
                CurrencyId = GridEx2.CurrentRow.Cells("CurrencyId").Text
                TipoDoc = GridEx2.CurrentRow.Cells("TipoDoc").Text
                TaxAmount = GridEx2.CurrentRow.Cells("TaxAmount").Text
                CodSerieFac = GridEx2.CurrentRow.Cells("CodSerie").Text
                NumDocFac = GridEx2.CurrentRow.Cells("NumDoc").Text
                DocumentoFac = GridEx2.CurrentRow.Cells("Documento").Text
                FecDoc = GridEx2.CurrentRow.Cells("FecDoc").Text
                RucEmp = GridEX2.CurrentRow.Cells("RucEmp").Text
                DniCli = GridEX2.CurrentRow.Cells("DniCli").Text
                RucCli = GridEx2.CurrentRow.Cells("RucCli").Text
                CodMon = GridEx2.CurrentRow.Cells("CodMon").Text

                CrearCarpeta()
                CrearXML()
                ObtenerTagFirma()
                CrearPDF()

            Else

                MsgBox("No existe registros, tenga cuidado", MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al descargar la boleta electronica")
        End Try

    End Sub

    Private Sub CrearCarpeta()

        If Not Directory.Exists("D:\Documentos_Electronicos\Boletas_Electronicas\" & GridEx2.CurrentRow.Cells("Documento").Text) Then
            Directory.CreateDirectory("D:\Documentos_Electronicos\Boletas_Electronicas\" & GridEx2.CurrentRow.Cells("Documento").Text)
        End If

    End Sub

    Private Sub CrearXML()

        Try
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(New StringReader(oBoletaDigitalService.Descargar(dgvDatos.CurrentRow.Cells("IdBoleta").Text)))

            NombreXMLPDF = oBoletaDigitalService.ObtenerNombre(dgvDatos.CurrentRow.Cells("IdBoleta").Text)

            xmlDoc.Save("D:\Documentos_Electronicos\Boletas_Electronicas\" & DocumentoFac & "\" & NombreXMLPDF & ".xml")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear el xml")
        End Try

    End Sub


    Private Sub ObtenerTagFirma()

        Try
            Dim xmlDoc As New XmlDocument
            Dim namespaces As XmlNamespaceManager = New XmlNamespaceManager(xmlDoc.NameTable)

            namespaces.AddNamespace("ns", "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2")
            namespaces.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance")
            namespaces.AddNamespace("xsd", "http://www.w3.org/2001/XMLSchema")
            namespaces.AddNamespace("sac", "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")
            namespaces.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")
            namespaces.AddNamespace("qdt", "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2")
            namespaces.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")
            namespaces.AddNamespace("udt", "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2")
            namespaces.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")
            namespaces.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#")

            xmlDoc.Load("D:\Documentos_Electronicos\Boletas_Electronicas\" & DocumentoFac & "\" & NombreXMLPDF & ".xml")

            Dim xPathStringInfo = "/ns:Invoice/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent/ds:Signature[@Id='SignatureSP']/ds:SignedInfo"
            Dim xPathStringValue = "/ns:Invoice/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent/ds:Signature[@Id='SignatureSP']/ds:SignatureValue"

            Dim oNodeInfo = xmlDoc.SelectSingleNode(xPathStringInfo, namespaces)
            ValorResumen = oNodeInfo.InnerText

            Dim oNodeValue = xmlDoc.SelectSingleNode(xPathStringValue, namespaces)
            ValorFirma = oNodeValue.InnerText

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Obtener el Tag")
        End Try


    End Sub

    Private Sub CrearPDF()


        Try
            Dim qr As PDF417Writer = New PDF417Writer

            'Dim url As String = "20100022142|01|F106|611|783.00|5133.00|2015-03-20|6|20100020441|oWUMtPr6aTZltzrFFI6whBA8qdg=|QaBVEy1zRK7VXLM5va0by+mInYDN2fhZBsPbOHXQlBytjj0RZVgjLMkSBhKeUe1kTU5Fk7yZI2S/wAKm/V8W7scEEf7kc3X7WCJwk0lrLoiY0l+N0S0AVJjZcm6wmlN0QB4jh+rTiy+STdhDhx37Ye5QmHAJyR0nB2OYrff2FeegsDv+XY7opVC8jjqxfJXlhvjrklLtMt4w4ueJ+i/YNRIj3D3kYnuj4IXp1SIpwQ3GYJs95yALfn9IME6zXfVkRmjXTqYUS5yAFFYqAc6r01WzcZQSKHPUIPQtoNLN0AHaTT0qQ7gKgBozoDDK0gR5RJ7jEaFd85S4o0h7EaysMg==|"
            Dim url As String = RucEmp & "|" & TipoDoc & "|" & CodSerieFac & "|" & NumDocFac & "|" & IIf(CodMot <> "2", FormatNumber(TaxAmount, 2), FormatNumber("0.00", 2)) & "|" & IIf(CodMot <> "2", FormatNumber(LegalMonetaryTotal, 2), FormatNumber("0.00", 2)) & "|" & FecDoc.ToString("yyyy-MM-dd") & "|" & "1" & "|" & DniCli & "|" & ValorResumen & "|" & ValorFirma


            Dim hints As IDictionary(Of EncodeHintType, Object) = New Dictionary(Of EncodeHintType, Object)
            hints.Add(EncodeHintType.CHARACTER_SET, "ISO8859-1")
            'hints.Add(EncodeHintType.ERROR_CORRECTION, 5)
            hints.Add(EncodeHintType.ERROR_CORRECTION, PDF417ErrorCorrectionLevel.L5)
            hints.Add(EncodeHintType.MARGIN, 5)         '5 es a 1mm , 20 es a 4mm
            hints.Add(EncodeHintType.PDF417_COMPACTION, Compaction.BYTE)
            hints.Add(EncodeHintType.DISABLE_ECI, True)
            'hints.Add(EncodeHintType.PURE_BARCODE

            'Dim matrix As ZXing.Common.BitMatrix = qr.encode(url, ZXing.BarcodeFormat.PDF_417, 115, 65)
            Dim matrix As ZXing.Common.BitMatrix = qr.encode(url, ZXing.BarcodeFormat.PDF_417, 115, 65, hints)
            'Dim matrix As ZXing.Common.BitMatrix = qr.encode(url, ZXing.BarcodeFormat.PDF_417, 115, 65, hints)
            Dim w As ZXing.BarcodeWriter = New ZXing.BarcodeWriter
            w.Format = ZXing.BarcodeFormat.PDF_417

            Dim img As Bitmap = w.Write(matrix)
            'Dim img2 As Bitmap = ResizeBitmap(img, 240, 80)
            'Dim img2 As Bitmap = ResizeBitmap(img, 388, 118)
            UbicacionCodBarra = "D:\Documentos_Electronicos\Boletas_Electronicas\" & DocumentoFac & "\" & DocumentoFac & ".png"
            'img2.Save(UbicacionCodBarra, System.Drawing.Imaging.ImageFormat.Png)
            img.Save(UbicacionCodBarra, System.Drawing.Imaging.ImageFormat.Png)

            If Session.sCodEmp = "01" Then
                CrearPDF2()
            ElseIf Session.sCodEmp = "02" Then
                CrearPDF2MtUAmazonica()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub CrearPDF2()

        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirBoletaElectronica
            'Dim UbicacionCodBarra As String
            'UbicacionCodBarra = "D:\Documentos_Electronicos\Facturas_Electronicas\" & NombreXMLPDF & "\" & NombreXMLPDF & ".png"

            dtReporte = oBoletaService.ImprimirDigital(dgvDatos.CurrentRow.Cells("IdBoleta").Text).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                ExportToPDF(reporte, "miReporte.pdf", DocumentoFac, NombreXMLPDF)

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear el pdf")
        End Try

    End Sub

    Private Sub CrearPDF2MtUAmazonica()

        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirBoletaElectronicaMtuAmaz
            'Dim UbicacionCodBarra As String
            'UbicacionCodBarra = "D:\Documentos_Electronicos\Facturas_Electronicas\" & NombreXMLPDF & "\" & NombreXMLPDF & ".png"

            dtReporte = oBoletaService.ImprimirDigital(dgvDatos.CurrentRow.Cells("IdBoleta").Text).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                ExportToPDF(reporte, "miReporte.pdf", DocumentoFac, NombreXMLPDF)

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear el pdf")
        End Try

    End Sub

    Public Shared Function ExportToPDF(rpt As ReportDocument, NombreArchivo As String, DocumentoFac As String, NombreXMLPDF As String) As String
        Dim vFileName As String = Nothing
        Dim diskOpts As New DiskFileDestinationOptions()

        Try
            diskOpts.DiskFileName = "D:\Documentos_Electronicos\Boletas_Electronicas\" & DocumentoFac & "\" & NombreXMLPDF & ".pdf"

            rpt.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile
            rpt.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat

            If File.Exists(vFileName) Then
                File.Delete(vFileName)
            End If
            rpt.ExportOptions.DestinationOptions = diskOpts
            rpt.Export()

            MsgBox("Se descargo la boleta electronica correctamente", MsgBoxStyle.Information)

        Catch ex As Exception
            Throw ex
        End Try

        Return vFileName
    End Function



End Class