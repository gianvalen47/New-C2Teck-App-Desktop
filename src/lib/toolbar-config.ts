import React from 'react'
import {
  Printer,
  TicketIcon,
  Send,
  Zap,
  FileText,
  Truck,
  Plus,
  Eye,
  Trash2,
  Ban,
  Lightbulb,
  Wrench,
  Search,
  TrendingDown,
  RefreshCw,
  Mail,
  FileCheck,
  FileX,
  Download,
  ListChecks,
  LogOut,
  Settings
} from 'lucide-react'

// Tipo compatible con ambos componentes Toolbar y ToolbarEnhanced
export interface ToolbarButton {
  id: string
  label: string
  tooltip?: string
  icon: React.ReactNode
  onClick?: () => void
  disabled?: boolean
  visible?: boolean
  group?: string
}

// Para compatibilidad con ToolbarEnhanced (es el mismo tipo)
export type ToolbarButtonWithIcon = ToolbarButton

/**
 * ConfiguraciÃ³n de botones para GuÃ­as de RemisiÃ³n
 * Convertido desde frmGuiasRemision.Designer.vb
 */
export const guiasRemisionToolbarButtons: ToolbarButton[] = [
  // Grupo ImpresiÃ³n
  {
    id: 'imprimir',
    label: 'Imprimir',
    tooltip: 'Imprimir GuÃ­a',
    icon: React.createElement(Printer, { className: "w-full h-full" }),
    group: 'impresion',
  },
  {
    id: 'ticket',
    label: 'Ticket',
    tooltip: 'Imprimir Ticket',
    icon: React.createElement(TicketIcon, { className: "w-full h-full" }),
    group: 'impresion',
  },

  // Grupo EnvÃ­os
  {
    id: 'enviar',
    label: 'Enviar',
    tooltip: 'Enviar a CrÃ©ditos',
    icon: React.createElement(Send, { className: "w-full h-full" }),
    group: 'envios',
  },
  {
    id: 'generar',
    label: 'Generar',
    tooltip: 'Generar Fac/Bol',
    icon: React.createElement(Zap, { className: "w-full h-full" }),
    group: 'envios',
  },
  {
    id: 'trasladar',
    label: 'Trasladar',
    tooltip: 'Trasladar GuÃ­a',
    icon: React.createElement(Truck, { className: "w-full h-full" }),
    group: 'envios',
  },
  {
    id: 'b2mining',
    label: 'B2Mining',
    tooltip: 'Enviar B2Mining',
    icon: React.createElement(Settings, { className: "w-full h-full" }),
    group: 'envios',
  },

  // Grupo GestiÃ³n
  {
    id: 'nuevo',
    label: 'Nuevo',
    tooltip: 'Nueva GuÃ­a',
    icon: React.createElement(Plus, { className: "w-full h-full" }),
    group: 'gestion',
  },
  {
    id: 'mostrar',
    label: 'Mostrar',
    tooltip: 'Mostrar GuÃ­a',
    icon: React.createElement(Eye, { className: "w-full h-full" }),
    group: 'gestion',
  },
  {
    id: 'eliminar',
    label: 'Eliminar',
    tooltip: 'Eliminar GuÃ­a',
    icon: React.createElement(Trash2, { className: "w-full h-full" }),
    group: 'gestion',
  },
  {
    id: 'anular',
    label: 'Anular',
    tooltip: 'Anular GuÃ­a',
    icon: React.createElement(Ban, { className: "w-full h-full" }),
    group: 'gestion',
  },

  // Grupo Operaciones
  {
    id: 'sugerir',
    label: 'Sugerir',
    tooltip: 'Sugerir Factor/Descuento',
    icon: React.createElement(Lightbulb, { className: "w-full h-full" }),
    group: 'operaciones',
  },
  {
    id: 'agregarConsumo',
    label: 'Consumo OT',
    tooltip: 'Agregar Consumo OT',
    icon: React.createElement(Wrench, { className: "w-full h-full" }),
    group: 'operaciones',
  },
  {
    id: 'estado',
    label: 'Estados',
    tooltip: 'Mostrar estados de guÃ­a',
    icon: React.createElement(Search, { className: "w-full h-full" }),
    group: 'operaciones',
  },
  {
    id: 'consultarSugerido',
    label: 'Precios',
    tooltip: 'Mostrar Precios Sugeridos',
    icon: React.createElement(FileText, { className: "w-full h-full" }),
    group: 'operaciones',
  },
  {
    id: 'bajarNivel',
    label: 'Bajar Nivel',
    tooltip: 'Bajar de Nivel',
    icon: React.createElement(TrendingDown, { className: "w-full h-full" }),
    group: 'operaciones',
  },
  {
    id: 'actualizar',
    label: 'Actualizar',
    tooltip: 'Actualizar GuÃ­as',
    icon: React.createElement(RefreshCw, { className: "w-full h-full" }),
    group: 'operaciones',
  },
  {
    id: 'enviarCorreo',
    label: 'Email',
    tooltip: 'Enviar Guia Remision Electronica',
    icon: React.createElement(Mail, { className: "w-full h-full" }),
    group: 'operaciones',
  },

  // Grupo ElectrÃ³nico
  {
    id: 'generarElectronica',
    label: 'Generar E.',
    tooltip: 'Generar Guia Electronica',
    icon: React.createElement(FileCheck, { className: "w-full h-full" }),
    group: 'electronico',
  },
  {
    id: 'darBajaElectronica',
    label: 'Baja E.',
    tooltip: 'Comunicacion de Baja Guia Electronica',
    icon: React.createElement(FileX, { className: "w-full h-full" }),
    group: 'electronico',
    visible: false,
  },
  {
    id: 'descargarElectronica',
    label: 'Descargar E.',
    tooltip: 'Descargar Guia Electronica',
    icon: React.createElement(Download, { className: "w-full h-full" }),
    group: 'electronico',
  },
  {
    id: 'listarElectronica',
    label: 'Listar E.',
    tooltip: 'Lista Guias Electronicas',
    icon: React.createElement(ListChecks, { className: "w-full h-full" }),
    group: 'electronico',
  },
  {
    id: 'listaComunicados',
    label: 'Comunicados',
    tooltip: 'Lista Comunicados Baja',
    icon: React.createElement(ListChecks, { className: "w-full h-full" }),
    group: 'electronico',
    visible: false,
  },

  // Grupo Control
  {
    id: 'salir',
    label: 'Salir',
    tooltip: 'Cerrar Formulario',
    icon: React.createElement(LogOut, { className: "w-full h-full" }),
    group: 'control',
  },
]

