// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search, FileSpreadsheet, RefreshCw } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  SearchBar,
  ListQueryForm
} from "@/components/ui/desktop-primitives";

export function TarjetasList() {
  return (
    <ListQueryForm
      title="Tarjetas de Inventario"
      toolbar={<>
        <button className={btnPrimary}><Search className="h-3.5 w-3.5" />Buscar Tarjeta</button>
        <button className={btn}><RefreshCw className="h-3.5 w-3.5" />Refrescar</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}
      extraTop={
        <div className="mx-1.5 mt-1.5 grid grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Tarjetas:</span> <b className="font-mono text-slate-900">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Movimientos:</span> <b className="font-mono text-slate-900">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Entradas:</span> <b className="font-mono text-emerald-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Salidas:</span> <b className="font-mono text-red-700">0</b></div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Producto" className="w-64"><input className={inp} placeholder="Código o descripción" /></Field>
          <Field label="Almacén" className="w-32"><select className={inp}><option>Central Lima</option><option>Norte</option><option>Sur</option></select></Field>
          <Field label="Fecha Desde" className="w-36"><input className={inp} type="date" /></Field>
          <Field label="Fecha Hasta" className="w-36"><input className={inp} type="date" /></Field>
          <Field label="Tipo" className="w-36"><select className={inp}><option>(Todos)</option><option>Ingreso</option><option>Salida</option><option>Ajuste</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Código", "Producto", "Almacén", "Stock Inicio", "Entradas", "Salidas", "Stock Final", "Acción"]}
      rows={8}
    />
  );
}
