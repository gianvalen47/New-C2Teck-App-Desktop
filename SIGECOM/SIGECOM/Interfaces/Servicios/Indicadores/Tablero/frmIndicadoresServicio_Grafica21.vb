Imports System.Windows.Forms
Imports System.ServiceModel
Imports System.Globalization

Public Class frmIndicadoresServicio_Grafica21

    Private oJobService As New JobService.JobServiceClient

    Private dtReporteTipo81 As New DataTable
    Private dtReporteTipo82 As New DataTable
    Public IdProgramacion As Integer
    Public Fecha As Date
    Public FechaEscogida As Date

    Private Sub frmIndicadoresServicio_Grafico2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
        End Try
    End Sub

    Private Sub frmIndicadoresServicio_Grafico2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmIndicadoresServicio_Grafico2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            ChartTipo82.Enabled = False



            dtReporteTipo81 = oJobService.ReporteIndicadores(Session.sCodEmp, Fecha, Fecha, 0, 0, "", 8, IdProgramacion, 1).Tables(0)
            dgvTipo81.DataSource = dtReporteTipo81

            'dtReporteTipo81 = oJobService.ReporteIndicadores(Session.sCodEmp, Fecha, FechaEscogida, 0, 0, "", 8, IdProgramacion, 1).Tables(0)
            'dgvTipo81.DataSource = dtReporteTipo81

            Dim estilo1 As New Estilo
            estilo1.cargaEstiloDataDrid(dgvTipo81)

            dtReporteTipo82 = oJobService.ReporteIndicadores(Session.sCodEmp, Fecha, Fecha, 0, 0, "", 8, IdProgramacion, 2).Tables(0)
            dgvTipo82.DataSource = dtReporteTipo82

            'dtReporteTipo82 = oJobService.ReporteIndicadores(Session.sCodEmp, Fecha, FechaEscogida, 0, 0, "", 8, IdProgramacion, 2).Tables(0)
            'dgvTipo82.DataSource = dtReporteTipo82

            ObtenerJobDatos()
            GraficoTipo7()

        Catch ex As Exception
            MsgBox("Error al Cargar el Formulario. " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
        'GraficoTipo7()
    End Sub

    Private Sub ObtenerJobDatos()
        If IdProgramacion = 0 Then
            lblNumJob.Visible = False
            lblUbiMantMot.Visible = False
        Else
            lblNumJob.Visible = True
            lblUbiMantMot.Visible = True
            lblNumJob.Text = "Job : " & dgvTipo82.Rows(0).Cells("CodJob").Value()
            lblUbiMantMot.Text = dgvTipo82.Rows(0).Cells("DesUbicacion").Value() & "-" & dgvTipo82.Rows(0).Cells("DesMantenimiento").Value() & "-" & dgvTipo82.Rows(0).Cells("TipMot").Value()
        End If
    End Sub

    Private Sub GraficoTipo7()

        Try
            If dtReporteTipo82.Rows.Count = 0 Then
                ChartTipo82.Visible = False
            Else
                ChartTipo82.Visible = True
                ChartTipo82.chartType = MSChart20Lib.VtChChartType.VtChChartType2dBar

                ChartTipo82.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).Labels(1).Format = "0"
                ChartTipo82.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY2).Labels(1).Format = "0"
                'ChartTipo82.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY2).ValueScale.Maximum = 100
                'ChartTipo82.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).ValueScale.Maximum = 100

                ChartTipo82.RowCount = dgvTipo82.RowCount - 1 + 2
                ChartTipo82.ColumnCount = 1

                ChartTipo82.Title.Text = "INDICADOR (PAGO DE HORAS EXTRAS) EN %" '    

                ChartTipo82.Row = 1
                ChartTipo82.RowLabel = "PB" 'dgvTipo82.Rows(i).Cells("PB").Value

                ChartTipo82.Column = 1
                ChartTipo82.Data = dgvTipo82.Rows(0).Cells("PB").Value()

                For i = 0 To dgvTipo82.Rows.Count - 2

                    ChartTipo82.Row = i + 1 + 1
                    ChartTipo82.RowLabel = dgvTipo82.Rows(i).Cells("Semana").Value & " - " & Mid(dgvTipo82.Rows(i).Cells("Anio").Value, 3, 2)

                    ChartTipo82.Column = 1
                    ChartTipo82.Data = dgvTipo82.Rows(i).Cells("PorHorasExtras").Value()
                    'ChartTipo82.Data = dgvTipo82.Rows(i).Cells("MontoHorasExtras").Value()
                Next

                ChartTipo82.Row = dgvTipo82.Rows.Count + 1
                ChartTipo82.RowLabel = "OBJETIVO" 'dgvTipo82.Rows(0).Cells("Objetivo").Value

                ChartTipo82.Column = 1
                ChartTipo82.Data = 0 'dgvTipo82.Rows(0).Cells("Objetivo").Value()

                'Para poner los valores en la columna
                For iIndex = 1 To ChartTipo82.Plot.SeriesCollection.Count
                    ChartTipo82.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.LocationType = MSChart20Lib.VtChLabelLocationType.VtChLabelLocationTypeBase
                    'ChartGrafico.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.VtFont.Style = MSChart20Lib.VtFontStyle.VtFontStyleBold
                    ChartTipo82.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.VtFont.VtColor.Set(245, 245, 220)
                    ChartTipo82.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.VtFont.Size = 13
                Next iIndex

            End If
        Catch ex As Exception
            MsgBox("Error al Mostrar la gráfica" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    'Private Sub GraficoTipo6()
    '    Try
    '        If dtReporteTipo62.Rows.Count = 0 Then
    '            chartTipo7.Visible = False
    '        Else
    '            chartTipo7.Visible = True
    '            chartTipo7.chartType = MSChart20Lib.VtChChartType.VtChChartType2dLine

    '            chartTipo7.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).Labels(1).Format = "0"

    '            chartTipo7.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY2).Labels(1).Format = "0"

    '            chartTipo7.RowCount = dgvTipo7.RowCount - 1
    '            chartTipo7.ColumnCount = 2
    '            'If iTipo = "Diaria" Then
    '            chartTipo7.Title.Text = "INDICADOR OBJETIVO - PROYECCIÓN"

    '            chartTipo7.Plot.SeriesCollection(1).LegendText = "Objetivo"
    '            chartTipo7.Plot.SeriesCollection(2).LegendText = "Proyeccion"

    '            'dgvTabla.DataSource = dtTabla

    '            For i = 0 To dgvTipo7.Rows.Count - 2

    '                'If iTipo = "Diaria" Then
    '                chartTipo7.Row = i + 1
    '                chartTipo7.RowLabel = Mid((dgvTipo7.Rows(i).Cells("Fecha").Value), 9, 2)

    '                chartTipo7.Column = 1
    '                chartTipo7.Data = dgvTipo7.Rows(i).Cells("Objetivo").Value()

    '                chartTipo7.Column = 2
    '                chartTipo7.Data = dgvTipo7.Rows(i).Cells("Proyeccion").Value()
    '            Next
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error al Mostrar la gráfica" + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Sub GraficoTipo7()
    '    Try
    '        If dtReporteTipo82.Rows.Count = 0 Then
    '            ChartTipo82.Visible = False
    '        Else
    '            ChartTipo82.Visible = True
    '            ChartTipo82.chartType = MSChart20Lib.VtChChartType.VtChChartType2dBar

    '            ChartTipo82.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).Labels(1).Format = "0"
    '            ChartTipo82.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY2).Labels(1).Format = "0"

    '            ChartTipo82.RowCount = dgvTipo82.RowCount - 1 + 2
    '            ChartTipo82.ColumnCount = 1
    '            'ChartTipo82.ColumnCount = 1

    '            'If iTipo = "Diaria" Then
    '            ChartTipo82.Title.Text = "INDICADOR (PAGO DE HORAS EXTRAS) EN %" '    
    '            'chartTipo7.Plot.SeriesCollection(1).LegendText = "DIAS DE LA SEMANA"
    '            '    Else
    '            '    ChartEstadistica.Title.Text = "VENTAS ANUALES" '
    '            '    ChartEstadistica.Plot.SeriesCollection(1).LegendText = "MESES DEL AÑO"
    '            'End If

    '            'ChartTipo82.Plot.SeriesCollection(1).LegendText = "Monto Horas Extras"
    '            'ChartTipo82.Plot.SeriesCollection(2).LegendText = "Proyeccion"

    '            'dgvTabla.DataSource = dtTabla

    '            'ChartTipo82.Column = 1
    '            'ChartTipo82.Data = dgvTipo82.Rows(0).Cells("PB").Value()

    '            ChartTipo82.Row = 1
    '            ChartTipo82.RowLabel = "PB" 'dgvTipo82.Rows(i).Cells("PB").Value

    '            ChartTipo82.Column = 1
    '            ChartTipo82.Data = dgvTipo82.Rows(0).Cells("PB").Value()

    '            For i = 0 To dgvTipo82.Rows.Count - 2

    '                ChartTipo82.Row = i + 1 + 1
    '                ChartTipo82.RowLabel = dgvTipo82.Rows(i).Cells("Semana").Value & " - " & Mid(dgvTipo82.Rows(i).Cells("Anio").Value, 3, 2)

    '                ChartTipo82.Column = 1
    '                ChartTipo82.Data = dgvTipo82.Rows(i).Cells("PorHorasExtras").Value()
    '                'ChartTipo82.Data = dgvTipo82.Rows(i).Cells("MontoHorasExtras").Value()
    '            Next

    '            'ChartTipo82.Row = 2
    '            'ChartTipo82.RowLabel = dgvTipo82.Rows(0).Cells("Semana").Value & " - " & Mid(dgvTipo82.Rows(0).Cells("Anio").Value, 3, 2)

    '            'ChartTipo82.Column = 1
    '            'ChartTipo82.Data = dgvTipo82.Rows(0).Cells("MontoHorasExtras").Value()

    '            ChartTipo82.Row = dgvTipo82.Rows.Count + 1
    '            ChartTipo82.RowLabel = "OBJETIVO" 'dgvTipo82.Rows(0).Cells("Objetivo").Value

    '            ChartTipo82.Column = 1
    '            ChartTipo82.Data = 100 'dgvTipo82.Rows(0).Cells("Objetivo").Value()

    '            'ChartTipo82.Column = 3
    '            'ChartTipo82.Data = 90 'dgvTipo82.Rows(0).Cells("Objetivo").Value()

    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error al Mostrar la gráfica" + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
    '    Dim frm As New frmIndicadoresServicio_Grafica22
    '    'Dim fechaLunes As DateTime = GetFirstDayOfWeek(txtFecha.Value.Date)
    '    frm.Fecha = Fecha
    '    frm.FechaEscogida = FechaEscogida
    '    frm.IdProgramacion = IdProgramacion
    '    frm.ShowDialog
    'End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class
