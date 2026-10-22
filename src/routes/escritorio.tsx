import { createFileRoute, Link } from "@tanstack/react-router";
import { useState, useRef, useEffect, useLayoutEffect, FormEvent, type CSSProperties } from "react";
import {
  motion,
  AnimatePresence,
  EASE_OUT,
  EASE_FAST,
} from "@/features/escritorio/motion";
import { toast } from "sonner";
import { useDesktopMode } from "@/hooks/use-desktop";
import { createPortal } from "react-dom";
import { WindowsProvider, useWindows} from "@/context/WindowsContext";
import { Workspace, renderWindow } from "@/features/escritorio/windows";
import { Glyph } from "@/features/escritorio/glyphs";
import { ICONOS_COLOR } from "@/assets/new-logos/iconos-sigecom-color";
import systeckIcon from "@/assets/Systeck.ico";
import {
  Minus, Square, X, ChevronDown, Bell, ShieldCheck, Cpu as CpuIcon, HelpCircle, Circle, ArrowLeft,
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
  ChevronRight, AlertTriangle as AlertIcon, PackageCheck as PackageAlert, CheckCheck, X as CloseIcon
} from "lucide-react";

import { fetchSession, fetchTipoCambio, login, type SessionInfo } from "@/lib/sigecoom-api";
import { SessionProvider, useSession } from "@/context/SessionContext";
import { CompanyPickerModal, type Company } from "@/features/escritorio/windows/Logueo/CambiarEmpresa";

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

function toDateInputValue(value: string): string {
  const legacyDate = value.match(/^(\d{1,2})\/(\d{1,2})\/(\d{4})$/);
  if (legacyDate) {
    const [, day, month, year] = legacyDate;
    return `${year}-${month.padStart(2, "0")}-${day.padStart(2, "0")}`;
  }
  if (/^\d{4}-\d{2}-\d{2}$/.test(value)) return value;

  const parsed = new Date(value);
  if (Number.isNaN(parsed.getTime())) return "";
  const year = parsed.getFullYear();
  const month = String(parsed.getMonth() + 1).padStart(2, "0");
  const day = String(parsed.getDate()).padStart(2, "0");
  return `${year}-${month}-${day}`;
}

function SessionStatus() {
  const [s, setS] = useState<SessionInfo | null>(null);
  useEffect(() => {
    let mounted = true;
    fetchSession()
      .then((res) => { if (mounted) setS(res); })
      .catch(() => { /* ignore */ });
    const onSessionUpdated = (ev: Event) => {
      try {
        const custom = ev as CustomEvent | undefined;
        const sess = custom && custom.detail ? (custom.detail as SessionInfo) : null;
        if (sess) {
          if (mounted) setS(sess);
          return;
        }
      } catch (_) {}
      // fallback: re-fetch session
      fetchSession().then((res) => { if (mounted) setS(res); }).catch(() => {});
    };
    window.addEventListener('systeck-session-updated', onSessionUpdated as EventListener);

    return () => { mounted = false; window.removeEventListener('systeck-session-updated', onSessionUpdated as EventListener); };
  }, []);

  const formatExchangeRate = (value: number) =>
    Number(value).toFixed(3).replace(/(\.\d*?)0+$/, "$1").replace(/\.$/, "");

  if (!s) {
    return (
      <>
        <span className="shrink-0">Usuario: <b className="text-cyan-300">-</b></span>
        <span className="text-slate-500 shrink-0">/</span>
        <span className="shrink-0">Perfil: <b className="text-cyan-300">-</b></span>
      </>
    );
  }

  return (
    <>
      <span className="shrink-0">Usuario: <b className="text-cyan-300">{s.username}</b></span>
      <span className="text-slate-500 shrink-0">/</span>
      <span className="shrink-0">Perfil: <b className="text-cyan-300">{s.perfil}</b></span>
      <span className="text-slate-500 shrink-0">|</span>
      <span className="shrink-0">Fecha Proceso: <b className="text-amber-300">{s.fecha_transaccion}</b></span>
      <span className="text-slate-500 shrink-0">/</span>
      <span className="shrink-0">Tipo de Cambio Compra: <b className="text-amber-300">{formatExchangeRate(s.tipo_cambio_compra)}</b></span>
      <span className="text-slate-500 shrink-0">/</span>
      <span className="shrink-0">Venta: <b className="text-amber-300">{formatExchangeRate(s.tipo_cambio_venta)}</b></span>
    </>
  );
}

type MenuItem = { icon: any; label: string; iconKey?: string; openLabel?: string };
type MenuSection = { title: string; items: MenuItem[] };
type RibbonBtn = { icon: any; label: string; iconKey?: string; big?: boolean; dropdown?: boolean; menu?: MenuSection[]; openLabel?: string  };
type RibbonGroup = { title?: string; items: RibbonBtn[] };

