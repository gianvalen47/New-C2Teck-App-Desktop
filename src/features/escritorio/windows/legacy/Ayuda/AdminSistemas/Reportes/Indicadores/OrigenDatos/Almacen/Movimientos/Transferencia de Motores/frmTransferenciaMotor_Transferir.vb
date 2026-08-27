Imports System.Windows.Forms

Public Class frmTransferenciaMotor_Transferir
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oTransferenciaMotorService As New TransferenciaMotorService.TransferenciaMotorServiceClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdTraMot As String
    Private IdLocacion As String
    Public IdLocacion_doc As String
    Public NumDoc As String

    Private Sub txtalmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtalmacen.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarAlmacen.Enabled = True Then
                btnBuscarAlmacen_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtMotor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMotor.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarMercaderia.Enabled = True Then
                btnBuscarMercaderia_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtMotor.KeyPress
        'txtalmacen.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmTransferenciaMotor_Transferir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
            e.Handled = True
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        If rbMotor.Checked Then
            btnBuscarMercaderia.Select()
        End If
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oTransferenciaMotorService) = False Then
                oTransferenciaMotorService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdTraMot) = 0 Then
                MsgBox("Debe Ingresar el código de la T.M.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf rbAlmacen.Checked And toNumber(IdLocacion) = 0 Then
                MsgBox("Debe ingresar el almacén a transferir", MsgBoxStyle.Information, "Información")
                btnBuscarAlmacen.Focus()
                Return False
            ElseIf rbMotor.Checked And toBlank(txtMotor.Text) = "" Then
                MsgBox("Debe ingresar el motor a transferir", MsgBoxStyle.Information, "Información")
                btnBuscarMercaderia.Focus()
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
            estado_process = oTransferenciaMotorService.Transferir(IdTraMot, toNumber(IdLocacion), toNull(txtMotor.Text), Session.sCodUsu)
            type_process = "insert"
            If estado_process = True Then
                MsgBox(" Se Transfirió correctamente al T.M. Nº: " + NumDoc + " :", MsgBoxStyle.Information)
                Me.DialogResult = Windows.Forms.DialogResult.OK
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
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de transferir la T.M Nº: " + NumDoc + " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
            Transferir()
        End If
    End Sub
    Private Sub btnBuscarAlmacen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarAlmacen.Click
        Dim frm As New frmBuscarAlmacen
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtalmacen.Text = frm.cmbOficinas.Text & " - " & frm.descripcion
            txtalmacen.BackColor = System.Drawing.SystemColors.Control
            IdLocacion = frm.codigo
        End If
        txtalmacen.Select()
    End Sub
    Private Sub rbMotor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMotor.CheckedChanged, rbAlmacen.CheckedChanged
        If rbMotor.Checked Then
            btnBuscarMercaderia.Enabled = True
            btnBuscarAlmacen.Enabled = False
            txtalmacen.Text = ""

        ElseIf rbAlmacen.Checked Then
            btnBuscarAlmacen.Enabled = True
            btnBuscarMercaderia.Enabled = False
            txtMotor.Text = ""
            txtMotor.BackColor = System.Drawing.SystemColors.Control
        End If
    End Sub
    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm As New frmBuscarLocacionMercaderia
        frm.IdLocacion = IdLocacion_doc
        frm.CodRub = "04"
        frm.cmbCodRub.ReadOnly = True
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtMotor.Text = frm.codigo
            txtMotor.BackColor = System.Drawing.SystemColors.Window
        End If
        txtMotor.Select()
    End Sub

    Private Sub txtalmacen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtalmacen.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnBuscarMercaderia.Enabled = True Then
                btnBuscarMercaderia.Select()
                e.Handled = True
            End If
        End If
    End Sub

   
End Class
