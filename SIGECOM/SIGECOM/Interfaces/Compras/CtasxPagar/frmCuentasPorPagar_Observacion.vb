Public Class frmCuentasPorPagar_Observacion

    Private Sub frmCuentasPorPagar_Observacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmCuentasPorPagar_Observacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtObservacion.Focus()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub
End Class