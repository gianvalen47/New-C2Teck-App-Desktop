import { Children, createContext, isValidElement, useContext, useState, useRef, useEffect, useCallback, type ReactNode, type CSSProperties, type RefObject, type MouseEvent as ReactMouseEvent } from "react";
import { createPortal } from "react-dom";
import * as React from 'react';
import systeckIcon from "@/assets/Systeck.ico";
import logoC2 from "@/assets/Logos/LogoC2teck02.png";
import {
  X, Check, Save, Printer, Search, Plus, Trash2, FileDown, FileSpreadsheet,
  Mail, Send, RefreshCw, Filter, Calendar, DollarSign, User, Package,
  Wrench, Clock, Car, MapPin, Phone, Users, GraduationCap, Fingerprint, Play, Square,
  Minus, Maximize2, Minimize2, Copy, Zap, Receipt, LogOut, Settings, ArrowDown, ArrowRight, FileSearch, Percent, CreditCard, Pencil, BarChart3, TrendingUp, TrendingDown, Activity, Brain, Server, ShieldAlert, Sparkles, FileText
} from "lucide-react";
import {
  inp,
  btn,
  Field,
  Toolbar,
  DataTable,
  WindowShell,
  SearchBar,
  Fs,
  Radio,
  CalculationSummaryBlock,
  MasterDetailForm,
  ListQueryForm,
  LookupDialog,
} from "@/components/ui/desktop-primitives";
import { Glyph } from "@/features/escritorio/glyphs";
import c2teckWatermark from "@/assets/Logos/LogoC2teck02.png";
import { toast } from "sonner";
import { getLogoUrl } from "@/lib/company-logos";
import { useSession } from "@/context/SessionContext";
// Legacy monolith renderer fallback
import {
  WindowsProvider,
  useWindows,
  openDesktopWindow,
  normalizeWindowLabel,
  normalizeWindowLookupKey,
  DESKTOP_STATUS_BAR_H,
  type WindowSize,
  type WindowPos,
  type OpenWindow,
} from "@/context/WindowsContext";
import { enhanceToolbar } from "./windows/shared/toolbars";
import { RibbonPlaceholder } from "./windows/shared/RibbonPlaceholder";

// Specific feature windows (moved to their own modules)
import { ConsultaPreciosDialogList, ConsultaPreciosDialog } from "./windows/Precios/ConsultaPreciosDialog";

// Additional window components referenced in legacy monolith
import { NewGuideWindow } from "./NewGuideWindow";

import { ReporteContainer } from "./windows/Reportes/ReporteContainer";

// Destinos del ribbon sin import previo
import { ReporteActivosFijosWindow } from "./windows/Activos/Reportes/ReporteActivosFijos";

// VENTAS
// Documentos
import { GuiaRemision, NuevaGuia, GuiaRemisionList, GuiaRemisionForm } from "./windows/Ventas/Documentos/GuiasRemision";
import { FacturaVentaList, Factura } from "./windows/Ventas/Documentos/Facturas";
import { NotaVentaList, NotaForm as NotaVentaForm, NuevaNota, Notas } from "./windows/Ventas/Documentos/Notas";
import { GuiaDevolucion, GuiaDevolucionList } from "./windows/Ventas/Documentos/GuiasDevolucion";
import { Boleta, BoletaList } from "./windows/Ventas/Documentos/Boletas";
import { ResumenBoletas, ResumenDeBoletasList } from "./windows/Ventas/Documentos/ResumenDeBoletas";

// Pre y Post Venta
import { Cotizaciones, CotizacionesList } from "./windows/Ventas/Pre y Post Venta/Cotizaciones";
import { ReclamoGarantia, ReclamoGarantiaList } from "./windows/Ventas/Pre y Post Venta/ReclamoGarantia";
import { SepararOrden } from "./windows/Ventas/Pre y Post Venta/SepararOrden";
import { OrdenesCompra, OrdenesCompraList } from "./windows/Ventas/Pre y Post Venta/OrdenesCompra";
import { ActualizarVendedor, ActualizarVendedorList } from "./windows/Ventas/Pre y Post Venta/ActualizarVendedor";
import { EnviarCorreos, EnviarCorreosList } from "./windows/Ventas/Pre y Post Venta/EnviarCorreos";

// Clientes
import { Cartera, CarteraList } from "./windows/Ventas/Clientes/Cartera";

// Requisiciones
import { Despacho, DespachoList } from "./windows/Ventas/Requisiciones/Despacho";

// Consultas
import { PrecioConsulta, PrecioConsultaList } from "./windows/Ventas/Consultas/Precios";
import { ConsultaDocumentosVentaWindow, ConsultaDocumentosVentaList } from "./windows/Ventas/Consultas/Documentos";

// Indicadores
import { TableroIndicador, TableroIndicadorList } from "./windows/Ventas/Indicadores/Tablero";

// Precios
import { PrecioClienteList, PrecioCliente } from "./windows/Ventas/Precios/PrecioCliente";
import { PrecioOfertaList, PrecioOferta } from "./windows/Ventas/Precios/PrecioOferta";
import { PrecioListaList, PrecioLista } from "./windows/Ventas/Precios/PrecioLista";
import { PrecioFabricantesList, PrecioFabricantes } from "./windows/Ventas/Precios/PrecioFabricantes";
import { FactoresRubrosList, FactoresRubros } from "./windows/Ventas/Precios/FactoresRubros";

// Reportes
// Registro
import { RegistroVenta, RegistroVentaList } from "./windows/Ventas/Registro/RegistroVenta";
import { RegistroAuxiliarList, RegistroAuxiliar } from "./windows/Ventas/Registro/RegistroAuxiliar";
import { ResumenRegistroList, ResumenRegistro } from "./windows/Ventas/Registro/ResumenRegistro";

import { ReporteVentasDetalladoList, ReporteVentasDetallado, ReporteDetalle } from "./windows/Ventas/Reportes/Detalle";
import { ReporteAcumulada, ReporteAcumuladaList } from "./windows/Ventas/Reportes/Acumulada";
import { ReporteGRPendiente, ReporteGRPendienteList } from "./windows/Ventas/Reportes/GRPendiente";
import { ReporteCotizaciones, ReporteCotizacionesList } from "./windows/Ventas/Reportes/Cotizaciones";
import { ReporteValeRequisicionList, ReporteValeRequisicion } from "./windows/Ventas/Reportes/ValeRequisicion";
import { ReporteMensualClienteList, ReporteMensualCliente } from "./windows/Ventas/Reportes/MensualesXCliente";
import { ReporteDetalleDescuentoList, ReporteDetalleDescuento } from "./windows/Ventas/Reportes/DetalleDescuento";
import { ReporteReclamosList, ReporteReclamos } from "./windows/Ventas/Reportes/Reclamos";
import { ReporteOrdenCompra, ReporteOrdenCompraList } from "./windows/Ventas/Reportes/OrdenesCompra";
import { ReporteConsignacionList, ReporteConsignacion } from "./windows/Ventas/Reportes/Consignaciones";
import { ReporteGuiasRemision, ReporteGuiasRemisionList } from "./windows/Ventas/Reportes/GuiasRemision";
import { ReportePresupuestoVenta, ReportePresupuestoVentaList } from "./windows/Ventas/Reportes/PresupuestoVenta";
import { ReporteComisiones, ReporteComisionesList } from "./windows/Ventas/Reportes/Comisiones";

// ALMACENES
// Almacén
import { DocIngresos, DocIngresosList } from "./windows/Almacenes/Almacen/DocIngresos";
import { DocSalidas, DocSalidasList } from "./windows/Almacenes/Almacen/DocSalidas";
import { ChequeoFI, ChequeoFIList } from "./windows/Almacenes/Almacen/ChequeoFI";
import { AlmacenTI, AlmacenTIList } from "./windows/Almacenes/Almacen/TI";
import { AlmacenMTI, AlmacenMTIList } from "./windows/Almacenes/Almacen/MTI";
import { AtenderOT, AtenderOTList } from "./windows/Almacenes/Almacen/AtenderOT";
import { DespachoWindow, DespachoList2 } from "./windows/Almacenes/Almacen/Despacho";
import { Vales, ValesList } from "./windows/Almacenes/Almacen/Vales";

// Motores
import { MemosTransferenciasInternas, MemosTransferenciasInternasList } from "./windows/Almacenes/Motores/Transferencias";
import { CompraMotores, CompraMotoresList } from "./windows/Almacenes/Motores/Compras";

// Transito
import { TransitoDocs, TransitoDocsList } from "./windows/Almacenes/Transito/Documentos";
import { AnulacionConsulta, AnulacionConsultaList } from "./windows/Almacenes/Transito/AnulacionEnConsulta";

// Mantenimiento
import { LiquiGastos, LiquiGastosList } from "./windows/Almacenes/Mantenimiento/LiquiGastos";
import { ActMinMax, ActMinMaxList } from "./windows/Almacenes/Mantenimiento/ActMinMax";
import { UbicacionesList, Ubicaciones } from "./windows/Almacenes/Mantenimiento/Ubicaciones";
import { MantenimientoProductos, MantenimientoProductosList } from "./windows/Almacenes/Mantenimiento/Productos";

// Consultas
import { Tarjetas, TarjetasList } from "./windows/Almacenes/Consultas/Tarjetas";
import { DocumentoConsulta, DocumentoConsultaList } from "./windows/Almacenes/Consultas/Documentos";

// Indicadores
import { ProcesarCobertura, ProcesarCoberturaList } from "./windows/Almacenes/Indicadores/ProcesarCobertura";
import { Calendario, CalendarioList } from "./windows/Almacenes/Indicadores/Calendario";
import { IndicadoresVentaDialog, IndicadoresVentaDialogList } from "./windows/Almacenes/Indicadores/Tablero";

// Reportes
import { ValeMaterialesReport, ValeMaterialesReportList } from "./windows/Almacenes/Reportes/ValeMateriales";
import { TomaInventarioReport, TomaInventarioReportList } from "./windows/Almacenes/Reportes/TomaDeInventario";
import { SinMovimientoReport, SinMovimientoReportList } from "./windows/Almacenes/Reportes/SinMovimiento";
import { MovimientosAlmacenReport, MovimientosAlmacenReportList } from "./windows/Almacenes/Reportes/Movimientos";
import { DocumentoReporte, DocumentoReporteList } from "./windows/Almacenes/Reportes/Documentos";
import { ReporteValorizado, ReporteValorizadoList } from "./windows/Almacenes/Reportes/InvPermValorizado";
import { ReporteInventario, ReporteInventarioList } from "./windows/Almacenes/Reportes/Inventario";
import { ReporteTransferencia, ReporteTransferenciaList } from "./windows/Almacenes/Reportes/Transferencias";

// CREDITOS
// Documentos
import { Anticipos, AnticiposList } from "./windows/Creditos/Documentos/Anticipos";
import { Planillas, PlanillasList } from "./windows/Creditos/Documentos/Planillas";
import { Letras, LetrasList } from "./windows/Creditos/Documentos/Letras";
import { DocCtasXCobrar, DocCtasXCobrarList } from "./windows/Creditos/Documentos/CtasXCobrar";

// Aprobaciones
import { AprobacionCreditos } from "./windows/Creditos/Aprobaciones/Creditos";
import { PermisoUsuarioCreditos } from "./windows/Creditos/Aprobaciones/PermisoUsuario";
import { CotizTallerCredito } from "./windows/Creditos/Aprobaciones/CotizTaller";
import { RecepcionDocCreditos } from "./windows/Creditos/Aprobaciones/RecepcionDoc";

