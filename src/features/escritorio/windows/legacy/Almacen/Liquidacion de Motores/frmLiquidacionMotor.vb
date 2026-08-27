Imports System.Windows.Forms

Public Class frmLiquidacionMotor


    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMaestroService As New MaestroService.MaestroClient
    Private oLiquidacionMotorService As New LiquidacionMotorService.LiquidacionMotorServiceClient
    Private oLiquidacionMotorDetService As New LiquidacionMotorDetService.LiquidacionMotorDetServiceClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdLiqMotor As String
    Public IdLocacion As String
    Private IdCliente As String
    Private IdPer As String
    Private CodMerRef As String

    Private dtAlmacenes As DataTable
    Private dtTipoDocumentos As DataTable
    Private dtTipoMovimientos As DataTable
    Private dtMonedas As DataTable
    Private dtAreas As DataTable
    Private dtMotivos As DataTable

    Private Sub txtCodMer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMer.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarMercaderia.Enabled = True Then
                btnBuscarMercaderia_Click(sender, e)
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

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarJob.Enabled = True Then
                btnBuscarJob_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGuardar.Enabled = True Then
                biGuardar_Click(sender, e)
                e.Handled = True
            Else
                dgvDatos.Select()
            End If
        End If
    End Sub
    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 And miMostrar.Enabled = True Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                           txtFecha.KeyPress _
                          , txtCliente.KeyPress _
                          , txtNumJob.KeyPress _
                          , cmbCodMon.KeyPress _
                          , txtTipCam.KeyPress _
                          , cmbIdMotLiq.KeyPress
        ', txtObservacion.KeyPress
        'txtCodMer.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtCodMer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodMer.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente.Select()
            End If
        End If
    End Sub

    Private Sub frmLiquidacionMotor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            biSalir_Click(sender, e)
            e.Handled = True
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.CancelButton = Me.btnCancelar
        'Me.Size = New System.Drawing.Size(670, 195)
        llenarCombos()
        If state_button Then    'Modificar
            'Me.btnGuardar.Location = New System.Drawing.Point(428, 133)
            'Me.btnEliminar.Location = New System.Drawing.Point(502, 133)
            ObtenerRegistro()
            gbEstado.Visible = True
            btnBuscarMercaderia.Enabled = False
            btnBuscarCliente.Enabled = False
            btnBuscarJob.Enabled = False
            cmbIdMotLiq.ReadOnly = True
            cmbCodMon.ReadOnly = True
            cmbCodMon.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = True
            biGuardar.Enabled = False
            biDeshacer.Enabled = False
            txtFecha.ReadOnly = True
            'btnVerDetalle.Visible = True
            If (lblEstado.Text <> "GENERADO" Or dgvDatos.RowCount = 0) Then
                biTrasladar.Enabled = False
            Else
                biTrasladar.Enabled = True
            End If
            listaDatos()

            Me.Text = "Liquidación del Motor " + Chr(34) + txtCodMer.Text.ToString + Chr(34)
        Else                    'Nuevo
            'Me.btnGuardar.Location = New System.Drawing.Point(502, 133)
            Me.Size = New System.Drawing.Point(672, 215)
            gbEstado.Visible = False
            'btnVerDetalle.Visible = False
            biEditar.Enabled = False
            biTrasladar.Enabled = False
            biSalir.Enabled = False
            cmbCodMon.Value = "US"
            txtTipCam.Text = toDouble(oMaestroService.MostrarTipoCambio(cmbCodMon.Value, txtFecha.Text))
            btnBuscarMercaderia.Select()

            Me.Text = "Registrar nuevo Liquidación del Motor"
        End If
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oLiquidacionMotorService) = False Then
                oLiquidacionMotorService.Close()
            End If
            If isClosed(oLiquidacionMotorDetService) = False Then
                oLiquidacionMotorDetService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub



    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                           txtCodMer.KeyUp _
                          , txtFecha.KeyUp _
                          , txtCliente.KeyUp _
                          , txtNumJob.KeyUp _
                          , txtTipCam.KeyUp _
                          , txtObservacion.KeyUp
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
                            cmbCodMon.KeyUp _
                          , cmbIdMotLiq.KeyUp
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
            fila(2) = "(Ninguno)"
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdLiqMotorDet").Value) = codigo Then

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
        If state_button = True And (toBlank(lblEstado.Text) = "GENERADO" Or toBlank(lblEstado.Text) = "GN") Then
            miNuevo.Enabled = True
            miEliminar.Enabled = True
            biEditar.Enabled = True
            If dgvDatos.RowCount = 0 Then
                biTrasladar.Enabled = False
            Else
                biTrasladar.Enabled = True
            End If
        Else
            miNuevo.Enabled = False
            miEliminar.Enabled = False
            miActualizar.Enabled = False
            biEditar.Enabled = False
        End If
    End Sub

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try

            If toBlank(txtCodMer.Text) = "" Then
                MsgBox("Debe Ingresar la serie del Motor.", MsgBoxStyle.Information, "Información")
                txtCodMer.BackColor = Color.Red
                btnBuscarMercaderia.Focus()
                Return False
            ElseIf toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe Ingresar la fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.BackColor = Color.Red
                txtFecha.Focus()
                Return False
            ElseIf toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar el cliente.", MsgBoxStyle.Information, "Información")
                txtCliente.BackColor = Color.Red
                btnBuscarCliente.Focus()
                Return False
            ElseIf toNumber(IdLocacion) = 0 Then
                MsgBox("Debe Ingresar el almacén.", MsgBoxStyle.Information, "Información")
                'txtalmacen.BackColor = Color.Red
                'btnBuscarAlmacen.Focus()
                Return False
            ElseIf toNull(cmbCodMon.Value) = Nothing Then
                MsgBox("Debe tipo el tipo de moneda.", MsgBoxStyle.Information, "Información")
                cmbCodMon.BackColor = Color.Red
                cmbCodMon.Focus()
                Return False
            ElseIf cmbCodMon.Value <> "NS" And toNumber(txtTipCam.Text) <= 0 Then
                MsgBox("Debe tipo de cambio debe ser Mayor que CERO.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toNumber(cmbIdMotLiq.Value) = 0 Then
                MsgBox("Debe ingresar el motivo de la liquidación.", MsgBoxStyle.Information, "Información")
                cmbIdMotLiq.BackColor = Color.Red
                cmbIdMotLiq.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As LiquidacionMotorService.LiquidacionMotor)
        Try

            Dim estado_process As Integer
            estado_process = oLiquidacionMotorService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdLiqMotor = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As LiquidacionMotorService.LiquidacionMotor)
        Try

            Dim estado_process As Boolean
            estado_process = oLiquidacionMotorService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    'Private Sub Eliminar()
    '  Try
    '    Dim estado_process As Boolean
    '    estado_process = oLiquidacionMotorService.Borrar(IdLiqMotor)
    '    type_process = "delete"
    '    If estado_process = True Then
    '      Me.DialogResult = System.Windows.Forms.DialogResult.OK
    '    Else
    '      MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
    '    End If
    '  Catch ex As Exception
    '    MsgBox("ERROR [INFO-004]: " + ex.Message, MsgBoxStyle.Exclamation)
    '  End Try
    'End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As LiquidacionMotorService.LiquidacionMotor
            registro = oLiquidacionMotorService.MostrarPorId(IdLiqMotor)

            IdLiqMotor = registro.IdLiqMotor
            IdLocacion = registro.Locacion.IdLocacion
            'txtalmacen.Text = registro.Locacion.Oficina.DesOfi + " - " + registro.Locacion.Almacen.DesAlm
            cmbIdMotLiq.Value = registro.MotivoLiqMotor.IdMotLiq
            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli
            txtCodMer.Text = registro.Mercaderia.CodMer
            txtFecha.Text = registro.Fecha
            txtNumJob.Text = registro.NumJob
            cmbCodMon.Value = registro.Moneda.CodMon
            txtTipCam.Text = registro.TipCam
            txtTotalNeto.Text = registro.TotalNeto
            txtObservacion.Text = registro.Observacion
            lblEstado.Text = registro.Estado

        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= MOTIVOS DE LIQUIDACION ================================================
            dtMotivos = oMaestroService.MostrarMotivoLiqMotor.Tables(0)
            cmbIdMotLiq.DataSource = dtMotivos
            cmbIdMotLiq.DropDownList.DataMember = dtMotivos.Columns("Nombre").ToString
            cmbIdMotLiq.DropDownList.DisplayMember = dtMotivos.Columns("Nombre").ToString
            cmbIdMotLiq.DropDownList.ValueMember = dtMotivos.Columns("IdMotLiq").ToString
            cmbIdMotLiq.DropDownList.Columns(0).DataMember = dtMotivos.Columns("IdMotLiq").ToString
            cmbIdMotLiq.DropDownList.Columns(1).DataMember = dtMotivos.Columns("Nombre").ToString
            dtMotivos = Nothing
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
            dtDatos = oLiquidacionMotorDetService.Mostrar(IdLiqMotor).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)

            txtTotalNeto.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.LiquidacionMotor", "TotalNeto", "IdLiqMotor", IdLiqMotor)
            lblTotal.Text = "TOTAL (" + oMaestroService.MostrarDato("SIGECOM.Maestro.Monedas", "AbrMon", "CodMon", oMaestroService.MostrarDato("SIGECOM.Almacen.LiquidacionMotor", "CodMon", "IdLiqMotor", IdLiqMotor)) + ")"

            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [INFO-007]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmLiquidacionMotor_AgregarDetalle
                frm.state_button = False
                frm.IdLiqMotor = IdLiqMotor
                frm.estado = "GN"
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdLiqMotorDet)
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
            If MsgBox("¿Está seguro de ELIMINAR el registro con RUBRO : " + dgvDatos.CurrentRow.Cells("Nombre").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oLiquidacionMotorDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdLiqMotorDet").Text), IdLiqMotor)
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
            Dim frm As New frmLiquidacionMotor_AgregarDetalle
            frm.state_button = True
            frm.IdLiqMotorDet = dgvDatos.CurrentRow.Cells("IdLiqMotorDet").Text
            frm.IdLiqMotor = IdLiqMotor
            frm.estado = toBlank(lblEstado.Text)

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdLiqMotorDet)
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
                    codigo = dgvDatos.CurrentRow.Cells("IdLiqMotorDet").Text
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

        btnBuscarCliente.Enabled = False
        btnBuscarJob.Enabled = True
        cmbIdMotLiq.ReadOnly = False
        txtObservacion.ReadOnly = False
        'txtFecha.ReadOnly = False
        biEditar.Enabled = False
        biDeshacer.Enabled = True
        biGuardar.Enabled = True
        biTrasladar.Enabled = False
    End Sub
    Private Sub desactivar()

        btnBuscarCliente.Enabled = False
        btnBuscarJob.Enabled = False
        cmbIdMotLiq.ReadOnly = True
        txtObservacion.ReadOnly = True
        'txtFecha.ReadOnly = True 
        biEditar.Enabled = True
        biDeshacer.Enabled = False
        biGuardar.Enabled = False
        If dgvDatos.RowCount <> 0 Then
            biTrasladar.Enabled = True
        End If
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================

    'Private Sub btnBuscarAlmacen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarAlmacen.Click
    '    Dim frm As New frmBuscarAlmacen
    '    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '        txtalmacen.Text = frm.descripcion
    '        txtalmacen.BackColor = System.Drawing.SystemColors.Control
    '        IdLocacion = frm.codigo
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
    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Dim frm As New frmBuscarJob
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.Text = frm.cod_job
        End If
        txtNumJob.Select()
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
        txtTipCam.Text = toDouble(oMaestroService.MostrarTipoCambio(cmbCodMon.Value, Date.Today))
    End Sub
    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm As New frmBuscarLocacionMercaderia
        frm.IdLocacion = IdLocacion
        frm.CodRub = "04"
        ' frm.cmbCodRub.ReadOnly = True
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCodMer.Text = frm.codigo
            txtCodMer.BackColor = System.Drawing.SystemColors.Window
        End If
        txtCodMer.Select()
        'Dim frm As New frmBuscarMercaderia
        'If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
        '    txtCodMer.Text = frm.codigo
        '    txtCodMer.BackColor = System.Drawing.SystemColors.Control
        'End If
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
        And ValidaCampos() Then

            Dim registro As New LiquidacionMotorService.LiquidacionMotor
            Dim locacion As New LiquidacionMotorService.Locacion
            Dim cliente As New LiquidacionMotorService.Cliente
            Dim moneda As New LiquidacionMotorService.Moneda
            Dim mercaderia As New LiquidacionMotorService.Mercaderia
            Dim motivo As New LiquidacionMotorService.MotivoLiqMotor

            registro.IdLiqMotor = IIf(toNumber(IdLiqMotor) = 0, Nothing, toNumber(IdLiqMotor))
            locacion.IdLocacion = IIf(toNumber(IdLocacion) = 0, Nothing, toNumber(IdLocacion))
            registro.Locacion = locacion
            motivo.IdMotLiq = IIf(toNumber(cmbIdMotLiq.Value) = 0, Nothing, toNumber(cmbIdMotLiq.Value))
            registro.MotivoLiqMotor = motivo
            cliente.IdCliente = IIf(toNumber(IdCliente) = 0, Nothing, toNumber(IdCliente))
            registro.Cliente = cliente
            mercaderia.CodMer = toNull(txtCodMer.Text)
            registro.Mercaderia = mercaderia
            registro.Fecha = toNull(txtFecha.Text)
            registro.NumJob = toNull(txtNumJob.Text)
            moneda.CodMon = toNull(cmbCodMon.Value)
            registro.Moneda = moneda
            registro.TipCam = toDouble(txtTipCam.Text)
            registro.TotalNeto = txtTotalNeto.Text
            registro.Observacion = toNull(txtObservacion.Text)
            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp

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
    Private Sub biTrasladar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTrasladar.Click
        Try
            ValidaCodigoSeleccionado()
            Dim frm As New frmLiquidacionesMotores
            If MsgBox("¿Está seguro de TRANSFERIR el Costo de liquidación del Motor Nº " + txtCodMer.Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                oLiquidacionMotorService.TransferirCostoMotor(IdLiqMotor)
                ObtenerRegistro()

                MsgBox("Se Transfirió la Liquidación para el Motor Nº " + txtCodMer.Text + " correctamente.", MsgBoxStyle.Information)

            End If
        Catch ex As Exception
            MsgBox("ERROR [TRANSTERIR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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
        sslError.Text = "Editar la Cabecera de la Liquidación."
    End Sub

    Private Sub biGuardar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.MouseEnter
        sslError.Text = "Grabar los Cambios Hechos en la Liquidación."
    End Sub
    Private Sub biDeshacer_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.MouseEnter
        sslError.Text = "Deshacer los Cambios Hechos en la Cabecera de la Liquidación."
    End Sub
    Private Sub biTrasladar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTrasladar.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario Liquidación de Motor."
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario Liquidación de Motor."
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

    Private Sub btnBuscarMercaderia_ControlRemoved(sender As Object, e As ControlEventArgs) Handles btnBuscarMercaderia.ControlRemoved

    End Sub
End Class
