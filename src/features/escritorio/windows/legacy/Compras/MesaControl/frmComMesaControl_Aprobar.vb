Imports System.ServiceModel
Public Class frmComMesaControl_Aprobar

    '===========================Servicios====================================
    Private oMesaControlService As New MesaControlService.MesaControlServiceClient

    '======================Declaración de Variables==============================   
    Public IdMesa As Integer

    Private Sub frmComMesaControl_Aprobar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmComMesaControl_Aprobar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComMesaControl_Aprobar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Aprobar Mesa de Control N°:" & IdMesa
        'Activar()
    End Sub

    Private Sub btnAprobar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAprobar.Click
        Try
            Dim estado_process As Boolean
            If cbAprobar.Checked Then
                If MsgBox("¿Está seguro de APROBAR la Mesa deControl N°:" & IdMesa & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    estado_process = oMesaControlService.Aprobar(IdMesa, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    MsgBox("Se Aprobó la Mesa de Control correctamente ")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            ElseIf cbRechazar.Checked Then
                If MsgBox("¿Está seguro de RECHAZAR la Mesa de Control N°:" & IdMesa & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    If txtObservacion.Text = "" Then
                        MsgBox("Debe ingresar la Observación")
                        txtObservacion.Focus()
                    Else
                        estado_process = oMesaControlService.Rechazar(IdMesa, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        MsgBox("Se rechazó la Mesa de Control correctamente ")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL APROBAR/DESAPROBAR LA MESA DE CONTROL : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cbAprobar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAprobar.CheckedChanged
        Activar()
        If cbAprobar.Checked Then
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
        Else
            btnAprobar.Text = "Rechazar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
        End If
    End Sub

    Private Sub Activar()
        'If cbAprobar.Checked Then
        '    txtObservacion.ReadOnly = True
        '    txtObservacion.BackColor = System.Drawing.SystemColors.Control
        'Else
        '    txtObservacion.ReadOnly = False
        '    txtObservacion.BackColor = System.Drawing.SystemColors.Window
        '    txtObservacion.Focus()
        'End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oMesaControlService.Close()
        Catch ex As TimeoutException
            oMesaControlService.Abort()
        Catch ex As CommunicationException
            oMesaControlService.Abort()
        End Try
    End Sub

    Private Sub cbRechazar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbRechazar.CheckedChanged
        If cbRechazar.Checked Then
            btnAprobar.Text = "Rechazar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
        Else
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
        End If
    End Sub
End Class