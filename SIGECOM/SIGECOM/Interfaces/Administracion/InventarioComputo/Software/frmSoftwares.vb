Imports System.ServiceModel

Public Class frmSoftwares


    '=========================== Servicios ===================================================
    Private oComputadoraService As New ComputadoraService.ComputadoraServiceClient

    '======================Declaración de Variables==============================================

    Public state_Search As Boolean
    Private dtDatos As New DataTable
    Private dtTipoSoftware As DataTable

    Public IdSoftware As Integer

    Private Sub frmSoftwares_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        llenarCombos()

        state_Search = True
        listaDatos()
        dgvDatos.Select()
    End Sub

    Private Sub frmSoftwares_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmSoftwares_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oComputadoraService.Close()
        Catch ex As TimeoutException
            oComputadoraService.Abort()
        Catch ex As CommunicationException
            oComputadoraService.Abort()
        End Try
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= TIPO SOFTWARE ================================================
            dtTipoSoftware = oComputadoraService.MostrarTipoSoftware().Tables(0)
            dtTipoSoftware.Rows.InsertAt(getRowTodos(dtTipoSoftware), 0)
            cmbTipoSoftware.DataSource = dtTipoSoftware
            cmbTipoSoftware.DropDownList.DataMember = dtTipoSoftware.Columns("DesTipoSoftware").ToString
            cmbTipoSoftware.DropDownList.DisplayMember = dtTipoSoftware.Columns("DesTipoSoftware").ToString
            cmbTipoSoftware.DropDownList.ValueMember = dtTipoSoftware.Columns("IdTipoSoftware").ToString
            cmbTipoSoftware.DropDownList.Columns(0).DataMember = dtTipoSoftware.Columns("IdTipoSoftware").ToString
            cmbTipoSoftware.DropDownList.Columns(1).DataMember = dtTipoSoftware.Columns("DesTipoSoftware").ToString
            cmbTipoSoftware.SelectedIndex = 0
            dtTipoSoftware = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(3) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Todos)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click, txtNomAplicacion.TextChanged, cmbTipoSoftware.ValueChanged, cbLicenciaAplica.CheckedChanged, cbVigente.CheckedChanged
        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oComputadoraService.FiltrarSoftware(toNumber(cmbTipoSoftware.Value), toBlank(txtNomAplicacion.Text), cbLicenciaAplica.Checked, cbVigente.Checked).Tables(0)
                'dtDatos = oComputadoraService.FiltrarSoftware(0, "", True, True).Tables(0)
                'DataGridView1.DataSource = dtDatos
                dgvDatos.DataSource = dtDatos
                sslTotal.Text = "Registros: " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        Try
            If dgvDatos.RowCount < 1 Then
                biImprimir.Enabled = False
                biMostrar.Enabled = False
                biEliminar.Enabled = False

                'miImprimir.Enabled = False
                miMostrar.Enabled = False
                miEliminar.Enabled = False
            Else
                biImprimir.Enabled = True
                biMostrar.Enabled = True
                biEliminar.Enabled = True

                'miImprimir.Enabled = True
                miMostrar.Enabled = True
                miEliminar.Enabled = True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub dgvDatos_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                e.Handled = True
                biMostrar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub dgvDatos_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub biNuevo_Click(sender As Object, e As EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub

    Private Sub Nuevo()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmSoftware
                frm.state_button = False

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdSoftware)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR EL SOFTWARE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biMostrar_Click(sender As Object, e As EventArgs) Handles biMostrar.Click, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmSoftware
            frm.state_button = True
            frm.IdSoftware = dgvDatos.CurrentRow.Cells("IdSoftware").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdSoftware)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdSoftware)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL SOFTWARE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEliminar_Click(sender As Object, e As EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Sub eliminar()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oComputadoraService.BorrarSoftware(dgvDatos.CurrentRow.Cells("IdSoftware").Value)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL SOFTWARE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biActualizar_Click(sender As Object, e As EventArgs) Handles biActualizar.Click, miActualizar.Click
        Actualizar()
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdSoftware").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdSoftware").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub


End Class