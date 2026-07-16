Imports System.ServiceModel
Public Class frmComOrdenCompra_Aprobar

    '===========================Servicios====================================
    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient

    '======================Declaración de Variables==============================   
    Public IdOrden As Integer

    Private Sub frmComProvisional_Aprobar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmComProvisional_Aprobar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComProvisional_Aprobar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = "Aprobar la Orden de Compra N°:" & IdOrden
        btnAprobar.Select()
    End Sub

    Private Sub btnAprobar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAprobar.Click
        Try
            Dim estado_process As Boolean
            If cbAprobar.Checked Then
                If MsgBox("¿Estás seguro de APROBAR la Orden de Compra N°:" & IdOrden.ToString & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    estado_process = oOrdenesCompraService.Aprobar(IdOrden, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    MsgBox("Se Aprobo la Orden de Compra correctamente.")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            ElseIf cbRechazar.Checked Then
                If MsgBox("¿Estás seguro de RECHAZAR la Orden de Compra N°:" & IdOrden.ToString & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    If txtObservacion.Text = "" Then
                        MsgBox("Debe ingresar la Observación")
                        txtObservacion.Focus()
                    Else
                        estado_process = oOrdenesCompraService.Rechazar(IdOrden, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        MsgBox("Se rechazó la Orden de Compra correctamente.")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al aprobar/desaprobar la Orden de Compra : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oOrdenesCompraService.Close()
        Catch ex As TimeoutException
            oOrdenesCompraService.Abort()
        Catch ex As CommunicationException
            oOrdenesCompraService.Abort()
        End Try
    End Sub

    Private Sub cbAprobar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAprobar.CheckedChanged
        If cbAprobar.Checked Then
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            btnAprobar.Select()
        Else
            btnAprobar.Text = "Rechazar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
            txtObservacion.Select()
        End If
    End Sub

    Private Sub cbRechazar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbRechazar.CheckedChanged
        If cbRechazar.Checked Then
            btnAprobar.Text = "Rechazar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
            txtObservacion.Select()
        Else
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            btnAprobar.Select()
        End If
    End Sub
End Class