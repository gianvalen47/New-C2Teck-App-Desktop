
Imports System.ServiceModel
Public Class frmNotaCredito_NotaElectronica_Imprimir
    Public Imprimir As String

    Private oMaestroService As New MaestroService.MaestroClient
    Private oNotaCreditoService As New NotaCreditoService.NotaCreditoServiceClient
    Private oTesoreriaService As New TesoreriaService.TesoreriaServiceClient

    Public IdNotaImpresion As Integer
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

    Dim TotNetoLetras As String

    Private Sub frmNotaCredito_NotaElectronica_Imprimir_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub frmNotaCredito_NotaElectronica_Imprimir_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        rbDetalle.Checked = True
    End Sub

    Private Sub rbDetalle_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbDetalle.CheckedChanged, rbResumen.CheckedChanged
        If rbDetalle.Checked Then
            Imprimir = "Detallado" 'Detallado
        ElseIf rbResumen.Checked Then
            Imprimir = "Resumido" 'Resumido
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnPreImpresion_Click(sender As Object, e As EventArgs) Handles btnPreImpresion.Click

        Try
            Dim dtReporte As New DataTable
            dtReporte = oNotaCreditoService.ImprimirDigital(IdNotaImpresion).Tables(0)
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

            If rbDetalle.Checked Then
                opcionimp = "Detallado"
            ElseIf rbResumen.Checked Then
                opcionimp = "Resumido"
            End If
            'CrearXMLSerializado() 'CrearXmlDsctoGlobal() 'CrearxmlInafecta() '
            CrearPDF()

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
            Dim reporte As New rpImprimirNotaElectronica

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNotaImpresion).Tables(0)
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
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Nota Electronica"
                forma.ShowDialog()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2Res()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirNotaElectronicaResumido

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNotaImpresion).Tables(0)
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
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Nota Electronica"
                forma.ShowDialog()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2DetMtuAmazonica()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirNotaElectronicaMtuAmaz

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNotaImpresion).Tables(0)
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
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Nota Electronica"
                forma.ShowDialog()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2ResMtuAmazonica()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirNotaElectronicaMtuAmazResumido

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNotaImpresion).Tables(0)
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
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Nota Electronica"
                forma.ShowDialog()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2DetEquimap()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirNotaElectronicaEquimap

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNotaImpresion).Tables(0)
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
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Nota Electronica"
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
            Dim reporte As New rpImprimirNotaElectronicaEquimapResumido

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNotaImpresion).Tables(0)
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
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Nota Electronica"
                forma.ShowDialog()

            End If

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

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNotaImpresion).Tables(0)
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
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Nota Electronica"
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
            Dim reporte As New rpImprimirNotaElectronicaC2TeckResumido

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNotaImpresion).Tables(0)
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
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Nota Electronica"
                forma.ShowDialog()

            End If

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

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNotaImpresion).Tables(0)
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
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Nota Electronica"
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
            Dim reporte As New rpImprimirNotaElectronicaC2TeckIMResumido

            dtReporte = oNotaCreditoService.ImprimirDigital(IdNotaImpresion).Tables(0)
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
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Nota Electronica"
                forma.ShowDialog()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    '=========================== C2TECK INFORMATICA Y METALURGICA


    Private Sub frmNotaCredito_NotaElectronica_Imprimir_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oNotaCreditoService.Close()
            oTesoreriaService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oNotaCreditoService.Abort()
            oTesoreriaService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oNotaCreditoService.Abort()
            oTesoreriaService.Abort()
        End Try
    End Sub
End Class