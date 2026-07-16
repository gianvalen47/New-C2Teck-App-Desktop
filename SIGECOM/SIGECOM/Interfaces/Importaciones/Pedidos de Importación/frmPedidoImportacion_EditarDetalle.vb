Imports System.Windows.Forms

Public Class frmPedidoImportacion_EditarDetalle


    Public NumPed As String
    Public ObservDet As String

    Private Sub frmPedidoImportacion_EditarDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If MsgBox("¿Desea Guardar la Observación?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
                btnGuardar_Click(sender, e)
            Else
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If
        End If
    End Sub

    Private Sub frmPedidoImportacion_EditarDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'txtObsDet.Text = "REGARDS" & Environment.NewLine & _
        '                 "MORI VALDIZAN" & Environment.NewLine & _
        '                 "DETROIT DIESEL - MTU PERU S.A.C." & Environment.NewLine & _
        '                 "LIMA PERU"

        txtObsDet.Text = ObservDet

        btnGuardar.Enabled = True


    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class