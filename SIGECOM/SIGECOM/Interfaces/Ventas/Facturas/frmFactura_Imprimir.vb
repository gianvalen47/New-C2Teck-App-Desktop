Public Class frmFactura_Imprimir
    Public Imprimir As Boolean
    Public state As Boolean
    Public Moneda As String
    Private Sub frmFactura_Imprimir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End If
    End Sub

    Private Sub frmFactura_Imprimir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cbMostrarNroCuenta.Checked = False
        rbSoles.Enabled = False
        rbDolares.Enabled = False
        rbSoles.Checked = False
        rbDolares.Checked = False

    End Sub

    Private Sub rbButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDetalle.CheckedChanged, rbResumen.CheckedChanged
        If rbDetalle.Checked Then
            Imprimir = True
        ElseIf rbResumen.Checked Then
            Imprimir = False
        End If
    End Sub

    
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If cbMostrarNroCuenta.Checked And rbSoles.Checked Then
            Moneda = "NS"
        ElseIf cbMostrarNroCuenta.Checked And rbDolares.Checked Then
            Moneda = "US"
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub cbMostrarNroCuenta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMostrarNroCuenta.CheckedChanged
        If cbMostrarNroCuenta.Checked Then
            rbDolares.Enabled = True
            rbSoles.Enabled = True
            rbSoles.Checked = True
        Else
            rbDolares.Enabled = False
            rbSoles.Enabled = False
        End If
    End Sub
End Class