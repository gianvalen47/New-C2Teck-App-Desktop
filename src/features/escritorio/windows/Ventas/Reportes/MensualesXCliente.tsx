import { useState } from "react";
import {
  btn,
  btnPrimary,
  Fs,
  inp,
  Radio,
  WindowShell,
} from "@/components/ui/desktop-primitives";

export function ReporteMensualClienteList() {
  const [todoVendedor, setTodoVendedor] = useState(true);

  return (
    <WindowShell title="Reporte de Ventas Mensuales por Cliente">
      <div className="flex h-full items-center justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[460px] space-y-2 px-1 py-1">
          <div className="flex items-center justify-center gap-5">
            <span className="font-bold">Fechas</span>
            <label className="flex items-center gap-1.5">
              <span className="font-bold">Del :</span>
              <input
                aria-label="Fecha desde"
                className={`${inp} h-6 w-[100px] px-1`}
                type="date"
                defaultValue="2026-10-01"
              />
            </label>
            <label className="flex items-center gap-1.5">
              <span className="font-bold">Al</span>
              <input
                aria-label="Fecha hasta"
                className={`${inp} h-6 w-[100px] px-1`}
                type="date"
                defaultValue="2026-10-15"
              />
            </label>
          </div>

          <div className="grid grid-cols-[1.3fr_0.85fr] items-center gap-3">
            <div className="space-y-1">
              <label className="grid grid-cols-[80px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold">Oficina:</span>
                <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                  <option value="all">(Todos)</option>
                </select>
              </label>
              <label className="grid grid-cols-[80px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold">Almacén:</span>
                <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                  <option value="all">(Todos)</option>
                </select>
              </label>
              <label className="grid grid-cols-[80px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold">Rubro:</span>
                <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                  <option value="all">(Todos)</option>
                </select>
              </label>
            </div>

            <Fs legend="Reporte" className="px-2 pb-1 pt-0">
              <div className="flex justify-center gap-3">
                <Radio
                  name="reporte-mensual-cliente-tipo"
                  label="Detalle"
                  defaultChecked
                />
                <Radio name="reporte-mensual-cliente-tipo" label="Resumen" />
              </div>
            </Fs>
          </div>

          <Fs legend="Buscar Por Vendedor" className="px-2 pb-1 pt-0">
            <label className="flex items-center gap-1.5 font-bold">
              <input
                type="checkbox"
                checked={todoVendedor}
                onChange={(event) => setTodoVendedor(event.target.checked)}
                className="accent-[#2A5590]"
              />
              Todo Vendedor
            </label>
            <label className="grid grid-cols-[76px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Vendedor:</span>
              <select
                className={`${inp} h-6 min-w-0 px-1`}
                defaultValue="all"
                disabled={todoVendedor}
              >
                <option value="all">(Todos)</option>
              </select>
            </label>
          </Fs>

          <label className="grid max-w-[260px] grid-cols-[64px_minmax(0,1fr)] items-center gap-1">
            <span className="font-bold">Sector:</span>
            <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
              <option value="all">(Todos)</option>
            </select>
          </label>

          <div className="grid grid-cols-3 gap-2">
            <Fs legend="Ordenado X" className="px-2 pb-1 pt-0">
              <div className="flex flex-col gap-0.5">
                <Radio
                  name="reporte-mensual-cliente-ordenado"
                  label="Cliente"
                  defaultChecked
                />
                <Radio
                  name="reporte-mensual-cliente-ordenado"
                  label="Total Venta"
                />
              </div>
            </Fs>
            <Fs legend="Tipo de Orden" className="px-2 pb-1 pt-0">
              <div className="flex flex-col gap-0.5">
                <Radio
                  name="reporte-mensual-cliente-direccion"
                  label="Ascendente"
                  defaultChecked
                />
                <Radio
                  name="reporte-mensual-cliente-direccion"
                  label="Descendente"
                />
              </div>
            </Fs>
            <Fs legend="Moneda" className="px-2 pb-1 pt-0">
              <div className="flex flex-col gap-0.5">
                <Radio
                  name="reporte-mensual-cliente-moneda"
                  label="En Soles"
                  defaultChecked
                />
                <Radio
                  name="reporte-mensual-cliente-moneda"
                  label="En Dólares"
                />
              </div>
            </Fs>
          </div>

          <div className="flex justify-center gap-2 pt-1">
            <button type="button" className={btnPrimary}>
              Aceptar
            </button>
            <button type="button" className={btn}>
              Cancelar
            </button>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}

export function ReporteMensualCliente() {
  return <ReporteMensualClienteList />;
}
