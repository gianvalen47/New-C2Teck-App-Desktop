Imports System.ServiceModel

Public Class FrmJob_MostrasGasto

    Private oJobService As New JobService.JobServiceClient

    Private dtDatos As DataTable
    Public CodJob As String
    Public CodRubro As String

    Private Sub FrmJob_MostrasGasto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()

        End Try
    End Sub

    Private Sub FrmJob_MostrasGasto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub


    Private Sub FrmJob_MostrasGasto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        listaDatos()
        lblNumJob.Text = CodJob

        If CodRubro = "2" Then
            lblRubro.Text = "Terceros"
        ElseIf CodRubro = "3" Then
            lblRubro.Text = "Gastos de Viaje"
        ElseIf CodRubro = "4" Then
            lblRubro.Text = "Materiales"
        ElseIf CodRubro = "5" Then
            lblRubro.Text = "Varios"
        ElseIf CodRubro = "6" Then
            lblRubro.Text = "Repuestos"
        ElseIf CodRubro = "7" Then
            lblRubro.Text = "Refrig. y Movild."
        End If

    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oJobService.ConsultarGastos(CodJob, CodRubro).Tables(0)
            dgvDatos.DataSource = dtDatos
            SumaColumna()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.Close()
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click
        listaDatos()
    End Sub

    Private Sub SumaColumna()
        Try
            Dim total As Double = 0
            Dim totalSol As Double = 0

            If CodRubro = "6" Or CodRubro = "4" Then

                If dgvDatos.RowCount <> 0 Then

                    For i As Integer = 0 To dgvDatos.RowCount - 1

                        If Not (IsDBNull(dgvDatos.Item("CostoUS".ToLower, i).Value)) Then
                            total = total + CDbl(dgvDatos.Item("CostoUS".ToLower, i).Value)
                        End If
                    Next

                    MontoDol.Text = "Total Dolares :"
                    txtMontoDol.Value = total
                    txtMontoSol.Visible = False
                    MontoSol.Visible = False
                End If

            ElseIf CodRubro = "2" Or CodRubro = "3" Or CodRubro = "5" Or CodRubro = "7" Then

                If dgvDatos.RowCount <> 0 Then

                    For i As Integer = 0 To dgvDatos.RowCount - 1
                        If Not (IsDBNull(dgvDatos.Item("MontoDol".ToLower, i).Value)) Then
                            total = total + CDbl(dgvDatos.Item("MontoDol".ToLower, i).Value)
                        End If

                        If Not (IsDBNull(dgvDatos.Item("MontoSol".ToLower, i).Value)) Then
                            totalSol = totalSol + CDbl(dgvDatos.Item("MontoSol".ToLower, i).Value)
                        End If
                    Next

                    MontoDol.Text = "Total Dolares :"
                    txtMontoDol.Value = total
                    MontoSol.Text = "Total Soles :"
                    txtMontoSol.Value = totalSol
                End If
            End If


        Catch ex As Exception
            MsgBox("ERROR AL SUMAR DATOS: " + ex.Message)
        End Try

            End Sub

End Class
