Imports System.ServiceModel

Public Class frmComSolicitudGasto_ActualizarJob

    '===========================Servicios====================================
    Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient
    Private oJobService As New JobService.JobServiceClient
    '======================Declaración de Variables==============================   

    Public IdGasto As Integer

    Public dtDetalles As DataTable

    Private Sub frmComSolicitudGasto_ActualizarJob_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudGastoDetService.Close()
            oJobService.Close()
        Catch ex As TimeoutException
            oSolicitudGastoDetService.Abort()
            oJobService.Abort()
        Catch ex As CommunicationException
            oSolicitudGastoDetService.Abort()
            oJobService.Abort()
        End Try
    End Sub

    Private Sub frmComSolicitudGasto_ActualizarJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComSolicitudGasto_ActualizarJob_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblIdGasto.Text = CStr(IdGasto)
        Me.Text = "Actualizar OT"
        txtNumJob.Focus()
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
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

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim estado_process As Boolean

            estado_process = oSolicitudGastoDetService.ActualizarJob(IdGasto, txtNumJob.Text.Trim, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            If estado_process Then
                MsgBox("Se actualizo la OT correctamente ")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If

        Catch ex As Exception
            MsgBox("Error al Actualizar el Número de Cuenta Contable : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
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
                    'ElseIf oJobService.Estado(txtNumJob.Text) = 16 Then
                    '    MsgBox("Número de Job Liquidado, Verifique")
                    '    txtNumJob.Text = ""
                    '    txtNumJob.Focus()
                Else
                    btnBuscarJob.Focus()
                    'txtIgv.Focus()
                    'cmbMoneda.Focus()
                End If
            Else
                btnBuscarJob.Focus()
                'txtIgv.Focus()
                'cmbMoneda.Focus()
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
                    'ElseIf oJobService.Estado(txtNumJob.Text) = 16 Then
                    '    MsgBox("Número de Job Liquidado, Verifique")
                    '    txtNumJob.Text = ""
                    '    txtNumJob.Focus()
                Else
                    btnBuscarJob.Focus()
                    'txtIgv.Focus()
                    'cmbMoneda.Focus()
                End If
            Else
                btnBuscarJob.Focus()
                'txtIgv.Focus()
                'cmbMoneda.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL OT : " + ex.Message)
        End Try
    End Sub

    Private Sub txtNumJob_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumJob.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnAceptar.Focus()
        End If
    End Sub
End Class