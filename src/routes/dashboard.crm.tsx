import { createFileRoute } from "@tanstack/react-router";
import { toast } from "sonner";
import { Mail, MapPin, Phone, Send, Users } from "lucide-react";
import { useEffect, useState } from "react";
import { KpiCard } from "@/components/ui/kpi-card";
import { StatusBadge } from "@/components/ui/status-badge";
import { leads } from "@/lib/mock-data";
import { fetchBackendHealth, fetchSigecoomClients, type BackendHealth, type SigecoomClient } from "@/lib/sigecoom-api";

export const Route = createFileRoute("/dashboard/crm")({
  head: () => ({
    meta: [
      { title: "Contact & CRM · C2Teck" },
      { name: "description", content: "Solicita demos y visualiza leads corporativos." },
    ],
  }),
  component: CRMPage,
});

function CRMPage() {
  const [clients, setClients] = useState<SigecoomClient[]>([]);
  const [loadingClients, setLoadingClients] = useState(true);
  const [sourceInfo, setSourceInfo] = useState<BackendHealth | null>(null);

  useEffect(() => {
    let ignore = false;

    fetchBackendHealth()
      .then((health) => {
        if (!ignore) {
          setSourceInfo(health);
        }
      })
      .catch(() => {
        if (!ignore) {
          setSourceInfo({ status: "unavailable", database: "unknown" });
        }
      });

    fetchSigecoomClients()
      .then((data) => {
        if (!ignore) {
          setClients(data);
          setLoadingClients(false);
        }
      })
      .catch(() => {
        if (!ignore) {
          setClients([]);
          setLoadingClients(false);
        }
      });

    return () => {
      ignore = true;
    };
  }, []);

  return (
    <div className="space-y-6">
      <header>
        <p className="text-xs uppercase tracking-widest text-primary">Contact & CRM</p>
        <h1 className="text-3xl font-display font-bold">Leads & Solicitudes</h1>
        <p className="text-sm text-muted-foreground mt-1">Consultas técnicas y demos ruteadas a <span className="text-primary">crios@c2teck.com.pe</span>.</p>
      </header>

      <div className="grid grid-cols-1 sm:grid-cols-4 gap-4">
        <KpiCard label="Leads este mes" value="94" delta="+21% MoM" icon={Users} accent="primary" />
        <KpiCard label="Clientes SIGECOM" value={loadingClients ? "…" : String(clients.length)} icon={Users} accent="success" />
        <KpiCard label="Demos agendadas" value="18" icon={Send} accent="success" />
        <KpiCard label="En negociación" value="7" delta="Ticket promedio S/ 48k" icon={Users} accent="warning" />
        <KpiCard label="Ganados YTD" value="41" icon={Users} accent="success" />
      </div>

      <div className="grid lg:grid-cols-5 gap-4">
        <div className="card-elevated p-6 lg:col-span-2">
          <h3 className="font-display font-semibold">Solicita una demo</h3>
          <p className="text-xs text-muted-foreground mb-4">Un consultor te contactará en menos de 24 horas.</p>
          <form onSubmit={(e) => {
            e.preventDefault();
            toast.success("Solicitud enviada", { description: "Ruteada a crios@c2teck.com.pe" });
            (e.target as HTMLFormElement).reset();
          }} className="space-y-3">
            <div className="grid grid-cols-2 gap-3">
              <F label="Nombre"><input required className="inp" /></F>
              <F label="Empresa"><input required className="inp" /></F>
            </div>
            <F label="Email corporativo"><input required type="email" className="inp" placeholder="nombre@empresa.pe" /></F>
            <F label="Teléfono"><input className="inp" placeholder="+51 999 999 999" /></F>
            <F label="¿Qué módulo te interesa?">
              <select className="inp">
                <option>ERP Systeck</option>
                <option>Zigma — Hoteles</option>
                <option>Zigma — Restaurantes</option>
                <option>Zigma — Tiendas</option>
                <option>Zigma — SPA</option>
                <option>Zigma — Gimnasios</option>
                <option>ParkView TI</option>
                <option>Hideez Passwordless</option>
              </select>
            </F>
            <F label="Mensaje"><textarea rows={4} className="inp resize-none" /></F>
            <button className="w-full inline-flex items-center justify-center gap-2 rounded-md bg-primary py-2.5 text-sm font-semibold text-primary-foreground">
              <Send className="h-4 w-4" /> Enviar solicitud
            </button>
          </form>
          <div className="mt-6 space-y-2 text-sm">
            <div className="flex items-center gap-3"><Mail className="h-4 w-4 text-primary" /> <span>crios@c2teck.com.pe</span></div>
            <div className="flex items-center gap-3"><Phone className="h-4 w-4 text-primary" /> <span>+51 (1) 555-2100</span></div>
            <div className="flex items-center gap-3"><MapPin className="h-4 w-4 text-primary" /> <span>Av. Universitaria 1234, San Martín de Porres, Lima</span></div>
          </div>
        </div>

        <div className="card-elevated p-5 lg:col-span-3">
          <div className="flex items-center justify-between mb-3">
            <h3 className="font-display font-semibold">Pipeline de leads</h3>
            <div className="text-xs text-muted-foreground">Últimos {leads.length}</div>
          </div>
          <div className="overflow-x-auto">
            <table className="w-full text-sm">
              <thead className="text-left text-xs uppercase text-muted-foreground bg-muted/30">
                <tr><th className="px-3 py-2">ID</th><th className="px-3 py-2">Cliente</th><th className="px-3 py-2">Contacto</th><th className="px-3 py-2">Interés</th><th className="px-3 py-2">Etapa</th></tr>
              </thead>
              <tbody>
                {leads.map(l => (
                  <tr key={l.id} className="border-t border-border hover:bg-accent/40">
                    <td className="px-3 py-2 font-mono text-xs">{l.id}</td>
                    <td className="px-3 py-2 font-medium">{l.name}</td>
                    <td className="px-3 py-2 text-muted-foreground">{l.contact}</td>
                    <td className="px-3 py-2">{l.interest}</td>
                    <td className="px-3 py-2"><StatusBadge status={l.stage} /></td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>

          <div className="mt-6 rounded-lg border border-border p-4">
            <div className="flex items-center justify-between">
              <h4 className="font-display font-semibold">Clientes desde la API SIGECOM original</h4>
              <span className="text-xs text-muted-foreground">{loadingClients ? "Cargando…" : `${clients.length} registros`}</span>
            </div>
            <div className="mt-2 flex items-center gap-2 text-[11px] text-muted-foreground">
              <span className="h-2 w-2 rounded-full bg-emerald-500" />
              <span className="font-medium">Fuente activa:</span>
              <span>{sourceInfo?.database ?? "unknown"}</span>
              <span className="text-slate-400">·</span>
              <span>{sourceInfo?.status ?? "unknown"}</span>
            </div>
            <div className="mt-3 space-y-2">
              {clients.length > 0 ? (
                clients.slice(0, 8).map((client) => (
                  <div key={client.id} className="flex items-center justify-between rounded-md border border-border bg-muted/20 px-3 py-2 text-sm">
                    <div>
                      <p className="font-medium">{client.name}</p>
                      <p className="text-xs text-muted-foreground">RUC {client.ruc ?? "-"} · {client.address ?? "Sin dirección"}</p>
                    </div>
                    <span className="text-xs text-primary">#{client.id}</span>
                  </div>
                ))
              ) : (
                <p className="text-sm text-muted-foreground">Sin datos desde el origen original todavía.</p>
              )}
            </div>
          </div>

          <div className="mt-6 grid grid-cols-2 md:grid-cols-4 gap-3">
            {["Nuevo", "Demo Agendada", "Propuesta", "Negociación"].map((stage) => {
              const count = leads.filter(l => l.stage === stage).length + Math.floor(Math.random() * 8) + 3;
              return (
                <div key={stage} className="rounded-lg border border-border p-4">
                  <p className="text-xs uppercase text-muted-foreground">{stage}</p>
                  <p className="text-2xl font-display font-bold text-primary mt-1">{count}</p>
                </div>
              );
            })}
          </div>
        </div>
      </div>
    </div>
  );
}

function F({ label, children }: { label: string; children: React.ReactNode }) {
  return (
    <label className="block">
      <span className="text-xs text-muted-foreground">{label}</span>
      <div className="mt-1 [&_.inp]:w-full [&_.inp]:min-h-10 [&_.inp]:rounded-md [&_.inp]:bg-muted [&_.inp]:px-3 [&_.inp]:py-2 [&_.inp]:text-sm [&_.inp]:border [&_.inp]:border-border [&_.inp]:outline-none [&_.inp:focus]:border-primary">
        {children}
      </div>
    </label>
  );
}
