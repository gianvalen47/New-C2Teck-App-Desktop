Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data
Imports System.ServiceModel

Public Class frmConsolidadoReportes

    Private oVentaService As New ReporteVentaService.ReporteVentaServiceClient
    Private oDocumentoCostoService As New DocumentoCostoService.DocumentoCostoServiceClient
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oDocumentosCtasCtesService As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient
    Private oReporteVentaService As New ReporteVentaService.ReporteVentaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private DtTotal As New DataTable
    Public Shared dtReporte1 As DataTable
    Public Shared dtReporte2 As DataTable
    Public Shared dtReporte3 As DataTable
    Public Shared dtReporte4 As DataTable
    Public Shared dtReporte5 As DataTable
    Public Shared dtReporte6 As DataTable
    Public Shared dtReporte7 As DataTable
    Public Shared dtReporte8 As DataTable
    Public Shared dtReporte9 As DataTable
    Public Shared dtReporte10 As DataTable
    Public Shared dtReporte11 As DataTable
    Public Shared dtReporte12 As DataTable
    Public Shared dtReporte13 As DataTable
    Public Shared dtReporte14 As DataTable
    Public Shared dtReporte15 As DataTable
    Public Shared dtReporte16 As DataTable
    Public Shared dtReporte17 As DataTable
    Public Shared FechaInicio1 As Date
    Public Shared FechaFinal1 As Date
    Public Shared FechaInicio2 As Date
    Public Shared FechaFinal2 As Date
    Public Shared FechaInicio3 As Date
    Public Shared FechaFinal3 As Date
    Public Shared FechaInicio4 As Date
    Public Shared FechaFinal4 As Date
    Public Shared FechaInicio5 As Date
    Public Shared FechaFinal5 As Date
    Public Shared FechaInicio6 As Date
    Public Shared FechaFinal6 As Date
    Public Shared FechaInicio7 As Date
    Public Shared FechaFinal7 As Date
    Public Shared FechaInicio8 As Date
    Public Shared FechaFinal8 As Date
    Public Shared FechaInicio9 As Date
    Public Shared FechaFinal9 As Date
    Public Shared FechaInicio10 As Date
    Public Shared FechaFinal10 As Date
    Public Shared FechaInicio11 As Date
    Public Shared FechaFinal11 As Date
    Public Shared FechaInicio12 As Date
    Public Shared FechaFinal12 As Date
    Public Shared FechaInicio13 As Date
    Public Shared FechaFinal13 As Date
    Public Shared FechaInicio14 As Date
    Public Shared FechaFinal14 As Date
    Public Shared FechaInicio15 As Date
    Public Shared FechaFinal15 As Date
    Public Shared FechaInicio16 As Date
    Public Shared FechaFinal16 As Date
    Public Shared FechaInicio17 As Date
    Public Shared FechaFinal17 As Date
    Public Shared Cliente6 As String
    Public Shared CodMon17 As String
    Public Shared Cliente17 As String
    Public Shared Tipo1 As Boolean
    Public Shared Tipo2 As Boolean
    Public Shared Tipo3 As Boolean
    Public Shared Tipo4 As Boolean
    Public Shared Tipo5 As Boolean
    Public Shared Tipo6 As Boolean
    Public Shared Tipo7 As Boolean
    Public Shared Tipo8 As Boolean
    Public Shared Tipo9 As Boolean
    Public Shared Tipo10 As Boolean
    Public Shared Tipo11 As Boolean
    Public Shared Tipo12 As Boolean
    Public Shared Tipo13 As Boolean
    Public Shared Tipo14 As Boolean
    Public Shared Tipo15 As Boolean
    Public Shared Tipo16 As Boolean
    Public Shared Tipo17 As Boolean
    Dim row As DataRow

    Private Sub frmConsolidadoReportes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oVentaService.Close()
            oDocumentoCostoService.Close()
            oJobService.Close()
            oLocacionMercaderiaService.Close()
            oDocumentosCtasCtesService.Close()
            oReporteVentaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oVentaService.Abort()
            oDocumentoCostoService.Abort()
            oJobService.Abort()
            oLocacionMercaderiaService.Abort()
            oDocumentosCtasCtesService.Abort()
            oReporteVentaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oVentaService.Abort()
            oDocumentoCostoService.Abort()
            oJobService.Abort()
            oLocacionMercaderiaService.Abort()
            oDocumentosCtasCtesService.Abort()
            oReporteVentaService.Abort()
            oSeguridadService.Abort()
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmConsolidadoReportes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmConsolidadoReportes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 176)
        '/*************************************************************************************/

        DtTotal.Columns.Add(("Reporte").ToString)
        DtTotal.Columns.Add(("TipoReporte").ToString)
        DtTotal.Columns.Add(("Orientacion").ToString)
        DtTotal.Columns.Add(("PDF").ToString)

        Actualizar()

        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

    End Sub


    Private Sub dgvDatos_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.ColumnButtonClick
        Try
            If e.Column.Key = "PDF" Then
                Eliminar()
            End If
        Catch ex As Exception
            MsgBox("Error al Eliminar " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim TipoSeleccionado As String

            TipoSeleccionado = CInt(dgvDatos.CurrentRow.Cells("TipoReporte").Value)

            For i As Integer = 1 To DtTotal.Rows.Count
                DtTotal.Rows.RemoveAt(0)
            Next

            dgvDatos.DataSource = Nothing

            If TipoSeleccionado = 1 Then
                Tipo1 = False
            ElseIf TipoSeleccionado = 2 Then
                Tipo2 = False
            ElseIf TipoSeleccionado = 3 Then
                Tipo3 = False
            ElseIf TipoSeleccionado = 4 Then
                Tipo4 = False
            ElseIf TipoSeleccionado = 5 Then
                Tipo5 = False
            ElseIf TipoSeleccionado = 6 Then
                Tipo6 = False
            ElseIf TipoSeleccionado = 7 Then
                Tipo7 = False
            ElseIf TipoSeleccionado = 8 Then
                Tipo8 = False
            ElseIf TipoSeleccionado = 9 Then
                Tipo9 = False
            ElseIf TipoSeleccionado = 10 Then
                Tipo10 = False
            ElseIf TipoSeleccionado = 11 Then
                Tipo11 = False
            ElseIf TipoSeleccionado = 12 Then
                Tipo12 = False
            ElseIf TipoSeleccionado = 13 Then
                Tipo13 = False
            ElseIf TipoSeleccionado = 14 Then
                Tipo14 = False
            ElseIf TipoSeleccionado = 15 Then
                Tipo15 = False
            ElseIf TipoSeleccionado = 16 Then
                Tipo16 = False
            ElseIf TipoSeleccionado = 17 Then
                Tipo17 = False
            End If

            If Tipo1 = True Then
                row = DtTotal.NewRow
                row(0) = "Reporte Gerencial de Ventas"
                row(1) = "1"
                row(2) = "V"
                DtTotal.Rows.Add(row)
            End If
            If Tipo2 = True Then
                row = DtTotal.NewRow
                row(0) = "Reporte Resumen Garantias"
                row(1) = "2"
                row(2) = "V"
                DtTotal.Rows.Add(row)
            End If
            If Tipo3 = True Then
                row = DtTotal.NewRow
                row(0) = "Reporte de Factura por Adelantos"
                row(1) = "3"
                row(2) = "V"
                DtTotal.Rows.Add(row)
            End If
            If Tipo4 = True Then
                row = DtTotal.NewRow
                row(0) = "Reporte de Detalle de Servicios en IGV"
                row(1) = "4"
                row(2) = "V"
                DtTotal.Rows.Add(row)
            End If
            If Tipo5 = True Then
                row = DtTotal.NewRow
                row(0) = "Reporte de Consolidado de Ventas"
                row(1) = "5"
                row(2) = "V"
                DtTotal.Rows.Add(row)
            End If
            If Tipo6 = True Then
                row = DtTotal.NewRow
                row(0) = "Reporte de Record de Ventas por Cliente"
                row(1) = "6"
                row(2) = "V"
                DtTotal.Rows.Add(row)
            End If
            If Tipo7 = True Then
                row = DtTotal.NewRow
                row(0) = "Reporte de Motores Vendidos"
                row(1) = "7"
                row(2) = "H"
                DtTotal.Rows.Add(row)
            End If
            If Tipo8 = True Then
                row = DtTotal.NewRow
                row(0) = "Reporte de Consolidado de Jobs"
                row(1) = "8"
                row(2) = "V"
                DtTotal.Rows.Add(row)
            End If
            'If Tipo9 = False Then
            '    FechaInicio9 = "01/01/2012"
            '    FechaFinal9 = "01/09/2012"
            'End If
            If Tipo10 = True Then
                row = DtTotal.NewRow
                row(0) = "Reporte de Ventas vs Presupuesto"
                row(1) = "10"
                row(2) = "V"
                DtTotal.Rows.Add(row)
            End If
            If Tipo11 = True Then
                row = DtTotal.NewRow
                row(0) = "Resumen de Importaciones"
                row(1) = "11"
                row(2) = "V"
                DtTotal.Rows.Add(row)
            End If
            If Tipo12 = True Then
                row = DtTotal.NewRow
                row(0) = "Detalle de Importaciones"
                row(1) = "12"
                row(2) = "V"
                DtTotal.Rows.Add(row)
            End If
            If Tipo13 = True Then
                row = DtTotal.NewRow
                row(0) = "Pedido de Importaciones"
                row(1) = "13"
                row(2) = "V"
                DtTotal.Rows.Add(row)
            End If
            If Tipo14 = True Then
                row = DtTotal.NewRow
                row(0) = "Reporte de Importaciones por Proveedor"
                row(1) = "14"
                row(2) = "V"
                DtTotal.Rows.Add(row)
            End If
            If Tipo15 = True Then
                row = DtTotal.NewRow
                row(0) = "Reporte de Stock Valorizado"
                row(1) = "15"
                row(2) = "V"
                DtTotal.Rows.Add(row)
            End If
            If Tipo16 = True Then
                row = DtTotal.NewRow
                row(0) = "Reporte de Ventas vs Cobranza sin IGV"
                row(1) = "16"
                row(2) = "V"
                DtTotal.Rows.Add(row)
            End If
            If Tipo17 = True Then
                row = DtTotal.NewRow
                row(0) = "Reporte de Cuadro de Ventas"
                row(1) = "17"
                row(2) = "H"
                DtTotal.Rows.Add(row)
            End If

            dgvDatos.DataSource = DtTotal

        Catch ex As Exception
            MsgBox("Error al Eliminar " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click

        Dim reporte1 As New rptConsolidadoReportes
        Dim forma As New frmReportes
        Dim i As Integer = 0
        Dim a1 As String = ""
        Dim a2 As String = ""
        Dim a3 As String = ""
        Dim a4 As String = ""
        Dim a5 As String = ""
        Dim a6 As String = ""
        Dim a7 As String = ""
        Dim a8 As String = ""
        Dim a9 As String = ""
        Dim a10 As String = ""
        Dim a11 As String = ""
        Dim a12 As String = ""
        Dim a13 As String = ""
        Dim a14 As String = ""
        Dim a15 As String = ""
        Dim a16 As String = ""

        If Tipo1 = False Then
            FechaInicio1 = "01/01/2012"
            FechaFinal1 = "01/09/2012"
        End If
        If Tipo2 = False Then
            FechaInicio2 = "01/01/2012"
            FechaFinal2 = "01/09/2012"
        End If
        If Tipo3 = False Then
            FechaInicio3 = "01/01/2012"
            FechaFinal3 = "01/09/2012"
        End If
        If Tipo4 = False Then
            FechaInicio4 = "01/01/2012"
            FechaFinal4 = "01/09/2012"
        End If
        If Tipo5 = False Then
            FechaInicio5 = "01/01/2012"
            FechaFinal5 = "01/09/2012"
        End If
        If Tipo6 = False Then
            FechaInicio6 = "01/01/2012"
            FechaFinal6 = "01/09/2012"
        End If
        If Tipo7 = False Then
            'FechaInicio7 = "01/01/2012"
            'FechaFinal7 = "01/09/2012"
        End If
        If Tipo8 = False Then
            FechaInicio8 = "01/01/2012"
            FechaFinal8 = "01/09/2012"
        End If
        If Tipo9 = False Then
            FechaInicio9 = "01/01/2012"
            FechaFinal9 = "01/09/2012"
        End If
        If Tipo10 = False Then
            FechaInicio10 = "01/01/2012"
            FechaFinal10 = "01/09/2012"
        End If
        If Tipo11 = False Then
            FechaInicio11 = "01/07/2012"
            FechaFinal11 = "30/07/2012"
        End If
        If Tipo12 = False Then
            FechaInicio12 = "01/07/2012"
            FechaFinal12 = "30/07/2012"
        End If
        If Tipo13 = False Then
            FechaInicio13 = "01/07/2012"
            FechaFinal13 = "30/07/2012"
        End If
        If Tipo14 = False Then
            FechaInicio14 = "01/07/2012"
            FechaFinal14 = "30/07/2012"
        End If
        If Tipo15 = False Then
            'FechaInicio15 = "01/07/2012"
            'FechaFinal15 = "30/07/2012"
        End If
        If Tipo16 = False Then
            FechaInicio16 = "01/07/2012"
            FechaFinal16 = "30/07/2012"
        End If

        If Tipo1 = False And Tipo2 = False And Tipo3 = False And Tipo4 = False And Tipo5 = False And Tipo6 = False And Tipo8 = False And Tipo9 = False And Tipo10 = False And Tipo11 = False And Tipo12 = False And Tipo13 = False And Tipo14 = False And Tipo15 = False And Tipo16 = False Then
            MsgBox("No hay Datos en el Reporte Consolidado, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
        Else
            dtReporte1 = oVentaService.ReporteGerVenta(Session.sCodEmp, FechaInicio1, FechaFinal1, 0, 1).Tables(0)
            If dtReporte1.Rows.Count > 0 Then
                If Tipo1 = True Then
                    a1 = "Supr"

                Else
                    a1 = "No"
                End If
            End If

            dtReporte2 = oVentaService.ReporteGerVenta(Session.sCodEmp, FechaInicio2, FechaFinal2, 0, 2).Tables(0)
            If dtReporte2.Rows.Count > 0 Then
                If Tipo2 = True Then
                    a2 = "Supr"
                Else
                    a2 = "No"
                End If
            End If

            dtReporte3 = oVentaService.ReporteGerVenta(Session.sCodEmp, FechaInicio3, FechaFinal3, 0, 3).Tables(0)
            If dtReporte3.Rows.Count > 0 Then
                If Tipo3 = True Then
                    a3 = "Supr"
                Else
                    a3 = "No"
                End If
            End If

            dtReporte4 = oVentaService.ReporteGerVenta(Session.sCodEmp, FechaInicio4, FechaFinal4, 0, 4).Tables(0)
            If dtReporte4.Rows.Count > 0 Then
                If Tipo4 = True Then
                    a4 = "Supr"
                Else
                    a4 = "No"
                End If
            End If

            dtReporte5 = oVentaService.ReporteGerVenta(Session.sCodEmp, FechaInicio5, FechaFinal5, 0, 5).Tables(0)
            If dtReporte5.Rows.Count > 0 Then
                If Tipo5 = True Then
                    a5 = "Supr"
                Else
                    a5 = "No"
                End If
            End If

            dtReporte6 = oVentaService.ReporteGerVenta(Session.sCodEmp, FechaInicio5, FechaFinal5, Cliente6, 6).Tables(0)
            If dtReporte6.Rows.Count > 0 Then
                If Tipo6 = True Then
                    a6 = "Supr"
                Else
                    a6 = "No"
                End If
            End If

            'dtReporte7 = oDocumentoCostoService.ReporteMotoresVendidos(0, FechaInicio7, FechaFinal7).Tables(0)
            'If dtReporte7.Rows.Count > 0 Then
            '    If Tipo7 = True Then
            '        a7 = "Supr"
            '    Else
            '        a7 = "No"
            '    End If
            'End If

            dtReporte8 = oVentaService.ReporteGerVenta(Session.sCodEmp, FechaInicio8, FechaFinal8, 0, 7).Tables(0)
            If dtReporte8.Rows.Count > 0 Then
                If Tipo8 = True Then
                    a8 = "Supr"
                Else
                    a8 = "No"
                End If
            End If

            'dtReporte9 = oJobService.ReporteGerencialServicios(Session.sCodEmp, FechaInicio9, FechaFinal9, 1).Tables(0)
            'If dtReporte9.Rows.Count > 0 Then
            '    If Tipo9 = True Then
            '        a9 = "Supr"
            '    Else
            '        a9 = "No"
            '    End If
            'End If

            dtReporte10 = oVentaService.ReporteGerVenta(Session.sCodEmp, FechaInicio10, FechaFinal10, 0, 8).Tables(0)
            If dtReporte10.Rows.Count > 0 Then
                If Tipo10 = True Then
                    a10 = "Supr"

                Else
                    a10 = "No"
                End If
            End If

            dtReporte11 = oDocumentoCostoService.ReporteGerenciaCostos(Session.sCodEmp, FechaInicio11, FechaFinal11, 1).Tables(0)
            If dtReporte11.Rows.Count > 0 Then
                If Tipo11 = True Then
                    a11 = "Supr"

                Else
                    a11 = "No"
                End If
            End If

            dtReporte12 = oDocumentoCostoService.ReporteGerenciaCostos(Session.sCodEmp, FechaInicio12, FechaFinal12, 2).Tables(0)
            If dtReporte12.Rows.Count > 0 Then
                If Tipo12 = True Then
                    a12 = "Supr"

                Else
                    a12 = "No"
                End If
            End If

            dtReporte13 = oDocumentoCostoService.ReporteGerenciaCostos(Session.sCodEmp, FechaInicio13, FechaFinal13, 3).Tables(0)
            If dtReporte13.Rows.Count > 0 Then
                If Tipo13 = True Then
                    a13 = "Supr"
                Else
                    a13 = "No"
                End If
            End If

            dtReporte14 = oLocacionMercaderiaService.ReporteGerencialInventarios(Session.sCodEmp, "", FechaInicio14, FechaFinal14, 0, 2).Tables(0)
            If dtReporte14.Rows.Count > 0 Then
                If Tipo14 = True Then
                    a14 = "Supr"
                Else
                    a14 = "No"
                End If
            End If

            dtReporte15 = oLocacionMercaderiaService.ReporteGerencialValorizado(Session.sCodEmp).Tables(0)
            If dtReporte15.Rows.Count > 0 Then
                If Tipo15 = True Then
                    a15 = "Supr"
                Else
                    a15 = "No"
                End If
            End If

            dtReporte16 = oDocumentosCtasCtesService.ReporteGerencial(Session.sCodEmp, FechaInicio16, FechaFinal16, 1).Tables(0)
            If dtReporte16.Rows.Count > 0 Then
                If Tipo16 = True Then
                    a16 = "Supr"
                Else
                    a16 = "No"
                End If
            End If

            dgvDatos.DataSource = DtTotal

            If reporte1.Subreports.Count > 0 Then
                'If dtReporte1.Rows.Count > 0 Then
                reporte1.Subreports("rptGerencialRegVentas.rpt").SetDataSource(dtReporte1)
                reporte1.Subreports("rptGerencialResumGarantias.rpt").SetDataSource(dtReporte2)
                reporte1.Subreports("rptGerencialAdelantos.rpt").SetDataSource(dtReporte3)
                reporte1.Subreports("rptGerencialServicioSinIGV.rpt").SetDataSource(dtReporte4)
                reporte1.Subreports("rptGerencialConsolVentas.rpt").SetDataSource(dtReporte5)
                reporte1.Subreports("rptVentasSegunCliente.rpt").SetDataSource(dtReporte6)
                'reporte1.Subreports("rptMotoresVenta.rpt").SetDataSource(dtReporte7)
                reporte1.Subreports("rptGerencialJobsVenta.rpt").SetDataSource(dtReporte8)
                'reporte1.Subreports("rptGerenciaJobFacturados.rpt").SetDataSource(dtReporte9)
                reporte1.Subreports("rptGerenciaVentaPresupuesto.rpt").SetDataSource(dtReporte10)
                reporte1.Subreports("rpRepGerImportaciones1.rpt").SetDataSource(dtReporte11)
                reporte1.Subreports("rpRepGerImportaciones2.rpt").SetDataSource(dtReporte12)
                reporte1.Subreports("rpRepGerImportaciones3.rpt").SetDataSource(dtReporte13)
                reporte1.Subreports("rpRepGerImportaciones4.rpt").SetDataSource(dtReporte14)
                reporte1.Subreports("rptGerenciaInventariosCostos.rpt").SetDataSource(dtReporte15)
                reporte1.Subreports("rpRepGerCreditos.rpt").SetDataSource(dtReporte16)
            End If

            reporte1.SetDataSource(dtReporte1)
            forma.crvReportes.ReportSource = reporte1
            ' Validar Usuario - Exportar Excel
            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                forma.crvReportes.ShowExportButton = True
            Else
                forma.crvReportes.ShowExportButton = False
            End If

            forma.crvReportes.DisplayGroupTree = False

            reporte1.SetParameterValue("Tipo1", IIf(a1 = "Supr", "1", "0"))
            reporte1.SetParameterValue("Tipo2", IIf(a2 = "Supr", "1", "0"))
            reporte1.SetParameterValue("Tipo3", IIf(a3 = "Supr", "1", "0"))
            reporte1.SetParameterValue("Tipo4", IIf(a4 = "Supr", "1", "0"))
            reporte1.SetParameterValue("Tipo5", IIf(a5 = "Supr", "1", "0"))
            reporte1.SetParameterValue("Tipo6", IIf(a6 = "Supr", "1", "0"))
            reporte1.SetParameterValue("Tipo7", IIf(a7 = "Supr", "1", "0"))
            reporte1.SetParameterValue("Tipo8", IIf(a8 = "Supr", "1", "0"))
            reporte1.SetParameterValue("Tipo9", IIf(a9 = "Supr", "1", "0"))
            reporte1.SetParameterValue("Tipo10", IIf(a10 = "Supr", "1", "0"))
            reporte1.SetParameterValue("Tipo11", IIf(a11 = "Supr", "1", "0"))
            reporte1.SetParameterValue("Tipo12", IIf(a12 = "Supr", "1", "0"))
            reporte1.SetParameterValue("Tipo13", IIf(a13 = "Supr", "1", "0"))
            reporte1.SetParameterValue("Tipo14", IIf(a14 = "Supr", "1", "0"))
            reporte1.SetParameterValue("Tipo15", IIf(a15 = "Supr", "1", "0"))
            reporte1.SetParameterValue("Tipo16", IIf(a16 = "Supr", "1", "0"))

            reporte1.SetParameterValue("FechaInicio", FechaInicio1, "rptGerencialRegVentas.rpt")
            reporte1.SetParameterValue("FechaFin", FechaFinal1, "rptGerencialRegVentas.rpt")
            reporte1.SetParameterValue("FechaInicio", FechaInicio2, "rptGerencialResumGarantias.rpt")
            reporte1.SetParameterValue("FechaFin", FechaFinal2, "rptGerencialResumGarantias.rpt")
            reporte1.SetParameterValue("FechaInicio", FechaInicio3, "rptGerencialAdelantos.rpt")
            reporte1.SetParameterValue("FechaFin", FechaFinal3, "rptGerencialAdelantos.rpt")
            reporte1.SetParameterValue("FecInicio", FechaInicio4, "rptGerencialServicioSinIGV.rpt")
            reporte1.SetParameterValue("FecFin", FechaFinal4, "rptGerencialServicioSinIGV.rpt")
            reporte1.SetParameterValue("FecInicio", FechaInicio5, "rptGerencialConsolVentas.rpt")
            reporte1.SetParameterValue("FecFin", FechaFinal5, "rptGerencialConsolVentas.rpt")
            reporte1.SetParameterValue("FecInicio", FechaInicio6, "rptVentasSegunCliente.rpt")
            reporte1.SetParameterValue("FechaFin", FechaFinal6, "rptVentasSegunCliente.rpt")
            reporte1.SetParameterValue("cbFecInicio", FechaInicio7, "rptMotoresVenta.rpt")
            reporte1.SetParameterValue("cbFecFinal", FechaFinal7, "rptMotoresVenta.rpt")
            reporte1.SetParameterValue("Titulo", "Motores", "rptMotoresVenta.rpt")
            reporte1.SetParameterValue("cbFecInicio", FechaInicio8, "rptGerencialJobsVenta.rpt")
            reporte1.SetParameterValue("cbFecFin", FechaFinal8, "rptGerencialJobsVenta.rpt")
            reporte1.SetParameterValue("cbFecInicio", FechaInicio9, "rptGerenciaJobFacturados.rpt")
            reporte1.SetParameterValue("cbFecFinal", FechaFinal9, "rptGerenciaJobFacturados.rpt")
            reporte1.SetParameterValue("FecInicio", FechaInicio11, "rpRepGerImportaciones1.rpt")
            reporte1.SetParameterValue("FecFinal", FechaFinal11, "rpRepGerImportaciones1.rpt")
            reporte1.SetParameterValue("FecInicio", FechaInicio12, "rpRepGerImportaciones2.rpt")
            reporte1.SetParameterValue("FecFinal", FechaFinal12, "rpRepGerImportaciones2.rpt")
            reporte1.SetParameterValue("FecInicio", FechaInicio13, "rpRepGerImportaciones3.rpt")
            reporte1.SetParameterValue("FecFinal", FechaFinal13, "rpRepGerImportaciones3.rpt")
            reporte1.SetParameterValue("FecInicio", FechaInicio14, "rpRepGerImportaciones4.rpt")
            reporte1.SetParameterValue("FecFinal", FechaFinal14, "rpRepGerImportaciones4.rpt")
            reporte1.SetParameterValue("FecInicio", FechaInicio16, "rpRepGerCreditos.rpt")
            reporte1.SetParameterValue("FecFinal", FechaFinal16, "rpRepGerCreditos.rpt")

            forma.Text = "Reporte Consolidado"
            forma.ShowDialog()

        End If

    End Sub

    Private Sub biLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biLimpiar.Click

        For i As Integer = 1 To DtTotal.Rows.Count
            DtTotal.Rows.RemoveAt(0)
        Next

        dgvDatos.DataSource = Nothing

        Tipo1 = False
        Tipo2 = False
        Tipo3 = False
        Tipo4 = False
        Tipo5 = False
        Tipo6 = False
        Tipo7 = False
        Tipo8 = False
        Tipo9 = False
        Tipo10 = False
        Tipo11 = False
        Tipo12 = False
        Tipo13 = False
        Tipo14 = False
        Tipo15 = False
        Tipo16 = False
        Tipo17 = False
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click
        Actualizar()
    End Sub

    Private Sub Actualizar()

        For i As Integer = 1 To DtTotal.Rows.Count
            DtTotal.Rows.RemoveAt(0)
        Next

        dgvDatos.DataSource = Nothing

        If Tipo1 = True Then
            row = DtTotal.NewRow
            row(0) = "Reporte Gerencial de Ventas"
            row(1) = "1"
            row(2) = "V"
            DtTotal.Rows.Add(row)
        End If
        If Tipo2 = True Then
            row = DtTotal.NewRow
            row(0) = "Reporte Resumen Garantias"
            row(1) = "2"
            row(2) = "V"
            DtTotal.Rows.Add(row)
        End If
        If Tipo3 = True Then
            row = DtTotal.NewRow
            row(0) = "Reporte de Factura por Adelantos"
            row(1) = "3"
            row(2) = "V"
            DtTotal.Rows.Add(row)
        End If
        If Tipo4 = True Then
            row = DtTotal.NewRow
            row(0) = "Reporte de Detalle de Servicios en IGV"
            row(1) = "4"
            row(2) = "V"
            DtTotal.Rows.Add(row)
        End If
        If Tipo5 = True Then
            row = DtTotal.NewRow
            row(0) = "Reporte de Consolidado de Ventas"
            row(1) = "5"
            row(2) = "V"
            DtTotal.Rows.Add(row)
        End If
        If Tipo6 = True Then
            row = DtTotal.NewRow
            row(0) = "Reporte de Record de Ventas por Cliente"
            row(1) = "6"
            row(2) = "V"
            DtTotal.Rows.Add(row)
        End If
        If Tipo7 = True Then
            row = DtTotal.NewRow
            row(0) = "Reporte de Motores Vendidos"
            row(1) = "7"
            row(2) = "H"
            DtTotal.Rows.Add(row)
        End If
        If Tipo8 = True Then
            row = DtTotal.NewRow
            row(0) = "Reporte de Consolidado de Jobs"
            row(1) = "8"
            row(2) = "V"
            DtTotal.Rows.Add(row)
        End If
        'If Tipo9 = False Then
        '    FechaInicio9 = "01/01/2012"
        '    FechaFinal9 = "01/09/2012"
        'End If
        If Tipo10 = True Then
            row = DtTotal.NewRow
            row(0) = "Reporte de Ventas vs Presupuesto"
            row(1) = "10"
            row(2) = "V"
            DtTotal.Rows.Add(row)
        End If
        If Tipo11 = True Then
            row = DtTotal.NewRow
            row(0) = "Resumen de Importaciones"
            row(1) = "11"
            row(2) = "V"
            DtTotal.Rows.Add(row)
        End If
        If Tipo12 = True Then
            row = DtTotal.NewRow
            row(0) = "Detalle de Importaciones"
            row(1) = "12"
            row(2) = "V"
            DtTotal.Rows.Add(row)
        End If
        If Tipo13 = True Then
            row = DtTotal.NewRow
            row(0) = "Pedido de Importaciones"
            row(1) = "13"
            row(2) = "V"
            DtTotal.Rows.Add(row)
        End If
        If Tipo14 = True Then
            row = DtTotal.NewRow
            row(0) = "Reporte de Importaciones por Proveedor"
            row(1) = "14"
            row(2) = "V"
            DtTotal.Rows.Add(row)
        End If
        If Tipo15 = True Then
            row = DtTotal.NewRow
            row(0) = "Reporte de Stock Valorizado"
            row(1) = "15"
            row(2) = "V"
            DtTotal.Rows.Add(row)
        End If
        If Tipo16 = True Then
            row = DtTotal.NewRow
            row(0) = "Reporte de Ventas vs Cobranza sin IGV"
            row(1) = "16"
            row(2) = "V"
            DtTotal.Rows.Add(row)
        End If
        If Tipo17 = True Then
            row = DtTotal.NewRow
            row(0) = "Reporte de Cuadro de Ventas"
            row(1) = "17"
            row(2) = "H"
            DtTotal.Rows.Add(row)
        End If

        dgvDatos.DataSource = DtTotal
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biImprimir2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir2.Click

        Dim reporte2 As New rptConsolidadoReportesHorizontal
        Dim forma As New frmReportes
        Dim i As Integer = 0
        Dim a17 As String = ""
        Dim a18 As String = ""

        If Tipo7 = False Then
            FechaInicio7 = "01/01/2012"
            FechaFinal7 = "10/01/2012"
        End If
        If Tipo17 = False Then
            FechaInicio17 = "01/01/2012"
            FechaFinal17 = "15/01/2012"
        End If

        If Tipo7 = False And Tipo17 = False Then
            MsgBox("No hay Datos en el Reporte Consolidado, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
        Else
            dtReporte7 = oDocumentoCostoService.ReporteMotoresVendidos(0, FechaInicio7, FechaFinal7).Tables(0)
            If dtReporte7.Rows.Count > 0 Then
                If Tipo7 = True Then
                    a17 = "Supr"
                Else
                    a17 = "No"
                End If
            End If

            dtReporte17 = oReporteVentaService.ReporteGerCuadroVenta(Session.sCodEmp, FechaInicio17, FechaFinal17, CodMon17, Cliente17, 1).Tables(0)
            If dtReporte17.Rows.Count > 0 Then
                If Tipo17 = True Then
                    a18 = "Supr"
                Else
                    a18 = "No"
                End If
            End If

            'dgvDatos.DataSource = DtTotal

            If reporte2.Subreports.Count > 0 Then

                reporte2.Subreports("rptMotoresVenta.rpt").SetDataSource(dtReporte7)
                reporte2.Subreports("rpRepGerContabilidad.rpt").SetDataSource(dtReporte17)

            End If

            reporte2.SetDataSource(dtReporte1)
            forma.crvReportes.ReportSource = reporte2
            ' Validar Usuario - Exportar Excel
            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                forma.crvReportes.ShowExportButton = True
            Else
                forma.crvReportes.ShowExportButton = False
            End If

            forma.crvReportes.DisplayGroupTree = False


            reporte2.SetParameterValue("Tipo7", IIf(a17 = "Supr", "1", "0"))
            reporte2.SetParameterValue("Tipo17", IIf(a18 = "Supr", "1", "0"))

            reporte2.SetParameterValue("cbFecInicio", FechaInicio7, "rptMotoresVenta.rpt")
            reporte2.SetParameterValue("cbFecFinal", FechaFinal7, "rptMotoresVenta.rpt")
            reporte2.SetParameterValue("Titulo", "Motores", "rptMotoresVenta.rpt")
            If CodMon17 = "US" Then
                reporte2.SetParameterValue("Moneda", "DOLARES USA", "rpRepGerContabilidad.rpt")
            Else
                reporte2.SetParameterValue("Moneda", "NUEVOS SOLES", "rpRepGerContabilidad.rpt")
            End If
            'reporte2.SetParameterValue("Moneda", "Motores", "rpRepGerContabilidad.rpt")
            reporte2.SetParameterValue("FecInicio", FechaInicio17, "rpRepGerContabilidad.rpt")
            reporte2.SetParameterValue("FecFinal", FechaFinal17, "rpRepGerContabilidad.rpt")

            forma.Text = "Reporte Consolidado"
            forma.ShowDialog()

        End If


    End Sub
End Class
