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
export const Books256ColorIcon = crearColor('Books256', D.Books, { p: '#2f78c4', s: '#4a9a4a' });
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
  diarioAlmacen: DiarioAlmacenColorIcon,
  diarioPago: DiarioPagoColorIcon,
  doc: DocColorIcon,
  doc_elec_descargar: DocElecDescargarColorIcon,
  doc_elec_eliminar: DocElecEliminarColorIcon,
  doc_elec_generar: DocElecGenerarColorIcon,
  doc_elec_lupa: DocElecLupaColorIcon,
  documentosEmitidos: DocumentosEmitidosColorIcon,
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
  mercaderia: MercaderiaColorIcon,
  mesa_control: MesaControlColorIcon,
  modelo_telefono: ModeloTelefonoColorIcon,
  motores: MotoresColorIcon,
  movimiento: MovimientoColorIcon,
  mp_icon: MpIconColorIcon,
  observacion: ObservacionColorIcon,
  ordenesCompra: OrdenesCompraColorIcon,
  partidas: PartidasColorIcon,
} as const;

export type NombreIconoColor = keyof typeof ICONOS_COLOR;
