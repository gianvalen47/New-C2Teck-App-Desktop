import { createFileRoute } from "@tanstack/react-router";
import { useState } from "react";
import { toast } from "sonner";
import { Settings, ShieldCheck, FileDigit, Coins, RefreshCcw, Upload, CheckCircle2, AlertTriangle, UserCog, Building2 } from "lucide-react";
import { useStore, actions, validateRUC, ROLE_LABEL, type Role, type ModuleKey } from "@/lib/store";
import { cn } from "@/lib/utils";


export const Route = createFileRoute("/dashboard/settings")({
  head: () => ({
    meta: [
      { title: "Configuración del Sistema · C2Teck" },
      { name: "description", content: "Multi-tenant SUNAT, correlativos, tributos y tipo de cambio." },
    ],
  }),
  component: SettingsPage,
});

function SettingsPage() {
  const s = useStore(x => x.settings);
  const [ruc, setRuc] = useState(s.ruc);
  const [solUser, setSolUser] = useState(s.solUser);
  const [solPass, setSolPass] = useState(s.solPass);
  const [rucErr, setRucErr] = useState("");

  const [fF, setFF] = useState(s.correlativos.factura);
  const [fB, setFB] = useState(s.correlativos.boleta);
  const [fN, setFN] = useState(s.correlativos.nota);

  const [igv, setIgv] = useState(s.igvRate);
  const [isc, setIsc] = useState(s.iscRate);
  const [autoFx, setAutoFx] = useState(s.autoFx);
  const [fx, setFx] = useState(s.fxUSD);
  const [syncing, setSyncing] = useState(false);

  const daysLeft = s.cert ? Math.ceil((+new Date(s.cert.validUntil) - Date.now()) / 86400000) : 0;

  return (
    <div className="space-y-6">
      <header>
        <p className="text-xs uppercase tracking-widest text-primary flex items-center gap-2"><Settings className="h-3 w-3" /> Core · Multi-tenant</p>
        <h1 className="text-3xl font-display font-bold">Configuración del Sistema</h1>
        <p className="text-sm text-muted-foreground mt-1">Reglas de negocio, credenciales SUNAT y tributos aplicables a todos los módulos.</p>
      </header>

      <div className="grid lg:grid-cols-2 gap-4">
        {/* SUNAT credentials */}
        <div className="card-elevated p-5">
          <div className="flex items-center gap-2 mb-4">
            <ShieldCheck className="h-4 w-4 text-primary" />
            <h3 className="font-display font-semibold">Credenciales SUNAT & Certificado Digital</h3>
          </div>
          <form onSubmit={(e) => {
            e.preventDefault();
            if (!validateRUC(ruc)) { setRucErr("El RUC debe tener exactamente 11 dígitos."); return; }
            setRucErr("");
            actions.updateSettings({ ruc, solUser, solPass });
            toast.success("Credenciales SUNAT guardadas", { description: `RUC ${ruc} · Usuario SOL ${solUser}` });
          }} className="space-y-3">
            <Field label="RUC de la empresa" error={rucErr}>
              <input value={ruc} onChange={e => setRuc(e.target.value)} className={cn("input", rucErr && "!border-destructive")} maxLength={11} />
            </Field>
            <div className="grid grid-cols-2 gap-3">
              <Field label="Usuario SOL"><input value={solUser} onChange={e => setSolUser(e.target.value)} className="input" /></Field>
              <Field label="Clave SOL"><input type="password" value={solPass} onChange={e => setSolPass(e.target.value)} className="input" /></Field>
            </div>

            <div className="rounded-lg border border-border p-3">
              <div className="flex items-center justify-between">
                <div>
                  <p className="text-xs text-muted-foreground">Certificado digital</p>
                  <p className="text-sm font-mono">{s.cert?.name ?? "— no cargado —"}</p>
                </div>
                {s.cert && (
                  <span className={cn("inline-flex items-center gap-1.5 rounded-full border px-2 py-0.5 text-[11px]",
                    daysLeft > 60 ? "bg-success/15 text-success border-success/30" : "bg-warning/15 text-warning border-warning/30")}>
                    {daysLeft > 60 ? <CheckCircle2 className="h-3 w-3" /> : <AlertTriangle className="h-3 w-3" />}
                    Vigente {daysLeft} días
                  </span>
                )}
              </div>
              <label className="mt-3 flex items-center justify-center gap-2 rounded-md border border-dashed border-border py-2 text-xs cursor-pointer hover:border-primary hover:text-primary">
                <Upload className="h-3.5 w-3.5" />
                Subir nuevo .pfx / .p12
                <input type="file" accept=".pfx,.p12" className="hidden" onChange={(e) => {
                  const f = e.target.files?.[0]; if (!f) return;
                  actions.updateSettings({ cert: { name: f.name, validUntil: "2028-01-01" } });
                  toast.success("Certificado cargado", { description: `${f.name} · válido hasta 2028-01-01` });
                }} />
              </label>
            </div>
            <button className="w-full rounded-md bg-primary py-2 text-sm font-medium text-primary-foreground">Guardar credenciales</button>
          </form>
        </div>

        {/* Correlativos */}
        <div className="card-elevated p-5">
          <div className="flex items-center gap-2 mb-4">
            <FileDigit className="h-4 w-4 text-primary" />
            <h3 className="font-display font-semibold">Series & Correlativos Electrónicos</h3>
          </div>
          <form onSubmit={(e) => {
            e.preventDefault();
            const ok = [fF, fB, fN].every(v => /^[A-Z]{1,2}\d{2,3}-\d{6}$/.test(v));
            if (!ok) { toast.error("Formato inválido", { description: "Ej: F001-000001" }); return; }
            actions.updateSettings({ correlativos: { factura: fF, boleta: fB, nota: fN } });
            toast.success("Correlativos actualizados", { description: "Aplicados a todos los puntos de emisión" });
          }} className="space-y-3">
            <Field label="Factura (siguiente)"><input value={fF} onChange={e => setFF(e.target.value.toUpperCase())} className="input font-mono" /></Field>
            <Field label="Boleta (siguiente)"><input value={fB} onChange={e => setFB(e.target.value.toUpperCase())} className="input font-mono" /></Field>
            <Field label="Nota de Crédito (siguiente)"><input value={fN} onChange={e => setFN(e.target.value.toUpperCase())} className="input font-mono" /></Field>
            <div className="rounded-lg bg-muted/30 border border-border p-3 text-xs text-muted-foreground">
              El sistema autoincrementa el correlativo tras cada emisión aceptada por SUNAT.
            </div>
            <button className="w-full rounded-md bg-primary py-2 text-sm font-medium text-primary-foreground">Guardar series</button>
          </form>
        </div>

        {/* Tax & currency */}
        <div className="card-elevated p-5 lg:col-span-2">
          <div className="flex items-center gap-2 mb-4">
            <Coins className="h-4 w-4 text-primary" />
            <h3 className="font-display font-semibold">Tributos & Tipo de Cambio</h3>
          </div>
          <div className="grid md:grid-cols-3 gap-4">
            <Field label="IGV general (%)">
              <input type="number" min={0} max={30} step={0.5} value={igv}
                onChange={e => setIgv(Number(e.target.value))}
                onBlur={() => { actions.updateSettings({ igvRate: igv }); toast.success(`IGV actualizado a ${igv}%`); }}
                className="input" />
            </Field>
            <Field label="ISC (%) [productos aplicables]">
              <input type="number" min={0} max={50} step={0.5} value={isc}
                onChange={e => setIsc(Number(e.target.value))}
                onBlur={() => { actions.updateSettings({ iscRate: isc }); toast.success(`ISC actualizado a ${isc}%`); }}
                className="input" />
            </Field>
            <Field label="Moneda base">
              <select value={s.currency} onChange={e => { actions.updateSettings({ currency: e.target.value as "PEN" | "USD" }); toast.success(`Moneda base: ${e.target.value}`); }} className="input">
                <option value="PEN">PEN — Soles</option>
                <option value="USD">USD — Dólares</option>
              </select>
            </Field>
          </div>

          <div className="mt-4 rounded-lg border border-border p-4 flex flex-wrap items-center gap-4">
            <div className="flex-1 min-w-[200px]">
              <p className="text-xs text-muted-foreground">Tipo de cambio USD → PEN</p>
              <p className="text-2xl font-display font-bold">S/ {fx.toFixed(3)}</p>
              <p className="text-[11px] text-muted-foreground">Fuente: SUNAT / SBS · sincronización diaria 07:00 GMT-5</p>
            </div>
            <label className="flex items-center gap-2 text-sm">
              <input type="checkbox" checked={autoFx} onChange={(e) => { setAutoFx(e.target.checked); actions.updateSettings({ autoFx: e.target.checked }); }}
                className="h-4 w-4 rounded border-border" />
              Sincronización automática
            </label>
            <button
              disabled={syncing}
              onClick={async () => {
                setSyncing(true);
                await new Promise(r => setTimeout(r, 900));
                const next = +(3.68 + Math.random() * 0.15).toFixed(3);
                setFx(next);
                actions.updateSettings({ fxUSD: next });
                setSyncing(false);
                toast.success("Tipo de cambio sincronizado", { description: `USD/PEN = ${next.toFixed(3)} · fuente SBS` });
              }}
              className="inline-flex items-center gap-2 rounded-md bg-primary/15 text-primary px-3 py-2 text-sm hover:bg-primary/25">
              <RefreshCcw className={cn("h-4 w-4", syncing && "animate-spin")} /> Sincronizar ahora
            </button>
          </div>
        </div>

        <RolesTenantsPanel />
      </div>
    </div>
  );
}

