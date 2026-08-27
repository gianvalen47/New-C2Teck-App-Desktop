// Custom enterprise glyph system for Systeck ERP.
// Each glyph is its own hand-crafted SVG — physically independent — matching
// the concept of the ribbon icon (document, invoice, client, warehouse, ...).
// Unmapped labels fall back to a monogram tile so every icon still gets a
// unique, corporate-styled visual.

import type { CSSProperties } from "react";

type GlyphProps = { name: string; size?: number; className?: string };

// ---------- Palette per functional family ----------
const FAMILIES: Record<string, { from: string; to: string; ink: string; ring: string }> = {
  doc:      { from: "#3B82F6", to: "#1E3A8A", ink: "#EAF2FF", ring: "#1D4ED8" },   // documents
  money:    { from: "#F59E0B", to: "#B45309", ink: "#FFF7E6", ring: "#92400E" },   // money / credit
  ware:     { from: "#10B981", to: "#065F46", ink: "#E6FFF4", ring: "#047857" },   // warehouse
  logistic: { from: "#6366F1", to: "#312E81", ink: "#EDEBFF", ring: "#4338CA" },   // logistics / import
  cost:     { from: "#8B5CF6", to: "#4C1D95", ink: "#F1EAFF", ring: "#6D28D9" },   // costs / analytics
  people:   { from: "#EC4899", to: "#831843", ink: "#FFEBF4", ring: "#BE185D" },   // HR / personal
  security: { from: "#0EA5E9", to: "#075985", ink: "#E6F6FF", ring: "#0369A1" },   // security / admin
  route:    { from: "#22C55E", to: "#14532D", ink: "#E9FFF0", ring: "#166534" },   // rutas / rondas
  book:     { from: "#4F46E5", to: "#1E1B4B", ink: "#EAE9FF", ring: "#3730A3" },   // contabilidad
  tel:      { from: "#06B6D4", to: "#164E63", ink: "#E4FBFF", ring: "#0E7490" },   // telefonía
  crm:      { from: "#F43F5E", to: "#881337", ink: "#FFEAEF", ring: "#BE123C" },   // CRM
  asset:    { from: "#84CC16", to: "#365314", ink: "#F1FFE0", ring: "#4D7C0F" },   // activos
  table:    { from: "#475569", to: "#0F172A", ink: "#EEF2F8", ring: "#334155" },   // tablas
  help:     { from: "#0284C7", to: "#075985", ink: "#E4F4FF", ring: "#0369A1" },   // ayuda
  neutral:  { from: "#64748B", to: "#1E293B", ink: "#EEF2F8", ring: "#334155" },
};

// ---------- Concept → family mapping (used by fallback monogram) ----------
function familyFor(name: string): keyof typeof FAMILIES {
  const s = name.toLowerCase();
  if (/(factura|boleta|nota|guía|guia|documento|resumen|cotiza|reclamo|orden|comprob|remisión|remision|correo|reporte|informe)/.test(s)) return "doc";
  if (/(precio|tarifa|cobrar|pagar|dólar|dolar|sol|cambio|anticipo|letra|cta|cuenta|cheque|financ|banco|caja|reemb|gasto|deuda|crédito|credito|cobrador|reci[bp]|honorario|provi|mayor|libro)/.test(s)) return "money";
  if (/(almac[eé]n|stock|kardex|inventar|producto|mercader|repuesto|ubicaci|toma|vale|material|transferen|despacho|salida|ingreso|chequeo|categor|modelo|marca)/.test(s)) return "ware";
  if (/(import|contenedor|embarque|orden de import|pedido|tránsito|transito)/.test(s)) return "logistic";
  if (/(costo|kard|valoriz|proces|período|cierre|cuadrar|gmroi|condens|motores|sobregiro|indicador|estad[íi]stic|tablero|resumen general)/.test(s)) return "cost";
  if (/(personal|usuario|perfil|vendedor|cliente|contacto|cartera|empresa|área|area|cargo|asig|falta|tardanza|horas|marcaci[oó]n|onomás|onomas|vacacion|planilla|sueldo|jefe|cronograma|escala|capacita)/.test(s)) return "people";
  if (/(seguridad|sesi[oó]n|acceso|fido|mfa|token|contraseña|login|logueo|permiso|solicitud)/.test(s)) return "security";
  if (/(ruta|rond|control|ruteador|punto|puesto)/.test(s)) return "route";
  if (/(contab|asiento|diario|libro|arqueo|provi|reemb|cierre mes|financiero)/.test(s)) return "book";
  if (/(tele|línea|linea|plan|equipo|smart|call|llamada|operad)/.test(s)) return "tel";
  if (/(crm|oportun|tarjeta|cuota|visita|ocurrenc)/.test(s)) return "crm";
  if (/(activo|patrimoni|depreci)/.test(s)) return "asset";
  if (/(tabla|par[aá]metro|rubro|partida|serie|feriad|afp|horari|motivo)/.test(s)) return "table";
  if (/(ayuda|acerca|información|informacion|about)/.test(s)) return "help";
  return "neutral";
}

