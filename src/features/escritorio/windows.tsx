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
import { ConsultaDocumentosVentaWindow, ConsultaDocumentosVentaList } from "./windows/Ventas/Consultas/Documentos";
import { PrecioConsulta, PrecioConsultaList } from "./windows/Ventas/Consultas/Precios";

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

import { ReporteCotizaciones, ReporteCotizacionesList } from "./windows/Ventas/Reportes/Cotizaciones";
import { ReporteVentasDetalladoList, ReporteVentasDetallado, ReporteDetalle } from "./windows/Ventas/Reportes/Detalle";
import { ReporteValeRequisicionList, ReporteValeRequisicion } from "./windows/Ventas/Reportes/ValeRequisicion";
import { ReporteMensualClienteList, ReporteMensualCliente } from "./windows/Ventas/Reportes/MensualesXCliente";
import { ReporteDetalleDescuentoList, ReporteDetalleDescuento } from "./windows/Ventas/Reportes/DetalleDescuento";
import { ReporteReclamosList, ReporteReclamos } from "./windows/Ventas/Reportes/Reclamos";
import { ReporteOrdenCompra, ReporteOrdenCompraList } from "./windows/Ventas/Reportes/OrdenesCompra";
import { ReporteConsignacionList, ReporteConsignacion } from "./windows/Ventas/Reportes/Consignaciones";
import { ReporteGuiasRemision, ReporteGuiasRemisionList } from "./windows/Ventas/Reportes/GuiasRemision";
import { ReporteGRPendiente, ReporteGRPendienteList } from "./windows/Ventas/Reportes/GRPendiente";
import { ReportePresupuestoVenta, ReportePresupuestoVentaList } from "./windows/Ventas/Reportes/PresupuestoVenta";
import { ReporteComisiones, ReporteComisionesList } from "./windows/Ventas/Reportes/Comisiones";
import { ReporteAcumulada, ReporteAcumuladaList } from "./windows/Ventas/Reportes/Acumulada";

// ALMACENES
// Almacén
import { DespachoWindow, DespachoList2 } from "./windows/Almacenes/Almacen/Despacho";
import { DocSalidas, DocSalidasList } from "./windows/Almacenes/Almacen/DocSalidas";
import { ChequeoFI, ChequeoFIList } from "./windows/Almacenes/Almacen/ChequeoFI";
import { AtenderOT, AtenderOTList } from "./windows/Almacenes/Almacen/AtenderOT";
import { DatosDespachoWindow, DatosDespachoList } from "./windows/Almacenes/Almacen/DatosDespachoClientes";
import { Vales, ValesList } from "./windows/Almacenes/Almacen/Vales";
import { AlmacenTI, AlmacenTIList } from "./windows/Almacenes/Almacen/TI";
import { AlmacenMTI, AlmacenMTIList } from "./windows/Almacenes/Almacen/MTI";

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
import { ReporteVentas, ReporteVentasList } from "./windows/Gerencia/Reportes/000Ventas";
import { ReporteImportacion, ReporteImportacionList } from "./windows/Gerencia/Reportes/010Importaciones";
import { ReporteInvencos, ReporteInvencosList } from "./windows/Gerencia/Reportes/020InventarioYCostos";
import { ReporteContabilidad, ReporteContabilidadList } from "./windows/Gerencia/Reportes/030Contabilidad";
import { ReporteCreco, ReporteCrecoList } from "./windows/Gerencia/Reportes/040CreditosYCobranzas";
import { ReporteContenedor, ReporteContenedorList } from "./windows/Gerencia/Reportes/ContenedorReportes";
import { ReporteIndicador, ReporteIndicadorList } from "./windows/Gerencia/Reportes/DatosParaIndicadores";
import { ReporteFinanciero, ReporteFinancieroList } from "./windows/Gerencia/Reportes/EstadosFinancieros";
import { ReporteTarjeta, ReporteTarjetaList } from "./windows/Gerencia/Reportes/Tarjeta";

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
import { GerenciaVentasWindow } from "./windows/Gerencia/Reportes/000Ventas";
import { GerenciaImportacionesWindow } from "./windows/Gerencia/Reportes/010Importaciones";
import { GerenciaInventarioCostosWindow } from "./windows/Gerencia/Reportes/020InventarioYCostos";
import { GerenciaContabilidadWindow } from "./windows/Gerencia/Reportes/030Contabilidad";
import { GerenciaCreditosWindow } from "./windows/Gerencia/Reportes/040CreditosYCobranzas";
import { ContenedorReportes, ContenedorReportesWindow } from "./windows/Gerencia/Reportes/ContenedorReportes";
import { DatosParaIndicadores ,DatosParaIndicadoresWindow } from "./windows/Gerencia/Reportes/DatosParaIndicadores";
import { EstadosFinancieros, EstadosFinancierosWindow } from "./windows/Gerencia/Reportes/EstadosFinancieros";
import { Tarjeta, TarjetaGerenciaWindow } from "./windows/Gerencia/Reportes/Tarjeta";
import { Resultado, ResultadoEncuestaWindow } from "./windows/Administracion/Encuestas/Resultado";

// Inventario
import { ComputadoraAsignar, ComputadoraAsignarList } from "./windows/Administracion/Inventario/AsignarComputadora";
import { ComputadoraInv, ComputadoraInvList } from "./windows/Administracion/Inventario/Computadora";

