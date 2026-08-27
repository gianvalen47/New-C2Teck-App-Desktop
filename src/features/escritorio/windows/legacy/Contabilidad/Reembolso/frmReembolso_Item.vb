Imports System.ServiceModel

Public Class frmReembolso_Item
    Private oReembolsoCajaDetService As New ReembolsoCajaDetService.ReembolsoCajaDetServiceClient

    Public IdReembolsoDet As Int64
    Public IdReembolso As Integer

    Private Sub Finalizar()
        Try
            oReembolsoCajaDetService.Close()

        Catch ex As TimeoutException
            oReembolsoCajaDetService.Abort()

        Catch ex As CommunicationException
            oReembolsoCajaDetService.Abort()

        End Try
    End Sub

    Private Sub frmReembolso_Item_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmReembolso_Item_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub


    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                txtItem.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub frmReembolso_Item_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtItem.Focus()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean = False
                estado_process = oReembolsoCajaDetService.RecalcularItem(IdReembolso, IdReembolsoDet, txtItem.Value)
                If estado_process Then
                    MsgBox("Se actualizo el item correctamente")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            End If

        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR ITEM : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub
End Class