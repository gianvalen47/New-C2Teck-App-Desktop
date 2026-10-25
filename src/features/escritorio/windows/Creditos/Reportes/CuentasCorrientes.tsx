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
  disabled = false,
}: {
  name: string;
  value: string;
  options: RadioOption[];
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

export function CuentasCorrientes({
  title = "Reporte de Cuentas Corrientes",
}: {
  title?: string;
}) {
  return <CuentasCorrientesList title={title} />;
}

export function CuentasCorrientesList({
  title = "Reporte de Cuentas Corrientes",
}: {
  title?: string;
}) {
  const [todosClientes, setTodosClientes] = useState(true);
  const [todosCobradores, setTodosCobradores] = useState(true);
  const [documentoTipo, setDocumentoTipo] = useState("clientes");
  const [documentoOrigen, setDocumentoOrigen] = useState("");
  const [documentos, setDocumentos] = useState("all");
  const [tipoCuenta, setTipoCuenta] = useState("cuentas");
  const [condicion, setCondicion] = useState("pendientes");
  const [tipo, setTipo] = useState("detallado");
  const [exportar, setExportar] = useState("pantalla");
  const [moneda, setMoneda] = useState("USD");
  const [mantenerMonedaEmision, setMantenerMonedaEmision] = useState(false);
  const [ordenadoX, setOrdenadoX] = useState("total");
  const [orden, setOrden] = useState("descendente");

  return (
    <WindowShell title={title}>
      <div className="flex h-full items-start justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[590px] space-y-1.5">
          <div className="grid grid-cols-[minmax(0,1fr)_160px] gap-2">
            <div className="space-y-1.5">
              <Fs legend="FECHAS" className="px-2 pb-2 pt-0">
                <div className="flex items-center justify-between gap-3 px-4">
                  <label className="flex items-center gap-1.5">
                    <span className="font-bold">Del :</span>
                    <input
                      aria-label="Fecha desde"
                      className={`${inp} h-6 w-[98px] px-1`}
                      type="date"
                      defaultValue="1992-01-01"
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

              <div className="space-y-1 px-2">
                <label className="grid grid-cols-[122px_minmax(0,1fr)] items-center gap-1">
                  <span className="font-bold">Unidad Negocio:</span>
                  <select className={`${inp} h-6 w-[160px] px-1`} defaultValue="all">
                    <option value="all">(Todos)</option>
                  </select>
                </label>
                <div className="grid grid-cols-2 gap-3">
                  <label className="grid grid-cols-[54px_minmax(0,1fr)] items-center gap-1">
                    <span className="font-bold">Oficina:</span>
                    <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                      <option value="all">(Todos)</option>
                    </select>
                  </label>
                  <label className="grid grid-cols-[58px_minmax(0,1fr)] items-center gap-1">
                    <span className="font-bold">Almacén:</span>
                    <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                      <option value="all">(Todos)</option>
                    </select>
                  </label>
                </div>
              </div>

              <div className="grid grid-cols-[minmax(0,1fr)_145px] items-center gap-2">
                <Fs legend="MONEDA" className="px-2 pb-2 pt-0">
                  <div className="flex items-center gap-2">
                    <select
                      aria-label="Moneda"
                      className={`${inp} h-6 w-[50px] px-1`}
                      value={moneda}
                      onChange={(event) => setMoneda(event.target.value)}
                    >
                      <option value="USD">USD</option>
                      <option value="PEN">PEN</option>
                    </select>
                    <label className="inline-flex items-center gap-1 font-bold">
                      <input
                        type="checkbox"
                        checked={mantenerMonedaEmision}
                        onChange={(event) => setMantenerMonedaEmision(event.target.checked)}
                        className="accent-[#0874c9]"
                      />
                      Mantener Mon. de Emisión
                    </label>
                  </div>
                </Fs>
                <label className="flex flex-col gap-1 font-bold">
                  <span>Estado:</span>
                  <select className={`${inp} h-6 w-full px-1`} defaultValue="all">
                    <option value="all">(Todos)</option>
                  </select>
                </label>
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
                <label className="grid grid-cols-[76px_minmax(0,1fr)] items-center gap-1">
                  <span className={`font-bold ${todosCobradores ? "text-slate-400" : ""}`}>
                    Cobrador :
                  </span>
                  <select
                    aria-label="Cobrador"
                    className={`${inp} h-6 min-w-0 px-1`}
                    defaultValue="0"
                    disabled={todosCobradores}
                  >
                    <option value="0">0</option>
                  </select>
                </label>
              </Fs>

              <div className="grid grid-cols-3 gap-2">
                <Fs legend="ORDENADO X" className="px-2 pb-2 pt-0">
                  <RadioGroup
                    name="cuentas-ordenado"
                    value={ordenadoX}
                    options={[
                      { value: "total", label: "Total" },
                      { value: "cliente", label: "Cliente" },
                    ]}
                    onChange={setOrdenadoX}
                    disabled={tipo !== "resumen"}
                  />
                </Fs>
                <Fs legend="ORDEN" className="px-2 pb-2 pt-0">
                  <RadioGroup
                    name="cuentas-orden"
                    value={orden}
                    options={[
                      { value: "descendente", label: "Descendente" },
                      { value: "ascendente", label: "Ascendente" },
                    ]}
                    onChange={setOrden}
                    disabled={tipo !== "resumen"}
                  />
                </Fs>
                <Fs legend="TIPO CUENTA" className="px-2 pb-2 pt-0">
                  <RadioGroup
                    name="cuentas-tipo-cuenta"
                    value={tipoCuenta}
                    options={[
                      { value: "cuentas", label: "Ctas Ctes" },
                      { value: "provisiones", label: "Provisiones" },
                      { value: "castigos", label: "Castigos" },
                    ]}
                    onChange={setTipoCuenta}
                  />
                </Fs>
              </div>

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
                <div className="grid grid-cols-[50px_minmax(0,1fr)_26px] items-center gap-1">
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
            </div>

            <div className="space-y-1.5">
              <Fs legend="DOCUMENTOS" className="px-2 pb-2 pt-0">
                <RadioGroup
                  name="cuentas-documento-tipo"
                  value={documentoTipo}
                  options={[
                    { value: "clientes", label: "Clientes" },
                    { value: "documento", label: "Documento" },
                  ]}
                  onChange={setDocumentoTipo}
                />
                <select
                  aria-label="Documento"
                  className={`${inp} h-6 w-full px-1`}
                  value={documentos}
                  onChange={(event) => setDocumentos(event.target.value)}
                  disabled={documentoTipo !== "documento"}
                >
                  <option value="all">(Todos)</option>
                </select>
                <RadioGroup
                  name="cuentas-documento-origen"
                  value={documentoOrigen}
                  options={[
                    { value: "judicial", label: "Judicial" },
                    { value: "gerencial", label: "Gerencial" },
                  ]}
                  onChange={setDocumentoOrigen}
                />
              </Fs>

              <Fs legend="CONDICION" className="px-2 pb-2 pt-0">
                <RadioGroup
                  name="cuentas-condicion"
                  value={condicion}
                  options={[
                    { value: "pendientes", label: "Pendientes" },
                    { value: "cancelado", label: "Cancelado" },
                    { value: "todos", label: "Todos" },
                  ]}
                  onChange={setCondicion}
                />
              </Fs>

              <Fs legend="TIPO" className="px-2 pb-2 pt-0">
                <RadioGroup
                  name="cuentas-tipo"
                  value={tipo}
                  options={[
                    { value: "detallado", label: "Detallado" },
                    { value: "resumen", label: "Resumen" },
                    { value: "unidad", label: "X Unidad de Negocio" },
                  ]}
                  onChange={setTipo}
                />
              </Fs>

              <Fs legend="EXPORTAR" className="px-2 pb-2 pt-0">
                <RadioGroup
                  name="cuentas-exportar"
                  value={exportar}
                  options={[
                    { value: "pantalla", label: "Pantalla" },
                    { value: "excel", label: "Excel" },
                  ]}
                  onChange={setExportar}
                />
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
