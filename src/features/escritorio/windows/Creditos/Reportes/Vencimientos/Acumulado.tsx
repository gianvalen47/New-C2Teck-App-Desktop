import { useState } from "react";
import { CheckCircle2, LogOut } from "lucide-react";
import {
  btn,
  btnPrimary,
  Fs,
  inp,
  WindowShell,
} from "@/components/ui/desktop-primitives";

type AccountType = "todos" | "cuentas" | "provisiones" | "castigos";

export function Acumulado({
  title = "Reporte de Vencimientos Acumulado",
}: {
  title?: string;
}) {
  return <AcumuladoList title={title} />;
}

export function AcumuladoList({
  title = "Reporte de Vencimientos Acumulado",
}: {
  title?: string;
}) {
  const [tipoCuenta, setTipoCuenta] = useState<AccountType>("cuentas");

  const accountTypes: { value: AccountType; label: string }[] = [
    { value: "todos", label: "Todos" },
    { value: "cuentas", label: "Ctas Ctes" },
    { value: "provisiones", label: "Provisiones" },
    { value: "castigos", label: "Castigos" },
  ];

  return (
    <WindowShell title={title}>
      <div className="flex h-full items-start justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[390px] space-y-2">
          <div className="grid grid-cols-[minmax(0,1fr)_122px] items-start gap-3">
            <div className="space-y-2">
              <Fs legend="FECHAS" className="px-2 pb-2 pt-0">
                <div className="flex items-center justify-between gap-2">
                  <label className="flex items-center gap-1">
                    <span className="font-bold">Del :</span>
                    <input
                      aria-label="Fecha desde"
                      className={`${inp} h-6 w-[98px] px-1`}
                      type="date"
                      defaultValue="2026-10-24"
                    />
                  </label>
                  <label className="flex items-center gap-1">
                    <span className="font-bold">Al :</span>
                    <input
                      aria-label="Fecha hasta"
                      className={`${inp} h-6 w-[98px] px-1`}
                      type="date"
                      defaultValue="2026-10-26"
                    />
                  </label>
                </div>
              </Fs>

              <label className="grid gap-0.5 px-1">
                <span className="font-bold">Unidad Negocio:</span>
                <select className={`${inp} h-6 w-[160px] max-w-full px-1`} defaultValue="all">
                  <option value="all">(Todos)</option>
                </select>
              </label>

              <label className="grid gap-0.5 px-1">
                <span className="font-bold">Moneda:</span>
                <select className={`${inp} h-6 w-[145px] max-w-full px-1`} defaultValue="USD">
                  <option value="USD">USD</option>
                  <option value="PEN">PEN</option>
                </select>
              </label>

              <label className="grid gap-0.5 px-1">
                <span className="font-bold">Cobrador :</span>
                <select className={`${inp} h-6 w-full px-1`} defaultValue="all">
                  <option value="all">(Todos)</option>
                </select>
              </label>
            </div>

            <Fs legend="TIP CTA" className="mt-[78px] px-2 pb-2 pt-0">
              <div className="flex flex-col gap-1">
                {accountTypes.map(({ value, label }) => (
                  <label key={value} className="inline-flex items-center gap-1 font-bold">
                    <input
                      type="radio"
                      name="vencimientos-acumulado-tipo-cuenta"
                      checked={tipoCuenta === value}
                      onChange={() => setTipoCuenta(value)}
                      className="accent-[#0874c9]"
                    />
                    {label}
                  </label>
                ))}
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
