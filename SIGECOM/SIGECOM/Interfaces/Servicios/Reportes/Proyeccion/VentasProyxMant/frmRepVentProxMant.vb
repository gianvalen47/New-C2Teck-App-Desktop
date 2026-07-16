Imports System.ServiceModel

Public Class frmRepVentProxMant

    '=========================== Servicios ====================================
    Private oHorasMotorService As New HorasMotorService.HorasMotorServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtDatos As DataTable

    Private Sub frmRepVentProxMant_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oHorasMotorService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oHorasMotorService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oHorasMotorService.Abort()
            oSeguridadService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)

    End Sub

    Private Sub frmRepVentProxMant_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepVentProxMant_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cbFecInicio.Value = "01/01/" & Today.Year
        cbFecFinal.Value = "31/12/" & Today.Year

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(256, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        mostrarReporte()
    End Sub


    Private Sub mostrarReporte()

        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptVentProxMant

            dtReporte = oHorasMotorService.ReporteProyectarVentas(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("¡No hay Datos que mostrar, verifique.!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.DisplayGroupTree = False

                reporte.SetParameterValue("FecInicio", cbFecInicio.Text)
                reporte.SetParameterValue("FecFin", cbFecFinal.Text)

                forma.Text = "Reporte de Ventas Proyectadas por Mantenimiento"

                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class