Imports System.ServiceModel

Public Class frmIndicadoresServicio_Atraso_Detallado

    Private oJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Public FecInicio As Date
    Public FecFinal As Date
    Private dtReporte As New DataView
    Public IdAtrasoFinal As Integer
    Public NumJob As String

    Private Sub frmIndicadoresServicio_Atraso_Detallado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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

    Private Sub frmIndicadoresServicio_Atraso_Detallado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmIndicadoresServicio_Atraso_Detallado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ListarDatos()
    End Sub

    Private Sub ListarDatos()

        'dtReporte = oJobService.ReporteIndicadores(Session.sCodEmp, Date.Today, Date.Today, 0, 0, "", 9, IdProgramacion, 0).Tables(0)
        dtReporte = oJobService.ReporteIndicadores(Session.sCodEmp, FecInicio, FecFinal, 0, 0, "", 10, 0, 2).Tables(0).DefaultView

        dtReporte.RowFilter = "IdAtraso = " & IdAtrasoFinal & ""

        'If IdAtrasoFinal = 2 Then
        '    dtReporte.RowFilter = ""
        'ElseIf rbsinceros.Checked Then
        '    dtReporte.RowFilter = "Stock <> 0"
        'ElseIf rbceros.Checked Then
        '    dtReporte.RowFilter = "Stock = 0"
        'ElseIf rbpositivos.Checked Then
        '    dtReporte.RowFilter = "Stock > 0"
        'ElseIf rbnegativos.Checked Then
        '    dtReporte.RowFilter = "Stock < 0"
        'ElseIf rbbajominimo.Checked Then
        '    dtReporte.RowFilter = "Stock < MinMer"
        'ElseIf rbbajomaximo.Checked Then
        '    dtReporte.RowFilter = "Stock < MaxMer"
        'ElseIf rbSobFal.Checked Then
        '    'dtReporte.RowFilter = ""
        'End If

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
            Dim dtReporte As New DataView
            Dim reporte As New rptTabServAtrasoTotal

            dtReporte = oJobService.ReporteIndicadores(Session.sCodEmp, FecInicio, FecFinal, 0, 0, "", 10, 0, 2).Tables(0).DefaultView

            dtReporte.RowFilter = "IdAtraso = " & IdAtrasoFinal & ""
            'DataGridView1.DataSource = dtReporte

            If dtReporte.Count = 0 Then
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