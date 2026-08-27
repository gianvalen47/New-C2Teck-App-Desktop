Imports System.ServiceModel
Public Class frmDespachoConformidad

    Private oDespachoCabService As New DespachoCabService.DespachoCabServiceClient
    Private oDespachoDetService As New DespachoDetService.DespachoDetServiceClient

    Public IdDespachoCab As String
    Public IdDespachoDet As String

    Private Sub frmDespachoConformidad_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oDespachoCabService.Close()
        Catch ex As TimeoutException
            oDespachoCabService.Abort()
        Catch ex As CommunicationException
            oDespachoCabService.Abort()
        End Try
    End Sub

    Private Sub frmDespachoConformidad_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmDespachoConformidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cbAprobar.Checked = True

    End Sub

    Private Sub cbAprobar_CheckedChanged(sender As Object, e As EventArgs) Handles cbAprobar.CheckedChanged
        If cbRechazar.Checked Then
            btnAceptar.Text = "Rechazar"
            btnAceptar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
            'Me.Size = New System.Drawing.Size(509, 236)
            txtObservacion.Focus()
        Else
            btnAceptar.Text = "Aprobar"
            btnAceptar.Image = SIGECOM.My.Resources.Resources.Aceptar
            'Me.Size = New System.Drawing.Size(509, 236)
            btnAceptar.Focus()
        End If
    End Sub

    Private Sub cbRechazar_CheckedChanged(sender As Object, e As EventArgs) Handles cbRechazar.CheckedChanged
        If cbRechazar.Checked Then
            btnAceptar.Text = "Rechazar"
            btnAceptar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
            'Me.Size = New System.Drawing.Size(509, 236)
            txtObservacion.Focus()
        Else
            btnAceptar.Text = "Aprobar"
            btnAceptar.Image = SIGECOM.My.Resources.Resources.Aceptar
            'Me.Size = New System.Drawing.Size(509, 236)
            btnAceptar.Focus()
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Try

            Dim conformidad As Boolean
            Dim iddespacho As Int32 = toNumber(IdDespachoCab)

            If cbAprobar.Checked Then
                conformidad = oDespachoDetService.Aceptar(toNumber(IdDespachoDet), toNumber(IdDespachoCab), txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            ElseIf cbRechazar.Checked Then
                conformidad = oDespachoDetService.Rechazar(toNumber(IdDespachoDet), toNumber(IdDespachoCab), txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If

        Catch ex As Exception
            MsgBox("Error al ACEPTAR/RECHAZAR la conformidad del despacho : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class