Imports System.ServiceModel
Public Class frmGuiaRemision_Electronica_ObsSunat

    Private oGuiaRemisionDigitalService As New GuiaRemisionDigitalService.GuiaRemisionDigitalServiceClient

    Public IdGuia As Integer

    Private Sub frmGuiaRemision_Electronica_ObsSunat_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oGuiaRemisionDigitalService.Close()
        Catch ex As TimeoutException
            oGuiaRemisionDigitalService.Abort()
        Catch ex As CommunicationException
            oGuiaRemisionDigitalService.Abort()
        End Try
    End Sub

    Private Sub frmGuiaRemision_Electronica_ObsSunat_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmGuiaRemision_Electronica_ObsSunat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObtenerRegistro()
    End Sub

    Private Sub ObtenerRegistro()
        Try

            Dim registro As GuiaRemisionDigitalService.GuiaRemisionDigital
            registro = oGuiaRemisionDigitalService.Obtener(IdGuia)

            txtTicket.Text = registro.NumTicket
            txtEstado.Text = registro.Estado
            txtObservacion.Text = registro.Observacion
            txtNotas.Text = registro.Notas
            txtUrlLink.Text = registro.UrlLink

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class