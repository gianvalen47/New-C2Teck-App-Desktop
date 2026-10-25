import { useState } from "react";
import { WindowShell } from "@/components/ui/desktop-primitives";

const months = [
  "ENERO",
  "FEBRERO",
  "MARZO",
  "ABRIL",
  "MAYO",
  "JUNIO",
  "JULIO",
  "AGOSTO",
  "SETIEMBRE",
  "OCTUBRE",
  "NOVIEMBRE",
  "DICIEMBRE",
];

const years = Array.from({ length: 21 }, (_, index) => new Date().getFullYear() - 10 + index);

function ReporteEstadoFinanciero() {
  const currentDate = new Date();
  const previousMonth = currentDate.getMonth() === 0 ? 11 : currentDate.getMonth() - 1;
  const previousYear = currentDate.getMonth() === 0 ? currentDate.getFullYear() - 1 : currentDate.getFullYear();

  const [statementType, setStatementType] = useState<"balance" | "profit-loss">("balance");
  const [year, setYear] = useState(previousYear);
  const [month, setMonth] = useState(previousMonth);
  const [currency, setCurrency] = useState("NS");
  const [businessUnit, setBusinessUnit] = useState("");
  const [area, setArea] = useState("");
  const [costCenter, setCostCenter] = useState("");

  return (
    <WindowShell title="Estado Financiero">
      <div className="mx-auto flex h-full w-full max-w-[580px] flex-col overflow-auto bg-[#F8FBFF] px-4 py-3 text-[12px] font-semibold text-slate-800">
        <fieldset className="rounded-sm border border-blue-400 px-3 pb-2 pt-1">
          <legend className="px-1 text-blue-800">Tipo</legend>
          <div className="flex min-h-7 flex-wrap items-center justify-center gap-x-7 gap-y-1">
            <label className="flex cursor-pointer items-center gap-1.5 whitespace-nowrap">
              <input
                type="radio"
                name="estado-financiero-tipo"
                checked={statementType === "balance"}
                onChange={() => setStatementType("balance")}
              />
              Balance General
            </label>
            <label className="flex cursor-pointer items-center gap-1.5 whitespace-nowrap">
              <input
                type="radio"
                name="estado-financiero-tipo"
                checked={statementType === "profit-loss"}
                onChange={() => setStatementType("profit-loss")}
              />
              Estado Ganancias y Perdidas
            </label>
          </div>
        </fieldset>

        <div className="mt-2 grid grid-cols-[1fr_118px] gap-3">
          <fieldset className="min-w-0 rounded-sm border border-blue-400 px-3 pb-2 pt-1">
            <legend className="px-1 text-blue-800">Período</legend>
            <div className="flex min-h-7 items-center justify-between gap-3">
              <label className="flex items-center gap-2">
                Año
                <select
                  value={year}
                  onChange={(event) => setYear(Number(event.target.value))}
                  className="h-7 w-[70px] rounded-sm border border-slate-400 bg-white px-1"
                >
                  {years.map((option) => (
                    <option key={option} value={option}>{option}</option>
                  ))}
                </select>
              </label>
              <label className="flex items-center gap-2">
                Mes
                <select
                  value={month}
                  onChange={(event) => setMonth(Number(event.target.value))}
                  className="h-7 w-[130px] rounded-sm border border-slate-400 bg-white px-1"
                >
                  {months.map((option, index) => (
                    <option key={option} value={index}>{option}</option>
                  ))}
                </select>
              </label>
            </div>
          </fieldset>

          <fieldset className="rounded-sm border border-blue-400 px-3 pb-2 pt-1">
            <legend className="px-1 text-blue-800">Moneda</legend>
            <select
              aria-label="Moneda"
              value={currency}
              onChange={(event) => setCurrency(event.target.value)}
              className="mt-1 h-7 w-full rounded-sm border border-slate-400 bg-white px-2"
            >
              <option value="NS">S/</option>
              <option value="US">US$</option>
            </select>
          </fieldset>
        </div>

        <fieldset className="mt-3 grid grid-cols-[1fr_1fr] gap-x-5 gap-y-2 rounded-sm border border-blue-400 px-3 pb-2 pt-3">
          <label htmlFor="estado-financiero-unidad" className="flex items-center gap-2">
            <span className="whitespace-nowrap">Unidad de Negocio</span>
            <select
              id="estado-financiero-unidad"
              value={businessUnit}
              onChange={(event) => {
                setBusinessUnit(event.target.value);
                setArea("");
                setCostCenter("");
              }}
              className="h-7 min-w-0 flex-1 rounded-sm border border-slate-400 bg-white px-1"
            >
              <option value="">(Todos)</option>
            </select>
          </label>
          <label htmlFor="estado-financiero-area" className="flex items-center gap-2">
            <span>Area</span>
            <select
              id="estado-financiero-area"
              value={area}
              onChange={(event) => {
                setArea(event.target.value);
                setCostCenter("");
              }}
              className="h-7 min-w-0 flex-1 rounded-sm border border-slate-400 bg-white px-1"
            >
              <option value="">(Todos)</option>
            </select>
          </label>
          <label htmlFor="estado-financiero-centro" className="col-span-2 flex items-center gap-2">
            <span className="whitespace-nowrap">Centro de Costo</span>
            <select
              id="estado-financiero-centro"
              value={costCenter}
              onChange={(event) => setCostCenter(event.target.value)}
              className="h-7 w-[min(100%,210px)] rounded-sm border border-slate-400 bg-white px-1"
            >
              <option value="">(Todos)</option>
            </select>
          </label>
        </fieldset>

        <div className="flex justify-center gap-3 pt-3">
          <button
            type="button"
            className="h-8 min-w-[86px] rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 px-3 font-semibold hover:bg-[#CFE0F4]"
          >
            <span aria-hidden="true" className="mr-1 text-emerald-600">✓</span>
            Aceptar
          </button>
          <button
            type="button"
            onClick={() => {
              setStatementType("balance");
              setYear(previousYear);
              setMonth(previousMonth);
              setCurrency("NS");
              setBusinessUnit("");
              setArea("");
              setCostCenter("");
            }}
            className="h-8 min-w-[86px] rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 px-3 font-semibold hover:bg-[#CFE0F4]"
          >
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}

export function EstadosFinancieros() {
  return <ReporteEstadoFinanciero />;
}

export function EstadosFinancierosWindow() {
  return <EstadosFinancieros />;
}

export function ReporteFinanciero({ title = "Estados Financieros" }: { title?: string }) {
  return <ReporteFinancieroList title={title} />;
}

export function ReporteFinancieroList({ title = "Reporte Financiero" }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <EstadosFinancierosWindow />
    </div>
  );
}
