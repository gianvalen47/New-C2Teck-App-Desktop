import { createFileRoute, Link } from "@tanstack/react-router";
import { useState, useRef, useEffect, useLayoutEffect, FormEvent } from "react";
import { toast } from "sonner";
import { useDesktopMode } from "@/hooks/use-desktop";
import { createPortal } from "react-dom";
import { WindowsProvider, useWindows} from "@/context/WindowsContext";
import { Workspace, renderWindow } from "@/features/escritorio/windows";
import { Glyph } from "@/features/escritorio/glyphs";
import systeckIcon from "@/assets/Systeck.ico";
import {
  Minus, Square, X, ChevronDown, Circle, ArrowLeft,
  FileText, ShoppingBag, Users, ClipboardList, Search, BarChart3,
  Tag, Tags, Percent, Factory, Layers, DollarSign, Package,
  Contact, Briefcase, MonitorSmartphone, Cpu, ListOrdered, ScanLine,
  FileEdit, FilePlus, FileCheck, FileSearch, Receipt, Truck,
  Wallet, ScrollText, HandCoins, Boxes, ClipboardCheck, Coins,
  Warehouse, CheckCircle2, Wrench, ClipboardEdit, ArrowRightLeft, ShoppingCart,
  XCircle, Box, Sliders, MapPin, Calendar, LayoutGrid, Archive, ArrowLeftRight,
  FileMinus, RefreshCw, PackageCheck, PackageOpen, PackageX,
  UserCheck, Mail, FileSpreadsheet, BookOpen, Banknote, CalendarDays,
  RefreshCcw, ClipboardX, BadgeCheck, FileClock, UserCog, StickyNote, UserSearch,
  Plane, Ship, Import, Send,
  Calculator, Lock, Move, RotateCw, Settings, FileBarChart, BookMarked, TrendingUp, AlertTriangle,
  BarChart2, PieChart, LineChart, CreditCard, Database, FolderOpen,
  Car, Award, Clock, FileSignature, Timer,
  Building2, UserPlus, UserMinus, CalendarCheck, AlarmClock, GraduationCap, Gift, ClipboardType,
  Radio, Route as RouteIcon, Navigation,
  BookText, ScrollText as Scroll, Building, ArrowDownUp, Landmark, ArrowUpDown, RefreshCcwDot,
  FileDown, PiggyBank, BookCheck, FileWarning,
  Smartphone, Signal, Phone, Target, IdCard, LogOut, Info, KeyRound, Handshake,
  Eye, EyeOff, Key, User, Zap,
} from "lucide-react";

export const Route = createFileRoute("/escritorio")({
  head: () => ({
    meta: [
      { title: "Systeck (Versión 10.6.30) — C2TECK S.A.C." },
      { name: "description", content: "Vista previa de la aplicación de escritorio Systeck de C2Teck S.A.C." },
    ],
  }),
  component: DesktopApp,
});

const TABS = [
  "Ventas", "Almacenes", "Créditos", "Importaciones", "Costos", "Gerencia",
  "Servicios", "Compras", "Personal", "Rondas", "Contabilidad", "Telefonía",
  "CRM", "Activos", "Tablas", "Logueo", "Administración", "Ayuda",
];

type MenuItem = { icon: any; label: string };
type MenuSection = { title: string; items: MenuItem[] };
type RibbonBtn = { icon: any; label: string; big?: boolean; dropdown?: boolean; menu?: MenuSection[]; openLabel?: string  };
type RibbonGroup = { title?: string; items: RibbonBtn[] };

