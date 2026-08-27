
Imports System.ServiceModel
Public Class frmEncuestaSistema_Activar

    '===========================Servicios====================================================
    Private oEncuestaSistema As New EncuestaService.EncuestaServiceClient

    Public IdEncuesta As Integer

    Private Sub frmEncuestaSistema_Activar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oEncuestaSistema.Close()
        Catch ex As TimeoutException
            oEncuestaSistema.Abort()
        Catch ex As CommunicationException
            oEncuestaSistema.Abort()
        End Try
    End Sub

    Private Sub frmEncuestaSistema_Activar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmEncuestaSistema_Activar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        cbActivar.Checked = True
        btnAceptar.Text = "Activar"

    End Sub

    Private Sub cbActivar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbActivar.CheckedChanged
        If cbDesactivar.Checked Then
            btnAceptar.Text = "Desactivar"
            btnAceptar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
        ElseIf cbActivar.Checked Then
            btnAceptar.Text = "Activar"
            btnAceptar.Image = SIGECOM.My.Resources.Resources.Aceptar
        End If
    End Sub

    Private Sub cbDesactivar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDesactivar.CheckedChanged
        If cbDesactivar.Checked Then
            btnAceptar.Text = "Desactivar"
            btnAceptar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
        ElseIf cbActivar.Checked Then
            btnAceptar.Text = "Activar"
            btnAceptar.Image = SIGECOM.My.Resources.Resources.Aceptar
        End If
    End Sub



    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Try
            Dim estado_process As Boolean
            '=====================================================ACTIVAR ===========================================
            If cbActivar.Checked Then

                If MsgBox("¿Está seguro de ACTIVAR la encuesta?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    estado_process = oEncuestaSistema.Activar(IdEncuesta, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        MsgBox("Se activo la encuesta correctamente ")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If
                End If

                '======================================================RECHAZAR ==========================================
            ElseIf cbDesactivar.Checked Then
                If MsgBox("¿Está seguro de DESACTIVAR la encuesta?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                    estado_process = oEncuestaSistema.Desactivar(IdEncuesta, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        MsgBox("Se desactivo la encuesta correctamente ")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox("Error al aprobar/desaprobar la solicitud de gastos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
End Class