Imports System.Windows.Forms

Public Class frmTransferenciaMotor
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMaestroService As New MaestroService.MaestroClient
    Private oTransferenciaMotorService As New TransferenciaMotorService.TransferenciaMotorServiceClient
    Private oTransferenciaMotorDetService As New TransferenciaMotorDetService.TransferenciaMotorDetServiceClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdTraMot As Integer
    Public IdLocacion As Integer
    Private IdCliente As Integer
    Private dtMonedas As DataTable

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente_Click(sender, e)
                e.Handled = True
            End If
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
    Private Sub txtObservacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacion .KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnModificarObservacion.Enabled = True Then
                btnModificarObservacion_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGuardar.Enabled = True Then
                biGuardar.Select()
                biGuardar_Click(sender, e)
                e.Handled = True
            Else
                dgvDatos.Select()
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
                          , txtTotalPrecio.KeyPress _
                          , txtTotalDescuento.KeyPress _
                          , txtTotal.KeyPress
        'txtObservacion.KeyPress _
        ' , txtNumJob.KeyPress _
        ', cmbCodMon.KeyPress _
        ', txtMotorOrigen.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub frmTransferenciaMotor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            'Me.btnGuardar.Location = New System.Drawing.Point(525, 114)
            'Me.btnEliminar.Location = New System.Drawing.Point(599, 114)
            ObtenerRegistro()
            gbEstado.Visible = True
            'btnVerDetalle.Visible = True
            btnBuscarCliente.Enabled = False
            'btnBuscarAlmacen.Enabled = False
            txtNumDoc.ReadOnly = True
            cmbCodMon.ReadOnly = True
            cmbCodMon.BackColor = System.Drawing.SystemColors.Control
            btnBuscarCliente.Enabled = False
            btnBuscarMercaderiaOrigen.Enabled = False
            txtFecDoc.ReadOnly = True
            txtObservacion.ReadOnly = True
            btnModificarObservacion.Enabled = False
            btnBuscarJob.Enabled = False
            biGuardar.Enabled = False
            biDeshacer.Enabled = False
            enableOpciones()
            listaDatos()
            Me.Text = "Transferencia de Motor Nº " + Chr(34) + txtNumDoc.Text.ToString + Chr(34)
        Else                    'Nuevo
            'Me.btnGuardar.Location = New System.Drawing.Point(599, 114)
            gbEstado.Visible = False
            'btnVerDetalle.Visible = False
            btnBuscarCliente.Enabled = True
            'btnBuscarAlmacen.Enabled = True
            txtNumDoc.ReadOnly = False
            cmbCodMon.ReadOnly = False
            cmbCodMon.BackColor = System.Drawing.SystemColors.Control
            cmbCodMon.Value = "US"
            txtTipoCambio.Text = toDouble(oMaestroService.MostrarTipoCambio(cmbCodMon.Value, txtFecDoc.Text))
            biEditar.Enabled = False
            biSalir.Enabled = False
            biTrasladar.Enabled = False
            Me.Size = New System.Drawing.Size(780, 205)
            Me.Text = "Registrar una Nueva Transferencia de Motor"
        End If
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        state_Search = True
        enableOpciones()
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oTransferenciaMotorService) = False Then
                oTransferenciaMotorService.Close()
            End If
            If isClosed(oTransferenciaMotorDetService) = False Then
                oTransferenciaMotorDetService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtNumJob_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumJob.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente.Select()
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
            If btnBuscarMercaderiaOrigen.Enabled = True Then
                btnBuscarMercaderiaOrigen.Select()
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

                If CInt(row.Cells("IdTraMotDet").Value) = codigo Then

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
            miNuevo.Enabled = True
            miEliminar.Enabled = True
            biTrasladar.Enabled = IIf(txtTotalNeto.Text = 0, False, True)
            biEditar.Enabled = True

        ElseIf state_button = True And toBlank(lblEstado.Text) <> "GENERADO" Then
            miNuevo.Enabled = False
            miEliminar.Enabled = False
            miActualizar.Enabled = False
            biTrasladar.Enabled = False
            biEditar.Enabled = False
        End If
    End Sub
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If state_button = True And toNumber(IdTraMot) = 0 Then
                MsgBox("Debe Ingresar el código del T.M.", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
           
            ElseIf toBlank(txtFecDoc.Text) = "" Then
                MsgBox("Debe Ingresar la fecha.", MsgBoxStyle.Information, "Información")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
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
            ElseIf cmbCodMon.Value <> "NS" And toDouble(txtTipoCambio.Text) <= 0 Then
                MsgBox("El Tipo de cambio no puede ser CERO..", MsgBoxStyle.Information, "Información")
                txtTipoCambio.BackColor = Color.Red
                txtTipoCambio.Focus()
                Return False
            ElseIf toBlank(txtMotorOrigen.Text) = "" Then
                MsgBox("Debe ingresar el código del motor.", MsgBoxStyle.Information, "Información")
                txtMotorOrigen.BackColor = Color.Red
                btnBuscarMercaderiaOrigen.Focus()
                Return False
            ElseIf state_button = False And oTransferenciaMotorService.Buscar(IdLocacion, toNumber(txtNumDoc.Text)) Then
                MsgBox("El Número " + txtNumDoc.Text + " de la T.M. ya existe...!", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf state_button = True And oTransferenciaMotorService.Estado(IdTraMot) <> "GENERADO" Then
                MsgBox("Ya no se puede realizar modificaciones...!" + vbCr + "Debido que ya no se encuentra en el estado GENERADO...!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As TransferenciaMotorService.TransferenciaMotor)
        Try
            Dim estado_process As Integer
            estado_process = oTransferenciaMotorService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdTraMot = estado_process
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As TransferenciaMotorService.TransferenciaMotor)
        Try
            Dim estado_process As Boolean
            estado_process = oTransferenciaMotorService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                ' Me.DialogResult = Windows.Forms.DialogResult.OK
                ObtenerRegistro()
                desactivar()
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
            estado_process = oTransferenciaMotorService.Borrar(IdTraMot, Session.sCodUsu)
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
            Dim registro As TransferenciaMotorService.TransferenciaMotor
            registro = oTransferenciaMotorService.MostrarPorId(IdTraMot)

            IdTraMot = registro.IdTraMot
            IdLocacion = registro.Locacion.IdLocacion
            'txtalmacen.Text = registro.Locacion.Almacen.DesAlm + "-" + registro.Locacion.Oficina.DesOfi
            txtNumDoc.Text = registro.NumDoc
            txtFecDoc.Text = registro.FecDoc
            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli
            txtNumJob.Text = registro.NumJob
            txtIgv.Text = registro.Igv
            txtObservacion.Text = toBlank(registro.Observacion)
            txtMotorOrigen.Text = registro.MercaderiaOrigen.CodMer
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
            dtDatos = oTransferenciaMotorDetService.Mostrar(IdTraMot).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)

            txtTotalPrecio.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.TransferenciaMotor", "TotBruto", "IdTraMot", IdTraMot)
            txtTotalDescuento.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.TransferenciaMotor", "TotDscto", "IdTraMot", IdTraMot)
            txtTotal.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.TransferenciaMotor", "TotVenta", "IdTraMot", IdTraMot)
            txtTotalIGV.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.TransferenciaMotor", "TotIgv", "IdTraMot", IdTraMot)
            txtTotalNeto.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.TransferenciaMotor", "TotNeto", "IdTraMot", IdTraMot)
            lblTotal.Text = "SUB TOTALES"
            lbltotalIGV.Text = "IGV"
            lblTotalNeto.Text = "TOTAL (" + oMaestroService.MostrarDato("SIGECOM.Maestro.Monedas", "AbrMon", "CodMon", oMaestroService.MostrarDato("SIGECOM.Almacen.TransferenciaMotor", "CodMon", "IdTraMot", IdTraMot)) + ")"

            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [INFO-007]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmTransferenciaMotor_AgregarDetalle
                frm.state_button = False
                frm.IdTraMot = IdTraMot
                frm.IdLocacion = IdLocacion
                frm.IdCliente = IdCliente
                frm.CodMon = cmbCodMon.Value
                frm.Fecha = txtFecDoc.Text
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdTraMotDet)
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

                estado_process = oTransferenciaMotorDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdTraMotDet").Text), IdTraMot)
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
            Dim frm As New frmTransferenciaMotor_AgregarDetalle
            frm.state_button = True
            frm.IdTraMotDet = dgvDatos.CurrentRow.Cells("IdTraMotDet").Text
            frm.IdTraMot = IdTraMot
            frm.IdLocacion = IdLocacion
            frm.IdCliente = IdCliente
            frm.CodMon = cmbCodMon.Value
            frm.estado = lblEstado.Text
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdTraMotDet)
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
                    codigo = dgvDatos.CurrentRow.Cells("IdTraMotDet").Text
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
        btnBuscarMercaderiaOrigen.Enabled = True
        txtObservacion.ReadOnly = False
        txtFecDoc.ReadOnly = False
        btnModificarObservacion.Enabled = True
        btnBuscarJob.Enabled = True

        biGuardar.Enabled = True
        biEditar.Enabled = False
        biDeshacer.Enabled = True
        biTrasladar.Enabled = False
    End Sub
    Private Sub desactivar()
        btnBuscarCliente.Enabled = False
        btnBuscarMercaderiaOrigen.Enabled = False
        txtObservacion.ReadOnly = True
        txtFecDoc.ReadOnly = True
        btnModificarObservacion.Enabled = False
        btnBuscarJob.Enabled = False

        biGuardar.Enabled = False
        biEditar.Enabled = True
        biDeshacer.Enabled = False
        biTrasladar.Enabled = True

    End Sub
    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    
    'Private Sub btnBuscarAlmacen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarAlmacen.Click
    '    Dim frm As New frmBuscarLocacionPorALmacen
    '    frm.CodigoAlmacén = "004"
    '    If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
    '        txtalmacen.Text = frm.descripcion
    '        txtalmacen.BackColor = System.Drawing.SystemColors.Control
    '        IdLocacion = frm.codigo

    '        txtNumDoc.Text = oTransferenciaMotorService.SugerirNumero(IdLocacion)
    '        txtIgv.Text = toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Parametros", "igv", "IdLocacion", IdLocacion))
    '    End If
    'End Sub
    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If
        txtCliente.Select()

    End Sub
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
            txtTipoCambio.Text = toDouble(oMaestroService.MostrarTipoCambio(cmbCodMon.Value, txtFecDoc.Text))
        End If
    End Sub
    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Dim frm As New frmBuscarJob
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.Text = frm.cod_job
        End If
    End Sub
    Private Sub btnModificarObservacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarObservacion.Click
        Dim frm As New frmTransferenciaMotor_ModificarObservacion
        frm.state_button = state_button
        frm.IdTraMot = IdTraMot
        frm.txtObservacion.Text = toBlank(txtObservacion.Text)
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtObservacion.Text = toBlank(frm.txtObservacion.Text)
        End If
        txtObservacion.Select()
    End Sub
    Private Sub txtFecDoc_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecDoc.ValueChanged
        txtTipoCambio.Text = toDouble(oMaestroService.MostrarTipoCambio(cmbCodMon.Value, txtFecDoc.Text))
    End Sub
    Private Sub btnBuscarMercaderiaOrigen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderiaOrigen.Click
        Dim frm As New frmBuscarLocacionMercaderia
        frm.IdLocacion = IdLocacion
        frm.CodRub = "04"
        frm.cmbCodRub.ReadOnly = True
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtMotorOrigen.Text = frm.codigo
            txtMotorOrigen.BackColor = System.Drawing.SystemColors.Window
        End If
        txtMotorOrigen.Select()

    End Sub
    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New TransferenciaMotorService.TransferenciaMotor
            Dim locacion As New TransferenciaMotorService.Locacion
            Dim cliente As New TransferenciaMotorService.Cliente
            Dim moneda As New TransferenciaMotorService.Moneda
            Dim mercaderiaOrigen As New TransferenciaMotorService.Mercaderia

            registro.IdTraMot = IdTraMot
            locacion.IdLocacion = IdLocacion
            registro.Locacion = locacion
            registro.NumDoc = txtNumDoc.Text
            registro.FecDoc = txtFecDoc.Text
            cliente.IdCliente = IdCliente
            registro.Cliente = cliente
            moneda.CodMon = cmbCodMon.Value
            registro.Moneda = moneda
            registro.NumJob = toNull(txtNumJob.Text)
            registro.Observacion = toNull(txtObservacion.Text)
            mercaderiaOrigen.CodMer = toNull(txtMotorOrigen.Text)
            registro.MercaderiaOrigen = mercaderiaOrigen
            registro.CodUsu = Session.sCodUsu

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub
    Private Sub biTrasladar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTrasladar.Click
        Try
            Dim frm As New frmTransferenciaMotor_Transferir
            frm.NumDoc = txtNumDoc.Text
            frm.IdTraMot = IdTraMot
            frm.IdLocacion_doc = IdLocacion
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                lblEstado.Text = oTransferenciaMotorService.Estado(IdTraMot)
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [TRANSTERIR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
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
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub
    Private Sub biEditar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.MouseEnter
        sslError.Text = "Editar la Cabecera de la Transferencia."
    End Sub

    Private Sub biGuardar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.MouseEnter
        sslError.Text = "Grabar los Cambios Hechos en la Transferencia."
    End Sub
    Private Sub biDeshacer_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.MouseEnter
        sslError.Text = "Deshacer los Cambios Hechos en la Cabecera de la Transferencia."
    End Sub
    Private Sub biTrasladar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTrasladar .MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario de la Transferencia."
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario de la Transferencia."
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
        biEditar.MouseLeave, biGuardar.MouseLeave, biSalir.MouseLeave, biTrasladar.MouseLeave, biDeshacer.MouseLeave, _
        miNuevo.MouseLeave, miMostrar.MouseLeave, miEliminar.MouseLeave, miActualizar.MouseLeave
        sslError.Text = ""
    End Sub


    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            txtNumDoc.Select()
        End If
    End Sub

    Private Sub txtMotorOrigen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMotorOrigen.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtObservacion.Select()
        End If
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
