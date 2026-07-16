
Imports System.ServiceModel
Imports LibreriaFacturacion
Imports System.Xml
Imports System.Text
Imports System.IO
Imports Ionic.Zip
Imports UblLarsen.Ubl2
Imports UblLarsen.Ubl2.aplicacion
Imports UblLarsen.Ubl2.Cac
Imports UblLarsen.Ubl2.Udt
Imports FacturarSunat.aplicacion
Imports FacturarSunat21.aplicacion
Public Class frmBoleta_BoletaElectronica_Resumen_Generar

    Private oResumenBoletaDigitalService As New ResumenBoletasDigitalService.ResumenBoletasDigitalServiceClient
    Private oCommunicationState As New ComunicacionSunat

    Public IdBoleta As String
    Public EstadoEnvio As Boolean

    Dim RucEmp As String
    Dim DesEmp As String
    Dim TipoDoc As String
    Dim IdSerieDoc As String
    Dim CodSerie As String
    Dim NumDoc As String
    Dim TipoIdentidad As String

    Dim NumDocCli As String
    Dim CodSerieRef As String
    Dim TipoDocRef As String
    Dim NumDocRef As String
    Dim TotBruto As String
    Dim TotDscto As String


    Dim TotNeto As Double
    Dim TotIgv As Double
    Dim TotVenta As Double
    Dim TotalGravadas As Double
    Dim TotalExoneradas As Double
    Dim TotalInafectas As Double

    Dim CodTributo As String
    Dim NomTributo As String
    Dim CodTributoInt As String

    Dim IdNumeracion As String

    Private Sub frmBoleta_BoletaElectronica_Resumen_Generar_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oResumenBoletaDigitalService.Close()
        Catch ex As TimeoutException
            oResumenBoletaDigitalService.Abort()
        Catch ex As CommunicationException
            oResumenBoletaDigitalService.Abort()
        End Try
    End Sub

    Private Sub frmBoleta_BoletaElectronica_Resumen_Generar_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmBoleta_BoletaElectronica_Resumen_Generar_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        cbFecha.Value = Today

        ListarDetalles()

    End Sub

    Private Sub cbFecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbFecha.KeyPress
        If e.KeyChar = ChrW(Keys.Tab Or Keys.Enter) Then
            If btnBuscar.Enabled = True Then
                btnBuscar.Select()
                btnBuscar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click

        IdNumeracion = oResumenBoletaDigitalService.SugerirNumero(Session.sCodEmp, cbFecha.Value)
        CrearCarpeta()
        'ListarDetalles()
        CrearXML()
    End Sub

    Private Sub CrearCarpeta()

        If Not Directory.Exists("D:\Documentos_Electronicos\Resumen_Boletas\" & "RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion) Then
            Directory.CreateDirectory("D:\Documentos_Electronicos\Resumen_Boletas\" & "RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion)
        End If

    End Sub

    Private Sub ListarDetalles()
        Try
            Dim dtReporte As New DataTable
            dtReporte = oResumenBoletaDigitalService.MostrarResumenBoletas(Session.sCodEmp, cbFecha.Value).Tables(0)
            dgvDatos.DataSource = dtReporte

            If dtReporte.Rows.Count > 0 Then

                For Each row2 As DataRow In dtReporte.Rows

                    Dim tipodocrefv As String
                    Dim codseriefecv As String
                    Dim numdocrefv As String

                    RucEmp = row2("RucEmp")   'dgvDatos.CurrentRow.Cells("RucEmp").Text
                    DesEmp = row2("DesEmp")   'dgvDatos.CurrentRow.Cells("DesEmp").Text
                    TipoDoc = row2("TipoDoc")   'dgvDatos.CurrentRow.Cells("TipoDoc").Text
                    IdSerieDoc = row2("IdSerieDoc")   'dgvDatos.CurrentRow.Cells("IdSerieDoc").Text
                    CodSerie = row2("CodSerie")   'dgvDatos.CurrentRow.Cells("CodSerie").Text
                    NumDoc = row2("NumDoc")   'dgvDatos.CurrentRow.Cells("NumDoc").Text
                    TipoIdentidad = row2("TipoIdentidad")   'dgvDatos.CurrentRow.Cells("TipoIdentidad").Text
                    NumDocCli = row2("NumDocCli")   'dgvDatos.CurrentRow.Cells("NumDocCli").Text
                    'CodSerieRef = row2("CodSerieRef")    'dgvDatos.CurrentRow.Cells("CodSerieRef").Text
                    If IsDBNull(row2("CodSerieRef")) Then
                        codseriefecv = ""
                    Else codseriefecv = CStr(row2("CodSerieRef"))
                    End If
                    CodSerieRef = codseriefecv
                    If IsDBNull(row2("TipoDocRef")) Then
                        tipodocrefv = ""
                    Else tipodocrefv = CStr(row2("TipoDocRef"))
                    End If
                    TipoDocRef = tipodocrefv
                    If IsDBNull(row2("NumDocRef")) Then
                        numdocrefv = ""
                    Else numdocrefv = CStr(row2("NumDocRef"))
                    End If
                    NumDocRef = numdocrefv 'dgvDatos.CurrentRow.Cells("TipoDocRef").Text
                    'NumDocRef = row2("NumDocRef") 'dgvDatos.CurrentRow.Cells("NumDocRef").Text
                    TotNeto = row2("TotNeto") 'dgvDatos.CurrentRow.Cells("TotNeto").Text
                    TotIgv = row2("TotIgv") 'dgvDatos.CurrentRow.Cells("TotIgv").Text
                    TotBruto = row2("TotBruto") ' dgvDatos.CurrentRow.Cells("TotBruto").Text
                    TotDscto = row2("TotDscto") 'dgvDatos.CurrentRow.Cells("TotDscto").Text
                    TotVenta = row2("TotVenta") 'dgvDatos.CurrentRow.Cells("TotVenta").Text
                    TotalInafectas = row2("TotalInafectas") 'dgvDatos.CurrentRow.Cells("TotalInafectas").Text
                    CodTributo = row2("CodTributo") 'dgvDatos.CurrentRow.Cells("CodTributo").Text
                    NomTributo = row2("NomTributo") 'dgvDatos.CurrentRow.Cells("NomTributo").Text
                    CodTributoInt = row2("CodTributoInt") 'dgvDatos.CurrentRow.Cells("CodTributoInt").Text

                Next

                ''Dim tipodocref As String
                'RucEmp = dgvDatos.CurrentRow.Cells("RucEmp").Text
                'DesEmp = dgvDatos.CurrentRow.Cells("DesEmp").Text
                'TipoDoc = dgvDatos.CurrentRow.Cells("TipoDoc").Text
                'IdSerieDoc = dgvDatos.CurrentRow.Cells("IdSerieDoc").Text
                'CodSerie = dgvDatos.CurrentRow.Cells("CodSerie").Text
                'NumDoc = dgvDatos.CurrentRow.Cells("NumDoc").Text
                'TipoIdentidad = dgvDatos.CurrentRow.Cells("TipoIdentidad").Text
                'NumDocCli = dgvDatos.CurrentRow.Cells("NumDocCli").Text
                'CodSerieRef = dgvDatos.CurrentRow.Cells("CodSerieRef").Text
                'If IsDBNull(dgvDatos.CurrentRow.Cells("TipoDocRef").Text) Then
                '    tipodocref = ""
                'Else tipodocref = CStr(dgvDatos.CurrentRow.Cells("TipoDocRef").Text)
                'End If
                'tipodocref = tipodocref 'dgvDatos.CurrentRow.Cells("TipoDocRef").Text
                'NumDocRef = dgvDatos.CurrentRow.Cells("NumDocRef").Text
                'TotNeto = dgvDatos.CurrentRow.Cells("TotNeto").Text
                'TotIgv = dgvDatos.CurrentRow.Cells("TotIgv").Text
                'TotBruto = dgvDatos.CurrentRow.Cells("TotBruto").Text
                'TotDscto = dgvDatos.CurrentRow.Cells("TotDscto").Text
                'TotVenta = dgvDatos.CurrentRow.Cells("TotVenta").Text
                'TotalInafectas = dgvDatos.CurrentRow.Cells("TotalInafectas").Text
                'TotalInafectas = dgvDatos.CurrentRow.Cells("TotalInafectas").Text
                'TotalInafectas = dgvDatos.CurrentRow.Cells("TotalInafectas").Text
                'CodTributo = dgvDatos.CurrentRow.Cells("CodTributo").Text
                'NomTributo = dgvDatos.CurrentRow.Cells("NomTributo").Text
                'CodTributoInt = dgvDatos.CurrentRow.Cells("CodTributoInt").Text
            Else
                'MsgBox("No existen boletas en esta fecha...", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CrearXMLAntiguo()

        Try


            Dim xmlFilename As String = "D:\Documentos_Electronicos\Resumen_Boletas\" & "RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion & "\" & Session.sRucEmp & "-RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion & ".xml"
            'Dim xmlFilename As String = "D:\Documentos_Electronicos\Resumen_Boletas\" & "RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion & "\20100020441-RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion & ".xml"

            UblLarsen.Ubl2.UblBaseDocumentType.GlbCustomizationID = "1.0"

            AmountType.TlsDefaultCurrencyID = "PEN"

            Dim line As SummaryDocumentsLineType() = Nothing

            Dim row As Janus.Windows.GridEX.GridEXRow

            If dgvDatos.RowCount > 0 Then
                Dim cantline As Integer = dgvDatos.RowCount
                line = New SummaryDocumentsLineType(cantline) {}

                For j = 0 To dgvDatos.RowCount - 1
                    Me.dgvDatos.Row = j
                    row = Me.dgvDatos.GetRow()

                    line(j) = New SummaryDocumentsLineType() With {
                        .LineID = j + 1,
                        .DocumentTypeCode = CStr(row.Cells("TipoDoc").Value),
                        .DocumentSerialID = CStr(row.Cells("CodSerie").Value),
                        .StartDocumentNumberID = CStr(row.Cells("NumDocInicio").Value),
                        .EndDocumentNumberID = CStr(row.Cells("NumDocFinal").Value),
                        .TotalAmount = CDec(FormatNumber(row.Cells("TotNeto").Value, 2)),
                        .BillingPayment = New BillingPaymentType() {New BillingPaymentType() With {
                            .PaidAmount = CDec(FormatNumber(row.Cells("TotalGravadas").Value, 2)),
                            .InstructionID = "01"
                        }, New BillingPaymentType() With {
                            .PaidAmount = CDec(FormatNumber(row.Cells("TotalExoneradas").Value, 2)),
                            .InstructionID = "02"
                        }, New BillingPaymentType() With {
                            .PaidAmount = CDec(FormatNumber(row.Cells("TotalInafectas").Value, 2)),
                            .InstructionID = "03"
                        }},
                        .AllowanceCharge = New AllowanceChargeType() {New AllowanceChargeType() With {
                            .ChargeIndicator = True,
                            .Amount = 0D
                        }},
                        .TaxTotal = New TaxTotalType() {New TaxTotalType() With {
                            .TaxAmount = 0D,
                            .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With {
                                .TaxAmount = 0D,
                                .TaxCategory = New TaxCategoryType() With {
                                    .TaxScheme = New TaxSchemeType() With {
                                        .ID = "2000",
                                        .Name = "ISC",
                                        .TaxTypeCode = "EXC"
                                    }
                                }
                            }}
                        }, New TaxTotalType() With {
                            .TaxAmount = CDec(FormatNumber(row.Cells("TotIgv").Value, 2)),
                            .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With {
                                .TaxAmount = CDec(FormatNumber(row.Cells("TotIgv").Value, 2)),
                                .TaxCategory = New TaxCategoryType() With {
                                    .TaxScheme = New TaxSchemeType() With {
                                        .ID = "1000",
                                        .Name = "IGV",
                                        .TaxTypeCode = "VAT"
                                    }
                                }
                            }}
                        }}
                    }

                Next

            End If
            '==============================================================================================================================Fin Codigo InvoiceLine

            '==============================================================================================================================Inicio Codigo GenerarXML

            'Dim Hoy As DateTime = DateTime.Today

            'Dim file As String = "D:\Certificado\20100020441-RC-20150904-1.xml"

            FacturacionElectronica.GenerarSummaryDocument(xmlFilename, Session.sRucEmp, Session.sDesEmp, "PEN", "RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion, cbFecha.Value, cbFecha.Value, line)

            '==============================================================================================================================Fin Codigo GenerarXML

            FirmadoDigital()

        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub CrearXML()

        Try
            Dim xmlFilename As String = "D:\Documentos_Electronicos\Resumen_Boletas\" & "RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion & "\" & Session.sRucEmp & "-RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion & ".xml"
            'Dim xmlFilename As String = "D:\Documentos_Electronicos\Resumen_Boletas\" & "RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion & "\20100020441-RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion & ".xml"

            UblLarsen.Ubl2.UblBaseDocumentType.GlbCustomizationID = "1.0"

            AmountType.TlsDefaultCurrencyID = "PEN"

            Dim line As SummaryDocumentsLineType() = Nothing

            Dim row As Janus.Windows.GridEX.GridEXRow

            If dgvDatos.RowCount > 0 Then
                Dim cantline As Integer = dgvDatos.RowCount
                line = New SummaryDocumentsLineType(cantline) {}

                For j = 0 To dgvDatos.RowCount - 1
                    Me.dgvDatos.Row = j
                    row = Me.dgvDatos.GetRow()

                    Dim id As String = CStr(row.Cells("CodSerie").Value.ToString + "-" + row.Cells("NumDoc").Value.ToString)
                    Dim idref As String = CStr(row.Cells("CodSerieRef").Value.ToString + "-" + row.Cells("NumDocRef").Value.ToString)

                    Dim TipoDoc As String = CStr(row.Cells("TipoDoc").Value)
                    'Dim TipoDocRef As String = CStr(row.Cells("TipoDocRef").Value)

                    If (TipoDoc = "07" Or TipoDoc = "08") Then

                        line(j) = New SummaryDocumentsLineType() With {
                        .LineID = j + 1,
                        .DocumentTypeCode = CStr(row.Cells("TipoDoc").Value),
                        .ID = id,'row.Cells("CodSerie").Value + "-" + row.Cells("NumDoc").Value,
                        .AccountingCustomerParty = New CustomerPartyType() With {
                        .CustomerAssignedAccountID = CStr(row.Cells("NumDocCli").Value),
                        .AdditionalAccountID = New IdentifierType() {CStr(TipoIdentidad)}
                        },
                        .BillingReference = New BillingReferenceType() {New BillingReferenceType() With {
                         .InvoiceDocumentReference = New DocumentReferenceType() With {
                            .ID = idref,
                            .DocumentTypeCode = CStr(row.Cells("TipoDocRef").Value)
                        }}},
                        .Status = New StatusType() With {
                        .ConditionCode = Convert.ToInt32(row.Cells("Estado").Value)
                        },
                        .TotalAmount = CDec(FormatNumber(row.Cells("TotNeto").Value, 2)),
                        .BillingPayment = New BillingPaymentType() {New BillingPaymentType() With {
                        .PaidAmount = CDec(FormatNumber(row.Cells("TotVenta").Value, 2)),
                        .InstructionID = "01"
                        }},
                        .TaxTotal = New TaxTotalType() {New TaxTotalType() With {
                        .TaxAmount = CDec(FormatNumber(row.Cells("TotIgv").Value, 2)),
                        .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With {
                        .TaxAmount = CDec(FormatNumber(row.Cells("TotIgv").Value, 2)),
                        .TaxCategory = New TaxCategoryType() With {
                        .TaxScheme = New TaxSchemeType() With {
                        .ID = "1000",
                        .Name = "IGV",
                        .TaxTypeCode = "VAT"
                        }
                        }
                        }}
                      }}
                    }

                    Else

                        line(j) = New SummaryDocumentsLineType() With {
                        .LineID = j + 1,
                        .DocumentTypeCode = CStr(row.Cells("TipoDoc").Value),
                        .ID = id,'row.Cells("CodSerie").Value + "-" + row.Cells("NumDoc").Value,
                        .AccountingCustomerParty = New CustomerPartyType() With {
                        .CustomerAssignedAccountID = CStr(row.Cells("NumDocCli").Value),
                        .AdditionalAccountID = New IdentifierType() {CStr(TipoIdentidad)}
                        },
                        .Status = New StatusType() With {
                        .ConditionCode = Convert.ToInt32(row.Cells("Estado").Value)
                        },
                        .TotalAmount = CDec(FormatNumber(row.Cells("TotNeto").Value, 2)),
                        .BillingPayment = New BillingPaymentType() {New BillingPaymentType() With {
                        .PaidAmount = CDec(FormatNumber(row.Cells("TotVenta").Value, 2)),
                        .InstructionID = "01"
                        }},
                        .TaxTotal = New TaxTotalType() {New TaxTotalType() With {
                        .TaxAmount = CDec(FormatNumber(row.Cells("TotIgv").Value, 2)),
                        .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With {
                        .TaxAmount = CDec(FormatNumber(row.Cells("TotIgv").Value, 2)),
                        .TaxCategory = New TaxCategoryType() With {
                        .TaxScheme = New TaxSchemeType() With {
                        .ID = "1000",
                        .Name = "IGV",
                        .TaxTypeCode = "VAT"
                        }
                        }
                        }}
                        }}
                    }

                    End If

                    'line(j) = New SummaryDocumentsLineType() With {
                    '    .LineID = j + 1,
                    '    .DocumentTypeCode = CStr(row.Cells("TipoDoc").Value),
                    '    .ID = id,'row.Cells("CodSerie").Value + "-" + row.Cells("NumDoc").Value,
                    '    .AccountingCustomerParty = New CustomerPartyType() With {
                    '    .CustomerAssignedAccountID = CStr(row.Cells("NumDocCli").Value),
                    '    .AdditionalAccountID = New IdentifierType() {CStr(TipoIdentidad)}
                    '    },
                    '    .Status = New StatusType() With {
                    '        .ConditionCode = "1"
                    '    },
                    '    .TotalAmount = CDec(FormatNumber(row.Cells("TotNeto").Value, 2)),
                    '    .BillingPayment = New BillingPaymentType() {New BillingPaymentType() With {
                    '        .PaidAmount = CDec(FormatNumber(row.Cells("TotVenta").Value, 2)),
                    '        .InstructionID = "01"
                    '    }},
                    '    .TaxTotal = New TaxTotalType() {New TaxTotalType() With {
                    '        .TaxAmount = CDec(FormatNumber(row.Cells("TotIgv").Value, 2)),
                    '        .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With {
                    '            .TaxAmount = CDec(FormatNumber(row.Cells("TotIgv").Value, 2)),
                    '            .TaxCategory = New TaxCategoryType() With {
                    '                .TaxScheme = New TaxSchemeType() With {
                    '                    .ID = "1000",
                    '                    .Name = "IGV",
                    '                    .TaxTypeCode = "VAT"
                    '                }
                    '            }
                    '        }}
                    '    }}
                    '}

                Next

            End If
            '==============================================================================================================================Fin Codigo InvoiceLine

            '==============================================================================================================================Inicio Codigo GenerarXML

            'Dim Hoy As DateTime = DateTime.Today

            'Dim file As String = "D:\Certificado\20100020441-RC-20150904-1.xml"

            FacturacionElectronica.GenerarSummaryDocument(xmlFilename, Session.sRucEmp, Session.sDesEmp, "PEN", "RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion, cbFecha.Value, cbFecha.Value, line)

            '==============================================================================================================================Fin Codigo GenerarXML

            FirmadoDigital()

        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub FirmadoDigital()
        Try
            Dim ObjLib As New FirmarDocumento

            Dim direccion As String
            Dim firmado As Boolean
            direccion = "D:\Documentos_Electronicos\Resumen_Boletas\" & "RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion & "\" & Session.sRucEmp & "-RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion & ".xml"
            'direccion = "D:\Documentos_Electronicos\Resumen_Boletas\" & "RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion & "\20100020441-RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion & ".xml"

            Dim ruta As String = System.AppDomain.CurrentDomain.BaseDirectory & "Certificado\" & Session.sNombreCertificado
            'Dim ruta As String = System.AppDomain.CurrentDomain.BaseDirectory & "Certificado\CertificadoFacturacion.pfx"
            'firmado = ObjLib.SignXmlFile("20100020441", "D:\Documentos_Electronicos\xadesnettest.p12", "xadesnet", direccion)
            'firmado = ObjLib.SignXmlFile("20100020441", 4, ruta, "DdperU", direccion)
            firmado = FirmarDocumento.SignXmlFile(Session.sRucEmp, 4, ruta, Session.sClaveCertificado, direccion)
            'firmado = FirmarDocumento.SignXmlFile(RucEmp, 4, ruta, "DdperU", direccion)

            If firmado = True Then
                'MsgBox("Se genero el firmado", MsgBoxStyle.Information)

                Dim xmlDoc As New XmlDocument
                xmlDoc.Load("D:\Documentos_Electronicos\Resumen_Boletas\" & "RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion & "\" & Session.sRucEmp & "-RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion & ".xml")
                'xmlDoc.Load("D:\Documentos_Electronicos\Resumen_Boletas\" & "RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion & "\20100020441-RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion & ".xml")

                Dim insertar As Boolean
                'Dim nombrexml As String = GridEX1.CurrentRow.Cells("NumDoc").Text & ".xml"     'Comentado para que en el evento de descargar se obtenga el numdoc sin el ".xml"
                Dim nombrexml As String = Session.sRucEmp & "-RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion '& ".xml"
                'Dim nombrexml As String = "20100020441-RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion '& ".xml"
                'insertar = oBoletaDigitalService.Insertar(IdBoleta, nombrexml, xmlDoc.OuterXml, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                Comprimir()

                Dim resulenvio As String
                Dim rutaenvio As String = "D:\Documentos_Electronicos\Resumen_Boletas\" & "RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion & "\"
                'Dim file As String = Session.sRucEmp & "-RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion & ".ZIP"
                'Dim file As String = "20100020441-RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion & ".ZIP"
                'Dim file As String = "20100020441-RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion ' & ".ZIP"
                Dim file As String = Session.sRucEmp & "-RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion

                '=====================================================================
                'If Session.sCodEmp = "01" Then
                '    'resulenvio = oCommunicationState.EnviarSummarySunat(rutaenvio, file)                    
                '    resulenvio = EnviarSunat21.EnviarResumenBoletasOSE(Session.sRucEmp, Session.sUsuarioOSE, Session.sClaveOSE, rutaenvio, file)
                'Else
                '    resulenvio = EnviarSunat21.EnviarResumenBoletasProduccion(Session.sRucEmp, Session.sUsuarioSunat, Session.sClaveSunat, rutaenvio, file)
                'End If

                If Session.sAplicaOSE Then
                    resulenvio = EnviarSunat21.EnviarResumenBoletasOSE(Session.sRucEmp, Session.sUsuarioOSE, Session.sClaveOSE, rutaenvio, file)
                Else
                    resulenvio = EnviarSunat21.EnviarResumenBoletasProduccion(Session.sRucEmp, Session.sUsuarioSunat, Session.sClaveSunat, rutaenvio, file)
                End If


                If resulenvio <> "" Then

                    'Dim xmlDocR As New XmlDocument
                    'xmlDocR.Load("D:\Documentos_Electronicos\Resumen_Boletas\" & "RC-" & cbFecha.Value.ToString("dd-MM-yyyy") & "-" & IdNumeracion & "\R-20100020441-RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion & ".xml")

                    ''/////////OBTENER ESTADO E INFORMACION DEL CDR SUNAT/////////////////////////
                    'Dim namespaces As XmlNamespaceManager = New XmlNamespaceManager(xmlDocR.NameTable)
                    'namespaces.AddNamespace("ar", "urn:oasis:names:specification:ubl:schema:xsd:ApplicationResponse-2")
                    'namespaces.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")
                    'namespaces.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")
                    'namespaces.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#")
                    'namespaces.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")
                    'namespaces.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/")

                    'Dim notecompilado As String = ""
                    'Dim contador As Integer = 0
                    'Dim xnList As XmlNodeList = xmlDocR.SelectNodes("/ns:ApplicationResponse/cbc:Note", namespaces)
                    'For Each xn As XmlNode In xnList
                    '    notecompilado = notecompilado & xnList.Item(contador).InnerText & ". " & Environment.NewLine
                    '    contador = contador + 1
                    'Next
                    'Dim xPathString = "/ar:ApplicationResponse/cac:DocumentResponse/cac:Response/cbc:Description"
                    'Dim xPathString2 = "/ar:ApplicationResponse/cac:DocumentResponse/cac:Response/cbc:ResponseCode"
                    ''Dim xPathString3 = "/ar:ApplicationResponse/cbc:ID"
                    'Dim oNode = xmlDocR.SelectSingleNode(xPathString, namespaces)
                    'Dim oNode2 = xmlDocR.SelectSingleNode(xPathString2, namespaces)
                    ''Dim oNode3 = xmlDocR.SelectSingleNode(xPathString3, namespaces)
                    'Dim Descripcioncdr As String = oNode.InnerText
                    'Dim Responsecode = oNode2.InnerText
                    'Dim NumTicket As String = oNode3.InnerText
                    '///////////////////////////////////////////////////////////////////////////

                    'Dim rutapdf As New FileStream("D:\Documentos_Electronicos\Facturas_Electronicas\" & Documento & "\20100020441-01-" & Documento & ".pdf", FileMode.Open, FileAccess.Read)
                    'Dim binario(rutapdf.Length) As Byte
                    'rutapdf.Read(binario, 0, rutapdf.Length) 'Leo el archivo y lo convierto a binario
                    'rutapdf.Close()

                    Dim registro As New ResumenBoletasDigitalService.ResumenBoletasDigital
                    Dim empresa As New ResumenBoletasDigitalService.Empresa
                    'Dim factura As New FacturaDigitalService.Factura

                    registro.CDRxml = "" 'xmlDocR.OuterXml
                    registro.CodUsu = Session.sCodUsu
                    registro.DirIp = Session.sDirIp
                    empresa.CodEmp = Session.sCodEmp
                    registro.Empresa = empresa
                    registro.DocumentoXml = xmlDoc.OuterXml
                    registro.Estado = ""
                    registro.Fecha = cbFecha.Value
                    registro.IdResumen = "RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion
                    registro.NombreXml = nombrexml
                    registro.NomPc = Session.sNomPc
                    registro.Notas = "" 'notecompilado
                    registro.NumTicket = resulenvio
                    registro.Observacion = "" 'Descripcioncdr

                    insertar = oResumenBoletaDigitalService.Insertar(registro)

                    If insertar Then
                        MsgBox("Se generó el resumen electrónico correctamente", MsgBoxStyle.Information)
                        EstadoEnvio = True
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If
                Else
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Comprimir()

        Dim destdir As String = "D:\Documentos_Electronicos\Resumen_Boletas\" & "RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion & "\" & Session.sRucEmp & "-RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion & ".zip"
        'Dim destdir As String = "D:\Documentos_Electronicos\Resumen_Boletas\" & "RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion & "\20100020441-RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion & ".zip"

        Dim zip As ZipFile = New ZipFile
        Dim directorio As String = "D:\Documentos_Electronicos\Resumen_Boletas\" & "RC-" & cbFecha.Value.ToString("yyyyMMdd") & "-" & IdNumeracion
        zip.AddDirectory(directorio)
        zip.Save(destdir)
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click, cbFecha.ValueChanged
        ListarDetalles()
    End Sub

End Class