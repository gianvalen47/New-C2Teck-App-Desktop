import { useState } from "react";
import {
  btn,
  btnPrimary,
  Fs,
  inp,
  Radio,
  WindowShell,
} from "@/components/ui/desktop-primitives";

function toDateInputValue(date: Date) {
  const month = String(date.getMonth() + 1).padStart(2, "0");
  const day = String(date.getDate()).padStart(2, "0");
  return `${date.getFullYear()}-${month}-${day}`;
}

function getMonthStart() {
  const today = new Date();
  return toDateInputValue(new Date(today.getFullYear(), today.getMonth(), 1));
}

function getToday() {
  return toDateInputValue(new Date());
}

export function ReporteValeRequisicionList({
  title = "Vales de Requisiciones",
}: {
  title?: string;
}) {
  const [startDate, setStartDate] = useState(getMonthStart);
  const [endDate, setEndDate] = useState(getToday);
  const [office, setOffice] = useState("LIMA");
  const [warehouse, setWarehouse] = useState("COMERCIAL");
  const [status, setStatus] = useState("(Todos)");
  const [category, setCategory] = useState("(Todos)");

  const filterClass =
    "grid grid-cols-[68px_minmax(0,1fr)] items-center gap-1 font-bold";

  return (
    <WindowShell title={title}>
      <div className="flex h-full items-center justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[460px] space-y-2 px-1 py-1">
          <div className="flex items-center justify-center gap-5">
            <span className="font-bold">Fechas</span>
            <label className="flex items-center gap-1.5">
              <span className="font-bold">Del :</span>
              <input
                aria-label="Fecha desde"
                className={`${inp} h-6 w-[100px] px-1`}
                type="date"
                min="2010-01-01"
                value={startDate}
                onChange={(event) => setStartDate(event.target.value)}
              />
            </label>
            <label className="flex items-center gap-1.5">
              <span className="font-bold">Al</span>
              <input
                aria-label="Fecha hasta"
                className={`${inp} h-6 w-[100px] px-1`}
                type="date"
                min="2010-01-01"
                value={endDate}
                onChange={(event) => setEndDate(event.target.value)}
              />
            </label>
          </div>

          <div className="grid grid-cols-2 gap-x-3 gap-y-1">
            <label className={filterClass}>
              <span>Oficina:</span>
              <select
                aria-label="Oficina"
                className={`${inp} h-6 min-w-0 px-1`}
                value={office}
                onChange={(event) => setOffice(event.target.value)}
              >
                <option>LIMA</option>
              </select>
            </label>
            <label className={filterClass}>
              <span>Almacén:</span>
              <select
                aria-label="Almacén"
                className={`${inp} h-6 min-w-0 px-1`}
                value={warehouse}
                onChange={(event) => setWarehouse(event.target.value)}
              >
                <option>COMERCIAL</option>
              </select>
            </label>
            <label className={filterClass}>
              <span>Estado:</span>
              <select
                aria-label="Estado"
                className={`${inp} h-6 min-w-0 px-1`}
                value={status}
                onChange={(event) => setStatus(event.target.value)}
              >
                <option>(Todos)</option>
              </select>
            </label>
            <label className={filterClass}>
              <span>Rubro:</span>
              <select
                aria-label="Rubro"
                className={`${inp} h-6 min-w-0 px-1`}
                value={category}
                onChange={(event) => setCategory(event.target.value)}
              >
                <option>(Todos)</option>
              </select>
            </label>
          </div>

          <div className="grid grid-cols-2 gap-2">
            <Fs legend="Tipo Reporte" className="px-2 pb-1 pt-0">
              <div className="flex justify-center gap-3">
                <Radio
                  name="vale-requisicion-tipo-reporte"
                  label="Resumen"
                  defaultChecked
                />
                <Radio
                  name="vale-requisicion-tipo-reporte"
                  label="Detalle"
                />
              </div>
            </Fs>
            <Fs legend="Exportar" className="px-2 pb-1 pt-0">
              <div className="flex justify-center gap-3">
                <Radio
                  name="vale-requisicion-exportar"
                  label="Pantalla"
                  defaultChecked
                />
                <Radio
                  name="vale-requisicion-exportar"
                  label="Exportar"
                />
              </div>
            </Fs>
          </div>

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

export function ReporteValeRequisicion() {
  return <ReporteValeRequisicionList />;
}
