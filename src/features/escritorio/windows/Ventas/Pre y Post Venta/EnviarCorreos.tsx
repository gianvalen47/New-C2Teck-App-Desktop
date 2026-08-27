// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { X, Search, Trash2, FileDown, Send } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  iconBtn,
  WindowShell,
  Fs,
  Radio
} from "@/components/ui/desktop-primitives";

export function EnviarCorreosList() {
  return (
    <WindowShell title="Envío masivo de comprobantes"
      toolbar={null}>
      <div className="p-3 space-y-2 max-w-4xl mx-auto">
        <Fs legend="Tipo">
          <div className="flex gap-6 mx-auto">
            <Radio label="Clientes" name="tipoenvio" defaultChecked />
            <Radio label="Personal Interno" name="tipoenvio" />
          </div>
        </Fs>
        <div className="grid grid-cols-[70px_1fr] gap-x-2 gap-y-1.5 text-[11.5px]">
          <label className="text-right pt-1 font-bold">De :</label><input className={inp} />
          <label className="text-right pt-1 font-bold">Para :</label>
          <div className="border border-[#7A96B4] bg-white h-24 overflow-auto">
            <table className="w-full text-[11.5px]">
              <thead className="bg-gradient-to-b from-[#EAF0F7] to-[#C9D6E5] text-[#243B55]">
                <tr><th className="border-r border-b border-[#7A96B4] px-2 py-[3px] text-center">Descripción</th><th className="border-b border-[#7A96B4] px-2 py-[3px] text-center">Correo</th></tr>
              </thead>
            </table>
          </div>
          <label className="text-right pt-1 font-bold">Asunto :</label><input className={inp} />
          <label className="text-right pt-1 font-bold">Mensaje :</label><textarea className={`${inp} h-24 py-1`} />
          <label className="text-right pt-1 font-bold">Publicidad :</label>
          <div className="flex gap-1">
            <input className={`${inp} flex-1`} />
            <button className={iconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
            <button className={iconBtn} title="Ver"><FileDown className="h-3.5 w-3.5" /></button>
            <button className={iconBtn} title="Limpiar"><Trash2 className="h-3.5 w-3.5" /></button>
          </div>
          <label className="text-right pt-1 font-bold">Adjuntos :</label>
          <div className="border border-[#7A96B4] bg-white h-16 overflow-auto">
            <table className="w-full text-[11.5px]">
              <thead className="bg-gradient-to-b from-[#EAF0F7] to-[#C9D6E5] text-[#243B55]">
                <tr><th className="border-r border-b border-[#7A96B4] px-2 py-[3px] text-center">Nombre</th><th className="border-b border-[#7A96B4] px-2 py-[3px] text-center w-28">Tamaño ( kb.)</th></tr>
              </thead>
            </table>
          </div>
        </div>
        <div className="flex justify-end gap-2 pt-2">
          <button className={btnPrimary}><Send className="h-3.5 w-3.5" />Enviar Correo</button>
          <button className={btn}><X className="h-3.5 w-3.5" />Cancelar</button>
        </div>
      </div>
    </WindowShell>
  );
}
