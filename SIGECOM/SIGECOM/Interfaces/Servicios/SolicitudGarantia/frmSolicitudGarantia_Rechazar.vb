Imports System.ServiceModel
Public Class frmSolicitudGarantia_Rechazar

    '===========================Servicios====================================
    Private oSolicitudGarantiaAtencionService As New SolicitudGarantiaAtencionService.SolicitudGarantiaAtencionServiceClient
    Private oSolicitudGarantiaService As New SolicitudGarantiaService.SolicitudGarantiaServiceClient

    '======================Declaración de Variables==============================   
    Public IdAfa As Integer
    Public IdAfaDet As Integer

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub frmSolicitudGarantia_Rechazar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmSolicitudGarantia_Rechazar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmSolicitudGarantia_Rechazar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtObservacion.Focus()
        If IdAfaDet = 0 Then
            Me.Text = "Rechazar Formato de ORDEN DE REPARACIÓN N°:" & IdAfa
        Else
            Me.Text = "Rechazar Atención de Formato de ORDEN DE REPARACIÓN N°:" & IdAfaDet
        End If
    End Sub

    Private Sub btnAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        Try
            Dim estado_process As Boolean
            If IdAfaDet <> 0 Then
                If MsgBox("¿Está seguro de RECHAZAR la Atención de Formato de ORDEN DE REPARACIÓN N°: " & IdAfaDet & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    If txtObservacion.Text = "" Then
                        MsgBox("Debe ingresar la Observación")
                        txtObservacion.Focus()
                    Else
                        estado_process = oSolicitudGarantiaAtencionService.Rechazar(IdAfa, IdAfaDet, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        MsgBox("Se rechazó la Atención de Formato de ORDEN DE REPARACIÓN correctamente")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If
                End If
            Else
                If MsgBox("¿Estás seguro de rechazar el Formato de ORDEN DE REPARACIÓN N°:" & IdAfa & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    If txtObservacion.Text = "" Then
                        MsgBox("Debe ingresar la Observación")
                        txtObservacion.Focus()
                    Else
                        estado_process = oSolicitudGarantiaService.Rechazar(IdAfa, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        MsgBox("Se rechazó el Formato de ORDEN DE REPARACIÓN correctamente ")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Rechazar Formato de ORDEN DE REPARACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oSolicitudGarantiaAtencionService.Close()
        Catch ex As TimeoutException
            oSolicitudGarantiaAtencionService.Abort()
        Catch ex As CommunicationException
            oSolicitudGarantiaAtencionService.Abort()
        End Try
    End Sub
End Class