/**
 * Iconos SIGECOM a COLOR (estilo Lucide con relleno). 24x24, trazo + relleno por icono.
 * Cada icono tiene su propia paleta tomada del icono original.
 * Aceptan las mismas props que lucide-react (size, strokeWidth, className...).
 * Nota: `color` no cambia el relleno; el relleno viene de la paleta de cada icono.
 *
 * Uso:
 *   import { AnularColorIcon, ICONOS_COLOR } from './iconos-sigecom-color';
 *   <AnularColorIcon size={24} />
 *   const Icono = ICONOS_COLOR['doc_elec_lupa']; <Icono />   // clave = nombre original del archivo
 *   (si varios archivos comparten nombre, la clave lleva la extensión: ICONOS_COLOR['Anular.png'])
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
        a.stroke = k ? trazo(String(k), pal) : TINTA;
      }
      return [tag, a];
    }) as unknown as IconNode,
  );

/* ---------- diseños (f = relleno, k = trazo; P/S/T = colores de la paleta, W = blanco, K = tinta) ---------- */
const D: Record<string, Nodo[]> = {
  MaximunRico: [
    ['rect', { x: 3, y: 5, width: 15.5, height: 16.5, rx: 1.6, fill: '#f3f4f6', stroke: '#7b8088', strokeWidth: 1 }],
    ['rect', { x: 4.6, y: 6.6, width: 12.3, height: 13.2, rx: 1, fill: '#ffffff', stroke: 'none', fillOpacity: 0.7 }],
    ['path', { d: 'M18.2 3.6 22 7.4 13.4 16 9.4 17.2 10.6 13.2Z', fill: '#d99a2b', stroke: '#6b3d0c', strokeWidth: 0.9 }],
    ['path', { d: 'M18.2 3.6 22 7.4 20.4 9 16.6 5.2Z', fill: '#f3e2b0', stroke: '#6b3d0c', strokeWidth: 0.7 }],
    ['path', { d: 'M10.6 13.2 9.4 17.2 13.4 16Z', fill: '#33241a', stroke: '#1c130d', strokeWidth: 0.6 }],
    ['path', { d: 'M17 6.5 21 10.3', fill: 'none', stroke: '#b9801f', strokeWidth: 0.5 }],
    ['circle', { cx: 9, cy: 9, r: 5.4, fill: '#c7dcf7', stroke: '#868c95', strokeWidth: 1.5 }],
    ['circle', { cx: 9, cy: 9, r: 3.6, fill: '#e8f1fd', stroke: 'none', fillOpacity: 0.9 }],
    ['path', { d: 'M6.4 7.8a3.6 3.6 0 0 1 3.4-2', fill: 'none', stroke: '#ffffff', strokeWidth: 0.9 }],
  ],
  PagosRico: [
    ['path', { d: 'M1 4.6 L5.4 1.4 L8.4 5.8 L3.8 9Z', fill: '#3b57d8', stroke: '#16257a', strokeWidth: 0.8 }],
    ['path', { d: 'M1.9 5.2 L3.4 4.1 L5.2 6.7 L3.6 7.8Z', fill: '#9db2ff', stroke: 'none', fillOpacity: 0.9 }],
    ['path', { d: 'M8.6 8.4 L19.4 6.2 L21.4 13.2 L10.6 15.6Z', fill: '#74dc97', stroke: '#2c8250', strokeWidth: 0.9 }],
    ['path', { d: 'M9.8 9.6 L18.6 7.8 L20 12.6 L11.2 14.4Z', fill: 'none', stroke: '#2c8250', strokeWidth: 0.5 }],
    ['circle', { cx: 15.2, cy: 11.2, r: 2.1, fill: '#a6efbc', stroke: '#2c8250', strokeWidth: 0.6 }],
    ['path', { d: 'M10.6 11.2l1.2-.3M17.6 9.2l1-.2M12 13.4l1.4-.3', fill: 'none', stroke: '#2c8250', strokeWidth: 0.6 }],
    ['path', { d: 'M5.8 6.2C9 4.4 13.4 3.8 16.8 5l.6 2.4-9.4 2.4-2.2-1.2Z', fill: '#f2bd91', stroke: '#9b5a2a', strokeWidth: 0.8 }],
    ['path', { d: 'M16.6 5.2c1.4.2 1.8 1 1.4 1.8l-.8.8', fill: '#f2bd91', stroke: '#9b5a2a', strokeWidth: 0.7 }],
    ['path', { d: 'M9.8 14.6 11 11.4l2.4.6-.6 3.2Z', fill: '#f2bd91', stroke: '#9b5a2a', strokeWidth: 0.7 }],
    ['path', { d: 'M12.6 15.2l1.2-3.4 2.4.5-.8 3.5Z', fill: '#f2bd91', stroke: '#9b5a2a', strokeWidth: 0.7 }],
    ['path', { d: 'M15.6 15.8l1.2-3.6 2.4.4-.9 3.9Z', fill: '#f2bd91', stroke: '#9b5a2a', strokeWidth: 0.7 }],
    ['path', { d: 'M9.6 15.2c3-.6 8.6-1.4 11-.2l-.4 3.6-8.6 1.8Z', fill: '#f2bd91', stroke: '#9b5a2a', strokeWidth: 0.8 }],
    ['path', { d: 'M16 19.6 L22.6 17.4 L23.4 22 L16.8 23.8Z', fill: '#3b57d8', stroke: '#16257a', strokeWidth: 0.8 }],
    ['path', { d: 'M16.8 20.4 L21.8 18.8 L22 20.4 L17.2 21.8Z', fill: '#9db2ff', stroke: 'none', fillOpacity: 0.9 }],
  ],
  LibrosContRico: [
    ['path', { d: 'M2.6 12.8 L12.2 16 L12.2 19.2 L2.6 16Z', fill: '#6a9a1a', stroke: '#2f5a0a', strokeWidth: 0.8 }],
    ['path', { d: 'M12.2 16 L18.4 11.2 L18.4 14.4 L12.2 19.2Z', fill: '#eef6cf', stroke: '#2f5a0a', strokeWidth: 0.8 }],
    ['path', { d: 'M12.2 16.96L18.4 12.16', fill: 'none', stroke: '#b8c98a', strokeWidth: 0.4 }],
    ['path', { d: 'M12.2 17.76L18.4 12.96', fill: 'none', stroke: '#b8c98a', strokeWidth: 0.4 }],
    ['path', { d: 'M12.2 18.56L18.4 13.76', fill: 'none', stroke: '#b8c98a', strokeWidth: 0.4 }],
    ['path', { d: 'M2.6 12.8 L12.2 16 L18.4 11.2 L8.8 8Z', fill: '#a8d635', stroke: '#2f5a0a', strokeWidth: 0.8 }],
    ['path', { d: 'M3.6 9.2 L13.4 12.2 L13.4 16 L3.6 13Z', fill: '#1565b8', stroke: '#0e3d7a', strokeWidth: 0.8 }],
    ['path', { d: 'M13.4 12.2 L19.6 7.6 L19.6 11.4 L13.4 16Z', fill: '#f7fafc', stroke: '#0e3d7a', strokeWidth: 0.8 }],
    ['path', { d: 'M13.4 13.34L19.6 8.74', fill: 'none', stroke: '#9aa8b8', strokeWidth: 0.4 }],
    ['path', { d: 'M13.4 14.29L19.6 9.69', fill: 'none', stroke: '#9aa8b8', strokeWidth: 0.4 }],
    ['path', { d: 'M13.4 15.24L19.6 10.64', fill: 'none', stroke: '#9aa8b8', strokeWidth: 0.4 }],
    ['path', { d: 'M3.6 9.2 L13.4 12.2 L19.6 7.6 L9.8 4.6Z', fill: '#2b9be8', stroke: '#0e3d7a', strokeWidth: 0.8 }],
    ['path', { d: 'M4.488 8.952 L13.504 11.712 L15.488 10.24 L6.472 7.48Z', fill: '#ffffff', stroke: 'none', fillOpacity: 0.28 }],
  ],
  Books256Rico: [
    ['path', { d: 'M3 11.6 L13.2 14.9 L13.2 18.5 L3 15.2Z', fill: '#2f7a3f', stroke: '#173a22', strokeWidth: 0.8 }],
    ['path', { d: 'M4.224 11.996 L5.448 12.392 L5.448 15.992 L4.224 15.596Z', fill: '#f2c93c', stroke: 'none' }],
    ['path', { d: 'M6.264 12.656 L7.488 13.052 L7.488 16.652 L6.264 16.256Z', fill: '#f2c93c', stroke: 'none' }],
    ['path', { d: 'M13.2 14.9 L19.8 9.9 L19.8 13.5 L13.2 18.5Z', fill: '#f3d36a', stroke: '#173a22', strokeWidth: 0.8 }],
    ['path', { d: 'M13.2 15.98L19.8 10.98', fill: 'none', stroke: '#c7922a', strokeWidth: 0.4 }],
    ['path', { d: 'M13.2 16.88L19.8 11.88', fill: 'none', stroke: '#c7922a', strokeWidth: 0.4 }],
    ['path', { d: 'M13.2 17.78L19.8 12.78', fill: 'none', stroke: '#c7922a', strokeWidth: 0.4 }],
    ['path', { d: 'M3 11.6 L13.2 14.9 L19.8 9.9 L9.6 6.6Z', fill: '#3f8a4c', stroke: '#173a22', strokeWidth: 0.8 }],
    ['path', { d: 'M3.936 11.332 L13.32 14.368 L15.432 12.768 L6.048 9.732Z', fill: '#ffffff', stroke: 'none', fillOpacity: 0.28 }],
    ['path', { d: 'M5.6 6.6 L16 9.6 L16 13.4 L5.6 10.4Z', fill: '#1f6fc4', stroke: '#0c2f66', strokeWidth: 0.8 }],
    ['path', { d: 'M6.64 6.9 L7.888 7.26 L7.888 11.06 L6.64 10.7Z', fill: '#f2c93c', stroke: 'none' }],
    ['path', { d: 'M8.72 7.5 L9.968 7.86 L9.968 11.66 L8.72 11.3Z', fill: '#f2c93c', stroke: 'none' }],
    ['path', { d: 'M16 9.6 L22.4 4.4 L22.4 8.2 L16 13.4Z', fill: '#f3d36a', stroke: '#0c2f66', strokeWidth: 0.8 }],
    ['path', { d: 'M16 10.74L22.4 5.54', fill: 'none', stroke: '#c7922a', strokeWidth: 0.4 }],
    ['path', { d: 'M16 11.69L22.4 6.49', fill: 'none', stroke: '#c7922a', strokeWidth: 0.4 }],
    ['path', { d: 'M16 12.64L22.4 7.44', fill: 'none', stroke: '#c7922a', strokeWidth: 0.4 }],
    ['path', { d: 'M5.6 6.6 L16 9.6 L22.4 4.4 L12 1.4Z', fill: '#2fa4ee', stroke: '#0c2f66', strokeWidth: 0.8 }],
    ['path', { d: 'M6.528 6.304 L16.096 9.064 L18.144 7.4 L8.576 4.64Z', fill: '#ffffff', stroke: 'none', fillOpacity: 0.28 }],
    ['path', { d: 'M10.384 6.148 L14.96 7.468 L17.776 5.18 L13.2 3.86Z', fill: '#f6d452', stroke: '#8a5a08', strokeWidth: 0.7 }],
    ['path', { d: 'M11.984 5.764 L14.896 6.604 L16.176 5.564 L13.264 4.724Z', fill: '#30a6ef', stroke: 'none' }],
    ['path', { d: 'M13.04 5.364L15.12 5.964', fill: 'none', stroke: '#f6d452', strokeWidth: 0.7 }],
  ],
  DocRico: [
    ['path', { d: 'M2.4 17.2 L13.8 20.2 L13.8 22.9 L2.4 19.9Z', fill: '#c06f08', stroke: '#4a2a08', strokeWidth: 0.8 }],
    ['path', { d: 'M13.8 20.2 L21.2 16 L21.2 18.7 L13.8 22.9Z', fill: '#f4d98a', stroke: '#4a2a08', strokeWidth: 0.8 }],
    ['path', { d: 'M13.8 21.01L21.2 16.81', fill: 'none', stroke: '#8a6a20', strokeWidth: 0.4 }],
    ['path', { d: 'M13.8 21.685L21.2 17.485', fill: 'none', stroke: '#8a6a20', strokeWidth: 0.4 }],
    ['path', { d: 'M13.8 22.36L21.2 18.16', fill: 'none', stroke: '#8a6a20', strokeWidth: 0.4 }],
    ['path', { d: 'M2.4 17.2 L13.8 20.2 L21.2 16 L9.8 13Z', fill: '#d98512', stroke: '#4a2a08', strokeWidth: 0.8 }],
    ['path', { d: 'M2.4 13.8 L13.8 16.8 L13.8 19.5 L2.4 16.5Z', fill: '#58491a', stroke: '#2a2208', strokeWidth: 0.8 }],
    ['path', { d: 'M13.8 16.8 L21.2 12.6 L21.2 15.3 L13.8 19.5Z', fill: '#d9c479', stroke: '#2a2208', strokeWidth: 0.8 }],
    ['path', { d: 'M13.8 17.61L21.2 13.41', fill: 'none', stroke: '#8a6a20', strokeWidth: 0.4 }],
    ['path', { d: 'M13.8 18.285L21.2 14.085', fill: 'none', stroke: '#8a6a20', strokeWidth: 0.4 }],
    ['path', { d: 'M13.8 18.96L21.2 14.76', fill: 'none', stroke: '#8a6a20', strokeWidth: 0.4 }],
    ['path', { d: 'M2.4 13.8 L13.8 16.8 L21.2 12.6 L9.8 9.6Z', fill: '#6a581c', stroke: '#2a2208', strokeWidth: 0.8 }],
    ['path', { d: 'M2.4 10.4 L13.8 13.4 L13.8 16.1 L2.4 13.1Z', fill: '#c9a020', stroke: '#5a4608', strokeWidth: 0.8 }],
    ['path', { d: 'M13.8 13.4 L21.2 9.2 L21.2 11.9 L13.8 16.1Z', fill: '#f8ecaa', stroke: '#5a4608', strokeWidth: 0.8 }],
    ['path', { d: 'M13.8 14.21L21.2 10.01', fill: 'none', stroke: '#8a6a20', strokeWidth: 0.4 }],
    ['path', { d: 'M13.8 14.885L21.2 10.685', fill: 'none', stroke: '#8a6a20', strokeWidth: 0.4 }],
    ['path', { d: 'M13.8 15.56L21.2 11.36', fill: 'none', stroke: '#8a6a20', strokeWidth: 0.4 }],
    ['path', { d: 'M2.4 10.4 L13.8 13.4 L21.2 9.2 L9.8 6.2Z', fill: '#e6bb2c', stroke: '#5a4608', strokeWidth: 0.8 }],
    ['path', { d: 'M2.4 7 L13.8 10 L13.8 12.7 L2.4 9.7Z', fill: '#8a1c0e', stroke: '#3a0c06', strokeWidth: 0.8 }],
    ['path', { d: 'M13.8 10 L21.2 5.8 L21.2 8.5 L13.8 12.7Z', fill: '#f0c0a8', stroke: '#3a0c06', strokeWidth: 0.8 }],
    ['path', { d: 'M13.8 10.81L21.2 6.61', fill: 'none', stroke: '#8a6a20', strokeWidth: 0.4 }],
    ['path', { d: 'M13.8 11.485L21.2 7.285', fill: 'none', stroke: '#8a6a20', strokeWidth: 0.4 }],
    ['path', { d: 'M13.8 12.16L21.2 7.96', fill: 'none', stroke: '#8a6a20', strokeWidth: 0.4 }],
    ['path', { d: 'M2.4 7 L13.8 10 L21.2 5.8 L9.8 2.8Z', fill: '#a82312', stroke: '#3a0c06', strokeWidth: 0.8 }],
    ['path', { d: 'M2.4 3.6 L13.8 6.6 L13.8 9.3 L2.4 6.3Z', fill: '#0f1a1a', stroke: '#050a0a', strokeWidth: 0.8 }],
    ['path', { d: 'M13.8 6.6 L21.2 2.4 L21.2 5.1 L13.8 9.3Z', fill: '#e9eef0', stroke: '#050a0a', strokeWidth: 0.8 }],
    ['path', { d: 'M13.8 7.41L21.2 3.21', fill: 'none', stroke: '#8a6a20', strokeWidth: 0.4 }],
    ['path', { d: 'M13.8 8.085L21.2 3.885', fill: 'none', stroke: '#8a6a20', strokeWidth: 0.4 }],
    ['path', { d: 'M13.8 8.76L21.2 4.56', fill: 'none', stroke: '#8a6a20', strokeWidth: 0.4 }],
    ['path', { d: 'M2.4 3.6 L13.8 6.6 L21.2 2.4 L9.8 -0.6Z', fill: '#1d2b2b', stroke: '#050a0a', strokeWidth: 0.8 }],
    ['path', { d: 'M3.448 3.384 L13.936 6.144 L16.304 4.8 L5.816 2.04Z', fill: '#ffffff', stroke: 'none', fillOpacity: 0.28 }],
  ],
  TicketRico: [
    ['path', { d: 'M8.6 2.4 L17.8 1.6 L18.6 10.6 L9.4 11.4Z', fill: '#ffffff', stroke: '#7b7f86', strokeWidth: 0.8 }],
    ['circle', { cx: 12.2, cy: 5.2, r: 0.55, fill: '#e8707a', stroke: 'none' }],
    ['circle', { cx: 14.4, cy: 4.9, r: 0.55, fill: '#e8707a', stroke: 'none' }],
    ['circle', { cx: 16, cy: 5.8, r: 0.55, fill: '#e8707a', stroke: 'none' }],
    ['circle', { cx: 12.8, cy: 7.4, r: 0.55, fill: '#e8707a', stroke: 'none' }],
    ['circle', { cx: 15.4, cy: 8, r: 0.55, fill: '#e8707a', stroke: 'none' }],
    ['circle', { cx: 11.2, cy: 9.4, r: 0.5, fill: '#e8707a', stroke: 'none' }],
    ['path', { d: 'M5.2 10.2 L19.2 9.2 L22.4 13 L2 13.4Z', fill: '#f2f2f2', stroke: '#3a3d44', strokeWidth: 0.8 }],
    ['path', { d: 'M2 13.4 L22.4 13 L22.4 19.6 L2 19.8Z', fill: '#cfcfd2', stroke: '#3a3d44', strokeWidth: 0.8 }],
    ['path', { d: 'M2 13.4 L22.4 13 L22.4 15.2 L2 15.6Z', fill: '#ffffff', stroke: 'none', fillOpacity: 0.6 }],
    ['rect', { x: 11, y: 11.1, width: 2, height: 1.2, rx: 0.5, fill: '#3fa389', stroke: 'none' }],
    ['path', { d: 'M1 19.2 L8 17.2 L16 17.4 L23 19.2 L23 21 L1 21Z', fill: '#ffffff', stroke: '#3a3d44', strokeWidth: 0.8 }],
    ['path', { d: 'M4 19.6h16', fill: 'none', stroke: '#9a9ea6', strokeWidth: 0.6 }],
  ],
  TarifasRico: [
    ['path', { d: 'M9.2 4.6c-1.8-.7-2.6-1.8-2.2-3 1 .2 1.8.7 2.4 1.4.8-.8 1.8-.8 2.6 0 .6-.7 1.4-1.2 2.4-1.4.4 1.2-.4 2.3-2.2 3 4.4 1.8 7.2 5.6 7.2 10 0 3.6-2.2 5.4-5.8 5.4H8c-3.6 0-5.8-1.8-5.8-5.4 0-4.4 2.8-8.2 7-10Z', fill: '#cf9a3e', stroke: '#6a4310', strokeWidth: 0.9 }],
    ['path', { d: 'M8.6 4.8c1.2.8 4.6.8 5.8 0', fill: 'none', stroke: '#8a5a14', strokeWidth: 0.8 }],
    ['path', { d: 'M7 7.6c-2.2 2.2-3 5-2.8 8', fill: 'none', stroke: '#f0cf86', strokeWidth: 0.7 }],
    ['circle', { cx: 12, cy: 14.2, r: 5.1, fill: '#f4efc6', stroke: '#8a6a1e', strokeWidth: 0.8 }],
    ['circle', { cx: 12, cy: 14.2, r: 4, fill: '#fbf8de', stroke: 'none' }],
    ['path', { d: 'M13.9 12c-.5-.8-1.4-1.1-2.3-.9-1.1.2-1.6 1.2-1.2 2 .5 1.2 2.9 1 3.4 2.2.3.9-.4 1.9-1.5 2-.9.1-1.9-.2-2.5-1M12 10.4v8.3', fill: 'none', stroke: '#1f9a4a', strokeWidth: 1.5 }],
  ],
  TabRico: [
    ['path', { d: 'M2.4 2.4v9', fill: 'none', stroke: '#000080', strokeWidth: 2 }],
    ['path', { d: 'M5 6.9h16.4', fill: 'none', stroke: '#000080', strokeWidth: 1.8 }],
    ['path', { d: 'M4.6 6.9 L9.4 3.8 L9.4 10Z', fill: '#000080', stroke: '#000080', strokeWidth: 0.6 }],
    ['path', { d: 'M21.6 12.6v9', fill: 'none', stroke: '#000080', strokeWidth: 2 }],
    ['path', { d: 'M2.6 17.1H19', fill: 'none', stroke: '#000080', strokeWidth: 1.8 }],
    ['path', { d: 'M19.4 17.1 L14.6 14 L14.6 20.2Z', fill: '#000080', stroke: '#000080', strokeWidth: 0.6 }],
  ],
  SugerirRico: [
    ['path', { d: 'M9.4 2.2v19.6', fill: 'none', stroke: '#2e7d12', strokeWidth: 2.6 }],
    ['path', { d: 'M14.2 6.2H8.4a3.4 3.4 0 0 0 0 6.8h2a3.4 3.4 0 0 1 0 6.8H4', fill: 'none', stroke: '#2e7d12', strokeWidth: 2.8 }],
    ['path', { d: 'M21.4 2 15.2 22', fill: 'none', stroke: '#ee1c1c', strokeWidth: 1.6 }],
    ['circle', { cx: 17, cy: 4.4, r: 1.8, fill: 'none', stroke: '#ee1c1c', strokeWidth: 1.3 }],
    ['circle', { cx: 21.2, cy: 19.8, r: 1.8, fill: 'none', stroke: '#ee1c1c', strokeWidth: 1.3 }],
  ],
  VehiculoIcoRico: [
    ['path', { d: 'M8.8 5 L23 5 L23 16.4 L8.8 16.4Z', fill: '#ffab0a', stroke: '#6b3a00', strokeWidth: 0.8 }],
    ['path', { d: 'M11 5.6v10.2', fill: 'none', stroke: '#ffd24d', strokeWidth: 1 }],
    ['path', { d: 'M13.4 5.6v10.2', fill: 'none', stroke: '#ffd24d', strokeWidth: 1 }],
    ['path', { d: 'M15.8 5.6v10.2', fill: 'none', stroke: '#ffd24d', strokeWidth: 1 }],
    ['path', { d: 'M18.2 5.6v10.2', fill: 'none', stroke: '#ffd24d', strokeWidth: 1 }],
    ['path', { d: 'M20.6 5.6v10.2', fill: 'none', stroke: '#ffd24d', strokeWidth: 1 }],
    ['path', { d: 'M1.4 9.2 L4.4 6.2 L8.8 6.2 L8.8 17.4 L1.4 17.4Z', fill: '#ff9d0a', stroke: '#6b3a00', strokeWidth: 0.8 }],
    ['path', { d: 'M3.2 8.2 L6.2 8.2 L6.2 12.4 L3.2 12.4Z', fill: '#a8ecf2', stroke: '#4a8a90', strokeWidth: 0.6 }],
    ['circle', { cx: 4.7, cy: 9.9, r: 0.9, fill: '#f7d08a', stroke: 'none' }],
    ['path', { d: 'M3.6 12.4c0-1 .6-1.6 1.1-1.6s1.1.6 1.1 1.6Z', fill: '#e8452c', stroke: 'none' }],
    ['path', { d: 'M1.4 15.4 L8.8 15.4 L8.8 17.4 L1.4 17.4Z', fill: '#8d96a0', stroke: '#4a5058', strokeWidth: 0.6 }],
    ['circle', { cx: 6, cy: 18.2, r: 3.2, fill: '#8e949c', stroke: '#23272d', strokeWidth: 1.4 }],
    ['circle', { cx: 6, cy: 18.2, r: 1.4, fill: '#cfd3d8', stroke: '#4a5058', strokeWidth: 0.6 }],
    ['circle', { cx: 18.4, cy: 18.2, r: 3.2, fill: '#8e949c', stroke: '#23272d', strokeWidth: 1.4 }],
    ['circle', { cx: 18.4, cy: 18.2, r: 1.4, fill: '#cfd3d8', stroke: '#4a5058', strokeWidth: 0.6 }],
  ],
  TomaInventarioRico: [
    ['path', { d: 'M3.3 14.6 L12.55 17.7 L12.55 22.1 L3.3 19Z', fill: '#4cbf3a', stroke: '#0e3a22', strokeWidth: 1 }],
    ['path', { d: 'M12.55 17.7 L21.55 13.8 L21.55 18.2 L12.55 22.1Z', fill: '#ffffff', stroke: '#0e3a22', strokeWidth: 1 }],
    ['path', { d: 'M12.55 19.02L21.55 15.12', fill: 'none', stroke: '#eef2ee', strokeWidth: 0.4 }],
    ['path', { d: 'M12.55 20.12L21.55 16.22', fill: 'none', stroke: '#eef2ee', strokeWidth: 0.4 }],
    ['path', { d: 'M12.55 21.22L21.55 17.32', fill: 'none', stroke: '#eef2ee', strokeWidth: 0.4 }],
    ['path', { d: 'M3.3 14.6 L12.55 17.7 L21.55 13.8 L12.3 10.7Z', fill: '#7de06a', stroke: '#0e3a22', strokeWidth: 1 }],
    ['path', { d: 'M1.1 9.6 L10.25 13 L10.25 17.2 L1.1 13.8Z', fill: '#1f6fd6', stroke: '#0a2a66', strokeWidth: 1 }],
    ['path', { d: 'M10.25 13 L19.25 9.1 L19.25 13.3 L10.25 17.2Z', fill: '#ffffff', stroke: '#0a2a66', strokeWidth: 1 }],
    ['path', { d: 'M10.25 14.26L19.25 10.36', fill: 'none', stroke: '#eef2f6', strokeWidth: 0.4 }],
    ['path', { d: 'M10.25 15.31L19.25 11.41', fill: 'none', stroke: '#eef2f6', strokeWidth: 0.4 }],
    ['path', { d: 'M10.25 16.36L19.25 12.46', fill: 'none', stroke: '#eef2f6', strokeWidth: 0.4 }],
    ['path', { d: 'M1.1 9.6 L10.25 13 L19.25 9.1 L10.1 5.7Z', fill: '#3a9af0', stroke: '#0a2a66', strokeWidth: 1 }],
    ['path', { d: 'M4.25 4.9 L13.6 8 L13.6 12.6 L4.25 9.5Z', fill: '#e0424a', stroke: '#6a0a12', strokeWidth: 1 }],
    ['path', { d: 'M13.6 8 L22.6 4.1 L22.6 8.7 L13.6 12.6Z', fill: '#ffffff', stroke: '#6a0a12', strokeWidth: 1 }],
    ['path', { d: 'M13.6 9.38L22.6 5.48', fill: 'none', stroke: '#f4eeee', strokeWidth: 0.4 }],
    ['path', { d: 'M13.6 10.53L22.6 6.63', fill: 'none', stroke: '#f4eeee', strokeWidth: 0.4 }],
    ['path', { d: 'M13.6 11.68L22.6 7.78', fill: 'none', stroke: '#f4eeee', strokeWidth: 0.4 }],
    ['path', { d: 'M4.25 4.9 L13.6 8 L22.6 4.1 L13.25 1Z', fill: '#ff7a80', stroke: '#6a0a12', strokeWidth: 1 }],
    ['path', { d: 'M5.7975 4.587 L14.0325 7.455 L16.085 6.208 L9.422 3.517Z', fill: '#ffffff', stroke: 'none', fillOpacity: 0.25 }],
    ['path', { d: 'M4.6 9.5 13.2 12.4', fill: 'none', stroke: '#ff8a90', strokeWidth: 0.5 }],
  ],
  VencimientoAcumuladaRico: [
    ['ellipse', { cx: 11, cy: 13, rx: 8.6, ry: 9.6, fill: '#f08a1c', stroke: '#c85a00', strokeWidth: 1 }],
    ['ellipse', { cx: 11, cy: 15.4, rx: 6.6, ry: 6.2, fill: '#ffc94a', stroke: 'none', fillOpacity: 0.85 }],
    ['ellipse', { cx: 7.6, cy: 10.6, rx: 1.5, ry: 2.5, fill: '#fff1c9', stroke: '#c85a00', strokeWidth: 0.6 }],
    ['ellipse', { cx: 14.4, cy: 10.6, rx: 1.5, ry: 2.5, fill: '#fff1c9', stroke: '#c85a00', strokeWidth: 0.6 }],
    ['path', { d: 'M7.2 17.8c1.6-2.2 6-2.2 7.6 0', fill: 'none', stroke: '#c85a00', strokeWidth: 1.4 }],
    ['path', { d: 'M5.4 7.4c1-1 2.6-1.4 3.8-1M12.8 6.4c1.2-.4 2.8 0 3.8 1', fill: 'none', stroke: '#c85a00', strokeWidth: 0.7 }],
    ['circle', { cx: 18.2, cy: 6, r: 4.4, fill: '#58c63a', stroke: '#2f8a1a', strokeWidth: 0.9 }],
    ['circle', { cx: 17.6, cy: 5.2, r: 3, fill: '#8fe36f', stroke: 'none', fillOpacity: 0.5 }],
    ['path', { d: 'M18.2 3.4v5.2M15.6 6h5.2', fill: 'none', stroke: '#ffffff', strokeWidth: 1.8 }],
  ],
  VencimientoDetalleRico: [
    ['ellipse', { cx: 11, cy: 13, rx: 8.6, ry: 9.6, fill: '#f08a1c', stroke: '#c85a00', strokeWidth: 1 }],
    ['ellipse', { cx: 11, cy: 15.4, rx: 6.6, ry: 6.2, fill: '#ffc94a', stroke: 'none', fillOpacity: 0.85 }],
    ['ellipse', { cx: 7.6, cy: 10.6, rx: 1.5, ry: 2.5, fill: '#fff1c9', stroke: '#c85a00', strokeWidth: 0.6 }],
    ['ellipse', { cx: 14.4, cy: 10.6, rx: 1.5, ry: 2.5, fill: '#fff1c9', stroke: '#c85a00', strokeWidth: 0.6 }],
    ['path', { d: 'M7.2 17.8c1.6-2.2 6-2.2 7.6 0', fill: 'none', stroke: '#c85a00', strokeWidth: 1.4 }],
    ['path', { d: 'M5.4 7.4c1-1 2.6-1.4 3.8-1M12.8 6.4c1.2-.4 2.8 0 3.8 1', fill: 'none', stroke: '#c85a00', strokeWidth: 0.7 }],
    ['circle', { cx: 17.4, cy: 8.4, r: 3.8, fill: '#e7f4fb', stroke: '#000000', strokeWidth: 1.8, fillOpacity: 0.8 }],
    ['path', { d: 'M20.2 11.2 23 14', fill: 'none', stroke: '#000000', strokeWidth: 2.4 }],
  ],
  UploadRico: [
    ['rect', { x: 2, y: 2.5, width: 20, height: 19, rx: 0.8, fill: '#f4f6fa', stroke: '#202428', strokeWidth: 1 }],
    ['rect', { x: 2, y: 2.5, width: 20, height: 3.4, rx: 0.6, fill: '#00007f', stroke: '#00007f', strokeWidth: 0.5 }],
    ['rect', { x: 3, y: 7, width: 18, height: 9, rx: 0.3, fill: '#ffffff', stroke: 'none' }],
    ['path', { d: 'M13 8.6h7M13 11h7', fill: 'none', stroke: '#555a62', strokeWidth: 1.1 }],
    ['path', { d: 'M8 7.4 L5.6 10.6 L7.2 10.6 L7.2 12.6 L8.8 12.6 L8.8 10.6 L10.4 10.6Z', fill: '#101418', stroke: 'none' }],
    ['rect', { x: 4, y: 13.4, width: 9.6, height: 5.6, rx: 0.8, fill: '#aeb3ba', stroke: '#25292f', strokeWidth: 0.9 }],
    ['circle', { cx: 6, cy: 16.2, r: 0.8, fill: '#2fd45a', stroke: 'none' }],
    ['path', { d: 'M8.4 16.2h4', fill: 'none', stroke: '#6c717a', strokeWidth: 1 }],
  ],
  VencimientosRico: [
    ['path', { d: 'M4.8 11.4 L8.6 6.6 L14.4 6.6 L16.8 7.6 L21.6 7.6 L21.6 18.6 L4.8 18.6Z', fill: '#6f7378', stroke: '#14171a', strokeWidth: 0.9 }],
    ['path', { d: 'M9 6.6 L14.4 4.4 L20.8 8.4 L15.4 10.8Z', fill: '#f3f4f4', stroke: '#8e9298', strokeWidth: 0.7 }],
    ['path', { d: 'M4.8 11.4 L21.6 10.6 L21.6 19.6 L4.8 20.6Z', fill: '#262a30', stroke: '#0c0e11', strokeWidth: 0.9 }],
    ['path', { d: 'M4.8 11.4 L21.6 10.6 L21.6 13 L4.8 14Z', fill: '#5d6269', stroke: 'none', fillOpacity: 0.55 }],
  ],
  VendedorRico: [
    ['circle', { cx: 12, cy: 6.6, r: 4.4, fill: '#6a6a6a', stroke: '#4a4a4a', strokeWidth: 0.6 }],
    ['path', { d: 'M2.4 22v-6.4c0-2.2 1.6-3.8 3.8-4.4l4.4-1.2c.6.8 1 2.4 1.4 4.2.4-1.8.8-3.4 1.4-4.2l4.4 1.2c2.2.6 3.8 2.2 3.8 4.4V22Z', fill: '#6a6a6a', stroke: '#4a4a4a', strokeWidth: 0.6 }],
    ['path', { d: 'M9.4 9.8 L12 11.4 L14.6 9.8 L12 14.4Z', fill: '#f5f5f5', stroke: 'none' }],
    ['path', { d: 'M12 11.4 10.8 13.6l1.2 5.8 1.2-5.8Z', fill: '#f40000', stroke: 'none' }],
    ['path', { d: 'M10.4 10 L12 11.4 L13.6 10 L12 9.4Z', fill: '#e00000', stroke: 'none' }],
    ['rect', { x: 15.2, y: 16.4, width: 4, height: 1.2, rx: 0.4, fill: '#e8e8e8', stroke: 'none' }],
  ],
  StockValorizadoRico: [
    ['path', { d: 'M5 21.8 L9 20.8 L21.2 18.8 L21.4 20.6 L9.2 22.8 L5.2 23.4Z', fill: '#e9eaec', stroke: '#3a3d42', strokeWidth: 0.7 }],
    ['path', { d: 'M7.4 3.6 L19.4 2 L21.4 18.8 L9 20.8Z', fill: '#c79a5c', stroke: '#2b1a08', strokeWidth: 0.9 }],
    ['path', { d: 'M9.2 5 L18.2 3.8 L19.2 10 L10.2 11.4Z', fill: '#e0b97c', stroke: 'none', fillOpacity: 0.7 }],
    ['path', { d: 'M11.4 8.5 17 7.8M10.6 14.6l7.4-1.2', fill: 'none', stroke: '#b88442', strokeWidth: 0.5 }],
    ['path', { d: 'M3 5.4 L7.4 3.6 L9 20.8 L5 22 L3 20.6Z', fill: '#17181a', stroke: '#000000', strokeWidth: 0.8 }],
    ['path', { d: 'M5 6 6.6 5.3', fill: 'none', stroke: '#6a6c70', strokeWidth: 0.6 }],
  ],
  ToolsRico: [
    ['path', { d: 'M3 6.2h3.4v2.2H4.8v2h3.6l9.6 9.6-2.6 2.6L5.8 13c-.8-.6-1.4-1.4-1.6-2.4H3Z', fill: '#111111', stroke: '#000000', strokeWidth: 0.6 }],
    ['path', { d: 'M14.4 3.4 L19.6 2.4 L21.6 5.6 L17.2 8.6 L15 7.6Z', fill: '#e3d200', stroke: '#4a4400', strokeWidth: 0.8 }],
    ['path', { d: 'M14.4 3.4 L16 2 L18 1.8 L19.6 2.4Z', fill: '#7a7500', stroke: 'none' }],
    ['path', { d: 'M15.2 8.2 L17.6 9.2 L7.4 20.4 L5 19.4Z', fill: '#e8171d', stroke: '#6a0a0e', strokeWidth: 0.8 }],
    ['path', { d: 'M7.4 6.8 L9.4 5.8 L21.6 18 L19.6 20.4 L17.4 19.6Z', fill: '#b5b9bf', stroke: '#43474d', strokeWidth: 0.8 }],
    ['path', { d: 'M17.4 19.6 L19.6 20.4 L18.6 21.6Z', fill: '#e8171d', stroke: '#6a0a0e', strokeWidth: 0.7 }],
  ],
  TransferenciasRico: [
    ['path', { d: 'M2 8.4h10.4V3.2L22.4 12l-10 8.8v-5.4H2Z', fill: '#8c8c8c', stroke: '#1b1b1b', strokeWidth: 0.9 }],
    ['path', { d: 'M2.8 9.2h10.4V4.8L21 12h-8.6', fill: '#b5b5b5', stroke: 'none', fillOpacity: 0.7 }],
    ['path', { d: 'M2.8 12.2H12V15.6H2.8Z', fill: '#6b6b6b', stroke: 'none', fillOpacity: 0.6 }],
  ],
  RepPersonalRico: [
    ['path', { d: 'M11.4 14.4c1-2.2 2.6-3.2 4.4-3.2s3.6 1 4.6 3.2V18H11.4Z', fill: '#79b24a', stroke: '#3d6a22', strokeWidth: 0.9 }],
    ['circle', { cx: 15.8, cy: 5.4, r: 3, fill: '#ecc98a', stroke: '#8a5a2a', strokeWidth: 0.8 }],
    ['path', { d: 'M12.8 5.4c0-2.4 1.2-3.8 3-3.8s3 1.4 3 3.8c-.8-1.2-1.8-1.8-3-1.8s-2.2.6-3 1.8Z', fill: '#8a4a1a', stroke: 'none' }],
    ['path', { d: 'M1.4 22v-3.6c0-2.8 2.2-4.6 5-5.2l2-.4 2 .4c2.8.6 5 2.4 5 5.2V22Z', fill: '#4a8fe0', stroke: '#1c4c9a', strokeWidth: 0.9 }],
    ['circle', { cx: 8.5, cy: 8.4, r: 3.7, fill: '#ecc98a', stroke: '#8a5a2a', strokeWidth: 0.8 }],
    ['path', { d: 'M4.7 8.4c0-3.2 1.6-4.8 3.8-4.8s3.8 1.6 3.8 4.8c-1-1.8-2.4-2.6-3.8-2.6S5.7 6.6 4.7 8.4Z', fill: '#8a4a1a', stroke: 'none' }],
    ['path', { d: 'M6.6 16.6 L19.4 7.4 L22.2 10.4 L9.2 20.4Z', fill: '#ffa31a', stroke: '#9a5200', strokeWidth: 0.8 }],
    ['path', { d: 'M8.6 17.4 20.4 8.8M9.6 19 21.2 10.2', fill: 'none', stroke: '#ffd27a', strokeWidth: 0.7 }],
    ['path', { d: 'M6.6 16.6 L9.2 20.4 L4.2 22Z', fill: '#f3e0b8', stroke: '#6a4a20', strokeWidth: 0.7 }],
    ['path', { d: 'M4.9 20.6 L4.2 22 L5.9 21.6Z', fill: '#33241a', stroke: 'none' }],
    ['path', { d: 'M19.4 7.4 L21 5.8 L23.4 8.6 L22.2 10.4Z', fill: '#f08ab4', stroke: '#9a2a5a', strokeWidth: 0.8 }],
  ],
  RepReembolsoRico: [
    ['path', { d: 'M16.2 6.8H9.8a3.4 3.4 0 0 0 0 6.8h4.4a3.4 3.4 0 0 1 0 6.8H7.6', fill: 'none', stroke: '#d3d8dd', strokeWidth: 6.4 }],
    ['path', { d: 'M12 2.4v19.2', fill: 'none', stroke: '#d3d8dd', strokeWidth: 5.4 }],
    ['path', { d: 'M16.2 6.8H9.8a3.4 3.4 0 0 0 0 6.8h4.4a3.4 3.4 0 0 1 0 6.8H7.6', fill: 'none', stroke: '#ffffff', strokeWidth: 5 }],
    ['path', { d: 'M12 2.4v19.2', fill: 'none', stroke: '#ffffff', strokeWidth: 4 }],
    ['path', { d: 'M16.2 6.8H9.8a3.4 3.4 0 0 0 0 6.8h4.4a3.4 3.4 0 0 1 0 6.8H7.6', fill: 'none', stroke: '#7ab51d', strokeWidth: 3.2 }],
    ['path', { d: 'M12 2.4v19.2', fill: 'none', stroke: '#7ab51d', strokeWidth: 2.4 }],
    ['path', { d: 'M15.6 7.4H10', fill: 'none', stroke: '#b4dc5e', strokeWidth: 0.8 }],
  ],
  RepRegComprasRico: [
    ['path', { d: 'M3.4 4 8.6 9.6', fill: 'none', stroke: '#3b3b3b', strokeWidth: 2.4 }],
    ['path', { d: 'M3.4 4 8.6 9.6', fill: 'none', stroke: '#9a9a9a', strokeWidth: 0.6 }],
    ['path', { d: 'M20.6 4 15.4 9.6', fill: 'none', stroke: '#3b3b3b', strokeWidth: 2.4 }],
    ['path', { d: 'M20.6 4 15.4 9.6', fill: 'none', stroke: '#9a9a9a', strokeWidth: 0.6 }],
    ['path', { d: 'M3 11.6 L21 11.6 L18.8 21.6 L5.2 21.6Z', fill: '#c81c1c', stroke: '#6a0a0a', strokeWidth: 0.9 }],
    ['rect', { x: 1.6, y: 8.6, width: 20.8, height: 3.4, rx: 0.7, fill: '#dc2a2a', stroke: '#7a0d0d', strokeWidth: 0.9 }],
    ['path', { d: 'M7.4 13.8v5.4', fill: 'none', stroke: '#8a1010', strokeWidth: 1.4 }],
    ['path', { d: 'M9.8 13.8v5.4', fill: 'none', stroke: '#8a1010', strokeWidth: 1.4 }],
    ['path', { d: 'M12.2 13.8v5.4', fill: 'none', stroke: '#8a1010', strokeWidth: 1.4 }],
    ['path', { d: 'M14.6 13.8v5.4', fill: 'none', stroke: '#8a1010', strokeWidth: 1.4 }],
    ['path', { d: 'M17 13.8v5.4', fill: 'none', stroke: '#8a1010', strokeWidth: 1.4 }],
    ['path', { d: 'M2.6 9.6h18.8', fill: 'none', stroke: '#ff7a7a', strokeWidth: 0.5 }],
  ],
  RepTardanzasRico: [
    ['path', { d: 'M12 3.2 L21.6 20.6 L2.4 20.6Z', fill: '#0a4a8c', stroke: '#0a4a8c', strokeWidth: 2.2 }],
    ['path', { d: 'M12 9.4v5.4', fill: 'none', stroke: '#ffffff', strokeWidth: 2.3 }],
    ['rect', { x: 10.9, y: 16.6, width: 2.2, height: 2.2, rx: 0.3, fill: '#ffffff', stroke: 'none' }],
  ],
  ReportRico: [
    ['path', { d: 'M4.5 22h15', fill: 'none', stroke: '#9a9a9a', strokeWidth: 1.6 }],
    ['path', { d: 'M3.4 3.4h15v17.8h-15Z', fill: '#f4f4f4', stroke: '#000000', strokeWidth: 1.3 }],
    ['path', { d: 'M5.6 7h5', fill: 'none', stroke: '#555555', strokeWidth: 0.9 }],
    ['path', { d: 'M5.6 9.2h10', fill: 'none', stroke: '#555555', strokeWidth: 0.9 }],
    ['path', { d: 'M5.6 11.4h10', fill: 'none', stroke: '#555555', strokeWidth: 0.9 }],
    ['path', { d: 'M5.6 13.6h10', fill: 'none', stroke: '#555555', strokeWidth: 0.9 }],
    ['path', { d: 'M5.6 15.8h9', fill: 'none', stroke: '#555555', strokeWidth: 0.9 }],
    ['path', { d: 'M5.6 18h6', fill: 'none', stroke: '#555555', strokeWidth: 0.9 }],
    ['rect', { x: 14.4, y: 5.8, width: 1, height: 1, rx: 0, fill: '#e02020', stroke: 'none' }],
    ['path', { d: 'M18.4 3.4h1.6a1.8 1.8 0 0 1 1.8 1.8v4a1.8 1.8 0 0 1-1.8 1.8h-1.6', fill: '#c9c9c9', stroke: '#000000', strokeWidth: 1.2 }],
  ],
  ResumenGeneralRico: [
    ['rect', { x: 3.2, y: 2.4, width: 14, height: 17.6, rx: 0.8, fill: '#ffffff', stroke: '#000000', strokeWidth: 1.5 }],
    ['rect', { x: 5.8, y: 5, width: 15.4, height: 16.6, rx: 0.8, fill: '#ffffff', stroke: '#000000', strokeWidth: 1.7 }],
    ['path', { d: 'M9 10h8.4M9 13.2h8.4M9 16.4h5.2', fill: 'none', stroke: '#000000', strokeWidth: 1.7 }],
  ],
  ScdrespsRico: [
    ['rect', { x: 3, y: 5, width: 18, height: 16, rx: 0.3, fill: '#ffffff', stroke: '#808080', strokeWidth: 1.1 }],
    ['path', { d: 'M3 9.8h18M3 13.6h18M3 17.4h18M9 9.8v11M15 9.8v11', fill: 'none', stroke: '#a0a0a0', strokeWidth: 0.8 }],
    ['rect', { x: 3, y: 3.4, width: 15, height: 2.8, rx: 0, fill: '#0000dd', stroke: '#00006a', strokeWidth: 0.6 }],
    ['path', { d: 'M4.6 4.8h5', fill: 'none', stroke: '#ffffff', strokeWidth: 0.8 }],
    ['path', { d: 'M6 6.8 10.4 11.4 20.6 2.8', fill: 'none', stroke: '#0000e6', strokeWidth: 2.6 }],
  ],
  SemaforoRico: [
    ['rect', { x: 6.4, y: 2, width: 11.2, height: 20, rx: 3.2, fill: '#2e2e30', stroke: '#0a0a0a', strokeWidth: 1 }],
    ['path', { d: 'M6.4 5.6 L3.4 4.4 L3.4 8.4 L6.4 8.4Z', fill: '#202022', stroke: 'none' }],
    ['path', { d: 'M17.6 5.6 L20.6 4.4 L20.6 8.4 L17.6 8.4Z', fill: '#202022', stroke: 'none' }],
    ['path', { d: 'M6.4 10.8 L3.4 9.6 L3.4 13.8 L6.4 13.8Z', fill: '#202022', stroke: 'none' }],
    ['path', { d: 'M17.6 10.8 L20.6 9.6 L20.6 13.8 L17.6 13.8Z', fill: '#202022', stroke: 'none' }],
    ['path', { d: 'M6.4 16.2 L3.4 15 L3.4 19.2 L6.4 19.2Z', fill: '#202022', stroke: 'none' }],
    ['path', { d: 'M17.6 16.2 L20.6 15 L20.6 19.2 L17.6 19.2Z', fill: '#202022', stroke: 'none' }],
    ['circle', { cx: 12, cy: 6.8, r: 2.9, fill: '#d6341c', stroke: '#5a0e06', strokeWidth: 0.8 }],
    ['circle', { cx: 11.2, cy: 5.9, r: 1, fill: '#ff9a8a', stroke: 'none', fillOpacity: 0.8 }],
    ['circle', { cx: 12, cy: 12, r: 2.9, fill: '#e08c0a', stroke: '#5a3300', strokeWidth: 0.8 }],
    ['circle', { cx: 11.2, cy: 11.1, r: 1, fill: '#ffd27a', stroke: 'none', fillOpacity: 0.8 }],
    ['circle', { cx: 12, cy: 17.2, r: 2.9, fill: '#3ae82a', stroke: '#0e5a08', strokeWidth: 0.8 }],
    ['circle', { cx: 11.2, cy: 16.3, r: 1, fill: '#d8ffd0', stroke: 'none', fillOpacity: 0.8 }],
  ],
  SepararRico: [
    ['path', { d: 'M5 3.4A1.6 1.6 0 0 1 6.6 1.8h8.2l5.4 5.4v13.4a1.6 1.6 0 0 1-1.6 1.6H6.6A1.6 1.6 0 0 1 5 20.6Z', fill: '#f1f4f8', stroke: '#0b0b0b', strokeWidth: 1.5 }],
    ['path', { d: 'M14.8 1.8v4.4a1 1 0 0 0 1 1h4.4', fill: '#dfe5ee', stroke: '#0b0b0b', strokeWidth: 0.9 }],
    ['path', { d: 'M8 5.6h6.2M8 7.6h4.6', fill: 'none', stroke: '#222222', strokeWidth: 1.3 }],
    ['path', { d: 'M7.4 10.4h10.4M7.4 12h10.4M7.4 13.6h10.4M7.4 15.2h10.4M7.4 16.8h10.4M7.4 18.4h6', fill: 'none', stroke: '#7a808a', strokeWidth: 0.7 }],
    ['path', { d: 'M5.4 10.8h8.4V8l8.4 5.4-8.4 5.4V16H5.4Z', fill: '#3f74c0', stroke: '#0f2f66', strokeWidth: 0.9 }],
    ['path', { d: 'M5.8 11.2h8.4V9.2l6.2 4', fill: 'none', stroke: '#8db4ee', strokeWidth: 0.9 }],
  ],
  SepararAmbosRico: [
    ['path', { d: 'M5 3.4A1.6 1.6 0 0 1 6.6 1.8h8.2l5.4 5.4v13.4a1.6 1.6 0 0 1-1.6 1.6H6.6A1.6 1.6 0 0 1 5 20.6Z', fill: '#f1f4f8', stroke: '#0b0b0b', strokeWidth: 1.5 }],
    ['path', { d: 'M14.8 1.8v4.4a1 1 0 0 0 1 1h4.4', fill: '#dfe5ee', stroke: '#0b0b0b', strokeWidth: 0.9 }],
    ['path', { d: 'M8 5.6h6.2M8 7.6h4.6', fill: 'none', stroke: '#222222', strokeWidth: 1.3 }],
    ['path', { d: 'M7.4 10.4h10.4M7.4 12h10.4M7.4 13.6h10.4M7.4 15.2h10.4M7.4 16.8h10.4M7.4 18.4h6', fill: 'none', stroke: '#7a808a', strokeWidth: 0.7 }],
    ['path', { d: 'M1.2 13.2 L5.4 9.4 L5.4 11.6 L11.2 11.6 L11.2 14.8 L5.4 14.8 L5.4 17Z', fill: '#66b82a', stroke: '#2c6a0e', strokeWidth: 0.9 }],
    ['path', { d: 'M22.8 13.2 L18.6 9.8 L18.6 11.8 L12.8 11.8 L12.8 14.6 L18.6 14.6 L18.6 16.6Z', fill: '#66b82a', stroke: '#2c6a0e', strokeWidth: 0.9 }],
  ],
  SesionIconRico: [
    ['path', { d: 'M12.8 14c1.2-1.4 3-2.2 5-2.2 3.2 0 5.2 1.8 5.2 4.6v3.2h-8', fill: '#f4a10a', stroke: '#1a1000', strokeWidth: 1 }],
    ['circle', { cx: 17.8, cy: 6.6, r: 3.4, fill: '#ffc61a', stroke: '#1a1000', strokeWidth: 1 }],
    ['circle', { cx: 16.8, cy: 5.4, r: 1.3, fill: '#ffffff', stroke: 'none', fillOpacity: 0.5 }],
    ['path', { d: 'M1.2 22v-3.4c0-3.2 3-5.6 7.4-5.6s7.4 2.4 7.4 5.6V22Z', fill: '#58c01c', stroke: '#0a2a00', strokeWidth: 1.1 }],
    ['circle', { cx: 8.6, cy: 7.2, r: 4.6, fill: '#6fd02a', stroke: '#0a2a00', strokeWidth: 1.1 }],
    ['ellipse', { cx: 7, cy: 5.2, rx: 2.2, ry: 1.4, fill: '#ffffff', stroke: 'none', fillOpacity: 0.45 }],
  ],
  SobregiroRico: [
    ['rect', { x: 3.5, y: 2, width: 17, height: 15.4, rx: 2, fill: '#000000', stroke: 'none' }],
    ['path', { d: 'M9.4 2 L14.6 2 L14.6 9.6 L12 7.4 L9.4 9.6Z', fill: '#ffffff', stroke: 'none' }],
    ['path', { d: 'M3.5 19.2h17v1.4a1.8 1.8 0 0 1-1.8 1.8H5.3a1.8 1.8 0 0 1-1.8-1.8Z', fill: '#000000', stroke: 'none' }],
    ['path', { d: 'M3.5 18.3h17', fill: 'none', stroke: '#ffffff', strokeWidth: 0.8 }],
  ],
  SolGastosRico: [
    ['path', { d: 'M3.4 4.6 L13.4 2 L16 8 L5.6 10.6Z', fill: '#9ccb86', stroke: '#4a7a36', strokeWidth: 0.8 }],
    ['path', { d: 'M7 6 L17.2 3.2 L19.4 9.4 L9.2 12Z', fill: '#b4d99e', stroke: '#4a7a36', strokeWidth: 0.8 }],
    ['path', { d: 'M10.4 7.2 15 6', fill: 'none', stroke: '#6a9a56', strokeWidth: 0.7 }],
    ['circle', { cx: 13.2, cy: 8.2, r: 1.4, fill: '#8fc37a', stroke: '#4a7a36', strokeWidth: 0.5 }],
    ['rect', { x: 1.6, y: 9.4, width: 20.8, height: 11.8, rx: 2.6, fill: '#c98e4c', stroke: '#5a3410', strokeWidth: 1 }],
    ['rect', { x: 2.6, y: 10.4, width: 18.8, height: 9.8, rx: 2, fill: 'none', stroke: '#f2d9aa', strokeWidth: 0.6 }],
    ['rect', { x: 15.8, y: 10.8, width: 6.6, height: 8.8, rx: 2.4, fill: '#d9a05c', stroke: '#5a3410', strokeWidth: 0.9 }],
    ['circle', { cx: 18.2, cy: 15.2, r: 1.1, fill: '#f4f4f4', stroke: '#555555', strokeWidth: 0.5 }],
    ['path', { d: 'M4 12.4h9', fill: 'none', stroke: '#f2d9aa', strokeWidth: 0.5 }],
  ],
  SolicGarantiaRico: [
    ['path', { d: 'M5.2 3.6A1.6 1.6 0 0 1 6.8 2h8.6l5 5v13.4a1.6 1.6 0 0 1-1.6 1.6H6.8a1.6 1.6 0 0 1-1.6-1.6Z', fill: '#f6f8fb', stroke: '#1f2328', strokeWidth: 1.2 }],
    ['path', { d: 'M15.4 2v3.8a1.2 1.2 0 0 0 1.2 1.2h3.8', fill: '#dfe5ee', stroke: '#1f2328', strokeWidth: 0.9 }],
    ['path', { d: 'M8 6.4h5.6M8 8.2h3.8', fill: 'none', stroke: '#3a3f46', strokeWidth: 1.4 }],
    ['path', { d: 'M8 11h9.8M8 12.6h9.8M8 14.2h9.8M8 15.8h9.8M8 17.4h6', fill: 'none', stroke: '#8a9098', strokeWidth: 0.7 }],
  ],
  ReordenarRico: [
    ['rect', { x: 4.8, y: 2.6, width: 15.4, height: 8.6, rx: 0.4, fill: '#d6d6d6', stroke: '#000000', strokeWidth: 1.6 }],
    ['path', { d: 'M10.4 5.4l1.9-1.2V9M10.4 9h3.6', fill: 'none', stroke: '#000000', strokeWidth: 1.3 }],
    ['rect', { x: 4.8, y: 11.6, width: 15.4, height: 9.8, rx: 0.4, fill: '#d6d6d6', stroke: '#000000', strokeWidth: 1.6 }],
    ['circle', { cx: 12.4, cy: 15, r: 1.8, fill: 'none', stroke: '#000000', strokeWidth: 1.3 }],
    ['path', { d: 'M14.2 15.2v1.6c0 1.3-1 2.2-2.4 2.2', fill: 'none', stroke: '#000000', strokeWidth: 1.3 }],
    ['path', { d: 'M21.4 4v17', fill: 'none', stroke: '#bdbdbd', strokeWidth: 1 }],
  ],
  RepAsistenciaRico: [
    ['ellipse', { cx: 12, cy: 12, rx: 9.2, ry: 10.4, fill: 'none', stroke: '#101010', strokeWidth: 1.2 }],
    ['ellipse', { cx: 12, cy: 12.6, rx: 7.2, ry: 8.6, fill: 'none', stroke: '#101010', strokeWidth: 1.3 }],
    ['ellipse', { cx: 12, cy: 13, rx: 5.4, ry: 6.8, fill: 'none', stroke: '#101010', strokeWidth: 1.3 }],
    ['ellipse', { cx: 12, cy: 13.4, rx: 3.6, ry: 4.9, fill: 'none', stroke: '#101010', strokeWidth: 1.4 }],
    ['ellipse', { cx: 12, cy: 13.6, rx: 1.8, ry: 3, fill: '#000000', stroke: '#000000', strokeWidth: 0.8 }],
    ['path', { d: 'M4 8.4c1.4-3 4.4-5 8-5', fill: 'none', stroke: '#ffffff', strokeWidth: 1.6 }],
  ],
  ComisionIcoRico: [
    ['path', { d: 'M8 7.4C4 9.6 1.6 13 1.6 16.6c0 3.2 2.6 5.2 6.2 5.2h8.4c3.6 0 6.2-2 6.2-5.2 0-3.6-2.4-7-6.4-9.2Z', fill: '#303234', stroke: 'none' }],
    ['path', { d: 'M7.2 3.4c.2-1 1-1 1.4-.4l1.3 1.6L11.2 2h1.6l1.3 2.6 1.3-1.6c.4-.6 1.2-.6 1.4.4l-.6 3c-1 .8-2.4 1.2-4 1.2s-3-.4-4-1.2Z', fill: '#303234', stroke: 'none' }],
    ['path', { d: 'M7.6 7.3c2.7 1.5 5.9 1.5 8.8 0', fill: 'none', stroke: '#ffffff', strokeWidth: 1.1 }],
    ['path', { d: 'M14.3 13.4h-3.6a1.7 1.7 0 0 0 0 3.4h2.8a1.7 1.7 0 0 1 0 3.4H9.8', fill: 'none', stroke: '#ffffff', strokeWidth: 1.5 }],
    ['path', { d: 'M12 11.8v9.6', fill: 'none', stroke: '#ffffff', strokeWidth: 1.2 }],
  ],
  Separar: [
    ['path', { d: 'M8 4H2.5M2.5 4 5 1.5M2.5 4 5 6.5' }],
    ['path', { d: 'M16 4h5.5m0 0L19 1.5M21.5 4 19 6.5' }],
    ['path', { d: 'M2 9h9v4.3a2.2 2.2 0 0 1 0 4.5V20H2Z', f: 'P' }],
    ['path', { d: 'M11 10h11v11H11v-3.3a2.2 2.2 0 0 0 0-4.5Z', f: 'T' }],
  ],
  RegistroResumen: [
    ['rect', { x: 9, y: 2.5, width: 11, height: 15, rx: 1.5, f: 'T' }],
    ['rect', { x: 6.5, y: 5, width: 11, height: 15, rx: 1.5, f: 'T' }],
    ['path', { d: 'M12 9h2.5M12 12h2.5M12 15h2.5' }],
    ['path', { d: 'M2 12.5A1.5 1.5 0 0 1 3.5 11H7l1.6 1.6H13a1.5 1.5 0 0 1 1.5 1.5v6.4A1.5 1.5 0 0 1 13 22H3.5A1.5 1.5 0 0 1 2 20.5Z', f: 'P' }],
  ],
  Registro: [
    ['rect', { x: 4, y: 2, width: 16, height: 19, rx: 2, f: 'P' }],
    ['rect', { x: 6.5, y: 4.5, width: 11, height: 5.5, rx: 0.8 }],
    ['path', { d: 'M10 7.2h4' }],
    ['path', { d: 'M7.5 15 8.8 9.8 17.8 11.6 17 15Z', f: 'T' }],
    ['rect', { x: 5, y: 15, width: 14, height: 7, rx: 1, f: 'S' }],
    ['path', { d: 'M10 18.5h4' }],
  ],
  PendienteFacturacion: [
    ['path', { d: 'M7 2.5h7l5 5V19a1.5 1.5 0 0 1-1.5 1.5H7A1.5 1.5 0 0 1 5.5 19V4A1.5 1.5 0 0 1 7 2.5Z', f: 'P' }],
    ['path', { d: 'M14 2.5V7a.5.5 0 0 0 .5.5H19' }],
    ['path', { d: 'M10.5 10h5M10.5 13h5' }],
    ['path', { d: 'M2 15.5v5c0 .8 1.8 1.5 4 1.5s4-.7 4-1.5v-5Z', f: 'S' }],
    ['ellipse', { cx: 6, cy: 15.5, rx: 4, ry: 1.5, f: 'T' }],
    ['path', { d: 'M2 18.2c0 .8 1.8 1.5 4 1.5s4-.7 4-1.5' }],
    ['path', { d: 'M11 19v2.5c0 .6 1.3 1 3 1s3-.4 3-1V19Z', f: 'S' }],
    ['ellipse', { cx: 14, cy: 19, rx: 3, ry: 1.1, f: 'T' }],
  ],
  ReclamoGarantia: [
    ['path', { d: 'M8 15.5 5 22l3.6-1.4L10.8 22l1.2-6.5Z', f: 'S' }],
    ['path', { d: 'M16 15.5 19 22l-3.6-1.4L13.2 22 12 15.5Z', f: 'S' }],
    ['circle', { cx: 12, cy: 10, r: 8, f: 'P' }],
    ['circle', { cx: 12, cy: 10, r: 5, f: 'T' }],
    ['path', { d: 'M10.6 8.4 12.4 7v6' }],
  ],
  ValeRequisicion: [
    ['path', { d: 'M7 2.5h10A2.5 2.5 0 0 1 19.5 5v10.5L14 21.5H7A2.5 2.5 0 0 1 4.5 19V5A2.5 2.5 0 0 1 7 2.5Z', f: 'P' }],
    ['path', { d: 'M19.5 15.5h-3.2a2.3 2.3 0 0 0-2.3 2.3v3.7' }],
    ['path', { d: 'M8 7h8M8 10h8M8 13h8M8 16h4', k: 'S' }],
  ],
  RegistroAuxiliar: [
    ['rect', { x: 6, y: 2.5, width: 13, height: 11, rx: 1.5, f: 'T' }],
    ['path', { d: 'M9 3v10M12 3v10' }],
    ['path', { d: 'M14.5 7h2.5' }],
    ['rect', { x: 2.5, y: 12, width: 19, height: 9.5, rx: 1.8, f: 'P' }],
    ['rect', { x: 9.5, y: 15.5, width: 5, height: 2.4, rx: 0.6, f: 'S' }],
  ],
  PrecioCore: [
    ['rect', { x: 6, y: 3.5, width: 16, height: 10, rx: 1.5, f: 'T' }],
    ['rect', { x: 4.5, y: 6, width: 16, height: 10, rx: 1.5, f: 'T' }],
    ['path', { d: 'M3 18.5h16v1a1.5 1.5 0 0 1-1.5 1.5h-13A1.5 1.5 0 0 1 3 19.5Z', f: 'T' }],
    ['rect', { x: 3, y: 8.5, width: 16, height: 10, rx: 1.5, f: 'P' }],
    ['circle', { cx: 9.5, cy: 13.5, r: 2.3, f: 'T' }],
    ['path', { d: 'M9.5 12.4v2.2', k: 'T' }],
    ['rect', { x: 13.5, y: 8.5, width: 3.5, height: 10, f: 'S' }],
  ],
  ChevronsDown: [
    ['path', { d: 'm7 6 5 5 5-5M7 13l5 5 5-5', k: 'P' }]
  ],
  ChevronsUp: [
    ['path', { d: 'm17 11-5-5-5 5M17 18l-5-5-5 5', k: 'P' }]
  ],
  ChevronsLeft: [
    ['path', { d: 'm11 17-5-5 5-5M18 17l-5-5 5-5', k: 'P' }]
  ],
  ChevronsRight: [
    ['path', { d: 'm6 17 5-5-5-5M13 17l5-5-5-5', k: 'P' }]
  ],
  ChevronRightToLine: [
    ['path', { d: 'm5 7 6 5-6 5M18 5v14', k: 'P' }]
  ],
  Info: [
    ['circle', { cx: 12, cy: 12, r: 10, f: 'P' }],
    ['path', { d: 'M12 16v-4M12 8h.01', k: 'aP' }]
  ],
  CircleCheck: [
    ['circle', { cx: 12, cy: 12, r: 10, f: 'P' }],
    ['path', { d: 'm9 12 2 2 4-4', k: 'aP' }]
  ],
  CircleX: [
    ['circle', { cx: 12, cy: 12, r: 10, f: 'P' }],
    ['path', { d: 'm15 9-6 6M9 9l6 6', k: 'aP' }]
  ],
  CirclePlus: [
    ['circle', { cx: 12, cy: 12, r: 10, f: 'P' }],
    ['path', { d: 'M8 12h8M12 8v8', k: 'aP' }]
  ],
  Ban: [
    ['circle', { cx: 12, cy: 12, r: 10, f: 'P' }],
    ['path', { d: 'm4.9 4.9 14.2 14.2', k: 'aP' }]
  ],
  Check: [
    ['path', { d: 'M20 6 9 17l-5-5', k: 'P' }]
  ],
  CheckCheck: [
    ['path', { d: 'M18 6 7 17l-5-5M22 10l-7.5 7.5L13 16', k: 'P' }]
  ],
  X: [
    ['path', { d: 'M18 6 6 18M6 6l12 12', k: 'P' }]
  ],
  Square: [
    ['rect', { x: 3, y: 3, width: 18, height: 18, rx: 3, f: 'P' }]
  ],
  SquareCheck: [
    ['rect', { x: 3, y: 3, width: 18, height: 18, rx: 3, f: 'P' }],
    ['path', { d: 'm9 12 2 2 4-4', k: 'aP' }]
  ],
  Undo: [
    ['path', { d: 'M9 14 4 9l5-5', k: 'P' }],
    ['path', { d: 'M4 9h10.5a5.5 5.5 0 0 1 5.5 5.5 5.5 5.5 0 0 1-5.5 5.5H11', k: 'P' }]
  ],
  Refresh: [
    ['path', { d: 'M3 12a9 9 0 0 1 9-9 9.75 9.75 0 0 1 6.74 2.74L21 8M21 3v5h-5M21 12a9 9 0 0 1-9 9 9.75 9.75 0 0 1-6.74-2.74L3 16M8 16H3v5', k: 'P' }]
  ],
  RotateCw: [
    ['path', { d: 'M21 12a9 9 0 1 1-9-9c2.52 0 4.93 1 6.74 2.74L21 8M21 3v5h-5', k: 'P' }]
  ],
  RotateCcw: [
    ['path', { d: 'M3 12a9 9 0 1 0 9-9 9.75 9.75 0 0 0-6.74 2.74L3 8M3 3v5h5', k: 'P' }]
  ],
  CircleArrow: [
    ['path', { d: 'M21 12a9 9 0 1 1-9-9c2.52 0 4.93 1 6.74 2.74L21 8M21 3v5h-5', k: 'P' }],
    ['circle', { cx: 12, cy: 12, r: 1.5, k: 'P' }]
  ],
  ArrowLeftRight: [
    ['path', { d: 'M8 3 4 7l4 4M4 7h16M16 21l4-4-4-4M20 17H4', k: 'P' }]
  ],
  AtSign: [
    ['circle', { cx: 12, cy: 12, r: 4, f: 'P' }],
    ['path', { d: 'M16 8v5a3 3 0 0 0 6 0v-1a10 10 0 1 0-4 8' }]
  ],
  MailUp: [
    ['rect', { x: 2, y: 5, width: 20, height: 15, rx: 2, f: 'P' }],
    ['path', { d: 'm22 8-8.97 5.2a2 2 0 0 1-2.06 0L2 8', k: 'aP' }],
    ['path', { d: 'M12 3v5M10 5l2-2 2 2', k: 'S' }]
  ],
  ThumbsUp: [
    ['path', { d: 'M7 10v12', k: 'aP' }],
    ['path', { d: 'M15 5.88 14 10h5.83a2 2 0 0 1 1.92 2.56l-2.33 8A2 2 0 0 1 17.5 22H4a2 2 0 0 1-2-2v-8a2 2 0 0 1 2-2h2.76a2 2 0 0 0 1.79-1.11L12 2a3.13 3.13 0 0 1 3 3.88Z', f: 'P' }]
  ],
  ThumbsDown: [
    ['path', { d: 'M7 10v12', transform: 'translate(0 24) scale(1 -1)', k: 'aP' }],
    ['path', { d: 'M15 5.88 14 10h5.83a2 2 0 0 1 1.92 2.56l-2.33 8A2 2 0 0 1 17.5 22H4a2 2 0 0 1-2-2v-8a2 2 0 0 1 2-2h2.76a2 2 0 0 0 1.79-1.11L12 2a3.13 3.13 0 0 1 3 3.88Z', transform: 'translate(0 24) scale(1 -1)', f: 'P' }]
  ],
  PlayCircle: [
    ['circle', { cx: 12, cy: 12, r: 10, f: 'P' }],
    ['path', { d: 'm10 8 6 4-6 4z', f: 'S' }]
  ],
  HelpSquare: [
    ['rect', { x: 3, y: 3, width: 18, height: 18, rx: 4, f: 'P' }],
    ['path', { d: 'M9.1 9a3 3 0 0 1 5.82 1c0 2-3 3-3 3M12 17h.01', k: 'S' }]
  ],
  DocBol: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', k: 'aP' }],
    ['path', { d: 'M0 0V5H2L3 4V3L2 2.5L3 2V1L2 0ZM0 2.5H2', transform: 'translate(6.1 9.5) scale(1)', strokeWidth: 1.4, k: 'aP' }],
    ['path', { d: 'M0 0H3V5H0Z', transform: 'translate(10.5 9.5) scale(1)', strokeWidth: 1.4, k: 'aP' }],
    ['path', { d: 'M0 0V5H3', transform: 'translate(14.9 9.5) scale(1)', strokeWidth: 1.4, k: 'aP' }],
    ['path', { d: 'M8 17h8', k: 'aP' }]
  ],
  DocFac: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', k: 'aP' }],
    ['path', { d: 'M3 0H0V5M0 2.5H2', transform: 'translate(6.1 9.5) scale(1)', strokeWidth: 1.4, k: 'aP' }],
    ['path', { d: 'M0 5V1.5L1.5 0L3 1.5V5M0 3H3', transform: 'translate(10.5 9.5) scale(1)', strokeWidth: 1.4, k: 'aP' }],
    ['path', { d: 'M3 0H0V5H3', transform: 'translate(14.9 9.5) scale(1)', strokeWidth: 1.4, k: 'aP' }],
    ['path', { d: 'M8 17h8', k: 'aP' }]
  ],
  DocFG: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', k: 'aP' }],
    ['path', { d: 'M3 0H0V5M0 2.5H2', transform: 'translate(6.1 9.5) scale(1)', strokeWidth: 1.4, k: 'aP' }],
    ['path', { d: 'M3 0L0 5', transform: 'translate(10.5 9.5) scale(1)', strokeWidth: 1.4, k: 'aP' }],
    ['path', { d: 'M3 0H0V5H3V2.5H1.5', transform: 'translate(14.9 9.5) scale(1)', strokeWidth: 1.4, k: 'aP' }],
    ['path', { d: 'M8 17h8', k: 'aP' }]
  ],
  DocGD: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', k: 'aP' }],
    ['path', { d: 'M3 0H0V5H3V2.5H1.5', transform: 'translate(6.1 9.5) scale(1)', strokeWidth: 1.4, k: 'aP' }],
    ['path', { d: 'M3 0L0 5', transform: 'translate(10.5 9.5) scale(1)', strokeWidth: 1.4, k: 'aP' }],
    ['path', { d: 'M0 0V5H2L3 4V1L2 0Z', transform: 'translate(14.9 9.5) scale(1)', strokeWidth: 1.4, k: 'aP' }],
    ['path', { d: 'M8 17h8', k: 'aP' }]
  ],
  DocGR: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', k: 'aP' }],
    ['path', { d: 'M3 0H0V5H3V2.5H1.5', transform: 'translate(6.1 9.5) scale(1)', strokeWidth: 1.4, k: 'aP' }],
    ['path', { d: 'M3 0L0 5', transform: 'translate(10.5 9.5) scale(1)', strokeWidth: 1.4, k: 'aP' }],
    ['path', { d: 'M0 5V0H2L3 1V1.5L2 2.5H0M2 2.5L3 5', transform: 'translate(14.9 9.5) scale(1)', strokeWidth: 1.4, k: 'aP' }],
    ['path', { d: 'M8 17h8', k: 'aP' }]
  ],
  DocNot: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', k: 'aP' }],
    ['path', { d: 'M0 5V0L3 5V0', transform: 'translate(6.1 9.5) scale(1)', strokeWidth: 1.4, k: 'aP' }],
    ['path', { d: 'M0 0H3V5H0Z', transform: 'translate(10.5 9.5) scale(1)', strokeWidth: 1.4, k: 'aP' }],
    ['path', { d: 'M0 0H3M1.5 0V5', transform: 'translate(14.9 9.5) scale(1)', strokeWidth: 1.4, k: 'aP' }],
    ['path', { d: 'M8 17h8', k: 'aP' }]
  ],
  DocC: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', k: 'aP' }],
    ['path', { d: 'M3 0H0V5H3', transform: 'translate(8.2 11) scale(1.4)', strokeWidth: 1.6, k: 'aP' }]
  ],
  DocDollar: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', k: 'aP' }],
    ['path', { d: 'M12 9v9M14.5 10.5h-3a1.5 1.5 0 0 0 0 3h1a1.5 1.5 0 0 1 0 3H9.5', k: 'aP' }]
  ],
  DocSend: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', k: 'aP' }],
    ['path', { d: 'M8 13h8M8 17h8M8 9h2', k: 'aP' }],
    ['path', { d: 'M1 11h2M1 15h2M1 19h2' }]
  ],
  DocDown: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', k: 'aP' }],
    ['path', { d: 'M12 11v6M9 14.5l3 3 3-3', k: 'S' }]
  ],
  DocGlobe: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', transform: 'scale(.78)', k: 'aP' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'M13.5 18h9M18 13.5c-2 2.4-2 6.6 0 9M18 13.5c2 2.4 2 6.6 0 9', k: 'W' }]
  ],
  DocSign: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', k: 'aP' }],
    ['path', { d: 'M8 12h4M8 16h2', k: 'aP' }],
    ['path', { d: 'm14 21 1-3 5-5 2 2-5 5z', f: 'S', k: 'S' }]
  ],
  DocStack: [
    ['path', { d: 'M3 18V4a2 2 0 0 1 2-2h12' }],
    ['rect', { x: 6, y: 5, width: 15, height: 17, rx: 2, f: 'P' }],
    ['rect', { x: 9, y: 8, width: 5, height: 4, rx: 0, f: 'S' }],
    ['path', { d: 'M16 9h2M16 12h2M9 16h9', k: 'aP' }]
  ],
  FileX: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', k: 'aP' }],
    ['path', { d: 'm9.5 12.5 5 5M14.5 12.5l-5 5', k: 'S' }]
  ],
  FilePen: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', k: 'aP' }],
    ['path', { d: 'M8 11h4M8 15h2', k: 'aP' }],
    ['path', { d: 'm14 21 1-3 5-5 2 2-5 5z', f: 'S' }]
  ],
  FilesPlus: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', transform: 'scale(.78)', k: 'aP' }],
    ['path', { d: 'M8 13h8M8 17h8M8 9h2', transform: 'scale(.78)', k: 'aP' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'M18 15.5v5M15.5 18h5', k: 'W' }]
  ],
  Certificate: [
    ['rect', { x: 3, y: 2, width: 14, height: 17, rx: 1.5, f: 'P' }],
    ['path', { d: 'M6.5 6h7M6.5 9h7', k: 'aP' }],
    ['circle', { cx: 10, cy: 13, r: 2, f: 'S' }],
    ['path', { d: 'm14 22 1-3 6-6 2 2-6 6z', f: 'S' }]
  ],
  Copy: [
    ['rect', { x: 8, y: 8, width: 14, height: 14, rx: 2, f: 'P' }],
    ['path', { d: 'M4 16c-1.1 0-2-.9-2-2V4c0-1.1.9-2 2-2h10c1.1 0 2 .9 2 2' }]
  ],
  InvDown: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', transform: 'scale(.78)', k: 'aP' }],
    ['path', { d: 'M8 10h4', transform: 'scale(.78)', k: 'aP' }],
    ['rect', { x: 8, y: 13, width: 8, height: 5, rx: 1, transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M12 13v5', transform: 'scale(.78)', k: 'aP' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'M18 15.5v5M16 18.5l2 2 2-2', k: 'W' }]
  ],
  InvX: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', transform: 'scale(.78)', k: 'aP' }],
    ['path', { d: 'M8 10h4', transform: 'scale(.78)', k: 'aP' }],
    ['rect', { x: 8, y: 13, width: 8, height: 5, rx: 1, transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M12 13v5', transform: 'scale(.78)', k: 'aP' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'm16 16 4 4M20 16l-4 4', k: 'W' }]
  ],
  InvOk: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', transform: 'scale(.78)', k: 'aP' }],
    ['path', { d: 'M8 10h4', transform: 'scale(.78)', k: 'aP' }],
    ['rect', { x: 8, y: 13, width: 8, height: 5, rx: 1, transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M12 13v5', transform: 'scale(.78)', k: 'aP' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'm15.6 18.2 1.7 1.7 3.1-3.5', k: 'W' }]
  ],
  InvSearch: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', transform: 'scale(.78)', k: 'aP' }],
    ['path', { d: 'M8 10h4', transform: 'scale(.78)', k: 'aP' }],
    ['rect', { x: 8, y: 13, width: 8, height: 5, rx: 1, transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M12 13v5', transform: 'scale(.78)', k: 'aP' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['circle', { cx: 17.5, cy: 17.5, r: 2, k: 'W' }],
    ['path', { d: 'm19 19 1.8 1.8', k: 'W' }]
  ],
  Excel: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', k: 'aP' }],
    ['path', { d: 'm8.5 11 5 7M13.5 11l-5 7', k: 'aP' }]
  ],
  ExcelDown: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', transform: 'scale(.78)', k: 'aP' }],
    ['path', { d: 'm8.5 11 5 7M13.5 11l-5 7', transform: 'scale(.78)', k: 'aP' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'M18 15.5v5M16 18.5l2 2 2-2', k: 'W' }]
  ],
  ExcelUp: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', transform: 'scale(.78)', k: 'aP' }],
    ['path', { d: 'm8.5 11 5 7M13.5 11l-5 7', transform: 'scale(.78)', k: 'aP' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'M18 20.5v-5M16 17.5l2-2 2 2', k: 'W' }]
  ],
  ExcelPercent: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', k: 'aP' }],
    ['path', { d: 'M15 9l-6 9', k: 'S' }],
    ['circle', { cx: 9.5, cy: 10, r: 0.8, k: 'S' }],
    ['circle', { cx: 14.5, cy: 17, r: 0.8, k: 'S' }]
  ],
  ExcelPercentDown: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', transform: 'scale(.78)', k: 'aP' }],
    ['path', { d: 'M12.5 7 7 15', k: 'aP' }],
    ['circle', { cx: 7.5, cy: 8, r: 0.7, k: 'aP' }],
    ['circle', { cx: 12, cy: 14.5, r: 0.7, k: 'aP' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'M18 15.5v5M16 18.5l2 2 2-2', k: 'W' }]
  ],
  ExcelCoinsDown: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', transform: 'scale(.78)', k: 'aP' }],
    ['path', { d: 'M10 8v7M12 9.5H9a1.2 1.2 0 0 0 0 2.4h1.6a1.2 1.2 0 0 1 0 2.4H8', k: 'aP' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'M18 15.5v5M16 18.5l2 2 2-2', k: 'W' }]
  ],
  ExcelCoinsUp: [
    ['path', { d: 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z', transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M14 2v4a2 2 0 0 0 2 2h4', transform: 'scale(.78)', k: 'aP' }],
    ['path', { d: 'M10 8v7M12 9.5H9a1.2 1.2 0 0 0 0 2.4h1.6a1.2 1.2 0 0 1 0 2.4H8', k: 'aP' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'M18 20.5v-5M16 17.5l2-2 2 2', k: 'W' }]
  ],
  FolderPlus: [
    ['path', { d: 'M20 20a2 2 0 0 0 2-2V8a2 2 0 0 0-2-2h-7.9a2 2 0 0 1-1.69-.9L9.6 3.9A2 2 0 0 0 7.93 3H4a2 2 0 0 0-2 2v13a2 2 0 0 0 2 2Z', f: 'P' }],
    ['path', { d: 'M12 10v6M9 13h6', k: 'S' }]
  ],
  FolderPen: [
    ['path', { d: 'M20 20a2 2 0 0 0 2-2V8a2 2 0 0 0-2-2h-7.9a2 2 0 0 1-1.69-.9L9.6 3.9A2 2 0 0 0 7.93 3H4a2 2 0 0 0-2 2v13a2 2 0 0 0 2 2Z', transform: 'scale(.78)', f: 'P' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'm15.6 20.4 5-5M19 14l2.5 2.5M15.6 20.4l.3-1.9', k: 'W' }]
  ],
  FolderStar: [
    ['path', { d: 'M20 20a2 2 0 0 0 2-2V8a2 2 0 0 0-2-2h-7.9a2 2 0 0 1-1.69-.9L9.6 3.9A2 2 0 0 0 7.93 3H4a2 2 0 0 0-2 2v13a2 2 0 0 0 2 2Z', f: 'P' }],
    ['path', { d: 'm12 9.5 1.1 2.2 2.4.35-1.75 1.7.4 2.4L12 15l-2.15 1.15.4-2.4-1.75-1.7 2.4-.35z', f: 'S' }]
  ],
  FolderOpen: [
    ['path', { d: 'm6 14 1.5-2.9A2 2 0 0 1 9.24 10H20a2 2 0 0 1 1.94 2.5l-1.54 6a2 2 0 0 1-1.95 1.5H4a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2h3.9a2 2 0 0 1 1.69.9l.81 1.2a2 2 0 0 0 1.67.9H18a2 2 0 0 1 2 2v2', f: 'P' }]
  ],
  Calendar: [
    ['rect', { x: 3, y: 4, width: 18, height: 18, rx: 2, f: 'P' }],
    ['path', { d: 'M3 6a2 2 0 0 1 2-2h14a2 2 0 0 1 2 2v4H3Z', f: 'S' }],
    ['path', { d: 'M16 2v4M8 2v4' }],
    ['path', { d: 'M8 14h.01M12 14h.01M16 14h.01M8 18h.01M12 18h.01' }],
    ['path', { d: 'M8 14h.01M12 14h.01M16 14h.01M8 18h.01M12 18h.01' }]
  ],
  CalendarCheck: [
    ['rect', { x: 3, y: 4, width: 18, height: 18, rx: 2, f: 'P' }],
    ['path', { d: 'M3 6a2 2 0 0 1 2-2h14a2 2 0 0 1 2 2v4H3Z', f: 'S' }],
    ['path', { d: 'M16 2v4M8 2v4' }],
    ['path', { d: 'm9 16 2 2 4-4' }]
  ],
  CalendarClock: [
    ['rect', { x: 3, y: 4, width: 18, height: 18, rx: 2, transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M3 6a2 2 0 0 1 2-2h14a2 2 0 0 1 2 2v4H3Z', transform: 'scale(.78)', f: 'S' }],
    ['path', { d: 'M16 2v4M8 2v4', transform: 'scale(.78)' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'M18 15.3V18l1.8 1', k: 'W' }]
  ],
  CalendarPen: [
    ['rect', { x: 3, y: 4, width: 18, height: 18, rx: 2, transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M3 6a2 2 0 0 1 2-2h14a2 2 0 0 1 2 2v4H3Z', transform: 'scale(.78)', f: 'S' }],
    ['path', { d: 'M16 2v4M8 2v4', transform: 'scale(.78)' }],
    ['path', { d: 'M8 14h.01M12 14h.01', transform: 'scale(.78)' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'm15.6 20.4 5-5M19 14l2.5 2.5M15.6 20.4l.3-1.9', k: 'W' }]
  ],
  CalendarCopy: [
    ['rect', { x: 8, y: 8, width: 14, height: 14, rx: 2, f: 'P' }],
    ['path', { d: 'M4 16a2 2 0 0 1-2-2V4a2 2 0 0 1 2-2h10a2 2 0 0 1 2 2M8 13h14' }]
  ],
  CalendarDigits: [
    ['rect', { x: 3, y: 4, width: 18, height: 18, rx: 2, f: 'P' }],
    ['path', { d: 'M3 6a2 2 0 0 1 2-2h14a2 2 0 0 1 2 2v4H3Z', f: 'S' }],
    ['path', { d: 'M16 2v4M8 2v4', k: 'S' }],
    ['path', { d: 'M.4 1.2L1.6 0V5', transform: 'translate(8.2 13.2) scale(1)', strokeWidth: 1.5, k: 'S' }],
    ['path', { d: 'M0 1L1 0H2L3 1V2L0 5H3', transform: 'translate(12.6 13.2) scale(1)', strokeWidth: 1.5 }]
  ],
  Clock: [
    ['circle', { cx: 12, cy: 12, r: 10, f: 'P' }],
    ['path', { d: 'M12 6v6l4 2', k: 'aP' }]
  ],
  Watch: [
    ['circle', { cx: 12, cy: 12, r: 10, f: 'P' }],
    ['path', { d: 'M12 2v1.5M12 20.5V22M2 12h1.5M20.5 12H22M12 7v5l3 2', k: 'aP' }]
  ],
  Wristwatch: [
    ['circle', { cx: 12, cy: 12, r: 6, f: 'P' }],
    ['path', { d: 'M12 9v3l1.5 1M16.13 7.66l-.81-4.05a2 2 0 0 0-2-1.61h-2.68a2 2 0 0 0-2 1.61l-.78 4.05M7.88 16.36l.8 4a2 2 0 0 0 2 1.61h2.72a2 2 0 0 0 2-1.61l.81-4.05' }]
  ],
  Stopwatch: [
    ['path', { d: 'M10 2h4M12 14l3-3' }],
    ['circle', { cx: 12, cy: 14, r: 8, f: 'P' }]
  ],
  Alarm: [
    ['path', { d: 'M12 7v5l3 2M5 3 2 6M22 6l-3-3M6 19l-2 2M18 19l2 2' }],
    ['circle', { cx: 12, cy: 13, r: 8, f: 'P' }]
  ],
  AlarmPlus: [
    ['circle', { cx: 12, cy: 13, r: 8, transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M12 9v4l2 2M5 3 2 6M22 6l-3-3M6 19l-2 2M18 19l2 2', transform: 'scale(.78)' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'M18 15.5v5M15.5 18h5', k: 'W' }]
  ],
  ClockGear: [
    ['circle', { cx: 12, cy: 12, r: 10, transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M12 6v6l4 2', transform: 'scale(.78)', k: 'aP' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['circle', { cx: 18, cy: 18, r: 1.8, k: 'W' }],
    ['path', { d: 'M18 14.5v1.2M18 20.3v1.2M14.5 18h1.2M20.3 18h1.2', k: 'W' }]
  ],
  ClockSpark: [
    ['path', { d: 'M21 12a9 9 0 1 1-9-9', k: 'P' }],
    ['path', { d: 'M12 7v5l3 2M19 2v4M17 4h4', k: 'P' }]
  ],
  WindowClock: [
    ['rect', { x: 2, y: 3, width: 20, height: 16, rx: 2, transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M2 8h20M6 12h5M6 15h4', transform: 'scale(.78)', k: 'aP' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'M18 15.3V18l1.8 1', k: 'W' }]
  ],
  Canjear: [
    ['rect', { x: 2, y: 2, width: 10, height: 10, rx: 1.5, f: 'P' }],
    ['path', { d: 'M7 5v2.5l1.5 1', k: 'aP' }],
    ['path', { d: 'M15 5h2.5a2 2 0 0 1 2 2v2.5M17 8l2.5 2.5L22 8' }],
    ['rect', { x: 12, y: 14, width: 9, height: 8, rx: 1.5, f: 'P' }]
  ],
  Dollar: [
    ['path', { d: 'M12 2v20M17 5H9.5a3.5 3.5 0 0 0 0 7h5a3.5 3.5 0 0 1 0 7H6', k: 'P' }]
  ],
  Percent: [
    ['path', { d: 'M19 5 5 19', k: 'P' }],
    ['circle', { cx: 6.5, cy: 6.5, r: 2.5, f: 'P' }],
    ['circle', { cx: 17.5, cy: 17.5, r: 2.5, f: 'P' }]
  ],
  PercentDown: [
    ['path', { d: 'M19 5 5 19', transform: 'scale(.78)', k: 'P' }],
    ['circle', { cx: 6.5, cy: 6.5, r: 2.5, transform: 'scale(.78)', f: 'P' }],
    ['circle', { cx: 17.5, cy: 17.5, r: 2.5, transform: 'scale(.78)', f: 'P' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'M18 15.5v5M16 18.5l2 2 2-2', k: 'W' }]
  ],
  PercentPlus: [
    ['path', { d: 'M19 5 5 19', transform: 'scale(.78)', k: 'P' }],
    ['circle', { cx: 6.5, cy: 6.5, r: 2.5, transform: 'scale(.78)', f: 'P' }],
    ['circle', { cx: 17.5, cy: 17.5, r: 2.5, transform: 'scale(.78)', f: 'P' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'M18 15.5v5M15.5 18h5', k: 'W' }]
  ],
  MoneyBag: [
    ['path', { d: 'M9 3h6l-1.5 3h-3z' }],
    ['path', { d: 'M10.5 6C6 8.5 4 12 4 16a5 5 0 0 0 5 5h6a5 5 0 0 0 5-5c0-4-2-7.5-6.5-10', f: 'P' }],
    ['path', { d: 'M14 12.5h-2.2a1.5 1.5 0 0 0 0 3h.4a1.5 1.5 0 0 1 0 3H10M12 11v1.5M12 18.5V20' }]
  ],
  MoneyBagCoin: [
    ['path', { d: 'M9 3h6l-1.5 3h-3z', transform: 'scale(.78)' }],
    ['path', { d: 'M10.5 6C6 8.5 4 12 4 16a5 5 0 0 0 5 5h6a5 5 0 0 0 5-5c0-4-2-7.5-6.5-10', transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M14 12.5h-2.2a1.5 1.5 0 0 0 0 3h.4a1.5 1.5 0 0 1 0 3H10M12 11v1.5M12 18.5V20', transform: 'scale(.78)' }],
    ['circle', { cx: 18, cy: 18, r: 3.5, f: 'P' }],
    ['path', { d: 'M18 16.5v3', k: 'aP' }]
  ],
  Coins: [
    ['path', { d: 'M5 6v12c0 1.1 3.1 2 7 2s7-.9 7-2V6Z', f: 'P' }],
    ['path', { d: 'M5 6c0 1.1 3.1 2 7 2s7-.9 7-2-3.1-2-7-2-7 .9-7 2z', f: 'S' }],
    ['path', { d: 'M5 10c0 1.1 3.1 2 7 2s7-.9 7-2' }],
    ['path', { d: 'M5 14c0 1.1 3.1 2 7 2s7-.9 7-2' }]
  ],
  CoinsPlus: [
    ['path', { d: 'M5 6v12c0 1.1 3.1 2 7 2s7-.9 7-2V6Z', transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M5 6c0 1.1 3.1 2 7 2s7-.9 7-2-3.1-2-7-2-7 .9-7 2z', transform: 'scale(.78)', f: 'S' }],
    ['path', { d: 'M5 10c0 1.1 3.1 2 7 2s7-.9 7-2', transform: 'scale(.78)' }],
    ['path', { d: 'M5 14c0 1.1 3.1 2 7 2s7-.9 7-2', transform: 'scale(.78)' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'M18 15.5v5M15.5 18h5', k: 'W' }]
  ],
  Banknotes: [
    ['rect', { x: 2, y: 7, width: 17, height: 11, rx: 2, f: 'P' }],
    ['circle', { cx: 10.5, cy: 12.5, r: 2.2, f: 'S' }],
    ['path', { d: 'M5 5h15a2 2 0 0 1 2 2v9' }]
  ],
  BanknoteBundle: [
    ['rect', { x: 2, y: 8, width: 18, height: 12, rx: 1.5, f: 'P' }],
    ['path', { d: 'M5 5h15a2 2 0 0 1 2 2v9' }],
    ['rect', { x: 8, y: 8, width: 5, height: 12, rx: 0, f: 'S' }],
    ['circle', { cx: 10.5, cy: 14, r: 1, k: 'aP' }]
  ],
  Wallet: [
    ['rect', { x: 3, y: 5, width: 18, height: 15, rx: 2, f: 'P' }],
    ['path', { d: 'M3 9h14' }],
    ['rect', { x: 15, y: 12, width: 6, height: 4, rx: 1.5, f: 'S' }]
  ],
  WalletCoin: [
    ['rect', { x: 3, y: 5, width: 18, height: 15, rx: 2, transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M3 9h14', transform: 'scale(.78)' }],
    ['rect', { x: 15, y: 12, width: 6, height: 4, rx: 1.5, transform: 'scale(.78)', f: 'S' }],
    ['circle', { cx: 18, cy: 18, r: 4, f: 'S' }],
    ['path', { d: 'M18 16.2v3.6', k: 'aS' }]
  ],
  Cards: [
    ['path', { d: 'M5 7V6a2 2 0 0 1 2-2h13a2 2 0 0 1 2 2v8a2 2 0 0 1-2 2h-1', f: 'S' }],
    ['rect', { x: 2, y: 8, width: 17, height: 12, rx: 2, f: 'P' }],
    ['path', { d: 'M2 12.5h17M5 17h3', k: 'aP' }]
  ],
  CardCoins: [
    ['rect', { x: 2, y: 5, width: 20, height: 14, rx: 2, transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M2 10h20', transform: 'scale(.78)', k: 'aP' }],
    ['circle', { cx: 17, cy: 18, r: 3.5, f: 'S' }],
    ['path', { d: 'M17 16.3v3.4', k: 'aS' }]
  ],
  Calculator: [
    ['rect', { x: 4, y: 2, width: 16, height: 20, rx: 2, f: 'P' }],
    ['path', { d: 'M8 6h8M8 10h.01M12 10h.01M16 10h.01M8 14h.01M12 14h.01M16 14h.01M8 18h.01M12 18h.01M16 18h.01', k: 'aP' }]
  ],
  CalcRefresh: [
    ['rect', { x: 4, y: 2, width: 16, height: 20, rx: 2, transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M8 6h8M8 10h.01M12 10h.01M16 10h.01M8 14h.01M12 14h.01M16 14h.01M8 18h.01M12 18h.01M16 18h.01', transform: 'scale(.78)', k: 'aP' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'M20.3 17.6a2.5 2.5 0 0 0-4.4-.6M15.7 18.4a2.5 2.5 0 0 0 4.4.6M20.4 15.6v2h-2M15.6 20.4v-2h2', k: 'W' }]
  ],
  CalcRound: [
    ['rect', { x: 2, y: 2, width: 20, height: 20, rx: 4, f: 'P' }],
    ['path', { d: 'M8 6.5v3M6.5 8h3M14.5 8h3M14.5 14.5l3 3M17.5 14.5l-3 3M6.5 15.5h3M6.5 17.5h3', k: 'aP' }]
  ],
  CashRegister: [
    ['path', { d: 'M8 8V2h8v6' }],
    ['path', { d: 'M4 8h16l2 8v4a1 1 0 0 1-1 1H3a1 1 0 0 1-1-1v-4z', f: 'P' }],
    ['path', { d: 'M7 12h.01M11 12h.01M15 12h.01M7 16h.01M11 16h.01M15 16h3', k: 'aP' }]
  ],
  Safe: [
    ['rect', { x: 3, y: 3, width: 18, height: 17, rx: 2, f: 'P' }],
    ['circle', { cx: 11.5, cy: 11.5, r: 4, f: 'S' }],
    ['circle', { cx: 11.5, cy: 11.5, r: 1, k: 'aP' }],
    ['path', { d: 'M7 20v2M17 20v2M21 8h1M21 14h1' }]
  ],
  PiggyBank: [
    ['path', { d: 'M19 5c-1.5 0-2.8 1.4-3 2-3.5-1.5-11-.3-11 5 0 1.8 0 3 2 4.5V20h4v-2h3v2h4v-4c1-.5 1.7-1 2-2h2v-4h-2c0-1-.5-1.5-1-2V5z', f: 'P' }],
    ['path', { d: 'M2 9.5a2 2 0 0 0 2 2M16 11h.01' }]
  ],
  HandCoins: [
    ['path', { d: 'M11 15h2a2 2 0 1 0 0-4h-3c-.6 0-1.1.2-1.4.6L3 17' }],
    ['path', { d: 'm7 21 1.6-1.4c.3-.4.8-.6 1.4-.6h4c1.1 0 2.1-.4 2.8-1.2l4.6-4.4a2 2 0 0 0-2.75-2.91l-4.2 3.9' }],
    ['path', { d: 'm2 16 6 6' }],
    ['circle', { cx: 16, cy: 9, r: 2.9, f: 'P' }],
    ['path', { d: 'M16 5.1v.2' }]
  ],
  HandBanknote: [
    ['path', { d: 'M9 20l1-1c.3-.3.6-.4 1-.4h3c.8 0 1.5-.3 2-.8l4.5-4.5a1.8 1.8 0 0 0-2.5-2.5L15 13.500' }],
    ['path', { d: 'm3 15 5 5' }],
    ['rect', { x: 11, y: 3, width: 10, height: 6, rx: 1, f: 'P' }],
    ['circle', { cx: 16, cy: 6, r: 1.2, k: 'aP' }]
  ],
  HandHelping: [
    ['path', { d: 'M11 12h2a2 2 0 1 0 0-4h-3c-.6 0-1.1.2-1.4.6L3 14', k: 'P' }],
    ['path', { d: 'm7 18 1.6-1.4c.3-.4.8-.6 1.4-.6h4c1.1 0 2.1-.4 2.8-1.2l4.6-4.4a2 2 0 0 0-2.75-2.91l-4.2 3.9', k: 'P' }],
    ['path', { d: 'm2 13 6 6', k: 'P' }]
  ],
  Scale: [
    ['path', { d: 'm16 16 3-8 3 8c-.87.65-1.92 1-3 1s-2.13-.35-3-1Z', f: 'P' }],
    ['path', { d: 'm2 16 3-8 3 8c-.87.65-1.92 1-3 1s-2.13-.35-3-1Z', f: 'P' }],
    ['path', { d: 'M7 21h10M12 3v18M3 7h2c2 0 5-1 7-2 2 1 5 2 7 2h2' }]
  ],
  Luggage: [
    ['rect', { x: 3, y: 7, width: 18, height: 14, rx: 2, f: 'P' }],
    ['path', { d: 'M8 7V5a2 2 0 0 1 2-2h4a2 2 0 0 1 2 2v2M8 7v14M16 7v14', k: 'aP' }],
    ['circle', { cx: 19, cy: 10, r: 1, k: 'aP' }]
  ],
  UserTie: [
    ['circle', { cx: 12, cy: 7, r: 4, f: 'P' }],
    ['path', { d: 'M5 21v-2a4 4 0 0 1 4-4h6a4 4 0 0 1 4 4v2M12 15l-1.2 1.8L12 21l1.2-3.2z', f: 'P', k: 'S' }]
  ],
  UserSilhouette: [
    ['rect', { x: 2, y: 2, width: 20, height: 20, rx: 2, f: 'P' }],
    ['circle', { cx: 12, cy: 9, r: 3.5, f: 'S' }],
    ['path', { d: 'M5 22c.5-4 3.5-6 7-6s6.5 2 7 6', k: 'S' }]
  ],
  UserBriefcase: [
    ['circle', { cx: 9, cy: 6, r: 3.5, f: 'S' }],
    ['path', { d: 'M2 20v-2a4 4 0 0 1 4-4h4' }],
    ['rect', { x: 12, y: 13, width: 10, height: 8, rx: 1.5, f: 'P' }],
    ['path', { d: 'M15 13v-1.5h4V13' }]
  ],
  UserChecklist: [
    ['circle', { cx: 8, cy: 6, r: 3, f: 'S' }],
    ['path', { d: 'M2 20v-1.5a4 4 0 0 1 4-4h4' }],
    ['rect', { x: 13, y: 10, width: 9, height: 12, rx: 1.5, f: 'P' }],
    ['path', { d: 'M15.5 14h4M15.5 17h4', k: 'aP' }]
  ],
  UsersHardHat: [
    ['path', { d: 'M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2' }],
    ['circle', { cx: 9, cy: 7, r: 4, f: 'P' }],
    ['path', { d: 'M22 21v-2a4 4 0 0 0-3-3.87M16 3.13a4 4 0 0 1 0 7.75' }],
    ['path', { d: 'M5.5 5.200a3.500 3.500 0 0 1 7 0M3.500 5.500h11' }]
  ],
  Family: [
    ['circle', { cx: 7, cy: 6, r: 3, f: 'P' }],
    ['circle', { cx: 17, cy: 6, r: 3, f: 'P' }],
    ['path', { d: 'M1 19v-1.5A3.5 3.5 0 0 1 4.5 14h2M23 19v-1.5a3.5 3.5 0 0 0-3.5-3.5h-2' }],
    ['circle', { cx: 12, cy: 14, r: 2.2, f: 'S' }],
    ['path', { d: 'M8.5 21v-1.5a3.5 3.5 0 0 1 7 0V21' }]
  ],
  PersonKey: [
    ['circle', { cx: 8, cy: 5, r: 2.5, f: 'P' }],
    ['path', { d: 'M8 8v7l-3 6M8 15l3 6M5 11l3-2 2.5 2' }],
    ['circle', { cx: 17, cy: 8, r: 3, f: 'P' }],
    ['path', { d: 'm19 10 3 3M20.5 11.5l1.5-1.5' }]
  ],
  Fingerprint: [
    ['path', { d: 'M2 12a10 10 0 0 1 18-6M5 19.500c.5-1.500 1-4 1-7.500a6 6 0 0 1 11.500-2.500M10 22c.5-2 1-5 1-9a1 1 0 0 1 2 0c0 3 .5 6.500 1.500 8.500', k: 'P' }]
  ],
  FingerprintDevice: [
    ['rect', { x: 3, y: 2, width: 18, height: 20, rx: 2, f: 'P' }],
    ['rect', { x: 6, y: 5, width: 12, height: 7, rx: 1, f: 'S' }],
    ['path', { d: 'M7 16h.01M10 16h.01M13 16h.01M7 19h.01M10 19h.01M13 19h.01', k: 'aP' }],
    ['rect', { x: 16, y: 15, width: 3, height: 5, rx: 1.5, k: 'aP' }]
  ],
  Truck: [
    ['path', { d: 'M2 6a2 2 0 0 1 2-2h8a2 2 0 0 1 2 2v12H3a1 1 0 0 1-1-1Z', f: 'P' }],
    ['path', { d: 'M14 8h3.52a1 1 0 0 1 .78.38l3.48 4.35a1 1 0 0 1 .22.62V17a1 1 0 0 1-1 1H14Z', f: 'S' }],
    ['circle', { cx: 7, cy: 18, r: 2, f: 'W' }],
    ['circle', { cx: 17, cy: 18, r: 2, f: 'W' }]
  ],
  Car: [
    ['path', { d: 'M19 17h2c.6 0 1-.4 1-1v-3c0-.9-.7-1.7-1.5-1.9C18.7 10.6 16 10 16 10s-1.3-1.4-2.2-2.3c-.5-.4-1.1-.7-1.8-.7H5c-.6 0-1.1.4-1.4.9l-1.4 2.9A3.7 3.7 0 0 0 2 12v4c0 .6.4 1 1 1h2', f: 'P' }],
    ['circle', { cx: 7, cy: 17, r: 2, f: 'P' }],
    ['path', { d: 'M9 17h6' }],
    ['circle', { cx: 17, cy: 17, r: 2, f: 'P' }]
  ],
  Plane: [
    ['path', { d: 'M17.8 19.2 16 11l3.5-3.5C21 6 21.5 4 21 3c-1-.5-3 0-4.5 1.5L13 8 4.8 6.2c-.5-.1-.9.1-1.1.5l-.3.5c-.2.5-.1 1 .3 1.3L9 12l-2 3H4l-1 1 3 2 2 3 1-1v-3l3-2 3.5 5.3c.3.4.8.5 1.3.3l.5-.2c.4-.3.6-.7.5-1.2z', f: 'P' }]
  ],
  House: [
    ['path', { d: 'M5 10.5 12 4.5l7 6V20a1 1 0 0 1-1 1H6a1 1 0 0 1-1-1Z', f: 'P' }],
    ['path', { d: 'M2 11.5 12 3l10 8.5-1.4 1.6L12 5.8 3.4 13.1Z', f: 'S' }],
    ['path', { d: 'M10 21v-6h4v6Z', f: 'T' }],
    ['rect', { x: 16, y: 3, width: 2.4, height: 4, f: 'P' }]
  ],
  Building: [
    ['path', { d: 'M6 22V4a2 2 0 0 1 2-2h8a2 2 0 0 1 2 2v18Z', f: 'P' }],
    ['path', { d: 'M6 12H4a2 2 0 0 0-2 2v6a2 2 0 0 0 2 2h2M18 9h2a2 2 0 0 1 2 2v9a2 2 0 0 1-2 2h-2M10 6h4M10 10h4M10 14h4M10 18h4' }]
  ],
  Boots: [
    ['path', { d: 'M6 3h6v8c0 1.5 1.2 2.5 3 3l3.5 1.5A2.5 2.5 0 0 1 20 18v2H6z', f: 'P' }],
    ['path', { d: 'M6 17h14', k: 'aP' }]
  ],
  DoorExit: [
    ['path', { d: 'M10 3H6a2 2 0 0 0-2 2v14a2 2 0 0 0 2 2h4M17 8l-4 4 4 4M13 12h8', k: 'P' }]
  ],
  DoorArrowIn: [
    ['path', { d: 'M14 3h4a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2h-4M3 12h11M10 8l4 4-4 4', k: 'P' }]
  ],
  Network: [
    ['rect', { x: 16, y: 16, width: 6, height: 6, rx: 1, f: 'P' }],
    ['rect', { x: 2, y: 16, width: 6, height: 6, rx: 1, f: 'P' }],
    ['rect', { x: 9, y: 2, width: 6, height: 6, rx: 1, f: 'S' }],
    ['path', { d: 'M5 16v-3a1 1 0 0 1 1-1h12a1 1 0 0 1 1 1v3M12 12V8' }]
  ],
  Footprints: [
    ['path', { d: 'M4 16v-2.38C4 11.5 2.97 10.5 3 8c.03-2.72 1.49-6 4.5-6C9.37 2 10 3.8 10 5.5c0 3.11-2 5.66-2 8.68V16a2 2 0 1 1-4 0Z', f: 'P' }],
    ['path', { d: 'M20 20v-2.38c0-2.12 1.03-3.12 1-5.62-.03-2.72-1.49-6-4.5-6C14.63 6 14 7.8 14 9.5c0 3.11 2 5.66 2 8.68V20a2 2 0 1 0 4 0Z', f: 'P' }],
    ['path', { d: 'M16 17h4M4 13h4' }]
  ],
  Flag: [
    ['path', { d: 'M4 15s1-1 4-1 5 2 8 2 4-1 4-1V3s-1 1-4 1-5-2-8-2-4 1-4 1z', f: 'P' }],
    ['path', { d: 'M4 22v-7' }]
  ],
  ChristmasTree: [
    ['path', { d: 'm12 3-5 6h3l-5 6h4l-3 5h12l-3-5h4l-5-6h3z', f: 'P' }],
    ['path', { d: 'M12 20v2' }]
  ],
  Wreath: [
    ['circle', { cx: 12, cy: 11, r: 7.5, f: 'P' }],
    ['circle', { cx: 12, cy: 11, r: 4, f: 'W' }],
    ['path', { d: 'M12 18.5 8.5 22.5M12 18.5l3.5 4', k: 'S' }]
  ],
  Book: [
    ['path', { d: 'M4 19.5v-15A2.5 2.5 0 0 1 6.5 2H19a1 1 0 0 1 1 1v18a1 1 0 0 1-1 1H6.5a1 1 0 0 1 0-5H20', f: 'P' }]
  ],
  BookBookmark: [
    ['path', { d: 'M10 2v8l3-3 3 3V2', f: 'S' }],
    ['path', { d: 'M4 19.5v-15A2.5 2.5 0 0 1 6.5 2H19a1 1 0 0 1 1 1v18a1 1 0 0 1-1 1H6.5a1 1 0 0 1 0-5H20', f: 'P' }]
  ],
  BookOpen: [
    ['path', { d: 'M12 7v14', k: 'aP' }],
    ['path', { d: 'M3 18a1 1 0 0 1-1-1V4a1 1 0 0 1 1-1h5a4 4 0 0 1 4 4 4 4 0 0 1 4-4h5a1 1 0 0 1 1 1v13a1 1 0 0 1-1 1h-6a3 3 0 0 0-3 3 3 3 0 0 0-3-3z', f: 'P' }],
    ['path', { d: 'M5 8h3M5 12h3M16 8h3M16 12h3', k: 'aP' }]
  ],
  BookHelp: [
    ['path', { d: 'M4 19.5v-15A2.5 2.5 0 0 1 6.5 2H19a1 1 0 0 1 1 1v18a1 1 0 0 1-1 1H6.5a1 1 0 0 1 0-5H20', f: 'P' }],
    ['path', { d: 'M9.5 8a2.5 2.5 0 0 1 5 .5c0 1.5-2.500 2-2.500 3.500M12 15h.01' }]
  ],
  BookInfo: [
    ['path', { d: 'M4 19.5v-15A2.5 2.5 0 0 1 6.5 2H19a1 1 0 0 1 1 1v18a1 1 0 0 1-1 1H6.5a1 1 0 0 1 0-5H20', f: 'P' }],
    ['path', { d: 'M13 8h.01M13 11v4' }]
  ],
  BookUp: [
    ['path', { d: 'M4 19.5v-15A2.5 2.5 0 0 1 6.5 2H19a1 1 0 0 1 1 1v18a1 1 0 0 1-1 1H6.5a1 1 0 0 1 0-5H20', f: 'P' }],
    ['path', { d: 'M9.500 12 13 8.500l3.500 3.500M13 8.500V15' }]
  ],
  Books: [
    ['rect', { x: 5, y: 2, width: 15, height: 7, rx: 1, f: 'P' }],
    ['path', { d: 'M9 2v7', k: 'aP' }],
    ['rect', { x: 3, y: 9, width: 16, height: 6, rx: 1, f: 'S' }],
    ['path', { d: 'M7 9v6', k: 'aP' }],
    ['rect', { x: 5, y: 15, width: 15, height: 7, rx: 1, f: 'P' }],
    ['path', { d: 'M9 15v7', k: 'aP' }]
  ],
  Notebook: [
    ['rect', { x: 4, y: 2, width: 16, height: 20, rx: 2, f: 'P' }],
    ['path', { d: 'M2 6h4M2 10h4M2 14h4M2 18h4M10 7h6M10 11h6' }]
  ],
  NotebookClock: [
    ['rect', { x: 4, y: 2, width: 16, height: 20, rx: 2, transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M2 6h4M2 10h4M2 14h4M2 18h4M10 7h6M10 11h6', transform: 'scale(.78)' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'M18 15.3V18l1.8 1', k: 'W' }]
  ],
  NotebookPlus: [
    ['rect', { x: 4, y: 2, width: 16, height: 20, rx: 2, transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M2 6h4M2 10h4M2 14h4M2 18h4M10 7h6M10 11h6', transform: 'scale(.78)' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'M18 15.5v5M15.5 18h5', k: 'W' }]
  ],
  NotebookSpiral: [
    ['rect', { x: 5, y: 2, width: 16, height: 20, rx: 2, f: 'P' }],
    ['path', { d: 'M2 6h5M2 10h5M2 14h5M2 18h5' }]
  ],
  NotebookPen: [
    ['rect', { x: 3, y: 3, width: 15, height: 19, rx: 2, f: 'P' }],
    ['path', { d: 'M7 3v19', k: 'aP' }],
    ['path', { d: 'm13 17 8-8 2 2-8 8-3 1z', f: 'S' }]
  ],
  NotepadPen: [
    ['rect', { x: 4, y: 3, width: 14, height: 18, rx: 2, f: 'P' }],
    ['path', { d: 'M8 8h6M8 12h4M8 16h2', k: 'aP' }],
    ['path', { d: 'm14 20 1-3 6-6 2 2-6 6z', f: 'S' }]
  ],
  Album: [
    ['rect', { x: 3, y: 2, width: 18, height: 20, rx: 2, f: 'P' }],
    ['path', { d: 'M12 2v20M6 6h3v4H6zM15 6h3v4h-3zM6 14h3v4H6zM15 14h3v4h-3z', f: 'P' }]
  ],
  Clipboard: [
    ['rect', { x: 8, y: 2, width: 8, height: 4, rx: 1, f: 'S' }],
    ['path', { d: 'M16 4h2a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2H6a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2h2', f: 'P' }]
  ],
  ClipboardList: [
    ['rect', { x: 8, y: 2, width: 8, height: 4, rx: 1, f: 'S' }],
    ['path', { d: 'M16 4h2a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2H6a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2h2', f: 'P' }],
    ['path', { d: 'M9 12h.01M13 12h3M9 16h.01M13 16h3' }]
  ],
  ClipboardCheckPen: [
    ['rect', { x: 8, y: 2, width: 8, height: 4, rx: 1, f: 'S' }],
    ['path', { d: 'M16 4h2a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2H6a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2h2', f: 'P' }],
    ['path', { d: 'm9 14 2 2 4-4' }]
  ],
  ListOrdered: [
    ['path', { d: 'M10 6h11M10 12h11M10 18h11M4 5l1-1v5M4 14.5a1.500 1.500 0 1 1 2.500 1L4 18h3', k: 'P' }]
  ],
  Briefcase: [
    ['rect', { x: 2, y: 7, width: 20, height: 14, rx: 2, f: 'P' }],
    ['path', { d: 'M16 21V5a2 2 0 0 0-2-2h-4a2 2 0 0 0-2 2v16' }]
  ],
  Portfolio: [
    ['rect', { x: 2, y: 7, width: 20, height: 14, rx: 2, f: 'P' }],
    ['path', { d: 'M8 7V5a2 2 0 0 1 2-2h4a2 2 0 0 1 2 2v2M2 13h20M10 13v2h4v-2', k: 'aP' }]
  ],
  Stamp: [
    ['path', { d: 'M5 22h14' }],
    ['path', { d: 'M19.27 13.73A2.5 2.5 0 0 0 17.5 13h-11A2.5 2.5 0 0 0 4 15.5V17a1 1 0 0 0 1 1h14a1 1 0 0 0 1-1v-1.5c0-.66-.26-1.3-.73-1.77Z', f: 'P' }],
    ['path', { d: 'M14 13V8.5C14 7 15 7 15 5a3 3 0 0 0-3-3c-1.66 0-3 1-3 3s1 2 1 3.5V13' }]
  ],
  Pencil: [
    ['path', { d: 'M21.17 6.81a1 1 0 0 0-3.99-3.99L3.84 16.17a2 2 0 0 0-.5.83l-1.32 4.35a.5.5 0 0 0 .62.62l4.35-1.32a2 2 0 0 0 .83-.5z', f: 'P' }],
    ['path', { d: 'm15 5 4 4', k: 'aP' }]
  ],
  Chalkboard: [
    ['rect', { x: 3, y: 3, width: 18, height: 12, rx: 1, f: 'P' }],
    ['path', { d: 'M7 19l1.5-4M17 19l-1.5-4M12 15v6M7 8l2 3M11 7v4M15 8h2' }]
  ],
  GradBubble: [
    ['path', { d: 'M21 15a2 2 0 0 1-2 2H7l-4 4V5a2 2 0 0 1 2-2h14a2 2 0 0 1 2 2z', f: 'P' }],
    ['path', { d: 'm12 6.500-5.500 2.500L12 11.500l5.500-2.500zM8.500 11v2.500c0 .8 1.500 1.500 3.500 1.500s3.500-.7 3.500-1.500V11', k: 'aP' }]
  ],
  CardFile: [
    ['path', { d: 'M2 13h20v7a1 1 0 0 1-1 1H3a1 1 0 0 1-1-1z', f: 'P' }],
    ['path', { d: 'M6 13V3h9l3 3v7M9 7h6M9 10h6M9 17h6' }]
  ],
  CardFileStand: [
    ['path', { d: 'M2 13h20v7a1 1 0 0 1-1 1H3a1 1 0 0 1-1-1z', f: 'P' }],
    ['path', { d: 'M7 13V3h9l3 3v7M10 7h6M10 10h6M10 17h6M3 3v6' }]
  ],
  CardFilePen: [
    ['path', { d: 'M2 13h20v7a1 1 0 0 1-1 1H3a1 1 0 0 1-1-1z', f: 'P' }],
    ['path', { d: 'M8 13V6h8l2 2v5M11 9h4M11 17h6' }],
    ['path', { d: 'm4 9 4-5 2 1.500-4 5z', f: 'S' }]
  ],
  Printer: [
    ['path', { d: 'M6 18H4a2 2 0 0 1-2-2v-5a2 2 0 0 1 2-2h16a2 2 0 0 1 2 2v5a2 2 0 0 1-2 2h-2' }],
    ['path', { d: 'M6 9V3a1 1 0 0 1 1-1h10a1 1 0 0 1 1 1v6' }],
    ['rect', { x: 6, y: 14, width: 12, height: 8, rx: 1, f: 'P' }]
  ],
  Laptop: [
    ['rect', { x: 4, y: 5, width: 16, height: 11, rx: 2, f: 'P' }],
    ['path', { d: 'M2.7 17.5h18.6a.7.7 0 0 1 .65 1l-.6 1.3a1.4 1.4 0 0 1-1.3.8H3.95a1.4 1.4 0 0 1-1.3-.8l-.6-1.3a.7.7 0 0 1 .65-1Z', f: 'S' }]
  ],
  Monitor: [
    ['rect', { x: 2, y: 3, width: 20, height: 14, rx: 2, f: 'P' }],
    ['path', { d: 'M8 21h8M12 17v4' }]
  ],
  Smartphone: [
    ['rect', { x: 5, y: 2, width: 14, height: 20, rx: 2, f: 'P' }],
    ['path', { d: 'M12 18h.01', k: 'aP' }]
  ],
  PhoneKeypad: [
    ['rect', { x: 6, y: 2, width: 12, height: 20, rx: 2.5, f: 'P' }],
    ['path', { d: 'M9 7h.01M12 7h.01M15 7h.01M9 11h.01M12 11h.01M15 11h.01M9 15h.01M12 15h.01M15 15h.01', k: 'aP' }]
  ],
  Phone: [
    ['path', { d: 'M22 16.92v3a2 2 0 0 1-2.18 2 19.79 19.79 0 0 1-8.63-3.07 19.5 19.5 0 0 1-6-6 19.79 19.79 0 0 1-3.07-8.67A2 2 0 0 1 4.11 2h3a2 2 0 0 1 2 1.72 12.84 12.84 0 0 0 .7 2.81 2 2 0 0 1-.45 2.11L8.09 9.91a16 16 0 0 0 6 6l1.27-1.27a2 2 0 0 1 2.11-.45 12.84 12.84 0 0 0 2.81.7A2 2 0 0 1 22 16.92z', f: 'P' }]
  ],
  PhoneCall: [
    ['path', { d: 'M22 16.92v3a2 2 0 0 1-2.18 2 19.79 19.79 0 0 1-8.63-3.07 19.5 19.5 0 0 1-6-6 19.79 19.79 0 0 1-3.07-8.67A2 2 0 0 1 4.11 2h3a2 2 0 0 1 2 1.72 12.84 12.84 0 0 0 .7 2.81 2 2 0 0 1-.45 2.11L8.09 9.91a16 16 0 0 0 6 6l1.27-1.27a2 2 0 0 1 2.11-.45 12.84 12.84 0 0 0 2.81.7A2 2 0 0 1 22 16.92z', f: 'P' }],
    ['path', { d: 'M14.05 2a9 9 0 0 1 8 7.94M14.05 6A5 5 0 0 1 18 10' }]
  ],
  Keypad: [
    ['rect', { x: 2, y: 2, width: 20, height: 20, rx: 2, f: 'P' }],
    ['path', { d: 'M7 7h.01M12 7h.01M17 7h.01M7 12h.01M12 12h.01M17 12h.01M7 17h.01M12 17h.01M17 17h.01', k: 'aP' }]
  ],
  Gears3: [
    ['path', { d: 'M12.22 2h-.44a2 2 0 0 0-2 2v.18a2 2 0 0 1-1 1.73l-.43.25a2 2 0 0 1-2 0l-.15-.08a2 2 0 0 0-2.73.73l-.22.38a2 2 0 0 0 .73 2.73l.15.1a2 2 0 0 1 1 1.72v.51a2 2 0 0 1-1 1.74l-.15.09a2 2 0 0 0-.73 2.73l.22.38a2 2 0 0 0 2.73.73l.15-.08a2 2 0 0 1 2 0l.43.25a2 2 0 0 1 1 1.73V20a2 2 0 0 0 2 2h.44a2 2 0 0 0 2-2v-.18a2 2 0 0 1 1-1.73l.43-.25a2 2 0 0 1 2 0l.15.08a2 2 0 0 0 2.73-.73l.22-.39a2 2 0 0 0-.73-2.73l-.15-.08a2 2 0 0 1-1-1.74v-.5a2 2 0 0 1 1-1.74l.15-.09a2 2 0 0 0 .73-2.73l-.22-.38a2 2 0 0 0-2.73-.73l-.15.08a2 2 0 0 1-2 0l-.43-.25a2 2 0 0 1-1-1.73V4a2 2 0 0 0-2-2z', transform: 'translate(.5 .5) scale(.7)', f: 'P' }],
    ['circle', { cx: 12, cy: 12, r: 3, transform: 'translate(.5 .5) scale(.7)', f: 'W' }],
    ['path', { d: 'M12.22 2h-.44a2 2 0 0 0-2 2v.18a2 2 0 0 1-1 1.73l-.43.25a2 2 0 0 1-2 0l-.15-.08a2 2 0 0 0-2.73.73l-.22.38a2 2 0 0 0 .73 2.73l.15.1a2 2 0 0 1 1 1.72v.51a2 2 0 0 1-1 1.74l-.15.09a2 2 0 0 0-.73 2.73l.22.38a2 2 0 0 0 2.73.73l.15-.08a2 2 0 0 1 2 0l.43.25a2 2 0 0 1 1 1.73V20a2 2 0 0 0 2 2h.44a2 2 0 0 0 2-2v-.18a2 2 0 0 1 1-1.73l.43-.25a2 2 0 0 1 2 0l.15.08a2 2 0 0 0 2.73-.73l.22-.39a2 2 0 0 0-.73-2.73l-.15-.08a2 2 0 0 1-1-1.74v-.5a2 2 0 0 1 1-1.74l.15-.09a2 2 0 0 0 .73-2.73l-.22-.38a2 2 0 0 0-2.73-.73l-.15.08a2 2 0 0 1-2 0l-.43-.25a2 2 0 0 1-1-1.73V4a2 2 0 0 0-2-2z', transform: 'translate(11.5 8) scale(.55)', f: 'S' }],
    ['circle', { cx: 12, cy: 12, r: 3, transform: 'translate(11.5 8) scale(.55)', f: 'W', k: 'aP' }],
    ['path', { d: 'M12.22 2h-.44a2 2 0 0 0-2 2v.18a2 2 0 0 1-1 1.73l-.43.25a2 2 0 0 1-2 0l-.15-.08a2 2 0 0 0-2.73.73l-.22.38a2 2 0 0 0 .73 2.73l.15.1a2 2 0 0 1 1 1.72v.51a2 2 0 0 1-1 1.74l-.15.09a2 2 0 0 0-.73 2.73l.22.38a2 2 0 0 0 2.73.73l.15-.08a2 2 0 0 1 2 0l.43.25a2 2 0 0 1 1 1.73V20a2 2 0 0 0 2 2h.44a2 2 0 0 0 2-2v-.18a2 2 0 0 1 1-1.73l.43-.25a2 2 0 0 1 2 0l.15.08a2 2 0 0 0 2.73-.73l.22-.39a2 2 0 0 0-.73-2.73l-.15-.08a2 2 0 0 1-1-1.74v-.5a2 2 0 0 1 1-1.74l.15-.09a2 2 0 0 0 .73-2.73l-.22-.38a2 2 0 0 0-2.73-.73l-.15.08a2 2 0 0 1-2 0l-.43-.25a2 2 0 0 1-1-1.73V4a2 2 0 0 0-2-2z', transform: 'translate(3 13) scale(.5)', f: 'T' }],
    ['circle', { cx: 12, cy: 12, r: 3, transform: 'translate(3 13) scale(.5)', f: 'W', k: 'aS' }]
  ],
  Wrench: [
    ['path', { d: 'M14.7 6.3a1 1 0 0 0 0 1.4l1.6 1.6a1 1 0 0 0 1.4 0l3.77-3.77a6 6 0 0 1-7.94 7.94l-6.91 6.91a2.12 2.12 0 0 1-3-3l6.91-6.91a6 6 0 0 1 7.94-7.94l-3.76 3.76z', f: 'P' }]
  ],
  PCWrench: [
    ['rect', { x: 3, y: 2, width: 9, height: 20, rx: 1.5, f: 'P' }],
    ['circle', { cx: 7.5, cy: 17, r: 1, k: 'aP' }],
    ['path', { d: 'M6 6h3', k: 'aP' }],
    ['path', { d: 'M14.7 6.3a1 1 0 0 0 0 1.4l1.6 1.6a1 1 0 0 0 1.4 0l3.77-3.77a6 6 0 0 1-7.94 7.94l-6.91 6.91a2.12 2.12 0 0 1-3-3l6.91-6.91a6 6 0 0 1 7.94-7.94l-3.76 3.76z', transform: 'translate(11 7) scale(.55)', f: 'P' }]
  ],
  Engine: [
    ['rect', { x: 5, y: 8, width: 12, height: 9, rx: 1, f: 'P' }],
    ['path', { d: 'M8 8V5h6v3M3 11v4M17 11h2M19 9v6M5 17v3h12v-3' }]
  ],
  Key: [
    ['circle', { cx: 7.5, cy: 15.5, r: 4.5, f: 'P' }],
    ['path', { d: 'm10.7 12.3 9.8-9.8M17 6l3 3M14 9l2 2' }]
  ],
  Lock: [
    ['rect', { x: 3, y: 11, width: 18, height: 11, rx: 2, f: 'P' }],
    ['path', { d: 'M7 11V7a5 5 0 0 1 10 0v4' }]
  ],
  LockKey: [
    ['rect', { x: 2, y: 10, width: 15, height: 12, rx: 2, f: 'P' }],
    ['path', { d: 'M5.5 10V7a4 4 0 0 1 8 0v3' }],
    ['circle', { cx: 19, cy: 15, r: 2.5, f: 'S' }],
    ['path', { d: 'M19 17.5V22M19 20h2' }]
  ],
  Link: [
    ['path', { d: 'M10 13a5 5 0 0 0 7.54.54l3-3a5 5 0 0 0-7.07-7.07l-1.72 1.71', k: 'P' }],
    ['path', { d: 'M14 11a5 5 0 0 0-7.54-.54l-3 3a5 5 0 0 0 7.07 7.07l1.71-1.71', k: 'P' }]
  ],
  Search: [
    ['circle', { cx: 11, cy: 11, r: 8, f: 'P' }],
    ['path', { d: 'm21 21-4.3-4.3', k: 'S' }]
  ],
  SearchPen: [
    ['circle', { cx: 11, cy: 11, r: 8, transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'm21 21-4.3-4.3', transform: 'scale(.78)' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'm15.6 20.4 5-5M19 14l2.5 2.5M15.6 20.4l.3-1.9', k: 'W' }]
  ],
  ScanSearch: [
    ['path', { d: 'M3 7V5a2 2 0 0 1 2-2h2M17 3h2a2 2 0 0 1 2 2v2M21 17v2a2 2 0 0 1-2 2h-2M7 21H5a2 2 0 0 1-2-2v-2' }],
    ['circle', { cx: 12, cy: 12, r: 3, f: 'P' }],
    ['path', { d: 'm16 16-1.9-1.9' }]
  ],
  Binoculars: [
    ['path', { d: 'M10 10h4M19 7V4a1 1 0 0 0-1-1h-2a1 1 0 0 0-1 1v3' }],
    ['path', { d: 'M20 21a2 2 0 0 0 2-2v-3.851c0-1.39-2-2.962-2-4.829V8a1 1 0 0 0-1-1h-4a1 1 0 0 0-1 1v11a2 2 0 0 0 2 2z', f: 'P' }],
    ['path', { d: 'M22 16H2' }],
    ['path', { d: 'M4 21a2 2 0 0 1-2-2v-3.851c0-1.39 2-2.962 2-4.829V8a1 1 0 0 1 1-1h4a1 1 0 0 1 1 1v11a2 2 0 0 1-2 2z', f: 'P' }],
    ['path', { d: 'M9 7V4a1 1 0 0 0-1-1H6a1 1 0 0 0-1 1v3' }]
  ],
  Broom: [
    ['path', { d: 'M14 10l6.5-6.5' }],
    ['path', { d: 'M10 9l5 5c-1 3-3.5 6-8 7l-4-1c1-3 1-5 3-7 1.5-1.5 3.5-3 4-4z', f: 'P' }],
    ['path', { d: 'M7 13l4 4', k: 'aP' }]
  ],
  Camera: [
    ['path', { d: 'M14.5 4h-5L7 7H4a2 2 0 0 0-2 2v9a2 2 0 0 0 2 2h16a2 2 0 0 0 2-2V9a2 2 0 0 0-2-2h-3l-2.5-3z', f: 'P' }],
    ['circle', { cx: 12, cy: 13, r: 3, f: 'S' }]
  ],
  CameraPlus: [
    ['path', { d: 'M14.5 4h-5L7 7H4a2 2 0 0 0-2 2v9a2 2 0 0 0 2 2h16a2 2 0 0 0 2-2V9a2 2 0 0 0-2-2h-3l-2.5-3z', transform: 'scale(.78)', f: 'P' }],
    ['circle', { cx: 12, cy: 13, r: 3, transform: 'scale(.78)', f: 'P' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'M18 15.5v5M15.5 18h5', k: 'W' }]
  ],
  Picture: [
    ['rect', { x: 3, y: 3, width: 18, height: 18, rx: 2, f: 'P' }],
    ['circle', { cx: 9, cy: 9, r: 1.5, k: 'aP' }],
    ['path', { d: 'm21 15-3.086-3.086a2 2 0 0 0-2.828 0L6 21', k: 'aP' }]
  ],
  Floppy: [
    ['path', { d: 'M15.2 3a2 2 0 0 1 1.4.6l3.8 3.8a2 2 0 0 1 .6 1.4V19a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2z', f: 'P' }],
    ['path', { d: 'M17 21v-7a1 1 0 0 0-1-1H8a1 1 0 0 0-1 1v7M7 3v4a1 1 0 0 0 1 1h7', k: 'aP' }]
  ],
  HardHat: [
    ['path', { d: 'M3.5 15v-2.5a8.5 8.5 0 0 1 17 0V15Z', f: 'P' }],
    ['path', { d: 'M10 11V5.5a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1V11' }],
    ['rect', { x: 2, y: 15, width: 20, height: 4, rx: 1, f: 'P' }]
  ],
  B2Mining: [
    ['path', { d: 'M5 10a7 6 0 0 1 14 0H5Z', f: 'P' }],
    ['path', { d: 'M0 0V5H2L3 4V3L2 2.5L3 2V1L2 0ZM0 2.5H2', transform: 'translate(8.5 13.5) scale(1)', strokeWidth: 1.5 }],
    ['path', { d: 'M0 1L1 0H2L3 1V2L0 5H3', transform: 'translate(12.9 13.5) scale(1)', strokeWidth: 1.5 }],
    ['path', { d: 'M4 21h16' }]
  ],
  Cart: [
    ['path', { d: 'M5.12 7H22l-1.65 7.43a2 2 0 0 1-1.95 1.57H8.72a2 2 0 0 1-2-1.58Z', f: 'P' }],
    ['path', { d: 'M2.05 2.05h2l1.7 8' }],
    ['circle', { cx: 8, cy: 21, r: 1.4, f: 'K' }],
    ['circle', { cx: 19, cy: 21, r: 1.4, f: 'K' }]
  ],
  CartPackage: [
    ['path', { d: 'M5.12 7H22l-1.65 7.43a2 2 0 0 1-1.95 1.57H8.72a2 2 0 0 1-2-1.58Z', transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M2.05 2.05h2l1.7 8', transform: 'scale(.78)' }],
    ['circle', { cx: 8, cy: 21, r: 1.4, transform: 'scale(.78)', f: 'K' }],
    ['circle', { cx: 19, cy: 21, r: 1.4, transform: 'scale(.78)', f: 'K' }],
    ['rect', { x: 14, y: 12, width: 8, height: 8, rx: 1, f: 'S' }],
    ['path', { d: 'M14 15h8M18 12v3', k: 'aS' }]
  ],
  CartHouse: [
    ['path', { d: 'M5.12 7H22l-1.65 7.43a2 2 0 0 1-1.95 1.57H8.72a2 2 0 0 1-2-1.58Z', f: 'P' }],
    ['path', { d: 'M2.05 2.05h2l1.7 8' }],
    ['circle', { cx: 8, cy: 21, r: 1.4, f: 'K' }],
    ['circle', { cx: 19, cy: 21, r: 1.4, f: 'K' }],
    ['path', { d: 'M9.5 10 12.5 6.5 15.5 10v3h-6Z', f: 'S' }]
  ],
  WindowsArrow: [
    ['rect', { x: 3, y: 12, width: 10, height: 9, rx: 1.5, f: 'P' }],
    ['path', { d: 'M6 16h4', k: 'aP' }],
    ['path', { d: 'M20 4 13 11M20 4v5M20 4h-5', k: 'T' }]
  ],
  WindowsArrowPlus: [
    ['rect', { x: 3, y: 12, width: 10, height: 9, rx: 1.5, transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M6 16h4', transform: 'scale(.78)', k: 'aP' }],
    ['path', { d: 'M20 4 13 11M20 4v5M20 4h-5', transform: 'scale(.78)', k: 'T' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'M18 15.5v5M15.5 18h5', k: 'W' }]
  ],
  Wizard: [
    ['rect', { x: 2, y: 3, width: 20, height: 18, rx: 2, f: 'P' }],
    ['path', { d: 'M2 8h20M6 12h.01M6 15h.01M6 18h.01M9 12h9M9 15h9M9 18h9', k: 'aP' }]
  ],
  TableX: [
    ['rect', { x: 2, y: 3, width: 20, height: 16, rx: 2, transform: 'scale(.78)', f: 'P' }],
    ['path', { d: 'M2 9h20M2 14h20M9 9v10', transform: 'scale(.78)', k: 'aP' }],
    ['circle', { cx: 18, cy: 18, r: 5, f: 'B' }],
    ['path', { d: 'm16 16 4 4M20 16l-4 4', k: 'W' }]
  ],
  TagNew: [
    ['rect', { x: 2, y: 6, width: 20, height: 12, rx: 3, f: 'P' }],
    ['path', { d: 'M0 5V0L3 5V0', transform: 'translate(5.9 9.5) scale(1)', strokeWidth: 1.5, k: 'aP' }],
    ['path', { d: 'M3 0H0V5H3M0 2.5H2', transform: 'translate(10.3 9.5) scale(1)', strokeWidth: 1.5, k: 'aP' }],
    ['path', { d: 'M0 0L.75 5L1.5 1.8L2.25 5L3 0', transform: 'translate(14.700000000000001 9.5) scale(1)', strokeWidth: 1.5, k: 'aP' }]
  ],
  Digits123: [
    ['path', { d: 'M.4 1.2L1.6 0V5', transform: 'translate(3.2 8) scale(1.6)', strokeWidth: 1.3, k: 'P' }],
    ['path', { d: 'M0 1L1 0H2L3 1V2L0 5H3', transform: 'translate(10.240000000000002 8) scale(1.6)', strokeWidth: 1.3, k: 'P' }],
    ['path', { d: 'M0 0H3L1.5 2.2L3 3.2V4L2 5H0', transform: 'translate(17.28 8) scale(1.6)', strokeWidth: 1.3, k: 'P' }]
  ],
  Warning: [
    ['path', { d: 'm21.73 18-8-14a2 2 0 0 0-3.48 0l-8 14A2 2 0 0 0 4 21h16a2 2 0 0 0 1.73-3', f: 'P' }],
    ['path', { d: 'M12 9v4M12 17h.01', k: 'aP' }]
  ],
  WarningDouble: [
    ['path', { d: 'm21.73 18-8-14a2 2 0 0 0-3.48 0l-8 14A2 2 0 0 0 4 21h16a2 2 0 0 0 1.73-3', transform: 'translate(-1 5) scale(.72)', f: 'P' }],
    ['path', { d: 'M12 9v4M12 17h.01', transform: 'translate(-1 5) scale(.72)', k: 'aP' }],
    ['path', { d: 'm21.73 18-8-14a2 2 0 0 0-3.48 0l-8 14A2 2 0 0 0 4 21h16a2 2 0 0 0 1.73-3', transform: 'translate(9 1) scale(.72)', f: 'P' }],
    ['path', { d: 'M12 9v4M12 17h.01', transform: 'translate(9 1) scale(.72)', k: 'aP' }]
  ],
  BarChart: [
    ['path', { d: 'M3 3v16a2 2 0 0 0 2 2h16' }],
    ['rect', { x: 6, y: 13, width: 3, height: 6, f: 'P' }],
    ['rect', { x: 10, y: 9, width: 3, height: 10, f: 'S' }],
    ['rect', { x: 14, y: 11, width: 3, height: 8, f: 'T' }],
    ['rect', { x: 18, y: 5, width: 3, height: 14, f: 'P' }]
  ],
  Pie: [
    ['path', { d: 'M12 12 8 2.83A10 10 0 1 0 21.21 15.89Z', f: 'P' }],
    ['path', { d: 'M21 12c.55 0 1-.45.95-1a10 10 0 0 0-8.95-8.95c-.55-.05-1 .4-1 .95v8a1 1 0 0 0 1 1z', f: 'S' }]
  ],
  PieBars: [
    ['path', { d: 'M3 3v18h18' }],
    ['rect', { x: 10, y: 14, width: 3, height: 5, f: 'S' }],
    ['rect', { x: 13.5, y: 10, width: 3, height: 9, f: 'P' }],
    ['rect', { x: 17, y: 7, width: 3, height: 12, f: 'T' }],
    ['circle', { cx: 8, cy: 8, r: 3.5, f: 'P' }],
    ['path', { d: 'M8 4.5V8h3.5' }]
  ],
};

/* paleta vacía: los diseños 'Rico' llevan sus colores literales en cada forma */
const RICA: Paleta = { p: '#000000' };

/* ---------- iconos ---------- */
export const ActivitlColorIcon = crearColor('Activitl', D.NotebookClock, { p: '#f3f3f6', s: '#9ea5ad' });
export const AbajoColorIcon = crearColor('Abajo', D.ChevronsDown, { p: '#2f6fb5' });
export const AceptarColorIcon = crearColor('Aceptar', D.CircleCheck, { p: '#43a52b' });
export const Act2ColorIcon = crearColor('Act2', D.Refresh, { p: '#2f6fb5' });
export const ActCuentaColorIcon = crearColor('ActCuenta', D.CalcRefresh, { p: '#d9dde2', s: '#43a52b' });
export const ActualizarColorIcon = crearColor('Actualizar', D.Refresh, { p: '#5a8fd0' });
export const AfpColorIcon = crearColor('Afp', D.DocGlobe, { p: '#f4f4f4', s: '#2f6fb5' });
export const AgregarColorIcon = crearColor('Agregar', D.ChevronRightToLine, { p: '#2f6fb5' });
export const AnularPngColorIcon = crearColor('AnularPng', D.Ban, { p: '#d82a2a' });
export const AnularJpgColorIcon = crearColor('AnularJpg', D.TableX, { p: '#eef0f6', s: '#d82a2a' });
export const AnularIcoColorIcon = crearColor('AnularIco', D.CircleX, { p: '#c62828' });
export const AprobarColorIcon = crearColor('Aprobar', D.Check, { p: '#2e9a2e' });
export const AprobarMasColorIcon = crearColor('AprobarMas', D.CheckCheck, { p: '#5dbb2f' });
export const ArribaColorIcon = crearColor('Arriba', D.ChevronsUp, { p: '#2f6fb5' });
export const AsigHorarioColorIcon = crearColor('AsigHorario', D.CalendarClock, { p: '#fdecc8', s: '#f08a24' });
export const AsigJefesColorIcon = crearColor('AsigJefes', D.UserBriefcase, { p: '#8a5a2b', s: '#f0c9a0' });
export const AtendProvColorIcon = crearColor('AtendProv', D.FolderPen, { p: '#4f8fe0', s: '#f6c928' });
export const AtenderMasivoColorIcon = crearColor('AtenderMasivo', D.Banknotes, { p: '#a6d66b', s: '#7bbf45' });
export const BalanceColorIcon = crearColor('Balance', D.Scale, { p: '#d9a441' });
export const BoletaColorIcon = crearColor('Boleta', D.DocBol, { p: '#fff0d4' });
export const BorrarColorIcon = crearColor('Borrar', D.X, { p: '#d82a2a' });
export const BuscarIcoColorIcon = crearColor('BuscarIco', D.Binoculars, { p: '#6b7280', s: '#2b78c9' });
export const BuscarPngColorIcon = crearColor('BuscarPng', D.Binoculars, { p: '#4a6fb5', s: '#2b78c9' });
export const CoaColorIcon = crearColor('Coa', D.Certificate, { p: '#cdeff7', s: '#7a7af0' });
export const CajaBancoColorIcon = crearColor('CajaBanco', D.MoneyBagCoin, { p: '#efd27a', s: '#e3b53a' });
export const CanjearColorIcon = crearColor('Canjear', D.Canjear, { p: '#9aa0a8', s: '#4b5563' });
export const CapacitacionColorIcon = crearColor('Capacitacion', D.Chalkboard, { p: '#1f7a3a', s: '#d9893a' });
export const CargoPerColorIcon = crearColor('CargoPer', D.UsersHardHat, { p: '#f0c9a0', s: '#f6c928' });
export const CerrarColorIcon = crearColor('Cerrar', D.DoorExit, { p: '#8a8a1a' });
export const CerrarPrColorIcon = crearColor('CerrarPr', D.Lock, { p: '#cfd2d6', s: '#f6c928' });
export const CheckColorIcon = crearColor('Check', D.SquareCheck, { p: '#2b2f36' });
export const Check1ColorIcon = crearColor('Check1', D.Square, { p: '#ffffff' });
export const CompraConColorIcon = crearColor('CompraCon', D.CartPackage, { p: '#f6b84a', s: '#d93a35' });
export const ComprasColorIcon = crearColor('Compras', D.Cart, { p: '#7b8088' });
export const ContDiarioColorIcon = crearColor('ContDiario', D.ClipboardCheckPen, { p: '#3b4048', s: '#4f8ef0' });
export const CrdFle04ColorIcon = crearColor('CrdFle04', D.CardFile, { p: '#e03a3a', s: '#f4f4f4' });
export const CrdFle12ColorIcon = crearColor('CrdFle12', D.CardFileStand, { p: '#e03a3a', s: '#f4f4f4' });
export const CrdFle13ColorIcon = crearColor('CrdFle13', D.CardFilePen, { p: '#e03a3a', s: '#f6e04a' });
export const CronogramaIcoColorIcon = crearColor('CronogramaIco', D.CalendarCheck, { p: '#cfe9e4', s: '#3f4a56' });
export const DerechaColorIcon = crearColor('Derecha', D.ChevronsRight, { p: '#2f6fb5' });
export const DesExcelDsctosColorIcon = crearColor('DesExcelDsctos', D.ExcelPercentDown, { p: '#dcebd2', s: '#4ca83a' });
export const DesExcelIngColorIcon = crearColor('DesExcelIng', D.ExcelCoinsDown, { p: '#dcebd2', s: '#4ca83a' });
export const DescPlanillaColorIcon = crearColor('DescPlanilla', D.Percent, { p: '#d82a2a' });
export const DescargarExcelColorIcon = crearColor('DescargarExcel', D.ExcelDown, { p: '#d4e8c4', s: '#3f9a2f' });
export const DescuentosPerColorIcon = crearColor('DescuentosPer', D.PercentDown, { p: '#f78a2a', s: '#f26a1b' });
export const DeshacerColorIcon = crearColor('Deshacer', D.Undo, { p: '#2b8de0' });
export const DolarColorIcon = crearColor('Dolar', D.Dollar, { p: '#2e8b2e' });
export const DsctoColorIcon = crearColor('Dscto', D.Percent, { p: '#e02424' });
export const EditarColorIcon = crearColor('Editar', D.FilePen, { p: '#eaf1fb' });
export const EliminarIcoColorIcon = crearColor('EliminarIco', D.X, { p: '#d01c2c' });
export const EliminarPngColorIcon = crearColor('EliminarPng', D.FileX, { p: '#f0f0f0', s: '#e02424' });
export const EmbarqueColorIcon = crearColor('Embarque', D.Truck, { p: '#2b2f36', s: '#555b63' });
export const EmpresaColorIcon = crearColor('Empresa', D.Boots, { p: '#b98a4a' });
export const EnviarColorIcon = crearColor('Enviar', D.DocSend, { p: '#f3f3f3' });
export const EnviarPrColorIcon = crearColor('EnviarPr', D.MailUp, { p: '#eef0f3', s: '#43a52b' });
export const EquiposColorIcon = crearColor('Equipos', D.Gears3, { p: '#f0c030', s: '#2e6fcb', t: '#4aa84a' });
export const FacturaColorIcon = crearColor('Factura', D.DocFac, { p: '#ffd4ff' });
export const FacturaGuiaColorIcon = crearColor('FacturaGuia', D.DocFG, { p: '#c8e8c4' });
export const FacturarGuiasColorIcon = crearColor('FacturarGuias', D.DocDollar, { p: '#dcdcdc' });
export const FechaColorIcon = crearColor('Fecha', D.CalendarDigits, { p: '#fff7d0', s: '#e03a3a' });
export const FotoNoDisponibleColorIcon = crearColor('FotoNoDisponible', D.UserSilhouette, { p: '#8fcde0', s: '#3e3e3e' });
export const Graph07ColorIcon = crearColor('Graph07', D.BarChart, { p: '#2f90ff', s: '#e03a2a', t: '#43a52b' });
export const GearsColorIcon = crearColor('Gears', D.Gears3, { p: '#e9b730', s: '#2f6fcb', t: '#4aa84a' });
export const GenerarColorIcon = crearColor('Generar', D.WindowsArrow, { p: '#c4c8cd', s: '#f2993a', t: '#f2993a' });
export const GuiaDevolucionColorIcon = crearColor('GuiaDevolucion', D.DocGD, { p: '#ffffff' });
export const GuiaRemisionColorIcon = crearColor('GuiaRemision', D.DocGR, { p: '#e3ffd4' });
export const GrabarColorIcon = crearColor('Grabar', D.Floppy, { p: '#2bd4e6' });
export const HeIconColorIcon = crearColor('HeIcon', D.Clock, { p: '#cfd2d6' });
export const HorariosColorIcon = crearColor('Horarios', D.WindowClock, { p: '#e9ebee', s: '#c9ccd1' });
export const HorsExtColorIcon = crearColor('HorsExt', D.AlarmPlus, { p: '#f4f0c8', s: '#43a52b' });
export const IcoReloj2ColorIcon = crearColor('IcoReloj2', D.Wristwatch, { p: '#c0c4cc', s: '#1a2a6c' });
export const ImgApptRecurColorIcon = crearColor('ImgApptRecur', D.RotateCw, { p: '#27539b' });
export const ImgSendReceiveColorIcon = crearColor('ImgSendReceive', D.ArrowLeftRight, { p: '#3f6fa5' });
export const ImpExcelIngColorIcon = crearColor('ImpExcelIng', D.ExcelCoinsUp, { p: '#dcebd2', s: '#e6b43a' });
export const ImportarExcelColorIcon = crearColor('ImportarExcel', D.ExcelUp, { p: '#d4e8c4', s: '#3f9a2f' });
export const ImpresoraIcoColorIcon = crearColor('ImpresoraIco', D.Printer, { p: '#a8adb5' });
export const ImpresoraPngColorIcon = crearColor('ImpresoraPng', D.Printer, { p: '#c8e68a' });
export const IngresosColorIcon = crearColor('Ingresos', D.PiggyBank, { p: '#f4c6c0' });
export const IngresosPerColorIcon = crearColor('IngresosPer', D.HandCoins, { p: '#f4c542' });
export const InstruccionColorIcon = crearColor('Instruccion', D.GradBubble, { p: '#22b6ea' });
export const IzquierdaColorIcon = crearColor('Izquierda', D.ChevronsLeft, { p: '#2f6fb5' });
export const JobMarcaColorIcon = crearColor('JobMarca', D.ClipboardList, { p: '#33373d' });
export const KeysColorIcon = crearColor('Keys', D.Key, { p: '#f2b84b' });
export const LectorHuellasColorIcon = crearColor('LectorHuellas', D.FingerprintDevice, { p: '#33383f', s: '#4a9de8', t: '#7ed957' });
export const LibDiarioColorIcon = crearColor('LibDiario', D.BookOpen, { p: '#dcebf5', s: '#2f6fb5' });
export const LibMayorColorIcon = crearColor('LibMayor', D.NotebookPlus, { p: '#dbe8f3', s: '#43a52b' });
export const LibroDiarioColorIcon = crearColor('LibroDiario', D.Book, { p: '#2f8fd0' });
export const LibroMayorColorIcon = crearColor('LibroMayor', D.BookBookmark, { p: '#c4262e' });
export const LimpiarPngColorIcon = crearColor('LimpiarPng', D.Broom, { p: '#f0c94f' });
export const LimpiarJpgColorIcon = crearColor('LimpiarJpg', D.Broom, { p: '#d9d28a' });
export const LlamadaColorIcon = crearColor('Llamada', D.PhoneCall, { p: '#2b2f36' });
export const LupaColorIcon = crearColor('Lupa', D.Search, { p: '#cfe6fa', s: '#e8a23a' });
export const Mail20ColorIcon = crearColor('Mail20', D.Keypad, { p: '#5b5a24' });
export const ManoHaciaAbajoColorIcon = crearColor('ManoHaciaAbajo', D.ThumbsDown, { p: '#e8262b' });
export const MaterialColorIcon = crearColor('Material', D.Wrench, { p: '#9aa0a6' });
export const MaximunColorIcon = crearColor('Maximun', D.SearchPen, { p: '#cfe0f5', s: '#c88a2a' });
export const NotasColorIcon = crearColor('Notas', D.DocNot, { p: '#fffbe8' });
export const NuevaMarcacionColorIcon = crearColor('NuevaMarcacion', D.ClockSpark, { p: '#8e63b5' });
export const NuevoMultipleColorIcon = crearColor('NuevoMultiple', D.FilesPlus, { p: '#e6efe4', s: '#43a52b' });
export const OfficeColorIcon = crearColor('Office', D.Building, { p: '#b7bbc1', s: '#2b6fd0' });
export const PagosColorIcon = crearColor('Pagos', D.HandBanknote, { p: '#9fdcaa' });
export const AboutColorIcon = crearColor('About', D.Info, { p: '#2f6fd0' });
export const ActMailColorIcon = crearColor('ActMail', D.AtSign, { p: '#2b2f36' });
export const ActualizarCostosColorIcon = crearColor('ActualizarCostos', D.RotateCcw, { p: '#4a8a1a' });
export const AcumuladaColorIcon = crearColor('Acumulada', D.CirclePlus, { p: '#7cc720' });
export const AcwizardColorIcon = crearColor('Acwizard', D.Wizard, { p: '#eef0f2', s: '#4aa84a' });
export const AdicionarcontenedorColorIcon = crearColor('Adicionarcontenedor', D.FolderPlus, { p: '#f4c24a', s: '#43a52b' });
export const Admin48ColorIcon = crearColor('Admin48', D.UserTie, { p: '#f0c9a0', s: '#3b78b8' });
export const AjustarCostosColorIcon = crearColor('AjustarCostos', D.BookHelp, { p: '#2f6fc0' });
export const AlmacenColorIcon = crearColor('Almacen', D.House, { p: '#e9ecef', s: '#4f7f9f' });
export const AporPlanillasColorIcon = crearColor('AporPlanillas', D.MoneyBag, { p: '#f7c948' });
export const ArbolnavidadColorIcon = crearColor('Arbolnavidad', D.ChristmasTree, { p: '#4f9a2f', s: '#e03a2a' });
export const AreaCostoColorIcon = crearColor('AreaCosto', D.Network, { p: '#3b9ae0', s: '#6fb43a' });
export const AreaPerColorIcon = crearColor('AreaPer', D.Briefcase, { p: '#8a4a1f' });
export const ArqueoCajaColorIcon = crearColor('ArqueoCaja', D.CashRegister, { p: '#c3cad3', s: '#ead07a' });
export const B2miningColorIcon = crearColor('B2mining', D.B2Mining, { p: '#ffd23f' });
export const BajarEstadoColorIcon = crearColor('BajarEstado', D.DocDown, { p: '#f2f2f2', s: '#6b940b' });
export const BancosColorIcon = crearColor('Bancos', D.Safe, { p: '#f7d04a', s: '#4aa0e8' });
export const Books256ColorIcon = crearColor('Books256', D.Books256Rico, RICA);
export const Brcase16ColorIcon = crearColor('Brcase16', D.Portfolio, { p: '#b7b374' });
export const Brcase48ColorIcon = crearColor('Brcase48', D.Portfolio, { p: '#b9b678' });
export const BrochaColorIcon = crearColor('Brocha', D.Stamp, { p: '#b85a44' });
export const Bundle256ColorIcon = crearColor('Bundle256', D.BanknoteBundle, { p: '#cbeacb', s: '#f6c928' });
export const CalendarColorIcon = crearColor('Calendar', D.Calendar, { p: '#dcf0fb', s: '#f5a03a' });
export const CalendarCopiarColorIcon = crearColor('CalendarCopiar', D.CalendarCopy, { p: '#dfe6ee', s: '#d62828' });
export const CalendarEditColorIcon = crearColor('CalendarEdit', D.CalendarPen, { p: '#dcf0fb', s: '#f5a03a' });
export const Cam48ColorIcon = crearColor('Cam48', D.Camera, { p: '#a2a7ae' });
export const CameraColorIcon = crearColor('Camera', D.Camera, { p: '#2b2f36' });
export const Car256ColorIcon = crearColor('Car256', D.Car, { p: '#6f66d4' });
export const Cartera2ColorIcon = crearColor('Cartera2', D.Clipboard, { p: '#33373d', s: '#6b7280' });
export const CasaAeropuertoColorIcon = crearColor('CasaAeropuerto', D.Plane, { p: '#2b2f36' });
export const CerrarmesColorIcon = crearColor('Cerrarmes', D.DoorArrowIn, { p: '#e8420f' });
export const ChequeoColorIcon = crearColor('Chequeo', D.CircleCheck, { p: '#8fc400' });
export const ClasesColorIcon = crearColor('Clases', D.BookBookmark, { p: '#3b3d40', s: '#e8863a' });
export const CleanClienteColorIcon = crearColor('CleanCliente', D.Broom, { p: '#f0c94f' });
export const ClienteColorIcon = crearColor('Cliente', D.UserTie, { p: '#f0c9a0', s: '#1c58b0' });
export const ComisionIcoColorIcon = crearColor('ComisionIco', D.MoneyBag, { p: '#2b2f36' });
export const CompraColorIcon = crearColor('Compra', D.ListOrdered, { p: '#2b2f36' });
export const CondensadosColorIcon = crearColor('Condensados', D.FolderStar, { p: '#2b2f36' });
export const ConsolidadoColorIcon = crearColor('Consolidado', D.NotebookSpiral, { p: '#f5b942' });
export const ContrasenaColorIcon = crearColor('Contrasena', D.PersonKey, { p: '#e5b655' });
export const ContratoColorIcon = crearColor('Contrato', D.DocSign, { p: '#f2f2f5', s: '#2f6fd0' });
export const CoronaColorIcon = crearColor('Corona', D.Wreath, { p: '#4f9a2f', s: '#e03a2a' });
export const CostoVentaColorIcon = crearColor('CostoVenta', D.BookUp, { p: '#d9262b' });
export const CostosColorIcon = crearColor('Costos', D.Coins, { p: '#f4c553' });
export const CotIcoColorIcon = crearColor('CotIco', D.ScanSearch, { p: '#cfe3fa', s: '#f59a2c' });
export const CotizacionColorIcon = crearColor('Cotizacion', D.Copy, { p: '#c9ccd1' });
export const CotizacionTallerColorIcon = crearColor('CotizacionTaller', D.HardHat, { p: '#f7d21a' });
export const CreditoColorIcon = crearColor('Credito', D.DocC, { p: '#d6dddf', s: '#5e6c73' });
export const CreditosColorIcon = crearColor('Creditos', D.WalletCoin, { p: '#4a4c52', s: '#e0b040' });
export const CtaDestinoColorIcon = crearColor('CtaDestino', D.CalcRound, { p: '#5d4f48' });
export const CtaPngColorIcon = crearColor('CtaPng', D.Calculator, { p: '#383c43' });
export const CtasPagarColorIcon = crearColor('CtasPagar', D.Cards, { p: '#4aa8e8', s: '#f2b24a' });
export const CtasCtesColorIcon = crearColor('CtasCtes', D.Cards, { p: '#2f6fb0', s: '#f2b630' });
export const CtasCtesPendColorIcon = crearColor('CtasCtesPend', D.CardCoins, { p: '#c4392e', s: '#d9a83a' });
export const CuadrarCierreColorIcon = crearColor('CuadrarCierre', D.Album, { p: '#c9ced4' });
export const CuentaMasColorIcon = crearColor('CuentaMas', D.Calculator, { p: '#a9aed0' });
export const CuentasCobrarColorIcon = crearColor('CuentasCobrar', D.MoneyBag, { p: '#f3cf5a', s: '#5aa02a' });
export const CuentasCorrientesColorIcon = crearColor('CuentasCorrientes', D.Cards, { p: '#6aa6f1', s: '#3ea03a' });
export const DesPerMasColorIcon = crearColor('DesPerMas', D.PercentPlus, { p: '#fe7a1a', s: '#5fb92a' });
export const DespachoColorIcon = crearColor('Despacho', D.HandHelping, { p: '#d4a574' });
export const DetalleColorIcon = crearColor('Detalle', D.Search, { p: '#d4ecfb', s: '#e8920c' });
export const DiarioAlmacenColorIcon = crearColor('DiarioAlmacen', D.Book, { p: '#4f8fe8' });
export const DiarioPagoColorIcon = crearColor('DiarioPago', D.NotebookPen, { p: '#3b3d42', s: '#f0b429' });
export const DocColorIcon = crearColor('Doc', D.Books, { p: '#354c4a', s: '#e8c840' });
export const DocElecDescargarColorIcon = crearColor('DocElecDescargar', D.InvDown, { p: '#f5f7fa', s: '#4f8ef6' });
export const DocElecEliminarColorIcon = crearColor('DocElecEliminar', D.InvX, { p: '#f5f7fa', s: '#4f8ef6' });
export const DocElecGenerarColorIcon = crearColor('DocElecGenerar', D.InvOk, { p: '#f5f7fa', s: '#4f8ef6' });
export const DocElecLupaColorIcon = crearColor('DocElecLupa', D.InvSearch, { p: '#f5f7fa', s: '#4f8ef6' });
export const DocumentosEmitidosColorIcon = crearColor('DocumentosEmitidos', D.FolderOpen, { p: '#fdab31' });
export const Editar2ColorIcon = crearColor('Editar2', D.Pencil, { p: '#eab42e' });
export const EquipoMarColorIcon = crearColor('EquipoMar', D.FingerprintDevice, { p: '#6b7378', s: '#4a9de8', t: '#7ed957' });
export const EquipoTelefonicoColorIcon = crearColor('EquipoTelefonico', D.PhoneKeypad, { p: '#2b2f36' });
export const ExcelColorIcon = crearColor('Excel', D.ExcelPercent, { p: '#a5c898', s: '#d33a2e' });
export const ExcelIcoColorIcon = crearColor('ExcelIco', D.Excel, { p: '#5a9a3a' });
export const ExpLabColorIcon = crearColor('ExpLab', D.UserChecklist, { p: '#f5f5f5', s: '#f0c9a0' });
export const FactDarbajaColorIcon = crearColor('FactDarbaja', D.InvX, { p: '#f5f7fa', s: '#4f8ef6' });
export const FactDescargarColorIcon = crearColor('FactDescargar', D.InvDown, { p: '#f5f7fa', s: '#4f8ef6' });
export const FactGenerarColorIcon = crearColor('FactGenerar', D.InvOk, { p: '#f5f7fa', s: '#4f8ef6' });
export const FactLupaColorIcon = crearColor('FactLupa', D.InvSearch, { p: '#f5f7fa', s: '#4f8ef6' });
export const FalMasivoColorIcon = crearColor('FalMasivo', D.WarningDouble, { p: '#fcb30a' });
export const FaltasIcoColorIcon = crearColor('FaltasIco', D.Warning, { p: '#fcb30a' });
export const FamiliaresColorIcon = crearColor('Familiares', D.Family, { p: '#f0c9a0', s: '#f6c928' });
export const GastoRealRubroColorIcon = crearColor('GastoRealRubro', D.Dollar, { p: '#4cae3c' });
export const GastoRealTotalColorIcon = crearColor('GastoRealTotal', D.Dollar, { p: '#6a9a3a' });
export const GastoViajeColorIcon = crearColor('GastoViaje', D.Luggage, { p: '#8b5a2b' });
export const GastosColorIcon = crearColor('Gastos', D.Wallet, { p: '#d8aa70' });
export const GenerarMasColorIcon = crearColor('GenerarMas', D.WindowsArrowPlus, { p: '#c4c8cd', s: '#37b83a', t: '#f2993a' });
export const GenerarPeriodoColorIcon = crearColor('GenerarPeriodo', D.TagNew, { p: '#ff9a1a' });
export const GerenteColorIcon = crearColor('Gerente', D.UserTie, { p: '#f0c9a0', s: '#3a3a3a' });
export const GraficaColorIcon = crearColor('Grafica', D.PlayCircle, { p: '#c9c7c2' });
export const HePlanillasColorIcon = crearColor('HePlanillas', D.Clock, { p: '#ffffff' });
export const HelpColorIcon = crearColor('Help', D.HelpSquare, { p: '#f1f3f5', s: '#1b9ad6' });
export const HrsEquipoColorIcon = crearColor('HrsEquipo', D.ClockGear, { p: '#2b2f36', s: '#6b7280' });
export const IcoRelojColorIcon = crearColor('IcoReloj', D.Watch, { p: '#ffffff', s: '#d82a2a' });
export const IcoReloj3ColorIcon = crearColor('IcoReloj3', D.Clock, { p: '#b9c0cc' });
export const IcoReloj4ColorIcon = crearColor('IcoReloj4', D.Stopwatch, { p: '#ffffff' });
export const IdiomaColorIcon = crearColor('Idioma', D.Flag, { p: '#c8102e' });
export const ImagenFondoColorIcon = crearColor('ImagenFondo', D.CameraPlus, { p: '#2b2f36', s: '#6b7280' });
export const Img48ColorIcon = crearColor('Img48', D.Picture, { p: '#9edcf7', s: '#2f9a1a' });
export const ImportacionColorIcon = crearColor('Importacion', D.Plane, { p: '#2b2f36' });
export const Indicadores1ColorIcon = crearColor('Indicadores1', D.Pie, { p: '#d8202e', s: '#7aa012', t: '#2f6fb5' });
export const Indicadores2ColorIcon = crearColor('Indicadores2', D.BarChart, { p: '#2f90ff', s: '#e03a2a', t: '#43a52b' });
export const Indicadores3ColorIcon = crearColor('Indicadores3', D.PieBars, { p: '#4a9de8', s: '#e03a2a' });
export const Indicadorico2ColorIcon = crearColor('Indicadorico2', D.BarChart, { p: '#2f90ff', s: '#e03a2a', t: '#43a52b' });
export const Indicadorico3ColorIcon = crearColor('Indicadorico3', D.PieBars, { p: '#4a9de8', s: '#e03a2a' });
export const InformaticaColorIcon = crearColor('Informatica', D.Monitor, { p: '#2a52c8' });
export const IngCtasColorIcon = crearColor('IngCtas', D.MoneyBag, { p: '#1b57c4' });
export const IngPerMasColorIcon = crearColor('IngPerMas', D.CoinsPlus, { p: '#efb94a', s: '#5fb92a' });
export const IngPlanillasColorIcon = crearColor('IngPlanillas', D.MoneyBag, { p: '#2a8a2e' });
export const InternoColorIcon = crearColor('Interno', D.Truck, { p: '#2a9d22', s: '#b7bcc2' });
export const InventarioColorIcon = crearColor('Inventario', D.Digits123, { p: '#8d8d8d' });
export const Laptop16ColorIcon = crearColor('Laptop16', D.Laptop, { p: '#b5dcf5', s: '#7d8590' });
export const Laptop48ColorIcon = crearColor('Laptop48', D.Laptop, { p: '#b5d8ee', s: '#7d8590' });
export const LetrasAceptadasColorIcon = crearColor('LetrasAceptadas', D.ThumbsUp, { p: '#f2b79a' });
export const LibrosContColorIcon = crearColor('LibrosCont', D.Books, { p: '#27b0e8', s: '#79a31a' });
export const LineaTelefonicaColorIcon = crearColor('LineaTelefonica', D.Phone, { p: '#ffffff' });
export const LinkicoColorIcon = crearColor('Linkico', D.Link, { p: '#8a8d92' });
export const LiquidacionColorIcon = crearColor('Liquidacion', D.Dollar, { p: '#4cb52e' });
export const LoginColorIcon = crearColor('Login', D.LockKey, { p: '#d8bd86', s: '#4a4c50' });
export const MantenimientoColorIcon = crearColor('Mantenimiento', D.PCWrench, { p: '#2f3946', s: '#3b78d0' });
export const MarcaColorIcon = crearColor('Marca', D.Footprints, { p: '#3f3f3f' });
export const MayorAuxColorIcon = crearColor('MayorAux', D.Book, { p: '#3f7a45' });
export const MercaderiaColorIcon = crearColor('Mercaderia', D.CartHouse, { p: '#e82a2e', s: '#f6c928' });
export const MesaControlColorIcon = crearColor('MesaControl', D.SquareCheck, { p: '#ffffff' });
export const ModeloTelefonoColorIcon = crearColor('ModeloTelefono', D.Smartphone, { p: '#2b2f36' });
export const MotoresColorIcon = crearColor('Motores', D.Engine, { p: '#d0d3d8' });
export const MovimientoColorIcon = crearColor('Movimiento', D.CircleArrow, { p: '#6b3fa0' });
export const MpIconColorIcon = crearColor('MpIcon', D.Alarm, { p: '#2f3237' });
export const ObservacionColorIcon = crearColor('Observacion', D.NotepadPen, { p: '#e8f1fb', s: '#f0b429' });
export const OrdenesCompraColorIcon = crearColor('OrdenesCompra', D.DocStack, { p: '#ffffff' });
export const PartidasColorIcon = crearColor('Partidas', D.BookInfo, { p: '#6fb8dc' });

export const PrecioCoreColorIcon = crearColor('PrecioCore', D.PrecioCore, { p: '#dcefd2', s: '#d93a35', t: '#b4dba6' });

export const PendienteFacturacionColorIcon = crearColor('PendienteFacturacion', D.PendienteFacturacion, { p: '#e3eef2', s: '#f0b429', t: '#f8d36a' });
export const ReclamoGarantiaColorIcon = crearColor('ReclamoGarantia', D.ReclamoGarantia, { p: '#e0983c', s: '#d62f2f', t: '#f6c97a' });
export const ValeRequisicionColorIcon = crearColor('ValeRequisicion', D.ValeRequisicion, { p: '#ececec', s: '#8f8f8f' });
export const RegistroAuxiliarColorIcon = crearColor('RegistroAuxiliar', D.RegistroAuxiliar, { p: '#e8c987', s: '#a3792a', t: '#e4ebf1' });
export const SepararColorIcon = crearColor('Separar', D.Separar, { p: '#fdd270', t: '#ffffff' });
export const RegistroResumenColorIcon = crearColor('RegistroResumen', D.RegistroResumen, { p: '#56b9f7', t: '#e3ecec' });
export const RegistroColorIcon = crearColor('Registro', D.Registro, { p: '#b39a6a', s: '#a3865a', t: '#f1f2fb' });

export const TicketColorIcon = crearColor('Ticket', D.TicketRico, RICA);
export const TarifasColorIcon = crearColor('Tarifas', D.TarifasRico, RICA);
export const TabColorIcon = crearColor('Tab', D.TabRico, RICA);
export const SugerirColorIcon = crearColor('Sugerir', D.SugerirRico, RICA);
export const VehiculoIcoColorIcon = crearColor('VehiculoIco', D.VehiculoIcoRico, RICA);
export const TomaInventarioColorIcon = crearColor('TomaInventario', D.TomaInventarioRico, RICA);
export const VencimientoAcumuladaColorIcon = crearColor('VencimientoAcumulada', D.VencimientoAcumuladaRico, RICA);
export const VencimientoDetalleColorIcon = crearColor('VencimientoDetalle', D.VencimientoDetalleRico, RICA);
export const UploadColorIcon = crearColor('Upload', D.UploadRico, RICA);
export const VencimientosColorIcon = crearColor('Vencimientos', D.VencimientosRico, RICA);
export const VendedorColorIcon = crearColor('Vendedor', D.VendedorRico, RICA);
export const StockValorizadoColorIcon = crearColor('StockValorizado', D.StockValorizadoRico, RICA);
export const ToolsColorIcon = crearColor('Tools', D.ToolsRico, RICA);
export const TransferenciasColorIcon = crearColor('Transferencias', D.TransferenciasRico, RICA);
export const RepPersonalColorIcon = crearColor('RepPersonal', D.RepPersonalRico, RICA);
export const RepReembolsoColorIcon = crearColor('RepReembolso', D.RepReembolsoRico, RICA);
export const RepRegComprasColorIcon = crearColor('RepRegCompras', D.RepRegComprasRico, RICA);
export const RepTardanzasColorIcon = crearColor('RepTardanzas', D.RepTardanzasRico, RICA);
export const ReportColorIcon = crearColor('Report', D.ReportRico, RICA);
export const ResumenGeneralColorIcon = crearColor('ResumenGeneral', D.ResumenGeneralRico, RICA);
export const ScdrespsColorIcon = crearColor('Scdresps', D.ScdrespsRico, RICA);
export const SemaforoColorIcon = crearColor('Semaforo', D.SemaforoRico, RICA);
export const SepararRicoColorIcon = crearColor('Separar', D.SepararRico, RICA);
export const SepararAmbosColorIcon = crearColor('SepararAmbos', D.SepararAmbosRico, RICA);
export const SesionIconColorIcon = crearColor('SesionIcon', D.SesionIconRico, RICA);
export const SobregiroColorIcon = crearColor('Sobregiro', D.SobregiroRico, RICA);
export const SolGastosColorIcon = crearColor('SolGastos', D.SolGastosRico, RICA);
export const SolicGarantiaColorIcon = crearColor('SolicGarantia', D.SolicGarantiaRico, RICA);
export const ReordenarColorIcon = crearColor('Reordenar', D.ReordenarRico, RICA);
export const RepAsistenciaColorIcon = crearColor('RepAsistencia', D.RepAsistenciaRico, RICA);

export const ICONOS_COLOR = {
  ACTIVITL: ActivitlColorIcon,
  Abajo: AbajoColorIcon,
  Aceptar: AceptarColorIcon,
  Act_2: Act2ColorIcon,
  Act_cuenta: ActCuentaColorIcon,
  Actualizar: ActualizarColorIcon,
  Afp: AfpColorIcon,
  Agregar: AgregarColorIcon,
  'Anular.png': AnularPngColorIcon,
  'Anular.jpg': AnularJpgColorIcon,
  Anular_ico: AnularIcoColorIcon,
  Aprobar: AprobarColorIcon,
  Aprobar_Mas: AprobarMasColorIcon,
  Arriba: ArribaColorIcon,
  Asig_Horario: AsigHorarioColorIcon,
  Asig_Jefes: AsigJefesColorIcon,
  Atend_Prov: AtendProvColorIcon,
  AtenderMasivo: AtenderMasivoColorIcon,
  Balance: BalanceColorIcon,
  Boleta: BoletaColorIcon,
  Borrar: BorrarColorIcon,
  'Buscar.ico': BuscarIcoColorIcon,
  'Buscar.png': BuscarPngColorIcon,
  COA: CoaColorIcon,
  CajaBanco: CajaBancoColorIcon,
  Canjear: CanjearColorIcon,
  Capacitacion: CapacitacionColorIcon,
  Cargo_per: CargoPerColorIcon,
  Cerrar: CerrarColorIcon,
  Cerrar_Pr: CerrarPrColorIcon,
  Check: CheckColorIcon,
  Check1: Check1ColorIcon,
  Compra_Con: CompraConColorIcon,
  Compras: ComprasColorIcon,
  Consignaciones: CompraConColorIcon,
  Cont_diario: ContDiarioColorIcon,
  CrdFle04: CrdFle04ColorIcon,
  CrdFle12: CrdFle12ColorIcon,
  CrdFle13: CrdFle13ColorIcon,
  Cronograma_ico: CronogramaIcoColorIcon,
  Derecha: DerechaColorIcon,
  DesExcelDsctos: DesExcelDsctosColorIcon,
  DesExcelIng: DesExcelIngColorIcon,
  Desc_planilla: DescPlanillaColorIcon,
  DescargarExcel: DescargarExcelColorIcon,
  Descuentos_Per: DescuentosPerColorIcon,
  Deshacer: DeshacerColorIcon,
  Dolar: DolarColorIcon,
  Dscto: DsctoColorIcon,
  Editar: EditarColorIcon,
  'Eliminar.ico': EliminarIcoColorIcon,
  'Eliminar.png': EliminarPngColorIcon,
  Embarque: EmbarqueColorIcon,
  Empresa: EmpresaColorIcon,
  Enviar: EnviarColorIcon,
  EnviarCorreos: EnviarPrColorIcon,
  Enviar_Pr: EnviarPrColorIcon,
  Equipos: EquiposColorIcon,
  Factura: FacturaColorIcon,
  FacturaGuia: FacturaGuiaColorIcon,
  FacturarGuias: FacturarGuiasColorIcon,
  Fecha: FechaColorIcon,
  FotoNoDisponible: FotoNoDisponibleColorIcon,
  GRAPH07: Graph07ColorIcon,
  Gears: GearsColorIcon,
  Generar: GenerarColorIcon,
  GuiaDevolucion: GuiaDevolucionColorIcon,
  GuiaRemision: GuiaRemisionColorIcon,
  Grabar: GrabarColorIcon,
  HE_icon: HeIconColorIcon,
  Horarios: HorariosColorIcon,
  HorsExt: HorsExtColorIcon,
  Ico_reloj2: IcoReloj2ColorIcon,
  ImgApptRecur: ImgApptRecurColorIcon,
  ImgSendReceive: ImgSendReceiveColorIcon,
  ImpExcelIng: ImpExcelIngColorIcon,
  ImportarExcel: ImportarExcelColorIcon,
  'Impresora.ico': ImpresoraIcoColorIcon,
  'Impresora.png': ImpresoraPngColorIcon,
  Ingresos: IngresosColorIcon,
  Ingresos_Per: IngresosPerColorIcon,
  Instruccion: InstruccionColorIcon,
  Izquierda: IzquierdaColorIcon,
  Job_Marca: JobMarcaColorIcon,
  Keys: KeysColorIcon,
  LectorHuellas: LectorHuellasColorIcon,
  LibDiario: LibDiarioColorIcon,
  LibMayor: LibMayorColorIcon,
  Libro_diario: LibroDiarioColorIcon,
  Libro_mayor: LibroMayorColorIcon,
  'Limpiar.png': LimpiarPngColorIcon,
  'Limpiar.jpg': LimpiarJpgColorIcon,
  Llamada: LlamadaColorIcon,
  Lupa: LupaColorIcon,
  Mail20: Mail20ColorIcon,
  ManoHaciaAbajo: ManoHaciaAbajoColorIcon,
  Material: MaterialColorIcon,
  Maximun: MaximunColorIcon,
  Notas: NotasColorIcon,
  Nueva_Marcacion: NuevaMarcacionColorIcon,
  Nuevo_multiple: NuevoMultipleColorIcon,
  Office: OfficeColorIcon,
  Pagos: PagosColorIcon,
  about: AboutColorIcon,
  act_mail: ActMailColorIcon,
  actualizarCostos: ActualizarCostosColorIcon,
  acumulada: AcumuladaColorIcon,
  acwizard: AcwizardColorIcon,
  adicionarcontenedor: AdicionarcontenedorColorIcon,
  admin_48: Admin48ColorIcon,
  ajustarCostos: AjustarCostosColorIcon,
  almacen: AlmacenColorIcon,
  apor_planillas: AporPlanillasColorIcon,
  arbolnavidad: ArbolnavidadColorIcon,
  area_costo: AreaCostoColorIcon,
  area_per: AreaPerColorIcon,
  arqueo_caja: ArqueoCajaColorIcon,
  b2mining: B2miningColorIcon,
  bajar_estado: BajarEstadoColorIcon,
  bancos: BancosColorIcon,
  books_256: Books256ColorIcon,
  brcase_16: Brcase16ColorIcon,
  brcase_48: Brcase48ColorIcon,
  brocha: BrochaColorIcon,
  bundle_256: Bundle256ColorIcon,
  calendar: CalendarColorIcon,
  calendar_copiar: CalendarCopiarColorIcon,
  calendar_edit: CalendarEditColorIcon,
  cam_48: Cam48ColorIcon,
  camera: CameraColorIcon,
  car_256: Car256ColorIcon,
  cartera__2_: Cartera2ColorIcon,
  casa_aeropuerto: CasaAeropuertoColorIcon,
  cerrarmes: CerrarmesColorIcon,
  chequeo: ChequeoColorIcon,
  clases: ClasesColorIcon,
  cleanCliente: CleanClienteColorIcon,
  cliente: ClienteColorIcon,
  comision_ico: ComisionIcoColorIcon,
  compra: CompraColorIcon,
  condensados: CondensadosColorIcon,
  consolidado: ConsolidadoColorIcon,
  contraseña: ContrasenaColorIcon,
  contrato: ContratoColorIcon,
  corona: CoronaColorIcon,
  costoVenta: CostoVentaColorIcon,
  costos: CostosColorIcon,
  cot_ico: CotIcoColorIcon,
  cotizacion: CotizacionColorIcon,
  cotizacionTaller: CotizacionTallerColorIcon,
  credito: CreditoColorIcon,
  creditos: CreditosColorIcon,
  cta_destino: CtaDestinoColorIcon,
  cta_png: CtaPngColorIcon,
  ctasPagar: CtasPagarColorIcon,
  ctas_ctes: CtasCtesColorIcon,
  ctas_ctes_pend: CtasCtesPendColorIcon,
  cuadrarCierre: CuadrarCierreColorIcon,
  cuenta_mas: CuentaMasColorIcon,
  cuentasCobrar: CuentasCobrarColorIcon,
  cuentasCorrientes: CuentasCorrientesColorIcon,
  des_per_mas: DesPerMasColorIcon,
  despacho: DespachoColorIcon,
  detalle: DetalleColorIcon,
  detalledescuento: DsctoColorIcon,
  diarioAlmacen: DiarioAlmacenColorIcon,
  diarioPago: DiarioPagoColorIcon,
  doc: DocColorIcon,
  doc_ingresos: NuevoMultipleColorIcon,
  doc_elec_descargar: DocElecDescargarColorIcon,
  doc_elec_eliminar: DocElecEliminarColorIcon,
  doc_elec_generar: DocElecGenerarColorIcon,
  doc_elec_lupa: DocElecLupaColorIcon,
  documentosEmitidos: DocumentosEmitidosColorIcon,
  documentos: Books256ColorIcon,
  editar2: Editar2ColorIcon,
  equipo_mar: EquipoMarColorIcon,
  equipo_telefonico: EquipoTelefonicoColorIcon,
  excel: ExcelColorIcon,
  excel_ico: ExcelIcoColorIcon,
  exp_lab: ExpLabColorIcon,
  fact_darbaja: FactDarbajaColorIcon,
  fact_descargar: FactDescargarColorIcon,
  fact_generar: FactGenerarColorIcon,
  fact_lupa: FactLupaColorIcon,
  fal_masivo: FalMasivoColorIcon,
  factoresrubros: AporPlanillasColorIcon,
  faltas_ico: FaltasIcoColorIcon,
  familiares: FamiliaresColorIcon,
  gasto_real_rubro: GastoRealRubroColorIcon,
  gasto_real_total: GastoRealTotalColorIcon,
  gasto_viaje: GastoViajeColorIcon,
  gastos: GastosColorIcon,
  generar_mas: GenerarMasColorIcon,
  generarPeriodo: GenerarPeriodoColorIcon,
  gerente: GerenteColorIcon,
  grafica: GraficaColorIcon,
  he_planillas: HePlanillasColorIcon,
  help: HelpColorIcon,
  hrs_equipo: HrsEquipoColorIcon,
  ico_reloj: IcoRelojColorIcon,
  ico_reloj3: IcoReloj3ColorIcon,
  ico_reloj4: IcoReloj4ColorIcon,
  idioma: IdiomaColorIcon,
  imagen_fondo: ImagenFondoColorIcon,
  img_48: Img48ColorIcon,
  importacion: ImportacionColorIcon,
  indicadores1: Indicadores1ColorIcon,
  indicadores2: Indicadores2ColorIcon,
  indicadores3: Indicadores3ColorIcon,
  indicadorico2: Indicadorico2ColorIcon,
  indicadorico3: Indicadorico3ColorIcon,
  informatica: InformaticaColorIcon,
  ing_ctas: IngCtasColorIcon,
  ing_per_mas: IngPerMasColorIcon,
  ing_planillas: IngPlanillasColorIcon,
  interno: InternoColorIcon,
  inventario: InventarioColorIcon,
  laptop_16: Laptop16ColorIcon,
  laptop_48: Laptop48ColorIcon,
  letrasAceptadas: LetrasAceptadasColorIcon,
  librosCont: LibrosContColorIcon,
  linea_telefonica: LineaTelefonicaColorIcon,
  linkico: LinkicoColorIcon,
  liquidacion: LiquidacionColorIcon,
  login: LoginColorIcon,
  mantenimiento: MantenimientoColorIcon,
  marca: MarcaColorIcon,
  mayor_aux: MayorAuxColorIcon,
  mensualesxcliente: Brcase48ColorIcon,
  mercaderia: MercaderiaColorIcon,
  mesa_control: MesaControlColorIcon,
  modelo_telefono: ModeloTelefonoColorIcon,
  motores: MotoresColorIcon,
  movimiento: MovimientoColorIcon,
  mp_icon: MpIconColorIcon,
  mti: MovimientoColorIcon,
  observacion: ObservacionColorIcon,
  ordenesCompra: OrdenesCompraColorIcon,
  partidas: PartidasColorIcon,
  precioCore: PrecioCoreColorIcon,
  preciofabricantes: CreditosColorIcon,
  presupuesto_venta: PendienteFacturacionColorIcon,
  pendiente_facturacion: PendienteFacturacionColorIcon,
  precios: DolarColorIcon,
  reclamoGarantia: ReclamoGarantiaColorIcon,
  resumenBoletas: EnviarPrColorIcon,
  valeRequisicion: ValeRequisicionColorIcon,
  registroAuxiliar: RegistroAuxiliarColorIcon,
  Separar__: SepararColorIcon,
  separarOrden: SepararColorIcon,
  registroResumen: RegistroResumenColorIcon,
  registro: RegistroColorIcon,
  Ticket: TicketColorIcon,
  Tarifas: TarifasColorIcon,
  Tab: TabColorIcon,
  Sugerir: SugerirColorIcon,
  vehiculo_ico: VehiculoIcoColorIcon,
  tomaInventario: TomaInventarioColorIcon,
  vencimientoAcumulada: VencimientoAcumuladaColorIcon,
  vencimientoDetalle: VencimientoDetalleColorIcon,
  upload: UploadColorIcon,
  vencimientos: VencimientoAcumuladaColorIcon,
  vendedor: VendedorColorIcon,
  stockValorizado: StockValorizadoColorIcon,
  Tools: ToolsColorIcon,
  transferencias: TransferenciasColorIcon,
  rep_personal: RepPersonalColorIcon,
  rep_Reembolso: RepReembolsoColorIcon,
  Rep_RegCompras: RepRegComprasColorIcon,
  Rep_Tardanzas: RepTardanzasColorIcon,
  Report: ReportColorIcon,
  resumenGeneral: ResumenGeneralColorIcon,
  SCDRESPS: ScdrespsColorIcon,
  Semaforo: SemaforoColorIcon,
  separar: SepararColorIcon,
  separar_: SepararAmbosColorIcon,
  sesion_icon: SesionIconColorIcon,
  sobregiro: SobregiroColorIcon,
  Sol_Gastos: SolGastosColorIcon,
  Solic_Garantia: SolicGarantiaColorIcon,
  Reordenar: ReordenarColorIcon,
  Rep_Asistencia: RepAsistenciaColorIcon,
} as const;

export type NombreIconoColor = keyof typeof ICONOS_COLOR;
