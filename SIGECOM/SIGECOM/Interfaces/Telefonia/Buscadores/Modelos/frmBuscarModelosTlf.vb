Imports System.ServiceModel
Public Class frmBuscarModelosTlf

    '=========================== Servicios ===================================================
    Private oLineasService As New LineasService.LineasServiceClient

    '======================Declaración de Variables==============================================
    Public state_Search As Boolean
    Private dtDatos As New DataTable
    Private dtMarca As New DataTable
    Public IdModelo As Integer
    Public IdMarca As Integer

    Public codigo As String
    Public descripcion As String

    Private Sub frmBuscarModelosTellef_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oLineasService.Close()
        Catch ex As TimeoutException
            oLineasService.Abort()
        Catch ex As CommunicationException
            oLineasService.Abort()
        End Try
    End Sub

    Private Sub frmBuscarModelosTellef_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmBuscarModelosTellef_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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
            dtMarca.Rows.InsertAt(getRowTodos(dtMarca), 0)
            cmbMarca.DataSource = dtMarca
            cmbMarca.DropDownList.DataMember = dtMarca.Columns("DesMarca").ToString
            cmbMarca.DropDownList.DisplayMember = dtMarca.Columns("DesMarca").ToString
            cmbMarca.DropDownList.ValueMember = dtMarca.Columns("IdMarca").ToString
            cmbMarca.DropDownList.Columns(0).DataMember = dtMarca.Columns("IdMarca").ToString
            cmbMarca.DropDownList.Columns(1).DataMember = dtMarca.Columns("DesMarca").ToString
            cmbMarca.SelectedIndex = 0
            dtMarca = Nothing

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

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click, cmbMarca.ValueChanged, txtDesModelo.TextChanged
        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oLineasService.FiltrarModelo(toNumber(cmbMarca.Value), toBlank(txtDesModelo.Text)).Tables(0)
                'DataGridView1.DataSource = dtDatos
                dgvDatos.DataSource = dtDatos
                sslTotal.Text = "Registros: " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
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

    Private Sub Seleccionar()
        Try
            codigo = dgvDatos.CurrentRow.Cells("IdModelo").Text
            descripcion = dgvDatos.CurrentRow.Cells("DesModelo").Text


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
                 cmbMarca.KeyPress _
              , btnBuscar.KeyPress _
 _
              , dgvDatos.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            dgvDatos_DoubleClick(sender, e)
        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
        Try
            tabla.DefaultView.Sort = nombreCampo
            lista.FirstRow = dtDatos.DefaultView.Find(codigo)
            lista.Row = dtDatos.DefaultView.Find(codigo)
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub miSeleccionar_Click(sender As System.Object, e As System.EventArgs) Handles miSeleccionar.Click
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub



End Class