// Mantenimiento
import { SaldoBancosCreditos } from "./windows/Creditos/Mantenimiento/SaldoBancos";
import { TipoCambio } from "./windows/Creditos/Mantenimiento/RenuevaTipoCambio";
import { FactoresDescuentosWindow } from "./windows/Creditos/Mantenimiento/FactoresYDescuentos";
import { FeriadosWindow } from "./windows/Creditos/Mantenimiento/Feriados";
import { ProcesarJobWindow } from "./windows/Creditos/Mantenimiento/ProcesarJob";
import { VincularGRWindow } from "./windows/Creditos/Mantenimiento/VincularGR";
import { MantenimientoTipoDeCambio, MantenimientoTipoDeCambioList } from "./windows/Creditos/Mantenimiento/MantenimientoTipoDeCambio";
import { TipoCambiosVentas, TipoCambiosVentasList } from "./windows/Creditos/Mantenimiento/TipoCambioVentas";

// Consultas
import { CtasXCobrar, CtasXCobrarList } from "./windows/Creditos/Consultas/CtasXCobrar";
import { VencimientosCreditosReport } from "./windows/Creditos/Consultas/Vencimientos";
import { TarjetaCliente, TarjetaClienteList } from "./windows/Creditos/Consultas/TarjetaCliente";

// Reportes
// Vencimientos
import { Acumulado, AcumuladoList } from "./windows/Creditos/Reportes/Vencimientos/Acumulado";
import { Detalle, DetalleList } from "./windows/Creditos/Reportes/Vencimientos/Detalle";
import { ReporteClientes, ReporteClientesList } from "./windows/Creditos/Reportes/Clientes";
import { CuentasCorrientes, CuentasCorrientesList } from "./windows/Creditos/Reportes/CuentasCorrientes";
import { ReporteDiario, ReporteDiarioList } from "./windows/Creditos/Reportes/DiarioDePagos";
import { ReporteDocEmi, ReporteDocEmiList } from "./windows/Creditos/Reportes/DocumentosEmitidos";
import { LetrasAceptadas, LetrasAceptadasList } from "./windows/Creditos/Reportes/LetrasAceptadas";
import { ReporteNotDebCred, ReporteNotDebCredList } from "./windows/Creditos/Reportes/NotasDebitoCredito";
import { ReportePlanillas, ReportePlanillasList } from "./windows/Creditos/Reportes/Planillas";
import { ReporteVisCo, ReporteViscoList } from "./windows/Creditos/Reportes/VisitaCobrador";

// IMPORTACIONES
// Importaciones
import { ImportDoc, ImportDocList } from "./windows/Importaciones/Importaciones/Documentos";
import { ImportEmbarque, ImportEmbarqueList } from "./windows/Importaciones/Importaciones/Embarque";

// Pedidos
import { OrdenImportacion, OrdenImportacionList } from "./windows/Importaciones/Pedidos/OrdenImportacion";
import { Internos, InternosList } from "./windows/Importaciones/Pedidos/Internos";

// Reportes
import { EmbarqueImportacion, EmbarqueImportacionList } from "./windows/Importaciones/Reportes/EmbarquesDeImportacion";
import { ReporteOrdenImportacion, ReporteOrdenImportacionList } from "./windows/Importaciones/Reportes/OrdenDeImportación";
import { PedidoInterno, PedidoInternoList } from "./windows/Importaciones/Reportes/PedidoInterno";

// COSTOS
// Importaciones
import { ImportValorizarFI, ImportValorizarFIList } from "./windows/Costos/Importaciones/ValorizarFI";

// Procesos
import { AjustarCostos, AjustarCostosList } from "./windows/Costos/Procesos/AjustarCostos";
import { CerrarMes, CerrarMesList } from "./windows/Costos/Procesos/CerrarMes";
import { Consolidado, ConsolidadoList } from "./windows/Costos/Procesos/Consolidado";
import { GenerarPeriodo, GenerarPeriodoList } from "./windows/Costos/Procesos/GenerarPeriodo";
import { InvRotativo, InvRotativoList } from "./windows/Costos/Procesos/InvRotativo";
import { Recalcular, RecalcularList } from "./windows/Costos/Procesos/Recalcular";
import { TrasladarCostos, TrasladarCostosList } from "./windows/Costos/Procesos/TrasladarCostos";

// Documentos
import { ActualizarCostos, ActualizarCostosList } from "./windows/Costos/Documentos/ActualizarCostos";

// Reportes
import { CostoVentaCostosReport } from "./windows/Costos/Reportes/CostoDeVenta";
import { CuadrarCierreCostosWindow } from "./windows/Costos/Reportes/CuadrarCierre";
import { DiarioAlmacenCostosReport } from "./windows/Costos/Reportes/DiarioDeAlmacen";
import { StockValorizadoCostosReport } from "./windows/Costos/Reportes/StockValorizado";
import { GmroiCostosReport } from "./windows/Costos/Reportes/GMROI";
import { CerrarMesCostosWindow } from "./windows/Contabilidad/Costos/Procesos/CerrarMes";
import { ConsolidadoCostosWindow } from "./windows/Contabilidad/Costos/Procesos/Consolidado";
import { GenerarPeriodoCostosWindow } from "./windows/Contabilidad/Costos/Procesos/GenerarPeriodo";
import { InventarioRotativoWindow } from "./windows/Contabilidad/Costos/Procesos/InvRotativo";
import { RecalcularCostosWindow } from "./windows/Contabilidad/Costos/Procesos/Recalcular";
import { TrasladarCostosWindow } from "./windows/Contabilidad/Costos/Procesos/TrasladarCostos";

// GERENCIA
// Reportes
import { GerenciaVentasWindow } from "./windows/Gerencia/Reportes/000Ventas";
import { GerenciaImportacionesWindow } from "./windows/Gerencia/Reportes/010Importaciones";
import { GerenciaInventarioCostosWindow } from "./windows/Gerencia/Reportes/020InventarioYCostos";
import { GerenciaContabilidadWindow } from "./windows/Gerencia/Reportes/030Contabilidad";
import { GerenciaCreditosWindow } from "./windows/Gerencia/Reportes/040CreditosYCobranzas";
import { ContenedorReportes, ContenedorReportesWindow } from "./windows/Gerencia/Reportes/ContenedorReportes";
import { DatosParaIndicadores ,DatosParaIndicadoresWindow } from "./windows/Gerencia/Reportes/DatosParaIndicadores";
import { EstadosFinancieros, EstadosFinancierosWindow } from "./windows/Gerencia/Reportes/EstadosFinancieros";
import { Tarjeta, TarjetaGerenciaWindow } from "./windows/Gerencia/Reportes/Tarjeta";

// SERVICIOS
// Almacen
import { PedirRepuestos, PedirRepuestosList } from "./windows/Servicios/Almacen/PedirRepuestos";

// Ventas
import { VentaCotizacion, VentaCotizacionList } from "./windows/Servicios/Ventas/Cotizacion";

// Orden de Trabajo
import { OrdenTrabajo, OrdenTrabajoList } from "./windows/Servicios/Orden de Trabajo/OT";
import { Marcaciones, MarcacionesList } from "./windows/Servicios/Orden de Trabajo/Marcaciones";
import { GastosReales, GastosRealesList } from "./windows/Servicios/Orden de Trabajo/GastosReales";
import { MarcarOT, MarcarOTList } from "./windows/Servicios/Orden de Trabajo/MarcarOT";
import { PreMarcacion, PreMarcacionList } from "./windows/Servicios/Orden de Trabajo/PreMarcacion";
import { SolicitudOT, SolicitudOTList } from "./windows/Servicios/Orden de Trabajo/SolicitudOT";

// Garantia
import { GarantiaWin, GarantiaWinList } from "./windows/Servicios/Garantia/OrdenReparacion";
import { ReclamoCliente, ReclamoClienteWindow } from "./windows/Servicios/Garantia/ReclamoCliente";

// Control Vehicular
import { Kilometraje, KilometrajeList } from "./windows/Servicios/Control Vehicular/Kilometraje";

// Mantenimiento
import { OficinaUsuario, OficinaUsuarioList } from "./windows/Servicios/Mantenimiento/OficinaUsuario";

// Consultas
import { ConsultasGastosReales, ConsultasGastosRealesList } from "./windows/Servicios/Consultas/GastosReales";
import { ConsultasMarcaciones, ConsultasMarcacionesList } from "./windows/Servicios/Consultas/Marcaciones";
import { OT, OTList } from "./windows/Servicios/Consultas/OT";

// Indicadores
import { Actividades, ActividadesList } from "./windows/Servicios/Indicadores/Actividades";
import { Plantilla, PlantillaList } from "./windows/Servicios/Indicadores/Plantilla";
import { Productividad, ProductividadList } from "./windows/Servicios/Indicadores/Productividad";
import { Programacion, ProgramacionList } from "./windows/Servicios/Indicadores/Programacion";
import { Tablero, TableroList } from "./windows/Servicios/Indicadores/Tablero";

// Proyeccion
import { GenerarPedido, GenerarPedidoList } from "./windows/Servicios/Proyeccion/GenerarPedido";
import { HorasMotor, HorasMotorList } from "./windows/Servicios/Proyeccion/HorasMotor";
import { Motores, MotoresList } from "./windows/Servicios/Proyeccion/Motores";
import { Repuestos, RepuestosList } from "./windows/Servicios/Proyeccion/Repuestos";
import { Seguimiento, SeguimientoList } from "./windows/Servicios/Proyeccion/Seguimiento";

// Reportes
// Proyeccion
import { DisponibilidadDelMotor, DisponibilidadDelMotorList } from "./windows/Servicios/Reportes/Proyeccion/DisponibilidadDelMotor";
import { HorasDeMotores, HorasDeMotoresList } from "./windows/Servicios/Reportes/Proyeccion/HorasDeMotores";
import { MotoresADarDeBaja, MotoresADarDeBajaList } from "./windows/Servicios/Reportes/Proyeccion/MotoresADarDeBaja";
import { ProyeccionDeReparaciones, ProyeccionDeReparacionesList } from "./windows/Servicios/Reportes/Proyeccion/ProyeccionDeReparaciones";
import { RepuestosAImportar, RepuestosAImportarList } from "./windows/Servicios/Reportes/Proyeccion/RepuestosAImportar";
import { Seguimientos, SeguimientosList } from "./windows/Servicios/Reportes/Proyeccion/Seguimientos";
import { VentasPorMantenimientos, VentasPorMantenimientosList } from "./windows/Servicios/Reportes/Proyeccion/VentasPorMantenimientos";

import { ReportesCotizaciones, ReportesCotizacionesList } from "./windows/Servicios/Reportes/Cotizaciones";
import { GastosDetallado, GastosDetalladoList } from "./windows/Servicios/Reportes/GastosDetallado";
import { GastosPorRubros, GastosPorRubrosList } from "./windows/Servicios/Reportes/GastosPorRubros";
import { HorasDeTrabajo, HorasDeTrabajoList } from "./windows/Servicios/Reportes/HorasDeTrabajo";
import { HorasEscalon, HorasEscalonList } from "./windows/Servicios/Reportes/HorasEscalon";
import { HorasMuertas, HorasMuertasList } from "./windows/Servicios/Reportes/HorasMuertas";
import { LiquidacionXGarantia, LiquidacionXGarantiaList } from "./windows/Servicios/Reportes/LiquidacionXGarantia";
import { MovimientoRepuestos, MovimientoRepuestosList } from "./windows/Servicios/Reportes/MovimientoRepuestos";
import { ReporteOT, ReporteOTList } from "./windows/Servicios/Reportes/OT";
import { PendienteFacturacion, PendienteFacturacionList } from "./windows/Servicios/Reportes/PendienteFacturacion";
import { SolicitudGarantia, SolicitudGarantiaList } from "./windows/Servicios/Reportes/SolicitudGarantia";
import { ReporteSolicitudOT, ReporteSolicitudOTList } from "./windows/Servicios/Reportes/SolicitudOT";
import { TiempoReparacion, TiempoReparacionList } from "./windows/Servicios/Reportes/TiempoReparacion";

// COMPRAS
// Compras
import { CotizacionesCompra, CotizacionesCompraList } from "./windows/Compras/Compras/Cotizaciones";
import { OrdenCompraCompras, OrdenCompraComprasList } from "./windows/Compras/Compras/OrdenDeCompra";
import { SolicitudCompraCompras, SolicitudCompraComprasList } from "./windows/Compras/Compras/SolicitudDeCompra";

