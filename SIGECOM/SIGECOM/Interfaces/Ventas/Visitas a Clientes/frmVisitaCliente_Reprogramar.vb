Public Class frmVisitaCliente_Reprogramar

    Private oVisitaClienteService As New VisitaClienteService.VisitaClienteServiceClient
    Public IdVisita As Integer
    Private Sub frmVisitaCliente_Reprogramar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try

            If isClosed(oVisitaClienteService) = False Then
                oVisitaClienteService.Close()
            End If

        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmVisitaCliente_Reprogramar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End If
    End Sub

    Private Sub frmVisitaCliente_Reprogramar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
             txtFecha.KeyPress _
             , txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub frmVisitaCliente_Reprogramar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtFecha.Select()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If MsgBox("¿Esta seguro de REPROGRAMAR la visita?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            Try
                Dim estado_process As Boolean
                estado_process = False  'oVisitaClienteService.Reprogramar(IdVisita, txtFecha.Text, txtObservacion.Text, Session.sCodUsu)
                If estado_process Then
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            Catch ex As Exception
                MsgBox("ERROR AL REPROGRAMAR VISITA: " + ex.Message, MsgBoxStyle.Exclamation)
            End Try            
        End If
    End Sub
End Class