// ---------- Base tile ----------
function Tile({
  fam, children, size = 28, className = "", style,
}: { fam: keyof typeof FAMILIES; children: React.ReactNode; size?: number; className?: string; style?: CSSProperties }) {
  const f = FAMILIES[fam];
  const id = `g-${fam}`;
  return (
    <svg
      width={size}
      height={size}
      viewBox="0 0 32 32"
      className={className}
      style={style}
      aria-hidden
    >
      <defs>
        <linearGradient id={id} x1="0" y1="0" x2="0" y2="1">
          <stop offset="0%" stopColor={f.from} />
          <stop offset="100%" stopColor={f.to} />
        </linearGradient>
        <linearGradient id={`${id}-hl`} x1="0" y1="0" x2="0" y2="1">
          <stop offset="0%" stopColor="rgba(255,255,255,0.55)" />
          <stop offset="55%" stopColor="rgba(255,255,255,0)" />
        </linearGradient>
      </defs>
      {/* soft outer shadow via a duplicated darker plate */}
      <rect x="1.2" y="2.2" width="29.6" height="27.6" rx="7" fill={f.ring} opacity="0.28" />
      {/* main plate */}
      <rect x="1" y="1" width="30" height="28" rx="7" fill={`url(#${id})`} stroke={f.ring} strokeOpacity="0.85" />
      {/* glossy highlight */}
      <rect x="2.5" y="2.2" width="27" height="10" rx="5" fill={`url(#${id}-hl)`} />
      <g stroke={f.ink} strokeWidth={1.6} strokeLinecap="round" strokeLinejoin="round" fill="none">
        {children}
      </g>
    </svg>
  );
}

// ---------- Concept glyphs (drawn inside 32x32 viewbox, centered ~16,16) ----------
// Every path is inside a <g> centered around 16,16, sized ~14x14 for the glyph.

