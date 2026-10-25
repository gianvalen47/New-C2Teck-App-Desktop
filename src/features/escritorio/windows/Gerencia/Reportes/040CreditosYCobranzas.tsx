import { useState } from "react";
import { Plus } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

function ReporteGerencialCreditosYCobranzas() {
  const today = new Date();
  const [startDate, setStartDate] = useState(
    `${today.getFullYear()}-${String(today.getMonth() + 1).padStart(2, "0")}-01`,
  );
  const [endDate, setEndDate] = useState(
    `${today.getFullYear()}-${String(today.getMonth() + 1).padStart(2, "0")}-${String(today.getDate()).padStart(2, "0")}`,
  );
  const [selectedReport, setSelectedReport] = useState<"ventas-cobranzas" | "saldos">(
    "ventas-cobranzas",
  );

  return (
    <WindowShell title="Reporte Gerencial de Créditos y Cobranzas">
      <div className="mx-auto flex h-full w-full max-w-[490px] flex-col overflow-auto bg-[#F8FBFF] px-4 py-4 text-[12px] text-slate-800">
        <div className="grid grid-cols-[auto_1fr_auto_1fr] items-center gap-2 whitespace-nowrap">
          <label htmlFor="gerencia-creditos-start" className="font-semibold">
            Fechas Del :
          </label>
          <input
            id="gerencia-creditos-start"
            type="date"
            value={startDate}
            onChange={(event) => setStartDate(event.target.value)}
            className="h-7 min-w-0 rounded-sm border border-slate-400 bg-white px-1 font-semibold"
          />
          <label htmlFor="gerencia-creditos-end" className="font-semibold">
            Al :
          </label>
          <input
            id="gerencia-creditos-end"
            type="date"
            value={endDate}
            onChange={(event) => setEndDate(event.target.value)}
            className="h-7 min-w-0 rounded-sm border border-slate-400 bg-white px-1 font-semibold"
          />
        </div>

        <div className="flex flex-1 flex-col">
          <h1 className="mb-2 mt-5 text-center text-lg font-bold tracking-wide text-red-800">
            CREDITOS Y COBRANZAS
          </h1>

          <div className="flex flex-col items-center">
            <section className="w-[270px]">
              <h2 className="mb-1 text-[13px] font-bold">Reporte Gerencial 041</h2>
              <div className="flex min-h-6 items-center gap-1">
                <label className="flex cursor-pointer items-center gap-2">
                  <input
                    type="radio"
                    name="gerencia-creditos-report"
                    checked={selectedReport === "ventas-cobranzas"}
                    onChange={() => setSelectedReport("ventas-cobranzas")}
                  />
                  Ventas vs Cobranzas con IGV
                </label>
                <button
                  type="button"
                  title="Agregar a Reporte Consolidado Vertical"
                  aria-label="Agregar Ventas vs Cobranzas con IGV al Reporte Consolidado Vertical"
                  onClick={() => setSelectedReport("ventas-cobranzas")}
                  className="ml-1 flex h-6 w-7 shrink-0 items-center justify-center rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 text-emerald-700 hover:bg-[#CFE0F4]"
                >
                  <Plus size={15} />
                </button>
              </div>
            </section>

            <section className="mt-1 w-[270px]">
              <h2 className="mb-1 text-[13px] font-bold">Reporte Gerencial 042</h2>
              <label className="flex min-h-6 cursor-pointer items-center gap-2">
                <input
                  type="radio"
                  name="gerencia-creditos-report"
                  checked={selectedReport === "saldos"}
                  onChange={() => setSelectedReport("saldos")}
                />
                Saldos de Cuentas por Cobrar
              </label>
            </section>
          </div>
        </div>

        <div className="flex justify-center gap-5 pt-3">
          <button
            type="button"
            className="h-8 min-w-[84px] rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 px-2 font-semibold hover:bg-[#CFE0F4]"
          >
            <span aria-hidden="true" className="mr-1 text-emerald-600">✓</span>
            Aceptar
          </button>
          <button
            type="button"
            onClick={() => setSelectedReport("ventas-cobranzas")}
            className="h-8 min-w-[84px] rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 px-2 font-semibold hover:bg-[#CFE0F4]"
          >
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}

export function Rpt040CreditosYCobranzas() {
  return <ReporteGerencialCreditosYCobranzas />;
}

export function GerenciaCreditosWindow() {
  return <Rpt040CreditosYCobranzas />;
}

export function ReporteCreco({ title = "Reporte Gerencial de Créditos y Cobranzas" }: { title?: string }) {
  return <ReporteCrecoList title={title} />;
}

export function ReporteCrecoList({ title = "Reporte Gerencial de Créditos y Cobranzas" }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <GerenciaCreditosWindow />
    </div>
  );
}
