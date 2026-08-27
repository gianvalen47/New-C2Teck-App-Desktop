// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Save, Search, Plus, Trash2 } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  SearchBar,
  MasterDetailForm
} from "@/components/ui/desktop-primitives";

export function UsuariosAdminList() {
  return (
    <MasterDetailForm
      title="Usuarios — Administración"
      toolbar={<>
        <button className={btnPrimary}><Plus className="h-3.5 w-3.5" />Nuevo usuario</button>
        <button className={btn}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Trash2 className="h-3.5 w-3.5" />Desactivar</button>
      </>}
      header={
        <div className="space-y-2">
          <div className="grid grid-cols-4 gap-2 text-[11px]">
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Activos:</span> <b className="font-mono text-emerald-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Bloqueados:</span> <b className="font-mono text-red-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Sin acceso 30d:</span> <b className="font-mono text-amber-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Total usuarios:</span> <b className="font-mono text-slate-900">0</b></div>
          </div>
          <div className="grid grid-cols-4 gap-3">
            <Field label="Usuario"><input className={inp} /></Field>
            <Field label="Nombre completo" className="col-span-2"><input className={inp} /></Field>
            <Field label="Perfil"><select className={inp}><option>Administrador</option><option>Vendedor</option><option>Almacenero</option><option>Contador</option></select></Field>
            <Field label="Email"><input className={inp} type="email" /></Field>
            <Field label="DNI"><input className={inp} /></Field>
            <Field label="Sede"><select className={inp}><option>Central</option><option>Norte</option></select></Field>
            <Field label="Estado"><select className={inp}><option>Activo</option><option>Bloqueado</option></select></Field>
          </div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Sede" className="w-36"><select className={inp}><option>(Todas)</option><option>Central</option><option>Norte</option></select></Field>
          <Field label="Perfil" className="w-36"><select className={inp}><option>(Todos)</option><option>Administrador</option><option>Vendedor</option></select></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>(Todos)</option><option>Activo</option><option>Bloqueado</option></select></Field>
          <Field label="Búsqueda" className="w-64"><input className={inp} placeholder="Usuario / Nombre / DNI" /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Usuario", "Nombre", "Perfil", "Sede", "Último acceso", "Estado", "Acción"]}
      rows={10}
    />
  );
}
