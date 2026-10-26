import { useState } from "react";
import { CheckCircle2, LogOut } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

export function HorasDeMotores({
  title = "Reporte de Horas Motor",
}: {
  title?: string;
}) {
  return <HorasDeMotoresList title={title} />;
}

export function HorasDeMotoresList({
  title = "Reporte de Horas Motor",
}: {
  title?: string;
}) {
  const [reportType, setReportType] = useState<"all" | "production">("all");
  const [location, setLocation] = useState("LIMA");

  const labelClass = "absolute whitespace-nowrap font-bold";

  return (
    <WindowShell title={title}>
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[185px] w-[256px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <fieldset className="absolute left-[21px] top-[12px] h-[51px] w-[213px] border border-[#7799c5] px-0">
            <legend className="mx-auto px-[3px] font-bold text-[#164b91]">Tipo</legend>
            <label className="absolute left-[13px] top-[18px] flex items-center gap-[5px] whitespace-nowrap font-bold">
              <input
                type="radio"
                name="engine-hours-type"
                checked={reportType === "all"}
                onChange={() => setReportType("all")}
                className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
              />
              Todos
            </label>
            <label className="absolute left-[95px] top-[18px] flex items-center gap-[5px] whitespace-nowrap font-bold">
              <input
                type="radio"
                name="engine-hours-type"
                checked={reportType === "production"}
                onChange={() => setReportType("production")}
                className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
              />
              En Producción
            </label>
          </fieldset>

          <fieldset className="absolute left-[12px] top-[72px] h-[50px] w-[232px] border border-[#7799c5] px-0">
            <label className={`${labelClass} left-[17px] top-[18px]`}>Ubicación</label>
            <select
              aria-label="Ubicación"
              value={location}
              onChange={(event) => setLocation(event.target.value)}
              className="absolute left-[87px] top-[13px] h-[20px] w-[152px] border border-[#7799c5] bg-[#0875c9] px-[3px] text-center text-[12px] font-bold text-white"
            >
              <option>LIMA</option>
              <option>(Todos)</option>
            </select>
          </fieldset>

          <button
            type="button"
            className="absolute left-[44px] top-[140px] flex h-[27px] w-[79px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <CheckCircle2 className="h-[16px] w-[16px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[137px] top-[140px] flex h-[27px] w-[79px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <LogOut className="h-[15px] w-[15px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