const RIBBONS: Record<string, RibbonGroup[]> = {
  Ventas: [
    {
      title: "",
      items: [
        { icon: FileText, label: "Documentos", big: true, dropdown: true, menu: [
          { title: "Documentos", items: [
            { icon: Truck, label: "Guía Remisión" },
            { icon: Receipt, label: "Factura" },
            { icon: StickyNote, label: "Notas" },
            { icon: FileMinus, label: "Guía Devolución" },
            { icon: FileText, label: "Boleta" },
            { icon: FileSpreadsheet, label: "Resumen de Boletas" },
          ]},
        ]},
        { icon: ShoppingBag, label: "Pre y Post\nVenta", big: true, dropdown: true, menu: [
          { title: "Pre y Post Venta", items: [
            { icon: FileEdit, label: "Cotizaciones" },
            { icon: Award, label: "Reclamo Garantía" },
            { icon: ArrowRightLeft, label: "Separar Orden" },
            { icon: ShoppingCart, label: "Ordenes Compra" },
            { icon: UserCog, label: "Actualizar Vendedor" },
            { icon: Mail, label: "Enviar Correos" },
          ]},
        ]},
        { icon: Users, label: "Clientes", big: true, dropdown: true, menu: [
          { title: "Clientes", items: [
            { icon: Contact, label: "Cartera" },
          ]},
        ]},
        { icon: ClipboardList, label: "Requisiciones", big: true, dropdown: true, menu: [
          { title: "Requisiciones", items: [
            { icon: Truck, label: "Despacho" },
          ]},
        ]},
        { icon: Search, label: "Consultas", big: true, dropdown: true, menu: [
          { title: "Consultas", items: [
            { icon: DollarSign, label: "Precios" },
            { icon: FileText, label: "Documentos" },
          ]},
        ]},
        { icon: BarChart3, label: "Indicadores", big: true, dropdown: true, menu: [
          { title: "Indicadores", items: [
            { icon: LayoutGrid, label: "Tablero" },
          ]},
        ]},
      ],
    },
    {
      title: "Precios",
      items: [
        { icon: Tag, label: "Precios Cliente" },
        { icon: Percent, label: "Precio Oferta" },
        { icon: Factory, label: "Factores Rubros" },
        { icon: Layers, label: "Precio Lista" },
        { icon: DollarSign, label: "Precio Fabricantes" },
      ],
    },
    {
      title: "Reportes",
      items: [
        { icon: FilePlus, label: "Registro de Venta", dropdown: true, menu: [
          { title: "Registro de Venta", items: [
            { icon: FileText, label: "Registro" },
            { icon: FileSpreadsheet, label: "Registro Auxiliar" },
            { icon: FileCheck, label: "Resumen Registro" },
          ]},
        ] },
        { icon: FileCheck, label: "Acumulada" },
        { icon: FileSearch, label: "Cotizaciones" },
        { icon: Users, label: "Mensuales x Cliente" },
        { icon: Receipt, label: "Reclamos" },
        { icon: Package, label: "Consignaciones" },
        { icon: Wallet, label: "Presupuesto Venta" },
        { icon: FileEdit, label: "Detalle" },
        { icon: ScrollText, label: "G/R Pendiente" },
        { icon: HandCoins, label: "Vale Requisición" },
        { icon: Percent, label: "Detalle Descuento" },
        { icon: Boxes, label: "Órdenes Compra" },
        { icon: Truck, label: "Guías Remisión" },
        { icon: Coins, label: "Comisiones" },
      ],
    },
  ],

  Almacenes: [
    {
      title: "Almacén",
      items: [
        { icon: PackageOpen, label: "Doc.Ingresos" },
        { icon: PackageX, label: "Doc.Salidas" },
        { icon: CheckCircle2, label: "Chequeo F/I" },
        { icon: ClipboardCheck, label: "T / I" },
        { icon: Wrench, label: "M T I" },
        { icon: HandCoins, label: "Vales" },
        { icon: ClipboardEdit, label: "Atender OT" },
        { icon: Truck, label: "Despachos" },
        { icon: UserSearch, label: "Datos Despacho Clientes" },
      ],
    },
    {
      title: "Motores",
      items: [
        { icon: ArrowRightLeft, label: "Transferencias" },
        { icon: ShoppingCart, label: "Compras" },
      ],
    },
    {
      title: "Tránsito",
      items: [
        { icon: FileText, label: "Documentos" },
        { icon: XCircle, label: "Anulación en Consulta" },
      ],
    },
    {
      title: "Mantenimiento",
      items: [
        { icon: Box, label: "Productos" },
        { icon: DollarSign, label: "Liqui. Gastos" },
        { icon: Sliders, label: "Act. Min Max" },
        { icon: MapPin, label: "Ubicaciones" },
      ],
    },
    {
      title: "Consultas",
      items: [
        { icon: Tag, label: "Tarjetas" },
        { icon: FileText, label: "Documentos" },
      ],
    },
    {
      title: "Indicadores",
      items: [
        { icon: Calendar, label: "Calendario" },
        { icon: LayoutGrid, label: "Tablero" },
        { icon: RefreshCw, label: "Procesar Cobertura" },
      ],
    },
    {
      title: "Reportes",
      items: [
        { icon: Archive, label: "Inventario" },
        { icon: ArrowLeftRight, label: "Movimientos" },
        { icon: FileText, label: "Documentos" },
        { icon: FileMinus, label: "Sin Movimiento" },
        { icon: ClipboardCheck, label: "Toma de Inventario" },
        { icon: HandCoins, label: "Vale Materiales" },
        { icon: PackageCheck, label: "Inv. Perm. Valorizado" },
        { icon: ArrowRightLeft, label: "Transferencias" },
      ],
    },
  ],

  "Créditos": [
    {
      title: "Documentos",
      items: [
        { icon: HandCoins, label: "Ctas x Cobrar" },
        { icon: ScrollText, label: "Letras" },
        { icon: FileSpreadsheet, label: "Planillas" },
      ],
    },
    {
      title: "Aprobaciones",
      items: [
        { icon: BadgeCheck, label: "Créditos" },
        { icon: FileEdit, label: "Cotiz. Taller" },
        { icon: UserCheck, label: "Anticipos" },
        { icon: Mail, label: "Recepcion Doc." },
      ],
    },
    {
      title: "Mantenimiento",
      items: [
        { icon: Percent, label: "Factores y Descuentos" },
        { icon: Banknote, label: "Saldo Bancos" },
        { icon: UserSearch, label: "Visitas Cobrador" },
        { icon: RefreshCw, label: "Procesar Job" },
        { icon: Truck, label: "Vincular G/R" },
        { icon: CalendarDays, label: "Feriados" },
        { icon: DollarSign, label: "Tipo Cambio Ventas" },
        { icon: RefreshCcw, label: "Renueva Tipo Cambio" },
        { icon: Wrench, label: "Mantenimiento Tipo de Cambio" },
        { icon: Lock, label: "Permiso Usuario" },
      ],
    },
    {
      title: "Consultas",
      items: [
        { icon: BookOpen, label: "Consultas", big: true, dropdown: true, menu: [
          { title: "Consultas", items: [
            { icon: HandCoins, label: "Ctas. x Cobrar" },
            { icon: IdCard, label: "Tarjeta Cliente" },
            { icon: FileClock, label: "Vencimientos" },
          ]},
        ]},
      ],
    },
    {
      title: "Reportes",
      items: [
        { icon: HandCoins, label: "Cuentas Corrientes" },
        { icon: BookText, label: "Diario de Pagos" },
        { icon: BadgeCheck, label: "Letras Aceptadas" },
        { icon: FileText, label: "Documentos Emitidos" },
        { icon: FileSpreadsheet, label: "Planillas" },
        { icon: FileEdit, label: "Notas Debito/Credito" },
        { icon: UserSearch, label: "Visita Cobrador" },
        { icon: FileClock, label: "Vencimientos", dropdown: true, menu: [
          { title: "Vencimientos", items: [
            { icon: FileEdit, label: "Detalle Vencimientos" },
            { icon: FileCheck, label: "Acumulado Vencimientos" },
          ]},
        ] },
        { icon: Users, label: "Clientes" },
      ],
    },
  ],

  Importaciones: [
    {
      title: "Importaciones",
      items: [
        { icon: FileText, label: "Documentos" },
        { icon: Ship, label: "Embarque" },
      ],
    },
    {
      title: "Pedidos",
      items: [
        { icon: Plane, label: "Orden Importación" },
        { icon: Send, label: "Internos" },
      ],
    },
    {
      title: "Reportes",
      items: [
        { icon: Import, label: "Orden de Importación" },
        { icon: Ship, label: "Embarques de Importación" },
        { icon: ClipboardList, label: "Pedido Interno" },
      ],
    },
  ],

  Costos: [
    {
      title: "Importaciones",
      items: [
        { icon: Calculator, label: "Valorizar F/I", big: true },
      ],
    },
    {
      title: "Procesos",
      items: [
        { icon: RotateCw, label: "Recalcular" },
        { icon: Wrench, label: "Ajustar Costos" },
        { icon: Lock, label: "Cerrar Mes" },
        { icon: FolderOpen, label: "Consolidado" },
        { icon: Move, label: "Trasladar Costos" },
        { icon: CalendarDays, label: "Generar Periodo" },
        { icon: RefreshCw, label: "Inv. Rotativo" },
      ],
    },
    {
      title: "Documentos",
      items: [
        { icon: Settings, label: "Actualizar Costos" },
      ],
    },
    {
      title: "Reportes",
      items: [
        { icon: Plane, label: "Importaciones" },
        { icon: BookOpen, label: "Diario de Almacen" },
        { icon: DollarSign, label: "Stock Valorizado" },
        { icon: FileCheck, label: "Cuadrar Cierre" },
        { icon: BookMarked, label: "Kardex" },
        { icon: TrendingUp, label: "Costo de Venta" },
        { icon: FileBarChart, label: "Condensados" },
        { icon: Wrench, label: "Motores" },
        { icon: FileSpreadsheet, label: "Resumen General" },
        { icon: AlertTriangle, label: "Sobregiro" },
        { icon: BarChart3, label: "GMROI" },
      ],
    },
  ],

  Gerencia: [
    {
      title: "Reportes",
      items: [
        { icon: DollarSign, label: "000 - Ventas" },
        { icon: Plane, label: "010 - Importaciones" },
        { icon: Package, label: "020 - Inventario y Costos" },
        { icon: BookText, label: "030 - Contabilidad" },
        { icon: HandCoins, label: "040 - Creditos y Cobranzas" },
        { icon: BarChart2, label: "Datos para Indicadores" },
        { icon: CreditCard, label: "Tarjeta" },
        { icon: FolderOpen, label: "Contenedor Reportes" },
        { icon: PieChart, label: "Estados Financieros" },
      ],
    },
  ],

  Servicios: [
    {
      title: "Almacen",
      items: [
        { icon: ShoppingCart, label: "Pedir Repuestos" },
      ],
    },
    {
      title: "Ventas",
      items: [
        { icon: FileEdit, label: "Cotizacion" },
      ],
    },
    {
      items: [
        { icon: Wrench, label: "Orden de\nTrabajo", big: true, dropdown: true, menu: [
          { title: "Orden de Trabajo", items: [
            { icon: FileSignature, label: "Solicitud OT" },
            { icon: Wrench, label: "OT" },
            { icon: UserCheck, label: "Marcaciones" },
            { icon: DollarSign, label: "Gastos Reales" },
            { icon: Clock, label: "Pre Marcación" },
            { icon: BadgeCheck, label: "Marcar OT" },
          ]},
        ]},
        { icon: Award, label: "Garantia", big: true, dropdown: true, menu: [
          { title: "Garantia", items: [
            { icon: Wrench, label: "Orden Reparación" },
            { icon: FileWarning, label: "Reclamo Cliente" },
          ]},
        ]},
        { icon: Car, label: "Control\nVehicular", big: true, dropdown: true, menu: [
          { title: "Control Vehicular", items: [
            { icon: Truck, label: "Kilometraje" },
          ]},
        ]},
        { icon: Settings, label: "Mantenimiento", big: true, dropdown: true, menu: [
          { title: "Mantenimiento", items: [
            { icon: UserCog, label: "Oficina Usuario" },
          ]},
        ]},
        { icon: Search, label: "Consultas", big: true, dropdown: true, menu: [
          { title: "Consultas", items: [
            { icon: Wrench, label: "OT" },
            { icon: UserCheck, label: "Marcaciones" },
            { icon: DollarSign, label: "Gastos Reales" },
          ]},
        ]},
        { icon: BarChart3, label: "Indicadores", big: true, dropdown: true, menu: [
          { title: "Indicadores", items: [
            { icon: ClipboardCheck, label: "Actividades" },
            { icon: CalendarDays, label: "Programacion" },
            { icon: FileSpreadsheet, label: "Plantilla" },
            { icon: LayoutGrid, label: "Tablero" },
            { icon: TrendingUp, label: "Productividad" },
          ]},
        ]},
        { icon: LineChart, label: "Proyección", big: true, dropdown: true, menu: [
          { title: "Proyección", items: [
            { icon: ArrowLeftRight, label: "Movimiento Repuestos" },
            { icon: Clock, label: "Horas Escalon" },
            { icon: Timer, label: "Horas de Trabajo" },
            { icon: DollarSign, label: "Gastos Detalle" },
            { icon: Factory, label: "Horas Motor" },
            { icon: FileSearch, label: "Seguimiento" },
            { icon: Send, label: "Generar Pedido" },
            { icon: Wrench, label: "Motores" },
            { icon: Package, label: "Repuestos" },
          ]},
        ]},
      ],
    },
    {
      title: "Reportes",
      items: [
        { icon: ArrowLeftRight, label: "Movimiento Repuestos" },
        { icon: Clock, label: "Horas Escalon" },
        { icon: Timer, label: "Horas de Trabajo" },
        { icon: DollarSign, label: "Gastos Detallado" },
        { icon: DollarSign, label: "Gastos Por Rubros" },
        { icon: FileClock, label: "Pendiente Facturacion" },
        { icon: Award, label: "Liquidación x Garantia" },
        { icon: Clock, label: "Tiempo Reparación" },
        { icon: Award, label: "Solicitud Garantia" },
        { icon: FileEdit, label: "Cotizaciones" },
        { icon: FileSignature, label: "Solicitud OT" },
        { icon: Wrench, label: "OT" },
        { icon: AlarmClock, label: "Horas Muertas" },
        { icon: LineChart, label: "Proyección", dropdown: true },
      ],
    },
  ],

  Compras: [
    {
      title: "Compras",
      items: [
        { icon: ClipboardList, label: "Solicitud de Compra" },
        { icon: ShoppingCart, label: "Orden de Compra" },
        { icon: FileEdit, label: "Cotizaciones" },
      ],
    },
    {
      title: "Control",
      items: [
        { icon: FileSignature, label: "Solicitud Gasto" },
        { icon: FileSpreadsheet, label: "Planilla Viatico" },
        { icon: Plane, label: "Tarifa Gasto Viaje" },
        { icon: Car, label: "Tarifa Taxis Casa" },
        { icon: Car, label: "Tarifas Taxi Destino" },
        { icon: HandCoins, label: "Cuentas x Pagar" },
      ],
    },
    {
      title: "Consultas",
      items: [
        { icon: DollarSign, label: "Compras y/o Gastos" },
      ],
    },
    {
      title: "Reportes",
      items: [
        { icon: Boxes, label: "Ordenes Compra" },
        { icon: FileSignature, label: "Solicitud Gastos" },
        { icon: FileClock, label: "Vencimientos" },
        { icon: HandCoins, label: "Cuentas x Pagar" },
        { icon: Coins, label: "Pagos Cuentas x Pagar" },
        { icon: Building2, label: "Cuentas x Pagar Por Unidad" },
      ],
    },
  ],

  Personal: [
    {
      items: [
        { icon: UserSearch, label: "Informacion", big: true, dropdown: true, menu: [
          { title: "Información", items: [
            { icon: IdCard, label: "Ficha General" },
            { icon: CalendarDays, label: "Vacaciones" },
            { icon: GraduationCap, label: "Capacitaciones" },
            { icon: ClipboardCheck, label: "Evaluaciones" },
          ]},
        ]},
        { icon: FileSpreadsheet, label: "Planilla\nSueldos", big: true, dropdown: true, menu: [
          { title: "Planilla Sueldos", items: [
            { icon: FileBarChart, label: "Quinta Categoria" },
          ]},
        ]},
      ],
    },
    {
      title: "Asignaciones",
      items: [
        { icon: AlertTriangle, label: "Faltas" },
        { icon: UserCheck, label: "Marcacion" },
        { icon: UserPlus, label: "Asigna H. Extra" },
        { icon: CalendarDays, label: "Horarios" },
        { icon: Clock, label: "Horas Extras" },
        { icon: UserPlus, label: "Ingresos" },
        { icon: Percent, label: "Descuentos" },
        { icon: UserCog, label: "Jefe Area" },
        { icon: UserCheck, label: "Recursos" },
        { icon: CalendarCheck, label: "Cronograma Mina" },
        { icon: Radio, label: "Marcación Online" },
      ],
    },
    {
      title: "Comunicaciones",
      items: [
        { icon: MonitorSmartphone, label: "Comunicaciones", big: true, dropdown: true, menu: [
          { title: "Comunicaciones", items: [
            { icon: ScanLine, label: "Admin. Lector" },
            { icon: RefreshCcw, label: "Procesar Marcas" },
          ]},
        ]},
      ],
    },
    {
      title: "Reportes",
      items: [
        { icon: FileSpreadsheet, label: "Planilla Sueldos" },
        { icon: UserCheck, label: "Asistencia" },
        { icon: UserPlus, label: "Asig. H. Extra" },
        { icon: Clock, label: "Horas Extras" },
        { icon: AlarmClock, label: "Tardanzas" },
        { icon: AlertTriangle, label: "Faltas" },
        { icon: UserPlus, label: "Ingresos" },
        { icon: Percent, label: "Descuentos" },
        { icon: UserSearch, label: "Recursos" },
        { icon: CalendarDays, label: "Vacaciones" },
        { icon: Users, label: "Personal" },
        { icon: GraduationCap, label: "Capacitaciones" },
        { icon: FileSignature, label: "Contratos" },
        { icon: Gift, label: "Onomasticos" },
        { icon: CalendarCheck, label: "Cronograma Mina" },
        { icon: ClipboardType, label: "Asignación Horario" },
      ],
    },
  ],

  Rondas: [
    {
      title: "Asignacion",
      items: [
        { icon: MapPin, label: "Puntos Control Rutas" },
        { icon: Navigation, label: "Ruteador Rutas" },
        { icon: RouteIcon, label: "Rondas" },
      ],
    },
  ],

  Contabilidad: [
    {
      title: "Tesoreria",
      items: [
        { icon: BookText, label: "Asientos" },
        { icon: ArrowDownUp, label: "Movimiento Bancos" },
      ],
    },
    {
      title: "Compras",
      items: [
        { icon: ClipboardList, label: "Registro Compra" },
        { icon: FileText, label: "Recibo Honorario" },
      ],
    },
    {
      title: "Contabilidad",
      items: [
        { icon: BookOpen, label: "Diario" },
      ],
    },
    {
      title: "Caja Chica",
      items: [
        { icon: Wallet, label: "Provisional" },
        { icon: RefreshCcwDot, label: "Reembolso" },
        { icon: PiggyBank, label: "Arqueo Caja" },
      ],
    },
    {
      title: "Procesos",
      items: [
        { icon: Landmark, label: "Cuenta Destino" },
        { icon: Lock, label: "Cierre Mes" },
        { icon: ArrowUpDown, label: "Dif. Tipo Cambio" },
        { icon: FileDown, label: "Generar TXT Libros" },
        { icon: TrendingUp, label: "Flujo de Caja" },
      ],
    },
    {
      title: "Reportes",
      items: [
        { icon: HandCoins, label: "Ctas x Pagar" },
        { icon: FileClock, label: "Vencimientos" },
        { icon: Coins, label: "Reembolsos" },
        { icon: BookMarked, label: "Libros Oficiales", dropdown: true, menu: [
          { title: "Libros Oficiales", items: [
            { icon: BookText, label: "Libro Diario" },
            { icon: BookOpen, label: "Libro Mayor" },
            { icon: Wallet, label: "Caja y Bancos" },
            { icon: ShoppingCart, label: "Registro de Compras" },
          ]},
        ] },
        { icon: Building, label: "Ctas Ctes" },
        { icon: FileWarning, label: "Ctas Ctes Pendiente" },
        { icon: BookCheck, label: "Mayor Auxiliar" },
        { icon: PieChart, label: "Estado Financiero" },
        { icon: CreditCard, label: "Cheques Girados" },
        { icon: Wallet, label: "Provisionales" },
      ],
    },
  ],
  "Telefonía": [
    {
      title: "Mantenimiento",
      items: [
        { icon: Smartphone, label: "Modelos" },
        { icon: Signal, label: "Planes" },
        { icon: Phone, label: "Equipos" },
      ],
    },
    {
      title: "Asignación",
      items: [
        { icon: RouteIcon, label: "Lineas" },
        { icon: UserPlus, label: "Asigna Persona" },
      ],
    },
  ],
  CRM: [
    {
      title: "Oportunidades",
      items: [
        { icon: Handshake, label: "Oportunidad Negocio" },
        { icon: IdCard, label: "Tarjeta Cliente" },
        { icon: Percent, label: "Cuota Vendedor" },
        { icon: AlertTriangle, label: "Ocurrencias" },
        { icon: MapPin, label: "Visita Clientes" },
      ],
    },
    {
      title: "Reportes",
      items: [
        { icon: Target, label: "Oportunidad Negocio" },
        { icon: MapPin, label: "Visita Clientes" },
      ],
    },
  ],
  Activos: [
    {
      title: "Activos",
      items: [
        { icon: Wrench, label: "Activos Fijos" },
      ],
    },
    {
      title: "Reportes",
      items: [
        { icon: FileSearch, label: "Reporte Activos Fijos" },
      ],
    },
  ],
  Tablas: [
    {
      title: "Ventas",
      items: [
        { icon: Users, label: "Clientes" },
        { icon: CreditCard, label: "Condición de Pago" },
      ],
    },
    {
      title: "Almacenes",
      items: [
        { icon: Package, label: "Productos" },
        { icon: Factory, label: "Tipo Motores" },
        { icon: Layers, label: "Modelos" },
        { icon: Tags, label: "Categorias" },
      ],
    },
    {
      title: "Importaciones",
      items: [
        { icon: Boxes, label: "Partidas" },
        { icon: Tag, label: "Marcas" },
      ],
    },
    {
      title: "Servicios",
      items: [
        { icon: ClipboardList, label: "Plantilla Repuestos" },
        { icon: ClipboardEdit, label: "Plantilla Repuestos Cliente" },
        { icon: MapPin, label: "Ubicacion Servicio" },
        { icon: Car, label: "Vehiculos" },
      ],
    },
    {
      title: "Compras",
      items: [
        { icon: ShoppingCart, label: "Proveedores" },
        { icon: CreditCard, label: "Condición de Pago" },
      ],
    },
    {
      title: "Contabilidad",
      items: [
        { icon: BookOpen, label: "Cuenta Contable" },
        { icon: Landmark, label: "Cuentas Destino" },
        { icon: FileSpreadsheet, label: "Rubro Planilla" },
        { icon: FileBarChart, label: "Rubro Planilla Ctas" },
      ],
    },
    {
      title: "Personal",
      items: [
        { icon: Clock, label: "Horarios" },
        { icon: CalendarCheck, label: "Feriados" },
        { icon: PiggyBank, label: "AFP" },
        { icon: Contact, label: "Cargos" },
        { icon: Building2, label: "Áreas" },
        { icon: AlertTriangle, label: "Motivos Faltas" },
        { icon: ScanLine, label: "Equipo Lector" },
        { icon: Timer, label: "Tipo Hora Extra" },
      ],
    },
    {
      title: "Rondas",
      items: [
        { icon: Navigation, label: "Ruteador" },
        { icon: RouteIcon, label: "Rutas" },
        { icon: Radio, label: "Puntos Control" },
      ],
    },
  ],
  Logueo: [
    {
      title: "Login",
      items: [
        { icon: LogOut, label: "Cerrar Sesion" },
        { icon: KeyRound, label: "Cambiar Contraseña" },
        { icon: Building2, label: "Cambiar Empresa" },
      ],
    },
  ],
  "Administración": [
    {
      title: "Seguridad",
      items: [
        { icon: Users, label: "Usuarios" },
        { icon: UserCog, label: "Perfiles" },
      ],
    },
    {
      title: "Usuarios",
      items: [
        { icon: Circle, label: "Sesiones" },
        { icon: ClipboardCheck, label: "Atender Solicitud" },
      ],
    },
    {
      title: "Reportes",
      items: [
        { icon: BarChart2, label: "Indicadores" },
      ],
    },
    {
      title: "Encuestas",
      items: [
        { icon: ClipboardList, label: "Encuesta" },
        { icon: FileBarChart, label: "Resultado" },
      ],
    },
    {
      title: "Inventario",
      items: [
        { icon: MonitorSmartphone, label: "Asignar Computadora" },
        { icon: Cpu, label: "Computadora" },
      ],
    },
    {
      title: "Llamadas",
      items: [
        { icon: Phone, label: "Llamadas" },
      ],
    },
    {
      title: "Tablas Generales",
      items: [
        { icon: ScanLine, label: "Equipos Marcación Personal" },
        { icon: Building2, label: "Empresas" },
        { icon: ListOrdered, label: "Series Documentos" },
        { icon: MapPin, label: "Locaciones" },
        { icon: Tags, label: "Rubros de Productos" },
        { icon: Sliders, label: "Parametros Locaciones" },
        { icon: FileSpreadsheet, label: "Parametros Planilla Sueldos" },
        { icon: Briefcase, label: "Rubros x Empresa" },
      ],
    },
  ],
  Ayuda: [
    {
      title: "Usuario",
      items: [
        { icon: Mail, label: "Solicitud" },
      ],
    },
    {
      title: "Ayuda",
      items: [
        { icon: FileText, label: "Información Cambios" },
        { icon: Info, label: "Acerca" },
      ],
    },
  ],
};

