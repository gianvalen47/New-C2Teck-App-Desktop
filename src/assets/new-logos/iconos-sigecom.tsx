/**
 * Iconos personalizados estilo Lucide (24x24, trazo, currentColor).
 * Se crean con `createLucideIcon`, así que aceptan las mismas props que
 * cualquier icono de lucide-react: size, color, strokeWidth, className, etc.
 *
 * Uso:
 *   import { MonedaIcon, ICONOS } from './iconos-sigecom';
 *   <MonedaIcon size={20} />
 *   const Icono = ICONOS['Moneda']; <Icono />   // clave = nombre original del archivo
 *   (incluye también los iconos A–Z: <AnularIcon />, ICONOS['doc_elec_lupa'], etc.;
 *    si varios archivos comparten nombre, la clave lleva la extensión: ICONOS['Anular.png'])
 */
import { createLucideIcon, type IconNode } from 'lucide-react';

type Nodo = [tag: string, attrs: Record<string, string>];

const n = (v: number | string) => String(v);
const p = (d: string): Nodo => ['path', { d }];
const circ = (cx: number, cy: number, r: number): Nodo => ['circle', { cx: n(cx), cy: n(cy), r: n(r) }];
const rect = (x: number, y: number, w: number, h: number, rx?: number): Nodo => [
  'rect',
  { x: n(x), y: n(y), width: n(w), height: n(h), ...(rx !== undefined ? { rx: n(rx) } : {}) },
];
const elipse = (cx: number, cy: number, rx: number, ry: number): Nodo => [
  'ellipse',
  { cx: n(cx), cy: n(cy), rx: n(rx), ry: n(ry) },
];
const punto = (x: number, y: number): Nodo => p(`M${x} ${y}h.01`);

const crear = (nombre: string, nodos: Nodo[]) =>
  createLucideIcon(
    nombre,
    nodos.map(([tag, attrs], i) => [tag, { ...attrs, key: `${nombre}-${i}` }]) as unknown as IconNode,
  );

/* ---------- piezas reutilizables ---------- */
const HOJA = 'M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7Z';
const HOJA_ESQUINA = 'M14 2v4a2 2 0 0 0 2 2h4';
const hoja = (...extra: Nodo[]): Nodo[] => [p(HOJA), p(HOJA_ESQUINA), ...extra];

const ENGRANAJE =
  'M12.22 2h-.44a2 2 0 0 0-2 2v.18a2 2 0 0 1-1 1.73l-.43.25a2 2 0 0 1-2 0l-.15-.08a2 2 0 0 0-2.73.73l-.22.38a2 2 0 0 0 .73 2.73l.15.1a2 2 0 0 1 1 1.72v.51a2 2 0 0 1-1 1.74l-.15.09a2 2 0 0 0-.73 2.73l.22.38a2 2 0 0 0 2.73.73l.15-.08a2 2 0 0 1 2 0l.43.25a2 2 0 0 1 1 1.73V20a2 2 0 0 0 2 2h.44a2 2 0 0 0 2-2v-.18a2 2 0 0 1 1-1.73l.43-.25a2 2 0 0 1 2 0l.15.08a2 2 0 0 0 2.73-.73l.22-.39a2 2 0 0 0-.73-2.73l-.15-.08a2 2 0 0 1-1-1.74v-.5a2 2 0 0 1 1-1.74l.15-.09a2 2 0 0 0 .73-2.73l-.22-.38a2 2 0 0 0-2.73-.73l-.15.08a2 2 0 0 1-2 0l-.43-.25a2 2 0 0 1-1-1.73V4a2 2 0 0 0-2-2z';

const LLAVE =
  'M14.7 6.3a1 1 0 0 0 0 1.4l1.6 1.6a1 1 0 0 0 1.4 0l3.77-3.77a6 6 0 0 1-7.94 7.94l-6.91 6.91a2.12 2.12 0 0 1-3-3l6.91-6.91a6 6 0 0 1 7.94-7.94l-3.76 3.76z';
const herramientas = (): Nodo[] => [p(LLAVE), p('m3 3 6 6')];

const LIBRO =
  'M4 19.5v-15A2.5 2.5 0 0 1 6.5 2H19a1 1 0 0 1 1 1v18a1 1 0 0 1-1 1H6.5a1 1 0 0 1 0-5H20';

const CARPETA =
  'M20 20a2 2 0 0 0 2-2V8a2 2 0 0 0-2-2h-7.9a2 2 0 0 1-1.69-.9L9.6 3.9A2 2 0 0 0 7.93 3H4a2 2 0 0 0-2 2v13a2 2 0 0 0 2 2Z';

const CANASTA: Nodo[] = [
  p('m15 11-1 9'),
  p('m19 11-4-7'),
  p('M2 11h20'),
  p('m3.5 11 1.6 7.4a2 2 0 0 0 2 1.6h9.8a2 2 0 0 0 2-1.6l1.7-7.4'),
  p('M4.5 15.5h15'),
  p('m5 11 4-7'),
  p('m9 11 1 9'),
];

const BOLSA = 'M8 21c-3 0-4-2-4-4 0-3 3-6 5.5-8.5h5C17 11 20 14 20 17c0 2-1 4-4 4Z';
const BOLSA_BOCA = 'M9 3h6l-1.5 3h-3Z';
const SIGNO_DOLAR = ['M12 11.5v8.5', 'M14.5 13h-3a1.5 1.5 0 0 0 0 3h1a1.5 1.5 0 0 1 0 3h-3'];

const USUARIOS: Nodo[] = [
  p('M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2'),
  circ(9, 7, 4),
  p('M22 21v-2a4 4 0 0 0-3-3.87'),
  p('M16 3.13a4 4 0 0 1 0 7.75'),
];

const BOCA_TRISTE = (cx: number, cy: number): Nodo[] => [
  circ(cx, cy, 8),
  p(`M${cx + 3.5} ${cy + 3.5}s-1.2-2-3.5-2-3.5 2-3.5 2`),
  punto(cx - 3, cy - 2),
  punto(cx + 3, cy - 2),
];

