Imports System.ServiceModel
Public Class frmJob_HabilitarMarcacion
    Private oJobService As New JobService.JobServiceClient

    Public CodJob As String

    Private Sub frmJob_HabilitarMarcacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
        Catch ex As TimeoutException
            oJobService.Close()
        Catch ex As CommunicationException
            oJobService.Close()
        End Try
    End Sub

    Private Sub frmJob_Regularizar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmJob_Regularizar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbActivar.Checked = True
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click      
        If oJobService.Estado(CodJob) = 6 Then
            If cbActivar.Checked = True Then
                If MsgBox("¿Estás Seguro de " & cbActivar.Text & " la OT " & Trim(CodJob) & " para Marcación?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    HabilitarMarcacion()
                End If
            ElseIf cbDesactivar.Checked = True Then
                If MsgBox("¿Estás Seguro de " & cbDesactivar.Text & " la OT " & Trim(CodJob) & " para Marcación?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    HabilitarMarcacion()
                End If
            End If
        Else
            MsgBox("Esta OT no puede ser Habilitado ya que no esta en Estado Ejecución")
        End If
    End Sub

    Private Sub HabilitarMarcacion()
        Try
            If cbActivar.Checked = True Then
                If oJobService.Marcable(CodJob) = False Then
                    Dim estado_process As Boolean
                    estado_process = oJobService.ActivarMarcacion(CodJob, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                    If estado_process Then
                        MsgBox("¡Se Activo la Marcación correctamente!")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()
                    Else
                        MsgBox("Error en el Proceso, Comuniquese con el área de TI")
                    End If
                Else
                    MsgBox("Esta OT ya esta Activado para Marcación,Tenga Cuidado")
                End If

            ElseIf cbDesactivar.Checked = True Then
                If oJobService.Marcable(CodJob) = True Then
                    Dim estado_process As Boolean
                    estado_process = oJobService.DesactivarMarcacion(CodJob, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                    If estado_process Then
                        MsgBox("¡Se Desactivo la Marcación correctamente!")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()
                    Else
                        MsgBox("Error en el Proceso, Comuniquese con el área de TI")
                    End If
                Else
                    MsgBox("Esta OT ya esta Desactivado para Marcación, Tenga Cuidado")
                End If
            End If

        Catch ex As Exception
            MsgBox("ERROR AL ACTIVAR MARCACIÓN : " + ex.Message)
        End Try
    End Sub
End Class