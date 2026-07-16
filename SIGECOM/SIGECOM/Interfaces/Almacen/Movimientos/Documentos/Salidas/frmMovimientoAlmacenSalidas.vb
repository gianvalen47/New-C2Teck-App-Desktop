Imports System.Windows.Forms
Imports System.ServiceModel
Imports System.Xml
Imports System.IO

Public Class frmMovimientoAlmacenSalidas

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMaestroService As New MaestroService.MaestroClient
    Private oMoviAlmacenService As New MoviAlmacenService.MoviAlmacenServiceClient
    Private oMoviAlmacenDetService As New MoviAlmacenDetService.MoviAlmacenDetServiceClient
    Private oLocacionClienteService As New LocacionClienteService.LocacionClienteServiceClient
    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient

    Private oContactoService As New ContactoService.ContactoServiceClient
    Private dtDatos As DataTable
    Private dtLocaciones As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdMovimiento As String
    Public IdLocacion As String
    Public IdGasto As String
    Public IdSerieDoc As Int32
    Private IdCliente As String
    Private CodMerRef As String
    Private ConLocCli As Integer = 0
    Private dtAlmacenes As DataTable
    Private dtTipoDocumentos As DataTable
    Private dtTipoMovimientos As DataTable
    Private dtMonedas As DataTable
    Private dtAreas As DataTable
    Private dtMotivos As DataTable
    Private dtTipDoc As DataTable

    Private NombreArchivo As String
    Private DocumentoXml As String = ""
    Private DocumentoPdf As Byte() = Nothing

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
    'Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
    '                      txtNumDoc.KeyPress _
    '                      , txtFecDoc.KeyPress _
    '    , txtFecEmision.KeyPress _
    '                      , cmbCodMon.KeyPress _
    '                       , txtCliente.KeyPress _
    '                      , txtIgv.KeyPress _
    '                      , txtNumJob.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        e.Handled = True
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub

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

            btnBuscarMotor.Enabled = False
            btnBuscarCliente.Enabled = False
            btnAgregarProveedor.Enabled = False
            txtFecDoc.ReadOnly = True
            txtFecDoc.BackColor = System.Drawing.SystemColors.Control
            txtFecEmision.ReadOnly = True
            txtFecEmision.BackColor = System.Drawing.SystemColors.Control
            cmbCodMon.ReadOnly = True
            cmbCodMon.BackColor = System.Drawing.SystemColors.Control
            cmbIdLocCli.ReadOnly = True
            cmbIdLocCli.BackColor = System.Drawing.SystemColors.Control
            txtIgv.ReadOnly = True
            txtIgv.BackColor = System.Drawing.SystemColors.Control

            Me.Text = "Documento de Salida de Almacén Nº " + Chr(34) + txtNumDoc.Text.ToString + Chr(34)
        Else                    'Nuevo

            txtNumDoc.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.SerieDocumento", "NumDoc", "IdSerieDoc", IdSerieDoc)

            txtNumDoc.ReadOnly = False
            txtNumDoc.TabStop = True
            gbEstado.Visible = False
            btnCancelar.Enabled = False
            btnEditar.Enabled = False
            btnBuscarCliente.Visible = True
            btnAgregarProveedor.Enabled = True
            biGenerar.Enabled = False
            btnTransferirCostoMotor.Enabled = False
            cmbCodMon.Value = "US"
            'cmbTipoComprobante.SelectedIndex = 2 
            txtIgv.ReadOnly = False

            txtIgv.BackColor = System.Drawing.SystemColors.Window
            Me.Size = New System.Drawing.Size(775, 240)
            Me.Text = "Registrar nuevo documento de salida Almacén"
        End If
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oMoviAlmacenService.Close()
            oMoviAlmacenDetService.Close()
            oLocacionClienteService.Close()
            oOrdenesCompraService.Close()
            oContactoService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oMoviAlmacenService.Abort()
            oMoviAlmacenDetService.Abort()
            oLocacionClienteService.Abort()
            oOrdenesCompraService.Abort()
            oContactoService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oMoviAlmacenService.Abort()
            oMoviAlmacenDetService.Abort()
            oLocacionClienteService.Abort()
            oOrdenesCompraService.Abort()
            oContactoService.Abort()
        End Try
    End Sub
    Private Sub txtNumDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtFecDoc.Focus()
        End If
    End Sub

    Private Sub txtFecDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtFecEmision.Focus()
        End If
    End Sub

    Private Sub txtFecEmision_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecEmision.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            cmbCodMon.Focus()
        End If
    End Sub

    Private Sub cmbCodMon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCodMon.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnBuscarCliente.Focus()
        End If
    End Sub

    Private Sub txtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtObservacion.Focus()
        End If
    End Sub

    Private Sub cmbIdLocCli_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbIdLocCli.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtObservacion.Focus()
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

        Dim ordencompra As Boolean

        ordencompra = False  'oOrdenesCompraService.Buscar(toNumber(txtNumOrden.Text))

        If dgvDatos.RowCount < 1 Then

            btnGuardar.Enabled = False
            btnDeshacer.Enabled = False

            If ordencompra = True Then

                miNuevo.Enabled = False
                miEliminar.Enabled = False
                miModificar.Enabled = False
                miOrdenCompra.Enabled = True

            Else
                miEliminar.Enabled = False
                miModificar.Enabled = False

            End If
        Else

            If state_button = True And (toBlank(lblEstado.Text) = "GENERADO" Or toBlank(lblEstado.Text) = "GN" Or toBlank(lblEstado.Text) = "TRANSITO" Or toBlank(lblEstado.Text) = "TR") Then

                btnGuardar.Enabled = False
                btnEditar.Enabled = True
                btnDeshacer.Enabled = False

                If ordencompra = True Then

                    miNuevo.Enabled = False
                    miEliminar.Enabled = False
                    miModificar.Enabled = False

                    miOrdenCompra.Enabled = False 'True     ---- porque no puede actualizar cada detalle por ahora
                    miRecibir.Enabled = True
                    miRecibirTodos.Enabled = True

                Else

                    miNuevo.Enabled = True
                    miEliminar.Enabled = True
                    miModificar.Enabled = True

                    miOrdenCompra.Enabled = False
                    miRecibir.Enabled = False
                    miRecibirTodos.Enabled = False

                End If

            ElseIf state_button = True And (toBlank(lblEstado.Text) = "CHEQUEADO" Or toBlank(lblEstado.Text) = "CH") Then

                If ordencompra = True Then

                    miNuevo.Enabled = False
                    miEliminar.Enabled = False
                    miModificar.Enabled = False

                    miOrdenCompra.Enabled = False 'True     ---- porque no puede actualizar cada detalle por ahora
                    miRecibir.Enabled = True
                    miRecibirTodos.Enabled = True

                Else

                    miNuevo.Enabled = False
                    miEliminar.Enabled = False
                    miModificar.Enabled = False

                    miOrdenCompra.Enabled = False
                    miRecibir.Enabled = False
                    miRecibirTodos.Enabled = False

                End If



            ElseIf state_button = True And (toBlank(lblEstado.Text) = "IMPRESO" Or toBlank(lblEstado.Text) = "IM") Then

                miNuevo.Enabled = False
                miEliminar.Enabled = False
                miActualizar.Enabled = False
                miModificar.Enabled = False
                miOrdenCompra.Enabled = False

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



            ElseIf toNumber(IdSerieDoc) = 0 Then
                MsgBox("Debe Ingresar el tipo de documento.", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False

            ElseIf toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar el cliente", MsgBoxStyle.Information, "Información")
                txtCliente.BackColor = Color.Red
                txtCliente.Focus()
                Return False
            ElseIf toNull(cmbCodMon.Value) = Nothing Then
                MsgBox("Debe tipo de moneda.", MsgBoxStyle.Information, "Información")
                cmbCodMon.BackColor = Color.Red
                cmbCodMon.Focus()
                Return False
                'ElseIf cmbCodMon.Value <> "NS" And toDouble(txtTipoCambio.Text) <= 0 Then
                '    MsgBox("Tipo de cambio no puede ser CERO..", MsgBoxStyle.Information, "Información")
                '    txtTipoCambio.BackColor = Color.Red
                '    txtTipoCambio.Focus()
                '    Return False
            ElseIf toDouble(txtTipoCambio.Text) = 0 Then
                MsgBox("Tipo de cambio no puede ser CERO..", MsgBoxStyle.Information, "Información")
                txtTipoCambio.BackColor = Color.Red
                txtTipoCambio.Focus()
                Return False
            ElseIf state_button = False And oMoviAlmacenService.Buscar(IdLocacion, IdSerieDoc, IdCliente, toNumber(txtNumDoc.Text)) Then
                MsgBox("Número " + txtNumDoc.Text + " de documento ya existe...!", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf state_button = True And toBlank(lblEstado.Text) <> "GENERADO" And toBlank(lblEstado.Text) <> "GN" And toBlank(lblEstado.Text) <> "TRANSITO" And toBlank(lblEstado.Text) <> "TR" Then
                MsgBox("Pedido ya no se puede modificar...!" + vbCr + "Debido que ya no se encuentra en el estado generado o en transito...!!", MsgBoxStyle.Information, "Información")
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
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
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
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
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
            estado_process = oMoviAlmacenService.Borrar(toNull(IdMovimiento), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
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

            IdSerieDoc = registro.SerieDocumento.IdSerieDoc
            txtNumDoc.Text = registro.NumDoc
            txtFecDoc.Text = registro.FecDoc
            txtFecEmision.Text = registro.FecEmision
            IdCliente = registro.Cliente.IdCliente
            listarLocacionesCliente()
            txtCliente.Text = registro.Cliente.DesCli
            'lblCliente.Text = registro.Cliente.DesCli
            cmbCodMon.Value = registro.Moneda.CodMon
            txtNumJob.Text = toBlank(registro.NumJob)
            txtNumFac.Text = toBlank(registro.NumFac)
            txtIgv.Text = registro.Igv
            txtObservacion.Text = toBlank(registro.Observacion)
            lblEstado.Text = toBlank(registro.Estado)
            cmbIdLocCli.Value = registro.LocacionCliente.IdLocCli

            DocumentoXml = registro.DocumentoXml
            DocumentoPdf = registro.DocumentoPdf
            NombreArchivo = registro.NombreArchivo

            txtMotorDestino.Text = registro.Mercaderia.CodMer
            txtDesMotorDestino.Text = registro.Mercaderia.DesMer1

            enableCampos(toBlank(IdSerieDoc))
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
                frm.tioMovimineto = "D"
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
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

                estado_process = oMoviAlmacenDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdMovimientoDet").Text),
                                                               IdMovimiento, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
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
            frm.tioMovimineto = "D"

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
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
        btnTransferirCostoMotor.Enabled = False
        biGenerar.Enabled = False

        btnBuscarMotor.Enabled = True
        btnBuscarCliente.Enabled = True
        btnAgregarProveedor.Enabled = True
        btnBuscarJob.Enabled = True
        txtObservacion.ReadOnly = False
        txtFecDoc.ReadOnly = False
        txtFecEmision.BackColor = System.Drawing.SystemColors.Window
        txtFecEmision.ReadOnly = False
        txtFecDoc.BackColor = System.Drawing.SystemColors.Window
        'txtNumOrden.ReadOnly = False
        txtNumFac.ReadOnly = False
        cmbIdLocCli.ReadOnly = False
        cmbIdLocCli.BackColor = System.Drawing.SystemColors.Window


    End Sub
    Private Sub desactivar()

        btnTransferirCostoMotor.Enabled = True
        biGenerar.Enabled = True
        btnBuscarMotor.Enabled = False
        txtObservacion.ReadOnly = True
        txtFecDoc.ReadOnly = True
        txtFecDoc.BackColor = System.Drawing.SystemColors.Control
        txtFecEmision.ReadOnly = True
        txtFecEmision.BackColor = System.Drawing.SystemColors.Control

        txtCliente.ReadOnly = True
        txtCliente.BackColor = System.Drawing.SystemColors.Control
        txtNumJob.ReadOnly = True
        txtNumJob.BackColor = System.Drawing.SystemColors.Control
        cmbIdLocCli.ReadOnly = True
        cmbIdLocCli.BackColor = System.Drawing.SystemColors.Control
        btnBuscarCliente.Enabled = False
        btnAgregarProveedor.Enabled = False
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
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
            listarLocacionesCliente()
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

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminarDetalle()
        End If
    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()
    End Sub
    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        If state_button = True And (toBlank(lblEstado.Text) = "GENERADO" Or toBlank(lblEstado.Text) = "GN" Or toBlank(lblEstado.Text) = "TRANSITO" Or toBlank(lblEstado.Text) = "TR") Then
            NuevoDetalle()
        End If
    End Sub
    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            Dim ordencompra As Boolean
            ordencompra = False  'oOrdenesCompraService.Buscar(toNumber(txtNumOrden.Text))
            If ordencompra = False Then
                mostrarDetalle()
            End If
        End If
    End Sub

    Private Sub cmbCodMon_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodMon.ValueChanged
        'txtTipoCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio("US", Date.Today)), "#0.000")
        txtTipoCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio("US", txtFecEmision.Text)), "#0.000")
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
            Dim ordencompra As New MoviAlmacenService.OrdenesCompra
            Dim mercaderia As New MoviAlmacenService.Mercaderia
            Dim proveedor As New MoviAlmacenService.Proveedor
            Dim tipodocumento As New MoviAlmacenService.TipoDocumento

            proveedor.IdProveedor = Nothing
            registro.Proveedor = proveedor
            registro.IdMovimiento = toNull(IdMovimiento)
            locacion.IdLocacion = toNull(IdLocacion)
            registro.Locacion = locacion
            cliente.IdCliente = toNull(IdCliente)
            registro.Cliente = cliente
            locacionCliente.IdLocCli = toNull(cmbIdLocCli.Value)
            registro.LocacionCliente = locacionCliente

            tipodocumento.IdDocumento = 50 'Nothing  'cmbTipoComprobante.Value
            registro.TipoDocumento = tipodocumento
            registro.SerDoc = Nothing  'txtSerDoc.Text


            serie.IdSerieDoc = toNull(IdSerieDoc)
            registro.SerieDocumento = serie
            registro.NumDoc = toNull(txtNumDoc.Text)
            registro.FecDoc = toNull(txtFecDoc.Text)
            registro.FecEmision = toNull(txtFecEmision.Text)

            moneda.CodMon = toNull(cmbCodMon.Value)
            registro.Moneda = moneda
            registro.NumJob = toNull(txtNumJob.Text)
            registro.TipMov = "D"
            registro.NumFac = toNull(txtNumFac.Text) 'IIf(toBlank(txtNumFac.Text) = "", Nothing, toNumber(txtNumFac.Text))
            registro.Igv = toNull(txtIgv.Text)
            registro.Observacion = toNull(txtObservacion.Text)
            registro.AplicaTransito = False
            mercaderia.CodMer = toNull(txtMotorDestino.Text)
            registro.Mercaderia = mercaderia
            ordencompra.IdOrden = Nothing
            registro.OrdenesCompra = ordencompra
            registro.DocumentoXml = Nothing
            registro.DocumentoPdf = Nothing
            registro.NombreArchivo = Nothing
            registro.Estado = toNull(lblEstado.Text)
            registro.CodUsu = Session.sCodUsu
            registro.DirIp = Session.sDirIp
            registro.NomPc = Session.sNomPc

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
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
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub miModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miModificar.Click
        If ValidaCodigoSeleccionado() Then
            Dim ordencompra As Boolean
            ordencompra = False  'oOrdenesCompraService.Buscar(toNumber(txtNumOrden.Text))
            If ordencompra = False Then
                mostrarDetalle()
            End If
            '            mostrarDetalle()
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
                                   btnGuardar.MouseLeave, btnDeshacer.MouseLeave,
                                   btnEditar.MouseLeave, btnCancelar.MouseLeave,
                                   miNuevo.MouseLeave, miModificar.MouseLeave,
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

    Private Sub txtFecEmision_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecEmision.ValueChanged
        txtTipoCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio("US", txtFecEmision.Text)), "#0.000")
        cmbCodMon.Focus()
    End Sub

    Private Sub txtFecDoc_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecDoc.ValueChanged
        If state_button = False Then
            txtFecEmision.Value = txtFecDoc.Value
            txtFecEmision.Focus()
        End If
    End Sub

    Private Sub btnAgregarLocacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarLocacion.Click
        If IdCliente > 0 Then
            Dim forma As New frmAgregarLocacionCliente
            forma.IdCliente = IdCliente
            If forma.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                listarLocacionesCliente()
                ' cmbIdContacto.Text = forma.txtNombres.Text & " " & frmAgregarContacto.txtApellidos.Text
                'cmbIdLocCli.ReadOnly = True
            End If
            ' MsgBox(cmbIdContacto.Value)  
        End If
        cmbIdLocCli.Select()
    End Sub

    'Private Sub txtNumOrden_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumOrden.KeyPress
    '    If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
    '        e.KeyChar = Chr(0)
    '    End If
    'End Sub

    Private Sub miOrdenCompra_Click(sender As Object, e As EventArgs) Handles miOrdenCompra.Click

        'Try
        '    Dim frm As New frmMovimAlmacen_OrdenCompra
        '    frm.IdMovimiento = IdMovimiento
        '    frm.IdOrdenG = toNumber(txtNumOrden.Text) 'dgvDatos.CurrentRow.Cells("IdOrden").Text
        '    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
        '        listaDatos()
        '    End If

        'Catch ex As Exception
        '    MsgBox("ERROR AL INSERTAR LOS DETALLES DE LA ORDEN DE COMPRA." + ex.Message, MsgBoxStyle.Exclamation)
        'End Try

    End Sub

    Private Sub txtNumOrden_Validated(sender As Object, e As EventArgs)
        'Try
        '    If Len(Trim(txtNumOrden.Text)) > 0 Then
        '        If Not (oOrdenesCompraService.Buscar(txtNumOrden.Text)) Then
        '            MsgBox("Número de Orden de Compra no existente, Verifique")
        '            txtNumOrden.Text = ""
        '            txtNumOrden.Focus()
        '        Else
        '            txtNumOrden.Focus()
        '        End If
        '    Else
        '        txtNumOrden.Focus()
        '    End If
        'Catch ex As Exception
        '    MsgBox("ERROR AL OBTENER EL ORDEN DE COMPRA : " + ex.Message)
        'End Try
    End Sub

    Private Sub miRecibirTodos_Click(sender As Object, e As EventArgs) Handles miRecibirTodos.Click
        Try
            If MsgBox("¿Está seguro de RECIBIR todos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim row As Janus.Windows.GridEX.GridEXRow
                For i = 0 To Me.dgvDatos.RowCount - 1
                    Me.dgvDatos.Row = i
                    row = Me.dgvDatos.GetRow()

                    oMoviAlmacenDetService.ChequearCantidad(row.Cells("IdMovimientoDet").Value, row.Cells("CanMer").Value, "")

                Next

                actualizar()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL RECIBIR TODOS : " + ex.Message)
        End Try
    End Sub

    Private Sub miRecibir_Click(sender As Object, e As EventArgs) Handles miRecibir.Click
        Try
            Dim frm As New frmMovimAlmacen_ActualizarCantRec
            frm.IdMovimientoDet = dgvDatos.CurrentRow.Cells("IdMovimientoDet").Text
            frm.CanRec = dgvDatos.CurrentRow.Cells("CanRec").Text
            frm.ObservacionDet = dgvDatos.CurrentRow.Cells("Observacion").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                actualizar()
            End If

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL ORDEN DE COMPRA : " + ex.Message)
        End Try
    End Sub

    Private Sub btnBuscarMotor_Click(sender As Object, e As EventArgs) Handles btnBuscarMotor.Click
        Dim frm As New frmBuscarLocacionMercaderia
        'frm.IdLocacion = 4          'Se comenta el 19/06/2013 (Sr. VictorHugo/Cesar)
        frm.CodRub = "04"
        'frm.cmbCodRub.ReadOnly = True
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtMotorDestino.Text = frm.codigo
            txtDesMotorDestino.Text = frm.descripcion
        End If
        txtMotorDestino.Select()
    End Sub

    Private Sub btnTransferirCostoMotor_Click(sender As Object, e As EventArgs) Handles btnTransferirCostoMotor.Click
        Try

            If MsgBox("¿Está seguro de TRANSFERIR EL COSTO MOTOR el registro con CÓDIGO = " + txtNumDoc.Text + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oMoviAlmacenService.TransferirCostoMotor(toNumber(IdMovimiento), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                'type_process = "insert"
                If estado_process = True Then
                    MsgBox(" Se Transfirió el costo motor correctamente.", MsgBoxStyle.Information)
                    'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    ObtenerRegistro()
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub biGenerar_Click(sender As Object, e As EventArgs) Handles biGenerar.Click

        Try
            Dim frm As New frmMovimAlmacen_GenerarSolGasto
            frm.IdMovimiento = IdMovimiento

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                'dtDatos = Nothing
                'listaDatos()
                'RowPossesion(dgvDatos, frm.IdMovimiento)
                'actualizar()
                type_process = "update"
                Me.DialogResult = System.Windows.Forms.DialogResult.OK

            End If

        Catch ex As Exception
            MsgBox(ex.Message + "Error al Generar la Solicitud de Gastos. ", MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnAgregarProveedor_Click(sender As Object, e As EventArgs) Handles btnAgregarProveedor.Click
        Try
            Dim frm As New frmAgregarClienteSunat

            frm.IdCliente = 0
                frm.tipoBusqueda = 1
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdCliente = frm.IdCliente
                txtCliente.Text = frm.txtDesCli.Text
            End If



        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class
