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

export function ReporteGuiasRemisionList() {
  return (
    <WindowShell title="Reporte de Guías Remisión"
    >
      <div className="p-3 space-y-2 max-w-3xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Fechas">
          <Field label="Del"><input className={inp} type="date" defaultValue="2026-01-07" /></Field>
          <Field label="Al"><input className={inp} type="date" defaultValue="2026-07-21" /></Field>
        </Fs>
        <Fs legend="Búsqueda Rápida">
          <Field label="Oficina"><select className={inp}><option>(Todos)</option></select></Field>
          <Field label="Almacén"><select className={inp}><option>(Todos)</option></select></Field>
        </Fs>
        <Fs legend="Buscar Cliente">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Cliente</label>
          <Field label="Cliente"><select className={inp}><option>(Todos)</option></select></Field>
        </Fs>
        <Fs legend="Opciones">
          <Field label="Moneda"><select className={inp}><option>(Todos)</option></select></Field>
          <Field label="Serie Doc."><input className={inp} /></Field>
          <Field label="Motivo"><select className={inp}><option>(Todos)</option></select></Field>
          <Field label="Estado"><select className={inp}><option>(Todos)</option></select></Field>
        </Fs>
        <DataTable columns={["Fecha", "G/R", "Cliente", "Destino", "Cantidad", "Total"]} rows={5} />
        <div className="mt-2 flex justify-end gap-2"><button className={btn}>Cancelar</button><button className={btnPrimary}>Aceptar</button></div>
      </div>
    </WindowShell>
  );
}
