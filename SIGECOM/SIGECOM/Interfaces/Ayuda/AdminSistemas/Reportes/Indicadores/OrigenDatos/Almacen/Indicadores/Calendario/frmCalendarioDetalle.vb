Imports System.ServiceModel

Public Class frmCalendarioDetalle

    Private oIndicadoresAlmacenService As New IndicadoresAlmacenService.IndicadoresAlmacenServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    Private dtDatos As DataTable
    Private dtRubros As DataTable
    Public IdProceso As Integer
    Public IdLocacion As Integer

    Private Sub frmCalendarioDetalle_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oIndicadoresAlmacenService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oIndicadoresAlmacenService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oIndicadoresAlmacenService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmCalendarioDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmCalendarioDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        listaDatos()
    End Sub

    Private Sub txtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecha.ValueChanged
        listaDatos()
    End Sub

    Private Sub cmbRubro_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRubro.ValueChanged
        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oIndicadoresAlmacenService.MostrarDetalleCalendario(IdProceso, txtFecha.Value, cmbRubro.Value).Tables(0)
            dgvDatos.DataSource = dtDatos

            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            ActualizarPorcEval()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub llenarCombos()
        '======================================= RUBROS ================================================
        dtRubros = oIndicadoresAlmacenService.MostrarRubros.Tables(0)
        'dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
        cmbRubro.DataSource = dtRubros
        cmbRubro.DropDownList.DataMember = dtRubros.Columns("DesRub").ToString
        cmbRubro.DropDownList.DisplayMember = dtRubros.Columns("DesRub").ToString
        cmbRubro.DropDownList.ValueMember = dtRubros.Columns("CodRub").ToString
        cmbRubro.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRub").ToString
        cmbRubro.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRub").ToString
        cmbRubro.SelectedIndex = 0
        dtRubros = Nothing
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Try
            Dim frm As New frmCalendarioDetalle_Actualizar
            If dgvDatos.RowCount > 0 Then
                frm.IdProcesoAct = IdProceso
                frm.IdLocacionAct = IdLocacion
                frm.CodMer = dgvDatos.CurrentRow.Cells("CodMer").Text
                frm.Fecha = txtFecha.Text
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    listaDatos()
                    RowPossesion(dgvDatos, frm.CodMer)
                End If
            Else
                MsgBox("No existen datos, Verifique...")
            End If
        Catch ex As Exception
            MsgBox("Error al mostrar los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        biActualizar_Click(sender, e)
        dgvDatos.Select()
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If dgvDatos.RowCount > 0 Then
                    biActualizar_Click(sender, e)
                    e.Handled = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        Dim frm As New frmCalendario_Imprimir
        frm.IdProcesoImp = IdProceso
        frm.Fecha = txtFecha.Text
        frm.CodRubro = cmbRubro.Value
        frm.DesRubro = cmbRubro.Text
        frm.dtCalendarioActual = dtDatos
        frm.ShowDialog()
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("CodMer").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub ActualizarPorcEval()

        Dim row As Janus.Windows.GridEX.GridEXRow
        Dim Contador As Integer
        Dim Porcentaje As Integer

        If dgvDatos.RowCount <> 0 Then

            For i As Integer = 0 To dgvDatos.RowCount - 1
                Me.dgvDatos.Row = i
                row = Me.dgvDatos.GetRow()

                If row.Cells("Evaluacion").Text = "0" Then
                    'If dgvDatos.Rows(i).Cells("Evaluacion").Text = 0 Then
                    Contador = Contador + 1
                End If
            Next
            Porcentaje = Math.Round((Contador / dgvDatos.RowCount), 2) * 100
            lblEvaluacion.Text = Porcentaje & " %"

        End If
    End Sub

    Private Sub biCopiarABC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCopiarABC.Click

        Dim frm As New frmCalendario_Copiar
        frm.IdProceso = IdProceso

        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            listaDatos()
        End If

    End Sub
End Class

