Public Class frmVehiculo_Observ

    Public Observacion As String

    Private Sub frmVehiculo_Observ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmVehiculo_Observ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtObservacion.Text = Observacion
        Label1.Select()

    End Sub

End Class