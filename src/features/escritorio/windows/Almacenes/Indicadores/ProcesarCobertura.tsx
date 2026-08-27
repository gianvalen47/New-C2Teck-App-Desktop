// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search, RefreshCw } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  DataTable,
  WindowShell,
  SearchBar
} from "@/components/ui/desktop-primitives";

export function ProcesarCoberturaList() {
  return (
    <WindowShell title="Procesar Cobertura" toolbar={<>      
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Procesar</button>
        <button className={btn}><Search className="h-3.5 w-3.5" />Ver Resultados</button>
      </>}>
      <SearchBar>
        <Field label="Año" className="w-20"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
        <Field label="Mes" className="w-24"><select className={inp}><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
        <Field label="Almacén" className="w-32"><select className={inp}><option>Central Lima</option><option>Norte</option><option>Sur</option></select></Field>
      </SearchBar>
      <div className="p-1.5"><DataTable columns={["Producto", "Stock Actual", "Stock Crítico", "Cobertura Días", "Sugerido"]} rows={8} /></div>
    </WindowShell>
  );
}
