Imports System.Windows.Forms

Public Class frmGuiaRemision_Transferir

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oGuiaRemisionService As New GuiaRemisionService.GuiaRemisionServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdGuia As Integer
    Public IdLocacion As Integer
    Public NumDoc As String

    Private Sub txtAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAlmacen.KeyDown
        If e.KeyCode = Keys.F12 Then
            txtAlmacen_ButtonClick(sender, e)
        End If
    End Sub

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtAlmacen.KeyPress, btnGuardar.KeyPress, btnCancelar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmGuiaRemision_Transferir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oGuiaRemisionService) = False Then
                oGuiaRemisionService.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                           txtAlmacen.KeyUp
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
            If toNumber(IdGuia) = 0 Then
                MsgBox("Debe Ingresar el código de la Guía de Remisión.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toNumber(IdLocacion) = 0 Then
                MsgBox("Debe ingresar el almacén a transferir", MsgBoxStyle.Information, "Información")
                txtAlmacen.BackColor = Color.Red
                txtAlmacen.Select()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [TRANS-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Transferir()
        Try
            Dim estado_process As Boolean
            estado_process = oGuiaRemisionService.Transferir(toNumber(IdGuia), toNumber(IdLocacion), Session.sCodUsu)
            type_process = "insert"
            If estado_process = True Then
                MsgBox(" Se Transfirió la Guía de Remisión Nº: " + NumDoc + " :", MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [TRANS-002]: " + ex.Message, MsgBoxStyle.Exclamation)
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
        If MsgBox("¿Está seguro de TRANSFERIR la G/R Nº: " + NumDoc + " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
            Transferir()
        End If
    End Sub
    Private Sub txtAlmacen_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAlmacen.ButtonClick
        Dim frm As New frmBuscarAlmacen
        frm.LocUsuario = False
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtAlmacen.Text = frm.cmbOficinas.Text & " - " & frm.descripcion
            txtAlmacen.BackColor = System.Drawing.SystemColors.Control
            IdLocacion = frm.codigo
            txtAlmacen.Select()
        End If
    End Sub

End Class
