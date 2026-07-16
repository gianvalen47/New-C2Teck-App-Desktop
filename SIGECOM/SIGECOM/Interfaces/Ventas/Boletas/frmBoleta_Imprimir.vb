Public Class frmBoleta_Imprimir
    Public Imprimir As Boolean

    Private Sub frmBoleta_Imprimir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub rbButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDetalle.CheckedChanged, rbResumen.CheckedChanged
        If rbDetalle.Checked Then
            Imprimir = True 'Detallado
        ElseIf rbResumen.Checked Then
            Imprimir = False 'Resumido
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub
End Class