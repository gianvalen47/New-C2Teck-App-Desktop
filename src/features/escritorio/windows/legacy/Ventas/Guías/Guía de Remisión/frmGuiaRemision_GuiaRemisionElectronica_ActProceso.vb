Imports ZXing
Imports ZXing.PDF417
Imports ZXing.PDF417.Internal
Imports System.ServiceModel
Imports System.Xml
Imports System.IO
Imports FacturarSunat21.aplicacion
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmGuiaRemision_GuiaRemisionElectronica_ActProceso

    Private oGuiaRemisionDigitalService As New GuiaRemisionDigitalService.GuiaRemisionDigitalServiceClient

    Public opcion As String    'Detallado o Resumido
    Public mostrarprecio As Boolean
    Public IdGuiaRem As Integer
    Public NumDocGuiaRem As String
    Public GuiaPreexistente As Boolean
    Public DocumentoRef As String
    Public CodSunatRef As String
    Public DesDocRef As String

    'Pre Impresion
    Public opcionimp As String
    'Public mostrarPrecio As String
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
    'Dim Documento As String
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

    '========================================

    Private oGuiaRemisionService As New GuiaRemisionService.GuiaRemisionServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    Public IdGuiaPreImpresion As Integer


    '===========================================================================================

    Public pIdGuia As String
    Public pCodSerie As String
    Public pNumDoc As String
    Public Documento As String
    Public ticket As String
    'Dim UbicacionCodBarra As String

    Private Sub frmGuiaRemision_GuiaRemisionElectronica_ActProceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        rbDetalle.Checked = True
        'lblguia.Visible = False
        'txtNumGuia.Visible = False
        'btnBuscarguia.Visible = False
        cbMostrarMensaje.Checked = False

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Try

            If rbDetalle.Checked And cbNoCodigo.Checked = False Then
                opcionimp = "DetalladoCod"
            ElseIf rbDetalle.Checked And cbNoCodigo.Checked = True Then
                opcionimp = "DetalladoNoCod"
            ElseIf rbResumen.Checked Then
                opcionimp = "Resumido"
            ElseIf rbObservacion.Checked Then
                opcionimp = "Observacion"
            End If
            mostrarprecio = cbMostrarMensaje.Checked
            'GuiaPreexistente = cbOpcion.Checked


            Dim insertar As Boolean

            Dim rutaenvio As String = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\"
            Dim file As String = ""
            file = Session.sRucEmp & "-09-" & Documento & ".zip"





            '////////////GENERAR TOKEN///////////////
            Dim respuesta As New ConectarAPISUNAT.RespuestaToken()
            Dim userSOL As String = Session.sRucEmp & Session.sUsuarioSunat
            respuesta = ConectarAPISUNAT.GenerarTokenSunat(Session.sUrlApiSunat, Session.sIdApiSunat, Session.sClaveApiSunat, userSOL, Session.sClaveSunat)
            '////////////////////////////////////////

            '/////////CONSULTAR EL NUMERO DE TICKET///////////////
            Dim respuestaTicket As New ConectarAPISUNAT.ResponseConsultarGre()
            Dim url As String = "https://api-cpe.sunat.gob.pe/v1/contribuyente/gem/comprobantes/envios/" & ticket
            respuestaTicket = ConectarAPISUNAT.ObtenerCDR(file, url, respuesta.access_token, ticket)
            '////////////////////////////////////////////////////////////////////////




            'Dim respuestaTicket As New ConectarAPISUNAT.ResponseConsultarGre()
            'respuestaTicket.codRespuesta = "0"
            'respuestaTicket.indCdrGenerado = 1




            If respuestaTicket.codRespuesta = "0" And respuestaTicket.indCdrGenerado = 1 Then
                Dim fileCDR As String = Session.sRucEmp & "-09-" & Documento
                ConectarAPISUNAT.ConvertirCDR(respuestaTicket.arcCdr, rutaenvio, fileCDR)




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
                Dim Responsecode = oNode2.InnerText
                Dim NumTicket As String = oNode3.InnerText
                Dim UrlLink As String = oNode4.InnerText

                '================================================
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

                CrearPDF()

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
                registro.DocumentoXml = Nothing
                registro.Estado = Responsecode
                guiaremision.IdGuia = pIdGuia
                registro.GuiaRemision = guiaremision
                registro.NombreXml = Nothing
                registro.NomPc = Session.sNomPc
                registro.NumTicket = NumTicket
                registro.Observacion = Descripcioncdr
                registro.Notas = toNull(notecompilado)
                registro.DocumentoPdf = binario
                registro.IdGuiaRef = Nothing
                registro.UrlLink = UrlLink
                insertar = oGuiaRemisionDigitalService.ActualizarProceso(registro)

                If insertar Then
                    MsgBox("Se proceso la guia de remision electronica correctamente", MsgBoxStyle.Information)

                    '//////////ENVIAR CORREO/////////
                    Dim frm1 As New frmGuiaRemision_GuiaRemisionElectronica
                    frm1.IdGuiaReg = pIdGuia
                    frm1.Documento = Documento
                    frm1.enProceso = True
                    If frm1.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                        Me.DialogResult = System.Windows.Forms.DialogResult.OK

                    End If
                    '////////////////////////////////
                End If


            Else

                If respuestaTicket.codRespuesta = "99" Then 'ERROR

                    MsgBox("Codigo Error: " + respuestaTicket.Error.numError + "     Descripcion: " + respuestaTicket.Error.desError, MsgBoxStyle.Information)

                    oGuiaRemisionDigitalService.Borrar(pIdGuia, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    'listaDatos()
                    'RowPossesion(dgvDatos, pIdGuia)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK

                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Actualizar Respuesta de Ticket")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try

    End Sub

    Private Sub CrearPDF()


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

            dtReporte = oGuiaRemisionService.ImprimirDigital(pIdGuia).Tables(0)
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
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2DetNoCod()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaNoCodigo

            dtReporte = oGuiaRemisionService.ImprimirDigital(pIdGuia).Tables(0)
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
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2Res()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaResumido

            dtReporte = oGuiaRemisionService.ImprimirDigital(pIdGuia).Tables(0)
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
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2Obs()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaObservacion

            dtReporte = oGuiaRemisionService.ImprimirDigital(pIdGuia).Tables(0)
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
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)
            End If

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

            dtReporte = oGuiaRemisionService.ImprimirDigital(pIdGuia).Tables(0)
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
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2DetNoCodMtuAmazonica()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaMtuAmazNoCodigo

            dtReporte = oGuiaRemisionService.ImprimirDigital(pIdGuia).Tables(0)
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
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2ResMtuAmazonica()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaMtuAmazResumido

            dtReporte = oGuiaRemisionService.ImprimirDigital(pIdGuia).Tables(0)
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
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2ObsMtuAmazonica()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaMtuAmazObservacion

            dtReporte = oGuiaRemisionService.ImprimirDigital(pIdGuia).Tables(0)
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
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)
            End If

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

            dtReporte = oGuiaRemisionService.ImprimirDigital(pIdGuia).Tables(0)
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
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2DetNoCodEquimap()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaEquimapNoCodigo

            dtReporte = oGuiaRemisionService.ImprimirDigital(pIdGuia).Tables(0)
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
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2ResEquimap()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaEquimapResumido

            dtReporte = oGuiaRemisionService.ImprimirDigital(pIdGuia).Tables(0)
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
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
    Private Sub CrearPDF2ObsEquimap()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaEquimapObservacion

            dtReporte = oGuiaRemisionService.ImprimirDigital(pIdGuia).Tables(0)
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
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)
            End If

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

            dtReporte = oGuiaRemisionService.ImprimirDigital(pIdGuia).Tables(0)
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
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
    Private Sub CrearPDF2DetNoCodC2Teck()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaC2TeckNoCodigo

            dtReporte = oGuiaRemisionService.ImprimirDigital(pIdGuia).Tables(0)
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
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2ResC2Teck()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaC2TeckResumido

            dtReporte = oGuiaRemisionService.ImprimirDigital(pIdGuia).Tables(0)
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
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2ObsC2Teck()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaC2TeckObservacion

            dtReporte = oGuiaRemisionService.ImprimirDigital(pIdGuia).Tables(0)
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
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)
            End If

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

            dtReporte = oGuiaRemisionService.ImprimirDigital(pIdGuia).Tables(0)
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
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2DetNoCodC2TeckIM()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaC2TeckIMNoCodigo

            dtReporte = oGuiaRemisionService.ImprimirDigital(pIdGuia).Tables(0)
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
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

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

    Private Sub CrearPDF2ResC2TeckIM()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaC2TeckIMResumido

            dtReporte = oGuiaRemisionService.ImprimirDigital(pIdGuia).Tables(0)
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
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2ObsC2TeckIM()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirGuiaElectronicaC2TeckIMObservacion

            dtReporte = oGuiaRemisionService.ImprimirDigital(pIdGuia).Tables(0)
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
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "false")
                ExportToPDF(reporte, "miReporte.pdf", Documento)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    ' ---------------------------------------------------------------------------- FIN C2TECK INFORMATICA Y METALURGICA -----------------------------------------------------------


    Private Sub frmGuiaRemision_GuiaRemisionElectronica_ActProceso_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    'Private Sub btnBuscarguia_Click(sender As Object, e As EventArgs)
    '    Dim frm As New frmGuiaRemision_Electronica_BuscarGuia
    '    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '        IdGuiaRem = frm.codigo
    '        NumDocGuiaRem = frm.numero
    '        txtNumGuia.Text = frm.numero
    '        DocumentoRef = frm.docref
    '        CodSunatRef = frm.codsunatref
    '        DesDocRef = frm.desdocref
    '    End If
    'End Sub

    'Private Sub cbOpcion_CheckedChanged(sender As Object, e As EventArgs)
    '    If cbOpcion.Checked Then
    '        lblguia.Visible = True
    '        txtNumGuia.Visible = True
    '        btnBuscarguia.Visible = True
    '        txtNumGuia.Text = ""
    '        IdGuiaRem = 0
    '        NumDocGuiaRem = ""
    '    Else
    '        lblguia.Visible = False
    '        txtNumGuia.Visible = False
    '        btnBuscarguia.Visible = False
    '        txtNumGuia.Text = ""
    '        IdGuiaRem = 0
    '        NumDocGuiaRem = ""
    '    End If
    'End Sub

End Class