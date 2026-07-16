import { createFileRoute } from "@tanstack/react-router";
import { useState } from "react";
import { Server, Cpu, HardDrive, Activity, Zap, PlayCircle, UserPlus, Stethoscope, CheckCircle2, X } from "lucide-react";
import { toast } from "sonner";
import { KpiCard } from "@/components/ui/kpi-card";
import { StatusBadge } from "@/components/ui/status-badge";
import { aiEvents } from "@/lib/mock-data";
import { useStore, actions, type InfraTicket } from "@/lib/store";
import { cn } from "@/lib/utils";

export const Route = createFileRoute("/dashboard/infrastructure")({
  head: () => ({
    meta: [
      { title: "Infraestructura TI · ParkView™ · C2Teck" },
      { name: "description", content: "Centro operacional automatizado con AI predictiva y ticketing." },
    ],
  }),
  component: InfraPage,
});

const ENGINEERS = ["Miguel Cárdenas", "Luis Palomino", "Ana Ramos", "Carlos Ríos"];

function InfraPage() {
  const allServers = useStore(s => s.servers);
  const allTickets = useStore(s => s.infraTickets);
  const q = useStore(s => s.searchQuery).trim().toLowerCase();
  const servers = q
    ? allServers.filter(sv => (sv.name + " " + sv.role + " " + sv.status).toLowerCase().includes(q))
    : allServers;
  const tickets = q
    ? allTickets.filter(t => (t.id + " " + t.server + " " + t.issue + " " + (t.tech ?? "")).toLowerCase().includes(q))
    : allTickets;
  const [openTicket, setOpenTicket] = useState<InfraTicket | null>(null);

  const activeTickets = allTickets.filter(t => t.status !== "Resuelto");

  return (
    <div className="space-y-6">
      <header className="flex flex-wrap items-start justify-between gap-3">
        <div>
          <p className="text-xs uppercase tracking-widest text-primary">ParkView™ Automated Support</p>
          <h1 className="text-3xl font-display font-bold">Infraestructura TI</h1>
          <p className="text-sm text-muted-foreground mt-1">Monitoreo predictivo, ticketing automático y despacho de ingenieros.</p>
        </div>
        <button onClick={() => {
          const t = actions.simulateIncident();
          if (t) toast.warning("Incidente detectado por AI", { description: `${t.id} · ${t.server}` });
        }} className="inline-flex items-center gap-2 rounded-md bg-primary/15 text-primary px-3 py-2 text-sm hover:bg-primary/25">
          <PlayCircle className="h-4 w-4" /> Simular incidente
        </button>
      </header>

      <div className="grid grid-cols-1 sm:grid-cols-4 gap-4">
        <KpiCard label="Servidores gestionados" value={String(servers.length + 122)} icon={Server} accent="primary" />
        <KpiCard label="Fix rate 1ra visita" value="97%" icon={Zap} accent="success" />
        <KpiCard label="Tickets activos" value={String(activeTickets.length)} icon={Activity} accent={activeTickets.length > 2 ? "warning" : "success"} />
        <KpiCard label="Eventos AI (24h)" value="1,842" delta="12 acciones auto" icon={Cpu} accent="warning" />
      </div>

      <div className="card-elevated p-5">
        <h3 className="font-display font-semibold mb-4">Datacenter · Hardware Grid</h3>
        <div className="space-y-2">
          {servers.map(s => (
            <div key={s.name} className="grid grid-cols-12 items-center gap-3 rounded-lg border border-border p-3 hover:bg-accent/40 transition-colors">
              <div className="col-span-12 md:col-span-4 flex items-center gap-3">
                <div className={cn("h-9 w-9 rounded-md grid place-items-center",
                  s.status === "OK" ? "bg-success/15 text-success" : s.status === "Alerta" ? "bg-warning/15 text-warning" : "bg-destructive/15 text-destructive")}>
                  <HardDrive className="h-4 w-4" />
                </div>
                <div>
                  <p className="font-mono text-xs text-muted-foreground">{s.name}</p>
                  <p className="text-sm font-medium">{s.role}</p>
                </div>
              </div>
              <Metric label="CPU" value={s.cpu} />
              <Metric label="RAM" value={s.ram} />
              <Metric label="Temp °C" value={s.temp} max={80} unit="°" />
              <div className="col-span-6 md:col-span-2 flex justify-end"><StatusBadge status={s.status} /></div>
            </div>
          ))}
        </div>
      </div>

      <div className="grid lg:grid-cols-2 gap-4">
        <div className="card-elevated p-5">
          <h3 className="font-display font-semibold mb-3">Live event logger · AI predictivo</h3>
          <ul className="space-y-3 max-h-80 overflow-y-auto pr-2 font-mono text-xs">
            {aiEvents.concat(aiEvents).map((e, i) => (
              <li key={i} className="flex gap-3">
                <span className="text-muted-foreground">{e.t}</span>
                <span className={cn("uppercase font-bold",
                  e.sev === "warn" ? "text-warning" : e.sev === "success" ? "text-success" : "text-primary")}>[{e.sev}]</span>
                <span className="text-foreground/90">{e.msg}</span>
              </li>
            ))}
          </ul>
        </div>
        <div className="card-elevated p-5">
          <h3 className="font-display font-semibold mb-3">Tickets · Consola activa</h3>
          <div className="space-y-3 max-h-80 overflow-y-auto pr-1">
            {tickets.map(t => (
              <button key={t.id} onClick={() => setOpenTicket(t)}
                className="w-full text-left rounded-lg border border-border p-4 hover:bg-accent/40">
                <div className="flex items-center justify-between">
                  <p className="font-mono text-xs text-muted-foreground">{t.id}</p>
                  <StatusBadge status={t.status === "Resuelto" ? "Cerrado" : t.status === "Abierto" ? "Alta" : t.status} />
                </div>
                <p className="mt-1 text-sm font-medium">{t.issue}</p>
                <div className="mt-2 flex items-center justify-between text-xs text-muted-foreground">
                  <span>Servidor: <span className="text-foreground">{t.server}</span></span>
                  <span>👤 {t.tech ?? "Sin asignar"}</span>
                </div>
              </button>
            ))}
          </div>
        </div>
      </div>

      {openTicket && <TicketConsoleModal ticket={openTicket} onClose={() => setOpenTicket(null)} />}
    </div>
  );
}

