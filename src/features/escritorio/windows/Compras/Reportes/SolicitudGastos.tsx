import { useState } from "react";
import { CheckCircle2, LogOut, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

type ReportType = "totalizado" | "detallado";
type ExportType = "pantalla" | "excel";
type JobProcess = "todos" | "procesado" | "no-procesado";
type TravelExpense = "todos" | "gasto-viaje" | "no-gasto-viaje";

const comboClass =
  "absolute h-[21px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-700";
const inputClass =
  "absolute h-[21px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800";
const labelClass = "absolute whitespace-nowrap text-[12px] font-bold leading-[16px] text-slate-900";
const searchButtonClass =
  "absolute flex h-[22px] w-[25px] items-center justify-center rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 text-blue-800 hover:bg-[#CFE0F4]";

function SolicitudGastosForm({ title }: { title: string }) {
  const today = new Date();
  const currentMonth = String(today.getMonth() + 1).padStart(2, "0");
  const [reportType, setReportType] = useState<ReportType>("totalizado");
  const [startDate, setStartDate] = useState(
    `${today.getFullYear()}-${currentMonth}-01`,
  );
  const [endDate, setEndDate] = useState(
    `${today.getFullYear()}-${currentMonth}-${String(today.getDate()).padStart(2, "0")}`,
  );
  const [area, setArea] = useState("(Todos)");
  const [costCenter, setCostCenter] = useState("(Todos)");
  const [currency, setCurrency] = useState("S/");
  const [status, setStatus] = useState("(Todos)");
  const [jobNumber, setJobNumber] = useState("");
  const [accountCode, setAccountCode] = useState("");
  const [documentType, setDocumentType] = useState("(Todos)");
  const [documentNumber, setDocumentNumber] = useState("");
  const [licensePlate, setLicensePlate] = useState("(Todos)");
  const [expenseType, setExpenseType] = useState("(Todos)");
  const [description, setDescription] = useState("");
  const [allPersonnel, setAllPersonnel] = useState(true);
  const [person, setPerson] = useState("(Todos)");
  const [jobProcess, setJobProcess] = useState<JobProcess>("todos");
  const [travelExpense, setTravelExpense] = useState<TravelExpense>("todos");
  const [travelCategory, setTravelCategory] = useState("(Todos)");
  const [allProviders, setAllProviders] = useState(true);
  const [provider, setProvider] = useState("(Todos)");
  const [exportType, setExportType] = useState<ExportType>("pantalla");

  const radio = (name: string, value: string, checked: boolean, onChange: () => void) => (
    <input
      aria-label={value}
      className="m-0 h-[13px] w-[13px] accent-[#0067b8]"
      type="radio"
      name={name}
      checked={checked}
      onChange={onChange}
    />
  );

  return (
    <WindowShell title={title}>
      <div className="h-full min-h-0 overflow-auto bg-[#F3F3F3]">
        <div className="relative h-[406px] w-[745px] min-w-[745px] text-[12px] text-slate-900">
          <fieldset className="absolute left-[8px] top-[4px] h-[348px] w-[713px] border border-blue-400">
            <legend className="px-1 font-semibold text-blue-800">Datos de Reporte</legend>

            <fieldset className="absolute left-[248px] top-[2px] h-[40px] w-[199px] rounded-sm border border-blue-400">
              <legend className="px-1 text-center font-semibold text-blue-800">Tipo</legend>
              <div className="absolute left-[12px] top-[8px] flex items-center gap-[6px] font-bold">
                <label className="flex cursor-pointer items-center gap-1">
                  {radio("solicitud-gastos-tipo", "Totalizado", reportType === "totalizado", () => setReportType("totalizado"))}
                  Totalizado
                </label>
                <label className="ml-[10px] flex cursor-pointer items-center gap-1">
                  {radio("solicitud-gastos-tipo", "Detallado", reportType === "detallado", () => setReportType("detallado"))}
                  Detallado
                </label>
              </div>
            </fieldset>

            <span className={`${labelClass} left-[172px] top-[55px]`}>Fechas&nbsp;&nbsp; Del :</span>
            <input
              aria-label="Fecha inicial"
              className={`${inputClass} left-[269px] top-[51px] w-[97px]`}
              type="date"
              value={startDate}
              onChange={(event) => setStartDate(event.target.value)}
            />
            <span className={`${labelClass} left-[394px] top-[55px]`}>Al :</span>
            <input
              aria-label="Fecha final"
              className={`${inputClass} left-[426px] top-[51px] w-[94px]`}
              type="date"
              value={endDate}
              onChange={(event) => setEndDate(event.target.value)}
            />

            <span className="absolute left-[51px] top-[70px] whitespace-nowrap text-[12px] font-bold leading-[14px] text-red-600">
              Area de la Cabecera
            </span>
            <label className={`${labelClass} left-[5px] top-[89px]`} htmlFor="solicitud-gastos-area">Area :</label>
            <select
              id="solicitud-gastos-area"
              aria-label="Area"
              className={`${comboClass} left-[48px] top-[86px] w-[109px]`}
              value={area}
              onChange={(event) => setArea(event.target.value)}
            >
              <option>(Todos)</option>
            </select>
            <label className={`${labelClass} left-[173px] top-[89px]`} htmlFor="solicitud-gastos-centro">Centro Costo :</label>
            <select
              id="solicitud-gastos-centro"
              aria-label="Centro Costo"
              className={`${comboClass} left-[263px] top-[86px] w-[120px]`}
              value={costCenter}
              onChange={(event) => setCostCenter(event.target.value)}
              disabled
            >
              <option>(Todos)</option>
            </select>
            <label className={`${labelClass} left-[399px] top-[89px]`} htmlFor="solicitud-gastos-moneda">Moneda :</label>
            <select
              id="solicitud-gastos-moneda"
              aria-label="Moneda"
              className={`${comboClass} left-[461px] top-[86px] w-[54px] text-center`}
              value={currency}
              onChange={(event) => setCurrency(event.target.value)}
            >
              <option>S/</option>
              <option>US$</option>
            </select>
            <label className={`${labelClass} left-[532px] top-[89px]`} htmlFor="solicitud-gastos-estado">Estado :</label>
            <select
              id="solicitud-gastos-estado"
              aria-label="Estado"
              className={`${comboClass} left-[588px] top-[86px] w-[110px]`}
              value={status}
              onChange={(event) => setStatus(event.target.value)}
            >
              <option>(Todos)</option>
            </select>

            <label className={`${labelClass} left-[5px] top-[120px]`} htmlFor="solicitud-gastos-ot">OT :</label>
            <input
              id="solicitud-gastos-ot"
              aria-label="OT"
              className={`${inputClass} left-[32px] top-[117px] w-[55px] text-center`}
              value={jobNumber}
              onChange={(event) => setJobNumber(event.target.value)}
            />
            <button
              type="button"
              title="Buscar OT"
              aria-label="Buscar OT"
              onClick={() => document.getElementById("solicitud-gastos-ot")?.focus()}
              className={`${searchButtonClass} left-[88px] top-[116px]`}
            >
              <Search size={15} />
            </button>
            <label className={`${labelClass} left-[119px] top-[120px]`} htmlFor="solicitud-gastos-cuenta">Cod Cuenta :</label>
            <input
              id="solicitud-gastos-cuenta"
              aria-label="Cod Cuenta"
              className={`${inputClass} left-[200px] top-[117px] w-[64px]`}
              value={accountCode}
              onChange={(event) => setAccountCode(event.target.value)}
            />
            <label className={`${labelClass} left-[271px] top-[120px]`} htmlFor="solicitud-gastos-tipo-doc">Tipo Doc :</label>
            <select
              id="solicitud-gastos-tipo-doc"
              aria-label="Tipo Doc"
              className={`${comboClass} left-[337px] top-[117px] w-[94px]`}
              value={documentType}
              onChange={(event) => setDocumentType(event.target.value)}
            >
              <option>(Todos)</option>
            </select>
            <label className={`${labelClass} left-[440px] top-[120px]`} htmlFor="solicitud-gastos-documento">Doc :</label>
            <input
              id="solicitud-gastos-documento"
              aria-label="Doc"
              className={`${inputClass} left-[477px] top-[117px] w-[74px]`}
              value={documentNumber}
              onChange={(event) => setDocumentNumber(event.target.value)}
            />
            <label className={`${labelClass} left-[560px] top-[120px]`} htmlFor="solicitud-gastos-placa">Placa :</label>
            <select
              id="solicitud-gastos-placa"
              aria-label="Placa"
              className={`${comboClass} left-[606px] top-[117px] w-[92px]`}
              value={licensePlate}
              onChange={(event) => setLicensePlate(event.target.value)}
            >
              <option>(Todos)</option>
            </select>

            <label className={`${labelClass} left-[5px] top-[150px]`} htmlFor="solicitud-gastos-tipo">Tipo Gasto :</label>
            <select
              id="solicitud-gastos-tipo"
              aria-label="Tipo Gasto"
              className={`${comboClass} left-[78px] top-[147px] w-[163px]`}
              value={expenseType}
              onChange={(event) => setExpenseType(event.target.value)}
            >
              <option>(Todos)</option>
            </select>
            <label className={`${labelClass} left-[253px] top-[150px]`} htmlFor="solicitud-gastos-descripcion">Descripción :</label>
            <input
              id="solicitud-gastos-descripcion"
              aria-label="Descripción"
              className={`${inputClass} left-[337px] top-[147px] w-[361px]`}
              value={description}
              onChange={(event) => setDescription(event.target.value)}
            />

            <fieldset className="absolute left-[0px] top-[175px] h-[53px] w-[332px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Buscar Persona</legend>
              <label className="absolute left-[125px] top-[-1px] flex cursor-pointer items-center gap-1 font-bold text-slate-500">
                <input
                  type="checkbox"
                  checked={allPersonnel}
                  onChange={(event) => {
                    setAllPersonnel(event.target.checked);
                    if (event.target.checked) setPerson("(Todos)");
                  }}
                  className="h-[13px] w-[13px] accent-[#0067b8]"
                />
                Todo Personal
              </label>
              <label className="absolute left-[8px] top-[25px] font-bold" htmlFor="solicitud-gastos-persona">Persona</label>
              <input
                id="solicitud-gastos-persona"
                aria-label="Persona"
                className={`${inputClass} left-[70px] top-[22px] w-[217px] text-slate-500`}
                value={person}
                readOnly
              />
              <button
                type="button"
                title="Buscar Persona"
                aria-label="Buscar Persona"
                onClick={() => {
                  setAllPersonnel(false);
                  setPerson("");
                  document.getElementById("solicitud-gastos-persona")?.focus();
                }}
                className={`${searchButtonClass} left-[290px] top-[20px]`}
              >
                <Search size={15} />
              </button>
            </fieldset>

            <fieldset className="absolute left-[343px] top-[175px] h-[112px] w-[148px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Proceso OT</legend>
              <div className="absolute left-[15px] top-[16px] flex flex-col gap-[8px] font-bold text-slate-700">
                <label className="flex cursor-pointer items-center gap-2">
                  {radio("solicitud-gastos-proceso", "Todos los procesos OT", jobProcess === "todos", () => setJobProcess("todos"))}
                  Todos
                </label>
                <label className="flex cursor-pointer items-center gap-2">
                  {radio("solicitud-gastos-proceso", "Procesado al OT", jobProcess === "procesado", () => setJobProcess("procesado"))}
                  Proc. al OT
                </label>
                <label className="flex cursor-pointer items-center gap-2">
                  {radio("solicitud-gastos-proceso", "No procesado al OT", jobProcess === "no-procesado", () => setJobProcess("no-procesado"))}
                  No Proc. al OT
                </label>
              </div>
            </fieldset>

            <fieldset className="absolute left-[502px] top-[175px] h-[112px] w-[195px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Gastos Viaje</legend>
              <div className="absolute left-[15px] top-[13px] flex flex-col gap-[6px] font-bold text-slate-700">
                <label className="flex cursor-pointer items-center gap-2">
                  {radio("solicitud-gastos-viaje", "Todos los gastos de viaje", travelExpense === "todos", () => setTravelExpense("todos"))}
                  Todos
                </label>
                <label className="flex cursor-pointer items-center gap-2">
                  {radio("solicitud-gastos-viaje", "Gasto Viaje", travelExpense === "gasto-viaje", () => setTravelExpense("gasto-viaje"))}
                  Gasto Viaje
                </label>
                <label className="flex cursor-pointer items-center gap-2">
                  {radio("solicitud-gastos-viaje", "No Gasto Viaje", travelExpense === "no-gasto-viaje", () => setTravelExpense("no-gasto-viaje"))}
                  No Gasto Viaje
                </label>
              </div>
              <select
                aria-label="Rubro de gasto de viaje"
                className={`${comboClass} left-[39px] top-[51px] w-[138px]`}
                value={travelCategory}
                onChange={(event) => setTravelCategory(event.target.value)}
                disabled={travelExpense !== "gasto-viaje"}
              >
                <option>(Todos)</option>
              </select>
            </fieldset>

            <fieldset className="absolute left-[0px] top-[234px] h-[53px] w-[332px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Buscar Proveedor</legend>
              <label className="absolute left-[124px] top-[-1px] flex cursor-pointer items-center gap-1 font-bold text-slate-500">
                <input
                  type="checkbox"
                  checked={allProviders}
                  onChange={(event) => {
                    setAllProviders(event.target.checked);
                    if (event.target.checked) setProvider("(Todos)");
                  }}
                  className="h-[13px] w-[13px] accent-[#0067b8]"
                />
                Todo Proveedor
              </label>
              <label className="absolute left-[8px] top-[25px] font-bold" htmlFor="solicitud-gastos-proveedor">Proveedor</label>
              <input
                id="solicitud-gastos-proveedor"
                aria-label="Proveedor"
                className={`${inputClass} left-[69px] top-[22px] w-[218px] text-slate-500`}
                value={provider}
                readOnly
              />
              <button
                type="button"
                title="Buscar Proveedor"
                aria-label="Buscar Proveedor"
                onClick={() => {
                  setAllProviders(false);
                  setProvider("");
                  document.getElementById("solicitud-gastos-proveedor")?.focus();
                }}
                className={`${searchButtonClass} left-[290px] top-[20px]`}
              >
                <Search size={15} />
              </button>
            </fieldset>

            <fieldset className="absolute left-[228px] top-[291px] h-[40px] w-[238px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Exportar</legend>
              <div className="absolute left-[49px] top-[8px] flex items-center gap-[14px] font-bold">
                <label className="flex cursor-pointer items-center gap-1">
                  {radio("solicitud-gastos-exportar", "Pantalla", exportType === "pantalla", () => setExportType("pantalla"))}
                  Pantalla
                </label>
                <label className="flex cursor-pointer items-center gap-1">
                  {radio("solicitud-gastos-exportar", "Excel", exportType === "excel", () => setExportType("excel"))}
                  Excel
                </label>
              </div>
            </fieldset>
          </fieldset>

          <button
            type="button"
            className="absolute left-[284px] top-[358px] flex h-[27px] w-[76px] items-center justify-center gap-1 rounded-sm border border-blue-500 bg-white text-[12px] font-bold text-slate-900 hover:bg-[#CFE0F4]"
          >
            <CheckCircle2 aria-hidden="true" size={16} className="text-green-600" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[366px] top-[358px] flex h-[27px] w-[80px] items-center justify-center gap-1 rounded-sm border border-slate-400 bg-white text-[12px] font-bold text-slate-900 hover:bg-[#CFE0F4]"
          >
            <LogOut aria-hidden="true" size={15} className="text-blue-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}

export function ReporteSolicitudGastos({ title = "Reporte de Solicitud de Gasto" }: { title?: string }) {
  return <ReporteSolicitudGastosList title={title} />;
}

export function ReporteSolicitudGastosList({ title = "Reporte de Solicitud de Gasto" }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <SolicitudGastosForm title={title} />
    </div>
  );
}
