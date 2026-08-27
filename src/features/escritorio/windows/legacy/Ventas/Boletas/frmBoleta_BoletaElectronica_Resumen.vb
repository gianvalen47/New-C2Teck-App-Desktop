Imports System.ServiceModel
Imports LibreriaFacturacion
Imports System.Xml
Imports System.Text
Imports System.IO
Imports Ionic.Zip

Public Class frmBoleta_BoletaElectronica_Resumen

    'Private oBoletaDigitalService As New BoletaDigitalService.BoletaDigitalServiceClient
    Private oBoletaService As New BoletaService.BoletaServiceClient

    Dim FecDoc As Date
    Dim DesEmp As String
    Dim DirEmp As String
    Dim Urbanizacion As String
    Dim CodUbigeo As String
    Dim Departamento As String
    Dim Provincia As String
    Dim Distrito As String
    Dim CodPais As String
    Dim RucEmp As String
    Dim TipoDoc As String
    Dim NumDoc As String
    Dim TipoIdentidad As String
    Dim RucCli As String
    Dim DniCli As String
    Dim DesCli As String
    Dim unitCode As String
    Dim CanMer As String
    Dim DesMer1 As String
    Dim ValorUnitario As Double
    Dim DscMer As Double
    Dim PrecioVenta As Double
    Dim CodigoPrecio As String
    Dim MontoIgv As Double
    Dim CodAfectacion As String
    Dim CodTributo As String
    Dim NomTributo As String
    Dim CodTributoInt As String
    Dim CodOtroTributo As String
    Dim TotVenta As Double
    Dim CodMot As String
    Dim ValorVenta As Double
    Dim TotIgv As Double
    Dim TotGasto As Double
    Dim CodOtroTributoDesc As String
    Dim TotDscto As Double
    Dim TotNeto As Double
    Dim CodMon As String
    Dim DesMon As String
    Dim CurrencyId As String
    Dim NumGuis As String
    Dim CodGuia As String
    Dim Item As Integer
    Dim CodMer As String
    Dim Observacion As String

    Private Sub frmBoleta_BoletaElectronica_Resumen_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oBoletaService.Close()
        Catch ex As TimeoutException
            oBoletaService.Abort()
        Catch ex As CommunicationException
            oBoletaService.Abort()
        End Try
    End Sub

    Private Sub frmBoleta_BoletaElectronica_Resumen_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmBoleta_BoletaElectronica_Resumen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        cbFecha.Value = Today

    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click

        CrearCarpeta()
        CrearXML()

    End Sub

    Private Sub CrearCarpeta()

        If Not Directory.Exists("D:\Documentos_Electronicos\Resumen_Boletas\" & cbFecha.Value.ToString("dd-MM-yyyy")) Then
            Directory.CreateDirectory("D:\Documentos_Electronicos\Resumen_Boletas\" & cbFecha.Value.ToString("dd-MM-yyyy"))
        End If

    End Sub

    Private Sub CrearXML()

        Try
            Dim dtReporte As New DataTable
            dtReporte = oBoletaService.ImprimirResumenDigital(cbFecha.Value).Tables(0)
            GridEX2.DataSource = dtReporte

            FecDoc = GridEx2.CurrentRow.Cells("FecDoc").Text
            DesEmp = GridEX2.CurrentRow.Cells("DesEmp").Text
            DirEmp = GridEX2.CurrentRow.Cells("DirEmp").Text
            Urbanizacion = IIf(IsDBNull(GridEX2.CurrentRow.Cells("Urbanizacion").Text), "", GridEX2.CurrentRow.Cells("Urbanizacion").Text)
            CodUbigeo = GridEX2.CurrentRow.Cells("CodUbigeo").Text
            Departamento = GridEX2.CurrentRow.Cells("Departamento").Text
            Provincia = GridEX2.CurrentRow.Cells("Provincia").Text
            Distrito = GridEX2.CurrentRow.Cells("Distrito").Text
            CodPais = GridEX2.CurrentRow.Cells("CodPais").Text
            RucEmp = GridEX2.CurrentRow.Cells("RucEmp").Text
            TipoDoc = GridEX2.CurrentRow.Cells("TipoDoc").Text
            NumDoc = GridEX2.CurrentRow.Cells("NumDoc").Text
            TipoIdentidad = GridEX2.CurrentRow.Cells("TipoIdentidad").Text
            RucCli = GridEX2.CurrentRow.Cells("RucCli").Text
            DniCli = GridEX2.CurrentRow.Cells("DniCli").Text
            DesCli = GridEX2.CurrentRow.Cells("DesCli").Text
            CodigoPrecio = GridEX2.CurrentRow.Cells("CodigoPrecio").Text
            CodAfectacion = GridEX2.CurrentRow.Cells("CodAfectacion").Text
            CodTributo = GridEX2.CurrentRow.Cells("CodTributo").Text
            NomTributo = GridEX2.CurrentRow.Cells("NomTributo").Text
            CodTributoInt = GridEX2.CurrentRow.Cells("CodTributoInt").Text
            CodOtroTributo = GridEX2.CurrentRow.Cells("CodOtroTributo").Text
            TotVenta = GridEX2.CurrentRow.Cells("TotVenta").Text
            CodMot = GridEX2.CurrentRow.Cells("CodMot").Text
            TotIgv = GridEX2.CurrentRow.Cells("TotIgv").Text
            CodOtroTributoDesc = GridEX2.CurrentRow.Cells("CodOtroTributoDesc").Text
            TotDscto = GridEX2.CurrentRow.Cells("TotDscto").Text
            TotNeto = GridEX2.CurrentRow.Cells("TotNeto").Text
            CodMon = GridEX2.CurrentRow.Cells("CodMon").Text
            DesMon = GridEX2.CurrentRow.Cells("DesMon").Text
            CurrencyId = GridEX2.CurrentRow.Cells("CurrencyId").Text
            NumGuis = GridEX2.CurrentRow.Cells("NumGuis").Text
            CodGuia = GridEX2.CurrentRow.Cells("CodGuia").Text
            Observacion = GridEX2.CurrentRow.Cells("Observacion").Text

            Dim W As New XmlTextWriter("D:\Documentos_Electronicos\Resumen_Boletas\" & cbFecha.Value.ToString("dd-MM-yyyy") & "\20100020441-RC-" & FecDoc.ToString("yyyyMMdd") & "-1" & ".xml", Encoding.GetEncoding("ISO-8859-1"))
            'Dim W As New XmlTextWriter("D:\resumenboletaselec.xml", Encoding.GetEncoding("ISO-8859-1"))

            'W. = Formatting.Indented

            W.WriteStartDocument(False)
            W.WriteStartElement("SummaryDocuments")

            W.WriteStartAttribute("xmlns")
            W.WriteValue("urn:sunat:names:specification:ubl:peru:schema:xsd:SummaryDocuments-1")
            W.WriteEndAttribute()

            W.WriteStartAttribute("xmlns:cac")
            W.WriteValue("urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")
            W.WriteEndAttribute()

            W.WriteStartAttribute("xmlns:cbc")
            W.WriteValue("urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")
            W.WriteEndAttribute()

            W.WriteStartAttribute("xmlns:ds")
            W.WriteValue("http://www.w3.org/2000/09/xmldsig#")
            W.WriteEndAttribute()

            W.WriteStartAttribute("xmlns:ext")
            W.WriteValue("urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")
            W.WriteEndAttribute()

            W.WriteStartAttribute("xmlns:sac")
            W.WriteValue("urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")
            W.WriteEndAttribute()


            W.WriteStartAttribute("xmlns:xsi")
            W.WriteValue("http://www.w3.org/2001/XMLSchema-instance")
            W.WriteEndAttribute()

            W.WriteStartAttribute("xsi:schemaLocation")
            W.WriteValue("urn:sunat:names:specification:ubl:peru:schema:xsd:InvoiceSummary-1 D:\UBL_SUNAT\SUNAT_xml_20110112\20110112\xsd\maindoc\UBLPE-InvoiceSummary-1.0.xsd")
            W.WriteEndAttribute()

            '----------------------------------------------------------------------Se inicia el Tag Extensions 

            W.WriteStartElement("ext:UBLExtensions")
            W.WriteStartElement("ext:UBLExtension")
            W.WriteStartElement("ext:ExtensionContent")

            W.WriteStartElement("ds:SignatureId")
            W.WriteValue("SignatureCA")
            W.WriteEndElement()


            W.WriteEndElement()
            W.WriteEndElement()

            ' Se agrega ublextension para la firma
            W.WriteStartElement("ext:UBLExtension")
            W.WriteStartElement("ext:ExtensionContent")

            W.WriteEndElement()
            W.WriteEndElement()
            '-------------------------------------


            W.WriteEndElement()             'Se cierra UBLExtensions

            '-----
            W.WriteStartElement("cbc:UBLVersionID")
            W.WriteValue("2.0")
            W.WriteEndElement()

            W.WriteStartElement("cbc:CustomizationID")
            W.WriteValue("1.0")
            W.WriteEndElement()

            Dim ID As String
            ID = "RC_" & FecDoc.ToString("yyyyMMdd") & "-001"

            W.WriteStartElement("cbc:ID")
            W.WriteValue(ID)
            W.WriteEndElement()

            W.WriteStartElement("cbc:ReferenceDate")
            W.WriteValue(FecDoc.ToString("yyyy-MM-dd"))
            W.WriteEndElement()

            W.WriteStartElement("cbc:IssueDate")
            W.WriteValue(FecDoc.ToString("yyyy-MM-dd"))
            W.WriteEndElement()

            W.WriteStartElement("cac:Signature")        '------------empieza Signature

            W.WriteStartElement("cbc:ID")
            W.WriteValue("IDSignCA")
            W.WriteEndElement()

            W.WriteStartElement("cac:SignatoryParty")
            W.WriteStartElement("cac:PartyIdentification")
            W.WriteStartElement("cbc:ID")
            W.WriteValue(RucEmp)
            W.WriteEndElement()
            W.WriteEndElement()

            W.WriteStartElement("cac:PartyName")
            W.WriteStartElement("cbc:Name")
            W.WriteValue(DesEmp)
            W.WriteEndElement()
            W.WriteEndElement()
            W.WriteEndElement()         ' Se cierra SignatoryParty

            W.WriteStartElement("cac:DigitalSignatureAttachment")
            W.WriteStartElement("cac:ExternalReference")
            W.WriteStartElement("cbc:URI")
            W.WriteValue("SignatureSP")
            W.WriteEndElement()

            W.WriteEndElement()
            W.WriteEndElement()
            W.WriteEndElement()                 '------------termina Signature

            W.WriteStartElement("cac:AccountingSupplierParty")
            W.WriteStartElement("cbc:CustomerAssignedAccountID")
            W.WriteValue(RucEmp)
            W.WriteEndElement()

            W.WriteStartElement("cbc:AdditionalAccountID")
            W.WriteValue("6")
            W.WriteEndElement()

            W.WriteStartElement("cac:Party")

            W.WriteStartElement("cac:PartylegalEntity")
            W.WriteStartElement("cbc:RegistrationName")
            W.WriteValue(DesEmp)
            W.WriteEndElement()
            W.WriteEndElement()                 'Se cierra Partylegalentity
            W.WriteEndElement()                 'Se cierra Party
            W.WriteEndElement()                 'Se cierra AccountingSupplierParty

            Dim row As Janus.Windows.GridEX.GridEXRow

            If GridEx2.RowCount > 0 Then
                For j = 0 To Me.GridEx2.RowCount - 1
                    Me.GridEx2.Row = j
                    row = Me.GridEx2.GetRow()

                    W.WriteStartElement("sac:SummaryDocumentsLine")
                    W.WriteStartElement("cbc:LineID")
                    W.WriteValue(j + 1)
                    W.WriteEndElement()

                    W.WriteStartElement("cbc:DocumentTypeCode")
                    W.WriteValue(row.Cells("TipoDoc").Value)
                    W.WriteEndElement()

                    W.WriteStartElement("sac:DocumentSerialID")
                    W.WriteValue(row.Cells("NumDoc").Value)
                    W.WriteEndElement()

                    W.WriteStartElement("sac:StartDocumentNumberID")
                    W.WriteValue("451")
                    W.WriteEndElement()

                    W.WriteStartElement("sac:EndDocumentNumberID")
                    W.WriteValue("764")
                    W.WriteEndElement()

                    W.WriteStartElement("sac:TotalAmount")

                    W.WriteStartAttribute("currencyID")
                    W.WriteValue(CurrencyId)
                    W.WriteEndAttribute()

                    W.WriteValue(row.Cells("TotNeto").Value)
                    W.WriteEndElement()             'Finalizar TotalAmount

                    W.WriteStartElement("sac:BillingPayment")
                    W.WriteStartElement("cbc:PaidAmount")

                    W.WriteStartAttribute("currencyID")
                    W.WriteValue(CurrencyId)
                    W.WriteEndAttribute()

                    W.WriteValue(row.Cells("TotVenta").Value)
                    W.WriteEndElement()

                    W.WriteStartElement("cbc:InstructionID")

                    W.WriteValue("01")
                    W.WriteEndElement()
                    W.WriteEndElement()             'Finalizar el 1er BillingPayment

                    W.WriteStartElement("sac:BillingPayment")
                    W.WriteStartElement("cbc:PaidAmount")

                    W.WriteStartAttribute("currencyID")
                    W.WriteValue(CurrencyId)
                    W.WriteEndAttribute()

                    W.WriteValue("0.00")
                    W.WriteEndElement()

                    W.WriteStartElement("cbc:InstructionID")

                    W.WriteValue("02")
                    W.WriteEndElement()
                    W.WriteEndElement()             'Finalizar el 2do BillingPayment

                    W.WriteStartElement("sac:BillingPayment")
                    W.WriteStartElement("cbc:PaidAmount")

                    W.WriteStartAttribute("currencyID")
                    W.WriteValue(CurrencyId)
                    W.WriteEndAttribute()

                    W.WriteValue("0.00")
                    W.WriteEndElement()

                    W.WriteStartElement("cbc:InstructionID")

                    W.WriteValue("03")
                    W.WriteEndElement()
                    W.WriteEndElement()              'Finalizar el 3er BillingPayment

                    W.WriteStartElement("cac:AllowanceCharge")

                    W.WriteStartElement("cbc:ChargeIndicator")
                    W.WriteValue("true")
                    W.WriteEndElement()

                    W.WriteStartElement("cbc:Amount")

                    W.WriteStartAttribute("currencyID")
                    W.WriteValue(CurrencyId)
                    W.WriteEndAttribute()

                    W.WriteValue("0.00")
                    W.WriteEndElement()

                    W.WriteEndElement()         'Finaliza AllowanceCharge

                    '-----------------------------------TotISC

                    W.WriteStartElement("cac:TaxTotal")
                    W.WriteStartElement("cbc:TaxAmount")
                    W.WriteStartAttribute("currencyID")
                    W.WriteValue(CurrencyId)
                    W.WriteEndAttribute()
                    W.WriteValue("0.00")
                    W.WriteEndElement()

                    W.WriteStartElement("cac:TaxSubTotal")
                    W.WriteStartElement("cbc:TaxAmount")
                    W.WriteStartAttribute("currencyID")
                    W.WriteValue(CurrencyId)
                    W.WriteEndAttribute()
                    W.WriteValue("0.00")
                    W.WriteEndElement()

                    W.WriteStartElement("cac:TaxCategory")

                    W.WriteStartElement("cac:TaxScheme")

                    W.WriteStartElement("cbc:ID")
                    W.WriteValue(CodTributo)
                    W.WriteEndElement()

                    W.WriteStartElement("cbc:Name")
                    W.WriteValue(NomTributo)
                    W.WriteEndElement()

                    W.WriteStartElement("cbc:TaxTypeCode")
                    W.WriteValue(CodTributoInt)
                    W.WriteEndElement()

                    W.WriteEndElement()     'Se cierra TaxScheme
                    W.WriteEndElement()     'Se cierra TaxCategory
                    W.WriteEndElement()     'Se cierra TaxSubTotal
                    W.WriteEndElement()     'Se cierra TaxTotal

                    '---------------------------------- FIN TotISC
                    '---------------------------------- Total IGV

                    W.WriteStartElement("cac:TaxTotal")
                    W.WriteStartElement("cbc:TaxAmount")
                    W.WriteStartAttribute("currencyID")
                    W.WriteValue(CurrencyId)
                    W.WriteEndAttribute()
                    W.WriteValue(TotIgv)
                    W.WriteEndElement()

                    W.WriteStartElement("cac:TaxSubTotal")
                    W.WriteStartElement("cbc:TaxAmount")
                    W.WriteStartAttribute("currencyID")
                    W.WriteValue(CurrencyId)
                    W.WriteEndAttribute()
                    W.WriteValue(TotIgv)
                    W.WriteEndElement()

                    W.WriteStartElement("cac:TaxCategory")

                    W.WriteStartElement("cac:TaxScheme")

                    W.WriteStartElement("cbc:ID")
                    W.WriteValue(CodTributo)
                    W.WriteEndElement()

                    W.WriteStartElement("cbc:Name")
                    W.WriteValue(NomTributo)
                    W.WriteEndElement()

                    W.WriteStartElement("cbc:TaxTypeCode")
                    W.WriteValue(CodTributoInt)
                    W.WriteEndElement()

                    W.WriteEndElement()     'Se cierra TaxScheme
                    W.WriteEndElement()     'Se cierra TaxCategory
                    W.WriteEndElement()     'Se cierra TaxSubTotal
                    W.WriteEndElement()     'Se cierra TaxTotal

                    '-----------------------------------  FIN TotalIGV
                    '---------------------------------- Total Otros Tributos

                    W.WriteStartElement("cac:TaxTotal")
                    W.WriteStartElement("cbc:TaxAmount")
                    W.WriteStartAttribute("currencyID")
                    W.WriteValue(CurrencyId)
                    W.WriteEndAttribute()
                    W.WriteValue("0.00")
                    W.WriteEndElement()

                    W.WriteStartElement("cac:TaxSubTotal")
                    W.WriteStartElement("cbc:TaxAmount")
                    W.WriteStartAttribute("currencyID")
                    W.WriteValue(CurrencyId)
                    W.WriteEndAttribute()
                    W.WriteValue("0.00")
                    W.WriteEndElement()

                    W.WriteStartElement("cac:TaxCategory")
                    W.WriteStartElement("cac:TaxScheme")

                    W.WriteStartElement("cbc:ID")
                    W.WriteValue(CodTributo)
                    W.WriteEndElement()

                    W.WriteStartElement("cbc:Name")
                    W.WriteValue(NomTributo)
                    W.WriteEndElement()

                    W.WriteStartElement("cbc:TaxTypeCode")
                    W.WriteValue(CodTributoInt)
                    W.WriteEndElement()

                    W.WriteEndElement()     'Se cierra TaxScheme
                    W.WriteEndElement()     'Se cierra TaxCategory
                    W.WriteEndElement()     'Se cierra TaxSubTotal
                    W.WriteEndElement()     'Se cierra TaxTotal

                    '-------------------    'FIN Otros Tributos
                    W.WriteEndElement()     'Se cierra SumatoryDocumentsLine

                Next
            End If
            'W.WriteEndElement()    'se cierra InvoiceLine

            W.WriteEndElement()     'finaliza comprobante
            W.WriteEndDocument()    'finaliza documento

            W.Flush()
            W.Close()

            FirmadoDigital()

        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub FirmadoDigital()
        'Firmando xml 
        Dim ObjLib As New FirmarDocumento

        Dim direccion As String
        Dim firmado As Boolean
        direccion = "D:\Documentos_Electronicos\Resumen_Boletas\" & cbFecha.Value.ToString("dd-MM-yyyy") & "\20100020441-RC-" & FecDoc.ToString("yyyyMMdd") & "-1" & ".xml"

        Dim ruta As String = System.AppDomain.CurrentDomain.BaseDirectory & "Certificado\CertificadoFacturacion.pfx"
        'firmado = ObjLib.SignXmlFile("20100020441", "D:\Documentos_Electronicos\xadesnettest.p12", "xadesnet", direccion)
        firmado = ObjLib.SignXmlFile("20100020441", 1, ruta, "123456", direccion)

        If firmado = True Then
            'MsgBox("Se genero el firmado", MsgBoxStyle.Information)

            Dim xmlDoc As New XmlDocument
            xmlDoc.Load("D:\Documentos_Electronicos\Resumen_Boletas\" & cbFecha.Value.ToString("dd-MM-yyyy") & "\20100020441-RC-" & FecDoc.ToString("yyyyMMdd") & "-1" & ".xml")

            'ValorResumen = xmlDoc.SelectSingleNode("/ext:UBLExtensions/ext:UBLExtension/ext:UBLExtensionContent/category[@name='a']/SubCategoryName").Value
            'ValorResumen = xmlDoc.SelectSingleNode("/DigestValue").InnerText
            'ValorFirma = xmlDoc.SelectSingleNode("/SignatureValue").InnerText

            'Comentado para pruebas ====================================================================================
            'Dim insertar As Boolean
            ''Dim nombrexml As String = GridEX1.CurrentRow.Cells("NumDoc").Text & ".xml"     'Comentado para que en el evento de descargar se obtenga el numdoc sin el ".xml"
            'Dim nombrexml As String = "20100020441-01-" & GridEX1.CurrentRow.Cells("NumDoc").Text '& ".xml"
            'insertar = oFacturaDigitalService.Insertar(IdFactura, nombrexml, xmlDoc.OuterXml, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            'If insertar = True Then
            '    Comprimir()
            'End If

        End If

    End Sub

    Private Sub Comprimir()

        Dim destdir As String = "D:\Documentos_Electronicos\Resumen_Boletas\" & cbFecha.Value.ToString("dd-MM-yyyy") & "\20100020441-RC-" & FecDoc.ToString("yyyyMMdd") & "-1" & ".zip"

        Dim zip As ZipFile = New ZipFile
        Dim directorio As String = "D:\Documentos_Electronicos\Resumen_Boletas\" & cbFecha.Value.ToString("dd-MM-yyyy")
        zip.AddDirectory(directorio)
        zip.Save(destdir)

    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class