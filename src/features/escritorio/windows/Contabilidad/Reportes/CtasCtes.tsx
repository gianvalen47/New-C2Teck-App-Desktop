import { useState } from "react";
import { CheckCircle2, LogOut, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

const labelClass = "absolute whitespace-nowrap text-[12px] font-bold leading-[16px] text-slate-900";
const inputClass =
  "absolute h-[21px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800";
const searchButtonClass =
  "absolute flex h-[22px] w-[25px] items-center justify-center rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 text-blue-800 hover:bg-[#CFE0F4]";

function CurrentAccountsReportForm({ title }: { title: string }) {
  const today = new Date();
  const month = String(today.getMonth() + 1).padStart(2, "0");
  const day = String(today.getDate()).padStart(2, "0");
  const [dateFrom, setDateFrom] = useState(`${today.getFullYear()}-${month}-01`);
  const [dateTo, setDateTo] = useState(`${today.getFullYear()}-${month}-${day}`);
  const [businessUnit, setBusinessUnit] = useState("(Todos)");
  const [area, setArea] = useState("(Todos)");
  const [costCenter, setCostCenter] = useState("(Todos)");
  const [allProviders, setAllProviders] = useState(true);
  const [provider, setProvider] = useState("(TODOS)");
  const [allCollaborators, setAllCollaborators] = useState(true);
  const [collaborator, setCollaborator] = useState("(TODOS)");
  const [accountFrom, setAccountFrom] = useState("");
  const [accountTo, setAccountTo] = useState("");

  return (
    <WindowShell title={title}>
      <div className="h-full min-h-0 overflow-auto bg-[#F3F3F3]">
        <div className="relative h-[383px] w-[506px] min-w-[506px] text-[12px] text-slate-900">
          <div className="absolute left-[9px] top-[5px] h-[334px] w-[489px] rounded-sm border border-blue-300">
            <fieldset className="absolute left-[9px] top-[6px] h-[54px] w-[470px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Rango de Fechas</legend>
              <label className={`${labelClass} left-[30px] top-[17px]`} htmlFor="current-accounts-date-from">
                Fechas Del :
              </label>
              <input
                id="current-accounts-date-from"
                aria-label="Fecha desde"
                type="date"
                value={dateFrom}
                onChange={(event) => setDateFrom(event.target.value)}
                className="absolute left-[119px] top-[13px] h-[21px] w-[94px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800"
              />
              <label className={`${labelClass} left-[277px] top-[16px]`} htmlFor="current-accounts-date-to">
                Al :
              </label>
              <input
                id="current-accounts-date-to"
                aria-label="Fecha hasta"
                type="date"
                value={dateTo}
                onChange={(event) => setDateTo(event.target.value)}
                className="absolute left-[309px] top-[12px] h-[21px] w-[94px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800"
              />
            </fieldset>

            <fieldset className="absolute left-[9px] top-[66px] h-[75px] w-[470px] rounded-sm border border-blue-400">
              <label className={`${labelClass} left-[9px] top-[16px]`} htmlFor="current-accounts-unit">
                Unidad de Negocio
              </label>
              <select
                id="current-accounts-unit"
                aria-label="Unidad de Negocio"
                value={businessUnit}
                onChange={(event) => {
                  setBusinessUnit(event.target.value);
                  setArea("(Todos)");
                  setCostCenter("(Todos)");
                }}
                className="absolute left-[124px] top-[10px] h-[21px] w-[120px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold"
              >
                <option>(Todos)</option>
              </select>
              <label className={`${labelClass} left-[270px] top-[16px]`} htmlFor="current-accounts-area">
                Area
              </label>
              <select
                id="current-accounts-area"
                aria-label="Area"
                value={area}
                onChange={(event) => {
                  setArea(event.target.value);
                  setCostCenter("(Todos)");
                }}
                className="absolute left-[304px] top-[10px] h-[21px] w-[156px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold"
              >
                <option>(Todos)</option>
              </select>
              <label className={`${labelClass} left-[9px] top-[43px]`} htmlFor="current-accounts-cost-center">
                Centro de Costo
              </label>
              <select
                id="current-accounts-cost-center"
                aria-label="Centro de Costo"
                value={costCenter}
                onChange={(event) => setCostCenter(event.target.value)}
                className="absolute left-[124px] top-[37px] h-[21px] w-[171px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold"
              >
                <option>(Todos)</option>
              </select>
            </fieldset>

            <fieldset className="absolute left-[9px] top-[147px] h-[54px] w-[470px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Proveedor</legend>
              <label className="absolute left-[187px] top-[-1px] flex cursor-pointer items-center gap-1 font-bold">
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
              <label className={`${labelClass} left-[23px] top-[24px]`} htmlFor="current-accounts-provider">
                Proveedor
              </label>
              <input
                id="current-accounts-provider"
                aria-label="Proveedor"
                value={provider}
                readOnly={allProviders}
                onChange={(event) => setProvider(event.target.value)}
                className={`${inputClass} left-[92px] top-[21px] w-[299px]`}
              />
              <button
                type="button"
                title="Buscar Proveedor"
                aria-label="Buscar Proveedor"
                onClick={() => {
                  setAllProviders(false);
                  setProvider("");
                  document.getElementById("current-accounts-provider")?.focus();
                }}
                className={`${searchButtonClass} left-[396px] top-[19px]`}
              >
                <Search size={15} />
              </button>
            </fieldset>

            <fieldset className="absolute left-[9px] top-[207px] h-[54px] w-[470px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Colaborador</legend>
              <label className="absolute left-[161px] top-[-1px] flex cursor-pointer items-center gap-1 font-bold">
                <input
                  aria-label="Todo Colaborador"
                  type="checkbox"
                  checked={allCollaborators}
                  onChange={(event) => {
                    setAllCollaborators(event.target.checked);
                    setCollaborator(event.target.checked ? "(TODOS)" : "");
                  }}
                  className="m-0 h-[13px] w-[13px] accent-[#0067b8]"
                />
                Todo Colaborador
              </label>
              <label className={`${labelClass} left-[13px] top-[24px]`} htmlFor="current-accounts-collaborator">
                Colaborador
              </label>
              <input
                id="current-accounts-collaborator"
                aria-label="Colaborador"
                value={collaborator}
                readOnly={allCollaborators}
                onChange={(event) => setCollaborator(event.target.value)}
                className={`${inputClass} left-[92px] top-[21px] w-[299px]`}
              />
              <button
                type="button"
                title="Buscar Colaborador"
                aria-label="Buscar Colaborador"
                onClick={() => {
                  setAllCollaborators(false);
                  setCollaborator("");
                  document.getElementById("current-accounts-collaborator")?.focus();
                }}
                className={`${searchButtonClass} left-[396px] top-[19px]`}
              >
                <Search size={15} />
              </button>
            </fieldset>

            <fieldset className="absolute left-[9px] top-[267px] h-[51px] w-[470px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Cuenta Contable</legend>
              <label className={`${labelClass} left-[45px] top-[20px]`} htmlFor="current-accounts-from">
                De :
              </label>
              <input
                id="current-accounts-from"
                aria-label="Cuenta contable desde"
                value={accountFrom}
                onChange={(event) => {
                  const value = event.target.value.toUpperCase();
                  setAccountFrom(value);
                  setAccountTo(value);
                }}
                className={`${inputClass} left-[86px] top-[17px] w-[62px] text-center uppercase`}
              />
              <button
                type="button"
                title="Buscar cuenta contable desde"
                aria-label="Buscar cuenta contable desde"
                onClick={() => document.getElementById("current-accounts-from")?.focus()}
                className={`${searchButtonClass} left-[150px] top-[16px]`}
              >
                <Search size={15} />
              </button>
              <label className={`${labelClass} left-[251px] top-[20px]`} htmlFor="current-accounts-to">
                Hasta :
              </label>
              <input
                id="current-accounts-to"
                aria-label="Cuenta contable hasta"
                value={accountTo}
                onChange={(event) => setAccountTo(event.target.value.toUpperCase())}
                className={`${inputClass} left-[315px] top-[17px] w-[62px] text-center uppercase`}
              />
              <button
                type="button"
                title="Buscar cuenta contable hasta"
                aria-label="Buscar cuenta contable hasta"
                onClick={() => document.getElementById("current-accounts-to")?.focus()}
                className={`${searchButtonClass} left-[379px] top-[16px]`}
              >
                <Search size={15} />
              </button>
            </fieldset>
          </div>

          <button
            type="button"
            className="absolute left-[172px] top-[347px] flex h-[27px] w-[78px] items-center justify-center gap-1 rounded-sm border border-slate-400 bg-white text-[12px] font-bold hover:bg-[#CFE0F4]"
          >
            <CheckCircle2 aria-hidden="true" size={16} className="text-green-600" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[256px] top-[347px] flex h-[27px] w-[78px] items-center justify-center gap-1 rounded-sm border border-slate-400 bg-white text-[12px] font-bold hover:bg-[#CFE0F4]"
          >
            <LogOut aria-hidden="true" size={15} className="text-blue-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}

export function CtasCtes({ title = "Reporte de Cuentas Corrientes" }: { title?: string }) {
  return <CtasCtesList title={title} />;
}

export function CtasCtesList({ title = "Reporte de Cuentas Corrientes" }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <CurrentAccountsReportForm title={title} />
    </div>
  );
}
