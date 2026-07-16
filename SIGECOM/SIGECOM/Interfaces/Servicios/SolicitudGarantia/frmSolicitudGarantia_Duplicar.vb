Imports System.ServiceModel
Public Class frmSolicitudGarantia_Duplicar

    '===========================Servicios====================================
    Private oSolicitudGarantiaService As New SolicitudGarantiaService.SolicitudGarantiaServiceClient
    Private oJobService As New JobService.JobServiceClient

    '======================Declaración de Variables==============================   
    Public IdAfa As Integer

    Private Sub frmSolicitudGarantia_Duplicar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmSolicitudGarantia_Duplicar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmSolicitudGarantia_Duplicar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtNumJob.Focus()
        Me.Text = "Duplicar Formato de ORDEN DE REPARACIÓN N°:" & IdAfa
    End Sub

    Private Sub btnDuplicar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDuplicar.Click
        Try
            Dim estado_process As Integer
            If MsgBox("¿Está seguro de duplicar el Formato de ORDEN DE REPARACIÓN N°: " & IdAfa & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If txtNumJob.Text = "" Then
                    MsgBox("Debe ingresar el Nº de OT")
                    txtNumJob.Focus()
                Else
                    estado_process = oSolicitudGarantiaService.Duplicar(IdAfa, txtNumJob.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process > 0 Then
                        MsgBox("Se generó el Formato de ORDEN DE REPARACIÓN Nº " + estado_process.ToString + "correctamente.")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("Error en el Proceso, comunicarse con el área de TI.!!!")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Duplicar Formato de ORDEN DE REPARACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oSolicitudGarantiaService.Close()
            oJobService.Close()
        Catch ex As TimeoutException
            oSolicitudGarantiaService.Abort()
            oJobService.Abort()
        Catch ex As CommunicationException
            oSolicitudGarantiaService.Abort()
            oJobService.Abort()
        End Try
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarJob.Enabled = True Then
                e.Handled = True
                btnBuscarJob_Click(sender, e)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                ElseIf oJobService.Estado(txtNumJob.Text) = 16 Then
                    MsgBox("Número de OT Liquidado, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                End If
            Else
                txtNumJob.Focus()
            End If
        End If
    End Sub

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        Try
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                ElseIf oJobService.Estado(txtNumJob.Text) = 16 Then
                    MsgBox("Número de OT Liquidado, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                End If
            Else
                txtNumJob.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA OT : " + ex.Message)
        End Try
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Try
            Dim frm As New frmBuscarJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.cod_job) <> Nothing Then
                    txtNumJob.Text = frm.cod_job
                Else
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class