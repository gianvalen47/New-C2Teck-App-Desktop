Imports System.Windows.Forms

Public Class frmDespachoRequisicion_GenerarCierre
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oRequisicionService As New RequisicionService.RequisicionServiceClient
    Private oGuiaRemisionService As New GuiaRemisionService.GuiaRemisionServiceClient
    Private dtDatos As DataTable

    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdRequisicion As Integer
    Public IdLocacion As Integer
    Private estado As String
    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                  txtNumDoc.KeyPress _
                , txtFecIni.KeyPress _
                , txtFecFin.KeyPress _
                , txtFecDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmDespachoRequisicion_GenerarCierre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar

        txtFecIni.Value = Session.sFecha
        txtFecFin.Value = Session.sFecha
        txtFecDoc.Value = Session.sFecha

        txtNumDoc.Text = oGuiaRemisionService.SugerirNumero(oGuiaRemisionService.MostraIdSerie(IdLocacion))


    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oRequisicionService) = False Then
                oRequisicionService.Close()
            End If
            If isClosed(oGuiaRemisionService) = False Then
                oGuiaRemisionService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                  txtNumDoc.KeyUp _
                , txtFecIni.KeyUp _
                , txtFecFin.KeyUp _
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
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdRequisicion) = 0 Then
                MsgBox("Debe Ingresar el código de la Requisición. ", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(txtFecIni.Text) = "" Then
                MsgBox("Debe Ingresar la fecha inicial", MsgBoxStyle.Information, "Información")
                txtFecIni.BackColor = Color.Red
                txtFecIni.Focus()
                Return False
            ElseIf toBlank(txtFecFin.Text) = "" Then
                MsgBox("Debe Ingresar la fecha final", MsgBoxStyle.Information, "Información")
                txtFecFin.BackColor = Color.Red
                txtFecFin.Focus()
                Return False
            ElseIf toNumber(txtNumDoc.Text) = 0 Then
                MsgBox("Debe Ingresar número de inicial de las Guías.", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
            ElseIf toBlank(txtFecDoc.Text) = "" Then
                MsgBox("Debe Ingresar la fecha del las Guías", MsgBoxStyle.Information, "Información")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
            ElseIf state_button = True And oGuiaRemisionService.Buscar(IdLocacion, oGuiaRemisionService.MostraIdSerie(IdLocacion), toNumber(txtNumDoc.Text)) Then
                MsgBox("El número de la Guía inicial Nº " + txtNumDoc.Text.ToString + " ya existe...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf state_button = True And oRequisicionService.Estado(IdRequisicion) <> "GENERADO" Then
                MsgBox("No puede generar el documento...!" + vbCr + "Debido que la Requisición no esta en estado GENERADO...!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [GEN-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub GenerarDocumento()
        Try
            Dim estado_process As String
            estado_process = oRequisicionService.GenerarCierre(IdLocacion, txtFecIni.Text, txtFecFin.Text, toNumber(txtNumDoc.Text), txtFecDoc.Text, Session.sCodUsu)
            If toBlank(estado_process) <> "" Then
                MsgBox("El Cierre se ejecuto correctamente…!!!" + vbCr + "Se generaron las siguientes Guías de Remisión: " + estado_process, MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [GEN-002]: " + ex.Message, MsgBoxStyle.Exclamation)
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
        If MsgBox("¿Está seguro de GENERAR el Cierre?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
            GenerarDocumento()
        End If
    End Sub
End Class