/**
 * ConfiguraciÃ³n de botones para GuÃ­as de DevoluciÃ³n
 * Similar a GuÃ­as de RemisiÃ³n pero con adaptaciones
 */
export const guiasDevolucionToolbarButtons: ToolbarButton[] = [
  // Grupo ImpresiÃ³n
  {
    id: 'imprimir',
    label: 'Imprimir',
    tooltip: 'Imprimir GuÃ­a de DevoluciÃ³n',
    icon: React.createElement(Printer, { className: "w-full h-full" }),
    group: 'impresion',
  },
  {
    id: 'ticket',
    label: 'Ticket',
    tooltip: 'Imprimir Ticket',
    icon: React.createElement(TicketIcon, { className: "w-full h-full" }),
    group: 'impresion',
  },

  // Grupo EnvÃ­os
  {
    id: 'enviar',
    label: 'Enviar',
    tooltip: 'Enviar a CrÃ©ditos',
    icon: React.createElement(Send, { className: "w-full h-full" }),
    group: 'envios',
  },
  {
    id: 'generar',
    label: 'Generar',
    tooltip: 'Generar Fac/Bol',
    icon: React.createElement(Zap, { className: "w-full h-full" }),
    group: 'envios',
  },

  // Grupo GestiÃ³n
  {
    id: 'nuevo',
    label: 'Nuevo',
    tooltip: 'Nueva GuÃ­a de DevoluciÃ³n',
    icon: React.createElement(Plus, { className: "w-full h-full" }),
    group: 'gestion',
  },
  {
    id: 'mostrar',
    label: 'Mostrar',
    tooltip: 'Mostrar GuÃ­a',
    icon: React.createElement(Eye, { className: "w-full h-full" }),
    group: 'gestion',
  },
  {
    id: 'eliminar',
    label: 'Eliminar',
    tooltip: 'Eliminar GuÃ­a',
    icon: React.createElement(Trash2, { className: "w-full h-full" }),
    group: 'gestion',
  },
  {
    id: 'anular',
    label: 'Anular',
    tooltip: 'Anular GuÃ­a',
    icon: React.createElement(Ban, { className: "w-full h-full" }),
    group: 'gestion',
  },

  // Grupo Operaciones
  {
    id: 'actualizar',
    label: 'Actualizar',
    tooltip: 'Actualizar GuÃ­as',
    icon: React.createElement(RefreshCw, { className: "w-full h-full" }),
    group: 'operaciones',
  },
  {
    id: 'enviarCorreo',
    label: 'Email',
    tooltip: 'Enviar Guia Remision Electronica',
    icon: React.createElement(Mail, { className: "w-full h-full" }),
    group: 'operaciones',
  },

  // Grupo ElectrÃ³nico
  {
    id: 'generarElectronica',
    label: 'Generar E.',
    tooltip: 'Generar Guia Electronica',
    icon: React.createElement(FileCheck, { className: "w-full h-full" }),
    group: 'electronico',
  },
  {
    id: 'descargarElectronica',
    label: 'Descargar E.',
    tooltip: 'Descargar Guia Electronica',
    icon: React.createElement(Download, { className: "w-full h-full" }),
    group: 'electronico',
  },

  // Grupo Control
  {
    id: 'salir',
    label: 'Salir',
    tooltip: 'Cerrar Formulario',
    icon: React.createElement(LogOut, { className: "w-full h-full" }),
    group: 'control',
  },
]

