/**
 * Iconos SIGECOM MONOCROMO (currentColor / line-art).
 * 24x24, estilo Lucide compatible con lucide-react (size, strokeWidth, className, color...).
 *
 * Total iconos: 331
 * Uso:
 *   import { AbajoMonoIcon, ICONOS_MONOCROMO } from './iconos-sigecom-monocromo';
 *   <AbajoMonoIcon size={20} />
 *   const Icono = ICONOS_MONOCROMO['GuiaRemision']; <Icono size={20} />
 */
import { createLucideIcon, type IconNode } from 'lucide-react';

type Atributos = Record<string, string | number>;
type Nodo = [tag: string, attrs: Atributos];

const crear = (nombre: string, nodos: Nodo[]) =>
  createLucideIcon(
    `${nombre}Mono`,
    nodos.map(([tag, resto], i) => {
      const a: Atributos = { ...resto, key: `${nombre}-${i}` };
      
      return [tag, a];
    }) as unknown as IconNode,
  );

/* ---------- Componentes de Iconos ---------- */
export const ActivitlMonoIcon = crear('Activitl', [
    [
      "rect",
      {
        "x": "4",
        "y": "2",
        "width": "16",
        "height": "20",
        "rx": "2",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M2 6h4M2 10h4M2 14h4M2 18h4M10 7h6M10 11h6",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M18 15.3V18l1.8 1"
      }
    ]
  ]);

export const AbajoMonoIcon = crear('Abajo', [
    [
      "path",
      {
        "d": "m7 6 5 5 5-5M7 13l5 5 5-5"
      }
    ]
  ]);

export const AceptarMonoIcon = crear('Aceptar', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "10"
      }
    ],
    [
      "path",
      {
        "d": "m9 12 2 2 4-4"
      }
    ]
  ]);

export const Act2MonoIcon = crear('Act2', [
    [
      "path",
      {
        "d": "M3 12a9 9 0 0 1 9-9 9.75 9.75 0 0 1 6.74 2.74L21 8M21 3v5h-5M21 12a9 9 0 0 1-9 9 9.75 9.75 0 0 1-6.74-2.74L3 16M8 16H3v5"
      }
    ]
  ]);

export const ActCuentaMonoIcon = crear('ActCuenta', [
    [
      "rect",
      {
        "x": "4",
        "y": "2",
        "width": "16",
        "height": "20",
        "rx": "2",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M8 6h8M8 10h.01M12 10h.01M16 10h.01M8 14h.01M12 14h.01M16 14h.01M8 18h.01M12 18h.01M16 18h.01",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M20.3 17.6a2.5 2.5 0 0 0-4.4-.6M15.7 18.4a2.5 2.5 0 0 0 4.4.6M20.4 15.6v2h-2M15.6 20.4v-2h2"
      }
    ]
  ]);

export const ActualizarMonoIcon = crear('Actualizar', [
    [
      "path",
      {
        "d": "M3 12a9 9 0 0 1 9-9 9.75 9.75 0 0 1 6.74 2.74L21 8M21 3v5h-5M21 12a9 9 0 0 1-9 9 9.75 9.75 0 0 1-6.74-2.74L3 16M8 16H3v5"
      }
    ]
  ]);

export const AfpMonoIcon = crear('Afp', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M13.5 18h9M18 13.5c-2 2.4-2 6.6 0 9M18 13.5c2 2.4 2 6.6 0 9"
      }
    ]
  ]);

export const AgregarMonoIcon = crear('Agregar', [
    [
      "path",
      {
        "d": "m5 7 6 5-6 5M18 5v14"
      }
    ]
  ]);

export const AnularPngMonoIcon = crear('AnularPng', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "10"
      }
    ],
    [
      "path",
      {
        "d": "m4.9 4.9 14.2 14.2"
      }
    ]
  ]);

export const AnularJpgMonoIcon = crear('AnularJpg', [
    [
      "rect",
      {
        "x": "2",
        "y": "3",
        "width": "20",
        "height": "16",
        "rx": "2",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M2 9h20M2 14h20M9 9v10",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "m16 16 4 4M20 16l-4 4"
      }
    ]
  ]);

export const AnularIcoMonoIcon = crear('AnularIco', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "10"
      }
    ],
    [
      "path",
      {
        "d": "m15 9-6 6M9 9l6 6"
      }
    ]
  ]);

export const AprobarMonoIcon = crear('Aprobar', [
    [
      "path",
      {
        "d": "M20 6 9 17l-5-5"
      }
    ]
  ]);

export const AprobarMasMonoIcon = crear('AprobarMas', [
    [
      "path",
      {
        "d": "M18 6 7 17l-5-5M22 10l-7.5 7.5L13 16"
      }
    ]
  ]);

export const ArribaMonoIcon = crear('Arriba', [
    [
      "path",
      {
        "d": "m17 11-5-5-5 5M17 18l-5-5-5 5"
      }
    ]
  ]);

export const AsigHorarioMonoIcon = crear('AsigHorario', [
    [
      "rect",
      {
        "x": "3",
        "y": "4",
        "width": "18",
        "height": "18",
        "rx": "2",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M16 2v4M8 2v4M3 10h18",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M18 15.3V18l1.8 1"
      }
    ]
  ]);

export const AsigJefesMonoIcon = crear('AsigJefes', [
    [
      "circle",
      {
        "cx": "9",
        "cy": "6",
        "r": "3.5"
      }
    ],
    [
      "path",
      {
        "d": "M2 20v-2a4 4 0 0 1 4-4h4"
      }
    ],
    [
      "rect",
      {
        "x": "12",
        "y": "13",
        "width": "10",
        "height": "8",
        "rx": "1.5"
      }
    ],
    [
      "path",
      {
        "d": "M15 13v-1.5h4V13"
      }
    ]
  ]);

export const AtendProvMonoIcon = crear('AtendProv', [
    [
      "path",
      {
        "d": "M20 20a2 2 0 0 0 2-2V8a2 2 0 0 0-2-2h-7.9a2 2 0 0 1-1.69-.9L9.6 3.9A2 2 0 0 0 7.93 3H4a2 2 0 0 0-2 2v13a2 2 0 0 0 2 2Z",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "m15.6 20.4 5-5M19 14l2.5 2.5M15.6 20.4l.3-1.9"
      }
    ]
  ]);

export const AtenderMasivoMonoIcon = crear('AtenderMasivo', [
    [
      "rect",
      {
        "x": "2",
        "y": "7",
        "width": "17",
        "height": "11",
        "rx": "2"
      }
    ],
    [
      "circle",
      {
        "cx": "10.5",
        "cy": "12.5",
        "r": "2.2"
      }
    ],
    [
      "path",
      {
        "d": "M5 5h15a2 2 0 0 1 2 2v9"
      }
    ]
  ]);

export const BalanceMonoIcon = crear('Balance', [
    [
      "path",
      {
        "d": "m16 16 3-8 3 8c-.87.65-1.92 1-3 1s-2.13-.35-3-1Z"
      }
    ],
    [
      "path",
      {
        "d": "m2 16 3-8 3 8c-.87.65-1.92 1-3 1s-2.13-.35-3-1Z"
      }
    ],
    [
      "path",
      {
        "d": "M7 21h10M12 3v18M3 7h2c2 0 5-1 7-2 2 1 5 2 7 2h2"
      }
    ]
  ]);

export const BoletaMonoIcon = crear('Boleta', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4"
      }
    ],
    [
      "path",
      {
        "d": "M0 0V5H2L3 4V3L2 2.5L3 2V1L2 0ZM0 2.5H2",
        "transform": "translate(6.1 9.5) scale(1)",
        "strokeWidth": "1.4"
      }
    ],
    [
      "path",
      {
        "d": "M0 0H3V5H0Z",
        "transform": "translate(10.5 9.5) scale(1)",
        "strokeWidth": "1.4"
      }
    ],
    [
      "path",
      {
        "d": "M0 0V5H3",
        "transform": "translate(14.9 9.5) scale(1)",
        "strokeWidth": "1.4"
      }
    ],
    [
      "path",
      {
        "d": "M8 17h8"
      }
    ]
  ]);

export const BorrarMonoIcon = crear('Borrar', [
    [
      "path",
      {
        "d": "M18 6 6 18M6 6l12 12"
      }
    ]
  ]);

export const BuscarIcoMonoIcon = crear('BuscarIco', [
    [
      "path",
      {
        "d": "M10 10h4M19 7V4a1 1 0 0 0-1-1h-2a1 1 0 0 0-1 1v3"
      }
    ],
    [
      "path",
      {
        "d": "M20 21a2 2 0 0 0 2-2v-3.851c0-1.39-2-2.962-2-4.829V8a1 1 0 0 0-1-1h-4a1 1 0 0 0-1 1v11a2 2 0 0 0 2 2z"
      }
    ],
    [
      "path",
      {
        "d": "M22 16H2"
      }
    ],
    [
      "path",
      {
        "d": "M4 21a2 2 0 0 1-2-2v-3.851c0-1.39 2-2.962 2-4.829V8a1 1 0 0 1 1-1h4a1 1 0 0 1 1 1v11a2 2 0 0 1-2 2z"
      }
    ],
    [
      "path",
      {
        "d": "M9 7V4a1 1 0 0 0-1-1H6a1 1 0 0 0-1 1v3"
      }
    ]
  ]);

export const BuscarPngMonoIcon = crear('BuscarPng', [
    [
      "path",
      {
        "d": "M10 10h4M19 7V4a1 1 0 0 0-1-1h-2a1 1 0 0 0-1 1v3"
      }
    ],
    [
      "path",
      {
        "d": "M20 21a2 2 0 0 0 2-2v-3.851c0-1.39-2-2.962-2-4.829V8a1 1 0 0 0-1-1h-4a1 1 0 0 0-1 1v11a2 2 0 0 0 2 2z"
      }
    ],
    [
      "path",
      {
        "d": "M22 16H2"
      }
    ],
    [
      "path",
      {
        "d": "M4 21a2 2 0 0 1-2-2v-3.851c0-1.39 2-2.962 2-4.829V8a1 1 0 0 1 1-1h4a1 1 0 0 1 1 1v11a2 2 0 0 1-2 2z"
      }
    ],
    [
      "path",
      {
        "d": "M9 7V4a1 1 0 0 0-1-1H6a1 1 0 0 0-1 1v3"
      }
    ]
  ]);

export const CoaMonoIcon = crear('Coa', [
    [
      "rect",
      {
        "x": "3",
        "y": "2",
        "width": "14",
        "height": "17",
        "rx": "1.5"
      }
    ],
    [
      "path",
      {
        "d": "M6.5 6h7M6.5 9h7"
      }
    ],
    [
      "circle",
      {
        "cx": "10",
        "cy": "13",
        "r": "2"
      }
    ],
    [
      "path",
      {
        "d": "m14 22 1-3 6-6 2 2-6 6z"
      }
    ]
  ]);

export const CajaBancoMonoIcon = crear('CajaBanco', [
    [
      "path",
      {
        "d": "M9 3h6l-1.5 3h-3z",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M10.5 6C6 8.5 4 12 4 16a5 5 0 0 0 5 5h6a5 5 0 0 0 5-5c0-4-2-7.5-6.5-10",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M14 12.5h-2.2a1.5 1.5 0 0 0 0 3h.4a1.5 1.5 0 0 1 0 3H10M12 11v1.5M12 18.5V20",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "3.5"
      }
    ],
    [
      "path",
      {
        "d": "M18 16.5v3"
      }
    ]
  ]);

export const CanjearMonoIcon = crear('Canjear', [
    [
      "rect",
      {
        "x": "2",
        "y": "2",
        "width": "10",
        "height": "10",
        "rx": "1.5"
      }
    ],
    [
      "path",
      {
        "d": "M7 5v2.5l1.5 1"
      }
    ],
    [
      "path",
      {
        "d": "M15 5h2.5a2 2 0 0 1 2 2v2.5M17 8l2.5 2.5L22 8"
      }
    ],
    [
      "rect",
      {
        "x": "12",
        "y": "14",
        "width": "9",
        "height": "8",
        "rx": "1.5"
      }
    ]
  ]);

export const CapacitacionMonoIcon = crear('Capacitacion', [
    [
      "rect",
      {
        "x": "3",
        "y": "3",
        "width": "18",
        "height": "12",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M7 19l1.5-4M17 19l-1.5-4M12 15v6M7 8l2 3M11 7v4M15 8h2"
      }
    ]
  ]);

export const CargoPerMonoIcon = crear('CargoPer', [
    [
      "path",
      {
        "d": "M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2"
      }
    ],
    [
      "circle",
      {
        "cx": "9",
        "cy": "7",
        "r": "4"
      }
    ],
    [
      "path",
      {
        "d": "M22 21v-2a4 4 0 0 0-3-3.87M16 3.13a4 4 0 0 1 0 7.75"
      }
    ],
    [
      "path",
      {
        "d": "M5.5 5.200a3.500 3.500 0 0 1 7 0M3.500 5.500h11"
      }
    ]
  ]);

export const CerrarMonoIcon = crear('Cerrar', [
    [
      "path",
      {
        "d": "M10 3H6a2 2 0 0 0-2 2v14a2 2 0 0 0 2 2h4M17 8l-4 4 4 4M13 12h8"
      }
    ]
  ]);

export const CerrarPrMonoIcon = crear('CerrarPr', [
    [
      "rect",
      {
        "x": "3",
        "y": "11",
        "width": "18",
        "height": "11",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M7 11V7a5 5 0 0 1 10 0v4"
      }
    ]
  ]);

export const CheckMonoIcon = crear('Check', [
    [
      "rect",
      {
        "x": "3",
        "y": "3",
        "width": "18",
        "height": "18",
        "rx": "3"
      }
    ],
    [
      "path",
      {
        "d": "m9 12 2 2 4-4"
      }
    ]
  ]);

export const Check1MonoIcon = crear('Check1', [
    [
      "rect",
      {
        "x": "3",
        "y": "3",
        "width": "18",
        "height": "18",
        "rx": "3"
      }
    ]
  ]);

export const CompraConMonoIcon = crear('CompraCon', [
    [
      "circle",
      {
        "cx": "8",
        "cy": "21",
        "r": "1",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "19",
        "cy": "21",
        "r": "1",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M2.05 2.05h2l2.66 12.42a2 2 0 0 0 2 1.58h9.78a2 2 0 0 0 1.95-1.57l1.65-7.43H5.12",
        "transform": "scale(.78)"
      }
    ],
    [
      "rect",
      {
        "x": "14",
        "y": "12",
        "width": "8",
        "height": "8",
        "rx": "1",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M14 15h8M18 12v3"
      }
    ]
  ]);

export const ComprasMonoIcon = crear('Compras', [
    [
      "circle",
      {
        "cx": "8",
        "cy": "21",
        "r": "1"
      }
    ],
    [
      "circle",
      {
        "cx": "19",
        "cy": "21",
        "r": "1"
      }
    ],
    [
      "path",
      {
        "d": "M2.05 2.05h2l2.66 12.42a2 2 0 0 0 2 1.58h9.78a2 2 0 0 0 1.95-1.57l1.65-7.43H5.12"
      }
    ]
  ]);

export const ContDiarioMonoIcon = crear('ContDiario', [
    [
      "rect",
      {
        "x": "8",
        "y": "2",
        "width": "8",
        "height": "4",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M16 4h2a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2H6a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2h2"
      }
    ],
    [
      "path",
      {
        "d": "m9 14 2 2 4-4"
      }
    ]
  ]);

export const CrdFle04MonoIcon = crear('CrdFle04', [
    [
      "path",
      {
        "d": "M2 13h20v7a1 1 0 0 1-1 1H3a1 1 0 0 1-1-1z"
      }
    ],
    [
      "path",
      {
        "d": "M6 13V3h9l3 3v7M9 7h6M9 10h6M9 17h6"
      }
    ]
  ]);

export const CrdFle12MonoIcon = crear('CrdFle12', [
    [
      "path",
      {
        "d": "M2 13h20v7a1 1 0 0 1-1 1H3a1 1 0 0 1-1-1z"
      }
    ],
    [
      "path",
      {
        "d": "M7 13V3h9l3 3v7M10 7h6M10 10h6M10 17h6M3 3v6"
      }
    ]
  ]);

export const CrdFle13MonoIcon = crear('CrdFle13', [
    [
      "path",
      {
        "d": "M2 13h20v7a1 1 0 0 1-1 1H3a1 1 0 0 1-1-1z"
      }
    ],
    [
      "path",
      {
        "d": "M8 13V6h8l2 2v5M11 9h4M11 17h6"
      }
    ],
    [
      "path",
      {
        "d": "m4 9 4-5 2 1.500-4 5z"
      }
    ]
  ]);

export const CronogramaIcoMonoIcon = crear('CronogramaIco', [
    [
      "rect",
      {
        "x": "3",
        "y": "4",
        "width": "18",
        "height": "18",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M16 2v4M8 2v4M3 10h18"
      }
    ],
    [
      "path",
      {
        "d": "m9 16 2 2 4-4"
      }
    ]
  ]);

export const DerechaMonoIcon = crear('Derecha', [
    [
      "path",
      {
        "d": "m6 17 5-5-5-5M13 17l5-5-5-5"
      }
    ]
  ]);

export const DesExcelDsctosMonoIcon = crear('DesExcelDsctos', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M12.5 7 7 15"
      }
    ],
    [
      "circle",
      {
        "cx": "7.5",
        "cy": "8",
        "r": "0.7"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "14.5",
        "r": "0.7"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M18 15.5v5M16 18.5l2 2 2-2"
      }
    ]
  ]);

export const DesExcelIngMonoIcon = crear('DesExcelIng', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M10 8v7M12 9.5H9a1.2 1.2 0 0 0 0 2.4h1.6a1.2 1.2 0 0 1 0 2.4H8"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M18 15.5v5M16 18.5l2 2 2-2"
      }
    ]
  ]);

export const DescPlanillaMonoIcon = crear('DescPlanilla', [
    [
      "path",
      {
        "d": "M19 5 5 19"
      }
    ],
    [
      "circle",
      {
        "cx": "6.5",
        "cy": "6.5",
        "r": "2.5"
      }
    ],
    [
      "circle",
      {
        "cx": "17.5",
        "cy": "17.5",
        "r": "2.5"
      }
    ]
  ]);

export const DescargarExcelMonoIcon = crear('DescargarExcel', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "m8.5 11 5 7M13.5 11l-5 7",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M18 15.5v5M16 18.5l2 2 2-2"
      }
    ]
  ]);

export const DescuentosPerMonoIcon = crear('DescuentosPer', [
    [
      "path",
      {
        "d": "M19 5 5 19",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "6.5",
        "cy": "6.5",
        "r": "2.5",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "17.5",
        "cy": "17.5",
        "r": "2.5",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M18 15.5v5M16 18.5l2 2 2-2"
      }
    ]
  ]);

export const DeshacerMonoIcon = crear('Deshacer', [
    [
      "path",
      {
        "d": "M9 14 4 9l5-5"
      }
    ],
    [
      "path",
      {
        "d": "M4 9h10.5a5.5 5.5 0 0 1 5.5 5.5 5.5 5.5 0 0 1-5.5 5.5H11"
      }
    ]
  ]);

export const DolarMonoIcon = crear('Dolar', [
    [
      "path",
      {
        "d": "M12 2v20M17 5H9.5a3.5 3.5 0 0 0 0 7h5a3.5 3.5 0 0 1 0 7H6"
      }
    ]
  ]);

export const DsctoMonoIcon = crear('Dscto', [
    [
      "path",
      {
        "d": "M19 5 5 19"
      }
    ],
    [
      "circle",
      {
        "cx": "6.5",
        "cy": "6.5",
        "r": "2.5"
      }
    ],
    [
      "circle",
      {
        "cx": "17.5",
        "cy": "17.5",
        "r": "2.5"
      }
    ]
  ]);

export const EditarMonoIcon = crear('Editar', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4"
      }
    ],
    [
      "path",
      {
        "d": "M8 11h4M8 15h2"
      }
    ],
    [
      "path",
      {
        "d": "m14 21 1-3 5-5 2 2-5 5z"
      }
    ]
  ]);

export const EliminarIcoMonoIcon = crear('EliminarIco', [
    [
      "path",
      {
        "d": "M18 6 6 18M6 6l12 12"
      }
    ]
  ]);

export const EliminarPngMonoIcon = crear('EliminarPng', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4"
      }
    ],
    [
      "path",
      {
        "d": "m9.5 12.5 5 5M14.5 12.5l-5 5"
      }
    ]
  ]);

export const EmbarqueMonoIcon = crear('Embarque', [
    [
      "path",
      {
        "d": "M14 18V6a2 2 0 0 0-2-2H4a2 2 0 0 0-2 2v11a1 1 0 0 0 1 1h2M15 18H9M19 18h2a1 1 0 0 0 1-1v-3.65a1 1 0 0 0-.22-.62l-3.48-4.35A1 1 0 0 0 17.52 8H14"
      }
    ],
    [
      "circle",
      {
        "cx": "17",
        "cy": "18",
        "r": "2"
      }
    ],
    [
      "circle",
      {
        "cx": "7",
        "cy": "18",
        "r": "2"
      }
    ]
  ]);

export const EmpresaMonoIcon = crear('Empresa', [
    [
      "path",
      {
        "d": "M6 3h6v8c0 1.5 1.2 2.5 3 3l3.5 1.5A2.5 2.5 0 0 1 20 18v2H6z"
      }
    ],
    [
      "path",
      {
        "d": "M6 17h14"
      }
    ]
  ]);

export const EnviarMonoIcon = crear('Enviar', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4"
      }
    ],
    [
      "path",
      {
        "d": "M8 13h8M8 17h8M8 9h2"
      }
    ],
    [
      "path",
      {
        "d": "M1 11h2M1 15h2M1 19h2"
      }
    ]
  ]);

export const EnviarPrMonoIcon = crear('EnviarPr', [
    [
      "rect",
      {
        "x": "2",
        "y": "5",
        "width": "20",
        "height": "15",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "m22 8-8.97 5.2a2 2 0 0 1-2.06 0L2 8"
      }
    ],
    [
      "path",
      {
        "d": "M12 3v5M10 5l2-2 2 2"
      }
    ]
  ]);

export const EquiposMonoIcon = crear('Equipos', [
    [
      "path",
      {
        "d": "M12.22 2h-.44a2 2 0 0 0-2 2v.18a2 2 0 0 1-1 1.73l-.43.25a2 2 0 0 1-2 0l-.15-.08a2 2 0 0 0-2.73.73l-.22.38a2 2 0 0 0 .73 2.73l.15.1a2 2 0 0 1 1 1.72v.51a2 2 0 0 1-1 1.74l-.15.09a2 2 0 0 0-.73 2.73l.22.38a2 2 0 0 0 2.73.73l.15-.08a2 2 0 0 1 2 0l.43.25a2 2 0 0 1 1 1.73V20a2 2 0 0 0 2 2h.44a2 2 0 0 0 2-2v-.18a2 2 0 0 1 1-1.73l.43-.25a2 2 0 0 1 2 0l.15.08a2 2 0 0 0 2.73-.73l.22-.39a2 2 0 0 0-.73-2.73l-.15-.08a2 2 0 0 1-1-1.74v-.5a2 2 0 0 1 1-1.74l.15-.09a2 2 0 0 0 .73-2.73l-.22-.38a2 2 0 0 0-2.73-.73l-.15.08a2 2 0 0 1-2 0l-.43-.25a2 2 0 0 1-1-1.73V4a2 2 0 0 0-2-2z",
        "transform": "translate(.5 .5) scale(.7)"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "3",
        "transform": "translate(.5 .5) scale(.7)"
      }
    ],
    [
      "path",
      {
        "d": "M12.22 2h-.44a2 2 0 0 0-2 2v.18a2 2 0 0 1-1 1.73l-.43.25a2 2 0 0 1-2 0l-.15-.08a2 2 0 0 0-2.73.73l-.22.38a2 2 0 0 0 .73 2.73l.15.1a2 2 0 0 1 1 1.72v.51a2 2 0 0 1-1 1.74l-.15.09a2 2 0 0 0-.73 2.73l.22.38a2 2 0 0 0 2.73.73l.15-.08a2 2 0 0 1 2 0l.43.25a2 2 0 0 1 1 1.73V20a2 2 0 0 0 2 2h.44a2 2 0 0 0 2-2v-.18a2 2 0 0 1 1-1.73l.43-.25a2 2 0 0 1 2 0l.15.08a2 2 0 0 0 2.73-.73l.22-.39a2 2 0 0 0-.73-2.73l-.15-.08a2 2 0 0 1-1-1.74v-.5a2 2 0 0 1 1-1.74l.15-.09a2 2 0 0 0 .73-2.73l-.22-.38a2 2 0 0 0-2.73-.73l-.15.08a2 2 0 0 1-2 0l-.43-.25a2 2 0 0 1-1-1.73V4a2 2 0 0 0-2-2z",
        "transform": "translate(11.5 8) scale(.55)"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "3",
        "transform": "translate(11.5 8) scale(.55)"
      }
    ],
    [
      "path",
      {
        "d": "M12.22 2h-.44a2 2 0 0 0-2 2v.18a2 2 0 0 1-1 1.73l-.43.25a2 2 0 0 1-2 0l-.15-.08a2 2 0 0 0-2.73.73l-.22.38a2 2 0 0 0 .73 2.73l.15.1a2 2 0 0 1 1 1.72v.51a2 2 0 0 1-1 1.74l-.15.09a2 2 0 0 0-.73 2.73l.22.38a2 2 0 0 0 2.73.73l.15-.08a2 2 0 0 1 2 0l.43.25a2 2 0 0 1 1 1.73V20a2 2 0 0 0 2 2h.44a2 2 0 0 0 2-2v-.18a2 2 0 0 1 1-1.73l.43-.25a2 2 0 0 1 2 0l.15.08a2 2 0 0 0 2.73-.73l.22-.39a2 2 0 0 0-.73-2.73l-.15-.08a2 2 0 0 1-1-1.74v-.5a2 2 0 0 1 1-1.74l.15-.09a2 2 0 0 0 .73-2.73l-.22-.38a2 2 0 0 0-2.73-.73l-.15.08a2 2 0 0 1-2 0l-.43-.25a2 2 0 0 1-1-1.73V4a2 2 0 0 0-2-2z",
        "transform": "translate(3 13) scale(.5)"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "3",
        "transform": "translate(3 13) scale(.5)"
      }
    ]
  ]);

