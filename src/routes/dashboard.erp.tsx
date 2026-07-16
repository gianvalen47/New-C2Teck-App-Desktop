import { createFileRoute } from "@tanstack/react-router";
import { useState, useEffect } from "react";
import { toast } from "sonner";
import {
  FileText, Boxes, Calculator, Users2, Wrench, Plus, Search, X, TrendingUp, AlertTriangle,
  ClipboardList, CheckCircle2, PackageCheck, Printer, ArrowRight, Timer, ShieldAlert, BarChart3, Trophy,
} from "lucide-react";
import { StatusBadge } from "@/components/ui/status-badge";
import { KpiCard } from "@/components/ui/kpi-card";
import { invoices, suppliers, employees } from "@/lib/mock-data";
import { fetchSigecoomSales, type SigecoomSale } from "@/lib/sigecoom-api";
import { useStore, actions, formatSoles, type OTStatus, type PurchaseOrder } from "@/lib/store";
import { Line, LineChart, CartesianGrid, ResponsiveContainer, Tooltip, XAxis, YAxis, Bar, BarChart, Legend, Cell } from "recharts";
import { cn } from "@/lib/utils";


export const Route = createFileRoute("/dashboard/erp")({
  head: () => ({
    meta: [
      { title: "ERP Systeck · C2Teck" },
      { name: "description", content: "Ventas, facturación SUNAT, inventarios, contabilidad, planillas y servicio técnico." },
    ],
  }),
  component: ERPPage,
});

const TABS = [
  { key: "ventas", label: "Ventas & Facturación", icon: FileText },
  { key: "compras", label: "Compras & Inventarios", icon: Boxes },
  { key: "conta", label: "Contabilidad & Costos", icon: Calculator },
  { key: "planillas", label: "Planillas & Personal", icon: Users2 },
  { key: "tecnico", label: "Servicio Técnico", icon: Wrench },
  { key: "bi", label: "Inteligencia de Negocios", icon: BarChart3 },
] as const;


function ERPPage() {
  const [tab, setTab] = useState<(typeof TABS)[number]["key"]>("ventas");
  return (
    <div className="space-y-6">
      <header>
        <p className="text-xs uppercase tracking-widest text-primary">Módulo Integrado</p>
        <h1 className="text-3xl font-display font-bold">ERP Systeck</h1>
        <p className="text-sm text-muted-foreground mt-1">Gestión integral · integrado con SUNAT y planillas PLAME.</p>
      </header>

      <div className="flex flex-wrap gap-1 rounded-lg bg-card border border-border p-1">
        {TABS.map((t) => {
          const Icon = t.icon;
          const active = tab === t.key;
          return (
            <button key={t.key} onClick={() => setTab(t.key)}
              className={cn("flex items-center gap-2 rounded-md px-3 py-2 text-sm font-medium transition-colors",
                active ? "bg-primary/15 text-primary" : "text-muted-foreground hover:text-foreground hover:bg-accent")}>
              <Icon className="h-4 w-4" /> {t.label}
            </button>
          );
        })}
      </div>

      {tab === "ventas" && <VentasTab />}
      {tab === "compras" && <ComprasTab />}
      {tab === "conta" && <ContaTab />}
      {tab === "planillas" && <PlanillasTab />}
      {tab === "tecnico" && <TecnicoTab />}
      {tab === "bi" && <BITab />}

    </div>
  );
}

