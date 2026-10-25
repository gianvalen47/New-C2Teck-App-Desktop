import { useState } from "react";
import { CheckCircle2, LogOut, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

type ReportType = "totalized" | "detailed";
type ExportType = "screen" | "excel";

const labelClass = "absolute whitespace-nowrap text-[12px] font-bold leading-[16px] text-slate-900";
const inputClass =
  "absolute h-[21px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800";
const searchButtonClass =
  "absolute flex h-[22px] w-[25px] items-center justify-center rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 text-blue-800 hover:bg-[#CFE0F4]";

function OpportunityReportForm({ title }: { title: string }) {
  const today = new Date();
  const month = String(today.getMonth() + 1).padStart(2, "0");
  const day = String(today.getDate()).padStart(2, "0");
  const [reportType, setReportType] = useState<ReportType>("totalized");
  const [dateFrom, setDateFrom] = useState(`${today.getFullYear()}-${month}-01`);
  const [dateTo, setDateTo] = useState(`${today.getFullYear()}-${month}-${day}`);
  const [stage, setStage] = useState("(Todos)");
  const [name, setName] = useState("");
  const [allClients, setAllClients] = useState(true);
  const [client, setClient] = useState("(Todos)");
  const [allSellers, setAllSellers] = useState(true);
  const [seller, setSeller] = useState("RIOS ROSALES CARLOS");
  const [productType, setProductType] = useState("");
  const [description, setDescription] = useState("");
  const [visitType, setVisitType] = useState("(Todos)");
  const [exportType, setExportType] = useState<ExportType>("screen");

  const radio = <T extends string>(
    name: string,
    value: T,
    selected: T,
    onChange: (value: T) => void,
    label: string,
  ) => (
    <input
      aria-label={label}
      type="radio"
      name={name}
      checked={selected === value}
      onChange={() => onChange(value)}
      className="m-0 h-[13px] w-[13px] accent-[#0067b8]"
    />
  );

  return (
    <WindowShell title={title}>
      <div className="h-full min-h-0 overflow-auto bg-[#F3F3F3]">
        <div className="relative h-[456px] w-[408px] min-w-[408px] text-[12px] text-slate-900">
          <fieldset className="absolute left-[8px] top-[4px] h-[409px] w-[393px] rounded-sm border border-blue-400">
            <legend className="px-1 font-bold text-blue-800">Datos de Reporte</legend>

            <fieldset className="absolute left-[77px] top-[15px] h-[40px] w-[242px] rounded-sm border border-blue-400">
              <legend className="px-1 text-blue-800">Tipo</legend>
              <label className="absolute left-[23px] top-[15px] flex cursor-pointer items-center gap-1 font-bold">
                {radio(
                  "opportunity-report-type",
                  "totalized",
                  reportType,
                  setReportType,
                  "Totalizado",
                )}
                Totalizado
              </label>
              <label className="absolute left-[139px] top-[15px] flex cursor-pointer items-center gap-1 font-bold">
                {radio(
                  "opportunity-report-type",
                  "detailed",
                  reportType,
                  setReportType,
                  "Detallado",
                )}
                Detallado
              </label>
            </fieldset>

            <fieldset className="absolute left-[12px] top-[61px] h-[50px] w-[369px] rounded-sm border border-blue-400">
              <legend className="px-1 text-blue-800">Fecha Probable</legend>
              <label
                className={`${labelClass} left-[28px] top-[24px]`}
                htmlFor="opportunity-report-date-from"
              >
                Del :
              </label>
              <input
                id="opportunity-report-date-from"
                aria-label="Fecha probable desde"
                type="date"
                value={dateFrom}
                onChange={(event) => setDateFrom(event.target.value)}
                className="absolute left-[72px] top-[20px] h-[21px] w-[92px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800"
              />
              <label
                className={`${labelClass} left-[198px] top-[24px]`}
                htmlFor="opportunity-report-date-to"
              >
                Al :
              </label>
              <input
                id="opportunity-report-date-to"
                aria-label="Fecha probable hasta"
                type="date"
                value={dateTo}
                onChange={(event) => setDateTo(event.target.value)}
                className="absolute left-[242px] top-[20px] h-[21px] w-[92px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800"
              />
            </fieldset>

            <label
              className={`${labelClass} left-[10px] top-[123px]`}
              htmlFor="opportunity-report-stage"
            >
              Etapa :
            </label>
            <select
              id="opportunity-report-stage"
              aria-label="Etapa"
              value={stage}
              onChange={(event) => setStage(event.target.value)}
              className="absolute left-[74px] top-[119px] h-[21px] w-[292px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800"
            >
              <option>(Todos)</option>
            </select>

            <label
              className={`${labelClass} left-[10px] top-[150px]`}
              htmlFor="opportunity-report-name"
            >
              Nombre :
            </label>
            <input
              id="opportunity-report-name"
              aria-label="Nombre"
              value={name}
              onChange={(event) => setName(event.target.value.toUpperCase())}
              className={`${inputClass} left-[74px] top-[147px] w-[307px] uppercase`}
            />

            <fieldset className="absolute left-[12px] top-[174px] h-[60px] w-[369px] rounded-sm border border-blue-400">
              <legend className="px-1 text-blue-800">Buscar Cliente</legend>
              <label className="absolute left-[163px] top-[13px] flex cursor-pointer items-center gap-1 font-bold">
                <input
                  aria-label="Todo Cliente"
                  type="checkbox"
                  checked={allClients}
                  onChange={(event) => {
                    setAllClients(event.target.checked);
                    setClient(event.target.checked ? "(Todos)" : "");
                  }}
                  className="m-0 h-[13px] w-[13px] accent-[#0067b8]"
                />
                Todo Cliente
              </label>
              <label
                className={`${labelClass} left-[14px] top-[33px]`}
                htmlFor="opportunity-report-client"
              >
                Cliente
              </label>
              <input
                id="opportunity-report-client"
                aria-label="Cliente"
                value={client}
                readOnly={allClients}
                onChange={(event) => setClient(event.target.value)}
                className={`${inputClass} left-[65px] top-[30px] w-[266px]`}
              />
              <button
                type="button"
                title="Buscar Cliente"
                aria-label="Buscar Cliente"
                onClick={() => {
                  setAllClients(false);
                  setClient("");
                }}
                className={`${searchButtonClass} left-[333px] top-[29px]`}
              >
                <Search size={15} />
              </button>
            </fieldset>

            <fieldset className="absolute left-[12px] top-[241px] h-[60px] w-[369px] rounded-sm border border-blue-400">
              <legend className="px-1 text-blue-800">Buscar Vendedor</legend>
              <label className="absolute left-[160px] top-[14px] flex cursor-pointer items-center gap-1 font-bold">
                <input
                  aria-label="Todo Vendedor"
                  type="checkbox"
                  checked={allSellers}
                  onChange={(event) => {
                    setAllSellers(event.target.checked);
                    setSeller(event.target.checked ? "(Todos)" : "");
                  }}
                  className="m-0 h-[13px] w-[13px] accent-[#0067b8]"
                />
                Todo Vendedor
              </label>
              <label
                className={`${labelClass} left-[14px] top-[36px]`}
                htmlFor="opportunity-report-seller"
              >
                Vendedor
              </label>
              <select
                id="opportunity-report-seller"
                aria-label="Vendedor"
                value={seller}
                onChange={(event) => setSeller(event.target.value)}
                className="absolute left-[81px] top-[32px] h-[21px] w-[260px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800"
              >
                <option>RIOS ROSALES CARLOS</option>
                <option>(Todos)</option>
              </select>
            </fieldset>

            <label
              className={`${labelClass} left-[10px] top-[313px]`}
              htmlFor="opportunity-report-product"
            >
              Tipo Producto :
            </label>
            <input
              id="opportunity-report-product"
              aria-label="Tipo Producto"
              value={productType}
              onChange={(event) => setProductType(event.target.value.toUpperCase())}
              className={`${inputClass} left-[111px] top-[310px] w-[270px] uppercase`}
            />

            <label
              className={`${labelClass} left-[10px] top-[340px]`}
              htmlFor="opportunity-report-description"
            >
              Descripción :
            </label>
            <input
              id="opportunity-report-description"
              aria-label="Descripción"
              value={description}
              onChange={(event) => setDescription(event.target.value.toUpperCase())}
              className={`${inputClass} left-[111px] top-[337px] w-[270px] uppercase`}
            />

            <label
              className={`${labelClass} left-[10px] top-[377px]`}
              htmlFor="opportunity-report-visit-type"
            >
              Tipo Visita
            </label>
            <select
              id="opportunity-report-visit-type"
              aria-label="Tipo Visita"
              value={visitType}
              disabled={reportType === "totalized"}
              onChange={(event) => setVisitType(event.target.value)}
              className="absolute left-[83px] top-[373px] h-[21px] w-[121px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800 disabled:bg-slate-100"
            >
              <option>(Todos)</option>
            </select>

            <fieldset className="absolute left-[229px] top-[359px] h-[40px] w-[152px] rounded-sm border border-blue-400">
              <legend className="px-1 text-blue-800">Exportar</legend>
              <label className="absolute left-[13px] top-[13px] flex cursor-pointer items-center gap-1 font-bold">
                {radio("opportunity-export-type", "screen", exportType, setExportType, "Pantalla")}
                Pantalla
              </label>
              <label className="absolute left-[90px] top-[13px] flex cursor-pointer items-center gap-1 font-bold">
                {radio("opportunity-export-type", "excel", exportType, setExportType, "Excel")}
                Excel
              </label>
            </fieldset>
          </fieldset>

          <button
            type="button"
            className="absolute left-[125px] top-[420px] flex h-[27px] w-[76px] items-center justify-center gap-1 rounded-sm border border-slate-400 bg-white text-[12px] font-bold hover:bg-[#CFE0F4]"
          >
            <CheckCircle2 aria-hidden="true" size={16} className="text-green-600" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[207px] top-[420px] flex h-[27px] w-[80px] items-center justify-center gap-1 rounded-sm border border-slate-400 bg-white text-[12px] font-bold hover:bg-[#CFE0F4]"
          >
            <LogOut aria-hidden="true" size={15} className="text-blue-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}

export function OportunidadNegocio({
  title = "Reporte de Oportunidad de Negocio",
}: {
  title?: string;
}) {
  return <OportunidadNegocioList title={title} />;
}

export function OportunidadNegocioList({
  title = "Reporte de Oportunidad de Negocio",
}: {
  title?: string;
}) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <OpportunityReportForm title={title} />
    </div>
  );
}
