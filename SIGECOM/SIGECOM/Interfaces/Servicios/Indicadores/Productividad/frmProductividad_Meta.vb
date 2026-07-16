Imports System.Windows.Forms
Imports System.ServiceModel
Imports AxMSChart20Lib
Public Class frmProductividad_Meta


    '===========================Servicios====================================================
    Private oJobService As New JobService.JobServiceClient

    '======================Declaración de Variables==============================================
    Private dtDatos As DataTable
    Public Fecha As Date


    Private Sub frmProductividad_Meta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ChartMotivo.Visible = True
        ChartMotivo.Enabled = False
        MostrarGrafico()
    End Sub

    Private Sub MostrarGrafico()
        Try
            dtDatos = oJobService.ReporteIndicadores(Session.sCodEmp, Fecha, Fecha, 0, 0, "", 11, 0, 1).Tables(0)
            dgvDatos.DataSource = dtDatos

            If dtDatos.Rows.Count = 0 Then
                ChartMotivo.Visible = False
            Else
                '-----------------------------------------------------Formato de Gráfico---------------------------------------------------------
                ChartMotivo.Visible = True
                ChartMotivo.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).AxisTitle.Visible = False
                ChartMotivo.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdX).AxisTitle.Visible = True
                ChartMotivo.Footnote.Location.Visible = False
                ChartMotivo.Legend.Location.LocationType = MSChart20Lib.VtChLocationType.VtChLocationTypeTop
                ChartMotivo.Title.Text = "% Productividad vs Meta"
                '------------------------------------------------------------------------------------------------------------------------------------------

                '----------------------------------------------------------------------Filas y Columnas del Gráfico--------------------------------------------------------------
                ChartMotivo.ColumnCount = 2    'Productividad y Meta
                ChartMotivo.RowCount = dgvDatos.ColumnCount - 1     'Se resta la columna (Nombre) para tener la cantidad de meses

                Dim cont As Integer = 1
                'For I = 0 To ChartMotivo.ColumnCount - 1
                ChartMotivo.Plot.SeriesCollection(1).LegendText = "%Productividad"
                ChartMotivo.Plot.SeriesCollection(2).LegendText = "Meta"
                'cont = cont + 1
                'Next
                '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                '---------------------------------------------------------------------------------------Datos de Gráfico---------------------------------------------------------------------------
                cont = 0
                For J = 0 To dgvDatos.ColumnCount - 2
                    cont = cont + 1
                    If cont > 0 Then
                        ChartMotivo.Row = cont
                        ChartMotivo.RowLabel = dgvDatos.Columns(cont).HeaderText
                        For I = 0 To dgvDatos.Rows.Count - 8
                            ChartMotivo.Column = I + 1
                            ChartMotivo.Data = IIf(dgvDatos(cont, I + 2).Value Is Nothing Or dgvDatos(cont, I + 2).Value.ToString = "" Or IsDBNull(dgvDatos(cont, I + 2).Value), 0, dgvDatos(cont, I + 2).Value)
                        Next
                    End If
                Next
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            End If
        Catch ex As Exception
            MsgBox("Error al Cargar Gráfico: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '==============================Evento KeyDown==============================================
    Private Sub frmAsignacionesRecursos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmAsignacionesRecursos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
        End Try
    End Sub
End Class