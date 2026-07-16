Imports System.ServiceModel
Public Class frmReclamoCliente_Rechazar

    '===========================Servicios====================================
    Private oReclamoClienteService As New ReclamoClienteService.ReclamoClienteServiceClient

    '======================Declaración de Variables==============================   
    Public IdReclamo As Integer

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmReclamoCliente_Rechazar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmReclamoCliente_Rechazar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmReclamoCliente_Rechazar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtObservacion.Focus()
        Me.Text = "Aprobar / Rechazar Reclamo de Cliente N°:" & IdReclamo.ToString
    End Sub

    Private Sub btnAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAprobar.Click
        Try
            Dim estado_process As Boolean
            If cbAprobar.Checked = True Then

                If MsgBox("¿Estás seguro de aprobar el Reclamo de Cliente N°:" & IdReclamo.ToString & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    If txtObservacion.Text = "" Then
                        MsgBox("Debe ingresar la Observación")
                        txtObservacion.Focus()
                    Else
                        estado_process = oReclamoClienteService.Aprobar(IdReclamo, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        MsgBox("Se aprobó el Reclamo de Cliente correctamente ")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If
                End If

            ElseIf cbRechazar.Checked = True Then

                If MsgBox("¿Estás seguro de rechazar el Reclamo de Cliente N°:" & IdReclamo.ToString & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    If txtObservacion.Text = "" Then
                        MsgBox("Debe ingresar la Observación")
                        txtObservacion.Focus()
                    Else
                        estado_process = oReclamoClienteService.Rechazar(IdReclamo, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        MsgBox("Se rechazó el Reclamo de Cliente correctamente ")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If
                End If

            End If
        Catch ex As Exception
            MsgBox("Error al Rechazar Reclamo de Cliente: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Finalizar()
        Try
            oReclamoClienteService.Close()
        Catch ex As TimeoutException
            oReclamoClienteService.Abort()
        Catch ex As CommunicationException
            oReclamoClienteService.Abort()
        End Try
    End Sub

    Private Sub cbAprobar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAprobar.CheckedChanged
        If cbRechazar.Checked Then
            btnAprobar.Text = "Rechazar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
            Me.Size = New System.Drawing.Size(509, 236)            
            txtObservacion.Focus()        
        Else
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            Me.Size = New System.Drawing.Size(509, 236)            
            txtObservacion.Focus()
        End If
    End Sub

    Private Sub cbRechazar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbRechazar.CheckedChanged
        If cbRechazar.Checked Then
            btnAprobar.Text = "Rechazar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
            Me.Size = New System.Drawing.Size(509, 236)            
            txtObservacion.Focus()  
        Else
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            Me.Size = New System.Drawing.Size(509, 236)            
            txtObservacion.Focus()
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub
End Class