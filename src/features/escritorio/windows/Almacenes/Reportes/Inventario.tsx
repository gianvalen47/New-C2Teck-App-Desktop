import { useState, type ReactNode } from "react";
import { Search, ShoppingCart } from "lucide-react";
import {
  btn,
  btnPrimary,
  iconBtn,
  inp,
  WindowShell,
} from "@/components/ui/desktop-primitives";

const stockTypes = [
  "Todos",
  "Todos sin Ceros",
  "Ceros",
  "Positivos",
  "Negativos",
  "Bajo el Mínimo",
  "Bajo el Máximo",
];

function getLocalDateValue() {
  const date = new Date();
  const month = String(date.getMonth() + 1).padStart(2, "0");
  const day = String(date.getDate()).padStart(2, "0");
  return `${date.getFullYear()}-${month}-${day}`;
}

function PositionedGroup({
  legend,
  left,
  top,
  width,
  height,
  legendTop = -8,
  children,
}: {
  legend: string;
  left: number;
  top: number;
  width: number;
  height: number;
  legendTop?: number;
  children?: ReactNode;
}) {
  return (
    <div
      role="group"
      aria-label={legend}
      className="absolute rounded-sm border border-[#7A96B4] bg-[#ECF1F7]"
      style={{ left, top, width, height }}
    >
      <span
        className="absolute left-2 bg-[#F8FBFF] px-1 text-[10.5px] font-bold leading-4 text-slate-700"
        style={{ top: legendTop }}
      >
        {legend}
      </span>
      {children}
    </div>
  );
}

function LookupGroup({
  legend,
  option,
  checked,
  onCheckedChange,
  left,
  inputWidth,
  radioTop,
  inputTop,
  buttonTop,
}: {
  legend: string;
  option: string;
  checked: boolean;
  onCheckedChange: (checked: boolean) => void;
  left: number;
  inputWidth: number;
  radioTop: number;
  inputTop: number;
  buttonTop: number;
}) {
  const inputId = `inventario-${option.toLowerCase()}`;

  return (
    <PositionedGroup
      legend={legend}
      left={left}
      top={374}
      width={180}
      height={74}
    >
      <label
        className="absolute flex items-center gap-1 font-bold"
        style={{ left: 16, top: radioTop }}
      >
        <input
          type="radio"
          name={`inventario-buscar-${option}`}
          checked={checked}
          onChange={() => onCheckedChange(true)}
          className="accent-[#2A5590]"
        />
        {option === "Marca" ? "Toda Marca" : "Toda Aplicación"}
      </label>
      <input
        id={inputId}
        aria-label={legend}
        className={`${inp} absolute h-5 rounded-none px-1`}
        style={{ left: 11, top: inputTop, width: inputWidth }}
        disabled={checked}
        onChange={() => onCheckedChange(false)}
      />
      <button
        type="button"
        className={`${iconBtn} absolute h-[22px] w-[25px] border border-slate-400/70`}
        style={{ left: 11 + inputWidth, top: buttonTop }}
        aria-label={`Buscar ${option.toLowerCase()}`}
        disabled={checked}
        onClick={() => onCheckedChange(false)}
      >
        <Search className="h-3.5 w-3.5" />
      </button>
    </PositionedGroup>
  );
}

export function ReporteInventario({
  title = "Reporte de Inventario",
}: {
  title?: string;
}) {
  return <ReporteInventarioList title={title} />;
}

