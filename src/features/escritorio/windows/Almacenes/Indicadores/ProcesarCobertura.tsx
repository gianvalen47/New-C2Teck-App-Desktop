import { useState } from "react";
import { Check, X } from "lucide-react";
import {
  btn,
  btnPrimary,
  Fs,
  inp,
  WindowShell,
} from "@/components/ui/desktop-primitives";

export function ProcesarCoberturaList() {
  const [fecha, setFecha] = useState("2026-10-20");
  const [meses, setMeses] = useState(3);

  return (
    <WindowShell title="Procesar Cobertura de Tablero">
      <div className="flex h-full items-center justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <Fs
          legend="Procesar"
          className="w-full max-w-[390px] px-3 pb-3 pt-1"
        >
          <div className="grid grid-cols-[minmax(0,1fr)_minmax(0,1fr)] items-center gap-x-5 gap-y-3 py-1">
            <label className="grid grid-cols-[48px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Fecha</span>
              <input
                aria-label="Fecha de cobertura"
                className={`${inp} h-6 min-w-0 px-1`}
                type="date"
                value={fecha}
                onChange={(event) => setFecha(event.target.value)}
              />
            </label>

            <label className="grid grid-cols-[42px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Meses</span>
              <input
                aria-label="Cantidad de meses"
                className={`${inp} h-6 w-[64px] px-1`}
                type="number"
                min={1}
                value={meses}
                onChange={(event) => setMeses(Number(event.target.value))}
              />
            </label>

            <label className="grid grid-cols-[48px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Oficina</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="LIMA">
                <option value="LIMA">LIMA</option>
              </select>
            </label>

            <label className="grid grid-cols-[58px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Almacén</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="">
                <option value=""></option>
                <option value="central">Central</option>
              </select>
            </label>
          </div>

          <div className="flex justify-center gap-2 pt-1">
            <button type="button" className={btnPrimary}>
              <Check className="h-3.5 w-3.5 text-emerald-300" />
              Procesar
            </button>
            <button type="button" className={btn}>
              <X className="h-3.5 w-3.5" />
              Cancelar
            </button>
          </div>
        </Fs>
      </div>
    </WindowShell>
  );
}

export function ProcesarCobertura() {
  return <ProcesarCoberturaList />;
}
