import { useState } from "react";
import { WindowShell } from "@/components/ui/desktop-primitives";

type RadioOptionProps = {
  name: string;
  label: string;
  checked: boolean;
  disabled?: boolean;
  left: number;
  top: number;
  onChange: () => void;
};

function RadioOption({
  name,
  label,
  checked,
  disabled = false,
  left,
  top,
  onChange,
}: RadioOptionProps) {
  return (
    <label
      className={`absolute flex h-[17px] items-center gap-[4px] whitespace-nowrap text-[11px] font-bold leading-[17px] ${
        disabled ? "text-gray-400" : "text-gray-900"
      }`}
      style={{ left, top }}
    >
      <input
        type="radio"
        name={name}
        checked={checked}
        disabled={disabled}
        onChange={onChange}
        className="m-0 h-[13px] w-[13px] accent-[#1769aa]"
      />
      {label}
    </label>
  );
}

type GroupBoxProps = {
  title?: string;
  left: number;
  top: number;
  width: number;
  height: number;
  disabled?: boolean;
  children: React.ReactNode;
};

function GroupBox({
  title,
  left,
  top,
  width,
  height,
  disabled = false,
  children,
}: GroupBoxProps) {
  return (
    <div
      role="group"
      aria-label={title}
      className={`absolute border border-[#9aa5b1] bg-[#F8FBFF] ${
        disabled ? "opacity-55" : ""
      }`}
      style={{ left, top, width, height }}
    >
      {title && (
        <span className="absolute -top-[8px] left-[8px] bg-[#F8FBFF] px-[3px] text-[11px] font-bold leading-[15px] text-gray-900">
          {title}
        </span>
      )}
      {children}
    </div>
  );
}

function SelectField({
  left,
  top,
  width,
  disabled = false,
}: {
  left: number;
  top: number;
  width: number;
  disabled?: boolean;
}) {
  return (
    <select
      aria-label="Tipo de Trabajo"
      disabled={disabled}
      defaultValue=""
      className="absolute h-[20px] rounded-[2px] border border-[#9ba9b8] bg-white px-[4px] text-[11px] font-bold text-gray-900 disabled:bg-[#e8edf2]"
      style={{ left, top, width }}
    >
      <option value="" />
    </select>
  );
}

