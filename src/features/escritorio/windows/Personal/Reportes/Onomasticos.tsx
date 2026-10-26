import { useState } from "react";
import { CheckCircle2, LogOut } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

const MONTHS = [
  "ENERO",
  "FEBRERO",
  "MARZO",
  "ABRIL",
  "MAYO",
  "JUNIO",
  "JULIO",
  "AGOSTO",
  "SEPTIEMBRE",
  "OCTUBRE",
  "NOVIEMBRE",
  "DICIEMBRE",
];

export function OnomasticosList() {
  return <Onomasticos />;
}

export function Onomasticos() {
  const [month, setMonth] = useState(String(new Date().getMonth() + 1));

  return (
    <WindowShell title="Reporte de Onomasticos">
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[149px] w-[248px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <fieldset className="absolute left-[49px] top-[25px] h-[50px] w-[150px] border border-[#7799c5] px-0">
            <label
              htmlFor="onomasticos-month"
              className="absolute left-[12px] top-[17px] whitespace-nowrap font-bold"
            >
              Mes
            </label>
            <select
              id="onomasticos-month"
              aria-label="Mes"
              value={month}
              onChange={(event) => setMonth(event.target.value)}
              className="absolute left-[48px] top-[17px] h-[20px] w-[89px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold text-[#164b91]"
            >
              {MONTHS.map((name, index) => (
                <option key={name} value={String(index + 1)}>
                  {name}
                </option>
              ))}
            </select>
          </fieldset>

          <button
            type="button"
            className="absolute left-[38px] top-[98px] flex h-[27px] w-[79px] items-center justify-center gap-[4px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <CheckCircle2 className="h-[17px] w-[17px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[131px] top-[98px] flex h-[27px] w-[79px] items-center justify-center gap-[4px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <LogOut className="h-[16px] w-[16px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
