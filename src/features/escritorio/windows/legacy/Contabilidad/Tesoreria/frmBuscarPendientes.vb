Imports System.ServiceModel
Public Class frmBuscarPendientes

    '===========================Servicios====================================================
    Private oTesoreriaService As New TesoreriaService.TesoreriaServiceClient

    '======================Declaración de Variables==============================   
    Public IdCompra As Integer
    Public IdDocumento As Integer 'Tipo de Documento viene del InsertarPendientes
    Public SerieDoc As String 'Serie de Documento viene del Insertar Pendientes
    Public NumDoc As String 'Número de Documento viene del Insertar Pendientes
    Public dtDetalles As DataTable 'Documentos Seleccionados
    Public Nombre As String 'DesProv de la primera fila seleccionada
    Private IdProveedor As Integer
    Private state_Search As Boolean
    Private dtDatos As DataTable
    Private dtTipDoc As DataTable

    Private Sub frmBuscarPendientes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmBuscarPendientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmBuscarPendientes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        chkProveedor.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkProveedor, "Limpiar Proveedor")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Proveedor")

        dgvDatos.BackgroundColor = Color.Beige
        dgvDatos.BackColor = Color.Beige
        dgvDatos.ForeColor = Color.MidnightBlue
        dgvDatos.ScrollBars = ScrollBars.Both
        dgvDatos.AutoGenerateColumns = False
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        IdProveedor = 0
        txtProveedor.Text = "(Todos)"

        state_Search = False
        LlenarCombos()
        state_Search = True
        listaDatos()
        'txtPeriodo.Value = Today.Year
        'txtMesRegistro.Text = Today.Month
        cmbTipoDoc.Value = 3
        txtPeriodo.Select()
    End Sub

    Private Sub Finalizar()
        Try
            oTesoreriaService.Close()
        Catch ex As TimeoutException
            oTesoreriaService.Abort()
        Catch ex As CommunicationException
            oTesoreriaService.Abort()
        End Try
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
                    txtCodCuenta.Focus()
                Else
                    MsgBox("Rango de Mes [01 - 12]")
                    txtMesRegistro.Focus()
                    txtMesRegistro.Focus()
                End If
            End If
            txtCodCuenta.Focus()
        End If
    End Sub

    Private Sub txtCodCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCuenta.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCuenta.Enabled = True Then
                e.Handled = True
                btnBuscarCuenta_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtPeriodo.ValueChanged, txtMesRegistro.TextChanged, _
                                                                                                                                                           txtCodCuenta.TextChanged, cmbTipoDoc.ValueChanged, txtSerieDoc.TextChanged, _
                                                                                                                                                           txtNumDoc.TextChanged, txtProveedor.TextChanged
        listaDatos()
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
            dtTipDoc = oTesoreriaService.MostrarTipoDocumento().Tables(0)
            dtTipDoc.Rows.InsertAt(getRowTodos(dtTipDoc), 0)
            cmbTipoDoc.DataSource = dtTipDoc
            cmbTipoDoc.DropDownList.DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.DisplayMember = dtTipDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.DropDownList.ValueMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(0).DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(1).DataMember = dtTipDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.DropDownList.Columns(2).DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.Columns(3).DataMember = dtTipDoc.Columns("CodSunat").ToString
            dtTipDoc = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                oTesoreriaService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(400)
                dtDatos = oTesoreriaService.ConsultarPendientes(Session.sCodEmp, txtPeriodo.Value, txtMesRegistro.Text, txtCodCuenta.Text, IdProveedor, cmbTipoDoc.Value, txtSerieDoc.Text, txtNumDoc.Text).Tables(0)
                dgvDatos.DataSource = dtDatos

                cIdCompra.DataPropertyName = dtDatos.Columns("IdCompra").ColumnName
                cIdCuenta.DataPropertyName = dtDatos.Columns("IdCuenta").ColumnName
                cCodCuenta.DataPropertyName = dtDatos.Columns("CodCuenta").ColumnName
                cIdDocumento.DataPropertyName = dtDatos.Columns("IdDocumento").ColumnName
                cSerDoc.DataPropertyName = dtDatos.Columns("SerDoc").ColumnName
                cTipMov.DataPropertyName = dtDatos.Columns("TipMov").ColumnName
                cNumDoc.DataPropertyName = dtDatos.Columns("NumDoc").ColumnName
                cIdProveedor.DataPropertyName = dtDatos.Columns("IdProveedor").ColumnName
                cDocumento.DataPropertyName = dtDatos.Columns("Documento").ColumnName
                cDesProv.DataPropertyName = dtDatos.Columns("DesProv").ColumnName
                cFecDoc.DataPropertyName = dtDatos.Columns("FecDoc").ColumnName
                cCodMon.DataPropertyName = dtDatos.Columns("CodMon").ColumnName
                cSaldoSol.DefaultCellStyle.Format = "N2"
                cSaldoSol.DataPropertyName = dtDatos.Columns("SaldoSol").ColumnName
                cSaldoDol.DefaultCellStyle.Format = "N2"
                cSaldoDol.DataPropertyName = dtDatos.Columns("SaldoDol").ColumnName
                cFecVen.DataPropertyName = dtDatos.Columns("FecVen").ColumnName
                cSeleccion.DataPropertyName = dtDatos.Columns("Seleccion").ColumnName
                cIdCliente.DataPropertyName = dtDatos.Columns("IdCliente").ColumnName
                cIdHonorario.DataPropertyName = dtDatos.Columns("IdHonorario").ColumnName

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                CalcularAcumulado()
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
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

    Private Sub dgvDatos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDatos.CellContentClick
        TextBox1.Select()
        CalcularAcumulado()
    End Sub

    Private Sub CalcularAcumulado()
        Try

            Dim TotalSaldoUS As Double = 0
            Dim TotalSaldoNS As Double = 0

            For i As Integer = 0 To dtDatos.Rows.Count - 1

                Dim row As DataGridViewRow = dgvDatos.Rows(i)
                Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("cbInsertar"), DataGridViewCheckBoxCell)

                If toBoolean(cellSelecion.Value) = True Then
                    TotalSaldoUS = TotalSaldoUS + (toDouble(dgvDatos.Rows(i).Cells("cSaldoDol").Value) * (IIf(dgvDatos.Rows(i).Cells("cTipMov").Value = "H", -1, 1)))
                    TotalSaldoNS = TotalSaldoNS + (toDouble(dgvDatos.Rows(i).Cells("cSaldoSol").Value) * (IIf(dgvDatos.Rows(i).Cells("cTipMov").Value = "H", -1, 1)))
                End If
            Next

            sslTotalSaldoNS.Text = "Total Saldo Soles: " + TotalSaldoNS.ToString
            sslTotalSaldoUS.Text = "Total Saldo Dolares: " + TotalSaldoUS.ToString
        Catch ex As Exception
            MsgBox("ERROR CALCULAR MONTOS ACUMULADOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Insertar()
        Try
            If MsgBox("¿Está seguro de INSERTAR el(los) Doc(s) seleccionado(s)?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                dgvDatos.Update()
                Dim dtTable As DataTable
                Dim rows As DataRow

                dtTable = dtDatos.Copy
                dtTable.Clear()

                For i As Integer = 0 To dtDatos.Rows.Count - 1

                    Dim row As DataGridViewRow = dgvDatos.Rows(i)
                    Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("cbInsertar"), DataGridViewCheckBoxCell)

                    If toBoolean(cellSelecion.Value) = True Then
                        rows = dtTable.NewRow
                        rows(0) = dgvDatos.Rows(i).Cells("cIdCompra").Value
                        rows(1) = dgvDatos.Rows(i).Cells("cIdCuenta").Value
                        rows(2) = dgvDatos.Rows(i).Cells("cCodCuenta").Value
                        rows(3) = dgvDatos.Rows(i).Cells("cIdDocumento").Value
                        rows(4) = dgvDatos.Rows(i).Cells("cTipMov").Value
                        rows(5) = dgvDatos.Rows(i).Cells("cSerDoc").Value
                        rows(6) = dgvDatos.Rows(i).Cells("cNumDoc").Value
                        rows(7) = dgvDatos.Rows(i).Cells("cIdProveedor").Value
                        rows(8) = dgvDatos.Rows(i).Cells("cIdCliente").Value
                        rows(9) = dgvDatos.Rows(i).Cells("cDocumento").Value
                        rows(10) = dgvDatos.Rows(i).Cells("cDesProv").Value
                        rows(11) = dgvDatos.Rows(i).Cells("cFecDoc").Value
                        rows(12) = dgvDatos.Rows(i).Cells("cCodMon").Value
                        rows(13) = IIf(dgvDatos.Rows(i).Cells("cSaldoSol").Value < 0, dgvDatos.Rows(i).Cells("cSaldoSol").Value * -1, dgvDatos.Rows(i).Cells("cSaldoSol").Value)
                        rows(14) = IIf(dgvDatos.Rows(i).Cells("cSaldoDol").Value < 0, dgvDatos.Rows(i).Cells("cSaldoDol").Value * -1, dgvDatos.Rows(i).Cells("cSaldoDol").Value)
                        rows(15) = dgvDatos.Rows(i).Cells("cFecVen").Value
                        rows(16) = dgvDatos.Rows(i).Cells("cSeleccion").Value
                        rows(17) = dgvDatos.Rows(i).Cells("cIdHonorario").Value
                        dtTable.Rows.Add(rows)
                    End If
                Next
                If dtTable.Rows.Count = 0 Then
                    MsgBox("¡Debe seleccionar alguno de los Documentos...!", MsgBoxStyle.Information, "No hay datos")
                Else
                    Dim frm As New frmInsertarPendientes
                    frm.Provisional = False
                    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                        dtDetalles = dtTable
                        IdDocumento = frm.IdDocumento
                        SerieDoc = frm.SerieDoc
                        NumDoc = frm.NumDoc
                        Nombre = dtTable.Rows(0).Item("DesProv").ToString
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miSeleccionarTodos.Enabled = False
            cbSeleccionarTodos.Enabled = False
            miNinguno.Enabled = False
            miInsertar.Enabled = False
            biInsertar.Enabled = False
        Else
            miSeleccionarTodos.Enabled = True
            cbSeleccionarTodos.Enabled = True
            miNinguno.Enabled = True
            miInsertar.Enabled = True
            biInsertar.Enabled = True
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

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtPeriodo.KeyPress _
                       , txtCodCuenta.KeyPress _
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

    Private Sub btnBuscarCuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCuenta.Click
        Try
            Dim frm As New frmBuscarCuentaContable
            frm.txtCodCuenta.Text = txtCodCuenta.Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtCodCuenta.Text = frm.codigo
                    'lblDesCuenta.Text = frm.descripcion
                Else
                    txtCodCuenta.Text = ""
                    'lblDesCuenta.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al buscar Buscar Cuenta Contable : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miSeleccionarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeleccionarTodos.Click
        For Each fila As DataGridViewRow In dgvDatos.Rows
            fila.Cells(16).Value = True
        Next
        CalcularAcumulado()
    End Sub

    Private Sub miNinguno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNinguno.Click
        For Each fila As DataGridViewRow In dgvDatos.Rows
            fila.Cells(16).Value = False
        Next
        CalcularAcumulado()
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click, biActualizar.Click
        listaDatos()
    End Sub

    Private Sub biInsertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biInsertar.Click, miInsertar.Click
        Insertar()
    End Sub

    Private Sub miSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miSalir.Click, biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cbSeleccionarTodos_CheckedChanged(sender As Object, e As EventArgs) Handles cbSeleccionarTodos.CheckedChanged
        If cbSeleccionarTodos.Checked = True Then
            For Each fila As DataGridViewRow In dgvDatos.Rows
                fila.Cells(16).Value = True
            Next
        Else
            For Each fila As DataGridViewRow In dgvDatos.Rows
                fila.Cells(16).Value = False
            Next
        End If
        CalcularAcumulado()
    End Sub


End Class