/**
 * ConfiguraciÃ³n de botones para Boletas
 * Convertido desde frmBoletas.Designer.vb
 */
export const boletasToolbarButtons: ToolbarButton[] = [
  // Grupo ImpresiÃ³n
  {
    id: 'imprimir',
    label: 'Imprimir',
    tooltip: 'Imprimir Boleta',
    icon: React.createElement(Printer, { className: "w-full h-full" }),
    group: 'impresion',
  },
  {
    id: 'ticket',
    label: 'Ticket',
    tooltip: 'Imprimir Ticket',
    icon: React.createElement(TicketIcon, { className: "w-full h-full" }),
    group: 'impresion',
  },

  // Grupo EnvÃ­os
  {
    id: 'enviar',
    label: 'Enviar',
    tooltip: 'Enviar a CrÃ©ditos',
    icon: React.createElement(Send, { className: "w-full h-full" }),
    group: 'envios',
  },
  {
    id: 'generar',
    label: 'Generar',
    tooltip: 'Generar Fac/Bol',
    icon: React.createElement(Zap, { className: "w-full h-full" }),
    group: 'envios',
  },

  // Grupo GestiÃ³n
  {
    id: 'nuevo',
    label: 'Nuevo',
    tooltip: 'Nueva Boleta',
    icon: React.createElement(Plus, { className: "w-full h-full" }),
    group: 'gestion',
  },
  {
    id: 'mostrar',
    label: 'Mostrar',
    tooltip: 'Mostrar Boleta',
    icon: React.createElement(Eye, { className: "w-full h-full" }),
    group: 'gestion',
  },
  {
    id: 'eliminar',
    label: 'Eliminar',
    tooltip: 'Eliminar Boleta',
    icon: React.createElement(Trash2, { className: "w-full h-full" }),
    group: 'gestion',
  },
  {
    id: 'anular',
    label: 'Anular',
    tooltip: 'Anular Boleta',
    icon: React.createElement(Ban, { className: "w-full h-full" }),
    group: 'gestion',
  },

  // Grupo Operaciones
  {
    id: 'sugerir',
    label: 'Sugerir',
    tooltip: 'Sugerir Factor/Descuento',
    icon: React.createElement(Lightbulb, { className: "w-full h-full" }),
    group: 'operaciones',
  },
  {
    id: 'estado',
    label: 'Estados',
    tooltip: 'Mostrar estados de boleta',
    icon: React.createElement(Search, { className: "w-full h-full" }),
    group: 'operaciones',
  },
  {
    id: 'actualizar',
    label: 'Actualizar',
    tooltip: 'Actualizar Boletas',
    icon: React.createElement(RefreshCw, { className: "w-full h-full" }),
    group: 'operaciones',
  },
  {
    id: 'enviarCorreo',
    label: 'Email',
    tooltip: 'Enviar Boleta Electronica',
    icon: React.createElement(Mail, { className: "w-full h-full" }),
    group: 'operaciones',
  },

  // Grupo ElectrÃ³nico
  {
    id: 'generarElectronica',
    label: 'Generar E.',
    tooltip: 'Generar Boleta Electronica',
    icon: React.createElement(FileCheck, { className: "w-full h-full" }),
    group: 'electronico',
  },
  {
    id: 'descargarElectronica',
    label: 'Descargar E.',
    tooltip: 'Descargar Boleta Electronica',
    icon: React.createElement(Download, { className: "w-full h-full" }),
    group: 'electronico',
  },

  // Grupo Control
  {
    id: 'salir',
    label: 'Salir',
    tooltip: 'Cerrar Formulario',
    icon: React.createElement(LogOut, { className: "w-full h-full" }),
    group: 'control',
  },
]

