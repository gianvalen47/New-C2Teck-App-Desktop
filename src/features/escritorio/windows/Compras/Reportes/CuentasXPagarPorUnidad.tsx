// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import {
  inp,
  btn,
  btnPrimary,
  Field,
  DataTable,
  WindowShell,
  Fs
} from "@/components/ui/desktop-primitives";

export function ReporteCtasXPagarUnidadList() {
  return (
    <WindowShell title="Cuentas x Pagar por Unidad"
    >
      <div className="p-3 space-y-2 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Período">
          <Field label="Desde"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
        </Fs>
        <Fs legend="Consolidación">
          <Field label="Unidad"><select className={inp}><option>(Todas)</option><option>Unidad Lima</option><option>Unidad Norte</option><option>Unidad Sur</option></select></Field>
          <Field label="Moneda"><select className={inp}><option>(Todas)</option><option>PEN</option><option>USD</option></select></Field>
          <Field label="Estado"><select className={inp}><option>(Todos)</option><option>Vigente</option><option>Vencido</option><option>Pagado</option></select></Field>
        </Fs>
        <DataTable columns={["Unidad", "Proveedor", "Comprobante", "Vence", "Moneda", "Total", "Saldo", "Estado"]} rows={8} />
        <div className="mt-2 flex justify-end gap-2"><button className={btn}>Cancelar</button><button className={btnPrimary}>Aceptar</button></div>
      </div>
    </WindowShell>
  );
}
