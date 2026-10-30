import { createContext, useContext, useState, useRef, useCallback, type ReactNode } from "react";

// ---------- Context (MDI floating windows) ----------
export type WindowSize = { w: number; h: number };
export type WindowPos = { x: number; y: number };

export type OpenWindow = {
  id: string;
  label: string;
  title: string;
  position: WindowPos;
  size: WindowSize;
  zIndex: number;
  isMaximized: boolean;
  isMinimized: boolean;
  canMaximize?: boolean;
};

type Ctx = {
  windows: OpenWindow[];
  active: string | null;
  open: (label: string) => void;
  close: (id: string) => void;
  focus: (id: string) => void;
  move: (id: string, pos: WindowPos) => void;
  toggleMaximize: (id: string) => void;
  toggleFromTaskbar: (id: string) => void;
  minimize: (id: string) => void;
  restore: (id: string) => void;
};

const WindowsCtx = createContext<Ctx | null>(null);
const WINDOWS_FALLBACK_CTX: Ctx = {
  windows: [],
  active: null,
  open: () => {},
  close: () => {},
  focus: () => {},
  move: () => {},
  toggleMaximize: () => {},
  toggleFromTaskbar: () => {},
  minimize: () => {},
  restore: () => {},
};

function getWindowOptions(label: string) {
  const normalized = normalizeWindowLabel(label);
  const blocked = new Set([
    "Registro",
    "Registro Venta",
    "Registro de Ventas",
    "Registro Ventas",
  ]);
  return {
    canMaximize: !blocked.has(normalized),
  };
}


