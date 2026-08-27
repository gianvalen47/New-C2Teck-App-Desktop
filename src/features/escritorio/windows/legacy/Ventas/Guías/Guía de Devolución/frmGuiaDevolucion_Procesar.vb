Imports System.ServiceModel
Public Class frmGuiaDevolucion_Procesar

    '===========================Servicios====================================
    Private oGuiaDevolucionService As New GuiaDevolucionService.GuiaDevolucionServiceClient

    '======================Declaración de Variables==============================   
    Public IdGuiaDev As Integer
    Public NumDoc As String

    Private Sub frmGuiaDevolucion_Procesar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmGuiaDevolucion_Procesar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComOrdenCompra_Anular_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = "Procesar Guía de Devolución N°:" & NumDoc
        txtObservacion.Focus()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oGuiaDevolucionService.Close()
        Catch ex As TimeoutException
            oGuiaDevolucionService.Abort()
        Catch ex As CommunicationException
            oGuiaDevolucionService.Abort()
        End Try
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        Try
            Dim estado_process As Boolean
            If txtObservacion.Text = "" Then
                MsgBox("Debe ingresar la Observación...!")
            Else
                If MsgBox("¿Está seguro de PROCESAR la Guía de Devolución N°: " & NumDoc & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                    estado_process = oGuiaDevolucionService.Procesar(IdGuiaDev, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        MsgBox("Se Procesó la Guía de Devolución correctamente ")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("Error en el Proceso ,Comunicarse con el Administrador del Sistema")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Procesar la Guía de Devolución : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class