import { createFileRoute } from "@tanstack/react-router";
import { useState } from "react";
import { toast } from "sonner";
import { Search, FileText, Download, X, ShieldCheck, QrCode } from "lucide-react";
import { PublicLayout } from "@/components/layout/PublicLayout";
import { useStore, formatSoles } from "@/lib/store";
import { invoices as legacyInvoices } from "@/lib/mock-data";
import { cn } from "@/lib/utils";

export const Route = createFileRoute("/portal")({
  head: () => ({
    meta: [
      { title: "Portal Consulta de Comprobantes · C2Teck" },
      { name: "description", content: "Consulta ciudadana SUNAT: verifique facturas y boletas electrónicas emitidas." },
    ],
  }),
  component: PortalPage,
});

type FoundReceipt = {
  serie: string; client: string; total: number; date: string; status: string; type: string;
  ruc?: string; items?: { name: string; qty: number; price: number }[];
};

function PortalPage() {
  const sales = useStore(s => s.sales);
  const settings = useStore(s => s.settings);
  const [ruc, setRuc] = useState("");
  const [docType, setDocType] = useState<"Factura" | "Boleta">("Factura");
  const [serie, setSerie] = useState("");
  const [date, setDate] = useState("");
  const [total, setTotal] = useState("");
  const [err, setErr] = useState<Record<string, string>>({});
  const [found, setFound] = useState<FoundReceipt | null>(null);

  return (
    <PublicLayout>
      <section className="mx-auto max-w-5xl px-4 lg:px-8 py-12">
        <header className="text-center mb-10">
          <p className="text-xs uppercase tracking-widest text-primary flex items-center justify-center gap-2"><ShieldCheck className="h-3 w-3" /> SUNAT · Consulta Ciudadana</p>
          <h1 className="mt-2 text-4xl font-display font-bold">Portal de Consulta de Comprobantes</h1>
          <p className="mt-3 text-sm text-muted-foreground max-w-2xl mx-auto">Verifique la autenticidad y el estado de las facturas y boletas electrónicas emitidas por empresas administradas con C2Teck ERP Systeck.</p>
        </header>

        <div className="card-elevated p-6">
          <form onSubmit={(e) => {
            e.preventDefault();
            const errs: Record<string, string> = {};
            if (!/^\d{11}$/.test(ruc)) errs.ruc = "RUC del emisor debe tener 11 dígitos";
            if (!/^[A-Z]{1,2}\d{2,3}-\d{6}$/i.test(serie)) errs.serie = "Formato: F001-000045";
            if (!date) errs.date = "Fecha requerida";
            const t = Number(total);
            if (!t || t <= 0) errs.total = "Monto inválido";
            setErr(errs);
            if (Object.keys(errs).length) return;

            const q = serie.toUpperCase();
            const live = sales.find(s => s.serie.toUpperCase() === q);
            const legacy = legacyInvoices.find(i => i.id.toUpperCase() === q);
            if (live) {
              setFound({
                serie: live.serie, client: live.client, total: live.total, date: live.date.slice(0, 10),
                status: live.status, type: live.serie.startsWith("F") ? "Factura" : "Boleta",
                ruc: settings.ruc, items: live.items.map(i => ({ name: i.name, qty: i.qty, price: i.price })),
              });
              toast.success("Comprobante encontrado", { description: `${live.serie} · aceptado por SUNAT` });
            } else if (legacy) {
              setFound({
                serie: legacy.id, client: legacy.client, total: legacy.amount, date: legacy.date,
                status: legacy.status, type: legacy.type, ruc: settings.ruc,
                items: [{ name: "Servicio / Producto facturado", qty: 1, price: legacy.amount }],
              });
              toast.success("Comprobante encontrado", { description: `${legacy.id} en base histórica` });
            } else {
              toast.error("No encontrado", { description: `No existe ${q} en los registros SUNAT del emisor` });
              setFound(null);
            }
          }} className="grid md:grid-cols-2 gap-4">
            <Field label="RUC del emisor" error={err.ruc}>
              <input value={ruc} onChange={e => setRuc(e.target.value)} maxLength={11} className={cn("input", err.ruc && "!border-destructive")} placeholder="20605421903" />
            </Field>
            <Field label="Tipo de comprobante">
              <select value={docType} onChange={e => setDocType(e.target.value as "Factura" | "Boleta")} className="input">
                <option>Factura</option><option>Boleta</option>
              </select>
            </Field>
            <Field label="Serie-Correlativo" error={err.serie}>
              <input value={serie} onChange={e => setSerie(e.target.value.toUpperCase())} className={cn("input font-mono", err.serie && "!border-destructive")} placeholder="F001-000486" />
            </Field>
            <Field label="Fecha de emisión" error={err.date}>
              <input type="date" value={date} onChange={e => setDate(e.target.value)} className={cn("input", err.date && "!border-destructive")} />
            </Field>
            <Field label="Monto total (S/)" error={err.total}>
              <input value={total} onChange={e => setTotal(e.target.value)} type="number" step="0.01" className={cn("input", err.total && "!border-destructive")} placeholder="0.00" />
            </Field>
            <div className="flex items-end">
              <button className="w-full inline-flex items-center justify-center gap-2 rounded-md bg-primary py-3 text-sm font-semibold text-primary-foreground hover:opacity-90">
                <Search className="h-4 w-4" /> Buscar comprobante
              </button>
            </div>
          </form>
        </div>

        <div className="mt-8 text-center text-xs text-muted-foreground">
          <p>Tip: intente con <span className="font-mono text-primary">F001-000482</span> o <span className="font-mono text-primary">B002-001139</span> (base histórica de demostración).</p>
        </div>

        {found && <ReceiptViewer receipt={found} onClose={() => setFound(null)} />}
      </section>
    </PublicLayout>
  );
}