export const FacturaMonoIcon = crear('Factura', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4"
      }
    ],
    [
      "path",
      {
        "d": "M3 0H0V5M0 2.5H2",
        "transform": "translate(6.1 9.5) scale(1)",
        "strokeWidth": "1.4"
      }
    ],
    [
      "path",
      {
        "d": "M0 5V1.5L1.5 0L3 1.5V5M0 3H3",
        "transform": "translate(10.5 9.5) scale(1)",
        "strokeWidth": "1.4"
      }
    ],
    [
      "path",
      {
        "d": "M3 0H0V5H3",
        "transform": "translate(14.9 9.5) scale(1)",
        "strokeWidth": "1.4"
      }
    ],
    [
      "path",
      {
        "d": "M8 17h8"
      }
    ]
  ]);

export const FacturaGuiaMonoIcon = crear('FacturaGuia', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4"
      }
    ],
    [
      "path",
      {
        "d": "M3 0H0V5M0 2.5H2",
        "transform": "translate(6.1 9.5) scale(1)",
        "strokeWidth": "1.4"
      }
    ],
    [
      "path",
      {
        "d": "M3 0L0 5",
        "transform": "translate(10.5 9.5) scale(1)",
        "strokeWidth": "1.4"
      }
    ],
    [
      "path",
      {
        "d": "M3 0H0V5H3V2.5H1.5",
        "transform": "translate(14.9 9.5) scale(1)",
        "strokeWidth": "1.4"
      }
    ],
    [
      "path",
      {
        "d": "M8 17h8"
      }
    ]
  ]);

export const FacturarGuiasMonoIcon = crear('FacturarGuias', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4"
      }
    ],
    [
      "path",
      {
        "d": "M12 9v9M14.5 10.5h-3a1.5 1.5 0 0 0 0 3h1a1.5 1.5 0 0 1 0 3H9.5"
      }
    ]
  ]);

export const FechaMonoIcon = crear('Fecha', [
    [
      "rect",
      {
        "x": "3",
        "y": "4",
        "width": "18",
        "height": "18",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M16 2v4M8 2v4M3 10h18"
      }
    ],
    [
      "path",
      {
        "d": "M.4 1.2L1.6 0V5",
        "transform": "translate(8.2 13.2) scale(1)",
        "strokeWidth": "1.5"
      }
    ],
    [
      "path",
      {
        "d": "M0 1L1 0H2L3 1V2L0 5H3",
        "transform": "translate(12.6 13.2) scale(1)",
        "strokeWidth": "1.5"
      }
    ]
  ]);

export const FotoNoDisponibleMonoIcon = crear('FotoNoDisponible', [
    [
      "rect",
      {
        "x": "2",
        "y": "2",
        "width": "20",
        "height": "20",
        "rx": "2"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "9",
        "r": "3.5"
      }
    ],
    [
      "path",
      {
        "d": "M5 22c.5-4 3.5-6 7-6s6.5 2 7 6"
      }
    ]
  ]);

export const Graph07MonoIcon = crear('Graph07', [
    [
      "path",
      {
        "d": "M3 3v16a2 2 0 0 0 2 2h16"
      }
    ],
    [
      "path",
      {
        "d": "M7 17v-3M11 17v-6M15 17V8M19 17V5"
      }
    ]
  ]);

export const GearsMonoIcon = crear('Gears', [
    [
      "path",
      {
        "d": "M12.22 2h-.44a2 2 0 0 0-2 2v.18a2 2 0 0 1-1 1.73l-.43.25a2 2 0 0 1-2 0l-.15-.08a2 2 0 0 0-2.73.73l-.22.38a2 2 0 0 0 .73 2.73l.15.1a2 2 0 0 1 1 1.72v.51a2 2 0 0 1-1 1.74l-.15.09a2 2 0 0 0-.73 2.73l.22.38a2 2 0 0 0 2.73.73l.15-.08a2 2 0 0 1 2 0l.43.25a2 2 0 0 1 1 1.73V20a2 2 0 0 0 2 2h.44a2 2 0 0 0 2-2v-.18a2 2 0 0 1 1-1.73l.43-.25a2 2 0 0 1 2 0l.15.08a2 2 0 0 0 2.73-.73l.22-.39a2 2 0 0 0-.73-2.73l-.15-.08a2 2 0 0 1-1-1.74v-.5a2 2 0 0 1 1-1.74l.15-.09a2 2 0 0 0 .73-2.73l-.22-.38a2 2 0 0 0-2.73-.73l-.15.08a2 2 0 0 1-2 0l-.43-.25a2 2 0 0 1-1-1.73V4a2 2 0 0 0-2-2z",
        "transform": "translate(.5 .5) scale(.7)"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "3",
        "transform": "translate(.5 .5) scale(.7)"
      }
    ],
    [
      "path",
      {
        "d": "M12.22 2h-.44a2 2 0 0 0-2 2v.18a2 2 0 0 1-1 1.73l-.43.25a2 2 0 0 1-2 0l-.15-.08a2 2 0 0 0-2.73.73l-.22.38a2 2 0 0 0 .73 2.73l.15.1a2 2 0 0 1 1 1.72v.51a2 2 0 0 1-1 1.74l-.15.09a2 2 0 0 0-.73 2.73l.22.38a2 2 0 0 0 2.73.73l.15-.08a2 2 0 0 1 2 0l.43.25a2 2 0 0 1 1 1.73V20a2 2 0 0 0 2 2h.44a2 2 0 0 0 2-2v-.18a2 2 0 0 1 1-1.73l.43-.25a2 2 0 0 1 2 0l.15.08a2 2 0 0 0 2.73-.73l.22-.39a2 2 0 0 0-.73-2.73l-.15-.08a2 2 0 0 1-1-1.74v-.5a2 2 0 0 1 1-1.74l.15-.09a2 2 0 0 0 .73-2.73l-.22-.38a2 2 0 0 0-2.73-.73l-.15.08a2 2 0 0 1-2 0l-.43-.25a2 2 0 0 1-1-1.73V4a2 2 0 0 0-2-2z",
        "transform": "translate(11.5 8) scale(.55)"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "3",
        "transform": "translate(11.5 8) scale(.55)"
      }
    ],
    [
      "path",
      {
        "d": "M12.22 2h-.44a2 2 0 0 0-2 2v.18a2 2 0 0 1-1 1.73l-.43.25a2 2 0 0 1-2 0l-.15-.08a2 2 0 0 0-2.73.73l-.22.38a2 2 0 0 0 .73 2.73l.15.1a2 2 0 0 1 1 1.72v.51a2 2 0 0 1-1 1.74l-.15.09a2 2 0 0 0-.73 2.73l.22.38a2 2 0 0 0 2.73.73l.15-.08a2 2 0 0 1 2 0l.43.25a2 2 0 0 1 1 1.73V20a2 2 0 0 0 2 2h.44a2 2 0 0 0 2-2v-.18a2 2 0 0 1 1-1.73l.43-.25a2 2 0 0 1 2 0l.15.08a2 2 0 0 0 2.73-.73l.22-.39a2 2 0 0 0-.73-2.73l-.15-.08a2 2 0 0 1-1-1.74v-.5a2 2 0 0 1 1-1.74l.15-.09a2 2 0 0 0 .73-2.73l-.22-.38a2 2 0 0 0-2.73-.73l-.15.08a2 2 0 0 1-2 0l-.43-.25a2 2 0 0 1-1-1.73V4a2 2 0 0 0-2-2z",
        "transform": "translate(3 13) scale(.5)"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "3",
        "transform": "translate(3 13) scale(.5)"
      }
    ]
  ]);

export const GenerarMonoIcon = crear('Generar', [
    [
      "rect",
      {
        "x": "3",
        "y": "12",
        "width": "10",
        "height": "9",
        "rx": "1.5"
      }
    ],
    [
      "path",
      {
        "d": "M6 16h4"
      }
    ],
    [
      "path",
      {
        "d": "M20 4 13 11M20 4v5M20 4h-5"
      }
    ]
  ]);

export const GuiaDevolucionMonoIcon = crear('GuiaDevolucion', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4"
      }
    ],
    [
      "path",
      {
        "d": "M3 0H0V5H3V2.5H1.5",
        "transform": "translate(6.1 9.5) scale(1)",
        "strokeWidth": "1.4"
      }
    ],
    [
      "path",
      {
        "d": "M3 0L0 5",
        "transform": "translate(10.5 9.5) scale(1)",
        "strokeWidth": "1.4"
      }
    ],
    [
      "path",
      {
        "d": "M0 0V5H2L3 4V1L2 0Z",
        "transform": "translate(14.9 9.5) scale(1)",
        "strokeWidth": "1.4"
      }
    ],
    [
      "path",
      {
        "d": "M8 17h8"
      }
    ]
  ]);

export const GuiaRemisionMonoIcon = crear('GuiaRemision', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4"
      }
    ],
    [
      "path",
      {
        "d": "M3 0H0V5H3V2.5H1.5",
        "transform": "translate(6.1 9.5) scale(1)",
        "strokeWidth": "1.4"
      }
    ],
    [
      "path",
      {
        "d": "M3 0L0 5",
        "transform": "translate(10.5 9.5) scale(1)",
        "strokeWidth": "1.4"
      }
    ],
    [
      "path",
      {
        "d": "M0 5V0H2L3 1V1.5L2 2.5H0M2 2.5L3 5",
        "transform": "translate(14.9 9.5) scale(1)",
        "strokeWidth": "1.4"
      }
    ],
    [
      "path",
      {
        "d": "M8 17h8"
      }
    ]
  ]);

export const GrabarMonoIcon = crear('Grabar', [
    [
      "path",
      {
        "d": "M15.2 3a2 2 0 0 1 1.4.6l3.8 3.8a2 2 0 0 1 .6 1.4V19a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2z"
      }
    ],
    [
      "path",
      {
        "d": "M17 21v-7a1 1 0 0 0-1-1H8a1 1 0 0 0-1 1v7M7 3v4a1 1 0 0 0 1 1h7"
      }
    ]
  ]);

export const HeIconMonoIcon = crear('HeIcon', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "10"
      }
    ],
    [
      "path",
      {
        "d": "M12 6v6l4 2"
      }
    ]
  ]);

export const HorariosMonoIcon = crear('Horarios', [
    [
      "rect",
      {
        "x": "2",
        "y": "3",
        "width": "20",
        "height": "16",
        "rx": "2",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M2 8h20M6 12h5M6 15h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M18 15.3V18l1.8 1"
      }
    ]
  ]);

export const HorsExtMonoIcon = crear('HorsExt', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "13",
        "r": "8",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M12 9v4l2 2M5 3 2 6M22 6l-3-3M6 19l-2 2M18 19l2 2",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M18 15.5v5M15.5 18h5"
      }
    ]
  ]);

export const IcoReloj2MonoIcon = crear('IcoReloj2', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "6"
      }
    ],
    [
      "path",
      {
        "d": "M12 9v3l1.5 1M16.13 7.66l-.81-4.05a2 2 0 0 0-2-1.61h-2.68a2 2 0 0 0-2 1.61l-.78 4.05M7.88 16.36l.8 4a2 2 0 0 0 2 1.61h2.72a2 2 0 0 0 2-1.61l.81-4.05"
      }
    ]
  ]);

export const ImgApptRecurMonoIcon = crear('ImgApptRecur', [
    [
      "path",
      {
        "d": "M21 12a9 9 0 1 1-9-9c2.52 0 4.93 1 6.74 2.74L21 8M21 3v5h-5"
      }
    ]
  ]);

export const ImgSendReceiveMonoIcon = crear('ImgSendReceive', [
    [
      "path",
      {
        "d": "M8 3 4 7l4 4M4 7h16M16 21l4-4-4-4M20 17H4"
      }
    ]
  ]);

export const ImpExcelIngMonoIcon = crear('ImpExcelIng', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M10 8v7M12 9.5H9a1.2 1.2 0 0 0 0 2.4h1.6a1.2 1.2 0 0 1 0 2.4H8"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M18 20.5v-5M16 17.5l2-2 2 2"
      }
    ]
  ]);

export const ImportarExcelMonoIcon = crear('ImportarExcel', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "m8.5 11 5 7M13.5 11l-5 7",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M18 20.5v-5M16 17.5l2-2 2 2"
      }
    ]
  ]);

export const ImpresoraIcoMonoIcon = crear('ImpresoraIco', [
    [
      "path",
      {
        "d": "M6 18H4a2 2 0 0 1-2-2v-5a2 2 0 0 1 2-2h16a2 2 0 0 1 2 2v5a2 2 0 0 1-2 2h-2"
      }
    ],
    [
      "path",
      {
        "d": "M6 9V3a1 1 0 0 1 1-1h10a1 1 0 0 1 1 1v6"
      }
    ],
    [
      "rect",
      {
        "x": "6",
        "y": "14",
        "width": "12",
        "height": "8",
        "rx": "1"
      }
    ]
  ]);

export const ImpresoraPngMonoIcon = crear('ImpresoraPng', [
    [
      "path",
      {
        "d": "M6 18H4a2 2 0 0 1-2-2v-5a2 2 0 0 1 2-2h16a2 2 0 0 1 2 2v5a2 2 0 0 1-2 2h-2"
      }
    ],
    [
      "path",
      {
        "d": "M6 9V3a1 1 0 0 1 1-1h10a1 1 0 0 1 1 1v6"
      }
    ],
    [
      "rect",
      {
        "x": "6",
        "y": "14",
        "width": "12",
        "height": "8",
        "rx": "1"
      }
    ]
  ]);

export const IngresosMonoIcon = crear('Ingresos', [
    [
      "path",
      {
        "d": "M19 5c-1.5 0-2.8 1.4-3 2-3.5-1.5-11-.3-11 5 0 1.8 0 3 2 4.5V20h4v-2h3v2h4v-4c1-.5 1.7-1 2-2h2v-4h-2c0-1-.5-1.5-1-2V5z"
      }
    ],
    [
      "path",
      {
        "d": "M2 9.5a2 2 0 0 0 2 2M16 11h.01"
      }
    ]
  ]);

export const IngresosPerMonoIcon = crear('IngresosPer', [
    [
      "path",
      {
        "d": "M11 15h2a2 2 0 1 0 0-4h-3c-.6 0-1.1.2-1.4.6L3 17"
      }
    ],
    [
      "path",
      {
        "d": "m7 21 1.6-1.4c.3-.4.8-.6 1.4-.6h4c1.1 0 2.1-.4 2.8-1.2l4.6-4.4a2 2 0 0 0-2.75-2.91l-4.2 3.9"
      }
    ],
    [
      "path",
      {
        "d": "m2 16 6 6"
      }
    ],
    [
      "circle",
      {
        "cx": "16",
        "cy": "9",
        "r": "2.9"
      }
    ],
    [
      "path",
      {
        "d": "M16 5.1v.2"
      }
    ]
  ]);

export const InstruccionMonoIcon = crear('Instruccion', [
    [
      "path",
      {
        "d": "M21 15a2 2 0 0 1-2 2H7l-4 4V5a2 2 0 0 1 2-2h14a2 2 0 0 1 2 2z"
      }
    ],
    [
      "path",
      {
        "d": "m12 6.500-5.500 2.500L12 11.500l5.500-2.500zM8.500 11v2.500c0 .8 1.500 1.500 3.500 1.500s3.500-.7 3.500-1.500V11"
      }
    ]
  ]);

export const IzquierdaMonoIcon = crear('Izquierda', [
    [
      "path",
      {
        "d": "m11 17-5-5 5-5M18 17l-5-5 5-5"
      }
    ]
  ]);

export const JobMarcaMonoIcon = crear('JobMarca', [
    [
      "rect",
      {
        "x": "8",
        "y": "2",
        "width": "8",
        "height": "4",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M16 4h2a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2H6a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2h2"
      }
    ],
    [
      "path",
      {
        "d": "M9 12h.01M13 12h3M9 16h.01M13 16h3"
      }
    ]
  ]);

export const KeysMonoIcon = crear('Keys', [
    [
      "circle",
      {
        "cx": "7.5",
        "cy": "15.5",
        "r": "4.5"
      }
    ],
    [
      "path",
      {
        "d": "m10.7 12.3 9.8-9.8M17 6l3 3M14 9l2 2"
      }
    ]
  ]);

export const LectorHuellasMonoIcon = crear('LectorHuellas', [
    [
      "rect",
      {
        "x": "3",
        "y": "2",
        "width": "18",
        "height": "20",
        "rx": "2"
      }
    ],
    [
      "rect",
      {
        "x": "6",
        "y": "5",
        "width": "12",
        "height": "7",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M7 16h.01M10 16h.01M13 16h.01M7 19h.01M10 19h.01M13 19h.01"
      }
    ],
    [
      "rect",
      {
        "x": "16",
        "y": "15",
        "width": "3",
        "height": "5",
        "rx": "1.5"
      }
    ]
  ]);

export const LibDiarioMonoIcon = crear('LibDiario', [
    [
      "path",
      {
        "d": "M12 7v14"
      }
    ],
    [
      "path",
      {
        "d": "M3 18a1 1 0 0 1-1-1V4a1 1 0 0 1 1-1h5a4 4 0 0 1 4 4 4 4 0 0 1 4-4h5a1 1 0 0 1 1 1v13a1 1 0 0 1-1 1h-6a3 3 0 0 0-3 3 3 3 0 0 0-3-3z"
      }
    ],
    [
      "path",
      {
        "d": "M5 8h3M5 12h3M16 8h3M16 12h3"
      }
    ]
  ]);

export const LibMayorMonoIcon = crear('LibMayor', [
    [
      "rect",
      {
        "x": "4",
        "y": "2",
        "width": "16",
        "height": "20",
        "rx": "2",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M2 6h4M2 10h4M2 14h4M2 18h4M10 7h6M10 11h6",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M18 15.5v5M15.5 18h5"
      }
    ]
  ]);

export const LibroDiarioMonoIcon = crear('LibroDiario', [
    [
      "path",
      {
        "d": "M4 19.5v-15A2.5 2.5 0 0 1 6.5 2H19a1 1 0 0 1 1 1v18a1 1 0 0 1-1 1H6.5a1 1 0 0 1 0-5H20"
      }
    ]
  ]);

export const LibroMayorMonoIcon = crear('LibroMayor', [
    [
      "path",
      {
        "d": "M10 2v8l3-3 3 3V2"
      }
    ],
    [
      "path",
      {
        "d": "M4 19.5v-15A2.5 2.5 0 0 1 6.5 2H19a1 1 0 0 1 1 1v18a1 1 0 0 1-1 1H6.5a1 1 0 0 1 0-5H20"
      }
    ]
  ]);

export const LimpiarPngMonoIcon = crear('LimpiarPng', [
    [
      "path",
      {
        "d": "M14 10l6.5-6.5"
      }
    ],
    [
      "path",
      {
        "d": "M10 9l5 5c-1 3-3.5 6-8 7l-4-1c1-3 1-5 3-7 1.5-1.5 3.5-3 4-4z"
      }
    ],
    [
      "path",
      {
        "d": "M7 13l4 4"
      }
    ]
  ]);

export const LimpiarJpgMonoIcon = crear('LimpiarJpg', [
    [
      "path",
      {
        "d": "M14 10l6.5-6.5"
      }
    ],
    [
      "path",
      {
        "d": "M10 9l5 5c-1 3-3.5 6-8 7l-4-1c1-3 1-5 3-7 1.5-1.5 3.5-3 4-4z"
      }
    ],
    [
      "path",
      {
        "d": "M7 13l4 4"
      }
    ]
  ]);

export const LlamadaMonoIcon = crear('Llamada', [
    [
      "path",
      {
        "d": "M22 16.92v3a2 2 0 0 1-2.18 2 19.79 19.79 0 0 1-8.63-3.07 19.5 19.5 0 0 1-6-6 19.79 19.79 0 0 1-3.07-8.67A2 2 0 0 1 4.11 2h3a2 2 0 0 1 2 1.72 12.84 12.84 0 0 0 .7 2.81 2 2 0 0 1-.45 2.11L8.09 9.91a16 16 0 0 0 6 6l1.27-1.27a2 2 0 0 1 2.11-.45 12.84 12.84 0 0 0 2.81.7A2 2 0 0 1 22 16.92z"
      }
    ],
    [
      "path",
      {
        "d": "M14.05 2a9 9 0 0 1 8 7.94M14.05 6A5 5 0 0 1 18 10"
      }
    ]
  ]);

export const LupaMonoIcon = crear('Lupa', [
    [
      "circle",
      {
        "cx": "11",
        "cy": "11",
        "r": "8"
      }
    ],
    [
      "path",
      {
        "d": "m21 21-4.3-4.3"
      }
    ]
  ]);

export const Mail20MonoIcon = crear('Mail20', [
    [
      "rect",
      {
        "x": "2",
        "y": "2",
        "width": "20",
        "height": "20",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M7 7h.01M12 7h.01M17 7h.01M7 12h.01M12 12h.01M17 12h.01M7 17h.01M12 17h.01M17 17h.01"
      }
    ]
  ]);

export const ManoHaciaAbajoMonoIcon = crear('ManoHaciaAbajo', [
    [
      "path",
      {
        "d": "M7 10v12",
        "transform": "translate(0 24) scale(1 -1)"
      }
    ],
    [
      "path",
      {
        "d": "M15 5.88 14 10h5.83a2 2 0 0 1 1.92 2.56l-2.33 8A2 2 0 0 1 17.5 22H4a2 2 0 0 1-2-2v-8a2 2 0 0 1 2-2h2.76a2 2 0 0 0 1.79-1.11L12 2a3.13 3.13 0 0 1 3 3.88Z",
        "transform": "translate(0 24) scale(1 -1)"
      }
    ]
  ]);

export const MaterialMonoIcon = crear('Material', [
    [
      "path",
      {
        "d": "M14.7 6.3a1 1 0 0 0 0 1.4l1.6 1.6a1 1 0 0 0 1.4 0l3.77-3.77a6 6 0 0 1-7.94 7.94l-6.91 6.91a2.12 2.12 0 0 1-3-3l6.91-6.91a6 6 0 0 1 7.94-7.94l-3.76 3.76z"
      }
    ]
  ]);

export const MaximunMonoIcon = crear('Maximun', [
    [
      "circle",
      {
        "cx": "11",
        "cy": "11",
        "r": "8",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "m21 21-4.3-4.3",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "m15.6 20.4 5-5M19 14l2.5 2.5M15.6 20.4l.3-1.9"
      }
    ]
  ]);

export const NotasMonoIcon = crear('Notas', [
    [
      "rect",
      {
        "x": "3",
        "y": "3",
        "width": "18",
        "height": "18",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M7 8h6"
      }
    ],
    [
      "path",
      {
        "d": "M7 12h10"
      }
    ],
    [
      "path",
      {
        "d": "M7 16h8"
      }
    ]
  ]);

