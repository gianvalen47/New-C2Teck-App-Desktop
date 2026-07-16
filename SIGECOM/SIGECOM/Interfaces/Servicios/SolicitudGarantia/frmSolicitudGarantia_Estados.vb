Imports System.ServiceModel
Public Class frmSolicitudGarantia_Estados

    '===========================Servicios====================================
    Private oSolicitudGarantiaService As New SolicitudGarantiaService.SolicitudGarantiaServiceClient

    '======================Declaración de Variables==============================   
    Public IdAfa As Integer
    Private dtDatos As DataTable

    Private Sub frmSolicitudGarantia_Estados_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudGarantiaService.Close()
        Catch ex As TimeoutException
            oSolicitudGarantiaService.Abort()
        Catch ex As CommunicationException
            oSolicitudGarantiaService.Abort()
        End Try
    End Sub

    Private Sub frmSolicitudGarantia_Estados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmSolicitudGarantia_Estados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oSolicitudGarantiaService.ConsultarEstados(IdAfa).Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class