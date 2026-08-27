// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search } from "lucide-react";
import {
  inp,
  btn,
  Field,
  SearchBar,
  MasterDetailForm
} from "@/components/ui/desktop-primitives";
import { stdToolbar19 } from "@/features/escritorio/windows/shared/toolbarPresets";

export function PermisoUsuarioCreditosList() {
  return (
    <MasterDetailForm
      title="Permiso de Usuario - Créditos"
      toolbar={stdToolbar19}
      header={
        <div className="grid grid-cols-4 gap-2">
          <Field label="Usuario"><input className={inp} defaultValue="" /></Field>
          <Field label="Perfil"><select className={inp}><option>ANALISTA</option><option>JEFE CRÉDITOS</option><option>AUDITOR</option></select></Field>
          <Field label="Estado"><select className={inp}><option>ACTIVO</option><option>INACTIVO</option></select></Field>
          <Field label="Vigencia"><input className={inp} type="date" defaultValue="2026-12-31" /></Field>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Usuario" className="w-56"><input className={inp} /></Field>
          <Field label="Perfil" className="w-40"><select className={inp}><option>(Todos)</option><option>ANALISTA</option><option>JEFE CRÉDITOS</option><option>AUDITOR</option></select></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>(Todos)</option><option>ACTIVO</option><option>INACTIVO</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Usuario", "Nombre", "Perfil", "Aprueba Línea", "Aprueba Cotiz.", "Límite Aprobación", "Estado", "Vigencia"]}
      rows={0}
    />
  );
}
