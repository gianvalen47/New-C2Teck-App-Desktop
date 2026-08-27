Public Class frmCotizacion_GenerarGuiasMulti
    Public IdCotizacion As Integer
    Public IdLocacion As Integer
    Private oCotizacionService As New CotizacionService.CotizacionServiceClient
    Private oCotizacionDetalleService As New CotizacionDetalleService.CotizacionDetalleServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    Private Sub frmCotizacion_GenerarGuiasMulti_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oCotizacionService) = False Then
                oCotizacionService.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oCotizacionDetalleService) = False Then
                oCotizacionDetalleService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmCotizacion_GenerarGuiasMulti_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarJob.Enabled = True Then
                btnBuscarJob_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub frmCotizacion_GenerarGuiasMulti_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtFecDoc.KeyPress _
            , txtNumDoc.KeyPress _
            , txtNumJob.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmCotizacion_GenerarGuiasMulti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtNumDoc.Text = oCotizacionService.SugerirNumero(1, IdLocacion)
        txtFecDoc.Value = Session.sFecha
        If oCotizacionService.Estado(IdCotizacion) = "ATENDIDO" Then
            btnGuardar.Enabled = False
        Else
            btnGuardar.Enabled = True
        End If
    End Sub

    Private Sub txtFecDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter Or Keys.Tab) Then
            If btnGuardar.Enabled = True Then
                btnGuardar.Select()
                'btnGuardar_Click(sender, e)
            Else
                'dgvDatos.Select()
            End If
        End If
        'If e.KeyChar = ChrW(Keys.Enter) Then
        '    If btnBuscarCliente.Enabled = True Then
        '        btnBuscarCliente.Select()
        '        e.Handled = True
        '    End If
        'End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdCotizacion) = 0 Then
                MsgBox("Debe Ingresar el código de la Cotización. ", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf txtNumDoc.Text = "" Then
                MsgBox("Debe Ingresar número del nuevo documento.", MsgBoxStyle.Information, "Información")
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
            ElseIf oCotizacionService.Estado(IdCotizacion) = "ATENDIDO" Then
                MsgBox("No puede generar el documento...!" + vbCr + "Debido que la cotización esta ATENDIDA...!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [GEN-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub GenerarGuias()
        Try
            Dim estado_process As Integer
            estado_process = oCotizacionService.GenerarGuiasMasivas(IdCotizacion, txtNumDoc.Text, toNull(txtNumJob.Text), txtFecDoc.Value, Session.sCodUsu)
            If estado_process <> "" Then
                MsgBox("Se generó las Guías" & vbCr & "Números : " & estado_process & " correctamente.", MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [GEN-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try 
            Dim codigos As String = oCotizacionService.MostrarMercaderiaSinStock(IdCotizacion)
            If MsgBox(codigos & " ¿Está seguro de GENERAR las Guías", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                And ValidaCampos() Then
                GenerarGuias()
            End If
        Catch ex As Exception
            MsgBox("Error al Generar Guias multiples " + ex.Message, MsgBoxStyle.Information, "Error al Generar")
        End Try
        
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Dim frm As New frmBuscarJob
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.Text = frm.cod_job
            txtNumJob.Select()
        End If
    End Sub

End Class