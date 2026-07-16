Imports System.ServiceModel
Public Class frmDespachoCierre

    Private oDespachoCabService As New DespachoCabService.DespachoCabServiceClient

    Public IdDespachoCab As String

    Private Sub frmDespachoCierre_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
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

    Private Sub frmDespachoCierre_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmDespachoCierre_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtHoraCierre.Text = Now().ToString("HH:mm:ss")
        txtHoraCierre.Select()

    End Sub

    Private Sub txtHoraCierre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHoraCierre.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtObservacion.Select()
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnAceptar.Enabled = True Then
                btnAceptar.Select()
                btnAceptar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Try
            If MsgBox("¿Está seguro de CERRAR el Despacho Nº " + IdDespachoCab + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then

                Dim cerrar As Boolean
                Dim iddespacho As Int32 = toNumber(IdDespachoCab)
                cerrar = oDespachoCabService.CerrarRuta(iddespacho, txtHoraCierre.Text, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                If cerrar = True Then
                    MsgBox("Se Cerro el despacho correctamente.", MsgBoxStyle.Information)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK

                End If
            End If

        Catch ex As Exception
            MsgBox("Error al CERRAR el Despacho : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub
End Class