Imports System.ServiceModel
Public Class frmJobConsulta_Mostrar_ManoObra
    Private oJobService As New JobService.JobServiceClient

    Private dtDatos As DataTable
    Public CodJob As String
    Public CodRubro As String
    Public CodMon As String

    Private Sub frmJobConsulta_Mostrar_ManoObra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()

        End Try
    End Sub

    Private Sub frmJobConsulta_Mostrar_ManoObra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmJobConsulta_Mostrar_ManoObra_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        listaDatos()
        lblNumJob.Text = CodJob
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oJobService.ConsultarGastos(CodJob, CodRubro, Session.sCodUsu).Tables(0)
            dgvDatos.DataSource = dtDatos
            SumaColumna()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.Close()
    End Sub

    Private Sub SumaColumna()

        Dim total As Double = 0
        Dim totalViaje As Double = 0
        Dim total100 As Double = 0
        Dim total35 As Double = 0
        Dim total25 As Double = 0
        Dim totalNormal As Double = 0

        If dgvDatos.RowCount <> 0 Then

            For i As Integer = 0 To dgvDatos.RowCount - 1
                total = total + CDbl(dgvDatos.Item("Costo".ToLower, i).Value)
                totalViaje = totalViaje + CDbl(dgvDatos.Item("HoraViaje".ToLower, i).Value)
                total100 = total100 + CDbl(dgvDatos.Item("Hora100".ToLower, i).Value)
                total35 = total35 + CDbl(dgvDatos.Item("Hora35".ToLower, i).Value)
                total25 = total25 + CDbl(dgvDatos.Item("Hora25".ToLower, i).Value)
                totalNormal = totalNormal + CDbl(dgvDatos.Item("HoraNormal".ToLower, i).Value)
            Next

            lblMontoTotal.Text = "Monto Total (" & CodMon & ")"

            txtTotal.Value = total
            txtTotal100.Value = total100
            txtTotal35.Value = total35
            txtTotal25.Value = total25
            txtTotalNormal.Value = totalNormal
        End If

    End Sub
End Class