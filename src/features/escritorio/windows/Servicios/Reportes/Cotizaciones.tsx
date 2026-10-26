import { useState } from "react";
import { CheckCircle2, LogOut, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

function getLocalDateString(date: Date) {
  const month = String(date.getMonth() + 1).padStart(2, "0");
  const day = String(date.getDate()).padStart(2, "0");
  return `${date.getFullYear()}-${month}-${day}`;
}

function getMonthStart() {
  const today = new Date();
  return getLocalDateString(new Date(today.getFullYear(), today.getMonth(), 1));
}

function getToday() {
  return getLocalDateString(new Date());
}

export function ReportesCotizaciones({ title = "Reporte de Cotización" }: { title?: string }) {
  return <ReportesCotizacionesList title={title} />;
}

export function ReportesCotizacionesList({ title = "Reporte de Cotización" }: { title?: string }) {
  const [startDate, setStartDate] = useState(getMonthStart);
  const [endDate, setEndDate] = useState(getToday);
  const [allClients, setAllClients] = useState(true);
  const [office, setOffice] = useState("(Todos)");
  const [vendor, setVendor] = useState("(Todos)");
  const [supervisor, setSupervisor] = useState("(Todos)");
  const [status, setStatus] = useState("(Todos)");

  return (
    <WindowShell title={title}>
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[250px] w-[514px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <div className="absolute left-[15px] top-[5px] h-[233px] w-[489px] border border-[#d7d7d7]">
            <label className="absolute left-[64px] top-[26px] whitespace-nowrap font-bold">
              Fechas&nbsp;&nbsp; Del :
            </label>
            <input
              aria-label="Fecha desde"
              type="date"
              value={startDate}
              onChange={(event) => setStartDate(event.target.value)}
              className="absolute left-[162px] top-[23px] h-[20px] w-[97px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold text-[#164b91]"
            />
            <label className="absolute left-[287px] top-[26px] whitespace-nowrap font-bold">
              Al :
            </label>
            <input
              aria-label="Fecha hasta"
              type="date"
              value={endDate}
              onChange={(event) => setEndDate(event.target.value)}
              className="absolute left-[319px] top-[23px] h-[20px] w-[94px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />

            <fieldset className="absolute left-[15px] top-[54px] h-[61px] w-[457px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
                Buscar Cliente
              </legend>
              <label className="absolute left-[160px] top-[17px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="checkbox"
                  checked={allClients}
                  onChange={(event) => setAllClients(event.target.checked)}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Todo Cliente
              </label>
              <label className="absolute left-[6px] top-[37px] whitespace-nowrap font-bold">
                Cliente :
              </label>
              <input
                aria-label="Cliente"
                value="(Todos)"
                readOnly
                className="absolute left-[66px] top-[34px] h-[20px] w-[345px] border border-[#d5d5d5] bg-white px-[4px] font-bold"
              />
              <button
                type="button"
                aria-label="Buscar cliente"
                className="absolute left-[417px] top-[33px] flex h-[21px] w-[25px] items-center justify-center rounded-[2px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed]"
              >
                <Search className="h-[15px] w-[15px] text-[#234878]" />
              </button>
            </fieldset>

            <label className="absolute left-[27px] top-[137px] whitespace-nowrap font-bold">
              Oficina :
            </label>
            <select
              aria-label="Oficina"
              value={office}
              onChange={(event) => setOffice(event.target.value)}
              className="absolute left-[84px] top-[133px] h-[20px] w-[142px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option>(Todos)</option>
            </select>
            <label className="absolute left-[244px] top-[137px] whitespace-nowrap font-bold">
              Vendedor :
            </label>
            <select
              aria-label="Vendedor"
              value={vendor}
              onChange={(event) => setVendor(event.target.value)}
              className="absolute left-[315px] top-[133px] h-[20px] w-[153px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option>(Todos)</option>
            </select>

            <label className="absolute left-[8px] top-[163px] whitespace-nowrap font-bold">
              Supervisor :
            </label>
            <select
              aria-label="Supervisor"
              value={supervisor}
              onChange={(event) => setSupervisor(event.target.value)}
              className="absolute left-[84px] top-[159px] h-[20px] w-[142px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option>(Todos)</option>
            </select>
            <label className="absolute left-[259px] top-[163px] whitespace-nowrap font-bold">
              Estado :
            </label>
            <select
              aria-label="Estado"
              value={status}
              onChange={(event) => setStatus(event.target.value)}
              className="absolute left-[315px] top-[159px] h-[20px] w-[153px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option>(Todos)</option>
            </select>

            <button
              type="button"
              className="absolute left-[161px] top-[199px] flex h-[27px] w-[80px] items-center justify-center gap-[4px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
            >
              <CheckCircle2 className="h-[17px] w-[17px] fill-green-600 text-white" />
              Aceptar
            </button>
            <button
              type="button"
              className="absolute left-[247px] top-[199px] flex h-[27px] w-[80px] items-center justify-center gap-[4px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
            >
              <LogOut className="h-[16px] w-[16px] text-gray-700" />
              Cancelar
            </button>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}