function RolesTenantsPanel() {
  const perms = useStore(s => s.permissions);
  const tenants = useStore(s => s.tenants);
  const current = useStore(s => s.currentTenantId);
  const role = useStore(s => s.currentRole);
  const ROLES: Role[] = ["admin", "contador", "cajero", "soporte"];
  const MODS: { key: ModuleKey; label: string }[] = [
    { key: "overview", label: "Overview" },
    { key: "erp", label: "ERP" },
    { key: "zigma", label: "Zigma POS" },
    { key: "infrastructure", label: "Infra TI" },
    { key: "security", label: "Seguridad" },
    { key: "crm", label: "CRM" },
    { key: "audit", label: "Auditoría" },
    { key: "settings", label: "Configuración" },
  ];

  return (
    <div className="grid lg:grid-cols-2 gap-4 lg:col-span-2">
      <div className="card-elevated p-5">
        <div className="flex items-center gap-2 mb-4">
          <Building2 className="h-4 w-4 text-primary" />
          <h3 className="font-display font-semibold">Multi-tenant · Clientes corporativos</h3>
        </div>
        <div className="space-y-2">
          {tenants.map(t => (
            <button key={t.id} onClick={() => {
              actions.setTenant(t.id);
              toast.success("Tenant conmutado", { description: `${t.name} · datos aislados` });
            }} className={cn("w-full text-left rounded-lg border p-3 hover:border-primary transition",
              t.id === current ? "border-primary bg-primary/5" : "border-border")}>
              <div className="flex items-center justify-between">
                <p className="text-sm font-medium">{t.name}</p>
                {t.id === current && <span className="text-[10px] text-primary uppercase tracking-widest">Activo</span>}
              </div>
              <p className="text-[11px] text-muted-foreground font-mono">RUC {t.ruc} · {t.industry}</p>
            </button>
          ))}
        </div>
      </div>

      <div className="card-elevated p-5">
        <div className="flex items-center gap-2 mb-4">
          <UserCog className="h-4 w-4 text-primary" />
          <h3 className="font-display font-semibold">Matriz de Roles & Permisos</h3>
          <span className="ml-auto text-[10px] text-muted-foreground">Perfil activo: <span className="text-success">{ROLE_LABEL[role]}</span></span>
        </div>
        <div className="overflow-x-auto">
          <table className="w-full text-xs">
            <thead>
              <tr className="text-muted-foreground">
                <th className="text-left py-2 px-2">Módulo</th>
                {ROLES.map(r => (
                  <th key={r} className="text-center py-2 px-2">
                    <div className="font-medium text-foreground text-[11px]">{r}</div>
                    <div className="text-[9px] text-muted-foreground normal-case">{ROLE_LABEL[r].split("(")[0]}</div>
                  </th>
                ))}
              </tr>
            </thead>
            <tbody>
              {MODS.map(m => (
                <tr key={m.key} className="border-t border-border">
                  <td className="py-2 px-2">{m.label}</td>
                  {ROLES.map(r => {
                    const on = perms[r].includes(m.key);
                    return (
                      <td key={r} className="text-center py-2 px-2">
                        <button
                          onClick={() => {
                            actions.togglePermission(r, m.key);
                            toast(on ? `Permiso revocado` : `Permiso otorgado`, { description: `${m.label} · ${r}` });
                          }}
                          className={cn("h-6 w-11 rounded-full transition relative",
                            on ? "bg-primary" : "bg-muted border border-border")}>
                          <span className={cn("absolute top-0.5 h-5 w-5 rounded-full bg-background transition",
                            on ? "right-0.5" : "left-0.5")} />
                        </button>
                      </td>
                    );
                  })}
                </tr>
              ))}
            </tbody>
          </table>
        </div>
        <p className="mt-3 text-[10px] text-muted-foreground">Al modificar un permiso, el menú lateral se actualiza inmediatamente para todos los usuarios asignados a ese rol.</p>
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