// Control
import { PlanillaViaticos, PlanillaViaticosList } from "./windows/Compras/Control/PlanillaViatico";
import { CtasXPagar, CtasXPagarList } from "./windows/Compras/Control/CuentasXPagar";
import { SolicitudGasto, SolicitudGastoList } from "./windows/Compras/Control/SolicitudGasto";
import { TarifaGastoViajeWindow, TarifaGastoViajeList } from "./windows/Compras/Control/TarifaGastoViaje";
import { TarifaTaxisCasaWindow, TarifaTaxisCasaList } from "./windows/Compras/Control/TarifaTaxisCasa";
import { TarifaTaxiDestinoWindow, TarifaTaxiDestinoList } from "./windows/Compras/Control/TarifaTaxiDestino";

// Consultas
import { CompraYOGastos, CompraYOGastosList } from "./windows/Compras/Consultas/CompraYOGastos";

// Reportes
import { ReportePagosCuentasXPagar, ReportePagosCuentasXPagarList } from "./windows/Compras/Reportes/PagoCuentasXPagar";
import { ReporteSolicitudGastos, ReporteSolicitudGastosList } from "./windows/Compras/Reportes/SolicitudGastos";
import { ReporteCtasXPagarUnidad, ReporteCtasXPagarUnidadList } from "./windows/Compras/Reportes/CuentasXPagarPorUnidad";

// PERSONAL
// Informacion
import { FichaGeneral, FichaGeneralList } from "./windows/Personal/Informacion/FichaGeneral";
import { CapacitacionesWin, CapacitacionesWinList } from "./windows/Personal/Informacion/Capacitaciones";

// Planillas Sueldos
import { PlanillaSueldos, PlanillaSueldosList } from "./windows/Personal/Planilla Sueldos/QuintaCategoria";

// Asignaciones
import { PersonalTiempo, PersonalTiempoList } from "./windows/Personal/Asignaciones/Faltas";
import { MarcacionOnline, MarcacionOnlineList } from "./windows/Personal/Asignaciones/MarcacionOnline";
import { AsignaHorasExtraWindow, AsignaHExtraList } from "./windows/Personal/Asignaciones/AsignaHExtra";
import { CronogramaMinaWindow, CronogramaMinaList } from "./windows/Personal/Asignaciones/CronogramaMina";
import { DescuentosWindow, DescuentosList } from "./windows/Personal/Asignaciones/Descuentos";
import { HorariosWindow, HorariosList } from "./windows/Personal/Asignaciones/Horarios";
import { HorasExtrasWindow, HorasExtrasList } from "./windows/Personal/Asignaciones/HorasExtras";
import { IngresosWindow, IngresosList } from "./windows/Personal/Asignaciones/Ingresos";
import { JefeAreaWindow, JefeAreaList } from "./windows/Personal/Asignaciones/JefeArea";
import { RecursosWindow, RecursosList } from "./windows/Personal/Asignaciones/Recursos";
import { EvaluacionesWindow, EvaluacionesList } from "./windows/Personal/Informacion/Evaluaciones";
import { VacacionesWindow, VacacionesList } from "./windows/Personal/Informacion/Vacaciones";

// Comunicaciones
import { ProcesarMarcasList } from "./windows/Personal/Comunicaciones/ProcesarMarcas";
import { AdminLector, AdminLectorList } from "./windows/Personal/Comunicaciones/AdminLector";

// Reportes
import { AsigHExtra, AsigHExtraList } from "./windows/Personal/Reportes/AsigHExtra";
import { AsignacionHorario, AsignacionHorarioList } from "./windows/Personal/Reportes/AsignacionHorario";
import { Asistencia, AsistenciaList } from "./windows/Personal/Reportes/Asistencia";
import { Capacitaciones, CapacitacionesList } from "./windows/Personal/Reportes/Capacitaciones";
import { Contratos, ContratosList } from "./windows/Personal/Reportes/Contratos";
import { ReporteCronogramaMina, ReporteCronogramaMinaList } from "./windows/Personal/Reportes/CronogramaMina";
import { ReporteDescuentos, ReporteDescuentosList } from "./windows/Personal/Reportes/Descuentos";
import { Faltas, FaltasList } from "./windows/Personal/Reportes/Faltas";
import { HorasExtra, HorasExtraList } from "./windows/Personal/Reportes/HorasExtra";
import { ReporteIngresos, ReporteIngresosList } from "./windows/Personal/Reportes/Ingresos";
import { Onomasticos, OnomasticosList } from "./windows/Personal/Reportes/Onomasticos";
import { Personal, PersonalList } from "./windows/Personal/Reportes/Personal";
import { ReportePlanillaSueldos, ReportePlanillaSueldosList } from "./windows/Personal/Reportes/PlanillaSueldos";
import { ReporteRecursos, ReporteRecursosList } from "./windows/Personal/Reportes/Recursos";
import { Tardanzas, TardanzasList } from "./windows/Personal/Reportes/Tardanzas";
import { ReporteVacaciones, ReporteVacacionesList } from "./windows/Personal/Reportes/Vacaciones";

// RONDAS
// Asignacion
import { PuntosControl, PuntosControlList } from "./windows/Rondas/Asignacion/PuntosControlRutas";
import { Rondas, RondasWindow } from "./windows/Rondas/Asignacion/Rondas";
import { RuteadorRutasWindow, RuteadorRutas } from "./windows/Rondas/Asignacion/RuteadorRutas";

// CONTABILIDAD
// Tesoreria
import { ValorizarFI, ValorizarFIList } from "./windows/Contabilidad/Costos/Importaciones/ValorizarFI";
import { Asientos, AsientosList } from "./windows/Contabilidad/Tesoreria/Asientos";
import { MovimientoBancos, MovimientoBancosList } from "./windows/Contabilidad/Tesoreria/MovimientoBancos";

// Compras
import { RegistroCompra, RegistroCompraList } from "./windows/Contabilidad/Compras/RegistroCompra";

// Contabilidad
import { DiarioCompras, DiarioComprasList } from "./windows/Contabilidad/Contabilidad/Diario";

// Caja Chica
import { CajaChica, CajaChicaList } from "./windows/Contabilidad/Caja Chica/ArqueoCaja";

// Procesos
import { GenerarTXT, GenerarTXTList } from "./windows/Contabilidad/Procesos/GenerarTXTLibros";
import { FlujoCaja, FlujoCajaList } from "./windows/Contabilidad/Procesos/FlujoDeCaja";
import { DiferenciaTipoCambioWindow, DifTipoCambioList } from "./windows/Contabilidad/Procesos/DifTipoCambio";
import { CierreMesContableWindow, CierreMesList } from "./windows/Contabilidad/Procesos/CierreMes";
import { CuentaDestinoWindow, CuentaDestinoList } from "./windows/Contabilidad/Procesos/CuentaDestino";

// Reportes
// Libros Oficiales
import { CajaYBancos, CajaYBancosList } from "./windows/Contabilidad/Reportes/LibrosOficiales/CajaYBancos";
import { LibroDiarioWindow, LibroDiarioList } from "./windows/Contabilidad/Reportes/LibrosOficiales/LibroDiario";
import { LibroMayor, LibroMayorList } from "./windows/Contabilidad/Reportes/LibrosOficiales/LibroMayor";
import { RegistroDeCompras, RegistroDeComprasList } from "./windows/Contabilidad/Reportes/LibrosOficiales/RegistroDeCompras";

import { ChequesGirados, ChequesGiradosList } from "./windows/Contabilidad/Reportes/ChequesGirados";
import { CtasCtes, CtasCtesList } from "./windows/Contabilidad/Reportes/CtasCtes";
import { CtasCtesPendiente, CtasCtesPendienteList } from "./windows/Contabilidad/Reportes/CtasCtesPendiente";
import { ReportCtasXPagar, ReportCtasXPagarList } from "./windows/Contabilidad/Reportes/CtasXPagar";
import { EstadoFinanciero, EstadoFinancieroList } from "./windows/Contabilidad/Reportes/EstadoFinanciero";
import { ReportAuxiliar, ReportAuxiliarList } from "./windows/Contabilidad/Reportes/MayorAuxiliar";
import { ReportProvisionales, ReportProvisionalesList } from "./windows/Contabilidad/Reportes/Provisionales";
import { ReporteReembolso, ReporteReembolsoList } from "./windows/Contabilidad/Reportes/Reembolsos";
import { ReporteVencimiento, ReporteVencimientoList } from "./windows/Contabilidad/Reportes/Vencimientos";


// TELEFONIA
// Mantenimiento
import { TelefoniaInv, TelefoniaInvList } from "./windows/Telefonia/Mantenimiento/Modelos";
import { TelefoniaEquiposWindow } from "./windows/Telefonia/Mantenimiento/Equipos";
import { TelefoniaPlanesWindow } from "./windows/Telefonia/Mantenimiento/Planes";

// Asignacion
import { AsignaPersona, AsignaPersonaList } from "./windows/Telefonia/Asignacion/AsignaPersona";
import { TelefoniaLineasWindow } from "./windows/Telefonia/Asignacion/Lineas";

// CRM
// Oportunidades
import { CuotaVendedor, CuotaVendedorWindow } from "./windows/CRM/Oportunidades/CuotaVendedor";
import { Ocurrencias, OcurrenciasWindow } from "./windows/CRM/Oportunidades/Ocurrencias";
import { OportunidadNegocioWindow } from "./windows/CRM/Oportunidades/OportunidadNegocio";
import { CRMTarjetaCliente, CRMTarjetaClienteList } from "./windows/CRM/Oportunidades/TarjetaCliente";
import { VisitaClientes, VisitaClientesWindow } from "./windows/CRM/Oportunidades/VisitaClientes";

// Reportes
import { OportunidadNegocio, OportunidadNegocioList } from "./windows/CRM/Reportes/OportunidadNegocio";
import { ReporteVisitaClientes, ReporteVisitaClientesList } from "./windows/CRM/Reportes/VisitaClientes";

// TABLAS
// Ventas

// Almacenes
import { CategoriasWindow, CategoriasList } from "./windows/Tablas/Almacenes/Categorias";
import { ModelosAlmacenesWindow, ModelosList } from "./windows/Tablas/Almacenes/Modelos";
import { TipoMotoresWindow, TipoMotoresList } from "./windows/Tablas/Almacenes/TipoMotores";

// Importaciones
import { MarcasWindow, MarcasList } from "./windows/Tablas/Importaciones/Marcas";
import { PartidasWindow, PartidasList } from "./windows/Tablas/Importaciones/Partidas";

// Servicios
import { PlantillaRepuestosWindow, PlantillaRepuestosList } from "./windows/Tablas/Servicios/PlantillaRepuestos";
import { PlantillaRepuestosClienteWindow, PlantillaRepuestosClienteList } from "./windows/Tablas/Servicios/PlantillaRepuestosCliente";
import { UbicacionServicioWindow, UbicacionServicioList } from "./windows/Tablas/Servicios/UbicacionServicio";
import { VehiculosWindow, VehiculosList } from "./windows/Tablas/Servicios/Vehiculos";

// Compras
import { CondicionDePagoWindow, CondicionDePagoList } from "./windows/Tablas/Compras/CondicionDePago";
import { ProveedoresWindow, ProveedoresList } from "./windows/Tablas/Compras/Proveedores";

// Contabilidad
import { CuentaContableWindow, CuentaContableList } from "./windows/Tablas/Contabilidad/CuentaContable";
import { CuentasDestinoTablaWindow, CuentasDestinoList } from "./windows/Tablas/Contabilidad/CuentasDestino";