const G = {
  // documentos
  documento: (
    <>
      <path d="M10 7h9l3 3v15H10z" />
      <path d="M19 7v3h3" />
      <path d="M13 14h6M13 17h6M13 20h4" />
    </>
  ),
  factura: (
    <>
      <path d="M10 6h10l2 2v18l-2-2-2 2-2-2-2 2-2-2-2 2z" />
      <path d="M13 12h6M13 15h6M13 18h4" />
      <circle cx="20" cy="22" r="1.2" fill="currentColor" />
    </>
  ),
  boleta: (
    <>
      <path d="M11 7h9v18l-1.5-1.5L17 25l-1.5-1.5L14 25l-1.5-1.5L11 25z" />
      <path d="M13 12h5M13 15h5M13 18h3" />
    </>
  ),
  nota: (
    <>
      <path d="M9 8h11l3 3v11l-3 3H9z" />
      <path d="M20 8v3h3" />
      <path d="M13 15l2 2 4-4" />
    </>
  ),
  guia: (
    <>
      <path d="M6 20h4l2-2h6l2 2h4" />
      <rect x="9" y="9" width="14" height="8" rx="1.5" />
      <circle cx="11" cy="22" r="2" />
      <circle cx="21" cy="22" r="2" />
    </>
  ),
  cotizacion: (
    <>
      <path d="M10 7h9l3 3v15H10z" />
      <path d="M19 7v3h3" />
      <path d="M14 15l2 2 4-4" />
      <path d="M13 20h6" />
    </>
  ),
  reclamo: (
    <>
      <path d="M9 8h11l3 3v10l-3 3h-5l-4 3v-3H9z" />
      <path d="M16 12v5M16 20v.5" />
    </>
  ),
  correo: (
    <>
      <rect x="6" y="9" width="20" height="14" rx="2" />
      <path d="M6 11l10 7 10-7" />
    </>
  ),
  buscar: (
    <>
      <circle cx="14" cy="14" r="5" />
      <path d="M18 18l5 5" />
    </>
  ),
  indicador: (
    <>
      <path d="M7 22V13M13 22V9M19 22V15M25 22V6" />
      <path d="M6 24h20" />
    </>
  ),

  // ventas / precios
  precio: (
    <>
      <path d="M8 7h13l5 5v13h-18z" />
      <circle cx="12" cy="12" r="1.4" fill="currentColor" />
      <path d="M15 22l6-6" />
    </>
  ),
  oferta: (
    <>
      <path d="M17 5l2 3h4v4l3 2-3 2v4h-4l-2 3-2-3h-4v-4l-3-2 3-2V8h4z" />
      <path d="M13 15l6 6M13 19l6-6" />
    </>
  ),
  fabricante: (
    <>
      <path d="M6 25V14l5 3V14l5 3V14l5 3V10l5-3v18z" />
      <path d="M11 25v-4M16 25v-4M21 25v-4" />
    </>
  ),
  lista: (
    <>
      <rect x="6" y="7" width="20" height="18" rx="2" />
      <path d="M10 12h12M10 16h12M10 20h8" />
    </>
  ),

  // cliente / personas
  cliente: (
    <>
      <circle cx="16" cy="12" r="4" />
      <path d="M8 24c1.5-4 5-6 8-6s6.5 2 8 6" />
    </>
  ),
  clientes: (
    <>
      <circle cx="12" cy="12" r="3.5" />
      <circle cx="21" cy="14" r="2.8" />
      <path d="M6 24c1.2-3.6 4-5.4 6.5-5.4s5.3 1.8 6.5 5.4" />
      <path d="M20 24c.8-2.4 2.4-3.6 4-3.6s3.2 1.2 4 3.6" />
    </>
  ),
  cartera: (
    <>
      <rect x="5" y="10" width="22" height="14" rx="2" />
      <path d="M5 14h22" />
      <rect x="20" y="16" width="5" height="3" rx="1" fill="currentColor" opacity=".9" />
    </>
  ),
  vendedor: (
    <>
      <circle cx="16" cy="11" r="3.5" />
      <path d="M9 24c1.4-3.5 4.2-5.2 7-5.2s5.6 1.7 7 5.2" />
      <path d="M22 6l2 2-2 2M20 8h4" />
    </>
  ),

  // almacén
  almacen: (
    <>
      <path d="M5 13l11-6 11 6v12H5z" />
      <path d="M12 25v-7h8v7" />
    </>
  ),
  caja: (
    <>
      <path d="M6 11l10-4 10 4-10 4z" />
      <path d="M6 11v10l10 4 10-4V11" />
      <path d="M16 15v10" />
    </>
  ),
  cajaOpen: (
    <>
      <path d="M6 11l10-4 10 4v10l-10 4-10-4z" />
      <path d="M6 11l10 4 10-4M16 15v10" />
      <path d="M13 8l6 2" opacity=".6" />
    </>
  ),
  cajaOut: (
    <>
      <path d="M6 11l10-4 10 4v10l-10 4-10-4z" />
      <path d="M6 11l10 4 10-4" />
      <path d="M22 18l4-3-4-3" />
      <path d="M26 15h-8" />
    </>
  ),
  kardex: (
    <>
      <rect x="6" y="8" width="20" height="16" rx="1.5" />
      <path d="M6 12h20" />
      <path d="M10 16h12M10 19h8" />
      <circle cx="22" cy="19" r="1.2" fill="currentColor" />
    </>
  ),
  transferencia: (
    <>
      <path d="M7 12h14M18 9l3 3-3 3" />
      <path d="M25 20H11M14 23l-3-3 3-3" />
    </>
  ),
  chequeo: (
    <>
      <rect x="6" y="7" width="20" height="18" rx="2" />
      <path d="M10 15l4 4 8-8" />
    </>
  ),
  tablero: (
    <>
      <rect x="5" y="7" width="10" height="9" rx="1.5" />
      <rect x="17" y="7" width="10" height="6" rx="1.5" />
      <rect x="5" y="18" width="10" height="7" rx="1.5" />
      <rect x="17" y="15" width="10" height="10" rx="1.5" />
    </>
  ),

  // logística
  camion: (
    <>
      <path d="M4 20V9h13v11" />
      <path d="M17 13h5l4 4v3H17" />
      <circle cx="9" cy="22" r="2" />
      <circle cx="22" cy="22" r="2" />
    </>
  ),
  barco: (
    <>
      <path d="M4 20l3 4h18l3-4" />
      <path d="M6 20l3-6h14l3 6" />
      <path d="M16 6v8" />
      <path d="M12 10h8" />
    </>
  ),
  contenedor: (
    <>
      <rect x="5" y="10" width="22" height="14" rx="1" />
      <path d="M10 10v14M15 10v14M20 10v14M25 10v14" />
    </>
  ),
  avion: (
    <>
      <path d="M4 18l10-2 6-8 3 1-3 8 8 2-1 3-9-1-2 5-3-1 1-4z" />
    </>
  ),
  import: (
    <>
      <path d="M16 6v14M11 15l5 5 5-5" />
      <path d="M6 24h20" />
    </>
  ),

  // dinero / créditos
  dolar: (
    <>
      <circle cx="16" cy="16" r="9" />
      <path d="M19 12c-1-1.2-2-1.8-3.5-1.8-2 0-3.2 1.2-3.2 2.4 0 3.4 7 2 7 5.4 0 1.4-1.4 2.8-3.6 2.8-1.8 0-3-.8-3.8-2M16 8v16" />
    </>
  ),
  moneda: (
    <>
      <circle cx="13" cy="14" r="6" />
      <circle cx="20" cy="18" r="6" />
    </>
  ),
  cambio: (
    <>
      <path d="M6 12h16M18 9l4 3-4 3" />
      <path d="M26 20H10M14 23l-4-3 4-3" />
    </>
  ),
  cobrar: (
    <>
      <rect x="5" y="10" width="22" height="12" rx="1.5" />
      <circle cx="16" cy="16" r="3" />
      <path d="M9 13v6M23 13v6" />
    </>
  ),
  pagar: (
    <>
      <rect x="5" y="9" width="22" height="14" rx="2" />
      <path d="M5 13h22" />
      <path d="M10 19h6" />
    </>
  ),
  letra: (
    <>
      <path d="M8 6h13l3 3v17H8z" />
      <path d="M12 12h8M12 15h8M12 18h5" />
      <path d="M18 22l2 2 4-4" />
    </>
  ),
  cheque: (
    <>
      <rect x="4" y="10" width="24" height="12" rx="1.5" />
      <path d="M8 14h10M8 17h6" />
      <path d="M20 18l1.5 1.5L26 15" />
    </>
  ),
  banco: (
    <>
      <path d="M4 12l12-6 12 6" />
      <path d="M6 12v10M11 12v10M16 12v10M21 12v10M26 12v10" />
      <path d="M3 24h26" />
    </>
  ),
  anticipo: (
    <>
      <circle cx="16" cy="16" r="8" />
      <path d="M12 16h8M17 12l4 4-4 4" />
    </>
  ),

  // contabilidad
  asiento: (
    <>
      <rect x="6" y="7" width="20" height="18" rx="1.5" />
      <path d="M10 12h5M17 12h5M10 16h5M17 16h5M10 20h5M17 20h5" />
    </>
  ),
  libro: (
    <>
      <path d="M6 8c3-1.5 6-1.5 10 0v16c-4-1.5-7-1.5-10 0z" />
      <path d="M26 8c-3-1.5-6-1.5-10 0v16c4-1.5 7-1.5 10 0z" />
    </>
  ),
  diario: (
    <>
      <rect x="6" y="8" width="20" height="17" rx="1.5" />
      <path d="M6 12h20" />
      <path d="M10 6v4M22 6v4" />
      <path d="M10 17h5M17 17h5M10 21h12" />
    </>
  ),
  flujo: (
    <>
      <path d="M6 24V8M6 24h20" />
      <path d="M9 20l4-6 4 3 5-9 4 4" />
    </>
  ),

  // reportes / analytics
  reporte: (
    <>
      <path d="M8 7h11l4 4v14H8z" />
      <path d="M19 7v4h4" />
      <path d="M12 16h8M12 19h6M12 22h5" />
    </>
  ),
  grafico: (
    <>
      <path d="M6 22l6-6 4 3 8-9" />
      <circle cx="12" cy="16" r="1.4" fill="currentColor" />
      <circle cx="16" cy="19" r="1.4" fill="currentColor" />
      <circle cx="24" cy="10" r="1.4" fill="currentColor" />
    </>
  ),
  torta: (
    <>
      <path d="M16 6v10l8 5A10 10 0 1 1 16 6z" />
      <path d="M18 6a10 10 0 0 1 8 8h-8z" />
    </>
  ),
  tendencia: (
    <>
      <path d="M6 22l6-6 4 4 10-12" />
      <path d="M20 8h6v6" />
    </>
  ),

  // seguridad
  escudo: (
    <>
      <path d="M16 5l10 3v7c0 6-4 10-10 12-6-2-10-6-10-12V8z" />
      <path d="M11 16l4 4 6-8" />
    </>
  ),
  candado: (
    <>
      <rect x="8" y="14" width="16" height="12" rx="2" />
      <path d="M11 14v-3a5 5 0 0 1 10 0v3" />
      <circle cx="16" cy="20" r="1.5" fill="currentColor" />
    </>
  ),
  llave: (
    <>
      <circle cx="12" cy="16" r="5" />
      <path d="M17 16h10M22 16v4M26 16v3" />
    </>
  ),
  usuario: (
    <>
      <circle cx="16" cy="11" r="4" />
      <path d="M8 25c1.5-4.5 5-6.5 8-6.5s6.5 2 8 6.5" />
    </>
  ),

  // rondas / rutas
  ruta: (
    <>
      <path d="M8 26c0-6 6-6 8-9s-6-3-6-9c0-3 3-5 6-5" />
      <circle cx="8" cy="26" r="2" fill="currentColor" />
      <circle cx="22" cy="6" r="2" fill="currentColor" />
    </>
  ),
  mapa: (
    <>
      <path d="M6 8l6 2 8-2 6 2v16l-6-2-8 2-6-2z" />
      <path d="M12 10v14M20 8v14" />
    </>
  ),
  puntos: (
    <>
      <circle cx="10" cy="10" r="2.5" />
      <circle cx="22" cy="12" r="2.5" />
      <circle cx="14" cy="22" r="2.5" />
      <path d="M12 11l8 1M12 20l1-6M22 14l-8 6" />
    </>
  ),

  // telefonía
  telefono: (
    <>
      <path d="M8 6h10a2 2 0 0 1 2 2v18a2 2 0 0 1-2 2H8a2 2 0 0 1-2-2V8a2 2 0 0 1 2-2z" />
      <path d="M6 12h14M6 22h14" />
      <circle cx="13" cy="25" r="1" fill="currentColor" />
    </>
  ),
  senal: (
    <>
      <path d="M6 22c0-6 4-10 10-10s10 4 10 10" />
      <path d="M10 22c0-3.5 3-6 6-6s6 2.5 6 6" />
      <circle cx="16" cy="22" r="1.5" fill="currentColor" />
    </>
  ),

  // tablas / config
  tabla: (
    <>
      <rect x="5" y="7" width="22" height="18" rx="1.5" />
      <path d="M5 13h22M12 7v18M20 7v18" />
    </>
  ),
  parametros: (
    <>
      <circle cx="16" cy="16" r="4" />
      <path d="M16 5v3M16 24v3M27 16h-3M8 16H5M23.5 8.5l-2 2M10.5 21.5l-2 2M23.5 23.5l-2-2M10.5 10.5l-2-2" />
    </>
  ),
  rubro: (
    <>
      <path d="M14 6l12 6-6 12-12-6z" />
      <circle cx="14" cy="12" r="1.8" fill="currentColor" />
    </>
  ),

  // activos
  activo: (
    <>
      <path d="M6 12l10-6 10 6v11H6z" />
      <path d="M12 23v-7h8v7" />
      <path d="M14 12h4" />
    </>
  ),

  // ayuda
  ayuda: (
    <>
      <circle cx="16" cy="16" r="10" />
      <path d="M13 13c0-2 1.5-3 3-3s3 1 3 3-1.5 2.5-3 3v1.5" />
      <circle cx="16" cy="21" r="1.2" fill="currentColor" />
    </>
  ),
  info: (
    <>
      <circle cx="16" cy="16" r="10" />
      <path d="M16 13v6" />
      <circle cx="16" cy="10.5" r="1.2" fill="currentColor" />
    </>
  ),

  // procesos / batch
  proceso: (
    <>
      <path d="M6 12a10 10 0 0 1 18-4M26 8v6h-6" />
      <path d="M26 20a10 10 0 0 1-18 4M6 24v-6h6" />
    </>
  ),
  recalcular: (
    <>
      <rect x="7" y="6" width="18" height="20" rx="2" />
      <path d="M10 11h12" />
      <path d="M11 15h3M17 15h3M11 19h3M17 19h3M11 23h3M17 23h3" />
    </>
  ),
  cierre: (
    <>
      <rect x="7" y="12" width="18" height="14" rx="2" />
      <path d="M11 12v-2a5 5 0 0 1 10 0v2" />
      <path d="M12 26l8-8" />
    </>
  ),

  // extras
  favorito: (
    <>
      <path d="M16 6l3 6 7 1-5 5 1 7-6-3-6 3 1-7-5-5 7-1z" />
    </>
  ),
  sesion: (
    <>
      <circle cx="14" cy="14" r="4" />
      <path d="M6 25c1-4 4-6 8-6M20 15l6 6-3 3-6-6" />
    </>
  ),
  logout: (
    <>
      <path d="M14 6h-6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h6" />
      <path d="M22 20l4-4-4-4M12 16h14" />
    </>
  ),
  empresa: (
    <>
      <path d="M6 26V10l8-4v20" />
      <path d="M14 14h12v12H14" />
      <path d="M10 14v.5M10 18v.5M10 22v.5M18 18v.5M22 18v.5M18 22v.5M22 22v.5" />
    </>
  ),
  computador: (
    <>
      <rect x="5" y="8" width="22" height="13" rx="2" />
      <path d="M11 25h10M15 21v4M17 21v4" />
    </>
  ),
  encuesta: (
    <>
      <rect x="7" y="7" width="18" height="18" rx="2" />
      <path d="M11 12h10M11 16h10M11 20h6" />
      <path d="M22 20l1.5 1.5L26 19" />
    </>
  ),
};

