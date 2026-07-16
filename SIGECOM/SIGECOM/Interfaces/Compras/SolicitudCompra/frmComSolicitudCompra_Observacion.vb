Public Class frmComSolicitudCompra_Observacion

    Private Sub frmComSolicitudCompra_Observacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComSolicitudCompra_Observacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtOservacion.Focus()
    End Sub

    Private Sub biCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAceptar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK

    End Sub
End Class