const SMALL_COLOR_ICON_ALIASES: Record<string, string> = {
  // Conjuntos principales de cada pestaña (botones grandes / cabeceras)
  documentos: "books_256",
  "pre y post venta": "Compras",
  clientes: "cliente",
  cartera: "cartera__2_",
  requisiciones: "ValeRequisicion",
  consultas: "doc_elec_lupa",
  indicadores: "indicadorico32",
  tablero: "QuickPlay",
  almacen: "almacen",
  almacenes: "almacen",
  motores: "motores",
  transito: "detalle",
  mantenimiento: "actualizarCostos",
  reportes: "doc",
  compras: "Compras",
  control: "detalle",
  creditos: "creditos",
  aprobaciones: "Check",
  importaciones: "casa_aeropuerto",
  pedidos: "generar_mas",
  procesos: "Procesar",
  gerencia: "Indicadores1",
  servicios: "Tools",
  ventas: "cotizacion",
  asignaciones: "calendar",
  comunicaciones: "act_mail",
  rondas: "Buscar.ico",
  tesoreria: "CajaBanco",
  "caja chica": "bancos",
  telefonia: "equipo_telefonico",
  asignacion: "cliente",
  oportunidades: "cliente",
  activos: "inventario",
  tablas: "doc",
  login: "login",
  seguridad: "admin_48",
  usuarios: "User",
  encuestas: "doc",
  "inventario admin": "inventario",
  llamadas: "Llamada",
  "tablas generales": "doc",
  usuario: "cliente",
  ayuda: "help",

  // VENTAS - Documentos
  "guia remision": "GuiaRemision",
  "guias remision": "GuiaRemision",
  "guia devolucion": "GuiaDevolucion",
  factura: "Factura",
  boleta: "Boleta",
  notas: "Notas",
  "resumen de boletas": "Enviar_Pr",
  "resumen boletas": "Boleta",

  // VENTAS - Pre y Post Venta
  cotizaciones: "costos",
  "cotiz taller": "cotizacionTaller",
  "reclamo garantia": "reclamoGarantia",
  reclamos: "reclamoGarantia",
  "separar orden": "Separar__",
  "ordenes compra": "ordenesCompra",
  "ordenes de compra": "ordenesCompra",
  "actualizar vendedor": "vendedor",
  "enviar correos": "Enviar_Pr",

  // VENTAS - Requisiciones, Consultas, Precios
  despacho: "despacho",
  despachos: "vehiculo_ico",
  precios: "Dolar",
  "precios cliente": "precioCore",
  "precio core": "precioCore",
  "precio oferta": "Pagos",
  "precio lista": "Maximun",
  "precio fabricantes": "creditos",
  "factores rubros": "apor_planillas",
  "registro de venta": "registroAuxiliar",
  registro: "registro",
  "registro auxiliar": "RegistroAuxiliar",
  "resumen registro": "registroResumen",
  "mensuales x cliente": "brcase_48",
  "presupuesto venta": "pendiente_facturacion",
  detalle: "detalle",
  "detalle descuento": "Dscto",
  "g r pendiente": "GuiaRemision",
  "gr pendiente": "GuiaRemision",
  "vale requisicion": "valeRequisicion",
  vales: "valesMaterial",
  comisiones: "comision_ico",
  "doc ingresos": "Ingresos_Per",
  "doc salidas": "Descuentos_Per",
  docingresos: "Ingresos",
  docsalidas: "Ingresos",
  "chequeo f i": "chequeo",
  ti: "doc",
  "t i": "transferenciaInterna",
  mti: "movimiento",
  "m t i": "movimiento",
  "atender ot": "Report",
  "datos despacho clientes": "cliente",
  acumulada: "acumulada",
  "documentos emitidos": "documentosEmitidos",
  "cuentas x cobrar": "cuentasCobrar",
  anticipos: "Compra_Con",
  consignaciones: "Compra_Con",

  // ALMACENES
  transferencias: "transferenciaInterna",
  anulacion: "Anular_ico",
  "anulacion en consulta": "Rechazar",
  "anulación en consulta": "Anular_ico",
  productos: "mercaderia",
  "liqui gastos": "liquidacion",
  "act min max": "Maximun",
  ubicaciones: "CrdFle12",
  tarjetas: "CrdFle12",
  tarjeta: "CrdFle04",
  calendario: "calendar",
  "procesar cobertura": "Processs",
  inventario: "inventario",
  movimientos: "movimiento",
  "sin movimiento": "Maximun",
  "toma de inventario": "tomaInventario",
  "toma inventario": "tomaInventario",
  "vale materiales": "valesMaterial",
  "inv perm valorizado": "stockValorizado",
  "stock valorizado": "stockValorizado",
  "inv rotativo": "Act_2",
  "diario de almacen": "diarioAlmacen",
  "cuadrar cierre": "cuadrarCierre",
  "costo de venta": "costoVenta",
  "resumen general": "resumenGeneral",
  kardex: "CrdFle12",
  gmroi: "indicadores2",

  // CRÉDITOS
  "ctas x cobrar": "cuentasCobrar",
  letras: "letrasAceptadas",
  "letras aceptadas": "letrasAceptadas",
  planillas: "doc",
  "recepcion doc": "doc",
  "factores y descuentos": "Descuentos_Per",
  "saldo bancos": "bancos",
  "visitas cobrador": "cliente",
  "visita cobrador": "cliente",
  "procesar job": "ProcessJob",
  "vincular g r": "GuiaRemision",
  feriados: "Fecha",
  "tipo cambio ventas": "Dolar",
  "renueva tipo cambio": "Actualizar",
  "mantenimiento tipo de cambio": "Dolar",
  "permiso usuario": "admin_48",
  "detalle vencimientos": "vencimientoDetalle",
  "acumulado vencimientos": "vencimientoAcumulada",
  "diario de pagos": "diarioPago",
  "notas debito credito": "Notas",
  vencimientos: "vencimientoAcumulada",
  "cuentas corrientes": "cuentasCorrientes",
  sobregiro: "sobregiro",
  "040 creditos y cobranzas": "Pagos",

  // IMPORTACIONES
  embarque: "Embarque",
  "embarques de importacion": "Embarque",
  "orden importacion": "casa_aeropuerto",
  "ordenes de importacion": "Importacion",
  "orden de importacion": "pedidoImportacion",
  internos: "interno",
  "pedido interno": "Solic_Garantia",
  "010 importaciones": "Compras",

  // COSTOS
  productividad: "Provisional",
  proyeccion: "var_planillas",
  "movimiento repuestos": "mercaderia",
  "horas escalon": "ico_reloj4",
  "horas de trabajo": "ico_reloj32",
  "horas motor": "HorsExt2",
  "gastos detalle": "detalle",
  "gastos por rubros": "gasto_real_rubro",
  "gastos reales": "gasto_real_total",
  "gastos detallado": "gasto_real_total",
  "pendiente facturacion": "pendiente_facturacion",
  "liquidacion x garantia": "reclamoGarantia",
  "tiempo reparacion": "Material",
  "solicitud garantia": "Reembolso",
  "horas muertas": "mp_icon2",
  "horas de motores": "Motores",
  seguimientos: "doc_elec_lupa",
  seguimiento: "Job_Marca",
  "motores a dar de baja": "Motores",
  "disponibilidad del motor": "Motores",
  "repuestos a importar": "Compras",
  repuestos: "mercaderia",
  "ventas por mantenimiento": "cotizacion",
  "proyeccion de reparaciones": "Indicadores1",
  recalcular: "Recalcular",
  "ajustar costos": "ajustarCostos",
  "actualizar costos": "actualizarCostos",
  "valorizar f i": "CrdFle13",
  "trasladar costos": "trasladarCostos",
  "generar periodo": "generarPeriodo",
  "020 inventario y costos": "CrdFle12",

  // COMPRAS
  "solicitud de compra": "compra",
  "orden de compra": "Compras",
  "solicitud gasto": "Sol_Gastos",
  "solicitud gastos": "Sol_Gastos",
  "planilla viatico": "gasto_viaje",
  "tarifa gasto viaje": "Tarifas",
  "tarifa taxis casa": "importacion",
  "tarifas taxi destino": "Taxi",
  "cuentas x pagar": "ctas_ctes",
  "ctas x pagar": "diarioPago",
  "compras y o gastos": "Compra_Con",
  "pagos cuentas x pagar": "Pagos",
  "cuentas x pagar por unidad": "cuentasCorrientes",
  proveedores: "Compras",
  "generar pedido": "interno",
  "pedir repuestos": "Compras",

  // SERVICIOS
  "orden de trabajo": "Material",
  ot: "Material",
  "solicitud ot": "Check1",
  "marcar ot": "equipo_mar",
  "orden reparacion": "Solic_Garantia",
  "reclamo cliente": "reclamo_garantia",
  garantia: "reclamo_garantia",
  "control vehicular": "vehiculo_ico",
  kilometraje: "vehiculo_ico",
  actividades: "ACTIVITL",
  programacion: "ico_reloj2",
  plantilla: "plantillas",

  // PERSONAL
  informacion: "doc_elec_lupa",
  "ficha general": "workers",
  vacaciones: "vacaciones",
  capacitaciones: "Capacitacion",
  evaluaciones: "GRAPH07",
  "planilla sueldos": "Planillas_Sueldos",
  "quinta categoria": "cuenta_mas",
  faltas: "faltas_ico",
  marcacion: "mp_icon",
  "marcacion online": "equipo_mar",
  marcaciones: "mp_icon2",
  "pre marcacion": "PreMarcacion",
  "asigna h extra": "HorsExt2",
  "asig h extra": "HorsExt2",
  horarios: "Asig_Horario",
  "horas extras": "HE_icon2",
  ingresos: "Ingresos",
  descuentos: "Descuentos_Per",
  "jefe area": "Asig_Jefes",
  recursos: "Material",
  "cronograma mina": "Cargo_per",
  "admin lector": "LectorHuellas",
  "procesar marcas": "marca",
  asistencia: "Rep_Asistencia",
  tardanzas: "Rep_Tardanzas",
  personal: "rep_personal",
  contratos: "contrato",
  onomasticos: "torta",
  "asignacion horario": "Asig_Horario",
  "puntos control rutas": "marca",
  "ruteador rutas": "cliente",
  "lista de personal": "cliente",
  "oficina usuario": "editar2",

  // RONDAS
  "puntos control rondas": "bundle_256",
  ruteador: "vendedor",
  rutas: "bundle_256",
  "puntos control": "Ubicacion",

  // CONTABILIDAD
  asientos: "tes_asientos",
  "movimiento bancos": "bancos",
  "registro compra": "Reg_Compras",
  "registro de compras": "Reg_Compras",
  "recibo honorario": "workers",
  diario: "Cont_diario",
  provisional: "Provisional",
  provisionales: "precioCore",
  reembolso: "Reembolso",
  reembolsos: "rep_Reembolso",
  "arqueo caja": "arqueo_caja",
  "cuenta destino": "ajustarCostos",
  "cierre mes": "cuadrarCierre",
  "cerrar mes": "cerrarmes",
  "dif tipo cambio": "QuickPlay",
  "generar txt libros": "librosCont",
  "flujo de caja": "cuentasCobrar",
  "libros oficiales": "LibDiario2",
  "libro diario": "Cont_diario",
  "libro mayor": "mayor_aux",
  "caja y bancos": "CajaBanco",
  "ctas ctes": "ctas_ctes2",
  "ctas ctes pendiente": "ctas_ctes_pend",
  "mayor auxiliar": "LibMayor2",
  "estado financiero": "Balance",
  "estados financieros": "Balance",
  "cheques girados": "CajaBanco",
  "030 contabilidad": "books_256",

  // TELEFONÍA
  planes: "plan_telefonico",
  equipos: "equipo_telefonico",
  lineas: "linea_telefonica2",
  modelos: "modelos",
  "asigna persona": "Cargo_per",

  // CRM
  "oportunidad negocio": "cuadrarCierre",
  ocurrencias: "ocurrencias",
  "tarjeta cliente": "cliente",
  "visita clientes": "car_256",
  "cuota vendedor": "precioCore",

  // ACTIVOS
  "activos fijos": "Material",
  "reporte activos fijos": "cot_ico",

  // TABLAS
  "condicion de pago": "Cronograma_ico",
  "tipo motores": "motores",
  categorias: "clases",
  "precios core": "precioCore",
  partidas: "partidas",
  marcas: "marca",
  "plantilla repuestos": "Bloc_Notas",
  "plantilla repuestos cliente": "plantillas",
  "ubicacion servicio": "Buscar.ico",
  vehiculos: "car_256",
  "cuenta contable": "cuenta_mas",
  "cuentas destino": "proc_cta_dest",
  "rubro planilla": "ing_planillas",
  "rubro planilla ctas": "apor_planillas",
  afp: "Afp2",
  cargos: "Cargo_per",
  areas: "area_costo",
  "motivos faltas": "faltas_ico",
  "equipo lector": "equipo_mar",
  "tipo hora extra": "ing_per_mas",

  // LOGUEO
  "cerrar sesion": "Cerrar",
  "cambiar contrasena": "login",
  "cambiar contraseña": "login",
  "cambiar empresa": "Empresa",

  // ADMINISTRACIÓN
  perfiles: "workers",
  sesiones: "login",
  "atender solicitud": "ImgSendReceive",
  encuesta: "compra",
  resultado: "Cont_diario",
  "asignar computadora": "despacho",
  computadora: "laptop_48",
  "equipos marcacion personal": "equipo_mar",
  empresas: "Office2",
  "series documentos": "compra",
  locaciones: "Material",
  "rubros de productos": "mercaderia",
  "parametros locaciones": "cuenta_mas",
  "parametros planilla sueldos": "tes_asientos",
  "rubros x empresa": "Empresa",

  // AYUDA
  solicitud: "Enviar",
  "informacion cambios": "observacion",
  acerca: "about",
  "000 ventas": "bundle_256",
  "datos para indicadores": "indicadores2",
  "contenedor reportes": "adicionarcontenedor",
  "050 servicios": "Tools",
  "gastos viaje": "gasto_viaje",
  "gasto viaje x rubro": "gasto_viaje",
  "gua a remisia n": "GuiaRemision",
  "anulacia n en consulta": "Rechazar",
  "a reas": "area_costo",
  "equipos marcacia n personal": "equipo_mar",
  "asignacia n horario": "Asig_Horario",
  "marcacia n online": "equipo_mar",
  "mesa control": "Check",
  "liquidacia n x garantia": "reclamoGarantia",
  "tiempo reparacia n": "Material",
  "embarques de importacia n": "Embarque",
  "generar": "planillas",
};

