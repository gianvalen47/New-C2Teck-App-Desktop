Imports System.Windows.Forms
Imports System.ServiceModel

Public Class frmIndicadorGrafica

    Private oReporteVentaService As New ReporteVentaService.ReporteVentaServiceClient

    Public iFecha As Date
    Public iGrupo As Integer
    Public iTipo As String
    Public iTitulo As String
    Public iPB As Integer
    Public iObjetivo As Integer
    Public Semaforo As String

    Dim dtGrafica As DataTable
    Dim dtTabla As DataTable
    Dim dtTableM As DataTable
    Dim dtTableM2 As DataTable
    Dim row As DataRow
    Dim col As DataColumn

    Private Sub frmIndicadorGrafica_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oReporteVentaService.Close()
        Catch ex As TimeoutException
            oReporteVentaService.Abort()
        Catch ex As CommunicationException
            oReporteVentaService.Abort()
        End Try
    End Sub

    Private Sub frmIndicadorGrafica_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmIndicadorGrafica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Grafica()
        VerificarSemaforo()

    End Sub

    Private Sub VerificarSemaforo()
        'Dim numcol As Integer
        'Dim numfila As Integer
        'numcol = dgvTabla.ColumnCount
        'numfila = dgvTabla.Rows(2).Cells(numcol - 1).Value
        If Semaforo = "R" Then
            pbVerde.Visible = False
            pbRojo.Visible = True
            pbAmarillo.Visible = False
        ElseIf Semaforo = "A" Then
            pbVerde.Visible = False
            pbRojo.Visible = False
            pbAmarillo.Visible = True
        ElseIf Semaforo = "V" Then
            pbVerde.Visible = True
            pbRojo.Visible = False
            pbAmarillo.Visible = False
        End If

    End Sub

    Function PrimerDiaDelMes(ByVal dtmFecha As Date) As Date
        PrimerDiaDelMes = DateSerial(Year(dtmFecha), Month(dtmFecha), 1)
    End Function

    Function UltimoDiaDelMes(ByVal dtmFecha As Date) As Date
        UltimoDiaDelMes = DateSerial(Year(dtmFecha), Month(dtmFecha) + 1, 0)
    End Function

    Private Sub Grafica()
        Try
            If iTipo = "Diaria" Then
                dtGrafica = oReporteVentaService.ReporteIndicadoresComercial(Session.sCodEmp, PrimerDiaDelMes(iFecha), iFecha, iGrupo, 2).Tables(0)
                dgvGrafica.DataSource = dtGrafica

                dtTabla = oReporteVentaService.ReporteIndicadoresComercial(Session.sCodEmp, PrimerDiaDelMes(iFecha), iFecha, iGrupo, 1).Tables(0)

                AgregarFilaPorcentaje()
                AgregarFormatoMiles()

                'dgvTabla.DataSource = dtTableM
                Dim estilo1 As New Estilo
                estilo1.cargaEstiloDataDrid(dgvTabla)

                lblDefinicion.Text = "Cumplimiento del Pronóstico Mensual"
                lblMedicion.Text = "Diaria"
                lblReporte.Text = "Semanal"
                lblTitulo.Text = iTitulo
                'Comentado 24-01-13
                'If iTitulo = "Cumplimiento al Presupuesto Motores" Then
                '    lblObservaciones.Text = "Motores y Accesorios"
                'ElseIf iTitulo = "Cumplimiento al Presupuesto Repuestos" Then
                '    lblObservaciones.Text = "Consignación"
                'ElseIf iTitulo = "Cumplimiento al Presupuesto Servicios" Then
                '    lblObservaciones.Text = "Repuestos de Servicio"
                'ElseIf iTitulo = "Cumplimiento al Presupuesto Filtros y Baterías" Then
                '    lblObservaciones.Text = "Filtros"
                'Else
                '    lblObservaciones.Text = ""
                'End If
                lblObservaciones.Text = ""
                lblNotapie.Text = "Dias del Mes"

            ElseIf iTipo = "Mensual" Then

                Dim PrimerDiadelAño As String
                Dim UltimoDiadelAño As String

                PrimerDiadelAño = "01/01/" & Year(iFecha)
                UltimoDiadelAño = "31/12/" & Year(iFecha)

                dtGrafica = oReporteVentaService.ReporteIndicadoresComercial(Session.sCodEmp, CDate(PrimerDiadelAño), UltimoDiaDelMes(iFecha), iGrupo, 2).Tables(0)
                'dtGrafica = oReporteVentaService.ReporteIndicadoresComercial(Session.sCodEmp, CDate(PrimerDiadelAño), CDate(iFecha), iGrupo, 2).Tables(0)
                dgvGrafica.DataSource = dtGrafica

                dtTabla = oReporteVentaService.ReporteIndicadoresComercial(Session.sCodEmp, CDate(PrimerDiadelAño), UltimoDiaDelMes(iFecha), iGrupo, 1).Tables(0)
                'dtTabla = oReporteVentaService.ReporteIndicadoresComercial(Session.sCodEmp, CDate(PrimerDiadelAño), CDate(iFecha), iGrupo, 1).Tables(0)

                AgregarFilaPorcentaje()
                AgregarFormatoMiles()

                'dgvTabla.DataSource = dtTableM
                Dim estilo1 As New Estilo
                estilo1.cargaEstiloDataDrid(dgvTabla)

                lblDefinicion.Text = "Cumplimiento del Pronóstico Anual"
                lblMedicion.Text = "Mensual"
                lblReporte.Text = "Mensual"
                lblTitulo.Text = iTitulo
                'Comentado 24-01-13
                'If iTitulo = "Cumplimiento al Presupuesto Motores" Then
                '    lblObservaciones.Text = "Motores y Accesorios"
                'ElseIf iTitulo = "Cumplimiento al Presupuesto Repuestos" Then
                '    lblObservaciones.Text = "Consignación"
                'ElseIf iTitulo = "Cumplimiento al Presupuesto Servicios" Then
                '    lblObservaciones.Text = "Repuestos de Servicio"
                'ElseIf iTitulo = "Cumplimiento al Presupuesto Filtros y Baterías" Then
                '    lblObservaciones.Text = "Filtros"
                'Else
                '    lblObservaciones.Text = ""
                'End If
                lblObservaciones.Text = ""
                lblNotapie.Text = "Meses del Año"

            End If

            If dtGrafica.Rows.Count = 0 Then
                ChartEstadistica.Visible = False
            Else
                ChartEstadistica.Visible = True
                ChartEstadistica.chartType = MSChart20Lib.VtChChartType.VtChChartType2dLine

                ChartEstadistica.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).Labels(1).Format = "0,000"

                ChartEstadistica.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY2).Labels(1).Format = "0"

                ChartEstadistica.RowCount = dgvGrafica.RowCount - 1
                ChartEstadistica.ColumnCount = 2
                If iTipo = "Diaria" Then
                    ChartEstadistica.Title.Text = "VENTAS MENSUALES" '    
                    ChartEstadistica.Plot.SeriesCollection(1).LegendText = "DIAS DEL MES"
                Else
                    ChartEstadistica.Title.Text = "VENTAS ANUALES" '
                    ChartEstadistica.Plot.SeriesCollection(1).LegendText = "MESES DEL AÑO"

                End If

                ChartEstadistica.Plot.SeriesCollection(1).LegendText = "TotVenta"
                ChartEstadistica.Plot.SeriesCollection(2).LegendText = "Presupuesto"

                'dgvTabla.DataSource = dtTabla

                For I = 0 To dgvGrafica.Rows.Count - 2

                    If iTipo = "Diaria" Then
                        ChartEstadistica.Row = I + 1
                        ChartEstadistica.RowLabel = Mid((dgvGrafica.Rows(I).Cells("FecDoc").Value), 1, 2)
                    Else
                        ChartEstadistica.Row = I + 1
                        ChartEstadistica.RowLabel = dgvGrafica.Rows(I).Cells("NombreMes").Value
                    End If

                    ChartEstadistica.Plot.SeriesCollection(1).LegendText = "Venta"
                    ChartEstadistica.Plot.SeriesCollection(2).LegendText = "Presupuesto"

                    ChartEstadistica.Column = 1
                    ChartEstadistica.Data = dgvGrafica.Rows(I).Cells("TotVenta").Value()

                    ChartEstadistica.Column = 2
                    ChartEstadistica.Data = dgvGrafica.Rows(I).Cells("Presupuesto").Value()

                Next

            End If

        Catch ex As Exception
            MsgBox("Error al Mostrar los Indicadores" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub AgregarFormatoMiles()

        'Dim i As Integer
        'Dim j As Integer

        dtTableM2 = dtTableM.Copy
        dtTableM2.Clear()

        For i = 0 To dtTableM.Rows.Count - 2
            'row = dtTableM.NewRow

            If i <> dtTableM.Rows.Count Then

                For j = 0 To dtTableM2.Columns.Count - 1
                    'row(j) = dtTabla.Rows(i).Item(j)
                    If j = 0 Then
                        'row(j) = dtTableM.Rows(i).Item(j)
                    Else
                        dgvTabla.Columns(j).DefaultCellStyle.Format = "##,##0"
                        dgvTabla.Rows(i).DefaultCellStyle.Format = "##,##0"
                        'dgvTabla.Columns(j).DefaultCellStyle.Format = "##,##0.00"
                        'dgvTabla.Rows(i).DefaultCellStyle.Format = "##,##0.00"
                        'row(j) = dtTableM.Rows(i).Item(j)
                    End If

                Next
            End If
        Next

        'For i = 0 To dtTabla.Rows.Count - 1
        '    row = dtTableM.NewRow

        '    'If i <> dtTabla.Rows.Count Then

        '    For j = 0 To dtTableM.Columns.Count - 1
        '        If j = 0 Then
        '            row(j) = dtTabla.Rows(i).Item(j)
        '        Else
        '            row(j) = dtTabla.Rows(i).Item(j)
        '        End If

        '    Next

        '    dtTableM.Rows.Add(row)
        '    'Else
        '    'End If
        'Next

        'dgvTabla.DataSource = dtTableM

        'For j = 1 To dtTableM.Columns.Count - 1
        '    dgvTabla.Columns(j).DefaultCellStyle.Format = "##,##0.00"
        '    'dgvTabla.RowsDefaultCellStyle(j).DefaultCellStyle.Format = "##,##0.00"
        'Next


    End Sub


    Private Sub AgregarFilaPorcentaje()

        Dim NumColumnas As Integer

        dtTableM = dtTabla.Copy
        dtTableM.Clear()

        NumColumnas = dtTableM.Columns.Count

        For i = 0 To dtTabla.Rows.Count
            row = dtTableM.NewRow

            If i <> dtTabla.Rows.Count Then

                For j = 0 To dtTableM.Columns.Count - 1
                    row(j) = dtTabla.Rows(i).Item(j)

                Next
            Else
                For j = 0 To dtTableM.Columns.Count - 1

                    If j = 0 Then
                        row(0) = "Porcentaje (%)"
                    Else
                        If dtTabla.Rows(0).Item(j) = 0 Then
                            row(j) = 0
                            'row(j) = 100
                        Else
                            row(j) = Format(((dtTabla.Rows(0).Item(j) / IIf(dtTabla.Rows(1).Item(j) = 0, 1, dtTabla.Rows(1).Item(j))) * 100), "0.00")
                        End If
                    End If
                Next
            End If
            dtTableM.Rows.Add(row)

        Next
        dgvTabla.DataSource = dtTableM

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class