Imports System.Windows.Forms
Public Class frmAlmacen_FacturaImportacion_GenerarMTI

    Private oImportacionService As New ImportacionService.ImportacionServiceClient

    Public IdSerieDoc As Integer
    Public IdImportacion As Integer
    Private IdCliente As Integer
    Public NumDoc As String
    Public estado_process As String

    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oImportacionService) = False Then
                oImportacionService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If
        txtCliente.Select()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Estás seguro de Generar el MTI?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    oImportacionService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(30)
                    estado_process = oImportacionService.GenerarMTI(IdImportacion, txtFecDoc.Value, IdCliente, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    MsgBox("Se Generó el MTI Nº " + estado_process.ToString)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR EL MTI: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdImportacion) = 0 Then
                MsgBox("Debe Ingresar el código de la F/I.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(txtFecDoc.Text) = "" Then
                MsgBox("Debe Ingresar el la fecha.", MsgBoxStyle.Information, "Información")
                txtFecDoc.Focus()
                Return False
            ElseIf toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar el cliente ", MsgBoxStyle.Information, "Información")
                btnBuscarCliente.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub frmAlmacen_FacturaImportacion_GenerarMTI_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtCliente.Focus()
        Me.Text = "Generar MTI de Factura de Importación Nº " + Chr(34) + Numdoc + Chr(34)
    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente_Click(sender, e)
            End If
        End If
    End Sub
End Class