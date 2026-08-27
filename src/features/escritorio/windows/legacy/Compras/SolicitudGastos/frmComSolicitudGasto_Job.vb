Imports System.ServiceModel
Public Class frmComSolicitudGasto_Job

    '============================Servicios===================================
    Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient

    '======================Declaración de Variables==============================
    Public IdGastoDet As Integer
    Public CodJob As String

    Private Sub frmComSolicitudGasto_Job_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        llenarCombos()
        Desactivar()
        ObtenerRegistro()
        txtNumJob.Focus()
    End Sub

    Private Sub frmComSolicitudGasto_Job_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmComSolicitudGasto_Job_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
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

    Private Sub llenarCombos()
        Try

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Desactivar()
        Try

            txtNumJob.ReadOnly = True
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            txtMonto.ReadOnly = True
            txtMonto.BackColor = System.Drawing.SystemColors.Control
            txtMontoSinIgv.ReadOnly = True
            txtMontoSinIgv.BackColor = System.Drawing.SystemColors.Control
            txtMontoNoAfecto.ReadOnly = True
            txtMontoNoAfecto.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control

        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As SolicitudGastoDetService.SolicitudGastoDetJob
            registro = oSolicitudGastoDetService.ObtenerJob(IdGastoDet, CodJob)

            IdGastoDet = registro.SolicitudGastoDet.IdGastoDet
            CodJob = registro.Job.CodJob
            txtNumJob.Text = registro.Job.CodJob
            txtMonto.Value = registro.Monto
            txtMontoSinIgv.Value = registro.MontoSinIgv
            txtMontoNoAfecto.Value = registro.MontoNoAfecto
            txtObservacion.Text = registro.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class