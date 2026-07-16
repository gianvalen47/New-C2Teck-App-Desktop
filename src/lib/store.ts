import { useSyncExternalStore } from "react";

// ---------------- Types ----------------
export type InventoryItem = {
  sku: string;
  name: string;
  stock: number;
  min: number;
  supplier: string;
  avgCost: number;
};

export type KardexTx = {
  id: string;
  date: string;
  sku: string;
  type: "Compra" | "Venta" | "Ajuste";
  qty: number;
  unitCost: number;
  totalValue: number;
  balance: number;
  balanceValue: number;
  note?: string;
};

export type SaleLine = { sku: string; name: string; price: number; qty: number };
export type Sale = {
  id: string;
  serie: string;
  date: string;
  client: string;
  total: number;
  items: SaleLine[];
  paymentMethods: { method: string; amount: number }[];
  sunatSent: boolean;
  status: "Aceptado" | "Pendiente" | "Rechazado";
  channel: "ERP" | "Zigma";
};

export type PurchaseOrder = {
  id: string;
  supplier: string;
  status: "Requisición" | "Aprobada" | "Recibida";
  items: { sku: string; name: string; qty: number; unitCost: number }[];
  createdAt: string;
  approvedAt?: string;
  receivedAt?: string;
};

export type OTStatus = "Por Asignar" | "En Diagnóstico" | "En Reparación" | "Listas para Entrega";
export type WorkOrder = {
  id: string;
  asset: string;
  client: string;
  hours: number;
  hoursLimit: number;
  priority: "Baja" | "Media" | "Alta" | "Crítica";
  status: OTStatus;
  needsPM?: boolean;
};

export type ServerNode = {
  name: string;
  role: string;
  cpu: number;
  ram: number;
  temp: number;
  status: "OK" | "Alerta" | "Crítico";
};

export type InfraTicket = {
  id: string;
  server: string;
  issue: string;
  severity: "info" | "warn" | "critical";
  tech: string | null;
  status: "Abierto" | "Asignado" | "En Diagnóstico" | "Resuelto";
  telemetry: string[];
  createdAt: string;
  resolvedAt?: string;
};

export type AuthLog = {
  id: string;
  ts: string;
  user: string;
  device: "Hideez Key 4" | "Hideez Key 3";
  action: "Login" | "Access Denied" | "Lock by Proximity" | "Unlock" | "MFA Challenge";
  assessment: "OK" | "Phishing Attempt Blocked" | "Anomalía geográfica" | "Bloqueado";
};

export type Settings = {
  ruc: string;
  solUser: string;
  solPass: string;
  cert: { name: string; validUntil: string } | null;
  correlativos: { factura: string; boleta: string; nota: string };
  igvRate: number;
  iscRate: number;
  currency: "PEN" | "USD";
  fxUSD: number;
  autoFx: boolean;
};

// ---------------- Roles / Tenants / Audit ----------------
export type Role = "admin" | "contador" | "cajero" | "soporte";
export type ModuleKey = "overview" | "erp" | "zigma" | "infrastructure" | "security" | "crm" | "settings" | "audit";

export const ROLE_LABEL: Record<Role, string> = {
  admin: "Administrador General",
  contador: "Contador (ERP)",
  cajero: "Cajero (Zigma POS)",
  soporte: "Ingeniero de Soporte (ParkView)",
};

export type Tenant = { id: string; name: string; ruc: string; industry: string };

export type AuditEntry = {
  id: string;
  ts: string;
  user: string;
  role: Role;
  ip: string;
  tenantId: string;
  module: ModuleKey | "auth" | "system";
  action: string;
  detail?: string;
};

