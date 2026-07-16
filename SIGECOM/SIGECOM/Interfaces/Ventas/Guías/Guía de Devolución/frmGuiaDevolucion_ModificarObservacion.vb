Imports System.Windows.Forms

Public Class frmGuiaDevolucion_ModificarObservacion
  Public state_button As Boolean              'True: Modificar    False: nuevo
  Private oGuiaDevolucionService As New GuiaDevolucionService.GuiaDevolucionServiceClient
    Public IdGuiaDev As Integer

    Private Sub frmGuiaDevolucion_ModificarObservacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If MsgBox("¿Desea Guardar la Observación?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
                btnGuardar_Click(sender, e)

            Else
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If
        End If
    End Sub

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
  Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If txtObservacion.ReadOnly Then
            'btnAceptar.Select()
            'Me.CancelButton = btnAceptar
    Else
      txtObservacion.Select()
            ' Me.CancelButton = btnCancelar
    End If
  End Sub
  Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    Try
      If isClosed(oGuiaDevolucionService) = False Then
        oGuiaDevolucionService.Close()
      End If
    Catch ex As Exception
      MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
  '====================================================================================================================
  '============================================ TASK'S METHOD =========================================================
  '====================================================================================================================
  Private Sub salir()
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub
  '====================================================================================================================
  '============================================ INTERFACE'S METHOD ==================================================== 
  '==================================================================================================================== 
  
  Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.OK
  End Sub
  Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
    salir()
  End Sub

End Class
