Imports System.ServiceModel

Public Class frmComOrdenCompra_AsignaraGastoManual


    '===========================Servicios====================================
    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient

    Public IdOrden As Integer


    Private Sub frmComOrdenCompra_AsignaraGastoManual_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oOrdenesCompraService.Close()
        Catch ex As TimeoutException
            oOrdenesCompraService.Abort()
        Catch ex As CommunicationException
            oOrdenesCompraService.Abort()
        End Try
    End Sub

    Private Sub frmComOrdenCompra_AsignaraGastoManual_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComOrdenCompra_AsignaraGastoManual_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblOrdenCompra.Text = IdOrden
        Me.Text = "Asignar a gasto manualmente"
        txtObservacion.Focus()


    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim estado_process As Boolean

            estado_process = oOrdenesCompraService.AsignarGastoManual(IdOrden, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            If estado_process Then
                MsgBox("Se asino al gasto correctamente ")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If

        Catch ex As Exception
            MsgBox("Error al Asignar el gasto : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class