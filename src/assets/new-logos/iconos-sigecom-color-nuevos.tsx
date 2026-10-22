/**
 * Iconos SIGECOM a COLOR - LOTE NUEVO de 38 iconos (estilo Lucide con relleno). 24x24, trazo + relleno por icono.
 * Cada icono tiene su propia paleta tomada del icono original.
 * Aceptan las mismas props que lucide-react (size, strokeWidth, className...).
 * Nota: `color` no cambia el relleno; el relleno viene de la paleta de cada icono.
 *
 * Uso:
 *   import { PlanillasColorIcon, ICONOS_COLOR } from './iconos-sigecom-color-nuevos';
 *   <PlanillasColorIcon size={24} />
 *   const Icono = ICONOS_COLOR['ing_planillas']; <Icono />   // clave = nombre original del archivo
 *   Impresora.ico / Impresora.png comparten nombre: la clave lleva la extensión.
 */
import { createLucideIcon, type IconNode } from 'lucide-react';

type Atributos = Record<string, string | number>;
type Nodo = [tag: string, attrs: Atributos];
interface Paleta { p: string; s?: string; t?: string }

const TINTA = '#27303f';
const luz = (hex: string) => {
  const n = parseInt(hex.slice(1), 16);
  return (0.299 * ((n >> 16) & 255) + 0.587 * ((n >> 8) & 255) + 0.114 * (n & 255)) / 255;
};
const oscurecer = (hex: string, f: number) => {
  const n = parseInt(hex.slice(1), 16);
  const c = (v: number) => Math.round(v * (1 - f)).toString(16).padStart(2, '0');
  return `#${c((n >> 16) & 255)}${c((n >> 8) & 255)}${c(n & 255)}`;
};

const relleno = (tok: string, pal: Paleta): string => {
  switch (tok) {
    case 'P': return pal.p;
    case 'S': return pal.s ?? '#ffffff';
    case 'T': return pal.t ?? pal.s ?? '#ffffff';
    case 'B': return pal.s ?? pal.p;
    case 'K': return TINTA;
    default: return '#ffffff';
  }
};
const trazo = (tok: string, pal: Paleta): string => {
  if (tok === 'W') return '#ffffff';
  if (tok === 'P') return pal.p;
  if (tok === 'S') return pal.s ?? TINTA;
  if (tok === 'T') return pal.t ?? pal.s ?? TINTA;
  if (tok[0] === 'a') return luz(relleno(tok[1], pal)) < 0.7 ? '#ffffff' : TINTA; // detalle sobre relleno
  return TINTA;
};

const crearColor = (nombre: string, nodos: Nodo[], pal: Paleta) =>
  createLucideIcon(
    `${nombre}Color`,
    nodos.map(([tag, { f, k, ...resto }], i) => {
      const a: Atributos = { ...resto, key: `${nombre}-${i}` };
      if (f) {
        const c = relleno(String(f), pal);
        a.fill = c;
        a.stroke = f === 'K' ? TINTA : oscurecer(c === '#ffffff' ? '#8a93a0' : c, 0.5);
      } else {
        if (a.stroke === undefined) a.stroke = k ? trazo(String(k), pal) : TINTA;
      }
      return [tag, a];
    }) as unknown as IconNode,
  );

