import { useState } from "react";
import { Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

type SelectFilterProps = {
  label: string;
  value: string;
  onChange: (value: string) => void;
  className?: string;
  options?: string[];
};

function SelectFilter({ label, value, onChange, className = "", options = [] }: SelectFilterProps) {
  return (
    <label className={`flex min-w-0 items-center gap-1.5 whitespace-nowrap font-semibold ${className}`}>
      <span>{label}</span>
      <select
        aria-label={label.replace(/\s*:\s*$/, "")}
        value={value}
        onChange={(event) => onChange(event.target.value)}
        className="h-6 min-w-0 flex-1 rounded-sm border border-slate-400 bg-white px-1"
      >
        <option value="">(Todos)</option>
        {options.map((option) => (
          <option key={option} value={option}>{option}</option>
        ))}
      </select>
    </label>
  );
}

function ClientFilter({
  label,
  allLabel,
  all,
  onAllChange,
  client,
  onClientChange,
}: {
  label: string;
  allLabel: string;
  all: boolean;
  onAllChange: (checked: boolean) => void;
  client: string;
  onClientChange: (value: string) => void;
}) {
  return (
    <fieldset className="grid grid-cols-[1fr_auto] gap-x-2 rounded-sm border border-blue-400 px-3 pb-2 pt-1">
      <label className="col-span-2 flex cursor-pointer items-center justify-center gap-1 font-semibold text-slate-600">
        <input
          type="checkbox"
          checked={all}
          onChange={(event) => {
            onAllChange(event.target.checked);
            if (event.target.checked) onClientChange("(Todos)");
          }}
        />
        {allLabel}
      </label>
      <label className="flex min-w-0 items-center gap-1.5 whitespace-nowrap font-semibold">
        <span>{label}</span>
        <input
          value={client}
          disabled={all}
          onChange={(event) => {
            onClientChange(event.target.value);
            if (event.target.value !== "(Todos)") onAllChange(false);
          }}
          className="h-6 min-w-0 flex-1 rounded-sm border border-slate-400 bg-white px-1 disabled:bg-slate-100"
        />
      </label>
      <button
        type="button"
        title={`Buscar ${label.replace(/\s*:\s*$/, "")}`}
        aria-label={`Buscar ${label.replace(/\s*:\s*$/, "")}`}
        disabled={all}
        onClick={() => {
          onAllChange(false);
          onClientChange("");
        }}
        className="flex h-6 w-7 items-center justify-center rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 text-blue-800 hover:bg-[#CFE0F4] disabled:opacity-50"
      >
        <Search size={15} />
      </button>
    </fieldset>
  );
}

function ReporteOrdenesTrabajo() {
  const today = new Date();
  const [startDate, setStartDate] = useState(
    `${today.getFullYear()}-${String(today.getMonth() + 1).padStart(2, "0")}-01`,
  );
  const [endDate, setEndDate] = useState(
    `${today.getFullYear()}-${String(today.getMonth() + 1).padStart(2, "0")}-${String(today.getDate()).padStart(2, "0")}`,
  );
  const [dateMode, setDateMode] = useState<"apertura" | "liquidacion">("apertura");
  const [reportType, setReportType] = useState<"cotizados" | "gastos">("cotizados");
  const [exportMode, setExportMode] = useState<"pantalla" | "exportar">("pantalla");
  const [area, setArea] = useState("");
  const [costCenter, setCostCenter] = useState("");
  const [location, setLocation] = useState("");
  const [jobType, setJobType] = useState("");
  const [process, setProcess] = useState("");
  const [manufacturer, setManufacturer] = useState("");
  const [maintenance, setMaintenance] = useState("");
  const [application, setApplication] = useState("");
  const [series, setSeries] = useState("");
  const [unitLocation, setUnitLocation] = useState("");
  const [supervisor, setSupervisor] = useState("");
  const [allApplicants, setAllApplicants] = useState(true);
  const [applicant, setApplicant] = useState("(Todos)");
  const [allBeneficiaries, setAllBeneficiaries] = useState(true);
  const [beneficiary, setBeneficiary] = useState("(Todos)");

  return (
    <WindowShell title="Reporte de OT">
      <div className="mx-auto flex h-full w-full max-w-[700px] flex-col overflow-auto bg-[#F3F3F3] px-3 py-3 text-[12px] text-slate-900">
        <div className="flex flex-1 flex-col gap-2 border border-slate-300 p-3">
          <div className="grid grid-cols-[1fr_132px] gap-3">
            <fieldset className="flex min-w-0 items-center gap-3 rounded-sm border border-blue-400 px-3 py-1">
              <legend className="sr-only">Fechas</legend>
              <label className="flex items-center gap-2 whitespace-nowrap font-bold">
                Fechas&nbsp; Del :
                <input
                  type="date"
                  aria-label="Fecha inicial"
                  value={startDate}
                  onChange={(event) => setStartDate(event.target.value)}
                  className="h-6 min-w-0 rounded-sm border border-slate-400 bg-white px-1 font-semibold"
                />
              </label>
              <label className="flex items-center gap-2 whitespace-nowrap font-bold">
                Al :
                <input
                  type="date"
                  aria-label="Fecha final"
                  value={endDate}
                  onChange={(event) => setEndDate(event.target.value)}
                  className="h-6 min-w-0 rounded-sm border border-slate-400 bg-white px-1 font-semibold"
                />
              </label>
            </fieldset>

            <fieldset className="flex flex-col justify-center rounded-sm border border-blue-400 px-2 py-1">
              <legend className="sr-only">Filtrar fechas por</legend>
              <label className="flex h-5 cursor-pointer items-center gap-1 font-semibold">
                <input
                  type="radio"
                  name="ot-date-mode"
                  checked={dateMode === "apertura"}
                  onChange={() => setDateMode("apertura")}
                />
                Apertura OT
              </label>
              <label className="flex h-5 cursor-pointer items-center gap-1 font-semibold">
                <input
                  type="radio"
                  name="ot-date-mode"
                  checked={dateMode === "liquidacion"}
                  onChange={() => setDateMode("liquidacion")}
                />
                Liquidacion
              </label>
            </fieldset>
          </div>

          <fieldset className="grid grid-cols-[1fr_1.15fr] gap-2 rounded-sm border border-blue-400 px-3 pb-2 pt-1">
            <legend className="sr-only">Área y Centro de Costo</legend>
            <SelectFilter label="Area" value={area} onChange={setArea} />
            <SelectFilter label="Centro Costo" value={costCenter} onChange={setCostCenter} />
          </fieldset>

          <div className="grid grid-cols-3 gap-x-4 gap-y-2 px-1">
            <SelectFilter label="Locación :" value={location} onChange={setLocation} />
            <SelectFilter label="Tipo :" value={jobType} onChange={setJobType} />
            <SelectFilter label="Proceso :" value={process} onChange={setProcess} />
            <SelectFilter label="Fabricante :" value={manufacturer} onChange={setManufacturer} />
            <SelectFilter label="Mant. :" value={maintenance} onChange={setMaintenance} />
            <SelectFilter label="Aplicación :" value={application} onChange={setApplication} />
            <label className="flex min-w-0 items-center gap-1.5 whitespace-nowrap font-semibold">
              Serie :
              <input
                aria-label="Serie"
                value={series}
                onChange={(event) => setSeries(event.target.value)}
                className="h-6 min-w-0 flex-1 rounded-sm border border-slate-400 bg-white px-1"
              />
              <button
                type="button"
                title="Buscar Serie"
                aria-label="Buscar Serie"
                onClick={() => document.querySelector<HTMLInputElement>('input[aria-label="Serie"]')?.focus()}
                className="flex h-6 w-7 shrink-0 items-center justify-center rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 text-blue-800 hover:bg-[#CFE0F4]"
              >
                <Search size={15} />
              </button>
            </label>
            <SelectFilter label="Ubicación :" value={unitLocation} onChange={setUnitLocation} />
            <span />
            <SelectFilter label="Supervisor :" value={supervisor} onChange={setSupervisor} className="col-span-2" />
          </div>

          <ClientFilter
            label="Cliente Solicitante :"
            allLabel="Todo Cliente Solicitante"
            all={allApplicants}
            onAllChange={setAllApplicants}
            client={applicant}
            onClientChange={setApplicant}
          />

          <ClientFilter
            label="Cliente Beneficiado :"
            allLabel="Todo Cliente Beneficiado"
            all={allBeneficiaries}
            onAllChange={setAllBeneficiaries}
            client={beneficiary}
            onClientChange={setBeneficiary}
          />

          <div className="grid grid-cols-[1fr_200px] gap-4">
            <fieldset className="flex items-center gap-4 rounded-sm border border-blue-400 px-3 pb-2 pt-1">
              <legend className="px-1 font-semibold text-blue-800">Tipo</legend>
              <label className="flex cursor-pointer items-center gap-1 font-semibold">
                <input
                  type="radio"
                  name="ot-report-type"
                  checked={reportType === "cotizados"}
                  onChange={() => setReportType("cotizados")}
                />
                Montos Cotizados
              </label>
              <label className="flex cursor-pointer items-center gap-1 font-semibold">
                <input
                  type="radio"
                  name="ot-report-type"
                  checked={reportType === "gastos"}
                  onChange={() => setReportType("gastos")}
                />
                Gastos Incurridos
              </label>
            </fieldset>

            <fieldset className="flex items-center justify-center gap-3 rounded-sm border border-blue-400 px-2 pb-2 pt-1">
              <legend className="px-1 font-semibold text-blue-800">Exportar</legend>
              <label className="flex cursor-pointer items-center gap-1 font-semibold">
                <input
                  type="radio"
                  name="ot-export-mode"
                  checked={exportMode === "pantalla"}
                  onChange={() => setExportMode("pantalla")}
                />
                Pantalla
              </label>
              <label className="flex cursor-pointer items-center gap-1 font-semibold">
                <input
                  type="radio"
                  name="ot-export-mode"
                  checked={exportMode === "exportar"}
                  onChange={() => setExportMode("exportar")}
                />
                Exportar
              </label>
            </fieldset>
          </div>

          <div className="flex justify-center gap-3 pt-1">
            <button
              type="button"
              className="h-8 min-w-[80px] rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 px-2 font-bold hover:bg-[#CFE0F4]"
            >
              <span aria-hidden="true" className="mr-1 text-emerald-600">✓</span>
              Aceptar
            </button>
            <button
              type="button"
              onClick={() => {
                setDateMode("apertura");
                setReportType("cotizados");
                setExportMode("pantalla");
                setAllApplicants(true);
                setApplicant("(Todos)");
                setAllBeneficiaries(true);
                setBeneficiary("(Todos)");
              }}
              className="h-8 min-w-[80px] rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 px-2 font-bold hover:bg-[#CFE0F4]"
            >
              Cancelar
            </button>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}

export function ReporteOT({ title = "Reporte de OT" }: { title?: string }) {
  return <ReporteOTList title={title} />;
}

export function ReporteOTList({ title = "Reporte de OT" }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <ReporteOrdenesTrabajo />
    </div>
  );
}
