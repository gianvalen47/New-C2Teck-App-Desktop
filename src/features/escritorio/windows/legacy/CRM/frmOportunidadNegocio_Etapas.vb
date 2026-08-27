Imports System.ServiceModel
Public Class frmOportunidadNegocio_Etapas
    '===========================Servicios====================================
    Private oOportunidadNegocioService As New OportunidadNegocioService.OportunidadNegocioServiceClient

    '======================Declaración de Variables==============================   
    Public IdOportunidad As Integer
    Private dtDatos As DataTable

    Private Sub frmOportunidadNegocio_Etapas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oOportunidadNegocioService.Close()
        Catch ex As TimeoutException
            oOportunidadNegocioService.Abort()
        Catch ex As CommunicationException
            oOportunidadNegocioService.Abort()
        End Try
    End Sub

    Private Sub frmOportunidadNegocio_Etapas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmOportunidadNegocio_Etapas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oOportunidadNegocioService.ConsultarEtapas(IdOportunidad).Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class