// ---------- Label → concept mapping ----------
const MAP: Record<string, keyof typeof G> = {
  // ventas
  "documentos": "documento",
  "guía remisión": "guia", "guia remision": "guia",
  "factura": "factura",
  "notas": "nota",
  "guía devolución": "guia", "guia devolucion": "guia",
  "boleta": "boleta",
  "resumen de boletas": "boleta",
  "pre y post venta": "documento",
  "cotizaciones": "cotizacion",
  "reclamo garantía": "reclamo", "reclamo garantia": "reclamo",
  "separar orden": "documento",
  "ordenes compra": "documento", "órdenes compra": "documento",
  "actualizar vendedor": "vendedor",
  "enviar correos": "correo",
  "clientes": "clientes",
  "cartera": "cartera",
  "requisiciones": "documento",
  "despacho": "camion",
  "consultas": "buscar",
  "precios": "precio", "precios cliente": "cliente", "precio oferta": "oferta",
  "factores rubros": "rubro", "precio lista": "lista", "precio fabricantes": "fabricante",
  "indicadores": "indicador",
  "tablero": "tablero",
  "registro de venta": "reporte",
  "acumulada": "grafico",
  "mensuales x cliente": "grafico",
  "reclamos": "reclamo",
  "consignaciones": "camion",
  "presupuesto venta": "grafico",
  "detalle": "reporte",
  "g/r pendiente": "guia",
  "vale requisición": "documento", "vale requisicion": "documento",
  "detalle descuento": "oferta",
  "guías remisión": "guia", "guias remision": "guia",
  "comisiones": "dolar",

  // almacenes
  "doc.ingresos": "cajaOpen",
  "doc.salidas": "cajaOut",
  "chequeo f/i": "chequeo",
  "t / i": "chequeo",
  "m t i": "kardex",
  "monitor ot": "computador",
  "datos despacho clientes": "camion",
  "transferencias": "transferencia",
  "vales": "documento",
  "despachos": "camion",
  "productos": "caja",
  "act. min max": "kardex",
  "tarjetas": "kardex",
  "calendario": "diario",
  "tablero almacen": "tablero",
  "inventario": "almacen",
  "movimientos": "transferencia",
  "sin movimiento": "caja",
  "toma de inventario": "chequeo",
  "vale materiales": "documento",
  "inv. perm. valorizado": "kardex",
  "anulación en consulta": "reclamo", "anulacion en consulta": "reclamo",
  "liqul. gastos": "pagar",
  "ubicaciones": "mapa",
  "procesar cobertura": "proceso",

  // créditos
  "ctas x cobrar": "cobrar", "cuentas x cobrar": "cobrar",
  "anticipos": "anticipo",
  "créditos": "letra", "creditos": "letra",
  "permiso usuario": "usuario",
  "planilla": "diario",
  "letras": "letra",
  "cotiz. tallas": "cotizacion",
  "recepcion doc.": "documento", "recepción doc.": "documento",
  "factores y descuentos": "oferta",
  "vistas cobrador": "cobrar", "vista cobrador": "cobrar",
  "vincular g/r": "guia",
  "tipo cambio ventas": "cambio",
  "acumulado": "moneda",
  "saldo bancos": "banco",
  "procesar job": "proceso",
  "forzados": "reclamo",
  "renovar tipo cambio": "cambio",
  "mantenimiento tipo de cambio": "cambio",
  "cuentas corrientes": "banco",
  "documentos emitidos": "documento",
  "notas debito/credito": "nota", "notas débito/crédito": "nota", "notas débito / crédito": "nota",
  "diario de pagos": "pagar",
  "letras aceptadas": "letra",
  "vencimientos": "diario",

  // importaciones
  "orden de importación": "import", "orden de importacion": "import",
  "pedido interno": "documento",
  "embarques": "barco",
  "internos": "camion",
  "embarques de importación": "barco", "embarques de importacion": "barco",

  // costos
  "valorizar f/i": "kardex",
  "recalcular": "recalcular",
  "cerrar mes": "cierre",
  "trasladar costos": "transferencia",
  "inv. rotativo": "recalcular",
  "actualizar costos": "recalcular",
  "importaciones": "import",
  "stock valorizado": "kardex",
  "kardex": "kardex",
  "condensados": "libro",
  "resumen general": "reporte",
  "gmroi": "grafico",
  "ajustar costos": "recalcular",
  "consolidado": "libro",
  "generar período": "proceso", "generar periodo": "proceso",
  "diario de almacén": "diario", "diario de almacen": "diario",
  "cuadrar cierre": "cierre",
  "costo de venta": "dolar",
  "motores": "activo",
  "sobregiro": "reclamo",

  // gerencia
  "ventas": "grafico",
  "inventario y costos": "kardex",
  "créditos y cobranzas": "cobrar", "creditos y cobranzas": "cobrar",
  "tarjeta": "cartera",
  "contabilidad": "libro",
  "datos para indicadores": "grafico",
  "estados financieros": "torta",
  "contenedor reportes": "contenedor",
  "000 ventas": "grafico",
  "020 inventario y costos": "kardex",
  "040 créditos y cobranzas": "cobrar",
  "010 - importaciones": "import",
  "030 - contabilidad": "libro",

  // servicios
  "pedir repuestos": "caja",
  "cotización": "cotizacion", "cotizacion": "cotizacion",
  "orden de trabajo": "documento",
  "garantía": "escudo", "garantia": "escudo",
  "control vehiculos": "camion", "control vehículos": "camion",
  "mantenimiento": "recalcular",
  "movimiento repuestos": "transferencia",
  "horas de trabajo": "reporte",
  "gastos por rubros": "torta",
  "liquidación a garantía": "escudo", "liquidacion a garantia": "escudo",
  "solicitud garantía": "escudo", "solicitud garantia": "escudo",
  "solicitud ot": "documento",
  "horas muestra": "reporte",
  "horas escalón": "reporte", "horas escalon": "reporte",
  "gastos detallado": "torta",
  "pendiente facturación": "factura", "pendiente facturacion": "factura",
  "tiempo reparación": "recalcular", "tiempo reparacion": "recalcular",
  "ot": "documento",
  "proyección": "tendencia", "proyeccion": "tendencia",

  // compras
  "solicitud de compra": "documento",
  "solicitud gasto": "documento",
  "orden de compra": "documento",
  "planilla viático": "diario", "planilla viatico": "diario", "planilla viáticos": "diario",
  "tarifas": "lista",
  "tarifas fast destino": "camion",
  "tarifa taxis casa": "camion",
  "cuentas x pagar": "pagar",
  "compras y/o gastos": "pagar",
  "ordenes compra ": "documento",
  "pagos cuentas x pagar": "pagar",
  "cuentas x pagar por unidad": "pagar",

  // personal
  "faltas": "reclamo",
  "asigna h. extra": "diario",
  "horas extras": "diario",
  "descuentos": "oferta",
  "recursos": "usuario",
  "marcación online": "senal", "marcacion online": "senal",
  "marcaciones": "senal", "marcacion": "senal",
  "horarios": "diario",
  "jefe area": "usuario", "jefe área": "usuario",
  "cronograma mina": "diario",
  "planilla sueldos": "diario",
  "asig. h. extra": "diario",
  "tardanzas": "diario",
  "ingresos": "cajaOpen",
  "vacaciones": "diario",
  "capacitaciones": "usuario",
  "personal": "usuario",
  "contratos": "documento",
  "cronograma": "diario",
  "asistencia": "chequeo",
  "onomásticos": "usuario", "onomasticos": "usuario",
  "asignación horario": "diario", "asignacion horario": "diario",
  "informacion": "info", "información": "info",
  "planilla sueldos ": "diario",

  // rondas
  "puntos control rutas": "puntos",
  "rondas": "ruta",
  "ruteador rutas": "mapa",
  "ruteador": "mapa",
  "rutas": "ruta",
  "puntos control": "puntos",

  // contabilidad
  "asientos": "asiento",
  "registro compra": "documento",
  "diario": "diario",
  "provisional": "libro",
  "arqueo caja": "caja",
  "cuenta destino": "banco",
  "dif. tipo cambio": "cambio",
  "flujo de caja": "flujo",
  "ctas x pagar": "pagar",
  "reembolsos": "pagar",
  "ctas ctes": "banco",
  "mayor auxiliar": "libro",
  "cheques girados": "cheque",
  "movimiento bancos": "transferencia",
  "recibo honorario": "documento",
  "reembolso": "pagar",
  "cierre mes": "cierre",
  "generar txt libros": "libro",
  "libros oficiales": "libro",
  "ctas ctes pendiente": "banco",
  "estado financiero": "torta",
  "provisionales": "libro",

  // telefonía
  "modelos": "telefono",
  "planes": "senal",
  "líneas": "senal", "lineas": "senal",
  "equipos": "telefono",
  "asigna persona": "usuario",

  // crm
  "oportunidad negocio": "tendencia",
  "tarjeta cliente": "cartera",
  "cuota vendedor": "vendedor",
  "ocurrencias": "reclamo",
  "visita clientes": "ruta",

  // activos
  "activos fijos": "activo",
  "reporte activos fijos": "reporte",

  // tablas
  "condición de pago": "cambio", "condicion de pago": "cambio",
  "tipo motores": "activo",
  "categorias": "rubro", "categorías": "rubro",
  "partidas": "libro",
  "marcas": "rubro",
  "plantilla repuestos": "caja",
  "plantilla repuestos cliente": "caja",
  "ubicacion servicio": "mapa",
  "vehiculos": "camion", "vehículos": "camion",
  "proveedores": "clientes",
  "cuenta contable": "libro",
  "cuentas destino": "banco",
  "rubro planilla": "diario",
  "rubro planilla ctas": "diario",
  "horarios ": "diario",
  "feriados": "diario",
  "afp": "cartera",
  "cargos": "usuario",
  "áreas": "empresa", "areas": "empresa",
  "motivos faltas": "reclamo",
  "equipo lector": "computador",
  "tipo hora extra": "diario",

  // logueo
  "cerrar sesion": "logout", "cerrar sesión": "logout",
  "cambiar contraseña": "candado",
  "cambiar empresa": "empresa",

  // admin
  "usuarios": "usuario",
  "perfiles": "usuario",
  "sesiones": "sesion",
  "atender solicitud": "chequeo",
  "encuesta": "encuesta",
  "resultado": "grafico",
  "asignar computadora": "computador",
  "computadora": "computador",
  "llamadas": "telefono",
  "equipos marcación personal": "senal",
  "empresas": "empresa",
  "series documentos": "documento",
  "locaciones": "mapa",
  "rubros de productos": "rubro",
  "parametros locaciones": "mapa",
  "parametros planilla sueldos": "parametros",
  "rubros x empresa": "rubro",

  // ayuda
  "solicitud": "correo",
  "información cambios": "info", "informacion cambios": "info",
  "acerca": "info",
};

