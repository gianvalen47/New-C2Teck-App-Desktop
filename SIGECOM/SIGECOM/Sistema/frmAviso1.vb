
Public Class frmAviso1
    Private Sub frmCentroCosto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            'Finalizar()
            Me.Close()
        End If
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        'Finalizar()
        Me.Close()
    End Sub
End Class