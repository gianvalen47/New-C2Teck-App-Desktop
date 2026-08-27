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

export function ReporteSolicitudGastosList() {
  return (
    <WindowShell title="Reporte de Solicitud de Gastos"
    >
      <div className="p-3 space-y-2 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Fechas de Solicitud">
          <Field label="Del"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Al"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
        </Fs>
        <Fs legend="Filtros Principales">
          <Field label="Área"><select className={inp}><option>(Todas)</option><option>Administración</option><option>Operaciones</option><option>Ventas</option></select></Field>
          <Field label="Estado"><select className={inp}><option>(Todos)</option><option>Pendiente</option><option>Aprobada</option><option>Rendida</option><option>Rechazada</option></select></Field>
          <Field label="Solicitante"><input className={inp} /></Field>
          <Field label="Tipo"><select className={inp}><option>(Todos)</option><option>Operativo</option><option>Servicio</option><option>Movilidad</option></select></Field>
        </Fs>
        <DataTable columns={["Fecha", "Solicitud", "Área", "Solicitante", "Tipo", "Estado", "Monto", "Rendido"]} rows={8} />
        <div className="mt-2 flex justify-end gap-2"><button className={btn}>Cancelar</button><button className={btnPrimary}>Aceptar</button></div>
      </div>
    </WindowShell>
  );
}