export const NuevaMarcacionMonoIcon = crear('NuevaMarcacion', [
    [
      "path",
      {
        "d": "M21 12a9 9 0 1 1-9-9"
      }
    ],
    [
      "path",
      {
        "d": "M12 7v5l3 2"
      }
    ],
    [
      "path",
      {
        "d": "M19 2v6"
      }
    ],
    [
      "path",
      {
        "d": "M16 5h6"
      }
    ]
  ]);

export const NuevoMultipleMonoIcon = crear('NuevoMultiple', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7Z"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4"
      }
    ],
    [
      "path",
      {
        "d": "M12 11v6"
      }
    ],
    [
      "path",
      {
        "d": "M9 14h6"
      }
    ],
    [
      "path",
      {
        "d": "M2 8v12a2 2 0 0 0 2 2"
      }
    ]
  ]);

export const OfficeMonoIcon = crear('Office', [
    [
      "rect",
      {
        "x": "4",
        "y": "2",
        "width": "16",
        "height": "20",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M9 22v-4h6v4"
      }
    ],
    [
      "path",
      {
        "d": "M8 6h.01"
      }
    ],
    [
      "path",
      {
        "d": "M12 6h.01"
      }
    ],
    [
      "path",
      {
        "d": "M16 6h.01"
      }
    ],
    [
      "path",
      {
        "d": "M8 10h.01"
      }
    ],
    [
      "path",
      {
        "d": "M12 10h.01"
      }
    ],
    [
      "path",
      {
        "d": "M16 10h.01"
      }
    ],
    [
      "path",
      {
        "d": "M8 14h.01"
      }
    ],
    [
      "path",
      {
        "d": "M12 14h.01"
      }
    ],
    [
      "path",
      {
        "d": "M16 14h.01"
      }
    ]
  ]);

export const PagosMonoIcon = crear('Pagos', [
    [
      "path",
      {
        "d": "M11 15h2a2 2 0 1 0 0-4h-3c-.6 0-1.1.2-1.4.6L3 17"
      }
    ],
    [
      "path",
      {
        "d": "m7 21 1.6-1.4c.3-.4.8-.6 1.4-.6h4c1.1 0 2.1-.4 2.8-1.2l4.6-4.4a2 2 0 0 0-2.75-2.91l-4.2 3.9"
      }
    ],
    [
      "path",
      {
        "d": "m2 16 6 6"
      }
    ],
    [
      "circle",
      {
        "cx": "16",
        "cy": "9",
        "r": "2.9"
      }
    ],
    [
      "circle",
      {
        "cx": "6",
        "cy": "5",
        "r": "3"
      }
    ]
  ]);

export const AboutMonoIcon = crear('About', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "10"
      }
    ],
    [
      "path",
      {
        "d": "M12 16v-4M12 8h.01"
      }
    ]
  ]);

export const ActMailMonoIcon = crear('ActMail', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "4"
      }
    ],
    [
      "path",
      {
        "d": "M16 8v5a3 3 0 0 0 6 0v-1a10 10 0 1 0-4 8"
      }
    ]
  ]);

export const ActualizarCostosMonoIcon = crear('ActualizarCostos', [
    [
      "path",
      {
        "d": "M3 12a9 9 0 1 0 9-9 9.75 9.75 0 0 0-6.74 2.74L3 8M3 3v5h5"
      }
    ]
  ]);

export const AcumuladaMonoIcon = crear('Acumulada', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "10"
      }
    ],
    [
      "path",
      {
        "d": "M8 12h8M12 8v8"
      }
    ]
  ]);

export const AcwizardMonoIcon = crear('Acwizard', [
    [
      "rect",
      {
        "x": "2",
        "y": "3",
        "width": "20",
        "height": "18",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M2 8h20M6 12h.01M6 15h.01M6 18h.01M9 12h9M9 15h9M9 18h9"
      }
    ]
  ]);

export const AdicionarcontenedorMonoIcon = crear('Adicionarcontenedor', [
    [
      "path",
      {
        "d": "M20 20a2 2 0 0 0 2-2V8a2 2 0 0 0-2-2h-7.9a2 2 0 0 1-1.69-.9L9.6 3.9A2 2 0 0 0 7.93 3H4a2 2 0 0 0-2 2v13a2 2 0 0 0 2 2Z"
      }
    ],
    [
      "path",
      {
        "d": "M12 10v6M9 13h6"
      }
    ]
  ]);

export const Admin48MonoIcon = crear('Admin48', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "7",
        "r": "4"
      }
    ],
    [
      "path",
      {
        "d": "M5 21v-2a4 4 0 0 1 4-4h6a4 4 0 0 1 4 4v2M12 15l-1.2 1.8L12 21l1.2-3.2z"
      }
    ]
  ]);

export const AjustarCostosMonoIcon = crear('AjustarCostos', [
    [
      "path",
      {
        "d": "M4 19.5v-15A2.5 2.5 0 0 1 6.5 2H19a1 1 0 0 1 1 1v18a1 1 0 0 1-1 1H6.5a1 1 0 0 1 0-5H20"
      }
    ],
    [
      "path",
      {
        "d": "M9.5 8a2.5 2.5 0 0 1 5 .5c0 1.5-2.500 2-2.500 3.500M12 15h.01"
      }
    ]
  ]);

export const AlmacenMonoIcon = crear('Almacen', [
    [
      "path",
      {
        "d": "M3 11 12 3l9 8M5 9.5V21h14V9.5M10 21v-6h4v6M16 5.5V3h2v4"
      }
    ]
  ]);

export const AporPlanillasMonoIcon = crear('AporPlanillas', [
    [
      "path",
      {
        "d": "M9 3h6l-1.5 3h-3z"
      }
    ],
    [
      "path",
      {
        "d": "M10.5 6C6 8.5 4 12 4 16a5 5 0 0 0 5 5h6a5 5 0 0 0 5-5c0-4-2-7.5-6.5-10"
      }
    ],
    [
      "path",
      {
        "d": "M14 12.5h-2.2a1.5 1.5 0 0 0 0 3h.4a1.5 1.5 0 0 1 0 3H10M12 11v1.5M12 18.5V20"
      }
    ]
  ]);

export const ArbolnavidadMonoIcon = crear('Arbolnavidad', [
    [
      "path",
      {
        "d": "m12 3-5 6h3l-5 6h4l-3 5h12l-3-5h4l-5-6h3z"
      }
    ],
    [
      "path",
      {
        "d": "M12 20v2"
      }
    ]
  ]);

export const AreaCostoMonoIcon = crear('AreaCosto', [
    [
      "rect",
      {
        "x": "16",
        "y": "16",
        "width": "6",
        "height": "6",
        "rx": "1"
      }
    ],
    [
      "rect",
      {
        "x": "2",
        "y": "16",
        "width": "6",
        "height": "6",
        "rx": "1"
      }
    ],
    [
      "rect",
      {
        "x": "9",
        "y": "2",
        "width": "6",
        "height": "6",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M5 16v-3a1 1 0 0 1 1-1h12a1 1 0 0 1 1 1v3M12 12V8"
      }
    ]
  ]);

export const AreaPerMonoIcon = crear('AreaPer', [
    [
      "rect",
      {
        "x": "2",
        "y": "7",
        "width": "20",
        "height": "14",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M16 21V5a2 2 0 0 0-2-2h-4a2 2 0 0 0-2 2v16"
      }
    ]
  ]);

export const ArqueoCajaMonoIcon = crear('ArqueoCaja', [
    [
      "path",
      {
        "d": "M8 8V2h8v6"
      }
    ],
    [
      "path",
      {
        "d": "M4 8h16l2 8v4a1 1 0 0 1-1 1H3a1 1 0 0 1-1-1v-4z"
      }
    ],
    [
      "path",
      {
        "d": "M7 12h.01M11 12h.01M15 12h.01M7 16h.01M11 16h.01M15 16h3"
      }
    ]
  ]);

export const B2miningMonoIcon = crear('B2mining', [
    [
      "path",
      {
        "d": "M5 10a7 6 0 0 1 14 0H5Z"
      }
    ],
    [
      "path",
      {
        "d": "M0 0V5H2L3 4V3L2 2.5L3 2V1L2 0ZM0 2.5H2",
        "transform": "translate(8.5 13.5) scale(1)",
        "strokeWidth": "1.5"
      }
    ],
    [
      "path",
      {
        "d": "M0 1L1 0H2L3 1V2L0 5H3",
        "transform": "translate(12.9 13.5) scale(1)",
        "strokeWidth": "1.5"
      }
    ],
    [
      "path",
      {
        "d": "M4 21h16"
      }
    ]
  ]);

export const BajarEstadoMonoIcon = crear('BajarEstado', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4"
      }
    ],
    [
      "path",
      {
        "d": "M12 11v6M9 14.5l3 3 3-3"
      }
    ]
  ]);

export const BancosMonoIcon = crear('Bancos', [
    [
      "rect",
      {
        "x": "3",
        "y": "3",
        "width": "18",
        "height": "17",
        "rx": "2"
      }
    ],
    [
      "circle",
      {
        "cx": "11.5",
        "cy": "11.5",
        "r": "4"
      }
    ],
    [
      "circle",
      {
        "cx": "11.5",
        "cy": "11.5",
        "r": "1"
      }
    ],
    [
      "path",
      {
        "d": "M7 20v2M17 20v2M21 8h1M21 14h1"
      }
    ]
  ]);

export const Books256MonoIcon = crear('Books256', [
    [
      "rect",
      {
        "x": "5",
        "y": "2",
        "width": "15",
        "height": "7",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M9 2v7"
      }
    ],
    [
      "rect",
      {
        "x": "3",
        "y": "9",
        "width": "16",
        "height": "6",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M7 9v6"
      }
    ],
    [
      "rect",
      {
        "x": "5",
        "y": "15",
        "width": "15",
        "height": "7",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M9 15v7"
      }
    ]
  ]);

export const Brcase16MonoIcon = crear('Brcase16', [
    [
      "rect",
      {
        "x": "2",
        "y": "7",
        "width": "20",
        "height": "14",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M8 7V5a2 2 0 0 1 2-2h4a2 2 0 0 1 2 2v2M2 13h20M10 13v2h4v-2"
      }
    ]
  ]);

export const Brcase48MonoIcon = crear('Brcase48', [
    [
      "rect",
      {
        "x": "2",
        "y": "7",
        "width": "20",
        "height": "14",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M8 7V5a2 2 0 0 1 2-2h4a2 2 0 0 1 2 2v2M2 13h20M10 13v2h4v-2"
      }
    ]
  ]);

export const BrochaMonoIcon = crear('Brocha', [
    [
      "path",
      {
        "d": "M5 22h14"
      }
    ],
    [
      "path",
      {
        "d": "M19.27 13.73A2.5 2.5 0 0 0 17.5 13h-11A2.5 2.5 0 0 0 4 15.5V17a1 1 0 0 0 1 1h14a1 1 0 0 0 1-1v-1.5c0-.66-.26-1.3-.73-1.77Z"
      }
    ],
    [
      "path",
      {
        "d": "M14 13V8.5C14 7 15 7 15 5a3 3 0 0 0-3-3c-1.66 0-3 1-3 3s1 2 1 3.5V13"
      }
    ]
  ]);

export const Bundle256MonoIcon = crear('Bundle256', [
    [
      "rect",
      {
        "x": "2",
        "y": "8",
        "width": "18",
        "height": "12",
        "rx": "1.5"
      }
    ],
    [
      "path",
      {
        "d": "M5 5h15a2 2 0 0 1 2 2v9"
      }
    ],
    [
      "rect",
      {
        "x": "8",
        "y": "8",
        "width": "5",
        "height": "12",
        "rx": "0"
      }
    ],
    [
      "circle",
      {
        "cx": "10.5",
        "cy": "14",
        "r": "1"
      }
    ]
  ]);

export const CalendarMonoIcon = crear('Calendar', [
    [
      "rect",
      {
        "x": "3",
        "y": "4",
        "width": "18",
        "height": "18",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M16 2v4M8 2v4M3 10h18"
      }
    ],
    [
      "path",
      {
        "d": "M8 14h.01M12 14h.01M16 14h.01M8 18h.01M12 18h.01"
      }
    ]
  ]);

export const CalendarCopiarMonoIcon = crear('CalendarCopiar', [
    [
      "rect",
      {
        "x": "8",
        "y": "8",
        "width": "14",
        "height": "14",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M4 16a2 2 0 0 1-2-2V4a2 2 0 0 1 2-2h10a2 2 0 0 1 2 2M8 13h14"
      }
    ]
  ]);

export const CalendarEditMonoIcon = crear('CalendarEdit', [
    [
      "rect",
      {
        "x": "3",
        "y": "4",
        "width": "18",
        "height": "18",
        "rx": "2",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M16 2v4M8 2v4M3 10h18",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M8 14h.01M12 14h.01",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "m15.6 20.4 5-5M19 14l2.5 2.5M15.6 20.4l.3-1.9"
      }
    ]
  ]);

export const Cam48MonoIcon = crear('Cam48', [
    [
      "path",
      {
        "d": "M14.5 4h-5L7 7H4a2 2 0 0 0-2 2v9a2 2 0 0 0 2 2h16a2 2 0 0 0 2-2V9a2 2 0 0 0-2-2h-3l-2.5-3z"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "13",
        "r": "3"
      }
    ]
  ]);

export const CameraMonoIcon = crear('Camera', [
    [
      "path",
      {
        "d": "M14.5 4h-5L7 7H4a2 2 0 0 0-2 2v9a2 2 0 0 0 2 2h16a2 2 0 0 0 2-2V9a2 2 0 0 0-2-2h-3l-2.5-3z"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "13",
        "r": "3"
      }
    ]
  ]);

export const Car256MonoIcon = crear('Car256', [
    [
      "path",
      {
        "d": "M19 17h2c.6 0 1-.4 1-1v-3c0-.9-.7-1.7-1.5-1.9C18.7 10.6 16 10 16 10s-1.3-1.4-2.2-2.3c-.5-.4-1.1-.7-1.8-.7H5c-.6 0-1.1.4-1.4.9l-1.4 2.9A3.7 3.7 0 0 0 2 12v4c0 .6.4 1 1 1h2"
      }
    ],
    [
      "circle",
      {
        "cx": "7",
        "cy": "17",
        "r": "2"
      }
    ],
    [
      "path",
      {
        "d": "M9 17h6"
      }
    ],
    [
      "circle",
      {
        "cx": "17",
        "cy": "17",
        "r": "2"
      }
    ]
  ]);

export const Cartera2MonoIcon = crear('Cartera2', [
    [
      "rect",
      {
        "x": "8",
        "y": "2",
        "width": "8",
        "height": "4",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M16 4h2a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2H6a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2h2"
      }
    ]
  ]);

export const CasaAeropuertoMonoIcon = crear('CasaAeropuerto', [
    [
      "path",
      {
        "d": "M17.8 19.2 16 11l3.5-3.5C21 6 21.5 4 21 3c-1-.5-3 0-4.5 1.5L13 8 4.8 6.2c-.5-.1-.9.1-1.1.5l-.3.5c-.2.5-.1 1 .3 1.3L9 12l-2 3H4l-1 1 3 2 2 3 1-1v-3l3-2 3.5 5.3c.3.4.8.5 1.3.3l.5-.2c.4-.3.6-.7.5-1.2z"
      }
    ]
  ]);

export const CerrarmesMonoIcon = crear('Cerrarmes', [
    [
      "path",
      {
        "d": "M14 3h4a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2h-4M3 12h11M10 8l4 4-4 4"
      }
    ]
  ]);

export const ChequeoMonoIcon = crear('Chequeo', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "10"
      }
    ],
    [
      "path",
      {
        "d": "m9 12 2 2 4-4"
      }
    ]
  ]);

export const ClasesMonoIcon = crear('Clases', [
    [
      "path",
      {
        "d": "M10 2v8l3-3 3 3V2"
      }
    ],
    [
      "path",
      {
        "d": "M4 19.5v-15A2.5 2.5 0 0 1 6.5 2H19a1 1 0 0 1 1 1v18a1 1 0 0 1-1 1H6.5a1 1 0 0 1 0-5H20"
      }
    ]
  ]);

export const CleanClienteMonoIcon = crear('CleanCliente', [
    [
      "path",
      {
        "d": "M14 10l6.5-6.5"
      }
    ],
    [
      "path",
      {
        "d": "M10 9l5 5c-1 3-3.5 6-8 7l-4-1c1-3 1-5 3-7 1.5-1.5 3.5-3 4-4z"
      }
    ],
    [
      "path",
      {
        "d": "M7 13l4 4"
      }
    ]
  ]);

export const ClienteMonoIcon = crear('Cliente', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "7",
        "r": "4"
      }
    ],
    [
      "path",
      {
        "d": "M5 21v-2a4 4 0 0 1 4-4h6a4 4 0 0 1 4 4v2M12 15l-1.2 1.8L12 21l1.2-3.2z"
      }
    ]
  ]);

export const ComisionIcoMonoIcon = crear('ComisionIco', [
    [
      "path",
      {
        "d": "M9 3h6l-1.5 3h-3z"
      }
    ],
    [
      "path",
      {
        "d": "M10.5 6C6 8.5 4 12 4 16a5 5 0 0 0 5 5h6a5 5 0 0 0 5-5c0-4-2-7.5-6.5-10"
      }
    ],
    [
      "path",
      {
        "d": "M14 12.5h-2.2a1.5 1.5 0 0 0 0 3h.4a1.5 1.5 0 0 1 0 3H10M12 11v1.5M12 18.5V20"
      }
    ]
  ]);

export const CompraMonoIcon = crear('Compra', [
    [
      "path",
      {
        "d": "M10 6h11M10 12h11M10 18h11M4 5l1-1v5M4 14.5a1.500 1.500 0 1 1 2.500 1L4 18h3"
      }
    ]
  ]);

export const CondensadosMonoIcon = crear('Condensados', [
    [
      "path",
      {
        "d": "M20 20a2 2 0 0 0 2-2V8a2 2 0 0 0-2-2h-7.9a2 2 0 0 1-1.69-.9L9.6 3.9A2 2 0 0 0 7.93 3H4a2 2 0 0 0-2 2v13a2 2 0 0 0 2 2Z"
      }
    ],
    [
      "path",
      {
        "d": "m12 9.5 1.1 2.2 2.4.35-1.75 1.7.4 2.4L12 15l-2.15 1.15.4-2.4-1.75-1.7 2.4-.35z"
      }
    ]
  ]);

export const ConsolidadoMonoIcon = crear('Consolidado', [
    [
      "rect",
      {
        "x": "5",
        "y": "2",
        "width": "16",
        "height": "20",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M2 6h5M2 10h5M2 14h5M2 18h5"
      }
    ]
  ]);

export const ContratoMonoIcon = crear('Contrato', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4"
      }
    ],
    [
      "path",
      {
        "d": "M8 12h4M8 16h2"
      }
    ],
    [
      "path",
      {
        "d": "m14 21 1-3 5-5 2 2-5 5z"
      }
    ]
  ]);

export const CoronaMonoIcon = crear('Corona', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "11",
        "r": "7.5"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "11",
        "r": "4"
      }
    ],
    [
      "path",
      {
        "d": "M12 18.5 8.5 22.5M12 18.5l3.5 4"
      }
    ]
  ]);

export const CostoVentaMonoIcon = crear('CostoVenta', [
    [
      "path",
      {
        "d": "M4 19.5v-15A2.5 2.5 0 0 1 6.5 2H19a1 1 0 0 1 1 1v18a1 1 0 0 1-1 1H6.5a1 1 0 0 1 0-5H20"
      }
    ],
    [
      "path",
      {
        "d": "M9.500 12 13 8.500l3.500 3.500M13 8.500V15"
      }
    ]
  ]);

export const CostosMonoIcon = crear('Costos', [
    [
      "path",
      {
        "d": "M5 6c0 1.1 3.1 2 7 2s7-.9 7-2-3.1-2-7-2-7 .9-7 2z"
      }
    ],
    [
      "path",
      {
        "d": "M5 6v4c0 1.1 3.1 2 7 2s7-.9 7-2V6"
      }
    ],
    [
      "path",
      {
        "d": "M5 10v4c0 1.1 3.1 2 7 2s7-.9 7-2v-4"
      }
    ],
    [
      "path",
      {
        "d": "M5 14v4c0 1.1 3.1 2 7 2s7-.9 7-2v-4"
      }
    ]
  ]);

export const CotIcoMonoIcon = crear('CotIco', [
    [
      "path",
      {
        "d": "M3 7V5a2 2 0 0 1 2-2h2M17 3h2a2 2 0 0 1 2 2v2M21 17v2a2 2 0 0 1-2 2h-2M7 21H5a2 2 0 0 1-2-2v-2"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "3"
      }
    ],
    [
      "path",
      {
        "d": "m16 16-1.9-1.9"
      }
    ]
  ]);

export const CotizacionMonoIcon = crear('Cotizacion', [
    [
      "rect",
      {
        "x": "8",
        "y": "8",
        "width": "14",
        "height": "14",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M4 16c-1.1 0-2-.9-2-2V4c0-1.1.9-2 2-2h10c1.1 0 2 .9 2 2"
      }
    ]
  ]);

export const CotizacionTallerMonoIcon = crear('CotizacionTaller', [
    [
      "path",
      {
        "d": "M10 10V5a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v5"
      }
    ],
    [
      "path",
      {
        "d": "M14 6a6 6 0 0 1 6 6v3"
      }
    ],
    [
      "path",
      {
        "d": "M4 15v-3a6 6 0 0 1 6-6"
      }
    ],
    [
      "rect",
      {
        "x": "2",
        "y": "15",
        "width": "20",
        "height": "4",
        "rx": "1"
      }
    ]
  ]);

export const CreditoMonoIcon = crear('Credito', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4"
      }
    ],
    [
      "path",
      {
        "d": "M3 0H0V5H3",
        "transform": "translate(8.2 11) scale(1.4)",
        "strokeWidth": "1.6"
      }
    ]
  ]);

export const CreditosMonoIcon = crear('Creditos', [
    [
      "path",
      {
        "d": "M19 7V4a1 1 0 0 0-1-1H5a2 2 0 0 0 0 4h15a1 1 0 0 1 1 1v4h-3a2 2 0 0 0 0 4h3a1 1 0 0 0 1-1v-2a1 1 0 0 0-1-1",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M3 5v14a2 2 0 0 0 2 2h15a1 1 0 0 0 1-1v-4",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "4"
      }
    ],
    [
      "path",
      {
        "d": "M18 16.2v3.6"
      }
    ]
  ]);

export const CtaDestinoMonoIcon = crear('CtaDestino', [
    [
      "rect",
      {
        "x": "2",
        "y": "2",
        "width": "20",
        "height": "20",
        "rx": "4"
      }
    ],
    [
      "path",
      {
        "d": "M8 6.5v3M6.5 8h3M14.5 8h3M14.5 14.5l3 3M17.5 14.5l-3 3M6.5 15.5h3M6.5 17.5h3"
      }
    ]
  ]);

export const CtaPngMonoIcon = crear('CtaPng', [
    [
      "rect",
      {
        "x": "4",
        "y": "2",
        "width": "16",
        "height": "20",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M8 6h8M8 10h.01M12 10h.01M16 10h.01M8 14h.01M12 14h.01M16 14h.01M8 18h.01M12 18h.01M16 18h.01"
      }
    ]
  ]);

export const CtasPagarMonoIcon = crear('CtasPagar', [
    [
      "path",
      {
        "d": "M5 7V6a2 2 0 0 1 2-2h13a2 2 0 0 1 2 2v8a2 2 0 0 1-2 2h-1"
      }
    ],
    [
      "rect",
      {
        "x": "2",
        "y": "8",
        "width": "17",
        "height": "12",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M2 12.5h17M5 17h3"
      }
    ]
  ]);

export const CtasCtesMonoIcon = crear('CtasCtes', [
    [
      "path",
      {
        "d": "M5 7V6a2 2 0 0 1 2-2h13a2 2 0 0 1 2 2v8a2 2 0 0 1-2 2h-1"
      }
    ],
    [
      "rect",
      {
        "x": "2",
        "y": "8",
        "width": "17",
        "height": "12",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M2 12.5h17M5 17h3"
      }
    ]
  ]);

export const CtasCtesPendMonoIcon = crear('CtasCtesPend', [
    [
      "rect",
      {
        "x": "2",
        "y": "5",
        "width": "20",
        "height": "14",
        "rx": "2",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M2 10h20",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "17",
        "cy": "18",
        "r": "3.5"
      }
    ],
    [
      "path",
      {
        "d": "M17 16.3v3.4"
      }
    ]
  ]);

