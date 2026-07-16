Public Class frmCotizacion_Recalcular

    Private oCotizacionService As New CotizacionService.CotizacionServiceClient
    Public IdCotizacion As Integer

    Private Sub frmCotizacion_Recalcular_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oCotizacionService) = False Then
                oCotizacionService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmCotizacion_Recalcular_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtDescuento.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmCotizacion_Recalcular_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmCotizacion_Recalcular_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDescuento.Select()
    End Sub

    Private Sub btnRecalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecalcular.Click
        If MsgBox("¿Está seguro de RECALCULAR el descuento... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Dim estado_process As Boolean
            estado_process = oCotizacionService.RecalcularDescuento(IdCotizacion, txtDescuento.Text, Session.sCodUsu)
            If estado_process Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class