// ---------------- State ----------------
type State = {
  settings: Settings;
  inventory: InventoryItem[];
  kardex: KardexTx[];
  sales: Sale[];
  purchaseOrders: PurchaseOrder[];
  workOrders: WorkOrder[];
  servers: ServerNode[];
  infraTickets: InfraTicket[];
  authLogs: AuthLog[];
  currentRole: Role;
  currentTenantId: string;
  tenants: Tenant[];
  permissions: Record<Role, ModuleKey[]>;
  auditLog: AuditEntry[];
  searchQuery: string;
  notificationsReadAt: string;
};


const nowISO = () => new Date().toISOString().slice(0, 19).replace("T", " ");
const uid = (p: string) => `${p}-${Math.random().toString(36).slice(2, 8).toUpperCase()}`;

const initialInventory: InventoryItem[] = [
  { sku: "SKU-1042", name: "Laptop HP ProBook 450 G10", stock: 42, min: 15, supplier: "HP Perú", avgCost: 3200 },
  { sku: "SKU-1108", name: "Impresora Térmica 80mm", stock: 4, min: 10, supplier: "TecnoImports", avgCost: 320 },
  { sku: "SKU-2201", name: "Cable UTP Cat 6a (305m)", stock: 27, min: 20, supplier: "Anixter", avgCost: 640 },
  { sku: "SKU-3390", name: "Router Mikrotik hEX S", stock: 2, min: 8, supplier: "Mikrotik Perú", avgCost: 280 },
  { sku: "SKU-4501", name: "Hideez Key 4", stock: 58, min: 25, supplier: "Hideez Group", avgCost: 145 },
  { sku: "SKU-4502", name: "Hideez Key 3", stock: 12, min: 15, supplier: "Hideez Group", avgCost: 95 },
  { sku: "SKU-7788", name: "Coca-Cola 500ml", stock: 220, min: 60, supplier: "Distribuidora Andina", avgCost: 2.1 },
  { sku: "SKU-7789", name: "Pan francés x6", stock: 80, min: 30, supplier: "Panadería Real", avgCost: 1.2 },
];

const initialKardex: KardexTx[] = [
  { id: uid("KDX"), date: "2026-06-01 09:12", sku: "SKU-1042", type: "Compra", qty: 20, unitCost: 3180, totalValue: 63600, balance: 42, balanceValue: 42 * 3200 },
  { id: uid("KDX"), date: "2026-06-04 15:44", sku: "SKU-1042", type: "Venta", qty: -3, unitCost: 3200, totalValue: -9600, balance: 39, balanceValue: 39 * 3200 },
  { id: uid("KDX"), date: "2026-06-11 10:22", sku: "SKU-4501", type: "Compra", qty: 30, unitCost: 145, totalValue: 4350, balance: 58, balanceValue: 58 * 145 },
];

const initialWO: WorkOrder[] = [
  { id: "OT-2026-0341", asset: "Servidor Dell R750 #S12", client: "Banco Andes", hours: 8420, hoursLimit: 10000, priority: "Alta", status: "En Diagnóstico" },
  { id: "OT-2026-0342", asset: "Storage Synology RS3621", client: "Clínica San Felipe", hours: 12100, hoursLimit: 12000, priority: "Media", status: "Por Asignar", needsPM: true },
  { id: "OT-2026-0343", asset: "UPS APC 10kVA", client: "Hotel Miraflores", hours: 4300, hoursLimit: 8000, priority: "Baja", status: "Listas para Entrega" },
  { id: "OT-2026-0344", asset: "Switch Cisco Catalyst 9300", client: "Ministerio X", hours: 15680, hoursLimit: 15000, priority: "Crítica", status: "En Reparación", needsPM: true },
  { id: "OT-2026-0345", asset: "Compresor Atlas GA22", client: "Industrias Piura", hours: 9200, hoursLimit: 10000, priority: "Media", status: "Por Asignar" },
];