function normalizeRibbonLabel(label: string) {
  return label.replace(/\s+/g, " ").replace(/\n/g, " ").trim();
}

function collectRibbonLabels(ribbons: Record<string, RibbonGroup[]>) {
  const labels: string[] = [];

  const addLabel = (value?: string) => {
    if (!value) return;
    const normalized = normalizeRibbonLabel(value);
    if (!normalized) return;
    labels.push(normalized);
  };

  const collectMenuSection = (section?: MenuSection[]) => {
    if (!section) return;
    section.forEach((menuSection) => {
      menuSection.items.forEach((menuItem) => addLabel(menuItem.label));
    });
  };

  Object.values(ribbons).forEach((groups) => {
    groups.forEach((group) => {
      group.items.forEach((item) => {
        addLabel(item.label);
        collectMenuSection(item.menu);
      });
    });
  });

  return Array.from(new Set(labels));
}

const ALL_RIBBON_LABELS = collectRibbonLabels(RIBBONS);

function DesktopApp() {
  return (
    <WindowsProvider>
      <DesktopAppInner />
    </WindowsProvider>
  );
}

function DesktopAppInner() {
  const [active, setActive] = useState("Ventas");
  const ribbon = RIBBONS[active] ?? RIBBONS.Ventas;
  const [ribbonMode, setRibbonMode] = useState<"expanded" | "hidden" | "overlay">("expanded");
  const [now, setNow] = useState("");
  const { isDesktop, minimize, maximize, close } = useDesktopMode();
  const { open: openWindow, windows, active: activeWindowId, close: closeWindow, focus: focusWindow } = useWindows();
  const params = typeof window !== "undefined" ? new URLSearchParams(window.location.search) : new URLSearchParams();
  const [recover, setRecover] = useState(false);
  const popupLabel = params.get("popup");
  const loginMode = params.get("login") === "1";
  const [desktopAuthenticated, setDesktopAuthenticated] = useState(!loginMode);
  const [desktopReady, setDesktopReady] = useState(false);
  const [busy, setBusy] = useState(false);
  const [user, setUser] = useState("grios");
  const [pass, setPass] = useState("demo1234");
  const [ribbonMinimized, setRibbonMinimized] = useState(false);
  const [ribbonBelow, setRibbonBelow] = useState(false);
  const [ribbonMenu, setRibbonMenu] = useState<{ x: number; y: number } | null>(null);
  const [fecha, setFecha] = useState(new Date().toISOString().slice(0, 10));
  const [tc, setTc] = useState("3.399");
  const [sucursal, setSucursal] = useState("01 - Sede Central Lima");
  const [showPass, setShowPass] = useState(false);
  const [capsOn, setCapsOn] = useState(false);

  useEffect(() => {
    setNow(new Date().toLocaleDateString("es-PE"));
  }, []);

  useEffect(() => {
    if (typeof window === "undefined") return;
    const desktopWindow = window as Window & { __systeckAllMenuLabels?: string[] };
    desktopWindow.__systeckAllMenuLabels = ALL_RIBBON_LABELS;
    return () => {
      if (desktopWindow.__systeckAllMenuLabels === ALL_RIBBON_LABELS) {
        delete desktopWindow.__systeckAllMenuLabels;
      }
    };
  }, []);

  useEffect(() => {
    setDesktopReady(true);
    if (isDesktop && loginMode) {
      setDesktopAuthenticated(false);
    } else {
      setDesktopAuthenticated(true);
    }
  }, [isDesktop, loginMode]);

  useEffect(() => {
    if (!popupLabel) {
      document.title = "Systeck (Versión 10.6.30) — C2TECK S.A.C.";
    }
  }, [popupLabel]);

  useEffect(() => {
    if (!ribbonMenu) return;
    const close = () => setRibbonMenu(null);
    const onKeyDown = (e: KeyboardEvent) => {
      if (e.key === "Escape") close();
    };
    window.addEventListener("mousedown", close);
    window.addEventListener("keydown", onKeyDown);
    return () => {
      window.removeEventListener("mousedown", close);
      window.removeEventListener("keydown", onKeyDown);
    };
  }, [ribbonMenu]);

  const submit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    setBusy(true);

    setTimeout(() => {
      setBusy(false);
      if (user === "grios" && pass === "demo1234") {
        setDesktopAuthenticated(true);
        toast.success("Bienvenido a Systeck", { description: "Acceso al escritorio habilitado" });
        window.c2teckDesktop?.loginSuccess?.();
        return;
      }
      toast.error("Credenciales inválidas", { description: "Verifica usuario y clave predeterminados" });
    }, 700);
  };

  const inputCls = "h-9 w-full rounded border border-slate-300 bg-white px-3 text-sm text-slate-900 outline-none transition focus:border-slate-500 focus:ring-2 focus:ring-slate-300";

  const openDesktopWindow = (label: string) => {
    // Siempre abrir ventanas simuladas dentro del MDI del escritorio.
    openWindow(label);
  };

  if (popupLabel && isDesktop) {
    return <DesktopPopoutWindow label={popupLabel} onClose={close} />;
  }

  if (loginMode && isDesktop && !desktopAuthenticated) {
    return (
      <DesktopLogin
        busy={busy}
        user={user}
        pass={pass}
        fecha={fecha}
        tc={tc}
        sucursal={sucursal}
        showPass={showPass}
        capsOn={capsOn}
        onSubmit={submit}
        onUserChange={setUser}
        onPassChange={setPass}
        onFechaChange={setFecha}
        onTcChange={setTc}
        onSucursalChange={setSucursal}
        onToggleShowPass={() => setShowPass((v) => !v)}
        onCapsChange={setCapsOn}
      />
    );
  }

  return (

    <div className={[
      "min-h-screen font-sans",
      isDesktop
        ? "bg-[#DDE4EC] p-0 flex items-stretch justify-stretch"
        : "bg-slate-900 p-2 sm:p-6 flex items-center justify-center",
    ].join(" ")}>
      {/* Ventana */}
      <div className={[
        "w-full h-full flex flex-col bg-[#DDE4EC] text-slate-800 overflow-visible",
        isDesktop
          ? "h-screen rounded-none shadow-none border-0"
          : "max-w-[1400px] rounded-lg shadow-2xl border border-slate-700",
      ].join(" ")}>
        {!isDesktop && (
          <div className="relative z-30 h-8 bg-gradient-to-b from-[#3E5B7A] to-[#2A3F55] flex items-center justify-between px-2 text-white text-xs select-none">
            <div className="flex items-center gap-2">
              <div className="h-5 w-5 rounded-sm bg-white/10 grid place-items-center">
                <Circle className="h-3 w-3" />
              </div>
              <span className="opacity-80">Systeck (Versión 10.6.3.0) — C2TECK S.A.C.</span>
            </div>
            <div className="flex items-center">
              <button
                type="button"
                onClick={isDesktop ? minimize : undefined}
                className="h-8 w-11 hover:bg-white/10 grid place-items-center"
              ><Minus className="h-3.5 w-3.5" /></button>
              <button
                type="button"
                onClick={isDesktop ? maximize : undefined}
                className="h-8 w-11 hover:bg-white/10 grid place-items-center"
              ><Square className="h-3 w-3" /></button>
              <button
                type="button"
                onClick={isDesktop ? close : undefined}
                className="h-8 w-11 hover:bg-red-600 grid place-items-center"
              ><X className="h-3.5 w-3.5" /></button>
            </div>
          </div>
        )}

        {/* Quick access + tabs */}
        <div
          onContextMenu={(e) => { e.preventDefault(); setRibbonMenu({ x: e.clientX, y: e.clientY }); }}
          className="shrink-0 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/40 flex items-stretch relative z-30"
        >
          <AppOrb
            onSwitchCompany={() => { setDesktopAuthenticated(false); toast("Cambiar empresa", { description: "Vuelva a iniciar sesión con las credenciales de la nueva empresa." }); }}
            onCloseApp={() => { toast.success("Cerrando aplicación…"); setTimeout(() => { window.location.href = "/"; }, 300); }}
          />
          <div className="flex-1 min-w-0">
            <TabsCarousel 
              tabs={TABS} 
              active={active} 
              onSelect={setActive}
              onTabClick={(e, t) => {
                const isDouble = e.detail === 2;
                if (isDouble) {
                  if (active === t) {
                    setRibbonMode((m) => (m === "expanded" ? "hidden" : "expanded"));
                  } else {
                    setActive(t);
                    setRibbonMode("expanded");
                  }
                  return;
                }

                if (active === t) {
                  return;
                }

                setActive(t);
              }}
            />
          </div>
        </div>

        {/* Overlay ribbon (does NOT push workspace) */}
        <div
          className={[
            "absolute left-0 right-0 top-full overflow-hidden bg-gradient-to-b from-[#F8FAFC] to-[#EEF2F7] border-b border-slate-300 shadow-[0_12px_24px_-12px_rgba(15,23,42,0.35)] transition-[max-height,opacity,transform] duration-300 ease-out",
            ribbonMode === "overlay"
              ? "max-h-[112px] opacity-100 translate-y-0 pointer-events-auto"
              : "max-h-0 opacity-0 -translate-y-1 pointer-events-none",
          ].join(" ")}
          onMouseLeave={() => { if (ribbonMode === "overlay") setRibbonMode("hidden"); }}
          style={{ zIndex: 29 }}
        >
          <div className="px-2 py-1 h-[104px]">
            <RibbonContent ribbon={ribbon} openDesktopWindow={openDesktopWindow} />
          </div>
        </div>

        {/* Ribbon (in-flow, keeps the normal top position) */}
        <div
          className={[
            "shrink-0 overflow-hidden bg-gradient-to-b from-[#F8FAFC] to-[#EEF2F7] transition-[height,opacity] duration-300 ease-out",
            ribbonMode === "expanded" && !ribbonMinimized ? "h-[104px] opacity-100 border-b border-slate-300" : "h-0 opacity-0",
          ].join(" ")}
        >
          {!ribbonMinimized && (
            <div
              onContextMenu={(e) => { e.preventDefault(); setRibbonMenu({ x: e.clientX, y: e.clientY }); }}
              className={`px-2 py-1 h-[104px] ${ribbonBelow ? "order-last border-t border-b-0" : ""}`}
            >
              <RibbonContent ribbon={ribbon} openDesktopWindow={openDesktopWindow} />
            </div>
          )}
        </div>

        {ribbonMenu && (
          <div
            style={{ left: ribbonMenu.x, top: ribbonMenu.y }}
            onMouseDown={(e) => e.stopPropagation()}
            className="fixed z-[100] min-w-[220px] rounded-sm border border-slate-400 bg-[#F1F1F1] py-1 shadow-[0_6px_20px_rgba(0,0,0,0.25)] text-[12px] text-slate-800"
          >
            <button
              onClick={() => { toast.success("Añadido a la barra de acceso rápido"); setRibbonMenu(null); }}
              className="w-full text-left px-3 py-1.5 hover:bg-[#3B82F6] hover:text-white"
            >
              <u>A</u>dd to Quick Access Toolbar
            </button>
            <button
              onClick={() => { setRibbonBelow(v => !v); setRibbonMenu(null); }}
              className="w-full text-left px-3 py-1.5 hover:bg-[#3B82F6] hover:text-white"
            >
              <u>S</u>how {ribbonBelow ? "Above" : "Below"} the Ribbon
            </button>
            <div className="my-1 border-t border-slate-300" />
            <button
              onClick={() => { setRibbonMinimized(v => !v); setRibbonMenu(null); }}
              className="w-full text-left px-3 py-1.5 hover:bg-[#3B82F6] hover:text-white"
            >
              <u>M</u>inimize the Ribbon {ribbonMinimized ? "✓" : ""}
            </button>
          </div>
        )}

        {/* Workspace MDI */}
        <Workspace />


        {/* Status bar / MDI strip */}
        <div className="shrink-0 border-t border-slate-900/60 bg-gradient-to-b from-[#243B55] to-[#141E30]">
          <div className="h-7 border-b border-slate-700/70 px-2 flex items-center gap-2 overflow-x-auto text-[10px] text-slate-300 font-mono">
            <span className="inline-flex items-center gap-1.5 shrink-0">
              <span className="h-1.5 w-1.5 rounded-full bg-emerald-400 shadow-[0_0_6px_#10B981]" />
              SYSTECK MDI
            </span>
            <span className="text-slate-500 shrink-0">|</span>
            {windows.length === 0 ? (
              <span className="text-slate-400 shrink-0">sin ventanas abiertas</span>
            ) : (
              <div className="flex items-center gap-1.5">
                {windows.slice(0, 5).map((w) => (
                  <button
                    key={w.id}
                    type="button"
                    onClick={() => focusWindow(w.id)}
                    className={[
                      "inline-flex items-center gap-1.5 h-5 px-2 rounded border shrink-0",
                      w.id === activeWindowId
                        ? "border-cyan-500/60 bg-cyan-500/15 text-cyan-200"
                        : "border-slate-600/80 bg-slate-800/60 text-slate-300 hover:bg-slate-700/70",
                    ].join(" ")}
                  >
                    <span className="truncate max-w-[140px]">{w.label}</span>
                    <span
                      className="text-slate-400 hover:text-red-300"
                      onClick={(e) => {
                        e.stopPropagation();
                        closeWindow(w.id);
                      }}
                    >
                      x
                    </span>
                  </button>
                ))}
                {windows.length > 5 && (
                  <span className="text-slate-400 shrink-0">+{windows.length - 5} más</span>
                )}
              </div>
            )}
            <span className="ml-auto text-slate-400 shrink-0">{windows.length} ventana{windows.length === 1 ? "" : "s"} • 0 min.</span>
          </div>

          <div className="h-7 px-2 flex items-center gap-2 overflow-x-auto text-[10.5px] text-slate-200 font-mono">
            <span className="shrink-0">Usuario: <b className="text-cyan-300">grios</b></span>
            <span className="text-slate-500 shrink-0">/</span>
            <span className="shrink-0">Perfil: <b className="text-cyan-300">Consultor</b></span>
            <span className="text-slate-500 shrink-0">|</span>
            <span className="shrink-0">Fecha Proceso: <b className="text-amber-300">{now}</b></span>
            <span className="text-slate-500 shrink-0">/</span>
            <span className="shrink-0">T.C.: <b className="text-amber-300">3.406</b></span>
            <span className="text-slate-500 shrink-0">|</span>
            <span className="shrink-0 inline-flex items-center gap-1.5 px-1.5 h-5 rounded border border-indigo-400/40 bg-indigo-500/10 text-indigo-200">
              <Zap className="h-2.5 w-2.5 text-cyan-300 animate-pulse" />
              <span>Systeck-AI Core: <b className="text-emerald-300">ONLINE</b></span>
            </span>
            <span className="shrink-0 inline-flex items-center gap-1 px-1.5 h-5 rounded border border-cyan-400/40 bg-cyan-500/10 text-cyan-200">GPU Usage: <b className="text-cyan-100">24%</b></span>
            <span className="shrink-0 inline-flex items-center gap-1 px-1.5 h-5 rounded border border-cyan-400/40 bg-cyan-500/10 text-cyan-200">Model Latency: <b className="text-cyan-100">12ms</b></span>
          </div>
        </div>
      </div>

      {loginMode && isDesktop && desktopReady && !desktopAuthenticated && (
        <DesktopLogin
          busy={busy}
          user={user}
          pass={pass}
          fecha={fecha}
          tc={tc}
          sucursal={sucursal}
          showPass={showPass}
          capsOn={capsOn}
          onSubmit={submit}
          onUserChange={setUser}
          onPassChange={setPass}
          onFechaChange={setFecha}
          onTcChange={setTc}
          onSucursalChange={setSucursal}
          onToggleShowPass={() => setShowPass((v) => !v)}
          onCapsChange={setCapsOn}
        />
      )}

      {!isDesktop && (
        <Link
          to="/"
          className="fixed top-4 left-4 z-50 inline-flex items-center gap-2 rounded-md bg-slate-800/80 backdrop-blur px-3 py-2 text-xs font-medium text-white hover:bg-slate-700 border border-slate-600"
        >
          ← Volver al sitio web
        </Link>
      )}
    </div>
  );
}

