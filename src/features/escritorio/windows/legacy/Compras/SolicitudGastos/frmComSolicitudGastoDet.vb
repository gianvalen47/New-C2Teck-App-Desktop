Imports System.ServiceModel
Imports System.IO
Imports System.Xml

Public Class frmComSolicitudGastoDet

    '============================Servicios===================================
    Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient
    Private oSolicitudGastoService As New SolicitudGastoService.SolicitudGastoServiceClient
    Private oProveedorService As New ProveedorService.ProveedorServiceClient
    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oGastoRealService As New GastoRealService.GastoRealServiceClient
    Private oVehiculoService As New VehiculoService.VehiculoServiceClient
    Private Persona As New PersonaService.Persona
    Private oEmbarqueService As New EmbarqueService.EmbarqueServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oReembolsoCajaDetService As New ReembolsoCajaDetService.ReembolsoCajaDetServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable

    Private dtCentrosCosto As DataTable
    Private dtJobs As DataTable
    Private dtMedios As DataTable

    Private dtCondPago As DataTable
    Private dtTipDoc As DataTable
    'Private dtAreas As DataTable
    'Private dtCentroCosto As DataTable    'Se agrega el centro de costo 05/12/2012
    Private dtRubros As DataTable
    Private dtPlaca As DataTable
    Public IdPersonaSolicita As Integer
    Public IdGastoDet As Integer
    Public IdGasto As Integer
    Public IdProveedor As Integer
    Public IdPersona As Integer
    Public estado As Integer
    Public Planilla As Boolean = False                'Variable que evalua si el Detalle de Gasto presenta planillas de viático

    '-------------------------- Agregado el 16/05/2012 Datos de Gasto de Viaje---------------------------
    Private dtRubroViaje As DataTable
    Private dtSubRubroViaje As DataTable
    Private dtDestino As DataTable
    Public GastoViaje As Boolean 'Check Gasto de Viaje de SolicitudGasto (cabecera)
    'Public JobEnable As Boolean 'Habilitar/Deshabilitar Job si es Gasto de Viaje             / Se comenta ya que el Job se ingresa en la cabecera cuando es Gasto de Viaje
    Public DestinoEnable As Boolean 'Habilitar/Deshabilitar Destino si es Gasto de Viaje 
    Public IdDestino As Integer 'primer destino ingresado  que sera repetido en los demas detalles
    '-----------------------------------------------------------------------------------------------------------------------------

    '-------------------------- Agregado el 10/07/2015 Grabar XML , PDF Facturacion Electronica ---------------------------
    'Private DireccionXML As String
    'Private DireccionPFG As String
    Private NombreArchivo As String
    Private DocumentoXml As String = ""
    Private DocumentoPdf As Byte() = Nothing
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    'Public CodArea As String  '---------Agregado el 01/06/2012------(Se comenta quedando que las solicitudes de gasto 
    'que sean Gasto de Viaje y que el Id del Solicitante no sea Jefe se le obliga el ingreso del Nº de Job,de lo contrario no se obliga)
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Moneda As String
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Private dtTipoGasto As DataTable

    Private Sub frmComSolicitudGastoDet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvCentrosCosto)
        dgvCentrosCosto.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        estilo.CargaEstiloGrid(dgvJos)
        dgvJos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        llenarCombos()
        LlenarSubRubroViaje()

        If state_button Then                'Modificar
            Planilla = oSolicitudGastoDetService.BuscarPlanilla(IdGastoDet)
            ObtenerRegistro()
            desactivar()
            gbCentroCosto.Visible = True
            gbJobs.Visible = True
            ActualizarDetallesCentroCosto()
            ActualizarDetallesJob()
            Me.Text = "Solicitud de Gasto Detalle"
            dgvCentrosCosto.Select()

            If GastoViaje = True Then
                'cbComputo.Visible = False
                lblRubro.Visible = False
                cmbRubro.Visible = False
                lblTipoGasto.Visible = False
                cmbTipoGasto.Visible = False

            End If
        Else                                      'Nuevo
            Me.Size = New System.Drawing.Size(674, 477)
            gbCentroCosto.Visible = False
            gbJobs.Visible = False
            Me.Text = "Registrar nuevo Solicitud de Gasto Detalle"
            Activar()
            cbAfectoIgv.Checked = True
            txtCantidad.Focus()
            txtFecDoc.Value = Today
            txtFecDoc.Text = Today
            ObtenerAreaCentroCosto()
            If GastoViaje = True Then
                ObtenerPersonayRubro()
                'cmbDestinoViaje.Value = IdDestino
                'cbComputo.Visible = False
                lblRubro.Visible = False
                cmbRubro.Visible = False
                lblTipoGasto.Visible = False
                cmbTipoGasto.Visible = False

            End If
        End If

    End Sub

    Private Sub frmComSolicitudGastoDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            'If state_button Then
            If cmbTipoGasto.SelectedIndex = 0 And GastoViaje = False Then 'And dgvJos.RowCount > 0 Then
                MsgBox("Debe ingresar el Tipo de Gasto.", MsgBoxStyle.Information, "Información")
                cmbRubro.Focus()
                'If ValidarDetalles() Then  '--- Se comenta a pedido del Sr Carlos Rios 13/05/2015
                'Finalizar()
                'Me.Close()
                'End If
            Else
                Finalizar()
                Me.Close()
            End If
        End If
    End Sub

    'Private Sub frmComSolicitudGastoDet_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '    If ValidarDetalles() Then
    '        Finalizar()
    '    End If
    'End Sub

    Private Sub Finalizar()
        Try
            oSolicitudGastoDetService.Close()
            oSolicitudGastoService.Close()
            oProveedorService.Close()
            oOrdenesCompraService.Close()
            oJobService.Close()
            oPersonaService.Close()
            oGastoRealService.Close()
            oVehiculoService.Close()
            oEmbarqueService.Close()
            oReembolsoCajaDetService.close()
        Catch ex As TimeoutException
            oSolicitudGastoDetService.Abort()
            oSolicitudGastoService.Abort()
            oProveedorService.Abort()
            oOrdenesCompraService.Abort()
            oJobService.Abort()
            oPersonaService.Abort()
            oGastoRealService.Abort()
            oVehiculoService.Abort()
            oEmbarqueService.Abort()
            oReembolsoCajaDetService.Abort()
        Catch ex As CommunicationException
            oSolicitudGastoDetService.Abort()
            oSolicitudGastoService.Abort()
            oProveedorService.Abort()
            oOrdenesCompraService.Abort()
            oJobService.Abort()
            oPersonaService.Abort()
            oGastoRealService.Abort()
            oVehiculoService.Abort()
            oEmbarqueService.Abort()
            oReembolsoCajaDetService.Abort()
        End Try
    End Sub

    Private Sub RowPossesionCentroCosto(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If toBlank(row.Cells("CodCentro").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS] CENTRO COSTO: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub RowPossesionJob(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If toBlank(row.Cells("CodJob").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS] JOB: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Ninguno)"
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
            fila(3) = 0
        End Try
        Return fila
    End Function

    Private Function getRowTodos1(ByVal data As DataTable)
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
            fila(3) = 0
        End Try
        Return fila
    End Function

    Private Sub llenarCombos()
        Try

            '================================CONDICION DE PAGO PROVEEDOR===================================
            dtCondPago = oProveedorService.MostrarCondicionPago.Tables(0)
            dtCondPago.Rows.InsertAt(getRowTodos(dtCondPago), 0)
            cmbCondPago.DataSource = dtCondPago
            cmbCondPago.DropDownList.DataMember = dtCondPago.Columns("NomCondicion").ToString
            cmbCondPago.DropDownList.DisplayMember = dtCondPago.Columns("NomCondicion").ToString
            cmbCondPago.DropDownList.ValueMember = dtCondPago.Columns("IdCondicion").ToString
            cmbCondPago.DropDownList.Columns(0).DataMember = dtCondPago.Columns("IdCondicion").ToString
            cmbCondPago.DropDownList.Columns(1).DataMember = dtCondPago.Columns("NomCondicion").ToString
            cmbCondPago.DropDownList.Columns(2).DataMember = dtCondPago.Columns("DiasPago").ToString
            cmbCondPago.SelectedIndex = 0
            dtCondPago = Nothing

            ''===================================== TIPO DE DOCUMENTO=========================================
            dtTipDoc = oOrdenesCompraService.MostrarTipoDocumentoCompras().Tables(0)
            dtTipDoc.Rows.InsertAt(getRowTodos(dtTipDoc), 0)
            cmbTipoDoc.DataSource = dtTipDoc
            cmbTipoDoc.DropDownList.DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.DisplayMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.ValueMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(0).DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(1).DataMember = dtTipDoc.Columns("CodSunat").ToString
            cmbTipoDoc.DropDownList.Columns(2).DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.Columns(3).DataMember = dtTipDoc.Columns("AplicaIgv").ToString
            cmbTipoDoc.SelectedIndex = 0
            dtTipDoc = Nothing

            ''========================================== AREAS ===============================================
            'dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            'cmbArea.DataSource = dtAreas
            'cmbArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            'cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            'cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            'cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            'cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            'dtAreas = Nothing

          

            '//////////////////////////////////////////////////////////////////Agregado el 17/05/2012 (Gasto de Viaje)/////////////////////////////////////////////////////////////////////
            '======================================= RUBRO VIAJE ==============================================
            dtRubroViaje = oSolicitudGastoDetService.MostrarRubroViaje.Tables(0)
            dtRubroViaje.Rows.InsertAt(getRowTodos(dtRubroViaje), 0)
            cmbRubroViaje.DataSource = dtRubroViaje
            cmbRubroViaje.DropDownList.DataMember = dtRubroViaje.Columns("DesRubro").ToString
            cmbRubroViaje.DropDownList.DisplayMember = dtRubroViaje.Columns("DesRubro").ToString
            cmbRubroViaje.DropDownList.ValueMember = dtRubroViaje.Columns("IdRubro").ToString
            cmbRubroViaje.DropDownList.Columns(0).DataMember = dtRubroViaje.Columns("IdRubro").ToString
            cmbRubroViaje.DropDownList.Columns(1).DataMember = dtRubroViaje.Columns("DesRubro").ToString
            cmbRubroViaje.SelectedIndex = 0
            dtRubroViaje = Nothing

            ''======================================= DESTINOS ==============================================
            'dtDestino = oSolicitudGastoDetService.MostrarDestinos.Tables(0)
            'dtDestino.Rows.InsertAt(getRowTodos(dtDestino), 0)
            'cmbDestinoViaje.DataSource = dtDestino
            'cmbDestinoViaje.DropDownList.DataMember = dtDestino.Columns("DesDestino").ToString
            'cmbDestinoViaje.DropDownList.DisplayMember = dtDestino.Columns("DesDestino").ToString
            'cmbDestinoViaje.DropDownList.ValueMember = dtDestino.Columns("IdDestino").ToString
            'cmbDestinoViaje.DropDownList.Columns(0).DataMember = dtDestino.Columns("IdDestino").ToString
            'cmbDestinoViaje.DropDownList.Columns(1).DataMember = dtDestino.Columns("DesDestino").ToString
            'cmbDestinoViaje.SelectedIndex = 0
            'dtDestino = Nothing

            '========================================== PLACA ===============================================
            dtPlaca = oVehiculoService.MostrarUnidades.Tables(0)
            dtPlaca.Rows.InsertAt(getRowTodos(dtPlaca), 0)
            cmbPlaca.DataSource = dtPlaca
            cmbPlaca.DropDownList.DataMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.DisplayMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.ValueMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.Columns(0).DataMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.Columns(1).DataMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.SelectedIndex = 0
            dtPlaca = Nothing
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            '======================================= MEDIOS ================================================
            dtMedios = New DataTable
            dtMedios.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtMedios.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtMedios.Rows.Add(New Object() {"", ""})
            dtMedios.Rows.Add(New Object() {"A", "Aéreo"}) ', New DateTime(2008, 2, 5)
            dtMedios.Rows.Add(New Object() {"M", "Marinos"})
            dtMedios.Rows.Add(New Object() {"O", "Otros"})

            cmbMedio.DataSource = dtMedios
            cmbMedio.DropDownList.DataMember = dtMedios.Columns("nombre").ToString
            cmbMedio.DropDownList.DisplayMember = dtMedios.Columns("nombre").ToString
            cmbMedio.DropDownList.ValueMember = dtMedios.Columns("codigo").ToString
            cmbMedio.DropDownList.Columns(0).DataMember = dtMedios.Columns("codigo").ToString
            cmbMedio.DropDownList.Columns(1).DataMember = dtMedios.Columns("nombre").ToString
            cmbMedio.SelectedIndex = 0
            dtMedios = Nothing

            ''===================================== TIPO DE GASTO ============================================
            dtTipoGasto = oReembolsoCajaDetService.MostrarTipoGasto().Tables(0)
            dtTipoGasto.Rows.InsertAt(getRowTodos(dtTipoGasto), 0)
            cmbTipoGasto.DataSource = dtTipoGasto
            cmbTipoGasto.DropDownList.DataMember = dtTipoGasto.Columns("DesTipo").ToString
            cmbTipoGasto.DropDownList.DisplayMember = dtTipoGasto.Columns("DesTipo").ToString
            cmbTipoGasto.DropDownList.ValueMember = dtTipoGasto.Columns("IdTipoGasto").ToString
            cmbTipoGasto.DropDownList.Columns(0).DataMember = dtTipoGasto.Columns("IdTipoGasto").ToString
            cmbTipoGasto.DropDownList.Columns(1).DataMember = dtTipoGasto.Columns("DesTipo").ToString
            cmbTipoGasto.DropDownList.Columns(2).DataMember = dtTipoGasto.Columns("Observacion").ToString
            cmbTipoGasto.SelectedIndex = 0
            dtTipoGasto = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    ''//////////////////////////////////////////////////////////////////Agregado el 05/12/2012 (Contabilidad)/////////////////////////////////////////////////////////////////////
    'Private Sub cmbArea_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        'If cmbArea.Value <> "" Then
    '        '====================================== CENTRO COSTO ===========================================
    '        dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbArea.Value, "").Tables(0)
    '        'dtCentroCosto.Rows.InsertAt(getRowTodos(dtCentroCosto), 0)
    '        cmbCentroCosto.DataSource = dtCentroCosto
    '        cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
    '        cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
    '        cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
    '        cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
    '        cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString
    '        'If cmbArea.Value <> "" Then
    '        '    cmbCentroCosto.SelectedIndex = 1
    '        'Else
    '        cmbCentroCosto.SelectedIndex = 0
    '        'End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    '////////////////////////////////////////////////////////////////// Agregado el 17/05/2012 (Gasto de Viaje) /////////////////////////////////////////////////////////////////////

    Private Sub LlenarSubRubroViaje()
        Try
            '======================================= SUBRUBRO VIAJE =============================================
            If cmbRubroViaje.SelectedIndex <> 0 Then
                dtSubRubroViaje = oSolicitudGastoDetService.MostrarSubRubroViaje(cmbRubroViaje.Value, IdDestino).Tables(0)
                dtSubRubroViaje.Rows.InsertAt(getRowTodos(dtSubRubroViaje), 0)
                cmbSubRubroViaje.DataSource = dtSubRubroViaje
                cmbSubRubroViaje.DropDownList.DataMember = dtSubRubroViaje.Columns("DesSubRubro").ToString
                cmbSubRubroViaje.DropDownList.DisplayMember = dtSubRubroViaje.Columns("DesSubRubro").ToString
                cmbSubRubroViaje.DropDownList.ValueMember = dtSubRubroViaje.Columns("IdSubRubro").ToString
                cmbSubRubroViaje.DropDownList.Columns(0).DataMember = dtSubRubroViaje.Columns("IdSubRubro").ToString
                cmbSubRubroViaje.DropDownList.Columns(1).DataMember = dtSubRubroViaje.Columns("DesSubRubro").ToString
                cmbSubRubroViaje.DropDownList.Columns(2).DataMember = dtSubRubroViaje.Columns("Observacion").ToString
                'cmbSubRubroViaje.SelectedIndex = 0
                dtSubRubroViaje = Nothing
            Else
                dtSubRubroViaje = oSolicitudGastoDetService.MostrarSubRubroViaje(cmbRubroViaje.Value, IdDestino).Tables(0)
                dtSubRubroViaje.Rows.InsertAt(getRowTodos(dtSubRubroViaje), 0)
                cmbSubRubroViaje.DataSource = dtSubRubroViaje
                cmbSubRubroViaje.SelectedIndex = 0
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBO SUBRUBRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvCentrosCosto.RowCount < 1 Then
            miMostrarCentroCosto.Enabled = False
        Else
            miMostrarCentroCosto.Enabled = True
        End If

        If dgvJos.RowCount < 1 Then
            miMostrarJob.Enabled = False
            miEliminarJob.Enabled = False
            'miProcesarJob.Enabled = False
            miMostrarCompras.Enabled = False
        Else
            Dim iProcesoJob As Boolean
            iProcesoJob = toBoolean(dgvJos.CurrentRow.Cells("ProcesoJob2").Value)
            miMostrarJob.Enabled = True
            miEliminarJob.Enabled = IIf(Not edicion And editable And Planilla = False And GastoViaje = False And estado = 1, True, False)
            'miProcesarJob.Enabled = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "24") And (estado = 3 Or estado = 5), True, False)
            miMostrarCompras.Enabled = True

            dgvJos.RootTable.Columns("ProcesoJob").Visible = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "24") And (estado = 3 Or estado = 5 Or estado = 7 Or estado = 10), True, False)
            dgvJos.RootTable.Columns("CodJob").Width = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "24") And (estado = 3 Or estado = 5 Or estado = 7 Or estado = 10), "67", "88")
        End If

        miAsignarCentroCosto.Enabled = IIf(Not edicion And editable And Planilla = False And GastoViaje = False And (estado = 1 Or ((estado = 3 Or estado = 5) And (Session.CodPerfil = "22" Or Session.CodPerfil = "01" Or Session.CodPerfil = "11" Or Session.CodPerfil = "05"))), True, False) 'Se agrega el perfiles Solicitud de Usuario 65887,65888
        miAsignarJobs.Enabled = IIf(Not edicion And editable And Planilla = False And GastoViaje = False And (estado = 1 Or ((estado = 3 Or estado = 5) And (Session.CodPerfil = "22" Or Session.CodPerfil = "01" Or Session.CodPerfil = "11" Or Session.CodPerfil = "05"))), True, False) 'Se agrega el perfiles Solicitud de Usuario 65887,65888

        biEditar.Enabled = IIf(editable, Not edicion, False)
        biCerrar.Enabled = Not edicion
        biGuardar.Enabled = edicion
        biDeshacer.Enabled = edicion
        cmOpcionesCentrosCosto.Enabled = IIf(Not edicion, True, False)
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCentrosCosto.SelectionChanged, dgvJos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub Activar()
        Try
            dtRubros = oSolicitudGastoDetService.MostrarRubros(cmbTipoGasto.Value).Tables(0)
            If state_button Then    '////////////////////////////////////////////////// ACTUALIZAR ////////////////////////////////////////////////////////////

                If estado = 1 Then      '===========================  GENERADO==========================
                    '=======SE VALIDA SI EL DETALLE DE GASTO PRESENTA PLANILLAS======
                    '(Se inhabilita todos los campos a exepción de Cantidad, Descripción y Justificación)
                    If Planilla = True Then
                        txtCodCuenta.ReadOnly = True
                        txtCodCuenta.BackColor = System.Drawing.SystemColors.Control
                        txtCantidad.ReadOnly = False
                        txtCantidad.BackColor = System.Drawing.SystemColors.Window
                        cmbTipoGasto.ReadOnly = True
                        cmbTipoGasto.BackColor = System.Drawing.SystemColors.Control
                        'cbComputo.Enabled = IIf(dtRubros.Rows.Count > 0, True, False)
                        'txtNumJob.ReadOnly = True
                        'txtNumJob.BackColor = System.Drawing.SystemColors.Control
                        'btnBuscarJob.Enabled = False

                        cmbRubro.ReadOnly = True
                        cmbRubro.BackColor = System.Drawing.SystemColors.Control

                        cbAfectoIgv.Enabled = False
                        txtMonto.ReadOnly = True
                        txtMonto.BackColor = System.Drawing.SystemColors.Control
                        txtMontoNoAfecto.ReadOnly = True
                        txtMontoNoAfecto.BackColor = System.Drawing.SystemColors.Control
                        txtDescripcion.ReadOnly = False
                        txtDescripcion.BackColor = System.Drawing.SystemColors.Window
                        btnBuscarProveedor.Enabled = False
                        btnAgregarProveedor.Enabled = False
                        btnLimpiarProveedor.Enabled = False
                        cmbCondPago.ReadOnly = True
                        cmbCondPago.BackColor = System.Drawing.SystemColors.Control

                        cbAplicaCosto.Enabled = False

                        cmbTipoDoc.ReadOnly = True
                        cmbTipoDoc.BackColor = System.Drawing.SystemColors.Control
                        txtNumDoc.ReadOnly = True
                        txtNumDoc.BackColor = System.Drawing.SystemColors.Control
                        txtSerieDoc.ReadOnly = True
                        txtSerieDoc.BackColor = System.Drawing.SystemColors.Control
                        txtFecDoc.ReadOnly = True
                        txtFecDoc.BackColor = System.Drawing.SystemColors.Control
                        txtJustificacion.ReadOnly = False
                        txtJustificacion.BackColor = System.Drawing.SystemColors.Window
                        cmbPlaca.ReadOnly = True
                        cmbPlaca.BackColor = System.Drawing.SystemColors.Control
                        cbNoAplicaPolitica.Checked = False
                        cbNoAplicaPolitica.Enabled = False
                        'cmbDestinoViaje.ReadOnly = True
                        'cmbDestinoViaje.BackColor = System.Drawing.SystemColors.Control
                        cmbRubroViaje.ReadOnly = True
                        cmbRubroViaje.BackColor = System.Drawing.SystemColors.Control
                        cmbSubRubroViaje.ReadOnly = True
                        cmbSubRubroViaje.BackColor = System.Drawing.SystemColors.Control
                        btnBuscarPersona.Enabled = False
                        btnBuscarXml.Enabled = False
                        btnBuscarPdf.Enabled = False
                        biLimpiarXml.Enabled = False
                        biLimpiarPdf.Enabled = False

                        txtCodEmbarque.ReadOnly = True
                        txtCodEmbarque.BackColor = System.Drawing.SystemColors.Control

                        ' ''cmbArea.ReadOnly = True
                        ' ''cmbArea.BackColor = System.Drawing.SystemColors.Control
                        ' ''cmbCentroCosto.ReadOnly = True
                        ' ''cmbCentroCosto.BackColor = System.Drawing.SystemColors.Control
                        '======================= DIFERENTE DE PLANILLA =========================
                    Else
                        txtCodCuenta.ReadOnly = True
                        txtCodCuenta.BackColor = System.Drawing.SystemColors.Control
                        txtCantidad.ReadOnly = False
                        txtCantidad.BackColor = System.Drawing.SystemColors.Window
                       
                        'If JobEnable = True Then
                        '    txtNumJob.ReadOnly = False
                        '    txtNumJob.BackColor = System.Drawing.SystemColors.Window
                        '    btnBuscarJob.Enabled = True
                        'Else
                        '    txtNumJob.ReadOnly = True
                        '    txtNumJob.BackColor = System.Drawing.SystemColors.Control
                        '    btnBuscarJob.Enabled = False
                        'End If
                        If GastoViaje = True Then
                            cmbTipoGasto.ReadOnly = True
                            cmbTipoGasto.BackColor = System.Drawing.SystemColors.Control
                            'cbComputo.Enabled = False
                            cmbRubro.ReadOnly = True
                            cmbRubro.BackColor = System.Drawing.SystemColors.Control
                        Else
                            cmbTipoGasto.ReadOnly = False
                            cmbTipoGasto.BackColor = System.Drawing.SystemColors.Window
                            'cbComputo.Enabled = IIf(dtRubros.Rows.Count > 0, True, False)
                            cmbRubro.ReadOnly = False
                            cmbRubro.BackColor = System.Drawing.SystemColors.Window
                        End If
                        cbAfectoIgv.Enabled = True
                        txtMonto.ReadOnly = False
                        txtMonto.BackColor = System.Drawing.SystemColors.Window
                        txtMontoNoAfecto.ReadOnly = False
                        txtMontoNoAfecto.BackColor = System.Drawing.SystemColors.Window
                        txtDescripcion.ReadOnly = False
                        txtDescripcion.BackColor = System.Drawing.SystemColors.Window
                        btnBuscarProveedor.Enabled = True
                        btnAgregarProveedor.Enabled = True
                        btnLimpiarProveedor.Enabled = True 'Agregado el 20/09/2012
                        cmbCondPago.ReadOnly = False
                        cmbCondPago.BackColor = System.Drawing.SystemColors.Window

                        cbAplicaCosto.Enabled = False

                        cmbTipoDoc.ReadOnly = False
                        cmbTipoDoc.BackColor = System.Drawing.SystemColors.Window
                        txtNumDoc.ReadOnly = False
                        txtNumDoc.BackColor = System.Drawing.SystemColors.Window
                        txtSerieDoc.ReadOnly = False
                        txtSerieDoc.BackColor = System.Drawing.SystemColors.Window
                        txtFecDoc.ReadOnly = False
                        txtFecDoc.BackColor = System.Drawing.SystemColors.Window
                        txtJustificacion.ReadOnly = False
                        txtJustificacion.BackColor = System.Drawing.SystemColors.Window
                        btnBuscarXml.Enabled = True
                        btnBuscarPdf.Enabled = True
                        biLimpiarXml.Enabled = True
                        biLimpiarPdf.Enabled = True

                        '================= Sr. Pacolo (Solicitud 3728) ==================
                        '----------------------------- Agregado el 14/06/2012 (Sr Pacolo) ----------------------------
                        cmbPlaca.ReadOnly = False
                        cmbPlaca.BackColor = System.Drawing.SystemColors.Window
                        '----------------------------------------------------------------------------------------------------------------
                        '========================================================

                        '--------------------------Agregado el 16/05/2012 (Gasto de Viaje)---------------------------
                        If GastoViaje = True Then
                            If oSolicitudGastoDetService.BuscarJefe(IdPersonaSolicita) Then
                                cbNoAplicaPolitica.Checked = True
                                cbNoAplicaPolitica.Enabled = False
                            Else
                                cbNoAplicaPolitica.Enabled = True
                            End If
                            'If DestinoEnable = True Then
                            '    cmbDestinoViaje.ReadOnly = False
                            '    cmbDestinoViaje.BackColor = System.Drawing.SystemColors.Window
                            'Else
                            '    cmbDestinoViaje.ReadOnly = True
                            '    cmbDestinoViaje.BackColor = System.Drawing.SystemColors.Control
                            'End If
                            cmbRubroViaje.ReadOnly = False
                            cmbRubroViaje.BackColor = System.Drawing.SystemColors.Window
                            cmbSubRubroViaje.ReadOnly = False
                            cmbSubRubroViaje.BackColor = System.Drawing.SystemColors.Window
                            btnBuscarPersona.Enabled = False

                            txtCodEmbarque.ReadOnly = True
                            txtCodEmbarque.BackColor = System.Drawing.SystemColors.Control

                            ' ''cmbArea.ReadOnly = True
                            ' ''cmbArea.BackColor = System.Drawing.SystemColors.Control
                            ' ''cmbCentroCosto.ReadOnly = True
                            ' ''cmbCentroCosto.BackColor = System.Drawing.SystemColors.Control
                        Else
                            cbNoAplicaPolitica.Checked = False
                            cbNoAplicaPolitica.Enabled = False
                            'cmbDestinoViaje.ReadOnly = True
                            'cmbDestinoViaje.BackColor = System.Drawing.SystemColors.Control
                            cmbRubroViaje.ReadOnly = True
                            cmbRubroViaje.BackColor = System.Drawing.SystemColors.Control
                            cmbSubRubroViaje.ReadOnly = True
                            cmbSubRubroViaje.BackColor = System.Drawing.SystemColors.Control
                            btnBuscarPersona.Enabled = True

                            txtCodEmbarque.ReadOnly = False
                            txtCodEmbarque.BackColor = System.Drawing.SystemColors.Window

                            ' ''cmbArea.ReadOnly = False
                            ' ''cmbArea.BackColor = System.Drawing.SystemColors.Window
                            ' ''cmbCentroCosto.ReadOnly = False
                            ' ''cmbCentroCosto.BackColor = System.Drawing.SystemColors.Window
                        End If
                        '----------------------------------------------------------------------------------------------------------------
                    End If

                Else      '=========================== <> GENERADO==========================
                    txtCodCuenta.ReadOnly = True
                    txtCodCuenta.BackColor = System.Drawing.SystemColors.Control
                    txtCantidad.ReadOnly = True
                    txtCantidad.BackColor = System.Drawing.SystemColors.Control
                    'txtNumJob.ReadOnly = True
                    'txtNumJob.BackColor = System.Drawing.SystemColors.Control
                    'btnBuscarJob.Enabled = False                   
                    btnBuscarPersona.Enabled = False

                    txtCodEmbarque.ReadOnly = True
                    txtCodEmbarque.BackColor = System.Drawing.SystemColors.Control

                    '================= Sr. Pacolo (Solicitud 3728) ==================
                    cmbPlaca.ReadOnly = True
                    cmbPlaca.BackColor = System.Drawing.SystemColors.Control
                    '========================================================

                    If (estado = 2 Or estado = 3 Or (estado = 5 And (Session.CodPerfil = "22" Or Session.CodPerfil = "01" Or Session.CodPerfil = "11" Or Session.CodPerfil = "05"))) Then 'Se agrega el perfiles Solicitud de Usuario 65887,65888
                        'And Planilla = False Then 'ESTADO( APROBADO POR JEFE DE AREA O APROBADO) Se activa los detalles tipo Planilla para la edición de Observación Contable (Sr. Jesus Alba 03/08/2015)
                        cbAfectoIgv.Enabled = True
                        btnAgregarProveedor.Enabled = True
                        btnBuscarProveedor.Enabled = True
                        btnLimpiarProveedor.Enabled = True  'Agregado el 20/09/2012
                        cmbCondPago.ReadOnly = False
                        cmbCondPago.BackColor = System.Drawing.SystemColors.Window

                        cbAplicaCosto.Enabled = False

                        cmbTipoDoc.ReadOnly = False
                        cmbTipoDoc.BackColor = System.Drawing.SystemColors.Window
                        txtNumDoc.ReadOnly = False
                        txtNumDoc.BackColor = System.Drawing.SystemColors.Window
                        txtSerieDoc.ReadOnly = False
                        txtSerieDoc.BackColor = System.Drawing.SystemColors.Window
                        txtFecDoc.ReadOnly = False
                        txtFecDoc.BackColor = System.Drawing.SystemColors.Window
                        btnBuscarXml.Enabled = True
                        btnBuscarPdf.Enabled = True

                        If Session.CodPerfil = "22" Or Session.CodPerfil = "01" Or Session.CodPerfil = "11" Or Session.CodPerfil = "05" Then 'Se agrega el perfiles Solicitud de Usuario 65887,65888
                            txtMonto.ReadOnly = False
                            txtMonto.BackColor = System.Drawing.SystemColors.Window
                            txtMontoNoAfecto.ReadOnly = False
                            txtMontoNoAfecto.BackColor = System.Drawing.SystemColors.Window
                            txtDescripcion.ReadOnly = False
                            txtDescripcion.BackColor = System.Drawing.SystemColors.Window
                            txtJustificacion.ReadOnly = False
                            txtJustificacion.BackColor = System.Drawing.SystemColors.Window
                            cmbTipoGasto.ReadOnly = False
                            cmbTipoGasto.BackColor = System.Drawing.SystemColors.Window
                            cmbRubro.ReadOnly = False
                            cmbRubro.BackColor = System.Drawing.SystemColors.Window
                            'cbComputo.Enabled = IIf(dtRubros.Rows.Count > 0, True, False)

                        Else
                            txtMonto.ReadOnly = True
                            txtMonto.BackColor = System.Drawing.SystemColors.Control
                            txtMontoNoAfecto.ReadOnly = True
                            txtMontoNoAfecto.BackColor = System.Drawing.SystemColors.Control
                            txtDescripcion.ReadOnly = True
                            txtDescripcion.BackColor = System.Drawing.SystemColors.Control
                            txtJustificacion.ReadOnly = True
                            txtJustificacion.BackColor = System.Drawing.SystemColors.Control
                            cmbTipoGasto.ReadOnly = True
                            cmbTipoGasto.BackColor = System.Drawing.SystemColors.Control
                            cmbRubro.ReadOnly = True
                            cmbRubro.BackColor = System.Drawing.SystemColors.Control
                            'cbComputo.Enabled = IIf(dtRubros.Rows.Count > 0, True, False)
                        End If

                        ' ''cmbArea.ReadOnly = True
                        ' ''cmbArea.BackColor = System.Drawing.SystemColors.Control
                        ' ''cmbCentroCosto.ReadOnly = True
                        ' ''cmbCentroCosto.BackColor = System.Drawing.SystemColors.Control

                    Else     'ESTADO <> GENERADO, APROBADO POR JEFE DE AREA Y APROBADO
                        cbAfectoIgv.Enabled = False
                        btnAgregarProveedor.Enabled = False
                        btnBuscarProveedor.Enabled = False
                        btnLimpiarProveedor.Enabled = False    'Agregado el 20/09/2012
                        cmbCondPago.ReadOnly = True
                        cmbCondPago.BackColor = System.Drawing.SystemColors.Control

                        cbAplicaCosto.Enabled = False

                        cmbTipoDoc.ReadOnly = True
                        cmbTipoDoc.BackColor = System.Drawing.SystemColors.Control
                        txtNumDoc.ReadOnly = True
                        txtNumDoc.BackColor = System.Drawing.SystemColors.Control
                        txtSerieDoc.ReadOnly = True
                        txtSerieDoc.BackColor = System.Drawing.SystemColors.Control
                        txtFecDoc.ReadOnly = True
                        txtFecDoc.BackColor = System.Drawing.SystemColors.Control
                        btnBuscarXml.Enabled = False
                        btnBuscarPdf.Enabled = False
                        biLimpiarXml.Enabled = False
                        biLimpiarPdf.Enabled = False

                        txtMonto.ReadOnly = True
                        txtMonto.BackColor = System.Drawing.SystemColors.Control
                        txtMontoNoAfecto.ReadOnly = True
                        txtMontoNoAfecto.BackColor = System.Drawing.SystemColors.Control
                        '--------------------------Agregado el 28/05/2012 (Gasto de Viaje)----------------------------
                        ' ''cmbArea.ReadOnly = True
                        ' ''cmbArea.BackColor = System.Drawing.SystemColors.Control
                        ' ''cmbCentroCosto.ReadOnly = True
                        ' ''cmbCentroCosto.BackColor = System.Drawing.SystemColors.Control
                        '-------------------------------------------------------------------------------------------------------------
                    End If
                    '--------------------------Agregado el 16/05/2012 (Gasto de Viaje)----------------------------
                    cbNoAplicaPolitica.Enabled = False
                    'cmbDestinoViaje.ReadOnly = True
                    'cmbDestinoViaje.BackColor = System.Drawing.SystemColors.Control
                    cmbRubroViaje.ReadOnly = True
                    cmbRubroViaje.BackColor = System.Drawing.SystemColors.Control
                    cmbSubRubroViaje.ReadOnly = True
                    cmbSubRubroViaje.BackColor = System.Drawing.SystemColors.Control
                    '------------------------------------------------------------------------------------------------------------------
                End If

                edicion = True
                enableOpciones()
                txtCantidad.Focus()

            Else  '////////////////////////////////////////////////// NUEVO ////////////////////////////////////////////////////////////
                If Planilla = True Then
                    txtCodCuenta.ReadOnly = True
                    txtCodCuenta.BackColor = System.Drawing.SystemColors.Control
                    txtCantidad.ReadOnly = False
                    txtCantidad.BackColor = System.Drawing.SystemColors.Window
                    'txtNumJob.ReadOnly = True
                    'txtNumJob.BackColor = System.Drawing.SystemColors.Control
                    'btnBuscarJob.Enabled = False
                    cmbTipoGasto.ReadOnly = True
                    cmbTipoGasto.BackColor = System.Drawing.SystemColors.Control
                    cmbRubro.ReadOnly = True
                    cmbRubro.BackColor = System.Drawing.SystemColors.Control
                    'cbComputo.Enabled = IIf(dtRubros.Rows.Count > 0, True, False)
                    
                    cbAfectoIgv.Enabled = False
                    txtMonto.ReadOnly = True
                    txtMonto.BackColor = System.Drawing.SystemColors.Control
                    txtMontoNoAfecto.ReadOnly = True
                    txtMontoNoAfecto.BackColor = System.Drawing.SystemColors.Control
                    txtDescripcion.ReadOnly = False
                    txtDescripcion.BackColor = System.Drawing.SystemColors.Window
                    btnBuscarProveedor.Enabled = False
                    btnAgregarProveedor.Enabled = False
                    btnLimpiarProveedor.Enabled = False
                    cmbCondPago.ReadOnly = True
                    cmbCondPago.BackColor = System.Drawing.SystemColors.Control

                    cbAplicaCosto.Enabled = False

                    cmbTipoDoc.ReadOnly = True
                    cmbTipoDoc.BackColor = System.Drawing.SystemColors.Control
                    txtNumDoc.ReadOnly = True
                    txtNumDoc.BackColor = System.Drawing.SystemColors.Control
                    txtSerieDoc.ReadOnly = True
                    txtSerieDoc.BackColor = System.Drawing.SystemColors.Control
                    txtFecDoc.ReadOnly = True
                    txtFecDoc.BackColor = System.Drawing.SystemColors.Control
                    txtJustificacion.ReadOnly = False
                    txtJustificacion.BackColor = System.Drawing.SystemColors.Window
                    cmbPlaca.ReadOnly = True
                    cmbPlaca.BackColor = System.Drawing.SystemColors.Control
                    cbNoAplicaPolitica.Checked = False
                    cbNoAplicaPolitica.Enabled = False
                    'cmbDestinoViaje.ReadOnly = True
                    'cmbDestinoViaje.BackColor = System.Drawing.SystemColors.Control
                    cmbRubroViaje.ReadOnly = True
                    cmbRubroViaje.BackColor = System.Drawing.SystemColors.Control
                    cmbSubRubroViaje.ReadOnly = True
                    cmbSubRubroViaje.BackColor = System.Drawing.SystemColors.Control
                    btnBuscarPersona.Enabled = True
                    btnBuscarXml.Enabled = False
                    btnBuscarPdf.Enabled = False
                    biLimpiarXml.Enabled = False
                    biLimpiarPdf.Enabled = False
                    txtCodEmbarque.ReadOnly = True
                    txtCodEmbarque.BackColor = System.Drawing.SystemColors.Control

                    ' ''cmbArea.ReadOnly = True
                    ' ''cmbArea.BackColor = System.Drawing.SystemColors.Control
                    ' ''cmbCentroCosto.ReadOnly = True
                    ' ''cmbCentroCosto.BackColor = System.Drawing.SystemColors.Control

                    '======================= DIFERENTE DE PLANILLA =========================
                Else
                    txtCodCuenta.ReadOnly = True
                    txtCodCuenta.BackColor = System.Drawing.SystemColors.Control
                    txtCantidad.ReadOnly = False
                    txtCantidad.BackColor = System.Drawing.SystemColors.Window
                    'If JobEnable = True Then
                    '    txtNumJob.ReadOnly = False
                    '    txtNumJob.BackColor = System.Drawing.SystemColors.Window
                    '    btnBuscarJob.Enabled = True
                    'Else
                    '    txtNumJob.ReadOnly = True
                    '    txtNumJob.BackColor = System.Drawing.SystemColors.Control
                    '    btnBuscarJob.Enabled = False
                    'End If
                    If GastoViaje = True Then
                        cmbTipoGasto.ReadOnly = True
                        cmbTipoGasto.BackColor = System.Drawing.SystemColors.Control
                        'cbComputo.Enabled = False
                        cmbRubro.ReadOnly = True
                        cmbRubro.BackColor = System.Drawing.SystemColors.Control
                    Else
                        cmbTipoGasto.ReadOnly = False
                        cmbTipoGasto.BackColor = System.Drawing.SystemColors.Window
                        'cbComputo.Enabled = IIf(dtRubros.Rows.Count > 0, True, False)
                        cmbRubro.ReadOnly = False
                        cmbRubro.BackColor = System.Drawing.SystemColors.Window
                    End If
                    cbAfectoIgv.Enabled = True
                    txtMonto.ReadOnly = False
                    txtMonto.BackColor = System.Drawing.SystemColors.Window
                    txtMontoNoAfecto.ReadOnly = False
                    txtMontoNoAfecto.BackColor = System.Drawing.SystemColors.Window
                    txtDescripcion.ReadOnly = False
                    txtDescripcion.BackColor = System.Drawing.SystemColors.Window
                    btnBuscarProveedor.Enabled = True
                    btnAgregarProveedor.Enabled = True
                    btnLimpiarProveedor.Enabled = True 'Agregado el 20/09/2012
                    cmbCondPago.ReadOnly = False
                    cmbCondPago.BackColor = System.Drawing.SystemColors.Window

                    cbAplicaCosto.Enabled = True

                    cmbTipoDoc.ReadOnly = False
                    cmbTipoDoc.BackColor = System.Drawing.SystemColors.Window
                    txtNumDoc.ReadOnly = False
                    txtNumDoc.BackColor = System.Drawing.SystemColors.Window
                    txtSerieDoc.ReadOnly = False
                    txtSerieDoc.BackColor = System.Drawing.SystemColors.Window
                    txtFecDoc.ReadOnly = False
                    txtFecDoc.BackColor = System.Drawing.SystemColors.Window
                    txtJustificacion.ReadOnly = False
                    txtJustificacion.BackColor = System.Drawing.SystemColors.Window
                    btnBuscarXml.Enabled = True
                    btnBuscarPdf.Enabled = True
                    biLimpiarXml.Enabled = True
                    biLimpiarPdf.Enabled = True
                    '================= Sr. Pacolo (Solicitud 3728) ==================
                    '----------------------------- Agregado el 14/06/2012 (Sr Pacolo) ----------------------------
                    cmbPlaca.ReadOnly = False
                    cmbPlaca.BackColor = System.Drawing.SystemColors.Window
                    '----------------------------------------------------------------------------------------------------------------
                    '========================================================

                    '--------------------------Agregado el 16/05/2012 (Gasto de Viaje)---------------------------
                    If GastoViaje = True Then
                        If oSolicitudGastoDetService.BuscarJefe(IdPersonaSolicita) Then
                            cbNoAplicaPolitica.Checked = True
                            cbNoAplicaPolitica.Enabled = False
                        Else
                            cbNoAplicaPolitica.Enabled = True
                        End If
                        'If DestinoEnable = True Then
                        '    cmbDestinoViaje.ReadOnly = False
                        '    cmbDestinoViaje.BackColor = System.Drawing.SystemColors.Window
                        'Else
                        '    cmbDestinoViaje.ReadOnly = True
                        '    cmbDestinoViaje.BackColor = System.Drawing.SystemColors.Control
                        'End If
                        cmbRubroViaje.ReadOnly = False
                        cmbRubroViaje.BackColor = System.Drawing.SystemColors.Window
                        cmbSubRubroViaje.ReadOnly = False
                        cmbSubRubroViaje.BackColor = System.Drawing.SystemColors.Window
                        btnBuscarPersona.Enabled = False

                        txtCodEmbarque.ReadOnly = True
                        txtCodEmbarque.BackColor = System.Drawing.SystemColors.Control

                        ' ''cmbArea.ReadOnly = True
                        ' ''cmbArea.BackColor = System.Drawing.SystemColors.Control
                        ' ''cmbCentroCosto.ReadOnly = True
                        ' ''cmbCentroCosto.BackColor = System.Drawing.SystemColors.Control
                    Else
                        cbNoAplicaPolitica.Checked = False
                        cbNoAplicaPolitica.Enabled = False
                        'cmbDestinoViaje.ReadOnly = True
                        'cmbDestinoViaje.BackColor = System.Drawing.SystemColors.Control
                        cmbRubroViaje.ReadOnly = True
                        cmbRubroViaje.BackColor = System.Drawing.SystemColors.Control
                        cmbSubRubroViaje.ReadOnly = True
                        cmbSubRubroViaje.BackColor = System.Drawing.SystemColors.Control
                        btnBuscarPersona.Enabled = True

                        txtCodEmbarque.ReadOnly = False
                        txtCodEmbarque.BackColor = System.Drawing.SystemColors.Window

                        ' ''cmbArea.ReadOnly = False
                        ' ''cmbArea.BackColor = System.Drawing.SystemColors.Window
                        ' ''cmbCentroCosto.ReadOnly = False
                        ' ''cmbCentroCosto.BackColor = System.Drawing.SystemColors.Window
                    End If
                    '----------------------------------------------------------------------------------------------------------------
                End If
                edicion = True
                enableOpciones()
                txtCantidad.Select()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Sub desactivar()
        Try
            txtCodCuenta.ReadOnly = True
            txtCodCuenta.BackColor = System.Drawing.SystemColors.Control
            txtCantidad.ReadOnly = True
            txtCantidad.BackColor = System.Drawing.SystemColors.Control
            'txtNumJob.ReadOnly = True
            'txtNumJob.BackColor = System.Drawing.SystemColors.Control
            'btnBuscarJob.Enabled = False
            cmbTipoGasto.ReadOnly = True
            cmbTipoGasto.BackColor = System.Drawing.SystemColors.Control
            'cbComputo.Enabled = False
            cmbRubro.ReadOnly = True
            cmbRubro.BackColor = System.Drawing.SystemColors.Control
            cbAfectoIgv.Enabled = False
            txtMonto.ReadOnly = True
            txtMonto.BackColor = System.Drawing.SystemColors.Control
            txtMontoNoAfecto.ReadOnly = True
            txtMontoNoAfecto.BackColor = System.Drawing.SystemColors.Control
            cbNoAplicaPolitica.Enabled = False
            'cmbDestinoViaje.ReadOnly = True
            'cmbDestinoViaje.BackColor = System.Drawing.SystemColors.Control
            cmbRubroViaje.ReadOnly = True
            cmbRubroViaje.BackColor = System.Drawing.SystemColors.Control
            cmbSubRubroViaje.ReadOnly = True
            cmbSubRubroViaje.BackColor = System.Drawing.SystemColors.Control
            cmbPlaca.ReadOnly = True
            cmbPlaca.BackColor = System.Drawing.SystemColors.Control
            txtDescripcion.ReadOnly = True
            txtDescripcion.BackColor = System.Drawing.SystemColors.Control
            txtJustificacion.ReadOnly = True
            txtJustificacion.BackColor = System.Drawing.SystemColors.Control
            btnBuscarPersona.Enabled = False

            txtCodEmbarque.ReadOnly = True
            txtCodEmbarque.BackColor = System.Drawing.SystemColors.Control

            btnBuscarProveedor.Enabled = False
            btnAgregarProveedor.Enabled = False
            btnLimpiarProveedor.Enabled = False
            cmbCondPago.ReadOnly = True
            cmbCondPago.BackColor = System.Drawing.SystemColors.Control

            cbAplicaCosto.Enabled = False

            cmbTipoDoc.ReadOnly = True
            cmbTipoDoc.BackColor = System.Drawing.SystemColors.Control
            txtSerieDoc.ReadOnly = True
            txtSerieDoc.BackColor = System.Drawing.SystemColors.Control
            txtNumDoc.ReadOnly = True
            txtNumDoc.BackColor = System.Drawing.SystemColors.Control
            txtFecDoc.ReadOnly = True
            txtFecDoc.BackColor = System.Drawing.SystemColors.Control
            btnBuscarXml.Enabled = False
            btnBuscarPdf.Enabled = False
            biLimpiarXml.Enabled = False
            biLimpiarPdf.Enabled = False

            edicion = False
            enableOpciones()
            txtCantidad.Focus()
        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Dim dtTable As New DataTable
        dtTable = oSolicitudGastoDetService.MostrarRubros(toNumber(cmbTipoGasto.Value)).Tables(0)
        Try
            If txtCantidad.Value <= 0 Then
                MsgBox("Debe Ingresar la Cantidad. ", MsgBoxStyle.Information, "Información")
                txtCantidad.Focus()
                Return False
            ElseIf toNumber(cmbTipoGasto.Value) = 0 And GastoViaje = False Then '-------- 21/09/2016 --------
                MsgBox("Debe Ingresar el Tipo de Gasto", MsgBoxStyle.Information, "Información")
                cmbTipoGasto.Focus()
                Return False
            ElseIf toNumber(cmbRubro.Value) = 0 And GastoViaje = False And dtTable.Rows.Count > 0 Then '-------- 04/07/2018 --------         
                MsgBox("Debe Ingresar el Rubro", MsgBoxStyle.Information, "Información")
                cmbRubro.Focus()
                Return False

                '----------------- Se comento ya que ahora el campo Rubro es obligatorio en todos los casos ----------------- (21/09/2016)
                'ElseIf dgvJos.RowCount > 0 And toNumber(cmbRubro.Value) = 0 And state_button = True Then
                '    MsgBox("Debe Ingresar el Rubro del Gasto", MsgBoxStyle.Information, "Información")
                '    cmbRubro.Focus()
                '    Return False
                '-------------------------------------------------------------------------------------------------------------------------------------------------

                '--------------------------------------------------------- Se agregó el 28/06/2013 ---------------------------------------------------------(Sr. Pacolo)
                ' '' '' ''ElseIf txtNumJob.Text = "" And cmbArea.Value = "05" Then
                ' '' '' ''    MsgBox("Debe Ingresar el Número del Job.", MsgBoxStyle.Information, "Información")
                ' '' '' ''    txtNumJob.Focus()
                ''Return False
                '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

                '-------------------------------------------------------Agregado el 17/05/2012 (Gasto de Viaje)------------------------------------------------------ (se cambio para validar por idPersonaSolicita y por área)
                '--------------------------------------------------------- Se comenta el 28/06/2013 ----------------------------------------------------------------------- (Sr. Pacolo)
                'ElseIf txtNumJob.Text = "" And GastoViaje = True And oSolicitudGastoDetService.BuscarJefe(IdPersonaSolicita) = False And cmbArea.Value = "05" Then
                '    MsgBox("Debe Ingresar el Número del Job.", MsgBoxStyle.Information, "Información")
                '    txtNumJob.Focus()
                '    Return False
                'ElseIf txtNumJob.Text = "" And GastoViaje = True And CodArea = "05" Then
                '    MsgBox("Debe Ingresar el Número del Job.", MsgBoxStyle.Information, "Información")
                '    txtNumJob.Focus()
                '    Return False
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            ElseIf txtIgv.Value < 0 Then
                MsgBox("El Igv no debe ser menor que CERO.")
                txtIgv.Focus()
                Return False
            ElseIf toDouble(txtMonto.Value) <= 0 And cbAfectoIgv.Checked = True Then    'toDouble(txtMonto.Value) <= 0 Then  ' Modificado 26-02
                MsgBox("El monto debe ser mayor a CERO.", MsgBoxStyle.Information, "Información")
                txtMonto.Focus()
                Return False
            ElseIf toDouble(txtMontoNoAfecto.Value) < 0 Then
                MsgBox("El monto no afecto no debe ser menor a CERO", MsgBoxStyle.Information, "Información")
                txtMontoNoAfecto.Focus()
                Return False
                '----------------------------------------------------------------Agregado el 17/05/2012 (Gasto de Viaje)-------------------------------------------------------------------
                'ElseIf GastoViaje = True And oSolicitudGastoDetService.BuscarJefe(IdPersonaSolicita) = False And cmbDestinoViaje.SelectedIndex = 0 Then
                'ElseIf GastoViaje = True And toNumber(cmbDestinoViaje.Value) = 0 Then
                '    MsgBox("Debe Ingresar el Destino de Viaje.", MsgBoxStyle.Information, "Información")
                '    cmbDestinoViaje.Focus()
                '    Return False
            ElseIf GastoViaje = True And toNumber(cmbRubroViaje.Value) = 0 Then
                MsgBox("Debe Ingresar el Rubro de Viaje.", MsgBoxStyle.Information, "Información")
                cmbRubroViaje.Focus()
                Return False
            ElseIf GastoViaje = True And toNumber(cmbSubRubroViaje.Value) = 0 Then 'And oSolicitudGastoDetService.BuscarJefe(IdPersonaSolicita) = False 
                MsgBox("Debe Ingresar el SubRubro de Viaje.", MsgBoxStyle.Information, "Información")
                cmbSubRubroViaje.Focus()
                Return False
                '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            ElseIf toBlank(txtCodEmbarque.Text) <> "" And Not (oEmbarqueService.Buscar(Session.sCodEmp, txtCodEmbarque.Text)) Then
                MsgBox("El código de embarque no es válido.", MsgBoxStyle.Information, "Información")
                txtCodEmbarque.Focus()
                Return False

            ElseIf toBlank(txtDescripcion.Text) = "" Then
                MsgBox("Debe Ingresar la Descripción", MsgBoxStyle.Information, "Información")
                txtDescripcion.Focus()
                Return False
            ElseIf toNumber(IdProveedor) <> 0 And toNumber(cmbCondPago.Value) = 0 Then
                MsgBox("Debe de ingresar la Forma de Pago.", MsgBoxStyle.Information, "Información")
                cmbCondPago.Focus()
                Return False
                ' ''ElseIf toBlank(cmbArea.Value) = "" Then
                ' ''    MsgBox("Debe de Ingresar el Área.", MsgBoxStyle.Information, "Información")
                ' ''    'cmbArea.BackColor = Color.Red
                ' ''    cmbArea.Focus()
                ' ''    Return False
            ElseIf toNumber(cmbCondPago.Value) <> 0 And toNumber(IdProveedor) = 0 Then
                MsgBox("Debe de ingresar el Proveedor.", MsgBoxStyle.Information, "Información")
                txtProveedor.Focus()
                Return False
            ElseIf toNumber(cmbTipoDoc.Value) <> 0 And (toBlank(txtSerieDoc.Text) = "") Then
                MsgBox("Debe Ingresar la Serie del Documento.", MsgBoxStyle.Information, "Información")
                txtSerieDoc.Focus()
                Return False
            ElseIf toNumber(cmbTipoDoc.Value) <> 0 And (toBlank(txtNumDoc.Text) = "") Then
                MsgBox("Debe Ingresar el Número del Documento.", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf toNumber(cmbTipoDoc.Value) = 0 And toBlank(txtNumDoc.Text) <> "" Then
                MsgBox("Debe Ingresar el Tipo de Documento.", MsgBoxStyle.Information, "Información")
                cmbTipoDoc.Focus()
                Return False
            ElseIf (toBlank(txtNumDoc.Text) <> "") And toNumber(cmbTipoDoc.Value) = 0 And GastoViaje = False Then
                MsgBox("Debe Ingresar el Tipo de Documento.", MsgBoxStyle.Information, "Información")
                cmbTipoDoc.Focus()
                Return False
            ElseIf toBlank(txtFecDoc.Text) = "" Then 'Se valida que la fecha del gasto sea obligatoria en cualquier caso
                MsgBox("Debe Ingresar la fecha del Gasto.", MsgBoxStyle.Information, "Información")
                txtFecDoc.Focus()
                Return False
                'ElseIf toBlank(txtFecDoc.Text) = "" And GastoViaje = True Then
                '    MsgBox("Debe Ingresar la fecha del Documento.", MsgBoxStyle.Information, "Información")
                '    txtFecDoc.Focus()
                '    Return False
                'ElseIf toNumber(cmbTipoDoc.Value) <> 0 And toBlank(txtFecDoc.Text) = "" And GastoViaje = False Then
                '    MsgBox("Debe Ingresar la fecha del Documento.", MsgBoxStyle.Information, "Información")
                '    txtFecDoc.Focus()
                '    Return False
            ElseIf toNumber(cmbTipoDoc.Value) <> 0 And Year(txtFecDoc.Value) < 2012 Then
                MsgBox("Fecha de Documento inválido.", MsgBoxStyle.Information, "Información")
                txtFecDoc.Focus()
                Return False
            ElseIf toBlank(txtNumDoc.Text) <> "" And IdProveedor = 0 Then
                MsgBox("Debe Ingresar el Proveedor.", MsgBoxStyle.Information, "Información")
                txtProveedor.Focus()
                Return False
            ElseIf toBlank(txtSerieDoc.Text) = "" And IdProveedor <> 0 Then
                MsgBox("Debe Ingresar la Serie del Documento.", MsgBoxStyle.Information, "Información")
                txtSerieDoc.Focus()
                Return False
            ElseIf toBlank(txtNumDoc.Text) = "" And IdProveedor <> 0 Then
                MsgBox("Debe Ingresar el Número del Documento.", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf toBlank(txtXmlFE.Text) = "" And toBlank(txtPdfFE.Text) <> "" Then
                MsgBox("Debe Ingresar el Documento Xml y el Documento Pdf.", MsgBoxStyle.Information, "Información")
                txtXmlFE.Focus()
                Return False
            ElseIf toBlank(txtXmlFE.Text) <> "" And toBlank(txtPdfFE.Text) = "" Then
                MsgBox("Debe Ingresar el Documento Xml y el Documento Pdf.", MsgBoxStyle.Information, "Información")
                txtPdfFE.Focus()
                Return False
            ElseIf ((oProveedorService.ObtenerEmiteFacturaDigital(IdProveedor) And (toBlank(txtXmlFE.Text) = "" And toBlank(txtPdfFE.Text) = "")) And Not (oSolicitudGastoDetService.BuscarXmlxDoc(toNumber(IdGasto), toNumber(IdProveedor), toNumber(cmbTipoDoc.DropDownList.GetRow.Cells(0).Text), toBlank(txtSerieDoc.Text), toBlank(txtNumDoc.Text)))) = True Then
                'oProveedorService.ObtenerEmiteFacturaDigital(IdProveedor)
                MsgBox("Debe Ingresar el Documento Xml y el Documento Pdf.", MsgBoxStyle.Information, "Información")
                txtPdfFE.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Function ValidaCodigoSeleccionadoCentroCosto() As Boolean
        Try
            If dgvCentrosCosto.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvCentrosCosto.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvCentrosCosto.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO CENTRO COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Function ValidaCodigoSeleccionadoJob() As Boolean
        Try
            If dgvJos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvJos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvJos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO JOB: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub ObtenerRegistro()
        Try
            Dim registro As SolicitudGastoDetService.SolicitudGastoDet
            registro = oSolicitudGastoDetService.Obtener(toNumber(IdGastoDet))

            IdGastoDet = registro.IdGastoDet
            IdGasto = registro.SolicitudGasto.IdGasto
            txtItem.Value = registro.Item
            txtCodCuenta.Text = toNull(registro.CuentaContable.CodCuenta)
            txtCantidad.Value = registro.Cantidad
            'txtNumJob.Text = registro.Job.CodJob

            If registro.TipoGasto.IdTipoGasto <> 0 Then
                cmbTipoGasto.Value = registro.TipoGasto.IdTipoGasto
            Else
                cmbTipoGasto.SelectedIndex = 0
            End If
            ObtenerObservacionTipoGasto()
            'cbComputo.Checked = registro.TieneRubro
            If registro.RubroGasto.CodRubro <> "" Then
                cmbRubro.Value = registro.RubroGasto.CodRubro
                'cbComputo.Checked = True
            Else
                cmbRubro.SelectedIndex = 0
                'cbComputo.Checked = False
            End If

            IdPersona = registro.Persona.IdPer
            txtPersona.Text = registro.Persona.ApeNom

            txtCodEmbarque.Text = toNull(registro.Embarque.CodEmbarque)       '--- Se agregó el 09/07/2014 Importaciones (Sra. Mori)

            ' ''cmbArea.Value = registro.CentroCosto.Area.CodArea
            ' ''cmbCentroCosto.Value = registro.CentroCosto.CodCentro
            txtIgv.Value = registro.Igv
            txtDescripcion.Text = registro.Descripcion
            txtJustificacion.Text = registro.Justificacion
            IdProveedor = registro.Proveedor.IdProveedor
            txtProveedor.Text = registro.Proveedor.DesProv
            If registro.CondicionPagoProveedor.IdCondicion <> 0 Then
                cmbCondPago.Value = registro.CondicionPagoProveedor.IdCondicion
            Else
                cmbCondPago.SelectedIndex = 0
            End If
            If registro.TipoDocumento.IdDocumento <> 0 Then
                cmbTipoDoc.Value = registro.TipoDocumento.IdDocumento
            Else
                cmbTipoDoc.SelectedIndex = 0
            End If
            txtMonto.Value = registro.Monto
            txtMontoSinIgv.Value = registro.MontoSinIgv
            txtMontoNoAfecto.Value = registro.MontoNoAfecto
            cbAfectoIgv.Checked = registro.Afecto
            txtNumDoc.Text = registro.NumDoc
            txtSerieDoc.Text = registro.SerDoc
            If Not (registro.FecDoc.ToString = "") Then
                txtFecDoc.Value = CDate(registro.FecDoc)
                txtFecDoc.Text = registro.FecDoc.ToString
            End If

            cbAplicaCosto.Checked = registro.AplicaCosto

            '---------------------------------------Agregado el 17/05/2012 (Gasto de Viaje)-----------------------------------
            cbNoAplicaPolitica.Checked = registro.NoAplicaTarifa
            'If registro.DestinosViaje.IdDestino Is Nothing Or registro.DestinosViaje.IdDestino = 0 Then
            '    cmbDestinoViaje.SelectedIndex = 0
            'Else
            '    cmbDestinoViaje.Value = registro.DestinosViaje.IdDestino
            'End If
            If registro.SubRubroViaje.RubroViaje.IdRubro Is Nothing Or registro.SubRubroViaje.RubroViaje.IdRubro = 0 Then
                cmbRubroViaje.SelectedIndex = 0
            Else
                cmbRubroViaje.Value = registro.SubRubroViaje.RubroViaje.IdRubro
            End If
            LlenarSubRubroViaje()
            If registro.SubRubroViaje.IdSubRubro Is Nothing Or registro.SubRubroViaje.IdSubRubro = 0 Then
                cmbSubRubroViaje.SelectedIndex = 0
            Else
                cmbSubRubroViaje.Value = registro.SubRubroViaje.IdSubRubro
            End If
            ObtenerObservacion()
            If registro.Unidad.Placa = Nothing Or registro.Unidad.Placa = "" Then
                cmbPlaca.SelectedIndex = 0
            Else
                cmbPlaca.Value = registro.Unidad.Placa
            End If
            DocumentoXml = registro.DocumentoXml
            DocumentoPdf = registro.DocumentoPdf
            NombreArchivo = registro.NombreArchivo
            txtPdfFE.Text = registro.NombreArchivo
            txtXmlFE.Text = registro.NombreArchivo
            '---------------------------------------------------------------------------------------------------------------------------------------
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoCentroCosto()
        Try
            Dim frm As New frmAgregar_CentroCosto_SolGastosNew
            frm.IdGastoDet = IdGastoDet
            frm.IdGasto = IdGasto
            frm.Monto = txtMonto.Value
            frm.MontoSinIgv = txtMontoSinIgv.Value
            frm.MontoNoAfecto = txtMontoNoAfecto.Value
            frm.MontoTotal = txtMontoTotal.Value
            frm.AfectoIgv = cbAfectoIgv.Checked
            frm.Igv = txtIgv.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtCentrosCosto = Nothing
                ObtenerRegistro()
                ActualizarDetallesCentroCosto()
                ActualizarDetallesJob()
            Else
                ObtenerRegistro()
                ActualizarDetallesCentroCosto()
                ActualizarDetallesJob()
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ASIGNAR CENTROS DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarDetallesCentroCosto()
        Try
            Dim codigo As String = ""
            If dgvCentrosCosto.RowCount > 0 Then
                If IsDBNull(dgvCentrosCosto.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvCentrosCosto.CurrentRow.Cells("CodCentro").Text
                End If
            End If
            dtCentrosCosto = Nothing
            listaDatosCentroCosto()
            If dgvCentrosCosto.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionCentroCosto(dgvCentrosCosto, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoJob()
        Try
            'If oSolicitudGastoDetService.BuscarServicios(IdGastoDet) Then
            Dim MontoServicio As Double = 0.0
                Dim MontoSinIgvServicio As Double = 0.0
                Dim MontoNoAfectoServicio As Double = 0.0
                Dim row As Janus.Windows.GridEX.GridEXRow

                For i = 0 To Me.dgvCentrosCosto.RowCount - 1
                    Me.dgvCentrosCosto.Row = i
                    row = Me.dgvCentrosCosto.GetRow()
                    If row.Cells("CodArea").Value = "05" Or row.Cells("CodArea").Value = "20" Then
                    MontoServicio = MontoServicio + toDouble(row.Cells("Monto").Value)
                    MontoSinIgvServicio = MontoSinIgvServicio + toDouble(row.Cells("MontoSinIgv").Value)
                        MontoNoAfectoServicio = MontoNoAfectoServicio + toDouble(row.Cells("MontoNoAfecto").Value)
                    End If
                Next

                Dim frm As New frmAgregar_Job_SolGastosNew
                frm.IdGastoDet = IdGastoDet
                frm.IdGasto = IdGasto
                frm.Monto = MontoServicio
                frm.MontoSinIgv = MontoSinIgvServicio
                frm.MontoNoAfecto = MontoNoAfectoServicio
                frm.MontoTotal = txtMontoTotal.Value
                frm.AfectoIgv = cbAfectoIgv.Checked
                frm.Igv = txtIgv.Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtJobs = Nothing
                    ObtenerRegistro()
                    ActualizarDetallesCentroCosto()
                    ActualizarDetallesJob()
                Else
                    ObtenerRegistro()
                    ActualizarDetallesCentroCosto()
                    ActualizarDetallesJob()
                    enableOpciones()
                End If
            'Else
            '    MsgBox("Debe ingresar un Centro de Costo de Servicio Técnico ó Componentes Mayores.", MsgBoxStyle.Information, "Información")
            'End If
        Catch ex As Exception
            MsgBox("ERROR AL ASIGNAR JOB: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarDetallesJob()
        Try
            Dim codigo As String = ""
            If dgvJos.RowCount > 0 Then
                If IsDBNull(dgvJos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvJos.CurrentRow.Cells("CodJob").Text
                End If
            End If
            dtJobs = Nothing
            listaDatosJob()
            If dgvJos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionJob(dgvJos, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES JOB: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As SolicitudGastoDetService.SolicitudGastoDet)
        Try
            Dim estado_process As Integer
            estado_process = oSolicitudGastoDetService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdGastoDet = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As SolicitudGastoDetService.SolicitudGastoDet)
        Try
            Dim estado_process As Boolean
            estado_process = oSolicitudGastoDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                desactivar()
                ObtenerRegistro()
                ActualizarDetallesCentroCosto()
                ActualizarDetallesJob()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatosCentroCosto()
        Try
            dtCentrosCosto = oSolicitudGastoDetService.MostrarCentro(IdGastoDet).Tables(0)
            dgvCentrosCosto.DataSource = dtCentrosCosto
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatosJob()
        Try
            dtJobs = oSolicitudGastoDetService.MostrarJob(IdGastoDet).Tables(0)
            dgvJos.DataSource = dtJobs
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS JOB: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerAreaCentroCosto()
        Persona = oPersonaService.Obtener(IdPersonaSolicita)
        ' ''cmbArea.Value = Persona.CentroCosto.Area.CodArea
        ' ''cmbCentroCosto.Value = Persona.CentroCosto.CodCentro
    End Sub

    Private Sub ObtenerPersonayRubro()
        Persona = oPersonaService.Obtener(IdPersonaSolicita)
        IdPersona = IdPersonaSolicita
        txtPersona.Text = Persona.ApeNom
        cmbTipoGasto.Value = 9
    End Sub

    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdProveedor = frm.codigo
                    txtProveedor.Text = frm.descripcion
                    cmbCondPago.Focus()
                Else
                    IdProveedor = 0
                    txtProveedor.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub btnBuscarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim frm As New frmBuscarJob
    '        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '            If toNull(frm.cod_job) <> Nothing Then
    '                txtNumJob.Text = frm.cod_job
    '                CalcularMontos()
    '            Else
    '                txtNumJob.Text = ""
    '                txtNumJob.Focus()
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.F12 Then
    '        If btnBuscarJob.Enabled = True Then
    '            e.Handled = True
    '            btnBuscarJob_Click(sender, e)
    '        End If
    '    End If
    '    If e.KeyCode = Keys.Enter Then
    '        If Len(Trim(txtNumJob.Text)) > 0 Then
    '            If Not (oJobService.Buscar(txtNumJob.Text)) Then
    '                MsgBox("Número de Job no existente, Verifique")
    '                txtNumJob.Text = ""
    '                txtNumJob.Focus()
    '            Else
    '                cmbRubro.Focus()
    '            End If
    '        Else
    '            cmbRubro.Focus()
    '        End If
    '    End If
    'End Sub

    'Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        If Len(Trim(txtNumJob.Text)) > 0 Then

    '            If Not (oJobService.Buscar(txtNumJob.Text)) Then
    '                MsgBox("Número de Job no existente, Verifique")
    '                txtNumJob.Text = ""
    '                txtNumJob.Focus()
    '            ElseIf oJobService.Estado(txtNumJob.Text) = 1 Then
    '                MsgBox("Número de Job Anulado, Verifique")
    '                txtNumJob.Text = ""
    '                txtNumJob.Focus()
    '            Else
    '                cmbRubro.Focus()
    '            End If
    '        Else
    '            cmbRubro.Focus()
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL OBTENER EL JOB : " + ex.Message)
    '    End Try
    'End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    Dim registro As New SolicitudGastoDetService.SolicitudGastoDet
                    Dim CondicionPago As New SolicitudGastoDetService.CondicionPagoProveedor
                    Dim Proveedor As New SolicitudGastoDetService.Proveedor
                    Dim SolicitudGasto As New SolicitudGastoDetService.SolicitudGasto
                    Dim TipoDocumento As New SolicitudGastoDetService.TipoDocumento
                    Dim Persona As New SolicitudGastoDetService.Persona
                    Dim Planilla As New SolicitudGastoDetService.PlanillaViatico
                    Dim Rubro As New SolicitudGastoDetService.RubroGasto
                    'Dim CuentaContable As New SolicitudGastoDetService.CuentaContable
                    '---------------------Agregado el 16/05/2012 (Gasto de Viaje)--------------------
                    Dim Destino As New SolicitudGastoDetService.DestinosViaje
                    Dim RubroViaje As New SolicitudGastoDetService.RubroViaje
                    Dim SubRubro As New SolicitudGastoDetService.SubRubroViaje
                    Dim Placa As New SolicitudGastoDetService.Unidad
                    '-----------------------------------------------------------------------------------------------------
                    Dim Embarque As New SolicitudGastoDetService.Embarque         '--- Se agregó el 09/07/2014 Importaciones (Sra. Mori)
                    Dim TipoGasto As New SolicitudGastoDetService.TipoGasto


                    registro.IdGastoDet = IdGastoDet
                    SolicitudGasto.IdGasto = IdGasto
                    SolicitudGasto.GastoViaje = GastoViaje
                    registro.SolicitudGasto = SolicitudGasto
                    registro.Item = txtItem.Value
                    registro.Cantidad = txtCantidad.Value
                    Rubro.CodRubro = IIf(cmbRubro.SelectedIndex = 0, Nothing, cmbRubro.Value) 'IIf(cbComputo.Checked = True, IIf(cmbRubro.SelectedIndex = 0, Nothing, cmbRubro.Value), Nothing)
                    registro.RubroGasto = Rubro
                    TipoGasto.IdTipoGasto = IIf(GastoViaje, 7, cmbTipoGasto.Value) 'Se valida que ingrese tipo de gasto 7 (Traslado Personal) por defecto cunado sea tipo Gasto de Viaje 29/08/2017 'IIf(cmbTipoGasto.SelectedIndex = 0, Nothing, cmbTipoGasto.Value)
                    registro.TipoGasto = TipoGasto
                    registro.Igv = txtIgv.Value
                    registro.Descripcion = txtDescripcion.Text
                    Planilla.IdPlanilla = Nothing
                    registro.PlanillaViatico = Planilla
                    Persona.IdPer = IIf(IdPersona = 0, Nothing, IdPersona)
                    registro.Persona = Persona

                    Embarque.CodEmbarque = IIf(txtCodEmbarque.Text = "", Nothing, txtCodEmbarque.Text)     '--- Se agregó el 09/07/2014 Importaciones (Sra. Mori)
                    registro.Embarque = Embarque                               '--- Se agregó el 09/07/2014 Importaciones (Sra. Mori)

                    Proveedor.IdProveedor = IdProveedor
                    registro.Proveedor = Proveedor

                    If toNumber(cmbCondPago.Value) = 0 Then
                        CondicionPago.IdCondicion = Nothing
                        registro.CondicionPagoProveedor = CondicionPago
                    Else
                        CondicionPago.IdCondicion = cmbCondPago.Value
                        registro.CondicionPagoProveedor = CondicionPago
                    End If
                    If toNumber(cmbTipoDoc.Value) = 0 Then
                        TipoDocumento.IdDocumento = Nothing
                        registro.TipoDocumento = TipoDocumento
                    Else
                        TipoDocumento.IdDocumento = cmbTipoDoc.Value
                        registro.TipoDocumento = TipoDocumento
                    End If
                    registro.Afecto = cbAfectoIgv.Checked
                    registro.Monto = txtMonto.Value
                    registro.MontoSinIgv = txtMontoSinIgv.Value
                    registro.MontoNoAfecto = txtMontoNoAfecto.Value
                    If Len(Trim(txtSerieDoc.Text)) > 0 Then
                        SerieDoc()
                    End If
                    If Len(Trim(txtNumDoc.Text)) > 0 Then
                        NumDoc()
                    End If
                    registro.NumDoc = toNull(txtNumDoc.Text)
                    registro.SerDoc = toNull(txtSerieDoc.Text)
                    registro.FecDoc = IIf(txtFecDoc.Text = "", Nothing, txtFecDoc.Value)
                    registro.Justificacion = txtJustificacion.Text
                    registro.CodUsu = Session.sCodUsu
                    registro.DirIp = Session.sDirIp
                    registro.NomPc = Session.sNomPc

                    '---------------------Agregado el 14/06/2012 (Sr Pacolo)--------------------
                    Placa.Placa = IIf(cmbPlaca.SelectedIndex = 0, Nothing, cmbPlaca.Value)
                    registro.Unidad = Placa
                    '----------------------------------------------------------------------------------------------------

                    '---------------------Agregado el 16/05/2012 (Gasto de Viaje)--------------------
                    If GastoViaje = True Then
                        registro.NoAplicaTarifa = cbNoAplicaPolitica.Checked
                        'Destino.IdDestino = IIf(CInt(cmbDestinoViaje.Value) = 0, Nothing, cmbDestinoViaje.Value)
                        'registro.DestinosViaje = Destino
                        SubRubro.IdSubRubro = IIf(CInt(cmbSubRubroViaje.Value) = 0, Nothing, cmbSubRubroViaje.Value)
                        RubroViaje.IdRubro = IIf(CInt(cmbRubroViaje.Value) = 0, Nothing, cmbRubroViaje.Value)
                        SubRubro.RubroViaje = RubroViaje
                        registro.SubRubroViaje = SubRubro
                    Else
                        registro.NoAplicaTarifa = False
                        'Destino.IdDestino = Nothing
                        'registro.DestinosViaje = Destino
                        SubRubro.IdSubRubro = Nothing
                        RubroViaje.IdRubro = Nothing
                        SubRubro.RubroViaje = RubroViaje
                        registro.SubRubroViaje = SubRubro
                    End If
                    '----------------------------------------------------------------------------------------------------
                    registro.AplicaCosto = cbAplicaCosto.Checked
                    '----------------------------------------------------------------------------------------------------
                    Dim xmlDoc As New XmlDocument

                    Dim count As Integer
                    count = txtXmlFE.Text.Split("\").Length - 1
                    If count < 1 Then

                        registro.DocumentoXml = IIf(txtXmlFE.Text = "", Nothing, DocumentoXml)
                        registro.DocumentoPdf = IIf(txtPdfFE.Text = "", Nothing, DocumentoPdf)
                        registro.NombreArchivo = IIf(txtXmlFE.Text = "", Nothing, NombreArchivo)
                    Else
                        If txtXmlFE.Text <> "" Then
                            xmlDoc.Load(txtXmlFE.Text)
                        End If

                        If txtPdfFE.Text <> "" Then
                            Dim rutapdf As New FileStream(txtPdfFE.Text, FileMode.Open, FileAccess.Read)
                            Dim binarioPDF(rutapdf.Length) As Byte
                            rutapdf.Read(binarioPDF, 0, rutapdf.Length) 'Leo el archivo y lo convierto a binario
                            rutapdf.Close()
                            registro.DocumentoPdf = IIf(txtPdfFE.Text = "", Nothing, binarioPDF)
                        End If
                        registro.DocumentoXml = IIf(txtXmlFE.Text = "", Nothing, xmlDoc.OuterXml)
                        registro.NombreArchivo = NombreArchivo
                    End If
                    '-------------------------------------------------------------------------------------------


                    If state_button Then        'Modificar
                        Modificar(registro)
                    Else                        'Nuevo
                        Insertar(registro)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        'If ValidarDetalles() Then      '--- Se comenta a pedido del Sr Carlos Rios 13/05/2015
        If toNumber(cmbTipoGasto.Value) = 0 And GastoViaje = False Then 'And dgvJos.RowCount > 0 Then
            MsgBox("Debe ingresar el Tipo de Gasto.", MsgBoxStyle.Information, "Información")
            cmbTipoGasto.Focus()
        Else
            Finalizar()
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
        'End If
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

    Private Sub biEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEditar.Click
        Activar()
    End Sub

    Private Sub miAsignar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miAsignarCentroCosto.Click
        If state_button = True Then
            NuevoCentroCosto()
        End If
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizarCentroCosto.Click
        ActualizarDetallesCentroCosto()
    End Sub

    Private Sub txtProveedor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProveedor.TextChanged
        Try
            If txtProveedor.Text <> "" Then
                Dim proveedor As ProveedorService.Proveedor
                proveedor = oProveedorService.Obtener(IdProveedor)
                If proveedor.CondicionPagoProveedor.IdCondicion <> 0 Then
                    cmbCondPago.Value = proveedor.CondicionPagoProveedor.IdCondicion
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA CONDICION DE PAGO DEL PROVEEDOR : " + ex.Message)
        End Try
    End Sub

    Private Sub txtIgv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIgv.TextChanged, txtMonto.TextChanged, txtMontoNoAfecto.TextChanged
        CalcularMontos()
    End Sub

    Private Sub CalcularMontos()
        Dim MontoSinIgv As Double
        If cmbTipoDoc.Value = 38 Then
            Dim igvhn As Integer = 8
            MontoSinIgv = IIf(cbAfectoIgv.Checked = True, (txtMonto.Value / ((igvhn + 100) / 100)) + txtMontoNoAfecto.Value, txtMontoNoAfecto.Value)
        Else
            MontoSinIgv = IIf(cbAfectoIgv.Checked = True, (txtMonto.Value / ((txtIgv.Value + 100) / 100)) + txtMontoNoAfecto.Value, txtMontoNoAfecto.Value)
        End If
        'MontoSinIgv = IIf(cbAfectoIgv.Checked = True, txtMonto.Value / ((txtIgv.Value + 100) / 100), txtMonto.Value)   'Comentado 26-02

        txtMontoSinIgv.Value = MontoSinIgv
        txtMontoTotal.Value = txtMonto.Value + txtMontoNoAfecto.Value
        'txtMontoIgv.Value = txtMonto.Value - txtMontoSinIgv.Value                                                      'Comentado 26-02
        txtMontoIgv.Value = IIf(cbAfectoIgv.Checked = True, txtMonto.Value - txtMontoSinIgv.Value + txtMontoNoAfecto.Value, 0)

    End Sub

    Private Sub cmbTipoDoc_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoDoc.ValueChanged
        If oSolicitudGastoDetService.BuscarAplicaIgv(toNumber(cmbTipoDoc.Value)) Then
            cbAfectoIgv.Checked = True
        Else
            cbAfectoIgv.Checked = False
        End If
        'If cmbTipoDoc.Value = 3 Or cmbTipoDoc.Value = 43 Or cmbTipoDoc.Value = 40 Then
        '    cbAfectoIgv.Checked = True
        'Else
        '    cbAfectoIgv.Checked = False
        'End If
    End Sub

    Private Sub cbAfectoIgv_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAfectoIgv.CheckedChanged
        If cbAfectoIgv.Checked = False Then
            txtMonto.Text = 0  'Agregado 26-02-15
            txtMontoSinIgv.Value = txtMonto.Value
            txtMonto.ReadOnly = True
            txtMonto.BackColor = System.Drawing.SystemColors.Control
        ElseIf cbAfectoIgv.Checked = True Then
            txtMonto.ReadOnly = False
            txtMonto.BackColor = System.Drawing.SystemColors.Window
        End If

        'txtMontoSinIgv.ReadOnly = False
        'txtMontoSinIgv.BackColor = System.Drawing.SystemColors.Window

        CalcularMontos()
    End Sub

    Private Sub txtMontoNoAfecto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMontoNoAfecto.TextChanged
        txtMontoTotal.Value = txtMonto.Value + txtMontoNoAfecto.Value
        'Agregado 26-02-15
        If cbAfectoIgv.Checked = False Then
            txtMontoSinIgv.Value = txtMontoNoAfecto.Value
        End If
    End Sub

    Private Sub btnAgregarProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarProveedor.Click
        Try
            Dim frm As New frmProveedor
            frm.state_button = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdProveedor = frm.IdProveedor
                txtProveedor.Text = frm.DesProv
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el Proveedor : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnLimpiarProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLimpiarProveedor.Click 'Agregado el 20/09/2012
        Try
            IdProveedor = 0
            txtProveedor.Text = ""
            cmbCondPago.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Error al Limpiar el Proveedor : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersona = frm.codigo
                    txtPersona.Text = frm.descripcion
                    txtCodEmbarque.Focus()
                Else
                    IdPersona = 0
                    txtPersona.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '--------------------------------------------------------------------------Agregado el 17/05/2012 (Gasto de Viaje)-----------------------------------------------------------------------
    Private Sub cmbRubroViaje_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRubroViaje.ValueChanged
        LlenarSubRubroViaje()
    End Sub

    Private Sub cmbSubRubroViaje_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSubRubroViaje.ValueChanged
        ObtenerObservacion()
    End Sub

    Private Sub ObtenerObservacion()
        If cmbSubRubroViaje.SelectedIndex <> 0 Then
            txtObservSubRubro.Text = cmbSubRubroViaje.DropDownList.GetRow.Cells(2).Text    'Obtiene el Texto de la 3 columna del Combo SubRubroViaje
        Else
            txtObservSubRubro.Text = ""
        End If
    End Sub

    Private Sub cmbDestinoViaje_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LlenarSubRubroViaje()
    End Sub
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Private Sub cbNoAplicaPolitica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbNoAplicaPolitica.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            If GastoViaje = True Then
                e.Handled = True
                cmbRubroViaje.Focus()
            End If
        End If
    End Sub

    Private Sub cmbDestinoViaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbRubroViaje.Focus()
        End If
    End Sub

    Private Sub cmbRubroViaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbRubroViaje.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbSubRubroViaje.Focus()
        End If
    End Sub

    Private Sub cmbSubRubroViaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbSubRubroViaje.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbPlaca.Focus()
        End If
    End Sub

    Private Sub cmbPlaca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbPlaca.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtDescripcion.Focus()
        End If
    End Sub

    Private Sub txtMontoNoAfecto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoNoAfecto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            If GastoViaje = True And cbNoAplicaPolitica.Enabled = True Then
                e.Handled = True
                cbNoAplicaPolitica.Focus()
            ElseIf GastoViaje = True And cbNoAplicaPolitica.Enabled = False Then
                e.Handled = True
                cmbRubroViaje.Focus()
            ElseIf GastoViaje = False Then
                e.Handled = True
                txtDescripcion.Focus()
            End If
        End If
    End Sub

    Private Sub txtPersona_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPersona.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtCodEmbarque.Focus()
        End If
    End Sub

    Private Sub txtCodEmbarque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodEmbarque.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtProveedor.Focus()
        End If
    End Sub

    Private Sub cbAfectoIgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbAfectoIgv.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtMonto.Focus()
        End If
    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtMontoNoAfecto.Focus()
        End If
    End Sub

    Private Sub txtProveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProveedor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbCondPago.Focus()
        End If
    End Sub

    Private Sub cmbCondPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCondPago.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbTipoDoc.Focus()
        End If
    End Sub

    Private Sub cmbTipoDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbTipoDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtSerieDoc.Focus()
        End If
    End Sub

    Private Sub txtNumDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            If Len(Trim(txtNumDoc.Text)) > 0 Then
                NumDoc()
            End If
            txtFecDoc.Focus()
        End If
    End Sub

    Private Sub txtSerieDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerieDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            If Len(Trim(txtSerieDoc.Text)) > 0 Then
                SerieDoc()
            End If
            txtNumDoc.Focus()
        End If
    End Sub

    Private Sub txtFecDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            biGuardar.Select()
        End If
    End Sub

    Private Sub txtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbRubro.Focus()
        End If
    End Sub

    'Private Sub txtNumJob_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
    '        e.Handled = True
    '        cmbRubro.Focus()
    '    End If
    'End Sub

    Private Sub cmbRubro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbRubro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cbAfectoIgv.Focus()
        End If
    End Sub

    Private Sub txtPersonaSolicita_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPersona.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarPersona.Enabled = True Then
                e.Handled = True
                btnBuscarPersona_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarProveedor.Enabled = True Then
                e.Handled = True
                btnBuscarProveedor_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub SerieDoc()
        Try
            Dim cant As Integer = Len(txtSerieDoc.Text)
            Do While cant < 4
                txtSerieDoc.Text = "0" & txtSerieDoc.Text
                cant = cant + 1
            Loop
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA SERIE DEL DOCUMENTO : " + ex.Message)
        End Try
    End Sub

    Private Sub txtSerieDoc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSerieDoc.Validated
        Try
            If Len(Trim(txtSerieDoc.Text)) > 0 Then
                SerieDoc()
                txtNumDoc.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA SERIE DEL DOCUMENTO : " + ex.Message)
        End Try
    End Sub

    Private Sub txtSerieDoc_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtSerieDoc.Validating
        Try
            If Len(Trim(txtSerieDoc.Text)) > 0 Then
                SerieDoc()
                'txtNumDoc.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA SERIE DEL DOCUMENTO : " + ex.Message)
        End Try
    End Sub

    Private Sub NumDoc()
        Try
            Dim cant As Integer = Len(txtNumDoc.Text)
            Do While cant < 10
                txtNumDoc.Text = "0" & txtNumDoc.Text
                cant = cant + 1
            Loop
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL NÚMERO DEL DOCUMENTO : " + ex.Message)
        End Try
    End Sub

    Private Sub txtNumDoc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumDoc.Validated
        Try
            If Len(Trim(txtNumDoc.Text)) > 0 Then
                NumDoc()
                txtFecDoc.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL NÚMERO DEL DOCUMENTO : " + ex.Message)
        End Try
    End Sub

    Private Sub txtNumDoc_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNumDoc.Validating
        Try
            If Len(Trim(txtNumDoc.Text)) > 0 Then
                NumDoc()
                'txtFecDoc.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA SERIE DEL DOCUMENTO : " + ex.Message)
        End Try
    End Sub

    Private Sub txtSerieDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSerieDoc.Click
        txtSerieDoc.SelectAll()
    End Sub

    Private Sub txtNumDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumDoc.Click
        txtNumDoc.SelectAll()
    End Sub

    Private Sub txtPersona_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPersona.TextChanged
        If txtPersona.Text <> "" Then
            Persona = oPersonaService.Obtener(IdPersona)
            ' ''cmbArea.Value = Persona.CentroCosto.Area.CodArea
            ' ''cmbCentroCosto.Value = Persona.CentroCosto.CodCentro
        End If
    End Sub

    Private Sub mostrarCentroCosto()
        Try
            Dim frm As New frmComSolicitudGasto_CentroCosto
            frm.IdGastoDet = dgvCentrosCosto.CurrentRow.Cells("IdGastoDet").Value
            frm.CodCentro = dgvCentrosCosto.CurrentRow.Cells("CodCentro").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtCentrosCosto = Nothing
                listaDatosCentroCosto()
                RowPossesionCentroCosto(dgvCentrosCosto, frm.CodCentro)
            End If
            RowPossesionCentroCosto(dgvCentrosCosto, frm.CodCentro)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarJob()
        Try
            Dim frm As New frmComSolicitudGasto_Job
            frm.IdGastoDet = dgvJos.CurrentRow.Cells("IdGastoDet").Value
            frm.CodJob = dgvJos.CurrentRow.Cells("CodJob").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtJobs = Nothing
                listaDatosJob()
                RowPossesionJob(dgvJos, frm.CodJob)
            End If
            RowPossesionJob(dgvJos, frm.CodJob)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR JOB: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidarDetalles() As Boolean
        Try
            If dgvCentrosCosto.RowCount > 0 Then
                Dim Monto As Double = 0
                Dim MontoSinIgv As Double = 0
                Dim MontoNoAfecto As Double = 0
                Dim row As Janus.Windows.GridEX.GridEXRow
                For i = 0 To Me.dgvCentrosCosto.RowCount - 1
                    Me.dgvCentrosCosto.Row = i
                    row = Me.dgvCentrosCosto.GetRow()
                    Monto = Monto + CDbl(Me.dgvCentrosCosto.CurrentRow.Cells("Monto").Value)
                    MontoSinIgv = MontoSinIgv + CDbl(Me.dgvCentrosCosto.CurrentRow.Cells("MontoSinIgv").Value)
                    MontoNoAfecto = MontoNoAfecto + CDbl(Me.dgvCentrosCosto.CurrentRow.Cells("MontoNoAfecto").Value)
                Next

                If Not (txtMonto.Value = Math.Round(Monto, 2) And txtMontoSinIgv.Value = Math.Round(MontoSinIgv, 2) And txtMontoNoAfecto.Value = Math.Round(MontoNoAfecto, 2)) Then
                    MsgBox("Los montos de los centros de costo asignados no coinciden con el documento.", MsgBoxStyle.Information, "Información")
                    Return False
                    '-------------------Se comenta esta validación a pedido del Sr. Carlos Ríos 15/12/2014 ---------------
                    'ElseIf oSolicitudGastoDetService.BuscarServicios(IdGastoDet) And dgvJos.RowCount < 1 Then
                    '    MsgBox("Debe asignar un Job para los montos del centro de costo de Servicio Técnico asignado.", MsgBoxStyle.Information, "Información")
                    '    Return False
                    'ElseIf oSolicitudGastoDetService.BuscarServicios(IdGastoDet) = False And dgvJos.RowCount > 0 Then
                    '    MsgBox("Debe asignar un Centro de Costo de Servicio Técnico para los montos del Job asignado.", MsgBoxStyle.Information, "Información")
                    '    Return False
                    '---------------------------------------------------------------------------------------------------------------------------------------
                ElseIf ValidarServicioTecnicoJob() Then

                ElseIf cmbRubro.SelectedIndex = 0 And dgvJos.RowCount > 0 Then
                    MsgBox("Debe ingresar el Rubro del Gasto.", MsgBoxStyle.Information, "Información")
                    cmbRubro.Focus()
                    Return False
                Else
                    Return True
                End If
            Else
                MsgBox("Debe ingresar al menos un Centro de Costo", MsgBoxStyle.Information, "Información")
                dgvCentrosCosto.Focus()
                Return False
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR LOS DETALLES" + ex.Message)
        End Try
    End Function

    Private Function ValidarServicioTecnicoJob() As Boolean
        Try
            Dim Monto As Double = 0
            Dim MontoSinIgv As Double = 0
            Dim MontoNoAfecto As Double = 0

            Dim MontoJob As Double = 0
            Dim MontoSinIgvJob As Double = 0
            Dim MontoNoAfectoJob As Double = 0
            Dim row As Janus.Windows.GridEX.GridEXRow

            If dgvCentrosCosto.RowCount > 0 Then
                For i = 0 To Me.dgvCentrosCosto.RowCount - 1
                    Me.dgvCentrosCosto.Row = i
                    row = Me.dgvCentrosCosto.GetRow()
                    If row.Cells("CodArea").Value = "05" Or row.Cells("CodArea").Value = "20" Then
                        Monto = Monto + toDouble(row.Cells("Monto").Value)
                        MontoSinIgv = MontoSinIgv + toDouble(row.Cells("MontoSinIgv").Value)
                        MontoNoAfecto = MontoNoAfecto + toDouble(row.Cells("MontoNoAfecto").Value)
                    End If
                Next
            End If

            If dgvJos.RowCount > 0 Then
                For j = 0 To Me.dgvJos.RowCount - 1
                    Me.dgvJos.Row = j
                    row = Me.dgvJos.GetRow()
                    MontoJob = MontoJob + toDouble(row.Cells("Monto").Value)
                    MontoSinIgvJob = MontoSinIgvJob + toDouble(row.Cells("MontoSinIgv").Value)
                    MontoNoAfectoJob = MontoNoAfectoJob + toDouble(row.Cells("MontoNoAfecto").Value)
                Next
            End If
            '-------Se condiciona que se valide los montos siempre y cuando se haya agregado un centro de costo de servicios y un Job ----Sr CarlosRíos 15/12/2014--------
            If Monto > 0 And dgvJos.RowCount > 0 Then
                If Not (Math.Round(MontoJob, 2) = Math.Round(Monto, 2) And Math.Round(MontoSinIgvJob, 2) = Math.Round(MontoSinIgv, 2) And Math.Round(MontoNoAfectoJob, 2) = Math.Round(MontoNoAfecto, 2)) Then
                    MsgBox("Los montos de los centros de costo de Servicio Técnico no coinciden con los montos de el(los) Job(s).", MsgBoxStyle.Information, "Información")
                    Return True    'Se valida el total de los montos de los centros de costo de servicio técnico sean iguales a los montos de los job asignados
                Else
                    Return False
                End If
            Else
                Return False
            End If
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR LOS MONTOS DE CENTRO DE COSTO Y JOB" + ex.Message)
        End Try
    End Function
    Private Sub miMostrarCentroCosto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarCentroCosto.Click, dgvCentrosCosto.DoubleClick
        If ValidaCodigoSeleccionadoCentroCosto() Then
            mostrarCentroCosto()
        End If
    End Sub

    Private Sub miMostrarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarJob.Click, dgvJos.DoubleClick
        If ValidaCodigoSeleccionadoJob() Then
            mostrarJob()
        End If
    End Sub

    Private Sub miAsignarJobs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miAsignarJobs.Click
        If state_button = True Then
            NuevoJob()
        End If
    End Sub

    Private Sub miEliminarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarJob.Click
        If ValidaCodigoSeleccionadoJob() Then
            eliminarJob()
        End If
    End Sub

    Private Sub eliminarJob()
        Try
            cmOpcionesJobs.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el Job: " + dgvJos.CurrentRow.Cells("CodJob").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oSolicitudGastoDetService.BorrarJob(IdGastoDet, IdGasto, dgvJos.CurrentRow.Cells("CodJob").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtJobs = Nothing
                    listaDatosJob()
                    ObtenerRegistro()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR JOB:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActualizarJobs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizarJobs.Click
        ActualizarDetallesJob()
    End Sub

    Private Sub dgvJos_EditingCell(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.EditingCellEventArgs) Handles dgvJos.EditingCell
        Try
            Dim Check As String = ""

            If e.Column.ActAsSelector Then
                Check = Me.dgvJos.GetValue("ProcesoJob2").ToString.Trim
                If Check = False Then

                    Dim iCodJob As String
                    Dim iProcesoJob As Boolean
                    Dim estado_process As Boolean

                    iCodJob = dgvJos.CurrentRow.Cells("CodJob").Value
                    iProcesoJob = dgvJos.CurrentRow.Cells("ProcesoJob2").Value
                    estado = oSolicitudGastoService.ObtenerEstado(IdGasto)

                    If (Session.CodPerfil = "01" Or Session.CodPerfil = "24") And (iCodJob <> "" Or iCodJob <> Nothing) And (estado = 3 Or estado = 5 Or estado = 7 Or estado = 10) And Not iProcesoJob Then
                        estado_process = oSolicitudGastoDetService.ProcesarJob(IdGastoDet, IdGasto, iCodJob, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    End If

                    If estado_process = True Then
                        ActualizarDetallesJob()
                    End If
                Else
                    MsgBox("Este Documento ya ha sido Procesado")
                    ActualizarDetallesJob()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al PROCESAR el Documento : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub dgvJos_ColumnHeaderClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvJos.ColumnHeaderClick
        Try
            If dgvJos.RootTable.Columns(e.Column.Index).Caption = "P" Then

                If VerificarSeleccion() = True Then

                    If MsgBox("¿Está seguro de PROCESAR Todos los Documentos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                        Dim rows() As Janus.Windows.GridEX.GridEXRow
                        rows = dgvJos.GetCheckedRows()
                        Dim row As Janus.Windows.GridEX.GridEXRow

                        If rows.Count <> 0 Then
                            Dim estado_process As Boolean
                            For Each row In rows
                                Dim iCodJob As String
                                Dim IProcesoJob As Boolean
                                iCodJob = dgvJos.CurrentRow.Cells("CodJob").Value
                                IProcesoJob = row.Cells("ProcesoJob2").Text
                                estado = oSolicitudGastoService.ObtenerEstado(IdGasto)

                                If (Session.CodPerfil = "01" Or Session.CodPerfil = "24") And (iCodJob <> "" Or iCodJob <> Nothing) And (estado = 3 Or estado = 5 Or estado = 7 Or estado = 10) And Not IProcesoJob Then
                                    estado_process = oSolicitudGastoDetService.ProcesarJob(row.Cells("IdGastoDet").Text, row.Cells("IdGasto").Text, row.Cells("CodJob").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                                End If
                            Next
                            '=================================Enviar a Correos Seleccionados=================================
                            If estado_process Then
                                ActualizarDetallesJob()
                            Else
                                MsgBox("No se Proceso Ningun Documento porque ya ha sido Procesado o No Cumple con los Requisitos")
                                ActualizarDetallesJob()
                            End If
                        Else
                            MsgBox("Debe seleccionar alguno de los gastos a procesar")
                        End If
                    End If
                Else
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al PROCESAR los Documentos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarComprasJob()
        Try
            Dim iCodJob As String
            iCodJob = CStr(dgvJos.CurrentRow.Cells("CodJob").Value)
            If iCodJob <> "" Or iCodJob <> Nothing Then
                Dim frm As New frmComSolicitudGasto_Compras
                frm.CodJob = CStr(dgvJos.CurrentRow.Cells("CodJob").Value)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtJobs = Nothing
                    ActualizarDetallesJob()
                    ObtenerRegistro()
                End If
            Else
                MsgBox("¡Este detalle no presenta Nro de Job....!")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR COMPRAS DE JOB: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miMostrarCompras_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarCompras.Click
        If cmOpcionesJobs.Enabled = True Then
            If ValidaCodigoSeleccionadoJob() Then
                mostrarComprasJob()
            End If
        End If
    End Sub

    Private Function VerificarSeleccion() As Boolean
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        Dim Cadena As String = ""
        rows = dgvJos.GetCheckedRows()
        Dim row As Janus.Windows.GridEX.GridEXRow

        If rows.Count <> 0 Then
            For Each row In rows
                If Cadena = "" Then
                    Cadena = row.Cells("CodJob").Text
                Else
                    Cadena = Cadena + ";" + row.Cells("CodJob").Text
                End If
            Next
        End If
        If Cadena = "" Then
            VerificarSeleccion = False
        Else
            VerificarSeleccion = True
        End If
    End Function

    Private Sub miProcesarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miProcesarJob.Click
        'Try
        '    If dgvJos.RowCount > 0 Then
        '        If MsgBox("¿Está seguro de Ingresar de Ingresar los gastos a el(los) Job(s) seleccionado(s) ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
        '            Dim estado_process As Boolean
        '            Dim iCodJob As String
        '            iCodJob = dgvJos.CurrentRow.Cells("CodJob").Value
        '            estado_process = oSolicitudGastoDetService.ProcesarJob(IdGastoDet, IdGasto, iCodJob, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        '            If estado_process Then
        '                'MsgBox("Se Ingresó el Gasto al Job correctamente")
        '                ActualizarDetallesJob()
        '            Else
        '                MsgBox("Error en el proceso,comuniquese con el departamento de sistemas")
        '            End If
        '        End If
        '    Else
        '        MsgBox("No existen datos, Verifique...")
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        'End Try
    End Sub

    Private Sub txtCodEmbarque_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodEmbarque.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtCodEmbarque.Text)) > 0 Then
                If Not (oEmbarqueService.Buscar(Session.sCodEmp, txtCodEmbarque.Text)) Then
                    MsgBox("El código de embarque no es válido.")
                    txtCodEmbarque.Text = ""
                    cmbMedio.SelectedIndex = 0
                    txtCodEmbarque.Focus()
                Else
                    Dim embarque As New EmbarqueService.Embarque
                    embarque = oEmbarqueService.Obtener(txtCodEmbarque.Text)
                    cmbMedio.Value = embarque.Medio
                    txtProveedor.Focus()
                End If
            Else
                cmbMedio.SelectedIndex = 0
                txtProveedor.Focus()
            End If
        End If
    End Sub

    Private Sub txtCodEmbarque_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodEmbarque.Validated
        Try
            If Len(Trim(txtCodEmbarque.Text)) > 0 Then
                If Not (oEmbarqueService.Buscar(Session.sCodEmp, txtCodEmbarque.Text)) Then
                    MsgBox("El código de embarque no es válido.")
                    txtCodEmbarque.Text = ""
                    cmbMedio.SelectedIndex = 0
                    txtCodEmbarque.Focus()
                Else
                    Dim embarque As New EmbarqueService.Embarque
                    embarque = oEmbarqueService.Obtener(txtCodEmbarque.Text)
                    cmbMedio.Value = embarque.Medio
                    txtProveedor.Focus()
                End If
            Else
                cmbMedio.SelectedIndex = 0
                txtProveedor.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL JOB : " + ex.Message)
        End Try
    End Sub

    Private Sub btnBuscarXml_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarXml.Click
        'Dim file As New OpenFileDialog()
        ''file.Filter = "Archivo JPG|*.jpg"
        'file.Filter = "XML|*.xml"
        'If file.ShowDialog() = DialogResult.OK Then

        '    txtXmlFE.Text = file.FileName
        '    NombreArchivo = System.IO.Path.GetFileNameWithoutExtension(file.FileName)

        'End If

        '=================================================================================================== 


        Try

            '=============================================== OBTENER DATA DEL XML ==============================

            Dim file As New OpenFileDialog()
            Dim RutaArchivo As String = ""
            'file.Filter = "Archivo JPG|*.jpg"
            file.Filter = "XML|*.xml"
            If file.ShowDialog() = DialogResult.OK Then

                txtXmlFE.Text = file.FileName
                NombreArchivo = System.IO.Path.GetFileNameWithoutExtension(file.FileName)
                RutaArchivo = System.IO.Path.GetFullPath(file.FileName)

            End If

            If txtXmlFE.Text <> "" Then

                Dim xmlDocR As New XmlDocument
                xmlDocR.Load(RutaArchivo)

                '/////////OBTENER ESTADO E INFORMACION DEL CDR SUNAT/////////////////////////
                Dim namespaces As XmlNamespaceManager = New XmlNamespaceManager(xmlDocR.NameTable)
                namespaces.AddNamespace("ns", "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2")
                namespaces.AddNamespace("qdt", "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2")
                namespaces.AddNamespace("udt", "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2")
                namespaces.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")
                namespaces.AddNamespace("ccts", "urn:un:unece:uncefact:documentation:2")
                namespaces.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")
                namespaces.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#")
                namespaces.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")

                Dim xPathSupplierPartyString As String
                Dim oNodeSupplierPartID As XmlNode
                Dim SupplierPartID As String
                'Dim TipoDocumento As String

                '====================================================
                'Obtener Serie - Numero del Documento

                Dim xPathIDString = "/ns:Invoice/cbc:ID"
                Dim oNodeSerieNum = xmlDocR.SelectSingleNode(xPathIDString, namespaces)
                Dim SerNumDoc As String = oNodeSerieNum.InnerText

                Dim contadorsernum As Integer = Len(SerNumDoc)
                Dim Serie As String = Mid(SerNumDoc, 1, 4)
                Dim NumDoc As String = Mid(SerNumDoc, 6, contadorsernum - 5)
                'Dim NumDoc As String = Mid(SerNumDoc, contadorsernum - 4)
                Dim cantnumdocfinal As Integer = 0
                cantnumdocfinal = Len(NumDoc)

                Do While cantnumdocfinal < 10
                    NumDoc = "0" & NumDoc
                    cantnumdocfinal = cantnumdocfinal + 1
                Loop

                txtSerieDoc.Text = Serie
                txtNumDoc.Text = NumDoc


                '====================================================
                'Obtener Tipo de Documento

                Dim xPathInvoiceTypeString = "/ns:Invoice/cbc:InvoiceTypeCode"
                Dim oNodeInvoiceType = xmlDocR.SelectSingleNode(xPathInvoiceTypeString, namespaces)
                Dim InvoiceType As String = oNodeInvoiceType.InnerText

                cmbTipoDoc.Value = oSolicitudGastoDetService.ObtenerIdDocumentoSunat(InvoiceType)

                '===================================================
                'Obtener el Proveedor

                'TipoDocumento = Mid(SerNumDoc, 1, 1)

                'If InvoiceType = "01" And TipoDocumento = "E" Then  '' Recibo por Honorarios

                '    xPathSupplierPartyString = "/ns:Invoice/cac:AccountingSupplierParty/cbc:CustomerAssignedAccountID"
                '    oNodeSupplierPartID = xmlDocR.SelectSingleNode(xPathSupplierPartyString, namespaces)
                '    SupplierPartID = oNodeSupplierPartID.InnerText

                'Else

                xPathSupplierPartyString = "/ns:Invoice/cac:AccountingSupplierParty/cac:Party/cac:PartyIdentification/cbc:ID"
                oNodeSupplierPartID = xmlDocR.SelectSingleNode(xPathSupplierPartyString, namespaces)
                SupplierPartID = oNodeSupplierPartID.InnerText

                'End If

                'xPathSupplierPartyString = "/ns:Invoice/cac:AccountingSupplierParty/cac:Party/cac:PartyIdentification/cbc:ID"
                'oNodeSupplierPartID = xmlDocR.SelectSingleNode(xPathSupplierPartyString, namespaces)
                'SupplierPartID = oNodeSupplierPartID.InnerText

                Dim proveedor As Boolean = oProveedorService.BuscarRuc(Session.sCodEmp, SupplierPartID)

                If (proveedor) Then

                    Dim registro As ProveedorService.Proveedor
                    registro = oProveedorService.ObtenerPorRuc(Session.sCodEmp, SupplierPartID)

                    IdProveedor = registro.IdProveedor
                    txtProveedor.Text = registro.DesProv
                    cmbCondPago.Value = registro.CondicionPagoProveedor.IdCondicion

                Else
                    MsgBox("Debe registrar el proveedor primero.", MsgBoxStyle.Information)
                    'txtXmlFE.Text = ""
                    'NombreArchivo = ""
                    'RutaArchivo = ""
                    'IdProveedor = 0
                    'txtProveedor.Text = ""
                    'cmbCondPago.Value = 0 'registro.CondicionPagoProveedor.IdCondicion
                    ActivarCampos()
                    LimpiarCamposXml()
                    Exit Sub
                End If






                '===================================================
                'Obtener Fecha

                Dim xPathDateString = "/ns:Invoice/cbc:IssueDate"
                Dim oNodeDate = xmlDocR.SelectSingleNode(xPathDateString, namespaces)
                Dim Fecha As Date = CDate(oNodeDate.InnerText)

                txtFecDoc.Value = Fecha

                '===================================================
                'Obtener Monto Tax  - Payable Amount - LineExtensionAmount

                Dim xPathTaxAmountString = "/ns:Invoice/cac:TaxTotal/cbc:TaxAmount"
                Dim oNodeTaxAmount = xmlDocR.SelectSingleNode(xPathTaxAmountString, namespaces)
                Dim TaxAmount As Double = CDbl(oNodeTaxAmount.InnerText)

                Dim xPathPayableAmountString = "/ns:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount"
                Dim oNodePayableAmount = xmlDocR.SelectSingleNode(xPathPayableAmountString, namespaces)
                Dim PayableAmount As Double = CDbl(oNodePayableAmount.InnerText)

                Dim xPathLineExtensionAmountString = "/ns:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount"
                Dim oNodeLineExtensionAmount = xmlDocR.SelectSingleNode(xPathLineExtensionAmountString, namespaces)
                Dim LineExtensionAmount As Double = CDbl(oNodeLineExtensionAmount.InnerText)

                '===================================================
                'Calculando el MontoNoAfecto

                Dim MontoNoAfecto As Double = 0

                MontoNoAfecto = PayableAmount - (LineExtensionAmount + TaxAmount)

                If TaxAmount = 0 Then
                    cbAfectoIgv.Checked = False
                    txtMontoNoAfecto.Value = PayableAmount
                    txtMonto.Value = 0
                Else
                    cbAfectoIgv.Checked = True
                    txtMontoNoAfecto.Value = MontoNoAfecto
                    txtMonto.Value = PayableAmount - MontoNoAfecto
                End If


                'If InvoiceType = "01" And TipoDocumento = "E" Then  '' Recibo por Honorarios
                '    MontoNoAfecto = PayableAmount + TaxAmount
                'Else
                '    MontoNoAfecto = PayableAmount - (LineExtensionAmount + TaxAmount)
                'End If

                'If InvoiceType = "01" And TipoDocumento = "E" Then  '' Recibo por Honorarios
                '    cbAfectoIgv.Checked = False
                '    txtMontoNoAfecto.Value = MontoNoAfecto
                '    txtMonto.Value = 0
                'Else
                '    If TaxAmount = 0 Then
                '        cbAfectoIgv.Checked = False
                '        txtMontoNoAfecto.Value = PayableAmount
                '        txtMonto.Value = 0
                '    Else
                '        cbAfectoIgv.Checked = True

                '        txtMontoNoAfecto.Value = MontoNoAfecto
                '        txtMonto.Value = PayableAmount
                '    End If
                'End If


                Dim MontoSinIgv As Double
                MontoSinIgv = IIf(cbAfectoIgv.Checked = True, (txtMonto.Value / ((txtIgv.Value + 100) / 100)) + txtMontoNoAfecto.Value, txtMontoNoAfecto.Value)
                txtMontoSinIgv.Value = MontoSinIgv
                txtMontoTotal.Value = txtMonto.Value + txtMontoNoAfecto.Value
                txtMontoIgv.Value = IIf(cbAfectoIgv.Checked = True, txtMonto.Value - txtMontoSinIgv.Value + txtMontoNoAfecto.Value, 0)

                End If

                DesactivarCampos()

        Catch ex As Exception
            MsgBox("Error al obtener los datos. El archivo xml no tiene el formato requerido : " + ex.Message, MsgBoxStyle.Information)
            ActivarCampos()
            LimpiarCamposXml()
        End Try

    End Sub

    Private Sub DesactivarCampos()

        cmbTipoDoc.ReadOnly = True
        cmbTipoDoc.BackColor = System.Drawing.SystemColors.Control
        txtSerieDoc.ReadOnly = True
        txtSerieDoc.BackColor = System.Drawing.SystemColors.Control
        txtNumDoc.ReadOnly = True
        txtNumDoc.BackColor = System.Drawing.SystemColors.Control
        txtFecDoc.ReadOnly = True
        txtFecDoc.BackColor = System.Drawing.SystemColors.Control
        btnBuscarProveedor.Enabled = False
        btnAgregarProveedor.Enabled = False
        btnLimpiarProveedor.Enabled = False
        'cmbCondPago.ReadOnly = True
        'cmbCondPago.BackColor = System.Drawing.SystemColors.Control
        'cbAfectoIgv.Enabled = False
        'cbAfectoIgv.BackColor = System.Drawing.SystemColors.Control
        'txtMonto.ReadOnly = True
        'txtMonto.BackColor = System.Drawing.SystemColors.Control
        'txtMontoNoAfecto.ReadOnly = True
        'txtMontoNoAfecto.BackColor = System.Drawing.SystemColors.Control

    End Sub

    Private Sub ActivarCampos()

        cmbTipoDoc.ReadOnly = False
        cmbTipoDoc.BackColor = System.Drawing.SystemColors.Window
        txtSerieDoc.ReadOnly = False
        txtSerieDoc.BackColor = System.Drawing.SystemColors.Window
        txtNumDoc.ReadOnly = False
        txtNumDoc.BackColor = System.Drawing.SystemColors.Window
        txtFecDoc.ReadOnly = False
        txtFecDoc.BackColor = System.Drawing.SystemColors.Window
        btnBuscarProveedor.Enabled = True
        btnAgregarProveedor.Enabled = True
        btnLimpiarProveedor.Enabled = True
        'cmbCondPago.ReadOnly = False
        'cmbCondPago.BackColor = System.Drawing.SystemColors.Window
        'cbAfectoIgv.Enabled = True
        'cbAfectoIgv.BackColor = System.Drawing.SystemColors.Control
        'txtMonto.ReadOnly = False
        'txtMonto.BackColor = System.Drawing.SystemColors.Window
        'txtMontoNoAfecto.ReadOnly = False
        'txtMontoNoAfecto.BackColor = System.Drawing.SystemColors.Window

    End Sub

    Private Sub LimpiarCamposXml()

        cmbTipoDoc.Value = 0
        txtSerieDoc.Text = ""
        txtNumDoc.Text = ""
        txtFecDoc.Value = Today.Date
        IdProveedor = 0
        txtProveedor.Text = ""
        cmbCondPago.Value = 0
        txtMonto.Value = 0.00
        txtMontoNoAfecto.Value = 0.00
        txtMontoSinIgv.Value = 0.00
        txtMontoIgv.Value = 0.0
        txtMontoTotal.Value = 0.00

    End Sub
    Private Sub btnBuscarPdf_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarPdf.Click
        Dim file As New OpenFileDialog()
        'file.Filter = "Archivo JPG|*.jpg"
        file.Filter = "PDF|*.pdf"
        If file.ShowDialog() = DialogResult.OK Then

            txtPdfFE.Text = file.FileName
            NombreArchivo = System.IO.Path.GetFileNameWithoutExtension(file.FileName)
        End If
    End Sub

    Private Sub biLimpiarXml_Click(sender As System.Object, e As System.EventArgs) Handles biLimpiarXml.Click
        txtXmlFE.Text = ""
    End Sub

    Private Sub biLimpiarPdf_Click(sender As System.Object, e As System.EventArgs) Handles biLimpiarPdf.Click
        txtPdfFE.Text = ""
    End Sub

    Private Sub txtFecDoc_ValueChanged(sender As Object, e As System.EventArgs) Handles txtFecDoc.ValueChanged
        If toBlank(txtFecDoc.Value) <> "" Then
            txtTipCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio(Moneda, txtFecDoc.Value)), "#0.000")
        End If
    End Sub

    'Private Sub cbComputo_CheckedChanged(sender As Object, e As System.EventArgs)
    '    If cbComputo.Enabled = True Then
    '        If cbComputo.Checked = True Then
    '            cmbRubro.SelectedIndex = 0
    '            cmbRubro.ReadOnly = False
    '            cmbRubro.BackColor = System.Drawing.SystemColors.Window
    '            cmbRubro.Visible = True
    '            lblRubro.Visible = True
    '        Else
    '            cmbRubro.SelectedIndex = 0
    '            cmbRubro.ReadOnly = True
    '            cmbRubro.BackColor = System.Drawing.SystemColors.Control
    '            cmbRubro.Visible = False
    '            lblRubro.Visible = False
    '        End If
    '    End If
    'End Sub

    Private Sub cmbTipoGasto_ValueChanged(sender As Object, e As System.EventArgs) Handles cmbTipoGasto.ValueChanged
        ObtenerObservacionTipoGasto()
        LlenarRubroGasto()
    End Sub

    Private Sub LlenarRubroGasto()
        Try

            '========================================== RUBROS ===============================================
            dtRubros = oSolicitudGastoDetService.MostrarRubros(cmbTipoGasto.Value).Tables(0)

            'If dtRubros.Rows.Count > 0 Then
            'cbComputo.Enabled = True
            'If cbComputo.Checked = True Then
            'cmbRubro.ReadOnly = False
            'cmbRubro.BackColor = System.Drawing.SystemColors.Window
            'cmbRubro.Visible = True
            'lblRubro.Visible = True
            'End If
            'Else
            'cbComputo.Enabled = False
            'cbComputo.Checked = False
            'cmbRubro.ReadOnly = True
            'cmbRubro.BackColor = System.Drawing.SystemColors.Control
            'cmbRubro.Visible = False
            'lblRubro.Visible = False
            'End If

            dtRubros.Rows.InsertAt(getRowTodos1(dtRubros), 0)

            cmbRubro.DataSource = dtRubros
            cmbRubro.DropDownList.DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubros.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.SelectedIndex = 0
            dtRubros = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR RUBRO GASTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerObservacionTipoGasto()
        If cmbTipoGasto.SelectedIndex <> 0 Then
            txtObservTipoGasto.Text = toBlank(cmbTipoGasto.DropDownList.GetRow.Cells(2).Text)  'Obtiene el Texto de la 3 columna del Combo TipoGasto
        Else
            txtObservTipoGasto.Text = ""
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub txtMontoSinIgv_TextChanged(sender As Object, e As EventArgs) Handles txtMontoSinIgv.TextChanged
        CalcularMontos()
    End Sub

    'Private Sub btnDatosXml_Click(sender As Object, e As EventArgs) Handles btnDatosXml.Click

    '    Dim file As New OpenFileDialog()
    '    'file.Filter = "Archivo JPG|*.jpg"
    '    file.Filter = "XML|*.xml"
    '    If file.ShowDialog() = DialogResult.OK Then

    '        txtXmlFE.Text = file.FileName
    '        NombreArchivo = System.IO.Path.GetFileNameWithoutExtension(file.FileName)

    '    End If

    '    Dim RutaArchivo As String
    '    RutaArchivo = System.IO.Path.GetFullPath(file.FileName)

    '    Dim xmlDocR As New XmlDocument
    '    xmlDocR.Load(RutaArchivo)

    '    '/////////OBTENER ESTADO E INFORMACION DEL CDR SUNAT/////////////////////////
    '    Dim namespaces As XmlNamespaceManager = New XmlNamespaceManager(xmlDocR.NameTable)
    '    namespaces.AddNamespace("ns", "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2")
    '    namespaces.AddNamespace("qdt", "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2")
    '    namespaces.AddNamespace("udt", "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2")
    '    namespaces.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")
    '    namespaces.AddNamespace("ccts", "urn:un:unece:uncefact:documentation:2")
    '    namespaces.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")
    '    namespaces.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#")
    '    namespaces.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")

    '    '====================================================
    '    'Obtener Tipo de Documento

    '    Dim xPathInvoiceTypeString = "/ns:Invoice/cbc:InvoiceTypeCode"
    '    Dim oNodeInvoiceType = xmlDocR.SelectSingleNode(xPathInvoiceTypeString, namespaces)
    '    Dim InvoiceType As String = oNodeInvoiceType.InnerText

    '    cmbTipoDoc.Value = oSolicitudGastoDetService.ObtenerIdDocumentoSunat(InvoiceType)

    '    '====================================================
    '    'Obtener Serie - Numero del Documento

    '    Dim xPathIDString = "/ns:Invoice/cbc:ID"
    '    Dim oNodeSerieNum = xmlDocR.SelectSingleNode(xPathIDString, namespaces)
    '    Dim SerNumDoc As String = oNodeSerieNum.InnerText

    '    Dim contadorsernum As Integer = Len(SerNumDoc)
    '    Dim Serie As String = Mid(SerNumDoc, 1, 4)
    '    Dim NumDoc As String = Mid(SerNumDoc, contadorsernum - 4)
    '    Dim cantnumdocfinal As Integer = 0
    '    cantnumdocfinal = Len(NumDoc)

    '    Do While cantnumdocfinal < 10
    '        NumDoc = "0" & NumDoc
    '        cantnumdocfinal = cantnumdocfinal + 1
    '    Loop

    '    txtSerieDoc.Text = Serie
    '    txtNumDoc.Text = NumDoc

    '    '===================================================
    '    'Obtener Fecha

    '    Dim xPathDateString = "/ns:Invoice/cbc:IssueDate"
    '    Dim oNodeDate = xmlDocR.SelectSingleNode(xPathDateString, namespaces)
    '    Dim Fecha As Date = CDate(oNodeDate.InnerText)

    '    txtFecDoc.Value = Fecha

    '    '===================================================
    '    'Obtener Monto Tax 

    '    Dim xPathTaxAmountString = "/ns:Invoice/cac:TaxTotal/cbc:TaxAmount"
    '    Dim oNodeTaxAmount = xmlDocR.SelectSingleNode(xPathTaxAmountString, namespaces)
    '    Dim TaxAmount As Double = CDbl(oNodeTaxAmount.InnerText)

    '    Dim xPathPayableAmountString = "/ns:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount"
    '    Dim oNodePayableAmount = xmlDocR.SelectSingleNode(xPathPayableAmountString, namespaces)
    '    Dim PayableAmount As Double = CDbl(oNodePayableAmount.InnerText)

    '    If TaxAmount = 0 Then
    '        cbAfectoIgv.Checked = False
    '        txtMontoNoAfecto.Value = PayableAmount
    '    Else
    '        cbAfectoIgv.Checked = True
    '        txtMonto.Value = PayableAmount


    '    End If

    '    Dim MontoSinIgv As Double
    '    MontoSinIgv = IIf(cbAfectoIgv.Checked = True, (txtMonto.Value / ((txtIgv.Value + 100) / 100)) + txtMontoNoAfecto.Value, txtMontoNoAfecto.Value)
    '    txtMontoSinIgv.Value = MontoSinIgv
    '    txtMontoTotal.Value = txtMonto.Value + txtMontoNoAfecto.Value
    '    txtMontoIgv.Value = IIf(cbAfectoIgv.Checked = True, txtMonto.Value - txtMontoSinIgv.Value + txtMontoNoAfecto.Value, 0)

    '    '===================================================
    '    'Obtener el Proveedor

    '    Dim xPathSupplierPartyString = "/ns:Invoice/cac:AccountingSupplierParty/cac:Party/cac:PartyIdentification/cbc:ID"
    '    Dim oNodeSupplierPartID = xmlDocR.SelectSingleNode(xPathSupplierPartyString, namespaces)
    '    Dim SupplierPartID As String = oNodeSupplierPartID.InnerText

    '    Dim proveedor As Boolean = oProveedorService.BuscarRuc(Session.sCodEmp, SupplierPartID)

    '    If (proveedor) Then

    '        Dim registro As ProveedorService.Proveedor
    '        registro = oProveedorService.ObtenerPorRuc(Session.sCodEmp, SupplierPartID)

    '        IdProveedor = registro.IdProveedor
    '        txtProveedor.Text = registro.DesProv
    '        cmbCondPago.Value = registro.CondicionPagoProveedor.IdCondicion

    '    Else
    '        MsgBox("Debe registrar el proveedor primero.")
    '    End If

    'End Sub

End Class