Imports System.Windows.Forms
Imports System.ServiceModel
Imports System.Globalization

Public Class frmIndicadoresServicio_Grafica11

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
    Dim arrPrices(0 To 6)
    Dim i As Integer


    Private Sub frmIndicadoresServicio_Grafica_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
        End Try
    End Sub

    Private Sub frmIndicadoresServicio_Grafica_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmIndicadoresServicio_Grafica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            ChartGrafico.Enabled = False
            ChartGrafico5.Enabled = False
            ChartMotivo.Enabled = False
            '---------------------------

            dtReporteTipo4 = oJobService.ReporteIndicadores(Session.sCodEmp, Fecha, FechaEscogida, 0, 0, "", 4, IdProgramacion, 0).Tables(0)
            dgvTipo4.DataSource = dtReporteTipo4

            dtReporteTipo5 = oJobService.ReporteIndicadores(Session.sCodEmp, Fecha, FechaEscogida, 0, 0, "", 5, IdProgramacion, 0).Tables(0)
            dgvTipo5.DataSource = dtReporteTipo5

            GraficaTipo42()
            GraficoTipo5()

        Catch ex As Exception
            MsgBox("Error al Cargar el Formulario. " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    'Private Sub GraficaTipo4()
    '    Try
    '        ChartGrafico.Visible = True
    '        ChartGrafico.chartType = MSChart20Lib.VtChChartType.VtChChartType2dBar
    '        ChartGrafico.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).Labels(1).Format = "0"
    '        ChartGrafico.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).AxisTitle.Visible = False
    '        ChartGrafico.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdX).AxisTitle.Visible = False
    '        ChartGrafico.Footnote.Location.Visible = False
    '        ChartGrafico.Legend.Location.LocationType = MSChart20Lib.VtChLocationType.VtChLocationTypeTop
    '        'ChartGrafico.Title.Text = "GRAFICO TIPO 4"

    '        ChartGrafico.Column = 1
    '        ChartGrafico.Data = dgvTipo4.Rows(0).Cells("DiasEstandar").Value()
    '        ChartGrafico.Column = 2
    '        ChartGrafico.Data = dgvTipo4.Rows(0).Cells("DiasPromesa").Value()
    '        ChartGrafico.Column = 3
    '        ChartGrafico.Data = dgvTipo4.Rows(0).Cells("DiasProyectados").Value()

    '        ChartGrafico.Plot.SeriesCollection(1).LegendText = "DiasEstandar"
    '        ChartGrafico.Plot.SeriesCollection(2).LegendText = "DiasPromesa"
    '        ChartGrafico.Plot.SeriesCollection(3).LegendText = "DiasProyectados"
    '    Catch ex As Exception
    '        MsgBox("Error al Mostrar la gráfica" + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub GraficaTipo42()
        Try
            ChartMotivo.Visible = True
            ChartMotivo.chartType = MSChart20Lib.VtChChartType.VtChChartType2dBar

            For J = 0 To 1
                If J = 0 Then
                    ChartMotivo.Row = 1
                    ChartMotivo.RowLabel = ""
                    ChartMotivo.Column = 1
                    ChartMotivo.Data = dgvTipo4.Rows(J).Cells("DiasEstandar").Value()
                    ChartMotivo.Column = 2
                    ChartMotivo.Data = dgvTipo4.Rows(J).Cells("DiasPromesa").Value() - dgvTipo4.Rows(J).Cells("DiasEstandar").Value()
                    ChartMotivo.Column = 3
                    ChartMotivo.Data = 0
                End If
                If J = 1 Then
                    ChartMotivo.Row = 2
                    ChartMotivo.RowLabel = ""
                    ChartMotivo.Column = 1
                    ChartMotivo.Data = 0
                    ChartMotivo.Column = 2
                    ChartMotivo.Data = 0
                    ChartMotivo.Column = 3
                    ChartMotivo.Data = dgvTipo4.Rows(0).Cells("DiasProyectados").Value()
                End If
                lblNumJob.Text = "Job : " & dgvTipo4.Rows(0).Cells("CodJob").Value()
                lblUbiMantMot.Text = dgvTipo4.Rows(0).Cells("DesUbicacion").Value() & "-" & dgvTipo4.Rows(0).Cells("DesMantenimiento").Value() & "-" & dgvTipo4.Rows(0).Cells("TipMot").Value()
                'lblFechaCierre.Text = "Fecha del Cierre: " & dgvTipo4.Rows(0).Cells("FechaCierre").Value()
                lblDiasEstandar.Text = "Dias Estandar: " & CInt(dgvTipo4.Rows(0).Cells("DiasEstandar").Value())
                lblDiasPromesa.Text = "Dias Promesa: " & CInt(dgvTipo4.Rows(0).Cells("DiasPromesa").Value())
                lblDiasProyectados.Text = "Dias Proyectados: " & dgvTipo4.Rows(0).Cells("DiasProyectados").Value()

                ChartMotivo.Plot.SeriesCollection(1).LegendText = "DiasEstandar"
                ChartMotivo.Plot.SeriesCollection(2).LegendText = "DiasPromesa"
                ChartMotivo.Plot.SeriesCollection(3).LegendText = "DiasProyectados"

            Next

            'Para poner los valores en la columna
            'For iIndex = 1 To ChartMotivo.Plot.SeriesCollection.Count
            '    ChartMotivo.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.LocationType = MSChart20Lib.VtChLabelLocationType.VtChLabelLocationTypeBase
            '    'ChartGrafico.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.VtFont.Style = MSChart20Lib.VtFontStyle.VtFontStyleBold
            '    ChartMotivo.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.VtFont.VtColor.Set(245, 245, 220)
            '    ChartMotivo.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.VtFont.Size = 12
            'Next iIndex

        Catch ex As Exception
            MsgBox("Error al Mostrar la gráfica" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub GraficoTipo5()
        Try
            ChartGrafico5.Visible = True
            ChartGrafico5.chartType = MSChart20Lib.VtChChartType.VtChChartType2dBar
            ChartGrafico5.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).Labels(1).Format = "0"
            ChartGrafico5.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).AxisTitle.Visible = False
            ChartGrafico5.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdX).AxisTitle.Visible = False
            ChartGrafico5.Footnote.Location.Visible = False
            ChartGrafico5.Legend.Location.LocationType = MSChart20Lib.VtChLocationType.VtChLocationTypeRight
            'ChartGrafico5.Title.Text = "GRAFICO TIPO 5"

            ChartGrafico5.Column = 1
            ChartGrafico5.Data = dgvTipo5.Rows(0).Cells("AvanceReal").Value()
            ChartGrafico5.Column = 2
            ChartGrafico5.Data = dgvTipo5.Rows(0).Cells("AvanceEsperado").Value()
            'ChartGrafico.Column = 3
            'ChartGrafico.Data = dgvTipo1.Rows(0).Cells("DiasProyectados").Value()
            lblDiasPlaneados.Text = CInt(dgvTipo5.Rows(0).Cells("DiasPlaneados").Value)
            lblDiasEjecutados.Text = CInt(dgvTipo5.Rows(0).Cells("DiasEjecucion").Value)

            ChartGrafico5.Plot.SeriesCollection(1).LegendText = "AvanceReal"
            ChartGrafico5.Plot.SeriesCollection(2).LegendText = "AvanceEsperado"
            'ChartGrafico.Plot.SeriesCollection(3).LegendText = "DiasProyectados"

            For iIndex = 1 To ChartGrafico5.Plot.SeriesCollection.Count
                ChartGrafico5.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.LocationType = MSChart20Lib.VtChLabelLocationType.VtChLabelLocationTypeBase
                ChartGrafico5.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.VtFont.Style = MSChart20Lib.VtFontStyle.VtFontStyleBold
                'ChartGrafico5.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.VtFont.Style = MSChart20Lib.VtFontStyle.VtFontStyleItalic

                'ChartGrafico5.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.VtFont.VtColor.Set(0, 0, 0)
                ChartGrafico5.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.VtFont.VtColor.Set(245, 245S, 220)
                ChartGrafico5.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.VtFont.Size = 12
                'ChartGrafico5.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.VtFont.style
            Next iIndex

        Catch ex As Exception
            MsgBox("Error al Mostrar la gráfica" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Dim frm As New frmIndicadoresServicio_Grafica12
        'Dim fechaLunes As DateTime = GetFirstDayOfWeek(txtFecha.Value.Date)
        frm.Fecha = Fecha
        frm.FechaEscogida = FechaEscogida
        frm.IdProgramacion = IdProgramacion
        frm.NumJob = lblNumJob.Text
        'frm.ShowDialog()
        If frm.ShowDialog = System.Windows.Forms.DialogResult.Cancel Then
            'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            'Me.Close()
        End If

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class