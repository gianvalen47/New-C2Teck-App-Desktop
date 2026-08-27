Imports System.ServiceModel
Public Class frmTablero_Procesar

    '===========================Servicios====================================
    Private oIndicadoresAlmacenService As New IndicadoresAlmacenService.IndicadoresAlmacenServiceClient

    '======================Declaración de Variables==============================   

    Private Sub frmTablero_Procesar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmTablero_Procesar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oIndicadoresAlmacenService.Close()
        Catch ex As TimeoutException
            oIndicadoresAlmacenService.Abort()
        Catch ex As CommunicationException
            oIndicadoresAlmacenService.Abort()
        End Try
    End Sub

    Private Sub frmTablero_Procesar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtFecha.Focus()
        txtFecha.Value = Today
        txtMeses.Value = 9
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        Try
            Dim estado_process As Boolean
            If MsgBox("¿Está seguro de realizar el PROCESO?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                oIndicadoresAlmacenService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(10)
                estado_process = oIndicadoresAlmacenService.ProcesarCoberturaTablero(Session.sCodEmp, txtFecha.Value, txtMeses.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process Then
                    MsgBox("Se realizó el proceso correctamente.")
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al realizar el Proceso" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class