/* ---------- diseños (f = relleno, k = trazo; P/S/T = colores de la paleta, W = blanco, K = tinta) ---------- */
const D: Record<string, Nodo[]> = {
  IngPlanillasRico: [
    ['path', { d: 'M8.2 6.4C4.8 9.2 2.6 12.8 2.6 17.2c0 3.4 2.6 5 6 5h6.8c3.4 0 6-1.6 6-5 0-4.4-2.2-8-5.6-10.8Z', fill: '#238a25', stroke: '#145a16', strokeWidth: 0.9 }],
    ['path', { d: 'M5.4 11.6C4.4 13 3.9 14.6 3.9 16.4', fill: 'none', stroke: '#5fc062', strokeWidth: 0.8 }],
    ['path', { d: 'M8.4 6.6C7.6 4.8 7.8 3.2 8.8 2.2L10.6 3.8 12 2.4 13.4 3.8 15.2 2.2c1 1 1.2 2.6.4 4.4Z', fill: '#2b9a2d', stroke: '#145a16', strokeWidth: 0.8 }],
    ['path', { d: 'M8.1 6.6C10.6 8 13.4 8 15.9 6.6L16.2 8.8C13.6 10.2 10.4 10.2 7.8 8.8Z', fill: '#1b7a1e', stroke: '#145a16', strokeWidth: 0.8 }],
    ['path', { d: 'M8.6 7.4C10.8 8.4 13.2 8.4 15.4 7.4', fill: 'none', stroke: '#7fd283', strokeWidth: 0.5 }],
    ['path', { d: 'M14.6 12.4C14 11.4 13 10.9 11.9 10.9 10.5 10.9 9.5 11.7 9.5 12.8c0 1.2 1.1 1.7 2.5 2.1 1.5.4 2.6 1 2.6 2.2 0 1.2-1.1 2-2.6 2-1.2 0-2.3-.5-2.9-1.5', fill: 'none', stroke: '#d7dcd2', strokeWidth: 1.25 }],
    ['path', { d: 'M12 9.6V10.9M12 19.2V20.4', fill: 'none', stroke: '#d7dcd2', strokeWidth: 1.2 }],
  ],
  LibDiarioRico: [
    ['rect', { x: 2.6, y: 21.4, width: 19, height: 0.9, rx: 0.4, fill: '#c3c6cd', stroke: 'none' }],
    ['rect', { x: 1.2, y: 1.6, width: 21.6, height: 19.8, rx: 0.9, fill: '#4f7cb8', stroke: '#2c4c7e', strokeWidth: 0.8 }],
    ['rect', { x: 2.6, y: 3.4, width: 5.6, height: 15.2, rx: 0, fill: '#fdfefe', stroke: 'none' }],
    ['rect', { x: 8.2, y: 3.4, width: 13.2, height: 15.2, rx: 0, fill: '#f2f9f9', stroke: 'none' }],
    ['rect', { x: 7.2, y: 3.4, width: 1.8, height: 15.2, rx: 0, fill: '#bcd0d3', stroke: 'none' }],
    ['rect', { x: 1.2, y: 1.6, width: 21.6, height: 1.8, rx: 0.6, fill: '#a9c0c2', stroke: 'none' }],
    ['rect', { x: 1.2, y: 18.6, width: 21.6, height: 2.8, rx: 0.6, fill: '#5b83be', stroke: 'none' }],
    ['rect', { x: 12.2, y: 4.3, width: 1.6, height: 1.6, rx: 0, fill: '#2fa81f', stroke: 'none' }],
    ['rect', { x: 12.2, y: 7.4, width: 1.6, height: 1.6, rx: 0, fill: '#c06e68', stroke: 'none' }],
    ['rect', { x: 12.2, y: 10.5, width: 1.6, height: 1.6, rx: 0, fill: '#5b8dee', stroke: 'none' }],
    ['rect', { x: 12.2, y: 13.6, width: 1.6, height: 1.6, rx: 0, fill: '#7a7a7a', stroke: 'none' }],
    ['rect', { x: 14.6, y: 4.55, width: 4.6, height: 1.1, rx: 0, fill: '#bccfd1', stroke: 'none' }],
    ['rect', { x: 14.6, y: 7.65, width: 4.6, height: 1.1, rx: 0, fill: '#bccfd1', stroke: 'none' }],
    ['rect', { x: 14.6, y: 10.75, width: 4.6, height: 1.1, rx: 0, fill: '#bccfd1', stroke: 'none' }],
    ['rect', { x: 14.6, y: 13.85, width: 4.6, height: 1.1, rx: 0, fill: '#bccfd1', stroke: 'none' }],
  ],
  LibMayorRico: [
    ['rect', { x: 1, y: 2.4, width: 22, height: 16.6, rx: 0.7, fill: '#2d4d7e', stroke: '#1d3358', strokeWidth: 0.6 }],
    ['rect', { x: 2.2, y: 3.6, width: 9.4, height: 13.8, rx: 0.3, fill: '#bfe0fa', stroke: 'none' }],
    ['rect', { x: 12.4, y: 3.6, width: 9.4, height: 13.8, rx: 0.3, fill: '#f3f6f8', stroke: 'none' }],
    ['rect', { x: 11.6, y: 3.6, width: 0.8, height: 13.8, rx: 0, fill: '#2d4d7e', stroke: 'none' }],
    ['path', { d: 'M4 14.8c0-1.6.6-2.4 1.5-2.8V8.8h3.1V12c.9.4 1.5 1.2 1.5 2.8Z', fill: '#e6a60a', stroke: '#b97c00', strokeWidth: 0.7 }],
    ['rect', { x: 2.8, y: 14.8, width: 8, height: 1.4, rx: 0.3, fill: '#f4d98a', stroke: '#c79a30', strokeWidth: 0.6 }],
    ['rect', { x: 14.4, y: 5, width: 5.2, height: 1.1, rx: 0, fill: '#9aa3a8', stroke: 'none' }],
    ['rect', { x: 14.4, y: 7.8, width: 5.2, height: 1.1, rx: 0, fill: '#c3c9cd', stroke: 'none' }],
    ['rect', { x: 14.4, y: 10.4, width: 4, height: 1.1, rx: 0, fill: '#c3c9cd', stroke: 'none' }],
    ['rect', { x: 15.6, y: 11.6, width: 8.2, height: 10.2, rx: 0.6, fill: '#ffffff', stroke: 'none' }],
    ['path', { d: 'M19.7 13.6V19.8M16.6 16.7H22.8', fill: 'none', stroke: '#4aa93b', strokeWidth: 2.5 }],
  ],
  LineaTelefonicaRico: [
    ['path', { d: 'M6.4 2.4c-.6.5-1 1.1-.8 1.8.9 3.1 2.7 6.1 5 8.4s5.3 4.1 8.4 5c.7.2 1.3-.2 1.8-.8l1.2-1.4c.5-.6.4-1.3-.2-1.8l-2.6-1.9c-.6-.4-1.3-.3-1.8.2l-.8.9C14 12 12.4 10.5 11.4 8.6l.9-.8c.5-.5.6-1.2.2-1.8L10.6 3.4C10.1 2.8 9.4 2.7 8.8 3.2Z', fill: 'none', stroke: '#232323', strokeWidth: 1.6 }],
    ['path', { d: 'M4.9 13.4C2.7 13 1.5 15 2.8 16.7l3.4 4.2c.9 1.1 2.4 1.3 3.6.6', fill: 'none', stroke: '#232323', strokeWidth: 1.6 }],
  ],
  MpIconRico: [
    ['path', { d: 'M2.2 9.4C1.4 6 3.6 3.4 6.8 3.2 8 3.2 9 3.6 9.6 4.2L4 9.9Z', fill: '#262626', stroke: 'none' }],
    ['path', { d: 'M21.8 9.4C22.6 6 20.4 3.4 17.2 3.2 16 3.2 15 3.6 14.4 4.2L20 9.9Z', fill: '#262626', stroke: 'none' }],
    ['rect', { x: 10.8, y: 1.2, width: 2.4, height: 2.2, rx: 0.8, fill: '#262626', stroke: 'none' }],
    ['path', { d: 'M6.6 20.8L5.2 22.5M17.4 20.8L18.8 22.5', fill: 'none', stroke: '#262626', strokeWidth: 1.7 }],
    ['circle', { cx: 12, cy: 13.2, r: 8.1, fill: '#fbfbfb', stroke: '#262626', strokeWidth: 2.2 }],
    ['circle', { cx: 12, cy: 13.2, r: 6.6, fill: 'none', stroke: '#8c8c8c', strokeWidth: 0.4 }],
    ['path', { d: 'M12 13.8V8M12 13.8H15.6', fill: 'none', stroke: '#262626', strokeWidth: 1.7 }],
  ],
  OfficeRico: [
    ['rect', { x: 1.2, y: 9.6, width: 3.6, height: 11.6, rx: 0, fill: '#cfcfcf', stroke: '#101010', strokeWidth: 1 }],
    ['rect', { x: 19.2, y: 9.6, width: 3.6, height: 11.6, rx: 0, fill: '#cfcfcf', stroke: '#101010', strokeWidth: 1 }],
    ['rect', { x: 4.6, y: 1.6, width: 14.8, height: 19.6, rx: 0, fill: '#e0e0e0', stroke: '#101010', strokeWidth: 1.1 }],
    ['rect', { x: 6.2, y: 4, width: 3.2, height: 4, rx: 0, fill: '#2b4a7a', stroke: 'none' }],
    ['rect', { x: 10.4, y: 4, width: 3.2, height: 4, rx: 0, fill: '#2b4a7a', stroke: 'none' }],
    ['rect', { x: 14.6, y: 4, width: 3.2, height: 4, rx: 0, fill: '#2b4a7a', stroke: 'none' }],
    ['rect', { x: 7, y: 4.8, width: 1.6, height: 1.8, rx: 0, fill: '#8bbcff', stroke: 'none' }],
    ['rect', { x: 11.2, y: 4.8, width: 1.6, height: 1.8, rx: 0, fill: '#8bbcff', stroke: 'none' }],
    ['rect', { x: 15.4, y: 4.8, width: 1.6, height: 1.8, rx: 0, fill: '#8bbcff', stroke: 'none' }],
    ['rect', { x: 4.6, y: 9.6, width: 14.8, height: 1.6, rx: 0, fill: '#8d8d8d', stroke: 'none' }],
    ['rect', { x: 6.6, y: 12.6, width: 10.8, height: 8, rx: 0.3, fill: '#bdbdbd', stroke: '#555555', strokeWidth: 0.6 }],
    ['path', { d: 'M12 12.6V20.6M9.2 12.6V20.6M14.8 12.6V20.6', fill: 'none', stroke: '#6a6a6a', strokeWidth: 0.6 }],
    ['rect', { x: 4.6, y: 20.6, width: 14.8, height: 1.4, rx: 0, fill: '#9a9a9a', stroke: '#101010', strokeWidth: 0.8 }],
    ['rect', { x: 1.9, y: 13.2, width: 2.2, height: 6.4, rx: 0.9, fill: '#2c9a2c', stroke: 'none' }],
    ['rect', { x: 19.9, y: 13.2, width: 2.2, height: 6.4, rx: 0.9, fill: '#2c9a2c', stroke: 'none' }],
    ['rect', { x: 2.5, y: 19.6, width: 1, height: 1.6, rx: 0, fill: '#c0541a', stroke: 'none' }],
    ['rect', { x: 20.5, y: 19.6, width: 1, height: 1.6, rx: 0, fill: '#c0541a', stroke: 'none' }],
  ],
  AfpRico: [
    ['path', { d: 'M4.4 1.2H15.8L20.8 6.2V22.8H4.4Z', fill: '#fbfbfb', stroke: '#9a9a9a', strokeWidth: 0.9 }],
    ['path', { d: 'M15.8 1.2V6.2H20.8Z', fill: '#dcdcdc', stroke: '#9a9a9a', strokeWidth: 0.7 }],
    ['circle', { cx: 12.4, cy: 9.8, r: 5.2, fill: '#2f8be6', stroke: '#1a5fb0', strokeWidth: 0.8 }],
    ['circle', { cx: 10.6, cy: 7.8, r: 2.6, fill: '#7cc0fa', stroke: 'none', fillOpacity: 0.55 }],
    ['path', { d: 'M8.2 10.6L10.6 8.4 13 11.2 16 8.8M10.6 8.4L12.4 6.4M13 11.2L12 13.6', fill: 'none', stroke: '#cfe8ff', strokeWidth: 0.5 }],
    ['circle', { cx: 8.2, cy: 10.6, r: 0.5, fill: '#ffffff', stroke: 'none' }],
    ['circle', { cx: 10.6, cy: 8.4, r: 0.5, fill: '#ffffff', stroke: 'none' }],
    ['circle', { cx: 13, cy: 11.2, r: 0.5, fill: '#ffffff', stroke: 'none' }],
    ['circle', { cx: 16, cy: 8.8, r: 0.5, fill: '#ffffff', stroke: 'none' }],
    ['circle', { cx: 12.4, cy: 6.4, r: 0.5, fill: '#ffffff', stroke: 'none' }],
    ['circle', { cx: 12, cy: 13.6, r: 0.5, fill: '#ffffff', stroke: 'none' }],
    ['path', { d: 'M5.6 21.4L7.8 15.6 10 21.4M6.4 19.6H9.2', fill: 'none', stroke: '#111111', strokeWidth: 1.6 }],
    ['path', { d: 'M11.6 21.4V15.6H14.8M11.6 18.4H14.2', fill: 'none', stroke: '#111111', strokeWidth: 1.6 }],
    ['path', { d: 'M16.2 21.4V15.6H18.2C19.8 15.6 19.8 18.8 18.2 18.8H16.2', fill: 'none', stroke: '#111111', strokeWidth: 1.6 }],
  ],
  AreaCostoRico: [
    ['path', { d: 'M12 5.2V7.6M4.8 7.6H19.2M4.8 7.6V9.6M12 7.6V9.6M19.2 7.6V9.6', fill: 'none', stroke: '#8a8a8a', strokeWidth: 1.1 }],
    ['path', { d: 'M4.8 13.6V16.2M12 13.6V16.2M19.2 13.6V16.2', fill: 'none', stroke: '#8a8a8a', strokeWidth: 1.1 }],
    ['rect', { x: 8, y: 1, width: 8, height: 4.4, rx: 0.5, fill: '#9ad41c', stroke: '#4f8a00', strokeWidth: 0.9 }],
    ['rect', { x: 8.8, y: 1.8, width: 6.4, height: 1.6, rx: 0.2, fill: '#c4f060', stroke: 'none' }],
    ['rect', { x: 2.2, y: 9.6, width: 5.6, height: 4.2, rx: 0.5, fill: '#e9e9e9', stroke: '#8c8c8c', strokeWidth: 1 }],
    ['rect', { x: 3.1, y: 10.5, width: 3.8, height: 1.2, rx: 0, fill: '#ffffff', stroke: 'none' }],
    ['rect', { x: 9.2, y: 9.6, width: 5.6, height: 4.2, rx: 0.5, fill: '#e9e9e9', stroke: '#8c8c8c', strokeWidth: 1 }],
    ['rect', { x: 10.1, y: 10.5, width: 3.8, height: 1.2, rx: 0, fill: '#ffffff', stroke: 'none' }],
    ['rect', { x: 16.2, y: 9.6, width: 5.6, height: 4.2, rx: 0.5, fill: '#e9e9e9', stroke: '#8c8c8c', strokeWidth: 1 }],
    ['rect', { x: 17.1, y: 10.5, width: 3.8, height: 1.2, rx: 0, fill: '#ffffff', stroke: 'none' }],
    ['rect', { x: 2.2, y: 16.2, width: 5.6, height: 4.6, rx: 0.5, fill: '#2d8fd0', stroke: '#1c6a9e', strokeWidth: 0.9 }],
    ['rect', { x: 3.1, y: 17.1, width: 3.8, height: 1.4, rx: 0, fill: '#8dd0f6', stroke: 'none' }],
    ['rect', { x: 9.2, y: 16.2, width: 5.6, height: 4.6, rx: 0.5, fill: '#2d8fd0', stroke: '#1c6a9e', strokeWidth: 0.9 }],
    ['rect', { x: 10.1, y: 17.1, width: 3.8, height: 1.4, rx: 0, fill: '#8dd0f6', stroke: 'none' }],
    ['rect', { x: 16.2, y: 16.2, width: 5.6, height: 4.6, rx: 0.5, fill: '#2d8fd0', stroke: '#1c6a9e', strokeWidth: 0.9 }],
    ['rect', { x: 17.1, y: 17.1, width: 3.8, height: 1.4, rx: 0, fill: '#8dd0f6', stroke: 'none' }],
  ],
  CerrarPrRico: [
    ['path', { d: 'M7.4 10.8V7.4C7.4 3.6 9.4 1.6 12 1.6S16.6 3.6 16.6 7.4V10.8', fill: 'none', stroke: '#7d7d7d', strokeWidth: 2.4 }],
    ['path', { d: 'M7.4 10.8V7.4C7.4 3.8 9.4 1.9 12 1.9', fill: 'none', stroke: '#dcdcdc', strokeWidth: 0.9 }],
    ['rect', { x: 4.2, y: 10.2, width: 15.6, height: 12, rx: 0.6, fill: '#fbfbfb', stroke: '#a5a5a5', strokeWidth: 0.9 }],
    ['rect', { x: 4.2, y: 17.6, width: 15.6, height: 4.6, rx: 0, fill: '#f3c61a', stroke: 'none' }],
    ['path', { d: 'M4.2 21.2 L4.2 22.2 L5.4 22.2 L10 17.6 L7.8 17.6Z', fill: '#1a1a1a', stroke: 'none' }],
    ['path', { d: 'M7.6 22.2 L9.8 22.2 L14.4 17.6 L12.2 17.6Z', fill: '#1a1a1a', stroke: 'none' }],
    ['path', { d: 'M12 22.2 L14.2 22.2 L18.8 17.6 L16.6 17.6Z', fill: '#1a1a1a', stroke: 'none' }],
    ['path', { d: 'M19.8 18.8 L16.4 22.2 L18.6 22.2 L19.8 21Z', fill: '#1a1a1a', stroke: 'none' }],
    ['rect', { x: 4.2, y: 17.6, width: 15.6, height: 4.6, rx: 0.3, fill: 'none', stroke: '#8a7a10', strokeWidth: 0.6 }],
  ],
  CtasCtesRico: [
    ['rect', { x: 3, y: 3.8, width: 17.2, height: 10.6, rx: 1.2, fill: '#f4efd6', stroke: '#7a7050', strokeWidth: 0.8, transform: 'rotate(-13 12 12)' }],
    ['rect', { x: 3, y: 3.8, width: 17.2, height: 3.4, rx: 1, fill: '#2a78cf', stroke: 'none', transform: 'rotate(-13 12 12)' }],
    ['rect', { x: 3, y: 10.8, width: 17.2, height: 2.2, rx: 0, fill: '#f2b222', stroke: 'none', transform: 'rotate(-13 12 12)' }],
    ['path', { d: 'M5.4 9H12M5.4 9.0L6.6 8H7.8', fill: 'none', stroke: '#2a78cf', strokeWidth: 0.5, transform: 'rotate(-13 12 12)' }],
    ['rect', { x: 6.2, y: 7.6, width: 7.6, height: 2, rx: 0.3, fill: 'none', stroke: '#2a78cf', strokeWidth: 0.9, transform: 'rotate(-13 12 12)' }],
    ['rect', { x: 4.4, y: 11.4, width: 17.2, height: 10.6, rx: 1.2, fill: '#f9f9f9', stroke: '#555555', strokeWidth: 0.8, transform: 'rotate(-13 14 14)' }],
    ['rect', { x: 4.4, y: 13.2, width: 17.2, height: 2, rx: 0, fill: '#2a3a5a', stroke: 'none', transform: 'rotate(-13 14 14)' }],
    ['circle', { cx: 11.6, cy: 18.6, r: 2.8, fill: '#e02727', stroke: 'none', fillOpacity: 0.95, transform: 'rotate(-13 14 14)' }],
    ['circle', { cx: 14.6, cy: 18.6, r: 2.8, fill: '#f59a1a', stroke: 'none', fillOpacity: 0.9, transform: 'rotate(-13 14 14)' }],
  ],
  HeIconRico: [
    ['circle', { cx: 12, cy: 12, r: 10.6, fill: '#4a4a4a', stroke: '#1c1c1c', strokeWidth: 0.8 }],
    ['circle', { cx: 12, cy: 12, r: 9.2, fill: '#e4e4e4', stroke: '#9a9a9a', strokeWidth: 0.5 }],
    ['circle', { cx: 12, cy: 12, r: 6.2, fill: '#f6f6f6', stroke: 'none', fillOpacity: 0.5 }],
    ['path', { d: 'M12.00 5.00L12.00 3.30', fill: 'none', stroke: '#1e1e1e', strokeWidth: 1.3 }],
    ['path', { d: 'M15.80 5.42L16.25 4.64', fill: 'none', stroke: '#1e1e1e', strokeWidth: 0.7 }],
    ['path', { d: 'M18.58 8.20L19.36 7.75', fill: 'none', stroke: '#1e1e1e', strokeWidth: 0.7 }],
    ['path', { d: 'M19.00 12.00L20.70 12.00', fill: 'none', stroke: '#1e1e1e', strokeWidth: 1.3 }],
    ['path', { d: 'M18.58 15.80L19.36 16.25', fill: 'none', stroke: '#1e1e1e', strokeWidth: 0.7 }],
    ['path', { d: 'M15.80 18.58L16.25 19.36', fill: 'none', stroke: '#1e1e1e', strokeWidth: 0.7 }],
    ['path', { d: 'M12.00 19.00L12.00 20.70', fill: 'none', stroke: '#1e1e1e', strokeWidth: 1.3 }],
    ['path', { d: 'M8.20 18.58L7.75 19.36', fill: 'none', stroke: '#1e1e1e', strokeWidth: 0.7 }],
    ['path', { d: 'M5.42 15.80L4.64 16.25', fill: 'none', stroke: '#1e1e1e', strokeWidth: 0.7 }],
    ['path', { d: 'M5.00 12.00L3.30 12.00', fill: 'none', stroke: '#1e1e1e', strokeWidth: 1.3 }],
    ['path', { d: 'M5.42 8.20L4.64 7.75', fill: 'none', stroke: '#1e1e1e', strokeWidth: 0.7 }],
    ['path', { d: 'M8.20 5.42L7.75 4.64', fill: 'none', stroke: '#1e1e1e', strokeWidth: 0.7 }],
    ['path', { d: 'M6.2 15.6L18.8 11.2', fill: 'none', stroke: '#241d8f', strokeWidth: 1.5 }],
    ['path', { d: 'M12 12L12.6 12.2', fill: 'none', stroke: '#241d8f', strokeWidth: 1.9 }],
  ],
  HorsExtRico: [
    ['circle', { cx: 4.6, cy: 4.6, r: 3.1, fill: '#f7b733', stroke: '#c78310', strokeWidth: 0.8 }],
    ['circle', { cx: 18.4, cy: 4.6, r: 3.1, fill: '#f7b733', stroke: '#c78310', strokeWidth: 0.8 }],
    ['path', { d: 'M6.4 20L4.6 22.4M16.8 20L18.6 22.4', fill: 'none', stroke: '#f0a21e', strokeWidth: 1.6 }],
    ['circle', { cx: 11.6, cy: 12.6, r: 9, fill: '#cdbff6', stroke: '#6a58c8', strokeWidth: 1 }],
    ['circle', { cx: 11.6, cy: 12.6, r: 7.2, fill: '#fffbe1', stroke: '#a8a074', strokeWidth: 0.6 }],
    ['path', { d: 'M11.6 6.4V7.8M11.6 17.4V18.8M5.4 12.6H6.8M16.4 12.6H17.8M7.2 8.2L8.2 9.2M16 8.2L15 9.2M7.2 17L8.2 16', fill: 'none', stroke: '#6b6a58', strokeWidth: 0.8 }],
    ['path', { d: 'M11.6 12.6L8.4 9.8M11.6 12.6L15 14.6', fill: 'none', stroke: '#6b6a58', strokeWidth: 1.4 }],
    ['circle', { cx: 17.8, cy: 18.4, r: 5.2, fill: '#7cc02a', stroke: '#3f7d12', strokeWidth: 0.9 }],
    ['circle', { cx: 17.8, cy: 17.4, r: 4, fill: '#a3dc4c', stroke: 'none', fillOpacity: 0.55 }],
    ['path', { d: 'M17.8 15.4V21.4M14.8 18.4H20.8', fill: 'none', stroke: '#ffffff', strokeWidth: 2 }],
  ],
  HrsEquipoRico: [
    ['path', { d: 'M14.8 20C13.2 21.2 11.8 21.6 10.2 21.6A8.6 8.6 0 1 1 18.6 12.6', fill: 'none', stroke: '#1e1e1e', strokeWidth: 1.4 }],
    ['path', { d: 'M10.20 6.80L10.20 5.60', fill: 'none', stroke: '#1e1e1e', strokeWidth: 1.1 }],
    ['path', { d: 'M16.60 13.20L17.80 13.20', fill: 'none', stroke: '#1e1e1e', strokeWidth: 1.1 }],
    ['path', { d: 'M10.20 19.60L10.20 20.80', fill: 'none', stroke: '#1e1e1e', strokeWidth: 1.1 }],
    ['path', { d: 'M3.80 13.20L2.60 13.20', fill: 'none', stroke: '#1e1e1e', strokeWidth: 1.1 }],
    ['path', { d: 'M10.2 13.2L6.2 10.6', fill: 'none', stroke: '#8a8a8a', strokeWidth: 0.9 }],
    ['path', { d: 'M10.2 13.2V8.2', fill: 'none', stroke: '#bdbdbd', strokeWidth: 0.9 }],
    ['path', { d: 'M16.64 3.32L16.84 1.85L18.36 1.85L18.56 3.32A4.0 4.0 0 0 1 19.66 3.77L20.84 2.88L21.92 3.96L21.03 5.14A4.0 4.0 0 0 1 21.48 6.24L22.95 6.44L22.95 7.96L21.48 8.16A4.0 4.0 0 0 1 21.03 9.26L21.92 10.44L20.84 11.52L19.66 10.63A4.0 4.0 0 0 1 18.56 11.08L18.36 12.55L16.84 12.55L16.64 11.08A4.0 4.0 0 0 1 15.54 10.63L14.36 11.52L13.28 10.44L14.17 9.26A4.0 4.0 0 0 1 13.72 8.16L12.25 7.96L12.25 6.44L13.72 6.24A4.0 4.0 0 0 1 14.17 5.14L13.28 3.96L14.36 2.88L15.54 3.77A4.0 4.0 0 0 1 16.64 3.32Z', fill: '#fafafa', stroke: '#1e1e1e', strokeWidth: 1.2 }],
    ['circle', { cx: 17.6, cy: 7.2, r: 1.8, fill: '#ffffff', stroke: '#1e1e1e', strokeWidth: 1.1 }],
  ],
  IcoRelojRico: [
    ['circle', { cx: 12, cy: 12, r: 10.6, fill: '#ffffff', stroke: '#000000', strokeWidth: 2.4 }],
    ['path', { d: 'M12 2.8V5.6M12 18.4V21.2M2.8 12H5.6M18.4 12H21.2', fill: 'none', stroke: '#000000', strokeWidth: 1.4 }],
    ['circle', { cx: 15.9, cy: 5.245, r: 0.55, fill: '#000', stroke: 'none' }],
    ['circle', { cx: 18.755, cy: 8.1, r: 0.55, fill: '#000', stroke: 'none' }],
    ['circle', { cx: 18.755, cy: 15.9, r: 0.55, fill: '#000', stroke: 'none' }],
    ['circle', { cx: 15.9, cy: 18.755, r: 0.55, fill: '#000', stroke: 'none' }],
    ['circle', { cx: 8.1, cy: 18.755, r: 0.55, fill: '#000', stroke: 'none' }],
    ['circle', { cx: 5.245, cy: 15.9, r: 0.55, fill: '#000', stroke: 'none' }],
    ['circle', { cx: 5.245, cy: 8.1, r: 0.55, fill: '#000', stroke: 'none' }],
    ['circle', { cx: 8.1, cy: 5.245, r: 0.55, fill: '#000', stroke: 'none' }],
    ['path', { d: 'M12 12L7.4 5.4', fill: 'none', stroke: '#000000', strokeWidth: 1.5 }],
    ['path', { d: 'M12 12L13.8 19', fill: 'none', stroke: '#000000', strokeWidth: 1.5 }],
    ['path', { d: 'M12 12L18.4 6', fill: 'none', stroke: '#e0161e', strokeWidth: 1 }],
  ],
  IcoReloj2Rico: [
    ['rect', { x: 7, y: 0.8, width: 10, height: 2.6, rx: 0.3, fill: '#2a2a2a', stroke: 'none' }],
    ['rect', { x: 7, y: 20.6, width: 10, height: 2.6, rx: 0.3, fill: '#2a2a2a', stroke: 'none' }],
    ['rect', { x: 21.6, y: 10.4, width: 1.8, height: 3.2, rx: 0.3, fill: '#111111', stroke: 'none' }],
    ['circle', { cx: 12, cy: 12, r: 10, fill: '#b9b9b9', stroke: '#0f7c7c', strokeWidth: 1.5 }],
    ['circle', { cx: 12, cy: 12, r: 8.4, fill: 'none', stroke: '#7a7a7a', strokeWidth: 0.5 }],
    ['circle', { cx: 12, cy: 5, r: 0.85, fill: '#1c1c8a', stroke: 'none' }],
    ['circle', { cx: 11.65, cy: 4.65, r: 0.35, fill: '#f2e030', stroke: 'none' }],
    ['circle', { cx: 15.5, cy: 5.938, r: 0.85, fill: '#1c1c8a', stroke: 'none' }],
    ['circle', { cx: 15.15, cy: 5.588, r: 0.35, fill: '#f2e030', stroke: 'none' }],
    ['circle', { cx: 18.062, cy: 8.5, r: 0.85, fill: '#1c1c8a', stroke: 'none' }],
    ['circle', { cx: 17.712, cy: 8.15, r: 0.35, fill: '#f2e030', stroke: 'none' }],
    ['circle', { cx: 19, cy: 12, r: 0.85, fill: '#1c1c8a', stroke: 'none' }],
    ['circle', { cx: 18.65, cy: 11.65, r: 0.35, fill: '#f2e030', stroke: 'none' }],
    ['circle', { cx: 18.062, cy: 15.5, r: 0.85, fill: '#1c1c8a', stroke: 'none' }],
    ['circle', { cx: 17.712, cy: 15.15, r: 0.35, fill: '#f2e030', stroke: 'none' }],
    ['circle', { cx: 15.5, cy: 18.062, r: 0.85, fill: '#1c1c8a', stroke: 'none' }],
    ['circle', { cx: 15.15, cy: 17.712, r: 0.35, fill: '#f2e030', stroke: 'none' }],
    ['circle', { cx: 12, cy: 19, r: 0.85, fill: '#1c1c8a', stroke: 'none' }],
    ['circle', { cx: 11.65, cy: 18.65, r: 0.35, fill: '#f2e030', stroke: 'none' }],
    ['circle', { cx: 8.5, cy: 18.062, r: 0.85, fill: '#1c1c8a', stroke: 'none' }],
    ['circle', { cx: 8.15, cy: 17.712, r: 0.35, fill: '#f2e030', stroke: 'none' }],
    ['circle', { cx: 5.938, cy: 15.5, r: 0.85, fill: '#1c1c8a', stroke: 'none' }],
    ['circle', { cx: 5.588, cy: 15.15, r: 0.35, fill: '#f2e030', stroke: 'none' }],
    ['circle', { cx: 5, cy: 12.0, r: 0.85, fill: '#1c1c8a', stroke: 'none' }],
    ['circle', { cx: 4.65, cy: 11.65, r: 0.35, fill: '#f2e030', stroke: 'none' }],
    ['circle', { cx: 5.938, cy: 8.5, r: 0.85, fill: '#1c1c8a', stroke: 'none' }],
    ['circle', { cx: 5.588, cy: 8.15, r: 0.35, fill: '#f2e030', stroke: 'none' }],
    ['circle', { cx: 8.5, cy: 5.938, r: 0.85, fill: '#1c1c8a', stroke: 'none' }],
    ['circle', { cx: 8.15, cy: 5.588, r: 0.35, fill: '#f2e030', stroke: 'none' }],
    ['path', { d: 'M5 14.8 L10.6 9 L11.8 10.4 L6.2 16.2Z', fill: '#f4f4f4', stroke: 'none' }],
    ['path', { d: 'M13 10.4 L18.4 5.4 L19.6 6.8 L14.2 11.8Z', fill: '#f4f4f4', stroke: 'none' }],
    ['path', { d: 'M12 12V5.4M12 12H17.2', fill: 'none', stroke: '#111111', strokeWidth: 1.1 }],
    ['circle', { cx: 12, cy: 12, r: 1, fill: '#1c1c8a', stroke: '#111', strokeWidth: 0.4 }],
  ],
  IcoReloj3Rico: [
    ['circle', { cx: 12, cy: 12, r: 10.6, fill: '#c4c4c4', stroke: '#06067a', strokeWidth: 1.4 }],
    ['circle', { cx: 12, cy: 12, r: 9.2, fill: 'none', stroke: '#18d8f0', strokeWidth: 1 }],
    ['circle', { cx: 12, cy: 12, r: 8.1, fill: '#bdbdbd', stroke: '#1a1ad8', strokeWidth: 0.9 }],
    ['path', { d: 'M12 3.8V6M12 18V20.2M3.8 12H6M18 12H20.2', fill: 'none', stroke: '#ffffff', strokeWidth: 1.3 }],
    ['path', { d: 'M12 12V5M12 12L17.8 6.2', fill: 'none', stroke: '#ffffff', strokeWidth: 1.5 }],
    ['path', { d: 'M12 12L8.2 15.2', fill: 'none', stroke: '#1a1ad8', strokeWidth: 0.9 }],
  ],
  Indicadorico2Rico: [
    ['path', { d: 'M1.6 12.6L22.6 5.2M1.6 15.8L22.6 8.8M1.6 19L22.6 12.4', fill: 'none', stroke: '#9d9d9d', strokeWidth: 0.5 }],
    ['path', { d: 'M5.4 9.6V20M9.4 8.2V20M13.4 6.8V20M17.4 5.4V20', fill: 'none', stroke: '#9d9d9d', strokeWidth: 0.5 }],
    ['rect', { x: 1.4, y: 19.3, width: 2.5, height: 2.4, rx: 0.2, fill: '#222222', stroke: 'none', fillOpacity: 0.22 }],
    ['rect', { x: 0.8, y: 19.8, width: 2.5, height: 2.4, rx: 0.3, fill: '#a2631a', stroke: '#3a2a2a', strokeWidth: 0.4 }],
    ['rect', { x: 0.8, y: 19.8, width: 0.8, height: 2.4, rx: 0.2, fill: '#ffffff', stroke: 'none', fillOpacity: 0.28 }],
    ['rect', { x: 4.3, y: 17.35, width: 2.5, height: 4.2, rx: 0.2, fill: '#222222', stroke: 'none', fillOpacity: 0.22 }],
    ['rect', { x: 3.7, y: 17.85, width: 2.5, height: 4.2, rx: 0.3, fill: '#12677a', stroke: '#3a2a2a', strokeWidth: 0.4 }],
    ['rect', { x: 3.7, y: 17.85, width: 0.8, height: 4.2, rx: 0.2, fill: '#ffffff', stroke: 'none', fillOpacity: 0.28 }],
    ['rect', { x: 7.2, y: 15.6, width: 2.5, height: 5.8, rx: 0.2, fill: '#222222', stroke: 'none', fillOpacity: 0.22 }],
    ['rect', { x: 6.6, y: 16.1, width: 2.5, height: 5.8, rx: 0.3, fill: '#3a8a1a', stroke: '#3a2a2a', strokeWidth: 0.4 }],
    ['rect', { x: 6.6, y: 16.1, width: 0.8, height: 5.8, rx: 0.2, fill: '#ffffff', stroke: 'none', fillOpacity: 0.28 }],
    ['rect', { x: 10.1, y: 13.45, width: 2.5, height: 7.8, rx: 0.2, fill: '#222222', stroke: 'none', fillOpacity: 0.22 }],
    ['rect', { x: 9.5, y: 13.95, width: 2.5, height: 7.8, rx: 0.3, fill: '#f2ea16', stroke: '#3a2a2a', strokeWidth: 0.4 }],
    ['rect', { x: 9.5, y: 13.95, width: 0.8, height: 7.8, rx: 0.2, fill: '#ffffff', stroke: 'none', fillOpacity: 0.28 }],
    ['rect', { x: 13, y: 11.1, width: 2.5, height: 10, rx: 0.2, fill: '#222222', stroke: 'none', fillOpacity: 0.22 }],
    ['rect', { x: 12.4, y: 11.6, width: 2.5, height: 10, rx: 0.3, fill: '#f07a12', stroke: '#3a2a2a', strokeWidth: 0.4 }],
    ['rect', { x: 12.4, y: 11.6, width: 0.8, height: 10, rx: 0.2, fill: '#ffffff', stroke: 'none', fillOpacity: 0.28 }],
    ['rect', { x: 15.9, y: 8.75, width: 2.5, height: 12.2, rx: 0.2, fill: '#222222', stroke: 'none', fillOpacity: 0.22 }],
    ['rect', { x: 15.3, y: 9.25, width: 2.5, height: 12.2, rx: 0.3, fill: '#d91f26', stroke: '#3a2a2a', strokeWidth: 0.4 }],
    ['rect', { x: 15.3, y: 9.25, width: 0.8, height: 12.2, rx: 0.2, fill: '#ffffff', stroke: 'none', fillOpacity: 0.28 }],
    ['rect', { x: 18.8, y: 5.8, width: 2.5, height: 15, rx: 0.2, fill: '#222222', stroke: 'none', fillOpacity: 0.22 }],
    ['rect', { x: 18.2, y: 6.3, width: 2.5, height: 15, rx: 0.3, fill: '#7a2a5a', stroke: '#3a2a2a', strokeWidth: 0.4 }],
    ['rect', { x: 18.2, y: 6.3, width: 0.8, height: 15, rx: 0.2, fill: '#ffffff', stroke: 'none', fillOpacity: 0.28 }],
    ['rect', { x: 21.7, y: 0.05, width: 2.5, height: 20.6, rx: 0.2, fill: '#222222', stroke: 'none', fillOpacity: 0.22 }],
    ['rect', { x: 21.1, y: 0.55, width: 2.5, height: 20.6, rx: 0.3, fill: '#14a0ff', stroke: '#3a2a2a', strokeWidth: 0.4 }],
    ['rect', { x: 21.1, y: 0.55, width: 0.8, height: 20.6, rx: 0.2, fill: '#ffffff', stroke: 'none', fillOpacity: 0.28 }],
  ],
  Indicadorico3Rico: [
    ['rect', { x: 2.2, y: 1.8, width: 19.6, height: 19.6, rx: 2.4, fill: '#f6a01c', stroke: '#d27004', strokeWidth: 0.9 }],
    ['rect', { x: 4, y: 3.6, width: 16, height: 16, rx: 0.8, fill: '#ffe58c', stroke: 'none' }],
    ['path', { d: 'M7.4 11.8 L10.6 9.6 L13.8 11.8 L13.8 17 L10.6 19 L7.4 17Z', fill: '#4ec94b', stroke: '#2a8a28', strokeWidth: 0.7 }],
    ['path', { d: 'M11.4 5.2 L14.2 1.8 L17.2 3.4 L17.2 14 L14.2 17 L11.4 15Z', fill: '#4a96f2', stroke: '#1b52b8', strokeWidth: 0.8 }],
    ['path', { d: 'M11.4 5.2 L14.2 2.6 L17.2 4.2 L14.2 6.6Z', fill: '#a8d0fc', stroke: 'none' }],
    ['path', { d: 'M15.4 10 L18.2 8.2 L21 9.6 L21 17 L18.2 20 L15.4 18Z', fill: '#e63a3a', stroke: '#9a1212', strokeWidth: 0.8 }],
    ['path', { d: 'M15.4 10 L18.2 8.6 L21 10 L18.2 12.2Z', fill: '#ff8e8e', stroke: 'none' }],
    ['ellipse', { cx: 9.4, cy: 17.2, rx: 7.6, ry: 3.4, fill: '#4b8ff0', stroke: '#1b4aa8', strokeWidth: 0.9 }],
    ['path', { d: 'M2.2 16.4C3.4 13.8 7.4 13.2 9.4 13.8L9.4 17.2Z', fill: '#f0583a', stroke: '#a8281a', strokeWidth: 0.6 }],
    ['path', { d: 'M9.4 13.8C12 13.6 15 14.6 16.4 16.8L9.4 17.2Z', fill: '#f5c63a', stroke: '#a8801a', strokeWidth: 0.6 }],
  ],
  ImpresoraIcoRico: [
    ['rect', { x: 8.2, y: 1.2, width: 7.6, height: 7.6, rx: 0.3, fill: '#f7f7ff', stroke: '#7a8aa0', strokeWidth: 0.9 }],
    ['rect', { x: 1.4, y: 8.2, width: 21.2, height: 8.8, rx: 1, fill: '#a8a8b4', stroke: '#4e4e5a', strokeWidth: 0.9 }],
    ['rect', { x: 3, y: 9.4, width: 18, height: 4.4, rx: 0.5, fill: '#d9d9e2', stroke: 'none' }],
    ['rect', { x: 1.4, y: 9.4, width: 2.6, height: 5.8, rx: 0.3, fill: '#ececf2', stroke: 'none' }],
    ['rect', { x: 20, y: 9.4, width: 2.6, height: 5.8, rx: 0.3, fill: '#ececf2', stroke: 'none' }],
    ['rect', { x: 10.6, y: 11.6, width: 5.2, height: 1.3, rx: 0, fill: '#5fa8ff', stroke: 'none' }],
    ['rect', { x: 8.2, y: 16.4, width: 7.6, height: 6.4, rx: 0.3, fill: '#bfdcf8', stroke: '#7aa0d0', strokeWidth: 0.8 }],
    ['rect', { x: 10.8, y: 19.6, width: 1.6, height: 1.6, rx: 0, fill: '#3a6fe0', stroke: 'none' }],
  ],
  ImpresoraPngRico: [
    ['rect', { x: 6.6, y: 1.2, width: 10.8, height: 7, rx: 0.5, fill: '#acc9f2', stroke: '#7a9cc8', strokeWidth: 0.8 }],
    ['rect', { x: 1.6, y: 7, width: 20.8, height: 10.6, rx: 2.8, fill: '#f4f4f1', stroke: '#b3b4ae', strokeWidth: 0.9 }],
    ['rect', { x: 3, y: 8.4, width: 18, height: 4.6, rx: 1.2, fill: '#8cc63e', stroke: '#5a8a1e', strokeWidth: 0.8 }],
    ['rect', { x: 3.8, y: 9, width: 16.4, height: 1.4, rx: 0.6, fill: '#b6e06a', stroke: 'none' }],
    ['rect', { x: 3, y: 13, width: 18, height: 1.2, rx: 0.4, fill: '#6aa028', stroke: 'none' }],
    ['circle', { cx: 19.6, cy: 15.4, r: 0.6, fill: '#6aa028', stroke: 'none' }],
    ['rect', { x: 6.6, y: 15.8, width: 10.8, height: 6.2, rx: 0.5, fill: '#acc9f2', stroke: '#7a9cc8', strokeWidth: 0.8 }],
    ['path', { d: 'M8.2 18.2H15.8M8.2 20H13.4', fill: 'none', stroke: '#d0e2fa', strokeWidth: 0.7 }],
  ],
  CamaraRico: [
    ['rect', { x: 1.6, y: 6.4, width: 21, height: 13.2, rx: 2.4, fill: '#3d3d3d', stroke: '#111111', strokeWidth: 0.9 }],
    ['rect', { x: 12.6, y: 4.2, width: 6.2, height: 3, rx: 0.6, fill: '#666666', stroke: '#222', strokeWidth: 0.6 }],
    ['rect', { x: 2.4, y: 8.4, width: 4.2, height: 9.2, rx: 0.8, fill: '#c9c9c9', stroke: '#555555', strokeWidth: 0.7 }],
    ['rect', { x: 2.8, y: 9.2, width: 1.4, height: 1.4, rx: 0, fill: '#8a8a8a', stroke: 'none' }],
    ['rect', { x: 2.8, y: 12, width: 1.4, height: 1.4, rx: 0, fill: '#8a8a8a', stroke: 'none' }],
    ['rect', { x: 2.8, y: 14.8, width: 1.4, height: 1.4, rx: 0, fill: '#8a8a8a', stroke: 'none' }],
    ['rect', { x: 4.8, y: 9.2, width: 1.4, height: 1.4, rx: 0, fill: '#8a8a8a', stroke: 'none' }],
    ['rect', { x: 4.8, y: 12, width: 1.4, height: 1.4, rx: 0, fill: '#8a8a8a', stroke: 'none' }],
    ['rect', { x: 4.8, y: 14.8, width: 1.4, height: 1.4, rx: 0, fill: '#8a8a8a', stroke: 'none' }],
    ['rect', { x: 7.6, y: 8.6, width: 1.5, height: 1.5, rx: 0.2, fill: '#6ab0ff', stroke: 'none' }],
    ['circle', { cx: 14.8, cy: 13.2, r: 6.4, fill: '#e6dcae', stroke: '#9a8b4a', strokeWidth: 0.9 }],
    ['circle', { cx: 14.8, cy: 13.2, r: 5, fill: '#2c2c2c', stroke: '#111111', strokeWidth: 0.6 }],
    ['circle', { cx: 14.8, cy: 13.2, r: 3.4, fill: '#0e0e0e', stroke: 'none' }],
    ['circle', { cx: 13.4, cy: 11.8, r: 1.1, fill: '#9a9a9a', stroke: 'none', fillOpacity: 0.8 }],
    ['circle', { cx: 16.2, cy: 14.8, r: 0.6, fill: '#555555', stroke: 'none' }],
  ],
  OcurrenciasRico: [
    ['path', { d: 'M1.8 2.4H22.2V20.2C22.2 20.9 21.8 21.4 21.1 21.5L5 21.5C2.8 21.5 1.8 21.2 1.8 20.4Z', fill: '#f8e682', stroke: '#c9a82e', strokeWidth: 0.7 }],
    ['rect', { x: 1.8, y: 2.4, width: 20.4, height: 2.4, rx: 0.2, fill: '#f2c94a', stroke: 'none' }],
    ['path', { d: 'M22.2 13.4C18.6 14.4 16 17.6 15 21.5H21.1C21.8 21.4 22.2 20.9 22.2 20.2Z', fill: '#f4d24e', stroke: '#c9a82e', strokeWidth: 0.5 }],
    ['path', { d: 'M22.2 13.4C20 15.6 17.6 17.4 15 21.5C17.6 20 20.4 17.4 22.2 13.4Z', fill: '#fff3b0', stroke: 'none' }],
    ['path', { d: 'M3.6 12L4.4 7.4 7 11.4 7.8 6.8', fill: 'none', stroke: '#c24a45', strokeWidth: 1.1 }],
    ['ellipse', { cx: 10.4, cy: 9.4, rx: 1.5, ry: 2.3, fill: 'none', stroke: '#c24a45', strokeWidth: 1.1 }],
    ['path', { d: 'M12.6 7.4L15.8 6.9M14.4 7.2L13.9 12', fill: 'none', stroke: '#c24a45', strokeWidth: 1.1 }],
    ['path', { d: 'M19.6 7.2L16.8 7.5 16.4 9.5 18.8 9.2M16.4 9.5L16.2 11.8 19.2 11.4', fill: 'none', stroke: '#c24a45', strokeWidth: 1.1 }],
    ['path', { d: 'M3.4 15.2L16.8 12.8', fill: 'none', stroke: '#c24a45', strokeWidth: 1.3 }],
  ],
  PedidoImportacionRico: [
    ['path', { d: 'M10.6 1.4H19.2A2.8 2.8 0 0 1 22 4.2V19.8A2.8 2.8 0 0 1 19.2 22.6H10.6V16', fill: '#1d1d1d', stroke: '#000', strokeWidth: 0.5 }],
    ['path', { d: 'M10.6 1.4L9 3V9', fill: '#1d1d1d', stroke: '#000', strokeWidth: 0.5 }],
    ['path', { d: 'M0.8 9.4 L9.6 9.4 L9.6 14.6 L0.8 14.6Z', fill: '#1d1d1d', stroke: 'none' }],
    ['path', { d: 'M8.4 5.2L15.6 12 8.4 18.8', fill: 'none', stroke: '#f3f3f3', strokeWidth: 1.7 }],
    ['path', { d: 'M9.6 8.2L12.6 12 9.6 15.8', fill: 'none', stroke: '#1d1d1d', strokeWidth: 1.6 }],
  ],
  PlanillaOficialRico: [
    ['path', { d: 'M-7.2 16.4C-7.2 10.8 -3.8 9 0 9s7.2 1.8 7.2 7.4Z', fill: '#92c93d', stroke: '#171717', strokeWidth: 1, transform: 'translate(6.6 1.8) scale(0.88)' }],
    ['path', { d: 'M-1.9 9.1L0 12.2 1.9 9.1Z', fill: '#ffffff', stroke: '#171717', strokeWidth: 0.5, transform: 'translate(6.6 1.8) scale(0.88)' }],
    ['circle', { cx: 0, cy: 4, r: 4.1, fill: '#fbd2a8', stroke: '#171717', strokeWidth: 1, transform: 'translate(6.6 1.8) scale(0.88)' }],
    ['path', { d: 'M-4.3 3.6C-4.8 -.8 -1.8 -1.8 .8 -1.5 3.4 -1.2 5 .6 4.3 3.8 3.2 1.4 -1.2 .8 -4.3 3.6Z', fill: '#7a4a22', stroke: '#171717', strokeWidth: 0.6, transform: 'translate(6.6 1.8) scale(0.88)' }],
    ['path', { d: 'M-7.2 16.4C-7.2 10.8 -3.8 9 0 9s7.2 1.8 7.2 7.4Z', fill: '#92c93d', stroke: '#171717', strokeWidth: 1, transform: 'translate(17.4 1.8) scale(0.88)' }],
    ['path', { d: 'M-1.9 9.1L0 12.2 1.9 9.1Z', fill: '#ffffff', stroke: '#171717', strokeWidth: 0.5, transform: 'translate(17.4 1.8) scale(0.88)' }],
    ['circle', { cx: 0, cy: 4, r: 4.1, fill: '#fbd2a8', stroke: '#171717', strokeWidth: 1, transform: 'translate(17.4 1.8) scale(0.88)' }],
    ['path', { d: 'M-4.3 3.6C-4.8 -.8 -1.8 -1.8 .8 -1.5 3.4 -1.2 5 .6 4.3 3.8 3.2 1.4 -1.2 .8 -4.3 3.6Z', fill: '#7a4a22', stroke: '#171717', strokeWidth: 0.6, transform: 'translate(17.4 1.8) scale(0.88)' }],
    ['path', { d: 'M-7.2 16.4C-7.2 10.8 -3.8 9 0 9s7.2 1.8 7.2 7.4Z', fill: '#92c93d', stroke: '#171717', strokeWidth: 1, transform: 'translate(12 6)' }],
    ['path', { d: 'M-1.9 9.1L0 12.2 1.9 9.1Z', fill: '#ffffff', stroke: '#171717', strokeWidth: 0.5, transform: 'translate(12 6)' }],
    ['circle', { cx: 0, cy: 4, r: 4.1, fill: '#fbd8b2', stroke: '#171717', strokeWidth: 1, transform: 'translate(12 6)' }],
    ['path', { d: 'M-4.3 3.6C-4.8 -.8 -1.8 -1.8 .8 -1.5 3.4 -1.2 5 .6 4.3 3.8 3.2 1.4 -1.2 .8 -4.3 3.6Z', fill: '#7a4a22', stroke: '#171717', strokeWidth: 0.6, transform: 'translate(12 6)' }],
  ],
  PlanillasRico: [
    ['path', { d: 'M-6 15.6C-6 11 -3.4 9.2 0 9.2S6 11 6 15.6Z', fill: '#37a238', stroke: '#1b6a1d', strokeWidth: 0.8, transform: 'translate(16.8 1.6) scale(1.1)' }],
    ['path', { d: 'M-1.7 9.3L0 11.9 1.7 9.3Z', fill: '#fff', stroke: '#1b6a1d', strokeWidth: 0.5, transform: 'translate(16.8 1.6) scale(1.1)' }],
    ['circle', { cx: 0, cy: 4.2, r: 3.8, fill: '#f2a64c', stroke: '#a8631a', strokeWidth: 0.8, transform: 'translate(16.8 1.6) scale(1.1)' }],
    ['path', { d: 'M-4 3.8C-4.6 .0 -1.6 -1.1 .6 -.8 3 -.5 4.4 1 3.9 4 3 2 1 1.6 -1.4 2.2Z', fill: '#e2a33a', stroke: '#a8731a', strokeWidth: 0.6, transform: 'translate(16.8 1.6) scale(1.1)' }],
    ['path', { d: 'M-6.4 16.6C-6.4 11.4 -3.6 9.4 0 9.4S6.4 11.4 6.4 16.6Z', fill: '#2c6cc6', stroke: '#173f86', strokeWidth: 0.8, transform: 'translate(7.6 3) scale(1.1)' }],
    ['path', { d: 'M-2 9.6L0 12.6 2 9.6Z', fill: '#e6f0ff', stroke: '#173f86', strokeWidth: 0.5, transform: 'translate(7.6 3) scale(1.1)' }],
    ['circle', { cx: 0, cy: 4.4, r: 4.1, fill: '#e8791f', stroke: '#8a3d0a', strokeWidth: 0.8, transform: 'translate(7.6 3) scale(1.1)' }],
    ['path', { d: 'M-4.8 5C-5.8 -.8 -1.6 -2 1 -1.4 3.8 -.8 5.8 1.6 4.8 5.6 4.8 2.6 2.8 1.6 .2 1.8 -2 1.8 -3.6 2.8 -4.8 5Z', fill: '#4b4b4b', stroke: '#222', strokeWidth: 0.6, transform: 'translate(7.6 3) scale(1.1)' }],
  ],
  PlanillasSueldosRico: [
    ['rect', { x: 3.4, y: 2.2, width: 17.2, height: 16.4, rx: 1.3, fill: '#eaeef3', stroke: '#222222', strokeWidth: 1.3, transform: 'rotate(-5 12 12)' }],
    ['rect', { x: 4.6, y: 3.4, width: 14.8, height: 2.2, rx: 0.3, fill: '#bcd3ee', stroke: 'none', transform: 'rotate(-5 12 12)' }],
    ['rect', { x: 5.4, y: 7, width: 7.8, height: 6, rx: 0.5, fill: '#8a4f9a', stroke: '#5a2d68', strokeWidth: 0.5, transform: 'rotate(-5 12 12)' }],
    ['ellipse', { cx: 8.4, cy: 9.8, rx: 2.4, ry: 1.8, fill: '#b27cc2', stroke: 'none', fillOpacity: 0.7, transform: 'rotate(-5 12 12)' }],
    ['rect', { x: 5.4, y: 14, width: 7.8, height: 0.9, rx: 0, fill: '#8c96a3', stroke: 'none', transform: 'rotate(-5 12 12)' }],
    ['rect', { x: 5.4, y: 15.8, width: 7.8, height: 0.9, rx: 0, fill: '#b4bcc6', stroke: 'none', transform: 'rotate(-5 12 12)' }],
    ['rect', { x: 14.2, y: 7.2, width: 5.2, height: 0.9, rx: 0, fill: '#9aa4b0', stroke: 'none', transform: 'rotate(-5 12 12)' }],
    ['rect', { x: 14.2, y: 9.2, width: 5.2, height: 0.9, rx: 0, fill: '#9aa4b0', stroke: 'none', transform: 'rotate(-5 12 12)' }],
    ['rect', { x: 14.2, y: 11.2, width: 5.2, height: 0.9, rx: 0, fill: '#9aa4b0', stroke: 'none', transform: 'rotate(-5 12 12)' }],
    ['rect', { x: 14.2, y: 13.2, width: 5.2, height: 0.9, rx: 0, fill: '#9aa4b0', stroke: 'none', transform: 'rotate(-5 12 12)' }],
    ['rect', { x: 14.2, y: 15.2, width: 5.2, height: 0.9, rx: 0, fill: '#9aa4b0', stroke: 'none', transform: 'rotate(-5 12 12)' }],
    ['path', { d: 'M3.8 18.2C3.8 20.2 5.2 21.2 7 21.2H17.6C19.2 21.2 20.2 20.2 20.2 18.6', fill: '#f1f4f8', stroke: '#222', strokeWidth: 1.2, transform: 'rotate(-5 12 12)' }],
  ],
  PlantillasRico: [
    ['path', { d: 'M8.8 2.6H20.6V21.4H3.6V7.8Z', fill: '#ffffff', stroke: '#151515', strokeWidth: 2 }],
    ['path', { d: 'M3.6 7.8 L8.8 2.6 L8.8 7.8Z', fill: '#151515', stroke: 'none' }],
  ],
  TransferenciaInternaRico: [
    ['path', { d: 'M4.2 8.8H19.8L21.2 11.2H2.8Z', fill: '#6e4118', stroke: '#4a2a0c', strokeWidth: 0.6 }],
    ['path', { d: 'M8.4 0.8 L15.4 0.8 L15.4 7.2 L19.6 7.2 L11.9 14 L4.2 7.2 L8.4 7.2Z', fill: '#4fbe2a', stroke: '#1f6b10', strokeWidth: 0.9 }],
    ['path', { d: 'M9.6 2.2V7.8M6.4 8L11 11.6', fill: 'none', stroke: '#a9f27f', strokeWidth: 0.8 }],
    ['rect', { x: 2.4, y: 10.4, width: 19.2, height: 11.4, rx: 0.9, fill: '#d9a661', stroke: '#8a5a20', strokeWidth: 0.9 }],
    ['rect', { x: 2.4, y: 10.4, width: 19.2, height: 1.8, rx: 0.5, fill: '#ebc888', stroke: '#8a5a20', strokeWidth: 0.7 }],
    ['path', { d: 'M2.8 14.6H21.2M2.8 18H21.2', fill: 'none', stroke: '#a8722e', strokeWidth: 0.8 }],
    ['circle', { cx: 3.8, cy: 12, r: 0.45, fill: '#7a4d1a', stroke: 'none' }],
    ['circle', { cx: 3.8, cy: 14, r: 0.45, fill: '#7a4d1a', stroke: 'none' }],
    ['circle', { cx: 3.8, cy: 16.6, r: 0.45, fill: '#7a4d1a', stroke: 'none' }],
    ['circle', { cx: 3.8, cy: 19.6, r: 0.45, fill: '#7a4d1a', stroke: 'none' }],
    ['circle', { cx: 20.2, cy: 12, r: 0.45, fill: '#7a4d1a', stroke: 'none' }],
    ['circle', { cx: 20.2, cy: 14, r: 0.45, fill: '#7a4d1a', stroke: 'none' }],
    ['circle', { cx: 20.2, cy: 16.6, r: 0.45, fill: '#7a4d1a', stroke: 'none' }],
    ['circle', { cx: 20.2, cy: 19.6, r: 0.45, fill: '#7a4d1a', stroke: 'none' }],
  ],
  UbicacionRico: [
    ['ellipse', { cx: 14.6, cy: 22.4, rx: 8.6, ry: 1, fill: '#cbd0d6', stroke: 'none', fillOpacity: 0.8 }],
    ['path', { d: 'M6.6 9.2C6.6 10.8 9 11.8 12 11.8S17.4 10.8 17.4 9.2Z', fill: '#245bb8', stroke: '#173f86', strokeWidth: 0.7, transform: 'rotate(40 12 12) translate(-3 -3) scale(1.25)' }],
    ['ellipse', { cx: 12, cy: 9, rx: 5.4, ry: 1.6, fill: '#2f6fd6', stroke: '#173f86', strokeWidth: 0.7, transform: 'rotate(40 12 12) translate(-3 -3) scale(1.25)' }],
    ['path', { d: 'M8.2 3.6C8.2 6 9.8 7 10 8.8H14C14.2 7 15.8 6 15.8 3.6Z', fill: '#2f6fd6', stroke: '#173f86', strokeWidth: 0.7, transform: 'rotate(40 12 12) translate(-3 -3) scale(1.25)' }],
    ['ellipse', { cx: 12, cy: 3.6, rx: 3.7, ry: 1.4, fill: '#7fb2f6', stroke: '#173f86', strokeWidth: 0.7, transform: 'rotate(40 12 12) translate(-3 -3) scale(1.25)' }],
    ['path', { d: 'M9.2 4.8C9.4 6 10 6.8 10.6 7.8', fill: 'none', stroke: '#9cc4fa', strokeWidth: 0.8, transform: 'rotate(40 12 12) translate(-3 -3) scale(1.25)' }],
    ['rect', { x: 10.5, y: 11, width: 3, height: 2.8, rx: 0.4, fill: '#a9afb8', stroke: '#5d646e', strokeWidth: 0.6, transform: 'rotate(40 12 12) translate(-3 -3) scale(1.25)' }],
    ['path', { d: 'M11 13.6 L13 13.6 L12 21.8Z', fill: '#cfd3da', stroke: '#6b727c', strokeWidth: 0.6, transform: 'rotate(40 12 12) translate(-3 -3) scale(1.25)' }],
  ],
  UserRico: [
    ['path', { d: 'M4.4 22V17.6C4.4 15 6.4 13.2 9 12.8L12 14.6 15 12.8C17.6 13.2 19.6 15 19.6 17.6V22Z', fill: '#2f55d3', stroke: '#1b3799', strokeWidth: 0.8 }],
    ['path', { d: 'M10.2 13.2L12 16.6 13.8 13.2Z', fill: '#e8efff', stroke: 'none' }],
    ['rect', { x: 10.2, y: 10.6, width: 3.6, height: 2.8, rx: 0.5, fill: '#d0821f', stroke: 'none' }],
    ['ellipse', { cx: 12, cy: 7.2, rx: 4.4, ry: 5, fill: '#f5a23c', stroke: '#b36b12', strokeWidth: 0.8 }],
    ['path', { d: 'M7.6 7C7.2 3.4 10 1.4 12.8 1.8 15.4 2.2 16.8 4 16.6 6.8 15.2 5 12.8 4.8 10.6 5.6 9.2 6.2 8.4 6.6 7.6 7Z', fill: '#9a6a14', stroke: 'none' }],
  ],
  UsersRico: [
    ['path', { d: 'M-6 15.6C-6 11 -3.4 9.2 0 9.2S6 11 6 15.6Z', fill: '#2f6fd6', stroke: '#17408f', strokeWidth: 0.8, transform: 'translate(15.8 1.4) scale(1.05)' }],
    ['path', { d: 'M-2 9.3L0 12.4 2 9.3Z', fill: '#ffffff', stroke: '#17408f', strokeWidth: 0.5, transform: 'translate(15.8 1.4) scale(1.05)' }],
    ['path', { d: 'M-.7 11.2H.7L1.1 15 0 15.8 -1.1 15Z', fill: '#d62020', stroke: 'none', transform: 'translate(15.8 1.4) scale(1.05)' }],
    ['circle', { cx: 0, cy: 4.2, r: 3.7, fill: '#f5d9a8', stroke: '#a8771e', strokeWidth: 0.8, transform: 'translate(15.8 1.4) scale(1.05)' }],
    ['path', { d: 'M-3.9 3.4C-4.4 -.4 -1.8 -1.3 .6 -1 3 -.7 4.4 .8 3.9 3.6 2.6 1.4 -1.4 1 -3.9 3.4Z', fill: '#1e2a66', stroke: 'none', transform: 'translate(15.8 1.4) scale(1.05)' }],
    ['path', { d: 'M-6.4 17.2C-6.4 11.6 -3.6 9.6 0 9.6S6.4 11.6 6.4 17.2Z', fill: '#e01e1e', stroke: '#7a1010', strokeWidth: 0.8, transform: 'translate(8.2 5.4) scale(0.97)' }],
    ['path', { d: 'M-3.2 9.7L0 13.4 3.2 9.7Z', fill: '#ffffff', stroke: '#7a1010', strokeWidth: 0.5, transform: 'translate(8.2 5.4) scale(0.97)' }],
    ['path', { d: 'M-4.8 5C-5.8 -1 -1.6 -2.2 1 -1.6 4 -.9 5.8 1.6 4.8 5.2 6 8.4 5.6 11 3.6 11.4L3.8 6.6C2.4 3.6 -1.2 3.4 -3.8 5.8L-3.6 11.4C-5.8 10.8 -6 8 -4.8 5Z', fill: '#a8452a', stroke: '#7a1010', strokeWidth: 0.7, transform: 'translate(8.2 5.4) scale(0.97)' }],
    ['circle', { cx: 0, cy: 4.6, r: 3.9, fill: '#f8dcb4', stroke: '#7a1010', strokeWidth: 0.8, transform: 'translate(8.2 5.4) scale(0.97)' }],
    ['path', { d: 'M-3.6 3.6C-1.6 4 1.6 3 3.8 2.6 3.2 0 .2 -.8 -1.8 0 -3.2 .8 -3.8 2 -3.6 3.6Z', fill: '#a8452a', stroke: 'none', transform: 'translate(8.2 5.4) scale(0.97)' }],
  ],
  ValesMaterialRico: [
    ['path', { d: 'M18.6 4.8L4.8 19.2', fill: 'none', stroke: '#111111', strokeWidth: 3.8 }],
    ['path', { d: 'M18.6 4.8L4.8 19.2', fill: 'none', stroke: '#3a3a3a', strokeWidth: 2.8 }],
    ['path', { d: 'M17.6 5.8L5.6 18.4', fill: 'none', stroke: '#7c7c7c', strokeWidth: 0.5 }],
    ['path', { d: 'M12.4 2.4 L19.8 1 L22.8 4.6 L20.4 9 L13.4 7.8Z', fill: '#2a2a2a', stroke: '#000000', strokeWidth: 0.8 }],
    ['path', { d: 'M14.2 3.4L19.8 2.4', fill: 'none', stroke: '#8a8a8a', strokeWidth: 0.6 }],
    ['path', { d: 'M8 7.2L19.6 19.2', fill: 'none', stroke: '#4a4d52', strokeWidth: 4.8 }],
    ['path', { d: 'M8 7.2L19.6 19.2', fill: 'none', stroke: '#cfd3d8', strokeWidth: 3.8 }],
    ['circle', { cx: 20.4, cy: 20.4, r: 2, fill: '#cfd3d8', stroke: '#4a4d52', strokeWidth: 0.8 }],
    ['circle', { cx: 6.4, cy: 6.4, r: 4.6, fill: '#cfd3d8', stroke: '#4a4d52', strokeWidth: 0.9 }],
    ['path', { d: 'M7.32 5.48 L5.48 7.32 L1.24 3.08 L3.08 1.24Z', fill: 'var(--icon-bg, #ffffff)', stroke: 'none' }],
    ['path', { d: 'M7.32 5.48L3.08 1.24M5.48 7.32L1.24 3.08', fill: 'none', stroke: '#4a4d52', strokeWidth: 0.9 }],
    ['path', { d: 'M2.6 9.4L8 4', fill: 'none', stroke: '#f6f7f8', strokeWidth: 0.5 }],
  ],
  WorkersRico: [
    ['path', { d: 'M-6.4 17.2C-6.4 11.6 -3.6 9.6 0 9.6S6.4 11.6 6.4 17.2Z', fill: '#dc3d8c', stroke: '#7a1d4a', strokeWidth: 0.8, transform: 'translate(7.4 3) scale(0.97)' }],
    ['path', { d: 'M-3.2 9.7L0 13.4 3.2 9.7Z', fill: '#ffffff', stroke: '#7a1d4a', strokeWidth: 0.5, transform: 'translate(7.4 3) scale(0.97)' }],
    ['path', { d: 'M-4.8 5C-5.8 -1 -1.6 -2.2 1 -1.6 4 -.9 5.8 1.6 4.8 5.2 6 8.4 5.6 11 3.6 11.4L3.8 6.6C2.4 3.6 -1.2 3.4 -3.8 5.8L-3.6 11.4C-5.8 10.8 -6 8 -4.8 5Z', fill: '#7a3a2a', stroke: '#7a1d4a', strokeWidth: 0.7, transform: 'translate(7.4 3) scale(0.97)' }],
    ['circle', { cx: 0, cy: 4.6, r: 3.9, fill: '#fbdcc4', stroke: '#7a1d4a', strokeWidth: 0.8, transform: 'translate(7.4 3) scale(0.97)' }],
    ['path', { d: 'M-3.6 3.6C-1.6 4 1.6 3 3.8 2.6 3.2 0 .2 -.8 -1.8 0 -3.2 .8 -3.8 2 -3.6 3.6Z', fill: '#7a3a2a', stroke: 'none', transform: 'translate(7.4 3) scale(0.97)' }],
    ['path', { d: 'M-6.6 17.6C-6.6 11.8 -3.6 9.4 0 9.4S6.6 11.8 6.6 17.6Z', fill: '#6f6f6f', stroke: '#2a2a2a', strokeWidth: 0.8, transform: 'translate(16.4 4.2)' }],
    ['path', { d: 'M-2.2 9.5L0 13.2 2.2 9.5Z', fill: '#e9f2ff', stroke: '#2a2a2a', strokeWidth: 0.5, transform: 'translate(16.4 4.2)' }],
    ['path', { d: 'M-.7 11.4H.7L1 15.4 0 16.2 -1 15.4Z', fill: '#8a8a40', stroke: 'none', transform: 'translate(16.4 4.2)' }],
    ['path', { d: 'M-4.4 12V17.4M-2.6 13V17.4M2.6 13V17.4M4.4 12V17.4', fill: 'none', stroke: '#3f3f3f', strokeWidth: 0.4, transform: 'translate(16.4 4.2)' }],
    ['circle', { cx: 0, cy: 4.4, r: 3.8, fill: '#f9d6b8', stroke: '#2a2a2a', strokeWidth: 0.8, transform: 'translate(16.4 4.2)' }],
    ['path', { d: 'M-3.9 3.6C-4.4 -.6 -1.8 -1.5 .6 -1.2 3 -.9 4.4 .7 3.9 3.8 2.6 1.6 -1.6 1.2 -3.9 3.6Z', fill: '#6a4a2a', stroke: 'none', transform: 'translate(16.4 4.2)' }],
  ],
  VentasRico: [
    ['ellipse', { cx: 12, cy: 21.8, rx: 10.4, ry: 1.2, fill: '#2a2a2a', stroke: 'none', fillOpacity: 0.4 }],
    ['path', { d: 'M6.0 16.6L11.2 9.6', fill: 'none', stroke: '#8a5a34', strokeWidth: 5.6 }],
    ['path', { d: 'M6.0 16.6L11.2 9.6', fill: 'none', stroke: '#ebbc92', strokeWidth: 4.4 }],
    ['path', { d: 'M18.0 16.6L12.8 9.6', fill: 'none', stroke: '#8a5a34', strokeWidth: 5.6 }],
    ['path', { d: 'M18.0 16.6L12.8 9.6', fill: 'none', stroke: '#e0a678', strokeWidth: 4.4 }],
    ['path', { d: 'M3.4 20L5.6 17.2', fill: 'none', stroke: '#101010', strokeWidth: 5.8 }],
    ['path', { d: 'M20.6 20L18.4 17.2', fill: 'none', stroke: '#101010', strokeWidth: 5.8 }],
    ['path', { d: 'M5.4 17.4L6.8 15.6M18.6 17.4L17.2 15.6', fill: 'none', stroke: '#f2f2f2', strokeWidth: 1.2 }],
    ['path', { d: 'M7.8 9.6C7.2 7.6 8.6 6 10.2 6.4L10.6 5C11 3.8 12.4 3.6 13 4.6L13.8 3.6C14.8 3 16 3.8 16 5L16.8 6.6C18 7.6 17.4 9.6 16.6 10.6L14 13.6 10.2 12.8Z', fill: '#efc29a', stroke: '#8a5a34', strokeWidth: 0.8, transform: 'translate(-1.8 -1.35) scale(1.15)' }],
    ['path', { d: 'M10.4 6.6L11.6 9M13 5.2L13.6 8.2M15.4 6.8L15 9.6', fill: 'none', stroke: '#a8703e', strokeWidth: 0.6, transform: 'translate(-1.8 -1.35) scale(1.15)' }],
    ['path', { d: 'M9.4 10.6L12 12.4M11.6 9.8L14 11.6', fill: 'none', stroke: '#b27a46', strokeWidth: 0.6, transform: 'translate(-1.8 -1.35) scale(1.15)' }],
  ],
  SortRico: [
    ['path', { d: 'M3.0 9.4L6.0 2.0 9.0 9.4M4.2 6.8H7.8', fill: 'none', stroke: '#1018ff', strokeWidth: 1.9 }],
    ['path', { d: 'M3.2 15.0H9.0L3.2 22.0H9.0', fill: 'none', stroke: '#ee1c1c', strokeWidth: 1.9 }],
    ['path', { d: 'M18.0 1.8V6.6', fill: 'none', stroke: '#e8e8e8', strokeWidth: 2.2 }],
    ['path', { d: 'M18.0 6.6V10.4', fill: 'none', stroke: '#bdbdbd', strokeWidth: 2.2 }],
    ['path', { d: 'M18.0 10.4V14.2', fill: 'none', stroke: '#7e7e7e', strokeWidth: 2.2 }],
    ['path', { d: 'M14.4 14.4 L21.6 14.4 L21.6 17.4 L19.4 17.4 L19.4 20.4 L18 22.2 L16.6 20.4 L16.6 17.4 L14.4 17.4Z', fill: '#101010', stroke: 'none' }],
  ],
  EditarDocRico: [
    ['path', { d: 'M5.4 1.6H20A2.4 2.4 0 0 1 22.4 4V20A2.4 2.4 0 0 1 20 22.4H4A2.4 2.4 0 0 1 1.6 20V5.4Z', fill: '#1b1b1b', stroke: '#000', strokeWidth: 0.5 }],
    ['path', { d: 'M4.4 17.6 L14.8 7.2 L18.4 10.8 L8 21.2 L4 21.6Z', fill: 'none', stroke: '#f2f2f2', strokeWidth: 1.4 }],
    ['path', { d: 'M12.8 9.2L16.4 12.8', fill: 'none', stroke: '#f2f2f2', strokeWidth: 1.1 }],
    ['path', { d: 'M4.4 17.6 L4 21.6 L8 21.2Z', fill: '#f2f2f2', stroke: 'none' }],
    ['circle', { cx: 19, cy: 5.2, r: 1.3, fill: 'none', stroke: '#f2f2f2', strokeWidth: 1.1 }],
  ],
  BlocNotasRico: [
    ['path', { d: 'M7.4 6.4L21.4 4.8V20C21.4 21.2 20.6 22 19.4 22H10C8.6 22 7.4 21 7.4 19.6Z', fill: '#ffffff', stroke: '#111111', strokeWidth: 1.2 }],
    ['path', { d: 'M7.6 8.6L11 8.2V21.8C8.8 21.6 7.6 20.8 7.6 19.4Z', fill: '#c9c9c9', stroke: 'none' }],
    ['path', { d: 'M12.8 11.6H20M12.8 14H20M12.8 16.4H20M12.8 18.8H20', fill: 'none', stroke: '#8c9298', strokeWidth: 0.8 }],
    ['path', { d: 'M1.4 15.8 L5 4.4 L19.4 3.2 L15.2 14.6Z', fill: '#5cd6d8', stroke: '#111111', strokeWidth: 1.2 }],
    ['path', { d: 'M7.4 7.6H16.4M6.2 10.4H14', fill: 'none', stroke: '#111111', strokeWidth: 1.3 }],
    ['path', { d: 'M7.2 2.6v1.6', fill: 'none', stroke: '#8a8a8a', strokeWidth: 1 }],
    ['path', { d: 'M9.0 2.4v1.6', fill: 'none', stroke: '#8a8a8a', strokeWidth: 1 }],
    ['path', { d: 'M10.8 2.2v1.6', fill: 'none', stroke: '#8a8a8a', strokeWidth: 1 }],
    ['path', { d: 'M12.6 2.0v1.6', fill: 'none', stroke: '#8a8a8a', strokeWidth: 1 }],
    ['path', { d: 'M14.4 1.8v1.6', fill: 'none', stroke: '#8a8a8a', strokeWidth: 1 }],
    ['path', { d: 'M16.2 1.6v1.6', fill: 'none', stroke: '#8a8a8a', strokeWidth: 1 }],
  ],
  RelojAvisoRico: [
    ['circle', { cx: 12, cy: 12, r: 9.8, fill: '#f6f0fb', stroke: '#9b78ad', strokeWidth: 1.4 }],
    ['circle', { cx: 12, cy: 12, r: 8.2, fill: 'none', stroke: '#d8c4e4', strokeWidth: 0.7 }],
    ['path', { d: 'M12 12 L9.6 7.4 L14.6 9.8Z', fill: '#d8bc48', stroke: '#8a6f1a', strokeWidth: 0.5 }],
    ['path', { d: 'M12 12L8.4 8.2M12 12L14.2 17', fill: 'none', stroke: '#1a1a1a', strokeWidth: 1.5 }],
    ['circle', { cx: 18.6, cy: 5.4, r: 3, fill: '#fff27a', stroke: 'none', fillOpacity: 0.7 }],
    ['circle', { cx: 18.6, cy: 5.4, r: 1.5, fill: '#ffffe0', stroke: 'none', fillOpacity: 0.9 }],
  ],
};