// ---------- Utilidades de Configuración y Cálculo ----------
function getInitialSize(label: string): WindowSize {
  const vw = typeof window !== "undefined" ? window.innerWidth : 1280;
  const vh = typeof window !== "undefined" ? window.innerHeight : 800;
  const maxH = Math.max(400, vh - 140 - 56 - 20);

  const fit = (preferred: number, min: number, max: number) => {
    const boundedMin = Math.min(min, max);
    return Math.max(boundedMin, Math.min(preferred, max));
  };

  // Tamaños específicos por ventana
  const windowSizes: Record<string, { w: number; h: number }> = {
    // Registros (usando los nombres exactos del REGISTRY)
    "Registro": { w: 466, h: 488 },
    "Registro Auxiliar": { w: 402, h: 478 },
    "Resumen Registro": { w: 395, h: 433 },
    "Consignaciones": { w: 461, h: 413 },
    "Reporte Acumulada": { w: 500, h: 520 },
    "Reporte Mensual Cliente": { w: 540, h: 450 },
    "Mensuales x Cliente": { w: 540, h: 471 },
    "Reporte de Ventas Mensuales por Cliente": { w: 540, h: 450 },
    "Vales de Requisiciones": { w: 523, h: 313 },
    "Reporte Vale Requisición": { w: 523, h: 313 },
    "Vale Requisición": { w: 563, h: 313 },
    "Comisiones": { w: 415, h: 244 },
    "Reclamos" : { w: 422, h: 352 },
    "Reporte Orden Compra": { w: 600, h: 650 },
    "Reporte Detalle Descuento": { w: 520, h: 450 },
    "Reporte Consignacion": { w: 500, h: 370 },
    "Reporte Cotizaciones": { w: 470, h: 500 },
    "Reporte de Cotización": { w: 544, h: 287 },
    "Reporte de Cotizacion": { w: 544, h: 287 },
    "Reportes Cotizaciones": { w: 544, h: 287 },
    "Gastos Detallado": { w: 644, h: 426 },
    "Gastos Generales": { w: 644, h: 426 },
    "Total x Rubro": { w: 561, h: 401 },
    "Gastos Por Rubros": { w: 561, h: 401 },
    "Gastos por Rubro": { w: 561, h: 401 },
    "Gastos Viaje Total x Rubro": { w: 561, h: 401 },
    "Movimiento Repuestos": { w: 430, h: 308 },
    "Reporte de Movimiento de Repuestos": { w: 430, h: 308 },
    "Horas Generales": { w: 603, h: 237 },
    "Horas De Trabajo": { w: 603, h: 237 },
    "Reporte de Horas Muertas": { w: 493, h: 241 },
    "Horas Muertas": { w: 493, h: 241 },
    "Reporte de Horas Motor": { w: 284, h: 222 },
    "Horas De Motores": { w: 284, h: 222 },
    "Horas de Motores": { w: 284, h: 222 },
    "Reporte de Disponibilidad Motor": { w: 599, h: 356 },
    "Disponibilidad Del Motor": { w: 599, h: 356 },
    "Disponibilidad Motor": { w: 599, h: 356 },
    "Reporte de Motores a Dar de Baja": { w: 355, h: 173 },
    "Motores A Dar De Baja": { w: 355, h: 173 },
    "Reporte Proyección de Repuestos a Consumir": { w: 445, h: 233 },
    "Reporte Proyeccion de Repuestos a Consumir": { w: 445, h: 233 },
    "Repuestos A Importar": { w: 445, h: 233 },
    "Repuestos a Importar": { w: 445, h: 233 },
    "Reporte de Seguimiento": { w: 586, h: 334 },
    "Seguimientos": { w: 586, h: 334 },
    "Reporte Seguimiento": { w: 586, h: 334 },
    "Reporte de Proyección de Reparaciones Anuales": { w: 384, h: 283 },
    "Reporte de Proyeccion de Reparaciones Anuales": { w: 384, h: 283 },
    "Proyeccion De Reparaciones": { w: 384, h: 283 },
    "Reporte Ventas Proyectadas por Mantenimiento": { w: 437, h: 156 },
    "Ventas Por Mantenimientos": { w: 437, h: 156 },
    "Reporte Consolidado de Horas": { w: 484, h: 266 },
    "Horas Escalon": { w: 484, h: 266 },
    "Horas Escalón": { w: 484, h: 266 },
    "OT Garantia": { w: 440, h: 436 },
    "OT Garantía": { w: 440, h: 436 },
    "Liquidacion X Garantia": { w: 440, h: 436 },
    "Liquidación X Garantía": { w: 440, h: 436 },
    "Liquidacion x Garantia": { w: 440, h: 436 },
    "Liquidación x Garantía": { w: 440, h: 436 },
    "OT Tiempo de Reparación": { w: 278, h: 212 },
    "OT Tiempo de Reparacion": { w: 278, h: 212 },
    "Tiempo Reparación": { w: 278, h: 212 },
    "Tiempo Reparacion": { w: 278, h: 212 },
    "OT Pendiente Facturación": { w: 611, h: 286 },
    "OT Pendiente Facturacion": { w: 611, h: 286 },
    "Pendiente Facturación": { w: 611, h: 286 },
    "Pendiente Facturacion": { w: 611, h: 286 },
    "Reporte de Ventas Detallado": { w: 565, h: 620 },
    "Reporte Venta Detallado": { w: 565, h: 620 },
    "Reporte GR Pendiente": { w: 600, h: 450 },
    "Órdenes Compra": { w: 594, h: 615 },
    "Presupuesto Venta": { w: 360, h: 277 },
    "Detalle Descuento": { w: 412, h: 448 },

    // Guías y Documentos
    "Guía Remisión": { w: 1020, h: 380 },
    "Guías Remisión": { w: 388, h: 404 },
    "Guia Remision": { w: 920, h: 680 },
    "G/R Pendiente": { w: 508, h: 509 },
    "Nueva Guía": { w: 880, h: 680 },
    "Nueva Guia": { w: 880, h: 680 },
    "Factura": { w: 900, h: 700 },
    "Boleta": { w: 900, h: 700 },
    "Resumen de Boletas": { w: 900, h: 700 },
    "Guía Devolución": { w: 880, h: 680 },
    "Notas": { w: 880, h: 680 },
    "Nueva Nota": { w: 880, h: 680 },

    // Pre y Post Venta
    "Cotizaciones": { w: 465, h: 561 },
    "Cotizacion": { w: 900, h: 700 },
    "Reclamo Garantía": { w: 820, h: 620 },
    "Separar Orden": { w: 800, h: 600 },
    "Ordenes Compra": { w: 880, h: 680 },
    "Actualizar Vendedor": { w: 760, h: 540 },
    "Enviar Correos": { w: 800, h: 600 },

    // Clientes / Requisiciones
    "Cartera": { w: 920, h: 700 },
    "Despacho": { w: 900, h: 680 },
    "Requisiciones": { w: 900, h: 680 },
    "Vales": { w: 880, h: 660 },
    "Tarjetas": { w: 800, h: 600 },
    "Calendario": { w: 900, h: 650 },

    // Precios
    "Precios Cliente": { w: 880, h: 660 },
    "Precio Oferta": { w: 880, h: 660 },
    "Factores Rubros": { w: 900, h: 680 },
    "Precio Lista": { w: 880, h: 660 },
    "Precio Fabricantes": { w: 900, h: 680 },
    "Consulta de Precios": { w: 744, h: 464 },
    "Consulta Precios": { w: 744, h: 464 },
    "Precio Consulta": { w: 744, h: 464 },
    "Precios": { w: 744, h: 464 },
    "Acumulada": { w: 464, h: 633 },
    "Detalle": { w: 490, h: 766 },
    "Detalle Vencimientos": { w: 530, h: 590 },
    "Reporte de Vencimientos": { w: 530, h: 590 },
    "Vencimientos Detalle": { w: 530, h: 590 },
    "Acumulado Vencimientos": { w: 360, h: 362 },
    "Vencimientos Acumulado": { w: 470, h: 390 },
    "Reporte de Vencimientos Acumulado": { w: 470, h: 390 },

    // Créditos
    "Ctas x Cobrar": { w: 920, h: 700 },
    "Cuentas x Cobrar": { w: 920, h: 700 },
    "Ctas. x Cobrar": { w: 920, h: 700 },
    "Anticipos": { w: 880, h: 660 },
    "Planillas": { w: 900, h: 700 },
    "Letras": { w: 880, h: 660 },
    "Créditos": { w: 820, h: 620 },
    "Creditos": { w: 820, h: 620 },
    "Permiso Usuario": { w: 760, h: 540 },
    "Cotiz. Taller": { w: 840, h: 640 },
    "Recepcion Doc.": { w: 880, h: 660 },
    "Recepción Doc.": { w: 880, h: 660 },
    "Saldo Bancos": { w: 900, h: 700 },
    "Tipo Cambio Ventas": { w: 800, h: 600 },
    "Mantenimiento Tipo de Cambio": { w: 800, h: 600 },
    "Renueva Tipo Cambio": { w: 800, h: 600 },
    "Procesar Job": { w: 820, h: 640 },
    "Vincular G/R": { w: 820, h: 640 },

    // Almacenes
    "Doc. Ingresos": { w: 920, h: 700 },
    "Doc.Ingresos": { w: 920, h: 700 },
    "Doc.Salidas": { w: 920, h: 700 },
    "Doc. Salidas": { w: 920, h: 700 },
    "Chequeo F/I": { w: 880, h: 680 },
    "MTI": { w: 900, h: 700 },
    "M T I": { w: 900, h: 700 },
    "Atender OT": { w: 920, h: 700 },
    "T / I": { w: 900, h: 700 },
    "T/I": { w: 900, h: 700 },
    "Vales / Despachos": { w: 920, h: 700 },
    "Productos": { w: 900, h: 700 },
    "Liqui. Gastos": { w: 840, h: 640 },
    "Act. Min Max": { w: 880, h: 660 },
    "Ubicaciones": { w: 820, h: 620 },
    "Procesar Cobertura": { w: 440, h: 260 },
    "Procesar Cobertura de Tablero": { w: 440, h: 260 },
    "Sin Movimiento Report": { w: 540, h: 420 },
    "Sin Movimiento": { w: 451, h: 420 },
    "Inventario": { w: 765, h: 620 },
    "Inventario sin Movimiento": { w: 540, h: 420 },
    "Reporte Sin Movimiento": { w: 540, h: 420 },
    "Reporte Toma de Inventario": { w: 660, h: 520 },
    "Toma Inventario Report": { w: 660, h: 605 },
    "Toma de Inventario": { w: 660, h: 605 },
    "Documento Reporte": { w: 560, h: 405 },
    "Reporte de Documentos": { w: 560, h: 405 },
    "Reporte Documentos": { w: 560, h: 405 },
    "Reporte de Visitas del Cobrador": { w: 457, h: 492 },
    "Reporte Vis Co": { w: 457, h: 492 },
    "Visita Cobrador": { w: 457, h: 492 },
    "Visitas Cobrador": { w: 457, h: 492 },
    "Reporte de Letras": { w: 468, h: 269 },
    "Reporte de Letras Aceptadas": { w: 468, h: 269 },
    "Letras Aceptadas": { w: 468, h: 269 },
    "Reporte de Notas Débito/Crédito": { w: 406, h: 222 },
    "Reporte de Notas Debito/Credito": { w: 406, h: 222 },
    "Reporte Not Deb Cred": { w: 406, h: 222 },
    "Notas Débito/Crédito": { w: 406, h: 222 },
    "Notas Débito / Crédito": { w: 406, h: 222 },
    "Reporte de Planilla": { w: 480, h: 470 },
    "Reporte Planillas": { w: 480, h: 470 },
    "Planillas Report": { w: 480, h: 470 },
    "Diario de Pagos": { w: 520, h: 621 },
    "Reporte Diario": { w: 520, h: 560 },
    "Reporte Diario de Pagos": { w: 520, h: 560 },
    "Cuentas Corrientes": { w: 598, h: 608 },
    "Reporte de Cuentas Corrientes": { w: 650, h: 570 },
    "Reporte Cuentas Corrientes": { w: 650, h: 570 },
    "Ctas Ctes": { w: 560, h: 450 },
    "Reporte de Cuentas Corrientes Contabilidad": { w: 560, h: 450 },
    "Ctas Ctes Pendiente": { w: 560, h: 600 },
    "Reporte Cuentas Corrientes Pendientes": { w: 560, h: 600 },
    "Reporte de Cuentas Corrientes Pendientes": { w: 560, h: 600 },
    "Reporte Reembolso": { w: 550, h: 360 },
    "Reporte de Reembolso x Tipo de Gasto": { w: 550, h: 360 },
    "Reembolso x Tipo de Gasto": { w: 550, h: 360 },
    "Report Ctas X Pagar": { w: 470, h: 530 },
    "Reporte de Cuentas x Pagar Contable": { w: 470, h: 530 },
    "Reporte de Cuentas por Pagar Contable": { w: 470, h: 530 },
    "Ctas x Pagar Contable": { w: 470, h: 530 },
    "ReporteVencimiento": { w: 550, h: 380 },
    "Reporte de Vencimientos de Cuentas x Pagar Contable": { w: 550, h: 380 },
    "Reporte de Vencimientos de Cuentas por Pagar Contable": { w: 550, h: 380 },
    "Reporte Vencimientos Cuentas por Pagar Contable": { w: 550, h: 380 },
    "Indicadores de Usuario": { w: 680, h: 550 },
    "Documentos Emitidos": { w: 452, h: 408 },
    "Reporte Doc Emi": { w: 580, h: 470 },
    "Reporte de Documentos Emitidos": { w: 580, h: 470 },
    "Reporte Límite de Crédito": { w: 407, h: 239 },
    "Reporte Limite de Credito": { w: 407, h: 239 },
    "Reporte Clientes": { w: 407, h: 239 },
    "000 - Ventas": { w: 620, h: 460 },
    "Gerencia Ventas Window": { w: 620, h: 460 },
    "Reporte Gerencial de Ventas": { w: 620, h: 460 },
    "010 - Importaciones": { w: 470, h: 400 },
    "Gerencia Importaciones Window": { w: 470, h: 400 },
    "Reporte Gerencial de Importaciones": { w: 470, h: 400 },
    "020 - Inventario y Costos": { w: 460, h: 700 },
    "Gerencia Inventario Costos Window": { w: 460, h: 700 },
    "Reporte Gerencial de Inventarios y Costos": { w: 460, h: 700 },
    "030 - Contabilidad": { w: 620, h: 390 },
    "Gerencia Contabilidad Window": { w: 620, h: 390 },
    "Reporte Gerencial de Contabilidad": { w: 620, h: 390 },
    "040 - Creditos y Cobranzas": { w: 510, h: 410 },
    "040 - Créditos y Cobranzas": { w: 510, h: 410 },
    "Gerencia Creditos Window": { w: 510, h: 410 },
    "Reporte Gerencial de Créditos y Cobranzas": { w: 510, h: 410 },
    "Estados Financieros": { w: 620, h: 390 },
    "Reporte Estado Financiero Gerencia": { w: 620, h: 390 },
    "Estado Financiero": { w: 560, h: 380 },
    "Reporte Balances": { w: 560, h: 380 },
    "Reporte de Balances": { w: 560, h: 380 },
    "GMROI": { w: 570, h: 380 },
    "Reporte de GMROI": { w: 570, h: 380 },
    "Importaciones": { w: 380, h: 470 },
    "Reporte de Importaciones": { w: 380, h: 470 },
    "Importaciones Costos Report": { w: 380, h: 470 },
    "Kardex": { w: 470, h: 475 },
    "Kardex de Almacén": { w: 470, h: 460 },
    "Kardex de Almacen": { w: 470, h: 460 },
    "Condensados": { w: 370, h: 220 },
    "Reporte de Condensados": { w: 370, h: 260 },
    "Motores Costos Report": { w: 500, h: 390 },
    "Reporte de Motores": { w: 500, h: 390 },
    "Resumen General": { w: 360, h: 358 },
    "Reporte de Resumen General": { w: 410, h: 390 },
    "Resumen General Costos Report": { w: 410, h: 390 },
    "Sobregiro": { w: 340, h: 240 },
    "Reporte de Sobregiro": { w: 340, h: 240 },
    "Sobregiro Costos Report": { w: 340, h: 240 },
    "Stock Valorizado": { w: 570, h: 470 },
    "Reporte de Stock Valorizado": { w: 570, h: 470 },
    "Stock Valorizado Costos Report": { w: 570, h: 470 },
    "Costo de Venta": { w: 600, h: 633 },
    "Reporte de Costo de Venta": { w: 600, h: 590 },
    "Embarques de Importación": { w: 470, h: 390 },
    "Embarque Importacion": { w: 470, h: 390 },
    "Reporte de Embarques": { w: 470, h: 390 },
    "Embarques Importacion": { w: 470, h: 390 },
    "Reporte de Pedidos": { w: 390, h: 420 },
    "Reporte Orden Importacion": { w: 390, h: 420 },
    "Reporte Orden de Importación": { w: 390, h: 420 },
    "Vale Materiales Report": { w: 640, h: 430 },
    "Vale Materiales": { w: 429, h: 511 },
    "Entrega de Materiales": { w: 640, h: 430 },
    "Reporte de Entrega de Materiales": { w: 640, h: 430 },
    "Movimientos Almacen Report": { w: 560, h: 660 },
    "Movimientos": { w: 560, h: 660 },
    "Movimientos Almacen": { w: 560, h: 660 },
    "Reporte de Movimientos de Almacén": { w: 560, h: 660 },
    "Transferencias": { w: 397, h: 452 },
    "Reporte Transferencia": { w: 540, h: 410 },
    "Reporte Transferencia Interna": { w: 540, h: 410 },
    "Inventario Permanente Valorizado": { w: 470, h: 430 },
    "Inv. Perm. Valorizado": { w: 407, h: 433 },
    "Reporte Valorizado": { w: 470, h: 430 },
    "Reporte de Inventario": { w: 765, h: 620 },
    "Reporte Inventario": { w: 765, h: 620 },
    "Inventario General": { w: 765, h: 620 },
    "Compras": { w: 900, h: 700 },
    "Documentos": { w: 920, h: 700 },
    "Anulación en Consulta": { w: 880, h: 680 },

    // Importaciones
    "Orden Importación": { w: 920, h: 700 },
    "Orden de Importación": { w: 920, h: 700 },
    "Embarque": { w: 900, h: 700 },
    "Internos": { w: 880, h: 680 },

    // Costos
    "Gestión de Costos": { w: 1000, h: 750 },
    "Costos": { w: 1000, h: 750 },

    // Contabilidad
    "Asiento": { w: 920, h: 700 },
    "Diario": { w: 1000, h: 750 },
    "Mayor": { w: 1000, h: 750 },
    "Balance": { w: 900, h: 700 },

    // Taller
    "Orden de Trabajo": { w: 920, h: 700 },
    "OT": { w: 680, h: 560 },
    "Reporte de OT": { w: 680, h: 560 },
    "Reporte OT": { w: 680, h: 560 },
    "Reporte Solicitud OT": { w: 620, h: 440 },
    "Solicitud de OT": { w: 620, h: 440 },
    "Reporte de Solicitud de OT": { w: 620, h: 440 },
    "Solicitud Garantia": { w: 560, h: 480 },
    "Solicitud Garantía": { w: 560, h: 480 },
    "Reporte Solicitud Garantía": { w: 560, h: 480 },
    "Reporte de Solicitud de Garantía": { w: 560, h: 480 },
    "Reporte Solicitud Gastos": { w: 780, h: 480 },
    "Solicitud Gastos": { w: 780, h: 480 },
    "Reporte de Solicitud de Gastos": { w: 780, h: 480 },
    "Reporte de Solicitud de Gasto": { w: 780, h: 480 },

    // Personal
    "Marcaciones": { w: 880, h: 650 },
    "Asistencia": { w: 520, h: 300 },
    "Reporte de Asistencias": { w: 520, h: 300 },
    "Reporte Asistencias": { w: 520, h: 300 },
    "Reporte de Asistencia": { w: 520, h: 300 },
    "Onomasticos": { w: 278, h: 186 },
    "Reporte de Onomasticos": { w: 278, h: 186 },
    "Reporte de Onomásticos": { w: 278, h: 186 },
    "Onomásticos": { w: 278, h: 186 },
    "Asignacion Horario": { w: 510, h: 246 },
    "Reporte de Asignación de Horario": { w: 510, h: 246 },
    "Reporte de Asignacion de Horario": { w: 510, h: 246 },
    "Asignación de Horario": { w: 510, h: 246 },
    "Asignacion de Horario": { w: 510, h: 246 },
    "Horas Extra": { w: 520, h: 340 },
    "Reporte de Horas Extra": { w: 520, h: 340 },
    "Reporte de Horas Extras": { w: 520, h: 340 },
    "Horas Extra Report": { w: 520, h: 340 },
    "Nómina": { w: 900, h: 700 },
    "Reporte Cronograma Mina": { w: 470, h: 300 },
    "Reporte de Cronograma Minas": { w: 470, h: 300 },
    "Cronograma Mina Report": { w: 470, h: 300 },
    "Capacitaciones": { w: 550, h: 390 },
    "Reporte de Capacitación": { w: 550, h: 390 },
    "Reporte de Capacitaciones": { w: 550, h: 390 },
    "Reporte Capacitacion": { w: 550, h: 390 },
    "Contratos": { w: 500, h: 280 },
    "Reporte de Contratos": { w: 500, h: 280 },
    "Reporte Contratos": { w: 500, h: 280 },
    "Reporte Vacaciones": { w: 620, h: 350 },
    "Reporte de Vacaciones": { w: 620, h: 350 },
    "Vacaciones Report": { w: 620, h: 350 },
    "Personal": { w: 500, h: 300 },
    "Reporte de Personal": { w: 500, h: 300 },
    "Reporte Personal": { w: 500, h: 300 },
    "Personal Report": { w: 500, h: 300 },
    "Reporte Planilla Sueldos": { w: 330, h: 320 },
    "Planilla Oficial de Sueldos": { w: 330, h: 320 },
    "Reporte Planilla Oficial": { w: 330, h: 320 },
    "Planilla Oficial": { w: 330, h: 320 },
    "Asig H Extra": { w: 510, h: 300 },
    "Reporte de Asignación de Hora Extra": { w: 510, h: 300 },
    "Reporte de Asignacion de Hora Extra": { w: 510, h: 300 },
    "Asignación de Hora Extra": { w: 510, h: 300 },
    "Asignacion de Hora Extra": { w: 510, h: 300 },
    "Faltas": { w: 522, h: 365 },
    "Reporte de Faltas de Personal": { w: 522, h: 365 },
    "Reporte de Faltas": { w: 522, h: 365 },
    "Reporte Faltas Personal": { w: 522, h: 365 },
    "Tardanzas": { w: 700, h: 330 },
    "Reporte de Tardanzas": { w: 700, h: 330 },
    "Reporte Tardanzas": { w: 700, h: 330 },
    "Reporte Descuentos": { w: 514, h: 286 },
    "Reporte de Descuentos": { w: 514, h: 286 },
    "Descuentos Report": { w: 514, h: 286 },
    "Reporte Ingresos": { w: 514, h: 286 },
    "Reporte de Ingresos": { w: 514, h: 286 },
    "Reporte de Ingresos de Personal": { w: 514, h: 286 },
    "Ingresos Report": { w: 514, h: 286 },
    "Reporte Recursos": { w: 565, h: 330 },
    "Reporte de Recursos": { w: 565, h: 330 },
    "Reporte de Asignación de Recursos": { w: 565, h: 330 },
    "Reporte de Asignacion de Recursos": { w: 565, h: 330 },
    "Reporte Asignación de Recursos": { w: 565, h: 330 },
    "Reporte Asignacion de Recursos": { w: 565, h: 330 },

    // CRM
    "Oportunidad": { w: 920, h: 700 },
    "Oportunidad Negocio": { w: 470, h: 530 },
    "Reporte de Oportunidad de Negocio": { w: 470, h: 530 },
    "Reporte Oportunidad Negocio": { w: 470, h: 530 },
    "Visita Clientes": { w: 880, h: 680 },
    "Reporte Visita Clientes": { w: 560, h: 350 },
    "Reporte de Visita de Cliente": { w: 560, h: 350 },
    "Reporte Visita de Cliente": { w: 560, h: 350 },
  };

  // Buscar tamaño específico
  const normalizedLabel = label.replace(/\s+/g, " ").trim();
  if (windowSizes[normalizedLabel]) {
    return windowSizes[normalizedLabel];
  }

  // Búsqueda por patrón como fallback
  if (/Gu[ií]a\s+Remisi[oó]n|Nueva\s+Gu[ií]a/i.test(label)) {
    return { w: 920, h: 680 };
  }

  if (/Factura|Boleta|Cotizaci[oó]n|Venta/i.test(label)) {
    return { w: 900, h: 700 };
  }

  if (/Orden\s+de\s+Trabajo|\bOT\b|Taller|Marcaciones?/i.test(label)) {
    return { w: 920, h: 700 };
  }

  if (/Reporte|Consultas|Tablero|Kardex|Inventario|Movimientos|Resumen|Cuentas|Compras|Almac[eé]n/i.test(label)) {
    return { w: 1000, h: 750 };
  }

  // Tamaño por defecto
  return {
    w: fit(Math.round(vw * 0.70), 720, vw - 32),
    h: fit(Math.round(maxH * 0.70), 450, maxH),
  };
}


