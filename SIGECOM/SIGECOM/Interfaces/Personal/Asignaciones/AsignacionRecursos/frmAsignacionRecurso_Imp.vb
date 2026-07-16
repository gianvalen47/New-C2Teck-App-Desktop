Imports System.ServiceModel
Public Class frmAsignacionRecurso_Imp

    '===========================Servicios====================================================    
    Private oRecursoService As New RecursoService.RecursoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    '======================Declaración de Variables==============================================
    Private dtDatos As DataTable
    Public IdRecurso As Integer

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmAsignacionRecurso_Imp_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oRecursoService) = False Then
                oRecursoService.Close()
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmAsignacionRecurso_Imp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rbEntrega.Checked = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If rbEntrega.Checked = True Then
                ImprimirReporte()
            ElseIf rbDevolucion.Checked Then
                ImprimirReporteDev()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub ImprimirReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptAsignacionRecurso
            If IdRecurso <> 0 Then
                dtReporte = oRecursoService.Imprimir(toNumber(IdRecurso)).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay datos a mostrar")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.Text = "Asignación de Recurso Nº" + IdRecurso.ToString
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.ShowDialog()
                End If
            Else
                MsgBox("!No hay Datos que mostrar, verifique...!", MsgBoxStyle.Information, "No hay datos")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub ImprimirReporteDev()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptAsignacionRecurso_Dev
            If IdRecurso <> 0 Then
                dtReporte = oRecursoService.Imprimir(toNumber(IdRecurso)).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay datos a mostrar")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.Text = "Devolución de Asignación de Recurso Nº" + IdRecurso.ToString
                    forma.ShowDialog()
                End If
            Else
                MsgBox("!No hay Datos que mostrar, verifique...!", MsgBoxStyle.Information, "No hay datos")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub frmAsignacionRecurso_Imp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oRecursoService.Close()
        Catch ex As TimeoutException
            oRecursoService.Abort()
        Catch ex As CommunicationException
            oRecursoService.Abort()
        End Try
    End Sub
End Class