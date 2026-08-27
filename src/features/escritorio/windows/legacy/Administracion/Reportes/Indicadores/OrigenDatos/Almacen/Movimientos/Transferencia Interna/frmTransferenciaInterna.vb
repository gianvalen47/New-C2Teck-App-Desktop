Imports System.Windows.Forms

Public Class frmTransferenciaInterna
  Public state_button As Boolean              'True: Modificar    False: nuevo
  Public type_process As String               'update     insert      delete
  Private oMaestroService As New MaestroService.MaestroClient
  Private oTransferenciaService As New TransferenciaService.TransferenciaServiceClient
  Private oTransferenciaDetService As New TransferenciaDetService.TransferenciaDetServiceClient
    ' Private oLocacionClienteService As New LocacionClienteService.LocacionClienteServiceClient
    'Private oContactoService As New ContactoService.ContactoServiceClient
    Private dtDatos As DataTable
    Public edicion As Boolean
    Public editable As Boolean

  '====================================================================================================================
  '============================================ PARAMETROS LOCALES ====================================================
  '====================================================================================================================
  Public IdTransferencia As Integer
  Public IdLocacion As Integer
  Private IdCliente As Integer
    Private ConLocCli As Integer = 0
    Private dtMonedas As DataTable

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarJob.Enabled = True Then
                btnBuscarJob_Click(sender, e)
                e.Handled = True
            End If

        End If
    End Sub

    Private Sub txtMotorDestino_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMotorDestino.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarMotor.Enabled = True Then
                btnBuscarMotor_Click(sender, e)
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
    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente_Click(sender, e)
                e.Handled = True
            End If

        End If
    End Sub
  '====================================================================================================================
  '============================================ CONTROL'S METHOD ======================================================
  '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                           txtNumDoc.KeyPress _
                          , txtFecDoc.KeyPress _
                          , txtNumJob.KeyPress _
                          , txtIgv.KeyPress _
                          , cmbCodMon.KeyPress _
                          , txtTipoCambio.KeyPress _
                          , txtCliente.KeyPress _
                          , txtTotalNeto.KeyPress _
                          , txtTotalIGV.KeyPress _
                          , txtTotalPrecio.KeyPress _
                          , txtMotorDestino.KeyPress _
                          , txtTotalDescuento.KeyPress _
                          , txtTotal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmTransferenciaInterna_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
            e.Handled = True
        ElseIf e.KeyCode = Keys.Insert Then
            If miNuevo.Enabled = True Then
                miNuevo_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miModificar_Click(sender, e)
                e.Handled = True
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            txtNumDoc.Select()
        End If
    End Sub
  Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo

        estilo.cargaEstiloGridExt(dgvDatos)
        llenarCombos()

        If state_button Then    'Modificar

            ObtenerRegistro()
            gbEstado.Visible = True
            btnBuscarCliente.Enabled = False
            btnBuscarJob.Enabled = False
            btnBuscarMotor.Enabled = False
            btnModificarObservacion.Enabled = False
            txtNumDoc.ReadOnly = True
            txtObservacion.ReadOnly = True
            txtFecDoc.ReadOnly = True
            txtFecDoc.BackColor = System.Drawing.SystemColors.Control
            cmbCodMon.ReadOnly = True
            cmbCodMon.BackColor = System.Drawing.SystemColors.Control

            listaDatos()
            Me.Text = "Transferencia Interna Nº " + Chr(34) + txtNumDoc.Text.ToString + Chr(34)
            dgvDatos.Select()

        Else                    'Nuevo

            gbEstado.Visible = False
            btnBuscarCliente.Enabled = True
            'btnBuscarJob.Enabled = IIf(oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", IdLocacion) = "001", False, True)
            txtNumDoc.ReadOnly = False
            cmbCodMon.ReadOnly = False
            cmbCodMon.BackColor = System.Drawing.SystemColors.Control
            Me.Size = New System.Drawing.Size(850, 223)
            Me.Text = "Registrar una Nueva Transferencia Interna"
            txtNumDoc.Select()
            cmbCodMon.Value = "US"
        End If
   
  End Sub
  Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    Try
      If isClosed(oMaestroService) = False Then
        oMaestroService.Close()
      End If
      If isClosed(oTransferenciaService) = False Then
        oTransferenciaService.Close()
      End If
      If isClosed(oTransferenciaDetService) = False Then
        oTransferenciaDetService.Close()
            End If
    Catch ex As Exception
      MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
    End Sub
    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnGuardar.Enabled = True Then
                btnGuardar.Select()
                btnGuardar_Click(sender, e)
            Else
                dgvDatos.Select()
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
                             cmbCodMon.ValueChanged
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

                If CInt(row.Cells("IdTransferenciaDet").Value) = codigo Then

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
                btnDeshacer.Enabled = False
                miEliminar.Enabled = True
                miModificar.Enabled = True

            ElseIf state_button = True And toBlank(lblEstado.Text) = "TRANSFERIDO" Or toBlank(lblEstado.Text) = "INGRESADO" Then

                miNuevo.Enabled = False
                miEliminar.Enabled = False
                miModificar.Enabled = False
                miActualizar.Enabled = False
                btnGuardar.Enabled = False
                btnDeshacer.Enabled = False
                btnEditar.Enabled = False

            Else
                miNuevo.Enabled = False
                miEliminar.Enabled = False

                btnGuardar.Enabled = False

            End If
        End If
    End Sub
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If state_button = True And toNumber(IdTransferencia) = 0 Then
                MsgBox("Debe Ingresar el código del T.I.", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf toBlank(txtFecDoc.Text) = "" Then
                MsgBox("Debe Ingresar la fecha.", MsgBoxStyle.Information, "Información")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
                'ElseIf toBlank(txtNumJob.Text) <> "" And state_button = False And oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", IdLocacion) = "001" Then
                '    MsgBox("La Transferencia presenta Nº de Job debe ingresarse por el modulo Atender Job.", MsgBoxStyle.Information, "Información")
                '    txtNumJob.Text = ""
                '    txtNumJob.Focus()
                '    Return False
            ElseIf toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar el cliente ", MsgBoxStyle.Information, "Información")
                txtCliente.BackColor = Color.Red
                txtCliente.Focus()
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
            ElseIf state_button = False And oTransferenciaService.Buscar(IdLocacion, toNumber(txtNumDoc.Text)) Then
                MsgBox("El Número " + txtNumDoc.Text + " de la T.I. ya existe...!", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf state_button = True And oTransferenciaService.Estado(IdTransferencia) <> "GENERADO" Then
                MsgBox("Ya no se puede realizar modificaciones...!" + vbCr + "Debido que ya no se encuentra en el estado GENERADO...!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(txtObservacion.Text) = "" Then
                MsgBox("Debe Ingresar la Observación ", MsgBoxStyle.Information, "Información")
                txtObservacion.BackColor = Color.Red
                txtObservacion.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As TransferenciaService.Transferencia)
        Try
            Dim estado_process As Integer
            estado_process = oTransferenciaService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdTransferencia = estado_process
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As TransferenciaService.Transferencia)
        Try
            Dim estado_process As Boolean
            estado_process = oTransferenciaService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                ' Me.DialogResult = Windows.Forms.DialogResult.OK
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
            estado_process = oTransferenciaService.Borrar(IdTransferencia, Session.sCodUsu)
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
            Dim registro As TransferenciaService.Transferencia
            registro = oTransferenciaService.MostrarPorId(IdTransferencia)

            IdTransferencia = registro.IdTransferencia
            IdLocacion = registro.Locacion.IdLocacion
            txtNumDoc.Text = registro.NumDoc
            txtFecDoc.Text = registro.FecDoc
            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli
            cmbCodMon.Value = registro.Moneda.CodMon
            txtNumJob.Text = registro.NumJob
            txtIgv.Text = registro.Igv
            txtMotorDestino.Text = registro.Mercaderia.CodMer
            txtDesMotorDestino.Text = registro.Mercaderia.DesMer1
            txtObservacion.Text = toBlank(registro.Observacion)
            lblEstado.Text = registro.Estado

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

            dtDatos = oTransferenciaDetService.Mostrar(IdTransferencia).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)

            txtTotalPrecio.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.Transferencia", "TotBruto", "IdTransferencia", IdTransferencia)
            txtTotalDescuento.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.Transferencia", "TotDscto", "IdTransferencia", IdTransferencia)
            txtTotal.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.Transferencia", "TotVenta", "IdTransferencia", IdTransferencia)
            txtTotalIGV.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.Transferencia", "TotIgv", "IdTransferencia", IdTransferencia)
            txtTotalNeto.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.Transferencia", "TotNeto", "IdTransferencia", IdTransferencia)
            lblTotal.Text = "SUB TOTALES"
            lbltotalIGV.Text = "IGV"
            lblTotalNeto.Text = "TOTAL (" + oMaestroService.MostrarDato("SIGECOM.Maestro.Monedas", "AbrMon", "CodMon", oMaestroService.MostrarDato("SIGECOM.Almacen.Transferencia", "CodMon", "IdTransferencia", IdTransferencia)) + ")"

            enableOpciones()

        Catch ex As Exception
            MsgBox("ERROR [INFO-007]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub NuevoDetalle()
        Try

            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmTransferenciaInterna_AgregarDetalle
                frm.state_button = False
                frm.IdTransferencia = IdTransferencia
                frm.IdLocacion = IdLocacion
                frm.IdCliente = IdCliente
                frm.CodMon = cmbCodMon.Value
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdTransferenciaDet)
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

                estado_process = oTransferenciaDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdTransferenciaDet").Text), IdTransferencia)
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
            Dim frm As New frmTransferenciaInterna_AgregarDetalle
            frm.state_button = True
            frm.IdTransferenciaDet = dgvDatos.CurrentRow.Cells("IdTransferenciaDet").Text
            frm.IdTransferencia = IdTransferencia
            frm.IdLocacion = IdLocacion
            frm.IdCliente = IdCliente
            frm.CodMon = cmbCodMon.Value
            frm.CodJob = txtNumJob.Text
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdTransferenciaDet)
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
                    codigo = dgvDatos.CurrentRow.Cells("IdTransferenciaDet").Text
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
        Dim frm As New frmTransferenciaInterna_ModificarObservacion
        frm.state_button = state_button
        frm.IdTransferencia = IdTransferencia
        frm.txtObservacion.Text = toBlank(txtObservacion.Text)
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtObservacion.Text = toBlank(frm.txtObservacion.Text)
        End If
        txtObservacion.Select()
    End Sub
    Private Sub txtFecDoc_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecDoc.ValueChanged
        txtTipoCambio.Text = toDouble(oMaestroService.MostrarTipoCambio(cmbCodMon.Value, txtFecDoc.Text))
    End Sub
    Private Sub desactivar()

        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
        txtCliente.ReadOnly = True
        txtCliente.BackColor = System.Drawing.SystemColors.Control
        txtNumJob.ReadOnly = True
        txtNumJob.BackColor = System.Drawing.SystemColors.Control
        txtMotorDestino.ReadOnly = True
        txtMotorDestino.BackColor = System.Drawing.SystemColors.Control
        btnModificarObservacion.Enabled = False
        btnBuscarCliente.Enabled = False
        btnBuscarJob.Enabled = False
        btnBuscarMotor.Enabled = False
        btnEditar.Enabled = True

        edicion = False
        enableOpciones()
        dgvDatos.Select()

    End Sub
    Private Sub activar()

        btnGuardar.Enabled = True
        btnDeshacer.Enabled = True
        btnEditar.Enabled = False

        btnBuscarCliente.Enabled = True
        'btnBuscarJob.Enabled = IIf(oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", IdLocacion) = "001", False, True)
        btnBuscarJob.Enabled = True
        btnBuscarMotor.Enabled = True
        btnModificarObservacion.Enabled = True

    End Sub

    Private Sub btnBuscarMotor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMotor.Click
        Dim frm As New frmBuscarLocacionMercaderia
        'frm.IdLocacion = 4          'Se comenta el 19/06/2013 (Sr. VictorHugo/Cesar)
        frm.CodRub = "04"
        'frm.cmbCodRub.ReadOnly = True
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtMotorDestino.Text = frm.codigo
            txtDesMotorDestino.Text = frm.descripcion
        End If
        txtMotorDestino.Select()
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub


    Private Sub miModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miModificar.Click
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
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

    
    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        activar()
    End Sub

    Private Sub biEditar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.MouseEnter
        sslError.Text = "Editar la Cabecera de la Transferencia Interna."
    End Sub
   
    Private Sub biGrabar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.MouseEnter
        sslError.Text = "Grabar los Cambios Hechos en la Transferencia Interna."
    End Sub
    Private Sub biDeshacer_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeshacer.MouseEnter
        sslError.Text = "Deshacer los Cambios Hechos en la Cabecera de la Transferencia Interna."
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario Transferencia Interna."
    End Sub

    Private Sub miNuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Detalle de la Transferencia Interna."
    End Sub
    Private Sub miModificar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miModificar.MouseEnter
        sslError.Text = "Modificar Detalle actual."
    End Sub
    Private Sub miEliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.MouseEnter
        sslError.Text = "Eliminar Detalle actual."
    End Sub
    Private Sub miActualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario Transferencia Interna."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                   btnGuardar.MouseLeave, btnEditar.MouseLeave, btnDeshacer.MouseLeave, _
                                   btnCancelar.MouseLeave, _
                                   miNuevo.MouseLeave, miModificar.MouseLeave, _
                                   miEliminar.MouseLeave, miActualizar.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
          And ValidaCampos() Then

            Dim registro As New TransferenciaService.Transferencia
            Dim locacion As New TransferenciaService.Locacion
            Dim almacen As New TransferenciaService.Almacen
            Dim cliente As New TransferenciaService.Cliente
            Dim moneda As New TransferenciaService.Moneda
            Dim mercaderia As New TransferenciaService.Mercaderia

            registro.IdTransferencia = IdTransferencia
            locacion.IdLocacion = IdLocacion
            registro.Locacion = locacion
            registro.NumDoc = txtNumDoc.Text
            registro.FecDoc = txtFecDoc.Text
            cliente.IdCliente = IdCliente
            registro.Cliente = cliente
            moneda.CodMon = cmbCodMon.Value
            registro.Moneda = moneda
            registro.NumJob = toNull(txtNumJob.Text)
            mercaderia.CodMer = toNull(txtMotorDestino.Text)
            registro.Mercaderia = mercaderia
            registro.Observacion = toNull(txtObservacion.Text)
            registro.CodUsu = Session.sCodUsu

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress

        'If Not (Char.IsDigit(e.KeyChar)) Then
        '    e.Handled = True
        'End If
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

End Class
