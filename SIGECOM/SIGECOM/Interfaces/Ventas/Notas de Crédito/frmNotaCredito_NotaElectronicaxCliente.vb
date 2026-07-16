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

Public Class frmNotaCredito_NotaElectronicaxCliente

    Private oMaestroService As New MaestroService.MaestroClient
    Private oNotaCreditoService As New NotaCreditoService.NotaCreditoServiceClient
    Private oNotaDigitalService As New NotaDigitalService.NotaDigitalServiceClient

    Public DesCli As String
    Public IdCliente As Integer
    Public CodSerie As String
    Public NumDoc As String
    Public IdNota As Integer
    Public IdDocumento As String
    Dim dtNotas As DataTable
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
    Dim DniCli As String
    Dim RucCli As String
    Dim RucEmp As String
    Dim CodMon As String
    Dim TipoIdentidad As String
    Dim ValorResumen As String
    Dim ValorFirma As String

    Private Sub frmNotaCredito_NotaElectronicaxCliente_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oNotaCreditoService.Close()
            oNotaDigitalService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oNotaCreditoService.Abort()
            oNotaDigitalService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oNotaCreditoService.Abort()
            oNotaDigitalService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmNotaCredito_NotaElectronicaxCliente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmNotaCredito_NotaElectronicaxCliente_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnBuscarCliente.Select()
        txtCodSerie.Text = CodSerie
        txtNumDoc.Text = NumDoc
        txtCliente.Text = DesCli
        ListarDatos()
    End Sub

    Private Sub ListarDatos()

        dtNotas = oNotaDigitalService.ConsultarNotas(IdCliente, utils.toBlank(txtCodSerie.Text), utils.toNumber(txtNumDoc.Text)).Tables(0)
        dgvDatos.DataSource = dtNotas

        sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
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

                'ListarDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biActualizar_Click(sender As System.Object, e As System.EventArgs) Handles biActualizar.Click, txtCliente.TextChanged, txtCodSerie.TextChanged, txtNumDoc.TextChanged
        ListarDatos()
    End Sub

    Private Sub biSalir_Click(sender As System.Object, e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biDescargar_Click(sender As System.Object, e As System.EventArgs) Handles biDescargar.Click
        Try
            If dgvDatos.RowCount > 0 Then

                Dim dtImprimirDigital As New DataTable

                dtImprimirDigital = oNotaCreditoService.ImprimirDigital(dgvDatos.CurrentRow.Cells("IdNota").Text).Tables(0)
                GridEX2.DataSource = dtImprimirDigital

                LegalMonetaryTotal = GridEX2.CurrentRow.Cells("LegalMonetaryTotal").Text
                CurrencyId = GridEX2.CurrentRow.Cells("CurrencyId").Text
                TipoDoc = GridEX2.CurrentRow.Cells("TipoDoc").Text
                TaxAmount = GridEX2.CurrentRow.Cells("TaxAmount").Text
                CodSerieFac = GridEX2.CurrentRow.Cells("CodSerie").Text
                NumDocFac = GridEX2.CurrentRow.Cells("NumDoc").Text
                DocumentoFac = GridEX2.CurrentRow.Cells("Documento").Text
                FecDoc = GridEX2.CurrentRow.Cells("FecDoc").Text
                RucEmp = GridEX2.CurrentRow.Cells("RucEmp").Text
                DniCli = GridEX2.CurrentRow.Cells("DniCli").Text
                RucCli = GridEX2.CurrentRow.Cells("RucCli").Text
                CodMon = GridEX2.CurrentRow.Cells("CodMon").Text
                TipoIdentidad = GridEX2.CurrentRow.Cells("TipoIdentidad").Text

                CrearCarpeta()
                CrearXML()
                ObtenerTagFirma()
                CrearPDF()
            Else
                MsgBox("No existe registros, tenga cuidado", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al descargar la nota electronica")
        End Try
    End Sub

    Private Sub CrearCarpeta()

        If Not Directory.Exists("D:\Documentos_Electronicos\Notas_Electronicas\" & GridEX2.CurrentRow.Cells("Documento").Text) Then
            Directory.CreateDirectory("D:\Documentos_Electronicos\Notas_Electronicas\" & GridEX2.CurrentRow.Cells("Documento").Text)
        End If

    End Sub

    Private Sub CrearXML()

        Try
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(New StringReader(oNotaDigitalService.Descargar(dgvDatos.CurrentRow.Cells("IdNota").Text)))

            NombreXMLPDF = oNotaDigitalService.ObtenerNombre(dgvDatos.CurrentRow.Cells("IdNota").Text)

            xmlDoc.Save("D:\Documentos_Electronicos\Notas_Electronicas\" & DocumentoFac & "\" & NombreXMLPDF & ".xml")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear el xml")
        End Try

    End Sub

    Private Sub ObtenerTagFirma()

        Try
            Dim xmlDoc As New XmlDocument
            Dim namespaces As XmlNamespaceManager = New XmlNamespaceManager(xmlDoc.NameTable)

            If IdDocumento = "5" Then
                namespaces.AddNamespace("ns", "urn:oasis:names:specification:ubl:schema:xsd:CreditNote-2")
            ElseIf IdDocumento = "6" Then
                namespaces.AddNamespace("ns", "urn:oasis:names:specification:ubl:schema:xsd:DebitNote-2")
            End If
            namespaces.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance")
            namespaces.AddNamespace("xsd", "http://www.w3.org/2001/XMLSchema")
            namespaces.AddNamespace("sac", "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")
            namespaces.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")
            namespaces.AddNamespace("qdt", "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2")
            namespaces.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")
            namespaces.AddNamespace("udt", "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2")
            namespaces.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")
            namespaces.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#")

            If IdDocumento = "5" Then

                xmlDoc.Load("D:\Documentos_Electronicos\Notas_Electronicas\" & DocumentoFac & "\" & Session.sRucEmp & "-07-" & DocumentoFac & ".xml")
                'xmlDoc.Load("D:\Documentos_Electronicos\Notas_Electronicas\" & DocumentoFac & "\20100020441-07-" & DocumentoFac & ".xml")
                Dim xPathStringInfo = "/ns:CreditNote/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent/ds:Signature[@Id='SignatureSP']/ds:SignedInfo"
                Dim xPathStringValue = "/ns:CreditNote/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent/ds:Signature[@Id='SignatureSP']/ds:SignatureValue"

                Dim oNodeInfo = xmlDoc.SelectSingleNode(xPathStringInfo, namespaces)
                ValorResumen = oNodeInfo.InnerText

                Dim oNodeValue = xmlDoc.SelectSingleNode(xPathStringValue, namespaces)
                ValorFirma = oNodeValue.InnerText

            ElseIf IdDocumento = "6" Then

                xmlDoc.Load("D:\Documentos_Electronicos\Notas_Electronicas\" & DocumentoFac & "\" & Session.sRucEmp & "-08-" & DocumentoFac & ".xml")
                'xmlDoc.Load("D:\Documentos_Electronicos\Notas_Electronicas\" & DocumentoFac & "\20100020441-08-" & DocumentoFac & ".xml")
                Dim xPathStringInfo = "/ns:DebitNote/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent/ds:Signature[@Id='SignatureSP']/ds:SignedInfo"
                Dim xPathStringValue = "/ns:DebitNote/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent/ds:Signature[@Id='SignatureSP']/ds:SignatureValue"

                Dim oNodeInfo = xmlDoc.SelectSingleNode(xPathStringInfo, namespaces)
                ValorResumen = oNodeInfo.InnerText

                Dim oNodeValue = xmlDoc.SelectSingleNode(xPathStringValue, namespaces)
                ValorFirma = oNodeValue.InnerText
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Obtener el Tag")
        End Try

    End Sub

       Private Sub CrearPDF()

        Try
            Dim qr As PDF417Writer = New PDF417Writer

            Dim url As String = RucEmp & "|" & TipoDoc & "|" & CodSerieFac & "|" & NumDocFac & "|" & FormatNumber(TaxAmount, 2) & "|" & FormatNumber(LegalMonetaryTotal, 2) & "|" & FecDoc.ToString("yyyy-MM-dd") & "|" & TipoIdentidad & "|" & IIf(TipoIdentidad = "1", DniCli, RucCli) & "|" & ValorResumen & "|" & ValorFirma


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
            UbicacionCodBarra = "D:\Documentos_Electronicos\Notas_Electronicas\" & DocumentoFac & "\" & DocumentoFac & ".png"
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
            Dim reporte As New rpImprimirNotaElectronica

            dtReporte = oNotaCreditoService.ImprimirDigital(dgvDatos.CurrentRow.Cells("IdNota").Text).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, GridEX2.CurrentRow.Cells("CodMon").Text))
                reporte.SetParameterValue("TipoDoc", IIf(IdDocumento = "5", "CREDITO", "DEBITO"))
                reporte.SetParameterValue("DocumentoCliente", IIf(TipoIdentidad = "1", "D.N.I. :", "R.U.C. :"))
                reporte.SetParameterValue("NroDocumentoCliente", IIf(TipoIdentidad = "1", DniCli, RucCli))
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
            Dim reporte As New rpImprimirNotaElectronicaMtuAmaz

            dtReporte = oNotaCreditoService.ImprimirDigital(dgvDatos.CurrentRow.Cells("IdNota").Text).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, GridEX2.CurrentRow.Cells("CodMon").Text))
                reporte.SetParameterValue("TipoDoc", IIf(IdDocumento = "5", "CREDITO", "DEBITO"))
                reporte.SetParameterValue("DocumentoCliente", IIf(TipoIdentidad = "1", "D.N.I. :", "R.U.C. :"))
                reporte.SetParameterValue("NroDocumentoCliente", IIf(TipoIdentidad = "1", DniCli, RucCli))
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
            diskOpts.DiskFileName = "D:\Documentos_Electronicos\Notas_Electronicas\" & DocumentoFac & "\" & NombreXMLPDF & ".pdf"

            rpt.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile
            rpt.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat

            If File.Exists(vFileName) Then
                File.Delete(vFileName)
            End If
            rpt.ExportOptions.DestinationOptions = diskOpts
            rpt.Export()

            MsgBox("Se descargo la nota electronica correctamente", MsgBoxStyle.Information)

        Catch ex As Exception
            Throw ex
        End Try

        Return vFileName
    End Function


End Class