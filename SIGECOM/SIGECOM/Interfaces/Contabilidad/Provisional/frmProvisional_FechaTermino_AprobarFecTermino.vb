Imports System.ServiceModel

Public Class frmProvisional_FechaTermino_AprobarFecTermino

    '===========================Servicios====================================
    Private oProvisionalService As New ProvisionalService.ProvisionalServiceClient

    Public IdProvisional As Integer
    Public IdFechas As Integer
    'Public state_button As Boolean
    'Public type_process As String

    Private Sub frmProvisional_FechaTermino_AprobarFecTermino_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oProvisionalService.Close()
        Catch ex As TimeoutException
            oProvisionalService.Abort()
        Catch ex As CommunicationException
            oProvisionalService.Abort()
        End Try
    End Sub

    Private Sub frmProvisional_FechaTermino_AprobarFecTermino_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmProvisional_FechaTermino_AprobarFecTermino_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btnAprobar.Focus()

        ObtenerDatosFecTermino()

    End Sub

    Private Sub ObtenerDatosFecTermino()

        Try

            Dim registro As ProvisionalService.ProvisionalExtensionFechas
            registro = oProvisionalService.ObtenerEnviadoExtensionFecha(IdProvisional)

            IdProvisional = registro.Provisional.IdProvisional
            IdFechas = registro.IdFechas
            txtFecDoc.Value = registro.FecFinal
            txtObservacionDatos.Text = registro.Observacion

        Catch ex As Exception
            MsgBox("Error al obtener la extensión de fecha termino: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub cbAprobar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAprobar.CheckedChanged
        If cbRechazar.Checked Then
            btnAprobar.Text = "Rechazar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
            txtObservacion.Focus()
        ElseIf cbAprobar.Checked Then
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            btnAprobar.Focus()
        Else
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            btnAprobar.Focus()
        End If
    End Sub

    Private Sub cbRechazar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbRechazar.CheckedChanged
        If cbRechazar.Checked Then
            btnAprobar.Text = "Rechazar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
            txtObservacion.Focus()
        ElseIf cbAprobar.Checked Then
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            btnAprobar.Focus()
        Else
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            btnAprobar.Focus()
        End If
    End Sub

    Private Sub btnAprobar_Click(sender As Object, e As EventArgs) Handles btnAprobar.Click

        Try
            Dim estado_process As Boolean
            '=====================================================APROBAR ===========================================
            If cbAprobar.Checked Then

                If MsgBox("¿Está seguro de APROBAR la Extensión de Fecha Termino del Provisional N°: " & IdProvisional & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                    estado_process = oProvisionalService.AprobarExtensionFecha(IdFechas, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                    If estado_process = True Then
                        MsgBox("Se Aprobó la extensión de fecha termino del provisional correctamente")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If
                End If
                '======================================================RECHAZAR ==========================================
            ElseIf cbRechazar.Checked Then
                If MsgBox("¿Está seguro de RECHAZAR la Extensión de Fecha Termino del Provisional N°: " & IdProvisional & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    If txtObservacion.Text = "" Then
                        MsgBox("Debe ingresar la observación")
                        txtObservacion.Focus()
                    Else
                        estado_process = oProvisionalService.RechazarExtensionFecha(IdFechas, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        If estado_process Then
                            MsgBox("Se Rechazó la extensión de fecha termino del provisional correctamente")
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox("Error al aprobar/desaprobar la extensión de fecha termino del provisional : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Close()
    End Sub
End Class