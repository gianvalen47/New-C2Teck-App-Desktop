import { useState } from "react";
import { CheckCircle2, LogOut } from "lucide-react";
import {
  btn,
  btnPrimary,
  Fs,
  inp,
  WindowShell,
} from "@/components/ui/desktop-primitives";

type Choice = {
  value: string;
  label: string;
};

function RadioOptions({
  name,
  value,
  options,
  onChange,
  disabled = false,
}: {
  name: string;
  value: string;
  options: Choice[];
  onChange: (value: string) => void;
  disabled?: boolean;
}) {
  return (
    <div className={`flex flex-col gap-1 ${disabled ? "opacity-50" : ""}`}>
      {options.map((option) => (
        <label key={option.value} className="inline-flex items-center gap-1 font-bold">
          <input
            type="radio"
            name={name}
            checked={value === option.value}
            onChange={() => onChange(option.value)}
            disabled={disabled}
            className="accent-[#0874c9]"
          />
          {option.label}
        </label>
      ))}
    </div>
  );
}

export function StockValorizadoCostosReport({
  title = "Reporte de Stock Valorizado",
}: {
  title?: string;
}) {
  const [opcion, setOpcion] = useState("fecha");
  const [tipoReporte, setTipoReporte] = useState("detalle");
  const [tipoStock, setTipoStock] = useState("todos");
  const [agrupado, setAgrupado] = useState("rubro");
  const [impresionLibro, setImpresionLibro] = useState(false);

  return (
    <WindowShell title={title}>
      <div className="flex h-full items-start justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="grid w-full max-w-[510px] grid-cols-[126px_minmax(0,1fr)_126px] items-start gap-2">
          <div className="space-y-2">
            <Fs legend="Opciones" className="px-2 pb-2 pt-0">
              <RadioOptions
                name="stock-valorizado-opciones"
                value={opcion}
                options={[
                  { value: "fecha", label: "Stock a la Fecha" },
                  { value: "inicio", label: "Saldos de Inicio" },
                  { value: "actual", label: "Stock Actual" },
                ]}
                onChange={setOpcion}
              />
            </Fs>

            <Fs legend="Tipo Reporte" className="px-2 pb-2 pt-0">
              <RadioOptions
                name="stock-valorizado-tipo-reporte"
                value={tipoReporte}
                options={[
                  { value: "detalle", label: "Detalle" },
                  { value: "total", label: "Total General" },
                  { value: "resumen", label: "Resumen" },
                  { value: "indicador", label: "Indicador" },
                ]}
                onChange={setTipoReporte}
              />
            </Fs>

            <Fs legend="Exportar" className="px-2 pb-2 pt-0 opacity-50">
              <RadioOptions
                name="stock-valorizado-exportar"
                value="pantalla"
                options={[{ value: "pantalla", label: "Pantalla" }]}
                onChange={() => undefined}
                disabled
              />
            </Fs>
          </div>

          <div className="space-y-2">
            <Fs legend="Almacenes" className="px-2 pb-2 pt-0">
              <label className="grid grid-cols-[52px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold">Oficina :</span>
                <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                  <option value="all">(Todos)</option>
                </select>
              </label>
              <label className="grid grid-cols-[52px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold">Almacén :</span>
                <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                  <option value="all">(Todos)</option>
                </select>
              </label>
            </Fs>

            <label className="grid grid-cols-[82px_minmax(0,1fr)] items-center gap-1 px-1">
              <span className="font-bold">A la Fecha :</span>
              <input
                aria-label="A la fecha"
                className={`${inp} h-6 min-w-0 px-1`}
                type="date"
                defaultValue="2026-10-24"
                disabled={opcion !== "fecha"}
              />
            </label>

            <label className="flex items-center gap-1 px-3 font-bold">
              <input
                type="checkbox"
                checked={impresionLibro}
                onChange={(event) => setImpresionLibro(event.target.checked)}
                className="accent-[#0874c9]"
              />
              Impresion para el Libro
            </label>

            <label className="grid grid-cols-[64px_minmax(0,1fr)] items-center gap-1 px-1">
              <span className="font-bold">Rubro :</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>

            <label className="grid grid-cols-[82px_minmax(0,1fr)] items-center gap-1 px-1">
              <span className="font-bold">Movimiento :</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>
          </div>

          <div className="space-y-2">
            <Fs legend="Tipo Stock" className="px-2 pb-2 pt-0">
              <RadioOptions
                name="stock-valorizado-tipo-stock"
                value={tipoStock}
                options={[
                  { value: "todos", label: "Todos" },
                  { value: "sin-ceros", label: "Todos sin Ceros" },
                  { value: "positivos", label: "Positivos" },
                  { value: "negativos", label: "Negativos" },
                  { value: "ceros", label: "Con Ceros" },
                ]}
                onChange={setTipoStock}
              />
            </Fs>

            <Fs legend="Agrupado por:" className="px-2 pb-2 pt-0">
              <RadioOptions
                name="stock-valorizado-agrupado"
                value={agrupado}
                options={[
                  { value: "rubro", label: "Por Rubros" },
                  { value: "clase", label: "Por Clase" },
                  { value: "marca", label: "Por Marca" },
                  { value: "proveedor", label: "Por Proveedor" },
                ]}
                onChange={setAgrupado}
              />
            </Fs>
          </div>

          <div className="col-span-3 flex justify-center gap-2 pt-2">
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
