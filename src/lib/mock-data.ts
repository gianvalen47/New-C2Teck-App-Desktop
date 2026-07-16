export const salesInventory = [
  { month: "Ene", ventas: 128000, inventario: 92000 },
  { month: "Feb", ventas: 141200, inventario: 88400 },
  { month: "Mar", ventas: 156800, inventario: 95100 },
  { month: "Abr", ventas: 149300, inventario: 101200 },
  { month: "May", ventas: 172400, inventario: 98700 },
  { month: "Jun", ventas: 189600, inventario: 104500 },
  { month: "Jul", ventas: 205100, inventario: 110300 },
  { month: "Ago", ventas: 214800, inventario: 118900 },
  { month: "Set", ventas: 232500, inventario: 122400 },
  { month: "Oct", ventas: 248900, inventario: 129700 },
  { month: "Nov", ventas: 261300, inventario: 134100 },
  { month: "Dic", ventas: 289400, inventario: 141800 },
];

export const invoices = [
  { id: "F001-000482", client: "Distribuidora Andina SAC", type: "Factura", amount: 12480.5, status: "Aceptado", date: "2026-06-28" },
  { id: "B002-001139", client: "María Zavala", type: "Boleta", amount: 249.9, status: "Aceptado", date: "2026-06-28" },
  { id: "F001-000483", client: "Corporación Lima Norte", type: "Factura", amount: 8920.0, status: "Pendiente", date: "2026-06-29" },
  { id: "F001-000484", client: "Ferretería Los Olivos", type: "Factura", amount: 3410.75, status: "Aceptado", date: "2026-06-30" },
  { id: "B002-001140", client: "Juan Pérez Ramírez", type: "Boleta", amount: 129.0, status: "Rechazado", date: "2026-06-30" },
  { id: "F001-000485", client: "Hotel Miraflores Plaza", type: "Factura", amount: 21980.0, status: "Aceptado", date: "2026-07-01" },
];

export const inventory = [
  { sku: "SKU-1042", name: "Laptop HP ProBook 450 G10", stock: 42, min: 15, supplier: "HP Perú" },
  { sku: "SKU-1108", name: "Impresora Térmica 80mm", stock: 4, min: 10, supplier: "TecnoImports" },
  { sku: "SKU-2201", name: "Cable UTP Cat 6a (305m)", stock: 27, min: 20, supplier: "Anixter" },
  { sku: "SKU-3390", name: "Router Mikrotik hEX S", stock: 2, min: 8, supplier: "Mikrotik Perú" },
  { sku: "SKU-4501", name: "Hideez Key 4", stock: 58, min: 25, supplier: "Hideez Group" },
  { sku: "SKU-4502", name: "Hideez Key 3", stock: 12, min: 15, supplier: "Hideez Group" },
];

export const suppliers = [
  { ruc: "20512345678", name: "HP Perú S.A.C.", contact: "ventas@hp.pe", rating: 4.8 },
  { ruc: "20487654321", name: "Mikrotik Perú", contact: "info@mikrotik.pe", rating: 4.6 },
  { ruc: "20698765432", name: "Hideez Group Inc.", contact: "sales@hideez.com", rating: 4.9 },
  { ruc: "20111222333", name: "TecnoImports EIRL", contact: "ventas@tecno.pe", rating: 4.3 },
];

export const employees = [
  { dni: "45876123", name: "Carlos Ríos", role: "CTO", area: "Dirección", status: "Activo", shift: "Diurno" },
  { dni: "70223418", name: "Ana Salcedo", role: "Contadora", area: "Contabilidad", status: "Activo", shift: "Diurno" },
  { dni: "41556722", name: "Luis Palomino", role: "Ingeniero TI", area: "Infraestructura", status: "Vacaciones", shift: "Rotativo" },
  { dni: "72901133", name: "Rosa Villalba", role: "Ejecutiva Ventas", area: "Comercial", status: "Activo", shift: "Diurno" },
  { dni: "48221990", name: "Miguel Cárdenas", role: "Técnico ParkView", area: "Soporte", status: "En Ruta", shift: "Nocturno" },
];

export const workOrders = [
  { id: "OT-2026-0341", asset: "Servidor Dell R750 #S12", client: "Banco Andes", hours: 8420, priority: "Alta", status: "En Proceso" },
  { id: "OT-2026-0342", asset: "Storage Synology RS3621", client: "Clínica San Felipe", hours: 12100, priority: "Media", status: "Programada" },
  { id: "OT-2026-0343", asset: "UPS APC 10kVA", client: "Hotel Miraflores", hours: 4300, priority: "Baja", status: "Completada" },
  { id: "OT-2026-0344", asset: "Switch Cisco Catalyst 9300", client: "Ministerio X", hours: 15680, priority: "Crítica", status: "En Proceso" },
];

