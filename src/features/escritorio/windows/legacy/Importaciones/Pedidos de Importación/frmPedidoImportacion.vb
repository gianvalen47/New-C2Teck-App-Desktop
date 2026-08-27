Imports System.Windows.Forms

Public Class frmPedidoImportacion

  Public state_button As Boolean              'True: Modificar    False: nuevo
  Public type_process As String               'update     insert      delete
  Private oMaestroService As New MaestroService.MaestroClient
  Private oPedidoImportService As New PedidoImportService.PedidoImportServiceClient
    Private oPedidoImportDetService As New PedidoImportDetService.PedidoImportDetServiceClient
    Private oJobService As New JobService.JobServiceClient

    Private dtDatos As DataTable
    Private AbrvProv As String
    Private dtADR As DataTable
    Private CodPais As String
    Private dtMonedas As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdPedidoImp As String
    Public IdCliente As String
    Public IdLocacion As String

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarProveedor.Enabled = True Then
                btnBuscarProveedor_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtObsPed_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 'Handles txtobs
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGuardar.Enabled = True Then
                'biGuardar.Focus()
                biGuardar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                mostrarDetalle()
                e.Handled = True
            End If
        End If
    End Sub

  '====================================================================================================================
  '============================================ CONTROL'S METHOD ======================================================
  '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtProveedor.KeyPress _
                          , txtNumPed.KeyPress _
                          , txtFecPed.KeyPress _
                          , txtTotPed.KeyPress _
                          , txtNumJob.KeyPress _
                          , cmbADR.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmPedidoImportacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            biSalir_Click(sender, e)
            e.Handled = True
        End If
    End Sub
  Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.CancelButton = Me.btnCancelar
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left Or AnchorStyles.Bottom
        llenarCombos()

        If state_button Then    'Modificar

            'Me.btnGuardar.Location = New System.Drawing.Point(308, 143)
            'Me.btnEliminar.Location = New System.Drawing.Point(382, 143)
            'Me.btnCancelar.Location = New System.Drawing.Point(456, 143)
            txtNumPed.ReadOnly = True
            txtNumPed.TabStop = True
            ObtenerRegistro()
            'If IdCliente = "404" Then
            '    ActualizarObsCabecera()
            '    ActualizarObsDetalle()
            'End If
            txtObsCab.ReadOnly = True
            txtObsDet.ReadOnly = True
            btnModificarCabecera.Enabled = False
            btnModificarDetalle.Enabled = False
            'txtObsPed.ReadOnly = True
            txtFecPed.ReadOnly = True
            txtFecPromesa.ReadOnly = True
            txtNumJob.ReadOnly = True
            cmbADR.ReadOnly = True
            cmbADR.BackColor = System.Drawing.SystemColors.Control
            btnBuscarJob.Enabled = False
            btnBuscarPais.Enabled = False
            biGuardar.Enabled = False
            biEditar.Enabled = True
            biDeshacer.Enabled = False
            gbEstado.Visible = True
            btnBuscarProveedor.Enabled = False
            cmbCodMon.ReadOnly = True
            cmbCodMon.BackColor = System.Drawing.SystemColors.Control
            'btnVerDetalle.Visible = True
            'Me.gbDatos.Size = New System.Drawing.Size(526, 138)
            'Me.Size = New System.Drawing.Size(544, 206)
            listaDatos()
            dgvDatos.Select()

            'If (lblEstado.Text = "GENERADO" Or lblEstado.Text = "GN") Then
            '          biGuardar.Enabled = True
            '          'btnEliminar.Enabled = True
            'Else
            '          biGuardar.Enabled = False
            '          'btnEliminar.Enabled = False
            'End If
            Me.Text = "Orden de Pedido de Importación Nº " + Chr(34) + txtNumPed.Text.ToString + Chr(34)
        Else                    'Nuevo
            'btnEliminar.Visible = False
            'Me.btnEliminar.Location = New System.Drawing.Point(308, 103)
            'Me.btnGuardar.Location = New System.Drawing.Point(382, 103)
            'Me.btnCancelar.Location = New System.Drawing.Point(456, 103)
            txtNumPed.ReadOnly = False
            txtNumPed.TabStop = True
            gbEstado.Visible = False
            btnBuscarProveedor.Visible = True
            biSalir.Enabled = False
            biEditar.Enabled = False
            txtNumPed.Focus()
            txtObsCab.Text = ""
            txtObsDet.Text = ""
            cmbCodMon.ReadOnly = False

            'btnVerDetalle.Visible = False
            'Me.gbDatos.Size = New System.Drawing.Size(526, 97)
            Me.Size = New System.Drawing.Size(788, 356)
            Me.Text = "Registrar nueva Orden de Pedido de Importación"
            If IdCliente = "404" Then
                ActualizarObsCabecera()
                ActualizarObsDetalle()
            End If
        End If
    
  End Sub
  Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    Try
      If isClosed(oMaestroService) = False Then
        oMaestroService.Close()
      End If
      If isClosed(oPedidoImportService) = False Then
        oPedidoImportService.Close()
      End If
      If isClosed(oPedidoImportDetService) = False Then
        oPedidoImportDetService.Close()
      End If
    Catch ex As Exception
      MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
  Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                         txtNumPed.KeyUp
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
    'Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumPed.KeyPress
    '  If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
    '    e.KeyChar = Chr(0)
    '  End If
    'End Sub
    Private Function getRowTodos(ByVal data As DataTable)
    Dim fila As DataRow = data.NewRow
    Try
      fila(0) = ""
    Catch ex As Exception
      fila(0) = 0
    End Try
    fila(1) = "(Ninguno)"
    Return fila
  End Function
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdDetPedidoImp").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("El código no se encuentra en el detalle.Verifique !!! ", MsgBoxStyle.Exclamation, "Información")
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
    If state_button = True And (toBlank(lblEstado.Text) = "GENERADO" Or toBlank(lblEstado.Text) = "GN") Then
      miNuevo.Enabled = True
      miEliminar.Enabled = True

    Else
      miNuevo.Enabled = False
      miEliminar.Enabled = False

    End If
  End Sub

  '====================================================================================================================
  '============================================ TASK'S METHOD =========================================================
  '====================================================================================================================
  Private Function ValidaCampos() As Boolean
        Try

            Dim registro As New PedidoImportService.PedidoImport
            Dim proveedor As New PedidoImportService.Proveedor
            Dim locacion As New PedidoImportService.Locacion

            registro.NumPed = toNull(txtNumPed.Text)
            proveedor.IdProveedor = toNull(IdCliente)
            locacion.IdLocacion = IdLocacion
            registro.Locacion = locacion
            registro.Proveedor = proveedor
            registro.FecPed = txtFecPed.Text
            If toBlank(txtNumPed.Text) = "" Then
                MsgBox("Debe Ingresar el número de la Orden de Pedido", MsgBoxStyle.Information, "Información")
                txtNumPed.BackColor = Color.Red
                txtNumPed.Focus()
                Return False

            ElseIf toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar el proveedor de la Orden de Pedido", MsgBoxStyle.Information, "Información")
                txtProveedor.BackColor = Color.Red
                txtProveedor.Focus()
                Return False
            ElseIf toNull(txtFecPed.Text) = Nothing Then
                MsgBox("Debe Ingresar la fecha de la Orden de Pedido", MsgBoxStyle.Information, "Información")
                txtFecPed.BackColor = Color.Red
                txtFecPed.Focus()
                Return False
            ElseIf toNull(txtFecPromesa.Text) = Nothing Then
                MsgBox("Debe Ingresar la fecha promesa de la Orden de Pedido", MsgBoxStyle.Information, "Información")
                txtFecPromesa.BackColor = Color.Red
                txtFecPromesa.Focus()
                Return False
            ElseIf state_button = False And oPedidoImportService.Buscar(registro) = True Then
                MsgBox("Código " + txtNumPed.Text + " ya existe...!", MsgBoxStyle.Information, "Información")
                txtNumPed.Text = ""
                txtNumPed.Focus()
                Return False
            ElseIf state_button = True And toBlank(lblEstado.Text) <> "GENERADO" Then
                MsgBox("Orden de Pedido ya no se puede modificar...!" + vbCr + "Debido que ya no se encuentra en el estado generado...!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
  End Function
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
  Private Sub Insertar(ByVal registro As PedidoImportService.PedidoImport)
        Try

            Dim estado_process As Integer
            estado_process = oPedidoImportService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdPedidoImp = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
  End Sub
  Private Sub Modificar(ByVal registro As PedidoImportService.PedidoImport)
        Try

            Dim estado_process As Boolean
            estado_process = oPedidoImportService.Actualizar(registro)
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
  Private Sub Eliminar(ByVal registro As PedidoImportService.PedidoImport)
        Try

            Dim estado_process As Boolean
            estado_process = oPedidoImportService.Borrar(registro)
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
            Dim registro As PedidoImportService.PedidoImport
            registro = oPedidoImportService.MostrarPorId(toNumber(IdPedidoImp))

            IdPedidoImp = registro.IdPedidoImp
            IdLocacion = registro.Locacion.IdLocacion
            'txtalmacen.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.Almacenes", "DesAlm", "CodAlm", oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", IdLocacion)) _
            '                   & " - " & oMaestroService.MostrarDato("SIGECOM.Maestro.Oficinas", "DesOfi", "CodOfi", oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodOfi", "IdLocacion", IdLocacion))
            'txtalmacen.Text = registro.Locacion.Oficina.DesOfi & " - " & registro.Locacion.Almacen.DesAlm
            IdCliente = registro.Proveedor.IdProveedor
            'txtProveedor.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.Clientes", "DesCli", "IdCliente", IdCliente)
            txtProveedor.Text = registro.Proveedor.DesProv
            txtNumJob.Text = registro.Job.CodJob
            If registro.NumerosADR.NumeroADR = Nothing Or registro.NumerosADR.NumeroADR = "" Then
                cmbADR.SelectedIndex = 0
            Else
                cmbADR.Value = registro.NumerosADR.NumeroADR
            End If
            AbrvProv = registro.Proveedor.AbrProv
            txtNumPed.Text = registro.NumPed
            txtFecPed.Text = registro.FecPed

            If Not (registro.FecPromesa.ToString = "") Then
                txtFecPromesa.Value = CDate(registro.FecPromesa)
                txtFecPromesa.Text = registro.FecPromesa.ToString
            End If
            'txtFecPromesa.Text = registro.FecPromesa
            cmbCodMon.Value = registro.Moneda.CodMon
            txtTotPed.Text = registro.TotPed
            txtObsCab.Text = registro.ObsPed
            txtObsDet.Text = registro.ObsDet
            CodPais = registro.Pais.CodPais
            txtPais.Text = registro.Pais.DesPais

            lblEstado.Text = registro.Estado

        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Function getRowTodos1(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Ninguno)"
        Catch ex As Exception
            fila(0) = 0
        End Try
        Return fila
    End Function
  Private Sub llenarCombos()
        Try
            '======================================= ADR ================================================
            dtADR = oPedidoImportService.ConsultarNumerosADR().Tables(0)
            dtADR.Rows.InsertAt(getRowTodos1(dtADR), 0)
            cmbADR.DataSource = dtADR
            cmbADR.DropDownList.DataMember = dtADR.Columns("NumeroADR").ToString
            cmbADR.DropDownList.DisplayMember = dtADR.Columns("NumeroADR").ToString
            cmbADR.DropDownList.ValueMember = dtADR.Columns("NumeroADR").ToString
            cmbADR.DropDownList.Columns(0).DataMember = dtADR.Columns("NumeroADR").ToString
            cmbADR.SelectedIndex = 0
            dtADR = Nothing


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

            dtDatos = oPedidoImportDetService.Mostrar(toNumber(IdPedidoImp)).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)
            enableOpciones()
            txtTotal.Text = oMaestroService.MostrarDato("SIGECOM.Importaciones.PedidoImport", "TotPed", "IdPedidoImp", toNumber(IdPedidoImp))
            txtTotPed.Text = txtTotal.Text
        Catch ex As Exception
            MsgBox("ERROR [INFO-007]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub activar()
        txtFecPed.ReadOnly = False
        txtFecPromesa.ReadOnly = False
        txtNumJob.ReadOnly = False
        btnBuscarJob.Enabled = True
        btnBuscarPais.Enabled = True
        cmbADR.ReadOnly = True
        cmbADR.BackColor = System.Drawing.SystemColors.Control
        'btnBuscarProveedor.Enabled = True
        'txtObsPed.ReadOnly = False
        txtObsCab.ReadOnly = False
        txtObsDet.ReadOnly = False
        btnModificarCabecera.Enabled = True
        btnModificarDetalle.Enabled = True
        cmbCodMon.ReadOnly = True
        cmbCodMon.BackColor = System.Drawing.SystemColors.Control
        biEditar.Enabled = False
        biDeshacer.Enabled = True
        biGuardar.Enabled = True
    End Sub
    Private Sub desactivar()
        txtFecPed.ReadOnly = True
        txtFecPromesa.ReadOnly = True
        txtNumJob.ReadOnly = True
        btnBuscarJob.Enabled = False
        btnBuscarPais.Enabled = False
        cmbADR.ReadOnly = True
        cmbADR.BackColor = System.Drawing.SystemColors.Control
        'btnBuscarProveedor.Enabled = False
        'txtObsPed.ReadOnly = True
        cmbCodMon.ReadOnly = False
        cmbCodMon.BackColor = System.Drawing.SystemColors.Control
        txtObsCab.ReadOnly = True
        txtObsDet.ReadOnly = True
        btnModificarCabecera.Enabled = False
        btnModificarDetalle.Enabled = False
        biEditar.Enabled = True
        biDeshacer.Enabled = False
        biGuardar.Enabled = False
    End Sub
  Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmAgregarDetalle_PedidoImportacion
                frm.state_button = False
                frm.IdPedidoImp = toNumber(IdPedidoImp)
                frm.IdLocacion = IdLocacion
                frm.estado_pedido = "GN"
                frm.txtItem.Text = toNumber(dgvDatos.GetRow(dgvDatos.RowCount - 1).Cells("Item").Text) + 1
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdDetPedidoImp)
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

                Dim registro As New PedidoImportDetService.PedidoImportDet
                Dim pedidoImp As New PedidoImportDetService.PedidoImport
                registro.IdDetPedidoImp = toNumber(dgvDatos.CurrentRow.Cells("IdDetPedidoImp").Text)
                pedidoImp.IdPedidoImp = toNumber(IdPedidoImp)
                registro.PedidoImp = pedidoImp
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                estado_process = oPedidoImportDetService.Borrar(registro)

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

            Dim frm As New frmAgregarDetalle_PedidoImportacion
            frm.state_button = True
            frm.IdDetPedidoImp = dgvDatos.CurrentRow.Cells("IdDetPedidoImp").Text
            frm.estado_pedido = toBlank(lblEstado.Text)


            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdDetPedidoImp)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-010]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
  End Sub
  Private Sub actualizar()
        Try

            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                codigo = dgvDatos.CurrentRow.Cells("IdDetPedidoImp").Text
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

  '====================================================================================================================
  '============================================ INTERFACE'S METHOD ====================================================
  '====================================================================================================================

    'Private Sub btnBuscarAlmacen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarAlmacen.Click
    '  Dim frm As New frmBuscarAlmacen
    '  If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '    txtalmacen.Text = frm.descripcion
    '    txtalmacen.BackColor = System.Drawing.SystemColors.Control
    '    IdLocacion = frm.codigo
    '  End If
    'End Sub
  Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
    Dim frm As New frmBuscarProveedor
    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
      txtProveedor.Text = frm.descripcion
      txtProveedor.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
            AbrvProv = frm.abreviatura
            If state_button = False Then
                txtNumPed.Text = oPedidoImportService.MostrarNumPed(IdCliente, txtFecPed.Text)
            End If
            txtProveedor.Select()
    End If
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
    NuevoDetalle()
  End Sub
  Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
    If ValidaCodigoSeleccionado() Then
      mostrarDetalle()
    End If
  End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
       And ValidaCampos() Then

            Dim registro As New PedidoImportService.PedidoImport
            Dim locacion As New PedidoImportService.Locacion
            Dim proveedor As New PedidoImportService.Proveedor
            Dim Job As New PedidoImportService.Job
            Dim NumeroADR As New PedidoImportService.NumerosADR
            Dim paisOrigen As New PedidoImportService.Pais
            Dim moneda As New PedidoImportService.Moneda


            registro.IdPedidoImp = toNumber(IdPedidoImp)
            locacion.IdLocacion = toNull(IdLocacion)
            registro.Locacion = locacion
            proveedor.IdProveedor = toNull(IdCliente)
            registro.Proveedor = proveedor
            Job.CodJob = IIf(txtNumJob.Text = "", Nothing, txtNumJob.Text)
            registro.Job = Job
            NumeroADR.NumeroADR = IIf(cmbADR.SelectedIndex = 0, Nothing, cmbADR.Value)
            registro.NumerosADR = NumeroADR
            registro.NumPed = toNull(txtNumPed.Text)
            registro.FecPed = toNull(txtFecPed.Text)
            registro.FecPromesa = toNull(txtFecPromesa.Text)
            registro.ObsPed = toNull(txtObsCab.Text)
            registro.ObsDet = toNull(txtObsDet.Text)
            'registro.ObsPed = toNull(txtObsPed.Text)
            paisOrigen.CodPais = CodPais
            registro.Pais = paisOrigen
            moneda.CodMon = cmbCodMon.Value
            registro.Moneda = moneda
            txtObsCab.ReadOnly = True
            txtObsDet.ReadOnly = True

            registro.CodUsu = Session.sCodUsu

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
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
    Private Sub biEditar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.Click
        sslError.Text = "Editar Cabecera de la Orden de Pedido de Importación."
    End Sub

    Private Sub biGuardar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        sslError.Text = "Grabar los Cambios Hechos en la Orden de Pedido de Importación."
    End Sub
    Private Sub biDeshacer_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        sslError.Text = "Deshacer los Cambios Hechos en la Cabecera de la Orden de Pedido de Importación."
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        sslError.Text = "Cerrar y Salir del Formulario de la Orden de Pedido de Importación."
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

    Private Sub miBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miBuscar.Click
        BuscarDetalle()

    End Sub
    Private Sub BuscarDetalle()
        Try
            Dim frm As New frmBuscarDetalle
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                'MessageBox.Show(" " & frm.codigoDetalle)
                Dim rows() As Janus.Windows.GridEX.GridEXRow
                rows = dgvDatos.GetRows

                For Each row In rows

                    If CStr(row.Cells("CodMer").Value) = frm.codigoDetalle Then

                        dgvDatos.Row = row.Position
                        dgvDatos.Col = 1

                        Exit For
                    End If

                Next
                'RowPossesion(dgvDatos, dtDatos, "CodMer", frm.codigoDetalle)
            End If
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnModificarCabecera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarCabecera.Click
        Dim frm As New frmPedidoImportacion_EditarCabecera

        frm.NumPed = txtNumPed.Text
        frm.ObservCab = txtObsCab.Text
        frm.txtObsCab.Text = toBlank(txtObsCab.Text)
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtObsCab.Text = toBlank(frm.txtObsCab.Text)
        End If
        txtObsCab.Select()
    End Sub

    Private Sub btnModificarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarDetalle.Click
        Dim frm As New frmPedidoImportacion_EditarDetalle

        frm.NumPed = txtNumPed.Text
        frm.ObservDet = txtObsDet.Text
        frm.txtObsDet.Text = toBlank(txtObsDet.Text)
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtObsDet.Text = toBlank(frm.txtObsDet.Text)
        End If
        txtObsDet.Select()
    End Sub

    Private Sub txtNumPed_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumPed.TextChanged
        ActualizarObsCabecera()
        ActualizarObsDetalle()
    End Sub

    Private Sub ActualizarObsCabecera()
        If IdCliente = "404" Then
            txtObsCab.Text = "A/To : STEVE REMMICK                                                           Referencia  :   ORDER " & AbrvProv & "" & txtNumPed.Text & "-" & Mid(Today.Year, 3, 2) & Environment.NewLine &
                                    "  " & Environment.NewLine &
                                    "PLEASE ENTER OUR ORDER  " & AbrvProv & "" & txtNumPed.Text & "-" & Mid(Today.Year, 3, 2) & ",  TO BE SHIPPED OPEN ACCOUNT, SURFACE TO :" & Environment.NewLine &
                                    "DISTRIBUCIONES DIESEL PERU S.A.C."
        Else : txtObsCab.Text = ""
        End If
    End Sub

    Private Sub txtProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProveedor.TextChanged
        ActualizarObsCabecera()
        ActualizarObsDetalle()
    End Sub

    Private Sub ActualizarObsDetalle()
        If IdCliente = "404" Then
            txtObsDet.Text = "REGARDS," & Environment.NewLine &
                                   "MORI VALDIZAN" & Environment.NewLine &
                                   "DISTRIBUCIONES DIESEL PERU S.A.C." & Environment.NewLine &
                                   "LIMA PERU"
        Else : txtObsCab.Text = ""
        End If
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Try
            Dim frm As New frmBuscarJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.cod_job) <> Nothing Then
                    txtNumJob.Text = frm.cod_job
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
        If e.KeyCode = Keys.F12 Then
            If btnBuscarJob.Enabled = True Then
                e.Handled = True
                btnBuscarJob_Click(sender, e)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    txtFecPed.Focus()
                End If
            Else
                txtFecPed.Focus()
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
                ElseIf oJobService.Estado(txtNumJob.Text) = 1 Then
                    MsgBox("Número de OT Anulado, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    txtFecPed.Focus()
                End If
            Else
                txtFecPed.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA OT : " + ex.Message)
        End Try
    End Sub

    Private Sub btnBuscarPais_Click(sender As Object, e As EventArgs) Handles btnBuscarPais.Click
        Dim frm As New frmBuscarPais
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtPais.Text = frm.descripcion
            txtPais.BackColor = System.Drawing.SystemColors.Control
            CodPais = frm.codigo
        End If
        txtPais.Focus()
    End Sub
End Class
