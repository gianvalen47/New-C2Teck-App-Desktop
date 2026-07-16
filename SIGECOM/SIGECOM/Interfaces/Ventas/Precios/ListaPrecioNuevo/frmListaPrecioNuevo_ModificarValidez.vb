Imports System.ServiceModel
Public Class frmListaPrecioNuevo_ModificarValidez

    Private oListaPrecioCabService As New ListaPrecioCabService.ListaPrecioCabServiceClient

    Public FecVencimiento As Date
    Public IdLista As Integer

    Private Sub frmListaPrecioNuevo_ModificarValidez_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFecVencimiento.Value = Session.sFecha
        txtFecVencimiento.Select()
    End Sub

    Private Sub frmListaPrecioNuevo_ModificarValidez_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmListaPrecioNuevo_ModificarValidez_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oListaPrecioCabService.Close()
        Catch ex As TimeoutException
            oListaPrecioCabService.Abort()
        Catch ex As CommunicationException
            oListaPrecioCabService.Abort()
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de Modificar la Fecha de Vencimiento de la Lista de Precio Nº " + CStr(IdLista) + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oListaPrecioCabService.ActualizarFechaVencimiento(CInt(IdLista), txtFecVencimiento.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    MsgBox("Se modifico la fecha de vencimiento.", MsgBoxStyle.Information)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ACTUALIZAR la fecha de vencimiento de la lista precio :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtFecVencimiento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFecVencimiento.KeyPress
        If e.KeyChar = ChrW(Keys.Tab Or Keys.Enter) Then
            If btnGuardar.Enabled = True Then
                btnGuardar.Select()
                btnGuardar_Click(sender, e)
            Else
                'dgvDatos.Select()
            End If
        End If
    End Sub
End Class