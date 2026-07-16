Imports System.ServiceModel
Imports System.Windows.Forms

Public Class frmPedidoImportacionActualizarRecibido

    Private oPedidoImportDetService As New PedidoImportDetService.PedidoImportDetServiceClient
    Private oPedidoImportService As New PedidoImportService.PedidoImportServiceClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================

    Private dtProveedores As DataTable
    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                txtEmbarque.KeyPress _
 _
 _
 _
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
        dgvDatos.Anchor = AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        llenarCombos()
        enableOpciones()
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPedidoImportDetService.Close()
            oPedidoImportService.Close()
        Catch ex As TimeoutException
            oPedidoImportDetService.Abort()
            oPedidoImportService.Abort()
        Catch ex As CommunicationException
            oPedidoImportDetService.Abort()
            oPedidoImportService.Abort()
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                  txtEmbarque.KeyUp

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
        dgvPrueba.Columns(8).ReadOnly = False


    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
        Try
            tabla.DefaultView.Sort = nombreCampo
            lista.Row = dtDatos.DefaultView.Find(codigo)
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            'If toNumber(IdOrden) = 0 Then
            '    MsgBox("Debe Ingresrar el código de la O.C. ", MsgBoxStyle.Information, "Información")
            '    Return False
            'ElseIf toNumber(txtNumDoc.Text) = 0 And cmbTipo.Value <> 3 Then
            '    MsgBox("Debe Ingresar número del nuevo documento.", MsgBoxStyle.Information, "Información")
            '    txtNumDoc.BackColor = Color.Red
            '    txtNumDoc.Focus()
            '    Return False
            'ElseIf toBlank(txtFecDoc.Text) = "" Then
            '    MsgBox("Debe Ingresar la fecha del nuevo documento", MsgBoxStyle.Information, "Información")
            '    txtFecDoc.BackColor = Color.Red
            '    txtFecDoc.Focus()
            '    Return False
            'ElseIf oMaestroService.MostrarTipoCambio("US", txtFecDoc.Text) = 0 Then
            '    MsgBox("Esta fecha no tiene tipo de cambio, Tenga cuidado...")
            '    txtFecDoc.BackColor = Color.Red
            '    txtFecDoc.Focus()
            '    Return False
            'ElseIf cmbIdLocCli.DropDownList.RowCount > 0 And toNumber(cmbIdLocCli.Value) = 0 And cmbTipo.Value <> 3 Then
            '    MsgBox("Debe ingresar la locación del cliente", MsgBoxStyle.Information, "Información")
            '    cmbIdLocCli.Focus()
            '    Return False
            '    'ElseIf cmbTipo.Value <> 4 And toNumber(cmbIdLocCli.Value) = 0 Then
            '    '    MsgBox("Debe ingresar la locación del cliente", MsgBoxStyle.Information, "Información")
            '    '    cmbIdLocCli.Focus()
            '    '    Return False
            'ElseIf state_button = True And oOrdenCompraService.Estado(IdOrden) = "PROCESADO" Then
            '    MsgBox("No puede generar el documento...!" + vbCr + "Debido que la O.C. esta PROCESADO...!!", MsgBoxStyle.Information, "Información")
            '    Return False
            'Else
            Return True
            'End If
        Catch ex As Exception
            MsgBox("ERROR [GEN-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function


    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    'Private Function ValidaCampos() As Boolean
    '    Try
    '        If toNumber(IdOrden) = 0 Then
    '            MsgBox("Debe Ingresrar el código de la O.C. ", MsgBoxStyle.Information, "Información")
    '            Return False
    '        ElseIf toNumber(txtEmbarque.Text) = 0 And cmbTipo.Value <> 3 Then
    '            MsgBox("Debe Ingresar número del nuevo documento.", MsgBoxStyle.Information, "Información")
    '            txtEmbarque.BackColor = Color.Red
    '            txtEmbarque.Focus()
    '            Return False
    '        ElseIf toBlank(txtFecDoc.Text) = "" Then
    '            MsgBox("Debe Ingresar la fecha del nuevo documento", MsgBoxStyle.Information, "Información")
    '            txtFecDoc.BackColor = Color.Red
    '            txtFecDoc.Focus()
    '            Return False
    '        ElseIf oMaestroService.MostrarTipoCambio("US", txtFecDoc.Text) = 0 Then
    '            MsgBox("Esta fecha no tiene tipo de cambio, Tenga cuidado...")
    '            txtFecDoc.BackColor = Color.Red
    '            txtFecDoc.Focus()
    '            Return False
    '        ElseIf cmbIdLocCli.DropDownList.RowCount > 0 And toNumber(cmbIdLocCli.Value) = 0 And cmbTipo.Value <> 3 Then
    '            MsgBox("Debe ingresar la locación del cliente", MsgBoxStyle.Information, "Información")
    '            cmbIdLocCli.Focus()
    '            Return False
    '            'ElseIf cmbTipo.Value <> 4 And toNumber(cmbIdLocCli.Value) = 0 Then
    '            '    MsgBox("Debe ingresar la locación del cliente", MsgBoxStyle.Information, "Información")
    '            '    cmbIdLocCli.Focus()
    '            '    Return False
    '        ElseIf state_button = True And oOrdenCompraService.Estado(IdOrden) = "PROCESADO" Then
    '            MsgBox("No puede generar el documento...!" + vbCr + "Debido que la O.C. esta PROCESADO...!!", MsgBoxStyle.Information, "Información")
    '            Return False
    '        Else
    '            Return True
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR [GEN-001]: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Function
    Private Sub GenerarDocumento()
        Try
            Dim estado_process As Boolean

            For Each Fila As DataRow In dtDatos.Rows
                If Fila.Item("Recibir") > 0 Then
                    estado_process = oPedidoImportDetService.ActualizarCanRec(Fila.Item("IdDetPedidoImp"), Fila.Item("IdPedidoImp"), Fila.Item("Recibir"), toNull(Fila.Item("Observacion").ToString), Session.sCodUsu, Session.sNomPc, Session.sNomPc)

                End If
            Next


            If estado_process Then
                MsgBox("Se Actualizo correctamente los registros", MsgBoxStyle.Information)
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
            listaDatos()

        Catch ex As Exception
            MsgBox("ERROR [GEN-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= PROVEEDORES ================================================
            dtProveedores = oPedidoImportService.MostrarProveedores(Session.sCodEmp).Tables(0)
            dtProveedores.Rows.InsertAt(getRowTodos(dtProveedores), 0)
            cmbIdProveedor.DataSource = dtProveedores
            cmbIdProveedor.DropDownList.DataMember = dtProveedores.Columns("DesProv").ToString
            cmbIdProveedor.DropDownList.DisplayMember = dtProveedores.Columns("DesProv").ToString
            cmbIdProveedor.DropDownList.ValueMember = dtProveedores.Columns("IdProveedor").ToString
            cmbIdProveedor.DropDownList.Columns(0).DataMember = dtProveedores.Columns("IdProveedor").ToString
            cmbIdProveedor.DropDownList.Columns(1).DataMember = dtProveedores.Columns("DesProv").ToString
            cmbIdProveedor.SelectedIndex = 0
            dtProveedores = Nothing

        Catch ex As Exception
            MsgBox("ERROR [GEN-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        fila(1) = "(Todos)"
        Return fila
    End Function
    Private Sub listaDatos()
        Try
            dtDatos = oPedidoImportDetService.MostrarPendientes(Session.sCodEmp, cmbIdProveedor.Value, txtEmbarque.Text, txtNumPed.Text, txtNumFactura.Text, txtCodMer.Text).Tables(0)
            'dgvDatos.SetDataBinding(dtDatos, 0)

            ''//Datagrid agregado para solucionar el problema de Columna Despacho q seteaba 0
            dgvPrueba.DataSource = dtDatos

            lblTotal.Text = "Total Registros : " & dtDatos.Rows.Count.ToString

            'enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvPrueba.Rows.Count > 0 Then
                If IsDBNull(dgvPrueba.CurrentRow.Cells(0).Value) = False Then
                    codigo = dgvPrueba.CurrentRow.Cells("IdDetPedidoImp").Value
                End If
            End If
            dtDatos = Nothing
            'listaDatos()
            If dgvPrueba.Rows.Count > 0 And codigo.Trim.Length > 0 Then
                dgvPrueba.CurrentRow.Cells("Recibir").Value = 0
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
                dgvPrueba.Rows(i).Cells("Recibir").Value = dgvPrueba.Rows(i).Cells("CanPen").Value
            Else
                dgvPrueba.Rows(i).Cells("Recibir").Value = 0
            End If
        Next
    End Sub
    Private Function actualizaListaDetalle() As Integer
        Dim nroItem As Integer = 0
        For Each Fila As DataRow In dtDatos.Rows
            If Fila.Item("Recibir") > 0 Then
                nroItem = nroItem + 1
            End If
        Next
        Return nroItem
    End Function


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
        If MsgBox("¿Está seguro de ACTUALIZAR las Cantidades ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
            If actualizaListaDetalle() > 0 Then
                GenerarDocumento()
            Else
                MsgBox("Debe recibir por lo menos un item.", MsgBoxStyle.Exclamation)
            End If
        End If

    End Sub

    Private Sub dgvDatos_CellEditCanceled(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.CellEditCanceled
        If dgvDatos.RowCount < 1 Then
        ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
        ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
        Else
            dgvDatos.CurrentRow.Cells("Recibir").Text = 0
        End If
    End Sub
    Private Sub dgvDatos_CellUpdated(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.CellUpdated
        If toNumber(dgvDatos.CurrentRow.Cells("Recibir").Text) > toNumber(dgvDatos.CurrentRow.Cells("CanPen").Text) Then
            MsgBox("La cantidad a Recibir esta fuera de rango.", MsgBoxStyle.Information, "Información")
            actualizar()

        End If
    End Sub

    Private Sub dgvPrueba_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrueba.CellEndEdit
        If toNumber(dgvPrueba.CurrentRow.Cells("Recibir").Value) > toNumber(dgvPrueba.CurrentRow.Cells("CanPen").Value) Then
            MsgBox("La cantidad a Recibir esta fuera de rango.", MsgBoxStyle.Information, "Información")
            actualizar()

        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click, cmbIdProveedor.ValueChanged, txtEmbarque.TextChanged, txtNumPed.TextChanged, txtNumFactura.TextChanged, txtCodMer.TextChanged
        listaDatos()
    End Sub

    Private Sub miObservacionMasiva_Click(sender As Object, e As EventArgs) Handles miObservacionMasiva.Click
        Try
            Dim frm As New frmPedidoImportacion_ActualizarRecibidoObservacion
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                For i As Integer = 0 To dtDatos.Rows.Count - 1
                    dgvPrueba.Rows(i).Cells("Observacion").Value = frm.observacion
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class
