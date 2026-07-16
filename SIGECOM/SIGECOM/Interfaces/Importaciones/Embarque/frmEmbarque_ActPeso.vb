Imports System.ServiceModel
Public Class frmEmbarque_ActPeso

    Private oEmbarqueDetService As New EmbarqueDetService.EmbarqueDetServiceClient

    '======================Declaración de Variables==============================
    Public CodEmbarque As String
    Public IdFactura As Integer
    Public NumDoc As String


    Private Sub frmEmbarque_ActPeso_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmEmbarque_ActPeso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Actualizar Peso de la Factura Nº " + Chr(34) + NumDoc.ToString + Chr(34)
        txtPeso.Select()
    End Sub

    Private Sub frmEmbarque_ActPeso_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oEmbarqueDetService.Close()
        Catch ex As TimeoutException
            oEmbarqueDetService.Abort()
        Catch ex As CommunicationException
            oEmbarqueDetService.Abort()
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim estado_process As Boolean
            If MsgBox("¿Está seguro de ACTUALIZAR el peso de la Factura N°: " & NumDoc.ToString & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If toNumber(txtPeso.Value) < 0 Then
                    MsgBox("Debe Ingresar un Peso valido")
                    txtPeso.Focus()
                Else
                    estado_process = oEmbarqueDetService.ActualizarPeso(CodEmbarque, IdFactura, utils.toDouble(txtPeso.Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    MsgBox("Se Actualizó el Peso correctamente ")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Actualizar el Peso : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class