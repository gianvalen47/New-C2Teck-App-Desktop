Imports System.ServiceModel

Public Class frmComSolicitudCompra_Generar

    Private oSolicitudCompraService As New SolicitudCompraService.SolicitudCompraServiceClient

    Public IdSolicitud As Integer
    Private IdProveedor As Integer
    Private dtCondicion As DataTable

    Private Sub frmComSolicituCompra_Generar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            oSolicitudCompraService.Close()
        Catch ex As TimeoutException
            oSolicitudCompraService.Abort()
        Catch ex As CommunicationException
            oSolicitudCompraService.Abort()
        End Try
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmComSolicituCompra_Generar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComSolicituCompra_Generar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
         cbFecha.KeyPress _
         , txtProveedor.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub frmComSolicituCompra_Generar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Text = "Generar Orden de Compra"

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If MsgBox("¿Está Seguro de GENERAR la orden de compra?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then

                Dim estado_proces As Long
                estado_proces = oSolicitudCompraService.GenerarOrdenCompra(IdSolicitud, IdProveedor, cbFecha.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                If estado_proces > 0 Then
                    MsgBox("Se generó correctamente la Orden de Compra N° : " & estado_proces, MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comunicarse con el administrador del sistema")
                End If

                Me.DialogResult = System.Windows.Forms.DialogResult.OK

            End If
        Catch ex As Exception
            MsgBox("Error al Generar la Orden de Compra : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdProveedor) = 0 Then
                MsgBox("Debe ingresar el proveedor")
                txtProveedor.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("Error al validar campos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdProveedor = frm.codigo
                txtProveedor.Text = frm.descripcion
                txtProveedor.Select()
            End If
        Catch ex As Exception
            MsgBox("Error al buscar el proveedor :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.F12 Then
            e.Handled = True
            btnBuscarProveedor_Click(sender, e)
        End If
    End Sub

End Class