Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmReportes

    Private Sub frmReportes_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub

    Private Sub frmReporteImportacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crvReportes.ToolPanelView = False

    End Sub


End Class