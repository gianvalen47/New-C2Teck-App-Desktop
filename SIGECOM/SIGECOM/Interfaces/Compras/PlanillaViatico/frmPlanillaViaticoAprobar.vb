
Imports System.ServiceModel

Public Class frmPlanillaViaticoAprobar

    '===========================Servicios====================================
    Private oPlanillaViaticoService As New PlanillaViaticoService.PlanillaViaticoServiceClient

    '======================Declaración de Variables==============================   
    Public IdPlanilla As Integer

    Private Sub frmPlanillaViaticoAprobar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmPlanillaViaticoAprobar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub frmPlanillaViaticoAprobar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Text = "Aprobar y/o Rechazar Planilla Viatico N°:" & IdPlanilla

    End Sub

    Private Sub btnAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAprobar.Click
        Try
            Dim estado_process As Boolean

            '======================================================APROBAR ==========================================
            If cbAprobar.Checked Then

                '=========================================== APROBACION JEFE DE AREA ===================================

                If MsgBox("¿Está seguro de APROBAR la Planilla de Viatico N°: " & IdPlanilla & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                    estado_process = oPlanillaViaticoService.Aprobar(IdPlanilla, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        MsgBox("Se Aprobó la Solicitud de Gastos correctamente")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If

                End If

                '======================================================RECHAZAR ==========================================
            ElseIf cbRechazar.Checked Then
                If MsgBox("¿Está seguro de RECHAZAR la Planilla de Viatico N°:" & IdPlanilla & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    If txtObservacion.Text = "" Then
                        MsgBox("Debe ingresar la observación")
                        txtObservacion.Focus()
                    Else
                        estado_process = oPlanillaViaticoService.Desaprobar(IdPlanilla, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        If estado_process Then
                            MsgBox("Se rechazó la Planilla correctamente ")
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al aprobar/desaprobar la solicitud de gastos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oPlanillaViaticoService.Close()
        Catch ex As TimeoutException
            oPlanillaViaticoService.Abort()
        Catch ex As CommunicationException
            oPlanillaViaticoService.Abort()
        End Try
    End Sub

    Private Sub cbAprobar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAprobar.CheckedChanged
        txtObservacion.Enabled = False
        If cbRechazar.Checked Then
            btnAprobar.Text = "Rechazar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Rechazar_1

        ElseIf cbAprobar.Checked Then
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar

        Else
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar

        End If
    End Sub

    Private Sub cbRechazar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbRechazar.CheckedChanged
        txtObservacion.Enabled = True
        If cbRechazar.Checked Then
            btnAprobar.Text = "Rechazar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Rechazar_1

        ElseIf cbAprobar.Checked Then
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar

        Else
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar

        End If
    End Sub
End Class