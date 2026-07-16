Imports System.ServiceModel

Public Class frmProgramacionJob_ActFecha

    Private oIndicadoresServicioService As New IndicadoresServicioService.IndicadoresServicioServiceClient

    Public IdProgramacionDet As Integer
    Public DesActividad As String

    Private Sub frmProgramacionJob_ActFecha_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oIndicadoresServicioService.Close()
        Catch ex As TimeoutException
            oIndicadoresServicioService.Abort()
        Catch ex As CommunicationException
            oIndicadoresServicioService.Abort()
        End Try
    End Sub

    Private Sub frmProgramacionJob_ActFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmProgramacionJob_ActFecha_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtActividad.Text = DesActividad

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Dim estado_process As Boolean
            estado_process = oIndicadoresServicioService.ActualizarFecha(IdProgramacionDet, txtFecInicio.Value, txtFecFin.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If estado_process Then
                MsgBox("Se Actualizo correctamente la fecha de inicio.")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error al Actualizar la fecha")
            End If
        Catch ex As Exception
            MsgBox("Error al Actualizar la fecha de inicio : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class