

Public Class frmReclamoCliente_Imprimir

    Public nofirma As String

    Private Sub frmReclamoCliente_Imprimir_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub frmReclamoCliente_Imprimir_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmReclamoCliente_Imprimir_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Dim check As Boolean
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        check = cbNoIncluyeFirma.Checked
        If check = True Then
            nofirma = "true"
        Else
            nofirma = "false"
        End If


    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel

    End Sub
End Class