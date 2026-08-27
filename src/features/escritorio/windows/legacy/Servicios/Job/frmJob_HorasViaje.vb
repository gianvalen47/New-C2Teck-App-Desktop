Imports System.ServiceModel

Public Class frmJob_HorasViaje

    Public CodJob As String
    Private IdCliente As Integer

    Private oMarcacionService As New MarcacionJobService.MarcacionJobServiceClient

    Private Sub frmJob_HorasViaje_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMarcacionService.Close()
        Catch ex As TimeoutException
            oMarcacionService.Abort()
        Catch ex As CommunicationException
            oMarcacionService.Abort()
        End Try
    End Sub

    Private Sub frmJob_HorasViaje_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmJob_HorasViaje_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblNumJob.Text = CodJob
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If utils.toBlank(dtpfecha.Value) = "" Then
            MsgBox("Debe ingresar la Fecha")
        ElseIf txtPersona.Text = "" Then
            MsgBox("Debe ingresar el colaborador")
        ElseIf txtObservacion.Text = "" Then
            MsgBox("Debe ingresar la observación")
        ElseIf txtHoraViaje.Text = "" Then
            MsgBox("Debe ingresar las Horas de Viaje")

        Else

            If oMarcacionService.ActualizarHoraViaje(utils.toBlank(dtpfecha.Value), lblNumJob.Text, IdCliente, utils.toNumber(txtHoraViaje.Text), utils.toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp) Then
                MsgBox("Hora de Viaje Actualizado")
            Else
                MsgBox("Error en el proceso, comunicarse con el área de TI")
            End If

        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnColaborador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColaborador.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                If toNull(frm.codigo) <> Nothing Then
                    txtPersona.Text = frm.descripcion
                    IdCliente = frm.codigo
                Else
                    txtPersona.Text = ""
                    IdCliente = 0
                End If

                'listarContactos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class