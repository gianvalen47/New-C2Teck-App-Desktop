import { useState } from "react";
import { CheckCircle2, LogOut, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

function formatLocalDate(date: Date) {
  const month = String(date.getMonth() + 1).padStart(2, "0");
  const day = String(date.getDate()).padStart(2, "0");
  return `${date.getFullYear()}-${month}-${day}`;
}

function getMonthStart() {
  const today = new Date();
  return formatLocalDate(new Date(today.getFullYear(), today.getMonth(), 1));
}

function getToday() {
  return formatLocalDate(new Date());
}

export function LiquidacionXGarantia({ title = "OT Garantia" }: { title?: string }) {
  return <LiquidacionXGarantiaList title={title} />;
}

export function LiquidacionXGarantiaList({ title = "OT Garantia" }: { title?: string }) {
  const [reportType, setReportType] = useState<"job" | "liquidation">("job");
  const [liquidationStatus, setLiquidationStatus] = useState<
    "all" | "settled" | "invoiced"
  >("all");
  const [allClients, setAllClients] = useState(true);
  const [client, setClient] = useState("(Todos)");
  const [creditStateFrom, setCreditStateFrom] = useState("");
  const [creditStateTo, setCreditStateTo] = useState("");
  const [location, setLocation] = useState("(Todos)");
  const [claimNumber, setClaimNumber] = useState("");
  const [startDate, setStartDate] = useState(getMonthStart);
  const [endDate, setEndDate] = useState(getToday);

  const labelClass = "absolute whitespace-nowrap font-bold";
  const fieldClass =
    "absolute h-[20px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold";
  const disabledChoice = "text-gray-400";

  return (
    <WindowShell title={title}>
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[399px] w-[412px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <div className="absolute left-[7px] top-0 h-[343px] w-[382px] border border-[#d7d7d7]">
            <fieldset className="absolute left-[6px] top-[11px] h-[91px] w-[370px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] font-bold text-[#164b91]">Tipo</legend>
              <label className="absolute left-[27px] top-[18px] flex items-center gap-[5px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="ot-garantia-report-type"
                  checked={reportType === "job"}
                  onChange={() => setReportType("job")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Por OT
              </label>
              <label className="absolute left-[140px] top-[18px] flex items-center gap-[5px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="ot-garantia-report-type"
                  checked={reportType === "liquidation"}
                  onChange={() => {
                    setReportType("liquidation");
                    setLiquidationStatus("all");
                  }}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Por Liquidación
              </label>
              <fieldset
                disabled={reportType !== "liquidation"}
                className="absolute left-[247px] top-[7px] h-[75px] w-[103px] border border-[#7799c5] px-0 disabled:border-[#c8c8c8]"
              >
                <label
                  className={`absolute left-[6px] top-[9px] flex items-center gap-[4px] whitespace-nowrap font-bold ${reportType !== "liquidation" ? disabledChoice : ""}`}
                >
                  <input
                    type="radio"
                    name="ot-garantia-liquidation-status"
                    checked={liquidationStatus === "all"}
                    onChange={() => setLiquidationStatus("all")}
                    className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                  />
                  Todos
                </label>
                <label
                  className={`absolute left-[6px] top-[31px] flex items-center gap-[4px] whitespace-nowrap font-bold ${reportType !== "liquidation" ? disabledChoice : ""}`}
                >
                  <input
                    type="radio"
                    name="ot-garantia-liquidation-status"
                    checked={liquidationStatus === "settled"}
                    onChange={() => setLiquidationStatus("settled")}
                    className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                  />
                  Liquidado
                </label>
                <label
                  className={`absolute left-[6px] top-[53px] flex items-center gap-[4px] whitespace-nowrap font-bold ${reportType !== "liquidation" ? disabledChoice : ""}`}
                >
                  <input
                    type="radio"
                    name="ot-garantia-liquidation-status"
                    checked={liquidationStatus === "invoiced"}
                    onChange={() => setLiquidationStatus("invoiced")}
                    className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                  />
                  Facturado
                </label>
              </fieldset>
            </fieldset>

            <fieldset className="absolute left-[6px] top-[108px] h-[57px] w-[370px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] font-bold text-[#164b91]">
                Buscar Cliente
              </legend>
              <label className="absolute left-[139px] top-[7px] flex items-center gap-[5px] whitespace-nowrap font-bold">
                <input
                  type="checkbox"
                  checked={allClients}
                  onChange={(event) => {
                    const checked = event.target.checked;
                    setAllClients(checked);
                    if (checked) setClient("(Todos)");
                    else if (client === "(Todos)") setClient("");
                  }}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Todo Cliente
              </label>
              <label className={`${labelClass} left-[6px] top-[31px]`}>Cliente :</label>
              <input
                aria-label="Cliente"
                value={client}
                readOnly
                className="absolute left-[66px] top-[28px] h-[20px] w-[267px] border border-[#d5d5d5] bg-white px-[4px] font-bold"
              />
              <button
                type="button"
                aria-label="Buscar cliente"
                className="absolute left-[338px] top-[27px] flex h-[21px] w-[25px] items-center justify-center rounded-[2px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed]"
              >
                <Search className="h-[15px] w-[15px] text-[#234878]" />
              </button>
            </fieldset>

            <fieldset className="absolute left-[6px] top-[172px] h-[45px] w-[370px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] font-bold text-[#164b91]">
                Credit State
              </legend>
              <label className={`${labelClass} left-[36px] top-[17px]`}>Desde</label>
              <input
                aria-label="Credit State desde"
                value={creditStateFrom}
                onChange={(event) => setCreditStateFrom(event.target.value)}
                className="absolute left-[84px] top-[14px] h-[20px] w-[84px] border border-[#d5d5d5] bg-white px-[3px] font-bold"
              />
              <label className={`${labelClass} left-[184px] top-[17px]`}>Hasta</label>
              <input
                aria-label="Credit State hasta"
                value={creditStateTo}
                onChange={(event) => setCreditStateTo(event.target.value)}
                className="absolute left-[229px] top-[14px] h-[20px] w-[84px] border border-[#d5d5d5] bg-white px-[3px] font-bold"
              />
            </fieldset>

            <label className={`${labelClass} left-[89px] top-[231px]`}>Locación :</label>
            <select
              aria-label="Locación"
              value={location}
              onChange={(event) => setLocation(event.target.value)}
              className={`${fieldClass} left-[184px] top-[228px] w-[120px]`}
            >
              <option>(Todos)</option>
            </select>

            <label className={`${labelClass} left-[89px] top-[256px]`}>Nro. Claim :</label>
            <input
              aria-label="Número de Claim"
              value={claimNumber}
              onChange={(event) => setClaimNumber(event.target.value)}
              className="absolute left-[184px] top-[254px] h-[20px] w-[95px] border border-[#d5d5d5] bg-white px-[3px] font-bold"
            />

            <label className={`${labelClass} left-[89px] top-[283px]`}>Fecha Inicio :</label>
            <input
              aria-label="Fecha Inicio"
              type="date"
              value={startDate}
              onChange={(event) => setStartDate(event.target.value)}
              className={`${fieldClass} left-[184px] top-[280px] w-[95px]`}
            />

            <label className={`${labelClass} left-[89px] top-[309px]`}>Fecha Fin :</label>
            <input
              aria-label="Fecha Fin"
              type="date"
              value={endDate}
              onChange={(event) => setEndDate(event.target.value)}
              className={`${fieldClass} left-[184px] top-[306px] w-[95px]`}
            />
          </div>

          <button
            type="button"
            className="absolute left-[111px] top-[350px] flex h-[27px] w-[79px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <CheckCircle2 className="h-[16px] w-[16px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[204px] top-[350px] flex h-[27px] w-[79px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <LogOut className="h-[15px] w-[15px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
