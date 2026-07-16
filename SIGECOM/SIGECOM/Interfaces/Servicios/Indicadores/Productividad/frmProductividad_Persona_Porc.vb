
Imports System.ServiceModel

Public Class frmProductividad_Persona_Porc

    Public JobVen As Double
    Public JobInt As Double
    Public JobGar As Double
    Public JobAse As Double
    Public JobCap As Double
    Public Diferencia As Double

    Private Sub frmProductividad_Persona_Porc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GraficoPie()
    End Sub

    Private Sub GraficoPie()
        Try
            ChartTipo3.Visible = True
            ChartTipo3.chartType = MSChart20Lib.VtChChartType.VtChChartType2dPie

            ChartTipo3.Footnote.Location.Visible = False
            ChartTipo3.Legend.Location.LocationType = MSChart20Lib.VtChLocationType.VtChLocationTypeRight

            ChartTipo3.Title.Text = "PORCENTAJE POR COLABORADOR"
            ChartTipo3.ColumnCount = 6

            ChartTipo3.Row = 1
            ChartTipo3.RowLabel = ""
            'Dim i As Integer = 0
            'For i = 0 To dgvTipo3.Rows.Count - 2
            ChartTipo3.Column = 1
            ChartTipo3.Data = JobVen

            ChartTipo3.Plot.SeriesCollection(1).LegendText = "Job Venta" & " (" & JobVen & "%)"
            '----------------------------------------------------------------------------------
            ChartTipo3.Column = 2
            ChartTipo3.Data = JobInt

            ChartTipo3.Plot.SeriesCollection(2).LegendText = "Job Interno" & " (" & JobInt & "%)"
            '----------------------------------------------------------------------------------
            ChartTipo3.Column = 3
            ChartTipo3.Data = JobGar

            ChartTipo3.Plot.SeriesCollection(3).LegendText = "Job Garantia" & " (" & JobGar & "%)"
            '----------------------------------------------------------------------------------
            ChartTipo3.Column = 4
            ChartTipo3.Data = JobAse

            ChartTipo3.Plot.SeriesCollection(4).LegendText = "Job Asesoria" & " (" & JobAse & "%)"
            '----------------------------------------------------------------------------------
            ChartTipo3.Column = 5
            ChartTipo3.Data = JobCap

            ChartTipo3.Plot.SeriesCollection(5).LegendText = "Job Capacitación" & " (" & JobCap & "%)"
            '----------------------------------------------------------------------------------
            ChartTipo3.Column = 6
            ChartTipo3.Data = Diferencia

            ChartTipo3.Plot.SeriesCollection(6).LegendText = "Diferencia" & " (" & -1 * Diferencia & "%)"
            '----------------------------------------------------------------------------------

            'Next

            For i = 1 To 6
                With ChartTipo3.Plot.SeriesCollection(i).DataPoints(-1).DataPointLabel
                    .LocationType = MSChart20Lib.VtChLabelLocationType.VtChLabelLocationTypeBase
                    '.VtFont.VtColor.Set(245, 245, 220)
                    .VtFont.VtColor.Set(0, 0, 0)
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

    Private Sub frmProductividad_Persona_Porc_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
End Class