// Llamadas
import { LlamadasWin, LlamadasWinList } from "./windows/Administracion/Llamadas/Llamadas";

// Tablas Generales
import { EmpresasWindow, EmpresasList } from "./windows/Administracion/Tablas Generales/Empresas";
import { EquiposMarcacionPersonalWindow, EquiposMarcacionPersonalList } from "./windows/Administracion/Tablas Generales/EquiposMarcacionPersonal";
import { LocacionesWindow, LocacionesList } from "./windows/Administracion/Tablas Generales/Locaciones";
import { ParametrosLocacionesWindow, ParametrosLocacionesList } from "./windows/Administracion/Tablas Generales/ParametrosLocaciones";
import { ParametrosPlanillaSueldosWindow, ParametrosPlanillaSueldosList } from "./windows/Administracion/Tablas Generales/ParametrosPlanillaSueldos";
import { RubrosDeProductosWindow, RubrosDeProductosList } from "./windows/Administracion/Tablas Generales/RubrosDeProductos";
import { RubrosXEmpresaWindow, RubrosXEmpresaList } from "./windows/Administracion/Tablas Generales/RubrosXEmpresa";
import { SeriesDocumentosWindow, SeriesDocumentosList } from "./windows/Administracion/Tablas Generales/SeriesDocumentos";

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
import { MovimientosAlmacenList, DocIngresosList, DocSalidasList2, TransferenciasList, DocIngresos } from "./windows/MovimientosAlmacen";
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

// --- Precios group ---
addAliases("Precios", ["Precios y Tarifas", "Gestor Precios"], PreciosManagerList);
addAliases("Precios Cliente", ["Precio por Cliente", "Precios-Cliente"], PrecioClienteList);
addAliases("Precio Oferta", ["Ofertas", "Precios Oferta"], PrecioOfertaList);
add("Factores Rubros", FactoresRubrosList);
add("Precio Lista", PrecioListaList);
add("Precio Fabricantes", PrecioFabricantesList);
add("Consulta Precios", ConsultaPreciosDialogList);

// --- Ventas / Registro ---
add("Registro Venta", RegistroVentaList);
addAliases("Registro Auxiliar", ["Registro-Aux", "Auxiliar Registro"], RegistroAuxiliarList);
add("Resumen Registro", ResumenRegistroList);

// Documentos de ventas y listas relacionadas
addAliases("Guías de Remisión", ["Guia Remision", "Guía Remisión", "Guias Remision"], GuiaRemisionList);
addAliases("Nueva Guía Remisión", ["Nueva Guia Remision", "New Guide", "Guia Remision - Nuevo"], NewGuideWindow);
addAliases("Factura de Venta", ["Facturas", "Factura Venta", "Factura de Ventas"], FacturaVentaList);
addAliases("Nota de Venta", ["Notas", "Nota Venta", "Nota de Ventas"], NotaVentaList);
addAliases("Clientes", ["Clientes - Lista", "Clientes - Gestión", "Clientes - Gestión"], ClientesList);
addAliases("Productos", ["Inventario", "Productos - Lista", "Productos - Gestión"], ProductosList);

// --- Almacén ---
add("Despacho", DespachoList2);
add("Doc Salidas", DocSalidas);
add("Vales", Vales);
add("Tarjetas", Tarjetas);
add("Calendario", Calendario);
add("Procesar Cobertura", ProcesarCobertura);
add("Liqui Gastos", LiquiGastos);

// Movimientos de almacén y entradas/salidas
addAliases("Documentos Ingreso", ["Doc Ingresos", "Ingresos"], DocIngresosList);
addAliases("Documentos Salida", ["Doc Salidas", "Salidas", "Salidas Almacen"], DocSalidasList2);
addAliases("Transferencias", ["Transferencias Almacen", "Traslados"], TransferenciasList);

// Compras / Cuentas por pagar / Solicitudes
addAliases("Registro Compras", ["Compras Registro", "Registro de Compras"], RegistroComprasList);
addAliases("Solicitudes de Compra", ["Solicitud Compra", "Solicitudes Compra"], SolicitudCompraList);
addAliases("Ordenes de Compra", ["Orden Compra", "Ordenes Compra", "O.C."], OrdenCompraList);
addAliases("Cuentas por Pagar", ["Cuentas Pagar", "Proveedores - Cuentas"], CuentasPagarList);
addAliases("Solicitudes de Gasto", ["Solicitud Gasto", "Gastos Solicitud"], SolicitudGastoList);
addAliases("Planilla Viaticos", ["Planilla Viaticos", "Viaticos"], PlanillaViaticosList);

// Ubicaciones y movimientos
addAliases("Ubicaciones", ["Ubicaciones - Lista", "Localizaciones"], UbicacionesWindow);
addAliases("Movimientos Almacen", ["Movimientos", "Mov. Almacen"], MovimientosAlmacenList);
addAliases("Documentos Ingreso", ["Ingresos"], DocIngresosList);
addAliases("Transferencias Almacen", ["Transferencias"], TransferenciasList);

// Forms and detail windows
addAliases("Guia Remision Form", ["Guia Remision - Form", "Guía Remisión - Form"], GuiaRemisionForm);
addAliases("Nota Venta Form", ["Nota Venta - Form", "Nota - Form"], NotaVentaForm);

