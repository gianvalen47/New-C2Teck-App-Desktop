Public Class frmAtenderJob_Detalles

    Private oMaestro As New MaestroService.MaestroClient
    Private oTransferenciaService As New TransferenciaService.TransferenciaServiceClient
    Private state_Search As Boolean
    Private dtAlmacenes As DataTable
    'Public IdOficina As Integer
    Public NumJob As String
    Public IdCliente As String
    Private dtDatos As DataTable
    Private loNuevoDataTable As DataTable
    'Private data As DataTable

    Private Sub frmAtenderJob_Detalles_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestro) = False Then
                oMaestro.Close()
            End If
            If isClosed(oTransferenciaService) = False Then
                oTransferenciaService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub frmAtenderJob_Detalles_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub frmAtenderJob_Detalles_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                cmbAlmacen.KeyPress _
                , txtNumero.KeyPress _
                , txtFecha.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub frmAtenderJob_Detalles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dgvDatos.BackgroundColor = Color.Beige
        dgvDatos.BackColor = Color.Beige
        dgvDatos.ForeColor = Color.MidnightBlue
        dgvDatos.AutoGenerateColumns = False
        llenarCombos()
        state_Search = True
        listaDatos()
        enableOpciones()
        txtNumero.ReadOnly = True
        txtFecha.ReadOnly = True
        cmbAlmacen.ReadOnly = False

    End Sub
    Private Sub llenarCombos()
        '======================================= ALMACENES ================================================
        dtAlmacenes = oMaestro.MostrarLocaciones(Session.sCodEmp, "01", Session.sCodUsu).Tables(0)
        cmbAlmacen.DataSource = dtAlmacenes
        'cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
        cmbAlmacen.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
        cmbAlmacen.DropDownList.ValueMember = dtAlmacenes.Columns("IdLocacion").ToString
        cmbAlmacen.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("IdLocacion").ToString
        cmbAlmacen.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
        cmbAlmacen.SelectedIndex = 0
        If dtAlmacenes.Rows.Count > 0 Then
            cmbAlmacen.SelectedIndex = 0
        Else
            cmbAlmacen.Value = ""
        End If
        dtAlmacenes = Nothing
    End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 0 Then
            biDeshacer.Enabled = False
            biGenerarTransferencia.Enabled = False
            biSeparar.Enabled = False
            biDespachar.Enabled = False
            biImprimir.Enabled = False
        Else
            biDespachar.Enabled = True
            biSeparar.Enabled = True
            biGenerarTransferencia.Enabled = False
            biDeshacer.Enabled = False
            biImprimir.Enabled = True
        End If
    End Sub
    Private Function ValidaCampos() As Boolean
        Try
            If IdCliente = 0 Then
                MsgBox("Debe Ingresar el cliente.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf cmbAlmacen.Value = 0 Then
                MsgBox("Debe Ingresar la locación.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(txtNumero.Text) = "" Then
                MsgBox("Debe Ingresar el número de la Transferencia.", MsgBoxStyle.Information, "Información")
                txtNumero.BackColor = Color.Red
                txtNumero.Focus()
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub activar()
        biGenerarTransferencia.Enabled = True
        biDeshacer.Enabled = True
        biDespachar.Enabled = False
        biSeparar.Enabled = False
        biImprimir.Enabled = False
        rbSeleccionrTodos.Enabled = True
        txtNumero.ReadOnly = False
        txtFecha.ReadOnly = False
        cmbAlmacen.ReadOnly = True
    End Sub
    Private Sub desactivar()
        biGenerarTransferencia.Enabled = False
        biDeshacer.Enabled = False
        biDespachar.Enabled = True
        biSeparar.Enabled = False
        biImprimir.Enabled = True
        rbSeleccionrTodos.Enabled = False
        txtNumero.ReadOnly = True
        txtNumero.Text = ""
        txtFecha.ReadOnly = True
        cmbAlmacen.ReadOnly = False
        rbSeleccionrTodos.Checked = False
    End Sub
    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oTransferenciaService.MostrarJobRepPendientes("01", cmbAlmacen.Value, NumJob).Tables(0)
                dgvDatos.DataSource = dtDatos

                cCodMer.DataPropertyName = dtDatos.Columns("CodMer").ColumnName
                cDesMer.DataPropertyName = dtDatos.Columns("DesMer").ColumnName
                cCanPed.DataPropertyName = dtDatos.Columns("CanMer").ColumnName
                cCanAte.DataPropertyName = dtDatos.Columns("CanAte").ColumnName
                cCanPen.DataPropertyName = dtDatos.Columns("CanPen").ColumnName
                cAtender.DataPropertyName = dtDatos.Columns("Despachar").ColumnName
                cStock.DataPropertyName = dtDatos.Columns("Stock").ColumnName
                enableOpciones()
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub biDespachar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDespachar.Click
        activar()
        txtNumero.Text = oTransferenciaService.SugerirNumero(cmbAlmacen.Value)
        dgvDatos.Columns("cAtender").ReadOnly = False
        txtNumero.Select()
    End Sub
    Private Sub biSeparar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSeparar.Click

    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub biGenerarTransferencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerarTransferencia.Click
        Try
            If MsgBox("¿Está seguro de despachar la mercaderia?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then
                'FiltrarDatatable()
                Dim dtTable As DataTable
                Dim row As DataRow

                dtDatos = oTransferenciaService.MostrarJobRepPendientes("01", cmbAlmacen.Value, NumJob).Tables(0)
                dtTable = dtDatos.Copy
                dtTable.Clear()

                For i As Integer = 0 To dtDatos.Rows.Count - 1
                    If dgvDatos.Rows(i).Cells(5).Value.ToString > "0" Then
                        row = dtTable.NewRow
                        row(0) = dtDatos.Rows(i).Item(0)
                        row(1) = dtDatos.Rows(i).Item(1)
                        row(2) = dtDatos.Rows(i).Item(2)
                        row(3) = dtDatos.Rows(i).Item(3)
                        row(4) = dtDatos.Rows(i).Item(4)
                        row(5) = dtDatos.Rows(i).Item(5)
                        row(6) = dtDatos.Rows(i).Item(6)
                        row(7) = dtDatos.Rows(i).Item(7)
                        row(8) = dtDatos.Rows(i).Item(8)
                        row(9) = dtDatos.Rows(i).Item(9)
                        row(10) = dgvDatos.Item(5, i).Value
                        row(11) = dtDatos.Rows(i).Item(11)
                        row(12) = dtDatos.Rows(i).Item(12)
                        row(13) = dtDatos.Rows(i).Item(13)
                        row(14) = dtDatos.Rows(i).Item(14)
                        row(15) = dtDatos.Rows(i).Item(15)
                        row(16) = dtDatos.Rows(i).Item(16)
                        row(17) = dtDatos.Rows(i).Item(17)
                        row(18) = dtDatos.Rows(i).Item(18)
                        row(19) = dtDatos.Rows(i).Item(19)

                        'row(0) = dtDatos.Rows(i).Item(0)
                        'row(1) = dtDatos.Rows(i).Item(1)
                        'row(2) = dtDatos.Rows(i).Item(2)
                        'row(3) = dtDatos.Rows(i).Item(3)
                        'row(4) = dtDatos.Rows(i).Item(4)
                        'row(5) = dtDatos.Rows(i).Item(5)
                        'row(6) = dtDatos.Rows(i).Item(6)
                        'row(7) = dtDatos.Rows(i).Item(7)
                        'row(8) = dtDatos.Rows(i).Item(8)
                        'row(9) = dtDatos.Rows(i).Item(9)
                        'row(10) = dtDatos.Rows(i).Item(10)
                        'row(11) = dtDatos.Rows(i).Item(11)
                        'row(12) = dtDatos.Rows(i).Item(12)
                        'row(13) = dtDatos.Rows(i).Item(13)
                        'row(14) = dtDatos.Rows(i).Item(14)
                        'row(15) = dgvDatos.Item(5, i).Value
                        'row(16) = dtDatos.Rows(i).Item(16)

                        dtTable.Rows.Add(row)
                    End If
                Next

                Dim estado_process As Boolean
                estado_process = oTransferenciaService.GenerarAtencionJob(cmbAlmacen.Value, IdCliente, txtNumero.Text, txtFecha.Text, NumJob, dtTable, Session.sCodUsu)

                If estado_process Then
                    Me.DialogResult = Windows.Forms.DialogResult.OK

                Else
                    MsgBox("No se despacho correctamente")
                    desactivar()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub rbSeleccionrTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSeleccionrTodos.CheckedChanged
        seleccionaTodos(rbSeleccionrTodos.Checked)
    End Sub
    Private Sub seleccionaTodos(ByVal condicion As Boolean)
        Try
            Dim contador As Integer

            contador = 0
            For i As Integer = 0 To dtDatos.Rows.Count - 1
                If contador = 30 Then
                    GoTo 2
                Else
                    If condicion = True Then
                        If dgvDatos.Item("cStock", i).Value < dgvDatos.Item("cCanPen", i).Value Then
                            If dgvDatos.Item("cStock", i).Value <> 0 Then
                                dgvDatos.Item("cAtender", i).Value = dgvDatos.Item("cStock", i).Value
                                contador = contador + 1
                            Else
                                dgvDatos.Item("cAtender", i).Value = 0
                            End If
                        Else
                            dgvDatos.Item("cAtender", i).Value = dgvDatos.Item("cCanPen", i).Value
                            contador = contador + 1
                        End If
                    Else
                        dgvDatos.Item("cAtender", i).Value = 0
                    End If
                End If

            Next
2:          dgvDatos.Select()
            dtDatos.AcceptChanges()
        Catch ex As Exception
            MsgBox("ERROR " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
    Private Sub cmbAlmacen_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAlmacen.ValueChanged
        listaDatos()
    End Sub
    'Private Sub dgvDatos_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvDatos.CellFormatting
    '    If Me.dgvDatos.Columns(e.ColumnIndex).Name = "cAtender" Then
    '        e.CellStyle.BackColor = Color.Wheat
    '    End If
    'End Sub
    Private Sub dgvDatos_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvDatos.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub
    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = dgvDatos.CurrentCell.ColumnIndex
        If columna = 5 Or columna = 6 Then
            Dim caracter As Char = e.KeyChar
            If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False Then
                e.KeyChar = Chr(0)
            Else
                Dim campo As TextBox = sender
                If (e.KeyChar <> ChrW(Keys.Back)) Then
                    Dim porAtender As Integer = 0
                    Try
                        porAtender = CInt(campo.Text + e.KeyChar.ToString)
                    Catch ex As Exception
                        porAtender = toNumber(campo.Text)
                    End Try

                    Dim margen As Integer
                    Dim stock As Integer
                    margen = toNumber(dgvDatos.Item("cCanPen", dgvDatos.CurrentRow.Index).Value.ToString)
                    stock = toNumber(dgvDatos.Item("cStock", dgvDatos.CurrentRow.Index).Value.ToString)
                    If porAtender > margen Then
                        MsgBox("La cantidad a despachar es mayor a la cantidad pendiente", MsgBoxStyle.Exclamation)
                        e.KeyChar = Chr(0)
                    Else
                        If porAtender > stock Then
                            MsgBox("La cantidad a despachar no puede ser mayor al stock")
                            e.KeyChar = Chr(0)
                        End If
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        dgvDatos.Columns("cAtender").ReadOnly = False
        listaDatos()
        desactivar()
    End Sub
    'Private Function FiltrarDatatable() As DataTable
    '    Dim loRows As DataRow()
    '    loNuevoDataTable = dtDatos

    '    loRows = dtDatos.Select(dgvDatos.Item("cAtender", dgvDatos.CurrentRow.Index).Value <> 0)
    '    For Each ldrRow As DataRow In loRows
    '        loNuevoDataTable.ImportRow(ldrRow)
    '    Next
    '    ' Retorno el nuevo DataTable       
    '    Return loNuevoDataTable
    'End Function


    'Private Function FiltrarTable() As DataTable
    '    Try
    '        data = dtDatos
    '        Dim row As DataRow
    '        For i As Integer = 0 To dtDatos.Rows.Count - 1
    '            If dgvDatos.Rows(i).Cells(5).Value.ToString > "0" Then
    '                row = data.NewRow
    '                row(0) = dgvDatos.Item(5, i).Value
    '                row(1) = dgvDatos.Item(5, i).Value
    '                row(2) = dgvDatos.Item(5, i).Value
    '                row(3) = dgvDatos.Item(5, i).Value
    '                row(4) = dgvDatos.Item(5, i).Value
    '                row(5) = dgvDatos.Item(5, i).Value
    '                row(6) = dgvDatos.Item(5, i).Value
    '                data.Rows.Add(row)
    '            End If
    '        Next
    '        Return data
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    End Try

    'End Function

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        Try
            Dim forma As New frmReportes
            Dim reporte As New rpAtenderJob

            If dtDatos.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtDatos)
                forma.crvReportes.ReportSource = reporte
                forma.crvReportes.DisplayGroupTree = False
                'forma.crvReportes.RefreshReport = False
                reporte.SetParameterValue("NumJob", NumJob)

                forma.Text = "Reporte de Pedidos de Job"
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

   
End Class