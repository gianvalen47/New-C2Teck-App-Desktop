import { Children, createContext, isValidElement, useContext, useState, useRef, useEffect, useCallback, type ReactNode, type CSSProperties, type RefObject, type MouseEvent as ReactMouseEvent } from "react";
import { createPortal } from "react-dom";
import * as React from 'react';
import systeckIcon from "@/assets/Systeck.ico";
import logoC2 from "@/assets/Logos/LogoC2teck02.png";
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
import { normalizeWindowLabel } from "@/context/WindowsContext";
import { ReporteContainerList } from "./windows/Reportes/ReporteContainer";
// Legacy monolith renderer fallback
import { renderWindow as legacyRenderWindow, Workspace as LegacyWorkspace } from "@/components/windows (1).tsx";
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

// --- Public API ---
export function getWindowComponentForLabel(label: string): WindowComponent {
  const key = normalizeWindowLabel(label);
  if (registry[key]) return registry[key];
  // fallback: if the legacy monolith knows how to render this label, wrap it
  return ((props: any) => {
    const node = legacyRenderWindow(label);
    return <>{enhanceToolbar(node)}</> as any;
  }) as WindowComponent;
}

export function hasWindowForLabel(label: string): boolean {
  return !!registry[normalizeWindowLabel(label)];
}

export function registerWindow(label: string, comp: WindowComponent) {
  add(label, comp);
}

export default getWindowComponentForLabel;

// Backwards-compatible helpers used by older codepaths.
export function renderWindow(label: string) {
  const C = getWindowComponentForLabel(label);
  return C ? React.createElement(C) : null;
}

export function Workspace(): React.ReactElement {
  return <LegacyWorkspace />;
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