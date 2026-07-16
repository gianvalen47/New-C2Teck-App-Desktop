Imports System.ServiceModel

Public Class frmFactura_FacturacionElectronica_ObsSunat


    Private oFacturaDigitalService As New FacturaDigitalService.FacturaDigitalServiceClient

    Public IdFactura As Integer

    Private Sub frmFactura_FacturacionElectronica_ObsSunat_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oFacturaDigitalService.Close()
        Catch ex As TimeoutException
            oFacturaDigitalService.Abort()
        Catch ex As CommunicationException
            oFacturaDigitalService.Abort()
        End Try
    End Sub

    Private Sub frmFactura_FacturacionElectronica_ObsSunat_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmFactura_FacturacionElectronica_ObsSunat_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ObtenerRegistro()
    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As FacturaDigitalService.FacturaDigital
            registro = oFacturaDigitalService.Obtener(IdFactura)

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