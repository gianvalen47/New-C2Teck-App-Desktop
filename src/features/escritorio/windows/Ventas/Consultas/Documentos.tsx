import React from "react";
import { iconBtn, tbSep } from "@/features/escritorio/windows/uiStyles";
import { Printer, Send, Package, Plus, Search, FileSearch, LogOut } from "lucide-react";
import { TicketPrinterIcon } from "@/components/ui/icons";

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