Imports System.ServiceModel

Public Class frmJobConsulta_MostrasGasto

    Private oJobService As New JobService.JobServiceClient

    Private dtDatos As DataTable
    Public CodJob As String
    Public CodRubro As String

    Private Sub frmJobConsulta_MostrasGasto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
        End Try
    End Sub

    Private Sub frmJobConsulta_MostrasGasto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmJobConsulta_MostrasGasto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        listaDatos()
        lblNumJob.Text = CodJob
        If CodRubro = "1" Then
            lblRubro.Text = "Mano de Obra"
            'btnActHoraViaje.Visible = True
        ElseIf CodRubro = "2" Then
            lblRubro.Text = "Terceros"
            'btnActHoraViaje.Visible = False
        ElseIf CodRubro = "3" Then
            lblRubro.Text = "Gastos de Viaje"
            'btnActHoraViaje.Visible = False
        ElseIf CodRubro = "4" Then
            lblRubro.Text = "Materiales"
            'btnActHoraViaje.Visible = False
        ElseIf CodRubro = "5" Then
            lblRubro.Text = "Varios"
            'btnActHoraViaje.Visible = False
        ElseIf CodRubro = "6" Then
            lblRubro.Text = "Repuestos"
            'btnActHoraViaje.Visible = False
        ElseIf CodRubro = "7" Then
            lblRubro.Text = "Refrig. y Movild."
            'btnActHoraViaje.Visible = False
        End If

    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oJobService.ConsultarGastos(CodJob, CodRubro, Session.sCodUsu).Tables(0)
            '            dgvDatos.DataSource = dtDatos
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


    Private Sub SumaColumna()
        Try
            Dim total As Double = 0
            Dim totalSol As Double = 0
            Dim totalprecio As Double = 0

            If CodRubro = "6" Then

                If dgvDatos.RowCount <> 0 Then

                    For i As Integer = 0 To dgvDatos.RowCount - 1

                        If Not (IsDBNull(dgvDatos.Item("CostoUS".ToLower, i).Value)) Then
                            total = total + CDbl(dgvDatos.Item("CostoUS".ToLower, i).Value)
                        End If
                        If Not (IsDBNull(dgvDatos.Item("PrecioUS".ToLower, i).Value)) Then
                            totalprecio = totalprecio + CDbl(dgvDatos.Item("PrecioUS".ToLower, i).Value)
                        End If

                    Next

                    MontoDol.Text = "Total Costos USD "
                    PrecioDol.Text = "Total Precio Venta USD "
                    txtMontoDol.Value = total
                    txtPrecioDol.Value = totalprecio
                    txtMontoSol.Visible = False
                    MontoSol.Visible = False
                End If

            ElseIf CodRubro = "4" Then

                If dgvDatos.RowCount <> 0 Then

                    For i As Integer = 0 To dgvDatos.RowCount - 1

                        If Not (IsDBNull(dgvDatos.Item("CostoUS".ToLower, i).Value)) Then
                            total = total + CDbl(dgvDatos.Item("CostoUS".ToLower, i).Value)
                        End If

                    Next

                    MontoDol.Text = "Total Dólares :"

                    txtMontoDol.Value = total
                    txtMontoSol.Visible = False
                    MontoSol.Visible = False
                    PrecioDol.Visible = False
                    txtPrecioDol.Visible = False

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

                    MontoDol.Text = "Total Dólares :"
                    txtMontoDol.Value = total
                    MontoSol.Text = "Total Soles :"
                    txtMontoSol.Value = totalSol
                    PrecioDol.Visible = False
                    txtPrecioDol.Visible = False
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL SUMAR DATOS : " + ex.Message)
        End Try

       

    End Sub

End Class