/**
 * ConfiguraciÃ³n de botones para Facturas
 * Similar a Boletas pero para facturas
 */
export const facturasToolbarButtons: ToolbarButton[] = [
  // Grupo ImpresiÃ³n
  {
    id: 'imprimir',
    label: 'Imprimir',
    tooltip: 'Imprimir Factura',
    icon: React.createElement(Printer, { className: "w-full h-full" }),
    group: 'impresion',
  },
  {
    id: 'ticket',
    label: 'Ticket',
    tooltip: 'Imprimir Ticket',
    icon: React.createElement(TicketIcon, { className: "w-full h-full" }),
    group: 'impresion',
  },

  // Grupo EnvÃ­os
  {
    id: 'enviar',
    label: 'Enviar',
    tooltip: 'Enviar a CrÃ©ditos',
    icon: React.createElement(Send, { className: "w-full h-full" }),
    group: 'envios',
  },
  {
    id: 'generar',
    label: 'Generar',
    tooltip: 'Generar Fac/Bol',
    icon: React.createElement(Zap, { className: "w-full h-full" }),
    group: 'envios',
  },

  // Grupo GestiÃ³n
  {
    id: 'nuevo',
    label: 'Nuevo',
    tooltip: 'Nueva Factura',
    icon: React.createElement(Plus, { className: "w-full h-full" }),
    group: 'gestion',
  },
  {
    id: 'mostrar',
    label: 'Mostrar',
    tooltip: 'Mostrar Factura',
    icon: React.createElement(Eye, { className: "w-full h-full" }),
    group: 'gestion',
  },
  {
    id: 'eliminar',
    label: 'Eliminar',
    tooltip: 'Eliminar Factura',
    icon: React.createElement(Trash2, { className: "w-full h-full" }),
    group: 'gestion',
  },
  {
    id: 'anular',
    label: 'Anular',
    tooltip: 'Anular Factura',
    icon: React.createElement(Ban, { className: "w-full h-full" }),
    group: 'gestion',
  },

  // Grupo Operaciones
  {
    id: 'sugerir',
    label: 'Sugerir',
    tooltip: 'Sugerir Factor/Descuento',
    icon: React.createElement(Lightbulb, { className: "w-full h-full" }),
    group: 'operaciones',
  },
  {
    id: 'estado',
    label: 'Estados',
    tooltip: 'Mostrar estados de factura',
    icon: React.createElement(Search, { className: "w-full h-full" }),
    group: 'operaciones',
  },
  {
    id: 'actualizar',
    label: 'Actualizar',
    tooltip: 'Actualizar Facturas',
    icon: React.createElement(RefreshCw, { className: "w-full h-full" }),
    group: 'operaciones',
  },
  {
    id: 'enviarCorreo',
    label: 'Email',
    tooltip: 'Enviar Factura Electronica',
    icon: React.createElement(Mail, { className: "w-full h-full" }),
    group: 'operaciones',
  },

  // Grupo ElectrÃ³nico
  {
    id: 'generarElectronica',
    label: 'Generar E.',
    tooltip: 'Generar Factura Electronica',
    icon: React.createElement(FileCheck, { className: "w-full h-full" }),
    group: 'electronico',
  },
  {
    id: 'descargarElectronica',
    label: 'Descargar E.',
    tooltip: 'Descargar Factura Electronica',
    icon: React.createElement(Download, { className: "w-full h-full" }),
    group: 'electronico',
  },

  // Grupo Control
  {
    id: 'salir',
    label: 'Salir',
    tooltip: 'Cerrar Formulario',
    icon: React.createElement(LogOut, { className: "w-full h-full" }),
    group: 'control',
  },
]

