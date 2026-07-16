Imports System.ServiceModel
Public Class frmComSolicitudGasto_MostrarPlanilla

    '===========================Servicios====================================
    Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient

    '======================Declaración de Variables==============================   
    Public IdGastoDet As Integer
    Private dtDatos As DataTable

    Private Sub frmComSolicitudGasto_MostrarPlanilla_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        ListaDatos()
        Me.Text = "Mostrar Planillas de Viático"
        dgvDatos.Select()
    End Sub

    Private Sub ListaDatos()
        Try
            dtDatos = oSolicitudGastoDetService.MostrarPlanillas(IdGastoDet).Tables(0)
            dgvDatos.DataSource = dtDatos

            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmComSolicitudGastoDet_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmComSolicitudGastoDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oSolicitudGastoDetService.Close()
        Catch ex As TimeoutException
            oSolicitudGastoDetService.Abort()
        Catch ex As CommunicationException
            oSolicitudGastoDetService.Abort()
        End Try
    End Sub
End Class