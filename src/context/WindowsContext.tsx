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
};

type Ctx = {
  windows: OpenWindow[];
  active: string | null;
  open: (label: string) => void;
  close: (id: string) => void;
  focus: (id: string) => void;
  move: (id: string, pos: WindowPos) => void;
  toggleMaximize: (id: string) => void;
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
  minimize: () => {},
  restore: () => {},
};


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
    "Registro": { w: 480, h: 630 },
    "Registro Auxiliar": { w: 520, h: 550 },
    "Resumen Registro": { w: 900, h: 600 },

    // Guías y Documentos
    "Guía Remisión": { w: 920, h: 680 },
    "Guías Remisión": { w: 920, h: 680 },
    "Guia Remision": { w: 920, h: 680 },
    "G/R Pendiente": { w: 920, h: 700 },
    "Nueva Guía": { w: 880, h: 680 },
    "Nueva Guia": { w: 880, h: 680 },
    "Factura": { w: 900, h: 700 },
    "Boleta": { w: 900, h: 700 },
    "Resumen de Boletas": { w: 900, h: 700 },
    "Guía Devolución": { w: 880, h: 680 },
    "Notas": { w: 880, h: 680 },
    "Nueva Nota": { w: 880, h: 680 },

    // Pre y Post Venta
    "Cotizaciones": { w: 900, h: 700 },
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
    "Precios": { w: 920, h: 700 },
    "Acumulada": { w: 820, h: 700 },

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
    "Transferencias": { w: 920, h: 700 },
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
    "OT": { w: 920, h: 700 },

    // Personal
    "Marcaciones": { w: 880, h: 650 },
    "Asistencia": { w: 900, h: 700 },
    "Nómina": { w: 900, h: 700 },

    // CRM
    "Oportunidad": { w: 920, h: 700 },
    "Oportunidad Negocio": { w: 920, h: 700 },
    "Visita Clientes": { w: 880, h: 680 },
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
  "OT": "ORDEN DE TRABAJO",
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
    return { width: 1280, height: 720 };
  }
  const workspace = document.querySelector('[data-mdi-workspace="true"]') as HTMLDivElement | null;
  const width = workspace?.clientWidth ?? window.innerWidth;
  const height = workspace?.clientHeight ?? Math.max(320, window.innerHeight - DESKTOP_STATUS_BAR_H);
  return { width, height };
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
      const initialX = 40 + offset;
      const initialY = 20 + offset;
      const x = Math.max(0, Math.min(initialX, Math.max(0, bounds.width - size.w)));
      const y = Math.max(0, Math.min(initialY, Math.max(0, bounds.height - size.h)));
      const win: OpenWindow = {
        id, label: normalizedLabel,
        title: getWindowDisplayTitle(normalizedLabel),
        position: { x, y },
        size,
        zIndex: zRef.current,
        isMaximized: false,
        isMinimized: false,
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
    zRef.current += 1;
    const z = zRef.current;
    setWindows(prev => prev.map(w => w.id === id
      ? { ...w, isMaximized: !w.isMaximized, isMinimized: false, zIndex: z }
      : w));
    setActive(id);
  }, []);

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
      focus: bringToFront, move, toggleMaximize, minimize, restore,
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