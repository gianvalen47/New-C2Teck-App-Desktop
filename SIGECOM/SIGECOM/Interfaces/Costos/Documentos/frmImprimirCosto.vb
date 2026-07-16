Public Class frmImprimirCosto

    Public Imprimir As Integer


    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try

        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.OK

    End Sub

    Private Sub rbtCostos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtCostos.CheckedChanged, rbtnOriginal.CheckedChanged
        If rbtCostos.Checked Then
            Imprimir = 2
        ElseIf rbtnOriginal.Checked Then
            Imprimir = 1
        End If
    End Sub

    Private Sub frmImprimirCosto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmImprimirCosto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class