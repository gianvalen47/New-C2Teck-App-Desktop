Imports System.Data.OleDb
Imports System.ServiceModel
Imports System.Windows.Forms

Public Class frmCotizacion

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMaestroService As New MaestroService.MaestroClient
    Private oCotizacionService As New CotizacionService.CotizacionServiceClient
    Private oCotizacionDetalleService As New CotizacionDetalleService.CotizacionDetalleServiceClient
    Private oContactoService As New ContactoService.ContactoServiceClient
    Private oCondicionPagoClienteService As New CondicionPagoClienteService.CondicionPagoClienteServiceClient
    Private oClienteFacDscService As New ClienteFacDscService.ClienteFacDscServiceClient
    Private oClienteService As New ClienteService.ClienteServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private oMercaderiaService As New ProductoService.ProductoServiceClient  'MercaderiaService.MercaderiaServiceClient
    Private oPrecioService As New PrecioService.PrecioServiceClient
    Private oOrdenCompraDetService As New OrdenCompraDetService.OrdenCompraDetServiceClient
    Private oListaPrecioFabricante As New ListaPrecioFabricanteDetService.ListaPrecioFabricanteDetServiceClient

    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdCotizacion As Int64
    Public IdLocacion As Integer
    Public GruAlm As String
    Private IdCliente As Integer
    Private dtAlmacenes As DataTable
    Private dtContactos As DataTable
    Private dtMonedas As DataTable
    Private dtCondicionesPago As DataTable
    Public IdSugerido As Integer
    Private IdSugeridoCab As Integer
    Private CodMon As String
    Private Permiso As Boolean
    Private MonNac As Boolean


    Private DirFile As String
    Private fileExt As String
    Private dtDatosExcel As DataTable
    Private CondPagoTemp As String

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub cmbIdContacto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbIdContacto.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnAgregarContacto.Enabled = True Then
                btnAgregarContacto_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtObsCab_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F12 Then
            If btnModificarCabecera.Enabled = True Then
                btnModificarCabecera_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtObsDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F12 Then
            If btnModificarDetalle.Enabled = True Then
                btnModificarDetalle_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtObsDet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObsDet.KeyPress
        'If e.KeyChar = ChrW(Keys.Enter) Then
        '    If btnGuardar.Enabled = True Then
        '        btnGuardar.Select()
        '        btnGuardar_Click(sender, e)
        '        'Else
        '        '    dgvDatos.Select()
        '    End If
        'End If

        If e.KeyChar = ChrW(Keys.Tab) Then
            cbExportacion.Select()
            'If btnGuardar.Enabled = True Then
            '    btnGuardar.Select()
            '    btnGuardar_Click(sender, e)
            '    'Else
            '    '    dgvDatos.Select()
            'End If
        End If

    End Sub
    Private Sub txtFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnBuscarCliente.Select()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                e.Handled = True
                dgvDatos_DoubleClick(sender, e)
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            txtNumCot.Select()

        End If
    End Sub

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtTotalPrecio.KeyPress _
                          , txtTotalDescuento.KeyPress _
                          , txtTotal.KeyPress _
                          , cmbCodPag.KeyPress _
                          , txtIgv.KeyPress _
                          , cmbCodMon.KeyPress _
                          , txtTipoCambio.KeyPress _
                          , txtCliente.KeyPress _
                          , txtNumCot.KeyPress _
                          , cmbIdContacto.KeyPress _
                          , txtValidez.KeyPress _
                          , txtEntrega.KeyPress _
                          , txtGarantia.KeyPress _
                          , txtPlazo.KeyPress _
                          , txtReferencia.KeyPress _
                          , txtProyecto.KeyPress _
                          , txtFacCli.KeyPress _
                          , txtDscCli.KeyPress _
                          , txtDiasValidez.KeyPress
        ', txtObsDet.KeyPress _
        ', txtFecha.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmCotizacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()

        If state_button Then    'Modificar

            ObtenerRegistro()
            gbEstado.Visible = True
            desactivar()

            'If (lblEstado.Text = "GENERADO" Or lblEstado.Text = "GN") Then
            '    btnGuardar.Enabled = True
            '    btnEditar.Enabled = True
            'Else
            '    btnGuardar.Enabled = False
            '    btnEditar.Enabled = False
            'End If

            listaDatos()
            Me.Text = "Cotización Nº " + Chr(34) + txtNumCot.Text.ToString + Chr(34)
        Else                    'Nuevo

            CodMon = oMaestroService.ObtenerMonedaNacional(IdLocacion)
            Permiso = oSeguridadService.BuscarPermisoTipCam(Session.sCodUsu)
            MonNac = oMaestroService.BuscarMonedaNacional(IdLocacion)

            gbEstado.Visible = False
            txtNumCot.ReadOnly = False
            txtNumCot.BackColor = System.Drawing.SystemColors.Control
            biSugerir.Enabled = False
            biActMoneda.Enabled = False
            cmbCodMon.Value = CodMon

            txtFecha.Value = Session.sFecha

            If Permiso Then
                cmbCodMon.ReadOnly = False
                cmbCodMon.BackColor = System.Drawing.SystemColors.Window
            Else
                If MonNac = True Then
                    cmbCodMon.ReadOnly = True
                    cmbCodMon.BackColor = System.Drawing.SystemColors.Control
                Else
                    cmbCodMon.ReadOnly = False
                    cmbCodMon.BackColor = System.Drawing.SystemColors.Window
                End If
            End If

            txtObsCab.Text = "Estimados señores : " + vbCrLf + vbCrLf + "En atención a su solicitud, presentamos nuestra cotización por el suministro de los siguientes productos :"

            If Session.sCodEmp = "05" Then
                txtObsDet.Text = "BCP DOLARES 191-2592275-1-04" + vbCrLf + "EQUIPOS Y MAQUINARIA PESADA DIESEL SAC RUC 20554369759"
                'txtObsDet.Text = "En cuanto a los tiempos de entrega se detalla lo siguiente : " + vbCrLf + vbCrLf + "1. Tiempos de entrega dispuestos a cambio debido a la pandemia COVID-19." + vbCrLf + vbCrLf + "BCP DOLARES 191-2592275-1-04" + vbCrLf + "EQUIPOS Y MAQUINARIA PESADA DIESEL SAC RUC 20554369759"
            ElseIf Session.sCodEmp = "08" Then
                txtObsDet.Text = "Banco BCP Soles:      191-9891085-0-47		CCI : 00219100989108504752" + vbCrLf + "Banco BCP Dólares:   191-9876934-1-17       CCI : 00219100987693411757"
            Else
                '--------------------- Se agregó el 30/01/2015 Solicitud de usuario 4424 --------------------------
                txtObsDet.Text = "POR POLITICA DE EMPRESA SOLO SE OTORGA CREDITO Y ENTREGA A ALMACENES EN LIMA A ORDENES DE COMPRA IGUALES O SUPERIORES US$ 200.00 DOLARES"
            End If

            '--------------------------------------------------------------------------------------------------------------------------
            Me.Size = New System.Drawing.Size(856, 311)
            Me.Text = "Registrar Nueva Cotización"
        End If

    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oCotizacionService) = False Then
                oCotizacionService.Close()
            End If
            If isClosed(oCotizacionDetalleService) = False Then
                oCotizacionDetalleService.Close()
            End If
            If isClosed(oContactoService) = False Then
                oContactoService.Close()
            End If
            If isClosed(oCondicionPagoClienteService) = False Then
                oCondicionPagoClienteService.Close()
            End If
            If isClosed(oClienteFacDscService) = False Then
                oClienteFacDscService.Close()
            End If
            If isClosed(oClienteService) = False Then
                oClienteService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
            If isClosed(oMercaderiaService) = False Then
                oMercaderiaService.Close()
            End If
            If isClosed(oListaPrecioFabricante) = False Then
                oListaPrecioFabricante.Close()
            End If


        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                           txtNumCot.KeyUp
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
                        , cmbCodPag.ValueChanged _
                        , cmbIdContacto.ValueChanged
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
    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumCot.KeyPress
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub
    'Private Function getRowTodos(ByVal data As DataTable)
    '    Dim fila As DataRow = data.NewRow
    '    Try
    '        fila(0) = ""
    '    Catch ex As Exception
    '        fila(0) = 0
    '    End Try
    '    Try
    '        fila(1) = "(Ninguno)"
    '    Catch ex As Exception
    '        fila(2) = "(Ninguno)"
    '    End Try
    '    Try
    '        fila(2) = "(Ninguno)"
    '    Catch ex As Exception
    '    End Try
    '    Return fila
    'End Function
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdCotizacionDet").Value) = codigo Then

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

            miModificar.Enabled = False
            miEliminar.Enabled = False
            miEliminarDetalles.Enabled = False
            btnGuardar.Enabled = False
            btnDeshacer.Enabled = False
            btnGenerarDocumento.Enabled = False
            btnRecalcularDscto.Enabled = False
            biSugerir.Enabled = False
            biActMoneda.Enabled = IIf(toBlank(lblEstado.Text = "GENERADO" And Session.CodPerfil = "11" Or Session.CodPerfil = "12" Or Session.CodPerfil = "05"), True, False)  '------ Se agrega el Perfil de Costos 02/08/2016

            miSugerir.Enabled = False
            miAgregarPlantilla.Enabled = IIf(toBlank(lblEstado.Text = "GENERADO"), True, False)
            miAgregarConsumoJob.Enabled = IIf(toBlank(lblEstado.Text = "GENERADO"), True, False)

            miImportarExcel.Enabled = IIf(toBlank(lblEstado.Text = "GENERADO"), True, False)

        Else
            If state_button = True And (toBlank(lblEstado.Text) = "GENERADO" Or toBlank(lblEstado.Text) = "GN") Or (toBlank(lblEstado.Text) = "APROBADO" Or toBlank(lblEstado.Text) = "AP") Then
                '------------------------------------------------------Agregado el 25/05/2012 ---------------------------------------------------------------
                'If state_button = True And (toBlank(lblEstado.Text) = "GENERADO" Or toBlank(lblEstado.Text) = "GN") Then
                '--------------------------------------------------------------------------------------------------------------------------------------------------------

                btnGuardar.Enabled = False
                btnEditar.Enabled = True
                btnDeshacer.Enabled = False
                btnGenerarDocumento.Enabled = IIf(IdSugerido > 0, False, True)
                biActMoneda.Enabled = False

                miEliminar.Enabled = True
                miEliminarDetalles.Enabled = True
                miModificar.Enabled = True
                btnRecalcularDscto.Enabled = True
                biSugerir.Enabled = IIf((lblEstado.Text = "GENERADO" Or lblEstado.Text = "APROBADO"), True, False)
                miSugerir.Enabled = IIf((lblEstado.Text = "GENERADO" Or lblEstado.Text = "APROBADO"), True, False)

            ElseIf lblEstado.Text <> "GENERADO" Then

                miNuevo.Enabled = False
                miEliminar.Enabled = False
                miEliminarDetalles.Enabled = False
                miActualizar.Enabled = False
                miModificar.Enabled = False
                miSugerir.Enabled = False

                btnGuardar.Enabled = False
                btnEditar.Enabled = IIf(lblEstado.Text = "CREDITOS", True, False)
                btnDeshacer.Enabled = False
                biSugerir.Enabled = False
                biActMoneda.Enabled = False
                If lblEstado.Text = "ATENDIDO" Or lblEstado.Text = "RECHAZADO" Or lblEstado.Text = "CREDITOS" Then
                    btnGenerarDocumento.Enabled = False
                Else
                    btnGenerarDocumento.Enabled = IIf(IdSugerido > 0, False, True)
                End If

                btnRecalcularDscto.Enabled = False
            Else
                miNuevo.Enabled = False
                miEliminar.Enabled = False
                miEliminarDetalles.Enabled = False
                btnGuardar.Enabled = False
                btnGenerarDocumento.Enabled = True
                biActMoneda.Enabled = False
            End If
            miAgregarPlantilla.Enabled = False
            miAgregarConsumoJob.Enabled = False

            miImportarExcel.Enabled = False
        End If
    End Sub

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If state_button = True And toNumber(IdCotizacion) = 0 Then
                MsgBox("Debe Ingresar el código de la cotización.", MsgBoxStyle.Information, "Información")
                txtNumCot.Focus()
                Return False

            ElseIf toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe Ingresar el la fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.BackColor = Color.Red
                txtFecha.Focus()
                Return False
            ElseIf txtNumCot.Text = "" Then
                MsgBox("Debe ingresar el numero de la cotización", MsgBoxStyle.Information, "Información")
                txtNumCot.BackColor = Color.Red
                txtNumCot.Focus()
                Return False
            ElseIf toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar el cliente ", MsgBoxStyle.Information, "Información")
                txtCliente.BackColor = Color.Red
                txtCliente.Focus()
                Return False
                'ElseIf toNumber(cmbIdContacto.Value) = 0 Then
                '  MsgBox("Debe de ingresar el contacto del cliente.", MsgBoxStyle.Information, "Información")
                '  cmbIdContacto.BackColor = Color.Red
                '  cmbIdContacto.Focus()
                '  Return False
            ElseIf toBlank(txtDscCli.Text) = "" Then
                MsgBox("Descuento no valido.", MsgBoxStyle.Information, "Información")
                txtDscCli.BackColor = Color.Red
                txtDscCli.Focus()
                Return False
            ElseIf toBlank(cmbCodMon.Value) = "" Then
                MsgBox("Debe de ingresar el tipo de moneda.", MsgBoxStyle.Information, "Información")
                cmbCodMon.BackColor = Color.Red
                cmbCodMon.Focus()
                Return False
                'ElseIf toDouble(txtIgv.Text) <= 0 And cbExportacion.Checked = False Then
                '    MsgBox("El IGV es debe ser mayor que el CERO.", MsgBoxStyle.Information, "Información")
                '    txtIgv.Focus()
                '    Return False
            ElseIf toBlank(txtFacCli.Text) = "" Then
                MsgBox("Debe de ingresar el factor del cliente.", MsgBoxStyle.Information, "Información")
                txtFacCli.Focus()
                Return False
            ElseIf toDouble(txtTipoCambio.Text) <= 0 Then
                MsgBox("Tipo de cambio no puede ser CERO..", MsgBoxStyle.Information, "Información")
                txtTipoCambio.BackColor = Color.Red
                txtTipoCambio.Focus()
                Return False
            ElseIf state_button = False And oCotizacionService.Buscar(IdLocacion, toNumber(txtNumCot.Text)) Then
                MsgBox("El Número " + txtNumCot.Text + " de la cotización ya existe...!", MsgBoxStyle.Information, "Información")
                txtNumCot.Focus()
                Return False
            ElseIf state_button = True And toBlank(lblEstado.Text) <> "GENERADO" And toBlank(lblEstado.Text) <> "GN" And toBlank(lblEstado.Text) <> "APROBADO" And toBlank(lblEstado.Text) <> "CREDITOS" Then
                MsgBox("La Cotización ya no se puede modificar...!" + vbCr + "Debido que ya no se encuentra en el estado generado...!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As CotizacionService.Cotizacion)
        Try
            Dim estado_process As Integer
            estado_process = oCotizacionService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdCotizacion = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As CotizacionService.Cotizacion)
        Try
            Dim estado_process As Boolean
            estado_process = oCotizacionService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                desactivar()
                ObtenerRegistro()
                actualizar()
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
            estado_process = oCotizacionService.Borrar(IdCotizacion, Session.sCodUsu)
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
            Dim registro As CotizacionService.Cotizacion
            registro = oCotizacionService.MostrarPorId(toNumber(IdCotizacion))

            IdCotizacion = registro.IdCotizacion
            IdLocacion = registro.Locacion.IdLocacion

            txtNumCot.Text = registro.NumCot

            txtProyecto.Text = registro.Proyecto
            IdCliente = registro.Cliente.IdCliente
            listarContactos()
            txtCliente.Text = registro.Cliente.DesCli
            cmbIdContacto.Value = registro.Contacto.IdContacto
            txtFecha.Text = registro.Fecha
            txtReferencia.Text = registro.Referencia
            cmbCodMon.Value = registro.Moneda.CodMon
            txtIgv.Value = registro.Igv
            txtFacCli.Text = registro.FacCli
            txtDscCli.Text = registro.DscCli
            txtTotalPrecio.Text = registro.TotBruto
            txtTotalDescuento.Text = registro.TotDscto
            txtTotal.Text = registro.TotVenta
            txtObsCab.Text = registro.ObsCab
            txtObsDet.Text = registro.ObsDet
            If txtObsCab.Text <> "" Then
                If txtObsCab.Text.Substring(1, 1) = "\" Then
                    txtObsCab.Rtf = txtObsCab.Text
                End If
            End If
            If txtObsDet.Text <> "" Then
                If txtObsDet.Text.Substring(1, 1) = "\" Then
                    txtObsDet.Rtf = txtObsDet.Text
                End If
            End If
            'txtObsCab.Rtf = txtObsCab.Text
            'txtObsDet.Rtf = txtObsDet.Text
            cmbCodPag.Value = registro.CondicionPago.CodPag
            CondPagoTemp = registro.CondicionPago.CodPag
            txtPlazo.Text = registro.Plazo
            txtGarantia.Text = registro.Garantia
            txtEntrega.Text = registro.Entrega
            txtValidez.Text = registro.Validez
            lblEstado.Text = registro.Estado
            txtVendedor.Text = registro.Persona.ApeNom
            txtDiasValidez.Value = registro.DiasValidez
            cbExportacion.Checked = registro.Exportacion

            Me.Text = "Cotización Nº " + registro.NumCot.ToString
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= CONDICONES DE PAGO ================================================
            dtCondicionesPago = oMaestroService.MostrarCondicionPago.Tables(0)
            'dtCondicionesPago.Rows.InsertAt(getRowTodos(dtCondicionesPago), 0)
            cmbCodPag.DataSource = dtCondicionesPago
            cmbCodPag.DropDownList.DataMember = dtCondicionesPago.Columns("DesPag").ToString
            cmbCodPag.DropDownList.DisplayMember = dtCondicionesPago.Columns("DesPag").ToString
            cmbCodPag.DropDownList.ValueMember = dtCondicionesPago.Columns("CodPag").ToString
            cmbCodPag.DropDownList.Columns(0).DataMember = dtCondicionesPago.Columns("CodPag").ToString
            cmbCodPag.DropDownList.Columns(1).DataMember = dtCondicionesPago.Columns("DesPag").ToString
            dtCondicionesPago = Nothing
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
    Private Sub listarContactos()
        '======================================= CONTACTOS ================================================
        dtContactos = oContactoService.Mostrar(IdCliente).Tables(0)
        cmbIdContacto.DataSource = dtContactos
        cmbIdContacto.DropDownList.DataMember = dtContactos.Columns("Apellidos").ToString
        cmbIdContacto.DropDownList.DisplayMember = dtContactos.Columns("Apellidos").ToString
        cmbIdContacto.DropDownList.ValueMember = dtContactos.Columns("IdContacto").ToString
        cmbIdContacto.DropDownList.Columns(0).DataMember = dtContactos.Columns("IdContacto").ToString
        cmbIdContacto.DropDownList.Columns(1).DataMember = dtContactos.Columns("Apellidos").ToString
        cmbIdContacto.DropDownList.Columns(2).DataMember = dtContactos.Columns("Nombres").ToString
        dtContactos = Nothing
    End Sub
    Private Sub listarCondiciones()
        '======================================= CONDICION DE PAGO DEL CLIENTE ================================================
        dtCondicionesPago = oCondicionPagoClienteService.Mostrar(IdCliente).Tables(0)
        If dtCondicionesPago.Rows.Count > 0 Then
            cmbCodPag.DataSource = dtCondicionesPago
            cmbCodPag.DropDownList.DataMember = dtCondicionesPago.Columns("DesPag").ToString
            cmbCodPag.DropDownList.DisplayMember = dtCondicionesPago.Columns("DesPag").ToString
            cmbCodPag.DropDownList.ValueMember = dtCondicionesPago.Columns("CodPag").ToString
            cmbCodPag.DropDownList.Columns(0).DataMember = dtCondicionesPago.Columns("CodPag").ToString
            cmbCodPag.DropDownList.Columns(1).DataMember = dtCondicionesPago.Columns("DesPag").ToString
            cmbCodPag.DropDownList.Columns(2).DataMember = dtCondicionesPago.Columns("DesRub").ToString
            cmbCodPag.SelectedIndex = 0
            cmbCodPag.ReadOnly = False
            cmbCodPag.BackColor = System.Drawing.SystemColors.Window
        Else
            dtCondicionesPago = oMaestroService.MostrarCondicionPago.Tables(0)
            'dtCondicionesPago.Rows.InsertAt(getRowTodos(dtCondicionesPago), 0)
            cmbCodPag.DataSource = dtCondicionesPago
            cmbCodPag.DropDownList.DataMember = dtCondicionesPago.Columns("DesPag").ToString
            cmbCodPag.DropDownList.DisplayMember = dtCondicionesPago.Columns("DesPag").ToString
            cmbCodPag.DropDownList.ValueMember = dtCondicionesPago.Columns("CodPag").ToString
            cmbCodPag.DropDownList.Columns(0).DataMember = dtCondicionesPago.Columns("CodPag").ToString
            cmbCodPag.DropDownList.Columns(1).DataMember = dtCondicionesPago.Columns("DesPag").ToString
            cmbCodPag.SelectedIndex = 0
            If Session.CodPerfil = "01" And toBlank(lblEstado.Text) = "GENERADO" Then
                cmbCodPag.Value = CondPagoTemp
            End If
            'dtCondicionesPago = Nothing
            'Agregado a pedido de crios se activa para perfil Administrador
            If Session.CodPerfil = "01" Then
                cmbCodPag.ReadOnly = False
                cmbCodPag.BackColor = System.Drawing.SystemColors.Window
            Else
                cmbCodPag.ReadOnly = True
                cmbCodPag.BackColor = System.Drawing.SystemColors.Control
            End If

        End If
        dtCondicionesPago = Nothing
    End Sub
    Private Sub listaDatos()
        Try
            dtDatos = oCotizacionDetalleService.Mostrar(toNumber(IdCotizacion)).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)
            If dgvDatos.RowCount > 0 Then
                IdSugeridoCab = IIf(dgvDatos.CurrentRow.Cells("IdSugeridoCab").Text = "", 0, dgvDatos.CurrentRow.Cells("IdSugeridoCab").Text)

                'txtTotalPrecio.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.Cotizacion", "TotBruto", "IdCotizacion", IdCotizacion)
                'txtTotalDescuento.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.Cotizacion", "TotDscto", "IdCotizacion", IdCotizacion)
                'txtTotal.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.Cotizacion", "TotVenta", "IdCotizacion", IdCotizacion)
                'txtTotalIGV.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.Cotizacion", "TotIgv", "IdCotizacion", IdCotizacion)
                'txtTotalNeto.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.Cotizacion", "TotNeto", "IdCotizacion", IdCotizacion)
                'lblTotal.Text = "SUB TOTALES"
                'lbltotalIGV.Text = "IGV"
                'lblTotalNeto.Text = "TOTAL (" + oMaestroService.MostrarDato("SIGECOM.Maestro.Monedas", "AbrMon", "CodMon", cmbCodMon.Value) + ")"

                Dim registro1 As New CotizacionService.Cotizacion
                Dim registro2 As New CotizacionService.SugeridoCotizacion

                registro1 = oCotizacionService.MostrarPorId(IdCotizacion)
                If IdSugeridoCab > 0 Then
                    registro2 = oCotizacionService.MostrarPorIdSugerido(IdSugeridoCab)
                End If

                txtTotalPrecio.Value = registro1.TotBruto
                txtTotalDescuento.Value = registro1.TotDscto
                txtTotal.Value = registro1.TotVenta
                txtTotalIGV.Value = registro1.TotIgv
                txtTotalNeto.Value = registro1.TotNeto

                lblTotal.Text = "SUB TOTALES ==>  "
                lbltotalIGV.Text = "IGV ==>  "
                lblTotalNeto.Text = "TOTAL NETO ==> (" + oMaestroService.MostrarDato("SIGECOM.Maestro.Monedas", "AbrMon", "CodMon", cmbCodMon.Value) + ")"

                txtTotalSug.Text = IIf(IdSugeridoCab <> 0, registro2.TotVentaSug, 0)
                txtTotalIgvSug.Text = IIf(IdSugeridoCab <> 0, registro2.TotIgvSug, 0)
                txtTotalNetoSug.Text = IIf(IdSugeridoCab <> 0, registro2.TotNetoSug, 0)

                If txtTotalNetoSug.Text > 0 Then
                    dgvDatos.RootTable.Columns(3).Width = 228
                    dgvDatos.RootTable.Columns(8).Visible = True
                    lblTotal.Size = New System.Drawing.Size(433, 20)
                    lbltotalIGV.Size = New System.Drawing.Size(602, 20)
                    lblTotalNeto.Size = New System.Drawing.Size(602, 20)
                    txtTotalPrecio.Location = New System.Drawing.Point(457, 9)
                    txtTotalDescuento.Location = New System.Drawing.Point(547, 9)
                    txtTotal.Location = New System.Drawing.Point(626, 9)
                    txtTotalIGV.Location = New System.Drawing.Point(626, 28)
                    txtTotalNeto.Location = New System.Drawing.Point(626, 47)
                    txtTotalSug.Visible = True
                    txtTotalIgvSug.Visible = True
                    txtTotalNetoSug.Visible = True
                Else
                    dgvDatos.RootTable.Columns(3).Width = 318
                    dgvDatos.RootTable.Columns(8).Visible = False
                    lblTotal.Size = New System.Drawing.Size(522, 20)
                    lbltotalIGV.Size = New System.Drawing.Size(691, 20)
                    lblTotalNeto.Size = New System.Drawing.Size(691, 20)
                    txtTotalPrecio.Location = New System.Drawing.Point(546, 9)
                    txtTotalDescuento.Location = New System.Drawing.Point(636, 9)
                    txtTotal.Location = New System.Drawing.Point(715, 9)
                    txtTotalIGV.Location = New System.Drawing.Point(715, 28)
                    txtTotalNeto.Location = New System.Drawing.Point(715, 47)
                    txtTotalSug.Visible = False
                    txtTotalIgvSug.Visible = False
                    txtTotalNetoSug.Visible = False
                End If

            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [INFO-007]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmCotizacion_AgregarDetalle
                frm.state_button = False
                frm.IdCotizacion = IdCotizacion
                frm.IdLocacion = IdLocacion
                frm.IdCliente = IdCliente
                frm.CodMon = cmbCodMon.Value
                frm.estado = "GN"
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    IdSugerido = frm.IdSugerido
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdCotizacionDet)
                    End If
                Else
                    lLog = False
                End If
            End While
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [INFO-008]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("CodMer").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then

                If dgvDatos.CurrentRow.Cells("IdSugerido").Text = "" Then
                    Dim estado_process As Boolean

                    estado_process = oCotizacionDetalleService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdCotizacionDet").Text), IdCotizacion, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process = True Then
                        dtDatos = Nothing
                        listaDatos()
                        MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                        enableOpciones()
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                Else
                    MsgBox("Primero debe eliminar el Precio y/o Descuento sugerido")
                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-009]:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmCotizacion_AgregarDetalle
            frm.state_button = True
            frm.IdCotizacionDet = dgvDatos.CurrentRow.Cells("IdCotizacionDet").Text
            frm.IdCotizacion = IdCotizacion
            frm.IdLocacion = IdLocacion
            frm.IdCliente = IdCliente
            frm.CodMon = cmbCodMon.Value
            frm.estado = toBlank(lblEstado.Text)
            frm.IdSugerido = IIf(dgvDatos.CurrentRow.Cells("IdSugerido").Text = "", 0, dgvDatos.CurrentRow.Cells("IdSugerido").Text)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdSugerido = frm.IdSugerido
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdCotizacionDet)
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
                    codigo = dgvDatos.CurrentRow.Cells("IdCotizacionDet").Text
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
        btnGenerarDocumento.Enabled = False
        btnRecalcularDscto.Enabled = False
        btnGenerarDocumento.Enabled = False
        btnEditar.Enabled = False

        If lblEstado.Text = "GENERADO" Then
            txtDiasValidez.ReadOnly = False
            txtDiasValidez.BackColor = System.Drawing.SystemColors.Window
            '------------Agregado el 25/05/2012 ---------
            If dgvDatos.RowCount < 1 Then
                btnBuscarCliente.Enabled = True
            Else
                btnBuscarCliente.Enabled = False
            End If
            '--------------------------------------------------------
        Else
            btnBuscarCliente.Enabled = False   '------------Agregado el 25/05/2012 ---------
            btnAgregarCliente.Enabled = False
            txtDiasValidez.ReadOnly = True
            txtDiasValidez.BackColor = System.Drawing.SystemColors.Control
        End If

        btnAgregarContacto.Enabled = True
        cmbIdContacto.ReadOnly = False
        txtReferencia.ReadOnly = False
        txtReferencia.BackColor = System.Drawing.SystemColors.Window
        txtObsCab.ReadOnly = False
        txtObsCab.BackColor = System.Drawing.SystemColors.Window
        txtObsDet.ReadOnly = False
        txtObsDet.BackColor = System.Drawing.SystemColors.Window
        txtGarantia.ReadOnly = False
        txtGarantia.BackColor = System.Drawing.SystemColors.Window
        txtEntrega.ReadOnly = False
        txtEntrega.BackColor = System.Drawing.SystemColors.Window
        txtValidez.ReadOnly = False
        txtValidez.BackColor = System.Drawing.SystemColors.Window
        txtPlazo.ReadOnly = False
        txtPlazo.BackColor = System.Drawing.SystemColors.Window
        txtProyecto.ReadOnly = False
        txtProyecto.BackColor = System.Drawing.SystemColors.Window
        cbExportacion.Enabled = True
        If oCotizacionService.BuscarAprobacion(IdCotizacion) = True Then
            cmbCodPag.ReadOnly = True
            cmbCodPag.BackColor = System.Drawing.SystemColors.Control
        Else
            'cmbCodPag.ReadOnly = False
            'cmbCodPag.BackColor = System.Drawing.SystemColors.Window
            listarCondiciones()
        End If

        btnModificarCabecera.Enabled = True
        btnModificarDetalle.Enabled = True
        biSugerir.Enabled = False
        cmOpciones.Enabled = False
    End Sub
    Private Sub desactivar()

        btnGuardar.Enabled = False
        btnDeshacer.Enabled = False
        btnEditar.Enabled = True
        If dgvDatos.RowCount > 0 Then
            btnGenerarDocumento.Enabled = True
            btnRecalcularDscto.Enabled = True
            biSugerir.Enabled = True
        Else
            btnGenerarDocumento.Enabled = False
            btnRecalcularDscto.Enabled = False
            biSugerir.Enabled = False
        End If
        btnBuscarCliente.Enabled = False
        btnAgregarCliente.Enabled = False
        btnAgregarContacto.Enabled = False
        txtNumCot.ReadOnly = True
        txtNumCot.BackColor = System.Drawing.SystemColors.Control
        cmbIdContacto.ReadOnly = True
        cmbIdContacto.BackColor = System.Drawing.SystemColors.Control
        txtReferencia.ReadOnly = True
        txtReferencia.BackColor = System.Drawing.SystemColors.Control
        txtObsCab.ReadOnly = True
        txtObsCab.BackColor = System.Drawing.SystemColors.Control
        txtObsDet.ReadOnly = True
        txtObsDet.BackColor = System.Drawing.SystemColors.Control
        txtGarantia.ReadOnly = True
        txtGarantia.BackColor = System.Drawing.SystemColors.Control
        txtEntrega.ReadOnly = True
        txtEntrega.BackColor = System.Drawing.SystemColors.Control
        txtValidez.ReadOnly = True
        txtValidez.BackColor = System.Drawing.SystemColors.Control
        txtDiasValidez.ReadOnly = True
        txtDiasValidez.BackColor = System.Drawing.SystemColors.Control
        txtPlazo.ReadOnly = True
        txtPlazo.BackColor = System.Drawing.SystemColors.Control
        txtProyecto.ReadOnly = True
        txtProyecto.BackColor = System.Drawing.SystemColors.Control
        cmbCodPag.ReadOnly = True
        cmbCodPag.BackColor = System.Drawing.SystemColors.Control

        cbExportacion.Enabled = False
        btnModificarCabecera.Enabled = False
        btnModificarDetalle.Enabled = False

        cmbCodMon.ReadOnly = True
        cmbCodMon.BackColor = System.Drawing.SystemColors.Control
        cmbCodPag.ReadOnly = True
        cmbCodPag.BackColor = System.Drawing.SystemColors.Control
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        cmOpciones.Enabled = True

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

            '///////BUSCAR FACTORES DE DESCUENTO DEL CLIENTE////////////
            If oClienteFacDscService.Buscar(Session.sCodEmp, GruAlm, IdCliente) Then
                Dim factorCliente As New ClienteFacDscService.ClienteFacDsc
                factorCliente = oClienteFacDscService.MostrarPorId(Session.sCodEmp, GruAlm, IdCliente)
                txtFacCli.Text = factorCliente.FacCli
                txtDscCli.Text = factorCliente.DscCli
            Else
                txtFacCli.Text = 0
                txtDscCli.Text = 0
            End If
            '///////////////////////////////////////////////////////////

            listarContactos()
            listarCondiciones()
            If oClienteService.BuscarMonedaCliente(IdLocacion, IdCliente) = True Then
                cmbCodMon.ReadOnly = False
                cmbCodMon.BackColor = System.Drawing.SystemColors.Window
            Else
                If Permiso = False And MonNac = True Then
                    cmbCodMon.ReadOnly = True
                    cmbCodMon.BackColor = System.Drawing.SystemColors.Control
                    cmbCodMon.Value = CodMon
                End If
            End If
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
        If state_button = True And (toBlank(lblEstado.Text) = "GENERADO" Or toBlank(lblEstado.Text) = "GN" Or toBlank(lblEstado.Text) = "APROBADO" Or toBlank(lblEstado.Text) = "AP") Then
            NuevoDetalle()
        End If
    End Sub
    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub
    Private Sub cmbCodMon_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodMon.ValueChanged
        txtTipoCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio("US", txtFecha.Text)), "#0.000")
    End Sub
    Private Sub btnModificarCabecera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarCabecera.Click
        'Dim frm As New frmEditarCabecera
        'frm.state_button = state_button
        'frm.IdCotizacion = IdCotizacion
        'frm.estado = lblEstado.Text
        'frm.txtObsCab.Text = toBlank(txtObsCab.Text)
        'If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
        '    txtObsCab.Text = toBlank(frm.txtObsCab.Text)
        'End If
        'txtObsCab.Select()


        Dim frm As New frmEditarCabeceraFormato
        frm.state_button = state_button
        frm.IdCotizacion = IdCotizacion
        frm.estado = lblEstado.Text
        frm.txtObsCab.Rtf = toBlank(txtObsCab.Rtf)
        'Dim d As String = txtObsCab.Text
        'frm.txtObsCab.Text = d.ToRtf()
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtObsCab.Rtf = toBlank(frm.txtObsCab.Rtf)
        End If
        txtObsCab.Select()

    End Sub
    Private Sub btnModificarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarDetalle.Click
        'Dim frm As New frmEditarDetalle
        'frm.state_button = state_button
        'frm.IdCotizacion = IdCotizacion
        'frm.estado = lblEstado.Text
        'frm.txtObsDet.Text = toBlank(txtObsDet.Text)
        'If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
        '    txtObsDet.Text = toBlank(frm.txtObsDet.Text)
        'End If
        'txtObsDet.Select()

        Dim frm As New frmEditarDetalleFormato
        frm.state_button = state_button
        frm.IdCotizacion = IdCotizacion
        frm.estado = lblEstado.Text
        frm.txtObsDet.Rtf = toBlank(txtObsDet.Rtf)
        'Dim d As String = txtObsCab.Text
        'frm.txtObsCab.Text = d.ToRtf()
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtObsDet.Rtf = toBlank(frm.txtObsDet.Rtf)
        End If
        txtObsDet.Select()
    End Sub

    Private Sub txtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecha.ValueChanged
        txtTipoCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio("US", txtFecha.Text)), "#0.000")
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
           And ValidaCampos() Then

            Dim registro As New CotizacionService.Cotizacion
            Dim locacion As New CotizacionService.Locacion
            Dim cliente As New CotizacionService.Cliente
            Dim contacto As New CotizacionService.Contacto
            Dim condicionPago As New CotizacionService.CondicionPago
            Dim moneda As New CotizacionService.Moneda

            registro.IdCotizacion = IdCotizacion
            locacion.IdLocacion = IdLocacion
            registro.Locacion = locacion
            registro.NumCot = txtNumCot.Text
            registro.Proyecto = txtProyecto.Text
            cliente.IdCliente = IdCliente
            registro.Cliente = cliente
            contacto.IdContacto = cmbIdContacto.Value
            registro.Contacto = contacto
            registro.Fecha = txtFecha.Text
            registro.Referencia = txtReferencia.Text
            moneda.CodMon = cmbCodMon.Value
            registro.Moneda = moneda
            registro.Igv = txtIgv.Value
            registro.FacCli = txtFacCli.Text
            registro.DscCli = txtDscCli.Text
            registro.TotBruto = txtTotalPrecio.Text
            registro.TotDscto = txtTotalDescuento.Text
            registro.TotVenta = txtTotal.Text
            registro.ObsCab = txtObsCab.Text
            registro.ObsDet = txtObsDet.Text
            condicionPago.CodPag = cmbCodPag.Value
            registro.CondicionPago = condicionPago
            registro.Plazo = txtPlazo.Text
            registro.Garantia = txtGarantia.Text
            registro.Entrega = txtEntrega.Text
            registro.Validez = txtValidez.Text
            registro.CodUsu = Session.sCodUsu
            registro.Estado = lblEstado.Text
            registro.DiasValidez = txtDiasValidez.Value
            registro.Exportacion = cbExportacion.Checked
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp


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

    Private Sub btnGenerarDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerarDocumento.Click
        Try
            Dim frm As New frmCotizacion_GenerarDocumento
            frm.Text = "Generar G/F/B/O.C. "
            frm.IdCotizacion = IdCotizacion
            frm.IdLocacion = IdLocacion
            frm.IdCliente = IdCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                lblEstado.Text = oCotizacionService.Estado(IdCotizacion)
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [GENERAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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

    Private Sub biGrabar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.MouseEnter
        sslError.Text = "Grabar los Cambios Hechos en la Cotizacion."
    End Sub
    Private Sub biDeshacer_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeshacer.MouseEnter
        sslError.Text = "Deshacer los Cambios Hechos en la Cabecera de la Cotizacion."
    End Sub
    Private Sub biEditar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.MouseEnter
        sslError.Text = "Editar Cabecera de la Cotizacion."
    End Sub
    Private Sub btnGenerarDocumento_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerarDocumento.MouseEnter
        sslError.Text = "Generar Documento G/F/B/O.C.."
    End Sub
    Private Sub biSugerir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSugerir.MouseEnter
        sslError.Text = "Sugerir Factor o Descuento a la Cotización."
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario Cotizacion."
    End Sub
    Private Sub miNuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Detalle de la Cotizacion."
    End Sub
    Private Sub miModificar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miModificar.MouseEnter
        sslError.Text = "Modificar Detalle actual."
    End Sub
    Private Sub miEliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.MouseEnter
        sslError.Text = "Eliminar Detalle actual."
    End Sub
    Private Sub miActualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.MouseEnter
        sslError.Text = "Actualizar detalles del Formulario Cotizacion."
    End Sub
    Private Sub miSugerir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSugerir.MouseEnter
        sslError.Text = "Sugerir Precio y/o Descuento al detalle seleccionado."
    End Sub
    Private Sub miAgregarPlantilla_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miAgregarPlantilla.MouseEnter
        sslError.Text = "Agregar Plantilla a la Cotización."
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                   btnGuardar.MouseLeave, btnDeshacer.MouseLeave, biSugerir.MouseLeave, _
                                   btnEditar.MouseLeave, btnCancelar.MouseLeave, btnGenerarDocumento.MouseLeave, _
                                   miNuevo.MouseLeave, miModificar.MouseLeave, miSugerir.MouseLeave, miAgregarPlantilla.MouseLeave, _
                                   miEliminar.MouseLeave, miActualizar.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub miModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miModificar.Click
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub

    Private Sub btnAgregarContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarContacto.Click
        If IdCliente > 0 Then
            Dim forma As New frmAgregarContacto
            forma.IdCliente = IdCliente
            If forma.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                listarContactos()
                cmbIdContacto.Value = toNumber(forma.txtIdContacto.Text)
                ' cmbIdContacto.Text = forma.txtNombres.Text & " " & frmAgregarContacto.txtApellidos.Text
                cmbIdContacto.ReadOnly = True
            End If
            ' MsgBox(cmbIdContacto.Value)  
        End If
        cmbIdContacto.Select()
    End Sub

    Private Sub btnRecalcularDscto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecalcularDscto.Click
        Dim frm As New frmCotizacion_Recalcular
        frm.IdCotizacion = IdCotizacion
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            MsgBox("Se realizó el recalculo del descuento correctamente ")
            ObtenerRegistro()
            actualizar()

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
    Private Sub sugerirCabecera()
        Try
            If toNumber(IdSugeridoCab) > 0 Then
                Dim registro As New CotizacionService.SugeridoCotizacion
                registro = oCotizacionService.MostrarPorIdSugerido(IdSugeridoCab)
                If registro.FactorSug + registro.DsctoSug = 0 And txtTotalSug.Text > 0 Then
                    MsgBox("No puede hacer sugerencias por Documento, por que ya se hizo a nivel de Detalle ... !!!", MsgBoxStyle.Critical)
                    Return
                End If
            End If
            Dim frm As New frmCotizacion_SugerirCabecera
            frm.IdCotizacion = IdCotizacion
            frm.IdSugerido = IdSugerido
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdSugerido = frm.IdSugerido
                dtDatos = Nothing
                ObtenerRegistro()
                listaDatos()
                'If frm.type_process = "insert" Or frm.type_process = "update" Then
                '    RowPossesion(dgvDatos, dtDatos, "IdGuia", frm.IdGuia)
                'Else
                '    MsgBox("Se elimino la sugerencia correctamente.", MsgBoxStyle.Information)
                'End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub sugerirDetalle()
        Try
            If toNumber(IdSugeridoCab) > 0 Then
                Dim registro As New CotizacionService.SugeridoCotizacion
                registro = oCotizacionService.MostrarPorIdSugerido(IdSugeridoCab)
                If registro.FactorSug + registro.DsctoSug > 0 Then
                    MsgBox("No puede hacer sugerencias por detalle, por que ya se hizo a nivel de Documento ... !!!", MsgBoxStyle.Critical)
                    Return
                End If
            End If

            Dim frm As New frmCotizacion_SugerirDetalle
            frm.IdCotizacion = IdCotizacion
            frm.IdCotizacionDet = toNumber(dgvDatos.CurrentRow.Cells("IdCotizacionDet").Value)
            frm.IdSugerido = IIf(dgvDatos.CurrentRow.Cells("IdSugerido").Text = "", 0, dgvDatos.CurrentRow.Cells("IdSugerido").Text)
            frm.IdLocacion = IdLocacion
            frm.IdCliente = IdCliente
            frm.CodMer = dgvDatos.CurrentRow.Cells("CodMer").Text
            frm.CodMon = cmbCodMon.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                IdSugerido = frm.IdSugerido
                dtDatos = Nothing
                ObtenerRegistro()
                listaDatos()

                If frm.type_process = "insert" Or frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdCotizacionDet)
                Else
                    MsgBox("Se eliminó la sugerencia correctamente.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub biSugerir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSugerir.Click
        If ValidaCodigoSeleccionado() Then
            sugerirCabecera()
            ObtenerRegistro()
        End If
    End Sub

    Private Sub miSugerir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSugerir.Click
        If ValidaCodigoSeleccionado() Then
            sugerirDetalle()
            ObtenerRegistro()
        End If
    End Sub

    Private Sub miAgregarPlantilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miAgregarPlantilla.Click
        Dim frm As New frmCotizacion_AgregarPlantilla

        frm.IdCliente = IdCliente
        frm.IdCotizacion = IdCotizacion
        frm.IdLocacion = IdLocacion
        frm.Text = "Agregar Plantilla a la cotización Nº" & txtNumCot.Text
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            listaDatos()
        End If
    End Sub

    Private Sub txtDiasValidez_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiasValidez.Validated
        If txtDiasValidez.ReadOnly = False Then
            txtValidez.Text = "A " & txtDiasValidez.Value & " DIAS"
        End If

    End Sub

    Private Sub miAgregarConsumoJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miAgregarConsumoJob.Click
        Try
            Dim frm As New frmCotizacion_AgregarConsumoJob
            frm.IdCotizacion = IdCotizacion
            frm.Text = "Agregar Consumo de Job a la Cotización Nº" & txtNumCot.Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                listaDatos()
            End If
        Catch ex As Exception

        End Try
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
                actualizar()
            End If
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub biActMoneda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActMoneda.Click
        Try
            Dim frm As New frmGuiaRemision_ActualizarMoneda

            frm.IdDoc = IdCotizacion
            frm.CodMon = cmbCodMon.Value
            frm.state_button = 4
            frm.NumDoc = txtNumCot.Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ObtenerRegistro()

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error al Actualizar la moneda")
        End Try
    End Sub

    'Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
    '    Dim frm As New frmEditarCabeceraFormato
    '    frm.state_button = state_button
    '    frm.IdCotizacion = IdCotizacion
    '    frm.estado = lblEstado.Text
    '    frm.txtObsCab.Rtf = toBlank(txtObsCab.Text)
    '    'Dim d As String = txtObsCab.Text
    '    'frm.txtObsCab.Text = d.ToRtf()
    '    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '        txtObsCab.Text = toBlank(frm.txtObsCab.Text)
    '    End If
    '    txtObsCab.Select()
    'End Sub

    Private Sub miFormatoExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miFormatoExcel.Click
        FormatoExcel()
    End Sub

    Private Sub FormatoExcel()

        Dim dtExcel As New DataTable("tabla2")

        dtExcel.Columns.Add(New DataColumn("Codigo", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Cantidad", Type.GetType("System.String")))        

        dtExcel.Rows.Add(New Object() {"", ""})

        dgvFormatoExcel.DataSource = dtExcel

        Dim Export As Boolean
        Export = ExportarExcel(dgvFormatoExcel)

        If Export Then
            MsgBox("Se descargo el excel correctamente")
        End If
    End Sub

    Private Sub miImportarExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miImportarExcel.Click
        OpenFileDialog1.InitialDirectory = "d:\"
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            DirFile = OpenFileDialog1.FileName
            CargadoFinal()
        End If
    End Sub

    Private Sub CargadoFinal()
        If Not OpenFileDialog1.FileName Is Nothing And OpenFileDialog1.FileName.Length > 0 Then
            fileExt = System.IO.Path.GetExtension(OpenFileDialog1.FileName)
            If (fileExt <> ".xls") And (fileExt <> ".xlsx") Then
                MsgBox("¡Solo se aceptan archivos de Excel, tenga cuidado...!", MsgBoxStyle.Information)
                Exit Sub
            Else
                CargarGrilla()
            End If
        End If
    End Sub

    Private Sub CargarGrilla()
        Try
            If MsgBox("¿Está seguro de IMPORTAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                dgvImportarExcel.DataSource = GetDataExcel(DirFile, fileExt)
                Dim estado_process As Integer = 0
                Dim mensaje As String = ""
                Dim Item As Integer = 0
                CodMon = cmbCodMon.Value

                If dgvImportarExcel.RowCount > 0 Then
                    For Each fila As DataGridViewRow In dgvImportarExcel.Rows
                        Dim registro As New CotizacionDetalleService.CotizacionDetalle
                        Dim cotizacion As New CotizacionDetalleService.Cotizacion
                        Dim modelo As New CotizacionDetalleService.Modelo
                        Dim marca As New CotizacionDetalleService.Marca
                        Dim stockactual As Integer

                        Dim codigo As String = ""
                        Item = Item + 1

                        codigo = toBlank(fila.Cells("Codigo").Value)
                        cotizacion.IdCotizacion = IdCotizacion

                        If oCotizacionDetalleService.Buscar(IdCotizacion, toBlank(codigo)) = True And Trim(codigo).Substring(0, 3) <> "AAA" Then
                            MsgBox("Código " + codigo + " ya existe...!", MsgBoxStyle.Information, "Información")
                            listaDatos()
                            Exit Sub

                        Else


                            If oMercaderiaService.Buscar(codigo, Session.sCodEmp) Then

                                Dim Mercaderia As New ProductoService.Producto  'MercaderiaService.Mercaderia
                                Mercaderia = oMercaderiaService.Obtener(codigo, Session.sCodEmp)

                                registro.Cotizacion = cotizacion
                                registro.CodMer = codigo
                                registro.DesMer = Mercaderia.DesMer1
                                modelo.ModMer = toNull(Mercaderia.Modelo.ModMer)
                                registro.Modelo = modelo
                                marca.CodMar = toNull(Mercaderia.Marca.CodMar)
                                registro.Marca = marca
                                registro.CanMer = toNumber(fila.Cells("Cantidad").Value)
                                registro.PreMer = toDouble(oPrecioService.PrecioVenta(IdLocacion, IdCliente, codigo, CodMon, Date.Today))
                                registro.DscMer = toDouble(oPrecioService.DescuentoVenta(IdLocacion, IdCliente, codigo))
                                registro.Stock = oPrecioService.MostrarStock(IdLocacion, codigo)
                                registro.Importado = True
                                registro.Referencia = Nothing
                                registro.Observacion = Nothing
                                registro.NoCore = False
                                registro.Item = Item


                                'ElseIf oPrecioService.BuscarListaPrecioFabrica(1, codigo) Then

                                '    Dim Precio As New PrecioService.PrecioFabrica
                                '    Precio = oPrecioService.ObtenerListaPrecioFabrica(1, codigo)

                                '    registro.Cotizacion = cotizacion
                                '    registro.CodMer = codigo
                                '    registro.DesMer = Precio.Mercaderia.DesMer1
                                '    modelo.ModMer = toNull(Precio.Mercaderia.Modelo.ModMer)
                                '    registro.Modelo = modelo
                                '    marca.CodMar = toNull(Precio.Mercaderia.Marca.CodMar)
                                '    registro.Marca = marca
                                '    registro.CanMer = toNumber(fila.Cells("Cantidad").Value)
                                '    registro.PreMer = toDouble(oPrecioService.PrecioVenta(IdLocacion, IdCliente, codigo, CodMon, Date.Today))
                                '    registro.DscMer = toDouble(oPrecioService.DescuentoVenta(IdLocacion, IdCliente, codigo))
                                '    registro.Stock = oPrecioService.MostrarStock(IdLocacion, codigo)
                                '    registro.Importado = True
                                '    registro.Referencia = Nothing
                                '    registro.Observacion = Nothing
                                '    registro.NoCore = False
                                '    registro.Item = Item

                                'ElseIf oPrecioService.BuscarPrecioFabricaGeneral(codigo)
                            ElseIf oListaPrecioFabricante.BuscarPrecioGeneralVigente(Session.sCodEmp, codigo) Then



                                Dim idListaPre As Integer = oListaPrecioFabricante.ObtenerIdListaPreGeneralVigente(Session.sCodEmp, codigo)
                                Dim preciofabrica As New ListaPrecioFabricanteDetService.ListaPrecioFabricanteDet 'PrecioService.PrecioFabrica
                                'preciofabrica = oPrecioService.ObtenerPrecioFabricaGeneral(codigo)
                                preciofabrica = oListaPrecioFabricante.ObtenerPrecioCodigoVigente(Session.sCodEmp, idListaPre, codigo)
                                Dim tc As Double = oMaestroService.MostrarTipoCambio("US", Today)

                                registro.Cotizacion = cotizacion
                                registro.CodMer = codigo
                                registro.DesMer = preciofabrica.DesMer  'preciofabrica.Mercaderia.DesMer2
                                modelo.ModMer = Nothing  'toNull(preciofabrica.Mercaderia.Modelo.ModMer)
                                registro.Modelo = modelo
                                marca.CodMar = Nothing  'toNull(preciofabrica.Mercaderia.Marca.CodMar)
                                registro.Marca = marca
                                registro.CanMer = toNumber(fila.Cells("Cantidad").Value)
                                registro.PreMer = oPrecioService.PrecioVenta(IdLocacion, IdCliente, codigo, CodMon, Date.Today) 'toDouble(IIf(CodMon = "US", preciofabrica.PreVenDol, Math.Round(preciofabrica.PreVenDol * tc, 2)))
                                registro.DscMer = oPrecioService.DescuentoVenta(IdLocacion, IdCliente, codigo) '0.00
                                registro.Stock = 0
                                registro.Importado = True
                                registro.Referencia = Nothing
                                registro.Observacion = Nothing
                                registro.NoCore = False
                                registro.Item = Item
                            Else
                                registro.Cotizacion = cotizacion
                                registro.CodMer = codigo
                                registro.DesMer = Nothing
                                modelo.ModMer = toNull(Nothing)
                                registro.Modelo = modelo
                                marca.CodMar = toNull(Nothing)
                                registro.Marca = marca
                                registro.CanMer = toNumber(fila.Cells("Cantidad").Value)
                                registro.PreMer = 0.0
                                registro.DscMer = 0.0
                                registro.Stock = 0
                                registro.Importado = False
                                registro.Referencia = Nothing
                                registro.Observacion = Nothing
                                registro.NoCore = False
                                registro.Item = Item

                                mensaje = mensaje & codigo & ", "

                            End If

                            registro.CodUsu = Session.sCodUsu
                            registro.NomPc = Session.sNomPc
                            registro.DirIp = Session.sDirIp

                            estado_process = oCotizacionDetalleService.Insertar(registro)

                        End If

                        'registro.CodUsu = Session.sCodUsu
                        'registro.NomPc = Session.sNomPc
                        'registro.DirIp = Session.sDirIp

                        'estado_process = oCotizacionDetalleService.Insertar(registro)

                    Next

                    If estado_process > 0 And mensaje = "" Then
                        MsgBox("Se ingresó los detalles correctamente", MsgBoxStyle.Information, "Error de datos")
                        listaDatos()
                    ElseIf estado_process > 0 And mensaje <> "" Then
                        MsgBox("Se ingresó los detalles correctamente. Favor de actualizar los datos de los códigos que no estan registrados en el sistema: " & mensaje, MsgBoxStyle.Information, "Error de datos")
                        listaDatos()
                    End If

                Else
                    MsgBox("¡No existen detalles a importar...!", MsgBoxStyle.Information, "Error de datos")
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al IMPORTAR los detalles: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cbExportacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbExportacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnGuardar.Enabled = True Then
                btnGuardar.Select()
                btnGuardar_Click(sender, e)
            Else
                dgvDatos.Select()
            End If

        End If
    End Sub

    Private Sub miEliminarDetalles_Click(sender As Object, e As EventArgs) Handles miEliminarDetalles.Click

        Try
            If MsgBox("¿Está seguro de ELIMINAR los detalles?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                Dim row As Janus.Windows.GridEX.GridEXRow

                For i = 0 To Me.dgvDatos.RowCount - 1
                    Me.dgvDatos.Row = i
                    row = Me.dgvDatos.GetRow()

                    If row.Cells("IdSugerido").Text = "" Then

                        oCotizacionDetalleService.Borrar(toNumber(row.Cells("IdCotizacionDet").Value), IdCotizacion, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    Else
                        MsgBox("Primero debe eliminar el Precio y/o Descuento sugerido")
                        Exit Sub
                    End If
                Next

                listaDatos()
                MsgBox("Se eliminaron los detalles correctamente.", MsgBoxStyle.Information)

            End If
        Catch ex As Exception
            MsgBox("Error al ELIMINAR los detalles: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub btnAgregarCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarCliente.Click
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
