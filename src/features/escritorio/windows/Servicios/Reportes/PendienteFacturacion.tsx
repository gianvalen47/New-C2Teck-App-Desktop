import { useState } from "react";
import { Brush, CheckCircle2, LogOut, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

function dateString(date: Date) {
  const month = String(date.getMonth() + 1).padStart(2, "0");
  const day = String(date.getDate()).padStart(2, "0");
  return `${date.getFullYear()}-${month}-${day}`;
}

function getYearStart() {
  return dateString(new Date(new Date().getFullYear(), 0, 1));
}

function getToday() {
  return dateString(new Date());
}

export function PendienteFacturacion({
  title = "OT Pendiente Facturación",
}: {
  title?: string;
}) {
  return <PendienteFacturacionList title={title} />;
}

export function PendienteFacturacionList({
  title = "OT Pendiente Facturación",
}: {
  title?: string;
}) {
  const [startDate, setStartDate] = useState(getYearStart);
  const [endDate, setEndDate] = useState(getToday);
  const [location, setLocation] = useState("(Todos)");
  const [clientIsAll, setClientIsAll] = useState(true);
  const [client, setClient] = useState("");
  const [invoiceStatus, setInvoiceStatus] = useState<"pending" | "billed">("pending");
  const [jobType, setJobType] = useState("(Todos)");
  const [supervisor, setSupervisor] = useState("(Todos)");

  const selectClass =
    "absolute h-[20px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold";
  const labelClass = "absolute whitespace-nowrap font-bold";

  return (
    <WindowShell title={title}>
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[248px] w-[583px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <div className="absolute left-[6px] top-[3px] h-[234px] w-[567px] border border-[#d7d7d7]">
            <label className={`${labelClass} left-[28px] top-[30px]`}>
              Fecha Inicio:
            </label>
            <input
              aria-label="Fecha Inicio"
              type="date"
              value={startDate}
              onChange={(event) => setStartDate(event.target.value)}
              className="absolute left-[125px] top-[27px] h-[20px] w-[92px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />
            <label className={`${labelClass} left-[223px] top-[30px]`}>
              Fecha Fin:
            </label>
            <input
              aria-label="Fecha Fin"
              type="date"
              value={endDate}
              onChange={(event) => setEndDate(event.target.value)}
              className="absolute left-[299px] top-[27px] h-[20px] w-[92px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />

            <label className={`${labelClass} left-[35px] top-[61px]`}>
              Locación :
            </label>
            <select
              aria-label="Locación"
              value={location}
              onChange={(event) => setLocation(event.target.value)}
              className={`${selectClass} left-[108px] top-[58px] w-[219px]`}
            >
              <option>(Todos)</option>
            </select>

            <label className={`${labelClass} left-[35px] top-[91px]`}>
              Cliente:
            </label>
            <input
              type="checkbox"
              aria-label="Todos los clientes"
              checked={clientIsAll}
              onChange={(event) => {
                const checked = event.target.checked;
                setClientIsAll(checked);
                if (checked) setClient("");
              }}
              className="absolute left-[92px] top-[94px] m-0 h-[14px] w-[14px] accent-[#0875c9]"
            />
            <button
              type="button"
              aria-label="Limpiar cliente"
              onClick={() => setClient("")}
              className="absolute left-[113px] top-[91px] flex h-[18px] w-[24px] items-center justify-center text-[#a97816]"
            >
              <Brush className="h-[17px] w-[17px]" />
            </button>
            <input
              aria-label="Cliente"
              value={clientIsAll ? "" : client}
              onChange={(event) => setClient(event.target.value)}
              className="absolute left-[143px] top-[91px] h-[20px] w-[227px] border border-[#d5d5d5] bg-white px-[4px] font-bold"
            />
            <button
              type="button"
              aria-label="Buscar cliente"
              className="absolute left-[369px] top-[90px] flex h-[22px] w-[24px] items-center justify-center rounded-[2px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed]"
            >
              <Search className="h-[15px] w-[15px] text-[#234878]" />
            </button>

            <fieldset className="absolute left-[405px] top-[24px] h-[84px] w-[159px] border border-[#d7d7d7] px-0">
              <legend className="ml-[5px] px-[3px] text-[12px] font-bold">
                Facturación
              </legend>
              <label className="absolute left-[7px] top-[21px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="billing-status"
                  checked={invoiceStatus === "pending"}
                  onChange={() => setInvoiceStatus("pending")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Pendiente Facturación
              </label>
              <label className="absolute left-[7px] top-[50px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="billing-status"
                  checked={invoiceStatus === "billed"}
                  onChange={() => setInvoiceStatus("billed")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Facturados
              </label>
            </fieldset>

            <label className={`${labelClass} left-[35px] top-[121px]`}>
              Tipo OT :
            </label>
            <select
              aria-label="Tipo OT"
              value={jobType}
              onChange={(event) => setJobType(event.target.value)}
              className={`${selectClass} left-[108px] top-[118px] w-[150px]`}
            >
              <option>(Todos)</option>
            </select>
            <label className={`${labelClass} left-[31px] top-[151px]`}>
              Supervisor :
            </label>
            <select
              aria-label="Supervisor"
              value={supervisor}
              onChange={(event) => setSupervisor(event.target.value)}
              className={`${selectClass} left-[108px] top-[148px] w-[305px]`}
            >
              <option>(Todos)</option>
            </select>

            <button
              type="button"
              className="absolute left-[196px] top-[190px] flex h-[23px] w-[74px] items-center justify-center gap-[3px] rounded-[3px] border border-[#85a9d1] bg-gradient-to-b from-white to-[#e7eef7] text-[12px] font-bold hover:to-[#dce8f5]"
            >
              <CheckCircle2 className="h-[16px] w-[16px] fill-green-600 text-white" />
              Aceptar
            </button>
            <button
              type="button"
              className="absolute left-[289px] top-[190px] flex h-[23px] w-[80px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
            >
              <LogOut className="h-[15px] w-[15px] text-gray-700" />
              Cancelar
            </button>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}
