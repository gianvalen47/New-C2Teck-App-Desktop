Imports System.ServiceModel

Public Class frmPedidoImportacion_ActFecPromesa

    '===========================Servicios====================================
    Private oPedidoImportService As New PedidoImportService.PedidoImportServiceClient

    Public IdPedidoImp As Integer
    Public FechaEstimada As Date

    Private Sub frmPedidoImportacion_ActFecPromesa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "Actualizar Fecha Estimada"
        txtFecDoc.Value = FechaEstimada
        txtFecDoc.Focus()
    End Sub

    Private Sub frmPedidoImportacion_ActFecPromesa_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmPedidoImportacion_ActFecPromesa_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPedidoImportService.Close()
        Catch ex As TimeoutException
            oPedidoImportService.Abort()
        Catch ex As CommunicationException
            oPedidoImportService.Abort()
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Dim estado_process As Boolean

            estado_process = oPedidoImportService.ActualizarFecPromesa(IdPedidoImp, txtFecDoc.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            If estado_process Then
                MsgBox("Se actualizo la fecha estimada correctamente.")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If

        Catch ex As Exception
            MsgBox("Error al Actualizar la fecha estimada : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub



End Class