Public Class frmBuscarDetalle
    Public codigoDetalle As String

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If txtCodigo.Text <> "" Then
            codigoDetalle = txtCodigo.Text
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Else
            MsgBox("Debe Ingresar un código del detalle. ", MsgBoxStyle.Information, "Información")

        End If
    End Sub
    Private Sub frmDocumento_BuscarDetalle_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtCodigo.Select()
    End Sub
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                                    txtCodigo.KeyPress _
                                    , btnAceptar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub
    Private Sub frmDocumento_BuscarDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
            e.Handled = True
        End If
    End Sub
End Class