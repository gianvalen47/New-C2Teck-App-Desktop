Imports System.ServiceModel
Public Class frmListaOfertaNuevo_Estados

    Private oListaOfertaCabService As New ListaOfertaCabService.ListaOfertaCabServiceClient

    '======================Declaración de Variables==============================   
    Public IdOferta As Integer
    Private dtDatos As DataTable

    Private Sub frmListaOfertaNuevo_Estados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        Me.Size = New System.Drawing.Size(741, 235)
        listaDatos()
    End Sub

    Private Sub frmListaOfertaNuevo_Estados_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmListaOfertaNuevo_Estados_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oListaOfertaCabService.Close()
        Catch ex As TimeoutException
            oListaOfertaCabService.Abort()
        Catch ex As CommunicationException
            oListaOfertaCabService.Abort()
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oListaOfertaCabService.ConsultarEstados(IdOferta).Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class