const initialServers: ServerNode[] = [
  { name: "DC1-COMPUTE-01", role: "Cluster VMware ESXi", cpu: 62, ram: 71, temp: 46, status: "OK" },
  { name: "DC1-STORAGE-02", role: "NetApp AFF C400", cpu: 24, ram: 38, temp: 41, status: "OK" },
  { name: "DC1-NET-CORE", role: "Cisco Nexus 9500", cpu: 41, ram: 55, temp: 38, status: "OK" },
  { name: "DC2-BACKUP-01", role: "Veeam Repository", cpu: 88, ram: 92, temp: 63, status: "Alerta" },
  { name: "DC2-DB-CLUSTER", role: "PostgreSQL 16 HA", cpu: 57, ram: 68, temp: 44, status: "OK" },
  { name: "EDGE-FW-01", role: "Palo Alto PA-3220", cpu: 33, ram: 47, temp: 40, status: "OK" },
];

const initialTickets: InfraTicket[] = [
  {
    id: "TCK-88214", server: "DC2-BACKUP-01", issue: "Uso de disco > 90%", severity: "critical",
    tech: null, status: "Abierto",
    telemetry: ["[disk] /dev/sdb1 utilización 92.4%", "[veeam] Job WEEKLY-FULL en cola", "[predict] Saturación en ~4h si continúa la tasa"],
    createdAt: nowISO(),
  },
  {
    id: "TCK-88215", server: "DC1-COMPUTE-01", issue: "Predicción falla ventilador #3", severity: "warn",
    tech: "Luis Palomino", status: "Asignado",
    telemetry: ["[ipmi] Fan3 RPM 4200 (nominal 6500)", "[thermal] +4°C sobre baseline", "[ml] Prob. falla 72h: 87%"],
    createdAt: nowISO(),
  },
];

const initialAuth: AuthLog[] = [
  { id: uid("AL"), ts: nowISO(), user: "carlos.rios@c2teck.com.pe", device: "Hideez Key 4", action: "Login", assessment: "OK" },
  { id: uid("AL"), ts: nowISO(), user: "ana.salcedo@c2teck.com.pe", device: "Hideez Key 4", action: "MFA Challenge", assessment: "OK" },
  { id: uid("AL"), ts: nowISO(), user: "unknown@spoof-c2teck.pe", device: "Hideez Key 4", action: "Access Denied", assessment: "Phishing Attempt Blocked" },
  { id: uid("AL"), ts: nowISO(), user: "luis.palomino@c2teck.com.pe", device: "Hideez Key 3", action: "Lock by Proximity", assessment: "OK" },
];

let state: State = {
  settings: {
    ruc: "20605421903",
    solUser: "C2TECKSOL",
    solPass: "••••••••",
    cert: { name: "c2teck_2026.pfx", validUntil: "2027-04-15" },
    correlativos: { factura: "F001-000486", boleta: "B002-001141", nota: "FC01-000012" },
    igvRate: 18,
    iscRate: 0,
    currency: "PEN",
    fxUSD: 3.752,
    autoFx: true,
  },
  inventory: initialInventory,
  kardex: initialKardex,
  sales: [],
  purchaseOrders: [
    { id: "OC-2026-0088", supplier: "HP Perú", status: "Aprobada", createdAt: "2026-06-20", approvedAt: "2026-06-21",
      items: [{ sku: "SKU-1042", name: "Laptop HP ProBook 450 G10", qty: 10, unitCost: 3180 }] },
  ],
  workOrders: initialWO,
  servers: initialServers,
  infraTickets: initialTickets,
  authLogs: initialAuth,
  currentRole: "admin",
  currentTenantId: "c2teck",
  tenants: [
    { id: "c2teck", name: "C2Teck S.A.C. (Master)", ruc: "20605421903", industry: "Tecnología / Multi-vertical" },
    { id: "alfa", name: "Corporación Alfa S.A.", ruc: "20512340987", industry: "Distribución Retail" },
    { id: "solima", name: "Hotel Sol de Lima", ruc: "20487651230", industry: "Hospitalidad" },
    { id: "andes", name: "Clínica San Andrés E.I.R.L.", ruc: "20399887744", industry: "Salud" },
  ],
  permissions: {
    admin: ["overview", "erp", "zigma", "infrastructure", "security", "crm", "settings", "audit"],
    contador: ["overview", "erp", "crm", "audit"],
    cajero: ["overview", "zigma"],
    soporte: ["overview", "infrastructure", "security", "audit"],
  },
  auditLog: [
    { id: uid("AU"), ts: nowISO(), user: "carlos.rios@c2teck.com.pe", role: "admin", ip: "10.0.4.12", tenantId: "c2teck", module: "auth", action: "Login exitoso vía Hideez Key 4", detail: "FIDO2 · WebAuthn" },
    { id: uid("AU"), ts: nowISO(), user: "ana.salcedo@c2teck.com.pe", role: "contador", ip: "10.0.4.18", tenantId: "c2teck", module: "erp", action: "Emisión Factura F001-000485", detail: "Aceptada por SUNAT · CDR 2.1s" },
    { id: uid("AU"), ts: nowISO(), user: "luis.palomino@c2teck.com.pe", role: "soporte", ip: "10.0.4.22", tenantId: "c2teck", module: "infrastructure", action: "Ticket TCK-88215 asignado", detail: "Predicción falla ventilador #3" },
  ],
  searchQuery: "",
  notificationsReadAt: "1970-01-01 00:00:00",
};