function DesktopLogin({
  busy,
  user,
  pass,
  fecha,
  tc,
  sucursal,
  showPass,
  capsOn,
  onSubmit,
  onUserChange,
  onPassChange,
  onFechaChange,
  onTcChange,
  onSucursalChange,
  onToggleShowPass,
  onCapsChange,
}: {
  busy: boolean;
  user: string;
  pass: string;
  fecha: string;
  tc: string;
  sucursal: string;
  showPass: boolean;
  capsOn: boolean;
  onSubmit: (event: FormEvent<HTMLFormElement>) => void;
  onUserChange: (value: string) => void;
  onPassChange: (value: string) => void;
  onFechaChange: (value: string) => void;
  onTcChange: (value: string) => void;
  onSucursalChange: (value: string) => void;
  onToggleShowPass: () => void;
  onCapsChange: (value: boolean) => void;
}) {
  const inputCls = "h-9 rounded-md border border-slate-300 bg-white px-3 text-sm text-slate-900 outline-none transition focus:border-slate-500 focus:ring-2 focus:ring-slate-300 flex-1";
  const [recover, setRecover] = useState(false);
  return (
    <div className={`h-screen w-screen overflow-hidden bg-[#F1F4F9] ${busy ? "cursor-wait" : ""}`}>
      <form onSubmit={onSubmit} className="flex h-full w-full flex-col rounded-none overflow-hidden border-0 shadow-none bg-[#F1F4F9]">
        <div className="h-10 bg-gradient-to-b from-[#4A6789] via-[#3A5573] to-[#243B55] flex items-center justify-between px-3 text-white text-xs">
          <span className="font-semibold tracking-tight flex items-center gap-2"><Lock className="h-3.5 w-3.5 text-amber-300" /> Acceso al Sistema — Systeck v10.6.3.0</span>
          <span className="opacity-70 font-mono">C2TECK S.A.C.</span>
        </div>
        <div className="flex h-full overflow-hidden">
          <div className="w-[170px] bg-gradient-to-b from-[#DDE7F3] to-[#B7C7DC] grid place-items-center border-r border-slate-400/50 min-h-full">
            <div className="h-28 w-28 rounded-full bg-gradient-to-br from-amber-300 to-amber-600 grid place-items-center shadow-inner ring-4 ring-amber-200/60">
              <Lock className="h-12 w-12 text-white drop-shadow" strokeWidth={2} />
            </div>
          </div>
          <div className="flex flex-1 flex-col px-6 py-4 overflow-hidden">
            <div className="text-[11px] uppercase tracking-widest text-slate-500 font-semibold border-b border-slate-300 pb-2 shrink-0">Credenciales</div>
            <div className="space-y-3 mt-3 shrink-0">
              <label className="flex items-center gap-3">
                <User className="h-3.5 w-3.5 text-slate-500 shrink-0" />
                <span className="text-[11.5px] text-slate-700 w-20 shrink-0">Usuario</span>
                <input value={user} onChange={(e) => onUserChange(e.target.value)} className={inputCls} />
              </label>
              <label className="flex items-start gap-3">
                <Key className="h-3.5 w-3.5 text-slate-500 shrink-0 mt-1.5" />
                <span className="text-[11.5px] text-slate-700 w-20 mt-1 shrink-0">Clave</span>
                <div className="flex-1 flex flex-col min-w-0">
                  <div className="relative">
                    <input type={showPass ? "text" : "password"} value={pass} onChange={(e) => onPassChange(e.target.value)} onKeyDown={(e) => onCapsChange(e.getModifierState("CapsLock"))} onKeyUp={(e) => onCapsChange(e.getModifierState("CapsLock"))} className={`${inputCls} w-full pr-8`} />
                    <button type="button" onClick={onToggleShowPass} tabIndex={-1} title={showPass ? "Ocultar clave" : "Mostrar clave"} className="absolute right-1 top-1/2 -translate-y-1/2 h-6 w-6 grid place-items-center text-slate-500 hover:text-[#3E5B7A]">
                      {showPass ? <EyeOff className="h-3.5 w-3.5" /> : <Eye className="h-3.5 w-3.5" />}
                    </button>
                  </div>
                  {capsOn && <div className="mt-1 text-[10.5px] font-medium text-orange-600 flex items-center gap-1 animate-in fade-in slide-in-from-top-1 duration-150">⚠️ Bloq Mayús activado</div>}
                </div>
              </label>
            </div>

            <div className="text-[11px] uppercase tracking-widest text-slate-500 font-semibold border-b border-slate-300 pb-2 mt-3 shrink-0">Parámetros de Sesión</div>
            <div className="space-y-3 mt-2 shrink-0">
              <label className="flex items-center gap-3">
                <Calendar className="h-3.5 w-3.5 text-slate-500 shrink-0" />
                <span className="text-[11.5px] text-slate-700 w-20 shrink-0">Fecha Proceso</span>
                <input value={fecha} onChange={(e) => onFechaChange(e.target.value)} className={inputCls} />
              </label>
              <label className="flex items-center gap-3">
                <DollarSign className="h-3.5 w-3.5 text-slate-500 shrink-0" />
                <span className="text-[11.5px] text-slate-700 w-20 shrink-0">Tipo de Cambio</span>
                <input value={tc} onChange={(e) => onTcChange(e.target.value)} className={inputCls} />
              </label>
              <label className="flex items-center gap-3">
                <MapPin className="h-3.5 w-3.5 text-slate-500 shrink-0" />
                <span className="text-[11.5px] text-slate-700 w-20 shrink-0">Sucursal</span>
                <select value={sucursal} onChange={(e) => onSucursalChange(e.target.value)} className={`${inputCls} appearance-none cursor-pointer`}>
                  <option>01 - Sede Central Lima</option>
                  <option>02 - Almacén Principal</option>
                  <option>03 - Operación Minera</option>
                </select>
              </label>
            </div>
            
            <div className="shrink-0 space-y-2 mt-2">
              <div className="flex items-center justify-end gap-2 pt-2 pb-2 border-t border-slate-300">
                <button type="button" onClick={() => window.close()} className="h-7 px-4 text-[12px] rounded-sm border border-slate-400/70 bg-gradient-to-b from-[#F6F9FC] to-[#DDE4EC] hover:from-[#EEF2F7] hover:to-[#C9D3DF] text-slate-800 whitespace-nowrap">Cancelar</button>
                <button type="submit" disabled={busy} className="h-7 px-6 text-[12px] font-semibold rounded-sm border border-[#2A3F55] bg-gradient-to-b from-[#4C6E93] to-[#2A3F55] hover:from-[#5A80A9] text-white disabled:opacity-60 whitespace-nowrap">{busy ? "Conectando..." : "OK"}</button>
              </div>
              <div className="text-center">
                <button
                  type="button"
                  onClick={() => setRecover(true)}
                  className="text-[12px] font-semibold text-red-600 underline underline-offset-2 hover:text-red-700"
                >
                  ¿Olvidaste tu clave de acceso?
                </button>
              </div>
            </div>
          </div>
        </div>
        <div className="h-5 bg-slate-800 text-slate-400 text-[10px] font-mono flex items-center px-3 gap-2 border-t border-slate-900 shrink-0">
          <span className="h-1.5 w-1.5 rounded-full bg-emerald-400 animate-pulse" />
          <span>Auth Server · 127.0.0.1:8443 · TLS 1.3</span>
          <span className="ml-auto">Hideez FIDO2 ready</span>
        </div>
      </form>
      {recover && <RecoverPasswordModal onClose={() => setRecover(false)} />}
    </div>
  );
}

