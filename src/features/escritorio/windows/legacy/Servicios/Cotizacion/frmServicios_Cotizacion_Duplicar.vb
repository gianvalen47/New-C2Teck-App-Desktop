
Imports System.ServiceModel

Public Class frmServicios_Cotizacion_Duplicar

    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Public IdCotizacionSer As Integer
    Public NumCotizacion As String


    Private Sub frmServicios_Cotizacion_Duplicar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            oCotizacionServicioService.Close()

        Catch ex As TimeoutException
            oCotizacionServicioService.Abort()

        Catch ex As CommunicationException
            oCotizacionServicioService.Abort()

        End Try
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmServicios_Cotizacion_Revertir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmServicios_Cotizacion_Revertir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtFecha.Value = Today
        Me.Text = "Duplicar Cotización N°:" & NumCotizacion
    End Sub

    Private Sub btnDuplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDuplicar.Click
        Try
            If MsgBox("¿Esta seguro de DUPLICAR la Cotización N° " & NumCotizacion & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim estado_process As String = ""
                estado_process = oCotizacionServicioService.Duplicar(IdCotizacionSer, txtFecha.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process <> "" Then
                    MsgBox("Se generó la Cotización Nº " + estado_process + " correctamente.")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el Proceso, comunicarse con el área de TI!!!")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class