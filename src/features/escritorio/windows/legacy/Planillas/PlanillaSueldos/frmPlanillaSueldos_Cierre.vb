Imports System.ServiceModel
Public Class frmPlanillaSueldos_Cierre

    '===========================Servicios====================================
    Private oPlanillaSueldosService As New PlanillaSueldosService.PlanillaSueldosServiceClient

    '======================Declaración de Variables==============================   
    Public IdPlanilla As Integer

    Private Sub frmPlanillaSueldo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = "Cerrar / Revertir Cierre de la Planilla N°:" & IdPlanilla
        btnAceptar.Select()
    End Sub

    Private Sub frmPlanillaSueldo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmPlanillaSueldo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oPlanillaSueldosService.Close()
        Catch ex As TimeoutException
            oPlanillaSueldosService.Abort()
        Catch ex As CommunicationException
            oPlanillaSueldosService.Abort()
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As System.EventArgs) Handles btnAceptar.Click
        Try
                If cbCerrar.Checked = True Then
                    If MsgBox("¿Está seguro de CERRAR la Planilla de Sueldos N° " & IdPlanilla.ToString & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                        Dim estado_process As Boolean
                        estado_process = oPlanillaSueldosService.CerrarPlanilla(toNumber(IdPlanilla), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        If estado_process = True Then
                            MsgBox("Se cerró la Planilla de Sueldos correctamente.")
                        Else
                            MsgBox("¡Error en el proceso,comuniquese con el departamento de sistemas...!")
                        End If
                    End If
                ElseIf cbRevertirCierre.Checked = True Then
                    If MsgBox("¿Está seguro de REVERTIR el cierre de la Planilla de Sueldos N° " & IdPlanilla.ToString & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                        Dim estado_process As Boolean
                        estado_process = oPlanillaSueldosService.RevertirCierrePlanilla(toNumber(IdPlanilla), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        If estado_process = True Then
                            MsgBox("Se revirtió el cierre de la Planilla de Sueldos correctamente.")
                        Else
                            MsgBox("¡Error en el proceso,comuniquese con el departamento de sistemas...!")
                        End If
                    End If
                End If            
        Catch ex As Exception
            MsgBox("ERROR AL CERRAR / REVERTIR PLANILLA SUELDOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub
End Class