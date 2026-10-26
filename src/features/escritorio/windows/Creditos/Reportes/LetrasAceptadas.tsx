import { useState } from "react";
import { CheckCircle2, LogOut, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

function toDateInputValue(date: Date) {
  const month = String(date.getMonth() + 1).padStart(2, "0");
  const day = String(date.getDate()).padStart(2, "0");
  return `${date.getFullYear()}-${month}-${day}`;
}

function getMonthStart() {
  const today = new Date();
  return toDateInputValue(new Date(today.getFullYear(), today.getMonth(), 1));
}

function getToday() {
  return toDateInputValue(new Date());
}

export function LetrasAceptadas({
  title = "Reporte de Letras",
}: {
  title?: string;
}) {
  return <LetrasAceptadasList title={title} />;
}

export function LetrasAceptadasList({
  title = "Reporte de Letras",
}: {
  title?: string;
}) {
  const [startDate, setStartDate] = useState(getMonthStart);
  const [endDate, setEndDate] = useState(getToday);
  const [todosClientes, setTodosClientes] = useState(true);
  const [client, setClient] = useState("");

  const labelClass = "absolute whitespace-nowrap font-bold";

  return (
    <WindowShell title={title}>
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[221px] w-[420px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <fieldset className="absolute left-[12px] top-[12px] h-[67px] w-[397px] border border-[#d7d7d7] px-0">
            <legend className="ml-[5px] px-[3px] font-bold">
              Intervalo de Fechas
            </legend>
            <label className="absolute left-[17px] top-[31px] whitespace-nowrap bg-white px-1 font-bold">
              Fecha Del :
            </label>
            <input
              aria-label="Fecha desde"
              type="date"
              min="1992-01-01"
              value={startDate}
              onChange={(event) => setStartDate(event.target.value)}
              className="absolute left-[96px] top-[30px] h-[20px] w-[97px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />
            <label className="absolute left-[234px] top-[32px] whitespace-nowrap bg-white px-1 font-bold">
              Al :
            </label>
            <input
              aria-label="Fecha hasta"
              type="date"
              min="1992-01-01"
              value={endDate}
              onChange={(event) => setEndDate(event.target.value)}
              className="absolute left-[258px] top-[29px] h-[20px] w-[94px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />
          </fieldset>

          <fieldset className="absolute left-[12px] top-[97px] h-[82px] w-[397px] border border-[#d7d7d7] px-0">
            <legend className="ml-[5px] px-[3px] font-bold">Cliente</legend>
            <label className="absolute left-[167px] top-[20px] flex items-center gap-[6px] whitespace-nowrap font-bold">
              <input
                aria-label="Todos los clientes"
                type="checkbox"
                checked={todosClientes}
                onChange={(event) => {
                  setTodosClientes(event.target.checked);
                  if (event.target.checked) setClient("");
                }}
                className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
              />
              Todos
            </label>
            <label
              className={`${labelClass} left-[13px] top-[54px] bg-white px-1 ${
                todosClientes ? "text-gray-400" : ""
              }`}
            >
              Cliente
            </label>
            <input
              aria-label="Cliente"
              value={client}
              onChange={(event) => setClient(event.target.value.toUpperCase())}
              disabled={todosClientes}
              readOnly
              className="absolute left-[64px] top-[53px] h-[20px] w-[288px] border border-[#b8b8b8] bg-white px-[3px] text-[12px] font-bold uppercase disabled:bg-[#f0f0f0]"
            />
            <button
              type="button"
              aria-label="Buscar cliente"
              disabled={todosClientes}
              className="absolute left-[353px] top-[51px] flex h-[22px] w-[25px] items-center justify-center rounded-[2px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] disabled:opacity-60"
            >
              <Search className="h-[15px] w-[15px] text-gray-700" />
            </button>
          </fieldset>

          <button
            type="button"
            className="absolute left-[130px] top-[185px] flex h-[27px] w-[78px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <CheckCircle2 className="h-[16px] w-[16px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[214px] top-[185px] flex h-[27px] w-[78px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <LogOut className="h-[15px] w-[15px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
