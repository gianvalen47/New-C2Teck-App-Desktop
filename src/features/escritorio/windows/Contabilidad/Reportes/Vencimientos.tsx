import { useState } from "react";
import { CheckCircle2, LogOut, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

type PurchaseType = "local" | "foreign";
type Condition = "pending" | "all";
type DetailType = "detailed" | "grouped";
type SortOrder = "due-date" | "provider";

const labelClass = "absolute whitespace-nowrap text-[12px] font-bold leading-[16px] text-slate-900";
const inputClass =
  "absolute h-[21px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800";
const searchButtonClass =
  "absolute flex h-[22px] w-[25px] items-center justify-center rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 text-blue-800 hover:bg-[#CFE0F4]";

function AccountsPayableMaturityForm({ title }: { title: string }) {
  const today = new Date();
  const month = String(today.getMonth() + 1).padStart(2, "0");
  const day = String(today.getDate()).padStart(2, "0");
  const [dateFrom, setDateFrom] = useState(`${today.getFullYear()}-${month}-01`);
  const [dateTo, setDateTo] = useState(`${today.getFullYear()}-${month}-${day}`);
  const [allProviders, setAllProviders] = useState(true);
  const [provider, setProvider] = useState("(TODOS)");
  const [documentType, setDocumentType] = useState("(Todos)");
  const [purchaseType, setPurchaseType] = useState<PurchaseType>("local");
  const [condition, setCondition] = useState<Condition>("pending");
  const [detailType, setDetailType] = useState<DetailType>("detailed");
  const [sortOrder, setSortOrder] = useState<SortOrder>("due-date");

  const radio = (name: string, value: string, checked: boolean, onChange: () => void) => (
    <input
      aria-label={value}
      type="radio"
      name={name}
      checked={checked}
      onChange={onChange}
      className="m-0 h-[13px] w-[13px] accent-[#0067b8]"
    />
  );

  return (
    <WindowShell title={title}>
      <div className="h-full min-h-0 overflow-auto bg-[#F3F3F3]">
        <div className="relative h-[321px] w-[522px] min-w-[522px] text-[12px] text-slate-900">
          <div className="absolute left-[13px] top-[7px] h-[258px] w-[481px] rounded-sm border border-slate-300">
            <label className={`${labelClass} left-[56px] top-[21px]`} htmlFor="ap-maturity-date-from">
              Fechas&nbsp;&nbsp; Del :
            </label>
            <input
              id="ap-maturity-date-from"
              aria-label="Fecha desde"
              type="date"
              value={dateFrom}
              onChange={(event) => setDateFrom(event.target.value)}
              className="absolute left-[154px] top-[18px] h-[21px] w-[97px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800"
            />
            <label className={`${labelClass} left-[267px] top-[21px]`} htmlFor="ap-maturity-date-to">
              Al :
            </label>
            <input
              id="ap-maturity-date-to"
              aria-label="Fecha hasta"
              type="date"
              value={dateTo}
              onChange={(event) => setDateTo(event.target.value)}
              className="absolute left-[313px] top-[18px] h-[21px] w-[94px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800"
            />

            <fieldset className="absolute left-[20px] top-[43px] h-[58px] w-[445px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Buscar Proveedor</legend>
              <label className="absolute left-[183px] top-[12px] flex cursor-pointer items-center gap-1 font-bold">
                <input
                  aria-label="Todo Proveedor"
                  type="checkbox"
                  checked={allProviders}
                  onChange={(event) => {
                    setAllProviders(event.target.checked);
                    setProvider(event.target.checked ? "(TODOS)" : "");
                  }}
                  className="m-0 h-[13px] w-[13px] accent-[#0067b8]"
                />
                Todo Proveedor
              </label>
              <label className={`${labelClass} left-[18px] top-[35px]`} htmlFor="ap-maturity-provider">
                Proveedor
              </label>
              <input
                id="ap-maturity-provider"
                aria-label="Proveedor"
                value={provider}
                readOnly={allProviders}
                onChange={(event) => setProvider(event.target.value)}
                className={`${inputClass} left-[89px] top-[32px] w-[296px]`}
              />
              <button
                type="button"
                title="Buscar Proveedor"
                aria-label="Buscar Proveedor"
                onClick={() => {
                  setAllProviders(false);
                  setProvider("");
                  document.getElementById("ap-maturity-provider")?.focus();
                }}
                className={`${searchButtonClass} left-[387px] top-[31px]`}
              >
                <Search size={15} />
              </button>
            </fieldset>

            <fieldset className="absolute left-[20px] top-[109px] h-[44px] w-[445px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Documento</legend>
              <label className={`${labelClass} left-[33px] top-[20px]`} htmlFor="ap-maturity-document-type">
                Tipo Documento
              </label>
              <select
                id="ap-maturity-document-type"
                aria-label="Tipo Documento"
                value={documentType}
                onChange={(event) => setDocumentType(event.target.value)}
                className="absolute left-[139px] top-[16px] h-[21px] w-[249px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800"
              >
                <option>(Todos)</option>
              </select>
            </fieldset>

            <fieldset className="absolute left-[7px] top-[168px] h-[79px] w-[144px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Tipo de Compra</legend>
              <label className="absolute left-[5px] top-[22px] flex cursor-pointer items-center gap-1 font-bold">
                {radio("ap-maturity-purchase-type", "Compras Locales", purchaseType === "local", () => setPurchaseType("local"))}
                Compras Locales
              </label>
              <label className="absolute left-[5px] top-[45px] flex cursor-pointer items-center gap-1 font-bold">
                {radio("ap-maturity-purchase-type", "Compras al Exterior", purchaseType === "foreign", () => setPurchaseType("foreign"))}
                Compras al Exterior
              </label>
            </fieldset>

            <fieldset className="absolute left-[157px] top-[168px] h-[79px] w-[99px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Condición</legend>
              <label className="absolute left-[6px] top-[21px] flex cursor-pointer items-center gap-1 font-bold">
                {radio("ap-maturity-condition", "Pendientes", condition === "pending", () => setCondition("pending"))}
                Pendientes
              </label>
              <label className="absolute left-[6px] top-[46px] flex cursor-pointer items-center gap-1 font-bold">
                {radio("ap-maturity-condition", "Todos", condition === "all", () => setCondition("all"))}
                Todos
              </label>
            </fieldset>

            <fieldset className="absolute left-[261px] top-[168px] h-[79px] w-[92px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Tipo</legend>
              <label className="absolute left-[6px] top-[21px] flex cursor-pointer items-center gap-1 font-bold">
                {radio("ap-maturity-detail-type", "Detallado", detailType === "detailed", () => setDetailType("detailed"))}
                Detallado
              </label>
              <label className="absolute left-[6px] top-[46px] flex cursor-pointer items-center gap-1 font-bold">
                {radio("ap-maturity-detail-type", "Agrupado", detailType === "grouped", () => setDetailType("grouped"))}
                Agrupado
              </label>
            </fieldset>

            <fieldset className="absolute left-[359px] top-[168px] h-[79px] w-[113px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Ordenado por :</legend>
              <label className="absolute left-[10px] top-[16px] flex cursor-pointer items-center gap-1 font-bold">
                {radio("ap-maturity-sort", "Fecha Venc.", sortOrder === "due-date", () => setSortOrder("due-date"))}
                Fecha Venc.
              </label>
              <label className="absolute left-[10px] top-[35px] flex cursor-pointer items-center gap-1 font-bold">
                {radio("ap-maturity-sort", "Proveedor", sortOrder === "provider", () => setSortOrder("provider"))}
                Proveedor
              </label>
            </fieldset>
          </div>

          <button
            type="button"
            className="absolute left-[173px] top-[274px] flex h-[27px] w-[78px] items-center justify-center gap-1 rounded-sm border border-slate-400 bg-white text-[12px] font-bold hover:bg-[#CFE0F4]"
          >
            <CheckCircle2 aria-hidden="true" size={16} className="text-green-600" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[255px] top-[274px] flex h-[27px] w-[78px] items-center justify-center gap-1 rounded-sm border border-slate-400 bg-white text-[12px] font-bold hover:bg-[#CFE0F4]"
          >
            <LogOut aria-hidden="true" size={15} className="text-blue-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}

export function ReporteVencimiento({ title = "Reporte de Vencimientos de Cuentas x Pagar Contable" }: { title?: string }) {
  return <ReporteVencimientoList title={title} />;
}

export function ReporteVencimientoList({ title = "Reporte de Vencimientos de Cuentas x Pagar Contable" }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <AccountsPayableMaturityForm title={title} />
    </div>
  );
}
