Imports System.Windows.Forms

Public Class frmTransferenciaInterna_ModificarObservacion
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Private oTransferenciaService As New TransferenciaService.TransferenciaServiceClient
    Public IdTransferencia As Integer

    Private Sub frmTransferenciaInterna_ModificarObservacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If MsgBox("Desea Guardar la Observación", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
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
        If oTransferenciaService.Estado(IdTransferencia) <> Nothing And oTransferenciaService.Estado(IdTransferencia) <> "GENERADO" Then
            btnGuardar.Enabled = False
        Else
            btnGuardar.Enabled = True
            txtObservacion.Select()
        End If
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oTransferenciaService) = False Then
                oTransferenciaService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If state_button Then
            oTransferenciaService.ActualizarObservacion(IdTransferencia, toNull(txtObservacion.Text), Session.sCodUsu)
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub
End Class
