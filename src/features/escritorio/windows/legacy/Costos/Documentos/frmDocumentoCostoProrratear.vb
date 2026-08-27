Public Class frmDocumentoCostoProrratear
    Private ObjDocumento As New DocumentoCostoService.DocumentoCostoServiceClient
    Public IdMemo As Integer

    Private Sub frmDocumentoCostoProrratear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtCosDol.KeyPress _
            , txtCosSol.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmDocumentoCostoProrratear_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(ObjDocumento) = False Then
                ObjDocumento.Close()
            End If

        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmDocumentoCostoProrratear_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmDocumentoCostoProrratear_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCosDol.Select()

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If MsgBox("¿Desea Prorratear los costos ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Dim estado_process As Boolean
            estado_process = ObjDocumento.ProrratearMemos(IdMemo, txtCosDol.Text, txtCosSol.Text)
            If estado_process Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If
        Else

        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class