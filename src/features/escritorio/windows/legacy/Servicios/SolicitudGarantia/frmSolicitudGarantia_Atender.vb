Imports System.ServiceModel
Public Class frmSolicitudGarantia_Atender

    '===========================Servicios====================================
    Private oSolicitudGarantiaAtencionService As New SolicitudGarantiaAtencionService.SolicitudGarantiaAtencionServiceClient

    '======================Declaración de Variables==============================   
    Public IdAfa As Integer
    Public IdAfaDet As Integer

    Private Sub frmSolicitudGarantia_Atender_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                   txtCreditState.KeyPress _
                   , txtFechaCredit.KeyPress _
                   , txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmSolicitudGarantia_Atender_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmSolicitudGarantia_Atender_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtCreditState.Focus()
        txtFechaCredit.Value = Today
        Me.Text = "Atender Atención de Formato ORDEN DE REPARACIÓN N°:" & IdAfaDet
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim estado_process As Boolean
            If MsgBox("¿Está seguro de ATENDER la Atención de Formato de ORDEN DE REPARACIÓN N°: " & IdAfaDet & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If txtCreditState.Text = "" Then
                    MsgBox("Debe ingresar el Credit State...!")
                    txtCreditState.Focus()
                Else
                    estado_process = oSolicitudGarantiaAtencionService.Atender(IdAfa, IdAfaDet, txtCreditState.Text, txtFechaCredit.Value, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    MsgBox("Se atendió la Atención de Formato de ORDEN DE REPARACIÓN correctamente ")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Atender Atención de ORDEN DE REPARACIÓN : " + ex.Message, MsgBoxStyle.Exclamation)
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