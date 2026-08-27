
Imports System.ServiceModel
Public Class frmFactura_FacturaElectronica_Imprimir

    Public state As Boolean
    Public opcion As String    'Detallado o Resumido

    '================= Pre Impresion ========
    Private oFacturaService As New FacturaService.FacturaServiceClient
    Private oTesoreriaService As New TesoreriaService.TesoreriaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oDocCtaCte As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient

    Public IdFactura As Integer
    Public IdFacturaPreImpresion As Integer
    Public EstadoSunat As Boolean
    Private VerFactura As Boolean
    Private dtImprimirDigital As DataTable
    Public MostrarBanco As Boolean
    Public opcionimp As String
    Public TotalSoles As String
    Private dtSubreporte As DataTable
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
    Dim TotBruto As Double
    Dim TotVenta As Double
    Dim CodMot As String
    Dim LineExtensionAmount As Double
    Dim Price As Double
    Dim TaxAmount As Double
    Dim TotGasto As Double
    Dim CodOtroTributoDesc As String
    Dim TotDscto As Double
    Dim LegalMonetaryTotal As Double
    Dim CurrencyId As String
    Dim NumGuis As String
    Dim CodGuia As String
    Dim Item As Integer
    Dim CodMer As String
    Dim EmpresaTrans As String
    Dim RucTrans As String
    Dim Vehiculo As String
    Dim Placa As String
    Dim Chofer As String
    Dim Licencia As String
    Dim ConIns As String
    Dim Observacion As String
    Dim CodMon As String
    Dim InstructionID As String
    Dim UbicacionCodBarra As String
    Dim ValorResumen As String
    Dim ValorFirma As String
    Dim Responsecode As String
    Dim DireccionFiscal As String
    Dim CodUbigeoRec As String
    Dim NomDistRec As String
    Dim NomProvRec As String
    Dim NomDptoRec As String
    Dim WebEmp As String
    Dim CorEmp As String
    Dim NumOrden As String
    Dim TotNetoLetras As String
    Dim CodEstablecimiento As String
    Dim FormaPago As String
    Dim CodPag As String
    Dim Igv As Double



    Private Sub frmFactura_FacturaElectronica_Imprimir_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End If
    End Sub

    Private Sub frmFactura_FacturaElectronica_Imprimir_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cbMostrarMensaje.Checked = False
        rbDetalle.Checked = True
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        state = cbMostrarMensaje.Checked
        If rbDetalle.Checked Then
            opcion = "Detallado"
        ElseIf rbResumen.Checked Then
            opcion = "Resumido"
        End If

        Dim dtReporte As New DataTable
        Dim dtImprimirDigital As New DataTable

        dtReporte = oFacturaService.ImprimirDigital(IdFacturaPreImpresion).Tables(0)
        'DataGridView1.DataSource = dtReporte
        GridEX1.DataSource = dtReporte

        Dim existecuotas As Double
        Dim MostrarBanco As Boolean
        Dim opcionimp As String
        Dim FecDoc As Date = GridEX1.CurrentRow.Cells("FecDoc").Value
        Dim CodMon As String = GridEX1.CurrentRow.Cells("CodMon").Text
        Dim CodPag As String = GridEX1.CurrentRow.Cells("CodPag").Text

        Dim fecVencimiento As Date = oDocCtaCte.CalcularFecVen(CodPag, FecDoc)
        'Dim TotNeto As Decimal
        'TotNeto = Math.Round(GridEX1.CurrentRow.Cells("TotNeto").Value, 2)
        TotNeto = Math.Round(TotNeto, 2)

        '======================================================= CODIGO ANTES DEL CAMBIO DE CUOTAS EN VENTANA DE IMPRIMIR ===============================

        'Ingreso de Cuotas 

        existecuotas = oFacturaService.ObtenerTotalCuota(IdFacturaPreImpresion)
        'existecuotas = oFacturaService.ObtenerTotalCuota(GridEX1.CurrentRow.Cells("IdFactura").Text)

        'existecuotas = 1 'oFacturaService.ObtenerTotalCuota(dgvDatos.CurrentRow.Cells("IdFactura").Text)

        '=============================================== CONTADO ===================================
        If CodPag = "00" Or CodPag = "25" Then

            If state = True Then
                MostrarBanco = True
            Else
                MostrarBanco = False
            End If
            opcionimp = opcion
            Dim frm1 As New frmFactura_FacturaElectronica
            frm1.IdFactura = IdFacturaPreImpresion
            frm1.MostrarBanco = MostrarBanco
            frm1.opcionimp = opcionimp
            frm1.TotalSoles = TotalSoles
            If frm1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If frm1.EstadoSunat = True Then
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            End If

            '============================== CREDITO SIN CUOTAS ===========================================
        ElseIf existecuotas = 0 And CodPag <> "00" And CodPag <> "25" Then   'cmbTipFac.Value = 1
            'MsgBox("Debe ingresar las cuotas, verifique.", MsgBoxStyle.Information)

            If MsgBox("¿Desea insertar una cuota unica?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then

                Dim registro As New FacturaService.FacturaCuotas
                Dim empresa As New FacturaService.Empresa
                Dim factura As New FacturaService.Factura

                registro.NumeroCuota = 1
                registro.MontoCuota = TotNeto
                registro.FecVencimiento = fecVencimiento

                factura.IdFactura = IdFacturaPreImpresion 'GridEX1.CurrentRow.Cells("IdFactura").Text
                registro.Factura = factura

                registro.FecReg = Date.Today

                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                Dim estado_process As Boolean
                estado_process = oFacturaService.InsertarCuota(registro)

                'If estado_process Then

                If state = True Then
                    MostrarBanco = True
                Else
                    MostrarBanco = False
                End If
                opcionimp = opcion

                Dim frm2 As New frmFactura_FacturaElectronica
                frm2.IdFactura = IdFacturaPreImpresion 'GridEX1.CurrentRow.Cells("IdFactura").Text
                frm2.MostrarBanco = MostrarBanco
                    frm2.opcionimp = opcionimp
                    frm2.TotalSoles = TotalSoles
                    If frm2.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                        If frm2.EstadoSunat = True Then
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If
                    End If
                'Else
                '    Exit Sub
                'End If

                'End If

            Else

                'MsgBox("Debe ingresar las cuotas, verifique.", MsgBoxStyle.Information)

                Dim frm4 As New frmFactura_Cuotas
                frm4.IdFactura = IdFacturaPreImpresion
                frm4.FecDoc = FecDoc
                frm4.TotNeto = CDbl(TotNeto)
                frm4.CodPag = CodPag
                frm4.ShowDialog()

            End If

        Else
            '============================== CREDITO CON CUOTAS ===========================================
            'If existecuotas <> TotNeto Then
            '    MsgBox("Las cuotas no coinciden con el total, verifique.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            If state = True Then
                MostrarBanco = True
            Else
                MostrarBanco = False
            End If
            opcionimp = opcion

            If existecuotas <> TotNeto Then
                MsgBox("Las cuotas no coinciden con el total, verifique.", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim frm1 As New frmFactura_FacturaElectronica
            frm1.IdFactura = IdFacturaPreImpresion  'GridEX1.CurrentRow.Cells("IdFactura").Text
            frm1.MostrarBanco = MostrarBanco
            frm1.opcionimp = opcionimp
            frm1.TotalSoles = TotalSoles
            If frm1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If frm1.EstadoSunat = True Then
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            End If

        End If

    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnPreImpresion_Click(sender As Object, e As EventArgs) Handles btnPreImpresion.Click

        Try
            Dim dtReporte As New DataTable
            Dim dtImprimirDigital As New DataTable

            dtReporte = oFacturaService.ImprimirDigital(IdFacturaPreImpresion).Tables(0)
            'DataGridView1.DataSource = dtReporte
            GridEX1.DataSource = dtReporte
            'DataGridView1.DataSource = dtReporte

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
            TotBruto = GridEX1.CurrentRow.Cells("TotBruto").Text
            TotVenta = GridEX1.CurrentRow.Cells("TotVenta").Text
            CodMot = GridEX1.CurrentRow.Cells("CodMot").Text
            LineExtensionAmount = GridEX1.CurrentRow.Cells("LineExtensionAmount").Text
            Price = GridEX1.CurrentRow.Cells("Price").Text
            TaxAmount = GridEX1.CurrentRow.Cells("TaxAmount").Text
            TotGasto = GridEX1.CurrentRow.Cells("TotGasto").Text
            CodOtroTributoDesc = GridEX1.CurrentRow.Cells("CodOtroTributoDesc").Text
            TotDscto = GridEX1.CurrentRow.Cells("TotDscto").Text
            LegalMonetaryTotal = GridEX1.CurrentRow.Cells("LegalMonetaryTotal").Text
            CurrencyId = GridEX1.CurrentRow.Cells("CurrencyId").Text
            NumGuis = GridEX1.CurrentRow.Cells("NumGuis").Text
            CodGuia = GridEX1.CurrentRow.Cells("CodGuia").Text
            Item = GridEX1.CurrentRow.Cells("Item").Text
            CodMer = GridEX1.CurrentRow.Cells("CodMer").Text
            EmpresaTrans = GridEX1.CurrentRow.Cells("EmpresaTrans").Text
            RucTrans = GridEX1.CurrentRow.Cells("RucTrans").Text
            Vehiculo = GridEX1.CurrentRow.Cells("Vehiculo").Text
            Placa = GridEX1.CurrentRow.Cells("Placa").Text
            Chofer = GridEX1.CurrentRow.Cells("Chofer").Text
            Licencia = GridEX1.CurrentRow.Cells("Licencia").Text
            ConIns = GridEX1.CurrentRow.Cells("ConIns").Text
            Observacion = GridEX1.CurrentRow.Cells("Observacion").Text
            CodMon = GridEX1.CurrentRow.Cells("CodMon").Text
            InstructionID = GridEX1.CurrentRow.Cells("InstructionID").Text
            WebEmp = GridEX1.CurrentRow.Cells("WebEmp").Text
            CorEmp = GridEX1.CurrentRow.Cells("CorEmp").Text

            DireccionFiscal = GridEX1.CurrentRow.Cells("DireccionFiscal").Text
            CodUbigeoRec = GridEX1.CurrentRow.Cells("CodUbigeoRec").Text
            NomDistRec = GridEX1.CurrentRow.Cells("NomDistRec").Text
            NomProvRec = GridEX1.CurrentRow.Cells("NomProvRec").Text
            NomDptoRec = GridEX1.CurrentRow.Cells("NomDptoRec").Text
            NumOrden = GridEX1.CurrentRow.Cells("NumOrden").Text
            CodEstablecimiento = GridEX1.CurrentRow.Cells("CodEstablecimiento").Text
            FormaPago = GridEX1.CurrentRow.Cells("FormaPago").Text
            CodPag = GridEX1.CurrentRow.Cells("CodPag").Text
            Igv = GridEX1.CurrentRow.Cells("Igv").Text

            TotNetoLetras = oTesoreriaService.ConvierteNumLetraConta(GridEX1.CurrentRow.Cells("LegalMonetaryTotal").Text)

            'CrearCarpeta()

            If rbDetalle.Checked Then
                opcion = "Detallado"
            ElseIf rbResumen.Checked Then
                opcion = "Resumido"
            End If
            If cbMostrarMensaje.Checked Then
                MostrarBanco = True
            Else
                MostrarBanco = False
            End If

            CrearPDF()

            'If opcionimp = "Detallado" Then
            '    'CrearXMLSerializadoDet()
            '    CrearXmlDetalle21()
            'ElseIf opcionimp = "Resumido" Then
            '    'CrearXMLSerializadoRes()
            '    CrearXmlResumen21()
            'End If

            'If Session.sCodEmp = "01" Then
            '    CargarCorreo()
            'ElseIf Session.sCodEmp = "02" Then
            '    CargarCorreoMtUAmazonica()
            'ElseIf Session.sCodEmp = "03" Then
            '    CargarCorreoEquimap()
            'ElseIf Session.sCodEmp = "07" Then
            '    CargarCorreoC2Teck()
            'Else
            '    CargarCorreo()
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub CrearPDF()

        Try
            CrearPDF2()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub CrearPDF2()

        If Session.sCodEmp = "01" Then
            If opcion = "Detallado" Then
                CrearPDF2Det()
            ElseIf opcion = "Resumido" Then
                CrearPDF2Res()
            End If
        ElseIf Session.sCodEmp = "02" Then
            If opcion = "Detallado" Then
                CrearPDF2DetMtUAmazonica()
            ElseIf opcion = "Resumido" Then
                CrearPDF2ResMtUAmazonica()
            End If
        ElseIf Session.sCodEmp = "05" Then
            If opcion = "Detallado" Then
                CrearPDF2DetEquimap()
            ElseIf opcion = "Resumido" Then
                CrearPDF2ResEquimap()
            End If

        ElseIf Session.sCodEmp = "07" Then
            If opcion = "Detallado" Then
                CrearPDF2DetC2Teck()
            ElseIf opcion = "Resumido" Then
                CrearPDF2ResC2Teck()
            End If

        ElseIf Session.sCodEmp = "08" Then
            If opcion = "Detallado" Then
                CrearPDF2DetC2TeckIM()
            ElseIf opcion = "Resumido" Then
                CrearPDF2ResC2TeckIM()
            End If

        End If

    End Sub


    Private Sub CrearPDF2Det()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim cuotasrows As Integer
            Dim reporte As New rpImprimirFacturaElectronica
            Dim reporte2 As New rpImprimirFacturaElectronica2
            Dim reporteC As New rpImprimirFacturaElectronicaC

            dtReporte = oFacturaService.ImprimirDigital(IdFacturaPreImpresion).Tables(0)
            dtSubreporte = oFacturaService.MostrarCuota(IdFacturaPreImpresion).Tables(0)
            cuotasrows = dtSubreporte.Rows.Count

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                If cuotasrows = 0 Then

                    reporteC.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteC
                    reporteC.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                    reporteC.SetParameterValue("CodMot", CodMot)
                    'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                    reporteC.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                    reporteC.SetParameterValue("UbicacionCodBarra", "")
                    reporteC.SetParameterValue("MostrarBanco", MostrarBanco)
                    reporteC.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                    reporteC.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                    reporteC.SetParameterValue("VistaPreliminar", "true")
                    forma.Text = "Factura Electronica"
                    forma.ShowDialog()

                ElseIf cuotasrows = 1 Or cuotasrows = 2 Or cuotasrows = 3 Or cuotasrows = 4 Then

                    If reporte.Subreports.Count > 0 Then
                        reporte.Subreports(0).SetDataSource(dtSubreporte)
                    End If

                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                    reporte.SetParameterValue("CodMot", CodMot)
                    'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                    reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                    reporte.SetParameterValue("UbicacionCodBarra", "")
                    reporte.SetParameterValue("MostrarBanco", MostrarBanco)
                    reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                    reporte.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                    reporte.SetParameterValue("VistaPreliminar", "true")
                    forma.Text = "Factura Electronica"
                    forma.ShowDialog()
                Else
                    If reporte2.Subreports.Count > 0 Then
                        reporte2.Subreports(0).SetDataSource(dtSubreporte)
                    End If

                    reporte2.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte2
                    reporte2.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                    reporte2.SetParameterValue("CodMot", CodMot)
                    'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                    reporte2.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                    reporte2.SetParameterValue("UbicacionCodBarra", "")
                    reporte2.SetParameterValue("MostrarBanco", MostrarBanco)
                    reporte2.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                    reporte2.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                    reporte2.SetParameterValue("VistaPreliminar", "true")
                    forma.Text = "Factura Electronica"
                    forma.ShowDialog()

                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2Res()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim cuotasrows As Integer
            Dim reporte As New rpImprimirFacturaElectronicaResumido
            Dim reporte2 As New rpImprimirFacturaElectronicaResumido2
            Dim reporteC As New rpImprimirFacturaElectronicaResumidoCR

            dtReporte = oFacturaService.ImprimirDigital(IdFacturaPreImpresion).Tables(0)
            dtSubreporte = oFacturaService.MostrarCuota(IdFacturaPreImpresion).Tables(0)
            cuotasrows = dtSubreporte.Rows.Count

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                If cuotasrows = 0 Then

                    reporteC.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteC
                    reporteC.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                    reporteC.SetParameterValue("CodMot", CodMot)
                    'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                    reporteC.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                    reporteC.SetParameterValue("UbicacionCodBarra", "")
                    reporteC.SetParameterValue("MostrarBanco", MostrarBanco)
                    reporteC.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                    reporteC.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                    reporteC.SetParameterValue("VistaPreliminar", "true")
                    forma.Text = "Factura Electronica"
                    forma.ShowDialog()

                ElseIf cuotasrows = 1 Or cuotasrows = 2 Or cuotasrows = 3 Or cuotasrows = 4 Then

                    If reporte.Subreports.Count > 0 Then
                        reporte.Subreports(0).SetDataSource(dtSubreporte)
                    End If

                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                    reporte.SetParameterValue("CodMot", CodMot)
                    'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                    reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                    reporte.SetParameterValue("UbicacionCodBarra", "")
                    reporte.SetParameterValue("MostrarBanco", MostrarBanco)
                    reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                    reporte.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                    reporte.SetParameterValue("VistaPreliminar", "true")
                    forma.Text = "Factura Electronica"
                    forma.ShowDialog()

                Else
                    If reporte2.Subreports.Count > 0 Then
                        reporte2.Subreports(0).SetDataSource(dtSubreporte)
                    End If

                    reporte2.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte2
                    reporte2.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                    reporte2.SetParameterValue("CodMot", CodMot)
                    'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                    reporte2.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                    reporte2.SetParameterValue("UbicacionCodBarra", "")
                    reporte2.SetParameterValue("MostrarBanco", MostrarBanco)
                    reporte2.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                    reporte2.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                    reporte2.SetParameterValue("VistaPreliminar", "true")
                    forma.Text = "Factura Electronica"
                    forma.ShowDialog()

                End If



            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub


    Private Sub CrearPDF2DetMtUAmazonica()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            'Dim reporte As New rpImprimirFacturaElectronicaMtUAmaz
            Dim cuotasrows As Integer
            Dim reporte As New rpImprimirFacturaElectronicaMtUAmaz
            Dim reporte2 As New rpImprimirFacturaElectronicaMtUAmaz2
            Dim reporteC As New rpImprimirFacturaElectronicaMtUAmazC

            Dim reporteAntic As New rpImprimirFacturaElectronicaEquimapAmazonicaAnticipo
            Dim reporte2Antic As New rpImprimirFacturaElectronicaEquimapAmazonica2Anticipo
            Dim reporteCAntic As New rpImprimirFacturaElectronicaEquimapAmazonicaCAnticipo



            dtReporte = oFacturaService.ImprimirDigital(IdFacturaPreImpresion).Tables(0)
            dtSubreporte = oFacturaService.MostrarCuota(IdFacturaPreImpresion).Tables(0)
            cuotasrows = dtSubreporte.Rows.Count

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else

                If CodMot = "10" Then 'DEDUCIR ADELANTOS

                    If cuotasrows = 0 Then

                        reporteCAntic.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteCAntic
                        reporteCAntic.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                        reporteCAntic.SetParameterValue("CodMot", CodMot)
                        'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                        reporteCAntic.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                        reporteCAntic.SetParameterValue("UbicacionCodBarra", "")
                        reporteCAntic.SetParameterValue("MostrarBanco", MostrarBanco)
                        reporteCAntic.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                        reporteCAntic.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                        reporteCAntic.SetParameterValue("VistaPreliminar", "true")
                        forma.Text = "Factura Electronica"
                        forma.ShowDialog()

                    ElseIf cuotasrows = 1 Or cuotasrows = 2 Or cuotasrows = 3 Or cuotasrows = 4 Then

                        If reporteAntic.Subreports.Count > 0 Then
                            reporteAntic.Subreports(0).SetDataSource(dtSubreporte)
                        End If

                        reporteAntic.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteAntic
                        reporteAntic.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                        reporteAntic.SetParameterValue("CodMot", CodMot)
                        'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                        reporteAntic.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                        reporteAntic.SetParameterValue("UbicacionCodBarra", "")
                        reporteAntic.SetParameterValue("MostrarBanco", MostrarBanco)
                        reporteAntic.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                        reporteAntic.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                        reporteAntic.SetParameterValue("VistaPreliminar", "true")
                        forma.Text = "Factura Electronica"
                        forma.ShowDialog()

                    Else

                        If reporte2Antic.Subreports.Count > 0 Then
                            reporte2Antic.Subreports(0).SetDataSource(dtSubreporte)
                        End If

                        reporte2Antic.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte2Antic
                        reporte2Antic.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                        reporte2Antic.SetParameterValue("CodMot", CodMot)
                        'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                        reporte2Antic.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                        reporte2Antic.SetParameterValue("UbicacionCodBarra", "")
                        reporte2Antic.SetParameterValue("MostrarBanco", MostrarBanco)
                        reporte2Antic.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                        reporte2Antic.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                        reporte2Antic.SetParameterValue("VistaPreliminar", "true")
                        forma.Text = "Factura Electronica"
                        forma.ShowDialog()

                    End If

                Else

                    If cuotasrows = 0 Then

                        reporteC.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteC
                        reporteC.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                        reporteC.SetParameterValue("CodMot", CodMot)
                        'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                        reporteC.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                        reporteC.SetParameterValue("UbicacionCodBarra", "")
                        reporteC.SetParameterValue("MostrarBanco", MostrarBanco)
                        reporteC.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                        reporteC.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                        reporteC.SetParameterValue("VistaPreliminar", "true")
                        forma.Text = "Factura Electronica"
                        forma.ShowDialog()

                    ElseIf cuotasrows = 1 Or cuotasrows = 2 Or cuotasrows = 3 Or cuotasrows = 4 Then

                        If reporte.Subreports.Count > 0 Then
                            reporte.Subreports(0).SetDataSource(dtSubreporte)
                        End If

                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte
                        reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                        reporte.SetParameterValue("CodMot", CodMot)
                        'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                        reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                        reporte.SetParameterValue("UbicacionCodBarra", "")
                        reporte.SetParameterValue("MostrarBanco", MostrarBanco)
                        reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                        reporte.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                        reporte.SetParameterValue("VistaPreliminar", "true")
                        forma.Text = "Factura Electronica"
                        forma.ShowDialog()

                    Else

                        If reporte2.Subreports.Count > 0 Then
                            reporte2.Subreports(0).SetDataSource(dtSubreporte)
                        End If

                        reporte2.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte2
                        reporte2.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                        reporte2.SetParameterValue("CodMot", CodMot)
                        'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                        reporte2.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                        reporte2.SetParameterValue("UbicacionCodBarra", "")
                        reporte2.SetParameterValue("MostrarBanco", MostrarBanco)
                        reporte2.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                        reporte2.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                        reporte2.SetParameterValue("VistaPreliminar", "true")
                        forma.Text = "Factura Electronica"
                        forma.ShowDialog()

                    End If

                    'reporte.SetDataSource(dtReporte)
                    'forma.crvReportes.ReportSource = reporte
                    'reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                    'reporte.SetParameterValue("CodMot", CodMot)
                    ''reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                    'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                    'reporte.SetParameterValue("UbicacionCodBarra", "")
                    'reporte.SetParameterValue("MostrarBanco", MostrarBanco)
                    'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                    'reporte.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                    'reporte.SetParameterValue("VistaPreliminar", "true")
                    'forma.Text = "Factura Electronica"
                    'forma.ShowDialog()

                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2ResMtUAmazonica()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            'Dim reporte As New rpImprimirFacturaElectronicaMtuAmazResumido
            Dim cuotasrows As Integer
            Dim reporte As New rpImprimirFacturaElectronicaMtuAmazResumido
            Dim reporte2 As New rpImprimirFacturaElectronicaMtuAmazResumido2
            Dim reporteC As New rpImprimirFacturaElectronicaMtuAmazResumidoC

            dtReporte = oFacturaService.ImprimirDigital(IdFacturaPreImpresion).Tables(0)
            dtSubreporte = oFacturaService.MostrarCuota(IdFacturaPreImpresion).Tables(0)
            cuotasrows = dtSubreporte.Rows.Count

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                If cuotasrows = 0 Then

                    reporteC.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteC
                    reporteC.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                    reporteC.SetParameterValue("CodMot", CodMot)
                    'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                    reporteC.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                    reporteC.SetParameterValue("UbicacionCodBarra", "")
                    reporteC.SetParameterValue("MostrarBanco", MostrarBanco)
                    reporteC.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                    reporteC.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                    reporteC.SetParameterValue("VistaPreliminar", "true")
                    forma.Text = "Factura Electronica"
                    forma.ShowDialog()

                ElseIf cuotasrows = 1 Or cuotasrows = 2 Or cuotasrows = 3 Or cuotasrows = 4 Then

                    If reporte.Subreports.Count > 0 Then
                        reporte.Subreports(0).SetDataSource(dtSubreporte)
                    End If

                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                    reporte.SetParameterValue("CodMot", CodMot)
                    'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                    reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                    reporte.SetParameterValue("UbicacionCodBarra", "")
                    reporte.SetParameterValue("MostrarBanco", MostrarBanco)
                    reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                    reporte.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                    reporte.SetParameterValue("VistaPreliminar", "true")
                    forma.Text = "Factura Electronica"
                    forma.ShowDialog()

                Else

                    If reporte2.Subreports.Count > 0 Then
                        reporte2.Subreports(0).SetDataSource(dtSubreporte)
                    End If

                    reporte2.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte2
                    reporte2.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                    reporte2.SetParameterValue("CodMot", CodMot)
                    'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                    reporte2.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                    reporte2.SetParameterValue("UbicacionCodBarra", "")
                    reporte2.SetParameterValue("MostrarBanco", MostrarBanco)
                    reporte2.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                    reporte2.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                    reporte2.SetParameterValue("VistaPreliminar", "true")
                    forma.Text = "Factura Electronica"
                    forma.ShowDialog()

                End If

                'reporte.SetDataSource(dtReporte)
                'forma.crvReportes.ReportSource = reporte
                'reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                ''reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("UbicacionCodBarra", "")
                'reporte.SetParameterValue("MostrarBanco", MostrarBanco)
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                'reporte.SetParameterValue("VistaPreliminar", "true")
                'forma.Text = "Factura Electronica"
                'forma.ShowDialog()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub


    Private Sub CrearPDF2DetEquimap()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim cuotasrows As Integer
            Dim reporte As New rpImprimirFacturaElectronicaEquimap
            Dim reporte2 As New rpImprimirFacturaElectronicaEquimap2
            Dim reporteC As New rpImprimirFacturaElectronicaEquimapC

            Dim reporteAntic As New rpImprimirFacturaElectronicaEquimapAnticipo
            Dim reporte2Antic As New rpImprimirFacturaElectronicaEquimap2Anticipo
            Dim reporteCAntic As New rpImprimirFacturaElectronicaEquimapCAnticipo

            dtReporte = oFacturaService.ImprimirDigital(IdFacturaPreImpresion).Tables(0)
            dtSubreporte = oFacturaService.MostrarCuota(IdFacturaPreImpresion).Tables(0)
            cuotasrows = dtSubreporte.Rows.Count


            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else

                If CodMot = "10" Then 'DEDUCIR ADELANTOS

                    If cuotasrows = 0 Then

                        reporteCAntic.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteCAntic
                        reporteCAntic.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                        reporteCAntic.SetParameterValue("CodMot", CodMot)
                        'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                        reporteCAntic.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                        reporteCAntic.SetParameterValue("UbicacionCodBarra", "")
                        reporteCAntic.SetParameterValue("MostrarBanco", MostrarBanco)
                        reporteCAntic.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                        reporteCAntic.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                        reporteCAntic.SetParameterValue("VistaPreliminar", "true")
                        forma.Text = "Factura Electronica"
                        forma.ShowDialog()

                    ElseIf cuotasrows = 1 Or cuotasrows = 2 Or cuotasrows = 3 Or cuotasrows = 4 Then

                        If reporteAntic.Subreports.Count > 0 Then
                            reporteAntic.Subreports(0).SetDataSource(dtSubreporte)
                        End If

                        reporteAntic.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteAntic
                        reporteAntic.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                        reporteAntic.SetParameterValue("CodMot", CodMot)
                        'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                        reporteAntic.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                        reporteAntic.SetParameterValue("UbicacionCodBarra", "")
                        reporteAntic.SetParameterValue("MostrarBanco", MostrarBanco)
                        reporteAntic.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                        reporteAntic.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                        reporteAntic.SetParameterValue("VistaPreliminar", "true")
                        forma.Text = "Factura Electronica"
                        forma.ShowDialog()

                    Else

                        If reporte2Antic.Subreports.Count > 0 Then
                            reporte2Antic.Subreports(0).SetDataSource(dtSubreporte)
                        End If

                        reporte2Antic.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte2Antic
                        reporte2Antic.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                        reporte2Antic.SetParameterValue("CodMot", CodMot)
                        'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                        reporte2Antic.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                        reporte2Antic.SetParameterValue("UbicacionCodBarra", "")
                        reporte2Antic.SetParameterValue("MostrarBanco", MostrarBanco)
                        reporte2Antic.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                        reporte2Antic.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                        reporte2Antic.SetParameterValue("VistaPreliminar", "true")
                        forma.Text = "Factura Electronica"
                        forma.ShowDialog()

                    End If


                Else

                    If cuotasrows = 0 Then

                        reporteC.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteC
                        reporteC.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                        reporteC.SetParameterValue("CodMot", CodMot)
                        'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                        reporteC.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                        reporteC.SetParameterValue("UbicacionCodBarra", "")
                        reporteC.SetParameterValue("MostrarBanco", MostrarBanco)
                        reporteC.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                        reporteC.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                        reporteC.SetParameterValue("VistaPreliminar", "true")
                        forma.Text = "Factura Electronica"
                        forma.ShowDialog()

                    ElseIf cuotasrows = 1 Or cuotasrows = 2 Or cuotasrows = 3 Or cuotasrows = 4 Then

                        If reporte.Subreports.Count > 0 Then
                            reporte.Subreports(0).SetDataSource(dtSubreporte)
                        End If

                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte
                        reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                        reporte.SetParameterValue("CodMot", CodMot)
                        'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                        reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                        reporte.SetParameterValue("UbicacionCodBarra", "")
                        reporte.SetParameterValue("MostrarBanco", MostrarBanco)
                        reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                        reporte.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                        reporte.SetParameterValue("VistaPreliminar", "true")
                        forma.Text = "Factura Electronica"
                        forma.ShowDialog()

                    Else

                        If reporte2.Subreports.Count > 0 Then
                            reporte2.Subreports(0).SetDataSource(dtSubreporte)
                        End If

                        reporte2.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte2
                        reporte2.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                        reporte2.SetParameterValue("CodMot", CodMot)
                        'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                        reporte2.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                        reporte2.SetParameterValue("UbicacionCodBarra", "")
                        reporte2.SetParameterValue("MostrarBanco", MostrarBanco)
                        reporte2.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                        reporte2.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                        reporte2.SetParameterValue("VistaPreliminar", "true")
                        forma.Text = "Factura Electronica"
                        forma.ShowDialog()

                    End If

                    'reporte.SetDataSource(dtReporte)
                    'forma.crvReportes.ReportSource = reporte
                    'reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                    'reporte.SetParameterValue("CodMot", CodMot)
                    ''reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                    'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                    'reporte.SetParameterValue("UbicacionCodBarra", "")
                    'reporte.SetParameterValue("MostrarBanco", MostrarBanco)
                    'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                    'reporte.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                    'reporte.SetParameterValue("VistaPreliminar", "true")
                    'forma.Text = "Factura Electronica"
                    'forma.ShowDialog()

                End If



            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2ResEquimap()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim cuotasrows As Integer
            Dim reporte As New rpImprimirFacturaElectronicaEquimapResumido
            Dim reporte2 As New rpImprimirFacturaElectronicaEquimapResumido2
            Dim reporteC As New rpImprimirFacturaElectronicaEquimapResumidoC

            Dim reporteAntic As New rpImprimirFacturaElectronicaEquimapResumidoAnticipo
            Dim reporte2Antic As New rpImprimirFacturaElectronicaEquimapResumido2Anticipo
            Dim reporteCAntic As New rpImprimirFacturaElectronicaEquimapResumidoCAnticipo

            dtReporte = oFacturaService.ImprimirDigital(IdFacturaPreImpresion).Tables(0)
            dtSubreporte = oFacturaService.MostrarCuota(IdFacturaPreImpresion).Tables(0)
            cuotasrows = dtSubreporte.Rows.Count

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else

                If CodMot = "10" Then 'DEDUCIR ADELANTOS

                    If cuotasrows = 0 Then

                        reporteCAntic.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteCAntic
                        reporteCAntic.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                        reporteCAntic.SetParameterValue("CodMot", CodMot)
                        'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                        reporteCAntic.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                        reporteCAntic.SetParameterValue("UbicacionCodBarra", "")
                        reporteCAntic.SetParameterValue("MostrarBanco", MostrarBanco)
                        reporteCAntic.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                        reporteCAntic.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                        reporteCAntic.SetParameterValue("VistaPreliminar", "true")
                        forma.Text = "Factura Electronica"
                        forma.ShowDialog()

                    ElseIf cuotasrows = 1 Or cuotasrows = 2 Or cuotasrows = 3 Or cuotasrows = 4 Then

                        If reporteAntic.Subreports.Count > 0 Then
                            reporteAntic.Subreports(0).SetDataSource(dtSubreporte)
                        End If

                        reporteAntic.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteAntic
                        reporteAntic.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                        reporteAntic.SetParameterValue("CodMot", CodMot)
                        'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                        reporteAntic.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                        reporteAntic.SetParameterValue("UbicacionCodBarra", "")
                        reporteAntic.SetParameterValue("MostrarBanco", MostrarBanco)
                        reporteAntic.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                        reporteAntic.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                        reporteAntic.SetParameterValue("VistaPreliminar", "true")
                        forma.Text = "Factura Electronica"
                        forma.ShowDialog()


                    Else

                        If reporte2Antic.Subreports.Count > 0 Then
                            reporte2Antic.Subreports(0).SetDataSource(dtSubreporte)
                        End If

                        reporte2Antic.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte2Antic
                        reporte2Antic.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                        reporte2Antic.SetParameterValue("CodMot", CodMot)
                        'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                        reporte2Antic.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                        reporte2Antic.SetParameterValue("UbicacionCodBarra", "")
                        reporte2Antic.SetParameterValue("MostrarBanco", MostrarBanco)
                        reporte2Antic.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                        reporte2Antic.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                        reporte2Antic.SetParameterValue("VistaPreliminar", "true")
                        forma.Text = "Factura Electronica"
                        forma.ShowDialog()

                    End If

                Else

                    If cuotasrows = 0 Then

                        reporteC.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteC
                        reporteC.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                        reporteC.SetParameterValue("CodMot", CodMot)
                        'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                        reporteC.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                        reporteC.SetParameterValue("UbicacionCodBarra", "")
                        reporteC.SetParameterValue("MostrarBanco", MostrarBanco)
                        reporteC.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                        reporteC.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                        reporteC.SetParameterValue("VistaPreliminar", "true")
                        forma.Text = "Factura Electronica"
                        forma.ShowDialog()

                    ElseIf cuotasrows = 1 Or cuotasrows = 2 Or cuotasrows = 3 Or cuotasrows = 4 Then

                        If reporte.Subreports.Count > 0 Then
                            reporte.Subreports(0).SetDataSource(dtSubreporte)
                        End If

                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte
                        reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                        reporte.SetParameterValue("CodMot", CodMot)
                        'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                        reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                        reporte.SetParameterValue("UbicacionCodBarra", "")
                        reporte.SetParameterValue("MostrarBanco", MostrarBanco)
                        reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                        reporte.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                        reporte.SetParameterValue("VistaPreliminar", "true")
                        forma.Text = "Factura Electronica"
                        forma.ShowDialog()


                    Else

                        If reporte2.Subreports.Count > 0 Then
                            reporte2.Subreports(0).SetDataSource(dtSubreporte)
                        End If

                        reporte2.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte2
                        reporte2.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                        reporte2.SetParameterValue("CodMot", CodMot)
                        'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                        reporte2.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                        reporte2.SetParameterValue("UbicacionCodBarra", "")
                        reporte2.SetParameterValue("MostrarBanco", MostrarBanco)
                        reporte2.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                        reporte2.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                        reporte2.SetParameterValue("VistaPreliminar", "true")
                        forma.Text = "Factura Electronica"
                        forma.ShowDialog()

                    End If


                    'reporte.SetDataSource(dtReporte)
                    'forma.crvReportes.ReportSource = reporte
                    'reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                    'reporte.SetParameterValue("CodMot", CodMot)
                    ''reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                    'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                    'reporte.SetParameterValue("UbicacionCodBarra", "")
                    'reporte.SetParameterValue("MostrarBanco", MostrarBanco)
                    'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                    'reporte.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                    'reporte.SetParameterValue("VistaPreliminar", "true")
                    'forma.Text = "Factura Electronica"
                    'forma.ShowDialog()

                End If



            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    '=============================================== C2TECK
    Private Sub CrearPDF2DetC2Teck()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            'Dim reporte As New rpImprimirFacturaElectronicaC2Teck
            Dim cuotasrows As Integer
            Dim reporte As New rpImprimirFacturaElectronicaC2Teck
            Dim reporte2 As New rpImprimirFacturaElectronicaC2Teck2
            Dim reporteC As New rpImprimirFacturaElectronicaC2TeckC


            dtReporte = oFacturaService.ImprimirDigital(IdFacturaPreImpresion).Tables(0)
            dtSubreporte = oFacturaService.MostrarCuota(IdFacturaPreImpresion).Tables(0)
            cuotasrows = dtSubreporte.Rows.Count


            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else

                If cuotasrows = 0 Then

                    reporteC.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteC
                    reporteC.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                    reporteC.SetParameterValue("CodMot", CodMot)
                    'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                    reporteC.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                    reporteC.SetParameterValue("UbicacionCodBarra", "")
                    reporteC.SetParameterValue("MostrarBanco", MostrarBanco)
                    reporteC.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                    reporteC.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                    reporteC.SetParameterValue("VistaPreliminar", "true")
                    forma.Text = "Factura Electronica"
                    forma.ShowDialog()

                ElseIf cuotasrows = 1 Or cuotasrows = 2 Or cuotasrows = 3 Or cuotasrows = 4 Then

                    If reporte.Subreports.Count > 0 Then
                        reporte.Subreports(0).SetDataSource(dtSubreporte)
                    End If

                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                    reporte.SetParameterValue("CodMot", CodMot)
                    'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                    reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                    reporte.SetParameterValue("UbicacionCodBarra", "")
                    reporte.SetParameterValue("MostrarBanco", MostrarBanco)
                    reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                    reporte.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                    reporte.SetParameterValue("VistaPreliminar", "true")
                    forma.Text = "Factura Electronica"
                    forma.ShowDialog()

                Else

                    If reporte2.Subreports.Count > 0 Then
                        reporte2.Subreports(0).SetDataSource(dtSubreporte)
                    End If

                    reporte2.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte2
                    reporte2.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                    reporte2.SetParameterValue("CodMot", CodMot)
                    'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                    reporte2.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                    reporte2.SetParameterValue("UbicacionCodBarra", "")
                    reporte2.SetParameterValue("MostrarBanco", MostrarBanco)
                    reporte2.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                    reporte2.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                    reporte2.SetParameterValue("VistaPreliminar", "true")
                    forma.Text = "Factura Electronica"
                    forma.ShowDialog()


                End If

                'reporte.SetDataSource(dtReporte)
                'forma.crvReportes.ReportSource = reporte
                'reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                ''reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("UbicacionCodBarra", "")
                'reporte.SetParameterValue("MostrarBanco", MostrarBanco)
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                'reporte.SetParameterValue("VistaPreliminar", "true")
                'forma.Text = "Factura Electronica"
                'forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2ResC2Teck()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            'Dim reporte As New rpImprimirFacturaElectronicaC2TeckResumido
            Dim cuotasrows As Integer
            Dim reporte As New rpImprimirFacturaElectronicaC2TeckResumido
            Dim reporte2 As New rpImprimirFacturaElectronicaC2TeckResumido2
            Dim reporteC As New rpImprimirFacturaElectronicaC2TeckResumidoC


            dtReporte = oFacturaService.ImprimirDigital(IdFacturaPreImpresion).Tables(0)
            dtSubreporte = oFacturaService.MostrarCuota(IdFacturaPreImpresion).Tables(0)
            cuotasrows = dtSubreporte.Rows.Count


            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                If cuotasrows = 0 Then

                    reporteC.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteC
                    reporteC.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                    reporteC.SetParameterValue("CodMot", CodMot)
                    'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                    reporteC.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                    reporteC.SetParameterValue("UbicacionCodBarra", "")
                    reporteC.SetParameterValue("MostrarBanco", MostrarBanco)
                    reporteC.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                    reporteC.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                    reporteC.SetParameterValue("VistaPreliminar", "true")
                    forma.Text = "Factura Electronica"
                    forma.ShowDialog()

                ElseIf cuotasrows = 1 Or cuotasrows = 2 Or cuotasrows = 3 Or cuotasrows = 4 Then

                    If reporte.Subreports.Count > 0 Then
                        reporte.Subreports(0).SetDataSource(dtSubreporte)
                    End If

                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                    reporte.SetParameterValue("CodMot", CodMot)
                    'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                    reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                    reporte.SetParameterValue("UbicacionCodBarra", "")
                    reporte.SetParameterValue("MostrarBanco", MostrarBanco)
                    reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                    reporte.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                    reporte.SetParameterValue("VistaPreliminar", "true")
                    forma.Text = "Factura Electronica"
                    forma.ShowDialog()

                Else

                    If reporte2.Subreports.Count > 0 Then
                        reporte2.Subreports(0).SetDataSource(dtSubreporte)
                    End If

                    reporte2.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte2
                    reporte2.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                    reporte2.SetParameterValue("CodMot", CodMot)
                    'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                    reporte2.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                    reporte2.SetParameterValue("UbicacionCodBarra", "")
                    reporte2.SetParameterValue("MostrarBanco", MostrarBanco)
                    reporte2.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                    reporte2.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                    reporte2.SetParameterValue("VistaPreliminar", "true")
                    forma.Text = "Factura Electronica"
                    forma.ShowDialog()


                End If


                'reporte.SetDataSource(dtReporte)
                'forma.crvReportes.ReportSource = reporte
                'reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                ''reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("UbicacionCodBarra", "")
                'reporte.SetParameterValue("MostrarBanco", MostrarBanco)
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                'reporte.SetParameterValue("VistaPreliminar", "true")
                'forma.Text = "Factura Electronica"
                'forma.ShowDialog()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    '=============================================== C2TECK

    '=============================================== C2TECK INFORMATICA Y METALURGICA
    Private Sub CrearPDF2DetC2TeckIM()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            'Dim reporte As New rpImprimirFacturaElectronicaC2Teck
            Dim cuotasrows As Integer
            Dim reporte As New rpImprimirFacturaElectronicaC2TeckIM
            Dim reporte2 As New rpImprimirFacturaElectronicaC2TeckIM2
            Dim reporteC As New rpImprimirFacturaElectronicaC2TeckIMC


            dtReporte = oFacturaService.ImprimirDigital(IdFacturaPreImpresion).Tables(0)
            dtSubreporte = oFacturaService.MostrarCuota(IdFacturaPreImpresion).Tables(0)
            cuotasrows = dtSubreporte.Rows.Count


            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else

                If cuotasrows = 0 Then

                    reporteC.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteC
                    reporteC.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                    reporteC.SetParameterValue("CodMot", CodMot)
                    'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                    reporteC.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                    reporteC.SetParameterValue("UbicacionCodBarra", "")
                    reporteC.SetParameterValue("MostrarBanco", MostrarBanco)
                    reporteC.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                    reporteC.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                    reporteC.SetParameterValue("VistaPreliminar", "true")
                    forma.Text = "Factura Electronica"
                    forma.ShowDialog()

                ElseIf cuotasrows = 1 Or cuotasrows = 2 Or cuotasrows = 3 Or cuotasrows = 4 Then

                    If reporte.Subreports.Count > 0 Then
                        reporte.Subreports(0).SetDataSource(dtSubreporte)
                    End If

                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                    reporte.SetParameterValue("CodMot", CodMot)
                    'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                    reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                    reporte.SetParameterValue("UbicacionCodBarra", "")
                    reporte.SetParameterValue("MostrarBanco", MostrarBanco)
                    reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                    reporte.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                    reporte.SetParameterValue("VistaPreliminar", "true")
                    forma.Text = "Factura Electronica"
                    forma.ShowDialog()

                Else

                    If reporte2.Subreports.Count > 0 Then
                        reporte2.Subreports(0).SetDataSource(dtSubreporte)
                    End If

                    reporte2.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte2
                    reporte2.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                    reporte2.SetParameterValue("CodMot", CodMot)
                    'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                    reporte2.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                    reporte2.SetParameterValue("UbicacionCodBarra", "")
                    reporte2.SetParameterValue("MostrarBanco", MostrarBanco)
                    reporte2.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                    reporte2.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                    reporte2.SetParameterValue("VistaPreliminar", "true")
                    forma.Text = "Factura Electronica"
                    forma.ShowDialog()


                End If

                'reporte.SetDataSource(dtReporte)
                'forma.crvReportes.ReportSource = reporte
                'reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                ''reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("UbicacionCodBarra", "")
                'reporte.SetParameterValue("MostrarBanco", MostrarBanco)
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                'reporte.SetParameterValue("VistaPreliminar", "true")
                'forma.Text = "Factura Electronica"
                'forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2ResC2TeckIM()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            'Dim reporte As New rpImprimirFacturaElectronicaC2TeckResumido
            Dim cuotasrows As Integer
            Dim reporte As New rpImprimirFacturaElectronicaC2TeckIMResumido
            Dim reporte2 As New rpImprimirFacturaElectronicaC2TeckIMResumido2
            Dim reporteC As New rpImprimirFacturaElectronicaC2TeckIMResumidoC


            dtReporte = oFacturaService.ImprimirDigital(IdFacturaPreImpresion).Tables(0)
            dtSubreporte = oFacturaService.MostrarCuota(IdFacturaPreImpresion).Tables(0)
            cuotasrows = dtSubreporte.Rows.Count


            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                If cuotasrows = 0 Then

                    reporteC.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteC
                    reporteC.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                    reporteC.SetParameterValue("CodMot", CodMot)
                    'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                    reporteC.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                    reporteC.SetParameterValue("UbicacionCodBarra", "")
                    reporteC.SetParameterValue("MostrarBanco", MostrarBanco)
                    reporteC.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                    reporteC.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                    reporteC.SetParameterValue("VistaPreliminar", "true")
                    forma.Text = "Factura Electronica"
                    forma.ShowDialog()

                ElseIf cuotasrows = 1 Or cuotasrows = 2 Or cuotasrows = 3 Or cuotasrows = 4 Then

                    If reporte.Subreports.Count > 0 Then
                        reporte.Subreports(0).SetDataSource(dtSubreporte)
                    End If

                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                    reporte.SetParameterValue("CodMot", CodMot)
                    'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                    reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                    reporte.SetParameterValue("UbicacionCodBarra", "")
                    reporte.SetParameterValue("MostrarBanco", MostrarBanco)
                    reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                    reporte.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                    reporte.SetParameterValue("VistaPreliminar", "true")
                    forma.Text = "Factura Electronica"
                    forma.ShowDialog()

                Else

                    If reporte2.Subreports.Count > 0 Then
                        reporte2.Subreports(0).SetDataSource(dtSubreporte)
                    End If

                    reporte2.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte2
                    reporte2.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                    reporte2.SetParameterValue("CodMot", CodMot)
                    'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                    reporte2.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                    reporte2.SetParameterValue("UbicacionCodBarra", "")
                    reporte2.SetParameterValue("MostrarBanco", MostrarBanco)
                    reporte2.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                    reporte2.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                    reporte2.SetParameterValue("VistaPreliminar", "true")
                    forma.Text = "Factura Electronica"
                    forma.ShowDialog()


                End If


                'reporte.SetDataSource(dtReporte)
                'forma.crvReportes.ReportSource = reporte
                'reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                'reporte.SetParameterValue("CodMot", CodMot)
                ''reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("UbicacionCodBarra", "")
                'reporte.SetParameterValue("MostrarBanco", MostrarBanco)
                'reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                'reporte.SetParameterValue("FecVenc", oDocCtaCte.CalcularFecVen(CodPag, FecDoc))
                'reporte.SetParameterValue("VistaPreliminar", "true")
                'forma.Text = "Factura Electronica"
                'forma.ShowDialog()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    '=============================================== C2TECK INFORMATICA Y METALURGICA


    Private Sub frmFactura_FacturaElectronica_Imprimir_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Try
            oFacturaService.Close()
            oTesoreriaService.Close()
            oMaestroService.Close()
            oDocCtaCte.Close()
        Catch ex As TimeoutException
            oFacturaService.Abort()
            oTesoreriaService.Abort()
            oMaestroService.Abort()
            oDocCtaCte.Abort()
        Catch ex As CommunicationException
            oFacturaService.Abort()
            oTesoreriaService.Abort()
            oMaestroService.Abort()
            oDocCtaCte.Abort()
        End Try

    End Sub

End Class