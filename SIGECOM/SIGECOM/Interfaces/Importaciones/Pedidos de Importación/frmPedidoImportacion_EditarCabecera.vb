Imports System.Windows.Forms
Imports System.ServiceModel

Public Class frmPedidoImportacion_EditarCabecera

    'Private oPedidoImportService As New PedidoImportService.PedidoImportServiceClient
    'Private oPedidoImportDetService As New PedidoImportDetService.PedidoImportDetServiceClient

    Public NumPed As String
    Public ObservCab As String

    Private Sub frmPedidoImportacion_EditarCabecera_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If MsgBox("¿Desea Guardar la Observación?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
                btnGuardar_Click(sender, e)
            Else
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If
        End If
    End Sub

    Private Sub frmPedidoImportacion_EditarCabecera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'txtObsCab.Text = "A/To : STEVE REMMICK                                  Del/From    :   MORI VALDIZAN" & Environment.NewLine & _
        '                 "N°Fax : 52(55)2595-1639                               Referencia  :   " & NumPed & Environment.NewLine & _
        '                 "  " & Environment.NewLine & _
        '                 "PLEASE ENTER OUR ORDER   CROWN C36-12,  TO BE SHIPPED OPEN ACCOUNT, SURFACE TO :" & Environment.NewLine & _
        '                 "DETROIT DIESEL-MTU PERU S.A.C."

        txtObsCab.Text = ObservCab

        btnGuardar.Enabled = True

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()


        'If state_button Then
        'End If

    End Sub
End Class