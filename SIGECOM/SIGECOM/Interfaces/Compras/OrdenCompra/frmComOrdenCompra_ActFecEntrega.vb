Imports System.ServiceModel

Public Class frmComOrdenCompra_ActFecEntrega

    '===========================Servicios====================================
    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient

    Public IdOrden As Integer

    Private Sub frmComOrdenCompra_ActFecEntrega_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oOrdenesCompraService.Close()
        Catch ex As TimeoutException
            oOrdenesCompraService.Abort()
        Catch ex As CommunicationException
            oOrdenesCompraService.Abort()
        End Try
    End Sub

    Private Sub frmComOrdenCompra_ActFecEntrega_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComOrdenCompra_ActFecEntrega_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblOrdenCompra.Text = IdOrden
        Me.Text = "Actualizar Fecha Entrega"
        txtFecDoc.Value = Today
        txtFecDoc.Focus()
    End Sub


    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim estado_process As Boolean

            estado_process = oOrdenesCompraService.ActualizarFecEntrega(IdOrden, txtFecDoc.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            If estado_process Then
                MsgBox("Se actualizo la fecha de entrega correctamente ")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If

        Catch ex As Exception
            MsgBox("Error al Actualizar la fecha de entrega : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class