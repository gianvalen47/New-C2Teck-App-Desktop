<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MDIPrincipal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIPrincipal))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblUsuario = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblTransa = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.rbbMTU = New Janus.Windows.Ribbon.Ribbon()
        Me.btnCambiarEmpresa = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCerrarSesion = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbTabVentas = New Janus.Windows.Ribbon.RibbonTab()
        Me.rbbVenDocumentos = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnVenDocGuiasRemision = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenDocGuiasDevolucion = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenDocFacturas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenDocBoletas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenDocNotas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenDocResumen = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbVenPrePostVenta = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnVenPreCotizaciones = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenPreOrdenesCompra = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenReclamo = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenPostActuVendedor = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenSepararOrden = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenEnvioCorreo = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbVenClientes = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnVenCliCartera = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbVenRequisiciones = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnVenReqDespachos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbVenConsultas = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnVenConPrecios = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenConDocumentos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbVenIndicadores = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnVenIndTablero = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbVenPrecios = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnVenPreciosCliente = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenPreciosLista = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenPreciosOferta = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenPreciosFabricantes = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenPreciosRubrosEmpresa = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbVenReportes = New Janus.Windows.Ribbon.RibbonGroup()
        Me.ddcVenRepRegistroVenta = New Janus.Windows.Ribbon.DropDownCommand()
        Me.ddcVenRepRegistro = New Janus.Windows.Ribbon.DropDownCommand()
        Me.ddcVenRepRegistroAuxiliar = New Janus.Windows.Ribbon.DropDownCommand()
        Me.ddcVenRepRegistroResumen = New Janus.Windows.Ribbon.DropDownCommand()
        Me.btnVenRepVentaDetalle = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenRepVentaAcumulada = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenRepVentaGuias = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenRepCotizaciones = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenRepVentaRequisiciones = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenRepMensualesxCliente = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenRepDetalleDescuento = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenRepReclamos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenRepOrdenes = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenRepConsignacion = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenRepTodoGuiaRemision = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenRepPresupuestoVenta = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnVenRepComisiones = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbTabAlmacenes = New Janus.Windows.Ribbon.RibbonTab()
        Me.rbbAlmAlmacen = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnAlmAlmDocumentos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAlmAlmDocumentoSalidas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAlmAlmChequeoFI = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAlmAlmTI = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAlmAlmMTI = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAlmAlmValesMate = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAlmAlmAtenderJob = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAlmAlmDespacho = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAlmAlmDatosDespacho = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbAlmMotores = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnAlmMotTransferencias = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAlmMotCompras = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbAlmTransito = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnAlmTraDocumentos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAlmTraAnulacionGuia = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbAlmMantenimiento = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnAlmManMercaderias = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAlmManLiquiGastos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAlmManMinMax = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAlmManUbicacion = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbAlmConsultas = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnAlmConTarjetas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAlmConDocumentos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbAlmIndicadores = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnAlmIndCalendario = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAlmIndProcesoCobertura = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAlmIndTablero = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbAlmReportes = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnAlmRepInventario = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAlmRepTomaInventario = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAlmRepMovimientos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAlmRepValeMaterial = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAlmRepDocumento = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAlmRepInvPermanente = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAlmRepSinMovimiento = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAlmRepTransferencia = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbTabCréditos = New Janus.Windows.Ribbon.RibbonTab()
        Me.rbbCreDocumentos = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnCreDocCuentas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCreDocPlanillas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCreDocAnticipos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCreDocLetras = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbCreAprobaciones = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnCreAprCreditos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCreAprCotizaciones = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCreAprPerUsuario = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCreAprRecepcionDoc = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbCreMantenimiento = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnCreManFacDesc = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCreManBancos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCreManVisitaCobrador = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCreManProcesarGuias = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCreManVincularGuias = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCreManFeriados = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCreManTipoCambio = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCreManRenuevaTC = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCreMantenimientoTipoCambio = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbCreConsultas = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnCreConCuentas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCreConVencimientos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCreConTarjetaCliente = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbCreReportes = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnCreRepCtasCtes = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCreRepDiarioPago = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCreRepDocEmitido = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCreRepLetra = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCreRepNotasDebito = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCreRepPlanilla = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCreRepVisitaCobrador = New Janus.Windows.Ribbon.ButtonCommand()
        Me.ddcCreRepVencimientos = New Janus.Windows.Ribbon.DropDownCommand()
        Me.ddcCreRepVencimientoDetalle = New Janus.Windows.Ribbon.DropDownCommand()
        Me.ddcCreRepVencimientoAcumulado = New Janus.Windows.Ribbon.DropDownCommand()
        Me.btnCreRepClientes = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbTabImportaciones = New Janus.Windows.Ribbon.RibbonTab()
        Me.rbbImpImportaciones = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnImpImpDocumentos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnImpImpEmbarque = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbImpPedidos = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnImpPedImportacion = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnImpPedInternos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbImpConsultas = New Janus.Windows.Ribbon.RibbonGroup()
        Me.rbbImpReportes = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnImpRepPedidoImp = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnImpRepEmbarques = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnImpRepPedido = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbTabCostos = New Janus.Windows.Ribbon.RibbonTab()
        Me.rbbCostoImportaciones = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnCostoValorizarImp = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbCostoProcesos = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnCostoRecalcular = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCostoAjustarCierre = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCostoCerrarMes = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCostoConsolidado = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCostoProTrasladarCosto = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCostoProGenerarPeriodo = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCostoProInvRotativo = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbCostoDocumentos = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnCostoActualizarDocs = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbCostoReportes = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnCostoRepImportaciones = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCostoDiarioAlmacen = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCostoStockValorizado = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCostoRepCierreMes = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCostoRepKardex = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCostoRepCostoVenta = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCostoRepCondensado = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCostoRepMotores = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCostoRepResumenGen = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCostoRepSobregiro = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCostoRepGMROI = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbTabGerencia = New Janus.Windows.Ribbon.RibbonTab()
        Me.rbbGerReportes = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnGerVentas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnGerImportaciones = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnGerInventario = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnGerContabilidad = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnGerCreditos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnGerServicios = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnGerFiltroIndicadores = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnGerTarjeta = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnGerConsolidado = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnGerEstadosFinancieros = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbTabServicios = New Janus.Windows.Ribbon.RibbonTab()
        Me.rbbSerAlmacen = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnSerPedirRepuesto = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbSerVentas = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnSerCotizacion = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbSerJob = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnSerSolicitudJob = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerJob = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerMarcacionJob = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerGastoReal = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerGastoViaje = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerPreMarcacionJob = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerMarcacionOT = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbSerGarantia = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnSerAfa = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerReclamoCliente = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbSerVehiculos = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnSerKilometraje = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbSerMantenimiento = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnSerManOficinaUsuario = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbSerConsultas = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnSerConJob = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerConMarcacionJob = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerConGastoRealJob = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbSerIndicadores = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnSerIndActividades = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerIndProgramacion = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerIndPlantilla = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerIndTablero = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerIndProductividad = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbSerProyeccion = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnSerProHorasMotor = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerProEquipos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerProSeguimiento = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerProRepuestos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerProGenerarPedidoInterno = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbSerReportes = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnSerRepMovRepuesto = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerRepHorasEscalon = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerRepHorasGenerales = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerRepCostosDirectos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerRepGastosPorRubro = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerRepGastosViajePorRubro = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerRepJobPendienteFacturacion = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerRepJobGarantias = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerRepTiempoReparacion = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerRepAfas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerRepCotizaciones = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerRepSolicitudJob = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerRepJob = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSerRepHorasMuertas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.ddcSerRepProyeccion = New Janus.Windows.Ribbon.DropDownCommand()
        Me.btnSerRepHorasMotores = New Janus.Windows.Ribbon.DropDownCommand()
        Me.btnSerRepSeguimientos = New Janus.Windows.Ribbon.DropDownCommand()
        Me.btnSerRepMotorDarBaja = New Janus.Windows.Ribbon.DropDownCommand()
        Me.btnSerRepDisponibilidad = New Janus.Windows.Ribbon.DropDownCommand()
        Me.btnSerRepProyeccionRepImportar = New Janus.Windows.Ribbon.DropDownCommand()
        Me.btnSerRepProyeccionVentas = New Janus.Windows.Ribbon.DropDownCommand()
        Me.btnSerRepProyeccionReparaciones = New Janus.Windows.Ribbon.DropDownCommand()
        Me.rbbTabCompras = New Janus.Windows.Ribbon.RibbonTab()
        Me.rbbComCompras = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnComSolicitud = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnComOrdenCompra = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnComCotizacionSolicitud = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbComControl = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnComSolicitudGasto = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnComMesaControl = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnComPlanillaViatico = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnComTarifa = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnComTarifaCasa = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnComTarifaDestino = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnComCuentasPorPagar = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbComConsultas = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnComConsultaCompras = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbComReportes = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnComRepOrdenes = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnComRepSolicitudGasto = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnComRepMesaControl = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnComRepVencimientosCtasPorPagar = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnComRepCtasPorPagar = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnComRepPagosCuentasPorPagar = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnComRepCtasPorPagarUnidad = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbTabPersonal = New Janus.Windows.Ribbon.RibbonTab()
        Me.rbbPerInformacion = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnPerInfDatos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerInfVacaciones = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerInfContratos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerInfCapacitacion = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerInfEvaluacion = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbPerPlanilla = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnPerPlanilla = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerQuintaCategoria = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbPerAsignaciones = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnPerAsigFaltas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerAsigMarcas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerAsigHoraExtra = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerAsigHorario = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerRegistroHoraExtra = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerAsigIngresos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerAsigDescuentos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerAsigJefes = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerAsigRecursos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerAsigCronogramaMina = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerMarcaccionOnline = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbPerComunicaciones = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnPerComAdminLector = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerComProcesarMarcas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbPerReportes = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnPerRepPlanillaSueldos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerRepAsistencia = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerRepAsignacionHoraExtra = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerRepHoraExtra = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerRepTardanzas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerRepFaltas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerRepIngresos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerRepDescuentos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerRepRecursos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerRepVacaciones = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerRepPersonal = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerRepCapacitacion = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerRepContratos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerRepOnomasticos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerRepCronogramaMina = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerRepAsigHorario = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbTabRondas = New Janus.Windows.Ribbon.RibbonTab()
        Me.rbbRondasAsignacion = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnPuntosControlRutas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnRuteadorRutas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnRondas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbRondasReporte = New Janus.Windows.Ribbon.RibbonGroup()
        Me.rbbTabContabilidad = New Janus.Windows.Ribbon.RibbonTab()
        Me.rbbContaTesoreria = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnConTesoreria = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnConMovimientoBanco = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbContaCompras = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnConRegistroCompra = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnConReciboHonorario = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbContaContabilidad = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnConDiario = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbContaCajaChica = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnConProvisional = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnConReembolso = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnConArqueoCaja = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbContaProcesos = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnConProCuentaDestino = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnConProCierreMes = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnConProDifTipoCambio = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnConGenerarTXTLibros = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnConProFlujoCaja = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbContaReportes = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnConRepCtasPorPagar = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnConRepVencimientos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnConRepReembolso = New Janus.Windows.Ribbon.ButtonCommand()
        Me.ddcConRepLibrosOficiales = New Janus.Windows.Ribbon.DropDownCommand()
        Me.btnConRepLibroDiario = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnConRepLibroMayor = New Janus.Windows.Ribbon.DropDownCommand()
        Me.btnConRepCajaBancos = New Janus.Windows.Ribbon.DropDownCommand()
        Me.btnConRepRegistroCompra = New Janus.Windows.Ribbon.DropDownCommand()
        Me.btnConRepCtasCtes = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnConRepCtasCtesPend = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnConRepMayorAuxiliar = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnConRepEstadosFinancieros = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnConRepChequesGirados = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnConRepProvisionales = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbTabTelefonia = New Janus.Windows.Ribbon.RibbonTab()
        Me.rbbTelefoniaMante = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnTelModelos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnTelEquipos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnTelPlanes = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbTelefoniaAsigna = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnTelLineas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnTelAsignaLinea = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbTelefoniaReporte = New Janus.Windows.Ribbon.RibbonGroup()
        Me.rbbTabCRM = New Janus.Windows.Ribbon.RibbonTab()
        Me.rbbCRMOportunidad = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnCRMOportIngresar = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCRMOcurrencias = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCRMTarjetaCliente = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCRMVisitas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCRMCuotas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbCRMReportes = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnCRMRepOportunidad = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCRMRepVisitas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbTabActivos = New Janus.Windows.Ribbon.RibbonTab()
        Me.rbbActivoDatos = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnActivoDatos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbActivoReportes = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnActivoReporte = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbTabTablas = New Janus.Windows.Ribbon.RibbonTab()
        Me.rbbTabTabVentas = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnTabVenClientes = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnTabCondicionPagoCliente = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbTabTabAlmacen = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnTabAlmMercaderias = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnTabAlmTipoMotores = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnTabAlmModelos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnTabAlmClases = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnTabAlmPreciosCore = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbTabTabImportacion = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnTabImpPartidas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnTabImpMarcas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbTabTabServicios = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnPlantillaRepuesto = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPlantillaRepuestoCliente = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnManteUbicaServicio = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnTabManteVehiculos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbTabTabCompras = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnproveedores = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnCondicionPagoProveedores = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbTabTabContabilidad = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnManteCuentaContable = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnManteCuentaDestino = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbTabTabPersonal = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnManteRubroPlanilla = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnManteRubroPlanillaCuentas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnManteHorarios = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnManteFeriadoPersonal = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnManteAfp = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnManteCargos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnManteAreas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnManteMotFaltas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnManteEquipoLector = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnManteTipoHoraExtra = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbTabTabRondas = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnManteRuteador = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnManteRutas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnMantePuntosControl = New Janus.Windows.Ribbon.ButtonCommand()
        Me.RibbonTab1 = New Janus.Windows.Ribbon.RibbonTab()
        Me.RibbonGroup1 = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnLogueoCerrarSesion = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnLogueoCambiarClave = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnLogueoEmpresas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbTabAdministracion = New Janus.Windows.Ribbon.RibbonTab()
        Me.rbbAdminSeguridad = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnUsuarios = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnPerfiles = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnSesiones = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbAdminUsuarios = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnAtencionSolicitud = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbAdminReportes = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnAdminIndicadorSolicitud = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbAdminEncuestas = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnAdminEncuesta = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAdminResultadoEncuesta = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbAdminSoftware = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnAdminSoftwareAsignar = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAdminSoftwareComputadora = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbAdminLlamadas = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnAdminLlamadas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbAdminTablas = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnAdminEquiposMarcacion = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAdminEmpresas = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAdminSeriesDocumentos = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAdminLocaciones = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAdminRubros = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAdminParametrosLocacion = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAdminParametrosPlanilla = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAdminRubroEmpresa = New Janus.Windows.Ribbon.ButtonCommand()
        Me.rbbTabAyuda = New Janus.Windows.Ribbon.RibbonTab()
        Me.RibbonGroup2 = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnSolicitudUsuario = New Janus.Windows.Ribbon.ButtonCommand()
        Me.RibbonGroup3 = New Janus.Windows.Ribbon.RibbonGroup()
        Me.btnAyuda = New Janus.Windows.Ribbon.ButtonCommand()
        Me.btnAcerca = New Janus.Windows.Ribbon.ButtonCommand()
        Me.TVEmerg = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip.SuspendLayout()
        CType(Me.rbbMTU, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel, Me.lblUsuario, Me.ToolStripStatusLabel1, Me.lblTransa})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 1047)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip.Size = New System.Drawing.Size(1761, 22)
        Me.StatusStrip.TabIndex = 1
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(0, 17)
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = False
        Me.lblUsuario.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblUsuario.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(350, 17)
        Me.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'lblTransa
        '
        Me.lblTransa.AutoSize = False
        Me.lblTransa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblTransa.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTransa.Name = "lblTransa"
        Me.lblTransa.Size = New System.Drawing.Size(500, 17)
        Me.lblTransa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rbbMTU
        '
        Me.rbbMTU.ControlBoxMenu.LeftCommands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnCambiarEmpresa, Me.btnCerrarSesion})
        Me.rbbMTU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbbMTU.ItemRows = 2
        Me.rbbMTU.Location = New System.Drawing.Point(0, 0)
        Me.rbbMTU.Name = "rbbMTU"
        Me.rbbMTU.Size = New System.Drawing.Size(1761, 124)
        '
        '
        '
        Me.rbbMTU.SuperTipComponent.AutoPopDelay = 2000
        Me.rbbMTU.SuperTipComponent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbbMTU.SuperTipComponent.ImageList = Nothing
        Me.rbbMTU.SuperTipComponent.ShowAlways = True
        Me.rbbMTU.SuperTipWidth = 250
        Me.rbbMTU.TabIndex = 0
        Me.rbbMTU.Tabs.AddRange(New Janus.Windows.Ribbon.RibbonTab() {Me.rbbTabVentas, Me.rbbTabAlmacenes, Me.rbbTabCréditos, Me.rbbTabImportaciones, Me.rbbTabCostos, Me.rbbTabGerencia, Me.rbbTabServicios, Me.rbbTabCompras, Me.rbbTabPersonal, Me.rbbTabRondas, Me.rbbTabContabilidad, Me.rbbTabTelefonia, Me.rbbTabCRM, Me.rbbTabActivos, Me.rbbTabTablas, Me.RibbonTab1, Me.rbbTabAdministracion, Me.rbbTabAyuda})
        '
        'btnCambiarEmpresa
        '
        Me.btnCambiarEmpresa.Image = CType(resources.GetObject("btnCambiarEmpresa.Image"), System.Drawing.Image)
        Me.btnCambiarEmpresa.Key = "ButtonCommand1"
        Me.btnCambiarEmpresa.Name = "btnCambiarEmpresa"
        Me.btnCambiarEmpresa.Shortcut = System.Windows.Forms.Shortcut.CtrlE
        Me.btnCambiarEmpresa.Text = "Cambiar Empresa"
        '
        'btnCerrarSesion
        '
        Me.btnCerrarSesion.Image = CType(resources.GetObject("btnCerrarSesion.Image"), System.Drawing.Image)
        Me.btnCerrarSesion.Key = "ButtonCommand1"
        Me.btnCerrarSesion.Name = "btnCerrarSesion"
        Me.btnCerrarSesion.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.btnCerrarSesion.Text = "Cerrar Sesión"
        '
        'rbbTabVentas
        '
        Me.rbbTabVentas.Groups.AddRange(New Janus.Windows.Ribbon.RibbonGroup() {Me.rbbVenDocumentos, Me.rbbVenPrePostVenta, Me.rbbVenClientes, Me.rbbVenRequisiciones, Me.rbbVenConsultas, Me.rbbVenIndicadores, Me.rbbVenPrecios, Me.rbbVenReportes})
        Me.rbbTabVentas.Key = "2"
        Me.rbbTabVentas.KeyTip = "Ventas"
        Me.rbbTabVentas.Name = "rbbTabVentas"
        Me.rbbTabVentas.Text = "Ventas"
        '
        'rbbVenDocumentos
        '
        Me.rbbVenDocumentos.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnVenDocGuiasRemision, Me.btnVenDocGuiasDevolucion, Me.btnVenDocFacturas, Me.btnVenDocBoletas, Me.btnVenDocNotas, Me.btnVenDocResumen})
        Me.rbbVenDocumentos.ImageKey = ""
        Me.rbbVenDocumentos.Key = "RibbonGroup1"
        Me.rbbVenDocumentos.Name = "rbbVenDocumentos"
        Me.rbbVenDocumentos.Text = "Documentos"
        '
        'btnVenDocGuiasRemision
        '
        Me.btnVenDocGuiasRemision.Icon = CType(resources.GetObject("btnVenDocGuiasRemision.Icon"), System.Drawing.Icon)
        Me.btnVenDocGuiasRemision.Key = "16"
        Me.btnVenDocGuiasRemision.KeyTip = "Guía Remisión"
        Me.btnVenDocGuiasRemision.Name = "btnVenDocGuiasRemision"
        Me.btnVenDocGuiasRemision.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenDocGuiasRemision.Text = "Guía Remisión"
        '
        'btnVenDocGuiasDevolucion
        '
        Me.btnVenDocGuiasDevolucion.Icon = CType(resources.GetObject("btnVenDocGuiasDevolucion.Icon"), System.Drawing.Icon)
        Me.btnVenDocGuiasDevolucion.Key = "19"
        Me.btnVenDocGuiasDevolucion.KeyTip = "Guía Devolución"
        Me.btnVenDocGuiasDevolucion.Name = "btnVenDocGuiasDevolucion"
        Me.btnVenDocGuiasDevolucion.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenDocGuiasDevolucion.Text = "Guía Devolución"
        '
        'btnVenDocFacturas
        '
        Me.btnVenDocFacturas.Icon = CType(resources.GetObject("btnVenDocFacturas.Icon"), System.Drawing.Icon)
        Me.btnVenDocFacturas.Key = "17"
        Me.btnVenDocFacturas.Name = "btnVenDocFacturas"
        Me.btnVenDocFacturas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenDocFacturas.Text = "Factura"
        '
        'btnVenDocBoletas
        '
        Me.btnVenDocBoletas.Icon = CType(resources.GetObject("btnVenDocBoletas.Icon"), System.Drawing.Icon)
        Me.btnVenDocBoletas.Key = "18"
        Me.btnVenDocBoletas.Name = "btnVenDocBoletas"
        Me.btnVenDocBoletas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenDocBoletas.Text = "Boleta"
        '
        'btnVenDocNotas
        '
        Me.btnVenDocNotas.Icon = CType(resources.GetObject("btnVenDocNotas.Icon"), System.Drawing.Icon)
        Me.btnVenDocNotas.Key = "20"
        Me.btnVenDocNotas.Name = "btnVenDocNotas"
        Me.btnVenDocNotas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenDocNotas.Text = "Notas"
        '
        'btnVenDocResumen
        '
        Me.btnVenDocResumen.Image = CType(resources.GetObject("btnVenDocResumen.Image"), System.Drawing.Image)
        Me.btnVenDocResumen.Key = "ButtonCommand1"
        Me.btnVenDocResumen.Name = "btnVenDocResumen"
        Me.btnVenDocResumen.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenDocResumen.Text = "Resumen de Boletas"
        '
        'rbbVenPrePostVenta
        '
        Me.rbbVenPrePostVenta.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnVenPreCotizaciones, Me.btnVenPreOrdenesCompra, Me.btnVenReclamo, Me.btnVenPostActuVendedor, Me.btnVenSepararOrden, Me.btnVenEnvioCorreo})
        Me.rbbVenPrePostVenta.ImageKey = ""
        Me.rbbVenPrePostVenta.Key = "RibbonGroup2"
        Me.rbbVenPrePostVenta.Name = "rbbVenPrePostVenta"
        Me.rbbVenPrePostVenta.Text = "Pre y Post Venta"
        '
        'btnVenPreCotizaciones
        '
        Me.btnVenPreCotizaciones.Image = CType(resources.GetObject("btnVenPreCotizaciones.Image"), System.Drawing.Image)
        Me.btnVenPreCotizaciones.Key = "21"
        Me.btnVenPreCotizaciones.Name = "btnVenPreCotizaciones"
        Me.btnVenPreCotizaciones.Shortcut = System.Windows.Forms.Shortcut.CtrlF3
        Me.btnVenPreCotizaciones.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenPreCotizaciones.Text = "Cotizaciones"
        '
        'btnVenPreOrdenesCompra
        '
        Me.btnVenPreOrdenesCompra.Image = CType(resources.GetObject("btnVenPreOrdenesCompra.Image"), System.Drawing.Image)
        Me.btnVenPreOrdenesCompra.Key = "22"
        Me.btnVenPreOrdenesCompra.Name = "btnVenPreOrdenesCompra"
        Me.btnVenPreOrdenesCompra.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenPreOrdenesCompra.Text = "Ordenes Compra"
        '
        'btnVenReclamo
        '
        Me.btnVenReclamo.Icon = CType(resources.GetObject("btnVenReclamo.Icon"), System.Drawing.Icon)
        Me.btnVenReclamo.Key = "23"
        Me.btnVenReclamo.Name = "btnVenReclamo"
        Me.btnVenReclamo.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenReclamo.Text = "Reclamo Garantia"
        '
        'btnVenPostActuVendedor
        '
        Me.btnVenPostActuVendedor.Icon = CType(resources.GetObject("btnVenPostActuVendedor.Icon"), System.Drawing.Icon)
        Me.btnVenPostActuVendedor.Key = "ButtonCommand1"
        Me.btnVenPostActuVendedor.Name = "btnVenPostActuVendedor"
        Me.btnVenPostActuVendedor.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenPostActuVendedor.Text = "Actualizar Vendedor"
        '
        'btnVenSepararOrden
        '
        Me.btnVenSepararOrden.Icon = CType(resources.GetObject("btnVenSepararOrden.Icon"), System.Drawing.Icon)
        Me.btnVenSepararOrden.Key = "ButtonCommand1"
        Me.btnVenSepararOrden.Name = "btnVenSepararOrden"
        Me.btnVenSepararOrden.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenSepararOrden.Text = "Separar Orden"
        '
        'btnVenEnvioCorreo
        '
        Me.btnVenEnvioCorreo.Image = CType(resources.GetObject("btnVenEnvioCorreo.Image"), System.Drawing.Image)
        Me.btnVenEnvioCorreo.Key = "ButtonCommand1"
        Me.btnVenEnvioCorreo.Name = "btnVenEnvioCorreo"
        Me.btnVenEnvioCorreo.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenEnvioCorreo.Text = "Enviar Correos"
        '
        'rbbVenClientes
        '
        Me.rbbVenClientes.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnVenCliCartera})
        Me.rbbVenClientes.ImageKey = ""
        Me.rbbVenClientes.Key = "RibbonGroup3"
        Me.rbbVenClientes.Name = "rbbVenClientes"
        Me.rbbVenClientes.Text = "Clientes"
        '
        'btnVenCliCartera
        '
        Me.btnVenCliCartera.Icon = CType(resources.GetObject("btnVenCliCartera.Icon"), System.Drawing.Icon)
        Me.btnVenCliCartera.Key = "24"
        Me.btnVenCliCartera.Name = "btnVenCliCartera"
        Me.btnVenCliCartera.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenCliCartera.Text = "Cartera"
        '
        'rbbVenRequisiciones
        '
        Me.rbbVenRequisiciones.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnVenReqDespachos})
        Me.rbbVenRequisiciones.ImageKey = ""
        Me.rbbVenRequisiciones.Key = "RibbonGroup4"
        Me.rbbVenRequisiciones.Name = "rbbVenRequisiciones"
        Me.rbbVenRequisiciones.Text = "Requisiciones"
        '
        'btnVenReqDespachos
        '
        Me.btnVenReqDespachos.Icon = CType(resources.GetObject("btnVenReqDespachos.Icon"), System.Drawing.Icon)
        Me.btnVenReqDespachos.Key = "27"
        Me.btnVenReqDespachos.Name = "btnVenReqDespachos"
        Me.btnVenReqDespachos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenReqDespachos.Text = "Despacho"
        '
        'rbbVenConsultas
        '
        Me.rbbVenConsultas.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnVenConPrecios, Me.btnVenConDocumentos})
        Me.rbbVenConsultas.ImageKey = ""
        Me.rbbVenConsultas.Key = "RibbonGroup5"
        Me.rbbVenConsultas.Name = "rbbVenConsultas"
        Me.rbbVenConsultas.Text = "Consultas"
        '
        'btnVenConPrecios
        '
        Me.btnVenConPrecios.Icon = CType(resources.GetObject("btnVenConPrecios.Icon"), System.Drawing.Icon)
        Me.btnVenConPrecios.Key = "28"
        Me.btnVenConPrecios.Name = "btnVenConPrecios"
        Me.btnVenConPrecios.Shortcut = System.Windows.Forms.Shortcut.CtrlF2
        Me.btnVenConPrecios.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenConPrecios.Text = "Precios"
        '
        'btnVenConDocumentos
        '
        Me.btnVenConDocumentos.Image = CType(resources.GetObject("btnVenConDocumentos.Image"), System.Drawing.Image)
        Me.btnVenConDocumentos.Key = "ButtonCommand1"
        Me.btnVenConDocumentos.Name = "btnVenConDocumentos"
        Me.btnVenConDocumentos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenConDocumentos.Text = "Documentos"
        '
        'rbbVenIndicadores
        '
        Me.rbbVenIndicadores.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnVenIndTablero})
        Me.rbbVenIndicadores.Key = "RibbonGroup4"
        Me.rbbVenIndicadores.Name = "rbbVenIndicadores"
        Me.rbbVenIndicadores.Text = "Indicadores"
        '
        'btnVenIndTablero
        '
        Me.btnVenIndTablero.Icon = CType(resources.GetObject("btnVenIndTablero.Icon"), System.Drawing.Icon)
        Me.btnVenIndTablero.Key = "ButtonCommand1"
        Me.btnVenIndTablero.Name = "btnVenIndTablero"
        Me.btnVenIndTablero.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenIndTablero.Text = "Tablero"
        '
        'rbbVenPrecios
        '
        Me.rbbVenPrecios.AllowAutoSizeItems = False
        Me.rbbVenPrecios.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnVenPreciosCliente, Me.btnVenPreciosLista, Me.btnVenPreciosOferta, Me.btnVenPreciosFabricantes, Me.btnVenPreciosRubrosEmpresa})
        Me.rbbVenPrecios.Key = "RibbonGroup4"
        Me.rbbVenPrecios.Name = "rbbVenPrecios"
        Me.rbbVenPrecios.Text = "Precios"
        '
        'btnVenPreciosCliente
        '
        Me.btnVenPreciosCliente.Icon = CType(resources.GetObject("btnVenPreciosCliente.Icon"), System.Drawing.Icon)
        Me.btnVenPreciosCliente.Key = "ButtonCommand1"
        Me.btnVenPreciosCliente.Name = "btnVenPreciosCliente"
        Me.btnVenPreciosCliente.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenPreciosCliente.Text = "Precios Cliente"
        '
        'btnVenPreciosLista
        '
        Me.btnVenPreciosLista.Image = CType(resources.GetObject("btnVenPreciosLista.Image"), System.Drawing.Image)
        Me.btnVenPreciosLista.Key = "ButtonCommand1"
        Me.btnVenPreciosLista.Name = "btnVenPreciosLista"
        Me.btnVenPreciosLista.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenPreciosLista.Text = "Precio Lista"
        '
        'btnVenPreciosOferta
        '
        Me.btnVenPreciosOferta.Image = CType(resources.GetObject("btnVenPreciosOferta.Image"), System.Drawing.Image)
        Me.btnVenPreciosOferta.Key = "ButtonCommand2"
        Me.btnVenPreciosOferta.Name = "btnVenPreciosOferta"
        Me.btnVenPreciosOferta.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenPreciosOferta.Text = "Precio Oferta"
        '
        'btnVenPreciosFabricantes
        '
        Me.btnVenPreciosFabricantes.Icon = CType(resources.GetObject("btnVenPreciosFabricantes.Icon"), System.Drawing.Icon)
        Me.btnVenPreciosFabricantes.Key = "ButtonCommand1"
        Me.btnVenPreciosFabricantes.Name = "btnVenPreciosFabricantes"
        Me.btnVenPreciosFabricantes.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenPreciosFabricantes.Text = "Precio Fabricantes"
        '
        'btnVenPreciosRubrosEmpresa
        '
        Me.btnVenPreciosRubrosEmpresa.Image = CType(resources.GetObject("btnVenPreciosRubrosEmpresa.Image"), System.Drawing.Image)
        Me.btnVenPreciosRubrosEmpresa.Key = "ButtonCommand1"
        Me.btnVenPreciosRubrosEmpresa.Name = "btnVenPreciosRubrosEmpresa"
        Me.btnVenPreciosRubrosEmpresa.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenPreciosRubrosEmpresa.Text = "Factores Rubros"
        '
        'rbbVenReportes
        '
        Me.rbbVenReportes.AllowAutoSizeItems = False
        Me.rbbVenReportes.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.ddcVenRepRegistroVenta, Me.btnVenRepVentaDetalle, Me.btnVenRepVentaAcumulada, Me.btnVenRepVentaGuias, Me.btnVenRepCotizaciones, Me.btnVenRepVentaRequisiciones, Me.btnVenRepMensualesxCliente, Me.btnVenRepDetalleDescuento, Me.btnVenRepReclamos, Me.btnVenRepOrdenes, Me.btnVenRepConsignacion, Me.btnVenRepTodoGuiaRemision, Me.btnVenRepPresupuestoVenta, Me.btnVenRepComisiones})
        Me.rbbVenReportes.ImageKey = ""
        Me.rbbVenReportes.Key = "RibbonGroup6"
        Me.rbbVenReportes.Name = "rbbVenReportes"
        Me.rbbVenReportes.Text = "Reportes"
        '
        'ddcVenRepRegistroVenta
        '
        Me.ddcVenRepRegistroVenta.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.ddcVenRepRegistro, Me.ddcVenRepRegistroAuxiliar, Me.ddcVenRepRegistroResumen})
        Me.ddcVenRepRegistroVenta.Icon = CType(resources.GetObject("ddcVenRepRegistroVenta.Icon"), System.Drawing.Icon)
        Me.ddcVenRepRegistroVenta.Key = "DropDownCommand1"
        Me.ddcVenRepRegistroVenta.Name = "ddcVenRepRegistroVenta"
        Me.ddcVenRepRegistroVenta.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.ddcVenRepRegistroVenta.Text = "Registro de Venta"
        '
        'ddcVenRepRegistro
        '
        Me.ddcVenRepRegistro.Image = CType(resources.GetObject("ddcVenRepRegistro.Image"), System.Drawing.Image)
        Me.ddcVenRepRegistro.Key = "DropDownCommand1"
        Me.ddcVenRepRegistro.Name = "ddcVenRepRegistro"
        Me.ddcVenRepRegistro.Text = "Registro"
        '
        'ddcVenRepRegistroAuxiliar
        '
        Me.ddcVenRepRegistroAuxiliar.Image = CType(resources.GetObject("ddcVenRepRegistroAuxiliar.Image"), System.Drawing.Image)
        Me.ddcVenRepRegistroAuxiliar.Key = "DropDownCommand2"
        Me.ddcVenRepRegistroAuxiliar.Name = "ddcVenRepRegistroAuxiliar"
        Me.ddcVenRepRegistroAuxiliar.Text = "Registro Auxiliar"
        '
        'ddcVenRepRegistroResumen
        '
        Me.ddcVenRepRegistroResumen.Image = CType(resources.GetObject("ddcVenRepRegistroResumen.Image"), System.Drawing.Image)
        Me.ddcVenRepRegistroResumen.Key = "DropDownCommand3"
        Me.ddcVenRepRegistroResumen.Name = "ddcVenRepRegistroResumen"
        Me.ddcVenRepRegistroResumen.Text = "Resumen Registro"
        '
        'btnVenRepVentaDetalle
        '
        Me.btnVenRepVentaDetalle.Icon = CType(resources.GetObject("btnVenRepVentaDetalle.Icon"), System.Drawing.Icon)
        Me.btnVenRepVentaDetalle.Key = "32"
        Me.btnVenRepVentaDetalle.Name = "btnVenRepVentaDetalle"
        Me.btnVenRepVentaDetalle.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenRepVentaDetalle.Text = "Detalle"
        '
        'btnVenRepVentaAcumulada
        '
        Me.btnVenRepVentaAcumulada.Icon = CType(resources.GetObject("btnVenRepVentaAcumulada.Icon"), System.Drawing.Icon)
        Me.btnVenRepVentaAcumulada.Key = "33"
        Me.btnVenRepVentaAcumulada.Name = "btnVenRepVentaAcumulada"
        Me.btnVenRepVentaAcumulada.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenRepVentaAcumulada.Text = "Acumulada"
        '
        'btnVenRepVentaGuias
        '
        Me.btnVenRepVentaGuias.Icon = CType(resources.GetObject("btnVenRepVentaGuias.Icon"), System.Drawing.Icon)
        Me.btnVenRepVentaGuias.Key = "34"
        Me.btnVenRepVentaGuias.Name = "btnVenRepVentaGuias"
        Me.btnVenRepVentaGuias.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenRepVentaGuias.Text = "G/R Pendiente"
        '
        'btnVenRepCotizaciones
        '
        Me.btnVenRepCotizaciones.Icon = CType(resources.GetObject("btnVenRepCotizaciones.Icon"), System.Drawing.Icon)
        Me.btnVenRepCotizaciones.Image = CType(resources.GetObject("btnVenRepCotizaciones.Image"), System.Drawing.Image)
        Me.btnVenRepCotizaciones.Key = "ButtonCommand1"
        Me.btnVenRepCotizaciones.Name = "btnVenRepCotizaciones"
        Me.btnVenRepCotizaciones.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenRepCotizaciones.Text = "Cotizaciones"
        '
        'btnVenRepVentaRequisiciones
        '
        Me.btnVenRepVentaRequisiciones.Icon = CType(resources.GetObject("btnVenRepVentaRequisiciones.Icon"), System.Drawing.Icon)
        Me.btnVenRepVentaRequisiciones.Key = "ButtonCommand2"
        Me.btnVenRepVentaRequisiciones.Name = "btnVenRepVentaRequisiciones"
        Me.btnVenRepVentaRequisiciones.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenRepVentaRequisiciones.Text = "Vale Requisicion"
        '
        'btnVenRepMensualesxCliente
        '
        Me.btnVenRepMensualesxCliente.Image = CType(resources.GetObject("btnVenRepMensualesxCliente.Image"), System.Drawing.Image)
        Me.btnVenRepMensualesxCliente.Key = "ButtonCommand1"
        Me.btnVenRepMensualesxCliente.Name = "btnVenRepMensualesxCliente"
        Me.btnVenRepMensualesxCliente.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenRepMensualesxCliente.Text = "Mensuales x Cliente"
        '
        'btnVenRepDetalleDescuento
        '
        Me.btnVenRepDetalleDescuento.Icon = CType(resources.GetObject("btnVenRepDetalleDescuento.Icon"), System.Drawing.Icon)
        Me.btnVenRepDetalleDescuento.Key = "ButtonCommand1"
        Me.btnVenRepDetalleDescuento.Name = "btnVenRepDetalleDescuento"
        Me.btnVenRepDetalleDescuento.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenRepDetalleDescuento.Text = "Detalle Descuento"
        '
        'btnVenRepReclamos
        '
        Me.btnVenRepReclamos.Icon = CType(resources.GetObject("btnVenRepReclamos.Icon"), System.Drawing.Icon)
        Me.btnVenRepReclamos.Key = "ButtonCommand1"
        Me.btnVenRepReclamos.Name = "btnVenRepReclamos"
        Me.btnVenRepReclamos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenRepReclamos.Text = "Reclamos"
        '
        'btnVenRepOrdenes
        '
        Me.btnVenRepOrdenes.Icon = CType(resources.GetObject("btnVenRepOrdenes.Icon"), System.Drawing.Icon)
        Me.btnVenRepOrdenes.Key = "ButtonCommand1"
        Me.btnVenRepOrdenes.Name = "btnVenRepOrdenes"
        Me.btnVenRepOrdenes.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenRepOrdenes.Text = "Ordenes Compra"
        '
        'btnVenRepConsignacion
        '
        Me.btnVenRepConsignacion.Image = CType(resources.GetObject("btnVenRepConsignacion.Image"), System.Drawing.Image)
        Me.btnVenRepConsignacion.Key = "ButtonCommand1"
        Me.btnVenRepConsignacion.Name = "btnVenRepConsignacion"
        Me.btnVenRepConsignacion.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenRepConsignacion.Text = "Consignaciones"
        '
        'btnVenRepTodoGuiaRemision
        '
        Me.btnVenRepTodoGuiaRemision.Icon = CType(resources.GetObject("btnVenRepTodoGuiaRemision.Icon"), System.Drawing.Icon)
        Me.btnVenRepTodoGuiaRemision.Key = "ButtonCommand1"
        Me.btnVenRepTodoGuiaRemision.Name = "btnVenRepTodoGuiaRemision"
        Me.btnVenRepTodoGuiaRemision.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenRepTodoGuiaRemision.Text = "Guias Remision"
        '
        'btnVenRepPresupuestoVenta
        '
        Me.btnVenRepPresupuestoVenta.Image = CType(resources.GetObject("btnVenRepPresupuestoVenta.Image"), System.Drawing.Image)
        Me.btnVenRepPresupuestoVenta.Key = "ButtonCommand1"
        Me.btnVenRepPresupuestoVenta.Name = "btnVenRepPresupuestoVenta"
        Me.btnVenRepPresupuestoVenta.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenRepPresupuestoVenta.Text = "Presupuesto Venta"
        '
        'btnVenRepComisiones
        '
        Me.btnVenRepComisiones.Image = CType(resources.GetObject("btnVenRepComisiones.Image"), System.Drawing.Image)
        Me.btnVenRepComisiones.Key = "ButtonCommand1"
        Me.btnVenRepComisiones.Name = "btnVenRepComisiones"
        Me.btnVenRepComisiones.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnVenRepComisiones.Text = "Comisiones"
        '
        'rbbTabAlmacenes
        '
        Me.rbbTabAlmacenes.Groups.AddRange(New Janus.Windows.Ribbon.RibbonGroup() {Me.rbbAlmAlmacen, Me.rbbAlmMotores, Me.rbbAlmTransito, Me.rbbAlmMantenimiento, Me.rbbAlmConsultas, Me.rbbAlmIndicadores, Me.rbbAlmReportes})
        Me.rbbTabAlmacenes.Key = "1"
        Me.rbbTabAlmacenes.KeyTip = "Almacenes"
        Me.rbbTabAlmacenes.Name = "rbbTabAlmacenes"
        Me.rbbTabAlmacenes.Text = "Almacenes"
        '
        'rbbAlmAlmacen
        '
        Me.rbbAlmAlmacen.AllowAutoSizeItems = False
        Me.rbbAlmAlmacen.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnAlmAlmDocumentos, Me.btnAlmAlmDocumentoSalidas, Me.btnAlmAlmChequeoFI, Me.btnAlmAlmTI, Me.btnAlmAlmMTI, Me.btnAlmAlmValesMate, Me.btnAlmAlmAtenderJob, Me.btnAlmAlmDespacho, Me.btnAlmAlmDatosDespacho})
        Me.rbbAlmAlmacen.ImageKey = ""
        Me.rbbAlmAlmacen.Key = "RibbonGroup1"
        Me.rbbAlmAlmacen.Name = "rbbAlmAlmacen"
        Me.rbbAlmAlmacen.Text = "Almacén"
        '
        'btnAlmAlmDocumentos
        '
        Me.btnAlmAlmDocumentos.Image = CType(resources.GetObject("btnAlmAlmDocumentos.Image"), System.Drawing.Image)
        Me.btnAlmAlmDocumentos.Key = "1"
        Me.btnAlmAlmDocumentos.Name = "btnAlmAlmDocumentos"
        Me.btnAlmAlmDocumentos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmAlmDocumentos.Text = "Doc.Ingresos"
        '
        'btnAlmAlmDocumentoSalidas
        '
        Me.btnAlmAlmDocumentoSalidas.Image = CType(resources.GetObject("btnAlmAlmDocumentoSalidas.Image"), System.Drawing.Image)
        Me.btnAlmAlmDocumentoSalidas.Key = "ButtonCommand1"
        Me.btnAlmAlmDocumentoSalidas.Name = "btnAlmAlmDocumentoSalidas"
        Me.btnAlmAlmDocumentoSalidas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmAlmDocumentoSalidas.Text = "Doc.Salidas"
        '
        'btnAlmAlmChequeoFI
        '
        Me.btnAlmAlmChequeoFI.Icon = CType(resources.GetObject("btnAlmAlmChequeoFI.Icon"), System.Drawing.Icon)
        Me.btnAlmAlmChequeoFI.Key = "5"
        Me.btnAlmAlmChequeoFI.Name = "btnAlmAlmChequeoFI"
        Me.btnAlmAlmChequeoFI.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmAlmChequeoFI.Text = "Chequeo F/I"
        '
        'btnAlmAlmTI
        '
        Me.btnAlmAlmTI.Icon = CType(resources.GetObject("btnAlmAlmTI.Icon"), System.Drawing.Icon)
        Me.btnAlmAlmTI.Key = "2"
        Me.btnAlmAlmTI.Name = "btnAlmAlmTI"
        Me.btnAlmAlmTI.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmAlmTI.Text = "T / I"
        '
        'btnAlmAlmMTI
        '
        Me.btnAlmAlmMTI.Icon = CType(resources.GetObject("btnAlmAlmMTI.Icon"), System.Drawing.Icon)
        Me.btnAlmAlmMTI.Key = "4"
        Me.btnAlmAlmMTI.Name = "btnAlmAlmMTI"
        Me.btnAlmAlmMTI.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmAlmMTI.Text = "M T I"
        '
        'btnAlmAlmValesMate
        '
        Me.btnAlmAlmValesMate.Icon = CType(resources.GetObject("btnAlmAlmValesMate.Icon"), System.Drawing.Icon)
        Me.btnAlmAlmValesMate.Key = "3"
        Me.btnAlmAlmValesMate.Name = "btnAlmAlmValesMate"
        Me.btnAlmAlmValesMate.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmAlmValesMate.Text = "Vales"
        '
        'btnAlmAlmAtenderJob
        '
        Me.btnAlmAlmAtenderJob.Image = CType(resources.GetObject("btnAlmAlmAtenderJob.Image"), System.Drawing.Image)
        Me.btnAlmAlmAtenderJob.Key = "ButtonCommand1"
        Me.btnAlmAlmAtenderJob.Name = "btnAlmAlmAtenderJob"
        Me.btnAlmAlmAtenderJob.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmAlmAtenderJob.Text = "Atender OT"
        '
        'btnAlmAlmDespacho
        '
        Me.btnAlmAlmDespacho.Image = CType(resources.GetObject("btnAlmAlmDespacho.Image"), System.Drawing.Image)
        Me.btnAlmAlmDespacho.Key = "ButtonCommand1"
        Me.btnAlmAlmDespacho.Name = "btnAlmAlmDespacho"
        Me.btnAlmAlmDespacho.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmAlmDespacho.Text = "Despachos"
        '
        'btnAlmAlmDatosDespacho
        '
        Me.btnAlmAlmDatosDespacho.Image = CType(resources.GetObject("btnAlmAlmDatosDespacho.Image"), System.Drawing.Image)
        Me.btnAlmAlmDatosDespacho.Key = "ButtonCommand1"
        Me.btnAlmAlmDatosDespacho.Name = "btnAlmAlmDatosDespacho"
        Me.btnAlmAlmDatosDespacho.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmAlmDatosDespacho.Text = "Datos Despacho Clientes"
        '
        'rbbAlmMotores
        '
        Me.rbbAlmMotores.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnAlmMotTransferencias, Me.btnAlmMotCompras})
        Me.rbbAlmMotores.ImageKey = ""
        Me.rbbAlmMotores.Key = "RibbonGroup2"
        Me.rbbAlmMotores.Name = "rbbAlmMotores"
        Me.rbbAlmMotores.Text = "Motores"
        '
        'btnAlmMotTransferencias
        '
        Me.btnAlmMotTransferencias.Icon = CType(resources.GetObject("btnAlmMotTransferencias.Icon"), System.Drawing.Icon)
        Me.btnAlmMotTransferencias.Key = "6"
        Me.btnAlmMotTransferencias.Name = "btnAlmMotTransferencias"
        Me.btnAlmMotTransferencias.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmMotTransferencias.Text = "Transferencias"
        '
        'btnAlmMotCompras
        '
        Me.btnAlmMotCompras.Icon = CType(resources.GetObject("btnAlmMotCompras.Icon"), System.Drawing.Icon)
        Me.btnAlmMotCompras.Key = "7"
        Me.btnAlmMotCompras.Name = "btnAlmMotCompras"
        Me.btnAlmMotCompras.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmMotCompras.Text = "Compras"
        '
        'rbbAlmTransito
        '
        Me.rbbAlmTransito.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnAlmTraDocumentos, Me.btnAlmTraAnulacionGuia})
        Me.rbbAlmTransito.ImageKey = ""
        Me.rbbAlmTransito.Key = "RibbonGroup3"
        Me.rbbAlmTransito.Name = "rbbAlmTransito"
        Me.rbbAlmTransito.Text = "Tránsito"
        '
        'btnAlmTraDocumentos
        '
        Me.btnAlmTraDocumentos.Icon = CType(resources.GetObject("btnAlmTraDocumentos.Icon"), System.Drawing.Icon)
        Me.btnAlmTraDocumentos.Key = "8"
        Me.btnAlmTraDocumentos.Name = "btnAlmTraDocumentos"
        Me.btnAlmTraDocumentos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmTraDocumentos.Text = "Documentos"
        '
        'btnAlmTraAnulacionGuia
        '
        Me.btnAlmTraAnulacionGuia.Icon = CType(resources.GetObject("btnAlmTraAnulacionGuia.Icon"), System.Drawing.Icon)
        Me.btnAlmTraAnulacionGuia.Key = "ButtonCommand1"
        Me.btnAlmTraAnulacionGuia.Name = "btnAlmTraAnulacionGuia"
        Me.btnAlmTraAnulacionGuia.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmTraAnulacionGuia.Text = "Anulación en Consulta"
        '
        'rbbAlmMantenimiento
        '
        Me.rbbAlmMantenimiento.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnAlmManMercaderias, Me.btnAlmManLiquiGastos, Me.btnAlmManMinMax, Me.btnAlmManUbicacion})
        Me.rbbAlmMantenimiento.ImageKey = ""
        Me.rbbAlmMantenimiento.Key = "RibbonGroup4"
        Me.rbbAlmMantenimiento.Name = "rbbAlmMantenimiento"
        Me.rbbAlmMantenimiento.Text = "Mantenimiento"
        '
        'btnAlmManMercaderias
        '
        Me.btnAlmManMercaderias.Image = CType(resources.GetObject("btnAlmManMercaderias.Image"), System.Drawing.Image)
        Me.btnAlmManMercaderias.Key = "9"
        Me.btnAlmManMercaderias.Name = "btnAlmManMercaderias"
        Me.btnAlmManMercaderias.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmManMercaderias.Text = "Productos"
        '
        'btnAlmManLiquiGastos
        '
        Me.btnAlmManLiquiGastos.Image = CType(resources.GetObject("btnAlmManLiquiGastos.Image"), System.Drawing.Image)
        Me.btnAlmManLiquiGastos.Key = "10"
        Me.btnAlmManLiquiGastos.Name = "btnAlmManLiquiGastos"
        Me.btnAlmManLiquiGastos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmManLiquiGastos.Text = "Liqui. Gastos"
        '
        'btnAlmManMinMax
        '
        Me.btnAlmManMinMax.Image = CType(resources.GetObject("btnAlmManMinMax.Image"), System.Drawing.Image)
        Me.btnAlmManMinMax.Key = "ButtonCommand1"
        Me.btnAlmManMinMax.Name = "btnAlmManMinMax"
        Me.btnAlmManMinMax.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmManMinMax.Text = "Act. Min Max"
        '
        'btnAlmManUbicacion
        '
        Me.btnAlmManUbicacion.Icon = CType(resources.GetObject("btnAlmManUbicacion.Icon"), System.Drawing.Icon)
        Me.btnAlmManUbicacion.Key = "ButtonCommand1"
        Me.btnAlmManUbicacion.Name = "btnAlmManUbicacion"
        Me.btnAlmManUbicacion.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmManUbicacion.Text = "Ubicaciones"
        '
        'rbbAlmConsultas
        '
        Me.rbbAlmConsultas.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnAlmConTarjetas, Me.btnAlmConDocumentos})
        Me.rbbAlmConsultas.ImageKey = ""
        Me.rbbAlmConsultas.Key = "RibbonGroup5"
        Me.rbbAlmConsultas.Name = "rbbAlmConsultas"
        Me.rbbAlmConsultas.Text = "Consultas"
        '
        'btnAlmConTarjetas
        '
        Me.btnAlmConTarjetas.Icon = CType(resources.GetObject("btnAlmConTarjetas.Icon"), System.Drawing.Icon)
        Me.btnAlmConTarjetas.Key = "11"
        Me.btnAlmConTarjetas.Name = "btnAlmConTarjetas"
        Me.btnAlmConTarjetas.Shortcut = System.Windows.Forms.Shortcut.CtrlF1
        Me.btnAlmConTarjetas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmConTarjetas.Text = "Tarjetas"
        '
        'btnAlmConDocumentos
        '
        Me.btnAlmConDocumentos.Image = CType(resources.GetObject("btnAlmConDocumentos.Image"), System.Drawing.Image)
        Me.btnAlmConDocumentos.Key = "ButtonCommand1"
        Me.btnAlmConDocumentos.Name = "btnAlmConDocumentos"
        Me.btnAlmConDocumentos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmConDocumentos.Text = "Documentos"
        '
        'rbbAlmIndicadores
        '
        Me.rbbAlmIndicadores.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnAlmIndCalendario, Me.btnAlmIndProcesoCobertura, Me.btnAlmIndTablero})
        Me.rbbAlmIndicadores.Key = "RibbonGroup4"
        Me.rbbAlmIndicadores.Name = "rbbAlmIndicadores"
        Me.rbbAlmIndicadores.Text = "Indicadores"
        '
        'btnAlmIndCalendario
        '
        Me.btnAlmIndCalendario.Icon = CType(resources.GetObject("btnAlmIndCalendario.Icon"), System.Drawing.Icon)
        Me.btnAlmIndCalendario.Key = "ButtonCommand1"
        Me.btnAlmIndCalendario.Name = "btnAlmIndCalendario"
        Me.btnAlmIndCalendario.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmIndCalendario.Text = "Calendario"
        '
        'btnAlmIndProcesoCobertura
        '
        Me.btnAlmIndProcesoCobertura.Icon = CType(resources.GetObject("btnAlmIndProcesoCobertura.Icon"), System.Drawing.Icon)
        Me.btnAlmIndProcesoCobertura.Key = "ButtonCommand1"
        Me.btnAlmIndProcesoCobertura.Name = "btnAlmIndProcesoCobertura"
        Me.btnAlmIndProcesoCobertura.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmIndProcesoCobertura.Text = "Procesar Cobertura"
        '
        'btnAlmIndTablero
        '
        Me.btnAlmIndTablero.Icon = CType(resources.GetObject("btnAlmIndTablero.Icon"), System.Drawing.Icon)
        Me.btnAlmIndTablero.Key = "ButtonCommand1"
        Me.btnAlmIndTablero.Name = "btnAlmIndTablero"
        Me.btnAlmIndTablero.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmIndTablero.Text = "Tablero"
        '
        'rbbAlmReportes
        '
        Me.rbbAlmReportes.AllowAutoSizeItems = False
        Me.rbbAlmReportes.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnAlmRepInventario, Me.btnAlmRepTomaInventario, Me.btnAlmRepMovimientos, Me.btnAlmRepValeMaterial, Me.btnAlmRepDocumento, Me.btnAlmRepInvPermanente, Me.btnAlmRepSinMovimiento, Me.btnAlmRepTransferencia})
        Me.rbbAlmReportes.ImageKey = ""
        Me.rbbAlmReportes.Key = "RibbonGroup6"
        Me.rbbAlmReportes.Name = "rbbAlmReportes"
        Me.rbbAlmReportes.Text = "Reportes"
        '
        'btnAlmRepInventario
        '
        Me.btnAlmRepInventario.Image = CType(resources.GetObject("btnAlmRepInventario.Image"), System.Drawing.Image)
        Me.btnAlmRepInventario.Key = "12"
        Me.btnAlmRepInventario.Name = "btnAlmRepInventario"
        Me.btnAlmRepInventario.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmRepInventario.Text = "Inventario"
        '
        'btnAlmRepTomaInventario
        '
        Me.btnAlmRepTomaInventario.Icon = CType(resources.GetObject("btnAlmRepTomaInventario.Icon"), System.Drawing.Icon)
        Me.btnAlmRepTomaInventario.Key = "13"
        Me.btnAlmRepTomaInventario.Name = "btnAlmRepTomaInventario"
        Me.btnAlmRepTomaInventario.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmRepTomaInventario.Text = "Toma de Inventario"
        '
        'btnAlmRepMovimientos
        '
        Me.btnAlmRepMovimientos.Icon = CType(resources.GetObject("btnAlmRepMovimientos.Icon"), System.Drawing.Icon)
        Me.btnAlmRepMovimientos.Key = "14"
        Me.btnAlmRepMovimientos.Name = "btnAlmRepMovimientos"
        Me.btnAlmRepMovimientos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmRepMovimientos.Text = "Movimientos"
        '
        'btnAlmRepValeMaterial
        '
        Me.btnAlmRepValeMaterial.Icon = CType(resources.GetObject("btnAlmRepValeMaterial.Icon"), System.Drawing.Icon)
        Me.btnAlmRepValeMaterial.Key = "15"
        Me.btnAlmRepValeMaterial.Name = "btnAlmRepValeMaterial"
        Me.btnAlmRepValeMaterial.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmRepValeMaterial.Text = "Vale Materiales"
        '
        'btnAlmRepDocumento
        '
        Me.btnAlmRepDocumento.Icon = CType(resources.GetObject("btnAlmRepDocumento.Icon"), System.Drawing.Icon)
        Me.btnAlmRepDocumento.Key = "ButtonCommand1"
        Me.btnAlmRepDocumento.Name = "btnAlmRepDocumento"
        Me.btnAlmRepDocumento.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmRepDocumento.Text = "Documentos"
        '
        'btnAlmRepInvPermanente
        '
        Me.btnAlmRepInvPermanente.Icon = CType(resources.GetObject("btnAlmRepInvPermanente.Icon"), System.Drawing.Icon)
        Me.btnAlmRepInvPermanente.Key = "ButtonCommand1"
        Me.btnAlmRepInvPermanente.Name = "btnAlmRepInvPermanente"
        Me.btnAlmRepInvPermanente.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmRepInvPermanente.Text = "Inv. Perm. Valorizado"
        '
        'btnAlmRepSinMovimiento
        '
        Me.btnAlmRepSinMovimiento.Image = CType(resources.GetObject("btnAlmRepSinMovimiento.Image"), System.Drawing.Image)
        Me.btnAlmRepSinMovimiento.Key = "ButtonCommand1"
        Me.btnAlmRepSinMovimiento.Name = "btnAlmRepSinMovimiento"
        Me.btnAlmRepSinMovimiento.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmRepSinMovimiento.Text = "Sin Movimiento"
        '
        'btnAlmRepTransferencia
        '
        Me.btnAlmRepTransferencia.Image = CType(resources.GetObject("btnAlmRepTransferencia.Image"), System.Drawing.Image)
        Me.btnAlmRepTransferencia.Key = "ButtonCommand1"
        Me.btnAlmRepTransferencia.Name = "btnAlmRepTransferencia"
        Me.btnAlmRepTransferencia.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAlmRepTransferencia.Text = "Transferencias"
        '
        'rbbTabCréditos
        '
        Me.rbbTabCréditos.Groups.AddRange(New Janus.Windows.Ribbon.RibbonGroup() {Me.rbbCreDocumentos, Me.rbbCreAprobaciones, Me.rbbCreMantenimiento, Me.rbbCreConsultas, Me.rbbCreReportes})
        Me.rbbTabCréditos.Key = "3"
        Me.rbbTabCréditos.KeyTip = "Creditos"
        Me.rbbTabCréditos.Name = "rbbTabCréditos"
        Me.rbbTabCréditos.Text = "Créditos"
        '
        'rbbCreDocumentos
        '
        Me.rbbCreDocumentos.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnCreDocCuentas, Me.btnCreDocPlanillas, Me.btnCreDocAnticipos, Me.btnCreDocLetras})
        Me.rbbCreDocumentos.ImageKey = ""
        Me.rbbCreDocumentos.Key = "RibbonGroup1"
        Me.rbbCreDocumentos.Name = "rbbCreDocumentos"
        Me.rbbCreDocumentos.Text = "Documentos"
        '
        'btnCreDocCuentas
        '
        Me.btnCreDocCuentas.Image = CType(resources.GetObject("btnCreDocCuentas.Image"), System.Drawing.Image)
        Me.btnCreDocCuentas.Key = "ButtonCommand1"
        Me.btnCreDocCuentas.Name = "btnCreDocCuentas"
        Me.btnCreDocCuentas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreDocCuentas.Text = "Ctas x Cobrar"
        '
        'btnCreDocPlanillas
        '
        Me.btnCreDocPlanillas.Image = CType(resources.GetObject("btnCreDocPlanillas.Image"), System.Drawing.Image)
        Me.btnCreDocPlanillas.Key = "ButtonCommand2"
        Me.btnCreDocPlanillas.Name = "btnCreDocPlanillas"
        Me.btnCreDocPlanillas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreDocPlanillas.Text = "Planillas"
        '
        'btnCreDocAnticipos
        '
        Me.btnCreDocAnticipos.Icon = CType(resources.GetObject("btnCreDocAnticipos.Icon"), System.Drawing.Icon)
        Me.btnCreDocAnticipos.Key = "ButtonCommand3"
        Me.btnCreDocAnticipos.Name = "btnCreDocAnticipos"
        Me.btnCreDocAnticipos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreDocAnticipos.Text = "Anticipos"
        '
        'btnCreDocLetras
        '
        Me.btnCreDocLetras.Icon = CType(resources.GetObject("btnCreDocLetras.Icon"), System.Drawing.Icon)
        Me.btnCreDocLetras.Key = "ButtonCommand4"
        Me.btnCreDocLetras.Name = "btnCreDocLetras"
        Me.btnCreDocLetras.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreDocLetras.Text = "Letras"
        '
        'rbbCreAprobaciones
        '
        Me.rbbCreAprobaciones.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnCreAprCreditos, Me.btnCreAprCotizaciones, Me.btnCreAprPerUsuario, Me.btnCreAprRecepcionDoc})
        Me.rbbCreAprobaciones.ImageKey = ""
        Me.rbbCreAprobaciones.Key = "RibbonGroup2"
        Me.rbbCreAprobaciones.Name = "rbbCreAprobaciones"
        Me.rbbCreAprobaciones.Text = "Aprobaciones"
        '
        'btnCreAprCreditos
        '
        Me.btnCreAprCreditos.Image = CType(resources.GetObject("btnCreAprCreditos.Image"), System.Drawing.Image)
        Me.btnCreAprCreditos.Key = "ButtonCommand5"
        Me.btnCreAprCreditos.Name = "btnCreAprCreditos"
        Me.btnCreAprCreditos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreAprCreditos.Text = "Créditos"
        '
        'btnCreAprCotizaciones
        '
        Me.btnCreAprCotizaciones.Image = CType(resources.GetObject("btnCreAprCotizaciones.Image"), System.Drawing.Image)
        Me.btnCreAprCotizaciones.Key = "ButtonCommand7"
        Me.btnCreAprCotizaciones.Name = "btnCreAprCotizaciones"
        Me.btnCreAprCotizaciones.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreAprCotizaciones.Text = "Cotiz. Taller"
        '
        'btnCreAprPerUsuario
        '
        Me.btnCreAprPerUsuario.Icon = CType(resources.GetObject("btnCreAprPerUsuario.Icon"), System.Drawing.Icon)
        Me.btnCreAprPerUsuario.Key = "ButtonCommand1"
        Me.btnCreAprPerUsuario.Name = "btnCreAprPerUsuario"
        Me.btnCreAprPerUsuario.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreAprPerUsuario.Text = "Permiso Usuario"
        '
        'btnCreAprRecepcionDoc
        '
        Me.btnCreAprRecepcionDoc.Image = CType(resources.GetObject("btnCreAprRecepcionDoc.Image"), System.Drawing.Image)
        Me.btnCreAprRecepcionDoc.Key = "ButtonCommand1"
        Me.btnCreAprRecepcionDoc.Name = "btnCreAprRecepcionDoc"
        Me.btnCreAprRecepcionDoc.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreAprRecepcionDoc.Text = "Recepcion Doc."
        '
        'rbbCreMantenimiento
        '
        Me.rbbCreMantenimiento.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnCreManFacDesc, Me.btnCreManBancos, Me.btnCreManVisitaCobrador, Me.btnCreManProcesarGuias, Me.btnCreManVincularGuias, Me.btnCreManFeriados, Me.btnCreManTipoCambio, Me.btnCreManRenuevaTC, Me.btnCreMantenimientoTipoCambio})
        Me.rbbCreMantenimiento.ImageKey = ""
        Me.rbbCreMantenimiento.Key = "RibbonGroup3"
        Me.rbbCreMantenimiento.Name = "rbbCreMantenimiento"
        Me.rbbCreMantenimiento.Text = "Mantenimiento"
        '
        'btnCreManFacDesc
        '
        Me.btnCreManFacDesc.Icon = CType(resources.GetObject("btnCreManFacDesc.Icon"), System.Drawing.Icon)
        Me.btnCreManFacDesc.Key = "ButtonCommand6"
        Me.btnCreManFacDesc.Name = "btnCreManFacDesc"
        Me.btnCreManFacDesc.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreManFacDesc.Text = "Factores y Descuentos"
        '
        'btnCreManBancos
        '
        Me.btnCreManBancos.Image = CType(resources.GetObject("btnCreManBancos.Image"), System.Drawing.Image)
        Me.btnCreManBancos.Key = "ButtonCommand10"
        Me.btnCreManBancos.Name = "btnCreManBancos"
        Me.btnCreManBancos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreManBancos.Text = "Saldo Bancos"
        '
        'btnCreManVisitaCobrador
        '
        Me.btnCreManVisitaCobrador.Image = CType(resources.GetObject("btnCreManVisitaCobrador.Image"), System.Drawing.Image)
        Me.btnCreManVisitaCobrador.Key = "ButtonCommand1"
        Me.btnCreManVisitaCobrador.Name = "btnCreManVisitaCobrador"
        Me.btnCreManVisitaCobrador.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreManVisitaCobrador.Text = "Visitas Cobrador"
        '
        'btnCreManProcesarGuias
        '
        Me.btnCreManProcesarGuias.Image = CType(resources.GetObject("btnCreManProcesarGuias.Image"), System.Drawing.Image)
        Me.btnCreManProcesarGuias.Key = "ButtonCommand1"
        Me.btnCreManProcesarGuias.Name = "btnCreManProcesarGuias"
        Me.btnCreManProcesarGuias.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreManProcesarGuias.Text = "Procesar Job"
        '
        'btnCreManVincularGuias
        '
        Me.btnCreManVincularGuias.Icon = CType(resources.GetObject("btnCreManVincularGuias.Icon"), System.Drawing.Icon)
        Me.btnCreManVincularGuias.Key = "ButtonCommand1"
        Me.btnCreManVincularGuias.Name = "btnCreManVincularGuias"
        Me.btnCreManVincularGuias.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreManVincularGuias.Text = "Vincular G/R"
        '
        'btnCreManFeriados
        '
        Me.btnCreManFeriados.Icon = CType(resources.GetObject("btnCreManFeriados.Icon"), System.Drawing.Icon)
        Me.btnCreManFeriados.Key = "ButtonCommand1"
        Me.btnCreManFeriados.Name = "btnCreManFeriados"
        Me.btnCreManFeriados.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreManFeriados.Text = "Feriados"
        '
        'btnCreManTipoCambio
        '
        Me.btnCreManTipoCambio.Image = CType(resources.GetObject("btnCreManTipoCambio.Image"), System.Drawing.Image)
        Me.btnCreManTipoCambio.Key = "ButtonCommand1"
        Me.btnCreManTipoCambio.Name = "btnCreManTipoCambio"
        Me.btnCreManTipoCambio.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreManTipoCambio.Text = "Tipo Cambio Ventas"
        '
        'btnCreManRenuevaTC
        '
        Me.btnCreManRenuevaTC.Image = CType(resources.GetObject("btnCreManRenuevaTC.Image"), System.Drawing.Image)
        Me.btnCreManRenuevaTC.Key = "ButtonCommand1"
        Me.btnCreManRenuevaTC.Name = "btnCreManRenuevaTC"
        Me.btnCreManRenuevaTC.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreManRenuevaTC.Text = "Renueva Tipo Cambio"
        '
        'btnCreMantenimientoTipoCambio
        '
        Me.btnCreMantenimientoTipoCambio.Image = CType(resources.GetObject("btnCreMantenimientoTipoCambio.Image"), System.Drawing.Image)
        Me.btnCreMantenimientoTipoCambio.Key = "ButtonCommand1"
        Me.btnCreMantenimientoTipoCambio.Name = "btnCreMantenimientoTipoCambio"
        Me.btnCreMantenimientoTipoCambio.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreMantenimientoTipoCambio.Text = "Mantenimiento Tipo de Cambio"
        '
        'rbbCreConsultas
        '
        Me.rbbCreConsultas.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnCreConCuentas, Me.btnCreConVencimientos, Me.btnCreConTarjetaCliente})
        Me.rbbCreConsultas.ImageKey = ""
        Me.rbbCreConsultas.Key = "RibbonGroup1"
        Me.rbbCreConsultas.Name = "rbbCreConsultas"
        Me.rbbCreConsultas.Text = "Consultas"
        '
        'btnCreConCuentas
        '
        Me.btnCreConCuentas.Image = CType(resources.GetObject("btnCreConCuentas.Image"), System.Drawing.Image)
        Me.btnCreConCuentas.Key = "ButtonCommand8"
        Me.btnCreConCuentas.Name = "btnCreConCuentas"
        Me.btnCreConCuentas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreConCuentas.Text = "Ctas. x Cobrar"
        '
        'btnCreConVencimientos
        '
        Me.btnCreConVencimientos.Image = CType(resources.GetObject("btnCreConVencimientos.Image"), System.Drawing.Image)
        Me.btnCreConVencimientos.Key = "ButtonCommand11"
        Me.btnCreConVencimientos.Name = "btnCreConVencimientos"
        Me.btnCreConVencimientos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreConVencimientos.Text = "Vencimientos"
        '
        'btnCreConTarjetaCliente
        '
        Me.btnCreConTarjetaCliente.Icon = CType(resources.GetObject("btnCreConTarjetaCliente.Icon"), System.Drawing.Icon)
        Me.btnCreConTarjetaCliente.Key = "ButtonCommand1"
        Me.btnCreConTarjetaCliente.Name = "btnCreConTarjetaCliente"
        Me.btnCreConTarjetaCliente.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreConTarjetaCliente.Text = "Tarjeta Cliente"
        '
        'rbbCreReportes
        '
        Me.rbbCreReportes.AllowAutoSizeItems = False
        Me.rbbCreReportes.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnCreRepCtasCtes, Me.btnCreRepDiarioPago, Me.btnCreRepDocEmitido, Me.btnCreRepLetra, Me.btnCreRepNotasDebito, Me.btnCreRepPlanilla, Me.btnCreRepVisitaCobrador, Me.ddcCreRepVencimientos, Me.btnCreRepClientes})
        Me.rbbCreReportes.Key = "RibbonGroup8"
        Me.rbbCreReportes.Name = "rbbCreReportes"
        Me.rbbCreReportes.Text = "Reportes"
        '
        'btnCreRepCtasCtes
        '
        Me.btnCreRepCtasCtes.Image = CType(resources.GetObject("btnCreRepCtasCtes.Image"), System.Drawing.Image)
        Me.btnCreRepCtasCtes.Key = "ButtonCommand1"
        Me.btnCreRepCtasCtes.Name = "btnCreRepCtasCtes"
        Me.btnCreRepCtasCtes.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreRepCtasCtes.Text = "Cuentas Corrientes"
        '
        'btnCreRepDiarioPago
        '
        Me.btnCreRepDiarioPago.Image = CType(resources.GetObject("btnCreRepDiarioPago.Image"), System.Drawing.Image)
        Me.btnCreRepDiarioPago.Key = "ButtonCommand3"
        Me.btnCreRepDiarioPago.Name = "btnCreRepDiarioPago"
        Me.btnCreRepDiarioPago.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreRepDiarioPago.Text = "Diario de Pagos"
        '
        'btnCreRepDocEmitido
        '
        Me.btnCreRepDocEmitido.Image = CType(resources.GetObject("btnCreRepDocEmitido.Image"), System.Drawing.Image)
        Me.btnCreRepDocEmitido.Key = "ButtonCommand4"
        Me.btnCreRepDocEmitido.Name = "btnCreRepDocEmitido"
        Me.btnCreRepDocEmitido.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreRepDocEmitido.Text = "Documentos Emitidos"
        '
        'btnCreRepLetra
        '
        Me.btnCreRepLetra.Image = CType(resources.GetObject("btnCreRepLetra.Image"), System.Drawing.Image)
        Me.btnCreRepLetra.Key = "ButtonCommand5"
        Me.btnCreRepLetra.Name = "btnCreRepLetra"
        Me.btnCreRepLetra.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreRepLetra.Text = "Letras Aceptadas"
        '
        'btnCreRepNotasDebito
        '
        Me.btnCreRepNotasDebito.Icon = CType(resources.GetObject("btnCreRepNotasDebito.Icon"), System.Drawing.Icon)
        Me.btnCreRepNotasDebito.Key = "ButtonCommand6"
        Me.btnCreRepNotasDebito.Name = "btnCreRepNotasDebito"
        Me.btnCreRepNotasDebito.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreRepNotasDebito.Text = "Notas Debito/Credito"
        '
        'btnCreRepPlanilla
        '
        Me.btnCreRepPlanilla.Image = CType(resources.GetObject("btnCreRepPlanilla.Image"), System.Drawing.Image)
        Me.btnCreRepPlanilla.Key = "ButtonCommand2"
        Me.btnCreRepPlanilla.Name = "btnCreRepPlanilla"
        Me.btnCreRepPlanilla.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreRepPlanilla.Text = "Planillas"
        '
        'btnCreRepVisitaCobrador
        '
        Me.btnCreRepVisitaCobrador.Image = CType(resources.GetObject("btnCreRepVisitaCobrador.Image"), System.Drawing.Image)
        Me.btnCreRepVisitaCobrador.Key = "ButtonCommand1"
        Me.btnCreRepVisitaCobrador.Name = "btnCreRepVisitaCobrador"
        Me.btnCreRepVisitaCobrador.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreRepVisitaCobrador.Text = "Visita Cobrador"
        '
        'ddcCreRepVencimientos
        '
        Me.ddcCreRepVencimientos.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.ddcCreRepVencimientoDetalle, Me.ddcCreRepVencimientoAcumulado})
        Me.ddcCreRepVencimientos.Image = CType(resources.GetObject("ddcCreRepVencimientos.Image"), System.Drawing.Image)
        Me.ddcCreRepVencimientos.Key = "DropDownCommand1"
        Me.ddcCreRepVencimientos.Name = "ddcCreRepVencimientos"
        Me.ddcCreRepVencimientos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.ddcCreRepVencimientos.Text = "Vencimientos"
        '
        'ddcCreRepVencimientoDetalle
        '
        Me.ddcCreRepVencimientoDetalle.Image = CType(resources.GetObject("ddcCreRepVencimientoDetalle.Image"), System.Drawing.Image)
        Me.ddcCreRepVencimientoDetalle.Key = "DropDownCommand2"
        Me.ddcCreRepVencimientoDetalle.Name = "ddcCreRepVencimientoDetalle"
        Me.ddcCreRepVencimientoDetalle.Text = "Detalle"
        '
        'ddcCreRepVencimientoAcumulado
        '
        Me.ddcCreRepVencimientoAcumulado.Image = CType(resources.GetObject("ddcCreRepVencimientoAcumulado.Image"), System.Drawing.Image)
        Me.ddcCreRepVencimientoAcumulado.Key = "DropDownCommand3"
        Me.ddcCreRepVencimientoAcumulado.Name = "ddcCreRepVencimientoAcumulado"
        Me.ddcCreRepVencimientoAcumulado.Text = "Acumulado"
        '
        'btnCreRepClientes
        '
        Me.btnCreRepClientes.Image = CType(resources.GetObject("btnCreRepClientes.Image"), System.Drawing.Image)
        Me.btnCreRepClientes.Key = "ButtonCommand1"
        Me.btnCreRepClientes.Name = "btnCreRepClientes"
        Me.btnCreRepClientes.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCreRepClientes.Text = "Clientes"
        '
        'rbbTabImportaciones
        '
        Me.rbbTabImportaciones.Groups.AddRange(New Janus.Windows.Ribbon.RibbonGroup() {Me.rbbImpImportaciones, Me.rbbImpPedidos, Me.rbbImpConsultas, Me.rbbImpReportes})
        Me.rbbTabImportaciones.Key = "4"
        Me.rbbTabImportaciones.KeyTip = "Impotaciones"
        Me.rbbTabImportaciones.Name = "rbbTabImportaciones"
        Me.rbbTabImportaciones.Text = "Importaciones"
        '
        'rbbImpImportaciones
        '
        Me.rbbImpImportaciones.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnImpImpDocumentos, Me.btnImpImpEmbarque})
        Me.rbbImpImportaciones.ImageKey = ""
        Me.rbbImpImportaciones.Key = "RibbonGroup1"
        Me.rbbImpImportaciones.Name = "rbbImpImportaciones"
        Me.rbbImpImportaciones.Text = "Importaciones"
        '
        'btnImpImpDocumentos
        '
        Me.btnImpImpDocumentos.Image = CType(resources.GetObject("btnImpImpDocumentos.Image"), System.Drawing.Image)
        Me.btnImpImpDocumentos.Key = "ButtonCommand1"
        Me.btnImpImpDocumentos.Name = "btnImpImpDocumentos"
        Me.btnImpImpDocumentos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnImpImpDocumentos.Text = "Documentos"
        '
        'btnImpImpEmbarque
        '
        Me.btnImpImpEmbarque.Icon = CType(resources.GetObject("btnImpImpEmbarque.Icon"), System.Drawing.Icon)
        Me.btnImpImpEmbarque.Key = "ButtonCommand1"
        Me.btnImpImpEmbarque.Name = "btnImpImpEmbarque"
        Me.btnImpImpEmbarque.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnImpImpEmbarque.Text = "Embarque"
        '
        'rbbImpPedidos
        '
        Me.rbbImpPedidos.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnImpPedImportacion, Me.btnImpPedInternos})
        Me.rbbImpPedidos.ImageKey = ""
        Me.rbbImpPedidos.Key = "RibbonGroup2"
        Me.rbbImpPedidos.Name = "rbbImpPedidos"
        Me.rbbImpPedidos.Text = "Pedidos"
        '
        'btnImpPedImportacion
        '
        Me.btnImpPedImportacion.Image = CType(resources.GetObject("btnImpPedImportacion.Image"), System.Drawing.Image)
        Me.btnImpPedImportacion.Key = "ButtonCommand2"
        Me.btnImpPedImportacion.Name = "btnImpPedImportacion"
        Me.btnImpPedImportacion.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnImpPedImportacion.Text = "Orden Importación"
        '
        'btnImpPedInternos
        '
        Me.btnImpPedInternos.Icon = CType(resources.GetObject("btnImpPedInternos.Icon"), System.Drawing.Icon)
        Me.btnImpPedInternos.Key = "ButtonCommand3"
        Me.btnImpPedInternos.Name = "btnImpPedInternos"
        Me.btnImpPedInternos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnImpPedInternos.Text = "Internos"
        '
        'rbbImpConsultas
        '
        Me.rbbImpConsultas.ImageKey = ""
        Me.rbbImpConsultas.Key = "RibbonGroup1"
        Me.rbbImpConsultas.Name = "rbbImpConsultas"
        Me.rbbImpConsultas.Text = "Consultas"
        '
        'rbbImpReportes
        '
        Me.rbbImpReportes.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnImpRepPedidoImp, Me.btnImpRepEmbarques, Me.btnImpRepPedido})
        Me.rbbImpReportes.ImageKey = ""
        Me.rbbImpReportes.Key = "RibbonGroup1"
        Me.rbbImpReportes.Name = "rbbImpReportes"
        Me.rbbImpReportes.Text = "Reportes"
        '
        'btnImpRepPedidoImp
        '
        Me.btnImpRepPedidoImp.Image = CType(resources.GetObject("btnImpRepPedidoImp.Image"), System.Drawing.Image)
        Me.btnImpRepPedidoImp.Key = "ButtonCommand1"
        Me.btnImpRepPedidoImp.Name = "btnImpRepPedidoImp"
        Me.btnImpRepPedidoImp.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnImpRepPedidoImp.Text = "Orden de Importación"
        '
        'btnImpRepEmbarques
        '
        Me.btnImpRepEmbarques.Icon = CType(resources.GetObject("btnImpRepEmbarques.Icon"), System.Drawing.Icon)
        Me.btnImpRepEmbarques.Key = "ButtonCommand1"
        Me.btnImpRepEmbarques.Name = "btnImpRepEmbarques"
        Me.btnImpRepEmbarques.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnImpRepEmbarques.Text = "Embarques de Importación"
        '
        'btnImpRepPedido
        '
        Me.btnImpRepPedido.Image = CType(resources.GetObject("btnImpRepPedido.Image"), System.Drawing.Image)
        Me.btnImpRepPedido.Key = "ButtonCommand1"
        Me.btnImpRepPedido.Name = "btnImpRepPedido"
        Me.btnImpRepPedido.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnImpRepPedido.Text = "Pedido Interno"
        '
        'rbbTabCostos
        '
        Me.rbbTabCostos.Groups.AddRange(New Janus.Windows.Ribbon.RibbonGroup() {Me.rbbCostoImportaciones, Me.rbbCostoProcesos, Me.rbbCostoDocumentos, Me.rbbCostoReportes})
        Me.rbbTabCostos.Key = "5"
        Me.rbbTabCostos.KeyTip = "Costos"
        Me.rbbTabCostos.Name = "rbbTabCostos"
        Me.rbbTabCostos.Text = "Costos"
        '
        'rbbCostoImportaciones
        '
        Me.rbbCostoImportaciones.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnCostoValorizarImp})
        Me.rbbCostoImportaciones.Key = "RibbonGroup4"
        Me.rbbCostoImportaciones.Name = "rbbCostoImportaciones"
        Me.rbbCostoImportaciones.Text = "Importaciones"
        '
        'btnCostoValorizarImp
        '
        Me.btnCostoValorizarImp.Image = CType(resources.GetObject("btnCostoValorizarImp.Image"), System.Drawing.Image)
        Me.btnCostoValorizarImp.Key = "ButtonCommand1"
        Me.btnCostoValorizarImp.Name = "btnCostoValorizarImp"
        Me.btnCostoValorizarImp.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCostoValorizarImp.Text = "Valorizar F/I"
        '
        'rbbCostoProcesos
        '
        Me.rbbCostoProcesos.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnCostoRecalcular, Me.btnCostoAjustarCierre, Me.btnCostoCerrarMes, Me.btnCostoConsolidado, Me.btnCostoProTrasladarCosto, Me.btnCostoProGenerarPeriodo, Me.btnCostoProInvRotativo})
        Me.rbbCostoProcesos.Key = "RibbonGroup5"
        Me.rbbCostoProcesos.Name = "rbbCostoProcesos"
        Me.rbbCostoProcesos.Text = "Procesos"
        '
        'btnCostoRecalcular
        '
        Me.btnCostoRecalcular.Image = CType(resources.GetObject("btnCostoRecalcular.Image"), System.Drawing.Image)
        Me.btnCostoRecalcular.Key = "ButtonCommand2"
        Me.btnCostoRecalcular.Name = "btnCostoRecalcular"
        Me.btnCostoRecalcular.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCostoRecalcular.Text = "Recalcular"
        '
        'btnCostoAjustarCierre
        '
        Me.btnCostoAjustarCierre.Image = CType(resources.GetObject("btnCostoAjustarCierre.Image"), System.Drawing.Image)
        Me.btnCostoAjustarCierre.Key = "ButtonCommand3"
        Me.btnCostoAjustarCierre.Name = "btnCostoAjustarCierre"
        Me.btnCostoAjustarCierre.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCostoAjustarCierre.Text = "Ajustar Costos"
        '
        'btnCostoCerrarMes
        '
        Me.btnCostoCerrarMes.Image = CType(resources.GetObject("btnCostoCerrarMes.Image"), System.Drawing.Image)
        Me.btnCostoCerrarMes.Key = "ButtonCommand4"
        Me.btnCostoCerrarMes.Name = "btnCostoCerrarMes"
        Me.btnCostoCerrarMes.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCostoCerrarMes.Text = "Cerrar Mes"
        '
        'btnCostoConsolidado
        '
        Me.btnCostoConsolidado.Image = CType(resources.GetObject("btnCostoConsolidado.Image"), System.Drawing.Image)
        Me.btnCostoConsolidado.Key = "ButtonCommand6"
        Me.btnCostoConsolidado.Name = "btnCostoConsolidado"
        Me.btnCostoConsolidado.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCostoConsolidado.Text = "Consolidado"
        '
        'btnCostoProTrasladarCosto
        '
        Me.btnCostoProTrasladarCosto.Image = CType(resources.GetObject("btnCostoProTrasladarCosto.Image"), System.Drawing.Image)
        Me.btnCostoProTrasladarCosto.Key = "ButtonCommand1"
        Me.btnCostoProTrasladarCosto.Name = "btnCostoProTrasladarCosto"
        Me.btnCostoProTrasladarCosto.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCostoProTrasladarCosto.Text = "Trasladar Costos"
        '
        'btnCostoProGenerarPeriodo
        '
        Me.btnCostoProGenerarPeriodo.Image = CType(resources.GetObject("btnCostoProGenerarPeriodo.Image"), System.Drawing.Image)
        Me.btnCostoProGenerarPeriodo.Key = "ButtonCommand1"
        Me.btnCostoProGenerarPeriodo.Name = "btnCostoProGenerarPeriodo"
        Me.btnCostoProGenerarPeriodo.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCostoProGenerarPeriodo.Text = "Generar Periodo"
        '
        'btnCostoProInvRotativo
        '
        Me.btnCostoProInvRotativo.Icon = CType(resources.GetObject("btnCostoProInvRotativo.Icon"), System.Drawing.Icon)
        Me.btnCostoProInvRotativo.Key = "ButtonCommand1"
        Me.btnCostoProInvRotativo.Name = "btnCostoProInvRotativo"
        Me.btnCostoProInvRotativo.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCostoProInvRotativo.Text = "Inv. Rotativo"
        '
        'rbbCostoDocumentos
        '
        Me.rbbCostoDocumentos.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnCostoActualizarDocs})
        Me.rbbCostoDocumentos.Key = "RibbonGroup6"
        Me.rbbCostoDocumentos.Name = "rbbCostoDocumentos"
        Me.rbbCostoDocumentos.Text = "Documentos"
        '
        'btnCostoActualizarDocs
        '
        Me.btnCostoActualizarDocs.Image = CType(resources.GetObject("btnCostoActualizarDocs.Image"), System.Drawing.Image)
        Me.btnCostoActualizarDocs.Key = "ButtonCommand5"
        Me.btnCostoActualizarDocs.Name = "btnCostoActualizarDocs"
        Me.btnCostoActualizarDocs.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCostoActualizarDocs.Text = "Actualizar Costos"
        '
        'rbbCostoReportes
        '
        Me.rbbCostoReportes.AllowAutoSizeItems = False
        Me.rbbCostoReportes.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnCostoRepImportaciones, Me.btnCostoDiarioAlmacen, Me.btnCostoStockValorizado, Me.btnCostoRepCierreMes, Me.btnCostoRepKardex, Me.btnCostoRepCostoVenta, Me.btnCostoRepCondensado, Me.btnCostoRepMotores, Me.btnCostoRepResumenGen, Me.btnCostoRepSobregiro, Me.btnCostoRepGMROI})
        Me.rbbCostoReportes.Key = "RibbonGroup8"
        Me.rbbCostoReportes.Name = "rbbCostoReportes"
        Me.rbbCostoReportes.Text = "Reportes"
        '
        'btnCostoRepImportaciones
        '
        Me.btnCostoRepImportaciones.Image = CType(resources.GetObject("btnCostoRepImportaciones.Image"), System.Drawing.Image)
        Me.btnCostoRepImportaciones.Key = "ButtonCommand7"
        Me.btnCostoRepImportaciones.Name = "btnCostoRepImportaciones"
        Me.btnCostoRepImportaciones.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCostoRepImportaciones.Text = "Importaciones"
        '
        'btnCostoDiarioAlmacen
        '
        Me.btnCostoDiarioAlmacen.Image = CType(resources.GetObject("btnCostoDiarioAlmacen.Image"), System.Drawing.Image)
        Me.btnCostoDiarioAlmacen.Key = "ButtonCommand8"
        Me.btnCostoDiarioAlmacen.Name = "btnCostoDiarioAlmacen"
        Me.btnCostoDiarioAlmacen.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCostoDiarioAlmacen.Text = "Diario de Almacen"
        '
        'btnCostoStockValorizado
        '
        Me.btnCostoStockValorizado.Image = CType(resources.GetObject("btnCostoStockValorizado.Image"), System.Drawing.Image)
        Me.btnCostoStockValorizado.Key = "ButtonCommand9"
        Me.btnCostoStockValorizado.Name = "btnCostoStockValorizado"
        Me.btnCostoStockValorizado.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCostoStockValorizado.Text = "Stock Valorizado"
        '
        'btnCostoRepCierreMes
        '
        Me.btnCostoRepCierreMes.Image = CType(resources.GetObject("btnCostoRepCierreMes.Image"), System.Drawing.Image)
        Me.btnCostoRepCierreMes.Key = "ButtonCommand10"
        Me.btnCostoRepCierreMes.Name = "btnCostoRepCierreMes"
        Me.btnCostoRepCierreMes.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCostoRepCierreMes.Text = "Cuadrar Cierre"
        '
        'btnCostoRepKardex
        '
        Me.btnCostoRepKardex.Image = CType(resources.GetObject("btnCostoRepKardex.Image"), System.Drawing.Image)
        Me.btnCostoRepKardex.Key = "ButtonCommand1"
        Me.btnCostoRepKardex.Name = "btnCostoRepKardex"
        Me.btnCostoRepKardex.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCostoRepKardex.Text = "Kardex"
        '
        'btnCostoRepCostoVenta
        '
        Me.btnCostoRepCostoVenta.Image = CType(resources.GetObject("btnCostoRepCostoVenta.Image"), System.Drawing.Image)
        Me.btnCostoRepCostoVenta.Key = "ButtonCommand2"
        Me.btnCostoRepCostoVenta.Name = "btnCostoRepCostoVenta"
        Me.btnCostoRepCostoVenta.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCostoRepCostoVenta.Text = "Costo de Venta"
        '
        'btnCostoRepCondensado
        '
        Me.btnCostoRepCondensado.Image = CType(resources.GetObject("btnCostoRepCondensado.Image"), System.Drawing.Image)
        Me.btnCostoRepCondensado.Key = "ButtonCommand3"
        Me.btnCostoRepCondensado.Name = "btnCostoRepCondensado"
        Me.btnCostoRepCondensado.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCostoRepCondensado.Text = "Condensados"
        '
        'btnCostoRepMotores
        '
        Me.btnCostoRepMotores.Image = CType(resources.GetObject("btnCostoRepMotores.Image"), System.Drawing.Image)
        Me.btnCostoRepMotores.Key = "ButtonCommand1"
        Me.btnCostoRepMotores.Name = "btnCostoRepMotores"
        Me.btnCostoRepMotores.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCostoRepMotores.Text = "Motores"
        '
        'btnCostoRepResumenGen
        '
        Me.btnCostoRepResumenGen.Image = CType(resources.GetObject("btnCostoRepResumenGen.Image"), System.Drawing.Image)
        Me.btnCostoRepResumenGen.Key = "ButtonCommand1"
        Me.btnCostoRepResumenGen.Name = "btnCostoRepResumenGen"
        Me.btnCostoRepResumenGen.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCostoRepResumenGen.Text = "Resumen General"
        '
        'btnCostoRepSobregiro
        '
        Me.btnCostoRepSobregiro.Image = CType(resources.GetObject("btnCostoRepSobregiro.Image"), System.Drawing.Image)
        Me.btnCostoRepSobregiro.Key = "ButtonCommand1"
        Me.btnCostoRepSobregiro.Name = "btnCostoRepSobregiro"
        Me.btnCostoRepSobregiro.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCostoRepSobregiro.Text = "Sobregiro"
        '
        'btnCostoRepGMROI
        '
        Me.btnCostoRepGMROI.Image = CType(resources.GetObject("btnCostoRepGMROI.Image"), System.Drawing.Image)
        Me.btnCostoRepGMROI.Key = "ButtonCommand1"
        Me.btnCostoRepGMROI.Name = "btnCostoRepGMROI"
        Me.btnCostoRepGMROI.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCostoRepGMROI.Text = "GMROI"
        '
        'rbbTabGerencia
        '
        Me.rbbTabGerencia.Groups.AddRange(New Janus.Windows.Ribbon.RibbonGroup() {Me.rbbGerReportes})
        Me.rbbTabGerencia.Key = "RibbonTab2"
        Me.rbbTabGerencia.KeyTip = "Gerencia"
        Me.rbbTabGerencia.Name = "rbbTabGerencia"
        Me.rbbTabGerencia.Text = "Gerencia"
        '
        'rbbGerReportes
        '
        Me.rbbGerReportes.AllowAutoSizeItems = False
        Me.rbbGerReportes.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnGerVentas, Me.btnGerImportaciones, Me.btnGerInventario, Me.btnGerContabilidad, Me.btnGerCreditos, Me.btnGerServicios, Me.btnGerFiltroIndicadores, Me.btnGerTarjeta, Me.btnGerConsolidado, Me.btnGerEstadosFinancieros})
        Me.rbbGerReportes.Key = "RibbonGroup2"
        Me.rbbGerReportes.Name = "rbbGerReportes"
        Me.rbbGerReportes.Text = "Reportes"
        '
        'btnGerVentas
        '
        Me.btnGerVentas.Icon = CType(resources.GetObject("btnGerVentas.Icon"), System.Drawing.Icon)
        Me.btnGerVentas.Key = "ButtonCommand1"
        Me.btnGerVentas.Name = "btnGerVentas"
        Me.btnGerVentas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnGerVentas.Text = "000 - Ventas"
        '
        'btnGerImportaciones
        '
        Me.btnGerImportaciones.Icon = CType(resources.GetObject("btnGerImportaciones.Icon"), System.Drawing.Icon)
        Me.btnGerImportaciones.Key = "ButtonCommand1"
        Me.btnGerImportaciones.Name = "btnGerImportaciones"
        Me.btnGerImportaciones.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnGerImportaciones.Text = "010 - Importaciones"
        '
        'btnGerInventario
        '
        Me.btnGerInventario.Icon = CType(resources.GetObject("btnGerInventario.Icon"), System.Drawing.Icon)
        Me.btnGerInventario.Key = "ButtonCommand1"
        Me.btnGerInventario.Name = "btnGerInventario"
        Me.btnGerInventario.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnGerInventario.Text = "020 - Inventario y Costos"
        '
        'btnGerContabilidad
        '
        Me.btnGerContabilidad.Icon = CType(resources.GetObject("btnGerContabilidad.Icon"), System.Drawing.Icon)
        Me.btnGerContabilidad.Key = "ButtonCommand1"
        Me.btnGerContabilidad.Name = "btnGerContabilidad"
        Me.btnGerContabilidad.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnGerContabilidad.Text = "030 - Contabilidad"
        '
        'btnGerCreditos
        '
        Me.btnGerCreditos.Icon = CType(resources.GetObject("btnGerCreditos.Icon"), System.Drawing.Icon)
        Me.btnGerCreditos.Key = "ButtonCommand1"
        Me.btnGerCreditos.Name = "btnGerCreditos"
        Me.btnGerCreditos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnGerCreditos.Text = "040 - Creditos y Cobranzas"
        '
        'btnGerServicios
        '
        Me.btnGerServicios.Icon = CType(resources.GetObject("btnGerServicios.Icon"), System.Drawing.Icon)
        Me.btnGerServicios.Key = "ButtonCommand1"
        Me.btnGerServicios.Name = "btnGerServicios"
        Me.btnGerServicios.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnGerServicios.Text = "050 - Servicios"
        '
        'btnGerFiltroIndicadores
        '
        Me.btnGerFiltroIndicadores.Image = CType(resources.GetObject("btnGerFiltroIndicadores.Image"), System.Drawing.Image)
        Me.btnGerFiltroIndicadores.Key = "ButtonCommand1"
        Me.btnGerFiltroIndicadores.Name = "btnGerFiltroIndicadores"
        Me.btnGerFiltroIndicadores.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnGerFiltroIndicadores.Text = "Datos para Indicadores"
        '
        'btnGerTarjeta
        '
        Me.btnGerTarjeta.Image = CType(resources.GetObject("btnGerTarjeta.Image"), System.Drawing.Image)
        Me.btnGerTarjeta.Key = "ButtonCommand1"
        Me.btnGerTarjeta.Name = "btnGerTarjeta"
        Me.btnGerTarjeta.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnGerTarjeta.Text = "Tarjeta"
        '
        'btnGerConsolidado
        '
        Me.btnGerConsolidado.Image = CType(resources.GetObject("btnGerConsolidado.Image"), System.Drawing.Image)
        Me.btnGerConsolidado.Key = "ButtonCommand1"
        Me.btnGerConsolidado.Name = "btnGerConsolidado"
        Me.btnGerConsolidado.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnGerConsolidado.Text = "Contenedor Reportes"
        '
        'btnGerEstadosFinancieros
        '
        Me.btnGerEstadosFinancieros.Icon = CType(resources.GetObject("btnGerEstadosFinancieros.Icon"), System.Drawing.Icon)
        Me.btnGerEstadosFinancieros.Key = "ButtonCommand1"
        Me.btnGerEstadosFinancieros.Name = "btnGerEstadosFinancieros"
        Me.btnGerEstadosFinancieros.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnGerEstadosFinancieros.Text = "Estados Financieros"
        '
        'rbbTabServicios
        '
        Me.rbbTabServicios.Groups.AddRange(New Janus.Windows.Ribbon.RibbonGroup() {Me.rbbSerAlmacen, Me.rbbSerVentas, Me.rbbSerJob, Me.rbbSerGarantia, Me.rbbSerVehiculos, Me.rbbSerMantenimiento, Me.rbbSerConsultas, Me.rbbSerIndicadores, Me.rbbSerProyeccion, Me.rbbSerReportes})
        Me.rbbTabServicios.Key = "RibbonTab2"
        Me.rbbTabServicios.Name = "rbbTabServicios"
        Me.rbbTabServicios.Text = "Servicios"
        '
        'rbbSerAlmacen
        '
        Me.rbbSerAlmacen.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnSerPedirRepuesto})
        Me.rbbSerAlmacen.Key = "RibbonGroup2"
        Me.rbbSerAlmacen.Name = "rbbSerAlmacen"
        Me.rbbSerAlmacen.Text = "Almacen"
        '
        'btnSerPedirRepuesto
        '
        Me.btnSerPedirRepuesto.Icon = CType(resources.GetObject("btnSerPedirRepuesto.Icon"), System.Drawing.Icon)
        Me.btnSerPedirRepuesto.Key = "ButtonCommand1"
        Me.btnSerPedirRepuesto.Name = "btnSerPedirRepuesto"
        Me.btnSerPedirRepuesto.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerPedirRepuesto.Text = "Pedir Repuestos"
        '
        'rbbSerVentas
        '
        Me.rbbSerVentas.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnSerCotizacion})
        Me.rbbSerVentas.Key = "RibbonGroup4"
        Me.rbbSerVentas.Name = "rbbSerVentas"
        Me.rbbSerVentas.Text = "Ventas"
        '
        'btnSerCotizacion
        '
        Me.btnSerCotizacion.Image = CType(resources.GetObject("btnSerCotizacion.Image"), System.Drawing.Image)
        Me.btnSerCotizacion.Key = "ButtonCommand1"
        Me.btnSerCotizacion.Name = "btnSerCotizacion"
        Me.btnSerCotizacion.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerCotizacion.Text = "Cotizacion"
        '
        'rbbSerJob
        '
        Me.rbbSerJob.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnSerSolicitudJob, Me.btnSerJob, Me.btnSerMarcacionJob, Me.btnSerGastoReal, Me.btnSerGastoViaje, Me.btnSerPreMarcacionJob, Me.btnSerMarcacionOT})
        Me.rbbSerJob.Key = "RibbonGroup5"
        Me.rbbSerJob.Name = "rbbSerJob"
        Me.rbbSerJob.Text = "Orden de Trabajo"
        '
        'btnSerSolicitudJob
        '
        Me.btnSerSolicitudJob.Icon = CType(resources.GetObject("btnSerSolicitudJob.Icon"), System.Drawing.Icon)
        Me.btnSerSolicitudJob.Key = "ButtonCommand1"
        Me.btnSerSolicitudJob.Name = "btnSerSolicitudJob"
        Me.btnSerSolicitudJob.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerSolicitudJob.Text = "Solicitud OT"
        '
        'btnSerJob
        '
        Me.btnSerJob.Icon = CType(resources.GetObject("btnSerJob.Icon"), System.Drawing.Icon)
        Me.btnSerJob.Key = "ButtonCommand1"
        Me.btnSerJob.Name = "btnSerJob"
        Me.btnSerJob.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerJob.Text = "OT"
        '
        'btnSerMarcacionJob
        '
        Me.btnSerMarcacionJob.Icon = CType(resources.GetObject("btnSerMarcacionJob.Icon"), System.Drawing.Icon)
        Me.btnSerMarcacionJob.Key = "ButtonCommand1"
        Me.btnSerMarcacionJob.Name = "btnSerMarcacionJob"
        Me.btnSerMarcacionJob.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerMarcacionJob.Text = "Marcaciones"
        '
        'btnSerGastoReal
        '
        Me.btnSerGastoReal.Icon = CType(resources.GetObject("btnSerGastoReal.Icon"), System.Drawing.Icon)
        Me.btnSerGastoReal.Key = "ButtonCommand1"
        Me.btnSerGastoReal.Name = "btnSerGastoReal"
        Me.btnSerGastoReal.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerGastoReal.Text = "Gastos Reales"
        '
        'btnSerGastoViaje
        '
        Me.btnSerGastoViaje.Icon = CType(resources.GetObject("btnSerGastoViaje.Icon"), System.Drawing.Icon)
        Me.btnSerGastoViaje.Key = "ButtonCommand1"
        Me.btnSerGastoViaje.Name = "btnSerGastoViaje"
        Me.btnSerGastoViaje.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerGastoViaje.Text = "Gastos Viaje"
        '
        'btnSerPreMarcacionJob
        '
        Me.btnSerPreMarcacionJob.Icon = CType(resources.GetObject("btnSerPreMarcacionJob.Icon"), System.Drawing.Icon)
        Me.btnSerPreMarcacionJob.Key = "ButtonCommand1"
        Me.btnSerPreMarcacionJob.Name = "btnSerPreMarcacionJob"
        Me.btnSerPreMarcacionJob.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerPreMarcacionJob.Text = "Pre Marcacion"
        '
        'btnSerMarcacionOT
        '
        Me.btnSerMarcacionOT.Image = CType(resources.GetObject("btnSerMarcacionOT.Image"), System.Drawing.Image)
        Me.btnSerMarcacionOT.Key = "ButtonCommand1"
        Me.btnSerMarcacionOT.Name = "btnSerMarcacionOT"
        Me.btnSerMarcacionOT.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerMarcacionOT.Text = "Marcar OT"
        '
        'rbbSerGarantia
        '
        Me.rbbSerGarantia.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnSerAfa, Me.btnSerReclamoCliente})
        Me.rbbSerGarantia.Key = "RibbonGroup4"
        Me.rbbSerGarantia.Name = "rbbSerGarantia"
        Me.rbbSerGarantia.Text = "Garantia"
        '
        'btnSerAfa
        '
        Me.btnSerAfa.Icon = CType(resources.GetObject("btnSerAfa.Icon"), System.Drawing.Icon)
        Me.btnSerAfa.Key = "ButtonCommand1"
        Me.btnSerAfa.Name = "btnSerAfa"
        Me.btnSerAfa.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerAfa.Text = "Orden Reparación"
        '
        'btnSerReclamoCliente
        '
        Me.btnSerReclamoCliente.Image = CType(resources.GetObject("btnSerReclamoCliente.Image"), System.Drawing.Image)
        Me.btnSerReclamoCliente.Key = "ButtonCommand1"
        Me.btnSerReclamoCliente.Name = "btnSerReclamoCliente"
        Me.btnSerReclamoCliente.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerReclamoCliente.Text = "Reclamo Cliente"
        '
        'rbbSerVehiculos
        '
        Me.rbbSerVehiculos.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnSerKilometraje})
        Me.rbbSerVehiculos.Key = "RibbonGroup4"
        Me.rbbSerVehiculos.Name = "rbbSerVehiculos"
        Me.rbbSerVehiculos.Text = "Control Vehicular"
        '
        'btnSerKilometraje
        '
        Me.btnSerKilometraje.Icon = CType(resources.GetObject("btnSerKilometraje.Icon"), System.Drawing.Icon)
        Me.btnSerKilometraje.Key = "ButtonCommand1"
        Me.btnSerKilometraje.Name = "btnSerKilometraje"
        Me.btnSerKilometraje.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerKilometraje.Text = "Kilometraje"
        '
        'rbbSerMantenimiento
        '
        Me.rbbSerMantenimiento.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnSerManOficinaUsuario})
        Me.rbbSerMantenimiento.Key = "RibbonGroup4"
        Me.rbbSerMantenimiento.Name = "rbbSerMantenimiento"
        Me.rbbSerMantenimiento.Text = "Mantenimiento"
        '
        'btnSerManOficinaUsuario
        '
        Me.btnSerManOficinaUsuario.Image = CType(resources.GetObject("btnSerManOficinaUsuario.Image"), System.Drawing.Image)
        Me.btnSerManOficinaUsuario.Key = "ButtonCommand1"
        Me.btnSerManOficinaUsuario.Name = "btnSerManOficinaUsuario"
        Me.btnSerManOficinaUsuario.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerManOficinaUsuario.Text = "Oficina Usuario"
        '
        'rbbSerConsultas
        '
        Me.rbbSerConsultas.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnSerConJob, Me.btnSerConMarcacionJob, Me.btnSerConGastoRealJob})
        Me.rbbSerConsultas.Key = "RibbonGroup4"
        Me.rbbSerConsultas.Name = "rbbSerConsultas"
        Me.rbbSerConsultas.Text = "Consultas"
        '
        'btnSerConJob
        '
        Me.btnSerConJob.Icon = CType(resources.GetObject("btnSerConJob.Icon"), System.Drawing.Icon)
        Me.btnSerConJob.Key = "ButtonCommand1"
        Me.btnSerConJob.Name = "btnSerConJob"
        Me.btnSerConJob.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerConJob.Text = "OT"
        '
        'btnSerConMarcacionJob
        '
        Me.btnSerConMarcacionJob.Icon = CType(resources.GetObject("btnSerConMarcacionJob.Icon"), System.Drawing.Icon)
        Me.btnSerConMarcacionJob.Key = "ButtonCommand1"
        Me.btnSerConMarcacionJob.Name = "btnSerConMarcacionJob"
        Me.btnSerConMarcacionJob.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerConMarcacionJob.Text = "Marcaciones"
        '
        'btnSerConGastoRealJob
        '
        Me.btnSerConGastoRealJob.Icon = CType(resources.GetObject("btnSerConGastoRealJob.Icon"), System.Drawing.Icon)
        Me.btnSerConGastoRealJob.Key = "ButtonCommand1"
        Me.btnSerConGastoRealJob.Name = "btnSerConGastoRealJob"
        Me.btnSerConGastoRealJob.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerConGastoRealJob.Text = "Gastos Reales"
        '
        'rbbSerIndicadores
        '
        Me.rbbSerIndicadores.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnSerIndActividades, Me.btnSerIndProgramacion, Me.btnSerIndPlantilla, Me.btnSerIndTablero, Me.btnSerIndProductividad})
        Me.rbbSerIndicadores.Key = "RibbonGroup4"
        Me.rbbSerIndicadores.Name = "rbbSerIndicadores"
        Me.rbbSerIndicadores.Text = "Indicadores"
        '
        'btnSerIndActividades
        '
        Me.btnSerIndActividades.Icon = CType(resources.GetObject("btnSerIndActividades.Icon"), System.Drawing.Icon)
        Me.btnSerIndActividades.Key = "ButtonCommand1"
        Me.btnSerIndActividades.Name = "btnSerIndActividades"
        Me.btnSerIndActividades.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerIndActividades.Text = "Actividades"
        '
        'btnSerIndProgramacion
        '
        Me.btnSerIndProgramacion.Icon = CType(resources.GetObject("btnSerIndProgramacion.Icon"), System.Drawing.Icon)
        Me.btnSerIndProgramacion.Key = "ButtonCommand1"
        Me.btnSerIndProgramacion.Name = "btnSerIndProgramacion"
        Me.btnSerIndProgramacion.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerIndProgramacion.Text = "Programacion"
        '
        'btnSerIndPlantilla
        '
        Me.btnSerIndPlantilla.Icon = CType(resources.GetObject("btnSerIndPlantilla.Icon"), System.Drawing.Icon)
        Me.btnSerIndPlantilla.Key = "ButtonCommand2"
        Me.btnSerIndPlantilla.Name = "btnSerIndPlantilla"
        Me.btnSerIndPlantilla.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerIndPlantilla.Text = "Plantilla"
        '
        'btnSerIndTablero
        '
        Me.btnSerIndTablero.Image = CType(resources.GetObject("btnSerIndTablero.Image"), System.Drawing.Image)
        Me.btnSerIndTablero.Key = "ButtonCommand1"
        Me.btnSerIndTablero.Name = "btnSerIndTablero"
        Me.btnSerIndTablero.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerIndTablero.Text = "Tablero"
        '
        'btnSerIndProductividad
        '
        Me.btnSerIndProductividad.Icon = CType(resources.GetObject("btnSerIndProductividad.Icon"), System.Drawing.Icon)
        Me.btnSerIndProductividad.Key = "ButtonCommand1"
        Me.btnSerIndProductividad.Name = "btnSerIndProductividad"
        Me.btnSerIndProductividad.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerIndProductividad.Text = "Productividad"
        '
        'rbbSerProyeccion
        '
        Me.rbbSerProyeccion.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnSerProHorasMotor, Me.btnSerProEquipos, Me.btnSerProSeguimiento, Me.btnSerProRepuestos, Me.btnSerProGenerarPedidoInterno})
        Me.rbbSerProyeccion.Key = "RibbonGroup4"
        Me.rbbSerProyeccion.Name = "rbbSerProyeccion"
        Me.rbbSerProyeccion.Text = "Proyección"
        '
        'btnSerProHorasMotor
        '
        Me.btnSerProHorasMotor.Image = CType(resources.GetObject("btnSerProHorasMotor.Image"), System.Drawing.Image)
        Me.btnSerProHorasMotor.Key = "ButtonCommand1"
        Me.btnSerProHorasMotor.Name = "btnSerProHorasMotor"
        Me.btnSerProHorasMotor.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerProHorasMotor.Text = "Horas Motor"
        '
        'btnSerProEquipos
        '
        Me.btnSerProEquipos.Image = CType(resources.GetObject("btnSerProEquipos.Image"), System.Drawing.Image)
        Me.btnSerProEquipos.Key = "ButtonCommand1"
        Me.btnSerProEquipos.Name = "btnSerProEquipos"
        Me.btnSerProEquipos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerProEquipos.Text = "Motores"
        '
        'btnSerProSeguimiento
        '
        Me.btnSerProSeguimiento.Image = CType(resources.GetObject("btnSerProSeguimiento.Image"), System.Drawing.Image)
        Me.btnSerProSeguimiento.Key = "ButtonCommand1"
        Me.btnSerProSeguimiento.Name = "btnSerProSeguimiento"
        Me.btnSerProSeguimiento.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerProSeguimiento.Text = "Seguimiento"
        '
        'btnSerProRepuestos
        '
        Me.btnSerProRepuestos.Image = CType(resources.GetObject("btnSerProRepuestos.Image"), System.Drawing.Image)
        Me.btnSerProRepuestos.Key = "ButtonCommand1"
        Me.btnSerProRepuestos.Name = "btnSerProRepuestos"
        Me.btnSerProRepuestos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerProRepuestos.Text = "Repuestos"
        '
        'btnSerProGenerarPedidoInterno
        '
        Me.btnSerProGenerarPedidoInterno.Icon = CType(resources.GetObject("btnSerProGenerarPedidoInterno.Icon"), System.Drawing.Icon)
        Me.btnSerProGenerarPedidoInterno.Key = "ButtonCommand1"
        Me.btnSerProGenerarPedidoInterno.Name = "btnSerProGenerarPedidoInterno"
        Me.btnSerProGenerarPedidoInterno.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerProGenerarPedidoInterno.Text = "Generar Pedido"
        '
        'rbbSerReportes
        '
        Me.rbbSerReportes.AllowAutoSizeItems = False
        Me.rbbSerReportes.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnSerRepMovRepuesto, Me.btnSerRepHorasEscalon, Me.btnSerRepHorasGenerales, Me.btnSerRepCostosDirectos, Me.btnSerRepGastosPorRubro, Me.btnSerRepGastosViajePorRubro, Me.btnSerRepJobPendienteFacturacion, Me.btnSerRepJobGarantias, Me.btnSerRepTiempoReparacion, Me.btnSerRepAfas, Me.btnSerRepCotizaciones, Me.btnSerRepSolicitudJob, Me.btnSerRepJob, Me.btnSerRepHorasMuertas, Me.ddcSerRepProyeccion})
        Me.rbbSerReportes.Key = "RibbonGroup4"
        Me.rbbSerReportes.Name = "rbbSerReportes"
        Me.rbbSerReportes.Text = "Reportes"
        '
        'btnSerRepMovRepuesto
        '
        Me.btnSerRepMovRepuesto.Icon = CType(resources.GetObject("btnSerRepMovRepuesto.Icon"), System.Drawing.Icon)
        Me.btnSerRepMovRepuesto.Key = "ButtonCommand1"
        Me.btnSerRepMovRepuesto.Name = "btnSerRepMovRepuesto"
        Me.btnSerRepMovRepuesto.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerRepMovRepuesto.Text = "Movimiento Repuestos"
        '
        'btnSerRepHorasEscalon
        '
        Me.btnSerRepHorasEscalon.Icon = CType(resources.GetObject("btnSerRepHorasEscalon.Icon"), System.Drawing.Icon)
        Me.btnSerRepHorasEscalon.Key = "ButtonCommand1"
        Me.btnSerRepHorasEscalon.Name = "btnSerRepHorasEscalon"
        Me.btnSerRepHorasEscalon.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerRepHorasEscalon.Text = "Horas Escalon"
        '
        'btnSerRepHorasGenerales
        '
        Me.btnSerRepHorasGenerales.Icon = CType(resources.GetObject("btnSerRepHorasGenerales.Icon"), System.Drawing.Icon)
        Me.btnSerRepHorasGenerales.Key = "ButtonCommand1"
        Me.btnSerRepHorasGenerales.Name = "btnSerRepHorasGenerales"
        Me.btnSerRepHorasGenerales.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerRepHorasGenerales.Text = "Horas de Trabajo"
        '
        'btnSerRepCostosDirectos
        '
        Me.btnSerRepCostosDirectos.Icon = CType(resources.GetObject("btnSerRepCostosDirectos.Icon"), System.Drawing.Icon)
        Me.btnSerRepCostosDirectos.Key = "ButtonCommand1"
        Me.btnSerRepCostosDirectos.Name = "btnSerRepCostosDirectos"
        Me.btnSerRepCostosDirectos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerRepCostosDirectos.Text = "Gastos Detallado"
        '
        'btnSerRepGastosPorRubro
        '
        Me.btnSerRepGastosPorRubro.Icon = CType(resources.GetObject("btnSerRepGastosPorRubro.Icon"), System.Drawing.Icon)
        Me.btnSerRepGastosPorRubro.Key = "ButtonCommand1"
        Me.btnSerRepGastosPorRubro.Name = "btnSerRepGastosPorRubro"
        Me.btnSerRepGastosPorRubro.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerRepGastosPorRubro.Text = "Gastos Por Rubros"
        '
        'btnSerRepGastosViajePorRubro
        '
        Me.btnSerRepGastosViajePorRubro.Icon = CType(resources.GetObject("btnSerRepGastosViajePorRubro.Icon"), System.Drawing.Icon)
        Me.btnSerRepGastosViajePorRubro.Key = "ButtonCommand1"
        Me.btnSerRepGastosViajePorRubro.Name = "btnSerRepGastosViajePorRubro"
        Me.btnSerRepGastosViajePorRubro.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerRepGastosViajePorRubro.Text = "Gasto Viaje x Rubro"
        '
        'btnSerRepJobPendienteFacturacion
        '
        Me.btnSerRepJobPendienteFacturacion.Icon = CType(resources.GetObject("btnSerRepJobPendienteFacturacion.Icon"), System.Drawing.Icon)
        Me.btnSerRepJobPendienteFacturacion.Key = "ButtonCommand1"
        Me.btnSerRepJobPendienteFacturacion.Name = "btnSerRepJobPendienteFacturacion"
        Me.btnSerRepJobPendienteFacturacion.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerRepJobPendienteFacturacion.Text = "Pendiente Facturacion"
        '
        'btnSerRepJobGarantias
        '
        Me.btnSerRepJobGarantias.Icon = CType(resources.GetObject("btnSerRepJobGarantias.Icon"), System.Drawing.Icon)
        Me.btnSerRepJobGarantias.Key = "ButtonCommand1"
        Me.btnSerRepJobGarantias.Name = "btnSerRepJobGarantias"
        Me.btnSerRepJobGarantias.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerRepJobGarantias.Text = "Liquidación x Garantia"
        '
        'btnSerRepTiempoReparacion
        '
        Me.btnSerRepTiempoReparacion.Icon = CType(resources.GetObject("btnSerRepTiempoReparacion.Icon"), System.Drawing.Icon)
        Me.btnSerRepTiempoReparacion.Key = "ButtonCommand1"
        Me.btnSerRepTiempoReparacion.Name = "btnSerRepTiempoReparacion"
        Me.btnSerRepTiempoReparacion.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerRepTiempoReparacion.Text = "Tiempo Reparación"
        '
        'btnSerRepAfas
        '
        Me.btnSerRepAfas.Icon = CType(resources.GetObject("btnSerRepAfas.Icon"), System.Drawing.Icon)
        Me.btnSerRepAfas.Key = "ButtonCommand1"
        Me.btnSerRepAfas.Name = "btnSerRepAfas"
        Me.btnSerRepAfas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerRepAfas.Text = "Solicitud Garantia"
        '
        'btnSerRepCotizaciones
        '
        Me.btnSerRepCotizaciones.Icon = CType(resources.GetObject("btnSerRepCotizaciones.Icon"), System.Drawing.Icon)
        Me.btnSerRepCotizaciones.Key = "ButtonCommand1"
        Me.btnSerRepCotizaciones.Name = "btnSerRepCotizaciones"
        Me.btnSerRepCotizaciones.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerRepCotizaciones.Text = "Cotizaciones"
        '
        'btnSerRepSolicitudJob
        '
        Me.btnSerRepSolicitudJob.Icon = CType(resources.GetObject("btnSerRepSolicitudJob.Icon"), System.Drawing.Icon)
        Me.btnSerRepSolicitudJob.Key = "ButtonCommand1"
        Me.btnSerRepSolicitudJob.Name = "btnSerRepSolicitudJob"
        Me.btnSerRepSolicitudJob.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerRepSolicitudJob.Text = "Solicitud OT"
        '
        'btnSerRepJob
        '
        Me.btnSerRepJob.Icon = CType(resources.GetObject("btnSerRepJob.Icon"), System.Drawing.Icon)
        Me.btnSerRepJob.Key = "ButtonCommand1"
        Me.btnSerRepJob.Name = "btnSerRepJob"
        Me.btnSerRepJob.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerRepJob.Text = "OT"
        '
        'btnSerRepHorasMuertas
        '
        Me.btnSerRepHorasMuertas.Icon = CType(resources.GetObject("btnSerRepHorasMuertas.Icon"), System.Drawing.Icon)
        Me.btnSerRepHorasMuertas.Key = "ButtonCommand1"
        Me.btnSerRepHorasMuertas.Name = "btnSerRepHorasMuertas"
        Me.btnSerRepHorasMuertas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSerRepHorasMuertas.Text = "Horas Muertas"
        '
        'ddcSerRepProyeccion
        '
        Me.ddcSerRepProyeccion.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnSerRepHorasMotores, Me.btnSerRepSeguimientos, Me.btnSerRepMotorDarBaja, Me.btnSerRepDisponibilidad, Me.btnSerRepProyeccionRepImportar, Me.btnSerRepProyeccionVentas, Me.btnSerRepProyeccionReparaciones})
        Me.ddcSerRepProyeccion.Image = CType(resources.GetObject("ddcSerRepProyeccion.Image"), System.Drawing.Image)
        Me.ddcSerRepProyeccion.Key = "DropDownCommand1"
        Me.ddcSerRepProyeccion.Name = "ddcSerRepProyeccion"
        Me.ddcSerRepProyeccion.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.ddcSerRepProyeccion.Text = "Proyección"
        '
        'btnSerRepHorasMotores
        '
        Me.btnSerRepHorasMotores.Image = CType(resources.GetObject("btnSerRepHorasMotores.Image"), System.Drawing.Image)
        Me.btnSerRepHorasMotores.Key = "DropDownCommand1"
        Me.btnSerRepHorasMotores.Name = "btnSerRepHorasMotores"
        Me.btnSerRepHorasMotores.Text = "Horas de Motores"
        '
        'btnSerRepSeguimientos
        '
        Me.btnSerRepSeguimientos.Image = CType(resources.GetObject("btnSerRepSeguimientos.Image"), System.Drawing.Image)
        Me.btnSerRepSeguimientos.Key = "DropDownCommand1"
        Me.btnSerRepSeguimientos.Name = "btnSerRepSeguimientos"
        Me.btnSerRepSeguimientos.Text = "Seguimientos"
        '
        'btnSerRepMotorDarBaja
        '
        Me.btnSerRepMotorDarBaja.Image = CType(resources.GetObject("btnSerRepMotorDarBaja.Image"), System.Drawing.Image)
        Me.btnSerRepMotorDarBaja.Key = "DropDownCommand1"
        Me.btnSerRepMotorDarBaja.Name = "btnSerRepMotorDarBaja"
        Me.btnSerRepMotorDarBaja.Text = "Motores a dar de Baja"
        '
        'btnSerRepDisponibilidad
        '
        Me.btnSerRepDisponibilidad.Image = CType(resources.GetObject("btnSerRepDisponibilidad.Image"), System.Drawing.Image)
        Me.btnSerRepDisponibilidad.Key = "DropDownCommand1"
        Me.btnSerRepDisponibilidad.Name = "btnSerRepDisponibilidad"
        Me.btnSerRepDisponibilidad.Text = "Disponibilidad del Motor"
        '
        'btnSerRepProyeccionRepImportar
        '
        Me.btnSerRepProyeccionRepImportar.Image = CType(resources.GetObject("btnSerRepProyeccionRepImportar.Image"), System.Drawing.Image)
        Me.btnSerRepProyeccionRepImportar.Key = "DropDownCommand1"
        Me.btnSerRepProyeccionRepImportar.Name = "btnSerRepProyeccionRepImportar"
        Me.btnSerRepProyeccionRepImportar.Text = "Repuestos a Importar"
        '
        'btnSerRepProyeccionVentas
        '
        Me.btnSerRepProyeccionVentas.Image = CType(resources.GetObject("btnSerRepProyeccionVentas.Image"), System.Drawing.Image)
        Me.btnSerRepProyeccionVentas.Key = "DropDownCommand2"
        Me.btnSerRepProyeccionVentas.Name = "btnSerRepProyeccionVentas"
        Me.btnSerRepProyeccionVentas.Text = "Ventas por mantenimientos"
        '
        'btnSerRepProyeccionReparaciones
        '
        Me.btnSerRepProyeccionReparaciones.Image = CType(resources.GetObject("btnSerRepProyeccionReparaciones.Image"), System.Drawing.Image)
        Me.btnSerRepProyeccionReparaciones.Key = "DropDownCommand1"
        Me.btnSerRepProyeccionReparaciones.Name = "btnSerRepProyeccionReparaciones"
        Me.btnSerRepProyeccionReparaciones.Text = "Proyección de Reparaciones"
        '
        'rbbTabCompras
        '
        Me.rbbTabCompras.Groups.AddRange(New Janus.Windows.Ribbon.RibbonGroup() {Me.rbbComCompras, Me.rbbComControl, Me.rbbComConsultas, Me.rbbComReportes})
        Me.rbbTabCompras.Key = "RibbonTab2"
        Me.rbbTabCompras.Name = "rbbTabCompras"
        Me.rbbTabCompras.Text = "Compras"
        '
        'rbbComCompras
        '
        Me.rbbComCompras.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnComSolicitud, Me.btnComOrdenCompra, Me.btnComCotizacionSolicitud})
        Me.rbbComCompras.Key = "RibbonGroup4"
        Me.rbbComCompras.Name = "rbbComCompras"
        Me.rbbComCompras.Text = "Compras"
        '
        'btnComSolicitud
        '
        Me.btnComSolicitud.Description = "Solicitud de Compra"
        Me.btnComSolicitud.Icon = CType(resources.GetObject("btnComSolicitud.Icon"), System.Drawing.Icon)
        Me.btnComSolicitud.Key = "ButtonCommand1"
        Me.btnComSolicitud.Name = "btnComSolicitud"
        Me.btnComSolicitud.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnComSolicitud.Text = "Solicitud de Compra"
        '
        'btnComOrdenCompra
        '
        Me.btnComOrdenCompra.Icon = CType(resources.GetObject("btnComOrdenCompra.Icon"), System.Drawing.Icon)
        Me.btnComOrdenCompra.Key = "ButtonCommand1"
        Me.btnComOrdenCompra.Name = "btnComOrdenCompra"
        Me.btnComOrdenCompra.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnComOrdenCompra.Text = "Orden de Compra"
        '
        'btnComCotizacionSolicitud
        '
        Me.btnComCotizacionSolicitud.Icon = CType(resources.GetObject("btnComCotizacionSolicitud.Icon"), System.Drawing.Icon)
        Me.btnComCotizacionSolicitud.Key = "ButtonCommand1"
        Me.btnComCotizacionSolicitud.Name = "btnComCotizacionSolicitud"
        Me.btnComCotizacionSolicitud.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnComCotizacionSolicitud.Text = "Cotizaciones"
        '
        'rbbComControl
        '
        Me.rbbComControl.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnComSolicitudGasto, Me.btnComMesaControl, Me.btnComPlanillaViatico, Me.btnComTarifa, Me.btnComTarifaCasa, Me.btnComTarifaDestino, Me.btnComCuentasPorPagar})
        Me.rbbComControl.Key = "RibbonGroup4"
        Me.rbbComControl.Name = "rbbComControl"
        Me.rbbComControl.Text = "Control"
        '
        'btnComSolicitudGasto
        '
        Me.btnComSolicitudGasto.Icon = CType(resources.GetObject("btnComSolicitudGasto.Icon"), System.Drawing.Icon)
        Me.btnComSolicitudGasto.Key = "ButtonCommand1"
        Me.btnComSolicitudGasto.Name = "btnComSolicitudGasto"
        Me.btnComSolicitudGasto.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnComSolicitudGasto.Text = "Solicitud Gasto"
        '
        'btnComMesaControl
        '
        Me.btnComMesaControl.Image = CType(resources.GetObject("btnComMesaControl.Image"), System.Drawing.Image)
        Me.btnComMesaControl.Key = "ButtonCommand2"
        Me.btnComMesaControl.Name = "btnComMesaControl"
        Me.btnComMesaControl.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnComMesaControl.Text = "Mesa Control"
        '
        'btnComPlanillaViatico
        '
        Me.btnComPlanillaViatico.Icon = CType(resources.GetObject("btnComPlanillaViatico.Icon"), System.Drawing.Icon)
        Me.btnComPlanillaViatico.Key = "ButtonCommand1"
        Me.btnComPlanillaViatico.Name = "btnComPlanillaViatico"
        Me.btnComPlanillaViatico.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnComPlanillaViatico.Text = "Planilla Viatico"
        '
        'btnComTarifa
        '
        Me.btnComTarifa.Icon = CType(resources.GetObject("btnComTarifa.Icon"), System.Drawing.Icon)
        Me.btnComTarifa.Key = "ButtonCommand1"
        Me.btnComTarifa.Name = "btnComTarifa"
        Me.btnComTarifa.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnComTarifa.Text = "Tarifa Gasto Viaje"
        '
        'btnComTarifaCasa
        '
        Me.btnComTarifaCasa.Icon = CType(resources.GetObject("btnComTarifaCasa.Icon"), System.Drawing.Icon)
        Me.btnComTarifaCasa.Key = "ButtonCommand1"
        Me.btnComTarifaCasa.Name = "btnComTarifaCasa"
        Me.btnComTarifaCasa.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnComTarifaCasa.Text = "Tarifa Taxis Casa"
        '
        'btnComTarifaDestino
        '
        Me.btnComTarifaDestino.Image = CType(resources.GetObject("btnComTarifaDestino.Image"), System.Drawing.Image)
        Me.btnComTarifaDestino.Key = "ButtonCommand1"
        Me.btnComTarifaDestino.Name = "btnComTarifaDestino"
        Me.btnComTarifaDestino.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnComTarifaDestino.Text = "Tarifas Taxi Destino"
        '
        'btnComCuentasPorPagar
        '
        Me.btnComCuentasPorPagar.Icon = CType(resources.GetObject("btnComCuentasPorPagar.Icon"), System.Drawing.Icon)
        Me.btnComCuentasPorPagar.Key = "ButtonCommand4"
        Me.btnComCuentasPorPagar.Name = "btnComCuentasPorPagar"
        Me.btnComCuentasPorPagar.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnComCuentasPorPagar.Text = "Cuentas x Pagar"
        '
        'rbbComConsultas
        '
        Me.rbbComConsultas.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnComConsultaCompras})
        Me.rbbComConsultas.Key = "RibbonGroup5"
        Me.rbbComConsultas.Name = "rbbComConsultas"
        Me.rbbComConsultas.Text = "Consultas"
        '
        'btnComConsultaCompras
        '
        Me.btnComConsultaCompras.Icon = CType(resources.GetObject("btnComConsultaCompras.Icon"), System.Drawing.Icon)
        Me.btnComConsultaCompras.Key = "ButtonCommand1"
        Me.btnComConsultaCompras.Name = "btnComConsultaCompras"
        Me.btnComConsultaCompras.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnComConsultaCompras.Text = "Compras y/o Gastos"
        '
        'rbbComReportes
        '
        Me.rbbComReportes.AllowAutoSizeItems = False
        Me.rbbComReportes.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnComRepOrdenes, Me.btnComRepSolicitudGasto, Me.btnComRepMesaControl, Me.btnComRepVencimientosCtasPorPagar, Me.btnComRepCtasPorPagar, Me.btnComRepPagosCuentasPorPagar, Me.btnComRepCtasPorPagarUnidad})
        Me.rbbComReportes.Key = "RibbonGroup6"
        Me.rbbComReportes.Name = "rbbComReportes"
        Me.rbbComReportes.Text = "Reportes"
        '
        'btnComRepOrdenes
        '
        Me.btnComRepOrdenes.Icon = CType(resources.GetObject("btnComRepOrdenes.Icon"), System.Drawing.Icon)
        Me.btnComRepOrdenes.Key = "ButtonCommand1"
        Me.btnComRepOrdenes.Name = "btnComRepOrdenes"
        Me.btnComRepOrdenes.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnComRepOrdenes.Text = "Ordenes Compra"
        '
        'btnComRepSolicitudGasto
        '
        Me.btnComRepSolicitudGasto.Icon = CType(resources.GetObject("btnComRepSolicitudGasto.Icon"), System.Drawing.Icon)
        Me.btnComRepSolicitudGasto.Key = "ButtonCommand1"
        Me.btnComRepSolicitudGasto.Name = "btnComRepSolicitudGasto"
        Me.btnComRepSolicitudGasto.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnComRepSolicitudGasto.Text = "Solicitud Gastos"
        '
        'btnComRepMesaControl
        '
        Me.btnComRepMesaControl.Icon = CType(resources.GetObject("btnComRepMesaControl.Icon"), System.Drawing.Icon)
        Me.btnComRepMesaControl.Key = "ButtonCommand1"
        Me.btnComRepMesaControl.Name = "btnComRepMesaControl"
        Me.btnComRepMesaControl.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnComRepMesaControl.Text = "Mesa Control"
        '
        'btnComRepVencimientosCtasPorPagar
        '
        Me.btnComRepVencimientosCtasPorPagar.Image = CType(resources.GetObject("btnComRepVencimientosCtasPorPagar.Image"), System.Drawing.Image)
        Me.btnComRepVencimientosCtasPorPagar.Key = "ButtonCommand1"
        Me.btnComRepVencimientosCtasPorPagar.Name = "btnComRepVencimientosCtasPorPagar"
        Me.btnComRepVencimientosCtasPorPagar.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnComRepVencimientosCtasPorPagar.Text = "Vencimientos"
        '
        'btnComRepCtasPorPagar
        '
        Me.btnComRepCtasPorPagar.Icon = CType(resources.GetObject("btnComRepCtasPorPagar.Icon"), System.Drawing.Icon)
        Me.btnComRepCtasPorPagar.Key = "ButtonCommand2"
        Me.btnComRepCtasPorPagar.Name = "btnComRepCtasPorPagar"
        Me.btnComRepCtasPorPagar.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnComRepCtasPorPagar.Text = "Cuentas x Pagar"
        '
        'btnComRepPagosCuentasPorPagar
        '
        Me.btnComRepPagosCuentasPorPagar.Icon = CType(resources.GetObject("btnComRepPagosCuentasPorPagar.Icon"), System.Drawing.Icon)
        Me.btnComRepPagosCuentasPorPagar.Key = "ButtonCommand3"
        Me.btnComRepPagosCuentasPorPagar.Name = "btnComRepPagosCuentasPorPagar"
        Me.btnComRepPagosCuentasPorPagar.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnComRepPagosCuentasPorPagar.Text = "Pagos Cuentas x Pagar"
        '
        'btnComRepCtasPorPagarUnidad
        '
        Me.btnComRepCtasPorPagarUnidad.Icon = CType(resources.GetObject("btnComRepCtasPorPagarUnidad.Icon"), System.Drawing.Icon)
        Me.btnComRepCtasPorPagarUnidad.Key = "ButtonCommand1"
        Me.btnComRepCtasPorPagarUnidad.Name = "btnComRepCtasPorPagarUnidad"
        Me.btnComRepCtasPorPagarUnidad.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnComRepCtasPorPagarUnidad.Text = "Cuentas x Pagar Por Unidad"
        '
        'rbbTabPersonal
        '
        Me.rbbTabPersonal.Groups.AddRange(New Janus.Windows.Ribbon.RibbonGroup() {Me.rbbPerInformacion, Me.rbbPerPlanilla, Me.rbbPerAsignaciones, Me.rbbPerComunicaciones, Me.rbbPerReportes})
        Me.rbbTabPersonal.Key = "RibbonTab3"
        Me.rbbTabPersonal.Name = "rbbTabPersonal"
        Me.rbbTabPersonal.Text = "Personal"
        '
        'rbbPerInformacion
        '
        Me.rbbPerInformacion.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnPerInfDatos, Me.btnPerInfVacaciones, Me.btnPerInfContratos, Me.btnPerInfCapacitacion, Me.btnPerInfEvaluacion})
        Me.rbbPerInformacion.Key = "RibbonGroup4"
        Me.rbbPerInformacion.Name = "rbbPerInformacion"
        Me.rbbPerInformacion.Text = "Informacion"
        '
        'btnPerInfDatos
        '
        Me.btnPerInfDatos.Icon = CType(resources.GetObject("btnPerInfDatos.Icon"), System.Drawing.Icon)
        Me.btnPerInfDatos.Key = "ButtonCommand1"
        Me.btnPerInfDatos.Name = "btnPerInfDatos"
        Me.btnPerInfDatos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerInfDatos.Text = "Ficha General"
        '
        'btnPerInfVacaciones
        '
        Me.btnPerInfVacaciones.Image = CType(resources.GetObject("btnPerInfVacaciones.Image"), System.Drawing.Image)
        Me.btnPerInfVacaciones.Key = "ButtonCommand1"
        Me.btnPerInfVacaciones.Name = "btnPerInfVacaciones"
        Me.btnPerInfVacaciones.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerInfVacaciones.Text = "Vacaciones"
        '
        'btnPerInfContratos
        '
        Me.btnPerInfContratos.Icon = CType(resources.GetObject("btnPerInfContratos.Icon"), System.Drawing.Icon)
        Me.btnPerInfContratos.Key = "ButtonCommand1"
        Me.btnPerInfContratos.Name = "btnPerInfContratos"
        Me.btnPerInfContratos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerInfContratos.Text = "Contratos"
        '
        'btnPerInfCapacitacion
        '
        Me.btnPerInfCapacitacion.Icon = CType(resources.GetObject("btnPerInfCapacitacion.Icon"), System.Drawing.Icon)
        Me.btnPerInfCapacitacion.Key = "ButtonCommand1"
        Me.btnPerInfCapacitacion.Name = "btnPerInfCapacitacion"
        Me.btnPerInfCapacitacion.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerInfCapacitacion.Text = "Capacitaciones"
        '
        'btnPerInfEvaluacion
        '
        Me.btnPerInfEvaluacion.Icon = CType(resources.GetObject("btnPerInfEvaluacion.Icon"), System.Drawing.Icon)
        Me.btnPerInfEvaluacion.Key = "ButtonCommand1"
        Me.btnPerInfEvaluacion.Name = "btnPerInfEvaluacion"
        Me.btnPerInfEvaluacion.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerInfEvaluacion.Text = "Evaluaciones"
        '
        'rbbPerPlanilla
        '
        Me.rbbPerPlanilla.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnPerPlanilla, Me.btnPerQuintaCategoria})
        Me.rbbPerPlanilla.Key = "Planilla"
        Me.rbbPerPlanilla.Name = "rbbPerPlanilla"
        Me.rbbPerPlanilla.Text = "Planilla Sueldos"
        '
        'btnPerPlanilla
        '
        Me.btnPerPlanilla.Icon = CType(resources.GetObject("btnPerPlanilla.Icon"), System.Drawing.Icon)
        Me.btnPerPlanilla.Key = "ButtonCommand1"
        Me.btnPerPlanilla.Name = "btnPerPlanilla"
        Me.btnPerPlanilla.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerPlanilla.Text = "Generar"
        '
        'btnPerQuintaCategoria
        '
        Me.btnPerQuintaCategoria.Image = CType(resources.GetObject("btnPerQuintaCategoria.Image"), System.Drawing.Image)
        Me.btnPerQuintaCategoria.Key = "ButtonCommand1"
        Me.btnPerQuintaCategoria.Name = "btnPerQuintaCategoria"
        Me.btnPerQuintaCategoria.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerQuintaCategoria.Text = "Quinta Categoria"
        '
        'rbbPerAsignaciones
        '
        Me.rbbPerAsignaciones.AllowAutoSizeItems = False
        Me.rbbPerAsignaciones.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnPerAsigFaltas, Me.btnPerAsigMarcas, Me.btnPerAsigHoraExtra, Me.btnPerAsigHorario, Me.btnPerRegistroHoraExtra, Me.btnPerAsigIngresos, Me.btnPerAsigDescuentos, Me.btnPerAsigJefes, Me.btnPerAsigRecursos, Me.btnPerAsigCronogramaMina, Me.btnPerMarcaccionOnline})
        Me.rbbPerAsignaciones.Key = "RibbonGroup4"
        Me.rbbPerAsignaciones.Name = "rbbPerAsignaciones"
        Me.rbbPerAsignaciones.Text = "Asignaciones"
        '
        'btnPerAsigFaltas
        '
        Me.btnPerAsigFaltas.Icon = CType(resources.GetObject("btnPerAsigFaltas.Icon"), System.Drawing.Icon)
        Me.btnPerAsigFaltas.Key = "ButtonCommand1"
        Me.btnPerAsigFaltas.Name = "btnPerAsigFaltas"
        Me.btnPerAsigFaltas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerAsigFaltas.Text = "Faltas"
        '
        'btnPerAsigMarcas
        '
        Me.btnPerAsigMarcas.Image = CType(resources.GetObject("btnPerAsigMarcas.Image"), System.Drawing.Image)
        Me.btnPerAsigMarcas.Key = "ButtonCommand1"
        Me.btnPerAsigMarcas.Name = "btnPerAsigMarcas"
        Me.btnPerAsigMarcas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerAsigMarcas.Text = "Marcacion"
        '
        'btnPerAsigHoraExtra
        '
        Me.btnPerAsigHoraExtra.Image = CType(resources.GetObject("btnPerAsigHoraExtra.Image"), System.Drawing.Image)
        Me.btnPerAsigHoraExtra.Key = "ButtonCommand2"
        Me.btnPerAsigHoraExtra.Name = "btnPerAsigHoraExtra"
        Me.btnPerAsigHoraExtra.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerAsigHoraExtra.Text = "Asigna H. Extra"
        '
        'btnPerAsigHorario
        '
        Me.btnPerAsigHorario.Image = CType(resources.GetObject("btnPerAsigHorario.Image"), System.Drawing.Image)
        Me.btnPerAsigHorario.Key = "ButtonCommand3"
        Me.btnPerAsigHorario.Name = "btnPerAsigHorario"
        Me.btnPerAsigHorario.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerAsigHorario.Text = "Horarios"
        '
        'btnPerRegistroHoraExtra
        '
        Me.btnPerRegistroHoraExtra.Image = CType(resources.GetObject("btnPerRegistroHoraExtra.Image"), System.Drawing.Image)
        Me.btnPerRegistroHoraExtra.Key = "ButtonCommand1"
        Me.btnPerRegistroHoraExtra.Name = "btnPerRegistroHoraExtra"
        Me.btnPerRegistroHoraExtra.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerRegistroHoraExtra.Text = "Horas Extras"
        '
        'btnPerAsigIngresos
        '
        Me.btnPerAsigIngresos.Image = CType(resources.GetObject("btnPerAsigIngresos.Image"), System.Drawing.Image)
        Me.btnPerAsigIngresos.Key = "ButtonCommand1"
        Me.btnPerAsigIngresos.Name = "btnPerAsigIngresos"
        Me.btnPerAsigIngresos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerAsigIngresos.Text = "Ingresos"
        '
        'btnPerAsigDescuentos
        '
        Me.btnPerAsigDescuentos.Image = CType(resources.GetObject("btnPerAsigDescuentos.Image"), System.Drawing.Image)
        Me.btnPerAsigDescuentos.Key = "ButtonCommand1"
        Me.btnPerAsigDescuentos.Name = "btnPerAsigDescuentos"
        Me.btnPerAsigDescuentos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerAsigDescuentos.Text = "Descuentos"
        '
        'btnPerAsigJefes
        '
        Me.btnPerAsigJefes.Image = CType(resources.GetObject("btnPerAsigJefes.Image"), System.Drawing.Image)
        Me.btnPerAsigJefes.Key = "ButtonCommand1"
        Me.btnPerAsigJefes.Name = "btnPerAsigJefes"
        Me.btnPerAsigJefes.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerAsigJefes.Text = "Jefe Area"
        '
        'btnPerAsigRecursos
        '
        Me.btnPerAsigRecursos.Image = CType(resources.GetObject("btnPerAsigRecursos.Image"), System.Drawing.Image)
        Me.btnPerAsigRecursos.Key = "ButtonCommand1"
        Me.btnPerAsigRecursos.Name = "btnPerAsigRecursos"
        Me.btnPerAsigRecursos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerAsigRecursos.Text = "Recursos"
        '
        'btnPerAsigCronogramaMina
        '
        Me.btnPerAsigCronogramaMina.Icon = CType(resources.GetObject("btnPerAsigCronogramaMina.Icon"), System.Drawing.Icon)
        Me.btnPerAsigCronogramaMina.Key = "ButtonCommand1"
        Me.btnPerAsigCronogramaMina.Name = "btnPerAsigCronogramaMina"
        Me.btnPerAsigCronogramaMina.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerAsigCronogramaMina.Text = "Cronograma Mina"
        '
        'btnPerMarcaccionOnline
        '
        Me.btnPerMarcaccionOnline.Image = CType(resources.GetObject("btnPerMarcaccionOnline.Image"), System.Drawing.Image)
        Me.btnPerMarcaccionOnline.Key = "ButtonCommand1"
        Me.btnPerMarcaccionOnline.Name = "btnPerMarcaccionOnline"
        Me.btnPerMarcaccionOnline.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerMarcaccionOnline.Text = "Marcación Online"
        '
        'rbbPerComunicaciones
        '
        Me.rbbPerComunicaciones.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnPerComAdminLector, Me.btnPerComProcesarMarcas})
        Me.rbbPerComunicaciones.Key = "RibbonGroup4"
        Me.rbbPerComunicaciones.Name = "rbbPerComunicaciones"
        Me.rbbPerComunicaciones.Text = "Comunicaciones"
        '
        'btnPerComAdminLector
        '
        Me.btnPerComAdminLector.Image = CType(resources.GetObject("btnPerComAdminLector.Image"), System.Drawing.Image)
        Me.btnPerComAdminLector.Key = "ButtonCommand1"
        Me.btnPerComAdminLector.Name = "btnPerComAdminLector"
        Me.btnPerComAdminLector.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerComAdminLector.Text = "Admin. Lector"
        '
        'btnPerComProcesarMarcas
        '
        Me.btnPerComProcesarMarcas.Image = CType(resources.GetObject("btnPerComProcesarMarcas.Image"), System.Drawing.Image)
        Me.btnPerComProcesarMarcas.Key = "ButtonCommand1"
        Me.btnPerComProcesarMarcas.Name = "btnPerComProcesarMarcas"
        Me.btnPerComProcesarMarcas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerComProcesarMarcas.Text = "Procesar Marcas"
        '
        'rbbPerReportes
        '
        Me.rbbPerReportes.AllowAutoSizeItems = False
        Me.rbbPerReportes.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnPerRepPlanillaSueldos, Me.btnPerRepAsistencia, Me.btnPerRepAsignacionHoraExtra, Me.btnPerRepHoraExtra, Me.btnPerRepTardanzas, Me.btnPerRepFaltas, Me.btnPerRepIngresos, Me.btnPerRepDescuentos, Me.btnPerRepRecursos, Me.btnPerRepVacaciones, Me.btnPerRepPersonal, Me.btnPerRepCapacitacion, Me.btnPerRepContratos, Me.btnPerRepOnomasticos, Me.btnPerRepCronogramaMina, Me.btnPerRepAsigHorario})
        Me.rbbPerReportes.Key = "RibbonGroup4"
        Me.rbbPerReportes.Name = "rbbPerReportes"
        Me.rbbPerReportes.Text = "Reportes"
        '
        'btnPerRepPlanillaSueldos
        '
        Me.btnPerRepPlanillaSueldos.Icon = CType(resources.GetObject("btnPerRepPlanillaSueldos.Icon"), System.Drawing.Icon)
        Me.btnPerRepPlanillaSueldos.Key = "ButtonCommand1"
        Me.btnPerRepPlanillaSueldos.Name = "btnPerRepPlanillaSueldos"
        Me.btnPerRepPlanillaSueldos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerRepPlanillaSueldos.Text = "Planilla Sueldos"
        '
        'btnPerRepAsistencia
        '
        Me.btnPerRepAsistencia.Icon = CType(resources.GetObject("btnPerRepAsistencia.Icon"), System.Drawing.Icon)
        Me.btnPerRepAsistencia.Key = "ButtonCommand1"
        Me.btnPerRepAsistencia.Name = "btnPerRepAsistencia"
        Me.btnPerRepAsistencia.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerRepAsistencia.Text = "Asistencia"
        '
        'btnPerRepAsignacionHoraExtra
        '
        Me.btnPerRepAsignacionHoraExtra.Image = CType(resources.GetObject("btnPerRepAsignacionHoraExtra.Image"), System.Drawing.Image)
        Me.btnPerRepAsignacionHoraExtra.Key = "ButtonCommand1"
        Me.btnPerRepAsignacionHoraExtra.Name = "btnPerRepAsignacionHoraExtra"
        Me.btnPerRepAsignacionHoraExtra.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerRepAsignacionHoraExtra.Text = "Asig. H. Extra"
        '
        'btnPerRepHoraExtra
        '
        Me.btnPerRepHoraExtra.Icon = CType(resources.GetObject("btnPerRepHoraExtra.Icon"), System.Drawing.Icon)
        Me.btnPerRepHoraExtra.Key = "ButtonCommand1"
        Me.btnPerRepHoraExtra.Name = "btnPerRepHoraExtra"
        Me.btnPerRepHoraExtra.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerRepHoraExtra.Text = "Horas Extras"
        '
        'btnPerRepTardanzas
        '
        Me.btnPerRepTardanzas.Icon = CType(resources.GetObject("btnPerRepTardanzas.Icon"), System.Drawing.Icon)
        Me.btnPerRepTardanzas.Key = "ButtonCommand1"
        Me.btnPerRepTardanzas.Name = "btnPerRepTardanzas"
        Me.btnPerRepTardanzas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerRepTardanzas.Text = "Tardanzas"
        '
        'btnPerRepFaltas
        '
        Me.btnPerRepFaltas.Icon = CType(resources.GetObject("btnPerRepFaltas.Icon"), System.Drawing.Icon)
        Me.btnPerRepFaltas.Key = "ButtonCommand1"
        Me.btnPerRepFaltas.Name = "btnPerRepFaltas"
        Me.btnPerRepFaltas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerRepFaltas.Text = "Faltas"
        '
        'btnPerRepIngresos
        '
        Me.btnPerRepIngresos.Icon = CType(resources.GetObject("btnPerRepIngresos.Icon"), System.Drawing.Icon)
        Me.btnPerRepIngresos.Key = "ButtonCommand1"
        Me.btnPerRepIngresos.Name = "btnPerRepIngresos"
        Me.btnPerRepIngresos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerRepIngresos.Text = "Ingresos"
        '
        'btnPerRepDescuentos
        '
        Me.btnPerRepDescuentos.Icon = CType(resources.GetObject("btnPerRepDescuentos.Icon"), System.Drawing.Icon)
        Me.btnPerRepDescuentos.Key = "ButtonCommand1"
        Me.btnPerRepDescuentos.Name = "btnPerRepDescuentos"
        Me.btnPerRepDescuentos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerRepDescuentos.Text = "Descuentos"
        '
        'btnPerRepRecursos
        '
        Me.btnPerRepRecursos.Icon = CType(resources.GetObject("btnPerRepRecursos.Icon"), System.Drawing.Icon)
        Me.btnPerRepRecursos.Key = "ButtonCommand1"
        Me.btnPerRepRecursos.Name = "btnPerRepRecursos"
        Me.btnPerRepRecursos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerRepRecursos.Text = "Recursos"
        '
        'btnPerRepVacaciones
        '
        Me.btnPerRepVacaciones.Icon = CType(resources.GetObject("btnPerRepVacaciones.Icon"), System.Drawing.Icon)
        Me.btnPerRepVacaciones.Key = "ButtonCommand1"
        Me.btnPerRepVacaciones.Name = "btnPerRepVacaciones"
        Me.btnPerRepVacaciones.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerRepVacaciones.Text = "Vacaciones"
        '
        'btnPerRepPersonal
        '
        Me.btnPerRepPersonal.Icon = CType(resources.GetObject("btnPerRepPersonal.Icon"), System.Drawing.Icon)
        Me.btnPerRepPersonal.Key = "ButtonCommand1"
        Me.btnPerRepPersonal.Name = "btnPerRepPersonal"
        Me.btnPerRepPersonal.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerRepPersonal.Text = "Personal"
        '
        'btnPerRepCapacitacion
        '
        Me.btnPerRepCapacitacion.Image = CType(resources.GetObject("btnPerRepCapacitacion.Image"), System.Drawing.Image)
        Me.btnPerRepCapacitacion.Key = "ButtonCommand1"
        Me.btnPerRepCapacitacion.Name = "btnPerRepCapacitacion"
        Me.btnPerRepCapacitacion.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerRepCapacitacion.Text = "Capacitaciones"
        '
        'btnPerRepContratos
        '
        Me.btnPerRepContratos.Icon = CType(resources.GetObject("btnPerRepContratos.Icon"), System.Drawing.Icon)
        Me.btnPerRepContratos.Key = "ButtonCommand1"
        Me.btnPerRepContratos.Name = "btnPerRepContratos"
        Me.btnPerRepContratos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerRepContratos.Text = "Contratos"
        '
        'btnPerRepOnomasticos
        '
        Me.btnPerRepOnomasticos.Image = CType(resources.GetObject("btnPerRepOnomasticos.Image"), System.Drawing.Image)
        Me.btnPerRepOnomasticos.Key = "ButtonCommand1"
        Me.btnPerRepOnomasticos.Name = "btnPerRepOnomasticos"
        Me.btnPerRepOnomasticos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerRepOnomasticos.Text = "Onomasticos"
        '
        'btnPerRepCronogramaMina
        '
        Me.btnPerRepCronogramaMina.Icon = CType(resources.GetObject("btnPerRepCronogramaMina.Icon"), System.Drawing.Icon)
        Me.btnPerRepCronogramaMina.Key = "ButtonCommand1"
        Me.btnPerRepCronogramaMina.Name = "btnPerRepCronogramaMina"
        Me.btnPerRepCronogramaMina.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerRepCronogramaMina.Text = "Cronograma Mina"
        '
        'btnPerRepAsigHorario
        '
        Me.btnPerRepAsigHorario.Icon = CType(resources.GetObject("btnPerRepAsigHorario.Icon"), System.Drawing.Icon)
        Me.btnPerRepAsigHorario.Key = "ButtonCommand1"
        Me.btnPerRepAsigHorario.Name = "btnPerRepAsigHorario"
        Me.btnPerRepAsigHorario.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerRepAsigHorario.Text = "Asignación Horario"
        '
        'rbbTabRondas
        '
        Me.rbbTabRondas.Groups.AddRange(New Janus.Windows.Ribbon.RibbonGroup() {Me.rbbRondasAsignacion, Me.rbbRondasReporte})
        Me.rbbTabRondas.Key = "RibbonTab2"
        Me.rbbTabRondas.Name = "rbbTabRondas"
        Me.rbbTabRondas.Text = "Rondas"
        '
        'rbbRondasAsignacion
        '
        Me.rbbRondasAsignacion.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnPuntosControlRutas, Me.btnRuteadorRutas, Me.btnRondas})
        Me.rbbRondasAsignacion.Key = "RibbonGroup4"
        Me.rbbRondasAsignacion.Name = "rbbRondasAsignacion"
        Me.rbbRondasAsignacion.Text = "Asignacion"
        '
        'btnPuntosControlRutas
        '
        Me.btnPuntosControlRutas.Image = CType(resources.GetObject("btnPuntosControlRutas.Image"), System.Drawing.Image)
        Me.btnPuntosControlRutas.Key = "ButtonCommand1"
        Me.btnPuntosControlRutas.Name = "btnPuntosControlRutas"
        Me.btnPuntosControlRutas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPuntosControlRutas.Text = "Puntos Control Rutas"
        '
        'btnRuteadorRutas
        '
        Me.btnRuteadorRutas.Image = CType(resources.GetObject("btnRuteadorRutas.Image"), System.Drawing.Image)
        Me.btnRuteadorRutas.Key = "ButtonCommand1"
        Me.btnRuteadorRutas.Name = "btnRuteadorRutas"
        Me.btnRuteadorRutas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnRuteadorRutas.Text = "Ruteador Rutas"
        '
        'btnRondas
        '
        Me.btnRondas.Image = CType(resources.GetObject("btnRondas.Image"), System.Drawing.Image)
        Me.btnRondas.Key = "ButtonCommand1"
        Me.btnRondas.Name = "btnRondas"
        Me.btnRondas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnRondas.Text = "Rondas"
        '
        'rbbRondasReporte
        '
        Me.rbbRondasReporte.Key = "RibbonGroup4"
        Me.rbbRondasReporte.Name = "rbbRondasReporte"
        Me.rbbRondasReporte.Text = "Reportes"
        '
        'rbbTabContabilidad
        '
        Me.rbbTabContabilidad.Groups.AddRange(New Janus.Windows.Ribbon.RibbonGroup() {Me.rbbContaTesoreria, Me.rbbContaCompras, Me.rbbContaContabilidad, Me.rbbContaCajaChica, Me.rbbContaProcesos, Me.rbbContaReportes})
        Me.rbbTabContabilidad.Key = "RibbonTab2"
        Me.rbbTabContabilidad.Name = "rbbTabContabilidad"
        Me.rbbTabContabilidad.Text = "Contabilidad"
        '
        'rbbContaTesoreria
        '
        Me.rbbContaTesoreria.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnConTesoreria, Me.btnConMovimientoBanco})
        Me.rbbContaTesoreria.Key = "RibbonGroup4"
        Me.rbbContaTesoreria.Name = "rbbContaTesoreria"
        Me.rbbContaTesoreria.Text = "Tesoreria"
        '
        'btnConTesoreria
        '
        Me.btnConTesoreria.Icon = CType(resources.GetObject("btnConTesoreria.Icon"), System.Drawing.Icon)
        Me.btnConTesoreria.Key = "ButtonCommand1"
        Me.btnConTesoreria.Name = "btnConTesoreria"
        Me.btnConTesoreria.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnConTesoreria.Text = "Asientos"
        '
        'btnConMovimientoBanco
        '
        Me.btnConMovimientoBanco.Image = CType(resources.GetObject("btnConMovimientoBanco.Image"), System.Drawing.Image)
        Me.btnConMovimientoBanco.Key = "ButtonCommand1"
        Me.btnConMovimientoBanco.Name = "btnConMovimientoBanco"
        Me.btnConMovimientoBanco.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnConMovimientoBanco.Text = "Movimiento Bancos"
        '
        'rbbContaCompras
        '
        Me.rbbContaCompras.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnConRegistroCompra, Me.btnConReciboHonorario})
        Me.rbbContaCompras.Key = "RibbonGroup4"
        Me.rbbContaCompras.Name = "rbbContaCompras"
        Me.rbbContaCompras.Text = "Compras"
        '
        'btnConRegistroCompra
        '
        Me.btnConRegistroCompra.Icon = CType(resources.GetObject("btnConRegistroCompra.Icon"), System.Drawing.Icon)
        Me.btnConRegistroCompra.Key = "ButtonCommand1"
        Me.btnConRegistroCompra.Name = "btnConRegistroCompra"
        Me.btnConRegistroCompra.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnConRegistroCompra.Text = "Registro Compra"
        '
        'btnConReciboHonorario
        '
        Me.btnConReciboHonorario.Icon = CType(resources.GetObject("btnConReciboHonorario.Icon"), System.Drawing.Icon)
        Me.btnConReciboHonorario.Key = "ButtonCommand1"
        Me.btnConReciboHonorario.Name = "btnConReciboHonorario"
        Me.btnConReciboHonorario.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnConReciboHonorario.Text = "Recibo Honorario"
        '
        'rbbContaContabilidad
        '
        Me.rbbContaContabilidad.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnConDiario})
        Me.rbbContaContabilidad.Key = "RibbonGroup7"
        Me.rbbContaContabilidad.Name = "rbbContaContabilidad"
        Me.rbbContaContabilidad.Text = "Contabilidad"
        '
        'btnConDiario
        '
        Me.btnConDiario.Icon = CType(resources.GetObject("btnConDiario.Icon"), System.Drawing.Icon)
        Me.btnConDiario.Key = "ButtonCommand1"
        Me.btnConDiario.Name = "btnConDiario"
        Me.btnConDiario.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnConDiario.Text = "Diario"
        '
        'rbbContaCajaChica
        '
        Me.rbbContaCajaChica.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnConProvisional, Me.btnConReembolso, Me.btnConArqueoCaja})
        Me.rbbContaCajaChica.Key = "RibbonGroup4"
        Me.rbbContaCajaChica.Name = "rbbContaCajaChica"
        Me.rbbContaCajaChica.Text = "Caja Chica"
        '
        'btnConProvisional
        '
        Me.btnConProvisional.Icon = CType(resources.GetObject("btnConProvisional.Icon"), System.Drawing.Icon)
        Me.btnConProvisional.Key = "ButtonCommand1"
        Me.btnConProvisional.Name = "btnConProvisional"
        Me.btnConProvisional.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnConProvisional.Text = "Provisional"
        '
        'btnConReembolso
        '
        Me.btnConReembolso.Icon = CType(resources.GetObject("btnConReembolso.Icon"), System.Drawing.Icon)
        Me.btnConReembolso.Key = "ButtonCommand2"
        Me.btnConReembolso.Name = "btnConReembolso"
        Me.btnConReembolso.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnConReembolso.Text = "Reembolso"
        '
        'btnConArqueoCaja
        '
        Me.btnConArqueoCaja.Icon = CType(resources.GetObject("btnConArqueoCaja.Icon"), System.Drawing.Icon)
        Me.btnConArqueoCaja.Key = "ButtonCommand1"
        Me.btnConArqueoCaja.Name = "btnConArqueoCaja"
        Me.btnConArqueoCaja.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnConArqueoCaja.Text = "Arqueo Caja"
        '
        'rbbContaProcesos
        '
        Me.rbbContaProcesos.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnConProCuentaDestino, Me.btnConProCierreMes, Me.btnConProDifTipoCambio, Me.btnConGenerarTXTLibros, Me.btnConProFlujoCaja})
        Me.rbbContaProcesos.Key = "RibbonGroup6"
        Me.rbbContaProcesos.Name = "rbbContaProcesos"
        Me.rbbContaProcesos.Text = "Procesos"
        '
        'btnConProCuentaDestino
        '
        Me.btnConProCuentaDestino.Icon = CType(resources.GetObject("btnConProCuentaDestino.Icon"), System.Drawing.Icon)
        Me.btnConProCuentaDestino.Key = "ButtonCommand2"
        Me.btnConProCuentaDestino.Name = "btnConProCuentaDestino"
        Me.btnConProCuentaDestino.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnConProCuentaDestino.Text = "Cuenta Destino"
        '
        'btnConProCierreMes
        '
        Me.btnConProCierreMes.Icon = CType(resources.GetObject("btnConProCierreMes.Icon"), System.Drawing.Icon)
        Me.btnConProCierreMes.Key = "ButtonCommand1"
        Me.btnConProCierreMes.Name = "btnConProCierreMes"
        Me.btnConProCierreMes.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnConProCierreMes.Text = "Cierre Mes"
        '
        'btnConProDifTipoCambio
        '
        Me.btnConProDifTipoCambio.Icon = CType(resources.GetObject("btnConProDifTipoCambio.Icon"), System.Drawing.Icon)
        Me.btnConProDifTipoCambio.Key = "ButtonCommand1"
        Me.btnConProDifTipoCambio.Name = "btnConProDifTipoCambio"
        Me.btnConProDifTipoCambio.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnConProDifTipoCambio.Text = "Dif. Tipo Cambio"
        '
        'btnConGenerarTXTLibros
        '
        Me.btnConGenerarTXTLibros.Icon = CType(resources.GetObject("btnConGenerarTXTLibros.Icon"), System.Drawing.Icon)
        Me.btnConGenerarTXTLibros.Key = "ButtonCommand1"
        Me.btnConGenerarTXTLibros.Name = "btnConGenerarTXTLibros"
        Me.btnConGenerarTXTLibros.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnConGenerarTXTLibros.Text = "Generar TXT Libros"
        '
        'btnConProFlujoCaja
        '
        Me.btnConProFlujoCaja.Image = CType(resources.GetObject("btnConProFlujoCaja.Image"), System.Drawing.Image)
        Me.btnConProFlujoCaja.Key = "ButtonCommand1"
        Me.btnConProFlujoCaja.Name = "btnConProFlujoCaja"
        Me.btnConProFlujoCaja.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnConProFlujoCaja.Text = "Flujo de Caja"
        '
        'rbbContaReportes
        '
        Me.rbbContaReportes.AllowAutoSizeItems = False
        Me.rbbContaReportes.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnConRepCtasPorPagar, Me.btnConRepVencimientos, Me.btnConRepReembolso, Me.ddcConRepLibrosOficiales, Me.btnConRepCtasCtes, Me.btnConRepCtasCtesPend, Me.btnConRepMayorAuxiliar, Me.btnConRepEstadosFinancieros, Me.btnConRepChequesGirados, Me.btnConRepProvisionales})
        Me.rbbContaReportes.Key = "RibbonGroup4"
        Me.rbbContaReportes.Name = "rbbContaReportes"
        Me.rbbContaReportes.Text = "Reportes"
        '
        'btnConRepCtasPorPagar
        '
        Me.btnConRepCtasPorPagar.Icon = CType(resources.GetObject("btnConRepCtasPorPagar.Icon"), System.Drawing.Icon)
        Me.btnConRepCtasPorPagar.Key = "ButtonCommand1"
        Me.btnConRepCtasPorPagar.Name = "btnConRepCtasPorPagar"
        Me.btnConRepCtasPorPagar.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnConRepCtasPorPagar.Text = "Ctas x Pagar"
        '
        'btnConRepVencimientos
        '
        Me.btnConRepVencimientos.Icon = CType(resources.GetObject("btnConRepVencimientos.Icon"), System.Drawing.Icon)
        Me.btnConRepVencimientos.Key = "ButtonCommand2"
        Me.btnConRepVencimientos.Name = "btnConRepVencimientos"
        Me.btnConRepVencimientos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnConRepVencimientos.Text = "Vencimientos"
        '
        'btnConRepReembolso
        '
        Me.btnConRepReembolso.Icon = CType(resources.GetObject("btnConRepReembolso.Icon"), System.Drawing.Icon)
        Me.btnConRepReembolso.Key = "ButtonCommand1"
        Me.btnConRepReembolso.Name = "btnConRepReembolso"
        Me.btnConRepReembolso.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnConRepReembolso.Text = "Reembolsos"
        '
        'ddcConRepLibrosOficiales
        '
        Me.ddcConRepLibrosOficiales.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnConRepLibroDiario, Me.btnConRepLibroMayor, Me.btnConRepCajaBancos, Me.btnConRepRegistroCompra})
        Me.ddcConRepLibrosOficiales.Image = CType(resources.GetObject("ddcConRepLibrosOficiales.Image"), System.Drawing.Image)
        Me.ddcConRepLibrosOficiales.Key = "DropDownCommand1"
        Me.ddcConRepLibrosOficiales.Name = "ddcConRepLibrosOficiales"
        Me.ddcConRepLibrosOficiales.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.ddcConRepLibrosOficiales.Text = "Libros Oficiales"
        '
        'btnConRepLibroDiario
        '
        Me.btnConRepLibroDiario.Icon = CType(resources.GetObject("btnConRepLibroDiario.Icon"), System.Drawing.Icon)
        Me.btnConRepLibroDiario.Key = "ButtonCommand1"
        Me.btnConRepLibroDiario.Name = "btnConRepLibroDiario"
        Me.btnConRepLibroDiario.Text = "Libro Diario"
        '
        'btnConRepLibroMayor
        '
        Me.btnConRepLibroMayor.Icon = CType(resources.GetObject("btnConRepLibroMayor.Icon"), System.Drawing.Icon)
        Me.btnConRepLibroMayor.Key = "DropDownCommand2"
        Me.btnConRepLibroMayor.Name = "btnConRepLibroMayor"
        Me.btnConRepLibroMayor.Text = "Libro Mayor"
        '
        'btnConRepCajaBancos
        '
        Me.btnConRepCajaBancos.Icon = CType(resources.GetObject("btnConRepCajaBancos.Icon"), System.Drawing.Icon)
        Me.btnConRepCajaBancos.Key = "DropDownCommand4"
        Me.btnConRepCajaBancos.Name = "btnConRepCajaBancos"
        Me.btnConRepCajaBancos.Text = "Caja y Bancos"
        '
        'btnConRepRegistroCompra
        '
        Me.btnConRepRegistroCompra.Image = CType(resources.GetObject("btnConRepRegistroCompra.Image"), System.Drawing.Image)
        Me.btnConRepRegistroCompra.Key = "DropDownCommand5"
        Me.btnConRepRegistroCompra.Name = "btnConRepRegistroCompra"
        Me.btnConRepRegistroCompra.Text = "Registro de Compras"
        '
        'btnConRepCtasCtes
        '
        Me.btnConRepCtasCtes.Image = CType(resources.GetObject("btnConRepCtasCtes.Image"), System.Drawing.Image)
        Me.btnConRepCtasCtes.Key = "ButtonCommand1"
        Me.btnConRepCtasCtes.Name = "btnConRepCtasCtes"
        Me.btnConRepCtasCtes.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnConRepCtasCtes.Text = "Ctas Ctes"
        '
        'btnConRepCtasCtesPend
        '
        Me.btnConRepCtasCtesPend.Image = CType(resources.GetObject("btnConRepCtasCtesPend.Image"), System.Drawing.Image)
        Me.btnConRepCtasCtesPend.Key = "ButtonCommand1"
        Me.btnConRepCtasCtesPend.Name = "btnConRepCtasCtesPend"
        Me.btnConRepCtasCtesPend.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnConRepCtasCtesPend.Text = "Ctas Ctes Pendiente"
        '
        'btnConRepMayorAuxiliar
        '
        Me.btnConRepMayorAuxiliar.Icon = CType(resources.GetObject("btnConRepMayorAuxiliar.Icon"), System.Drawing.Icon)
        Me.btnConRepMayorAuxiliar.Key = "ButtonCommand1"
        Me.btnConRepMayorAuxiliar.Name = "btnConRepMayorAuxiliar"
        Me.btnConRepMayorAuxiliar.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnConRepMayorAuxiliar.Text = "Mayor Auxiliar"
        '
        'btnConRepEstadosFinancieros
        '
        Me.btnConRepEstadosFinancieros.Icon = CType(resources.GetObject("btnConRepEstadosFinancieros.Icon"), System.Drawing.Icon)
        Me.btnConRepEstadosFinancieros.Key = "ButtonCommand1"
        Me.btnConRepEstadosFinancieros.Name = "btnConRepEstadosFinancieros"
        Me.btnConRepEstadosFinancieros.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnConRepEstadosFinancieros.Text = "Estado Financiero"
        '
        'btnConRepChequesGirados
        '
        Me.btnConRepChequesGirados.Image = CType(resources.GetObject("btnConRepChequesGirados.Image"), System.Drawing.Image)
        Me.btnConRepChequesGirados.Key = "ButtonCommand1"
        Me.btnConRepChequesGirados.Name = "btnConRepChequesGirados"
        Me.btnConRepChequesGirados.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnConRepChequesGirados.Text = "Cheques Girados"
        '
        'btnConRepProvisionales
        '
        Me.btnConRepProvisionales.Image = CType(resources.GetObject("btnConRepProvisionales.Image"), System.Drawing.Image)
        Me.btnConRepProvisionales.Key = "ButtonCommand1"
        Me.btnConRepProvisionales.Name = "btnConRepProvisionales"
        Me.btnConRepProvisionales.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnConRepProvisionales.Text = "Provisionales"
        '
        'rbbTabTelefonia
        '
        Me.rbbTabTelefonia.Groups.AddRange(New Janus.Windows.Ribbon.RibbonGroup() {Me.rbbTelefoniaMante, Me.rbbTelefoniaAsigna, Me.rbbTelefoniaReporte})
        Me.rbbTabTelefonia.Key = "RibbonTab2"
        Me.rbbTabTelefonia.Name = "rbbTabTelefonia"
        Me.rbbTabTelefonia.Text = "Telefonia"
        '
        'rbbTelefoniaMante
        '
        Me.rbbTelefoniaMante.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnTelModelos, Me.btnTelEquipos, Me.btnTelPlanes})
        Me.rbbTelefoniaMante.Key = "RibbonGroup4"
        Me.rbbTelefoniaMante.Name = "rbbTelefoniaMante"
        Me.rbbTelefoniaMante.Text = "Mantenimiento"
        '
        'btnTelModelos
        '
        Me.btnTelModelos.Image = CType(resources.GetObject("btnTelModelos.Image"), System.Drawing.Image)
        Me.btnTelModelos.Key = "ButtonCommand1"
        Me.btnTelModelos.Name = "btnTelModelos"
        Me.btnTelModelos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnTelModelos.Text = "Modelos"
        '
        'btnTelEquipos
        '
        Me.btnTelEquipos.Image = CType(resources.GetObject("btnTelEquipos.Image"), System.Drawing.Image)
        Me.btnTelEquipos.Key = "ButtonCommand1"
        Me.btnTelEquipos.Name = "btnTelEquipos"
        Me.btnTelEquipos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnTelEquipos.Text = "Equipos"
        '
        'btnTelPlanes
        '
        Me.btnTelPlanes.Image = CType(resources.GetObject("btnTelPlanes.Image"), System.Drawing.Image)
        Me.btnTelPlanes.Key = "ButtonCommand1"
        Me.btnTelPlanes.Name = "btnTelPlanes"
        Me.btnTelPlanes.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnTelPlanes.Text = "Planes"
        '
        'rbbTelefoniaAsigna
        '
        Me.rbbTelefoniaAsigna.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnTelLineas, Me.btnTelAsignaLinea})
        Me.rbbTelefoniaAsigna.Key = "RibbonGroup5"
        Me.rbbTelefoniaAsigna.Name = "rbbTelefoniaAsigna"
        Me.rbbTelefoniaAsigna.Text = "Asignación"
        '
        'btnTelLineas
        '
        Me.btnTelLineas.Image = CType(resources.GetObject("btnTelLineas.Image"), System.Drawing.Image)
        Me.btnTelLineas.Key = "ButtonCommand2"
        Me.btnTelLineas.Name = "btnTelLineas"
        Me.btnTelLineas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnTelLineas.Text = "Lineas"
        '
        'btnTelAsignaLinea
        '
        Me.btnTelAsignaLinea.Image = CType(resources.GetObject("btnTelAsignaLinea.Image"), System.Drawing.Image)
        Me.btnTelAsignaLinea.Key = "ButtonCommand1"
        Me.btnTelAsignaLinea.Name = "btnTelAsignaLinea"
        Me.btnTelAsignaLinea.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnTelAsignaLinea.Text = "Asigna Persona"
        '
        'rbbTelefoniaReporte
        '
        Me.rbbTelefoniaReporte.Key = "RibbonGroup6"
        Me.rbbTelefoniaReporte.Name = "rbbTelefoniaReporte"
        Me.rbbTelefoniaReporte.Text = "Reportes"
        '
        'rbbTabCRM
        '
        Me.rbbTabCRM.Groups.AddRange(New Janus.Windows.Ribbon.RibbonGroup() {Me.rbbCRMOportunidad, Me.rbbCRMReportes})
        Me.rbbTabCRM.Key = "RibbonTab2"
        Me.rbbTabCRM.Name = "rbbTabCRM"
        Me.rbbTabCRM.Text = "CRM"
        '
        'rbbCRMOportunidad
        '
        Me.rbbCRMOportunidad.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnCRMOportIngresar, Me.btnCRMOcurrencias, Me.btnCRMTarjetaCliente, Me.btnCRMVisitas, Me.btnCRMCuotas})
        Me.rbbCRMOportunidad.Image = CType(resources.GetObject("rbbCRMOportunidad.Image"), System.Drawing.Image)
        Me.rbbCRMOportunidad.Key = "RibbonGroup4"
        Me.rbbCRMOportunidad.Name = "rbbCRMOportunidad"
        Me.rbbCRMOportunidad.Text = "Oportunidades"
        '
        'btnCRMOportIngresar
        '
        Me.btnCRMOportIngresar.Image = CType(resources.GetObject("btnCRMOportIngresar.Image"), System.Drawing.Image)
        Me.btnCRMOportIngresar.Key = "ButtonCommand1"
        Me.btnCRMOportIngresar.Name = "btnCRMOportIngresar"
        Me.btnCRMOportIngresar.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCRMOportIngresar.Text = "Oportunidad Negocio"
        '
        'btnCRMOcurrencias
        '
        Me.btnCRMOcurrencias.Image = CType(resources.GetObject("btnCRMOcurrencias.Image"), System.Drawing.Image)
        Me.btnCRMOcurrencias.Key = "ButtonCommand1"
        Me.btnCRMOcurrencias.Name = "btnCRMOcurrencias"
        Me.btnCRMOcurrencias.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCRMOcurrencias.Text = "Ocurrencias"
        '
        'btnCRMTarjetaCliente
        '
        Me.btnCRMTarjetaCliente.Image = CType(resources.GetObject("btnCRMTarjetaCliente.Image"), System.Drawing.Image)
        Me.btnCRMTarjetaCliente.Key = "ButtonCommand1"
        Me.btnCRMTarjetaCliente.Name = "btnCRMTarjetaCliente"
        Me.btnCRMTarjetaCliente.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCRMTarjetaCliente.Text = "Tarjeta Cliente"
        '
        'btnCRMVisitas
        '
        Me.btnCRMVisitas.Image = CType(resources.GetObject("btnCRMVisitas.Image"), System.Drawing.Image)
        Me.btnCRMVisitas.Key = "ButtonCommand1"
        Me.btnCRMVisitas.Name = "btnCRMVisitas"
        Me.btnCRMVisitas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCRMVisitas.Text = "Visita Clientes"
        '
        'btnCRMCuotas
        '
        Me.btnCRMCuotas.Image = CType(resources.GetObject("btnCRMCuotas.Image"), System.Drawing.Image)
        Me.btnCRMCuotas.Key = "ButtonCommand1"
        Me.btnCRMCuotas.Name = "btnCRMCuotas"
        Me.btnCRMCuotas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCRMCuotas.Text = "Cuota Vendedor"
        '
        'rbbCRMReportes
        '
        Me.rbbCRMReportes.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnCRMRepOportunidad, Me.btnCRMRepVisitas})
        Me.rbbCRMReportes.Key = "RibbonGroup5"
        Me.rbbCRMReportes.Name = "rbbCRMReportes"
        Me.rbbCRMReportes.Text = "Reportes"
        '
        'btnCRMRepOportunidad
        '
        Me.btnCRMRepOportunidad.Image = CType(resources.GetObject("btnCRMRepOportunidad.Image"), System.Drawing.Image)
        Me.btnCRMRepOportunidad.Key = "ButtonCommand3"
        Me.btnCRMRepOportunidad.Name = "btnCRMRepOportunidad"
        Me.btnCRMRepOportunidad.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCRMRepOportunidad.Text = "Oportunidad Negocio"
        '
        'btnCRMRepVisitas
        '
        Me.btnCRMRepVisitas.Image = CType(resources.GetObject("btnCRMRepVisitas.Image"), System.Drawing.Image)
        Me.btnCRMRepVisitas.Key = "ButtonCommand1"
        Me.btnCRMRepVisitas.Name = "btnCRMRepVisitas"
        Me.btnCRMRepVisitas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCRMRepVisitas.Text = "Visita Clientes"
        '
        'rbbTabActivos
        '
        Me.rbbTabActivos.Groups.AddRange(New Janus.Windows.Ribbon.RibbonGroup() {Me.rbbActivoDatos, Me.rbbActivoReportes})
        Me.rbbTabActivos.Key = "RibbonTab2"
        Me.rbbTabActivos.Name = "rbbTabActivos"
        Me.rbbTabActivos.Text = "Activos"
        '
        'rbbActivoDatos
        '
        Me.rbbActivoDatos.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnActivoDatos})
        Me.rbbActivoDatos.Key = "RibbonGroup4"
        Me.rbbActivoDatos.Name = "rbbActivoDatos"
        Me.rbbActivoDatos.Text = "Activos"
        '
        'btnActivoDatos
        '
        Me.btnActivoDatos.Icon = CType(resources.GetObject("btnActivoDatos.Icon"), System.Drawing.Icon)
        Me.btnActivoDatos.Key = "ButtonCommand1"
        Me.btnActivoDatos.Name = "btnActivoDatos"
        Me.btnActivoDatos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnActivoDatos.Text = "Activos Fijos"
        '
        'rbbActivoReportes
        '
        Me.rbbActivoReportes.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnActivoReporte})
        Me.rbbActivoReportes.Key = "RibbonGroup4"
        Me.rbbActivoReportes.Name = "rbbActivoReportes"
        Me.rbbActivoReportes.Text = "Reportes"
        '
        'btnActivoReporte
        '
        Me.btnActivoReporte.Image = CType(resources.GetObject("btnActivoReporte.Image"), System.Drawing.Image)
        Me.btnActivoReporte.Key = "ButtonCommand1"
        Me.btnActivoReporte.Name = "btnActivoReporte"
        Me.btnActivoReporte.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnActivoReporte.Text = "Reporte Activos Fijos"
        '
        'rbbTabTablas
        '
        Me.rbbTabTablas.Groups.AddRange(New Janus.Windows.Ribbon.RibbonGroup() {Me.rbbTabTabVentas, Me.rbbTabTabAlmacen, Me.rbbTabTabImportacion, Me.rbbTabTabServicios, Me.rbbTabTabCompras, Me.rbbTabTabContabilidad, Me.rbbTabTabPersonal, Me.rbbTabTabRondas})
        Me.rbbTabTablas.Key = "6"
        Me.rbbTabTablas.KeyTip = "Tablas"
        Me.rbbTabTablas.Name = "rbbTabTablas"
        Me.rbbTabTablas.Text = "Tablas"
        '
        'rbbTabTabVentas
        '
        Me.rbbTabTabVentas.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnTabVenClientes, Me.btnTabCondicionPagoCliente})
        Me.rbbTabTabVentas.ImageKey = ""
        Me.rbbTabTabVentas.Key = "RibbonGroup1"
        Me.rbbTabTabVentas.Name = "rbbTabTabVentas"
        Me.rbbTabTabVentas.Text = "Ventas"
        '
        'btnTabVenClientes
        '
        Me.btnTabVenClientes.Image = CType(resources.GetObject("btnTabVenClientes.Image"), System.Drawing.Image)
        Me.btnTabVenClientes.Key = "ButtonCommand1"
        Me.btnTabVenClientes.Name = "btnTabVenClientes"
        Me.btnTabVenClientes.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnTabVenClientes.Text = "Clientes"
        '
        'btnTabCondicionPagoCliente
        '
        Me.btnTabCondicionPagoCliente.Image = CType(resources.GetObject("btnTabCondicionPagoCliente.Image"), System.Drawing.Image)
        Me.btnTabCondicionPagoCliente.Key = "ButtonCommand1"
        Me.btnTabCondicionPagoCliente.Name = "btnTabCondicionPagoCliente"
        Me.btnTabCondicionPagoCliente.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnTabCondicionPagoCliente.Text = "Condición de Pago"
        '
        'rbbTabTabAlmacen
        '
        Me.rbbTabTabAlmacen.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnTabAlmMercaderias, Me.btnTabAlmTipoMotores, Me.btnTabAlmModelos, Me.btnTabAlmClases, Me.btnTabAlmPreciosCore})
        Me.rbbTabTabAlmacen.ImageKey = ""
        Me.rbbTabTabAlmacen.Key = "RibbonGroup2"
        Me.rbbTabTabAlmacen.Name = "rbbTabTabAlmacen"
        Me.rbbTabTabAlmacen.Text = "Almacenes"
        '
        'btnTabAlmMercaderias
        '
        Me.btnTabAlmMercaderias.Image = CType(resources.GetObject("btnTabAlmMercaderias.Image"), System.Drawing.Image)
        Me.btnTabAlmMercaderias.Key = "ButtonCommand2"
        Me.btnTabAlmMercaderias.Name = "btnTabAlmMercaderias"
        Me.btnTabAlmMercaderias.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnTabAlmMercaderias.Text = "Productos"
        '
        'btnTabAlmTipoMotores
        '
        Me.btnTabAlmTipoMotores.Image = CType(resources.GetObject("btnTabAlmTipoMotores.Image"), System.Drawing.Image)
        Me.btnTabAlmTipoMotores.Key = "ButtonCommand3"
        Me.btnTabAlmTipoMotores.Name = "btnTabAlmTipoMotores"
        Me.btnTabAlmTipoMotores.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnTabAlmTipoMotores.Text = "Tipo Motores"
        '
        'btnTabAlmModelos
        '
        Me.btnTabAlmModelos.Image = CType(resources.GetObject("btnTabAlmModelos.Image"), System.Drawing.Image)
        Me.btnTabAlmModelos.Key = "ButtonCommand4"
        Me.btnTabAlmModelos.Name = "btnTabAlmModelos"
        Me.btnTabAlmModelos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnTabAlmModelos.Text = "Modelos"
        '
        'btnTabAlmClases
        '
        Me.btnTabAlmClases.Image = CType(resources.GetObject("btnTabAlmClases.Image"), System.Drawing.Image)
        Me.btnTabAlmClases.Key = "ButtonCommand1"
        Me.btnTabAlmClases.Name = "btnTabAlmClases"
        Me.btnTabAlmClases.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnTabAlmClases.Text = "Categorias"
        '
        'btnTabAlmPreciosCore
        '
        Me.btnTabAlmPreciosCore.Image = CType(resources.GetObject("btnTabAlmPreciosCore.Image"), System.Drawing.Image)
        Me.btnTabAlmPreciosCore.Key = "ButtonCommand1"
        Me.btnTabAlmPreciosCore.Name = "btnTabAlmPreciosCore"
        Me.btnTabAlmPreciosCore.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnTabAlmPreciosCore.Text = "Precios Core"
        '
        'rbbTabTabImportacion
        '
        Me.rbbTabTabImportacion.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnTabImpPartidas, Me.btnTabImpMarcas})
        Me.rbbTabTabImportacion.ImageKey = ""
        Me.rbbTabTabImportacion.Key = "RibbonGroup3"
        Me.rbbTabTabImportacion.Name = "rbbTabTabImportacion"
        Me.rbbTabTabImportacion.Text = "Importaciones"
        '
        'btnTabImpPartidas
        '
        Me.btnTabImpPartidas.Image = CType(resources.GetObject("btnTabImpPartidas.Image"), System.Drawing.Image)
        Me.btnTabImpPartidas.Key = "ButtonCommand6"
        Me.btnTabImpPartidas.Name = "btnTabImpPartidas"
        Me.btnTabImpPartidas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnTabImpPartidas.Text = "Partidas"
        '
        'btnTabImpMarcas
        '
        Me.btnTabImpMarcas.Image = CType(resources.GetObject("btnTabImpMarcas.Image"), System.Drawing.Image)
        Me.btnTabImpMarcas.Key = "ButtonCommand5"
        Me.btnTabImpMarcas.Name = "btnTabImpMarcas"
        Me.btnTabImpMarcas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnTabImpMarcas.Text = "Marcas"
        '
        'rbbTabTabServicios
        '
        Me.rbbTabTabServicios.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnPlantillaRepuesto, Me.btnPlantillaRepuestoCliente, Me.btnManteUbicaServicio, Me.btnTabManteVehiculos})
        Me.rbbTabTabServicios.Key = "RibbonGroup4"
        Me.rbbTabTabServicios.Name = "rbbTabTabServicios"
        Me.rbbTabTabServicios.Text = "Servicios"
        '
        'btnPlantillaRepuesto
        '
        Me.btnPlantillaRepuesto.Image = CType(resources.GetObject("btnPlantillaRepuesto.Image"), System.Drawing.Image)
        Me.btnPlantillaRepuesto.Key = "ButtonCommand1"
        Me.btnPlantillaRepuesto.Name = "btnPlantillaRepuesto"
        Me.btnPlantillaRepuesto.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPlantillaRepuesto.Text = "Plantilla Repuestos"
        '
        'btnPlantillaRepuestoCliente
        '
        Me.btnPlantillaRepuestoCliente.Image = CType(resources.GetObject("btnPlantillaRepuestoCliente.Image"), System.Drawing.Image)
        Me.btnPlantillaRepuestoCliente.Key = "ButtonCommand2"
        Me.btnPlantillaRepuestoCliente.Name = "btnPlantillaRepuestoCliente"
        Me.btnPlantillaRepuestoCliente.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPlantillaRepuestoCliente.Text = "Plantilla Repuestos Cliente"
        '
        'btnManteUbicaServicio
        '
        Me.btnManteUbicaServicio.Icon = CType(resources.GetObject("btnManteUbicaServicio.Icon"), System.Drawing.Icon)
        Me.btnManteUbicaServicio.Key = "ButtonCommand1"
        Me.btnManteUbicaServicio.Name = "btnManteUbicaServicio"
        Me.btnManteUbicaServicio.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnManteUbicaServicio.Text = "Ubicacion Servicio"
        '
        'btnTabManteVehiculos
        '
        Me.btnTabManteVehiculos.Image = CType(resources.GetObject("btnTabManteVehiculos.Image"), System.Drawing.Image)
        Me.btnTabManteVehiculos.Key = "ButtonCommand1"
        Me.btnTabManteVehiculos.Name = "btnTabManteVehiculos"
        Me.btnTabManteVehiculos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnTabManteVehiculos.Text = "Vehiculos"
        '
        'rbbTabTabCompras
        '
        Me.rbbTabTabCompras.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnproveedores, Me.btnCondicionPagoProveedores})
        Me.rbbTabTabCompras.Key = "RibbonGroup4"
        Me.rbbTabTabCompras.Name = "rbbTabTabCompras"
        Me.rbbTabTabCompras.Text = "Compras"
        '
        'btnproveedores
        '
        Me.btnproveedores.Image = CType(resources.GetObject("btnproveedores.Image"), System.Drawing.Image)
        Me.btnproveedores.Key = "ButtonCommand1"
        Me.btnproveedores.Name = "btnproveedores"
        Me.btnproveedores.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnproveedores.Text = "Proveedores"
        '
        'btnCondicionPagoProveedores
        '
        Me.btnCondicionPagoProveedores.Image = CType(resources.GetObject("btnCondicionPagoProveedores.Image"), System.Drawing.Image)
        Me.btnCondicionPagoProveedores.Key = "ButtonCommand1"
        Me.btnCondicionPagoProveedores.Name = "btnCondicionPagoProveedores"
        Me.btnCondicionPagoProveedores.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnCondicionPagoProveedores.Text = "Condición de Pago"
        '
        'rbbTabTabContabilidad
        '
        Me.rbbTabTabContabilidad.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnManteCuentaContable, Me.btnManteCuentaDestino})
        Me.rbbTabTabContabilidad.Key = "Contabilidad"
        Me.rbbTabTabContabilidad.Name = "rbbTabTabContabilidad"
        Me.rbbTabTabContabilidad.Text = "Contabilidad"
        '
        'btnManteCuentaContable
        '
        Me.btnManteCuentaContable.Image = CType(resources.GetObject("btnManteCuentaContable.Image"), System.Drawing.Image)
        Me.btnManteCuentaContable.Key = "ButtonCommand1"
        Me.btnManteCuentaContable.Name = "btnManteCuentaContable"
        Me.btnManteCuentaContable.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnManteCuentaContable.Text = "Cuenta Contable"
        '
        'btnManteCuentaDestino
        '
        Me.btnManteCuentaDestino.Image = CType(resources.GetObject("btnManteCuentaDestino.Image"), System.Drawing.Image)
        Me.btnManteCuentaDestino.Key = "ButtonCommand1"
        Me.btnManteCuentaDestino.Name = "btnManteCuentaDestino"
        Me.btnManteCuentaDestino.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnManteCuentaDestino.Text = "Cuentas Destino"
        '
        'rbbTabTabPersonal
        '
        Me.rbbTabTabPersonal.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnManteRubroPlanilla, Me.btnManteRubroPlanillaCuentas, Me.btnManteHorarios, Me.btnManteFeriadoPersonal, Me.btnManteAfp, Me.btnManteCargos, Me.btnManteAreas, Me.btnManteMotFaltas, Me.btnManteEquipoLector, Me.btnManteTipoHoraExtra})
        Me.rbbTabTabPersonal.Key = "RibbonGroup4"
        Me.rbbTabTabPersonal.Name = "rbbTabTabPersonal"
        Me.rbbTabTabPersonal.Text = "Personal"
        '
        'btnManteRubroPlanilla
        '
        Me.btnManteRubroPlanilla.Image = CType(resources.GetObject("btnManteRubroPlanilla.Image"), System.Drawing.Image)
        Me.btnManteRubroPlanilla.Key = "ButtonCommand1"
        Me.btnManteRubroPlanilla.Name = "btnManteRubroPlanilla"
        Me.btnManteRubroPlanilla.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnManteRubroPlanilla.Text = "Rubro Planilla"
        '
        'btnManteRubroPlanillaCuentas
        '
        Me.btnManteRubroPlanillaCuentas.Image = CType(resources.GetObject("btnManteRubroPlanillaCuentas.Image"), System.Drawing.Image)
        Me.btnManteRubroPlanillaCuentas.Key = "ButtonCommand1"
        Me.btnManteRubroPlanillaCuentas.Name = "btnManteRubroPlanillaCuentas"
        Me.btnManteRubroPlanillaCuentas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnManteRubroPlanillaCuentas.Text = "Rubro Planilla Ctas"
        '
        'btnManteHorarios
        '
        Me.btnManteHorarios.Image = CType(resources.GetObject("btnManteHorarios.Image"), System.Drawing.Image)
        Me.btnManteHorarios.Key = "ButtonCommand1"
        Me.btnManteHorarios.Name = "btnManteHorarios"
        Me.btnManteHorarios.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnManteHorarios.Text = "Horarios"
        '
        'btnManteFeriadoPersonal
        '
        Me.btnManteFeriadoPersonal.Icon = CType(resources.GetObject("btnManteFeriadoPersonal.Icon"), System.Drawing.Icon)
        Me.btnManteFeriadoPersonal.Key = "ButtonCommand1"
        Me.btnManteFeriadoPersonal.Name = "btnManteFeriadoPersonal"
        Me.btnManteFeriadoPersonal.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnManteFeriadoPersonal.Text = "Feriados"
        '
        'btnManteAfp
        '
        Me.btnManteAfp.Image = CType(resources.GetObject("btnManteAfp.Image"), System.Drawing.Image)
        Me.btnManteAfp.Key = "ButtonCommand1"
        Me.btnManteAfp.Name = "btnManteAfp"
        Me.btnManteAfp.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnManteAfp.Text = "AFP"
        '
        'btnManteCargos
        '
        Me.btnManteCargos.Icon = CType(resources.GetObject("btnManteCargos.Icon"), System.Drawing.Icon)
        Me.btnManteCargos.Key = "ButtonCommand1"
        Me.btnManteCargos.Name = "btnManteCargos"
        Me.btnManteCargos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnManteCargos.Text = "Cargos"
        '
        'btnManteAreas
        '
        Me.btnManteAreas.Icon = CType(resources.GetObject("btnManteAreas.Icon"), System.Drawing.Icon)
        Me.btnManteAreas.Key = "ButtonCommand1"
        Me.btnManteAreas.Name = "btnManteAreas"
        Me.btnManteAreas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnManteAreas.Text = "Áreas"
        '
        'btnManteMotFaltas
        '
        Me.btnManteMotFaltas.Image = CType(resources.GetObject("btnManteMotFaltas.Image"), System.Drawing.Image)
        Me.btnManteMotFaltas.Key = "ButtonCommand1"
        Me.btnManteMotFaltas.Name = "btnManteMotFaltas"
        Me.btnManteMotFaltas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnManteMotFaltas.Text = "Motivos Faltas"
        '
        'btnManteEquipoLector
        '
        Me.btnManteEquipoLector.Image = CType(resources.GetObject("btnManteEquipoLector.Image"), System.Drawing.Image)
        Me.btnManteEquipoLector.Key = "ButtonCommand1"
        Me.btnManteEquipoLector.Name = "btnManteEquipoLector"
        Me.btnManteEquipoLector.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnManteEquipoLector.Text = "Equipo Lector"
        '
        'btnManteTipoHoraExtra
        '
        Me.btnManteTipoHoraExtra.Image = CType(resources.GetObject("btnManteTipoHoraExtra.Image"), System.Drawing.Image)
        Me.btnManteTipoHoraExtra.Key = "ButtonCommand1"
        Me.btnManteTipoHoraExtra.Name = "btnManteTipoHoraExtra"
        Me.btnManteTipoHoraExtra.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnManteTipoHoraExtra.Text = "Tipo Hora Extra"
        '
        'rbbTabTabRondas
        '
        Me.rbbTabTabRondas.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnManteRuteador, Me.btnManteRutas, Me.btnMantePuntosControl})
        Me.rbbTabTabRondas.Key = "RibbonGroup4"
        Me.rbbTabTabRondas.Name = "rbbTabTabRondas"
        Me.rbbTabTabRondas.Text = "Rondas"
        '
        'btnManteRuteador
        '
        Me.btnManteRuteador.Image = CType(resources.GetObject("btnManteRuteador.Image"), System.Drawing.Image)
        Me.btnManteRuteador.Key = "ButtonCommand2"
        Me.btnManteRuteador.Name = "btnManteRuteador"
        Me.btnManteRuteador.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnManteRuteador.Text = "Ruteador"
        '
        'btnManteRutas
        '
        Me.btnManteRutas.Image = CType(resources.GetObject("btnManteRutas.Image"), System.Drawing.Image)
        Me.btnManteRutas.Key = "ButtonCommand2"
        Me.btnManteRutas.Name = "btnManteRutas"
        Me.btnManteRutas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnManteRutas.Text = "Rutas"
        '
        'btnMantePuntosControl
        '
        Me.btnMantePuntosControl.Image = CType(resources.GetObject("btnMantePuntosControl.Image"), System.Drawing.Image)
        Me.btnMantePuntosControl.Key = "ButtonCommand2"
        Me.btnMantePuntosControl.Name = "btnMantePuntosControl"
        Me.btnMantePuntosControl.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnMantePuntosControl.Text = "Puntos Control"
        '
        'RibbonTab1
        '
        Me.RibbonTab1.Groups.AddRange(New Janus.Windows.Ribbon.RibbonGroup() {Me.RibbonGroup1})
        Me.RibbonTab1.Key = "RibbonTab1"
        Me.RibbonTab1.KeyTip = "Logueo"
        Me.RibbonTab1.Name = "RibbonTab1"
        Me.RibbonTab1.Text = "Logueo"
        '
        'RibbonGroup1
        '
        Me.RibbonGroup1.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnLogueoCerrarSesion, Me.btnLogueoCambiarClave, Me.btnLogueoEmpresas})
        Me.RibbonGroup1.Key = "RibbonGroup1"
        Me.RibbonGroup1.Name = "RibbonGroup1"
        Me.RibbonGroup1.Text = "Login"
        '
        'btnLogueoCerrarSesion
        '
        Me.btnLogueoCerrarSesion.Icon = CType(resources.GetObject("btnLogueoCerrarSesion.Icon"), System.Drawing.Icon)
        Me.btnLogueoCerrarSesion.Key = "ButtonCommand1"
        Me.btnLogueoCerrarSesion.Name = "btnLogueoCerrarSesion"
        Me.btnLogueoCerrarSesion.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnLogueoCerrarSesion.Text = "Cerrar Sesion"
        '
        'btnLogueoCambiarClave
        '
        Me.btnLogueoCambiarClave.Icon = CType(resources.GetObject("btnLogueoCambiarClave.Icon"), System.Drawing.Icon)
        Me.btnLogueoCambiarClave.Key = "ButtonCommand2"
        Me.btnLogueoCambiarClave.Name = "btnLogueoCambiarClave"
        Me.btnLogueoCambiarClave.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnLogueoCambiarClave.Text = "Cambiar Contraseña"
        '
        'btnLogueoEmpresas
        '
        Me.btnLogueoEmpresas.Icon = CType(resources.GetObject("btnLogueoEmpresas.Icon"), System.Drawing.Icon)
        Me.btnLogueoEmpresas.Key = "ButtonCommand1"
        Me.btnLogueoEmpresas.Name = "btnLogueoEmpresas"
        Me.btnLogueoEmpresas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnLogueoEmpresas.Text = "Cambiar Empresa"
        '
        'rbbTabAdministracion
        '
        Me.rbbTabAdministracion.Groups.AddRange(New Janus.Windows.Ribbon.RibbonGroup() {Me.rbbAdminSeguridad, Me.rbbAdminUsuarios, Me.rbbAdminReportes, Me.rbbAdminEncuestas, Me.rbbAdminSoftware, Me.rbbAdminLlamadas, Me.rbbAdminTablas})
        Me.rbbTabAdministracion.Key = "7"
        Me.rbbTabAdministracion.KeyTip = "Administración"
        Me.rbbTabAdministracion.Name = "rbbTabAdministracion"
        Me.rbbTabAdministracion.Text = "Administracion"
        '
        'rbbAdminSeguridad
        '
        Me.rbbAdminSeguridad.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnUsuarios, Me.btnPerfiles, Me.btnSesiones})
        Me.rbbAdminSeguridad.Key = "RibbonGroup7"
        Me.rbbAdminSeguridad.Name = "rbbAdminSeguridad"
        Me.rbbAdminSeguridad.Text = "Seguridad"
        '
        'btnUsuarios
        '
        Me.btnUsuarios.Image = CType(resources.GetObject("btnUsuarios.Image"), System.Drawing.Image)
        Me.btnUsuarios.Key = "ButtonCommand1"
        Me.btnUsuarios.Name = "btnUsuarios"
        Me.btnUsuarios.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnUsuarios.Text = "Usuarios"
        '
        'btnPerfiles
        '
        Me.btnPerfiles.Image = CType(resources.GetObject("btnPerfiles.Image"), System.Drawing.Image)
        Me.btnPerfiles.Key = "ButtonCommand2"
        Me.btnPerfiles.Name = "btnPerfiles"
        Me.btnPerfiles.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnPerfiles.Text = "Perfiles"
        '
        'btnSesiones
        '
        Me.btnSesiones.Image = CType(resources.GetObject("btnSesiones.Image"), System.Drawing.Image)
        Me.btnSesiones.Key = "ButtonCommand1"
        Me.btnSesiones.Name = "btnSesiones"
        Me.btnSesiones.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSesiones.Text = "Sesiones"
        '
        'rbbAdminUsuarios
        '
        Me.rbbAdminUsuarios.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnAtencionSolicitud})
        Me.rbbAdminUsuarios.Key = "RibbonGroup4"
        Me.rbbAdminUsuarios.Name = "rbbAdminUsuarios"
        Me.rbbAdminUsuarios.Text = "Usuarios"
        '
        'btnAtencionSolicitud
        '
        Me.btnAtencionSolicitud.Image = CType(resources.GetObject("btnAtencionSolicitud.Image"), System.Drawing.Image)
        Me.btnAtencionSolicitud.Key = "ButtonCommand1"
        Me.btnAtencionSolicitud.Name = "btnAtencionSolicitud"
        Me.btnAtencionSolicitud.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAtencionSolicitud.Text = "Atender Solicitud"
        '
        'rbbAdminReportes
        '
        Me.rbbAdminReportes.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnAdminIndicadorSolicitud})
        Me.rbbAdminReportes.Key = "RibbonGroup4"
        Me.rbbAdminReportes.Name = "rbbAdminReportes"
        Me.rbbAdminReportes.Text = "Reportes"
        '
        'btnAdminIndicadorSolicitud
        '
        Me.btnAdminIndicadorSolicitud.Image = CType(resources.GetObject("btnAdminIndicadorSolicitud.Image"), System.Drawing.Image)
        Me.btnAdminIndicadorSolicitud.Key = "ButtonCommand1"
        Me.btnAdminIndicadorSolicitud.Name = "btnAdminIndicadorSolicitud"
        Me.btnAdminIndicadorSolicitud.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAdminIndicadorSolicitud.Text = "Indicadores"
        '
        'rbbAdminEncuestas
        '
        Me.rbbAdminEncuestas.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnAdminEncuesta, Me.btnAdminResultadoEncuesta})
        Me.rbbAdminEncuestas.Key = "RibbonGroup4"
        Me.rbbAdminEncuestas.Name = "rbbAdminEncuestas"
        Me.rbbAdminEncuestas.Text = "Encuestas"
        '
        'btnAdminEncuesta
        '
        Me.btnAdminEncuesta.Icon = CType(resources.GetObject("btnAdminEncuesta.Icon"), System.Drawing.Icon)
        Me.btnAdminEncuesta.Key = "ButtonCommand1"
        Me.btnAdminEncuesta.Name = "btnAdminEncuesta"
        Me.btnAdminEncuesta.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAdminEncuesta.Text = "Encuesta"
        '
        'btnAdminResultadoEncuesta
        '
        Me.btnAdminResultadoEncuesta.Icon = CType(resources.GetObject("btnAdminResultadoEncuesta.Icon"), System.Drawing.Icon)
        Me.btnAdminResultadoEncuesta.Key = "ButtonCommand1"
        Me.btnAdminResultadoEncuesta.Name = "btnAdminResultadoEncuesta"
        Me.btnAdminResultadoEncuesta.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAdminResultadoEncuesta.Text = "Resultado"
        '
        'rbbAdminSoftware
        '
        Me.rbbAdminSoftware.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnAdminSoftwareAsignar, Me.btnAdminSoftwareComputadora})
        Me.rbbAdminSoftware.Key = "RibbonGroup4"
        Me.rbbAdminSoftware.Name = "rbbAdminSoftware"
        Me.rbbAdminSoftware.Text = "Inventario"
        '
        'btnAdminSoftwareAsignar
        '
        Me.btnAdminSoftwareAsignar.Image = CType(resources.GetObject("btnAdminSoftwareAsignar.Image"), System.Drawing.Image)
        Me.btnAdminSoftwareAsignar.Key = "ButtonCommand1"
        Me.btnAdminSoftwareAsignar.Name = "btnAdminSoftwareAsignar"
        Me.btnAdminSoftwareAsignar.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAdminSoftwareAsignar.Text = "Asignar Computadora"
        '
        'btnAdminSoftwareComputadora
        '
        Me.btnAdminSoftwareComputadora.Image = CType(resources.GetObject("btnAdminSoftwareComputadora.Image"), System.Drawing.Image)
        Me.btnAdminSoftwareComputadora.Key = "ButtonCommand1"
        Me.btnAdminSoftwareComputadora.Name = "btnAdminSoftwareComputadora"
        Me.btnAdminSoftwareComputadora.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAdminSoftwareComputadora.Text = "Computadora"
        '
        'rbbAdminLlamadas
        '
        Me.rbbAdminLlamadas.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnAdminLlamadas})
        Me.rbbAdminLlamadas.Key = "RibbonGroup4"
        Me.rbbAdminLlamadas.Name = "rbbAdminLlamadas"
        Me.rbbAdminLlamadas.Text = "Llamadas"
        '
        'btnAdminLlamadas
        '
        Me.btnAdminLlamadas.Icon = CType(resources.GetObject("btnAdminLlamadas.Icon"), System.Drawing.Icon)
        Me.btnAdminLlamadas.Key = "ButtonCommand1"
        Me.btnAdminLlamadas.Name = "btnAdminLlamadas"
        Me.btnAdminLlamadas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAdminLlamadas.Text = "Llamadas"
        '
        'rbbAdminTablas
        '
        Me.rbbAdminTablas.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnAdminEquiposMarcacion, Me.btnAdminEmpresas, Me.btnAdminSeriesDocumentos, Me.btnAdminLocaciones, Me.btnAdminRubros, Me.btnAdminParametrosLocacion, Me.btnAdminParametrosPlanilla, Me.btnAdminRubroEmpresa})
        Me.rbbAdminTablas.Key = "RibbonGroup4"
        Me.rbbAdminTablas.Name = "rbbAdminTablas"
        Me.rbbAdminTablas.Text = "Tablas Generales"
        '
        'btnAdminEquiposMarcacion
        '
        Me.btnAdminEquiposMarcacion.Icon = CType(resources.GetObject("btnAdminEquiposMarcacion.Icon"), System.Drawing.Icon)
        Me.btnAdminEquiposMarcacion.Key = "ButtonCommand1"
        Me.btnAdminEquiposMarcacion.Name = "btnAdminEquiposMarcacion"
        Me.btnAdminEquiposMarcacion.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAdminEquiposMarcacion.Text = "Equipos Marcación Personal"
        '
        'btnAdminEmpresas
        '
        Me.btnAdminEmpresas.Image = CType(resources.GetObject("btnAdminEmpresas.Image"), System.Drawing.Image)
        Me.btnAdminEmpresas.Key = "ButtonCommand1"
        Me.btnAdminEmpresas.Name = "btnAdminEmpresas"
        Me.btnAdminEmpresas.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAdminEmpresas.Text = "Empresas"
        '
        'btnAdminSeriesDocumentos
        '
        Me.btnAdminSeriesDocumentos.Image = CType(resources.GetObject("btnAdminSeriesDocumentos.Image"), System.Drawing.Image)
        Me.btnAdminSeriesDocumentos.Key = "ButtonCommand1"
        Me.btnAdminSeriesDocumentos.Name = "btnAdminSeriesDocumentos"
        Me.btnAdminSeriesDocumentos.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAdminSeriesDocumentos.Text = "Series Documentos"
        '
        'btnAdminLocaciones
        '
        Me.btnAdminLocaciones.Image = CType(resources.GetObject("btnAdminLocaciones.Image"), System.Drawing.Image)
        Me.btnAdminLocaciones.Key = "ButtonCommand1"
        Me.btnAdminLocaciones.Name = "btnAdminLocaciones"
        Me.btnAdminLocaciones.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAdminLocaciones.Text = "Locaciones"
        '
        'btnAdminRubros
        '
        Me.btnAdminRubros.Image = CType(resources.GetObject("btnAdminRubros.Image"), System.Drawing.Image)
        Me.btnAdminRubros.Key = "ButtonCommand1"
        Me.btnAdminRubros.Name = "btnAdminRubros"
        Me.btnAdminRubros.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAdminRubros.Text = "Rubros de Productos"
        '
        'btnAdminParametrosLocacion
        '
        Me.btnAdminParametrosLocacion.Image = CType(resources.GetObject("btnAdminParametrosLocacion.Image"), System.Drawing.Image)
        Me.btnAdminParametrosLocacion.Key = "ButtonCommand1"
        Me.btnAdminParametrosLocacion.Name = "btnAdminParametrosLocacion"
        Me.btnAdminParametrosLocacion.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAdminParametrosLocacion.Text = "Parametros Locaciones"
        '
        'btnAdminParametrosPlanilla
        '
        Me.btnAdminParametrosPlanilla.Image = CType(resources.GetObject("btnAdminParametrosPlanilla.Image"), System.Drawing.Image)
        Me.btnAdminParametrosPlanilla.Key = "ButtonCommand2"
        Me.btnAdminParametrosPlanilla.Name = "btnAdminParametrosPlanilla"
        Me.btnAdminParametrosPlanilla.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAdminParametrosPlanilla.Text = "Parametros Planilla Sueldos"
        '
        'btnAdminRubroEmpresa
        '
        Me.btnAdminRubroEmpresa.Icon = CType(resources.GetObject("btnAdminRubroEmpresa.Icon"), System.Drawing.Icon)
        Me.btnAdminRubroEmpresa.Key = "ButtonCommand1"
        Me.btnAdminRubroEmpresa.Name = "btnAdminRubroEmpresa"
        Me.btnAdminRubroEmpresa.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAdminRubroEmpresa.Text = "Rubros x Empresa"
        '
        'rbbTabAyuda
        '
        Me.rbbTabAyuda.Groups.AddRange(New Janus.Windows.Ribbon.RibbonGroup() {Me.RibbonGroup2, Me.RibbonGroup3})
        Me.rbbTabAyuda.Key = "RibbonTab2"
        Me.rbbTabAyuda.Name = "rbbTabAyuda"
        Me.rbbTabAyuda.Text = "Ayuda"
        '
        'RibbonGroup2
        '
        Me.RibbonGroup2.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnSolicitudUsuario})
        Me.RibbonGroup2.Key = "RibbonGroup2"
        Me.RibbonGroup2.Name = "RibbonGroup2"
        Me.RibbonGroup2.Text = "Usuario"
        '
        'btnSolicitudUsuario
        '
        Me.btnSolicitudUsuario.Image = CType(resources.GetObject("btnSolicitudUsuario.Image"), System.Drawing.Image)
        Me.btnSolicitudUsuario.Key = "ButtonCommand1"
        Me.btnSolicitudUsuario.Name = "btnSolicitudUsuario"
        Me.btnSolicitudUsuario.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnSolicitudUsuario.Text = "Solicitud"
        '
        'RibbonGroup3
        '
        Me.RibbonGroup3.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.btnAyuda, Me.btnAcerca})
        Me.RibbonGroup3.Key = "RibbonGroup3"
        Me.RibbonGroup3.Name = "RibbonGroup3"
        Me.RibbonGroup3.Text = "Ayuda"
        '
        'btnAyuda
        '
        Me.btnAyuda.Image = CType(resources.GetObject("btnAyuda.Image"), System.Drawing.Image)
        Me.btnAyuda.Key = "ButtonCommand1"
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAyuda.Text = "Información Cambios"
        '
        'btnAcerca
        '
        Me.btnAcerca.Image = CType(resources.GetObject("btnAcerca.Image"), System.Drawing.Image)
        Me.btnAcerca.Key = "ButtonCommand2"
        Me.btnAcerca.Name = "btnAcerca"
        Me.btnAcerca.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Small
        Me.btnAcerca.Text = "Acerca"
        '
        'TVEmerg
        '
        Me.TVEmerg.Enabled = True
        Me.TVEmerg.Interval = 60000
        '
        'MDIPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1761, 1069)
        Me.Controls.Add(Me.rbbMTU)
        Me.Controls.Add(Me.StatusStrip)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "MDIPrincipal"
        Me.Text = "MDIPrincipal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.rbbMTU, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents rbbMTU As Janus.Windows.Ribbon.Ribbon
    Friend WithEvents rbbTabVentas As Janus.Windows.Ribbon.RibbonTab
    Friend WithEvents rbbVenDocumentos As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnVenDocFacturas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenDocBoletas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenDocGuiasRemision As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenDocGuiasDevolucion As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbVenClientes As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnVenCliCartera As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbVenPrePostVenta As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnVenPreCotizaciones As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenPreOrdenesCompra As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbVenRequisiciones As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnVenReqDespachos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbTabAlmacenes As Janus.Windows.Ribbon.RibbonTab
    Friend WithEvents rbbTabCréditos As Janus.Windows.Ribbon.RibbonTab
    Friend WithEvents rbbCreDocumentos As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents rbbCreAprobaciones As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnCreAprCreditos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbCreMantenimiento As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnCreManFacDesc As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreDocCuentas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreDocPlanillas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreDocAnticipos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreDocLetras As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreAprCotizaciones As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreManBancos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbCreConsultas As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnCreConCuentas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreConVencimientos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbAlmAlmacen As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnAlmAlmDocumentos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAlmAlmChequeoFI As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAlmAlmTI As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAlmAlmMTI As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAlmAlmValesMate As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbAlmMotores As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnAlmMotTransferencias As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAlmMotCompras As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAlmManLiquiGastos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbAlmMantenimiento As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents rbbAlmTransito As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnAlmTraDocumentos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAlmManMercaderias As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbAlmConsultas As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnAlmConTarjetas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbVenReportes As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents rbbAlmReportes As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents rbbCreReportes As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents rbbVenConsultas As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnVenConPrecios As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbTabImportaciones As Janus.Windows.Ribbon.RibbonTab
    Friend WithEvents rbbImpImportaciones As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnImpImpDocumentos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbImpPedidos As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnImpPedImportacion As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnImpPedInternos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbImpConsultas As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents rbbImpReportes As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents rbbTabTablas As Janus.Windows.Ribbon.RibbonTab
    Friend WithEvents rbbTabTabVentas As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents rbbTabTabAlmacen As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnTabAlmMercaderias As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnTabAlmTipoMotores As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnTabAlmModelos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbTabTabImportacion As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnTabImpPartidas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnTabImpMarcas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenDocNotas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbTabCostos As Janus.Windows.Ribbon.RibbonTab
    Friend WithEvents rbbCostoImportaciones As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents rbbCostoProcesos As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents rbbCostoDocumentos As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents rbbCostoReportes As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnCostoValorizarImp As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCostoRecalcular As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCostoAjustarCierre As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCostoCerrarMes As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCostoConsolidado As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCostoActualizarDocs As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCostoRepImportaciones As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCostoDiarioAlmacen As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCostoStockValorizado As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCostoRepCierreMes As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAlmRepInventario As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAlmRepTomaInventario As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAlmRepMovimientos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAlmRepValeMaterial As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenRepVentaDetalle As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenRepVentaAcumulada As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenRepVentaGuias As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreRepCtasCtes As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreRepDiarioPago As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreRepDocEmitido As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreRepLetra As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreRepNotasDebito As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreRepPlanilla As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenReclamo As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbTabAdministracion As Janus.Windows.Ribbon.RibbonTab
    Friend WithEvents rbbAdminSeguridad As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnUsuarios As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerfiles As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents lblUsuario As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnCostoRepKardex As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCostoRepCostoVenta As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCostoRepCondensado As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnTabVenClientes As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblTransa As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnAlmAlmAtenderJob As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenRepCotizaciones As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenConDocumentos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenPostActuVendedor As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreManVisitaCobrador As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreRepVisitaCobrador As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCostoProTrasladarCosto As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCostoProGenerarPeriodo As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCostoRepMotores As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents RibbonTab1 As Janus.Windows.Ribbon.RibbonTab
    Friend WithEvents RibbonGroup1 As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnLogueoCerrarSesion As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnLogueoCambiarClave As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenRepVentaRequisiciones As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbTabGerencia As Janus.Windows.Ribbon.RibbonTab
    Friend WithEvents rbbGerReportes As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnImpRepPedidoImp As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreManProcesarGuias As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnGerVentas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnGerImportaciones As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnGerInventario As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnGerContabilidad As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnGerCreditos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnGerServicios As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCostoRepResumenGen As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenRepMensualesxCliente As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnGerFiltroIndicadores As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCostoRepSobregiro As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnTabAlmClases As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnTabAlmPreciosCore As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnGerTarjeta As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents ddcCreRepVencimientos As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents ddcCreRepVencimientoDetalle As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents ddcCreRepVencimientoAcumulado As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents ddcVenRepRegistroVenta As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents ddcVenRepRegistro As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents ddcVenRepRegistroAuxiliar As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents ddcVenRepRegistroResumen As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents rbbTabServicios As Janus.Windows.Ribbon.RibbonTab
    Friend WithEvents rbbSerAlmacen As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnSerPedirRepuesto As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbTabAyuda As Janus.Windows.Ribbon.RibbonTab
    Friend WithEvents RibbonGroup2 As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnSolicitudUsuario As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents RibbonGroup3 As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnAyuda As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAcerca As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenRepDetalleDescuento As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbTabTabServicios As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnPlantillaRepuesto As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPlantillaRepuestoCliente As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAlmConDocumentos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenRepReclamos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbSerVentas As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnSerCotizacion As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbSerJob As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents rbbSerVehiculos As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents rbbSerReportes As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnSerSolicitudJob As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerJob As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerRepMovRepuesto As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbSerConsultas As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnSerConJob As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerMarcacionJob As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerRepHorasEscalon As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerRepHorasGenerales As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerConMarcacionJob As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreAprPerUsuario As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerConGastoRealJob As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerKilometraje As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAlmTraAnulacionGuia As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbTabCompras As Janus.Windows.Ribbon.RibbonTab
    Friend WithEvents rbbComCompras As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents rbbComConsultas As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents rbbComReportes As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnComSolicitud As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnComOrdenCompra As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerGastoReal As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerGastoViaje As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerRepCostosDirectos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerRepGastosPorRubro As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerRepGastosViajePorRubro As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerRepJobPendienteFacturacion As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerRepJobGarantias As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerRepTiempoReparacion As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbTabTabCompras As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnproveedores As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnComCotizacionSolicitud As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreManVincularGuias As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbTabContabilidad As Janus.Windows.Ribbon.RibbonTab
    Friend WithEvents rbbContaCompras As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents rbbComControl As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnComSolicitudGasto As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnComMesaControl As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreConTarjetaCliente As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCostoProInvRotativo As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbContaCajaChica As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnConProvisional As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnConReembolso As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbAdminUsuarios As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnAtencionSolicitud As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnConArqueoCaja As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbSerMantenimiento As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnSerManOficinaUsuario As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenRepOrdenes As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbContaReportes As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnConRepCtasPorPagar As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnConRepVencimientos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerPreMarcacionJob As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnComPlanillaViatico As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnConRepReembolso As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbSerGarantia As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnSerAfa As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnComConsultaCompras As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnComRepOrdenes As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenSepararOrden As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAlmManMinMax As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnComRepSolicitudGasto As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbAdminReportes As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnAdminIndicadorSolicitud As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAlmRepDocumento As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbAlmIndicadores As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnAlmIndCalendario As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAlmIndProcesoCobertura As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAlmIndTablero As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnComTarifa As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerRepAfas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreManFeriados As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnComTarifaCasa As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnComRepMesaControl As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbVenIndicadores As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnVenIndTablero As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerRepCotizaciones As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerRepSolicitudJob As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbContaTesoreria As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents rbbContaProcesos As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents rbbContaContabilidad As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnConTesoreria As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnConRegistroCompra As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnConDiario As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerRepJob As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnGerConsolidado As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbTabPersonal As Janus.Windows.Ribbon.RibbonTab
    Friend WithEvents rbbPerInformacion As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnPerInfDatos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbPerPlanilla As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnPerPlanilla As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAlmRepInvPermanente As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbTabTabContabilidad As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnManteCuentaContable As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbSerIndicadores As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnSerIndActividades As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnConProCuentaDestino As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerIndProgramacion As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerIndPlantilla As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnConProCierreMes As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbTabTabPersonal As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnManteRubroPlanilla As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnManteCuentaDestino As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnManteRubroPlanillaCuentas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents ddcConRepLibrosOficiales As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents btnConRepLibroDiario As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnConRepLibroMayor As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents btnConRepCajaBancos As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents btnConRepRegistroCompra As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents btnConProDifTipoCambio As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbPerReportes As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnPerRepPlanillaSueldos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnConRepCtasCtes As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnConRepCtasCtesPend As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenRepConsignacion As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenRepTodoGuiaRemision As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerIndTablero As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbVenPrecios As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnVenPreciosCliente As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAlmRepSinMovimiento As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenPreciosLista As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenPreciosOferta As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbPerAsignaciones As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnPerAsigFaltas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerAsigMarcas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerAsigHoraExtra As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerAsigHorario As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerInfVacaciones As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerInfContratos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerRegistroHoraExtra As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerAsigIngresos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerAsigDescuentos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnManteHorarios As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerAsigJefes As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerAsigRecursos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerRepAsistencia As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerRepAsignacionHoraExtra As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerRepHoraExtra As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerRepTardanzas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerRepFaltas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerRepIngresos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerRepDescuentos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerRepRecursos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerRepVacaciones As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerRepPersonal As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbPerComunicaciones As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnPerComAdminLector As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnManteFeriadoPersonal As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnManteAfp As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnManteCargos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnManteAreas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnManteMotFaltas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnManteEquipoLector As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnManteTipoHoraExtra As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnManteUbicaServicio As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerRepHorasMuertas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerInfCapacitacion As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerRepCapacitacion As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerRepContratos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnConRepMayorAuxiliar As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbAdminEncuestas As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnAdminEncuesta As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAdminResultadoEncuesta As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerIndProductividad As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerComProcesarMarcas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbSerProyeccion As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnSerProHorasMotor As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerProEquipos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnImpImpEmbarque As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnImpRepEmbarques As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnConRepEstadosFinancieros As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents ddcSerRepProyeccion As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents btnSerRepHorasMotores As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents btnSerProSeguimiento As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerRepDisponibilidad As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents TVEmerg As System.Windows.Forms.Timer
    Friend WithEvents btnConMovimientoBanco As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerRepMotorDarBaja As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents btnSerRepProyeccionRepImportar As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents btnSerRepProyeccionVentas As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents btnSerProRepuestos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnComTarifaDestino As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerRepOnomasticos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenRepPresupuestoVenta As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerRepSeguimientos As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents rbbTabRondas As Janus.Windows.Ribbon.RibbonTab
    Friend WithEvents rbbRondasAsignacion As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnPuntosControlRutas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbRondasReporte As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents rbbTabTabRondas As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnManteRuteador As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnManteRutas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnMantePuntosControl As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnRuteadorRutas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnRondas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnConRepChequesGirados As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAlmRepTransferencia As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCostoRepGMROI As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenEnvioCorreo As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreAprRecepcionDoc As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenDocResumen As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerRepProyeccionReparaciones As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents btnVenRepComisiones As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreManTipoCambio As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnGerEstadosFinancieros As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbTabTelefonia As Janus.Windows.Ribbon.RibbonTab
    Friend WithEvents rbbTelefoniaMante As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnTelModelos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbTelefoniaAsigna As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnTelLineas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbTelefoniaReporte As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnTelEquipos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnTelPlanes As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnTelAsignaLinea As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbAdminSoftware As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnAdminSoftwareAsignar As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAdminSoftwareComputadora As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbAdminLlamadas As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnAdminLlamadas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnImpRepPedido As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerProGenerarPedidoInterno As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbTabCRM As Janus.Windows.Ribbon.RibbonTab
    Friend WithEvents rbbCRMOportunidad As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnCRMOportIngresar As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbCRMReportes As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnCRMRepOportunidad As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCRMOcurrencias As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCRMTarjetaCliente As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCRMVisitas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCRMRepVisitas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerAsigCronogramaMina As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSesiones As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerRepCronogramaMina As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAlmManUbicacion As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCRMCuotas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAlmAlmDespacho As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerReclamoCliente As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerInfEvaluacion As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbTabActivos As Janus.Windows.Ribbon.RibbonTab
    Friend WithEvents rbbActivoDatos As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnActivoDatos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnLogueoEmpresas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCambiarEmpresa As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCerrarSesion As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreManRenuevaTC As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnConGenerarTXTLibros As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnConProFlujoCaja As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreMantenimientoTipoCambio As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerRepAsigHorario As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbAdminTablas As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnAdminEquiposMarcacion As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAdminEmpresas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAdminSeriesDocumentos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAdminLocaciones As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCreRepClientes As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnCondicionPagoProveedores As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnTabCondicionPagoCliente As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnTabManteVehiculos As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAdminRubros As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAdminParametrosLocacion As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAdminParametrosPlanilla As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAdminRubroEmpresa As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnComCuentasPorPagar As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnComRepVencimientosCtasPorPagar As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnComRepCtasPorPagar As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnComRepPagosCuentasPorPagar As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnComRepCtasPorPagarUnidad As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerQuintaCategoria As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnConReciboHonorario As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents rbbActivoReportes As Janus.Windows.Ribbon.RibbonGroup
    Friend WithEvents btnActivoReporte As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenPreciosFabricantes As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnVenPreciosRubrosEmpresa As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnConRepProvisionales As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAlmAlmDocumentoSalidas As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnAlmAlmDatosDespacho As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnSerMarcacionOT As Janus.Windows.Ribbon.ButtonCommand
    Friend WithEvents btnPerMarcaccionOnline As Janus.Windows.Ribbon.ButtonCommand
End Class
