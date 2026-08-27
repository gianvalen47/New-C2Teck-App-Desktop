Public Class frmProgramacionJob_Imprimir

    Private oIndicadoresServicioService As New IndicadoresServicioService.IndicadoresServicioServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Public IdProgramacion As Integer

    Private Sub frmProgramacionJob_Imprimir_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        rbProgramacionSeleccionada.Checked = True
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        txtFecha.Enabled = False
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Try

            If rbProgramacionSeleccionada.Checked Then

                Dim forma As New frmReportes
                Dim dtReporte As New DataTable
                Dim reporte As New rptProgramacionJob

                dtReporte = oIndicadoresServicioService.ImprimirProgramacion(IdProgramacion).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay datos a mostrar")
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
                    forma.Text = "Reporte de Programacion OT"
                    forma.ShowDialog()
                End If

            ElseIf rbMostrarMarcacionesPendientes.Checked Then

                Dim forma As New frmReportes
                Dim dtReporte As New DataTable
                Dim reporte As New rptProgramacionJobMarPendientes

                dtReporte = oIndicadoresServicioService.ReporteMarcacionPendiente().Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay datos a mostrar")
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
                    forma.Text = "Reporte de Programacion OT"
                    forma.ShowDialog()
                End If

            ElseIf rbActividadesRealizar.Checked Then
                Dim forma As New frmReportes
                Dim dtReporte As New DataTable
                Dim reporte As New rptProgramacionJobActRealizar

                dtReporte = oIndicadoresServicioService.ReporteActividadesPorRealizar(IdProgramacion, txtFecha.Value).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay datos a mostrar")
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
                    forma.Text = "Reporte de Programacion OT Actividades a Realizar"
                    reporte.SetParameterValue("pFecha", txtFecha.Value)
                    forma.ShowDialog()
                End If
            End If

        Catch ex As Exception
            MsgBox("Error al Imprimir : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub rbProgramacionSeleccionada_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbProgramacionSeleccionada.CheckedChanged, rbMostrarMarcacionesPendientes.CheckedChanged, rbActividadesRealizar.CheckedChanged
        If rbActividadesRealizar.Checked = True Then
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            txtFecha.Enabled = True
        Else
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            txtFecha.Enabled = False
        End If
    End Sub
End Class