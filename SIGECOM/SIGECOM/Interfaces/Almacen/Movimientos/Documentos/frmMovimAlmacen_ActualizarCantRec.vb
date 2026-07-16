Imports System.ServiceModel
Public Class frmMovimAlmacen_ActualizarCantRec

    Private oMoviAlmacenDetService As New MoviAlmacenDetService.MoviAlmacenDetServiceClient

    Public IdMovimientoDet As Integer
    Public CanRec As Integer
    Public ObservacionDet As String

    Private Sub frmMovimAlmacen_ActualizarCantRec_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMoviAlmacenDetService.Close()
        Catch ex As TimeoutException
            oMoviAlmacenDetService.Abort()
        Catch ex As CommunicationException
            oMoviAlmacenDetService.Abort()
        End Try
    End Sub

    Private Sub frmMovimAlmacen_ActualizarCantRec_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmMovimAlmacen_ActualizarCantRec_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtCanMer.Value = CanRec
        txtObservacion.Text = ObservacionDet

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try

            oMoviAlmacenDetService.ChequearCantidad(IdMovimientoDet, txtCanMer.Value, txtObservacion.Text)

            MsgBox("Se actualizo la cantidad recibida correctamente", MsgBoxStyle.Information)

            Me.DialogResult = System.Windows.Forms.DialogResult.OK

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL ORDEN DE COMPRA : " + ex.Message)
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class