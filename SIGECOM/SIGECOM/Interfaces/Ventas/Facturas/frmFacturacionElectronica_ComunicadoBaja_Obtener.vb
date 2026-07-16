Imports System.ServiceModel

Public Class frmFacturacionElectronica_ComunicadoBaja_Obtener

    Private oComunicacionBajaDigitalService As New ComunicacionBajaDigitalService.ComunicacionBajaDigitalServiceClient

    Public IdComunicacion As String

    Private Sub frmFacturacionElectronica_ComunicadoBaja_Obtener_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oComunicacionBajaDigitalService.Close()
        Catch ex As TimeoutException
            oComunicacionBajaDigitalService.Abort()
        Catch ex As CommunicationException
            oComunicacionBajaDigitalService.Abort()
        End Try
    End Sub

    Private Sub frmFacturacionElectronica_ComunicadoBaja_Obtener_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmFacturacionElectronica_ComunicadoBaja_Obtener_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ObtenerComunicadoBaja()
    End Sub

    Private Sub ObtenerComunicadoBaja()
        Try

            Dim registro As ComunicacionBajaDigitalService.ComunicacionBajaDigital
            registro = oComunicacionBajaDigitalService.Obtener(Session.sCodEmp, IdComunicacion)

            txtIdComunicacion.Text = registro.IdComunicacion
            cbFecha.Value = registro.Fecha
            txtNombrexml.Text = registro.NombreXml
            txtSerie.Text = registro.SerieDocumento.CodSerie
            txtNumDoc.Text = registro.NumDoc
            txtMotivo.Text = registro.Motivo
            txtNumTicket.Text = registro.NumTicket
            txtEstado.Text = registro.Estado
            txtObservacion.Text = registro.Observacion

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub biSalir_Click(sender As System.Object, e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class