/* ---------- iconos ---------- */
export const ModeloTelefonoIcon = crear('ModeloTelefono', [rect(5, 2, 14, 20, 2), punto(12, 18)]);
export const ModelosIcon = crear('Modelos', [rect(5, 2, 14, 20, 2), p('M9 2v8l2-1.5 2 1.5V2')]);
export const MonedaIcon = crear('Moneda', [
  elipse(12, 6, 7, 3),
  p('M5 6v4c0 1.7 3.1 3 7 3s7-1.3 7-3V6'),
  p('M5 10v4c0 1.7 3.1 3 7 3s7-1.3 7-3v-4'),
  p('M5 14v4c0 1.7 3.1 3 7 3s7-1.3 7-3v-4'),
]);
export const MotoresIcon = crear('Motores', [
  rect(6, 8, 12, 9, 1),
  p('M9 8V5h6v3'),
  p('M3 11v4'),
  p('M3 13h3'),
  p('M18 11h2v4h-2'),
  p('M9 17v3'),
  p('M15 17v3'),
]);
export const MovimientoCircularIcon = crear('MovimientoCircular', [
  p('M21 12a9 9 0 1 1-9-9'),
  p('M12 3l3 3-3 3'),
  circ(12, 12, 1),
]);
export const MovimientoCarpetaIcon = crear('MovimientoCarpeta', [p(CARPETA), p('M8 13h8'), p('m13 10 3 3-3 3')]);
export const MpIconIcon = crear('MpIcon', [
  circ(12, 13, 8),
  p('M12 9v4l2 2'),
  p('M5 3 2 6'),
  p('m22 6-3-3'),
  p('M6.38 18.7 4 21'),
  p('M17.64 18.67 20 21'),
]);
export const NotasIcon = crear('Notas', [rect(3, 3, 18, 18, 2), p('M7 8h6'), p('M7 12h10'), p('M7 16h8')]);
export const NuevaMarcacionIcon = crear('NuevaMarcacion', [
  p('M21 12a9 9 0 1 1-9-9'),
  p('M12 7v5l3 2'),
  p('M19 2v6'),
  p('M16 5h6'),
]);
export const NuevoIcon = crear('Nuevo', hoja());
export const NuevoMultipleIcon = crear('NuevoMultiple', [
  ...hoja(p('M12 11v6'), p('M9 14h6')),
  p('M2 8v12a2 2 0 0 0 2 2'),
]);
export const ObservacionIcon = crear('Observacion', [
  p('M12 20h9'),
  p('M16.376 3.622a1 1 0 0 1 3.002 3.002L7.368 18.635a2 2 0 0 1-.855.506l-2.872.838a.5.5 0 0 1-.62-.62l.838-2.872a2 2 0 0 1 .506-.854z'),
]);
export const OcurrenciasIcon = crear('Ocurrencias', [
  p('M15.5 3H5a2 2 0 0 0-2 2v14a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2V8.5L15.5 3Z'),
  p('M15 3v6h6'),
  p('M7 13h8'),
  p('M7 17h5'),
]);
export const OfficeIcon = crear('Office', [
  rect(4, 2, 16, 20, 2),
  p('M9 22v-4h6v4'),
  punto(8, 6), punto(12, 6), punto(16, 6),
  punto(8, 10), punto(12, 10), punto(16, 10),
  punto(8, 14), punto(12, 14), punto(16, 14),
]);
export const OportunidadNegocioIcon = crear('OportunidadNegocio', [
  rect(3, 3, 14, 12, 1),
  p('M3 8h14'),
  p('M9 8v7'),
  circ(17, 17, 4),
  p('M17 15.5v3'),
]);
export const OrdenesCompraIcon = crear('OrdenesCompra', [
  p('M4 22h16a2 2 0 0 0 2-2V4a2 2 0 0 0-2-2H8a2 2 0 0 0-2 2v16a2 2 0 0 1-2 2Zm0 0a2 2 0 0 1-2-2v-9c0-1.1.9-2 2-2h2'),
  p('M18 14h-8'),
  p('M15 18h-5'),
  p('M10 6h8v4h-8V6Z'),
]);
export const PageSetupIcon = crear('PageSetup', [...hoja(), p('M9 11v11'), p('M4 15h16')]);
export const PagosIcon = crear('Pagos', [
  p('M11 15h2a2 2 0 1 0 0-4h-3c-.6 0-1.1.2-1.4.6L3 17'),
  p('m7 21 1.6-1.4c.3-.4.8-.6 1.4-.6h4c1.1 0 2.1-.4 2.8-1.2l4.6-4.4a2 2 0 0 0-2.75-2.91l-4.2 3.9'),
  p('m2 16 6 6'),
  circ(16, 9, 2.9),
  circ(6, 5, 3),
]);
export const PartidasIcon = crear('Partidas', [p(LIBRO), p('M12 7h.01'), p('M12 10v5')]);
export const PedidoImportacionIcon = crear('PedidoImportacion', [
  p('M15 3h4a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2h-4'),
  p('m10 17 5-5-5-5'),
  p('M15 12H3'),
]);
export const PendienteFacturacionIcon = crear('PendienteFacturacion', [
  ...hoja(p('M10 9H8')),
  circ(9, 16, 4),
  p('M9 14.5v3'),
]);
export const PeriContratoIcon = crear('PeriContrato', [
  p('M12.5 22H18a2 2 0 0 0 2-2V7l-5-5H6a2 2 0 0 0-2 2v9.5'),
  p(HOJA_ESQUINA),
  p('M13.378 15.626a1 1 0 1 0-3.004-3.004l-5.01 5.012a2 2 0 0 0-.506.854l-.837 2.87a.5.5 0 0 0 .62.62l2.87-.837a2 2 0 0 0 .854-.506z'),
]);
export const PlanTelefonicoIcon = crear('PlanTelefonico', [
  p('M7.9 20A9 9 0 1 0 4 16.1L2 22Z'),
  p('M8.5 8.5c.4 2.6 3 5.2 5.6 5.6l1.4-1.4-2-1-1 .8c-1-.5-1.9-1.4-2.4-2.4l.8-1-1-2z'),
]);
export const PlanillaExcelIcon = crear('PlanillaExcel', [
  ...hoja(p('M8 13h2'), p('M14 13h2'), p('M8 17h2'), p('M14 17h2')),
]);
export const PlanillaOficialIcon = crear('PlanillaOficial', [
  circ(12, 8, 3),
  p('M6.5 21v-2a4 4 0 0 1 4-4h3a4 4 0 0 1 4 4v2'),
  circ(5, 11, 2.2),
  circ(19, 11, 2.2),
  p('M2 19v-1a3 3 0 0 1 3-3'),
  p('M22 19v-1a3 3 0 0 0-3-3'),
]);
export const PlanillasIcon = crear('Planillas', USUARIOS);
export const PlanillasSueldosIcon = crear('PlanillasSueldos', [
  rect(4, 3, 16, 18, 2),
  p('M4 8h16'),
  p('M8 12h8'),
  p('M8 16h5'),
]);
export const PlantillaIcon = crear('Plantilla', [
  rect(6, 3, 14, 18, 2),
  p('M2 7h4'), p('M2 12h4'), p('M2 17h4'),
  p('M10 8h6'), p('M10 12h6'),
]);
export const PlantillasIcon = crear('Plantillas', [
  rect(8, 8, 14, 14, 2),
  p('M4 16c-1.1 0-2-.9-2-2V4c0-1.1.9-2 2-2h10c1.1 0 2 .9 2 2'),
]);
export const PrecioCoreIcon = crear('PrecioCore', [
  rect(2, 6, 20, 12, 2),
  circ(12, 12, 2),
  punto(6, 12),
  punto(18, 12),
  p('M5 3.5h14'),
]);
export const PreMarcacionIcon = crear('PreMarcacion', [circ(12, 12, 10), p('M12 6v6l4 2')]);
export const ProcCierreMesIcon = crear('ProcCierreMes', [
  p('M8 2v4'), p('M16 2v4'),
  rect(3, 4, 18, 18, 2),
  p('M3 10h18'),
  punto(8, 14), punto(12, 14), punto(16, 14),
  punto(8, 18), punto(12, 18), punto(16, 18),
]);
export const ProcCtaDestIcon = crear('ProcCtaDest', [
  rect(3, 4, 18, 16, 1),
  p('M3 9h18'), p('M3 15h18'),
  punto(7, 6.5), punto(11, 6.5),
  punto(9, 12), punto(15, 12),
  punto(8, 17.5), punto(13, 17.5),
]);
export const ProcesarIcon = crear('Procesar', [
  rect(8, 2, 8, 4, 1),
  p('M10.42 12.61a2.1 2.1 0 1 1 2.97 2.97L7.95 21 4 22l.99-3.95 5.43-5.44Z'),
  p('M16 4h2a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2h-5.5'),
  p('M4 13.5V6a2 2 0 0 1 2-2h2'),
]);
export const ProcessIcon = crear('Process', [p(ENGRANAJE), p('m9.5 12 1.8 1.8 3.4-3.6')]);
export const ProcessJobIcon = crear('ProcessJob', herramientas());
export const ProvisionalIcon = crear('Provisional', [p(BOLSA_BOCA), p(BOLSA), elipse(8, 18, 3, 1.4)]);
export const QuickPlayIcon = crear('QuickPlay', [
  p('M3 12a9 9 0 0 1 15-6.7L21 8'),
  p('M21 3v5h-5'),
  p('M21 12a9 9 0 0 1-15 6.7L3 16'),
  p('M3 21v-5h5'),
]);
export const RecalcularIcon = crear('Recalcular', [p(ENGRANAJE), circ(12, 12, 3)]);
export const RechazarIcon = crear('Rechazar', [circ(12, 12, 10), p('m4.9 4.9 14.2 14.2')]);
export const Rechazar1Icon = RechazarIcon;
export const Rechazar3Icon = crear('Rechazar3', [rect(3, 3, 18, 18, 3), p('m15 9-6 6'), p('m9 9 6 6')]);
export const ReclamoGarantiaHojaIcon = crear('ReclamoGarantiaHoja', [
  rect(5, 2, 14, 20, 2),
  p('M9 7h6'), p('M9 11h6'), p('M9 15h4'),
]);
export const ReclamoGarantiaMedallaIcon = crear('ReclamoGarantiaMedalla', [
  circ(12, 8, 6),
  p('M15.477 12.89 17 22l-5-3-5 3 1.523-9.11'),
]);
export const ReembolsoIcon = crear('Reembolso', [
  rect(2, 9, 14, 10, 2),
  circ(9, 14, 2),
  p('M22 12V8a2 2 0 0 0-2-2h-6'),
  p('m17 3-3 3 3 3'),
]);
export const RegComprasIcon = crear('RegCompras', CANASTA);
export const RegistroIcon = crear('Registro', [
  rect(2, 3, 20, 5, 1),
  p('M4 8v11a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8'),
  p('M10 12h4'),
]);
export const RegistroAuxiliarIcon = crear('RegistroAuxiliar', [
  rect(3, 3, 18, 18, 2),
  p('M3 12h18'),
  p('M10 7.5h4'),
  p('M10 16.5h4'),
]);
export const RegistroResumenIcon = crear('RegistroResumen', [p(CARPETA), p('M8 13h8'), p('M8 16.5h5')]);
export const RegresarIcon = crear('Regresar', [p('m11 17-5-5 5-5'), p('m18 17-5-5 5-5')]);
export const ReordenarIcon = crear('Reordenar', [
  p('m3 16 4 4 4-4'),
  p('M7 20V4'),
  rect(15, 4, 4, 6, 2),
  p('M17 20v-6h-2'),
  p('M15 20h4'),
]);
export const RepAsistenciaIcon = crear('RepAsistencia', [
  p('M12 10a2 2 0 0 0-2 2c0 1.02-.1 2.51-.26 4'),
  p('M14 13.12c0 2.38 0 6.38-1 8.88'),
  p('M17.29 21.02c.12-.6.43-2.3.5-3.02'),
  p('M2 12a10 10 0 0 1 18-6'),
  p('M2 16h.01'),
  p('M21.8 16c.2-2 .131-5.354 0-6'),
  p('M5 19.5C5.5 18 6 15 6 12a6 6 0 0 1 .34-2'),
  p('M8.65 22c.21-.66.45-1.32.57-2'),
  p('M9 6.8a6 6 0 0 1 9 5.2v2'),
]);
export const RepPersonalIcon = crear('RepPersonal', [
  p('M11.5 15H7a4 4 0 0 0-4 4v2'),
  p('M21.378 16.626a1 1 0 0 0-3.004-3.004l-4.01 4.012a2 2 0 0 0-.506.854l-.837 2.87a.5.5 0 0 0 .62.62l2.87-.837a2 2 0 0 0 .854-.506z'),
  circ(10, 7, 4),
]);
export const RepReembolsoIcon = crear('RepReembolso', [
  circ(12, 12, 10),
  p('M16 8h-6a2 2 0 1 0 0 4h4a2 2 0 1 1 0 4H8'),
  p('M12 18V6'),
]);
export const RepRegComprasIcon = crear('RepRegCompras', [...CANASTA, p('M9 2h6')]);
export const RepTardanzasIcon = crear('RepTardanzas', [
  p('m21.73 18-8-14a2 2 0 0 0-3.48 0l-8 14A2 2 0 0 0 4 21h16a2 2 0 0 0 1.73-3'),
  p('M12 9v4'),
  p('M12 17h.01'),
]);
export const ReportIcon = crear('Report', hoja(p('M10 9H8'), p('M16 13H8'), p('M16 17H8')));
export const ResumenGeneralIcon = crear('ResumenGeneral', [
  rect(8, 2, 8, 4, 1),
  p('M16 4h2a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2H6a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2h2'),
  p('M12 11h4'), p('M12 16h4'), p('M8 11h.01'), p('M8 16h.01'),
]);
export const ScdrespsIcon = crear('Scdresps', [
  p('M8 2v4'), p('M16 2v4'),
  rect(3, 4, 18, 18, 2),
  p('M3 10h18'),
  p('m9 16 2 2 4-4'),
]);
export const SecurityLockIcon = crear('SecurityLock', [rect(3, 11, 18, 11, 2), p('M7 11V7a5 5 0 0 1 10 0v4')]);
export const SeleccionarIcon = crear('Seleccionar', [
  rect(8, 2, 8, 4, 1),
  p('M16 4h2a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2H6a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2h2'),
  p('m9 14 2 2 4-4'),
]);
export const SemaforoIcon = crear('Semaforo', [rect(7, 2, 10, 20, 3), punto(12, 7), punto(12, 12), punto(12, 17)]);
export const SepararIcon = crear('Separar', hoja(p('M8 15h8'), p('m13 12 3 3-3 3')));
export const SepararAmbosIcon = crear('SepararAmbos', hoja(p('M7 15h10'), p('m10 12-3 3 3 3'), p('m14 12 3 3-3 3')));
export const SepararPuzzleIcon = crear('SepararPuzzle', [
  p('M16 3h5v5'),
  p('M8 3H3v5'),
  p('M12 22v-8.3a4 4 0 0 0-1.172-2.872L3 3'),
  p('m15 9 6-6'),
]);
export const SesionIconIcon = crear('SesionIcon', USUARIOS);
export const SobregiroIcon = crear('Sobregiro', [rect(5, 2, 14, 20, 2), p('M9 2v8l2-1.5 2 1.5V2'), p('M9 16h6')]);
export const SolGastosIcon = crear('SolGastos', [
  p('M19 7V4a1 1 0 0 0-1-1H5a2 2 0 0 0 0 4h15a1 1 0 0 1 1 1v4h-3a2 2 0 0 0 0 4h3a1 1 0 0 0 1-1v-2a1 1 0 0 0-1-1'),
  p('M3 5v14a2 2 0 0 0 2 2h15a1 1 0 0 0 1-1v-4'),
]);
export const SolicGarantiaIcon = crear('SolicGarantia', hoja(p('M8 11h2'), p('M8 15h8'), p('M8 19h5')));
export const SortIcon = crear('Sort', [
  p('m3 16 4 4 4-4'),
  p('M7 20V4'),
  p('M20 8h-5'),
  p('M15 10V6.5a2.5 2.5 0 0 1 5 0V10'),
  p('M15 14h5l-5 6h5'),
]);
export const StockIcon = crear('Stock', [
  p('M11 21.73a2 2 0 0 0 2 0l7-4A2 2 0 0 0 21 16V8a2 2 0 0 0-1-1.73l-7-4a2 2 0 0 0-2 0l-7 4A2 2 0 0 0 3 8v8a2 2 0 0 0 1 1.73z'),
  p('M12 22V12'),
  p('m3.3 7 7.703 4.734a2 2 0 0 0 1.994 0L20.7 7'),
  p('m7.5 4.27 9 5.15'),
]);
export const StockValorizadoIcon = crear('StockValorizado', [p(LIBRO), p('M9 7h6'), p('M9 11h4')]);
export const SugerirIcon = crear('Sugerir', [
  p('M3.85 8.62a4 4 0 0 1 4.78-4.77 4 4 0 0 1 6.74 0 4 4 0 0 1 4.78 4.78 4 4 0 0 1 0 6.74 4 4 0 0 1-4.77 4.78 4 4 0 0 1-6.75 0 4 4 0 0 1-4.78-4.77 4 4 0 0 1 0-6.76Z'),
  p('m15 9-6 6'),
  p('M9 9h.01'),
  p('M15 15h.01'),
]);
export const TabIcon = crear('Tab', [p('m16 3 4 4-4 4'), p('M20 7H4'), p('m8 21-4-4 4-4'), p('M4 17h16')]);
export const TarifasIcon = crear('Tarifas', [p(BOLSA_BOCA), p(BOLSA), ...SIGNO_DOLAR.map((d) => p(d))]);
export const TaxiIcon = crear('Taxi', [
  p('M19 17h2c.6 0 1-.4 1-1v-3c0-.9-.7-1.7-1.5-1.9C18.7 10.6 16 10 16 10s-1.3-1.4-2.2-2.3c-.5-.4-1.1-.7-1.8-.7H5c-.6 0-1.1.4-1.4.9l-1.4 2.9A3.7 3.7 0 0 0 2 12v4c0 .6.4 1 1 1h2'),
  circ(7, 17, 2),
  p('M9 17h6'),
  circ(17, 17, 2),
]);
export const TesAsientosIcon = crear('TesAsientos', [
  rect(4, 2, 16, 20, 2),
  p('M8 6h8'),
  p('M16 14v4'),
  punto(16, 10), punto(12, 10), punto(8, 10),
  punto(12, 14), punto(8, 14),
  punto(12, 18), punto(8, 18),
]);
export const TicketIcon = crear('Ticket', [
  p('M6 18H4a2 2 0 0 1-2-2v-5a2 2 0 0 1 2-2h16a2 2 0 0 1 2 2v5a2 2 0 0 1-2 2h-2'),
  p('M6 9V3a1 1 0 0 1 1-1h10a1 1 0 0 1 1 1v6'),
  rect(6, 14, 12, 8, 1),
]);
export const TomaInventarioIcon = crear('TomaInventario', [p('m16 6 4 14'), p('M12 6v14'), p('M8 8v12'), p('M4 4v16')]);
export const ToolsIcon = crear('Tools', herramientas());
export const TortaIcon = crear('Torta', [
  p('M20 21v-8a2 2 0 0 0-2-2H6a2 2 0 0 0-2 2v8'),
  p('M4 16s.5-1 2-1 2.5 2 4 2 2.5-2 4-2 2.5 2 4 2 2-1 2-1'),
  p('M2 21h20'),
  p('M7 8v3'), p('M12 8v3'), p('M17 8v3'),
  p('M7 4h.01'), p('M12 4h.01'), p('M17 4h.01'),
]);
export const TransferenciaInternaIcon = crear('TransferenciaInterna', [
  rect(3, 11, 18, 10, 1),
  p('M12 2v8'),
  p('m8 6 4 4 4-4'),
  p('M10 15h4'),
]);
export const TransferenciasIcon = crear('Transferencias', [p('M5 12h14'), p('m12 5 7 7-7 7')]);
export const TransporteIcon = crear('Transporte', [
  p('M14 18V6a2 2 0 0 0-2-2H4a2 2 0 0 0-2 2v11a1 1 0 0 0 1 1h2'),
  p('M15 18H9'),
  p('M19 18h2a1 1 0 0 0 1-1v-3.65a1 1 0 0 0-.22-.624l-3.48-4.35A1 1 0 0 0 17.52 8H14'),
  circ(17, 18, 2),
  circ(7, 18, 2),
]);
export const TrasladarIcon = crear('Trasladar', [p('M3 12h14'), p('m13 8 4 4-4 4'), p('M21 5v14')]);
export const TrasladarCostosIcon = crear('TrasladarCostos', [
  p('M4 22h14a2 2 0 0 0 2-2V7l-5-5H6a2 2 0 0 0-2 2v4'),
  p(HOJA_ESQUINA),
  p('M2 15h10'),
  p('m9 18 3-3-3-3'),
]);
export const UbicacionIcon = crear('Ubicacion', [
  p('M12 17v5'),
  p('M9 10.76a2 2 0 0 1-1.11 1.79l-1.78.9A2 2 0 0 0 5 15.24V16a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1v-.76a2 2 0 0 0-1.11-1.79l-1.78-.9A2 2 0 0 1 15 10.76V7a1 1 0 0 1 1-1 2 2 0 0 0 0-4H8a2 2 0 0 0 0 4 1 1 0 0 1 1 1z'),
]);
export const UploadIcon = crear('Upload', [rect(3, 3, 18, 18, 2), p('M3 8h18'), p('M12 19v-7'), p('m9 15 3-3 3 3')]);
export const UserIcon = crear('User', [p('M19 21v-2a4 4 0 0 0-4-4H9a4 4 0 0 0-4 4v2'), circ(12, 7, 4)]);
export const UsersIcon = crear('Users', [
  p('M18 21a8 8 0 0 0-16 0'),
  circ(10, 8, 5),
  p('M22 20c0-3.37-2-6.5-4-8a5 5 0 0 0-.45-8.3'),
]);
export const VacacionesIcon = crear('Vacaciones', [p('M22 12a10.06 10.06 1 0 0-20 0Z'), p('M12 12v8a2 2 0 0 0 4 0'), p('M12 2v1')]);
export const ValeMaterialIcon = crear('ValeMaterial', hoja(p('m9 17 6-6'), p('m9 11 2 2'), p('m13 17 2-2')));
export const ValeRequisicionIcon = crear('ValeRequisicion', hoja(p('M10 9H8'), p('M16 13H8'), p('M16 17H8')));
export const ValesMaterialIcon = crear('ValesMaterial', herramientas());
export const VarPlanillasIcon = crear('VarPlanillas', [
  p('M3 3v16a2 2 0 0 0 2 2h16'),
  p('M18 17V9'),
  p('M13 17V5'),
  p('M8 17v-3'),
]);
export const VehiculoIcoIcon = crear('VehiculoIco', [
  p('M14 18V6a2 2 0 0 0-2-2H4a2 2 0 0 0-2 2v11a1 1 0 0 0 1 1h2'),
  p('M15 18H9'),
  p('M22 18v-5l-3-4h-5'),
  circ(17, 18, 2),
  circ(7, 18, 2),
  p('M6 8h4'),
]);
export const VelasIcon = crear('Velas', [
  rect(4, 13, 6, 8, 1),
  rect(13, 11, 6, 10, 1),
  p('M7 10c-1.2-1 .2-2.8 0-4.5 1.6 1.2 2.4 3.3 0 4.5Z'),
  p('M16 8c-1.2-1 .2-2.8 0-4.5 1.6 1.2 2.4 3.3 0 4.5Z'),
  p('M2 21h20'),
]);
export const VencimientoAcumuladaIcon = crear('VencimientoAcumulada', [...BOCA_TRISTE(10, 14), p('M19 2v6'), p('M16 5h6')]);
export const VencimientoDetalleIcon = crear('VencimientoDetalle', [
  ...BOCA_TRISTE(10, 14),
  circ(18, 6, 3),
  p('m20.1 8.1 2.4 2.4'),
]);
export const VencimientosIcon = crear('Vencimientos', [
  p('m6 14 1.5-2.9A2 2 0 0 1 9.24 10H20a2 2 0 0 1 1.94 2.5l-1.54 6a2 2 0 0 1-1.95 1.5H4a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2h3.9a2 2 0 0 1 1.69.9l.81 1.2a2 2 0 0 0 1.67.9H18a2 2 0 0 1 2 2v2'),
]);
export const VendedorIcon = crear('Vendedor', [
  circ(12, 7, 4),
  p('M5 21v-2a5 5 0 0 1 5-5h4a5 5 0 0 1 5 5v2'),
  p('m12 14-1.5 2 1.5 3 1.5-3z'),
]);
export const VentIcon = crear('Vent', [
  p('M12 3H5a2 2 0 0 0-2 2v14a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2v-7'),
  p('M18.375 2.625a1 1 0 0 1 3 3l-9.013 9.014a2 2 0 0 1-.853.505l-2.873.84a.5.5 0 0 1-.62-.62l.84-2.873a2 2 0 0 1 .506-.852z'),
]);
export const VentasIcon = crear('Ventas', [
  p('m11 17 2 2a1 1 0 1 0 3-3'),
  p('m14 14 2.5 2.5a1 1 0 1 0 3-3l-3.88-3.88a3 3 0 0 0-4.24 0l-.88.88a1 1 0 1 1-3-3l2.81-2.81a5.79 5.79 0 0 1 7.06-.87l.47.28a2 2 0 0 0 1.42.25L21 4'),
  p('m21 3 1 11h-2'),
  p('M3 3 2 14l6.5 6.5a1 1 0 1 0 3-3'),
  p('M3 4h8'),
]);
export const VincularIcon = crear('Vincular', [
  p('M10 13a5 5 0 0 0 7.54.54l3-3a5 5 0 0 0-7.07-7.07l-1.72 1.71'),
  p('M14 11a5 5 0 0 0-7.54-.54l-3 3a5 5 0 0 0 7.07 7.07l1.71-1.71'),
]);
export const VisitaCobradorIcon = crear('VisitaCobrador', [...USUARIOS, p('m9 14-1 1.5L9 18l1-2.5z')]);
export const WorkersIcon = crear('Workers', USUARIOS);

