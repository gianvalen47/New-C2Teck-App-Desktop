
Imports System.ServiceModel
Imports System.Windows.Forms

Public Class frmSolicitudesDetEstados

    Public Estado As String
    Public Fecha As String
    Public Hora As String
    Public Usuario As String
    Public Observacion As String

    Private Sub frmSolicitudesDetEstados_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub frmSolicitudesDetEstados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmSolicitudesDetEstados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtEstado.Text = Estado
        txtFecha.Text = Fecha
        txtHora.Text = Hora
        txtUsuario.Text = Usuario
        txtObservacion.Text = Observacion

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub
End Class