export function normalizeWindowLabel(label: string) {
  return label.replace(/\s+/g, " ").replace(/\n/g, " ").trim();
}

export function normalizeWindowLookupKey(label: string) {
  return normalizeWindowLabel(label)
    .normalize("NFD")
    .replace(/[\u0300-\u036f]/g, "");
}

const WINDOW_TITLE_OVERRIDES: Record<string, string> = {
  "Guía Remisión": "GUÍAS DE REMISIÓN",
  "Guia Remisión": "GUÍAS DE REMISIÓN",
  "Nueva Guía": "Registrar nueva GUÍA DE REMISIÓN",
  "Nueva Guia": "Registrar nueva GUÍA DE REMISIÓN",
  "Factura": "FACTURAS DE VENTA",
  "Boleta": "BOLETAS DE VENTA",
  "Cotizaciones": "COTIZACIONES",
  "Orden de Trabajo": "ORDEN DE TRABAJO",
  "OT": "REPORTE DE OT",
  "Reporte de OT": "REPORTE DE OT",
  "Reporte OT": "REPORTE DE OT",
};

const WINDOW_TITLE_OVERRIDES_NORMALIZED: Record<string, string> = Object.fromEntries(
  Object.entries(WINDOW_TITLE_OVERRIDES).map(([key, value]) => [normalizeWindowLookupKey(key), value]),
);