// Personal
import { AFPWindow, AFPList } from "./windows/Tablas/Personal/AFP";
import { AreasWindow, AreasList } from "./windows/Tablas/Personal/Areas";
import { CargosWindow, CargosList } from "./windows/Tablas/Personal/Cargos";
import { EquipoLectorWindow, EquipoLectorList } from "./windows/Tablas/Personal/EquipoLector";
import { MotivosFaltasWindow, MotivosFaltasList } from "./windows/Tablas/Personal/MotivosFaltas";
import { RubroPlanillaWindow, RubroPlanillaList } from "./windows/Tablas/Personal/RubroPlanilla";
import { RubroPlanillaCtasWindow, RubroPlanillaCtasList } from "./windows/Tablas/Personal/RubroPlanillaCtas";
import { TipoHoraExtraWindow, TipoHoraExtraList } from "./windows/Tablas/Personal/TipoHoraExtra";

// Rondas
import { RutasWindow, RutasList } from "./windows/Tablas/Rondas/Rutas";
import { RuteadorWindow, RuteadorList } from "./windows/Tablas/Rondas/Ruteador";

// LOGUEO
// Login
import { CambiarEmpresa, CambiarEmpresaList } from "./windows/Logueo/CambiarEmpresa";
import { CerrarSesion, CerrarSesionList } from "./windows/Logueo/CerrarSesion";
import { CambiarContrasena, CambiarContrasenaList } from "./windows/Logueo/CambiarContrasena";


// ADMINISTRACION
// Seguridad
import { UsuariosAdmin, UsuariosAdminList } from "./windows/Administracion/Seguridad/Usuarios";
import { Perfiles, PerfilesList } from "./windows/Administracion/Seguridad/Perfiles";
import { Sesiones, SesionesList } from "./windows/Administracion/Seguridad/Sesiones";


// Usuarios
import { AtenderSolicitud, AtenderSolicitudList } from "./windows/Administracion/Usuarios/AtenderSolicitud";

// Reportes
import { IndicadoresEncuesta, IndicadoresEncuestaWindow } from "./windows/Administracion/Reportes/Indicadores";

// Encuestas
import { EncuestaWin, EncuestaWinList } from "./windows/Administracion/Encuestas/Encuesta";
import { Resultado, ResultadoEncuestaWindow } from "./windows/Administracion/Encuestas/Resultado";

// Inventario
import { ComputadoraAsignar, ComputadoraAsignarList } from "./windows/Administracion/Inventario/AsignarComputadora";
import { ComputadoraInv, ComputadoraInvList } from "./windows/Administracion/Inventario/Computadora";

// Llamadas
import { LlamadasWin, LlamadasWinList } from "./windows/Administracion/Llamadas/Llamadas";

// Tablas Generales
import { EquiposMarcacionPersonalWindow, EquiposMarcacionPersonalList } from "./windows/Administracion/Tablas Generales/EquiposMarcacionPersonal";
import { EmpresasWindow, EmpresasList } from "./windows/Administracion/Tablas Generales/Empresas";
import { SeriesDocumentosWindow, SeriesDocumentosList } from "./windows/Administracion/Tablas Generales/SeriesDocumentos";
import { LocacionesWindow, LocacionesList } from "./windows/Administracion/Tablas Generales/Locaciones";
import { RubrosDeProductosWindow, RubrosDeProductosList } from "./windows/Administracion/Tablas Generales/RubrosDeProductos";
import { ParametrosLocacionesWindow, ParametrosLocacionesList } from "./windows/Administracion/Tablas Generales/ParametrosLocaciones";
import { ParametrosPlanillaSueldosWindow, ParametrosPlanillaSueldosList } from "./windows/Administracion/Tablas Generales/ParametrosPlanillaSueldos";
import { RubrosXEmpresaWindow, RubrosXEmpresaList } from "./windows/Administracion/Tablas Generales/RubrosXEmpresa";

// AYUDA
// Usuario
import { SolicitudSoporte, SolicitudSoporteList } from "./windows/Ayuda/Usuario/Solicitud";
// Ayuda
import { Acerca, AcercaList } from "./windows/Ayuda/Ayuda/Acerca";
import { InfoCambios, InfoCambiosList } from "./windows/Ayuda/Ayuda/InfoCambios";


import { ReporteGuias } from "./windows/Reportes/ReporteGuias";
import { ClientesList } from "./windows/Clientes";
import { UbicacionesList as UbicacionesWindow } from "./windows/Ubicaciones";
import { ProductosList, Productos } from "./windows/Productos";
import { RegistroComprasList } from "./windows/ComprasRegistro";
import { SolicitudCompraList, SolicitudCompra } from "./windows/SolicitudCompra";
import { OrdenCompraList, OrdenCompra } from "./windows/OrdenCompra";
import { CuentasPagarList } from "./windows/CuentasPagar";
import { VentaReporteDialog } from "./windows/Reportes/VentaReporteDialog";
import { CostosReporteDialog } from "./windows/Reportes/CostosReporteDialog";
import { ComprasReporteDialog } from "./windows/Reportes/ComprasReporteDialog";
import { ContabilidadReporteDialog } from "./windows/Reportes/ContabilidadReporteDialog";
import { AlmacenReporteDialog } from "./windows/Reportes/AlmacenReporteDialog";
import { CreditosReporteDialog } from "./windows/Reportes/CreditosReporteDialog";
import { ReporteCostoVenta } from "./windows/Reportes/ReporteCostoVenta";
import { PreciosManagerList, PreciosManager } from "./windows/Precios/PreciosManager";
import { ServicioReporteDialog } from "./windows/Reportes/ServicioReporteDialog";
import { PersonalReporteDialog } from "./windows/Reportes/PersonalReporteDialog";
import { GerenciaReporteDialog } from "./windows/Reportes/GerenciaReporteDialog";
import { CrmReporteDialog } from "./windows/Reportes/CrmReporteDialog";
import { ActivosFijos } from "./windows/Activos/Activos/ActivosFijos";



import { FsLegacy, RadioLegacy, DialogFooter, ProcesoLote, MantenimientoCRUD, ConfigTabla } from "./windows/shared/LegacySupport";



import {
  motion, AnimatePresence, mdiWindowVariants, MotionTBody, MotionRow, Spinner, GlowPulse,
} from "./motion";


// The goal of this file is to act as the single registry for all "windows" used
// by the application. It must preserve the original normalization rules and
// export a single function that the `WindowsContext` (or other callers)
// consumes to map an incoming label to a React component.

// We deliberately keep this file focused on mapping/compatibility. Implement
// specific window UIs in individual modules (already moved into subfolders).

export type WindowComponent = React.ComponentType<any>;

/* Utility: build a registry with aliases while keeping easy-to-read source
   for future maintenance. We intentionally include many normalized labels and
   compatibility aliases here so changes in labels continue to resolve to the
   same component. */

const registry: Record<string, WindowComponent> = {};

function add(keyLabel: string, component: WindowComponent) {
  registry[normalizeWindowLabel(keyLabel)] = component;
}

function addAliases(baseLabel: string, aliases: string[], component: WindowComponent) {
  add(baseLabel, component);
  aliases.forEach(a => add(a, component));
}

// --- Precios ---
add("Consulta Precios", ConsultaPreciosDialogList);
add("Precios Cliente", PrecioClienteList);
add("Precio Oferta", PrecioOfertaList);
add("Precio Lista", PrecioListaList);
add("Precio Fabricantes", PrecioFabricantesList);
add("Factores Rubros", FactoresRubrosList);

// --- General / Base ---
add("New Guide", NewGuideWindow);
add("Reporte Container", ReporteContainer);
add("Reporte Activos Fijos", ReporteActivosFijosWindow);

// --- Ventas ---
add("Guía Remisión", GuiaRemision);
add("Factura de Venta", FacturaVentaList);
add("Nota de Venta", NotaVentaList);
add("Guía Devolución", GuiaDevolucion);
add("Boleta", Boleta);
add("Resumen de Boletas", ResumenBoletas);

add("Cotizaciones", Cotizaciones);
add("Reclamo Garantía", ReclamoGarantia);
add("Separar Orden", SepararOrden);
add("Órdenes Compra", OrdenesCompra);
add("Actualizar Vendedor", ActualizarVendedor);
add("Enviar Correos", EnviarCorreos);

add("Cartera", Cartera);
add("Despacho", Despacho);
add("Precio Consulta", PrecioConsulta);
add("Consulta Documentos Venta", ConsultaDocumentosVentaWindow);
add("Tablero Indicador", TableroIndicador);

add("Registro Venta", RegistroVenta);
add("Registro Auxiliar", RegistroAuxiliarList);
add("Resumen Registro", ResumenRegistroList);
add("Reporte Ventas Detallado", ReporteVentasDetalladoList);
add("Reporte Acumulada", ReporteAcumulada);
add("Reporte GR Pendiente", ReporteGRPendiente);
add("Reporte Cotizaciones", ReporteCotizaciones);
add("Reporte Vale Requisición", ReporteValeRequisicionList);
add("Reporte Mensual Cliente", ReporteMensualClienteList);
add("Reporte Detalle Descuento", ReporteDetalleDescuentoList);
add("Reporte Reclamos", ReporteReclamosList);
add("Reporte Orden Compra", ReporteOrdenCompra);
add("Reporte Consignacion", ReporteConsignacionList);
add("Reporte Guías Remisión", ReporteGuiasRemision);
add("Reporte Presupuesto Venta", ReportePresupuestoVenta);
add("Reporte Comisiones", ReporteComisiones);

// --- Almacenes ---
add("Doc. Ingresos", DocIngresos);
add("Doc. Salidas", DocSalidas);
add("Chequeo F/I", ChequeoFI);
add("Almacén T/I", AlmacenTI);
add("Almacén MTI", AlmacenMTI);
add("Atender OT", AtenderOT);
add("Despacho Almacén", DespachoWindow);
add("Vales", Vales);

add("Memos Transferencias Internas", MemosTransferenciasInternas);
add("Compra Motores", CompraMotores);

add("Tránsito Docs", TransitoDocs);
add("Anulación Consulta", AnulacionConsulta);

add("Liqui Gastos", LiquiGastos);
add("Act. Min Max", ActMinMax);
add("Ubicaciones", UbicacionesList);
add("Mantenimiento Productos", MantenimientoProductos);

add("Tarjetas", Tarjetas);
add("Documento Consulta", DocumentoConsulta);

add("Procesar Cobertura", ProcesarCobertura);
add("Calendario", Calendario);
add("Indicadores Venta Dialog", IndicadoresVentaDialog);

add("Vale Materiales Report", ValeMaterialesReport);
add("Toma Inventario Report", TomaInventarioReport);
add("Sin Movimiento Report", SinMovimientoReport);
add("Movimientos Almacen Report", MovimientosAlmacenReport);
add("Documento Reporte", DocumentoReporte);
add("Reporte Valorizado", ReporteValorizado);
add("Reporte Inventario", ReporteInventario);
add("Reporte Transferencia", ReporteTransferencia);

// --- Créditos ---
add("Anticipos", Anticipos);
add("Planillas", Planillas);
add("Letras", Letras);
add("Doc Ctas x Cobrar", DocCtasXCobrar);

add("Aprobación Créditos", AprobacionCreditos);
add("Permiso Usuario Créditos", PermisoUsuarioCreditos);
add("Cotiz Taller Crédito", CotizTallerCredito);
add("Recepción Doc Créditos", RecepcionDocCreditos);

add("Saldo Bancos Créditos", SaldoBancosCreditos);
add("Tipo Cambio", TipoCambio);
add("Factores Descuentos Window", FactoresDescuentosWindow);
add("Feriados Window", FeriadosWindow);
add("Procesar Job Window", ProcesarJobWindow);
add("Vincular GR Window", VincularGRWindow);
add("Mantenimiento Tipo de Cambio", MantenimientoTipoDeCambio);
add("Tipo Cambios Ventas", TipoCambiosVentas);

add("Ctas x Cobrar", CtasXCobrar);
add("Vencimientos Créditos Report", VencimientosCreditosReport);
add("Tarjeta Cliente", TarjetaCliente);

