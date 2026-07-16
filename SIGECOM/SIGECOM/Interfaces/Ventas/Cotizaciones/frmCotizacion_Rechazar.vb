Imports System.Windows.Forms
Imports System.ServiceModel
Imports System.Net
Public Class frmCotizacion_Rechazar

    Private oCotizacionService As New CotizacionService.CotizacionServiceClient
    Private ObjSeguridad As New SeguridadService.SeguridadClient
    Private dtMotivo As DataTable
    Public IdCotizacion As Integer

    Private Sub frmCotizacion_Rechazar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oCotizacionService) = False Then
                oCotizacionService.Close()
            End If
            If isClosed(ObjSeguridad) = False Then
                ObjSeguridad.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub frmCotizacion_Rechazar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmCotizacion_Rechazar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            cmbMotivo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmCotizacion_Rechazar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
    End Sub
    Private Sub llenarCombos()
        Try
            dtMotivo = oCotizacionService.MostrarTipoRechazo.Tables(0)
            cmbMotivo.DataSource = dtMotivo
            cmbMotivo.DropDownList.DataMember = dtMotivo.Columns("Nombre").ToString
            cmbMotivo.DropDownList.DisplayMember = dtMotivo.Columns("Nombre").ToString
            cmbMotivo.DropDownList.ValueMember = dtMotivo.Columns("IdTipo").ToString
            cmbMotivo.DropDownList.Columns(0).DataMember = dtMotivo.Columns("IdTipo").ToString
            cmbMotivo.DropDownList.Columns(1).DataMember = dtMotivo.Columns("Nombre").ToString
            dtMotivo = Nothing
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnRechazar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRechazar.Click
        Try
            If MsgBox("¿Está Seguro de RECHAZAR la Cotización ... ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                'Dim NomPc As String = Dns.GetHostName
                'Dim DirIp As IPHostEntry = Dns.GetHostEntry(NomPc)
                estado_process = oCotizacionService.Rechazar(IdCotizacion, cmbMotivo.Value, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process Then
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR [RECHAZAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class