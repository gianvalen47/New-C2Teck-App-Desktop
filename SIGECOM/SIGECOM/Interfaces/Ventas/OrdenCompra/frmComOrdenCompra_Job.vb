Imports System.ServiceModel
Public Class frmComOrdenCompra_Job

    '============================Servicios===================================
    Private oOrdenesCompraDetService As New OrdenesCompraDetService.OrdenesCompraDetServiceClient

    '======================Declaración de Variables==============================
    Public IdOrdenDoc As Integer
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
            oOrdenesCompraDetService.Close()
        Catch ex As TimeoutException
            oOrdenesCompraDetService.Abort()
        Catch ex As CommunicationException
            oOrdenesCompraDetService.Abort()
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
            txtMontoNoAfecto.ReadOnly = True
            txtMontoNoAfecto.BackColor = System.Drawing.SystemColors.Control
            txtMontoTotal.ReadOnly = True
            txtMontoTotal.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control

        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As OrdenesCompraDetService.FacturaOrdenJob
            registro = oOrdenesCompraDetService.ObtenerJob(IdOrdenDoc, CodJob)

            IdOrdenDoc = registro.FacturaOrdenesCompra.IdOrdenDoc
            CodJob = registro.Job.CodJob
            txtNumJob.Text = registro.Job.CodJob
            txtMonto.Value = registro.Monto
            txtMontoNoAfecto.Value = registro.MontoNoAfecto
            txtMontoTotal.Value = registro.Monto + registro.MontoNoAfecto
            txtObservacion.Text = registro.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class