import { Fragment, useState } from "react";
import { createFileRoute } from "@tanstack/react-router";
import { toast } from "sonner";
import { Hotel, Utensils, ShoppingCart, Scissors, Dumbbell, Check, Clock, Bell, X, Printer, Banknote, CreditCard, Smartphone } from "lucide-react";
import { zigmaNiches } from "@/lib/mock-data";
import { cn } from "@/lib/utils";
import { StatusBadge } from "@/components/ui/status-badge";
import { actions, useStore, type SaleLine, type Sale } from "@/lib/store";

export const Route = createFileRoute("/dashboard/zigma")({
  head: () => ({
    meta: [
      { title: "Zigma Apps · C2Teck" },
      { name: "description", content: "Repositorio de aplicaciones Zigma para hoteles, restaurantes, tiendas, spa y gimnasios." },
    ],
  }),
  component: ZigmaPage,
});

const ICONS = { hoteles: Hotel, restaurantes: Utensils, tiendas: ShoppingCart, spa: Scissors, gimnasios: Dumbbell } as const;
type Key = keyof typeof ICONS;

function ZigmaPage() {
  const [active, setActive] = useState<Key>("hoteles");
  return (
    <div className="space-y-6">
      <header>
        <p className="text-xs uppercase tracking-widest text-primary">Repositorio de aplicaciones</p>
        <h1 className="text-3xl font-display font-bold">Zigma Apps</h1>
        <p className="text-sm text-muted-foreground mt-1">Presets configurables por nicho — activación en 1 clic.</p>
      </header>

      <div className="grid grid-cols-2 md:grid-cols-3 xl:grid-cols-5 gap-4">
        {zigmaNiches.map(n => {
          const Icon = ICONS[n.key as Key];
          const isActive = active === n.key;
          return (
            <button
              key={n.key}
              onClick={() => setActive(n.key as Key)}
              className={cn(
                "text-left card-elevated p-5 relative overflow-hidden transition-all",
                isActive ? "ring-2 ring-primary glow" : "hover:border-primary/40",
              )}
            >
              <div className={cn("absolute -right-8 -top-8 h-24 w-24 rounded-full blur-2xl opacity-40 bg-gradient-to-br", n.color)} />
              <Icon className="h-6 w-6 text-primary" />
              <h3 className="mt-3 font-display font-semibold">{n.name}</h3>
              <p className="text-xs text-muted-foreground mt-1 leading-relaxed">{n.desc}</p>
              <p className="mt-3 text-xs"><span className="text-primary font-bold">{n.clients}</span> clientes activos</p>
            </button>
          );
        })}
      </div>

      <div className="card-elevated p-5">
        {active === "hoteles" && <HotelesView />}
        {active === "restaurantes" && <RestaurantesView />}
        {active === "tiendas" && <TiendasView />}
        {active === "spa" && <SpaView />}
        {active === "gimnasios" && <GymView />}
      </div>
    </div>
  );
}

function HotelesView() {
  const rooms = Array.from({ length: 30 }, (_, i) => {
    const states = ["libre", "ocupada", "checkout", "limpieza"] as const;
    const s = states[(i * 7) % 4];
    return { n: 101 + i, s };
  });
  const color = { libre: "bg-success/20 text-success border-success/40", ocupada: "bg-primary/20 text-primary border-primary/40", checkout: "bg-warning/20 text-warning border-warning/40", limpieza: "bg-muted text-muted-foreground border-border" };
  return (
    <div>
      <div className="flex items-center justify-between mb-4">
        <h3 className="font-display font-semibold">Mapa de habitaciones · Hoy</h3>
        <div className="flex flex-wrap gap-2 text-xs">
          {Object.entries(color).map(([k, c]) => (
            <span key={k} className={cn("rounded-full border px-2 py-0.5 capitalize", c)}>{k}</span>
          ))}
        </div>
      </div>
      <div className="grid grid-cols-5 sm:grid-cols-8 lg:grid-cols-10 gap-2">
        {rooms.map(r => (
          <button
            key={r.n}
            onClick={() => toast(`Habitación ${r.n}`, { description: `Estado: ${r.s}` })}
            className={cn("aspect-square rounded-md border grid place-items-center text-xs font-mono font-semibold hover:scale-105 transition", color[r.s])}
          >
            {r.n}
          </button>
        ))}
      </div>
      <div className="grid md:grid-cols-3 gap-3 mt-6">
        {["Standard", "Deluxe", "Suite"].map(t => (
          <div key={t} className="rounded-lg border border-border p-4">
            <p className="text-xs uppercase text-muted-foreground">Room type</p>
            <p className="font-display font-semibold">{t}</p>
            <p className="text-2xl font-bold text-primary mt-1">{Math.floor(Math.random() * 15) + 5}</p>
            <p className="text-xs text-muted-foreground">disponibles</p>
          </div>
        ))}
      </div>
    </div>
  );
}

