Imports System.Windows.Forms

Public Class frmGuiaDevolucion_GenerarNotaCredito

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oGuiaDevolucionService As New GuiaDevolucionService.GuiaDevolucionServiceClient
    Private oNotaCreditoService As New NotaCreditoService.NotaCreditoServiceClient
    Private dtDatos As DataTable
    Private oMaestroService As New MaestroService.MaestroClient
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdGuiaDev As Integer
    Public IdLocacion As Integer
    Private dtTipoNota As DataTable
    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                txtNumDoc.KeyPress _
                , txtFecDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmGuiaDevolucion_GenerarNotaCredito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If

    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        txtFecDoc.Value = Session.sFecha
        Me.CancelButton = Me.btnCancelar
        txtNumDoc.Text = oGuiaDevolucionService.SugerirNumeroNotaCredito(IdLocacion)
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oGuiaDevolucionService) = False Then
                oGuiaDevolucionService.Close()
            End If
            If isClosed(oNotaCreditoService) = False Then
                oNotaCreditoService.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                  txtNumDoc.KeyUp _
                , txtFecDoc.KeyUp
        Try
            Dim campo As New Object
            If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.EditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.EditBox
            ElseIf sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.NumericEditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.NumericEditBox
            ElseIf sender.GetType.ToString = "System.Windows.Forms.TextBox" Then
                campo = New TextBox
            End If
            campo = sender
            If campo.readonly = False Then
                If campo.Text.Trim.Length > 0 Then
                    campo.BackColor = Color.White
                Else
                    campo.BackColor = Color.Red
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
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
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdGuiaDev) = 0 Then
                MsgBox("Debe Ingresrar el código de la guía. ", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toNumber(txtNumDoc.Text) = 0 Then
                MsgBox("Debe Ingresar número de la note de crédito.", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
            ElseIf toBlank(txtFecDoc.Text) = "" Then
                MsgBox("Debe Ingresar la fecha", MsgBoxStyle.Information, "Información")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
            ElseIf toBlank(txtMotivo.Text) = "" Then
                MsgBox("Debe Ingresar el motivo", MsgBoxStyle.Information, "Información")
                txtMotivo.BackColor = Color.Red
                txtMotivo.Focus()
                Return False
            ElseIf toBlank(cmbTipoNota.Text) = "" Then
                MsgBox("Debe seleccionar el tipo de nota", MsgBoxStyle.Information, "Información")
                cmbTipoNota.BackColor = Color.Red
                cmbTipoNota.Focus()
                Return False
            ElseIf oMaestroService.MostrarTipoCambio("US", txtFecDoc.Text) <= 0 Then
                MsgBox("Tipo de cambio no puede ser CERO..", MsgBoxStyle.Information, "Información")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
                'ElseIf state_button = False And oNotaCreditoService.Buscar(IdLocacion, txtNumDoc.Text) Then
                '    MsgBox("El número " + txtNumDoc.Text + " ya existe...!", MsgBoxStyle.Information, "Información")
                '    Return False
            ElseIf state_button = True And oGuiaDevolucionService.Estado(IdGuiaDev) <> "IMPRESO" Then
                MsgBox("No puede generar la Nota de Crédito...!" + vbCr + "Debido que la Guía no esta en estado IMPRESO...!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub GenerarNotaCredito()
        Try
            Dim estado_process As Integer
            estado_process = oGuiaDevolucionService.GenerarNotaCredito(IdGuiaDev, txtFecDoc.Text, txtNumDoc.Text, cmbTipoNota.Value, txtMotivo.Text.Trim, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "insert"
            If estado_process > 0 Then
                IdGuiaDev = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
            GenerarNotaCredito()
        End If
    End Sub
End Class
