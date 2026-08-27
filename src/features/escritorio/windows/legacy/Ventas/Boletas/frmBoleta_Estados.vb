Imports System.ServiceModel
Public Class frmBoleta_Estados

    Private oBoletaService As New BoletaService.BoletaServiceClient

    Public IdBoleta As Integer
    Public NumDoc As String
    Private dtDatos As DataTable

    Private Sub frmBoleta_Estados_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            oBoletaService.Close()
        Catch ex As TimeoutException
            oBoletaService.Abort()
        Catch ex As CommunicationException
            oBoletaService.Abort()
        End Try
    End Sub

    Private Sub frmBoleta_Estados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub frmBoleta_Estados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim estilo As New Estilo
            estilo.cargaEstiloGridExt(dgvDatos)
            dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
            listaDatos()
            Me.Text = "Estados de la Boleta N°:" & NumDoc
        Catch ex As Exception
            MsgBox("Error en el load : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oBoletaService.ConsultarEstados(IdBoleta).Tables(0)
            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox("Error al listar los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Delete Then
            listaDatos()
        End If
    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        'If Not (Char.IsDigit(e.KeyChar)) Then
        '    e.Handled = True
        'End If
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub
End Class