function RestaurantesView() {
  const tables = Array.from({ length: 12 }, (_, i) => ({ n: i + 1, busy: (i * 3) % 5 < 2, guests: 2 + (i % 4) }));
  const orders = [
    { table: 4, items: [{ sku: "MENU-LS", name: "Lomo saltado", price: 32, qty: 1 }, { sku: "BEB-CM", name: "Chicha morada", price: 8, qty: 1 }], time: "12:04" },
    { table: 7, items: [{ sku: "MENU-CV", name: "Ceviche mixto", price: 45, qty: 1 }, { sku: "BEB-IK", name: "Inca Kola", price: 7, qty: 1 }], time: "12:06" },
    { table: 2, items: [{ sku: "MENU-AG", name: "Ají de gallina", price: 28, qty: 2 }], time: "12:09" },
  ];
  const [checkout, setCheckout] = useState<SaleLine[] | null>(null);
  return (
    <div className="grid lg:grid-cols-2 gap-6">
      <div>
        <h3 className="font-display font-semibold mb-3">Mapa de mesas</h3>
        <div className="grid grid-cols-3 sm:grid-cols-4 gap-3">
          {tables.map(t => (
            <button key={t.n} onClick={() => toast(`Mesa ${t.n}`, { description: t.busy ? `${t.guests} comensales` : "Libre" })}
              className={cn("aspect-square rounded-lg border grid place-items-center font-display font-bold text-lg",
                t.busy ? "bg-primary/15 text-primary border-primary/40" : "bg-success/10 text-success border-success/30")}>
              {t.n}
              <span className="text-[10px] font-normal opacity-70">{t.busy ? `${t.guests} pax` : "libre"}</span>
            </button>
          ))}
        </div>
        <button onClick={() => toast.success("Arqueo de caja cerrado", { description: "Turno noche · S/ 3,240.50" })}
          className="mt-4 w-full rounded-md bg-primary/15 text-primary py-2.5 text-sm font-medium hover:bg-primary/25">
          Cerrar arqueo de caja (turno actual)
        </button>
      </div>
      <div>
        <h3 className="font-display font-semibold mb-3">Comandas activas</h3>
        <ul className="space-y-3">
          {orders.map((o, i) => (
            <li key={i} className="rounded-lg border border-border p-3">
              <div className="flex items-center gap-3">
                <div className="h-10 w-10 rounded bg-warning/15 text-warning grid place-items-center font-bold">M{o.table}</div>
                <div className="flex-1">
                  <p className="text-sm font-medium">{o.items.map(x => `${x.name}${x.qty > 1 ? ` x${x.qty}` : ""}`).join(" · ")}</p>
                  <p className="text-xs text-muted-foreground flex items-center gap-1"><Clock className="h-3 w-3" /> {o.time}</p>
                </div>
                <button onClick={() => toast.success("Marcado como servido")}
                  className="rounded-md bg-success/15 text-success p-2 hover:bg-success/25"><Check className="h-4 w-4" /></button>
              </div>
              <button onClick={() => setCheckout(o.items)}
                className="mt-2 w-full rounded-md bg-primary py-1.5 text-xs font-medium text-primary-foreground hover:opacity-90">
                Finalizar venta · Mesa {o.table}
              </button>
            </li>
          ))}
        </ul>
      </div>
      {checkout && <CheckoutModal items={checkout} channel="Zigma" onClose={() => setCheckout(null)} />}
    </div>
  );
}

