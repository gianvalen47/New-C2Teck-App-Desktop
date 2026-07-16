Imports System.ServiceModel

Public Class frmIndicadoresServicio_Grafica14

    Private oJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Public Fecha As Date
    Public FechaEscogida As Date
    Private dtReporte As New DataTable
    Public IdProgramacion As Integer
    Public NumJob As String

    Private Sub frmIndicadoresServicio_Grafica14_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmIndicadoresServicio_Grafica14_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmIndicadoresServicio_Grafica14_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lblNumJob.Text = NumJob
        ListarDatos()
    End Sub

    Private Sub ListarDatos()

        dtReporte = oJobService.ReporteIndicadores(Session.sCodEmp, Date.Today, Date.Today, 0, 0, "", 9, IdProgramacion, 0).Tables(0)
        dgvAtraso.DataSource = dtReporte

        Dim estilo1 As New Estilo
        estilo1.cargaEstiloDataDrid(dgvAtraso)

    End Sub

    Private Sub btnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Me.Close()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptTabServAtraso

            dtReporte = oJobService.ReporteIndicadores(Session.sCodEmp, Fecha, FechaEscogida, 0, 0, "", 9, IdProgramacion, 0).Tables(0)
            'DataGridView1.DataSource = dtReporte

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else

                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                forma.crvReportes.DisplayGroupTree = False
                forma.Text = "Reporte de Atraso por Job"

                'reporte.SetParameterValue("Reporte", "Reporte de Atraso")

                forma.ShowDialog()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub
End Class