export const zigmaNiches = [
  { key: "hoteles", name: "Hoteles", desc: "Reservas, housekeeping y room service", clients: 42, color: "from-cyan-400 to-blue-500" },
  { key: "restaurantes", name: "Restaurantes", desc: "POS, comandas y arqueo de caja", clients: 87, color: "from-emerald-400 to-teal-500" },
  { key: "tiendas", name: "Tiendas / Markets", desc: "Kardex, checkout rápido y códigos de barra", clients: 134, color: "from-fuchsia-400 to-purple-500" },
  { key: "spa", name: "SPA & Peluquerías", desc: "Agenda por especialista y comisiones", clients: 29, color: "from-pink-400 to-rose-500" },
  { key: "gimnasios", name: "Gimnasios", desc: "Membresías, check-in y notificaciones", clients: 18, color: "from-amber-400 to-orange-500" },
];

export const servers = [
  { name: "DC1-COMPUTE-01", role: "Cluster VMware ESXi", cpu: 62, ram: 71, temp: 46, status: "OK" },
  { name: "DC1-STORAGE-02", role: "NetApp AFF C400", cpu: 24, ram: 38, temp: 41, status: "OK" },
  { name: "DC1-NET-CORE", role: "Cisco Nexus 9500", cpu: 41, ram: 55, temp: 38, status: "OK" },
  { name: "DC2-BACKUP-01", role: "Veeam Repository", cpu: 88, ram: 92, temp: 63, status: "Alerta" },
  { name: "DC2-DB-CLUSTER", role: "PostgreSQL 16 HA", cpu: 57, ram: 68, temp: 44, status: "OK" },
  { name: "EDGE-FW-01", role: "Palo Alto PA-3220", cpu: 33, ram: 47, temp: 40, status: "OK" },
];

export const tickets = [
  { id: "TCK-88214", server: "DC2-BACKUP-01", issue: "Uso de disco > 90%", eta: "22 min", tech: "Miguel Cárdenas", status: "Asignado" },
  { id: "TCK-88215", server: "DC1-COMPUTE-01", issue: "Predicción falla ventilador #3", eta: "1h 10m", tech: "Luis Palomino", status: "En Ruta" },
  { id: "TCK-88213", server: "EDGE-FW-01", issue: "Reglas obsoletas detectadas", eta: "Resuelto", tech: "AI Auto-Fix", status: "Cerrado" },
];

export const hideezDevices = [
  { id: "HK4-00A21F", model: "Hideez Key 4", user: "carlos.rios@c2teck.com.pe", link: "Bluetooth", battery: 87, status: "Activo" },
  { id: "HK4-00A238", model: "Hideez Key 4", user: "ana.salcedo@c2teck.com.pe", link: "NFC", battery: 64, status: "Activo" },
  { id: "HK3-00918C", model: "Hideez Key 3", user: "luis.palomino@c2teck.com.pe", link: "USB", battery: 100, status: "Inactivo" },
  { id: "HK4-00A2A9", model: "Hideez Key 4", user: "rosa.villalba@c2teck.com.pe", link: "Bluetooth", battery: 42, status: "Activo" },
];

export const leads = [
  { id: "LD-1201", name: "Comercial Piura SAC", contact: "gerencia@cpiura.pe", interest: "ERP Systeck", stage: "Demo Agendada", date: "2026-07-02" },
  { id: "LD-1202", name: "Restaurant El Tumi", contact: "admin@tumi.pe", interest: "Zigma Restaurantes", stage: "Nuevo", date: "2026-07-01" },
  { id: "LD-1203", name: "Grupo Hotelero Costa", contact: "ti@ghcosta.pe", interest: "Zigma Hoteles + Hideez", stage: "Propuesta", date: "2026-06-29" },
  { id: "LD-1204", name: "Gobierno Regional Junín", contact: "compras@regjunin.gob.pe", interest: "ParkView TI", stage: "Negociación", date: "2026-06-27" },
];

export const aiEvents = [
  { t: "12:04:22", sev: "info", msg: "Modelo predictivo detectó variación térmica normal en DC1-STORAGE-02" },
  { t: "12:03:58", sev: "warn", msg: "DC2-BACKUP-01 supera umbral I/O (92%). Ticket TCK-88214 abierto automáticamente." },
  { t: "12:02:41", sev: "info", msg: "Auto-parche aplicado a EDGE-FW-01 · reglas OWASP actualizadas" },
  { t: "12:01:09", sev: "success", msg: "Backup incremental Veeam completado — 1.4 TB en 38 min" },
  { t: "11:59:52", sev: "warn", msg: "Predicción: ventilador #3 en DC1-COMPUTE-01 fallará en ~72h" },
  { t: "11:58:03", sev: "info", msg: "Nueva sesión FIDO2 registrada · usuario ana.salcedo" },
];
