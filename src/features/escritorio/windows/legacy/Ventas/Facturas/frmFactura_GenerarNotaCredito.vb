Imports System.ServiceModel

Public Class frmFactura_GenerarNotaCredito

    Private oFacturaService As New FacturaService.FacturaServiceClient
    Private oNotaCreditoService As New NotaCreditoService.NotaCreditoServiceClient

    Public IdFactura As Int32
    Private dtTipoNota As DataTable

    Private Sub frmFactura_GenerarNotaCredito_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oFacturaService.Close()
            oNotaCreditoService.Close()
        Catch ex As TimeoutException
            oFacturaService.Abort()
            oNotaCreditoService.Abort()
        Catch ex As CommunicationException
            oFacturaService.Abort()
            oNotaCreditoService.Abort()
        End Try
    End Sub

    Private Sub frmFactura_GenerarNotaCredito_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmFactura_GenerarNotaCredito_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtNumDoc.Text = oNotaCreditoService.SugerirNumero(299)  '299 nota de credito
        llenarCombos

    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= TIPO NOTA ================================================

            dtTipoNota = oNotaCreditoService.MostrarTipoNotaCredito.Tables(0)
            cmbTipoNota.DataSource = dtTipoNota
            cmbTipoNota.DropDownList.DataMember = dtTipoNota.Columns("DesTipo").ToString
            cmbTipoNota.DropDownList.DisplayMember = dtTipoNota.Columns("DesTipo").ToString
            cmbTipoNota.DropDownList.ValueMember = dtTipoNota.Columns("CodTipoCre").ToString
            cmbTipoNota.DropDownList.Columns(0).DataMember = dtTipoNota.Columns("CodTipoCre").ToString
            cmbTipoNota.DropDownList.Columns(1).DataMember = dtTipoNota.Columns("DesTipo").ToString
            dtTipoNota = Nothing


        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Try

            If ValidaCampos() Then

                Dim estado_process As Integer

                estado_process = oFacturaService.GenerarNotaCredito(IdFactura, txtFecDoc.Value, txtNumDoc.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp, cmbTipoNota.Value, txtMotivo.Text)

                If estado_process > 0 Then
                    MsgBox("Se Generó correctamente la Nota de Credito N° : " + txtNumDoc.Text.ToString, MsgBoxStyle.Information)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR [GEN-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtNumDoc.Text) = "" Then
                MsgBox("Debe ingresar el número del Documento..", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
            ElseIf toBlank(txtFecDoc.Text) = "" Then
                MsgBox("Debe Ingresar el la fecha.", MsgBoxStyle.Information, "Información")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
            ElseIf toBlank(cmbTipoNota.Text) = "" Then
                MsgBox("Debe ingresar el tipo de nota", MsgBoxStyle.Information, "Información")
                cmbTipoNota.Focus()
                Return False
            ElseIf toBlank(txtMotivo.Text) = "" Then
                MsgBox("Debe ingresar el motivo", MsgBoxStyle.Information, "Información")
                txtMotivo.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

End Class