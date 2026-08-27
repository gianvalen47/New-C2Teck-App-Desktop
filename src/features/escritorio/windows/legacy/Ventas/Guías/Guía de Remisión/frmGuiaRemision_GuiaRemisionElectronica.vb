Imports System
Imports System.IO
Imports System.ServiceModel
Imports System.Xml
Imports System.Xml.Schema
Imports System.Text
Imports System.Net.Mail
Imports Ionic.Zip
Imports UblLarsen.Ubl2
Imports LibreriaFacturacion
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
Imports System.Security.Cryptography

Public Class frmGuiaRemision_GuiaRemisionElectronica

    Private oGuiaRemisionService As New GuiaRemisionService.GuiaRemisionServiceClient
    Private oUsuarioClienteService As New UsuarioClienteService.UsuarioClienteServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oComunicacionSunat As New ComunicacionSunat
    Private oGuiaRemisionDigitalService As New GuiaRemisionDigitalService.GuiaRemisionDigitalServiceClient

    Public opcionimp As String
    Public MostrarPrecio As String
    Public IdGu As Integer
    Public EstadoSunat As Boolean

    Private VerFactura As Boolean
    Private dtImprimirDigital As DataTable
    Public MostrarBanco As Boolean

    Dim IdGuia As Integer
    Dim IdCliente As String
    Dim FecDoc As Date
    Dim DesEmp As String
    Dim DirEmp As String
    Dim TelEmp As String
    Dim Urbanizacion As String
    Dim CodUbigeo As String
    Dim Departamento As String
    Dim Provincia As String
    Dim Distrito As String
    Dim CodPais As String
    Dim RucEmp As String
    Dim TipoDoc As String
    Public Documento As String
    Dim TipoIdentidad As String
    Dim RucCli As String
    Dim DniCli As String
    Dim DesCli As String
    Dim unitCode As String
    Dim CanMer As String
    Dim DesMer1 As String
    Dim PreMer As Double
    Dim DscMer As Double
    Dim TotalFila As Double
    Dim CodMot As String
    Dim DesMot As String
    Dim TotBruto As Double
    Dim TotDscto As Double
    Dim TotFlete As Double
    Dim TotEmbarque As Double
    Dim TotVenta As Double
    Dim TotGasto As Double
    Dim TotIgv As Double
    Dim TotNeto As Double
    Dim CodMon As String
    Dim DesMon As String
    Dim AbrMon As String
    Dim Item As String
    Dim CodMer As String
    Dim Observacion As String
    Dim NumOrden As String
    Dim NumJob As String
    Dim Igv As String
    Dim DesPag As String
    Dim DireccionFiscal As String
    Dim Ubigeo As String
    Dim CodUbigeoRec As String
    Dim NomDistRec As String
    Dim NomProvRec As String
    Dim NomDptoRec As String
    Dim CodSerie As String
    Dim NumDoc As String
    Dim CodTraslado As String
    Dim PtoPartida As String
    Dim PtoLlegada As String
    Dim CodUbigeoLlegada As String

    Dim Empresa As String
    Dim Direccion As String
    Dim Ruc As String
    Dim Vehiculo As String
    Dim Placa As String
    Dim Chofer As String
    Dim Licencia As String
    Dim ConIns As String
    Dim CodDocChofer As String
    Dim NumDocChofer As String

    Dim CodUniMed As String
    Dim PesoBruto As String
    Dim CodUniMedPeso As String
    Dim NumeroBultos As String
    Dim CodModo As String
    Dim FecTraslado As Date

    Dim Responsecode As String
    Dim UbicacionCodBarra As String
    Dim ValorResumen As String
    Dim ValorFirma As String

    Dim TotNetoLetras As String

    Public IdGuiaReg As Integer
    Public NumDocGuiaReg As Integer
    Public DocumentoReferencia As String
    Public CodSunatReferencia As String
    Public DesDocReferencia As String
    Public GuiaPreexistente As Boolean
    Public enProceso As Boolean

    Private Sub frmGuiaRemision_GuiaRemisionElectronica_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oGuiaRemisionService.Close()
            oUsuarioClienteService.Close()
            oGuiaRemisionDigitalService.Close()
        Catch ex As TimeoutException
            oMaestroService.Close()
            oGuiaRemisionService.Close()
            oUsuarioClienteService.Close()
            oGuiaRemisionDigitalService.Close()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oGuiaRemisionService.Abort()
            oUsuarioClienteService.Abort()
            oGuiaRemisionDigitalService.Abort()
            oUsuarioClienteService.Abort()
        End Try
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub frmGuiaRemision_GuiaRemisionElectronica_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub frmGuiaRemision_GuiaRemisionElectronica_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim dtReporte As New DataTable
            Dim dtImprimirDigital As New DataTable

            If enProceso Then
                ListarArchivos()

                dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuiaReg).Tables(0)
                DataGridView1.DataSource = dtReporte
                GridEX1.DataSource = dtReporte
                IdCliente = GridEX1.CurrentRow.Cells("IdCliente").Text
            Else

                'Dim dtReporte As New DataTable
                'Dim dtImprimirDigital As New DataTable

                dtReporte = oGuiaRemisionService.ImprimirDigital(IdGu).Tables(0)
                DataGridView1.DataSource = dtReporte
                GridEX1.DataSource = dtReporte

                If opcionimp = "Observacion" Then

                    IdGuia = GridEX1.CurrentRow.Cells("IdGuia").Text
                    IdCliente = GridEX1.CurrentRow.Cells("IdCliente").Text
                    FecDoc = GridEX1.CurrentRow.Cells("FecDoc").Text
                    DesEmp = GridEX1.CurrentRow.Cells("DesEmp").Text
                    DirEmp = GridEX1.CurrentRow.Cells("DirEmp").Text
                    TelEmp = GridEX1.CurrentRow.Cells("TelEmp").Text
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
                    RucCli = GridEX1.CurrentRow.Cells("RucCli").Text
                    DniCli = GridEX1.CurrentRow.Cells("DniCli").Text
                    DesCli = GridEX1.CurrentRow.Cells("DesCli").Text
                    unitCode = GridEX1.CurrentRow.Cells("UnitCode").Text
                    CanMer = "1"
                    DesMer1 = ""
                    PreMer = 0
                    DscMer = 0
                    TotalFila = 0
                    CodMot = GridEX1.CurrentRow.Cells("CodMot").Text
                    DesMot = GridEX1.CurrentRow.Cells("DesMot").Text
                    TotBruto = 0
                    TotDscto = 0
                    TotFlete = 0
                    TotEmbarque = 0
                    TotVenta = 0
                    TotGasto = 0
                    TotGasto = 0
                    TotIgv = 0
                    TotNeto = 0
                    CodMon = GridEX1.CurrentRow.Cells("CodMon").Text
                    DesMon = GridEX1.CurrentRow.Cells("DesMon").Text
                    AbrMon = GridEX1.CurrentRow.Cells("AbrMon").Text
                    Item = 1
                    CodMer = "-"
                    Observacion = GridEX1.CurrentRow.Cells("Observacion").Text
                    NumOrden = GridEX1.CurrentRow.Cells("NumOrden").Text
                    NumJob = GridEX1.CurrentRow.Cells("NumJob").Text
                    Igv = GridEX1.CurrentRow.Cells("Igv").Text
                    DesPag = GridEX1.CurrentRow.Cells("DesPag").Text
                    DireccionFiscal = GridEX1.CurrentRow.Cells("DireccionFiscal").Text
                    Ubigeo = GridEX1.CurrentRow.Cells("Ubigeo").Text
                    CodUbigeoRec = GridEX1.CurrentRow.Cells("CodUbigeoRec").Text
                    NomDistRec = GridEX1.CurrentRow.Cells("NomDistRec").Text
                    NomProvRec = GridEX1.CurrentRow.Cells("NomProvRec").Text
                    NomDptoRec = GridEX1.CurrentRow.Cells("NomDptoRec").Text
                    CodSerie = GridEX1.CurrentRow.Cells("CodSerie").Text
                    NumDoc = GridEX1.CurrentRow.Cells("NumDoc").Text
                    CodTraslado = GridEX1.CurrentRow.Cells("CodTraslado").Text
                    PtoPartida = GridEX1.CurrentRow.Cells("PtoPartida").Text
                    PtoLlegada = GridEX1.CurrentRow.Cells("PtoLlegada").Text
                    CodModo = GridEX1.CurrentRow.Cells("CodModo").Text
                    FecTraslado = GridEX1.CurrentRow.Cells("FecTraslado").Text
                    CodUbigeoLlegada = GridEX1.CurrentRow.Cells("CodUbigeoLlegada").Text

                    'Transportista
                    Empresa = GridEX1.CurrentRow.Cells("Empresa").Text
                    Direccion = GridEX1.CurrentRow.Cells("Direccion").Text
                    Ruc = GridEX1.CurrentRow.Cells("Ruc").Text
                    Vehiculo = GridEX1.CurrentRow.Cells("Vehiculo").Text
                    Placa = GridEX1.CurrentRow.Cells("Placa").Text
                    Chofer = GridEX1.CurrentRow.Cells("Chofer").Text
                    Licencia = GridEX1.CurrentRow.Cells("Licencia").Text
                    ConIns = GridEX1.CurrentRow.Cells("ConIns").Text
                    CodDocChofer = GridEX1.CurrentRow.Cells("CodDocChofer").Text
                    NumDocChofer = GridEX1.CurrentRow.Cells("NumDocChofer").Text

                    CodUniMed = GridEX1.CurrentRow.Cells("CodUniMedPeso").Text 'GridEX1.CurrentRow.Cells("CodUniMed").Text
                    PesoBruto = GridEX1.CurrentRow.Cells("PesoBruto").Text
                    CodUniMedPeso = GridEX1.CurrentRow.Cells("CodUniMedPeso").Text
                    NumeroBultos = GridEX1.CurrentRow.Cells("NumeroBultos").Text

                Else    'Tipos Detlaldo y Resumido

                    IdGuia = GridEX1.CurrentRow.Cells("IdGuia").Text
                    IdCliente = GridEX1.CurrentRow.Cells("IdCliente").Text
                    FecDoc = GridEX1.CurrentRow.Cells("FecDoc").Text
                    DesEmp = GridEX1.CurrentRow.Cells("DesEmp").Text
                    DirEmp = GridEX1.CurrentRow.Cells("DirEmp").Text
                    TelEmp = GridEX1.CurrentRow.Cells("TelEmp").Text
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
                    RucCli = GridEX1.CurrentRow.Cells("RucCli").Text
                    DniCli = GridEX1.CurrentRow.Cells("DniCli").Text
                    DesCli = GridEX1.CurrentRow.Cells("DesCli").Text
                    unitCode = GridEX1.CurrentRow.Cells("UnitCode").Text
                    CanMer = GridEX1.CurrentRow.Cells("CanMer").Text
                    DesMer1 = GridEX1.CurrentRow.Cells("DesMer1").Text
                    PreMer = GridEX1.CurrentRow.Cells("PreMer").Text
                    DscMer = GridEX1.CurrentRow.Cells("DscMer").Text
                    TotalFila = GridEX1.CurrentRow.Cells("TotalFila").Text
                    CodMot = GridEX1.CurrentRow.Cells("CodMot").Text
                    DesMot = GridEX1.CurrentRow.Cells("DesMot").Text
                    TotBruto = GridEX1.CurrentRow.Cells("TotBruto").Text
                    TotDscto = GridEX1.CurrentRow.Cells("TotDscto").Text
                    TotFlete = GridEX1.CurrentRow.Cells("TotFlete").Text
                    TotEmbarque = GridEX1.CurrentRow.Cells("TotEmbarque").Text
                    TotVenta = GridEX1.CurrentRow.Cells("TotVenta").Text
                    TotGasto = GridEX1.CurrentRow.Cells("TotGasto").Text
                    TotIgv = GridEX1.CurrentRow.Cells("TotIgv").Text
                    TotNeto = GridEX1.CurrentRow.Cells("TotNeto").Text
                    CodMon = GridEX1.CurrentRow.Cells("CodMon").Text
                    DesMon = GridEX1.CurrentRow.Cells("DesMon").Text
                    AbrMon = GridEX1.CurrentRow.Cells("AbrMon").Text
                    Item = GridEX1.CurrentRow.Cells("Item").Text
                    CodMer = GridEX1.CurrentRow.Cells("CodMer").Text
                    Observacion = GridEX1.CurrentRow.Cells("Observacion").Text
                    NumOrden = GridEX1.CurrentRow.Cells("NumOrden").Text
                    NumJob = GridEX1.CurrentRow.Cells("NumJob").Text
                    Igv = GridEX1.CurrentRow.Cells("Igv").Text
                    DesPag = GridEX1.CurrentRow.Cells("DesPag").Text
                    DireccionFiscal = GridEX1.CurrentRow.Cells("DireccionFiscal").Text
                    Ubigeo = GridEX1.CurrentRow.Cells("Ubigeo").Text
                    CodUbigeoRec = GridEX1.CurrentRow.Cells("CodUbigeoRec").Text
                    NomDistRec = GridEX1.CurrentRow.Cells("NomDistRec").Text
                    NomProvRec = GridEX1.CurrentRow.Cells("NomProvRec").Text
                    NomDptoRec = GridEX1.CurrentRow.Cells("NomDptoRec").Text
                    CodSerie = GridEX1.CurrentRow.Cells("CodSerie").Text
                    NumDoc = GridEX1.CurrentRow.Cells("NumDoc").Text
                    CodTraslado = GridEX1.CurrentRow.Cells("CodTraslado").Text
                    PtoPartida = GridEX1.CurrentRow.Cells("PtoPartida").Text
                    PtoLlegada = GridEX1.CurrentRow.Cells("PtoLlegada").Text
                    CodModo = GridEX1.CurrentRow.Cells("CodModo").Text
                    FecTraslado = GridEX1.CurrentRow.Cells("FecTraslado").Text
                    CodUbigeoLlegada = GridEX1.CurrentRow.Cells("CodUbigeoLlegada").Text

                    'Transportista
                    Empresa = GridEX1.CurrentRow.Cells("Empresa").Text
                    Direccion = GridEX1.CurrentRow.Cells("Direccion").Text
                    Ruc = GridEX1.CurrentRow.Cells("Ruc").Text
                    Vehiculo = GridEX1.CurrentRow.Cells("Vehiculo").Text
                    Placa = GridEX1.CurrentRow.Cells("Placa").Text
                    Chofer = GridEX1.CurrentRow.Cells("Chofer").Text
                    Licencia = GridEX1.CurrentRow.Cells("Licencia").Text
                    ConIns = GridEX1.CurrentRow.Cells("ConIns").Text
                    CodDocChofer = GridEX1.CurrentRow.Cells("CodDocChofer").Text
                    NumDocChofer = GridEX1.CurrentRow.Cells("NumDocChofer").Text

                    CodUniMed = GridEX1.CurrentRow.Cells("CodUniMedPeso").Text 'GridEX1.CurrentRow.Cells("CodUniMed").Text
                    PesoBruto = GridEX1.CurrentRow.Cells("PesoBruto").Text
                    CodUniMedPeso = GridEX1.CurrentRow.Cells("CodUniMedPeso").Text
                    NumeroBultos = GridEX1.CurrentRow.Cells("NumeroBultos").Text


                End If

                'TotNetoLetras = oTesoreriaService.ConvierteNumLetraConta(GridEX1.CurrentRow.Cells("LegalMonetaryTotal").Text)

                '-------------------------------------------
                CrearCarpeta()
                If opcionimp = "DetalladoCod" Then
                    'CrearXMLSerializadoDet()
                    CrearXmlDetalle21()
                ElseIf opcionimp = "DetalladoNoCod" Then
                    'CrearXMLSerializadoDet()
                    CrearXmlDetalle21()
                ElseIf opcionimp = "Resumido" Then
                    'CrearXMLSerializadoRes()
                    CrearXmlResumen21()
                ElseIf opcionimp = "Observacion" Then
                    'CrearXMLSerializadoObs()
                    CrearXMLObservacion21()
                End If

            End If

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
            If Not Directory.Exists("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento) Then
                Directory.CreateDirectory("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear la carpeta")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try
    End Sub


    Private Sub CrearXMLSerializadoDet()
        Try
            Dim xmlFilename As String = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\" & Session.sRucEmp & "-09-" & Documento & ".xml"
            'Dim xmlFilename As String = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\20100020441-09-" & Documento & ".xml"
            'Dim xmlFilename As String = "D:\Documentos_Electronicos\Facturas_Electronicas\" & GridEX1.CurrentRow.Cells("NumDoc").Text & "\20100020441-01-" & "FF11-119021" & ".xml"
            'UblLarsen.Ubl2.UblBaseDocumentType.GlbCustomizationID = "1.0"

            '================================================================================================================================= Inicio Codigo destinatario
            Dim orderReference As OrderReferenceType() = Nothing

            If GuiaPreexistente Then

                orderReference = New OrderReferenceType(1) {}
                orderReference(0) = New OrderReferenceType() With {
                    .ID = DocumentoReferencia, '"T001-16",
                    .OrderTypeCode = New CodeType() With {
                        .name = DesDocReferencia, '"Guia de Remisión",
                        .Value = CodSunatReferencia '"09"
                }
                }

            End If

            Dim destinatario As CustomerPartyType() = New CustomerPartyType(1) {}
            destinatario(0) = New CustomerPartyType() With {
               .CustomerAssignedAccountID = New IdentifierType() With {
                    .schemeID = TipoIdentidad,
                    .Value = RucCli
               },
               .Party = New PartyType() With {
                    .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With {
                    .RegistrationName = DesCli
                    }}
               }
            }

            'Dim tercero As SupplierPartyType() = New SupplierPartyType(1) {}
            'tercero(0) = New SupplierPartyType() With {
            '   .CustomerAssignedAccountID = New IdentifierType() With {
            '        .schemeID = TipoIdentidad,
            '        .Value = RucCli
            '   },
            '   .Party = New PartyType() With {
            '        .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With {
            '        .RegistrationName = DesCli
            '        }}
            '   }
            '}

            'Dim tercero As SupplierPartyType() = New SupplierPartyType(1) {}
            'tercero(0) = New SupplierPartyType() With {
            '   .CustomerAssignedAccountID = New IdentifierType() With {
            '        .schemeID = TipoIdentidad,
            '        .Value = RucCli
            '   },
            '   .Party = New PartyType() With {
            '        .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With {
            '        .RegistrationName = DesCli
            '        }}
            '   }
            '}

            '=========================================================================
            '.ID = "1",

            '.Information = "VENTA",
            '    .GrossWeightMeasure = New MeasureType() With {
            '    .unitCode = "KGM",
            '    .Value = 1000
            '    },
            '    .TotalTransportHandlingUnitQuantity = 1,
            '    .SplitConsignmentIndicator = True,

            Dim datosenvio As ShipmentType() = Nothing

            If CodTraslado = "08" Then

                If Empresa = "" Or IsDBNull(Empresa) Then

                    datosenvio = New ShipmentType(1) {}
                    datosenvio(0) = New ShipmentType() With {
                    .ID = "1",
                    .HandlingCode = CodTraslado,
                    .Information = DesMot,
                    .GrossWeightMeasure = New MeasureType() With {
                    .unitCode = CodUniMedPeso,
                    .Value = PesoBruto
                    },
                    .TotalTransportHandlingUnitQuantity = NumeroBultos,
                    .ShipmentStage = New ShipmentStageType() {New ShipmentStageType() With {
                    .TransportModeCode = CodModo,
                    .TransitPeriod = New PeriodType() With {
                    .StartDate = FecTraslado
                    }
                    }
                    },
                    .Delivery = New DeliveryType() With {
                        .DeliveryAddress = New AddressType() With {
                            .ID = CodUbigeoLlegada,
                            .StreetName = PtoLlegada
                        }
                    },
                    .OriginAddress = New AddressType() With {
                        .ID = CodUbigeo,
                        .StreetName = PtoPartida
                    }
                }
                Else

                    datosenvio = New ShipmentType(1) {}
                    datosenvio(0) = New ShipmentType() With {
                    .ID = "1",
                    .HandlingCode = CodTraslado,
                    .Information = DesMot,
                    .GrossWeightMeasure = New MeasureType() With {
                    .unitCode = CodUniMedPeso,
                    .Value = PesoBruto
                    },
                    .TotalTransportHandlingUnitQuantity = NumeroBultos,
                    .ShipmentStage = New ShipmentStageType() {New ShipmentStageType() With {
                    .TransportModeCode = CodModo,
                    .TransitPeriod = New PeriodType() With {
                    .StartDate = FecTraslado
                    },
                    .CarrierParty = New PartyType() {New PartyType() With {
                    .PartyIdentification = New PartyIdentificationType() {New PartyIdentificationType() With {
                    .ID = New IdentifierType() With {
                     .schemeID = "6",
                     .Value = Ruc   'ruc transporte
                    }
                    }
                    },
                    .PartyName = New PartyNameType() {New PartyNameType() With {
                    .Name = Empresa
                    }
                    }
                    }
                    },
                    .TransportMeans = New TransportMeansType() With {
                        .RoadTransport = New RoadTransportType() With {
                    .LicensePlateID = Placa
                    }
                    },
                    .DriverPerson = New DriverPersonType() With {
                    .ID = New IdentifierType() With {
                    .schemeID = CodDocChofer,
                    .Value = NumDocChofer
                    }
                    }
                    }
                    },
                    .Delivery = New DeliveryType() With {
                        .DeliveryAddress = New AddressType() With {
                            .ID = CodUbigeoRec,
                            .StreetName = DireccionFiscal
                        }
                    },
                    .OriginAddress = New AddressType() With {
                        .ID = CodUbigeo,
                        .StreetName = PtoPartida
                    }
                }


                End If

            Else

                If Empresa = "" Or IsDBNull(Empresa) Then

                    datosenvio = New ShipmentType(1) {}
                    datosenvio(0) = New ShipmentType() With {
                    .ID = "1",
                    .HandlingCode = CodTraslado,
                    .Information = DesMot,
                    .GrossWeightMeasure = New MeasureType() With {
                    .unitCode = CodUniMedPeso,
                    .Value = PesoBruto
                    },
                    .ShipmentStage = New ShipmentStageType() {New ShipmentStageType() With {
                    .TransportModeCode = CodModo,
                    .TransitPeriod = New PeriodType() With {
                    .StartDate = FecTraslado
                    }
                    }
                    },
                    .Delivery = New DeliveryType() With {
                        .DeliveryAddress = New AddressType() With {
                            .ID = CodUbigeoLlegada,
                            .StreetName = PtoLlegada
                        }
                    },
                    .OriginAddress = New AddressType() With {
                        .ID = CodUbigeo,
                        .StreetName = PtoPartida
                    }
                }
                Else

                    datosenvio = New ShipmentType(1) {}
                    datosenvio(0) = New ShipmentType() With {
                    .ID = "1",
                    .HandlingCode = CodTraslado,
                    .Information = DesMot,
                    .GrossWeightMeasure = New MeasureType() With {
                    .unitCode = CodUniMedPeso,
                    .Value = PesoBruto
                    },
                    .ShipmentStage = New ShipmentStageType() {New ShipmentStageType() With {
                    .TransportModeCode = CodModo,
                    .TransitPeriod = New PeriodType() With {
                    .StartDate = FecTraslado
                    },
                    .CarrierParty = New PartyType() {New PartyType() With {
                    .PartyIdentification = New PartyIdentificationType() {New PartyIdentificationType() With {
                    .ID = New IdentifierType() With {
                     .schemeID = "6",
                     .Value = Ruc   'ruc transporte
                    }
                    }
                    },
                    .PartyName = New PartyNameType() {New PartyNameType() With {
                    .Name = Empresa
                    }
                    }
                    }
                    },
                    .TransportMeans = New TransportMeansType() With {
                        .RoadTransport = New RoadTransportType() With {
                    .LicensePlateID = Placa
                    }
                    },
                    .DriverPerson = New DriverPersonType() With {
                    .ID = New IdentifierType() With {
                    .schemeID = CodDocChofer,
                    .Value = NumDocChofer
                    }
                    }
                    }
                    },
                    .Delivery = New DeliveryType() With {
                        .DeliveryAddress = New AddressType() With {
                            .ID = CodUbigeoRec,
                            .StreetName = DireccionFiscal
                        }
                    },
                    .OriginAddress = New AddressType() With {
                        .ID = CodUbigeo,
                        .StreetName = PtoPartida
                    }
                }


                End If

            End If


            '.ID = CStr(row.Cells("Item").Value),
            '=========================================================================
            Dim line As DespatchLineType() = Nothing

            Dim row As Janus.Windows.GridEX.GridEXRow

            If GridEX1.RowCount > 0 Then
                Dim cantline As Integer = GridEX1.RowCount
                line = New DespatchLineType(cantline) {}

                For j = 0 To GridEX1.RowCount - 1
                    Me.GridEX1.Row = j
                    row = Me.GridEX1.GetRow()

                    'If InstructionID <> "05" Then
                    'If CodMot = "1" Then

                    line(j) = New DespatchLineType() With {
                               .ID = CStr(row.Cells("Item").Value),
                               .DeliveredQuantity = New QuantityType() With {
                                   .unitCode = CStr(row.Cells("unitCode").Value),
                                   .Value = CDec(row.Cells("CanMer").Value)
                               },
                               .OrderLineReference = New OrderLineReferenceType() {New OrderLineReferenceType() With {
                               .LineID = CStr(row.Cells("Item").Value)
                                }
                                },
                                .Item = New ItemType() With {
                                    .Description = New TextType() {New TextType() With {
                                        .Value = CStr(row.Cells("DesMer1").Value)}},
                                    .SellersItemIdentification = New ItemIdentificationType() With {.ID = CStr(row.Cells("CodMer").Value)}
                                    }
                                }
                Next

                'backup cambios en guias 27/12/22 Description x Name
                'For j = 0 To GridEX1.RowCount - 1
                '    Me.GridEX1.Row = j
                '    row = Me.GridEX1.GetRow()

                '    'If InstructionID <> "05" Then
                '    'If CodMot = "1" Then

                '    line(j) = New DespatchLineType() With {
                '               .ID = CStr(row.Cells("Item").Value),
                '               .DeliveredQuantity = New QuantityType() With {
                '                   .unitCode = CStr(row.Cells("unitCode").Value),
                '                   .Value = CDec(row.Cells("CanMer").Value)
                '               },
                '               .OrderLineReference = New OrderLineReferenceType() {New OrderLineReferenceType() With {
                '               .LineID = CStr(row.Cells("Item").Value)
                '                }
                '                },
                '                .Item = New ItemType() With {
                '                    .Name = CStr(row.Cells("DesMer1").Value),
                '                    .SellersItemIdentification = New ItemIdentificationType() With {.ID = CStr(row.Cells("CodMer").Value)}
                '                    }
                '                }
                'Next


            End If
            'String File = @"D:\Certificado\20100020441-09-T001-1.xml";
            Dim notas As String = Observacion ' "ENTREGAR : AV ESTADO DE ISRAEL S/N URB. EL ALAMO COMAS REF. EX  AERODROMO DE COLLIQUE PUERTA 4 COLOR PLOMA.";

            If GuiaPreexistente Then
                FacturacionElectronica.GenerarDespatchAdvice(xmlFilename, Session.sRucEmp, Session.sDesEmp, Documento, DateTime.Today, "09", orderReference, Nothing, destinatario(0), Nothing, notas, datosenvio(0), line)
            Else
                FacturacionElectronica.GenerarDespatchAdvice(xmlFilename, Session.sRucEmp, Session.sDesEmp, Documento, DateTime.Today, "09", Nothing, Nothing, destinatario(0), Nothing, notas, datosenvio(0), line)
                'FacturacionElectronica.GenerarDespatchAdvice(xmlFilename, Documento, DateTime.Today, "09", Nothing, Nothing, destinatario(0), Nothing, Nothing, datosenvio(0), line)
            End If

            FirmadoDigital()

            '==============================================================================================================================Fin Codigo GenerarXML
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al firmar el documento")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try
    End Sub

    Private Sub CrearXMLSerializadoRes()

        Try
            Dim xmlFilename As String = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\" & Session.sRucEmp & "-09-" & Documento & ".xml"
            'Dim xmlFilename As String = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\20100020441-09-" & Documento & ".xml"
            'Dim xmlFilename As String = "D:\Documentos_Electronicos\Facturas_Electronicas\" & GridEX1.CurrentRow.Cells("NumDoc").Text & "\20100020441-01-" & "FF11-119021" & ".xml"
            'UblLarsen.Ubl2.UblBaseDocumentType.GlbCustomizationID = "1.0"

            '================================================================================================================================= Inicio Codigo destinatario

            Dim orderReference As OrderReferenceType() = Nothing

            If GuiaPreexistente Then
                orderReference = New OrderReferenceType(1) {}
                orderReference(0) = New OrderReferenceType() With {
                    .ID = DocumentoReferencia, '"T001-16",
                    .OrderTypeCode = New CodeType() With {
                        .name = DesDocReferencia, '"Guia de Remisión",
                        .Value = CodSunatReferencia '"09"
                }
            }

            End If

            Dim destinatario As CustomerPartyType() = New CustomerPartyType(1) {}
            destinatario(0) = New CustomerPartyType() With {
               .CustomerAssignedAccountID = New IdentifierType() With {
                    .schemeID = TipoIdentidad,
                    .Value = RucCli
               },
               .Party = New PartyType() With {
                    .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With {
                    .RegistrationName = DesCli
                    }}
               }
            }

            Dim datosenvio As ShipmentType() = Nothing

            If CodTraslado = "08" Then

                If Empresa = "" Or IsDBNull(Empresa) Then

                    datosenvio = New ShipmentType(1) {}
                    datosenvio(0) = New ShipmentType() With {
                    .ID = "1",
                    .HandlingCode = CodTraslado,
                    .Information = DesMot,
                    .GrossWeightMeasure = New MeasureType() With {
                    .unitCode = CodUniMedPeso,
                    .Value = PesoBruto
                    },
                    .TotalTransportHandlingUnitQuantity = NumeroBultos,
                    .ShipmentStage = New ShipmentStageType() {New ShipmentStageType() With {
                    .TransportModeCode = CodModo,
                    .TransitPeriod = New PeriodType() With {
                    .StartDate = FecTraslado
                    }
                    }
                    },
                    .Delivery = New DeliveryType() With {
                        .DeliveryAddress = New AddressType() With {
                            .ID = CodUbigeoLlegada,
                            .StreetName = PtoLlegada
                        }
                    },
                    .OriginAddress = New AddressType() With {
                        .ID = CodUbigeo,
                        .StreetName = PtoPartida
                    }
                }
                Else

                    datosenvio = New ShipmentType(1) {}
                    datosenvio(0) = New ShipmentType() With {
                    .ID = "1",
                    .HandlingCode = CodTraslado,
                    .Information = DesMot,
                    .GrossWeightMeasure = New MeasureType() With {
                    .unitCode = CodUniMedPeso,
                    .Value = PesoBruto
                    },
                    .TotalTransportHandlingUnitQuantity = NumeroBultos,
                    .ShipmentStage = New ShipmentStageType() {New ShipmentStageType() With {
                    .TransportModeCode = CodModo,
                    .TransitPeriod = New PeriodType() With {
                    .StartDate = FecTraslado
                    },
                    .CarrierParty = New PartyType() {New PartyType() With {
                    .PartyIdentification = New PartyIdentificationType() {New PartyIdentificationType() With {
                    .ID = New IdentifierType() With {
                     .schemeID = "6",
                     .Value = Ruc   'ruc transporte
                    }
                    }
                    },
                    .PartyName = New PartyNameType() {New PartyNameType() With {
                    .Name = Empresa
                    }
                    }
                    }
                    },
                    .TransportMeans = New TransportMeansType() With {
                        .RoadTransport = New RoadTransportType() With {
                    .LicensePlateID = Placa
                    }
                    },
                    .DriverPerson = New DriverPersonType() With {
                    .ID = New IdentifierType() With {
                    .schemeID = CodDocChofer,
                    .Value = NumDocChofer
                    }
                    }
                    }
                    },
                    .Delivery = New DeliveryType() With {
                        .DeliveryAddress = New AddressType() With {
                            .ID = CodUbigeoRec,
                            .StreetName = DireccionFiscal
                        }
                    },
                    .OriginAddress = New AddressType() With {
                        .ID = CodUbigeo,
                        .StreetName = PtoPartida
                    }
                }


                End If

            Else

                If Empresa = "" Or IsDBNull(Empresa) Then

                    datosenvio = New ShipmentType(1) {}
                    datosenvio(0) = New ShipmentType() With {
                    .ID = "1",
                    .HandlingCode = CodTraslado,
                    .Information = DesMot,
                    .GrossWeightMeasure = New MeasureType() With {
                    .unitCode = CodUniMedPeso,
                    .Value = PesoBruto
                    },
                    .ShipmentStage = New ShipmentStageType() {New ShipmentStageType() With {
                    .TransportModeCode = CodModo,
                    .TransitPeriod = New PeriodType() With {
                    .StartDate = FecTraslado
                    }
                    }
                    },
                    .Delivery = New DeliveryType() With {
                        .DeliveryAddress = New AddressType() With {
                            .ID = CodUbigeoLlegada,
                            .StreetName = PtoLlegada
                        }
                    },
                    .OriginAddress = New AddressType() With {
                        .ID = CodUbigeo,
                        .StreetName = PtoPartida
                    }
                }
                Else

                    datosenvio = New ShipmentType(1) {}
                    datosenvio(0) = New ShipmentType() With {
                    .ID = "1",
                    .HandlingCode = CodTraslado,
                    .Information = DesMot,
                    .GrossWeightMeasure = New MeasureType() With {
                    .unitCode = CodUniMedPeso,
                    .Value = PesoBruto
                    },
                    .ShipmentStage = New ShipmentStageType() {New ShipmentStageType() With {
                    .TransportModeCode = CodModo,
                    .TransitPeriod = New PeriodType() With {
                    .StartDate = FecTraslado
                    },
                    .CarrierParty = New PartyType() {New PartyType() With {
                    .PartyIdentification = New PartyIdentificationType() {New PartyIdentificationType() With {
                    .ID = New IdentifierType() With {
                     .schemeID = "6",
                     .Value = Ruc   'ruc transporte
                    }
                    }
                    },
                    .PartyName = New PartyNameType() {New PartyNameType() With {
                    .Name = Empresa
                    }
                    }
                    }
                    },
                    .TransportMeans = New TransportMeansType() With {
                        .RoadTransport = New RoadTransportType() With {
                    .LicensePlateID = Placa
                    }
                    },
                    .DriverPerson = New DriverPersonType() With {
                    .ID = New IdentifierType() With {
                    .schemeID = CodDocChofer,
                    .Value = NumDocChofer
                    }
                    }
                    }
                    },
                    .Delivery = New DeliveryType() With {
                        .DeliveryAddress = New AddressType() With {
                            .ID = CodUbigeoRec,
                            .StreetName = DireccionFiscal
                        }
                    },
                    .OriginAddress = New AddressType() With {
                        .ID = CodUbigeo,
                        .StreetName = PtoPartida
                    }
                }


                End If

            End If



            '.ID = CStr(row.Cells("Item").Value),
            '=========================================================================
            Dim line As DespatchLineType() = Nothing

            Dim row As Janus.Windows.GridEX.GridEXRow

            If GridEX1.RowCount > 0 Then
                Dim cantline As Integer = GridEX1.RowCount
                line = New DespatchLineType(cantline) {}

                For j = 0 To 0 'GridEX1.RowCount - 1
                    Me.GridEX1.Row = j
                    row = Me.GridEX1.GetRow()

                    'If InstructionID <> "05" Then
                    'If CodMot = "1" Then

                    line(j) = New DespatchLineType() With {
                               .ID = CStr(row.Cells("Item").Value),
                               .DeliveredQuantity = New QuantityType() With {
                                   .unitCode = CStr(row.Cells("unitCode").Value),
                                   .Value = CDec(row.Cells("CanMer").Value)
                               },
                               .OrderLineReference = New OrderLineReferenceType() {New OrderLineReferenceType() With {
                               .LineID = CStr(row.Cells("Item").Value)
                                }
                                },
                                .Item = New ItemType() With {
                                    .Description = New TextType() {New TextType() With {
                                        .Value = CStr(row.Cells("Observacion").Value)}},
                                    .SellersItemIdentification = New ItemIdentificationType() With {.ID = CStr("-")}
                                    }
                                }
                Next

            End If


            Dim notas As String = Observacion ' "ENTREGAR : AV ESTADO DE ISRAEL S/N URB. EL ALAMO COMAS REF. EX  AERODROMO DE COLLIQUE PUERTA 4 COLOR PLOMA.";

            If GuiaPreexistente Then

                FacturacionElectronica.GenerarDespatchAdvice(xmlFilename, Session.sRucEmp, Session.sDesEmp, Documento, DateTime.Today, "09", orderReference, Nothing, destinatario(0), Nothing, notas, datosenvio(0), line)
            Else
                FacturacionElectronica.GenerarDespatchAdvice(xmlFilename, Session.sRucEmp, Session.sDesEmp, Documento, DateTime.Today, "09", Nothing, Nothing, destinatario(0), Nothing, notas, datosenvio(0), line)
                'FacturacionElectronica.GenerarDespatchAdvice(xmlFilename, Documento, DateTime.Today, "09", Nothing, Nothing, destinatario(0), tercero(0), notas, datosenvio(0), line)

            End If
            FirmadoDigital()

            '==============================================================================================================================Fin Codigo GenerarXML
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al firmar el documento")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try

    End Sub

    Private Sub CrearXMLSerializadoObs()

        Try
            Dim xmlFilename As String = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\" & Session.sRucEmp & "-09-" & Documento & ".xml"
            'Dim xmlFilename As String = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\20100020441-09-" & Documento & ".xml"
            'Dim xmlFilename As String = "D:\Documentos_Electronicos\Facturas_Electronicas\" & GridEX1.CurrentRow.Cells("NumDoc").Text & "\20100020441-01-" & "FF11-119021" & ".xml"
            'UblLarsen.Ubl2.UblBaseDocumentType.GlbCustomizationID = "1.0"

            '================================================================================================================================= Inicio Codigo destinatario

            Dim orderReference As OrderReferenceType() = Nothing

            If GuiaPreexistente Then
                orderReference = New OrderReferenceType(1) {}
                orderReference(0) = New OrderReferenceType() With {
                    .ID = DocumentoReferencia, '"T001-16",
                    .OrderTypeCode = New CodeType() With {
                        .name = DesDocReferencia, '"Guia de Remisión",
                        .Value = CodSunatReferencia '"09"
                }
            }

            End If

            Dim destinatario As CustomerPartyType() = New CustomerPartyType(1) {}
            destinatario(0) = New CustomerPartyType() With {
               .CustomerAssignedAccountID = New IdentifierType() With {
                    .schemeID = TipoIdentidad,
                    .Value = RucCli
               },
               .Party = New PartyType() With {
                    .PartyLegalEntity = New PartyLegalEntityType() {New PartyLegalEntityType() With {
                    .RegistrationName = DesCli
                    }}
               }
            }

            Dim datosenvio As ShipmentType() = Nothing

            If CodTraslado = "08" Then

                If Empresa = "" Or IsDBNull(Empresa) Then

                    datosenvio = New ShipmentType(1) {}
                    datosenvio(0) = New ShipmentType() With {
                    .ID = "1",
                    .HandlingCode = CodTraslado,
                    .Information = DesMot,
                    .GrossWeightMeasure = New MeasureType() With {
                    .unitCode = CodUniMedPeso,
                    .Value = PesoBruto
                    },
                    .TotalTransportHandlingUnitQuantity = NumeroBultos,
                    .ShipmentStage = New ShipmentStageType() {New ShipmentStageType() With {
                    .TransportModeCode = CodModo,
                    .TransitPeriod = New PeriodType() With {
                    .StartDate = FecTraslado
                    }
                    }
                    },
                    .Delivery = New DeliveryType() With {
                        .DeliveryAddress = New AddressType() With {
                            .ID = CodUbigeoLlegada,
                            .StreetName = PtoLlegada
                        }
                    },
                    .OriginAddress = New AddressType() With {
                        .ID = CodUbigeo,
                        .StreetName = PtoPartida
                    }
                }
                Else

                    datosenvio = New ShipmentType(1) {}
                    datosenvio(0) = New ShipmentType() With {
                    .ID = "1",
                    .HandlingCode = CodTraslado,
                    .Information = DesMot,
                    .GrossWeightMeasure = New MeasureType() With {
                    .unitCode = CodUniMedPeso,
                    .Value = PesoBruto
                    },
                    .TotalTransportHandlingUnitQuantity = NumeroBultos,
                    .ShipmentStage = New ShipmentStageType() {New ShipmentStageType() With {
                    .TransportModeCode = CodModo,
                    .TransitPeriod = New PeriodType() With {
                    .StartDate = FecTraslado
                    },
                    .CarrierParty = New PartyType() {New PartyType() With {
                    .PartyIdentification = New PartyIdentificationType() {New PartyIdentificationType() With {
                    .ID = New IdentifierType() With {
                     .schemeID = "6",
                     .Value = Ruc   'ruc transporte
                    }
                    }
                    },
                    .PartyName = New PartyNameType() {New PartyNameType() With {
                    .Name = Empresa
                    }
                    }
                    }
                    },
                    .TransportMeans = New TransportMeansType() With {
                        .RoadTransport = New RoadTransportType() With {
                    .LicensePlateID = Placa
                    }
                    },
                    .DriverPerson = New DriverPersonType() With {
                    .ID = New IdentifierType() With {
                    .schemeID = CodDocChofer,
                    .Value = NumDocChofer
                    }
                    }
                    }
                    },
                    .Delivery = New DeliveryType() With {
                        .DeliveryAddress = New AddressType() With {
                            .ID = CodUbigeoRec,
                            .StreetName = DireccionFiscal
                        }
                    },
                    .OriginAddress = New AddressType() With {
                        .ID = CodUbigeo,
                        .StreetName = PtoPartida
                    }
                }


                End If

            Else

                If Empresa = "" Or IsDBNull(Empresa) Then

                    datosenvio = New ShipmentType(1) {}
                    datosenvio(0) = New ShipmentType() With {
                    .ID = "1",
                    .HandlingCode = CodTraslado,
                    .Information = DesMot,
                    .GrossWeightMeasure = New MeasureType() With {
                    .unitCode = CodUniMedPeso,
                    .Value = PesoBruto
                    },
                    .ShipmentStage = New ShipmentStageType() {New ShipmentStageType() With {
                    .TransportModeCode = CodModo,
                    .TransitPeriod = New PeriodType() With {
                    .StartDate = FecTraslado
                    }
                    }
                    },
                    .Delivery = New DeliveryType() With {
                        .DeliveryAddress = New AddressType() With {
                            .ID = CodUbigeoLlegada,
                            .StreetName = PtoLlegada
                        }
                    },
                    .OriginAddress = New AddressType() With {
                        .ID = CodUbigeo,
                        .StreetName = PtoPartida
                    }
                }
                Else

                    datosenvio = New ShipmentType(1) {}
                    datosenvio(0) = New ShipmentType() With {
                    .ID = "1",
                    .HandlingCode = CodTraslado,
                    .Information = DesMot,
                    .GrossWeightMeasure = New MeasureType() With {
                    .unitCode = CodUniMedPeso,
                    .Value = PesoBruto
                    },
                    .ShipmentStage = New ShipmentStageType() {New ShipmentStageType() With {
                    .TransportModeCode = CodModo,
                    .TransitPeriod = New PeriodType() With {
                    .StartDate = FecTraslado
                    },
                    .CarrierParty = New PartyType() {New PartyType() With {
                    .PartyIdentification = New PartyIdentificationType() {New PartyIdentificationType() With {
                    .ID = New IdentifierType() With {
                     .schemeID = "6",
                     .Value = Ruc   'ruc transporte
                    }
                    }
                    },
                    .PartyName = New PartyNameType() {New PartyNameType() With {
                    .Name = Empresa
                    }
                    }
                    }
                    },
                    .TransportMeans = New TransportMeansType() With {
                        .RoadTransport = New RoadTransportType() With {
                    .LicensePlateID = Placa
                    }
                    },
                    .DriverPerson = New DriverPersonType() With {
                    .ID = New IdentifierType() With {
                    .schemeID = CodDocChofer,
                    .Value = NumDocChofer
                    }
                    }
                    }
                    },
                    .Delivery = New DeliveryType() With {
                        .DeliveryAddress = New AddressType() With {
                            .ID = CodUbigeoRec,
                            .StreetName = DireccionFiscal
                        }
                    },
                    .OriginAddress = New AddressType() With {
                        .ID = CodUbigeo,
                        .StreetName = PtoPartida
                    }
                }


                End If

            End If



            '.ID = CStr(row.Cells("Item").Value),
            '=========================================================================
            Dim line As DespatchLineType() = Nothing

            Dim row As Janus.Windows.GridEX.GridEXRow

            If GridEX1.RowCount > 0 Then
                Dim cantline As Integer = GridEX1.RowCount
                line = New DespatchLineType(cantline) {}

                For j = 0 To 0 'GridEX1.RowCount - 1
                    Me.GridEX1.Row = j
                    row = Me.GridEX1.GetRow()

                    'If InstructionID <> "05" Then
                    'If CodMot = "1" Then

                    line(j) = New DespatchLineType() With {
                               .ID = "1",
                               .DeliveredQuantity = New QuantityType() With {
                                   .unitCode = "NIU",
                                   .Value = 1
                               },
                               .OrderLineReference = New OrderLineReferenceType() {New OrderLineReferenceType() With {
                               .LineID = "1"
                                }
                                },
                                .Item = New ItemType() With {
                                    .Description = New TextType() {New TextType() With {
                                        .Value = CStr(row.Cells("Observacion").Value)}},
                                    .SellersItemIdentification = New ItemIdentificationType() With {.ID = CStr("-")}
                                    }
                                }
                Next

            End If


            Dim notas As String = Observacion ' "ENTREGAR : AV ESTADO DE ISRAEL S/N URB. EL ALAMO COMAS REF. EX  AERODROMO DE COLLIQUE PUERTA 4 COLOR PLOMA.";

            If GuiaPreexistente Then

                FacturacionElectronica.GenerarDespatchAdvice(xmlFilename, Session.sRucEmp, Session.sDesEmp, Documento, DateTime.Today, "09", orderReference, Nothing, destinatario(0), Nothing, notas, datosenvio(0), line)
            Else
                FacturacionElectronica.GenerarDespatchAdvice(xmlFilename, Session.sRucEmp, Session.sDesEmp, Documento, DateTime.Today, "09", Nothing, Nothing, destinatario(0), Nothing, notas, datosenvio(0), line)
                'FacturacionElectronica.GenerarDespatchAdvice(xmlFilename, Documento, DateTime.Today, "09", Nothing, Nothing, destinatario(0), tercero(0), notas, datosenvio(0), line)

            End If
            FirmadoDigital()

            '==============================================================================================================================Fin Codigo GenerarXML
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al firmar el documento")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try

    End Sub

    Private Sub FirmadoDigital()
        Try
            'Firmando xml 
            Dim ObjLib As New FirmarDocumento

            Dim direccion As String
            Dim firmado As Boolean
            direccion = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\" & Session.sRucEmp & "-09-" & Documento & ".xml"
            'direccion = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\20100020441-09-" & Documento & ".xml"
            'direccion = "D:\Documentos_Electronicos\Facturas_Electronicas\" & GridEX1.CurrentRow.Cells("NumDoc").Text & "\20100020441-01-" & "FF11-119021" & ".xml"

            Dim ruta As String = System.AppDomain.CurrentDomain.BaseDirectory & "Certificado\" & Session.sNombreCertificado
            'Dim ruta As String = System.AppDomain.CurrentDomain.BaseDirectory & "Certificado\CertificadoFacturacion.pfx"
            'firmado = ObjLib.SignXmlFile("20100020441", "D:\Documentos_Electronicos\xadesnettest.p12", "xadesnet", direccion)
            'activar -------------------------------------------------------------------------------------------------------------------------------------------------------------
            'firmado = ObjLib.SignXmlFile(Session.sRucEmp, 6, ruta, Session.sClaveCertificado, direccion)
            'firmado = ObjLib.SignXmlFile("20100020441", 6, ruta, "DdperU", direccion)

            firmado = FirmarDocumento21.SignXmlFile(Session.sRucEmp, 6, ruta, Session.sClaveCertificado, direccion)

            If firmado = True Then
                'MsgBox("Se genero el firmado", MsgBoxStyle.Information)

                Dim xmlDoc As New XmlDocument
                xmlDoc.Load("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\" & Session.sRucEmp & "-09-" & Documento & ".xml")
                'xmlDoc.Load("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\20100020441-09-" & Documento & ".xml")

                'Comentado para pruebas ====================================================================================
                Dim insertar As Boolean
                'Dim nombrexml As String = GridEX1.CurrentRow.Cells("NumDoc").Text & ".xml"     'Comentado para que en el evento de descargar se obtenga el numdoc sin el ".xml"
                Dim nombrexml As String = Session.sRucEmp & "-09-" & GridEX1.CurrentRow.Cells("Documento").Text '& ".xml"
                'Dim nombrexml As String = "20100020441-09-" & GridEX1.CurrentRow.Cells("Documento").Text '& ".xml"

                'insertar = oFacturaDigitalService.Insertar(IdFactura, nombrexml, xmlDoc.OuterXml, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                'If insertar = True Then
                Comprimir()
                'End If

                Dim resulenvio As Boolean = False
                Dim rutaenvio As String = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\"
                Dim file As String = ""
                file = Session.sRucEmp & "-09-" & Documento & ".zip"

                'Dim file As String = "20100020441-09-" & Documento & ".ZIP"

                'If Session.sCodEmp = "01" Then
                '    resulenvio = oComunicacionSunat.EnviarGuiaRemisionSunat(rutaenvio, file)
                'Else
                'file = Session.sRucEmp & "-09-" & Documento
                'EnviarSunat21.EnviarGuiaRemisionProduccion(Session.sRucEmp, Session.sUsuarioSunat, Session.sClaveSunat, rutaenvio, file)
                'resulenvio = True
                'resulenvio = False
                'End If




                '////////////GENERAR TOKEN///////////////
                Dim respuesta As New ConectarAPISUNAT.RespuestaToken()
                Dim userSOL As String = Session.sRucEmp & Session.sUsuarioSunat
                respuesta = ConectarAPISUNAT.GenerarTokenSunat(Session.sUrlApiSunat, Session.sIdApiSunat, Session.sClaveApiSunat, userSOL, Session.sClaveSunat)
                '////////////////////////////////////////

                '////////GENERAR ARCHIVO B64//////////////
                Dim direccionZip As String = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\" & Session.sRucEmp & "-09-" & Documento & ".zip"
                Dim arcGreZip As String = Convert.ToBase64String(System.IO.File.ReadAllBytes(direccionZip))
                '/////////////////////////////////////////

                '////////////GENERAR SHA///////////////
                Dim data As Byte() = System.IO.File.ReadAllBytes(direccionZip)
                Dim sha256 As SHA256
                sha256 = SHA256.Create()
                Dim checksum = sha256.ComputeHash(data)
                Dim hash = BitConverter.ToString(checksum).Replace("-", String.Empty).ToLower()
                '//////////////////////////////////////

                '/////////////ENVIAR A LA SUNAT//////////
                Dim fileEnvio = Session.sRucEmp & "-09-" & Documento
                Dim urlEnvio As String = "https://api-cpe.sunat.gob.pe/v1/contribuyente/gem/comprobantes/" + fileEnvio
                Dim respuestaEnvio As New ConectarAPISUNAT.RespuestaEnvioSunat()
                respuestaEnvio = ConectarAPISUNAT.EnviarSunat(file, arcGreZip, hash, urlEnvio, respuesta.access_token)
                Dim ticket As String = respuestaEnvio.numTicket
                '////////////////////////////////////////

                '/////////CONSULTAR EL NUMERO DE TICKET DEVUELTO DEL ENVIO///////////////
                Dim respuestaTicket As New ConectarAPISUNAT.ResponseConsultarGre()
                Dim url As String = "https://api-cpe.sunat.gob.pe/v1/contribuyente/gem/comprobantes/envios/" & ticket
                respuestaTicket = ConectarAPISUNAT.ObtenerCDR(file, url, respuesta.access_token, ticket)
                '////////////////////////////////////////////////////////////////////////



                'Dim ticket As String = "73618EB9-75D2-44AB-9330-C5C60D79AA4A"
                'Dim respuestaTicket As New ConectarAPISUNAT.ResponseConsultarGre()

                'respuestaTicket.codRespuesta = "98"
                'respuestaTicket.indCdrGenerado = 1

                If respuestaTicket.codRespuesta = "0" And respuestaTicket.indCdrGenerado = 1 Then
                    Dim fileCDR As String = Session.sRucEmp & "-09-" & Documento
                    ConectarAPISUNAT.ConvertirCDR(respuestaTicket.arcCdr, rutaenvio, fileCDR)
                    resulenvio = True
                Else

                    'If respuestaTicket.codRespuesta = "98" Then 'EN PROCESO


                    'Agregado para insertar el url link al pdf ------------------------

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

                        'Dim url As String = RucEmp & "|" & TipoDoc & "|" & CodSerie & "|" & NumDoc & "|" & "0.00" & "|" & "0.00" & "|" & FecDoc.ToString("yyyy-MM-dd") & "|" & TipoIdentidad & "|" & RucCli & "|" & ValorResumen
                        Dim urls As String = RucEmp & "|" & TipoDoc & "|" & CodSerie & "|" & NumDoc & "|" & "0.00" & "|" & "0.00" & "|" & FecDoc.ToString("yyyy-MM-dd") & "|" & TipoIdentidad & "|" & RucCli & "|" & ValorResumen
                        UbicacionCodBarra = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\" & Documento & ".png"

                        bmp = ZX.Write(urls)
                        bmp.Save(UbicacionCodBarra, Imaging.ImageFormat.Png)

                        ' mandando vacio para no generar el qr en la impresion 
                        ' UbicacionCodBarra = ""

                        CrearPDF2()



                        'fin Agregado para insertar el url link al pdf ------------------------

                        Dim rutapdf As New FileStream("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\" & Session.sRucEmp & "-09-" & Documento & ".pdf", FileMode.Open, FileAccess.Read)
                        'Dim rutapdf As New FileStream("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\20100020441-09-" & Documento & ".pdf", FileMode.Open, FileAccess.Read)
                        Dim binario(rutapdf.Length) As Byte
                        rutapdf.Read(binario, 0, rutapdf.Length) 'Leo el archivo y lo convierto a binario
                        rutapdf.Close()



                        Dim registro As New GuiaRemisionDigitalService.GuiaRemisionDigital
                        Dim guiaremision As New GuiaRemisionDigitalService.GuiaRemision

                        registro.CDRxml = Nothing
                        registro.CodUsu = Session.sCodUsu
                        registro.DirIp = Session.sDirIp
                        registro.DocumentoXml = xmlDoc.OuterXml
                        registro.Estado = "98"
                        guiaremision.IdGuia = IdGuia
                        registro.GuiaRemision = guiaremision
                        registro.NombreXml = nombrexml
                        registro.NomPc = Session.sNomPc
                        registro.NumTicket = ticket
                        registro.Observacion = Nothing
                        registro.Notas = Nothing
                        registro.DocumentoPdf = binario
                        registro.IdGuiaRef = Nothing
                        registro.UrlLink = Nothing

                        insertar = oGuiaRemisionDigitalService.Insertar(registro)

                        If insertar Then
                            MsgBox("Se proceso la guia de remision electronica correctamente", MsgBoxStyle.Information)
                            EstadoSunat = True
                        Else
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        End If
                        '        Else
                        '            MsgBox("Codigo Error: " + respuestaTicket.Error.numError + "     Descripcion: " + respuestaTicket.Error.desError, MsgBoxStyle.Information)
                        '    Me.DialogResult = System.Windows.Forms.DialogResult.OK

                        'End If
                        resulenvio = False
            End If

                If resulenvio Then


                    Dim xmlDocR As New XmlDocument
                    xmlDocR.Load("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\R-" & Session.sRucEmp & "-09-" & Documento & ".xml")
                    'xmlDocR.Load("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\R-20100020441-09-" & Documento & ".xml")

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
                    Dim xPathString4 = "/ns:ApplicationResponse/cac:DocumentResponse/cac:DocumentReference/cbc:DocumentDescription"
                    Dim oNode = xmlDocR.SelectSingleNode(xPathString, namespaces)
                    Dim oNode2 = xmlDocR.SelectSingleNode(xPathString2, namespaces)
                    Dim oNode3 = xmlDocR.SelectSingleNode(xPathString3, namespaces)
                    Dim oNode4 = xmlDocR.SelectSingleNode(xPathString4, namespaces)
                    Dim Descripcioncdr As String = oNode.InnerText
                    Responsecode = oNode2.InnerText
                    Dim NumTicket As String = oNode3.InnerText
                    Dim UrlLink As String = oNode4.InnerText
                    '///////////////////////////////////////////////////////////////////////////

                    'Agregado para insertar el url link al pdf ------------------------------------------------------

                    Dim ZX As New ZXing.BarcodeWriter
                    Dim bmp As Bitmap
                    Dim options As ZXing.QrCode.QrCodeEncodingOptions

                    options = New ZXing.QrCode.QrCodeEncodingOptions
                    options.ErrorCorrection = ZXing.QrCode.Internal.ErrorCorrectionLevel.Q
                    options.Height = 200
                    options.Width = 200
                    options.Margin = 0.1
                    'options.Height = 190
                    'options.Width = 190
                    'options.Margin = 0.9
                    options.PureBarcode = True

                    ZX.Format = ZXing.BarcodeFormat.QR_CODE
                    ZX.Options = options

                    'Dim url As String = RucEmp & "|" & TipoDoc & "|" & CodSerie & "|" & NumDoc & "|" & "0.00" & "|" & "0.00" & "|" & FecDoc.ToString("yyyy-MM-dd") & "|" & TipoIdentidad & "|" & RucCli & "|" & ValorResumen
                    UbicacionCodBarra = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\" & Documento & ".png"

                    bmp = ZX.Write(UrlLink)
                    bmp.Save(UbicacionCodBarra, Imaging.ImageFormat.Png)

                    CrearPDF2()



                    'fin Agregado para insertar el url link al pdf ------------------------



                    Dim rutapdf As New FileStream("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\" & Session.sRucEmp & "-09-" & Documento & ".pdf", FileMode.Open, FileAccess.Read)
                    'Dim rutapdf As New FileStream("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\20100020441-09-" & Documento & ".pdf", FileMode.Open, FileAccess.Read)
                    Dim binario(rutapdf.Length) As Byte
                    rutapdf.Read(binario, 0, rutapdf.Length) 'Leo el archivo y lo convierto a binario
                    rutapdf.Close()

                    Dim registro As New GuiaRemisionDigitalService.GuiaRemisionDigital
                    Dim guiaremision As New GuiaRemisionDigitalService.GuiaRemision

                    registro.CDRxml = xmlDocR.OuterXml
                    registro.CodUsu = Session.sCodUsu
                    registro.DirIp = Session.sDirIp
                    registro.DocumentoXml = xmlDoc.OuterXml
                    registro.Estado = Responsecode
                    guiaremision.IdGuia = IdGuia
                    registro.GuiaRemision = guiaremision
                    registro.NombreXml = nombrexml
                    registro.NomPc = Session.sNomPc
                    registro.NumTicket = NumTicket
                    registro.Observacion = Descripcioncdr
                    registro.Notas = toNull(notecompilado)
                    registro.DocumentoPdf = binario
                    registro.IdGuiaRef = IIf(GuiaPreexistente, Convert.ToInt64(IdGuiaReg), Nothing)
                    registro.UrlLink = UrlLink
                    insertar = oGuiaRemisionDigitalService.Insertar(registro)


                    If insertar Then
                        MsgBox("Se proceso la guia de remision electronica correctamente", MsgBoxStyle.Information)
                        EstadoSunat = True
                    Else
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If
                Else
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If

            End If

            If Responsecode <> "0" Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If

        Catch ex As Exception
            'If Len(ex.Message) > 4 Then
            '    oGuiaRemisionService.ActualizarEstadoImpreso(IdGuia, Session.sCodUsu)
            'End If
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al firmar el documento")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try
    End Sub

    Private Sub ObtenerTagFirma()

        Try
            Dim xmlDoc As New XmlDocument
            Dim namespaces As XmlNamespaceManager = New XmlNamespaceManager(xmlDoc.NameTable)

            namespaces.AddNamespace("ns", "urn:oasis:names:specification:ubl:schema:xsd:DespatchAdvice-2")
            namespaces.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance")
            namespaces.AddNamespace("xsd", "http://www.w3.org/2001/XMLSchema")
            namespaces.AddNamespace("sac", "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")
            namespaces.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")
            namespaces.AddNamespace("qdt", "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2")
            namespaces.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")
            namespaces.AddNamespace("udt", "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2")
            namespaces.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")
            namespaces.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#")

            xmlDoc.Load("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\" & Session.sRucEmp & "-09-" & Documento & ".xml")
            'xmlDoc.Load("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\20100020441-09-" & Documento & ".xml")

            Dim xPathStringInfo = "/ns:DespatchAdvice/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent/ds:Signature[@Id='SignatureSP']/ds:SignedInfo"
            Dim xPathStringValue = "/ns:DespatchAdvice/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent/ds:Signature[@Id='SignatureSP']/ds:SignatureValue"

            Dim oNodeInfo = xmlDoc.SelectSingleNode(xPathStringInfo, namespaces)
            ValorResumen = oNodeInfo.InnerText

            Dim oNodeValue = xmlDoc.SelectSingleNode(xPathStringValue, namespaces)
            ValorFirma = oNodeValue.InnerText

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Obtener el Tag")
        End Try

    End Sub

    Private Sub Comprimir()

        Dim destdir As String = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\" & Session.sRucEmp & "-09-" & Documento & ".zip"
        'Dim destdir As String = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\20100020441-09-" & Documento & ".zip"

        Dim zip As ZipFile = New ZipFile
        Dim file As String = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\" & Session.sRucEmp & "-09-" & Documento & ".xml"
        'Dim file As String = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\20100020441-09-" & Documento & ".xml"
        zip.AddFile(file, "")
        zip.Save(destdir)

        ObtenerTagFirma()
        'CrearPDF()

    End Sub

    Private Sub btnVerFactura_Click(sender As Object, e As EventArgs) Handles btnVerFactura.Click
        If Session.sCodEmp = "01" Then
            If opcionimp = "DetalladoCod" Then
                VerFacturaDetallado()
            ElseIf opcionimp = "DetalladoNoCod" Then
                VerFacturaDetalladoNoCodigo()
            ElseIf opcionimp = "Resumido" Then
                VerFacturaResumido()
            ElseIf opcionimp = "Observacion" Then
                VerFacturaObservacion()
            End If
        ElseIf Session.sCodEmp = "02" Then
            If opcionimp = "DetalladoCod" Then
                VerFacturaDetalladoMtuAmazonico()
            ElseIf opcionimp = "DetalladoNoCod" Then
                VerFacturaDetalladoNoCodigoMtuAmazonico()
            ElseIf opcionimp = "Resumido" Then
                VerFacturaResumidoMtuAmazonico()
            ElseIf opcionimp = "Observacion" Then
                VerFacturaObservacionMtuAmazonico()
            End If
        ElseIf Session.sCodEmp = "05" Then
            If opcionimp = "DetalladoCod" Then
                VerFacturaDetalladoEquimap()
            ElseIf opcionimp = "DetalladoNoCod" Then
                VerFacturaDetalladoNoCodigoEquimap()
            ElseIf opcionimp = "Resumido" Then
                VerFacturaResumidoEquimap()
            ElseIf opcionimp = "Observacion" Then
                VerFacturaObservacionEquimap()
            End If
        ElseIf Session.sCodEmp = "07" Then
            If opcionimp = "DetalladoCod" Then
                VerFacturaDetalladoC2Teck()
            ElseIf opcionimp = "DetalladoNoCod" Then
                VerFacturaDetalladoNoCodigoC2Teck()
            ElseIf opcionimp = "Resumido" Then
                VerFacturaResumidoC2Teck()
            ElseIf opcionimp = "Observacion" Then
                VerFacturaObservacionC2Teck()
            End If
        ElseIf Session.sCodEmp = "08" Then
            If opcionimp = "DetalladoCod" Then
                VerFacturaDetalladoC2TeckIM()
            ElseIf opcionimp = "DetalladoNoCod" Then
                VerFacturaDetalladoNoCodigoC2TeckIM()
            ElseIf opcionimp = "Resumido" Then
                VerFacturaResumidoC2TeckIM()
            ElseIf opcionimp = "Observacion" Then
                VerFacturaObservacionC2TeckIM()
            End If
        End If

    End Sub
    Private Sub VerFacturaDetallado()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim reporte As New rpImprimirGuiaElectronica

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", MostrarPrecio)
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("pIdMesa", 0)
                reporte.SetParameterValue("VistaPreliminar", "false")
                forma.Text = "Guia Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub VerFacturaDetalladoNoCodigo()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim reporte As New rpImprimirGuiaElectronicaNoCodigo

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", MostrarPrecio)
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("pIdMesa", 0)
                reporte.SetParameterValue("VistaPreliminar", "false")
                forma.Text = "Guia Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub VerFacturaResumido()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim reporte As New rpImprimirGuiaElectronicaResumido

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76"))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", MostrarPrecio)
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("pIdMesa", 0)
                reporte.SetParameterValue("VistaPreliminar", "false")
                forma.Text = "Guia Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub VerFacturaObservacion()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim reporte As New rpImprimirGuiaElectronicaObservacion

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76"))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", MostrarPrecio)
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("pIdMesa", 0)
                reporte.SetParameterValue("VistaPreliminar", "false")
                forma.Text = "Guia Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    '-------------------------------------------------------------------------  MTU AMAZONICA  -------------------------------------------------------------------------------------

    Private Sub VerFacturaDetalladoMtuAmazonico()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim reporte As New rpImprimirGuiaElectronicaMtuAmaz

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", MostrarPrecio)
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("pIdMesa", 0)
                reporte.SetParameterValue("VistaPreliminar", "false")
                forma.Text = "Guia Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub VerFacturaDetalladoNoCodigoMtuAmazonico()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim reporte As New rpImprimirGuiaElectronicaMtuAmazNoCodigo

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", MostrarPrecio)
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("pIdMesa", 0)
                reporte.SetParameterValue("VistaPreliminar", "false")
                forma.Text = "Guia Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub VerFacturaResumidoMtuAmazonico()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim reporte As New rpImprimirGuiaElectronicaMtuAmazResumido

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76"))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", MostrarPrecio)
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("pIdMesa", 0)
                reporte.SetParameterValue("VistaPreliminar", "false")
                forma.Text = "Guia Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub VerFacturaObservacionMtuAmazonico()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim reporte As New rpImprimirGuiaElectronicaMtuAmazObservacion

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76"))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", MostrarPrecio)
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("pIdMesa", 0)
                reporte.SetParameterValue("VistaPreliminar", "false")
                forma.Text = "Guia Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    ' ----------------------------------------------------------------------------- EQUIMAP ------------------------------------------------------------------------------

    Private Sub VerFacturaDetalladoEquimap()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim reporte As New rpImprimirGuiaElectronicaEquimap

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", MostrarPrecio)
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("pIdMesa", 0)
                reporte.SetParameterValue("VistaPreliminar", "false")
                forma.Text = "Guia Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub VerFacturaDetalladoNoCodigoEquimap()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim reporte As New rpImprimirGuiaElectronicaEquimapNoCodigo

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", MostrarPrecio)
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("pIdMesa", 0)
                reporte.SetParameterValue("VistaPreliminar", "false")
                forma.Text = "Guia Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub VerFacturaResumidoEquimap()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim reporte As New rpImprimirGuiaElectronicaEquimapResumido

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76"))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", MostrarPrecio)
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("pIdMesa", 0)
                reporte.SetParameterValue("VistaPreliminar", "false")
                forma.Text = "Guia Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub VerFacturaObservacionEquimap()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim reporte As New rpImprimirGuiaElectronicaEquimapObservacion

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76"))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", MostrarPrecio)
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("pIdMesa", 0)
                reporte.SetParameterValue("VistaPreliminar", "false")
                forma.Text = "Guia Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    ' ---------------------------------------------------------------------------------- EQUIMAP -----------------------------------------------------------------------------------------

    ' ----------------------------------------------------------------------------- C2TECK ------------------------------------------------------------------------------

    Private Sub VerFacturaDetalladoC2Teck()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim reporte As New rpImprimirGuiaElectronicaC2Teck

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", MostrarPrecio)
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("pIdMesa", 0)
                reporte.SetParameterValue("VistaPreliminar", "false")
                forma.Text = "Guia Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub VerFacturaDetalladoNoCodigoC2Teck()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim reporte As New rpImprimirGuiaElectronicaC2TeckNoCodigo

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", MostrarPrecio)
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("pIdMesa", 0)
                reporte.SetParameterValue("VistaPreliminar", "false")
                forma.Text = "Guia Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub VerFacturaResumidoC2Teck()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim reporte As New rpImprimirGuiaElectronicaC2TeckResumido

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76"))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", MostrarPrecio)
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("pIdMesa", 0)
                reporte.SetParameterValue("VistaPreliminar", "false")
                forma.Text = "Guia Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub VerFacturaObservacionC2Teck()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim reporte As New rpImprimirGuiaElectronicaC2TeckObservacion

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76"))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", MostrarPrecio)
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("pIdMesa", 0)
                reporte.SetParameterValue("VistaPreliminar", "false")
                forma.Text = "Guia Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    ' ---------------------------------------------------------------------------------- C2TECK -----------------------------------------------------------------------------------------

    ' ----------------------------------------------------------------------------- C2TECK INFORMATICA Y METALURGICA ----------------------------------------------------

    Private Sub VerFacturaDetalladoC2TeckIM()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim reporte As New rpImprimirGuiaElectronicaC2TeckIM

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", MostrarPrecio)
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("pIdMesa", 0)
                reporte.SetParameterValue("VistaPreliminar", "false")
                forma.Text = "Guia Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub VerFacturaDetalladoNoCodigoC2TeckIM()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim reporte As New rpImprimirGuiaElectronicaC2TeckIMNoCodigo

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", MostrarPrecio)
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("pIdMesa", 0)
                reporte.SetParameterValue("VistaPreliminar", "false")
                forma.Text = "Guia Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub VerFacturaResumidoC2TeckIM()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim reporte As New rpImprimirGuiaElectronicaC2TeckIMResumido

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76"))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", MostrarPrecio)
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("pIdMesa", 0)
                reporte.SetParameterValue("VistaPreliminar", "false")
                forma.Text = "Guia Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub VerFacturaObservacionC2TeckIM()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim reporte As New rpImprimirGuiaElectronicaC2TeckIMObservacion

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76"))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", MostrarPrecio)
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("pIdMesa", 0)
                reporte.SetParameterValue("VistaPreliminar", "false")
                forma.Text = "Guia Digital"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    ' ---------------------------------------------------------------------------------- C2TECK INFORMATICA Y METALURGICA ---------------------------------------------------------

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

            Dim registro As GuiaRemisionDigitalService.GuiaRemisionDigital
            registro = oGuiaRemisionDigitalService.Obtener(IdGuia)

            'Dim url As String = RucEmp & "|" & TipoDoc & "|" & CodSerie & "|" & NumDoc & "|" & "0.00" & "|" & "0.00" & "|" & FecDoc.ToString("yyyy-MM-dd") & "|" & TipoIdentidad & "|" & RucCli & "|" & ValorResumen
            Dim url As String = registro.UrlLink 'RucEmp & "|" & TipoDoc & "|" & CodSerie & "|" & NumDoc & "|" & "0.00" & "|" & "0.00" & "|" & FecDoc.ToString("yyyy-MM-dd") & "|" & TipoIdentidad & "|" & RucCli & "|" & ValorResumen
            'Dim url As String = "https://e-factura.sunat.gob.pe/v1/contribuyente/gre/comprobantes/descargaqr?hashqr=K8uc7pMBCeLJ8/Zeq4HObPVeciULLPaKZibrrrjLy39vdsjCMwALoj+V1hR9C7Fdptyku8Nd0a/2HlvLyOm6ScM2CB9uo3Gr/SdKnRc/2Gg=" 'registro.UrlLink 'RucEmp & "|" & TipoDoc & "|" & CodSerie & "|" & NumDoc & "|" & "0.00" & "|" & "0.00" & "|" & FecDoc.ToString("yyyy-MM-dd") & "|" & TipoIdentidad & "|" & RucCli & "|" & ValorResumen
            UbicacionCodBarra = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\" & Documento & ".png"

            bmp = ZX.Write(url)
            bmp.Save(UbicacionCodBarra, Imaging.ImageFormat.Png)




            'Dim qr As PDF417Writer = New PDF417Writer
            ''Dim NumDocsinSerie As String = Mid(NumDoc, 6, NumDoc.Length - 5)
            ''Dim url As String = "20100022142|01|F106|611|783.00|5133.00|2015-03-20|6|20100020441|oWUMtPr6aTZltzrFFI6whBA8qdg=|QaBVEy1zRK7VXLM5va0by+mInYDN2fhZBsPbOHXQlBytjj0RZVgjLMkSBhKeUe1kTU5Fk7yZI2S/wAKm/V8W7scEEf7kc3X7WCJwk0lrLoiY0l+N0S0AVJjZcm6wmlN0QB4jh+rTiy+STdhDhx37Ye5QmHAJyR0nB2OYrff2FeegsDv+XY7opVC8jjqxfJXlhvjrklLtMt4w4ueJ+i/YNRIj3D3kYnuj4IXp1SIpwQ3GYJs95yALfn9IME6zXfVkRmjXTqYUS5yAFFYqAc6r01WzcZQSKHPUIPQtoNLN0AHaTT0qQ7gKgBozoDDK0gR5RJ7jEaFd85S4o0h7EaysMg==|"
            'Dim url As String = RucEmp & "|" & TipoDoc & "|" & CodSerie & "|" & NumDoc & "|" & "0.00" & "|" & "0.00" & "|" & FecDoc.ToString("yyyy-MM-dd") & "|" & TipoIdentidad & "|" & RucCli '& "|" & ValorResumen & "|" & ValorFirma

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
            'UbicacionCodBarra = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\" & Documento & ".png"
            ''img2.Save(UbicacionCodBarra, System.Drawing.Imaging.ImageFormat.Png)
            'img.Save(UbicacionCodBarra, System.Drawing.Imaging.ImageFormat.Png)

            CrearPDF2()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Shared Function ResizeBitmap(ByVal sourceBMP As Bitmap, ByVal width As Integer, ByVal height As Integer) As Bitmap
        Dim result As Bitmap = New Bitmap(width, height)
        Dim g As Graphics = Graphics.FromImage(result)
        g.DrawImage(sourceBMP, 0, 0, width, height)
        Return result
    End Function

    Private Sub CrearPDF2()

        If Session.sCodEmp = "01" Then
            If opcionimp = "DetalladoCod" Then
                CrearPDF2Det()
            ElseIf opcionimp = "DetalladoNoCod" Then
                CrearPDF2DetNoCod()
            ElseIf opcionimp = "Resumido" Then
                CrearPDF2Res()
            ElseIf opcionimp = "Observacion" Then
                CrearPDF2Obs()
            End If
        ElseIf Session.sCodEmp = "02" Then
            If opcionimp = "DetalladoCod" Then
                CrearPDF2DetMtuAmazonica()
            ElseIf opcionimp = "DetalladoNoCod" Then
                CrearPDF2DetNoCodMtuAmazonica()
            ElseIf opcionimp = "Resumido" Then
                CrearPDF2ResMtuAmazonica()
            ElseIf opcionimp = "Observacion" Then
                CrearPDF2ObsMtuAmazonica()
            End If
        ElseIf Session.sCodEmp = "05" Then
            If opcionimp = "DetalladoCod" Then
                CrearPDF2DetEquimap()
            ElseIf opcionimp = "DetalladoNoCod" Then
                CrearPDF2DetNoCodEquimap()
            ElseIf opcionimp = "Resumido" Then
                CrearPDF2ResEquimap()
            ElseIf opcionimp = "Observacion" Then
                CrearPDF2ObsEquimap()
            End If
        ElseIf Session.sCodEmp = "07" Then
            If opcionimp = "DetalladoCod" Then
                CrearPDF2DetC2Teck()
            ElseIf opcionimp = "DetalladoNoCod" Then
                CrearPDF2DetNoCodC2Teck()
            ElseIf opcionimp = "Resumido" Then
                CrearPDF2ResC2Teck()
            ElseIf opcionimp = "Observacion" Then
                CrearPDF2ObsC2Teck()
            End If
        ElseIf Session.sCodEmp = "08" Then
            If opcionimp = "DetalladoCod" Then
                CrearPDF2DetC2Teck()
            ElseIf opcionimp = "DetalladoNoCod" Then
                CrearPDF2DetNoCodC2Teck()
            ElseIf opcionimp = "Resumido" Then
                CrearPDF2ResC2Teck()
            ElseIf opcionimp = "Observacion" Then
                CrearPDF2ObsC2Teck()
            End If

        End If

    End Sub

    Private Sub CrearPDF2Det()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronica

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(MostrarPrecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)

            End If

            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2DetNoCod()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaNoCodigo

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(MostrarPrecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
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
            Dim reporte As New rpImprimirGuiaElectronicaResumido

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(MostrarPrecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)
            End If
            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2Obs()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaObservacion

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(MostrarPrecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)
            End If
            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    ' ---------------------------------------------------------------------------- MTU AMAZONICA ---------------------------------------------------------------------------------
    Private Sub CrearPDF2DetMtuAmazonica()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaMtuAmaz

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(MostrarPrecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)

            End If

            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2DetNoCodMtuAmazonica()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaMtuAmazNoCodigo

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(MostrarPrecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)

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
            Dim reporte As New rpImprimirGuiaElectronicaMtuAmazResumido

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(MostrarPrecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)
            End If
            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2ObsMtuAmazonica()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaMtuAmazObservacion

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(MostrarPrecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)
            End If
            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    ' ---------------------------------------------------------------------------- EQUIMAP ---------------------------------------------------------------------------------

    Private Sub CrearPDF2DetEquimap()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaEquimap

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(MostrarPrecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)

            End If

            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2DetNoCodEquimap()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaEquimapNoCodigo

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(MostrarPrecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
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
            Dim reporte As New rpImprimirGuiaElectronicaEquimapResumido

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(MostrarPrecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)
            End If
            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
    Private Sub CrearPDF2ObsEquimap()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaEquimapObservacion

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(MostrarPrecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)
            End If
            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    ' ---------------------------------------------------------------------------- FIN EQUIMAP ---------------------------------------------------------------------------------

    ' ---------------------------------------------------------------------------- C2TECK ---------------------------------------------------------------------------------

    Private Sub CrearPDF2DetC2Teck()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaC2Teck

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(MostrarPrecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)

            End If

            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
    Private Sub CrearPDF2DetNoCodC2Teck()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaC2TeckNoCodigo

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(MostrarPrecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
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
            Dim reporte As New rpImprimirGuiaElectronicaC2TeckResumido

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(MostrarPrecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)
            End If
            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2ObsC2Teck()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaC2TeckObservacion

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(MostrarPrecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)
            End If
            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub


    ' ---------------------------------------------------------------------------- FIN C2TECK ---------------------------------------------------------------------------------

    ' ---------------------------------------------------------------------------- C2TECK INFORMATICA Y METALURGICA -------------------------------------------------------------------

    Private Sub CrearPDF2DetC2TeckIM()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaC2TeckIM

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(MostrarPrecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)

            End If

            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2DetNoCodC2TeckIM()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaC2TeckIMNoCodigo

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(MostrarPrecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
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
            Dim reporte As New rpImprimirGuiaElectronicaC2TeckIMResumido

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(MostrarPrecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)
            End If
            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2ObsC2TeckIM()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaC2TeckIMObservacion

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(MostrarPrecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)
            End If
            ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    ' ---------------------------------------------------------------------------- FIN C2TECK INFORMATICA Y METALURGICA -----------------------------------------------------------

    Public Shared Function ExportToPDF(rpt As ReportDocument, NombreArchivo As String, NumDoc1 As String) As String
        Dim vFileName As String = Nothing
        Dim diskOpts As New DiskFileDestinationOptions()

        Try

            diskOpts.DiskFileName = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & NumDoc1 & "\" & Session.sRucEmp & "-09-" & NumDoc1 & ".pdf"
            'diskOpts.DiskFileName = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & NumDoc1 & "\20100020441-09-" & NumDoc1 & ".pdf"

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
            Dim d As New DirectoryInfo("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento)

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
            txtAsunto.Text = Session.sDesEmp & " - Guia Remisión Electrónica: " & Documento '"DETROIT DIESEL MTU PERU SAC - Boleta Electrónica: " & Documento
            txtMensaje.Text = "Envio de Guia Electronica Electronica c/Adjunto xml, pdf" '& Environment.NewLine & Environment.NewLine & "No Contestar el correo porque es una cuenta desatendida"

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
            txtAsunto.Text = Session.sDesEmp & " - Guia Remisión Electrónica: " & Documento '"DETROIT DIESEL MTU PERU SAC - Boleta Electrónica: " & Documento
            txtMensaje.Text = "Envio de Guia Electronica Electronica c/Adjunto xml, pdf" '& Environment.NewLine & Environment.NewLine & "No Contestar el correo porque es una cuenta desatendida"

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
            txtAsunto.Text = Session.sDesEmp & " - Guia Remisión Electrónica: " & Documento '"DETROIT DIESEL MTU PERU SAC - Boleta Electrónica: " & Documento
            txtMensaje.Text = "Envio de Guia Electronica Electronica c/Adjunto xml, pdf" '& Environment.NewLine & Environment.NewLine & "No Contestar el correo porque es una cuenta desatendida"

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
            txtAsunto.Text = Session.sDesEmp & " - Guia Remisión Electrónica: " & Documento '"DETROIT DIESEL MTU PERU SAC - Boleta Electrónica: " & Documento
            txtMensaje.Text = "Envio de Guia Electronica Electronica c/Adjunto xml, pdf" '& Environment.NewLine & Environment.NewLine & "No Contestar el correo porque es una cuenta desatendida"

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
            txtAsunto.Text = Session.sDesEmp & " - Guia Remisión Electrónica: " & Documento '"DETROIT DIESEL MTU PERU SAC - Boleta Electrónica: " & Documento
            txtMensaje.Text = "Envio de Guia Electronica Electronica c/Adjunto xml, pdf" '& Environment.NewLine & Environment.NewLine & "No Contestar el correo porque es una cuenta desatendida"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Correo")
        End Try

    End Sub

    Private Sub btnEnviarCorreo_Click(sender As Object, e As EventArgs) Handles btnEnviarCorreo.Click
        Try
            If ValidaCamposCorreo() Then

                Dim Cuerpo As String
                Cuerpo = "<html><body><font size='2'>" + "Fecha de Ingreso " + Today().ToString("dd/MM/yyyy") + " : " + TimeOfDay.ToString("HH:mm:ss")
                Cuerpo = Cuerpo + "<br/><br/>Señor(es) : " +
                              "<br/><br/><b>" + Trim(DesCli) + ":</b>" +
                                     "<br/><br/>Le informamos que ha recibido un documento de " + DesEmp +
                                     "<br/><br/>Número de documento : " + Documento
                Cuerpo = Cuerpo + "<br/>Tipo de Documento : " + "Guia Remisión"
                Cuerpo = Cuerpo + "<br/>Fecha de emisión : " + FecDoc.ToString("dd/MM/yyyy")
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

                Dim destdir As String = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\" & Session.sRucEmp & "-09-" & Documento & ".zip"
                Dim xmldir As String = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\" & Session.sRucEmp & "-09-" & Documento & ".xml"
                Dim pdfdir As String = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\" & Session.sRucEmp & "-09-" & Documento & ".pdf"
                Dim xmlcdrdir As String = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\R-" & Session.sRucEmp & "-09-" & Documento & ".xml"

                'Dim destdir As String = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\20100020441-09-" & Documento & ".zip"
                'Dim xmldir As String = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\20100020441-09-" & Documento & ".xml"
                'Dim pdfdir As String = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\20100020441-09-" & Documento & ".pdf"

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

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub CrearXmlDetalle21()

        Try

            Dim xmlFilename As String = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\" & Session.sRucEmp & "-09-" & Documento & ".xml"
            Dim registro As New DocumentoSunat()

            registro.CodDocEmisor = "6"
            registro.RucEmisor = Session.sRucEmp
            registro.DesEmpEmisor = Session.sDesEmp
            registro.CodUbigeoEmisor = Session.sCodUbigeo
            registro.DireccionEmisor = Session.sDireccion
            registro.DepartamentoEmisor = Session.sDepartamento
            registro.ProvinciaEmisor = Session.sProvincia
            registro.DistritoEmisor = Session.sDistrito
            registro.DocumentoRef = DocumentoReferencia
            registro.Documento = Documento
            registro.FecDoc = FecDoc
            registro.FechaTraslado = FecTraslado
            registro.TipoDoc = TipoDoc
            registro.LetrasTotalDoc = TotNetoLetras
            registro.CodDocCliente = TipoIdentidad
            registro.RucCliente = RucCli
            registro.DesCliente = DesCli
            registro.PorcentajeIGV = Igv
            registro.NumOrden = NumOrden
            registro.CodTraslado = CodTraslado
            registro.DesTraslado = DesMot
            registro.CodUnidadPeso = CodUniMedPeso
            registro.TotalPeso = PesoBruto
            registro.CantidadBultos = NumeroBultos
            registro.CodModalidad = CodModo
            registro.CodUbigeoLlegada = CodUbigeoLlegada
            registro.DireccionLlegada = PtoLlegada
            registro.CodUbigeoPartida = CodUbigeo
            registro.DireccionPartida = PtoPartida
            registro.CodDocTransportista = "6"
            registro.RucTransportista = Ruc
            registro.DesTransportista = Empresa
            registro.NumeroPlaca = Placa
            registro.CodDocConductor = CodDocChofer
            registro.NumDocConductor = NumDocChofer
            registro.NumLicenciaConductor = Licencia
            registro.NombresConductor = Chofer
            registro.ApellidosConductor = "-"
            registro.CargoConductor = "Principal"
            registro.Observacion = Observacion

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
                    .UnidadMedida = CStr(row.Cells("unitCode").Value)
                    }
                Next
                registro.DocumentoFilas = fila
            End If

            FacturacionElectronica21.GenerarDespatchAdvice(xmlFilename, registro)

            FirmadoDigital()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear xml")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try

    End Sub

    Private Sub CrearXmlResumen21()

        Try

            Dim xmlFilename As String = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\" & Session.sRucEmp & "-09-" & Documento & ".xml"
            Dim registro As New DocumentoSunat()

            registro.CodDocEmisor = "6"
            registro.RucEmisor = Session.sRucEmp
            registro.DesEmpEmisor = Session.sDesEmp
            registro.CodUbigeoEmisor = Session.sCodUbigeo
            registro.DireccionEmisor = Session.sDireccion
            registro.DepartamentoEmisor = Session.sDepartamento
            registro.ProvinciaEmisor = Session.sProvincia
            registro.DistritoEmisor = Session.sDistrito
            registro.DocumentoRef = DocumentoReferencia
            registro.Documento = Documento
            registro.FecDoc = FecDoc
            registro.FechaTraslado = FecTraslado
            registro.TipoDoc = TipoDoc
            registro.LetrasTotalDoc = TotNetoLetras
            registro.CodDocCliente = TipoIdentidad
            registro.RucCliente = RucCli
            registro.DesCliente = DesCli
            registro.PorcentajeIGV = Igv
            registro.NumOrden = NumOrden
            registro.CodTraslado = CodTraslado
            registro.DesTraslado = DesMot
            registro.CodUnidadPeso = CodUniMedPeso
            registro.TotalPeso = PesoBruto
            registro.CantidadBultos = NumeroBultos
            registro.CodModalidad = CodModo
            registro.CodUbigeoLlegada = CodUbigeoLlegada
            registro.DireccionLlegada = PtoLlegada
            registro.CodUbigeoPartida = CodUbigeo
            registro.DireccionPartida = PtoPartida
            registro.CodDocTransportista = "6"
            registro.RucTransportista = Ruc
            registro.DesTransportista = Empresa
            registro.NumeroPlaca = Placa
            registro.CodDocConductor = CodDocChofer
            registro.NumDocConductor = NumDocChofer
            registro.NumLicenciaConductor = Licencia
            registro.NombresConductor = Chofer
            registro.ApellidosConductor = "-"
            registro.CargoConductor = "Principal"
            registro.Observacion = Observacion

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
                    .Cantidad = CDec(1.0),
                    .UnidadMedida = CStr(row.Cells("unitCode").Value)
                    }
                Next


            End If

            registro.DocumentoFilas = fila

            FacturacionElectronica21.GenerarDespatchAdvice(xmlFilename, registro)

            FirmadoDigital()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear xml")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try

    End Sub


    Private Sub CrearXMLObservacion21()

        Try
            Dim xmlFilename As String = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\" & Session.sRucEmp & "-09-" & Documento & ".xml"
            Dim registro As New DocumentoSunat()

            registro.CodDocEmisor = "6"
            registro.RucEmisor = Session.sRucEmp
            registro.DesEmpEmisor = Session.sDesEmp
            registro.CodUbigeoEmisor = Session.sCodUbigeo
            registro.DireccionEmisor = Session.sDireccion
            registro.DepartamentoEmisor = Session.sDepartamento
            registro.ProvinciaEmisor = Session.sProvincia
            registro.DistritoEmisor = Session.sDistrito
            registro.DocumentoRef = DocumentoReferencia
            registro.Documento = Documento
            registro.FecDoc = FecDoc
            registro.FechaTraslado = FecTraslado
            registro.TipoDoc = TipoDoc
            registro.LetrasTotalDoc = TotNetoLetras
            registro.CodDocCliente = TipoIdentidad
            registro.RucCliente = RucCli
            registro.DesCliente = DesCli
            registro.PorcentajeIGV = Igv
            registro.NumOrden = NumOrden
            registro.CodTraslado = CodTraslado
            registro.DesTraslado = DesMot
            registro.CodUnidadPeso = CodUniMedPeso
            registro.TotalPeso = PesoBruto
            registro.CantidadBultos = NumeroBultos
            registro.CodModalidad = CodModo
            registro.CodUbigeoLlegada = CodUbigeoLlegada
            registro.DireccionLlegada = PtoLlegada
            registro.CodUbigeoPartida = CodUbigeo
            registro.DireccionPartida = PtoPartida
            registro.CodDocTransportista = "6"
            registro.RucTransportista = Ruc
            registro.DesTransportista = Empresa
            registro.NumeroPlaca = Placa
            registro.CodDocConductor = CodDocChofer
            registro.NumDocConductor = NumDocChofer
            registro.NumLicenciaConductor = Licencia
            registro.NombresConductor = Chofer
            registro.ApellidosConductor = "-"
            registro.CargoConductor = "Principal"
            registro.Observacion = Observacion

            Dim cantline As Integer = 0 'GridEX1.RowCount - 1
            Dim fila As DocumentoDetalleSunat() = New DocumentoDetalleSunat(cantline) {}
            Dim row As Janus.Windows.GridEX.GridEXRow
            If GridEX1.RowCount > 0 Then
                For j = 0 To 0 'GridEX1.RowCount - 1
                    Me.GridEX1.Row = j
                    row = Me.GridEX1.GetRow()
                    fila(j) = New DocumentoDetalleSunat() With {
                    .Id = "1",
                    .Codigo = CStr("-"),
                    .Descripcion = CStr(row.Cells("Observacion").Value),
                    .Cantidad = CDec(1.0),
                    .UnidadMedida = "NIU"
                    }
                Next


            End If

            registro.DocumentoFilas = fila

            FacturacionElectronica21.GenerarDespatchAdvice(xmlFilename, registro)

            FirmadoDigital()

            '==============================================================================================================================Fin Codigo GenerarXML
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al firmar el documento")
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