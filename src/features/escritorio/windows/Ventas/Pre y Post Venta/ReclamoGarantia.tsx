// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { X, Save, Search } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  SearchBar,
  MasterDetailForm
} from "@/components/ui/desktop-primitives";
import { stdToolbar8 } from "@/features/escritorio/windows/shared/toolbarPresets";

export function ReclamoGarantiaList() {
  return (
    <MasterDetailForm
      title="Reclamos de Garantía"
      toolbar={stdToolbar8}
      header={
        <div className="grid grid-cols-5 gap-2">
          <Field label="N° Reclamo"><input className={`${inp} font-mono`} defaultValue="" /></Field>
          <Field label="Fecha"><input className={inp} type="date" defaultValue="2026-07-25" /></Field>
          <Field label="Control"><input className={inp} defaultValue="" /></Field>
          <Field label="Estado"><select className={inp}><option>REGISTRADO</option><option>EN EVALUACIÓN</option><option>CERRADO</option><option>ANULADO</option></select></Field>
          <Field label="Resultado"><select className={inp}><option>(Pendiente)</option><option>PROCEDE</option><option>NO PROCEDE</option></select></Field>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Cliente" className="w-64"><input className={inp} defaultValue="(Todos)" /></Field>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Estado" className="w-36"><select className={inp}><option>(Todos)</option><option>REGISTRADO</option><option>EN EVALUACIÓN</option><option>CERRADO</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["N°", "Fecha", "Control", "Cliente", "Documento", "Equipo", "Falla", "Estado", "Resultado"]}
      rows={0}
      footer={
        <div className="px-1.5 pb-1.5 flex justify-end gap-2">
          <button className={btn}><X className="h-3.5 w-3.5" />Cancelar</button>
          <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        </div>
      }
    />
  );
}