function RecoverPasswordModal({ onClose }: { onClose: () => void }) {
  const [u, setU] = useState("");
  return (
    <div className="fixed inset-0 z-[10000] bg-slate-950/40 grid place-items-center animate-in fade-in duration-150">
      <form
        onSubmit={(e) => {
          e.preventDefault();
          if (!u.trim()) { toast.error("Ingresa tu usuario"); return; }
          toast.success("Solicitud enviada", { description: `Se envió el enlace de recuperación para "${u.trim()}".` });
          onClose();
        }}
        className="w-[440px] max-w-[95vw] rounded-md overflow-hidden border border-slate-400/70 shadow-2xl bg-[#F8FAFC]"
      >
        <div className="h-8 bg-gradient-to-b from-[#F3F6FA] to-[#E2E8F0] border-b border-slate-300 flex items-center justify-between px-3">
          <span className="text-[12px] text-slate-700">Recuperar Clave</span>
          <button type="button" onClick={onClose} className="h-6 w-6 grid place-items-center rounded-sm text-slate-600 hover:bg-red-600 hover:text-white">
            <X className="h-3.5 w-3.5" />
          </button>
        </div>
        <div className="px-6 py-5">
          <h3 className="text-center text-[17px] font-bold text-slate-900">Recuperar Contraseña</h3>
          <label className="mt-5 flex items-center gap-3">
            <span className="text-[12.5px] text-slate-800 whitespace-nowrap">Ingresa tu usuario :</span>
            <input
              value={u}
              onChange={(e) => setU(e.target.value)}
              autoFocus
              className="flex-1 h-8 px-2 text-[12px] bg-white border border-slate-400/70 rounded-sm text-slate-900 focus:border-[#3E5B7A] focus:ring-1 focus:ring-[#3E5B7A]/30 outline-none font-mono"
            />
          </label>
          <div className="mt-6 flex items-center justify-center gap-3">
            <button type="submit" className="h-8 px-4 text-[12.5px] rounded-sm border border-[#3E7BC0] bg-gradient-to-b from-white to-[#E4EEF9] text-slate-800 inline-flex items-center gap-2 hover:from-[#F2F8FF]">
              Aceptar <CheckCircle2 className="h-4 w-4 text-emerald-600" />
            </button>
            <button type="button" onClick={onClose} className="h-8 px-4 text-[12.5px] rounded-sm border border-slate-400/70 bg-gradient-to-b from-white to-[#E7ECF2] text-slate-800 inline-flex items-center gap-2 hover:from-[#F5F8FB]">
              Cancelar <ArrowLeft className="h-4 w-4 text-[#2F80ED]" />
            </button>
          </div>
        </div>
      </form>
    </div>
  );
}


