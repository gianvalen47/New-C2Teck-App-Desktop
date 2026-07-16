Imports System.ServiceModel
Public Class frmSolicitudGarantia_ActualizarEstado

    '===========================Servicios====================================================
    Private oSolicitudGarantiaAtencionService As New SolicitudGarantiaAtencionService.SolicitudGarantiaAtencionServiceClient

    '======================Declaración de Variables==============================================
    Public IdAfa As Integer
    Public IdAfaDet As Integer

    Private Sub frmSolicitudGarantia_ActualizarEstado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudGarantiaAtencionService.Close()
        Catch ex As TimeoutException
            oSolicitudGarantiaAtencionService.Abort()
        Catch ex As CommunicationException
            oSolicitudGarantiaAtencionService.Abort()
        End Try
    End Sub

    Private Sub frmSolicitudGarantia_ActualizarEstado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmJob_ActualizarEstado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblIdAfa.Text = IdAfa
        txtObservacion.Focus()
    End Sub


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If txtObservacion.Text = "" Then
            MsgBox("Debe ingresar una observación, tenga cuidado", MsgBoxStyle.Information)
        Else
            If MsgBox("¿Está seguro de actualizar el estado de la ORDEN DE REPARACIÓN: " & IdAfa.ToString & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                ActualizarEstadoAfa()
            End If
        End If
    End Sub

    Private Sub ActualizarEstadoAfa()

        If oSolicitudGarantiaAtencionService.ActualizarEstadoInicial(IdAfaDet, IdAfa, 3, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp) Then
            MsgBox("Se actualizó el estado de ORDEN DE REPARACIÓN correctamente.", MsgBoxStyle.Information)
            'Limpiar()
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Else
            MsgBox("Error en el proceso, comunicarse con el área de TI")
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class