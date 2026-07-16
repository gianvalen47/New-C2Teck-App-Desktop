Imports System.ServiceModel

Public Class frmEmbarque_Estados

    '=========================== Servicios ====================================
    Private oEmbarqueService As New EmbarqueService.EmbarqueServiceClient

    Public CodEmbarque As String
    Private dtDatos As DataTable

    Private Sub frmEmbarque_Estados_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oEmbarqueService.Close()
        Catch ex As TimeoutException
            oEmbarqueService.Abort()
        Catch ex As CommunicationException
            oEmbarqueService.Abort()
        End Try
    End Sub

    Private Sub frmEmbarque_Estados_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmEmbarque_Estados_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        listaDatos()

    End Sub

    Private Sub listaDatos()

        Try
            dtDatos = oEmbarqueService.ConsultarEstados(CodEmbarque).Tables(0)
            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox("ERROR AL VER LOS ESTADOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

End Class