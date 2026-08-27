Imports System.ServiceModel

Public Class frmEmbarque_BajarNivel

    '=========================== Servicios ====================================
    Private oEmbarqueService As New EmbarqueService.EmbarqueServiceClient

    Public CodEmbarque As String

    Private Sub frmEmbarque_BajarNivel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oEmbarqueService.Close()
        Catch ex As TimeoutException
            oEmbarqueService.Abort()
        Catch ex As CommunicationException
            oEmbarqueService.Abort()
        End Try
    End Sub

    Private Sub frmEmbarque_BajarNivel_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmEmbarque_BajarNivel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtObservacion.Focus()

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If txtObservacion.Text = "" Then
            MsgBox("Debe ingresar una observación, tenga cuidado", MsgBoxStyle.Information)
        Else
            If MsgBox("¿Está seguro de bajar de nivel el embarque?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                BajarNivel()
            End If
        End If
    End Sub

    Private Sub BajarNivel()
        Try

            If oEmbarqueService.BajardeNivel(CodEmbarque, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp) Then
                MsgBox("Se Bajo de Nivel el Embarque correctamente", MsgBoxStyle.Information)
                'Limpiar()
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comunicarse con el área de TI")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL BAJAR DE NIVEL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class