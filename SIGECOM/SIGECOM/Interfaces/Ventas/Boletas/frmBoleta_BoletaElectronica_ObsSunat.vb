Imports System.ServiceModel

Public Class frmBoleta_BoletaElectronica_ObsSunat

    Private oBoletaDigitalService As New BoletaDigitalService.BoletaDigitalServiceClient

    Public IdBoleta As Integer

    Private Sub frmBoleta_BoletaElectronica_ObsSunat_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oBoletaDigitalService.Close()
        Catch ex As TimeoutException
            oBoletaDigitalService.Abort()
        Catch ex As CommunicationException
            oBoletaDigitalService.Abort()
        End Try
    End Sub

    Private Sub frmBoleta_BoletaElectronica_ObsSunat_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmBoleta_BoletaElectronica_ObsSunat_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ObtenerRegistro()
    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As BoletaDigitalService.BoletaDigital
            registro = oBoletaDigitalService.Obtener(IdBoleta)

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