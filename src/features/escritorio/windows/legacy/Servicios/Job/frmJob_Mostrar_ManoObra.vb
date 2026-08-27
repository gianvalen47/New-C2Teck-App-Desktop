Imports System.ServiceModel
Public Class frmJob_Mostrar_ManoObra

    Private oJobService As New JobService.JobServiceClient
    Private oMarcacionService As New MarcacionJobService.MarcacionJobServiceClient

    Private dtDatos As DataTable
    Public CodJob As String
    Public CodRubro As String
    Public CodMon As String

    Private Sub frmJob_Mostrar_ManoObra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
            oMarcacionService.Close()

        Catch ex As TimeoutException
            oJobService.Abort()
            oMarcacionService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
            oMarcacionService.Abort()
        End Try
    End Sub

    Private Sub frmJob_Mostrar_ManoObra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmJob_Mostrar_ManoObra_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

    Private Sub btnActHoraViaje_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnActHoraViaje.Click
        Try
            Dim frm As New frmJob_HoraViaje

            frm.CodJob = lblNumJob.Text
            frm.ShowDialog()

            listaDatos()
        Catch ex As Exception
            MsgBox("Error  : " + ex.Message)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.Close()
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
                    If Not (IsDBNull(dgvDatos.Item("Costo".ToLower, i).Value)) Then
                        total = total + CDbl(dgvDatos.Item("Costo".ToLower, i).Value)
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

                lblMontoTotal.Text = "Monto Total (" & CodMon & ")"

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

    Private Sub btnElimHoraViaje_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnElimHoraViaje.Click
       
        If MsgBox("¿Está seguro de ELIMINAR la hora de viaje seleccionada?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            EliminarHoraViaje()
        End If

    End Sub

    Sub EliminarHoraViaje()
        Try
            If dgvDatos.RowCount <> 0 Then
                If oMarcacionService.BorrarHoraViaje(CDate(dgvDatos.Item("Fecha".ToLower, dgvDatos.CurrentRow.Index).Value), lblNumJob.Text, CInt(dgvDatos.Item("IdPer".ToLower, dgvDatos.CurrentRow.Index).Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp) Then
                    MsgBox("Hora de Viaje Eliminado")
                    listaDatos()
                Else
                    MsgBox("Error en el proceso, comunicarse con el área de sistemas")
                End If
            Else
                MsgBox("No hay Datos ....")
            End If
        Catch ex As Exception
            MsgBox("Error al Eliminar Hora de Viaje  " + ex.Message)
        End Try
    End Sub
End Class