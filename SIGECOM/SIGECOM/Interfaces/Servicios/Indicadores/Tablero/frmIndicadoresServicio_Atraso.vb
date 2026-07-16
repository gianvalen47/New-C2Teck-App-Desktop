Imports System.ServiceModel
Imports System.Globalization

Public Class frmIndicadoresServicio_Atraso

    Private oJobService As New JobService.JobServiceClient

    'Private dtIndicadoresNivSer As DataTable
    'Private dtIndicadoresMO As DataTable
    Dim dtAtraso As DataTable
    Dim dtAtrasoFinal As DataTable
    Dim SumaTotalHora As Integer
    'Dim dtTableMO As DataTable
    Dim row As DataRow
    Dim col As DataColumn

    Private Sub frmIndicadoresServicio_Atraso_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
        End Try
    End Sub

    Private Sub frmIndicadoresServicio_Atraso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmIndicadoresServicio_Atraso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtFechaInicio.Value = CDate("01/01/" + utils.toBlank(Year(Today)))
        'txtFechaInicio.Value = CDate("01/" + utils.toBlank(Month(Today)) + )
        txtFechaFin.Value = Today()
        ChartTipo3.Visible = False
        Actualizar()
    End Sub

    Private Sub Actualizar()
        dtAtraso = oJobService.ReporteIndicadores(Session.sCodEmp, txtFechaInicio.Value, txtFechaFin.Value, 0, 0, "", 10, 0, 1).Tables(0)
        'DataGridView3.DataSource = dtAtraso
        'dtAtraso = oJobService.ReporteIndicadores(Session.sCodEmp, txtFechaInicio.Value, txtFechaFin.Value, 0, 0, "", 10, 0, 0).Tables(0)
        DataGridView1.DataSource = dtAtraso
        SumTotalHora()
        If SumaTotalHora > 0 Then
            ChartTipo3.Visible = True
            AgregarTotHorasPorc()
        Else
            ChartTipo3.Visible = False
        End If
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click

        dtAtraso = oJobService.ReporteIndicadores(Session.sCodEmp, txtFechaInicio.Value, txtFechaFin.Value, 0, 0, "", 10, 0, 1).Tables(0)
        DataGridView1.DataSource = dtAtraso
        SumTotalHora()
        If SumaTotalHora > 0 Then
            ChartTipo3.Visible = True
            AgregarTotHorasPorc()
        Else
            ChartTipo3.Visible = False
        End If
    End Sub


    Private Sub SumTotalHora()

        Try
            Dim total As Double = 0

            If DataGridView1.RowCount <> 0 Then
                For i As Integer = 0 To DataGridView1.RowCount - 1
                    If Not (IsDBNull(DataGridView1.Item("TotHoras".ToLower, i).Value)) Then
                        total = total + CDbl(DataGridView1.Item("TotHoras".ToLower, i).Value)
                    End If
                Next
                SumaTotalHora = total
            End If

        Catch ex As Exception
            MsgBox("ERROR AL SUMAR DATOS : " + ex.Message)
        End Try

    End Sub

    Private Sub AgregarTotHorasPorc()

        dtAtrasoFinal = dtAtraso.Copy
        dtAtrasoFinal.Clear()

        dtAtrasoFinal.Columns.Add(New DataColumn("TotHorasPorc", Type.GetType("System.String")))
        dtAtrasoFinal.Columns.Add(New DataColumn("TotHorasSinPorc", Type.GetType("System.String")))

        For i = 0 To dtAtraso.Rows.Count - 1
            row = dtAtrasoFinal.NewRow

            For j = 0 To dtAtrasoFinal.Columns.Count - 1

                If j = 4 Then

                    row(j) = CStr(Format(Math.Round((dtAtraso.Rows(i).Item(2) / SumaTotalHora) * 100, 2), "#0.##") & " %")
                    'row(j) = CStr(Math.Round(CInt((dtAtraso.Rows(i).Item(2) / SumaTotalHora) * 100), 2) & " %")
                    'row(j) = CStr(Format(CInt((dtAtraso.Rows(i).Item(2) / SumaTotalHora) * 100), "#.##") & " %")0
                ElseIf j = 5 Then
                    row(j) = (dtAtraso.Rows(i).Item(2) / SumaTotalHora) * 100
                    'row(j) = Format((dtAtraso.Rows(i).Item(2) / SumaTotalHora) * 100, "#.##")
                Else
                    row(j) = dtAtraso.Rows(i).Item(j)
                End If

            Next

            dtAtrasoFinal.Rows.Add(row)

        Next

        dgvDatosNivSer.DataSource = dtAtrasoFinal
        DataGridView2.DataSource = dtAtrasoFinal

        GraficoTipoAtraso()

    End Sub

    Private Sub GraficoTipoAtraso()

        Try
            ChartTipo3.Visible = True
            ChartTipo3.chartType = MSChart20Lib.VtChChartType.VtChChartType2dPie
            'ChartEstadistica.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).Labels(1).Format = "0"
            'ChartEstadistica.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).AxisTitle.Visible = False
            'ChartEstadistica.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdX).AxisTitle.Visible = False
            ChartTipo3.Footnote.Location.Visible = False
            ChartTipo3.Legend.Location.LocationType = MSChart20Lib.VtChLocationType.VtChLocationTypeRight
            'ChartEstadistica.Legend.Location.LocationType = MSChart20Lib.VtChLocationType.VtChLocationTypeTop
            ChartTipo3.Title.Text = "% HORAS TOTALES ADICIONALES"
            ChartTipo3.ColumnCount = DataGridView2.Rows.Count - 1

            ChartTipo3.Row = 1
            ChartTipo3.RowLabel = ""

            For i = 0 To DataGridView2.Rows.Count - 2
                ChartTipo3.Column = i + 1
                ChartTipo3.Data = DataGridView2.Rows(i).Cells("TotHorasSinPorc").Value()

                ChartTipo3.Plot.SeriesCollection(i + 1).LegendText = DataGridView2.Rows(i).Cells("DesAtraso").Value() & " (" & Math.Round(CInt(DataGridView2.Rows(i).Cells("TotHorasSinPorc").Value()), 2) & "%)"
                'ChartTipo3.Plot.SeriesCollection(i + 1).LegendText = DataGridView2.Rows(i).Cells("DesAtraso").Value() & " (" & Math.Round(DataGridView2.Rows(i).Cells("TotHorasSinPorc").Value(), 2) & "%)"
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

    Private Sub dgvDatosNivSer_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatosNivSer.ColumnButtonClick

        Try
            If dgvDatosNivSer.CurrentRow.Cells("IdAtraso").Value = 0 Then

            Else
                If e.Column.Key = "Grafica" Then
                    Dim frm As New frmIndicadoresServicio_Atraso_Detallado

                    frm.FecInicio = txtFechaInicio.Value
                    frm.FecFinal = txtFechaFin.Value
                    frm.IdAtrasoFinal = dgvDatosNivSer.CurrentRow.Cells("IdAtraso").Value

                    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Mostrar la gráfica" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

End Class