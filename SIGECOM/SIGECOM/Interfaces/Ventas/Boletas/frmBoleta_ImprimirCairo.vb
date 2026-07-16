Public Class frmBoleta_ImprimirCairo

    Public Imprimir As Boolean
    Public Documento As String
    Public TipoDoc As String

    Private Sub frmBoleta_ImprimirCairo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Documento = txtDocumento.Text
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub rbDetallado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDetallado.CheckedChanged, rbResumen.CheckedChanged
        If rbDetallado.Checked Then
            Imprimir = False  'Imprimir detallado incluyendo el IGV total de la fila 
        ElseIf rbResumen.Checked Then
            Imprimir = True  'Imprimir resumido Precio de venta total 
        End If
    End Sub

    Private Sub frmBoleta_ImprimirCairo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDocumento.Text = "DNI :"
    End Sub
End Class