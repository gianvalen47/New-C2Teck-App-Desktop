Imports System.ServiceModel
Public Class frmComMesaControl_Procesar

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
        Me.Text = "Procesar Mesa de Control N°:" & IdMesa
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

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnAprobar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim estado_process As Boolean
            If MsgBox("¿Está seguro de PROCESAR la Mesa deControl N°: " & IdMesa & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                estado_process = oMesaControlService.Procesar(IdMesa, cbProcesarCredito.Checked, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                MsgBox("Se Procesó la Mesa de Control correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception
            MsgBox("Error al aprobar/desaprobar la Mesa de Control : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


End Class