Imports System.ServiceModel
Public Class frmListaOfertaNuevo_ModificarValidez

    Private oListaOfertaCabService As New ListaOfertaCabService.ListaOfertaCabServiceClient

    Public FecVencimiento As Date
    Public IdOferta As Integer

    Private Sub frmListaOfertaNuevo_ModificarValidez_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFecVencimiento.Value = Session.sFecha
        txtFecVencimiento.Select()
    End Sub

    Private Sub frmListaOfertaNuevo_ModificarValidez_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmListaOfertaNuevo_ModificarValidez_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oListaOfertaCabService.Close()
        Catch ex As TimeoutException
            oListaOfertaCabService.Abort()
        Catch ex As CommunicationException
            oListaOfertaCabService.Abort()
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de Modificar la Fecha de Vencimiento de la Lista de Oferta Nº " + CStr(IdOferta) + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oListaOfertaCabService.ActualizarFechaVencimiento(CInt(IdOferta), txtFecVencimiento.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    MsgBox("Se modifico la fecha de vencimiento.", MsgBoxStyle.Information)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ACTUALIZAR la fecha de vencimiento de la lista oferta :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class