/* ---------- registro: clave = nombre original del archivo (sin extensión) ---------- */
/* ================================================================
   Iconos A–Z (lote 2). Diseños únicos reutilizados por varios archivos.
   Las insignias (más, x, check, flecha…) rellenan su círculo con
   `var(--icon-bg, #fff)`: defina --icon-bg con el color de fondo del botón.
   ================================================================ */
const DISENOS = (() => {
  type AttrB = Record<string, string | number>;
  type NodoB = [string, AttrB];

  /* ───────────── helpers ───────────── */
  const P = (d: string, a: AttrB = {}): NodoB => ["path", { d, ...a }];
  const C = (cx: number, cy: number, r: number, a: AttrB = {}): NodoB => ["circle", { cx, cy, r, ...a }];
  const R = (x: number, y: number, width: number, height: number, rx = 0, a: AttrB = {}): NodoB => [
    "rect",
    { x, y, width, height, rx, ...a },
  ];
  const T = (ns: NodoB[], transform: string): NodoB[] => ns.map(([t, a]) => [t, { ...a, transform }] as NodoB);
  const S = (ns: NodoB[]) => T(ns, "scale(.78)"); // base reducida para dejar sitio a la insignia
  const mk = (name: string, ns: NodoB[]) =>
    createLucideIcon(name, ns.map(([t, a], i) => [t, { ...a, key: `k${i}` }]) as unknown as IconNode);

  /* letras/dígitos de 3×5 para siglas (BOL, FAC, F/G, G/D, G/R, NOT, NEW, 123…) */
  const GL: Record<string, string> = {
    A: "M0 5V1.5L1.5 0L3 1.5V5M0 3H3", B: "M0 0V5H2L3 4V3L2 2.5L3 2V1L2 0ZM0 2.5H2", C: "M3 0H0V5H3",
    D: "M0 0V5H2L3 4V1L2 0Z", E: "M3 0H0V5H3M0 2.5H2", F: "M3 0H0V5M0 2.5H2", G: "M3 0H0V5H3V2.5H1.5",
    L: "M0 0V5H3", NodoB: "M0 5V0L3 5V0", O: "M0 0H3V5H0Z", R: "M0 5V0H2L3 1V1.5L2 2.5H0M2 2.5L3 5",
    T: "M0 0H3M1.5 0V5", W: "M0 0L.75 5L1.5 1.8L2.25 5L3 0", "/": "M3 0L0 5", "1": "M.4 1.2L1.6 0V5",
    "2": "M0 1L1 0H2L3 1V2L0 5H3", "3": "M0 0H3L1.5 2.2L3 3.2V4L2 5H0",
  };
  const txt = (s: string, x: number, y: number, sw = 1.4, k = 1): NodoB[] =>
    [...s].map((ch, i) => P(GL[ch], { transform: `translate(${x + i * 4.4 * k} ${y}) scale(${k})`, strokeWidth: sw }));

  /* insignias (esquina inferior derecha) */
  const badge = (inner: NodoB[]): NodoB[] => [C(18, 18, 5, { fill: "var(--icon-bg, #fff)" }), ...inner];
  const B_PLUS = badge([P("M18 15.5v5M15.5 18h5")]);
  const B_X = badge([P("m16 16 4 4M20 16l-4 4")]);
  const B_OK = badge([P("m15.6 18.2 1.7 1.7 3.1-3.5")]);
  const B_DOWN = badge([P("M18 15.5v5M16 18.5l2 2 2-2")]);
  const B_UP = badge([P("M18 20.5v-5M16 17.5l2-2 2 2")]);
  const B_SEARCH = badge([C(17.5, 17.5, 2), P("m19 19 1.8 1.8")]);
  const B_CLOCK = badge([P("M18 15.3V18l1.8 1")]);
  const B_PEN = badge([P("m15.6 20.4 5-5M19 14l2.5 2.5M15.6 20.4l.3-1.9")]);
  const B_REFRESH = badge([P("M20.3 17.6a2.5 2.5 0 0 0-4.4-.6M15.7 18.4a2.5 2.5 0 0 0 4.4.6M20.4 15.6v2h-2M15.6 20.4v-2h2")]);
  const B_GLOBE = badge([P("M13.5 18h9M18 13.5c-2 2.4-2 6.6 0 9M18 13.5c2 2.4 2 6.6 0 9")]);
  const B_GEAR = badge([C(18, 18, 1.8), P("M18 14.5v1.2M18 20.3v1.2M14.5 18h1.2M20.3 18h1.2")]);

  /* ───────────── dibujos base ───────────── */
  const DOC: NodoB[] = [P("M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z"), P("M14 2v4a2 2 0 0 0 2 2h4")];
  const DOC_LINES: NodoB[] = [...DOC, P("M8 13h8M8 17h8M8 9h2")];
  const INVOICE: NodoB[] = [...DOC, P("M8 10h4"), R(8, 13, 8, 5, 1), P("M12 13v5")];
  const FOLDER: NodoB[] = [P("M20 20a2 2 0 0 0 2-2V8a2 2 0 0 0-2-2h-7.9a2 2 0 0 1-1.69-.9L9.6 3.9A2 2 0 0 0 7.93 3H4a2 2 0 0 0-2 2v13a2 2 0 0 0 2 2Z")];
  const FOLDER_OPEN: NodoB[] = [P("m6 14 1.5-2.9A2 2 0 0 1 9.24 10H20a2 2 0 0 1 1.94 2.5l-1.54 6a2 2 0 0 1-1.95 1.5H4a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2h3.9a2 2 0 0 1 1.69.9l.81 1.2a2 2 0 0 0 1.67.9H18a2 2 0 0 1 2 2v2")];
  const CALENDAR: NodoB[] = [R(3, 4, 18, 18, 2), P("M16 2v4M8 2v4M3 10h18")];
  const CLOCK: NodoB[] = [C(12, 12, 10), P("M12 6v6l4 2")];
  const ALARM: NodoB[] = [C(12, 13, 8), P("M12 9v4l2 2M5 3 2 6M22 6l-3-3M6 19l-2 2M18 19l2 2")];
  const PERCENT: NodoB[] = [P("M19 5 5 19"), C(6.5, 6.5, 2.5), C(17.5, 17.5, 2.5)];
  const DOLLAR: NodoB[] = [P("M12 2v20M17 5H9.5a3.5 3.5 0 0 0 0 7h5a3.5 3.5 0 0 1 0 7H6")];
  const MONEYBAG: NodoB[] = [P("M9 3h6l-1.5 3h-3z"), P("M10.5 6C6 8.5 4 12 4 16a5 5 0 0 0 5 5h6a5 5 0 0 0 5-5c0-4-2-7.5-6.5-10"), P("M14 12.5h-2.2a1.5 1.5 0 0 0 0 3h.4a1.5 1.5 0 0 1 0 3H10M12 11v1.5M12 18.5V20")];
  const COINS: NodoB[] = [P("M5 6c0 1.1 3.1 2 7 2s7-.9 7-2-3.1-2-7-2-7 .9-7 2z"), P("M5 6v4c0 1.1 3.1 2 7 2s7-.9 7-2V6"), P("M5 10v4c0 1.1 3.1 2 7 2s7-.9 7-2v-4"), P("M5 14v4c0 1.1 3.1 2 7 2s7-.9 7-2v-4")];
  const BANKNOTE: NodoB[] = [R(2, 6, 20, 12, 2), C(12, 12, 2), P("M6 12h.01M18 12h.01")];
  const WALLET: NodoB[] = [P("M19 7V4a1 1 0 0 0-1-1H5a2 2 0 0 0 0 4h15a1 1 0 0 1 1 1v4h-3a2 2 0 0 0 0 4h3a1 1 0 0 0 1-1v-2a1 1 0 0 0-1-1"), P("M3 5v14a2 2 0 0 0 2 2h15a1 1 0 0 0 1-1v-4")];
  const CARD: NodoB[] = [R(2, 5, 20, 14, 2), P("M2 10h20")];
  const CARDS: NodoB[] = [P("M5 7V6a2 2 0 0 1 2-2h13a2 2 0 0 1 2 2v8a2 2 0 0 1-2 2h-1"), R(2, 8, 17, 12, 2), P("M2 12.5h17M5 17h3")];
  const CALC: NodoB[] = [R(4, 2, 16, 20, 2), P("M8 6h8M8 10h.01M12 10h.01M16 10h.01M8 14h.01M12 14h.01M16 14h.01M8 18h.01M12 18h.01M16 18h.01")];
  const SAFE: NodoB[] = [R(3, 3, 18, 17, 2), C(11.5, 11.5, 4), C(11.5, 11.5, 1), P("M7 20v2M17 20v2M21 8h1M21 14h1")];
  const BOOK: NodoB[] = [P("M4 19.5v-15A2.5 2.5 0 0 1 6.5 2H19a1 1 0 0 1 1 1v18a1 1 0 0 1-1 1H6.5a1 1 0 0 1 0-5H20")];
  const BOOKS: NodoB[] = [R(5, 2, 15, 7, 1), P("M9 2v7"), R(3, 9, 16, 6, 1), P("M7 9v6"), R(5, 15, 15, 7, 1), P("M9 15v7")];
  const NOTEBOOK: NodoB[] = [R(4, 2, 16, 20, 2), P("M2 6h4M2 10h4M2 14h4M2 18h4M10 7h6M10 11h6")];
  const BRIEFCASE: NodoB[] = [R(2, 7, 20, 14, 2), P("M16 21V5a2 2 0 0 0-2-2h-4a2 2 0 0 0-2 2v16")];
  const USER: NodoB[] = [C(12, 7, 4), P("M19 21v-2a4 4 0 0 0-4-4H9a4 4 0 0 0-4 4v2")];
  const TRUCK: NodoB[] = [P("M14 18V6a2 2 0 0 0-2-2H4a2 2 0 0 0-2 2v11a1 1 0 0 0 1 1h2M15 18H9M19 18h2a1 1 0 0 0 1-1v-3.65a1 1 0 0 0-.22-.62l-3.48-4.35A1 1 0 0 0 17.52 8H14"), C(17, 18, 2), C(7, 18, 2)];
  const PRINTER: NodoB[] = [P("M6 18H4a2 2 0 0 1-2-2v-5a2 2 0 0 1 2-2h16a2 2 0 0 1 2 2v5a2 2 0 0 1-2 2h-2"), P("M6 9V3a1 1 0 0 1 1-1h10a1 1 0 0 1 1 1v6"), R(6, 14, 12, 8, 1)];
  const PHONE: NodoB[] = [P("M22 16.92v3a2 2 0 0 1-2.18 2 19.79 19.79 0 0 1-8.63-3.07 19.5 19.5 0 0 1-6-6 19.79 19.79 0 0 1-3.07-8.67A2 2 0 0 1 4.11 2h3a2 2 0 0 1 2 1.72 12.84 12.84 0 0 0 .7 2.81 2 2 0 0 1-.45 2.11L8.09 9.91a16 16 0 0 0 6 6l1.27-1.27a2 2 0 0 1 2.11-.45 12.84 12.84 0 0 0 2.81.7A2 2 0 0 1 22 16.92z")];
  const CART: NodoB[] = [C(8, 21, 1), C(19, 21, 1), P("M2.05 2.05h2l2.66 12.42a2 2 0 0 0 2 1.58h9.78a2 2 0 0 0 1.95-1.57l1.65-7.43H5.12")];
  const GEAR: NodoB[] = [P("M12.22 2h-.44a2 2 0 0 0-2 2v.18a2 2 0 0 1-1 1.73l-.43.25a2 2 0 0 1-2 0l-.15-.08a2 2 0 0 0-2.73.73l-.22.38a2 2 0 0 0 .73 2.73l.15.1a2 2 0 0 1 1 1.72v.51a2 2 0 0 1-1 1.74l-.15.09a2 2 0 0 0-.73 2.73l.22.38a2 2 0 0 0 2.73.73l.15-.08a2 2 0 0 1 2 0l.43.25a2 2 0 0 1 1 1.73V20a2 2 0 0 0 2 2h.44a2 2 0 0 0 2-2v-.18a2 2 0 0 1 1-1.73l.43-.25a2 2 0 0 1 2 0l.15.08a2 2 0 0 0 2.73-.73l.22-.39a2 2 0 0 0-.73-2.73l-.15-.08a2 2 0 0 1-1-1.74v-.5a2 2 0 0 1 1-1.74l.15-.09a2 2 0 0 0 .73-2.73l-.22-.38a2 2 0 0 0-2.73-.73l-.15.08a2 2 0 0 1-2 0l-.43-.25a2 2 0 0 1-1-1.73V4a2 2 0 0 0-2-2z"), C(12, 12, 3)];
  const LOCK: NodoB[] = [R(3, 11, 18, 11, 2), P("M7 11V7a5 5 0 0 1 10 0v4")];
  const SEARCH: NodoB[] = [C(11, 11, 8), P("m21 21-4.3-4.3")];
  const PENCIL: NodoB[] = [P("M21.17 6.81a1 1 0 0 0-3.99-3.99L3.84 16.17a2 2 0 0 0-.5.83l-1.32 4.35a.5.5 0 0 0 .62.62l4.35-1.32a2 2 0 0 0 .83-.5z"), P("m15 5 4 4")];
  const CLIPBOARD: NodoB[] = [R(8, 2, 8, 4, 1), P("M16 4h2a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2H6a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2h2")];
  const COPY: NodoB[] = [R(8, 8, 14, 14, 2), P("M4 16c-1.1 0-2-.9-2-2V4c0-1.1.9-2 2-2h10c1.1 0 2 .9 2 2")];
  const HAND: NodoB[] = [P("M11 12h2a2 2 0 1 0 0-4h-3c-.6 0-1.1.2-1.4.6L3 14"), P("m7 18 1.6-1.4c.3-.4.8-.6 1.4-.6h4c1.1 0 2.1-.4 2.8-1.2l4.6-4.4a2 2 0 0 0-2.75-2.91l-4.2 3.9"), P("m2 13 6 6")];
  const THUMB_UP: NodoB[] = [P("M7 10v12"), P("M15 5.88 14 10h5.83a2 2 0 0 1 1.92 2.56l-2.33 8A2 2 0 0 1 17.5 22H4a2 2 0 0 1-2-2v-8a2 2 0 0 1 2-2h2.76a2 2 0 0 0 1.79-1.11L12 2a3.13 3.13 0 0 1 3 3.88Z")];
  const WARN: NodoB[] = [P("m21.73 18-8-14a2 2 0 0 0-3.48 0l-8 14A2 2 0 0 0 4 21h16a2 2 0 0 0 1.73-3"), P("M12 9v4M12 17h.01")];
  const HARDHAT: NodoB[] = [P("M10 10V5a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v5"), P("M14 6a6 6 0 0 1 6 6v3"), P("M4 15v-3a6 6 0 0 1 6-6"), R(2, 15, 20, 4, 1)];
  const CAMERA: NodoB[] = [P("M14.5 4h-5L7 7H4a2 2 0 0 0-2 2v9a2 2 0 0 0 2 2h16a2 2 0 0 0 2-2V9a2 2 0 0 0-2-2h-3l-2.5-3z"), C(12, 13, 3)];
  const WRENCH: NodoB[] = [P("M14.7 6.3a1 1 0 0 0 0 1.4l1.6 1.6a1 1 0 0 0 1.4 0l3.77-3.77a6 6 0 0 1-7.94 7.94l-6.91 6.91a2.12 2.12 0 0 1-3-3l6.91-6.91a6 6 0 0 1 7.94-7.94l-3.76 3.76z")];
  const EXCEL: NodoB[] = [...DOC, P("m8.5 11 5 7M13.5 11l-5 7")];
  const BARS: NodoB[] = [P("M3 3v16a2 2 0 0 0 2 2h16"), P("M7 17v-3M11 17v-6M15 17V8M19 17V5")];
  const PIE: NodoB[] = [P("M21 12c.55 0 1-.45.95-1a10 10 0 0 0-8.95-8.95c-.55-.05-1 .4-1 .95v8a1 1 0 0 0 1 1z"), P("M21.21 15.89A10 10 0 1 1 8 2.83")];
  const USERS: NodoB[] = [P("M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2"), C(9, 7, 4), P("M22 21v-2a4 4 0 0 0-3-3.87M16 3.13a4 4 0 0 1 0 7.75")];
  const WINDOWS_ARROW: NodoB[] = [R(3, 12, 10, 9, 1.5), P("M6 16h4"), P("M20 4 13 11M20 4v5M20 4h-5")];

  /* ───────────── diseños únicos ───────────── */
  const D = {
    /* flechas / navegación / estados */
    ChevronsDown: mk("ChevronsDown", [P("m7 6 5 5 5-5M7 13l5 5 5-5")]),
    ChevronsUp: mk("ChevronsUp", [P("m17 11-5-5-5 5M17 18l-5-5-5 5")]),
    ChevronsLeft: mk("ChevronsLeft", [P("m11 17-5-5 5-5M18 17l-5-5 5-5")]),
    ChevronsRight: mk("ChevronsRight", [P("m6 17 5-5-5-5M13 17l5-5-5-5")]),
    ChevronRightToLine: mk("ChevronRightToLine", [P("m5 7 6 5-6 5M18 5v14")]),
    Info: mk("Info", [C(12, 12, 10), P("M12 16v-4M12 8h.01")]),
    CircleCheck: mk("CircleCheck", [C(12, 12, 10), P("m9 12 2 2 4-4")]),
    CircleX: mk("CircleX", [C(12, 12, 10), P("m15 9-6 6M9 9l6 6")]),
    CirclePlus: mk("CirclePlus", [C(12, 12, 10), P("M8 12h8M12 8v8")]),
    Ban: mk("Ban", [C(12, 12, 10), P("m4.9 4.9 14.2 14.2")]),
    Check: mk("Check", [P("M20 6 9 17l-5-5")]),
    CheckCheck: mk("CheckCheck", [P("M18 6 7 17l-5-5M22 10l-7.5 7.5L13 16")]),
    X: mk("X", [P("M18 6 6 18M6 6l12 12")]),
    Square: mk("Square", [R(3, 3, 18, 18, 3)]),
    SquareCheck: mk("SquareCheck", [R(3, 3, 18, 18, 3), P("m9 12 2 2 4-4")]),
    Undo: mk("Undo", [P("M9 14 4 9l5-5"), P("M4 9h10.5a5.5 5.5 0 0 1 5.5 5.5 5.5 5.5 0 0 1-5.5 5.5H11")]),
    Refresh: mk("Refresh", [P("M3 12a9 9 0 0 1 9-9 9.75 9.75 0 0 1 6.74 2.74L21 8M21 3v5h-5M21 12a9 9 0 0 1-9 9 9.75 9.75 0 0 1-6.74-2.74L3 16M8 16H3v5")]),
    RotateCw: mk("RotateCw", [P("M21 12a9 9 0 1 1-9-9c2.52 0 4.93 1 6.74 2.74L21 8M21 3v5h-5")]),
    RotateCcw: mk("RotateCcw", [P("M3 12a9 9 0 1 0 9-9 9.75 9.75 0 0 0-6.74 2.74L3 8M3 3v5h5")]),
    CircleArrow: mk("CircleArrow", [P("M21 12a9 9 0 1 1-9-9c2.52 0 4.93 1 6.74 2.74L21 8M21 3v5h-5"), C(12, 12, 1.5)]),
    ArrowLeftRight: mk("ArrowLeftRight", [P("M8 3 4 7l4 4M4 7h16M16 21l4-4-4-4M20 17H4")]),
    AtSign: mk("AtSign", [C(12, 12, 4), P("M16 8v5a3 3 0 0 0 6 0v-1a10 10 0 1 0-4 8")]),
    MailUp: mk("MailUp", [R(2, 5, 20, 15, 2), P("m22 8-8.97 5.2a2 2 0 0 1-2.06 0L2 8"), P("M12 3v5M10 5l2-2 2 2")]),
    ThumbsUp: mk("ThumbsUp", THUMB_UP),
    ThumbsDown: mk("ThumbsDown", T(THUMB_UP, "translate(0 24) scale(1 -1)")),
    PlayCircle: mk("PlayCircle", [C(12, 12, 10), P("m10 8 6 4-6 4z")]),
    HelpSquare: mk("HelpSquare", [R(3, 3, 18, 18, 4), P("M9.1 9a3 3 0 0 1 5.82 1c0 2-3 3-3 3M12 17h.01")]),

    /* documentos */
    DocBol: mk("DocBol", [...DOC, ...txt("BOL", 6.1, 9.5), P("M8 17h8")]),
    DocFac: mk("DocFac", [...DOC, ...txt("FAC", 6.1, 9.5), P("M8 17h8")]),
    DocFG: mk("DocFG", [...DOC, ...txt("F/G", 6.1, 9.5), P("M8 17h8")]),
    DocGD: mk("DocGD", [...DOC, ...txt("G/D", 6.1, 9.5), P("M8 17h8")]),
    DocGR: mk("DocGR", [...DOC, ...txt("G/R", 6.1, 9.5), P("M8 17h8")]),
    DocNot: mk("DocNot", [...DOC, ...txt("NOT", 6.1, 9.5), P("M8 17h8")]),
    DocC: mk("DocC", [...DOC, ...txt("C", 8.2, 11, 1.6, 1.4)]),
    DocDollar: mk("DocDollar", [...DOC, P("M12 9v9M14.5 10.5h-3a1.5 1.5 0 0 0 0 3h1a1.5 1.5 0 0 1 0 3H9.5")]),
    DocSend: mk("DocSend", [...DOC_LINES, P("M1 11h2M1 15h2M1 19h2")]),
    DocDown: mk("DocDown", [...DOC, P("M12 11v6M9 14.5l3 3 3-3")]),
    DocGlobe: mk("DocGlobe", [...S(DOC), ...B_GLOBE]),
    DocSign: mk("DocSign", [...DOC, P("M8 12h4M8 16h2"), P("m14 21 1-3 5-5 2 2-5 5z")]),
    DocStack: mk("DocStack", [P("M3 18V4a2 2 0 0 1 2-2h12"), R(6, 5, 15, 17, 2), R(9, 8, 5, 4), P("M16 9h2M16 12h2M9 16h9")]),
    FileX: mk("FileX", [...DOC, P("m9.5 12.5 5 5M14.5 12.5l-5 5")]),
    FilePen: mk("FilePen", [...DOC, P("M8 11h4M8 15h2"), P("m14 21 1-3 5-5 2 2-5 5z")]),
    FilesPlus: mk("FilesPlus", [...S(DOC_LINES), ...B_PLUS]),
    Certificate: mk("Certificate", [R(3, 2, 14, 17, 1.5), P("M6.5 6h7M6.5 9h7"), C(10, 13, 2), P("m14 22 1-3 6-6 2 2-6 6z")]),
    Copy: mk("Copy", COPY),
    InvDown: mk("InvDown", [...S(INVOICE), ...B_DOWN]),
    InvX: mk("InvX", [...S(INVOICE), ...B_X]),
    InvOk: mk("InvOk", [...S(INVOICE), ...B_OK]),
    InvSearch: mk("InvSearch", [...S(INVOICE), ...B_SEARCH]),
    Excel: mk("Excel", EXCEL),
    ExcelDown: mk("ExcelDown", [...S(EXCEL), ...B_DOWN]),
    ExcelUp: mk("ExcelUp", [...S(EXCEL), ...B_UP]),
    ExcelPercent: mk("ExcelPercent", [...DOC, P("M15 9l-6 9"), C(9.5, 10, 0.8), C(14.5, 17, 0.8)]),
    ExcelPercentDown: mk("ExcelPercentDown", [...S(DOC), P("M12.5 7 7 15"), C(7.5, 8, 0.7), C(12, 14.5, 0.7), ...B_DOWN]),
    ExcelCoinsDown: mk("ExcelCoinsDown", [...S(DOC), P("M10 8v7M12 9.5H9a1.2 1.2 0 0 0 0 2.4h1.6a1.2 1.2 0 0 1 0 2.4H8"), ...B_DOWN]),
    ExcelCoinsUp: mk("ExcelCoinsUp", [...S(DOC), P("M10 8v7M12 9.5H9a1.2 1.2 0 0 0 0 2.4h1.6a1.2 1.2 0 0 1 0 2.4H8"), ...B_UP]),

    /* carpetas */
    FolderPlus: mk("FolderPlus", [...FOLDER, P("M12 10v6M9 13h6")]),
    FolderPen: mk("FolderPen", [...S(FOLDER), ...B_PEN]),
    FolderStar: mk("FolderStar", [...FOLDER, P("m12 9.5 1.1 2.2 2.4.35-1.75 1.7.4 2.4L12 15l-2.15 1.15.4-2.4-1.75-1.7 2.4-.35z")]),
    FolderOpen: mk("FolderOpen", FOLDER_OPEN),

    /* fechas y horas */
    Calendar: mk("Calendar", [...CALENDAR, P("M8 14h.01M12 14h.01M16 14h.01M8 18h.01M12 18h.01")]),
    CalendarCheck: mk("CalendarCheck", [...CALENDAR, P("m9 16 2 2 4-4")]),
    CalendarClock: mk("CalendarClock", [...S(CALENDAR), ...B_CLOCK]),
    CalendarPen: mk("CalendarPen", [...S([...CALENDAR, P("M8 14h.01M12 14h.01")]), ...B_PEN]),
    CalendarCopy: mk("CalendarCopy", [R(8, 8, 14, 14, 2), P("M4 16a2 2 0 0 1-2-2V4a2 2 0 0 1 2-2h10a2 2 0 0 1 2 2M8 13h14")]),
    CalendarDigits: mk("CalendarDigits", [...CALENDAR, ...txt("12", 8.2, 13.2, 1.5)]),
    Clock: mk("Clock", CLOCK),
    Watch: mk("Watch", [C(12, 12, 10), P("M12 2v1.5M12 20.5V22M2 12h1.5M20.5 12H22M12 7v5l3 2")]),
    Wristwatch: mk("Wristwatch", [C(12, 12, 6), P("M12 9v3l1.5 1M16.13 7.66l-.81-4.05a2 2 0 0 0-2-1.61h-2.68a2 2 0 0 0-2 1.61l-.78 4.05M7.88 16.36l.8 4a2 2 0 0 0 2 1.61h2.72a2 2 0 0 0 2-1.61l.81-4.05")]),
    Stopwatch: mk("Stopwatch", [P("M10 2h4M12 14l3-3"), C(12, 14, 8)]),
    Alarm: mk("Alarm", [P("M12 7v5l3 2M5 3 2 6M22 6l-3-3M6 19l-2 2M18 19l2 2"), C(12, 13, 8)]),
    AlarmPlus: mk("AlarmPlus", [...S(ALARM), ...B_PLUS]),
    ClockGear: mk("ClockGear", [...S(CLOCK), ...B_GEAR]),
    ClockSpark: mk("ClockSpark", [P("M21 12a9 9 0 1 1-9-9"), P("M12 7v5l3 2M19 2v4M17 4h4")]),
    WindowClock: mk("WindowClock", [...S([R(2, 3, 20, 16, 2), P("M2 8h20M6 12h5M6 15h4")]), ...B_CLOCK]),
    Canjear: mk("Canjear", [R(2, 2, 10, 10, 1.5), P("M7 5v2.5l1.5 1"), P("M15 5h2.5a2 2 0 0 1 2 2v2.5M17 8l2.5 2.5L22 8"), R(12, 14, 9, 8, 1.5)]),

    /* dinero */
    Dollar: mk("Dollar", DOLLAR),
    Percent: mk("Percent", PERCENT),
    PercentDown: mk("PercentDown", [...S(PERCENT), ...B_DOWN]),
    PercentPlus: mk("PercentPlus", [...S(PERCENT), ...B_PLUS]),
    MoneyBag: mk("MoneyBag", MONEYBAG),
    MoneyBagCoin: mk("MoneyBagCoin", [...S(MONEYBAG), C(18, 18, 3.5), P("M18 16.5v3")]),
    Coins: mk("Coins", COINS),
    CoinsPlus: mk("CoinsPlus", [...S(COINS), ...B_PLUS]),
    Banknotes: mk("Banknotes", [R(2, 7, 17, 11, 2), C(10.5, 12.5, 2.2), P("M5 5h15a2 2 0 0 1 2 2v9")]),
    BanknoteBundle: mk("BanknoteBundle", [R(2, 8, 18, 12, 1.5), P("M5 5h15a2 2 0 0 1 2 2v9"), R(8, 8, 5, 12), C(10.5, 14, 1)]),
    Wallet: mk("Wallet", WALLET),
    WalletCoin: mk("WalletCoin", [...S(WALLET), C(18, 18, 4), P("M18 16.2v3.6")]),
    Cards: mk("Cards", CARDS),
    CardCoins: mk("CardCoins", [...S(CARD), C(17, 18, 3.5), P("M17 16.3v3.4")]),
    Calculator: mk("Calculator", CALC),
    CalcRefresh: mk("CalcRefresh", [...S(CALC), ...B_REFRESH]),
    CalcRound: mk("CalcRound", [R(2, 2, 20, 20, 4), P("M8 6.5v3M6.5 8h3M14.5 8h3M14.5 14.5l3 3M17.5 14.5l-3 3M6.5 15.5h3M6.5 17.5h3")]),
    CashRegister: mk("CashRegister", [P("M8 8V2h8v6"), P("M4 8h16l2 8v4a1 1 0 0 1-1 1H3a1 1 0 0 1-1-1v-4z"), P("M7 12h.01M11 12h.01M15 12h.01M7 16h.01M11 16h.01M15 16h3")]),
    Safe: mk("Safe", SAFE),
    PiggyBank: mk("PiggyBank", [P("M19 5c-1.5 0-2.8 1.4-3 2-3.5-1.5-11-.3-11 5 0 1.8 0 3 2 4.5V20h4v-2h3v2h4v-4c1-.5 1.7-1 2-2h2v-4h-2c0-1-.5-1.5-1-2V5z"), P("M2 9.5a2 2 0 0 0 2 2M16 11h.01")]),
    HandCoins: mk("HandCoins", [P("M11 15h2a2 2 0 1 0 0-4h-3c-.6 0-1.1.2-1.4.6L3 17"), P("m7 21 1.6-1.4c.3-.4.8-.6 1.4-.6h4c1.1 0 2.1-.4 2.8-1.2l4.6-4.4a2 2 0 0 0-2.75-2.91l-4.2 3.9"), P("m2 16 6 6"), C(16, 9, 2.9), P("M16 5.1v.2")]),
    HandBanknote: mk("HandBanknote", [P("M9 20l1-1c.3-.3.6-.4 1-.4h3c.8 0 1.5-.3 2-.8l4.5-4.5a1.8 1.8 0 0 0-2.5-2.5L15 13.500"), P("m3 15 5 5"), R(11, 3, 10, 6, 1), C(16, 6, 1.2)]),
    HandHelping: mk("HandHelping", HAND),
    Scale: mk("Scale", [P("m16 16 3-8 3 8c-.87.65-1.92 1-3 1s-2.13-.35-3-1Z"), P("m2 16 3-8 3 8c-.87.65-1.92 1-3 1s-2.13-.35-3-1Z"), P("M7 21h10M12 3v18M3 7h2c2 0 5-1 7-2 2 1 5 2 7 2h2")]),
    Luggage: mk("Luggage", [R(3, 7, 18, 14, 2), P("M8 7V5a2 2 0 0 1 2-2h4a2 2 0 0 1 2 2v2M8 7v14M16 7v14"), C(19, 10, 1)]),

    /* personas */
    UserTie: mk("UserTie", [C(12, 7, 4), P("M5 21v-2a4 4 0 0 1 4-4h6a4 4 0 0 1 4 4v2M12 15l-1.2 1.8L12 21l1.2-3.2z")]),
    UserSilhouette: mk("UserSilhouette", [R(2, 2, 20, 20, 2), C(12, 9, 3.5), P("M5 22c.5-4 3.5-6 7-6s6.5 2 7 6")]),
    UserBriefcase: mk("UserBriefcase", [C(9, 6, 3.5), P("M2 20v-2a4 4 0 0 1 4-4h4"), R(12, 13, 10, 8, 1.5), P("M15 13v-1.5h4V13")]),
    UserChecklist: mk("UserChecklist", [C(8, 6, 3), P("M2 20v-1.5a4 4 0 0 1 4-4h4"), R(13, 10, 9, 12, 1.5), P("M15.5 14h4M15.5 17h4")]),
    UsersHardHat: mk("UsersHardHat", [...USERS, P("M5.5 5.200a3.500 3.500 0 0 1 7 0M3.500 5.500h11")]),
    Family: mk("Family", [C(7, 6, 3), C(17, 6, 3), P("M1 19v-1.5A3.5 3.5 0 0 1 4.5 14h2M23 19v-1.5a3.5 3.5 0 0 0-3.5-3.5h-2"), C(12, 14, 2.2), P("M8.5 21v-1.5a3.5 3.5 0 0 1 7 0V21")]),
    PersonKey: mk("PersonKey", [C(8, 5, 2.5), P("M8 8v7l-3 6M8 15l3 6M5 11l3-2 2.5 2"), C(17, 8, 3), P("m19 10 3 3M20.5 11.5l1.5-1.5")]),
    Fingerprint: mk("Fingerprint", [P("M2 12a10 10 0 0 1 18-6M5 19.500c.5-1.500 1-4 1-7.500a6 6 0 0 1 11.500-2.500M10 22c.5-2 1-5 1-9a1 1 0 0 1 2 0c0 3 .5 6.500 1.500 8.500")]),
    FingerprintDevice: mk("FingerprintDevice", [R(3, 2, 18, 20, 2), R(6, 5, 12, 7, 1), P("M7 16h.01M10 16h.01M13 16h.01M7 19h.01M10 19h.01M13 19h.01"), R(16, 15, 3, 5, 1.5)]),

    /* transporte y lugares */
    Truck: mk("Truck", TRUCK),
    Car: mk("Car", [P("M19 17h2c.6 0 1-.4 1-1v-3c0-.9-.7-1.7-1.5-1.9C18.7 10.6 16 10 16 10s-1.3-1.4-2.2-2.3c-.5-.4-1.1-.7-1.8-.7H5c-.6 0-1.1.4-1.4.9l-1.4 2.9A3.7 3.7 0 0 0 2 12v4c0 .6.4 1 1 1h2"), C(7, 17, 2), P("M9 17h6"), C(17, 17, 2)]),
    Plane: mk("Plane", [P("M17.8 19.2 16 11l3.5-3.5C21 6 21.5 4 21 3c-1-.5-3 0-4.5 1.5L13 8 4.8 6.2c-.5-.1-.9.1-1.1.5l-.3.5c-.2.5-.1 1 .3 1.3L9 12l-2 3H4l-1 1 3 2 2 3 1-1v-3l3-2 3.5 5.3c.3.4.8.5 1.3.3l.5-.2c.4-.3.6-.7.5-1.2z")]),
    House: mk("House", [P("M3 11 12 3l9 8M5 9.5V21h14V9.5M10 21v-6h4v6M16 5.5V3h2v4")]),
    Building: mk("Building", [P("M6 22V4a2 2 0 0 1 2-2h8a2 2 0 0 1 2 2v18Z"), P("M6 12H4a2 2 0 0 0-2 2v6a2 2 0 0 0 2 2h2M18 9h2a2 2 0 0 1 2 2v9a2 2 0 0 1-2 2h-2M10 6h4M10 10h4M10 14h4M10 18h4")]),
    Boots: mk("Boots", [P("M6 3h6v8c0 1.5 1.2 2.5 3 3l3.5 1.5A2.5 2.5 0 0 1 20 18v2H6z"), P("M6 17h14")]),
    DoorExit: mk("DoorExit", [P("M10 3H6a2 2 0 0 0-2 2v14a2 2 0 0 0 2 2h4M17 8l-4 4 4 4M13 12h8")]),
    DoorArrowIn: mk("DoorArrowIn", [P("M14 3h4a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2h-4M3 12h11M10 8l4 4-4 4")]),
    Network: mk("Network", [R(16, 16, 6, 6, 1), R(2, 16, 6, 6, 1), R(9, 2, 6, 6, 1), P("M5 16v-3a1 1 0 0 1 1-1h12a1 1 0 0 1 1 1v3M12 12V8")]),
    Footprints: mk("Footprints", [P("M4 16v-2.38C4 11.5 2.97 10.5 3 8c.03-2.72 1.49-6 4.5-6C9.37 2 10 3.8 10 5.5c0 3.11-2 5.66-2 8.68V16a2 2 0 1 1-4 0Z"), P("M20 20v-2.38c0-2.12 1.03-3.12 1-5.62-.03-2.72-1.49-6-4.5-6C14.63 6 14 7.8 14 9.5c0 3.11 2 5.66 2 8.68V20a2 2 0 1 0 4 0Z"), P("M16 17h4M4 13h4")]),
    Flag: mk("Flag", [P("M4 15s1-1 4-1 5 2 8 2 4-1 4-1V3s-1 1-4 1-5-2-8-2-4 1-4 1z"), P("M4 22v-7")]),
    ChristmasTree: mk("ChristmasTree", [P("m12 3-5 6h3l-5 6h4l-3 5h12l-3-5h4l-5-6h3z"), P("M12 20v2")]),
    Wreath: mk("Wreath", [C(12, 11, 7.5), C(12, 11, 4), P("M12 18.5 8.5 22.5M12 18.5l3.5 4")]),

    /* libros y oficina */
    Book: mk("Book", BOOK),
    BookBookmark: mk("BookBookmark", [P("M10 2v8l3-3 3 3V2"), ...BOOK]),
    BookOpen: mk("BookOpen", [P("M12 7v14"), P("M3 18a1 1 0 0 1-1-1V4a1 1 0 0 1 1-1h5a4 4 0 0 1 4 4 4 4 0 0 1 4-4h5a1 1 0 0 1 1 1v13a1 1 0 0 1-1 1h-6a3 3 0 0 0-3 3 3 3 0 0 0-3-3z"), P("M5 8h3M5 12h3M16 8h3M16 12h3")]),
    BookHelp: mk("BookHelp", [...BOOK, P("M9.5 8a2.5 2.5 0 0 1 5 .5c0 1.5-2.500 2-2.500 3.500M12 15h.01")]),
    BookInfo: mk("BookInfo", [...BOOK, P("M13 8h.01M13 11v4")]),
    BookUp: mk("BookUp", [...BOOK, P("M9.500 12 13 8.500l3.500 3.500M13 8.500V15")]),
    Books: mk("Books", BOOKS),
    Notebook: mk("Notebook", NOTEBOOK),
    NotebookClock: mk("NotebookClock", [...S(NOTEBOOK), ...B_CLOCK]),
    NotebookPlus: mk("NotebookPlus", [...S(NOTEBOOK), ...B_PLUS]),
    NotebookSpiral: mk("NotebookSpiral", [R(5, 2, 16, 20, 2), P("M2 6h5M2 10h5M2 14h5M2 18h5")]),
    NotebookPen: mk("NotebookPen", [R(3, 3, 15, 19, 2), P("M7 3v19"), P("m13 17 8-8 2 2-8 8-3 1z")]),
    NotepadPen: mk("NotepadPen", [R(4, 3, 14, 18, 2), P("M8 8h6M8 12h4M8 16h2"), P("m14 20 1-3 6-6 2 2-6 6z")]),
    Album: mk("Album", [R(3, 2, 18, 20, 2), P("M12 2v20M6 6h3v4H6zM15 6h3v4h-3zM6 14h3v4H6zM15 14h3v4h-3z")]),
    Clipboard: mk("Clipboard", CLIPBOARD),
    ClipboardList: mk("ClipboardList", [...CLIPBOARD, P("M9 12h.01M13 12h3M9 16h.01M13 16h3")]),
    ClipboardCheckPen: mk("ClipboardCheckPen", [...CLIPBOARD, P("m9 14 2 2 4-4")]),
    ListOrdered: mk("ListOrdered", [P("M10 6h11M10 12h11M10 18h11M4 5l1-1v5M4 14.5a1.500 1.500 0 1 1 2.500 1L4 18h3")]),
    Briefcase: mk("Briefcase", BRIEFCASE),
    Portfolio: mk("Portfolio", [R(2, 7, 20, 14, 2), P("M8 7V5a2 2 0 0 1 2-2h4a2 2 0 0 1 2 2v2M2 13h20M10 13v2h4v-2")]),
    Stamp: mk("Stamp", [P("M5 22h14"), P("M19.27 13.73A2.5 2.5 0 0 0 17.5 13h-11A2.5 2.5 0 0 0 4 15.5V17a1 1 0 0 0 1 1h14a1 1 0 0 0 1-1v-1.5c0-.66-.26-1.3-.73-1.77Z"), P("M14 13V8.5C14 7 15 7 15 5a3 3 0 0 0-3-3c-1.66 0-3 1-3 3s1 2 1 3.5V13")]),
    Pencil: mk("Pencil", PENCIL),
    Chalkboard: mk("Chalkboard", [R(3, 3, 18, 12, 1), P("M7 19l1.5-4M17 19l-1.5-4M12 15v6M7 8l2 3M11 7v4M15 8h2")]),
    GradBubble: mk("GradBubble", [P("M21 15a2 2 0 0 1-2 2H7l-4 4V5a2 2 0 0 1 2-2h14a2 2 0 0 1 2 2z"), P("m12 6.500-5.500 2.500L12 11.500l5.500-2.500zM8.500 11v2.500c0 .8 1.500 1.500 3.500 1.500s3.500-.7 3.500-1.500V11")]),
    CardFile: mk("CardFile", [P("M2 13h20v7a1 1 0 0 1-1 1H3a1 1 0 0 1-1-1z"), P("M6 13V3h9l3 3v7M9 7h6M9 10h6M9 17h6")]),
    CardFileStand: mk("CardFileStand", [P("M2 13h20v7a1 1 0 0 1-1 1H3a1 1 0 0 1-1-1z"), P("M7 13V3h9l3 3v7M10 7h6M10 10h6M10 17h6M3 3v6")]),
    CardFilePen: mk("CardFilePen", [P("M2 13h20v7a1 1 0 0 1-1 1H3a1 1 0 0 1-1-1z"), P("M8 13V6h8l2 2v5M11 9h4M11 17h6"), P("m4 9 4-5 2 1.500-4 5z")]),

    /* equipos */
    Printer: mk("Printer", PRINTER),
    Laptop: mk("Laptop", [P("M20 16V7a2 2 0 0 0-2-2H6a2 2 0 0 0-2 2v9m16 0H4m16 0 1.28 2.55a1 1 0 0 1-.9 1.45H3.62a1 1 0 0 1-.9-1.45L4 16")]),
    Monitor: mk("Monitor", [R(2, 3, 20, 14, 2), P("M8 21h8M12 17v4")]),
    Smartphone: mk("Smartphone", [R(5, 2, 14, 20, 2), P("M12 18h.01")]),
    PhoneKeypad: mk("PhoneKeypad", [R(6, 2, 12, 20, 2.5), P("M9 7h.01M12 7h.01M15 7h.01M9 11h.01M12 11h.01M15 11h.01M9 15h.01M12 15h.01M15 15h.01")]),
    Phone: mk("Phone", PHONE),
    PhoneCall: mk("PhoneCall", [...PHONE, P("M14.05 2a9 9 0 0 1 8 7.94M14.05 6A5 5 0 0 1 18 10")]),
    Keypad: mk("Keypad", [R(2, 2, 20, 20, 2), P("M7 7h.01M12 7h.01M17 7h.01M7 12h.01M12 12h.01M17 12h.01M7 17h.01M12 17h.01M17 17h.01")]),
    Gears3: mk("Gears3", [...T(GEAR, "translate(.5 .5) scale(.7)"), ...T(GEAR, "translate(11.5 8) scale(.55)"), ...T(GEAR, "translate(3 13) scale(.5)")]),
    Wrench: mk("Wrench", WRENCH),
    PCWrench: mk("PCWrench", [R(3, 2, 9, 20, 1.5), C(7.5, 17, 1), P("M6 6h3"), ...T(WRENCH, "translate(11 7) scale(.55)")]),
    Engine: mk("Engine", [R(5, 8, 12, 9, 1), P("M8 8V5h6v3M3 11v4M17 11h2M19 9v6M5 17v3h12v-3")]),
    Key: mk("Key", [C(7.5, 15.5, 4.5), P("m10.7 12.3 9.8-9.8M17 6l3 3M14 9l2 2")]),
    Lock: mk("Lock", LOCK),
    LockKey: mk("LockKey", [R(2, 10, 15, 12, 2), P("M5.5 10V7a4 4 0 0 1 8 0v3"), C(19, 15, 2.5), P("M19 17.5V22M19 20h2")]),
    Link: mk("Link", [P("M10 13a5 5 0 0 0 7.54.54l3-3a5 5 0 0 0-7.07-7.07l-1.72 1.71"), P("M14 11a5 5 0 0 0-7.54-.54l-3 3a5 5 0 0 0 7.07 7.07l1.71-1.71")]),
    Search: mk("Search", SEARCH),
    SearchPen: mk("SearchPen", [...S(SEARCH), ...B_PEN]),
    ScanSearch: mk("ScanSearch", [P("M3 7V5a2 2 0 0 1 2-2h2M17 3h2a2 2 0 0 1 2 2v2M21 17v2a2 2 0 0 1-2 2h-2M7 21H5a2 2 0 0 1-2-2v-2"), C(12, 12, 3), P("m16 16-1.9-1.9")]),
    Binoculars: mk("Binoculars", [P("M10 10h4M19 7V4a1 1 0 0 0-1-1h-2a1 1 0 0 0-1 1v3"), P("M20 21a2 2 0 0 0 2-2v-3.851c0-1.39-2-2.962-2-4.829V8a1 1 0 0 0-1-1h-4a1 1 0 0 0-1 1v11a2 2 0 0 0 2 2z"), P("M22 16H2"), P("M4 21a2 2 0 0 1-2-2v-3.851c0-1.39 2-2.962 2-4.829V8a1 1 0 0 1 1-1h4a1 1 0 0 1 1 1v11a2 2 0 0 1-2 2z"), P("M9 7V4a1 1 0 0 0-1-1H6a1 1 0 0 0-1 1v3")]),
    Broom: mk("Broom", [P("M14 10l6.5-6.5"), P("M10 9l5 5c-1 3-3.5 6-8 7l-4-1c1-3 1-5 3-7 1.5-1.5 3.5-3 4-4z"), P("M7 13l4 4")]),
    Camera: mk("Camera", CAMERA),
    CameraPlus: mk("CameraPlus", [...S(CAMERA), ...B_PLUS]),
    Picture: mk("Picture", [R(3, 3, 18, 18, 2), C(9, 9, 1.5), P("m21 15-3.086-3.086a2 2 0 0 0-2.828 0L6 21")]),
    Floppy: mk("Floppy", [P("M15.2 3a2 2 0 0 1 1.4.6l3.8 3.8a2 2 0 0 1 .6 1.4V19a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2z"), P("M17 21v-7a1 1 0 0 0-1-1H8a1 1 0 0 0-1 1v7M7 3v4a1 1 0 0 0 1 1h7")]),
    HardHat: mk("HardHat", HARDHAT),
    B2Mining: mk("B2Mining", [P("M5 10a7 6 0 0 1 14 0H5Z"), ...txt("B2", 8.5, 13.5, 1.5), P("M4 21h16")]),
    Cart: mk("Cart", CART),
    CartPackage: mk("CartPackage", [...S(CART), R(14, 12, 8, 8, 1, { fill: "var(--icon-bg, #fff)" }), P("M14 15h8M18 12v3")]),
    CartHouse: mk("CartHouse", [...CART, P("M9 9.500 12.500 6l3.500 3.500M10 9v3h5V9")]),
    WindowsArrow: mk("WindowsArrow", WINDOWS_ARROW),
    WindowsArrowPlus: mk("WindowsArrowPlus", [...S(WINDOWS_ARROW), ...B_PLUS]),
    Wizard: mk("Wizard", [R(2, 3, 20, 18, 2), P("M2 8h20M6 12h.01M6 15h.01M6 18h.01M9 12h9M9 15h9M9 18h9")]),
    TableX: mk("TableX", [...S([R(2, 3, 20, 16, 2), P("M2 9h20M2 14h20M9 9v10")]), ...B_X]),
    TagNew: mk("TagNew", [R(2, 6, 20, 12, 3), ...txt("NEW", 5.9, 9.5, 1.5)]),
    Digits123: mk("Digits123", txt("123", 3.2, 8, 1.3, 1.6)),
    Warning: mk("Warning", WARN),
    WarningDouble: mk("WarningDouble", [...T(WARN, "translate(-1 5) scale(.72)"), ...T(WARN, "translate(9 1) scale(.72)")]),
    BarChart: mk("BarChart", BARS),
    Pie: mk("Pie", PIE),
    PieBars: mk("PieBars", [P("M3 3v18h18"), P("M11 17v-4M15.500 17v-7M20 17V8"), C(8, 8, 3.5), P("M8 4.500V8h3.500")]),
  }
  return D;
})();