const RICA: Paleta = { p: '#000000' };

export const IngPlanillasColorIcon = crearColor('IngPlanillas', D.IngPlanillasRico, RICA);
export const LibDiarioColorIcon = crearColor('LibDiario', D.LibDiarioRico, RICA);
export const LibMayorColorIcon = crearColor('LibMayor', D.LibMayorRico, RICA);
export const LineaTelefonicaColorIcon = crearColor('LineaTelefonica', D.LineaTelefonicaRico, RICA);
export const MpIconColorIcon = crearColor('MpIcon', D.MpIconRico, RICA);
export const OfficeColorIcon = crearColor('Office', D.OfficeRico, RICA);
export const AfpColorIcon = crearColor('Afp', D.AfpRico, RICA);
export const AreaCostoColorIcon = crearColor('AreaCosto', D.AreaCostoRico, RICA);
export const CerrarPrColorIcon = crearColor('CerrarPr', D.CerrarPrRico, RICA);
export const CtasCtesColorIcon = crearColor('CtasCtes', D.CtasCtesRico, RICA);
export const HeIconColorIcon = crearColor('HeIcon', D.HeIconRico, RICA);
export const HorsExtColorIcon = crearColor('HorsExt', D.HorsExtRico, RICA);
export const HrsEquipoColorIcon = crearColor('HrsEquipo', D.HrsEquipoRico, RICA);
export const IcoRelojColorIcon = crearColor('IcoReloj', D.IcoRelojRico, RICA);
export const IcoReloj2ColorIcon = crearColor('IcoReloj2', D.IcoReloj2Rico, RICA);
export const IcoReloj3ColorIcon = crearColor('IcoReloj3', D.IcoReloj3Rico, RICA);
export const Indicadorico2ColorIcon = crearColor('Indicadorico2', D.Indicadorico2Rico, RICA);
export const Indicadorico3ColorIcon = crearColor('Indicadorico3', D.Indicadorico3Rico, RICA);
export const ImpresoraIcoColorIcon = crearColor('ImpresoraIco', D.ImpresoraIcoRico, RICA);
export const ImpresoraPngColorIcon = crearColor('ImpresoraPng', D.ImpresoraPngRico, RICA);
export const CameraColorIcon = crearColor('Camara', D.CamaraRico, RICA);
export const OcurrenciasColorIcon = crearColor('Ocurrencias', D.OcurrenciasRico, RICA);
export const PedidoImportacionColorIcon = crearColor('PedidoImportacion', D.PedidoImportacionRico, RICA);
export const PlanillaOficialColorIcon = crearColor('PlanillaOficial', D.PlanillaOficialRico, RICA);
export const PlanillasColorIcon = crearColor('Planillas', D.PlanillasRico, RICA);
export const PlanillasSueldosColorIcon = crearColor('PlanillasSueldos', D.PlanillasSueldosRico, RICA);
export const PlantillasColorIcon = crearColor('Plantillas', D.PlantillasRico, RICA);
export const TransferenciaInternaColorIcon = crearColor('TransferenciaInterna', D.TransferenciaInternaRico, RICA);
export const UbicacionColorIcon = crearColor('Ubicacion', D.UbicacionRico, RICA);
export const UserColorIcon = crearColor('User', D.UserRico, RICA);
export const UsersColorIcon = crearColor('Users', D.UsersRico, RICA);
export const ValesMaterialColorIcon = crearColor('ValesMaterial', D.ValesMaterialRico, RICA);
export const WorkersColorIcon = crearColor('Workers', D.WorkersRico, RICA);
export const VentasColorIcon = crearColor('Ventas', D.VentasRico, RICA);
export const SortColorIcon = crearColor('Sort', D.SortRico, RICA);
export const EditarDocColorIcon = crearColor('EditarDoc', D.EditarDocRico, RICA);
export const BlocNotasColorIcon = crearColor('BlocNotas', D.BlocNotasRico, RICA);
export const RelojAvisoColorIcon = crearColor('RelojAviso', D.RelojAvisoRico, RICA);

