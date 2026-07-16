Imports System.ServiceModel
Public Class frmComSolicitudGasto_Compras

    '===========================Servicios====================================
    Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient

    '======================Declaración de Variables==============================   
    Public CodJob As String
    Private dtDatos As DataTable

    Private Sub frmComSolicitudGasto_Compras_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        ListaDatos()
        Me.Text = "Compras de OT : " + CodJob
        txtNumJob.Text = CodJob
        dgvDatos.Select()
    End Sub

    Private Sub ListaDatos()
        Try
            dtDatos = oSolicitudGastoDetService.MostrarCompraJob(CodJob).Tables(0)
            dgvDatos.DataSource = dtDatos
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            Sumar()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Sumar()
        If dgvDatos.RowCount > 0 Then
            Try
                Dim totalSoles As Double = 0
                Dim totalDolares As Double = 0
                Dim row As Janus.Windows.GridEX.GridEXRow
                Dim bSelected As Boolean
                Dim CodMon As String
                For i = 0 To Me.dgvDatos.RowCount - 1
                    Me.dgvDatos.Row = i
                    row = Me.dgvDatos.GetRow()
                    bSelected = row.Cells("TotalFila").Value
                    CodMon = row.Cells("CodMon").Value
                    If CodMon = "NS" Then
                        If bSelected Then
                            totalSoles = totalSoles + CDbl(Me.dgvDatos.CurrentRow.Cells("TotalFila").Value)
                        End If
                    Else
                        If bSelected Then
                            totalDolares = totalDolares + CDbl(Me.dgvDatos.CurrentRow.Cells("TotalFila").Value)
                        End If
                    End If
                Next
                txtTotalDolares.Value = totalDolares
                txtTotalSoles.Value = totalSoles
            Catch ex As Exception
                MsgBox("Error al sumar Montos" + ex.Message)
            End Try
        End If
    End Sub

    Private Sub frmComSolicitudGastoDet_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmComSolicitudGastoDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oSolicitudGastoDetService.Close()
        Catch ex As TimeoutException
            oSolicitudGastoDetService.Abort()
        Catch ex As CommunicationException
            oSolicitudGastoDetService.Abort()
        End Try
    End Sub
End Class