function TiendasView() {
  const [items, setItems] = useState<SaleLine[]>([
    { sku: "SKU-7788", name: "Coca-Cola 500ml", price: 3.5, qty: 2 },
    { sku: "SKU-7789", name: "Pan francés x6", price: 2.0, qty: 1 },
  ]);
  const [checkout, setCheckout] = useState(false);
  const total = items.reduce((s, i) => s + i.price * i.qty, 0);
  return (
    <div className="grid lg:grid-cols-3 gap-6">
      <div className="lg:col-span-2">
        <h3 className="font-display font-semibold mb-3">Checkout rápido</h3>
        <form onSubmit={(e) => {
          e.preventDefault();
          const val = (e.currentTarget.elements.namedItem("barcode") as HTMLInputElement).value;
          if (!val) return;
          setItems(prev => [...prev, { sku: val, name: `Producto ${val}`, price: Math.round(Math.random() * 20 + 2), qty: 1 }]);
          (e.target as HTMLFormElement).reset();
          toast.success("Producto escaneado");
        }} className="flex gap-2 mb-3">
          <input name="barcode" placeholder="Escanear código de barras..." className="flex-1 h-11 rounded-md bg-muted px-4 font-mono border border-border outline-none focus:border-primary" />
          <button className="rounded-md bg-primary px-4 text-sm font-medium text-primary-foreground">Agregar</button>
        </form>
        <div className="overflow-x-auto -mx-2 sm:mx-0">
        <table className="w-full text-sm min-w-[520px]">
          <thead className="text-left text-xs uppercase text-muted-foreground bg-muted/30">
            <tr><th className="px-3 py-2">SKU</th><th className="px-3 py-2">Producto</th><th className="px-3 py-2 text-right">P.U.</th><th className="px-3 py-2 text-right">Cant.</th><th className="px-3 py-2 text-right">Total</th><th /></tr>
          </thead>
          <tbody>
            {items.map((i, idx) => (
              <tr key={idx} className="border-t border-border">
                <td className="px-3 py-2 font-mono text-xs">{i.sku}</td>
                <td className="px-3 py-2">{i.name}</td>
                <td className="px-3 py-2 text-right">S/ {i.price.toFixed(2)}</td>
                <td className="px-3 py-2 text-right">{i.qty}</td>
                <td className="px-3 py-2 text-right font-medium">S/ {(i.price * i.qty).toFixed(2)}</td>
                <td className="px-3 py-2 text-right">
                  <button onClick={() => setItems(prev => prev.filter((_, k) => k !== idx))} className="text-muted-foreground hover:text-destructive"><X className="h-3.5 w-3.5" /></button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
        </div>
      </div>
      <div className="rounded-xl bg-gradient-to-br from-primary/20 to-success/10 border border-primary/30 p-6">
        <p className="text-xs uppercase text-muted-foreground">Total a cobrar</p>
        <p className="text-5xl font-display font-bold text-primary mt-2">S/ {total.toFixed(2)}</p>
        <p className="text-xs text-muted-foreground mt-1">Incluye IGV 18%</p>
        <button onClick={() => { if (!items.length) { toast.error("Carrito vacío"); return; } setCheckout(true); }}
          className="mt-6 w-full rounded-md bg-primary py-3 text-sm font-semibold text-primary-foreground">
          Cobrar y emitir boleta
        </button>
        <div className="mt-4 rounded-lg bg-background/50 p-3 text-xs">
          <p className="font-medium mb-1">Kardex resumido</p>
          <p className="text-muted-foreground">1,284 SKUs · rotación 8.3 días</p>
        </div>
      </div>
      {checkout && <CheckoutModal items={items} channel="Zigma" onClose={() => setCheckout(false)} onDone={() => setItems([])} />}
    </div>
  );
}

/* -------- Shared POS Checkout Modal -------- */
function CheckoutModal({ items, channel, onClose, onDone }: {
  items: SaleLine[]; channel: "Zigma" | "ERP"; onClose: () => void; onDone?: () => void;
}) {
  const settings = useStore(s => s.settings);
  const total = items.reduce((s, i) => s + i.price * i.qty, 0);
  const [cash, setCash] = useState("0");
  const [card, setCard] = useState("0");
  const [yape, setYape] = useState(String(total.toFixed(2)));
  const [sendSunat, setSendSunat] = useState(true);
  const [receipt, setReceipt] = useState<Sale | null>(null);

  const paid = Number(cash || 0) + Number(card || 0) + Number(yape || 0);
  const change = paid - total;

  if (receipt) return <ThermalReceiptModal sale={receipt} onClose={() => { setReceipt(null); onDone?.(); onClose(); }} />;

  return (
    <div className="fixed inset-0 z-50 grid place-items-center bg-black/70 p-4" onClick={onClose}>
      <div className="w-full max-w-lg card-elevated p-6" onClick={e => e.stopPropagation()}>
        <div className="flex items-start justify-between mb-4">
          <div>
            <h3 className="font-display text-lg font-semibold">Módulo de Pago</h3>
            <p className="text-xs text-muted-foreground">Divide el monto entre los medios disponibles.</p>
          </div>
          <button onClick={onClose} className="p-1 hover:bg-accent rounded"><X className="h-4 w-4" /></button>
        </div>

        <div className="rounded-lg bg-muted/30 border border-border p-4 mb-4 text-center">
          <p className="text-xs uppercase text-muted-foreground">Total a cobrar</p>
          <p className="text-4xl font-display font-bold text-primary">S/ {total.toFixed(2)}</p>
        </div>

        <div className="space-y-3">
          <PayField icon={Banknote} label="Efectivo" value={cash} onChange={setCash} />
          <PayField icon={CreditCard} label="Tarjeta (POS Visa/MC)" value={card} onChange={setCard} />
          <PayField icon={Smartphone} label="Yape / Plin (QR)" value={yape} onChange={setYape} />
        </div>

        <div className="mt-3 rounded-md border border-border p-3 text-sm flex items-center justify-between">
          <span className="text-muted-foreground">Pagado</span>
          <span className="font-medium">S/ {paid.toFixed(2)}</span>
        </div>
        <div className={cn("mt-2 rounded-md border p-3 text-sm flex items-center justify-between",
          change >= 0 ? "border-success/40 bg-success/10 text-success" : "border-destructive/40 bg-destructive/10 text-destructive")}>
          <span>{change >= 0 ? "Vuelto" : "Falta"}</span>
          <span className="font-bold">S/ {Math.abs(change).toFixed(2)}</span>
        </div>

        <label className="mt-3 flex items-center gap-2 text-sm">
          <input type="checkbox" checked={sendSunat} onChange={e => setSendSunat(e.target.checked)} className="h-4 w-4 rounded border-border" />
          Enviar automáticamente a SUNAT ({settings.correlativos.boleta})
        </label>

        <div className="mt-4 flex justify-end gap-2">
          <button onClick={onClose} className="rounded-md border border-border px-3 py-2 text-sm hover:bg-accent">Cancelar</button>
          <button
            disabled={change < 0}
            onClick={() => {
              const payments = [
                { method: "Efectivo", amount: Number(cash) || 0 },
                { method: "Tarjeta", amount: Number(card) || 0 },
                { method: "Yape/Plin", amount: Number(yape) || 0 },
              ].filter(p => p.amount > 0);
              const sale = actions.registerSale({ channel, items, payments, sunatSent: sendSunat });
              toast.success(sendSunat ? "Boleta emitida y enviada a SUNAT" : "Venta registrada", {
                description: `${sale.serie} · ${sale.items.length} ítem(s) · stock actualizado`,
              });
              setReceipt(sale);
            }}
            className="rounded-md bg-primary px-4 py-2 text-sm font-semibold text-primary-foreground disabled:opacity-40">
            Finalizar Venta
          </button>
        </div>
      </div>
    </div>
  );
}

function PayField({ icon: Icon, label, value, onChange }: { icon: React.ComponentType<{ className?: string }>; label: string; value: string; onChange: (v: string) => void }) {
  return (
    <label className="flex items-center gap-3 rounded-md border border-border bg-muted/30 px-3 py-2">
      <Icon className="h-4 w-4 text-primary" />
      <span className="text-sm flex-1">{label}</span>
      <span className="text-xs text-muted-foreground">S/</span>
      <input type="number" step="0.01" min={0} value={value} onChange={e => onChange(e.target.value)}
        className="w-24 h-8 rounded bg-background px-2 text-right text-sm border border-border outline-none focus:border-primary" />
    </label>
  );
}

function ThermalReceiptModal({ sale, onClose }: { sale: Sale; onClose: () => void }) {
  const settings = useStore(s => s.settings);
  return (
    <div className="fixed inset-0 z-50 grid place-items-center bg-black/70 p-4" onClick={onClose}>
      <div className="w-full max-w-xs bg-white text-slate-900 rounded-md p-5 font-mono text-xs leading-relaxed shadow-2xl" onClick={e => e.stopPropagation()}>
        <div className="text-center border-b border-dashed border-slate-300 pb-2">
          <p className="font-bold text-sm">C2TECK S.A.C.</p>
          <p>RUC {settings.ruc}</p>
          <p>Av. Javier Prado 1234 · Lima</p>
          <p className="mt-1">BOLETA ELECTRÓNICA</p>
          <p className="font-bold">{sale.serie}</p>
        </div>
        <div className="py-2 border-b border-dashed border-slate-300">
          <p>Fecha: {sale.date}</p>
          <p>Cliente: {sale.client}</p>
        </div>
        <div className="py-2 border-b border-dashed border-slate-300 space-y-1">
          {sale.items.map((i, idx) => (
            <div key={idx}>
              <p>{i.name}</p>
              <p className="flex justify-between"><span>{i.qty} x {i.price.toFixed(2)}</span><span>{(i.qty * i.price).toFixed(2)}</span></p>
            </div>
          ))}
        </div>
        <div className="py-2 border-b border-dashed border-slate-300">
          <p className="flex justify-between"><span>Op. Gravada</span><span>S/ {(sale.total / (1 + settings.igvRate / 100)).toFixed(2)}</span></p>
          <p className="flex justify-between"><span>IGV ({settings.igvRate}%)</span><span>S/ {(sale.total - sale.total / (1 + settings.igvRate / 100)).toFixed(2)}</span></p>
          <p className="flex justify-between font-bold text-sm mt-1"><span>TOTAL</span><span>S/ {sale.total.toFixed(2)}</span></p>
        </div>
        <div className="py-2 border-b border-dashed border-slate-300">
          {sale.paymentMethods.map((p, i) => <p key={i} className="flex justify-between"><span>{p.method}</span><span>S/ {p.amount.toFixed(2)}</span></p>)}
        </div>
        <div className="text-center pt-2 space-y-0.5">
          <p>{sale.sunatSent ? "✓ Aceptado por SUNAT" : "⧗ Pendiente de envío"}</p>
          <p>Representación impresa de la BE</p>
          <p>Gracias por su compra</p>
        </div>
        <div className="mt-3 flex gap-2">
          <button onClick={() => { window.print(); toast.success("Ticket impreso"); }} className="flex-1 inline-flex items-center justify-center gap-1 rounded bg-slate-900 text-white py-2 text-xs">
            <Printer className="h-3 w-3" /> Imprimir
          </button>
          <button onClick={onClose} className="flex-1 rounded border border-slate-300 py-2 text-xs">Cerrar</button>
        </div>
      </div>
    </div>
  );
}

function SpaView() {
  const specialists = ["Ana G.", "Diego M.", "Karla V."];
  const slots = ["09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00"];
  return (
    <div>
      <div className="flex items-center justify-between mb-4">
        <h3 className="font-display font-semibold">Agenda por especialista · Hoy</h3>
        <div className="text-xs text-muted-foreground">Comisiones acumuladas: <span className="text-success font-bold">S/ 1,240</span></div>
      </div>
      <div className="overflow-x-auto">
        <div className="min-w-[600px] grid gap-2" style={{ gridTemplateColumns: `120px repeat(${slots.length}, 1fr)` }}>
          <div />
          {slots.map(s => <div key={s} className="text-xs text-muted-foreground text-center">{s}</div>)}
          {specialists.map(sp => (
            <Fragment key={sp}>
              <div className="text-sm font-medium py-2">{sp}</div>
              {slots.map((slot, i) => {
                const booked = (sp.length + i) % 3 === 0;
                return (
                  <button key={sp + slot}
                    onClick={() => toast(booked ? "Cita reservada" : "Slot disponible", { description: `${sp} · ${slot}` })}
                    className={cn("h-12 rounded-md border text-xs transition",
                      booked ? "bg-primary/15 text-primary border-primary/30" : "bg-muted/30 border-border hover:bg-accent")}>
                    {booked ? "Corte + Color" : "—"}
                  </button>
                );
              })}
            </Fragment>
          ))}
        </div>
      </div>
    </div>
  );
}

function GymView() {
  const members = [
    { name: "Andrea Cortez", plan: "Anual", expires: "2026-08-14", checked: true, status: "Activo" },
    { name: "Renzo Guevara", plan: "Mensual", expires: "2026-07-05", checked: true, status: "Activo" },
    { name: "Paola Ríos", plan: "Trimestral", expires: "2026-07-02", checked: false, status: "Vacaciones" },
    { name: "Bruno Salas", plan: "Mensual", expires: "2026-06-28", checked: false, status: "Inactivo" },
  ];
  return (
    <div>
      <div className="flex items-center justify-between mb-3">
        <h3 className="font-display font-semibold">Membresías</h3>
        <button onClick={() => toast.success("Notificación enviada a 3 socios", { description: "Vencimientos próximos" })}
          className="inline-flex items-center gap-2 rounded-md bg-primary/15 text-primary px-3 py-2 text-xs font-medium hover:bg-primary/25">
          <Bell className="h-3.5 w-3.5" /> Enviar recordatorios
        </button>
      </div>
      <div className="overflow-x-auto -mx-2 sm:mx-0">
      <table className="w-full text-sm min-w-[560px]">
        <thead className="text-left text-xs uppercase text-muted-foreground bg-muted/30">
          <tr><th className="px-3 py-2">Socio</th><th className="px-3 py-2">Plan</th><th className="px-3 py-2">Vencimiento</th><th className="px-3 py-2">Check-in hoy</th><th className="px-3 py-2">Estado</th></tr>
        </thead>
        <tbody>
          {members.map(m => (
            <tr key={m.name} className="border-t border-border hover:bg-accent/40">
              <td className="px-3 py-2 font-medium">{m.name}</td>
              <td className="px-3 py-2">{m.plan}</td>
              <td className="px-3 py-2 text-muted-foreground">{m.expires}</td>
              <td className="px-3 py-2">{m.checked ? <Check className="h-4 w-4 text-success" /> : <span className="text-muted-foreground">—</span>}</td>
              <td className="px-3 py-2"><StatusBadge status={m.status} /></td>
            </tr>
          ))}
        </tbody>
      </table>
      </div>
    </div>
  );
}
