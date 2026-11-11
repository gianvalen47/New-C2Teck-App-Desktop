import { useState } from "react";
import { Search } from "lucide-react";
import {
  btn,
  btnPrimary,
  Fs,
  iconBtn,
  inp,
  WindowShell,
} from "@/components/ui/desktop-primitives";

export function HorasEscalon({
  title = "Reporte Consolidado de Horas",
}: {
  title?: string;
}) {
  return <HorasEscalonList title={title} />;
}

export function HorasEscalonList({
  title = "Reporte Consolidado de Horas",
}: {
  title?: string;
}) {
  const [year, setYear] = useState(2006);
  const [escalon, setEscalon] = useState("(Todos)");
  const [jobNumber, setJobNumber] = useState("");
  const [process, setProcess] = useState("(Todos)");
  const [status, setStatus] = useState("(Todos)");
  const [allClients, setAllClients] = useState(true);
  const [client, setClient] = useState("(TODOS)");

  return (
    <WindowShell title={title}>
      <div className="flex h-full min-h-0 items-center justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[430px] space-y-3 px-1 py-2">
          <div className="grid grid-cols-[0.8fr_1.2fr_1fr] items-end gap-2">
            <label className="flex min-w-0 flex-col gap-1">
              <span className="text-center font-bold">Año:</span>
              <input
                aria-label="Año"
                type="number"
                min={2006}
                max={2020}
                value={year}
                onChange={(event) => {
                  const value = Number(event.target.value);
                  if (Number.isInteger(value) && value >= 2006 && value <= 2020) {
                    setYear(value);
                  }
                }}
                className={`${inp} h-7 min-w-0 w-full px-1 text-center font-bold`}
              />
            </label>

            <label className="flex min-w-0 flex-col gap-1">
              <span className="text-center font-bold">Escalón:</span>
              <select
                aria-label="Escalón"
                value={escalon}
                onChange={(event) => setEscalon(event.target.value)}
                className={`${inp} h-7 min-w-0 w-full px-1`}
              >
                <option>(Todos)</option>
              </select>
            </label>

            <label className="flex min-w-0 flex-col gap-1">
              <span className="text-center font-bold">OT:</span>
              <span className="flex min-w-0 items-center gap-1">
                <input
                  aria-label="OT"
                  value={jobNumber}
                  onChange={(event) => setJobNumber(event.target.value)}
                  className={`${inp} h-7 min-w-0 w-full px-1 font-bold`}
                />
                <button type="button" className={iconBtn} aria-label="Buscar OT">
                  <Search className="h-3.5 w-3.5" />
                </button>
              </span>
            </label>
          </div>

          <div className="grid grid-cols-2 gap-3">
            <label className="flex min-w-0 items-center gap-2">
              <span className="shrink-0 font-bold">Proceso:</span>
              <select
                aria-label="Proceso"
                value={process}
                onChange={(event) => setProcess(event.target.value)}
                className={`${inp} h-7 min-w-0 flex-1 px-1`}
              >
                <option>(Todos)</option>
              </select>
            </label>

            <label className="flex min-w-0 items-center gap-2">
              <span className="shrink-0 font-bold">Estado:</span>
              <select
                aria-label="Estado"
                value={status}
                onChange={(event) => setStatus(event.target.value)}
                className={`${inp} h-7 min-w-0 flex-1 px-1`}
              >
                <option>(Todos)</option>
              </select>
            </label>
          </div>

          <Fs legend="Buscar Cliente" className="px-2 pb-2 pt-0">
            <div className="flex justify-center">
              <label className="inline-flex items-center gap-1.5 font-bold">
                <input
                  aria-label="Todo Cliente"
                  type="checkbox"
                  checked={allClients}
                  onChange={(event) => {
                    const checked = event.target.checked;
                    setAllClients(checked);
                    if (checked) setClient("(TODOS)");
                    else if (client === "(TODOS)") setClient("");
                  }}
                  className="m-0 h-[13px] w-[13px] accent-[#2A5590]"
                />
                Todo Cliente
              </label>
            </div>
            <label className="grid grid-cols-[58px_minmax(0,1fr)_28px] items-center gap-1.5">
              <span className="font-bold">Cliente:</span>
              <input
                aria-label="Cliente"
                value={client}
                readOnly
                className={`${inp} h-7 min-w-0 px-1 font-bold uppercase text-slate-700`}
              />
              <button type="button" className={iconBtn} aria-label="Buscar cliente">
                <Search className="h-3.5 w-3.5" />
              </button>
            </label>
          </Fs>

          <div className="flex justify-center gap-2 pt-1">
            <button type="button" className={btnPrimary}>
              Aceptar
            </button>
            <button type="button" className={btn}>
              Cancelar
            </button>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}
