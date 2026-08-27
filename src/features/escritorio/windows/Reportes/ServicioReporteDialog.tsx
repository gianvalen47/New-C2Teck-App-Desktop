// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { FileDown, FileSpreadsheet, RefreshCw, Filter } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  DataTable,
  WindowShell,
  Fs
} from "@/components/ui/desktop-primitives";

export function ServicioReporteDialogList({ label }: { label: string }) {
  const n = label.toLowerCase();
  const isProgramacion = n.includes("program") || n.includes("tablero");
  const isHoras = n.includes("horas");
  const isGastos = n.includes("gasto");
  const isMotores = n.includes("motor");
  const isRepuestos = n.includes("repuesto");

  return (
    <WindowShell title={`Reporte Servicios — ${label}`}
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Generar</button>
        <div className="ml-auto flex gap-1.5">
          <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
          <button className={btn}><FileDown className="h-3.5 w-3.5" />PDF</button>
        </div>
      </>}>
      <div className="p-3 space-y-2 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Rango de Fechas">
          <Field label="Desde"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
        </Fs>

        <Fs legend="Filtros de Servicio">
          <Field label="Sede / Taller"><select className={inp}><option>(Todos)</option><option>Taller Central</option><option>Taller Mina</option></select></Field>
          <Field label="Jefe Taller"><input className={inp} /></Field>
          <Field label="Estado"><select className={inp}><option>(Todos)</option><option>Abierto</option><option>En proceso</option><option>Cerrado</option></select></Field>
          {isProgramacion && <Field label="Turno"><select className={inp}><option>(Todos)</option><option>Día</option><option>Noche</option></select></Field>}
          {isHoras && <Field label="Tipo Hora"><select className={inp}><option>(Todas)</option><option>Efectiva</option><option>Muerta</option><option>Escalón</option></select></Field>}
          {isGastos && <Field label="Rubro"><select className={inp}><option>(Todos)</option><option>Insumos</option><option>Terceros</option><option>Operativo</option></select></Field>}
          {isMotores && <Field label="Serie Motor"><input className={inp} /></Field>}
          {isRepuestos && <Field label="Repuesto"><input className={inp} /></Field>}
        </Fs>

        <DataTable columns={["Fecha", "OT", "Cliente", "Unidad", "Tarea", "Estado", "Costo", "Resultado"]} rows={8} />
      </div>
    </WindowShell>
  );
}
