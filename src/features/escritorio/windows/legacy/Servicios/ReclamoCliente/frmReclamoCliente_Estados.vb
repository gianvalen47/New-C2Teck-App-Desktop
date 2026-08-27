Imports System.ServiceModel
Public Class frmReclamoCliente_Estados
    '===========================Servicios====================================
    Private oReclamoClienteService As New ReclamoClienteService.ReclamoClienteServiceClient

    '======================Declaración de Variables==============================   
    Public IdReclamo As Integer
    Private dtDatos As DataTable

    Private Sub frmReclamoCliente_Estados_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oReclamoClienteService.Close()
        Catch ex As TimeoutException
            oReclamoClienteService.Abort()
        Catch ex As CommunicationException
            oReclamoClienteService.Abort()
        End Try
    End Sub

    Private Sub frmReclamoCliente_Estados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmReclamoCliente_Estados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left


        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oReclamoClienteService.ConsultarEstados(IdReclamo).Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class