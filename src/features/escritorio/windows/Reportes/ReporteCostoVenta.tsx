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

export function ReporteCostoVentaList() {
  return (
    <WindowShell title="Reporte de Costo de Venta"
    >
      <div className="p-3 space-y-2 max-w-3xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Rango de Fechas">
          <Field label="Desde"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
        </Fs>
        <Fs legend="Criterios">
          <Field label="Oficina"><select className={inp}><option>(Todos)</option><option>LIMA</option><option>AREQUIPA</option></select></Field>
          <Field label="Almacén"><select className={inp}><option>(Todos)</option><option>COMERCIAL</option><option>REPUESTOS</option></select></Field>
          <Field label="Tipo"><select className={inp}><option>Resumen</option><option>Detallado</option></select></Field>
        </Fs>
        <DataTable columns={["Fecha", "Documento", "Producto", "Cant.", "Costo Unit.", "Costo Total", "Venta", "Margen"]} rows={6} />
        <div className="mt-2 flex justify-end gap-2"><button className={btn}>Cancelar</button><button className={btnPrimary}>Aceptar</button></div>
      </div>
    </WindowShell>
  );
}
