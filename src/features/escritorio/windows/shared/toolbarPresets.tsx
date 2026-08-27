// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
// Presets de barra de herramientas (JSX) usados por varias ventanas legacy.
import { X, Check, Printer, Search, Plus, Trash2, FileDown, FileSpreadsheet, Mail, Send, RefreshCw, DollarSign, Package, Wrench, Clock, MapPin, Copy, Receipt, LogOut, FileSearch, Percent } from "lucide-react";
import {
  iconBtn,
  tbSep
} from "@/components/ui/desktop-primitives";
import { TicketPrinterIcon } from "@/components/ui/icons";
import { stdToolbar3, stdToolbar4, stdToolbar5, stdToolbar6, stdToolbar7, stdToolbar8, stdToolbar9, stdToolbar10, stdToolbar11, stdToolbar12, stdToolbar13, stdToolbar14, stdToolbar15, stdToolbar16, stdToolbar17, stdToolbar18, stdToolbar19, stdToolbar20, stdToolbar21, stdToolbar22, stdToolbar23, stdToolbar24, stdToolbar25, stdToolbarAlmacen } from "@/features/escritorio/windows/shared/toolbarPresets";
import { Boleta } from "@/features/escritorio/windows/Ventas/Documentos/Boletas";
import { Factura } from "@/features/escritorio/windows/Ventas/Documentos/Facturas";
import { Notas } from "@/features/escritorio/windows/Ventas/Documentos/Notas";

export const stdToolbar3 = (
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

export const stdToolbar4 = (
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

export const stdToolbar5 = (
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

export const stdToolbar6 = (
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

export const stdToolbar7 = (
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

export const stdToolbar8 = (
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

export const stdToolbar9 = (
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

export const stdToolbar10 = (
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

export const stdToolbar11 = (
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

export const stdToolbar12 = (
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

export const stdToolbar13 = (
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

export const stdToolbar14 = (
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

export const stdToolbar15 = (
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

export const stdToolbar16 = (
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

export const stdToolbar17 = (
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

export const stdToolbar18 = (
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

export const stdToolbar19 = (
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

export const stdToolbar20 = (
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

export const stdToolbar21 = (
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

export const stdToolbar22 = (
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

export const stdToolbar23 = (
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

export const stdToolbar24 = (
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

export const stdToolbar25 = (
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

export const stdToolbarAlmacen = (
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
