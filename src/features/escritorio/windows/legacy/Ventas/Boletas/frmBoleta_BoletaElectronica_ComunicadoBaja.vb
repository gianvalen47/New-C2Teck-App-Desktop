Imports System.ServiceModel
Imports LibreriaFacturacion
Imports System.Xml
Imports System.Text
Imports System.IO
Imports System
Imports UblLarsen.Ubl2
Imports System.Xml.Serialization
Imports UblLarsen.Ubl2.Cac
Imports UblLarsen.Ubl2.Udt
Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography.X509Certificates
Imports UblLarsen.Ubl2.aplicacion
Imports Ionic.Zip
Imports FacturarSunat.aplicacion

Public Class frmBoleta_BoletaElectronica_ComunicadoBaja

    Private oBoletaService As New BoletaService.BoletaServiceClient
    Private oComunicacionBajaDigitalService As New ComunicacionBajaDigitalService.ComunicacionBajaDigitalServiceClient

    Public IdBoleta As Integer
    Public DesCli As String
    Public CodMon As String
    Public TotNeto As Decimal

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
    Dim CodSerie As String
    Dim NumDoc As String
    Dim Documento As String
    Dim Observacion As String
    Dim CurrencyId As String
    Dim IdSerieDoc As String

    Private Sub frmBoleta_BoletaElectronica_ComunicadoBaja_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oBoletaService.Close()
            oComunicacionBajaDigitalService.Close()
        Catch ex As TimeoutException
            oBoletaService.Close()
            oComunicacionBajaDigitalService.Close()
        Catch ex As CommunicationException
            oBoletaService.Abort()
            oComunicacionBajaDigitalService.Abort()
        End Try
    End Sub

    Private Sub frmBoleta_BoletaElectronica_ComunicadoBaja_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmBoleta_BoletaElectronica_ComunicadoBaja_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Dim dtDarBaja As New DataTable

            dtDarBaja = oBoletaService.ComunicacionBajaDigital(IdBoleta).Tables(0)
            GridEX1.DataSource = dtDarBaja

            FecDoc = GridEX1.CurrentRow.Cells("FecDoc").Text
            DesEmp = GridEX1.CurrentRow.Cells("DesEmp").Text
            DirEmp = GridEX1.CurrentRow.Cells("DirEmp").Text
            Urbanizacion = IIf(IsDBNull(GridEX1.CurrentRow.Cells("Urbanizacion").Text), "", GridEX1.CurrentRow.Cells("Urbanizacion").Text)
            CodUbigeo = GridEX1.CurrentRow.Cells("CodUbigeo").Text
            Departamento = GridEX1.CurrentRow.Cells("Departamento").Text
            Provincia = GridEX1.CurrentRow.Cells("Provincia").Text
            Distrito = GridEX1.CurrentRow.Cells("Distrito").Text
            CodPais = GridEX1.CurrentRow.Cells("CodPais").Text
            RucEmp = GridEX1.CurrentRow.Cells("RucEmp").Text
            TipoDoc = GridEX1.CurrentRow.Cells("TipoDoc").Text
            CodSerie = GridEX1.CurrentRow.Cells("CodSerie").Text
            NumDoc = GridEX1.CurrentRow.Cells("NumDoc").Text
            Documento = GridEX1.CurrentRow.Cells("Documento").Text
            Observacion = GridEX1.CurrentRow.Cells("Observacion").Text
            CurrencyId = GridEX1.CurrentRow.Cells("CurrencyId").Text
            IdSerieDoc = GridEX1.CurrentRow.Cells("IdSerieDoc").Text

            txtCodSerie.Text = GridEX1.CurrentRow.Cells("CodSerie").Text
            txtNumDoc.Text = GridEX1.CurrentRow.Cells("NumDoc").Text
            'txtFecDoc.Value = CDate(GridEX1.CurrentRow.Cells("FecDoc").Text)
            txtFecDoc.Value = Session.sFecha
            txtCliente.Text = DesCli
            txtMoneda.Text = CodMon
            txtImporte.Text = TotNeto

            txtMotivo.Focus()
            txtMotivo.Select()

        Catch ex As Exception
            MsgBox("Error al crear el detalle xml : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub CrearCarpeta()

        If Not Directory.Exists("D:\Documentos_Electronicos\Comunicacion_de_Baja\" & GridEX1.CurrentRow.Cells("Documento").Text) Then
            Directory.CreateDirectory("D:\Documentos_Electronicos\Comunicacion_de_Baja\" & GridEX1.CurrentRow.Cells("Documento").Text)
        End If

    End Sub

    Private Sub CrearXMLSerializado()

        Try
            '============================================================================================================================= Creacion de XML

            Dim FecDocForm As String
            FecDocForm = Today.Date.ToString("yyyyMMdd")  ' 'FecDoc.ToString("yyyyMMdd")

            Dim NumCorrelativo As String
            NumCorrelativo = oComunicacionBajaDigitalService.ObtenerNumero(Session.sCodEmp)

            'Dim xmlFilename As String = "D:\Documentos_Electronicos\Comunicacion_de_Baja\" & "FF11-119026" & "\20100020441-RA-" & FecDoc.ToString("yyyyMMdd") & "-1" & ".xml"
            Dim xmlFilename As String = "D:\Documentos_Electronicos\Comunicacion_de_Baja\" & GridEX1.CurrentRow.Cells("Documento").Text & "\" & Session.sRucEmp & "-RA-" & FecDocForm & "-" & NumCorrelativo & ".xml"
            'Dim xmlFilename As String = "D:\Documentos_Electronicos\Comunicacion_de_Baja\" & GridEX1.CurrentRow.Cells("Documento").Text & "\20100020441-RA-" & FecDocForm & "-" & NumCorrelativo & ".xml"

            UblLarsen.Ubl2.UblBaseDocumentType.GlbCustomizationID = "1.0"

            AmountType.TlsDefaultCurrencyID = CurrencyId

            Dim line1 As VoidedDocumentsLineType() = Nothing

            Dim row As Janus.Windows.GridEX.GridEXRow

            If GridEX1.RowCount > 0 Then
                Dim cantline As Integer = GridEX1.RowCount
                line1 = New VoidedDocumentsLineType(cantline) {}

                For j = 0 To GridEX1.RowCount - 1
                    Me.GridEX1.Row = j
                    row = Me.GridEX1.GetRow()

                    'line1(j) = New VoidedDocumentsLineType() With { _
                    '       .LineID = j + 1, _
                    '       .DocumentTypeCode = TipoDoc, _
                    '       .DocumentSerialID = "FF11", _
                    '       .DocumentNumberID = "119026", _
                    '       .VoidReasonDescription = New TextType() {CStr(Observacion)} _
                    '}

                    line1(j) = New VoidedDocumentsLineType() With { _
                            .LineID = j + 1, _
                            .DocumentTypeCode = TipoDoc, _
                            .DocumentSerialID = CodSerie, _
                            .DocumentNumberID = NumDoc, _
                            .VoidReasonDescription = New TextType() {CStr(txtMotivo.Text.Trim)} _
                    }

                Next

            End If

            FacturacionElectronica.GenerarVoidedDocuments(xmlFilename, Session.sRucEmp, Session.sDesEmp, CurrencyId, "RA-" & FecDocForm & "-" & NumCorrelativo, Today.Date, FecDoc, line1)
            'FacturacionElectronica.GenerarVoidedDocuments(xmlFilename, CurrencyId, NumDoc, FecDoc, Today.Date, line1)

            '===================================================================================================================== Firmar Documento

            Dim ObjLib As New FirmarDocumento

            Dim direccion As String
            Dim firmado As Boolean
            direccion = xmlFilename
            'direccion = "D:\Documentos_Electronicos\Facturas_Electronicas\" & GridEX1.CurrentRow.Cells("NumDoc").Text & "\20100020441-01-" & GridEX1.CurrentRow.Cells("NumDoc").Text & ".xml"

            Dim ruta As String = System.AppDomain.CurrentDomain.BaseDirectory & "Certificado\" & Session.sNombreCertificado
            'Dim ruta As String = System.AppDomain.CurrentDomain.BaseDirectory & "Certificado\CertificadoFacturacion.pfx"
            'firmado = ObjLib.SignXmlFile("20100020441", "D:\Documentos_Electronicos\xadesnettest.p12", "xadesnet", direccion)
            'activar -------------------------------------------------------------------------------------------------------------------------------------------------------------
            firmado = ObjLib.SignXmlFile(Session.sRucEmp, 5, ruta, Session.sClaveCertificado, direccion)
            'firmado = ObjLib.SignXmlFile("20100020441", 5, ruta, "DdperU", direccion)

            If firmado = True Then
                'MsgBox("Se genero el firmado", MsgBoxStyle.Information)

                '==== Comprimir=========
                Dim destdir As String = "D:\Documentos_Electronicos\Comunicacion_de_Baja\" & GridEX1.CurrentRow.Cells("Documento").Text & "\" & Session.sRucEmp & "-RA-" & FecDocForm & "-" & NumCorrelativo & ".zip"
                'Dim destdir As String = "D:\Documentos_Electronicos\Comunicacion_de_Baja\" & GridEX1.CurrentRow.Cells("Documento").Text & "\20100020441-RA-" & FecDocForm & "-" & NumCorrelativo & ".zip"
                Dim zip As ZipFile = New ZipFile

                Dim filexml As String = "D:\Documentos_Electronicos\Comunicacion_de_Baja\" & GridEX1.CurrentRow.Cells("Documento").Text & "\" & Session.sRucEmp & "-RA-" & FecDocForm & "-" & NumCorrelativo & ".xml"
                'Dim filexml As String = "D:\Documentos_Electronicos\Comunicacion_de_Baja\" & GridEX1.CurrentRow.Cells("Documento").Text & "\20100020441-RA-" & FecDocForm & "-" & NumCorrelativo & ".xml"
                zip.AddFile(filexml, "")
                zip.Save(destdir)
                '===========================

                '=====ENVIAR SUNAT=======
                Dim oComunicacionSunat As New ComunicacionSunat
                Dim numeroTicket As String = ""
                Dim rutaenvio As String = "D:\Documentos_Electronicos\Comunicacion_de_Baja\" & GridEX1.CurrentRow.Cells("Documento").Text & "\"
                Dim file As String = Session.sRucEmp & "-RA-" & FecDocForm & "-" & NumCorrelativo & ".zip"
                'Dim file As String = "20100020441-RA-" & FecDocForm & "-" & NumCorrelativo & ".zip"
                Dim nombrexml As String = Session.sRucEmp & "-RA-" & FecDocForm & "-" & NumCorrelativo
                'Dim nombrexml As String = "20100020441-RA-" & FecDocForm & "-" & NumCorrelativo
                numeroTicket = oComunicacionSunat.EnviarSummarySunat(rutaenvio, file)
                '========================

                '======INSERTAR COMUNICACION DE BAJA=====
                Dim xmlDoc As New XmlDocument
                xmlDoc.Load("D:\Documentos_Electronicos\Comunicacion_de_Baja\" & GridEX1.CurrentRow.Cells("Documento").Text & "\" & Session.sRucEmp & "-RA-" & FecDocForm & "-" & NumCorrelativo & ".xml")
                'xmlDoc.Load("D:\Documentos_Electronicos\Comunicacion_de_Baja\" & GridEX1.CurrentRow.Cells("Documento").Text & "\20100020441-RA-" & FecDocForm & "-" & NumCorrelativo & ".xml")

                Dim registro As New ComunicacionBajaDigitalService.ComunicacionBajaDigital
                Dim empresa As New ComunicacionBajaDigitalService.Empresa
                Dim tipodoc As New ComunicacionBajaDigitalService.TipoDocumento
                Dim seriedoc As New ComunicacionBajaDigitalService.SerieDocumento
                registro.IdComunicacion = "RA-" & FecDocForm & "-" & NumCorrelativo
                empresa.CodEmp = Session.sCodEmp
                registro.Empresa = empresa
                tipodoc.IdDocumento = 2
                registro.TipoDocumento = tipodoc
                seriedoc.IdSerieDoc = CInt(IdSerieDoc)
                registro.SerieDocumento = seriedoc
                registro.NumDoc = txtNumDoc.Text.Trim
                registro.DocumentoTexto = xmlDoc.OuterXml
                registro.NombreXml = nombrexml
                registro.Motivo = txtMotivo.Text.Trim
                registro.Fecha = Today.Date
                registro.NumTicket = numeroTicket
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                'Comentado para pruebas ====================================================================================
                Dim insertar As Boolean
                'Dim nombrexml As String = GridEX1.CurrentRow.Cells("NumDoc").Text & ".xml"     'Comentado para que en el evento de descargar se obtenga el numdoc sin el ".xml"
                'Dim nombrexml As String = "20100020441-01-" & GridEX1.CurrentRow.Cells("NumDoc").Text '& ".xml"
                insertar = oComunicacionBajaDigitalService.Insertar(registro)
                '===========================================

                If insertar = True Then
                    ''====OBTENER CDR RESPUESTA SUNAT===== 
                    'Dim resul As Boolean = False
                    'resul = oComunicacionSunat.ObtenerEstadoSunat(rutaenvio, file, numeroTicket)
                    ''====================================

                    ''========ACTUALIZAR CDR RESPUESTA SUNAT========
                    'If resul Then
                    '    Dim xmlDocR As New XmlDocument
                    '    xmlDocR.Load("D:\Documentos_Electronicos\Comunicacion_de_Baja\" & GridEX1.CurrentRow.Cells("Documento").Text & "\R-20100020441-RA-" & FecDocForm & "-" & NumCorrelativo & ".xml")

                    '    '/////////OBTENER ESTADO E INFORMACION DEL CDR SUNAT/////////////////////////
                    '    Dim namespaces As XmlNamespaceManager = New XmlNamespaceManager(xmlDocR.NameTable)
                    '    namespaces.AddNamespace("ns", "urn:oasis:names:specification:ubl:schema:xsd:ApplicationResponse-2")
                    '    namespaces.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")
                    '    namespaces.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")
                    '    namespaces.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#")
                    '    namespaces.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")

                    '    Dim notecompilado As String = ""
                    '    Dim contador As Integer = 0
                    '    Dim xnList As XmlNodeList = xmlDoc.SelectNodes("/ns:ApplicationResponse/cbc:Note", namespaces)
                    '    For Each xn As XmlNode In xnList
                    '        notecompilado = notecompilado & xnList.Item(contador).InnerText & ". " & Environment.NewLine
                    '        contador = contador + 1
                    '    Next

                    '    Dim xPathString = "/ns:ApplicationResponse/cac:DocumentResponse/cac:Response/cbc:Description"
                    '    Dim xPathString2 = "/ns:ApplicationResponse/cac:DocumentResponse/cac:Response/cbc:ResponseCode"
                    '    'Dim xPathString3 = "/ns:ApplicationResponse/cbc:ID"
                    '    Dim oNode = xmlDocR.SelectSingleNode(xPathString, namespaces)
                    '    Dim oNode2 = xmlDocR.SelectSingleNode(xPathString2, namespaces)
                    '    'Dim oNode3 = xmlDocR.SelectSingleNode(xPathString3, namespaces)
                    '    Dim Descripcioncdr As String = oNode.InnerText
                    '    Dim Responsecode As String = oNode2.InnerText
                    '    'Dim NumTicket As String = oNode3.InnerText
                    '    '///////////////////////////////////////////////////////////////////////////

                    '    registro.Estado = Responsecode
                    '    registro.Observacion = Descripcioncdr
                    '    registro.CDRxml = xmlDocR.OuterXml
                    '    registro.Notas = toNull(notecompilado)
                    '    oComunicacionBajaDigitalService.ActualizarRespuestaSunat(registro)

                    MsgBox("Se genero el comunicado de baja correctamente", MsgBoxStyle.Information)
                    'End If

                End If
            End If

            '======================================================================================================================= Firmar Documento
        Catch ex As Exception
            MsgBox("Error al crear el xml : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim TienePagos As Boolean
            TienePagos = oComunicacionBajaDigitalService.BuscarPagoDoc(IdSerieDoc, NumDoc)

            If TienePagos Then
                MsgBox("Este documento tiene pagos realizados, no se puede dar de baja. ", MsgBoxStyle.Information)
            Else

                If MsgBox("¿Está seguro de generar la comunicación de baja del comprobante N° " & Documento & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    CrearCarpeta()
                    CrearXMLSerializado()

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            End If

        Catch ex As Exception
            MsgBox("Error al crear el comunicado de baja: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class