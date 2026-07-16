Imports ZXing
Imports ZXing.PDF417
Imports ZXing.PDF417.Internal
Imports System.ServiceModel
Imports System.Xml
Public Class frmGuiaRemision_Electronica_Imprimir

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
    Dim Documento As String
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

    Private Sub frmGuiaRemision_Electronica_Imprimir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbDetalle.Checked = True
        lblguia.Visible = False
        txtNumGuia.Visible = False
        btnBuscarguia.Visible = False
        cbMostrarMensaje.Checked = False
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        If MsgBox("¿Está seguro de GENERAR la Guía Electronica?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            If rbDetalle.Checked And cbNoCodigo.Checked = False Then
                opcion = "DetalladoCod"
            ElseIf rbDetalle.Checked And cbNoCodigo.Checked = True Then
                opcion = "DetalladoNoCod"
            ElseIf rbResumen.Checked Then
                opcion = "Resumido"
            ElseIf rbObservacion.Checked Then
                opcion = "Observacion"
            End If
            mostrarprecio = cbMostrarMensaje.Checked
            GuiaPreexistente = cbOpcion.Checked
            'oGuiaRemisionService.ActualizarEstadoImpreso(IdGuiaPreImpresion, Session.sCodUsu)
        End If

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmGuiaRemision_Electronica_Imprimir_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End If
    End Sub

    Private Sub btnBuscarguia_Click(sender As Object, e As EventArgs) Handles btnBuscarguia.Click
        Dim frm As New frmGuiaRemision_Electronica_BuscarGuia
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            IdGuiaRem = frm.codigo
            NumDocGuiaRem = frm.numero
            txtNumGuia.Text = frm.numero
            DocumentoRef = frm.docref
            CodSunatRef = frm.codsunatref
            DesDocRef = frm.desdocref
        End If
    End Sub

    Private Sub cbOpcion_CheckedChanged(sender As Object, e As EventArgs) Handles cbOpcion.CheckedChanged
        If cbOpcion.Checked Then
            lblguia.Visible = True
            txtNumGuia.Visible = True
            btnBuscarguia.Visible = True
            txtNumGuia.Text = ""
            IdGuiaRem = 0
            NumDocGuiaRem = ""
        Else
            lblguia.Visible = False
            txtNumGuia.Visible = False
            btnBuscarguia.Visible = False
            txtNumGuia.Text = ""
            IdGuiaRem = 0
            NumDocGuiaRem = ""
        End If
    End Sub

    Private Sub btnPreImpresion_Click(sender As Object, e As EventArgs) Handles btnPreImpresion.Click

        Try
            Dim dtReporte As New DataTable
            Dim dtImprimirDigital As New DataTable

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuiaPreImpresion).Tables(0)
            'DataGridView1.DataSource = dtReporte
            GridEX1.DataSource = dtReporte

            If rbDetalle.Checked And cbNoCodigo.Checked = False Then
                opcion = "DetalladoCod"
            ElseIf rbDetalle.Checked And cbNoCodigo.Checked = True Then
                opcion = "DetalladoNoCod"
            ElseIf rbResumen.Checked Then
                opcion = "Resumido"
            ElseIf rbObservacion.Checked Then
                opcion = "Observacion"
            End If

            If opcion = "Observacion" Then

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

            mostrarprecio = cbMostrarMensaje.Checked
            IdGuiaRem = IdGuiaRem
            NumDocGuiaRem = NumDocGuiaRem
            GuiaPreexistente = cbOpcion.Checked

            'ObtenerTagFirma()
            CrearPDF()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



    End Sub

    'Private Sub ObtenerTagFirma()

    '    Try
    '        Dim xmlDoc As New XmlDocument
    '        Dim namespaces As XmlNamespaceManager = New XmlNamespaceManager(xmlDoc.NameTable)

    '        namespaces.AddNamespace("ns", "urn:oasis:names:specification:ubl:schema:xsd:DespatchAdvice-2")
    '        namespaces.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance")
    '        namespaces.AddNamespace("xsd", "http://www.w3.org/2001/XMLSchema")
    '        namespaces.AddNamespace("sac", "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")
    '        namespaces.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")
    '        namespaces.AddNamespace("qdt", "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2")
    '        namespaces.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")
    '        namespaces.AddNamespace("udt", "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2")
    '        namespaces.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")
    '        namespaces.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#")

    '        xmlDoc.Load("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\20100020441-09-" & Documento & ".xml")

    '        Dim xPathStringInfo = "/ns:DespatchAdvice/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent/ds:Signature[@Id='SignatureSP']/ds:SignedInfo"
    '        Dim xPathStringValue = "/ns:DespatchAdvice/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent/ds:Signature[@Id='SignatureSP']/ds:SignatureValue"

    '        Dim oNodeInfo = xmlDoc.SelectSingleNode(xPathStringInfo, namespaces)
    '        ValorResumen = oNodeInfo.InnerText

    '        Dim oNodeValue = xmlDoc.SelectSingleNode(xPathStringValue, namespaces)
    '        ValorFirma = oNodeValue.InnerText

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Obtener el Tag")
    '    End Try

    'End Sub

    Private Sub CrearPDF()
        Try
            CrearPDF2()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub CrearPDF2()

        If Session.sCodEmp = "01" Then
            If opcion = "DetalladoCod" Then
                CrearPDF2Det()
            ElseIf opcion = "DetalladoNoCod" Then
                CrearPDF2DetNoCod()
            ElseIf opcion = "Resumido" Then
                CrearPDF2Res()
            ElseIf opcion = "Observacion" Then
                CrearPDF2Obs()
            End If
        ElseIf Session.sCodEmp = "02" Then
            If opcion = "DetalladoCod" Then
                CrearPDF2DetMtuAmazonica()
            ElseIf opcion = "DetalladoNoCod" Then
                CrearPDF2DetNoCodMtuAmazonica()
            ElseIf opcion = "Resumido" Then
                CrearPDF2ResMtuAmazonica()
            ElseIf opcion = "Observacion" Then
                CrearPDF2ObsMtuAmazonica()
            End If

        ElseIf Session.sCodEmp = "05" Then
            If opcion = "DetalladoCod" Then
                CrearPDF2DetEquimap()
            ElseIf opcion = "DetalladoNoCod" Then
                CrearPDF2DetNoCodEquimap()
            ElseIf opcion = "Resumido" Then
                CrearPDF2ResEquimap()
            ElseIf opcion = "Observacion" Then
                CrearPDF2ObsEquimap()
            End If

        ElseIf Session.sCodEmp = "07" Then
            If opcion = "DetalladoCod" Then
                CrearPDF2DetC2Teck()
            ElseIf opcion = "DetalladoNoCod" Then
                CrearPDF2DetNoCodC2Teck()
            ElseIf opcion = "Resumido" Then
                CrearPDF2ResC2Teck()
            ElseIf opcion = "Observacion" Then
                CrearPDF2ObsC2Teck()
            End If
        ElseIf Session.sCodEmp = "08" Then
            If opcion = "DetalladoCod" Then
                CrearPDF2DetC2TeckIM()
            ElseIf opcion = "DetalladoNoCod" Then
                CrearPDF2DetNoCodC2TeckIM()
            ElseIf opcion = "Resumido" Then
                CrearPDF2ResC2TeckIM()
            ElseIf opcion = "Observacion" Then
                CrearPDF2ObsC2TeckIM()
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
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'ExportToPDF(reporte, "miReporte.pdf", Documento)
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Guia Remision Electronica"
                forma.ShowDialog()

            End If

            'ListarArchivos()

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
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'ExportToPDF(reporte, "miReporte.pdf", Documento)
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Guia Remision Electronica"
                forma.ShowDialog()

            End If

            'ListarArchivos()

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
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'ExportToPDF(reporte, "miReporte.pdf", Documento)
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Guia Remision Electronica"
                forma.ShowDialog()

            End If
            'ListarArchivos()

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
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'ExportToPDF(reporte, "miReporte.pdf", Documento)
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Guia Remision Electronica"
                forma.ShowDialog()

            End If
            'ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

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
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'ExportToPDF(reporte, "miReporte.pdf", Documento)
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Guia Remision Electronica"
                forma.ShowDialog()

            End If

            'ListarArchivos()

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
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'ExportToPDF(reporte, "miReporte.pdf", Documento)
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Guia Remision Electronica"
                forma.ShowDialog()

            End If

            'ListarArchivos()

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
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'ExportToPDF(reporte, "miReporte.pdf", Documento)
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Guia Remision Electronica"
                forma.ShowDialog()

            End If
            'ListarArchivos()

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
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                'reporte.SetParameterValue("MostrarBanco", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'ExportToPDF(reporte, "miReporte.pdf", Documento)
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Guia Remision Electronica"
                forma.ShowDialog()

            End If
            'ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

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
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Guia Remision Electronica"
                forma.ShowDialog()

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

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Guia Remision Electronica"
                forma.ShowDialog()
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

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Guia Remision Electronica"
                forma.ShowDialog()
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

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Guia Remision Electronica"
                forma.ShowDialog()

            End If
            'ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    '========================= C2TECK

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
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Guia Remision Electronica"
                forma.ShowDialog()

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

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Guia Remision Electronica"
                forma.ShowDialog()
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

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Guia Remision Electronica"
                forma.ShowDialog()
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

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Guia Remision Electronica"
                forma.ShowDialog()

            End If
            'ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    '===================== C2TECK

    '========================= C2TECK INFORMATICA Y METALURGICA

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
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Guia Remision Electronica"
                forma.ShowDialog()

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

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Guia Remision Electronica"
                forma.ShowDialog()
            End If

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
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Guia Remision Electronica"
                forma.ShowDialog()
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

            dtReporte = oGuiaRemisionService.ImprimirDigital(IdGuia).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("MostrarPrecio", IIf(mostrarprecio = True, "true", "false"))
                reporte.SetParameterValue("GuiaRemisionRef", IIf(GuiaPreexistente, NumDocGuiaReg, ""))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Guia Remision Electronica"
                forma.ShowDialog()

            End If
            'ListarArchivos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    '===================== C2TECK INFORMATICA Y METALURGICA

    Private Sub rbDetalle_CheckedChanged(sender As Object, e As EventArgs) Handles rbDetalle.CheckedChanged, rbResumen.CheckedChanged, rbObservacion.CheckedChanged

        If rbDetalle.Checked Then
            cbMostrarMensaje.Enabled = True
            cbNoCodigo.Enabled = True
        ElseIf rbResumen.Checked Then
            cbMostrarMensaje.Enabled = True
            cbNoCodigo.Enabled = False
        ElseIf rbObservacion.Checked Then
            cbMostrarMensaje.Enabled = False
            cbMostrarMensaje.Checked = False
            cbNoCodigo.Enabled = False
        End If

    End Sub

    Private Sub frmGuiaRemision_Electronica_Imprimir_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oGuiaRemisionService.Close()
        Catch ex As TimeoutException
            oMaestroService.Close()
            oGuiaRemisionService.Close()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oGuiaRemisionService.Abort()
        End Try
    End Sub
End Class