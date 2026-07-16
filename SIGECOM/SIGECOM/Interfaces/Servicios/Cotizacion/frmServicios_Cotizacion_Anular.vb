Imports System.ServiceModel
Public Class frmServicios_Cotizacion_Anular

    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient

    Public NumCotizacion As String
    Public IdCotizacionSer As Integer

    Private Sub frmServicios_Cotizacion_Anular_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oCotizacionServicioService.Close()
        Catch ex As TimeoutException
            oCotizacionServicioService.Abort()
        Catch ex As CommunicationException
            oCotizacionServicioService.Abort()
        End Try
    End Sub

    Private Sub frmServicios_Cotizacion_Anular_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmServicios_Cotizacion_Anular_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblNumCotizacion.Text = "Cotización N° " & NumCotizacion
        txtObservacion.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try

            Dim estado_process As Boolean

            If MsgBox("¿Está seguro de ANULAR la cotización Nº " & NumCotizacion, MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If txtObservacion.Text = "" Then
                    MsgBox("Debe ingresar la observación")
                    txtObservacion.Focus()
                Else
                    estado_process = oCotizacionServicioService.Anular(IdCotizacionSer, utils.toNull(txtObservacion.Text), Session.sCodUsu, Session.sDirIp, Session.sNomPc)
                    If estado_process Then
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        MsgBox("Se anuló correctamente la cotizacion")
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class