Imports System.ServiceModel
Public Class frmServicios_Cotizacion_ActFecEmision

    '===========================Servicios====================================
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient

    Public IdCotizacionSer As Integer
    Public NumCotizacion As String
    Public FechaEmision As Date

    Private Sub frmServicios_Cotizacion_ActFecEmision_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oCotizacionServicioService.Close()
        Catch ex As TimeoutException
            oCotizacionServicioService.Abort()
        Catch ex As CommunicationException
            oCotizacionServicioService.Abort()
        End Try
    End Sub

    Private Sub frmServicios_Cotizacion_ActFecEmision_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmServicios_Cotizacion_ActFecEmision_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblProvisional.Text = NumCotizacion
        Me.Text = "Actualizar Fecha Emision"

        txtFecDoc.Value = FechaEmision
        'txtFecDoc.Value = Today
        txtFecDoc.Focus()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Dim estado_process As Boolean

            estado_process = oCotizacionServicioService.ActualizarFechaEmision(IdCotizacionSer, txtFecDoc.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            If estado_process Then
                MsgBox("Se actualizo la fecha de emision correctamente ")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If

        Catch ex As Exception
            MsgBox("Error al Actualizar la fecha de emision : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class