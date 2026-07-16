Imports System.ServiceModel
Public Class frmHoraMotor_Act_Historial

    '===========================Servicios====================================================
    Private oHorasMotorService As New HorasMotorService.HorasMotorServiceClient

    '====================== Declaración de Variables =============================================
    Public codMer As String
    Public FecRegistro As Date
    Public TotalHoras As Double
    Public HorasParcial As Double
    Public IdHistorial As Integer

    Private Sub frmHoraMotor_Act_Historial_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtCodMer.Text = codMer
        txtFecRegistro.Value = FecRegistro
        txtHrsTotales.Value = TotalHoras
        txtHrsParciales.Value = HorasParcial
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Try

            Dim estado_process As Boolean
            estado_process = oHorasMotorService.ActualizarHistorial(IdHistorial, txtFecRegistro.Value, txtHrsTotales.Value, txtHrsParciales.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If estado_process Then
                MsgBox("Se actualizó el Historial de Horas de Motor")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If

        Catch ex As Exception
            MsgBox("Error al Actualizar Fecha de Registro : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oHorasMotorService.Close()
        Catch ex As TimeoutException
            oHorasMotorService.Abort()
        Catch ex As CommunicationException
           oHorasMotorService.Abort()
        End Try
    End Sub
End Class