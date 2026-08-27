Imports System.ServiceModel
Public Class frmGastoViaje_Estados

    '===========================Servicios====================================
    Private oPreGastoRealService As New PreGastoRealService.PreGastoRealServiceClient

    '======================Declaración de Variables==============================   
    Public IdPreGastoReal As Integer
    Private dtDatos As DataTable

    Private Sub frmComSolicitudGasto_Estados_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPreGastoRealService.Close()
        Catch ex As TimeoutException
            oPreGastoRealService.Abort()
        Catch ex As CommunicationException
            oPreGastoRealService.Abort()
        End Try
    End Sub

    Private Sub frmComSolicitudGasto_Estados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComSolicitudGasto_Estados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oPreGastoRealService.ConsultarEstados(IdPreGastoReal).Tables(0)         
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class