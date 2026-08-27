Imports System.ServiceModel

Public Class frmSolicitudJob_Rechazar

    Private oSolicitudJobService As New SolicitudJobService.SolicitudJobServiceClient

    Public IdSolicitud As Long

    Private Sub frmSolicitudJob_Rechazar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudJobService.Close()
        Catch ex As TimeoutException
            oSolicitudJobService.Abort()
        Catch ex As CommunicationException
            oSolicitudJobService.Abort()
        End Try
    End Sub

    Private Sub frmSolicitudJob_Rechazar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmSolicitudJob_Rechazar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtObservacion.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Guardar()
    End Sub

    Private Sub Guardar()
        Try
            If validarcampo() Then

                'Dim registro As New SolicitudJobService.SolicitudJobServiceClient

                Dim estado_process As Boolean

                estado_process = oSolicitudJobService.Rechazar(IdSolicitud, utils.toNull(txtObservacion.Text), Session.sCodUsu, Session.sDirIp, Session.sNomPc)

                If estado_process Then
                    MsgBox("Se rechazó la Solicitud correctamente")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el Proceso, Comuniquese con el área de TI")
                End If

            End If


        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Function validarcampo() As Boolean
        If txtObservacion.Text = "" Then
            MsgBox("Debe Ingresar la Observación ")
            txtObservacion.Focus()
            Return False
        Else
            Return True
        End If
    End Function

End Class