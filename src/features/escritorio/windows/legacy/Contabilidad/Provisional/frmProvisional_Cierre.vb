Imports System.ServiceModel
Public Class frmProvisional_Cierre

    '===========================Servicios====================================
    Private oProvisionalService As New ProvisionalService.ProvisionalServiceClient

    '======================Declaración de Variables==============================   
    Public IdProvisional As Integer
    Public IdGasto As Integer

    Private Sub frmComProvisional_Cierre_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmComProvisional_Cierre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComProvisional_Cierre_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = "Cierre del Provisional N°:" & IdProvisional.ToString
        txtSaldoFavor.Focus()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oProvisionalService.Close()
        Catch ex As TimeoutException
            oProvisionalService.Abort()
        Catch ex As CommunicationException
            oProvisionalService.Abort()
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim estado_process As Boolean
            'If ValidarCodigo() Then
            If MsgBox("¿Está seguro de CERRAR el Provisional N°: " & IdProvisional.ToString & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                'If txtObservacion.Text <> "" Then                
                estado_process = oProvisionalService.Cerrar(IdProvisional, txtTotalDevuelto.Value, txtSaldoFavor.Value, txtObservacion.Text, 0, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                MsgBox("Se Cerró el Provisional correctamente ")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                'Else
                'MsgBox("Debe ingresar la Observación")
                'End If                
            End If
            'Else
            'MsgBox("Número de Gasto inexistente")
            'txtGasto.Text = ""
            'txtGasto.Focus()
            'End If
        Catch ex As Exception
            MsgBox("Error al Cerrar el Provisional : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtSaldoFavor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSaldoFavor.KeyDown
        If txtSaldoFavor.Value <> 0 Then
            txtTotalDevuelto.Value = 0
            txtTotalDevuelto.Enabled = False
        Else
            txtTotalDevuelto.Value = 0
            txtTotalDevuelto.Enabled = True
        End If
    End Sub

    Private Sub txtTotalDevuelto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotalDevuelto.KeyDown
        If txtTotalDevuelto.Value <> 0 Then
            txtSaldoFavor.Value = 0
            txtSaldoFavor.Enabled = False
        Else
            txtSaldoFavor.Value = 0
            txtSaldoFavor.Enabled = True
        End If
    End Sub

    Private Sub frmComCotizacionSolicitud_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        txtSaldoFavor.KeyPress _
        , txtTotalDevuelto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnAceptar.Focus()
        End If
    End Sub

    Private Sub txtTotalDevuelto_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotalDevuelto.Validating
        If txtTotalDevuelto.Value <> 0 Then
            txtSaldoFavor.Value = 0
            txtSaldoFavor.Enabled = False
        Else
            txtSaldoFavor.Value = 0
            txtSaldoFavor.Enabled = True
        End If
    End Sub

    Private Sub txtSaldoFavor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSaldoFavor.Validating
        If txtSaldoFavor.Value <> 0 Then
            txtTotalDevuelto.Value = 0
            txtTotalDevuelto.Enabled = False
        Else
            txtTotalDevuelto.Value = 0
            txtTotalDevuelto.Enabled = True
        End If
    End Sub

    'Private Function ValidarCodigo() As Boolean
    '    Try
    '        If Len(Trim(txtGasto.Text)) > 0 Then
    '            If oProvisionalService.BuscarGasto(toNumber(txtGasto.Text)) Then
    '                Return True
    '            Else
    '                Return False
    '            End If
    '        Else
    '            Return True
    '        End If        
    '    Catch ex As Exception
    '        MsgBox("ERROR AL VALIDAR CODIGO : " + ex.Message)
    '    End Try
    'End Function

End Class