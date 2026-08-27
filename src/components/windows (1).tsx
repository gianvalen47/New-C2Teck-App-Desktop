import { Children, createContext, isValidElement, useContext, useState, useRef, useEffect, useCallback, type ReactNode, type CSSProperties, type RefObject, type MouseEvent as ReactMouseEvent } from "react";
import { createPortal } from "react-dom";
import {
  X, Check, Save, Printer, Search, Plus, Trash2, FileDown, FileSpreadsheet,
  Mail, Send, RefreshCw, Filter, Calendar, DollarSign, User, Package,
  Wrench, Clock, Car, MapPin, Phone, Users, GraduationCap, Fingerprint, Play, Square,
  Minus, Maximize2, Minimize2, Copy, Zap, Receipt, LogOut, Settings, ArrowDown, ArrowRight, FileSearch, Percent, CreditCard, Pencil, BarChart3, TrendingUp, TrendingDown, Activity, Brain, Server, ShieldAlert, Sparkles
} from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  iconBtn,
  tbSep,
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
import { NewGuideWindow } from "@/features/escritorio/NewGuideWindow";
import { Glyph } from "@/features/escritorio/glyphs";
import { GuiaRemisionList, GuiaRemisionForm } from "@/features/escritorio/windows/GuiasRemision";
import { FacturaVentaList } from "@/features/escritorio/windows/Facturas";
import { NotaVentaList, NotaForm as NotaVentaForm } from "@/features/escritorio/windows/Notas";
import { ClientesList } from "@/features/escritorio/windows/Clientes";
import { UbicacionesList as UbicacionesWindow } from "@/features/escritorio/windows/Ubicaciones";
import { ProductosList } from "@/features/escritorio/windows/Productos";
import { RegistroComprasList } from "@/features/escritorio/windows/ComprasRegistro";
import { DocIngresosList, DocSalidasList, TransferenciasList } from "@/features/escritorio/windows/MovimientosAlmacen";
import { SolicitudCompraList } from "@/features/escritorio/windows/SolicitudCompra";
import { OrdenCompraList } from "@/features/escritorio/windows/OrdenCompra";
import { CuentasPagarList } from "@/features/escritorio/windows/CuentasPagar";
import { SolicitudGastoList } from "@/features/escritorio/windows/SolicitudGasto";
import { PlanillaViaticosList } from "@/features/escritorio/windows/PlanillaViaticos";
import {
  fetchSigecoomClients,
  fetchSigecoomSales,
  createSigecoomSale,
  issueSigecoomSale,
  updateSigecoomSale,
  sendSigecoomSaleEmail,
  linkSigecoomSalePurchase,
  fetchSigecoomJournalEntries,
  createSigecoomJournalEntry,
  fetchInventory,
  createInventoryItem,
  importSigecoomInventory,
  getInventoryItem,
  updateInventoryItem,
  deleteInventoryItem,
  fetchSigecoomLocations,
  createSigecoomLocation,
  updateSigecoomLocation,
  deleteSigecoomLocation,
  exportSigecoomInventory,
  exportSigecoomSales,
  fetchBankAccounts,
  createBankAccount,
  fetchBankTransactions,
  createBankTransaction,
  updateBankTransaction,
  fetchPurchaseRegisters,
  createPurchaseRegister,
  updatePurchaseRegister,
  deletePurchaseRegister,
  fetchCajaChica,
  createCajaChica,
  updateCajaChica,
  fetchGastos,
  createGasto,
  updateGasto,
  deleteGasto,
  submitGastos,
  reimburseGastos,
  getCajaBalance,
  type SigecoomClient,
  type SigecoomSale,
  type SigecoomJournalEntry,
  type SigecoomJournalLine,
  type BankAccount,
  type BankTransaction,
  type InventoryItem,
  type Location,
  type PurchaseRegister,
  type CajaChica,
  type Gasto,
} from "@/lib/sigecoom-api";
import {
  TicketPrinterIcon,
  EmailSendIcon,
  CreditNoteIcon,
  DownloadDocumentIcon,
  SearchDocumentIcon,
} from "@/components/ui/icons";
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
import c2teckWatermark from "@/assets/logos/LogoC2teck02.png";
import { toast } from "sonner";

function downloadBlob(blob: Blob, filename: string) {
  const url = URL.createObjectURL(blob);
  const link = document.createElement("a");
  link.href = url;
  link.download = filename;
  document.body.appendChild(link);
  link.click();
  link.remove();
  URL.revokeObjectURL(url);
}




