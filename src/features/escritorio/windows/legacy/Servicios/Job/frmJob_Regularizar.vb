Imports System.ServiceModel

Public Class frmJob_Regularizar

    Private oJobService As New JobService.JobServiceClient

    Public CodJob As String

    Private Sub frmJob_Regularizar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
        Catch ex As TimeoutException
            oJobService.Close()
        Catch ex As CommunicationException
            oJobService.Close()
        End Try
    End Sub

    Private Sub frmJob_Regularizar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmJob_Regularizar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbActivar.Checked = True
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'If oJobService.Estado(CodJob) = 16 Or oJobService.Estado(CodJob) = 25 Then '///Se realizo el cambio día 23/03/2012 
        If oJobService.Estado(CodJob) <> 6 Then
            If cbActivar.Checked = True Then
                If MsgBox("¿Estás Seguro de " & cbActivar.Text & " la OT " & Trim(CodJob) & " para los Gastos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    RegularizarGastos()
                End If
            ElseIf cbDesactivar.Checked = True Then
                If MsgBox("¿Estás Seguro de " & cbDesactivar.Text & " la OT " & Trim(CodJob) & " para los Gastos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    RegularizarGastos()
                End If
            End If
        Else
            MsgBox("Esta OT puede ser Regularizado ya que no esta en Estado Liquidado o Facturado")
        End If
    End Sub

    Private Sub RegularizarGastos()
        Try
            If cbActivar.Checked = True Then
                If oJobService.Regularizar(CodJob) = False Then
                    Dim estado_process As Boolean
                    estado_process = oJobService.ActivarRegularizarGastos(CodJob, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                    If estado_process Then
                        MsgBox("Se Activo los Gastos correctamente !!!")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()
                    Else
                        MsgBox("Error en el Proceso, Comuniquese con el área de TI")
                    End If
                Else
                    MsgBox("Esta OT ya esta Activado para Regularización,Tenga Cuidado")
                End If

            ElseIf cbDesactivar.Checked = True Then
                If oJobService.Regularizar(CodJob) = True Then
                    Dim estado_process As Boolean
                    estado_process = oJobService.DesactivarRegularizarGastos(CodJob, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                    If estado_process Then
                        MsgBox("Se Desactivo los Gastos correctamente !!!")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()
                    Else
                        MsgBox("Error en el Proceso, Comuniquese con el área de sistemas")
                    End If
                Else
                    MsgBox("Esta OT ya esta Desactivado para Regularización, Tenga Cuidado")
                End If
            End If

        Catch ex As Exception
            MsgBox("ERROR AL ACTIVAR REGULARIZACION : " + ex.Message)
        End Try
    End Sub

End Class