export const CuadrarCierreMonoIcon = crear('CuadrarCierre', [
    [
      "rect",
      {
        "x": "3",
        "y": "2",
        "width": "18",
        "height": "20",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M12 2v20M6 6h3v4H6zM15 6h3v4h-3zM6 14h3v4H6zM15 14h3v4h-3z"
      }
    ]
  ]);

export const CuentaMasMonoIcon = crear('CuentaMas', [
    [
      "rect",
      {
        "x": "4",
        "y": "2",
        "width": "16",
        "height": "20",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M8 6h8M8 10h.01M12 10h.01M16 10h.01M8 14h.01M12 14h.01M16 14h.01M8 18h.01M12 18h.01M16 18h.01"
      }
    ]
  ]);

export const CuentasCobrarMonoIcon = crear('CuentasCobrar', [
    [
      "path",
      {
        "d": "M9 3h6l-1.5 3h-3z"
      }
    ],
    [
      "path",
      {
        "d": "M10.5 6C6 8.5 4 12 4 16a5 5 0 0 0 5 5h6a5 5 0 0 0 5-5c0-4-2-7.5-6.5-10"
      }
    ],
    [
      "path",
      {
        "d": "M14 12.5h-2.2a1.5 1.5 0 0 0 0 3h.4a1.5 1.5 0 0 1 0 3H10M12 11v1.5M12 18.5V20"
      }
    ]
  ]);

export const CuentasCorrientesMonoIcon = crear('CuentasCorrientes', [
    [
      "path",
      {
        "d": "M5 7V6a2 2 0 0 1 2-2h13a2 2 0 0 1 2 2v8a2 2 0 0 1-2 2h-1"
      }
    ],
    [
      "rect",
      {
        "x": "2",
        "y": "8",
        "width": "17",
        "height": "12",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M2 12.5h17M5 17h3"
      }
    ]
  ]);

export const DesPerMasMonoIcon = crear('DesPerMas', [
    [
      "path",
      {
        "d": "M19 5 5 19",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "6.5",
        "cy": "6.5",
        "r": "2.5",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "17.5",
        "cy": "17.5",
        "r": "2.5",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M18 15.5v5M15.5 18h5"
      }
    ]
  ]);

export const DespachoMonoIcon = crear('Despacho', [
    [
      "path",
      {
        "d": "M11 12h2a2 2 0 1 0 0-4h-3c-.6 0-1.1.2-1.4.6L3 14"
      }
    ],
    [
      "path",
      {
        "d": "m7 18 1.6-1.4c.3-.4.8-.6 1.4-.6h4c1.1 0 2.1-.4 2.8-1.2l4.6-4.4a2 2 0 0 0-2.75-2.91l-4.2 3.9"
      }
    ],
    [
      "path",
      {
        "d": "m2 13 6 6"
      }
    ]
  ]);

export const DetalleMonoIcon = crear('Detalle', [
    [
      "circle",
      {
        "cx": "11",
        "cy": "11",
        "r": "8"
      }
    ],
    [
      "path",
      {
        "d": "m21 21-4.3-4.3"
      }
    ]
  ]);

export const DiarioAlmacenMonoIcon = crear('DiarioAlmacen', [
    [
      "path",
      {
        "d": "M4 19.5v-15A2.5 2.5 0 0 1 6.5 2H19a1 1 0 0 1 1 1v18a1 1 0 0 1-1 1H6.5a1 1 0 0 1 0-5H20"
      }
    ]
  ]);

export const DiarioPagoMonoIcon = crear('DiarioPago', [
    [
      "rect",
      {
        "x": "3",
        "y": "3",
        "width": "15",
        "height": "19",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M7 3v19"
      }
    ],
    [
      "path",
      {
        "d": "m13 17 8-8 2 2-8 8-3 1z"
      }
    ]
  ]);

export const DocMonoIcon = crear('Doc', [
    [
      "rect",
      {
        "x": "5",
        "y": "2",
        "width": "15",
        "height": "7",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M9 2v7"
      }
    ],
    [
      "rect",
      {
        "x": "3",
        "y": "9",
        "width": "16",
        "height": "6",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M7 9v6"
      }
    ],
    [
      "rect",
      {
        "x": "5",
        "y": "15",
        "width": "15",
        "height": "7",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M9 15v7"
      }
    ]
  ]);

export const DocElecDescargarMonoIcon = crear('DocElecDescargar', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M8 10h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "rect",
      {
        "x": "8",
        "y": "13",
        "width": "8",
        "height": "5",
        "rx": "1",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M12 13v5",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M18 15.5v5M16 18.5l2 2 2-2"
      }
    ]
  ]);

export const DocElecEliminarMonoIcon = crear('DocElecEliminar', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M8 10h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "rect",
      {
        "x": "8",
        "y": "13",
        "width": "8",
        "height": "5",
        "rx": "1",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M12 13v5",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "m16 16 4 4M20 16l-4 4"
      }
    ]
  ]);

export const DocElecGenerarMonoIcon = crear('DocElecGenerar', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M8 10h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "rect",
      {
        "x": "8",
        "y": "13",
        "width": "8",
        "height": "5",
        "rx": "1",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M12 13v5",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "m15.6 18.2 1.7 1.7 3.1-3.5"
      }
    ]
  ]);

export const DocElecLupaMonoIcon = crear('DocElecLupa', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M8 10h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "rect",
      {
        "x": "8",
        "y": "13",
        "width": "8",
        "height": "5",
        "rx": "1",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M12 13v5",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "17.5",
        "cy": "17.5",
        "r": "2"
      }
    ],
    [
      "path",
      {
        "d": "m19 19 1.8 1.8"
      }
    ]
  ]);

export const DocumentosEmitidosMonoIcon = crear('DocumentosEmitidos', [
    [
      "path",
      {
        "d": "m6 14 1.5-2.9A2 2 0 0 1 9.24 10H20a2 2 0 0 1 1.94 2.5l-1.54 6a2 2 0 0 1-1.95 1.5H4a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2h3.9a2 2 0 0 1 1.69.9l.81 1.2a2 2 0 0 0 1.67.9H18a2 2 0 0 1 2 2v2"
      }
    ]
  ]);

export const Editar2MonoIcon = crear('Editar2', [
    [
      "path",
      {
        "d": "M21.17 6.81a1 1 0 0 0-3.99-3.99L3.84 16.17a2 2 0 0 0-.5.83l-1.32 4.35a.5.5 0 0 0 .62.62l4.35-1.32a2 2 0 0 0 .83-.5z"
      }
    ],
    [
      "path",
      {
        "d": "m15 5 4 4"
      }
    ]
  ]);

export const EquipoMarMonoIcon = crear('EquipoMar', [
    [
      "rect",
      {
        "x": "3",
        "y": "2",
        "width": "18",
        "height": "20",
        "rx": "2"
      }
    ],
    [
      "rect",
      {
        "x": "6",
        "y": "5",
        "width": "12",
        "height": "7",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M7 16h.01M10 16h.01M13 16h.01M7 19h.01M10 19h.01M13 19h.01"
      }
    ],
    [
      "rect",
      {
        "x": "16",
        "y": "15",
        "width": "3",
        "height": "5",
        "rx": "1.5"
      }
    ]
  ]);

export const EquipoTelefonicoMonoIcon = crear('EquipoTelefonico', [
    [
      "rect",
      {
        "x": "6",
        "y": "2",
        "width": "12",
        "height": "20",
        "rx": "2.5"
      }
    ],
    [
      "path",
      {
        "d": "M9 7h.01M12 7h.01M15 7h.01M9 11h.01M12 11h.01M15 11h.01M9 15h.01M12 15h.01M15 15h.01"
      }
    ]
  ]);

export const ExcelMonoIcon = crear('Excel', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4"
      }
    ],
    [
      "path",
      {
        "d": "M15 9l-6 9"
      }
    ],
    [
      "circle",
      {
        "cx": "9.5",
        "cy": "10",
        "r": "0.8"
      }
    ],
    [
      "circle",
      {
        "cx": "14.5",
        "cy": "17",
        "r": "0.8"
      }
    ]
  ]);

export const ExcelIcoMonoIcon = crear('ExcelIco', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4"
      }
    ],
    [
      "path",
      {
        "d": "m8.5 11 5 7M13.5 11l-5 7"
      }
    ]
  ]);

export const ExpLabMonoIcon = crear('ExpLab', [
    [
      "circle",
      {
        "cx": "8",
        "cy": "6",
        "r": "3"
      }
    ],
    [
      "path",
      {
        "d": "M2 20v-1.5a4 4 0 0 1 4-4h4"
      }
    ],
    [
      "rect",
      {
        "x": "13",
        "y": "10",
        "width": "9",
        "height": "12",
        "rx": "1.5"
      }
    ],
    [
      "path",
      {
        "d": "M15.5 14h4M15.5 17h4"
      }
    ]
  ]);

export const FactDarbajaMonoIcon = crear('FactDarbaja', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M8 10h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "rect",
      {
        "x": "8",
        "y": "13",
        "width": "8",
        "height": "5",
        "rx": "1",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M12 13v5",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "m16 16 4 4M20 16l-4 4"
      }
    ]
  ]);

export const FactDescargarMonoIcon = crear('FactDescargar', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M8 10h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "rect",
      {
        "x": "8",
        "y": "13",
        "width": "8",
        "height": "5",
        "rx": "1",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M12 13v5",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M18 15.5v5M16 18.5l2 2 2-2"
      }
    ]
  ]);

export const FactGenerarMonoIcon = crear('FactGenerar', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M8 10h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "rect",
      {
        "x": "8",
        "y": "13",
        "width": "8",
        "height": "5",
        "rx": "1",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M12 13v5",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "m15.6 18.2 1.7 1.7 3.1-3.5"
      }
    ]
  ]);

export const FactLupaMonoIcon = crear('FactLupa', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M8 10h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "rect",
      {
        "x": "8",
        "y": "13",
        "width": "8",
        "height": "5",
        "rx": "1",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M12 13v5",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "17.5",
        "cy": "17.5",
        "r": "2"
      }
    ],
    [
      "path",
      {
        "d": "m19 19 1.8 1.8"
      }
    ]
  ]);

export const FalMasivoMonoIcon = crear('FalMasivo', [
    [
      "path",
      {
        "d": "m21.73 18-8-14a2 2 0 0 0-3.48 0l-8 14A2 2 0 0 0 4 21h16a2 2 0 0 0 1.73-3",
        "transform": "translate(-1 5) scale(.72)"
      }
    ],
    [
      "path",
      {
        "d": "M12 9v4M12 17h.01",
        "transform": "translate(-1 5) scale(.72)"
      }
    ],
    [
      "path",
      {
        "d": "m21.73 18-8-14a2 2 0 0 0-3.48 0l-8 14A2 2 0 0 0 4 21h16a2 2 0 0 0 1.73-3",
        "transform": "translate(9 1) scale(.72)"
      }
    ],
    [
      "path",
      {
        "d": "M12 9v4M12 17h.01",
        "transform": "translate(9 1) scale(.72)"
      }
    ]
  ]);

export const FaltasIcoMonoIcon = crear('FaltasIco', [
    [
      "path",
      {
        "d": "m21.73 18-8-14a2 2 0 0 0-3.48 0l-8 14A2 2 0 0 0 4 21h16a2 2 0 0 0 1.73-3"
      }
    ],
    [
      "path",
      {
        "d": "M12 9v4M12 17h.01"
      }
    ]
  ]);

export const FamiliaresMonoIcon = crear('Familiares', [
    [
      "circle",
      {
        "cx": "7",
        "cy": "6",
        "r": "3"
      }
    ],
    [
      "circle",
      {
        "cx": "17",
        "cy": "6",
        "r": "3"
      }
    ],
    [
      "path",
      {
        "d": "M1 19v-1.5A3.5 3.5 0 0 1 4.5 14h2M23 19v-1.5a3.5 3.5 0 0 0-3.5-3.5h-2"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "14",
        "r": "2.2"
      }
    ],
    [
      "path",
      {
        "d": "M8.5 21v-1.5a3.5 3.5 0 0 1 7 0V21"
      }
    ]
  ]);

export const GastoRealRubroMonoIcon = crear('GastoRealRubro', [
    [
      "path",
      {
        "d": "M12 2v20M17 5H9.5a3.5 3.5 0 0 0 0 7h5a3.5 3.5 0 0 1 0 7H6"
      }
    ]
  ]);

export const GastoRealTotalMonoIcon = crear('GastoRealTotal', [
    [
      "path",
      {
        "d": "M12 2v20M17 5H9.5a3.5 3.5 0 0 0 0 7h5a3.5 3.5 0 0 1 0 7H6"
      }
    ]
  ]);

export const GastoViajeMonoIcon = crear('GastoViaje', [
    [
      "rect",
      {
        "x": "3",
        "y": "7",
        "width": "18",
        "height": "14",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M8 7V5a2 2 0 0 1 2-2h4a2 2 0 0 1 2 2v2M8 7v14M16 7v14"
      }
    ],
    [
      "circle",
      {
        "cx": "19",
        "cy": "10",
        "r": "1"
      }
    ]
  ]);

export const GastosMonoIcon = crear('Gastos', [
    [
      "path",
      {
        "d": "M19 7V4a1 1 0 0 0-1-1H5a2 2 0 0 0 0 4h15a1 1 0 0 1 1 1v4h-3a2 2 0 0 0 0 4h3a1 1 0 0 0 1-1v-2a1 1 0 0 0-1-1"
      }
    ],
    [
      "path",
      {
        "d": "M3 5v14a2 2 0 0 0 2 2h15a1 1 0 0 0 1-1v-4"
      }
    ]
  ]);

export const GenerarMasMonoIcon = crear('GenerarMas', [
    [
      "rect",
      {
        "x": "3",
        "y": "12",
        "width": "10",
        "height": "9",
        "rx": "1.5",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M6 16h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M20 4 13 11M20 4v5M20 4h-5",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M18 15.5v5M15.5 18h5"
      }
    ]
  ]);

export const GenerarPeriodoMonoIcon = crear('GenerarPeriodo', [
    [
      "rect",
      {
        "x": "2",
        "y": "6",
        "width": "20",
        "height": "12",
        "rx": "3"
      }
    ],
    [
      "path",
      {
        "d": "M0 5V0L3 5V0",
        "transform": "translate(5.9 9.5) scale(1)",
        "strokeWidth": "1.5"
      }
    ],
    [
      "path",
      {
        "d": "M3 0H0V5H3M0 2.5H2",
        "transform": "translate(10.3 9.5) scale(1)",
        "strokeWidth": "1.5"
      }
    ],
    [
      "path",
      {
        "d": "M0 0L.75 5L1.5 1.8L2.25 5L3 0",
        "transform": "translate(14.700000000000001 9.5) scale(1)",
        "strokeWidth": "1.5"
      }
    ]
  ]);

export const GerenteMonoIcon = crear('Gerente', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "7",
        "r": "4"
      }
    ],
    [
      "path",
      {
        "d": "M5 21v-2a4 4 0 0 1 4-4h6a4 4 0 0 1 4 4v2M12 15l-1.2 1.8L12 21l1.2-3.2z"
      }
    ]
  ]);

export const GraficaMonoIcon = crear('Grafica', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "10"
      }
    ],
    [
      "path",
      {
        "d": "m10 8 6 4-6 4z"
      }
    ]
  ]);

export const HePlanillasMonoIcon = crear('HePlanillas', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "10"
      }
    ],
    [
      "path",
      {
        "d": "M12 6v6l4 2"
      }
    ]
  ]);

export const HelpMonoIcon = crear('Help', [
    [
      "rect",
      {
        "x": "3",
        "y": "3",
        "width": "18",
        "height": "18",
        "rx": "4"
      }
    ],
    [
      "path",
      {
        "d": "M9.1 9a3 3 0 0 1 5.82 1c0 2-3 3-3 3M12 17h.01"
      }
    ]
  ]);

export const HrsEquipoMonoIcon = crear('HrsEquipo', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "10",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M12 6v6l4 2",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "1.8"
      }
    ],
    [
      "path",
      {
        "d": "M18 14.5v1.2M18 20.3v1.2M14.5 18h1.2M20.3 18h1.2"
      }
    ]
  ]);

export const IcoRelojMonoIcon = crear('IcoReloj', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "10"
      }
    ],
    [
      "path",
      {
        "d": "M12 2v1.5M12 20.5V22M2 12h1.5M20.5 12H22M12 7v5l3 2"
      }
    ]
  ]);

export const IcoReloj3MonoIcon = crear('IcoReloj3', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "10"
      }
    ],
    [
      "path",
      {
        "d": "M12 6v6l4 2"
      }
    ]
  ]);

export const IcoReloj4MonoIcon = crear('IcoReloj4', [
    [
      "path",
      {
        "d": "M10 2h4M12 14l3-3"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "14",
        "r": "8"
      }
    ]
  ]);

export const IdiomaMonoIcon = crear('Idioma', [
    [
      "path",
      {
        "d": "M4 15s1-1 4-1 5 2 8 2 4-1 4-1V3s-1 1-4 1-5-2-8-2-4 1-4 1z"
      }
    ],
    [
      "path",
      {
        "d": "M4 22v-7"
      }
    ]
  ]);

export const ImagenFondoMonoIcon = crear('ImagenFondo', [
    [
      "path",
      {
        "d": "M14.5 4h-5L7 7H4a2 2 0 0 0-2 2v9a2 2 0 0 0 2 2h16a2 2 0 0 0 2-2V9a2 2 0 0 0-2-2h-3l-2.5-3z",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "13",
        "r": "3",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M18 15.5v5M15.5 18h5"
      }
    ]
  ]);

export const Img48MonoIcon = crear('Img48', [
    [
      "rect",
      {
        "x": "3",
        "y": "3",
        "width": "18",
        "height": "18",
        "rx": "2"
      }
    ],
    [
      "circle",
      {
        "cx": "9",
        "cy": "9",
        "r": "1.5"
      }
    ],
    [
      "path",
      {
        "d": "m21 15-3.086-3.086a2 2 0 0 0-2.828 0L6 21"
      }
    ]
  ]);

export const ImportacionMonoIcon = crear('Importacion', [
    [
      "path",
      {
        "d": "M17.8 19.2 16 11l3.5-3.5C21 6 21.5 4 21 3c-1-.5-3 0-4.5 1.5L13 8 4.8 6.2c-.5-.1-.9.1-1.1.5l-.3.5c-.2.5-.1 1 .3 1.3L9 12l-2 3H4l-1 1 3 2 2 3 1-1v-3l3-2 3.5 5.3c.3.4.8.5 1.3.3l.5-.2c.4-.3.6-.7.5-1.2z"
      }
    ]
  ]);

export const Indicadores1MonoIcon = crear('Indicadores1', [
    [
      "path",
      {
        "d": "M21 12c.55 0 1-.45.95-1a10 10 0 0 0-8.95-8.95c-.55-.05-1 .4-1 .95v8a1 1 0 0 0 1 1z"
      }
    ],
    [
      "path",
      {
        "d": "M21.21 15.89A10 10 0 1 1 8 2.83"
      }
    ]
  ]);

export const Indicadores2MonoIcon = crear('Indicadores2', [
    [
      "path",
      {
        "d": "M3 3v16a2 2 0 0 0 2 2h16"
      }
    ],
    [
      "path",
      {
        "d": "M7 17v-3M11 17v-6M15 17V8M19 17V5"
      }
    ]
  ]);

export const Indicadores3MonoIcon = crear('Indicadores3', [
    [
      "path",
      {
        "d": "M3 3v18h18"
      }
    ],
    [
      "path",
      {
        "d": "M11 17v-4M15.500 17v-7M20 17V8"
      }
    ],
    [
      "circle",
      {
        "cx": "8",
        "cy": "8",
        "r": "3.5"
      }
    ],
    [
      "path",
      {
        "d": "M8 4.500V8h3.500"
      }
    ]
  ]);

export const Indicadorico2MonoIcon = crear('Indicadorico2', [
    [
      "path",
      {
        "d": "M3 3v16a2 2 0 0 0 2 2h16"
      }
    ],
    [
      "path",
      {
        "d": "M7 17v-3M11 17v-6M15 17V8M19 17V5"
      }
    ]
  ]);

export const Indicadorico3MonoIcon = crear('Indicadorico3', [
    [
      "path",
      {
        "d": "M3 3v18h18"
      }
    ],
    [
      "path",
      {
        "d": "M11 17v-4M15.500 17v-7M20 17V8"
      }
    ],
    [
      "circle",
      {
        "cx": "8",
        "cy": "8",
        "r": "3.5"
      }
    ],
    [
      "path",
      {
        "d": "M8 4.500V8h3.500"
      }
    ]
  ]);

export const InformaticaMonoIcon = crear('Informatica', [
    [
      "rect",
      {
        "x": "2",
        "y": "3",
        "width": "20",
        "height": "14",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M8 21h8M12 17v4"
      }
    ]
  ]);

export const IngCtasMonoIcon = crear('IngCtas', [
    [
      "path",
      {
        "d": "M9 3h6l-1.5 3h-3z"
      }
    ],
    [
      "path",
      {
        "d": "M10.5 6C6 8.5 4 12 4 16a5 5 0 0 0 5 5h6a5 5 0 0 0 5-5c0-4-2-7.5-6.5-10"
      }
    ],
    [
      "path",
      {
        "d": "M14 12.5h-2.2a1.5 1.5 0 0 0 0 3h.4a1.5 1.5 0 0 1 0 3H10M12 11v1.5M12 18.5V20"
      }
    ]
  ]);

export const IngPerMasMonoIcon = crear('IngPerMas', [
    [
      "path",
      {
        "d": "M5 6c0 1.1 3.1 2 7 2s7-.9 7-2-3.1-2-7-2-7 .9-7 2z",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M5 6v4c0 1.1 3.1 2 7 2s7-.9 7-2V6",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M5 10v4c0 1.1 3.1 2 7 2s7-.9 7-2v-4",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M5 14v4c0 1.1 3.1 2 7 2s7-.9 7-2v-4",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M18 15.5v5M15.5 18h5"
      }
    ]
  ]);

export const IngPlanillasMonoIcon = crear('IngPlanillas', [
    [
      "path",
      {
        "d": "M9 3h6l-1.5 3h-3z"
      }
    ],
    [
      "path",
      {
        "d": "M10.5 6C6 8.5 4 12 4 16a5 5 0 0 0 5 5h6a5 5 0 0 0 5-5c0-4-2-7.5-6.5-10"
      }
    ],
    [
      "path",
      {
        "d": "M14 12.5h-2.2a1.5 1.5 0 0 0 0 3h.4a1.5 1.5 0 0 1 0 3H10M12 11v1.5M12 18.5V20"
      }
    ]
  ]);

export const InternoMonoIcon = crear('Interno', [
    [
      "path",
      {
        "d": "M14 18V6a2 2 0 0 0-2-2H4a2 2 0 0 0-2 2v11a1 1 0 0 0 1 1h2M15 18H9M19 18h2a1 1 0 0 0 1-1v-3.65a1 1 0 0 0-.22-.62l-3.48-4.35A1 1 0 0 0 17.52 8H14"
      }
    ],
    [
      "circle",
      {
        "cx": "17",
        "cy": "18",
        "r": "2"
      }
    ],
    [
      "circle",
      {
        "cx": "7",
        "cy": "18",
        "r": "2"
      }
    ]
  ]);

export const InventarioMonoIcon = crear('Inventario', [
    [
      "path",
      {
        "d": "M.4 1.2L1.6 0V5",
        "transform": "translate(3.2 8) scale(1.6)",
        "strokeWidth": "1.3"
      }
    ],
    [
      "path",
      {
        "d": "M0 1L1 0H2L3 1V2L0 5H3",
        "transform": "translate(10.240000000000002 8) scale(1.6)",
        "strokeWidth": "1.3"
      }
    ],
    [
      "path",
      {
        "d": "M0 0H3L1.5 2.2L3 3.2V4L2 5H0",
        "transform": "translate(17.28 8) scale(1.6)",
        "strokeWidth": "1.3"
      }
    ]
  ]);

export const Laptop16MonoIcon = crear('Laptop16', [
    [
      "path",
      {
        "d": "M20 16V7a2 2 0 0 0-2-2H6a2 2 0 0 0-2 2v9m16 0H4m16 0 1.28 2.55a1 1 0 0 1-.9 1.45H3.62a1 1 0 0 1-.9-1.45L4 16"
      }
    ]
  ]);

