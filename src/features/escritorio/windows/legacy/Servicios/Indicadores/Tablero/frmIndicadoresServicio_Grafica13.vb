Imports System.Windows.Forms
Imports System.ServiceModel
Imports System.Globalization

Public Class frmIndicadoresServicio_Grafica13

    Private oJobService As New JobService.JobServiceClient

    Private dtReporte As New DataTable
    Private dtReporte2 As New DataTable
    Private dtReporteTipo4 As New DataTable
    Private dtReporteTipo61 As New DataTable
    Private dtReporteTipo62 As New DataTable
    Private dtReporteTipo71 As New DataTable
    Private dtReporteTipo72 As New DataTable
    Public IdProgramacion As Integer
    Public Fecha As Date
    Public NumJob As String
    Public FechaEscogida As Date

    Private Sub frmIndicadoresServicio_Grafica13_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
        End Try
    End Sub

    Private Sub frmIndicadoresServicio_Grafica13_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmIndicadoresServicio_Grafica13_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            lblNumJob.Text = NumJob

            chartTipo7.Enabled = False

            dtReporteTipo61 = oJobService.ReporteIndicadores(Session.sCodEmp, Fecha, FechaEscogida, 0, 0, "", 6, IdProgramacion, 1).Tables(0)
            dgvTipo6.DataSource = dtReporteTipo61

            Dim estilo1 As New Estilo
            estilo1.cargaEstiloDataDrid(dgvTipo6)

            dtReporteTipo62 = oJobService.ReporteIndicadores(Session.sCodEmp, Fecha, FechaEscogida, 0, 0, "", 6, IdProgramacion, 2).Tables(0)
            dgvTipo7.DataSource = dtReporteTipo62

            GraficoTipo6()

        Catch ex As Exception
            MsgBox("Error al Cargar el Formulario. " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    'Private Sub GraficoTipo4()

    '    lblNumJob.Text = "Job : " & dgvTipo4.Rows(0).Cells("CodJob").Value()
    '    lblUbiMantMot.Text = dgvTipo4.Rows(0).Cells("DesUbicacion").Value() & "-" & dgvTipo4.Rows(0).Cells("DesMantenimiento").Value() & "-" & dgvTipo4.Rows(0).Cells("TipMot").Value()

    'End Sub

    Private Sub GraficoTipo6()

        Try
            If dtReporteTipo62.Rows.Count = 0 Then
                chartTipo7.Visible = False
            Else
                chartTipo7.Visible = True
                chartTipo7.chartType = MSChart20Lib.VtChChartType.VtChChartType2dLine

                chartTipo7.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).Labels(1).Format = "0"

                chartTipo7.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY2).Labels(1).Format = "0"

                chartTipo7.RowCount = dgvTipo7.RowCount - 1
                chartTipo7.ColumnCount = 4
                'If iTipo = "Diaria" Then
                chartTipo7.Title.Text = "INDICADOR OBJETIVO - PROYECCIÓN"

                chartTipo7.Plot.SeriesCollection(1).LegendText = "CumplimientoDiario"
                chartTipo7.Plot.SeriesCollection(2).LegendText = "Objetivo"
                chartTipo7.Plot.SeriesCollection(3).LegendText = "PB"
                chartTipo7.Plot.SeriesCollection(4).LegendText = "Proyeccion"


                'dgvTabla.DataSource = dtTabla

                For i = 0 To dgvTipo7.Rows.Count - 2

                    'If iTipo = "Diaria" Then
                    chartTipo7.Row = i + 1
                    chartTipo7.RowLabel = Mid((dgvTipo7.Rows(i).Cells("Fecha").Value), 9, 2)

                    'If dgvTipo7.Rows(i).Cells("CumplimientoDiario").Value = 0 Then
                    'Else
                    '    chartTipo7.Column = 1
                    '    chartTipo7.Data = dgvTipo7.Rows(i).Cells("CumplimientoDiario").Value()
                    'End If

                    chartTipo7.Column = 1
                    chartTipo7.Data = dgvTipo7.Rows(i).Cells("CumplimientoDiario").Value()

                    chartTipo7.Column = 2
                    chartTipo7.Data = dgvTipo7.Rows(i).Cells("Objetivo").Value()

                    chartTipo7.Column = 3
                    chartTipo7.Data = dgvTipo7.Rows(i).Cells("PB").Value()

                    chartTipo7.Column = 4
                    chartTipo7.Data = dgvTipo7.Rows(i).Cells("Proyeccion").Value()
                Next
            End If


            'For iIndex = 1 To chartTipo7.Plot.SeriesCollection.Count
            '    chartTipo7.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.LocationType = MSChart20Lib.VtChLabelLocationType.VtChLabelLocationTypeBase
            '    'ChartGrafico.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.VtFont.Style = MSChart20Lib.VtFontStyle.VtFontStyleBold
            '    chartTipo7.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.VtFont.VtColor.Set(245, 245, 220)
            '    chartTipo7.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.VtFont.Size = 14
            'Next iIndex

        Catch ex As Exception
            MsgBox("Error al Mostrar la gráfica" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    'Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
    '    Dim frm As New frmIndicadoresServicio_Grafica14
    '    'Dim fechaLunes As DateTime = GetFirstDayOfWeek(txtFecha.Value.Date)
    '    frm.Fecha = Fecha
    '    frm.FechaEscogida = FechaEscogida
    '    frm.IdProgramacion = IdProgramacion

    '    If frm.ShowDialog = System.Windows.Forms.DialogResult.Cancel Then
    '        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    '        Me.Close()
    '    End If

    'End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class