add("Acumulado", Acumulado);
add("Detalle", Detalle);
add("Reporte Clientes", ReporteClientes);
add("Cuentas Corrientes", CuentasCorrientes);
add("Reporte Diario", ReporteDiario);
add("Reporte Doc Emi", ReporteDocEmi);
add("Letras Aceptadas", LetrasAceptadas);
add("Reporte Not Deb Cred", ReporteNotDebCred);
add("Reporte Planillas", ReportePlanillas);
add("Reporte Vis Co", ReporteVisCo);

// --- Importaciones ---
add("Import Doc", ImportDoc);
add("Import Embarque", ImportEmbarque);
add("Orden Importacion", OrdenImportacion);
add("Internos", Internos);
add("Embarque Importacion", EmbarqueImportacion);
add("Reporte Orden Importacion", ReporteOrdenImportacion);
add("Pedido Interno", PedidoInterno);

// --- Costos ---
add("Import Valorizar FI", ImportValorizarFI);
add("Ajustar Costos", AjustarCostos);
add("Cerrar Mes", CerrarMes);
add("Consolidado", Consolidado);
add("Generar Periodo", GenerarPeriodo);
add("Inv Rotativo", InvRotativo);
add("Recalcular", Recalcular);
add("Trasladar Costos", TrasladarCostos);
add("Actualizar Costos", ActualizarCostos);

add("Costo Venta Costos Report", CostoVentaCostosReport);
add("Cuadrar Cierre Costos Window", CuadrarCierreCostosWindow);
add("Diario Almacen Costos Report", DiarioAlmacenCostosReport);
add("Stock Valorizado Costos Report", StockValorizadoCostosReport);
add("Gmroi Costos Report", GmroiCostosReport);

add("Cerrar Mes Costos Window", CerrarMesCostosWindow);
add("Consolidado Costos Window", ConsolidadoCostosWindow);
add("Generar Periodo Costos Window", GenerarPeriodoCostosWindow);
add("Inventario Rotativo Window", InventarioRotativoWindow);
add("Recalcular Costos Window", RecalcularCostosWindow);
add("Trasladar Costos Window", TrasladarCostosWindow);

// --- Gerencia ---
add("Gerencia Ventas Window", GerenciaVentasWindow);
add("Gerencia Importaciones Window", GerenciaImportacionesWindow);
add("Gerencia Inventario Costos Window", GerenciaInventarioCostosWindow);
add("Gerencia Contabilidad Window", GerenciaContabilidadWindow);
add("Gerencia Creditos Window", GerenciaCreditosWindow);
add("Contenedor Reportes", ContenedorReportes);
add("Datos Para Indicadores", DatosParaIndicadores);
add("Estados Financieros", EstadosFinancieros);
add("Tarjeta", Tarjeta);

// --- Servicios ---
add("Pedir Repuestos", PedirRepuestos);
add("Venta Cotizacion", VentaCotizacion);
add("Orden Trabajo", OrdenTrabajo);
add("Marcaciones", Marcaciones);
add("Gastos Reales", GastosReales);
add("Marcar OT", MarcarOT);
add("Pre Marcacion", PreMarcacion);
add("Solicitud OT", SolicitudOT);

add("Garantia Win", GarantiaWin);
add("Reclamo Cliente", ReclamoCliente);
add("Kilometraje", Kilometraje);
add("Oficina Usuario", OficinaUsuario);

add("Consultas Gastos Reales", ConsultasGastosReales);
add("Consultas Marcaciones", ConsultasMarcaciones);
add("OT", OT);

add("Actividades", Actividades);
add("Plantilla", Plantilla);
add("Productividad", Productividad);
add("Programacion", Programacion);
add("Tablero", Tablero);

add("Generar Pedido", GenerarPedido);
add("Horas Motor", HorasMotor);
add("Motores", Motores);
add("Repuestos", Repuestos);
add("Seguimiento", Seguimiento);

add("Disponibilidad Del Motor", DisponibilidadDelMotor);
add("Horas De Motores", HorasDeMotores);
add("Motores A Dar De Baja", MotoresADarDeBaja);
add("Proyeccion De Reparaciones", ProyeccionDeReparaciones);
add("Repuestos A Importar", RepuestosAImportar);
add("Seguimientos", Seguimientos);
add("Ventas Por Mantenimientos", VentasPorMantenimientos);

add("Reportes Cotizaciones", ReportesCotizaciones);
add("Gastos Detallado", GastosDetallado);
add("Gastos Por Rubros", GastosPorRubros);
add("Horas De Trabajo", HorasDeTrabajo);
add("Horas Escalon", HorasEscalon);
add("Horas Muertas", HorasMuertas);
add("Liquidacion X Garantia", LiquidacionXGarantia);
add("Movimiento Repuestos", MovimientoRepuestos);
add("Reporte OT", ReporteOT);
add("Pendiente Facturacion", PendienteFacturacion);
add("Solicitud Garantia", SolicitudGarantia);
add("Reporte Solicitud OT", ReporteSolicitudOT);
add("Tiempo Reparacion", TiempoReparacion);

// --- Compras ---
add("Cotizaciones Compra", CotizacionesCompra);
add("Orden Compra Compras", OrdenCompraCompras);
add("Solicitud Compra Compras", SolicitudCompraCompras);

add("Planilla Viaticos", PlanillaViaticos);
add("Ctas X Pagar", CtasXPagar);
add("Solicitud Gasto", SolicitudGasto);
add("Tarifa Gasto Viaje Window", TarifaGastoViajeWindow);
add("Tarifa Taxis Casa Window", TarifaTaxisCasaWindow);
add("Tarifa Taxi Destino Window", TarifaTaxiDestinoWindow);

add("Compra Y O Gastos", CompraYOGastos);
add("Reporte Pagos Cuentas X Pagar", ReportePagosCuentasXPagar);
add("Reporte Solicitud Gastos", ReporteSolicitudGastos);
add("Reporte Ctas X Pagar Unidad", ReporteCtasXPagarUnidad);

// --- Personal ---
add("Ficha General", FichaGeneral);
add("Capacitaciones Win", CapacitacionesWin);
add("Planilla Sueldos", PlanillaSueldos);
add("Personal Tiempo", PersonalTiempo);
add("Marcacion Online", MarcacionOnline);
add("Asigna Horas Extra Window", AsignaHorasExtraWindow);
add("Cronograma Mina Window", CronogramaMinaWindow);
add("Descuentos Window", DescuentosWindow);
add("Horarios Window", HorariosWindow);
add("Horas Extras Window", HorasExtrasWindow);
add("Ingresos Window", IngresosWindow);
add("Jefe Area Window", JefeAreaWindow);
add("Recursos Window", RecursosWindow);
add("Evaluaciones Window", EvaluacionesWindow);
add("Vacaciones Window", VacacionesWindow);

add("Procesar Marcas List", ProcesarMarcasList);
add("Admin Lector", AdminLector);

add("Asig H Extra", AsigHExtra);
add("Asignacion Horario", AsignacionHorario);
add("Asistencia", Asistencia);
add("Capacitaciones", Capacitaciones);
add("Contratos", Contratos);
add("Reporte Cronograma Mina", ReporteCronogramaMina);
add("Reporte Descuentos", ReporteDescuentos);
add("Faltas", Faltas);
add("Horas Extra", HorasExtra);
add("Reporte Ingresos", ReporteIngresos);
add("Onomasticos", Onomasticos);
add("Personal", Personal);
add("Reporte Planilla Sueldos", ReportePlanillaSueldos);
add("Reporte Recursos", ReporteRecursos);
add("Tardanzas", Tardanzas);
add("Reporte Vacaciones", ReporteVacaciones);

// --- Rondas ---
add("Puntos Control", PuntosControl);
add("Rondas", Rondas);
add("Ruteador Rutas Window", RuteadorRutasWindow);

// --- Contabilidad ---
add("Valorizar FI", ValorizarFI);
add("Asientos", Asientos);
add("Movimiento Bancos", MovimientoBancos);
add("Registro Compra", RegistroCompra);
add("Diario Compras", DiarioCompras);
add("Caja Chica", CajaChica);
add("Generar TXT", GenerarTXT);
add("Flujo Caja", FlujoCaja);
add("Diferencia Tipo Cambio Window", DiferenciaTipoCambioWindow);
add("Cierre Mes Contable Window", CierreMesContableWindow);
add("Cuenta Destino Window", CuentaDestinoWindow);

add("Caja Y Bancos", CajaYBancos);
add("Libro Diario Window", LibroDiarioWindow);
add("Libro Mayor", LibroMayor);
add("Registro De Compras", RegistroDeCompras);

add("Cheques Girados", ChequesGirados);
add("Ctas Ctes", CtasCtes);
add("Ctas Ctes Pendiente", CtasCtesPendiente);
add("Report Ctas X Pagar", ReportCtasXPagar);
add("Estado Financiero", EstadoFinanciero);
add("Report Auxiliar", ReportAuxiliar);
add("Report Provisionales", ReportProvisionales);
add("Reporte Reembolso", ReporteReembolso);
add("ReporteVencimiento", ReporteVencimiento);

// --- Telefonía ---
add("Telefonia Inv", TelefoniaInv);
add("Telefonia Equipos Window", TelefoniaEquiposWindow);
add("Telefonia Planes Window", TelefoniaPlanesWindow);
add("Asigna Persona", AsignaPersona);
add("Telefonia Lineas Window", TelefoniaLineasWindow);

// --- CRM ---
add("Cuota Vendedor", CuotaVendedor);
add("Ocurrencias", Ocurrencias);
add("Oportunidad Negocio Window", OportunidadNegocioWindow);
add("CRMTarjetaCliente", CRMTarjetaCliente);
add("Visita Clientes", VisitaClientes);
add("Oportunidad Negocio", OportunidadNegocio);
add("Reporte Visita Clientes", ReporteVisitaClientes);

// --- Tablas ---
add("Categorias Window", CategoriasWindow);
add("Modelos Almacenes Window", ModelosAlmacenesWindow);
add("Tipo Motores Window", TipoMotoresWindow);
add("Marcas Window", MarcasWindow);
add("Partidas Window", PartidasWindow);
add("Plantilla Repuestos Window", PlantillaRepuestosWindow);
add("Plantilla Repuestos Cliente Window", PlantillaRepuestosClienteWindow);
add("Ubicacion Servicio Window", UbicacionServicioWindow);
add("VehiculosWindow", VehiculosWindow);
add("Condicion De Pago Window", CondicionDePagoWindow);
add("ProveedoresWindow", ProveedoresWindow);
add("Cuenta Contable Window", CuentaContableWindow);
add("Cuentas Destino Tabla Window", CuentasDestinoTablaWindow);
add("AFPWindow", AFPWindow);
add("AreasWindow", AreasWindow);
add("CargosWindow", CargosWindow);
add("Equipo Lector Window", EquipoLectorWindow);
add("Motivos FaltasWindow", MotivosFaltasWindow);
add("Rubro Planilla Window", RubroPlanillaWindow);
add("Rubro Planilla Ctas Window", RubroPlanillaCtasWindow);
add("Tipo Hora Extra Window", TipoHoraExtraWindow);
add("RutasWindow", RutasWindow);
add("RuteadorWindow", RuteadorWindow);

// --- Logueo ---
add("Cambiar Empresa", CambiarEmpresa);
add("Cerrar Sesion", CerrarSesion);
add("Cambiar Contrasena", CambiarContrasena);

// --- Administración ---
add("Usuarios Admin", UsuariosAdmin);
add("Perfiles", Perfiles);
add("Sesiones", Sesiones);
add("Atender Solicitud", AtenderSolicitud);
add("Indicadores Encuesta", IndicadoresEncuesta);
add("Encuesta Win", EncuestaWin);
add("Resultado", Resultado);
add("Computadora Asignar", ComputadoraAsignar);
add("Computadora Inv", ComputadoraInv);
add("Llamadas Win", LlamadasWin);
add("Equipos Marcacion Personal Window", EquiposMarcacionPersonalWindow);
add("Empresas Window", EmpresasWindow);
add("Series Documentos Window", SeriesDocumentosWindow);
add("Locaciones Window", LocacionesWindow);
add("Rubros De Productos Window", RubrosDeProductosWindow);
add("Parametros Locaciones Window", ParametrosLocacionesWindow);
add("Parametros Planilla Sueldos Window", ParametrosPlanillaSueldosWindow);
add("Rubros X Empresa Window", RubrosXEmpresaWindow);

