
Imports System.ServiceModel
Public Class frmPedido_ActualizarCodigo

    '===========================Servicios====================================
    Private oPedidoDetalleService As New PedidoDetService.PedidoDetServiceClient

    '======================Declaración de Variables==============================   
    Public IdPedidoDet As Integer
    Public IdPedido As Integer
    Public CodMer As String


    Private Sub frmPedido_ActualizarCodigo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPedidoDetalleService.Close()
        Catch ex As TimeoutException
            oPedidoDetalleService.Abort()
        Catch ex As CommunicationException
            oPedidoDetalleService.Abort()
        End Try
    End Sub

    Private Sub frmPedido_ActualizarCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmPedido_ActualizarCodigo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblCodigoActual.Text = CodMer
        txtNuevoCodigo.Focus()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Len(Trim(txtNuevoCodigo.Text)) > 0 Then
            NuevoCodigo()
        Else
            MsgBox("Ingrese un Nuevo código")
        End If
    End Sub

    Private Sub NuevoCodigo()
        Try
            Dim estado_process As Boolean

            estado_process = oPedidoDetalleService.ActualizarCodigo(toNumber(IdPedidoDet), toNumber(IdPedido), Trim(txtNuevoCodigo.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            If estado_process = True Then
                MsgBox("Se Actualizo correctamente el código")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error al Actualizar el Codigo")
            End If

        Catch ex As Exception
            MsgBox("Error al Actualizar el Codigo: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtNuevoCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNuevoCodigo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnAceptar.Focus()
        End If
    End Sub

End Class