// --- Reportes (grouped examples) ---
addAliases(
  "Reporte de Ventas Detallado",
  ["Reporte Venta Detallado", "Venta Detallada", "Rpt Venta Detallado"],
  ReporteVentasDetalladoList,
);
add("Reporte Costos", CostosReporteDialog);
add("Reporte Compras", ComprasReporteDialog);
add("Reporte Contabilidad", ContabilidadReporteDialog);
add("Reporte Almacen", AlmacenReporteDialog);
add("Reporte Creditos", CreditosReporteDialog);
add("Reporte Guias", ReporteGuiasRemision);
add("Reporte Mensual Cliente", ReporteMensualClienteList);
add("Reporte Orden Compra", ReporteOrdenCompraList);
add("Reporte Presupuesto Venta", ReportePresupuestoVentaList);
add("Reporte Reclamos", ReporteReclamosList);
add("Reporte Vale Requisicion", ReporteValeRequisicionList);
add("Reporte GR Pendiente", ReporteGRPendienteList);
add("Reporte Detalle Descuento", ReporteDetalleDescuentoList);
add("Reporte Cotizaciones", ReporteCotizacionesList);
add("Reporte Consignacion", ReporteConsignacionList);
add("Consignaciones", ReporteConsignacionList);
add("Reporte Comisiones", ReporteComisionesList);
add("Reporte Acumulada", ReporteAcumuladaList);

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
  // === Ventas ===
  // Ventas > Documentos
  "Guía Remisión": () => <GuiaRemision />,
  "Guia Remision": () => <GuiaRemision />,
  "Factura": () => <Factura />,
  "Notas": () => <Notas />,
  "Guía Devolución": () => <GuiaDevolucion />,
  "Boleta": () => <Boleta />,
  "Resumen de Boletas": () => <ResumenBoletas />,
  "Pre y Post Venta": () => <ReporteCotizaciones />,
  // Pre y Post
  "Cotizaciones": () => <ReporteCotizaciones />,
  "Reclamo Garantía": () => <ReclamoGarantia />,
  "Separar Orden": () => <SepararOrden />,
  "Ordenes Compra": () => <ReporteOrdenCompra />,
  "Órdenes Compra": () => <ReporteOrdenCompraList />,
  "Actualizar Vendedor": () => <ActualizarVendedor />,
  "Enviar Correos": () => <EnviarCorreos />,
  // Clientes / Requisiciones
  "Cartera": () => <Cartera />,
  "Requisiciones": () => <Despacho />,
  "Despacho": () => <Despacho />,
  "Precios": () => <PreciosManager initial="Precio Lista" />,
  // Precios
  "Precios Cliente": () => <PrecioCliente />,
  "Precio Lista": () => <PrecioLista />,
  "Precio Oferta": () => <PrecioOferta />,
  "Precio Fabricantes": () => <PrecioFabricantes />,
  "Factores Rubros": () => <FactoresRubros />,
  // Registro de Venta windows
  "Registro": () => <RegistroVenta />,
  "Registro Auxiliar": () => <RegistroAuxiliar />,
  "Resumen Registro": () => <ResumenRegistro />,
  "Detalle": () => <ReporteDetalle />,
  "Guías Remisión": () => <ReporteGuiasRemisionList />,
  "Nueva Guía": () => <NuevaGuia />,
  "Nueva Nota": () => <NuevaNota />,
  "Reporte de Ventas Detallado": () => <ReporteVentasDetallado />,
  "Reporte Venta Detallado": () => <ReporteVentasDetallado />,

  // === Almacenes ===
  "Doc.Ingresos": () => <DocIngresos />,
  "Doc. Ingresos": () => <DocIngresosList />,
  "Doc.Salidas": () => <DocSalidasList />,
  "Doc. Salidas": () => <DocSalidas />,
  "Chequeo F/I": () => <ChequeoFI />,
  "T / I": () => <TransitoDocs />,
  "T/I": () => <TransitoDocs />,
  "M T I": () => <TransitoDocs />,
  "MTI": () => <TransitoDocs />,
  "Vales": () => <Vales />,
  "Atender OT": () => <AtenderOT />,
  "Despachos": () => <Despacho />,
  "Datos Despacho Clientes": () => <Despacho />,
  "Transferencias": () => <TransferenciasList />,
  "Compras": () => <TransitoDocs />,
  "Documentos": () => <TransitoDocs />,
  "Anulación en Consulta": () => <TransitoDocs />,
  "Productos": () => <ProductosList />,
  "Liqui. Gastos": () => <LiquiGastos />,
  "Act. Min Max": () => <ActMinMax />,
  "Ubicaciones": () => <UbicacionesWindow />,
  "Tarjetas": () => <Tarjetas />,
  "Calendario": () => <Calendario />,
  "Procesar Cobertura": () => <ProcesarCobertura />,
  "Vales / Despachos": () => <AtenderOT />,

  // === Créditos ===
  "Ctas x Cobrar": () => <CtasXCobrar />,
  "Cuentas x Cobrar": () => <CtasXCobrar />,
  "Planillas": () => <Planillas />,
  "Anticipos": () => <Anticipos />,
  "Letras": () => <Letras />,
  "Créditos": () => <AprobacionCreditos />,
  "Creditos": () => <AprobacionCreditos />,
  "Cotiz. Taller": () => <CotizTallerCredito />,
  "Permiso Usuario": () => <PermisoUsuarioCreditos />,
  "Recepcion Doc.": () => <RecepcionDocCreditos />,
  "Recepción Doc.": () => <RecepcionDocCreditos />,
  "Factores y Descuentos": () => <FactoresRubros />,
  "Saldo Bancos": () => <SaldoBancosCreditos />,
  "Visitas Cobrador": () => <CreditosReporteDialog label="Visitas Cobrador" />,
  "Procesar Job": () => <ProcesoLote label="Procesar Job" subtitle="Procesa y vincula documentos pendientes asociados a créditos." />,
  "Vincular G/R": () => <ProcesoLote label="Vincular G/R" subtitle="Relaciona guías de remisión con documentos comerciales y de cobranza." />,
  "Tipo Cambio Ventas": () => <TipoCambio />,
  "Renueva Tipo Cambio": () => <TipoCambio />,
  "Mantenimiento Tipo de Cambio": () => <TipoCambio />,
  "Consultas": () => <LookupDialog title="Consultas" columns={["Código", "Descripción", "Estado", "Referencia"]} rows={10} />,
  "Ctas. x Cobrar": () => <CtasXCobrar />,
  "Notas Debito/Credito": () => <CreditosReporteDialog label="Notas Debito/Credito" />,
  "Visita Cobrador": () => <CreditosReporteDialog label="Visita Cobrador" />,
  "Detalle Vencimientos": () => <CreditosReporteDialog label="Detalle Vencimientos" />,
  "Acumulado Vencimientos": () => <CreditosReporteDialog label="Acumulado Vencimientos" />,

  // === Importaciones ===
  "Embarque": () => <OrdenImportacion />,
  "Orden Importación": () => <OrdenImportacion />,
  "Internos": () => <OrdenImportacion />,
  "Orden de Importación": () => <OrdenImportacion />,
  "Embarques de Importación": () => <OrdenImportacion />,
  "Pedido Interno": () => <OrdenImportacion />,

  // === Costos ===
  "Valorizar F/I": () => <ValorizarFI />,
  "Recalcular": () => <ProcesoLote label="Recalcular Costos" subtitle="Recalcula el costo promedio ponderado de todos los productos del periodo seleccionado." />,
  "Ajustar Costos": () => <ValorizarFI />,
  "Cerrar Mes": () => <ProcesoLote label="Cerrar Mes" subtitle="Congela el mes comercial: bloquea documentos y libera datos para auditoría." />,
  "Consolidado": () => <ProcesoLote label="Consolidado" subtitle="Consolida movimientos y saldos de todos los almacenes." />,
  "Trasladar Costos": () => <ProcesoLote label="Trasladar Costos" subtitle="Transfiere costos calculados hacia contabilidad y kardex valorizado." />,
  "Generar Periodo": () => <ProcesoLote label="Generar Periodo" subtitle="Crea el nuevo periodo contable / comercial." />,
  "Inv. Rotativo": () => <ProcesoLote label="Inventario Rotativo" subtitle="Genera muestras de conteo rotativo por categoría / ubicación." />,
  "Importaciones": () => <CostosReporteDialog label="Importaciones" />,

  // === Gerencia ===
  "000 - Ventas": () => <GerenciaReporteDialog label="000 - Ventas" />,
  "010 - Importaciones": () => <GerenciaReporteDialog label="010 - Importaciones" />,
  "020 - Inventario y Costos": () => <GerenciaReporteDialog label="020 - Inventario y Costos" />,
  "030 - Contabilidad": () => <GerenciaReporteDialog label="030 - Contabilidad" />,
  "040 - Creditos y Cobranzas": () => <GerenciaReporteDialog label="040 - Creditos y Cobranzas" />,
  "Datos para Indicadores": () => <GerenciaReporteDialog label="Datos para Indicadores" />,
  "Tarjeta": () => <GerenciaReporteDialog label="Tarjeta" />,
  "Contenedor Reportes": () => <GerenciaReporteDialog label="Contenedor Reportes" />,
  "Estados Financieros": () => <GerenciaReporteDialog label="Estados Financieros" />,

  // === Servicios ===
  "Pedir Repuestos": () => <PedirRepuestos />,
  "Cotizacion": () => <ReporteCotizaciones />,
  "Orden de Trabajo": () => <OrdenTrabajo />,
  "Solicitud OT": () => <OrdenTrabajo />,
  "OT": () => <OrdenTrabajo />,
  "Marcaciones": () => <Marcaciones title="Marcaciones — OT" />,
  "Gastos Reales": () => <OrdenTrabajo />,
  "Pre Marcacion": () => <Marcaciones title="Pre Marcación — OT" />,
  "Pre Marcación": () => <Marcaciones title="Pre Marcación — OT" />,
  "Marcar OT": () => <Marcaciones title="Marcar OT" />,
  "Garantía": () => <GarantiaWin title="Garantía" />,
  "Garantia": () => <GarantiaWin title="Garantía" />,
  "Orden Reparación": () => <GarantiaWin title="Orden de Reparación" />,
  "Reclamo Cliente": () => <GarantiaWin title="Reclamo Cliente" />,
  "Control Vehicular": () => <Kilometraje />,
  "Kilometraje": () => <Kilometraje />,
  "Mantenimiento": () => <OficinaUsuario />,
  "Oficina Usuario": () => <OficinaUsuario />,
  "Gastos Detalle": () => <ServicioReporteDialog label="Gastos Detalle" />,
  "Gastos Detallado": () => <ServicioReporteDialog label="Gastos Detallado" />,
  "Liquidación x Garantia": () => <ServicioReporteDialog label="Liquidación x Garantia" />,
  "LiquidaciÃ³n x Garantia": () => <ServicioReporteDialog label="LiquidaciÃ³n x Garantia" />,

  // === Compras ===
  "Solicitud de Compra": () => <SolicitudCompraList />,
  "Solicitud Compra": () => <SolicitudCompraList />,
  "Orden de Compra": () => <OrdenCompraList />,
  "Solicitud Gasto": () => <SolicitudGastoList />,
  "Planilla Viático": () => <PlanillaViaticosList />,
  "Planilla Viatico": () => <PlanillaViaticosList />,
  "Planilla Viáticos": () => <PlanillaViaticosList />,
  "Tarifa Gasto Viaje": () => <MantenimientoCRUD label="Tarifa Gasto Viaje" columns={["Ruta", "Categoría", "Moneda", "Tarifa", "Estado"]} />,
  "Tarifa Taxis Casa": () => <MantenimientoCRUD label="Tarifa Taxis Casa" columns={["Zona", "Horario", "Moneda", "Tarifa", "Estado"]} />,
  "Tarifas Taxi Destino": () => <MantenimientoCRUD label="Tarifas Taxi Destino" columns={["Destino", "Tipo", "Moneda", "Tarifa", "Estado"]} />,
  "Cuentas x Pagar": () => <CuentasPagarList />,
  "Compras y/o Gastos": () => <RegistroComprasList />,
  "Orden Compra": () => <OrdenCompraList />,
  "Solicitud Gastos": () => <SolicitudGastoList />,
  "Pagos Cuentas x Pagar": () => <ReportePagosCuentasXPagar />,
  "Cuentas x Pagar Por Unidad": () => <ReporteCtasXPagarUnidad />,
  "Tarifas": () => <PreciosManager initial="Precio Lista" />,

  // === Personal ===
  "Informacion": () => <FichaGeneral />,
  "Ficha General": () => <FichaGeneral />,
  "Vacaciones": () => <CapacitacionesWin title="Vacaciones" />,
  "Capacitaciones": () => <CapacitacionesWin title="Capacitaciones" />,
  "Evaluaciones": () => <CapacitacionesWin title="Evaluaciones de Desempeño" />,
  "Planilla Sueldos": () => <PlanillaSueldos />,
  "Quinta Categoría": () => <PlanillaSueldos />,
  "Quinta Categoria": () => <PlanillaSueldos />,
  "Faltas": () => <PersonalTiempo title="Faltas" />,
  "Marcación": () => <MarcacionOnline />,
  "Marcacion": () => <MarcacionOnline />,
  "Asigna H. Extra": () => <PersonalTiempo title="Asignación H. Extra" />,
  "Horarios": () => <PersonalTiempo title="Horarios / Turnos" />,
  "Horas Extras": () => <PersonalTiempo title="Horas Extras" />,
  "Ingresos": () => <PersonalTiempo title="Ingresos" />,
  "Descuentos": () => <PersonalTiempo title="Descuentos" />,
  "Jefe Área": () => <PersonalTiempo title="Jefe de Área" />,
  "Jefe Area": () => <PersonalTiempo title="Jefe de Área" />,
  "Recursos": () => <PersonalTiempo title="Recursos" />,
  "Cronograma Mina": () => <PersonalTiempo title="Cronograma Mina" />,
  "Marcación Online": () => <MarcacionOnline />,
  "Marcacion Online": () => <MarcacionOnline />,
  "Comunicaciones": () => <EnviarCorreos />,
  "Admin. Lector": () => <MarcacionOnline />,
  "Procesar Marcas": () => <ProcesarMarcas />,
  "Asig. H. Extra": () => <PersonalTiempo title="Asignación H. Extra" />,
  "Personal": () => <PersonalReporteDialog label="Personal" />,

  // === Rondas ===
  "Puntos Control Rutas": () => <PuntosControl title="Puntos de Control" />,
  "Ruteador Rutas": () => <PuntosControl title="Ruteador de Rutas" />,
  "Rondas": () => <PuntosControl title="Rondas" />,

  // === Contabilidad ===
  "Asientos": () => <Asientos />,
  "Movimiento Bancos": () => <MovimientoBancos />,
  "Registro Compra": () => <RegistroComprasList />,
  "Recibo Honorario": () => <RegistroComprasList />,
  "Diario": () => <ReporteContainer label="Libro Diario" />,
  "Provisional": () => <CajaChica />,
  "Reembolso": () => <CajaChica />,
  "Arqueo Caja": () => <CajaChica />,
  "Cuenta Destino": () => <ProcesoLote label="Cuenta Destino" subtitle="Reasigna asientos entre cuentas contables destino." />,
  "Cierre Mes": () => <ProcesoLote label="Cierre Mes" subtitle="Cierre contable mensual con validación de saldos cuadrados." />,
  "Dif. Tipo Cambio": () => <ProcesoLote label="Diferencia de Tipo de Cambio" subtitle="Calcula pérdidas / ganancias por diferencia en tipo de cambio del periodo." />,
  "Generar TXT Libros": () => <GenerarTXT />,
  "Flujo de Caja": () => <FlujoCaja />,
  "Ctas x Pagar": () => <CuentasPagarList />,
  "Libro Diario": () => <ContabilidadReporteDialog label="Libro Diario" />,
  "Libro Mayor": () => <ContabilidadReporteDialog label="Libro Mayor" />,
  "Caja y Bancos": () => <ContabilidadReporteDialog label="Caja y Bancos" />,
  "Registro de Compras": () => <ContabilidadReporteDialog label="Registro de Compras" />,

  // === Telefonía ===
  "Modelos": () => <TelefoniaInv title="Modelos" />,
  "Equipos": () => <TelefoniaInv title="Equipos" />,
  "Planes": () => <TelefoniaInv title="Planes" />,
  "Líneas": () => <TelefoniaInv title="Líneas" />,
  "Lineas": () => <TelefoniaInv title="Líneas" />,
  "Asigna Persona": () => <AsignaPersona />,

  // === CRM ===
  "Oportunidad Negocio": () => <CrmReporteDialog label="Oportunidad Negocio" />,
  "Ocurrencias": () => <CrmReporteDialog label="Ocurrencias" />,
  "Tarjeta Cliente": () => <CrmReporteDialog label="Tarjeta Cliente" />,
  "Visita Clientes": () => <CrmReporteDialog label="Visita Clientes" />,
  "Cuota Vendedor": () => <CrmReporteDialog label="Cuota Vendedor" />,

  // === Activos ===
  "Activos Fijos": () => <ActivosFijos />,
  "Reporte Activos Fijos": () => <ReporteContainer label="Reporte Activos Fijos" />,

  // === Tablas ===
  "Clientes": () => <ClientesList />,
  "Condición de Pago": () => <MantenimientoCRUD label="Condición de Pago" columns={["Código", "Descripción", "Días", "Tipo", "Estado"]} />,
  "CondiciÃ³n de Pago": () => <MantenimientoCRUD label="Condición de Pago" columns={["Código", "Descripción", "Días", "Tipo", "Estado"]} />,
  "Tipo Motores": () => <MantenimientoCRUD label="Tipo Motores" columns={["Código", "Tipo", "Marca", "Estado"]} />,
  "Modelos ": () => <MantenimientoCRUD label="Modelos" columns={["Código", "Modelo", "Marca", "Estado"]} />,
  "Categorías": () => <MantenimientoCRUD label="Categorías" columns={["Código", "Categoría", "Rubro", "Estado"]} />,
  "Categorias": () => <MantenimientoCRUD label="Categorías" columns={["Código", "Categoría", "Rubro", "Estado"]} />,
  "Partidas": () => <MantenimientoCRUD label="Partidas Arancelarias" columns={["Partida", "Descripción", "Ad Valorem", "Estado"]} />,
  "Marcas": () => <MantenimientoCRUD label="Marcas" columns={["Código", "Marca", "Origen", "Estado"]} />,
  "Plantilla Repuestos": () => <MantenimientoCRUD label="Plantillas de Repuestos" columns={["Código", "Plantilla", "Modelo", "Nº items", "Estado"]} />,
  "Plantillas Repuestos": () => <MantenimientoCRUD label="Plantillas de Repuestos" columns={["Código", "Plantilla", "Modelo", "Nº items", "Estado"]} />,
  "Plantilla Repuestos Cliente": () => <MantenimientoCRUD label="Plantillas de Repuestos por Cliente" columns={["Cliente", "Plantilla", "Modelo", "Vigencia", "Estado"]} />,
  "Ubicacion Servicio": () => <MantenimientoCRUD label="Ubicación de Servicio" columns={["Código", "Ubicación", "Sede", "Responsable", "Estado"]} />,
  "Vehículos": () => <MantenimientoCRUD label="Vehículos" columns={["Placa", "Marca", "Modelo", "Año", "Cliente", "Estado"]} />,
  "Vehiculos": () => <MantenimientoCRUD label="Vehículos" columns={["Placa", "Marca", "Modelo", "Año", "Cliente", "Estado"]} />,
  "Proveedores": () => <MantenimientoCRUD label="Proveedores" columns={["RUC", "Razón Social", "Dirección", "Contacto", "Teléfono", "Estado"]} />,
  "Cuenta Contable": () => <MantenimientoCRUD label="Cuentas Contables" columns={["Cuenta", "Descripción", "Naturaleza", "Nivel", "Estado"]} />,
  "Cuentas Destino": () => <MantenimientoCRUD label="Cuentas Destino" columns={["Cuenta", "Destino", "Módulo", "Estado"]} />,
  "Rubro Planilla": () => <MantenimientoCRUD label="Rubros de Planilla" columns={["Código", "Rubro", "Tipo", "Afecta", "Estado"]} />,
  "Rubro Planilla Ctas": () => <ConfigTabla title="Rubro Planilla Ctas" columns={["Rubro", "Cuenta Debe", "Cuenta Haber", "Estado"]} />,
  "Horarios ": () => <MantenimientoCRUD label="Horarios" columns={["Código", "Horario", "Entrada", "Salida", "Tolerancia", "Estado"]} />,
  "Feriados": () => <MantenimientoCRUD label="Feriados" columns={["Fecha", "Descripción", "Tipo", "Ámbito", "Estado"]} />,
  "AFP": () => <MantenimientoCRUD label="AFP" columns={["Código", "AFP", "Comisión %", "Prima %", "Aporte %", "Estado"]} />,
  "Cargos": () => <MantenimientoCRUD label="Cargos" columns={["Código", "Cargo", "Área", "Nivel", "Estado"]} />,
  "Áreas": () => <MantenimientoCRUD label="Áreas" columns={["Código", "Área", "Responsable", "Estado"]} />,
  "Areas": () => <MantenimientoCRUD label="Áreas" columns={["Código", "Área", "Responsable", "Estado"]} />,
  "Motivos Faltas": () => <MantenimientoCRUD label="Motivos de Faltas" columns={["Código", "Motivo", "Justificada", "Descuenta", "Estado"]} />,
  "Equipo Lector": () => <MantenimientoCRUD label="Equipos Lectores (Biométricos)" columns={["Serie", "Marca", "IP", "Sede", "Estado"]} />,
  "Tipo Hora Extra": () => <MantenimientoCRUD label="Tipo Hora Extra" columns={["Código", "Tipo", "Factor", "Máximo", "Estado"]} />,
  "Ruteador": () => <MantenimientoCRUD label="Ruteadores de Rondas" columns={["Código", "Ruteador", "Zona", "Estado"]} />,
  "Rutas": () => <MantenimientoCRUD label="Rutas" columns={["Código", "Ruta", "Zona", "Nº puntos", "Estado"]} />,
  "Puntos Control": () => <MantenimientoCRUD label="Puntos de Control" columns={["Código", "Punto", "Dirección", "Ruta", "Estado"]} />,

  // === Logueo ===
  "Cerrar Sesión": () => <CerrarSesion />,
  "Cerrar Sesion": () => <CerrarSesion />,
  "Cambiar Contraseña": () => <CambiarContrasena />,
  "Cambiar Contrasena": () => <CambiarContrasena />,
  "Cambiar Empresa": () => <CambiarEmpresa />,

  // === Administración ===
  "Usuarios": () => <UsuariosAdmin />,
  "Perfiles": () => <Perfiles />,
  "Sesiones": () => <Sesiones />,
  "Atender Solicitud": () => <AtenderSolicitud />,
  "Indicadores": () => <EncuestaWin title="Indicadores de Encuesta" />,
  "Encuesta": () => <EncuestaWin title="Encuesta" />,
  "Resultado": () => <ReporteContainer label="Resultados de Encuesta" />,
  "Asignar Computadora": () => <ComputadoraAsignar />,
  "Computadora": () => <ComputadoraInv />,
  "Llamadas": () => <LlamadasWin />,
  "Equipos Marcación Personal": () => <ConfigTabla title="Equipos Marcación Personal" columns={["Serie", "IP", "Sede", "Modelo", "Estado"]} />,
  "Empresas": () => <ConfigTabla title="Empresas" columns={["RUC", "Razón Social", "Sucursal", "Régimen", "Estado"]} />,
  "Series Documentos": () => <ConfigTabla title="Series de Documentos" columns={["Tipo Doc.", "Serie", "Correlativo", "Sede", "Estado"]} />,
  "Locaciones": () => <ConfigTabla title="Locaciones / Sedes" columns={["Código", "Locación", "Dirección", "Ubigeo", "Estado"]} />,
  "Rubros de Productos": () => <ConfigTabla title="Rubros de Productos" columns={["Código", "Rubro", "Cuenta contable", "Estado"]} />,
  "Parámetros Locaciones": () => <ConfigTabla title="Parámetros de Locaciones" columns={["Locación", "Parámetro", "Valor", "Descripción"]} />,
  "Parametros Locaciones": () => <ConfigTabla title="Parámetros de Locaciones" columns={["Locación", "Parámetro", "Valor", "Descripción"]} />,
  "Parámetros Planilla Sueldos": () => <ConfigTabla title="Parámetros Planilla de Sueldos" columns={["Parámetro", "Valor", "Vigente desde", "Descripción"]} />,
  "Parametros Planilla Sueldos": () => <ConfigTabla title="Parámetros Planilla de Sueldos" columns={["Parámetro", "Valor", "Vigente desde", "Descripción"]} />,
  "Rubros x Empresa": () => <ConfigTabla title="Rubros por Empresa" columns={["Empresa", "Rubro", "Cuenta", "Estado"]} />,
  "Tablero": () => <IndicadoresVentaDialog />,

  // === Ayuda ===
  "Solicitud": () => <SolicitudSoporte />,
  "Información Cambios": () => <InfoCambios />,
  "Informacion Cambios": () => <InfoCambios />,
  "Acerca": () => <Acerca />,
  };

