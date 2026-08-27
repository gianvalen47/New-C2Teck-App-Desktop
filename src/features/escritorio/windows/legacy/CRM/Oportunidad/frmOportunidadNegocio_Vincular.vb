Imports System.ServiceModel
Imports System.Net
Public Class frmOportunidadNegocio_Vincular
    Private oOportunidadNegocioService As New OportunidadNegocioService.OportunidadNegocioServiceClient

    '======================Declaración de Variables==============================
    Public IdOportunidad As Integer
    Public IdCliente As Integer
    Public IdCotizacion As Integer

    Private Sub frmOportunidadNegocio_Vincular_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.Text = "Vincular Cotización a la Oportunidad de Negocio Nº " + Chr(34) + IdOportunidad.ToString + Chr(34)
        llenarCombos()
        txtNumCot.Select()
    End Sub

    Private Sub frmOportunidadNegocio_Vincular_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmOportunidadNegocio_Vincular_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        finalizar()
    End Sub

    Private Sub llenarCombos()
        Try
           
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oOportunidadNegocioService.Close()
        Catch ex As TimeoutException
            oOportunidadNegocioService.Abort()
        Catch ex As CommunicationException
            oOportunidadNegocioService.Abort()
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            Dim estado_process As Boolean
            If MsgBox("¿Está seguro de VINCULAR la cotización a la Oportunidad de Negocio N°: " & IdOportunidad.ToString & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If toNumber(IdCotizacion) = 0 Then
                    MsgBox("Debe Seleccionar la cotización")
                    btnBuscarCotizacion.Focus()
                Else
                    estado_process = oOportunidadNegocioService.VincularCotizacion(IdOportunidad, IdCotizacion, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    MsgBox("Se vinculó la Cotización correctamente ")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Vincular la Cotización: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarCotizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCotizacion.Click
        Try
            Dim frm As New frmBuscarCotizacion
            frm.IdCliente = IdCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdCotizacion = frm.codigo
                    txtNumCot.Text = frm.numero
                    btnGuardar.Focus()
                Else
                    IdCotizacion = 0
                    txtNumCot.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumCot.KeyDown
        'If CInt(lblSolicitud.Text) = 0 Then
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCotizacion.Enabled = True Then
                e.Handled = True
                btnBuscarCotizacion_Click(sender, e)
            End If
        End If
        'End If
    End Sub
End Class