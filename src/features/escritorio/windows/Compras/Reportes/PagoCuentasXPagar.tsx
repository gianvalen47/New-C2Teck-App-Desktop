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

export function ReportePagosCuentasXPagarList() {
  return (
    <WindowShell title="Reporte de Pagos de Cuentas x Pagar"
    >
      <div className="p-3 space-y-2 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Rango de Fechas">
          <Field label="Desde"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
        </Fs>
        <Fs legend="Criterios de Pago">
          <Field label="Proveedor"><input className={inp} placeholder="RUC / Razón Social" /></Field>
          <Field label="Medio"><select className={inp}><option>(Todos)</option><option>Transferencia</option><option>Cheque</option><option>Efectivo</option></select></Field>
          <Field label="Moneda"><select className={inp}><option>(Todas)</option><option>PEN</option><option>USD</option></select></Field>
          <Field label="Estado"><select className={inp}><option>(Todos)</option><option>Programado</option><option>Ejecutado</option><option>Anulado</option></select></Field>
        </Fs>
        <DataTable columns={["Fecha", "Proveedor", "Documento", "Moneda", "Importe", "Medio Pago", "N° Operación", "Estado"]} rows={8} />
        <div className="mt-2 flex justify-end gap-2"><button className={btn}>Cancelar</button><button className={btnPrimary}>Aceptar</button></div>
      </div>
    </WindowShell>
  );
}
