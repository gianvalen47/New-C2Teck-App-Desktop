// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { useState } from "react";
import { Save, Plus, FileSpreadsheet } from "lucide-react";
import {
  btn,
  btnPrimary,
  DataTable,
  WindowShell
} from "@/components/ui/desktop-primitives";

export function PreciosManagerList({ initial }: { initial: string }) {
  const [tab, setTab] = useState(initial);
  const tabs = ["Precios Cliente", "Precio Oferta", "Factores Rubros", "Precio Lista", "Precio Fabricantes"];
  return (
    <WindowShell title="Gestor Maestro de Precios y Tarifas"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar cambios</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Nuevo</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Importar Excel</button>
      </>}>
      <div className="flex gap-0.5 border-b border-slate-400/60 -mx-3 px-3">
        {tabs.map(t => (
          <button key={t} onClick={() => setTab(t)} className={[
            "px-3 py-1 text-[11.5px] rounded-t border-x border-t",
            tab === t ? "bg-white border-slate-400/60 text-[#2A3F55] font-semibold -mb-px" : "bg-transparent border-transparent text-slate-600 hover:bg-white/60",
          ].join(" ")}>{t}</button>
        ))}
      </div>
      <div className="mt-3">
        <div className="text-[11px] text-slate-600 mb-2">Editando: <b className="text-[#2A3F55]">{tab}</b></div>
        {tab === "Factores Rubros"
          ? <DataTable columns={["Rubro", "Margen %", "Descuento Máx %", "Vigencia"]} rows={6} />
          : <DataTable columns={["Código", "Producto", "Rubro", "Costo", "Precio", "Margen %", "Moneda", "Vigencia"]} rows={8} />}
      </div>
    </WindowShell>
  );
}
