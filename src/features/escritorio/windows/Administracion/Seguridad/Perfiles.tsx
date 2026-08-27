// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Save, Search, Plus } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  SearchBar,
  MasterDetailForm
} from "@/components/ui/desktop-primitives";

export function PerfilesList() {
  return (
    <MasterDetailForm
      title="Perfiles — Permisos Granulares"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar permisos</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Nuevo perfil</button>
      </>}
      header={
        <div className="grid grid-cols-3 gap-3">
          <Field label="Perfil"><select className={inp}><option>Administrador</option><option>Vendedor</option><option>Almacenero</option></select></Field>
          <Field label="Descripción" className="col-span-2"><input className={inp} /></Field>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Módulo" className="w-44"><select className={inp}><option>(Todos)</option><option>Ventas</option><option>Compras</option><option>Créditos</option></select></Field>
          <Field label="Nivel" className="w-32"><select className={inp}><option>(Todos)</option><option>Lectura</option><option>Escritura</option><option>Aprobar</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Módulo", "Pestaña", "Lectura", "Escritura", "Aprobar", "Sin acceso", "Acción"]}
      rows={10}
    />
  );
}