function RibbonContent({ ribbon, openDesktopWindow }: { ribbon: RibbonGroup[]; openDesktopWindow: (label: string) => void }) {
  const containerRef = useRef<HTMLDivElement>(null);
  const [collapsedGroups, setCollapsedGroups] = useState<Set<number>>(new Set());
  const expandedWidthCache = useRef<number[]>([]);
  const collapsedWidthCache = useRef<number[]>([]);

  const estimateExpandedWidth = (group: RibbonGroup) => {
    const bigCount = group.items.filter((item) => item.big).length;
    const smallCount = group.items.length - bigCount;
    const bigWidth = bigCount > 0 ? bigCount * 66 : 0;
    const smallWidth = smallCount > 0 ? Math.max(150, smallCount * 72 + 24) : 0;
    return Math.max(82, bigWidth + smallWidth + 16);
  };

  useEffect(() => {
    expandedWidthCache.current = [];
    collapsedWidthCache.current = [];
    setCollapsedGroups(new Set());
  }, [ribbon]);

  useLayoutEffect(() => {
    const el = containerRef.current;
    if (!el) return;

    let raf = 0;
    const measure = () => {
      cancelAnimationFrame(raf);
      raf = requestAnimationFrame(() => {
        const children = Array.from(el.children) as HTMLElement[];
        const currentWidth = children.reduce((total, child, index) => {
          const width = child.getBoundingClientRect().width;
          if (collapsedGroups.has(index)) {
            collapsedWidthCache.current[index] = width;
          } else {
            expandedWidthCache.current[index] = width;
          }
          return total + width;
        }, 0);

        const overflow = currentWidth - el.clientWidth;
        if (overflow > 4) {
          setCollapsedGroups((prev) => {
            const candidates = ribbon
              .map((group, index) => {
                const expandedWidth = expandedWidthCache.current[index] ?? estimateExpandedWidth(group);
                const collapsedWidth = collapsedWidthCache.current[index] ?? 84;
                return {
                  index,
                  count: group.items.length,
                  hasBig: group.items.some((item) => item.big),
                  savings: Math.max(0, expandedWidth - collapsedWidth),
                };
              })
              .filter((candidate) => !prev.has(candidate.index) && !candidate.hasBig && candidate.count >= 2)
              .sort((a, b) => b.savings - a.savings || b.count - a.count);

            if (!candidates.length) return prev;
            const next = new Set(prev);
            next.add(candidates[0].index);
            return next;
          });
        } else {
          const freeSpace = Math.max(0, el.clientWidth - currentWidth);
          setCollapsedGroups((prev) => {
            if (!prev.size) return prev;
            let remainingSpace = freeSpace;
            const candidates = [...prev]
              .map((index) => {
                const group = ribbon[index];
                if (!group) return null;
                const expandedWidth = expandedWidthCache.current[index] ?? estimateExpandedWidth(group);
                const collapsedWidth = collapsedWidthCache.current[index] ?? 84;
                return {
                  index,
                  count: group.items.length,
                  needed: Math.max(0, expandedWidth - collapsedWidth),
                };
              })
              .filter((candidate): candidate is { index: number; count: number; needed: number } => Boolean(candidate))
              .sort((a, b) => a.needed - b.needed || a.count - b.count);

            const next = new Set(prev);
            let changed = false;
            for (const candidate of candidates) {
              if (remainingSpace >= candidate.needed + 6) {
                next.delete(candidate.index);
                remainingSpace -= candidate.needed;
                changed = true;
              }
            }
            return changed ? next : prev;
          });
        }
      });
    };

    const ro = new ResizeObserver(measure);
    ro.observe(el);
    measure();

    return () => {
      ro.disconnect();
      cancelAnimationFrame(raf);
    };
  }, [ribbon, collapsedGroups]);

  return (
    <div ref={containerRef} className="flex items-stretch flex-nowrap h-full w-full overflow-hidden">
      {ribbon.map((group, gi) => (
        collapsedGroups.has(gi) ? (
          <CollapsedGroupButton key={gi} group={group} onOpen={openDesktopWindow} />
        ) : (
          <div key={gi} className="flex flex-col shrink-0 border-r border-slate-200 last:border-r-0">
            <div className="flex items-start gap-1 px-2 pt-1 pb-0.5 min-h-[78px]">
              {group.items.filter((item) => item.big).map((btn) => (
                <RibbonBigButton key={btn.label} {...btn} onOpen={openDesktopWindow} />
              ))}
              <div className="grid grid-flow-col grid-rows-2 auto-cols-max gap-x-3 gap-y-0.5 pt-0.5">
                {group.items.filter((item) => !item.big).map((btn) => (
                  <RibbonSmallButton key={btn.label} {...btn} onOpen={openDesktopWindow} />
                ))}
              </div>
            </div>
            {group.title && (
              <div className="shrink-0 text-[9.5px] lg:text-[10px] text-slate-500 mt-auto px-2 pt-0.5 pb-[3px] border-t border-slate-200/80 bg-slate-50/60 text-center uppercase tracking-wider">
                {group.title}
              </div>
            )}
          </div>
        )
      ))}
    </div>
  );
}

