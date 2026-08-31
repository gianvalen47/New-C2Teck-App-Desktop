import { Children, createContext, isValidElement, useContext, useState, useRef, useEffect, useCallback, type ReactNode, type CSSProperties, type RefObject, type MouseEvent as ReactMouseEvent } from "react";
import { createPortal } from "react-dom";
import * as React from 'react';
import systeckIcon from "@/assets/Systeck.ico";
import logoC2 from "@/assets/Logos/LogoC2teck02.png";
import {
  X, Check, Save, Printer, Search, Plus, Trash2, FileDown, FileSpreadsheet,
  Mail, Send, RefreshCw, Filter, Calendar, DollarSign, User, Package,
  Wrench, Clock, Car, MapPin, Phone, Users, GraduationCap, Fingerprint, Play, Square,
  Minus, Maximize2, Minimize2, Copy, Zap, Receipt, LogOut, Settings, ArrowDown, ArrowRight, FileSearch, Percent, CreditCard, Pencil, BarChart3, TrendingUp, TrendingDown, Activity, Brain, Server, ShieldAlert, Sparkles
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
import c2teckWatermark from "@/assets/logos/LogoC2teck02.png";
import { toast } from "sonner";
import { ReporteContainerList } from "./windows/Reportes/ReporteContainer";
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

// Specific feature windows (moved to their own modules)
import { ConsultaPreciosDialogList } from "./windows/Precios/ConsultaPreciosDialog";

// Additional window components referenced in legacy monolith
import { NewGuideWindow } from "./NewGuideWindow";
import { GuiaRemisionList, GuiaRemisionForm } from "./windows/Ventas/Documentos/GuiasRemision";
import { GuiaDevolucionList } from "./windows/Ventas/Documentos/GuiasDevolucion";
import { ResumenDeBoletasList } from "./windows/Ventas/Documentos/ResumenDeBoletas";
import { CotizacionesList } from "./windows/Ventas/Pre y Post Venta/Cotizaciones";
import { ReclamoGarantiaList } from "./windows/Ventas/Pre y Post Venta/ReclamoGarantia";
import { SepararOrdenList } from "./windows/Ventas/Pre y Post Venta/SepararOrden";
import { OrdenesCompraList } from "./windows/Ventas/Pre y Post Venta/OrdenesCompra";
import { ActualizarVendedorList } from "./windows/Ventas/Pre y Post Venta/ActualizarVendedor";
import { EnviarCorreosList } from "./windows/Ventas/Pre y Post Venta/EnviarCorreos";
import { CarteraList } from "./windows/Ventas/Clientes/Cartera";
import { DespachoList } from "./windows/Ventas/Requisiciones/Despacho";
import { BoletaList } from "./windows/Ventas/Documentos/Boletas";
import { FacturaVentaList } from "./windows/Ventas/Documentos/Facturas";
import { NotaVentaList, NotaForm as NotaVentaForm } from "./windows/Ventas/Documentos/Notas";
import { ClientesList } from "./windows/Clientes";
import { UbicacionesList as UbicacionesWindow } from "./windows/Ubicaciones";
import { ProductosList } from "./windows/Productos";
import { RegistroComprasList } from "./windows/ComprasRegistro";
import { MovimientosAlmacenList, DocIngresosList, DocSalidasList2, TransferenciasList } from "./windows/MovimientosAlmacen";
import { SolicitudCompraList } from "./windows/SolicitudCompra";
import { OrdenCompraList } from "./windows/OrdenCompra";
import { CuentasPagarList } from "./windows/CuentasPagar";
import { SolicitudGastoList } from "./windows/SolicitudGasto";
import { PlanillaViaticosList } from "./windows/PlanillaViaticos";

import { DespachoList2 } from "./windows/Almacenes/Almacen/Despacho";
import { DocSalidasList } from "./windows/Almacenes/Almacen/DocSalidas";

import { VentaReporteDialogList } from "./windows/Reportes/VentaReporteDialog";
import { CostosReporteDialogList } from "./windows/Reportes/CostosReporteDialog";
import { ComprasReporteDialogList } from "./windows/Reportes/ComprasReporteDialog";
import { ContabilidadReporteDialogList } from "./windows/Reportes/ContabilidadReporteDialog";
import { AlmacenReporteDialogList } from "./windows/Reportes/AlmacenReporteDialog";
import { CreditosReporteDialogList } from "./windows/Reportes/CreditosReporteDialog";
import { ActMinMaxList } from "./windows/Almacenes/Mantenimiento/ActMinMax";
import { ReporteCostoVentaList } from "./windows/Reportes/ReporteCostoVenta";
import { AcercaList } from "./windows/Ayuda/Ayuda/Acerca";
import { OrdenTrabajoList } from "./windows/Servicios/Orden de Trabajo/OT";
import { MarcacionesList } from "./windows/Servicios/Orden de Trabajo/Marcaciones";
import { CambiarEmpresaList } from "./windows/Logueo/CambiarEmpresa";
import { LiquiGastosList } from "./windows/Almacenes/Mantenimiento/LiquiGastos";
import { PreciosManagerList } from "./windows/Precios/PreciosManager";
import { FactoresRubrosList } from "./windows/Precios/FactoresRubros";
import { RegistroVentaList } from "./windows/Ventas/Registro/RegistroVenta";
import { RegistroAuxiliarList } from "./windows/Ventas/Registro/RegistroAuxiliar";
import { ResumenRegistroList } from "./windows/Ventas/Registro/ResumenRegistro";
import { ReporteGuiasList } from "./windows/Reportes/ReporteGuias";
import { ReporteCotizacionesList } from "./windows/Ventas/Reportes/Cotizaciones";
import { ReporteValeRequisicionList } from "./windows/Ventas/Reportes/ValeRequisicion";
import { ReporteMensualClienteList } from "./windows/Ventas/Reportes/MensualesXCliente";
import { ReporteDetalleDescuentoList } from "./windows/Ventas/Reportes/DetalleDescuento";
import { ReporteReclamosList } from "./windows/Ventas/Reportes/Reclamos";
import { ReporteOrdenCompraList } from "./windows/Ventas/Reportes/OrdenesCompra";
import { ReporteConsignacionList } from "./windows/Ventas/Reportes/Consignaciones";
import { ReporteGuiasRemisionList } from "./windows/Ventas/Reportes/GuiasRemision";
import { ReporteGRPendienteList } from "./windows/Ventas/Reportes/GRPendiente";
import { ReportePresupuestoVentaList } from "./windows/Ventas/Reportes/PresupuestoVenta";
import { ReporteComisionesList } from "./windows/Ventas/Reportes/Comisiones";
import { ReportePagosCuentasXPagarList } from "./windows/Compras/Reportes/PagoCuentasXPagar";
import { ReporteSolicitudGastosList } from "./windows/Compras/Reportes/SolicitudGastos";
import { ReporteCtasXPagarUnidadList } from "./windows/Compras/Reportes/CuentasXPagarPorUnidad";
import { CtasXCobrarList } from "./windows/Creditos/Consultas/CtasXCobrar";
import { AnticiposList } from "./windows/Creditos/Documentos/Anticipos";
import { PlanillasList } from "./windows/Creditos/Documentos/Planillas";
import { LetrasList } from "./windows/Creditos/Documentos/Letras";
import { AprobacionCreditosList } from "./windows/Creditos/Aprobaciones/Creditos";
import { PermisoUsuarioCreditosList } from "./windows/Creditos/Aprobaciones/PermisoUsuario";
import { CotizTallerCreditoList } from "./windows/Creditos/Aprobaciones/CotizTaller";
import { RecepcionDocCreditosList } from "./windows/Creditos/Aprobaciones/RecepcionDoc";
import { SaldoBancosCreditosList } from "./windows/Creditos/Mantenimiento/SaldoBancos";
import { TipoCambioList } from "./windows/Creditos/Mantenimiento/RenuevaTipoCambio";
import { ChequeoFIList } from "./windows/Almacenes/Almacen/ChequeoFI";
import { AtenderOTList } from "./windows/Almacenes/Almacen/AtenderOT";
import { UbicacionesList } from "./windows/Almacenes/Mantenimiento/Ubicaciones";
import { TransitoDocsList } from "./windows/Almacenes/Transito/Documentos";
import { MemosTransferenciasInternasList } from "./windows/Almacenes/Motores/Transferencias";
import { ValorizarFIList } from "./windows/Contabilidad/Costos/Importaciones/ValorizarFI";
import { AsientosList } from "./windows/Contabilidad/Tesoreria/Asientos";
import { MovimientoBancosList } from "./windows/Contabilidad/Tesoreria/MovimientoBancos";
import { RegistroCompraList } from "./windows/Contabilidad/Compras/RegistroCompra";
import { CajaChicaList } from "./windows/Contabilidad/Caja Chica/ArqueoCaja";
import { GenerarTXTList } from "./windows/Contabilidad/Procesos/GenerarTXTLibros";
import { FlujoCajaList } from "./windows/Contabilidad/Procesos/FlujoDeCaja";
import { CotizacionesCompraList } from "./windows/Compras/Compras/Cotizaciones";
import { ViaticosList } from "./windows/Compras/Control/PlanillaViatico";
import { CtasXPagarList } from "./windows/Compras/Control/CuentasXPagar";
import { GarantiaWinList } from "./windows/Servicios/Garantia/OrdenReparacion";
import { KilometrajeList } from "./windows/Servicios/Control Vehicular/Kilometraje";
import { OficinaUsuarioList } from "./windows/Servicios/Mantenimiento/OficinaUsuario";
import { PuntosControlList } from "./windows/Rondas/Asignacion/PuntosControlRutas";
import { TelefoniaInvList } from "./windows/Telefonia/Mantenimiento/Modelos";
import { PersonalTiempoList } from "./windows/Personal/Asignaciones/Faltas";
import { MarcacionOnlineList } from "./windows/Personal/Asignaciones/MarcacionOnline";
import { FichaGeneralList } from "./windows/Personal/Informacion/FichaGeneral";
import { CapacitacionesWinList } from "./windows/Personal/Informacion/Capacitaciones";
import { PlanillaSueldosList } from "./windows/Personal/Planilla Sueldos/QuintaCategoria";
import { ProcesarMarcasList } from "./windows/Personal/Comunicaciones/ProcesarMarcas";
import { EncuestaWinList } from "./windows/Administracion/Encuestas/Encuesta";
import { ValesList } from "./windows/Almacenes/Almacen/Vales";
import { TarjetasList } from "./windows/Almacenes/Consultas/Tarjetas";
import { CalendarioList } from "./windows/Almacenes/Indicadores/Calendario";
import { ProcesarCoberturaList } from "./windows/Almacenes/Indicadores/ProcesarCobertura";
import { PrecioClienteList } from "./windows/Precios/PrecioCliente";
import { PrecioOfertaList } from "./windows/Precios/PrecioOferta";
import { PrecioListaList } from "./windows/Precios/PrecioLista";
import { PrecioFabricantesList } from "./windows/Precios/PrecioFabricantes";
import { ReporteAcumuladaList } from "./windows/Ventas/Reportes/Acumulada";
import { OrdenImportacionList } from "./windows/Importaciones/Pedidos/OrdenImportacion";
import { ActivosFijosList } from "./windows/Activos/Activos/ActivosFijos";
import { PedirRepuestosList } from "./windows/Servicios/Almacen/PedirRepuestos";
import { AsignaPersonaList } from "./windows/Telefonia/Asignacion/AsignaPersona";
import { CerrarSesionList } from "./windows/Logueo/CerrarSesion";
import { CambiarContrasenaList } from "./windows/Logueo/CambiarContrasena";
import { UsuariosAdminList } from "./windows/Administracion/Seguridad/Usuarios";
import { PerfilesList } from "./windows/Administracion/Seguridad/Perfiles";
import { SesionesList } from "./windows/Administracion/Seguridad/Sesiones";
import { AtenderSolicitudList } from "./windows/Administracion/Usuarios/AtenderSolicitud";
import { ComputadoraAsignarList } from "./windows/Administracion/Inventario/AsignarComputadora";
import { ComputadoraInvList } from "./windows/Administracion/Inventario/Computadora";
import { LlamadasWinList } from "./windows/Administracion/Llamadas/Llamadas";
import { SolicitudSoporteList } from "./windows/Ayuda/Usuario/Solicitud";
import { ServicioReporteDialogList } from "./windows/Reportes/ServicioReporteDialog";
import { PersonalReporteDialogList } from "./windows/Reportes/PersonalReporteDialog";
import { GerenciaReporteDialogList } from "./windows/Reportes/GerenciaReporteDialog";
import { CrmReporteDialogList } from "./windows/Reportes/CrmReporteDialog";
import { FsLegacyList } from "./windows/shared/LegacySupport";
import { RadioLegacyList } from "./windows/shared/LegacySupport";
import { DialogFooterList } from "./windows/shared/LegacySupport";
import { IndicadoresVentaDialogList } from "./windows/Almacenes/Indicadores/Tablero";
import { LabRowList } from "./windows/shared/LegacySupport";
import { ProcesoLoteList } from "./windows/shared/LegacySupport";
import { MantenimientoCRUDList } from "./windows/shared/LegacySupport";
import { ConfigTablaList } from "./windows/shared/LegacySupport";


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
addAliases("Reporte Venta Detallado", ["Venta Detallada", "Rpt Venta Detallado"], VentaReporteDialogList);
add("Reporte Costos", CostosReporteDialog);
add("Reporte Compras", ComprasReporteDialog);
add("Reporte Contabilidad", ContabilidadReporteDialog);
add("Reporte Almacen", AlmacenReporteDialog);
add("Reporte Creditos", CreditosReporteDialog);
add("Reporte Guias", ReporteGuiasList);
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

export function hasWindowForLabel(label: string): boolean {
  return !!registry[normalizeWindowLabel(label)];
}

export function registerWindow(label: string, comp: WindowComponent) {
  add(label, comp);
}


// ---------- Ventas: Documentos ----------
function GuiaRemision() {
  return <GuiaRemisionList />;
}

function NuevaGuia() {
  return <GuiaRemisionForm onClose={() => {}} />;
}

function Factura() {
  return <FacturaVentaList />;
}

function NuevaNota() {
  return <NotaVentaForm onClose={() => {}} onSaved={() => {}} />;
}

function Notas() {
  return <NotaVentaList />;
}

function GuiaDevolucion() {
  return (
    <GuiaDevolucionList />
  );
}

function Boleta() {
  return (
    <BoletaList />
  );
}

function ResumenBoletas() {
  return (
    <ResumenDeBoletasList />
  );
}

// ---------- Ventas: Pre y Post ----------
function Cotizaciones() {
  return (
    <CotizacionesList />
  );
}

function ReclamoGarantia() {
  return (
    <ReclamoGarantiaList />
  );
}

function SepararOrden() {
  return (
    <SepararOrdenList />
  );
}

function OrdenesCompra() {
  return (
    <OrdenesCompraList />
  );
}

function ActualizarVendedor() {
  return (
    <ActualizarVendedorList />
  );
}

function EnviarCorreos() {
  return (
    <EnviarCorreosList />
  );
}

// ---------- Clientes / Requisiciones ----------
function Cartera() {
  return (
    <CarteraList />
  );
}

function Despacho() {
  return (
    <DespachoList />
  );
}

function DocSalidas() {
  return (
    <DocSalidasList />
  );
}

function Vales() {
  return (
    <ValesList />
  );
}

function Tarjetas() {
  return (
    <TarjetasList />
  );
}

function Calendario() {
  return (
    <CalendarioList />
  );
}

function ProcesarCobertura() {
  return (
    <ProcesarCoberturaList />
  );
}

function LiquiGastos() {
  return <LiquiGastosList />;
}

// ---------- Precios ----------
function PreciosManager({ initial }: { initial: string }) {
  return (
    <PreciosManagerList initial={initial} />
  );
}

// ---------- Ventanas de Precios (ListingBrowser basados en stdToolbar) ----------
function PrecioCliente() {
  return (
    <PrecioClienteList />
  );
}

function PrecioOferta() {
  return (
    <PrecioOfertaList />
  );
}

function FactoresRubros() {
  return <FactoresRubrosList />;
}

function PrecioLista() {
  return (
    <PrecioListaList />
  );
}

function PrecioFabricantes() {
  return (
    <PrecioFabricantesList />
  );
}

// ---------- Registro de Ventas (3 ventanas) ----------
function RegistroVenta() {
  return <RegistroVentaList />;
}

function RegistroAuxiliar() {
  return <RegistroAuxiliarList />;
}

function ResumenRegistro() {
  return <ResumenRegistroList />;
}


// ---------- Reportes del Menú Reportes ----------
function ReporteAcumulada() {
  return (
    <ReporteAcumuladaList />
  );
}

function ReporteGuias() {
  return <ReporteGuiasList />;
}

function ReporteCotizaciones() {
  return <ReporteCotizacionesList />;
}

function ReporteValeRequisicion() {
  return <ReporteValeRequisicionList />;
}

function ReporteMensualCliente() {
  return <ReporteMensualClienteList />;
}

function ReporteDetalleDescuento() {
  return <ReporteDetalleDescuentoList />;
}

function ReporteReclamos() {
  return <ReporteReclamosList />;
}

function ReporteOrdenCompra() {
  return <ReporteOrdenCompraList />;
}

function ReporteConsignacion() {
  return <ReporteConsignacionList />;
}

function ReporteGuiasRemision() {
  return <ReporteGuiasRemisionList />;
}

function ReporteGRPendiente() {
  return <ReporteGRPendienteList />;
}

function ReportePresupuestoVenta() {
  return <ReportePresupuestoVentaList />;
}

function ReporteComisiones() {
  return <ReporteComisionesList />;
}

function ReporteCostoVenta() {
  return (
    <ReporteCostoVentaList />
  );
}

function ReportePagosCuentasXPagar() {
  return <ReportePagosCuentasXPagarList />;
}

function ReporteSolicitudGastos() {
  return <ReporteSolicitudGastosList />;
}

function ReporteCtasXPagarUnidad() {
  return <ReporteCtasXPagarUnidadList />;
}

function ServicioReporteDialog({ label }: { label: string }) {
  return (
    <ServicioReporteDialogList label={label} />
  );
}

function PersonalReporteDialog({ label }: { label: string }) {
  return (
    <PersonalReporteDialogList label={label} />
  );
}

function GerenciaReporteDialog({ label }: { label: string }) {
  return (
    <GerenciaReporteDialogList label={label} />
  );
}

function CrmReporteDialog({ label }: { label: string }) {
  return (
    <CrmReporteDialogList label={label} />
  );
}

function CreditosReporteDialog({ label }: { label: string }) {
  return (
    <CreditosReporteDialogList label={label} />
  );
}

function AlmacenReporteDialog({ label }: { label: string }) {
  return (
    <AlmacenReporteDialogList label={label} />
  );
}

function CostosReporteDialog({ label }: { label: string }) {
  return (
    <CostosReporteDialogList label={label} />
  );
}

function ContabilidadReporteDialog({ label }: { label: string }) {
  return (
    <ContabilidadReporteDialogList label={label} />
  );
}

function ComprasReporteDialog({ label }: { label: string }) {
  return (
    <ComprasReporteDialogList label={label} />
  );
}

// ---------- Contenedor de reportes personalizados ----------
function FsLegacy({ legend, children }: { legend: string; children: React.ReactNode }) {
  return (
    <FsLegacyList  legend={legend} children={children}  />
  );
}

function RadioLegacy({ name, label, defaultChecked }: { name: string; label: string; defaultChecked?: boolean }) {
  return (
    <RadioLegacyList name={name} label={label} defaultChecked={defaultChecked} />
  );
}

function DialogFooter({ onOk, onCancel }: { onOk: () => void; onCancel: () => void }) {
  return (
    <DialogFooterList onOk={onOk} onCancel={onCancel} />
  );
}

function VentaReporteDialog({ label }: { label: string }) {
    return (
      <VentaReporteDialogList label={label} />
  );
}

function IndicadoresVentaDialog() {
  return (
    <IndicadoresVentaDialogList />
  );
}

// ---------- Contenedor de Reportes ----------
function ReporteContainer({ label }: { label: string }) {
  return (
    <ReporteContainerList label={label} />
  );
}

function LabRow({ label, children }: { label: string; children: React.ReactNode }) {
  return (
    <div className="flex items-center justify-between gap-2">
      <span className="font-semibold text-slate-700">{label}</span>
      <div className="flex items-center">{children}</div>
    </div>
  );
}

// ---------- Placeholder genérico ----------
function ConsultaPreciosDialog() {
  return (
    <ConsultaPreciosDialogList />
  );
}

// ============================================================
// MACRO 1 · CRÉDITOS
// ============================================================
function CtasXCobrar() {
  return <CtasXCobrarList />;
}

function Anticipos() {
  return <AnticiposList />;
}

function Planillas() {
  return <PlanillasList />;
}

function Letras() {
  return <LetrasList />;
}

function AprobacionCreditos() {
  return <AprobacionCreditosList />;
}

function PermisoUsuarioCreditos() {
  return <PermisoUsuarioCreditosList />;
}

function CotizTallerCredito() {
  return <CotizTallerCreditoList />;
}

function RecepcionDocCreditos() {
  return <RecepcionDocCreditosList />;
}

function SaldoBancosCreditos() {
  return <SaldoBancosCreditosList />;
}

function TipoCambio() {
  return <TipoCambioList />;
}

// ============================================================
// MACRO 2 · ALMACENES
// ============================================================
function DocIngresos() {
  return <DocIngresosList />;
}

function ChequeoFI() {
  return <ChequeoFIList />;
}

function AtenderOT() {
  return <AtenderOTList />;
}

function Productos() {
  return <ProductosList />;
}

function ActMinMax() {
  return (
    <ActMinMaxList />
  );
}

function Ubicaciones() {
  return <UbicacionesList />;
}

function TransitoDocs() {
  return <TransitoDocsList />;
}

function MemosTransferenciasInternas() {
  return <MemosTransferenciasInternasList />;
}

// ============================================================
// MACRO 2 · IMPORTACIONES
// ============================================================
function OrdenImportacion() {
  return (
    <OrdenImportacionList />
  );
}

// ============================================================
// MACRO 2 · ACTIVOS
// ============================================================
function ActivosFijos() {
  return (
    <ActivosFijosList />
  );
}

// ============================================================
// MACRO 3 · COSTOS
// ============================================================
function ValorizarFI() {
  return <ValorizarFIList />;
}

function ProcesoLote({ label, subtitle }: { label: string; subtitle: string }) {
  return (
    <ProcesoLoteList label={label} subtitle={subtitle} />
  );
}

// ============================================================
// MACRO 3 · CONTABILIDAD
// ============================================================
type JournalLineForm = {
  id: string;
  account: string;
  description: string;
  reference: string;
  debit: number;
  credit: number;
  cost_center: string;
};

function Asientos() {
  return <AsientosList />;
}

function MovimientoBancos() {
  return <MovimientoBancosList />;
}

function RegistroCompra() {
  return <RegistroCompraList />;
}

function CajaChica() {
  return <CajaChicaList />;
}

function GenerarTXT() {
  return <GenerarTXTList />;
}

function FlujoCaja() {
  return <FlujoCajaList />;
}

// ============================================================
// MACRO 3 · COMPRAS
// ============================================================
function SolicitudCompra() {
  return <SolicitudCompraList />;
}

function CotizacionesCompra() {
  return <CotizacionesCompraList />;
}

function SolicitudGasto() {
  return <SolicitudGastoList />;
}

function OrdenCompra() {
  return <OrdenCompraList />;
}

function Viaticos() {
  return <ViaticosList />;
}

function CtasXPagar() {
  return <CtasXPagarList />;
}

// ============= SERVICIOS / TALLERES =============
function OrdenTrabajo() {
  return (
    <OrdenTrabajoList />
  );
}

function Marcaciones({ title = "Marcación de Tareas OT" }: { title?: string }) {
  return (
    <MarcacionesList title={title} />
  );
}

function PedirRepuestos() {
  return (
    <PedirRepuestosList />
  );
}

function GarantiaWin({ title }: { title: string }) {
  return (
    <GarantiaWinList title={title} />
  );
}

function Kilometraje() {
  return <KilometrajeList />;
}

function OficinaUsuario() {
  return <OficinaUsuarioList />;
}

// ============= RONDAS =============
function PuntosControl({ title }: { title: string }) {
  return (
    <PuntosControlList title={title} />
  );
}

// ============= TELEFONÍA =============
function TelefoniaInv({ title }: { title: string }) {
  return (
    <TelefoniaInvList title={title} />
  );
}

function AsignaPersona() {
  return (
    <AsignaPersonaList />
  );
}

// ============= PERSONAL / PLANILLAS =============
function PersonalTiempo({ title }: { title: string }) {
  return <PersonalTiempoList title={title} />;
}

function MarcacionOnline() {
  return <MarcacionOnlineList />;
}

function FichaGeneral() {
  return <FichaGeneralList />;
}

function CapacitacionesWin({ title }: { title: string }) {
  return <CapacitacionesWinList title={title} />;
}

function PlanillaSueldos() {
  return <PlanillaSueldosList />;
}

function ProcesarMarcas() {
  return <ProcesoLote label="Procesar Marcas" subtitle="Consolida marcaciones biométricas y calcula asistencia, tardanzas y horas trabajadas del periodo." />;
}

// ============= MACRO 6 · TABLAS MAESTRAS (CRUD) =============
function MantenimientoCRUD({ label, columns }: { label: string; columns: string[] }) {
  return (
    <MantenimientoCRUDList label={label} columns={columns} />
  );
}

// ============= MACRO 6 · LOGUEO =============
function CerrarSesion() {
  return (
    <CerrarSesionList />
  );
}

function CambiarContrasena() {
  return (
    <CambiarContrasenaList />
  );
}

function CambiarEmpresa() {
  return (
    <CambiarEmpresaList />
  );
}

// ============= MACRO 6 · ADMINISTRACIÓN =============
function UsuariosAdmin() {
  return (
    <UsuariosAdminList />
  );
}

function Perfiles() {
  return (
    <PerfilesList />
  );
}

function Sesiones() {
  return (
    <SesionesList />
  );
}

function AtenderSolicitud() {
  return (
    <AtenderSolicitudList />
  );
}

function EncuestaWin({ title }: { title: string }) {
  return (
    <EncuestaWinList title={title} />
  );
}

function ComputadoraAsignar() {
  return (
    <ComputadoraAsignarList />
  );
}

function ComputadoraInv() {
  return (
    <ComputadoraInvList />
  );
}

function LlamadasWin() {
  return (
    <LlamadasWinList />
  );
}

function ConfigTabla({ title, columns }: { title: string; columns: string[] }) {
  return (
    <ConfigTablaList title={title} columns={columns} />
  );
}

// ============= MACRO 6 · AYUDA =============
function SolicitudSoporte() {
  return (
    <SolicitudSoporteList />
  );
}

function Acerca() {
  return (
    <AcercaList />
  );
}

function InfoCambios() {
  return (
    <WindowShell title="Información de Cambios — Changelog">
      <DataTable columns={["Versión", "Fecha", "Módulo", "Tipo", "Descripción"]} rows={10} />
    </WindowShell>
  );
}

// ---------- Registry ----------
const REGISTRY: Record<string, (label: string) => ReactNode> = {
  // Ventas > Documentos
  "Guía Remisión": () => <GuiaRemision />,
  "Guías Remisión": () => <GuiaRemision />,
  "Guia Remision": () => <GuiaRemision />,
  "Nueva Guía": () => <NuevaGuia />,
  "Factura": () => <Factura />,
  "Notas": () => <Notas />,
  "Nueva Nota": () => <NuevaNota />,
  "Guía Devolución": () => <GuiaDevolucion />,
  "Boleta": () => <Boleta />,
  "Resumen de Boletas": () => <ResumenBoletas />,
  // Pre y Post
  "Cotizaciones": () => <ReporteCotizaciones />,
  "Cotizacion": () => <ReporteCotizaciones />,
  "Reclamo Garantía": () => <ReclamoGarantia />,
  "Separar Orden": () => <SepararOrden />,
  "Ordenes Compra": () => <ReporteOrdenCompra />,
  "Órdenes Compra": () => <ReporteOrdenCompra />,
  "Actualizar Vendedor": () => <ActualizarVendedor />,
  "Enviar Correos": () => <EnviarCorreos />,
  "Pre y Post Venta": () => <ReporteCotizaciones />,
  // Clientes / Requisiciones
  "Cartera": () => <Cartera />,
  "Despacho": () => <Despacho />,
  "Requisiciones": () => <Despacho />,
  // Precios
  "Precios Cliente": () => <PrecioCliente />,
  "Precio Oferta": () => <PrecioOferta />,
  "Factores Rubros": () => <FactoresRubros />,
  "Precio Lista": () => <PrecioLista />,
  "Precio Fabricantes": () => <PrecioFabricantes />,
  "Precios": () => <PreciosManager initial="Precio Lista" />,

  // Registro de Venta windows
  "Registro": () => <RegistroVenta />,
  "Registro Auxiliar": () => <RegistroAuxiliar />,
  "Resumen Registro": () => <ResumenRegistro />,

  // === CRÉDITOS ===
  "Ctas x Cobrar": () => <CtasXCobrar />,
  "Cuentas x Cobrar": () => <CtasXCobrar />,
  "Ctas. x Cobrar": () => <CtasXCobrar />,
  "Anticipos": () => <Anticipos />,
  "Planillas": () => <Planillas />,
  "Letras": () => <Letras />,
  "Créditos": () => <AprobacionCreditos />,
  "Creditos": () => <AprobacionCreditos />,
  "Permiso Usuario": () => <PermisoUsuarioCreditos />,
  "Cotiz. Taller": () => <CotizTallerCredito />,
  "Recepcion Doc.": () => <RecepcionDocCreditos />,
  "Recepción Doc.": () => <RecepcionDocCreditos />,
  "Saldo Bancos": () => <SaldoBancosCreditos />,
  "Tipo Cambio Ventas": () => <TipoCambio />,
  "Mantenimiento Tipo de Cambio": () => <TipoCambio />,
  "Renueva Tipo Cambio": () => <TipoCambio />,
  "Factores y Descuentos": () => <FactoresRubros />,
  "Procesar Job": () => <ProcesoLote label="Procesar Job" subtitle="Procesa y vincula documentos pendientes asociados a créditos." />,
  "Vincular G/R": () => <ProcesoLote label="Vincular G/R" subtitle="Relaciona guías de remisión con documentos comerciales y de cobranza." />,
  "Visita Cobrador": () => <CreditosReporteDialog label="Visita Cobrador" />,
  "Visitas Cobrador": () => <CreditosReporteDialog label="Visitas Cobrador" />,
  "Detalle Vencimientos": () => <CreditosReporteDialog label="Detalle Vencimientos" />,
  "Acumulado Vencimientos": () => <CreditosReporteDialog label="Acumulado Vencimientos" />,
  "Notas Debito/Credito": () => <CreditosReporteDialog label="Notas Debito/Credito" />,
  "Consultas": () => <LookupDialog title="Consultas" columns={["Código", "Descripción", "Estado", "Referencia"]} rows={10} />,

  // === ALMACENES ===
  "Doc. Ingresos": () => <DocIngresosList />,
  "Doc.Ingresos": () => <DocIngresos />,
  "Doc.Salidas": () => <DocSalidasList />,
  "Chequeo F/I": () => <ChequeoFI />,
  "MTI": () => <TransitoDocs />,
  "M T I": () => <TransitoDocs />,
  "Atender OT": () => <AtenderOT />,
  "Datos Despacho Clientes": () => <Despacho />,
  "Doc. Salidas": () => <DocSalidas />,
  "T / I": () => <TransitoDocs />,
  "T/I": () => <TransitoDocs />,
  "Vales / Despachos": () => <AtenderOT />,
  "Vales": () => <Vales />,
  "Despachos": () => <Despacho />,
  "Productos": () => <ProductosList />,
  "Liqui. Gastos": () => <LiquiGastos />,
  "Act. Min Max": () => <ActMinMax />,
  "Ubicaciones": () => <UbicacionesWindow />,
  "Tarjetas": () => <Tarjetas />,
  "Calendario": () => <Calendario />,
  "Procesar Cobertura": () => <ProcesarCobertura />,
  "Transferencias": () => <TransferenciasList />,
  "Compras": () => <TransitoDocs />,
  "Documentos": () => <TransitoDocs />,
  "Anulación en Consulta": () => <TransitoDocs />,

  // === IMPORTACIONES ===
  "Orden Importación": () => <OrdenImportacion />,
  "Orden de Importación": () => <OrdenImportacion />,
  "Embarque": () => <OrdenImportacion />,
  "Internos": () => <OrdenImportacion />,
  "Pedido Interno": () => <OrdenImportacion />,
  "Embarques de Importación": () => <OrdenImportacion />,
  "Importaciones": () => <CostosReporteDialog label="Importaciones" />,

  // === ACTIVOS ===
  "Activos Fijos": () => <ActivosFijos />,
  "Reporte Activos Fijos": () => <ReporteContainer label="Reporte Activos Fijos" />,

  // === COSTOS ===
  "Valorizar F/I": () => <ValorizarFI />,
  "Ajustar Costos": () => <ValorizarFI />,
  "Recalcular": () => <ProcesoLote label="Recalcular Costos" subtitle="Recalcula el costo promedio ponderado de todos los productos del periodo seleccionado." />,
  "Cerrar Mes": () => <ProcesoLote label="Cerrar Mes" subtitle="Congela el mes comercial: bloquea documentos y libera datos para auditoría." />,
  "Trasladar Costos": () => <ProcesoLote label="Trasladar Costos" subtitle="Transfiere costos calculados hacia contabilidad y kardex valorizado." />,
  "Inv. Rotativo": () => <ProcesoLote label="Inventario Rotativo" subtitle="Genera muestras de conteo rotativo por categoría / ubicación." />,
  "Consolidado": () => <ProcesoLote label="Consolidado" subtitle="Consolida movimientos y saldos de todos los almacenes." />,
  "Generar Periodo": () => <ProcesoLote label="Generar Periodo" subtitle="Crea el nuevo periodo contable / comercial." />,

  // === CONTABILIDAD ===
  "Asientos": () => <Asientos />,
  "Movimiento Bancos": () => <MovimientoBancos />,
  "Registro Compra": () => <RegistroComprasList />,
  "Recibo Honorario": () => <RegistroComprasList />,
  "Diario": () => <ReporteContainer label="Libro Diario" />,
  "Provisional": () => <CajaChica />,
  "Reembolso": () => <CajaChica />,
  "Arqueo Caja": () => <CajaChica />,
  "Cierre Mes": () => <ProcesoLote label="Cierre Mes" subtitle="Cierre contable mensual con validación de saldos cuadrados." />,
  "Cuenta Destino": () => <ProcesoLote label="Cuenta Destino" subtitle="Reasigna asientos entre cuentas contables destino." />,
  "Dif. Tipo Cambio": () => <ProcesoLote label="Diferencia de Tipo de Cambio" subtitle="Calcula pérdidas / ganancias por diferencia en tipo de cambio del periodo." />,
  "Flujo de Caja": () => <FlujoCaja />,
  "Generar TXT Libros": () => <GenerarTXT />,
  "Libro Diario": () => <ContabilidadReporteDialog label="Libro Diario" />,
  "Libro Mayor": () => <ContabilidadReporteDialog label="Libro Mayor" />,
  "Caja y Bancos": () => <ContabilidadReporteDialog label="Caja y Bancos" />,
  "Registro de Compras": () => <ContabilidadReporteDialog label="Registro de Compras" />,

  // === COMPRAS ===
  "Solicitud de Compra": () => <SolicitudCompraList />,
  "Solicitud Compra": () => <SolicitudCompraList />,
  "Orden de Compra": () => <OrdenCompraList />,
  "Orden Compra": () => <OrdenCompraList />,
  "Solicitud Gasto": () => <SolicitudGastoList />,
  "Planilla Viático": () => <PlanillaViaticosList />,
  "Planilla Viáticos": () => <PlanillaViaticosList />,
  "Planilla Viatico": () => <PlanillaViaticosList />,
  "Tarifas": () => <PreciosManager initial="Precio Lista" />,
  "Tarifa Gasto Viaje": () => <MantenimientoCRUD label="Tarifa Gasto Viaje" columns={["Ruta", "Categoría", "Moneda", "Tarifa", "Estado"]} />,
  "Tarifa Taxis Casa": () => <MantenimientoCRUD label="Tarifa Taxis Casa" columns={["Zona", "Horario", "Moneda", "Tarifa", "Estado"]} />,
  "Tarifas Taxi Destino": () => <MantenimientoCRUD label="Tarifas Taxi Destino" columns={["Destino", "Tipo", "Moneda", "Tarifa", "Estado"]} />,
  "Cuentas x Pagar": () => <CuentasPagarList />,
  "Ctas x Pagar": () => <CuentasPagarList />,
  "Compras y/o Gastos": () => <RegistroComprasList />,
  "Pagos Cuentas x Pagar": () => <ReportePagosCuentasXPagar />,
  "Solicitud Gastos": () => <SolicitudGastoList />,
  "Cuentas x Pagar Por Unidad": () => <ReporteCtasXPagarUnidad />,

  // === SERVICIOS / TALLERES ===
  "Pedir Repuestos": () => <PedirRepuestos />,
  "Solicitud OT": () => <OrdenTrabajo />,
  "OT": () => <OrdenTrabajo />,
  "Orden de Trabajo": () => <OrdenTrabajo />,
  "Marcaciones": () => <Marcaciones title="Marcaciones — OT" />,
  "Pre Marcacion": () => <Marcaciones title="Pre Marcación — OT" />,
  "Pre Marcación": () => <Marcaciones title="Pre Marcación — OT" />,
  "Marcar OT": () => <Marcaciones title="Marcar OT" />,
  "Gastos Reales": () => <OrdenTrabajo />,
  "Orden Reparación": () => <GarantiaWin title="Orden de Reparación" />,
  "Reclamo Cliente": () => <GarantiaWin title="Reclamo Cliente" />,
  "Garantía": () => <GarantiaWin title="Garantía" />,
  "Garantia": () => <GarantiaWin title="Garantía" />,
  "Control Vehicular": () => <Kilometraje />,
  "Mantenimiento": () => <OficinaUsuario />,
  "Kilometraje": () => <Kilometraje />,
  "Oficina Usuario": () => <OficinaUsuario />,

  "Gastos Detallado": () => <ServicioReporteDialog label="Gastos Detallado" />,
  "Gastos Detalle": () => <ServicioReporteDialog label="Gastos Detalle" />,
  "Liquidación x Garantia": () => <ServicioReporteDialog label="Liquidación x Garantia" />,
  "LiquidaciÃ³n x Garantia": () => <ServicioReporteDialog label="LiquidaciÃ³n x Garantia" />,

  // === RONDAS ===
  "Puntos Control Rutas": () => <PuntosControl title="Puntos de Control" />,
  "Rondas": () => <PuntosControl title="Rondas" />,
  "Ruteador Rutas": () => <PuntosControl title="Ruteador de Rutas" />,

  // === TELEFONÍA ===
  "Modelos": () => <TelefoniaInv title="Modelos" />,
  "Planes": () => <TelefoniaInv title="Planes" />,
  "Líneas": () => <TelefoniaInv title="Líneas" />,
  "Lineas": () => <TelefoniaInv title="Líneas" />,
  "Equipos": () => <TelefoniaInv title="Equipos" />,
  "Asigna Persona": () => <AsignaPersona />,

  // === PERSONAL / PLANILLAS ===
  "Faltas": () => <PersonalTiempo title="Faltas" />,
  "Asigna H. Extra": () => <PersonalTiempo title="Asignación H. Extra" />,
  "Asig. H. Extra": () => <PersonalTiempo title="Asignación H. Extra" />,
  "Horas Extras": () => <PersonalTiempo title="Horas Extras" />,
  "Descuentos": () => <PersonalTiempo title="Descuentos" />,
  "Recursos": () => <PersonalTiempo title="Recursos" />,
  "Marcación Online": () => <MarcacionOnline />,
  "Marcacion Online": () => <MarcacionOnline />,
  "Marcación": () => <MarcacionOnline />,
  "Marcacion": () => <MarcacionOnline />,
  "Horarios": () => <PersonalTiempo title="Horarios / Turnos" />,
  "Ingresos": () => <PersonalTiempo title="Ingresos" />,
  "Jefe Área": () => <PersonalTiempo title="Jefe de Área" />,
  "Jefe Area": () => <PersonalTiempo title="Jefe de Área" />,
  "Cronograma Mina": () => <PersonalTiempo title="Cronograma Mina" />,
  "Informacion": () => <FichaGeneral />,
  "Personal": () => <PersonalReporteDialog label="Personal" />,
  "Ficha General": () => <FichaGeneral />,
  "Capacitaciones": () => <CapacitacionesWin title="Capacitaciones" />,
  "Vacaciones": () => <CapacitacionesWin title="Vacaciones" />,
  "Evaluaciones": () => <CapacitacionesWin title="Evaluaciones de Desempeño" />,
  "Quinta Categoría": () => <PlanillaSueldos />,
  "Quinta Categoria": () => <PlanillaSueldos />,
  "Planilla Sueldos": () => <PlanillaSueldos />,
  "Admin. Lector": () => <MarcacionOnline />,
  "Procesar Marcas": () => <ProcesarMarcas />,
  "Comunicaciones": () => <EnviarCorreos />,

  // === MACRO 6 · TABLAS MAESTRAS (CRUD) ===
  "Clientes": () => <ClientesList />,
  "Modelos ": () => <MantenimientoCRUD label="Modelos" columns={["Código", "Modelo", "Marca", "Estado"]} />,
  "Categorías": () => <MantenimientoCRUD label="Categorías" columns={["Código", "Categoría", "Rubro", "Estado"]} />,
  "Categorias": () => <MantenimientoCRUD label="Categorías" columns={["Código", "Categoría", "Rubro", "Estado"]} />,
  "Partidas": () => <MantenimientoCRUD label="Partidas Arancelarias" columns={["Partida", "Descripción", "Ad Valorem", "Estado"]} />,
  "Marcas": () => <MantenimientoCRUD label="Marcas" columns={["Código", "Marca", "Origen", "Estado"]} />,
  "Plantillas Repuestos": () => <MantenimientoCRUD label="Plantillas de Repuestos" columns={["Código", "Plantilla", "Modelo", "Nº items", "Estado"]} />,
  "Plantilla Repuestos": () => <MantenimientoCRUD label="Plantillas de Repuestos" columns={["Código", "Plantilla", "Modelo", "Nº items", "Estado"]} />,
  "Plantilla Repuestos Cliente": () => <MantenimientoCRUD label="Plantillas de Repuestos por Cliente" columns={["Cliente", "Plantilla", "Modelo", "Vigencia", "Estado"]} />,
  "Ubicacion Servicio": () => <MantenimientoCRUD label="Ubicación de Servicio" columns={["Código", "Ubicación", "Sede", "Responsable", "Estado"]} />,
  "Vehículos": () => <MantenimientoCRUD label="Vehículos" columns={["Placa", "Marca", "Modelo", "Año", "Cliente", "Estado"]} />,
  "Vehiculos": () => <MantenimientoCRUD label="Vehículos" columns={["Placa", "Marca", "Modelo", "Año", "Cliente", "Estado"]} />,
  "Proveedores": () => <MantenimientoCRUD label="Proveedores" columns={["RUC", "Razón Social", "Dirección", "Contacto", "Teléfono", "Estado"]} />,
  "Condición de Pago": () => <MantenimientoCRUD label="Condición de Pago" columns={["Código", "Descripción", "Días", "Tipo", "Estado"]} />,
  "CondiciÃ³n de Pago": () => <MantenimientoCRUD label="Condición de Pago" columns={["Código", "Descripción", "Días", "Tipo", "Estado"]} />,
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
  "Tipo Motores": () => <MantenimientoCRUD label="Tipo Motores" columns={["Código", "Tipo", "Marca", "Estado"]} />,
  "Ruteador": () => <MantenimientoCRUD label="Ruteadores de Rondas" columns={["Código", "Ruteador", "Zona", "Estado"]} />,
  "Rutas": () => <MantenimientoCRUD label="Rutas" columns={["Código", "Ruta", "Zona", "Nº puntos", "Estado"]} />,
  "Puntos Control": () => <MantenimientoCRUD label="Puntos de Control" columns={["Código", "Punto", "Dirección", "Ruta", "Estado"]} />,

  // === MACRO 6 · LOGUEO ===
  "Cerrar Sesión": () => <CerrarSesion />,
  "Cerrar Sesion": () => <CerrarSesion />,
  "Cambiar Contraseña": () => <CambiarContrasena />,
  "Cambiar Contrasena": () => <CambiarContrasena />,
  "Cambiar Empresa": () => <CambiarEmpresa />,

  // === MACRO 6 · ADMINISTRACIÓN ===
  "Usuarios": () => <UsuariosAdmin />,
  "Perfiles": () => <Perfiles />,
  "Sesiones": () => <Sesiones />,
  "Atender Solicitud": () => <AtenderSolicitud />,
  "Tablero": () => <IndicadoresVentaDialog />,
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

  // === CRM ===
  "Oportunidad Negocio": () => <CrmReporteDialog label="Oportunidad Negocio" />,
  "Tarjeta Cliente": () => <CrmReporteDialog label="Tarjeta Cliente" />,
  "Cuota Vendedor": () => <CrmReporteDialog label="Cuota Vendedor" />,
  "Ocurrencias": () => <CrmReporteDialog label="Ocurrencias" />,
  "Visita Clientes": () => <CrmReporteDialog label="Visita Clientes" />,

  // === GERENCIA ===
  "000 - Ventas": () => <GerenciaReporteDialog label="000 - Ventas" />,
  "010 - Importaciones": () => <GerenciaReporteDialog label="010 - Importaciones" />,
  "020 - Inventario y Costos": () => <GerenciaReporteDialog label="020 - Inventario y Costos" />,
  "030 - Contabilidad": () => <GerenciaReporteDialog label="030 - Contabilidad" />,
  "040 - Creditos y Cobranzas": () => <GerenciaReporteDialog label="040 - Creditos y Cobranzas" />,
  "Datos para Indicadores": () => <GerenciaReporteDialog label="Datos para Indicadores" />,
  "Tarjeta": () => <GerenciaReporteDialog label="Tarjeta" />,
  "Contenedor Reportes": () => <GerenciaReporteDialog label="Contenedor Reportes" />,
  "Estados Financieros": () => <GerenciaReporteDialog label="Estados Financieros" />,

  // === MACRO 6 · AYUDA ===
  "Solicitud": () => <SolicitudSoporte />,
  "Información Cambios": () => <InfoCambios />,
  "Informacion Cambios": () => <InfoCambios />,
  "Acerca": () => <Acerca />,
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
  if (normalizedLabel === normalizeWindowLookupKey("Detalle")) return <VentaReporteDialog label={normalizeWindowLabel(label)} />;
  
  // Mapeo de reportes específicos a componentes personalizados
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
  return <ConsultaPreciosDialog/>;
}


// ---------- MDI floating workspace ----------
export function Workspace() {
  const { windows, active, open, close, focus, move, toggleMaximize, minimize, restore } = useWindows();
  const containerRef = useRef<HTMLDivElement>(null);

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
        return isValidElement(node) && node.type === ConsultaPreciosDialog;
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
              src={c2teckWatermark}
              alt="C2TECK"
              className="max-w-[70vw] max-h-[60vh] w-auto h-auto object-contain opacity-90 drop-shadow-[0_10px_30px_rgba(58,85,115,0.25)]"
            />
            <div className="text-slate-400 text-[11px] mt-6 font-mono">// abre un módulo desde el ribbon superior</div>
          </div>
      </div>

      {/* Floating windows */}
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

      {/* Taskbar for minimized windows */}
      {minimized.length > 0 && (
        <div className="absolute bottom-0 left-0 right-0 h-8 bg-gradient-to-t from-[#2A3F55] to-[#3E5B7A] border-t border-slate-900/40 flex items-center gap-1 px-2 z-[9999]">
          {minimized.map(w => (
            <button
              key={w.id}
              onClick={() => restore(w.id)}
              className="h-6 px-2 max-w-[180px] flex items-center gap-1.5 text-[11px] text-white bg-white/10 hover:bg-white/20 rounded-sm border border-white/10 truncate"
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

const STATUS_BAR_H = DESKTOP_STATUS_BAR_H; // two h-7 rows in escritorio status bar

function FloatingWindow({ win, isActive, containerRef, onFocus, onClose, onMove, onToggleMaximize, onMinimize }: FWProps) {
  const [pos, setPos] = useState({ x: win.position.x, y: win.position.y });
  const [localSize, setLocalSize] = useState({ w: win.size.w, h: win.size.h });
  const posRef = useRef(pos);
  const sizeRef = useRef(localSize);
  const pendingPosRef = useRef(pos);
  const pendingSizeRef = useRef(localSize);
  const rafRef = useRef<number | null>(null);
  const dragRef = useRef<{ sx: number; sy: number; ox: number; oy: number } | null>(null);
  const resizeRef = useRef<{ sx: number; sy: number; ox: number; oy: number; ow: number; oh: number; dir: string } | null>(null);
  const [contextMenu, setContextMenu] = useState<{ left: number; top: number } | null>(null);

  const scheduleVisualUpdate = useCallback(() => {
    if (rafRef.current !== null) return;
    rafRef.current = window.requestAnimationFrame(() => {
      rafRef.current = null;
      setPos(pendingPosRef.current);
      setLocalSize(pendingSizeRef.current);
    });
  }, []);

  const closeContextMenu = () => setContextMenu(null);

  const onDragStart = (e: ReactMouseEvent) => {
    if (win.isMaximized) return;
    if ((e.target as HTMLElement).closest("[data-window-control]")) return;
    onFocus();
    dragRef.current = {
      sx: e.clientX, sy: e.clientY,
      ox: posRef.current.x, oy: posRef.current.y,
    };
    document.body.style.userSelect = "none";
    e.preventDefault();
  };

  const onResizeStart = (e: ReactMouseEvent, dir: string) => {
    if (win.isMaximized) return;
    onFocus();
    resizeRef.current = {
      sx: e.clientX, sy: e.clientY,
      ox: posRef.current.x, oy: posRef.current.y,
      ow: sizeRef.current.w, oh: sizeRef.current.h,
      dir,
    };
    document.body.style.userSelect = "none";
    e.preventDefault();
    e.stopPropagation();
  };

  const onContextMenu = (e: ReactMouseEvent<HTMLDivElement>) => {
    e.preventDefault();
    onFocus();
    setContextMenu({ left: e.clientX, top: e.clientY });
  };

  useEffect(() => {
    if (!contextMenu) return;
    const onKeyDown = (e: KeyboardEvent) => {
      if (e.key === "Escape") closeContextMenu();
    };
    window.addEventListener("keydown", onKeyDown);
    return () => window.removeEventListener("keydown", onKeyDown);
  }, [contextMenu]);

  useEffect(() => {
    const onMouseMove = (e: MouseEvent) => {
      const cw = containerRef.current?.offsetWidth ?? window.innerWidth;
      const ch = containerRef.current?.offsetHeight ?? Math.max(320, window.innerHeight - STATUS_BAR_H);

      const d = dragRef.current;
      if (d) {
        const dx = e.clientX - d.sx;
        const dy = e.clientY - d.sy;
        const maxX = Math.max(0, cw - sizeRef.current.w);
        const maxY = Math.max(0, ch - sizeRef.current.h);
        const next = {
          x: Math.max(0, Math.min(d.ox + dx, maxX)),
          y: Math.max(0, Math.min(d.oy + dy, maxY)),
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
      const MIN_W = 200;
      const MIN_H = 120;

      let nx = r.ox, ny = r.oy, nw = r.ow, nh = r.oh;

      if (r.dir.includes('e')) {
        nw = Math.min(cw - nx, Math.max(MIN_W, r.ow + dx));
      }
      if (r.dir.includes('s')) {
        nh = Math.min(ch - ny, Math.max(MIN_H, r.oh + dy));
      }
      if (r.dir.includes('w')) {
        const maxNx = r.ox + r.ow - MIN_W;
        nx = Math.max(0, Math.min(r.ox + dx, maxNx));
        nw = r.ow + (r.ox - nx);
      }
      if (r.dir.includes('n')) {
        const maxNy = r.oy + r.oh - MIN_H;
        ny = Math.max(0, Math.min(r.oy + dy, maxNy));
        nh = r.oh + (r.oy - ny);
      }

      if (ny + nh > ch) nh = ch - ny;
      if (nx + nw > cw) nw = cw - nx;

      nw = Math.max(MIN_W, nw);
      nh = Math.max(MIN_H, nh);

      pendingPosRef.current = { x: nx, y: ny };
      pendingSizeRef.current = { w: nw, h: nh };
      scheduleVisualUpdate();
    };

    const onMouseUp = () => {
      const wasDragging = Boolean(dragRef.current || resizeRef.current);
      if (wasDragging) {
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
      if (rafRef.current !== null) {
        window.cancelAnimationFrame(rafRef.current);
        rafRef.current = null;
      }
      document.body.style.userSelect = "";
    };
  }, [onMove, containerRef, scheduleVisualUpdate]);

  useEffect(() => {
    setPos(win.position);
    pendingPosRef.current = win.position;
  }, [win.position.x, win.position.y]);

  useEffect(() => {
    posRef.current = pos;
  }, [pos]);

  useEffect(() => {
    sizeRef.current = localSize;
  }, [localSize]);

  useEffect(() => {
    setLocalSize(win.size);
    pendingSizeRef.current = win.size;
  }, [win.size.w, win.size.h]);

  // Use absolute positioning inside the workspace container (position:relative).
  // This keeps windows correctly contained within the MDI area (below ribbon, above status bar).
  const style: CSSProperties = win.isMaximized
    ? { left: 0, top: 0, right: 0, bottom: 0, width: "auto", height: "auto", zIndex: win.zIndex, position: "absolute" }
    : { left: pos.x, top: pos.y, width: localSize.w, height: localSize.h, zIndex: win.zIndex, position: "absolute" };

  return (
    <div
      className={[
        "flex flex-col bg-white border border-slate-400/60 shadow-2xl overflow-hidden",
        win.isMaximized ? "rounded-none" : "rounded-lg",
        isActive
          ? "ring-2 ring-[#3B5998]/40"
          : "ring-1 ring-slate-300/40",
      ].join(" ")}
      style={style}
      onMouseDown={onFocus}
    >
      {/* Resize handles */}
      {!win.isMaximized && (
        <>
          <div className="absolute top-0 left-3 right-3 h-2 cursor-n-resize z-10" onMouseDown={(e) => onResizeStart(e, 'n')} />
          <div className="absolute bottom-0 left-3 right-3 h-2 cursor-s-resize z-10" onMouseDown={(e) => onResizeStart(e, 's')} />
          <div className="absolute left-0 top-3 bottom-3 w-2 cursor-w-resize z-10" onMouseDown={(e) => onResizeStart(e, 'w')} />
          <div className="absolute right-0 top-3 bottom-3 w-2 cursor-e-resize z-10" onMouseDown={(e) => onResizeStart(e, 'e')} />
          <div className="absolute top-0 left-0 h-3 w-3 cursor-nw-resize z-10" onMouseDown={(e) => onResizeStart(e, 'nw')} />
          <div className="absolute top-0 right-0 h-3 w-3 cursor-ne-resize z-10" onMouseDown={(e) => onResizeStart(e, 'ne')} />
          <div className="absolute bottom-0 left-0 h-3 w-3 cursor-sw-resize z-10" onMouseDown={(e) => onResizeStart(e, 'sw')} />
          <div className="absolute bottom-0 right-0 h-3 w-3 cursor-se-resize z-10" onMouseDown={(e) => onResizeStart(e, 'se')} />
        </>
      )}
      {/* Title bar */}
      <div
        onMouseDown={onDragStart}
        onDoubleClick={onToggleMaximize}
        onContextMenu={onContextMenu}
        className={[
          "h-9 px-3 flex items-center justify-between select-none shrink-0",
          win.isMaximized ? "cursor-default" : "cursor-move",
          isActive
            ? "bg-gradient-to-b from-[#4C6E93] to-[#2A3F55] text-white"
            : "bg-gradient-to-b from-slate-300 to-slate-400 text-slate-800",
        ].join(" ")}
      >
        <div className="flex items-center gap-2 min-w-0">
          <div className={["h-4 w-4 rounded-sm grid place-items-center shrink-0", isActive ? "bg-white/20" : "bg-white/40"].join(" ")}>
            <Square className="h-2.5 w-2.5" />
          </div>
          <span className="text-[12px] font-semibold truncate">{win.title}</span>
        </div>
        <div className="flex items-center gap-0.5" data-window-control>
          <button
            onClick={(e) => { e.stopPropagation(); onMinimize(); }}
            className="h-6 w-8 grid place-items-center rounded hover:bg-white/20"
            title="Minimizar"
          >
            <Minus className="h-3.5 w-3.5" />
          </button>
          <button
            onClick={(e) => { e.stopPropagation(); onToggleMaximize(); }}
            className="h-6 w-8 grid place-items-center rounded hover:bg-white/20"
            title={win.isMaximized ? "Restaurar" : "Maximizar"}
          >
            {win.isMaximized ? <Minimize2 className="h-3.5 w-3.5" /> : <Maximize2 className="h-3.5 w-3.5" />}
          </button>
          <button
            onClick={(e) => { e.stopPropagation(); onClose(); }}
            className="h-6 w-8 grid place-items-center rounded hover:bg-red-600 hover:text-white"
            title="Cerrar"
          >
            <X className="h-3.5 w-3.5" />
          </button>
        </div>
      </div>

      {/* Body */}
      <div className="flex-1 min-h-0 overflow-hidden bg-white">
        {renderWindow(win.label)}
      </div>
      {contextMenu && createPortal(
        <>
          <div className="fixed inset-0 z-[2147483645]" onMouseDown={closeContextMenu} />
          <div
            className="fixed z-[2147483646] min-w-[220px] rounded-sm border border-slate-300/80 bg-white shadow-2xl p-2"
            style={{ left: contextMenu.left, top: contextMenu.top }}
          >
            <div className="flex items-center gap-2 border-b border-slate-200 pb-2 mb-2">
              <Glyph name={win.label} size={20} className="shrink-0" />
              <div>
                <div className="text-[12px] font-semibold truncate max-w-[170px]">{win.title}</div>
                <div className="text-[10px] text-slate-500">Menú contextual de ventana</div>
              </div>
            </div>
            <div className="flex flex-col gap-1">
              <button
                type="button"
                onClick={() => { onToggleMaximize(); closeContextMenu(); }}
                className="flex items-center gap-2 rounded px-2 py-1.5 text-sm text-slate-800 hover:bg-slate-100"
              >
                {win.isMaximized ? <Minimize2 className="h-4 w-4" /> : <Maximize2 className="h-4 w-4" />}
                <span>{win.isMaximized ? "Restaurar" : "Maximizar"}</span>
              </button>
              <button
                type="button"
                onClick={() => { onMinimize(); closeContextMenu(); }}
                className="flex items-center gap-2 rounded px-2 py-1.5 text-sm text-slate-800 hover:bg-slate-100"
              >
                <Minus className="h-4 w-4" />
                <span>Minimizar</span>
              </button>
              <button
                type="button"
                onClick={() => { onClose(); closeContextMenu(); }}
                className="flex items-center gap-2 rounded px-2 py-1.5 text-sm text-slate-800 hover:bg-slate-100"
              >
                <X className="h-4 w-4" />
                <span>Cerrar</span>
              </button>
            </div>
          </div>
        </>,
        document.body,
      )}
    </div>
  );
}