function Field({ label, error, children }: { label: string; error?: string; children: React.ReactNode }) {
  return (
    <label className="block">
      <span className="text-xs text-muted-foreground">{label}</span>
      <div className="mt-1 [&_.input]:w-full [&_.input]:h-11 [&_.input]:rounded-md [&_.input]:bg-muted [&_.input]:px-3 [&_.input]:text-sm [&_.input]:border [&_.input]:border-border [&_.input]:outline-none [&_.input:focus]:border-primary">
        {children}
      </div>
      {error && <span className="mt-1 block text-[11px] text-destructive">{error}</span>}
    </label>
  );
}

function ReceiptViewer({ receipt, onClose }: { receipt: FoundReceipt; onClose: () => void }) {
  const dl = (name: string, content: string, mime: string) => {
    const blob = new Blob([content], { type: mime });
    const url = URL.createObjectURL(blob);
    const a = document.createElement("a"); a.href = url; a.download = name; a.click();
    setTimeout(() => URL.revokeObjectURL(url), 500);
  };
  const xml = `<?xml version="1.0" encoding="UTF-8"?>\n<Invoice xmlns="urn:oasis:names:specification:ubl:schema:xsd:Invoice-2">\n  <cbc:ID>${receipt.serie}</cbc:ID>\n  <cbc:IssueDate>${receipt.date}</cbc:IssueDate>\n  <cac:AccountingSupplierParty><cbc:CustomerAssignedAccountID>${receipt.ruc}</cbc:CustomerAssignedAccountID></cac:AccountingSupplierParty>\n  <cac:AccountingCustomerParty><cbc:Name>${receipt.client}</cbc:Name></cac:AccountingCustomerParty>\n  <cbc:PayableAmount currencyID="PEN">${receipt.total.toFixed(2)}</cbc:PayableAmount>\n</Invoice>`;

  return (
    <div className="fixed inset-0 z-50 grid place-items-center bg-black/70 p-4" onClick={onClose}>
      <div className="w-full max-w-2xl card-elevated p-6" onClick={e => e.stopPropagation()}>
        <div className="flex items-start justify-between mb-4">
          <div>
            <p className="text-xs uppercase tracking-widest text-primary">Documento electrónico</p>
            <h3 className="font-display text-2xl font-bold mt-1">{receipt.type} {receipt.serie}</h3>
          </div>
          <button onClick={onClose} className="p-1 hover:bg-accent rounded"><X className="h-4 w-4" /></button>
        </div>

        <div className="grid md:grid-cols-3 gap-4 rounded-lg border border-border p-4">
          <div className="md:col-span-2 space-y-2 text-sm">
            <div className="grid grid-cols-2 gap-2">
              <div><p className="text-[10px] uppercase text-muted-foreground">RUC emisor</p><p className="font-mono">{receipt.ruc}</p></div>
              <div><p className="text-[10px] uppercase text-muted-foreground">Fecha emisión</p><p>{receipt.date}</p></div>
              <div className="col-span-2"><p className="text-[10px] uppercase text-muted-foreground">Cliente</p><p>{receipt.client}</p></div>
              <div><p className="text-[10px] uppercase text-muted-foreground">Estado SUNAT</p>
                <p className={cn("font-semibold", receipt.status === "Aceptado" ? "text-success" : receipt.status === "Rechazado" ? "text-destructive" : "text-warning")}>{receipt.status}</p>
              </div>
              <div><p className="text-[10px] uppercase text-muted-foreground">Total</p><p className="font-display text-lg font-bold text-primary">{formatSoles(receipt.total)}</p></div>
            </div>
          </div>
          <div className="flex flex-col items-center justify-center rounded-md bg-muted p-3">
            <QrCode className="h-24 w-24 text-primary" />
            <p className="mt-2 text-[10px] text-muted-foreground text-center">QR SUNAT verificable</p>
          </div>
        </div>

        <div className="mt-4 rounded-lg border border-border overflow-x-auto">
          <table className="w-full text-sm min-w-[440px]">
            <thead className="bg-muted/30 text-xs uppercase text-muted-foreground">
              <tr><th className="px-3 py-2 text-left">Descripción</th><th className="px-3 py-2 text-right">Cant.</th><th className="px-3 py-2 text-right">Unit.</th><th className="px-3 py-2 text-right">Importe</th></tr>
            </thead>
            <tbody>
              {receipt.items?.map((it, i) => (
                <tr key={i} className="border-t border-border">
                  <td className="px-3 py-2">{it.name}</td>
                  <td className="px-3 py-2 text-right">{it.qty}</td>
                  <td className="px-3 py-2 text-right">{formatSoles(it.price)}</td>
                  <td className="px-3 py-2 text-right font-medium">{formatSoles(it.price * it.qty)}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>

        <div className="mt-4 flex flex-wrap gap-2 justify-end">
          <button onClick={() => { dl(`${receipt.serie}.xml`, xml, "application/xml"); toast.success("XML descargado", { description: "UBL 2.1 firmado" }); }}
            className="inline-flex items-center gap-1.5 rounded-md bg-muted px-3 py-2 text-xs hover:bg-accent"><Download className="h-3.5 w-3.5" /> XML</button>
          <button onClick={() => {
            const pdf = `%PDF-1.4\n1 0 obj<< /Type /Catalog /Pages 2 0 R >>endobj\n2 0 obj<< /Type /Pages /Count 1 /Kids [3 0 R] >>endobj\n3 0 obj<< /Type /Page /Parent 2 0 R /MediaBox [0 0 612 792] /Contents 4 0 R /Resources << /Font << /F1 5 0 R >> >> >>endobj\n4 0 obj<< /Length 220 >>stream\nBT /F1 16 Tf 60 740 Td (${receipt.type} ${receipt.serie}) Tj ET\nBT /F1 10 Tf 60 715 Td (Cliente: ${receipt.client}) Tj ET\nBT /F1 10 Tf 60 700 Td (Total: S/ ${receipt.total.toFixed(2)}) Tj ET\nBT /F1 10 Tf 60 685 Td (Estado: ${receipt.status}) Tj ET\nendstream endobj\n5 0 obj<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica >>endobj\nxref\n0 6\ntrailer<< /Size 6 /Root 1 0 R >>\n%%EOF`;
            dl(`${receipt.serie}.pdf`, pdf, "application/pdf");
            toast.success("PDF descargado", { description: "Formato SUNAT · A4" });
          }} className="inline-flex items-center gap-1.5 rounded-md bg-primary text-primary-foreground px-3 py-2 text-xs hover:opacity-90"><FileText className="h-3.5 w-3.5" /> PDF</button>
        </div>
      </div>
    </div>
  );
}