const normalizeSmallColorIconKey = (value: string) =>
  value
    .replace(/\\n|\n/g, " ")
    .normalize("NFD")
    .replace(/[\u0300-\u036f]/g, "")
    .toLowerCase()
    .replace(/[^a-z0-9]+/g, " ")
    .trim();

const SMALL_COLOR_ICON_LOOKUP: Record<string, any> = Object.fromEntries(
  Object.entries(ICONOS_COLOR).map(([name, icon]) => [normalizeSmallColorIconKey(name), icon]),
);

function SmallColorIcon({ label, iconKey, className, size = 19 }: { label: string; iconKey?: string; className?: string; size?: number }) {
  const normalizedLabel = normalizeSmallColorIconKey(label);
  const mappedKey = iconKey ?? SMALL_COLOR_ICON_ALIASES[normalizedLabel] ?? normalizedLabel;
  const Icon = SMALL_COLOR_ICON_LOOKUP[normalizeSmallColorIconKey(mappedKey)] ?? SMALL_COLOR_ICON_LOOKUP.doc ?? ICONOS_COLOR.doc;

  return <Icon size={size} className={className} strokeWidth={1.8} />;
}

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
            { icon: FileEdit, label: "Cotizaciones", openLabel: "Cotizaciones Ventas" },
            { icon: Award, label: "Reclamo Garantía" },
            { icon: ArrowRightLeft, label: "Separar Orden" },
            { icon: ShoppingCart, label: "Ordenes Compra", openLabel: "Ordenes Compra Venta" },
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
            { icon: FileText, label: "Documentos", iconKey: "documentos", openLabel: "Documentos de Ventas" },
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
        { icon: Layers, label: "Precio Lista" },
        { icon: Percent, label: "Precio Oferta" },
        { icon: DollarSign, label: "Precio Fabricantes" },
        { icon: Factory, label: "Factores Rubros" },
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
        { icon: FileEdit, label: "Detalle" },
        { icon: FileCheck, label: "Acumulada" },
        { icon: ScrollText, label: "G/R Pendiente" },
        { icon: FileSearch, label: "Cotizaciones" },
        { icon: HandCoins, label: "Vale Requisición" },
        { icon: Users, label: "Mensuales x Cliente" },
        { icon: Percent, label: "Detalle Descuento" },
        { icon: Receipt, label: "Reclamos" },
        { icon: Boxes, label: "Órdenes Compra" },
        { icon: Package, label: "Consignaciones" },
        { icon: Truck, label: "Guías Remisión" },
        { icon: Wallet, label: "Presupuesto Venta" },
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
        { icon: ShoppingCart, label: "Compras", openLabel: "Compras Motores" },
      ],
    },
    {
      title: "Tránsito",
      items: [
        { icon: FileText, label: "Documentos", openLabel: "Documentos de Tránsito" },
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
        { icon: FileText, label: "Documentos", openLabel: "Documentos de Importación" },
      ],
    },
    {
      title: "Indicadores",
      items: [
        { icon: Calendar, label: "Calendario" },
        { icon: RefreshCw, label: "Procesar Cobertura" },
        { icon: LayoutGrid, label: "Tablero" },
      ],
    },
    {
      title: "Reportes",
      items: [
        { icon: Archive, label: "Inventario" },
        { icon: ClipboardCheck, label: "Toma de Inventario" },
        { icon: ArrowLeftRight, label: "Movimientos" },
        { icon: HandCoins, label: "Vale Materiales" },
        { icon: FileText, label: "Documentos" },
        { icon: PackageCheck, label: "Inv. Perm. Valorizado" },
        { icon: FileMinus, label: "Sin Movimiento" },
        { icon: ArrowRightLeft, label: "Transferencias" },
      ],
    },
  ],

  "Créditos": [
    {
      title: "Documentos",
      items: [
        { icon: HandCoins, label: "Ctas x Cobrar" },
        { icon: FileSpreadsheet, label: "Planillas" },
        { icon: UserCheck, label: "Anticipos" },
        { icon: ScrollText, label: "Letras" },
      ],
    },
    {
      title: "Aprobaciones",
      items: [
        { icon: BadgeCheck, label: "Créditos" },
        { icon: FileEdit, label: "Cotiz. Taller" },
        { icon: Lock, label: "Permiso Usuario" },
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
        { icon: FileText, label: "Documentos Emitidos" },
        { icon: BadgeCheck, label: "Letras Aceptadas" },
        { icon: FileEdit, label: "Notas Debito/Credito" },
        { icon: FileSpreadsheet, label: "Planillas" },
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
        { icon: FileEdit, label: "Cotizacion", openLabel: "Cotizacion Servicio" },
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
        { icon: LineChart, label: "Proyección", dropdown: true, menu: [
          { title: "Proyección", items: [
            { icon: FileText, label: "Horas de Motores" },
            { icon: FileText, label: "Seguimientos" },
            { icon: FileText, label: "Motores a dar de Baja" },
            { icon: FileText, label: "Disponibilidad del Motor" },
            { icon: FileSpreadsheet, label: "Repuestos a Importar" },
            { icon: FileCheck, label: "Ventas por mantenimiento" },
            { icon: FileCheck, label: "Proyección de Reparaciones" },
          ]},
        ] },
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
        { icon: Smartphone, label: "Modelos", openLabel: "Modelos Telefonía" },
        { icon: Phone, label: "Equipos" },
        { icon: Signal, label: "Planes" },
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
        { icon: AlertTriangle, label: "Ocurrencias" },
        { icon: IdCard, label: "Tarjeta Cliente" },
        { icon: MapPin, label: "Visita Clientes" },
        { icon: Percent, label: "Cuota Vendedor" },
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
        { icon: Layers, label: "Modelos", openLabel: "Modelos Almacenes" },
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
      ],
    },
    {
      title: "Personal",
      items: [
        { icon: FileSpreadsheet, label: "Rubro Planilla" },
        { icon: FileBarChart, label: "Rubro Planilla Ctas" },
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
        { icon: Circle, label: "Sesiones" },
      ],
    },
    {
      title: "Usuarios",
      items: [
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
      <SessionProvider>
        <DesktopAppInner />
      </SessionProvider>
    </WindowsProvider>
  );
}

function useNow() {
  const [now, setNow] = useState(new Date());
  useEffect(() => {
    const t = setInterval(() => setNow(new Date()), 1000);
    return () => clearInterval(t);
  }, []);
  return now;
}

const TAB_ACCENTS: Record<string, string> = {
  Ventas: "from-[#0F5FAA] to-[#0A3F73]",
  Almacenes: "from-[#0E7E52] to-[#08553A]",
  "Créditos": "from-[#A44900] to-[#6F3000]",
  "Importaciones": "from-[#1D4ED8] to-[#0B255F]",
  Costos: "from-[#7C3AED] to-[#4C1D95]",
  Gerencia: "from-[#0F172A] to-[#020617]",
  Servicios: "from-[#0891B2] to-[#164E63]",
  Compras: "from-[#B45309] to-[#78350F]",
  Personal: "from-[#DB2777] to-[#831843]",
  Rondas: "from-[#059669] to-[#064E3B]",
  Contabilidad: "from-[#4338CA] to-[#1E1B4B]",
  "Telefonía": "from-[#0284C7] to-[#0C4A6E]",
  CRM: "from-[#E11D48] to-[#881337]",
  Activos: "from-[#65A30D] to-[#365314]",
  Tablas: "from-[#525252] to-[#171717]",
  Logueo: "from-[#7C2D12] to-[#431407]",
  "Administración": "from-[#334155] to-[#0F172A]",
  Ayuda: "from-[#0369A1] to-[#075985]",
};

function DesktopAppInner() {
  const [active, setActive] = useState("Ventas");
  const ribbon = RIBBONS[active] ?? RIBBONS.Ventas;
  const [ribbonMode, setRibbonMode] = useState<"expanded" | "hidden" | "overlay">("expanded");
  const [notificationsOpen, setNotificationsOpen] = useState(false);
  const [notificationsClosing, setNotificationsClosing] = useState(false);
  const notificationCloseTimer = useRef<number | null>(null);
  const [notifications, setNotifications] = useState([
    { id: 1, title: "Factura aceptada por SUNAT", detail: "F001-000488 recibió CDR código 0.", time: "Hace 5 min", kind: "ok", read: false, target: "Factura" },
    { id: 2, title: "Stock por debajo del mínimo", detail: "SKU-3390 tiene 2 unidades disponibles.", time: "Hace 18 min", kind: "warn", read: false, target: "Guía Remisión" },
    { id: 3, title: "Resumen diario pendiente", detail: "128 boletas están listas para consolidar.", time: "Hace 1 h", kind: "info", read: false, target: "Resumen de Boletas" },
    { id: 4, title: "Guía entregada", detail: "T001-000842 fue confirmada por almacén.", time: "Ayer", kind: "ok", read: true, target: "Guía Remisión" },
  ]);
  const unreadCount = notifications.filter(notification => !notification.read).length;

  useEffect(() => {
    if (typeof document === "undefined") return;
    const prevOverflow = document.body.style.overflow;
    document.body.style.overflow = notificationsOpen ? "hidden" : prevOverflow;
    return () => {
      document.body.style.overflow = prevOverflow;
    };
  }, [notificationsOpen]);

  useEffect(() => {
    return () => {
      if (notificationCloseTimer.current !== null) {
        window.clearTimeout(notificationCloseTimer.current);
      }
    };
  }, []);

  const closeNotifications = () => {
    if (!notificationsOpen || notificationsClosing) return;
    if (window.matchMedia("(prefers-reduced-motion: reduce)").matches) {
      setNotificationsClosing(false);
      setNotificationsOpen(false);
      return;
    }
    setNotificationsClosing(true);
    if (notificationCloseTimer.current !== null) {
      window.clearTimeout(notificationCloseTimer.current);
    }
    notificationCloseTimer.current = window.setTimeout(() => {
      setNotificationsOpen(false);
      setNotificationsClosing(false);
      notificationCloseTimer.current = null;
    }, 220);
  };
  const toggleNotifications = () => {
    if (notificationsOpen) {
      closeNotifications();
      return;
    }
    if (notificationCloseTimer.current !== null) {
      window.clearTimeout(notificationCloseTimer.current);
      notificationCloseTimer.current = null;
    }
    setNotificationsClosing(false);
    setNotificationsOpen(true);
  };
  const [now, setNow] = useState("");
  const { isDesktop, minimize, maximize, close } = useDesktopMode();
  const { open: openWindow, windows, active: activeWindowId, close: closeWindow, focus: focusWindow, toggleFromTaskbar } = useWindows();
  const params = typeof window !== "undefined" ? new URLSearchParams(window.location.search) : new URLSearchParams();
  const [recover, setRecover] = useState(false);
  const [starred, setStarred] = useState(false);
  const [cpuLoad, setCpuLoad] = useState(23);
  const [memLoad, setMemLoad] = useState(48);
  const accent = TAB_ACCENTS[active] ?? "from-[#3A5573] to-[#243B55]";
  const popupLabel = params.get("popup");
  const loginMode = params.get("login") === "1";
  const [desktopAuthenticated, setDesktopAuthenticated] = useState(false);
  const [desktopReady, setDesktopReady] = useState(false);
  const [busy, setBusy] = useState(false);
  const [user, setUser] = useState("");
  const [pass, setPass] = useState("");
  const [ribbonMinimized, setRibbonMinimized] = useState(false);
  const [ribbonBelow, setRibbonBelow] = useState(false);
  const [ribbonMenu, setRibbonMenu] = useState<{ x: number; y: number } | null>(null);
  const [fecha, setFecha] = useState("");
  const [tc, setTc] = useState("");
  const [tcLoading, setTcLoading] = useState(false);
  const tipoCambioRequestId = useRef(0);
  const [sucursal, setSucursal] = useState("");
  const [showPass, setShowPass] = useState(false);
  const [capsOn, setCapsOn] = useState(false);
  const [companyPickerOpen, setCompanyPickerOpen] = useState(false);
  const [selectedCompany, setSelectedCompany] = useState<Company | null>(null);
  const sessionCtx = useSession();


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
    let mounted = true;

    if (isDesktop) {
      setDesktopAuthenticated(false);
      setDesktopReady(false);
    } else {
      setDesktopAuthenticated(true);
      setDesktopReady(true);
    }

    (async () => {
      try {
        const session = await fetchSession();
        if (!mounted) return;
        if (loginMode) {
          setUser("");
        } else {
          setUser(session.username || "");
        }
        setFecha(toDateInputValue(new Date().toLocaleDateString("es-PE")));

        // Set selected company from session if provided by backend
        if (session.empresa_actual) {
          setSelectedCompany({
            codigo: session.empresa_actual.codigo || "",
            nombre: session.empresa_actual.nombre || session.empresa_actual.descripcion || "",
            ruc: session.empresa_actual.ruc ?? null,
            descripcion: session.empresa_actual.descripcion ?? null,
          });
        }

        if (Array.isArray(session.empresas) && session.empresas.length > 1) {
          setCompanyPickerOpen(true);
        }

        // If backend reports an active session, mark desktop as authenticated
        // but do NOT automatically authenticate when we're rendering the
        // small login window (loginMode). The small window should always
        // show the login UI so the user can enter credentials there.
        if (session && session.username && !loginMode) {
          setDesktopAuthenticated(true);
        }

        // Prefer venta on the login window, otherwise use compra
        const sessionTc = loginMode ? session.tipo_cambio_venta : session.tipo_cambio_compra;
        if (sessionTc != null && Number.isFinite(sessionTc)) {
          setTc(sessionTc.toFixed(3));
        } else {
          // if adapter already set tc, keep it; otherwise clear
          setTc((prev) => (prev ? prev : ""));
        }
      } catch (e) {
        if (!mounted) return;
        setTc("");
      } finally {
        if (!mounted) return;
        setDesktopReady(true);
      }
    })();

    return () => {
      mounted = false;
    };
  }, [isDesktop, loginMode]);

  useEffect(() => {
    if (!isDesktop || desktopAuthenticated || !fecha) return;

    let activeRequest = true;
    const requestId = ++tipoCambioRequestId.current;
    setTc("");
    setTcLoading(true);

    fetchTipoCambio(fecha, selectedCompany?.codigo)
      .then((tipoCambio) => {
        if (!activeRequest || requestId !== tipoCambioRequestId.current) return;
        setTc(tipoCambio.tipo_cambio_venta.toFixed(3));
      })
      .catch((error: unknown) => {
        if (!activeRequest || requestId !== tipoCambioRequestId.current) return;
        setTc("");
        toast.error("No se pudo consultar el tipo de cambio", {
          description: error instanceof Error ? error.message : "Verifica la conexión con SIGECOM.",
        });
      })
      .finally(() => {
        if (activeRequest && requestId === tipoCambioRequestId.current) setTcLoading(false);
      });

    return () => {
      activeRequest = false;
      if (requestId === tipoCambioRequestId.current) tipoCambioRequestId.current++;
    };
  }, [desktopAuthenticated, fecha, isDesktop, selectedCompany?.codigo]);

  useEffect(() => {
    if (!popupLabel) {
      const companyName = selectedCompany?.nombre.trim() || "C2TECK S.A.C.";
      document.title = `Systeck (Versión 10.6.30) — ${companyName}`;
    }
  }, [popupLabel, selectedCompany?.nombre]);

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

  const submit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    if (!fecha) {
      toast.error("Selecciona la fecha de proceso.");
      return;
    }
    if (tcLoading || !Number.isFinite(Number(tc)) || Number(tc) <= 0) {
      toast.error("No existe Tipo de Cambio para esta fecha, no puede ingresar.");
      return;
    }
    setBusy(true);

    try {
      const session = await login(user.trim(), pass, fecha);
      localStorage.setItem("sigecoom_session", JSON.stringify(session));
      setUser(session.username || "");
      setFecha(toDateInputValue(session.fecha_transaccion) || fecha);

      // Set selected company from session if provided
      if (session.empresa_actual) {
        setSelectedCompany({
          codigo: session.empresa_actual.codigo || "",
          nombre: session.empresa_actual.nombre || session.empresa_actual.descripcion || "",
          ruc: session.empresa_actual.ruc ?? null,
          descripcion: session.empresa_actual.descripcion ?? null,
        });
      }

      if (Array.isArray(session.empresas) && session.empresas.length > 1) {
        setCompanyPickerOpen(true);
      }

      const loginTc = session.tipo_cambio_venta ?? session.tipo_cambio_compra;
      if (loginTc != null && Number.isFinite(loginTc)) {
        setTc(loginTc.toFixed(3));
      } else {
        setTc("");
      }

      setDesktopAuthenticated(true);
      toast.success("Bienvenido a Systeck", { description: `Usuario ${session.username} · Perfil ${session.perfil}` });
      window.c2teckDesktop?.loginSuccess?.();
    } catch (error: any) {
      toast.error("No se pudo iniciar sesión", {
        description: error?.message ?? "No se pudo validar el usuario en el servicio SIGECOM original.",
      });
    } finally {
      setBusy(false);
    }
  };

  const inputCls = "h-9 w-full rounded border border-slate-300 bg-white px-3 text-sm text-slate-900 outline-none transition focus:border-slate-500 focus:ring-2 focus:ring-slate-300";

  const openDesktopWindow = (label: string) => {
    // Siempre abrir ventanas simuladas dentro del MDI del escritorio.
    openWindow(label);
  };

  if (popupLabel && isDesktop) {
    return <DesktopPopoutWindow label={popupLabel} onClose={close} />;
  }

  // When running inside the native desktop host we should allow the
  // React UI to render normally so session/login flows work. Previously
  // this returned a blank full-screen div which prevented the login
  // and main UI from ever appearing in desktop mode.

  // Do not block rendering while `desktopReady` is false — rendering
  // the app immediately avoids a blank screen during startup/login.

  if (isDesktop && !desktopAuthenticated) {
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
        tcLoading={tcLoading}
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
        ? "bg-[#DDE4EC] p-0 m-0 flex items-stretch justify-stretch"
        : "bg-slate-900 p-2 sm:p-6 flex items-center justify-center",
    ].join(" ")}>
      {companyPickerOpen && (
        <CompanyPickerModal
          current={selectedCompany}
          onCancel={() => setCompanyPickerOpen(false)}
          onAccept={async (company) => {
            setSelectedCompany(company);
            setCompanyPickerOpen(false);
            try {
              if (sessionCtx && sessionCtx.changeCompany) {
                await sessionCtx.changeCompany(company.codigo);
              }
            } catch (_) {}
            toast.success("Empresa actualizada", { description: `${company.nombre} (${company.codigo})` });
          }}
        />
      )}
      {/* Ventana */}
      <div className={[
        "w-full h-full flex flex-col bg-[#DDE4EC] text-slate-800 overflow-visible",
        isDesktop
          ? "h-screen rounded-none shadow-none border-0"
          : "max-w-[1400px] rounded-lg shadow-2xl border border-slate-700",
      ].join(" ")}>
        <div
          className="relative z-30 h-8 bg-white flex items-center justify-between px-0 text-white text-xs select-none"
          style={{ ["WebkitAppRegion" as any]: "drag" } as React.CSSProperties}
          onDoubleClick={() => {
            if (isDesktop) {
              void maximize();
            }
          }}
        >
          <div className="absolute left-1/2 -translate-x-1/2 font-semibold tracking-tight text-[12px] text-slate-900">
            Systeck ERP
          </div>
          <div className="ml-auto flex items-center" style={{ ["WebkitAppRegion" as any]: "no-drag" } as React.CSSProperties}>
            <button onClick={toggleNotifications} aria-expanded={notificationsOpen && !notificationsClosing} title="Notificaciones" className={`group/notice h-10 w-10 grid place-items-center relative text-slate-700 transition-all duration-200 active:scale-90 ${notificationsOpen && !notificationsClosing ? "bg-slate-900/10" : "hover:bg-slate-900/5"}`}>
              <Bell className={`h-3.5 w-3.5 group-hover/notice:desktop-bell-ring ${notificationsOpen && !notificationsClosing ? "desktop-bell-ring" : ""}`} />
              {unreadCount > 0 && <span className="desktop-badge-pulse absolute right-1.5 top-1 flex h-4 min-w-4 items-center justify-center rounded-full border border-white bg-red-500 px-1 text-[8px] font-bold text-white shadow-lg">{unreadCount}</span>}
            </button>
            <button title="Ayuda" className="h-10 w-10 text-slate-700 hover:bg-slate-900/5 grid place-items-center transition-all duration-200 active:scale-90">
              <HelpCircle className="h-3.5 w-3.5" />
            </button>
            <div className="h-5 w-px bg-white/15 mx-1" />
            <button
              type="button"
              onClick={isDesktop ? minimize : undefined}
              style={{ ["WebkitAppRegion" as any]: "no-drag" } as React.CSSProperties}
              className="h-10 w-11 text-slate-700 hover:bg-slate-900/10 grid place-items-center transition-all duration-150 active:scale-90"
              ><Minus className="h-3.5 w-3.5" /></button>
            <button
              type="button"
              onClick={isDesktop ? maximize : undefined}
              style={{ ["WebkitAppRegion" as any]: "no-drag" } as React.CSSProperties}
              className="h-10 w-11 text-slate-700 hover:bg-slate-900/10 grid place-items-center transition-all duration-150 active:scale-90"
              ><Square className="h-3 w-3" /></button>
            <button
              type="button"
              onClick={isDesktop ? close : undefined}
              style={{ ["WebkitAppRegion" as any]: "no-drag" } as React.CSSProperties}
              className="h-10 w-11 text-slate-700 hover:bg-red-600 hover:text-white grid place-items-center transition-all duration-150 active:scale-90"
              ><X className="h-4 w-4" /></button>
          </div>
        </div>

        {notificationsOpen && (
          <>
            <button aria-label="Cerrar notificaciones" className={`${notificationsClosing ? "desktop-overlay-out" : "desktop-overlay-in"} fixed inset-0 z-40 cursor-default bg-slate-950/5 backdrop-blur-[1px]`} onClick={closeNotifications} />
            <aside className={`${notificationsClosing ? "desktop-notification-out" : "desktop-notification-in"} absolute right-2 top-12 z-50 flex max-h-[min(560px,calc(100vh-100px))] w-[360px] max-w-[calc(100vw-24px)] flex-col overflow-hidden rounded-xl border border-white/70 bg-white/90 backdrop-blur-xl shadow-[0_28px_80px_-22px_rgba(2,8,23,0.65),0_0_0_1px_rgba(148,163,184,0.18)]`}>
              <div className="flex items-start gap-3 border-b border-slate-200 bg-[#0B1220] px-4 py-4 text-white">
                <div className="grid h-9 w-9 place-items-center rounded-lg border border-cyan-300/30 bg-cyan-300/10 text-cyan-300"><Bell className="h-4 w-4" /></div>
                <div><h2 className="text-sm font-bold">Centro de notificaciones</h2><p className="mt-0.5 text-[10px] text-slate-400">Alertas operativas en tiempo real</p></div>
                <button title="Cerrar" onClick={closeNotifications} className="ml-auto grid h-8 w-8 place-items-center rounded-md text-slate-400 hover:bg-white/10 hover:text-white"><CloseIcon className="h-4 w-4" /></button>
              </div>
              <div className="flex items-center gap-2 border-b border-slate-200 bg-slate-50 px-4 py-2.5">
                <span className="rounded-md bg-cyan-100 px-2 py-1 text-[10px] font-bold text-cyan-800">{unreadCount} NUEVAS</span>
                <button onClick={() => setNotifications(items => items.map(item => ({ ...item, read: true })))} className="ml-auto inline-flex items-center gap-1.5 text-[10px] font-semibold text-slate-600 hover:text-cyan-700"><CheckCheck className="h-3.5 w-3.5" />Marcar todas como leídas</button>
              </div>
              <div className="no-scrollbar min-h-0 overflow-y-auto">
                {notifications.map(notification => {
                  const NoticeIcon = notification.kind === "warn" ? AlertIcon : notification.kind === "ok" ? CheckCircle2 : PackageAlert;
                  return <button key={notification.id} style={{ "--notice-index": notification.id - 1 } as CSSProperties} onClick={() => { setNotifications(items => items.map(item => item.id === notification.id ? { ...item, read: true } : item)); openWindow(notification.target); closeNotifications(); }} className={`desktop-notice-row group flex w-full gap-3 border-b border-slate-100 p-4 text-left transition duration-300 hover:translate-x-0.5 hover:bg-cyan-50/70 ${notification.read ? "bg-white opacity-70" : "bg-cyan-50/25"}`}>
                    <div className={`grid h-9 w-9 shrink-0 place-items-center rounded-lg transition-transform duration-300 group-hover:scale-110 ${notification.kind === "warn" ? "bg-amber-100 text-amber-700" : notification.kind === "ok" ? "bg-emerald-100 text-emerald-700" : "bg-cyan-100 text-cyan-700"}`}><NoticeIcon className="h-4 w-4" /></div>
                    <div className="min-w-0 flex-1"><div className="flex items-start gap-2"><span className="text-[11px] font-bold text-slate-900">{notification.title}</span>{!notification.read && <span className="mt-1 h-1.5 w-1.5 shrink-0 rounded-full bg-cyan-500" />}</div><p className="mt-1 text-[10px] leading-relaxed text-slate-600">{notification.detail}</p><span className="mt-2 block text-[9px] font-semibold uppercase text-slate-400">{notification.time} · Abrir operación</span></div>
                  </button>;
                })}
              </div>
              <div className="border-t border-slate-200 bg-slate-50 p-3 text-center text-[10px] font-medium text-slate-500">Sistema actualizado · monitoreo activo</div>
            </aside>
          </>
        )}

        {/* Quick access + tabs */}
        <div
          onContextMenu={(e) => { e.preventDefault(); setRibbonMenu({ x: e.clientX, y: e.clientY }); }}
          className="shrink-0 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] flex items-stretch relative z-30"
        >
          <AppOrb
            companyName={selectedCompany?.nombre}
            onSwitchCompany={() => {
              setCompanyPickerOpen(true);
              toast.success("Empresa", { description: "Se abrió la selección de empresa." });
            }}
            onCloseApp={() => {
              if (isDesktop) {
                toast.success("Cerrando aplicación…");
                setTimeout(() => close(), 250);
                return;
              }

              toast.success("Volviendo al sitio…");
              setTimeout(() => { window.location.href = "/"; }, 300);
            }}
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

        {/* Ribbon animado (in-flow, mantiene el comportamiento original) */}
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
      <AnimatePresence mode="wait" initial={false}>
        <motion.div
          key={active}
          initial={{ opacity: 0, y: 4 }}
          animate={{ opacity: 1, y: 0, transition: EASE_OUT }}
          exit={{ opacity: 0, transition: EASE_FAST }}
          transition={{ duration: 0.18 }}
          className="h-full w-full"
        >
          <RibbonContent ribbon={ribbon} openDesktopWindow={openDesktopWindow} />
        </motion.div>
      </AnimatePresence>
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

        <div className="shrink-0 border-t border-slate-900/80 bg-[#060B13]">
          <div className="shrink-0 h-9 bg-gradient-to-b from-[#0a1220] to-[#060911] border-t border-[#00E5FF]/20 border-b border-white/70 flex items-center gap-1 px-2 overflow-x-auto">
            <div className="flex items-center gap-1.5 mr-2 pr-2 border-r border-slate-700/60">
              <span className="h-2 w-2 rounded-full bg-emerald-400 shadow-[0_0_6px_#10B981]" />
              <span className="text-[10px] font-mono text-slate-400 tracking-wider uppercase">Systeck MDI</span>
            </div>
            {windows.length === 0 && (
              <span className="text-[10.5px] font-mono text-slate-600">— sin ventanas abiertas —</span>
            )}
            {windows.map((w) => {
              const isActive = w.id === activeWindowId && !w.isMinimized;
              return (
                <div
                  key={w.id}
                  onClick={() => focusWindow(w.id)}
                  className={[
                    "group shrink-0 flex items-center h-7 rounded-sm border overflow-hidden transition-colors",
                    isActive
                      ? "bg-[#00E5FF]/15 border-[#00E5FF]/50 shadow-[inset_0_-2px_0_0_#00E5FF]"
                      : w.isMinimized
                        ? "bg-slate-800/60 border-slate-700/50 opacity-70 hover:opacity-100"
                        : "bg-slate-800/40 border-slate-700/60 hover:bg-slate-700/60",
                  ].join(" ")}
                >
                  <button
                    onClick={() => toggleFromTaskbar(w.id)}
                    className="flex items-center gap-1.5 px-2 h-full text-[11px] font-mono text-slate-200 max-w-[180px]"
                    title={w.isMinimized ? "Restaurar" : (isActive ? "Minimizar" : "Traer al frente")}
                  >
                    <span className={`h-1.5 w-1.5 rounded-full ${isActive ? "bg-[#00E5FF]" : w.isMinimized ? "bg-amber-400" : "bg-slate-400"}`} />
                    <span className="truncate">{w.label}</span>
                    {w.isMinimized && <span className="ml-1 text-[9px] px-1 rounded bg-amber-500/20 text-amber-300 border border-amber-500/30">MIN</span>}
                  </button>
                  <button
                    onClick={(e) => {
                      e.stopPropagation();
                      closeWindow(w.id);
                    }}
                    className="h-full w-6 grid place-items-center text-slate-500 hover:bg-red-600/80 hover:text-white"
                    title="Cerrar"
                  >
                    <X className="h-3 w-3" />
                  </button>
                </div>
              );
            })}
            <div className="ml-auto flex items-center gap-2 pl-2 border-l border-slate-700/60 shrink-0">
              <span className="text-[10px] font-mono text-slate-500">
                {windows.length} ventana{windows.length === 1 ? "" : "s"} • {windows.filter((w) => w.isMinimized).length} min.
              </span>
            </div>
          </div>

          <div className="h-7 px-2 flex items-center gap-2 overflow-x-auto text-[10.5px] text-slate-200 font-mono">
            <SessionStatus />
            <span className="text-slate-500 shrink-0">|</span>
            <span className="shrink-0 inline-flex items-center gap-1.5 px-1.5 h-5 rounded border border-indigo-400/40 bg-indigo-500/10 text-indigo-200">
              <Zap className="h-2.5 w-2.5 text-cyan-300 animate-pulse" />
              <span>Systeck-AI Core: <b className="text-emerald-300">ONLINE</b></span>
            </span>
            <span className="shrink-0 inline-flex items-center gap-1 px-1.5 h-5 rounded border border-cyan-400/40 bg-cyan-500/10 text-cyan-200">
              GPU Usage: <b className="text-cyan-100">24%</b>
            </span>
            <span className="shrink-0 inline-flex items-center gap-1 px-1.5 h-5 rounded border border-cyan-400/40 bg-cyan-500/10 text-cyan-200">
              Model Latency: <b className="text-cyan-100">12ms</b>
            </span>
          </div>
        </div>
      </div>

      {isDesktop && desktopReady && !desktopAuthenticated && (
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
          tcLoading={tcLoading}
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
  tcLoading,
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
  tcLoading: boolean;
  onSucursalChange: (value: string) => void;
  onToggleShowPass: () => void;
  onCapsChange: (value: boolean) => void;
}) {
  const inputCls = "h-9 rounded-md border border-slate-300 bg-white px-3 text-sm text-slate-900 outline-none transition focus:border-slate-500 focus:ring-2 focus:ring-slate-300 flex-1";
  const [recover, setRecover] = useState(false);
  return (
    <div className={`h-screen w-screen overflow-hidden bg-[#F1F4F9] ${busy ? "cursor-wait" : ""}`}>
      <form onSubmit={onSubmit} className="flex h-full w-full flex-col rounded-none overflow-hidden border-0 shadow-none bg-[#F1F4F9]">
        <div
          className="relative z-30 h-10 bg-white flex items-center justify-between pl-2.5 pr-0 text-slate-900 text-xs select-none border-b border-slate-300"
          style={{ ["WebkitAppRegion" as any]: "drag" } as React.CSSProperties}
          onDoubleClick={() => {
            if (typeof window !== "undefined") {
              window.c2teckDesktop?.maximize?.();
            }
          }}
        >
          <div className="absolute left-1/2 -translate-x-1/2 font-semibold tracking-tight text-[12px] text-slate-900">
            Systeck ERP
          </div>
          <div className="ml-auto flex items-center" style={{ ["WebkitAppRegion" as any]: "no-drag" } as React.CSSProperties}>
            <button
              type="button"
              onClick={() => window.c2teckDesktop?.minimize?.()}
              className="h-10 w-11 text-slate-700 hover:bg-slate-900/10 grid place-items-center transition-all duration-150 active:scale-90"
              title="Minimizar"
            >
              <Minus className="h-3.5 w-3.5" />
            </button>
            <button
              type="button"
              onClick={() => window.c2teckDesktop?.maximize?.()}
              className="h-10 w-11 text-slate-700 hover:bg-slate-900/10 grid place-items-center transition-all duration-150 active:scale-90"
              title="Maximizar"
            >
              <Square className="h-3 w-3" />
            </button>
            <button
              type="button"
              onClick={() => window.c2teckDesktop?.close?.() ?? window.close()}
              className="h-10 w-11 text-slate-700 hover:bg-red-600 hover:text-white grid place-items-center transition-all duration-150 active:scale-90"
              title="Cerrar"
            >
              <X className="h-4 w-4" />
            </button>
          </div>
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
                <input
                  value={user}
                  onChange={(e) => onUserChange(e.target.value)}
                  className={inputCls}
                  placeholder="Ingrese usuario"
                />
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
                <input
                  type="date"
                  lang="es-PE"
                  required
                  value={fecha}
                  onChange={(e) => onFechaChange(e.target.value)}
                  className={inputCls}
                />
              </label>
              <label className="flex items-center gap-3">
                <DollarSign className="h-3.5 w-3.5 text-slate-500 shrink-0" />
                <span className="text-[11.5px] text-slate-700 w-20 shrink-0">Tipo de Cambio</span>
                <input value={tc} readOnly aria-busy={tcLoading} placeholder={tcLoading ? "Consultando..." : "0.000"} className={inputCls} />
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
  const [expandedItem, setExpandedItem] = useState<string | null>(null);
  const btnRef = useRef<HTMLButtonElement>(null);
  const [pos, setPos] = useState<{ left: number; top: number } | null>(null);
  const { open: openWindow } = useWindows();

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
        <motion.button
          ref={btnRef}
          onClick={toggle}
          title={label}
          whileHover={{ scale: 1.02, y: -1 }}
          whileTap={{ scale: 0.97, y: 0 }}
          transition={{ duration: 0.12 }}
          className={[
            "flex flex-col items-center justify-center gap-1 rounded border w-[64px] h-[72px] px-1.5 press-fx",
            open
              ? "bg-gradient-to-b from-[#FCE9A8] to-[#F5C86A] border-[#B8892E] shadow-inner"
              : "border-transparent hover:bg-[#DDE7F3] hover:border-[#7FA8D6]",
          ].join(" ")}
        >
          <SmallColorIcon label={label} size={30} className="shrink-0 drop-shadow-[0_1px_1px_rgba(15,23,42,0.15)] transition-transform" />
          <span className="text-[10.5px] leading-tight text-center whitespace-pre text-slate-800 font-bold">{label}</span>
          <ChevronDown className="h-2.5 w-2.5 text-slate-600" />
        </motion.button>
      </div>
      {open && pos && createPortal(
        <>
          <div className="fixed inset-0 z-40" onClick={() => { setOpen(false); setExpandedItem(null); }} />
          <div
            className="fixed z-50 bg-[#F3F6FA] border border-slate-400/70 shadow-xl rounded-sm p-2 min-w-[220px] max-w-[calc(100vw-16px)] max-h-[calc(100vh-16px)] overflow-y-auto"
            style={{ left: Math.min(pos.left, window.innerWidth - 236), top: Math.min(pos.top, window.innerHeight - 120) }}
          >
            <div className="flex flex-col gap-0.5 px-1 py-1">
              {group.items.map((item, itemIndex) => (
                <div key={`${item.label}-${itemIndex}`}>
                  <button
                    onClick={() => {
                      if (item.menu) {
                        setExpandedItem(current => current === item.label ? null : item.label);
                      } else {
                        openWindow(item.openLabel ?? item.label.replace(/\n/g, " "));
                        setOpen(false);
                        setExpandedItem(null);
                      }
                    }}
                    aria-expanded={item.menu ? expandedItem === item.label : undefined}
                    className={[
                      "flex w-full items-center gap-2 px-1.5 py-1 rounded hover:bg-[#DDE7F3] hover:border-[#7FA8D6] border text-left",
                      expandedItem === item.label ? "bg-gradient-to-b from-[#FCE9A8] to-[#F5C86A] border-[#B8892E]" : "border-transparent",
                    ].join(" ")}
                  >
                    <SmallColorIcon label={item.label} iconKey={item.iconKey} className="h-4 w-4 shrink-0" size={16} />
                    <span className="text-[11.5px] text-slate-800 whitespace-nowrap flex-1">{item.label.replace(/\n/g, " ")}</span>
                    {item.menu && <ChevronDown className="h-3 w-3 text-slate-600 shrink-0" />}
                  </button>
                  {expandedItem === item.label && item.menu?.map((section, sectionIndex) => (
                    <div key={`${section.title}-${sectionIndex}`} className="ml-3 pl-2 border-l border-slate-300 py-0.5">
                      {section.items.map((subitem, subitemIndex) => (
                <button
                          key={`${subitem.label}-${subitemIndex}`}
                          onClick={() => { openWindow(subitem.openLabel ?? subitem.label); setOpen(false); setExpandedItem(null); }}
                          className="flex w-full items-center gap-2 px-1.5 py-1 rounded border border-transparent hover:bg-[#DDE7F3] hover:border-[#7FA8D6] text-left"
                        >
                          <SmallColorIcon label={subitem.label} iconKey={subitem.iconKey} className="h-4 w-4 shrink-0" size={16} />
                          <span className="text-[11.5px] text-slate-800 whitespace-nowrap font-bold">{subitem.label}</span>
                        </button>
                      ))}
                    </div>
                  ))}
                </div>
              ))}
            </div>
          </div>
        </>,
        document.body,
      )}
    </div>
  );
}