export function ReporteInventarioList({
  title = "Reporte de Inventario",
}: {
  title?: string;
}) {
  const [tipoReporte, setTipoReporte] = useState("Detallado");
  const [seleccionarRubros, setSeleccionarRubros] = useState(false);
  const [todaMarca, setTodaMarca] = useState(true);
  const [todaAplicacion, setTodaAplicacion] = useState(true);
  const [tipoStock, setTipoStock] = useState("Todos");
  const [mostrarStock, setMostrarStock] = useState("Físico");
  const [todoProveedor, setTodoProveedor] = useState(true);

  const fieldClass = `${inp} absolute h-5 rounded-none px-1 font-bold`;
  const labelStyle = (top: number) => ({
    left: 9,
    top,
    height: 20,
    lineHeight: "20px",
  });
  const fieldStyle = (top: number, width: number) => ({
    left: 118,
    top,
    width,
  });

  return (
    <WindowShell title={title}>
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto p-0 text-[11.5px] text-slate-800">
        <div className="relative h-[552px] w-[715px] shrink-0 font-[Arial,sans-serif]">
          <PositionedGroup
            legend="Tipo"
            left={203}
            top={8}
            width={319}
            height={40}
          >
            <div
              className="absolute flex items-center gap-[18px]"
              style={{ left: 10, top: 15 }}
            >
              {["Detallado", "Resumen", "Comprometidos"].map((option) => (
                <label key={option} className="inline-flex items-center gap-1 whitespace-nowrap font-bold">
                  <input
                    type="radio"
                    name="reporte-inventario-tipo"
                    checked={tipoReporte === option}
                    onChange={() => setTipoReporte(option)}
                    className="accent-[#2A5590]"
                  />
                  {option}
                </label>
              ))}
            </div>
          </PositionedGroup>

          <PositionedGroup
            legend="Inventario"
            left={7}
            top={53}
            width={699}
            height={455}
          >
            <label className="absolute whitespace-nowrap font-bold" style={labelStyle(17)}>
              Stock a la Fecha:
            </label>
            <input
              aria-label="Stock a la Fecha"
              type="date"
              min="2010-01-01"
              defaultValue={getLocalDateValue()}
              className={`${inp} absolute h-5 w-[100px] rounded-none px-1 font-bold`}
              style={{ left: 139, top: 15 }}
            />

            <label className="absolute whitespace-nowrap font-bold" style={labelStyle(42)}>
              Unidad:
            </label>
            <select className={fieldClass} style={fieldStyle(40, 229)} defaultValue="COMERCIAL">
              <option value="COMERCIAL">COMERCIAL</option>
            </select>

            <label className="absolute whitespace-nowrap font-bold" style={labelStyle(71)}>
              Oficina:
            </label>
            <select className={fieldClass} style={fieldStyle(69, 172)} defaultValue="LIMA">
              <option value="LIMA">LIMA</option>
            </select>

            <label className="absolute whitespace-nowrap font-bold" style={labelStyle(101)}>
              Almacén:
            </label>
            <select className={fieldClass} style={fieldStyle(99, 258)} defaultValue="COMERCIAL">
              <option value="COMERCIAL">COMERCIAL</option>
            </select>

            <label className="absolute whitespace-nowrap font-bold" style={labelStyle(131)}>
              Rubro:
            </label>
            <select
              className={fieldClass}
              style={fieldStyle(129, 138)}
              defaultValue="all"
              disabled={seleccionarRubros}
            >
              <option value="all">(Todos)</option>
            </select>
            <label
              className="absolute flex items-center gap-1.5 whitespace-nowrap font-bold"
              style={{ left: 291, top: 132 }}
            >
              <input
                type="checkbox"
                checked={seleccionarRubros}
                onChange={(event) => setSeleccionarRubros(event.target.checked)}
                className="accent-[#2A5590]"
              />
              Seleccionar Rubros
            </label>

            <label className="absolute whitespace-nowrap font-bold" style={labelStyle(160)}>
              Ubicación:
            </label>
            <input
              aria-label="Ubicación"
              className={`${inp} absolute h-5 w-[140px] rounded-none px-1`}
              style={{ left: 118, top: 160 }}
            />

            <label className="absolute whitespace-nowrap font-bold" style={labelStyle(191)}>
              Clase:
            </label>
            <select className={fieldClass} style={fieldStyle(189, 120)} defaultValue="">
              <option value="" />
              <option value="all">(Todos)</option>
            </select>

            <label className="absolute whitespace-nowrap font-bold" style={labelStyle(221)}>
              {"{ Tipo Mov }"}
            </label>
            <select className={fieldClass} style={fieldStyle(219, 140)} defaultValue="all">
              <option value="all">(Todos)</option>
            </select>

            <label className="absolute whitespace-nowrap font-bold" style={labelStyle(251)}>
              {"{ Ciclos }"}
            </label>
            <select className={fieldClass} style={fieldStyle(249, 99)} defaultValue="all">
              <option value="all">(Todos)</option>
            </select>

            <label className="absolute whitespace-nowrap font-bold" style={labelStyle(281)}>
              {"{ Tipo Motor }"}
            </label>
            <select className={fieldClass} style={fieldStyle(279, 142)} defaultValue="all">
              <option value="all">(Todos)</option>
            </select>

            <PositionedGroup
              legend="{ Tipo de Stock }"
              left={524}
              top={64}
              width={167}
              height={175}
              legendTop={-16}
            >
              <div
                className="absolute flex flex-col gap-[3px]"
                style={{ left: 38, top: 12 }}
              >
                {stockTypes.map((option) => (
                  <label key={option} className="inline-flex items-center gap-1 whitespace-nowrap">
                    <input
                      type="radio"
                      name="reporte-inventario-tipo-stock"
                      checked={tipoStock === option}
                      onChange={() => setTipoStock(option)}
                      className="accent-[#2A5590]"
                    />
                    {option}
                  </label>
                ))}
              </div>
            </PositionedGroup>

            <PositionedGroup
              legend="Mostrar Stock"
              left={524}
              top={245}
              width={167}
              height={63}
            >
              <div
                className="absolute flex flex-col gap-0.5"
                style={{ left: 43, top: 19 }}
              >
                {["Físico", "Disponible"].map((option) => (
                  <label key={option} className="inline-flex items-center gap-1 whitespace-nowrap">
                    <input
                      type="radio"
                      name="reporte-inventario-mostrar-stock"
                      checked={mostrarStock === option}
                      onChange={() => setMostrarStock(option)}
                      className="accent-[#2A5590]"
                    />
                    {option}
                  </label>
                ))}
              </div>
            </PositionedGroup>

            <PositionedGroup
              legend="Buscar Proveedor"
              left={5}
              top={313}
              width={380}
              height={52}
            >
              <label
                className="absolute flex items-center gap-1.5 whitespace-nowrap font-bold"
                style={{ left: 168, top: 7 }}
              >
                <input
                  type="checkbox"
                  checked={todoProveedor}
                  onChange={(event) => setTodoProveedor(event.target.checked)}
                  className="accent-[#2A5590]"
                />
                Todo Proveedor
              </label>
              <div
                className="absolute flex h-5 items-center gap-1"
                style={{ left: 9, right: 9, top: 27 }}
              >
                <label
                htmlFor="inventario-proveedor"
                className="w-[67px] shrink-0 whitespace-nowrap font-bold"
                >
                Proveedor
                </label>
                <input
                id="inventario-proveedor"
                className={`${inp} h-5 min-w-0 flex-1 rounded-none px-1`}
                defaultValue="(Todos)"
                disabled={todoProveedor}
                />
                <button
                type="button"
                className={`${iconBtn} h-[22px] w-[25px] shrink-0 border border-slate-400/70`}
                aria-label="Buscar proveedor"
                disabled={todoProveedor}
                >
                <Search className="h-3.5 w-3.5" />
                </button>
              </div>
            </PositionedGroup>

            <button
              type="button"
              className={`${btn} absolute h-7 w-[133px] justify-center gap-1 whitespace-nowrap px-1 font-bold`}
              style={{ left: 403, top: 337 }}
            >
              <ShoppingCart className="h-3.5 w-3.5 shrink-0" />
              Compras Anuales
            </button>

            <LookupGroup
              legend="Buscar Marca"
              option="Marca"
              checked={todaMarca}
              onCheckedChange={setTodaMarca}
              left={5}
              inputWidth={115}
              radioTop={22}
              inputTop={45}
              buttonTop={44}
            />
            <LookupGroup
              legend="Buscar Aplicación"
              option="Aplicación"
              checked={todaAplicacion}
              onCheckedChange={setTodaAplicacion}
              left={205}
              inputWidth={128}
              radioTop={21}
              inputTop={43}
              buttonTop={42}
            />

            <PositionedGroup
              legend="Exportar"
              left={403}
              top={374}
              width={216}
              height={74}
            >
              <label               className="absolute inline-flex items-center gap-1 whitespace-nowrap"
              style={{ left: 11, top: 22 }}>
                <input
                  type="radio"
                  name="reporte-inventario-exportar"
                  defaultChecked
                  className="accent-[#2A5590]"
                />
                Pantalla
              </label>
              <label               className="absolute inline-flex items-center gap-1 whitespace-nowrap"
              style={{ left: 142, top: 22 }}>
                <input
                  type="radio"
                  name="reporte-inventario-exportar"
                  className="accent-[#2A5590]"
                />
                Excel
              </label>
              <label               className="absolute inline-flex items-center gap-1 whitespace-nowrap"
              style={{ left: 11, top: 48 }}>
                <input
                  type="radio"
                  name="reporte-inventario-exportar"
                  className="accent-[#2A5590]"
                />
                Inventario General Excel
              </label>
            </PositionedGroup>
          </PositionedGroup>

          <button
            type="button"
            className={`${btnPrimary} absolute h-7 w-[80px] justify-center px-2 font-bold`}
            style={{ left: 274, top: 518 }}
          >
            Aceptar
          </button>
          <button
            type="button"
            className={`${btn} absolute h-7 w-[80px] justify-center px-2`}
            style={{ left: 360, top: 518 }}
          >
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
