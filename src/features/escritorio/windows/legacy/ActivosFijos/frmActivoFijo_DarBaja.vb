Imports System.ServiceModel
Public Class frmActivoFijo_DarBaja

    '===========================Servicios====================================================
    Private oActivoFijoService As New ActivoFijoService.ActivoFijoServiceClient

    '======================Declaración de Variables==============================   
    Public CodActivo As String

    Private Sub frmActivoFijo_DarBaja_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oActivoFijoService.Close()
        Catch ex As TimeoutException
            oActivoFijoService.Abort()
        Catch ex As CommunicationException
            oActivoFijoService.Abort()
        End Try
    End Sub

    Private Sub frmActivoFijo_DarBaja_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmActivoFijo_DarBaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "Activo Fijo - Dar de Baja N°:" & CodActivo
        txtFecBaja.Value = Date.Today
        txtObservacion.Focus()
        txtObservacion.Select()

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Try
            'cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de DAR DE BAJA el Activo Fijo con código Nº " + CodActivo + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oActivoFijoService.DarBaja(CodActivo, Session.sCodEmp, txtFecBaja.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    'dtDatos = Nothing
                    'listaDatos()
                    MsgBox("Se dio de baja el registro correctamente.", MsgBoxStyle.Information)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL DAR DE BAJA EL ACTIVO FIJO:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub
End Class