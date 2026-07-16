Imports System.ServiceModel
Public Class frmComMesaControl_Estados

    '===========================Servicios====================================
    Private oMesaControlService As New MesaControlService.MesaControlServiceClient

    '======================Declaración de Variables==============================   
    Public IdMesa As Integer
    Private dtDatos As DataTable

    Private Sub frmComMesaControl_Estados_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMesaControlService.Close()
        Catch ex As TimeoutException
            oMesaControlService.Abort()
        Catch ex As CommunicationException
            oMesaControlService.Abort()
        End Try
    End Sub

    Private Sub frmComMesaControl_Estados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComMesaControl_Estados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oMesaControlService.ConsultarEstados(IdMesa).Tables(0)
            dgvDatos.DataSource = dtDatos            
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class