function keyFor(label: string): keyof typeof G | undefined {
  const k = label.replace(/\n/g, " ").trim().toLowerCase();
  if (MAP[k]) return MAP[k];
  const k2 = k.normalize("NFD").replace(/[\u0300-\u036f]/g, "");
  for (const [mk, mv] of Object.entries(MAP)) {
    const nk = mk.normalize("NFD").replace(/[\u0300-\u036f]/g, "");
    if (nk === k2) return mv as keyof typeof G;
  }
  return undefined;
}

// ---------- Monogram fallback (unique per label) ----------
function hash(str: string) {
  let h = 0;
  for (let i = 0; i < str.length; i++) h = ((h << 5) - h + str.charCodeAt(i)) | 0;
  return Math.abs(h);
}

function Monogram({ label, size = 28, className = "", style }: { label: string; size?: number; className?: string; style?: CSSProperties }) {
  const fam = familyFor(label);
  const letters = label.replace(/[^\p{L}\d]/gu, " ").trim().split(/\s+/).map(w => w[0]).slice(0, 2).join("").toUpperCase() || "•";
  // small unique glyph rotation based on hash so tiles feel individual
  const h = hash(label);
  const dots = [0, 1, 2].map(i => ({
    x: 6 + ((h >> (i * 3)) & 7) * 2.5,
    y: 22 + ((h >> (i * 4)) & 3) * 1.5,
    o: 0.35 + ((h >> (i * 5)) & 3) * 0.15,
  }));
  return (
    <Tile fam={fam} size={size} className={className} style={style}>
      <text
        x="16" y="18" textAnchor="middle"
        fontFamily="ui-sans-serif, system-ui"
        fontWeight="800"
        fontSize={letters.length > 1 ? 10.5 : 13}
        fill={FAMILIES[fam].ink}
        stroke="none"
      >{letters}</text>
      {dots.map((d, i) => (
        <circle key={i} cx={d.x} cy={d.y} r="0.9" fill={FAMILIES[fam].ink} opacity={d.o} stroke="none" />
      ))}
    </Tile>
  );
}

// ---------- Public component ----------
export function Glyph({ name, size = 28, className = "" }: GlyphProps) {
  const key = keyFor(name);
  if (!key) return <Monogram label={name} size={size} className={className} />;
  const fam = familyFor(name);
  return (
    <Tile fam={fam} size={size} className={className}>
      {G[key]}
    </Tile>
  );
}

export default Glyph;
