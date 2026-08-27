import React from "react";
import {
  iconBtn,
  tbSep,
} from "@/components/ui/desktop-primitives";
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
import { TicketPrinterIcon, FileSpreadsheet } from "@/components/ui/icons";

export const FacturacionToolbar = (
  <>
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
    <button className={iconBtn} title="Estados"><Clock className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Facturar OT"><Wrench className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Nota Crédito"><Receipt className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Enviar Nota Crédito"><Mail className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Factura Electrónica"><FileSpreadsheet className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Descargar Factura Electrónica"><FileDown className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Listar Facturas"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4" /></button>
  </>
);

export const AlmacenToolbar = (
  <>
    <button className={iconBtn} title="Crear"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Chequear"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Eliminar"><Search className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Procesar"><FileSpreadsheet className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4" /></button>
  </>
);

export const StandardListToolbar = (
  <>
    <button className={iconBtn} title="Imprimir"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Nuevo"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar"><Search className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Eliminar"><Trash2 className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar"><RefreshCw className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4" /></button>
  </>
);

// compatibility aliases for existing names used across the codebase
export const stdToolbar3 = StandardListToolbar;
export const stdToolbarAlmacen = AlmacenToolbar;
export const stdToolbar19 = FacturacionToolbar;
export const stdToolbar20 = FacturacionToolbar;
export const stdToolbar21 = FacturacionToolbar;
