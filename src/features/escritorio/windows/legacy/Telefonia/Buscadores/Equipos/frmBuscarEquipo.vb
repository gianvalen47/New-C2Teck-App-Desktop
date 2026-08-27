Imports System.ServiceModel
Public Class frmBuscarEquipo

    '=========================== Servicios ===================================================
    Private oLineasService As New LineasService.LineasServiceClient

    '======================Declaración de Variables==============================================
    Public state_Search As Boolean
    Private dtDatos As New DataTable
    Private dtMarca As New DataTable
    Private dtModelo As New DataTable
    Public IdMarca As Integer
    Public IdEquipo As Integer

    Public codigo As String
    Public descripcion As String

    Private Sub frmBuscarEquipo_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oLineasService.Close()
        Catch ex As TimeoutException
            oLineasService.Abort()
        Catch ex As CommunicationException
            oLineasService.Abort()
        End Try
    End Sub

    Private Sub frmBuscarEquipo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmBuscarEquipo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGrid_Bucadores(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        state_Search = False
        llenarCombos()
        state_Search = True
        listaDatos()
    End Sub

    Private Sub llenarCombos()

        Try
            '======================================= MARCA ================================================
            dtMarca = oLineasService.MostrarMarcas().Tables(0)
            'DataGridView1.DataSource = dtMarca
            'If dtMarca.Rows.Count > 1 Then
            dtMarca.Rows.InsertAt(getRowTodos(dtMarca), 0)
            'End If
            'dtMarca.Rows.InsertAt(getRowTodos(dtMarca), 0)
            cmbMarca.DataSource = dtMarca
            cmbMarca.DropDownList.DataMember = dtMarca.Columns("DesMarca").ToString
            cmbMarca.DropDownList.DisplayMember = dtMarca.Columns("DesMarca").ToString
            cmbMarca.DropDownList.ValueMember = dtMarca.Columns("IdMarca").ToString
            cmbMarca.DropDownList.Columns(0).DataMember = dtMarca.Columns("IdMarca").ToString
            cmbMarca.DropDownList.Columns(1).DataMember = dtMarca.Columns("DesMarca").ToString
            cmbMarca.SelectedIndex = 0
            dtMarca = Nothing

            '======================================= MODELO ================================================
            'dtModelo = oLineasService.MostrarModelos().Tables(0)
            'dtModelo.Rows.InsertAt(getRowTodos(dtModelo), 0)
            'cmbModelo.DataSource = dtModelo
            'cmbModelo.DropDownList.DataMember = dtModelo.Columns("DesModelo").ToString
            'cmbModelo.DropDownList.DisplayMember = dtModelo.Columns("DesModelo").ToString
            'cmbModelo.DropDownList.ValueMember = dtModelo.Columns("IdModelo").ToString
            'cmbModelo.DropDownList.Columns(0).DataMember = dtModelo.Columns("IdModelo").ToString
            'cmbModelo.DropDownList.Columns(1).DataMember = dtModelo.Columns("DesModelo").ToString
            'cmbModelo.SelectedIndex = 0
            'dtModelo = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = 0 '""
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

    Private Sub listaDatos()
        Try
            If state_Search = True Then

                dtDatos = oLineasService.FiltrarEquipo(toNumber(cmbMarca.Value), toNumber(cmbModelo.Value), toBlank(txtNumSerie.Text), toBlank(txtDesEquipo.Text)).Tables(0)
                dgvDatos.SetDataBinding(dtDatos, 0)

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [BUSC-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub

    Private Sub Seleccionar()
        Try
            codigo = dgvDatos.CurrentRow.Cells("IdEquipo").Text
            descripcion = dgvDatos.CurrentRow.Cells("DesEquipo").Text


            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox("ERROR [BUSC-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miSeleccionar.Enabled = False
        Else
            miSeleccionar.Enabled = True
        End If
    End Sub

    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                   txtDesEquipo.KeyPress _
              , dgvDatos.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells("IdEquipo").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [BUSC-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub dgvDatos_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            dgvDatos_DoubleClick(sender, e)
        End If
    End Sub

    Private Sub cmbMarca_ValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbMarca.ValueChanged
        dtModelo = oLineasService.MostrarModelos(toNumber(cmbMarca.Value)).Tables(0)
        If dtModelo.Rows.Count > 1 Or cmbMarca.Value = 0 Then
            dtModelo.Rows.InsertAt(getRowTodos(dtModelo), 0)
        End If
        cmbModelo.DataSource = dtModelo
        cmbModelo.DropDownList.DataMember = dtModelo.Columns("IdModelo").ToString
        cmbModelo.DropDownList.DisplayMember = dtModelo.Columns("DesModelo").ToString
        cmbModelo.DropDownList.ValueMember = dtModelo.Columns("IdModelo").ToString
        cmbModelo.DropDownList.Columns(0).DataMember = dtModelo.Columns("IdModelo").ToString
        cmbModelo.DropDownList.Columns(1).DataMember = dtModelo.Columns("DesModelo").ToString
        If dtModelo.Rows.Count = 0 Then
            cmbModelo.SelectedIndex = 0
        End If
        listaDatos()
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click, cmbMarca.ValueChanged, cmbModelo.ValueChanged, txtDesEquipo.TextChanged, txtNumSerie.TextChanged
        listaDatos()
    End Sub
End Class