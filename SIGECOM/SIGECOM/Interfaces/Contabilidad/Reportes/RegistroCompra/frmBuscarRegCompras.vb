Imports System.ServiceModel
Public Class frmBuscarRegCompras

    '===========================Servicios====================================================
    Private oRegistroCompraService As New RegistroCompraService.RegistroCompraServiceClient

    '======================Declaración de Variables==============================   
    Public IdCompra As Integer
    Private IdProveedor As Integer
    Private state_Search As Boolean
    Private dtDatos As DataTable
    Private dtMonedas As DataTable
    Private dtCondPago As DataTable
    Private dtTipDoc As DataTable

    Private Sub frmBuscarRegCompras_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oRegistroCompraService.Close()
        Catch ex As TimeoutException
            oRegistroCompraService.Abort()            
        Catch ex As CommunicationException
            oRegistroCompraService.Abort()            
        End Try
    End Sub

    Private Sub frmBuscarRegCompras_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmBuscarRegCompras_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        chkProveedor.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkProveedor, "Limpiar Proveedor")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Proveedor")

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        IdProveedor = 0
        txtProveedor.Text = "(Todos)"

        state_Search = False
        LlenarCombos()
        state_Search = True
        listaDatos()
        'txtPeriodo.Value = Today.Year
        txtPeriodo.Select()
    End Sub

    Private Sub chkProveedor_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkProveedor.CheckedChanged
        If txtProveedor.Text <> "(Todos)" Then
            chkProveedor.Enabled = False
            txtProveedor.Text = "(Todos)"
            IdProveedor = 0
            listaDatos()
        Else
            chkProveedor.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub

    Private Sub btnBuscarProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                chkProveedor.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtProveedor.Text = frm.descripcion
                    IdProveedor = frm.codigo
                Else
                    txtProveedor.Text = "(Todos)"
                    IdProveedor = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                dgvDatos_DoubleClick(sender, e)
                e.Handled = True
            End If
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

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Todos)"
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
            fila(2) = ""
        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
            fila(3) = 0
        End Try
        Try
            fila(3) = "(Todos)"
        Catch ex As Exception
            fila(4) = 0
        End Try
        Return fila
    End Function

    Private Sub LlenarCombos()
        Try
            '===================================== TIPO DE DOCUMENTO=========================================
            dtTipDoc = oRegistroCompraService.MostrarTipoDocumento().Tables(0)
            dtTipDoc.Rows.InsertAt(getRowTodos(dtTipDoc), 0)
            cmbTipoDoc.DataSource = dtTipDoc
            cmbTipoDoc.DropDownList.DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.DisplayMember = dtTipDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.DropDownList.ValueMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(0).DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(1).DataMember = dtTipDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.DropDownList.Columns(2).DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.Columns(3).DataMember = dtTipDoc.Columns("CodSunat").ToString
            cmbTipoDoc.SelectedIndex = 0
            dtTipDoc = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
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
                MsgBox("¡Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells("IdCompra").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [BUSC-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Seleccionar()
        Try
            IdCompra = dgvDatos.CurrentRow.Cells("IdCompra").Text
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox("ERROR [BUSC-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oRegistroCompraService.Filtrar(Session.sCodEmp, txtPeriodo.Value, txtMesRegistro.Text, txtNumRegistro.Text, cmbTipoDoc.Value, txtSerieDoc.Text, txtNumDoc.Text, IdProveedor).Tables(0)
                dgvDatos.SetDataBinding(dtDatos, 0)

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miSeleccionar.Enabled = False
        Else
            miSeleccionar.Enabled = True
        End If
    End Sub

    Private Sub miSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeleccionar.Click
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdCompra").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, dtDatos, "IdCompra", codigo)
        End If
    End Sub

    Private Sub miNinguno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNinguno.Click
        IdCompra = 0
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub txtMesRegistro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMesRegistro.Click
        txtMesRegistro.SelectAll()
    End Sub

    Private Sub txtMesRegistro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMesRegistro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            If Len(Trim(txtMesRegistro.Text)) > 0 Then
                If toNumber(txtMesRegistro.Text) < 13 And toNumber(txtMesRegistro.Text) > 0 Then
                    Dim cant As Integer = Len(txtMesRegistro.Text)
                    If cant < 2 Then
                        txtMesRegistro.Text = "0" & txtMesRegistro.Text
                    End If
                    txtNumRegistro.Focus()
                Else
                    MsgBox("Rango de Mes [01 - 12]")
                    txtMesRegistro.Text = ""
                    txtMesRegistro.Focus()
                End If
            End If
            txtNumRegistro.Focus()
        End If
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarProveedor.Enabled = True Then
                e.Handled = True
                btnBuscarProveedor_Click(sender, e)
            End If
        End If
    End Sub

    'Private Sub txtNumRegistro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumRegistro.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
    '        e.Handled = True
    '        If Len(Trim(txtNumRegistro.Text)) > 0 Then
    '            Dim cant As Integer = Len(txtNumRegistro.Text)
    '            Do While cant < 6
    '                txtNumRegistro.Text = "0" & txtNumRegistro.Text
    '                cant = cant + 1
    '            Loop
    '        End If
    '        cmbTipoDoc.Focus()
    '    End If
    'End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                           txtPeriodo.KeyPress _
                         , txtNumRegistro.KeyPress _
                         , txtSerieDoc.KeyPress _
                         , txtNumDoc.KeyPress _
                         , cmbTipoDoc.KeyPress _
                         , txtProveedor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            'listaDatos()
            If dgvDatos.RowCount > 0 Then
                dgvDatos.Select()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtPeriodo.TextChanged, txtMesRegistro.TextChanged, txtNumRegistro.TextChanged, _
                                                                                                                                cmbTipoDoc.ValueChanged, txtSerieDoc.TextChanged, txtNumDoc.TextChanged, txtProveedor.TextChanged
        listaDatos()
    End Sub

    'Private Sub txtSerieDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerieDoc.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
    '        e.Handled = True
    '        If Len(Trim(txtSerieDoc.Text)) > 0 Then
    '            Dim cant As Integer = Len(txtSerieDoc.Text)
    '            Do While cant < 4
    '                txtSerieDoc.Text = "0" & txtSerieDoc.Text
    '                cant = cant + 1
    '            Loop
    '        End If
    '        txtNumDoc.Focus()
    '    End If
    'End Sub

    'Private Sub txtNumDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
    '        e.Handled = True
    '        If Len(Trim(txtNumDoc.Text)) > 0 Then
    '            Dim cant As Integer = Len(txtNumDoc.Text)
    '            Do While cant < 10
    '                txtNumDoc.Text = "0" & txtNumDoc.Text
    '                cant = cant + 1
    '            Loop
    '        End If
    '        txtProveedor.Focus()
    '    End If
    'End Sub

    'Private Sub txtSerieDoc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSerieDoc.Validated
    '    Try
    '        If Len(Trim(txtSerieDoc.Text)) > 0 Then
    '            Dim cant As Integer = Len(txtSerieDoc.Text)
    '            Do While cant < 4
    '                txtSerieDoc.Text = "0" & txtSerieDoc.Text
    '                cant = cant + 1
    '            Loop
    '            txtNumDoc.Focus()
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL OBTENER LA SERIE DEL DOCUMENTO : " + ex.Message)
    '    End Try
    'End Sub

    'Private Sub txtNumDoc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumDoc.Validated
    '    Try
    '        If Len(Trim(txtNumDoc.Text)) > 0 Then
    '            Dim cant As Integer = Len(txtNumDoc.Text)
    '            Do While cant < 10
    '                txtNumDoc.Text = "0" & txtNumDoc.Text
    '                cant = cant + 1
    '            Loop
    '            txtProveedor.Focus()
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL OBTENER EL NÚMERO DEL DOCUMENTO : " + ex.Message)
    '    End Try
    'End Sub

    'Private Sub txtSerieDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSerieDoc.Click
    '    txtSerieDoc.SelectAll()
    'End Sub

    'Private Sub txtNumDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumDoc.Click
    '    txtNumDoc.SelectAll()
    'End Sub

End Class