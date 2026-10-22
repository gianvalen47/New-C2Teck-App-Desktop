/**
 * Iconos SIGECOM a COLOR (estilo Lucide con relleno). 24x24, trazo + relleno por icono.
 * Cada icono tiene su propia paleta tomada del icono original.
 * Aceptan las mismas props que lucide-react (size, strokeWidth, className...).
 * Nota: `color` no cambia el relleno; el relleno viene de la paleta de cada icono.
 *
 * Uso:
 *   import { TaxiColorIcon, ICONOS_COLOR } from './iconos-sigecom-color-nuevos2';
 *   <TaxiColorIcon size={24} />
 *   const Icono = ICONOS_COLOR['Taxi']; <Icono />   // clave = nombre original del archivo
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
        if (a.stroke === undefined) a.stroke = k ? trazo(String(k), pal) : TINTA;
      }
      return [tag, a];
    }) as unknown as IconNode,
  );

/* ---------- diseños (f = relleno, k = trazo; P/S/T = colores de la paleta, W = blanco, K = tinta) ---------- */
const D: Record<string, Nodo[]> = {
  GastoRealRubroRico: [
    ['path', { d: 'M10 2V22M14 2V22', fill: 'none', stroke: '#1b5e20', strokeWidth: 2 }],
    ['path', { d: 'M17.5 5.5H9a3.25 3.25 0 0 0 0 6.5h6a3.25 3.25 0 0 1 0 6.5H6', fill: 'none', stroke: '#1b5e20', strokeWidth: 2 }],
  ],
  ModelosRico: [
    ['rect', { x: 2.2, y: 1.6, width: 17, height: 20.8, rx: 2.6, fill: '#111111', stroke: 'none' }],
    ['rect', { x: 4.6, y: 3.4, width: 11.4, height: 17.2, rx: 0.4, fill: '#ffffff', stroke: 'none' }],
    ['rect', { x: 14.6, y: 3.4, width: 1.4, height: 17.2, rx: 0, fill: '#c9c9c9', stroke: 'none' }],
    ['rect', { x: 6.6, y: 7.4, width: 6.6, height: 2.8, rx: 0, fill: '#111111', stroke: 'none' }],
    ['path', { d: 'M19.2 4.2 L22 2.8 L20.4 5.8 L22 8.2 L19.2 7.2Z', fill: '#111111', stroke: 'none' }],
  ],
  PlanTelefonicoRico: [
    ['ellipse', { cx: 13.4, cy: 20.4, rx: 9.6, ry: 2.4, fill: '#2a2a2a', stroke: 'none' }],
    ['path', { d: 'M12.4 2C7.2 2 3.2 5.7 3.2 10.4c0 2.4 1.1 4.6 2.9 6.2L4.4 21l5.4-2.8c.8.2 1.7.3 2.6.3 5.2 0 9.2-3.7 9.2-8.4S17.6 2 12.4 2Z', fill: '#ffffff', stroke: '#222222', strokeWidth: 1.3 }],
    ['path', { d: 'M8.8 7.4c-.5.5-.6 1.4-.2 2.4 1.3 3 3.4 5 6.4 6.4 1 .4 1.9.3 2.4-.2l.6-.7c.3-.4.2-.9-.2-1.2l-1.6-1.1c-.4-.2-.8-.2-1.1.1l-.5.5c-1.6-.8-2.8-2-3.6-3.6l.5-.5c.3-.3.3-.7.1-1.1L10.5 7.1c-.3-.4-.8-.5-1.2-.2Z', fill: '#222222', stroke: 'none' }],
  ],
  TaxiRico: [
    ['path', { d: 'M6.4 9.4L8.2 5.2C8.5 4.6 9 4.4 9.6 4.4h4.8c.6 0 1.1.2 1.4.8l1.8 4.2Z', fill: '#8fb4e0', stroke: '#2f5f9e', strokeWidth: 0.8 }],
    ['path', { d: 'M8 9L9.2 6h5.6L16 9Z', fill: '#2b3f5c', stroke: 'none' }],
    ['rect', { x: 2.2, y: 9, width: 19.6, height: 8.2, rx: 2.6, fill: '#5b8fd0', stroke: '#2f5f9e', strokeWidth: 0.9 }],
    ['rect', { x: 2.2, y: 13.6, width: 19.6, height: 3.6, rx: 1.4, fill: '#3f73b8', stroke: 'none' }],
    ['rect', { x: 3.2, y: 10.4, width: 3.6, height: 2.4, rx: 1.1, fill: '#eaf2ff', stroke: '#2f5f9e', strokeWidth: 0.5 }],
    ['rect', { x: 17.2, y: 10.4, width: 3.6, height: 2.4, rx: 1.1, fill: '#eaf2ff', stroke: '#2f5f9e', strokeWidth: 0.5 }],
    ['rect', { x: 9, y: 13, width: 6, height: 2.2, rx: 0.6, fill: '#b5c4d8', stroke: '#2f5f9e', strokeWidth: 0.5 }],
    ['rect', { x: 3.4, y: 16.2, width: 3.8, height: 4.8, rx: 1.2, fill: '#262a30', stroke: 'none' }],
    ['rect', { x: 16.8, y: 16.2, width: 3.8, height: 4.8, rx: 1.2, fill: '#262a30', stroke: 'none' }],
    ['path', { d: 'M3.6 9.8C5 9.2 7 9 8 9', fill: 'none', stroke: '#a9c8ee', strokeWidth: 0.6 }],
  ],
  TesAsientosRico: [
    ['rect', { x: 4.2, y: 1.6, width: 15.6, height: 20.8, rx: 2.2, fill: '#b0b2b8', stroke: '#55575c', strokeWidth: 0.9 }],
    ['rect', { x: 5.4, y: 2.8, width: 13.2, height: 18.4, rx: 1.4, fill: '#d6d8dd', stroke: 'none' }],
    ['rect', { x: 6.4, y: 3.8, width: 11.2, height: 4.4, rx: 0.6, fill: '#8fb4e0', stroke: '#4a6a95', strokeWidth: 0.6 }],
    ['path', { d: 'M7.4 5.2H12', fill: 'none', stroke: '#d9e8f8', strokeWidth: 0.6 }],
    ['rect', { x: 6.6, y: 9.8, width: 3.2, height: 2.5, rx: 0.4, fill: '#9aa0bf', stroke: '#6d7396', strokeWidth: 0.4 }],
    ['rect', { x: 10.4, y: 9.8, width: 3.2, height: 2.5, rx: 0.4, fill: '#9aa0bf', stroke: '#6d7396', strokeWidth: 0.4 }],
    ['rect', { x: 14.2, y: 9.8, width: 3.2, height: 2.5, rx: 0.4, fill: '#9aa0bf', stroke: '#6d7396', strokeWidth: 0.4 }],
    ['rect', { x: 6.6, y: 12.9, width: 3.2, height: 2.5, rx: 0.4, fill: '#9aa0bf', stroke: '#6d7396', strokeWidth: 0.4 }],
    ['rect', { x: 10.4, y: 12.9, width: 3.2, height: 2.5, rx: 0.4, fill: '#9aa0bf', stroke: '#6d7396', strokeWidth: 0.4 }],
    ['rect', { x: 14.2, y: 12.9, width: 3.2, height: 2.5, rx: 0.4, fill: '#9aa0bf', stroke: '#6d7396', strokeWidth: 0.4 }],
    ['rect', { x: 6.6, y: 16, width: 3.2, height: 2.5, rx: 0.4, fill: '#9aa0bf', stroke: '#6d7396', strokeWidth: 0.4 }],
    ['rect', { x: 10.4, y: 16, width: 3.2, height: 2.5, rx: 0.4, fill: '#9aa0bf', stroke: '#6d7396', strokeWidth: 0.4 }],
    ['rect', { x: 14.2, y: 16, width: 3.2, height: 2.5, rx: 0.4, fill: '#9aa0bf', stroke: '#6d7396', strokeWidth: 0.4 }],
    ['rect', { x: 6.6, y: 19.1, width: 3.2, height: 2.5, rx: 0.4, fill: '#9aa0bf', stroke: '#6d7396', strokeWidth: 0.4 }],
    ['rect', { x: 10.4, y: 19.1, width: 3.2, height: 2.5, rx: 0.4, fill: '#9aa0bf', stroke: '#6d7396', strokeWidth: 0.4 }],
    ['rect', { x: 14.2, y: 19.1, width: 3.2, height: 2.5, rx: 0.4, fill: '#454a78', stroke: '#6d7396', strokeWidth: 0.4 }],
  ],
  TortaRico: [
    ['ellipse', { cx: 12, cy: 20.2, rx: 9.8, ry: 2.2, fill: '#dbe9f7', stroke: '#8fb0d4', strokeWidth: 0.7 }],
    ['path', { d: 'M3.8 13v5.4c0 1.5 3.6 2.6 8.2 2.6s8.2-1.1 8.2-2.6V13Z', fill: '#c9741a', stroke: '#7d4208', strokeWidth: 0.9 }],
    ['ellipse', { cx: 12, cy: 13, rx: 8.2, ry: 3, fill: '#fff6e6', stroke: '#8a5a2a', strokeWidth: 0.9 }],
    ['path', { d: 'M3.8 13c0 1.2 1 1.9 2.2 2.3.6.2 1-.4 1.1-1.2.1-.9.8-1.2 1.4-.4.7.9 1 1.9 2 1.9s1.3-.9 1.8-1.7c.5-.8 1.3-.8 1.7 0 .5 1 1 1.8 2 1.6 1-.2 1.2-1 1.5-1.7.3-.7 1-.7 1.4.1.3.6.5 1.2.9 1.1 1-.3 1.4-1 1.4-1.8-.2 1.8-3.8 3-8.2 3S3.8 14.8 3.8 13Z', fill: '#ffffff', stroke: 'none' }],
    ['rect', { x: 10.9, y: 5.6, width: 2.2, height: 7, rx: 0.4, fill: '#e88a8a', stroke: '#a84a4a', strokeWidth: 0.6 }],
    ['path', { d: 'M12 1.4c1.5 1.4 1.7 3 0 4-1.7-1-1.5-2.6 0-4Z', fill: '#ff7a1a', stroke: '#c24a00', strokeWidth: 0.5 }],
    ['path', { d: 'M12 3.2c.7.8.8 1.6 0 2.2-.8-.6-.7-1.4 0-2.2Z', fill: '#ffd83a', stroke: 'none' }],
  ],
  TrasladarCostosRico: [
    ['path', { d: 'M4.6 2.6h9.4l4.8 4.8v14H4.6Z', fill: '#f2f2f2', stroke: '#b9b9b9', strokeWidth: 0.9 }],
    ['path', { d: 'M14 2.6v4.8h4.8', fill: '#cfcfcf', stroke: '#b9b9b9', strokeWidth: 0.7 }],
    ['rect', { x: 10.6, y: 2.4, width: 2.2, height: 2.2, rx: 0, fill: '#9a9a9a', stroke: 'none' }],
    ['path', { d: 'M6.4 11.2h7V8.2l8 6.2-8 6.2v-3H6.4Z', fill: '#b81818', stroke: '#6e0a0a', strokeWidth: 0.8 }],
    ['path', { d: 'M8 12.6H13.6', fill: 'none', stroke: '#e45a5a', strokeWidth: 0.7 }],
  ],
  VacacionesRico: [
    ['ellipse', { cx: 15, cy: 22, rx: 6.4, ry: 1.1, fill: '#d5d8dc', stroke: 'none' }],
    ['rect', { x: 11.3, y: 9, width: 1.5, height: 12.6, rx: 0.6, fill: '#c98d5a', stroke: '#8a5a2a', strokeWidth: 0.6 }],
    ['path', { d: 'M2 11.4C2.4 6 6.8 2.4 12 2.4s9.6 3.6 10 9c-2.2-1.8-4.2-.8-6 0C14.8 10.2 13.4 9.8 12 9.8s-2.8.4-4 1.6C6.2 10.6 4.2 9.6 2 11.4Z', fill: '#3cae3c', stroke: '#1b6b1b', strokeWidth: 0.9 }],
    ['path', { d: 'M8.6 4.2C9.6 3.4 10.8 3.2 12 3.2s2.4.2 3.4 1L15 9.9C14.2 9.6 13.2 9.5 12 9.5S9.8 9.6 9 9.9Z', fill: '#eef4fb', stroke: 'none' }],
    ['path', { d: 'M12 1.2V2.6', fill: 'none', stroke: '#8a5a2a', strokeWidth: 1 }],
  ],
  VarPlanillasRico: [
    ['rect', { x: 2.8, y: 13, width: 4.6, height: 8.2, rx: 0.6, fill: '#3f9bc9', stroke: '#1d6f98', strokeWidth: 0.8 }],
    ['rect', { x: 3.4, y: 13.6, width: 1.4, height: 7.0, rx: 0.3, fill: '#8fcbe6', stroke: 'none' }],
    ['rect', { x: 9.7, y: 9.8, width: 4.6, height: 11.4, rx: 0.6, fill: '#3f9bc9', stroke: '#1d6f98', strokeWidth: 0.8 }],
    ['rect', { x: 10.3, y: 10.4, width: 1.4, height: 10.2, rx: 0.3, fill: '#8fcbe6', stroke: 'none' }],
    ['rect', { x: 16.6, y: 6.2, width: 4.6, height: 15, rx: 0.6, fill: '#3f9bc9', stroke: '#1d6f98', strokeWidth: 0.8 }],
    ['rect', { x: 17.2, y: 6.8, width: 1.4, height: 13.8, rx: 0.3, fill: '#8fcbe6', stroke: 'none' }],
    ['path', { d: 'M1.6 21.4H22.4', fill: 'none', stroke: '#9aa7b3', strokeWidth: 0.8 }],
    ['path', { d: 'M2.4 9.6C3 5.8 5.8 3.2 9.6 3.2V1.2L14.4 4.4 9.6 7.6V5.6C7.4 5.8 5.8 7 5 9.6Z', fill: '#7fd22e', stroke: '#3f8a10', strokeWidth: 0.8 }],
    ['path', { d: 'M4 8.4C4.8 6.2 6.4 5 8.6 4.8', fill: 'none', stroke: '#c7f27a', strokeWidth: 0.6 }],
  ],
  CargoPerRico: [
    ['path', { d: 'M-6.6 16.4C-6.6 11 -3.8 9.2 0 9.2s6.6 1.8 6.6 7.2Z', fill: '#8aa2b6', stroke: '#3a3a3a', strokeWidth: 0.7, transform: 'translate(6.2 3.6) scale(0.9)' }],
    ['circle', { cx: 0, cy: 4.6, r: 3.8, fill: '#e6b48f', stroke: '#9a6a4a', strokeWidth: 0.6, transform: 'translate(6.2 3.6) scale(0.9)' }],
    ['path', { d: 'M-4.4 3.4C-4.4 -1.2 -1.6 -2.4 0 -2.4s4.4 1.2 4.4 5.8Z', fill: '#f3c418', stroke: '#5a4a10', strokeWidth: 0.7, transform: 'translate(6.2 3.6) scale(0.9)' }],
    ['path', { d: 'M-5.2 3.4H5.2', fill: 'none', stroke: '#f3c418', strokeWidth: 1.3, transform: 'translate(6.2 3.6) scale(0.9)' }],
    ['path', { d: 'M-6.6 16.4C-6.6 11 -3.8 9.2 0 9.2s6.6 1.8 6.6 7.2Z', fill: '#f1ede6', stroke: '#3a3a3a', strokeWidth: 0.7, transform: 'translate(17.8 3.8) scale(0.9)' }],
    ['circle', { cx: 0, cy: 4.6, r: 3.8, fill: '#f2c8a6', stroke: '#9a6a4a', strokeWidth: 0.6, transform: 'translate(17.8 3.8) scale(0.9)' }],
    ['path', { d: 'M-4.4 3.4C-4.4 -1.2 -1.6 -2.4 0 -2.4s4.4 1.2 4.4 5.8Z', fill: '#c72424', stroke: '#7a1010', strokeWidth: 0.7, transform: 'translate(17.8 3.8) scale(0.9)' }],
    ['path', { d: 'M-5.2 3.4H5.2', fill: 'none', stroke: '#c72424', strokeWidth: 1.3, transform: 'translate(17.8 3.8) scale(0.9)' }],
    ['path', { d: 'M-8 18.6C-8 11.6 -4 9.6 0 9.6s8 2 8 9Z', fill: '#4a4a4a', stroke: '#1a1a1a', strokeWidth: 0.8, transform: 'translate(12 6) scale(0.95)' }],
    ['path', { d: 'M-2.2 9.8L0 14.6 2.2 9.8Z', fill: '#ffffff', stroke: '#1a1a1a', strokeWidth: 0.5, transform: 'translate(12 6) scale(0.95)' }],
    ['path', { d: 'M0 11.6V14', fill: 'none', stroke: '#222', strokeWidth: 0.9, transform: 'translate(12 6) scale(0.95)' }],
    ['circle', { cx: 0, cy: 5.2, r: 4.2, fill: '#fbe3d2', stroke: '#8a6a52', strokeWidth: 0.6, transform: 'translate(12 6) scale(0.95)' }],
    ['path', { d: 'M-4.4 4.6C-5 -.6 -1.4 -1.6 1 -1.2 3.8 -.7 5.2 1.4 4.4 4.6 3.4 2.4 -1.4 1.6 -4.4 4.6Z', fill: '#1a1a1a', stroke: 'none', transform: 'translate(12 6) scale(0.95)' }],
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

export const GastoRealRubroColorIcon = crearColor('GastoRealRubro', D.GastoRealRubroRico, RICA);
export const ModelosColorIcon = crearColor('Modelos', D.ModelosRico, RICA);
export const PlanTelefonicoColorIcon = crearColor('PlanTelefonico', D.PlanTelefonicoRico, RICA);
export const TaxiColorIcon = crearColor('Taxi', D.TaxiRico, RICA);
export const TesAsientosColorIcon = crearColor('TesAsientos', D.TesAsientosRico, RICA);
export const TortaColorIcon = crearColor('Torta', D.TortaRico, RICA);
export const TrasladarCostosColorIcon = crearColor('TrasladarCostos', D.TrasladarCostosRico, RICA);
export const VacacionesColorIcon = crearColor('Vacaciones', D.VacacionesRico, RICA);
export const VarPlanillasColorIcon = crearColor('VarPlanillas', D.VarPlanillasRico, RICA);
export const CargoPerColorIcon = crearColor('CargoPer', D.CargoPerRico, RICA);
export const RelojAvisoColorIcon = crearColor('RelojAviso', D.RelojAvisoRico, RICA);

export const ICONOS_COLOR = {
  gasto_real_rubro: GastoRealRubroColorIcon,
  modelos: ModelosColorIcon,
  plan_telefonico: PlanTelefonicoColorIcon,
  Taxi: TaxiColorIcon,
  tes_asientos: TesAsientosColorIcon,
  torta: TortaColorIcon,
  trasladarCostos: TrasladarCostosColorIcon,
  vacaciones: VacacionesColorIcon,
  var_planillas: VarPlanillasColorIcon,
  Cargo_per: CargoPerColorIcon,
  Reloj_Aviso: RelojAvisoColorIcon,
} as const;

export type NombreIconoColor = keyof typeof ICONOS_COLOR;
