// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search } from "lucide-react";
import {
  inp,
  btn,
  iconBtn,
  DataTable,
  WindowShell,
  Fs
} from "@/components/ui/desktop-primitives";

export function IndicadoresVentaDialogList() {
  return (
    <WindowShell>
      <div className="p-3 space-y-2 max-w-3xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Mensual">
          <div className="flex items-center gap-2 w-full justify-center">
            <span className="font-bold">Fecha Mensual :</span>
            <input className={`${inp} w-28`} defaultValue="09-2024" />
            <button className={btn}><Search className="h-3.5 w-3.5" />Buscar</button>
          </div>
          <div className="w-full"><DataTable columns={["INDICADOR","U/M","FRECUENCIA","PB","OBJ.","REAL","🚦","G"]} rows={8} /></div>
        </Fs>
        <Fs legend="Diario">
          <div className="flex items-center gap-2 w-full justify-center">
            <span className="font-bold">Fecha Diaria :</span>
            <input className={`${inp} w-32`} type="date" defaultValue="2026-07-16" />
            <button className={btn}><Search className="h-3.5 w-3.5" />Buscar</button>
            <button className={iconBtn}>&lt;</button>
            <button className={iconBtn}>&gt;</button>
          </div>
          <div className="w-full"><DataTable columns={["INDICADOR","U/M","FRECUENCIA","PB","OBJ.","REAL","🚦","G"]} rows={8} /></div>
        </Fs>
      </div>
    </WindowShell>
  );
}
