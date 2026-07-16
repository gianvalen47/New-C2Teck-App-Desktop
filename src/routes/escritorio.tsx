import { createFileRoute, Link } from "@tanstack/react-router";
import { useState, useRef, useEffect, useLayoutEffect, FormEvent } from "react";
import { toast } from "sonner";
import { useDesktopMode } from "@/hooks/use-desktop";
import { createPortal } from "react-dom";
import { WindowsProvider, useWindows, Workspace, renderWindow } from "@/features/escritorio/windows";

import {
  Minus, Square, X, ChevronDown, Circle,
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
  Eye, EyeOff, Key, User,
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
type RibbonBtn = { icon: any; label: string; big?: boolean; dropdown?: boolean; menu?: MenuSection[] };
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
        { icon: FilePlus, label: "Registro de Venta", dropdown: true },
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
        { icon: BookOpen, label: "Consultas", big: true, dropdown: true },
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
        { icon: FileClock, label: "Vencimientos", dropdown: true },
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
      ],
    },
    {
      title: "Comunicaciones",
      items: [
        { icon: Radio, label: "Marcación Online" },
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
        { icon: BookMarked, label: "Libros Oficiales", dropdown: true },
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
  const [now, setNow] = useState("");
  const { isDesktop, minimize, maximize, close } = useDesktopMode();
  const { open: openWindow } = useWindows();
  const params = new URLSearchParams(window.location.search);
  const popupLabel = params.get("popup");
  const loginMode = params.get("login") === "1";
  const [desktopAuthenticated, setDesktopAuthenticated] = useState(!loginMode);
  const [desktopReady, setDesktopReady] = useState(false);
  const [busy, setBusy] = useState(false);
  const [user, setUser] = useState("grios");
  const [pass, setPass] = useState("demo1234");
  const [fecha, setFecha] = useState(new Date().toISOString().slice(0, 10));
  const [tc, setTc] = useState("3.399");
  const [sucursal, setSucursal] = useState("01 - Sede Central Lima");
  const [showPass, setShowPass] = useState(false);
  const [capsOn, setCapsOn] = useState(false);

  useEffect(() => {
    setNow(new Date().toLocaleDateString("es-PE"));
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
    if (isDesktop && typeof window !== "undefined") {
      const popupUrl = new URL("/escritorio", window.location.origin);
      popupUrl.searchParams.set("desktop", "1");
      popupUrl.searchParams.set("popup", label);
      window.open(
        popupUrl.toString(),
        `_popup-${label}-${Date.now()}`,
        "width=1400,height=900,resizable=yes,scrollbars=no",
      );
      return;
    }
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
        <div className="relative z-0 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/40">
          <div className="flex items-center px-2 pt-1 gap-0 overflow-x-auto">
            <div className="flex items-center gap-1 pr-1 shrink-0">
              <button className="h-5 w-5 rounded hover:bg-white/60 grid place-items-center flex-shrink-0">
                <ChevronDown className="h-3 w-3" />
              </button>
              <div className="w-px h-4 bg-slate-400/30"></div>
            </div>
            {TABS.map((t) => (
              <button
                key={t}
                onClick={() => setActive(t)}
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
        </div>

        {/* Ribbon */}
        <div className="shrink-0 bg-gradient-to-b from-[#F8FAFC] to-[#EEF2F7] border-b border-slate-300 px-2 pt-1 pb-0">
          <div className="flex items-stretch flex-nowrap overflow-x-auto overflow-y-visible">
            {ribbon.map((group, gi) => (
              <div key={gi} className="flex flex-col shrink-0 border-r border-slate-200 last:border-r-0">
                <div className="flex items-start gap-1 px-2 pt-1 pb-0.5 min-h-[78px]">
                  {group.items.filter(i => i.big).map((btn) => (
                    <RibbonBigButton key={btn.label} {...btn} onOpen={openDesktopWindow} />
                  ))}
                  <div className="grid grid-flow-col grid-rows-2 auto-cols-max gap-x-3 gap-y-0.5 pt-0.5">
                    {group.items.filter(i => !i.big).map((btn) => (
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
            ))}
          </div>
        </div>

        {/* Workspace MDI */}
        <Workspace />


        {/* Status bar */}
        <div className="relative z-0 h-6 bg-gradient-to-b from-[#E4EAF1] to-[#C9D3DF] border-t border-slate-400/40 flex items-center px-3 text-[11px] text-slate-700 gap-4 overflow-x-auto">
          <span>Usuario: <b>grios</b></span>
          <span className="text-slate-400">/</span>
          <span>Perfil: <b>Consultor</b></span>
          <span className="text-slate-400">|</span>
          <span>Fecha de Transacción: <b>{now}</b></span>
          <span className="text-slate-400">/</span>
          <span>Tipo de Cambio Compra: <b>3.399</b></span>
          <span className="text-slate-400">·</span>
          <span>Venta: <b>3.411</b></span>
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
  const inputCls = "h-9 rounded-md border border-slate-300 bg-white px-3 text-sm text-slate-900 outline-none transition focus:border-slate-500 focus:ring-2 focus:ring-slate-300";

  return (
    <div className={`h-screen w-screen overflow-hidden bg-[#F1F4F9] ${busy ? "cursor-wait" : ""}`}>
      <form onSubmit={onSubmit} className="flex h-full w-full flex-col rounded-none overflow-hidden border-0 shadow-none bg-[#F1F4F9]">
        <div className="h-10 bg-gradient-to-b from-[#4A6789] via-[#3A5573] to-[#243B55] flex items-center justify-between px-3 text-white text-xs">
          <span className="font-semibold tracking-tight flex items-center gap-2"><Lock className="h-3.5 w-3.5 text-amber-300" /> Acceso al Sistema — Systeck v10.6.3.0</span>
          <span className="opacity-70 font-mono">C2TECK S.A.C.</span>
        </div>
        <div className="flex h-full">
          <div className="w-[170px] bg-gradient-to-b from-[#DDE7F3] to-[#B7C7DC] grid place-items-center border-r border-slate-400/50 py-6 min-h-full">
            <div className="h-28 w-28 rounded-full bg-gradient-to-br from-amber-300 to-amber-600 grid place-items-center shadow-inner ring-4 ring-amber-200/60">
              <Lock className="h-12 w-12 text-white drop-shadow" strokeWidth={2} />
            </div>
          </div>
          <div className="flex flex-1 flex-col p-4 space-y-2.5">
            <div className="text-[11px] uppercase tracking-widest text-slate-500 font-semibold border-b border-slate-300 pb-1">Credenciales</div>
            <label className="flex items-center gap-2">
              <User className="h-3.5 w-3.5 text-slate-500 shrink-0" />
              <span className="text-[11.5px] text-slate-700 w-24">Usuario</span>
              <input value={user} onChange={(e) => onUserChange(e.target.value)} className={inputCls} />
            </label>
            <label className="flex items-start gap-2">
              <Key className="h-3.5 w-3.5 text-slate-500 shrink-0 mt-1.5" />
              <span className="text-[11.5px] text-slate-700 w-24 mt-1">Clave</span>
              <div className="flex-1 flex flex-col">
                <div className="relative">
                  <input type={showPass ? "text" : "password"} value={pass} onChange={(e) => onPassChange(e.target.value)} onKeyDown={(e) => onCapsChange(e.getModifierState("CapsLock"))} onKeyUp={(e) => onCapsChange(e.getModifierState("CapsLock"))} className={`${inputCls} w-full pr-8`} />
                  <button type="button" onClick={onToggleShowPass} tabIndex={-1} title={showPass ? "Ocultar clave" : "Mostrar clave"} className="absolute right-1 top-1/2 -translate-y-1/2 h-6 w-6 grid place-items-center text-slate-500 hover:text-[#3E5B7A]">
                    {showPass ? <EyeOff className="h-3.5 w-3.5" /> : <Eye className="h-3.5 w-3.5" />}
                  </button>
                </div>
                {capsOn && <div className="mt-1 text-[10.5px] font-medium text-orange-600 flex items-center gap-1 animate-in fade-in slide-in-from-top-1 duration-150">⚠️ Bloq Mayús activado</div>}
              </div>
            </label>
            
            <div className="flex flex-1 flex-col justify-between gap-4">
              <div className="space-y-2.5">
                <div className="text-[11px] uppercase tracking-widest text-slate-500 font-semibold border-b border-slate-300 pb-1">Parámetros de Sesión</div>
                <label className="flex items-center gap-2">
                  <Calendar className="h-3.5 w-3.5 text-slate-500 shrink-0" />
                  <span className="text-[11.5px] text-slate-700 w-24">Fecha Proceso</span>
                  <input value={fecha} onChange={(e) => onFechaChange(e.target.value)} className={inputCls} />
                </label>
                <label className="flex items-center gap-2">
                  <DollarSign className="h-3.5 w-3.5 text-slate-500 shrink-0" />
                  <span className="text-[11.5px] text-slate-700 w-24">Tipo de Cambio</span>
                  <input value={tc} onChange={(e) => onTcChange(e.target.value)} className={inputCls} />
                </label>
                <label className="flex items-center gap-2">
                  <MapPin className="h-3.5 w-3.5 text-slate-500 shrink-0" />
                  <span className="text-[11.5px] text-slate-700 w-24">Sucursal</span>
                  <select value={sucursal} onChange={(e) => onSucursalChange(e.target.value)} className={`${inputCls} appearance-none cursor-pointer`}>
                    <option>01 - Sede Central Lima</option>
                    <option>02 - Almacén Principal</option>
                    <option>03 - Operación Minera</option>
                  </select>
                </label>
              </div>
              <div className="flex items-center justify-end gap-2 pt-3 border-t border-slate-300">
                <button type="button" onClick={() => window.close()} className="h-7 px-4 text-[12px] rounded-sm border border-slate-400/70 bg-gradient-to-b from-[#F6F9FC] to-[#DDE4EC] hover:from-[#EEF2F7] hover:to-[#C9D3DF] text-slate-800">Cancelar</button>
                <button type="submit" disabled={busy} className="h-7 px-6 text-[12px] font-semibold rounded-sm border border-[#2A3F55] bg-gradient-to-b from-[#4C6E93] to-[#2A3F55] hover:from-[#5A80A9] text-white disabled:opacity-60">{busy ? "Conectando..." : "OK"}</button>
              </div>
            </div>
          </div>
        </div>
        <div className="h-5 bg-slate-800 text-slate-400 text-[10px] font-mono flex items-center px-3 gap-2 border-t border-slate-900">
          <span className="h-1.5 w-1.5 rounded-full bg-emerald-400 animate-pulse" />
          <span>Auth Server · 127.0.0.1:8443 · TLS 1.3</span>
          <span className="ml-auto">Hideez FIDO2 ready</span>
        </div>
      </form>
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
        <Icon className="h-6 w-6 text-slate-700" strokeWidth={1.5} />
        <span className="text-[9px] leading-tight text-center whitespace-pre text-slate-800">{label}</span>
        {dropdown && <ChevronDown className="h-2 w-2 text-slate-600 -mt-0.5" />}
      </button>
      {open && menu && pos && createPortal(
        <>
          <div className="fixed inset-0 z-40" onClick={() => setOpen(false)} />
          <div
            className="fixed z-[2147483646] bg-[#F3F6FA] border border-slate-400/70 shadow-xl rounded-sm p-2"
            style={{ left: pos.left, top: pos.top, maxWidth: "700px" }}
          >
            <div className="grid grid-cols-3 gap-3">
              {menu.map((sec) => (
                <div key={sec.title} className="flex flex-col">
                  <div className="flex flex-col gap-0.5">
                    {sec.items.map((it) => (
                      <button
                        key={it.label}
                        onClick={() => { onOpen(it.label); setOpen(false); }}
                        className="flex items-center gap-1.5 px-1.5 py-0.5 rounded hover:bg-[#DDE7F3] hover:border-[#7FA8D6] border border-transparent text-left whitespace-nowrap"
                      >
                        <it.icon className="h-3.5 w-3.5 text-amber-600 shrink-0" strokeWidth={1.5} />
                        <span className="text-[10px] text-slate-800">{it.label}</span>
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

function RibbonSmallButton({ icon: Icon, label, dropdown, onOpen }: RibbonBtn & { onOpen: (label: string) => void }) {
  return (
    <button
      onClick={() => onOpen(label)}
      className="flex items-center gap-1 px-1 py-0.5 rounded hover:bg-[#DDE7F3] hover:border-[#7FA8D6] border border-transparent text-left text-[10px]"
    >
      <Icon className="h-3.5 w-3.5 text-amber-600 shrink-0" strokeWidth={1.5} />
      <span className="text-slate-800 truncate">{label}</span>
      {dropdown && <ChevronDown className="h-2 w-2 text-slate-600" />}
    </button>
  );
}

