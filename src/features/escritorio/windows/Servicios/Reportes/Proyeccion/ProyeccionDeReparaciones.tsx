import { useState } from "react";
import { CheckCircle2, LogOut } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

const CURRENT_YEAR = new Date().getFullYear();

export function ProyeccionDeReparaciones({
  title = "Reporte de Proyección de Reparaciones Anuales",
}: {
  title?: string;
}) {
  return <ProyeccionDeReparacionesList title={title} />;
}

export function ProyeccionDeReparacionesList({
  title = "Reporte de Proyección de Reparaciones Anuales",
}: {
  title?: string;
}) {
  const [year, setYear] = useState(CURRENT_YEAR);
  const [location, setLocation] = useState("LIMA");
  const [planType, setPlanType] = useState("(Todos)");
  const [excludeW3, setExcludeW3] = useState(false);
  const [pendingOnly, setPendingOnly] = useState(false);

  const labelClass = "absolute whitespace-nowrap font-bold";
  const selectClass =
    "absolute h-[20px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold";
  const checkboxClass = "m-0 h-[13px] w-[13px] accent-[#0875c9]";

  return (
    <WindowShell title={title}>
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[235px] w-[336px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <label className={`${labelClass} left-[103px] top-[25px]`}>Año :</label>
          <input
            aria-label="Año"
            type="number"
            min={2015}
            max={CURRENT_YEAR}
            value={year}
            onChange={(event) => {
              const value = Number(event.target.value);
              if (Number.isInteger(value) && value >= 2015 && value <= CURRENT_YEAR) {
                setYear(value);
              }
            }}
            className="absolute left-[148px] top-[23px] h-[20px] w-[64px] border border-[#7799c5] bg-white px-[2px] text-center font-bold"
          />

          <label className={`${labelClass} left-[70px] top-[63px]`}>
            Ubicación :
          </label>
          <select
            aria-label="Ubicación"
            value={location}
            onChange={(event) => setLocation(event.target.value)}
            className={`${selectClass} left-[148px] top-[59px] w-[109px] text-center`}
          >
            <option>LIMA</option>
          </select>

          <label className={`${labelClass} left-[26px] top-[99px]`}>
            Tipo Plan Mant. :
          </label>
          <select
            aria-label="Tipo Plan Mantenimiento"
            value={planType}
            onChange={(event) => setPlanType(event.target.value)}
            className={`${selectClass} left-[148px] top-[95px] w-[129px]`}
          >
            <option>(Todos)</option>
          </select>

          <label className="absolute left-[148px] top-[129px] flex items-center gap-[5px] whitespace-nowrap font-bold">
            <input
              aria-label="No incluir W3"
              type="checkbox"
              checked={excludeW3}
              onChange={(event) => setExcludeW3(event.target.checked)}
              className={checkboxClass}
            />
            No incluir W3
          </label>
          <label className="absolute left-[148px] top-[152px] flex items-center gap-[5px] whitespace-nowrap font-bold">
            <input
              aria-label="Mostrar solo pendientes"
              type="checkbox"
              checked={pendingOnly}
              onChange={(event) => setPendingOnly(event.target.checked)}
              className={checkboxClass}
            />
            Mostrar solo pendientes
          </label>

          <button
            type="button"
            className="absolute left-[84px] top-[194px] flex h-[27px] w-[76px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <CheckCircle2 className="h-[16px] w-[16px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[168px] top-[194px] flex h-[27px] w-[80px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <LogOut className="h-[15px] w-[15px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
