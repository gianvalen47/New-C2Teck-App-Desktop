// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search, Plus, RefreshCw } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  DataTable,
  WindowShell,
  SearchBar
} from "@/components/ui/desktop-primitives";

export function LiquiGastosList() {
  return (
    <WindowShell title="Liquidación de Gastos" toolbar={<>      
        <button className={btnPrimary}><Plus className="h-3.5 w-3.5" />Nuevo</button>
        <button className={btn}><Search className="h-3.5 w-3.5" />Buscar</button>
        <button className={btn}><RefreshCw className="h-3.5 w-3.5" />Refrescar</button>
      </>}>
      <SearchBar>
        <Field label="Año" className="w-20"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
        <Field label="Mes" className="w-24"><select className={inp}><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
        <Field label="Tipo" className="w-32"><select className={inp}><option>Gastos de Almacén</option><option>Servicios</option><option>Transporte</option></select></Field>
        <Field label="Número" className="w-28"><input className={`${inp} font-mono`} /></Field>
      </SearchBar>
      <div className="p-1.5"><DataTable columns={["Documento", "Fecha", "Proveedor", "Tipo", "Importe", "Estado"]} rows={8} /></div>
    </WindowShell>
  );
}
