Imports System.ServiceModel
Public Class frmActTipoCambio

    Private oAprobarVentaService As New AprobarVentaService.AprobarVentaServiceClient

    Private Sub frmActTipoCambio_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oAprobarVentaService.Close()
        Catch ex As TimeoutException
            oAprobarVentaService.Abort()
        Catch ex As CommunicationException
            oAprobarVentaService.Abort()
        End Try
    End Sub

    Private Sub frmActTipoCambio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmActTipoCambio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtTipoCambio.Focus()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Try
            If MsgBox("¿Está seguro que desea actualizar el Tipo de Cambio para Ventas y Facturación?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If validarData() Then
                    Dim estado_process As Boolean
                    estado_process = oAprobarVentaService.ActualizarTipoCambio(txtTipoCambio.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process = True Then
                        MsgBox("Se actualizó el Tipo de Cambio para Ventas y Facturación Correctamente.")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR EL TIPO DE CAMBIO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function validarData() As Boolean
        If txtTipoCambio.Value = 0 Then
            MsgBox("El Tipo de Cambio debe ser mayor a cero")
            txtTipoCambio.Focus()
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnHistorial_Click(sender As Object, e As System.EventArgs) Handles btnHistorial.Click
        Try
            'If ValidaCodigoSeleccionado() Then
            Dim frm As New frmHistorialTipoCambio
            frm.Text = "Historial de Tipo de Cambio para Ventas y Facturación"
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            End If
            'End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class