function AppOrb({ companyName, onSwitchCompany, onCloseApp }: { companyName?: string; onSwitchCompany: () => void; onCloseApp: () => void }) {
  const [open, setOpen] = useState(false);
  const ref = useRef<HTMLDivElement>(null);
  useEffect(() => {
    if (!open) return;
    const onDoc = (e: MouseEvent) => { if (!ref.current?.contains(e.target as Node)) setOpen(false); };
    document.addEventListener("mousedown", onDoc);
    return () => document.removeEventListener("mousedown", onDoc);
  }, [open]);
  return (
    <div ref={ref} className="relative z-40 shrink-0 flex items-center pl-0 pr-0">
      <button
        onClick={() => setOpen(v => !v)}
        title="Menú de aplicación"
        style={{ ["WebkitAppRegion" as any]: "no-drag" } as React.CSSProperties}
        className={`group relative -translate-y-4.5 grid h-9 w-9 place-items-center rounded-full ring-1 ring-slate-900/40 bg-[radial-gradient(circle_at_32%_28%,#FFFFFF_0%,#E4ECF5_35%,#A9B8CB_70%,#6B7C93_100%)] shadow-[inset_0_1px_1.5px_rgba(255,255,255,0.9),inset_0_-3px_5px_rgba(30,45,70,0.45),inset_0_0_0_1px_rgba(255,255,255,0.15),0_2px_3px_rgba(0,0,0,0.35),0_4px_10px_rgba(0,0,0,0.25)] transition-all duration-200 hover:bg-[radial-gradient(circle_at_32%_28%,#FFF9D6_0%,#FFD966_35%,#C9962A_72%,#7A5A10_100%)] hover:ring-amber-700/60 hover:shadow-[inset_0_1px_1.5px_rgba(255,255,255,0.95),inset_0_-3px_6px_rgba(90,55,5,0.55),inset_0_0_0_1px_rgba(255,220,120,0.35),0_0_14px_rgba(245,196,64,0.6),0_2px_4px_rgba(0,0,0,0.4)] ${open ? "ring-2 ring-amber-500 bg-[radial-gradient(circle_at_32%_28%,#FFF9D6_0%,#FFD966_35%,#C9962A_72%,#7A5A10_100%)]" : ""}`}
      >
        <img src={systeckIcon} alt="Systeck" className="relative z-10 h-6 w-6 object-contain drop-shadow-[0_1px_1px_rgba(0,0,0,0.55)]" />
        <span aria-hidden className="pointer-events-none absolute inset-0 overflow-hidden rounded-full">
          <span className="absolute left-[14%] right-[14%] top-[6%] h-[42%] rounded-full bg-[radial-gradient(ellipse_at_center,rgba(255,255,255,0.85)_0%,rgba(255,255,255,0.35)_45%,rgba(255,255,255,0)_75%)] blur-[0.5px]" />
        </span>
        <span aria-hidden className="pointer-events-none absolute inset-0 rounded-full shadow-[inset_0_-1px_0_rgba(255,255,255,0.25)]" />
      </button>
      {open && (
        <div className="absolute top-[calc(100%-1.1rem)] left-1 mt-1 z-[100] w-60 rounded-md border border-slate-400/70 bg-[#F8FAFC] shadow-2xl overflow-hidden animate-in fade-in zoom-in-95 duration-150">
          <div className="px-3 py-2 bg-gradient-to-b from-[#4A6789] to-[#243B55] text-white text-[11px] font-semibold tracking-wide flex items-center gap-2">
            <Cpu className="h-3.5 w-3.5 text-amber-300" /> Systeck — {companyName?.trim() || "C2TECK S.A.C."}
          </div>
          <button
            onClick={() => { setOpen(false); onSwitchCompany(); }}
            className="w-full text-left px-3 py-2.5 text-[12px] text-slate-800 hover:bg-[#DDE7F3] flex items-center gap-2.5 border-b border-slate-200"
          >
            <Building2 className="h-4 w-4 text-[#3E5B7A]" />
            <div>
              <div className="font-semibold">Cambiar Empresa</div>
              <div className="text-[10px] text-slate-500">Abrir ventana con empresas asignadas</div>
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

// Carrusel de Pestañas Animado con el prop onTabClick tipado
function TabsCarousel({
  tabs,
  active,
  onSelect,
  onTabClick,
}: {
  tabs: string[];
  active: string;
  onSelect: (tab: string) => void;
  onTabClick?: (e: React.MouseEvent<HTMLButtonElement>, t: string) => void;
}) {
  const handleTabClick = (e: React.MouseEvent<HTMLButtonElement>, t: string) => {
    if (onTabClick) {
      onTabClick(e, t);
    } else {
      onSelect(t);
    }
  };

  return (
    <div className="flex h-full items-center px-2 pt-1 gap-0 overflow-hidden">
      <div className="flex h-full items-center gap-1 pr-1 shrink-0">
        <button type="button" className="h-5 w-5 rounded hover:bg-white/60 grid place-items-center flex-shrink-0">
          <ChevronDown className="h-3 w-3" />
        </button>
        <div className="w-px h-4 bg-slate-400/30"></div>
      </div>
      {tabs.map((t) => {
        const isActive = active === t;
        return (
          <button
            key={t}
            type="button"
            onClick={(e: React.MouseEvent<HTMLButtonElement>) => handleTabClick(e, t)}
            className={[
              "relative flex-1 px-2.5 py-1.5 text-[11px] font-medium rounded-t border-x border-t transition-colors text-center whitespace-nowrap select-none",
              isActive
                ? "bg-[#F3F6FA] border-slate-400/60 text-slate-900 font-semibold -mb-[2px] z-10"
                : "bg-transparent border-transparent text-slate-600 hover:bg-white/40 hover:text-slate-800",
            ].join(" ")}
          >
            <span className="relative z-10">{t}</span>
            {isActive && (
  <motion.div
    layoutId="activeTabLine"
    className="absolute bottom-0 left-3 right-3 h-[1.5px] bg-[#1E3A8A]/80 rounded-full"
    transition={{ type: "spring", stiffness: 400, damping: 30 }}
  />
)}
          </button>
        );
      })}
    </div>
  );
}


function RibbonBigButton({ icon: Icon, label, iconKey, dropdown, menu, onOpen }: RibbonBtn & { onOpen: (label: string) => void }) {
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
      <motion.button
        ref={btnRef}
        onClick={toggle}
        whileHover={{ scale: 1.03, y: -1 }}
        whileTap={{ scale: 0.97, y: 0 }}
        transition={{ duration: 0.12 }}
        className={[
          "flex flex-col items-center gap-1 px-1.5 py-0.5 rounded border w-[64px]",
          open
            ? "bg-gradient-to-b from-[#FCE9A8] to-[#F5C86A] border-[#B8892E] shadow-inner"
            : "border-transparent hover:bg-[#DDE7F3] hover:border-[#7FA8D6]",
        ].join(" ")}
      >
        {iconKey ? (
          <SmallColorIcon label={cleanLabel} iconKey={iconKey} size={30} className="drop-shadow-[0_1px_1px_rgba(15,23,42,0.15)] group-hover/rb:scale-105 transition-transform" />
        ) : (
          <Glyph name={cleanLabel} size={30} className="drop-shadow-[0_1px_1px_rgba(15,23,42,0.15)] group-hover/rb:scale-105 transition-transform" />
        )}
        <span className="text-[10.5px] leading-tight text-center whitespace-pre text-slate-800 font-bold">{label}</span>
        {dropdown && <ChevronDown className="h-2.5 w-2.5 text-slate-500 -mt-1" />}
      </motion.button>
      {open && menu && pos && createPortal(
        <>
          <div className="fixed inset-0 z-40" onClick={() => setOpen(false)} />
          <div
            className="fixed z-[2147483646] bg-[#F3F6FA] border border-slate-400/70 shadow-xl rounded-sm p-2"
            style={{ left: pos.left, top: pos.top, maxWidth: "700px" }}
          >
            <div className="grid gap-3" style={{ gridTemplateColumns: `repeat(${menu.length}, minmax(0, 1fr))` }}>
              {menu.map((sec, sectionIndex) => (
                <div key={`${sec.title}-${sectionIndex}`} className="flex flex-col">
                  <div className="flex flex-col gap-0.5">
                    {sec.items.map((it, itemIndex) => (
                      <button
                        key={`${it.label}-${itemIndex}`}
                        onClick={() => { onOpen(it.label); setOpen(false); }}
                        className="flex items-center gap-1.5 px-1.5 py-0.5 rounded hover:bg-[#DDE7F3] hover:border-[#7FA8D6] border border-transparent text-left whitespace-nowrap"
                      >
                        <SmallColorIcon label={it.label} iconKey={it.iconKey} size={22} className="shrink-0" />
                      <span className="text-[11.5px] text-slate-800 whitespace-nowrap font-bold">{it.label}</span>
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

function RibbonSmallButton({ icon: Icon, label, iconKey, dropdown, menu, onOpen }: RibbonBtn & { onOpen: (label: string) => void }) {
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
      <motion.button
        ref={btnRef}
        onClick={toggle}
        whileHover={{ scale: 1.02 }}
        whileTap={{ scale: 0.96 }}
        transition={{ duration: 0.1 }}
        className={[
          "flex items-center gap-1 px-1 py-0.5 rounded border text-left text-[10px] press-fx hover:-translate-y-[1px] active:scale-95",
          open
            ? "bg-gradient-to-b from-[#FCE9A8] to-[#F5C86A] border-[#B8892E]"
            : "border-transparent hover:bg-[#DDE7F3] hover:border-[#7FA8D6]",
        ].join(" ")}
      >
        <SmallColorIcon label={label} iconKey={iconKey} size={19} className="shrink-0 group-hover/rs:scale-105 transition-transform" />
        <span className="text-slate-800 truncate font-bold">{label}</span>
        {dropdown && <ChevronDown className="h-2 w-2 text-slate-600" />}
      </motion.button>
      {open && menu && pos && createPortal(
        <>
          <div className="fixed inset-0 z-40" onClick={() => setOpen(false)} />
          <div
            className="fixed z-[2147483646] bg-[#F3F6FA] border border-slate-400/70 shadow-xl rounded-sm p-2"
            style={{ left: pos.left, top: pos.top, maxWidth: "700px" }}
          >
            <div className="grid gap-3" style={{ gridTemplateColumns: `repeat(${menu.length}, minmax(0, 1fr))` }}>
              {menu.map((sec, sectionIndex) => (
                <div key={`${sec.title}-${sectionIndex}`} className="flex flex-col">
                  <div className="flex flex-col gap-0.5">
                    {sec.items.map((it, itemIndex) => (
                      <button
                        key={`${it.label}-${itemIndex}`}
                        onClick={() => { onOpen(it.label); setOpen(false); }}
                        className="flex items-center gap-1.5 px-1.5 py-0.5 rounded hover:bg-[#DDE7F3] hover:border-[#7FA8D6] border border-transparent text-left whitespace-nowrap"
                      >
                        <SmallColorIcon label={it.label} iconKey={it.iconKey} size={18} className="shrink-0" />
                        <span className="text-[11px] text-slate-800 whitespace-nowrap font-bold">{it.label}</span>
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