function CollapsedGroupButton({ group, onOpen }: { group: RibbonGroup; onOpen: (label: string) => void }) {
  const [open, setOpen] = useState(false);
  const btnRef = useRef<HTMLButtonElement>(null);
  const [pos, setPos] = useState<{ left: number; top: number } | null>(null);

  const label = group.title || group.items[0]?.label || "Grupo";

  const toggle = () => {
    if (!open && btnRef.current) {
      const rect = btnRef.current.getBoundingClientRect();
      setPos({ left: rect.left, top: rect.bottom + 2 });
    }
    setOpen((value) => !value);
  };

  return (
    <div className="flex flex-col shrink-0 border-r border-slate-200 last:border-r-0">
      <div className="flex items-start px-1.5 pt-1 pb-0.5 min-h-[78px]">
        <button
          ref={btnRef}
          onClick={toggle}
          title={label}
          className={[
            "flex flex-col items-center justify-center gap-1 rounded border w-[72px] h-[72px] px-1.5",
            open
              ? "bg-gradient-to-b from-[#FCE9A8] to-[#F5C86A] border-[#B8892E] shadow-inner"
              : "border-transparent hover:bg-[#DDE7F3] hover:border-[#7FA8D6]",
          ].join(" ")}
        >
          <Glyph name={label} size={24} className="shrink-0" />
          <span className="text-[9.5px] leading-tight text-center whitespace-pre text-slate-800 font-medium">{label}</span>
          <ChevronDown className="h-2.5 w-2.5 text-slate-600" />
        </button>
      </div>
      {open && pos && createPortal(
        <>
          <div className="fixed inset-0 z-40" onClick={() => setOpen(false)} />
          <div
            className="fixed z-[2147483646] bg-[#F3F6FA] border border-slate-400/70 shadow-xl rounded-sm p-2 min-w-[220px] max-h-[60vh] overflow-y-auto"
            style={{ left: pos.left, top: pos.top }}
          >
            <div className="flex flex-col gap-0.5">
              {group.items.map((item) => (
                <button
                  key={item.label}
                  onClick={() => { onOpen(item.label); setOpen(false); }}
                  className="flex items-center gap-2 px-1.5 py-1 rounded hover:bg-[#DDE7F3] hover:border-[#7FA8D6] border border-transparent text-left"
                >
                  <Glyph name={item.label} size={18} className="shrink-0" />
                  <span className="text-[11.5px] text-slate-800 whitespace-nowrap">{item.label}</span>
                </button>
              ))}
            </div>
          </div>
        </>,
        document.body,
      )}
    </div>
  );
}

function AppOrb({ onSwitchCompany, onCloseApp }: { onSwitchCompany: () => void; onCloseApp: () => void }) {
  const [open, setOpen] = useState(false);
  const ref = useRef<HTMLDivElement>(null);
  useEffect(() => {
    if (!open) return;
    const onDoc = (e: MouseEvent) => { if (!ref.current?.contains(e.target as Node)) setOpen(false); };
    document.addEventListener("mousedown", onDoc);
    return () => document.removeEventListener("mousedown", onDoc);
  }, [open]);
  return (
    <div ref={ref} className="relative shrink-0 flex items-center pl-1.5 pr-2">
      <button
        onClick={() => setOpen(v => !v)}
        title="Menú de aplicación"
        className={`group relative h-9 w-9 rounded-full grid place-items-center transition-all duration-200
          ring-1 ring-slate-900/40
          bg-[radial-gradient(circle_at_32%_28%,#FFFFFF_0%,#E4ECF5_35%,#A9B8CB_70%,#6B7C93_100%)]
          shadow-[inset_0_1px_1.5px_rgba(255,255,255,0.9),inset_0_-3px_5px_rgba(30,45,70,0.45),inset_0_0_0_1px_rgba(255,255,255,0.15),0_2px_3px_rgba(0,0,0,0.35),0_4px_10px_rgba(0,0,0,0.25)]
          hover:bg-[radial-gradient(circle_at_32%_28%,#FFF9D6_0%,#FFD966_35%,#C9962A_72%,#7A5A10_100%)]
          hover:ring-amber-700/60
          hover:shadow-[inset_0_1px_1.5px_rgba(255,255,255,0.95),inset_0_-3px_6px_rgba(90,55,5,0.55),inset_0_0_0_1px_rgba(255,220,120,0.35),0_0_14px_rgba(245,196,64,0.6),0_2px_4px_rgba(0,0,0,0.4)]
          active:translate-y-[1px] active:shadow-[inset_0_2px_4px_rgba(0,0,0,0.4),0_1px_2px_rgba(0,0,0,0.3)]
          ${open ? "ring-2 ring-amber-500 bg-[radial-gradient(circle_at_32%_28%,#FFF9D6_0%,#FFD966_35%,#C9962A_72%,#7A5A10_100%)]" : ""}`}
      >
        <img src={systeckIcon} alt="Systeck" className="relative z-10 h-6 w-6 object-contain drop-shadow-[0_1px_1px_rgba(0,0,0,0.55)]" />
        {/* Specular top highlight (glassy sheen) */}
        <span aria-hidden className="pointer-events-none absolute inset-0 rounded-full overflow-hidden">
          <span className="absolute left-[14%] right-[14%] top-[6%] h-[42%] rounded-full bg-[radial-gradient(ellipse_at_center,rgba(255,255,255,0.85)_0%,rgba(255,255,255,0.35)_45%,rgba(255,255,255,0)_75%)] blur-[0.5px]" />
        </span>
        {/* Bottom inner rim reflection */}
        <span aria-hidden className="pointer-events-none absolute inset-0 rounded-full shadow-[inset_0_-1px_0_rgba(255,255,255,0.25)]" />
      </button>
      {open && (
        <div className="absolute top-full left-1 mt-1 z-[100] w-60 rounded-md border border-slate-400/70 bg-[#F8FAFC] shadow-2xl overflow-hidden animate-in fade-in zoom-in-95 duration-150">
          <div className="px-3 py-2 bg-gradient-to-b from-[#4A6789] to-[#243B55] text-white text-[11px] font-semibold tracking-wide flex items-center gap-2">
            <Cpu className="h-3.5 w-3.5 text-amber-300" /> Systeck — C2TECK S.A.C.
          </div>
          <button
            onClick={() => { setOpen(false); onSwitchCompany(); }}
            className="w-full text-left px-3 py-2.5 text-[12px] text-slate-800 hover:bg-[#DDE7F3] flex items-center gap-2.5 border-b border-slate-200"
          >
            <Building2 className="h-4 w-4 text-[#3E5B7A]" />
            <div>
              <div className="font-semibold">Cambiar Empresa</div>
              <div className="text-[10px] text-slate-500">Cerrar sesión y elegir otro tenant</div>
            </div>
          </button>
          <button
            onClick={() => { setOpen(false); onCloseApp(); }}
            className="w-full text-left px-3 py-2.5 text-[12px] text-slate-800 hover:bg-red-50 flex items-center gap-2.5"
          >
            <LogOut className="h-4 w-4 text-red-600" />
            <div>
              <div className="font-semibold">Cerrar Aplicación</div>
              <div className="text-[10px] text-slate-500">Salir de Systeck y volver al sitio</div>
            </div>
          </button>
        </div>
      )}
    </div>
  );
}

