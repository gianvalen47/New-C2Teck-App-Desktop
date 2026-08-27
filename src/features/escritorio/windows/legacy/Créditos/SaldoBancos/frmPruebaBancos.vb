Public Class frmPruebaBancos

    Private Sub frmPruebaBancos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Dim celda As New DataGridViewComboBoxCell()

        celda.Items.Add("Casa")
        celda.Items.Add("Perro")
        celda.Items.Add("Coche")

        'DataGridView1[1, 0] = celda

    End Sub
End Class