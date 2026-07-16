Imports System.ServiceModel
Public Class frmDocumento_VerEstados

    '===========================Servicios====================================
    Private oFacturaImportService As New FacturaImportService.FacturaImportServiceClient

    '======================Declaración de Variables==============================   
    Public IdFactura As Integer
    Private dtDatos As DataTable

    Private Sub frmDocumento_VerEstados_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oFacturaImportService.Close()
        Catch ex As TimeoutException
            oFacturaImportService.Abort()
        Catch ex As CommunicationException
            oFacturaImportService.Abort()
        End Try
    End Sub

    Private Sub frmDocumento_VerEstados_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmDocumento_VerEstados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left


        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oFacturaImportService.ConsultarEstados(IdFactura).Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class