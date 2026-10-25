import { useState } from "react";
import { Search } from "lucide-react";
import {
  btn,
  btnPrimary,
  Fs,
  iconBtn,
  inp,
  Radio,
  WindowShell,
} from "@/components/ui/desktop-primitives";

export function ReporteValorizado({ title = "Inventario Permanente Valorizado" }: { title?: string }) {
  return <ReporteValorizadoList title={title} />;
}

export function ReporteValorizadoList({
  title = "Inventario Permanente Valorizado",
}: {
  title?: string;
}) {
  const [todaMercaderia, setTodaMercaderia] = useState(true);
  const [paginacion, setPaginacion] = useState(true);

  return (
    <WindowShell title={title}>
      <div className="flex h-full items-center justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[430px] space-y-1.5 px-1 py-1">
          <div className="flex items-center justify-center gap-5">
            <span className="font-bold">Fechas</span>
            <label className="flex items-center gap-1.5">
              <span className="font-bold">Del</span>
              <input
                aria-label="Fecha desde"
                className={`${inp} h-6 w-[98px] px-1`}
                type="date"
                defaultValue="2026-10-01"
              />
            </label>
            <label className="flex items-center gap-1.5">
              <span className="font-bold">A :</span>
              <input
                aria-label="Fecha hasta"
                className={`${inp} h-6 w-[98px] px-1`}
                type="date"
                defaultValue="2026-10-24"
              />
            </label>
          </div>

          <div className="space-y-1">
            <label className="grid grid-cols-[68px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Oficina:</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
                <option value="LIMA">LIMA</option>
              </select>
            </label>
            <label className="grid grid-cols-[68px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Almacén:</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>
          </div>

          <Fs legend="Buscar Mercadería" className="px-2 pb-1 pt-0">
            <label className="flex items-center justify-center gap-1.5 font-bold">
              <input
                type="checkbox"
                checked={todaMercaderia}
                onChange={(event) => setTodaMercaderia(event.target.checked)}
                className="accent-[#2A5590]"
              />
              Toda Mercadería
            </label>
            <div className="mx-auto grid max-w-[180px] grid-cols-[minmax(0,1fr)_26px] items-center gap-1">
              <input
                className={`${inp} h-6 min-w-0 px-1`}
                aria-label="Mercadería"
                disabled={todaMercaderia}
              />
              <button
                type="button"
                className={`${iconBtn} border border-slate-400/70`}
                aria-label="Buscar mercadería"
                disabled={todaMercaderia}
              >
                <Search className="h-3.5 w-3.5" />
              </button>
            </div>
          </Fs>

          <Fs legend="Tipo" className="px-2 pb-1 pt-0">
            <div className="flex justify-center gap-8">
              <Radio
                name="inventario-valorizado-tipo"
                label="Detallado"
                defaultChecked
              />
              <Radio name="inventario-valorizado-tipo" label="Resumido" />
            </div>
          </Fs>

          <Fs legend="Paginación" className="px-2 pb-1 pt-0">
            <label className="flex items-center justify-center gap-1.5 font-bold">
              <input
                type="checkbox"
                checked={paginacion}
                onChange={(event) => setPaginacion(event.target.checked)}
                className="accent-[#2A5590]"
              />
              Con Paginación
            </label>
          </Fs>

          <div className="flex justify-center gap-2 pt-1">
            <button type="button" className={btnPrimary}>Aceptar</button>
            <button type="button" className={btn}>Cancelar</button>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}
