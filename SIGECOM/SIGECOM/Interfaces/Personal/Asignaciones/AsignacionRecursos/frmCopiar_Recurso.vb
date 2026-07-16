Imports System.ServiceModel
Public Class frmCopiar_Recurso

    '=========================== Servicios ====================================
    Private oRecursoService As New RecursoService.RecursoServiceClient

    '====================== Declaración de Variables ==============================
    Public IdRecurso As Integer


    Private Sub frmCopiar_Recurso_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                   txtFecha.KeyPress, _
                   txtNumDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmCopiar_Recurso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmCopiar_Recurso_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtNumDoc.Focus()
        txtFecha.Value = Today

        Me.Text = "Copiar recurso seleccionado"
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oRecursoService.Close()
        Catch ex As TimeoutException
            oRecursoService.Abort()
        Catch ex As CommunicationException
            oRecursoService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If IdRecurso = 0 Then
                MsgBox("El número de recurso a copiar es invalido.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(txtNumDoc.Text) = "" Then
                MsgBox("Debe Ingresar el número de documento.", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf toBlank(txtFecha.Value) = "" Then
                MsgBox("Debe Ingresar la fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False            
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de COPIAR el recurso seleccionado?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    Dim state_process As Integer
                    state_process = oRecursoService.Copiar(IdRecurso, txtNumDoc.Text, txtFecha.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If state_process > 0 Then
                        IdRecurso = state_process
                        MsgBox("Se generó el recurso: " + txtNumDoc.Text + " correctamente.")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Copiar Recurso: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class