// --- Ayuda ---
add("Solicitud Soporte", SolicitudSoporte);
add("Acerca", Acerca);
add("Info Cambios", InfoCambios);

add("Reporte Guias", ReporteGuias);
add("ClientesList", ClientesList);
add("UbicacionesWindow", UbicacionesWindow);
add("ProductosList", ProductosList);
add("RegistroComprasList", RegistroComprasList);
add("SolicitudCompraList", SolicitudCompraList);
add("OrdenCompraList", OrdenCompraList);
add("CuentasPagarList", CuentasPagarList);
add("VentaReporteDialog", VentaReporteDialog);
add("CostosReporteDialog", CostosReporteDialog);
add("ComprasReporteDialog", ComprasReporteDialog);
add("ContabilidadReporteDialog", ContabilidadReporteDialog);
add("AlmacenReporteDialog", AlmacenReporteDialog);
add("CreditosReporteDialog", CreditosReporteDialog);
add("Reporte Costo Venta", ReporteCostoVenta);
add("PreciosManagerList", PreciosManagerList);
add("Servicio Reporte Dialog", ServicioReporteDialog);
add("Personal Reporte Dialog", PersonalReporteDialog);
add("Gerencia Reporte Dialog", GerenciaReporteDialog);
add("Crm Reporte Dialog", CrmReporteDialog);
add("Activos Fijos", ActivosFijos);

// --- Backwards-compatibility: many labels in the legacy `windows.tsx` were
// used by other subsystems. To avoid regressions we add common variants here.
// If a detailed, one-to-one migration of every historical label is desired,
// we can generate these aliases from a source-of-truth mapping file.

const legacyAliases: string[] = [
  // Commonly used nouns and synonyms in the app
  "Ventas", "Ventas - Diario", "Ventas - Mensual", "Ventas - Resumen",
  "Compras", "Compras - Resumen", "Compras - Detalle",
  "Clientes", "Clientes - Lista", "Clientes - Gestión",
  "Proveedores", "Proveedores - Lista", "Proveedores - Gestión",
  "Inventario", "Stock", "Stock Valorado", "Movimientos Almacen",
  "Contabilidad", "Asientos", "Diario", "Mayor", "Balance",
  "Tesoreria", "Caja", "Bancos", "Cuentas por Cobrar", "Cuentas por Pagar",
  "Reportes Ventas", "Reportes Compras", "Reportes Almacen", "Reportes Contabilidad",
  "Configuracion", "Parametros", "Ajustes", "Preferencias",
];

// Map many legacy-like labels to generic containers to preserve behavior.
legacyAliases.forEach(label => {
  // keep detailed report windows mapped to the most likely candidate
  if (label.toLowerCase().includes("venta")) add(label, VentaReporteDialog);
  else if (label.toLowerCase().includes("compra")) add(label, ComprasReporteDialog);
  else if (label.toLowerCase().includes("almacen") || label.toLowerCase().includes("stock") || label.toLowerCase().includes("movimientos")) add(label, AlmacenReporteDialog);
  else if (label.toLowerCase().includes("contabilidad") || label.toLowerCase().includes("asientos") || label.toLowerCase().includes("balance")) add(label, ContabilidadReporteDialog);
  else add(label, ReporteContainer);
});

// --- Heuristic generator for common suffixes/prefixes ---
// This block creates additional normalized labels that historically appeared
// across the monolithic file. It's intentionally verbose so future reviewers
// can see the patterns and remove or refine mappings.

const modules = [
  "Ventas", "Compras", "Almacen", "Precios", "Clientes", "Proveedores", "Contabilidad", "Tesoreria", "Inventarios",
];

const variants: string[] = [];
modules.forEach(m => {
  variants.push(m);
  variants.push(`${m} - Resumen`);
  variants.push(`${m} - Detalle`);
  variants.push(`${m} - Diario`);
  variants.push(`${m} - Mensual`);
  variants.push(`${m} / Reporte`);
  variants.push(`Rpt ${m}`);
  variants.push(`${m} (Reporte)`);
});

variants.forEach(v => {
  if (!registry[normalizeWindowLabel(v)]) {
    // map unknown variants to the generic report container for now
    registry[normalizeWindowLabel(v)] = ReporteContainer;
  }
});

export const hasWindowForLabel = (label: string): boolean => {
  return !!registry[normalizeWindowLabel(label)];
};

export function registerWindow(label: string, comp: WindowComponent) {
  add(label, comp);
}


function LabRow({ label, children }: { label: string; children: React.ReactNode }) {
  return (
    <div className="flex items-center justify-between gap-2">
      <span className="font-semibold text-slate-700">{label}</span>
      <div className="flex items-center">{children}</div>
    </div>
  );
}

type JournalLineForm = {
  id: string;
  account: string;
  description: string;
  reference: string;
  debit: number;
  credit: number;
  cost_center: string;
};


function ProcesarMarcas() {
  return <ProcesoLote label="Procesar Marcas" subtitle="Consolida marcaciones biométricas y calcula asistencia, tardanzas y horas trabajadas del periodo." />;
}

// ---------- Registry ----------
const REGISTRY: Record<string, (label: string) => ReactNode> = {
  "Guía Remisión": () => <GuiaRemision />,
  "Guia Remision": () => <GuiaRemision />,
  "Factura": () => <FacturaVentaList />,
  "Notas": () => <NotaVentaList />,
  "Guía Devolución": () => <GuiaDevolucion />,
  "Boleta": () => <Boleta />,
  "Resumen de Boletas": () => <ResumenBoletas />,
  "Pre y Post Venta": () => <ReporteCotizaciones />,
  "Cotizaciones": () => <ReporteCotizaciones />,
  "Reclamo Garantía": () => <ReclamoGarantia />,
  "Separar Orden": () => <SepararOrden />,
  "Ordenes Compra": () => <ReporteOrdenCompra />,
  "Órdenes Compra": () => <ReporteOrdenCompra />,
  "Actualizar Vendedor": () => <ActualizarVendedor />,
  "Enviar Correos": () => <EnviarCorreos />,
  "Cartera": () => <Cartera />,
  "Requisiciones": () => <Despacho />,
  "Despacho": () => <Despacho />,
  "Precios": () => <PrecioConsulta />,
  "Precios Cliente": () => <PrecioClienteList />,
  "Precio Lista": () => <PrecioListaList />,
  "Precio Oferta": () => <PrecioOfertaList />,
  "Precio Fabricantes": () => <PrecioFabricantesList />,
  "Factores Rubros": () => <FactoresRubrosList />,
  "Registro": () => <RegistroVenta />,
  "Registro Auxiliar": () => <RegistroAuxiliarList />,
  "Resumen Registro": () => <ResumenRegistroList />,
  "Detalle": () => <ReporteVentasDetalladoList />,
  "Guías Remisión": () => <ReporteGuiasRemision />,
  "Nueva Guía": () => <GuiaRemision />,
  "Nueva Nota": () => <NotaVentaList />,
  "Reporte de Ventas Detallado": () => <ReporteVentasDetalladoList />,
  "Reporte Venta Detallado": () => <ReporteVentasDetalladoList />,
};


// Reports of Ventas
const VENTAS_REPORTES = new Set([
  "Registro de Venta", "Acumulada", "Mensuales x Cliente", "Reclamos", "Consignaciones",
  "Presupuesto Venta", "Detalle", "G/R Pendiente", "Vale Requisición", "Detalle Descuento",
  "Órdenes Compra", "Guías Remisión", "Comisiones",
]);

// Reports of Créditos
const CREDITOS_REPORTES = new Set([
  "Cuentas Corrientes", "Documentos Emitidos", "Notas Débito/Crédito", "Notas Débito / Crédito",
  "Vista Cobrador", "Clientes", "Diario de Pagos", "Letras Aceptadas",
  "Vencimientos",
]);

// Reports of Almacenes
const ALMACEN_REPORTES = new Set([
  "Inventario", "Movimientos", "Toma de Inventario", "Vale Materiales",
  "Inv. Perm. Valorizado", "Sin Movimiento",
]);

// Reports of Costos
const COSTOS_REPORTES = new Set([
  "Actualizar Costos", "Diario de Almacén", "Diario de Almacen", "Stock Valorizado", "Kardex", "Condensados",
  "Resumen General", "GMROI", "Cuadrar Cierre", "Costo de Venta", "Motores", "Sobregiro",
]);

// Reports of Contabilidad
const CONTABILIDAD_REPORTES = new Set([
  "Reembolsos", "Ctas Ctes", "Mayor Auxiliar", "Cheques Girados",
  "Libros Oficiales", "Ctas Ctes Pendiente", "Estado Financiero", "Provisionales",
]);

// Reports of Compras
const COMPRAS_REPORTES = new Set([
  "Ordenes Compra", "Pagos Cuentas x Pagar", "Solicitud Gastos",
  "Cuentas x Pagar Por Unidad",
]);

const GERENCIA_REPORTES = new Set([
  "000 - Ventas", "010 - Importaciones", "020 - Inventario y Costos", "030 - Contabilidad",
  "040 - Creditos y Cobranzas", "Datos para Indicadores", "Tarjeta", "Contenedor Reportes", "Estados Financieros",
]);

const CRM_REPORTES = new Set([
  "Oportunidad Negocio", "Tarjeta Cliente", "Cuota Vendedor", "Ocurrencias", "Visita Clientes",
]);

// Reports of Servicios / Talleres
const SERVICIOS_REPORTES = new Set([
  "Actividades", "Plantilla", "Productividad", "Programación", "Programacion", "Tablero",
  "Movimiento Repuestos", "Horas Motor", "Seguimiento", "Generar Pedido", "Horas Escalon", "Horas Escalón",
  "Motores", "Repuestos", "Gastos Detallados", "Horas de Trabajo", "Gastos Por Rubros",
  "Liquidación x Garantía", "Liquidacion x Garantia", "LiquidaciÃ³n x Garantia", "Solicitud Garantía", "Solicitud Garantia",
  "Horas Muertas", "Pendiente Facturación", "Pendiente Facturacion", "Tiempo Reparación", "Tiempo Reparacion",
  "Proyección", "Proyeccion",
]);

// Reports of Personal / RRHH
const PERSONAL_REPORTES = new Set([
  "Tardanzas", "Contratos", "Asistencia", "Onomásticos", "Onomasticos", "Asignación Horario", "Asignacion Horario",
]);

const normalizeSet = (values: Iterable<string>) => new Set(Array.from(values, normalizeWindowLookupKey));
const NORMALIZED_REGISTRY: Record<string, (label: string) => ReactNode> = Object.fromEntries(
  Object.entries(REGISTRY).map(([key, value]) => [normalizeWindowLookupKey(key), value]),
);
const VENTAS_REPORTES_NORMALIZED = normalizeSet(VENTAS_REPORTES);
const CREDITOS_REPORTES_NORMALIZED = normalizeSet(CREDITOS_REPORTES);
const ALMACEN_REPORTES_NORMALIZED = normalizeSet(ALMACEN_REPORTES);
const COSTOS_REPORTES_NORMALIZED = normalizeSet(COSTOS_REPORTES);
const CONTABILIDAD_REPORTES_NORMALIZED = normalizeSet(CONTABILIDAD_REPORTES);
const COMPRAS_REPORTES_NORMALIZED = normalizeSet(COMPRAS_REPORTES);
const GERENCIA_REPORTES_NORMALIZED = normalizeSet(GERENCIA_REPORTES);
const CRM_REPORTES_NORMALIZED = normalizeSet(CRM_REPORTES);
const SERVICIOS_REPORTES_NORMALIZED = normalizeSet(SERVICIOS_REPORTES);
const PERSONAL_REPORTES_NORMALIZED = normalizeSet(PERSONAL_REPORTES);




