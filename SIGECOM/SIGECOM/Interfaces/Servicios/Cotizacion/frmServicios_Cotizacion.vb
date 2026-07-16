Public Class frmServicios_Cotizacion

    Private oMaestroService As New MaestroService.MaestroClient
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private oCotizacionServicioDetService As New CotizacionServicioDetService.CotizacionServicioDetServiceClient
    Private oContactoService As New ContactoService.ContactoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oClienteService As New ClienteService.ClienteServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable
    Public NumCotizacion As String
    Private dtOficinas As DataTable
    Private dtSupervisor As DataTable
    Private dtTipo As DataTable
    Private dtTipoMantenimiento As DataTable
    'Private dtContactos As DataTable
    Private dtSubMarca As DataTable
    Private dtGarantia As DataTable
    Private dtMedioAprobacion As DataTable
    Private dtMonedas As DataTable
    Private dtCondicionesPago As DataTable
    Private IdEstado As String
    Private dtDatos As DataTable

    Private IdLocacion As DataTable
    Private IdCliente As Integer
    Public IdCotizacionSer As Integer

    Private dtContacto As DataTable
    Private state As Boolean = False
    Private CodMon As String
    Private Permiso As Boolean
    Private MonNac As Boolean
    Private dtCotRepAdjuntadas As DataTable

    Private dtCentroCosto As New DataTable
    Private dtAreas As New DataTable

    Public iCodArea As String
    Public iCodCentro As String

    Private Sub frmServicios_Cotizacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oCotizacionServicioService) = False Then
                oCotizacionServicioService.Close()
            End If
            If isClosed(oContactoService) = False Then
                oContactoService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
            If isClosed(oClienteService) = False Then
                oClienteService.Close()
            End If
            If isClosed(oPersonaService) = False Then
                oPersonaService.Close()
            End If
            If isClosed(oCentroCostoService) = False Then
                oCentroCostoService.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmServicios_Cotizacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            biSalir_Click(sender, e)
        End If
    End Sub

    Private Sub cmbIdContacto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F12 Then
            If btnAgregarContacto.Enabled = True Then
                e.Handled = True
                btnAgregarContacto_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtSerie_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerie.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarMercaderia.Enabled = True Then
                e.Handled = True
                btnBuscarMercaderia_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub frmServicios_Cotizacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtCodProveedor.KeyPress _
            , txtDatEntrega.KeyPress _
            , txtFecValidez.KeyPress _
            , txtModelo.KeyPress _
            , txtNumCot.KeyPress _
            , txtNumOrden.KeyPress _
            , txtSerie.KeyPress _
            , txtSerie.KeyPress _
            , txtSolicitado.KeyPress _
            , txtReferencia.KeyPress _
            , txtUnidad.KeyPress _
            , txtContacto.KeyPress _
            , cmbGarantia.KeyPress _
            , cmbMantenimiento.KeyPress _
            , cmbMedios.KeyPress _
            , cmbOficinas.KeyPress _
            , cmbSupervisor.KeyPress _
            , cmbTipo.KeyPress _
            , cmbCondPago.KeyPress _
            , cmbCodMon.KeyPress, cmbSubMarca.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub frmServicios_Cotizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvCotRepAdjuntadas)
        llenarcombos()

        Dim estilo1 As New Estilo
        estilo1.cargaEstiloGrid_Bucadores(dgvDatos)
        dgvDatos.RowFormatStyle.FontSize = 9.0!
        dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left


        Permiso = oSeguridadService.BuscarPermisoTipCam(Session.sCodUsu)
        CodMon = oMaestroService.ObtenerMonedaNacional(3)
        MonNac = oMaestroService.BuscarMonedaNacional(3)

        If state_button Then  'Actualizar
            Dim registro As CotizacionServicioService.CotizacionServicio
            registro = oCotizacionServicioService.Obtener(IdCotizacionSer)

            If registro.Repuestos = False Then
                Me.Size = New System.Drawing.Size(849, 671)
                gbDetalle.Visible = True
                gbCotRepAdjuntadas.Visible = False
            Else
                Me.Size = New System.Drawing.Size(849, 787)
                gbDetalle.Visible = True
                gbCotRepAdjuntadas.Visible = True

                ListarCotizacionRepuestos()
            End If
            ObtenerRegistro()
            desactivar()
            Me.Text = "Cotizacion Nº" & txtNumCot.Text
            actualizarDetalles()
        Else                      'Nuevo
            Me.Size = New System.Drawing.Size(849, 430)
            gbCotRepAdjuntadas.Visible = False
            gbDetalle.Visible = False
            cmbCodMon.Value = CodMon
            txtFecha.Value = Today
            txtFecValidez.Text = Date.Today.AddYears(1)

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
            'txtRepCotizado.ReadOnly = True
            'txtRepCotizado.BackColor = System.Drawing.SystemColors.Control
            'txtDsctoRepuestos.ReadOnly = True
            'txtDsctoRepuestos.BackColor = System.Drawing.SystemColors.Control
            cmbCondPago.ReadOnly = True
            cmbCondPago.BackColor = System.Drawing.SystemColors.Control
            txtLucCesante.ReadOnly = True
            txtLucCesante.BackColor = System.Drawing.SystemColors.Control
            cmbSubMarca.Enabled = False
            CargarCentroCosto()
            Me.Text = "Crear una Nueva Cotización para Servicios"
        End If
        enableOpciones()
    End Sub

    Private Sub CargarCentroCosto()
        Try
            cmbArea.Value = iCodArea
            cmbCentroCosto.Value = iCodCentro
            lblUnidadNegocio.Text = "Unidad de Negocio: " & oCentroCostoService.ObtenerDesUnidad(iCodArea)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListarCotizacionRepuestos()
        Try
            dtCotRepAdjuntadas = oCotizacionServicioService.MostrarCotizacionAdjuntada(IdCotizacionSer).Tables(0)
            dgvCotRepAdjuntadas.DataSource = dtCotRepAdjuntadas
        Catch ex As Exception
            MsgBox("Error al Listar Cotizaciones de Repuestos Adjuntadas" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        Try
            If dgvDatos.RowCount < 1 Then
                miNuevo.Enabled = True
                miMostrar.Enabled = True
                miEliminar.Enabled = False
                miActualizar.Enabled = False
            Else
                miNuevo.Enabled = IIf(IdEstado = 1, True, False)
                miMostrar.Enabled = IIf(IdEstado = 1, True, False)
                miEliminar.Enabled = IIf(IdEstado = 1, True, False)
                miActualizar.Enabled = IIf(IdEstado = 1, True, False)
            End If

            biEditar.Enabled = IIf(Not edicion And (IdEstado = 1 Or IdEstado = 2 Or IdEstado = 5), True, False)
            biActualizarOrden.Enabled = IIf(IdEstado = 1 Or IdEstado = 2, False, True)
            btnAprobar.Enabled = IIf(Not edicion And (IdEstado = 10 And (Session.CodPerfil = "01" Or Session.CodPerfil = "24" Or Session.CodPerfil = "12" Or Session.CodPerfil = "13" Or Session.CodPerfil = "51" Or Session.CodPerfil = "57")), True, False)
            biActMoneda.Enabled = IIf(Not edicion And (Session.CodPerfil = "11" Or Session.CodPerfil = "12" Or Session.CodPerfil = "05" Or Session.CodPerfil = "01") And IdEstado = 1, True, False)      '-------- Se agrega el Perfil de Costos 02/08/2016
            biGuardar.Enabled = edicion
            biDeshacer.Enabled = edicion
            cmOpciones.Enabled = IIf(Not edicion, True, False)

            'If state_button Then
            '    'biGuardar.Enabled = False
            '    'biDeshacer.Enabled = False
            '    'If IdEstado = 1 Then
            '    '    biEditar.Enabled = True
            '    'Else
            '    '    biEditar.Enabled = False
            '    'End If
            '    biEditar.Enabled = IIf(IdEstado = 1 Or IdEstado = 2 Or IdEstado = 5, True, False)
            '    biActualizarOrden.Enabled = IIf(IdEstado = 1 Or IdEstado = 2, False, True)
            '    btnAprobar.Enabled = IIf(IdEstado = 10 And (Session.CodPerfil = "01" Or Session.CodPerfil = "24"), True, False)
            '    biActMoneda.Enabled = IIf((Session.CodPerfil = "11" Or Session.CodPerfil = "12") And IdEstado = 1, True, False)
            '    miNuevo.Enabled = IIf(IdEstado = 1, True, False)
            '    miMostrar.Enabled = IIf(IdEstado = 1, True, False)
            '    miEliminar.Enabled = IIf(IdEstado = 1, True, False)
            '    miActualizar.Enabled = IIf(IdEstado = 1, True, False)
            '    'cmOpciones.Enabled = IIf(Not edicion, True, False)
            'Else
            '    biSalir.Enabled = False
            '    biEditar.Enabled = False
            '    biActualizarOrden.Enabled = False
            '    btnAprobar.Enabled = False
            '    biActMoneda.Enabled = False
            '    miNuevo.Enabled = False
            '    miMostrar.Enabled = False
            '    miEliminar.Enabled = False
            '    miActualizar.Enabled = False
            'End If

            'miNuevo.Enabled = IIf(editable And iEstado = 1, True, False)
            'miProcesarViatico.Enabled = IIf(editable And iEstado = 1 And (Session.CodPerfil = "30" Or Session.CodPerfil = "24" Or Session.CodPerfil = "01"), True, False)
            'biEditar.Enabled = IIf(editable, Not edicion, False)
            'biCerrar.Enabled = Not edicion
            'biAprobar.Enabled = IIf(Not edicion And (iEstado = 8 Or iEstado = 2), True, False)

            'biGuardar.Enabled = edicion
            'biDeshacer.Enabled = edicion
            'cmOpciones.Enabled = IIf(Not edicion, True, False)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub llenarcombos()
        Try
            '======================================= OFICINAS ================================================
            dtOficinas = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

            '======================================= SUPERVISOR ================================================
            dtSupervisor = oCotizacionServicioService.MostrarSupervisores(Session.sCodEmp).Tables(0)
            dtSupervisor.Rows.InsertAt(getRowTodos(dtSupervisor), 0)
            cmbSupervisor.DataSource = dtSupervisor
            cmbSupervisor.DropDownList.DataMember = dtSupervisor.Columns("AbrPer").ToString
            cmbSupervisor.DropDownList.DisplayMember = dtSupervisor.Columns("AbrPer").ToString
            cmbSupervisor.DropDownList.ValueMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(0).DataMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(1).DataMember = dtSupervisor.Columns("AbrPer").ToString
            'cmbSupervisor.SelectedIndex = 0
            dtSupervisor = Nothing

            '======================================= FABRICANTE ================================================
            dtTipo = oCotizacionServicioService.MostrarFabricante.Tables(0)
            dtTipo.Rows.InsertAt(getRowTodos(dtTipo), 0)
            cmbTipo.DataSource = dtTipo
            cmbTipo.DropDownList.DataMember = dtTipo.Columns("NomFabricante").ToString
            cmbTipo.DropDownList.DisplayMember = dtTipo.Columns("NomFabricante").ToString
            cmbTipo.DropDownList.ValueMember = dtTipo.Columns("IdFabricante").ToString
            cmbTipo.DropDownList.Columns(0).DataMember = dtTipo.Columns("IdFabricante").ToString
            cmbTipo.DropDownList.Columns(1).DataMember = dtTipo.Columns("NomFabricante").ToString
            dtTipo = Nothing

            '======================================= TIPO MANTENIMIENTO ================================================

            dtTipoMantenimiento = oCotizacionServicioService.MostrarTipoMantenimiento.Tables(0)
            dtTipoMantenimiento.Rows.InsertAt(getRowTodos(dtTipoMantenimiento), 0)
            cmbMantenimiento.DataSource = dtTipoMantenimiento
            cmbMantenimiento.DropDownList.DataMember = dtTipoMantenimiento.Columns("DesMantenimiento").ToString
            cmbMantenimiento.DropDownList.DisplayMember = dtTipoMantenimiento.Columns("DesMantenimiento").ToString
            cmbMantenimiento.DropDownList.ValueMember = dtTipoMantenimiento.Columns("CodMantenimiento").ToString
            cmbMantenimiento.DropDownList.Columns(0).DataMember = dtTipoMantenimiento.Columns("CodMantenimiento").ToString
            cmbMantenimiento.DropDownList.Columns(1).DataMember = dtTipoMantenimiento.Columns("DesMantenimiento").ToString
            'cmbMantenimiento.SelectedIndex = 0
            dtTipoMantenimiento = Nothing

            '======================================= SUB MARCA ================================================
            dtSubMarca = oCotizacionServicioService.MostrarSubMarca
            dtSubMarca.Rows.InsertAt(getRowTodos(dtSubMarca), 0)
            cmbSubMarca.DataSource = dtSubMarca
            cmbSubMarca.DropDownList.DataMember = dtSubMarca.Columns("Tipo").ToString
            cmbSubMarca.DropDownList.DisplayMember = dtSubMarca.Columns("Tipo").ToString
            cmbSubMarca.DropDownList.ValueMember = dtSubMarca.Columns("Tipo").ToString
            cmbSubMarca.DropDownList.Columns(0).DataMember = dtSubMarca.Columns("Tipo").ToString
            'cmbSubMarca.SelectedIndex = 0
            dtSubMarca = Nothing

            '======================================= GARANTIA ================================================
            dtGarantia = oCotizacionServicioService.MostrarGarantia.Tables(0)
            dtGarantia.Rows.InsertAt(getRowTodos(dtGarantia), 0)
            cmbGarantia.DataSource = dtGarantia
            cmbGarantia.DropDownList.DataMember = dtGarantia.Columns("DesGarantia").ToString
            cmbGarantia.DropDownList.DisplayMember = dtGarantia.Columns("DesGarantia").ToString
            cmbGarantia.DropDownList.ValueMember = dtGarantia.Columns("IdGarantia").ToString
            cmbGarantia.DropDownList.Columns(0).DataMember = dtGarantia.Columns("IdGarantia").ToString
            cmbGarantia.DropDownList.Columns(1).DataMember = dtGarantia.Columns("DesGarantia").ToString
            'cmbSubMarca.SelectedIndex = 0
            dtGarantia = Nothing

            '======================================= MEDIO APROBACION ================================================
            dtMedioAprobacion = oCotizacionServicioService.MostrarMedioAprobacion.Tables(0)
            dtMedioAprobacion.Rows.InsertAt(getRowTodos(dtMedioAprobacion), 0)
            cmbMedios.DataSource = dtMedioAprobacion
            cmbMedios.DropDownList.DataMember = dtMedioAprobacion.Columns("DesMedio").ToString
            cmbMedios.DropDownList.DisplayMember = dtMedioAprobacion.Columns("DesMedio").ToString
            cmbMedios.DropDownList.ValueMember = dtMedioAprobacion.Columns("IdMedio").ToString
            cmbMedios.DropDownList.Columns(0).DataMember = dtMedioAprobacion.Columns("IdMedio").ToString
            cmbMedios.DropDownList.Columns(1).DataMember = dtMedioAprobacion.Columns("DesMedio").ToString
            ' cmbSubMarca.SelectedIndex = 0
            dtMedioAprobacion = Nothing

            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbCodMon.DataSource = dtMonedas
            cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

            '======================================= COND. DE PAGO ================================================
            Try
                dtCondicionesPago = oMaestroService.MostrarCondicionPago.Tables(0)
                'dtCondicionesPago.Rows.InsertAt(getRowTodos(dtCondicionesPago), 0)
                cmbCondPago.DataSource = dtCondicionesPago
                cmbCondPago.DropDownList.DataMember = dtCondicionesPago.Columns("DesPag").ToString
                cmbCondPago.DropDownList.DisplayMember = dtCondicionesPago.Columns("DesPag").ToString
                cmbCondPago.DropDownList.ValueMember = dtCondicionesPago.Columns("CodPag").ToString
                cmbCondPago.DropDownList.Columns(0).DataMember = dtCondicionesPago.Columns("CodPag").ToString
                cmbCondPago.DropDownList.Columns(1).DataMember = dtCondicionesPago.Columns("DesPag").ToString
                'cmbCondPago.SelectedIndex = 0
                dtCondicionesPago = Nothing
            Catch ex As Exception
                MsgBox("Error al Cargar Combos" + ex.Message, MsgBoxStyle.Exclamation)
            End Try

            '========================================== AREAS ===============================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbArea.DataSource = dtAreas
            cmbArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            dtAreas = Nothing

        Catch ex As Exception
            MsgBox("Error al Cargar Combos" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub cmbCodArea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbArea.Value, Session.sCodUsu).Tables(0)
            cmbCentroCosto.DataSource = dtCentroCosto
            cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.SelectedIndex = 0

            If cmbArea.Value = "" Then
                lblUnidadNegocio.Text = ""
            Else
                lblUnidadNegocio.Text = "Unidad de Negocio: " & oCentroCostoService.ObtenerDesUnidad(cmbArea.Value)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    'Private Sub listarContactos()
    '    Try
    '        '======================================= CONTACTOS ================================================
    '        dtContactos = oContactoService.Mostrar(IdCliente).Tables(0)
    '        cmbIdContacto.DataSource = dtContactos
    '        cmbIdContacto.DropDownList.DataMember = dtContactos.Columns("Apellidos").ToString
    '        cmbIdContacto.DropDownList.DisplayMember = dtContactos.Columns("Apellidos").ToString
    '        cmbIdContacto.DropDownList.ValueMember = dtContactos.Columns("IdContacto").ToString
    '        cmbIdContacto.DropDownList.Columns(0).DataMember = dtContactos.Columns("IdContacto").ToString
    '        cmbIdContacto.DropDownList.Columns(1).DataMember = dtContactos.Columns("Apellidos").ToString
    '        cmbIdContacto.DropDownList.Columns(2).DataMember = dtContactos.Columns("Nombres").ToString
    '        dtContactos = Nothing
    '    Catch ex As Exception
    '        MsgBox("Error al Cargar Combos" + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If state_button = True And toNumber(IdCotizacionSer) = 0 Then
                MsgBox("Debe ingresar el codigo de la cotización")
                txtNumCot.Focus()
                Return False
            ElseIf toBlank(cmbOficinas.Value) = "" Then
                MsgBox("Debe ingresar la oficina")
                cmbOficinas.Focus()
                Return False
            ElseIf toBlank(cmbTipo.Value) = "" Then
                MsgBox("Debe ingresar el Fabricante")
                cmbTipo.Focus()
                Return False
            ElseIf toNumber(IdCliente) = 0 Then
                MsgBox("Debe ingresar el cliente")
                btnBuscarCliente.Focus()
                Return False
            ElseIf toBlank(cmbMantenimiento.Value) = "" Then
                MsgBox("Debe ingresar el mantenimiento")
                cmbMantenimiento.Focus()
                Return False
            ElseIf toBlank(cmbCodMon.Value) = "" Then
                MsgBox("Debe ingresar la moneda")
                cmbCodMon.Focus()
                Return False
            ElseIf IsDBNull(cmbGarantia.Value) Then
                MsgBox("Debe ingresar la Garantía")
                cmbGarantia.Focus()
                Return False
                'ElseIf toNumber(cmbGarantia.Value) = 0 Then
                '    MsgBox("Debe ingresar la Garantía")
                '    cmbGarantia.Focus()
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Modificar(ByVal registro As CotizacionServicioService.CotizacionServicio)
        Try
            Dim estado_process As Boolean
            estado_process = oCotizacionServicioService.Actualizar(registro)
            If estado_process Then
                InsertarContacto()
                desactivar()
                ObtenerRegistro()
                MsgBox("Se modificó la cotización de servicios correctamente ")
            Else
                MsgBox("Error en el Proceso, Comuniquese con el Departamento de Sistemas", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As CotizacionServicioService.CotizacionServicio)
        Try
            Dim estado_process As Integer
            estado_process = oCotizacionServicioService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdCotizacionSer = estado_process
                InsertarContacto()
                MsgBox("Se insertó la cotización de servicios correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub InsertarContacto()
        Try
            If state = True Then
                Dim estado_process As Boolean
                estado_process = oCotizacionServicioService.InsertarContacto(IdCotizacionSer, Session.sCodUsu, dtContacto)
                dtContacto.Clear()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub
    Private Sub activar()
        If oCotizacionServicioService.Estado(IdCotizacionSer) = 1 Then
            cbRepuesto.Enabled = True
            cbCotAdicional.Enabled = True
            cbExportacion.Enabled = True
            'cbAprobado.Enabled = True
            btnBuscarMercaderia.Enabled = True
            btnBuscarCliente.Enabled = True
            btnAgregarContacto.Enabled = True
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            cmbTipo.ReadOnly = False
            cmbTipo.BackColor = System.Drawing.SystemColors.Window
            cmbOficinas.ReadOnly = False
            cmbOficinas.BackColor = System.Drawing.SystemColors.Window
            cmbSubMarca.ReadOnly = False
            cmbSubMarca.BackColor = System.Drawing.SystemColors.Window
            cmbMantenimiento.ReadOnly = False
            cmbMantenimiento.BackColor = System.Drawing.SystemColors.Window
            'txtContacto.ReadOnly = False
            'txtContacto.BackColor = System.Drawing.SystemColors.Window
            'cmbCondPago.ReadOnly = False
            'cmbCondPago.BackColor = System.Drawing.SystemColors.Window
            cmbGarantia.ReadOnly = False
            cmbGarantia.BackColor = System.Drawing.SystemColors.Window
            'cmbEstCotizacion.ReadOnly = False
            'cmbEstCotizacion.BackColor = System.Drawing.SystemColors.Window
            cmbSupervisor.ReadOnly = False
            cmbSupervisor.BackColor = System.Drawing.SystemColors.Window
            cmbMedios.ReadOnly = False
            cmbMedios.BackColor = System.Drawing.SystemColors.Window
            'cmbCodMon.ReadOnly = False
            'cmbCodMon.BackColor = System.Drawing.SystemColors.Window
            If oClienteService.BuscarMonedaCliente(3, IdCliente) = True Then
                cmbCodMon.ReadOnly = False
                cmbCodMon.BackColor = System.Drawing.SystemColors.Window
            Else
                If Permiso = False And MonNac = True Then
                    cmbCodMon.ReadOnly = True
                    cmbCodMon.BackColor = System.Drawing.SystemColors.Control

                End If
            End If
            txtSerie.ReadOnly = False
            txtSerie.BackColor = System.Drawing.SystemColors.Window
            txtModelo.ReadOnly = False
            txtModelo.BackColor = System.Drawing.SystemColors.Window
            txtUnidad.ReadOnly = False
            txtUnidad.BackColor = System.Drawing.SystemColors.Window
            txtDescripcion.ReadOnly = False
            txtDescripcion.BackColor = System.Drawing.SystemColors.Window
            txtDescripcion.ButtonEnabled = True
            txtReferencia.ReadOnly = False
            txtReferencia.BackColor = System.Drawing.SystemColors.Window
            txtSolicitado.ReadOnly = False
            txtSolicitado.BackColor = System.Drawing.SystemColors.Window
            txtDatEntrega.ReadOnly = False
            txtDatEntrega.BackColor = System.Drawing.SystemColors.Window
            txtCodProveedor.ReadOnly = False
            txtCodProveedor.BackColor = System.Drawing.SystemColors.Window
            'txtRepCotizado.ReadOnly = False
            'txtRepCotizado.BackColor = System.Drawing.SystemColors.Window
            'txtDsctoRepuestos.ReadOnly = False
            'txtDsctoRepuestos.BackColor = System.Drawing.SystemColors.Window
            'txtMateriales.ReadOnly = False
            'txtMateriales.BackColor = System.Drawing.SystemColors.Window
            'txtGastoViaje.ReadOnly = False
            'txtGastoViaje.BackColor = System.Drawing.SystemColors.Window
            'txtManObra.ReadOnly = False
            'txtManObra.BackColor = System.Drawing.SystemColors.Window
            'txtTerceros.ReadOnly = False
            'txtTerceros.BackColor = System.Drawing.SystemColors.Window
            'txtVarios.ReadOnly = False
            'txtVarios.BackColor = System.Drawing.SystemColors.Window
            'txtVarios1.ReadOnly = False
            'txtVarios1.BackColor = System.Drawing.SystemColors.Window
            'txtVarios2.ReadOnly = False
            'txtVarios2.BackColor = System.Drawing.SystemColors.Window
            'txtVarios3.ReadOnly = False
            'txtVarios3.BackColor = System.Drawing.SystemColors.Window
            'txtRepower.ReadOnly = False
            'txtRepower.BackColor = System.Drawing.SystemColors.Window
            'txtMonTerceros.ReadOnly = False
            'txtMonTerceros.BackColor = System.Drawing.SystemColors.Window
            'txtMonVarios.ReadOnly = False
            'txtMonVarios.BackColor = System.Drawing.SystemColors.Window
            'txtMonVarios1.ReadOnly = False
            'txtMonVarios1.BackColor = System.Drawing.SystemColors.Window
            'txtMonVarios2.ReadOnly = False
            'txtMonVarios2.BackColor = System.Drawing.SystemColors.Window
            'txtMonVarios3.ReadOnly = False
            'txtMonVarios3.BackColor = System.Drawing.SystemColors.Window
            'txtMonRepower.ReadOnly = False
            'txtMonRepower.BackColor = System.Drawing.SystemColors.Window
            txtGlosa.ReadOnly = False
            txtGlosa.BackColor = System.Drawing.SystemColors.Window
            txtFecValidez.ReadOnly = False
            txtFecValidez.BackColor = System.Drawing.SystemColors.Window
            'txtLucCesante.ReadOnly = False
            'txtLucCesante.BackColor = System.Drawing.SystemColors.Window
            txtNumOrden.ReadOnly = False
            txtNumOrden.BackColor = System.Drawing.SystemColors.Window
        Else
            txtDescripcion.ReadOnly = False
            txtDescripcion.BackColor = System.Drawing.SystemColors.Window
            txtDescripcion.ButtonEnabled = True
            txtGlosa.ReadOnly = False
            txtGlosa.BackColor = System.Drawing.SystemColors.Window
            btnAgregarContacto.Enabled = True
            'txtNumOrden.ReadOnly = True
        End If
        'biDeshacer.Enabled = True
        'biEditar.Enabled = False
        'biGuardar.Enabled = True
        edicion = True
        enableOpciones()
    End Sub
    Private Sub desactivar()
        txtNumCot.ReadOnly = True '----------------------------------------------------------------borrar
        txtNumCot.BackColor = System.Drawing.SystemColors.Control '---------------------------------borrar
        cbRepuesto.Enabled = False
        cbCotAdicional.Enabled = False
        cbExportacion.Enabled = False
        'cbAprobado.Enabled = False
        btnBuscarMercaderia.Enabled = False
        btnBuscarCliente.Enabled = False
        btnAgregarContacto.Enabled = False
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        cmbTipo.ReadOnly = True
        cmbTipo.BackColor = System.Drawing.SystemColors.Control
        cmbOficinas.ReadOnly = True
        cmbOficinas.BackColor = System.Drawing.SystemColors.Control
        cmbSubMarca.ReadOnly = True
        cmbSubMarca.BackColor = System.Drawing.SystemColors.Control
        cmbMantenimiento.ReadOnly = True
        cmbMantenimiento.BackColor = System.Drawing.SystemColors.Control
        txtContacto.ReadOnly = True
        txtContacto.BackColor = System.Drawing.SystemColors.Control
        cmbCondPago.ReadOnly = True
        cmbCondPago.BackColor = System.Drawing.SystemColors.Control
        cmbGarantia.ReadOnly = True
        cmbGarantia.BackColor = System.Drawing.SystemColors.Control
        'cmbEstCotizacion.ReadOnly = True
        'cmbEstCotizacion.BackColor = System.Drawing.SystemColors.Control
        cmbSupervisor.ReadOnly = True
        cmbSupervisor.BackColor = System.Drawing.SystemColors.Control
        cmbMedios.ReadOnly = True
        cmbMedios.BackColor = System.Drawing.SystemColors.Control
        cmbCodMon.ReadOnly = True
        cmbCodMon.BackColor = System.Drawing.SystemColors.Control
        txtSerie.ReadOnly = True
        txtSerie.BackColor = System.Drawing.SystemColors.Control
        txtModelo.ReadOnly = True
        txtModelo.BackColor = System.Drawing.SystemColors.Control
        txtUnidad.ReadOnly = True
        txtUnidad.BackColor = System.Drawing.SystemColors.Control
        txtDescripcion.ReadOnly = True
        txtDescripcion.BackColor = System.Drawing.SystemColors.Control
        txtDescripcion.ButtonEnabled = False
        txtReferencia.ReadOnly = True
        txtReferencia.BackColor = System.Drawing.SystemColors.Control
        txtSolicitado.ReadOnly = True
        txtSolicitado.BackColor = System.Drawing.SystemColors.Control
        txtDatEntrega.ReadOnly = True
        txtDatEntrega.BackColor = System.Drawing.SystemColors.Control
        txtCodProveedor.ReadOnly = True
        txtCodProveedor.BackColor = System.Drawing.SystemColors.Control
        'txtRepCotizado.ReadOnly = True
        'txtRepCotizado.BackColor = System.Drawing.SystemColors.Control
        'txtDsctoRepuestos.ReadOnly = True
        'txtDsctoRepuestos.BackColor = System.Drawing.SystemColors.Control
        'txtMateriales.ReadOnly = True
        'txtMateriales.BackColor = System.Drawing.SystemColors.Control
        'txtGastoViaje.ReadOnly = True
        'txtGastoViaje.BackColor = System.Drawing.SystemColors.Control
        'txtManObra.ReadOnly = True
        'txtManObra.BackColor = System.Drawing.SystemColors.Control
        'txtTerceros.ReadOnly = True
        'txtTerceros.BackColor = System.Drawing.SystemColors.Control
        'txtVarios.ReadOnly = True
        'txtVarios.BackColor = System.Drawing.SystemColors.Control
        'txtVarios1.ReadOnly = True
        'txtVarios1.BackColor = System.Drawing.SystemColors.Control
        'txtVarios2.ReadOnly = True
        'txtVarios2.BackColor = System.Drawing.SystemColors.Control
        'txtVarios3.ReadOnly = True
        'txtVarios3.BackColor = System.Drawing.SystemColors.Control
        'txtRepower.ReadOnly = True
        'txtRepower.BackColor = System.Drawing.SystemColors.Control
        'txtMonTerceros.ReadOnly = True
        'txtMonTerceros.BackColor = System.Drawing.SystemColors.Control
        'txtMonVarios.ReadOnly = True
        'txtMonVarios.BackColor = System.Drawing.SystemColors.Control
        'txtMonVarios1.ReadOnly = True
        'txtMonVarios1.BackColor = System.Drawing.SystemColors.Control
        'txtMonVarios2.ReadOnly = True
        'txtMonVarios2.BackColor = System.Drawing.SystemColors.Control
        'txtMonVarios3.ReadOnly = True
        'txtMonVarios3.BackColor = System.Drawing.SystemColors.Control
        'txtMonRepower.ReadOnly = True
        'txtMonRepower.BackColor = System.Drawing.SystemColors.Control
        txtGlosa.ReadOnly = True
        txtGlosa.BackColor = System.Drawing.SystemColors.Control
        txtFecValidez.ReadOnly = True
        txtFecValidez.BackColor = System.Drawing.SystemColors.Control
        txtLucCesante.ReadOnly = True
        txtLucCesante.BackColor = System.Drawing.SystemColors.Control
        txtNumOrden.ReadOnly = True
        txtNumOrden.BackColor = System.Drawing.SystemColors.Control

        'biDeshacer.Enabled = False
        'biEditar.Enabled = IIf(IdEstado = 1, True, False)
        'biGuardar.Enabled = False
        edicion = False
        enableOpciones()
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As CotizacionServicioService.CotizacionServicio
            registro = oCotizacionServicioService.Obtener(IdCotizacionSer)

            IdCotizacionSer = registro.IdCotizacionSer
            txtNumCot.Text = registro.NumCotizacion
            cmbOficinas.Value = registro.Oficina.CodOfi
            cbRepuesto.Checked = registro.Repuestos
            cmbTipo.Value = registro.Fabricante.IdFabricante
            cmbSubMarca.Value = registro.SubMarca
            txtFecha.Value = registro.Fecha
            IdCliente = registro.Cliente.IdCliente
            txtContacto.Text = registro.RefContacto
            txtBuscarCliente.Text = registro.Cliente.DesCli
            cmbMantenimiento.Value = registro.TipoMantenimiento.CodMantenimiento
            txtSerie.Text = registro.CodMer
            txtModelo.Text = registro.ModMer
            txtUnidad.Text = registro.Unidad
            cbCotAdicional.Checked = registro.Adicional
            cbExportacion.Checked = registro.Exportacion
            txtDescripcion.Text = registro.Observacion
            txtReferencia.Text = registro.Referencia
            txtSolicitado.Text = registro.Solicitante
            txtDatEntrega.Text = registro.DatosEntrega
            txtCodProveedor.Text = registro.CodProveedor
            cmbCodMon.Value = registro.Moneda.CodMon
            'txtRepCotizado.Text = registro.TotRepuestos
            'txtDsctoRepuestos.Text = registro.TotDscto
            'txtMateriales.Text = registro.TotMateriales
            'txtGastoViaje.Text = registro.TotViaticos
            'txtManObra.Text = registro.TotManoObra
            'txtTerceros.Text = registro.DesTerceros
            'txtMonTerceros.Text = registro.TotTerceros
            'txtVarios.Text = registro.DesOtroGasto
            'txtMonVarios.Text = registro.TotOtroGasto
            'txtVarios1.Text = registro.DesOtroGasto1
            'txtMonVarios1.Text = registro.TotOtroGasto1
            'txtVarios2.Text = registro.DesOtroGasto2
            'txtMonVarios2.Text = registro.TotOtroGasto2
            'txtVarios3.Text = registro.DesOtroGasto3
            'txtMonVarios3.Text = registro.TotOtroGasto3
            'txtRepower.Text = registro.DesOtroGasto4
            'txtMonRepower.Text = registro.TotOtroGasto4
            'txtMonDescuento.Text = registro.Descuento
            txtGlosa.Text = registro.Glosa
            cmbCondPago.Value = registro.CondicionPago.CodPag
            txtFecValidez.Text = toNull(registro.FecValidez)
            cmbGarantia.Value = registro.Garantia.IdGarantia
            txtLucCesante.Text = registro.LucroCesante
            cmbMedios.Value = registro.MedioAprobacion.IdMedio
            txtNumOrden.Text = registro.NumOrden
            cmbSupervisor.Value = registro.Supervisor.IdPer
            IdEstado = registro.EstadoCotizacion.IdEstado
            lblEstado.Text = registro.EstadoCotizacion.DesEstado

            lblTotalMontoSinIgv.Text = "IGV " + cmbCodMon.Text + " ==> "
            'lblTotalMontoBruto.Text = "MONTO TOTAL BRUTO " + cmbCodMon.Text + " :"
            lblMontoDscto.Text = "SUBTOTAL " + cmbCodMon.Text + " ==> "
            lblMontoTotal.Text = "MONTO TOTAL " + cmbCodMon.Text + " ==> "
            lblMontoTotalNeto.Text = "MONTO TOTAL NETO " + cmbCodMon.Text + " ==> "

            txtMontoSinIGV.Value = registro.TotIgv
            txtMontoBruto.Value = registro.TotBruto
            txtTotalDescuento.Value = registro.TotDscto
            txtMontoTotalNeto.Value = registro.TotNeto
            txtMontoTotal.Value = registro.TotVenta

            'txtMontoTotal.Value = registro.
            'Dim registro1 As New CotizacionServicioService
            ''Dim registro2 As New GuiaRemisionService.SugeridoGuia
            'registro1 = oGuiaRemisionService.MostrarPorId(IdGuia)
            cmbArea.Value = registro.CentroCosto.Area.CodArea
            cmbCentroCosto.Value = registro.CentroCosto.CodCentro
            lblUnidadNegocio.Text = "Unidad de Negocio: " & oCentroCostoService.ObtenerDesUnidad(registro.CentroCosto.Area.CodArea)

            enableOpciones()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        If MsgBox("¿Está seguro de salir del formulario?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then

            Dim registro As New CotizacionServicioService.CotizacionServicio
            Dim oficina As New CotizacionServicioService.Oficina
            Dim cliente As New CotizacionServicioService.Cliente
            Dim tipomantenimiento As New CotizacionServicioService.TipoMantenimiento
            'Dim contacto As New CotizacionServicioService.Contacto
            Dim condicionpago As New CotizacionServicioService.CondicionPago
            Dim garantia As New CotizacionServicioService.Garantia
            Dim medioaprobacion As New CotizacionServicioService.MedioAprobacion
            Dim estadocotizacion As New CotizacionServicioService.EstadoCotizacion
            Dim supervisor As New CotizacionServicioService.Persona
            Dim moneda As New CotizacionServicioService.Moneda
            Dim empresa As New CotizacionServicioService.Empresa
            Dim fabricante As New CotizacionServicioService.Fabricante
            Dim Area As New CotizacionServicioService.Area
            Dim CentroCosto As New CotizacionServicioService.CentroCosto

            registro.IdCotizacionSer = IdCotizacionSer
            registro.NumCotizacion = txtNumCot.Text
            oficina.CodOfi = cmbOficinas.Value
            registro.Oficina = oficina
            registro.Repuestos = cbRepuesto.Checked
            fabricante.IdFabricante = cmbTipo.Value
            registro.Fabricante = fabricante
            registro.Fecha = txtFecha.Value
            registro.SubMarca = toNull(cmbSubMarca.Value)
            cliente.IdCliente = IdCliente
            registro.Cliente = cliente
            tipomantenimiento.CodMantenimiento = toNull(cmbMantenimiento.Value)
            registro.TipoMantenimiento = tipomantenimiento
            registro.CodMer = toNull(txtSerie.Text)
            registro.ModMer = toNull(txtModelo.Text)
            registro.Unidad = toNull(txtUnidad.Text)
            registro.Adicional = cbCotAdicional.Checked
            registro.Exportacion = cbExportacion.Checked
            registro.Observacion = toNull(txtDescripcion.Text)
            registro.RefContacto = toNull(txtContacto.Text)
            registro.Referencia = toNull(txtReferencia.Text)
            registro.Solicitante = toNull(txtSolicitado.Text)
            registro.DatosEntrega = toNull(txtDatEntrega.Text)
            registro.CodProveedor = toNull(txtCodProveedor.Text)
            moneda.CodMon = cmbCodMon.Value
            registro.Moneda = moneda
            'registro.Fecha
            'registro.TotRepuestos = txtRepCotizado.Text
            'registro.TotDscto = txtDsctoRepuestos.Text
            'registro.TotMateriales = txtMateriales.Text
            'registro.TotViaticos = txtGastoViaje.Text
            'registro.TotManoObra = txtManObra.Text
            'registro.DesTerceros = toNull(txtTerceros.Text)
            'registro.TotTerceros = txtMonTerceros.Text
            'registro.DesOtroGasto = toNull(txtVarios.Text)
            'registro.TotOtroGasto = txtMonVarios.Text
            'registro.DesOtroGasto1 = toNull(txtVarios1.Text)
            'registro.TotOtroGasto1 = txtMonVarios1.Text
            'registro.DesOtroGasto2 = toNull(txtVarios2.Text)
            'registro.TotOtroGasto2 = txtMonVarios2.Text
            'registro.DesOtroGasto3 = toNull(txtVarios3.Text)
            'registro.TotOtroGasto3 = txtMonVarios3.Text
            'registro.DesOtroGasto4 = txtRepower.Text
            'registro.TotOtroGasto4 = toNull(txtMonRepower.Text)
            registro.Glosa = toNull(txtGlosa.Text)
            condicionpago.CodPag = cmbCondPago.Value
            registro.CondicionPago = condicionpago
            registro.FecValidez = txtFecValidez.Value
            garantia.IdGarantia = cmbGarantia.Value
            registro.Garantia = garantia
            registro.LucroCesante = toNull(txtLucCesante.Text)
            medioaprobacion.IdMedio = cmbMedios.Value
            registro.MedioAprobacion = medioaprobacion
            registro.NumOrden = toNull(txtNumOrden.Text)
            'estadocotizacion.IdEstado = cmbEstCotizacion.Value
            'registro.EstadoCotizacion = estadocotizacion
            supervisor.IdPer = IIf(cmbSupervisor.Value = 0, Nothing, cmbSupervisor.Value)
            registro.Supervisor = supervisor

            Area.CodArea = cmbArea.Value
            CentroCosto.CodCentro = cmbCentroCosto.Value
            CentroCosto.Area = Area
            registro.CentroCosto = CentroCosto

            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp
            empresa.CodEmp = Session.sCodEmp
            registro.Empresa = empresa
            'registro.Fecha = Today
            If state_button Then
                Modificar(registro)
            Else
                Insertar(registro)
            End If
        End If
    End Sub

    Private Sub biActivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.Click
        activar()
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm As New frmBuscarMercaderia
        frm.cmbCodRub.Value = "04"
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtSerie.Text = frm.codigo
        End If
        txtSerie.Select()
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtBuscarCliente.Text = frm.descripcion
                    IdCliente = frm.codigo

                    If oClienteService.BuscarMonedaCliente(3, IdCliente) = True Then
                        cmbCodMon.ReadOnly = False
                        cmbCodMon.BackColor = System.Drawing.SystemColors.Window
                    Else
                        If Permiso = False And MonNac = True Then
                            cmbCodMon.ReadOnly = True
                            cmbCodMon.BackColor = System.Drawing.SystemColors.Control
                            cmbCodMon.Value = CodMon
                        End If
                    End If
                    cmbMantenimiento.Select()
                Else
                    txtBuscarCliente.Text = ""
                    IdCliente = 0
                End If
                'listarContactos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub cmbTipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.ValueChanged
    '    If cmbTipo.Value = "MTU" Then
    '        cmbSubMarca.Value = ""
    '        cmbSubMarca.Enabled = False
    '    ElseIf cmbTipo.Value = "" Then
    '        cmbSubMarca.Enabled = False
    '    Else
    '        cmbSubMarca.Enabled = True
    '        cmbSubMarca.SelectedIndex = 1
    '    End If
    'End Sub

    'Private Sub cmbCodMon_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodMon.ValueChanged
    '    lblCodMon.Text = cmbCodMon.Value
    'End Sub

    Private Sub btnAgregarContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarContacto.Click
        Try
            If IdCliente > 0 Then
                Dim frm As New frmServicios_Contactos
                frm.Cliente = IdCliente
                frm.state_button = state_button
                frm.IdCotizacionSer = IdCotizacionSer
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtContacto = frm.dtContacto
                    state = frm.state
                    txtContacto.Text = frm.Concatenado
                    txtReferencia.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtBuscarCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscarCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCliente.Enabled = False Then
                e.Handled = True
                btnBuscarCliente_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub biActualizarOrden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizarOrden.Click
        Try
            Dim frm As New frmServicios_Cotizacion_Orden
            frm.IdCotizacionSer = IdCotizacionSer
            frm.Text = "Agregar orden de compra a la cotización N°" & txtNumCot.Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ObtenerRegistro()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAprobar.Click
        Dim frm As New frmServicios_Cotizacion_Aprobar
        frm.NumCotizacion = txtNumCot.Text
        frm.IdCotizacionSer = IdCotizacionSer
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            ObtenerRegistro()
        End If
    End Sub

    Private Sub txtDescripcion_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescripcion.ButtonClick
        Dim frm As New frmServicios_Cotizacion_ModificarDetalle
        frm.txtDescripcion.Text = toBlank(txtDescripcion.Text)
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtDescripcion.Text = toBlank(frm.txtDescripcion.Text)
        End If
        txtDescripcion.Select()
    End Sub

    Private Sub biActMoneda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActMoneda.Click
        Try
            Dim frm As New frmGuiaRemision_ActualizarMoneda
            frm.IdDoc = IdCotizacionSer
            frm.CodMon = cmbCodMon.Value
            frm.state_button = 6
            frm.NumDoc = txtNumCot.Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ObtenerRegistro()
            End If
        Catch ex As Exception
            MsgBox("Error al Actualizar Moneda : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Dim registro As CotizacionServicioService.CotizacionServicio
        registro = oCotizacionServicioService.Obtener(IdCotizacionSer)
        IdEstado = registro.EstadoCotizacion.IdEstado

        If state_button = True And IdEstado = 1 Then
            NuevoDetalle()
        End If
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim frm As New frmServicios_Cotizacion_Nuevo
            frm.state_button = False
            frm.IdCotizacionSer = IdCotizacionSer
            frm.estado = 1
            frm.IdCliente = IdCliente
            frm.txtItem.Text = toNumber(dgvDatos.GetRow(dgvDatos.RowCount - 1).Cells("Item").Text) + 1
            frm.NumCotizacion = NumCotizacion
            frm.edicion = True
            frm.editable = True
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                ListarCotizacionRepuestos()
                ObtenerRegistro()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdCotizacionDet)
                    mostrarDetalle()
                    actualizarDetalles()
                End If
                enableOpciones()
            End If
            ListarCotizacionRepuestos()
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdCotizacionSerDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oCotizacionServicioDetService.Mostrar(IdCotizacionSer).Tables(0)
            dgvDatos.DataSource = dtDatos
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdCotizacionSerDet").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminarDetalle()
        End If
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
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub eliminarDetalle()

        Try
            cmOpciones.Visible = False

            If dgvDatos.CurrentRow.Cells("IdRubro").Value = 1 Then
                If oCotizacionServicioService.BuscarRepuestos(IdCotizacionSer) = True Then
                    MsgBox("Debe desvincular la cotización de servicios primero", MsgBoxStyle.Information)
                Else
                    If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("Item").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                        Dim estado_process As Boolean
                        estado_process = oCotizacionServicioDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdCotizacionSerDet").Value), toNumber(dgvDatos.CurrentRow.Cells("IdCotizacionSer").Value))
                        If estado_process = True Then
                            dtDatos = Nothing
                            listaDatos()
                            ObtenerRegistro()
                            MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                        Else
                            MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                        End If
                    End If
                End If
            Else
                If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("Item").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oCotizacionServicioDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdCotizacionSerDet").Value), toNumber(dgvDatos.CurrentRow.Cells("IdCotizacionSer").Value))
                    If estado_process = True Then
                        dtDatos = Nothing
                        listaDatos()
                        ObtenerRegistro()
                        MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
        If cmOpciones.Enabled = False Then
        Else
            If ValidaCodigoSeleccionado() Then
                mostrarDetalle()
            End If
        End If
    End Sub

    Private Sub mostrarDetalle()
        Try
            Dim registro As CotizacionServicioService.CotizacionServicio
            registro = oCotizacionServicioService.Obtener(IdCotizacionSer)
            IdEstado = registro.EstadoCotizacion.IdEstado

            Dim frm As New frmServicios_Cotizacion_Nuevo
            frm.state_button = True
            frm.IdCotizacionDet = dgvDatos.CurrentRow.Cells("IdCotizacionSerDet").Text
            frm.IdCotizacionSer = IdCotizacionSer
            frm.NumCotizacion = NumCotizacion
            frm.IdRubro = dgvDatos.CurrentRow.Cells("IdRubro").Text
            frm.IdCliente = IdCliente
            frm.estado = IdEstado
            frm.editable = IIf(IdEstado = 1, True, False)
            frm.edicion = False
            frm.DesRubro = dgvDatos.CurrentRow.Cells("DesRubro").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                ListarCotizacionRepuestos()
                ObtenerRegistro()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdCotizacionDet)
                    '====================== Validar Montos ========================
                    Dim detalle As New CotizacionServicioDetService.CotizacionServicioDet
                    detalle = oCotizacionServicioDetService.Obtener(frm.IdCotizacionDet)
                    If Not (oCotizacionServicioDetService.ObtenerTotalCosto(frm.IdCotizacionDet, frm.IdCotizacionSer) = (detalle.Monto - detalle.MontoDscto)) Then
                        mostrarDetalle()
                    End If
                    actualizarDetalles()
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdCotizacionDet)
            ListarCotizacionRepuestos()
            enableOpciones()
            actualizarDetalles()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If cmOpciones.Enabled = False Then
        Else
            If ValidaCodigoSeleccionado() Then
                mostrarDetalle()
            End If
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        listaDatos()
    End Sub


End Class