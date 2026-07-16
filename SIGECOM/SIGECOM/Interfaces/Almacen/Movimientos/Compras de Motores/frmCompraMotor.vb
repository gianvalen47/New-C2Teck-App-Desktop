Imports System.Windows.Forms

Public Class frmCompraMotor

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMaestroService As New MaestroService.MaestroClient
    Private oComprasMotorService As New ComprasMotorService.ComprasMotorServiceClient
    Private oComprasMotorDetService As New ComprasMotorDetService.ComprasMotorDetServiceClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdCompraMot As Integer
    Public IdLocacion As Integer
    Private IdCliente As Integer

    Private dtMonedas As DataTable

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarJob.Enabled = True Then
                btnBuscarJob_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtMotorDestino_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMotorDestino.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarMercaderia.Enabled = True Then
                btnBuscarMercaderiaOrigen_Click(sender, e)
                e.Handled = True
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

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 And miMostrar.Enabled = True Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            txtNumDoc.Select()
        End If
    End Sub
    Private Sub txtNumJob_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumJob.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente.Select()
            End If
        End If
    End Sub
    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                           txtNumDoc.KeyPress _
                          , txtFecDoc.KeyPress _
                          , txtIgv.KeyPress _
                          , txtTipoCambio.KeyPress _
                          , txtCliente.KeyPress _
                          , txtTotalNeto.KeyPress _
                          , txtTotalIGV.KeyPress _
                          , txtMotorDestino.KeyPress _
                          , txtTotalPrecio.KeyPress _
                          , txtTotalDescuento.KeyPress _
                          , txtFecEmision.KeyPress _
                          , txtTotal.KeyPress
        ', cmbCodMon.KeyPress _
        ', txtNumJob.KeyPress _
        ' txtObservacion.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmCompraMotor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            biSalir_Click(sender, e)
            e.Handled = True
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.CancelButton = Me.btnCancelar
        'Me.Size = New System.Drawing.Size(763, 175)
        state_Search = False
        llenarCombos()
        If state_button Then    'Modificar
            'Me.btnGuardar.Location = New System.Drawing.Point(526, 115)
            'Me.btnEliminar.Location = New System.Drawing.Point(600, 115)
            ObtenerRegistro()
            gbEstado.Visible = True
            'btnVerDetalle.Visible = True
            btnBuscarCliente.Enabled = False
            txtNumDoc.ReadOnly = True
            cmbCodMon.ReadOnly = True
            cmbCodMon.BackColor = System.Drawing.SystemColors.Control
            btnBuscarMercaderia.Enabled = False
            txtFecDoc.ReadOnly = True
            txtFecDoc.BackColor = System.Drawing.SystemColors.Control
            txtFecEmision.ReadOnly = True
            txtFecEmision.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = True
            btnBuscarJob.Enabled = False
            btnModificarObservacion.Enabled = False
            biGuardar.Enabled = False
            biDeshacer.Enabled = False
            listaDatos()
            enableOpciones()
            Me.Text = "Compra para Motor Nº " + Chr(34) + txtNumDoc.Text.ToString + Chr(34)
        Else                'Nuevo

            'btnEliminar.Visible = False
            'Me.btnGuardar.Location = New System.Drawing.Point(600, 115)
            gbEstado.Visible = False
            'btnVerDetalle.Visible = False
            btnBuscarCliente.Enabled = True
            txtNumDoc.ReadOnly = False
            cmbCodMon.ReadOnly = False
            cmbCodMon.BackColor = System.Drawing.SystemColors.Control
            cmbCodMon.Value = "US"
            biEditar.Enabled = False
            biSalir.Enabled = False
            txtTipoCambio.Text = toDouble(oMaestroService.MostrarTipoCambio("US", txtFecEmision.Text))
            Me.Size = New System.Drawing.Size(786, 229)
            Me.Text = "Registrar un Nueva Compra para Motor"
        End If
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        state_Search = True
        enableOpciones()
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oComprasMotorService) = False Then
                oComprasMotorService.Close()
            End If
            If isClosed(oComprasMotorDetService) = False Then
                oComprasMotorDetService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGuardar.Enabled = True Then
                'biGuardar.Focus()
                biGuardar_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                            txtObservacion.KeyUp _
                          , txtNumJob.KeyUp _
                          , txtIgv.KeyUp _
                          , txtTipoCambio.KeyUp _
                          , txtCliente.KeyUp _
                          , txtFecDoc.KeyUp _
                          , txtFecEmision.KeyUp _
                          , txtNumDoc.KeyUp _
                          , txtTotalNeto.KeyUp _
                          , txtTotalIGV.KeyUp _
                          , txtTotalPrecio.KeyUp _
                          , txtTotalDescuento.KeyUp _
                          , txtTotal.KeyUp
        Try
            If state_Search = True Then
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
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbCodMon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCodMon.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnBuscarMercaderia.Enabled = True Then
                btnBuscarMercaderia.Focus()
            End If
        End If
    End Sub
    Private Sub setColor_BlankCombo(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                               cmbCodMon.ValueChanged
        Try
            If state_Search = True Then
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
            End If
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

                If CInt(row.Cells("IdCompraMotDet").Value) = codigo Then

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
            miMostrar.Enabled = False
            miEliminar.Enabled = False
        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = True
        End If
        If state_button = True And toBlank(lblEstado.Text) = "GENERADO" Then

            biEditar.Enabled = True

        ElseIf state_button = True And toBlank(lblEstado.Text) <> "GENERADO" Then
            miNuevo.Enabled = False
            miEliminar.Enabled = False
            'miMostrar.Enabled = False
            miActualizar.Enabled = False
            biEditar.Enabled = False
        End If
    End Sub
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try

            If state_button = True And toNumber(IdCompraMot) = 0 Then
                MsgBox("Debe Ingresar el código del Compra", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(txtFecDoc.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha de Registro.", MsgBoxStyle.Information, "Información")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
            ElseIf toBlank(txtFecEmision.Text) = "" Then
                MsgBox("Debe Ingresar la fecha de Emisión.", MsgBoxStyle.Information, "Información")
                txtFecEmision.BackColor = Color.Red
                txtFecEmision.Focus()
                Return False
            ElseIf toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar el Cliente ", MsgBoxStyle.Information, "Información")
                txtCliente.BackColor = Color.Red
                btnBuscarCliente.Focus()
                Return False
            ElseIf toBlank(cmbCodMon.Value) = "" Then
                MsgBox("Debe de ingresar el tipo de moneda.", MsgBoxStyle.Information, "Información")
                cmbCodMon.BackColor = Color.Red
                cmbCodMon.Focus()
                Return False
            ElseIf cmbCodMon.Value <> "NS" And toDouble(txtTipoCambio.Text) <= 0 Then
                MsgBox("Tipo de cambio no puede ser CERO..", MsgBoxStyle.Information, "Información")
                txtTipoCambio.BackColor = Color.Red
                txtTipoCambio.Focus()
                Return False
            ElseIf toBlank(txtMotorDestino.Text) = "" Then
                MsgBox("Debe ingresar el código del motor.", MsgBoxStyle.Information, "Información")
                txtMotorDestino.BackColor = Color.Red
                btnBuscarMercaderia.Focus()
                Return False
                'ElseIf state_button = False And oComprasMotorService.Buscar(IdCliente, toNumber(txtNumDoc.Text)) Then
                '          MsgBox("El Número " + txtNumDoc.Text + " ya existe " + vbCr + " Para el cliente " + txtCliente.Text + "...!", MsgBoxStyle.Information, "Información")
                '          txtNumDoc.Select()
                '  Return False
            ElseIf state_button = True And oComprasMotorService.Estado(IdCompraMot) <> "GENERADO" Then
                MsgBox("Ya no se puede realizar modificaciones...!" + vbCr + "Debido que ya no se encuentra en el estado GENERADO...!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As ComprasMotorService.ComprasMotor)
        Try
            Dim estado_process As Integer
            estado_process = oComprasMotorService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdCompraMot = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As ComprasMotorService.ComprasMotor)
        Try
            Dim estado_process As Boolean
            estado_process = oComprasMotorService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                ObtenerRegistro()
                desactivar()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oComprasMotorService.Borrar(IdCompraMot)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As ComprasMotorService.ComprasMotor
            registro = oComprasMotorService.MostrarPorId(IdCompraMot)

            IdCompraMot = registro.IdCompraMot
            IdLocacion = registro.Locacion.IdLocacion
            'txtalmacen.Text = registro.Locacion.Almacen.DesAlm + "-" + registro.Locacion.Oficina.DesOfi
            txtNumDoc.Text = registro.NumDoc
            txtFecDoc.Text = registro.FecDoc
            txtFecEmision.Text = registro.FecEmision
            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli
            txtNumJob.Text = registro.NumJob
            txtIgv.Text = registro.Igv
            txtObservacion.Text = toBlank(registro.Observacion)
            txtMotorDestino.Text = registro.Mercaderia.CodMer
            lblEstado.Text = registro.Estado
            state_Search = True
            cmbCodMon.Value = registro.Moneda.CodMon

        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbCodMon.DataSource = dtMonedas
            cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            dtDatos = oComprasMotorDetService.Mostrar(IdCompraMot).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)

            txtTotalPrecio.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.ComprasMotor", "TotBruto", "IdCompraMot", IdCompraMot)
            txtTotalDescuento.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.ComprasMotor", "TotDscto", "IdCompraMot", IdCompraMot)
            txtTotal.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.ComprasMotor", "TotVenta", "IdCompraMot", IdCompraMot)
            txtTotalIGV.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.ComprasMotor", "TotIgv", "IdCompraMot", IdCompraMot)
            txtTotalNeto.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.ComprasMotor", "TotNeto", "IdCompraMot", IdCompraMot)
            lblTotal.Text = "SUB TOTALES"
            lbltotalIGV.Text = "IGV"
            lblTotalNeto.Text = "TOTAL (" + oMaestroService.MostrarDato("SIGECOM.Maestro.Monedas", "AbrMon", "CodMon", oMaestroService.MostrarDato("SIGECOM.Almacen.ComprasMotor", "CodMon", "IdCompraMot", IdCompraMot)) + ")"

            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [INFO-007]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmCompraMotor_AgregarDetalle
                frm.state_button = False
                frm.IdCompraMot = IdCompraMot
                frm.IdLocacion = IdLocacion
                frm.IdCliente = IdCliente
                frm.CodMon = cmbCodMon.Value
                frm.TipCam = txtTipoCambio.Text
                'frm.Fecha = txtFecDoc.Text
                frm.Fecha = txtFecEmision.Text      ' Se actualiza a FecEmision
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdCompraMotDet)
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

                estado_process = oComprasMotorDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdCompraMotDet").Text), IdCompraMot)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-009]:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmCompraMotor_AgregarDetalle
            frm.state_button = True
            frm.IdCompraMotDet = dgvDatos.CurrentRow.Cells("IdCompraMotDet").Text
            frm.IdCompraMot = IdCompraMot
            frm.IdLocacion = IdLocacion
            frm.IdCliente = IdCliente
            frm.CodMon = cmbCodMon.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdCompraMotDet)
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
                    codigo = dgvDatos.CurrentRow.Cells("IdCompraMotDet").Text
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
        btnBuscarCliente.Enabled = True
        btnBuscarMercaderia.Enabled = True
        txtFecDoc.ReadOnly = False
        txtFecEmision.BackColor = System.Drawing.SystemColors.Window
        txtFecEmision.ReadOnly = False
        txtFecDoc.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.ReadOnly = False
        btnBuscarJob.Enabled = True
        btnModificarObservacion.Enabled = True
        biGuardar.Enabled = True
        biDeshacer.Enabled = True
        biEditar.Enabled = False

    End Sub
    Private Sub desactivar()
        btnBuscarCliente.Enabled = False
        btnBuscarMercaderia.Enabled = False
        txtFecDoc.ReadOnly = True
        txtFecDoc.BackColor = System.Drawing.SystemColors.Control
        txtFecEmision.ReadOnly = True
        txtFecEmision.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ReadOnly = True
        btnBuscarJob.Enabled = False
        btnModificarObservacion.Enabled = False
        biGuardar.Enabled = False
        biDeshacer.Enabled = False
        biEditar.Enabled = True

    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    'Private Sub btnBuscarAlmacen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarAlmacen.Click
    '    Dim frm As New frmBuscarLocacionPorALmacen
    '    frm.CodigoAlmacén = "004"
    '    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '        txtalmacen.Text = frm.descripcion
    '        txtalmacen.BackColor = System.Drawing.SystemColors.Control
    '        IdLocacion = frm.codigo

    '        txtIgv.Text = toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Parametros", "igv", "IdLocacion", IdLocacion))
    '    End If
    'End Sub
    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If
        txtCliente.Select()
    End Sub
    'Private Sub btnVerDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerDetalle.Click
    '  If btnVerDetalle.Text = "Ver Detalle" Then
    '    Me.Size = New System.Drawing.Size(768, 508)
    '    Me.btnVerDetalle.Image = Global.SIGECOM.My.Resources.Resources.Arriba
    '    btnVerDetalle.Text = "Ocultar Detalle"
    '    btnVerDetalle.Size = New System.Drawing.Size(102, 25)

    '    listaDatos()
    '  Else
    '    Me.Size = New System.Drawing.Size(768, 177)
    '    Me.btnVerDetalle.Image = Global.SIGECOM.My.Resources.Resources.Derecha
    '    btnVerDetalle.Text = "Ver Detalle"
    '    btnVerDetalle.Size = New System.Drawing.Size(85, 25)

    '    dtDatos = Nothing
    '    dgvDatos.DataSource = Nothing
    '  End If
    'End Sub

    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
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
        If state_Search = True Then
            'txtTipoCambio.Text = toDouble(oMaestroService.MostrarTipoCambio("US", txtFecDoc.Text))
            txtTipoCambio.Text = toDouble(oMaestroService.MostrarTipoCambio("US", txtFecEmision.Text))
        End If
    End Sub
    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Dim frm As New frmBuscarJob
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.Text = frm.cod_job
        End If
        btnBuscarJob.Select()
    End Sub
    Private Sub btnModificarObservacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarObservacion.Click
        Dim frm As New frmCompraMotor_ModificarObservacion
        frm.state_button = state_button
        frm.IdCompraMot = IdCompraMot
        frm.txtObservacion.Text = toBlank(txtObservacion.Text)
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtObservacion.Text = toBlank(frm.txtObservacion.Text)
        End If
        txtObservacion.Select()
    End Sub
    Private Sub txtFecEmision_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecEmision.ValueChanged
        txtTipoCambio.Text = toDouble(oMaestroService.MostrarTipoCambio("US", txtFecEmision.Text))
    End Sub
    Private Sub btnBuscarMercaderiaOrigen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm As New frmBuscarLocacionMercaderia
        frm.IdLocacion = IdLocacion
        frm.CodRub = "04"
        'frm.cmbCodRub.ReadOnly = True           'Se comenta el 13/06/2013 (Sr. VictorHugo/Cesar)
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtMotorDestino.Text = frm.codigo
            txtMotorDestino.BackColor = System.Drawing.SystemColors.Window
        End If
        txtMotorDestino.Select()
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
        And ValidaCampos() Then

            Dim registro As New ComprasMotorService.ComprasMotor
            Dim locacion As New ComprasMotorService.Locacion
            Dim cliente As New ComprasMotorService.Cliente
            Dim moneda As New ComprasMotorService.Moneda
            Dim mercaderia As New ComprasMotorService.Mercaderia

            registro.IdCompraMot = IdCompraMot
            locacion.IdLocacion = IdLocacion
            registro.Locacion = locacion
            registro.NumDoc = txtNumDoc.Text
            registro.FecDoc = txtFecDoc.Text
            registro.FecEmision = toNull(txtFecEmision.Text)
            cliente.IdCliente = IdCliente
            registro.Cliente = cliente
            moneda.CodMon = cmbCodMon.Value
            registro.Moneda = moneda
            registro.NumJob = toNull(txtNumJob.Text)
            registro.Observacion = toNull(txtObservacion.Text)
            mercaderia.CodMer = toNull(txtMotorDestino.Text)
            registro.Mercaderia = mercaderia
            registro.CodUsu = Session.sCodUsu

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub biEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.Click
        activar()

    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        If MsgBox("¿Desea Deshacer los Cambios Realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()

            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub
    Private Sub biEditar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.MouseEnter
        sslError.Text = "Editar la Cabecera de la Compra."
    End Sub

    Private Sub biGuardar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.MouseEnter
        sslError.Text = "Grabar los Cambios Hechos en la Compra."
    End Sub
    Private Sub biDeshacer_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.MouseEnter
        sslError.Text = "Deshacer los Cambios Hechos en la Cabecera de la Compra."
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario de Compra."
    End Sub

    Private Sub miNuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Detalle."
    End Sub
    Private Sub miMostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.MouseEnter
        sslError.Text = "Modificar Detalle Actual."
    End Sub
    Private Sub miEliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.MouseEnter
        sslError.Text = "Eliminar Detalle Actual."
    End Sub
    Private Sub miActualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.MouseEnter
        sslError.Text = "Actualizar Detalles del Formulario."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
 _
        miNuevo.MouseLeave, miMostrar.MouseLeave, miEliminar.MouseLeave, miActualizar.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        'If Not (Char.IsDigit(e.KeyChar) Then
        '    e.Handled = True
        'End If
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub
End Class
