Imports System.ServiceModel
Public Class frmListaPrecioClienteNuevo_ModificarValidez

    Private oListaClienteCabService As New ListaClienteCabService.ListaClienteCabServiceClient

    Public FecVencimiento As Date
    Public IdLista As Integer

    Private Sub frmListaPrecioClienteNuevo_ModificarValidez_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oListaClienteCabService.Close()
        Catch ex As TimeoutException
            oListaClienteCabService.Abort()
        Catch ex As CommunicationException
            oListaClienteCabService.Abort()
        End Try
    End Sub

    Private Sub frmListaPrecioClienteNuevo_ModificarValidez_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmListaPrecioClienteNuevo_ModificarValidez_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFecVencimiento.Select()
    End Sub

    Private Sub txtFecVencimiento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecVencimiento.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnGuardar.Select()
            btnGuardar_Click(sender, e)
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de Modificar la Fecha de Vencimiento de la Lista de Precio Cliente Nº " + CStr(IdLista) + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oListaClienteCabService.ActualizarFechaVencimiento(CInt(IdLista), txtFecVencimiento.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    MsgBox("Se modifico la fecha de vencimiento.", MsgBoxStyle.Information)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ACTUALIZAR la fecha de vencimiento de la lista precio cliente :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class