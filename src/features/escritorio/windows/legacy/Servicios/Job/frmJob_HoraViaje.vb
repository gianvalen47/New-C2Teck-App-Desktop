Imports System.ServiceModel
Public Class frmJob_HoraViaje
    Public CodJob As String
    Private IdPersona As Integer

    Private oMarcacionService As New MarcacionJobService.MarcacionJobServiceClient

    Private Sub frmJob_HoraViaje_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMarcacionService.Close()
        Catch ex As TimeoutException
            oMarcacionService.Abort()
        Catch ex As CommunicationException
            oMarcacionService.Abort()
        End Try
    End Sub

    Private Sub frmJob_HoraViaje_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmJob_HoraViaje_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblNumJob.Text = CodJob
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If utils.toBlank(txtFecha.Value) = "" Then
            MsgBox("Debe ingresar la Fecha")
        ElseIf txtSolicitante.Text = "" Then
            MsgBox("Debe ingresar el colaborador")
        ElseIf txtObservacion.Text = "" Then
            MsgBox("Debe ingresar la observación")
        ElseIf txtHoraViaje.Text = "" Then
            MsgBox("Debe ingresar las Horas de Viaje")

        Else
            If oMarcacionService.ActualizarHoraViaje(utils.toBlank(txtFecha.Value), lblNumJob.Text, IdPersona, txtHoraViaje.Value, utils.toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp) Then
                MsgBox("Hora de Viaje Actualizado")
                Limpiar()
            Else
                MsgBox("Error en el proceso, comunicarse con el área de TI")
            End If

        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub Limpiar()
        txtFecha.Value = Today
        txtSolicitante.Text = ""
        IdPersona = 0
        txtObservacion.Text = ""
        txtHoraViaje.Value = 1
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtSolicitante.Text = frm.descripcion
                    IdPersona = frm.codigo
                Else
                    txtSolicitante.Text = ""
                    IdPersona = 0
                End If
                'listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class