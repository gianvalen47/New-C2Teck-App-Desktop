Imports System.ServiceModel

Public Class frmOrdenCompra_ActualizarOrden

    Private oOrdenCompraService As New OrdenCompraService.OrdenCompraServiceClient


    Public IdOrden As Integer
    Public NumOrden As String

    Private Sub frmOrdenCompra_ActualizarOrden_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oOrdenCompraService.Close()

        Catch ex As TimeoutException
            oOrdenCompraService.Abort()

        Catch ex As CommunicationException
            oOrdenCompraService.Abort()

        End Try
    End Sub

    Private Sub frmOrdenCompra_ActualizarOrden_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmOrdenCompra_ActualizarOrden_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtNumOrden.Text = NumOrden

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Try
            If MsgBox("¿Está seguro de Actualizar la Orden de Compra?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then

                Dim estado_process As Boolean
                estado_process = oOrdenCompraService.ActualizarNumeroOrden(IdOrden, txtNumOrden.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process Then
                    MsgBox("Se actualizo la orden de compra correctamente ", MsgBoxStyle.Exclamation)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el proceso, comunicarse con el administrador de TI")

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtNumOrden.Text) = "" Then
                MsgBox("Debe ingresar la orden de compra", MsgBoxStyle.Information)
                txtNumOrden.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

End Class