/* ---------- iconos A–Z ---------- */
export const ActivitlIcon = DISENOS.NotebookClock;
export const AbajoIcon = DISENOS.ChevronsDown;
export const AceptarIcon = DISENOS.CircleCheck;
export const Act2Icon = DISENOS.Refresh;
export const ActCuentaIcon = DISENOS.CalcRefresh;
export const ActualizarIcon = DISENOS.Refresh;
export const AfpIcon = DISENOS.DocGlobe;
export const AgregarIcon = DISENOS.ChevronRightToLine;
export const AnularPngIcon = DISENOS.Ban;
export const AnularJpgIcon = DISENOS.TableX;
export const AnularIcoIcon = DISENOS.CircleX;
export const AprobarIcon = DISENOS.Check;
export const AprobarMasIcon = DISENOS.CheckCheck;
export const ArribaIcon = DISENOS.ChevronsUp;
export const AsigHorarioIcon = DISENOS.CalendarClock;
export const AsigJefesIcon = DISENOS.UserBriefcase;
export const AtendProvIcon = DISENOS.FolderPen;
export const AtenderMasivoIcon = DISENOS.Banknotes;
export const BalanceIcon = DISENOS.Scale;
export const BoletaIcon = DISENOS.DocBol;
export const BorrarIcon = DISENOS.X;
export const BuscarIcoIcon = DISENOS.Binoculars;
export const BuscarPngIcon = DISENOS.Binoculars;
export const CoaIcon = DISENOS.Certificate;
export const CajaBancoIcon = DISENOS.MoneyBagCoin;
export const CanjearIcon = DISENOS.Canjear;
export const CapacitacionIcon = DISENOS.Chalkboard;
export const CargoPerIcon = DISENOS.UsersHardHat;
export const CerrarIcon = DISENOS.DoorExit;
export const CerrarPrIcon = DISENOS.Lock;
export const CheckIcon = DISENOS.SquareCheck;
export const Check1Icon = DISENOS.Square;
export const CompraConIcon = DISENOS.CartPackage;
export const ComprasIcon = DISENOS.Cart;
export const ContDiarioIcon = DISENOS.ClipboardCheckPen;
export const CrdFle04Icon = DISENOS.CardFile;
export const CrdFle12Icon = DISENOS.CardFileStand;
export const CrdFle13Icon = DISENOS.CardFilePen;
export const CronogramaIcoIcon = DISENOS.CalendarCheck;
export const DerechaIcon = DISENOS.ChevronsRight;
export const DesExcelDsctosIcon = DISENOS.ExcelPercentDown;
export const DesExcelIngIcon = DISENOS.ExcelCoinsDown;
export const DescPlanillaIcon = DISENOS.Percent;
export const DescargarExcelIcon = DISENOS.ExcelDown;
export const DescuentosPerIcon = DISENOS.PercentDown;
export const DeshacerIcon = DISENOS.Undo;
export const DolarIcon = DISENOS.Dollar;
export const DsctoIcon = DISENOS.Percent;
export const EditarIcon = DISENOS.FilePen;
export const EliminarIcoIcon = DISENOS.X;
export const EliminarPngIcon = DISENOS.FileX;
export const EmbarqueIcon = DISENOS.Truck;
export const EmpresaIcon = DISENOS.Boots;
export const EnviarIcon = DISENOS.DocSend;
export const EnviarPrIcon = DISENOS.MailUp;
export const EquiposIcon = DISENOS.Gears3;
export const FacturaIcon = DISENOS.DocFac;
export const FacturaGuiaIcon = DISENOS.DocFG;
export const FacturarGuiasIcon = DISENOS.DocDollar;
export const FechaIcon = DISENOS.CalendarDigits;
export const FotoNoDisponibleIcon = DISENOS.UserSilhouette;
export const Graph07Icon = DISENOS.BarChart;
export const GearsIcon = DISENOS.Gears3;
export const GenerarIcon = DISENOS.WindowsArrow;
export const GuiaDevolucionIcon = DISENOS.DocGD;
export const GuiaRemisionIcon = DISENOS.DocGR;
export const GrabarIcon = DISENOS.Floppy;
export const HeIconIcon = DISENOS.Clock;
export const HorariosIcon = DISENOS.WindowClock;
export const HorsExtIcon = DISENOS.AlarmPlus;
export const IcoReloj2Icon = DISENOS.Wristwatch;
export const ImgApptRecurIcon = DISENOS.RotateCw;
export const ImgSendReceiveIcon = DISENOS.ArrowLeftRight;
export const ImpExcelIngIcon = DISENOS.ExcelCoinsUp;
export const ImportarExcelIcon = DISENOS.ExcelUp;
export const ImpresoraIcoIcon = DISENOS.Printer;
export const ImpresoraPngIcon = DISENOS.Printer;
export const IngresosIcon = DISENOS.PiggyBank;
export const IngresosPerIcon = DISENOS.HandCoins;
export const InstruccionIcon = DISENOS.GradBubble;
export const IzquierdaIcon = DISENOS.ChevronsLeft;
export const JobMarcaIcon = DISENOS.ClipboardList;
export const KeysIcon = DISENOS.Key;
export const LectorHuellasIcon = DISENOS.FingerprintDevice;
export const LibDiarioIcon = DISENOS.BookOpen;
export const LibMayorIcon = DISENOS.NotebookPlus;
export const LibroDiarioIcon = DISENOS.Book;
export const LibroMayorIcon = DISENOS.BookBookmark;
export const LimpiarPngIcon = DISENOS.Broom;
export const LimpiarJpgIcon = DISENOS.Broom;
export const LlamadaIcon = DISENOS.PhoneCall;
export const LupaIcon = DISENOS.Search;
export const Mail20Icon = DISENOS.Keypad;
export const ManoHaciaAbajoIcon = DISENOS.ThumbsDown;
export const MaterialIcon = DISENOS.Wrench;
export const MaximunIcon = DISENOS.SearchPen;
export const AboutIcon = DISENOS.Info;
export const ActMailIcon = DISENOS.AtSign;
export const ActualizarCostosIcon = DISENOS.RotateCcw;
export const AcumuladaIcon = DISENOS.CirclePlus;
export const AcwizardIcon = DISENOS.Wizard;
export const AdicionarcontenedorIcon = DISENOS.FolderPlus;
export const Admin48Icon = DISENOS.UserTie;
export const AjustarCostosIcon = DISENOS.BookHelp;
export const AlmacenIcon = DISENOS.House;
export const AporPlanillasIcon = DISENOS.MoneyBag;
export const ArbolnavidadIcon = DISENOS.ChristmasTree;
export const AreaCostoIcon = DISENOS.Network;
export const AreaPerIcon = DISENOS.Briefcase;
export const ArqueoCajaIcon = DISENOS.CashRegister;
export const B2miningIcon = DISENOS.B2Mining;
export const BajarEstadoIcon = DISENOS.DocDown;
export const BancosIcon = DISENOS.Safe;
export const Books256Icon = DISENOS.Books;
export const Brcase16Icon = DISENOS.Portfolio;
export const Brcase48Icon = DISENOS.Portfolio;
export const BrochaIcon = DISENOS.Stamp;
export const Bundle256Icon = DISENOS.BanknoteBundle;
export const CalendarIcon = DISENOS.Calendar;
export const CalendarCopiarIcon = DISENOS.CalendarCopy;
export const CalendarEditIcon = DISENOS.CalendarPen;
export const Cam48Icon = DISENOS.Camera;
export const CameraIcon = DISENOS.Camera;
export const Car256Icon = DISENOS.Car;
export const Cartera2Icon = DISENOS.Clipboard;
export const CasaAeropuertoIcon = DISENOS.Plane;
export const CerrarmesIcon = DISENOS.DoorArrowIn;
export const ChequeoIcon = DISENOS.CircleCheck;
export const ClasesIcon = DISENOS.BookBookmark;
export const CleanClienteIcon = DISENOS.Broom;
export const ClienteIcon = DISENOS.UserTie;
export const ComisionIcoIcon = DISENOS.MoneyBag;
export const CompraIcon = DISENOS.ListOrdered;
export const CondensadosIcon = DISENOS.FolderStar;
export const ConsolidadoIcon = DISENOS.NotebookSpiral;
export const ContrasenaIcon = DISENOS.PersonKey;
export const ContratoIcon = DISENOS.DocSign;
export const CoronaIcon = DISENOS.Wreath;
export const CostoVentaIcon = DISENOS.BookUp;
export const CostosIcon = DISENOS.Coins;
export const CotIcoIcon = DISENOS.ScanSearch;
export const CotizacionIcon = DISENOS.Copy;
export const CotizacionTallerIcon = DISENOS.HardHat;
export const CreditoIcon = DISENOS.DocC;
export const CreditosIcon = DISENOS.WalletCoin;
export const CtaDestinoIcon = DISENOS.CalcRound;
export const CtaPngIcon = DISENOS.Calculator;
export const CtasPagarIcon = DISENOS.Cards;
export const CtasCtesIcon = DISENOS.Cards;
export const CtasCtesPendIcon = DISENOS.CardCoins;
export const CuadrarCierreIcon = DISENOS.Album;
export const CuentaMasIcon = DISENOS.Calculator;
export const CuentasCobrarIcon = DISENOS.MoneyBag;
export const CuentasCorrientesIcon = DISENOS.Cards;
export const DesPerMasIcon = DISENOS.PercentPlus;
export const DespachoIcon = DISENOS.HandHelping;
export const DetalleIcon = DISENOS.Search;
export const DiarioAlmacenIcon = DISENOS.Book;
export const DiarioPagoIcon = DISENOS.NotebookPen;
export const DocIcon = DISENOS.Books;
export const DocElecDescargarIcon = DISENOS.InvDown;
export const DocElecEliminarIcon = DISENOS.InvX;
export const DocElecGenerarIcon = DISENOS.InvOk;
export const DocElecLupaIcon = DISENOS.InvSearch;
export const DocumentosEmitidosIcon = DISENOS.FolderOpen;
export const Editar2Icon = DISENOS.Pencil;
export const EquipoMarIcon = DISENOS.FingerprintDevice;
export const EquipoTelefonicoIcon = DISENOS.PhoneKeypad;
export const ExcelIcon = DISENOS.ExcelPercent;
export const ExcelIcoIcon = DISENOS.Excel;
export const ExpLabIcon = DISENOS.UserChecklist;
export const FactDarbajaIcon = DISENOS.InvX;
export const FactDescargarIcon = DISENOS.InvDown;
export const FactGenerarIcon = DISENOS.InvOk;
export const FactLupaIcon = DISENOS.InvSearch;
export const FalMasivoIcon = DISENOS.WarningDouble;
export const FaltasIcoIcon = DISENOS.Warning;
export const FamiliaresIcon = DISENOS.Family;
export const GastoRealRubroIcon = DISENOS.Dollar;
export const GastoRealTotalIcon = DISENOS.Dollar;
export const GastoViajeIcon = DISENOS.Luggage;
export const GastosIcon = DISENOS.Wallet;
export const GenerarMasIcon = DISENOS.WindowsArrowPlus;
export const GenerarPeriodoIcon = DISENOS.TagNew;
export const GerenteIcon = DISENOS.UserTie;
export const GraficaIcon = DISENOS.PlayCircle;
export const HePlanillasIcon = DISENOS.Clock;
export const HelpIcon = DISENOS.HelpSquare;
export const HrsEquipoIcon = DISENOS.ClockGear;
export const IcoRelojIcon = DISENOS.Watch;
export const IcoReloj3Icon = DISENOS.Clock;
export const IcoReloj4Icon = DISENOS.Stopwatch;
export const IdiomaIcon = DISENOS.Flag;
export const ImagenFondoIcon = DISENOS.CameraPlus;
export const Img48Icon = DISENOS.Picture;
export const ImportacionIcon = DISENOS.Plane;
export const Indicadores1Icon = DISENOS.Pie;
export const Indicadores2Icon = DISENOS.BarChart;
export const Indicadores3Icon = DISENOS.PieBars;
export const Indicadorico2Icon = DISENOS.BarChart;
export const Indicadorico3Icon = DISENOS.PieBars;
export const InformaticaIcon = DISENOS.Monitor;
export const IngCtasIcon = DISENOS.MoneyBag;
export const IngPerMasIcon = DISENOS.CoinsPlus;
export const IngPlanillasIcon = DISENOS.MoneyBag;
export const InternoIcon = DISENOS.Truck;
export const InventarioIcon = DISENOS.Digits123;
export const Laptop16Icon = DISENOS.Laptop;
export const Laptop48Icon = DISENOS.Laptop;
export const LetrasAceptadasIcon = DISENOS.ThumbsUp;
export const LibrosContIcon = DISENOS.Books;
export const LineaTelefonicaIcon = DISENOS.Phone;
export const LinkicoIcon = DISENOS.Link;
export const LiquidacionIcon = DISENOS.Dollar;
export const LoginIcon = DISENOS.LockKey;
export const MantenimientoIcon = DISENOS.PCWrench;
export const MarcaIcon = DISENOS.Footprints;
export const MayorAuxIcon = DISENOS.Book;
export const MercaderiaIcon = DISENOS.CartHouse;
export const MesaControlIcon = DISENOS.SquareCheck;
export const MovimientoIcon = DISENOS.CircleArrow;