export const ICONOS_COLOR = {
  ing_planillas: IngPlanillasColorIcon,
  LibDiario: LibDiarioColorIcon,
  LibMayor: LibMayorColorIcon,
  linea_telefonica: LineaTelefonicaColorIcon,
  mp_icon: MpIconColorIcon,
  Office: OfficeColorIcon,
  Afp: AfpColorIcon,
  area_costo: AreaCostoColorIcon,
  Cerrar_Pr: CerrarPrColorIcon,
  ctas_ctes: CtasCtesColorIcon,
  HE_icon: HeIconColorIcon,
  HorsExt: HorsExtColorIcon,
  hrs_equipo: HrsEquipoColorIcon,
  ico_reloj: IcoRelojColorIcon,
  Ico_reloj2: IcoReloj2ColorIcon,
  ico_reloj3: IcoReloj3ColorIcon,
  indicadorico2: Indicadorico2ColorIcon,
  indicadorico3: Indicadorico3ColorIcon,
  'Impresora.ico': ImpresoraIcoColorIcon,
  'Impresora.png': ImpresoraPngColorIcon,
  camera: CameraColorIcon,
  ocurrencias: OcurrenciasColorIcon,
  pedidoImportacion: PedidoImportacionColorIcon,
  planilla_oficial: PlanillaOficialColorIcon,
  planillas: PlanillasColorIcon,
  Planillas_Sueldos: PlanillasSueldosColorIcon,
  plantillas: PlantillasColorIcon,
  transferenciaInterna: TransferenciaInternaColorIcon,
  Ubicacion: UbicacionColorIcon,
  User: UserColorIcon,
  users: UsersColorIcon,
  valesMaterial: ValesMaterialColorIcon,
  workers: WorkersColorIcon,
  ventas: VentasColorIcon,
  Sort: SortColorIcon,
  editar_doc: EditarDocColorIcon,
  Bloc_Notas: BlocNotasColorIcon,
  Reloj_Aviso: RelojAvisoColorIcon,
} as const;

export type NombreIconoColor = keyof typeof ICONOS_COLOR;
