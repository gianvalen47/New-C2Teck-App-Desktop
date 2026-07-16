Public Class frmCotizacion_GenerarCoti

    Private oCotizacionService As New CotizacionService.CotizacionServiceClient
    Private oLocacionClienteService As New LocacionClienteService.LocacionClienteServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private dtDatos As DataTable
    Private dtLocacion As DataTable
    Public IdCotizacion As Integer
    Public IdCliente As Integer

    Private Sub frmCotizacion_GenerarCoti_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmCotizacion_GenerarCoti_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtNumDoc.KeyPress _
            , txtFecDoc.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oCotizacionService) = False Then
                oCotizacionService.Close()
            End If
           
            If isClosed(oLocacionClienteService) = False Then
                oLocacionClienteService.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
           
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmCotizacion_GenerarCoti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtFecDoc.Value = Session.sFecha

    End Sub
    
    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdCotizacion) = 0 Then
                MsgBox("Debe Ingresar el código de la Cotización. ", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf txtNumDoc.Text = "" Then
                MsgBox("Debe Ingresar número nuevo de la Cotización.", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
            ElseIf toBlank(txtFecDoc.Text) = "" Then
                MsgBox("Debe Ingresar la fecha del nuevo documento", MsgBoxStyle.Information, "Información")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
            ElseIf oMaestroService.MostrarTipoCambio("US", txtFecDoc.Text) = 0 Then
                MsgBox("Esta fecha no tiene tipo de cambio, Tenga cuidado...")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
                'ElseIf oCotizacionService.Estado(IdCotizacion) = "ATENDIDO" Then
                '    MsgBox("No puede generar el documento...!" + vbCr + "Debido que la cotización esta ATENDIDO...!!", MsgBoxStyle.Information, "Información")
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [GEN-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GENERAR la Cotización" + "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                      And ValidaCampos() Then
                Dim estado_process As Boolean
                estado_process = oCotizacionService.GenerarCotizacion(IdCotizacion, txtFecDoc.Text, txtNumDoc.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process Then
                    MsgBox("Se generó la Cotización correctamente" + txtNumDoc.Text.ToString, MsgBoxStyle.Information)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [GEN-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
        
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
End Class