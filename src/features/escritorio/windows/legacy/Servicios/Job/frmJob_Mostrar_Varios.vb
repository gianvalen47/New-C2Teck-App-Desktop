Imports System.ServiceModel

Public Class frmJob_Mostrar_Varios

    Private oJobService As New JobService.JobServiceClient

    Private dtDatos As DataTable
    Public CodJob As String
    Public CodRubro As String
    Public Actualizar As Boolean

    Private Sub frmJob_Mostrar_Varios_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
        End Try
    End Sub

    Private Sub frmJob_Mostrar_Varios_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmJob_Mostrar_Varios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        listaDatos()
        lblNumJob.Text = CodJob

        lblRubro.Text = "Varios"

        If Session.CodPerfil = "24" Or Session.CodPerfil = "01" Then
            btnActRubro.Visible = True
        End If
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
                    If Not (IsDBNull(dgvDatos.Item("MontoDol1".ToLower, i).Value)) Then
                        If dgvDatos.Item("TipMov".ToLower, i).Value = "D" Then
                            total = total + CDbl(dgvDatos.Item("MontoDol1".ToLower, i).Value)
                        ElseIf dgvDatos.Item("TipMov".ToLower, i).Value = "H" Then
                            total = total - CDbl(dgvDatos.Item("MontoDol1".ToLower, i).Value)
                        End If
                    End If
                    If Not (IsDBNull(dgvDatos.Item("MontoSol1".ToLower, i).Value)) Then
                        'totalSol = totalSol + CDbl(dgvDatos.Item("MontoSol1".ToLower, i).Value)
                        If dgvDatos.Item("TipMov".ToLower, i).Value = "D" Then
                            totalSol = totalSol + CDbl(dgvDatos.Item("MontoSol1".ToLower, i).Value)
                        ElseIf dgvDatos.Item("TipMov".ToLower, i).Value = "H" Then
                            totalSol = totalSol - CDbl(dgvDatos.Item("MontoSol1".ToLower, i).Value)
                        End If

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

        'Try
        '    Dim total As Double = 0
        '    Dim totalprecio As Double = 0
        '    Dim totalSol As Double = 0

        '    If dgvDatos.RowCount <> 0 Then

        '        For i As Integer = 0 To dgvDatos.RowCount - 1
        '            If Not (IsDBNull(dgvDatos.Item("MontoDol1".ToLower, i).Value)) Then
        '                total = total + CDbl(dgvDatos.Item("MontoDol1".ToLower, i).Value)
        '            End If

        '            If Not (IsDBNull(dgvDatos.Item("MontoSol1".ToLower, i).Value)) Then
        '                totalSol = totalSol + CDbl(dgvDatos.Item("MontoSol1".ToLower, i).Value)
        '            End If
        '        Next

        '        MontoDol.Text = "Total Dólares :"
        '        txtMontoDol.Value = total
        '        MontoSol.Text = "Total Soles :"
        '        txtMontoSol.Value = totalSol
        '        PrecioDol.Visible = False
        '        txtPrecioDol.Visible = False
        '    End If
        'Catch ex As Exception
        '    MsgBox("ERROR AL SUMAR DATOS: " + ex.Message)
        'End Try

    End Sub

    Private Sub btnActRubro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActRubro.Click
        Try
            If dgvDatos.Rows.Count <= 1 Then
                MsgBox("¡No hay Registros, tenga cuidado...!")
            Else
                Dim frm As New frmJob_ActualizarRubro

                frm.CodJob = lblNumJob.Text
                frm.IdGastoReal = dgvDatos.CurrentRow.Cells("IdGastoReal").Value
                frm.NumDoc = dgvDatos.CurrentRow.Cells("NumDoc").Value
                frm.CodRubro = CodRubro
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    listaDatos()
                    'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Actualizar = True
                End If
            End If
            'listaDatos()
            'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MsgBox("Error  : " + ex.Message)
        End Try
    End Sub
End Class