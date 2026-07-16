Imports System
Imports System.IO
Imports System.ServiceModel
Imports System.Xml
Imports System.Xml.Schema
Imports System.Text
Imports System.Net.Mail
Imports Ionic.Zip
Imports LibreriaFacturacion
Imports UblLarsen.Ubl2
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Collections.Generic
Imports System.Linq
Imports System.Xml.Linq
Imports ZXing
Imports ZXing.PDF417
Imports ZXing.PDF417.Internal
Imports System.Xml.Serialization

Imports UblLarsen.Ubl2.Cac
Imports UblLarsen.Ubl2.Udt
Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography.X509Certificates
Imports UblLarsen.Ubl2.aplicacion
Imports FacturarSunat.aplicacion
Imports FacturarSunat21.aplicacion

Public Class frmNotaCredito_NotaElectronica

    Public IdNota As Integer
    Public TipoDocElec As String
    Public EstadoSunat As Boolean

    Private oMaestroService As New MaestroService.MaestroClient
    Private oNotaCreditoService As New NotaCreditoService.NotaCreditoServiceClient
    Private oNotaDigitalService As New NotaDigitalService.NotaDigitalServiceClient
    Private oTesoreriaService As New TesoreriaService.TesoreriaServiceClient
    Private oComunicacionSunat As New ComunicacionSunat
    Private oUsuarioClienteService As New UsuarioClienteService.UsuarioClienteServiceClient

    Public IdDocumento As Integer
    Public opcionimp As String
    Public TotalSoles As String

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
    Dim TipoIdentidad As String
    Dim IdCliente As String
    Dim RucCli As String
    Dim DniCli As String
    Dim DesCli As String
    Dim unitCode As String
    Dim CanMer As String
    Dim DesMer1 As String
    Dim ValorUnitario As Double
    Dim DscMer As Double
    Dim Pricingreference As Double
    Dim CodigoPrecio As String
    Dim MontoIgv As Double
    Dim CodAfectacion As String
    Dim CodTributo As String
    Dim NomTributo As String
    Dim CodTributoInt As String
    Dim CodOtroTributo As String
    Dim TotVenta As Double
    Dim CodMot As String
    Dim LineExtensionAmount As Double
    Dim Price As Double
    Dim TaxAmount As Double
    Dim CodOtroTributoDesc As String
    Dim TotDscto As Double
    Dim LegalMonetaryTotal As Double
    Dim CodMon As String
    Dim DesMon As String
    Dim CurrencyId As String
    Dim NumGuis As String
    Dim CodGuia As String
    Dim Item As Integer
    Dim CodMer As String
    Dim Observacion As String
    Dim Igv As Integer

    Dim CodTipoCre As String
    Dim CodSerieRef As String
    Dim NumDocRef As String
    Dim CodTipoDeb As String
    Dim NumDocModifica As String
    Dim TipoDocModifica As String
    Dim NumGuiaRef As String
    Dim MotivoRef As String
    Dim InstructionID As String

    Dim Responsecode As String
    Dim UbicacionCodBarra As String
    Dim ValorResumen As String
    Dim ValorFirma As String

    Dim DireccionFiscal As String
    Dim CodUbigeoRec As String
    Dim NomDistRec As String
    Dim NomProvRec As String
    Dim NomDptoRec As String
    Dim CodEstablecimiento As String

    Dim TotNetoLetras As String


    Private Sub frmNotaCredito_NotaElectronica_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oNotaCreditoService.Close()
            oNotaDigitalService.Close()
            oTesoreriaService.Close()
            oUsuarioClienteService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oNotaCreditoService.Abort()
            oNotaDigitalService.Abort()
            oTesoreriaService.Abort()
            oUsuarioClienteService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oNotaCreditoService.Abort()
            oNotaDigitalService.Abort()
            oTesoreriaService.Abort()
            oUsuarioClienteService.Abort()
        End Try
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub frmNotaCredito_NotaElectronica_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub frmNotaCredito_NotaElectronica_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Dim dtReporte As New DataTable
            dtReporte = oNotaCreditoService.ImprimirDigital(IdNota).Tables(0)
            DataGridView1.DataSource = dtReporte
            GridEX1.DataSource = dtReporte

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
            TipoIdentidad = GridEX1.CurrentRow.Cells("TipoIdentidad").Text
            IdCliente = GridEX1.CurrentRow.Cells("IdCliente").Text
            RucCli = GridEX1.CurrentRow.Cells("RucCli").Text
            DniCli = GridEX1.CurrentRow.Cells("DniCli").Text
            DesCli = GridEX1.CurrentRow.Cells("DesCli").Text
            unitCode = GridEX1.CurrentRow.Cells("unitCode").Text
            CanMer = GridEX1.CurrentRow.Cells("CanMer").Text
            DesMer1 = GridEX1.CurrentRow.Cells("DesMer1").Text
            ValorUnitario = GridEX1.CurrentRow.Cells("ValorUnitario").Text
            DscMer = GridEX1.CurrentRow.Cells("DscMer").Text
            Pricingreference = GridEX1.CurrentRow.Cells("Pricingreference").Text
            CodigoPrecio = GridEX1.CurrentRow.Cells("CodigoPrecio").Text
            MontoIgv = GridEX1.CurrentRow.Cells("MontoIgv").Text
            CodAfectacion = GridEX1.CurrentRow.Cells("CodAfectacion").Text
            CodTributo = GridEX1.CurrentRow.Cells("CodTributo").Text
            NomTributo = GridEX1.CurrentRow.Cells("NomTributo").Text
            CodTributoInt = GridEX1.CurrentRow.Cells("CodTributoInt").Text
            CodOtroTributo = GridEX1.CurrentRow.Cells("CodOtroTributo").Text
            TotVenta = GridEX1.CurrentRow.Cells("TotVenta").Text
            CodMot = GridEX1.CurrentRow.Cells("CodMot").Text
            LineExtensionAmount = GridEX1.CurrentRow.Cells("LineExtensionAmount").Text
            Price = GridEX1.CurrentRow.Cells("Price").Text
            TaxAmount = GridEX1.CurrentRow.Cells("TaxAmount").Text
            'TotGasto = GridEX1.CurrentRow.Cells("TotGasto").Text
            CodOtroTributoDesc = GridEX1.CurrentRow.Cells("CodOtroTributoDesc").Text
            TotDscto = GridEX1.CurrentRow.Cells("TotDscto").Text
            LegalMonetaryTotal = GridEX1.CurrentRow.Cells("LegalMonetaryTotal").Text
            CodMon = GridEX1.CurrentRow.Cells("CodMon").Text
            DesMon = GridEX1.CurrentRow.Cells("DesMon").Text
            CurrencyId = GridEX1.CurrentRow.Cells("CurrencyId").Text
            NumGuis = GridEX1.CurrentRow.Cells("NumGuis").Text
            CodGuia = GridEX1.CurrentRow.Cells("CodGuia").Text
            Item = GridEX1.CurrentRow.Cells("Item").Text
            CodMer = GridEX1.CurrentRow.Cells("CodMer").Text
            Observacion = GridEX1.CurrentRow.Cells("Observacion").Text
            Igv = GridEX1.CurrentRow.Cells("Igv").Text

            CodTipoCre = GridEX1.CurrentRow.Cells("CodTipoCre").Text
            CodSerieRef = GridEX1.CurrentRow.Cells("CodSerieRef").Text
            NumDocRef = GridEX1.CurrentRow.Cells("NumDocRef").Text
            CodTipoDeb = GridEX1.CurrentRow.Cells("CodTipoDeb").Text
            NumDocModifica = GridEX1.CurrentRow.Cells("NumDocModifica").Text
            TipoDocModifica = GridEX1.CurrentRow.Cells("TipoDocModifica").Text
            NumGuiaRef = GridEX1.CurrentRow.Cells("NumGuiaRef").Text
            MotivoRef = GridEX1.CurrentRow.Cells("MotivoRef").Text
            InstructionID = GridEX1.CurrentRow.Cells("InstructionID").Text

            DireccionFiscal = GridEX1.CurrentRow.Cells("DireccionFiscal").Text
            CodUbigeoRec = GridEX1.CurrentRow.Cells("CodUbigeoRec").Text
            NomDistRec = GridEX1.CurrentRow.Cells("NomDistRec").Text
            NomProvRec = GridEX1.CurrentRow.Cells("NomProvRec").Text
            NomDptoRec = GridEX1.CurrentRow.Cells("NomDptoRec").Text
            TotNetoLetras = oTesoreriaService.ConvierteNumLetraConta(GridEX1.CurrentRow.Cells("LegalMonetaryTotal").Text)
            CodEstablecimiento = GridEX1.CurrentRow.Cells("CodEstablecimiento").Text

            CrearCarpeta()
            CrearXML()

            ListarArchivos()
            If Session.sCodEmp = "01" Then
                CargarCorreo()
            ElseIf Session.sCodEmp = "02" Then
                CargarCorreoMtuAmazonica()
            ElseIf Session.sCodEmp = "05" Then
                CargarCorreoEquimap()
            ElseIf Session.sCodEmp = "07" Then
                CargarCorreoC2Teck()
            ElseIf Session.sCodEmp = "08" Then
                CargarCorreoC2TeckIM()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub CrearCarpeta()
        Try
            If Not Directory.Exists("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento) Then
                Directory.CreateDirectory("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear la carpeta")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try
    End Sub

    Private Sub CrearXML()

        If IdDocumento = "5" Then

            If opcionimp = "Detallado" Then
                'CrearXMLCreditoSerializadoDet()
                CrearXmlCreditoDetalle21()
            ElseIf opcionimp = "Resumido" Then
                'CrearXMLCreditoSerializadoRes()
                CrearXmlCreditoResumen21()
            End If

        ElseIf IdDocumento = "6" Then

            If opcionimp = "Detallado" Then
                'CrearXMLDebitoSerializadoDet()
                CrearXmlDebitoDetalle21()
            ElseIf opcionimp = "Resumido" Then
                'CrearXMLDebitoSerializadoRes()
                CrearXmlDebitoResumen21()
            End If

        End If

    End Sub

    'Private Sub CrearXmlSerializadoDsctoGlobal()

    '    Dim xmlFilename As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & GridEX1.CurrentRow.Cells("NumDoc").Text & "\20100020441-07-" & GridEX1.CurrentRow.Cells("NumDoc").Text & ".xml"

    '    UblLarsen.Ubl2.UblBaseDocumentType.GlbCustomizationID = "1.0"

    '    AmountType.TlsDefaultCurrencyID = CurrencyId

    '    '================================================================================================================================= Inicio Codigo TaxTotal

    '    Dim taxtotal As TaxTotalType() = New TaxTotalType(1) {}
    '    taxtotal(0) = New TaxTotalType() With { _
    '       .TaxAmount = FormatNumber(TaxAmount, 2), _
    '       .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '           .TaxAmount = FormatNumber(TaxAmount, 2), _
    '           .TaxCategory = New TaxCategoryType() With { _
    '               .TaxExemptionReasonCode = CodAfectacion, _
    '               .TaxScheme = New TaxSchemeType() With { _
    '                   .ID = CodTributo, _
    '                   .Name = NomTributo, _
    '                   .TaxTypeCode = CodTributoInt _
    '               } _
    '           } _
    '       }} _
    '    }

    '    '================================================================================================================================= Inicio Codigo TaxTotal

    '    '================================================================================================================================= Inicio Codigo DocumentReference

    '    Dim documentreference As DocumentReferenceType() = New DocumentReferenceType(1) {}
    '    documentreference(0) = New DocumentReferenceType() With { _
    '            .ID = NumDocModifica, _
    '            .DocumentTypeCode = TipoDocModifica _
    '    }

    '    '================================================================================================================================= Fin Codigo DocumentReference

    '    '================================================================================================================================= Inicio Codigo Discrepancy

    '    Dim discrepancy As ResponseType() = New ResponseType(1) {}
    '    discrepancy(0) = New ResponseType() With { _
    '        .ReferenceID = NumDocModifica, _
    '        .ResponseCode = CodTipoCre, _
    '        .Description = New TextType() {CStr(MotivoRef)} _
    '    }
    '    '.Description = New TextType() {CStr(Observacion)} _
    '    '.Description = Observacion _
    '    'ResponseCode = "07" Devolucion por item  en el Catalogo 9
    '    '================================================================================================================================= Fin Codigo Discrepancy

    '    '================================================================================================================================= Inicio Codigo LegalMonetaryTotal

    '    Dim legal As MonetaryTotalType() = New MonetaryTotalType(1) {}
    '    legal(0) = New MonetaryTotalType() With { _
    '        .PayableAmount = FormatNumber(LegalMonetaryTotal, 2), _
    '        .AllowanceTotalAmount = FormatNumber("20", 2) _
    '    }

    '    '================================================================================================================================= Fin Codigo LegalMonetaryTotal

    '    '================================================================================================================================= Inicio Codigo CustomerParty

    '    Dim accountcust As CustomerPartyType()
    '    If TipoIdentidad = "6" Then
    '        accountcust = New CustomerPartyType(1) {}
    '        accountcust(0) = New CustomerPartyType() With { _
    '           .CustomerAssignedAccountID = RucCli, _
    '           .AdditionalAccountID = New IdentifierType() {CStr(TipoIdentidad)}, _
    '           .Party = New PartyType() With { _
    '               .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With { _
    '                   .RegistrationName = DesCli _
    '               }} _
    '           } _
    '        }
    '    ElseIf TipoIdentidad = "1" Then
    '        accountcust = New CustomerPartyType(1) {}
    '        accountcust(0) = New CustomerPartyType() With { _
    '           .CustomerAssignedAccountID = DesCli, _
    '           .AdditionalAccountID = New IdentifierType() {CStr(TipoIdentidad)}, _
    '           .Party = New PartyType() With { _
    '               .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With { _
    '                   .RegistrationName = DesCli _
    '               }} _
    '           } _
    '        }
    '    End If

    '    '================================================================================================================================= Fin Codigo CustomerParty

    '    '================================================================================================================================= Inicio Codigo AdditionalMonetary

    '    Dim additionalmon As UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType()

    '    additionalmon = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType(1) {}
    '    additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
    '                    .ID = "1001", _
    '                    .PayableAmount = FormatNumber(TotVenta, 2) _
    '    }

    '    '======================================================================================= Inicio Total Descuento
    '    additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
    '                    .ID = "2005", _
    '                    .PayableAmount = FormatNumber("20", 2) _
    '    }
    '    '======================================================================================= Fin Total descuentos

    '    '================================================================================================================================= Fin Codigo AdditionalMonetary

    '    '================================================================================================================================= Inicio Codigo InvoiceLine

    '    Dim line1 As CreditNoteLineType()

    '    Dim row As Janus.Windows.GridEX.GridEXRow

    '    If GridEX1.RowCount > 0 Then
    '        Dim cantline As Integer = GridEX1.RowCount
    '        line1 = New CreditNoteLineType(cantline) {}

    '        For j = 0 To GridEX1.RowCount - 1
    '            Me.GridEX1.Row = j
    '            row = Me.GridEX1.GetRow()

    '            'Dim cantline As Integer = GridEX1.RowCount
    '            'line1 = New InvoiceLineType(cantline) {}
    '            'Dim line1 As InvoiceLineType() = New InvoiceLineType(cantline) {}

    '            line1(j) = New CreditNoteLineType() With { _
    '                   .ID = CStr(row.Cells("Item").Value), _
    '                   .CreditedQuantity = New QuantityType() With { _
    '                       .unitCode = CStr(row.Cells("unitCode").Value), _
    '                       .Value = CDec(row.Cells("CanMer").Value) _
    '                   }, _
    '                   .LineExtensionAmount = CDec(FormatNumber(row.Cells("LineExtensionAmount").Value, 2)), _
    '                   .PricingReference = New PricingReferenceType() With { _
    '                       .AlternativeConditionPrice = New PriceType() {New PriceType() With { _
    '                           .PriceAmount = CDec(FormatNumber(row.Cells("Pricingreference").Value, 2)), _
    '                           .PriceTypeCode = CStr(row.Cells("CodigoPrecio").Value) _
    '                       }} _
    '                   }, _
    '                   .TaxTotal = New TaxTotalType() {New TaxTotalType() With { _
    '                       .TaxAmount = CDec(FormatNumber(row.Cells("MontoIgv").Value, 2)), _
    '                       .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '                           .TaxAmount = CDec(FormatNumber(row.Cells("MontoIgv").Value, 2)), _
    '                           .TaxCategory = New TaxCategoryType() With { _
    '                               .TaxExemptionReasonCode = CStr(CodAfectacion), _
    '                               .TaxScheme = New TaxSchemeType() With { _
    '                                   .ID = CStr(row.Cells("CodTributo").Value), _
    '                                   .Name = CStr(row.Cells("NomTributo").Value), _
    '                                   .TaxTypeCode = CStr(row.Cells("CodTributoInt").Value) _
    '                               } _
    '                           } _
    '                       }} _
    '                   }}, _
    '                   .Item = New ItemType() With { _
    '                       .Description = New TextType() {CStr(row.Cells("DesMer1").Value)}, _
    '                       .SellersItemIdentification = New ItemIdentificationType() With { _
    '                           .ID = CStr(row.Cells("CodMer").Value) _
    '                       } _
    '                   }, _
    '                   .Price = New PriceType() With { _
    '                       .PriceAmount = CDec(FormatNumber(row.Cells("Price").Value, 2)) _
    '                   } _
    '               }

    '        Next

    '    End If

    '    '==============================================================================================================================Fin Codigo InvoiceLine

    '    '==============================================================================================================================Inicio Codigo GenerarXML

    '    FacturacionElectronica.GenerarCreditNote(xmlFilename, additionalmon, CurrencyId, NumDoc, FecDoc, discrepancy, documentreference(0), accountcust(0), taxtotal, legal(0), line1)

    '    '==============================================================================================================================Fin Codigo GenerarXML

    '    FirmadoDigital()

    'End Sub

    'Private Sub CrearXMLDebitoDsctoGlobal()

    '    Dim xmlFilename As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & GridEX1.CurrentRow.Cells("NumDoc").Text & "\20100020441-08-" & GridEX1.CurrentRow.Cells("NumDoc").Text & ".xml"

    '    UblLarsen.Ubl2.UblBaseDocumentType.GlbCustomizationID = "1.0"

    '    AmountType.TlsDefaultCurrencyID = CurrencyId

    '    '================================================================================================================================= Inicio Codigo TaxTotal

    '    Dim taxtotal As TaxTotalType() = New TaxTotalType(1) {}
    '    taxtotal(0) = New TaxTotalType() With { _
    '       .TaxAmount = FormatNumber(TaxAmount, 2), _
    '       .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '           .TaxAmount = FormatNumber(TaxAmount, 2), _
    '           .TaxCategory = New TaxCategoryType() With { _
    '               .TaxExemptionReasonCode = CodAfectacion, _
    '               .TaxScheme = New TaxSchemeType() With { _
    '                   .ID = CodTributo, _
    '                   .Name = NomTributo, _
    '                   .TaxTypeCode = CodTributoInt _
    '               } _
    '           } _
    '       }} _
    '    }

    '    '================================================================================================================================= Inicio Codigo TaxTotal

    '    '================================================================================================================================= Inicio Codigo DocumentReference

    '    Dim documentreference As DocumentReferenceType() = New DocumentReferenceType(1) {}
    '    documentreference(0) = New DocumentReferenceType() With { _
    '            .ID = NumDocModifica, _
    '            .DocumentTypeCode = TipoDocModifica _
    '    }

    '    '================================================================================================================================= Fin Codigo DocumentReference

    '    '================================================================================================================================= Inicio Codigo Discrepancy

    '    Dim discrepancy As ResponseType() = New ResponseType(1) {}
    '    discrepancy(0) = New ResponseType() With { _
    '        .ReferenceID = NumDocModifica, _
    '        .ResponseCode = CodTipoDeb, _
    '        .Description = New TextType() {MotivoRef} _
    '    }
    '    '.Description = New TextType() {CStr(Observacion)} _
    '    '.Description = Observacion _
    '    'ResponseCode = "02" Aumento en el valor en el Catalogo 10
    '    '================================================================================================================================= Fin Codigo Discrepancy

    '    '================================================================================================================================= Inicio Codigo LegalMonetaryTotal

    '    Dim legal As MonetaryTotalType() = New MonetaryTotalType(1) {}
    '    legal(0) = New MonetaryTotalType() With { _
    '        .PayableAmount = FormatNumber(LegalMonetaryTotal, 2), _
    '        .AllowanceTotalAmount = FormatNumber("20", 2) _
    '    }

    '    '================================================================================================================================= Fin Codigo LegalMonetaryTotal

    '    '================================================================================================================================= Inicio Codigo CustomerParty

    '    Dim accountcust As CustomerPartyType()
    '    If TipoIdentidad = "6" Then
    '        accountcust = New CustomerPartyType(1) {}
    '        accountcust(0) = New CustomerPartyType() With { _
    '           .CustomerAssignedAccountID = RucCli, _
    '           .AdditionalAccountID = New IdentifierType() {CStr(TipoIdentidad)}, _
    '           .Party = New PartyType() With { _
    '               .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With { _
    '                   .RegistrationName = DesCli _
    '               }} _
    '           } _
    '        }
    '    ElseIf TipoIdentidad = "1" Then
    '        accountcust = New CustomerPartyType(1) {}
    '        accountcust(0) = New CustomerPartyType() With { _
    '           .CustomerAssignedAccountID = DesCli, _
    '           .AdditionalAccountID = New IdentifierType() {CStr(TipoIdentidad)}, _
    '           .Party = New PartyType() With { _
    '               .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With { _
    '                   .RegistrationName = DesCli _
    '               }} _
    '           } _
    '        }
    '    End If

    '    '================================================================================================================================= Fin Codigo CustomerParty

    '    '================================================================================================================================= Inicio Codigo AdditionalMonetary

    '    Dim additionalmon As UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType()

    '    additionalmon = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType(1) {}
    '    additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
    '                    .ID = "1001", _
    '                    .PayableAmount = FormatNumber(TotVenta, 2) _
    '    }
    '    '======================================================================================= Inicio Total Descuento
    '    additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
    '                    .ID = "2005", _
    '                    .PayableAmount = FormatNumber("20", 2) _
    '    }
    '    '======================================================================================= Fin Total descuentos
    '    '================================================================================================================================= Fin Codigo AdditionalMonetary

    '    '================================================================================================================================= Inicio Codigo InvoiceLine

    '    Dim line1 As DebitNoteLineType()

    '    Dim row As Janus.Windows.GridEX.GridEXRow

    '    If GridEX1.RowCount > 0 Then
    '        Dim cantline As Integer = GridEX1.RowCount
    '        line1 = New DebitNoteLineType(cantline) {}

    '        For j = 0 To GridEX1.RowCount - 1
    '            Me.GridEX1.Row = j
    '            row = Me.GridEX1.GetRow()

    '            'Dim cantline As Integer = GridEX1.RowCount
    '            'line1 = New InvoiceLineType(cantline) {}
    '            'Dim line1 As InvoiceLineType() = New InvoiceLineType(cantline) {}

    '            line1(j) = New DebitNoteLineType() With { _
    '                   .ID = CStr(row.Cells("Item").Value), _
    '                   .DebitedQuantity = New QuantityType() With { _
    '                       .unitCode = CStr(row.Cells("unitCode").Value), _
    '                       .Value = CDec(row.Cells("CanMer").Value) _
    '                   }, _
    '                   .LineExtensionAmount = CDec(FormatNumber(row.Cells("LineExtensionAmount").Value, 2)), _
    '                   .PricingReference = New PricingReferenceType() With { _
    '                       .AlternativeConditionPrice = New PriceType() {New PriceType() With { _
    '                           .PriceAmount = CDec(FormatNumber(row.Cells("Pricingreference").Value, 2)), _
    '                           .PriceTypeCode = CStr(row.Cells("CodigoPrecio").Value) _
    '                       }} _
    '                   }, _
    '                   .TaxTotal = New TaxTotalType() {New TaxTotalType() With { _
    '                       .TaxAmount = CDec(FormatNumber(row.Cells("MontoIgv").Value, 2)), _
    '                       .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '                           .TaxAmount = CDec(FormatNumber(row.Cells("MontoIgv").Value, 2)), _
    '                           .TaxCategory = New TaxCategoryType() With { _
    '                               .TaxExemptionReasonCode = CStr(CodAfectacion), _
    '                               .TaxScheme = New TaxSchemeType() With { _
    '                                   .ID = CStr(row.Cells("CodTributo").Value), _
    '                                   .Name = CStr(row.Cells("NomTributo").Value), _
    '                                   .TaxTypeCode = CStr(row.Cells("CodTributoInt").Value) _
    '                               } _
    '                           } _
    '                       }} _
    '                   }}, _
    '                   .Item = New ItemType() With { _
    '                       .Description = New TextType() {CStr(row.Cells("DesMer1").Value)}, _
    '                       .SellersItemIdentification = New ItemIdentificationType() With { _
    '                           .ID = CStr(row.Cells("CodMer").Value) _
    '                       } _
    '                   }, _
    '                   .Price = New PriceType() With { _
    '                       .PriceAmount = CDec(FormatNumber(row.Cells("Price").Value, 2)) _
    '                   } _
    '               }

    '        Next

    '    End If

    '    '==============================================================================================================================Fin Codigo InvoiceLine

    '    '==============================================================================================================================Inicio Codigo GenerarXML

    '    FacturacionElectronica.GenerarDebitNote(xmlFilename, additionalmon, CurrencyId, NumDoc, FecDoc, discrepancy, documentreference(0), accountcust(0), taxtotal, legal(0), line1)

    '    '==============================================================================================================================Fin Codigo GenerarXML

    '    FirmadoDigital()


    'End Sub

    'Private Sub CrearXmlCreditoSerializadoInafectos()

    '    Dim xmlFilename As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & GridEX1.CurrentRow.Cells("NumDoc").Text & "\20100020441-07-" & GridEX1.CurrentRow.Cells("NumDoc").Text & ".xml"

    '    UblLarsen.Ubl2.UblBaseDocumentType.GlbCustomizationID = "1.0"

    '    AmountType.TlsDefaultCurrencyID = CurrencyId

    '    '================================================================================================================================= Inicio Codigo TaxTotal

    '    Dim taxtotal As TaxTotalType() = New TaxTotalType(1) {}
    '    taxtotal(0) = New TaxTotalType() With { _
    '       .TaxAmount = FormatNumber("0.0", 2), _
    '       .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '           .TaxAmount = FormatNumber("0.0", 2), _
    '           .TaxCategory = New TaxCategoryType() With { _
    '               .TaxExemptionReasonCode = "30", _
    '               .TaxScheme = New TaxSchemeType() With { _
    '                   .ID = CodTributo, _
    '                   .Name = NomTributo, _
    '                   .TaxTypeCode = CodTributoInt _
    '               } _
    '           } _
    '       }} _
    '    }

    '    '================================================================================================================================= Inicio Codigo TaxTotal

    '    '================================================================================================================================= Inicio Codigo DocumentReference

    '    Dim documentreference As DocumentReferenceType() = New DocumentReferenceType(1) {}
    '    documentreference(0) = New DocumentReferenceType() With { _
    '            .ID = NumDocModifica, _
    '            .DocumentTypeCode = TipoDocModifica _
    '    }

    '    '================================================================================================================================= Fin Codigo DocumentReference

    '    '================================================================================================================================= Inicio Codigo Discrepancy

    '    Dim discrepancy As ResponseType() = New ResponseType(1) {}
    '    discrepancy(0) = New ResponseType() With { _
    '        .ReferenceID = NumDocModifica, _
    '        .ResponseCode = CodTipoCre, _
    '        .Description = New TextType() {CStr(MotivoRef)} _
    '    }
    '    '.Description = New TextType() {CStr(Observacion)} _
    '    '.Description = Observacion _
    '    'ResponseCode = "07" Devolucion por item  en el Catalogo 9
    '    '================================================================================================================================= Fin Codigo Discrepancy

    '    '================================================================================================================================= Inicio Codigo LegalMonetaryTotal

    '    Dim legal As MonetaryTotalType() = New MonetaryTotalType(1) {}
    '    legal(0) = New MonetaryTotalType() With { _
    '        .PayableAmount = FormatNumber(TotVenta, 2) _
    '    }

    '    '================================================================================================================================= Fin Codigo LegalMonetaryTotal

    '    '================================================================================================================================= Inicio Codigo CustomerParty

    '    Dim accountcust As CustomerPartyType()
    '    If TipoIdentidad = "6" Then
    '        accountcust = New CustomerPartyType(1) {}
    '        accountcust(0) = New CustomerPartyType() With { _
    '           .CustomerAssignedAccountID = RucCli, _
    '           .AdditionalAccountID = New IdentifierType() {CStr(TipoIdentidad)}, _
    '           .Party = New PartyType() With { _
    '               .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With { _
    '                   .RegistrationName = DesCli _
    '               }} _
    '           } _
    '        }
    '    ElseIf TipoIdentidad = "1" Then
    '        accountcust = New CustomerPartyType(1) {}
    '        accountcust(0) = New CustomerPartyType() With { _
    '           .CustomerAssignedAccountID = DesCli, _
    '           .AdditionalAccountID = New IdentifierType() {CStr(TipoIdentidad)}, _
    '           .Party = New PartyType() With { _
    '               .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With { _
    '                   .RegistrationName = DesCli _
    '               }} _
    '           } _
    '        }
    '    End If

    '    '================================================================================================================================= Fin Codigo CustomerParty

    '    '================================================================================================================================= Inicio Codigo AdditionalMonetary

    '    Dim additionalmon As UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType()

    '    additionalmon = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType(1) {}
    '    additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
    '                    .ID = "1001", _
    '                    .PayableAmount = FormatNumber("0.0", 2) _
    '    }



    '    '======================================================================================= Inicio Operaciones inafectas
    '    additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
    '                    .ID = "1002", _
    '                    .PayableAmount = FormatNumber(TotVenta, 2) _
    '    }
    '    ''======================================================================================= Fin Operaciones inafectas

    '    '================================================================================================================================= Fin Codigo AdditionalMonetary

    '    '================================================================================================================================= Inicio Codigo InvoiceLine

    '    Dim line1 As CreditNoteLineType()

    '    Dim row As Janus.Windows.GridEX.GridEXRow

    '    If GridEX1.RowCount > 0 Then
    '        Dim cantline As Integer = GridEX1.RowCount
    '        line1 = New CreditNoteLineType(cantline) {}

    '        For j = 0 To GridEX1.RowCount - 1
    '            Me.GridEX1.Row = j
    '            row = Me.GridEX1.GetRow()

    '            'Dim cantline As Integer = GridEX1.RowCount
    '            'line1 = New InvoiceLineType(cantline) {}
    '            'Dim line1 As InvoiceLineType() = New InvoiceLineType(cantline) {}

    '            line1(j) = New CreditNoteLineType() With { _
    '                   .ID = CStr(row.Cells("Item").Value), _
    '                   .CreditedQuantity = New QuantityType() With { _
    '                       .unitCode = CStr(row.Cells("unitCode").Value), _
    '                       .Value = CDec(row.Cells("CanMer").Value) _
    '                   }, _
    '                   .LineExtensionAmount = CDec(FormatNumber(row.Cells("LineExtensionAmount").Value, 2)), _
    '                   .PricingReference = New PricingReferenceType() With { _
    '                       .AlternativeConditionPrice = New PriceType() {New PriceType() With { _
    '                           .PriceAmount = CDec(FormatNumber(row.Cells("Price").Value, 2)), _
    '                           .PriceTypeCode = CStr("01") _
    '                       }} _
    '                   }, _
    '                   .TaxTotal = New TaxTotalType() {New TaxTotalType() With { _
    '                       .TaxAmount = CDec(FormatNumber("0.0", 2)), _
    '                       .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '                           .TaxAmount = CDec(FormatNumber("0.0", 2)), _
    '                           .TaxCategory = New TaxCategoryType() With { _
    '                               .TaxExemptionReasonCode = CStr("30"), _
    '                               .TaxScheme = New TaxSchemeType() With { _
    '                                   .ID = CStr(row.Cells("CodTributo").Value), _
    '                                   .Name = CStr(row.Cells("NomTributo").Value), _
    '                                   .TaxTypeCode = CStr(row.Cells("CodTributoInt").Value) _
    '                               } _
    '                           } _
    '                       }} _
    '                   }}, _
    '                   .Item = New ItemType() With { _
    '                       .Description = New TextType() {CStr(row.Cells("DesMer1").Value)}, _
    '                       .SellersItemIdentification = New ItemIdentificationType() With { _
    '                           .ID = CStr(row.Cells("CodMer").Value) _
    '                       } _
    '                   }, _
    '                   .Price = New PriceType() With { _
    '                       .PriceAmount = CDec(FormatNumber(row.Cells("Price").Value, 2)) _
    '                   } _
    '               }

    '        Next

    '    End If

    '    '==============================================================================================================================Fin Codigo InvoiceLine

    '    '==============================================================================================================================Inicio Codigo GenerarXML

    '    FacturacionElectronica.GenerarCreditNote(xmlFilename, additionalmon, CurrencyId, NumDoc, FecDoc, discrepancy, documentreference(0), accountcust(0), taxtotal, legal(0), line1)

    '    '==============================================================================================================================Fin Codigo GenerarXML

    '    FirmadoDigital()

    'End Sub

    'Private Sub CrearXmlDebitoSerializadoInafecto()

    '    Dim xmlFilename As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & GridEX1.CurrentRow.Cells("NumDoc").Text & "\20100020441-08-" & GridEX1.CurrentRow.Cells("NumDoc").Text & ".xml"

    '    UblLarsen.Ubl2.UblBaseDocumentType.GlbCustomizationID = "1.0"

    '    AmountType.TlsDefaultCurrencyID = CurrencyId

    '    '================================================================================================================================= Inicio Codigo TaxTotal

    '    Dim taxtotal As TaxTotalType() = New TaxTotalType(1) {}
    '    taxtotal(0) = New TaxTotalType() With { _
    '       .TaxAmount = FormatNumber("0.0", 2), _
    '       .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '           .TaxAmount = FormatNumber("0.0", 2), _
    '           .TaxCategory = New TaxCategoryType() With { _
    '               .TaxExemptionReasonCode = "30", _
    '               .TaxScheme = New TaxSchemeType() With { _
    '                   .ID = CodTributo, _
    '                   .Name = NomTributo, _
    '                   .TaxTypeCode = CodTributoInt _
    '               } _
    '           } _
    '       }} _
    '    }

    '    '================================================================================================================================= Inicio Codigo TaxTotal

    '    '================================================================================================================================= Inicio Codigo DocumentReference

    '    Dim documentreference As DocumentReferenceType() = New DocumentReferenceType(1) {}
    '    documentreference(0) = New DocumentReferenceType() With { _
    '            .ID = NumDocModifica, _
    '            .DocumentTypeCode = TipoDocModifica _
    '    }

    '    '================================================================================================================================= Fin Codigo DocumentReference

    '    '================================================================================================================================= Inicio Codigo Discrepancy

    '    Dim discrepancy As ResponseType() = New ResponseType(1) {}
    '    discrepancy(0) = New ResponseType() With { _
    '        .ReferenceID = NumDocModifica, _
    '        .ResponseCode = CodTipoDeb, _
    '        .Description = New TextType() {MotivoRef} _
    '    }
    '    '.Description = New TextType() {CStr(Observacion)} _
    '    '.Description = Observacion _
    '    'ResponseCode = "02" Aumento en el valor en el Catalogo 10
    '    '================================================================================================================================= Fin Codigo Discrepancy

    '    '================================================================================================================================= Inicio Codigo LegalMonetaryTotal

    '    Dim legal As MonetaryTotalType() = New MonetaryTotalType(1) {}
    '    legal(0) = New MonetaryTotalType() With { _
    '        .PayableAmount = FormatNumber(TotVenta, 2) _
    '    }

    '    '================================================================================================================================= Fin Codigo LegalMonetaryTotal

    '    '================================================================================================================================= Inicio Codigo CustomerParty

    '    Dim accountcust As CustomerPartyType()
    '    If TipoIdentidad = "6" Then
    '        accountcust = New CustomerPartyType(1) {}
    '        accountcust(0) = New CustomerPartyType() With { _
    '           .CustomerAssignedAccountID = RucCli, _
    '           .AdditionalAccountID = New IdentifierType() {CStr(TipoIdentidad)}, _
    '           .Party = New PartyType() With { _
    '               .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With { _
    '                   .RegistrationName = DesCli _
    '               }} _
    '           } _
    '        }
    '    ElseIf TipoIdentidad = "1" Then
    '        accountcust = New CustomerPartyType(1) {}
    '        accountcust(0) = New CustomerPartyType() With { _
    '           .CustomerAssignedAccountID = DesCli, _
    '           .AdditionalAccountID = New IdentifierType() {CStr(TipoIdentidad)}, _
    '           .Party = New PartyType() With { _
    '               .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With { _
    '                   .RegistrationName = DesCli _
    '               }} _
    '           } _
    '        }
    '    End If

    '    '================================================================================================================================= Fin Codigo CustomerParty

    '    '================================================================================================================================= Inicio Codigo AdditionalMonetary

    '    Dim additionalmon As UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType()

    '    additionalmon = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType(1) {}
    '    additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
    '                    .ID = "1001", _
    '                    .PayableAmount = FormatNumber("0.0", 2) _
    '    }
    '    '======================================================================================= Inicio Operaciones inafectas
    '    additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
    '                    .ID = "1002", _
    '                    .PayableAmount = FormatNumber(TotVenta, 2) _
    '    }
    '    ''======================================================================================= Fin Operaciones inafectas
    '    '================================================================================================================================= Fin Codigo AdditionalMonetary

    '    '================================================================================================================================= Inicio Codigo InvoiceLine

    '    Dim line1 As DebitNoteLineType()

    '    Dim row As Janus.Windows.GridEX.GridEXRow

    '    If GridEX1.RowCount > 0 Then
    '        Dim cantline As Integer = GridEX1.RowCount
    '        line1 = New DebitNoteLineType(cantline) {}

    '        For j = 0 To GridEX1.RowCount - 1
    '            Me.GridEX1.Row = j
    '            row = Me.GridEX1.GetRow()

    '            'Dim cantline As Integer = GridEX1.RowCount
    '            'line1 = New InvoiceLineType(cantline) {}
    '            'Dim line1 As InvoiceLineType() = New InvoiceLineType(cantline) {}

    '            line1(j) = New DebitNoteLineType() With { _
    '                   .ID = CStr(row.Cells("Item").Value), _
    '                   .DebitedQuantity = New QuantityType() With { _
    '                       .unitCode = CStr(row.Cells("unitCode").Value), _
    '                       .Value = CDec(row.Cells("CanMer").Value) _
    '                   }, _
    '                   .LineExtensionAmount = CDec(FormatNumber(row.Cells("LineExtensionAmount").Value, 2)), _
    '                   .PricingReference = New PricingReferenceType() With { _
    '                       .AlternativeConditionPrice = New PriceType() {New PriceType() With { _
    '                           .PriceAmount = CDec(FormatNumber(row.Cells("Price").Value, 2)), _
    '                           .PriceTypeCode = CStr("01") _
    '                       }} _
    '                   }, _
    '                   .TaxTotal = New TaxTotalType() {New TaxTotalType() With { _
    '                       .TaxAmount = CDec(FormatNumber("0.0", 2)), _
    '                       .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '                           .TaxAmount = CDec(FormatNumber("0.0", 2)), _
    '                           .TaxCategory = New TaxCategoryType() With { _
    '                               .TaxExemptionReasonCode = CStr("30"), _
    '                               .TaxScheme = New TaxSchemeType() With { _
    '                                   .ID = CStr(row.Cells("CodTributo").Value), _
    '                                   .Name = CStr(row.Cells("NomTributo").Value), _
    '                                   .TaxTypeCode = CStr(row.Cells("CodTributoInt").Value) _
    '                               } _
    '                           } _
    '                       }} _
    '                   }}, _
    '                   .Item = New ItemType() With { _
    '                       .Description = New TextType() {CStr(row.Cells("DesMer1").Value)}, _
    '                       .SellersItemIdentification = New ItemIdentificationType() With { _
    '                           .ID = CStr(row.Cells("CodMer").Value) _
    '                       } _
    '                   }, _
    '                   .Price = New PriceType() With { _
    '                       .PriceAmount = CDec(FormatNumber(row.Cells("Price").Value, 2)) _
    '                   } _
    '               }

    '        Next

    '    End If

    '    '==============================================================================================================================Fin Codigo InvoiceLine

    '    '==============================================================================================================================Inicio Codigo GenerarXML

    '    FacturacionElectronica.GenerarDebitNote(xmlFilename, additionalmon, CurrencyId, NumDoc, FecDoc, discrepancy, documentreference(0), accountcust(0), taxtotal, legal(0), line1)

    '    '==============================================================================================================================Fin Codigo GenerarXML

    '    FirmadoDigital()

    'End Sub

    Private Sub CrearXMLCreditoSerializadoDet()
        Try
            Dim xmlFilename As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-07-" & Documento & ".xml"
            'Dim xmlFilename As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-07-" & Documento & ".xml"

            UblLarsen.Ubl2.UblBaseDocumentType.GlbCustomizationID = "1.0"

            AmountType.TlsDefaultCurrencyID = CurrencyId

            '================================================================================================================================= Inicio Codigo TaxTotal

            Dim taxtotal As TaxTotalType() = New TaxTotalType(1) {}
            taxtotal(0) = New TaxTotalType() With {
               .TaxAmount = FormatNumber(TaxAmount, 2),
               .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With {
                   .TaxAmount = FormatNumber(TaxAmount, 2),
                   .TaxCategory = New TaxCategoryType() With {
                       .TaxExemptionReasonCode = CodAfectacion,
                       .TaxScheme = New TaxSchemeType() With {
                           .ID = CodTributo,
                           .Name = NomTributo,
                           .TaxTypeCode = CodTributoInt
                       }
                   }
               }}
            }

            '================================================================================================================================= Inicio Codigo TaxTotal

            '================================================================================================================================= Inicio Codigo DocumentReference

            Dim documentreference As DocumentReferenceType() = New DocumentReferenceType(1) {}
            documentreference(0) = New DocumentReferenceType() With {
                    .ID = NumDocModifica,
                    .DocumentTypeCode = TipoDocModifica
            }

            '================================================================================================================================= Fin Codigo DocumentReference

            '================================================================================================================================= Inicio Codigo Discrepancy

            Dim discrepancy As ResponseType() = New ResponseType(1) {}
            discrepancy(0) = New ResponseType() With {
                .ReferenceID = NumDocModifica,
                .ResponseCode = CodTipoCre,
                .Description = New TextType() {CStr(MotivoRef)}
            }
            '.Description = New TextType() {CStr(Observacion)} _
            '.Description = Observacion _
            'ResponseCode = "07" Devolucion por item  en el Catalogo 9
            '================================================================================================================================= Fin Codigo Discrepancy

            '================================================================================================================================= Inicio Codigo LegalMonetaryTotal

            Dim legal As MonetaryTotalType() = New MonetaryTotalType(1) {}
            legal(0) = New MonetaryTotalType() With {
                .PayableAmount = FormatNumber(LegalMonetaryTotal, 2)
            }

            '================================================================================================================================= Fin Codigo LegalMonetaryTotal

            '================================================================================================================================= Inicio Codigo CustomerParty

            Dim accountcust As CustomerPartyType()
            If TipoIdentidad = "6" Or TipoIdentidad = "-" Or TipoIdentidad = "0" Then
                accountcust = New CustomerPartyType(1) {}
                accountcust(0) = New CustomerPartyType() With {
                   .CustomerAssignedAccountID = RucCli,
                   .AdditionalAccountID = New IdentifierType() {CStr(TipoIdentidad)},
                   .Party = New PartyType() With {
                    .PostalAddress = New AddressType() With {
                    .ID = CodUbigeoRec,
                    .StreetName = DireccionFiscal,
                    .CityName = NomDptoRec,
                    .CountrySubentity = NomProvRec,
                    .District = NomDistRec,
                    .Country = New CountryType() With {
                            .IdentificationCode = CodPais
                    }
                },
                .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With {
                    .RegistrationName = DesCli
                    }}
                   }
                }
            ElseIf TipoIdentidad = "1" Then
                accountcust = New CustomerPartyType(1) {}
                accountcust(0) = New CustomerPartyType() With {
                   .CustomerAssignedAccountID = DniCli,
                   .AdditionalAccountID = New IdentifierType() {CStr(TipoIdentidad)},
                   .Party = New PartyType() With {
                       .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With {
                           .RegistrationName = DesCli
                       }}
                   }
                }
            End If

            '================================================================================================================================= Fin Codigo CustomerParty

            '================================================================================================================================= Inicio Codigo AdditionalMonetary

            'Dim additionalmon As UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType()

            'additionalmon = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType(1) {}
            'additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
            '                .ID = "1001", _
            '                .PayableAmount = FormatNumber(TotVenta, 2) _
            '}

            Dim additionalmon As UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() = Nothing


            If InstructionID = "01" Then

                additionalmon = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType(2) {}
                additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With {
                                .ID = "1001",
                                .PayableAmount = FormatNumber(TotVenta, 2)
                }

                ' ''======================================================================================= Inicio Operaciones inafectas
                'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "1002", _
                '                .PayableAmount = FormatNumber(TotVenta, 2) _
                '}
                ''======================================================================================= Fin Operaciones inafectas

                ''======================================================================================= Inicio Operaciones exoneradas
                'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "1003", _
                '                .PayableAmount = FormatNumber(TotNeto, 2) _
                '}
                ''======================================================================================= Fin Operaciones exoneradas

                ''======================================================================================= Inicio Percepcion
                'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "2001", _
                '                .PayableAmount = FormatNumber(TotNeto, 2) _
                '}
                ''======================================================================================= Fin Percepcion

                '======================================================================================= Inicio Total Descuento
                'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "2005", _
                '                .PayableAmount = FormatNumber(TotDscto, 2) _
                '}
                '======================================================================================= Fin Total descuentos

            ElseIf InstructionID = "04" Then

                additionalmon = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType(1) {}
                'additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "1001", _
                '                .PayableAmount = FormatNumber(0, 2) _
                '}

                ''======================================================================================= Inicio Operaciones inafectas
                additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With {
                                .ID = "1002",
                                .PayableAmount = FormatNumber(TotVenta, 2)
                }
                ''======================================================================================= Fin Operaciones inafectas

                ''======================================================================================= Inicio Operaciones exoneradas
                'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "1003", _
                '                .PayableAmount = FormatNumber(TotNeto, 2) _
                '}
                ''======================================================================================= Fin Operaciones exoneradas

                ''======================================================================================= Inicio Percepcion
                'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "2001", _
                '                .PayableAmount = FormatNumber(TotNeto, 2) _
                '}
                ''======================================================================================= Fin Percepcion

                '======================================================================================= Inicio Total Descuento
                'additionalmon(2) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "2005", _
                '                .PayableAmount = FormatNumber(TotDscto, 2) _
                '}
                '======================================================================================= Fin Total descuentos

            End If
            '================================================================================================================================= Fin Codigo AdditionalMonetary

            '================================================================================================================================= Inicio Codigo InvoiceLine

            Dim line1 As CreditNoteLineType()

            Dim row As Janus.Windows.GridEX.GridEXRow

            If GridEX1.RowCount > 0 Then
                Dim cantline As Integer = GridEX1.RowCount
                line1 = New CreditNoteLineType(cantline) {}

                For j = 0 To GridEX1.RowCount - 1
                    Me.GridEX1.Row = j
                    row = Me.GridEX1.GetRow()

                    'Dim cantline As Integer = GridEX1.RowCount
                    'line1 = New InvoiceLineType(cantline) {}
                    'Dim line1 As InvoiceLineType() = New InvoiceLineType(cantline) {}

                    line1(j) = New CreditNoteLineType() With {
                           .ID = CStr(row.Cells("Item").Value),
                           .CreditedQuantity = New QuantityType() With {
                               .unitCode = CStr(row.Cells("unitCode").Value),
                               .Value = CDec(row.Cells("CanMer").Value)
                           },
                           .LineExtensionAmount = CDec(FormatNumber(row.Cells("LineExtensionAmount").Value, 2)),
                           .PricingReference = New PricingReferenceType() With {
                               .AlternativeConditionPrice = New PriceType() {New PriceType() With {
                                   .PriceAmount = CDec(FormatNumber(row.Cells("Pricingreference").Value, 2)),
                                   .PriceTypeCode = CStr(row.Cells("CodigoPrecio").Value)
                               }}
                           },
                           .TaxTotal = New TaxTotalType() {New TaxTotalType() With {
                               .TaxAmount = CDec(FormatNumber(row.Cells("MontoIgv").Value, 2)),
                               .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With {
                                   .TaxAmount = CDec(FormatNumber(row.Cells("MontoIgv").Value, 2)),
                                   .TaxCategory = New TaxCategoryType() With {
                                       .TaxExemptionReasonCode = CStr(CodAfectacion),
                                       .TaxScheme = New TaxSchemeType() With {
                                           .ID = CStr(row.Cells("CodTributo").Value),
                                           .Name = CStr(row.Cells("NomTributo").Value),
                                           .TaxTypeCode = CStr(row.Cells("CodTributoInt").Value)
                                       }
                                   }
                               }}
                           }},
                           .Item = New ItemType() With {
                               .Description = New TextType() {CStr(row.Cells("DesMer1").Value)},
                               .SellersItemIdentification = New ItemIdentificationType() With {
                                   .ID = CStr(row.Cells("CodMer").Value)
                               }
                           },
                           .Price = New PriceType() With {
                               .PriceAmount = CDec(FormatNumber(row.Cells("Price").Value, 2))
                           }
                       }

                Next

            End If

            '==============================================================================================================================Fin Codigo InvoiceLine

            '==============================================================================================================================Inicio Codigo GenerarXML

            FacturacionElectronica.GenerarCreditNote(xmlFilename, Session.sRucEmp, Session.sDesEmp, Session.sCodUbigeo, Session.sDireccion, Session.sDepartamento, Session.sProvincia, Session.sDistrito, additionalmon, CurrencyId, Documento, FecDoc, discrepancy, documentreference(0), accountcust(0), taxtotal, legal(0), line1)

            '==============================================================================================================================Fin Codigo GenerarXML

            FirmadoDigital()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear xml")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try
    End Sub

    Private Sub CrearXMLCreditoSerializadoRes()
        Try
            Dim xmlFilename As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-07-" & Documento & ".xml"
            'Dim xmlFilename As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-07-" & Documento & ".xml"

            UblLarsen.Ubl2.UblBaseDocumentType.GlbCustomizationID = "1.0"

            AmountType.TlsDefaultCurrencyID = CurrencyId

            '================================================================================================================================= Inicio Codigo TaxTotal

            Dim taxtotal As TaxTotalType() = New TaxTotalType(1) {}
            taxtotal(0) = New TaxTotalType() With {
               .TaxAmount = FormatNumber(TaxAmount, 2),
               .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With {
                   .TaxAmount = FormatNumber(TaxAmount, 2),
                   .TaxCategory = New TaxCategoryType() With {
                       .TaxExemptionReasonCode = CodAfectacion,
                       .TaxScheme = New TaxSchemeType() With {
                           .ID = CodTributo,
                           .Name = NomTributo,
                           .TaxTypeCode = CodTributoInt
                       }
                   }
               }}
            }

            '================================================================================================================================= Inicio Codigo TaxTotal

            '================================================================================================================================= Inicio Codigo DocumentReference

            Dim documentreference As DocumentReferenceType() = New DocumentReferenceType(1) {}
            documentreference(0) = New DocumentReferenceType() With {
                    .ID = NumDocModifica,
                    .DocumentTypeCode = TipoDocModifica
            }

            '================================================================================================================================= Fin Codigo DocumentReference

            '================================================================================================================================= Inicio Codigo Discrepancy

            Dim discrepancy As ResponseType() = New ResponseType(1) {}
            discrepancy(0) = New ResponseType() With {
                .ReferenceID = NumDocModifica,
                .ResponseCode = CodTipoCre,
                .Description = New TextType() {CStr(MotivoRef)}
            }
            '.Description = New TextType() {CStr(Observacion)} _
            '.Description = Observacion _
            'ResponseCode = "07" Devolucion por item  en el Catalogo 9
            '================================================================================================================================= Fin Codigo Discrepancy

            '================================================================================================================================= Inicio Codigo LegalMonetaryTotal

            Dim legal As MonetaryTotalType() = New MonetaryTotalType(1) {}
            legal(0) = New MonetaryTotalType() With {
                .PayableAmount = FormatNumber(LegalMonetaryTotal, 2)
            }

            '================================================================================================================================= Fin Codigo LegalMonetaryTotal

            '================================================================================================================================= Inicio Codigo CustomerParty

            Dim accountcust As CustomerPartyType()
            If TipoIdentidad = "6" Or TipoIdentidad = "-" Or TipoIdentidad = "0" Then
                accountcust = New CustomerPartyType(1) {}
                accountcust(0) = New CustomerPartyType() With {
                   .CustomerAssignedAccountID = RucCli,
                   .AdditionalAccountID = New IdentifierType() {CStr(TipoIdentidad)},
                   .Party = New PartyType() With {
                    .PostalAddress = New AddressType() With {
                    .ID = CodUbigeoRec,
                    .StreetName = DireccionFiscal,
                    .CityName = NomDptoRec,
                    .CountrySubentity = NomProvRec,
                    .District = NomDistRec,
                    .Country = New CountryType() With {
                            .IdentificationCode = CodPais
                    }
                },
                .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With {
                    .RegistrationName = DesCli
                    }}
                   }
                }
            ElseIf TipoIdentidad = "1" Then
                accountcust = New CustomerPartyType(1) {}
                accountcust(0) = New CustomerPartyType() With {
                   .CustomerAssignedAccountID = DniCli,
                   .AdditionalAccountID = New IdentifierType() {CStr(TipoIdentidad)},
                   .Party = New PartyType() With {
                       .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With {
                           .RegistrationName = DesCli
                       }}
                   }
                }
            End If

            '================================================================================================================================= Fin Codigo CustomerParty

            '================================================================================================================================= Inicio Codigo AdditionalMonetary

            'Dim additionalmon As UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType()

            'additionalmon = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType(1) {}
            'additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
            '                .ID = "1001", _
            '                .PayableAmount = FormatNumber(TotVenta, 2) _
            '}

            Dim additionalmon As UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() = Nothing


            If InstructionID = "01" Then

                additionalmon = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType(2) {}
                additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With {
                                .ID = "1001",
                                .PayableAmount = FormatNumber(TotVenta, 2)
                }

                ' ''======================================================================================= Inicio Operaciones inafectas
                'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "1002", _
                '                .PayableAmount = FormatNumber(TotVenta, 2) _
                '}
                ''======================================================================================= Fin Operaciones inafectas

                ''======================================================================================= Inicio Operaciones exoneradas
                'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "1003", _
                '                .PayableAmount = FormatNumber(TotNeto, 2) _
                '}
                ''======================================================================================= Fin Operaciones exoneradas

                ''======================================================================================= Inicio Percepcion
                'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "2001", _
                '                .PayableAmount = FormatNumber(TotNeto, 2) _
                '}
                ''======================================================================================= Fin Percepcion

                '======================================================================================= Inicio Total Descuento
                'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "2005", _
                '                .PayableAmount = FormatNumber(TotDscto, 2) _
                '}
                '======================================================================================= Fin Total descuentos

            ElseIf InstructionID = "04" Then

                additionalmon = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType(1) {}
                'additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "1001", _
                '                .PayableAmount = FormatNumber(0, 2) _
                '}

                ''======================================================================================= Inicio Operaciones inafectas
                additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With {
                                .ID = "1002",
                                .PayableAmount = FormatNumber(TotVenta, 2)
                }
                ''======================================================================================= Fin Operaciones inafectas

                ''======================================================================================= Inicio Operaciones exoneradas
                'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "1003", _
                '                .PayableAmount = FormatNumber(TotNeto, 2) _
                '}
                ''======================================================================================= Fin Operaciones exoneradas

                ''======================================================================================= Inicio Percepcion
                'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "2001", _
                '                .PayableAmount = FormatNumber(TotNeto, 2) _
                '}
                ''======================================================================================= Fin Percepcion

                '======================================================================================= Inicio Total Descuento
                'additionalmon(2) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "2005", _
                '                .PayableAmount = FormatNumber(TotDscto, 2) _
                '}
                '======================================================================================= Fin Total descuentos

            End If
            '================================================================================================================================= Fin Codigo AdditionalMonetary

            '================================================================================================================================= Inicio Codigo InvoiceLine

            Dim line1 As CreditNoteLineType()

            Dim row As Janus.Windows.GridEX.GridEXRow

            If GridEX1.RowCount > 0 Then
                Dim cantline As Integer = GridEX1.RowCount
                line1 = New CreditNoteLineType(cantline) {}

                For j = 0 To 0 'GridEX1.RowCount - 1
                    Me.GridEX1.Row = j
                    row = Me.GridEX1.GetRow()

                    'Dim cantline As Integer = GridEX1.RowCount
                    'line1 = New InvoiceLineType(cantline) {}
                    'Dim line1 As InvoiceLineType() = New InvoiceLineType(cantline) {}

                    line1(j) = New CreditNoteLineType() With {
                           .ID = CStr(row.Cells("Item").Value),
                           .CreditedQuantity = New QuantityType() With {
                               .unitCode = CStr(row.Cells("unitCode").Value),
                               .Value = CDec(1)
                           },
                           .LineExtensionAmount = CDec(FormatNumber(row.Cells("TotVenta").Value, 2)),
                           .PricingReference = New PricingReferenceType() With {
                               .AlternativeConditionPrice = New PriceType() {New PriceType() With {
                                   .PriceAmount = CDec(FormatNumber(row.Cells("LegalMonetaryTotal").Value, 2)),
                                   .PriceTypeCode = CStr(row.Cells("CodigoPrecio").Value)
                               }}
                           },
                           .TaxTotal = New TaxTotalType() {New TaxTotalType() With {
                               .TaxAmount = CDec(FormatNumber(row.Cells("TaxAmount").Value, 2)),
                               .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With {
                                   .TaxAmount = CDec(FormatNumber(row.Cells("TaxAmount").Value, 2)),
                                   .TaxCategory = New TaxCategoryType() With {
                                       .TaxExemptionReasonCode = CStr(CodAfectacion),
                                       .TaxScheme = New TaxSchemeType() With {
                                           .ID = CStr(row.Cells("CodTributo").Value),
                                           .Name = CStr(row.Cells("NomTributo").Value),
                                           .TaxTypeCode = CStr(row.Cells("CodTributoInt").Value)
                                       }
                                   }
                               }}
                           }},
                           .Item = New ItemType() With {
                               .Description = New TextType() {CStr(row.Cells("Observacion").Value)},
                               .SellersItemIdentification = New ItemIdentificationType() With {
                                   .ID = CStr("-")
                               }
                           },
                           .Price = New PriceType() With {
                               .PriceAmount = CDec(FormatNumber(row.Cells("TotVenta").Value, 2))
                           }
                       }

                Next

            End If

            '==============================================================================================================================Fin Codigo InvoiceLine

            '==============================================================================================================================Inicio Codigo GenerarXML

            FacturacionElectronica.GenerarCreditNote(xmlFilename, Session.sRucEmp, Session.sDesEmp, Session.sCodUbigeo, Session.sDireccion, Session.sDepartamento, Session.sProvincia, Session.sDistrito, additionalmon, CurrencyId, Documento, FecDoc, discrepancy, documentreference(0), accountcust(0), taxtotal, legal(0), line1)

            '==============================================================================================================================Fin Codigo GenerarXML

            FirmadoDigital()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear xml")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try
    End Sub

    Private Sub CrearXMLDebitoSerializadoDet()
        Try
            Dim xmlFilename As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-08-" & Documento & ".xml"
            'Dim xmlFilename As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-08-" & Documento & ".xml"

            UblLarsen.Ubl2.UblBaseDocumentType.GlbCustomizationID = "1.0"

            AmountType.TlsDefaultCurrencyID = CurrencyId

            '================================================================================================================================= Inicio Codigo TaxTotal

            Dim taxtotal As TaxTotalType() = New TaxTotalType(1) {}
            taxtotal(0) = New TaxTotalType() With {
               .TaxAmount = FormatNumber(TaxAmount, 2),
               .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With {
                   .TaxAmount = FormatNumber(TaxAmount, 2),
                   .TaxCategory = New TaxCategoryType() With {
                       .TaxExemptionReasonCode = CodAfectacion,
                       .TaxScheme = New TaxSchemeType() With {
                           .ID = CodTributo,
                           .Name = NomTributo,
                           .TaxTypeCode = CodTributoInt
                       }
                   }
               }}
            }

            '================================================================================================================================= Inicio Codigo TaxTotal

            '================================================================================================================================= Inicio Codigo DocumentReference

            Dim documentreference As DocumentReferenceType() = New DocumentReferenceType(1) {}
            documentreference(0) = New DocumentReferenceType() With {
                    .ID = NumDocModifica,
                    .DocumentTypeCode = TipoDocModifica
            }

            '================================================================================================================================= Fin Codigo DocumentReference

            '================================================================================================================================= Inicio Codigo Discrepancy

            Dim discrepancy As ResponseType() = New ResponseType(1) {}
            discrepancy(0) = New ResponseType() With {
                .ReferenceID = NumDocModifica,
                .ResponseCode = CodTipoDeb,
                .Description = New TextType() {MotivoRef}
            }
            '.Description = New TextType() {CStr(Observacion)} _
            '.Description = Observacion _
            'ResponseCode = "02" Aumento en el valor en el Catalogo 10
            '================================================================================================================================= Fin Codigo Discrepancy

            '================================================================================================================================= Inicio Codigo LegalMonetaryTotal

            Dim legal As MonetaryTotalType() = New MonetaryTotalType(1) {}
            legal(0) = New MonetaryTotalType() With {
                .PayableAmount = FormatNumber(LegalMonetaryTotal, 2)
            }

            '================================================================================================================================= Fin Codigo LegalMonetaryTotal

            '================================================================================================================================= Inicio Codigo CustomerParty

            Dim accountcust As CustomerPartyType()
            If TipoIdentidad = "6" Or TipoIdentidad = "-" Or TipoIdentidad = "0" Then
                accountcust = New CustomerPartyType(1) {}
                accountcust(0) = New CustomerPartyType() With {
                   .CustomerAssignedAccountID = RucCli,
                   .AdditionalAccountID = New IdentifierType() {CStr(TipoIdentidad)},
                   .Party = New PartyType() With {
                       .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With {
                           .RegistrationName = DesCli
                       }}
                   }
                }
            ElseIf TipoIdentidad = "1" Then
                accountcust = New CustomerPartyType(1) {}
                accountcust(0) = New CustomerPartyType() With {
                   .CustomerAssignedAccountID = DniCli,
                   .AdditionalAccountID = New IdentifierType() {CStr(TipoIdentidad)},
                   .Party = New PartyType() With {
                       .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With {
                           .RegistrationName = DesCli
                       }}
                   }
                }

            End If

            '================================================================================================================================= Fin Codigo CustomerParty

            '================================================================================================================================= Inicio Codigo AdditionalMonetary

            'Dim additionalmon As UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType()

            'additionalmon = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType(1) {}
            'additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
            '                .ID = "1001", _
            '                .PayableAmount = FormatNumber(TotVenta, 2) _
            '}

            Dim additionalmon As UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() = Nothing


            If InstructionID = "01" Then

                additionalmon = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType(2) {}
                additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With {
                                .ID = "1001",
                                .PayableAmount = FormatNumber(TotVenta, 2)
                }

                ' ''======================================================================================= Inicio Operaciones inafectas
                'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "1002", _
                '                .PayableAmount = FormatNumber(TotVenta, 2) _
                '}
                ''======================================================================================= Fin Operaciones inafectas

                ''======================================================================================= Inicio Operaciones exoneradas
                'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "1003", _
                '                .PayableAmount = FormatNumber(TotNeto, 2) _
                '}
                ''======================================================================================= Fin Operaciones exoneradas

                ''======================================================================================= Inicio Percepcion
                'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "2001", _
                '                .PayableAmount = FormatNumber(TotNeto, 2) _
                '}
                ''======================================================================================= Fin Percepcion

                '======================================================================================= Inicio Total Descuento
                'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "2005", _
                '                .PayableAmount = FormatNumber(TotDscto, 2) _
                '}
                '======================================================================================= Fin Total descuentos

            ElseIf InstructionID = "04" Then

                additionalmon = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType(1) {}
                'additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "1001", _
                '                .PayableAmount = FormatNumber(0, 2) _
                '}

                ''======================================================================================= Inicio Operaciones inafectas
                additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With {
                                .ID = "1002",
                                .PayableAmount = FormatNumber(TotVenta, 2)
                }
                ''======================================================================================= Fin Operaciones inafectas

                ''======================================================================================= Inicio Operaciones exoneradas
                'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "1003", _
                '                .PayableAmount = FormatNumber(TotNeto, 2) _
                '}
                ''======================================================================================= Fin Operaciones exoneradas

                ''======================================================================================= Inicio Percepcion
                'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "2001", _
                '                .PayableAmount = FormatNumber(TotNeto, 2) _
                '}
                ''======================================================================================= Fin Percepcion

                '======================================================================================= Inicio Total Descuento
                'additionalmon(2) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "2005", _
                '                .PayableAmount = FormatNumber(TotDscto, 2) _
                '}
                '======================================================================================= Fin Total descuentos

            End If

            '================================================================================================================================= Fin Codigo AdditionalMonetary

            '================================================================================================================================= Inicio Codigo InvoiceLine

            Dim line1 As DebitNoteLineType()

            Dim row As Janus.Windows.GridEX.GridEXRow

            If GridEX1.RowCount > 0 Then
                Dim cantline As Integer = GridEX1.RowCount
                line1 = New DebitNoteLineType(cantline) {}

                For j = 0 To GridEX1.RowCount - 1
                    Me.GridEX1.Row = j
                    row = Me.GridEX1.GetRow()

                    'Dim cantline As Integer = GridEX1.RowCount
                    'line1 = New InvoiceLineType(cantline) {}
                    'Dim line1 As InvoiceLineType() = New InvoiceLineType(cantline) {}

                    line1(j) = New DebitNoteLineType() With {
                           .ID = CStr(row.Cells("Item").Value),
                           .DebitedQuantity = New QuantityType() With {
                               .unitCode = CStr(row.Cells("unitCode").Value),
                               .Value = CDec(row.Cells("CanMer").Value)
                           },
                           .LineExtensionAmount = CDec(FormatNumber(row.Cells("LineExtensionAmount").Value, 2)),
                           .PricingReference = New PricingReferenceType() With {
                               .AlternativeConditionPrice = New PriceType() {New PriceType() With {
                                   .PriceAmount = CDec(FormatNumber(row.Cells("Pricingreference").Value, 2)),
                                   .PriceTypeCode = CStr(row.Cells("CodigoPrecio").Value)
                               }}
                           },
                           .TaxTotal = New TaxTotalType() {New TaxTotalType() With {
                               .TaxAmount = CDec(FormatNumber(row.Cells("MontoIgv").Value, 2)),
                               .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With {
                                   .TaxAmount = CDec(FormatNumber(row.Cells("MontoIgv").Value, 2)),
                                   .TaxCategory = New TaxCategoryType() With {
                                       .TaxExemptionReasonCode = CStr(CodAfectacion),
                                       .TaxScheme = New TaxSchemeType() With {
                                           .ID = CStr(row.Cells("CodTributo").Value),
                                           .Name = CStr(row.Cells("NomTributo").Value),
                                           .TaxTypeCode = CStr(row.Cells("CodTributoInt").Value)
                                       }
                                   }
                               }}
                           }},
                           .Item = New ItemType() With {
                               .Description = New TextType() {CStr(row.Cells("DesMer1").Value)},
                               .SellersItemIdentification = New ItemIdentificationType() With {
                                   .ID = CStr(row.Cells("CodMer").Value)
                               }
                           },
                           .Price = New PriceType() With {
                               .PriceAmount = CDec(FormatNumber(row.Cells("Price").Value, 2))
                           }
                       }

                Next

            End If

            '==============================================================================================================================Fin Codigo InvoiceLine

            '==============================================================================================================================Inicio Codigo GenerarXML
            FacturacionElectronica.GenerarDebitNote(xmlFilename, Session.sRucEmp, Session.sDesEmp, Session.sCodUbigeo, Session.sDireccion, Session.sDepartamento, Session.sProvincia, Session.sDistrito, additionalmon, CurrencyId, Documento, FecDoc, discrepancy, documentreference(0), accountcust(0), taxtotal, legal(0), line1)
            '==============================================================================================================================Fin Codigo GenerarXML

            FirmadoDigital()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear xml")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try
    End Sub

    Private Sub CrearXMLDebitoSerializadoRes()
        Try
            Dim xmlFilename As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-08-" & Documento & ".xml"
            'Dim xmlFilename As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-08-" & Documento & ".xml"

            UblLarsen.Ubl2.UblBaseDocumentType.GlbCustomizationID = "1.0"

            AmountType.TlsDefaultCurrencyID = CurrencyId

            '================================================================================================================================= Inicio Codigo TaxTotal

            Dim taxtotal As TaxTotalType() = New TaxTotalType(1) {}
            taxtotal(0) = New TaxTotalType() With {
               .TaxAmount = FormatNumber(TaxAmount, 2),
               .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With {
                   .TaxAmount = FormatNumber(TaxAmount, 2),
                   .TaxCategory = New TaxCategoryType() With {
                       .TaxExemptionReasonCode = CodAfectacion,
                       .TaxScheme = New TaxSchemeType() With {
                           .ID = CodTributo,
                           .Name = NomTributo,
                           .TaxTypeCode = CodTributoInt
                       }
                   }
               }}
            }

            '================================================================================================================================= Inicio Codigo TaxTotal

            '================================================================================================================================= Inicio Codigo DocumentReference

            Dim documentreference As DocumentReferenceType() = New DocumentReferenceType(1) {}
            documentreference(0) = New DocumentReferenceType() With {
                    .ID = NumDocModifica,
                    .DocumentTypeCode = TipoDocModifica
            }

            '================================================================================================================================= Fin Codigo DocumentReference

            '================================================================================================================================= Inicio Codigo Discrepancy

            Dim discrepancy As ResponseType() = New ResponseType(1) {}
            discrepancy(0) = New ResponseType() With {
                .ReferenceID = NumDocModifica,
                .ResponseCode = CodTipoDeb,
                .Description = New TextType() {MotivoRef}
            }
            '.Description = New TextType() {CStr(Observacion)} _
            '.Description = Observacion _
            'ResponseCode = "02" Aumento en el valor en el Catalogo 10
            '================================================================================================================================= Fin Codigo Discrepancy

            '================================================================================================================================= Inicio Codigo LegalMonetaryTotal

            Dim legal As MonetaryTotalType() = New MonetaryTotalType(1) {}
            legal(0) = New MonetaryTotalType() With {
                .PayableAmount = FormatNumber(LegalMonetaryTotal, 2)
            }

            '================================================================================================================================= Fin Codigo LegalMonetaryTotal

            '================================================================================================================================= Inicio Codigo CustomerParty

            Dim accountcust As CustomerPartyType()
            If TipoIdentidad = "6" Or TipoIdentidad = "-" Or TipoIdentidad = "0" Then
                accountcust = New CustomerPartyType(1) {}
                accountcust(0) = New CustomerPartyType() With {
                   .CustomerAssignedAccountID = RucCli,
                   .AdditionalAccountID = New IdentifierType() {CStr(TipoIdentidad)},
                   .Party = New PartyType() With {
                       .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With {
                           .RegistrationName = DesCli
                       }}
                   }
                }
            ElseIf TipoIdentidad = "1" Then
                accountcust = New CustomerPartyType(1) {}
                accountcust(0) = New CustomerPartyType() With {
                   .CustomerAssignedAccountID = DniCli,
                   .AdditionalAccountID = New IdentifierType() {CStr(TipoIdentidad)},
                   .Party = New PartyType() With {
                       .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With {
                           .RegistrationName = DesCli
                       }}
                   }
                }

            End If

            '================================================================================================================================= Fin Codigo CustomerParty

            '================================================================================================================================= Inicio Codigo AdditionalMonetary

            'Dim additionalmon As UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType()

            'additionalmon = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType(1) {}
            'additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
            '                .ID = "1001", _
            '                .PayableAmount = FormatNumber(TotVenta, 2) _
            '}

            Dim additionalmon As UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() = Nothing


            If InstructionID = "01" Then

                additionalmon = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType(2) {}
                additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With {
                                .ID = "1001",
                                .PayableAmount = FormatNumber(TotVenta, 2)
                }

                ' ''======================================================================================= Inicio Operaciones inafectas
                'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "1002", _
                '                .PayableAmount = FormatNumber(TotVenta, 2) _
                '}
                ''======================================================================================= Fin Operaciones inafectas

                ''======================================================================================= Inicio Operaciones exoneradas
                'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "1003", _
                '                .PayableAmount = FormatNumber(TotNeto, 2) _
                '}
                ''======================================================================================= Fin Operaciones exoneradas

                ''======================================================================================= Inicio Percepcion
                'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "2001", _
                '                .PayableAmount = FormatNumber(TotNeto, 2) _
                '}
                ''======================================================================================= Fin Percepcion

                '======================================================================================= Inicio Total Descuento
                'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "2005", _
                '                .PayableAmount = FormatNumber(TotDscto, 2) _
                '}
                '======================================================================================= Fin Total descuentos

            ElseIf InstructionID = "04" Then

                additionalmon = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType(1) {}
                'additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "1001", _
                '                .PayableAmount = FormatNumber(0, 2) _
                '}

                ''======================================================================================= Inicio Operaciones inafectas
                additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With {
                                .ID = "1002",
                                .PayableAmount = FormatNumber(TotVenta, 2)
                }
                ''======================================================================================= Fin Operaciones inafectas

                ''======================================================================================= Inicio Operaciones exoneradas
                'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "1003", _
                '                .PayableAmount = FormatNumber(TotNeto, 2) _
                '}
                ''======================================================================================= Fin Operaciones exoneradas

                ''======================================================================================= Inicio Percepcion
                'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "2001", _
                '                .PayableAmount = FormatNumber(TotNeto, 2) _
                '}
                ''======================================================================================= Fin Percepcion

                '======================================================================================= Inicio Total Descuento
                'additionalmon(2) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                '                .ID = "2005", _
                '                .PayableAmount = FormatNumber(TotDscto, 2) _
                '}
                '======================================================================================= Fin Total descuentos

            End If

            '================================================================================================================================= Fin Codigo AdditionalMonetary

            '================================================================================================================================= Inicio Codigo InvoiceLine

            Dim line1 As DebitNoteLineType()

            Dim row As Janus.Windows.GridEX.GridEXRow

            If GridEX1.RowCount > 0 Then
                Dim cantline As Integer = GridEX1.RowCount
                line1 = New DebitNoteLineType(cantline) {}

                For j = 0 To 0 'GridEX1.RowCount - 1
                    Me.GridEX1.Row = j
                    row = Me.GridEX1.GetRow()

                    'Dim cantline As Integer = GridEX1.RowCount
                    'line1 = New InvoiceLineType(cantline) {}
                    'Dim line1 As InvoiceLineType() = New InvoiceLineType(cantline) {}

                    line1(j) = New DebitNoteLineType() With {
                           .ID = CStr(row.Cells("Item").Value),
                           .DebitedQuantity = New QuantityType() With {
                               .unitCode = CStr(row.Cells("unitCode").Value),
                               .Value = CDec(row.Cells("CanMer").Value)
                           },
                           .LineExtensionAmount = CDec(FormatNumber(row.Cells("TotVenta").Value, 2)),
                           .PricingReference = New PricingReferenceType() With {
                               .AlternativeConditionPrice = New PriceType() {New PriceType() With {
                                   .PriceAmount = CDec(FormatNumber(row.Cells("LegalMonetaryTotal").Value, 2)),
                                   .PriceTypeCode = CStr(row.Cells("CodigoPrecio").Value)
                               }}
                           },
                           .TaxTotal = New TaxTotalType() {New TaxTotalType() With {
                               .TaxAmount = CDec(FormatNumber(row.Cells("TaxAmount").Value, 2)),
                               .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With {
                                   .TaxAmount = CDec(FormatNumber(row.Cells("TaxAmount").Value, 2)),
                                   .TaxCategory = New TaxCategoryType() With {
                                       .TaxExemptionReasonCode = CStr(CodAfectacion),
                                       .TaxScheme = New TaxSchemeType() With {
                                           .ID = CStr(row.Cells("CodTributo").Value),
                                           .Name = CStr(row.Cells("NomTributo").Value),
                                           .TaxTypeCode = CStr(row.Cells("CodTributoInt").Value)
                                       }
                                   }
                               }}
                           }},
                           .Item = New ItemType() With {
                               .Description = New TextType() {CStr(row.Cells("Observacion").Value)},
                               .SellersItemIdentification = New ItemIdentificationType() With {
                                   .ID = CStr("-")
                               }
                           },
                           .Price = New PriceType() With {
                               .PriceAmount = CDec(FormatNumber(row.Cells("TotVenta").Value, 2))
                           }
                       }

                Next

            End If

            '==============================================================================================================================Fin Codigo InvoiceLine

            '==============================================================================================================================Inicio Codigo GenerarXML

            FacturacionElectronica.GenerarDebitNote(xmlFilename, Session.sRucEmp, Session.sDesEmp, Session.sCodUbigeo, Session.sDireccion, Session.sDepartamento, Session.sProvincia, Session.sDistrito, additionalmon, CurrencyId, Documento, FecDoc, discrepancy, documentreference(0), accountcust(0), taxtotal, legal(0), line1)

            '==============================================================================================================================Fin Codigo GenerarXML

            FirmadoDigital()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear xml")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try
    End Sub


    Private Sub FirmadoDigital()

        If TipoDocModifica = "01" Then
            FirmadoDigitalFactura()
        ElseIf TipoDocModifica = "03" Then
            FirmadoDigitalBoleta()
        End If

    End Sub


    Private Sub FirmadoDigitalFactura()
        Try
            Dim ObjLib As New FirmarDocumento

            Dim direccion As String = ""
            Dim firmado As Boolean
            Dim tipo As Integer

            If IdDocumento = "5" Then
                direccion = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-07-" & Documento & ".xml"
                'direccion = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-07-" & Documento & ".xml"
                tipo = 2
            ElseIf IdDocumento = "6" Then
                direccion = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-08-" & Documento & ".xml"
                'direccion = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-08-" & Documento & ".xml"
                tipo = 3
            End If

            Dim ruta As String = System.AppDomain.CurrentDomain.BaseDirectory & "Certificado\" & Session.sNombreCertificado
            'Dim ruta As String = System.AppDomain.CurrentDomain.BaseDirectory & "Certificado\CertificadoFacturacion.pfx"

            'firmado = ObjLib.SignXmlFile(Session.sRucEmp, tipo, ruta, Session.sClaveCertificado, direccion)

            firmado = FirmarDocumento21.SignXmlFile(Session.sRucEmp, tipo, ruta, Session.sClaveCertificado, direccion)

            'firmado = ObjLib.SignXmlFile("20100020441", tipo, ruta, "DdperU", direccion)

            If firmado = True Then

                If IdDocumento = "5" Then
                    Dim xmlDoc As New XmlDocument
                    xmlDoc.Load("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-07-" & Documento & ".xml")
                    'xmlDoc.Load("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-07-" & Documento & ".xml")

                    Dim insertar As Boolean
                    'Dim nombrexml As String = GridEX1.CurrentRow.Cells("NumDoc").Text & ".xml"     'Comentado para que en el evento de descargar se obtenga el numdoc sin el ".xml"
                    Dim nombrexml As String = Session.sRucEmp & "-07-" & Documento '& ".xml"
                    'Dim nombrexml As String = "20100020441-07-" & Documento '& ".xml"
                    'insertar = oNotaDigitalService.Insertar(IdNota, nombrexml, xmlDoc.OuterXml, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                    Comprimir()

                    Dim resulenvio As Boolean = False
                    Dim rutaenvio As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\"
                    'Dim file As String = Session.sRucEmp & "-07-" & Documento & ".ZIP"
                    Dim file As String = Session.sRucEmp & "-07-" & Documento


                    'If Session.sCodEmp = "01" Or Session.sCodEmp = "02" Then
                    '    'resulenvio = oComunicacionSunat.EnviarDocumentoSunat(rutaenvio, file)
                    '    resulenvio = EnviarSunat21.EnviarDocumentoOSE(Session.sRucEmp, Session.sUsuarioOSE, Session.sClaveOSE, rutaenvio, file)
                    'Else
                    '    'resulenvio = oComunicacionSunat.EnviarDocumentoIquitosSunat(rutaenvio, file)
                    '    'file = Session.sRucEmp & "-07-" & Documento
                    '    resulenvio = EnviarSunat.EnviarDocumentoProduccion(Session.sRucEmp, Session.sUsuarioSunat, Session.sClaveSunat, rutaenvio, file)
                    'End If

                    If Session.sAplicaOSE Then
                        resulenvio = EnviarSunat21.EnviarDocumentoOSE(Session.sRucEmp, Session.sUsuarioOSE, Session.sClaveOSE, rutaenvio, file)
                    Else
                        resulenvio = EnviarSunat21.EnviarDocumentoProduccion(Session.sRucEmp, Session.sUsuarioSunat, Session.sClaveSunat, rutaenvio, file)
                    End If

                    'resulenvio = oComunicacionSunat.EnviarDocumentoSunat(rutaenvio, file)
                    'resulenvio = EnviarSunat.EnviarDocumentoProduccion("20100020441", "CCUETO15", "10048380", rutaenvio, file)

                    If resulenvio Then

                        Dim xmlDocR As New XmlDocument
                        xmlDocR.Load("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\R-" & Session.sRucEmp & "-07-" & Documento & ".xml")
                        'xmlDocR.Load("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\R-20100020441-07-" & Documento & ".xml")

                        '/////////OBTENER ESTADO E INFORMACION DEL CDR SUNAT/////////////////////////
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
                        Dim Descripcioncdr As String = oNode.InnerText
                        Responsecode = oNode2.InnerText
                        Dim NumTicket As String = oNode3.InnerText
                        '///////////////////////////////////////////////////////////////////////////

                        Dim rutapdf As New FileStream("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-07-" & Documento & ".pdf", FileMode.Open, FileAccess.Read)
                        'Dim rutapdf As New FileStream("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-07-" & Documento & ".pdf", FileMode.Open, FileAccess.Read)
                        Dim binario(rutapdf.Length) As Byte
                        rutapdf.Read(binario, 0, rutapdf.Length) 'Leo el archivo y lo convierto a binario
                        rutapdf.Close()

                        Dim registro As New NotaDigitalService.NotaDigital
                        Dim nota As New NotaDigitalService.NotaCredito

                        registro.CDRxml = xmlDocR.OuterXml
                        registro.CodUsu = Session.sCodUsu
                        registro.DirIp = Session.sDirIp
                        registro.DocumentoXml = xmlDoc.OuterXml
                        registro.Estado = Responsecode
                        nota.IdNota = IdNota
                        registro.NotaCredito = nota
                        registro.NombreXml = nombrexml
                        registro.NomPc = Session.sNomPc
                        registro.NumTicket = NumTicket
                        registro.Observacion = Descripcioncdr
                        registro.Notas = toNull(notecompilado)
                        registro.DocumentoPdf = binario

                        insertar = oNotaDigitalService.Insertar(registro)

                        If insertar Then
                            MsgBox("Se proceso la nota electronica correctamente", MsgBoxStyle.Information)
                            EstadoSunat = True
                        Else
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        End If
                    Else
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If

                    If Responsecode <> "0" Then
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If

                ElseIf IdDocumento = "6" Then
                    Dim xmlDoc As New XmlDocument
                    xmlDoc.Load("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-08-" & Documento & ".xml")
                    'xmlDoc.Load("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-08-" & Documento & ".xml")

                    Dim insertar As Boolean
                    'Dim nombrexml As String = GridEX1.CurrentRow.Cells("NumDoc").Text & ".xml"     'Comentado para que en el evento de descargar se obtenga el numdoc sin el ".xml"
                    Dim nombrexml As String = Session.sRucEmp & "-08-" & Documento '& ".xml"
                    'Dim nombrexml As String = "20100020441-08-" & Documento '& ".xml"
                    'insertar = oNotaDigitalService.Insertar(IdNota, nombrexml, xmlDoc.OuterXml, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                    Comprimir()

                    Dim resulenvio As Boolean = False
                    Dim rutaenvio As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\"
                    'Dim file As String = Session.sRucEmp & "-08-" & Documento & ".ZIP"
                    'Dim file As String = "20100020441-08-" & Documento & ".ZIP"
                    'Dim file As String = "20100020441-08-" & Documento


                    'If Session.sCodEmp = "01" Then
                    '    resulenvio = oComunicacionSunat.EnviarDocumentoSunat(rutaenvio, file)
                    'Else
                    '    'resulenvio = oComunicacionSunat.EnviarDocumentoIquitosSunat(rutaenvio, file)
                    '    file = Session.sRucEmp & "-08-" & Documento
                    '    resulenvio = EnviarSunat.EnviarDocumentoProduccion(Session.sRucEmp, Session.sUsuarioSunat, Session.sClaveSunat, rutaenvio, file)

                    'End If

                    Dim file As String = Session.sRucEmp & "-08-" & Documento
                    If Session.sAplicaOSE Then
                        resulenvio = EnviarSunat21.EnviarDocumentoOSE(Session.sRucEmp, Session.sUsuarioOSE, Session.sClaveOSE, rutaenvio, file)
                    Else
                        resulenvio = EnviarSunat21.EnviarDocumentoProduccion(Session.sRucEmp, Session.sUsuarioSunat, Session.sClaveSunat, rutaenvio, file)
                    End If


                    If resulenvio Then

                        Dim xmlDocR As New XmlDocument
                        xmlDocR.Load("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\R-" & Session.sRucEmp & "-08-" & Documento & ".xml")
                        'xmlDocR.Load("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\R-20100020441-08-" & Documento & ".xml")

                        '/////////OBTENER ESTADO E INFORMACION DEL CDR SUNAT/////////////////////////
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
                        Dim Descripcioncdr As String = oNode.InnerText
                        Responsecode = oNode2.InnerText
                        Dim NumTicket As String = oNode3.InnerText
                        '///////////////////////////////////////////////////////////////////////////

                        Dim rutapdf As New FileStream("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-08-" & Documento & ".pdf", FileMode.Open, FileAccess.Read)
                        'Dim rutapdf As New FileStream("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-08-" & Documento & ".pdf", FileMode.Open, FileAccess.Read)
                        Dim binario(rutapdf.Length) As Byte
                        rutapdf.Read(binario, 0, rutapdf.Length) 'Leo el archivo y lo convierto a binario
                        rutapdf.Close()

                        Dim registro As New NotaDigitalService.NotaDigital
                        Dim nota As New NotaDigitalService.NotaCredito

                        registro.CDRxml = xmlDocR.OuterXml
                        registro.CodUsu = Session.sCodUsu
                        registro.DirIp = Session.sDirIp
                        registro.DocumentoXml = xmlDoc.OuterXml
                        registro.Estado = Responsecode
                        nota.IdNota = IdNota
                        registro.NotaCredito = nota
                        registro.NombreXml = nombrexml
                        registro.NomPc = Session.sNomPc
                        registro.NumTicket = NumTicket
                        registro.Observacion = Descripcioncdr
                        registro.Notas = toNull(notecompilado)
                        registro.DocumentoPdf = binario

                        insertar = oNotaDigitalService.Insertar(registro)

                        If insertar Then
                            MsgBox("Se proceso la nota electronica correctamente", MsgBoxStyle.Information)
                            EstadoSunat = True
                        Else
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        End If
                    Else
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If

                    If Responsecode <> "0" Then
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If

                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al firmar el documento")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try
    End Sub

    Private Sub FirmadoDigitalBoleta()

        Try
            Dim ObjLib As New FirmarDocumento

            Dim direccion As String = ""
            Dim firmado As Boolean
            Dim tipo As Integer

            If IdDocumento = "5" Then
                direccion = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-07-" & Documento & ".xml"
                'direccion = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-07-" & Documento & ".xml"
                tipo = 2
            ElseIf IdDocumento = "6" Then
                direccion = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-08-" & Documento & ".xml"
                'direccion = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-08-" & Documento & ".xml"
                tipo = 3
            End If

            Dim ruta As String = System.AppDomain.CurrentDomain.BaseDirectory & "Certificado\" & Session.sNombreCertificado
            'Dim ruta As String = System.AppDomain.CurrentDomain.BaseDirectory & "Certificado\CertificadoFacturacion.pfx"

            'firmado = ObjLib.SignXmlFile(Session.sRucEmp, tipo, ruta, Session.sClaveCertificado, direccion)

            firmado = FirmarDocumento21.SignXmlFile(Session.sRucEmp, tipo, ruta, Session.sClaveCertificado, direccion)

            'firmado = ObjLib.SignXmlFile("20100020441", tipo, ruta, "DdperU", direccion)

            If firmado = True Then

                If IdDocumento = "5" Then
                    Dim xmlDoc As New XmlDocument
                    xmlDoc.Load("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-07-" & Documento & ".xml")
                    'xmlDoc.Load("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-07-" & Documento & ".xml")

                    Dim insertar As Boolean
                    'Dim nombrexml As String = GridEX1.CurrentRow.Cells("NumDoc").Text & ".xml"     'Comentado para que en el evento de descargar se obtenga el numdoc sin el ".xml"
                    Dim nombrexml As String = Session.sRucEmp & "-" & Documento '& ".xml"
                    'Dim nombrexml As String = "20100020441-07-" & Documento '& ".xml"
                    'insertar = oNotaDigitalService.Insertar(IdNota, nombrexml, xmlDoc.OuterXml, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                    Comprimir()
                    ''====================================================================================================================== Comentado porque en produccion SUNAT no responde
                    'Dim resulenvio As Boolean
                    'Dim rutaenvio As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\"
                    'Dim file As String = "20100020441-07-" & Documento & ".ZIP"

                    'resulenvio = oComunicacionSunat.EnviarDocumentoSunat(rutaenvio, file)

                    'If resulenvio Then

                    'Dim xmlDocR As New XmlDocument
                    'xmlDocR.Load("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\R-20100020441-07-" & Documento & ".xml")

                    ''/////////OBTENER ESTADO E INFORMACION DEL CDR SUNAT/////////////////////////
                    'Dim namespaces As XmlNamespaceManager = New XmlNamespaceManager(xmlDocR.NameTable)
                    'namespaces.AddNamespace("ns", "urn:oasis:names:specification:ubl:schema:xsd:ApplicationResponse-2")
                    'namespaces.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")
                    'namespaces.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")
                    'namespaces.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#")
                    'namespaces.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")

                    'Dim notecompilado As String = ""
                    'Dim contador As Integer = 0
                    'Dim xnList As XmlNodeList = xmlDocR.SelectNodes("/ns:ApplicationResponse/cbc:Note", namespaces)
                    'For Each xn As XmlNode In xnList
                    '    notecompilado = notecompilado & xnList.Item(contador).InnerText & ". " & Environment.NewLine
                    '    contador = contador + 1
                    'Next

                    'Dim xPathString = "/ns:ApplicationResponse/cac:DocumentResponse/cac:Response/cbc:Description"
                    'Dim xPathString2 = "/ns:ApplicationResponse/cac:DocumentResponse/cac:Response/cbc:ResponseCode"
                    'Dim xPathString3 = "/ns:ApplicationResponse/cbc:ID"
                    'Dim oNode = xmlDocR.SelectSingleNode(xPathString, namespaces)
                    'Dim oNode2 = xmlDocR.SelectSingleNode(xPathString2, namespaces)
                    'Dim oNode3 = xmlDocR.SelectSingleNode(xPathString3, namespaces)
                    'Dim Descripcioncdr As String = oNode.InnerText
                    'Responsecode = oNode2.InnerText
                    'Dim NumTicket As String = oNode3.InnerText
                    ''///////////////////////////////////////////////////////////////////////////

                    Dim rutapdf As New FileStream("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-07-" & Documento & ".pdf", FileMode.Open, FileAccess.Read)
                    'Dim rutapdf As New FileStream("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-07-" & Documento & ".pdf", FileMode.Open, FileAccess.Read)
                    Dim binario(rutapdf.Length) As Byte
                    rutapdf.Read(binario, 0, rutapdf.Length) 'Leo el archivo y lo convierto a binario
                    rutapdf.Close()

                    Dim registro As New NotaDigitalService.NotaDigital
                    Dim nota As New NotaDigitalService.NotaCredito

                    registro.CDRxml = "" 'xmlDocR.OuterXml
                    registro.CodUsu = Session.sCodUsu
                    registro.DirIp = Session.sDirIp
                    registro.DocumentoXml = xmlDoc.OuterXml
                    registro.Estado = Responsecode
                    nota.IdNota = IdNota
                    registro.NotaCredito = nota
                    registro.NombreXml = nombrexml
                    registro.NomPc = Session.sNomPc
                    registro.NumTicket = "" 'NumTicket
                    registro.Observacion = "" '"" 'Descripcioncdr
                    registro.Notas = Nothing
                    registro.DocumentoPdf = binario

                    insertar = oNotaDigitalService.Insertar(registro)

                    If insertar Then
                        MsgBox("Se proceso la nota electronica correctamente", MsgBoxStyle.Information)
                        EstadoSunat = True
                    Else
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If
                    'Else
                    '    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    'End If

                    'Comentado porque en produccion no devuelve respuesta la sunat
                    'If Responsecode <> "0" Then
                    '    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    'End If

                ElseIf IdDocumento = "6" Then
                    Dim xmlDoc As New XmlDocument
                    xmlDoc.Load("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-08-" & Documento & ".xml")
                    'xmlDoc.Load("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-08-" & Documento & ".xml")

                    Dim insertar As Boolean
                    'Dim nombrexml As String = GridEX1.CurrentRow.Cells("NumDoc").Text & ".xml"     'Comentado para que en el evento de descargar se obtenga el numdoc sin el ".xml"
                    Dim nombrexml As String = Session.sRucEmp & "-08-" & Documento '& ".xml"
                    'Dim nombrexml As String = "20100020441-08-" & Documento '& ".xml"
                    'insertar = oNotaDigitalService.Insertar(IdNota, nombrexml, xmlDoc.OuterXml, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                    Comprimir()
                    ''====================================================================================================================== Comentado porque en produccion SUNAT no responde
                    'Dim resulenvio As Boolean
                    'Dim rutaenvio As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\"
                    'Dim file As String = "20100020441-08-" & Documento & ".ZIP"

                    'resulenvio = oComunicacionSunat.EnviarDocumentoSunat(rutaenvio, file)

                    'If resulenvio Then

                    'Dim xmlDocR As New XmlDocument
                    'xmlDocR.Load("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\R-20100020441-08-" & Documento & ".xml")

                    ''/////////OBTENER ESTADO E INFORMACION DEL CDR SUNAT/////////////////////////
                    'Dim namespaces As XmlNamespaceManager = New XmlNamespaceManager(xmlDocR.NameTable)
                    'namespaces.AddNamespace("ns", "urn:oasis:names:specification:ubl:schema:xsd:ApplicationResponse-2")
                    'namespaces.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")
                    'namespaces.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")
                    'namespaces.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#")
                    'namespaces.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")

                    'Dim notecompilado As String = ""
                    'Dim contador As Integer = 0
                    'Dim xnList As XmlNodeList = xmlDocR.SelectNodes("/ns:ApplicationResponse/cbc:Note", namespaces)
                    'For Each xn As XmlNode In xnList
                    '    notecompilado = notecompilado & xnList.Item(contador).InnerText & ". " & Environment.NewLine
                    '    contador = contador + 1
                    'Next

                    'Dim xPathString = "/ns:ApplicationResponse/cac:DocumentResponse/cac:Response/cbc:Description"
                    'Dim xPathString2 = "/ns:ApplicationResponse/cac:DocumentResponse/cac:Response/cbc:ResponseCode"
                    'Dim xPathString3 = "/ns:ApplicationResponse/cbc:ID"
                    'Dim oNode = xmlDocR.SelectSingleNode(xPathString, namespaces)
                    'Dim oNode2 = xmlDocR.SelectSingleNode(xPathString2, namespaces)
                    'Dim oNode3 = xmlDocR.SelectSingleNode(xPathString3, namespaces)
                    'Dim Descripcioncdr As String = oNode.InnerText
                    'Responsecode = oNode2.InnerText
                    'Dim NumTicket As String = oNode3.InnerText
                    ''///////////////////////////////////////////////////////////////////////////

                    Dim rutapdf As New FileStream("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-08-" & Documento & ".pdf", FileMode.Open, FileAccess.Read)
                    'Dim rutapdf As New FileStream("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-08-" & Documento & ".pdf", FileMode.Open, FileAccess.Read)
                    Dim binario(rutapdf.Length) As Byte
                    rutapdf.Read(binario, 0, rutapdf.Length) 'Leo el archivo y lo convierto a binario
                    rutapdf.Close()

                    Dim registro As New NotaDigitalService.NotaDigital
                    Dim nota As New NotaDigitalService.NotaCredito

                    registro.CDRxml = "" 'xmlDocR.OuterXml
                    registro.CodUsu = Session.sCodUsu
                    registro.DirIp = Session.sDirIp
                    registro.DocumentoXml = xmlDoc.OuterXml
                    registro.Estado = Responsecode
                    nota.IdNota = IdNota
                    registro.NotaCredito = nota
                    registro.NombreXml = nombrexml
                    registro.NomPc = Session.sNomPc
                    registro.NumTicket = "" 'NumTicket
                    registro.Observacion = "" 'Descripcioncdr
                    registro.Notas = Nothing 'toNull(notecompilado)
                    registro.DocumentoPdf = binario

                    insertar = oNotaDigitalService.Insertar(registro)

                    If insertar Then
                        MsgBox("Se proceso la nota electronica correctamente", MsgBoxStyle.Information)
                        EstadoSunat = True
                    Else
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If
                    'Else
                    '    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    'End If
                    'Comentado porque en produccion no devuelve respuesta la sunat
                    'If Responsecode <> "0" Then
                    '    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    'End If

                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al firmar el documento")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try

    End Sub

    Private Sub Comprimir()

        If IdDocumento = "5" Then

            Dim destdir As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-07-" & Documento & ".zip"
            'Dim destdir As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-07-" & Documento & ".zip"

            Dim zip As ZipFile = New ZipFile
            Dim file As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-07-" & Documento & ".xml"
            'Dim file As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-07-" & Documento & ".xml"
            zip.AddFile(file, "")
            zip.Save(destdir)

        ElseIf IdDocumento = "6" Then

            Dim destdir As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-08-" & Documento & ".zip"
            'Dim destdir As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-08-" & Documento & ".zip"

            Dim zip As ZipFile = New ZipFile
            Dim file As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-08-" & Documento & ".xml"
            'Dim file As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-08-" & Documento & ".xml"
            zip.AddFile(file, "")
            zip.Save(destdir)

        End If

        ObtenerTagFirma()
        CrearPDF()

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

                xmlDoc.Load("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-07-" & Documento & ".xml")
                'xmlDoc.Load("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-07-" & Documento & ".xml")
                Dim xPathStringInfo = "/ns:CreditNote/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent/ds:Signature[@Id='SignatureSP']/ds:SignedInfo"
                Dim xPathStringValue = "/ns:CreditNote/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent/ds:Signature[@Id='SignatureSP']/ds:SignatureValue"

                Dim oNodeInfo = xmlDoc.SelectSingleNode(xPathStringInfo, namespaces)
                ValorResumen = oNodeInfo.InnerText

                Dim oNodeValue = xmlDoc.SelectSingleNode(xPathStringValue, namespaces)
                ValorFirma = oNodeValue.InnerText

            ElseIf IdDocumento = "6" Then

                xmlDoc.Load("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-08-" & Documento & ".xml")
                'xmlDoc.Load("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-08-" & Documento & ".xml")
                Dim xPathStringInfo = "/ns:DebitNote/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent/ds:Signature[@Id='SignatureSP']/ds:SignedInfo"
                Dim xPathStringValue = "/ns:DebitNote/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent/ds:Signature[@Id='SignatureSP']/ds:SignatureValue"

                Dim oNodeInfo = xmlDoc.SelectSingleNode(xPathStringInfo, namespaces)
                ValorResumen = oNodeInfo.InnerText

                Dim oNodeValue = xmlDoc.SelectSingleNode(xPathStringValue, namespaces)
                ValorFirma = oNodeValue.InnerText
            End If

            'Dim xPathStringInfo = "/ns:DebitNote/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent/ds:Signature[@Id='SignatureSP']/ds:SignedInfo"
            'Dim xPathStringValue = "/ns:DebitNote/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent/ds:Signature[@Id='SignatureSP']/ds:SignatureValue"

            'Dim oNodeInfo = xmlDoc.SelectSingleNode(xPathStringInfo, namespaces)
            'ValorResumen = oNodeInfo.InnerText

            'Dim oNodeValue = xmlDoc.SelectSingleNode(xPathStringValue, namespaces)
            'ValorFirma = oNodeValue.InnerText

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Obtener el Tag")
        End Try

    End Sub

    Private Sub CrearPDF()

        Try

            Dim ZX As New ZXing.BarcodeWriter
            Dim bmp As Bitmap
            Dim options As ZXing.QrCode.QrCodeEncodingOptions

            options = New ZXing.QrCode.QrCodeEncodingOptions
            options.ErrorCorrection = ZXing.QrCode.Internal.ErrorCorrectionLevel.Q
            options.Height = 190
            options.Width = 190
            options.Margin = 0.9
            options.PureBarcode = True

            ZX.Format = ZXing.BarcodeFormat.QR_CODE
            ZX.Options = options

            Dim url As String = RucEmp & "|" & TipoDoc & "|" & CodSerie & "|" & NumDoc & "|" & FormatNumber(TaxAmount, 2) & "|" & FormatNumber(LegalMonetaryTotal, 2) & "|" & FecDoc.ToString("yyyy-MM-dd") & "|" & TipoIdentidad & "|" & IIf(TipoIdentidad = "1", DniCli, RucCli) & "|" & ValorResumen
            UbicacionCodBarra = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Documento & ".png"

            bmp = ZX.Write(url)
            bmp.Save(UbicacionCodBarra, Imaging.ImageFormat.Png)



            'Dim qr As PDF417Writer = New PDF417Writer
            ''Dim NumDocsinSerie As String = Mid(NumDoc, 6, NumDoc.Length - 5)
            ''Dim url As String = "20100022142|01|F106|611|783.00|5133.00|2015-03-20|6|20100020441|oWUMtPr6aTZltzrFFI6whBA8qdg=|QaBVEy1zRK7VXLM5va0by+mInYDN2fhZBsPbOHXQlBytjj0RZVgjLMkSBhKeUe1kTU5Fk7yZI2S/wAKm/V8W7scEEf7kc3X7WCJwk0lrLoiY0l+N0S0AVJjZcm6wmlN0QB4jh+rTiy+STdhDhx37Ye5QmHAJyR0nB2OYrff2FeegsDv+XY7opVC8jjqxfJXlhvjrklLtMt4w4ueJ+i/YNRIj3D3kYnuj4IXp1SIpwQ3GYJs95yALfn9IME6zXfVkRmjXTqYUS5yAFFYqAc6r01WzcZQSKHPUIPQtoNLN0AHaTT0qQ7gKgBozoDDK0gR5RJ7jEaFd85S4o0h7EaysMg==|"
            'Dim url As String = RucEmp & "|" & TipoDoc & "|" & CodSerie & "|" & NumDoc & "|" & FormatNumber(TaxAmount, 2) & "|" & FormatNumber(LegalMonetaryTotal, 2) & "|" & FecDoc.ToString("yyyy-MM-dd") & "|" & TipoIdentidad & "|" & IIf(TipoIdentidad = "1", DniCli, RucCli) & "|" & ValorResumen & "|" & ValorFirma

            ''Dim hints As New Dictionary(Of EncodeHintType, Object)
            ''hints.Add(EncodeHintType.ERROR_CORRECTION, PDF417ErrorCorrectionLevel.L5)
            ''hints.Add(EncodeHintType.MARGIN, "0.20")

            'Dim hints As IDictionary(Of EncodeHintType, Object) = New Dictionary(Of EncodeHintType, Object)
            'hints.Add(EncodeHintType.CHARACTER_SET, "ISO8859-1")
            ''hints.Add(EncodeHintType.ERROR_CORRECTION, 5)
            'hints.Add(EncodeHintType.ERROR_CORRECTION, PDF417ErrorCorrectionLevel.L5)
            'hints.Add(EncodeHintType.MARGIN, 5)         '5 es a 1mm , 20 es a 4mm
            'hints.Add(EncodeHintType.PDF417_COMPACTION, Compaction.BYTE)
            'hints.Add(EncodeHintType.DISABLE_ECI, True)
            ''hints.Add(EncodeHintType.PURE_BARCODE

            ''Dim matrix As ZXing.Common.BitMatrix = qr.encode(url, ZXing.BarcodeFormat.PDF_417, 115, 65)
            'Dim matrix As ZXing.Common.BitMatrix = qr.encode(url, ZXing.BarcodeFormat.PDF_417, 115, 65, hints)
            ''Dim matrix As ZXing.Common.BitMatrix = qr.encode(url, ZXing.BarcodeFormat.PDF_417, 115, 65, hints)
            'Dim w As ZXing.BarcodeWriter = New ZXing.BarcodeWriter
            'w.Format = ZXing.BarcodeFormat.PDF_417

            'Dim img As Bitmap = w.Write(matrix)
            ''Dim img2 As Bitmap = ResizeBitmap(img, 240, 80)
            ''Dim img2 As Bitmap = ResizeBitmap(img, 388, 118)
            'UbicacionCodBarra = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Documento & ".png"
            ''img2.Save(UbicacionCodBarra, System.Drawing.Imaging.ImageFormat.Png)
            'img.Save(UbicacionCodBarra, System.Drawing.Imaging.ImageFormat.Png)

            CrearPDF2()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub


    Private Sub CrearPDF2()

        If Session.sCodEmp = "01" Then
            If opcionimp = "Detallado" Then
                CrearPDF2Det()
            ElseIf opcionimp = "Resumido" Then
                CrearPDF2Res()
            End If
        ElseIf Session.sCodEmp = "02" Then
            If opcionimp = "Detallado" Then
                CrearPDF2DetMtuAmazonica()
            ElseIf opcionimp = "Resumido" Then
                CrearPDF2ResMtuAmazonica()
            End If
        ElseIf Session.sCodEmp = "05" Then
            If opcionimp = "Detallado" Then
                CrearPDF2DetEquimap()
            ElseIf opcionimp = "Resumido" Then
                CrearPDF2ResEquimap()
            End If
        ElseIf Session.sCodEmp = "07" Then
            If opcionimp = "Detallado" Then
                CrearPDF2DetC2Teck()
            ElseIf opcionimp = "Resumido" Then
                CrearPDF2ResC2Teck()
            End If

        ElseIf Session.sCodEmp = "08" Then
            If opcionimp = "Detallado" Then
                CrearPDF2DetC2TeckIM()
            ElseIf opcionimp = "Resumido" Then
                CrearPDF2ResC2TeckIM()
            End If

        End If


    End Sub

    Private Sub CrearPDF2Det()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirNotaElectronica

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNota).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("TipoDoc", IIf(IdDocumento = "5", "CREDITO", "DEBITO"))
                reporte.SetParameterValue("DocumentoCliente", IIf(TipoIdentidad = "1", "D.N.I. :", "R.U.C. :"))
                reporte.SetParameterValue("NroDocumentoCliente", IIf(TipoIdentidad = "1", DniCli, RucCli))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", GridEX1.CurrentRow.Cells("Documento").Text, IdDocumento)

            End If

            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2Res()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirNotaElectronicaResumido

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNota).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("TipoDoc", IIf(IdDocumento = "5", "CREDITO", "DEBITO"))
                reporte.SetParameterValue("DocumentoCliente", IIf(TipoIdentidad = "1", "D.N.I. :", "R.U.C. :"))
                reporte.SetParameterValue("NroDocumentoCliente", IIf(TipoIdentidad = "1", DniCli, RucCli))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", GridEX1.CurrentRow.Cells("Documento").Text, IdDocumento)

            End If

            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2DetMtuAmazonica()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirNotaElectronicaMtuAmaz

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNota).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("TipoDoc", IIf(IdDocumento = "5", "CREDITO", "DEBITO"))
                reporte.SetParameterValue("DocumentoCliente", IIf(TipoIdentidad = "1", "D.N.I. :", "R.U.C. :"))
                reporte.SetParameterValue("NroDocumentoCliente", IIf(TipoIdentidad = "1", DniCli, RucCli))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", GridEX1.CurrentRow.Cells("Documento").Text, IdDocumento)

            End If

            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2ResMtuAmazonica()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirNotaElectronicaMtuAmazResumido

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNota).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("TipoDoc", IIf(IdDocumento = "5", "CREDITO", "DEBITO"))
                reporte.SetParameterValue("DocumentoCliente", IIf(TipoIdentidad = "1", "D.N.I. :", "R.U.C. :"))
                reporte.SetParameterValue("NroDocumentoCliente", IIf(TipoIdentidad = "1", DniCli, RucCli))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", GridEX1.CurrentRow.Cells("Documento").Text, IdDocumento)

            End If

            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2DetEquimap()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirNotaElectronicaEquimap

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNota).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("TipoDoc", IIf(IdDocumento = "5", "CREDITO", "DEBITO"))
                reporte.SetParameterValue("DocumentoCliente", IIf(TipoIdentidad = "1", "D.N.I. :", "R.U.C. :"))
                reporte.SetParameterValue("NroDocumentoCliente", IIf(TipoIdentidad = "1", DniCli, RucCli))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", GridEX1.CurrentRow.Cells("Documento").Text, IdDocumento)

            End If

            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2ResEquimap()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirNotaElectronicaEquimapResumido

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNota).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("TipoDoc", IIf(IdDocumento = "5", "CREDITO", "DEBITO"))
                reporte.SetParameterValue("DocumentoCliente", IIf(TipoIdentidad = "1", "D.N.I. :", "R.U.C. :"))
                reporte.SetParameterValue("NroDocumentoCliente", IIf(TipoIdentidad = "1", DniCli, RucCli))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", GridEX1.CurrentRow.Cells("Documento").Text, IdDocumento)

            End If

            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    '===============================C2TECK

    Private Sub CrearPDF2DetC2Teck()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirNotaElectronicaC2Teck

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNota).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("TipoDoc", IIf(IdDocumento = "5", "CREDITO", "DEBITO"))
                reporte.SetParameterValue("DocumentoCliente", IIf(TipoIdentidad = "1", "D.N.I. :", "R.U.C. :"))
                reporte.SetParameterValue("NroDocumentoCliente", IIf(TipoIdentidad = "1", DniCli, RucCli))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", GridEX1.CurrentRow.Cells("Documento").Text, IdDocumento)

            End If

            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2ResC2Teck()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirNotaElectronicaC2TeckResumido

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNota).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("TipoDoc", IIf(IdDocumento = "5", "CREDITO", "DEBITO"))
                reporte.SetParameterValue("DocumentoCliente", IIf(TipoIdentidad = "1", "D.N.I. :", "R.U.C. :"))
                reporte.SetParameterValue("NroDocumentoCliente", IIf(TipoIdentidad = "1", DniCli, RucCli))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", GridEX1.CurrentRow.Cells("Documento").Text, IdDocumento)

            End If

            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    '=========================== C2TECK

    '===============================C2TECK INFORMATICA Y METALURGICA

    Private Sub CrearPDF2DetC2TeckIM()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirNotaElectronicaC2TeckIM

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNota).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("TipoDoc", IIf(IdDocumento = "5", "CREDITO", "DEBITO"))
                reporte.SetParameterValue("DocumentoCliente", IIf(TipoIdentidad = "1", "D.N.I. :", "R.U.C. :"))
                reporte.SetParameterValue("NroDocumentoCliente", IIf(TipoIdentidad = "1", DniCli, RucCli))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", GridEX1.CurrentRow.Cells("Documento").Text, IdDocumento)

            End If

            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2ResC2TeckIM()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirNotaElectronicaC2TeckIMResumido

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNota).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("TipoDoc", IIf(IdDocumento = "5", "CREDITO", "DEBITO"))
                reporte.SetParameterValue("DocumentoCliente", IIf(TipoIdentidad = "1", "D.N.I. :", "R.U.C. :"))
                reporte.SetParameterValue("NroDocumentoCliente", IIf(TipoIdentidad = "1", DniCli, RucCli))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", GridEX1.CurrentRow.Cells("Documento").Text, IdDocumento)

            End If

            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    '=========================== C2TECK INFORMATICA Y METALURGICA


    Public Shared Function ExportToPDF(rpt As ReportDocument, NombreArchivo As String, NumDoc As String, IdDocumento As String) As String
        Dim vFileName As String = Nothing
        Dim diskOpts As New DiskFileDestinationOptions()

        Try
            If IdDocumento = "5" Then
                diskOpts.DiskFileName = "D:\Documentos_Electronicos\Notas_Electronicas\" & NumDoc & "\" & Session.sRucEmp & "-07-" & NumDoc & ".pdf"
                'diskOpts.DiskFileName = "D:\Documentos_Electronicos\Notas_Electronicas\" & NumDoc & "\20100020441-07-" & NumDoc & ".pdf"
            ElseIf IdDocumento = "6" Then
                diskOpts.DiskFileName = "D:\Documentos_Electronicos\Notas_Electronicas\" & NumDoc & "\" & Session.sRucEmp & "-08-" & NumDoc & ".pdf"
                'diskOpts.DiskFileName = "D:\Documentos_Electronicos\Notas_Electronicas\" & NumDoc & "\20100020441-08-" & NumDoc & ".pdf"
            End If
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
            Dim d As New DirectoryInfo("D:\Documentos_Electronicos\Notas_Electronicas\" & Documento)

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
                '    dtArchivos.Rows.Add(row)
                'End If
                If f.Extension <> ".png" And f.Extension <> ".zip" Then
                    dtArchivos.Rows.Add(row)
                End If
            Next

            dgvArchivosDirectorio.DataSource = dtArchivos

        Catch ex As Exception
            MsgBox("Error al listar los elementos adjuntos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnVerNota_Click(sender As System.Object, e As System.EventArgs) Handles btnVerNota.Click

        If Session.sCodEmp = "01" Then
            If opcionimp = "Detallado" Then
                VerNotaDetallado()
            ElseIf opcionimp = "Resumido" Then
                VerNotaResumido()
            End If
        ElseIf Session.sCodEmp = "02" Then
            If opcionimp = "Detallado" Then
                VerNotaDetalladoMtuAmazonica()
            ElseIf opcionimp = "Resumido" Then
                VerNotaResumidoMtuAmazonica()
            End If
        ElseIf Session.sCodEmp = "05" Then
            If opcionimp = "Detallado" Then
                VerNotaDetalladoEquimap()
            ElseIf opcionimp = "Resumido" Then
                VerNotaResumidoEquimap()
            End If
        ElseIf Session.sCodEmp = "07" Then
            If opcionimp = "Detallado" Then
                VerNotaDetalladoC2Teck()
            ElseIf opcionimp = "Resumido" Then
                VerNotaResumidoC2Teck()
            End If
        ElseIf Session.sCodEmp = "08" Then
            If opcionimp = "Detallado" Then
                VerNotaDetalladoC2TeckIM()
            ElseIf opcionimp = "Resumido" Then
                VerNotaResumidoC2TeckIM()
            End If
        End If

    End Sub

    Private Sub VerNotaDetallado()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirNotaElectronica

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNota).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("TipoDoc", IIf(IdDocumento = "5", "CREDITO", "DEBITO"))
                reporte.SetParameterValue("DocumentoCliente", IIf(TipoIdentidad = "1", "D.N.I. :", "R.U.C. :"))
                reporte.SetParameterValue("NroDocumentoCliente", IIf(TipoIdentidad = "1", DniCli, RucCli))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                'reporte.SetParameterValue("pIdMesa", 0)
                forma.Text = "Nota Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub VerNotaResumido()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirNotaElectronicaResumido

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNota).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("TipoDoc", IIf(IdDocumento = "5", "CREDITO", "DEBITO"))
                reporte.SetParameterValue("DocumentoCliente", IIf(TipoIdentidad = "1", "D.N.I. :", "R.U.C. :"))
                reporte.SetParameterValue("NroDocumentoCliente", IIf(TipoIdentidad = "1", DniCli, RucCli))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                'reporte.SetParameterValue("pIdMesa", 0)
                forma.Text = "Nota Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub VerNotaDetalladoMtuAmazonica()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirNotaElectronicaMtuAmaz

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNota).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("TipoDoc", IIf(IdDocumento = "5", "CREDITO", "DEBITO"))
                reporte.SetParameterValue("DocumentoCliente", IIf(TipoIdentidad = "1", "D.N.I. :", "R.U.C. :"))
                reporte.SetParameterValue("NroDocumentoCliente", IIf(TipoIdentidad = "1", DniCli, RucCli))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                'reporte.SetParameterValue("pIdMesa", 0)
                forma.Text = "Nota Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub VerNotaResumidoMtuAmazonica()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirNotaElectronicaMtuAmazResumido

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNota).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("TipoDoc", IIf(IdDocumento = "5", "CREDITO", "DEBITO"))
                reporte.SetParameterValue("DocumentoCliente", IIf(TipoIdentidad = "1", "D.N.I. :", "R.U.C. :"))
                reporte.SetParameterValue("NroDocumentoCliente", IIf(TipoIdentidad = "1", DniCli, RucCli))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                'reporte.SetParameterValue("pIdMesa", 0)
                forma.Text = "Nota Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub


    Private Sub VerNotaDetalladoEquimap()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirNotaElectronicaEquimap

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNota).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("TipoDoc", IIf(IdDocumento = "5", "CREDITO", "DEBITO"))
                reporte.SetParameterValue("DocumentoCliente", IIf(TipoIdentidad = "1", "D.N.I. :", "R.U.C. :"))
                reporte.SetParameterValue("NroDocumentoCliente", IIf(TipoIdentidad = "1", DniCli, RucCli))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                'reporte.SetParameterValue("pIdMesa", 0)
                forma.Text = "Nota Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub VerNotaResumidoEquimap()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirNotaElectronicaEquimapResumido

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNota).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("TipoDoc", IIf(IdDocumento = "5", "CREDITO", "DEBITO"))
                reporte.SetParameterValue("DocumentoCliente", IIf(TipoIdentidad = "1", "D.N.I. :", "R.U.C. :"))
                reporte.SetParameterValue("NroDocumentoCliente", IIf(TipoIdentidad = "1", DniCli, RucCli))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                'reporte.SetParameterValue("pIdMesa", 0)
                forma.Text = "Nota Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub



    Private Sub VerNotaDetalladoC2Teck()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirNotaElectronicaC2Teck

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNota).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("TipoDoc", IIf(IdDocumento = "5", "CREDITO", "DEBITO"))
                reporte.SetParameterValue("DocumentoCliente", IIf(TipoIdentidad = "1", "D.N.I. :", "R.U.C. :"))
                reporte.SetParameterValue("NroDocumentoCliente", IIf(TipoIdentidad = "1", DniCli, RucCli))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                'reporte.SetParameterValue("pIdMesa", 0)
                forma.Text = "Nota Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub VerNotaResumidoC2Teck()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirNotaElectronicaC2TeckResumido

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNota).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("TipoDoc", IIf(IdDocumento = "5", "CREDITO", "DEBITO"))
                reporte.SetParameterValue("DocumentoCliente", IIf(TipoIdentidad = "1", "D.N.I. :", "R.U.C. :"))
                reporte.SetParameterValue("NroDocumentoCliente", IIf(TipoIdentidad = "1", DniCli, RucCli))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                'reporte.SetParameterValue("pIdMesa", 0)
                forma.Text = "Nota Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub


    Private Sub VerNotaDetalladoC2TeckIM()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirNotaElectronicaC2TeckIM

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNota).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("TipoDoc", IIf(IdDocumento = "5", "CREDITO", "DEBITO"))
                reporte.SetParameterValue("DocumentoCliente", IIf(TipoIdentidad = "1", "D.N.I. :", "R.U.C. :"))
                reporte.SetParameterValue("NroDocumentoCliente", IIf(TipoIdentidad = "1", DniCli, RucCli))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                'reporte.SetParameterValue("pIdMesa", 0)
                forma.Text = "Nota Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub VerNotaResumidoC2TeckIM()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirNotaElectronicaC2TeckIMResumido

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNota).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("TipoDoc", IIf(IdDocumento = "5", "CREDITO", "DEBITO"))
                reporte.SetParameterValue("DocumentoCliente", IIf(TipoIdentidad = "1", "D.N.I. :", "R.U.C. :"))
                reporte.SetParameterValue("NroDocumentoCliente", IIf(TipoIdentidad = "1", DniCli, RucCli))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                'reporte.SetParameterValue("pIdMesa", 0)
                forma.Text = "Nota Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
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
            txtAsunto.Text = Session.sDesEmp & " - NOTA DE " & IIf(IdDocumento = "5", "CREDITO", "DEBITO") & " ELECTRONICA: " & Documento '"DETROIT DIESEL MTU PERU SAC - Boleta Electrónica: " & Documento
            txtMensaje.Text = "Envio de Nota Electronica c/Adjunto xml, pdf" '& Environment.NewLine & Environment.NewLine & "No Contestar el correo porque es una cuenta desatendida"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Correo")
        End Try
    End Sub

    Private Sub CargarCorreoMtuAmazonica()
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
            txtAsunto.Text = Session.sDesEmp & " - NOTA DE " & IIf(IdDocumento = "5", "CREDITO", "DEBITO") & " ELECTRONICA: " & Documento '"DETROIT DIESEL MTU PERU SAC - Boleta Electrónica: " & Documento
            txtMensaje.Text = "Envio de Nota Electronica c/Adjunto xml, pdf" '& Environment.NewLine & Environment.NewLine & "No Contestar el correo porque es una cuenta desatendida"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Correo")
        End Try
    End Sub

    Private Sub CargarCorreoEquimap()
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
            txtAsunto.Text = Session.sDesEmp & " - NOTA DE " & IIf(IdDocumento = "5", "CREDITO", "DEBITO") & " ELECTRONICA: " & Documento
            txtMensaje.Text = "Envio de Nota Electronica c/Adjunto xml, pdf" '& Environment.NewLine & Environment.NewLine & "No Contestar el correo porque es una cuenta desatendida"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Correo")
        End Try
    End Sub

    '==================================================== C2TECK
    Private Sub CargarCorreoC2Teck()
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
            txtAsunto.Text = Session.sDesEmp & " - NOTA DE " & IIf(IdDocumento = "5", "CREDITO", "DEBITO") & " ELECTRONICA: " & Documento
            txtMensaje.Text = "Envio de Nota Electronica c/Adjunto xml, pdf" '& Environment.NewLine & Environment.NewLine & "No Contestar el correo porque es una cuenta desatendida"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Correo")
        End Try
    End Sub

    '====================================================

    '==================================================== C2TECK INFORMATICA Y METALURGICA
    Private Sub CargarCorreoC2TeckIM()
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
            txtAsunto.Text = Session.sDesEmp & " - NOTA DE " & IIf(IdDocumento = "5", "CREDITO", "DEBITO") & " ELECTRONICA: " & Documento
            txtMensaje.Text = "Envio de Nota Electronica c/Adjunto xml, pdf" '& Environment.NewLine & Environment.NewLine & "No Contestar el correo porque es una cuenta desatendida"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Correo")
        End Try
    End Sub

    '====================================================

    Private Sub btnEnviarCorreo_Click(sender As System.Object, e As System.EventArgs) Handles btnEnviarCorreo.Click

        Try
            If ValidaCamposCorreo() Then

                Dim Cuerpo As String
                Cuerpo = "<html><body><font size='2'>" + "Fecha de Ingreso " + Today().ToString("dd/MM/yyyy") + " : " + TimeOfDay.ToString("HH:mm:ss")
                Cuerpo = Cuerpo + "<br/><br/>Señor(es) : " +
                              "<br/><br/><b>" + Trim(DesCli) + ":</b>" +
                                     "<br/><br/>Le informamos que ha recibido un documento de " + DesEmp +
                                     "<br/><br/>Número de documento : " + Documento
                Cuerpo = Cuerpo + "<br/>Tipo de Documento : " + IIf(IdDocumento = "5", "Nota de Credito", "Nota de Debito")
                Cuerpo = Cuerpo + "<br/>Fecha de emisión : " + FecDoc.ToString("dd/MM/yyyy")
                Cuerpo = Cuerpo + "<br/>Valor : " + LegalMonetaryTotal.ToString()
                Cuerpo = Cuerpo + "<br/><br/><b>OBSERVACIONES: <br/></b>" + txtMensaje.Text.Trim
                Cuerpo = Cuerpo + "<br/><br/><b><br/></b>Si requiere consultar el documento en nuestro sitio Web por favor ingrese a http://intranet.c2teck-online.com/ConsultaFactura/VerComprobantes.aspx</b>"
                Cuerpo = Cuerpo + "<br/>Tambien puede consultar otros documentos ingresando su clave de acceso de cliente en la siguiente dirección http://intranet.c2teck-online.com/ConsultaFactura/"
                Cuerpo = Cuerpo + "<br/><br/><br/>Atentamente,<br/>"
                Cuerpo = Cuerpo + "<br/>Factura Electrónica<br/>"
                Cuerpo = Cuerpo + "<br/>C2TECK INFORMATICA<br/>"
                Cuerpo = Cuerpo + "<br/><br/><br/><i><b>Nota: Este e-mail es generado de manera automática, por favor no responda a este mensaje.<b><i/></font></body></html>"

                Dim SendFrom As MailAddress = New MailAddress(txtDe.Text.Trim)
                Dim SendTo As MailAddress = New MailAddress(txtPara.Text.Trim)
                Dim MyMessage As MailMessage = New MailMessage(SendFrom, SendTo)
                If toBlank(txtcc.Text) <> "" Then
                    MyMessage.CC.Add(txtcc.Text)
                End If
                MyMessage.Subject = txtAsunto.Text.Trim
                MyMessage.IsBodyHtml = True
                MyMessage.Body = Cuerpo  'txtMensaje.Text.Trim

                If IdDocumento = "5" Then

                    Dim destdir As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-07-" & Documento & ".zip"
                    Dim xmldir As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-07-" & Documento & ".xml"
                    Dim pdfdir As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-07-" & Documento & ".pdf"

                    'Dim destdir As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-07-" & Documento & ".zip"
                    'Dim xmldir As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-07-" & Documento & ".xml"
                    'Dim pdfdir As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-07-" & Documento & ".pdf"

                    Dim attachFile As Attachment = New Attachment(xmldir)
                    MyMessage.Attachments.Add(attachFile)
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

                    'Dim emailClient As SmtpClient = New SmtpClient("mail.equimap.com.pe")
                    'emailClient.Send(MyMessage)
                    'MyMessage.Dispose()
                    'MsgBox("Se envio el correo correctamente", MsgBoxStyle.Information)

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK

                ElseIf IdDocumento = "6" Then
                    Dim destdir As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-08-" & Documento & ".zip"
                    Dim xmldir As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-08-" & Documento & ".xml"
                    Dim pdfdir As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-08-" & Documento & ".pdf"

                    'Dim destdir As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-08-" & Documento & ".zip"
                    'Dim xmldir As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-08-" & Documento & ".xml"
                    'Dim pdfdir As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\20100020441-08-" & Documento & ".pdf"

                    Dim attachFile As Attachment = New Attachment(xmldir)
                    MyMessage.Attachments.Add(attachFile)
                    Dim attachFile1 As Attachment = New Attachment(pdfdir)
                    MyMessage.Attachments.Add(attachFile1)

                    Dim smtp As New System.Net.Mail.SmtpClient
                    smtp.Host = Session.sMailHost '"mail.ddperu.com.pe"
                    If Session.sCodEmp = "02" Or Session.sCodEmp = "05" Then    'equimap y equimap amazonica
                        smtp.EnableSsl = True
                    End If
                    smtp.Port = 587
                    smtp.Credentials = New System.Net.NetworkCredential(Session.sCorreoEmisor, Session.sClaveCorreoEmisor)
                    smtp.Send(MyMessage)
                    smtp.Dispose()
                    MsgBox("Se envio el correo correctamente", MsgBoxStyle.Information)

                    'Dim emailClient As SmtpClient = New SmtpClient("mail.equimap.com.pe")
                    'emailClient.Send(MyMessage)
                    'MyMessage.Dispose()
                    'MsgBox("Se envio el correo correctamente", MsgBoxStyle.Information)

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK

                End If

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

    Private Sub biSalir_Click(sender As System.Object, e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub CrearXmlCreditoDetalle21()

        Try

            Dim xmlFilename As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-07-" & Documento & ".xml"
            Dim registro As New DocumentoSunat()

            'TipoAfectacion = (1: GRABADO, 2: EXONERADO, 3: INAFECTO, 4: GRATUITO, 5: EXPORTACION)

            Dim tipoAfectacion As Integer
            tipoAfectacion = IIf(CodAfectacion = "20", 2, IIf(InstructionID = "05", 4, IIf(CodAfectacion = "40", 5, IIf(CodAfectacion = "30", 3, 1))))

            'CodAfectacion = IIf(Session.sIGV = 0, "20", IIf(InstructionID = "05", "31", IIf(InstructionID = "04", "40", IIf(InstructionID = "03", "30", CodAfectacion))))

            registro.RucEmisor = Session.sRucEmp
            registro.DesEmpEmisor = Session.sDesEmp
            registro.CodUbigeoEmisor = Session.sCodUbigeo
            registro.DireccionEmisor = Session.sDireccion
            registro.DepartamentoEmisor = Session.sDepartamento
            registro.ProvinciaEmisor = Session.sProvincia
            registro.DistritoEmisor = Session.sDistrito
            registro.CurrencyCode = CurrencyId
            registro.Documento = Documento
            registro.FecDoc = FecDoc
            registro.FecVencimiento = FecDoc
            registro.TipoDoc = TipoDoc
            registro.LetrasTotalDoc = TotNetoLetras
            registro.CodDocCliente = TipoIdentidad
            registro.RucCliente = RucCli
            registro.DesCliente = DesCli
            registro.PorcentajeIGV = Igv  'Session.sIGV
            registro.TipoAfectacion = tipoAfectacion 'IIf(CodAfectacion = "20", 2, IIf(InstructionID = "05", 4, IIf(InstructionID = "04", 5, IIf(InstructionID = "03", 3, 1))))
            registro.CodAfectacionIGV = CodAfectacion
            registro.TotalBruto = TotVenta
            registro.TotalDscto = 0.00 'TotDscto
            registro.TotalIgv = IIf(InstructionID <> "05" Or Igv > 0, TaxAmount, 0.00) 'IIf(InstructionID <> "05" Or Session.sIGV > 0, TaxAmount, 0.00)
            registro.TotalPrecio = LegalMonetaryTotal  'TotVenta 'INCLUYE EL BRUTO MAS IGV
            registro.TotalNeto = LegalMonetaryTotal
            registro.TipoDocRef = TipoDocModifica
            registro.DocumentoRef = NumDocModifica
            registro.TipoNota = CodTipoCre
            registro.MotivoNota = MotivoRef
            registro.CodEstablecimiento = CodEstablecimiento

            Dim cantline As Integer = GridEX1.RowCount - 1
            Dim fila As DocumentoDetalleSunat() = New DocumentoDetalleSunat(cantline) {}
            Dim row As Janus.Windows.GridEX.GridEXRow
            If GridEX1.RowCount > 0 Then
                For j = 0 To GridEX1.RowCount - 1
                    Me.GridEX1.Row = j
                    row = Me.GridEX1.GetRow()
                    fila(j) = New DocumentoDetalleSunat() With {
                        .Id = CStr(row.Cells("Item").Value),
                        .Codigo = CStr(row.Cells("CodMer").Value),
                        .Descripcion = CStr(row.Cells("DesMer1").Value),
                        .Cantidad = CDec(row.Cells("CanMer").Value),
                        .TipoPrecio = IIf(InstructionID = "05", "02", CStr(row.Cells("CodigoPrecio").Value)),
                        .UnidadMedida = CStr(row.Cells("unitCode").Value),
                        .PrecioUnitario = IIf(InstructionID = "05", 0.00, CDec(FormatNumber(row.Cells("Price").Value, 2))),
                        .PrecioReferencia = CDec(FormatNumber(row.Cells("Pricingreference").Value, 2)),
                        .MontoIgv = IIf(InstructionID = "05", 0.00, CDec(FormatNumber(row.Cells("MontoIgv").Value, 2))),
                        .PrecioFinal = CDec(FormatNumber(row.Cells("LineExtensionAmount").Value, 2)),
                        .PrecioNeto = CDec(FormatNumber(row.Cells("LineExtensionAmount").Value, 2))
                        }
                Next

            End If

            registro.DocumentoFilas = fila

            FacturacionElectronica21.GenerarCreditNote(xmlFilename, registro)

            FirmadoDigital()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear xml")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try

    End Sub

    Private Sub CrearXmlCreditoResumen21()

        Try

            Dim xmlFilename As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-07-" & Documento & ".xml"
            Dim registro As New DocumentoSunat()

            'TipoAfectacion = (1: GRABADO, 2: EXONERADO, 3: INAFECTO, 4: GRATUITO, 5: EXPORTACION)
            Dim tipoAfectacion As Integer
            tipoAfectacion = IIf(CodAfectacion = "20", 2, IIf(InstructionID = "05", 4, IIf(CodAfectacion = "40", 5, IIf(CodAfectacion = "30", 3, 1))))

            '            CodAfectacion = IIf(Session.sIGV = 0, "20", IIf(InstructionID = "05", "31", IIf(InstructionID = "04", "40", IIf(InstructionID = "03", "30", CodAfectacion))))

            registro.RucEmisor = Session.sRucEmp
            registro.DesEmpEmisor = Session.sDesEmp
            registro.CodUbigeoEmisor = Session.sCodUbigeo
            registro.DireccionEmisor = Session.sDireccion
            registro.DepartamentoEmisor = Session.sDepartamento
            registro.ProvinciaEmisor = Session.sProvincia
            registro.DistritoEmisor = Session.sDistrito
            registro.CurrencyCode = CurrencyId
            registro.Documento = Documento
            registro.FecDoc = FecDoc
            registro.FecVencimiento = FecDoc
            registro.TipoDoc = TipoDoc
            registro.LetrasTotalDoc = TotNetoLetras
            registro.CodDocCliente = TipoIdentidad
            registro.RucCliente = RucCli
            registro.DesCliente = DesCli
            registro.PorcentajeIGV = Igv  'Session.sIGV
            registro.TipoAfectacion = tipoAfectacion 'IIf(CodAfectacion = "20", 2, IIf(InstructionID = "05", 4, IIf(InstructionID = "04", 5, IIf(InstructionID = "03", 3, 1))))
            registro.CodAfectacionIGV = CodAfectacion
            registro.TotalBruto = TotVenta
            registro.TotalDscto = 0.00 'TotDscto
            registro.TotalIgv = IIf(InstructionID <> "05" Or Igv > 0, TaxAmount, 0.00)
            registro.TotalPrecio = LegalMonetaryTotal  'TotVenta 'INCLUYE EL BRUTO MAS IGV
            registro.TotalNeto = LegalMonetaryTotal
            registro.TipoDocRef = TipoDocModifica
            registro.DocumentoRef = NumDocModifica
            registro.TipoNota = CodTipoCre
            registro.MotivoNota = MotivoRef
            registro.CodEstablecimiento = CodEstablecimiento

            Dim cantline As Integer = 0 'GridEX1.RowCount - 1
            Dim fila As DocumentoDetalleSunat() = New DocumentoDetalleSunat(cantline) {}
            Dim row As Janus.Windows.GridEX.GridEXRow
            If GridEX1.RowCount > 0 Then
                For j = 0 To 0 'GridEX1.RowCount - 1
                    Me.GridEX1.Row = j
                    row = Me.GridEX1.GetRow()
                    fila(j) = New DocumentoDetalleSunat() With {
                        .Id = CStr(row.Cells("Item").Value),
                        .Codigo = CStr("-"),
                        .Descripcion = CStr(row.Cells("Observacion").Value),
                        .Cantidad = CDec(row.Cells("CanMer").Value),
                        .TipoPrecio = IIf(InstructionID = "05", "02", CStr(row.Cells("CodigoPrecio").Value)),
                        .UnidadMedida = CStr(row.Cells("unitCode").Value),
                        .PrecioUnitario = IIf(InstructionID = "05", 0.00, CDec(FormatNumber(row.Cells("TotVenta").Value, 2))),
                        .PrecioReferencia = CDec(FormatNumber(row.Cells("LegalMonetaryTotal").Value, 2)),
                        .MontoIgv = IIf(InstructionID = "05", 0.00, CDec(FormatNumber(row.Cells("TaxAmount").Value, 2))),
                        .PrecioFinal = CDec(FormatNumber(row.Cells("TotVenta").Value, 2)),
                        .PrecioNeto = CDec(FormatNumber(row.Cells("TotVenta").Value, 2))
                        }
                Next

            End If

            registro.DocumentoFilas = fila

            FacturacionElectronica21.GenerarCreditNote(xmlFilename, registro)

            FirmadoDigital()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear xml")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try
    End Sub

    Private Sub CrearXmlDebitoDetalle21()

        Try

            Dim xmlFilename As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-08-" & Documento & ".xml"
            Dim registro As New DocumentoSunat()

            'TipoAfectacion = (1: GRABADO, 2: EXONERADO, 3: INAFECTO, 4: GRATUITO, 5: EXPORTACION)
            Dim tipoAfectacion As Integer
            tipoAfectacion = IIf(CodAfectacion = "20", 2, IIf(InstructionID = "05", 4, IIf(CodAfectacion = "40", 5, IIf(CodAfectacion = "30", 3, 1))))

            'CodAfectacion = IIf(Session.sIGV = 0, "20", IIf(InstructionID = "05", "31", IIf(InstructionID = "04", "40", IIf(InstructionID = "03", "30", CodAfectacion))))

            registro.RucEmisor = Session.sRucEmp
            registro.DesEmpEmisor = Session.sDesEmp
            registro.CodUbigeoEmisor = Session.sCodUbigeo
            registro.DireccionEmisor = Session.sDireccion
            registro.DepartamentoEmisor = Session.sDepartamento
            registro.ProvinciaEmisor = Session.sProvincia
            registro.DistritoEmisor = Session.sDistrito
            registro.CurrencyCode = CurrencyId
            registro.Documento = Documento
            registro.FecDoc = FecDoc
            registro.FecVencimiento = FecDoc
            registro.TipoDoc = TipoDoc
            registro.LetrasTotalDoc = TotNetoLetras
            registro.CodDocCliente = TipoIdentidad
            registro.RucCliente = RucCli
            registro.DesCliente = DesCli
            registro.PorcentajeIGV = Igv  'Session.sIGV
            registro.TipoAfectacion = tipoAfectacion 'IIf(CodAfectacion = "20", 2, IIf(InstructionID = "05", 4, IIf(InstructionID = "04", 5, IIf(InstructionID = "03", 3, 1))))
            registro.CodAfectacionIGV = CodAfectacion
            registro.TotalBruto = TotVenta
            registro.TotalDscto = 0.00 'TotDscto
            registro.TotalIgv = IIf(InstructionID <> "05" Or Igv > 0, TaxAmount, 0.00)
            registro.TotalPrecio = LegalMonetaryTotal  'TotVenta 'INCLUYE EL BRUTO MAS IGV
            registro.TotalNeto = LegalMonetaryTotal
            registro.TipoDocRef = TipoDocModifica
            registro.DocumentoRef = NumDocModifica
            registro.TipoNota = CodTipoDeb
            registro.MotivoNota = MotivoRef
            registro.CodEstablecimiento = CodEstablecimiento

            Dim cantline As Integer = GridEX1.RowCount - 1
            Dim fila As DocumentoDetalleSunat() = New DocumentoDetalleSunat(cantline) {}
            Dim row As Janus.Windows.GridEX.GridEXRow
            If GridEX1.RowCount > 0 Then
                For j = 0 To GridEX1.RowCount - 1
                    Me.GridEX1.Row = j
                    row = Me.GridEX1.GetRow()
                    fila(j) = New DocumentoDetalleSunat() With {
                        .Id = CStr(row.Cells("Item").Value),
                        .Codigo = CStr(row.Cells("CodMer").Value),
                        .Descripcion = CStr(row.Cells("DesMer1").Value),
                        .Cantidad = CDec(row.Cells("CanMer").Value),
                        .TipoPrecio = IIf(InstructionID = "05", "02", CStr(row.Cells("CodigoPrecio").Value)),
                        .UnidadMedida = CStr(row.Cells("unitCode").Value),
                        .PrecioUnitario = IIf(InstructionID = "05", 0.00, CDec(FormatNumber(row.Cells("Price").Value, 2))),
                        .PrecioReferencia = CDec(FormatNumber(row.Cells("Pricingreference").Value, 2)),
                        .MontoIgv = IIf(InstructionID = "05", 0.00, CDec(FormatNumber(row.Cells("MontoIgv").Value, 2))),
                        .PrecioFinal = CDec(FormatNumber(row.Cells("LineExtensionAmount").Value, 2)),
                        .PrecioNeto = CDec(FormatNumber(row.Cells("LineExtensionAmount").Value, 2))
                        }
                Next

            End If

            registro.DocumentoFilas = fila

            FacturacionElectronica21.GenerarDebitNote(xmlFilename, registro)

            FirmadoDigital()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear xml")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try

    End Sub

    Private Sub CrearXmlDebitoResumen21()

        Try

            Dim xmlFilename As String = "D:\Documentos_Electronicos\Notas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-08-" & Documento & ".xml"
            Dim registro As New DocumentoSunat()

            'TipoAfectacion = (1: GRABADO, 2: EXONERADO, 3: INAFECTO, 4: GRATUITO, 5: EXPORTACION)
            Dim tipoAfectacion As Integer
            tipoAfectacion = IIf(CodAfectacion = "20", 2, IIf(InstructionID = "05", 4, IIf(CodAfectacion = "40", 5, IIf(CodAfectacion = "30", 3, 1))))

            'CodAfectacion = IIf(Session.sIGV = 0, "20", IIf(InstructionID = "05", "31", IIf(InstructionID = "04", "40", IIf(InstructionID = "03", "30", CodAfectacion))))

            registro.RucEmisor = Session.sRucEmp
            registro.DesEmpEmisor = Session.sDesEmp
            registro.CodUbigeoEmisor = Session.sCodUbigeo
            registro.DireccionEmisor = Session.sDireccion
            registro.DepartamentoEmisor = Session.sDepartamento
            registro.ProvinciaEmisor = Session.sProvincia
            registro.DistritoEmisor = Session.sDistrito
            registro.CurrencyCode = CurrencyId
            registro.Documento = Documento
            registro.FecDoc = FecDoc
            registro.FecVencimiento = FecDoc
            registro.TipoDoc = TipoDoc
            registro.LetrasTotalDoc = TotNetoLetras
            registro.CodDocCliente = TipoIdentidad
            registro.RucCliente = RucCli
            registro.DesCliente = DesCli
            registro.PorcentajeIGV = Igv 'Session.sIGV
            registro.TipoAfectacion = tipoAfectacion 'IIf(CodAfectacion = "20", 2, IIf(InstructionID = "05", 4, IIf(InstructionID = "04", 5, IIf(InstructionID = "03", 3, 1))))
            registro.CodAfectacionIGV = CodAfectacion
            registro.TotalBruto = TotVenta
            registro.TotalDscto = 0.00 'TotDscto
            registro.TotalIgv = IIf(InstructionID <> "05" Or Igv > 0, TaxAmount, 0.00)
            registro.TotalPrecio = LegalMonetaryTotal  'TotVenta 'INCLUYE EL BRUTO MAS IGV
            registro.TotalNeto = LegalMonetaryTotal
            registro.TipoDocRef = TipoDocModifica
            registro.DocumentoRef = NumDocModifica
            registro.TipoNota = CodTipoDeb
            registro.MotivoNota = MotivoRef
            registro.CodEstablecimiento = CodEstablecimiento

            Dim cantline As Integer = 0 'GridEX1.RowCount - 1
            Dim fila As DocumentoDetalleSunat() = New DocumentoDetalleSunat(cantline) {}
            Dim row As Janus.Windows.GridEX.GridEXRow
            If GridEX1.RowCount > 0 Then
                For j = 0 To 0 'GridEX1.RowCount - 1
                    Me.GridEX1.Row = j
                    row = Me.GridEX1.GetRow()
                    fila(j) = New DocumentoDetalleSunat() With {
                        .Id = CStr(row.Cells("Item").Value),
                        .Codigo = CStr("-"),
                        .Descripcion = CStr(row.Cells("Observacion").Value),
                        .Cantidad = CDec(row.Cells("CanMer").Value),
                        .TipoPrecio = IIf(InstructionID = "05", "02", CStr(row.Cells("CodigoPrecio").Value)),
                        .UnidadMedida = CStr(row.Cells("unitCode").Value),
                        .PrecioUnitario = IIf(InstructionID = "05", 0.00, CDec(FormatNumber(row.Cells("TotVenta").Value, 2))),
                        .PrecioReferencia = CDec(FormatNumber(row.Cells("LegalMonetaryTotal").Value, 2)),
                        .MontoIgv = IIf(InstructionID = "05", 0.00, CDec(FormatNumber(row.Cells("TaxAmount").Value, 2))),
                    .PrecioFinal = CDec(FormatNumber(row.Cells("TotVenta").Value, 2)),
                        .PrecioNeto = CDec(FormatNumber(row.Cells("TotVenta").Value, 2))
                        }
                Next

            End If

            registro.DocumentoFilas = fila

            FacturacionElectronica21.GenerarDebitNote(xmlFilename, registro)

            FirmadoDigital()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear xml")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try
    End Sub

    Private Sub txtMensaje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMensaje.KeyPress
        If e.KeyChar = ChrW(Keys.Tab) Then
            If btnEnviarCorreo.Enabled = True Then
                btnEnviarCorreo.Select()
                btnEnviarCorreo_Click(sender, e)
            End If
        End If
    End Sub

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