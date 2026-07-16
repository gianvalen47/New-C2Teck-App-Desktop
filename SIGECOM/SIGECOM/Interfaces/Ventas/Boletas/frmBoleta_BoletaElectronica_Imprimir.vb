Imports System.ComponentModel
Imports System.ServiceModel

Public Class frmBoleta_BoletaElectronica_Imprimir

    Public Imprimir As String

    Private oBoletaService As New BoletaService.BoletaServiceClient
    Private oTesoreriaService As New TesoreriaService.TesoreriaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    Public EstadoSunat As Boolean
    Public TotalSoles As String
    Public opcionimp As String

    Public IdBoletaImpresion As Integer

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

    Private Sub frmBoleta_BoletaElectronica_Imprimir_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub rbDetalle_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbDetalle.CheckedChanged, rbResumen.CheckedChanged
        If rbDetalle.Checked Then
            Imprimir = "Detallado" 'Detallado
        ElseIf rbResumen.Checked Then
            Imprimir = "Resumido" 'Resumido
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub frmBoleta_BoletaElectronica_Imprimir_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        rbDetalle.Checked = True
    End Sub

    Private Sub btnPreImpresion_Click(sender As Object, e As EventArgs) Handles btnPreImpresion.Click

        Try
            Dim dtReporte As New DataTable

            dtReporte = oBoletaService.ImprimirDigital(IdBoletaImpresion).Tables(0)
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
            NumOrden = ""

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

    Private Sub frmBoleta_BoletaElectronica_Imprimir_HelpButtonClicked(sender As Object, e As CancelEventArgs) Handles Me.HelpButtonClicked
        Try
            oBoletaService.Close()
            oTesoreriaService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oBoletaService.Close()
            oTesoreriaService.Close()
            oMaestroService.Close()
        Catch ex As CommunicationException
            oBoletaService.Abort()
            oTesoreriaService.Abort()
            oMaestroService.Abort()
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
            Dim reporte As New rpImprimirBoletaElectronica

            dtReporte = oBoletaService.ImprimirDigital(IdBoletaImpresion).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62 ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Boleta Electronica"
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
            Dim reporte As New rpImprimirBoletaElectronicaResumido

            dtReporte = oBoletaService.ImprimirDigital(IdBoletaImpresion).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Boleta Electronica"
                forma.ShowDialog()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2DetMtUAmazonica()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirBoletaElectronicaMtuAmaz

            dtReporte = oBoletaService.ImprimirDigital(IdBoletaImpresion).Tables(0)
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
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Boleta Electronica"
                forma.ShowDialog()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CrearPDF2ResMtUAmazonica()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirBoletaElectronicaMtuAmazResumido

            dtReporte = oBoletaService.ImprimirDigital(IdBoletaImpresion).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Boleta Electronica"
                forma.ShowDialog()

            End If

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

            dtReporte = oBoletaService.ImprimirDigital(IdBoletaImpresion).Tables(0)
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
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Boleta Electronica"
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
            Dim reporte As New rpImprimirBoletaElectronicaEquimapResumido

            dtReporte = oBoletaService.ImprimirDigital(IdBoletaImpresion).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Boleta Electronica"
                forma.ShowDialog()

            End If

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

            dtReporte = oBoletaService.ImprimirDigital(IdBoletaImpresion).Tables(0)
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
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Boleta Electronica"
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
            Dim reporte As New rpImprimirBoletaElectronicaC2TeckResumido

            dtReporte = oBoletaService.ImprimirDigital(IdBoletaImpresion).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Boleta Electronica"
                forma.ShowDialog()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    '=====================================

    '----------------------------------------------------------------------------- C2TECK INFORMATICA Y METALURGICA ----------------------------------------------------------

    Private Sub CrearPDF2DetC2TeckIM()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirBoletaElectronicaC2TeckIM

            dtReporte = oBoletaService.ImprimirDigital(IdBoletaImpresion).Tables(0)
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
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Boleta Electronica"
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
            Dim reporte As New rpImprimirBoletaElectronicaC2TeckIMResumido

            dtReporte = oBoletaService.ImprimirDigital(IdBoletaImpresion).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
                reporte.SetParameterValue("CodMot", CodMot)
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
                reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-1950878-0-36 ", "Nº Cta. Cte. en Dólares : BCP 390-1743298-1-72 "))
                'reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  ", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76 "))
                reporte.SetParameterValue("UbicacionCodBarra", "")
                reporte.SetParameterValue("TotalSoles", IIf(CurrencyId = "PEN", "", TotalSoles))
                reporte.SetParameterValue("VistaPreliminar", "true")
                forma.Text = "Boleta Electronica"
                forma.ShowDialog()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    '=====================================

End Class