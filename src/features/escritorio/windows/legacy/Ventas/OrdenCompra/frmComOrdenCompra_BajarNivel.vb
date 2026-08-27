Imports System.ServiceModel
Public Class frmComOrdenCompra_BajarNivel

    '===========================Servicios====================================
    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient

    '======================Declaración de Variables==============================   
    Public IdOrden As Integer

    Private Sub frmComOrdenCompra_Anular_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmComOrdenCompra_Anular_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComOrdenCompra_Anular_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = "Bajar de Nivel la Orden de Compra N°:" & IdOrden
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oOrdenesCompraService.Close()
        Catch ex As TimeoutException
            oOrdenesCompraService.Abort()
        Catch ex As CommunicationException
            oOrdenesCompraService.Abort()
        End Try
    End Sub

    Private Sub btnAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        Try
            Dim estado_process As Boolean
            If txtObservacion.Text = "" Then
                MsgBox("¡Debe ingresar la Observación...!")
            Else
                If MsgBox("¿Está seguro de BAJAR DE NIVEL la Orden de Compra N°:" & IdOrden.ToString & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                    estado_process = oOrdenesCompraService.BajarNivel(IdOrden, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        MsgBox("Se BAJO DE NIVEL la Orden de Compra correctamente")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("¡Error en el Proceso ,Comunicarse con el Administrador del Sistema...!")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Bajar de Nivel la Orden de Compra : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub



End Class