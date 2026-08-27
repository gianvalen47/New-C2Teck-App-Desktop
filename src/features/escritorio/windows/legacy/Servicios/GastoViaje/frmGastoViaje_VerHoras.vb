Imports System.ServiceModel
Public Class frmGastoViaje_VerHoras

    Private oMarcacionJobService As New MarcacionJobService.MarcacionJobServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private Persona As New PersonaService.Persona

    Public dtDatos As DataTable
    Public CodJob As String
    Public IdPersona As Integer

    Private Sub frmGastoViaje_VerHoras_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMarcacionJobService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oMarcacionJobService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oMarcacionJobService.Abort()
            oPersonaService.Abort()
        End Try
    End Sub

    Private Sub frmGastoViaje_VerHoras_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmGastoViaje_VerHoras_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        listaDatos()
        lblNumJob.Text = CodJob
    End Sub

    Protected Sub listaDatos()
        Try
            dtDatos = oMarcacionJobService.MostrarHorasPorPersona(CodJob, IdPersona).Tables(0)
            dgvDatos.DataSource = dtDatos
            SumaColumna()
            Persona = oPersonaService.Obtener(IdPersona)
            lblApeNom.Text = Persona.ApeNom
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub SumaColumna()

        Try

            Dim total As Double = 0
            Dim totalViaje As Double = 0
            Dim total100 As Double = 0
            Dim total35 As Double = 0
            Dim total25 As Double = 0
            Dim totalNormal As Double = 0

            If dgvDatos.RowCount <> 0 Then

                For i As Integer = 0 To dgvDatos.RowCount - 1
                    If Not (IsDBNull(dgvDatos.Item("CostoUS".ToLower, i).Value)) Then
                        total = total + CDbl(dgvDatos.Item("CostoUS".ToLower, i).Value)
                    End If
                    If Not (IsDBNull(dgvDatos.Item("HoraViaje".ToLower, i).Value)) Then
                        totalViaje = totalViaje + CDbl(dgvDatos.Item("HoraViaje".ToLower, i).Value)
                    End If
                    If Not (IsDBNull(dgvDatos.Item("Hora100".ToLower, i).Value)) Then
                        total100 = total100 + CDbl(dgvDatos.Item("Hora100".ToLower, i).Value)
                    End If
                    If Not (IsDBNull(dgvDatos.Item("Hora35".ToLower, i).Value)) Then
                        total35 = total35 + CDbl(dgvDatos.Item("Hora35".ToLower, i).Value)
                    End If
                    If Not (IsDBNull(dgvDatos.Item("Hora25".ToLower, i).Value)) Then
                        total25 = total25 + CDbl(dgvDatos.Item("Hora25".ToLower, i).Value)
                    End If
                    If Not (IsDBNull(dgvDatos.Item("HoraNormal".ToLower, i).Value)) Then
                        totalNormal = totalNormal + CDbl(dgvDatos.Item("HoraNormal".ToLower, i).Value)
                    End If
                Next
                txtTotal.Value = total
                txtTotal100.Value = total100
                txtTotal35.Value = total35
                txtTotal25.Value = total25
                txtTotalViaje.Value = totalViaje
                txtTotalNormal.Value = totalNormal
            End If

        Catch ex As Exception
            MsgBox("ERROR AL SUMAR DATOS : " + ex.Message)
        End Try

    End Sub

    Private Sub biSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.Close()
    End Sub
End Class