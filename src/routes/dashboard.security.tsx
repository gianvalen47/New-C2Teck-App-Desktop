import { createFileRoute } from "@tanstack/react-router";
import { useEffect, useState } from "react";
import { toast } from "sonner";
import { KeyRound, Bluetooth, Nfc, Usb, ShieldCheck, ShieldAlert, Fingerprint, Plus, Activity, Radio } from "lucide-react";
import { KpiCard } from "@/components/ui/kpi-card";
import { StatusBadge } from "@/components/ui/status-badge";
import { hideezDevices } from "@/lib/mock-data";
import { useStore, actions, type AuthLog } from "@/lib/store";
import { cn } from "@/lib/utils";

export const Route = createFileRoute("/dashboard/security")({
  head: () => ({
    meta: [
      { title: "Seguridad Hideez · C2Teck" },
      { name: "description", content: "Autenticación passwordless FIDO2/WebAuthn con Hideez Key 3 y 4." },
    ],
  }),
  component: SecurityPage,
});

const linkIcon = { Bluetooth, NFC: Nfc, USB: Usb } as const;

function SecurityPage() {
  const [access, setAccess] = useState<Record<string, { web: boolean; vpn: boolean; erp: boolean; proxLock: boolean }>>({
    "carlos.rios@c2teck.com.pe": { web: true, vpn: true, erp: true, proxLock: true },
    "ana.salcedo@c2teck.com.pe": { web: true, vpn: true, erp: true, proxLock: false },
    "luis.palomino@c2teck.com.pe": { web: true, vpn: false, erp: false, proxLock: true },
    "rosa.villalba@c2teck.com.pe": { web: true, vpn: false, erp: true, proxLock: true },
  });

  return (
    <div className="space-y-6">
      <header>
        <p className="text-xs uppercase tracking-widest text-primary">Hideez Hardware Identity</p>
        <h1 className="text-3xl font-display font-bold">Seguridad & Autenticación</h1>
        <p className="text-sm text-muted-foreground mt-1">Passwordless FIDO2 / WebAuthn — protección universal anti-phishing.</p>
      </header>

      <div className="grid grid-cols-1 sm:grid-cols-4 gap-4">
        <KpiCard label="Dispositivos activos" value="128" icon={KeyRound} accent="primary" />
        <KpiCard label="Cuentas passwordless" value="342" icon={ShieldCheck} accent="success" />
        <KpiCard label="Intentos phishing bloqueados" value="1,207" icon={ShieldAlert} accent="warning" />
        <KpiCard label="Sesiones biométricas hoy" value="86" icon={Fingerprint} accent="primary" />
      </div>

      <div className="grid lg:grid-cols-3 gap-4">
        <div className="card-elevated p-6 lg:col-span-1">
          <h3 className="font-display font-semibold mb-4">Device Manager</h3>
          <div className="space-y-4">
            <DeviceCard model="Hideez Key 4" desc="Bluetooth · NFC · USB-C" gradient="from-primary/30 to-cyan-500/20" />
            <DeviceCard model="Hideez Key 3" desc="Bluetooth · USB-A" gradient="from-success/25 to-emerald-500/15" />
            <button
              onClick={() => toast.success("Hideez Key registrada", { description: "FIDO2 credential provisionada" })}
              className="w-full inline-flex items-center justify-center gap-2 rounded-md border border-dashed border-border py-3 text-sm hover:border-primary hover:text-primary transition">
              <Plus className="h-4 w-4" /> Registrar nueva llave
            </button>
          </div>
        </div>

        <div className="card-elevated p-5 lg:col-span-2">
          <h3 className="font-display font-semibold mb-3">Llaves aprovisionadas</h3>
          <div className="overflow-x-auto">
            <table className="w-full text-sm">
              <thead className="text-left text-xs uppercase text-muted-foreground bg-muted/30">
                <tr><th className="px-3 py-2">ID</th><th className="px-3 py-2">Modelo</th><th className="px-3 py-2">Usuario</th><th className="px-3 py-2">Enlace</th><th className="px-3 py-2">Batería</th><th className="px-3 py-2">Estado</th></tr>
              </thead>
              <tbody>
                {hideezDevices.map(d => {
                  const Icon = linkIcon[d.link as keyof typeof linkIcon] || Bluetooth;
                  return (
                    <tr key={d.id} className="border-t border-border hover:bg-accent/40">
                      <td className="px-3 py-2 font-mono text-xs">{d.id}</td>
                      <td className="px-3 py-2">{d.model}</td>
                      <td className="px-3 py-2 text-muted-foreground">{d.user}</td>
                      <td className="px-3 py-2"><span className="inline-flex items-center gap-1.5"><Icon className="h-3.5 w-3.5 text-primary" />{d.link}</span></td>
                      <td className="px-3 py-2">
                        <div className="flex items-center gap-2">
                          <div className="w-16 h-1.5 rounded-full bg-muted overflow-hidden">
                            <div className={cn("h-full", d.battery > 40 ? "bg-success" : "bg-warning")} style={{ width: `${d.battery}%` }} />
                          </div>
                          <span className="text-xs text-muted-foreground">{d.battery}%</span>
                        </div>
                      </td>
                      <td className="px-3 py-2"><StatusBadge status={d.status} /></td>
                    </tr>
                  );
                })}
              </tbody>
            </table>
          </div>
        </div>
      </div>

      <div className="card-elevated p-5">
        <h3 className="font-display font-semibold mb-4">Matriz de acceso — Workforce Identity</h3>
        <div className="overflow-x-auto">
          <table className="w-full text-sm">
            <thead className="text-left text-xs uppercase text-muted-foreground bg-muted/30">
              <tr>
                <th className="px-3 py-2">Empleado</th>
                <th className="px-3 py-2 text-center">Web SSO</th>
                <th className="px-3 py-2 text-center">VPN</th>
                <th className="px-3 py-2 text-center">ERP Systeck</th>
                <th className="px-3 py-2 text-center">Bloqueo por proximidad</th>
              </tr>
            </thead>
            <tbody>
              {Object.entries(access).map(([user, perms]) => (
                <tr key={user} className="border-t border-border">
                  <td className="px-3 py-2 font-medium">{user}</td>
                  {(["web", "vpn", "erp", "proxLock"] as const).map(k => (
                    <td key={k} className="px-3 py-2 text-center">
                      <button
                        onClick={() => {
                          setAccess(prev => ({ ...prev, [user]: { ...prev[user], [k]: !prev[user][k] } }));
                          toast.success("Regla actualizada", { description: `${user} · ${k}` });
                        }}
                        className={cn("relative inline-flex h-6 w-11 items-center rounded-full transition",
                          perms[k] ? "bg-primary" : "bg-muted")}
                      >
                        <span className={cn("inline-block h-4 w-4 rounded-full bg-background transition-transform",
                          perms[k] ? "translate-x-6" : "translate-x-1")} />
                      </button>
                    </td>
                  ))}
                </tr>
              ))}
            </tbody>
          </table>
        </div>
        <div className="mt-4 flex items-start gap-3 rounded-lg border border-warning/30 bg-warning/10 p-3 text-xs">
          <ShieldAlert className="h-4 w-4 text-warning shrink-0 mt-0.5" />
          <p><span className="font-semibold text-warning">Alerta anti-phishing:</span> 12 intentos bloqueados en las últimas 24 horas. Los dominios spoofed no logran completar el desafío FIDO2.</p>
        </div>
      </div>

      <AuthAuditTrail />
    </div>
  );
}

