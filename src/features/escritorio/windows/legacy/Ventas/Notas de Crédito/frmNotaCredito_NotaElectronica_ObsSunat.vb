Imports System.ServiceModel

Public Class frmNotaCredito_NotaElectronica_ObsSunat

    Private oNotaDigitalService As New NotaDigitalService.NotaDigitalServiceClient

    Public IdNota As Integer

    Private Sub frmNotaCredito_NotaElectronica_ObsSunat_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oNotaDigitalService.Close()
        Catch ex As TimeoutException
            oNotaDigitalService.Abort()
        Catch ex As CommunicationException
            oNotaDigitalService.Abort()
        End Try
    End Sub

    Private Sub frmNotaCredito_NotaElectronica_ObsSunat_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmNotaCredito_NotaElectronica_ObsSunat_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ObtenerRegistro()
    End Sub

    Private Sub ObtenerRegistro()

        Try

            Dim registro As NotaDigitalService.NotaDigital
            registro = oNotaDigitalService.Obtener(IdNota)

            txtTicket.Text = registro.NumTicket
            txtEstado.Text = registro.Estado
            txtObservacion.Text = registro.Observacion
            txtNotas.Text = registro.Notas

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub biSalir_Click(sender As System.Object, e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class