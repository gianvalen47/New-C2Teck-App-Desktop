Imports System.Windows.Forms
Imports System.ServiceModel
Imports System.Linq

''VentanaEmergente
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports Janus.Windows.Ribbon

Public Class MDIPrincipal
    'Private oSeguridadService As New SeguridadService.SeguridadClient
    'Private oSeguridadServiceMensaje As New SeguridadService.SeguridadClient
    'Private oAprobarVentaService As New AprobarVentaService.AprobarVentaServiceClient
    Dim mdiChildForm As New Form
    Private Mensaje As String = ""

    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oSeguridadServiceMensaje As New SeguridadService.SeguridadClient
    Private oAprobarVentaService As New AprobarVentaService.AprobarVentaServiceClient


    Private Sub MDIPrincipal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        frmLogin.Close()
        'Cerrando el servicio del Mensaje Emergente

        '////////CERRAR SESION DEL USUARIO//////// 
        oSeguridadServiceMensaje.CerrarSesion(Session.sIdSesion)
        '///////////////////////////////////////////


        oSeguridadServiceMensaje.Close()
    End Sub



    Private Sub MostrarLogo()
        Select Case Session.sCodEmp
            Case "01"
                Me.BackgroundImage = Image.FromFile(My.Computer.FileSystem.CurrentDirectory + "\Logos\Logoddperu.png")
            Case "02"
                Me.BackgroundImage = Image.FromFile(My.Computer.FileSystem.CurrentDirectory + "\Logos\LogoAmazonica.png")
            Case "03"
                Me.BackgroundImage = Image.FromFile(My.Computer.FileSystem.CurrentDirectory + "\Logos\LogoCairo.jpg")
            Case "04"
                Me.BackgroundImage = Image.FromFile(My.Computer.FileSystem.CurrentDirectory + "\Logos\LogoJL.jpg")
            Case "05"
                Me.BackgroundImage = Image.FromFile(My.Computer.FileSystem.CurrentDirectory + "\Logos\LogoEquimap.png")
            Case "06"
                'Me.BackgroundImage = utils.ByteArrayToImage(Session.sLogo)
                Me.BackgroundImage = Image.FromFile(My.Computer.FileSystem.CurrentDirectory + "\Logos\LogoEryma.png")
            Case "07"
                Me.BackgroundImage = Image.FromFile(My.Computer.FileSystem.CurrentDirectory + "\Logos\LogoC2teck.png")
            Case "08"
                Me.BackgroundImage = Image.FromFile(My.Computer.FileSystem.CurrentDirectory + "\Logos\LogoC2teck02.png")
        End Select
    End Sub
    Private Sub MDIPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MostrarLogo()
        '////////INSERTAR SESION DEL USUARIO////////
        Dim sesion As New SeguridadService.Sesion
        Dim sistema As New SeguridadService.Sistema
        sistema.IdSistema = 1
        sesion.CodUsu = Session.sCodUsu
        sesion.Sistema = sistema
        sesion.NomPc = Session.sNomPc
        sesion.DirIp = Session.sDirIp
        sesion.Ubicacion = Nothing
        sesion.Observacion = Nothing

        Session.sIdSesion = oSeguridadService.InsertarSesion(sesion)
        '///////////////////////////////////////////

        CargarPerfil()

        VentanaOnomasticos()
        CerrarConexion()

        'VentanaNavidad()
        '================================================================      
        ' Set the IsMdiContainer property to true.
        IsMdiContainer = True
        ' Set the child form's MdiParent property to 
        ' the current form.
        mdiChildForm.MdiParent = Me
        'Call the method that changes the background color.
        SetBackGroundColorOfMDIForm()
        '================================================================
        'Notify Window   
        If Session.CodPerfil = "11" Or Session.CodPerfil = "12" Or Session.CodPerfil = "03" Or Session.CodPerfil = "04" Or Session.CodPerfil = "42" Or Session.CodPerfil = "05" Then   '------ Se agrega el Perfil de Costos 02/08/2016
            VentanaEmergente()
        End If



    End Sub

    '==========Cambiar de color el container========================
    Private Sub SetBackGroundColorOfMDIForm()
        Dim ctl As Control

        ' Loop through controls,  
        ' looking for controls of MdiClient type. 
        For Each ctl In Me.Controls
            If TypeOf (ctl) Is MdiClient Then

                ' If the control is the correct type,
                ' change the color.
                ctl.BackColor = System.Drawing.Color.LightGray
            End If
        Next

    End Sub

    Private Sub CerrarConexion()
        Try
            oSeguridadService.Close()
            oAprobarVentaService.Close()

        Catch ex As TimeoutException
            oSeguridadService.Abort()
            oAprobarVentaService.Abort()
        Catch ex As CommunicationException
            oSeguridadService.Abort()
            oAprobarVentaService.Abort()
        End Try

        'Me.Dispose(True)
        ' GC.SuppressFinalize(Me)
    End Sub

    Private Sub DesactivarMenu()
        '////////Menu de Almacen/////////////
        btnAlmAlmDocumentos.Visible = False
        btnAlmAlmDocumentoSalidas.Visible = False
        btnAlmAlmTI.Visible = False
        btnAlmAlmValesMate.Visible = False
        btnAlmAlmMTI.Visible = False
        btnAlmAlmChequeoFI.Visible = False
        btnAlmMotTransferencias.Visible = False
        btnAlmMotCompras.Visible = False
        btnAlmTraDocumentos.Visible = False
        btnAlmManMercaderias.Visible = False
        btnAlmManLiquiGastos.Visible = False
        btnAlmConTarjetas.Visible = False
        btnAlmRepInventario.Visible = False
        btnAlmRepTomaInventario.Visible = False
        btnAlmRepMovimientos.Visible = False
        btnAlmRepValeMaterial.Visible = False
        btnAlmAlmAtenderJob.Visible = False
        btnAlmConDocumentos.Visible = False
        btnAlmTraAnulacionGuia.Visible = False
        btnAlmManMinMax.Visible = False
        btnAlmRepDocumento.Visible = False
        btnAlmIndCalendario.Visible = False
        btnAlmIndProcesoCobertura.Visible = False
        btnAlmIndTablero.Visible = False
        btnAlmRepInvPermanente.Visible = False
        btnAlmRepSinMovimiento.Visible = False
        btnAlmRepTransferencia.Visible = False
        btnAlmManUbicacion.Visible = False
        btnAlmAlmDespacho.Visible = False
        btnAlmAlmDatosDespacho.Visible = False

        rbbAlmAlmacen.Visible = False
        rbbAlmMotores.Visible = False
        rbbAlmTransito.Visible = False
        rbbAlmMantenimiento.Visible = False
        rbbAlmConsultas.Visible = False
        rbbAlmReportes.Visible = False
        rbbAlmIndicadores.Visible = False
        '////////////////////////////////////

        '////////Menu de Ventas/////////////
        btnVenDocGuiasRemision.Visible = False
        btnVenDocFacturas.Visible = False
        btnVenDocBoletas.Visible = False
        btnVenDocGuiasDevolucion.Visible = False
        btnVenDocNotas.Visible = False
        btnVenPreCotizaciones.Visible = False
        btnVenPreOrdenesCompra.Visible = False
        btnVenReclamo.Visible = False
        btnVenCliCartera.Visible = False
        btnVenReqDespachos.Visible = False
        btnVenConPrecios.Visible = False
        ddcVenRepRegistro.Visible = False
        ddcVenRepRegistroAuxiliar.Visible = False
        ddcVenRepRegistroResumen.Visible = False
        btnVenRepVentaDetalle.Visible = False
        btnVenRepVentaAcumulada.Visible = False
        btnVenRepVentaGuias.Visible = False
        btnVenRepCotizaciones.Visible = False
        btnVenConDocumentos.Visible = False
        btnVenPostActuVendedor.Visible = False
        btnVenRepVentaRequisiciones.Visible = False
        btnVenRepMensualesxCliente.Visible = False
        btnVenRepDetalleDescuento.Visible = False
        btnVenRepReclamos.Visible = False
        btnVenRepOrdenes.Visible = False
        btnVenSepararOrden.Visible = False
        btnVenIndTablero.Visible = False
        btnVenRepConsignacion.Visible = False
        btnVenRepTodoGuiaRemision.Visible = False
        btnVenPreciosCliente.Visible = False
        btnVenPreciosLista.Visible = False
        btnVenPreciosOferta.Visible = False
        btnVenPreciosFabricantes.Visible = False
        btnVenRepPresupuestoVenta.Visible = False
        btnVenEnvioCorreo.Visible = False
        btnVenDocResumen.Visible = False
        btnVenRepComisiones.Visible = False
        btnVenPreciosRubrosEmpresa.Visible = False

        rbbVenDocumentos.Visible = False
        rbbVenRequisiciones.Visible = False
        rbbVenConsultas.Visible = False
        rbbVenPrePostVenta.Visible = False
        rbbVenClientes.Visible = False
        rbbVenReportes.Visible = False
        ddcVenRepRegistroVenta.Visible = False
        rbbVenIndicadores.Visible = False
        rbbVenPrecios.Visible = False
        '////////////////////////////////////

        '////////Menu de Creditos y Cobranzas/////////////
        btnCreDocCuentas.Visible = False
        btnCreDocPlanillas.Visible = False
        btnCreDocAnticipos.Visible = False
        btnCreDocLetras.Visible = False
        btnCreAprCreditos.Visible = False
        btnCreAprCotizaciones.Visible = False
        btnCreManFacDesc.Visible = False
        btnCreManBancos.Visible = False
        btnCreConCuentas.Visible = False
        btnCreConVencimientos.Visible = False
        btnCreRepCtasCtes.Visible = False
        btnCreRepDiarioPago.Visible = False
        btnCreRepDocEmitido.Visible = False
        btnCreRepLetra.Visible = False
        btnCreRepNotasDebito.Visible = False
        ddcCreRepVencimientoDetalle.Visible = False
        ddcCreRepVencimientoAcumulado.Visible = False
        btnCreRepPlanilla.Visible = False
        btnCreManVisitaCobrador.Visible = False
        btnCreRepVisitaCobrador.Visible = False
        btnCreManProcesarGuias.Visible = False
        btnCreManVincularGuias.Visible = False
        btnCreManFeriados.Visible = False
        btnCreAprRecepcionDoc.Visible = False
        btnCreManRenuevaTC.Visible = False
        btnCreMantenimientoTipoCambio.Visible = False
        btnCreRepClientes.Visible = False

        rbbCreDocumentos.Visible = False
        rbbCreAprobaciones.Visible = False
        rbbCreConsultas.Visible = False
        rbbCreMantenimiento.Visible = False
        rbbCreReportes.Visible = False
        ddcCreRepVencimientos.Visible = False
        btnCreAprPerUsuario.Visible = False
        btnCreConTarjetaCliente.Visible = False
        btnCreManTipoCambio.Visible = False
        '/////////////////////////////////////////////////

        '///////////Menu de Importaciones///////////////
        btnImpImpDocumentos.Visible = False
        btnImpPedImportacion.Visible = False
        btnImpPedInternos.Visible = False
        btnImpRepPedidoImp.Visible = False
        btnImpImpEmbarque.Visible = False
        btnImpRepEmbarques.Visible = False
        btnImpRepPedido.Visible = False

        rbbImpImportaciones.Visible = False
        rbbImpPedidos.Visible = False
        rbbImpConsultas.Visible = False
        rbbImpReportes.Visible = False
        '///////////////////////////////////////////////

        '///////////Menu de Costos///////////////
        btnCostoValorizarImp.Visible = False
        btnCostoRecalcular.Visible = False
        btnCostoAjustarCierre.Visible = False
        btnCostoCerrarMes.Visible = False
        btnCostoConsolidado.Visible = False
        btnCostoActualizarDocs.Visible = False
        btnCostoRepImportaciones.Visible = False
        btnCostoDiarioAlmacen.Visible = False
        btnCostoStockValorizado.Visible = False
        btnCostoRepCierreMes.Visible = False
        btnCostoRepKardex.Visible = False
        btnCostoRepCostoVenta.Visible = False
        btnCostoProTrasladarCosto.Visible = False
        btnCostoProGenerarPeriodo.Visible = False
        btnCostoRepCondensado.Visible = False
        btnCostoRepMotores.Visible = False
        btnCostoRepResumenGen.Visible = False
        btnCostoRepSobregiro.Visible = False
        btnCostoProInvRotativo.Visible = False
        btnCostoRepGMROI.Visible = False

        rbbCostoImportaciones.Visible = False
        rbbCostoDocumentos.Visible = False
        rbbCostoProcesos.Visible = False
        rbbCostoReportes.Visible = False
        '////////////////////////////////////////

        '///////////Menu de Tablas///////////////
        btnTabVenClientes.Visible = False
        btnTabAlmMercaderias.Visible = False
        btnTabAlmModelos.Visible = False
        btnTabAlmTipoMotores.Visible = False
        btnTabImpMarcas.Visible = False
        btnTabImpPartidas.Visible = False
        btnTabAlmClases.Visible = False
        btnTabAlmPreciosCore.Visible = False
        btnPlantillaRepuesto.Visible = False
        btnPlantillaRepuestoCliente.Visible = False
        btnproveedores.Visible = False
        btnManteCuentaContable.Visible = False
        btnManteRubroPlanilla.Visible = False
        btnManteCuentaDestino.Visible = False
        btnManteRubroPlanillaCuentas.Visible = False
        btnManteHorarios.Visible = False
        btnManteFeriadoPersonal.Visible = False
        btnManteAfp.Visible = False
        btnManteCargos.Visible = False
        btnManteAreas.Visible = False
        btnManteTipoHoraExtra.Visible = False
        btnManteEquipoLector.Visible = False
        btnManteMotFaltas.Visible = False
        btnManteRuteador.Visible = False
        btnManteRutas.Visible = False
        btnMantePuntosControl.Visible = False
        btnTabCondicionPagoCliente.Visible = False
        btnCondicionPagoProveedores.Visible = False
        btnTabManteVehiculos.Visible = False


        rbbTabTabVentas.Visible = False
        rbbTabTabAlmacen.Visible = False
        rbbTabTabImportacion.Visible = False
        rbbTabTabServicios.Visible = False
        rbbTabTabCompras.Visible = False
        rbbTabTabContabilidad.Visible = False
        rbbTabTabPersonal.Visible = False
        rbbTabTabRondas.Visible = False
        '////////////////////////////////////////

        '///////////Menu de Administracion///////////////
        btnUsuarios.Visible = False
        btnPerfiles.Visible = False
        btnAtencionSolicitud.Visible = False
        rbbAdminSeguridad.Visible = False
        rbbAdminUsuarios.Visible = False
        rbbAdminReportes.Visible = False
        btnAdminIndicadorSolicitud.Visible = False
        rbbAdminEncuestas.Visible = False
        rbbAdminSoftware.Visible = False
        rbbAdminLlamadas.Visible = False
        rbbAdminTablas.Visible = False
        btnAdminEncuesta.Visible = False
        btnAdminResultadoEncuesta.Visible = False
        btnAdminSoftwareAsignar.Visible = False
        btnAdminSoftwareComputadora.Visible = False
        btnAdminLlamadas.Visible = False
        btnSesiones.Visible = False
        btnAdminEquiposMarcacion.Visible = False
        btnAdminEmpresas.Visible = False
        btnAdminSeriesDocumentos.Visible = False
        btnAdminLocaciones.Visible = False
        btnAdminRubros.Visible = False
        btnAdminParametrosLocacion.Visible = False
        btnAdminParametrosPlanilla.Visible = False
        btnAdminRubroEmpresa.Visible = False
        '////////////////////////////////////////////////

        '///////////Menu de Gerencia///////////////
        rbbTabGerencia.Visible = False
        rbbGerReportes.Visible = False
        btnGerCreditos.Visible = False
        btnGerImportaciones.Visible = False
        btnGerInventario.Visible = False
        btnGerServicios.Visible = False
        btnGerVentas.Visible = False
        btnGerFiltroIndicadores.Visible = False
        btnGerTarjeta.Visible = False
        btnGerContabilidad.Visible = False
        btnGerConsolidado.Visible = False
        btnGerEstadosFinancieros.Visible = False
        '////////////////////////////////////////


        '///////////Menu de Servicios///////////////
        rbbTabServicios.Visible = False
        rbbSerAlmacen.Visible = False
        rbbSerVentas.Visible = False
        rbbSerJob.Visible = False
        rbbSerVehiculos.Visible = False
        rbbSerReportes.Visible = False
        rbbSerConsultas.Visible = False
        rbbSerMantenimiento.Visible = False
        rbbSerGarantia.Visible = False
        rbbSerIndicadores.Visible = False
        rbbSerProyeccion.Visible = False
        btnSerPedirRepuesto.Visible = False
        btnSerCotizacion.Visible = False
        btnSerSolicitudJob.Visible = False
        btnSerJob.Visible = False
        btnSerRepMovRepuesto.Visible = False
        btnSerConJob.Visible = False
        btnSerMarcacionJob.Visible = False
        btnSerRepHorasEscalon.Visible = False
        btnSerRepHorasGenerales.Visible = False
        btnSerConMarcacionJob.Visible = False
        btnSerConGastoRealJob.Visible = False
        btnSerKilometraje.Visible = False
        btnSerGastoReal.Visible = False
        btnSerGastoViaje.Visible = False
        btnSerRepCostosDirectos.Visible = False
        btnSerRepGastosPorRubro.Visible = False
        btnSerRepJobPendienteFacturacion.Visible = False
        btnSerRepJobGarantias.Visible = False
        btnSerRepTiempoReparacion.Visible = False
        btnSerRepGastosViajePorRubro.Visible = False
        btnSerManOficinaUsuario.Visible = False
        btnSerPreMarcacionJob.Visible = False
        btnSerAfa.Visible = False
        btnSerRepAfas.Visible = False
        btnSerRepCotizaciones.Visible = False
        btnSerRepSolicitudJob.Visible = False
        btnSerRepJob.Visible = False
        btnSerIndActividades.Visible = False
        btnSerIndProgramacion.Visible = False
        btnSerIndPlantilla.Visible = False
        btnSerIndTablero.Visible = False
        btnManteUbicaServicio.Visible = False
        btnSerRepHorasMuertas.Visible = False
        btnSerIndProductividad.Visible = False
        btnSerProHorasMotor.Visible = False
        btnSerProEquipos.Visible = False
        btnSerRepHorasMotores.Visible = False
        ddcSerRepProyeccion.Visible = False
        btnSerProSeguimiento.Visible = False
        btnSerRepDisponibilidad.Visible = False
        btnSerRepMotorDarBaja.Visible = False
        btnSerRepProyeccionRepImportar.Visible = False
        btnSerRepProyeccionVentas.Visible = False
        btnSerProRepuestos.Visible = False
        btnSerRepSeguimientos.Visible = False
        btnSerRepProyeccionReparaciones.Visible = False
        btnSerProGenerarPedidoInterno.Visible = False
        btnSerReclamoCliente.Visible = False
        btnSerMarcacionOT.Visible = False
        '////////////////////////////////////////

        '////////////Menu de Compras/////////////
        rbbTabCompras.Visible = False
        rbbComCompras.Visible = False
        rbbComConsultas.Visible = False
        rbbComReportes.Visible = False
        rbbComControl.Visible = False
        btnComSolicitud.Visible = False
        btnComOrdenCompra.Visible = False
        btnComCotizacionSolicitud.Visible = False
        btnComSolicitudGasto.Visible = False
        btnComMesaControl.Visible = False
        btnComPlanillaViatico.Visible = False
        btnComConsultaCompras.Visible = False
        btnComRepOrdenes.Visible = False
        btnComRepSolicitudGasto.Visible = False
        btnComTarifa.Visible = False
        btnComTarifaCasa.Visible = False
        btnComRepMesaControl.Visible = False
        btnComTarifaDestino.Visible = False
        btnComCuentasPorPagar.Visible = False
        btnComRepCtasPorPagar.Visible = False
        btnComRepVencimientosCtasPorPagar.Visible = False
        btnComRepPagosCuentasPorPagar.Visible = False
        btnComRepCtasPorPagarUnidad.Visible = False
        '////////////////////////////////////////

        '////////////Menu de Contabilidad/////////////
        rbbTabContabilidad.Visible = False
        rbbContaCompras.Visible = False
        rbbContaCajaChica.Visible = False
        rbbContaReportes.Visible = False
        rbbContaTesoreria.Visible = False
        rbbContaContabilidad.Visible = False
        rbbContaProcesos.Visible = False
        ddcConRepLibrosOficiales.Visible = False
        'btnConCtasPorPagar.Visible = False
        btnConReciboHonorario.Visible = False
        btnConProvisional.Visible = False
        btnConReembolso.Visible = False
        btnConArqueoCaja.Visible = False
        btnConRepCtasPorPagar.Visible = False
        btnConRepVencimientos.Visible = False
        btnConRepReembolso.Visible = False
        btnConTesoreria.Visible = False
        btnConRegistroCompra.Visible = False
        btnConDiario.Visible = False
        btnConRepRegistroCompra.Visible = False
        btnConProCuentaDestino.Visible = False
        btnConProCierreMes.Visible = False
        btnConRepLibroDiario.Visible = False
        btnConRepLibroMayor.Visible = False
        btnConRepEstadosFinancieros.Visible = False
        btnConRepCajaBancos.Visible = False
        btnConProDifTipoCambio.Visible = False
        btnConRepCtasCtes.Visible = False
        btnConRepCtasCtesPend.Visible = False
        btnConRepMayorAuxiliar.Visible = False
        btnConMovimientoBanco.Visible = False
        btnConRepChequesGirados.Visible = False
        btnConGenerarTXTLibros.Visible = False
        btnConProFlujoCaja.Visible = False
        btnConRepProvisionales.Visible = False
        '/////////////////////////////////////////////


        '///////PERSONAL//////////
        rbbTabPersonal.Visible = False
        rbbPerInformacion.Visible = False
        rbbPerReportes.Visible = False
        rbbPerAsignaciones.Visible = False
        rbbPerComunicaciones.Visible = False
        btnPerInfDatos.Visible = False
        rbbPerPlanilla.Visible = False
        btnPerPlanilla.Visible = False
        btnPerRepPlanillaSueldos.Visible = False
        btnPerAsigFaltas.Visible = False
        btnPerAsigDescuentos.Visible = False
        btnPerAsigHoraExtra.Visible = False
        btnPerRegistroHoraExtra.Visible = False
        btnPerAsigHorario.Visible = False
        btnPerAsigIngresos.Visible = False
        btnPerAsigMarcas.Visible = False
        btnPerInfContratos.Visible = False
        btnPerInfVacaciones.Visible = False
        btnPerAsigDescuentos.Visible = False
        btnPerAsigJefes.Visible = False
        btnPerAsigRecursos.Visible = False
        btnPerAsigHorario.Visible = False
        btnPerAsigIngresos.Visible = False
        btnPerRepAsistencia.Visible = False
        btnPerRepTardanzas.Visible = False
        btnPerRepAsignacionHoraExtra.Visible = False
        btnPerRepHoraExtra.Visible = False
        btnPerRepFaltas.Visible = False
        btnPerRepDescuentos.Visible = False
        btnPerRepIngresos.Visible = False
        btnPerRepPersonal.Visible = False
        btnPerRepRecursos.Visible = False
        btnPerRepVacaciones.Visible = False
        btnPerComAdminLector.Visible = False
        btnPerInfCapacitacion.Visible = False
        btnPerRepCapacitacion.Visible = False
        btnPerRepContratos.Visible = False
        btnPerComProcesarMarcas.Visible = False
        btnPerRepOnomasticos.Visible = False
        btnPerAsigCronogramaMina.Visible = False
        btnPerRepCronogramaMina.Visible = False
        btnPerInfEvaluacion.Visible = False
        btnPerRepAsigHorario.Visible = False
        btnPerQuintaCategoria.Visible = False
        btnPerMarcaccionOnline.Visible = False
        '/////////////////////////

        '////////////////RONDAS///////////////////
        rbbTabRondas.Visible = False
        rbbRondasAsignacion.Visible = False
        rbbRondasReporte.Visible = False
        btnPuntosControlRutas.Visible = False
        btnRuteadorRutas.Visible = False


        '//////////TELEFONIA//////////////
        rbbTabTelefonia.Visible = False
        rbbTelefoniaMante.Visible = False
        rbbTelefoniaAsigna.Visible = False
        rbbTelefoniaReporte.Visible = False
        btnTelEquipos.Visible = False
        btnTelAsignaLinea.Visible = False
        btnTelLineas.Visible = False
        btnTelModelos.Visible = False
        btnTelPlanes.Visible = False
        '/////////////////////////////////


        '////////////CRM///////////////
        rbbTabCRM.Visible = False
        rbbCRMOportunidad.Visible = False
        rbbCRMReportes.Visible = False
        btnCRMOportIngresar.Visible = False
        btnCRMRepOportunidad.Visible = False
        btnCRMOcurrencias.Visible = False
        btnCRMTarjetaCliente.Visible = False
        btnCRMVisitas.Visible = False
        btnCRMRepVisitas.Visible = False
        btnCRMCuotas.Visible = False
        '//////////////////////////////


        '////////////ACTIVOS/////////////
        rbbTabActivos.Visible = False
        rbbActivoDatos.Visible = False
        btnActivoDatos.Visible = False
        rbbActivoReportes.Visible = False
        btnActivoReporte.Visible = False
        '///////////////////////////////


    End Sub

    Private Sub ActivarMenu()

        Dim oSeguridadService As New SeguridadService.SeguridadClient

        Me.Text = Datos.TituloSistema

        DesactivarMenu()
        Dim dtMenus As New DataTable
        Dim dtOpciones As New DataTable
        dtMenus = oSeguridadService.MostrarMenuSistema.Tables(0)
        Dim ActMenu As Boolean
        For Each Fila As DataRow In dtMenus.Rows
            dtOpciones = oSeguridadService.MostrarPerfilOpciones(Session.CodPerfil, Fila.Item("IdMenu"), Session.sCodEmp).Tables(0)
            ActMenu = False
            For Each FilaOpc As DataRow In dtOpciones.Rows

                '////////Menu de Almacen/////////////
                Select Case FilaOpc.Item("IdOpcion")
                    Case 1
                        rbbAlmAlmacen.Visible = True
                        btnAlmAlmDocumentos.Visible = True
                        btnAlmAlmDocumentoSalidas.Visible = True
                    Case 2
                        rbbAlmAlmacen.Visible = True
                        btnAlmAlmTI.Visible = True
                    Case 3
                        rbbAlmAlmacen.Visible = True
                        btnAlmAlmValesMate.Visible = True
                    Case 4
                        rbbAlmAlmacen.Visible = True
                        btnAlmAlmMTI.Visible = True
                    Case 5
                        rbbAlmAlmacen.Visible = True
                        btnAlmAlmChequeoFI.Visible = True
                    Case 6
                        rbbAlmMotores.Visible = True
                        btnAlmMotTransferencias.Visible = True
                    Case 7
                        rbbAlmMotores.Visible = True
                        btnAlmMotCompras.Visible = True
                    Case 8
                        rbbAlmTransito.Visible = True
                        btnAlmTraDocumentos.Visible = True
                    Case 9
                        rbbAlmMantenimiento.Visible = True
                        btnAlmManMercaderias.Visible = True
                    Case 10
                        rbbAlmMantenimiento.Visible = True
                        btnAlmManLiquiGastos.Visible = True
                    Case 11
                        rbbAlmConsultas.Visible = True
                        btnAlmConTarjetas.Visible = True
                    Case 12
                        rbbAlmReportes.Visible = True
                        btnAlmRepInventario.Visible = True
                    Case 13
                        rbbAlmReportes.Visible = True
                        btnAlmRepTomaInventario.Visible = True
                    Case 14
                        rbbAlmReportes.Visible = True
                        btnAlmRepMovimientos.Visible = True
                    Case 15
                        rbbAlmReportes.Visible = True
                        btnAlmRepValeMaterial.Visible = True
                    Case 76
                        rbbAlmAlmacen.Visible = True
                        btnAlmAlmAtenderJob.Visible = True
                    Case 106
                        rbbAlmConsultas.Visible = True
                        btnAlmConDocumentos.Visible = True
                    Case 132
                        rbbAlmTransito.Visible = True
                        btnAlmTraAnulacionGuia.Visible = True
                    Case 156
                        rbbAlmMantenimiento.Visible = True
                        btnAlmManMinMax.Visible = True
                    Case 160
                        rbbAlmReportes.Visible = True
                        btnAlmRepDocumento.Visible = True
                    Case 161
                        rbbAlmIndicadores.Visible = True
                        btnAlmIndCalendario.Visible = True
                    Case 162
                        rbbAlmIndicadores.Visible = True
                        btnAlmIndProcesoCobertura.Visible = True
                    Case 163
                        rbbAlmIndicadores.Visible = True
                        btnAlmIndTablero.Visible = True
                    Case 180
                        rbbAlmReportes.Visible = True
                        btnAlmRepInvPermanente.Visible = True
                    Case 203
                        rbbAlmReportes.Visible = True
                        btnAlmRepSinMovimiento.Visible = True
                    Case 269
                        rbbAlmReportes.Visible = True
                        btnAlmRepTransferencia.Visible = True
                    Case 298
                        rbbAlmMantenimiento.Visible = True
                        btnAlmManUbicacion.Visible = True
                    Case 300
                        rbbAlmAlmacen.Visible = True
                        btnAlmAlmDespacho.Visible = True
                    Case 329
                        rbbAlmAlmacen.Visible = True
                        btnAlmAlmDatosDespacho.Visible = True
                End Select
                '////////////////////////////////////

                '////////Menu de Ventas/////////////
                Select Case FilaOpc.Item("IdOpcion")
                    Case 16
                        rbbVenDocumentos.Visible = True
                        btnVenDocGuiasRemision.Visible = True
                    Case 17
                        rbbVenDocumentos.Visible = True
                        btnVenDocFacturas.Visible = True
                    Case 18
                        rbbVenDocumentos.Visible = True
                        btnVenDocBoletas.Visible = True
                    Case 19
                        rbbVenDocumentos.Visible = True
                        btnVenDocGuiasDevolucion.Visible = True
                    Case 20
                        rbbVenDocumentos.Visible = True
                        btnVenDocNotas.Visible = True
                    Case 21
                        rbbVenPrePostVenta.Visible = True
                        btnVenPreCotizaciones.Visible = True
                    Case 22
                        rbbVenPrePostVenta.Visible = True
                        btnVenPreOrdenesCompra.Visible = True
                    Case 23
                        rbbVenPrePostVenta.Visible = True
                        btnVenReclamo.Visible = True
                    Case 24
                        btnVenCliCartera.Visible = True
                        rbbVenClientes.Visible = True

                    Case 27
                        btnVenReqDespachos.Visible = True
                        rbbVenRequisiciones.Visible = True
                    Case 28
                        rbbVenConsultas.Visible = True
                        btnVenConPrecios.Visible = True
                    Case 29
                        rbbVenReportes.Visible = True
                        ddcVenRepRegistroVenta.Visible = True
                        ddcVenRepRegistro.Visible = True
                    Case 30
                        rbbVenReportes.Visible = True
                        ddcVenRepRegistroVenta.Visible = True
                        ddcVenRepRegistroAuxiliar.Visible = True
                    Case 31
                        rbbVenReportes.Visible = True
                        ddcVenRepRegistroVenta.Visible = True
                        ddcVenRepRegistroResumen.Visible = True
                    Case 32
                        rbbVenReportes.Visible = True
                        btnVenRepVentaDetalle.Visible = True
                    Case 33
                        rbbVenReportes.Visible = True
                        btnVenRepVentaAcumulada.Visible = True
                    Case 34
                        rbbVenReportes.Visible = True
                        btnVenRepVentaGuias.Visible = True
                    Case 77
                        btnVenRepCotizaciones.Visible = True
                        rbbVenReportes.Visible = True
                    Case 78
                        rbbVenConsultas.Visible = True
                        btnVenConDocumentos.Visible = True
                    Case 79
                        rbbVenPrePostVenta.Visible = True
                        btnVenPostActuVendedor.Visible = True
                    Case 85
                        rbbVenReportes.Visible = True
                        btnVenRepVentaRequisiciones.Visible = True
                    Case 96
                        rbbVenReportes.Visible = True
                        btnVenRepMensualesxCliente.Visible = True
                    Case 103
                        rbbVenReportes.Visible = True
                        btnVenRepDetalleDescuento.Visible = True
                    Case 107
                        rbbVenReportes.Visible = True
                        btnVenRepReclamos.Visible = True
                    Case 146
                        rbbVenReportes.Visible = True
                        btnVenRepOrdenes.Visible = True
                    Case 155
                        rbbVenPrePostVenta.Visible = True
                        btnVenSepararOrden.Visible = True
                    Case 169
                        rbbVenIndicadores.Visible = True
                        btnVenIndTablero.Visible = True
                    Case 199
                        rbbVenReportes.Visible = True
                        btnVenRepTodoGuiaRemision.Visible = True
                    Case 200
                        rbbVenReportes.Visible = True
                        btnVenRepConsignacion.Visible = True
                    Case 202
                        rbbVenPrecios.Visible = True
                        btnVenPreciosCliente.Visible = True
                    Case 204
                        rbbVenPrecios.Visible = True
                        btnVenPreciosLista.Visible = True
                    Case 205
                        rbbVenPrecios.Visible = True
                        btnVenPreciosOferta.Visible = True
                    Case 260
                        rbbVenReportes.Visible = True
                        btnVenRepPresupuestoVenta.Visible = True
                    Case 272
                        rbbVenPrePostVenta.Visible = True
                        btnVenEnvioCorreo.Visible = True
                    Case 274
                        rbbVenDocumentos.Visible = True
                        btnVenDocResumen.Visible = True
                    Case 277
                        rbbVenReportes.Visible = True
                        btnVenRepComisiones.Visible = True
                    Case 326
                        rbbVenPrecios.Visible = True
                        btnVenPreciosFabricantes.Visible = True
                    Case 327
                        rbbVenPrecios.Visible = True
                        btnVenPreciosRubrosEmpresa.Visible = True

                End Select
                '////////////////////////////////////

                '////////Menu de Creditos y Cobranzas/////////////
                Select Case FilaOpc.Item("IdOpcion")
                    Case 35
                        rbbCreDocumentos.Visible = True
                        btnCreDocCuentas.Visible = True
                    Case 36
                        rbbCreDocumentos.Visible = True
                        btnCreDocPlanillas.Visible = True
                    Case 37
                        rbbCreDocumentos.Visible = True
                        btnCreDocAnticipos.Visible = True
                    Case 38
                        rbbCreDocumentos.Visible = True
                        btnCreDocLetras.Visible = True
                    Case 39
                        rbbCreAprobaciones.Visible = True
                        btnCreAprCreditos.Visible = True
                    Case 40
                        rbbCreAprobaciones.Visible = True
                        btnCreAprCotizaciones.Visible = True
                    Case 41
                        rbbCreMantenimiento.Visible = True
                        btnCreManFacDesc.Visible = True
                    Case 42
                        rbbCreMantenimiento.Visible = True
                        btnCreManBancos.Visible = True
                    Case 43
                        rbbCreConsultas.Visible = True
                        btnCreConCuentas.Visible = True
                    Case 44
                        rbbCreConsultas.Visible = True
                        btnCreConVencimientos.Visible = True
                    Case 45
                        rbbCreReportes.Visible = True
                        btnCreRepCtasCtes.Visible = True
                    Case 46
                        rbbCreReportes.Visible = True
                        btnCreRepDiarioPago.Visible = True
                    Case 47
                        rbbCreReportes.Visible = True
                        btnCreRepDocEmitido.Visible = True
                    Case 48
                        rbbCreReportes.Visible = True
                        btnCreRepLetra.Visible = True
                    Case 49
                        rbbCreReportes.Visible = True
                        btnCreRepNotasDebito.Visible = True
                    Case 50
                        rbbCreReportes.Visible = True
                        ddcCreRepVencimientos.Visible = True
                        ddcCreRepVencimientoDetalle.Visible = True
                    Case 51
                        rbbCreReportes.Visible = True
                        btnCreRepPlanilla.Visible = True
                    Case 80
                        rbbCreMantenimiento.Visible = True
                        btnCreManVisitaCobrador.Visible = True
                    Case 81
                        rbbCreMantenimiento.Visible = True
                        btnCreRepVisitaCobrador.Visible = True
                    Case 87
                        rbbCreMantenimiento.Visible = True
                        btnCreManProcesarGuias.Visible = True
                    Case 95
                        rbbCreReportes.Visible = True
                        ddcCreRepVencimientos.Visible = True
                        ddcCreRepVencimientoAcumulado.Visible = True
                    Case 128
                        rbbCreAprobaciones.Visible = True
                        btnCreAprPerUsuario.Visible = True
                    Case 135
                        rbbCreMantenimiento.Visible = True
                        btnCreManVincularGuias.Visible = True
                    Case 139
                        rbbCreConsultas.Visible = True
                        btnCreConTarjetaCliente.Visible = True
                    Case 166
                        rbbCreMantenimiento.Visible = True
                        btnCreManFeriados.Visible = True
                    Case 273
                        rbbCreAprobaciones.Visible = True
                        btnCreAprRecepcionDoc.Visible = True
                    Case 278
                        rbbCreMantenimiento.Visible = True
                        btnCreManTipoCambio.Visible = True
                    Case 304
                        rbbCreMantenimiento.Visible = True
                        btnCreManRenuevaTC.Visible = True
                    Case 307
                        rbbCreMantenimiento.Visible = True
                        btnCreMantenimientoTipoCambio.Visible = True
                    Case 313
                        rbbCreReportes.Visible = True
                        btnCreRepClientes.Visible = True

                End Select
                '////////////////////////////////////

                '///////////Menu de Importaciones///////////////
                Select Case FilaOpc.Item("IdOpcion")
                    Case 52
                        rbbImpImportaciones.Visible = True
                        btnImpImpDocumentos.Visible = True
                    Case 53
                        rbbImpPedidos.Visible = True
                        btnImpPedInternos.Visible = True
                    Case 54
                        rbbImpPedidos.Visible = True
                        btnImpPedImportacion.Visible = True
                    Case 86
                        rbbImpReportes.Visible = True
                        btnImpRepPedidoImp.Visible = True
                    Case 248
                        rbbImpImportaciones.Visible = True
                        btnImpImpEmbarque.Visible = True
                    Case 249
                        rbbImpReportes.Visible = True
                        btnImpRepEmbarques.Visible = True
                    Case 289
                        rbbImpReportes.Visible = True
                        btnImpRepPedido.Visible = True
                End Select
                '///////////////////////////////////////////////

                '///////////Menu de Costos///////////////
                Select Case FilaOpc.Item("IdOpcion")
                    Case 55
                        rbbCostoImportaciones.Visible = True
                        btnCostoValorizarImp.Visible = True
                    Case 56
                        rbbCostoProcesos.Visible = True
                        btnCostoRecalcular.Visible = True
                    Case 57
                        rbbCostoProcesos.Visible = True
                        btnCostoAjustarCierre.Visible = True
                    Case 58
                        rbbCostoProcesos.Visible = True
                        btnCostoCerrarMes.Visible = True
                    Case 59
                        rbbCostoProcesos.Visible = True
                        btnCostoConsolidado.Visible = True
                    Case 60
                        rbbCostoDocumentos.Visible = True
                        btnCostoActualizarDocs.Visible = True
                    Case 61
                        rbbCostoReportes.Visible = True
                        btnCostoRepImportaciones.Visible = True
                    Case 62
                        rbbCostoReportes.Visible = True
                        btnCostoDiarioAlmacen.Visible = True
                    Case 63
                        rbbCostoReportes.Visible = True
                        btnCostoStockValorizado.Visible = True
                    Case 64
                        rbbCostoReportes.Visible = True
                        btnCostoRepCierreMes.Visible = True
                    Case 65
                        rbbCostoReportes.Visible = True
                        btnCostoRepKardex.Visible = True
                    Case 66
                        rbbCostoReportes.Visible = True
                        btnCostoRepCostoVenta.Visible = True
                    Case 67
                        rbbCostoReportes.Visible = True
                        btnCostoRepCondensado.Visible = True
                    Case 82
                        rbbCostoProcesos.Visible = True
                        btnCostoProTrasladarCosto.Visible = True
                    Case 83
                        rbbCostoProcesos.Visible = True
                        btnCostoProGenerarPeriodo.Visible = True
                    Case 84
                        rbbCostoReportes.Visible = True
                        btnCostoRepMotores.Visible = True
                    Case 94
                        rbbCostoReportes.Visible = True
                        btnCostoRepResumenGen.Visible = True
                    Case 98
                        rbbCostoReportes.Visible = True
                        btnCostoRepSobregiro.Visible = True
                    Case 140
                        rbbCostoProcesos.Visible = True
                        btnCostoProInvRotativo.Visible = True
                    Case 270
                        rbbCostoReportes.Visible = True
                        btnCostoRepGMROI.Visible = True
                End Select
                '////////////////////////////////////////

                '///////////Menu de Tablas///////////////
                Select Case FilaOpc.Item("IdOpcion")
                    Case 68
                        rbbTabTabVentas.Visible = True
                        btnTabVenClientes.Visible = True
                    Case 69
                        rbbTabTabAlmacen.Visible = True
                        btnTabAlmMercaderias.Visible = True
                    Case 70
                        rbbTabTabAlmacen.Visible = True
                        btnTabAlmTipoMotores.Visible = True
                    Case 71
                        rbbTabTabAlmacen.Visible = True
                        btnTabAlmModelos.Visible = True
                    Case 72
                        rbbTabTabImportacion.Visible = True
                        btnTabImpPartidas.Visible = True
                    Case 73
                        rbbTabTabImportacion.Visible = True
                        btnTabImpMarcas.Visible = True
                    Case 99
                        rbbTabTabAlmacen.Visible = True
                        btnTabAlmClases.Visible = True
                    Case 100
                        rbbTabTabImportacion.Visible = True
                        btnTabAlmPreciosCore.Visible = True
                    Case 104
                        rbbTabTabServicios.Visible = True
                        btnPlantillaRepuesto.Visible = True
                    Case 105
                        rbbTabTabServicios.Visible = True
                        btnPlantillaRepuestoCliente.Visible = True
                    Case 133
                        rbbTabTabCompras.Visible = True
                        btnproveedores.Visible = True
                    Case 181
                        rbbTabTabContabilidad.Visible = True
                        btnManteCuentaContable.Visible = True
                    Case 186
                        rbbTabTabPersonal.Visible = True
                        btnManteRubroPlanilla.Visible = True
                    Case 192
                        rbbTabTabPersonal.Visible = True
                        btnManteRubroPlanillaCuentas.Visible = True
                    Case 193
                        rbbTabTabContabilidad.Visible = True
                        btnManteCuentaDestino.Visible = True
                    Case 227
                        rbbTabTabPersonal.Visible = True
                        btnManteHorarios.Visible = True
                    Case 229
                        rbbTabTabPersonal.Visible = True
                        btnManteFeriadoPersonal.Visible = True
                    Case 230
                        rbbTabTabPersonal.Visible = True
                        btnManteAfp.Visible = True
                    Case 231
                        rbbTabTabPersonal.Visible = True
                        btnManteCargos.Visible = True
                    Case 232
                        rbbTabTabPersonal.Visible = True
                        btnManteMotFaltas.Visible = True
                    Case 233
                        rbbTabTabPersonal.Visible = True
                        btnManteEquipoLector.Visible = True
                    Case 234
                        rbbTabTabPersonal.Visible = True
                        btnManteAreas.Visible = True
                    Case 235
                        rbbTabTabPersonal.Visible = True
                        btnManteTipoHoraExtra.Visible = True
                    Case 236
                        rbbTabTabServicios.Visible = True
                        btnManteUbicaServicio.Visible = True
                    Case 262
                        rbbTabTabRondas.Visible = True
                        btnManteRuteador.Visible = True
                    Case 263
                        rbbTabTabRondas.Visible = True
                        btnManteRutas.Visible = True
                    Case 264
                        rbbTabTabRondas.Visible = True
                        btnMantePuntosControl.Visible = True
                    Case 314
                        rbbTabTabVentas.Visible = True
                        btnTabCondicionPagoCliente.Visible = True
                    Case 315
                        rbbTabTabCompras.Visible = True
                        btnCondicionPagoProveedores.Visible = True
                    Case 316
                        rbbTabTabServicios.Visible = True
                        btnTabManteVehiculos.Visible = True
                End Select
                '////////////////////////////////////////

                '///////////Menu de Administracion///////////////
                Select Case FilaOpc.Item("IdOpcion")
                    Case 74
                        rbbAdminSeguridad.Visible = True
                        btnUsuarios.Visible = True
                    Case 75
                        rbbAdminSeguridad.Visible = True
                        btnPerfiles.Visible = True
                    Case 143
                        rbbAdminUsuarios.Visible = True
                        btnAtencionSolicitud.Visible = True
                    Case 159
                        rbbAdminReportes.Visible = True
                        btnAdminIndicadorSolicitud.Visible = True
                    Case 242
                        rbbAdminEncuestas.Visible = True
                        btnAdminEncuesta.Visible = True
                    Case 243
                        rbbAdminEncuestas.Visible = True
                        btnAdminResultadoEncuesta.Visible = True
                    Case 285
                        rbbAdminSoftware.Visible = True
                        btnAdminSoftwareComputadora.Visible = True
                    Case 286
                        rbbAdminSoftware.Visible = True
                        btnAdminSoftwareAsignar.Visible = True
                    Case 288
                        rbbAdminLlamadas.Visible = True
                        btnAdminLlamadas.Visible = True
                    Case 296
                        rbbAdminSeguridad.Visible = True
                        btnSesiones.Visible = True
                    Case 309
                        rbbAdminTablas.Visible = True
                        btnAdminEquiposMarcacion.Visible = True
                    Case 310
                        rbbAdminTablas.Visible = True
                        btnAdminSeriesDocumentos.Visible = True
                    Case 311
                        rbbAdminTablas.Visible = True
                        btnAdminEmpresas.Visible = True
                    Case 312
                        rbbAdminTablas.Visible = True
                        btnAdminLocaciones.Visible = True
                    Case 317
                        rbbAdminTablas.Visible = True
                        btnAdminRubros.Visible = True
                    Case 318
                        rbbAdminTablas.Visible = True
                        btnAdminParametrosLocacion.Visible = True
                    Case 319
                        rbbAdminTablas.Visible = True
                        btnAdminParametrosPlanilla.Visible = True
                    Case 322
                        rbbAdminTablas.Visible = True
                        btnAdminRubroEmpresa.Visible = True
                End Select
                '////////////////////////////////////////////////

                '///////////Menu de Gerencial///////////////
                Select Case FilaOpc.Item("IdOpcion")
                    Case 88
                        rbbGerReportes.Visible = True
                        btnGerVentas.Visible = True
                    Case 89
                        rbbGerReportes.Visible = True
                        btnGerImportaciones.Visible = True
                    Case 90
                        rbbGerReportes.Visible = True
                        btnGerInventario.Visible = True
                    Case 91
                        rbbGerReportes.Visible = True
                        btnGerContabilidad.Visible = True
                    Case 92
                        rbbGerReportes.Visible = True
                        btnGerCreditos.Visible = True
                    'Case 93
                    '    rbbGerReportes.Visible = True
                    '    btnGerServicios.Visible = True
                    Case 97
                        rbbGerReportes.Visible = True
                        btnGerFiltroIndicadores.Visible = True
                    Case 101
                        rbbGerReportes.Visible = True
                        btnGerTarjeta.Visible = True
                    Case 176
                        rbbGerReportes.Visible = True
                        btnGerConsolidado.Visible = True
                    Case 279
                        rbbGerReportes.Visible = True
                        btnGerEstadosFinancieros.Visible = True
                End Select
                '////////////////////////////////////////////////

                '///////////Menu de Servicios///////////////
                Select Case FilaOpc.Item("IdOpcion")
                    Case 102
                        rbbSerAlmacen.Visible = True
                        btnSerPedirRepuesto.Visible = True
                    Case 108
                        rbbSerVentas.Visible = True
                        btnSerCotizacion.Visible = True
                    Case 109
                        rbbSerJob.Visible = True
                        btnSerSolicitudJob.Visible = True
                    Case 110
                        rbbSerJob.Visible = True
                        btnSerJob.Visible = True
                    Case 111
                        rbbSerJob.Visible = True
                        btnSerGastoViaje.Visible = True
                    Case 112
                        rbbSerJob.Visible = True
                        btnSerMarcacionJob.Visible = True
                    Case 113
                        rbbSerJob.Visible = True
                        btnSerGastoReal.Visible = True
                    Case 114
                        rbbSerVehiculos.Visible = True
                        btnSerKilometraje.Visible = True
                    Case 115
                        rbbSerReportes.Visible = True
                        btnSerRepGastosPorRubro.Visible = True
                    Case 116
                        rbbSerReportes.Visible = True
                        btnSerRepCostosDirectos.Visible = True
                    Case 117
                        rbbSerReportes.Visible = True
                        btnSerRepGastosViajePorRubro.Visible = True
                    Case 118
                        rbbSerReportes.Visible = True
                        btnSerRepJobPendienteFacturacion.Visible = True
                    Case 119
                        rbbSerReportes.Visible = True
                        btnSerRepTiempoReparacion.Visible = True
                    Case 120
                        rbbSerReportes.Visible = True
                        btnSerRepJobGarantias.Visible = True
                    Case 121
                        rbbSerReportes.Visible = True
                        btnSerRepHorasEscalon.Visible = True
                    Case 122
                        rbbSerReportes.Visible = True
                        btnSerRepHorasGenerales.Visible = True
                    Case 123
                        rbbSerMantenimiento.Visible = True
                        btnSerManOficinaUsuario.Visible = True
                    Case 124
                        rbbSerReportes.Visible = True
                        btnSerRepMovRepuesto.Visible = True
                    Case 125
                        rbbSerConsultas.Visible = True
                        btnSerConJob.Visible = True
                    Case 127
                        rbbSerConsultas.Visible = True
                        btnSerConMarcacionJob.Visible = True
                    Case 129
                        rbbSerConsultas.Visible = True
                        btnSerConGastoRealJob.Visible = True
                    Case 151
                        rbbSerJob.Visible = True
                        btnSerPreMarcacionJob.Visible = True
                    Case 153
                        rbbSerGarantia.Visible = True
                        btnSerAfa.Visible = True
                    Case 164
                        rbbSerReportes.Visible = True
                        btnSerRepAfas.Visible = True
                    Case 170
                        rbbSerReportes.Visible = True
                        btnSerRepCotizaciones.Visible = True
                    Case 171
                        rbbSerReportes.Visible = True
                        btnSerRepSolicitudJob.Visible = True
                    Case 174
                        rbbSerReportes.Visible = True
                        btnSerRepJob.Visible = True
                    Case 183
                        rbbSerIndicadores.Visible = True
                        btnSerIndActividades.Visible = True
                    Case 184
                        rbbSerIndicadores.Visible = True
                        btnSerIndPlantilla.Visible = True
                    Case 185
                        rbbSerIndicadores.Visible = True
                        btnSerIndProgramacion.Visible = True
                    Case 201
                        rbbSerIndicadores.Visible = True
                        btnSerIndTablero.Visible = True
                    Case 237
                        rbbSerReportes.Visible = True
                        btnSerRepHorasMuertas.Visible = True
                    Case 244
                        btnSerProEquipos.Visible = True
                        rbbSerProyeccion.Visible = True
                    Case 245
                        rbbSerIndicadores.Visible = True
                        btnSerIndProductividad.Visible = True
                    Case 247
                        rbbSerProyeccion.Visible = True
                        btnSerProHorasMotor.Visible = True
                    Case 250
                        rbbSerProyeccion.Visible = True
                        btnSerProSeguimiento.Visible = True
                    Case 251
                        rbbSerReportes.Visible = True
                        ddcSerRepProyeccion.Visible = True
                        btnSerRepHorasMotores.Visible = True
                    Case 252
                        rbbSerReportes.Visible = True
                        ddcSerRepProyeccion.Visible = True
                        btnSerRepDisponibilidad.Visible = True
                    Case 253
                        rbbSerReportes.Visible = True
                        ddcSerRepProyeccion.Visible = True
                        btnSerRepMotorDarBaja.Visible = True
                    Case 255
                        rbbSerReportes.Visible = True
                        ddcSerRepProyeccion.Visible = True
                        btnSerRepProyeccionRepImportar.Visible = True
                    Case 256
                        rbbSerReportes.Visible = True
                        ddcSerRepProyeccion.Visible = True
                        btnSerRepProyeccionVentas.Visible = True
                    Case 257
                        rbbSerProyeccion.Visible = True
                        btnSerProRepuestos.Visible = True
                    Case 261
                        rbbSerReportes.Visible = True
                        ddcSerRepProyeccion.Visible = True
                        btnSerRepSeguimientos.Visible = True
                    Case 275
                        rbbSerReportes.Visible = True
                        ddcSerRepProyeccion.Visible = True
                        btnSerRepProyeccionReparaciones.Visible = True
                    Case 290
                        rbbSerProyeccion.Visible = True
                        btnSerProGenerarPedidoInterno.Visible = True
                    Case 301
                        rbbSerGarantia.Visible = True
                        btnSerReclamoCliente.Visible = True
                    Case 330
                        rbbSerJob.Visible = True
                        btnSerMarcacionOT.Visible = True
                End Select

                '////Menu de Compras//////
                Select Case FilaOpc.Item("IdOpcion")
                    Case 130
                        rbbComCompras.Visible = True
                        btnComSolicitud.Visible = True
                    Case 131
                        rbbComCompras.Visible = True
                        btnComOrdenCompra.Visible = True
                    Case 134
                        rbbComCompras.Visible = True
                        btnComCotizacionSolicitud.Visible = True
                    Case 136
                        rbbComControl.Visible = True
                        btnComSolicitudGasto.Visible = True
                    Case 137
                        rbbComControl.Visible = True
                        btnComMesaControl.Visible = True
                    Case 150
                        rbbComControl.Visible = True
                        btnComPlanillaViatico.Visible = True
                    Case 154
                        rbbComConsultas.Visible = True
                        btnComConsultaCompras.Visible = True
                    Case 157
                        rbbComReportes.Visible = True
                        btnComRepOrdenes.Visible = True
                    Case 158
                        rbbComReportes.Visible = True
                        btnComRepSolicitudGasto.Visible = True
                    Case 165
                        rbbComControl.Visible = True
                        btnComTarifa.Visible = True
                    Case 167
                        rbbComControl.Visible = True
                        btnComTarifaCasa.Visible = True
                    Case 168
                        rbbComReportes.Visible = True
                        btnComRepMesaControl.Visible = True
                    Case 258
                        rbbComControl.Visible = True
                        btnComTarifaDestino.Visible = True
                    Case 138
                        rbbComControl.Visible = True
                        btnComCuentasPorPagar.Visible = True
                    Case 149
                        rbbComReportes.Visible = True
                        btnComRepPagosCuentasPorPagar.Visible = True
                    Case 271
                        rbbComReportes.Visible = True
                        btnComRepCtasPorPagarUnidad.Visible = True
                    Case 320
                        rbbComReportes.Visible = True
                        btnComRepCtasPorPagar.Visible = True
                    Case 321
                        rbbComReportes.Visible = True
                        btnComRepVencimientosCtasPorPagar.Visible = True

                End Select
                '////////////////////////////////////////////////


                '////Menu de Contabilidad//////
                Select Case FilaOpc.Item("IdOpcion")

                    Case 141
                        rbbContaCajaChica.Visible = True
                        btnConProvisional.Visible = True
                    Case 142
                        rbbContaCajaChica.Visible = True
                        btnConReembolso.Visible = True
                    Case 144
                        rbbContaCajaChica.Visible = True
                        btnConArqueoCaja.Visible = True
                    Case 147
                        rbbContaReportes.Visible = True
                        btnConRepCtasPorPagar.Visible = True
                    Case 148
                        rbbContaReportes.Visible = True
                        btnConRepVencimientos.Visible = True

                    Case 152
                        rbbContaReportes.Visible = True
                        btnConRepReembolso.Visible = True
                    Case 172
                        rbbContaTesoreria.Visible = True
                        btnConTesoreria.Visible = True
                    Case 173
                        rbbContaCompras.Visible = True
                        btnConRegistroCompra.Visible = True
                    Case 175
                        rbbContaContabilidad.Visible = True
                        btnConDiario.Visible = True
                    Case 177
                        rbbContaReportes.Visible = True
                        ddcConRepLibrosOficiales.Visible = True
                        btnConRepRegistroCompra.Visible = True
                    Case 182
                        rbbContaProcesos.Visible = True
                        btnConProCuentaDestino.Visible = True
                    Case 187
                        rbbContaProcesos.Visible = True
                        btnConProCierreMes.Visible = True
                    Case 188
                        rbbContaReportes.Visible = True
                        ddcConRepLibrosOficiales.Visible = True
                        btnConRepLibroDiario.Visible = True
                    Case 189
                        rbbContaReportes.Visible = True
                        ddcConRepLibrosOficiales.Visible = True
                        btnConRepLibroMayor.Visible = True
                    Case 190
                        rbbContaReportes.Visible = True
                        'ddcConRepLibrosOficiales.Visible = True
                        btnConRepEstadosFinancieros.Visible = True
                    Case 191
                        rbbContaReportes.Visible = True
                        ddcConRepLibrosOficiales.Visible = True
                        btnConRepCajaBancos.Visible = True
                    Case 195
                        rbbContaProcesos.Visible = True
                        btnConProDifTipoCambio.Visible = True
                    Case 197
                        rbbContaReportes.Visible = True
                        btnConRepCtasCtes.Visible = True
                    Case 198
                        rbbContaReportes.Visible = True
                        btnConRepCtasCtesPend.Visible = True
                    Case 241
                        rbbContaReportes.Visible = True
                        btnConRepMayorAuxiliar.Visible = True
                    Case 254
                        rbbContaTesoreria.Visible = True
                        btnConMovimientoBanco.Visible = True
                    Case 268
                        rbbContaReportes.Visible = True
                        btnConRepChequesGirados.Visible = True
                    Case 305
                        rbbContaProcesos.Visible = True
                        btnConGenerarTXTLibros.Visible = True
                    Case 306
                        rbbContaProcesos.Visible = True
                        btnConProFlujoCaja.Visible = True
                    Case 324
                        rbbContaCompras.Visible = True
                        btnConReciboHonorario.Visible = True
                    Case 328
                        rbbContaReportes.Visible = True
                        btnConRepProvisionales.Visible = True
                End Select
                '////////////////////////////////////////////////

                '////PERSONAL//////////
                Select Case FilaOpc.Item("IdOpcion")
                    Case 178
                        rbbPerInformacion.Visible = True
                        btnPerInfDatos.Visible = True
                    Case 179
                        rbbPerPlanilla.Visible = True
                        btnPerPlanilla.Visible = True
                    Case 194
                        rbbPerReportes.Visible = True
                        btnPerRepPlanillaSueldos.Visible = True
                    Case 206
                        rbbPerAsignaciones.Visible = True
                        btnPerAsigFaltas.Visible = True
                    Case 207
                        rbbPerAsignaciones.Visible = True
                        btnPerAsigMarcas.Visible = True
                    Case 208
                        rbbPerInformacion.Visible = True
                        btnPerInfVacaciones.Visible = True
                    Case 209
                        rbbPerInformacion.Visible = True
                        btnPerInfContratos.Visible = True
                    Case 210
                        rbbPerAsignaciones.Visible = True
                        btnPerAsigHoraExtra.Visible = True
                    Case 211
                        rbbPerAsignaciones.Visible = True
                        btnPerRegistroHoraExtra.Visible = True
                    Case 212
                        rbbPerAsignaciones.Visible = True
                        btnPerAsigIngresos.Visible = True
                    Case 213
                        rbbPerAsignaciones.Visible = True
                        btnPerAsigDescuentos.Visible = True
                    Case 214
                        rbbPerAsignaciones.Visible = True
                        btnPerAsigJefes.Visible = True
                    Case 215
                        rbbPerAsignaciones.Visible = True
                        btnPerAsigHorario.Visible = True
                    Case 216
                        rbbPerAsignaciones.Visible = True
                        btnPerAsigRecursos.Visible = True
                    Case 217
                        rbbPerReportes.Visible = True
                        btnPerRepAsistencia.Visible = True
                    Case 218
                        rbbPerReportes.Visible = True
                        btnPerRepTardanzas.Visible = True
                    Case 219
                        rbbPerReportes.Visible = True
                        btnPerRepAsignacionHoraExtra.Visible = True
                    Case 220
                        rbbPerReportes.Visible = True
                        btnPerRepHoraExtra.Visible = True
                    Case 221
                        rbbPerReportes.Visible = True
                        btnPerRepFaltas.Visible = True
                    Case 222
                        rbbPerReportes.Visible = True
                        btnPerRepDescuentos.Visible = True
                    Case 223
                        rbbPerReportes.Visible = True
                        btnPerRepIngresos.Visible = True
                    Case 224
                        rbbPerReportes.Visible = True
                        btnPerRepPersonal.Visible = True
                    Case 225
                        rbbPerReportes.Visible = True
                        btnPerRepRecursos.Visible = True
                    Case 226
                        rbbPerReportes.Visible = True
                        btnPerRepVacaciones.Visible = True
                    Case 228
                        rbbPerComunicaciones.Visible = True
                        btnPerComAdminLector.Visible = True
                    Case 238
                        rbbPerInformacion.Visible = True
                        btnPerInfCapacitacion.Visible = True
                    Case 239
                        rbbPerReportes.Visible = True
                        btnPerRepCapacitacion.Visible = True
                    Case 240
                        rbbPerReportes.Visible = True
                        btnPerRepContratos.Visible = True
                    Case 246
                        rbbPerComunicaciones.Visible = True
                        btnPerComProcesarMarcas.Visible = True
                    Case 259
                        rbbPerReportes.Visible = True
                        btnPerRepOnomasticos.Visible = True
                    Case 295
                        rbbPerAsignaciones.Visible = True
                        btnPerAsigCronogramaMina.Visible = True
                    Case 297
                        rbbPerReportes.Visible = True
                        btnPerRepCronogramaMina.Visible = True
                    Case 302
                        rbbPerInformacion.Visible = True
                        btnPerInfEvaluacion.Visible = True
                    Case 308
                        rbbPerReportes.Visible = True
                        btnPerRepAsigHorario.Visible = True
                    Case 323
                        rbbPerPlanilla.Visible = True
                        btnPerQuintaCategoria.Visible = True
                    Case 331
                        rbbPerAsignaciones.Visible = True
                        btnPerMarcaccionOnline.Visible = True
                End Select
                '//////////////////////

                '/////////MENU RONDAS////////////
                Select Case FilaOpc.Item("IdOpcion")
                    Case 265
                        rbbRondasAsignacion.Visible = True
                        btnPuntosControlRutas.Visible = True
                    Case 266
                        rbbRondasAsignacion.Visible = True
                        btnRuteadorRutas.Visible = True
                    Case 267
                        rbbRondasAsignacion.Visible = True
                        btnRondas.Visible = True

                End Select

                '/////////MENU TELEFONIA////////////
                Select Case FilaOpc.Item("IdOpcion")
                    Case 280
                        rbbTelefoniaMante.Visible = True
                        btnTelModelos.Visible = True
                    Case 281
                        rbbTelefoniaMante.Visible = True
                        btnTelEquipos.Visible = True
                    Case 282
                        rbbTelefoniaMante.Visible = True
                        btnTelPlanes.Visible = True
                    Case 283
                        rbbTelefoniaAsigna.Visible = True
                        btnTelLineas.Visible = True
                    Case 284
                        rbbTelefoniaAsigna.Visible = True
                        btnTelAsignaLinea.Visible = True
                End Select

                '//////////MENU CMR/////////////
                Select Case FilaOpc.Item("IdOpcion")
                    Case 26
                        btnCRMVisitas.Visible = True
                        rbbCRMOportunidad.Visible = True
                    Case 291
                        rbbCRMOportunidad.Visible = True
                        btnCRMOportIngresar.Visible = True
                    Case 292
                        rbbCRMReportes.Visible = True
                        btnCRMRepOportunidad.Visible = True
                    Case 25
                        btnCRMOcurrencias.Visible = True
                        rbbCRMOportunidad.Visible = True
                    Case 293
                        rbbCRMOportunidad.Visible = True
                        btnCRMTarjetaCliente.Visible = True
                    Case 294
                        rbbCRMReportes.Visible = True
                        btnCRMRepVisitas.Visible = True
                    Case 299
                        btnCRMCuotas.Visible = True
                        rbbCRMOportunidad.Visible = True
                End Select
                '//////////////////////////////

                '//////////MENU ACTIVOS FIJOS/////////////
                Select Case FilaOpc.Item("IdOpcion")
                    Case 303
                        btnActivoDatos.Visible = True
                        rbbActivoDatos.Visible = True
                    Case 325
                        rbbActivoReportes.Visible = True
                        btnActivoReporte.Visible = True
                End Select
                '//////////////////////////////



                ActMenu = True
            Next
            Select Case Fila.Item("IdMenu")
                Case 1
                    rbbTabAlmacenes.Visible = ActMenu
                Case 2
                    rbbTabVentas.Visible = ActMenu
                Case 3
                    rbbTabCréditos.Visible = ActMenu
                Case 4
                    rbbTabImportaciones.Visible = ActMenu
                Case 5
                    rbbTabCostos.Visible = ActMenu
                Case 6
                    rbbTabTablas.Visible = ActMenu
                Case 7
                    rbbTabAdministracion.Visible = ActMenu
                Case 8
                    rbbTabGerencia.Visible = ActMenu
                Case 9
                    rbbTabServicios.Visible = ActMenu
                Case 10
                    rbbTabPersonal.Visible = ActMenu
                Case 11
                    rbbTabCompras.Visible = ActMenu
                Case 12
                    rbbTabContabilidad.Visible = ActMenu
                Case 13
                    rbbTabRondas.Visible = ActMenu
                Case 14
                    rbbTabTelefonia.Visible = ActMenu
                Case 15
                    rbbTabCRM.Visible = ActMenu
                Case 16
                    rbbTabActivos.Visible = ActMenu
            End Select

        Next

        oSeguridadService.Close()

    End Sub

    Private Sub CargarPerfil()
        Try
            Dim permisoUsuario As New SeguridadService.PermisoUsuario
            permisoUsuario = oSeguridadService.MostrarPermisos(Session.sCodUsu)
            If oAprobarVentaService.BuscarAutorizacion(Session.sCodUsu) Then
                Session.CodPerfil = "20"
                lblUsuario.Text = "Usuario :  " & permisoUsuario.Usuario.CodUsu & "  /  Perfil : Asistente de Creditos Provisional"
            Else
                Session.CodPerfil = permisoUsuario.Perfil.CodPerfil
                lblUsuario.Text = "Usuario : " & permisoUsuario.Usuario.CodUsu & "  /  Perfil : " & permisoUsuario.Perfil.Nombre
            End If

            'Session.CodPerfil = permisoUsuario.Perfil.CodPerfil
            'lblUsuario.Text = "Usuario : " & permisoUsuario.Usuario.CodUsu & "  /  Perfil : " & permisoUsuario.Perfil.Nombre

            lblTransa.Text = "Fecha de Transacción : " & Session.sFecha & "  /  Tipo de Cambio Compra : " & Trim(oSeguridadService.MostrarTipoCambioCompra("US", Session.sFecha)) & "    Venta : " & Trim(oSeguridadService.MostrarTipoCambio("US", Session.sFecha))

            ActivarMenu()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Perfil")
        End Try
    End Sub

    '/////////////// Ventas ///////////////
    '========== Ventas Documentos ==========
    Private Sub btnVenDocGuiasRemision_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenDocGuiasRemision.Click
        Dim frm As New frmGuiasRemision
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnVenDocGuiasDevolucion_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenDocGuiasDevolucion.Click
        Dim frm As New frmGuiasDevolucion
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnVenDocFacturas_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenDocFacturas.Click
        Dim frm As New frmFacturas
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnVenDocBoletas_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenDocBoletas.Click
        Dim frm As New frmBoletas
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnVenDocNotas1_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenDocNotas.Click
        Dim frm As New frmNotasCredito
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnVenDocResumen_Click(sender As Object, e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenDocResumen.Click
        Dim frm As New frmBoleta_BoletaElectronica_Resumen
        frm.MdiParent = Me
        frm.Show()
    End Sub
    '========== Ventas Pre y Post ==========
    Private Sub btnVenPreCotizaciones_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenPreCotizaciones.Click
        Dim frm As New frmCotizaciones
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnVenPreOrdenesCompra_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenPreOrdenesCompra.Click
        Dim frm As New frmOrdenesCompra
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnVenReclamo_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenReclamo.Click
        Dim frm As New frmReclamos
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnVenEnvioCorreo_Click(sender As Object, e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenEnvioCorreo.Click
        Dim frm As New frmEnvioMasivoCorreos
        frm.MdiParent = Me
        frm.Show()
    End Sub
    '========== Ventas Clientes ==========
    Private Sub btnVenCliCartera_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenCliCartera.Click
        Dim frm As New frmCarteraClientes
        frm.MdiParent = Me
        frm.Show()
    End Sub


    '========== Ventas Requisiciones ==========
    Private Sub btnVenReqDespachos_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenReqDespachos.Click
        Dim frm As New frmDespachosRequisiciones
        frm.MdiParent = Me
        frm.Show()
    End Sub
    '========== Ventas Consultas ==========
    Private Sub btnVenConPrecios_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenConPrecios.Click
        Dim frm As New frmPrecios
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnVenConDocumentos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenConDocumentos.Click
        Dim frm As New frmConsultaDocumentos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    '========== Ventas Reportes ==========
    Private Sub btnVenRepVentaDetalle_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenRepVentaDetalle.Click
        Dim frm As New frmRepVentaDetalle
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnVenRepVentaAcumulada_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenRepVentaAcumulada.Click
        Dim frm As New frmRepVentaAcumulada
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnVenRepVentaGuias_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenRepVentaGuias.Click
        Dim frm As New frmRepVentaGuias
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnVenRepCotizaciones_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenRepCotizaciones.Click
        Dim frm As New frmRepCotizaciones
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnVenPostActuVendedor_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenPostActuVendedor.Click
        Dim frm As New frmActualizarVendedor
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnVenRepVentaRequisiciones_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenRepVentaRequisiciones.Click
        Dim frm As New frmRepRequisiciones
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnVenRepMensualesxCliente_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenRepMensualesxCliente.Click
        Dim frm As New frmRepventaMenxCli
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ddcVenRepRegistro_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles ddcVenRepRegistro.Click
        Dim frm As New frmRegistroVenta
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ddcVenRepRegistroAuxiliar_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles ddcVenRepRegistroAuxiliar.Click
        Dim frm As New frmRegAuxiliarVenta
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ddcVenRepRegistroResumen_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles ddcVenRepRegistroResumen.Click
        Dim frm As New frmResumenRegVenta
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnVenRepDetalleDescuento_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenRepDetalleDescuento.Click
        Dim frm As New frmRepVentaDetalleDescuento
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnVenRepReclamos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenRepReclamos.Click
        Dim frm As New frmRepReclamos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnVenRepOrdenes_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenRepOrdenes.Click
        Dim frm As New frmRepOrdenesCompra
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnVenSepararOrden_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenSepararOrden.Click
        Dim frm As New frmSepOrdenesCompra
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnVenIndTablero_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenIndTablero.Click
        Dim frm As New frmIndicadoresVenta
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnVenRepConsignacion_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenRepConsignacion.Click
        Dim frm As New FrmRepConsignacion
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnVenRepTodoGuiaRemision_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenRepTodoGuiaRemision.Click
        Dim frm As New frmRepVentaGuiasRemision
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnVenPreciosCliente_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenPreciosCliente.Click
        ' Dim frm As New frmListaPrecioCliente
        Dim frm As New frmListaPrecioClienteNuevo
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnVenPreciosLista_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenPreciosLista.Click
        'Dim frm As New frmListaPrecio
        Dim frm As New frmListaPrecioNuevo
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnVenPreciosOferta_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenPreciosOferta.Click
        'Dim frm As New frmListaOferta
        Dim frm As New frmListaOfertaNuevo
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnVenRepPresupuestoVenta_Click(sender As Object, e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenRepPresupuestoVenta.Click
        Dim frm As New frmVentasPresupuestoAnual
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnVenRepComisiones_Click(sender As Object, e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnVenRepComisiones.Click
        Dim frm As New frmRepComisiones
        frm.MdiParent = Me
        frm.Show()
    End Sub
    '/////////////////////////////////////////

    '/////////////// Almacenes ///////////////
    '========== Almacenes Documentos ==========
    Private Sub btnAlmAlmDocumentos_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmAlmDocumentos.Click
        Dim frm As New frmMovimientosAlmacen
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnAlmAlmDocumentoSalidas_Click(sender As Object, e As CommandEventArgs) Handles btnAlmAlmDocumentoSalidas.Click
        Dim frm As New frmMovimientosAlmacenSalidas
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnAlmAlmChequeoFI_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmAlmChequeoFI.Click
        Dim frm As New frmAlmacen_FacturasImportacion
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnAlmAlmTI_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmAlmTI.Click
        Dim frm As New frmTransferenciasInternas
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnAlmAlmMTI_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmAlmMTI.Click
        Dim frm As New frmMemosTransferenciasInternas
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnAlmAlmValesMate_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmAlmValesMate.Click
        Dim frm As New frmVales
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnAlmAlmAtenderJob_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmAlmAtenderJob.Click
        Dim frm As New frmAtenderJobAlmacen
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnAlmIndCalendario_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmIndCalendario.Click
        Dim frm As New frmCalendario
        frm.MdiParent = Me
        frm.Show()
    End Sub
    '========== Almacenes Motores ==========
    Private Sub btnAlmMotTransferencias_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmMotTransferencias.Click
        Dim frm As New frmTransferenciasMotores
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnAlmMotCompras_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmMotCompras.Click
        Dim frm As New frmComprasMotores
        frm.MdiParent = Me
        frm.Show()
    End Sub
    '========== Almacenes Tránsito ==========
    Private Sub btnAlmTraDocumentos_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmTraDocumentos.Click
        Dim frm As New frmDocumentosTransito
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnAlmTraAnulacionGuia_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmTraAnulacionGuia.Click
        Dim frm As New frmAlmacen_AnularDocumentosConsulta
        frm.MdiParent = Me
        frm.Show()
    End Sub
    '========== Almacenes Mantenimiento ==========
    Private Sub btnAlmManMercaderias_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmManMercaderias.Click
        Dim frm As New frmLocacionesMercaderia
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnAlmManLiquiGastos_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmManLiquiGastos.Click
        Dim frm As New frmLiquidacionesMotores
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnAlmManMinMax_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmManMinMax.Click
        Dim frm As New frmMaximosMinimo
        frm.MdiParent = Me
        frm.Show()
    End Sub

    '========== Almacenes Consultas ==========
    Private Sub botonConsultaTarjetas_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles _
                 btnAlmConTarjetas.Click
        Dim frm As New frmKardex_Tarjetas
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnAlmConDocumentos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmConDocumentos.Click
        Dim frm As New frmConsultaDocumentosAlmacen
        frm.MdiParent = Me
        frm.Show()
    End Sub

    '========== Almacenes Reportes ==========
    Private Sub btnAlmRepInventario_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmRepInventario.Click
        Dim frm As New frmRepInventario
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnAlmRepMovimientos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmRepMovimientos.Click
        Dim frm As New frmRepMovimientosAlmacen
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnAlmRepTomaInventario_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmRepTomaInventario.Click
        Dim frm As New frmRepTomaInventario
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnAlmRepValeMaterial_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmRepValeMaterial.Click
        Dim frm As New frmRepValeMaterial
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnAlmRepDocumento_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmRepDocumento.Click
        Dim frm As New frmRepDocumentos
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnAlmIndProcesoCobertura_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmIndProcesoCobertura.Click
        Dim frm As New frmTablero_Procesar
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnAlmIndTablero_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmIndTablero.Click
        Dim frm As New frmTablero
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnAlmRepInvPermanente_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmRepInvPermanente.Click
        Dim frm As New frmInventarioValorizado
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnAlmRepSinMovimiento_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmRepSinMovimiento.Click
        Dim frm As New frmRepInventariosinMovimiento
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnAlmRepTransferencia_Click(sender As Object, e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAlmRepTransferencia.Click
        Dim frm As New frmRepTransferenciaInterna
        frm.MdiParent = Me
        frm.Show()
    End Sub
    '/////////////// Créditos ///////////////
    '========== Créditos Documentos ==========
    Private Sub btnCreDocAnticipos_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreDocAnticipos.Click
        Dim frm As New frmAnticipos
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnCreDocLetras_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreDocLetras.Click
        Dim frm As New frmLetras
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCreDocPlanillas_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreDocPlanillas.Click
        Dim frm As New frmPlanillas
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCreDocCuentas_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreDocCuentas.Click
        Dim frm As New frmDocsCreditos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    '========== Créditos Aprobaciones ==========
    Private Sub btnCreAprCreditos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreAprCreditos.Click
        Dim frm As New frmAprobacion
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnCreAprCotizaciones_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreAprCotizaciones.Click
        Dim frm As New frmAprobarServicios
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCreAprPerUsuario_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreAprPerUsuario.Click
        Dim frm As New frmAprobarPermisoUsuarios
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCreManBancos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreManBancos.Click
        Dim frm As New frmSaldoBancos
        frm.MdiParent = Me
        frm.Show()
    End Sub


    Private Sub btnCreAprRecepcionDoc_Click(sender As Object, e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreAprRecepcionDoc.Click
        Dim frm As New frmRecepcionDocumentos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    '========== Créditos Mantenimiento ==========
    Private Sub btnCreManFacDesc_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreManFacDesc.Click
        Dim frm As New frmClienteFacDscs
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCreManVisitaCobrador_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreManVisitaCobrador.Click
        Dim frm As New frmVisitasCobrador
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCreManProcesarGuias_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreManProcesarGuias.Click
        Dim frm As New frmGarantias
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCreManFeriados_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreManFeriados.Click
        Dim frm As New frmFeriados
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnCreManTipoCambio_Click(sender As Object, e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreManTipoCambio.Click
        Dim frm As New frmActTipoCambio
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnCreManRenuevaTC_Click(sender As Object, e As CommandEventArgs) Handles btnCreManRenuevaTC.Click
        Dim frm As New frmRenuevaTipCam
        frm.MdiParent = Me
        frm.Show()
    End Sub
    '========== Créditos Consultas ==========
    Private Sub btnCreConCuentas_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreConCuentas.Click
        Dim frm As New frmConsultaDocCtaCtes
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCreConVencimientos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreConVencimientos.Click
        Dim frm As New frmVencimientos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCreConTarjetaCliente_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreConTarjetaCliente.Click
        Dim frm As New frmEstadoCliente
        frm.MdiParent = Me
        frm.Show()
    End Sub

    '===========Creditos Reportes============
    Private Sub btnCreRepPlanilla_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreRepPlanilla.Click
        Dim frm As New frmRepPlanilla
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCreRepDiarioPago_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreRepDiarioPago.Click
        Dim frm As New frmRepDiarioPagos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCreRepDocEmitido_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreRepDocEmitido.Click
        Dim frm As New frmRepDocEmitidos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCreRepLetra_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreRepLetra.Click
        Dim frm As New frmRepLetras
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCreRepCtasCtes_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreRepCtasCtes.Click
        Dim frm As New frmRepCtasCtes
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCreRepNotasDebito_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreRepNotasDebito.Click
        Dim frm As New frmRepNotas
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCreRepVisitaCobrador_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreRepVisitaCobrador.Click
        Dim frm As New frmRepVisitaCobrador
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnCreManVincularGuias_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCreManVincularGuias.Click
        Dim frm As New frmVincularGuia
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ddcCreRepVencimientoDetalle_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles ddcCreRepVencimientoDetalle.Click
        Dim frm As New frmRepVencimientos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ddcCreRepVencimientoAcumulado_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles ddcCreRepVencimientoAcumulado.Click
        Dim frm As New frmRepVencimientosResumen
        frm.MdiParent = Me
        frm.Show()
    End Sub

    '/////////////// Importaciones ///////////////
    '========== Importaciones Importaciones ==========
    Private Sub btnImpImpDocumentos_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnImpImpDocumentos.Click
        Dim frm As New frmDocumentos
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnImpImpEmbarque_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnImpImpEmbarque.Click
        Dim frm As New frmEmbarques
        frm.MdiParent = Me
        frm.Show()
    End Sub
    '========== Importaciones Pedidos ==========
    Private Sub btnImpPedImportacion_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnImpPedImportacion.Click
        Dim frm As New frmPedidosImportacion
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnImpPedInternos_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnImpPedInternos.Click
        Dim frm As New frmPedidos
        frm.MdiParent = Me
        frm.Show()
    End Sub
    '========== Importaciones Consultas ==========


    '===========REPORTES DE IMPORTACIONES===========
    Private Sub btnImpRepPedidoImp_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnImpRepPedidoImp.Click

        Dim frm As New frmReportPedido
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnImpRepEmbarques_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnImpRepEmbarques.Click
        Dim frm As New frmRepEmbarques
        frm.MdiParent = Me
        frm.Show()
    End Sub

    '/////////////// Tablas ///////////////
    '========== Tablas Ventas ==========
    Private Sub btnTabVenClientes_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnTabVenClientes.Click
        Dim frm As New frmClientes
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnTabCondicionPagoCliente_Click(sender As Object, e As CommandEventArgs) Handles btnTabCondicionPagoCliente.Click
        Dim frm As New frmCondicionPagosV
        frm.MdiParent = Me
        frm.Show()
    End Sub



    '========== Tablas Almacenes ==========
    Private Sub btnTabAlmMercaderias_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnTabAlmMercaderias.Click
        Dim frm As New frmProductos
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnTabAlmTipoMotores_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnTabAlmTipoMotores.Click
        Dim frm As New frmTiposMotoresProducto
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnTabAlmModelos_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnTabAlmModelos.Click
        Dim frm As New frmModelosProducto
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnTabAlmClases_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnTabAlmClases.Click
        Dim frm As New frmClases
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnTabAlmPreciosCore_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnTabAlmPreciosCore.Click
        Dim frm As New frmCores
        frm.MdiParent = Me
        frm.Show()
    End Sub

    '========== Tablas Importaciones ==========
    Private Sub btnTabImpPartidas_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnTabImpPartidas.Click
        Dim frm As New frmPartidas
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnTabImpMarcas_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnTabImpMarcas.Click
        Dim frm As New frmMarcas
        frm.MdiParent = Me
        frm.Show()
    End Sub
    '/////////////////////////////////////////

    '===========Tablas Servicios===============
    Private Sub btnPlantillaRepuesto_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPlantillaRepuesto.Click
        Dim frm As New frmRepuestosServicios
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnPlantillaRepuestoCliente_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPlantillaRepuestoCliente.Click
        Dim frm As New frmRepuestosServicioClientes
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnproveedores_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnproveedores.Click
        Dim frm As New frmProveedores
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnCondicionPagoProveedores_Click(sender As Object, e As CommandEventArgs) Handles btnCondicionPagoProveedores.Click
        Dim frm As New frmCondicionPagosC
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnManteUbicaServicio_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnManteUbicaServicio.Click
        Dim frm As New frmUbicacionServicios
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnTabManteVehiculos_Click(sender As Object, e As CommandEventArgs) Handles btnTabManteVehiculos.Click
        Dim frm As New frmUnidades
        frm.MdiParent = Me
        frm.Show()
    End Sub



    '/////////TABLAS CONTABILIDAD////////////
    Private Sub btnManteCuentaContable_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnManteCuentaContable.Click
        Dim frm As New frmMantCuentas
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnManteCuentaDestino_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnManteCuentaDestino.Click
        Dim frm As New frmCuentasDestino
        frm.MdiParent = Me
        frm.Show()
    End Sub
    '//////////TABLAS PERSONAL/////////////////
    Private Sub btnManteRubroPlanilla_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnManteRubroPlanilla.Click
        Dim frm As New frmRubrosPlanilla
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnManteRubroPlanillaCuentas_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnManteRubroPlanillaCuentas.Click
        Dim frm As New frmRubrosCuenta
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnManteHorarios_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnManteHorarios.Click
        Dim frm As New frmHorarios
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnManteFeriadoPersonal_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnManteFeriadoPersonal.Click
        Dim frm As New frmFeriadosLaborales
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnManteAfp_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnManteAfp.Click
        Dim frm As New frmAFP
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnManteCargos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnManteCargos.Click
        Dim frm As New frmCargos
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnManteAreas_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnManteAreas.Click
        Dim frm As New frmAreasCentroCosto
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnManteMotFaltas_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnManteMotFaltas.Click
        Dim frm As New frmMotivosFalta
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnManteEquipoLector_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnManteEquipoLector.Click
        Dim frm As New frmEquiposMarcacionEmpresa
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnManteTipoHoraExtra_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnManteTipoHoraExtra.Click
        Dim frm As New frmTiposHoraExtra
        frm.MdiParent = Me
        frm.Show()
    End Sub
    '//////////////////////////////////////////

    '//////////TABLAS RUTAS////////////
    Private Sub btnManteRutas_Click(sender As Object, e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnManteRutas.Click
        Dim frm As New frmRutas
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnManteRuteador_Click(sender As Object, e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnManteRuteador.Click
        Dim frm As New frmRuteadores
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnMantePuntosControl_Click(sender As Object, e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnMantePuntosControl.Click
        Dim frm As New frmPuntos
        frm.MdiParent = Me
        frm.Show()
    End Sub
    '///////////////////////////


    '////////////COSTOS////////////////// 
    Private Sub btnCostoRecalcular_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCostoRecalcular.Click
        Dim frm As New frmRecalcular
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCostoCerrarMes_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCostoCerrarMes.Click
        Dim frm As New frmCierreMes
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCostoConsolidado_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCostoConsolidado.Click
        Dim frm As New frmConsolidadoMes
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCostoAjustarCierre_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCostoAjustarCierre.Click
        Dim frm As New frmAjusteCostos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCostoActualizarDocs_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCostoActualizarDocs.Click
        Dim frm As New frmDocumentoCosto
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCostoRepImportaciones_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCostoRepImportaciones.Click
        Dim frm As New frmReporteImport
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCostoStockValorizado_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCostoStockValorizado.Click
        Dim frm As New frmStockValorizado
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCostoDiarioAlmacen_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCostoDiarioAlmacen.Click
        Dim frm As New frmDiarioAlmacen
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCostoRepCierreMes_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCostoRepCierreMes.Click
        Dim frm As New frmCuadrarCierre
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCostoValorizarImp_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCostoValorizarImp.Click
        Dim frm As New frmImportaciones
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCostoProGenerarPeriodo_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCostoProGenerarPeriodo.Click
        Dim frm As New frmGenerarPeriodoInventario
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCostoProTrasladarCosto_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCostoProTrasladarCosto.Click
        Dim frm As New frmTrasladarCostos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCostoRepCondensado_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCostoRepCondensado.Click
        Dim frm As New frmRepCondensados
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCostoRepMotores_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCostoRepMotores.Click
        Dim frm As New frmRepCostoMotores
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCostoRepKardex_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCostoRepKardex.Click
        Dim frm As New frmRepKardex
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCostoRepCostoVenta_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCostoRepCostoVenta.Click
        Dim frm As New frmRepCostoVenta
        frm.MdiParent = Me
        frm.Show()
    End Sub


    Private Sub btnCostoRepResumenGen_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCostoRepResumenGen.Click
        Dim frm As New frmRepResuGeneral
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCostoRepSobregiro_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCostoRepSobregiro.Click
        Dim frm As New frmSobregiro
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnCostoProInvRotativo_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCostoProInvRotativo.Click
        Dim frm As New frmInvRotativo
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnCostoRepGMROI_Click(sender As Object, e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnCostoRepGMROI.Click
        Dim frm As New frmRepGmroi
        frm.MdiParent = Me
        frm.Show()
    End Sub

    '//////////////MODULO DE ADMINISTRACION DEL SISTEMA////////////////
    Private Sub btnPerfiles_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerfiles.Click
        Dim frm As New frmPerfiles
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnUsuarios_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnUsuarios.Click
        Dim frm As New frmUsuarios
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnAtencionSolicitud_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAtencionSolicitud.Click
        Dim frm As New frmSolicitudesUsuario
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnAdminIndicadorSolicitud_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAdminIndicadorSolicitud.Click
        Dim frm As New frmIndicadoresUsuario
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnAdminEncuesta_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAdminEncuesta.Click
        Dim frm As New frmEncuestasSistema
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnAdminResultadoEncuesta_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAdminResultadoEncuesta.Click
        Dim frm As New frmResultadosEncuestaSis
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnAdminLlamadas_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAdminLlamadas.Click
        Dim frm As New frmLlamadas
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnAdminParametrosLocacion_Click(sender As Object, e As CommandEventArgs) Handles btnAdminParametrosLocacion.Click
        Dim frm As New frmParametrosLocacion
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnAdminParametrosPlanilla_Click(sender As Object, e As CommandEventArgs) Handles btnAdminParametrosPlanilla.Click
        Dim frm As New frmParametrosPlanilla
        frm.MdiParent = Me
        frm.Show()
    End Sub

    '///////////////////////////////////////////////////////////////////

    '///////////////LOGUEO/////////////////
    Private Sub btnLogueoCerrarSesion_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnLogueoCerrarSesion.Click, btnCerrarSesion.Click
        If MsgBox("¿Está seguro de cerrar la sesion actual...?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            System.Diagnostics.Process.Start("SYSTECK.EXE")
            Close()
        End If
    End Sub

    Private Sub btnLogueoCambiarClave_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnLogueoCambiarClave.Click
        Dim frm As New frmCambioClave
        frm.MdiParent = Me
        frm.Show()
    End Sub
    '//////////////////////////////////////

    '///////MODULO GERENCIAL//////////
    Private Sub btnGerCreditos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnGerCreditos.Click
        Dim frm As New frmRepGerCtasCtes
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnGerImportaciones_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnGerImportaciones.Click
        Dim frm As New frmRepGerImportaciones
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnGerInventario_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnGerInventario.Click
        Dim frm As New frmInventarios
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnGerServicios_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnGerServicios.Click

    End Sub

    Private Sub btnGerVentas_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnGerVentas.Click
        Dim frm As New frmVentas
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnGerContabilidad_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnGerContabilidad.Click
        Dim frm As New frmRepContabilidad
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnGerFiltroIndicadores_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnGerFiltroIndicadores.Click
        Dim frm As New frmFiltroIndicadores
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnGerTarjeta_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnGerTarjeta.Click
        Dim frm As New frmTarjetaGerencia
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnGerConsolidado_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnGerConsolidado.Click
        Dim frm As New frmConsolidadoReportes
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnGerEstadosFinancieros_Click(sender As Object, e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnGerEstadosFinancieros.Click
        Dim frm As New frmEstadoFinanciero
        frm.MdiParent = Me
        frm.Show()
    End Sub
    '////////////////////////////////////

    '////////MODULO DE SERVICIOS//////////////
    Private Sub btnSerPedirRepuesto_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerPedirRepuesto.Click
        Dim frm As New frmServicios_PedRepuestos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnSerCotizacion_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerCotizacion.Click

        Dim frm As New frm_Ser_Cotizaciones
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnSerSolicitudJob_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerSolicitudJob.Click
        Dim frm As New frmSolicitudJob
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnSerJob_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerJob.Click
        Dim frm As New frmJob
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnSerRepMovRepuesto_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerRepMovRepuesto.Click
        Dim frm As New frmRepMovRepuestoServicio
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnSerConJob_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerConJob.Click
        Dim frm As New frmJobConsulta
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnSerMarcacionJob_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerMarcacionJob.Click
        Dim frm As New frm_Marcacion
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnSerRepHorasEscalon_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerRepHorasEscalon.Click
        Dim frm As New frmRepHorasEscalon
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnSerRepHorasGenerales_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerRepHorasGenerales.Click
        Dim frm As New frmRepHorasGenerales
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnSerConMarcacionJob_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerConMarcacionJob.Click
        Dim frm As New frmMarcacionConsulta
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnSerConGastoRealJob_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerConGastoRealJob.Click
        Dim frm As New frmGastoRealConsulta
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnSerKilometraje_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerKilometraje.Click
        Dim frm As New frmVehiculos
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnSerGastoReal_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerGastoReal.Click
        Dim frm As New frmGastoReal
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnSerGastoViaje_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerGastoViaje.Click
        Dim frm As New frmGastoViaje
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnSerRepTiempoReparacion_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerRepTiempoReparacion.Click
        Dim frm As New frmJobTiempoReparacion
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnSerRepCostosDirectos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerRepCostosDirectos.Click
        Dim frm As New frmRepGastosGenerales
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnSerRepGastosPorRubro_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerRepGastosPorRubro.Click
        Dim frm As New frmRptTotalxRubro
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnSerRepGastosViajePorRubro_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerRepGastosViajePorRubro.Click
        Dim frm As New frmRptGastosViajeTotalxRubro
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnSerRepJobGarantias_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerRepJobGarantias.Click
        Dim frm As New frmRptJobGarantia
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnSerRepJobPendienteFacturacion_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerRepJobPendienteFacturacion.Click
        Dim frm As New frmRptJobPendienteFacturacion
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnSerManOficinaUsuario_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerManOficinaUsuario.Click
        Dim frm As New frmMantOficinaUsuario
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnSerPreMarcacionJob_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerPreMarcacionJob.Click
        Dim frm As New frmPreMarcacion
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnSerAfa_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerAfa.Click
        Dim frm As New frmSolicitudGarantia
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnSerRepAfas_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerRepAfas.Click
        Dim frm As New frmRptSolicitudGarantia
        frm.MdiParent = Me
        frm.Show()
    End Sub


    Private Sub btnSerRepCotizaciones_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerRepCotizaciones.Click
        Dim frm As New frmRepCotizacion
        frm.MdiParent = Me
        frm.Show()
    End Sub


    Private Sub btnSerRepSolicitudJob_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerRepSolicitudJob.Click
        Dim frm As New frmRptSolicitudJob
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnSerRepJob_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerRepJob.Click
        Dim frm As New frmRepJob
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnSerIndActividades_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerIndActividades.Click
        Dim frm As New FrmActividades
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnSerIndPlantilla_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerIndPlantilla.Click
        Dim frm As New frmPlantillaServicios
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnSerIndProgramacion_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerIndProgramacion.Click
        Dim frm As New frmProgramacionJob
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnSerIndTablero_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerIndTablero.Click
        Dim frm As New frmIndicadoresServicio
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnSerRepHorasMuertas_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerRepHorasMuertas.Click
        Dim frm As New frmRepHorasMuertas
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnSerIndProductividad_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerIndProductividad.Click
        Dim frm As New frmProductividad
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnSerProHorasMotor_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerProHorasMotor.Click
        Dim frm As New frmHorasMotor
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnSerProEquipos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerProEquipos.Click
        Dim frm As New frmMotores
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnSerProSeguimiento_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerProSeguimiento.Click
        Dim frm As New frmSeguimientos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnSerRepHorasMotores_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerRepHorasMotores.Click
        Dim frm As New frmRepHorasMotor
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnSerRepDisponibilidad_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerRepDisponibilidad.Click
        Dim frm As New frmRepDisponibilidadMotores
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnSerRepMotorDarBaja_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerRepMotorDarBaja.Click
        Dim frm As New frmRepMotorDarBajaR
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnSerRepProyeccionRepImportar_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerRepProyeccionRepImportar.Click
        Dim frm As New frmRepConsumir
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnSerRepProyeccionVentas_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerRepProyeccionVentas.Click
        Dim frm As New frmRepVentProxMant
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnSerProRepuestos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerProRepuestos.Click
        Dim frm As New frmMantenimientoRepuestos
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnSerRepSeguimientos_Click(sender As Object, e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerRepSeguimientos.Click
        Dim frm As New frmRepSeguimiento
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnSerRepProyeccionReparaciones_Click(sender As Object, e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSerRepProyeccionReparaciones.Click
        Dim frm As New frmRepProyeccionRepAnuales
        frm.MdiParent = Me
        frm.Show()
    End Sub
    '///////////////////////////////////////////////////

    '////////MENU DE AYUDA/////////////
    Private Sub btnSolicitudUsuario_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnSolicitudUsuario.Click
        Dim frm As New frmAyuda_SolicitudUsuarios
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnAyuda_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAyuda.Click
        ' System.Diagnostics.Process.Start("tablaMercaderia.swf")
        System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.BaseDirectory & "Version\version.html")

        'Dim ruta As String = System.AppDomain.CurrentDomain.BaseDirectory & "AdminMarcador\Comunicacion.exe"
        'Shell(ruta, AppWinStyle.NormalFocus)


    End Sub

    Private Sub btnAcerca_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnAcerca.Click
        Dim frm As New frmAyuda_Acerca
        frm.MdiParent = Me
        frm.Show()
    End Sub

    '/////////////////////////////////


    '////////MODULO DE COMPRAS///////// 
    Private Sub btnComSolicitud_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnComSolicitud.Click
        Dim frm As New frmComSolicitudCompras
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnComOrdenCompra_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnComOrdenCompra.Click
        Dim frm As New frmComOrdenesCompra
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnComCotizacionSolicitud_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnComCotizacionSolicitud.Click
        Dim frm As New frmComCotizacionesSolicitud
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnComSolicitudGasto_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnComSolicitudGasto.Click
        Dim frm As New frmComSolicitudGastosNew
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnComMesaControl_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnComMesaControl.Click
        Dim frm As New frmComMesaControl
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnComPlanillaViatico_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnComPlanillaViatico.Click
        Dim frm As New frmPlanillasViatico
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnComConsultaCompras_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnComConsultaCompras.Click
        Dim frm As New frmConsultaCompras
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnComRepOrdenes_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnComRepOrdenes.Click
        Dim frm As New frmRepOrdenCompra
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnComRepSolicitudGasto_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnComRepSolicitudGasto.Click
        Dim frm As New frmRepSolicitudGasto
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnComTarifa_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnComTarifa.Click
        Dim frm As New frmTarifasGastoViaje
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnComTarifaCasa_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnComTarifaCasa.Click
        Dim frm As New frmTarifasCasaAeropuerto
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnComRepMesaControl_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnComRepMesaControl.Click
        Dim frm As New frmRepMesaControl
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnComTarifaDestino_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnComTarifaDestino.Click
        Dim frm As New frmTarifasTaxi
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnComRepCtasPorPagar_Click(sender As Object, e As CommandEventArgs) Handles btnComRepCtasPorPagar.Click
        Dim frm As New frmRepCtasxPagar
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnComRepVencimientosCtasPorPagar_Click(sender As Object, e As CommandEventArgs) Handles btnComRepVencimientosCtasPorPagar.Click
        Dim frm As New frmRepVencCtasxPagar
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnComRepPagosCtasPorPagar_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnComRepPagosCuentasPorPagar.Click
        Dim frm As New frmRepPagosCtasxPagar
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnComRepCtasPorPagarUnidad_Click(sender As Object, e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnComRepCtasPorPagarUnidad.Click
        Dim frm As New frmRepCtasxPagarUnidad
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnComCuentasPorPagar_Click(sender As Object, e As CommandEventArgs) Handles btnComCuentasPorPagar.Click
        Dim frm As New frmCuentasPorPagar
        frm.MdiParent = Me
        frm.Show()
    End Sub

    '///////////////////////////////////////////////

    '//////////////CONTABILIDAD/////////////
    Private Sub btnConProvisional_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnConProvisional.Click
        Dim frm As New frmProvisionales
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnConReembolso_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnConReembolso.Click
        Dim frm As New frmReembolsos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnConArqueoCaja_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnConArqueoCaja.Click
        Dim frm As New frmArqueoCaja
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnConRepCtasPorPagar_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnConRepCtasPorPagar.Click
        Dim frm As New frmRepCtasxPagarConta
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnConRepVencimientos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnConRepVencimientos.Click
        Dim frm As New frmRepVencCtasxPagarConta
        frm.MdiParent = Me
        frm.Show()
    End Sub



    Private Sub btnConRepReembolso_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnConRepReembolso.Click
        Dim frm As New frmRepReembolsoxGasto
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnConTesoreria_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnConTesoreria.Click
        Dim frm As New frmAsientos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnConRegistroCompra_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnConRegistroCompra.Click
        Dim frm As New frmRegComprasPrincipal
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnConReciboHonorario_Click(sender As Object, e As CommandEventArgs) Handles btnConReciboHonorario.Click
        Dim frm As New frmReciboHonorarios
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnConDiario_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnConDiario.Click
        Dim frm As New frmDiario
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnConRepRegistroCompra_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnConRepRegistroCompra.Click
        Dim frm As New frmRepRegCompra
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnConProCuentaDestino_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnConProCuentaDestino.Click
        Dim frm As New frmProcesarCtaDestino
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnConProCierreMes_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnConProCierreMes.Click
        Dim frm As New frmProcesarCierreMes
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnConRepLibroDiario_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnConRepLibroDiario.Click
        Dim frm As New frmRepLibroDiario
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnConRepLibroMayor_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnConRepLibroMayor.Click
        Dim frm As New frmRepLibroMayor
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnConRepEstadosFinancieros_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnConRepEstadosFinancieros.Click
        Dim frm As New frmRepBalance
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnConRepCajaBancos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnConRepCajaBancos.Click
        Dim frm As New frmRepCajaBancos
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnConProDifTipoCambio_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnConProDifTipoCambio.Click
        Dim frm As New frmProcesarDifTipCamb
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnConRepCtasCtes_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnConRepCtasCtes.Click
        Dim frm As New frmRepContCtasCtes
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnConRepCtasCtesPend_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnConRepCtasCtesPend.Click
        Dim frm As New frmRepContCtasCtesPend
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnConRepMayorAuxiliar_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnConRepMayorAuxiliar.Click
        Dim frm As New frmRepMayorAuxiliar
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnConMovimientoBanco_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnConMovimientoBanco.Click
        Dim frm As New frmMovimientoBancos
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnConRepChequesGirados_Click(sender As Object, e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnConRepChequesGirados.Click
        Dim frm As New frmRepChequesGirados
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnConGenerarTXTLibros_Click(sender As Object, e As CommandEventArgs) Handles btnConGenerarTXTLibros.Click
        Dim frm As New frmGenerarArchivoTXT
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnConProFlujoCaja_Click(sender As Object, e As CommandEventArgs) Handles btnConProFlujoCaja.Click
        Dim frm As New frmFlujosCaja
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnCreMantenimientoTipoCambio_Click(sender As Object, e As CommandEventArgs) Handles btnCreMantenimientoTipoCambio.Click
        Dim frm As New frmTipo_Cambio
        frm.MdiParent = Me
        frm.Show()
    End Sub

    '////////////////////////////////////

    '////////PERSONAL/////////
    Private Sub btnPerInfDatos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerInfDatos.Click
        Dim frm As New frmColaboradores
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnPerPlanilla_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerPlanilla.Click
        Dim frm As New frmPlanillasSueldos
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnPerRepPlanillaSueldos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerRepPlanillaSueldos.Click
        Dim frm As New frmRepPlanillaOficial
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnPerAsigFaltas_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerAsigFaltas.Click
        Dim frm As New frmFaltasPersonal
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnPerAsigMarcas_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerAsigMarcas.Click
        Dim frm As New frmMarcacionesPersonal
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnPerInfVacaciones_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerInfVacaciones.Click
        Dim frm As New frmVacaciones
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnPerAsigHoraExtra_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerAsigHoraExtra.Click
        Dim frm As New frmAsignacionesHE
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnPerRegistroHoraExtra_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerRegistroHoraExtra.Click
        Dim frm As New frmHorasExtra
        frm.MdiParent = Me
        frm.Show()
    End Sub


    Private Sub btnPerAsigDescuentos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerAsigDescuentos.Click
        Dim frm As New frmDescuentosPersonal
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnPerAsigJefes_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerAsigJefes.Click
        Dim frm As New frmAsignacionesJefes
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnPerAsigRecursos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerAsigRecursos.Click
        Dim frm As New frmAsignacionesRecursos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnPerAsigHorario_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerAsigHorario.Click
        Dim frm As New frmAsignacionesHorario
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnPerAsigIngresos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerAsigIngresos.Click
        Dim frm As New frmIngresosPersonal
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnPerRepAsignacionHoraExtra_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerRepAsignacionHoraExtra.Click
        Dim frm As New frmRepAsignacionHE
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnPerRepAsistencia_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerRepAsistencia.Click
        Dim frm As New frmRepAsistencias
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnPerRepDescuentos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerRepDescuentos.Click
        Dim frm As New frmRepDescuentos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnPerRepFaltas_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerRepFaltas.Click
        Dim frm As New frmRepFaltasPersonal
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnPerRepHoraExtra_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerRepHoraExtra.Click
        Dim frm As New frmRepHorasExtra
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnPerRepIngresos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerRepIngresos.Click
        Dim frm As New frmRepIngresos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnPerRepPersonal_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerRepPersonal.Click
        Dim frm As New frmRepPersonal
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnPerRepRecursos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerRepRecursos.Click
        Dim frm As New frmRepAsignacionRecurso
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnPerRepTardanzas_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerRepTardanzas.Click
        Dim frm As New frmRepTardanzas
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnPerRepVacaciones_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerRepVacaciones.Click
        Dim frm As New frmRepVacaciones
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnPerInfContratos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerInfContratos.Click
        Dim frm As New frmContratos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnPerComAdminLector_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerComAdminLector.Click
        'Dim frm As New frmAdminLector
        'frm.MdiParent = Me
        'frm.Show()
        Dim ruta As String = System.AppDomain.CurrentDomain.BaseDirectory & "AdminMarcador\Comunicacion.exe"
        Shell(ruta, AppWinStyle.NormalFocus)

    End Sub
    Private Sub btnPerInfCapacitacion_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerInfCapacitacion.Click
        Dim frm As New frmCapacitaciones
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnPerRepCapacitacion_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerRepCapacitacion.Click
        Dim frm As New frmRepCapacitacion
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnPerRepContratos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerRepContratos.Click
        Dim frm As New frmRepContratos
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnPerComProcesarMarcas_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerComProcesarMarcas.Click
        Dim frm As New frmProcesarMarcas
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnPerRepOnomasticos_Click(ByVal sender As Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPerRepOnomasticos.Click
        Dim frm As New frmRepOnomasticos
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnPerAsigCronogramaMina_Click(sender As Object, e As CommandEventArgs) Handles btnPerAsigCronogramaMina.Click
        Dim frm As New frmCronogramaMinas
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnPerRepAsigHorario_Click(sender As Object, e As CommandEventArgs) Handles btnPerRepAsigHorario.Click
        Dim frm As New frmRepAsignacionHorario
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub btnPerQuintaCategoria_Click(sender As Object, e As CommandEventArgs) Handles btnPerQuintaCategoria.Click
        Dim frm As New frmQuintaCategorias
        frm.MdiParent = Me
        frm.Show()
    End Sub



    '/////////////////////////
    'Ventana Emergente / NotifyWindow
    Private Sub VentanaEmergente()

        TVEmerg.Start()

    End Sub


    Private Sub TVEmerg_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TVEmerg.Tick

        ObtenerDatos()

    End Sub

    Private Sub ObtenerDatos()

        Try
            Mensaje = oSeguridadServiceMensaje.AlertaSistema(Session.sCodEmp, Session.sCodUsu, 1)

            If Mensaje <> "" Then
                MostrarMensaje()
            End If

        Catch ex As CommunicationException
            oSeguridadServiceMensaje.Abort()
            Me.Close()
        End Try

    End Sub

    Private Sub MostrarMensaje()

        Dim nw As NotifyWindow
        nw = New NotifyWindow("SYSTECK", Mensaje)

        nw.Font = New Font("Microsoft Sans Serif", 10.25F)
        nw.TitleFont = New Font("Microsoft Sans Serif", 10.25F, FontStyle.Bold)

        AddHandler nw.TitleClicked, New System.EventHandler(AddressOf titleClick)

        AddHandler nw.TextClicked, New System.EventHandler(AddressOf textClick)
        'nw.SetDimensions(CInt(Math.Truncate(240)), CInt(Math.Truncate(180)))
        nw.SetDimensions(CInt(Math.Truncate(240)), CInt(Math.Truncate(180)))
        nw.Notify()

    End Sub

    'Comentado porque Gerencia lo dispuso
    Private Sub VentanaOnomasticos()

        Dim VerAlerta As Boolean = False
        VerAlerta = oSeguridadService.RecibirAlerta(Session.sCodUsu)

        If VerAlerta Then
            Dim dtOnomasticos As DataTable
            dtOnomasticos = oSeguridadServiceMensaje.MostrarOnomasticosEmpresa(Session.sCodEmp).Tables(0)

            If dtOnomasticos.Rows.Count > 0 Then
                Dim frm As New frmOnomasticos
                frm.ShowDialog()
            End If

        End If



    End Sub

    Private Sub VentanaNavidad()
        Dim value As Integer
        Dim rn As New Random
        value = rn.Next(1, 7)
        If value = 1 Then
            Dim frm As New frmAviso1
            frm.ShowDialog()
        ElseIf value = 2 Then
            Dim frm As New frmAviso2
            frm.ShowDialog()
        ElseIf value = 3 Then
            Dim frm As New frmAviso3
            frm.ShowDialog()
        ElseIf value = 4 Then
            Dim frm As New frmAviso4
            frm.ShowDialog()
            'ElseIf value = 5 Then
            '    Dim frm As New frmAviso5
            '    frm.ShowDialog()
            'ElseIf value = 6 Then
            '    Dim frm As New frmAviso6
            '    frm.ShowDialog()
            'ElseIf value = 7 Then
            '    Dim frm As New frmAviso5
            '    frm.ShowDialog()
        End If
        'Dim frm As New frmAvisos
        'frm.ShowDialog()
    End Sub

    Private Sub titleClick(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub textClick(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    ''Comentado porque Gerencia lo dispuso
    'Private Sub MDIPrincipal_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
    '    Dim VerAlerta As Boolean = False
    '    VerAlerta = oSeguridadService.RecibirAlerta(Session.sCodUsu)

    '    If VerAlerta Then
    '        VentanaOnomasticos()
    '    End If

    'End Sub

    '//////////////RONDAS//////////////////
    Private Sub btnPuntosControlRutas_Click(sender As Object, e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnPuntosControlRutas.Click
        Dim frm As New frmPuntosRuta
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnRondas_Click(sender As Object, e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnRondas.Click
        'Dim frm As New frm
        'frm.MdiParent = Me
        'frm.Show()
    End Sub

    Private Sub btnRuteadorRutas_Click(sender As Object, e As Janus.Windows.Ribbon.CommandEventArgs) Handles btnRuteadorRutas.Click
        Dim frm As New frmRutasRuteador
        frm.MdiParent = Me
        frm.Show()
    End Sub


    '///////////////TELEFONIA///////////////////
    Private Sub btnTelAsignaLinea_Click(sender As Object, e As CommandEventArgs) Handles btnTelAsignaLinea.Click
        Dim frm As New frmAsignacionesPersona
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnTelEquipos_Click(sender As Object, e As CommandEventArgs) Handles btnTelEquipos.Click
        Dim frm As New frmEquiposTelefonia
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnTelLineas_Click(sender As Object, e As CommandEventArgs) Handles btnTelLineas.Click
        Dim frm As New frmLineasTelefonia
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnTelModelos_Click(sender As Object, e As CommandEventArgs) Handles btnTelModelos.Click
        Dim frm As New frmModelosTelefonia
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnTelPlanes_Click(sender As Object, e As CommandEventArgs) Handles btnTelPlanes.Click
        Dim frm As New frmPlanesTelefonia
        frm.MdiParent = Me
        frm.Show()
    End Sub
    '//////////////////////////////////////////////


    '/////////INVENTARIO SOFTWARE/////////////////
    Private Sub btnAdminSoftwareComputadora_Click(sender As Object, e As CommandEventArgs) Handles btnAdminSoftwareComputadora.Click
        Dim frm As New frmComputadoras
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnAdminSoftwareAsignar_Click(sender As Object, e As CommandEventArgs) Handles btnAdminSoftwareAsignar.Click
        Dim frm As New frmAsignacionesComputadora
        frm.MdiParent = Me
        frm.Show()
    End Sub

    '////////TABLAS GENERALES DEL SISTEMA/////////
    Private Sub btnAdminEquiposMarcacion_Click(sender As Object, e As CommandEventArgs) Handles btnAdminEquiposMarcacion.Click
        Dim frm As New frmEquiposMarcacion
        frm.MdiParent = Me
        frm.Show()
    End Sub


    Private Sub btnManteRepuestosPorMantenimiento_Click(sender As Object, e As CommandEventArgs) 
        Dim frm As New frmMantenimientoRepuestos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnImpRepPedido_Click(sender As Object, e As CommandEventArgs) Handles btnImpRepPedido.Click
        Dim frm As New frmReportePedidos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnSerProGenerarPedidoInterno_Click(sender As Object, e As CommandEventArgs) Handles btnSerProGenerarPedidoInterno.Click
        Dim frm As New frmGenerarPedidoInternoMantenimiento
        frm.MdiParent = Me
        frm.Show()
    End Sub
    '//////////////////////////////////////


    '/////////CRM///////////////
    Private Sub btnCRMOportIngresar_Click(sender As Object, e As CommandEventArgs) Handles btnCRMOportIngresar.Click
        Dim frm As New frmOportunidadesNegocio
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCRMRepOportunidad_Click(sender As Object, e As CommandEventArgs) Handles btnCRMRepOportunidad.Click
        Dim frm As New frmRepOportunidadNegocio
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCRMOcurrencias_Click(sender As Object, e As CommandEventArgs) Handles btnCRMOcurrencias.Click
        Dim frm As New frmOcurrenciasCliente
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCRMTarjetaCliente_Click(sender As Object, e As CommandEventArgs) Handles btnCRMTarjetaCliente.Click
        Dim frm As New frmEstadoCliente
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCRMVisitas_Click(sender As Object, e As CommandEventArgs) Handles btnCRMVisitas.Click
        Dim frm As New frmVisitasClientes
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCRMRepVisitas_Click(sender As Object, e As CommandEventArgs) Handles btnCRMRepVisitas.Click
        Dim frm As New frmRepVisitaCliente
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnSesiones_Click(sender As Object, e As CommandEventArgs) Handles btnSesiones.Click
        Dim frm As New frmSesiones
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnPerRepCronogramaMina_Click(sender As Object, e As CommandEventArgs) Handles btnPerRepCronogramaMina.Click
        Dim frm As New frmRepCronogramaMina
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnAlmManUbicacion_Click(sender As Object, e As CommandEventArgs) Handles btnAlmManUbicacion.Click
        Dim frm As New frmUbicaciones
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnCRMCuotas_Click(sender As Object, e As CommandEventArgs) Handles btnCRMCuotas.Click
        Dim frm As New frmCuotasVendedor
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnAlmAlmDespacho_Click(sender As Object, e As CommandEventArgs) Handles btnAlmAlmDespacho.Click
        Dim frm As New frmDespachos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnSerReclamoCliente_Click(sender As Object, e As CommandEventArgs) Handles btnSerReclamoCliente.Click
        Dim frm As New frmReclamosCliente
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnPerInfEvaluacion_Click(sender As Object, e As CommandEventArgs) Handles btnPerInfEvaluacion.Click
        Dim frm As New frmEvaluaciones
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnAdminEmpresas_Click(sender As Object, e As CommandEventArgs) Handles btnAdminEmpresas.Click
        Dim frm As New frmManteEmpresas
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnAdminSeriesDocumentos_Click(sender As Object, e As CommandEventArgs) Handles btnAdminSeriesDocumentos.Click
        Dim frm As New frmSerieDocumentos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnAdminLocaciones_Click(sender As Object, e As CommandEventArgs) Handles btnAdminLocaciones.Click
        Dim frm As New frmLocaciones
        frm.MdiParent = Me
        frm.Show()
    End Sub

    '///////////ACTIVOS FIJOS////////////////
    Private Sub btnActivoDatos_Click(sender As Object, e As CommandEventArgs) Handles btnActivoDatos.Click
        Dim frm As New frmActivosFijos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnActivoReporte_Click(sender As Object, e As CommandEventArgs) Handles btnActivoReporte.Click
        Dim frm As New frmRepActivoFijo
        frm.MdiParent = Me
        frm.Show()
    End Sub
    '////////////////////////////////////

    Public Function isOpened(ByVal frm As Form) As Boolean?
        Dim frmCol As New FormCollection()
        frmCol = Application.OpenForms
        Dim Cnt As Integer = 0
        For Each f As Form In frmCol
            If f.Name = frm.Name Then Cnt += 1 Next
        Return IIf(Cnt > 0, True, False)
    End Function

    Private Sub btnLogueoEmpresas_Click(sender As Object, e As CommandEventArgs) Handles btnLogueoEmpresas.Click, btnCambiarEmpresa.Click

        'Dim oSeguridadService As New SeguridadService.SeguridadClient
        'Dim oAprobarVentaService As New AprobarVentaService.AprobarVentaServiceClient

        If MdiChildren.Length > 1 Then
            'MessageBox.Show("Hay un formulario abierto")
            MsgBox("Debe cerrar las ventanas activas, antes de proceder a cambiar de empresa.", MsgBoxStyle.Information, "Información")

        Else
            Dim frm As New frmEmpresas

            ' If oSeguridadService.AccesoMultiEmpresa(Session.sCodUsu) Then
            frm.CodUsu = Session.sCodUsu
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Session.sCodEmp = frm.CodEmp
                Session.sDesEmp = frm.DesEmp

                '///////OBTENER DATOS SUNAT////////
                Dim empresa As New SeguridadService.Empresa
                Dim ObjSeg As New SeguridadService.SeguridadClient
                empresa = ObjSeg.ObtenerEmpresa(Session.sCodEmp)
                Session.sUsuarioSunat = empresa.UsuarioSOL
                Session.sClaveSunat = empresa.ClaveSOL
                Session.sNombreCertificado = empresa.NombreCertificado
                Session.sClaveCertificado = empresa.ClaveCertificado
                Session.sRucEmp = empresa.RucEmp
                Session.sCodUbigeo = empresa.Ubigeo.CodUbigeo
                Session.sDireccion = empresa.DirEmp
                Session.sDepartamento = empresa.Ubigeo.Departamento.NomDpto
                Session.sProvincia = empresa.Ubigeo.Provincia.NomProv
                Session.sDistrito = empresa.Ubigeo.Distrito.NomDist
                Session.sIGV = empresa.Igv
                Session.sUsuarioOSE = empresa.UsuarioOSE
                Session.sClaveOSE = empresa.ClaveOSE
                Session.sAplicaOSE = empresa.AplicaOSE
                Session.sCorreoEmisor = empresa.CorreoEmisor
                Session.sClaveCorreoEmisor = empresa.ClaveCorreoEmisor
                Session.sMailHost = empresa.MailHost
                'Session.sLogo = empresa.Logo
                '//////////////////////////////////

                MostrarLogo()
                ActivarMenu()

                Try
                    ObjSeg.Close()
                Catch ex As TimeoutException
                    ObjSeg.Abort()
                Catch ex As CommunicationException
                    ObjSeg.Abort()
                End Try

            End If

            'MessageBox.Show("No hay formulario")
        End If


        'Else
        'MsgBox("No tiene acceso a multiempresas, consulte con su Jefe!!!!!!!!", "Alerta!!!!!")
        'End If
    End Sub

    Private Sub btnCreRepClientes_Click(sender As Object, e As CommandEventArgs) Handles btnCreRepClientes.Click
        Dim frm As New frmRepClientes
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnAdminRubros_Click(sender As Object, e As CommandEventArgs) Handles btnAdminRubros.Click
        Dim frm As New frmMantRubros
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnAdminRubroEmpresa_Click(sender As Object, e As CommandEventArgs) Handles btnAdminRubroEmpresa.Click
        Dim frm As New frmRubrosxEmpresa
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnVenPreciosFabricantes_Click(sender As Object, e As CommandEventArgs) Handles btnVenPreciosFabricantes.Click
        Dim frm As New frmListaPrecioFabricante
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnVenPreciosRubrosEmpresa_Click(sender As Object, e As CommandEventArgs) Handles btnVenPreciosRubrosEmpresa.Click
        Dim frm As New frmRubrosEmpresa
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnConRepProvisionales_Click(sender As Object, e As CommandEventArgs) Handles btnConRepProvisionales.Click
        Dim frm As New frmRepProvisional
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnAlmAlmDatosDespacho_Click(sender As Object, e As CommandEventArgs) Handles btnAlmAlmDatosDespacho.Click
        Dim frm As New frmDatosDespachos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnSerMarcacionOT_Click(sender As Object, e As CommandEventArgs) Handles btnSerMarcacionOT.Click
        Dim frm As New frmMarcarOT
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnPerMarcaccionOnline_Click(sender As Object, e As CommandEventArgs) Handles btnPerMarcaccionOnline.Click
        Dim frm As New frmMarcacionOnline
        frm.MdiParent = Me
        frm.Show()
    End Sub
    '////////////////////////////////////////

End Class