export const Laptop48MonoIcon = crear('Laptop48', [
    [
      "path",
      {
        "d": "M20 16V7a2 2 0 0 0-2-2H6a2 2 0 0 0-2 2v9m16 0H4m16 0 1.28 2.55a1 1 0 0 1-.9 1.45H3.62a1 1 0 0 1-.9-1.45L4 16"
      }
    ]
  ]);

export const LetrasAceptadasMonoIcon = crear('LetrasAceptadas', [
    [
      "path",
      {
        "d": "M7 10v12"
      }
    ],
    [
      "path",
      {
        "d": "M15 5.88 14 10h5.83a2 2 0 0 1 1.92 2.56l-2.33 8A2 2 0 0 1 17.5 22H4a2 2 0 0 1-2-2v-8a2 2 0 0 1 2-2h2.76a2 2 0 0 0 1.79-1.11L12 2a3.13 3.13 0 0 1 3 3.88Z"
      }
    ]
  ]);

export const LibrosContMonoIcon = crear('LibrosCont', [
    [
      "rect",
      {
        "x": "5",
        "y": "2",
        "width": "15",
        "height": "7",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M9 2v7"
      }
    ],
    [
      "rect",
      {
        "x": "3",
        "y": "9",
        "width": "16",
        "height": "6",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M7 9v6"
      }
    ],
    [
      "rect",
      {
        "x": "5",
        "y": "15",
        "width": "15",
        "height": "7",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M9 15v7"
      }
    ]
  ]);

export const LineaTelefonicaMonoIcon = crear('LineaTelefonica', [
    [
      "path",
      {
        "d": "M22 16.92v3a2 2 0 0 1-2.18 2 19.79 19.79 0 0 1-8.63-3.07 19.5 19.5 0 0 1-6-6 19.79 19.79 0 0 1-3.07-8.67A2 2 0 0 1 4.11 2h3a2 2 0 0 1 2 1.72 12.84 12.84 0 0 0 .7 2.81 2 2 0 0 1-.45 2.11L8.09 9.91a16 16 0 0 0 6 6l1.27-1.27a2 2 0 0 1 2.11-.45 12.84 12.84 0 0 0 2.81.7A2 2 0 0 1 22 16.92z"
      }
    ]
  ]);

export const LinkicoMonoIcon = crear('Linkico', [
    [
      "path",
      {
        "d": "M10 13a5 5 0 0 0 7.54.54l3-3a5 5 0 0 0-7.07-7.07l-1.72 1.71"
      }
    ],
    [
      "path",
      {
        "d": "M14 11a5 5 0 0 0-7.54-.54l-3 3a5 5 0 0 0 7.07 7.07l1.71-1.71"
      }
    ]
  ]);

export const LiquidacionMonoIcon = crear('Liquidacion', [
    [
      "path",
      {
        "d": "M12 2v20M17 5H9.5a3.5 3.5 0 0 0 0 7h5a3.5 3.5 0 0 1 0 7H6"
      }
    ]
  ]);

export const LoginMonoIcon = crear('Login', [
    [
      "rect",
      {
        "x": "2",
        "y": "10",
        "width": "15",
        "height": "12",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M5.5 10V7a4 4 0 0 1 8 0v3"
      }
    ],
    [
      "circle",
      {
        "cx": "19",
        "cy": "15",
        "r": "2.5"
      }
    ],
    [
      "path",
      {
        "d": "M19 17.5V22M19 20h2"
      }
    ]
  ]);

export const MantenimientoMonoIcon = crear('Mantenimiento', [
    [
      "rect",
      {
        "x": "3",
        "y": "2",
        "width": "9",
        "height": "20",
        "rx": "1.5"
      }
    ],
    [
      "circle",
      {
        "cx": "7.5",
        "cy": "17",
        "r": "1"
      }
    ],
    [
      "path",
      {
        "d": "M6 6h3"
      }
    ],
    [
      "path",
      {
        "d": "M14.7 6.3a1 1 0 0 0 0 1.4l1.6 1.6a1 1 0 0 0 1.4 0l3.77-3.77a6 6 0 0 1-7.94 7.94l-6.91 6.91a2.12 2.12 0 0 1-3-3l6.91-6.91a6 6 0 0 1 7.94-7.94l-3.76 3.76z",
        "transform": "translate(11 7) scale(.55)"
      }
    ]
  ]);

export const MarcaMonoIcon = crear('Marca', [
    [
      "path",
      {
        "d": "M4 16v-2.38C4 11.5 2.97 10.5 3 8c.03-2.72 1.49-6 4.5-6C9.37 2 10 3.8 10 5.5c0 3.11-2 5.66-2 8.68V16a2 2 0 1 1-4 0Z"
      }
    ],
    [
      "path",
      {
        "d": "M20 20v-2.38c0-2.12 1.03-3.12 1-5.62-.03-2.72-1.49-6-4.5-6C14.63 6 14 7.8 14 9.5c0 3.11 2 5.66 2 8.68V20a2 2 0 1 0 4 0Z"
      }
    ],
    [
      "path",
      {
        "d": "M16 17h4M4 13h4"
      }
    ]
  ]);

export const MayorAuxMonoIcon = crear('MayorAux', [
    [
      "path",
      {
        "d": "M4 19.5v-15A2.5 2.5 0 0 1 6.5 2H19a1 1 0 0 1 1 1v18a1 1 0 0 1-1 1H6.5a1 1 0 0 1 0-5H20"
      }
    ]
  ]);

export const MercaderiaMonoIcon = crear('Mercaderia', [
    [
      "circle",
      {
        "cx": "8",
        "cy": "21",
        "r": "1"
      }
    ],
    [
      "circle",
      {
        "cx": "19",
        "cy": "21",
        "r": "1"
      }
    ],
    [
      "path",
      {
        "d": "M2.05 2.05h2l2.66 12.42a2 2 0 0 0 2 1.58h9.78a2 2 0 0 0 1.95-1.57l1.65-7.43H5.12"
      }
    ],
    [
      "path",
      {
        "d": "M9 9.500 12.500 6l3.500 3.500M10 9v3h5V9"
      }
    ]
  ]);

export const MesaControlMonoIcon = crear('MesaControl', [
    [
      "rect",
      {
        "x": "3",
        "y": "3",
        "width": "18",
        "height": "18",
        "rx": "3"
      }
    ],
    [
      "path",
      {
        "d": "m9 12 2 2 4-4"
      }
    ]
  ]);

export const ModeloTelefonoMonoIcon = crear('ModeloTelefono', [
    [
      "rect",
      {
        "x": "5",
        "y": "2",
        "width": "14",
        "height": "20",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M12 18h.01"
      }
    ]
  ]);

export const MotoresMonoIcon = crear('Motores', [
    [
      "rect",
      {
        "x": "6",
        "y": "8",
        "width": "12",
        "height": "9",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M9 8V5h6v3"
      }
    ],
    [
      "path",
      {
        "d": "M3 11v4"
      }
    ],
    [
      "path",
      {
        "d": "M3 13h3"
      }
    ],
    [
      "path",
      {
        "d": "M18 11h2v4h-2"
      }
    ],
    [
      "path",
      {
        "d": "M9 17v3"
      }
    ],
    [
      "path",
      {
        "d": "M15 17v3"
      }
    ]
  ]);

export const MovimientoMonoIcon = crear('Movimiento', [
    [
      "path",
      {
        "d": "M21 12a9 9 0 1 1-9-9c2.52 0 4.93 1 6.74 2.74L21 8M21 3v5h-5"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "1.5"
      }
    ]
  ]);

export const MpIconMonoIcon = crear('MpIcon', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "13",
        "r": "8"
      }
    ],
    [
      "path",
      {
        "d": "M12 9v4l2 2"
      }
    ],
    [
      "path",
      {
        "d": "M5 3 2 6"
      }
    ],
    [
      "path",
      {
        "d": "m22 6-3-3"
      }
    ],
    [
      "path",
      {
        "d": "M6.38 18.7 4 21"
      }
    ],
    [
      "path",
      {
        "d": "M17.64 18.67 20 21"
      }
    ]
  ]);

export const ObservacionMonoIcon = crear('Observacion', [
    [
      "path",
      {
        "d": "M12 20h9"
      }
    ],
    [
      "path",
      {
        "d": "M16.376 3.622a1 1 0 0 1 3.002 3.002L7.368 18.635a2 2 0 0 1-.855.506l-2.872.838a.5.5 0 0 1-.62-.62l.838-2.872a2 2 0 0 1 .506-.854z"
      }
    ]
  ]);

export const OrdenesCompraMonoIcon = crear('OrdenesCompra', [
    [
      "path",
      {
        "d": "M4 22h16a2 2 0 0 0 2-2V4a2 2 0 0 0-2-2H8a2 2 0 0 0-2 2v16a2 2 0 0 1-2 2Zm0 0a2 2 0 0 1-2-2v-9c0-1.1.9-2 2-2h2"
      }
    ],
    [
      "path",
      {
        "d": "M18 14h-8"
      }
    ],
    [
      "path",
      {
        "d": "M15 18h-5"
      }
    ],
    [
      "path",
      {
        "d": "M10 6h8v4h-8V6Z"
      }
    ]
  ]);

export const PartidasMonoIcon = crear('Partidas', [
    [
      "path",
      {
        "d": "M4 19.5v-15A2.5 2.5 0 0 1 6.5 2H19a1 1 0 0 1 1 1v18a1 1 0 0 1-1 1H6.5a1 1 0 0 1 0-5H20"
      }
    ],
    [
      "path",
      {
        "d": "M12 7h.01"
      }
    ],
    [
      "path",
      {
        "d": "M12 10v5"
      }
    ]
  ]);

export const PrecioCoreMonoIcon = crear('PrecioCore', [
    [
      "rect",
      {
        "x": "2",
        "y": "6",
        "width": "20",
        "height": "12",
        "rx": "2"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "2"
      }
    ],
    [
      "path",
      {
        "d": "M6 12h.01"
      }
    ],
    [
      "path",
      {
        "d": "M18 12h.01"
      }
    ],
    [
      "path",
      {
        "d": "M5 3.5h14"
      }
    ]
  ]);

export const PendienteFacturacionMonoIcon = crear('PendienteFacturacion', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7Z"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4"
      }
    ],
    [
      "path",
      {
        "d": "M10 9H8"
      }
    ],
    [
      "circle",
      {
        "cx": "9",
        "cy": "16",
        "r": "4"
      }
    ],
    [
      "path",
      {
        "d": "M9 14.5v3"
      }
    ]
  ]);

export const ReclamoGarantiaMonoIcon = crear('ReclamoGarantia', [
    [
      "path",
      {
        "d": "M8 15.5 5 22l3.6-1.4L10.8 22l1.2-6.5Z",
        "stroke": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M16 15.5 19 22l-3.6-1.4L13.2 22 12 15.5Z",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "10",
        "r": "8",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "10",
        "r": "5",
        "stroke": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M10.6 8.4 12.4 7v6",
        "stroke": "currentColor"
      }
    ]
  ]);

export const ValeRequisicionMonoIcon = crear('ValeRequisicion', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7Z"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4"
      }
    ],
    [
      "path",
      {
        "d": "M10 9H8"
      }
    ],
    [
      "path",
      {
        "d": "M16 13H8"
      }
    ],
    [
      "path",
      {
        "d": "M16 17H8"
      }
    ]
  ]);

export const RegistroAuxiliarMonoIcon = crear('RegistroAuxiliar', [
    [
      "rect",
      {
        "x": "3",
        "y": "3",
        "width": "18",
        "height": "18",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M3 12h18"
      }
    ],
    [
      "path",
      {
        "d": "M10 7.5h4"
      }
    ],
    [
      "path",
      {
        "d": "M10 16.5h4"
      }
    ]
  ]);

export const SepararPuzzleMonoIcon = crear('SepararPuzzle', [
    [
      "path",
      {
        "d": "M16 3h5v5"
      }
    ],
    [
      "path",
      {
        "d": "M8 3H3v5"
      }
    ],
    [
      "path",
      {
        "d": "M12 22v-8.3a4 4 0 0 0-1.172-2.872L3 3"
      }
    ],
    [
      "path",
      {
        "d": "m15 9 6-6"
      }
    ]
  ]);

export const RegistroResumenMonoIcon = crear('RegistroResumen', [
    [
      "path",
      {
        "d": "M20 20a2 2 0 0 0 2-2V8a2 2 0 0 0-2-2h-7.9a2 2 0 0 1-1.69-.9L9.6 3.9A2 2 0 0 0 7.93 3H4a2 2 0 0 0-2 2v13a2 2 0 0 0 2 2Z"
      }
    ],
    [
      "path",
      {
        "d": "M8 13h8"
      }
    ],
    [
      "path",
      {
        "d": "M8 16.5h5"
      }
    ]
  ]);

export const RegistroMonoIcon = crear('Registro', [
    [
      "rect",
      {
        "x": "2",
        "y": "3",
        "width": "20",
        "height": "5",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M4 8v11a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8"
      }
    ],
    [
      "path",
      {
        "d": "M10 12h4"
      }
    ]
  ]);

export const TicketMonoIcon = crear('Ticket', [
    [
      "path",
      {
        "d": "M6 18H4a2 2 0 0 1-2-2v-5a2 2 0 0 1 2-2h16a2 2 0 0 1 2 2v5a2 2 0 0 1-2 2h-2"
      }
    ],
    [
      "path",
      {
        "d": "M6 9V3a1 1 0 0 1 1-1h10a1 1 0 0 1 1 1v6"
      }
    ],
    [
      "rect",
      {
        "x": "6",
        "y": "14",
        "width": "12",
        "height": "8",
        "rx": "1"
      }
    ]
  ]);

export const TarifasMonoIcon = crear('Tarifas', [
    [
      "path",
      {
        "d": "M9 3h6l-1.5 3h-3Z"
      }
    ],
    [
      "path",
      {
        "d": "M8 21c-3 0-4-2-4-4 0-3 3-6 5.5-8.5h5C17 11 20 14 20 17c0 2-1 4-4 4Z"
      }
    ],
    [
      "path",
      {
        "d": "M12 11.5v8.5"
      }
    ],
    [
      "path",
      {
        "d": "M14.5 13h-3a1.5 1.5 0 0 0 0 3h1a1.5 1.5 0 0 1 0 3h-3"
      }
    ]
  ]);

export const TabMonoIcon = crear('Tab', [
    [
      "path",
      {
        "d": "m16 3 4 4-4 4"
      }
    ],
    [
      "path",
      {
        "d": "M20 7H4"
      }
    ],
    [
      "path",
      {
        "d": "m8 21-4-4 4-4"
      }
    ],
    [
      "path",
      {
        "d": "M4 17h16"
      }
    ]
  ]);

export const SugerirMonoIcon = crear('Sugerir', [
    [
      "path",
      {
        "d": "M3.85 8.62a4 4 0 0 1 4.78-4.77 4 4 0 0 1 6.74 0 4 4 0 0 1 4.78 4.78 4 4 0 0 1 0 6.74 4 4 0 0 1-4.77 4.78 4 4 0 0 1-6.75 0 4 4 0 0 1-4.78-4.77 4 4 0 0 1 0-6.76Z"
      }
    ],
    [
      "path",
      {
        "d": "m15 9-6 6"
      }
    ],
    [
      "path",
      {
        "d": "M9 9h.01"
      }
    ],
    [
      "path",
      {
        "d": "M15 15h.01"
      }
    ]
  ]);

export const VehiculoIcoMonoIcon = crear('VehiculoIco', [
    [
      "path",
      {
        "d": "M14 18V6a2 2 0 0 0-2-2H4a2 2 0 0 0-2 2v11a1 1 0 0 0 1 1h2"
      }
    ],
    [
      "path",
      {
        "d": "M15 18H9"
      }
    ],
    [
      "path",
      {
        "d": "M22 18v-5l-3-4h-5"
      }
    ],
    [
      "circle",
      {
        "cx": "17",
        "cy": "18",
        "r": "2"
      }
    ],
    [
      "circle",
      {
        "cx": "7",
        "cy": "18",
        "r": "2"
      }
    ],
    [
      "path",
      {
        "d": "M6 8h4"
      }
    ]
  ]);

export const TomaInventarioMonoIcon = crear('TomaInventario', [
    [
      "path",
      {
        "d": "m16 6 4 14"
      }
    ],
    [
      "path",
      {
        "d": "M12 6v14"
      }
    ],
    [
      "path",
      {
        "d": "M8 8v12"
      }
    ],
    [
      "path",
      {
        "d": "M4 4v16"
      }
    ]
  ]);

export const VencimientoAcumuladaMonoIcon = crear('VencimientoAcumulada', [
    [
      "circle",
      {
        "cx": "10",
        "cy": "14",
        "r": "8"
      }
    ],
    [
      "path",
      {
        "d": "M13.5 17.5s-1.2-2-3.5-2-3.5 2-3.5 2"
      }
    ],
    [
      "path",
      {
        "d": "M7 12h.01"
      }
    ],
    [
      "path",
      {
        "d": "M13 12h.01"
      }
    ],
    [
      "path",
      {
        "d": "M19 2v6"
      }
    ],
    [
      "path",
      {
        "d": "M16 5h6"
      }
    ]
  ]);

export const VencimientoDetalleMonoIcon = crear('VencimientoDetalle', [
    [
      "circle",
      {
        "cx": "10",
        "cy": "14",
        "r": "8"
      }
    ],
    [
      "path",
      {
        "d": "M13.5 17.5s-1.2-2-3.5-2-3.5 2-3.5 2"
      }
    ],
    [
      "path",
      {
        "d": "M7 12h.01"
      }
    ],
    [
      "path",
      {
        "d": "M13 12h.01"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "6",
        "r": "3"
      }
    ],
    [
      "path",
      {
        "d": "m20.1 8.1 2.4 2.4"
      }
    ]
  ]);

export const UploadMonoIcon = crear('Upload', [
    [
      "rect",
      {
        "x": "3",
        "y": "3",
        "width": "18",
        "height": "18",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M3 8h18"
      }
    ],
    [
      "path",
      {
        "d": "M12 19v-7"
      }
    ],
    [
      "path",
      {
        "d": "m9 15 3-3 3 3"
      }
    ]
  ]);

export const VencimientosMonoIcon = crear('Vencimientos', [
    [
      "path",
      {
        "d": "m6 14 1.5-2.9A2 2 0 0 1 9.24 10H20a2 2 0 0 1 1.94 2.5l-1.54 6a2 2 0 0 1-1.95 1.5H4a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2h3.9a2 2 0 0 1 1.69.9l.81 1.2a2 2 0 0 0 1.67.9H18a2 2 0 0 1 2 2v2"
      }
    ]
  ]);

export const VendedorMonoIcon = crear('Vendedor', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "7",
        "r": "4"
      }
    ],
    [
      "path",
      {
        "d": "M5 21v-2a5 5 0 0 1 5-5h4a5 5 0 0 1 5 5v2"
      }
    ],
    [
      "path",
      {
        "d": "m12 14-1.5 2 1.5 3 1.5-3z"
      }
    ]
  ]);

export const StockValorizadoMonoIcon = crear('StockValorizado', [
    [
      "path",
      {
        "d": "M4 19.5v-15A2.5 2.5 0 0 1 6.5 2H19a1 1 0 0 1 1 1v18a1 1 0 0 1-1 1H6.5a1 1 0 0 1 0-5H20"
      }
    ],
    [
      "path",
      {
        "d": "M9 7h6"
      }
    ],
    [
      "path",
      {
        "d": "M9 11h4"
      }
    ]
  ]);

export const ToolsMonoIcon = crear('Tools', [
    [
      "path",
      {
        "d": "M14.7 6.3a1 1 0 0 0 0 1.4l1.6 1.6a1 1 0 0 0 1.4 0l3.77-3.77a6 6 0 0 1-7.94 7.94l-6.91 6.91a2.12 2.12 0 0 1-3-3l6.91-6.91a6 6 0 0 1 7.94-7.94l-3.76 3.76z"
      }
    ],
    [
      "path",
      {
        "d": "m3 3 6 6"
      }
    ]
  ]);

export const TransferenciasMonoIcon = crear('Transferencias', [
    [
      "path",
      {
        "d": "M5 12h14"
      }
    ],
    [
      "path",
      {
        "d": "m12 5 7 7-7 7"
      }
    ]
  ]);

export const RepPersonalMonoIcon = crear('RepPersonal', [
    [
      "path",
      {
        "d": "M11.5 15H7a4 4 0 0 0-4 4v2"
      }
    ],
    [
      "path",
      {
        "d": "M21.378 16.626a1 1 0 0 0-3.004-3.004l-4.01 4.012a2 2 0 0 0-.506.854l-.837 2.87a.5.5 0 0 0 .62.62l2.87-.837a2 2 0 0 0 .854-.506z"
      }
    ],
    [
      "circle",
      {
        "cx": "10",
        "cy": "7",
        "r": "4"
      }
    ]
  ]);

export const RepReembolsoMonoIcon = crear('RepReembolso', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "10"
      }
    ],
    [
      "path",
      {
        "d": "M16 8h-6a2 2 0 1 0 0 4h4a2 2 0 1 1 0 4H8"
      }
    ],
    [
      "path",
      {
        "d": "M12 18V6"
      }
    ]
  ]);

export const RepRegComprasMonoIcon = crear('RepRegCompras', [
    [
      "path",
      {
        "d": "m15 11-1 9"
      }
    ],
    [
      "path",
      {
        "d": "m19 11-4-7"
      }
    ],
    [
      "path",
      {
        "d": "M2 11h20"
      }
    ],
    [
      "path",
      {
        "d": "m3.5 11 1.6 7.4a2 2 0 0 0 2 1.6h9.8a2 2 0 0 0 2-1.6l1.7-7.4"
      }
    ],
    [
      "path",
      {
        "d": "M4.5 15.5h15"
      }
    ],
    [
      "path",
      {
        "d": "m5 11 4-7"
      }
    ],
    [
      "path",
      {
        "d": "m9 11 1 9"
      }
    ],
    [
      "path",
      {
        "d": "M9 2h6"
      }
    ]
  ]);

export const RepTardanzasMonoIcon = crear('RepTardanzas', [
    [
      "path",
      {
        "d": "m21.73 18-8-14a2 2 0 0 0-3.48 0l-8 14A2 2 0 0 0 4 21h16a2 2 0 0 0 1.73-3"
      }
    ],
    [
      "path",
      {
        "d": "M12 9v4"
      }
    ],
    [
      "path",
      {
        "d": "M12 17h.01"
      }
    ]
  ]);

export const ReportMonoIcon = crear('Report', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7Z"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4"
      }
    ],
    [
      "path",
      {
        "d": "M10 9H8"
      }
    ],
    [
      "path",
      {
        "d": "M16 13H8"
      }
    ],
    [
      "path",
      {
        "d": "M16 17H8"
      }
    ]
  ]);

export const ResumenGeneralMonoIcon = crear('ResumenGeneral', [
    [
      "rect",
      {
        "x": "8",
        "y": "2",
        "width": "8",
        "height": "4",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M16 4h2a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2H6a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2h2"
      }
    ],
    [
      "path",
      {
        "d": "M12 11h4"
      }
    ],
    [
      "path",
      {
        "d": "M12 16h4"
      }
    ],
    [
      "path",
      {
        "d": "M8 11h.01"
      }
    ],
    [
      "path",
      {
        "d": "M8 16h.01"
      }
    ]
  ]);

export const ScdrespsMonoIcon = crear('Scdresps', [
    [
      "path",
      {
        "d": "M8 2v4"
      }
    ],
    [
      "path",
      {
        "d": "M16 2v4"
      }
    ],
    [
      "rect",
      {
        "x": "3",
        "y": "4",
        "width": "18",
        "height": "18",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M3 10h18"
      }
    ],
    [
      "path",
      {
        "d": "m9 16 2 2 4-4"
      }
    ]
  ]);

export const SemaforoMonoIcon = crear('Semaforo', [
    [
      "rect",
      {
        "x": "7",
        "y": "2",
        "width": "10",
        "height": "20",
        "rx": "3"
      }
    ],
    [
      "path",
      {
        "d": "M12 7h.01"
      }
    ],
    [
      "path",
      {
        "d": "M12 12h.01"
      }
    ],
    [
      "path",
      {
        "d": "M12 17h.01"
      }
    ]
  ]);

export const SepararMonoIcon = crear('Separar', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7Z"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4"
      }
    ],
    [
      "path",
      {
        "d": "M8 15h8"
      }
    ],
    [
      "path",
      {
        "d": "m13 12 3 3-3 3"
      }
    ]
  ]);

