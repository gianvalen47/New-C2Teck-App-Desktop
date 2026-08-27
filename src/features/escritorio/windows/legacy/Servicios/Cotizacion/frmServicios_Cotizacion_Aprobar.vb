Imports System.ServiceModel

Public Class frmServicios_Cotizacion_Aprobar

    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private dtMedioAprobacion As DataTable
    Public NumCotizacion As String
    Public IdCotizacionSer As Integer

    Private Sub frmCotizacion_Aprobar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oCotizacionServicioService.Close()
        Catch ex As TimeoutException
            oCotizacionServicioService.Abort()
        Catch ex As CommunicationException
            oCotizacionServicioService.Abort()
        End Try
    End Sub

    Private Sub frmCotizacion_Aprobar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmCotizacion_Aprobar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblNumCotizacion.Text = "Cotización N° " & NumCotizacion
        rbAprobar.Checked = True
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            'If Session.CodPerfil = "01" Or Session.CodPerfil = "24" Then

            Dim estado_process As Boolean

                If rbAprobar.Checked = True Then
                    If MsgBox("¿Está seguro de APROBAR la cotización Nº " & NumCotizacion & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                        estado_process = oCotizacionServicioService.AprobarServicio(IdCotizacionSer, Session.sCodUsu, Session.sDirIp, Session.sNomPc)
                        If estado_process Then
                            MsgBox("Se aprobó la cotización correctamente ")
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                    End If
                    End If

                ElseIf rbDesaprobar.Checked = True Then
                    If MsgBox("¿Está seguro de DESAPROBAR la cotización Nº " & NumCotizacion, MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                        If txtObservacion.Text = "" Then
                            MsgBox("Debe ingresar la observación")
                            txtObservacion.Focus()
                        Else
                            estado_process = oCotizacionServicioService.RechazarServicio(IdCotizacionSer, utils.toNull(txtObservacion.Text), Session.sCodUsu, Session.sDirIp, Session.sNomPc)
                            If estado_process Then
                                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                                MsgBox("Se desaprobó correctamente la cotizacion")
                            Else
                            MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                        End If
                        End If
                    End If
                End If
            'Else
            '    MsgBox("No tiene el perfil para aprobar la cotización")
            'End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub rbAprobar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAprobar.CheckedChanged
        If rbAprobar.Checked Then
            btnAceptar.Text = "Aprobar"
            btnAceptar.Image = SIGECOM.My.Resources.Resources.Aceptar
            btnAceptar.Size = New Size(71, 23)
        ElseIf rbDesaprobar.Checked Then
            btnAceptar.Text = "Desaprobar"
            btnAceptar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
            btnAceptar.Size = New Size(88, 23)
        End If
    End Sub

    Private Sub rbDesaprobar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDesaprobar.CheckedChanged
        If rbDesaprobar.Checked Then
            btnAceptar.Text = "Desaprobar"
            btnAceptar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
            btnAceptar.Size = New Size(88, 23)
        ElseIf rbAprobar.Checked Then
            btnAceptar.Text = "Aprobar"
            btnAceptar.Image = SIGECOM.My.Resources.Resources.Aceptar
            btnAceptar.Size = New Size(71, 23)
        End If
    End Sub
End Class