export const ICONOS = {
  Moneda: MonedaIcon,
  Notas: NotasIcon,
  Nueva_Marcacion: NuevaMarcacionIcon,
  Nuevo: NuevoIcon,
  Nuevo_multiple: NuevoMultipleIcon,
  Office: OfficeIcon,
  Oportunidad_Negocio: OportunidadNegocioIcon,
  PageSetup: PageSetupIcon,
  Pagos: PagosIcon,
  Planillas_Sueldos: PlanillasSueldosIcon,
  Plantilla: PlantillaIcon,
  PreMarcacion: PreMarcacionIcon,
  Procesar: ProcesarIcon,
  Process: ProcessIcon,
  ProcessJob: ProcessJobIcon,
  Provisional: ProvisionalIcon,
  QuickPlay: QuickPlayIcon,
  Recalcular: RecalcularIcon,
  Rechazar: RechazarIcon,
  Rechazar_1: Rechazar1Icon,
  Reembolso: ReembolsoIcon,
  Reg_Compras: RegComprasIcon,
  Regresar: RegresarIcon,
  Reordenar: ReordenarIcon,
  Rep_Asistencia: RepAsistenciaIcon,
  Rep_RegCompras: RepRegComprasIcon,
  Rep_Tardanzas: RepTardanzasIcon,
  Report: ReportIcon,
  SCDRESPS: ScdrespsIcon,
  SecurityLock: SecurityLockIcon,
  Seleccionar: SeleccionarIcon,
  Semaforo: SemaforoIcon,
  Separar__: SepararPuzzleIcon,
  Sol_Gastos: SolGastosIcon,
  Solic_Garantia: SolicGarantiaIcon,
  Sort: SortIcon,
  Sugerir: SugerirIcon,
  Tab: TabIcon,
  Tarifas: TarifasIcon,
  Taxi: TaxiIcon,
  Ticket: TicketIcon,
  Tools: ToolsIcon,
  Transporte: TransporteIcon,
  Trasladar: TrasladarIcon,
  Ubicacion: UbicacionIcon,
  User: UserIcon,
  modelo_telefono: ModeloTelefonoIcon,
  modelos: ModelosIcon,
  motores: MotoresIcon,
  movimiento_ico: MovimientoCircularIcon,
  movimiento_png: MovimientoCarpetaIcon,
  mp_icon: MpIconIcon,
  observacion: ObservacionIcon,
  ocurrencias: OcurrenciasIcon,
  ordenesCompra: OrdenesCompraIcon,
  partidas: PartidasIcon,
  pedidoImportacion: PedidoImportacionIcon,
  pendiente_facturacion: PendienteFacturacionIcon,
  peri_contrato: PeriContratoIcon,
  plan_telefonico: PlanTelefonicoIcon,
  planilla_excel: PlanillaExcelIcon,
  planilla_oficial: PlanillaOficialIcon,
  planillas: PlanillasIcon,
  plantillas: PlantillasIcon,
  precioCore: PrecioCoreIcon,
  proc_cierre_mes: ProcCierreMesIcon,
  proc_cta_dest: ProcCtaDestIcon,
  rechazar3: Rechazar3Icon,
  reclamoGarantia: ReclamoGarantiaMedallaIcon,
  reclamo_garantia: ReclamoGarantiaHojaIcon,
  registro: RegistroIcon,
  registroAuxiliar: RegistroAuxiliarIcon,
  registroResumen: RegistroResumenIcon,
  rep_Reembolso: RepReembolsoIcon,
  rep_personal: RepPersonalIcon,
  resumenGeneral: ResumenGeneralIcon,
  separar: SepararIcon,
  separar_: SepararAmbosIcon,
  sesion_icon: SesionIconIcon,
  sobregiro: SobregiroIcon,
  stock: StockIcon,
  stockValorizado: StockValorizadoIcon,
  tes_asientos: TesAsientosIcon,
  tomaInventario: TomaInventarioIcon,
  torta: TortaIcon,
  transferenciaInterna: TransferenciaInternaIcon,
  transferencias: TransferenciasIcon,
  trasladarCostos: TrasladarCostosIcon,
  upload: UploadIcon,
  users: UsersIcon,
  vacaciones: VacacionesIcon,
  valeMaterial: ValeMaterialIcon,
  valeRequisicion: ValeRequisicionIcon,
  valesMaterial: ValesMaterialIcon,
  var_planillas: VarPlanillasIcon,
  vehiculo_ico: VehiculoIcoIcon,
  velas: VelasIcon,
  vencimientoAcumulada: VencimientoAcumuladaIcon,
  vencimientoDetalle: VencimientoDetalleIcon,
  vencimientos: VencimientosIcon,
  vendedor: VendedorIcon,
  vent: VentIcon,
  ventas: VentasIcon,
  vincular: VincularIcon,
  visitaCobrador: VisitaCobradorIcon,
  workers: WorkersIcon,
  // ---- iconos A–Z ----
  ACTIVITL: ActivitlIcon,
  Abajo: AbajoIcon,
  Aceptar: AceptarIcon,
  Act_2: Act2Icon,
  Act_cuenta: ActCuentaIcon,
  Actualizar: ActualizarIcon,
  Afp: AfpIcon,
  Agregar: AgregarIcon,
  'Anular.png': AnularPngIcon,
  'Anular.jpg': AnularJpgIcon,
  Anular_ico: AnularIcoIcon,
  Aprobar: AprobarIcon,
  Aprobar_Mas: AprobarMasIcon,
  Arriba: ArribaIcon,
  Asig_Horario: AsigHorarioIcon,
  Asig_Jefes: AsigJefesIcon,
  Atend_Prov: AtendProvIcon,
  AtenderMasivo: AtenderMasivoIcon,
  Balance: BalanceIcon,
  Boleta: BoletaIcon,
  Borrar: BorrarIcon,
  'Buscar.ico': BuscarIcoIcon,
  'Buscar.png': BuscarPngIcon,
  COA: CoaIcon,
  CajaBanco: CajaBancoIcon,
  Canjear: CanjearIcon,
  Capacitacion: CapacitacionIcon,
  Cargo_per: CargoPerIcon,
  Cerrar: CerrarIcon,
  Cerrar_Pr: CerrarPrIcon,
  Check: CheckIcon,
  Check1: Check1Icon,
  Compra_Con: CompraConIcon,
  Compras: ComprasIcon,
  Cont_diario: ContDiarioIcon,
  CrdFle04: CrdFle04Icon,
  CrdFle12: CrdFle12Icon,
  CrdFle13: CrdFle13Icon,
  Cronograma_ico: CronogramaIcoIcon,
  Derecha: DerechaIcon,
  DesExcelDsctos: DesExcelDsctosIcon,
  DesExcelIng: DesExcelIngIcon,
  Desc_planilla: DescPlanillaIcon,
  DescargarExcel: DescargarExcelIcon,
  Descuentos_Per: DescuentosPerIcon,
  Deshacer: DeshacerIcon,
  Dolar: DolarIcon,
  Dscto: DsctoIcon,
  Editar: EditarIcon,
  'Eliminar.ico': EliminarIcoIcon,
  'Eliminar.png': EliminarPngIcon,
  Embarque: EmbarqueIcon,
  Empresa: EmpresaIcon,
  Enviar: EnviarIcon,
  Enviar_Pr: EnviarPrIcon,
  Equipos: EquiposIcon,
  Factura: FacturaIcon,
  FacturaGuia: FacturaGuiaIcon,
  FacturarGuias: FacturarGuiasIcon,
  Fecha: FechaIcon,
  FotoNoDisponible: FotoNoDisponibleIcon,
  GRAPH07: Graph07Icon,
  Gears: GearsIcon,
  Generar: GenerarIcon,
  GuiaDevolucion: GuiaDevolucionIcon,
  GuiaRemision: GuiaRemisionIcon,
  Grabar: GrabarIcon,
  HE_icon: HeIconIcon,
  Horarios: HorariosIcon,
  HorsExt: HorsExtIcon,
  Ico_reloj2: IcoReloj2Icon,
  ImgApptRecur: ImgApptRecurIcon,
  ImgSendReceive: ImgSendReceiveIcon,
  ImpExcelIng: ImpExcelIngIcon,
  ImportarExcel: ImportarExcelIcon,
  'Impresora.ico': ImpresoraIcoIcon,
  'Impresora.png': ImpresoraPngIcon,
  Ingresos: IngresosIcon,
  Ingresos_Per: IngresosPerIcon,
  Instruccion: InstruccionIcon,
  Izquierda: IzquierdaIcon,
  Job_Marca: JobMarcaIcon,
  Keys: KeysIcon,
  LectorHuellas: LectorHuellasIcon,
  LibDiario: LibDiarioIcon,
  LibMayor: LibMayorIcon,
  Libro_diario: LibroDiarioIcon,
  Libro_mayor: LibroMayorIcon,
  'Limpiar.png': LimpiarPngIcon,
  'Limpiar.jpg': LimpiarJpgIcon,
  Llamada: LlamadaIcon,
  Lupa: LupaIcon,
  Mail20: Mail20Icon,
  ManoHaciaAbajo: ManoHaciaAbajoIcon,
  Material: MaterialIcon,
  Maximun: MaximunIcon,
  about: AboutIcon,
  act_mail: ActMailIcon,
  actualizarCostos: ActualizarCostosIcon,
  acumulada: AcumuladaIcon,
  acwizard: AcwizardIcon,
  adicionarcontenedor: AdicionarcontenedorIcon,
  admin_48: Admin48Icon,
  ajustarCostos: AjustarCostosIcon,
  almacen: AlmacenIcon,
  apor_planillas: AporPlanillasIcon,
  arbolnavidad: ArbolnavidadIcon,
  area_costo: AreaCostoIcon,
  area_per: AreaPerIcon,
  arqueo_caja: ArqueoCajaIcon,
  b2mining: B2miningIcon,
  bajar_estado: BajarEstadoIcon,
  bancos: BancosIcon,
  books_256: Books256Icon,
  brcase_16: Brcase16Icon,
  brcase_48: Brcase48Icon,
  brocha: BrochaIcon,
  bundle_256: Bundle256Icon,
  calendar: CalendarIcon,
  calendar_copiar: CalendarCopiarIcon,
  calendar_edit: CalendarEditIcon,
  cam_48: Cam48Icon,
  camera: CameraIcon,
  car_256: Car256Icon,
  cartera__2_: Cartera2Icon,
  casa_aeropuerto: CasaAeropuertoIcon,
  cerrarmes: CerrarmesIcon,
  chequeo: ChequeoIcon,
  clases: ClasesIcon,
  cleanCliente: CleanClienteIcon,
  cliente: ClienteIcon,
  comision_ico: ComisionIcoIcon,
  compra: CompraIcon,
  condensados: CondensadosIcon,
  consolidado: ConsolidadoIcon,
  contraseña: ContrasenaIcon,
  contrato: ContratoIcon,
  corona: CoronaIcon,
  costoVenta: CostoVentaIcon,
  costos: CostosIcon,
  cot_ico: CotIcoIcon,
  cotizacion: CotizacionIcon,
  cotizacionTaller: CotizacionTallerIcon,
  credito: CreditoIcon,
  creditos: CreditosIcon,
  cta_destino: CtaDestinoIcon,
  cta_png: CtaPngIcon,
  ctasPagar: CtasPagarIcon,
  ctas_ctes: CtasCtesIcon,
  ctas_ctes_pend: CtasCtesPendIcon,
  cuadrarCierre: CuadrarCierreIcon,
  cuenta_mas: CuentaMasIcon,
  cuentasCobrar: CuentasCobrarIcon,
  cuentasCorrientes: CuentasCorrientesIcon,
  des_per_mas: DesPerMasIcon,
  despacho: DespachoIcon,
  detalle: DetalleIcon,
  diarioAlmacen: DiarioAlmacenIcon,
  diarioPago: DiarioPagoIcon,
  doc: DocIcon,
  doc_elec_descargar: DocElecDescargarIcon,
  doc_elec_eliminar: DocElecEliminarIcon,
  doc_elec_generar: DocElecGenerarIcon,
  doc_elec_lupa: DocElecLupaIcon,
  documentosEmitidos: DocumentosEmitidosIcon,
  editar2: Editar2Icon,
  equipo_mar: EquipoMarIcon,
  equipo_telefonico: EquipoTelefonicoIcon,
  excel: ExcelIcon,
  excel_ico: ExcelIcoIcon,
  exp_lab: ExpLabIcon,
  fact_darbaja: FactDarbajaIcon,
  fact_descargar: FactDescargarIcon,
  fact_generar: FactGenerarIcon,
  fact_lupa: FactLupaIcon,
  fal_masivo: FalMasivoIcon,
  faltas_ico: FaltasIcoIcon,
  familiares: FamiliaresIcon,
  gasto_real_rubro: GastoRealRubroIcon,
  gasto_real_total: GastoRealTotalIcon,
  gasto_viaje: GastoViajeIcon,
  gastos: GastosIcon,
  generar_mas: GenerarMasIcon,
  generarPeriodo: GenerarPeriodoIcon,
  gerente: GerenteIcon,
  grafica: GraficaIcon,
  he_planillas: HePlanillasIcon,
  help: HelpIcon,
  hrs_equipo: HrsEquipoIcon,
  ico_reloj: IcoRelojIcon,
  ico_reloj3: IcoReloj3Icon,
  ico_reloj4: IcoReloj4Icon,
  idioma: IdiomaIcon,
  imagen_fondo: ImagenFondoIcon,
  img_48: Img48Icon,
  importacion: ImportacionIcon,
  indicadores1: Indicadores1Icon,
  indicadores2: Indicadores2Icon,
  indicadores3: Indicadores3Icon,
  indicadorico2: Indicadorico2Icon,
  indicadorico3: Indicadorico3Icon,
  informatica: InformaticaIcon,
  ing_ctas: IngCtasIcon,
  ing_per_mas: IngPerMasIcon,
  ing_planillas: IngPlanillasIcon,
  interno: InternoIcon,
  inventario: InventarioIcon,
  laptop_16: Laptop16Icon,
  laptop_48: Laptop48Icon,
  letrasAceptadas: LetrasAceptadasIcon,
  librosCont: LibrosContIcon,
  linea_telefonica: LineaTelefonicaIcon,
  linkico: LinkicoIcon,
  liquidacion: LiquidacionIcon,
  login: LoginIcon,
  mantenimiento: MantenimientoIcon,
  marca: MarcaIcon,
  mayor_aux: MayorAuxIcon,
  mercaderia: MercaderiaIcon,
  mesa_control: MesaControlIcon,
  movimiento: MovimientoIcon,
} as const;

export type NombreIconoSigecom = keyof typeof ICONOS;