export const SepararAmbosMonoIcon = crear('SepararAmbos', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7Z"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4"
      }
    ],
    [
      "path",
      {
        "d": "M7 15h10"
      }
    ],
    [
      "path",
      {
        "d": "m10 12-3 3 3 3"
      }
    ],
    [
      "path",
      {
        "d": "m14 12 3 3-3 3"
      }
    ]
  ]);

export const SesionIconMonoIcon = crear('SesionIcon', [
    [
      "path",
      {
        "d": "M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2"
      }
    ],
    [
      "circle",
      {
        "cx": "9",
        "cy": "7",
        "r": "4"
      }
    ],
    [
      "path",
      {
        "d": "M22 21v-2a4 4 0 0 0-3-3.87"
      }
    ],
    [
      "path",
      {
        "d": "M16 3.13a4 4 0 0 1 0 7.75"
      }
    ]
  ]);

export const SobregiroMonoIcon = crear('Sobregiro', [
    [
      "rect",
      {
        "x": "5",
        "y": "2",
        "width": "14",
        "height": "20",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M9 2v8l2-1.5 2 1.5V2"
      }
    ],
    [
      "path",
      {
        "d": "M9 16h6"
      }
    ]
  ]);

export const SolGastosMonoIcon = crear('SolGastos', [
    [
      "path",
      {
        "d": "M19 7V4a1 1 0 0 0-1-1H5a2 2 0 0 0 0 4h15a1 1 0 0 1 1 1v4h-3a2 2 0 0 0 0 4h3a1 1 0 0 0 1-1v-2a1 1 0 0 0-1-1"
      }
    ],
    [
      "path",
      {
        "d": "M3 5v14a2 2 0 0 0 2 2h15a1 1 0 0 0 1-1v-4"
      }
    ]
  ]);

export const SolicGarantiaMonoIcon = crear('SolicGarantia', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7Z"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4"
      }
    ],
    [
      "path",
      {
        "d": "M8 11h2"
      }
    ],
    [
      "path",
      {
        "d": "M8 15h8"
      }
    ],
    [
      "path",
      {
        "d": "M8 19h5"
      }
    ]
  ]);

export const ReordenarMonoIcon = crear('Reordenar', [
    [
      "path",
      {
        "d": "m3 16 4 4 4-4"
      }
    ],
    [
      "path",
      {
        "d": "M7 20V4"
      }
    ],
    [
      "rect",
      {
        "x": "15",
        "y": "4",
        "width": "4",
        "height": "6",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M17 20v-6h-2"
      }
    ],
    [
      "path",
      {
        "d": "M15 20h4"
      }
    ]
  ]);

export const RepAsistenciaMonoIcon = crear('RepAsistencia', [
    [
      "path",
      {
        "d": "M12 10a2 2 0 0 0-2 2c0 1.02-.1 2.51-.26 4"
      }
    ],
    [
      "path",
      {
        "d": "M14 13.12c0 2.38 0 6.38-1 8.88"
      }
    ],
    [
      "path",
      {
        "d": "M17.29 21.02c.12-.6.43-2.3.5-3.02"
      }
    ],
    [
      "path",
      {
        "d": "M2 12a10 10 0 0 1 18-6"
      }
    ],
    [
      "path",
      {
        "d": "M2 16h.01"
      }
    ],
    [
      "path",
      {
        "d": "M21.8 16c.2-2 .131-5.354 0-6"
      }
    ],
    [
      "path",
      {
        "d": "M5 19.5C5.5 18 6 15 6 12a6 6 0 0 1 .34-2"
      }
    ],
    [
      "path",
      {
        "d": "M8.65 22c.21-.66.45-1.32.57-2"
      }
    ],
    [
      "path",
      {
        "d": "M9 6.8a6 6 0 0 1 9 5.2v2"
      }
    ]
  ]);

export const QuickPlayMonoIcon = crear('QuickPlay', [
    [
      "path",
      {
        "d": "M3 12a9 9 0 0 1 15-6.7L21 8"
      }
    ],
    [
      "path",
      {
        "d": "M21 3v5h-5"
      }
    ],
    [
      "path",
      {
        "d": "M21 12a9 9 0 0 1-15 6.7L3 16"
      }
    ],
    [
      "path",
      {
        "d": "M3 21v-5h5"
      }
    ]
  ]);

export const ProvisionalMonoIcon = crear('Provisional', [
    [
      "path",
      {
        "d": "M9 3h6l-1.5 3h-3Z"
      }
    ],
    [
      "path",
      {
        "d": "M8 21c-3 0-4-2-4-4 0-3 3-6 5.5-8.5h5C17 11 20 14 20 17c0 2-1 4-4 4Z"
      }
    ],
    [
      "ellipse",
      {
        "cx": "8",
        "cy": "18",
        "rx": "3",
        "ry": "1.4"
      }
    ]
  ]);

export const ProcCtaDestMonoIcon = crear('ProcCtaDest', [
    [
      "rect",
      {
        "x": "3",
        "y": "4",
        "width": "18",
        "height": "16",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M3 9h18"
      }
    ],
    [
      "path",
      {
        "d": "M3 15h18"
      }
    ],
    [
      "path",
      {
        "d": "M7 6.5h.01"
      }
    ],
    [
      "path",
      {
        "d": "M11 6.5h.01"
      }
    ],
    [
      "path",
      {
        "d": "M9 12h.01"
      }
    ],
    [
      "path",
      {
        "d": "M15 12h.01"
      }
    ],
    [
      "path",
      {
        "d": "M8 17.5h.01"
      }
    ],
    [
      "path",
      {
        "d": "M13 17.5h.01"
      }
    ]
  ]);

export const ProcCierreMesMonoIcon = crear('ProcCierreMes', [
    [
      "path",
      {
        "d": "M8 2v4"
      }
    ],
    [
      "path",
      {
        "d": "M16 2v4"
      }
    ],
    [
      "rect",
      {
        "x": "3",
        "y": "4",
        "width": "18",
        "height": "18",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M3 10h18"
      }
    ],
    [
      "path",
      {
        "d": "M8 14h.01"
      }
    ],
    [
      "path",
      {
        "d": "M12 14h.01"
      }
    ],
    [
      "path",
      {
        "d": "M16 14h.01"
      }
    ],
    [
      "path",
      {
        "d": "M8 18h.01"
      }
    ],
    [
      "path",
      {
        "d": "M12 18h.01"
      }
    ],
    [
      "path",
      {
        "d": "M16 18h.01"
      }
    ]
  ]);

export const RechazarMonoIcon = crear('Rechazar', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "10"
      }
    ],
    [
      "path",
      {
        "d": "m4.9 4.9 14.2 14.2"
      }
    ]
  ]);

export const RegComprasMonoIcon = crear('RegCompras', [
    [
      "path",
      {
        "d": "m15 11-1 9"
      }
    ],
    [
      "path",
      {
        "d": "m19 11-4-7"
      }
    ],
    [
      "path",
      {
        "d": "M2 11h20"
      }
    ],
    [
      "path",
      {
        "d": "m3.5 11 1.6 7.4a2 2 0 0 0 2 1.6h9.8a2 2 0 0 0 2-1.6l1.7-7.4"
      }
    ],
    [
      "path",
      {
        "d": "M4.5 15.5h15"
      }
    ],
    [
      "path",
      {
        "d": "m5 11 4-7"
      }
    ],
    [
      "path",
      {
        "d": "m9 11 1 9"
      }
    ]
  ]);

export const RecalcularMonoIcon = crear('Recalcular', [
    [
      "path",
      {
        "d": "M12.22 2h-.44a2 2 0 0 0-2 2v.18a2 2 0 0 1-1 1.73l-.43.25a2 2 0 0 1-2 0l-.15-.08a2 2 0 0 0-2.73.73l-.22.38a2 2 0 0 0 .73 2.73l.15.1a2 2 0 0 1 1 1.72v.51a2 2 0 0 1-1 1.74l-.15.09a2 2 0 0 0-.73 2.73l.22.38a2 2 0 0 0 2.73.73l.15-.08a2 2 0 0 1 2 0l.43.25a2 2 0 0 1 1 1.73V20a2 2 0 0 0 2 2h.44a2 2 0 0 0 2-2v-.18a2 2 0 0 1 1-1.73l.43-.25a2 2 0 0 1 2 0l.15.08a2 2 0 0 0 2.73-.73l.22-.39a2 2 0 0 0-.73-2.73l-.15-.08a2 2 0 0 1-1-1.74v-.5a2 2 0 0 1 1-1.74l.15-.09a2 2 0 0 0 .73-2.73l-.22-.38a2 2 0 0 0-2.73-.73l-.15.08a2 2 0 0 1-2 0l-.43-.25a2 2 0 0 1-1-1.73V4a2 2 0 0 0-2-2z"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "3"
      }
    ]
  ]);

export const PreMarcacionMonoIcon = crear('PreMarcacion', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "10"
      }
    ],
    [
      "path",
      {
        "d": "M12 6v6l4 2"
      }
    ]
  ]);

export const ProcesarMonoIcon = crear('Procesar', [
    [
      "rect",
      {
        "x": "8",
        "y": "2",
        "width": "8",
        "height": "4",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M10.42 12.61a2.1 2.1 0 1 1 2.97 2.97L7.95 21 4 22l.99-3.95 5.43-5.44Z"
      }
    ],
    [
      "path",
      {
        "d": "M16 4h2a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2h-5.5"
      }
    ],
    [
      "path",
      {
        "d": "M4 13.5V6a2 2 0 0 1 2-2h2"
      }
    ]
  ]);

export const ReembolsoMonoIcon = crear('Reembolso', [
    [
      "rect",
      {
        "x": "2",
        "y": "9",
        "width": "14",
        "height": "10",
        "rx": "2"
      }
    ],
    [
      "circle",
      {
        "cx": "9",
        "cy": "14",
        "r": "2"
      }
    ],
    [
      "path",
      {
        "d": "M22 12V8a2 2 0 0 0-2-2h-6"
      }
    ],
    [
      "path",
      {
        "d": "m17 3-3 3 3 3"
      }
    ]
  ]);

export const ProcessMonoIcon = crear('Process', [
    [
      "path",
      {
        "d": "M12.22 2h-.44a2 2 0 0 0-2 2v.18a2 2 0 0 1-1 1.73l-.43.25a2 2 0 0 1-2 0l-.15-.08a2 2 0 0 0-2.73.73l-.22.38a2 2 0 0 0 .73 2.73l.15.1a2 2 0 0 1 1 1.72v.51a2 2 0 0 1-1 1.74l-.15.09a2 2 0 0 0-.73 2.73l.22.38a2 2 0 0 0 2.73.73l.15-.08a2 2 0 0 1 2 0l.43.25a2 2 0 0 1 1 1.73V20a2 2 0 0 0 2 2h.44a2 2 0 0 0 2-2v-.18a2 2 0 0 1 1-1.73l.43-.25a2 2 0 0 1 2 0l.15.08a2 2 0 0 0 2.73-.73l.22-.39a2 2 0 0 0-.73-2.73l-.15-.08a2 2 0 0 1-1-1.74v-.5a2 2 0 0 1 1-1.74l.15-.09a2 2 0 0 0 .73-2.73l-.22-.38a2 2 0 0 0-2.73-.73l-.15.08a2 2 0 0 1-2 0l-.43-.25a2 2 0 0 1-1-1.73V4a2 2 0 0 0-2-2z"
      }
    ],
    [
      "path",
      {
        "d": "m9.5 12 1.8 1.8 3.4-3.6"
      }
    ]
  ]);

export const ReclamoGarantiaHojaMonoIcon = crear('ReclamoGarantiaHoja', [
    [
      "rect",
      {
        "x": "5",
        "y": "2",
        "width": "14",
        "height": "20",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M9 7h6"
      }
    ],
    [
      "path",
      {
        "d": "M9 11h6"
      }
    ],
    [
      "path",
      {
        "d": "M9 15h4"
      }
    ]
  ]);

export const Rechazar3MonoIcon = crear('Rechazar3', [
    [
      "rect",
      {
        "x": "3",
        "y": "3",
        "width": "18",
        "height": "18",
        "rx": "3"
      }
    ],
    [
      "path",
      {
        "d": "m15 9-6 6"
      }
    ],
    [
      "path",
      {
        "d": "m9 9 6 6"
      }
    ]
  ]);

export const RegresarMonoIcon = crear('Regresar', [
    [
      "path",
      {
        "d": "m11 17-5-5 5-5"
      }
    ],
    [
      "path",
      {
        "d": "m18 17-5-5 5-5"
      }
    ]
  ]);

export const ProcessJobMonoIcon = crear('ProcessJob', [
    [
      "path",
      {
        "d": "M14.7 6.3a1 1 0 0 0 0 1.4l1.6 1.6a1 1 0 0 0 1.4 0l3.77-3.77a6 6 0 0 1-7.94 7.94l-6.91 6.91a2.12 2.12 0 0 1-3-3l6.91-6.91a6 6 0 0 1 7.94-7.94l-3.76 3.76z"
      }
    ],
    [
      "path",
      {
        "d": "m3 3 6 6"
      }
    ]
  ]);

export const IngPlanillas2MonoIcon = crear('IngPlanillas2', [
    [
      "path",
      {
        "d": "M8.2 6.4C4.8 9.2 2.6 12.8 2.6 17.2c0 3.4 2.6 5 6 5h6.8c3.4 0 6-1.6 6-5 0-4.4-2.2-8-5.6-10.8Z",
        "stroke": "currentColor",
        "strokeWidth": "0.9"
      }
    ],
    [
      "path",
      {
        "d": "M5.4 11.6C4.4 13 3.9 14.6 3.9 16.4",
        "stroke": "currentColor",
        "strokeWidth": "0.8"
      }
    ],
    [
      "path",
      {
        "d": "M8.4 6.6C7.6 4.8 7.8 3.2 8.8 2.2L10.6 3.8 12 2.4 13.4 3.8 15.2 2.2c1 1 1.2 2.6.4 4.4Z",
        "stroke": "currentColor",
        "strokeWidth": "0.8"
      }
    ],
    [
      "path",
      {
        "d": "M8.1 6.6C10.6 8 13.4 8 15.9 6.6L16.2 8.8C13.6 10.2 10.4 10.2 7.8 8.8Z",
        "stroke": "currentColor",
        "strokeWidth": "0.8"
      }
    ],
    [
      "path",
      {
        "d": "M8.6 7.4C10.8 8.4 13.2 8.4 15.4 7.4",
        "stroke": "currentColor",
        "strokeWidth": "0.5"
      }
    ],
    [
      "path",
      {
        "d": "M14.6 12.4C14 11.4 13 10.9 11.9 10.9 10.5 10.9 9.5 11.7 9.5 12.8c0 1.2 1.1 1.7 2.5 2.1 1.5.4 2.6 1 2.6 2.2 0 1.2-1.1 2-2.6 2-1.2 0-2.3-.5-2.9-1.5",
        "stroke": "currentColor",
        "strokeWidth": "1.25"
      }
    ],
    [
      "path",
      {
        "d": "M12 9.6V10.9M12 19.2V20.4",
        "stroke": "currentColor",
        "strokeWidth": "1.2"
      }
    ]
  ]);

export const LibDiario2MonoIcon = crear('LibDiario2', [
    [
      "path",
      {
        "d": "M12 7v14"
      }
    ],
    [
      "path",
      {
        "d": "M3 18a1 1 0 0 1-1-1V4a1 1 0 0 1 1-1h5a4 4 0 0 1 4 4 4 4 0 0 1 4-4h5a1 1 0 0 1 1 1v13a1 1 0 0 1-1 1h-6a3 3 0 0 0-3 3 3 3 0 0 0-3-3z"
      }
    ],
    [
      "path",
      {
        "d": "M5 8h3M5 12h3M16 8h3M16 12h3"
      }
    ]
  ]);

export const LibMayor2MonoIcon = crear('LibMayor2', [
    [
      "rect",
      {
        "x": "4",
        "y": "2",
        "width": "16",
        "height": "20",
        "rx": "2",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M2 6h4M2 10h4M2 14h4M2 18h4M10 7h6M10 11h6",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M18 15.5v5M15.5 18h5"
      }
    ]
  ]);

export const LineaTelefonica2MonoIcon = crear('LineaTelefonica2', [
    [
      "path",
      {
        "d": "M6.4 2.4c-.6.5-1 1.1-.8 1.8.9 3.1 2.7 6.1 5 8.4s5.3 4.1 8.4 5c.7.2 1.3-.2 1.8-.8l1.2-1.4c.5-.6.4-1.3-.2-1.8l-2.6-1.9c-.6-.4-1.3-.3-1.8.2l-.8.9C14 12 12.4 10.5 11.4 8.6l.9-.8c.5-.5.6-1.2.2-1.8L10.6 3.4C10.1 2.8 9.4 2.7 8.8 3.2Z",
        "stroke": "currentColor",
        "strokeWidth": "1.6"
      }
    ],
    [
      "path",
      {
        "d": "M4.9 13.4C2.7 13 1.5 15 2.8 16.7l3.4 4.2c.9 1.1 2.4 1.3 3.6.6",
        "stroke": "currentColor",
        "strokeWidth": "1.6"
      }
    ]
  ]);

export const MpIcon2MonoIcon = crear('MpIcon2', [
    [
      "path",
      {
        "d": "M2.2 9.4C1.4 6 3.6 3.4 6.8 3.2 8 3.2 9 3.6 9.6 4.2L4 9.9Z",
        "stroke": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M21.8 9.4C22.6 6 20.4 3.4 17.2 3.2 16 3.2 15 3.6 14.4 4.2L20 9.9Z",
        "stroke": "currentColor"
      }
    ],
    [
      "rect",
      {
        "x": "10.8",
        "y": "1.2",
        "width": "2.4",
        "height": "2.2",
        "rx": "0.8",
        "stroke": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M6.6 20.8L5.2 22.5M17.4 20.8L18.8 22.5",
        "stroke": "currentColor",
        "strokeWidth": "1.7"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "13.2",
        "r": "8.1",
        "stroke": "currentColor",
        "strokeWidth": "2.2"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "13.2",
        "r": "6.6",
        "stroke": "currentColor",
        "strokeWidth": "0.4"
      }
    ],
    [
      "path",
      {
        "d": "M12 13.8V8M12 13.8H15.6",
        "stroke": "currentColor",
        "strokeWidth": "1.7"
      }
    ]
  ]);

export const Office2MonoIcon = crear('Office2', [
    [
      "rect",
      {
        "x": "4",
        "y": "2",
        "width": "16",
        "height": "20",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M9 22v-4h6v4"
      }
    ],
    [
      "path",
      {
        "d": "M8 6h.01"
      }
    ],
    [
      "path",
      {
        "d": "M12 6h.01"
      }
    ],
    [
      "path",
      {
        "d": "M16 6h.01"
      }
    ],
    [
      "path",
      {
        "d": "M8 10h.01"
      }
    ],
    [
      "path",
      {
        "d": "M12 10h.01"
      }
    ],
    [
      "path",
      {
        "d": "M16 10h.01"
      }
    ],
    [
      "path",
      {
        "d": "M8 14h.01"
      }
    ],
    [
      "path",
      {
        "d": "M12 14h.01"
      }
    ],
    [
      "path",
      {
        "d": "M16 14h.01"
      }
    ]
  ]);

export const Afp2MonoIcon = crear('Afp2', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M13.5 18h9M18 13.5c-2 2.4-2 6.6 0 9M18 13.5c2 2.4 2 6.6 0 9"
      }
    ]
  ]);

export const AreaCosto2MonoIcon = crear('AreaCosto2', [
    [
      "path",
      {
        "d": "M12 5.2V7.6M4.8 7.6H19.2M4.8 7.6V9.6M12 7.6V9.6M19.2 7.6V9.6",
        "stroke": "currentColor",
        "strokeWidth": "1.1"
      }
    ],
    [
      "path",
      {
        "d": "M4.8 13.6V16.2M12 13.6V16.2M19.2 13.6V16.2",
        "stroke": "currentColor",
        "strokeWidth": "1.1"
      }
    ],
    [
      "rect",
      {
        "x": "8",
        "y": "1",
        "width": "8",
        "height": "4.4",
        "rx": "0.5",
        "stroke": "currentColor",
        "strokeWidth": "0.9"
      }
    ],
    [
      "rect",
      {
        "x": "8.8",
        "y": "1.8",
        "width": "6.4",
        "height": "1.6",
        "rx": "0.2",
        "stroke": "currentColor"
      }
    ],
    [
      "rect",
      {
        "x": "2.2",
        "y": "9.6",
        "width": "5.6",
        "height": "4.2",
        "rx": "0.5",
        "stroke": "currentColor",
        "strokeWidth": "1"
      }
    ],
    [
      "rect",
      {
        "x": "3.1",
        "y": "10.5",
        "width": "3.8",
        "height": "1.2",
        "rx": "0",
        "stroke": "currentColor"
      }
    ],
    [
      "rect",
      {
        "x": "9.2",
        "y": "9.6",
        "width": "5.6",
        "height": "4.2",
        "rx": "0.5",
        "stroke": "currentColor",
        "strokeWidth": "1"
      }
    ],
    [
      "rect",
      {
        "x": "10.1",
        "y": "10.5",
        "width": "3.8",
        "height": "1.2",
        "rx": "0",
        "stroke": "currentColor"
      }
    ],
    [
      "rect",
      {
        "x": "16.2",
        "y": "9.6",
        "width": "5.6",
        "height": "4.2",
        "rx": "0.5",
        "stroke": "currentColor",
        "strokeWidth": "1"
      }
    ],
    [
      "rect",
      {
        "x": "17.1",
        "y": "10.5",
        "width": "3.8",
        "height": "1.2",
        "rx": "0",
        "stroke": "currentColor"
      }
    ],
    [
      "rect",
      {
        "x": "2.2",
        "y": "16.2",
        "width": "5.6",
        "height": "4.6",
        "rx": "0.5",
        "stroke": "currentColor",
        "strokeWidth": "0.9"
      }
    ],
    [
      "rect",
      {
        "x": "3.1",
        "y": "17.1",
        "width": "3.8",
        "height": "1.4",
        "rx": "0",
        "stroke": "currentColor"
      }
    ],
    [
      "rect",
      {
        "x": "9.2",
        "y": "16.2",
        "width": "5.6",
        "height": "4.6",
        "rx": "0.5",
        "stroke": "currentColor",
        "strokeWidth": "0.9"
      }
    ],
    [
      "rect",
      {
        "x": "10.1",
        "y": "17.1",
        "width": "3.8",
        "height": "1.4",
        "rx": "0",
        "stroke": "currentColor"
      }
    ],
    [
      "rect",
      {
        "x": "16.2",
        "y": "16.2",
        "width": "5.6",
        "height": "4.6",
        "rx": "0.5",
        "stroke": "currentColor",
        "strokeWidth": "0.9"
      }
    ],
    [
      "rect",
      {
        "x": "17.1",
        "y": "17.1",
        "width": "3.8",
        "height": "1.4",
        "rx": "0",
        "stroke": "currentColor"
      }
    ]
  ]);

export const CerrarPr2MonoIcon = crear('CerrarPr2', [
    [
      "path",
      {
        "d": "M7.4 10.8V7.4C7.4 3.6 9.4 1.6 12 1.6S16.6 3.6 16.6 7.4V10.8",
        "stroke": "currentColor",
        "strokeWidth": "2.4"
      }
    ],
    [
      "path",
      {
        "d": "M7.4 10.8V7.4C7.4 3.8 9.4 1.9 12 1.9",
        "stroke": "currentColor",
        "strokeWidth": "0.9"
      }
    ],
    [
      "rect",
      {
        "x": "4.2",
        "y": "10.2",
        "width": "15.6",
        "height": "12",
        "rx": "0.6",
        "stroke": "currentColor",
        "strokeWidth": "0.9"
      }
    ],
    [
      "rect",
      {
        "x": "4.2",
        "y": "17.6",
        "width": "15.6",
        "height": "4.6",
        "rx": "0",
        "stroke": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M4.2 21.2 L4.2 22.2 L5.4 22.2 L10 17.6 L7.8 17.6Z",
        "stroke": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M7.6 22.2 L9.8 22.2 L14.4 17.6 L12.2 17.6Z",
        "stroke": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M12 22.2 L14.2 22.2 L18.8 17.6 L16.6 17.6Z",
        "stroke": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M19.8 18.8 L16.4 22.2 L18.6 22.2 L19.8 21Z",
        "stroke": "currentColor"
      }
    ],
    [
      "rect",
      {
        "x": "4.2",
        "y": "17.6",
        "width": "15.6",
        "height": "4.6",
        "rx": "0.3",
        "stroke": "currentColor",
        "strokeWidth": "0.6"
      }
    ]
  ]);

