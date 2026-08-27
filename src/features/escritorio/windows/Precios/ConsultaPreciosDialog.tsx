// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { X } from "lucide-react";
import {
  inp,
  btn,
  WindowShell,
  Fs
} from "@/components/ui/desktop-primitives";
import { toast } from "sonner";
import { LabRow } from "@/features/escritorio/windows/shared/LegacySupport";

export function ConsultaPreciosDialogList() {
  return (
    <WindowShell>
      <div className="p-3 space-y-2 max-w-3xl mx-auto text-[11.5px] text-slate-800">
        <div className="flex items-center gap-2">
          <span className="font-bold w-16">Marca :</span>
          <select className={`${inp} w-64 bg-[#2A5590] text-white font-semibold`}>
            <option>YANMAR</option><option>CATERPILLAR</option><option>KOMATSU</option>
          </select>
        </div>
        <Fs legend="Mercaderia">
          <div className="grid grid-cols-2 gap-x-8 w-full">
            {/* Columna izquierda */}
            <div className="space-y-1.5">
              <LabRow label="Código :"><input className={`${inp} w-40`} /></LabRow>
              <LabRow label="Record Type :"><input className={`${inp} w-20`} /></LabRow>
              <LabRow label="Supercession Code"><input className={`${inp} w-20`} /></LabRow>
              <LabRow label="Publicacion Code"><input className={`${inp} w-20`} /></LabRow>
              <LabRow label="Series Code"><input className={`${inp} w-20`} /></LabRow>
              <LabRow label="Functional Comp Code"><input className={`${inp} w-20`} /></LabRow>
              <LabRow label="Country of Origen"><input className={`${inp} w-20`} /></LabRow>
              <LabRow label="Precio Core"><input className={`${inp} w-32 text-right`} defaultValue="0.00" /></LabRow>
              <div className="h-3" />
              <LabRow label="Precio Ex Work: US$"><input className={`${inp} w-32 text-right`} defaultValue="0.00" /></LabRow>
            </div>
            {/* Columna derecha */}
            <div className="space-y-1.5">
              <LabRow label="Descripcion :"><input className={`${inp} w-56`} /></LabRow>
              <LabRow label="Must Buy Quantity"><input className={`${inp} w-20`} /></LabRow>
              <LabRow label="Group Code"><input className={`${inp} w-32 text-right bg-[#DCE9F7]`} defaultValue="0.0000" /></LabRow>
              <LabRow label="Weight"><input className={`${inp} w-32 text-right bg-[#DCE9F7]`} defaultValue="0.0000" /></LabRow>
              <LabRow label="Unit Weight"><input className={`${inp} w-32`} /></LabRow>
              <LabRow label="Cubes"><input className={`${inp} w-32 text-right bg-[#DCE9F7]`} defaultValue="0.0000" /></LabRow>
              <LabRow label="Unit Cubes"><input className={`${inp} w-32`} /></LabRow>
              <LabRow label="Precio SLP : US$"><input className={`${inp} w-32 text-right bg-[#DCE9F7]`} defaultValue="0.00" /></LabRow>
              <LabRow label="Precio Venta :  US$"><input className={`${inp} w-32 text-right bg-[#DCE9F7]`} defaultValue="0.00" /></LabRow>
              <LabRow label="Precio Venta    S/."><input className={`${inp} w-32 text-right bg-[#DCE9F7]`} defaultValue="0.00" /></LabRow>
            </div>
          </div>
        </Fs>
        <div className="flex justify-end pt-1">
          <button className={btn} onClick={() => toast.message("Cerrado")}><X className="h-3.5 w-3.5" />Cancelar</button>
        </div>
      </div>
    </WindowShell>
  );
}