export function renderWindow(label: string): ReactNode {
  const normalizedLabel = normalizeWindowLookupKey(label);
  if (NORMALIZED_REGISTRY[normalizedLabel]) return NORMALIZED_REGISTRY[normalizedLabel](normalizeWindowLabel(label));

  switch (normalizedLabel) {
    case "Acumulada":
      return <ReporteAcumulada />;
    case "Guias Remision":
      return <GuiaRemision />;
    case "Cotizaciones":
      return <ReporteCotizaciones />;
    case "Vale Requisición":
      return <ReporteValeRequisicion />;
    case "Mensuales x Cliente":
      return <ReporteMensualCliente />;
    case "Detalle Descuento":
      return <ReporteDetalleDescuento />;
    case "Reclamos":
      return <ReporteReclamos />;
    case "OrdenesCompra":
      return <ReporteOrdenCompra />;
    case "Consignaciones":
      return <ReporteConsignacion />;
    case "G/R Pendiente":
      return <ReporteGRPendiente />;
    case "Presupuesto Venta":
      return <ReportePresupuestoVenta />;
    case "Comisiones":
      return <ReporteComisiones />;
    case "Costo de Venta":
      return <ReporteCostoVenta />;
  }

  if (VENTAS_REPORTES_NORMALIZED.has(normalizedLabel)) return <VentaReporteDialog label={normalizeWindowLabel(label)} />;
  if (CREDITOS_REPORTES_NORMALIZED.has(normalizedLabel)) return <CreditosReporteDialog label={normalizeWindowLabel(label)} />;
  if (ALMACEN_REPORTES_NORMALIZED.has(normalizedLabel)) return <AlmacenReporteDialog label={normalizeWindowLabel(label)} />;
  if (COSTOS_REPORTES_NORMALIZED.has(normalizedLabel)) return <CostosReporteDialog label={normalizeWindowLabel(label)} />;
  if (CONTABILIDAD_REPORTES_NORMALIZED.has(normalizedLabel)) return <ContabilidadReporteDialog label={normalizeWindowLabel(label)} />;
  if (COMPRAS_REPORTES_NORMALIZED.has(normalizedLabel)) return <ComprasReporteDialog label={normalizeWindowLabel(label)} />;
  if (GERENCIA_REPORTES_NORMALIZED.has(normalizedLabel)) return <GerenciaReporteDialog label={normalizeWindowLabel(label)} />;
  if (CRM_REPORTES_NORMALIZED.has(normalizedLabel)) return <CrmReporteDialog label={normalizeWindowLabel(label)} />;
  if (SERVICIOS_REPORTES_NORMALIZED.has(normalizedLabel)) return <ServicioReporteDialog label={normalizeWindowLabel(label)} />;
  if (PERSONAL_REPORTES_NORMALIZED.has(normalizedLabel)) return <PersonalReporteDialog label={normalizeWindowLabel(label)} />;

  if (/gerencia|indicador|estado financiero|contenedor reportes|cobranzas|importaciones|inventario y costos/i.test(normalizedLabel)) {
    return <GerenciaReporteDialog label={normalizedLabel} />;
  }
  if (/crm|oportunidad|visita clientes|cuota vendedor|ocurrencias|tarjeta cliente/i.test(normalizedLabel)) {
    return <CrmReporteDialog label={normalizedLabel} />;
  }
  return <RibbonPlaceholder label={normalizeWindowLabel(label)} />;
}

// ---------- MDI floating workspace ----------
export function Workspace() {
  const { windows, active, open, close, focus, move, toggleMaximize, minimize, restore } = useWindows();
  const containerRef = useRef<HTMLDivElement>(null);
  
  // company logo state — updates when session changes
  const { session } = useSession();
  const [empresaLogoUrl, setEmpresaLogoUrl] = useState<string | null>(() => {
    try {
      const initCode = session?.empresa_actual?.codigo ? String(session.empresa_actual.codigo).trim() : null;
      return initCode ? getLogoUrl(initCode) || null : null;
    } catch (_) {
      return null;
    }
  });

  useEffect(() => {
    const onSessionUpdated = (ev: Event) => {
      try {
        const custom = ev as CustomEvent | undefined;
        const sess = custom && custom.detail ? (custom.detail as any) : null;
        if (sess && sess.empresa_actual && sess.empresa_actual.codigo) {
          const code = String(sess.empresa_actual.codigo).trim();
          setEmpresaLogoUrl(code ? getLogoUrl(code) || null : null);
          try {
            // user-visible feedback for debugging: show a toast with the new code
            const newCode = String(sess.empresa_actual.codigo).trim();
            if (newCode) toast.success(`Logo cambiado a empresa ${newCode}`);
            try { console.info('[Workspace] session-updated detail:', sess); } catch (_) {}
          } catch (_) {}
          return;
        }

        // fallback to localStorage when event.detail isn't present
        const raw = window.localStorage.getItem("sigecoom_session");
        if (!raw) {
          setEmpresaLogoUrl(null);
          return;
        }
        const s = JSON.parse(raw as string);
        const code = (s?.empresa_actual?.codigo || "").toString().trim();
        setEmpresaLogoUrl(code ? getLogoUrl(code) || null : null);
      } catch (e) {
        setEmpresaLogoUrl(null);
      }
    };
    window.addEventListener('systeck-session-updated', onSessionUpdated as EventListener);
    return () => window.removeEventListener('systeck-session-updated', onSessionUpdated as EventListener);
  }, []);
  // keep session-driven update as well in case context changes
  useEffect(() => {
    try {
      if (session && session.empresa_actual && session.empresa_actual.codigo) {
        const code = String(session.empresa_actual.codigo).trim();
        setEmpresaLogoUrl(code ? getLogoUrl(code) || null : null);
      }
    } catch (_) {}
  }, [session]);
  const DESKTOP_SMOKE_LABELS = [
    "Factura",
    "Ctas x Cobrar",
    "Doc. Ingresos",
    "Registro Compra",
    "Orden de Compra",
    "Orden de Trabajo",
    "Marcación Online",
    "Usuarios",
    "Oportunidad Negocio",
    "000 - Ventas",
    "Acerca",
  ];

  useEffect(() => {
    const onOpenWindow = (event: Event) => {
      const detail = (event as CustomEvent<{ label?: string }>).detail;
      if (detail?.label) open(detail.label);
    };

    const onRunDesktopSmoke = (event: Event) => {
      const detail = (event as CustomEvent<{ labels?: string[] }>).detail;
      const desktopWindow = window as Window & { __systeckAllMenuLabels?: string[] };
      const sourceLabels =
        (Array.isArray(detail?.labels) && detail.labels.length > 0 && detail.labels)
        || (Array.isArray(desktopWindow.__systeckAllMenuLabels) && desktopWindow.__systeckAllMenuLabels.length > 0 && desktopWindow.__systeckAllMenuLabels)
        || DESKTOP_SMOKE_LABELS;

      const uniqueLabels = Array.from(new Set(
        sourceLabels
          .map((label) => normalizeWindowLabel(String(label)))
          .filter(Boolean),
      ));

      const fallbackLabels = uniqueLabels.filter((label) => {
        const node = renderWindow(label);
        return isValidElement(node) && node.type === RibbonPlaceholder;
      });

      const coveredCount = uniqueLabels.length - fallbackLabels.length;
      uniqueLabels.forEach((label, index) => {
        window.setTimeout(() => open(label), index * 120);
      });

      toast.success("Recorrido desktop E2E iniciado", {
        description: `${uniqueLabels.length} ventanas en apertura secuencial. Cobertura: ${coveredCount}/${uniqueLabels.length}.`,
      });

      if (fallbackLabels.length > 0) {
        const sample = fallbackLabels.slice(0, 6).join(", ");
        const extra = fallbackLabels.length > 6 ? ` (+${fallbackLabels.length - 6} más)` : "";
        toast.message("Cobertura parcial detectada", {
          description: `Fallback en ${fallbackLabels.length} labels: ${sample}${extra}.`,
        });
      } else {
        toast.success("Cobertura completa", {
          description: "No se detectaron labels en fallback.",
        });
      }

      console.info("[Desktop Smoke]", {
        total: uniqueLabels.length,
        covered: coveredCount,
        fallbackCount: fallbackLabels.length,
        fallbackLabels,
      });
    };

    window.addEventListener("systeck-open-window", onOpenWindow as EventListener);
    window.addEventListener("systeck-run-desktop-smoke", onRunDesktopSmoke as EventListener);
    return () => {
      window.removeEventListener("systeck-open-window", onOpenWindow as EventListener);
      window.removeEventListener("systeck-run-desktop-smoke", onRunDesktopSmoke as EventListener);
    };
  }, [open]);

  // No session/logo logic here — keep `Workspace` focused on window rendering.

  const visible = windows.filter(w => !w.isMinimized);
  const minimized = windows.filter(w => w.isMinimized);

  return (
    <div
      ref={containerRef}
      data-mdi-workspace="true"
      className="relative flex-1 bg-slate-200/70 overflow-hidden z-20 min-h-0"
      style={{ flex: 1, backgroundImage: "radial-gradient(circle at 1px 1px, rgba(62,91,122,0.10) 1px, transparent 0)", backgroundSize: "22px 22px" }}
    >
      {/* Watermark — always visible behind floating windows */}
      <div className={["absolute inset-0 grid place-items-center select-none pointer-events-none px-8 transition-opacity duration-300", windows.length > 0 ? "opacity-30" : "opacity-100"].join(" ")}>
        <div className="text-center">
          <img
              src={empresaLogoUrl || c2teckWatermark}
              alt="C2TECK"
              className="max-w-[70vw] max-h-[60vh] w-auto h-auto object-contain opacity-90 drop-shadow-[0_10px_30px_rgba(58,85,115,0.25)]"
            />
            <div className="text-slate-400 text-[11px] mt-6 font-mono">// abre un módulo desde el ribbon superior</div>
          </div>
      </div>

      {/* Company logo top-left removed — central watermark shows company logo instead */}

      {/* Floating windows */}
      <AnimatePresence initial={false}>
      {visible.map(w => (
        <FloatingWindow
          key={w.id}
          win={w}
          isActive={active === w.id}
          containerRef={containerRef}
          onFocus={() => focus(w.id)}
          onClose={() => close(w.id)}
          onMove={(pos) => move(w.id, pos)}
          onToggleMaximize={() => toggleMaximize(w.id)}
          onMinimize={() => minimize(w.id)}
        />
      ))}
      </AnimatePresence>

      {/* Taskbar for minimized windows */}
      {minimized.length > 0 && (
        <div className="absolute bottom-0 left-0 right-0 h-8 bg-gradient-to-t from-[#2A3F55] to-[#3E5B7A] border-t border-slate-900/40 flex items-center gap-1 px-2 z-[9999]">
          {minimized.map(w => (
            <button
              key={w.id}
              onClick={() => restore(w.id)}
              className="desktop-task-enter h-6 px-2 max-w-[180px] flex items-center gap-1.5 text-[11px] text-white bg-white/10 hover:bg-white/20 rounded-sm border border-white/10 truncate transition-all duration-150 active:scale-[0.96]"
              title={w.title}
            >
              <Square className="h-2.5 w-2.5 shrink-0" />
              <span className="truncate">{w.title}</span>
            </button>
          ))}
        </div>
      )}
    </div>
  );
}

type FWProps = {
  win: OpenWindow;
  isActive: boolean;
  containerRef: RefObject<HTMLDivElement | null>;
  onFocus: () => void;
  onClose: () => void;
  onMove: (pos: WindowPos) => void;
  onToggleMaximize: () => void;
  onMinimize: () => void;
};

type ResizeDirection = "n" | "s" | "e" | "w" | "ne" | "nw" | "se" | "sw";

