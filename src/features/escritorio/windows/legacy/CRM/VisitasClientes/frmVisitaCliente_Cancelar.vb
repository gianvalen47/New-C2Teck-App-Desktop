Imports System.ServiceModel
Imports System.Windows.Forms
Public Class frmVisitaCliente_Cancelar
    '===========================Servicios====================================
    Private oVisitaClienteService As New VisitaClienteService.VisitaClienteServiceClient

    '======================Declaración de Variables==============================   
    Public IdVisita As Integer
    Private dtTipoCancelacion As DataTable

    Private Sub frmVisitaCliente_Cancelar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmVisitaCliente_Cancelar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComProvisional_Aprobar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        llenarCombos()
        Me.Text = "Cancelar la Visita N°:" & IdVisita
    End Sub
    Private Sub btnAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Dim estado_process As Boolean
            If MsgBox("¿Está seguro de CANCELAR la Visita N°: " & IdVisita & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If txtObservacion.Text = "" Then
                    MsgBox("Debe ingresar la Observación")
                    txtObservacion.Focus()
                Else
                    estado_process = oVisitaClienteService.CancelarVisita(IdVisita, toNumber(cmbTipoCancelacion.Value), txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    MsgBox("Se canceló la Visita de Cliente correctamente ")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Cancelar la Visita de Cliente : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try
            ''===================================== TIPO DE VISITA ============================================
            dtTipoCancelacion = oVisitaClienteService.MostrarTipoCancelacionVisita().Tables(0)
            'dtTipoVisita.Rows.InsertAt(getRowTodos(dtTipoVisita), 0)
            cmbTipoCancelacion.DataSource = dtTipoCancelacion
            cmbTipoCancelacion.DropDownList.DataMember = dtTipoCancelacion.Columns("Nombre").ToString
            cmbTipoCancelacion.DropDownList.DisplayMember = dtTipoCancelacion.Columns("Nombre").ToString
            cmbTipoCancelacion.DropDownList.ValueMember = dtTipoCancelacion.Columns("IdCancelacion").ToString
            cmbTipoCancelacion.DropDownList.Columns(0).DataMember = dtTipoCancelacion.Columns("IdCancelacion").ToString
            cmbTipoCancelacion.DropDownList.Columns(1).DataMember = dtTipoCancelacion.Columns("Nombre").ToString
            cmbTipoCancelacion.SelectedIndex = 0
            dtTipoCancelacion = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oVisitaClienteService.Close()
        Catch ex As TimeoutException
            oVisitaClienteService.Abort()
        Catch ex As CommunicationException
            oVisitaClienteService.Abort()
        End Try
    End Sub
End Class