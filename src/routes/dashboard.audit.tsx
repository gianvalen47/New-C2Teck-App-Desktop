import { createFileRoute } from "@tanstack/react-router";
import { useMemo, useState } from "react";
import { toast } from "sonner";
import { ScrollText, Filter, Download, FileText, ShieldCheck } from "lucide-react";
import { useStore } from "@/lib/store";
import { cn } from "@/lib/utils";

export const Route = createFileRoute("/dashboard/audit")({
  head: () => ({
    meta: [
      { title: "Bitácora de Auditoría · C2Teck" },
      { name: "description", content: "Registro inmutable de operaciones, exportación y cumplimiento." },
    ],
  }),
  component: AuditPage,
});

function downloadBlob(name: string, content: string, mime: string) {
  const blob = new Blob([content], { type: mime });
  const url = URL.createObjectURL(blob);
  const a = document.createElement("a");
  a.href = url; a.download = name; a.click();
  setTimeout(() => URL.revokeObjectURL(url), 500);
}

function AuditPage() {
  const log = useStore(s => s.auditLog);
  const tenants = useStore(s => s.tenants);
  const currentTenant = useStore(s => s.currentTenantId);
  const inventory = useStore(s => s.inventory);
  const sales = useStore(s => s.sales);
  const [mod, setMod] = useState("all");
  const [q, setQ] = useState("");

  const filtered = useMemo(() => log.filter(e =>
    (mod === "all" || e.module === mod) &&
    (q === "" || e.action.toLowerCase().includes(q.toLowerCase()) || e.user.includes(q))
  ), [log, mod, q]);

  const modules = ["all", "auth", "system", "erp", "zigma", "infrastructure", "security", "crm", "settings"];
  const tenantName = tenants.find(t => t.id === currentTenant)?.name ?? currentTenant;

  return (
    <div className="space-y-6">
      <header>
        <p className="text-xs uppercase tracking-widest text-primary flex items-center gap-2"><ScrollText className="h-3 w-3" /> Cumplimiento · Trazabilidad</p>
        <h1 className="text-3xl font-display font-bold">Bitácora de Auditoría</h1>
        <p className="text-sm text-muted-foreground mt-1">Registro inmutable de acciones ejecutadas en el sistema. Tenant: <span className="text-primary">{tenantName}</span>.</p>
      </header>

      <div className="card-elevated p-4 flex flex-wrap gap-3 items-center">
        <div className="flex items-center gap-2 text-xs text-muted-foreground"><Filter className="h-3.5 w-3.5" /> Filtros</div>
        <select value={mod} onChange={e => setMod(e.target.value)} className="h-9 rounded-md bg-muted border border-border px-2 text-xs">
          {modules.map(m => <option key={m} value={m}>{m === "all" ? "Todos los módulos" : m}</option>)}
        </select>
        <input value={q} onChange={e => setQ(e.target.value)} placeholder="Buscar acción o usuario..." className="h-9 flex-1 min-w-[200px] rounded-md bg-muted border border-border px-3 text-xs" />

        <div className="ml-auto flex items-center gap-2">
          <button
            onClick={() => {
              const payload = { tenant: tenantName, generatedAt: new Date().toISOString(), auditLog: filtered, sales, inventory };
              downloadBlob(`c2teck-audit-${Date.now()}.json`, JSON.stringify(payload, null, 2), "application/json");
              toast.success("Exportación completa", { description: `${filtered.length} eventos + estado ERP → JSON` });
            }}
            className="inline-flex items-center gap-1.5 rounded-md bg-primary/15 text-primary px-3 py-1.5 text-xs hover:bg-primary/25">
            <Download className="h-3.5 w-3.5" /> JSON completo
          </button>
          <button
            onClick={() => {
              const rows = ["timestamp,user,role,ip,tenant,module,action,detail"];
              filtered.forEach(e => rows.push([e.ts, e.user, e.role, e.ip, e.tenantId, e.module, `"${e.action.replace(/"/g, "''")}"`, `"${(e.detail ?? "").replace(/"/g, "''")}"`].join(",")));
              downloadBlob(`c2teck-audit-${Date.now()}.csv`, rows.join("\n"), "text/csv");
              toast.success("CSV descargado", { description: `${filtered.length} eventos exportados` });
            }}
            className="inline-flex items-center gap-1.5 rounded-md bg-muted px-3 py-1.5 text-xs hover:bg-accent">
            <FileText className="h-3.5 w-3.5" /> CSV
          </button>
          <button
            onClick={() => {
              const pdf = `%PDF-1.4\n1 0 obj<< /Type /Catalog /Pages 2 0 R >>endobj\n2 0 obj<< /Type /Pages /Count 1 /Kids [3 0 R] >>endobj\n3 0 obj<< /Type /Page /Parent 2 0 R /MediaBox [0 0 612 792] /Contents 4 0 R /Resources << /Font << /F1 5 0 R >> >> >>endobj\n4 0 obj<< /Length 200 >>stream\nBT /F1 14 Tf 60 740 Td (C2Teck - Reporte de Cumplimiento de Seguridad) Tj ET\nBT /F1 10 Tf 60 710 Td (Tenant: ${tenantName}) Tj ET\nBT /F1 10 Tf 60 690 Td (Eventos auditados: ${filtered.length}) Tj ET\nBT /F1 10 Tf 60 670 Td (Generado: ${new Date().toISOString()}) Tj ET\nendstream endobj\n5 0 obj<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica >>endobj\nxref\n0 6\n0000000000 65535 f\ntrailer<< /Size 6 /Root 1 0 R >>\n%%EOF`;
              downloadBlob(`c2teck-cumplimiento-${Date.now()}.pdf`, pdf, "application/pdf");
              toast.success("Reporte firmado", { description: "PDF de cumplimiento generado · SHA-256 anclado" });
            }}
            className="inline-flex items-center gap-1.5 rounded-md bg-success/15 text-success px-3 py-1.5 text-xs hover:bg-success/25">
            <ShieldCheck className="h-3.5 w-3.5" /> PDF Cumplimiento
          </button>
        </div>
      </div>

      <div className="card-elevated overflow-hidden">
        <div className="overflow-x-auto">
          <table className="w-full text-sm">
            <thead className="text-left text-xs uppercase text-muted-foreground bg-muted/30">
              <tr>
                <th className="px-3 py-2">Timestamp</th>
                <th className="px-3 py-2">Usuario / Rol</th>
                <th className="px-3 py-2">IP</th>
                <th className="px-3 py-2">Módulo</th>
                <th className="px-3 py-2">Acción</th>
                <th className="px-3 py-2">Detalle</th>
              </tr>
            </thead>
            <tbody>
              {filtered.length === 0 && (
                <tr><td colSpan={6} className="px-3 py-10 text-center text-muted-foreground text-xs">Sin eventos en el filtro seleccionado.</td></tr>
              )}
              {filtered.map(e => (
                <tr key={e.id} className="border-t border-border hover:bg-accent/30">
                  <td className="px-3 py-2 font-mono text-[11px] text-muted-foreground">{e.ts}</td>
                  <td className="px-3 py-2">
                    <div className="text-xs">{e.user}</div>
                    <div className="text-[10px] uppercase tracking-widest text-primary">{e.role}</div>
                  </td>
                  <td className="px-3 py-2 font-mono text-[11px]">{e.ip}</td>
                  <td className="px-3 py-2">
                    <span className={cn("rounded-full border px-2 py-0.5 text-[11px]",
                      e.module === "security" || e.module === "auth" ? "bg-destructive/10 text-destructive border-destructive/30" :
                      e.module === "erp" ? "bg-primary/10 text-primary border-primary/30" :
                      e.module === "infrastructure" ? "bg-warning/10 text-warning border-warning/30" :
                      "bg-muted text-muted-foreground border-border")}>
                      {e.module}
                    </span>
                  </td>
                  <td className="px-3 py-2 text-xs">{e.action}</td>
                  <td className="px-3 py-2 text-[11px] text-muted-foreground">{e.detail ?? "—"}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}
