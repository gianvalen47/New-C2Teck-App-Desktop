Public Class frmComSolicituCompra_Generar

    Private Sub frmComSolicituCompra_Generar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End If
    End Sub

    Private Sub frmComSolicituCompra_Generar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        txtNumOrden.KeyPress _
        , txCodProveedor.KeyPress _
        , cbFecha.KeyPress _
        , cmbCodPago.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub frmComSolicituCompra_Generar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Generar Orden de Compra"

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If MsgBox("¿Estás Seguro de GENERAR la orden de compra?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Me.DialogResult = Windows.Forms.DialogResult.OK

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class