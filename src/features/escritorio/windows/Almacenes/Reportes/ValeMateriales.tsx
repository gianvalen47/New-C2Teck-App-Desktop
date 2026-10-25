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

export function ValeMaterialesReport() {
  return <ValeMaterialesReportList />;
}

export function ValeMaterialesReportList() {
  const [todaMercaderia, setTodaMercaderia] = useState(true);

  return (
    <WindowShell title="Reporte de Entrega de Materiales">
      <div className="flex h-full items-center justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <Fs
          legend="Datos de Reporte"
          className="w-full max-w-[555px] px-3 pb-3 pt-1"
        >
          <Fs legend="Rango de Fechas" className="mx-auto max-w-[390px] px-2 pb-1 pt-0">
            <div className="flex items-center justify-center gap-5">
              <label className="flex items-center gap-1.5">
                <span className="font-bold">Fechas Del :</span>
                <input
                  aria-label="Fecha desde"
                  className={`${inp} h-6 w-[98px] px-1`}
                  type="date"
                  defaultValue="2026-10-01"
                />
              </label>
              <label className="flex items-center gap-1.5">
                <span className="font-bold">Al :</span>
                <input
                  aria-label="Fecha hasta"
                  className={`${inp} h-6 w-[98px] px-1`}
                  type="date"
                  defaultValue="2026-10-24"
                />
              </label>
            </div>
          </Fs>

          <div className="grid grid-cols-[minmax(0,1fr)_minmax(0,1.05fr)] gap-x-3 gap-y-1">
            <label className="grid grid-cols-[60px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Oficina:</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
                <option value="LIMA">LIMA</option>
              </select>
            </label>
            <label className="grid grid-cols-[62px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Almacén:</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="">
                <option value=""></option>
                <option value="all">(Todos)</option>
              </select>
            </label>

            <label className="grid grid-cols-[60px_minmax(0,1fr)_26px] items-center gap-1">
              <span className="font-bold"># OT :</span>
              <input className={`${inp} h-6 min-w-0 px-1`} aria-label="Número de OT" />
              <button
                type="button"
                className={`${iconBtn} border border-slate-400/70`}
                aria-label="Buscar orden de trabajo"
              >
                <Search className="h-3.5 w-3.5" />
              </button>
            </label>
            <label className="grid grid-cols-[62px_minmax(0,1fr)_26px] items-center gap-1">
              <span className="font-bold">Personal:</span>
              <input className={`${inp} h-6 min-w-0 px-1`} aria-label="Personal" />
              <button
                type="button"
                className={`${iconBtn} border border-slate-400/70`}
                aria-label="Buscar personal"
              >
                <Search className="h-3.5 w-3.5" />
              </button>
            </label>

            <label className="grid grid-cols-[60px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">TipMov :</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="salidas">
                <option value="salidas">SALIDAS</option>
              </select>
            </label>
            <label className="grid grid-cols-[62px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Area :</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>

            <label className="grid grid-cols-[60px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Clase :</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>
            <Fs
              legend="{ Mercadería }"
              className="row-span-2 px-2 pb-1 pt-0"
            >
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
                <div className="grid grid-cols-[minmax(0,1fr)_26px] items-center gap-1">
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
            </Fs>

            <label className="grid grid-cols-[60px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Estado :</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>
            <Fs legend="Exportar" className="w-[205px] px-2 pb-1 pt-0">
              <div className="flex justify-center gap-5">
                <Radio
                  name="vale-materiales-exportar"
                  label="Pantalla"
                  defaultChecked
                />
                <Radio name="vale-materiales-exportar" label="Excel" />
              </div>
            </Fs>
          </div>

          <div className="flex justify-center gap-2 pt-2">
            <button type="button" className={btnPrimary}>Aceptar</button>
            <button type="button" className={btn}>Cancelar</button>
          </div>
        </Fs>
      </div>
    </WindowShell>
  );
}