const USERS = ["carlos.rios@c2teck.com.pe", "ana.salcedo@c2teck.com.pe", "luis.palomino@c2teck.com.pe", "rosa.villalba@c2teck.com.pe"];
const SPOOF = ["attacker@c2teck-support.pe", "admin@c2teck-login.com", "no-reply@c2teck.co"];
const ACTIONS: AuthLog["action"][] = ["Login", "MFA Challenge", "Unlock", "Lock by Proximity"];

function AuthAuditTrail() {
  const logs = useStore(s => s.authLogs);
  const [live, setLive] = useState(true);

  useEffect(() => {
    if (!live) return;
    const id = setInterval(() => {
      const isPhish = Math.random() < 0.18;
      if (isPhish) {
        actions.logAuth({
          user: SPOOF[Math.floor(Math.random() * SPOOF.length)],
          device: "Hideez Key 4", action: "Access Denied",
          assessment: "Phishing Attempt Blocked",
        });
      } else {
        actions.logAuth({
          user: USERS[Math.floor(Math.random() * USERS.length)],
          device: Math.random() < 0.7 ? "Hideez Key 4" : "Hideez Key 3",
          action: ACTIONS[Math.floor(Math.random() * ACTIONS.length)],
          assessment: "OK",
        });
      }
    }, 3500);
    return () => clearInterval(id);
  }, [live]);

  const badge = (a: AuthLog["assessment"]) => {
    if (a === "OK") return "bg-success/15 text-success border-success/30";
    if (a === "Phishing Attempt Blocked") return "bg-destructive/15 text-destructive border-destructive/30";
    return "bg-warning/15 text-warning border-warning/30";
  };

  return (
    <div className="card-elevated p-5">
      <div className="flex items-center justify-between mb-3">
        <div className="flex items-center gap-2">
          <Activity className="h-4 w-4 text-primary" />
          <h3 className="font-display font-semibold">Live Authentication Audit Trail</h3>
        </div>
        <button onClick={() => setLive(v => !v)}
          className={cn("inline-flex items-center gap-2 rounded-md px-3 py-1.5 text-xs font-medium",
            live ? "bg-success/15 text-success" : "bg-muted text-muted-foreground")}>
          <Radio className={cn("h-3 w-3", live && "animate-pulse")} /> {live ? "En vivo" : "Pausado"}
        </button>
      </div>
      <div className="overflow-x-auto max-h-96 overflow-y-auto">
        <table className="w-full text-sm">
          <thead className="text-left text-xs uppercase text-muted-foreground bg-muted/30 sticky top-0">
            <tr>
              <th className="px-3 py-2">Timestamp</th>
              <th className="px-3 py-2">Empleado</th>
              <th className="px-3 py-2">Dispositivo</th>
              <th className="px-3 py-2">Acción</th>
              <th className="px-3 py-2">Assessment</th>
            </tr>
          </thead>
          <tbody>
            {logs.map(l => (
              <tr key={l.id} className="border-t border-border font-mono text-xs">
                <td className="px-3 py-1.5 text-muted-foreground">{l.ts}</td>
                <td className="px-3 py-1.5">{l.user}</td>
                <td className="px-3 py-1.5"><span className="rounded bg-primary/10 text-primary px-1.5 py-0.5">{l.device}</span></td>
                <td className="px-3 py-1.5">{l.action}</td>
                <td className="px-3 py-1.5">
                  <span className={cn("inline-flex items-center gap-1 rounded-full border px-2 py-0.5 text-[10px]", badge(l.assessment))}>
                    {l.assessment}
                  </span>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}

function DeviceCard({ model, desc, gradient }: { model: string; desc: string; gradient: string }) {
  return (
    <div className={cn("relative overflow-hidden rounded-xl border border-border p-5 bg-gradient-to-br", gradient)}>
      <div className="flex items-center gap-3">
        <div className="h-12 w-12 rounded-lg bg-background/40 grid place-items-center backdrop-blur">
          <KeyRound className="h-6 w-6 text-primary" />
        </div>
        <div>
          <p className="font-display font-semibold">{model}</p>
          <p className="text-xs text-muted-foreground">{desc}</p>
        </div>
      </div>
      <div className="mt-4 flex gap-2 text-[10px] uppercase">
        <span className="rounded bg-background/40 px-2 py-1 border border-border">FIDO2</span>
        <span className="rounded bg-background/40 px-2 py-1 border border-border">WebAuthn</span>
        <span className="rounded bg-background/40 px-2 py-1 border border-border">OTP</span>
      </div>
    </div>
  );
}
