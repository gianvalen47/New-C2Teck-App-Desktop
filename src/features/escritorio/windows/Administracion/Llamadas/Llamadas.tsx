// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { FileSpreadsheet, Filter } from "lucide-react";
import {
  inp,
  btn,
  Field,
  DataTable,
  WindowShell
} from "@/components/ui/desktop-primitives";

export function LlamadasWinList() {
  return (
    <WindowShell title="Llamadas — Auditoría de Central Telefónica"
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}>
      <div className="grid grid-cols-5 gap-2 mb-3">
        <Field label="Anexo"><input className={inp} /></Field>
        <Field label="Número marcado"><input className={inp} /></Field>
        <Field label="Desde"><input className={inp} type="date" /></Field>
        <Field label="Hasta"><input className={inp} type="date" /></Field>
        <Field label="Tipo"><select className={inp}><option>Todas</option><option>Entrante</option><option>Saliente</option></select></Field>
      </div>
      <DataTable columns={["Fecha", "Hora", "Anexo", "Colaborador", "Nº marcado", "Duración", "Tipo", "Costo"]} rows={10} />
    </WindowShell>
  );
}
