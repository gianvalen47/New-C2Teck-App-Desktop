import { useState } from "react";
import { CheckCircle2, LogOut } from "lucide-react";
import {
  btn,
  btnPrimary,
  Fs,
  inp,
  WindowShell,
} from "@/components/ui/desktop-primitives";

type SaldoType = "final" | "cuentas";
type DetailType = "resumen" | "detallado";

export function CondensadosCostosReport({
  title = "Reporte de Condensados",
}: {
  title?: string;
}) {
  const [saldoType, setSaldoType] = useState<SaldoType>("final");
  const [detailType, setDetailType] = useState<DetailType>("resumen");

  return (
    <WindowShell title={title}>
      <div className="flex h-full items-start justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[310px] space-y-2">
          <div className="flex items-center justify-between gap-3 px-1">
            <label className="flex items-center gap-1.5">
              <span className="font-bold">Del :</span>
              <input
                aria-label="Fecha desde"
                className={`${inp} h-6 w-[98px] px-1`}
                type="date"
                defaultValue="2026-09-01"
              />
            </label>
            <label className="flex items-center gap-1.5">
              <span className="font-bold">Al :</span>
              <input
                aria-label="Fecha hasta"
                className={`${inp} h-6 w-[98px] px-1`}
                type="date"
                defaultValue="2026-09-30"
              />
            </label>
          </div>

          <div className="grid grid-cols-[minmax(0,1fr)_112px] items-center gap-3">
            <div className="flex flex-col gap-2">
              <label className="inline-flex items-center gap-1 font-bold">
                <input
                  type="radio"
                  name="condensados-saldo"
                  checked={saldoType === "final"}
                  onChange={() => setSaldoType("final")}
                  className="accent-[#0874c9]"
                />
                Saldo Final
              </label>
              <label className="inline-flex items-center gap-1 font-bold">
                <input
                  type="radio"
                  name="condensados-saldo"
                  checked={saldoType === "cuentas"}
                  onChange={() => setSaldoType("cuentas")}
                  className="accent-[#0874c9]"
                />
                Saldo Final por Cuentas
              </label>
            </div>

            <Fs legend="" className="px-2 pb-2 pt-0">
              <div className="flex flex-col gap-1">
                <label className="inline-flex items-center gap-1">
                  <input
                    type="radio"
                    name="condensados-detalle"
                    checked={detailType === "resumen"}
                    onChange={() => setDetailType("resumen")}
                    className="accent-[#0874c9]"
                  />
                  Resumen
                </label>
                <label className="inline-flex items-center gap-1">
                  <input
                    type="radio"
                    name="condensados-detalle"
                    checked={detailType === "detallado"}
                    onChange={() => setDetailType("detallado")}
                    className="accent-[#0874c9]"
                  />
                  Detallado
                </label>
              </div>
            </Fs>
          </div>

          <div className="flex justify-center gap-2 pt-1">
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