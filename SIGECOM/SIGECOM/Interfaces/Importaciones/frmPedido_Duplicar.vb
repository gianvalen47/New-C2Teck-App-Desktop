Imports System.ServiceModel
Public Class frmPedido_Duplicar
    Private oPedidoService As New PedidoService.PedidoServiceClient
    '======================Declaración de Variables==============================   
    Public IdPedido As Integer

    Private Sub frmSolicitudGarantia_Duplicar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmSolicitudGarantia_Duplicar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmSolicitudGarantia_Duplicar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtFecha.Focus()
        Me.Text = "Duplicar Pedido Interno N°:" & IdPedido
    End Sub

    Private Sub btnDuplicar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDuplicar.Click
        Try
            Dim estado_process As Integer
            If MsgBox("¿Está seguro de duplicar el Pedido Interno N°: " & IdPedido & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                estado_process = oPedidoService.Duplicar(IdPedido, txtFecha.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process > 0 Then
                    MsgBox("Se generó el Pedido Interno Nº " + estado_process.ToString + "correctamente.")
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el Proceso, comunicarse con el área de sistemas!!!")
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Duplicar Pedido Interno: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oPedidoService.Close()
        Catch ex As TimeoutException
            oPedidoService.Abort()
        Catch ex As CommunicationException
            oPedidoService.Abort()
        End Try
    End Sub
End Class