function TabsCarousel({ tabs, active, onSelect, onTabClick }: { tabs: string[]; active: string; onSelect: (tab: string) => void; onTabClick?: (e: React.MouseEvent, t: string) => void }) {
  const handleTabClick = (e: React.MouseEvent, t: string) => {
    if (onTabClick) {
      onTabClick(e, t);
    } else {
      onSelect(t);
    }
  };

  return (
    <div className="flex items-center px-2 pt-1 gap-0 overflow-x-auto">
      <div className="flex items-center gap-1 pr-1 shrink-0">
        <button className="h-5 w-5 rounded hover:bg-white/60 grid place-items-center flex-shrink-0">
          <ChevronDown className="h-3 w-3" />
        </button>
        <div className="w-px h-4 bg-slate-400/30"></div>
      </div>
      {tabs.map((t) => (
        <button
          key={t}
          onClick={(e) => handleTabClick(e, t)}
          className={[
            "flex-1 px-2 py-2 text-[11px] font-medium rounded-t border-x border-t transition-colors text-center whitespace-nowrap",
            active === t
              ? "bg-[#F3F6FA] border-slate-400/60 text-slate-900 font-semibold -mb-px"
              : "bg-transparent border-transparent text-slate-600 hover:bg-white/40 hover:text-slate-800",
          ].join(" ")}
        >
          {t}
        </button>
      ))}
    </div>
  );
}


function RibbonBigButton({ icon: Icon, label, dropdown, menu, onOpen }: RibbonBtn & { onOpen: (label: string) => void }) {
  const [open, setOpen] = useState(false);
  const btnRef = useRef<HTMLButtonElement>(null);
  const [pos, setPos] = useState<{ left: number; top: number } | null>(null);

  const cleanLabel = label.replace(/\n/g, " ");

  const toggle = () => {
    if (!menu) {
      onOpen(cleanLabel);
      return;
    }
    if (!open && btnRef.current) {
      const r = btnRef.current.getBoundingClientRect();
      setPos({ left: r.left, top: r.bottom + 2 });
    }
    setOpen((v) => !v);
  };

  return (
    <>
      <button
        ref={btnRef}
        onClick={toggle}
        className={[
          "flex flex-col items-center gap-1 px-1.5 py-0.5 rounded border w-[64px]",
          open
            ? "bg-gradient-to-b from-[#FCE9A8] to-[#F5C86A] border-[#B8892E] shadow-inner"
            : "border-transparent hover:bg-[#DDE7F3] hover:border-[#7FA8D6]",
        ].join(" ")}
      >
        <Glyph name={cleanLabel} size={30} className="drop-shadow-[0_1px_1px_rgba(15,23,42,0.15)] group-hover/rb:scale-105 transition-transform" />
        <span className="text-[10.5px] leading-tight text-center whitespace-pre text-slate-800 font-medium">{label}</span>
        {dropdown && <ChevronDown className="h-2.5 w-2.5 text-slate-500 -mt-1" />}
      </button>
      {open && menu && pos && createPortal(
        <>
          <div className="fixed inset-0 z-40" onClick={() => setOpen(false)} />
          <div
            className="fixed z-[2147483646] bg-[#F3F6FA] border border-slate-400/70 shadow-xl rounded-sm p-2"
            style={{ left: pos.left, top: pos.top, maxWidth: "700px" }}
          >
            <div className="grid gap-3" style={{ gridTemplateColumns: `repeat(${menu.length}, minmax(0, 1fr))` }}>
              {menu.map((sec) => (
                <div key={sec.title} className="flex flex-col">
                  <div className="flex flex-col gap-0.5">
                    {sec.items.map((it) => (
                      <button
                        key={it.label}
                        onClick={() => { onOpen(it.label); setOpen(false); }}
                        className="flex items-center gap-1.5 px-1.5 py-0.5 rounded hover:bg-[#DDE7F3] hover:border-[#7FA8D6] border border-transparent text-left whitespace-nowrap"
                      >
                        <Glyph name={it.label} size={22} className="shrink-0" />
                      <span className="text-[11.5px] text-slate-800 whitespace-nowrap font-medium">{it.label}</span>
                      </button>
                    ))}
                  </div>
                  <div className="text-[9px] text-slate-500 text-center border-t border-slate-300/70 pt-1 mt-1">
                    {sec.title}
                  </div>
                </div>
              ))}
            </div>
          </div>
        </>,
        document.body
      )}
    </>
  );
}

function DesktopPopoutWindow({ label, onClose }: { label: string; onClose: () => void }) {
  const normalizedLabel = label.replace(/\n/g, " ").trim();

  useEffect(() => {
    document.title = normalizedLabel;
  }, [normalizedLabel]);

  return (
    <div className="popup-mode h-screen w-screen bg-[#DDE4EC] text-slate-800 overflow-hidden">
      <div className="h-full w-full flex flex-col">
        <div className="flex-1 overflow-auto">
          {renderWindow(normalizedLabel)}
        </div>
      </div>
    </div>
  );
}

function RibbonSmallButton({ icon: Icon, label, dropdown, menu, onOpen }: RibbonBtn & { onOpen: (label: string) => void }) {
  const [open, setOpen] = useState(false);
  const btnRef = useRef<HTMLButtonElement>(null);
  const [pos, setPos] = useState<{ left: number; top: number } | null>(null);

  const toggle = () => {
    if (!menu) {
      onOpen(label);
      return;
    }
    if (!open && btnRef.current) {
      const r = btnRef.current.getBoundingClientRect();
      setPos({ left: r.left, top: r.bottom + 2 });
    }
    setOpen((v) => !v);
  };

  return (
    <>
      <button
        ref={btnRef}
        onClick={toggle}
        className={[
          "flex items-center gap-1 px-1 py-0.5 rounded border text-left text-[10px]",
          open
            ? "bg-gradient-to-b from-[#FCE9A8] to-[#F5C86A] border-[#B8892E]"
            : "border-transparent hover:bg-[#DDE7F3] hover:border-[#7FA8D6]",
        ].join(" ")}
      >
        <Glyph name={label} size={19} className="shrink-0 group-hover/rs:scale-105 transition-transform" />
        <span className="text-slate-800 truncate">{label}</span>
        {dropdown && <ChevronDown className="h-2 w-2 text-slate-600" />}
      </button>
      {open && menu && pos && createPortal(
        <>
          <div className="fixed inset-0 z-40" onClick={() => setOpen(false)} />
          <div
            className="fixed z-[2147483646] bg-[#F3F6FA] border border-slate-400/70 shadow-xl rounded-sm p-2"
            style={{ left: pos.left, top: pos.top, maxWidth: "700px" }}
          >
            <div className="grid gap-3" style={{ gridTemplateColumns: `repeat(${menu.length}, minmax(0, 1fr))` }}>
              {menu.map((sec) => (
                <div key={sec.title} className="flex flex-col">
                  <div className="flex flex-col gap-0.5">
                    {sec.items.map((it) => (
                      <button
                        key={it.label}
                        onClick={() => { onOpen(it.label); setOpen(false); }}
                        className="flex items-center gap-1.5 px-1.5 py-0.5 rounded hover:bg-[#DDE7F3] hover:border-[#7FA8D6] border border-transparent text-left whitespace-nowrap"
                      >
                        <Glyph name={it.label} size={18} className="shrink-0" />
                        <span className="text-[11px] text-slate-800 whitespace-nowrap font-medium">{it.label}</span>
                      </button>
                    ))}
                  </div>
                </div>
              ))}
            </div>
          </div>
        </>,
        document.body,
      )}
    </>
  );
}

