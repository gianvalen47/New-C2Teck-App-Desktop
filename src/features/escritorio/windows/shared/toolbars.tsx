import React, { Children, cloneElement, isValidElement } from "react";
import {
  iconBtn,
  tbSep,
  btn,
  btnPrimary,
} from "@/components/ui/desktop-primitives";
import { openDesktopWindow } from "@/context/WindowsContext";
import {
  Printer,
  Plus,
  Search,
  Trash2,
  X,
  Send,
  RefreshCw,
  Receipt,
  FileDown,
  FileSearch,
  Clock,
  Wrench,
  Percent,
  DollarSign,
  Mail,
  Package,
  LogOut,
  MapPin,
} from "lucide-react";
import { TicketPrinterIcon, FileSpreadsheet, Mail as MailIcon } from "@/components/ui/icons";

export function enhanceToolbar(node: React.ReactNode): React.ReactNode {
  return Children.map(node, (child) => {
    if (!isValidElement(child)) return child;
    const el = child as React.ReactElement<any>;
    // if it's a button element (string type 'button') add click handler
    if (typeof el.type === "string" && el.type === "button") {
      const title = (el.props && (el.props as any).title) || "";
      return cloneElement(el, { onClick: () => openDesktopWindow(title) } as any);
    }
    if ((el.props as any)?.children) {
      return cloneElement(el, { children: enhanceToolbar((el.props as any).children) } as any);
    }
    return el;
  }) as React.ReactNode;
}

const _raw_stdToolbar3 = (
  <>
    <button className={iconBtn} title="Imprimir Documento">
      <Printer className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Crear un Nuevo Registro">
      <Plus className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Mostrar los datos del registro seleccionado">
      <Search className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Eliminar el registro seleccionado">
      <Trash2 className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Anular">
      <X className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Enviar Factura Electrónica">
      <Send className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Actualizar">
      <RefreshCw className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Generar Nota Electrónica">
      <Receipt className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Comunicación de Baja Nota Electrónica">
      <X className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Descargar Nota Electrónica">
      <FileDown className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Listar Notas Electrónicas">
      <FileSearch className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Listar Comunicados Baja">
      <FileSearch className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Cerrar la ventana actual">
      <LogOut className="h-4 w-4" />
    </button>
  </>
);

export const stdToolbar3 = enhanceToolbar(_raw_stdToolbar3);

const _raw_stdToolbarAlmacen = (
  <>
    <button className={iconBtn} title="Imprimir Documento">
      <Plus className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Crear un nuevo registro">
      <Plus className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Mostrar los datos del registro seleccionado">
      <Plus className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Chequear">
      <Plus className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Eliminar el registro seleccionado">
      <Search className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Generar Solicitud de Gastos">
      <RefreshCw className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Impresión de Facturas de Importación Masiva">
      <Printer className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Procesar Documento">
      <FileSpreadsheet className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Actualizar Datos">
      <Plus className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Cerrar la ventana actual">
      <LogOut className="h-4 w-4" />
    </button>
  </>
);

export const stdToolbarAlmacen = enhanceToolbar(_raw_stdToolbarAlmacen);

const _raw_stdToolbar19 = (
  <>
    <button className={iconBtn} title="Imprimir">
      <Printer className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Ticket">
      <TicketPrinterIcon className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Enviar">
      <Send className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="B2Mining">
      <Package className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Nuevo">
      <Plus className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Mostrar">
      <Search className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Eliminar">
      <Trash2 className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Estados de la Factura">
      <Clock className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Facturar OT">
      <Wrench className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Facturar Grupo G/R Pendientes">
      <Package className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Sugerir Factor o Descuento">
      <Percent className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Precios Sugeridos">
      <DollarSign className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Cuotas">
      <Percent className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Actualizar">
      <RefreshCw className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Actualizar Locacion">
      <MapPin className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Generar Nota Crédito">
      <Receipt className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Enviar Nota Crédito">
      <Mail className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Enviar Factura Electrónica">
      <Send className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Generar Factura Electrónica">
      <FileSpreadsheet className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Comunicación de Baja Factura Electrónica">
      <X className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Descargar Factura Electrónica">
      <FileDown className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Listar Facturas Electrónicas">
      <FileSearch className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Listar Comunicados Baja">
      <FileSearch className="h-4 w-4" />
    </button>
    {tbSep}
    <button className={iconBtn} title="Salir">
      <LogOut className="h-4 w-4" />
    </button>
  </>
);

export const stdToolbar19 = enhanceToolbar(_raw_stdToolbar19);

export const stdToolbar20 = stdToolbar19;
export const stdToolbar21 = stdToolbar19;
