Imports System.ServiceModel
Public Class frmSeguimiento_Personal

    '====================== Declaración de Variables =============================================
    Public IdPer As Integer
    Public ApeNom As String
    Public DesCargo As String

    Private Sub frmSeguimiento_Personal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtColaborador.Text = ApeNom
        txtCargo.Text = DesCargo
    End Sub

    Private Sub frmHoraMotor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
End Class