Object.assign(REGISTRY, {
  "Reporte Activos Fijos": () => <ReporteActivosFijosWindow />,
  "Indicadores": () => <IndicadoresEncuestaWindow />,
  "Resultado": () => <ResultadoEncuestaWindow />,
  "Empresas": () => <EmpresasWindow />,
  "Equipos Marcación Personal": () => <EquiposMarcacionPersonalWindow />,
  "Locaciones": () => <LocacionesWindow />,
  "Parámetros Locaciones": () => <ParametrosLocacionesWindow />,
  "Parametros Locaciones": () => <ParametrosLocacionesWindow />,
  "Parámetros Planilla Sueldos": () => <ParametrosPlanillaSueldosWindow />,
  "Parametros Planilla Sueldos": () => <ParametrosPlanillaSueldosWindow />,
  "Rubros de Productos": () => <RubrosDeProductosWindow />,
  "Rubros x Empresa": () => <RubrosXEmpresaWindow />,
  "Series Documentos": () => <SeriesDocumentosWindow />,
  "Documentos de Ventas": () => <ConsultaDocumentosVentaWindow />,
  "Documentos de Tránsito": () => <TransitoDocs />,
  "Documentos de Importación": () => <RibbonPlaceholder label="Documentos de Importación" />,
  "Modelos Telefonía": () => <TelefoniaInv title="Modelos" />,
  "Modelos Almacenes": () => <ModelosAlmacenesWindow />,
  "Cotizaciones Ventas": () => <Cotizaciones />,
  "Ordenes Compra Venta": () => <OrdenesCompra />,
  "Cotizacion Servicio": () => <RibbonPlaceholder label="Cotizacion" />,
  "Compras Motores": () => <RibbonPlaceholder label="Compras de Motores" />,
  "Cerrar Mes": () => <CerrarMesCostosWindow />,
  "Consolidado": () => <ConsolidadoCostosWindow />,
  "Generar Periodo": () => <GenerarPeriodoCostosWindow />,
  "Inv. Rotativo": () => <InventarioRotativoWindow />,
  "Recalcular": () => <RecalcularCostosWindow />,
  "Trasladar Costos": () => <TrasladarCostosWindow />,
  "Cierre Mes": () => <CierreMesContableWindow />,
  "Cuenta Destino": () => <CuentaDestinoWindow />,
  "Dif. Tipo Cambio": () => <DiferenciaTipoCambioWindow />,
  "Libro Diario": () => <LibroDiarioWindow />,
  "Feriados": () => <FeriadosWindow />,
  "Procesar Job": () => <ProcesarJobWindow />,
  "Vincular G/R": () => <VincularGRWindow />,
  "Asigna H. Extra": () => <AsignaHorasExtraWindow />,
  "Cronograma Mina": () => <CronogramaMinaWindow />,
  "Descuentos": () => <DescuentosWindow />,
  "Horarios": () => <HorariosWindow />,
  "Horas Extras": () => <HorasExtrasWindow />,
  "Ingresos": () => <IngresosWindow />,
  "Jefe Area": () => <JefeAreaWindow />,
  "Recursos": () => <RecursosWindow />,
  "Evaluaciones": () => <EvaluacionesWindow />,
  "Vacaciones": () => <VacacionesWindow />,
  "Rondas": () => <RondasWindow />,
  "Ruteador Rutas": () => <RuteadorRutasWindow />,
  "Equipos": () => <TelefoniaEquiposWindow />,
  "Planes": () => <TelefoniaPlanesWindow />,
  "Lineas": () => <TelefoniaLineasWindow />,
  "000 - Ventas": () => <GerenciaVentasWindow />,
  "010 - Importaciones": () => <GerenciaImportacionesWindow />,
  "020 - Inventario y Costos": () => <GerenciaInventarioCostosWindow />,
  "030 - Contabilidad": () => <GerenciaContabilidadWindow />,
  "040 - Creditos y Cobranzas": () => <GerenciaCreditosWindow />,
  "Contenedor Reportes": () => <ContenedorReportesWindow />,
  "Datos para Indicadores": () => <DatosParaIndicadoresWindow />,
  "Estados Financieros": () => <EstadosFinancierosWindow />,
  "Tarjeta": () => <TarjetaGerenciaWindow />,
  "Oportunidad Negocio": () => <OportunidadNegocioWindow />,
  "Ocurrencias": () => <OcurrenciasWindow />,
  "Cuota Vendedor": () => <CuotaVendedorWindow />,
  "Visita Clientes": () => <VisitaClientesWindow />,
  "Reclamo Cliente": () => <ReclamoClienteWindow />,
  "Categorias": () => <CategoriasWindow />,
  "Modelos": () => <ModelosAlmacenesWindow />,
  "Tipo Motores": () => <TipoMotoresWindow />,
  "Condición de Pago": () => <CondicionDePagoWindow />,
  "Condicion de Pago": () => <CondicionDePagoWindow />,
  "Proveedores": () => <ProveedoresWindow />,
  "Cuenta Contable": () => <CuentaContableWindow />,
  "Cuentas Destino": () => <CuentasDestinoTablaWindow />,
  "Marcas": () => <MarcasWindow />,
  "Partidas": () => <PartidasWindow />,
  "AFP": () => <AFPWindow />,
  "Cargos": () => <CargosWindow />,
  "Áreas": () => <AreasWindow />,
  "Areas": () => <AreasWindow />,
  "Motivos Faltas": () => <MotivosFaltasWindow />,
  "Equipo Lector": () => <EquipoLectorWindow />,
  "Rubro Planilla": () => <RubroPlanillaWindow />,
  "Rubro Planilla Ctas": () => <RubroPlanillaCtasWindow />,
  "Tipo Hora Extra": () => <TipoHoraExtraWindow />,
  "Rutas": () => <RutasWindow />,
  "Ruteador": () => <RuteadorWindow />,
  "Plantilla Repuestos": () => <PlantillaRepuestosWindow />,
  "Plantilla Repuestos Cliente": () => <PlantillaRepuestosClienteWindow />,
  "Ubicacion Servicio": () => <UbicacionServicioWindow />,
  "Vehiculos": () => <VehiculosWindow />,
  "Tarifa Gasto Viaje": () => <TarifaGastoViajeWindow />,
  "Tarifa Taxis Casa": () => <TarifaTaxisCasaWindow />,
  "Tarifas Taxi Destino": () => <TarifaTaxiDestinoWindow />,
});


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
