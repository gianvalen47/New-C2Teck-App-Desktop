Imports System.ServiceModel

Public Class frmComSolicitudGasto_Rechazar

    '===========================Servicios====================================
    Private oSolicitudGastoService As New SolicitudGastoService.SolicitudGastoServiceClient

    '======================Declaración de Variables==============================   
    Public IdGasto As Integer
    'Public IdEstado As Integer

    Private Sub frmComSolicitudGasto_Rechazar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmComSolicitudGasto_Rechazar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComSolicitudGasto_Rechazar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Rechazar Solicitud de Gastos N°:" & IdGasto
        txtObservacion.Focus()
    End Sub

    Private Sub Finalizar()
        Try
            oSolicitudGastoService.Close()
        Catch ex As TimeoutException
            oSolicitudGastoService.Abort()
        Catch ex As CommunicationException
            oSolicitudGastoService.Abort()
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnRechazar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRechazar.Click
        Try
            Dim estado_process As Boolean
            If MsgBox("¿Está seguro de RECHAZAR la solicitud de Gastos N°: " & IdGasto & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If txtObservacion.Text = "" Then
                    MsgBox("Debe ingresar la observación")
                    txtObservacion.Focus()
                Else
                    estado_process = oSolicitudGastoService.Rechazar(IdGasto, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        MsgBox("Se rechazó la solicitud correctamente ")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al rechazar la solicitud de gastos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class