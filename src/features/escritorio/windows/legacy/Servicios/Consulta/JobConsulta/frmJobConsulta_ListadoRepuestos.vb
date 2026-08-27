Imports System.ServiceModel

Public Class frmJobConsulta_ListadoRepuestos

    Public CodJob As String
    Public DesCli As String
    Public ModMer As String

    Private dtDatos As DataTable
    Private dtCotizacion As DataTable

    Private oJobService As New JobService.JobServiceClient
    Private oJobRepuestoService As New JobRepuestoService.JobRepuestoServiceClient
    Private oMercaderiaService As New MercaderiaService.MercaderiaServiceClient

    Private Sub frmJobConsulta_ListadoRepuestos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
            oJobRepuestoService.Close()
            oMercaderiaService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
            oJobRepuestoService.Abort()
            oMercaderiaService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
            oJobRepuestoService.Abort()
            oMercaderiaService.Abort()
        End Try
    End Sub

    Private Sub frmJobConsulta_ListadoRepuestos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmJobConsulta_ListadoRepuestos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        lblNumJob.Text = CodJob
        lblCliente.Text = DesCli
        lblMotor.Text = ModMer
       
        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oJobService.MostrarRepuestos(CodJob).Tables(0)
            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS : " + ex.Message)
        End Try
    End Sub

End Class