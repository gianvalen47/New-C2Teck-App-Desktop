Public Class frmGuiaDevolucion_Estados

    Private oGuiaDevolucionService As New GuiaDevolucionService.GuiaDevolucionServiceClient
    Private dtDatos As DataTable
    Public IdGuiaDev As Integer
    Public NumDoc As String

    Private Sub frmGuiaDevolucion_Estados_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oGuiaDevolucionService) = False Then
                oGuiaDevolucionService.Close()
            End If

        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmGuiaDevolucion_Estados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub frmGuiaDevolucion_Estados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        Me.Text = "Estados de la Guía de Devolución N°: " & NumDoc
        listaDatos()

    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oGuiaDevolucionService.ConsultarEstados(IdGuiaDev).Tables(0)
            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox("ERROR [LISTAR: " + ex.Message, MsgBoxStyle.Exclamation)
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