Imports System.Windows.Forms
Imports System.ServiceModel

Public Class frmCotizacion_GenerarDocumento
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oCotizacionService As New CotizacionService.CotizacionServiceClient
    Private oCotizacionDetService As New CotizacionDetalleService.CotizacionDetalleServiceClient
    Private oLocacionClienteService As New LocacionClienteService.LocacionClienteServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oJobService As New JobService.JobServiceClient
    Private dtDatos As DataTable
    Private dtDetalles As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdCotizacion As Integer
    Public IdLocacion As Integer
    Public IdCliente As Integer
    Private DespachoTotal As Boolean = False

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Delete Then
            txtNumDoc.Select()
        End If
    End Sub
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

    Private Sub frmCotizacion_GenerarDocumento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.cargaEstiloDataDrid(dgvDetalles)

        dgvDetalles.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        Me.CancelButton = Me.btnCancelar
        'Dim estilo As New Estilo
        'estilo.cargaEstiloGridExt(dgvDatos)
        dgvDetalles.Columns(7).ReadOnly = False
        txtFecDoc.Value = Session.sFecha
        llenarCombos()
        listaDatos()

        If oCotizacionService.Estado(IdCotizacion) = "ATENDIDO" Then
            btnGuardar.Enabled = False
        Else
            btnGuardar.Enabled = True
            cmbTipo.Select()
        End If

    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oCotizacionService.Close()
            oMaestroService.Close()
            oLocacionClienteService.Close()
            oCotizacionDetService.Close()
            oJobService.Close()
        Catch ex As TimeoutException
            oCotizacionService.Abort()
            oMaestroService.Abort()
            oLocacionClienteService.Abort()
            oCotizacionDetService.Abort()
            oJobService.Abort()
        Catch ex As CommunicationException
            oCotizacionService.Abort()
            oMaestroService.Abort()
            oLocacionClienteService.Abort()
            oCotizacionDetService.Abort()
            oJobService.Abort()
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
        If oCotizacionService.Estado(IdCotizacion) = "ATENDIDO" Then
            btnGuardar.Enabled = False
            miSeleccionarTodo.Enabled = False
            miSeterCEROTodos.Enabled = False
            ' dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            dgvDetalles.ReadOnly = True
        Else
            btnGuardar.Enabled = True
            miSeleccionarTodo.Enabled = True
            miSeterCEROTodos.Enabled = True

            dgvDetalles.ReadOnly = False
            dgvDetalles.Columns(0).ReadOnly = True
            dgvDetalles.Columns(1).ReadOnly = True
            dgvDetalles.Columns(2).ReadOnly = True
            dgvDetalles.Columns(3).ReadOnly = True
            dgvDetalles.Columns(4).ReadOnly = True
            dgvDetalles.Columns(5).ReadOnly = True
            dgvDetalles.Columns(6).ReadOnly = True
            dgvDetalles.Columns(7).ReadOnly = False
            dgvDetalles.Columns(8).ReadOnly = True
            'dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[True]
            'dgvDatos.RootTable.Columns(1).EditType = Janus.Windows.GridEX.EditType.NoEdit
            'dgvDatos.RootTable.Columns(2).EditType = Janus.Windows.GridEX.EditType.NoEdit
            'dgvDatos.RootTable.Columns(3).EditType = Janus.Windows.GridEX.EditType.NoEdit
            'dgvDatos.RootTable.Columns(4).EditType = Janus.Windows.GridEX.EditType.NoEdit
            'dgvDatos.RootTable.Columns(5).EditType = Janus.Windows.GridEX.EditType.NoEdit
            'dgvDatos.RootTable.Columns(6).EditType = Janus.Windows.GridEX.EditType.NoEdit
            'dgvDatos.RootTable.Columns(7).EditType = Janus.Windows.GridEX.EditType.TextBox
        End If
    End Sub
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdCotizacion) = 0 Then
                MsgBox("Debe Ingresar el código de la Cotización. ", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf txtNumDoc.Text = "" Then
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
            ElseIf cmbIdLocCli.DropDownList.RowCount > 0 And toNumber(cmbIdLocCli.Value) = 0 And cmbTipo.Value <> 4 Then
                MsgBox("Debe ingresar la locación del cliente", MsgBoxStyle.Information, "Información")
                cmbIdLocCli.Focus()
                Return False
                'ElseIf cmbTipo.Value <> 4 And toNumber(cmbIdLocCli.Value) = 0 Then
                '    MsgBox("Debe ingresar la locación del cliente", MsgBoxStyle.Information, "Información")
                '    cmbIdLocCli.Focus()
                '    Return False
            ElseIf state_button = True And oCotizacionService.Estado(IdCotizacion) = "PROCESADO" Then
                MsgBox("No puede generar el documento...!" + vbCr + "Debido que la cotización esta PROCESADO...!!", MsgBoxStyle.Information, "Información")
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

            Dim dtTable As DataTable
            Dim row As DataRow

            dtTable = dtDetalles.Copy
            dtTable.Clear()
            For i As Integer = 0 To dtDetalles.Rows.Count - 1
                If dgvDetalles.Rows(i).Cells("Despachar").Value > "0" Then
                    row = dtTable.NewRow
                    row(0) = dtDetalles.Rows(i).Item(0)
                    row(1) = dtDetalles.Rows(i).Item(1)
                    row(2) = dtDetalles.Rows(i).Item(2)
                    row(3) = dtDetalles.Rows(i).Item(3)
                    row(4) = dtDetalles.Rows(i).Item(4)
                    row(5) = dtDetalles.Rows(i).Item(5)
                    row(6) = dtDetalles.Rows(i).Item(6)
                    row(7) = dtDetalles.Rows(i).Item(7)
                    row(8) = dtDetalles.Rows(i).Item(8)
                    row(9) = dtDetalles.Rows(i).Item(9)
                    row(10) = dtDetalles.Rows(i).Item(10)
                    row(11) = dtDetalles.Rows(i).Item(11)
                    row(12) = dtDetalles.Rows(i).Item(12)
                    row(13) = dtDetalles.Rows(i).Item(13)
                    row(14) = dtDetalles.Rows(i).Item(14)
                    row(15) = dtDetalles.Rows(i).Item(15)
                    row(16) = dgvDetalles.Rows(i).Cells("Despachar").Value
                    row(17) = dtDetalles.Rows(i).Item(17)
                    row(18) = dtDetalles.Rows(i).Item(18)
                    row(19) = dtDetalles.Rows(i).Item(19)
                    row(20) = dtDetalles.Rows(i).Item(20)
                    row(21) = dtDetalles.Rows(i).Item(21)
                    row(22) = dtDetalles.Rows(i).Item(22)
                    row(23) = dtDetalles.Rows(i).Item(23)
                    row(24) = dtDetalles.Rows(i).Item(24)
                    row(25) = dtDetalles.Rows(i).Item(25)
                    dtTable.Rows.Add(row)
                End If
            Next

            Dim estado_process As Integer
            If cmbTipo.Value <> 4 Then
                estado_process = oCotizacionService.GenerarDocumento(cmbTipo.Value, IdCotizacion, toNumber(cmbIdLocCli.Value), toNumber(txtNumDoc.Text), txtFecDoc.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp, dtTable, txtNumJob.Text.ToString)
            Else
                estado_process = oCotizacionService.GenerarOrden(IdCotizacion, txtFecDoc.Text, txtNumDoc.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp, DespachoTotal, IIf(cbDespacharTodo.Checked = True, Nothing, dtTable))
            End If

            type_process = "insert"
            If estado_process > 0 Then
                MsgBox("Se generó correctamente la " + cmbTipo.DropDownList.GetRow.Cells(1).Text.ToString + "...!" + vbCr + "Número : " + txtNumDoc.Text.ToString, MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [GEN-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= TIPOS  ================================================
            dtDatos = New DataTable
            dtDatos.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtDatos.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtDatos.Rows.Add(New Object() {1, "Guía de Remisión"})
            dtDatos.Rows.Add(New Object() {2, "Factura"})
            dtDatos.Rows.Add(New Object() {3, "Boleta"})
            dtDatos.Rows.Add(New Object() {4, "Orden Compra"})

            cmbTipo.DataSource = dtDatos
            cmbTipo.DropDownList.DataMember = dtDatos.Columns("nombre").ToString
            cmbTipo.DropDownList.DisplayMember = dtDatos.Columns("nombre").ToString
            cmbTipo.DropDownList.ValueMember = dtDatos.Columns("codigo").ToString
            cmbTipo.DropDownList.Columns(0).DataMember = dtDatos.Columns("codigo").ToString
            cmbTipo.DropDownList.Columns(1).DataMember = dtDatos.Columns("nombre").ToString
            cmbTipo.SelectedIndex = 0
            dtDatos = Nothing
            '======================================= LOCACIONES DEL CLIENTE ================================================
            dtDatos = oLocacionClienteService.Mostrar(IdCliente).Tables(0)
            cmbIdLocCli.DataSource = dtDatos
            cmbIdLocCli.DropDownList.DataMember = dtDatos.Columns("Nombre").ToString
            cmbIdLocCli.DropDownList.DisplayMember = dtDatos.Columns("Nombre").ToString
            cmbIdLocCli.DropDownList.ValueMember = dtDatos.Columns("IdLocCli").ToString
            cmbIdLocCli.DropDownList.Columns(0).DataMember = dtDatos.Columns("IdLocCli").ToString
            cmbIdLocCli.DropDownList.Columns(1).DataMember = dtDatos.Columns("Nombre").ToString
            dtDatos = Nothing
        Catch ex As Exception
            MsgBox("ERROR [GEN-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
        Try
            tabla.DefaultView.Sort = nombreCampo
            lista.Row = dtDatos.DefaultView.Find(codigo)
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            dtDetalles = oCotizacionDetService.Mostrar(IdCotizacion).Tables(0)
            'dgvDatos.SetDataBinding(dtDetalles, 0)
            dgvDetalles.DataSource = dtDetalles            
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub seleccionaTodos(ByVal condicion As Boolean)
        'For i As Integer = 0 To dtDetalles.Rows.Count - 1
        '    If condicion = True Then
        '        dgvDatos.GetRow(i).Cells("Despachar").Text = dgvDatos.GetRow(i).Cells("CanPen").Text
        '    Else
        '        dgvDatos.GetRow(i).Cells("Despachar").Text = 0
        '    End If
        'Next
        For i As Integer = 0 To dtDetalles.Rows.Count - 1
            If condicion = True Then
                dgvDetalles.Rows(i).Cells("Despachar").Value = dgvDetalles.Rows(i).Cells("CanPen").Value
            Else
                dgvDetalles.Rows(i).Cells("Despachar").Value = 0
            End If
        Next

    End Sub
    Private Sub actualizar()
        Try
            'Dim codigo As String = ""
            'If dgvDatos.RowCount > 0 Then
            '    If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
            '        codigo = dgvDatos.CurrentRow.Cells("Item").Text
            '    End If
            'End If
            'dtDatos = Nothing
            'listaDatos()
            'If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            '    RowPossesion(dgvDatos, dtDatos, "Item", codigo)
            'End If

            Dim codigo As String = ""
            If dgvDetalles.Rows.Count > 0 Then
                If IsDBNull(dgvDetalles.CurrentRow.Cells(0).Value) = False Then
                    codigo = dgvDetalles.CurrentRow.Cells("Item").Value
                End If
            End If
            dtDetalles = Nothing
            'listaDatos()
            If dgvDetalles .Rows.Count > 0 And codigo.Trim.Length > 0 Then
                dgvDetalles.CurrentRow.Cells("Despachar").Value = 0
                'RowPossesion(dgvDatos, dtDatos, "Item", codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-04]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Function actualizaListaDetalle() As Integer
        'Dim nroItem As Integer = 0
        'For i As Integer = 0 To dtDetalles.Rows.Count - 1
        '    dtDetalles.Rows(i).Item("Despachar") = dgvDatos.GetRow(i).Cells("Despachar").Text
        '    If toNumber(dtDetalles.Rows(i).Item("Despachar")) > 0 Then
        '        nroItem = nroItem + 1
        '    End If
        'Next
        'Return nroItem
        Dim nroItem As Integer = 0
        For i As Integer = 0 To dtDetalles.Rows.Count - 1
            dtDetalles.Rows(i).Item(16) = dgvDetalles.Rows(i).Cells("Despachar").Value
            If toNumber(dtDetalles.Rows(i).Item("Despachar")) > 0 Then
                nroItem = nroItem + 1
            End If
        Next
        Return nroItem
     
    End Function
    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GENERAR la " + cmbTipo.DropDownList.GetRow.Cells(1).Text.ToString + " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
            If actualizaListaDetalle() > 0 Then
                GenerarDocumento()
            Else
                MsgBox("Debe despachar por lo menos un item.", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub
    Private Sub cmbTipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.ValueChanged
        If cmbTipo.Value <> 4 Then
            txtNumDoc.Text = oCotizacionService.SugerirNumero(cmbTipo.Value, IdLocacion)
            cmbIdLocCli.Enabled = True
            cbDespacharTodo.Visible = False
        Else
            txtNumDoc.Text = ""
            cmbIdLocCli.Enabled = False
            cbDespacharTodo.Visible = True
        End If
    End Sub

    Private Sub miSeleccionarTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeleccionarTodo.Click
        seleccionaTodos(True)
    End Sub

    Private Sub miSeterCEROTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeterCEROTodos.Click
        seleccionaTodos(False)
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()
    End Sub

    'Private Sub dgvDatos_CellEditCanceled(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.CellEditCanceled
    '    If dgvDatos.RowCount < 1 Then
    '    ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
    '    ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
    '    Else
    '        dgvDatos.CurrentRow.Cells("Despachar").Text = 0
    '    End If
    'End Sub

    'Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
    '    'If Not (Char.IsDigit(e.KeyChar)) Then
    '    '    e.Handled = True
    '    'End If
    '    If Asc(e.KeyChar) = 3 Then
    '        e.Handled = False
    '    Else
    '        e.Handled = Not (e.KeyChar = "")
    '    End If
    'End Sub

    Private Sub cbDespacharTodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDespacharTodo.CheckedChanged
        'If cbDespacharTodo.Checked = True Then
        '    miSeleccionarTodo_Click(sender, e)
        '    dgvDatos.RootTable.Columns(7).EditType = Janus.Windows.GridEX.EditType.NoEdit
        '    DespachoTotal = True
        'ElseIf cbDespacharTodo.Checked = False Then
        '    dgvDatos.RootTable.Columns(7).EditType = Janus.Windows.GridEX.EditType.TextBox
        '    DespachoTotal = False
        'End If

        If cbDespacharTodo.Checked = True Then
            miSeleccionarTodo_Click(sender, e)
            dgvDetalles.Columns(7).ReadOnly = True
            DespachoTotal = True
        ElseIf cbDespacharTodo.Checked = False Then
            dgvDetalles.Columns(7).ReadOnly = False
            DespachoTotal = False
        End If
    End Sub

    Private Sub dgvDetalles_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalles.CellEndEdit
        If toNumber(IdCotizacion) = 0 Then
            MsgBox("Debe Ingresar el código de la O.C.", MsgBoxStyle.Information, "Información")
            actualizar()
        ElseIf toNumber(dgvDetalles.CurrentRow.Cells("Despachar").Value) > toNumber(dgvDetalles.CurrentRow.Cells("CanPen").Value) Then
            MsgBox("El cantidad a despachar esta fuera de rango.", MsgBoxStyle.Information, "Información")
            actualizar()
        Else
        End If
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Try
            Dim frm As New frmBuscarJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.cod_job) <> Nothing Then
                    txtNumJob.Text = frm.cod_job
                    'CalcularMontos()
                    'txtIgv.Focus()
                    'cmbMoneda.Focus()
                Else
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                    'ElseIf oJobService.Estado(txtNumJob.Text) = 16 Then
                    '    MsgBox("Número de Job Liquidado, Verifique")
                    '    txtNumJob.Text = ""
                    '    txtNumJob.Focus()
                Else
                    cmbIdLocCli.Focus()
                    'txtIgv.Focus()
                    'cmbMoneda.Focus()
                End If
            Else
                cmbIdLocCli.Focus()
                'txtIgv.Focus()
                'cmbMoneda.Focus()
            End If
        End If
    End Sub

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        Try
            If Len(Trim(txtNumJob.Text)) > 0 Then

                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                    'ElseIf oJobService.Estado(txtNumJob.Text) = 16 Then
                    '    MsgBox("Número de Job Liquidado, Verifique")
                    '    txtNumJob.Text = ""
                    '    txtNumJob.Focus()
                Else
                    cmbIdLocCli.Focus()
                    'txtIgv.Focus()
                    'cmbMoneda.Focus()
                End If
            Else
                cmbIdLocCli.Focus()
                'txtIgv.Focus()
                'cmbMoneda.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA OT : " + ex.Message)
        End Try
    End Sub
End Class
