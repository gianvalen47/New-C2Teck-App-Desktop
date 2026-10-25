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

type RadioOption = {
  value: string;
  label: string;
};

function RadioGroup({
  name,
  value,
  options,
  onChange,
}: {
  name: string;
  value: string;
  options: RadioOption[];
  onChange: (value: string) => void;
}) {
  return (
    <div className="flex flex-col gap-1">
      {options.map((option) => (
        <label key={option.value} className="inline-flex items-center gap-1 font-bold">
          <input
            type="radio"
            name={name}
            checked={value === option.value}
            onChange={() => onChange(option.value)}
            className="accent-[#0874c9]"
          />
          {option.label}
        </label>
      ))}
    </div>
  );
}

export function Detalle({
  title = "Reporte de Vencimientos",
}: {
  title?: string;
}) {
  return <DetalleList title={title} />;
}

export function DetalleList({
  title = "Reporte de Vencimientos",
}: {
  title?: string;
}) {
  const [tipoCuenta, setTipoCuenta] = useState("cuentas");
  const [todosCobradores, setTodosCobradores] = useState(true);
  const [todosClientes, setTodosClientes] = useState(true);
  const [ordenado, setOrdenado] = useState("documento");
  const [orden, setOrden] = useState("ascendente");
  const [condicion, setCondicion] = useState("pendientes");

  return (
    <WindowShell title={title}>
      <div className="flex h-full items-start justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[455px] space-y-1.5">
          <div className="grid grid-cols-[minmax(0,1fr)_122px] items-start gap-2">
            <div className="space-y-1.5">
              <Fs legend="FECHAS" className="px-2 pb-2 pt-0">
                <div className="flex items-center justify-between gap-2">
                  <label className="flex items-center gap-1">
                    <span className="font-bold">Del :</span>
                    <input
                      aria-label="Fecha desde"
                      className={`${inp} h-6 w-[98px] px-1`}
                      type="date"
                      defaultValue="2026-10-01"
                    />
                  </label>
                  <label className="flex items-center gap-1">
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

              <label className="grid gap-0.5 px-1">
                <span className="font-bold">Unidad Negocio:</span>
                <select className={`${inp} h-6 w-[160px] max-w-full px-1`} defaultValue="all">
                  <option value="all">(Todos)</option>
                </select>
              </label>

              <label className="grid gap-0.5 px-1">
                <span className="font-bold">Documentos:</span>
                <select className={`${inp} h-6 w-[190px] max-w-full px-1`} defaultValue="all">
                  <option value="all">(Todos)</option>
                </select>
              </label>
            </div>

            <Fs legend="TIP CTA" className="mt-1 px-2 pb-2 pt-0">
              <RadioGroup
                name="vencimientos-tipo-cuenta"
                value={tipoCuenta}
                options={[
                  { value: "todos", label: "Todos" },
                  { value: "cuentas", label: "Ctas Ctes" },
                  { value: "provisiones", label: "Provisiones" },
                  { value: "castigos", label: "Castigos" },
                ]}
                onChange={setTipoCuenta}
              />
            </Fs>
          </div>

          <Fs legend="COBRADOR" className="px-2 pb-2 pt-0">
            <label className="flex items-center justify-center gap-1.5 font-bold">
              <input
                type="checkbox"
                checked={todosCobradores}
                onChange={(event) => setTodosCobradores(event.target.checked)}
                className="accent-[#0874c9]"
              />
              Todos
            </label>
            <label className="grid grid-cols-[72px_minmax(0,1fr)] items-center gap-1">
              <span className={`font-bold ${todosCobradores ? "text-slate-400" : ""}`}>
                Cobrador :
              </span>
              <select
                aria-label="Cobrador"
                className={`${inp} h-6 min-w-0 px-1`}
                defaultValue="all"
                disabled={todosCobradores}
              >
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
              <span className={`font-bold ${todosClientes ? "text-slate-400" : ""}`}>
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

          <div className="grid grid-cols-[minmax(0,1fr)_112px] items-start gap-2">
            <Fs legend="ORDENAMIENTO" className="px-2 pb-2 pt-0">
              <div className="grid grid-cols-[minmax(0,1fr)_minmax(0,1fr)] gap-2">
                <RadioGroup
                  name="vencimientos-ordenado"
                  value={ordenado}
                  options={[
                    { value: "documento", label: "Por Documento" },
                    { value: "fecha", label: "Por Fecha Vencimiento" },
                  ]}
                  onChange={setOrdenado}
                />
                <RadioGroup
                  name="vencimientos-orden"
                  value={orden}
                  options={[
                    { value: "ascendente", label: "Ascendente" },
                    { value: "descendente", label: "Descendente" },
                  ]}
                  onChange={setOrden}
                />
              </div>
            </Fs>

            <Fs legend="CONDICION" className="px-2 pb-2 pt-0">
              <RadioGroup
                name="vencimientos-condicion"
                value={condicion}
                options={[
                  { value: "pendientes", label: "Pendientes" },
                  { value: "todos", label: "Todos" },
                ]}
                onChange={setCondicion}
              />
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
