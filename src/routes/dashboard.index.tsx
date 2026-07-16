import { createFileRoute } from "@tanstack/react-router";
import { Link } from "@tanstack/react-router";
import { Building2, Activity, ShieldAlert, Server, PlusCircle, AppWindow, KeyRound } from "lucide-react";
import { toast } from "sonner";
import {
  Area,
  AreaChart,
  Bar,
  BarChart,
  CartesianGrid,
  Legend,
  ResponsiveContainer,
  Tooltip,
  XAxis,
  YAxis,
} from "recharts";
import { KpiCard } from "@/components/ui/kpi-card";
import { salesInventory, aiEvents } from "@/lib/mock-data";

export const Route = createFileRoute("/dashboard/")({
  head: () => ({
    meta: [
      { title: "Global Overview · C2Teck S.A.C." },
      { name: "description", content: "Consola ejecutiva C2Teck con KPIs de negocio, ERP, infraestructura TI y seguridad." },
    ],
  }),
  component: Overview,
});

function Overview() {
  return (
    <div className="space-y-6">
      <header className="flex flex-wrap items-end justify-between gap-4">
        <div>
          <p className="text-xs uppercase tracking-widest text-primary">Consola ejecutiva</p>
          <h1 className="text-3xl font-display font-bold">Global Overview</h1>
          <p className="text-sm text-muted-foreground mt-1">Panorama consolidado del ecosistema C2Teck en tiempo real.</p>
        </div>
        <div className="flex flex-wrap gap-2">
          <button
            onClick={() => toast.success("Cliente registrado", { description: "Se envió invitación al portal." })}
            className="inline-flex items-center gap-2 rounded-md bg-primary px-3.5 py-2 text-sm font-medium text-primary-foreground hover:opacity-90"
          >
            <PlusCircle className="h-4 w-4" /> Registrar Cliente
          </button>
          <Link to="/dashboard/zigma" className="inline-flex items-center gap-2 rounded-md border border-border bg-card px-3.5 py-2 text-sm font-medium hover:bg-accent">
            <AppWindow className="h-4 w-4" /> Deploy Zigma
          </Link>
          <Link to="/dashboard/security" className="inline-flex items-center gap-2 rounded-md border border-border bg-card px-3.5 py-2 text-sm font-medium hover:bg-accent">
            <KeyRound className="h-4 w-4" /> Tokens Hideez
          </Link>
        </div>
      </header>

      <div className="grid grid-cols-1 sm:grid-cols-2 xl:grid-cols-4 gap-4">
        <KpiCard label="Negocios Conectados" value="1,284" delta="+42 este mes" icon={Building2} accent="primary" />
        <KpiCard label="Sesiones ERP Activas" value="9,412" delta="Pico 10,120" icon={Activity} accent="success" />
        <KpiCard label="Infra Uptime" value="99.98%" delta="ParkView™ AI monitor" icon={Server} accent="success" />
        <KpiCard label="Alertas TI Pendientes" value="7" delta="2 críticas" icon={ShieldAlert} accent="warning" />
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-3 gap-4">
        <div className="card-elevated p-5 lg:col-span-2">
          <div className="flex items-center justify-between mb-4">
            <div>
              <h3 className="font-display font-semibold">Ventas vs. Rotación de Inventario</h3>
              <p className="text-xs text-muted-foreground">Consolidado multi-cliente · últimos 12 meses (PEN)</p>
            </div>
            <div className="flex items-center gap-3 text-xs">
              <span className="flex items-center gap-1.5"><span className="h-2 w-2 rounded-full bg-primary" /> Ventas</span>
              <span className="flex items-center gap-1.5"><span className="h-2 w-2 rounded-full bg-success" /> Inventario</span>
            </div>
          </div>
          <div className="h-72">
            <ResponsiveContainer width="100%" height="100%">
              <AreaChart data={salesInventory}>
                <defs>
                  <linearGradient id="gVentas" x1="0" y1="0" x2="0" y2="1">
                    <stop offset="0%" stopColor="var(--primary)" stopOpacity={0.5} />
                    <stop offset="100%" stopColor="var(--primary)" stopOpacity={0} />
                  </linearGradient>
                  <linearGradient id="gInv" x1="0" y1="0" x2="0" y2="1">
                    <stop offset="0%" stopColor="var(--success)" stopOpacity={0.5} />
                    <stop offset="100%" stopColor="var(--success)" stopOpacity={0} />
                  </linearGradient>
                </defs>
                <CartesianGrid strokeDasharray="3 3" stroke="var(--border)" />
                <XAxis dataKey="month" stroke="var(--muted-foreground)" fontSize={12} />
                <YAxis stroke="var(--muted-foreground)" fontSize={12} />
                <Tooltip contentStyle={{ background: "var(--popover)", border: "1px solid var(--border)", borderRadius: 8 }} />
                <Area type="monotone" dataKey="ventas" stroke="var(--primary)" fill="url(#gVentas)" strokeWidth={2} />
                <Area type="monotone" dataKey="inventario" stroke="var(--success)" fill="url(#gInv)" strokeWidth={2} />
              </AreaChart>
            </ResponsiveContainer>
          </div>
        </div>
        <div className="card-elevated p-5">
          <h3 className="font-display font-semibold">Eventos AI en vivo</h3>
          <p className="text-xs text-muted-foreground mb-3">Predicciones ParkView™</p>
          <ul className="space-y-3 max-h-72 overflow-y-auto pr-2">
            {aiEvents.map((e, i) => (
              <li key={i} className="flex gap-3 text-sm">
                <span className="font-mono text-[11px] text-muted-foreground pt-0.5">{e.t}</span>
                <span
                  className={
                    "mt-1 h-2 w-2 rounded-full shrink-0 " +
                    (e.sev === "warn" ? "bg-warning" : e.sev === "success" ? "bg-success" : "bg-primary")
                  }
                />
                <span className="text-foreground/90">{e.msg}</span>
              </li>
            ))}
          </ul>
        </div>
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-3 gap-4">
        <div className="card-elevated p-5 lg:col-span-2">
          <h3 className="font-display font-semibold mb-4">Transacciones por módulo (semana)</h3>
          <div className="h-64">
            <ResponsiveContainer width="100%" height="100%">
              <BarChart data={[
                { d: "Lun", ERP: 4200, Zigma: 3100, TI: 620 },
                { d: "Mar", ERP: 4820, Zigma: 3520, TI: 710 },
                { d: "Mié", ERP: 5100, Zigma: 3810, TI: 690 },
                { d: "Jue", ERP: 4980, Zigma: 3620, TI: 740 },
                { d: "Vie", ERP: 6210, Zigma: 4400, TI: 810 },
                { d: "Sáb", ERP: 5320, Zigma: 5100, TI: 520 },
                { d: "Dom", ERP: 2100, Zigma: 3900, TI: 310 },
              ]}>
                <CartesianGrid strokeDasharray="3 3" stroke="var(--border)" />
                <XAxis dataKey="d" stroke="var(--muted-foreground)" fontSize={12} />
                <YAxis stroke="var(--muted-foreground)" fontSize={12} />
                <Tooltip contentStyle={{ background: "var(--popover)", border: "1px solid var(--border)", borderRadius: 8 }} />
                <Legend wrapperStyle={{ fontSize: 12 }} />
                <Bar dataKey="ERP" fill="var(--primary)" radius={[4, 4, 0, 0]} />
                <Bar dataKey="Zigma" fill="var(--success)" radius={[4, 4, 0, 0]} />
                <Bar dataKey="TI" fill="var(--warning)" radius={[4, 4, 0, 0]} />
              </BarChart>
            </ResponsiveContainer>
          </div>
        </div>
        <div className="card-elevated p-5">
          <h3 className="font-display font-semibold">Fix Rate ParkView™</h3>
          <div className="mt-6 flex items-center justify-center">
            <div className="relative h-40 w-40">
              <svg viewBox="0 0 100 100" className="h-full w-full -rotate-90">
                <circle cx="50" cy="50" r="42" stroke="var(--muted)" strokeWidth="10" fill="none" />
                <circle
                  cx="50" cy="50" r="42" stroke="var(--success)" strokeWidth="10" fill="none"
                  strokeDasharray={2 * Math.PI * 42}
                  strokeDashoffset={2 * Math.PI * 42 * (1 - 0.97)}
                  strokeLinecap="round"
                />
              </svg>
              <div className="absolute inset-0 grid place-items-center">
                <div className="text-center">
                  <div className="text-3xl font-display font-bold text-success">97%</div>
                  <div className="text-[10px] uppercase tracking-widest text-muted-foreground">1ra visita</div>
                </div>
              </div>
            </div>
          </div>
          <p className="text-xs text-muted-foreground text-center mt-4">
            Resolución automatizada por AI + ingeniero en sitio.
          </p>
        </div>
      </div>
    </div>
  );
}
