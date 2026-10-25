import { useState } from "react";
import { CheckCircle2, LogOut } from "lucide-react";
import {
  btn,
  btnPrimary,
  Fs,
  inp,
  WindowShell,
} from "@/components/ui/desktop-primitives";

type SummaryOption =
  | "compras-contabilidad"
  | "costo-ventas"
  | "transferencias-gratuita"
  | "transferencias-motores"
  | "movimientos";

const summaryOptions: { value: SummaryOption; label: string }[] = [
  { value: "compras-contabilidad", label: "1) Compras y Notas de Contabilidad" },
  { value: "costo-ventas", label: "2) Costo de Ventas" },
  { value: "transferencias-gratuita", label: "3) Transferencias y Venta Gratuita" },
  { value: "transferencias-motores", label: "4) Transferencias a Motores y Depart." },
  { value: "movimientos", label: "5) Mov. Resumen vs Mov. Detallado" },
];

const months = [
  "ENERO",
  "FEBRERO",
  "MARZO",
  "ABRIL",
  "MAYO",
  "JUNIO",
  "JULIO",
  "AGOSTO",
  "SETIEMBRE",
  "OCTUBRE",
  "NOVIEMBRE",
  "DICIEMBRE",
];

export function ResumenGeneralCostosReport({
  title = "Resumen General",
}: {
  title?: string;
}) {
  const [option, setOption] = useState<SummaryOption>("compras-contabilidad");

  return (
    <WindowShell title={title}>
      <div className="flex h-full items-start justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[305px] space-y-3">
          <Fs legend="Fechas" className="px-2 pb-2 pt-0">
            <div className="flex items-center justify-between gap-3">
              <label className="flex items-center gap-1.5">
                <span className="font-bold">Año</span>
                <input
                  aria-label="Año"
                  className={`${inp} h-6 w-[56px] px-1`}
                  type="number"
                  min="1900"
                  max="2200"
                  defaultValue={2026}
                />
              </label>
              <label className="flex items-center gap-1.5">
                <span className="font-bold">Mes</span>
                <select
                  aria-label="Mes"
                  className={`${inp} h-6 w-[110px] px-1`}
                  defaultValue="SETIEMBRE"
                >
                  {months.map((month) => (
                    <option key={month} value={month}>
                      {month}
                    </option>
                  ))}
                </select>
              </label>
            </div>
          </Fs>

          <Fs legend="Opciones" className="px-2 pb-2 pt-0">
            <div className="flex flex-col gap-2">
              {summaryOptions.map(({ value, label }) => (
                <label key={value} className="inline-flex items-center gap-1 font-bold">
                  <input
                    type="radio"
                    name="resumen-general-opcion"
                    checked={option === value}
                    onChange={() => setOption(value)}
                    className="accent-[#0874c9]"
                  />
                  {label}
                </label>
              ))}
            </div>
          </Fs>

          <div className="flex justify-center gap-3 pt-1">
            <button type="button" className={btnPrimary}>
              <CheckCircle2 className="h-4 w-4 text-green-300" />
              Aceptar
            </button>
            <button type="button" className={btn}>
              <LogOut className="h-4 w-4 text-slate-700" />
              Cancelar
            </button>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}