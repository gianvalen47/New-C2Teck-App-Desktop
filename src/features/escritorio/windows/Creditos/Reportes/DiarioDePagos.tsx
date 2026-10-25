import { useState } from "react";
import { CheckCircle2, LogOut, Search } from "lucide-react";
import {
  btn,
  btnPrimary,
  Fs,
  iconBtn,
  inp,
  WindowShell,
} from "@/components/ui/desktop-primitives";

export function ReporteDiario({ title = "Reporte Diario de Pagos" }: { title?: string }) {
  return <ReporteDiarioList title={title} />;
}

export function ReporteDiarioList({
  title = "Reporte Diario de Pagos",
}: {
  title?: string;
}) {
  const [todosClientes, setTodosClientes] = useState(true);
  const [tipoCuenta, setTipoCuenta] = useState("cuentas");
  const [exportar, setExportar] = useState("pantalla");
  const [pagosEfectivo, setPagosEfectivo] = useState(true);
  const [mantenerDolares, setMantenerDolares] = useState(true);

  return (
    <WindowShell title={title}>
      <div className="flex h-full items-start justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[465px] space-y-2">
          <Fs legend="FECHAS DE PAGO" className="px-2 pb-2 pt-0">
            <div className="flex items-center justify-center gap-8">
              <label className="flex items-center gap-1.5">
                <span className="font-bold">Del :</span>
                <input
                  aria-label="Fecha desde"
                  className={`${inp} h-6 w-[98px] px-1`}
                  type="date"
                  defaultValue="2026-10-01"
                />
              </label>
              <label className="flex items-center gap-1.5">
                <span className="font-bold">Al :</span>
                <input
                  aria-label="Fecha hasta"
                  className={`${inp} h-6 w-[98px] px-1`}
                  type="date"
                  defaultValue="2026-10-24"
                />
              </label>
            </div>
          </Fs>

          <Fs legend="UNIDAD DE NEGOCIO" className="px-2 pb-2 pt-0">
            <label className="flex items-center justify-center gap-2">
              <span className="font-bold">Unidad de Negocio</span>
              <select className={`${inp} h-6 w-[145px] px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>
          </Fs>

          <Fs legend="CLIENTE" className="px-2 pb-2 pt-0">
            <label className="flex items-center justify-center gap-1.5 font-bold">
              <input
                type="checkbox"
                checked={todosClientes}
                onChange={(event) => setTodosClientes(event.target.checked)}
                className="accent-[#0874c9]"
              />
              Todos
            </label>
            <div className="grid grid-cols-[54px_minmax(0,1fr)_26px] items-center gap-1">
              <span className={`text-center font-bold ${todosClientes ? "text-slate-400" : ""}`}>
                Cliente
              </span>
              <input
                aria-label="Cliente"
                className={`${inp} h-6 min-w-0 px-1`}
                disabled={todosClientes}
              />
              <button
                type="button"
                className={`${iconBtn} border border-slate-400/70`}
                aria-label="Buscar cliente"
                disabled={todosClientes}
              >
                <Search className="h-4 w-4" />
              </button>
            </div>
          </Fs>

          <div className="grid grid-cols-[125px_minmax(0,1fr)] items-start gap-3">
            <div className="space-y-2">
              <Fs legend="TIP CTA" className="px-2 pb-2 pt-0">
                <div className="flex flex-col gap-1">
                  {[
                    ["cuentas", "Ctas. Ctes."],
                    ["provisiones", "Provisiones"],
                    ["castigos", "Castigos"],
                  ].map(([value, label]) => (
                    <label key={value} className="inline-flex items-center gap-1 font-bold">
                      <input
                        type="radio"
                        name="diario-pagos-tipo-cuenta"
                        checked={tipoCuenta === value}
                        onChange={() => setTipoCuenta(value)}
                        className="accent-[#0874c9]"
                      />
                      {label}
                    </label>
                  ))}
                </div>
              </Fs>

              <Fs legend="EXPORTAR" className="px-2 pb-2 pt-0">
                <div className="flex flex-col gap-1">
                  {[
                    ["pantalla", "Pantalla"],
                    ["excel", "Excel"],
                  ].map(([value, label]) => (
                    <label key={value} className="inline-flex items-center gap-1 font-bold">
                      <input
                        type="radio"
                        name="diario-pagos-exportar"
                        checked={exportar === value}
                        onChange={() => setExportar(value)}
                        className="accent-[#0874c9]"
                      />
                      {label}
                    </label>
                  ))}
                </div>
              </Fs>
            </div>

            <div className="space-y-2">
              <Fs legend="FORMA DE PAGO" className="px-2 pb-2 pt-0">
                <label className="flex items-center justify-center gap-1.5 font-bold">
                  <input
                    type="checkbox"
                    checked={pagosEfectivo}
                    onChange={(event) => setPagosEfectivo(event.target.checked)}
                    className="accent-[#0874c9]"
                  />
                  Pagos Efectivo
                </label>
                <select
                  aria-label="Forma de pago"
                  className={`${inp} ml-5 h-6 w-[calc(100%-28px)] px-1`}
                  defaultValue="all"
                  disabled={!pagosEfectivo}
                >
                  <option value="all">(Todos)</option>
                </select>
              </Fs>

              <Fs legend="MONEDA" className="px-2 pb-2 pt-0">
                <label className="flex items-center justify-center gap-1.5 font-bold">
                  <input
                    type="checkbox"
                    checked={mantenerDolares}
                    onChange={(event) => setMantenerDolares(event.target.checked)}
                    className="accent-[#0874c9]"
                  />
                  Mantener Moneda Dolares
                </label>
              </Fs>

              <Fs legend="Datos de Búsqueda" className="px-2 pb-2 pt-0">
                <label className="grid grid-cols-[88px_minmax(0,1fr)] items-center gap-1">
                  <span className="font-bold">Documentos</span>
                  <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                    <option value="all">(Todos)</option>
                  </select>
                </label>
                <label className="grid grid-cols-[58px_minmax(0,1fr)] items-center gap-1">
                  <span className="font-bold">Banco</span>
                  <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                    <option value="all">(Todos)</option>
                  </select>
                </label>
              </Fs>
            </div>
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
