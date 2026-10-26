import { useState } from "react";
import { CheckCircle2, LogOut } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

export function MotoresADarDeBaja({
  title = "Reporte de Motores a Dar de Baja",
}: {
  title?: string;
}) {
  return <MotoresADarDeBajaList title={title} />;
}

export function MotoresADarDeBajaList({
  title = "Reporte de Motores a Dar de Baja",
}: {
  title?: string;
}) {
  const [location, setLocation] = useState("(Todos)");

  return (
    <WindowShell title={title}>
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[136px] w-[327px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <fieldset className="absolute left-[12px] top-[10px] h-[110px] w-[296px] border border-[#7799c5] px-0">
            <label className="absolute left-[33px] top-[29px] whitespace-nowrap font-bold">
              Ubicación
            </label>
            <select
              aria-label="Ubicación"
              value={location}
              onChange={(event) => setLocation(event.target.value)}
              className="absolute left-[103px] top-[25px] h-[20px] w-[131px] border border-[#7799c5] bg-white px-[3px] text-center text-[12px] font-bold"
            >
              <option>(Todos)</option>
            </select>

            <button
              type="button"
              className="absolute left-[51px] top-[66px] flex h-[27px] w-[76px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
            >
              <CheckCircle2 className="h-[16px] w-[16px] fill-green-600 text-white" />
              Aceptar
            </button>
            <button
              type="button"
              className="absolute left-[133px] top-[66px] flex h-[27px] w-[80px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
            >
              <LogOut className="h-[15px] w-[15px] text-gray-700" />
              Cancelar
            </button>
          </fieldset>
        </div>
      </div>
    </WindowShell>
  );
}
