Imports System.ServiceModel
Public Class frmDespachoCancelar

    Private oDespachoCabService As New DespachoCabService.DespachoCabServiceClient

    Public IdDespachoCab As String

    Private Sub frmDespachoCancelar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oDespachoCabService.Close()
        Catch ex As TimeoutException
            oDespachoCabService.Abort()
        Catch ex As CommunicationException
            oDespachoCabService.Abort()
        End Try
    End Sub

    Private Sub frmDespachoCancelar_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmDespachoCancelar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtMotivo.Focus()

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Try
            If MsgBox("¿Está seguro de CANCELAR el Despacho Nº " + IdDespachoCab + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then

                Dim cerrar As Boolean
                Dim iddespacho As Int32 = toNumber(IdDespachoCab)
                cerrar = oDespachoCabService.Cancelar(iddespacho, txtMotivo.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                If cerrar = True Then
                    MsgBox("Se Cancelo el despacho correctamente.", MsgBoxStyle.Information)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK

                End If
            End If

        Catch ex As Exception
            MsgBox("Error al CANCELAR el Despacho : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub
End Class