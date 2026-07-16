Imports System
Imports System.IO
Imports System.ServiceModel
Imports System.Xml
Imports System.Text
Imports System.Net.Mail
Imports Ionic.Zip
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports LibreriaFacturacion
Imports ZXing
Imports ZXing.PDF417
Imports ZXing.PDF417.Internal
Imports System.Xml.Serialization
Imports UblLarsen.Ubl2.Cac
Imports UblLarsen.Ubl2.Udt
Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography.X509Certificates
Imports System.Collections.Generic
Imports System.Linq
Imports System.Xml.Linq
Imports UblLarsen.Ubl2
Imports UblLarsen.Ubl2.aplicacion
Imports FacturarSunat.aplicacion
Imports FacturarSunat21.aplicacion

Public Class frmBoleta_BoletaElectronica

    Public IdBoleta As Integer

    Private oMaestroService As New MaestroService.MaestroClient
    Private oBoletaService As New BoletaService.BoletaServiceClient
    Private oBoletaDigitalService As New BoletaDigitalService.BoletaDigitalServiceClient
    Private oTesoreriaService As New TesoreriaService.TesoreriaServiceClient
    Private oComunicacionSunat As New ComunicacionSunat
    Private oUsuarioClienteService As New UsuarioClienteService.UsuarioClienteServiceClient
    Private oDocCtaCte As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient

    Public EstadoSunat As Boolean
    Public TotalSoles As String
    Public opcionimp As String

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
    Dim TotGasto As Double
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
    Dim InstructionID As String
    Dim UbicacionCodBarra As String
    Dim ValorResumen As String
    Dim ValorFirma As String
    Dim TotNetoLetras As String
    Dim Responsecode As String
    Dim DireccionFiscal As String
    Dim CodUbigeoRec As String
    Dim NomDistRec As String
    Dim NomProvRec As String
    Dim NomDptoRec As String
    Dim NumOrden As String
    Dim CodEstablecimiento As String
    Dim FormaPago As String
    Dim CodPag As String
    Dim TotalAnticipos As Double
    Dim TipoFactura As String
    Dim Igv As Double
    Dim TotalCuota As Double

    Private Sub frmBoleta_BoletaElectronica_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oBoletaService.Close()
            oBoletaDigitalService.Close()
            oTesoreriaService.Close()
            oUsuarioClienteService.Close()
            oDocCtaCte.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oBoletaService.Abort()
            oBoletaDigitalService.Abort()
            oTesoreriaService.Abort()
            oUsuarioClienteService.Abort()
            oDocCtaCte.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oBoletaService.Abort()
            oBoletaDigitalService.Abort()
            oTesoreriaService.Abort()
            oUsuarioClienteService.Abort()
            oDocCtaCte.Abort()
        End Try
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub frmBoleta_BoletaElectronica_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub frmBoleta_BoletaElectronica_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Dim dtReporte As New DataTable

            dtReporte = oBoletaService.ImprimirDigital(IdBoleta).Tables(0)
            GridEX1.DataSource = dtReporte
            DataGridView1.DataSource = dtReporte

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
            CodMon = GridEX1.CurrentRow.Cells("CodMon").Text
            InstructionID = GridEX1.CurrentRow.Cells("InstructionID").Text

            DireccionFiscal = GridEX1.CurrentRow.Cells("DireccionFiscal").Text
            CodUbigeoRec = GridEX1.CurrentRow.Cells("CodUbigeoRec").Text
            NomDistRec = GridEX1.CurrentRow.Cells("NomDistRec").Text
            NomProvRec = GridEX1.CurrentRow.Cells("NomProvRec").Text
            NomDptoRec = GridEX1.CurrentRow.Cells("NomDptoRec").Text
            CodEstablecimiento = GridEX1.CurrentRow.Cells("CodEstablecimiento").Text
            FormaPago = GridEX1.CurrentRow.Cells("FormaPago").Text
            CodPag = GridEX1.CurrentRow.Cells("CodPag").Text
            TipoFactura = GridEX1.CurrentRow.Cells("TipoFactura").Text
            TotalAnticipos = GridEX1.CurrentRow.Cells("TotalAnticipos").Text
            Igv = GridEX1.CurrentRow.Cells("Igv").Text
            TotalCuota = LegalMonetaryTotal 'GridEX1.CurrentRow.Cells("TotalCuota").Text

            TotNetoLetras = oTesoreriaService.ConvierteNumLetraConta(GridEX1.CurrentRow.Cells("LegalMonetaryTotal").Text)

            CrearCarpeta()

            If opcionimp = "Detallado" Then
                'CrearXMLSerializadoDet()
                CrearXmlDetalle21()
            ElseIf opcionimp = "Resumido" Then
                'CrearXMLSerializadoRes()
                CrearXmlResumen21()
            End If
            'CrearXMLSerializado() 'CrearXmlDsctoGlobal() 'CrearxmlInafecta() '

            If Session.sCodEmp = "01" Then
                CargarCorreo()
            ElseIf Session.sCodEmp = "02" Then
                CargarCorreoMtUAmazonica()
            ElseIf Session.sCodEmp = "03" Then
                CargarCorreoEquimap()
            ElseIf Session.sCodEmp = "07" Then
                CargarCorreoC2Teck()
            ElseIf Session.sCodEmp = "08" Then
                CargarCorreoC2TeckIM()
            Else
                CargarCorreo()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CrearCarpeta()
        Try
            If Not Directory.Exists("D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento) Then
                Directory.CreateDirectory("D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear la carpeta")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try
    End Sub

    'Private Sub CrearXmlDsctoGlobal()

    '    Dim xmlFilename As String = "D:\Documentos_Electronicos\Boletas_Electronicas\" & GridEX1.CurrentRow.Cells("NumDoc").Text & "\20100020441-03-" & GridEX1.CurrentRow.Cells("NumDoc").Text & ".xml"

    '    UblLarsen.Ubl2.UblBaseDocumentType.GlbCustomizationID = "1.0"

    '    AmountType.TlsDefaultCurrencyID = CurrencyId

    '    '================================================================================================================================= Inicio Codigo TaxTotal

    '    Dim taxtotal As TaxTotalType()

    '        taxtotal = New TaxTotalType(1) {}
    '        taxtotal(0) = New TaxTotalType() With { _
    '           .TaxAmount = FormatNumber(TaxAmount, 2), _
    '           .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '               .TaxAmount = FormatNumber(TaxAmount, 2), _
    '               .TaxCategory = New TaxCategoryType() With { _
    '                   .TaxExemptionReasonCode = CodAfectacion, _
    '                   .TaxScheme = New TaxSchemeType() With { _
    '                       .ID = CodTributo, _
    '                       .Name = NomTributo, _
    '                       .TaxTypeCode = CodTributoInt _
    '                   } _
    '               } _
    '           }} _
    '        }

    '        '================================================================================================================================= Inicio Codigo TaxTotal

    '        '================================================================================================================================= Inicio Codigo LegalMonetaryTotal

    '        Dim legal As MonetaryTotalType()


    '    legal = New MonetaryTotalType(1) {}
    '    legal(0) = New MonetaryTotalType() With { _
    '        .PayableAmount = FormatNumber(LegalMonetaryTotal, 2), _
    '        .AllowanceTotalAmount = FormatNumber("30", 2) _
    '    }

    '    '================================================================================================================================= Fin Codigo LegalMonetaryTotal

    '    '================================================================================================================================= Inicio Codigo CustomerParty

    '    Dim accountcust As CustomerPartyType() = New CustomerPartyType(1) {}
    '    accountcust(0) = New CustomerPartyType() With { _
    '       .CustomerAssignedAccountID = DniCli, _
    '       .AdditionalAccountID = New IdentifierType() {CStr(TipoIdentidad)}, _
    '       .Party = New PartyType() With { _
    '           .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With { _
    '               .RegistrationName = DesCli _
    '           }} _
    '       } _
    '    }

    '    '================================================================================================================================= Fin Codigo CustomerParty

    '    '================================================================================================================================= Inicio Codigo AdditionalInformation

    '    Dim additionalmon As UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType()
    '    Dim additionalpro As UblLarsen.Ubl2.Sac.AdditionalPropertyType()


    '        additionalmon = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType(1) {}
    '        additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
    '                        .ID = "1001", _
    '                        .PayableAmount = FormatNumber(TotVenta, 2) _
    '        }
    '    additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
    '            .ID = "2005", _
    '            .PayableAmount = FormatNumber("30", 2) _
    '        }
    '        ''======================================================================================= Inicio Operaciones inafectas
    '        'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
    '        '                .ID = "1002", _
    '        '                .PayableAmount = FormatNumber(TotNeto, 2) _
    '        '}
    '        ''======================================================================================= Fin Operaciones inafectas

    '        ''======================================================================================= Inicio Operaciones exoneradas
    '        'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
    '        '                .ID = "1003", _
    '        '                .PayableAmount = FormatNumber(TotNeto, 2) _
    '        '}
    '        ''======================================================================================= Fin Operaciones exoneradas

    '        ''======================================================================================= Inicio Percepcion
    '        'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
    '        '                .ID = "2001", _
    '        '                .PayableAmount = FormatNumber(TotNeto, 2) _
    '        '}
    '        ''======================================================================================= Fin Percepcion

    '        ''======================================================================================= Inicio Total Descuento
    '        'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
    '        '                .ID = "2005", _
    '        '                .PayableAmount = FormatNumber(TotDscto, 2) _
    '        '}
    '        ''======================================================================================= Fin Total descuentos

    '        additionalpro = New UblLarsen.Ubl2.Sac.AdditionalPropertyType(1) {}
    '        additionalpro(0) = New UblLarsen.Ubl2.Sac.AdditionalPropertyType() With { _
    '                        .ID = "1000", _
    '                        .Value = TotNetoLetras _
    '        }


    '        '================================================================================================================================= Fin Codigo AdditionalInformation

    '        '================================================================================================================================= Inicio Codigo InvoiceLine

    '        Dim line1 As InvoiceLineType() = Nothing

    '        Dim row As Janus.Windows.GridEX.GridEXRow

    '        If GridEX1.RowCount > 0 Then
    '            Dim cantline As Integer = GridEX1.RowCount
    '            line1 = New InvoiceLineType(cantline) {}

    '            For j = 0 To GridEX1.RowCount - 1
    '                Me.GridEX1.Row = j
    '                row = Me.GridEX1.GetRow()

    '            line1(j) = New InvoiceLineType() With { _
    '                   .ID = CStr(row.Cells("Item").Value), _
    '                   .InvoicedQuantity = New QuantityType() With { _
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

    '        End If

    '        '==============================================================================================================================Fin Codigo InvoiceLine

    '        '==============================================================================================================================Inicio Codigo GenerarXML

    '        FacturacionElectronica.GenerarInvoice(xmlFilename, additionalmon, additionalpro, CurrencyId, NumDoc, FecDoc, TipoDoc, accountcust(0), taxtotal, legal(0), line1)

    '        '==============================================================================================================================Fin Codigo GenerarXML

    '        FirmadoDigital()

    'End Sub

    'Private Sub CrearxmlInafecta()

    '    Dim xmlFilename As String = "D:\Documentos_Electronicos\Boletas_Electronicas\" & GridEX1.CurrentRow.Cells("NumDoc").Text & "\20100020441-03-" & GridEX1.CurrentRow.Cells("NumDoc").Text & ".xml"

    '    UblLarsen.Ubl2.UblBaseDocumentType.GlbCustomizationID = "1.0"

    '    AmountType.TlsDefaultCurrencyID = CurrencyId

    '    TotNetoLetras = oTesoreriaService.ConvierteNumLetraConta(TotVenta)

    '    '================================================================================================================================= Inicio Codigo TaxTotal

    '    Dim taxtotal As TaxTotalType()


    '    taxtotal = New TaxTotalType(1) {}
    '    taxtotal(0) = New TaxTotalType() With { _
    '       .TaxAmount = FormatNumber("0.0", 2), _
    '       .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '           .TaxAmount = FormatNumber("0.0", 2), _
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

    '    '================================================================================================================================= Inicio Codigo LegalMonetaryTotal

    '    Dim legal As MonetaryTotalType()


    '    legal = New MonetaryTotalType(1) {}
    '    legal(0) = New MonetaryTotalType() With { _
    '        .PayableAmount = FormatNumber(TotVenta, 2) _
    '    }

    '    '================================================================================================================================= Fin Codigo LegalMonetaryTotal

    '    '================================================================================================================================= Inicio Codigo CustomerParty

    '    Dim accountcust As CustomerPartyType() = New CustomerPartyType(1) {}
    '    accountcust(0) = New CustomerPartyType() With { _
    '       .CustomerAssignedAccountID = DniCli, _
    '       .AdditionalAccountID = New IdentifierType() {CStr(TipoIdentidad)}, _
    '       .Party = New PartyType() With { _
    '           .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With { _
    '               .RegistrationName = DesCli _
    '           }} _
    '       } _
    '    }

    '    '================================================================================================================================= Fin Codigo CustomerParty

    '    '================================================================================================================================= Inicio Codigo AdditionalInformation

    '    Dim additionalmon As UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType()
    '    Dim additionalpro As UblLarsen.Ubl2.Sac.AdditionalPropertyType()

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
    '    ''======================================================================================= Inicio Operaciones inafectas
    '    'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
    '    '                .ID = "1002", _
    '    '                .PayableAmount = FormatNumber(TotNeto, 2) _
    '    '}
    '    ''======================================================================================= Fin Operaciones inafectas

    '    ''======================================================================================= Inicio Operaciones exoneradas
    '    'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
    '    '                .ID = "1003", _
    '    '                .PayableAmount = FormatNumber(TotNeto, 2) _
    '    '}
    '    ''======================================================================================= Fin Operaciones exoneradas

    '    ''======================================================================================= Inicio Percepcion
    '    'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
    '    '                .ID = "2001", _
    '    '                .PayableAmount = FormatNumber(TotNeto, 2) _
    '    '}
    '    ''======================================================================================= Fin Percepcion

    '    ''======================================================================================= Inicio Total Descuento
    '    'additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
    '    '                .ID = "2005", _
    '    '                .PayableAmount = FormatNumber(TotDscto, 2) _
    '    '}
    '    ''======================================================================================= Fin Total descuentos

    '    additionalpro = New UblLarsen.Ubl2.Sac.AdditionalPropertyType(1) {}
    '    additionalpro(0) = New UblLarsen.Ubl2.Sac.AdditionalPropertyType() With { _
    '                    .ID = "1000", _
    '                    .Value = TotNetoLetras _
    '    }


    '    '================================================================================================================================= Fin Codigo AdditionalInformation

    '    '================================================================================================================================= Inicio Codigo InvoiceLine

    '    Dim line1 As InvoiceLineType() = Nothing

    '    Dim row As Janus.Windows.GridEX.GridEXRow

    '    If GridEX1.RowCount > 0 Then
    '        Dim cantline As Integer = GridEX1.RowCount
    '        line1 = New InvoiceLineType(cantline) {}

    '        For j = 0 To GridEX1.RowCount - 1
    '            Me.GridEX1.Row = j
    '            row = Me.GridEX1.GetRow()

    '            line1(j) = New InvoiceLineType() With { _
    '                                       .ID = CStr(row.Cells("Item").Value), _
    '                                       .InvoicedQuantity = New QuantityType() With { _
    '                                           .unitCode = CStr(row.Cells("unitCode").Value), _
    '                                           .Value = CDec(row.Cells("CanMer").Value) _
    '                                       }, _
    '                                       .LineExtensionAmount = CDec(FormatNumber(row.Cells("LineExtensionAmount").Value, 2)), _
    '                                       .PricingReference = New PricingReferenceType() With { _
    '                                           .AlternativeConditionPrice = New PriceType() {New PriceType() With { _
    '                                               .PriceAmount = CDec(FormatNumber(row.Cells("Price").Value, 2)), _
    '                                               .PriceTypeCode = CStr("01") _
    '                                           }} _
    '                                       }, _
    '                                       .TaxTotal = New TaxTotalType() {New TaxTotalType() With { _
    '                                           .TaxAmount = CDec(FormatNumber("0.0", 2)), _
    '                                           .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '                                               .TaxAmount = CDec(FormatNumber(("0.0"), 2)), _
    '                                               .TaxCategory = New TaxCategoryType() With { _
    '                                                   .TaxExemptionReasonCode = CStr("30"), _
    '                                                   .TaxScheme = New TaxSchemeType() With { _
    '                                                       .ID = CStr(row.Cells("CodTributo").Value), _
    '                                                       .Name = CStr(row.Cells("NomTributo").Value), _
    '                                                       .TaxTypeCode = CStr(row.Cells("CodTributoInt").Value) _
    '                                                   } _
    '                                               } _
    '                                           }} _
    '                                       }}, _
    '                                       .Item = New ItemType() With { _
    '                                           .Description = New TextType() {CStr(row.Cells("DesMer1").Value)}, _
    '                                           .SellersItemIdentification = New ItemIdentificationType() With { _
    '                                               .ID = CStr(row.Cells("CodMer").Value) _
    '                                           } _
    '                                       }, _
    '                                       .Price = New PriceType() With { _
    '                                           .PriceAmount = CDec(FormatNumber(row.Cells("Price").Value, 2)) _
    '                                       } _
    '                                   }

    '        Next

    '    End If

    '    '==============================================================================================================================Fin Codigo InvoiceLine

    '    '==============================================================================================================================Inicio Codigo GenerarXML

    '    FacturacionElectronica.GenerarInvoice(xmlFilename, additionalmon, additionalpro, CurrencyId, NumDoc, FecDoc, TipoDoc, accountcust(0), taxtotal, legal(0), line1)

    '    '==============================================================================================================================Fin Codigo GenerarXML

    '    FirmadoDigital()

    'End Sub

    'Private Sub CrearXmlDet21()

    '    Try

    '        Dim xmlFilename As String = "D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-03-" & Documento & ".xml"
    '        Dim registro As New DocumentoSunat()

    '        registro.RucEmisor = Session.sRucEmp
    '        registro.DesEmpEmisor = Session.sDesEmp
    '        registro.CodUbigeoEmisor = Session.sCodUbigeo
    '        registro.DireccionEmisor = Session.sDireccion
    '        registro.DepartamentoEmisor = Session.sDepartamento
    '        registro.ProvinciaEmisor = Session.sProvincia
    '        registro.DistritoEmisor = Session.sDistrito
    '        registro.CurrencyCode = CurrencyId
    '        registro.Documento = Documento
    '        registro.FecDoc = FecDoc
    '        registro.FecVencimiento = FecDoc
    '        registro.TipoDoc = TipoDoc
    '        registro.LetrasTotalDoc = TotNetoLetras
    '        registro.CodDocCliente = TipoIdentidad
    '        registro.RucCliente = DniCli
    '        registro.DesCliente = DesCli
    '        registro.PorcentajeIGV = Session.sIGV
    '        registro.CodAfectacionIGV = CodAfectacion
    '        registro.TotalGrabado = IIf(Session.sIGV = 0, 0, TotVenta)
    '        registro.TotalDscto = 0 'TotDscto
    '        registro.TotalInafecto = 0
    '        registro.TotalGratuita = IIf(InstructionID <> "05", TotVenta, 0.00)
    '        registro.TotalExonerada = IIf(Session.sIGV = 0, TotVenta, 0)
    '        registro.TotalIgv = IIf(InstructionID <> "05", TaxAmount, 0.00)
    '        registro.TotalPrecio = TotVenta 'INCLUYE EL BRUTO MAS IGV
    '        registro.TotalNeto = LegalMonetaryTotal

    '        Dim cantline As Integer = GridEX1.RowCount - 1
    '        Dim fila As DocumentoDetalleSunat() = New DocumentoDetalleSunat(cantline) {}
    '        Dim row As Janus.Windows.GridEX.GridEXRow
    '        If GridEX1.RowCount > 0 Then

    '            'fila = New DocumentoDetalleSunat(cantline) {}
    '            For j = 0 To GridEX1.RowCount - 1
    '                Me.GridEX1.Row = j
    '                row = Me.GridEX1.GetRow()
    '                fila(j) = New DocumentoDetalleSunat() With {
    '                    .Id = CStr(row.Cells("Item").Value),
    '                    .Codigo = CStr(row.Cells("CodMer").Value),
    '                    .Descripcion = CStr(row.Cells("DesMer1").Value),
    '                    .Cantidad = CDec(row.Cells("CanMer").Value),
    '                    .TipoPrecio = CStr(row.Cells("CodigoPrecio").Value),
    '                    .UnidadMedida = CStr(row.Cells("unitCode").Value),
    '                    .PrecioUnitario = CDec(FormatNumber(row.Cells("Price").Value, 2)),
    '                    .PrecioReferencia = CDec(FormatNumber(row.Cells("Pricingreference").Value, 2)),
    '                    .MontoIgv = CDec(FormatNumber(row.Cells("MontoIgv").Value, 2)),
    '                    .PrecioFinal = CDec(FormatNumber(row.Cells("LineExtensionAmount").Value, 2)),
    '                    .PrecioNeto = CDec(FormatNumber(row.Cells("LineExtensionAmount").Value, 2))
    '                    }
    '            Next

    '        End If

    '        registro.DocumentoFilas = fila

    '        FacturacionElectronica21.GenerarInvoice(xmlFilename, registro)

    '        FirmadoDigital21()

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear xml")
    '        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    '    End Try

    'End Sub

    Private Sub CrearXMLSerializadoDet()
        Try
            Dim xmlFilename As String = "D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-03-" & Documento & ".xml"
            'Dim xmlFilename As String = "D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\20100020441-03-" & Documento & ".xml"

            UblLarsen.Ubl2.UblBaseDocumentType.GlbCustomizationID = "1.0"

            AmountType.TlsDefaultCurrencyID = CurrencyId

            '================================================================================================================================= Inicio Codigo TaxTotal

            Dim taxtotal As TaxTotalType()

            If InstructionID <> "05" Then

                taxtotal = New TaxTotalType(1) {}
                taxtotal(0) = New TaxTotalType() With { _
                   .TaxAmount = FormatNumber(TaxAmount, 2), _
                   .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
                       .TaxAmount = FormatNumber(TaxAmount, 2), _
                       .TaxCategory = New TaxCategoryType() With { _
                           .TaxExemptionReasonCode = CodAfectacion, _
                           .TaxScheme = New TaxSchemeType() With { _
                               .ID = CodTributo, _
                               .Name = NomTributo, _
                               .TaxTypeCode = CodTributoInt _
                           } _
                       } _
                   }} _
                }

            ElseIf InstructionID = "05" Then

                taxtotal = New TaxTotalType(1) {}
                taxtotal(0) = New TaxTotalType() With { _
                   .TaxAmount = FormatNumber("0.00", 2), _
                   .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
                       .TaxAmount = FormatNumber("0.00", 2), _
                       .TaxCategory = New TaxCategoryType() With { _
                           .TaxExemptionReasonCode = CodAfectacion, _
                           .TaxScheme = New TaxSchemeType() With { _
                               .ID = CodTributo, _
                               .Name = NomTributo, _
                               .TaxTypeCode = CodTributoInt _
                           } _
                       } _
                   }} _
                }

            End If
            '================================================================================================================================= Inicio Codigo TaxTotal

            '================================================================================================================================= Inicio Codigo LegalMonetaryTotal

            Dim legal As MonetaryTotalType()

            If InstructionID <> "05" Then

                legal = New MonetaryTotalType(1) {}
                legal(0) = New MonetaryTotalType() With { _
                    .PayableAmount = FormatNumber(LegalMonetaryTotal, 2) _
                }
            ElseIf InstructionID = "05" Then

                legal = New MonetaryTotalType(1) {}
                legal(0) = New MonetaryTotalType() With { _
                    .PayableAmount = FormatNumber("0.00", 2) _
                }

            End If
            '================================================================================================================================= Fin Codigo LegalMonetaryTotal

            '================================================================================================================================= Inicio Codigo CustomerParty

            Dim accountcust As CustomerPartyType() = New CustomerPartyType(1) {}
            accountcust(0) = New CustomerPartyType() With { _
               .CustomerAssignedAccountID = DniCli, _
               .AdditionalAccountID = New IdentifierType() {CStr(TipoIdentidad)}, _
               .Party = New PartyType() With { _
                    .PostalAddress = New AddressType() With { _
                    .ID = CodUbigeoRec, _
                    .StreetName = DireccionFiscal, _
                    .CityName = NomDptoRec, _
                    .CountrySubentity = NomProvRec, _
                    .District = NomDistRec, _
                    .Country = New CountryType() With { _
                            .IdentificationCode = CodPais _
                    } _
                }, _
                .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With { _
                    .RegistrationName = DesCli _
                    }} _
               } _
            }

            '================================================================================================================================= Fin Codigo CustomerParty

            '================================================================================================================================= Inicio Codigo AdditionalInformation

            Dim additionalmon As UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType()
            Dim additionalpro As UblLarsen.Ubl2.Sac.AdditionalPropertyType()

            If InstructionID = "01" Then

                additionalmon = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType(2) {}
                additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                                .ID = "1001", _
                                .PayableAmount = FormatNumber(TotVenta, 2) _
                }

                ''======================================================================================= Inicio Operaciones inafectas
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
                additionalmon(2) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                                .ID = "2005", _
                                .PayableAmount = FormatNumber(TotDscto, 2) _
                }
                ''======================================================================================= Fin Total descuentos

                additionalpro = New UblLarsen.Ubl2.Sac.AdditionalPropertyType(1) {}
                additionalpro(0) = New UblLarsen.Ubl2.Sac.AdditionalPropertyType() With { _
                                .ID = "1000", _
                                .Value = TotNetoLetras _
                }
            ElseIf InstructionID = "04" Then

                additionalmon = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType(3) {}
                additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                                .ID = "1001", _
                                .PayableAmount = FormatNumber(0, 2) _
                }

                ''======================================================================================= Inicio Operaciones inafectas
                additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                                .ID = "1002", _
                                .PayableAmount = FormatNumber(TotVenta, 2) _
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
                additionalmon(2) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                                .ID = "2005", _
                                .PayableAmount = FormatNumber(TotDscto, 2) _
                }
                ''======================================================================================= Fin Total descuentos

                additionalpro = New UblLarsen.Ubl2.Sac.AdditionalPropertyType(1) {}
                additionalpro(0) = New UblLarsen.Ubl2.Sac.AdditionalPropertyType() With { _
                                .ID = "1000", _
                                .Value = TotNetoLetras _
                }
            ElseIf InstructionID = "05" Then

                additionalmon = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType(2) {}
                additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                                .ID = "1001", _
                                .PayableAmount = FormatNumber(0, 2) _
                }

                additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                                .ID = "1004", _
                                .PayableAmount = FormatNumber(TotVenta, 2) _
                }

                additionalpro = New UblLarsen.Ubl2.Sac.AdditionalPropertyType(1) {}
                additionalpro(0) = New UblLarsen.Ubl2.Sac.AdditionalPropertyType() With { _
                                .ID = "1002", _
                                .Value = "TRANSFERENCIA GRATUITA DE UN BIEN Y/O SERVICIO PRESTADO GRATUITAMENTE" _
                }

            End If

            '================================================================================================================================= Fin Codigo AdditionalInformation

            '================================================================================================================================= Inicio Codigo InvoiceLine

            Dim line1 As InvoiceLineType() = Nothing

            Dim row As Janus.Windows.GridEX.GridEXRow

            If GridEX1.RowCount > 0 Then
                Dim cantline As Integer = GridEX1.RowCount
                line1 = New InvoiceLineType(cantline) {}

                For j = 0 To GridEX1.RowCount - 1
                    Me.GridEX1.Row = j
                    row = Me.GridEX1.GetRow()

                    If InstructionID <> "05" Then

                        line1(j) = New InvoiceLineType() With { _
                               .ID = CStr(row.Cells("Item").Value), _
                               .InvoicedQuantity = New QuantityType() With { _
                                   .unitCode = CStr(row.Cells("unitCode").Value), _
                                   .Value = CDec(row.Cells("CanMer").Value) _
                               }, _
                               .LineExtensionAmount = CDec(FormatNumber(row.Cells("LineExtensionAmount").Value, 2)), _
                               .PricingReference = New PricingReferenceType() With { _
                                   .AlternativeConditionPrice = New PriceType() {New PriceType() With { _
                                       .PriceAmount = CDec(FormatNumber(row.Cells("Pricingreference").Value, 2)), _
                                       .PriceTypeCode = CStr(row.Cells("CodigoPrecio").Value) _
                                   }} _
                               }, _
                               .TaxTotal = New TaxTotalType() {New TaxTotalType() With { _
                                   .TaxAmount = CDec(FormatNumber(row.Cells("MontoIgv").Value, 2)), _
                                   .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
                                       .TaxAmount = CDec(FormatNumber(row.Cells("MontoIgv").Value, 2)), _
                                       .TaxCategory = New TaxCategoryType() With { _
                                           .TaxExemptionReasonCode = CStr(CodAfectacion), _
                                           .TaxScheme = New TaxSchemeType() With { _
                                               .ID = CStr(row.Cells("CodTributo").Value), _
                                               .Name = CStr(row.Cells("NomTributo").Value), _
                                               .TaxTypeCode = CStr(row.Cells("CodTributoInt").Value) _
                                           } _
                                       } _
                                   }} _
                               }}, _
                               .Item = New ItemType() With { _
                                   .Description = New TextType() {CStr(row.Cells("DesMer1").Value)}, _
                                   .SellersItemIdentification = New ItemIdentificationType() With { _
                                       .ID = CStr(row.Cells("CodMer").Value) _
                                   } _
                               }, _
                               .Price = New PriceType() With { _
                                   .PriceAmount = CDec(FormatNumber(row.Cells("Price").Value, 2)) _
                               } _
                           }

                        'ElseIf CodMot = "1" And TotDscto > 0 Then

                        '    line1(j) = New InvoiceLineType() With { _
                        '          .ID = CStr(row.Cells("Item").Value), _
                        '          .InvoicedQuantity = New QuantityType() With { _
                        '              .unitCode = CStr(row.Cells("unitCode").Value), _
                        '              .Value = CDec(row.Cells("CanMer").Value) _
                        '          }, _
                        '          .LineExtensionAmount = CDec(FormatNumber(row.Cells("LineExtensionAmount").Value, 2)), _
                        '          .PricingReference = New PricingReferenceType() With { _
                        '              .AlternativeConditionPrice = New PriceType() {New PriceType() With { _
                        '                  .PriceAmount = CDec(FormatNumber(row.Cells("ValorUnitario").Value * 1.18, 2)), _
                        '                  .PriceTypeCode = CStr(row.Cells("CodigoPrecio").Value) _
                        '              }} _
                        '          }, _
                        '          .TaxTotal = New TaxTotalType() {New TaxTotalType() With { _
                        '              .TaxAmount = CDec(FormatNumber(row.Cells("MontoIgv").Value, 2)), _
                        '              .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
                        '                  .TaxAmount = CDec(FormatNumber(row.Cells("MontoIgv").Value, 2)), _
                        '                  .TaxCategory = New TaxCategoryType() With { _
                        '                      .TaxExemptionReasonCode = CStr(CodAfectacion), _
                        '                      .TaxScheme = New TaxSchemeType() With { _
                        '                          .ID = CStr(row.Cells("CodTributo").Value), _
                        '                          .Name = CStr(row.Cells("NomTributo").Value), _
                        '                          .TaxTypeCode = CStr(row.Cells("CodTributoInt").Value) _
                        '                      } _
                        '                  } _
                        '              }} _
                        '          }}, _
                        '          .Item = New ItemType() With { _
                        '              .Description = New TextType() {CStr(row.Cells("DesMer1").Value)}, _
                        '              .SellersItemIdentification = New ItemIdentificationType() With { _
                        '                  .ID = CStr(row.Cells("CodMer").Value) _
                        '              } _
                        '          }, _
                        '          .Price = New PriceType() With { _
                        '              .PriceAmount = CDec(FormatNumber(row.Cells("ValorUnitario").Value, 2)) _
                        '          } _
                        '      }


                    ElseIf InstructionID = "05" Then

                        line1(j) = New InvoiceLineType() With { _
                               .ID = CStr(row.Cells("Item").Value), _
                               .InvoicedQuantity = New QuantityType() With { _
                                   .unitCode = CStr(row.Cells("unitCode").Value), _
                                   .Value = CDec(row.Cells("CanMer").Value) _
                               }, _
                               .LineExtensionAmount = CDec(FormatNumber(row.Cells("LineExtensionAmount").Value, 2)), _
                               .PricingReference = New PricingReferenceType() With { _
                                   .AlternativeConditionPrice = New PriceType() {New PriceType() With { _
                                        .PriceAmount = CDec(FormatNumber(0, 2)), _
                                        .PriceTypeCode = "01" _
                                        }, New PriceType() With { _
                                       .PriceAmount = CDec(FormatNumber(row.Cells("Pricingreference").Value, 2)), _
                                       .PriceTypeCode = CStr("02") _
                                   }} _
                               }, _
                               .TaxTotal = New TaxTotalType() {New TaxTotalType() With { _
                                   .TaxAmount = CDec(FormatNumber("0.00", 2)), _
                                   .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
                                       .TaxAmount = CDec(FormatNumber("0.00", 2)), _
                                       .TaxCategory = New TaxCategoryType() With { _
                                           .TaxExemptionReasonCode = CStr(11), _
                                           .TaxScheme = New TaxSchemeType() With { _
                                               .ID = CStr(row.Cells("CodTributo").Value), _
                                               .Name = CStr(row.Cells("NomTributo").Value), _
                                               .TaxTypeCode = CStr(row.Cells("CodTributoInt").Value) _
                                           } _
                                       } _
                                   }} _
                               }}, _
                               .Item = New ItemType() With { _
                                   .Description = New TextType() {CStr(row.Cells("DesMer1").Value)}, _
                                   .SellersItemIdentification = New ItemIdentificationType() With { _
                                       .ID = CStr(row.Cells("CodMer").Value) _
                                   } _
                               }, _
                               .Price = New PriceType() With { _
                                   .PriceAmount = CDec(FormatNumber("0.00", 2)) _
                               } _
                           }


                    End If
                Next

            End If

            '==============================================================================================================================Fin Codigo InvoiceLine

            '==============================================================================================================================Inicio Codigo GenerarXML

            FacturacionElectronica.GenerarInvoice(xmlFilename, Session.sRucEmp, Session.sDesEmp, Session.sCodUbigeo, Session.sDireccion, Session.sDepartamento, Session.sProvincia, Session.sDistrito, additionalmon, additionalpro, CurrencyId, Documento, FecDoc, TipoDoc, accountcust(0), taxtotal, legal(0), line1)

            '==============================================================================================================================Fin Codigo GenerarXML

            FirmadoDigital()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear xml")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try
    End Sub

    Private Sub CrearXmlSerializadoRes()
        Try
            Dim xmlFilename As String = "D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-03-" & Documento & ".xml"
            'Dim xmlFilename As String = "D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\20100020441-03-" & Documento & ".xml"

            UblLarsen.Ubl2.UblBaseDocumentType.GlbCustomizationID = "1.0"

            AmountType.TlsDefaultCurrencyID = CurrencyId

            '================================================================================================================================= Inicio Codigo TaxTotal

            Dim taxtotal As TaxTotalType()

            If InstructionID <> "05" Then

                taxtotal = New TaxTotalType(1) {}
                taxtotal(0) = New TaxTotalType() With { _
                   .TaxAmount = FormatNumber(TaxAmount, 2), _
                   .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
                       .TaxAmount = FormatNumber(TaxAmount, 2), _
                       .TaxCategory = New TaxCategoryType() With { _
                           .TaxExemptionReasonCode = CodAfectacion, _
                           .TaxScheme = New TaxSchemeType() With { _
                               .ID = CodTributo, _
                               .Name = NomTributo, _
                               .TaxTypeCode = CodTributoInt _
                           } _
                       } _
                   }} _
                }

            ElseIf InstructionID = "05" Then

                taxtotal = New TaxTotalType(1) {}
                taxtotal(0) = New TaxTotalType() With { _
                   .TaxAmount = FormatNumber("0.00", 2), _
                   .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
                       .TaxAmount = FormatNumber("0.00", 2), _
                       .TaxCategory = New TaxCategoryType() With { _
                           .TaxExemptionReasonCode = CodAfectacion, _
                           .TaxScheme = New TaxSchemeType() With { _
                               .ID = CodTributo, _
                               .Name = NomTributo, _
                               .TaxTypeCode = CodTributoInt _
                           } _
                       } _
                   }} _
                }

            End If
            '================================================================================================================================= Inicio Codigo TaxTotal

            '================================================================================================================================= Inicio Codigo LegalMonetaryTotal

            Dim legal As MonetaryTotalType()

            If InstructionID <> "05" Then

                legal = New MonetaryTotalType(1) {}
                legal(0) = New MonetaryTotalType() With { _
                    .PayableAmount = FormatNumber(LegalMonetaryTotal, 2) _
                }
            ElseIf InstructionID = "05" Then

                legal = New MonetaryTotalType(1) {}
                legal(0) = New MonetaryTotalType() With { _
                    .PayableAmount = FormatNumber("0.00", 2) _
                }

            End If
            '================================================================================================================================= Fin Codigo LegalMonetaryTotal

            '================================================================================================================================= Inicio Codigo CustomerParty

            Dim accountcust As CustomerPartyType() = New CustomerPartyType(1) {}
            accountcust(0) = New CustomerPartyType() With { _
               .CustomerAssignedAccountID = DniCli, _
               .AdditionalAccountID = New IdentifierType() {CStr(TipoIdentidad)}, _
               .Party = New PartyType() With { _
                    .PostalAddress = New AddressType() With { _
                    .ID = CodUbigeoRec, _
                    .StreetName = DireccionFiscal, _
                    .CityName = NomDptoRec, _
                    .CountrySubentity = NomProvRec, _
                    .District = NomDistRec, _
                    .Country = New CountryType() With { _
                            .IdentificationCode = CodPais _
                    } _
                }, _
                .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With { _
                    .RegistrationName = DesCli _
                    }} _
               } _
            }

            '================================================================================================================================= Fin Codigo CustomerParty

            '================================================================================================================================= Inicio Codigo AdditionalInformation

            Dim additionalmon As UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType()
            Dim additionalpro As UblLarsen.Ubl2.Sac.AdditionalPropertyType()

            If InstructionID = "01" Then

                additionalmon = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType(2) {}
                additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                                .ID = "1001", _
                                .PayableAmount = FormatNumber(TotVenta, 2) _
                }

                ''======================================================================================= Inicio Operaciones inafectas
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
                additionalmon(2) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                                .ID = "2005", _
                                .PayableAmount = FormatNumber(TotDscto, 2) _
                }
                ''======================================================================================= Fin Total descuentos

                additionalpro = New UblLarsen.Ubl2.Sac.AdditionalPropertyType(1) {}
                additionalpro(0) = New UblLarsen.Ubl2.Sac.AdditionalPropertyType() With { _
                                .ID = "1000", _
                                .Value = TotNetoLetras _
                }
            ElseIf InstructionID = "04" Then

                additionalmon = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType(3) {}
                additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                                .ID = "1001", _
                                .PayableAmount = FormatNumber(0, 2) _
                }

                ''======================================================================================= Inicio Operaciones inafectas
                additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                                .ID = "1002", _
                                .PayableAmount = FormatNumber(TotVenta, 2) _
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
                additionalmon(2) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                                .ID = "2005", _
                                .PayableAmount = FormatNumber(TotDscto, 2) _
                }
                ''======================================================================================= Fin Total descuentos

                additionalpro = New UblLarsen.Ubl2.Sac.AdditionalPropertyType(1) {}
                additionalpro(0) = New UblLarsen.Ubl2.Sac.AdditionalPropertyType() With { _
                                .ID = "1000", _
                                .Value = TotNetoLetras _
                }
            ElseIf InstructionID = "05" Then

                additionalmon = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType(2) {}
                additionalmon(0) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                                .ID = "1001", _
                                .PayableAmount = FormatNumber(0, 2) _
                }

                additionalmon(1) = New UblLarsen.Ubl2.Sac.AdditionalMonetaryTotalType() With { _
                                .ID = "1004", _
                                .PayableAmount = FormatNumber(TotVenta, 2) _
                }

                additionalpro = New UblLarsen.Ubl2.Sac.AdditionalPropertyType(1) {}
                additionalpro(0) = New UblLarsen.Ubl2.Sac.AdditionalPropertyType() With { _
                                .ID = "1002", _
                                .Value = "TRANSFERENCIA GRATUITA DE UN BIEN Y/O SERVICIO PRESTADO GRATUITAMENTE" _
                }

            End If

            '================================================================================================================================= Fin Codigo AdditionalInformation

            '================================================================================================================================= Inicio Codigo InvoiceLine

            Dim line1 As InvoiceLineType() = Nothing

            Dim row As Janus.Windows.GridEX.GridEXRow

            If GridEX1.RowCount > 0 Then
                Dim cantline As Integer = GridEX1.RowCount
                line1 = New InvoiceLineType(cantline) {}

                For j = 0 To 0 ' GridEX1.RowCount - 1
                    Me.GridEX1.Row = j
                    row = Me.GridEX1.GetRow()

                    If InstructionID <> "05" Then

                        line1(j) = New InvoiceLineType() With { _
                               .ID = CStr(row.Cells("Item").Value), _
                               .InvoicedQuantity = New QuantityType() With { _
                                   .unitCode = CStr(row.Cells("unitCode").Value), _
                                   .Value = CDec(1) _
                               }, _
                               .LineExtensionAmount = CDec(FormatNumber(row.Cells("TotVenta").Value, 2)), _
                               .PricingReference = New PricingReferenceType() With { _
                                   .AlternativeConditionPrice = New PriceType() {New PriceType() With { _
                                       .PriceAmount = CDec(FormatNumber(row.Cells("LegalMonetaryTotal").Value, 2)), _
                                       .PriceTypeCode = CStr(row.Cells("CodigoPrecio").Value) _
                                   }} _
                               }, _
                               .TaxTotal = New TaxTotalType() {New TaxTotalType() With { _
                                   .TaxAmount = CDec(FormatNumber(row.Cells("TaxAmount").Value, 2)), _
                                   .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
                                       .TaxAmount = CDec(FormatNumber(row.Cells("TaxAmount").Value, 2)), _
                                       .TaxCategory = New TaxCategoryType() With { _
                                           .TaxExemptionReasonCode = CStr(CodAfectacion), _
                                           .TaxScheme = New TaxSchemeType() With { _
                                               .ID = CStr(row.Cells("CodTributo").Value), _
                                               .Name = CStr(row.Cells("NomTributo").Value), _
                                               .TaxTypeCode = CStr(row.Cells("CodTributoInt").Value) _
                                           } _
                                       } _
                                   }} _
                               }}, _
                               .Item = New ItemType() With { _
                                   .Description = New TextType() {CStr(row.Cells("Observacion").Value)}, _
                                   .SellersItemIdentification = New ItemIdentificationType() With { _
                                       .ID = CStr("-") _
                                   } _
                               }, _
                               .Price = New PriceType() With { _
                                   .PriceAmount = CDec(FormatNumber(row.Cells("TotVenta").Value, 2)) _
                               } _
                           }

                        'ElseIf CodMot = "1" And TotDscto > 0 Then

                        '    line1(j) = New InvoiceLineType() With { _
                        '          .ID = CStr(row.Cells("Item").Value), _
                        '          .InvoicedQuantity = New QuantityType() With { _
                        '              .unitCode = CStr(row.Cells("unitCode").Value), _
                        '              .Value = CDec(row.Cells("CanMer").Value) _
                        '          }, _
                        '          .LineExtensionAmount = CDec(FormatNumber(row.Cells("LineExtensionAmount").Value, 2)), _
                        '          .PricingReference = New PricingReferenceType() With { _
                        '              .AlternativeConditionPrice = New PriceType() {New PriceType() With { _
                        '                  .PriceAmount = CDec(FormatNumber(row.Cells("ValorUnitario").Value * 1.18, 2)), _
                        '                  .PriceTypeCode = CStr(row.Cells("CodigoPrecio").Value) _
                        '              }} _
                        '          }, _
                        '          .TaxTotal = New TaxTotalType() {New TaxTotalType() With { _
                        '              .TaxAmount = CDec(FormatNumber(row.Cells("MontoIgv").Value, 2)), _
                        '              .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
                        '                  .TaxAmount = CDec(FormatNumber(row.Cells("MontoIgv").Value, 2)), _
                        '                  .TaxCategory = New TaxCategoryType() With { _
                        '                      .TaxExemptionReasonCode = CStr(CodAfectacion), _
                        '                      .TaxScheme = New TaxSchemeType() With { _
                        '                          .ID = CStr(row.Cells("CodTributo").Value), _
                        '                          .Name = CStr(row.Cells("NomTributo").Value), _
                        '                          .TaxTypeCode = CStr(row.Cells("CodTributoInt").Value) _
                        '                      } _
                        '                  } _
                        '              }} _
                        '          }}, _
                        '          .Item = New ItemType() With { _
                        '              .Description = New TextType() {CStr(row.Cells("DesMer1").Value)}, _
                        '              .SellersItemIdentification = New ItemIdentificationType() With { _
                        '                  .ID = CStr(row.Cells("CodMer").Value) _
                        '              } _
                        '          }, _
                        '          .Price = New PriceType() With { _
                        '              .PriceAmount = CDec(FormatNumber(row.Cells("ValorUnitario").Value, 2)) _
                        '          } _
                        '      }


                    ElseIf InstructionID = "05" Then

                        line1(j) = New InvoiceLineType() With { _
                               .ID = CStr(row.Cells("Item").Value), _
                               .InvoicedQuantity = New QuantityType() With { _
                                   .unitCode = CStr(row.Cells("unitCode").Value), _
                                   .Value = CDec(row.Cells("CanMer").Value) _
                               }, _
                               .LineExtensionAmount = CDec(FormatNumber(row.Cells("LineExtensionAmount").Value, 2)), _
                               .PricingReference = New PricingReferenceType() With { _
                                   .AlternativeConditionPrice = New PriceType() {New PriceType() With { _
                                        .PriceAmount = CDec(FormatNumber(0, 2)), _
                                        .PriceTypeCode = "01" _
                                        }, New PriceType() With { _
                                       .PriceAmount = CDec(FormatNumber(row.Cells("Pricingreference").Value, 2)), _
                                       .PriceTypeCode = CStr("02") _
                                   }} _
                               }, _
                               .TaxTotal = New TaxTotalType() {New TaxTotalType() With { _
                                   .TaxAmount = CDec(FormatNumber("0.00", 2)), _
                                   .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
                                       .TaxAmount = CDec(FormatNumber("0.00", 2)), _
                                       .TaxCategory = New TaxCategoryType() With { _
                                           .TaxExemptionReasonCode = CStr(11), _
                                           .TaxScheme = New TaxSchemeType() With { _
                                               .ID = CStr(row.Cells("CodTributo").Value), _
                                               .Name = CStr(row.Cells("NomTributo").Value), _
                                               .TaxTypeCode = CStr(row.Cells("CodTributoInt").Value) _
                                           } _
                                       } _
                                   }} _
                               }}, _
                               .Item = New ItemType() With { _
                                   .Description = New TextType() {CStr(row.Cells("Observacion").Value)}, _
                                   .SellersItemIdentification = New ItemIdentificationType() With { _
                                       .ID = CStr("-") _
                                   } _
                               }, _
                               .Price = New PriceType() With { _
                                   .PriceAmount = CDec(FormatNumber("0.00", 2)) _
                               } _
                           }


                    End If
                Next

            End If

            '==============================================================================================================================Fin Codigo InvoiceLine

            '==============================================================================================================================Inicio Codigo GenerarXML

            FacturacionElectronica.GenerarInvoice(xmlFilename, Session.sRucEmp, Session.sDesEmp, Session.sCodUbigeo, Session.sDireccion, Session.sDepartamento, Session.sProvincia, Session.sDistrito, additionalmon, additionalpro, CurrencyId, Documento, FecDoc, TipoDoc, accountcust(0), taxtotal, legal(0), line1)

            '==============================================================================================================================Fin Codigo GenerarXML

            FirmadoDigital()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear xml")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try
    End Sub

    Private Sub FirmadoDigital()
        Try
            'Firmando xml 
            Dim ObjLib As New FirmarDocumento

            Dim direccion As String
            Dim firmado As Boolean
            direccion = "D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-03-" & Documento & ".xml"
            'direccion = "D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\20100020441-03-" & Documento & ".xml"

            Dim ruta As String = System.AppDomain.CurrentDomain.BaseDirectory & "Certificado\" & Session.sNombreCertificado
            'Dim ruta As String = System.AppDomain.CurrentDomain.BaseDirectory & "Certificado\" & Session.sNombreCertificado
            'firmado = ObjLib.SignXmlFile("20100020441", "D:\Documentos_Electronicos\xadesnettest.p12", "xadesnet", direccion)
            'firmado = ObjLib.SignXmlFile(Session.sRucEmp, 1, ruta, Session.sClaveCertificado, direccion)

            firmado = FirmarDocumento21.SignXmlFile(Session.sRucEmp, 1, ruta, Session.sClaveCertificado, direccion)

            'firmado = ObjLib.SignXmlFile("20100020441", 1, ruta, "DdperU", direccion)

            If firmado = True Then
                'MsgBox("Se genero el firmado", MsgBoxStyle.Information)

                Dim xmlDoc As New XmlDocument
                xmlDoc.Load("D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-03-" & Documento & ".xml")
                'xmlDoc.Load("D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\20100020441-03-" & Documento & ".xml")

                Dim insertar As Boolean
                'Dim nombrexml As String = GridEX1.CurrentRow.Cells("NumDoc").Text & ".xml"     'Comentado para que en el evento de descargar se obtenga el numdoc sin el ".xml"
                Dim nombrexml As String = Session.sRucEmp & "-03-" & Documento '& ".xml"
                'Dim nombrexml As String = 20100020441-03-" & Documento '& ".xml"
                'insertar = oBoletaDigitalService.Insertar(IdBoleta, nombrexml, xmlDoc.OuterXml, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                Comprimir()

                Dim resulenvio As Boolean
                Dim rutaenvio As String = "D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\"
                Dim file As String = Session.sRucEmp & "-03-" & Documento & ".ZIP"
                'Dim file As String = "20100020441-03-" & Documento & ".ZIP"

                '====================================================================================================================== Comentado porque en produccion SUNAT no responde
                'resulenvio = oComunicacionSunat.EnviarDocumentoSunat(rutaenvio, file)

                'If resulenvio Then

                'Dim xmlDocR As New XmlDocument
                'xmlDocR.Load("D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\R-20100020441-03-" & Documento & ".xml")

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
                '///////////////////////////////////////////////////////////////////////////

                Dim rutapdf As New FileStream("D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-03-" & Documento & ".pdf", FileMode.Open, FileAccess.Read)
                'Dim rutapdf As New FileStream("D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\20100020441-03-" & Documento & ".pdf", FileMode.Open, FileAccess.Read)
                Dim binario(rutapdf.Length) As Byte
                rutapdf.Read(binario, 0, rutapdf.Length) 'Leo el archivo y lo convierto a binario
                rutapdf.Close()

                Dim registro As New BoletaDigitalService.BoletaDigital
                Dim boleta As New BoletaDigitalService.Boleta

                registro.CDRxml = "" 'xmlDocR.OuterXml
                registro.CodUsu = Session.sCodUsu
                registro.DirIp = Session.sDirIp
                registro.DocumentoXml = xmlDoc.OuterXml
                registro.Estado = Responsecode
                boleta.IdBoleta = IdBoleta
                registro.Boleta = boleta
                registro.NombreXml = nombrexml
                registro.NomPc = Session.sNomPc
                registro.NumTicket = "" 'NumTicket
                registro.Observacion = "" 'Descripcioncdr
                registro.Notas = "" 'toNull(notecompilado)
                registro.DocumentoPdf = binario

                insertar = oBoletaDigitalService.Insertar(registro)

                If insertar Then
                    MsgBox("Se proceso la boleta electronica correctamente", MsgBoxStyle.Information)
                    EstadoSunat = True
                Else
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
                'Else
                '    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                'End If
            End If

            'Comentado porque en produccion no devuelve respuesta la sunat
            'If Responsecode <> "0" Then
            '    Me.DialogResult = System.Windows.Forms.DialogResult.OK
            'End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al firmar el documento")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try
    End Sub


    Private Sub Comprimir()

        Dim destdir As String = "D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-03-" & Documento & ".zip"
        'Dim destdir As String = "D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\20100020441-03-" & Documento & ".zip"

        Dim zip As ZipFile = New ZipFile
        Dim file As String = "D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-03-" & Documento & ".xml"
        'Dim file As String = "D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\20100020441-03-" & Documento & ".xml"
        zip.AddFile(file, "")
        zip.Save(destdir)

        ObtenerTagFirma()
        CrearPDF()

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

            xmlDoc.Load("D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-03-" & Documento & ".xml")
            'xmlDoc.Load("D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\20100020441-03-" & Documento & ".xml")

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

            Dim url As String = RucEmp & "|" & TipoDoc & "|" & CodSerie & "|" & NumDoc & "|" & IIf(CodMot <> "2", FormatNumber(TaxAmount, 2), FormatNumber("0.00", 2)) & "|" & IIf(CodMot <> "2", FormatNumber(LegalMonetaryTotal, 2), FormatNumber("0.00", 2)) & "|" & FecDoc.ToString("yyyy-MM-dd") & "|" & "1" & "|" & DniCli & "|" & ValorResumen
            UbicacionCodBarra = "D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\" & Documento & ".png"

            bmp = ZX.Write(url)
            bmp.Save(UbicacionCodBarra, Imaging.ImageFormat.Png)

            'Dim qr As PDF417Writer = New PDF417Writer

            'Dim url As String = RucEmp & "|" & TipoDoc & "|" & CodSerie & "|" & NumDoc & "|" & IIf(CodMot <> "2", FormatNumber(TaxAmount, 2), FormatNumber("0.00", 2)) & "|" & IIf(CodMot <> "2", FormatNumber(LegalMonetaryTotal, 2), FormatNumber("0.00", 2)) & "|" & FecDoc.ToString("yyyy-MM-dd") & "|" & "1" & "|" & DniCli & "|" & ValorResumen & "|" & ValorFirma


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
            'UbicacionCodBarra = "D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\" & Documento & ".png"
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
                CrearPDF2DetMtUAmazonica()
            ElseIf opcionimp = "Resumido" Then
                CrearPDF2ResMtUAmazonica()
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
            Dim reporte As New rpImprimirBoletaElectronica

            dtReporte = oBoletaService.ImprimirDigital(IdBoleta).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)

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
            Dim reporte As New rpImprimirBoletaElectronicaResumido

            dtReporte = oBoletaService.ImprimirDigital(IdBoleta).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)

            End If

            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2DetMtUAmazonica()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirBoletaElectronicaMtuAmaz

            dtReporte = oBoletaService.ImprimirDigital(IdBoleta).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)

            End If

            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2ResMtUAmazonica()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirBoletaElectronicaMtuAmazResumido

            dtReporte = oBoletaService.ImprimirDigital(IdBoleta).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)

            End If

            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    '----------------------------------------------------------------------------- EQUIMAP -----------------------------------------------------------------------------------------

    Private Sub CrearPDF2DetEquimap()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirBoletaElectronicaEquimap

            dtReporte = oBoletaService.ImprimirDigital(IdBoleta).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)

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
            Dim reporte As New rpImprimirBoletaElectronicaEquimapResumido

            dtReporte = oBoletaService.ImprimirDigital(IdBoleta).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)

            End If

            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub


    '----------------------------------------------------------------------------- C2TECK -----------------------------------------------------------------------------------------

    Private Sub CrearPDF2DetC2Teck()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirBoletaElectronicaC2Teck

            dtReporte = oBoletaService.ImprimirDigital(IdBoleta).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)

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
            Dim reporte As New rpImprimirBoletaElectronicaC2TeckResumido

            dtReporte = oBoletaService.ImprimirDigital(IdBoleta).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)

            End If

            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    '=====================================

    '----------------------------------------------------------------------------- C2TECK INFORMATICA Y METALURGICA --------------------------------------------------------------

    Private Sub CrearPDF2DetC2TeckIM()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirBoletaElectronicaC2TeckIM

            dtReporte = oBoletaService.ImprimirDigital(IdBoleta).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)

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
            Dim reporte As New rpImprimirBoletaElectronicaC2TeckIMResumido

            dtReporte = oBoletaService.ImprimirDigital(IdBoleta).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)

            End If

            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    '===================================== INFORMATICA Y METALURGICA 

    Public Shared Function ExportToPDF(rpt As ReportDocument, NombreArchivo As String, NumDoc1 As String) As String
        Dim vFileName As String = Nothing
        Dim diskOpts As New DiskFileDestinationOptions()

        Try
            'rpt.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
            'rpt.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat
            diskOpts.DiskFileName = "D:\Documentos_Electronicos\Boletas_Electronicas\" & NumDoc1 & "\" & Session.sRucEmp & "-03-" & NumDoc1 & ".pdf"
            'diskOpts.DiskFileName = "D:\Documentos_Electronicos\Boletas_Electronicas\" & NumDoc1 & "\20100020441-03-" & NumDoc1 & ".pdf"

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
            Dim d As New DirectoryInfo("D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento)

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

                If f.Extension <> ".png" And f.Extension <> ".zip" And Mid(f.Name, 1, 1) <> "R" Then
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
            txtAsunto.Text = Session.sDesEmp & " - Boleta Electrónica: " & Documento '"DETROIT DIESEL MTU PERU SAC - Boleta Electrónica: " & Documento
            txtMensaje.Text = "Envio de Boleta Electronica c/Adjunto xml, pdf"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Correo")
        End Try

    End Sub

    Private Sub CargarCorreoMtUAmazonica()

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
            txtAsunto.Text = Session.sDesEmp & " - Boleta Electrónica: " & Documento '"DETROIT DIESEL MTU PERU SAC - Boleta Electrónica: " & Documento
            txtMensaje.Text = "Envio de Boleta Electronica c/Adjunto xml, pdf"

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
            txtAsunto.Text = Session.sDesEmp & " - Boleta Electrónica: " & Documento '"DETROIT DIESEL MTU PERU SAC - Boleta Electrónica: " & Documento
            txtMensaje.Text = "Envio de Boleta Electronica c/Adjunto xml, pdf"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Correo")
        End Try

    End Sub

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
            txtAsunto.Text = Session.sDesEmp & " - Boleta Electrónica: " & Documento '"DETROIT DIESEL MTU PERU SAC - Boleta Electrónica: " & Documento
            txtMensaje.Text = "Envio de Boleta Electronica c/Adjunto xml, pdf"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Correo")
        End Try

    End Sub


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
            txtAsunto.Text = Session.sDesEmp & " - Boleta Electrónica: " & Documento '"DETROIT DIESEL MTU PERU SAC - Boleta Electrónica: " & Documento
            'txtMensaje.Text = "Envio de Boleta Electronica c/Adjunto xml, pdf" & Environment.NewLine & Environment.NewLine & "No Contestar el correo porque es una cuenta desatendida"
            txtMensaje.Text = "Envio de Boleta Electronica c/Adjunto xml, pdf"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Correo")
        End Try

    End Sub

    Private Sub btnEnviarCorreo_Click(sender As System.Object, e As System.EventArgs) Handles btnEnviarCorreo.Click

        Try
            If ValidaCamposCorreo() Then

                Dim Cuerpo As String
                Cuerpo = "<html><body><font size='2'>" + "Fecha de Ingreso " + Today().ToString("dd/MM/yyyy") + " : " + TimeOfDay.ToString("HH:mm:ss")
                Cuerpo = Cuerpo + "<br/><br/>Señor(es) : " +
                              "<br/><br/><b>" + Trim(DesCli) + ":</b>" +
                                     "<br/><br/>Le informamos que ha recibido un documento de " + DesEmp +
                                     "<br/><br/>Número de documento : " + Documento
                Cuerpo = Cuerpo + "<br/>Tipo de Documento : " + "Boleta"
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
                'Dim destdir As String = "D:\firmamateu.jpg"
                Dim destdir As String = "D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-03-" & Documento & ".zip"
                Dim xmldir As String = "D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-03-" & Documento & ".xml"
                Dim pdfdir As String = "D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-03-" & Documento & ".pdf"

                'Dim destdir As String = "D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\20100020441-03-" & Documento & ".zip"
                'Dim xmldir As String = "D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\20100020441-03-" & Documento & ".xml"
                'Dim pdfdir As String = "D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\20100020441-03-" & Documento & ".pdf"

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
            End If
        Catch ex As Exception
            MsgBox("Error al enviar por correo : " + ex.ToString, MsgBoxStyle.Exclamation)
            'txtError.Text = ex.ToString
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

    Private Sub btnVerBoleta_Click(sender As System.Object, e As System.EventArgs) Handles btnVerBoleta.Click
        If Session.sCodEmp = "01" Then
            If opcionimp = "Detallado" Then
                VerBoletaDetallado()
            ElseIf opcionimp = "Resumido" Then
                VerBoletaResumido()
            End If
        ElseIf Session.sCodEmp = "02" Then
            If opcionimp = "Detallado" Then
                VerBoletaDetalladoMtuAmazonica()
            ElseIf opcionimp = "Resumido" Then
                VerBoletaResumidoMtuAmazonica()
            End If
        ElseIf Session.sCodEmp = "05" Then
            If opcionimp = "Detallado" Then
                VerBoletaDetalladoEquimap()
            ElseIf opcionimp = "Resumido" Then
                VerBoletaResumidoEquimap()
            End If
        ElseIf Session.sCodEmp = "07" Then
            If opcionimp = "Detallado" Then
                VerBoletaDetalladoC2Teck()
            ElseIf opcionimp = "Resumido" Then
                VerBoletaResumidoC2Teck()
            End If
        ElseIf Session.sCodEmp = "08" Then
            If opcionimp = "Detallado" Then
                VerBoletaDetalladoC2TeckIM()
            ElseIf opcionimp = "Resumido" Then
                VerBoletaResumidoC2TeckIM()
            End If

        End If
    End Sub

    Private Sub VerBoletaDetallado()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirBoletaElectronica

            dtReporte = oBoletaService.ImprimirDigital(IdBoleta).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                'reporte.SetParameterValue("pIdMesa", 0)
                forma.Text = "Boleta Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub VerBoletaResumido()

        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirBoletaElectronicaResumido

            dtReporte = oBoletaService.ImprimirDigital(IdBoleta).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                'reporte.SetParameterValue("pIdMesa", 0)
                forma.Text = "Boleta Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub VerBoletaDetalladoMtuAmazonica()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirBoletaElectronicaMtuAmaz

            dtReporte = oBoletaService.ImprimirDigital(IdBoleta).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                'reporte.SetParameterValue("pIdMesa", 0)
                forma.Text = "Boleta Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub VerBoletaResumidoMtuAmazonica()

        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirBoletaElectronicaMtuAmazResumido

            dtReporte = oBoletaService.ImprimirDigital(IdBoleta).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                'reporte.SetParameterValue("pIdMesa", 0)
                forma.Text = "Boleta Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    ' ------------------------------------------------------------------------------------------- EQUIMAP ---------------------------------------------------------------------------

    Private Sub VerBoletaDetalladoEquimap()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirBoletaElectronicaEquimap

            dtReporte = oBoletaService.ImprimirDigital(IdBoleta).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                'reporte.SetParameterValue("pIdMesa", 0)
                forma.Text = "Boleta Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub VerBoletaResumidoEquimap()

        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirBoletaElectronicaEquimapResumido

            dtReporte = oBoletaService.ImprimirDigital(IdBoleta).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                'reporte.SetParameterValue("pIdMesa", 0)
                forma.Text = "Boleta Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub


    ' ------------------------------------------------------------------------------------------- C2TECK ---------------------------------------------------------------------------

    Private Sub VerBoletaDetalladoC2Teck()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirBoletaElectronicaC2Teck

            dtReporte = oBoletaService.ImprimirDigital(IdBoleta).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                'reporte.SetParameterValue("pIdMesa", 0)
                forma.Text = "Boleta Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub VerBoletaResumidoC2Teck()

        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirBoletaElectronicaC2TeckResumido

            dtReporte = oBoletaService.ImprimirDigital(IdBoleta).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                'reporte.SetParameterValue("pIdMesa", 0)
                forma.Text = "Boleta Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub


    ' ------------------------------------------------------------------------------------------- C2TECK ---------------------------------------------------------------------------

    ' ------------------------------------------------------------------------------------------- C2TECK INFORMATICA Y METALURGICA ---------------------------------------------------

    Private Sub VerBoletaDetalladoC2TeckIM()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirBoletaElectronicaC2TeckIM

            dtReporte = oBoletaService.ImprimirDigital(IdBoleta).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                'reporte.SetParameterValue("pIdMesa", 0)
                forma.Text = "Boleta Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub VerBoletaResumidoC2TeckIM()

        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirBoletaElectronicaC2TeckIMResumido

            dtReporte = oBoletaService.ImprimirDigital(IdBoleta).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                'reporte.SetParameterValue("pIdMesa", 0)
                forma.Text = "Boleta Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub


    ' ------------------------------------------------------------------------------------------- C2TECK INFORMATICA Y METALURGICA -------------------------------------------------


    Private Sub CrearXmlDetalle21()

        Try

            Dim xmlFilename As String = "D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-03-" & Documento & ".xml"
            Dim registro As New DocumentoSunat()

            'TipoAfectacion = (1: GRABADO, 2: EXONERADO, 3: INAFECTO, 4: GRATUITO, 5: EXPORTACION)

            Dim tipoAfectacion As Integer
            tipoAfectacion = IIf(CodAfectacion = "20", 2, IIf(InstructionID = "05", 4, IIf(CodAfectacion = "40", 5, IIf(CodAfectacion = "30", 3, 1))))

            'CodAfectacion = IIf(Session.sIGV = 0, "20", IIf(InstructionID = "05", "31", IIf(InstructionID = "04", "40", CodAfectacion)))

            registro.RucEmisor = Session.sRucEmp
            registro.DesEmpEmisor = Session.sDesEmp
            registro.CodUbigeoEmisor = Session.sCodUbigeo
            registro.DireccionEmisor = Session.sDireccion
            registro.DepartamentoEmisor = Session.sDepartamento
            registro.ProvinciaEmisor = Session.sProvincia
            registro.DistritoEmisor = Session.sDistrito
            registro.CurrencyCode = CurrencyId
            registro.TipoFactura = TipoFactura
            registro.FormaPago = "Contado" 'FormaPago
            registro.NumeroCuotas = "Cuota001"
            registro.Documento = Documento
            registro.FecDoc = FecDoc
            registro.FecVencimiento = oDocCtaCte.CalcularFecVen(CodPag, FecDoc)
            registro.TipoDoc = TipoDoc
            registro.LetrasTotalDoc = TotNetoLetras
            registro.CodDocCliente = TipoIdentidad
            registro.RucCliente = DniCli
            registro.DesCliente = DesCli
            registro.PorcentajeIGV = Igv
            registro.TipoAfectacion = tipoAfectacion  'IIf(CodAfectacion = "20", 2, IIf(InstructionID = "05", 4, IIf(InstructionID = "04", 5, 1)))
            registro.CodAfectacionIGV = CodAfectacion
            registro.NumOrden = "" 'NumOrden
            registro.NumGuia = NumGuis
            registro.TotalAnticipos = TotalAnticipos
            registro.TotalBruto = TotVenta
            registro.TotalDscto = 0.00 'TotDscto
            registro.TotalIgv = IIf(InstructionID <> "05" Or IGV > 0, TaxAmount, 0.00)
            registro.TotalPrecio = LegalMonetaryTotal  'TotVenta 'INCLUYE EL BRUTO MAS IGV
            registro.TotalNeto = LegalMonetaryTotal
            registro.TotalCuota = TotalCuota
            registro.CodEstablecimiento = CodEstablecimiento

            registro.CodDetraccion = Nothing
            registro.CuentaBancoDetraccion = Nothing
            registro.PorcentajeDetraccion = 0
            registro.MontoDetraccion = 0.00

            ''//////////VARIAS CUOTAS///////////
            'If CodPag <> "00" And CodPag <> "25" Then '/////CREDITO//////
            '    Dim dtCuotas As DataTable
            '    dtCuotas = oFacturaService.MostrarCuota(IdFactura).Tables(0)
            '    Dim canCuota As Integer = dtCuotas.Rows.Count()
            '    Dim n As Integer = 0
            '    Dim regCuota As DocumentoCuotas() = New DocumentoCuotas(canCuota - 1) {}
            '    For Each FilaCuota As DataRow In dtCuotas.Rows
            '        regCuota(n) = New DocumentoCuotas() With {
            '                 .NumeroCuota = IIf(FilaCuota.Item("NumeroCuota") < 10, "Cuota00" & FilaCuota.Item("NumeroCuota"), "Cuota0" & FilaCuota.Item("NumeroCuota")),
            '                 .TotalCuota = CDec(FormatNumber(FilaCuota.Item("TotalCuota"), 2)),
            '                 .FecVencimientoCuota = FilaCuota.Item("FecVencimiento")
            '            }
            '        n = n + 1
            '    Next
            '    registro.DocumentoFilasCuotas = regCuota
            'Else '//////CONTADO///////
            Dim regCuota As DocumentoCuotas() = New DocumentoCuotas(1) {}
                regCuota(0) = New DocumentoCuotas() With {
                             .NumeroCuota = "Cuota001",
                             .TotalCuota = TotalCuota,
                             .FecVencimientoCuota = registro.FecVencimiento
                        }
                registro.DocumentoFilasCuotas = regCuota
            'End If
            '////////////////////////////////



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

            FacturacionElectronica21.GenerarInvoice(xmlFilename, registro)

            FirmadoDigital()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear xml")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try

    End Sub

    Private Sub CrearXmlResumen21()

        Try

            Dim xmlFilename As String = "D:\Documentos_Electronicos\Boletas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-03-" & Documento & ".xml"
            Dim registro As New DocumentoSunat()

            'TipoAfectacion = (1: GRABADO, 2: EXONERADO, 3: INAFECTO, 4: GRATUITO, 5: EXPORTACION)

            Dim tipoAfectacion As Integer
            tipoAfectacion = IIf(CodAfectacion = "20", 2, IIf(InstructionID = "05", 4, IIf(CodAfectacion = "40", 5, IIf(CodAfectacion = "30", 3, 1))))

            'CodAfectacion = IIf(Session.sIGV = 0, "20", IIf(InstructionID = "05", "31", IIf(InstructionID = "04", "40", CodAfectacion)))

            registro.RucEmisor = Session.sRucEmp
            registro.DesEmpEmisor = Session.sDesEmp
            registro.CodUbigeoEmisor = Session.sCodUbigeo
            registro.DireccionEmisor = Session.sDireccion
            registro.DepartamentoEmisor = Session.sDepartamento
            registro.ProvinciaEmisor = Session.sProvincia
            registro.DistritoEmisor = Session.sDistrito
            registro.CurrencyCode = CurrencyId
            registro.TipoFactura = TipoFactura
            registro.FormaPago = "Contado" 'FormaPago
            registro.NumeroCuotas = "Cuota001"
            registro.Documento = Documento
            registro.FecDoc = FecDoc
            registro.FecVencimiento = oDocCtaCte.CalcularFecVen(CodPag, FecDoc)
            registro.TipoDoc = TipoDoc
            registro.LetrasTotalDoc = TotNetoLetras
            registro.CodDocCliente = TipoIdentidad
            registro.RucCliente = DniCli
            registro.DesCliente = DesCli
            registro.PorcentajeIGV = Igv
            registro.TipoAfectacion = tipoAfectacion  'IIf(CodAfectacion = "20", 2, IIf(InstructionID = "05", 4, IIf(InstructionID = "04", 5, 1)))
            registro.CodAfectacionIGV = CodAfectacion
            registro.NumOrden = "" 'NumOrden
            registro.NumGuia = NumGuis
            registro.TotalAnticipos = TotalAnticipos
            registro.TotalBruto = TotVenta
            registro.TotalDscto = 0.00 'TotDscto
            registro.TotalIgv = IIf(InstructionID <> "05" Or Igv > 0, TaxAmount, 0.00)
            registro.TotalPrecio = LegalMonetaryTotal  'TotVenta 'INCLUYE EL BRUTO MAS IGV
            registro.TotalNeto = LegalMonetaryTotal
            registro.TotalCuota = TotalCuota
            registro.CodEstablecimiento = CodEstablecimiento

            'registro.CodDetraccion = Nothing
            'registro.CuentaBancoDetraccion = Nothing
            'registro.PorcentajeDetraccion = 0
            'registro.MontoDetraccion = 0.00

            ''//////////VARIAS CUOTAS///////////
            'If CodPag <> "00" And CodPag <> "25" Then '/////CREDITO//////
            '    Dim dtCuotas As DataTable
            '    dtCuotas = oFacturaService.MostrarCuota(IdFactura).Tables(0)
            '    Dim canCuota As Integer = dtCuotas.Rows.Count()
            '    Dim n As Integer = 0
            '    Dim regCuota As DocumentoCuotas() = New DocumentoCuotas(canCuota - 1) {}
            '    For Each FilaCuota As DataRow In dtCuotas.Rows
            '        regCuota(n) = New DocumentoCuotas() With {
            '                 .NumeroCuota = IIf(FilaCuota.Item("NumeroCuota") < 10, "Cuota00" & FilaCuota.Item("NumeroCuota"), "Cuota0" & FilaCuota.Item("NumeroCuota")),
            '                 .TotalCuota = CDec(FormatNumber(FilaCuota.Item("TotalCuota"), 2)),
            '                 .FecVencimientoCuota = FilaCuota.Item("FecVencimiento")
            '            }
            '        n = n + 1
            '    Next
            '    registro.DocumentoFilasCuotas = regCuota
            'Else '//////CONTADO///////
            Dim regCuota As DocumentoCuotas() = New DocumentoCuotas(1) {}
            regCuota(0) = New DocumentoCuotas() With {
                             .NumeroCuota = "Cuota001",
                             .TotalCuota = TotalCuota,
                             .FecVencimientoCuota = registro.FecVencimiento
                        }
            registro.DocumentoFilasCuotas = regCuota
            'End If
            '////////////////////////////////

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

            FacturacionElectronica21.GenerarInvoice(xmlFilename, registro)

            FirmadoDigital()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear xml")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try

    End Sub

End Class