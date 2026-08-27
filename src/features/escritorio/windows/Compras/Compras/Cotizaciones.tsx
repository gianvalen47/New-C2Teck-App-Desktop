// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search, Plus, FileDown } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  SearchBar,
  MasterDetailForm
} from "@/components/ui/desktop-primitives";
import { CotizacionesList } from "@/features/escritorio/windows/Ventas/Pre y Post Venta/Cotizaciones";

export function CotizacionesCompraList() {
  return (
    <MasterDetailForm
      title="Cuadro Comparativo de Cotizaciones"
      toolbar={<>
        <button className={btnPrimary}>✓ Adjudicar Proveedor</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Nuevo proveedor</button>
        <button className={btn}><FileDown className="h-3.5 w-3.5" />PDF</button>
      </>}
      header={
        <div className="space-y-2">
          <div className="grid grid-cols-4 gap-2 text-[11px]">
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">OC por emitir:</span> <b className="font-mono text-amber-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Cotiz. recibidas:</span> <b className="font-mono text-slate-900">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Aprobadas:</span> <b className="font-mono text-emerald-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Proveedor ganador:</span> <b className="font-mono text-[#2A3F55]">-</b></div>
          </div>
          <div className="grid grid-cols-4 gap-3">
            <Field label="Solicitud Ref."><input className={inp} placeholder="SC-2026-0001" /></Field>
            <Field label="Fecha"><input className={inp} type="date" /></Field>
            <Field label="Criterio"><select className={inp}><option>Menor precio</option><option>Mejor plazo</option><option>Puntaje ponderado</option></select></Field>
            <Field label="Moneda"><select className={inp}><option>PEN</option><option>USD</option></select></Field>
          </div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Estado" className="w-40"><select className={inp}><option>(Todos)</option><option>En evaluación</option><option>Aprobada</option><option>Rechazada</option></select></Field>
          <Field label="Proveedor" className="w-56"><input className={inp} placeholder="RUC / Razón Social" /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Producto", "Cant.", "Proveedor A", "Proveedor B", "Proveedor C", "Mejor Precio", "Plazo (días)", "Selección", "Acción"]}
      rows={6}
    />
  );
}
