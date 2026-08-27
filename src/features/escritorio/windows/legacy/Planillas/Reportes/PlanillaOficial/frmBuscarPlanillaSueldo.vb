Imports System.ServiceModel
Public Class frmBuscarPlanillaSueldo

    '===========================Servicios====================================================
    Private oPlanillaSueldosService As New PlanillaSueldosService.PlanillaSueldosServiceClient

    '======================Declaración de Variables==============================================
    Public codigo As String
    Public iEstado As Integer
    Private dtDatos As New DataTable
    Private dtEstados As New DataTable
    Private state_Search As Boolean


    Private Sub frmBuscarPlanillaSueldo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGrid_Bucadores(dgvDatos)
        txtPeriodo.Value = Today.Year

        state_Search = False
        llenarCombos()
        state_Search = True
        ListaDatos()
        dgvDatos.Select()
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                       txtPeriodo.KeyPress _
                     , txtIdPlanilla.KeyPress _
                     , cmbEstado.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            ListaDatos()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                dgvDatos_DoubleClick(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub frmBuscarAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                          txtPeriodo.KeyPress _
                     , txtMes.KeyPress _
                     , txtIdPlanilla.KeyPress _
                     , cmbEstado.KeyPress _
                      , dgvDatos.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
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

    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPlanillaSueldosService.Close()
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miSeleccionar.Enabled = False
        Else
            miSeleccionar.Enabled = True
        End If
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

    Private Sub ListaDatos()
        Try
            If state_Search = True Then
                dtDatos = oPlanillaSueldosService.Filtrar(Session.sCodEmp, txtPeriodo.Value, txtMes.Text, toNumber(IIf(txtIdPlanilla.Text = "", 0, txtIdPlanilla.Text)), cmbEstado.Value).Tables(0)
                dgvDatos.SetDataBinding(dtDatos, 0)

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [BUSC-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            '============================= ESTADOS ===============================      
            dtEstados = oPlanillaSueldosService.MostrarEstados().Tables(0)
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Seleccionar()
        Try
            codigo = dgvDatos.CurrentRow.Cells("IdPlanilla").Text
            'descripcion = dgvDatos.CurrentRow.Cells("DesAlm").Text
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox("ERROR [BUSC-001]: " + ex.Message, MsgBoxStyle.Exclamation)
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
            ElseIf dgvDatos.CurrentRow.Cells("IdPlanilla").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [BUSC-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtPeriodo.TextChanged, txtMes.TextChanged, txtIdPlanilla.TextChanged, cmbEstado.ValueChanged
        ListaDatos()
    End Sub

    Private Sub miSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeleccionar.Click
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdPlanilla").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, dtDatos, "IdPlanilla", codigo)
        End If
    End Sub

    Private Sub txtMes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMes.Click
        txtMes.SelectAll()
    End Sub

    Private Sub txtMes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMes.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            If Len(Trim(txtMes.Text)) > 0 Then
                If toNumber(txtMes.Text) < 13 And toNumber(txtMes.Text) > 0 Then
                    Dim cant As Integer = Len(txtMes.Text)
                    If cant < 2 Then
                        txtMes.Text = "0" & txtMes.Text
                    End If
                    txtIdPlanilla.Focus()
                Else
                    MsgBox("Rango de Mes [01 - 12]")
                    txtMes.Focus()
                End If
            End If
            txtIdPlanilla.Focus()
        End If
    End Sub

    Private Sub txtMesRegistro_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMes.Validated
        If Len(Trim(txtMes.Text)) > 0 Then
            Dim cant As Integer = Len(txtMes.Text)
            If cant < 2 Then
                txtMes.Text = "0" & txtMes.Text
            End If
            If toNumber(txtMes.Text) = 0 Or toNumber(txtMes.Text) > 12 Then
                MsgBox("Rango del Mes de Registro [01 - 12]", MsgBoxStyle.Critical, "Error de Datos")
            Else
                txtIdPlanilla.Focus()
            End If
            'Else
            '    MsgBox("Debe ingresar el Mes de Registro.", MsgBoxStyle.Critical, "No Existe")
            '    txtMesRegistro.Focus()
        End If
    End Sub
End Class