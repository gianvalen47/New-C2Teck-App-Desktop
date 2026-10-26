import { useState } from "react";
import { CheckCircle2, LogOut } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

export function ReporteClientes({
  title = "Reporte Límite de Crédito",
}: {
  title?: string;
}) {
  return <ReporteClientesList title={title} />;
}

export function ReporteClientesList({
  title = "Reporte Límite de Crédito",
}: {
  title?: string;
}) {
  const [contributorType, setContributorType] = useState("(Todos)");
  const [clientType, setClientType] = useState("(Todos)");
  const [status, setStatus] = useState("Ingresado");
  const [output, setOutput] = useState("pantalla");

  const labelClass = "absolute whitespace-nowrap font-bold";
  const selectClass =
    "absolute h-[20px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold";

  return (
    <WindowShell title={title}>
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[191px] w-[359px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <fieldset className="absolute left-[7px] top-[4px] h-[148px] w-[345px] border border-[#7799c5] px-0">
            <legend className="ml-[5px] px-[3px] font-bold text-[#164b91]">
              Datos de Reporte
            </legend>

            <label className={`${labelClass} left-[14px] top-[22px]`}>
              Tipo Contribuyente
            </label>
            <select
              aria-label="Tipo Contribuyente"
              value={contributorType}
              onChange={(event) => setContributorType(event.target.value)}
              className={`${selectClass} left-[127px] top-[15px] w-[194px]`}
            >
              <option>(Todos)</option>
            </select>

            <label className={`${labelClass} left-[14px] top-[49px]`}>
              Tipo Cliente
            </label>
            <select
              aria-label="Tipo Cliente"
              value={clientType}
              onChange={(event) => setClientType(event.target.value)}
              className={`${selectClass} left-[127px] top-[41px] w-[140px]`}
            >
              <option>(Todos)</option>
            </select>

            <label className={`${labelClass} left-[14px] top-[75px]`}>
              Estado
            </label>
            <select
              aria-label="Estado"
              value={status}
              onChange={(event) => setStatus(event.target.value)}
              className={`${selectClass} left-[127px] top-[67px] w-[123px]`}
            >
              <option>Ingresado</option>
            </select>

            <fieldset className="absolute left-[52px] top-[96px] h-[42px] w-[238px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] font-bold text-[#164b91]">
                Exportar
              </legend>
              <label className="absolute left-[27px] top-[15px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="reporte-clientes-exportar"
                  value="pantalla"
                  checked={output === "pantalla"}
                  onChange={() => setOutput("pantalla")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Pantalla
              </label>
              <label className="absolute left-[123px] top-[15px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="reporte-clientes-exportar"
                  value="exportar"
                  checked={output === "exportar"}
                  onChange={() => setOutput("exportar")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Exportar
              </label>
            </fieldset>
          </fieldset>

          <button
            type="button"
            className="absolute left-[96px] top-[158px] flex h-[25px] w-[78px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <CheckCircle2 className="h-[16px] w-[16px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[187px] top-[158px] flex h-[25px] w-[78px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <LogOut className="h-[15px] w-[15px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
