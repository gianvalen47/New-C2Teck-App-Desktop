Imports System.Windows.Forms

Public Class frmMovimientoAlmacen

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMaestroService As New MaestroService.MaestroClient
    Private oMoviAlmacenService As New MoviAlmacenService.MoviAlmacenServiceClient
    Private oMoviAlmacenDetService As New MoviAlmacenDetService.MoviAlmacenDetServiceClient
    Private oLocacionClienteService As New LocacionClienteService.LocacionClienteServiceClient
    Private oContactoService As New ContactoService.ContactoServiceClient
    Private dtDatos As DataTable
    Private dtLocaciones As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdMovimiento As String
    Public IdLocacion As String
    Private IdCliente As String
    Private CodMerRef As String
    Private ConLocCli As Integer = 0
    Private dtAlmacenes As DataTable
    Private dtTipoDocumentos As DataTable
    Private dtTipoMovimientos As DataTable
    Private dtMonedas As DataTable
    Private dtAreas As DataTable
    Private dtMotivos As DataTable

    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress, txtNumFac.KeyPress
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnGuardar.Enabled = True Then
                btnBuscarCliente_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnGuardar.Enabled = True Then
                btnBuscarJob_Click(sender, e)
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
    Private Sub txtNumFac_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumFac.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtNumJob.Select()
        End If
    End Sub

    Private Sub cmbIdLocCli_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbIdLocCli.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnAgregarLocacion.Enabled = True Then
                e.Handled = True
                btnAgregarLocacion_Click(sender, e)
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

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtNumJob.KeyPress _
                          , txtTipoCambio.KeyPress _
                          , txtFecDoc.KeyPress _
                          , txtCliente.KeyPress _
                          , cmbCodMon.KeyPress _
                          , txtIgv.KeyPress _
                          , cmbTipMov.KeyPress _
                          , cmbIdSerieDoc.KeyPress
        ', txtObservacion.KeyPress _
        ', txtNumFac.KeyPress _
        ', txtNumDoc.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmMovimientoAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
            e.Handled = True
        ElseIf e.KeyCode = Keys.Insert Then
            If miNuevo.Enabled = True Then
                miNuevo_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        llenarCombos()
        If state_button Then    'Modificar

            txtNumDoc.ReadOnly = True
            txtNumDoc.TabStop = False
            ObtenerRegistro()
            btnBuscarJob.Enabled = False
            txtObservacion.ReadOnly = True
            txtNumFac.ReadOnly = True
            gbEstado.Visible = True
            listaDatos()
            'If (lblEstado.Text = "GENERADO" Or lblEstado.Text = "GN") Then
            'btnGuardar.Enabled = True
            ' listaDatos()
            'dgvDatos.Select()
            'Else
            'btnGuardar.Enabled = False

            'End If

            btnBuscarCliente.Enabled = False
            txtFecDoc.ReadOnly = True
            txtFecDoc.BackColor = System.Drawing.SystemColors.Control
            cmbTipMov.ReadOnly = True
            cmbTipMov.BackColor = System.Drawing.SystemColors.Control
            cmbIdSerieDoc.ReadOnly = True
            cmbIdSerieDoc.BackColor = System.Drawing.SystemColors.Control
            cmbCodMon.ReadOnly = True
            cmbCodMon.BackColor = System.Drawing.SystemColors.Control
            cmbIdLocCli.ReadOnly = True
            cmbIdLocCli.BackColor = System.Drawing.SystemColors.Control

            Me.Text = "Movimiento Almacén Nº " + Chr(34) + txtNumDoc.Text.ToString + Chr(34)
        Else                    'Nuevo

            txtNumDoc.ReadOnly = True
            txtNumDoc.TabStop = False
            gbEstado.Visible = False
            btnCancelar.Enabled = False
            btnEditar.Enabled = False
            btnBuscarCliente.Visible = True
            cmbCodMon.Value = "US"
            Me.Size = New System.Drawing.Size(751, 235)
            Me.Text = "Registrar nuevo Movimiento Almacén"
        End If
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oMoviAlmacenService) = False Then
                oMoviAlmacenService.Close()
            End If
            If isClosed(oMoviAlmacenDetService) = False Then
                oMoviAlmacenDetService.Close()
            End If
            If isClosed(oLocacionClienteService) = False Then
                oLocacionClienteService.Close()
            End If
            If isClosed(oContactoService) = False Then
                oContactoService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub txtNumDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnBuscarCliente.Focus()
        End If
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                           txtNumDoc.KeyUp
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
            fila(3) = "(Ninguno)"
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

                If CInt(row.Cells("IdMovimientoDet").Value) = codigo Then

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

            miEliminar.Enabled = False
            miModificar.Enabled = False
            btnGuardar.Enabled = False
            btnDeshacer.Enabled = False

        Else
            If state_button = True And (toBlank(lblEstado.Text) = "GENERADO" Or toBlank(lblEstado.Text) = "GN") Then

                btnGuardar.Enabled = False
                btnEditar.Enabled = True
                btnDeshacer.Enabled = False

                miEliminar.Enabled = True
                miModificar.Enabled = True


            ElseIf state_button = True And (toBlank(lblEstado.Text) = "IMPRESO" Or toBlank(lblEstado.Text) = "IM") Then

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
    Private Sub enableCampos(ByVal codigo As String)
        If codigo = "10" Then               'TRANSFERENCIA INTERNA
            txtNumFac.Enabled = False
        ElseIf codigo = "15" Then           'Vale Materiales 
            txtNumFac.Enabled = True
        ElseIf codigo = "16" Then           'Memo de transferencia Desarmados 
            txtNumFac.Enabled = False
        Else
            txtNumFac.Enabled = True
        End If
    End Sub
    Private Function SumarSubTotal(ByVal campo As String, ByVal nro_columna As Integer) As Double
        Dim total As Double = 0
        For i As Integer = 0 To dtDatos.Rows.Count - 1
            Dim r As DataRow
            r = dtDatos.Rows.Item(i)
            total = total + CDbl(r.Item(nro_columna))
        Next
        Return total
    End Function

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If CLng(txtNumDoc.Text) = 0 Then
                MsgBox("Debe Ingresar el número del documento.", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False

            ElseIf toNumber(cmbIdSerieDoc.Value) = 0 Then
                MsgBox("Debe Ingresar el tipo de documento.", MsgBoxStyle.Information, "Información")
                cmbTipMov.Focus()
                Return False

            ElseIf toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar el cliente ", MsgBoxStyle.Information, "Información")
                txtCliente.BackColor = Color.Red
                txtCliente.Focus()
                Return False
            ElseIf toNull(cmbCodMon.Value) = Nothing Then
                MsgBox("Debe tipo de moneda.", MsgBoxStyle.Information, "Información")
                cmbCodMon.BackColor = Color.Red
                cmbCodMon.Focus()
                Return False
            ElseIf toNull(cmbTipMov.Value) = Nothing Then
                MsgBox("Debe Ingresar el tipo de Movimiento que desea hacer.", MsgBoxStyle.Information, "Información")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
            ElseIf cmbCodMon.Value <> "NS" And toDouble(txtTipoCambio.Text) <= 0 Then
                MsgBox("Tipo de cambio no puede ser CERO..", MsgBoxStyle.Information, "Información")
                txtTipoCambio.BackColor = Color.Red
                txtTipoCambio.Focus()
                Return False
            ElseIf state_button = False And oMoviAlmacenService.Buscar(IdLocacion, cmbIdSerieDoc.Value, IdCliente, toNumber(txtNumDoc.Text)) Then
                MsgBox("Número " + txtNumDoc.Text + " de documento ya existe...!", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf state_button = True And toBlank(lblEstado.Text) <> "GENERADO" And toBlank(lblEstado.Text) <> "GN" Then
                MsgBox("Pedido ya no se puede modificar...!" + vbCr + "Debido que ya no se encuentra en el estado generado...!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As MoviAlmacenService.MoviAlmacen)
        Try
            Dim estado_process As Integer
            estado_process = oMoviAlmacenService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdMovimiento = estado_process
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As MoviAlmacenService.MoviAlmacen)
        Try
            Dim estado_process As Boolean
            estado_process = oMoviAlmacenService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                'Me.DialogResult = Windows.Forms.DialogResult.OK
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
            estado_process = oMoviAlmacenService.Borrar(toNull(IdMovimiento), Session.sCodUsu)
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
            Dim registro As MoviAlmacenService.MoviAlmacen
            registro = oMoviAlmacenService.MostrarPorId(toNumber(IdMovimiento))

            IdMovimiento = registro.IdMovimiento
            IdLocacion = registro.Locacion.IdLocacion
            '======================================= TIPOS DE DOCUMENTOS ================================================
            dtTipoDocumentos = oMaestroService.MostrarSerieDocumento(toNumber(IdLocacion), 2, cmbTipMov.Value).Tables(0)
            cmbIdSerieDoc.DataSource = dtTipoDocumentos
            cmbIdSerieDoc.DropDownList.DataMember = dtTipoDocumentos.Columns("Descripcion").ToString
            cmbIdSerieDoc.DropDownList.DisplayMember = dtTipoDocumentos.Columns("Descripcion").ToString
            cmbIdSerieDoc.DropDownList.ValueMember = dtTipoDocumentos.Columns("IdSerieDoc").ToString
            cmbIdSerieDoc.DropDownList.Columns(0).DataMember = dtTipoDocumentos.Columns("IdSerieDoc").ToString
            cmbIdSerieDoc.DropDownList.Columns(1).DataMember = dtTipoDocumentos.Columns("Descripcion").ToString
            dtTipoDocumentos = Nothing

            cmbIdSerieDoc.Value = registro.SerieDocumento.IdSerieDoc
            txtNumDoc.Text = registro.NumDoc
            txtFecDoc.Text = registro.FecDoc
            IdCliente = registro.Cliente.IdCliente
            listarLocacionesCliente()
            txtCliente.Text = registro.Cliente.DesCli
            cmbCodMon.Value = registro.Moneda.CodMon
            txtNumJob.Text = toBlank(registro.NumJob)
            cmbTipMov.Value = registro.TipMov
            txtNumFac.Text = toNull(registro.NumFac)
            txtIgv.Text = registro.Igv
            txtObservacion.Text = toBlank(registro.Observacion)
            lblEstado.Text = toBlank(registro.Estado)
            cmbIdLocCli.Value = registro.LocacionCliente.IdLocCli

            enableCampos(toBlank(cmbIdSerieDoc.Value))
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= TIPOS DE DOCUMENTOS ================================================
            dtTipoDocumentos = oMaestroService.MostrarSerieDocumento(toNumber(IdLocacion), 2, cmbTipMov.Value).Tables(0)
            cmbIdSerieDoc.DataSource = dtTipoDocumentos
            cmbIdSerieDoc.DropDownList.DataMember = dtTipoDocumentos.Columns("Descripcion").ToString
            cmbIdSerieDoc.DropDownList.DisplayMember = dtTipoDocumentos.Columns("Descripcion").ToString
            cmbIdSerieDoc.DropDownList.ValueMember = dtTipoDocumentos.Columns("IdSerieDoc").ToString
            cmbIdSerieDoc.DropDownList.Columns(0).DataMember = dtTipoDocumentos.Columns("IdSerieDoc").ToString
            cmbIdSerieDoc.DropDownList.Columns(1).DataMember = dtTipoDocumentos.Columns("Descripcion").ToString
            dtTipoDocumentos = Nothing
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
            dtTipoMovimientos = New DataTable
            dtTipoMovimientos.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtTipoMovimientos.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtTipoMovimientos.Rows.Add(New Object() {"H", "Ingreso"})
            dtTipoMovimientos.Rows.Add(New Object() {"D", "Salida"})
            'dtTipoMovimientos.Rows.Add(New Object() {"C", "Costos"})

            cmbTipMov.DataSource = dtTipoMovimientos
            cmbTipMov.DropDownList.DataMember = dtTipoMovimientos.Columns("nombre").ToString
            cmbTipMov.DropDownList.DisplayMember = dtTipoMovimientos.Columns("nombre").ToString
            cmbTipMov.DropDownList.ValueMember = dtTipoMovimientos.Columns("codigo").ToString
            cmbTipMov.DropDownList.Columns(0).DataMember = dtTipoMovimientos.Columns("codigo").ToString
            cmbTipMov.DropDownList.Columns(1).DataMember = dtTipoMovimientos.Columns("nombre").ToString
            cmbTipMov.SelectedIndex = 1
            dtTipoMovimientos = Nothing

        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oMoviAlmacenDetService.Mostrar(toNumber(IdMovimiento)).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)

            txtTotalPrecio.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.MoviAlmacen", "TotBruto", "IdMovimiento", IdMovimiento)
            txtTotalDescuento.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.MoviAlmacen", "TotDscto", "IdMovimiento", IdMovimiento)
            txtTotal.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.MoviAlmacen", "TotVenta", "IdMovimiento", IdMovimiento)
            txtTotalIGV.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.MoviAlmacen", "TotIgv", "IdMovimiento", IdMovimiento)
            txtTotalNeto.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.MoviAlmacen", "TotNeto", "IdMovimiento", IdMovimiento)
            lblTotal.Text = "SUB TOTALES"
            lbltotalIGV.Text = "IGV"
            lblTotalNeto.Text = "TOTAL (" + oMaestroService.MostrarDato("SIGECOM.Maestro.Monedas", "AbrMon", "CodMon", oMaestroService.MostrarDato("SIGECOM.Almacen.MoviAlmacen", "CodMon", "IdMovimiento", IdMovimiento)) + ")"

            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [INFO-007]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listarLocacionesCliente()
        '======================================= LOCACIONES DEL CLIENTE ================================================
        dtLocaciones = oLocacionClienteService.Mostrar(IdCliente).Tables(0)
        dtLocaciones.Rows.InsertAt(getRowTodos(dtLocaciones), 0)
        cmbIdLocCli.DataSource = dtLocaciones
        cmbIdLocCli.DropDownList.DataMember = dtLocaciones.Columns("Nombre").ToString
        cmbIdLocCli.DropDownList.DisplayMember = dtLocaciones.Columns("Nombre").ToString
        cmbIdLocCli.DropDownList.ValueMember = dtLocaciones.Columns("IdLocCli").ToString
        cmbIdLocCli.DropDownList.Columns(0).DataMember = dtLocaciones.Columns("IdLocCli").ToString
        cmbIdLocCli.DropDownList.Columns(1).DataMember = dtLocaciones.Columns("Nombre").ToString
        ConLocCli = dtLocaciones.Rows.Count
        cmbIdLocCli.SelectedIndex = 0
        dtLocaciones = Nothing
     
    End Sub
    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmMovimAlmacen_AgregarDetalle
                frm.state_button = False
                frm.IdMovimiento = IdMovimiento
                frm.IdLocacion = IdLocacion
                frm.estado = "GN"
                frm.tioMovimineto = cmbTipMov.Value
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdMovimientoDet)
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

                estado_process = oMoviAlmacenDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdMovimientoDet").Text), _
                                                               IdMovimiento, Session.sCodUsu)
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
            Dim frm As New frmMovimAlmacen_AgregarDetalle
            frm.state_button = True
            frm.IdMovimientoDet = dgvDatos.CurrentRow.Cells("IdMovimientoDet").Text
            frm.IdMovimiento = IdMovimiento
            frm.IdLocacion = IdLocacion
            frm.estado = toBlank(lblEstado.Text)
            frm.tioMovimineto = cmbTipMov.Value

            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdMovimientoDet)
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
            ElseIf toNumber(IdLocacion) = 0 Then
                MsgBox("Debe ingresar el almacén.", MsgBoxStyle.Information, "Información")
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
                    codigo = dgvDatos.CurrentRow.Cells("IdMovimientoDet").Text
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
        txtObservacion.ReadOnly = False
        txtNumFac.ReadOnly = False
        cmbIdLocCli.ReadOnly = False
        cmbIdLocCli.BackColor = System.Drawing.SystemColors.Window


    End Sub
    Private Sub desactivar()

        txtObservacion.ReadOnly = True
        txtCliente.ReadOnly = True
        txtCliente.BackColor = System.Drawing.SystemColors.Control
        txtNumJob.ReadOnly = True
        txtNumJob.BackColor = System.Drawing.SystemColors.Control
        cmbIdLocCli.ReadOnly = True
        cmbIdLocCli.BackColor = System.Drawing.SystemColors.Control
        btnBuscarCliente.Enabled = False
        btnBuscarJob.Enabled = False
        txtNumFac.ReadOnly = True
        btnEditar.Enabled = True

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
            listarLocacionesCliente()
        End If
        txtCliente.Select()
    End Sub
    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Dim frm As New frmBuscarJob
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.Text = frm.cod_job
        End If
        txtNumJob.Select()
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
    Private Sub cmbIdSerieDoc_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIdSerieDoc.ValueChanged
        If state_button = False Then
            txtNumDoc.ReadOnly = False
            txtNumDoc.TabStop = True
            txtNumDoc.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.SerieDocumento", "NumDoc", "IdSerieDoc", cmbIdSerieDoc.Value)
        End If
        enableCampos(toBlank(cmbIdSerieDoc.Value))
    End Sub
    Private Sub cmbCodMon_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodMon.ValueChanged
        'txtTipoCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio("US", Date.Today)), "#0.000")
        txtTipoCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio("US", txtFecDoc.Text)), "#0.000")
    End Sub
    Private Sub cmbTipMov_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '======================================= TIPOS DE DOCUMENTOS ================================================
        dtTipoDocumentos = oMaestroService.MostrarSerieDocumento(toNumber(IdLocacion), 2, cmbTipMov.Value).Tables(0)
        cmbIdSerieDoc.DataSource = dtTipoDocumentos
        cmbIdSerieDoc.DropDownList.DataMember = dtTipoDocumentos.Columns("Nombre").ToString
        cmbIdSerieDoc.DropDownList.DisplayMember = dtTipoDocumentos.Columns("Nombre").ToString
        cmbIdSerieDoc.DropDownList.ValueMember = dtTipoDocumentos.Columns("IdSerieDoc").ToString
        cmbIdSerieDoc.DropDownList.Columns(0).DataMember = dtTipoDocumentos.Columns("IdSerieDoc").ToString
        cmbIdSerieDoc.DropDownList.Columns(1).DataMember = dtTipoDocumentos.Columns("Nombre").ToString
        dtTipoDocumentos = Nothing
        txtIgv.Text = toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Parametros", "igv", "IdLocacion", IdLocacion)) / 100
    End Sub
    Private Sub cmbTipMov_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipMov.ValueChanged
        '======================================= TIPOS DE DOCUMENTOS ================================================
        dtTipoDocumentos = oMaestroService.MostrarSerieDocumento(toNumber(IdLocacion), 2, cmbTipMov.Value).Tables(0)
        cmbIdSerieDoc.DataSource = dtTipoDocumentos
        cmbIdSerieDoc.DropDownList.DataMember = dtTipoDocumentos.Columns("Descripcion").ToString
        cmbIdSerieDoc.DropDownList.DisplayMember = dtTipoDocumentos.Columns("Descripcion").ToString
        cmbIdSerieDoc.DropDownList.ValueMember = dtTipoDocumentos.Columns("IdSerieDoc").ToString
        cmbIdSerieDoc.DropDownList.Columns(0).DataMember = dtTipoDocumentos.Columns("IdSerieDoc").ToString
        cmbIdSerieDoc.DropDownList.Columns(1).DataMember = dtTipoDocumentos.Columns("Descripcion").ToString
        dtTipoDocumentos = Nothing
        txtIgv.Text = toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Parametros", "igv", "IdLocacion", IdLocacion)) / 100
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
           And ValidaCampos() Then

            Dim registro As New MoviAlmacenService.MoviAlmacen
            Dim locacion As New MoviAlmacenService.Locacion
            Dim almacen As New TransferenciaService.Almacen
            Dim serie As New MoviAlmacenService.SerieDocumento
            Dim cliente As New MoviAlmacenService.Cliente
            Dim moneda As New MoviAlmacenService.Moneda
            Dim locacionCliente As New MoviAlmacenService.LocacionCliente

            registro.IdMovimiento = toNull(IdMovimiento)
            locacion.IdLocacion = toNull(IdLocacion)
            registro.Locacion = locacion
            locacionCliente.IdLocCli = toNull(cmbIdLocCli.Value)
            registro.LocacionCliente = locacionCliente
            serie.IdSerieDoc = toNull(cmbIdSerieDoc.Value)
            registro.SerieDocumento = serie
            registro.NumDoc = toNull(txtNumDoc.Text)
            registro.FecDoc = toNull(txtFecDoc.Text)
            cliente.IdCliente = toNull(IdCliente)
            registro.Cliente = cliente
            moneda.CodMon = toNull(cmbCodMon.Value)
            registro.Moneda = moneda
            registro.NumJob = toNull(txtNumJob.Text)
            registro.TipMov = toNull(cmbTipMov.Value)
            registro.NumFac = IIf(toBlank(txtNumFac.Text) = "", Nothing, toNumber(txtNumFac.Text))
            registro.Igv = toNull(txtIgv.Text)
            registro.Observacion = toNull(txtObservacion.Text)
            registro.Estado = toNull(lblEstado.Text)
            registro.CodUsu = Session.sCodUsu

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
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
        sslError.Text = "Editar la Cabecera del Documento."
    End Sub

    Private Sub biGrabar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.MouseEnter
        sslError.Text = "Grabar los Cambios Hechos en el Documento."
    End Sub
    Private Sub biDeshacer_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeshacer.MouseEnter
        sslError.Text = "Deshacer los Cambios Hechos en la Cabecera del Documento."
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario Documento."
    End Sub

    Private Sub miNuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Detalle del Documento."
    End Sub
    Private Sub miModificar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miModificar.MouseEnter
        sslError.Text = "Modificar Detalle actual."
    End Sub
    Private Sub miEliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.MouseEnter
        sslError.Text = "Eliminar Detalle actual."
    End Sub
    Private Sub miActualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.MouseEnter
        sslError.Text = "Actualizar detalles del Formulario Documento."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                   btnGuardar.MouseLeave, btnDeshacer.MouseLeave, _
                                   btnEditar.MouseLeave, btnCancelar.MouseLeave, _
                                   miNuevo.MouseLeave, miModificar.MouseLeave, _
                                   miEliminar.MouseLeave, miActualizar.MouseLeave
        sslError.Text = ""
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

    Private Sub txtFecDoc_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecDoc.ValueChanged
        txtTipoCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio("US", txtFecDoc.Text)), "#0.000")
    End Sub

    Private Sub btnAgregarLocacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarLocacion.Click
        If IdCliente > 0 Then
            Dim forma As New frmAgregarLocacionCliente
            forma.IdCliente = IdCliente
            If forma.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                listarLocacionesCliente()
                ' cmbIdContacto.Text = forma.txtNombres.Text & " " & frmAgregarContacto.txtApellidos.Text
                'cmbIdLocCli.ReadOnly = True
            End If
            ' MsgBox(cmbIdContacto.Value)  
        End If
        cmbIdLocCli.Select()
    End Sub
End Class
