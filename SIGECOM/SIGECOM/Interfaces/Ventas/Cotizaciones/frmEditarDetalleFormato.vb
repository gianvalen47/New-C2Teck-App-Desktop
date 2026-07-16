Imports System.Windows.Forms

Public Class frmEditarDetalleFormato

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Private oCotizacionService As New CotizacionService.CotizacionServiceClient

    Public IdCotizacion As Integer
    Public estado As String

    Private Sub frmEditarDetalleFormato_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oCotizacionService) = False Then
                oCotizacionService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmEditarDetalleFormato_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If MsgBox("¿Desea Guardar la Observación?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
                btnGuardar_Click(sender, e)
            Else
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If
        End If
    End Sub

    Private Sub frmEditarDetalleFormato_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If toNull(estado) <> Nothing And estado <> "GENERADO" And estado <> "APROBADO" And estado <> "CREDITOS" Then
            btnGuardar.Enabled = False
        Else
            btnGuardar.Enabled = True
            txtObsDet.Select()
        End If
    End Sub

    Private Sub biColorFuente_Click(sender As System.Object, e As System.EventArgs) Handles biColorFuente.Click
        ColorDialog1.ShowDialog()
        txtObsDet.SelectionColor = ColorDialog1.Color
    End Sub

    Private Sub biFuente_Click(sender As System.Object, e As System.EventArgs) Handles biFuente.Click
        FontDialog1.ShowDialog()
        txtObsDet.SelectionFont = FontDialog1.Font
    End Sub

    Private Sub cbVineta_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbVineta.CheckedChanged
        If cbVineta.Checked Then
            txtObsDet.SelectionBullet = True
        Else
            txtObsDet.SelectionBullet = False
        End If
    End Sub

    Private Sub txtObsDet_SelectionChanged(sender As Object, e As System.EventArgs) Handles txtObsDet.SelectionChanged
        If txtObsDet.SelectionBullet Then
            cbVineta.Checked = True
        Else
            cbVineta.Checked = False
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If state_button Then
            oCotizacionService.ActualizarDetalle(IdCotizacion, toNull(txtObsDet.Text))
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub
End Class