export const CtasCtes2MonoIcon = crear('CtasCtes2', [
    [
      "rect",
      {
        "x": "3",
        "y": "3.8",
        "width": "17.2",
        "height": "10.6",
        "rx": "1.2",
        "stroke": "currentColor",
        "strokeWidth": "0.8",
        "transform": "rotate(-13 12 12)"
      }
    ],
    [
      "rect",
      {
        "x": "3",
        "y": "3.8",
        "width": "17.2",
        "height": "3.4",
        "rx": "1",
        "stroke": "currentColor",
        "transform": "rotate(-13 12 12)"
      }
    ],
    [
      "rect",
      {
        "x": "3",
        "y": "10.8",
        "width": "17.2",
        "height": "2.2",
        "rx": "0",
        "stroke": "currentColor",
        "transform": "rotate(-13 12 12)"
      }
    ],
    [
      "path",
      {
        "d": "M5.4 9H12M5.4 9.0L6.6 8H7.8",
        "stroke": "currentColor",
        "strokeWidth": "0.5",
        "transform": "rotate(-13 12 12)"
      }
    ],
    [
      "rect",
      {
        "x": "6.2",
        "y": "7.6",
        "width": "7.6",
        "height": "2",
        "rx": "0.3",
        "stroke": "currentColor",
        "strokeWidth": "0.9",
        "transform": "rotate(-13 12 12)"
      }
    ],
    [
      "rect",
      {
        "x": "4.4",
        "y": "11.4",
        "width": "17.2",
        "height": "10.6",
        "rx": "1.2",
        "stroke": "currentColor",
        "strokeWidth": "0.8",
        "transform": "rotate(-13 14 14)"
      }
    ],
    [
      "rect",
      {
        "x": "4.4",
        "y": "13.2",
        "width": "17.2",
        "height": "2",
        "rx": "0",
        "stroke": "currentColor",
        "transform": "rotate(-13 14 14)"
      }
    ],
    [
      "circle",
      {
        "cx": "11.6",
        "cy": "18.6",
        "r": "2.8",
        "stroke": "currentColor",
        "fillOpacity": "0.95",
        "transform": "rotate(-13 14 14)"
      }
    ],
    [
      "circle",
      {
        "cx": "14.6",
        "cy": "18.6",
        "r": "2.8",
        "stroke": "currentColor",
        "fillOpacity": "0.9",
        "transform": "rotate(-13 14 14)"
      }
    ]
  ]);

export const HeIcon2MonoIcon = crear('HeIcon2', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "10.6",
        "stroke": "currentColor",
        "strokeWidth": "0.8"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "9.2",
        "stroke": "currentColor",
        "strokeWidth": "0.5"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "6.2",
        "stroke": "currentColor",
        "fillOpacity": "0.5"
      }
    ],
    [
      "path",
      {
        "d": "M12.00 5.00L12.00 3.30",
        "stroke": "currentColor",
        "strokeWidth": "1.3"
      }
    ],
    [
      "path",
      {
        "d": "M15.80 5.42L16.25 4.64",
        "stroke": "currentColor",
        "strokeWidth": "0.7"
      }
    ],
    [
      "path",
      {
        "d": "M18.58 8.20L19.36 7.75",
        "stroke": "currentColor",
        "strokeWidth": "0.7"
      }
    ],
    [
      "path",
      {
        "d": "M19.00 12.00L20.70 12.00",
        "stroke": "currentColor",
        "strokeWidth": "1.3"
      }
    ],
    [
      "path",
      {
        "d": "M18.58 15.80L19.36 16.25",
        "stroke": "currentColor",
        "strokeWidth": "0.7"
      }
    ],
    [
      "path",
      {
        "d": "M15.80 18.58L16.25 19.36",
        "stroke": "currentColor",
        "strokeWidth": "0.7"
      }
    ],
    [
      "path",
      {
        "d": "M12.00 19.00L12.00 20.70",
        "stroke": "currentColor",
        "strokeWidth": "1.3"
      }
    ],
    [
      "path",
      {
        "d": "M8.20 18.58L7.75 19.36",
        "stroke": "currentColor",
        "strokeWidth": "0.7"
      }
    ],
    [
      "path",
      {
        "d": "M5.42 15.80L4.64 16.25",
        "stroke": "currentColor",
        "strokeWidth": "0.7"
      }
    ],
    [
      "path",
      {
        "d": "M5.00 12.00L3.30 12.00",
        "stroke": "currentColor",
        "strokeWidth": "1.3"
      }
    ],
    [
      "path",
      {
        "d": "M5.42 8.20L4.64 7.75",
        "stroke": "currentColor",
        "strokeWidth": "0.7"
      }
    ],
    [
      "path",
      {
        "d": "M8.20 5.42L7.75 4.64",
        "stroke": "currentColor",
        "strokeWidth": "0.7"
      }
    ],
    [
      "path",
      {
        "d": "M6.2 15.6L18.8 11.2",
        "stroke": "currentColor",
        "strokeWidth": "1.5"
      }
    ],
    [
      "path",
      {
        "d": "M12 12L12.6 12.2",
        "stroke": "currentColor",
        "strokeWidth": "1.9"
      }
    ]
  ]);

export const HorsExt2MonoIcon = crear('HorsExt2', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "13",
        "r": "8",
        "transform": "scale(.78)"
      }
    ],
    [
      "path",
      {
        "d": "M12 9v4l2 2M5 3 2 6M22 6l-3-3M6 19l-2 2M18 19l2 2",
        "transform": "scale(.78)"
      }
    ],
    [
      "circle",
      {
        "cx": "18",
        "cy": "18",
        "r": "5",
        "fill": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M18 15.5v5M15.5 18h5"
      }
    ]
  ]);

export const HrsEquipo2MonoIcon = crear('HrsEquipo2', [
    [
      "path",
      {
        "d": "M14.8 20C13.2 21.2 11.8 21.6 10.2 21.6A8.6 8.6 0 1 1 18.6 12.6",
        "stroke": "currentColor",
        "strokeWidth": "1.4"
      }
    ],
    [
      "path",
      {
        "d": "M10.20 6.80L10.20 5.60",
        "stroke": "currentColor",
        "strokeWidth": "1.1"
      }
    ],
    [
      "path",
      {
        "d": "M16.60 13.20L17.80 13.20",
        "stroke": "currentColor",
        "strokeWidth": "1.1"
      }
    ],
    [
      "path",
      {
        "d": "M10.20 19.60L10.20 20.80",
        "stroke": "currentColor",
        "strokeWidth": "1.1"
      }
    ],
    [
      "path",
      {
        "d": "M3.80 13.20L2.60 13.20",
        "stroke": "currentColor",
        "strokeWidth": "1.1"
      }
    ],
    [
      "path",
      {
        "d": "M10.2 13.2L6.2 10.6",
        "stroke": "currentColor",
        "strokeWidth": "0.9"
      }
    ],
    [
      "path",
      {
        "d": "M10.2 13.2V8.2",
        "stroke": "currentColor",
        "strokeWidth": "0.9"
      }
    ],
    [
      "path",
      {
        "d": "M16.64 3.32L16.84 1.85L18.36 1.85L18.56 3.32A4.0 4.0 0 0 1 19.66 3.77L20.84 2.88L21.92 3.96L21.03 5.14A4.0 4.0 0 0 1 21.48 6.24L22.95 6.44L22.95 7.96L21.48 8.16A4.0 4.0 0 0 1 21.03 9.26L21.92 10.44L20.84 11.52L19.66 10.63A4.0 4.0 0 0 1 18.56 11.08L18.36 12.55L16.84 12.55L16.64 11.08A4.0 4.0 0 0 1 15.54 10.63L14.36 11.52L13.28 10.44L14.17 9.26A4.0 4.0 0 0 1 13.72 8.16L12.25 7.96L12.25 6.44L13.72 6.24A4.0 4.0 0 0 1 14.17 5.14L13.28 3.96L14.36 2.88L15.54 3.77A4.0 4.0 0 0 1 16.64 3.32Z",
        "stroke": "currentColor",
        "strokeWidth": "1.2"
      }
    ],
    [
      "circle",
      {
        "cx": "17.6",
        "cy": "7.2",
        "r": "1.8",
        "stroke": "currentColor",
        "strokeWidth": "1.1"
      }
    ]
  ]);

export const IcoReloj222MonoIcon = crear('IcoReloj222', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "10.6",
        "stroke": "currentColor",
        "strokeWidth": "2.4"
      }
    ],
    [
      "path",
      {
        "d": "M12 2.8V5.6M12 18.4V21.2M2.8 12H5.6M18.4 12H21.2",
        "stroke": "currentColor",
        "strokeWidth": "1.4"
      }
    ],
    [
      "circle",
      {
        "cx": "15.9",
        "cy": "5.245",
        "r": "0.55",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "18.755",
        "cy": "8.1",
        "r": "0.55",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "18.755",
        "cy": "15.9",
        "r": "0.55",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "15.9",
        "cy": "18.755",
        "r": "0.55",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "8.1",
        "cy": "18.755",
        "r": "0.55",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "5.245",
        "cy": "15.9",
        "r": "0.55",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "5.245",
        "cy": "8.1",
        "r": "0.55",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "8.1",
        "cy": "5.245",
        "r": "0.55",
        "stroke": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M12 12L7.4 5.4",
        "stroke": "currentColor",
        "strokeWidth": "1.5"
      }
    ],
    [
      "path",
      {
        "d": "M12 12L13.8 19",
        "stroke": "currentColor",
        "strokeWidth": "1.5"
      }
    ],
    [
      "path",
      {
        "d": "M12 12L18.4 6",
        "stroke": "currentColor",
        "strokeWidth": "1"
      }
    ]
  ]);

export const IcoReloj22MonoIcon = crear('IcoReloj22', [
    [
      "rect",
      {
        "x": "7",
        "y": "0.8",
        "width": "10",
        "height": "2.6",
        "rx": "0.3",
        "stroke": "currentColor"
      }
    ],
    [
      "rect",
      {
        "x": "7",
        "y": "20.6",
        "width": "10",
        "height": "2.6",
        "rx": "0.3",
        "stroke": "currentColor"
      }
    ],
    [
      "rect",
      {
        "x": "21.6",
        "y": "10.4",
        "width": "1.8",
        "height": "3.2",
        "rx": "0.3",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "10",
        "stroke": "currentColor",
        "strokeWidth": "1.5"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "8.4",
        "stroke": "currentColor",
        "strokeWidth": "0.5"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "5",
        "r": "0.85",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "11.65",
        "cy": "4.65",
        "r": "0.35",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "15.5",
        "cy": "5.938",
        "r": "0.85",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "15.15",
        "cy": "5.588",
        "r": "0.35",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "18.062",
        "cy": "8.5",
        "r": "0.85",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "17.712",
        "cy": "8.15",
        "r": "0.35",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "19",
        "cy": "12",
        "r": "0.85",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "18.65",
        "cy": "11.65",
        "r": "0.35",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "18.062",
        "cy": "15.5",
        "r": "0.85",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "17.712",
        "cy": "15.15",
        "r": "0.35",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "15.5",
        "cy": "18.062",
        "r": "0.85",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "15.15",
        "cy": "17.712",
        "r": "0.35",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "19",
        "r": "0.85",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "11.65",
        "cy": "18.65",
        "r": "0.35",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "8.5",
        "cy": "18.062",
        "r": "0.85",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "8.15",
        "cy": "17.712",
        "r": "0.35",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "5.938",
        "cy": "15.5",
        "r": "0.85",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "5.588",
        "cy": "15.15",
        "r": "0.35",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "5",
        "cy": "12",
        "r": "0.85",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "4.65",
        "cy": "11.65",
        "r": "0.35",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "5.938",
        "cy": "8.5",
        "r": "0.85",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "5.588",
        "cy": "8.15",
        "r": "0.35",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "8.5",
        "cy": "5.938",
        "r": "0.85",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "8.15",
        "cy": "5.588",
        "r": "0.35",
        "stroke": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M5 14.8 L10.6 9 L11.8 10.4 L6.2 16.2Z",
        "stroke": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M13 10.4 L18.4 5.4 L19.6 6.8 L14.2 11.8Z",
        "stroke": "currentColor"
      }
    ],
    [
      "path",
      {
        "d": "M12 12V5.4M12 12H17.2",
        "stroke": "currentColor",
        "strokeWidth": "1.1"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "1",
        "stroke": "currentColor",
        "strokeWidth": "0.4"
      }
    ]
  ]);

export const IcoReloj32MonoIcon = crear('IcoReloj32', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "10.6",
        "stroke": "currentColor",
        "strokeWidth": "1.4"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "9.2",
        "stroke": "currentColor",
        "strokeWidth": "1"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "8.1",
        "stroke": "currentColor",
        "strokeWidth": "0.9"
      }
    ],
    [
      "path",
      {
        "d": "M12 3.8V6M12 18V20.2M3.8 12H6M18 12H20.2",
        "stroke": "currentColor",
        "strokeWidth": "1.3"
      }
    ],
    [
      "path",
      {
        "d": "M12 12V5M12 12L17.8 6.2",
        "stroke": "currentColor",
        "strokeWidth": "1.5"
      }
    ],
    [
      "path",
      {
        "d": "M12 12L8.2 15.2",
        "stroke": "currentColor",
        "strokeWidth": "0.9"
      }
    ]
  ]);

export const Indicador2ico2MonoIcon = crear('Indicador2ico2', [
    [
      "path",
      {
        "d": "M3 3v16a2 2 0 0 0 2 2h16"
      }
    ],
    [
      "path",
      {
        "d": "M7 17v-3M11 17v-6M15 17V8M19 17V5"
      }
    ]
  ]);

export const Indicador2ico3MonoIcon = crear('Indicador2ico3', [
    [
      "path",
      {
        "d": "M3 3v18h18"
      }
    ],
    [
      "path",
      {
        "d": "M11 17v-4M15.500 17v-7M20 17V8"
      }
    ],
    [
      "circle",
      {
        "cx": "8",
        "cy": "8",
        "r": "3.5"
      }
    ],
    [
      "path",
      {
        "d": "M8 4.500V8h3.500"
      }
    ]
  ]);

export const Impresora2IcoMonoIcon = crear('Impresora2Ico', [
    [
      "rect",
      {
        "x": "8.2",
        "y": "1.2",
        "width": "7.6",
        "height": "7.6",
        "rx": "0.3",
        "stroke": "currentColor",
        "strokeWidth": "0.9"
      }
    ],
    [
      "rect",
      {
        "x": "1.4",
        "y": "8.2",
        "width": "21.2",
        "height": "8.8",
        "rx": "1",
        "stroke": "currentColor",
        "strokeWidth": "0.9"
      }
    ],
    [
      "rect",
      {
        "x": "3",
        "y": "9.4",
        "width": "18",
        "height": "4.4",
        "rx": "0.5",
        "stroke": "currentColor"
      }
    ],
    [
      "rect",
      {
        "x": "1.4",
        "y": "9.4",
        "width": "2.6",
        "height": "5.8",
        "rx": "0.3",
        "stroke": "currentColor"
      }
    ],
    [
      "rect",
      {
        "x": "20",
        "y": "9.4",
        "width": "2.6",
        "height": "5.8",
        "rx": "0.3",
        "stroke": "currentColor"
      }
    ],
    [
      "rect",
      {
        "x": "10.6",
        "y": "11.6",
        "width": "5.2",
        "height": "1.3",
        "rx": "0",
        "stroke": "currentColor"
      }
    ],
    [
      "rect",
      {
        "x": "8.2",
        "y": "16.4",
        "width": "7.6",
        "height": "6.4",
        "rx": "0.3",
        "stroke": "currentColor",
        "strokeWidth": "0.8"
      }
    ],
    [
      "rect",
      {
        "x": "10.8",
        "y": "19.6",
        "width": "1.6",
        "height": "1.6",
        "rx": "0",
        "stroke": "currentColor"
      }
    ]
  ]);

export const Impresora2PngMonoIcon = crear('Impresora2Png', [
    [
      "rect",
      {
        "x": "6.6",
        "y": "1.2",
        "width": "10.8",
        "height": "7",
        "rx": "0.5",
        "stroke": "currentColor",
        "strokeWidth": "0.8"
      }
    ],
    [
      "rect",
      {
        "x": "1.6",
        "y": "7",
        "width": "20.8",
        "height": "10.6",
        "rx": "2.8",
        "stroke": "currentColor",
        "strokeWidth": "0.9"
      }
    ],
    [
      "rect",
      {
        "x": "3",
        "y": "8.4",
        "width": "18",
        "height": "4.6",
        "rx": "1.2",
        "stroke": "currentColor",
        "strokeWidth": "0.8"
      }
    ],
    [
      "rect",
      {
        "x": "3.8",
        "y": "9",
        "width": "16.4",
        "height": "1.4",
        "rx": "0.6",
        "stroke": "currentColor"
      }
    ],
    [
      "rect",
      {
        "x": "3",
        "y": "13",
        "width": "18",
        "height": "1.2",
        "rx": "0.4",
        "stroke": "currentColor"
      }
    ],
    [
      "circle",
      {
        "cx": "19.6",
        "cy": "15.4",
        "r": "0.6",
        "stroke": "currentColor"
      }
    ],
    [
      "rect",
      {
        "x": "6.6",
        "y": "15.8",
        "width": "10.8",
        "height": "6.2",
        "rx": "0.5",
        "stroke": "currentColor",
        "strokeWidth": "0.8"
      }
    ],
    [
      "path",
      {
        "d": "M8.2 18.2H15.8M8.2 20H13.4",
        "stroke": "currentColor",
        "strokeWidth": "0.7"
      }
    ]
  ]);

export const Camera2MonoIcon = crear('Camera2', [
    [
      "path",
      {
        "d": "M14.5 4h-5L7 7H4a2 2 0 0 0-2 2v9a2 2 0 0 0 2 2h16a2 2 0 0 0 2-2V9a2 2 0 0 0-2-2h-3l-2.5-3z"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "13",
        "r": "3"
      }
    ]
  ]);

export const OcurrenciasMonoIcon = crear('Ocurrencias', [
    [
      "path",
      {
        "d": "M15.5 3H5a2 2 0 0 0-2 2v14a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2V8.5L15.5 3Z"
      }
    ],
    [
      "path",
      {
        "d": "M15 3v6h6"
      }
    ],
    [
      "path",
      {
        "d": "M7 13h8"
      }
    ],
    [
      "path",
      {
        "d": "M7 17h5"
      }
    ]
  ]);

export const PedidoImportacionMonoIcon = crear('PedidoImportacion', [
    [
      "path",
      {
        "d": "M15 3h4a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2h-4"
      }
    ],
    [
      "path",
      {
        "d": "m10 17 5-5-5-5"
      }
    ],
    [
      "path",
      {
        "d": "M15 12H3"
      }
    ]
  ]);

export const PlanillaOficialMonoIcon = crear('PlanillaOficial', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "8",
        "r": "3"
      }
    ],
    [
      "path",
      {
        "d": "M6.5 21v-2a4 4 0 0 1 4-4h3a4 4 0 0 1 4 4v2"
      }
    ],
    [
      "circle",
      {
        "cx": "5",
        "cy": "11",
        "r": "2.2"
      }
    ],
    [
      "circle",
      {
        "cx": "19",
        "cy": "11",
        "r": "2.2"
      }
    ],
    [
      "path",
      {
        "d": "M2 19v-1a3 3 0 0 1 3-3"
      }
    ],
    [
      "path",
      {
        "d": "M22 19v-1a3 3 0 0 0-3-3"
      }
    ]
  ]);

export const PlanillasMonoIcon = crear('Planillas', [
    [
      "path",
      {
        "d": "M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2"
      }
    ],
    [
      "circle",
      {
        "cx": "9",
        "cy": "7",
        "r": "4"
      }
    ],
    [
      "path",
      {
        "d": "M22 21v-2a4 4 0 0 0-3-3.87"
      }
    ],
    [
      "path",
      {
        "d": "M16 3.13a4 4 0 0 1 0 7.75"
      }
    ]
  ]);

export const PlanillasSueldosMonoIcon = crear('PlanillasSueldos', [
    [
      "rect",
      {
        "x": "4",
        "y": "3",
        "width": "16",
        "height": "18",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M4 8h16"
      }
    ],
    [
      "path",
      {
        "d": "M8 12h8"
      }
    ],
    [
      "path",
      {
        "d": "M8 16h5"
      }
    ]
  ]);

export const PlantillasMonoIcon = crear('Plantillas', [
    [
      "rect",
      {
        "x": "8",
        "y": "8",
        "width": "14",
        "height": "14",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M4 16c-1.1 0-2-.9-2-2V4c0-1.1.9-2 2-2h10c1.1 0 2 .9 2 2"
      }
    ]
  ]);

export const TransferenciaInternaMonoIcon = crear('TransferenciaInterna', [
    [
      "rect",
      {
        "x": "3",
        "y": "11",
        "width": "18",
        "height": "10",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M12 2v8"
      }
    ],
    [
      "path",
      {
        "d": "m8 6 4 4 4-4"
      }
    ],
    [
      "path",
      {
        "d": "M10 15h4"
      }
    ]
  ]);

export const UbicacionMonoIcon = crear('Ubicacion', [
    [
      "path",
      {
        "d": "M12 17v5"
      }
    ],
    [
      "path",
      {
        "d": "M9 10.76a2 2 0 0 1-1.11 1.79l-1.78.9A2 2 0 0 0 5 15.24V16a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1v-.76a2 2 0 0 0-1.11-1.79l-1.78-.9A2 2 0 0 1 15 10.76V7a1 1 0 0 1 1-1 2 2 0 0 0 0-4H8a2 2 0 0 0 0 4 1 1 0 0 1 1 1z"
      }
    ]
  ]);

export const UserMonoIcon = crear('User', [
    [
      "path",
      {
        "d": "M19 21v-2a4 4 0 0 0-4-4H9a4 4 0 0 0-4 4v2"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "7",
        "r": "4"
      }
    ]
  ]);

export const UsersMonoIcon = crear('Users', [
    [
      "path",
      {
        "d": "M18 21a8 8 0 0 0-16 0"
      }
    ],
    [
      "circle",
      {
        "cx": "10",
        "cy": "8",
        "r": "5"
      }
    ],
    [
      "path",
      {
        "d": "M22 20c0-3.37-2-6.5-4-8a5 5 0 0 0-.45-8.3"
      }
    ]
  ]);

export const ValesMaterialMonoIcon = crear('ValesMaterial', [
    [
      "path",
      {
        "d": "M14.7 6.3a1 1 0 0 0 0 1.4l1.6 1.6a1 1 0 0 0 1.4 0l3.77-3.77a6 6 0 0 1-7.94 7.94l-6.91 6.91a2.12 2.12 0 0 1-3-3l6.91-6.91a6 6 0 0 1 7.94-7.94l-3.76 3.76z"
      }
    ],
    [
      "path",
      {
        "d": "m3 3 6 6"
      }
    ]
  ]);

export const WorkersMonoIcon = crear('Workers', [
    [
      "path",
      {
        "d": "M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2"
      }
    ],
    [
      "circle",
      {
        "cx": "9",
        "cy": "7",
        "r": "4"
      }
    ],
    [
      "path",
      {
        "d": "M22 21v-2a4 4 0 0 0-3-3.87"
      }
    ],
    [
      "path",
      {
        "d": "M16 3.13a4 4 0 0 1 0 7.75"
      }
    ]
  ]);

export const VentasMonoIcon = crear('Ventas', [
    [
      "path",
      {
        "d": "m11 17 2 2a1 1 0 1 0 3-3"
      }
    ],
    [
      "path",
      {
        "d": "m14 14 2.5 2.5a1 1 0 1 0 3-3l-3.88-3.88a3 3 0 0 0-4.24 0l-.88.88a1 1 0 1 1-3-3l2.81-2.81a5.79 5.79 0 0 1 7.06-.87l.47.28a2 2 0 0 0 1.42.25L21 4"
      }
    ],
    [
      "path",
      {
        "d": "m21 3 1 11h-2"
      }
    ],
    [
      "path",
      {
        "d": "M3 3 2 14l6.5 6.5a1 1 0 1 0 3-3"
      }
    ],
    [
      "path",
      {
        "d": "M3 4h8"
      }
    ]
  ]);

