Imports System.Windows.Forms

Public Class frmMemoTransferenciaInterna
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMaestroService As New MaestroService.MaestroClient
    Private oMemoService As New MemoService.MemoServiceClient
    Private oMemoDetalleService As New MemoDetalleService.MemoDetalleServiceClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdMemo As Integer
    Private IdPer As Integer
    Public IdLocacion As Integer
    Private IdCliente As Integer
    Public TipMov As String
    Public IdSerieDoc As Integer
    Public AbrDoc As String

    Private dtTipos As DataTable
    Private dtMonedas As DataTable
    Private dtMotivos As DataTable

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtObservacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacion.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnModificarObservacion.Enabled = True Then
                btnModificarObservacion_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnGuardar.Enabled = True Then
                btnGuardar.Select()
                btnGuardar_Click(sender, e)

            End If
        End If
    End Sub
    Private Sub txtNumDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnBuscarCliente.Focus()
        End If
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarJob.Enabled = True Then
                btnBuscarJob_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                          txtFecDoc.KeyPress _
                          , txtNumJob.KeyPress _
                          , txtIgv.KeyPress _
                          , cmbCodMon.KeyPress _
                          , txtTipoCambio.KeyPress _
                          , txtCliente.KeyPress _
                          , txtTotalNeto.KeyPress _
                          , txtTotalIGV.KeyPress _
                          , txtTotalPrecio.KeyPress _
                          , txtTotalDescuento.KeyPress _
                          , txtTotal.KeyPress
        'txtObservacion.KeyPress _
        'txtNumDoc.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmMemoTransferenciaInterna_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        llenarCombos()

        If state_button Then    'Modificar

            txtNumDoc.ReadOnly = True
            txtNumDoc.TabStop = False
            ObtenerRegistro()
            btnBuscarJob.Enabled = False
            txtObservacion.ReadOnly = True
            btnModificarObservacion.Enabled = False
            gbEstado.Visible = True
            btnBuscarCliente.Enabled = False
            txtFecDoc.ReadOnly = True
            txtFecDoc.BackColor = System.Drawing.SystemColors.Control
            'cmbIdSerieDoc.ReadOnly = True
            'cmbIdSerieDoc.BackColor = System.Drawing.SystemColors.Control
            cmbCodMon.ReadOnly = True
            cmbCodMon.BackColor = System.Drawing.SystemColors.Control
            cmbMotMtd.ReadOnly = True
            cmbMotMtd.BackColor = System.Drawing.SystemColors.Control
            listaDatos()
            enableOpciones()
            Me.Text = "MEMO T.I. Nº " + Chr(34) + txtNumDoc.Text.ToString + Chr(34)
            dgvDatos.Select()
        Else                    'Nuevo

            'txtNumDoc.ReadOnly = True
            'txtNumDoc.TabStop = False

            gbEstado.Visible = False
            btnBuscarCliente.Enabled = True
            cmbCodMon.ReadOnly = False
            cmbCodMon.Value = "US"
            cmbCodMon.BackColor = System.Drawing.SystemColors.Control
            Me.Size = New System.Drawing.Size(850, 210)
            Me.Text = "Registrar un nuevo MEMO T.I."
            txtNumDoc.Select()
        End If

        estilo.cargaEstiloGridExt(dgvDatos)
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oMemoService) = False Then
                oMemoService.Close()
            End If
            If isClosed(oMemoDetalleService) = False Then
                oMemoDetalleService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                            txtObservacion.KeyUp _
                          , txtNumJob.KeyUp _
                          , txtIgv.KeyUp _
                          , txtTipoCambio.KeyUp _
                          , txtCliente.KeyUp _
                          , txtFecDoc.KeyUp _
                          , txtNumDoc.KeyUp _
                          , txtTotalNeto.KeyUp _
                          , txtTotalIGV.KeyUp _
                          , txtTotalPrecio.KeyUp _
                          , txtTotalDescuento.KeyUp _
                          , txtTotal.KeyUp
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
    Private Sub setColor_BlankCombo(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                               cmbCodMon.ValueChanged _
                          , cmbMotMtd.ValueChanged
        Try
            Dim campo As New Object
            If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.MultiColumnCombo" Then
                campo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
            End If
            campo = sender
            If toNumber(campo.value) <> 0 Or toNull(campo.Value) <> Nothing Then
                campo.BackColor = Color.White
            Else
                campo.BackColor = Color.Red
            End If

            '////MOSTRAR MOTIVO DEL MTD///////////


            If AbrDoc = "MTD" Then
                cmbMotMtd.Visible = True
                lblMotivo.Visible = True
            Else
                cmbMotMtd.Visible = False
                lblMotivo.Visible = False
            End If
            'If IdSerieDoc.SelectedIndex >= 0 Then
            '    If dtTipos.Rows(IdSerieDoc.SelectedIndex).Item("AbrDoc") = "MTD" Then
            '        cmbMotMtd.Visible = True
            '        lblMotivo.Visible = True
            '    Else
            '        cmbMotMtd.Visible = False
            '        lblMotivo.Visible = False
            '    End If
            'End If
            '///////////////////////////////////
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
            e.KeyChar = Chr(0)
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
            fila(1) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdMemoDet").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then

            miModificar.Enabled = False
            miEliminar.Enabled = False
            btnGuardar.Enabled = False
            btnDeshacer.Enabled = False
        Else
            If state_button = True And toBlank(lblEstado.Text) = "GENERADO" Then

                btnGuardar.Enabled = False
                btnEditar.Enabled = True
                btnDeshacer.Enabled = False
                miEliminar.Enabled = True
                miModificar.Enabled = True

            ElseIf state_button = True And toBlank(lblEstado.Text) = "IMPRESO" Then

                miNuevo.Enabled = False
                miEliminar.Enabled = False
                miActualizar.Enabled = False
                miModificar.Enabled = False

                btnGuardar.Enabled = False
                btnEditar.Enabled = False
                btnDeshacer.Enabled = False

            Else
                miNuevo.Enabled = False
                miEliminar.Enabled = False
                btnGuardar.Enabled = False

            End If
        End If
    End Sub
    Private Sub limpiaOpcionesBusqueda(ByVal TipoMov As String)
        state_Search = False
        If TipoMov = "H" Then
            rbIngreso.Checked = True
        Else
            rbSalida.Checked = True
        End If
        state_Search = True
    End Sub
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If state_button = True And toNumber(IdMemo) = 0 Then
                MsgBox("Debe Ingresar el código del Memo.", MsgBoxStyle.Information, "Información")
                Return False

            ElseIf toBlank(txtFecDoc.Text) = "" Then
                MsgBox("Debe Ingresar el la fecha.", MsgBoxStyle.Information, "Información")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
            ElseIf toNumber(IdSerieDoc) = 0 Then
                MsgBox("Debe Ingresar el tipo de vale.", MsgBoxStyle.Information, "Información")
                'cmbIdSerieDoc.BackColor = Color.Red
                'cmbIdSerieDoc.Focus()
                Return False
            ElseIf toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar el cliente ", MsgBoxStyle.Information, "Información")
                txtCliente.BackColor = Color.Red
                btnBuscarCliente.Focus()
                Return False
            ElseIf toBlank(cmbCodMon.Value) = "" Then
                MsgBox("Debe de ingresar el tipo de moneda.", MsgBoxStyle.Information, "Información")
                cmbCodMon.BackColor = Color.Red
                cmbCodMon.Focus()
                Return False
            ElseIf toBlank(cmbMotMtd.Value) = "" And state_button = False Then
                MsgBox("Debe de ingresar el motivo.", MsgBoxStyle.Information, "Información")
                cmbMotMtd.BackColor = Color.Red
                cmbMotMtd.Focus()
                Return False
            ElseIf cmbCodMon.Value <> "NS" And toDouble(txtTipoCambio.Text) <= 0 Then
                MsgBox("Tipo de cambio no puede ser CERO..", MsgBoxStyle.Information, "Información")
                txtTipoCambio.BackColor = Color.Red
                txtTipoCambio.Focus()
                Return False
            ElseIf state_button = False And oMemoService.Buscar(IdSerieDoc, toNumber(txtNumDoc.Text)) Then
                MsgBox("El Número " + txtNumDoc.Text + " del Memo T.I. ya existe...!", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf state_button = True And oMemoService.Estado(IdMemo) <> "GENERADO" Then
                MsgBox("Ya no se puede realizar modificaciones...!" + vbCr + "Debido que ya no se encuentra en el estado GENERADO...!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As MemoService.Memo)
        Try
            Dim estado_process As Integer
            estado_process = oMemoService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdMemo = estado_process
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As MemoService.Memo)
        Try
            Dim estado_process As Boolean
            estado_process = oMemoService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                desactivar()
                ObtenerRegistro()
                'Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oMemoService.Borrar(IdMemo)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As MemoService.Memo
            registro = oMemoService.MostrarPorId(IdMemo)

            IdMemo = registro.IdMemo
            IdLocacion = registro.Locacion.IdLocacion
            llenarComboTipos()

            IdSerieDoc = registro.SerieDocumento.IdSerieDoc
            txtNumDoc.Text = registro.NumDoc
            txtFecDoc.Text = registro.FecDoc
            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli
            cmbCodMon.Value = registro.Moneda.CodMon
            txtNumJob.Text = registro.NumJob
            cmbMotMtd.Value = registro.MotMtd
            txtIgv.Text = registro.Igv
            txtObservacion.Text = toBlank(registro.Observacion)
            lblEstado.Text = registro.Estado

        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            'dtTipos = oMaestroService.MostrarSerieDocumento(IdLocacion, 4, "").Tables(0)
            'cmbIdSerieDoc.DataSource = dtTipos
            'cmbIdSerieDoc.DropDownList.DataMember = dtTipos.Columns("Descripcion").ToString
            'cmbIdSerieDoc.DropDownList.DisplayMember = dtTipos.Columns("Descripcion").ToString
            'cmbIdSerieDoc.DropDownList.ValueMember = dtTipos.Columns("IdSerieDoc").ToString
            'cmbIdSerieDoc.DropDownList.Columns(0).DataMember = dtTipos.Columns("IdSerieDoc").ToString
            'cmbIdSerieDoc.DropDownList.Columns(1).DataMember = dtTipos.Columns("Descripcion").ToString
            'cmbIdSerieDoc.DropDownList.Columns(2).DataMember = dtTipos.Columns("AbrDoc").ToString

            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbCodMon.DataSource = dtMonedas
            cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing
            '======================================= TIPO DE MOVIMIENTO ================================================
            dtMotivos = New DataTable
            'dtMotivos.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtMotivos.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtMotivos.Rows.Add(New Object() {"DESARMADO"})
            dtMotivos.Rows.Add(New Object() {"ARMADO"})

            cmbMotMtd.DataSource = dtMotivos
            cmbMotMtd.DropDownList.DataMember = dtMotivos.Columns("nombre").ToString
            cmbMotMtd.DropDownList.DisplayMember = dtMotivos.Columns("nombre").ToString
            cmbMotMtd.DropDownList.ValueMember = dtMotivos.Columns("nombre").ToString
            cmbMotMtd.DropDownList.Columns(0).DataMember = dtMotivos.Columns("nombre").ToString
            'cmbMotMtd.DropDownList.Columns(1).DataMember = dtMotivos.Columns("nombre").ToString
            cmbMotMtd.SelectedIndex = 0
            dtMotivos = Nothing
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarComboTipos()
        '======================================= TIPOS  ================================================
        'dtTipos = oMaestroService.MostrarSerieDocumento(IdLocacion, 4, "").Tables(0)
        'cmbIdSerieDoc.DataSource = dtTipos
        'cmbIdSerieDoc.DropDownList.DataMember = dtTipos.Columns("Descripcion").ToString
        'cmbIdSerieDoc.DropDownList.DisplayMember = dtTipos.Columns("Descripcion").ToString
        'cmbIdSerieDoc.DropDownList.ValueMember = dtTipos.Columns("IdSerieDoc").ToString
        'cmbIdSerieDoc.DropDownList.Columns(0).DataMember = dtTipos.Columns("IdSerieDoc").ToString
        'cmbIdSerieDoc.DropDownList.Columns(1).DataMember = dtTipos.Columns("Descripcion").ToString
        'cmbIdSerieDoc.DropDownList.Columns(2).DataMember = dtTipos.Columns("AbrDoc").ToString
        'cmbIdSerieDoc.SelectedIndex = 0
        '' dtTipos = Nothing
    End Sub
    Private Sub listaDatos()
        Try

            dtDatos = oMemoDetalleService.Mostrar(IdMemo, TipMov).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)

            txtTotalPrecio.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.Memo", "TotBruto", "IdMemo", IdMemo)
            txtTotalDescuento.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.Memo", "TotDscto", "IdMemo", IdMemo)
            txtTotal.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.Memo", "TotVenta", "IdMemo", IdMemo)
            txtTotalIGV.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.Memo", "TotIgv", "IdMemo", IdMemo)
            txtTotalNeto.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.Memo", "TotNeto", "IdMemo", IdMemo)
            lblTotal.Text = "SUB TOTALES"
            lbltotalIGV.Text = "IGV"
            lblTotalNeto.Text = "TOTAL (" + oMaestroService.MostrarDato("SIGECOM.Maestro.Monedas", "AbrMon", "CodMon", oMaestroService.MostrarDato("SIGECOM.Almacen.Memo", "CodMon", "IdMemo", IdMemo)) + ")"

            enableOpciones()

        Catch ex As Exception
            MsgBox("ERROR [INFO-007]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmMemoTransferenciaInterna_AgregarDetalle
                frm.state_button = False
                frm.IdMemo = IdMemo
                frm.IdLocacion = IdLocacion
                frm.Tipo = TipMov
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    limpiaOpcionesBusqueda(frm.TipoMov)
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdMemoDet)
                    End If
                Else
                    lLog = False
                End If
            End While
            
        Catch ex As Exception
            MsgBox("ERROR [INFO-008]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("CodMer").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oMemoDetalleService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdMemoDet").Text), IdMemo)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-009]:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmMemoTransferenciaInterna_AgregarDetalle
            frm.state_button = True
            frm.IdMemoDet = dgvDatos.CurrentRow.Cells("IdMemoDet").Text
            frm.IdMemo = IdMemo
            frm.IdLocacion = IdLocacion

            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                limpiaOpcionesBusqueda(frm.TipoMov)
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdMemoDet)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-010]: " + ex.Message, MsgBoxStyle.Exclamation)
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
            ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-011]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdMemoDet").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-012]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub activar()

        btnGuardar.Enabled = True
        btnDeshacer.Enabled = True
        btnEditar.Enabled = False

        btnBuscarCliente.Enabled = True
        btnBuscarJob.Enabled = True
        btnModificarObservacion.Enabled = True

    End Sub
    Private Sub desactivar()

        txtObservacion.ReadOnly = True
        txtCliente.ReadOnly = True
        txtCliente.BackColor = System.Drawing.SystemColors.Control
        txtNumJob.ReadOnly = True
        txtNumJob.BackColor = System.Drawing.SystemColors.Control
        btnModificarObservacion.Enabled = False
        btnBuscarCliente.Enabled = False
        btnBuscarJob.Enabled = False
        btnEditar.Enabled = True
        btnGuardar.Enabled = False


        enableOpciones()
        dgvDatos.Select()
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If
        txtCliente.Select()

    End Sub

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminarDetalle()
        End If
    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()
    End Sub
    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        If state_button = True And (toBlank(lblEstado.Text) = "GENERADO" Or toBlank(lblEstado.Text) = "GN") Then
            NuevoDetalle()
        End If
    End Sub
    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub
    Private Sub cmbCodMon_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodMon.ValueChanged
        txtTipoCambio.Text = toDouble(oMaestroService.MostrarTipoCambio(cmbCodMon.Value, txtFecDoc.Text))
    End Sub
    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Dim frm As New frmBuscarJob
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.Text = frm.cod_job
        End If
        txtNumJob.Select()
    End Sub
    Private Sub btnModificarObservacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarObservacion.Click
        Dim frm As New frmMemoTransferenciaInterna_ModificarObservacion
        frm.state_button = state_button
        frm.IdMemo = IdMemo
        frm.txtObservacion.Text = toBlank(txtObservacion.Text)
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtObservacion.Text = toBlank(frm.txtObservacion.Text)
        End If
        txtObservacion.Select()
    End Sub
    'Private Sub cmbIdSerieDoc_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIdSerieDoc.ValueChanged

    '    If state_button = False Then

    '        txtNumDoc.ReadOnly = False
    '        txtNumDoc.TabStop = True
    '        txtNumDoc.Text = oMemoService.SugerirNumero(cmbIdSerieDoc.Value)
    '    End If
    'End Sub
    Private Sub txtFecDoc_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecDoc.ValueChanged
        txtTipoCambio.Text = toDouble(oMaestroService.MostrarTipoCambio(cmbCodMon.Value, txtFecDoc.Text))
    End Sub

    Private Sub rbArmado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbIngreso.CheckedChanged, rbSalida.CheckedChanged
        If rbIngreso.Checked Then
            TipMov = "H"
            listaDatos()
        ElseIf rbSalida.Checked Then
            TipMov = "D"
            listaDatos()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub
    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        activar()

    End Sub

    Private Sub btnDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeshacer.Click
        If MsgBox("¿Desea Deshacer los Cambios Realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub miModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miModificar.Click
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub
    Private Sub biEditar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.MouseEnter
        sslError.Text = "Editar la Cabecera del Memo."
    End Sub

    Private Sub biGrabar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.MouseEnter
        sslError.Text = "Grabar los Cambios Hechos en el Memo."
    End Sub
    Private Sub biDeshacer_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeshacer.MouseEnter
        sslError.Text = "Deshacer los Cambios Hechos en la Cabecera del Memo."
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario Memo de Transferencias Internas."
    End Sub

    Private Sub miNuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Detalle del Memo."
    End Sub
    Private Sub miModificar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miModificar.MouseEnter
        sslError.Text = "Modificar Detalle actual."
    End Sub
    Private Sub miEliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.MouseEnter
        sslError.Text = "Eliminar Detalle actual."
    End Sub
    Private Sub miActualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.MouseEnter
        sslError.Text = "Actualizar detalles del Formulario Memo de Transferencias Internas."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                   btnGuardar.MouseLeave, btnDeshacer.MouseLeave, _
                                   btnEditar.MouseLeave, btnCancelar.MouseLeave, _
                                   miNuevo.MouseLeave, miModificar.MouseLeave, _
                                   miEliminar.MouseLeave, miActualizar.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
           And ValidaCampos() Then

            Dim registro As New MemoService.Memo
            Dim locacion As New MemoService.Locacion
            Dim cliente As New MemoService.Cliente
            Dim moneda As New MemoService.Moneda
            Dim serieDocumento As New MemoService.SerieDocumento

            registro.IdMemo = IdMemo
            locacion.IdLocacion = IdLocacion
            registro.Locacion = locacion
            serieDocumento.IdSerieDoc = IdSerieDoc
            registro.SerieDocumento = serieDocumento
            registro.NumDoc = txtNumDoc.Text
            registro.FecDoc = txtFecDoc.Text
            cliente.IdCliente = IdCliente
            registro.Cliente = cliente
            moneda.CodMon = cmbCodMon.Value
            registro.Moneda = moneda
            registro.NumJob = toNull(txtNumJob.Text)
            registro.MotMtd = cmbMotMtd.Value
            registro.Observacion = toNull(txtObservacion.Text)
            registro.CodUsu = Session.sCodUsu

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If

    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 And miModificar.Enabled = True Then
                miModificar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
    
End Class
