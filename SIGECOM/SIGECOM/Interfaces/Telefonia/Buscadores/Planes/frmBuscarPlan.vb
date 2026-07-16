Imports System.ServiceModel

Public Class frmBuscarPlan

    Private oLineasService As New LineasService.LineasServiceClient

    Private dtDatos As DataTable
    Private state_Search As Boolean

    Private dtOperadores As DataTable
    Private dtTipoServicio As DataTable

    Public codigo As String
    Public descripcion As String

    Private Sub frmBuscarPlan_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oLineasService.Close()
        Catch ex As TimeoutException
            oLineasService.Abort()
        Catch ex As CommunicationException
            oLineasService.Abort()
        End Try
    End Sub

    Private Sub frmBuscarPlan_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub



    Private Sub frmBuscarPlan_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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

            '======================================= OPERADORES ================================================
            dtOperadores = oLineasService.MostrarOperadores().Tables(0)
            dtOperadores.Rows.InsertAt(getRowTodos(dtOperadores), 0)
            cmbOperador.DataSource = dtOperadores
            cmbOperador.DropDownList.DataMember = dtOperadores.Columns("DesOperador").ToString
            cmbOperador.DropDownList.DisplayMember = dtOperadores.Columns("DesOperador").ToString
            cmbOperador.DropDownList.ValueMember = dtOperadores.Columns("IdOperador").ToString
            cmbOperador.DropDownList.Columns(0).DataMember = dtOperadores.Columns("IdOperador").ToString
            cmbOperador.DropDownList.Columns(1).DataMember = dtOperadores.Columns("DesOperador").ToString
            cmbOperador.SelectedIndex = 0
            dtOperadores = Nothing

            '======================================= TIPO SERVICIO ================================================
            dtTipoServicio = oLineasService.MostrarTipoServicio().Tables(0)
            dtTipoServicio.Rows.InsertAt(getRowTodos(dtTipoServicio), 0)
            cmbTipoServicio.DataSource = dtTipoServicio
            cmbTipoServicio.DropDownList.DataMember = dtTipoServicio.Columns("DesTipo").ToString
            cmbTipoServicio.DropDownList.DisplayMember = dtTipoServicio.Columns("DesTipo").ToString
            cmbTipoServicio.DropDownList.ValueMember = dtTipoServicio.Columns("IdTipo").ToString
            cmbTipoServicio.DropDownList.Columns(0).DataMember = dtTipoServicio.Columns("IdTipo").ToString
            cmbTipoServicio.DropDownList.Columns(1).DataMember = dtTipoServicio.Columns("DesTipo").ToString
            cmbTipoServicio.SelectedIndex = 0
            dtTipoServicio = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub dgvDatos_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                'Dim registro As New ClienteService.Cliente
                'registro.IdCliente = toNumber(txtIdCliente.Text)
                'registro.DesCli = toBlank(txtDesCli.Text)
                'registro.RucCli = toBlank(txtRucCli.Text)
                'registro.DniCli = toBlank(txtDniCli.Text)

                dtDatos = oLineasService.FiltrarPlan(toNumber(cmbOperador.Value), toNumber(cmbTipoServicio.Value), toBlank(txtDesPlan.Text)).Tables(0)
                dgvDatos.SetDataBinding(dtDatos, 0)

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [BUSC-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Seleccionar()
        Try
            codigo = dgvDatos.CurrentRow.Cells("IdPlan").Text
            descripcion = dgvDatos.CurrentRow.Cells("DesPlan").Text


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
                     cmbOperador.KeyPress _
                  , cmbTipoServicio.KeyPress _
                  , btnBuscar.KeyPress _
                  , txtDesPlan.KeyPress

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

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells("IdPlan").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [BUSC-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub miSeleccionar_Click(sender As System.Object, e As System.EventArgs) Handles miSeleccionar.Click
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click, cmbOperador.ValueChanged, cmbTipoServicio.ValueChanged, txtDesPlan.TextChanged
        listaDatos()
    End Sub

End Class