export const SortMonoIcon = crear('Sort', [
    [
      "path",
      {
        "d": "m3 16 4 4 4-4"
      }
    ],
    [
      "path",
      {
        "d": "M7 20V4"
      }
    ],
    [
      "path",
      {
        "d": "M20 8h-5"
      }
    ],
    [
      "path",
      {
        "d": "M15 10V6.5a2.5 2.5 0 0 1 5 0V10"
      }
    ],
    [
      "path",
      {
        "d": "M15 14h5l-5 6h5"
      }
    ]
  ]);

export const EditarDocMonoIcon = crear('EditarDoc', [
    [
      "path",
      {
        "d": "M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7z"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4"
      }
    ],
    [
      "path",
      {
        "d": "M8 11h4M8 15h2"
      }
    ],
    [
      "path",
      {
        "d": "m14 21 1-3 5-5 2 2-5 5z"
      }
    ]
  ]);

export const BlocNotasMonoIcon = crear('BlocNotas', [
    [
      "rect",
      {
        "x": "5",
        "y": "2",
        "width": "15",
        "height": "7",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M9 2v7"
      }
    ],
    [
      "rect",
      {
        "x": "3",
        "y": "9",
        "width": "16",
        "height": "6",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M7 9v6"
      }
    ],
    [
      "rect",
      {
        "x": "5",
        "y": "15",
        "width": "15",
        "height": "7",
        "rx": "1"
      }
    ],
    [
      "path",
      {
        "d": "M9 15v7"
      }
    ]
  ]);

export const RelojAvisoMonoIcon = crear('RelojAviso', [
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "9.8",
        "stroke": "currentColor",
        "strokeWidth": "1.4"
      }
    ],
    [
      "circle",
      {
        "cx": "12",
        "cy": "12",
        "r": "8.2",
        "stroke": "currentColor",
        "strokeWidth": "0.7"
      }
    ],
    [
      "path",
      {
        "d": "M12 12 L9.6 7.4 L14.6 9.8Z",
        "stroke": "currentColor",
        "strokeWidth": "0.5"
      }
    ],
    [
      "path",
      {
        "d": "M12 12L8.4 8.2M12 12L14.2 17",
        "stroke": "currentColor",
        "strokeWidth": "1.5"
      }
    ],
    [
      "circle",
      {
        "cx": "18.6",
        "cy": "5.4",
        "r": "3",
        "stroke": "currentColor",
        "fillOpacity": "0.7"
      }
    ],
    [
      "circle",
      {
        "cx": "18.6",
        "cy": "5.4",
        "r": "1.5",
        "stroke": "currentColor",
        "fillOpacity": "0.9"
      }
    ]
  ]);

export const ModelosMonoIcon = crear('Modelos', [
    [
      "rect",
      {
        "x": "5",
        "y": "2",
        "width": "14",
        "height": "20",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M9 2v8l2-1.5 2 1.5V2"
      }
    ]
  ]);

export const PlanTelefonicoMonoIcon = crear('PlanTelefonico', [
    [
      "path",
      {
        "d": "M7.9 20A9 9 0 1 0 4 16.1L2 22Z"
      }
    ],
    [
      "path",
      {
        "d": "M8.5 8.5c.4 2.6 3 5.2 5.6 5.6l1.4-1.4-2-1-1 .8c-1-.5-1.9-1.4-2.4-2.4l.8-1-1-2z"
      }
    ]
  ]);

export const TaxiMonoIcon = crear('Taxi', [
    [
      "path",
      {
        "d": "M19 17h2c.6 0 1-.4 1-1v-3c0-.9-.7-1.7-1.5-1.9C18.7 10.6 16 10 16 10s-1.3-1.4-2.2-2.3c-.5-.4-1.1-.7-1.8-.7H5c-.6 0-1.1.4-1.4.9l-1.4 2.9A3.7 3.7 0 0 0 2 12v4c0 .6.4 1 1 1h2"
      }
    ],
    [
      "circle",
      {
        "cx": "7",
        "cy": "17",
        "r": "2"
      }
    ],
    [
      "path",
      {
        "d": "M9 17h6"
      }
    ],
    [
      "circle",
      {
        "cx": "17",
        "cy": "17",
        "r": "2"
      }
    ]
  ]);

export const TesAsientosMonoIcon = crear('TesAsientos', [
    [
      "rect",
      {
        "x": "4",
        "y": "2",
        "width": "16",
        "height": "20",
        "rx": "2"
      }
    ],
    [
      "path",
      {
        "d": "M8 6h8"
      }
    ],
    [
      "path",
      {
        "d": "M16 14v4"
      }
    ],
    [
      "path",
      {
        "d": "M16 10h.01"
      }
    ],
    [
      "path",
      {
        "d": "M12 10h.01"
      }
    ],
    [
      "path",
      {
        "d": "M8 10h.01"
      }
    ],
    [
      "path",
      {
        "d": "M12 14h.01"
      }
    ],
    [
      "path",
      {
        "d": "M8 14h.01"
      }
    ],
    [
      "path",
      {
        "d": "M12 18h.01"
      }
    ],
    [
      "path",
      {
        "d": "M8 18h.01"
      }
    ]
  ]);

export const TortaMonoIcon = crear('Torta', [
    [
      "path",
      {
        "d": "M20 21v-8a2 2 0 0 0-2-2H6a2 2 0 0 0-2 2v8"
      }
    ],
    [
      "path",
      {
        "d": "M4 16s.5-1 2-1 2.5 2 4 2 2.5-2 4-2 2.5 2 4 2 2-1 2-1"
      }
    ],
    [
      "path",
      {
        "d": "M2 21h20"
      }
    ],
    [
      "path",
      {
        "d": "M7 8v3"
      }
    ],
    [
      "path",
      {
        "d": "M12 8v3"
      }
    ],
    [
      "path",
      {
        "d": "M17 8v3"
      }
    ],
    [
      "path",
      {
        "d": "M7 4h.01"
      }
    ],
    [
      "path",
      {
        "d": "M12 4h.01"
      }
    ],
    [
      "path",
      {
        "d": "M17 4h.01"
      }
    ]
  ]);

export const TrasladarCostosMonoIcon = crear('TrasladarCostos', [
    [
      "path",
      {
        "d": "M4 22h14a2 2 0 0 0 2-2V7l-5-5H6a2 2 0 0 0-2 2v4"
      }
    ],
    [
      "path",
      {
        "d": "M14 2v4a2 2 0 0 0 2 2h4"
      }
    ],
    [
      "path",
      {
        "d": "M2 15h10"
      }
    ],
    [
      "path",
      {
        "d": "m9 18 3-3-3-3"
      }
    ]
  ]);

export const VacacionesMonoIcon = crear('Vacaciones', [
    [
      "path",
      {
        "d": "M22 12a10.06 10.06 1 0 0-20 0Z"
      }
    ],
    [
      "path",
      {
        "d": "M12 12v8a2 2 0 0 0 4 0"
      }
    ],
    [
      "path",
      {
        "d": "M12 2v1"
      }
    ]
  ]);

export const VarPlanillasMonoIcon = crear('VarPlanillas', [
    [
      "path",
      {
        "d": "M3 3v16a2 2 0 0 0 2 2h16"
      }
    ],
    [
      "path",
      {
        "d": "M18 17V9"
      }
    ],
    [
      "path",
      {
        "d": "M13 17V5"
      }
    ],
    [
      "path",
      {
        "d": "M8 17v-3"
      }
    ]
  ]);

/* ---------- Mapa de todos los 331 iconos ---------- */
export const ICONOS_MONOCROMO = {
  ACTIVITL: ActivitlMonoIcon,
  Abajo: AbajoMonoIcon,
  Aceptar: AceptarMonoIcon,
  Act_2: Act2MonoIcon,
  Act_cuenta: ActCuentaMonoIcon,
  Actualizar: ActualizarMonoIcon,
  Afp: AfpMonoIcon,
  Agregar: AgregarMonoIcon,
  'Anular.png': AnularPngMonoIcon,
  'Anular.jpg': AnularJpgMonoIcon,
  Anular_ico: AnularIcoMonoIcon,
  Aprobar: AprobarMonoIcon,
  Aprobar_Mas: AprobarMasMonoIcon,
  Arriba: ArribaMonoIcon,
  Asig_Horario: AsigHorarioMonoIcon,
  Asig_Jefes: AsigJefesMonoIcon,
  Atend_Prov: AtendProvMonoIcon,
  AtenderMasivo: AtenderMasivoMonoIcon,
  Balance: BalanceMonoIcon,
  Boleta: BoletaMonoIcon,
  Borrar: BorrarMonoIcon,
  'Buscar.ico': BuscarIcoMonoIcon,
  'Buscar.png': BuscarPngMonoIcon,
  COA: CoaMonoIcon,
  CajaBanco: CajaBancoMonoIcon,
  Canjear: CanjearMonoIcon,
  Capacitacion: CapacitacionMonoIcon,
  Cargo_per: CargoPerMonoIcon,
  Cerrar: CerrarMonoIcon,
  Cerrar_Pr: CerrarPrMonoIcon,
  Check: CheckMonoIcon,
  Check1: Check1MonoIcon,
  Compra_Con: CompraConMonoIcon,
  Compras: ComprasMonoIcon,
  Cont_diario: ContDiarioMonoIcon,
  CrdFle04: CrdFle04MonoIcon,
  CrdFle12: CrdFle12MonoIcon,
  CrdFle13: CrdFle13MonoIcon,
  Cronograma_ico: CronogramaIcoMonoIcon,
  Derecha: DerechaMonoIcon,
  DesExcelDsctos: DesExcelDsctosMonoIcon,
  DesExcelIng: DesExcelIngMonoIcon,
  Desc_planilla: DescPlanillaMonoIcon,
  DescargarExcel: DescargarExcelMonoIcon,
  Descuentos_Per: DescuentosPerMonoIcon,
  Deshacer: DeshacerMonoIcon,
  Dolar: DolarMonoIcon,
  Dscto: DsctoMonoIcon,
  Editar: EditarMonoIcon,
  'Eliminar.ico': EliminarIcoMonoIcon,
  'Eliminar.png': EliminarPngMonoIcon,
  Embarque: EmbarqueMonoIcon,
  Empresa: EmpresaMonoIcon,
  Enviar: EnviarMonoIcon,
  Enviar_Pr: EnviarPrMonoIcon,
  Equipos: EquiposMonoIcon,
  Factura: FacturaMonoIcon,
  FacturaGuia: FacturaGuiaMonoIcon,
  FacturarGuias: FacturarGuiasMonoIcon,
  Fecha: FechaMonoIcon,
  FotoNoDisponible: FotoNoDisponibleMonoIcon,
  GRAPH07: Graph07MonoIcon,
  Gears: GearsMonoIcon,
  Generar: GenerarMonoIcon,
  GuiaDevolucion: GuiaDevolucionMonoIcon,
  GuiaRemision: GuiaRemisionMonoIcon,
  Grabar: GrabarMonoIcon,
  HE_icon: HeIconMonoIcon,
  Horarios: HorariosMonoIcon,
  HorsExt: HorsExtMonoIcon,
  Ico_reloj2: IcoReloj2MonoIcon,
  ImgApptRecur: ImgApptRecurMonoIcon,
  ImgSendReceive: ImgSendReceiveMonoIcon,
  ImpExcelIng: ImpExcelIngMonoIcon,
  ImportarExcel: ImportarExcelMonoIcon,
  'Impresora.ico': ImpresoraIcoMonoIcon,
  'Impresora.png': ImpresoraPngMonoIcon,
  Ingresos: IngresosMonoIcon,
  Ingresos_Per: IngresosPerMonoIcon,
  Instruccion: InstruccionMonoIcon,
  Izquierda: IzquierdaMonoIcon,
  Job_Marca: JobMarcaMonoIcon,
  Keys: KeysMonoIcon,
  LectorHuellas: LectorHuellasMonoIcon,
  LibDiario: LibDiarioMonoIcon,
  LibMayor: LibMayorMonoIcon,
  Libro_diario: LibroDiarioMonoIcon,
  Libro_mayor: LibroMayorMonoIcon,
  'Limpiar.png': LimpiarPngMonoIcon,
  'Limpiar.jpg': LimpiarJpgMonoIcon,
  Llamada: LlamadaMonoIcon,
  Lupa: LupaMonoIcon,
  Mail20: Mail20MonoIcon,
  ManoHaciaAbajo: ManoHaciaAbajoMonoIcon,
  Material: MaterialMonoIcon,
  Maximun: MaximunMonoIcon,
  Notas: NotasMonoIcon,
  Nueva_Marcacion: NuevaMarcacionMonoIcon,
  Nuevo_multiple: NuevoMultipleMonoIcon,
  Office: OfficeMonoIcon,
  Pagos: PagosMonoIcon,
  about: AboutMonoIcon,
  act_mail: ActMailMonoIcon,
  actualizarCostos: ActualizarCostosMonoIcon,
  acumulada: AcumuladaMonoIcon,
  acwizard: AcwizardMonoIcon,
  adicionarcontenedor: AdicionarcontenedorMonoIcon,
  admin_48: Admin48MonoIcon,
  ajustarCostos: AjustarCostosMonoIcon,
  almacen: AlmacenMonoIcon,
  apor_planillas: AporPlanillasMonoIcon,
  arbolnavidad: ArbolnavidadMonoIcon,
  area_costo: AreaCostoMonoIcon,
  area_per: AreaPerMonoIcon,
  arqueo_caja: ArqueoCajaMonoIcon,
  b2mining: B2miningMonoIcon,
  bajar_estado: BajarEstadoMonoIcon,
  bancos: BancosMonoIcon,
  books_256: Books256MonoIcon,
  brcase_16: Brcase16MonoIcon,
  brcase_48: Brcase48MonoIcon,
  brocha: BrochaMonoIcon,
  bundle_256: Bundle256MonoIcon,
  calendar: CalendarMonoIcon,
  calendar_copiar: CalendarCopiarMonoIcon,
  calendar_edit: CalendarEditMonoIcon,
  cam_48: Cam48MonoIcon,
  camera: CameraMonoIcon,
  car_256: Car256MonoIcon,
  cartera__2_: Cartera2MonoIcon,
  casa_aeropuerto: CasaAeropuertoMonoIcon,
  cerrarmes: CerrarmesMonoIcon,
  chequeo: ChequeoMonoIcon,
  clases: ClasesMonoIcon,
  cleanCliente: CleanClienteMonoIcon,
  cliente: ClienteMonoIcon,
  comision_ico: ComisionIcoMonoIcon,
  compra: CompraMonoIcon,
  condensados: CondensadosMonoIcon,
  consolidado: ConsolidadoMonoIcon,
  contrato: ContratoMonoIcon,
  corona: CoronaMonoIcon,
  costoVenta: CostoVentaMonoIcon,
  costos: CostosMonoIcon,
  cot_ico: CotIcoMonoIcon,
  cotizacion: CotizacionMonoIcon,
  cotizacionTaller: CotizacionTallerMonoIcon,
  credito: CreditoMonoIcon,
  creditos: CreditosMonoIcon,
  cta_destino: CtaDestinoMonoIcon,
  cta_png: CtaPngMonoIcon,
  ctasPagar: CtasPagarMonoIcon,
  ctas_ctes: CtasCtesMonoIcon,
  ctas_ctes_pend: CtasCtesPendMonoIcon,
  cuadrarCierre: CuadrarCierreMonoIcon,
  cuenta_mas: CuentaMasMonoIcon,
  cuentasCobrar: CuentasCobrarMonoIcon,
  cuentasCorrientes: CuentasCorrientesMonoIcon,
  des_per_mas: DesPerMasMonoIcon,
  despacho: DespachoMonoIcon,
  detalle: DetalleMonoIcon,
  diarioAlmacen: DiarioAlmacenMonoIcon,
  diarioPago: DiarioPagoMonoIcon,
  doc: DocMonoIcon,
  doc_elec_descargar: DocElecDescargarMonoIcon,
  doc_elec_eliminar: DocElecEliminarMonoIcon,
  doc_elec_generar: DocElecGenerarMonoIcon,
  doc_elec_lupa: DocElecLupaMonoIcon,
  documentosEmitidos: DocumentosEmitidosMonoIcon,
  editar2: Editar2MonoIcon,
  equipo_mar: EquipoMarMonoIcon,
  equipo_telefonico: EquipoTelefonicoMonoIcon,
  excel: ExcelMonoIcon,
  excel_ico: ExcelIcoMonoIcon,
  exp_lab: ExpLabMonoIcon,
  fact_darbaja: FactDarbajaMonoIcon,
  fact_descargar: FactDescargarMonoIcon,
  fact_generar: FactGenerarMonoIcon,
  fact_lupa: FactLupaMonoIcon,
  fal_masivo: FalMasivoMonoIcon,
  faltas_ico: FaltasIcoMonoIcon,
  familiares: FamiliaresMonoIcon,
  gasto_real_rubro: GastoRealRubroMonoIcon,
  gasto_real_total: GastoRealTotalMonoIcon,
  gasto_viaje: GastoViajeMonoIcon,
  gastos: GastosMonoIcon,
  generar_mas: GenerarMasMonoIcon,
  generarPeriodo: GenerarPeriodoMonoIcon,
  gerente: GerenteMonoIcon,
  grafica: GraficaMonoIcon,
  he_planillas: HePlanillasMonoIcon,
  help: HelpMonoIcon,
  hrs_equipo: HrsEquipoMonoIcon,
  ico_reloj: IcoRelojMonoIcon,
  ico_reloj3: IcoReloj3MonoIcon,
  ico_reloj4: IcoReloj4MonoIcon,
  idioma: IdiomaMonoIcon,
  imagen_fondo: ImagenFondoMonoIcon,
  img_48: Img48MonoIcon,
  importacion: ImportacionMonoIcon,
  indicadores1: Indicadores1MonoIcon,
  indicadores2: Indicadores2MonoIcon,
  indicadores3: Indicadores3MonoIcon,
  indicadorico2: Indicadorico2MonoIcon,
  indicadorico3: Indicadorico3MonoIcon,
  informatica: InformaticaMonoIcon,
  ing_ctas: IngCtasMonoIcon,
  ing_per_mas: IngPerMasMonoIcon,
  ing_planillas: IngPlanillasMonoIcon,
  interno: InternoMonoIcon,
  inventario: InventarioMonoIcon,
  laptop_16: Laptop16MonoIcon,
  laptop_48: Laptop48MonoIcon,
  letrasAceptadas: LetrasAceptadasMonoIcon,
  librosCont: LibrosContMonoIcon,
  linea_telefonica: LineaTelefonicaMonoIcon,
  linkico: LinkicoMonoIcon,
  liquidacion: LiquidacionMonoIcon,
  login: LoginMonoIcon,
  mantenimiento: MantenimientoMonoIcon,
  marca: MarcaMonoIcon,
  mayor_aux: MayorAuxMonoIcon,
  mercaderia: MercaderiaMonoIcon,
  mesa_control: MesaControlMonoIcon,
  modelo_telefono: ModeloTelefonoMonoIcon,
  motores: MotoresMonoIcon,
  movimiento: MovimientoMonoIcon,
  mp_icon: MpIconMonoIcon,
  observacion: ObservacionMonoIcon,
  ordenesCompra: OrdenesCompraMonoIcon,
  partidas: PartidasMonoIcon,
  precioCore: PrecioCoreMonoIcon,
  pendiente_facturacion: PendienteFacturacionMonoIcon,
  reclamoGarantia: ReclamoGarantiaMonoIcon,
  valeRequisicion: ValeRequisicionMonoIcon,
  registroAuxiliar: RegistroAuxiliarMonoIcon,
  Separar__: SepararPuzzleMonoIcon,
  registroResumen: RegistroResumenMonoIcon,
  registro: RegistroMonoIcon,
  Ticket: TicketMonoIcon,
  Tarifas: TarifasMonoIcon,
  Tab: TabMonoIcon,
  Sugerir: SugerirMonoIcon,
  vehiculo_ico: VehiculoIcoMonoIcon,
  tomaInventario: TomaInventarioMonoIcon,
  vencimientoAcumulada: VencimientoAcumuladaMonoIcon,
  vencimientoDetalle: VencimientoDetalleMonoIcon,
  upload: UploadMonoIcon,
  vencimientos: VencimientosMonoIcon,
  vendedor: VendedorMonoIcon,
  stockValorizado: StockValorizadoMonoIcon,
  Tools: ToolsMonoIcon,
  transferencias: TransferenciasMonoIcon,
  rep_personal: RepPersonalMonoIcon,
  rep_Reembolso: RepReembolsoMonoIcon,
  Rep_RegCompras: RepRegComprasMonoIcon,
  Rep_Tardanzas: RepTardanzasMonoIcon,
  Report: ReportMonoIcon,
  resumenGeneral: ResumenGeneralMonoIcon,
  SCDRESPS: ScdrespsMonoIcon,
  Semaforo: SemaforoMonoIcon,
  separar: SepararMonoIcon,
  separar_: SepararAmbosMonoIcon,
  sesion_icon: SesionIconMonoIcon,
  sobregiro: SobregiroMonoIcon,
  Sol_Gastos: SolGastosMonoIcon,
  Solic_Garantia: SolicGarantiaMonoIcon,
  Reordenar: ReordenarMonoIcon,
  Rep_Asistencia: RepAsistenciaMonoIcon,
  QuickPlay: QuickPlayMonoIcon,
  Provisional: ProvisionalMonoIcon,
  proc_cta_dest: ProcCtaDestMonoIcon,
  proc_cierre_mes: ProcCierreMesMonoIcon,
  Rechazar: RechazarMonoIcon,
  Reg_Compras: RegComprasMonoIcon,
  Recalcular: RecalcularMonoIcon,
  PreMarcacion: PreMarcacionMonoIcon,
  Procesar: ProcesarMonoIcon,
  Reembolso: ReembolsoMonoIcon,
  Process: ProcessMonoIcon,
  Processs: ProcessMonoIcon,
  reclamo_garantia: ReclamoGarantiaHojaMonoIcon,
  rechazar3: Rechazar3MonoIcon,
  Regresar: RegresarMonoIcon,
  ProcessJob: ProcessJobMonoIcon,
  ing_planillas2: IngPlanillas2MonoIcon,
  LibDiario2: LibDiario2MonoIcon,
  LibMayor2: LibMayor2MonoIcon,
  linea_telefonica2: LineaTelefonica2MonoIcon,
  mp_icon2: MpIcon2MonoIcon,
  Office2: Office2MonoIcon,
  Afp2: Afp2MonoIcon,
  area_costo2: AreaCosto2MonoIcon,
  Cerrar_Pr2: CerrarPr2MonoIcon,
  ctas_ctes2: CtasCtes2MonoIcon,
  HE_icon2: HeIcon2MonoIcon,
  HorsExt2: HorsExt2MonoIcon,
  hrs_equipo2: HrsEquipo2MonoIcon,
  ico_reloj2: IcoReloj222MonoIcon,
  Ico_reloj22: IcoReloj22MonoIcon,
  ico_reloj32: IcoReloj32MonoIcon,
  indicadorico22: Indicador2ico2MonoIcon,
  indicadorico32: Indicador2ico3MonoIcon,
  'Impresora2.ico': Impresora2IcoMonoIcon,
  'Impresora2.png': Impresora2PngMonoIcon,
  camera2: Camera2MonoIcon,
  ocurrencias: OcurrenciasMonoIcon,
  pedidoImportacion: PedidoImportacionMonoIcon,
  planilla_oficial: PlanillaOficialMonoIcon,
  planillas: PlanillasMonoIcon,
  Planillas_Sueldos: PlanillasSueldosMonoIcon,
  plantillas: PlantillasMonoIcon,
  transferenciaInterna: TransferenciaInternaMonoIcon,
  Ubicacion: UbicacionMonoIcon,
  User: UserMonoIcon,
  users: UsersMonoIcon,
  valesMaterial: ValesMaterialMonoIcon,
  workers: WorkersMonoIcon,
  ventas: VentasMonoIcon,
  Sort: SortMonoIcon,
  editar_doc: EditarDocMonoIcon,
  Bloc_Notas: BlocNotasMonoIcon,
  Reloj_Aviso: RelojAvisoMonoIcon,
  modelos: ModelosMonoIcon,
  plan_telefonico: PlanTelefonicoMonoIcon,
  Taxi: TaxiMonoIcon,
  tes_asientos: TesAsientosMonoIcon,
  torta: TortaMonoIcon,
  trasladarCostos: TrasladarCostosMonoIcon,
  vacaciones: VacacionesMonoIcon,
  var_planillas: VarPlanillasMonoIcon,
} as const;

export type NombreIconoMonocromo = keyof typeof ICONOS_MONOCROMO;