Imports System.Windows.Forms

Public Class frmOrdenCompra_GenerarDocumento
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oOrdenCompraService As New OrdenCompraService.OrdenCompraServiceClient
    Private oOrdenCompraDetService As New OrdenCompraDetService.OrdenCompraDetServiceClient
    Private oLocacionClienteService As New LocacionClienteService.LocacionClienteServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdOrden As Integer
    Public IdLocacion As Integer
    Public IdCliente As Integer

    Private dtTipos As DataTable
    Private dtLocaciones As DataTable
    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                txtNumDoc.KeyPress _
                , txtFecDoc.KeyPress _
                , cmbIdLocCli.KeyPress _
                , cmbTipo.KeyPress _
                , dgvDatos.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmOrdenCompra_GenerarDocumento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        Dim estilo As New Estilo
        estilo.cargaEstiloDataDrid(dgvPrueba)
        dgvPrueba.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        dgvPrueba.Columns(7).ReadOnly = False
        llenarCombos()
        txtFecDoc.Value = Session.sFecha
        listaDatos()
        enableOpciones()
        'If Session.CodPerfil = "09" Then
        '    desactivar()
        'End If
        cmbTipo.Select()

    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oOrdenCompraService) = False Then
                oOrdenCompraService.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oLocacionClienteService) = False Then
                oLocacionClienteService.Close()
            End If
            If isClosed(oOrdenCompraDetService) = False Then
                oOrdenCompraDetService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                  txtNumDoc.KeyUp _
                , txtFecDoc.KeyUp
        Try
            Dim campo As New Object
            If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.EditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.EditBox
            ElseIf sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.NumericEditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.NumericEditBox
            ElseIf sender.GetType.ToString = "System.Windows.Forms.TextBox" Then
                campo = New TextBox
            End If
            campo = sender
            If campo.readonly = False Then
                If campo.Text.Trim.Length > 0 Then
                    campo.BackColor = Color.White
                Else
                    campo.BackColor = Color.Red
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub enableOpciones()
        If oOrdenCompraService.Estado(IdOrden) = "PROCESADO" Then
            btnGuardar.Enabled = False
            miSeleccionarTodo.Enabled = False
            miSeterCEROTodos.Enabled = False
            'dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            dgvPrueba.ReadOnly = True
        Else
            btnGuardar.Enabled = True
            miSeleccionarTodo.Enabled = True
            miSeterCEROTodos.Enabled = True

            'dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            dgvPrueba.ReadOnly = False
            dgvPrueba.Columns(0).ReadOnly = True
            dgvPrueba.Columns(1).ReadOnly = True
            dgvPrueba.Columns(2).ReadOnly = True
            dgvPrueba.Columns(3).ReadOnly = True
            dgvPrueba.Columns(4).ReadOnly = True
            dgvPrueba.Columns(5).ReadOnly = True
            dgvPrueba.Columns(6).ReadOnly = True
            dgvPrueba.Columns(7).ReadOnly = False
            dgvPrueba.Columns(26).ReadOnly = True
            'dgvDatos.RootTable.Columns(1).EditType = Janus.Windows.GridEX.EditType.NoEdit
            'dgvDatos.RootTable.Columns(2).EditType = Janus.Windows.GridEX.EditType.NoEdit
            'dgvDatos.RootTable.Columns(3).EditType = Janus.Windows.GridEX.EditType.NoEdit
            'dgvDatos.RootTable.Columns(4).EditType = Janus.Windows.GridEX.EditType.NoEdit
            'dgvDatos.RootTable.Columns(5).EditType = Janus.Windows.GridEX.EditType.NoEdit
            'dgvDatos.RootTable.Columns(6).EditType = Janus.Windows.GridEX.EditType.NoEdit
            'dgvDatos.RootTable.Columns(7).EditType = Janus.Windows.GridEX.EditType.TextBox
        End If
    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
        Try
            tabla.DefaultView.Sort = nombreCampo
            lista.Row = dtDatos.DefaultView.Find(codigo)
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdOrden) = 0 Then
                MsgBox("Debe Ingresrar el código de la O.C. ", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toNumber(txtNumDoc.Text) = 0 And cmbTipo.Value <> 3 Then
                MsgBox("Debe Ingresar número del nuevo documento.", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
            ElseIf toBlank(txtFecDoc.Text) = "" Then
                MsgBox("Debe Ingresar la fecha del nuevo documento", MsgBoxStyle.Information, "Información")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
            ElseIf oMaestroService.MostrarTipoCambio("US", txtFecDoc.Text) = 0 Then
                MsgBox("Esta fecha no tiene tipo de cambio, Tenga cuidado...")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
            ElseIf cmbIdLocCli.DropDownList.RowCount > 0 And toNumber(cmbIdLocCli.Value) = 0 And cmbTipo.Value <> 3 Then
                MsgBox("Debe ingresar la locación del cliente", MsgBoxStyle.Information, "Información")
                cmbIdLocCli.Focus()
                Return False
                'ElseIf cmbTipo.Value <> 4 And toNumber(cmbIdLocCli.Value) = 0 Then
                '    MsgBox("Debe ingresar la locación del cliente", MsgBoxStyle.Information, "Información")
                '    cmbIdLocCli.Focus()
                '    Return False
            ElseIf state_button = True And oOrdenCompraService.Estado(IdOrden) = "PROCESADO" Then
                MsgBox("No puede generar el documento...!" + vbCr + "Debido que la O.C. esta PROCESADO...!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [GEN-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub GenerarDocumento()
        Try
            Dim estado_process As Integer
            Dim dtTable As DataTable
            Dim row As DataRow

            dtTable = dtDatos.Copy
            dtTable.Clear()
            For i As Integer = 0 To dtDatos.Rows.Count - 1
                If dgvPrueba.Rows(i).Cells("Despacho").Value > "0" Then
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
                    row(10) = dtDatos.Rows(i).Item(10)
                    row(11) = dtDatos.Rows(i).Item(11)
                    row(12) = dtDatos.Rows(i).Item(12)
                    row(13) = dgvPrueba.Rows(i).Cells("Despacho").Value
                    row(14) = dtDatos.Rows(i).Item(14)
                    row(15) = dtDatos.Rows(i).Item(15)
                    row(16) = dtDatos.Rows(i).Item(16)
                    row(17) = dtDatos.Rows(i).Item(17)
                    row(18) = dtDatos.Rows(i).Item(18)
                    row(19) = dtDatos.Rows(i).Item(19)
                    row(20) = dtDatos.Rows(i).Item(20)
                    row(21) = dtDatos.Rows(i).Item(21)
                    row(22) = dtDatos.Rows(i).Item(22)
                    row(23) = dtDatos.Rows(i).Item(23)
                    row(24) = dtDatos.Rows(i).Item(24)
                    dtTable.Rows.Add(row)
                End If
            Next

            If cmbTipo.Value = 3 Then
                'MsgBox("hola")
                estado_process = oOrdenCompraService.GenerarRequisicion(IdOrden, txtFecDoc.Text, dtTable, Session.sCodUsu)
            Else
                estado_process = oOrdenCompraService.GenerarDocumento(cmbTipo.Value, IdOrden, toNumber(cmbIdLocCli.Value), toNumber(txtNumDoc.Text), txtFecDoc.Text, dtTable, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            End If

            type_process = "insert"
            If estado_process > 0 Then
                MsgBox("Se Generó correctamente la " + cmbTipo.DropDownList.GetRow.Cells(1).Text.ToString + "...!" + vbCr + "Número : " + txtNumDoc.Text.ToString, MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [GEN-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= TIPOS  ================================================
            dtTipos = New DataTable
            dtTipos.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtTipos.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))

            If Session.CodPerfil = "09" Then
                dtTipos.Rows.Add(New Object() {1, "Guía de Remisión"})
                dtTipos.Rows.Add(New Object() {3, "Requisiciones"})
            Else
                dtTipos.Rows.Add(New Object() {1, "Guía de Remisión"})
                dtTipos.Rows.Add(New Object() {2, "Factura al Contado"})
            End If

            cmbTipo.DataSource = dtTipos
            cmbTipo.DropDownList.DataMember = dtTipos.Columns("nombre").ToString
            cmbTipo.DropDownList.DisplayMember = dtTipos.Columns("nombre").ToString
            cmbTipo.DropDownList.ValueMember = dtTipos.Columns("codigo").ToString
            cmbTipo.DropDownList.Columns(0).DataMember = dtTipos.Columns("codigo").ToString
            cmbTipo.DropDownList.Columns(1).DataMember = dtTipos.Columns("nombre").ToString
            cmbTipo.SelectedIndex = 0
            dtTipos = Nothing

            '======================================= LOCACIONES DEL CLIENTE ================================================
            dtLocaciones = oLocacionClienteService.Mostrar(IdCliente).Tables(0)
            cmbIdLocCli.DataSource = dtLocaciones
            cmbIdLocCli.DropDownList.DataMember = dtLocaciones.Columns("Nombre").ToString
            cmbIdLocCli.DropDownList.DisplayMember = dtLocaciones.Columns("Nombre").ToString
            cmbIdLocCli.DropDownList.ValueMember = dtLocaciones.Columns("IdLocCli").ToString
            cmbIdLocCli.DropDownList.Columns(0).DataMember = dtLocaciones.Columns("IdLocCli").ToString
            cmbIdLocCli.DropDownList.Columns(1).DataMember = dtLocaciones.Columns("Nombre").ToString
            dtLocaciones = Nothing

        Catch ex As Exception
            MsgBox("ERROR [GEN-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            dtDatos = oOrdenCompraDetService.Mostrar(IdOrden).Tables(0)
            'dgvDatos.SetDataBinding(dtDatos, 0)

            ''//Datagrid agregado para solucionar el problema de Columna Despacho q seteaba 0
            dgvPrueba.DataSource = dtDatos

            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvPrueba.Rows.Count > 0 Then
                If IsDBNull(dgvPrueba.CurrentRow.Cells(0).Value) = False Then
                    codigo = dgvPrueba.CurrentRow.Cells("Item").Value
                End If
            End If
            dtDatos = Nothing
            'listaDatos()
            If dgvPrueba.Rows.Count > 0 And codigo.Trim.Length > 0 Then
                dgvPrueba.CurrentRow.Cells("Despacho").Value = 0
                'RowPossesion(dgvDatos, dtDatos, "Item", codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-04]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub seleccionaTodos(ByVal condicion As Boolean)
        ''//Codigo Comentado agregado para solucionar el problema de Columna Despacho q seteaba 0
        'For i As Integer = 0 To dtDatos.Rows.Count - 1
        '    If condicion = True Then
        '        dgvDatos.GetRow(i).Cells("Despacho").Text = dgvDatos.GetRow(i).Cells("CanPen").Text
        '    Else
        '        dgvDatos.GetRow(i).Cells("Despacho").Text = 0
        '    End If
        'Next
        For i As Integer = 0 To dtDatos.Rows.Count - 1
            If condicion = True Then
                dgvPrueba.Rows(i).Cells("Despacho").Value = dgvPrueba.Rows(i).Cells("CanPen").Value
            Else
                dgvPrueba.Rows(i).Cells("Despacho").Value = 0
            End If
        Next
    End Sub
    Private Function actualizaListaDetalle() As Integer
        Dim nroItem As Integer = 0
        For i As Integer = 0 To dtDatos.Rows.Count - 1
            dtDatos.Rows(i).Item(13) = dgvPrueba.Rows(i).Cells("Despacho").Value
            If toNumber(dtDatos.Rows(i).Item(13)) > 0 Then
                nroItem = nroItem + 1
            End If
        Next
        Return nroItem
    End Function
    Private Sub desactivar()
        txtNumDoc.ReadOnly = True
        cmbIdLocCli.ReadOnly = True
    End Sub
    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()
    End Sub
    Private Sub miSeleccionarTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeleccionarTodo.Click
        seleccionaTodos(True)
    End Sub
    Private Sub miSeterCEROTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeterCEROTodos.Click
        seleccionaTodos(False)
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GENERAR la " + cmbTipo.DropDownList.GetRow.Cells(1).Text.ToString + " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
            If actualizaListaDetalle() > 0 Then
                GenerarDocumento()
            End If
        Else
            MsgBox("Debe despachar por lo menos un item.", MsgBoxStyle.Exclamation)
        End If

    End Sub
    Private Sub cmbTipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.ValueChanged
        txtNumDoc.Text = oOrdenCompraService.SugerirNumero(cmbTipo.Value, IdLocacion)
        If cmbTipo.Value = "3" Then
            cmbIdLocCli.ReadOnly = True
        Else
            cmbIdLocCli.ReadOnly = False
        End If
    End Sub
    Private Sub dgvDatos_CellEditCanceled(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.CellEditCanceled
        If dgvDatos.RowCount < 1 Then
        ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
        ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
        Else
            dgvDatos.CurrentRow.Cells("Despacho").Text = 0
        End If
    End Sub
    Private Sub dgvDatos_CellUpdated(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.CellUpdated
        If toNumber(IdOrden) = 0 Then
            MsgBox("Debe Ingresar el código de la O.C.", MsgBoxStyle.Information, "Información")
            actualizar()
        ElseIf toNumber(dgvDatos.CurrentRow.Cells("Despacho").Text) > toNumber(dgvDatos.CurrentRow.Cells("CanPen").Text) Then
            MsgBox("El cantidad a despachar esta fuera de rango.", MsgBoxStyle.Information, "Información")
            actualizar()
        Else

        End If
    End Sub

    Private Sub dgvPrueba_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrueba.CellEndEdit
        If toNumber(IdOrden) = 0 Then
            MsgBox("Debe Ingresar el código de la O.C.", MsgBoxStyle.Information, "Información")
            actualizar()
        ElseIf toNumber(dgvPrueba.CurrentRow.Cells("Despacho").Value) > toNumber(dgvPrueba.CurrentRow.Cells("CanPen").Value) Then
            MsgBox("El cantidad a despachar esta fuera de rango.", MsgBoxStyle.Information, "Información")
            actualizar()
        Else
        End If
    End Sub

    Private Sub dgvPrueba_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrueba.CellValueChanged
        '    If toNumber(IdOrden) = 0 Then
        '        MsgBox("Debe Ingresar el código de la O.C.", MsgBoxStyle.Information, "Información")
        '        actualizar()
        '    ElseIf toNumber(dgvPrueba.CurrentRow.Cells("Despacho").Value) > toNumber(dgvPrueba.CurrentRow.Cells("CanPen").Value) Then
        '        MsgBox("El cantidad a despachar esta fuera de rango.", MsgBoxStyle.Information, "Información")
        '        actualizar()
        '    Else
        '    End If
    End Sub


    Private Sub dgvPrueba_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgvPrueba.RowPrePaint
        'If toNumber(IdOrden) = 0 Then
        '    MsgBox("Debe Ingresar el código de la O.C.", MsgBoxStyle.Information, "Información")
        '    actualizar()
        'ElseIf toNumber(dgvPrueba.CurrentRow.Cells("Despacho").Value) > toNumber(dgvPrueba.CurrentRow.Cells("CanPen").Value) Then
        '    MsgBox("El cantidad a despachar esta fuera de rango.", MsgBoxStyle.Information, "Información")
        '    actualizar()
        'Else

        'End If
    End Sub
End Class