const listeners = new Set<() => void>();
const emit = () => listeners.forEach(l => l());
const setState = (patch: Partial<State> | ((s: State) => Partial<State>)) => {
  const p = typeof patch === "function" ? patch(state) : patch;
  state = { ...state, ...p };
  emit();
};

export function useStore<T>(selector: (s: State) => T): T {
  return useSyncExternalStore(
    (cb) => { listeners.add(cb); return () => listeners.delete(cb); },
    () => selector(state),
    () => selector(state),
  );
}

// ---------------- Actions ----------------
export const actions = {
  updateSettings(patch: Partial<Settings>) {
    setState(s => ({ settings: { ...s.settings, ...patch } }));
    actions.logAudit({ module: "settings", action: "Actualización de parámetros del sistema", detail: Object.keys(patch).join(", ") });
  },

  bumpCorrelativo(kind: "factura" | "boleta") {
    setState(s => {
      const cur = s.settings.correlativos[kind];
      const [serie, num] = cur.split("-");
      const next = `${serie}-${String(Number(num) + 1).padStart(6, "0")}`;
      return { settings: { ...s.settings, correlativos: { ...s.settings.correlativos, [kind]: next } } };
    });
  },
  // POS finalize
  registerSale(input: {
    channel: "ERP" | "Zigma";
    items: SaleLine[];
    payments: { method: string; amount: number }[];
    sunatSent: boolean;
    client?: string;
    docType?: "factura" | "boleta";
  }) {
    const docType = input.docType ?? "boleta";
    const serie = state.settings.correlativos[docType];
    const total = input.items.reduce((s, i) => s + i.price * i.qty, 0);
    const sale: Sale = {
      id: uid("VT"),
      serie,
      date: nowISO(),
      client: input.client ?? "Consumidor Final",
      total,
      items: input.items,
      paymentMethods: input.payments,
      sunatSent: input.sunatSent,
      status: input.sunatSent ? "Aceptado" : "Pendiente",
      channel: input.channel,
    };
    // deduct stock + kardex
    setState(s => {
      const inv = s.inventory.map(it => {
        const line = input.items.find(l => l.sku === it.sku);
        if (!line) return it;
        return { ...it, stock: Math.max(0, it.stock - line.qty) };
      });
      const kx: KardexTx[] = input.items.map(line => {
        const it = s.inventory.find(x => x.sku === line.sku);
        const cost = it?.avgCost ?? line.price * 0.7;
        const remaining = (it?.stock ?? 0) - line.qty;
        return {
          id: uid("KDX"), date: sale.date, sku: line.sku, type: "Venta",
          qty: -line.qty, unitCost: cost, totalValue: -(cost * line.qty),
          balance: Math.max(0, remaining), balanceValue: Math.max(0, remaining) * cost,
          note: `Venta ${sale.serie}`,
        };
      });
      return { inventory: inv, kardex: [...kx, ...s.kardex], sales: [sale, ...s.sales] };
    });
    actions.bumpCorrelativo(docType);
    actions.logAudit({ module: "erp", action: `Venta ${sale.serie} registrada`, detail: `${input.channel} · ${formatSoles(total)} · ${input.items.length} ítem(s)` });
    return sale;
  },

  // Purchase workflow
  createPO(supplier: string, items: PurchaseOrder["items"]) {
    const po: PurchaseOrder = { id: uid("OC"), supplier, items, status: "Requisición", createdAt: nowISO() };
    setState(s => ({ purchaseOrders: [po, ...s.purchaseOrders] }));
    return po;
  },
  approvePO(id: string) {
    setState(s => ({
      purchaseOrders: s.purchaseOrders.map(p => p.id === id ? { ...p, status: "Aprobada", approvedAt: nowISO() } : p),
    }));
  },
  receivePO(id: string) {
    const po = state.purchaseOrders.find(p => p.id === id);
    if (!po) return;
    setState(s => {
      const inv = [...s.inventory];
      const kx: KardexTx[] = [];
      po.items.forEach(line => {
        const idx = inv.findIndex(x => x.sku === line.sku);
        if (idx >= 0) {
          const it = inv[idx];
          const newStock = it.stock + line.qty;
          const newAvg = (it.stock * it.avgCost + line.qty * line.unitCost) / newStock;
          inv[idx] = { ...it, stock: newStock, avgCost: newAvg };
          kx.push({
            id: uid("KDX"), date: nowISO(), sku: line.sku, type: "Compra",
            qty: line.qty, unitCost: line.unitCost, totalValue: line.qty * line.unitCost,
            balance: newStock, balanceValue: newStock * newAvg, note: `Recepción ${po.id}`,
          });
        }
      });
      return {
        inventory: inv,
        kardex: [...kx, ...s.kardex],
        purchaseOrders: s.purchaseOrders.map(p => p.id === id ? { ...p, status: "Recibida", receivedAt: nowISO() } : p),
      };
    });
  },
  // Work orders
  moveOT(id: string, status: OTStatus) {
    setState(s => ({ workOrders: s.workOrders.map(o => o.id === id ? { ...o, status } : o) }));
  },
  triggerPMCheck(hoursLimit: number) {
    let flagged = 0;
    setState(s => ({
      workOrders: s.workOrders.map(o => {
        if (o.hours >= hoursLimit) { flagged++; return { ...o, needsPM: true, priority: "Crítica" as const }; }
        return o;
      }),
    }));
    return flagged;
  },
  // Infra
  assignTicket(id: string, tech: string) {
    setState(s => ({
      infraTickets: s.infraTickets.map(t => t.id === id ? { ...t, tech, status: "Asignado" } : t),
    }));
  },
  diagnoseTicket(id: string) {
    setState(s => ({
      infraTickets: s.infraTickets.map(t => t.id === id ? { ...t, status: "En Diagnóstico",
        telemetry: [...t.telemetry, `[${nowISO().slice(11)}] Ingeniero conectado vía IPMI/SSH`] } : t),
    }));
  },
  resolveTicket(id: string) {
    const t = state.infraTickets.find(x => x.id === id);
    if (!t) return;
    setState(s => ({
      infraTickets: s.infraTickets.map(x => x.id === id ? { ...x, status: "Resuelto", resolvedAt: nowISO(),
        telemetry: [...x.telemetry, `[${nowISO().slice(11)}] Servicio restaurado · métricas nominales`] } : x),
      servers: s.servers.map(sv => sv.name === t.server
        ? { ...sv, status: "OK", cpu: Math.min(sv.cpu, 55), ram: Math.min(sv.ram, 65), temp: Math.min(sv.temp, 48) }
        : sv),
    }));
  },
  simulateIncident() {
    const targets = state.servers.filter(s => s.status === "OK");
    const target = targets[Math.floor(Math.random() * targets.length)];
    if (!target) return;
    const t: InfraTicket = {
      id: uid("TCK"), server: target.name, issue: "Latencia anómala detectada por AI", severity: "warn",
      tech: null, status: "Abierto", createdAt: nowISO(),
      telemetry: [`[ml] Anomaly score 0.87`, `[net] Retransmisiones TCP +340%`, `[ipmi] Sensores dentro de rango`],
    };
    setState(s => ({
      servers: s.servers.map(sv => sv.name === target.name ? { ...sv, status: "Alerta", cpu: 92, temp: 68 } : sv),
      infraTickets: [t, ...s.infraTickets],
    }));
    return t;
  },
  logAuth(entry: Omit<AuthLog, "id" | "ts"> & { ts?: string }) {
    setState(s => ({
      authLogs: [{ id: uid("AL"), ts: entry.ts ?? nowISO(), ...entry }, ...s.authLogs].slice(0, 100),
    }));
  },
  // ---- Roles / Tenants / Audit ----
  setRole(role: Role) {
    setState(() => ({ currentRole: role }));
    actions.logAudit({ module: "system", action: `Cambio de perfil activo → ${ROLE_LABEL[role]}` });
  },
  setTenant(id: string) {
    const t = state.tenants.find(x => x.id === id);
    setState(() => ({ currentTenantId: id }));
    if (t) actions.logAudit({ module: "system", action: `Tenant activo → ${t.name}`, detail: `RUC ${t.ruc}` });
  },
  togglePermission(role: Role, mod: ModuleKey) {
    setState(s => {
      const cur = s.permissions[role];
      const has = cur.includes(mod);
      const next = has ? cur.filter(m => m !== mod) : [...cur, mod];
      return { permissions: { ...s.permissions, [role]: next } };
    });
    actions.logAudit({ module: "settings", action: `Permiso ${mod} ${state.permissions[role].includes(mod) ? "revocado" : "otorgado"} a ${ROLE_LABEL[role]}` });
  },
  logAudit(entry: { module: AuditEntry["module"]; action: string; detail?: string; user?: string }) {
    setState(s => {
      const u = entry.user ?? (
        s.currentRole === "admin" ? "carlos.rios@c2teck.com.pe" :
        s.currentRole === "contador" ? "ana.salcedo@c2teck.com.pe" :
        s.currentRole === "cajero" ? "pos01@c2teck.com.pe" :
        "luis.palomino@c2teck.com.pe"
      );
      const e: AuditEntry = {
        id: uid("AU"), ts: nowISO(), user: u, role: s.currentRole,
        ip: `10.0.${Math.floor(Math.random() * 8)}.${10 + Math.floor(Math.random() * 240)}`,
        tenantId: s.currentTenantId, module: entry.module, action: entry.action, detail: entry.detail,
      };
      return { auditLog: [e, ...s.auditLog].slice(0, 500) };
    });
  },
  findReceipt(query: { serie: string; ruc?: string; total?: number }) {
    return state.sales.find(s => s.serie.replace(/\s/g, "").toUpperCase() === query.serie.replace(/\s/g, "").toUpperCase());
  },
  setSearch(q: string) { setState(() => ({ searchQuery: q })); },
  markNotificationsRead() { setState(() => ({ notificationsReadAt: nowISO() })); },
};


// helpers
export function formatSoles(n: number) {
  return `S/ ${n.toLocaleString("es-PE", { minimumFractionDigits: 2, maximumFractionDigits: 2 })}`;
}
export function validateRUC(ruc: string) {
  return /^\d{11}$/.test(ruc);
}