const RESIZE_HANDLES: { direction: ResizeDirection; className: string }[] = [
  { direction: "n", className: "absolute top-0 left-3 right-3 h-2 cursor-n-resize z-10" },
  { direction: "s", className: "absolute bottom-0 left-3 right-3 h-2 cursor-s-resize z-10" },
  { direction: "w", className: "absolute left-0 top-3 bottom-3 w-2 cursor-w-resize z-10" },
  { direction: "e", className: "absolute right-0 top-3 bottom-3 w-2 cursor-e-resize z-10" },
  { direction: "nw", className: "absolute top-0 left-0 h-3 w-3 cursor-nw-resize z-10" },
  { direction: "ne", className: "absolute top-0 right-0 h-3 w-3 cursor-ne-resize z-10" },
  { direction: "sw", className: "absolute bottom-0 left-0 h-3 w-3 cursor-sw-resize z-10" },
  { direction: "se", className: "absolute bottom-0 right-0 h-3 w-3 cursor-se-resize z-10" },
];

const isDiagonalResize = (direction: ResizeDirection) => ["ne", "nw", "se", "sw"].includes(direction);

const STATUS_BAR_H = DESKTOP_STATUS_BAR_H;

function FloatingWindow({ win, isActive, containerRef, onFocus, onClose, onMove, onToggleMaximize, onMinimize }: FWProps) {
  const [pos, setPos] = useState({ x: win.position.x, y: win.position.y });
  const [localSize, setLocalSize] = useState({ w: win.size.w, h: win.size.h });
  const posRef = useRef(pos);
  const sizeRef = useRef(localSize);
  const pendingPosRef = useRef(pos);
  const pendingSizeRef = useRef(localSize);
  const rafRef = useRef<number | null>(null);
  const dragRef = useRef<{ sx: number; sy: number; ox: number; oy: number } | null>(null);
  const resizeRef = useRef<{ sx: number; sy: number; ox: number; oy: number; ow: number; oh: number; dir: ResizeDirection } | null>(null);

  const scheduleVisualUpdate = useCallback(() => {
    if (rafRef.current !== null) return;
    rafRef.current = window.requestAnimationFrame(() => {
      rafRef.current = null;
      setPos(pendingPosRef.current);
      setLocalSize(pendingSizeRef.current);
    });
  }, []);

  const canToggleMaximize = win.canMaximize !== false;

  const onDragStart = (e: ReactMouseEvent<HTMLDivElement>) => {
    if (win.isMaximized) return;
    if ((e.target as HTMLElement).closest("[data-window-control]")) return;
    onFocus();
    dragRef.current = {
      sx: e.clientX,
      sy: e.clientY,
      ox: posRef.current.x,
      oy: posRef.current.y,
    };
    document.body.style.userSelect = "none";
    e.preventDefault();
  };

  const onResizeStart = (direction: ResizeDirection, e: ReactMouseEvent<HTMLDivElement>) => {
    if (win.isMaximized) return;
    if (isDiagonalResize(direction) && !e.shiftKey) return;
    onFocus();
    resizeRef.current = {
      sx: e.clientX,
      sy: e.clientY,
      ox: posRef.current.x,
      oy: posRef.current.y,
      ow: sizeRef.current.w,
      oh: sizeRef.current.h,
      dir: direction,
    };
    document.body.style.userSelect = "none";
    e.preventDefault();
    e.stopPropagation();
  };

  useEffect(() => {
    const onMouseMove = (e: MouseEvent) => {
      const workspace = containerRef.current;
      const workspaceRect = workspace?.getBoundingClientRect();
      const originX = workspaceRect?.left ?? 0;
      const originY = workspaceRect?.top ?? 0;
      const cw = workspaceRect?.width ?? workspace?.clientWidth ?? window.innerWidth;
      const ch = workspaceRect?.height ?? workspace?.clientHeight ?? Math.max(320, window.innerHeight - STATUS_BAR_H);

      const d = dragRef.current;
      if (d) {
        const dx = e.clientX - d.sx;
        const dy = e.clientY - d.sy;
        const screenX = d.ox + dx;
        const screenY = d.oy + dy;
        const maxX = Math.max(originX, originX + cw - sizeRef.current.w);
        const maxY = Math.max(originY, originY + ch - sizeRef.current.h);
        const next = {
          x: Math.min(Math.max(screenX, originX), maxX),
          y: Math.min(Math.max(screenY, originY), maxY),
        };
        pendingPosRef.current = next;
        pendingSizeRef.current = sizeRef.current;
        scheduleVisualUpdate();
        return;
      }

      const r = resizeRef.current;
      if (!r) return;

      const dx = e.clientX - r.sx;
      const dy = e.clientY - r.sy;
      const MIN_W = 360;
      const MIN_H = 220;
      const leftLimit = originX;
      const topLimit = originY;
      const rightLimit = originX + cw;
      const bottomLimit = originY + ch;

      let nx = r.ox;
      let ny = r.oy;
      let nw = r.ow;
      let nh = r.oh;

      if (r.dir.includes("e")) {
        nw = Math.min(rightLimit - nx, Math.max(MIN_W, r.ow + dx));
      }
      if (r.dir.includes("s")) {
        nh = Math.min(bottomLimit - ny, Math.max(MIN_H, r.oh + dy));
      }
      if (r.dir.includes("w")) {
        const maxNx = r.ox + r.ow - MIN_W;
        nx = Math.min(Math.max(r.ox + dx, leftLimit), maxNx);
        nw = r.ow + (r.ox - nx);
      }
      if (r.dir.includes("n")) {
        const maxNy = r.oy + r.oh - MIN_H;
        ny = Math.min(Math.max(r.oy + dy, topLimit), maxNy);
        nh = r.oh + (r.oy - ny);
      }

      nx = Math.min(Math.max(nx, leftLimit), rightLimit - nw);
      ny = Math.min(Math.max(ny, topLimit), bottomLimit - nh);

      nw = Math.min(Math.max(nw, MIN_W), rightLimit - nx);
      nh = Math.min(Math.max(nh, MIN_H), bottomLimit - ny);

      pendingPosRef.current = { x: nx, y: ny };
      pendingSizeRef.current = { w: nw, h: nh };
      scheduleVisualUpdate();
    };

    const onMouseUp = () => {
      if (dragRef.current || resizeRef.current) {
        setPos(pendingPosRef.current);
        setLocalSize(pendingSizeRef.current);
        onMove(pendingPosRef.current);
      }
      dragRef.current = null;
      resizeRef.current = null;
      if (rafRef.current !== null) {
        window.cancelAnimationFrame(rafRef.current);
        rafRef.current = null;
      }
      document.body.style.userSelect = "";
    };

    window.addEventListener("mousemove", onMouseMove);
    window.addEventListener("mouseup", onMouseUp);
    return () => {
      window.removeEventListener("mousemove", onMouseMove);
      window.removeEventListener("mouseup", onMouseUp);
      document.body.style.userSelect = "";
    };
  }, [containerRef, onMove, scheduleVisualUpdate]);

  useEffect(() => {
    setPos(win.position);
    posRef.current = win.position;
    pendingPosRef.current = win.position;
  }, [win.position.x, win.position.y]);

  useEffect(() => {
    posRef.current = pos;
  }, [pos]);

  useEffect(() => {
    setLocalSize(win.size);
    sizeRef.current = win.size;
    pendingSizeRef.current = win.size;
  }, [win.size.w, win.size.h]);

  useEffect(() => {
    sizeRef.current = localSize;
  }, [localSize]);

  const workspaceRect = containerRef.current?.getBoundingClientRect();
  const style: CSSProperties = win.isMaximized
    ? {
        left: workspaceRect?.left ?? 0,
        top: workspaceRect?.top ?? 0,
        width: workspaceRect?.width ?? localSize.w,
        height: workspaceRect?.height ?? localSize.h,
        zIndex: win.zIndex,
        position: "fixed",
      }
    : { left: pos.x, top: pos.y, width: localSize.w, height: localSize.h, zIndex: win.zIndex, position: "fixed" };

  return (
    <motion.div
      className={[
        "flex flex-col overflow-hidden border border-slate-300/80 bg-white transition-[box-shadow,filter] duration-200",
        win.isMaximized ? "rounded-none" : "rounded-lg",
        isActive
          ? "ring-2 ring-[#3B5998]/40 shadow-[0_24px_70px_-20px_rgba(15,23,42,0.48)]"
          : "shadow-[0_12px_35px_-18px_rgba(15,23,42,0.32)]",
      ].join(" ")}
      style={style}
      onMouseDown={onFocus}
      initial="initial"
      animate="animate"
      exit="exit"
      variants={mdiWindowVariants}
      transition={{ duration: 0.18, ease: "easeOut" }}
    >
      {!win.isMaximized && RESIZE_HANDLES.map((handle) => (
        <div
          key={handle.direction}
          data-resize-handle={handle.direction}
          className={handle.className}
          onMouseDown={(event) => onResizeStart(handle.direction, event)}
          aria-hidden="true"
        />
      ))}

      <div
        onMouseDown={onDragStart}
        onDoubleClick={canToggleMaximize ? onToggleMaximize : undefined}
        className={[
          "h-9 px-3 flex items-center justify-between select-none shrink-0",
          win.isMaximized ? "cursor-default" : "cursor-move",
          isActive
            ? "bg-gradient-to-r from-[#0B1220] via-[#162338] to-[#0B1220] text-white border-b border-cyan-300/30"
            : "bg-gradient-to-r from-slate-300 to-slate-400 text-slate-800 border-b border-slate-400",
        ].join(" ")}
      >
        <div className="flex items-center gap-2 min-w-0">
          <div className={["h-5 w-5 rounded-md grid place-items-center shrink-0", isActive ? "bg-cyan-300/15 text-cyan-300 ring-1 ring-cyan-300/25" : "bg-white/40 text-slate-700"].join(" ")}>
            <FileText className="h-3 w-3" />
          </div>
          <span className="text-[12px] font-semibold truncate">{win.title}</span>
        </div>

        <div className="flex items-center gap-2 text-[10px] font-mono text-cyan-100/90" data-window-control>
          <span className="rounded bg-white/10 px-1.5 py-0.5">w: {Math.round(localSize.w)}</span>
          <span className="rounded bg-white/10 px-1.5 py-0.5">h: {Math.round(localSize.h)}</span>
        </div>

        <div className="flex items-center gap-0.5" data-window-control>
          <button
            type="button"
            onClick={(e) => { e.stopPropagation(); onMinimize(); }}
            className="h-6 w-8 grid place-items-center rounded hover:bg-white/20 transition-all duration-150 active:scale-90"
            title="Minimizar"
          >
            <Minus className="h-3.5 w-3.5" />
          </button>
          <button
            type="button"
            disabled={!canToggleMaximize}
            onClick={(e) => {
              if (!canToggleMaximize) return;
              e.stopPropagation();
              onToggleMaximize();
            }}
            className={[
              "h-6 w-8 grid place-items-center rounded transition-all duration-150",
              canToggleMaximize
                ? "hover:bg-white/20 active:scale-90"
                : "opacity-40 cursor-not-allowed",
            ].join(" ")}
            title={win.isMaximized ? "Restaurar" : "Maximizar"}
            aria-disabled={!canToggleMaximize}
          >
            {win.isMaximized ? (
              <Minimize2 className={"h-3.5 w-3.5"} />
            ) : (
              <Maximize2 className={"h-3.5 w-3.5"} />
            )}
          </button>
          <button
            type="button"
            onClick={(e) => { e.stopPropagation(); onClose(); }}
            className="h-6 w-8 grid place-items-center rounded hover:bg-red-600 hover:text-white transition-all duration-150 active:scale-90"
            title="Cerrar"
          >
            <X className="h-3.5 w-3.5" />
          </button>
        </div>
      </div>

      <div className="flex-1 min-h-0 overflow-hidden bg-slate-100">
        {renderWindow(win.label)}
      </div>
    </motion.div>
  );
}