function ListingBrowser2({
  toolbar2,
  filters,
  columns,
  rows = 0,
  extraTop,
}: {
  toolbar2: ReactNode;
  filters?: "full" | "compact" | ReactNode;
  columns: string[];
  rows?: number;
  extraTop?: ReactNode;
}) {
  const fullFilters = (
    <SearchBar>
      <Field label="Año" className="w-14"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
      <Field label="Mes" className="w-20"><select className={inp} defaultValue="JULIO"><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
      <Field label="Oficina" className="w-24"><select className={inp}><option>LIMA</option><option>AREQUIPA</option><option>TRUJILLO</option></select></Field>
      <Field label="Almacén" className="w-28"><select className={inp}><option>COMERCIAL</option><option>REPUESTOS</option><option>IMPORTACIÓN</option></select></Field>
      <Field label="Tipo" className="w-28"><select className={inp}><option>Credito</option><option>REPUESTOS</option><option>IMPORTACIÓN</option></select></Field>
      <Field label="Serie" className="w-28"><select className={inp}><option>(Todos)</option><option>REPUESTOS</option><option>IMPORTACIÓN</option></select></Field>
      <Field label="Cliente" className="w-56">
        <div className="flex gap-1">
          <input className={`${inp} flex-1`} defaultValue="(Todos)" />
          <button className={iconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
        </div>
      </Field>
      <Field label="Estado" className="w-24"><select className={inp}><option>(Todos)</option><option>ACEPTADO</option><option>PENDIENTE</option><option>RECHAZADO</option></select></Field>
      <Field label="Número" className="w-20"><input className={`${inp} font-mono`} /></Field>
      <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
    </SearchBar>
  );
  return (
    <WindowShell title="Factura de Venta" toolbar={toolbar2}>
      <div className="h-full min-h-0 flex flex-col">
        {extraTop}
        {filters === "full" || filters === undefined ? fullFilters : filters === "compact" ? null : <div className="mx-1.5 mt-1.5">{filters}</div>}
        <div className="p-1.5 flex-1 min-h-0">
          <DataTable columns={columns} rows={rows} className="h-full overflow-auto" />
        </div>
      </div>
    </WindowShell>
  );
}

function ListingBrowser3({
  toolbar2,
  filters,
  columns,
  rows = 0,
  extraTop,
}: {
  toolbar2: ReactNode;
  filters?: "full" | "compact" | ReactNode;
  columns: string[];
  rows?: number;
  extraTop?: ReactNode;
}) {
  const fullFilters = (
    <SearchBar>
      <Field label="Año" className="w-14"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
      <Field label="Mes" className="w-20"><select className={inp} defaultValue="JULIO"><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
      <Field label="Oficina" className="w-24"><select className={inp}><option>LIMA</option><option>AREQUIPA</option><option>TRUJILLO</option></select></Field>
      <Field label="Almacén" className="w-28"><select className={inp}><option>COMERCIAL</option><option>REPUESTOS</option><option>IMPORTACIÓN</option></select></Field>
      <Field label="Documento" className="w-28"><select className={inp}><option>Credito</option><option>REPUESTOS</option><option>IMPORTACIÓN</option></select></Field>
      <Field label="Cliente" className="w-56">
        <div className="flex gap-1">
          <input className={`${inp} flex-1`} defaultValue="(Todos)" />
          <button className={iconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
        </div>
      </Field>
      <Field label="Estado" className="w-24"><select className={inp}><option>(Todos)</option><option>ACEPTADO</option><option>PENDIENTE</option><option>RECHAZADO</option></select></Field>
      <Field label="Número" className="w-20"><input className={`${inp} font-mono`} /></Field>
      <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
    </SearchBar>
  );
  return (
    <WindowShell title="Factura de Venta" toolbar={toolbar2}>
      <div className="h-full min-h-0 flex flex-col">
        {extraTop}
        {filters === "full" || filters === undefined ? fullFilters : filters === "compact" ? null : <div className="mx-1.5 mt-1.5">{filters}</div>}
        <div className="p-1.5 flex-1 min-h-0">
          <DataTable columns={columns} rows={rows} className="h-full overflow-auto" />
        </div>
      </div>
    </WindowShell>
  );
}

function ListingBrowser4({
  toolbar2,
  filters,
  columns,
  rows = 0,
  extraTop,
}: {
  toolbar2: ReactNode;
  filters?: "full" | "compact" | ReactNode;
  columns: string[];
  rows?: number;
  extraTop?: ReactNode;
}) {
  const fullFilters = (
    <SearchBar>
      <Field label="Año" className="w-14"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
      <Field label="Mes" className="w-20"><select className={inp} defaultValue="JULIO"><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
      <Field label="Oficina" className="w-24"><select className={inp}><option>LIMA</option><option>AREQUIPA</option><option>TRUJILLO</option></select></Field>
      <Field label="Almacén" className="w-28"><select className={inp}><option>COMERCIAL</option><option>REPUESTOS</option><option>IMPORTACIÓN</option></select></Field>
      <Field label="Cliente" className="w-56">
        <div className="flex gap-1">
          <input className={`${inp} flex-1`} defaultValue="(Todos)" />
          <button className={iconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
        </div>
      </Field>
      <Field label="Estado" className="w-24"><select className={inp}><option>(Todos)</option><option>ACEPTADO</option><option>PENDIENTE</option><option>RECHAZADO</option></select></Field>
      <Field label="Número" className="w-20"><input className={`${inp} font-mono`} /></Field>
      <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
    </SearchBar>
  );
  return (
    <WindowShell title="Factura de Venta" toolbar={toolbar2}>
      <div className="h-full min-h-0 flex flex-col">
        {extraTop}
        {filters === "full" || filters === undefined ? fullFilters : filters === "compact" ? null : <div className="mx-1.5 mt-1.5">{filters}</div>}
        <div className="p-1.5 flex-1 min-h-0">
          <DataTable columns={columns} rows={rows} className="h-full overflow-auto" />
        </div>
      </div>
    </WindowShell>
  );
}

function ListingBrowser5({
  toolbar2,
  filters,
  columns,
  rows = 0,
  extraTop,
}: {
  toolbar2: ReactNode;
  filters?: "full" | "compact" | ReactNode;
  columns: string[];
  rows?: number;
  extraTop?: ReactNode;
}) {
  const fullFilters = (
    <SearchBar>
      <Field label="Año" className="w-14"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
      <Field label="Mes" className="w-20"><select className={inp} defaultValue="JULIO"><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
      <Field label="Oficina" className="w-24"><select className={inp}><option>LIMA</option><option>AREQUIPA</option><option>TRUJILLO</option></select></Field>
      <Field label="Almacén" className="w-28"><select className={inp}><option>COMERCIAL</option><option>REPUESTOS</option><option>IMPORTACIÓN</option></select></Field>
      <Field label="Tipo" className="w-28"><select className={inp}><option>Credito</option><option>REPUESTOS</option><option>IMPORTACIÓN</option></select></Field>
      <Field label="Cliente" className="w-56">
        <div className="flex gap-1">
          <input className={`${inp} flex-1`} defaultValue="(Todos)" />
          <button className={iconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
        </div>
      </Field>
      <Field label="Estado" className="w-24"><select className={inp}><option>(Todos)</option><option>ACEPTADO</option><option>PENDIENTE</option><option>RECHAZADO</option></select></Field>
      <Field label="Número" className="w-20"><input className={`${inp} font-mono`} /></Field>
      <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
    </SearchBar>
  );
  return (
    <WindowShell title="Factura de Venta" toolbar={toolbar2}>
      <div className="h-full min-h-0 flex flex-col">
        {extraTop}
        {filters === "full" || filters === undefined ? fullFilters : filters === "compact" ? null : <div className="mx-1.5 mt-1.5">{filters}</div>}
        <div className="p-1.5 flex-1 min-h-0">
          <DataTable columns={columns} rows={rows} className="h-full overflow-auto" />
        </div>
      </div>
    </WindowShell>
  );
}

function ListingBrowser6({
  toolbar2,
  filters,
  columns,
  rows = 0,
  extraTop,
}: {
  toolbar2: ReactNode;
  filters?: "full" | "compact" | ReactNode;
  columns: string[];
  rows?: number;
  extraTop?: ReactNode;
}) {
  const fullFilters = (
      <div className="flex items-end flex-wrap gap-x-3 gap-y-1 justify-center">
    <SearchBar>
      <Field label="Año" className="w-16"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
      <Field label="Mes" className="w-24"><select className={inp} defaultValue="JULIO"><option>JULIO</option></select></Field>
      <Field label="Cod. Resumen" className="w-44"><input className={inp} /></Field>
      <button className={`${btn} h-[22px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
    </SearchBar>
      </div>
  );
  return (
    <WindowShell title="Factura de Venta" toolbar={toolbar2}>
      <div className="h-full min-h-0 flex flex-col">
        {extraTop}
        {filters === "full" || filters === undefined ? fullFilters : filters === "compact" ? null : <div className="mx-1.5 mt-1.5">{filters}</div>}
        <div className="p-1.5 flex-1 min-h-0">
          <DataTable columns={columns} rows={rows} className="h-full overflow-auto" />
        </div>
      </div>
    </WindowShell>
  );
}

const stdToolbar3 = (
  <>
    {/* Grupo principal: Impresión / Envíos / Nuevo */}
    <button className={iconBtn} title="Imprimir Documento"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Crear un Nuevo Registro"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar los datos del registro seleccionado"><Search className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Eliminar el registro seleccionado"><Trash2 className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Anular"><X className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Factura Electrónica"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar"><RefreshCw className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Nota Electrónica"><Receipt className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Comunicación de Baja Nota Electrónica"><X className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Descargar Nota Electrónica"><FileDown className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Notas Electrónicas"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Comunicados Baja"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    {/* Salir / Control */}
    <button className={iconBtn} title="Cerrar la ventana actual"><LogOut className="h-4 w-4" /></button>
  </>
);

const stdToolbar4 = (
  <>
    {/* Grupo principal: Impresión / Envíos / Nuevo */}
    <button className={iconBtn} title="Imprimir"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Nuevo"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar"><Search className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Eliminar"><Trash2 className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Anular"><X className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Procesar Guía de Devolución"><Wrench className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Estados de la G/D"><Clock className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar"><RefreshCw className="h-4 w-4" /></button>
    {tbSep}
    {/* Salir / Control */}
    <button className={iconBtn} title="Cerrar la ventana actual"><LogOut className="h-4 w-4" /></button>
  </>
);

const stdToolbar5 = (
  <>
    {/* Grupo principal: Impresión / Envíos / Nuevo */}
    <button className={iconBtn} title="Imprimir Boleta"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Imprimir Ticket"><TicketPrinterIcon className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar a Crédito y Cobranzas para aprobación de precios"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Crea un Nuevo Registro"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar los datos del registro seleccionado"><Search className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Eliminar el registro seleccionado"><Trash2 className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar los Estados de la Boleta"><Clock className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Anular Boleta"><X className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Facturar OT"><Wrench className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Sugerir Factor / Descuento"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Precios Sugeridos"><DollarSign className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Boleta Electrónica"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Refrescar Datos"><RefreshCw className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Boleta Electrónica"><FileSpreadsheet className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Descargar Boleta Electrónica"><FileDown className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Boleta Electrónicas"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Comunicados Baja"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    {/* Salir / Control */}
    <button className={iconBtn} title="Cerrar la ventana actual"><LogOut className="h-4 w-4" /></button>
  </>
);

const stdToolbar6 = (
  <>
    {/* Grupo principal: Impresión / Envíos / Nuevo */}
    <button className={iconBtn} title="Crear un nuevo registro"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar los datos del registro seleccionado"><Search className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Obtener Estado Sunat"><Clock className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar"><RefreshCw className="h-4 w-4" /></button>
    {tbSep}
    {/* Salir / Control */}
    <button className={iconBtn} title="Cerrar la ventana actual"><LogOut className="h-4 w-4" /></button>
  </>
);

const stdToolbar7 = (
  <>
    {/* Grupo principal: Impresión / Envíos / Nuevo */}
    <button className={iconBtn} title="Imprimir Cotización"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Crear una nueva cotización"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar los datos de la cotizacion seleccionada"><Search className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Eliminar cotizacion seleccionada"><Trash2 className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Observaciones de la cotizacion"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar G/F/B/O.C."><FileSpreadsheet className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar a Créditos"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Guías de Remision Multiples"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Duplicar Cotización"><Copy className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Rechazar Cotización"><X className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Estados de la Cotización"><Clock className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Precios Sugeridos"><DollarSign className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Sugerir Factor/Descuento"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Archivos"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar Cotización"><RefreshCw className="h-4 w-4" /></button>
    {tbSep}
    {/* Salir / Control */}
    <button className={iconBtn} title="Cerrar la ventana actual"><LogOut className="h-4 w-4" /></button>
  </>
);

const stdToolbar8 = (
  <>
    {/* Grupo principal: Impresión / Envíos / Nuevo */}
    <button className={iconBtn} title="Imprimir Reclamo"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Documento"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Nuevo Reclamo"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Reclamo"><Search className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Eliminar Reclamo"><Trash2 className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Documentos Generados"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar Reclamo"><RefreshCw className="h-4 w-4" /></button>
    {tbSep}
    {/* Salir / Control */}
    <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4" /></button>
  </>
);

const stdToolbar9 = (
  <>
    {/* Grupo principal: Impresión / Envíos / Nuevo */}
    <button className={iconBtn} title="Mostrar los datos del registro seleccionado"><Search className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Aprobar"><Check className="h-4 w-4" /></button>
    {tbSep}
    {/* Salir / Control */}
    <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4" /></button>
  </>
);

const stdToolbar10 = (
  <>
    {/* Grupo principal: Impresión / Envíos / Nuevo */}
    <button className={iconBtn} title="Imprimir"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar"><TicketPrinterIcon className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar para su Aprobacion"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Crear un nuevo registro"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar los datos del registro seleccionado"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Eliminar el registro seleccionado"><Search className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar a Créditos"><Trash2 className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Ver Estados de O/C"><Clock className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Separaciones"><Wrench className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Sugerir Factor o Descuento"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar Orden de Compra"><RefreshCw className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Precios Sugeridos"><MapPin className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Pedido Interno"><Receipt className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Registrar Archivos"><Mail className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Refrescar"><Send className="h-4 w-4" /></button>
    {tbSep}
    {/* Salir / Control */}
    <button className={iconBtn} title="Cerrar la ventana actual"><LogOut className="h-4 w-4" /></button>
  </>
);

const stdToolbar11 = (
  <>
    {/* Grupo principal: Impresión / Envíos / Nuevo */}
    <button className={iconBtn} title="Modificar Vendedor"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Limpiar Formulario"><TicketPrinterIcon className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Guardar los cambios realizados"><Send className="h-4 w-4" /></button>
    {tbSep}
    {/* Salir / Control */}
    <button className={iconBtn} title="Salir del Formulario"><LogOut className="h-4 w-4" /></button>
  </>
);

const stdToolbar12 = (
  <>
    {/* Grupo principal: Impresión / Envíos / Nuevo */}
    <button className={iconBtn} title="Imprimir"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Crear un Nuevo Registro"><TicketPrinterIcon className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar los datos del registro seleccionado"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Eliminar el registro seleccionado"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Refrescar"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    {/* Salir / Control */}
    <button className={iconBtn} title="Cerrar la Ventana Actual"><LogOut className="h-4 w-4" /></button>
  </>
);

const stdToolbar13 = (
  <>
    {/* Grupo principal: Impresión / Envíos / Nuevo */}
    <button className={iconBtn} title="Mostrar los datos del registro seleccionado"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Eliminar Requisicion"><TicketPrinterIcon className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Cierre"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Refrescar"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    {/* Salir / Control */}
    <button className={iconBtn} title="Cerrar la ventana actual"><LogOut className="h-4 w-4" /></button>
  </>
);

const stdToolbar14 = (
  <>
    {/* Grupo principal: Impresión / Envíos / Nuevo */}
    <button className={iconBtn} title="Imprimir Documento"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Imprimir Ticket"><TicketPrinterIcon className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Guía"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar Guías"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Ver Estados del Documento"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Precios Sugeridos"><Search className="h-4 w-4" /></button>
    {tbSep}
    {/* Salir / Control */}
    <button className={iconBtn} title="Cerrar Formulario"><LogOut className="h-4 w-4" /></button>
  </>
);

const stdToolbarAlmacen = (
  <>
    <button className={iconBtn} title="Imprimir Documento"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Crear un nuevo registro"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar los datos del registro seleccionado"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Chequear"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Eliminar el registro seleccionado"><Search className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Solicitud de Gastos"><RefreshCw className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Impresión de Facturas de Importación Masiva"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Procesar Documento"><FileSpreadsheet className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar Datos"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Cerrar la ventana actual"><LogOut className="h-4 w-4" /></button>
  </>
);

const stdToolbar15 = (
  <>
    {/* Grupo principal: Impresión / Envíos / Nuevo */}
    <button className={iconBtn} title="Imprimir"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Ticket"><TicketPrinterIcon className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="B2Mining"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Nuevo"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar"><Search className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Eliminar"><Trash2 className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Estados de la Factura"><Clock className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Facturar OT"><Wrench className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Facturar Grupo G/R Pendientes"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Sugerir Factor o Descuento"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Precios Sugeridos"><DollarSign className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Cuotas"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar"><RefreshCw className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar Locacion"><MapPin className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Nota Crédito"><Receipt className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Nota Crédito"><Mail className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Factura Electrónica"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Factura Electrónica"><FileSpreadsheet className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Comunicación de Baja Factura Electrónica"><X className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Descargar Factura Electrónica"><FileDown className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Facturas Electrónicas"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Comunicados Baja"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    {/* Salir / Control */}
    <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4" /></button>
  </>
);

const stdToolbar16 = (
  <>
    {/* Grupo principal: Impresión / Envíos / Nuevo */}
    <button className={iconBtn} title="Imprimir"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Ticket"><TicketPrinterIcon className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="B2Mining"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Nuevo"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar"><Search className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Eliminar"><Trash2 className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Estados de la Factura"><Clock className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Facturar OT"><Wrench className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Facturar Grupo G/R Pendientes"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Sugerir Factor o Descuento"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Precios Sugeridos"><DollarSign className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Cuotas"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar"><RefreshCw className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar Locacion"><MapPin className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Nota Crédito"><Receipt className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Nota Crédito"><Mail className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Factura Electrónica"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Factura Electrónica"><FileSpreadsheet className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Comunicación de Baja Factura Electrónica"><X className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Descargar Factura Electrónica"><FileDown className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Facturas Electrónicas"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Comunicados Baja"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    {/* Salir / Control */}
    <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4" /></button>
  </>
);

const stdToolbar17 = (
  <>
    {/* Grupo principal: Impresión / Envíos / Nuevo */}
    <button className={iconBtn} title="Imprimir"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Ticket"><TicketPrinterIcon className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="B2Mining"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Nuevo"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar"><Search className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Eliminar"><Trash2 className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Estados de la Factura"><Clock className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Facturar OT"><Wrench className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Facturar Grupo G/R Pendientes"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Sugerir Factor o Descuento"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Precios Sugeridos"><DollarSign className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Cuotas"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar"><RefreshCw className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar Locacion"><MapPin className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Nota Crédito"><Receipt className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Nota Crédito"><Mail className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Factura Electrónica"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Factura Electrónica"><FileSpreadsheet className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Comunicación de Baja Factura Electrónica"><X className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Descargar Factura Electrónica"><FileDown className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Facturas Electrónicas"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Comunicados Baja"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    {/* Salir / Control */}
    <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4" /></button>
  </>
);

const stdToolbar18 = (
  <>
    {/* Grupo principal: Impresión / Envíos / Nuevo */}
    <button className={iconBtn} title="Imprimir"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Ticket"><TicketPrinterIcon className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="B2Mining"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Nuevo"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar"><Search className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Eliminar"><Trash2 className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Estados de la Factura"><Clock className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Facturar OT"><Wrench className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Facturar Grupo G/R Pendientes"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Sugerir Factor o Descuento"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Precios Sugeridos"><DollarSign className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Cuotas"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar"><RefreshCw className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar Locacion"><MapPin className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Nota Crédito"><Receipt className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Nota Crédito"><Mail className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Factura Electrónica"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Factura Electrónica"><FileSpreadsheet className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Comunicación de Baja Factura Electrónica"><X className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Descargar Factura Electrónica"><FileDown className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Facturas Electrónicas"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Comunicados Baja"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    {/* Salir / Control */}
    <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4" /></button>
  </>
);

const stdToolbar19 = (
  <>
    {/* Grupo principal: Impresión / Envíos / Nuevo */}
    <button className={iconBtn} title="Imprimir"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Ticket"><TicketPrinterIcon className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="B2Mining"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Nuevo"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar"><Search className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Eliminar"><Trash2 className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Estados de la Factura"><Clock className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Facturar OT"><Wrench className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Facturar Grupo G/R Pendientes"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Sugerir Factor o Descuento"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Precios Sugeridos"><DollarSign className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Cuotas"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar"><RefreshCw className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar Locacion"><MapPin className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Nota Crédito"><Receipt className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Nota Crédito"><Mail className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Factura Electrónica"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Factura Electrónica"><FileSpreadsheet className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Comunicación de Baja Factura Electrónica"><X className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Descargar Factura Electrónica"><FileDown className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Facturas Electrónicas"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Comunicados Baja"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    {/* Salir / Control */}
    <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4" /></button>
  </>
);

const stdToolbar20 = (
  <>
    {/* Grupo principal: Impresión / Envíos / Nuevo */}
    <button className={iconBtn} title="Imprimir"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Ticket"><TicketPrinterIcon className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="B2Mining"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Nuevo"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar"><Search className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Eliminar"><Trash2 className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Estados de la Factura"><Clock className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Facturar OT"><Wrench className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Facturar Grupo G/R Pendientes"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Sugerir Factor o Descuento"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Precios Sugeridos"><DollarSign className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Cuotas"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar"><RefreshCw className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar Locacion"><MapPin className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Nota Crédito"><Receipt className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Nota Crédito"><Mail className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Factura Electrónica"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Factura Electrónica"><FileSpreadsheet className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Comunicación de Baja Factura Electrónica"><X className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Descargar Factura Electrónica"><FileDown className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Facturas Electrónicas"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Comunicados Baja"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    {/* Salir / Control */}
    <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4" /></button>
  </>
);

const stdToolbar21 = (
  <>
    {/* Grupo principal: Impresión / Envíos / Nuevo */}
    <button className={iconBtn} title="Imprimir"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Ticket"><TicketPrinterIcon className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="B2Mining"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Nuevo"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar"><Search className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Eliminar"><Trash2 className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Estados de la Factura"><Clock className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Facturar OT"><Wrench className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Facturar Grupo G/R Pendientes"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Sugerir Factor o Descuento"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Precios Sugeridos"><DollarSign className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Cuotas"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar"><RefreshCw className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar Locacion"><MapPin className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Nota Crédito"><Receipt className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Nota Crédito"><Mail className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Factura Electrónica"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Factura Electrónica"><FileSpreadsheet className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Comunicación de Baja Factura Electrónica"><X className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Descargar Factura Electrónica"><FileDown className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Facturas Electrónicas"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Comunicados Baja"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    {/* Salir / Control */}
    <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4" /></button>
  </>
);

const stdToolbar22 = (
  <>
    {/* Grupo principal: Impresión / Envíos / Nuevo */}
    <button className={iconBtn} title="Imprimir"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Ticket"><TicketPrinterIcon className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="B2Mining"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Nuevo"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar"><Search className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Eliminar"><Trash2 className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Estados de la Factura"><Clock className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Facturar OT"><Wrench className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Facturar Grupo G/R Pendientes"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Sugerir Factor o Descuento"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Precios Sugeridos"><DollarSign className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Cuotas"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar"><RefreshCw className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar Locacion"><MapPin className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Nota Crédito"><Receipt className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Nota Crédito"><Mail className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Factura Electrónica"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Factura Electrónica"><FileSpreadsheet className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Comunicación de Baja Factura Electrónica"><X className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Descargar Factura Electrónica"><FileDown className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Facturas Electrónicas"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Comunicados Baja"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    {/* Salir / Control */}
    <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4" /></button>
  </>
);

const stdToolbar23 = (
  <>
    {/* Grupo principal: Impresión / Envíos / Nuevo */}
    <button className={iconBtn} title="Imprimir"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Ticket"><TicketPrinterIcon className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="B2Mining"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Nuevo"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar"><Search className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Eliminar"><Trash2 className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Estados de la Factura"><Clock className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Facturar OT"><Wrench className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Facturar Grupo G/R Pendientes"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Sugerir Factor o Descuento"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Precios Sugeridos"><DollarSign className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Cuotas"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar"><RefreshCw className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar Locacion"><MapPin className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Nota Crédito"><Receipt className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Nota Crédito"><Mail className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Factura Electrónica"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Factura Electrónica"><FileSpreadsheet className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Comunicación de Baja Factura Electrónica"><X className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Descargar Factura Electrónica"><FileDown className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Facturas Electrónicas"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Comunicados Baja"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    {/* Salir / Control */}
    <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4" /></button>
  </>
);

const stdToolbar24 = (
  <>
    {/* Grupo principal: Impresión / Envíos / Nuevo */}
    <button className={iconBtn} title="Imprimir"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Ticket"><TicketPrinterIcon className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="B2Mining"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Nuevo"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar"><Search className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Eliminar"><Trash2 className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Estados de la Factura"><Clock className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Facturar OT"><Wrench className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Facturar Grupo G/R Pendientes"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Sugerir Factor o Descuento"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Precios Sugeridos"><DollarSign className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Cuotas"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar"><RefreshCw className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar Locacion"><MapPin className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Nota Crédito"><Receipt className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Nota Crédito"><Mail className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Factura Electrónica"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Factura Electrónica"><FileSpreadsheet className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Comunicación de Baja Factura Electrónica"><X className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Descargar Factura Electrónica"><FileDown className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Facturas Electrónicas"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Comunicados Baja"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    {/* Salir / Control */}
    <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4" /></button>
  </>
);

const stdToolbar25 = (
  <>
    {/* Grupo principal: Impresión / Envíos / Nuevo */}
    <button className={iconBtn} title="Imprimir"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Ticket"><TicketPrinterIcon className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="B2Mining"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Nuevo"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar"><Search className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Eliminar"><Trash2 className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Estados de la Factura"><Clock className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Facturar OT"><Wrench className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Facturar Grupo G/R Pendientes"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Sugerir Factor o Descuento"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Precios Sugeridos"><DollarSign className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Cuotas"><Percent className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar"><RefreshCw className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar Locacion"><MapPin className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Nota Crédito"><Receipt className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Nota Crédito"><Mail className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Factura Electrónica"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Factura Electrónica"><FileSpreadsheet className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Comunicación de Baja Factura Electrónica"><X className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Descargar Factura Electrónica"><FileDown className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Facturas Electrónicas"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Comunicados Baja"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    {/* Salir / Control */}
    <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4" /></button>
  </>
);


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
    <ListingBrowser4
      toolbar2={stdToolbar4}
      columns={["Número", "Fecha", "Referencia", "Cliente", "Mon.", "Total", "EST", "Doc.Devuelto", "TipMov"]}
      rows={0}
    />
  );
}

function Boleta() {
  return (
    <ListingBrowser5
      toolbar2={stdToolbar5}
      columns={["Número", "Fecha", "Cliente", "Mon.", "Total", "EST", "Estado Sunat", "C", "TotNetoSug", "ObservacionSunat"]}
      rows={0}
    />
  );
}

function ResumenBoletas() {
  return (
    <ListingBrowser6
      toolbar2={stdToolbar6}
      columns={["Cod. Resumen", "Fecha", "N° Ticket", "Observacion", "Notas", "Estado Sunat"]}
      rows={0}
    />
  );
}

// ---------- Ventas: Pre y Post ----------
function Cotizaciones() {
  return (
    <WindowShell title="Cotizaciones"
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Generar</button>
      </>}
    >
      <div className="p-3 space-y-3 max-w-xl mx-auto text-[11.5px] text-slate-800">
        <div className="grid grid-cols-[auto_1fr_auto_1fr] items-center gap-x-2 gap-y-2">
          <div className="text-right font-medium">Del :</div>
          <div><input className={inp} type="date" defaultValue="2026-08-01" /></div>
          <div className="text-right font-medium">Al :</div>
          <div><input className={inp} type="date" defaultValue="2026-08-08" /></div>
        </div>

        <div className="grid grid-cols-2 gap-3">
          <Field label="Oficina"><select className={inp}><option>(Todos)</option></select></Field>
          <Field label="Almacén"><select className={inp}><option>(Todos)</option></select></Field>
        </div>

        <Fs legend="Buscar Cliente">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Cliente</label>
          <Field label="Cliente"><div className="flex gap-1"><input className={`${inp} flex-1`} /><button className={iconBtn}><Search className="h-3.5 w-3.5" /></button></div></Field>
        </Fs>

        <Fs legend="Buscar Vendedor">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Vendedor</label>
          <Field label="Vendedor"><select className={inp}><option>(Todos)</option></select></Field>
        </Fs>

        <div className="grid grid-cols-[1.4fr_0.9fr] gap-3">
          <Fs legend="Opciones">
            <Field label="Estado"><select className={inp}><option>(Todos)</option><option>Generados</option><option>Vencidos</option><option>Atendidos</option><option>Rechazados</option></select></Field>
            <Field label="Tipo de Rechazo"><select className={inp}><option>(Todos)</option></select></Field>
          </Fs>
          <div className="rounded border border-slate-300/80 bg-slate-50/80 p-3 text-[11px] text-slate-800">
            <div className="font-medium mb-2">Mostrar</div>
            <div className="space-y-1">
              <label className="flex items-center gap-2"><input type="radio" name="cotop" className="accent-[#2A5590]" defaultChecked />Todos</label>
              <label className="flex items-center gap-2"><input type="radio" name="cotop" className="accent-[#2A5590]" />Generados</label>
              <label className="flex items-center gap-2"><input type="radio" name="cotop" className="accent-[#2A5590]" />Vencidos</label>
              <label className="flex items-center gap-2"><input type="radio" name="cotop" className="accent-[#2A5590]" />Atendidos</label>
              <label className="flex items-center gap-2"><input type="radio" name="cotop" className="accent-[#2A5590]" />Rechazados</label>
            </div>
          </div>
        </div>

        <div className="mt-2 flex justify-center gap-2"><button className={btnPrimary}>Aceptar</button><button className={btn}>Cancelar</button></div>
      </div>
    </WindowShell>
  );
}

function ReclamoGarantia() {
  return (
    <MasterDetailForm
      title="Reclamos de Garantía"
      toolbar={stdToolbar8}
      header={
        <div className="grid grid-cols-5 gap-2">
          <Field label="N° Reclamo"><input className={`${inp} font-mono`} defaultValue="" /></Field>
          <Field label="Fecha"><input className={inp} type="date" defaultValue="2026-07-25" /></Field>
          <Field label="Control"><input className={inp} defaultValue="" /></Field>
          <Field label="Estado"><select className={inp}><option>REGISTRADO</option><option>EN EVALUACIÓN</option><option>CERRADO</option><option>ANULADO</option></select></Field>
          <Field label="Resultado"><select className={inp}><option>(Pendiente)</option><option>PROCEDE</option><option>NO PROCEDE</option></select></Field>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Cliente" className="w-64"><input className={inp} defaultValue="(Todos)" /></Field>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Estado" className="w-36"><select className={inp}><option>(Todos)</option><option>REGISTRADO</option><option>EN EVALUACIÓN</option><option>CERRADO</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["N°", "Fecha", "Control", "Cliente", "Documento", "Equipo", "Falla", "Estado", "Resultado"]}
      rows={0}
      footer={
        <div className="px-1.5 pb-1.5 flex justify-end gap-2">
          <button className={btn}><X className="h-3.5 w-3.5" />Cancelar</button>
          <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        </div>
      }
    />
  );
}

function SepararOrden() {
  return (
    <MasterDetailForm
      title="Separación de Orden"
      toolbar={stdToolbar9}
      header={
        <div className="grid grid-cols-6 gap-2">
          <Field label="N° Orden"><input className={`${inp} font-mono`} defaultValue="" /></Field>
          <Field label="Fecha"><input className={inp} type="date" defaultValue="2026-07-25" /></Field>
          <Field label="Cliente"><input className={inp} defaultValue="" /></Field>
          <Field label="Moneda"><select className={inp}><option>PEN</option><option>USD</option></select></Field>
          <Field label="Estado"><select className={inp}><option>PENDIENTE</option><option>SEPARADO</option><option>ATENDIDO</option><option>ANULADO</option></select></Field>
          <Field label="Vendedor"><input className={inp} defaultValue="" /></Field>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Cliente" className="w-64"><input className={inp} defaultValue="(Todos)" /></Field>
          <Field label="Estado" className="w-36"><select className={inp}><option>(Todos)</option><option>PENDIENTE</option><option>SEPARADO</option><option>ATENDIDO</option><option>ANULADO</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Ítem", "Código", "Descripción", "Stock", "Cant. Sol.", "Cant. Sep.", "Mon.", "P.Unit", "Total"]}
      rows={0}
      summary={<CalculationSummaryBlock values={{ subtotal: 0, discount: 0, igv: 0, total: 0 }} />}
    />
  );
}

function OrdenesCompra() {
  return (
    <MasterDetailForm
      title="Órdenes de Compra de Venta"
      toolbar={stdToolbar10}
      header={
        <div className="grid grid-cols-6 gap-2">
          <Field label="Número"><input className={`${inp} font-mono`} defaultValue="000123" /></Field>
          <Field label="Fecha"><input className={inp} type="date" defaultValue="2026-07-25" /></Field>
          <Field label="Estado"><select className={inp}><option>PENDIENTE</option><option>ATENDIDO</option><option>ANULADO</option></select></Field>
          <Field label="Moneda"><select className={inp}><option>PEN</option><option>USD</option></select></Field>
          <Field label="Vendedor"><input className={inp} defaultValue="(Asignar)" /></Field>
          <Field label="Prioridad"><select className={inp}><option>NORMAL</option><option>URGENTE</option></select></Field>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Cliente" className="w-64">
            <div className="flex gap-1">
              <input className={`${inp} flex-1`} defaultValue="(Todos)" />
              <button className={iconBtn} title="Buscar cliente"><Search className="h-3.5 w-3.5" /></button>
            </div>
          </Field>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Tipo" className="w-32"><select className={inp}><option>(Todos)</option><option>Nacional</option><option>Importación</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Ítem", "Código", "Descripción", "Cant.", "P.Unit", "Desc.", "SubTotal", "IGV", "Total"]}
      rows={8}
      summary={<CalculationSummaryBlock values={{ subtotal: 0, discount: 0, igv: 0, total: 0 }} />}
    />
  );
}

function ActualizarVendedor() {
  return (
    <MasterDetailForm
      title="Actualizar Vendedor por Documento"
      toolbar={stdToolbar11}
      header={
        <div className="grid grid-cols-5 gap-2">
          <Field label="Documento"><input className={`${inp} font-mono`} defaultValue="" /></Field>
          <Field label="Fecha"><input className={inp} type="date" defaultValue="2026-07-25" /></Field>
          <Field label="Cliente"><input className={inp} defaultValue="" /></Field>
          <Field label="Vendedor Actual"><input className={inp} defaultValue="" /></Field>
          <Field label="Nuevo Vendedor"><select className={inp}><option>(Seleccionar)</option><option>VENDEDOR 01</option><option>VENDEDOR 02</option></select></Field>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Año" className="w-16"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
          <Field label="Mes" className="w-28"><select className={inp} defaultValue="JULIO"><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
          <Field label="Oficina" className="w-32"><select className={inp}><option>(Todas)</option><option>LIMA</option><option>AREQUIPA</option></select></Field>
          <Field label="Estado" className="w-28"><select className={inp}><option>(Todos)</option><option>GENERADO</option><option>EMITIDO</option><option>ANULADO</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Sel", "Documento", "Fecha", "Cliente", "Vendedor Actual", "Nuevo Vendedor", "Moneda", "Total", "Estado"]}
      rows={0}
      footer={
        <div className="px-1.5 pb-1.5 flex justify-end gap-2">
          <button className={btn}><X className="h-3.5 w-3.5" />Cancelar</button>
          <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Aplicar Cambio</button>
        </div>
      }
    />
  );
}

function EnviarCorreos() {
  return (
    <WindowShell title="Envío masivo de comprobantes"
      toolbar={null}>
      <div className="p-3 space-y-2 max-w-4xl mx-auto">
        <Fs legend="Tipo">
          <div className="flex gap-6 mx-auto">
            <Radio label="Clientes" name="tipoenvio" defaultChecked />
            <Radio label="Personal Interno" name="tipoenvio" />
          </div>
        </Fs>
        <div className="grid grid-cols-[70px_1fr] gap-x-2 gap-y-1.5 text-[11.5px]">
          <label className="text-right pt-1 font-bold">De :</label><input className={inp} />
          <label className="text-right pt-1 font-bold">Para :</label>
          <div className="border border-[#7A96B4] bg-white h-24 overflow-auto">
            <table className="w-full text-[11.5px]">
              <thead className="bg-gradient-to-b from-[#EAF0F7] to-[#C9D6E5] text-[#243B55]">
                <tr><th className="border-r border-b border-[#7A96B4] px-2 py-[3px] text-center">Descripción</th><th className="border-b border-[#7A96B4] px-2 py-[3px] text-center">Correo</th></tr>
              </thead>
            </table>
          </div>
          <label className="text-right pt-1 font-bold">Asunto :</label><input className={inp} />
          <label className="text-right pt-1 font-bold">Mensaje :</label><textarea className={`${inp} h-24 py-1`} />
          <label className="text-right pt-1 font-bold">Publicidad :</label>
          <div className="flex gap-1">
            <input className={`${inp} flex-1`} />
            <button className={iconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
            <button className={iconBtn} title="Ver"><FileDown className="h-3.5 w-3.5" /></button>
            <button className={iconBtn} title="Limpiar"><Trash2 className="h-3.5 w-3.5" /></button>
          </div>
          <label className="text-right pt-1 font-bold">Adjuntos :</label>
          <div className="border border-[#7A96B4] bg-white h-16 overflow-auto">
            <table className="w-full text-[11.5px]">
              <thead className="bg-gradient-to-b from-[#EAF0F7] to-[#C9D6E5] text-[#243B55]">
                <tr><th className="border-r border-b border-[#7A96B4] px-2 py-[3px] text-center">Nombre</th><th className="border-b border-[#7A96B4] px-2 py-[3px] text-center w-28">Tamaño ( kb.)</th></tr>
              </thead>
            </table>
          </div>
        </div>
        <div className="flex justify-end gap-2 pt-2">
          <button className={btnPrimary}><Send className="h-3.5 w-3.5" />Enviar Correo</button>
          <button className={btn}><X className="h-3.5 w-3.5" />Cancelar</button>
        </div>
      </div>
    </WindowShell>
  );
}

// ---------- Clientes / Requisiciones ----------
function Cartera() {
  return (
    <ListQueryForm
      title="Cartera de Clientes"
      toolbar={stdToolbar10}
      filters={
        <SearchBar>
          <Field label="Código" className="w-28"><input className={`${inp} font-mono`} /></Field>
          <Field label="Cliente" className="w-64"><input className={inp} defaultValue="(Todos)" /></Field>
          <Field label="Grupo" className="w-40"><select className={inp}><option>(Todos)</option><option>MINERÍA</option><option>COMERCIAL</option><option>SERVICIOS</option></select></Field>
          <Field label="Vendedor" className="w-44"><select className={inp}><option>(Todos)</option><option>VENDEDOR 01</option><option>VENDEDOR 02</option></select></Field>
          <Field label="Estado" className="w-28"><select className={inp}><option>ACTIVO</option><option>INACTIVO</option><option>(Todos)</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Código", "RUC", "Razón Social", "Grupo Ventas", "Vendedor", "Cond. Pago", "Límite Crédito", "Estado", "F.Actualización"]}
      rows={0}
    />
  );
}

function Despacho() {
  return (
    <ListQueryForm
      title="Despachos"
      toolbar={stdToolbarAlmacen}
      extraTop={
        <div className="mx-1.5 mt-1.5 grid grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Pendientes:</span> <b className="font-mono text-slate-900">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">En ruta:</span> <b className="font-mono text-slate-900">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Finalizados:</span> <b className="font-mono text-slate-900">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Anulados:</span> <b className="font-mono text-slate-900">0</b></div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Fecha Inicio" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Fecha Fin" className="w-32"><input className={inp} type="date" defaultValue="2026-07-21" /></Field>
          <Field label="Chofer" className="w-56"><input className={inp} defaultValue="(Todos)" /></Field>
          <Field label="Placa" className="w-28"><input className={`${inp} font-mono`} defaultValue="" /></Field>
          <Field label="Estado" className="w-24"><select className={inp}><option>(Todos)</option><option>GENERADO</option><option>EN RUTA</option><option>FINALIZADO</option><option>ANULADO</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Número", "Fecha", "Hora Salida", "Hora Retorno", "Chofer", "Placa", "Destino", "Observación", "Estado"]}
      rows={0}
    />
  );
}

function DocSalidas() {
  return (
    <ListQueryForm
      title="Movimiento de Salidas Almacén"
      toolbar={stdToolbarAlmacen}
      extraTop={
        <div className="mx-1.5 mt-1.5 grid grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Generados:</span> <b className="font-mono text-slate-900">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Entregados:</span> <b className="font-mono text-emerald-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Anulados:</span> <b className="font-mono text-red-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Total S/:</span> <b className="font-mono text-slate-900">0.00</b></div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Año" className="w-14"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
          <Field label="Mes" className="w-20"><select className={inp} defaultValue="JULIO"><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
          <Field label="Oficina" className="w-24"><select className={inp}><option>LIMA</option><option>AREQUIPA</option><option>TRUJILLO</option></select></Field>
          <Field label="Almacén" className="w-28"><select className={inp}><option>COMERCIAL</option><option>REPUESTOS</option><option>SERVICIOS</option></select></Field>
          <Field label="Tipo Documento" className="w-32"><select className={inp}><option>(Todos)</option><option>Factura Venta</option><option>Guía Interna</option><option>Nota de Salida</option></select></Field>
          <Field label="Cliente" className="w-56">
            <div className="flex gap-1">
              <input className={`${inp} flex-1`} defaultValue="(Todos)" />
              <button className={iconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
            </div>
          </Field>
          <Field label="Estado" className="w-24"><select className={inp}><option>(Todos)</option><option>GENERADO</option><option>ANULADO</option><option>ENTREGADO</option></select></Field>
          <Field label="Número" className="w-20"><input className={`${inp} font-mono`} /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Número", "T.Doc.", "Fecha", "# OT", "Cliente", "Mon.", "Total", "Estado", "Acción"]}
      rows={0}
    />
  );
}

function Vales() {
  return (
    <ListQueryForm
      title="Vales"
      toolbar={stdToolbarAlmacen}
      extraTop={
        <div className="mx-1.5 mt-1.5 grid grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Pendientes:</span> <b className="font-mono text-amber-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Despachados:</span> <b className="font-mono text-emerald-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Cerrados:</span> <b className="font-mono text-slate-900">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Monto S/:</span> <b className="font-mono text-slate-900">0.00</b></div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Año" className="w-14"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
          <Field label="Mes" className="w-20"><select className={inp} defaultValue="JULIO"><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
          <Field label="Oficina" className="w-24"><select className={inp}><option>LIMA</option><option>AREQUIPA</option><option>TRUJILLO</option></select></Field>
          <Field label="Almacén" className="w-28"><select className={inp}><option>COMERCIAL</option><option>REPUESTOS</option><option>SERVICIOS</option></select></Field>
          <Field label="Tipo" className="w-32"><select className={inp}><option>Vale de Almacén</option><option>Despacho</option><option>Requisición</option></select></Field>
          <Field label="Cliente" className="w-56">
            <div className="flex gap-1">
              <input className={`${inp} flex-1`} defaultValue="(Todos)" />
              <button className={iconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
            </div>
          </Field>
          <Field label="Estado" className="w-24"><select className={inp}><option>(Todos)</option><option>GENERADO</option><option>DESPACHADO</option><option>CERRADO</option></select></Field>
          <Field label="OT" className="w-20"><input className={`${inp} font-mono`} /></Field>
          <Field label="Número" className="w-20"><input className={`${inp} font-mono`} /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Número", "OT", "Fecha", "Cliente", "Mon.", "Total", "Estado", "Prioridad", "Acción"]}
      rows={0}
    />
  );
}

function Tarjetas() {
  return (
    <ListQueryForm
      title="Tarjetas de Inventario"
      toolbar={<>
        <button className={btnPrimary}><Search className="h-3.5 w-3.5" />Buscar Tarjeta</button>
        <button className={btn}><RefreshCw className="h-3.5 w-3.5" />Refrescar</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}
      extraTop={
        <div className="mx-1.5 mt-1.5 grid grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Tarjetas:</span> <b className="font-mono text-slate-900">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Movimientos:</span> <b className="font-mono text-slate-900">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Entradas:</span> <b className="font-mono text-emerald-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Salidas:</span> <b className="font-mono text-red-700">0</b></div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Producto" className="w-64"><input className={inp} placeholder="Código o descripción" /></Field>
          <Field label="Almacén" className="w-32"><select className={inp}><option>Central Lima</option><option>Norte</option><option>Sur</option></select></Field>
          <Field label="Fecha Desde" className="w-36"><input className={inp} type="date" /></Field>
          <Field label="Fecha Hasta" className="w-36"><input className={inp} type="date" /></Field>
          <Field label="Tipo" className="w-36"><select className={inp}><option>(Todos)</option><option>Ingreso</option><option>Salida</option><option>Ajuste</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Código", "Producto", "Almacén", "Stock Inicio", "Entradas", "Salidas", "Stock Final", "Acción"]}
      rows={8}
    />
  );
}

function Calendario() {
  return (
    <ListQueryForm
      title="Calendario de Almacén"
      toolbar={<>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Actualizar</button>
        <button className={btn}><Calendar className="h-3.5 w-3.5" />Ver Mes</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}
      extraTop={
        <div className="mx-1.5 mt-1.5 grid grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Eventos:</span> <b className="font-mono text-slate-900">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Inventarios:</span> <b className="font-mono text-emerald-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Traslados:</span> <b className="font-mono text-slate-900">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Conteos:</span> <b className="font-mono text-amber-700">0</b></div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Año" className="w-20"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
          <Field label="Mes" className="w-24"><select className={inp}><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
          <Field label="Almacén" className="w-32"><select className={inp}><option>Central Lima</option><option>Norte</option><option>Sur</option></select></Field>
          <Field label="Tipo Evento" className="w-40"><select className={inp}><option>(Todos)</option><option>Inventario</option><option>Traslado</option><option>Conteo</option></select></Field>
          <Field label="Responsable" className="w-48"><input className={inp} defaultValue="(Todos)" /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Fecha", "Evento", "Almacén", "Documento", "Responsable", "Estado", "Acción"]}
      rows={6}
    />
  );
}

function ProcesarCobertura() {
  return (
    <WindowShell title="Procesar Cobertura" toolbar={<>      
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Procesar</button>
        <button className={btn}><Search className="h-3.5 w-3.5" />Ver Resultados</button>
      </>}>
      <SearchBar>
        <Field label="Año" className="w-20"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
        <Field label="Mes" className="w-24"><select className={inp}><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
        <Field label="Almacén" className="w-32"><select className={inp}><option>Central Lima</option><option>Norte</option><option>Sur</option></select></Field>
      </SearchBar>
      <div className="p-1.5"><DataTable columns={["Producto", "Stock Actual", "Stock Crítico", "Cobertura Días", "Sugerido"]} rows={8} /></div>
    </WindowShell>
  );
}

function LiquiGastos() {
  return (
    <WindowShell title="Liquidación de Gastos" toolbar={<>      
        <button className={btnPrimary}><Plus className="h-3.5 w-3.5" />Nuevo</button>
        <button className={btn}><Search className="h-3.5 w-3.5" />Buscar</button>
        <button className={btn}><RefreshCw className="h-3.5 w-3.5" />Refrescar</button>
      </>}>
      <SearchBar>
        <Field label="Año" className="w-20"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
        <Field label="Mes" className="w-24"><select className={inp}><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
        <Field label="Tipo" className="w-32"><select className={inp}><option>Gastos de Almacén</option><option>Servicios</option><option>Transporte</option></select></Field>
        <Field label="Número" className="w-28"><input className={`${inp} font-mono`} /></Field>
      </SearchBar>
      <div className="p-1.5"><DataTable columns={["Documento", "Fecha", "Proveedor", "Tipo", "Importe", "Estado"]} rows={8} /></div>
    </WindowShell>
  );
}

// ---------- Precios ----------
function PreciosManager({ initial }: { initial: string }) {
  const [tab, setTab] = useState(initial);
  const tabs = ["Precios Cliente", "Precio Oferta", "Factores Rubros", "Precio Lista", "Precio Fabricantes"];
  return (
    <WindowShell title="Gestor Maestro de Precios y Tarifas"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar cambios</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Nuevo</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Importar Excel</button>
      </>}>
      <div className="flex gap-0.5 border-b border-slate-400/60 -mx-3 px-3">
        {tabs.map(t => (
          <button key={t} onClick={() => setTab(t)} className={[
            "px-3 py-1 text-[11.5px] rounded-t border-x border-t",
            tab === t ? "bg-white border-slate-400/60 text-[#2A3F55] font-semibold -mb-px" : "bg-transparent border-transparent text-slate-600 hover:bg-white/60",
          ].join(" ")}>{t}</button>
        ))}
      </div>
      <div className="mt-3">
        <div className="text-[11px] text-slate-600 mb-2">Editando: <b className="text-[#2A3F55]">{tab}</b></div>
        {tab === "Factores Rubros"
          ? <DataTable columns={["Rubro", "Margen %", "Descuento Máx %", "Vigencia"]} rows={6} />
          : <DataTable columns={["Código", "Producto", "Rubro", "Costo", "Precio", "Margen %", "Moneda", "Vigencia"]} rows={8} />}
      </div>
    </WindowShell>
  );
}

// ---------- Ventanas de Precios (ListingBrowser basados en stdToolbar) ----------
function PrecioCliente() {
  return (
    <ListQueryForm
      title="Precios por Cliente"
      toolbar={stdToolbar3}
      extraTop={
        <div className="mx-1.5 mt-1.5 grid grid-cols-3 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Vigentes:</span> <b className="font-mono text-slate-900">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Por vencer:</span> <b className="font-mono text-slate-900">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Vencidos:</span> <b className="font-mono text-slate-900">0</b></div>
        </div>
      }
      filters={(
        <SearchBar>
          <Field label="Cliente" className="w-64">
            <div className="flex gap-1">
              <input className={`${inp} flex-1`} defaultValue="(Todos)" />
              <button className={iconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
            </div>
          </Field>
          <Field label="Estado" className="w-36"><select className={inp}><option>(Todos)</option><option>Generado</option><option>Vigente</option><option>Vencido</option></select></Field>
          <Field label="N° Contrato" className="w-40"><input className={inp} /></Field>
          <Field label="Moneda" className="w-24"><select className={inp}><option>(Todos)</option><option>PEN</option><option>USD</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      )}
      columns={["Cód.", "Cliente", "N° Contrato", "Lista", "Mon.", "Observación", "Estado", "Fec. Inicio", "Fec. Venc."]}
      rows={0}
    />
  );
}

function PrecioOferta() {
  return (
    <ListQueryForm
      title="Precios de Oferta"
      toolbar={stdToolbar4}
      filters={(
        <SearchBar>
          <Field label="Estado" className="w-40"><select className={inp}><option>(Todos)</option><option>Vigente</option><option>Expirado</option><option>Programado</option></select></Field>
          <Field label="Rubro" className="w-44"><select className={inp}><option>(Todos)</option><option>REPUESTOS</option><option>SERVICIOS</option><option>LUBRICANTES</option></select></Field>
          <Field label="Buscar" className="w-64"><input className={inp} /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      )}
      columns={["Cód.", "Nombre", "Rubro", "Moneda", "Precio Oferta", "Observación", "Fec. Venc.", "Estado"]}
      rows={0}
    />
  );
}

function FactoresRubros() {
  return (
    <ListQueryForm
      title="Factores por Rubro"
      toolbar={stdToolbar5}
      filters={(
        <SearchBar>
          <Field label="Rubro" className="w-64"><input className={inp} /></Field>
          <Field label="Estado" className="w-28"><select className={inp}><option>(Todos)</option><option>ACTIVO</option><option>INACTIVO</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      )}
      columns={["Código", "Rubro", "Abrev.", "Fac. Costo", "Fac. Venta", "Dscto Máx", "Estado"]}
      rows={0}
    />
  );
}

function PrecioLista() {
  return (
    <ListQueryForm
      title="Listas de Precios"
      toolbar={stdToolbar6}
      filters={(
        <SearchBar>
          <Field label="Lista Precio" className="w-56"><select className={inp}><option>(Todos)</option><option>LISTA GENERAL</option><option>LISTA MAYORISTA</option></select></Field>
          <Field label="Estado" className="w-36"><select className={inp}><option>(Todos)</option><option>Vigente</option><option>No vigente</option></select></Field>
          <Field label="Moneda" className="w-24"><select className={inp}><option>(Todos)</option><option>PEN</option><option>USD</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      )}
      columns={["Cód.", "Nombre", "Moneda", "Observación", "Fec. Inicio", "Fec. Venc.", "Vigente"]}
      rows={0}
    />
  );
}

function PrecioFabricantes() {
  return (
    <ListQueryForm
      title="Precios de Fabricantes"
      toolbar={stdToolbar7}
      filters={(
        <SearchBar>
          <Field label="Fabricante" className="w-56"><input className={inp} defaultValue="(Todos)" /></Field>
          <Field label="Lista Precio" className="w-56"><select className={inp}><option>(Todos)</option><option>FABRICANTE A</option><option>FABRICANTE B</option></select></Field>
          <Field label="Estado" className="w-36"><select className={inp}><option>(Todos)</option><option>Vigente</option><option>No vigente</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      )}
      columns={["Fabricante", "Lista", "Mon.", "Observación", "Fec. Inicio", "Fec. Venc.", "Vigente"]}
      rows={0}
    />
  );
}

// ---------- Registro de Ventas (3 ventanas) ----------
function RegistroVenta() {
  return (
    <WindowShell title="Registro de Ventas">
      <div className="w-full h-full p-4 overflow-auto flex flex-col">
        <div className="space-y-3">
        {/* Ventas Section */}
        <Fs legend="Ventas">
          <div className="space-y-2">
            <div className="flex items-center gap-2">
              <span className="text-[11px] text-slate-600 w-12">Desde :</span>
              <input className={inp} type="date" defaultValue="2026-08-01" />
            </div>
            <div className="flex items-center gap-2">
              <span className="text-[11px] text-slate-600 w-12">Hasta :</span>
              <input className={inp} type="date" defaultValue="2026-08-07" />
            </div>
          </div>
          <div className="mt-3 pt-3 border-t border-slate-200">
            <div className="text-[11px] text-slate-600 font-semibold mb-2">Impresión</div>
            <div className="grid grid-cols-2 gap-4">
              <div className="flex flex-col gap-1.5">
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="impresion_pagina" defaultChecked className="accent-[#2A5590]" />
                  <span className="text-[11px] text-slate-700">Con Página</span>
                </label>
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="impresion_pagina" className="accent-[#2A5590]" />
                  <span className="text-[11px] text-slate-700">Sin Página</span>
                </label>
              </div>
              <div className="flex flex-col gap-1.5">
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="impresion_celdas" defaultChecked className="accent-[#2A5590]" />
                  <span className="text-[11px] text-slate-700">Con Celdas</span>
                </label>
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="impresion_celdas" className="accent-[#2A5590]" />
                  <span className="text-[11px] text-slate-700">Sin Celdas</span>
                </label>
              </div>
            </div>
          </div>
        </Fs>

        {/* Buscar Cliente Section */}
        <Fs legend="Buscar Cliente">
          <label className="flex items-center gap-2 mb-2">
            <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
            <span className="text-[11px] text-slate-700 font-semibold">Todo Cliente</span>
          </label>
          <div className="space-y-1">
            <span className="text-[11px] text-slate-600">Cliente</span>
            <div className="flex gap-1">
              <input className={`${inp} flex-1`} />
              <button className={iconBtn}><Search className="h-3.5 w-3.5" /></button>
            </div>
          </div>
        </Fs>

        {/* Por Documento Section */}
        <Fs legend="Por Documento">
          <div className="space-y-1">
            <span className="text-[11px] text-slate-600">Documento</span>
            <select className={inp}><option>(Todos)</option></select>
          </div>
        </Fs>

        {/* Moneda, Formato, Exportar in Grid */}
        <div className="grid grid-cols-3 gap-2">
          <Fs legend="Moneda">
            <div className="flex flex-col gap-1.5">
              <label className="inline-flex items-center gap-2">
                <input type="radio" name="moneda_reg" defaultChecked className="accent-[#2A5590]" />
                <span className="text-[11px] text-slate-700">En Soles</span>
              </label>
              <label className="inline-flex items-center gap-2">
                <input type="radio" name="moneda_reg" className="accent-[#2A5590]" />
                <span className="text-[11px] text-slate-700">En Dólares</span>
              </label>
            </div>
          </Fs>
          <Fs legend="Formato">
            <div className="flex flex-col gap-1.5">
              <label className="inline-flex items-center gap-2">
                <input type="radio" name="formato_reg" defaultChecked className="accent-[#2A5590]" />
                <span className="text-[11px] text-slate-700">Antiguo</span>
              </label>
              <label className="inline-flex items-center gap-2">
                <input type="radio" name="formato_reg" className="accent-[#2A5590]" />
                <span className="text-[11px] text-slate-700">Nuevo</span>
              </label>
            </div>
          </Fs>
          <Fs legend="Exportar">
            <div className="flex flex-col gap-1.5">
              <label className="inline-flex items-center gap-2">
                <input type="radio" name="exportar_reg" defaultChecked className="accent-[#2A5590]" />
                <span className="text-[11px] text-slate-700">Pantalla</span>
              </label>
              <label className="inline-flex items-center gap-2">
                <input type="radio" name="exportar_reg" className="accent-[#2A5590]" />
                <span className="text-[11px] text-slate-700">Excel</span>
              </label>
            </div>
          </Fs>
        </div>

        {/* Buttons */}
        <div className="flex justify-end gap-2 pt-2 border-t border-slate-200 mt-4">
          <button className={btn}>Cancelar</button>
          <button className={btnPrimary}>Aceptar</button>
        </div>
        </div>
      </div>
    </WindowShell>
  );
}

function RegistroAuxiliar() {
  return (
    <WindowShell title="Registro Auxiliar de Ventas">
      <div className="max-w-[520px] mx-auto p-3 space-y-3">
        <Fs legend="Fechas">
          <div className="grid grid-cols-[auto_auto_auto_auto] items-center gap-2">
            <span className="text-[11px] font-semibold text-slate-700">Del :</span>
            <input className={inp} type="date" defaultValue="2026-08-01" />
            <span className="text-[11px] font-semibold text-slate-700">Al</span>
            <input className={inp} type="date" defaultValue="2026-08-07" />
          </div>
        </Fs>

        <div className="grid grid-cols-[1fr_1.2fr] gap-3">
          <div className="space-y-3">
            <Field label="Oficina" className="w-full">
              <select className={inp}>
                <option>LIMA</option>
                <option>AREQUIPA</option>
                <option>TRUJILLO</option>
              </select>
            </Field>

            <Fs legend="Moneda">
              <div className="flex flex-col gap-2">
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="moneda_aux" defaultChecked className="accent-[#2A5590]" />
                  <span className="text-[12px] text-slate-700">En Soles</span>
                </label>
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="moneda_aux" className="accent-[#2A5590]" />
                  <span className="text-[12px] text-slate-700">En Dólares</span>
                </label>
              </div>
            </Fs>
          </div>

          <Fs legend="Departamento">
            <div className="flex flex-col gap-1">
              {[
                'Repuestos',
                'Baterías',
                'Filtros',
                'Servicios',
                'Motores',
                'Mercadería sin movimiento',
                'Consignación',
                'Notas de Débito',
                'Transferencia gratuita',
                'Back Office',
                'Proyectos Nuevos',
              ].map((dep) => (
                <label key={dep} className="inline-flex items-center gap-2">
                  <input type="radio" name="dep_aux" className="accent-[#2A5590]" />
                  <span className="text-[12px] text-slate-700">{dep}</span>
                </label>
              ))}
            </div>
          </Fs>
        </div>

        <div className="flex justify-end gap-2 pt-2 border-t border-slate-200">
          <button className={btnPrimary}>Aceptar</button>
          <button className={btn}>Cancelar</button>
        </div>
      </div>
    </WindowShell>
  );
}

function ResumenRegistro() {
  return (
    <WindowShell title="Resumen de Registro de Ventas">
      <div className="max-w-2xl mx-auto p-3 space-y-3">
        <div className="flex items-end gap-3">
          <div className="flex-1 space-y-1">
            <label className="text-[11px] font-semibold text-slate-700">Fechas</label>
            <div className="flex gap-2 items-center">
              <div className="flex items-center gap-1">
                <span className="text-[11px] text-slate-700">Del :</span>
                <input className={inp} type="date" defaultValue="2026-08-01" />
              </div>
              <div className="flex items-center gap-1">
                <span className="text-[11px] text-slate-700">Al</span>
                <input className={inp} type="date" defaultValue="2026-08-08" />
              </div>
            </div>
          </div>
        </div>

        <Fs legend="Buscar Cliente">
          <label className="flex items-center gap-2">
            <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
            <span className="text-[12px] text-slate-700">Todo Cliente</span>
          </label>
          <Field label="Cliente" className="w-full">
            <div className="flex gap-1">
              <input className={`${inp} flex-1`} />
              <button className={iconBtn}>
                <Search className="h-3.5 w-3.5" />
              </button>
            </div>
          </Field>
        </Fs>

        <div className="grid grid-cols-2 gap-3">
          <Fs legend="Tipo">
            <div className="flex flex-col gap-1">
              <label className="inline-flex items-center gap-2">
                <input type="radio" name="tipo_res" defaultChecked className="accent-[#2A5590]" />
                <span className="text-[12px] text-slate-700">Ventas</span>
              </label>
              <label className="inline-flex items-center gap-2">
                <input type="radio" name="tipo_res" className="accent-[#2A5590]" />
                <span className="text-[12px] text-slate-700">Exportación</span>
              </label>
              <label className="inline-flex items-center gap-2">
                <input type="radio" name="tipo_res" className="accent-[#2A5590]" />
                <span className="text-[12px] text-slate-700">Trans. Gratuitas</span>
              </label>
              <label className="inline-flex items-center gap-2">
                <input type="radio" name="tipo_res" className="accent-[#2A5590]" />
                <span className="text-[12px] text-slate-700">Agrupado por Cliente</span>
              </label>
            </div>
          </Fs>

          <Fs legend="Exportar">
            <div className="flex flex-col gap-1">
              <label className="inline-flex items-center gap-2">
                <input type="radio" name="exp_res" defaultChecked className="accent-[#2A5590]" />
                <span className="text-[12px] text-slate-700">Pantalla</span>
              </label>
              <label className="inline-flex items-center gap-2">
                <input type="radio" name="exp_res" className="accent-[#2A5590]" />
                <span className="text-[12px] text-slate-700">Excel</span>
              </label>
            </div>
          </Fs>
        </div>

        <div className="flex justify-end gap-2 pt-2 border-t border-slate-200">
          <button className={btnPrimary}>Aceptar</button>
          <button className={btn}>Cancelar</button>
        </div>
      </div>
    </WindowShell>
  );
}


// ---------- Reportes del Menú Reportes ----------
function ReporteAcumulada() {
  return (
    <WindowShell title="Reporte de Ventas Acumuladas">
      <div className="p-3 space-y-3 max-w-5xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Rango de Fechas">
          <div className="grid grid-cols-1 gap-2 sm:grid-cols-2">
            <Field label="Del">
              <input className={`${inp} w-40`} type="date" defaultValue="2026-08-01" />
            </Field>
            <Field label="Al">
              <input className={`${inp} w-40`} type="date" defaultValue="2026-08-08" />
            </Field>
          </div>
        </Fs>

        <div className="grid grid-cols-1 gap-2 sm:grid-cols-2">
          <Field label="Oficina">
            <select className={inp}><option>(Todos)</option></select>
          </Field>
          <Field label="Almacén">
            <select className={inp}><option>(Todos)</option></select>
          </Field>
        </div>

        <div className="grid grid-cols-1 gap-2 sm:grid-cols-2">
          <Field label="Rubro">
            <select className={inp}><option>(Todos)</option></select>
          </Field>
          <Field label="Motivo">
            <select className={inp}><option>(Todos)</option></select>
          </Field>
        </div>

        <Field label="Vendedor">
          <select className={inp}><option>(Todos)</option></select>
        </Field>

        <div className="grid grid-cols-1 gap-2 lg:grid-cols-[1.6fr_1fr_1fr_0.95fr]">
          <div className="h-full">
            <Fs legend="Acumulado X">
              <div className="flex flex-col gap-1">
                <Radio name="acum" label="Mercadería" defaultChecked />
                <Radio name="acum" label="Cliente" />
                <Radio name="acum" label="Año" />
                <Radio name="acum" label="Cantidades Vendidas" />
              </div>
            </Fs>
          </div>

          <div className="h-full">
            <Fs legend="Ordenado X">
              <div className="flex flex-col gap-1">
                <Radio name="ord" label="Descripción" defaultChecked />
                <Radio name="ord" label="Dólares" />
                <Radio name="ord" label="Soles" />
              </div>
            </Fs>
          </div>

          <div className="h-full">
            <Fs legend="Buscar Marca">
              <label className="inline-flex items-center gap-2">
                <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
                <span>Buscar Marca</span>
              </label>
              <div className="mt-2 flex items-center gap-1 min-w-0">
                <input className={`${inp} flex-1 min-w-0`} />
                <button className={iconBtn}><Search className="h-3.5 w-3.5" /></button>
              </div>
            </Fs>
          </div>

          <div className="h-full">
            <Fs legend="Tipo Orden">
              <div className="flex flex-col gap-1">
                <Radio name="tipo_orden" label="Ascendente" defaultChecked />
                <Radio name="tipo_orden" label="Descendente" />
              </div>
            </Fs>
          </div>
        </div>

        <Fs legend="Exportar">
          <div className="flex flex-col gap-2">
            <label className="inline-flex items-center gap-2">
              <input type="radio" name="export" defaultChecked className="accent-[#2A5590]" />
              <span>Pantalla</span>
            </label>
            <label className="inline-flex items-center gap-2">
              <input type="radio" name="export" className="accent-[#2A5590]" />
              <span>Excel</span>
            </label>
          </div>
        </Fs>

        <div className="flex justify-center gap-2 pt-2 border-t border-slate-200">
          <button className={btnPrimary}>Aceptar</button>
          <button className={btn}>Cancelar</button>
        </div>
      </div>
    </WindowShell>
  );
}

function ReporteGuias() {
  return (
    <WindowShell title="Reporte de Guías de Venta y Guías no Facturadas"
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Generar</button>
      </>}
    >
      <div className="p-3 space-y-2 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Fechas">
          <Field label="Del"><input className={inp} type="date" defaultValue="2026-01-07" /></Field>
          <Field label="Al"><input className={inp} type="date" defaultValue="2026-07-21" /></Field>
        </Fs>
        <div className="grid grid-cols-2 gap-2">
          <Fs legend="Localización"><div className="flex gap-3"><label className="flex items-center gap-1"><input type="radio" name="loc" defaultChecked className="accent-[#2A5590]" />Todos</label><label className="flex items-center gap-1"><input type="radio" name="loc" className="accent-[#2A5590]" />Uno</label></div><Field label="Oficina"><select className={inp}><option>LIMA</option></select></Field><Field label="Almacén"><select className={inp}><option>COMERCIAL</option></select></Field></Fs>
          <Fs legend="Facturado"><div className="flex flex-col gap-1"><Radio name="fact" label="Pendientes de Facturación" defaultChecked /><Radio name="fact" label="Todos" /></div></Fs>
        </div>
        <Fs legend="Buscar Cliente">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Cliente</label>
          <Field label="Cliente"><div className="flex gap-1"><input className={`${inp} flex-1`} /><button className={iconBtn}><Search className="h-3.5 w-3.5" /></button></div></Field>
        </Fs>
        <Fs legend="Buscar Por Vendedor">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Vendedor</label>
          <Field label="Vendedor"><select className={inp}><option>(Todos)</option></select></Field>
        </Fs>
        <div className="grid grid-cols-2 gap-2">
          <Fs legend="Tipo Reporte"><div className="flex flex-col gap-1"><Radio name="tipo" label="Reporte de Guías" defaultChecked /><Radio name="tipo" label="Reporte de G/R Por Fecha de Proceso" /></div></Fs>
          <Fs legend="Motivo"><Field label=""><select className={inp}><option>(Todos)</option></select></Field></Fs>
        </div>
        <DataTable columns={["Fecha", "G/R", "Cliente", "Oficina", "Almacén", "Total Soles"]} rows={5} />
        <div className="mt-2 flex justify-end gap-2"><button className={btn}>Cancelar</button><button className={btnPrimary}>Aceptar</button></div>
      </div>
    </WindowShell>
  );
}

function ReporteCotizaciones() {
  return (
    <WindowShell title="Cotizaciones"
    >
      <div className="p-3 space-y-3 max-w-2xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Rango de Fechas">
          <Field label="Del"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Al"><input className={inp} type="date" defaultValue="2026-07-21" /></Field>
        </Fs>

        <div className="grid grid-cols-2 gap-3">
          <Field label="Oficina"><select className={inp}><option>(Todos)</option></select></Field>
          <Field label="Almacén"><select className={inp}><option>(Todos)</option></select></Field>
        </div>

        <Fs legend="Buscar Cliente">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Cliente</label>
          <Field label="Cliente"><div className="flex gap-1"><input className={`${inp} flex-1`} /><button className={iconBtn}><Search className="h-3.5 w-3.5" /></button></div></Field>
        </Fs>

        <Fs legend="Buscar Vendedor">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Vendedor</label>
          <Field label="Vendedor"><select className={inp}><option>(Todos)</option></select></Field>
        </Fs>

        <div className="grid grid-cols-[1.3fr_0.9fr] gap-3">
          <Fs legend="Opciones">
            <Field label="Estado"><select className={inp}><option>(Todos)</option><option>Generados</option><option>Vencidos</option><option>Atendidos</option><option>Rechazados</option></select></Field>
            <Field label="Tipo de Rechazo"><select className={inp}><option>(Todos)</option></select></Field>
          </Fs>
          <Fs legend="Mostrar">
            <div className="flex flex-col gap-1 text-[11px] text-slate-800">
              <label className="inline-flex items-center gap-2"><input type="radio" name="cot_op" defaultChecked className="accent-[#2A5590]" />Todos</label>
              <label className="inline-flex items-center gap-2"><input type="radio" name="cot_op" className="accent-[#2A5590]" />Generados</label>
              <label className="inline-flex items-center gap-2"><input type="radio" name="cot_op" className="accent-[#2A5590]" />Vencidos</label>
              <label className="inline-flex items-center gap-2"><input type="radio" name="cot_op" className="accent-[#2A5590]" />Atendidos</label>
              <label className="inline-flex items-center gap-2"><input type="radio" name="cot_op" className="accent-[#2A5590]" />Rechazados</label>
            </div>
          </Fs>
        </div>

        <div className="mt-2 flex justify-end gap-2"><button className={btn}>Cancelar</button><button className={btnPrimary}>Aceptar</button></div>
      </div>
    </WindowShell>
  );
}

function ReporteValeRequisicion() {
  return (
    <WindowShell title="Vales de Requisiciones"
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Generar</button>
      </>}
    >
      <div className="p-3 space-y-2 max-w-2xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Rango de fechas">
          <Field label="Del"><input className={inp} type="date" defaultValue="2026-01-07" /></Field>
          <Field label="Al"><input className={inp} type="date" defaultValue="2026-07-21" /></Field>
        </Fs>
        <div className="grid grid-cols-2 gap-2">
          <Fs legend="Localización"><Field label="Oficina"><select className={inp}><option>LIMA</option></select></Field></Fs>
          <Fs legend="Almacén"><Field label=""><select className={inp}><option>COMERCIAL</option></select></Field></Fs>
        </div>
        <Fs legend="Estado">
          <Field label=""><select className={inp}><option>(Todos)</option></select></Field>
          <Field label="Rubro"><select className={inp}><option>(Todos)</option></select></Field>
        </Fs>
        <Fs legend="Exportar"><div className="flex flex-col gap-1"><Radio name="exp" label="Pantalla" defaultChecked /><Radio name="exp" label="Exportar" /></div></Fs>
        <DataTable columns={["Fecha", "Vale", "Concepto", "Cantidad", "Estado", "Ofic."]} rows={5} />
        <div className="mt-2 flex justify-end gap-2"><button className={btn}>Cancelar</button><button className={btnPrimary}>Aceptar</button></div>
      </div>
    </WindowShell>
  );
}

function ReporteMensualCliente() {
  return (
    <WindowShell title="Reporte de Ventas Mensuales por Cliente"
    >
      <div className="p-3 space-y-3 max-w-2xl mx-auto text-[11.5px] text-slate-800">
        <div className="grid grid-cols-[auto_1fr_auto_1fr] items-center gap-x-2 gap-y-2">
          <div className="text-right font-medium">Del :</div>
          <div><input className={inp} type="date" defaultValue="2026-08-01" /></div>
          <div className="text-right font-medium">Al :</div>
          <div><input className={inp} type="date" defaultValue="2026-08-08" /></div>
        </div>

        <div className="grid grid-cols-3 gap-2">
          <Field label="Oficina"><select className={inp}><option>(Todos)</option></select></Field>
          <Field label="Almacén"><select className={inp}><option>(Todos)</option></select></Field>
          <Field label="Rubro"><select className={inp}><option>(Todos)</option></select></Field>
        </div>

        <Fs legend="Buscar Por Vendedor">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Vendedor</label>
          <Field label="Vendedor"><select className={inp}><option>(Todos)</option></select></Field>
        </Fs>

        <Field label="Sector"><select className={inp}><option>(Todos)</option></select></Field>

        <Fs legend="Reporte">
          <div className="flex flex-col gap-1">
            <Radio name="reporte" label="Detalle" defaultChecked />
            <Radio name="reporte" label="Resumen" />
          </div>
        </Fs>

        <div className="grid grid-cols-3 gap-3">
          <Fs legend="Ordenado X">
            <div className="flex flex-col gap-1">
              <Radio name="orden_x" label="Cliente" defaultChecked />
              <Radio name="orden_x" label="Total Venta" />
            </div>
          </Fs>
          <Fs legend="Tipo de Orden">
            <div className="flex flex-col gap-1">
              <Radio name="tipo_orden" label="Ascendente" defaultChecked />
              <Radio name="tipo_orden" label="Descendente" />
            </div>
          </Fs>
          <Fs legend="Moneda">
            <div className="flex flex-col gap-1">
              <Radio name="moneda" label="En Soles" defaultChecked />
              <Radio name="moneda" label="En Dólares" />
            </div>
          </Fs>
        </div>

        <div className="mt-2 flex justify-center gap-2"><button className={btnPrimary}>Aceptar</button><button className={btn}>Cancelar</button></div>
      </div>
    </WindowShell>
  );
}

function ReporteDetalleDescuento() {
  return (
    <WindowShell title="Reporte de Venta Detallado con Descuento"
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Generar</button>
      </>}
    >
      <div className="p-3 space-y-3 max-w-2xl mx-auto text-[11.5px] text-slate-800">
        <div className="grid grid-cols-[auto_1fr_auto_1fr] items-center gap-x-2 gap-y-2">
          <div className="text-right font-medium">Fechas</div>
          <div className="grid grid-cols-[auto_1fr] gap-2 items-center">
            <span className="text-right">Del :</span>
            <input className={inp} type="date" defaultValue="2026-08-01" />
          </div>
          <div className="text-right">Al</div>
          <div><input className={inp} type="date" defaultValue="2026-08-08" /></div>
        </div>

        <div className="grid grid-cols-2 gap-3">
          <Fs legend="Localización">
            <Field label="Oficina"><select className={inp}><option>(Todos)</option></select></Field>
            <Field label="Almacén"><select className={inp}><option>(Todos)</option></select></Field>
          </Fs>
          <div />
        </div>

        <Fs legend="Buscar Por Vendedor">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Vendedor</label>
          <Field label="Vendedor"><select className={inp}><option>(Todos)</option></select></Field>
        </Fs>

        <Fs legend="Buscar Cliente">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Cliente</label>
          <Field label="Cliente"><div className="flex gap-1"><input className={`${inp} flex-1`} /><button className={iconBtn}><Search className="h-3.5 w-3.5" /></button></div></Field>
        </Fs>

        <div className="grid grid-cols-2 gap-3">
          <Fs legend="Buscar Mercadería">
            <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Toda Mercadería</label>
            <Field label=""><div className="flex gap-1"><input className={`${inp} flex-1`} /><button className={iconBtn}><Search className="h-3.5 w-3.5" /></button></div></Field>
          </Fs>
          <Fs legend="Imprimir">
            <div className="flex flex-col gap-1">
              <Radio name="imp" label="Pantalla" defaultChecked />
              <Radio name="imp" label="Exportar" />
            </div>
          </Fs>
        </div>

        <div className="mt-2 flex justify-center gap-2"><button className={btnPrimary}>Aceptar</button><button className={btn}>Cancelar</button></div>
      </div>
    </WindowShell>
  );
}

function ReporteReclamos() {
  return (
    <WindowShell title="Reporte de Reclamos"
    >
      <div className="p-3 space-y-3 max-w-sm mx-auto text-[11.5px] text-slate-800">
        <div className="grid grid-cols-[auto_1fr_auto_1fr] items-center gap-x-2 gap-y-2">
          <div className="text-right font-medium">Del :</div>
          <div><input className={inp} type="date" defaultValue="2026-08-01" /></div>
          <div className="text-right">Al</div>
          <div><input className={inp} type="date" defaultValue="2026-08-08" /></div>
        </div>

        <Field label="Oficina"><select className={inp}><option>LIMA</option></select></Field>
        <Field label="Almacén"><select className={inp}><option>COMERCIAL</option></select></Field>
        <Field label="Estado :"><select className={inp}><option>(Todos)</option></select></Field>

        <Fs legend="Buscar Cliente">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Cliente</label>
          <Field label="Cliente"><div className="flex gap-1"><input className={`${inp} flex-1`} /><button className={iconBtn}><Search className="h-3.5 w-3.5" /></button></div></Field>
        </Fs>

        <div className="mt-2 flex justify-center gap-2"><button className={btnPrimary}>Aceptar</button><button className={btn}>Cancelar</button></div>
      </div>
    </WindowShell>
  );
}

function ReporteOrdenCompra() {
  return (
    <WindowShell title="Reporte de Orden de Compra"
    >
      <div className="p-3 space-y-3 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        {/* Dos columnas: izquierda filtros, derecha Tipo */}
        <div className="grid grid-cols-[1.2fr_1fr] gap-4">
          {/* Columna Izquierda */}
          <div className="space-y-2">
            <div className="grid grid-cols-[auto_1fr_auto_1fr] items-center gap-x-2 gap-y-1">
              <div className="font-medium">Fechas</div>
              <div></div>
              <div className="text-right">Del :</div>
              <input className={inp} type="date" defaultValue="2026-08-01" />
              <div></div>
              <div></div>
              <div className="text-right">Al :</div>
              <input className={inp} type="date" defaultValue="2026-08-08" />
            </div>
            <Field label="Oficina :"><select className={inp}><option>LIMA</option></select></Field>
            <Field label="Almacén :"><select className={inp}><option>COMERCIAL</option></select></Field>
            <Field label="Estados :"><select className={inp}><option>(Todos)</option></select></Field>
            <Field label="Rubros :"><select className={inp}><option>(Todos)</option></select></Field>
          </div>

          {/* Columna Derecha - Tipo */}
          <Fs legend="Tipo">
            <div className="space-y-2">
              <Radio name="tipo" label="Totalizado" defaultChecked />
              <div className="space-y-1">
                <Radio name="tipo" label="Detallado" />
                <div className="ml-6 space-y-1">
                  <div className="text-[11px] font-medium">Condición</div>
                  <Radio name="cond" label="Separado" />
                  <Radio name="cond" label="Todos" />
                </div>
              </div>
              <Radio name="tipo" label="Atendidos" />
            </div>
          </Fs>
        </div>

        {/* Secciones de búsqueda - full width */}
        <Fs legend="Buscar Mercadería">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Mercadería</label>
          <Field label="Mercadería"><div className="flex gap-1"><input className={`${inp} flex-1`} /><button className={iconBtn}><Search className="h-3.5 w-3.5" /></button></div></Field>
        </Fs>

        <Fs legend="Buscar Cliente">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Cliente</label>
          <Field label="Cliente"><div className="flex gap-1"><input className={`${inp} flex-1`} /><button className={iconBtn}><Search className="h-3.5 w-3.5" /></button></div></Field>
        </Fs>

        <Fs legend="Buscar Vendedor">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Vendedor</label>
          <Field label="Vendedor"><select className={inp}><option>(Todos)</option></select></Field>
        </Fs>

        <Fs legend="Exportar">
          <div className="flex gap-3"><Radio name="exp" label="Pantalla" defaultChecked /><Radio name="exp" label="Excel" /></div>
        </Fs>

        <div className="mt-2 flex justify-center gap-2"><button className={btnPrimary}>Aceptar</button><button className={btn}>Cancelar</button></div>
      </div>
    </WindowShell>
  );
}

function ReporteConsignacion() {
  return (
    <WindowShell title="Consignación"
    >
      <div className="p-3 space-y-2 max-w-2xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Fechas">
          <Field label="Del"><input className={inp} type="date" defaultValue="2026-01-07" /></Field>
          <Field label="Al"><input className={inp} type="date" defaultValue="2026-07-21" /></Field>
        </Fs>
        <Fs legend="Búsqueda Rápida">
          <Field label="Oficina"><select className={inp}><option>(Todos)</option></select></Field>
          <Field label="Almacén"><select className={inp}><option>(Todos)</option></select></Field>
        </Fs>
        <Fs legend="Buscar Mercadería">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Toda Mercadería</label>
          <Field label="Mercadería"><div className="flex gap-1"><input className={`${inp} flex-1`} /><button className={iconBtn}><Search className="h-3.5 w-3.5" /></button></div></Field>
        </Fs>
        <Fs legend="Paginación">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Con Paginación</label>
        </Fs>
        <div className="mt-2 flex justify-end gap-2"><button className={btn}>Cancelar</button><button className={btnPrimary}>Aceptar</button></div>
      </div>
    </WindowShell>
  );
}

function ReporteGuiasRemision() {
  return (
    <WindowShell title="Reporte de Guías Remisión"
    >
      <div className="p-3 space-y-2 max-w-3xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Fechas">
          <Field label="Del"><input className={inp} type="date" defaultValue="2026-01-07" /></Field>
          <Field label="Al"><input className={inp} type="date" defaultValue="2026-07-21" /></Field>
        </Fs>
        <Fs legend="Búsqueda Rápida">
          <Field label="Oficina"><select className={inp}><option>(Todos)</option></select></Field>
          <Field label="Almacén"><select className={inp}><option>(Todos)</option></select></Field>
        </Fs>
        <Fs legend="Buscar Cliente">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Cliente</label>
          <Field label="Cliente"><select className={inp}><option>(Todos)</option></select></Field>
        </Fs>
        <Fs legend="Opciones">
          <Field label="Moneda"><select className={inp}><option>(Todos)</option></select></Field>
          <Field label="Serie Doc."><input className={inp} /></Field>
          <Field label="Motivo"><select className={inp}><option>(Todos)</option></select></Field>
          <Field label="Estado"><select className={inp}><option>(Todos)</option></select></Field>
        </Fs>
        <DataTable columns={["Fecha", "G/R", "Cliente", "Destino", "Cantidad", "Total"]} rows={5} />
        <div className="mt-2 flex justify-end gap-2"><button className={btn}>Cancelar</button><button className={btnPrimary}>Aceptar</button></div>
      </div>
    </WindowShell>
  );
}

function ReporteGRPendiente() {
  return (
    <WindowShell title="Reporte de Guías de Venta y Guías no Facturadas"
    >
      <div className="p-3 space-y-3 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        <div className="grid grid-cols-[1.35fr_0.75fr] gap-3">
          <Fs legend="Fechas">
            <Field label="Del"><input className={inp} type="date" defaultValue="2026-01-07" /></Field>
            <Field label="Al"><input className={inp} type="date" defaultValue="2026-07-21" /></Field>
          </Fs>
          <div className="space-y-3">
            <Field label="Motivo"><select className={inp}><option>(Todos)</option></select></Field>
            <Fs legend="Facturado">
              <div className="flex flex-col gap-1">
                <Radio name="facturado" label="Pendientes de Facturación" defaultChecked />
                <Radio name="facturado" label="Todos" />
              </div>
            </Fs>
          </div>
        </div>

        <div className="grid grid-cols-[1.1fr_1fr] gap-3">
          <Fs legend="Locación">
            <div className="space-y-1">
              <label className="flex items-center gap-2"><input type="radio" name="ubicacion" defaultChecked className="accent-[#2A5590]" />Todos</label>
              <label className="flex items-center gap-2"><input type="radio" name="ubicacion" className="accent-[#2A5590]" />Uno</label>
            </div>
            <Field label="Oficina"><select className={inp}><option>LIMA</option></select></Field>
            <Field label="Almacén"><select className={inp}><option>COMERCIAL</option></select></Field>
          </Fs>
          <Fs legend="Buscar Cliente">
            <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Cliente</label>
            <Field label="Cliente"><div className="flex gap-1"><input className={`${inp} flex-1`} /><button className={iconBtn}><Search className="h-3.5 w-3.5" /></button></div></Field>
          </Fs>
        </div>

        <div className="grid grid-cols-[1.1fr_1fr] gap-3">
          <Fs legend="Buscar Por Vendedor">
            <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Vendedor</label>
            <Field label="Vendedor"><div className="flex gap-1"><input className={`${inp} flex-1`} /><button className={iconBtn}><Search className="h-3.5 w-3.5" /></button></div></Field>
          </Fs>
          <Fs legend="Tipo Reporte">
            <div className="flex flex-col gap-1">
              <Radio name="tiporeporte" label="Reporte de Guías" defaultChecked />
              <Radio name="tiporeporte" label="Reporte de G/R Por Fecha de Proceso" />
            </div>
          </Fs>
        </div>

        <div className="mt-2 flex justify-end gap-2"><button className={btn}>Cancelar</button><button className={btnPrimary}>Aceptar</button></div>
      </div>
    </WindowShell>
  );
}

function ReportePresupuestoVenta() {
  return (
    <WindowShell title="Presupuesto Venta"
    >
      <div className="p-3 space-y-2 max-w-2xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Rango de Fechas">
          <Field label="Fecha del"><input className={inp} type="date" defaultValue="2026-01-07" /></Field>
          <Field label="Al"><input className={inp} type="date" defaultValue="2026-07-21" /></Field>
        </Fs>
        <Fs legend="Tipo Reporte">
          <div className="flex flex-col gap-1">
            <Radio name="tiprep" label="Presupuesto Anual" defaultChecked />
            <Radio name="tiprep" label="Ventas vs Presupuesto" />
          </div>
        </Fs>
        <div className="mt-2 flex justify-end gap-2"><button className={btn}>Cancelar</button><button className={btnPrimary}>Aceptar</button></div>
      </div>
    </WindowShell>
  );
}

function ReporteComisiones() {
  return (
    <WindowShell title="Reporte de Comisiones"
    >
      <div className="p-3 space-y-2 max-w-2xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Tipo Reporte">
          <div className="flex gap-2">
            <label className="flex items-center gap-1"><input type="radio" name="tiprep" defaultChecked className="accent-[#2A5590]" />Comisiones de vendedor</label>
            <label className="flex items-center gap-1"><input type="radio" name="tiprep" className="accent-[#2A5590]" />Compensación Allison</label>
          </div>
        </Fs>
        <Fs legend="Rango de Fechas">
          <Field label="Fechas Del"><input className={inp} type="date" defaultValue="2026-06-01" /></Field>
          <Field label="Al"><input className={inp} type="date" defaultValue="2026-06-30" /></Field>
        </Fs>
        <div className="mt-2 flex justify-end gap-2"><button className={btn}>Cancelar</button><button className={btnPrimary}>Aceptar</button></div>
      </div>
    </WindowShell>
  );
}

function ReporteCostoVenta() {
  return (
    <WindowShell title="Reporte de Costo de Venta"
    >
      <div className="p-3 space-y-2 max-w-3xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Rango de Fechas">
          <Field label="Desde"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
        </Fs>
        <Fs legend="Criterios">
          <Field label="Oficina"><select className={inp}><option>(Todos)</option><option>LIMA</option><option>AREQUIPA</option></select></Field>
          <Field label="Almacén"><select className={inp}><option>(Todos)</option><option>COMERCIAL</option><option>REPUESTOS</option></select></Field>
          <Field label="Tipo"><select className={inp}><option>Resumen</option><option>Detallado</option></select></Field>
        </Fs>
        <DataTable columns={["Fecha", "Documento", "Producto", "Cant.", "Costo Unit.", "Costo Total", "Venta", "Margen"]} rows={6} />
        <div className="mt-2 flex justify-end gap-2"><button className={btn}>Cancelar</button><button className={btnPrimary}>Aceptar</button></div>
      </div>
    </WindowShell>
  );
}

function ReportePagosCuentasXPagar() {
  return (
    <WindowShell title="Reporte de Pagos de Cuentas x Pagar"
    >
      <div className="p-3 space-y-2 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Rango de Fechas">
          <Field label="Desde"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
        </Fs>
        <Fs legend="Criterios de Pago">
          <Field label="Proveedor"><input className={inp} placeholder="RUC / Razón Social" /></Field>
          <Field label="Medio"><select className={inp}><option>(Todos)</option><option>Transferencia</option><option>Cheque</option><option>Efectivo</option></select></Field>
          <Field label="Moneda"><select className={inp}><option>(Todas)</option><option>PEN</option><option>USD</option></select></Field>
          <Field label="Estado"><select className={inp}><option>(Todos)</option><option>Programado</option><option>Ejecutado</option><option>Anulado</option></select></Field>
        </Fs>
        <DataTable columns={["Fecha", "Proveedor", "Documento", "Moneda", "Importe", "Medio Pago", "N° Operación", "Estado"]} rows={8} />
        <div className="mt-2 flex justify-end gap-2"><button className={btn}>Cancelar</button><button className={btnPrimary}>Aceptar</button></div>
      </div>
    </WindowShell>
  );
}

function ReporteSolicitudGastos() {
  return (
    <WindowShell title="Reporte de Solicitud de Gastos"
    >
      <div className="p-3 space-y-2 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Fechas de Solicitud">
          <Field label="Del"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Al"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
        </Fs>
        <Fs legend="Filtros Principales">
          <Field label="Área"><select className={inp}><option>(Todas)</option><option>Administración</option><option>Operaciones</option><option>Ventas</option></select></Field>
          <Field label="Estado"><select className={inp}><option>(Todos)</option><option>Pendiente</option><option>Aprobada</option><option>Rendida</option><option>Rechazada</option></select></Field>
          <Field label="Solicitante"><input className={inp} /></Field>
          <Field label="Tipo"><select className={inp}><option>(Todos)</option><option>Operativo</option><option>Servicio</option><option>Movilidad</option></select></Field>
        </Fs>
        <DataTable columns={["Fecha", "Solicitud", "Área", "Solicitante", "Tipo", "Estado", "Monto", "Rendido"]} rows={8} />
        <div className="mt-2 flex justify-end gap-2"><button className={btn}>Cancelar</button><button className={btnPrimary}>Aceptar</button></div>
      </div>
    </WindowShell>
  );
}

function ReporteCtasXPagarUnidad() {
  return (
    <WindowShell title="Cuentas x Pagar por Unidad"
    >
      <div className="p-3 space-y-2 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Período">
          <Field label="Desde"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
        </Fs>
        <Fs legend="Consolidación">
          <Field label="Unidad"><select className={inp}><option>(Todas)</option><option>Unidad Lima</option><option>Unidad Norte</option><option>Unidad Sur</option></select></Field>
          <Field label="Moneda"><select className={inp}><option>(Todas)</option><option>PEN</option><option>USD</option></select></Field>
          <Field label="Estado"><select className={inp}><option>(Todos)</option><option>Vigente</option><option>Vencido</option><option>Pagado</option></select></Field>
        </Fs>
        <DataTable columns={["Unidad", "Proveedor", "Comprobante", "Vence", "Moneda", "Total", "Saldo", "Estado"]} rows={8} />
        <div className="mt-2 flex justify-end gap-2"><button className={btn}>Cancelar</button><button className={btnPrimary}>Aceptar</button></div>
      </div>
    </WindowShell>
  );
}

function ServicioReporteDialog({ label }: { label: string }) {
  const n = label.toLowerCase();
  const isProgramacion = n.includes("program") || n.includes("tablero");
  const isHoras = n.includes("horas");
  const isGastos = n.includes("gasto");
  const isMotores = n.includes("motor");
  const isRepuestos = n.includes("repuesto");

  return (
    <WindowShell title={`Reporte Servicios — ${label}`}
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Generar</button>
        <div className="ml-auto flex gap-1.5">
          <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
          <button className={btn}><FileDown className="h-3.5 w-3.5" />PDF</button>
        </div>
      </>}>
      <div className="p-3 space-y-2 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Rango de Fechas">
          <Field label="Desde"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
        </Fs>

        <Fs legend="Filtros de Servicio">
          <Field label="Sede / Taller"><select className={inp}><option>(Todos)</option><option>Taller Central</option><option>Taller Mina</option></select></Field>
          <Field label="Jefe Taller"><input className={inp} /></Field>
          <Field label="Estado"><select className={inp}><option>(Todos)</option><option>Abierto</option><option>En proceso</option><option>Cerrado</option></select></Field>
          {isProgramacion && <Field label="Turno"><select className={inp}><option>(Todos)</option><option>Día</option><option>Noche</option></select></Field>}
          {isHoras && <Field label="Tipo Hora"><select className={inp}><option>(Todas)</option><option>Efectiva</option><option>Muerta</option><option>Escalón</option></select></Field>}
          {isGastos && <Field label="Rubro"><select className={inp}><option>(Todos)</option><option>Insumos</option><option>Terceros</option><option>Operativo</option></select></Field>}
          {isMotores && <Field label="Serie Motor"><input className={inp} /></Field>}
          {isRepuestos && <Field label="Repuesto"><input className={inp} /></Field>}
        </Fs>

        <DataTable columns={["Fecha", "OT", "Cliente", "Unidad", "Tarea", "Estado", "Costo", "Resultado"]} rows={8} />
      </div>
    </WindowShell>
  );
}

function PersonalReporteDialog({ label }: { label: string }) {
  const n = label.toLowerCase();
  const isAsistencia = n.includes("asist") || n.includes("tard");
  const isContrato = n.includes("contrat");
  const isHorario = n.includes("horario");
  const isOnomastico = n.includes("onom");

  return (
    <WindowShell title={`Reporte Personal — ${label}`}
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Generar</button>
        <div className="ml-auto flex gap-1.5">
          <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
          <button className={btn}><FileDown className="h-3.5 w-3.5" />PDF</button>
        </div>
      </>}>
      <div className="p-3 space-y-2 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Rango de Fechas">
          <Field label="Desde"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
        </Fs>

        <Fs legend="Filtros de RRHH">
          <Field label="Área"><select className={inp}><option>(Todas)</option><option>Administración</option><option>Operaciones</option><option>Servicios</option></select></Field>
          <Field label="Sede"><select className={inp}><option>(Todas)</option><option>Central</option><option>Mina 1</option></select></Field>
          <Field label="Colaborador"><input className={inp} placeholder="DNI / Nombre" /></Field>
          {isAsistencia && <Field label="Turno"><select className={inp}><option>(Todos)</option><option>Mañana</option><option>Tarde</option><option>Noche</option></select></Field>}
          {isContrato && <Field label="Vigencia"><select className={inp}><option>(Todas)</option><option>Vigente</option><option>Por vencer</option><option>Vencido</option></select></Field>}
          {isHorario && <Field label="Tipo Horario"><select className={inp}><option>(Todos)</option><option>Fijo</option><option>Rotativo</option></select></Field>}
          {isOnomastico && <Field label="Mes"><select className={inp}><option>Julio</option><option>Agosto</option><option>Septiembre</option></select></Field>}
        </Fs>

        <DataTable columns={["Fecha", "Colaborador", "Área", "Sede", "Estado", "Detalle", "Usuario"]} rows={8} />
      </div>
    </WindowShell>
  );
}

function GerenciaReporteDialog({ label }: { label: string }) {
  const n = label.toLowerCase();
  const isFinanzas = n.includes("financier") || n.includes("contabilidad") || n.includes("ctas");
  const isIndicadores = n.includes("indicador") || n.includes("tarjeta");

  return (
    <WindowShell title={`Gerencia — ${label}`}
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Actualizar</button>
        <div className="ml-auto flex gap-1.5">
          <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
          <button className={btn}><FileDown className="h-3.5 w-3.5" />PDF</button>
        </div>
      </>}>
      <div className="p-3 space-y-2 max-w-5xl mx-auto text-[11.5px] text-slate-800">

        <Fs legend="Rango Ejecutivo">
          <Field label="Desde"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Empresa"><select className={inp}><option>(Todas)</option><option>C2TECK S.A.C.</option><option>Sucursal Norte</option></select></Field>
          <Field label="Moneda"><select className={inp}><option>PEN</option><option>USD</option></select></Field>
          {isFinanzas && <Field label="Centro Costo"><select className={inp}><option>(Todos)</option><option>Administración</option><option>Operaciones</option><option>Servicios</option></select></Field>}
          {isIndicadores && <Field label="Frecuencia"><select className={inp}><option>Diaria</option><option>Semanal</option><option>Mensual</option></select></Field>}
        </Fs>

        <DataTable columns={["Periodo", "Unidad", "Indicador", "Meta", "Real", "Desvío", "Estado"]} rows={8} />
      </div>
    </WindowShell>
  );
}

function CrmReporteDialog({ label }: { label: string }) {
  const n = label.toLowerCase();
  const isOportunidad = n.includes("oportunidad");
  const isVisita = n.includes("visita");

  return (
    <WindowShell title={`CRM — ${label}`}
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Generar</button>
        <div className="ml-auto flex gap-1.5">
          <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
          <button className={btn}><FileDown className="h-3.5 w-3.5" />PDF</button>
        </div>
      </>}>
      <div className="p-3 space-y-2 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Rango de Fechas">
          <Field label="Desde"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
        </Fs>

        <Fs legend="Filtro Comercial">
          <Field label="Cliente"><input className={inp} /></Field>
          <Field label="Ejecutivo"><input className={inp} /></Field>
          <Field label="Estado"><select className={inp}><option>(Todos)</option><option>Abierto</option><option>En negociación</option><option>Cerrado</option></select></Field>
          {isOportunidad && <Field label="Etapa"><select className={inp}><option>(Todas)</option><option>Prospección</option><option>Cotización</option><option>Negociación</option></select></Field>}
          {isVisita && <Field label="Tipo visita"><select className={inp}><option>(Todas)</option><option>Comercial</option><option>Técnica</option><option>Postventa</option></select></Field>}
        </Fs>

        <DataTable columns={["Fecha", "Cliente", "Ejecutivo", "Actividad", "Estado", "Monto", "Resultado"]} rows={8} />
      </div>
    </WindowShell>
  );
}

function CreditosReporteDialog({ label }: { label: string }) {
  return (
    <WindowShell title={`Créditos — ${label}`}
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Generar</button>
      </>}>
      <div className="p-3 space-y-2 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Rango de Fechas">
          <Field label="Desde"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Cobrador"><input className={inp} /></Field>
          <Field label="Estado"><select className={inp}><option>(Todos)</option><option>Vigente</option><option>Vencido</option><option>Cancelado</option></select></Field>
        </Fs>
        <DataTable columns={["Documento", "Cliente", "Emisión", "Vence", "Saldo", "Estado", "Responsable"]} rows={8} />
      </div>
    </WindowShell>
  );
}

function AlmacenReporteDialog({ label }: { label: string }) {
  return (
    <WindowShell title={`Almacenes — ${label}`}
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Generar</button>
      </>}>
      <div className="p-3 space-y-2 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Criterios de Inventario">
          <Field label="Desde"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Almacén"><select className={inp}><option>(Todos)</option><option>Central</option><option>Repuestos</option></select></Field>
          <Field label="Rubro"><select className={inp}><option>(Todos)</option><option>Repuestos</option><option>Lubricantes</option></select></Field>
        </Fs>
        <DataTable columns={["Código", "Descripción", "Stock", "Costo", "Ubicación", "Estado", "Rotación"]} rows={8} />
      </div>
    </WindowShell>
  );
}

function CostosReporteDialog({ label }: { label: string }) {
  return (
    <WindowShell title={`Costos — ${label}`}
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Calcular</button>
      </>}>
      <div className="p-3 space-y-2 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Período de Costeo">
          <Field label="Mes"><input className={inp} type="month" defaultValue="2026-07" /></Field>
          <Field label="Almacén"><select className={inp}><option>(Todos)</option><option>Central</option><option>Repuestos</option></select></Field>
          <Field label="Método"><select className={inp}><option>Promedio</option><option>PEPS</option></select></Field>
          <Field label="Moneda"><select className={inp}><option>PEN</option><option>USD</option></select></Field>
        </Fs>
        <DataTable columns={["Ítem", "Cantidad", "Costo Unit", "Costo Total", "Venta", "Margen", "Estado"]} rows={8} />
      </div>
    </WindowShell>
  );
}

function ContabilidadReporteDialog({ label }: { label: string }) {
  return (
    <WindowShell title={`Contabilidad — ${label}`}
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Generar</button>
      </>}>
      <div className="p-3 space-y-2 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Rango Contable">
          <Field label="Desde"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Cuenta"><input className={inp} placeholder="10.01.01" /></Field>
          <Field label="Centro costo"><select className={inp}><option>(Todos)</option><option>Administración</option><option>Operaciones</option></select></Field>
        </Fs>
        <DataTable columns={["Fecha", "Asiento", "Cuenta", "Debe", "Haber", "Glosa", "Estado"]} rows={8} />
      </div>
    </WindowShell>
  );
}

function ComprasReporteDialog({ label }: { label: string }) {
  return (
    <WindowShell title={`Compras — ${label}`}
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Generar</button>
      </>}>
      <div className="p-3 space-y-2 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Rango de Compra">
          <Field label="Desde"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Proveedor"><input className={inp} placeholder="RUC / Razón Social" /></Field>
          <Field label="Estado"><select className={inp}><option>(Todos)</option><option>Pendiente</option><option>Aprobada</option><option>Pagada</option></select></Field>
        </Fs>
        <DataTable columns={["Fecha", "Documento", "Proveedor", "Moneda", "Base", "IGV", "Total", "Estado"]} rows={8} />
      </div>
    </WindowShell>
  );
}

// ---------- Contenedor de reportes personalizados ----------
function FsLegacy({ legend, children }: { legend: string; children: ReactNode }) {
  return (
    <fieldset className="border border-[#7A96B4] px-2 pb-2 pt-1 bg-[#ECF1F7] rounded-sm">
      <legend className="px-1 text-[10.5px] font-bold text-slate-700">{legend}</legend>
      <div className="mt-2 space-y-2">{children}</div>
    </fieldset>
  );
}

function RadioLegacy({ name, label, defaultChecked }: { name: string; label: string; defaultChecked?: boolean }) {
  return (
    <label className="inline-flex items-center gap-1 text-[11.5px] text-slate-800">
      <input type="radio" name={name} defaultChecked={defaultChecked} className="accent-[#2A5590]" />
      {label}
    </label>
  );
}

function DialogFooter({ onOk, onCancel }: { onOk: () => void; onCancel: () => void }) {
  return (
    <div className="flex justify-end gap-2 px-3 py-2 border-t border-slate-300 bg-[#F8FAFC]">
      <button className={btn} onClick={onCancel}>Cancelar</button>
      <button className={btnPrimary} onClick={onOk}>Generar</button>
    </div>
  );
}

function VentaReporteDialog({ label }: { label: string }) {
  const n = label.toLowerCase();
  const isDetalle = n.includes("detalle");

  if (isDetalle) {
    return (
      <WindowShell title="Reporte de Ventas Detallado">
        <div className="max-w-5xl mx-auto p-3 space-y-3 text-[11.5px] text-slate-800">
          <div className="grid grid-cols-1 gap-2 xl:grid-cols-[2fr_1fr]">
            <div className="xl:pr-2">
              <Fs legend="Fechas">
                <div className="flex flex-wrap items-center gap-2">
                  <span className="font-semibold">Del :</span>
                  <input className={`${inp} w-40`} type="date" defaultValue="2026-08-01" />
                  <span className="font-semibold">Al</span>
                  <input className={`${inp} w-40`} type="date" defaultValue="2026-08-08" />
                </div>
                <div className="mt-3">
                  <Field label="Rubro" className="w-full">
                    <select className={inp}><option>(Todos)</option></select>
                  </Field>
                </div>
              </Fs>
            </div>

            <div className="grid grid-cols-1 gap-2">
              <Field label="Oficina" className="w-full">
                <select className={inp}><option>(Todos)</option></select>
              </Field>
              <Field label="Almacén" className="w-full">
                <select className={inp}><option>(Todos)</option></select>
              </Field>
            </div>
          </div>

          <div className="grid grid-cols-1 gap-2 lg:grid-cols-3">
            <Fs legend="Buscar Por Vendedor">
              <label className="inline-flex items-center gap-2 text-[11px]">
                <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
                <span>Todo Vendedor</span>
              </label>
              <Field label="Vendedor" className="w-full">
                <select className={inp}><option>(Todos)</option></select>
              </Field>
            </Fs>

            <Fs legend="Buscar Cliente">
              <label className="inline-flex items-center gap-2 text-[11px]">
                <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
                <span>Todo Cliente</span>
              </label>
              <Field label="Cliente" className="w-full">
                <div className="flex items-center gap-2">
                  <input className={`${inp} flex-1`} />
                  <button className={iconBtn}><Search className="h-3.5 w-3.5" /></button>
                </div>
              </Field>
              <Field label="Locación Cliente" className="w-full">
                <select className={inp}><option>0</option></select>
              </Field>
            </Fs>

            <Fs legend="Buscar Mercadería">
              <label className="inline-flex items-center gap-2 text-[11px]">
                <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
                <span>Toda Mercadería</span>
              </label>
              <Field label="Mercadería" className="w-full">
                <div className="flex items-center gap-2">
                  <input className={`${inp} flex-1`} />
                  <button className={iconBtn}><Search className="h-3.5 w-3.5" /></button>
                </div>
              </Field>
            </Fs>
          </div>

          <div className="grid grid-cols-1 gap-2 lg:grid-cols-3">
            <Fs legend="Documentos">
              <div className="flex flex-col gap-1 text-[11px]">
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="docs" defaultChecked className="accent-[#2A5590]" />
                  <span>Todos</span>
                </label>
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="docs" className="accent-[#2A5590]" />
                  <span>Facturación</span>
                </label>
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="docs" className="accent-[#2A5590]" />
                  <span>Facturados sin Exportaciones</span>
                </label>
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="docs" className="accent-[#2A5590]" />
                  <span>Exportaciones</span>
                </label>
              </div>
            </Fs>

            <Fs legend="Tipo Reporte">
              <div className="flex flex-col gap-1 text-[11px]">
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="tipo" defaultChecked className="accent-[#2A5590]" />
                  <span>Detallado</span>
                </label>
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="tipo" className="accent-[#2A5590]" />
                  <span>Detallado Unitario</span>
                </label>
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="tipo" className="accent-[#2A5590]" />
                  <span>Resumen</span>
                </label>
              </div>
            </Fs>

            <Fs legend="Reporte Agrupado">
              <div className="space-y-3 text-[11px]">
                <div>
                  <label className="inline-flex items-center gap-2">
                    <input type="radio" name="agrup" defaultChecked className="accent-[#2A5590]" />
                    <span>Cliente</span>
                  </label>
                </div>
                <div className="flex flex-wrap items-center gap-2 text-[10px]">
                  <span>Ordenar por :</span>
                  <label className="inline-flex items-center gap-1">
                    <input type="radio" name="orden1" defaultChecked className="accent-[#2A5590]" />
                    <span>Fecha</span>
                  </label>
                  <label className="inline-flex items-center gap-1">
                    <input type="radio" name="orden1" className="accent-[#2A5590]" />
                    <span>Mercadería</span>
                  </label>
                </div>
                <div>
                  <label className="inline-flex items-center gap-2">
                    <input type="radio" name="agrup" className="accent-[#2A5590]" />
                    <span>Mercadería</span>
                  </label>
                </div>
                <div className="flex flex-wrap items-center gap-2 text-[10px]">
                  <span>Ordenar por :</span>
                  <label className="inline-flex items-center gap-1">
                    <input type="radio" name="orden2" className="accent-[#2A5590]" />
                    <span>Fecha</span>
                  </label>
                  <label className="inline-flex items-center gap-1">
                    <input type="radio" name="orden2" defaultChecked className="accent-[#2A5590]" />
                    <span>Cliente</span>
                  </label>
                </div>
              </div>
            </Fs>
          </div>

          <div className="grid grid-cols-1 gap-2 xl:grid-cols-[2fr_auto]">
            <Fs legend="Exportar">
              <div className="space-y-2 text-[11px]">
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="export" defaultChecked className="accent-[#2A5590]" />
                  <span>Pantalla</span>
                </label>
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="export" className="accent-[#2A5590]" />
                  <span>Exportar</span>
                </label>
              </div>
              <div className="ml-5 flex flex-col gap-2 mt-2 text-[11px]">
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="exp_type" defaultChecked className="accent-[#2A5590]" />
                  <span>Detallado</span>
                </label>
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="exp_type" className="accent-[#2A5590]" />
                  <span>Resumido</span>
                </label>
              </div>
            </Fs>

            <div className="flex items-end justify-end">
              <div className="flex gap-2">
                <button className={btnPrimary}>Aceptar</button>
                <button className={btn}>Cancelar</button>
              </div>
            </div>
          </div>
        </div>
      </WindowShell>
    );
  }

  // Otros tipos de reportes...
  return (
    <WindowShell title={`Reporte — ${label}`}>
      <div className="p-3 space-y-2 max-w-4xl mx-auto">
        <div className="flex justify-end gap-2 pt-2 border-t border-slate-200">
          <button className={btnPrimary}>Aceptar</button>
          <button className={btn}>Cancelar</button>
        </div>
      </div>
    </WindowShell>
  );
}

function IndicadoresVentaDialog() {
  return (
    <WindowShell>
      <div className="p-3 space-y-2 max-w-3xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Mensual">
          <div className="flex items-center gap-2 w-full justify-center">
            <span className="font-bold">Fecha Mensual :</span>
            <input className={`${inp} w-28`} defaultValue="09-2024" />
            <button className={btn}><Search className="h-3.5 w-3.5" />Buscar</button>
          </div>
          <div className="w-full"><DataTable columns={["INDICADOR","U/M","FRECUENCIA","PB","OBJ.","REAL","🚦","G"]} rows={8} /></div>
        </Fs>
        <Fs legend="Diario">
          <div className="flex items-center gap-2 w-full justify-center">
            <span className="font-bold">Fecha Diaria :</span>
            <input className={`${inp} w-32`} type="date" defaultValue="2026-07-16" />
            <button className={btn}><Search className="h-3.5 w-3.5" />Buscar</button>
            <button className={iconBtn}>&lt;</button>
            <button className={iconBtn}>&gt;</button>
          </div>
          <div className="w-full"><DataTable columns={["INDICADOR","U/M","FRECUENCIA","PB","OBJ.","REAL","🚦","G"]} rows={8} /></div>
        </Fs>
      </div>
    </WindowShell>
  );
}

// ---------- Contenedor de Reportes ----------
function ReporteContainer({ label }: { label: string }) {
  return (
    <WindowShell title={`Reporte — ${label}`}
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <Field label=""><input className={inp} type="date" /></Field>
        <span className="text-[11px] text-slate-500">a</span>
        <Field label=""><input className={inp} type="date" /></Field>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Generar</button>
        <div className="ml-auto flex gap-1.5">
          <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
          <button className={btn}><FileDown className="h-3.5 w-3.5" />PDF</button>
          <button className={btn}><Printer className="h-3.5 w-3.5" />Imprimir</button>
        </div>
      </>}>
      <div className="text-[11px] text-slate-500 mb-2">
        Filtro pre-seleccionado: <b className="text-[#2A3F55]">{label}</b>
      </div>
      <DataTable columns={["#", "Fecha", "Documento", "Cliente / Ref.", "Vendedor", "Moneda", "Base", "IGV", "Total"]} rows={10} />
    </WindowShell>
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
    <WindowShell>
      <div className="p-3 space-y-2 max-w-3xl mx-auto text-[11.5px] text-slate-800">
        <div className="flex items-center gap-2">
          <span className="font-bold w-16">Marca :</span>
          <select className={`${inp} w-64 bg-[#2A5590] text-white font-semibold`}>
            <option>YANMAR</option><option>CATERPILLAR</option><option>KOMATSU</option>
          </select>
        </div>
        <Fs legend="Mercaderia">
          <div className="grid grid-cols-2 gap-x-8 w-full">
            {/* Columna izquierda */}
            <div className="space-y-1.5">
              <LabRow label="Código :"><input className={`${inp} w-40`} /></LabRow>
              <LabRow label="Record Type :"><input className={`${inp} w-20`} /></LabRow>
              <LabRow label="Supercession Code"><input className={`${inp} w-20`} /></LabRow>
              <LabRow label="Publicacion Code"><input className={`${inp} w-20`} /></LabRow>
              <LabRow label="Series Code"><input className={`${inp} w-20`} /></LabRow>
              <LabRow label="Functional Comp Code"><input className={`${inp} w-20`} /></LabRow>
              <LabRow label="Country of Origen"><input className={`${inp} w-20`} /></LabRow>
              <LabRow label="Precio Core"><input className={`${inp} w-32 text-right`} defaultValue="0.00" /></LabRow>
              <div className="h-3" />
              <LabRow label="Precio Ex Work: US$"><input className={`${inp} w-32 text-right`} defaultValue="0.00" /></LabRow>
            </div>
            {/* Columna derecha */}
            <div className="space-y-1.5">
              <LabRow label="Descripcion :"><input className={`${inp} w-56`} /></LabRow>
              <LabRow label="Must Buy Quantity"><input className={`${inp} w-20`} /></LabRow>
              <LabRow label="Group Code"><input className={`${inp} w-32 text-right bg-[#DCE9F7]`} defaultValue="0.0000" /></LabRow>
              <LabRow label="Weight"><input className={`${inp} w-32 text-right bg-[#DCE9F7]`} defaultValue="0.0000" /></LabRow>
              <LabRow label="Unit Weight"><input className={`${inp} w-32`} /></LabRow>
              <LabRow label="Cubes"><input className={`${inp} w-32 text-right bg-[#DCE9F7]`} defaultValue="0.0000" /></LabRow>
              <LabRow label="Unit Cubes"><input className={`${inp} w-32`} /></LabRow>
              <LabRow label="Precio SLP : US$"><input className={`${inp} w-32 text-right bg-[#DCE9F7]`} defaultValue="0.00" /></LabRow>
              <LabRow label="Precio Venta :  US$"><input className={`${inp} w-32 text-right bg-[#DCE9F7]`} defaultValue="0.00" /></LabRow>
              <LabRow label="Precio Venta    S/."><input className={`${inp} w-32 text-right bg-[#DCE9F7]`} defaultValue="0.00" /></LabRow>
            </div>
          </div>
        </Fs>
        <div className="flex justify-end pt-1">
          <button className={btn} onClick={() => toast.message("Cerrado")}><X className="h-3.5 w-3.5" />Cancelar</button>
        </div>
      </div>
    </WindowShell>
  );
}

// ============================================================
// MACRO 1 · CRÉDITOS
// ============================================================
function CtasXCobrar() {
  const [search, setSearch] = useState("");
  const [vendor, setVendor] = useState("Todos");
  const [state, setState] = useState("Todos");
  const [currency, setCurrency] = useState("PEN");
  const [fromDate, setFromDate] = useState("");
  const [toDate, setToDate] = useState("");

  return (
    <WindowShell title="Cuentas por Cobrar — Gestión de Deudas"
      toolbar={<>
        <input className={`${inp} w-64`} placeholder="Cliente / RUC / Documento..." value={search} onChange={(e) => setSearch(e.target.value)} />
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><DollarSign className="h-3.5 w-3.5" />Registrar Cobro</button>
        <button className={btn}><Check className="h-3.5 w-3.5" />Marcar Cobrado</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
        <span className="ml-auto text-[11px] text-slate-500">Deuda total: <b className="text-red-700">S/ 0.00</b></span>
      </>}>
      <div className="grid grid-cols-4 gap-2 mb-2 text-[11px]">
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Vigente:</span> <b className="font-mono text-slate-900">S/ 0.00</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Vencido:</span> <b className="font-mono text-red-700">S/ 0.00</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Cobrado:</span> <b className="font-mono text-emerald-700">S/ 0.00</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Registros:</span> <b className="font-mono text-slate-900">0</b></div>
      </div>
      <div className="grid grid-cols-6 gap-2 mb-3">
        <Field label="Vendedor"><select className={inp} value={vendor} onChange={(e) => setVendor(e.target.value)}><option>Todos</option></select></Field>
        <Field label="Estado"><select className={inp} value={state} onChange={(e) => setState(e.target.value)}><option>Todos</option><option>Vigente</option><option>Vencido</option><option>Cobrado</option></select></Field>
        <Field label="Moneda"><select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}><option>PEN</option><option>USD</option></select></Field>
        <Field label="Desde"><input className={inp} type="date" value={fromDate} onChange={(e) => setFromDate(e.target.value)} /></Field>
        <Field label="Hasta"><input className={inp} type="date" value={toDate} onChange={(e) => setToDate(e.target.value)} /></Field>
        <Field label="Cond. Pago"><select className={inp}><option>(Todas)</option><option>CONTADO</option><option>CRÉDITO 15</option><option>CRÉDITO 30</option></select></Field>
      </div>
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]">
            <tr>
              <th className="px-2 py-2 text-left border-b border-slate-300">Doc.</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Fecha Emis.</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Vence</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Cliente</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Moneda</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">Total</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">Saldo</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">Días</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Estado</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Acción</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td colSpan={10} className="px-2 py-4 text-sm text-slate-500">No hay cuentas por cobrar.</td>
            </tr>
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}

function Anticipos() {
  const [clientName, setClientName] = useState("");
  const [date, setDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [currency, setCurrency] = useState("PEN");
  const [amount, setAmount] = useState(0);
  const [paymentMethod, setPaymentMethod] = useState("Transferencia");
  const [reference, setReference] = useState("");
  const [note, setNote] = useState("");
  const [saving, setSaving] = useState(false);
  const [message, setMessage] = useState<string | null>(null);
  const [recent, setRecent] = useState<Array<{ id: string; date: string; client: string; currency: string; amount: number; reference: string }>>([]);

  const handleSave = async () => {
    if (!clientName.trim() || amount <= 0) {
      setMessage("Complete cliente y monto.");
      return;
    }
    setSaving(true);
    try {
      const created = await createSigecoomSale({
        type: "Anticipo",
        series: "ANT001",
        number: Math.floor(Math.random() * 10000),
        client_id: clientName,
        date,
        items: [{ description: `Anticipo ${paymentMethod} - ${reference}`, unit: "unidad", quantity: 1, price: amount }],
        subtotal: amount,
        tax: 0,
        total: amount,
      });
      setMessage(`Anticipo registrado para ${clientName} - ${currency} ${amount}`);
      setRecent((prev) => [
        {
          id: created.id,
          date,
          client: clientName,
          currency,
          amount,
          reference,
        },
        ...prev,
      ].slice(0, 8));
      setClientName("");
      setAmount(0);
      setReference("");
      setNote("");
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error");
    } finally {
      setSaving(false);
    }
  };

  return (
    <WindowShell title="Anticipos de Clientes"
      toolbar={<>
        <button className={btnPrimary} onClick={handleSave} disabled={saving}><Save className="h-3.5 w-3.5" />{saving ? "Guardando..." : "Registrar Anticipo"}</button>
        <button className={btn}><Search className="h-3.5 w-3.5" />Aplicar a Factura</button>
        <button className={btn}><Printer className="h-3.5 w-3.5" />Imprimir</button>
      </>}>
      <div className="grid grid-cols-3 gap-2 mb-2 text-[11px]">
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Registros:</span> <b className="font-mono text-slate-900">{recent.length}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Total PEN:</span> <b className="font-mono text-slate-900">{recent.filter((row) => row.currency === "PEN").reduce((acc, row) => acc + row.amount, 0).toFixed(2)}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Total USD:</span> <b className="font-mono text-slate-900">{recent.filter((row) => row.currency === "USD").reduce((acc, row) => acc + row.amount, 0).toFixed(2)}</b></div>
      </div>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Cliente" className="col-span-2"><input className={inp} value={clientName} onChange={(e) => setClientName(e.target.value)} /></Field>
        <Field label="Fecha"><input className={inp} type="date" value={date} onChange={(e) => setDate(e.target.value)} /></Field>
        <Field label="Moneda"><select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}><option>PEN</option><option>USD</option></select></Field>
        <Field label="Monto"><input className={inp} type="number" value={amount} onChange={(e) => setAmount(Number(e.target.value))} /></Field>
        <Field label="Medio Pago"><select className={inp} value={paymentMethod} onChange={(e) => setPaymentMethod(e.target.value)}><option>Efectivo</option><option>Transferencia</option><option>Depósito</option></select></Field>
        <Field label="Referencia"><input className={inp} value={reference} onChange={(e) => setReference(e.target.value)} /></Field>
        <Field label="Observación" className="col-span-4"><input className={inp} value={note} onChange={(e) => setNote(e.target.value)} /></Field>
      </div>
      {message && <div className="mt-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="mt-3 border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]">
            <tr>
              <th className="px-2 py-2 text-left border-b border-slate-300">Fecha</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Cliente</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Mon.</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">Monto</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Referencia</th>
            </tr>
          </thead>
          <tbody>
            {recent.length === 0 ? (
              <tr><td colSpan={5} className="px-2 py-4 text-sm text-slate-500">No hay anticipos registrados en esta sesión.</td></tr>
            ) : recent.map((row) => (
              <tr key={row.id}>
                <td className="px-2 py-2 border-b border-slate-200">{row.date}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.client}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.currency}</td>
                <td className="px-2 py-2 border-b border-slate-200 text-right font-mono">{row.amount.toFixed(2)}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.reference || "-"}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}

function Planillas() {
  const [collector, setCollector] = useState("");
  const [date, setDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [route, setRoute] = useState("Lima Centro");
  const [currency, setCurrency] = useState("PEN");
  const [generating, setGenerating] = useState(false);
  const [message, setMessage] = useState<string | null>(null);
  const [planillas, setPlanillas] = useState<Array<{ id: string; number: string; collector: string; route: string; date: string; currency: string; total: number; state: string }>>([]);

  const handleGenerate = async () => {
    if (!collector) {
      setMessage("Seleccione un cobrador antes de generar la planilla.");
      return;
    }
    setGenerating(true);
    setMessage(null);
    try {
      const created = await createSigecoomSale({
        type: "Planilla",
        series: "PL001",
        number: Math.floor(Math.random() * 10000),
        date,
        client_id: collector,
        items: [{ description: `Planilla cobranza ${route}`, unit: "unidad", quantity: 1, price: 0 }],
        subtotal: 0,
        tax: 0,
        total: 0,
      });
      setMessage(`Planilla generada: ${created.series}-${created.number}`);
      setPlanillas((prev) => [
        {
          id: created.id,
          number: `${created.series}-${created.number}`,
          collector,
          route,
          date,
          currency,
          total: created.total,
          state: "Generada",
        },
        ...prev,
      ].slice(0, 10));
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error al generar planilla");
    } finally {
      setGenerating(false);
    }
  };

  return (
    <WindowShell title="Planillas de Cobranza"
      toolbar={<>
        <button className={btnPrimary} onClick={handleGenerate} disabled={generating}><Save className="h-3.5 w-3.5" />{generating ? "Generando..." : "Generar Planilla"}</button>
        <button className={btn}><Printer className="h-3.5 w-3.5" />Imprimir</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}>
      <div className="grid grid-cols-4 gap-2 mb-2 text-[11px]">
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Planillas:</span> <b className="font-mono text-slate-900">{planillas.length}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Ruta Centro:</span> <b className="font-mono text-slate-900">{planillas.filter((row) => row.route === "Lima Centro").length}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Ruta Norte:</span> <b className="font-mono text-slate-900">{planillas.filter((row) => row.route === "Lima Norte").length}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Total:</span> <b className="font-mono text-slate-900">{planillas.reduce((acc, row) => acc + row.total, 0).toFixed(2)}</b></div>
      </div>
      <div className="grid grid-cols-6 gap-2 mb-3">
        <Field label="Cobrador"><select className={inp} value={collector} onChange={(e) => setCollector(e.target.value)}><option value="">Asignar...</option><option value="grios">grios</option><option value="mlopez">mlopez</option></select></Field>
        <Field label="Fecha"><input className={inp} type="date" value={date} onChange={(e) => setDate(e.target.value)} /></Field>
        <Field label="Ruta"><select className={inp} value={route} onChange={(e) => setRoute(e.target.value)}><option>Lima Centro</option><option>Lima Norte</option></select></Field>
        <Field label="Moneda"><select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}><option>PEN</option></select></Field>
        <Field label="Prioridad"><select className={inp}><option>(Todas)</option><option>Alta</option><option>Media</option><option>Baja</option></select></Field>
        <Field label="Estado"><select className={inp}><option>(Todos)</option><option>Generada</option><option>En ruta</option><option>Cerrada</option></select></Field>
      </div>
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]">
            <tr>
              <th className="px-2 py-2 text-left border-b border-slate-300">Planilla</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Cobrador</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Ruta</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Fecha</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Moneda</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">Total</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Estado</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Acción</th>
            </tr>
          </thead>
          <tbody>
            {planillas.length === 0 ? (
              <tr><td colSpan={8} className="px-2 py-4 text-sm text-slate-500">No hay planillas generadas en esta sesión.</td></tr>
            ) : planillas.map((row) => (
              <tr key={row.id}>
                <td className="px-2 py-2 border-b border-slate-200 font-mono">{row.number}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.collector}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.route}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.date}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.currency}</td>
                <td className="px-2 py-2 border-b border-slate-200 text-right font-mono">{row.total.toFixed(2)}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.state}</td>
                <td className="px-2 py-2 border-b border-slate-200"><button className={btn}>Ver Detalle</button></td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}

function Letras() {
  const [letters, setLetters] = useState<SigecoomSale[]>([]);
  const [selectedLetterId, setSelectedLetterId] = useState("");
  const [loadingLetters, setLoadingLetters] = useState(true);
  const [actionLoading, setActionLoading] = useState(false);
  const [statusMessage, setStatusMessage] = useState<string | null>(null);
  const [statusFilter, setStatusFilter] = useState("Todos");
  const [clientFilter, setClientFilter] = useState("");

  const loadLetters = async () => {
    setLoadingLetters(true);
    try {
      const data = await fetchSigecoomSales();
      setLetters(data.filter((sale) => sale.type.toLowerCase().includes("letra")));
      setStatusMessage(null);
    } catch (error) {
      setStatusMessage(error instanceof Error ? error.message : "Error cargando letras");
    } finally {
      setLoadingLetters(false);
    }
  };

  useEffect(() => {
    loadLetters();
  }, []);

  const handleGenerate = async () => {
    setActionLoading(true);
    setStatusMessage(null);
    try {
      const created = await createSigecoomSale({
        type: "Letra",
        series: "LT001",
        number: Math.floor(Math.random() * 10000),
        date: new Date().toISOString().slice(0, 10),
        client_id: "Cliente Letra",
        items: [{ description: "Letra de cambio generada desde escritorio", unit: "unidad", quantity: 1, price: 0 }],
        subtotal: 0,
        tax: 0,
        total: 0,
      });
      setLetters((current) => [created, ...current]);
      setStatusMessage(`Letra generada: ${created.series}-${created.number}`);
    } catch (error) {
      setStatusMessage(error instanceof Error ? error.message : "Error al generar letra");
    } finally {
      setActionLoading(false);
    }
  };

  const updateSelectedLetterStatus = async (status: string) => {
    if (!selectedLetterId) {
      setStatusMessage("Seleccione una letra antes de continuar.");
      return;
    }
    setActionLoading(true);
    setStatusMessage(null);
    try {
      const updated = await updateSigecoomSale(selectedLetterId, { status });
      setLetters((current) => current.map((letter) => letter.id === updated.id ? updated : letter));
      setStatusMessage(`Letra ${updated.series}-${updated.number} ${status}.`);
    } catch (error) {
      setStatusMessage(error instanceof Error ? error.message : "Error al actualizar letra");
    } finally {
      setActionLoading(false);
    }
  };

  const visibleLetters = letters.filter((letter) => {
    const statusText = String(letter.status ?? "").toLowerCase();
    const statusMatch = statusFilter === "Todos" || statusText === statusFilter.toLowerCase();
    const clientText = String(letter.client_id ?? "").toLowerCase();
    const clientMatch = !clientFilter.trim() || clientText.includes(clientFilter.trim().toLowerCase());
    return statusMatch && clientMatch;
  });

  const totalAmount = visibleLetters.reduce((acc, letter) => acc + letter.total, 0);
  const acceptedCount = visibleLetters.filter((letter) => String(letter.status ?? "").toLowerCase() === "accepted").length;
  const protestedCount = visibleLetters.filter((letter) => String(letter.status ?? "").toLowerCase() === "protested").length;

  return (
    <WindowShell title="Letras de Cambio Financieras"
      toolbar={<>
        <button className={btnPrimary} onClick={handleGenerate} disabled={actionLoading}><Save className="h-3.5 w-3.5" />{actionLoading ? "Procesando..." : "Generar Letra"}</button>
        <button className={btn} onClick={() => updateSelectedLetterStatus("accepted")} disabled={actionLoading}>Aceptar</button>
        <button className={btn} onClick={() => updateSelectedLetterStatus("protested")} disabled={actionLoading}>Protestar</button>
        <button className={btn} onClick={loadLetters} disabled={actionLoading}><RefreshCw className="h-3.5 w-3.5" />Actualizar</button>
      </>}>
      {statusMessage && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{statusMessage}</div>}
      <div className="grid grid-cols-4 gap-2 mb-2 text-[11px]">
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Registros:</span> <b className="font-mono text-slate-900">{visibleLetters.length}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Aceptadas:</span> <b className="font-mono text-emerald-700">{acceptedCount}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Protestadas:</span> <b className="font-mono text-amber-700">{protestedCount}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Importe total:</span> <b className="font-mono text-slate-900">{totalAmount.toFixed(2)}</b></div>
      </div>
      <div className="grid grid-cols-3 gap-2 mb-3">
        <Field label="Cliente"><input className={inp} value={clientFilter} onChange={(e) => setClientFilter(e.target.value)} placeholder="Filtrar cliente" /></Field>
        <Field label="Estado"><select className={inp} value={statusFilter} onChange={(e) => setStatusFilter(e.target.value)}><option>Todos</option><option>draft</option><option>issued</option><option>accepted</option><option>protested</option></select></Field>
        <Field label="Carga"><input className={inp} value={loadingLetters ? "Cargando..." : "Lista actualizada"} readOnly /></Field>
      </div>
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]"><tr><th className="px-2 py-2 text-left border-b border-slate-300">Sel</th><th className="px-2 py-2 text-left border-b border-slate-300">Nº Letra</th><th className="px-2 py-2 text-left border-b border-slate-300">Fecha Giro</th><th className="px-2 py-2 text-left border-b border-slate-300">Cliente</th><th className="px-2 py-2 text-left border-b border-slate-300">Vencimiento</th><th className="px-2 py-2 text-left border-b border-slate-300">Moneda</th><th className="px-2 py-2 text-right border-b border-slate-300">Importe</th><th className="px-2 py-2 text-left border-b border-slate-300">Banco</th><th className="px-2 py-2 text-left border-b border-slate-300">Estado</th></tr></thead>
          <tbody>
            {visibleLetters.length === 0 ? (
              <tr><td colSpan={9} className="px-2 py-4 text-sm text-slate-500">No hay letras registradas.</td></tr>
            ) : visibleLetters.map((letter) => (
              <tr key={letter.id} className={`hover:bg-slate-50 ${selectedLetterId === letter.id ? "bg-slate-100" : ""}`}>
                <td className="px-2 py-2 border-b border-slate-200 text-center"><input type="radio" name="selectedLetter" checked={selectedLetterId === letter.id} onChange={() => setSelectedLetterId(letter.id)} /></td>
                <td className="px-2 py-2 border-b border-slate-200">{letter.series}-{letter.number}</td>
                <td className="px-2 py-2 border-b border-slate-200">{letter.date}</td>
                <td className="px-2 py-2 border-b border-slate-200">{letter.client_id}</td>
                <td className="px-2 py-2 border-b border-slate-200">{letter.date}</td>
                <td className="px-2 py-2 border-b border-slate-200">PEN</td>
                <td className="px-2 py-2 border-b border-slate-200 text-right">{letter.total.toFixed(2)}</td>
                <td className="px-2 py-2 border-b border-slate-200">Banco</td>
                <td className="px-2 py-2 border-b border-slate-200">{letter.status}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}

function AprobacionCreditos() {
  const [type, setType] = useState("Extensión de línea");
  const [status, setStatus] = useState("Pendiente");
  const [fromDate, setFromDate] = useState("");
  const [toDate, setToDate] = useState("");
  const [message, setMessage] = useState<string | null>(null);

  const handleAprobar = () => setMessage("Solicitud aprobada correctamente.");
  const handleRechazar = () => setMessage("Solicitud rechazada.");

  return (
    <WindowShell title="Aprobación de Créditos y Extensiones"
      toolbar={<>
        <button className={btnPrimary} onClick={handleAprobar}>Aprobar</button>
        <button className={btn} onClick={handleRechazar}>Rechazar</button>
        <button className={btn}><User className="h-3.5 w-3.5" />Ver Historial</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}>
      <div className="grid grid-cols-4 gap-2 mb-2 text-[11px]">
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Pendientes:</span> <b className="font-mono text-amber-700">0</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Aprobadas:</span> <b className="font-mono text-emerald-700">0</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Rechazadas:</span> <b className="font-mono text-red-700">0</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Monto Solicitado:</span> <b className="font-mono text-slate-900">0.00</b></div>
      </div>
      <div className="grid grid-cols-6 gap-2 mb-3">
        <Field label="Tipo"><select className={inp} value={type} onChange={(e) => setType(e.target.value)}><option>Extensión de línea</option><option>Cotización especial</option><option>Documento recibido</option></select></Field>
        <Field label="Estado"><select className={inp} value={status} onChange={(e) => setStatus(e.target.value)}><option>Pendiente</option><option>Aprobado</option><option>Rechazado</option></select></Field>
        <Field label="Desde"><input className={inp} type="date" value={fromDate} onChange={(e) => setFromDate(e.target.value)} /></Field>
        <Field label="Hasta"><input className={inp} type="date" value={toDate} onChange={(e) => setToDate(e.target.value)} /></Field>
        <Field label="Analista"><select className={inp}><option>(Todos)</option><option>ANALISTA 01</option><option>ANALISTA 02</option></select></Field>
        <Field label="Cliente"><input className={inp} defaultValue="" /></Field>
      </div>
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto"><table className="w-full text-[11px] border-collapse"><thead className="bg-[#F3F6FA]"><tr><th className="px-2 py-2 text-left border-b border-slate-300">#</th><th className="px-2 py-2 text-left border-b border-slate-300">Cliente</th><th className="px-2 py-2 text-left border-b border-slate-300">Solicita</th><th className="px-2 py-2 text-left border-b border-slate-300">Vendedor</th><th className="px-2 py-2 text-right border-b border-slate-300">Monto</th><th className="px-2 py-2 text-left border-b border-slate-300">Línea Actual</th><th className="px-2 py-2 text-left border-b border-slate-300">Línea Solicitada</th><th className="px-2 py-2 text-left border-b border-slate-300">Estado</th><th className="px-2 py-2 text-left border-b border-slate-300">Acción</th></tr></thead><tbody><tr><td colSpan={9} className="px-2 py-4 text-sm text-slate-500">No hay solicitudes de crédito.</td></tr></tbody></table></div>
    </WindowShell>
  );
}

function PermisoUsuarioCreditos() {
  return (
    <MasterDetailForm
      title="Permiso de Usuario - Créditos"
      toolbar={stdToolbar19}
      header={
        <div className="grid grid-cols-4 gap-2">
          <Field label="Usuario"><input className={inp} defaultValue="" /></Field>
          <Field label="Perfil"><select className={inp}><option>ANALISTA</option><option>JEFE CRÉDITOS</option><option>AUDITOR</option></select></Field>
          <Field label="Estado"><select className={inp}><option>ACTIVO</option><option>INACTIVO</option></select></Field>
          <Field label="Vigencia"><input className={inp} type="date" defaultValue="2026-12-31" /></Field>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Usuario" className="w-56"><input className={inp} /></Field>
          <Field label="Perfil" className="w-40"><select className={inp}><option>(Todos)</option><option>ANALISTA</option><option>JEFE CRÉDITOS</option><option>AUDITOR</option></select></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>(Todos)</option><option>ACTIVO</option><option>INACTIVO</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Usuario", "Nombre", "Perfil", "Aprueba Línea", "Aprueba Cotiz.", "Límite Aprobación", "Estado", "Vigencia"]}
      rows={0}
    />
  );
}

function CotizTallerCredito() {
  return (
    <ListQueryForm
      title="Cotizaciones de Taller para Evaluación"
      toolbar={stdToolbar20}
      filters={
        <SearchBar>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Cliente" className="w-56"><input className={inp} defaultValue="(Todos)" /></Field>
          <Field label="Estado" className="w-36"><select className={inp}><option>(Todos)</option><option>PENDIENTE</option><option>APROBADO</option><option>RECHAZADO</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["N° Cotiz.", "Fecha", "Cliente", "OT", "Mon.", "Total", "Solicita", "Estado", "Obs."]}
      rows={0}
    />
  );
}

function RecepcionDocCreditos() {
  return (
    <MasterDetailForm
      title="Recepción de Documentos - Créditos"
      toolbar={stdToolbar21}
      header={
        <div className="grid grid-cols-5 gap-2">
          <Field label="N° Registro"><input className={`${inp} font-mono`} defaultValue="" /></Field>
          <Field label="Fecha"><input className={inp} type="date" defaultValue="2026-07-25" /></Field>
          <Field label="Cliente"><input className={inp} defaultValue="" /></Field>
          <Field label="Documento"><select className={inp}><option>LETRA</option><option>PAGARÉ</option><option>CONTRATO</option></select></Field>
          <Field label="Estado"><select className={inp}><option>RECEPCIONADO</option><option>OBSERVADO</option><option>DEVUELTO</option></select></Field>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Cliente" className="w-56"><input className={inp} defaultValue="(Todos)" /></Field>
          <Field label="Tipo" className="w-40"><select className={inp}><option>(Todos)</option><option>LETRA</option><option>PAGARÉ</option><option>CONTRATO</option></select></Field>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Fecha", "Cliente", "Documento", "Número", "Banco", "Vencimiento", "Monto", "Estado", "Recibido por"]}
      rows={0}
    />
  );
}

function SaldoBancosCreditos() {
  const [records, setRecords] = useState<Array<{
    id: string;
    date: string;
    bank: string;
    account: string;
    operation: string;
    description: string;
    currency: "PEN" | "USD";
    debit: number;
    credit: number;
    balance: number;
    status: "pendiente" | "conciliado";
  }>>([]);
  const [message, setMessage] = useState<string | null>(null);

  const totalDebit = records.reduce((acc, row) => acc + row.debit, 0);
  const totalCredit = records.reduce((acc, row) => acc + row.credit, 0);
  const saldoPen = records.filter((row) => row.currency === "PEN").reduce((acc, row) => acc + row.balance, 0);
  const saldoUsd = records.filter((row) => row.currency === "USD").reduce((acc, row) => acc + row.balance, 0);

  const handleLoadSample = () => {
    const seed = [
      { id: "sb-1", date: "2026-07-25", bank: "BCP", account: "191-1234567-0-12", operation: "DEP", description: "Cobranza cliente", currency: "PEN" as const, debit: 0, credit: 1250, balance: 1250, status: "pendiente" as const },
      { id: "sb-2", date: "2026-07-25", bank: "BBVA", account: "0011-098765", operation: "CHQ", description: "Pago proveedor", currency: "PEN" as const, debit: 480, credit: 0, balance: 770, status: "pendiente" as const },
      { id: "sb-3", date: "2026-07-25", bank: "INTERBANK", account: "88990011", operation: "TRF", description: "Transferencia interna", currency: "USD" as const, debit: 0, credit: 200, balance: 200, status: "conciliado" as const },
    ];
    setRecords(seed);
    setMessage("Movimientos cargados para conciliación.");
  };

  const handleConciliar = (id: string) => {
    setRecords((current) => current.map((row) => row.id === id ? { ...row, status: "conciliado" } : row));
    setMessage("Movimiento conciliado.");
  };

  return (
    <WindowShell title="Saldo de Bancos" toolbar={<>
      <button className={btn} onClick={handleLoadSample}><RefreshCw className="h-3.5 w-3.5" />Cargar Movimientos</button>
      <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      <button className={btn}><Printer className="h-3.5 w-3.5" />Imprimir</button>
    </>}>
      <div className="mx-1.5 mt-1.5 grid grid-cols-4 gap-2 text-[11px]">
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Saldo PEN:</span> <b className="font-mono text-slate-900">{saldoPen.toFixed(2)}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Saldo USD:</span> <b className="font-mono text-slate-900">{saldoUsd.toFixed(2)}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Abonos:</span> <b className="font-mono text-slate-900">{totalCredit.toFixed(2)}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Cargos:</span> <b className="font-mono text-slate-900">{totalDebit.toFixed(2)}</b></div>
      </div>
      <SearchBar>
        <Field label="Banco" className="w-44"><select className={inp}><option>(Todos)</option><option>BCP</option><option>BBVA</option><option>INTERBANK</option></select></Field>
        <Field label="Cuenta" className="w-52"><input className={inp} defaultValue="(Todas)" /></Field>
        <Field label="Moneda" className="w-24"><select className={inp}><option>(Todas)</option><option>PEN</option><option>USD</option></select></Field>
        <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
        <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
        <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
      </SearchBar>
      {message ? <div className="mb-2 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div> : null}
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]"><tr><th className="px-2 py-2 text-left border-b border-slate-300">Fecha</th><th className="px-2 py-2 text-left border-b border-slate-300">Banco</th><th className="px-2 py-2 text-left border-b border-slate-300">Cuenta</th><th className="px-2 py-2 text-left border-b border-slate-300">Operación</th><th className="px-2 py-2 text-left border-b border-slate-300">Descripción</th><th className="px-2 py-2 text-left border-b border-slate-300">Mon.</th><th className="px-2 py-2 text-right border-b border-slate-300">Cargo</th><th className="px-2 py-2 text-right border-b border-slate-300">Abono</th><th className="px-2 py-2 text-right border-b border-slate-300">Saldo</th><th className="px-2 py-2 text-left border-b border-slate-300">Estado</th><th className="px-2 py-2 text-left border-b border-slate-300">Acción</th></tr></thead>
          <tbody>
            {records.length === 0 ? (
              <tr><td colSpan={11} className="px-2 py-4 text-sm text-slate-500">No hay movimientos cargados.</td></tr>
            ) : records.map((row) => (
              <tr key={row.id}>
                <td className="px-2 py-2 border-b border-slate-200">{row.date}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.bank}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.account}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.operation}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.description}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.currency}</td>
                <td className="px-2 py-2 border-b border-slate-200 text-right font-mono">{row.debit.toFixed(2)}</td>
                <td className="px-2 py-2 border-b border-slate-200 text-right font-mono">{row.credit.toFixed(2)}</td>
                <td className="px-2 py-2 border-b border-slate-200 text-right font-mono">{row.balance.toFixed(2)}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.status}</td>
                <td className="px-2 py-2 border-b border-slate-200">
                  <button className={btn} onClick={() => handleConciliar(row.id)} disabled={row.status === "conciliado"}>Conciliar</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}

function TipoCambio() {
  const [date, setDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [currency, setCurrency] = useState("USD");
  const [buy, setBuy] = useState(3.408);
  const [sell, setSell] = useState(3.412);
  const [saving, setSaving] = useState(false);
  const [history, setHistory] = useState<Array<{ id: string; date: string; currency: string; buy: number; sell: number; source: string }>>([]);
  const [message, setMessage] = useState<string | null>(null);

  const handleSave = async () => {
    setSaving(true);
    try {
      const row = {
        id: `${currency}-${date}-${Date.now()}`,
        date,
        currency,
        buy,
        sell,
        source: "Manual",
      };
      setHistory((prev) => [row, ...prev].slice(0, 20));
      setMessage("Tipo de cambio guardado en historial.");
    } finally {
      setSaving(false);
    }
  };

  const handleRefreshSunat = () => {
    setMessage("Consulta SUNAT simulada: revise y confirme los valores antes de guardar.");
  };

  return (
    <WindowShell title="Mantenimiento del Tipo de Cambio">
      <div className="grid grid-cols-4 gap-2 mb-2 text-[11px]">
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Registros:</span> <b className="font-mono text-slate-900">{history.length}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Moneda:</span> <b className="font-mono text-slate-900">{currency}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Compra:</span> <b className="font-mono text-slate-900">{buy.toFixed(3)}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Venta:</span> <b className="font-mono text-slate-900">{sell.toFixed(3)}</b></div>
      </div>
      <div className="grid grid-cols-4 gap-3 max-w-2xl">
        <Field label="Fecha"><input className={inp} type="date" value={date} onChange={(e) => setDate(e.target.value)} /></Field>
        <Field label="Moneda"><select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}><option>USD — Dólares</option><option>EUR — Euros</option></select></Field>
        <Field label="Compra"><input className={inp} type="number" step="0.001" value={buy} onChange={(e) => setBuy(Number(e.target.value))} /></Field>
        <Field label="Venta"><input className={inp} type="number" step="0.001" value={sell} onChange={(e) => setSell(Number(e.target.value))} /></Field>
      </div>
      {message ? <div className="mt-2 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div> : null}
      <div className="mt-4"><div className="border border-slate-300 rounded-sm bg-white overflow-auto"><table className="w-full text-[11px] border-collapse"><thead className="bg-[#F3F6FA]"><tr><th className="px-2 py-2 text-left border-b border-slate-300">Fecha</th><th className="px-2 py-2 text-left border-b border-slate-300">Moneda</th><th className="px-2 py-2 text-right border-b border-slate-300">Compra</th><th className="px-2 py-2 text-right border-b border-slate-300">Venta</th><th className="px-2 py-2 text-left border-b border-slate-300">Fuente</th><th className="px-2 py-2 text-left border-b border-slate-300">Acción</th></tr></thead><tbody>{history.length === 0 ? <tr><td colSpan={6} className="px-2 py-4 text-sm text-slate-500">No hay cambios registrados.</td></tr> : history.map((row) => <tr key={row.id}><td className="px-2 py-2 border-b border-slate-200">{row.date}</td><td className="px-2 py-2 border-b border-slate-200">{row.currency}</td><td className="px-2 py-2 border-b border-slate-200 text-right font-mono">{row.buy.toFixed(3)}</td><td className="px-2 py-2 border-b border-slate-200 text-right font-mono">{row.sell.toFixed(3)}</td><td className="px-2 py-2 border-b border-slate-200">{row.source}</td><td className="px-2 py-2 border-b border-slate-200"><button className={btn}>Usar</button></td></tr>)}</tbody></table></div></div>
    </WindowShell>
  );
}

// ============================================================
// MACRO 2 · ALMACENES
// ============================================================
function DocIngresos() {
  return (
    <ListQueryForm
      title="Movimiento de Ingresos Almacén"
      toolbar={stdToolbarAlmacen}
      filters={
        <SearchBar>
          <Field label="Año" className="w-14"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
          <Field label="Mes" className="w-20"><select className={inp} defaultValue="JULIO"><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
          <Field label="Oficina" className="w-24"><select className={inp}><option>LIMA</option><option>AREQUIPA</option><option>TRUJILLO</option></select></Field>
          <Field label="Almacén" className="w-28"><select className={inp}><option>COMERCIAL</option><option>REPUESTOS</option><option>SERVICIOS</option></select></Field>
          <Field label="Tipo Documento" className="w-32"><select className={inp}><option>(Todos)</option><option>Factura Compra</option><option>Guía Proveedor</option><option>Ingreso Interno</option></select></Field>
          <Field label="Proveedor" className="w-56">
            <div className="flex gap-1">
              <input className={`${inp} flex-1`} defaultValue="(Todos)" />
              <button className={iconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
            </div>
          </Field>
          <Field label="Estado" className="w-24"><select className={inp}><option>(Todos)</option><option>GENERADO</option><option>ANULADO</option></select></Field>
          <Field label="Número" className="w-20"><input className={`${inp} font-mono`} /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["T.Doc.", "Documento", "Fecha", "# OT", "Cliente", "Mon.", "Total", "Estado", "N° Gasto"]}
      rows={0}
    />
  );
}

function ChequeoFI() {
  return (
    <ListQueryForm
      title="Chequeo de Facturas de Importación"
      toolbar={stdToolbarAlmacen}
      filters={
        <SearchBar>
          <Field label="Oficina" className="w-24"><select className={inp}><option>LIMA</option><option>AREQUIPA</option><option>TRUJILLO</option></select></Field>
          <Field label="Almacén" className="w-28"><select className={inp}><option>SERVICIOS</option><option>COMERCIAL</option><option>REPUESTOS</option></select></Field>
          <Field label="Proveedor" className="w-56">
            <div className="flex gap-1">
              <input className={`${inp} flex-1`} defaultValue="(Todos)" />
              <button className={iconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
            </div>
          </Field>
          <Field label="Fecha Inicio" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Fecha Fin" className="w-32"><input className={inp} type="date" defaultValue="2026-07-21" /></Field>
          <Field label="Estado" className="w-24"><select className={inp}><option>(Todos)</option><option>GENERADO</option><option>RECHAZADO</option></select></Field>
          <Field label="Embarque" className="w-24"><input className={inp} /></Field>
          <Field label="Número" className="w-20"><input className={`${inp} font-mono`} /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Número", "Fecha", "Proveedor", "Embarque", "Total ($)", "Estado", "Resultado", "Acción"]}
      rows={0}
    />
  );
}

function AtenderOT() {
  return (
    <ListQueryForm
      title="Atender Job"
      toolbar={stdToolbarAlmacen}
      filters={
        <SearchBar>
          <Field label="Locación OT" className="w-32"><select className={inp}><option>LIMA</option><option>AREQUIPA</option><option>TRUJILLO</option></select></Field>
          <Field label="Cliente" className="w-56"><input className={inp} defaultValue="(Todos)" /></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>(Todos)</option><option>PENDIENTE</option><option>EN PROCESO</option><option>ATENDIDO</option></select></Field>
          <Field label="Número" className="w-20"><input className={`${inp} font-mono`} /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["OT", "Descripción", "Cliente", "Estado", "Prioridad", "Responsable", "Acción"]}
      rows={0}
    />
  );
}

function Productos() {
  const [items, setItems] = useState<InventoryItem[]>([]);
  const [selectedItemId, setSelectedItemId] = useState<string>("");
  const [sku, setSku] = useState("");
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");
  const [category, setCategory] = useState("Repuestos");
  const [unit, setUnit] = useState("UND");
  const [supplier, setSupplier] = useState("");
  const [stock, setStock] = useState(0);
  const [minStock, setMinStock] = useState(10);
  const [costPrice, setCostPrice] = useState(0);
  const [salePrice, setSalePrice] = useState(0);
  const [search, setSearch] = useState("");
  const [loading, setLoading] = useState(true);
  const [saving, setSaving] = useState(false);
  const [message, setMessage] = useState<string | null>(null);
  const [importing, setImporting] = useState(false);
  const fileInputRef = useRef<HTMLInputElement | null>(null);

  const loadItems = async (query?: string) => {
    setLoading(true);
    setMessage(null);
    try {
      const data = await fetchInventory(query?.trim() ? query : undefined);
      setItems(data);
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error cargando productos");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadItems();
  }, []);

  const clearForm = () => {
    setSelectedItemId("");
    setSku("");
    setName("");
    setDescription("");
    setCategory("Repuestos");
    setUnit("UND");
    setSupplier("");
    setStock(0);
    setMinStock(10);
    setCostPrice(0);
    setSalePrice(0);
    setMessage(null);
  };

  const handleSelect = (item: InventoryItem) => {
    setSelectedItemId(item.id);
    setSku(item.sku);
    setName(item.name);
    setDescription(item.description ?? "");
    setCategory(item.category ?? "Repuestos");
    setUnit(item.unit ?? "UND");
    setSupplier(item.supplier ?? "");
    setStock(item.stock ?? 0);
    setMinStock(item.min_stock ?? 0);
    setCostPrice(item.cost_price ?? 0);
    setSalePrice(item.sale_price ?? 0);
    setMessage(null);
  };

  const handleSave = async () => {
    if (!sku.trim() || !name.trim()) {
      setMessage("SKU y nombre son obligatorios.");
      return;
    }

    setSaving(true);
    try {
      if (selectedItemId) {
        const updated = await updateInventoryItem(selectedItemId, {
          name,
          description,
          category,
          unit,
          supplier,
          stock,
          min_stock: minStock,
          cost_price: costPrice,
          sale_price: salePrice,
        });
        setItems((current) => current.map((item) => item.id === updated.id ? updated : item));
        setMessage(`Producto actualizado: ${updated.sku}`);
      } else {
        const created = await createInventoryItem({
          sku,
          name,
          description,
          category,
          unit,
          supplier,
          stock,
          min_stock: minStock,
          cost_price: costPrice,
          sale_price: salePrice,
        });
        setItems((current) => [created, ...current]);
        setSelectedItemId(created.id);
        setMessage(`Producto creado: ${created.sku}`);
      }
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo guardar el producto");
    } finally {
      setSaving(false);
    }
  };

  const handleSearch = async () => {
    await loadItems(search);
  };

  const handleExport = async () => {
    try {
      const blob = await exportSigecoomInventory("csv");
      downloadBlob(blob, "inventario_export.csv");
      setMessage("Exportación de inventario iniciada.");
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo exportar el inventario");
    }
  };

  const handleImportClick = () => {
    fileInputRef.current?.click();
  };

  const handleImport = async (event: React.ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files?.[0];
    if (!file) {
      return;
    }
    setImporting(true);
    setMessage(null);
    try {
      const result = await importSigecoomInventory(file);
      setMessage(`Importados ${result.created} nuevos / actualizados ${result.updated}`);
      await loadItems();
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo importar el inventario");
    } finally {
      setImporting(false);
      event.target.value = "";
    }
  };

  const handleLabel = () => {
    if (!selectedItemId) {
      setMessage("Seleccione un producto para generar etiqueta.");
      return;
    }
    setMessage(`Etiqueta generada para ${sku}`);
  };

  return (
    <WindowShell title="Maestro de Productos — Ficha SKU"
      toolbar={<>
        <button className={btnPrimary} onClick={handleSave} disabled={saving}><Save className="h-3.5 w-3.5" />{saving ? "Guardando..." : "Guardar"}</button>
        <button className={btn} onClick={clearForm}><Plus className="h-3.5 w-3.5" />Nuevo</button>
        <button className={btn} onClick={handleSearch}><Search className="h-3.5 w-3.5" />Buscar</button>
        <button className={btn} onClick={handleLabel}><Printer className="h-3.5 w-3.5" />Etiqueta</button>
        <button className={btn} onClick={handleImportClick} disabled={importing}><FileSpreadsheet className="h-3.5 w-3.5" />Importar Excel</button>
        <button className={btn} onClick={handleExport}><FileDown className="h-3.5 w-3.5" />Exportar CSV</button>
        <input ref={fileInputRef} type="file" accept=".csv" className="hidden" onChange={handleImport} />
      </>}
    >
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="grid grid-cols-2 gap-4">
        <div className="border border-slate-300 rounded-sm p-3 bg-white">
          <div className="text-[11px] font-semibold text-[#2A3F55] mb-2 uppercase">Identificación</div>
          <div className="grid grid-cols-2 gap-2">
            <Field label="Código SKU"><input className={inp} value={sku} onChange={(e) => setSku(e.target.value)} /></Field>
            <Field label="Descripción" className="col-span-2"><input className={inp} value={name} onChange={(e) => setName(e.target.value)} /></Field>
            <Field label="Código de Barras"><input className={inp} value={description} onChange={(e) => setDescription(e.target.value)} /></Field>
            <Field label="Categoría"><select className={inp} value={category} onChange={(e) => setCategory(e.target.value)}><option>Repuestos</option><option>Herramientas</option><option>Consumibles</option></select></Field>
            <Field label="Unidad Medida"><select className={inp} value={unit} onChange={(e) => setUnit(e.target.value)}><option>UND</option><option>KG</option><option>MT</option></select></Field>
            <Field label="Marca"><input className={inp} value={supplier} onChange={(e) => setSupplier(e.target.value)} /></Field>
          </div>
        </div>
        <div className="border border-slate-300 rounded-sm p-3 bg-white">
          <div className="text-[11px] font-semibold text-[#2A3F55] mb-2 uppercase">Stocks y Precios</div>
          <div className="grid grid-cols-2 gap-2">
            <Field label="Stock Actual"><input className={inp} type="number" value={stock} onChange={(e) => setStock(Number(e.target.value))} /></Field>
            <Field label="Stock Mínimo"><input className={inp} type="number" value={minStock} onChange={(e) => setMinStock(Number(e.target.value))} /></Field>
            <Field label="Costo"><input className={inp} type="number" value={costPrice} onChange={(e) => setCostPrice(Number(e.target.value))} /></Field>
            <Field label="Precio Venta"><input className={inp} type="number" value={salePrice} onChange={(e) => setSalePrice(Number(e.target.value))} /></Field>
            <Field label="Proveedor"><input className={inp} value={supplier} onChange={(e) => setSupplier(e.target.value)} /></Field>
            <Field label="Moneda"><select className={inp}><option>PEN</option><option>USD</option></select></Field>
          </div>
        </div>
      </div>
      <div className="mt-4 border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]"><tr>
            <th className="px-2 py-2 text-left border-b border-slate-300">SKU</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Descripción</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Categoría</th>
            <th className="px-2 py-2 text-right border-b border-slate-300">Stock</th>
            <th className="px-2 py-2 text-right border-b border-slate-300">Precio</th>
          </tr></thead>
          <tbody>
            {loading ? (
              <tr><td colSpan={5} className="px-2 py-4 text-sm text-slate-500">Cargando productos...</td></tr>
            ) : items.length === 0 ? (
              <tr><td colSpan={5} className="px-2 py-4 text-sm text-slate-500">No hay productos registrados.</td></tr>
            ) : items.map((item) => (
              <tr key={item.id} className={`hover:bg-slate-50 ${selectedItemId === item.id ? "bg-slate-100" : ""}`} onClick={() => handleSelect(item)}>
                <td className="px-2 py-2 border-b border-slate-200">{item.sku}</td>
                <td className="px-2 py-2 border-b border-slate-200">{item.name}</td>
                <td className="px-2 py-2 border-b border-slate-200">{item.category || "—"}</td>
                <td className="px-2 py-2 text-right border-b border-slate-200">{item.stock ?? 0}</td>
                <td className="px-2 py-2 text-right border-b border-slate-200">{item.sale_price?.toFixed(2) ?? "0.00"}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}

function ActMinMax() {
  return (
    <WindowShell title="Actualización masiva de Stock Min / Max"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Aplicar cambios</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Importar Excel</button>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtrar categoría</button>
      </>}>
      <DataTable columns={["Código", "Producto", "Categoría", "Stock Actual", "Min Actual", "Max Actual", "Min Nuevo", "Max Nuevo"]} rows={10} />
    </WindowShell>
  );
}

function Ubicaciones() {
  const [locations, setLocations] = useState<Location[]>([]);
  const [selectedLocationId, setSelectedLocationId] = useState("");
  const [code, setCode] = useState("");
  const [warehouse, setWarehouse] = useState("Central Lima");
  const [aisle, setAisle] = useState("");
  const [shelf, setShelf] = useState("");
  const [row, setRow] = useState("");
  const [level, setLevel] = useState("");
  const [capacity, setCapacity] = useState<number | "">("");
  const [occupancy, setOccupancy] = useState<number | "">("");
  const [loading, setLoading] = useState(true);
  const [saving, setSaving] = useState(false);
  const [message, setMessage] = useState<string | null>(null);

  const resetForm = () => {
    setSelectedLocationId("");
    setCode("");
    setWarehouse("Central Lima");
    setAisle("");
    setShelf("");
    setRow("");
    setLevel("");
    setCapacity("");
    setOccupancy("");
    setMessage(null);
  };

  const loadLocations = async () => {
    setLoading(true);
    setMessage(null);
    try {
      const data = await fetchSigecoomLocations();
      setLocations(data);
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error cargando ubicaciones");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadLocations();
  }, []);

  const handleSave = async () => {
    if (!code.trim() || !warehouse.trim()) {
      setMessage("Código y almacén son obligatorios.");
      return;
    }
    setSaving(true);
    setMessage(null);
    try {
      const payload = {
        code: code.trim(),
        warehouse: warehouse.trim(),
        aisle: aisle.trim() || undefined,
        shelf: shelf.trim() || undefined,
        row: row.trim() || undefined,
        level: level.trim() || undefined,
        description: undefined,
        capacity: capacity === "" ? undefined : Number(capacity),
        occupancy_percent: occupancy === "" ? undefined : Number(occupancy),
      };
      if (selectedLocationId) {
        await updateSigecoomLocation(selectedLocationId, payload);
        setMessage("Ubicación actualizada correctamente.");
      } else {
        await createSigecoomLocation(payload);
        setMessage("Ubicación creada correctamente.");
      }
      resetForm();
      await loadLocations();
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo guardar la ubicación");
    } finally {
      setSaving(false);
    }
  };

  const handleSelect = (location: Location) => {
    setSelectedLocationId(location.id);
    setCode(location.code);
    setWarehouse(location.warehouse);
    setAisle(location.aisle ?? "");
    setShelf(location.shelf ?? "");
    setRow(location.row ?? "");
    setLevel(location.level ?? "");
    setCapacity(location.capacity ?? "");
    setOccupancy(location.occupancy_percent ?? "");
    setMessage(null);
  };

  const handleDelete = async () => {
    if (!selectedLocationId) {
      setMessage("Seleccione primero una ubicación para eliminar.");
      return;
    }
    setSaving(true);
    setMessage(null);
    try {
      await deleteSigecoomLocation(selectedLocationId);
      setMessage("Ubicación eliminada correctamente.");
      resetForm();
      await loadLocations();
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo eliminar la ubicación");
    } finally {
      setSaving(false);
    }
  };

  return (
    <WindowShell title="Ubicaciones de Almacén — Configuración geométrica"
    >
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="grid grid-cols-5 gap-2 mb-3">
        <Field label="Código"><input className={inp} value={code} onChange={(e) => setCode(e.target.value)} placeholder="UB-001" /></Field>
        <Field label="Almacén"><select className={inp} value={warehouse} onChange={(e) => setWarehouse(e.target.value)}><option>Central Lima</option><option>Norte</option><option>Sur</option></select></Field>
        <Field label="Pasillo"><input className={inp} value={aisle} onChange={(e) => setAisle(e.target.value)} /></Field>
        <Field label="Estantería"><input className={inp} value={shelf} onChange={(e) => setShelf(e.target.value)} /></Field>
        <Field label="Fila"><input className={inp} value={row} onChange={(e) => setRow(e.target.value)} /></Field>
        <Field label="Nivel"><input className={inp} value={level} onChange={(e) => setLevel(e.target.value)} /></Field>
        <Field label="Capacidad"><input className={inp} type="number" value={capacity} onChange={(e) => setCapacity(e.target.value === "" ? "" : Number(e.target.value))} /></Field>
        <Field label="Ocupación %"><input className={inp} type="number" value={occupancy} onChange={(e) => setOccupancy(e.target.value === "" ? "" : Number(e.target.value))} /></Field>
      </div>
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]"><tr>
            <th className="px-2 py-2 text-left border-b border-slate-300">Sel</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Código</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Almacén</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Pasillo</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Estantería</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Fila</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Nivel</th>
            <th className="px-2 py-2 text-right border-b border-slate-300">Capacidad</th>
            <th className="px-2 py-2 text-right border-b border-slate-300">Ocupación</th>
          </tr></thead>
          <tbody>
            {loading ? (
              <tr><td colSpan={9} className="px-2 py-4 text-sm text-slate-500">Cargando ubicaciones...</td></tr>
            ) : locations.length === 0 ? (
              <tr><td colSpan={9} className="px-2 py-4 text-sm text-slate-500">No hay ubicaciones registradas.</td></tr>
            ) : locations.map((location) => (
              <tr key={location.id} className={`hover:bg-slate-50 ${selectedLocationId === location.id ? "bg-slate-100" : ""}`} onClick={() => handleSelect(location)}>
                <td className="px-2 py-2 border-b border-slate-200 text-center"><input type="radio" name="selectedLocation" checked={selectedLocationId === location.id} readOnly /></td>
                <td className="px-2 py-2 border-b border-slate-200">{location.code}</td>
                <td className="px-2 py-2 border-b border-slate-200">{location.warehouse}</td>
                <td className="px-2 py-2 border-b border-slate-200">{location.aisle}</td>
                <td className="px-2 py-2 border-b border-slate-200">{location.shelf}</td>
                <td className="px-2 py-2 border-b border-slate-200">{location.row}</td>
                <td className="px-2 py-2 border-b border-slate-200">{location.level}</td>
                <td className="px-2 py-2 text-right border-b border-slate-200">{location.capacity ?? "-"}</td>
                <td className="px-2 py-2 text-right border-b border-slate-200">{location.occupancy_percent ?? "-"}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}

function TransitoDocs() {
  return (
    <ListQueryForm
      title="Transferencias Internas"
      toolbar={stdToolbarAlmacen}
      extraTop={
        <div className="mx-1.5 mt-1.5 grid grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">En proceso:</span> <b className="font-mono text-amber-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Cerradas:</span> <b className="font-mono text-emerald-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Anuladas:</span> <b className="font-mono text-red-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Monto:</span> <b className="font-mono text-slate-900">0.00</b></div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Año" className="w-14"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
          <Field label="Mes" className="w-20"><select className={inp} defaultValue="JULIO"><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
          <Field label="Oficina" className="w-24"><select className={inp}><option>LIMA</option><option>AREQUIPA</option><option>TRUJILLO</option></select></Field>
          <Field label="Almacén" className="w-28"><select className={inp}><option>COMERCIAL</option><option>REPUESTOS</option><option>SERVICIOS</option></select></Field>
          <Field label="Cliente" className="w-56"><input className={`${inp}`} defaultValue="(Todos)" /></Field>
          <Field label="Estado" className="w-24"><select className={inp}><option>(Todos)</option><option>GENERADO</option><option>EN PROCESO</option><option>CERRADO</option></select></Field>
          <Field label="# OT" className="w-20"><input className={`${inp} font-mono`} /></Field>
          <Field label="Número" className="w-20"><input className={`${inp} font-mono`} /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Número", "Fecha", "# OT", "Cliente", "Mon.", "Total", "Est.", "Origen", "Destino", "Acción"]}
      rows={0}
    />
  );
}

function MemosTransferenciasInternas() {
  return (
    <ListQueryForm
      title="Memos de Transferencias Internas"
      toolbar={stdToolbarAlmacen}
      extraTop={
        <div className="mx-1.5 mt-1.5 grid grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Generados:</span> <b className="font-mono text-slate-900">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Aprobados:</span> <b className="font-mono text-emerald-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Anulados:</span> <b className="font-mono text-red-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Total S/:</span> <b className="font-mono text-slate-900">0.00</b></div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Año" className="w-14"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
          <Field label="Mes" className="w-20"><select className={inp} defaultValue="JULIO"><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
          <Field label="Oficina" className="w-24"><select className={inp}><option>LIMA</option><option>AREQUIPA</option><option>TRUJILLO</option></select></Field>
          <Field label="Almacén" className="w-28"><select className={inp}><option>COMERCIAL</option><option>REPUESTOS</option><option>SERVICIOS</option></select></Field>
          <Field label="Tipo" className="w-28"><select className={inp}><option>Memo de Tran</option><option>Generado</option></select></Field>
          <Field label="Cliente" className="w-56"><input className={`${inp}`} defaultValue="(Todos)" /></Field>
          <Field label="Estado" className="w-24"><select className={inp}><option>(Todos)</option><option>GENERADO</option><option>ANULADO</option></select></Field>
          <Field label="Número" className="w-20"><input className={`${inp} font-mono`} /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Número", "Fecha", "Cliente", "Tipo", "Mon.", "Total", "Estado", "Aprobador", "Acción"]}
      rows={0}
    />
  );
}

// ============================================================
// MACRO 2 · IMPORTACIONES
// ============================================================
function OrdenImportacion() {
  const [orders, setOrders] = useState<SigecoomSale[]>([]);
  const [selectedOrderId, setSelectedOrderId] = useState("");
  const [oiNumber, setOiNumber] = useState("");
  const [date, setDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [foreignSupplier, setForeignSupplier] = useState("");
  const [country, setCountry] = useState("");
  const [incoterm, setIncoterm] = useState("FOB");
  const [currency, setCurrency] = useState("USD");
  const [container, setContainer] = useState("");
  const [customsAgency, setCustomsAgency] = useState("");
  const [dua, setDua] = useState("");
  const [freight, setFreight] = useState<number | "">("");
  const [etaPort, setEtaPort] = useState("");
  const [etaWarehouse, setEtaWarehouse] = useState("");
  const [shippingLine, setShippingLine] = useState("");
  const [loading, setLoading] = useState(true);
  const [saving, setSaving] = useState(false);
  const [message, setMessage] = useState<string | null>(null);

  const loadOrders = async () => {
    setLoading(true);
    setMessage(null);
    try {
      const data = await fetchSigecoomSales();
      setOrders(data.filter((sale) => sale.type.toLowerCase().includes("orden import")));
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error cargando órdenes de importación");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadOrders();
  }, []);

  const resetForm = () => {
    setSelectedOrderId("");
    setOiNumber("");
    setDate(new Date().toISOString().slice(0, 10));
    setForeignSupplier("");
    setCountry("");
    setIncoterm("FOB");
    setCurrency("USD");
    setContainer("");
    setCustomsAgency("");
    setDua("");
    setFreight("");
    setEtaPort("");
    setEtaWarehouse("");
    setShippingLine("");
    setMessage(null);
  };

  const handleSave = async () => {
    if (!oiNumber.trim() || !foreignSupplier.trim()) {
      setMessage("Complete el Nº de OI y el proveedor extranjero.");
      return;
    }

    setSaving(true);
    setMessage(null);
    try {
      const extra_data = {
        oi_number: oiNumber.trim(),
        country: country.trim(),
        incoterm,
        currency,
        container: container.trim(),
        customs_agency: customsAgency.trim(),
        dua: dua.trim(),
        freight: freight === "" ? 0 : Number(freight),
        eta_port: etaPort,
        eta_warehouse: etaWarehouse,
        shipping_line: shippingLine.trim(),
      };

      if (selectedOrderId) {
        await updateSigecoomSale(selectedOrderId, {
          client_id: foreignSupplier.trim(),
          date,
          extra_data,
          subtotal: freight === "" ? 0 : Number(freight),
          total: freight === "" ? 0 : Number(freight),
        });
        setMessage("Orden de importación actualizada correctamente.");
      } else {
        await createSigecoomSale({
          type: "Orden Importación",
          series: "OI",
          number: parseInt(oiNumber.replace(/\D/g, "")) || Math.floor(Math.random() * 1000) + 1,
          date,
          client_id: foreignSupplier.trim(),
          items: [{ description: `Orden de importación ${oiNumber}`, unit: "unidad", quantity: 1, price: freight === "" ? 0 : Number(freight) }],
          subtotal: freight === "" ? 0 : Number(freight),
          tax: 0,
          total: freight === "" ? 0 : Number(freight),
          extra_data,
        });
        setMessage("Orden de importación registrada correctamente.");
      }
      await loadOrders();
      resetForm();
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo guardar la orden de importación");
    } finally {
      setSaving(false);
    }
  };

  const handleSelect = (order: SigecoomSale) => {
    setSelectedOrderId(order.id);
    setOiNumber(order.extra_data?.oi_number ?? order.series ?? "");
    setDate(order.date.slice(0, 10));
    setForeignSupplier(order.client_id ?? "");
    setCountry(order.extra_data?.country ?? "");
    setIncoterm(order.extra_data?.incoterm ?? "FOB");
    setCurrency(order.extra_data?.currency ?? "USD");
    setContainer(order.extra_data?.container ?? "");
    setCustomsAgency(order.extra_data?.customs_agency ?? "");
    setDua(order.extra_data?.dua ?? "");
    setFreight(order.extra_data?.freight ?? "");
    setEtaPort(order.extra_data?.eta_port ?? "");
    setEtaWarehouse(order.extra_data?.eta_warehouse ?? "");
    setShippingLine(order.extra_data?.shipping_line ?? "");
    setMessage(null);
  };

  return (
    <WindowShell title="Orden de Importación"
    >
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="grid grid-cols-4 gap-3">
        <Field label="OI Nº"><input className={inp} placeholder="OI-2026-0001" value={oiNumber} onChange={(e) => setOiNumber(e.target.value)} /></Field>
        <Field label="Fecha"><input className={inp} type="date" value={date} onChange={(e) => setDate(e.target.value)} /></Field>
        <Field label="Proveedor Extranjero" className="col-span-2"><input className={inp} value={foreignSupplier} onChange={(e) => setForeignSupplier(e.target.value)} /></Field>
        <Field label="País"><input className={inp} value={country} onChange={(e) => setCountry(e.target.value)} /></Field>
        <Field label="Incoterm"><select className={inp} value={incoterm} onChange={(e) => setIncoterm(e.target.value)}><option>FOB</option><option>CIF</option><option>EXW</option><option>DDP</option></select></Field>
        <Field label="Moneda"><select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}><option>USD</option><option>EUR</option></select></Field>
        <Field label="Nº Contenedor"><input className={inp} value={container} onChange={(e) => setContainer(e.target.value)} /></Field>
        <Field label="Agencia Aduana" className="col-span-2"><input className={inp} value={customsAgency} onChange={(e) => setCustomsAgency(e.target.value)} /></Field>
        <Field label="Dua / Dami"><input className={inp} value={dua} onChange={(e) => setDua(e.target.value)} /></Field>
        <Field label="Flete Internacional"><input className={inp} type="number" value={freight} onChange={(e) => setFreight(e.target.value === "" ? "" : Number(e.target.value))} /></Field>
        <Field label="ETA Puerto"><input className={inp} type="date" value={etaPort} onChange={(e) => setEtaPort(e.target.value)} /></Field>
        <Field label="ETA Almacén"><input className={inp} type="date" value={etaWarehouse} onChange={(e) => setEtaWarehouse(e.target.value)} /></Field>
        <Field label="Naviera"><input className={inp} value={shippingLine} onChange={(e) => setShippingLine(e.target.value)} /></Field>
      </div>
      <div className="mt-3 border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]"><tr>
            <th className="px-2 py-2 text-left border-b border-slate-300">Sel</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">OI Nº</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Proveedor</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Incoterm</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">País</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Flete</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">ETA Puerto</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">ETA Almacén</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Estado</th>
          </tr></thead>
          <tbody>
            {loading ? (
              <tr><td colSpan={9} className="px-2 py-4 text-sm text-slate-500">Cargando órdenes de importación...</td></tr>
            ) : orders.length === 0 ? (
              <tr><td colSpan={9} className="px-2 py-4 text-sm text-slate-500">No hay órdenes de importación registradas.</td></tr>
            ) : orders.map((order) => (
              <tr key={order.id} className={`hover:bg-slate-50 ${selectedOrderId === order.id ? "bg-slate-100" : ""}`} onClick={() => handleSelect(order)}>
                <td className="px-2 py-2 border-b border-slate-200 text-center"><input type="radio" name="selectedOrder" checked={selectedOrderId === order.id} readOnly /></td>
                <td className="px-2 py-2 border-b border-slate-200">{order.extra_data?.oi_number ?? order.series}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.client_id}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.extra_data?.incoterm}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.extra_data?.country}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.extra_data?.freight ?? 0}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.extra_data?.eta_port}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.extra_data?.eta_warehouse}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.status}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}

// ============================================================
// MACRO 2 · ACTIVOS
// ============================================================
function ActivosFijos() {
  const [assets, setAssets] = useState<InventoryItem[]>([]);
  const [selectedAssetId, setSelectedAssetId] = useState("");
  const [sku, setSku] = useState("");
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");
  const [category, setCategory] = useState("Activo Fijo");
  const [unit, setUnit] = useState("UND");
  const [acquisitionDate, setAcquisitionDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [costPrice, setCostPrice] = useState(0);
  const [bookValue, setBookValue] = useState(0);
  const [responsible, setResponsible] = useState("");
  const [location, setLocation] = useState("");
  const [status, setStatus] = useState("Óptimo");
  const [search, setSearch] = useState("");
  const [loading, setLoading] = useState(true);
  const [saving, setSaving] = useState(false);
  const [message, setMessage] = useState<string | null>(null);

  const loadAssets = async (query?: string) => {
    setLoading(true);
    setMessage(null);
    try {
      const data = await fetchInventory(query?.trim() ? query : undefined);
      setAssets(data.filter((item) =>
        item.category?.toLowerCase().includes("activo") ||
        item.description?.toLowerCase().includes("activo") ||
        item.name.toLowerCase().includes("activo")
      ));
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error cargando activos fijos");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadAssets();
  }, []);

  const clearForm = () => {
    setSelectedAssetId("");
    setSku("");
    setName("");
    setDescription("");
    setCategory("Activo Fijo");
    setUnit("UND");
    setAcquisitionDate(new Date().toISOString().slice(0, 10));
    setCostPrice(0);
    setBookValue(0);
    setResponsible("");
    setLocation("");
    setStatus("Óptimo");
    setMessage(null);
  };

  const handleSelectAsset = (item: InventoryItem) => {
    setSelectedAssetId(item.id);
    setSku(item.sku);
    setName(item.name);
    setDescription(item.description ?? "");
    setCategory(item.category ?? "Activo Fijo");
    setUnit(item.unit ?? "UND");
    setCostPrice(item.cost_price ?? 0);
    setBookValue(item.sale_price ?? 0);
    setResponsible(item.supplier ?? "");
    setLocation(item.category ?? "");
    setStatus(item.active === 1 ? "Activo" : "Inactivo");
    setMessage(null);
  };

  const handleSave = async () => {
    if (!sku.trim() || !name.trim()) {
      setMessage("SKU y descripción son obligatorios.");
      return;
    }

    setSaving(true);
    setMessage(null);

    try {
      if (selectedAssetId) {
        const updated = await updateInventoryItem(selectedAssetId, {
          name,
          description,
          category,
          unit,
          supplier: responsible,
          cost_price: costPrice,
          sale_price: bookValue,
          active: status === "Activo" ? 1 : 0,
        });
        setAssets((current) => current.map((item) => item.id === updated.id ? updated : item));
        setMessage(`Activo fijo actualizado: ${updated.sku}`);
      } else {
        const created = await createInventoryItem({
          sku,
          name,
          description,
          category,
          unit,
          supplier: responsible,
          cost_price: costPrice,
          sale_price: bookValue,
          stock: 1,
          min_stock: 0,
        });
        setAssets((current) => [created, ...current]);
        setSelectedAssetId(created.id);
        setMessage(`Activo fijo creado: ${created.sku}`);
      }
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo guardar el activo fijo");
    } finally {
      setSaving(false);
    }
  };

  const visibleAssets = assets.filter((item) => {
    const query = search.trim().toLowerCase();
    if (!query) return true;
    return [item.sku, item.name, item.category, item.description, item.supplier]
      .some((value) => value?.toLowerCase().includes(query));
  });

  return (
    <WindowShell title="Activos Fijos — Inventario"
    >
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="grid grid-cols-4 gap-3 mb-3">
        <Field label="Buscar Activo" className="col-span-2"><input className={inp} value={search} onChange={(e) => setSearch(e.target.value)} placeholder="Código, nombre o categoría" /></Field>
        <Field label="SKU"><input className={inp} value={sku} onChange={(e) => setSku(e.target.value)} placeholder="AF-0001" /></Field>
        <Field label="Categoría"><input className={inp} value={category} onChange={(e) => setCategory(e.target.value)} /></Field>
        <Field label="Descripción" className="col-span-2"><input className={inp} value={name} onChange={(e) => setName(e.target.value)} /></Field>
        <Field label="Fecha Adquisición"><input className={inp} type="date" value={acquisitionDate} onChange={(e) => setAcquisitionDate(e.target.value)} /></Field>
        <Field label="Costo Adquisición"><input className={inp} type="number" value={costPrice} onChange={(e) => setCostPrice(Number(e.target.value))} /></Field>
        <Field label="Valor en Libros"><input className={inp} type="number" value={bookValue} onChange={(e) => setBookValue(Number(e.target.value))} /></Field>
        <Field label="Responsable"><input className={inp} value={responsible} onChange={(e) => setResponsible(e.target.value)} /></Field>
        <Field label="Ubicación / Área"><input className={inp} value={location} onChange={(e) => setLocation(e.target.value)} /></Field>
        <Field label="Estado"><select className={inp} value={status} onChange={(e) => setStatus(e.target.value)}><option>Óptimo</option><option>Bueno</option><option>Regular</option><option>Baja</option><option>Inactivo</option></select></Field>
        <Field label="Departamento" className="col-span-2"><input className={inp} placeholder="Área interna" /></Field>
      </div>

      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]"><tr>
            <th className="px-2 py-2 text-left border-b border-slate-300">SKU</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Activo</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Categoría</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Costo</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Valor Libros</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Responsable</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Estado</th>
          </tr></thead>
          <tbody>
            {loading ? (
              <tr><td colSpan={7} className="px-2 py-4 text-sm text-slate-500">Cargando activos fijos...</td></tr>
            ) : visibleAssets.length === 0 ? (
              <tr><td colSpan={7} className="px-2 py-4 text-sm text-slate-500">No se encontraron activos fijos.</td></tr>
            ) : visibleAssets.map((asset) => (
              <tr key={asset.id} className={`hover:bg-slate-50 ${selectedAssetId === asset.id ? "bg-slate-100" : ""}`} onClick={() => handleSelectAsset(asset)}>
                <td className="px-2 py-2 border-b border-slate-200">{asset.sku}</td>
                <td className="px-2 py-2 border-b border-slate-200">{asset.name}</td>
                <td className="px-2 py-2 border-b border-slate-200">{asset.category}</td>
                <td className="px-2 py-2 border-b border-slate-200">{asset.cost_price?.toFixed(2)}</td>
                <td className="px-2 py-2 border-b border-slate-200">{asset.sale_price?.toFixed(2)}</td>
                <td className="px-2 py-2 border-b border-slate-200">{asset.supplier}</td>
                <td className="px-2 py-2 border-b border-slate-200">{asset.active === 1 ? "Activo" : "Inactivo"}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}

// ============================================================
// MACRO 3 · COSTOS
// ============================================================
function ValorizarFI() {
  const [items, setItems] = useState<InventoryItem[]>([]);
  const [search, setSearch] = useState("");
  const [oiNumber, setOiNumber] = useState("OI-2026-0001");
  const [currency, setCurrency] = useState("USD");
  const [exchangeRate, setExchangeRate] = useState("3.411");
  const [freight, setFreight] = useState(0);
  const [insurance, setInsurance] = useState(0);
  const [customs, setCustoms] = useState(0);
  const [otherCosts, setOtherCosts] = useState(0);
  const [baseProrrateo, setBaseProrrateo] = useState("Valor FOB");
  const [selectedIds, setSelectedIds] = useState<string[]>([]);
  const [loading, setLoading] = useState(true);
  const [saving, setSaving] = useState(false);
  const [message, setMessage] = useState<string | null>(null);

  const loadItems = async (query?: string) => {
    setLoading(true);
    setMessage(null);
    try {
      const data = await fetchInventory(query?.trim() ? query : undefined);
      setItems(data);
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error cargando inventario");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadItems();
  }, []);

  const computedCosts = items.map((item) => {
    const stock = item.stock ?? 1;
    const baseValue = (item.cost_price ?? 0) * stock;
    return {
      ...item,
      stock,
      baseValue,
    };
  });

  const totalBase = computedCosts.reduce((sum, item) => sum + item.baseValue, 0);
  const totalExtras = freight + insurance + customs + otherCosts;

  const previewItems = computedCosts.map((item) => {
    const ratio = totalBase > 0 ? item.baseValue / totalBase : 1 / Math.max(items.length, 1);
    const proratedCost = totalExtras * ratio;
    const costPerUnit = item.stock > 0 ? proratedCost / item.stock : proratedCost;
    const netCost = (item.cost_price ?? 0) + costPerUnit;
    return {
      ...item,
      ratio,
      proratedCost,
      costPerUnit,
      netCost,
    };
  });

  const visibleItems = previewItems.filter((item) => {
    const needle = search.trim().toLowerCase();
    if (!needle) return true;
    return [item.sku, item.name, item.category, item.description].some((value) =>
      value?.toLowerCase().includes(needle)
    );
  });

  const toggleSelect = (itemId: string) => {
    setSelectedIds((current) =>
      current.includes(itemId) ? current.filter((id) => id !== itemId) : [...current, itemId]
    );
  };

  const handleApplyProrrateo = async () => {
    if (selectedIds.length === 0) {
      setMessage("Seleccione al menos un artículo para aplicar el prorrateo.");
      return;
    }
    setSaving(true);
    setMessage(null);
    try {
      const selected = previewItems.filter((item) => selectedIds.includes(item.id));
      const selectedTotalBase = selected.reduce((sum, item) => sum + item.baseValue, 0);
      await Promise.all(selected.map((item) => {
        const ratio = selectedTotalBase > 0 ? item.baseValue / selectedTotalBase : 1 / selected.length;
        const proratedCost = totalExtras * ratio;
        const priceIncrease = item.stock > 0 ? proratedCost / item.stock : proratedCost;
        const newCost = (item.cost_price ?? 0) + priceIncrease;
        return updateInventoryItem(item.id, {
          cost_price: Number(newCost.toFixed(2)),
        });
      }));
      await loadItems(search);
      setMessage("Prorrateo aplicado correctamente a los artículos seleccionados.");
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo aplicar el prorrateo");
    } finally {
      setSaving(false);
    }
  };

  return (
    <WindowShell title="Valorizar F/I — Prorrateo de Costos de Importación"
    >
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="grid grid-cols-4 gap-3 mb-3">
        <Field label="OI / Embarque" className="col-span-2"><input className={inp} value={oiNumber} onChange={(e) => setOiNumber(e.target.value)} placeholder="OI-2026-0001" /></Field>
        <Field label="Moneda"><select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}><option>USD</option><option>PEN</option></select></Field>
        <Field label="T/C"><input className={inp} value={exchangeRate} onChange={(e) => setExchangeRate(e.target.value)} /></Field>
        <Field label="Flete Internacional"><input className={inp} type="number" value={freight} onChange={(e) => setFreight(Number(e.target.value))} /></Field>
        <Field label="Seguro"><input className={inp} type="number" value={insurance} onChange={(e) => setInsurance(Number(e.target.value))} /></Field>
        <Field label="Aduana / DUA"><input className={inp} type="number" value={customs} onChange={(e) => setCustoms(Number(e.target.value))} /></Field>
        <Field label="Otros Gastos"><input className={inp} type="number" value={otherCosts} onChange={(e) => setOtherCosts(Number(e.target.value))} /></Field>
        <Field label="Base Prorrateo"><select className={inp} value={baseProrrateo} onChange={(e) => setBaseProrrateo(e.target.value)}><option>Valor FOB</option><option>Peso</option><option>Volumen</option></select></Field>
      </div>
      <div className="grid grid-cols-4 gap-3 mb-4">
        <Field label="Buscar artículo" className="col-span-2"><input className={inp} value={search} onChange={(e) => setSearch(e.target.value)} placeholder="SKU, nombre, categoría" /></Field>
        <Field label="Total Base"><input className={inp} value={totalBase.toFixed(2)} readOnly /></Field>
        <Field label="Total Gastos"><input className={inp} value={totalExtras.toFixed(2)} readOnly /></Field>
      </div>
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]"><tr>
            <th className="px-2 py-2 text-left border-b border-slate-300">Sel</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">SKU</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Producto</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Cant.</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">FOB Unit.</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Prorrateo</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Costo Neto</th>
          </tr></thead>
          <tbody>
            {loading ? (
              <tr><td colSpan={7} className="px-2 py-4 text-sm text-slate-500">Cargando artículos...</td></tr>
            ) : visibleItems.length === 0 ? (
              <tr><td colSpan={7} className="px-2 py-4 text-sm text-slate-500">No se encontraron artículos.</td></tr>
            ) : visibleItems.map((item) => (
              <tr key={item.id} className={`hover:bg-slate-50 ${selectedIds.includes(item.id) ? "bg-slate-100" : ""}`}>
                <td className="px-2 py-2 border-b border-slate-200 text-center"><input type="checkbox" checked={selectedIds.includes(item.id)} onChange={() => toggleSelect(item.id)} /></td>
                <td className="px-2 py-2 border-b border-slate-200">{item.sku}</td>
                <td className="px-2 py-2 border-b border-slate-200">{item.name}</td>
                <td className="px-2 py-2 border-b border-slate-200">{item.stock}</td>
                <td className="px-2 py-2 border-b border-slate-200">{(item.cost_price ?? 0).toFixed(2)}</td>
                <td className="px-2 py-2 border-b border-slate-200">{item.proratedCost?.toFixed(2) ?? "0.00"}</td>
                <td className="px-2 py-2 border-b border-slate-200">{item.netCost?.toFixed(2) ?? (item.cost_price ?? 0).toFixed(2)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}

function ProcesoLote({ label, subtitle }: { label: string; subtitle: string }) {
  return (
    <WindowShell title={`Proceso: ${label}`}>
      <div className="text-[12px] text-slate-600 mb-3">{subtitle}</div>
      <div className="grid grid-cols-3 gap-3 mb-4">
        <Field label="Periodo"><input className={inp} type="month" /></Field>
        <Field label="Almacén"><select className={inp}><option>Todos</option><option>Central Lima</option></select></Field>
        <Field label="Método Costeo"><select className={inp}><option>Promedio Ponderado</option><option>PEPS / FIFO</option></select></Field>
      </div>
      <div className="space-y-3">
        <div>
          <div className="flex justify-between text-[11px] text-slate-600 mb-1"><span>Validación de saldos</span><span>0 / 0</span></div>
          <div className="h-2 bg-slate-200 rounded-sm overflow-hidden"><div className="h-full bg-gradient-to-r from-[#4C6E93] to-[#2A3F55] w-0"></div></div>
        </div>
        <div>
          <div className="flex justify-between text-[11px] text-slate-600 mb-1"><span>Recálculo de costos</span><span>0 / 0</span></div>
          <div className="h-2 bg-slate-200 rounded-sm overflow-hidden"><div className="h-full bg-gradient-to-r from-[#4C6E93] to-[#2A3F55] w-0"></div></div>
        </div>
        <div>
          <div className="flex justify-between text-[11px] text-slate-600 mb-1"><span>Cierre y bloqueo del periodo</span><span>0 / 0</span></div>
          <div className="h-2 bg-slate-200 rounded-sm overflow-hidden"><div className="h-full bg-gradient-to-r from-[#4C6E93] to-[#2A3F55] w-0"></div></div>
        </div>
      </div>
      <div className="mt-4 border border-slate-300 rounded-sm bg-slate-950 text-emerald-300 text-[11px] font-mono p-3 h-28 overflow-auto">
        <div>[sistema] Esperando inicio de proceso…</div>
      </div>
    </WindowShell>
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
  const [entries, setEntries] = useState<SigecoomJournalEntry[]>([]);
  const [loadingEntries, setLoadingEntries] = useState(true);
  const [saving, setSaving] = useState(false);
  const [entryNumber, setEntryNumber] = useState("0001");
  const [date, setDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [entryType, setEntryType] = useState("Diario");
  const [currency, setCurrency] = useState("PEN");
  const [exchangeRate, setExchangeRate] = useState(1);
  const [description, setDescription] = useState("");
  const [lines, setLines] = useState<JournalLineForm[]>([
    { id: "line-1", account: "", description: "", reference: "", debit: 0, credit: 0, cost_center: "" },
  ]);

  useEffect(() => {
    fetchSigecoomJournalEntries()
      .then(setEntries)
      .catch(console.error)
      .finally(() => setLoadingEntries(false));
  }, []);

  const totalDebit = lines.reduce((sum, line) => sum + line.debit, 0);
  const totalCredit = lines.reduce((sum, line) => sum + line.credit, 0);
  const diff = totalDebit - totalCredit;

  const addLine = () => {
    setLines(prev => [
      ...prev,
      {
        id: `line-${Date.now()}`,
        account: "",
        description: "",
        reference: "",
        debit: 0,
        credit: 0,
        cost_center: "",
      },
    ]);
  };

  const updateLine = (lineId: string, field: keyof JournalLineForm, value: string) => {
    setLines(prev => prev.map(line => {
      if (line.id !== lineId) return line;
      if (field === "debit" || field === "credit") {
        return { ...line, [field]: Number(value) || 0 };
      }
      return { ...line, [field]: value };
    }));
  };

  const removeLine = (lineId: string) => {
    setLines(prev => prev.filter(line => line.id !== lineId));
  };

  const resetForm = () => {
    setEntryNumber(prev => String(Number(prev || "0") + 1).padStart(4, "0"));
    setDate(new Date().toISOString().slice(0, 10));
    setEntryType("Diario");
    setCurrency("PEN");
    setExchangeRate(1);
    setDescription("");
    setLines([
      { id: `line-${Date.now()}`, account: "", description: "", reference: "", debit: 0, credit: 0, cost_center: "" },
    ]);
  };

  const handleRegister = async () => {
    if (diff !== 0) {
      alert("El debe y el haber deben estar balanceados.");
      return;
    }

    setSaving(true);
    try {
      const created = await createSigecoomJournalEntry({
        entry_number: entryNumber,
        date,
        type: entryType,
        currency,
        exchange_rate: exchangeRate,
        description,
        lines: lines.map(line => ({
          account: line.account,
          description: line.description,
          reference: line.reference,
          debit: line.debit,
          credit: line.credit,
          cost_center: line.cost_center,
        })),
      });

      setEntries(prev => [created, ...prev]);
      resetForm();
    } catch (error) {
      console.error(error);
      alert("No se pudo guardar el asiento contable. Revise los datos e intente de nuevo.");
    } finally {
      setSaving(false);
    }
  };

  return (
    <WindowShell title="Asientos Contables — Doble Entrada"
      toolbar={<>
        <button className={btnPrimary} onClick={handleRegister} disabled={saving}>
          <Save className="h-3.5 w-3.5" />{saving ? "Guardando…" : "Registrar"}
        </button>
        <button className={btn} onClick={addLine} type="button"><Plus className="h-3.5 w-3.5" />Nueva línea</button>
        <span className="ml-auto text-[11px] text-slate-600">
          Debe: <b className="font-mono">{totalDebit.toFixed(2)}</b> · Haber: <b className="font-mono">{totalCredit.toFixed(2)}</b> · Dif: <b className={diff === 0 ? "font-mono text-emerald-700" : "font-mono text-red-700"}>{diff.toFixed(2)}</b>
        </span>
      </>}
    >
      <div className="grid grid-cols-4 gap-3">
        <Field label="Nº Asiento"><input className={inp} value={entryNumber} onChange={e => setEntryNumber(e.target.value)} /></Field>
        <Field label="Fecha"><input className={inp} type="date" value={date} onChange={e => setDate(e.target.value)} /></Field>
        <Field label="Tipo">
          <select className={inp} value={entryType} onChange={e => setEntryType(e.target.value)}>
            <option>Diario</option>
            <option>Ventas</option>
            <option>Compras</option>
            <option>Caja/Bancos</option>
          </select>
        </Field>
        <Field label="Moneda">
          <select className={inp} value={currency} onChange={e => setCurrency(e.target.value)}>
            <option>PEN</option>
            <option>USD</option>
          </select>
        </Field>
        <Field label="Tipo de cambio"><input className={inp} type="number" step="0.0001" value={exchangeRate} onChange={e => setExchangeRate(Number(e.target.value) || 1)} /></Field>
        <Field label="Glosa" className="col-span-3"><input className={inp} value={description} onChange={e => setDescription(e.target.value)} /></Field>
      </div>

      <div className="mt-3 overflow-auto border border-slate-300 rounded-sm bg-white">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#EEF2F7] text-slate-800">
            <tr>
              <th className="px-2 py-2 border-b border-slate-300 text-left">Cuenta</th>
              <th className="px-2 py-2 border-b border-slate-300 text-left">Descripción</th>
              <th className="px-2 py-2 border-b border-slate-300 text-left">Doc. Ref.</th>
              <th className="px-2 py-2 border-b border-slate-300 text-right">Debe</th>
              <th className="px-2 py-2 border-b border-slate-300 text-right">Haber</th>
              <th className="px-2 py-2 border-b border-slate-300 text-left">C. Costo</th>
              <th className="px-2 py-2 border-b border-slate-300 text-center">Acción</th>
            </tr>
          </thead>
          <tbody>
            {lines.map(line => (
              <tr key={line.id} className="even:bg-[#F8FBFF]">
                <td className="px-2 py-1 border-b border-slate-200"><input className={inp} value={line.account} onChange={e => updateLine(line.id, "account", e.target.value)} placeholder="Cuenta" /></td>
                <td className="px-2 py-1 border-b border-slate-200"><input className={inp} value={line.description} onChange={e => updateLine(line.id, "description", e.target.value)} placeholder="Descripción" /></td>
                <td className="px-2 py-1 border-b border-slate-200"><input className={inp} value={line.reference} onChange={e => updateLine(line.id, "reference", e.target.value)} placeholder="Ref." /></td>
                <td className="px-2 py-1 border-b border-slate-200 text-right"><input className={`${inp} text-right`} type="number" step="0.01" value={line.debit} onChange={e => updateLine(line.id, "debit", e.target.value)} /></td>
                <td className="px-2 py-1 border-b border-slate-200 text-right"><input className={`${inp} text-right`} type="number" step="0.01" value={line.credit} onChange={e => updateLine(line.id, "credit", e.target.value)} /></td>
                <td className="px-2 py-1 border-b border-slate-200"><input className={inp} value={line.cost_center} onChange={e => updateLine(line.id, "cost_center", e.target.value)} placeholder="C. Costo" /></td>
                <td className="px-2 py-1 border-b border-slate-200 text-center"><button className={btn} type="button" onClick={() => removeLine(line.id)}>Eliminar</button></td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      <div className="mt-3 grid grid-cols-3 gap-3 text-[12px] text-slate-700">
        <div className="p-2 bg-slate-50 rounded-sm border border-slate-200">Total Debe: <b>{totalDebit.toFixed(2)}</b></div>
        <div className="p-2 bg-slate-50 rounded-sm border border-slate-200">Total Haber: <b>{totalCredit.toFixed(2)}</b></div>
        <div className={`p-2 rounded-sm border ${diff === 0 ? "border-emerald-300 bg-emerald-50 text-emerald-700" : "border-rose-300 bg-rose-50 text-rose-700"}`}>Diferencia: <b>{diff.toFixed(2)}</b></div>
      </div>

      <div className="mt-6">
        <div className="text-[11px] font-semibold text-slate-700 uppercase mb-2">Últimos asientos registrados</div>
        <div className="overflow-auto border border-slate-300 rounded-sm bg-white">
          <table className="w-full text-[11px] border-collapse">
            <thead className="bg-[#EEF2F7] text-slate-800">
              <tr>
                <th className="px-2 py-2 border-b border-slate-300 text-left">Asiento</th>
                <th className="px-2 py-2 border-b border-slate-300 text-left">Fecha</th>
                <th className="px-2 py-2 border-b border-slate-300 text-left">Tipo</th>
                <th className="px-2 py-2 border-b border-slate-300 text-left">Moneda</th>
                <th className="px-2 py-2 border-b border-slate-300 text-left">Glosa</th>
              </tr>
            </thead>
            <tbody>
              {loadingEntries && (
                <tr><td colSpan={5} className="px-2 py-4 text-center text-slate-500">Cargando asientos…</td></tr>
              )}
              {!loadingEntries && entries.length === 0 && (
                <tr><td colSpan={5} className="px-2 py-4 text-center text-slate-500">No hay asientos registrados</td></tr>
              )}
              {entries.map(entry => (
                <tr key={entry.id} className="even:bg-[#F8FBFF]">
                  <td className="px-2 py-2 border-b border-slate-200">{entry.entry_number}</td>
                  <td className="px-2 py-2 border-b border-slate-200">{new Date(entry.date).toLocaleDateString()}</td>
                  <td className="px-2 py-2 border-b border-slate-200">{entry.type}</td>
                  <td className="px-2 py-2 border-b border-slate-200">{entry.currency}</td>
                  <td className="px-2 py-2 border-b border-slate-200">{entry.description || "—"}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </WindowShell>
  );
}

function MovimientoBancos() {
  const [accounts, setAccounts] = useState<BankAccount[]>([]);
  const [selectedAccountId, setSelectedAccountId] = useState("");
  const [fromDate, setFromDate] = useState("");
  const [toDate, setToDate] = useState("");
  const [bankTransactions, setBankTransactions] = useState<BankTransaction[]>([]);
  const [erpTransactions, setErpTransactions] = useState<BankTransaction[]>([]);
  const [selectedIds, setSelectedIds] = useState<string[]>([]);
  const [loading, setLoading] = useState(true);
  const [actionLoading, setActionLoading] = useState(false);
  const fileInputRef = useRef<HTMLInputElement>(null);

  const loadAccounts = useCallback(async () => {
    setLoading(true);
    try {
      const accountsData = await fetchBankAccounts();
      if (accountsData.length === 0) {
        const created = await createBankAccount({
          bank_name: "BCP",
          account_number: "194-0000000-0",
          currency: "PEN",
        });
        setAccounts([created]);
        setSelectedAccountId(created.id);
      } else {
        setAccounts(accountsData);
        if (!selectedAccountId) {
          setSelectedAccountId(accountsData[0].id);
        }
      }
    } catch (error) {
      console.error(error);
    } finally {
      setLoading(false);
    }
  }, [selectedAccountId]);

  const loadTransactions = useCallback(async (accountId?: string) => {
    setLoading(true);
    try {
      const [bankData, erpData] = await Promise.all([
        fetchBankTransactions("bank", accountId),
        fetchBankTransactions("erp"),
      ]);
      setBankTransactions(bankData);
      setErpTransactions(erpData);
    } catch (error) {
      console.error(error);
    } finally {
      setLoading(false);
    }
  }, []);

  useEffect(() => {
    loadAccounts();
  }, [loadAccounts]);

  useEffect(() => {
    if (selectedAccountId) {
      loadTransactions(selectedAccountId);
    }
  }, [selectedAccountId, loadTransactions]);

  const toggleSelection = (id: string) => {
    setSelectedIds(prev => prev.includes(id) ? prev.filter(item => item !== id) : [...prev, id]);
  };

  const handleConciliar = async () => {
    if (selectedIds.length === 0) {
      alert("Seleccione al menos una transacción para conciliar.");
      return;
    }

    setActionLoading(true);
    try {
      await Promise.all(selectedIds.map(id => updateBankTransaction(id, { reconciled: true })));
      setSelectedIds([]);
      await loadTransactions(selectedAccountId);
    } catch (error) {
      console.error(error);
      alert("No se pudo conciliar las transacciones seleccionadas.");
    } finally {
      setActionLoading(false);
    }
  };

  const handleImportClick = () => {
    fileInputRef.current?.click();
  };

  const handleFileSelected = async (event: React.ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files?.[0];
    if (!file) return;
    if (!selectedAccountId) {
      alert("Seleccione primero una cuenta bancaria.");
      return;
    }

    const text = await file.text();
    const lines = text.split(/\r?\n/).map(line => line.trim()).filter(Boolean);
    if (lines.length < 2) {
      alert("El archivo debe tener encabezado y al menos una fila de datos.");
      return;
    }

    const headers = lines[0].split(",").map(cell => cell.trim().toLowerCase());
    const dateIndex = headers.indexOf("date");
    const descriptionIndex = headers.indexOf("description");
    const cargoIndex = headers.indexOf("cargo");
    const abonoIndex = headers.indexOf("abono");
    const referenceIndex = headers.indexOf("reference");

    if (dateIndex === -1 || descriptionIndex === -1 || cargoIndex === -1 || abonoIndex === -1) {
      alert("El CSV debe incluir columnas: date, description, cargo, abono, reference.");
      return;
    }

    setActionLoading(true);
    try {
      const rows = lines.slice(1);
      await Promise.all(rows.map(async line => {
        const columns = line.split(",").map(cell => cell.trim());
        const date = columns[dateIndex] || new Date().toISOString().slice(0, 10);
        const description = columns[descriptionIndex] || "Movimiento bancario";
        const cargo = Number(columns[cargoIndex] || 0);
        const abono = Number(columns[abonoIndex] || 0);
        const reference = referenceIndex !== -1 ? columns[referenceIndex] : undefined;
        const direction = cargo > 0 ? "cargo" : "abono";
        const amount = Math.max(cargo, abono, 0);
        if (amount <= 0) return;

        await createBankTransaction({
          bank_account_id: selectedAccountId,
          source: "bank",
          date,
          description,
          reference,
          amount,
          direction,
        });
      }));
      await loadTransactions(selectedAccountId);
      alert("Estado de cuenta importado correctamente.");
    } catch (error) {
      console.error(error);
      alert("Error al importar el estado de cuenta.");
    } finally {
      setActionLoading(false);
      if (event.target) {
        event.target.value = "";
      }
    }
  };

  const handleCreateErpMovement = async () => {
    setActionLoading(true);
    try {
      await createBankTransaction({
        source: "erp",
        date: new Date().toISOString().slice(0, 10),
        description: "Pago ERP registrado",
        reference: `ERP-${Date.now()}`,
        amount: 1200,
        direction: "debe",
      });
      await loadTransactions(selectedAccountId);
    } catch (error) {
      console.error(error);
      alert("No se pudo crear el movimiento ERP.");
    } finally {
      setActionLoading(false);
    }
  };

  const showRows = loading ? 0 : undefined;

  return (
    <WindowShell title="Conciliación Bancaria"
      toolbar={<>
        <button className={btnPrimary} onClick={handleConciliar} disabled={actionLoading || selectedIds.length === 0}>
          ✓ Conciliar seleccionados
        </button>
        <button className={btn} onClick={handleImportClick} type="button" disabled={actionLoading}>
          <RefreshCw className="h-3.5 w-3.5" />Importar Estado Cta.
        </button>
        <button className={btn} onClick={handleCreateErpMovement} type="button" disabled={actionLoading}>
          <Plus className="h-3.5 w-3.5" />Agregar Movimiento ERP
        </button>
        <span className="ml-auto text-[11px] text-slate-600">Seleccionados: <b>{selectedIds.length}</b></span>
      </>}
    >
      <input ref={fileInputRef} type="file" accept=".csv,text/csv" className="hidden" onChange={handleFileSelected} />

      <div className="grid grid-cols-4 gap-3 mb-3">
        <Field label="Banco">
          <select className={inp} value={selectedAccountId} onChange={e => setSelectedAccountId(e.target.value)}>
            {accounts.map(account => (
              <option key={account.id} value={account.id}>{account.bank_name} — {account.account_number}</option>
            ))}
          </select>
        </Field>
        <Field label="Cuenta">
          <input className={inp} value={accounts.find(item => item.id === selectedAccountId)?.account_number || ""} readOnly />
        </Field>
        <Field label="Desde"><input className={inp} type="date" value={fromDate} onChange={e => setFromDate(e.target.value)} /></Field>
        <Field label="Hasta"><input className={inp} type="date" value={toDate} onChange={e => setToDate(e.target.value)} /></Field>
      </div>

      <div className="grid grid-cols-2 gap-3">
        <div>
          <div className="text-[11px] font-semibold text-[#2A3F55] mb-1 uppercase">Estado de Cuenta Banco</div>
          <div className="overflow-auto border border-slate-300 rounded-sm bg-white">
            <table className="w-full text-[11px] border-collapse">
              <thead className="bg-[#EEF2F7] text-slate-800">
                <tr>
                  <th className="px-2 py-2 border-b border-slate-300 text-left">Sel</th>
                  <th className="px-2 py-2 border-b border-slate-300 text-left">Fecha</th>
                  <th className="px-2 py-2 border-b border-slate-300 text-left">Concepto</th>
                  <th className="px-2 py-2 border-b border-slate-300 text-right">Cargo</th>
                  <th className="px-2 py-2 border-b border-slate-300 text-right">Abono</th>
                  <th className="px-2 py-2 border-b border-slate-300 text-left">Ref.</th>
                  <th className="px-2 py-2 border-b border-slate-300 text-center">Rec.</th>
                </tr>
              </thead>
              <tbody>
                {loading && (
                  <tr><td colSpan={7} className="px-2 py-4 text-center text-slate-500">Cargando transacciones...</td></tr>
                )}
                {!loading && bankTransactions.length === 0 && (
                  <tr><td colSpan={7} className="px-2 py-4 text-center text-slate-500">No hay movimientos bancarios</td></tr>
                )}
                {bankTransactions.map(tx => (
                  <tr key={tx.id} className={tx.reconciled ? "bg-emerald-50" : "even:bg-[#F8FBFF]"}>
                    <td className="px-2 py-1 border-b border-slate-200 text-center">
                      <input type="checkbox" checked={selectedIds.includes(tx.id)} onChange={() => toggleSelection(tx.id)} />
                    </td>
                    <td className="px-2 py-1 border-b border-slate-200">{new Date(tx.date).toLocaleDateString()}</td>
                    <td className="px-2 py-1 border-b border-slate-200">{tx.description}</td>
                    <td className="px-2 py-1 border-b border-slate-200 text-right">{tx.direction === "cargo" ? tx.amount.toFixed(2) : ""}</td>
                    <td className="px-2 py-1 border-b border-slate-200 text-right">{tx.direction === "abono" ? tx.amount.toFixed(2) : ""}</td>
                    <td className="px-2 py-1 border-b border-slate-200">{tx.reference || "—"}</td>
                    <td className="px-2 py-1 border-b border-slate-200 text-center">{tx.reconciled ? "Sí" : "No"}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </div>

        <div>
          <div className="text-[11px] font-semibold text-[#2A3F55] mb-1 uppercase">Movimientos ERP</div>
          <div className="overflow-auto border border-slate-300 rounded-sm bg-white">
            <table className="w-full text-[11px] border-collapse">
              <thead className="bg-[#EEF2F7] text-slate-800">
                <tr>
                  <th className="px-2 py-2 border-b border-slate-300 text-left">Sel</th>
                  <th className="px-2 py-2 border-b border-slate-300 text-left">Fecha</th>
                  <th className="px-2 py-2 border-b border-slate-300 text-left">Doc.</th>
                  <th className="px-2 py-2 border-b border-slate-300 text-right">Debe</th>
                  <th className="px-2 py-2 border-b border-slate-300 text-right">Haber</th>
                  <th className="px-2 py-2 border-b border-slate-300 text-left">Descripción</th>
                  <th className="px-2 py-2 border-b border-slate-300 text-center">Rec.</th>
                </tr>
              </thead>
              <tbody>
                {loading && (
                  <tr><td colSpan={7} className="px-2 py-4 text-center text-slate-500">Cargando movimientos ERP...</td></tr>
                )}
                {!loading && erpTransactions.length === 0 && (
                  <tr><td colSpan={7} className="px-2 py-4 text-center text-slate-500">No hay movimientos ERP</td></tr>
                )}
                {erpTransactions.map(tx => (
                  <tr key={tx.id} className={tx.reconciled ? "bg-emerald-50" : "even:bg-[#F8FBFF]"}>
                    <td className="px-2 py-1 border-b border-slate-200 text-center">
                      <input type="checkbox" checked={selectedIds.includes(tx.id)} onChange={() => toggleSelection(tx.id)} />
                    </td>
                    <td className="px-2 py-1 border-b border-slate-200">{new Date(tx.date).toLocaleDateString()}</td>
                    <td className="px-2 py-1 border-b border-slate-200">{tx.reference || "ERP"}</td>
                    <td className="px-2 py-1 border-b border-slate-200 text-right">{tx.direction === "debe" ? tx.amount.toFixed(2) : ""}</td>
                    <td className="px-2 py-1 border-b border-slate-200 text-right">{tx.direction === "haber" ? tx.amount.toFixed(2) : ""}</td>
                    <td className="px-2 py-1 border-b border-slate-200">{tx.description}</td>
                    <td className="px-2 py-1 border-b border-slate-200 text-center">{tx.reconciled ? "Sí" : "No"}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}

function RegistroCompra() {
  const [registers, setRegisters] = useState<PurchaseRegister[]>([]);
  const [loading, setLoading] = useState(false);
  const [filter, setFilter] = useState<"all" | "draft" | "registered">("all");

  // Form state
  const [docType, setDocType] = useState("Factura");
  const [series, setSeries] = useState("");
  const [number, setNumber] = useState("");
  const [docDate, setDocDate] = useState(new Date().toISOString().split('T')[0]);
  const [supplierRuc, setSupplierRuc] = useState("");
  const [supplierName, setSupplierName] = useState("");
  const [currency, setCurrency] = useState("PEN");
  const [taxableBase, setTaxableBase] = useState(0);
  const [igv, setIgv] = useState(0);
  const [nonTaxable, setNonTaxable] = useState(0);
  const [retention, setRetention] = useState(0);
  const [costCenter, setCostCenter] = useState("");

  // Load registers on mount
  useEffect(() => {
    loadRegisters();
  }, [filter]);

  const loadRegisters = async () => {
    try {
      setLoading(true);
      const statusFilter = filter === "all" ? undefined : filter;
      const data = await fetchPurchaseRegisters(statusFilter);
      setRegisters(data);
    } catch (error) {
      console.error("Error loading purchase registers:", error);
    } finally {
      setLoading(false);
    }
  };

  const handleSave = async () => {
    if (!supplierRuc || !supplierName || taxableBase + nonTaxable === 0) {
      alert("Ingrese datos requeridos: RUC, Razón Social y montos");
      return;
    }

    try {
      const total = taxableBase + igv + nonTaxable - retention;
      await createPurchaseRegister({
        document_type: docType,
        series: series || undefined,
        number: number || undefined,
        document_date: new Date(docDate).toISOString(),
        supplier_ruc: supplierRuc,
        supplier_name: supplierName,
        currency,
        taxable_base: taxableBase,
        igv,
        non_taxable: nonTaxable,
        total,
        retention: retention || undefined,
        cost_center: costCenter || undefined,
      });

      alert("Registro de compra creado exitosamente");
      // Clear form
      setSupplierRuc("");
      setSupplierName("");
      setSeries("");
      setNumber("");
      setTaxableBase(0);
      setIgv(0);
      setNonTaxable(0);
      setRetention(0);
      setCostCenter("");
      // Reload
      loadRegisters();
    } catch (error) {
      alert(`Error: ${(error as Error).message}`);
    }
  };

  const total = taxableBase + igv + nonTaxable - retention;

  return (
    <WindowShell title="Registro de Compras / Recibo por Honorarios"
      toolbar={<>
        <button className={btnPrimary} onClick={handleSave}><Save className="h-3.5 w-3.5" />Registrar</button>
        <button className={btn} onClick={loadRegisters}><RefreshCw className="h-3.5 w-3.5" />Recargar</button>
        <select className={inp} value={filter} onChange={(e) => setFilter(e.target.value as any)} style={{ maxWidth: "120px" }}>
          <option value="all">Todos</option>
          <option value="draft">Borrador</option>
          <option value="registered">Registrado</option>
        </select>
      </>}>
      
      {/* Input Section */}
      <div className="grid grid-cols-4 gap-3 mb-4 p-3 bg-slate-50 rounded">
        <Field label="Tipo Doc.">
          <select className={inp} value={docType} onChange={(e) => setDocType(e.target.value)}>
            <option>Factura</option>
            <option>Boleta</option>
            <option>Recibo x Honorarios</option>
            <option>Nota Crédito</option>
          </select>
        </Field>
        <Field label="Serie"><input className={inp} value={series} onChange={(e) => setSeries(e.target.value)} /></Field>
        <Field label="Número"><input className={inp} value={number} onChange={(e) => setNumber(e.target.value)} /></Field>
        <Field label="Fecha Emisión"><input className={inp} type="date" value={docDate} onChange={(e) => setDocDate(e.target.value)} /></Field>
        <Field label="Proveedor RUC/DNI"><input className={inp} value={supplierRuc} onChange={(e) => setSupplierRuc(e.target.value)} placeholder="12345678901" /></Field>
        <Field label="Razón Social" className="col-span-2"><input className={inp} value={supplierName} onChange={(e) => setSupplierName(e.target.value)} /></Field>
        <Field label="Moneda"><select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}>
          <option value="PEN">PEN</option>
          <option value="USD">USD</option>
        </select></Field>

        <Field label="Base Imponible"><input className={inp} type="number" value={taxableBase} onChange={(e) => setTaxableBase(parseFloat(e.target.value) || 0)} /></Field>
        <Field label="IGV"><input className={inp} type="number" value={igv} onChange={(e) => setIgv(parseFloat(e.target.value) || 0)} /></Field>
        <Field label="No Gravado"><input className={inp} type="number" value={nonTaxable} onChange={(e) => setNonTaxable(parseFloat(e.target.value) || 0)} /></Field>
        <Field label="Retención 4ta / Detracción"><input className={inp} type="number" value={retention} onChange={(e) => setRetention(parseFloat(e.target.value) || 0)} /></Field>
        <Field label="Centro Costo" className="col-span-2"><select className={inp} value={costCenter} onChange={(e) => setCostCenter(e.target.value)}>
          <option value="">-- Seleccionar --</option>
          <option value="Administración">Administración</option>
          <option value="Ventas">Ventas</option>
          <option value="Servicios">Servicios</option>
          <option value="Operaciones">Operaciones</option>
        </select></Field>

        <div className="col-span-4 text-right font-semibold text-slate-700">
          Total: <span className="text-lg font-mono">{total.toFixed(2)}</span>
        </div>
      </div>

      {/* Registers List */}
      <div className="mt-4">
        <div className="overflow-auto max-h-96 border border-slate-200 rounded">
          <table className="w-full text-sm">
            <thead className="sticky top-0 bg-slate-100 border-b">
              <tr>
                <th className="px-3 py-2 text-left">Tipo</th>
                <th className="px-3 py-2 text-left">Series</th>
                <th className="px-3 py-2 text-left">RUC</th>
                <th className="px-3 py-2 text-left">Proveedor</th>
                <th className="px-3 py-2 text-right">Base</th>
                <th className="px-3 py-2 text-right">IGV</th>
                <th className="px-3 py-2 text-right">Total</th>
                <th className="px-3 py-2 text-center">Estado</th>
              </tr>
            </thead>
            <tbody>
              {loading ? (
                <tr><td colSpan={8} className="px-3 py-2 text-center text-slate-500">Cargando...</td></tr>
              ) : registers.length === 0 ? (
                <tr><td colSpan={8} className="px-3 py-2 text-center text-slate-500">Sin registros</td></tr>
              ) : (
                registers.map((reg) => (
                  <tr key={reg.id} className="border-b hover:bg-slate-50 cursor-pointer">
                    <td className="px-3 py-2 text-xs">{reg.document_type}</td>
                    <td className="px-3 py-2 text-xs">{reg.series || "-"}</td>
                    <td className="px-3 py-2 text-xs font-mono">{reg.supplier_ruc}</td>
                    <td className="px-3 py-2 text-xs">{reg.supplier_name}</td>
                    <td className="px-3 py-2 text-right text-xs font-mono">{reg.taxable_base.toFixed(2)}</td>
                    <td className="px-3 py-2 text-right text-xs font-mono">{reg.igv.toFixed(2)}</td>
                    <td className="px-3 py-2 text-right text-xs font-mono font-semibold">{reg.total.toFixed(2)}</td>
                    <td className="px-3 py-2 text-center">
                      <span className={`text-xs px-2 py-1 rounded ${reg.status === 'registered' ? 'bg-green-100 text-green-700' : 'bg-blue-100 text-blue-700'}`}>
                        {reg.status === 'registered' ? 'Registrado' : 'Borrador'}
                      </span>
                    </td>
                  </tr>
                ))
              )}
            </tbody>
          </table>
        </div>
      </div>
    </WindowShell>
  );
}

function CajaChica() {
  const [cajas, setCajas] = useState<CajaChica[]>([]);
  const [selectedCajaId, setSelectedCajaId] = useState<string | null>(null);
  const [gastos, setGastos] = useState<Gasto[]>([]);
  const [balance, setBalance] = useState<any>(null);
  const [loading, setLoading] = useState(false);
  const [showNewGasto, setShowNewGasto] = useState(false);

  // New gasto form state
  const [concept, setConcept] = useState("");
  const [voucherType, setVoucherType] = useState("");
  const [voucherNumber, setVoucherNumber] = useState("");
  const [amount, setAmount] = useState(0);
  const [category, setCategory] = useState("Alimentación");
  const [description, setDescription] = useState("");

  // Load cajas on mount
  useEffect(() => {
    loadCajas();
  }, []);

  // Load gastos when caja changes
  useEffect(() => {
    if (selectedCajaId) {
      loadGastos();
      loadBalance();
    }
  }, [selectedCajaId]);

  const loadCajas = async () => {
    try {
      setLoading(true);
      const data = await fetchCajaChica();
      setCajas(data);
      if (data.length > 0 && !selectedCajaId) {
        setSelectedCajaId(data[0].id);
      }
    } catch (error) {
      console.error("Error loading cajas:", error);
    } finally {
      setLoading(false);
    }
  };

  const loadGastos = async () => {
    if (!selectedCajaId) return;
    try {
      const data = await fetchGastos(selectedCajaId);
      setGastos(data);
    } catch (error) {
      console.error("Error loading gastos:", error);
    }
  };

  const loadBalance = async () => {
    if (!selectedCajaId) return;
    try {
      const data = await getCajaBalance(selectedCajaId);
      setBalance(data);
    } catch (error) {
      console.error("Error loading balance:", error);
    }
  };

  const handleAddGasto = async () => {
    if (!selectedCajaId || !concept || amount <= 0) {
      alert("Ingrese datos requeridos");
      return;
    }

    try {
      await createGasto(selectedCajaId, {
        concept,
        voucher_type: voucherType || undefined,
        voucher_number: voucherNumber || undefined,
        amount,
        category,
        description: description || undefined,
      });

      // Reset form
      setConcept("");
      setVoucherType("");
      setVoucherNumber("");
      setAmount(0);
      setCategory("Alimentación");
      setDescription("");
      setShowNewGasto(false);

      // Reload
      await loadGastos();
      await loadBalance();
    } catch (error) {
      alert(`Error: ${(error as Error).message}`);
    }
  };

  const handleDeleteGasto = async (gastoId: string) => {
    if (!confirm("¿Eliminar este gasto?")) return;
    try {
      await deleteGasto(gastoId);
      await loadGastos();
      await loadBalance();
    } catch (error) {
      alert(`Error: ${(error as Error).message}`);
    }
  };

  const handleSubmitGastos = async () => {
    if (!selectedCajaId) return;
    const pendingIds = gastos
      .filter((g) => g.status === "pending")
      .map((g) => g.id);
    if (pendingIds.length === 0) {
      alert("No hay gastos pendientes para presentar");
      return;
    }

    try {
      await submitGastos(selectedCajaId, pendingIds);
      await loadGastos();
      await loadBalance();
      alert("Gastos presentados para reembolso");
    } catch (error) {
      alert(`Error: ${(error as Error).message}`);
    }
  };

  const handleReimburse = async () => {
    if (!selectedCajaId) return;
    const submittedIds = gastos
      .filter((g) => g.status === "submitted")
      .map((g) => g.id);
    if (submittedIds.length === 0) {
      alert("No hay gastos para reembolsar");
      return;
    }

    try {
      await reimburseGastos(selectedCajaId, submittedIds);
      await loadGastos();
      await loadBalance();
      alert("Gastos reembolsados");
    } catch (error) {
      alert(`Error: ${(error as Error).message}`);
    }
  };

  const currentCaja = cajas.find((c) => c.id === selectedCajaId);

  return (
    <WindowShell
      title="Caja Chica — Rendición y Arqueo"
      toolbar={
        <>
          <button className={btnPrimary} onClick={loadGastos}>
            <RefreshCw className="h-3.5 w-3.5" />
            Recargar
          </button>
          <button className={btn} onClick={() => setShowNewGasto(!showNewGasto)}>
            <Plus className="h-3.5 w-3.5" />
            Nuevo gasto
          </button>
          <button className={btn} onClick={handleSubmitGastos}>
            Reembolso
          </button>
          <button className={btn} onClick={handleReimburse}>
            Arqueo
          </button>
        </>
      }
    >
      {/* Caja Selection & Info */}
      <div className="grid grid-cols-4 gap-3 mb-3 p-3 bg-slate-50 rounded">
        <Field label="Caja">
          <select
            className={inp}
            value={selectedCajaId || ""}
            onChange={(e) => setSelectedCajaId(e.target.value)}
          >
            <option value="">-- Seleccionar --</option>
            {cajas.map((c) => (
              <option key={c.id} value={c.id}>
                {c.name}
              </option>
            ))}
          </select>
        </Field>
        {currentCaja && (
          <>
            <Field label="Responsable" className="col-span-2">
              <input className={inp} value={currentCaja.responsible} readOnly />
            </Field>
            <Field label="Fondo Asignado">
              <input
                className={inp}
                type="number"
                value={currentCaja.assigned_fund}
                readOnly
              />
            </Field>
          </>
        )}
      </div>

      {/* New Gasto Form */}
      {showNewGasto && selectedCajaId && (
        <div className="mb-4 p-3 border border-blue-200 bg-blue-50 rounded">
          <h4 className="font-semibold text-sm mb-3">Nuevo Gasto</h4>
          <div className="grid grid-cols-4 gap-3">
            <Field label="Concepto">
              <input
                className={inp}
                value={concept}
                onChange={(e) => setConcept(e.target.value)}
              />
            </Field>
            <Field label="Tipo Comprobante">
              <select
                className={inp}
                value={voucherType}
                onChange={(e) => setVoucherType(e.target.value)}
              >
                <option value="">-- Ninguno --</option>
                <option value="Ticket">Ticket</option>
                <option value="Factura">Factura</option>
                <option value="Recibo">Recibo</option>
              </select>
            </Field>
            <Field label="N° Comprobante">
              <input
                className={inp}
                value={voucherNumber}
                onChange={(e) => setVoucherNumber(e.target.value)}
              />
            </Field>
            <Field label="Monto">
              <input
                className={inp}
                type="number"
                value={amount}
                onChange={(e) => setAmount(parseFloat(e.target.value) || 0)}
              />
            </Field>
            <Field label="Categoría">
              <select
                className={inp}
                value={category}
                onChange={(e) => setCategory(e.target.value)}
              >
                <option>Alimentación</option>
                <option>Transporte</option>
                <option>Oficina</option>
                <option>Suministros</option>
                <option>Otros</option>
              </select>
            </Field>
            <Field label="Descripción" className="col-span-2">
              <input
                className={inp}
                value={description}
                onChange={(e) => setDescription(e.target.value)}
              />
            </Field>
            <div className="col-span-4 flex gap-2">
              <button
                className={btnPrimary}
                onClick={handleAddGasto}
              >
                Guardar
              </button>
              <button
                className={btn}
                onClick={() => {
                  setShowNewGasto(false);
                  setConcept("");
                  setAmount(0);
                  setDescription("");
                }}
              >
                Cancelar
              </button>
            </div>
          </div>
        </div>
      )}

      {/* Gastos Table */}
      <div className="mt-4 overflow-auto max-h-64 border border-slate-200 rounded">
        <table className="w-full text-sm">
          <thead className="sticky top-0 bg-slate-100 border-b">
            <tr>
              <th className="px-3 py-2 text-left">#</th>
              <th className="px-3 py-2 text-left">Fecha</th>
              <th className="px-3 py-2 text-left">Concepto</th>
              <th className="px-3 py-2 text-left">Comprobante</th>
              <th className="px-3 py-2 text-right">Monto</th>
              <th className="px-3 py-2 text-left">Categoría</th>
              <th className="px-3 py-2 text-center">Estado</th>
              <th className="px-3 py-2 text-center">Acciones</th>
            </tr>
          </thead>
          <tbody>
            {loading ? (
              <tr>
                <td colSpan={8} className="px-3 py-2 text-center text-slate-500">
                  Cargando...
                </td>
              </tr>
            ) : gastos.length === 0 ? (
              <tr>
                <td colSpan={8} className="px-3 py-2 text-center text-slate-500">
                  Sin gastos
                </td>
              </tr>
            ) : (
              gastos.map((gasto, idx) => (
                <tr key={gasto.id} className="border-b hover:bg-slate-50">
                  <td className="px-3 py-2 text-xs">{idx + 1}</td>
                  <td className="px-3 py-2 text-xs">
                    {new Date(gasto.date).toLocaleDateString()}
                  </td>
                  <td className="px-3 py-2 text-xs">{gasto.concept}</td>
                  <td className="px-3 py-2 text-xs">
                    {gasto.voucher_type} {gasto.voucher_number || "-"}
                  </td>
                  <td className="px-3 py-2 text-right text-xs font-mono">
                    {gasto.amount.toFixed(2)}
                  </td>
                  <td className="px-3 py-2 text-xs">{gasto.category}</td>
                  <td className="px-3 py-2 text-center">
                    <span
                      className={`text-xs px-2 py-1 rounded ${
                        gasto.status === "reimbursed"
                          ? "bg-green-100 text-green-700"
                          : gasto.status === "submitted"
                            ? "bg-yellow-100 text-yellow-700"
                            : "bg-blue-100 text-blue-700"
                      }`}
                    >
                      {gasto.status === "reimbursed"
                        ? "Reembolsado"
                        : gasto.status === "submitted"
                          ? "Presentado"
                          : "Pendiente"}
                    </span>
                  </td>
                  <td className="px-3 py-2 text-center">
                    {gasto.status === "pending" && (
                      <button
                        className="text-red-600 hover:text-red-800 text-xs"
                        onClick={() => handleDeleteGasto(gasto.id)}
                      >
                        Eliminar
                      </button>
                    )}
                  </td>
                </tr>
              ))
            )}
          </tbody>
        </table>
      </div>

      {/* Balance Summary */}
      {balance && (
        <div className="mt-3 grid grid-cols-4 gap-2 max-w-md ml-auto text-[11.5px]">
          <div className="text-right text-slate-600 col-span-3">
            Gastos registrados:
          </div>
          <div className="text-right font-mono">
            {(balance.total_gastos_pending + balance.total_gastos_reimbursed).toFixed(
              2
            )}
          </div>
          <div className="text-right text-slate-600 col-span-3">Saldo en caja:</div>
          <div className="text-right font-mono font-semibold">
            {balance.saldo_actual.toFixed(2)}
          </div>
          <div className="text-right font-bold text-[#2A3F55] col-span-3">
            Reembolso a solicitar:
          </div>
          <div className="text-right font-mono font-bold">
            {balance.reembolso_a_solicitar.toFixed(2)}
          </div>
        </div>
      )}
    </WindowShell>
  );
}

function GenerarTXT() {
  return (
    <WindowShell title="Generar TXT — Libros Electrónicos SUNAT"
      toolbar={<>
        <button className={btnPrimary}><FileDown className="h-3.5 w-3.5" />Generar archivo .TXT</button>
      </>}>
      <div className="grid grid-cols-3 gap-3">
        <Field label="Libro"><select className={inp}><option>Registro de Ventas</option><option>Registro de Compras</option><option>Libro Diario</option><option>Libro Mayor</option></select></Field>
        <Field label="Periodo"><input className={inp} type="month" /></Field>
        <Field label="Formato"><select className={inp}><option>PLE 5.2</option><option>PLE 5.3</option></select></Field>
      </div>
      <div className="mt-3 text-[11px] text-slate-600">Estructura del archivo se validará automáticamente contra el esquema oficial antes de la descarga.</div>
      <div className="mt-3"><DataTable columns={["Archivo", "Registros", "Tamaño", "Estado", "Fecha generación"]} rows={4} /></div>
    </WindowShell>
  );
}

function FlujoCaja() {
  return (
    <WindowShell title="Flujo de Caja Proyectado"
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Recalcular</button>
      </>}>
      <DataTable columns={["Semana", "Ingresos Proyectados", "Cobranza CxC", "Egresos Fijos", "Pagos CxP", "Saldo Neto", "Saldo Acumulado"]} rows={8} />
    </WindowShell>
  );
}

// ============================================================
// MACRO 3 · COMPRAS
// ============================================================
function SolicitudCompra() {
  return (
    <MasterDetailForm
      title="Solicitud de Compra — Requerimiento Interno"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Enviar Solicitud</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Añadir ítem</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}
      header={
        <div className="space-y-2">
          <div className="grid grid-cols-4 gap-2 text-[11px]">
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Pendientes:</span> <b className="font-mono text-amber-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Aprobadas:</span> <b className="font-mono text-emerald-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Urgentes:</span> <b className="font-mono text-red-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Solicitudes:</span> <b className="font-mono text-slate-900">0</b></div>
          </div>
          <div className="grid grid-cols-4 gap-3">
            <Field label="SC Nº"><input className={inp} placeholder="SC-2026-0001" /></Field>
            <Field label="Fecha"><input className={inp} type="date" /></Field>
            <Field label="Área Solicitante"><select className={inp}><option>Servicios Técnicos</option><option>Almacén</option><option>Administración</option><option>Ventas</option></select></Field>
            <Field label="Prioridad"><select className={inp}><option>Normal</option><option>Alta</option><option>Urgente</option></select></Field>
            <Field label="Solicitante" className="col-span-2"><input className={inp} /></Field>
            <Field label="Centro Costo"><select className={inp}><option>(Seleccionar)</option><option>Servicios</option><option>Operaciones</option><option>Administración</option></select></Field>
            <Field label="Estado"><select className={inp}><option>Borrador</option><option>Pendiente</option><option>Aprobada</option><option>Rechazada</option></select></Field>
          </div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Área" className="w-44"><select className={inp}><option>(Todas)</option><option>Servicios Técnicos</option><option>Almacén</option><option>Administración</option><option>Ventas</option></select></Field>
          <Field label="Prioridad" className="w-32"><select className={inp}><option>(Todas)</option><option>Normal</option><option>Alta</option><option>Urgente</option></select></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>(Todos)</option><option>Pendiente</option><option>Aprobada</option><option>Rechazada</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["#", "Código", "Descripción", "U.M.", "Cant.", "Uso destinado", "Prioridad", "Acción"]}
      rows={5}
      footer={<div className="px-1.5 pb-1.5"><Field label="Justificación" className="w-full"><textarea className={`${inp} h-14 py-1`} /></Field></div>}
    />
  );
}

function CotizacionesCompra() {
  return (
    <MasterDetailForm
      title="Cuadro Comparativo de Cotizaciones"
      toolbar={<>
        <button className={btnPrimary}>✓ Adjudicar Proveedor</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Nuevo proveedor</button>
        <button className={btn}><FileDown className="h-3.5 w-3.5" />PDF</button>
      </>}
      header={
        <div className="space-y-2">
          <div className="grid grid-cols-4 gap-2 text-[11px]">
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">OC por emitir:</span> <b className="font-mono text-amber-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Cotiz. recibidas:</span> <b className="font-mono text-slate-900">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Aprobadas:</span> <b className="font-mono text-emerald-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Proveedor ganador:</span> <b className="font-mono text-[#2A3F55]">-</b></div>
          </div>
          <div className="grid grid-cols-4 gap-3">
            <Field label="Solicitud Ref."><input className={inp} placeholder="SC-2026-0001" /></Field>
            <Field label="Fecha"><input className={inp} type="date" /></Field>
            <Field label="Criterio"><select className={inp}><option>Menor precio</option><option>Mejor plazo</option><option>Puntaje ponderado</option></select></Field>
            <Field label="Moneda"><select className={inp}><option>PEN</option><option>USD</option></select></Field>
          </div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Estado" className="w-40"><select className={inp}><option>(Todos)</option><option>En evaluación</option><option>Aprobada</option><option>Rechazada</option></select></Field>
          <Field label="Proveedor" className="w-56"><input className={inp} placeholder="RUC / Razón Social" /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Producto", "Cant.", "Proveedor A", "Proveedor B", "Proveedor C", "Mejor Precio", "Plazo (días)", "Selección", "Acción"]}
      rows={6}
    />
  );
}

function SolicitudGasto() {
  return (
    <MasterDetailForm
      title="Solicitud de Gasto — Caja / Compras Menores"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Enviar Solicitud</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Añadir concepto</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}
      header={
        <div className="space-y-2">
          <div className="grid grid-cols-4 gap-2 text-[11px]">
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Pendientes:</span> <b className="font-mono text-amber-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Aprobadas:</span> <b className="font-mono text-emerald-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Rendidas:</span> <b className="font-mono text-slate-900">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Monto total:</span> <b className="font-mono text-[#2A3F55]">S/ 0.00</b></div>
          </div>
          <div className="grid grid-cols-4 gap-3">
            <Field label="SG Nº"><input className={inp} placeholder="SG-2026-0001" /></Field>
            <Field label="Fecha"><input className={inp} type="date" /></Field>
            <Field label="Área"><select className={inp}><option>Administración</option><option>Operaciones</option><option>Ventas</option><option>Servicios</option></select></Field>
            <Field label="Prioridad"><select className={inp}><option>Normal</option><option>Alta</option><option>Urgente</option></select></Field>
            <Field label="Solicitante" className="col-span-2"><input className={inp} /></Field>
            <Field label="Tipo Gasto"><select className={inp}><option>Operativo</option><option>Servicio</option><option>Movilidad</option><option>Representación</option></select></Field>
            <Field label="Estado"><select className={inp}><option>Borrador</option><option>Pendiente</option><option>Aprobada</option><option>Rendida</option><option>Rechazada</option></select></Field>
          </div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>(Todos)</option><option>Pendiente</option><option>Aprobada</option><option>Rendida</option></select></Field>
          <Field label="Área" className="w-40"><select className={inp}><option>(Todas)</option><option>Administración</option><option>Operaciones</option><option>Ventas</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["#", "Concepto", "Centro costo", "Cant.", "P.Unit", "Subtotal", "IGV", "Total", "Acción"]}
      rows={5}
      summary={<CalculationSummaryBlock values={{ subtotal: 0, discount: 0, igv: 0, total: 0 }} />}
      footer={<div className="px-1.5 pb-1.5"><Field label="Justificación" className="w-full"><textarea className={`${inp} h-14 py-1`} /></Field></div>}
    />
  );
}

function OrdenCompra() {
  return (
    <MasterDetailForm
      title="Orden de Compra"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Emitir OC</button>
        <button className={btn}><Printer className="h-3.5 w-3.5" />Imprimir</button>
        <button className={btn}><Mail className="h-3.5 w-3.5" />Enviar Proveedor</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}
      header={
        <div className="space-y-2">
          <div className="grid grid-cols-4 gap-3">
            <Field label="OC Nº"><input className={inp} placeholder="OC-2026-0001" /></Field>
            <Field label="Fecha"><input className={inp} type="date" /></Field>
            <Field label="Fecha Entrega"><input className={inp} type="date" /></Field>
            <Field label="Moneda"><select className={inp}><option>PEN</option><option>USD</option></select></Field>
            <Field label="Proveedor RUC"><input className={inp} /></Field>
            <Field label="Razón Social" className="col-span-2"><input className={inp} /></Field>
            <Field label="Condición Pago"><select className={inp}><option>Contado</option><option>Crédito 30</option><option>Crédito 60</option></select></Field>
            <Field label="Almacén Destino"><select className={inp}><option>Central Lima</option><option>Norte</option><option>Sur</option></select></Field>
            <Field label="Solicitud Ref."><input className={inp} /></Field>
            <Field label="Comprador" className="col-span-2"><input className={inp} /></Field>
          </div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Proveedor" className="w-56"><input className={inp} defaultValue="(Todos)" /></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>(Todos)</option><option>EMITIDA</option><option>PARCIAL</option><option>CERRADA</option><option>ANULADA</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["#", "Código", "Descripción", "Cant.", "P.Unit", "Desc.", "IGV", "Total", "Acción"]}
      rows={6}
      summary={<CalculationSummaryBlock values={{ subtotal: 0, discount: 0, igv: 0, total: 0 }} />}
    />
  );
}

function Viaticos() {
  return (
    <WindowShell title="Planilla de Viáticos — Liquidación de Gastos de Viaje"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Liquidar</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Añadir gasto</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Personal" className="col-span-2"><input className={inp} /></Field>
        <Field label="Destino"><input className={inp} /></Field>
        <Field label="Motivo"><select className={inp}><option>Visita técnica</option><option>Visita comercial</option><option>Capacitación</option></select></Field>
        <Field label="Fecha Ida"><input className={inp} type="date" /></Field>
        <Field label="Fecha Retorno"><input className={inp} type="date" /></Field>
        <Field label="Adelanto S/"><input className={inp} type="number" /></Field>
        <Field label="Moneda"><select className={inp}><option>PEN</option><option>USD</option></select></Field>
      </div>
      <div className="mt-3"><DataTable columns={["#", "Fecha", "Concepto", "Comprobante", "Categoría", "Monto"]} rows={6} /></div>
      <div className="mt-3 grid grid-cols-4 gap-2 max-w-md ml-auto text-[11.5px]">
        <div className="text-right text-slate-600 col-span-3">Total gastado:</div><div className="text-right font-mono">0.00</div>
        <div className="text-right text-slate-600 col-span-3">Adelanto:</div><div className="text-right font-mono">0.00</div>
        <div className="text-right font-bold text-[#2A3F55] col-span-3">Saldo a favor / a devolver:</div><div className="text-right font-mono font-bold">0.00</div>
      </div>
    </WindowShell>
  );
}

function CtasXPagar() {
  return (
    <ListQueryForm
      title="Cuentas por Pagar — Programación de Pagos"
      toolbar={<>
      </>}
      extraTop={
        <div className="mx-1.5 mt-1.5 grid grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Vigente:</span> <b className="font-mono text-slate-900">S/ 0.00</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Vencido:</span> <b className="font-mono text-red-700">S/ 0.00</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Programado:</span> <b className="font-mono text-amber-700">S/ 0.00</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Pagado:</span> <b className="font-mono text-emerald-700">S/ 0.00</b></div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Proveedor" className="w-64"><input className={inp} placeholder="RUC / Razón Social" /></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>Todos</option><option>Vigente</option><option>Vencido</option><option>Pagado</option></select></Field>
          <Field label="Moneda" className="w-24"><select className={inp}><option>(Todas)</option><option>PEN</option><option>USD</option></select></Field>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Doc.", "Fecha", "Vence", "Proveedor", "Moneda", "Total", "Saldo", "Días", "Estado", "Acción"]}
      rows={10}
    />
  );
}

// ============= SERVICIOS / TALLERES =============
function OrdenTrabajo() {
  return (
    <WindowShell title="Orden de Trabajo — Taller / Servicio Técnico"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar OT</button>
        <button className={btn}><Printer className="h-3.5 w-3.5" />Imprimir</button>
        <button className={btn}><Wrench className="h-3.5 w-3.5" />Asignar mecánicos</button>
        <span className="ml-auto text-[11px] text-slate-500">Estado: <b className="text-amber-700">En proceso</b></span>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Nº OT"><input className={inp} defaultValue="OT-000000" readOnly /></Field>
        <Field label="Fecha"><input className={inp} type="date" /></Field>
        <Field label="Cliente" className="col-span-2"><input className={inp} placeholder="RUC / DNI / Razón Social" /></Field>
        <Field label="Placa / Equipo"><input className={inp} /></Field>
        <Field label="Marca"><input className={inp} /></Field>
        <Field label="Modelo"><input className={inp} /></Field>
        <Field label="Kilometraje"><input className={inp} type="number" /></Field>
        <Field label="Descripción de la falla" className="col-span-4">
          <textarea className={inp + " h-14 py-1"} />
        </Field>
      </div>
      <div className="grid grid-cols-2 gap-3 mt-3">
        <div>
          <div className="text-[11px] font-semibold text-slate-600 mb-1">Mano de Obra</div>
          <DataTable columns={["Mecánico", "Tarea", "Inicio", "Fin", "Horas", "Costo"]} rows={4} />
        </div>
        <div>
          <div className="text-[11px] font-semibold text-slate-600 mb-1">Repuestos utilizados</div>
          <DataTable columns={["Código", "Descripción", "Cant.", "P. Unit", "Total"]} rows={4} />
        </div>
      </div>
      <div className="mt-3 grid grid-cols-4 gap-2 max-w-md ml-auto text-[11.5px]">
        <div className="text-right text-slate-600 col-span-3">Mano de obra:</div><div className="text-right font-mono">0.00</div>
        <div className="text-right text-slate-600 col-span-3">Repuestos:</div><div className="text-right font-mono">0.00</div>
        <div className="text-right font-bold text-[#2A3F55] col-span-3">Total OT S/:</div><div className="text-right font-mono font-bold">0.00</div>
      </div>
    </WindowShell>
  );
}

function Marcaciones({ title = "Marcación de Tareas OT" }: { title?: string }) {
  return (
    <WindowShell title={title}
      toolbar={<>
        <button className={btnPrimary}><Play className="h-3.5 w-3.5" />Inicio Tarea</button>
        <button className={btn}><Square className="h-3.5 w-3.5" />Fin Tarea</button>
        <button className={btn}><Clock className="h-3.5 w-3.5" />Reloj biométrico</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Mecánico"><input className={inp} placeholder="Código / Nombre" /></Field>
        <Field label="OT"><input className={inp} /></Field>
        <Field label="Tarea" className="col-span-2"><input className={inp} /></Field>
      </div>
      <div className="mt-3"><DataTable columns={["Fecha", "Mecánico", "OT", "Tarea", "Inicio", "Fin", "Horas", "Estado"]} rows={8} /></div>
    </WindowShell>
  );
}

function PedirRepuestos() {
  return (
    <MasterDetailForm
      title="Pedir Repuestos — Enlace Taller ↔ Almacén"
      toolbar={<>
        <button className={btnPrimary}><Send className="h-3.5 w-3.5" />Enviar solicitud</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Añadir ítem</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}
      header={
        <div className="space-y-2">
          <div className="grid grid-cols-4 gap-2 text-[11px]">
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Pendientes:</span> <b className="font-mono text-amber-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Atendidas:</span> <b className="font-mono text-emerald-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Parciales:</span> <b className="font-mono text-slate-900">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Urgentes:</span> <b className="font-mono text-red-700">0</b></div>
          </div>
          <div className="grid grid-cols-4 gap-3">
            <Field label="OT origen"><input className={inp} /></Field>
            <Field label="Mecánico"><input className={inp} /></Field>
            <Field label="Almacén destino"><select className={inp}><option>Central</option><option>Repuestos</option></select></Field>
            <Field label="Prioridad"><select className={inp}><option>Normal</option><option>Urgente</option></select></Field>
          </div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>(Todos)</option><option>Pendiente</option><option>Atendido</option><option>Parcial</option></select></Field>
          <Field label="Taller" className="w-40"><select className={inp}><option>(Todos)</option><option>Taller Central</option><option>Taller Mina</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Código", "Descripción", "Cant. solicitada", "Cant. atendida", "Estado", "Acción"]}
      rows={6}
    />
  );
}

function GarantiaWin({ title }: { title: string }) {
  return (
    <MasterDetailForm
      title={title + " — Gestión de Garantía"}
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Registrar</button>
        <button className={btn}><FileDown className="h-3.5 w-3.5" />Adjuntos</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}
      header={
        <div className="space-y-2">
          <div className="grid grid-cols-4 gap-2 text-[11px]">
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Registradas:</span> <b className="font-mono text-slate-900">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Aprobadas:</span> <b className="font-mono text-emerald-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Rechazadas:</span> <b className="font-mono text-red-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">En taller:</span> <b className="font-mono text-amber-700">0</b></div>
          </div>
          <div className="grid grid-cols-4 gap-3">
            <Field label="Cliente" className="col-span-2"><input className={inp} /></Field>
            <Field label="Nº póliza / Serie"><input className={inp} /></Field>
            <Field label="Fecha reclamo"><input className={inp} type="date" /></Field>
            <Field label="Fabricante"><input className={inp} /></Field>
            <Field label="Equipo / Vehículo" className="col-span-2"><input className={inp} /></Field>
            <Field label="Cubre"><select className={inp}><option>Fabricante</option><option>Empresa</option><option>Compartida</option></select></Field>
            <Field label="Estado"><select className={inp}><option>Registrado</option><option>Evaluación</option><option>Aprobado</option><option>Rechazado</option></select></Field>
          </div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Estado" className="w-40"><select className={inp}><option>(Todos)</option><option>Evaluación</option><option>Aprobado</option><option>Rechazado</option></select></Field>
          <Field label="Fabricante" className="w-52"><input className={inp} /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Repuesto", "Cant.", "Costo cubierto", "Aprobado por", "Estado", "Acción"]}
      rows={4}
      footer={<div className="px-1.5 pb-1.5"><Field label="Descripción del defecto" className="w-full"><textarea className={inp + " h-14 py-1"} /></Field></div>}
    />
  );
}

function Kilometraje() {
  return (
    <WindowShell title="Kilometraje / Horómetros — Flota Vehicular"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Registrar lectura</button>
        <button className={btn}><Car className="h-3.5 w-3.5" />Alertas mantenimiento</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Placa / Equipo"><input className={inp} /></Field>
        <Field label="Fecha lectura"><input className={inp} type="date" /></Field>
        <Field label="Kilometraje / Horas"><input className={inp} type="number" /></Field>
        <Field label="Próximo servicio en"><input className={inp} type="number" /></Field>
      </div>
      <div className="mt-3"><DataTable columns={["Placa", "Última lectura", "Fecha", "Prox. servicio", "Días restantes", "Estado"]} rows={8} /></div>
    </WindowShell>
  );
}

function OficinaUsuario() {
  return (
    <ListQueryForm
      title="Oficina / Bahías del Taller"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Nueva bahía</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}
      extraTop={
        <div className="mx-1.5 mt-1.5 grid grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Bahías operativas:</span> <b className="font-mono text-emerald-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">En mantenimiento:</span> <b className="font-mono text-amber-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Inactivas:</span> <b className="font-mono text-red-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Capacidad total:</span> <b className="font-mono text-slate-900">0</b></div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Sede" className="w-44"><select className={inp}><option>(Todas)</option><option>Central</option><option>Norte</option><option>Sur</option></select></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>(Todos)</option><option>Operativa</option><option>Mantenimiento</option><option>Inactiva</option></select></Field>
          <Field label="Encargado" className="w-52"><input className={inp} /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Código", "Bahía / Puesto", "Sede", "Encargado", "Capacidad", "Estado", "Acción"]}
      rows={8}
    />
  );
}

// ============= RONDAS =============
function PuntosControl({ title }: { title: string }) {
  return (
    <WindowShell title={title + " — Rondas / Rutas de Control"}
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><MapPin className="h-3.5 w-3.5" />Ver en mapa</button>
        <button className={btn}><RefreshCw className="h-3.5 w-3.5" />Optimizar ruta</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Ruta" className="col-span-2"><input className={inp} /></Field>
        <Field label="Vigilante / Chofer"><input className={inp} /></Field>
        <Field label="Turno"><select className={inp}><option>Día</option><option>Noche</option></select></Field>
      </div>
      <div className="mt-3"><DataTable columns={["#", "Punto de control", "Dirección", "Hora exigida", "Tolerancia (min)", "Marcación"]} rows={8} /></div>
    </WindowShell>
  );
}

// ============= TELEFONÍA =============
function TelefoniaInv({ title }: { title: string }) {
  return (
    <WindowShell title={title + " — Inventario de Telefonía Corporativa"}
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Nuevo</button>
        <button className={btn}><Phone className="h-3.5 w-3.5" />Operadora</button>
      </>}>
      <DataTable columns={["Código", title, "Marca / Detalle", "Operadora", "Costo mensual", "Estado"]} rows={8} />
    </WindowShell>
  );
}

function AsignaPersona() {
  return (
    <WindowShell title="Asignar Teléfono / Línea a Colaborador"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Asignar</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Colaborador" className="col-span-2"><input className={inp} placeholder="DNI / Nombre" /></Field>
        <Field label="Equipo"><input className={inp} /></Field>
        <Field label="Línea"><input className={inp} /></Field>
        <Field label="Plan"><input className={inp} /></Field>
        <Field label="Fecha entrega"><input className={inp} type="date" /></Field>
        <Field label="Estado"><select className={inp}><option>Activo</option><option>Devuelto</option><option>Perdido</option></select></Field>
      </div>
      <div className="mt-3"><DataTable columns={["Fecha", "Colaborador", "Equipo", "Línea", "Plan", "Estado"]} rows={6} /></div>
    </WindowShell>
  );
}

// ============= PERSONAL / PLANILLAS =============
function PersonalTiempo({ title }: { title: string }) {
  return (
    <ListQueryForm
      title={title + " — Gestión de Tiempo / Planilla"}
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}
      extraTop={
        <div className="mx-1.5 mt-1.5 grid grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Pendiente aprobación:</span> <b className="font-mono text-amber-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Aprobado:</span> <b className="font-mono text-emerald-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Observado:</span> <b className="font-mono text-red-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Horas acumuladas:</span> <b className="font-mono text-slate-900">0.00</b></div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Colaborador" className="w-64"><input className={inp} placeholder="DNI / Nombre" /></Field>
          <Field label="Área" className="w-44"><input className={inp} /></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>(Todos)</option><option>Pendiente</option><option>Aprobado</option><option>Observado</option></select></Field>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Fecha", "Colaborador", "Área", title, "Horas", "Estado", "Aprobado por", "Acción"]}
      rows={10}
    />
  );
}

function MarcacionOnline() {
  return (
    <ListQueryForm
      title="Marcación en línea — Relojes Biométricos"
      toolbar={<>
        <button className={btn}><RefreshCw className="h-3.5 w-3.5" />Sincronizar relojes</button>
        <button className={btn}><Fingerprint className="h-3.5 w-3.5" />Historial</button>
        <span className="ml-auto text-[11px] text-slate-500">Última sincronización: <b>—</b></span>
      </>}
      extraTop={
        <div className="mx-1.5 mt-1.5 grid grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Marcaciones válidas:</span> <b className="font-mono text-emerald-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Observadas:</span> <b className="font-mono text-red-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Tardanzas:</span> <b className="font-mono text-amber-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Ausencias:</span> <b className="font-mono text-slate-900">0</b></div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Sede / Mina" className="w-40"><select className={inp}><option>Todas</option><option>Sede Central</option><option>Mina 1</option></select></Field>
          <Field label="Fecha" className="w-32"><input className={inp} type="date" defaultValue="2026-07-25" /></Field>
          <Field label="Turno" className="w-32"><select className={inp}><option>Todos</option><option>Mañana</option><option>Tarde</option><option>Noche</option></select></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>(Todos)</option><option>Válida</option><option>Observada</option><option>Tardanza</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Hora", "Colaborador", "Sede", "Tipo", "Estado", "Acción"]}
      rows={12}
    />
  );
}

function FichaGeneral() {
  return (
    <WindowShell title="Ficha General del Empleado"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Printer className="h-3.5 w-3.5" />Imprimir ficha</button>
        <button className={btn}><FileDown className="h-3.5 w-3.5" />Contrato PDF</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="DNI"><input className={inp} /></Field>
        <Field label="Apellidos" className="col-span-2"><input className={inp} /></Field>
        <Field label="Nombres"><input className={inp} /></Field>
        <Field label="Fecha nacimiento"><input className={inp} type="date" /></Field>
        <Field label="Estado civil"><select className={inp}><option>Soltero</option><option>Casado</option><option>Conviviente</option></select></Field>
        <Field label="Dirección" className="col-span-2"><input className={inp} /></Field>
        <Field label="Teléfono"><input className={inp} /></Field>
        <Field label="Email"><input className={inp} type="email" /></Field>
        <Field label="Contacto emergencia" className="col-span-2"><input className={inp} /></Field>
        <Field label="Tipo de contrato"><select className={inp}><option>Indefinido</option><option>Plazo fijo</option><option>Locación</option></select></Field>
        <Field label="Régimen salud"><select className={inp}><option>EsSalud</option><option>EPS</option></select></Field>
        <Field label="AFP"><select className={inp}><option>Integra</option><option>Prima</option><option>Profuturo</option><option>Habitat</option><option>ONP</option></select></Field>
        <Field label="Sueldo base S/"><input className={inp} type="number" /></Field>
      </div>
      <div className="mt-3">
        <div className="text-[11px] font-semibold text-slate-600 mb-1">Historial de puestos</div>
        <DataTable columns={["Desde", "Hasta", "Puesto", "Área", "Sueldo", "Motivo cambio"]} rows={4} />
      </div>
    </WindowShell>
  );
}

function CapacitacionesWin({ title }: { title: string }) {
  return (
    <MasterDetailForm
      title={title + " — Personal"}
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Programar</button>
        <button className={btn}><GraduationCap className="h-3.5 w-3.5" />Certificados</button>
      </>}
      header={
        <div className="space-y-2">
          <div className="grid grid-cols-4 gap-2 text-[11px]">
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Programadas:</span> <b className="font-mono text-slate-900">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">En curso:</span> <b className="font-mono text-amber-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Aprobadas:</span> <b className="font-mono text-emerald-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Observadas:</span> <b className="font-mono text-red-700">0</b></div>
          </div>
          <div className="grid grid-cols-4 gap-3">
            <Field label="Colaborador" className="col-span-2"><input className={inp} /></Field>
            <Field label="Área"><input className={inp} /></Field>
            <Field label="Periodo"><input className={inp} placeholder="2026" /></Field>
          </div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>(Todos)</option><option>Programada</option><option>En curso</option><option>Aprobada</option><option>Observada</option></select></Field>
          <Field label="Instructor" className="w-52"><input className={inp} /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Fecha", "Colaborador", title, "Duración", "Resultado", "Estado", "Acción"]}
      rows={8}
    />
  );
}

function PlanillaSueldos() {
  const [period, setPeriod] = useState("2026-07");
  const [branch, setBranch] = useState("Todas");
  const [regimen, setRegimen] = useState("General");
  const [bank, setBank] = useState("BCP");
  const [currency, setCurrency] = useState("PEN");
  const [processing, setProcessing] = useState(false);
  const [sending, setSending] = useState(false);
  const [message, setMessage] = useState<string | null>(null);
  const [lastPayrollId, setLastPayrollId] = useState<string | null>(null);

  const handleProcess = async () => {
    setProcessing(true);
    setMessage(null);
    try {
      const created = await createSigecoomSale({
        type: "Planilla Sueldos",
        series: "PLS001",
        number: Math.floor(Math.random() * 10000),
        date: new Date().toISOString().slice(0, 10),
        client_id: branch,
        items: [{ description: `Planilla ${period} — ${branch} — ${regimen}` , unit: "unidad", quantity: 1, price: 0 }],
        subtotal: 0,
        tax: 0,
        total: 0,
      });
      setLastPayrollId(created.id);
      setMessage(`Planilla procesada: ${created.series}-${created.number}`);
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error al procesar la planilla");
    } finally {
      setProcessing(false);
    }
  };

  const handleSendBoletas = async () => {
    if (!lastPayrollId) {
      setMessage("Procese la planilla antes de enviar las boletas.");
      return;
    }
    setSending(true);
    setMessage(null);
    try {
      await sendSigecoomSaleEmail(lastPayrollId);
      setMessage("Boletas enviadas correctamente.");
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo enviar las boletas");
    } finally {
      setSending(false);
    }
  };

  return (
    <WindowShell title="Planilla de Sueldos — Cálculo Mensual"
      toolbar={<>
        <button className={btnPrimary} onClick={handleProcess} disabled={processing}><Users className="h-3.5 w-3.5" />{processing ? "Procesando..." : "Procesar planilla"}</button>
        <button className={btn} disabled>{/* TXT bancario no implementado todavía */}<FileDown className="h-3.5 w-3.5" />TXT Bancario</button>
        <button className={btn} onClick={handleSendBoletas} disabled={sending || processing}><Mail className="h-3.5 w-3.5" />{sending ? "Enviando..." : "Enviar boletas"}</button>
      </>}
    >
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="grid grid-cols-5 gap-2 mb-3">
        <Field label="Periodo"><input className={inp} value={period} onChange={(e) => setPeriod(e.target.value)} placeholder="2026-07" /></Field>
        <Field label="Sede"><select className={inp} value={branch} onChange={(e) => setBranch(e.target.value)}><option>Todas</option><option>Central</option><option>Mina 1</option></select></Field>
        <Field label="Régimen"><select className={inp} value={regimen} onChange={(e) => setRegimen(e.target.value)}><option>General</option><option>Mype</option></select></Field>
        <Field label="Banco"><select className={inp} value={bank} onChange={(e) => setBank(e.target.value)}><option>BCP</option><option>BBVA</option><option>Interbank</option><option>Scotiabank</option></select></Field>
        <Field label="Moneda"><select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}><option>PEN</option><option>USD</option></select></Field>
      </div>
      <DataTable columns={["DNI", "Colaborador", "Sueldo base", "H. Extras", "Descuentos", "5ta Categoría", "AFP/ONP", "Neto"]} rows={10} />
      <div className="mt-3 grid grid-cols-4 gap-2 max-w-md ml-auto text-[11.5px]">
        <div className="text-right text-slate-600 col-span-3">Total bruto:</div><div className="text-right font-mono">0.00</div>
        <div className="text-right text-slate-600 col-span-3">Retenciones:</div><div className="text-right font-mono">0.00</div>
        <div className="text-right font-bold text-[#2A3F55] col-span-3">Neto a pagar S/:</div><div className="text-right font-mono font-bold">0.00</div>
      </div>
    </WindowShell>
  );
}

function ProcesarMarcas() {
  return <ProcesoLote label="Procesar Marcas" subtitle="Consolida marcaciones biométricas y calcula asistencia, tardanzas y horas trabajadas del periodo." />;
}

// ============= MACRO 6 · TABLAS MAESTRAS (CRUD) =============
function MantenimientoCRUD({ label, columns }: { label: string; columns: string[] }) {
  return (
    <WindowShell title={"Mantenimiento — " + label}
      toolbar={<>
        <button className={btnPrimary}><Plus className="h-3.5 w-3.5" />Nuevo</button>
        <button className={btn}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Trash2 className="h-3.5 w-3.5" />Eliminar</button>
        <button className={btn}><Search className="h-3.5 w-3.5" />Buscar</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
        <span className="ml-auto text-[11px] text-slate-500">Registros: <b>—</b></span>
      </>}>
      <div className="grid grid-cols-4 gap-3 mb-3">
        <Field label="Código"><input className={inp} /></Field>
        <Field label={label} className="col-span-2"><input className={inp} placeholder={"Descripción de " + label} /></Field>
        <Field label="Estado"><select className={inp}><option>Activo</option><option>Inactivo</option></select></Field>
      </div>
      <DataTable columns={columns} rows={10} />
    </WindowShell>
  );
}

// ============= MACRO 6 · LOGUEO =============
function CerrarSesion() {
  return (
    <WindowShell title="Cerrar Sesión">
      <div className="max-w-md mx-auto mt-6 p-6 border border-slate-300 rounded bg-slate-50">
        <div className="text-center text-[13px] text-slate-700 mb-4">¿Está seguro que desea cerrar la sesión actual? Se destruirá el token de autenticación y volverá a la pantalla de Login.</div>
        <div className="flex gap-2 justify-center">
          <button className={btnPrimary}>Sí, cerrar sesión</button>
          <button className={btn}>Cancelar</button>
        </div>
      </div>
    </WindowShell>
  );
}

function CambiarContrasena() {
  return (
    <WindowShell title="Cambiar Contraseña"
      toolbar={<><button className={btnPrimary}><Save className="h-3.5 w-3.5" />Actualizar</button></>}>
      <div className="max-w-md mx-auto mt-4 space-y-3">
        <Field label="Contraseña actual"><input className={inp} type="password" /></Field>
        <Field label="Nueva contraseña"><input className={inp} type="password" /></Field>
        <Field label="Confirmar nueva contraseña"><input className={inp} type="password" /></Field>
        <div className="text-[10.5px] text-slate-500 pt-1">Mínimo 8 caracteres, incluir mayúscula, minúscula, número y carácter especial.</div>
      </div>
    </WindowShell>
  );
}

function CambiarEmpresa() {
  return (
    <WindowShell title="Cambiar Empresa / Sucursal Fiscal"
      toolbar={<><button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Cambiar</button></>}>
      <div className="max-w-md mx-auto mt-4 space-y-3">
        <Field label="Empresa actual"><input className={inp} defaultValue="C2TECK S.A.C." readOnly /></Field>
        <Field label="Cambiar a">
          <select className={inp}>
            <option>C2TECK S.A.C.</option>
            <option>C2TECK Holding</option>
            <option>Sucursal Norte</option>
            <option>Sucursal Sur</option>
          </select>
        </Field>
        <Field label="Sede / Locación">
          <select className={inp}><option>Central</option><option>Mina 1</option><option>Taller</option></select>
        </Field>
      </div>
    </WindowShell>
  );
}

// ============= MACRO 6 · ADMINISTRACIÓN =============
function UsuariosAdmin() {
  return (
    <MasterDetailForm
      title="Usuarios — Administración"
      toolbar={<>
        <button className={btnPrimary}><Plus className="h-3.5 w-3.5" />Nuevo usuario</button>
        <button className={btn}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Trash2 className="h-3.5 w-3.5" />Desactivar</button>
      </>}
      header={
        <div className="space-y-2">
          <div className="grid grid-cols-4 gap-2 text-[11px]">
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Activos:</span> <b className="font-mono text-emerald-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Bloqueados:</span> <b className="font-mono text-red-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Sin acceso 30d:</span> <b className="font-mono text-amber-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Total usuarios:</span> <b className="font-mono text-slate-900">0</b></div>
          </div>
          <div className="grid grid-cols-4 gap-3">
            <Field label="Usuario"><input className={inp} /></Field>
            <Field label="Nombre completo" className="col-span-2"><input className={inp} /></Field>
            <Field label="Perfil"><select className={inp}><option>Administrador</option><option>Vendedor</option><option>Almacenero</option><option>Contador</option></select></Field>
            <Field label="Email"><input className={inp} type="email" /></Field>
            <Field label="DNI"><input className={inp} /></Field>
            <Field label="Sede"><select className={inp}><option>Central</option><option>Norte</option></select></Field>
            <Field label="Estado"><select className={inp}><option>Activo</option><option>Bloqueado</option></select></Field>
          </div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Sede" className="w-36"><select className={inp}><option>(Todas)</option><option>Central</option><option>Norte</option></select></Field>
          <Field label="Perfil" className="w-36"><select className={inp}><option>(Todos)</option><option>Administrador</option><option>Vendedor</option></select></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>(Todos)</option><option>Activo</option><option>Bloqueado</option></select></Field>
          <Field label="Búsqueda" className="w-64"><input className={inp} placeholder="Usuario / Nombre / DNI" /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Usuario", "Nombre", "Perfil", "Sede", "Último acceso", "Estado", "Acción"]}
      rows={10}
    />
  );
}

function Perfiles() {
  return (
    <MasterDetailForm
      title="Perfiles — Permisos Granulares"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar permisos</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Nuevo perfil</button>
      </>}
      header={
        <div className="grid grid-cols-3 gap-3">
          <Field label="Perfil"><select className={inp}><option>Administrador</option><option>Vendedor</option><option>Almacenero</option></select></Field>
          <Field label="Descripción" className="col-span-2"><input className={inp} /></Field>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Módulo" className="w-44"><select className={inp}><option>(Todos)</option><option>Ventas</option><option>Compras</option><option>Créditos</option></select></Field>
          <Field label="Nivel" className="w-32"><select className={inp}><option>(Todos)</option><option>Lectura</option><option>Escritura</option><option>Aprobar</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Módulo", "Pestaña", "Lectura", "Escritura", "Aprobar", "Sin acceso", "Acción"]}
      rows={10}
    />
  );
}

function Sesiones() {
  return (
    <ListQueryForm
      title="Sesiones activas — Auditoría"
      toolbar={<>
        <button className={btn}><RefreshCw className="h-3.5 w-3.5" />Refrescar</button>
        <button className={btnPrimary}><X className="h-3.5 w-3.5" />Cerrar sesión remota</button>
      </>}
      extraTop={
        <div className="mx-1.5 mt-1.5 grid grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Sesiones activas:</span> <b className="font-mono text-emerald-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Inactivas:</span> <b className="font-mono text-amber-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Remotas:</span> <b className="font-mono text-slate-900">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Alertas:</span> <b className="font-mono text-red-700">0</b></div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Usuario" className="w-52"><input className={inp} /></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>(Todos)</option><option>Activa</option><option>Inactiva</option><option>Bloqueada</option></select></Field>
          <Field label="Sede" className="w-36"><select className={inp}><option>(Todas)</option><option>Central</option><option>Norte</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Usuario", "IP", "Equipo", "Inicio sesión", "Última acción", "Módulo", "Estado", "Acción"]}
      rows={12}
    />
  );
}

function AtenderSolicitud() {
  return (
    <WindowShell title="Atender Solicitudes de Acceso"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Aprobar</button>
        <button className={btn}><X className="h-3.5 w-3.5" />Rechazar</button>
      </>}>
      <DataTable columns={["Fecha", "Usuario", "Solicitud", "Módulo", "Solicitado a", "Estado"]} rows={8} />
    </WindowShell>
  );
}

function EncuestaWin({ title }: { title: string }) {
  return (
    <WindowShell title={title + " — Clima Laboral / Satisfacción"}
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Send className="h-3.5 w-3.5" />Enviar</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Encuesta" className="col-span-2"><input className={inp} /></Field>
        <Field label="Público"><select className={inp}><option>Colaboradores</option><option>Clientes internos</option></select></Field>
        <Field label="Periodo"><input className={inp} placeholder="2026-Q3" /></Field>
      </div>
      <div className="mt-3"><DataTable columns={["#", "Pregunta", "Tipo", "Escala", "Obligatoria"]} rows={6} /></div>
    </WindowShell>
  );
}

function ComputadoraAsignar() {
  return (
    <WindowShell title="Asignar Computadora — Inventario TI"
      toolbar={<><button className={btnPrimary}><Save className="h-3.5 w-3.5" />Asignar</button></>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Colaborador" className="col-span-2"><input className={inp} /></Field>
        <Field label="Equipo (Serie)"><input className={inp} /></Field>
        <Field label="Fecha entrega"><input className={inp} type="date" /></Field>
        <Field label="Tipo"><select className={inp}><option>Laptop</option><option>Desktop</option><option>Monitor</option></select></Field>
        <Field label="Licencias"><input className={inp} placeholder="Office, Antivirus…" /></Field>
        <Field label="Estado"><select className={inp}><option>Asignado</option><option>Devuelto</option><option>Baja</option></select></Field>
      </div>
      <div className="mt-3"><DataTable columns={["Fecha", "Colaborador", "Equipo", "Tipo", "Licencias", "Estado"]} rows={6} /></div>
    </WindowShell>
  );
}

function ComputadoraInv() {
  return (
    <WindowShell title="Computadoras — Inventario Informático"
      toolbar={<>
        <button className={btnPrimary}><Plus className="h-3.5 w-3.5" />Nuevo</button>
        <button className={btn}><Save className="h-3.5 w-3.5" />Guardar</button>
      </>}>
      <DataTable columns={["Serie", "Marca", "Modelo", "Procesador", "RAM", "Almacenamiento", "Sede", "Estado"]} rows={10} />
    </WindowShell>
  );
}

function LlamadasWin() {
  return (
    <WindowShell title="Llamadas — Auditoría de Central Telefónica"
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}>
      <div className="grid grid-cols-5 gap-2 mb-3">
        <Field label="Anexo"><input className={inp} /></Field>
        <Field label="Número marcado"><input className={inp} /></Field>
        <Field label="Desde"><input className={inp} type="date" /></Field>
        <Field label="Hasta"><input className={inp} type="date" /></Field>
        <Field label="Tipo"><select className={inp}><option>Todas</option><option>Entrante</option><option>Saliente</option></select></Field>
      </div>
      <DataTable columns={["Fecha", "Hora", "Anexo", "Colaborador", "Nº marcado", "Duración", "Tipo", "Costo"]} rows={10} />
    </WindowShell>
  );
}

function ConfigTabla({ title, columns }: { title: string; columns: string[] }) {
  return (
    <WindowShell title={title + " — Configuración Avanzada"}
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Nuevo</button>
      </>}>
      <DataTable columns={columns} rows={8} />
    </WindowShell>
  );
}

// ============= MACRO 6 · AYUDA =============
function SolicitudSoporte() {
  return (
    <WindowShell title="Solicitud de Soporte — Ticket TI"
      toolbar={<><button className={btnPrimary}><Send className="h-3.5 w-3.5" />Enviar ticket</button></>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Nº ticket"><input className={inp} defaultValue="TCK-0000" readOnly /></Field>
        <Field label="Prioridad"><select className={inp}><option>Baja</option><option>Media</option><option>Alta</option><option>Crítica</option></select></Field>
        <Field label="Módulo afectado" className="col-span-2"><input className={inp} /></Field>
        <Field label="Asunto" className="col-span-4"><input className={inp} /></Field>
        <Field label="Descripción del problema" className="col-span-4"><textarea className={inp + " h-24 py-1"} /></Field>
        <Field label="Adjuntar captura" className="col-span-2"><input className={inp} type="file" /></Field>
      </div>
    </WindowShell>
  );
}

function Acerca() {
  return (
    <WindowShell title="Acerca de Systeck ERP Pro">
      <div className="max-w-lg mx-auto mt-4 p-5 border border-slate-300 rounded bg-slate-50 space-y-2 text-[12px]">
        <div className="font-display text-2xl font-bold text-[#2A3F55]">Systeck ERP Pro</div>
        <div className="text-slate-600">Versión <b>10.6.3.0</b></div>
        <div className="text-slate-600">Build: 2026.07.08</div>
        <hr className="my-2" />
        <div className="font-semibold text-slate-700">Notas del último parche</div>
        <ul className="list-disc pl-5 text-slate-600 space-y-0.5">
          <li>Nuevo panel de sesiones activas con cierre remoto.</li>
          <li>Mejoras en cálculo de quinta categoría.</li>
          <li>Integración con relojes biométricos de sedes remotas.</li>
        </ul>
        <hr className="my-2" />
        <div className="text-[10.5px] text-slate-500">© 2026 C2TECK S.A.C. — Todos los derechos reservados.</div>
        <div className="pt-2">
          <button
            className={btnPrimary}
            onClick={() => window.dispatchEvent(new Event("systeck-run-desktop-smoke"))}
          >
            <Play className="h-3.5 w-3.5" />Ejecutar recorrido E2E desktop
          </button>
        </div>
      </div>
    </WindowShell>
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
  "Doc. Salidas": () => <DocSalidasList />,
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
