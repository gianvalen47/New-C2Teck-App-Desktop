Imports System.ServiceModel

Public Class frmJob_Mostrar_GastosViaje

    Private oJobService As New JobService.JobServiceClient

    Private dtDatos As DataTable
    Public CodJob As String
    Public CodRubro As String

    Private Sub frmJob_Mostrar_GastosViaje_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
        End Try
    End Sub

    Private Sub frmJob_Mostrar_GastosViaje_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmJob_Mostrar_GastosViaje_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        listaDatos()
        lblNumJob.Text = CodJob

        lblRubro.Text = "Gastos de Viaje"

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
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click
        listaDatos()
    End Sub

    Private Sub SumaColumna()
        Try
            Dim total As Double = 0
            Dim totalprecio As Double = 0
            Dim totalSol As Double = 0

            If dgvDatos.RowCount <> 0 Then

                For i As Integer = 0 To dgvDatos.RowCount - 1
                    If Not (IsDBNull(dgvDatos.Item("MontoDol2".ToLower, i).Value)) Then
                        total = total + CDbl(dgvDatos.Item("MontoDol2".ToLower, i).Value)
                    End If

                    If Not (IsDBNull(dgvDatos.Item("MontoSol2".ToLower, i).Value)) Then
                        totalSol = totalSol + CDbl(dgvDatos.Item("MontoSol2".ToLower, i).Value)
                    End If
                Next

                MontoDol.Text = "Total Dólares :"
                txtMontoDol.Value = total
                MontoSol.Text = "Total Soles :"
                txtMontoSol.Value = totalSol
                PrecioDol.Visible = False
                txtPrecioDol.Visible = False
            End If

        Catch ex As Exception
            MsgBox("ERROR AL SUMAR DATOS: " + ex.Message)
        End Try
    End Sub

End Class