/* -------- Ventas -------- */
function VentasTab() {
  const [open, setOpen] = useState(false);
  const [q, setQ] = useState("");
  const [backendSales, setBackendSales] = useState<SigecoomSale[]>([]);
  const [loadingSales, setLoadingSales] = useState(true);
  
  const liveSales = useStore(s => s.sales);
  
  useEffect(() => {
    let ignore = false;
    fetchSigecoomSales()
      .then((data) => {
        if (!ignore) {
          setBackendSales(data);
          setLoadingSales(false);
        }
      })
      .catch(() => {
        if (!ignore) {
          setBackendSales([]);
          setLoadingSales(false);
        }
      });
    return () => {
      ignore = true;
    };
  }, []);
  
  const merged = [
    ...liveSales.map(s => ({ id: s.serie, client: s.client, type: s.serie.startsWith("F") ? "Factura" : "Boleta", amount: s.total, status: s.status, date: s.date.slice(0, 10) })),
    ...backendSales.map(s => ({ 
      id: `${s.series}-${s.number}`, 
      client: s.client_id || "Cliente", 
      type: s.type === "factura" ? "Factura" : "Boleta", 
      amount: s.total, 
      status: s.status, 
      date: new Date(s.date).toISOString().slice(0, 10) 
    })),
    ...invoices,
  ];
  const filtered = merged.filter(i => i.client.toLowerCase().includes(q.toLowerCase()) || i.id.includes(q));
  const settings = useStore(s => s.settings);

  return (
    <div className="space-y-4">
      <div className="grid grid-cols-1 sm:grid-cols-4 gap-4">
        <KpiCard label="Facturado hoy" value={formatSoles(liveSales.reduce((s, x) => s + x.total, 0) + 47321)} delta="+18% vs ayer" icon={TrendingUp} accent="success" />
        <KpiCard label="Aceptadas SUNAT" value={String(1204 + liveSales.filter(s => s.sunatSent).length)} delta="99.2% éxito" icon={FileText} accent="primary" />
        <KpiCard label="Pendientes" value={String(18 + liveSales.filter(s => !s.sunatSent).length)} delta="Envío automático" icon={AlertTriangle} accent="warning" />
        <KpiCard label="Próximo correlativo" value={settings.correlativos.factura} icon={FileText} accent="primary" />
      </div>

      <div className="card-elevated">
        <div className="flex flex-wrap items-center gap-3 p-4 border-b border-border">
          <h3 className="font-display font-semibold">Comprobantes electrónicos</h3>
          <div className="relative ml-auto">
            <Search className="absolute left-3 top-1/2 -translate-y-1/2 h-4 w-4 text-muted-foreground" />
            <input value={q} onChange={e => setQ(e.target.value)} placeholder="Buscar por cliente o serie"
              className="h-9 rounded-md bg-muted pl-9 pr-3 text-sm outline-none border border-transparent focus:border-border" />
          </div>
          <button onClick={() => setOpen(true)} className="inline-flex items-center gap-2 rounded-md bg-primary px-3 py-2 text-sm font-medium text-primary-foreground">
            <Plus className="h-4 w-4" /> Nueva factura
          </button>
        </div>
        <div className="overflow-x-auto">
          <table className="w-full text-sm">
            <thead className="text-left text-xs uppercase text-muted-foreground bg-muted/30">
              <tr>
                <th className="px-4 py-3">Serie-Correlativo</th>
                <th className="px-4 py-3">Cliente</th>
                <th className="px-4 py-3">Tipo</th>
                <th className="px-4 py-3 text-right">Monto (S/)</th>
                <th className="px-4 py-3">Fecha</th>
                <th className="px-4 py-3">Estado SUNAT</th>
              </tr>
            </thead>
            <tbody>
              {filtered.map(inv => (
                <tr key={inv.id + inv.date} className="border-t border-border hover:bg-accent/40">
                  <td className="px-4 py-3 font-mono text-xs">{inv.id}</td>
                  <td className="px-4 py-3">{inv.client}</td>
                  <td className="px-4 py-3">{inv.type}</td>
                  <td className="px-4 py-3 text-right font-medium">{inv.amount.toLocaleString("es-PE", { minimumFractionDigits: 2 })}</td>
                  <td className="px-4 py-3 text-muted-foreground">{inv.date}</td>
                  <td className="px-4 py-3"><StatusBadge status={inv.status} /></td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>

      {open && <InvoiceModal onClose={() => setOpen(false)} />}
    </div>
  );
}

function InvoiceModal({ onClose }: { onClose: () => void }) {
  const [ruc, setRuc] = useState("");
  const [razon, setRazon] = useState("");
  const [total, setTotal] = useState("");
  const [err, setErr] = useState<Record<string, string>>({});

  return (
    <div className="fixed inset-0 z-50 grid place-items-center bg-black/70 p-4" onClick={onClose}>
      <div className="w-full max-w-lg card-elevated p-6" onClick={e => e.stopPropagation()}>
        <div className="flex items-start justify-between mb-4">
          <div>
            <h3 className="font-display text-lg font-semibold">Nueva Factura Electrónica</h3>
            <p className="text-xs text-muted-foreground">Se enviará automáticamente a SUNAT.</p>
          </div>
          <button onClick={onClose} className="p-1 hover:bg-accent rounded"><X className="h-4 w-4" /></button>
        </div>
        <form onSubmit={(e) => {
          e.preventDefault();
          const errs: Record<string, string> = {};
          if (!/^\d{11}$/.test(ruc)) errs.ruc = "RUC debe tener 11 dígitos";
          if (razon.trim().length < 3) errs.razon = "Razón social requerida";
          const t = Number(total);
          if (!t || t <= 0) errs.total = "Monto inválido";
          setErr(errs);
          if (Object.keys(errs).length) return;
          actions.registerSale({
            channel: "ERP",
            client: razon,
            docType: "factura",
            items: [{ sku: "SRV-001", name: "Servicio facturado", price: t, qty: 1 }],
            payments: [{ method: "Transferencia", amount: t }],
            sunatSent: true,
          });
          toast.success("Factura creada", { description: "Enviada a SUNAT · CDR recibido en 2.1s" });
          onClose();
        }} className="space-y-3">
          <Field label="RUC Cliente" error={err.ruc}><input value={ruc} onChange={e => setRuc(e.target.value)} className={cn("input", err.ruc && "!border-destructive")} placeholder="20512345678" maxLength={11} /></Field>
          <Field label="Razón social" error={err.razon}><input value={razon} onChange={e => setRazon(e.target.value)} className={cn("input", err.razon && "!border-destructive")} placeholder="Distribuidora Andina SAC" /></Field>
          <div className="grid grid-cols-2 gap-3">
            <Field label="Tipo"><select className="input"><option>Factura</option><option>Boleta</option></select></Field>
            <Field label="Moneda"><select className="input"><option>PEN — Soles</option><option>USD — Dólares</option></select></Field>
          </div>
          <Field label="Total (incl. IGV)" error={err.total}><input value={total} onChange={e => setTotal(e.target.value)} type="number" step="0.01" className={cn("input", err.total && "!border-destructive")} placeholder="0.00" /></Field>
          <div className="flex justify-end gap-2 pt-2">
            <button type="button" onClick={onClose} className="rounded-md border border-border px-3 py-2 text-sm hover:bg-accent">Cancelar</button>
            <button className="rounded-md bg-primary px-3 py-2 text-sm font-medium text-primary-foreground">Emitir</button>
          </div>
        </form>
      </div>
    </div>
  );
}

function Field({ label, error, children }: { label: string; error?: string; children: React.ReactNode }) {
  return (
    <label className="block">
      <span className="text-xs text-muted-foreground">{label}</span>
      <div className="mt-1 [&_.input]:w-full [&_.input]:h-10 [&_.input]:rounded-md [&_.input]:bg-muted [&_.input]:px-3 [&_.input]:text-sm [&_.input]:border [&_.input]:border-border [&_.input]:outline-none [&_.input:focus]:border-primary">
        {children}
      </div>
      {error && <span className="mt-1 block text-[11px] text-destructive">{error}</span>}
    </label>
  );
}

/* -------- Compras · Kardex Valorado + PO Workflow -------- */
function ComprasTab() {
  const inventory = useStore(s => s.inventory);
  const kardex = useStore(s => s.kardex);
  const pos = useStore(s => s.purchaseOrders);
  const [selSku, setSelSku] = useState(inventory[0]?.sku ?? "");
  const [poOpen, setPoOpen] = useState(false);
  const [printPO, setPrintPO] = useState<PurchaseOrder | null>(null);

  const skuKardex = kardex.filter(k => k.sku === selSku);

  const forecast = [
    { w: "S1", real: 320, forecast: 300 }, { w: "S2", real: 340, forecast: 330 },
    { w: "S3", real: 380, forecast: 360 }, { w: "S4", real: 355, forecast: 390 },
    { w: "S5", real: 0, forecast: 410 }, { w: "S6", real: 0, forecast: 430 },
  ];

  return (
    <div className="space-y-4">
      <div className="grid lg:grid-cols-3 gap-4">
        <div className="card-elevated p-5 lg:col-span-2">
          <div className="flex items-center justify-between mb-4">
            <h3 className="font-display font-semibold">Stock por SKU · Costo Promedio</h3>
            <button onClick={() => setPoOpen(true)} className="inline-flex items-center gap-2 rounded-md bg-primary px-3 py-1.5 text-xs font-medium text-primary-foreground">
              <Plus className="h-3.5 w-3.5" /> Nueva requisición
            </button>
          </div>
          <div className="overflow-x-auto">
            <table className="w-full text-sm">
              <thead className="text-left text-xs uppercase text-muted-foreground bg-muted/30">
                <tr>
                  <th className="px-3 py-2">SKU</th><th className="px-3 py-2">Producto</th>
                  <th className="px-3 py-2 text-right">Stock</th><th className="px-3 py-2 text-right">Costo Prom.</th>
                  <th className="px-3 py-2 text-right">Valor Total</th><th className="px-3 py-2">Estado</th>
                </tr>
              </thead>
              <tbody>
                {inventory.map(it => {
                  const low = it.stock < it.min;
                  return (
                    <tr key={it.sku} onClick={() => setSelSku(it.sku)}
                      className={cn("border-t border-border hover:bg-accent/40 cursor-pointer", selSku === it.sku && "bg-primary/5")}>
                      <td className="px-3 py-2 font-mono text-xs">{it.sku}</td>
                      <td className="px-3 py-2">{it.name}</td>
                      <td className="px-3 py-2 text-right font-medium">{it.stock}</td>
                      <td className="px-3 py-2 text-right">{formatSoles(it.avgCost)}</td>
                      <td className="px-3 py-2 text-right text-primary font-medium">{formatSoles(it.stock * it.avgCost)}</td>
                      <td className="px-3 py-2">
                        {low
                          ? <span className="inline-flex items-center gap-1 rounded-full bg-warning/15 text-warning border border-warning/30 px-2 py-0.5 text-[11px]"><AlertTriangle className="h-3 w-3" /> Mín {it.min}</span>
                          : <span className="inline-flex items-center gap-1 rounded-full bg-success/15 text-success border border-success/30 px-2 py-0.5 text-[11px]">OK</span>}
                      </td>
                    </tr>
                  );
                })}
              </tbody>
            </table>
          </div>
        </div>

        <div className="card-elevated p-5">
          <h3 className="font-display font-semibold mb-4">Forecast demanda (unid)</h3>
          <div className="h-56">
            <ResponsiveContainer width="100%" height="100%">
              <LineChart data={forecast}>
                <CartesianGrid strokeDasharray="3 3" stroke="var(--border)" />
                <XAxis dataKey="w" stroke="var(--muted-foreground)" fontSize={12} />
                <YAxis stroke="var(--muted-foreground)" fontSize={12} />
                <Tooltip contentStyle={{ background: "var(--popover)", border: "1px solid var(--border)", borderRadius: 8 }} />
                <Line type="monotone" dataKey="real" stroke="var(--primary)" strokeWidth={2} dot />
                <Line type="monotone" dataKey="forecast" stroke="var(--success)" strokeDasharray="5 5" strokeWidth={2} dot />
              </LineChart>
            </ResponsiveContainer>
          </div>
        </div>
      </div>

      {/* Kardex Valorado */}
      <div className="card-elevated p-5">
        <div className="flex flex-wrap items-center justify-between gap-3 mb-3">
          <div>
            <h3 className="font-display font-semibold">Kardex Valorado · Costo Promedio Móvil</h3>
            <p className="text-xs text-muted-foreground">SKU seleccionado: <span className="text-primary font-mono">{selSku}</span></p>
          </div>
        </div>
        <div className="overflow-x-auto">
          <table className="w-full text-sm">
            <thead className="text-left text-xs uppercase text-muted-foreground bg-muted/30">
              <tr>
                <th className="px-3 py-2">Fecha</th><th className="px-3 py-2">Tipo</th>
                <th className="px-3 py-2 text-right">Cantidad</th><th className="px-3 py-2 text-right">Costo Unit.</th>
                <th className="px-3 py-2 text-right">Valor Movimiento</th>
                <th className="px-3 py-2 text-right">Saldo</th><th className="px-3 py-2 text-right">Valor Saldo</th>
                <th className="px-3 py-2">Referencia</th>
              </tr>
            </thead>
            <tbody>
              {skuKardex.length === 0 && (
                <tr><td colSpan={8} className="px-3 py-6 text-center text-muted-foreground">Sin movimientos registrados para este SKU.</td></tr>
              )}
              {skuKardex.map(k => (
                <tr key={k.id} className="border-t border-border">
                  <td className="px-3 py-2 font-mono text-xs text-muted-foreground">{k.date}</td>
                  <td className="px-3 py-2">
                    <span className={cn("rounded-full border px-2 py-0.5 text-[11px]",
                      k.type === "Compra" ? "bg-success/15 text-success border-success/30" :
                      k.type === "Venta" ? "bg-primary/15 text-primary border-primary/30" :
                      "bg-warning/15 text-warning border-warning/30")}>{k.type}</span>
                  </td>
                  <td className={cn("px-3 py-2 text-right font-medium", k.qty < 0 && "text-destructive")}>{k.qty > 0 ? "+" : ""}{k.qty}</td>
                  <td className="px-3 py-2 text-right">{formatSoles(k.unitCost)}</td>
                  <td className="px-3 py-2 text-right">{formatSoles(k.totalValue)}</td>
                  <td className="px-3 py-2 text-right font-medium">{k.balance}</td>
                  <td className="px-3 py-2 text-right text-primary">{formatSoles(k.balanceValue)}</td>
                  <td className="px-3 py-2 text-xs text-muted-foreground">{k.note ?? "—"}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>

      {/* Purchase workflow */}
      <div className="card-elevated p-5">
        <div className="flex items-center gap-2 mb-4">
          <ClipboardList className="h-4 w-4 text-primary" />
          <h3 className="font-display font-semibold">Órdenes de Compra · Flujo de aprobación</h3>
        </div>
        <div className="grid md:grid-cols-3 gap-3">
          {(["Requisición", "Aprobada", "Recibida"] as const).map(col => (
            <div key={col} className="rounded-lg border border-border bg-background/40">
              <div className="p-3 border-b border-border text-xs uppercase tracking-widest text-muted-foreground flex items-center justify-between">
                {col}
                <span className="rounded-full bg-muted px-2 py-0.5">{pos.filter(p => p.status === col).length}</span>
              </div>
              <div className="p-3 space-y-2 min-h-[120px]">
                {pos.filter(p => p.status === col).map(p => (
                  <div key={p.id} className="rounded-md border border-border p-3 bg-card">
                    <div className="flex items-center justify-between text-xs">
                      <span className="font-mono">{p.id}</span>
                      <span className="text-muted-foreground">{p.supplier}</span>
                    </div>
                    <p className="mt-1 text-sm">{p.items.length} ítem(s) · {formatSoles(p.items.reduce((s, i) => s + i.qty * i.unitCost, 0))}</p>
                    <div className="mt-2 flex gap-2">
                      {p.status === "Requisición" && (
                        <button onClick={() => { actions.approvePO(p.id); toast.success("Orden aprobada", { description: p.id }); }}
                          className="inline-flex items-center gap-1 rounded bg-primary/15 text-primary px-2 py-1 text-xs hover:bg-primary/25">
                          <CheckCircle2 className="h-3 w-3" /> Aprobar
                        </button>
                      )}
                      {p.status === "Aprobada" && (
                        <>
                          <button onClick={() => setPrintPO(p)} className="inline-flex items-center gap-1 rounded bg-muted px-2 py-1 text-xs hover:bg-accent">
                            <Printer className="h-3 w-3" /> PDF
                          </button>
                          <button onClick={() => { actions.receivePO(p.id); toast.success("Mercadería recibida", { description: `${p.id} · stock actualizado` }); }}
                            className="inline-flex items-center gap-1 rounded bg-success/15 text-success px-2 py-1 text-xs hover:bg-success/25">
                            <PackageCheck className="h-3 w-3" /> Recepcionar
                          </button>
                        </>
                      )}
                      {p.status === "Recibida" && (
                        <span className="text-[11px] text-success flex items-center gap-1"><CheckCircle2 className="h-3 w-3" /> {p.receivedAt}</span>
                      )}
                    </div>
                  </div>
                ))}
                {pos.filter(p => p.status === col).length === 0 && (
                  <p className="text-xs text-muted-foreground text-center py-4">Sin órdenes</p>
                )}
              </div>
            </div>
          ))}
        </div>
      </div>

      {poOpen && <NewPOModal onClose={() => setPoOpen(false)} />}
      {printPO && <POPrintModal po={printPO} onClose={() => setPrintPO(null)} />}
    </div>
  );
}

function NewPOModal({ onClose }: { onClose: () => void }) {
  const inventory = useStore(s => s.inventory);
  const [supplier, setSupplier] = useState(suppliers[0].name);
  const [sku, setSku] = useState(inventory[0]?.sku ?? "");
  const [qty, setQty] = useState("10");
  const [cost, setCost] = useState(String(inventory[0]?.avgCost ?? 0));
  const [err, setErr] = useState<Record<string, string>>({});

  return (
    <div className="fixed inset-0 z-50 grid place-items-center bg-black/70 p-4" onClick={onClose}>
      <div className="w-full max-w-lg card-elevated p-6" onClick={e => e.stopPropagation()}>
        <div className="flex items-start justify-between mb-4">
          <h3 className="font-display text-lg font-semibold">Nueva Requisición de Compra</h3>
          <button onClick={onClose} className="p-1 hover:bg-accent rounded"><X className="h-4 w-4" /></button>
        </div>
        <form onSubmit={(e) => {
          e.preventDefault();
          const errs: Record<string, string> = {};
          const q = Number(qty), c = Number(cost);
          if (!q || q <= 0) errs.qty = "Cantidad requerida";
          if (!c || c <= 0) errs.cost = "Costo requerido";
          setErr(errs);
          if (Object.keys(errs).length) return;
          const it = inventory.find(x => x.sku === sku)!;
          const po = actions.createPO(supplier, [{ sku: it.sku, name: it.name, qty: q, unitCost: c }]);
          toast.success("Requisición creada", { description: `${po.id} · pendiente aprobación` });
          onClose();
        }} className="space-y-3">
          <Field label="Proveedor">
            <select value={supplier} onChange={e => setSupplier(e.target.value)} className="input">
              {suppliers.map(s => <option key={s.ruc} value={s.name}>{s.name}</option>)}
            </select>
          </Field>
          <Field label="SKU">
            <select value={sku} onChange={e => {
              setSku(e.target.value);
              const it = inventory.find(x => x.sku === e.target.value);
              if (it) setCost(String(it.avgCost));
            }} className="input">
              {inventory.map(i => <option key={i.sku} value={i.sku}>{i.sku} — {i.name}</option>)}
            </select>
          </Field>
          <div className="grid grid-cols-2 gap-3">
            <Field label="Cantidad" error={err.qty}><input type="number" min={1} value={qty} onChange={e => setQty(e.target.value)} className={cn("input", err.qty && "!border-destructive")} /></Field>
            <Field label="Costo Unitario" error={err.cost}><input type="number" step="0.01" min={0.01} value={cost} onChange={e => setCost(e.target.value)} className={cn("input", err.cost && "!border-destructive")} /></Field>
          </div>
          <div className="flex justify-end gap-2 pt-2">
            <button type="button" onClick={onClose} className="rounded-md border border-border px-3 py-2 text-sm hover:bg-accent">Cancelar</button>
            <button className="rounded-md bg-primary px-3 py-2 text-sm font-medium text-primary-foreground">Crear requisición</button>
          </div>
        </form>
      </div>
    </div>
  );
}

function POPrintModal({ po, onClose }: { po: PurchaseOrder; onClose: () => void }) {
  const settings = useStore(s => s.settings);
  const total = po.items.reduce((s, i) => s + i.qty * i.unitCost, 0);
  return (
    <div className="fixed inset-0 z-50 grid place-items-center bg-black/70 p-4" onClick={onClose}>
      <div className="w-full max-w-2xl bg-white text-slate-900 rounded-xl p-8 shadow-2xl" onClick={e => e.stopPropagation()}>
        <div className="flex items-start justify-between border-b border-slate-200 pb-4">
          <div>
            <p className="text-xs uppercase tracking-widest text-slate-500">Orden de Compra</p>
            <h2 className="text-2xl font-bold">{po.id}</h2>
          </div>
          <div className="text-right text-sm">
            <p className="font-bold">C2TECK S.A.C.</p>
            <p className="text-slate-500">RUC {settings.ruc}</p>
            <p className="text-slate-500">Lima, Perú</p>
          </div>
        </div>
        <div className="grid grid-cols-2 gap-4 py-4 text-sm">
          <div><p className="text-slate-500 text-xs">Proveedor</p><p className="font-medium">{po.supplier}</p></div>
          <div><p className="text-slate-500 text-xs">Fecha de emisión</p><p className="font-medium">{po.createdAt}</p></div>
        </div>
        <table className="w-full text-sm border-t border-slate-200">
          <thead className="text-left text-xs uppercase text-slate-500">
            <tr><th className="py-2">SKU</th><th className="py-2">Descripción</th><th className="py-2 text-right">Cant.</th><th className="py-2 text-right">Costo U.</th><th className="py-2 text-right">Subtotal</th></tr>
          </thead>
          <tbody>
            {po.items.map((i, idx) => (
              <tr key={idx} className="border-t border-slate-100">
                <td className="py-2 font-mono text-xs">{i.sku}</td>
                <td className="py-2">{i.name}</td>
                <td className="py-2 text-right">{i.qty}</td>
                <td className="py-2 text-right">S/ {i.unitCost.toFixed(2)}</td>
                <td className="py-2 text-right font-medium">S/ {(i.qty * i.unitCost).toFixed(2)}</td>
              </tr>
            ))}
          </tbody>
        </table>
        <div className="mt-4 flex justify-end">
          <div className="w-64 text-sm">
            <div className="flex justify-between py-1"><span className="text-slate-500">Subtotal</span><span>S/ {(total / (1 + settings.igvRate / 100)).toFixed(2)}</span></div>
            <div className="flex justify-between py-1"><span className="text-slate-500">IGV ({settings.igvRate}%)</span><span>S/ {(total - total / (1 + settings.igvRate / 100)).toFixed(2)}</span></div>
            <div className="flex justify-between border-t border-slate-200 pt-2 font-bold text-base"><span>Total</span><span>S/ {total.toFixed(2)}</span></div>
          </div>
        </div>
        <div className="mt-6 flex justify-end gap-2">
          <button onClick={onClose} className="rounded-md border border-slate-300 px-3 py-2 text-sm text-slate-700 hover:bg-slate-50">Cerrar</button>
          <button onClick={() => { window.print(); toast.success("Impresión enviada"); }} className="rounded-md bg-slate-900 text-white px-4 py-2 text-sm font-medium">Imprimir / PDF</button>
        </div>
      </div>
    </div>
  );
}

/* -------- Contabilidad -------- */
function ContaTab() {
  const books = [
    { code: "PLE 5.1", name: "Registro de Compras", period: "2026-06", status: "Generado" },
    { code: "PLE 14.1", name: "Registro de Ventas", period: "2026-06", status: "Generado" },
    { code: "PLE 3.1", name: "Libro Mayor", period: "2026-05", status: "Enviado" },
    { code: "PLE 8.1", name: "Libro Diario", period: "2026-05", status: "Enviado" },
  ];
  return (
    <div className="space-y-4">
      <div className="grid grid-cols-1 sm:grid-cols-3 gap-4">
        <KpiCard label="Cuentas por Cobrar" value="S/ 428,150" delta="+12 clientes activos" icon={Calculator} accent="primary" />
        <KpiCard label="Cuentas por Pagar" value="S/ 187,420" delta="Vencen esta semana: 3" icon={Calculator} accent="warning" />
        <KpiCard label="Flujo neto (mes)" value="S/ 240,730" delta="Margen 34%" icon={TrendingUp} accent="success" />
      </div>
      <div className="card-elevated p-5">
        <h3 className="font-display font-semibold mb-3">Libros Electrónicos (PLE) generados</h3>
        <div className="overflow-x-auto -mx-2 sm:mx-0">
        <table className="w-full text-sm min-w-[560px]">
          <thead className="text-left text-xs uppercase text-muted-foreground bg-muted/30">
            <tr><th className="px-4 py-3">Código</th><th className="px-4 py-3">Libro</th><th className="px-4 py-3">Periodo</th><th className="px-4 py-3">Estado</th></tr>
          </thead>
          <tbody>
            {books.map(b => (
              <tr key={b.code} className="border-t border-border hover:bg-accent/40">
                <td className="px-4 py-3 font-mono text-xs">{b.code}</td>
                <td className="px-4 py-3">{b.name}</td>
                <td className="px-4 py-3 text-muted-foreground">{b.period}</td>
                <td className="px-4 py-3"><span className="inline-flex items-center gap-1 rounded-full bg-success/15 text-success border border-success/30 px-2 py-0.5 text-[11px]">{b.status}</span></td>
              </tr>
            ))}
          </tbody>
        </table>
        </div>
      </div>
    </div>
  );
}

/* -------- Planillas -------- */
function PlanillasTab() {
  return (
    <div className="grid lg:grid-cols-3 gap-4">
      <div className="card-elevated p-5 lg:col-span-2">
        <h3 className="font-display font-semibold mb-3">Directorio de empleados</h3>
        <div className="overflow-x-auto">
          <table className="w-full text-sm">
            <thead className="text-left text-xs uppercase text-muted-foreground bg-muted/30">
              <tr><th className="px-4 py-3">DNI</th><th className="px-4 py-3">Nombre</th><th className="px-4 py-3">Cargo</th><th className="px-4 py-3">Área</th><th className="px-4 py-3">Turno</th><th className="px-4 py-3">Estado</th></tr>
            </thead>
            <tbody>
              {employees.map(e => (
                <tr key={e.dni} className="border-t border-border hover:bg-accent/40">
                  <td className="px-4 py-3 font-mono text-xs">{e.dni}</td>
                  <td className="px-4 py-3 font-medium">{e.name}</td>
                  <td className="px-4 py-3">{e.role}</td>
                  <td className="px-4 py-3 text-muted-foreground">{e.area}</td>
                  <td className="px-4 py-3">{e.shift}</td>
                  <td className="px-4 py-3"><StatusBadge status={e.status} /></td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
      <div className="card-elevated p-5">
        <h3 className="font-display font-semibold mb-3">Alta rápida</h3>
        <PlanillaForm />
      </div>
    </div>
  );
}

function PlanillaForm() {
  const [dni, setDni] = useState(""); const [name, setName] = useState(""); const [role, setRole] = useState("");
  const [err, setErr] = useState<Record<string, string>>({});
  return (
    <form onSubmit={(e) => {
      e.preventDefault();
      const errs: Record<string, string> = {};
      if (!/^\d{8}$/.test(dni)) errs.dni = "DNI debe tener 8 dígitos";
      if (name.trim().length < 3) errs.name = "Nombre requerido";
      if (role.trim().length < 2) errs.role = "Cargo requerido";
      setErr(errs);
      if (Object.keys(errs).length) return;
      toast.success("Empleado registrado en PLAME", { description: `${name} · DNI ${dni}` });
      setDni(""); setName(""); setRole("");
    }} className="space-y-3">
      <Field label="DNI" error={err.dni}><input value={dni} onChange={e => setDni(e.target.value)} className={cn("input", err.dni && "!border-destructive")} maxLength={8} placeholder="12345678" /></Field>
      <Field label="Nombre completo" error={err.name}><input value={name} onChange={e => setName(e.target.value)} className={cn("input", err.name && "!border-destructive")} /></Field>
      <Field label="Cargo" error={err.role}><input value={role} onChange={e => setRole(e.target.value)} className={cn("input", err.role && "!border-destructive")} /></Field>
      <Field label="Turno"><select className="input"><option>Diurno</option><option>Nocturno</option><option>Rotativo</option></select></Field>
      <button className="w-full rounded-md bg-primary py-2 text-sm font-medium text-primary-foreground">Registrar</button>
    </form>
  );
}

/* -------- Servicio Técnico · Kanban + PM -------- */
const OT_COLUMNS: OTStatus[] = ["Por Asignar", "En Diagnóstico", "En Reparación", "Listas para Entrega"];

function TecnicoTab() {
  const workOrders = useStore(s => s.workOrders);
  const [pmHours, setPmHours] = useState("10000");

  return (
    <div className="space-y-4">
      <div className="grid grid-cols-1 sm:grid-cols-4 gap-4">
        <KpiCard label="OTs abiertas" value={String(workOrders.filter(o => o.status !== "Listas para Entrega").length)} icon={Wrench} accent="primary" />
        <KpiCard label="Horas motor totales" value={workOrders.reduce((s, o) => s + o.hours, 0).toLocaleString()} icon={TrendingUp} accent="success" />
        <KpiCard label="Requieren PM" value={String(workOrders.filter(o => o.needsPM).length)} icon={ShieldAlert} accent="warning" />
        <KpiCard label="SLA cumplido" value="98.4%" icon={FileText} accent="success" />
      </div>

      {/* PM trigger */}
      <div className="card-elevated p-5">
        <div className="flex items-center gap-2 mb-3">
          <Timer className="h-4 w-4 text-primary" />
          <h3 className="font-display font-semibold">Programador de Mantenimiento Preventivo</h3>
        </div>
        <div className="flex flex-wrap items-end gap-3">
          <label className="flex-1 min-w-[220px]">
            <span className="text-xs text-muted-foreground">Umbral de horas-motor</span>
            <input type="number" value={pmHours} onChange={e => setPmHours(e.target.value)}
              className="mt-1 w-full h-10 rounded-md bg-muted px-3 text-sm border border-border outline-none focus:border-primary" />
          </label>
          <button onClick={() => {
            const n = Number(pmHours);
            if (!n || n <= 0) { toast.error("Umbral inválido"); return; }
            const flagged = actions.triggerPMCheck(n);
            if (flagged > 0) toast.warning(`${flagged} activo(s) requieren mantenimiento inmediato`, { description: `Umbral: ${n.toLocaleString()} h` });
            else toast.success("Ningún activo excede el umbral");
          }} className="rounded-md bg-primary px-4 h-10 text-sm font-medium text-primary-foreground">
            Ejecutar chequeo
          </button>
        </div>
      </div>

      {/* Kanban */}
      <div className="grid md:grid-cols-2 xl:grid-cols-4 gap-3">
        {OT_COLUMNS.map((col) => (
          <div key={col} className="rounded-lg border border-border bg-background/40">
            <div className="p-3 border-b border-border text-xs uppercase tracking-widest text-muted-foreground flex items-center justify-between">
              {col}
              <span className="rounded-full bg-muted px-2 py-0.5">{workOrders.filter(o => o.status === col).length}</span>
            </div>
            <div className="p-3 space-y-2 min-h-[200px]">
              {workOrders.filter(o => o.status === col).map(o => {
                const nextIdx = OT_COLUMNS.indexOf(o.status) + 1;
                const nextCol = OT_COLUMNS[nextIdx];
                return (
                  <div key={o.id} className="rounded-md border border-border p-3 bg-card">
                    <div className="flex items-center justify-between">
                      <p className="font-mono text-[11px] text-muted-foreground">{o.id}</p>
                      {o.needsPM && <span className="rounded-full bg-warning/15 text-warning border border-warning/30 px-2 py-0.5 text-[10px]">PM</span>}
                    </div>
                    <p className="text-sm font-medium mt-1">{o.asset}</p>
                    <p className="text-xs text-muted-foreground">{o.client}</p>
                    <div className="flex items-center justify-between mt-2 text-[11px] text-muted-foreground">
                      <span>{o.hours.toLocaleString()}h / {o.hoursLimit.toLocaleString()}h</span>
                      <StatusBadge status={o.priority} />
                    </div>
                    {nextCol && (
                      <button onClick={() => { actions.moveOT(o.id, nextCol); toast.success(`OT movida a "${nextCol}"`, { description: o.id }); }}
                        className="mt-2 w-full inline-flex items-center justify-center gap-1 rounded bg-primary/15 text-primary px-2 py-1 text-xs hover:bg-primary/25">
                        Avanzar <ArrowRight className="h-3 w-3" />
                      </button>
                    )}
                  </div>
                );
              })}
              {workOrders.filter(o => o.status === col).length === 0 && (
                <p className="text-xs text-muted-foreground text-center py-4">Vacío</p>
              )}
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}

/* -------- Inteligencia de Negocios -------- */
function BITab() {
  const sales = useStore(s => s.sales);
  const tenant = useStore(s => s.tenants.find(t => t.id === s.currentTenantId));
  const [range, setRange] = useState<"hoy" | "7d" | "mes">("mes");
  const [branch, setBranch] = useState("all");

  const ventasVsImport = [
    { m: "Ene", ventas: 128000, importaciones: 92000, margen: 36000 },
    { m: "Feb", ventas: 141200, importaciones: 88400, margen: 52800 },
    { m: "Mar", ventas: 156800, importaciones: 95100, margen: 61700 },
    { m: "Abr", ventas: 149300, importaciones: 101200, margen: 48100 },
    { m: "May", ventas: 172400, importaciones: 98700, margen: 73700 },
    { m: "Jun", ventas: 189600, importaciones: 104500, margen: 85100 },
    { m: "Jul", ventas: 205100 + sales.reduce((s, x) => s + x.total, 0) / 100, importaciones: 110300, margen: 94800 },
  ];

  const marginByCat = [
    { cat: "Hardware TI", margen: 22.4 },
    { cat: "Consumibles", margen: 41.2 },
    { cat: "Servicios Cloud", margen: 68.7 },
    { cat: "Licencias SW", margen: 55.3 },
    { cat: "Retail Zigma", margen: 18.9 },
    { cat: "Alimentos POS", margen: 32.1 },
  ];

  const savedByParkView = [
    { m: "Feb", ahorro: 12400 },
    { m: "Mar", ahorro: 18700 },
    { m: "Abr", ahorro: 21200 },
    { m: "May", ahorro: 34500 },
    { m: "Jun", ahorro: 41800 },
    { m: "Jul", ahorro: 52300 },
  ];

  const verticals = [
    { name: "Zigma Restaurantes", tx: 4218, revenue: 128940, color: "var(--primary)" },
    { name: "Zigma Retail", tx: 3891, revenue: 98410, color: "var(--success)" },
    { name: "Zigma Hoteles", tx: 1240, revenue: 214800, color: "var(--warning)" },
    { name: "Zigma SPA/Gym", tx: 812, revenue: 45700, color: "var(--destructive)" },
  ].sort((a, b) => b.revenue - a.revenue);

  return (
    <div className="space-y-4">
      <div className="card-elevated p-4 flex flex-wrap items-center gap-3">
        <BarChart3 className="h-4 w-4 text-primary" />
        <h3 className="font-display font-semibold">Panel Analítico · {tenant?.name}</h3>
        <div className="ml-auto flex items-center gap-2 text-xs">
          <select value={range} onChange={e => setRange(e.target.value as typeof range)} className="h-9 rounded-md bg-muted border border-border px-2">
            <option value="hoy">Hoy</option>
            <option value="7d">Últimos 7 días</option>
            <option value="mes">Este mes</option>
          </select>
          <select value={branch} onChange={e => setBranch(e.target.value)} className="h-9 rounded-md bg-muted border border-border px-2">
            <option value="all">Todas las sucursales</option>
            <option>Lima Centro</option>
            <option>Miraflores</option>
            <option>San Borja</option>
            <option>Callao</option>
          </select>
        </div>
      </div>

      <div className="grid grid-cols-1 md:grid-cols-4 gap-4">
        <KpiCard label="Ventas del período" value={formatSoles(sales.reduce((s, x) => s + x.total, 0) + 892450)} delta="+22% vs anterior" icon={TrendingUp} accent="success" />
        <KpiCard label="Margen neto" value="41.8%" delta="+3.2 pts" icon={BarChart3} accent="primary" />
        <KpiCard label="Ahorro ParkView™" value={formatSoles(52300)} delta="Downtime evitado" icon={ShieldAlert} accent="warning" />
        <KpiCard label="Ticket promedio" value={formatSoles(148.4)} icon={FileText} accent="primary" />
      </div>

      <div className="grid lg:grid-cols-2 gap-4">
        <div className="card-elevated p-5">
          <h3 className="font-display font-semibold mb-4">Ventas vs. Costo de Importaciones</h3>
          <div className="h-64">
            <ResponsiveContainer width="100%" height="100%">
              <BarChart data={ventasVsImport}>
                <CartesianGrid strokeDasharray="3 3" stroke="var(--border)" />
                <XAxis dataKey="m" stroke="var(--muted-foreground)" fontSize={12} />
                <YAxis stroke="var(--muted-foreground)" fontSize={12} />
                <Tooltip contentStyle={{ background: "var(--popover)", border: "1px solid var(--border)", borderRadius: 8 }} />
                <Legend wrapperStyle={{ fontSize: 11 }} />
                <Bar dataKey="ventas" fill="var(--primary)" radius={[4, 4, 0, 0]} />
                <Bar dataKey="importaciones" fill="var(--warning)" radius={[4, 4, 0, 0]} />
                <Bar dataKey="margen" fill="var(--success)" radius={[4, 4, 0, 0]} />
              </BarChart>
            </ResponsiveContainer>
          </div>
        </div>

        <div className="card-elevated p-5">
          <h3 className="font-display font-semibold mb-4">Margen de Ganancia por Categoría (%)</h3>
          <div className="h-64">
            <ResponsiveContainer width="100%" height="100%">
              <BarChart data={marginByCat} layout="vertical">
                <CartesianGrid strokeDasharray="3 3" stroke="var(--border)" />
                <XAxis type="number" stroke="var(--muted-foreground)" fontSize={12} />
                <YAxis type="category" dataKey="cat" stroke="var(--muted-foreground)" fontSize={11} width={110} />
                <Tooltip contentStyle={{ background: "var(--popover)", border: "1px solid var(--border)", borderRadius: 8 }} />
                <Bar dataKey="margen" radius={[0, 4, 4, 0]}>
                  {marginByCat.map((_, i) => <Cell key={i} fill={i % 2 ? "var(--primary)" : "var(--success)"} />)}
                </Bar>
              </BarChart>
            </ResponsiveContainer>
          </div>
        </div>

        <div className="card-elevated p-5">
          <h3 className="font-display font-semibold mb-4">Pérdidas Evitadas · ParkView™ AI (S/)</h3>
          <div className="h-64">
            <ResponsiveContainer width="100%" height="100%">
              <LineChart data={savedByParkView}>
                <CartesianGrid strokeDasharray="3 3" stroke="var(--border)" />
                <XAxis dataKey="m" stroke="var(--muted-foreground)" fontSize={12} />
                <YAxis stroke="var(--muted-foreground)" fontSize={12} />
                <Tooltip contentStyle={{ background: "var(--popover)", border: "1px solid var(--border)", borderRadius: 8 }} />
                <Line type="monotone" dataKey="ahorro" stroke="var(--success)" strokeWidth={3} dot={{ r: 4 }} />
              </LineChart>
            </ResponsiveContainer>
          </div>
        </div>

        <div className="card-elevated p-5">
          <div className="flex items-center gap-2 mb-4">
            <Trophy className="h-4 w-4 text-warning" />
            <h3 className="font-display font-semibold">Top Verticales Zigma (volumen)</h3>
          </div>
          <ul className="space-y-3">
            {verticals.map((v, i) => {
              const max = verticals[0].revenue;
              const pct = (v.revenue / max) * 100;
              return (
                <li key={v.name}>
                  <div className="flex items-center justify-between text-xs mb-1">
                    <span className="flex items-center gap-2">
                      <span className={cn("h-6 w-6 rounded-full grid place-items-center text-[11px] font-bold",
                        i === 0 ? "bg-warning/20 text-warning" : "bg-muted text-muted-foreground")}>#{i + 1}</span>
                      <span className="font-medium">{v.name}</span>
                    </span>
                    <span className="font-mono">{formatSoles(v.revenue)}</span>
                  </div>
                  <div className="h-2 rounded-full bg-muted overflow-hidden">
                    <div className="h-full rounded-full" style={{ width: `${pct}%`, background: v.color }} />
                  </div>
                  <p className="mt-1 text-[10px] text-muted-foreground">{v.tx.toLocaleString()} transacciones · ticket prom. {formatSoles(v.revenue / v.tx)}</p>
                </li>
              );
            })}
          </ul>
        </div>
      </div>
    </div>
  );
}