export function IndicadoresUsuario() {
  const today = new Date();
  const todayValue = `${today.getFullYear()}-${String(today.getMonth() + 1).padStart(2, "0")}-${String(today.getDate()).padStart(2, "0")}`;
  const [startDate, setStartDate] = useState(`${today.getFullYear()}-01-01`);
  const [endDate, setEndDate] = useState(todayValue);
  const [mode, setMode] = useState<"requests" | "duration" | "person">("requests");
  const [requestFilter, setRequestFilter] = useState("group");
  const [applicantFilter, setApplicantFilter] = useState("");
  const [rankingFilter, setRankingFilter] = useState("");
  const [durationUnit, setDurationUnit] = useState("");

  return (
    <WindowShell title="Indicadores de Usuario">
      <div className="relative h-[495px] w-[633px] overflow-hidden bg-[#F8FBFF] font-[Arial,sans-serif]">
        <label className="absolute left-[160px] top-[28px] text-[11px] font-bold text-gray-900">
          Del :
        </label>
        <input
          aria-label="Fecha de inicio"
          type="date"
          value={startDate}
          onChange={(event) => setStartDate(event.target.value)}
          className="absolute left-[204px] top-[26px] h-[20px] w-[97px] border border-[#9ba9b8] bg-white px-[2px] text-[11px] font-bold text-gray-900"
        />
        <label className="absolute left-[329px] top-[27px] text-[11px] font-bold text-gray-900">
          Al :
        </label>
        <input
          aria-label="Fecha final"
          type="date"
          value={endDate}
          onChange={(event) => setEndDate(event.target.value)}
          className="absolute left-[361px] top-[26px] h-[20px] w-[94px] border border-[#9ba9b8] bg-white px-[2px] text-[11px] font-bold text-gray-900"
        />

        <GroupBox left={54} top={56} width={525} height={54}>
          <RadioOption
            name="indicator-mode"
            label="Por Numero de Solicitudes"
            left={9}
            top={22}
            checked={mode === "requests"}
            onChange={() => setMode("requests")}
          />
          <RadioOption
            name="indicator-mode"
            label="Por Duración de Atención"
            left={205}
            top={22}
            checked={mode === "duration"}
            onChange={() => setMode("duration")}
          />
          <RadioOption
            name="indicator-mode"
            label="Por Personal"
            left={404}
            top={22}
            checked={mode === "person"}
            onChange={() => setMode("person")}
          />
        </GroupBox>

        <GroupBox
          title="Por Numero de Solicitudes"
          left={11}
          top={118}
          width={255}
          height={365}
          disabled={mode !== "requests"}
        >
          <RadioOption name="request-filter" label="Por Grupo" left={16} top={19} checked={requestFilter === "group"} disabled={mode !== "requests"} onChange={() => setRequestFilter("group")} />
          <RadioOption name="request-filter" label="Por Estado" left={16} top={42} checked={requestFilter === "status"} disabled={mode !== "requests"} onChange={() => setRequestFilter("status")} />
          <RadioOption name="request-filter" label="Por Tipo de Trabajo" left={16} top={65} checked={requestFilter === "work"} disabled={mode !== "requests"} onChange={() => setRequestFilter("work")} />
          <RadioOption name="request-filter" label="Por Solicitante" left={16} top={89} checked={requestFilter === "applicant"} disabled={mode !== "requests"} onChange={() => setRequestFilter("applicant")} />

          <GroupBox
            left={33}
            top={105}
            width={209}
            height={111}
            disabled={mode !== "requests" || requestFilter !== "applicant"}
          >
            <RadioOption name="applicant-filter" label="Por Cantidad de Solicitudes" left={10} top={14} checked={applicantFilter === "quantity"} disabled={mode !== "requests" || requestFilter !== "applicant"} onChange={() => setApplicantFilter("quantity")} />
            <RadioOption name="applicant-filter" label="Tipo de Trabajo" left={10} top={37} checked={applicantFilter === "work"} disabled={mode !== "requests" || requestFilter !== "applicant"} onChange={() => setApplicantFilter("work")} />
            <RadioOption name="applicant-filter" label="Tipo de Problema" left={10} top={60} checked={applicantFilter === "problem"} disabled={mode !== "requests" || requestFilter !== "applicant"} onChange={() => setApplicantFilter("problem")} />
            <SelectField left={30} top={82} width={164} disabled={mode !== "requests" || requestFilter !== "applicant"} />
          </GroupBox>

          <RadioOption name="request-filter" label="Por Tipo de Problema" left={16} top={223} checked={requestFilter === "problem"} disabled={mode !== "requests"} onChange={() => setRequestFilter("problem")} />
          <SelectField left={38} top={246} width={164} disabled={mode !== "requests"} />
          <RadioOption name="request-filter" label="Por Ranking" left={16} top={275} checked={requestFilter === "ranking"} disabled={mode !== "requests"} onChange={() => setRequestFilter("ranking")} />

          <GroupBox
            left={32}
            top={291}
            width={128}
            height={63}
            disabled={mode !== "requests" || requestFilter !== "ranking"}
          >
            <RadioOption name="ranking-filter" label="Solicitante" left={10} top={14} checked={rankingFilter === "applicant"} disabled={mode !== "requests" || requestFilter !== "ranking"} onChange={() => setRankingFilter("applicant")} />
            <RadioOption name="ranking-filter" label="Tipo de Trabajo" left={10} top={37} checked={rankingFilter === "work"} disabled={mode !== "requests" || requestFilter !== "ranking"} onChange={() => setRankingFilter("work")} />
          </GroupBox>
        </GroupBox>

        <GroupBox
          title="Por Duración de Atención"
          left={280}
          top={118}
          width={341}
          height={106}
          disabled={mode !== "duration"}
        >
          <label className="absolute left-[29px] top-[34px] text-[11px] font-bold text-gray-900">
            Tipo de Trabajo :
          </label>
          <SelectField left={144} top={30} width={164} disabled={mode !== "duration"} />
          <RadioOption name="duration-unit" label="Minutos" left={47} top={71} checked={durationUnit === "minutes"} disabled={mode !== "duration"} onChange={() => setDurationUnit("minutes")} />
          <RadioOption name="duration-unit" label="Horas" left={144} top={71} checked={durationUnit === "hours"} disabled={mode !== "duration"} onChange={() => setDurationUnit("hours")} />
          <RadioOption name="duration-unit" label="Dias" left={234} top={71} checked={durationUnit === "days"} disabled={mode !== "duration"} onChange={() => setDurationUnit("days")} />
        </GroupBox>

        <GroupBox
          title="Por Personal"
          left={280}
          top={230}
          width={341}
          height={63}
          disabled={mode !== "person"}
        >
          <label className="absolute left-[29px] top-[32px] text-[11px] font-bold text-gray-900">
            Tipo de Trabajo :
          </label>
          <SelectField left={144} top={28} width={164} disabled={mode !== "person"} />
        </GroupBox>

        <button
          type="button"
          className="absolute left-[374px] top-[320px] h-[23px] w-[74px] rounded-[2px] border border-[#7d8b99] bg-gradient-to-b from-white to-[#e7edf3] px-[6px] text-[11px] font-bold text-gray-900 shadow-sm hover:from-[#f7fbff] hover:to-[#dbe7f2]"
        >
          Aceptar
        </button>
        <button
          type="button"
          className="absolute left-[456px] top-[320px] h-[23px] w-[80px] rounded-[2px] border border-[#7d8b99] bg-gradient-to-b from-white to-[#e7edf3] px-[6px] text-[11px] font-bold text-gray-900 shadow-sm hover:from-[#f7fbff] hover:to-[#dbe7f2]"
        >
          Cancelar
        </button>
      </div>
    </WindowShell>
  );
}
