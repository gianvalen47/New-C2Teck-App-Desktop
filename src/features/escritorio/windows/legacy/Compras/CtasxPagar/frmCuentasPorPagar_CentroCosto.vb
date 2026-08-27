
Imports System.ServiceModel
Public Class frmCuentasPorPagar_CentroCosto

    '============================Servicios===================================
    Private oCtasPorPagarService As New CtasPorPagarService.CtasPorPagarServiceClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient

    '======================Declaración de Variables==============================
    Public IdCuenta As Integer
    Public CodCentro As String

    Private Sub frmCuentasPorPagar_CentroCosto_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmCuentasPorPagar_CentroCosto_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmCuentasPorPagar_CentroCosto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Desactivar()
        ObtenerRegistro()
        txtUnidad.Focus()
    End Sub
    Private Sub Finalizar()
        Try
            oCtasPorPagarService.Close()
            oCentroCostoService.Close()
        Catch ex As TimeoutException
            oCtasPorPagarService.Abort()
            oCentroCostoService.Abort()
        Catch ex As CommunicationException
            oCtasPorPagarService.Abort()
            oCentroCostoService.Abort()
        End Try
    End Sub

    Private Sub Desactivar()
        Try

            txtUnidad.ReadOnly = True
            txtUnidad.BackColor = System.Drawing.SystemColors.Control
            txtArea.ReadOnly = True
            txtArea.BackColor = System.Drawing.SystemColors.Control
            txtCentroCosto.ReadOnly = True
            txtCentroCosto.BackColor = System.Drawing.SystemColors.Control
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
            Dim registro As CtasPorPagarService.CtasPorPagarCentroCosto
            registro = oCtasPorPagarService.ObtenerCentroCosto(IdCuenta, CodCentro)

            IdCuenta = registro.CtasPorPagar.IdCuenta
            CodCentro = registro.CentroCosto.CodCentro
            txtUnidad.Text = registro.CentroCosto.Area.UnidadNegocio.DesUnidad
            txtArea.Text = registro.CentroCosto.Area.DesArea
            txtCentroCosto.Text = registro.CentroCosto.DesCentro
            txtMontoTotal.Value = registro.Monto
            txtObservacion.Text = registro.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


End Class