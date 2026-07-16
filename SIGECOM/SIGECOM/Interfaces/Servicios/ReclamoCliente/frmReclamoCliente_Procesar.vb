Imports System.ServiceModel
Public Class frmReclamoCliente_Procesar

    '===========================Servicios====================================
    Private oReclamoClienteService As New ReclamoClienteService.ReclamoClienteServiceClient
    Private oJobService As New JobService.JobServiceClient

    '======================Declaración de Variables==============================   
    Public IdReclamo As Integer

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oReclamoClienteService.Close()
            oJobService.Close()
        Catch ex As TimeoutException
            oReclamoClienteService.Abort()
            oJobService.Abort()
        Catch ex As CommunicationException
            oReclamoClienteService.Abort()
            oJobService.Abort()
        End Try
    End Sub

    Private Sub frmReclamoCliente_Procesar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmReclamoCliente_Procesar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmReclamoCliente_Procesar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load        
        Me.Text = "Procesar Reclamo de Cliente N°:" & IdReclamo.ToString
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
                ElseIf (oJobService.Estado(txtNumJob.Text) = 16 Or oJobService.Estado(txtNumJob.Text) = 25) And oJobService.Regularizar(txtNumJob.Text) = False Then
                    MsgBox("Número de OT Liquidado o Facturado")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    btnProcesar.Focus()
                End If
            Else
                btnProcesar.Focus()
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
                ElseIf (oJobService.Estado(txtNumJob.Text) = 16 Or oJobService.Estado(txtNumJob.Text) = 25) And oJobService.Regularizar(txtNumJob.Text) = False Then
                    MsgBox("Número de OT Liquidado o Facturado")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    btnProcesar.Focus()
                End If
            Else
                btnProcesar.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA OT : " + ex.Message)
        End Try
    End Sub

    Private Sub btnProcesar_Click(sender As Object, e As System.EventArgs) Handles btnProcesar.Click
        Try
            Dim estado_process As Boolean
            If MsgBox("¿Está seguro de PROCESAR el Reclamo de Cliente N°: " & IdReclamo & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If txtNumJob.Text = "" Then
                    MsgBox("Debe ingresar el Nro de OT")
                    txtNumJob.Focus()
                Else
                    estado_process = oReclamoClienteService.ProcesarReclamo(IdReclamo, toBlank(txtNumJob.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    MsgBox("Se procesó el reclamo de cliente correctamente ")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Procesar Reclamo de Cliente: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub
End Class