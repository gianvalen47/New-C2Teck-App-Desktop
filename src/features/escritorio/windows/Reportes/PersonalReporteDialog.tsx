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

export function PersonalReporteDialogList({ label }: { label: string }) {
  const n = label.toLowerCase();
  const isAsistencia = n.includes("asist") || n.includes("tard");
  const isContrato = n.includes("contrat");
  const isHorario = n.includes("horario");
  const isOnomastico = n.includes("onom");

  return (
    <WindowShell title={`Reporte Personal — ${label}`}
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

        <Fs legend="Filtros de RRHH">
          <Field label="Área"><select className={inp}><option>(Todas)</option><option>Administración</option><option>Operaciones</option><option>Servicios</option></select></Field>
          <Field label="Sede"><select className={inp}><option>(Todas)</option><option>Central</option><option>Mina 1</option></select></Field>
          <Field label="Colaborador"><input className={inp} placeholder="DNI / Nombre" /></Field>
          {isAsistencia && <Field label="Turno"><select className={inp}><option>(Todos)</option><option>Mañana</option><option>Tarde</option><option>Noche</option></select></Field>}
          {isContrato && <Field label="Vigencia"><select className={inp}><option>(Todas)</option><option>Vigente</option><option>Por vencer</option><option>Vencido</option></select></Field>}
          {isHorario && <Field label="Tipo Horario"><select className={inp}><option>(Todos)</option><option>Fijo</option><option>Rotativo</option></select></Field>}
          {isOnomastico && <Field label="Mes"><select className={inp}><option>Julio</option><option>Agosto</option><option>Septiembre</option></select></Field>}
        </Fs>

        <DataTable columns={["Fecha", "Colaborador", "Área", "Sede", "Estado", "Detalle", "Usuario"]} rows={8} />
      </div>
    </WindowShell>
  );
}