function TicketConsoleModal({ ticket, onClose }: { ticket: InfraTicket; onClose: () => void }) {
  const live = useStore(s => s.infraTickets.find(t => t.id === ticket.id)) ?? ticket;
  const [tech, setTech] = useState(live.tech ?? ENGINEERS[0]);
  const done = live.status === "Resuelto";

  return (
    <div className="fixed inset-0 z-50 grid place-items-center bg-black/70 p-4" onClick={onClose}>
      <div className="w-full max-w-2xl card-elevated p-6" onClick={e => e.stopPropagation()}>
        <div className="flex items-start justify-between mb-4">
          <div>
            <p className="font-mono text-xs text-muted-foreground">{live.id}</p>
            <h3 className="font-display text-lg font-semibold">{live.issue}</h3>
            <p className="text-xs text-muted-foreground">Servidor <span className="text-primary font-mono">{live.server}</span> · abierto {live.createdAt}</p>
          </div>
          <button onClick={onClose} className="p-1 hover:bg-accent rounded"><X className="h-4 w-4" /></button>
        </div>

        <div className="grid md:grid-cols-2 gap-4">
          <div className="space-y-3">
            <div className="rounded-lg border border-border p-3">
              <p className="text-xs uppercase text-muted-foreground mb-2">Ingeniero asignado</p>
              <div className="flex gap-2">
                <select value={tech} onChange={e => setTech(e.target.value)} disabled={done}
                  className="flex-1 h-9 rounded-md bg-muted px-2 text-sm border border-border outline-none focus:border-primary">
                  {ENGINEERS.map(e => <option key={e}>{e}</option>)}
                </select>
                <button disabled={done || live.tech === tech}
                  onClick={() => { actions.assignTicket(live.id, tech); toast.success("Ingeniero asignado", { description: `${live.id} · ${tech}` }); }}
                  className="inline-flex items-center gap-1 rounded bg-primary/15 text-primary px-3 text-xs disabled:opacity-40 hover:bg-primary/25">
                  <UserPlus className="h-3 w-3" /> Asignar
                </button>
              </div>
            </div>
            <button disabled={done || live.status === "En Diagnóstico"}
              onClick={() => { actions.diagnoseTicket(live.id); toast.success("Diagnóstico iniciado", { description: `Ingeniero conectado vía IPMI` }); }}
              className="w-full inline-flex items-center justify-center gap-2 rounded-md bg-warning/15 text-warning py-2 text-sm hover:bg-warning/25 disabled:opacity-40">
              <Stethoscope className="h-4 w-4" /> Iniciar diagnóstico
            </button>
            <button disabled={done}
              onClick={() => {
                actions.resolveTicket(live.id);
                toast.success("Incidente resuelto", { description: `${live.server} restaurado · MTTR 28 min · SLA cumplido` });
              }}
              className="w-full inline-flex items-center justify-center gap-2 rounded-md bg-success/15 text-success py-2 text-sm hover:bg-success/25 disabled:opacity-40">
              <CheckCircle2 className="h-4 w-4" /> Resolver incidente
            </button>

            {done && (
              <div className="rounded-lg border border-success/40 bg-success/10 p-3 text-xs">
                <p className="font-semibold text-success">Métricas post-resolución</p>
                <p className="text-success/90 mt-1">MTTR: 28 min · Downtime evitado: 3h 12m · CSAT: 5/5</p>
              </div>
            )}
          </div>

          <div className="rounded-lg border border-border bg-background/60 p-3">
            <p className="text-xs uppercase text-muted-foreground mb-2">Telemetría / Logs</p>
            <ul className="font-mono text-[11px] space-y-1 max-h-60 overflow-y-auto">
              {live.telemetry.map((t, i) => <li key={i} className="text-foreground/85">{t}</li>)}
            </ul>
          </div>
        </div>
      </div>
    </div>
  );
}

function Metric({ label, value, max = 100, unit = "%" }: { label: string; value: number; max?: number; unit?: string }) {
  const pct = Math.min(100, (value / max) * 100);
  const color = pct > 85 ? "bg-destructive" : pct > 70 ? "bg-warning" : "bg-primary";
  return (
    <div className="col-span-4 md:col-span-2">
      <div className="flex items-center justify-between text-[10px] uppercase text-muted-foreground">
        <span>{label}</span>
        <span className="text-foreground font-medium">{value}{unit}</span>
      </div>
      <div className="mt-1 h-1.5 rounded-full bg-muted overflow-hidden">
        <div className={cn("h-full rounded-full transition-all", color)} style={{ width: `${pct}%` }} />
      </div>
    </div>
  );
}
