Imports System.Windows.Forms
Imports System.ServiceModel
Imports System.Globalization

Public Class frmIndicadoresServicio_Grafica22

    Private oJobService As New JobService.JobServiceClient

    Private dtReporte As New DataTable
    Private dtReporte2 As New DataTable
    Private dtReporteTipo61 As New DataTable
    Private dtReporteTipo62 As New DataTable
    Private dtReporteTipo81 As New DataTable
    Private dtReporteTipo82 As New DataTable
    Public IdProgramacion As Integer
    Public Fecha As Date
    Public FechaEscogida As Date

    Private Sub frmIndicadoresServicio_Grafica22_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
        End Try
    End Sub

    Private Sub frmIndicadoresServicio_Grafica22_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmIndicadoresServicio_Grafica22_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dtReporteTipo81 = oJobService.ReporteIndicadores(Session.sCodEmp, Fecha, Fecha, 0, 0, "", 8, IdProgramacion, 1).Tables(0)
            dgvTipo81.DataSource = dtReporteTipo81

            Dim estilo1 As New Estilo
            estilo1.cargaEstiloDataDrid(dgvTipo81)

            dtReporteTipo82 = oJobService.ReporteIndicadores(Session.sCodEmp, Fecha, Fecha, 0, 0, "", 8, IdProgramacion, 2).Tables(0)
            dgvTipo82.DataSource = dtReporteTipo82

            GraficoTipo7()

        Catch ex As Exception
            MsgBox("Error al Cargar el Formulario. " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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
                ChartTipo82.Data = 100 'dgvTipo82.Rows(0).Cells("Objetivo").Value()

            End If
        Catch ex As Exception
            MsgBox("Error al Mostrar la gráfica" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class