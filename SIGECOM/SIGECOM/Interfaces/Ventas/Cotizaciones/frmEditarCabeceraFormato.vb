Imports System.Windows.Forms

Public Class frmEditarCabeceraFormato

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Private oCotizacionService As New CotizacionService.CotizacionServiceClient

    Public IdCotizacion As Integer
    Public estado As String

    Private Sub frmEditarCabeceraFormato_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oCotizacionService) = False Then
                oCotizacionService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmEditarCabeceraFormato_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If MsgBox("¿Desea Guardar la Observación?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
                btnGuardar_Click(sender, e)
            Else
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If
        End If
    End Sub

    Private Sub frmEditarCabeceraFormato_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If toNull(estado) <> Nothing And (estado <> "GENERADO" And estado <> "APROBADO" And estado <> "CREDITOS") Then
            btnGuardar.Enabled = False
        Else
            btnGuardar.Enabled = True
            txtObsCab.Select()
        End If
        'txtObsCab.Font.Name. = "Arial"
        'txtObsCab.Font.Size = 10
        'txtObsCab.SelectionFont.Name = "Arial"
        'txtObsCab.SelectionFont.Size = 10
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If state_button Then
            'oCotizacionService.ActualizarCabecera(IdCotizacion, txtObsCab.Rtf)
            oCotizacionService.ActualizarCabecera(IdCotizacion, toNull(txtObsCab.Rtf))
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnColorFuente_Click(sender As System.Object, e As System.EventArgs) Handles biColorFuente.Click
        ColorDialog1.ShowDialog()

        txtObsCab.SelectionColor = ColorDialog1.Color
    End Sub



    Private Sub biVinetas_Click(sender As System.Object, e As System.EventArgs) Handles biVinetas.Click

        txtObsCab.SelectionBullet = True

    End Sub

    Private Sub biFuente_Click(sender As System.Object, e As System.EventArgs) Handles biFuente.Click

        FontDialog1.ShowDialog()

        txtObsCab.SelectionFont = FontDialog1.Font

    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biNegrita_Click(sender As System.Object, e As System.EventArgs) Handles biNegrita.Click



    End Sub

    Private Sub biSubrayado_Click(sender As System.Object, e As System.EventArgs) Handles biSubrayado.Click

    End Sub

    Private Sub txtObsCab_SelectionChanged(sender As Object, e As System.EventArgs) Handles txtObsCab.SelectionChanged
        If txtObsCab.SelectionBullet Then
            cbVineta.Checked = True
        Else
            cbVineta.Checked = False
        End If

    End Sub


    Private Sub cbVineta_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbVineta.CheckedChanged

        If cbVineta.Checked Then

            txtObsCab.SelectionBullet = True
        Else
            txtObsCab.SelectionBullet = False
        End If

    End Sub
End Class