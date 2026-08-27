Imports System.Windows.Forms
Imports System.ServiceModel
Imports System.Globalization

Public Class frmIndicadoresServicio_Grafica12

    Private oJobService As New JobService.JobServiceClient

    Public Fecha As Date
    Public FechaEscogida As Date
    Private dtReporteTipo3 As New DataTable
    Private dtReporteTipo4 As New DataTable
    Private dtReporteTipo5 As New DataTable
    Private dtReporteTipo61 As New DataTable
    Private dtReporteTipo62 As New DataTable
    Private dtReporteTipo71 As New DataTable
    Private dtReporteTipo72 As New DataTable
    Public IdProgramacion As Integer
    Public NumJob As String
    Dim arrPrices(0 To 6)
    Dim i As Integer

    Private Sub frmIndicadoresServicio_Grafica12_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
        End Try
    End Sub

    Private Sub frmIndicadoresServicio_Grafica12_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmIndicadoresServicio_Grafica12_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ChartTipo3.Enabled = False
            chartTipo9.Enabled = False

            lblNumJob.Text = NumJob
            lblNumJob2.Text = NumJob

            dtReporteTipo3 = oJobService.ReporteIndicadores(Session.sCodEmp, Fecha, FechaEscogida, 0, 0, "", 3, IdProgramacion, 0).Tables(0)
            dgvTipo3.DataSource = dtReporteTipo3

            dtReporteTipo71 = oJobService.ReporteIndicadores(Session.sCodEmp, Fecha, FechaEscogida, 0, 0, "", 7, IdProgramacion, 1).Tables(0)
            dgvTipo8.DataSource = dtReporteTipo71

            Dim estilo1 As New Estilo
            estilo1.cargaEstiloDataDrid(dgvTipo8)

            dtReporteTipo72 = oJobService.ReporteIndicadores(Session.sCodEmp, Fecha, FechaEscogida, 0, 0, "", 7, IdProgramacion, 2).Tables(0)
            dgvTipo9.DataSource = dtReporteTipo72

            GraficoTipo3()
            GraficoTipo7()

        Catch ex As Exception
            MsgBox("Error al Cargar el Formulario. " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub


    Private Sub GraficoTipo3()
        Try
            ChartTipo3.Visible = True
            ChartTipo3.chartType = MSChart20Lib.VtChChartType.VtChChartType2dPie
            'ChartEstadistica.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).Labels(1).Format = "0"
            'ChartEstadistica.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).AxisTitle.Visible = False
            'ChartEstadistica.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdX).AxisTitle.Visible = False
            ChartTipo3.Footnote.Location.Visible = False
            ChartTipo3.Legend.Location.LocationType = MSChart20Lib.VtChLocationType.VtChLocationTypeRight
            'ChartEstadistica.Legend.Location.LocationType = MSChart20Lib.VtChLocationType.VtChLocationTypeTop
            ChartTipo3.Title.Text = "CAUSAS DE DEMORA"
            ChartTipo3.ColumnCount = 7

            ChartTipo3.Row = 1
            ChartTipo3.RowLabel = ""
            Dim i As Integer = 0
            For i = 0 To dgvTipo3.Rows.Count - 2
                ChartTipo3.Column = i + 1
                ChartTipo3.Data = dgvTipo3.Rows(i).Cells("Porcentaje").Value()

                ChartTipo3.Plot.SeriesCollection(i + 1).LegendText = dgvTipo3.Rows(i).Cells("DesAtraso").Value() & " (" & Math.Round(dgvTipo3.Rows(i).Cells("Porcentaje").Value(), 2) & "%)"
            Next

            For i = 1 To ChartTipo3.Plot.SeriesCollection.Count
                With ChartTipo3.Plot.SeriesCollection(i).DataPoints(-1).DataPointLabel
                    .LocationType = MSChart20Lib.VtChLabelLocationType.VtChLabelLocationTypeBase
                    .VtFont.VtColor.Set(245, 245, 220)
                    .Component = MSChart20Lib.VtChLabelComponent.VtChLabelComponentPercent
                    .PercentFormat = "0%"
                    .VtFont.Size = 10
                    '.VtFont.

                End With
            Next i
        Catch ex As Exception
            MsgBox("Error al Mostrar la gráfica" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub GraficoTipo7()
        Try
            If dtReporteTipo72.Rows.Count = 0 Then
                chartTipo9.Visible = False
            Else
                chartTipo9.Visible = True
                chartTipo9.chartType = MSChart20Lib.VtChChartType.VtChChartType2dBar

                chartTipo9.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).Labels(1).Format = "0"

                chartTipo9.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY2).Labels(1).Format = "0"

                chartTipo9.RowCount = dgvTipo9.RowCount - 1 + 2
                chartTipo9.ColumnCount = 1
                'If iTipo = "Diaria" Then
                chartTipo9.Title.Text = "% CUMPLIMIENTO ACTIVIDADES PLANEADAS" '    
                'chartTipo9.Plot.SeriesCollection(1).LegendText = "DIAS DE LA SEMANA"
                '    Else
                '    ChartEstadistica.Title.Text = "VENTAS ANUALES" '
                '    ChartEstadistica.Plot.SeriesCollection(1).LegendText = "MESES DEL AÑO"
                'End If

                'chartTipo9.Plot.SeriesCollection(1).LegendText = ""
                'chartTipo9.Plot.SeriesCollection(2).LegendText = "Proyeccion"

                'dgvTabla.DataSource = dtTabla

                chartTipo9.Row = 1
                chartTipo9.RowLabel = "PB" 'dgvTipo82.Rows(i).Cells("PB").Value

                chartTipo9.Column = 1
                chartTipo9.Data = 40
                Dim i As Integer = 0
                For i = 0 To dgvTipo9.Rows.Count - 2

                    'If iTipo = "Diaria" Then
                    chartTipo9.Row = i + 1 + 1
                    chartTipo9.RowLabel = dgvTipo9.Rows(i).Cells("Fecha").Value
                    'chartTipo9.RowLabel = Mid((dgvTipo9.Rows(i).Cells("Fecha").Value), 9, 2)

                    chartTipo9.Column = 1
                    chartTipo9.Data = dgvTipo9.Rows(i).Cells("CumplimientoActividades").Value()

                    'chartTipo9.Column = 2
                    'chartTipo9.Data = dgvTipo7.Rows(i).Cells("Proyeccion").Value()
                Next

                chartTipo9.Row = dgvTipo9.Rows.Count + 1
                chartTipo9.RowLabel = "OBJETIVO" 'dgvTipo82.Rows(0).Cells("Objetivo").Value

                chartTipo9.Column = 1
                chartTipo9.Data = 100 'dgvTipo82.Rows(0).Cells("Objetivo").Value()

                For iIndex = 1 To chartTipo9.Plot.SeriesCollection.Count
                    chartTipo9.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.LocationType = MSChart20Lib.VtChLabelLocationType.VtChLabelLocationTypeOutside
                    chartTipo9.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.VtFont.Style = MSChart20Lib.VtFontStyle.VtFontStyleBold
                    chartTipo9.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.VtFont.VtColor.Set(0, 0, 0)
                    chartTipo9.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.VtFont.Size = 12
                Next iIndex

            End If
        Catch ex As Exception
            MsgBox("Error al Mostrar la gráfica" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Dim frm As New frmIndicadoresServicio_Grafica13
        'Dim fechaLunes As DateTime = GetFirstDayOfWeek(txtFecha.Value.Date)
        frm.Fecha = Fecha
        frm.FechaEscogida = FechaEscogida
        frm.IdProgramacion = IdProgramacion
        frm.NumJob = NumJob
        'frm.ShowDialog()
        If frm.ShowDialog = System.Windows.Forms.DialogResult.Cancel Then
            'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            'Me.Close()
        End If


    End Sub

    Private Sub btnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAtradoDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtradoDet.Click
        Dim frm As New frmIndicadoresServicio_Grafica14
        'Dim fechaLunes As DateTime = GetFirstDayOfWeek(txtFecha.Value.Date)
        frm.Fecha = Date.Today
        frm.FechaEscogida = Date.Today
        frm.IdProgramacion = IdProgramacion
        frm.NumJob = NumJob
        'frm.ShowDialog()
        If frm.ShowDialog = System.Windows.Forms.DialogResult.Cancel Then
            'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            'Me.Close()
        End If
    End Sub
End Class