function getWindowDisplayTitle(label: string) {
  const normalizedLabel = normalizeWindowLookupKey(label);
  return WINDOW_TITLE_OVERRIDES_NORMALIZED[normalizedLabel] ?? normalizeWindowLabel(label);
}

export const DESKTOP_STATUS_BAR_H = 56;

function getWorkspaceBounds() {
  if (typeof window === "undefined") {
    return { left: 0, top: 0, width: 1280, height: 720 };
  }
  const workspace = document.querySelector('[data-mdi-workspace="true"]') as HTMLDivElement | null;
  const rect = workspace?.getBoundingClientRect();
  const left = rect?.left ?? 0;
  const top = rect?.top ?? 0;
  const width = rect?.width ?? workspace?.clientWidth ?? window.innerWidth;
  const height = rect?.height ?? workspace?.clientHeight ?? Math.max(320, window.innerHeight - DESKTOP_STATUS_BAR_H);
  return { left, top, width, height };
}
// ---------- Provider ----------
export function WindowsProvider({ children }: { children: ReactNode }) {
  const [windows, setWindows] = useState<OpenWindow[]>([]);
  const [active, setActive] = useState<string | null>(null);
  const zRef = useRef(10);
  const cascadeRef = useRef(0);

  const bringToFront = useCallback((id: string) => {
    zRef.current += 1;
    const z = zRef.current;
    setWindows(prev => prev.map(w => w.id === id ? { ...w, zIndex: z, isMinimized: false } : w));
    setActive(id);
  }, []);

  const open = useCallback((label: string) => {
    const normalizedLabel = normalizeWindowLabel(label);
    const winOptions = getWindowOptions(normalizedLabel);
    setWindows(prev => {
      const existing = prev.find(w => w.label === normalizedLabel);
      if (existing) {
        zRef.current += 1;
        setActive(existing.id);
        return prev.map(w => w.id === existing.id
          ? { ...w, zIndex: zRef.current, isMinimized: false }
          : w);
      }
      zRef.current += 1;
      cascadeRef.current = (cascadeRef.current + 1) % 8;
      const offset = cascadeRef.current * 24;
      const id = `${normalizedLabel}-${Date.now()}-${Math.random().toString(36).slice(2, 6)}`;
      const rawSize = getInitialSize(normalizedLabel);
      const bounds = getWorkspaceBounds();
      const size = {
        w: Math.min(rawSize.w, Math.max(220, bounds.width)),
        h: Math.min(rawSize.h, Math.max(140, bounds.height)),
      };
      const initialX = bounds.left + 40 + offset;
      const initialY = bounds.top + 20 + offset;
      const maxX = Math.max(bounds.left, bounds.left + bounds.width - size.w);
      const maxY = Math.max(bounds.top, bounds.top + bounds.height - size.h);
      const x = Math.min(Math.max(initialX, bounds.left), maxX);
      const y = Math.min(Math.max(initialY, bounds.top), maxY);
      const win: OpenWindow = {
        id, label: normalizedLabel,
        title: getWindowDisplayTitle(normalizedLabel),
        position: { x, y },
        size,
        zIndex: zRef.current,
        isMaximized: false,
        isMinimized: false,
        canMaximize: winOptions.canMaximize,
      };
      setActive(id);
      return [...prev, win];
    });
  }, []);

  const close = useCallback((id: string) => {
    setWindows(prev => {
      const next = prev.filter(w => w.id !== id);
      if (active === id) {
        const top = next.reduce<OpenWindow | null>((a, b) => (!a || b.zIndex > a.zIndex) ? b : a, null);
        setActive(top ? top.id : null);
      }
      return next;
    });
  }, [active]);

  const move = useCallback((id: string, pos: WindowPos) => {
    setWindows(prev => prev.map(w => w.id === id ? { ...w, position: pos } : w));
  }, []);

  const toggleMaximize = useCallback((id: string) => {
    setWindows(prev => {
      const current = prev.find(w => w.id === id);
      if (!current || current.canMaximize === false) return prev;
      zRef.current += 1;
      const z = zRef.current;
      const next = prev.map(w => w.id === id
        ? { ...w, isMaximized: !w.isMaximized, isMinimized: false, zIndex: z }
        : w);
      setActive(id);
      return next;
    });
  }, []);

  const toggleFromTaskbar = (id: string) => {
    setWindows(prev => {
      const w = prev.find(x => x.id === id);
      if (!w) return prev;
      if (w.isMinimized) {
        zRef.current += 1;
        setActive(id);
        return prev.map(x => x.id === id ? { ...x, isMinimized: false, zIndex: zRef.current } : x);
      }
      if (active === id) {
        // minimize
        const next = prev.map(x => x.id === id ? { ...x, isMinimized: true } : x);
        const top = next.filter(x => !x.isMinimized).sort((a, b) => b.zIndex - a.zIndex)[0];
        setActive(top?.id ?? null);
        return next;
      }
      // just focus
      zRef.current += 1;
      setActive(id);
      return prev.map(x => x.id === id ? { ...x, zIndex: zRef.current } : x);
    });
  };

  const minimize = useCallback((id: string) => {
    setWindows(prev => prev.map(w => w.id === id ? { ...w, isMinimized: true } : w));
    setActive(prev => {
      // pick next top non-minimized
      return prev;
    });
  }, []);

  const restore = useCallback((id: string) => bringToFront(id), [bringToFront]);

  return (
    <WindowsCtx.Provider value={{
      windows, active, open, close,
      focus: bringToFront, move, toggleMaximize, toggleFromTaskbar, minimize, restore,
    }}>
      {children}
    </WindowsCtx.Provider>
  );
}

// ---------- Hook ----------
export function useWindows() {
  const c = useContext(WindowsCtx);
  if (!c) {
    console.warn("useWindows outside provider; using fallback context");
    return WINDOWS_FALLBACK_CTX;
  }
  return c;
}

export function openDesktopWindow(label: string) {
  if (typeof window === "undefined") return;
  window.dispatchEvent(new CustomEvent("systeck-open-window", { detail: { label } }));
}