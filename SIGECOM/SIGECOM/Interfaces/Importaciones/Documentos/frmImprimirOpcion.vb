Public Class frmImprimirOpcion

    Public state_button As Boolean


    Private Sub frmImprimirOpcion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If rbMemActual.Checked Then
            state_button = True
            Me.DialogResult = System.Windows.Forms.DialogResult.OK

        ElseIf rbMemAntiguo.Checked Then
            state_button = False
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
End Class