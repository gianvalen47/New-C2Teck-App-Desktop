Imports System.ServiceModel
Public Class frmReembolso_Ingresar

    '===========================Servicios====================================================
    Dim oReembolsoCajaDetService As New ReembolsoCajaDetService.ReembolsoCajaDetServiceClient

    '======================Declaración de Variables==============================================
    Public IdReembolso As Integer

    Private Sub frmReembolso_Generar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtFechaInicio.Focus()
        Me.Text = "Ingresar Solicitud de Gastos al Reembolso Nº " & IdReembolso
    End Sub

    Private Sub frmReembolso_Generar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmReembolso_Generar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oReembolsoCajaDetService.Close()
        Catch ex As TimeoutException
            oReembolsoCajaDetService.Abort()
        Catch ex As CommunicationException
            oReembolsoCajaDetService.Abort()
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim estado_process As Boolean
            If MsgBox("¿Estás seguro de INGRESAR Solicitud de Gastos al Reembolso N°:" & IdReembolso & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                estado_process = oReembolsoCajaDetService.IngresarSolicitudGasto(IdReembolso, txtFechaInicio.Value, txtFechaFin.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                MsgBox("Se Ingresó Solicitud de Gastos correctamente al Reembolso")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception
            MsgBox("Error al Ingresar Solicitud de Gastos al Reembolso: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class