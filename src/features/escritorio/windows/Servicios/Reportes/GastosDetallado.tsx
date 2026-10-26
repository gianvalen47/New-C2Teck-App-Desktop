import { useState } from "react";
import { CheckCircle2, LogOut, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

function formatDate(date: Date) {
  const month = String(date.getMonth() + 1).padStart(2, "0");
  const day = String(date.getDate()).padStart(2, "0");
  return `${date.getFullYear()}-${month}-${day}`;
}

function getStartOfYear() {
  return formatDate(new Date(new Date().getFullYear(), 0, 1));
}

function getToday() {
  return formatDate(new Date());
}

export function GastosDetallado({ title = "Gastos Generales" }: { title?: string }) {
  return <GastosDetalladoList title={title} />;
}

export function GastosDetalladoList({ title = "Gastos Generales" }: { title?: string }) {
  const [startDate, setStartDate] = useState(getStartOfYear);
  const [endDate, setEndDate] = useState(getToday);
  const [location, setLocation] = useState("Todos");
  const [type, setType] = useState("Todos");
  const [documentType, setDocumentType] = useState("Todos");
  const [rubro, setRubro] = useState("Todos");
  const [currency, setCurrency] = useState("Todos");
  const [businessUnit, setBusinessUnit] = useState("Todos");
  const [area, setArea] = useState("Todos");
  const [costCenter, setCostCenter] = useState("Todos");
  const [jobNumber, setJobNumber] = useState("");
  const [documentNumber, setDocumentNumber] = useState("");
  const [ruc, setRuc] = useState("");
  const [description, setDescription] = useState("");
  const [amount, setAmount] = useState("0.00");
  const [exportType, setExportType] = useState<"screen" | "excel">("screen");

  const selectClass =
    "absolute h-[20px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold";
  const labelClass = "absolute whitespace-nowrap font-bold";
  const textInputClass =
    "absolute h-[20px] border border-[#aeb6c2] bg-white px-[4px] text-[12px] font-bold";
  const todoOptions = (
    <>
      <option>Todos</option>
    </>
  );

  return (
    <WindowShell title={title}>
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[389px] w-[614px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <div className="absolute left-[7px] top-[2px] h-[329px] w-[581px]">
            <div className="relative h-full w-full">
            <fieldset className="absolute left-[66px] top-[16px] h-[48px] w-[450px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
                Fango de Fechas
              </legend>
              <label className={`${labelClass} left-[31px] top-[19px]`}>
                Fecha Inicio:
              </label>
              <input
                aria-label="Fecha Inicio"
                type="date"
                value={startDate}
                onChange={(event) => setStartDate(event.target.value)}
                className="absolute left-[126px] top-[17px] h-[20px] w-[92px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
              />
              <label className={`${labelClass} left-[255px] top-[21px]`}>
                Fecha Fin:
              </label>
              <input
                aria-label="Fecha Fin"
                type="date"
                value={endDate}
                onChange={(event) => setEndDate(event.target.value)}
                className="absolute left-[328px] top-[17px] h-[20px] w-[92px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
              />
            </fieldset>

            <label className={`${labelClass} left-[31px] top-[79px]`}>
              Locación:
            </label>
            <select
              aria-label="Locación"
              value={location}
              onChange={(event) => setLocation(event.target.value)}
              className={`${selectClass} left-[106px] top-[77px] w-[118px]`}
            >
              {todoOptions}
            </select>
            <label className={`${labelClass} left-[268px] top-[79px]`}>Tipo :</label>
            <select
              aria-label="Tipo"
              value={type}
              onChange={(event) => setType(event.target.value)}
              className={`${selectClass} left-[310px] top-[77px] w-[74px]`}
            >
              {todoOptions}
            </select>
            <label className={`${labelClass} left-[405px] top-[79px]`}># OT :</label>
            <input
              aria-label="Número de OT"
              maxLength={7}
              value={jobNumber}
              onChange={(event) => setJobNumber(event.target.value.toUpperCase())}
              className={`${textInputClass} left-[461px] top-[76px] w-[61px] uppercase`}
            />
            <button
              type="button"
              aria-label="Buscar OT"
              className="absolute left-[524px] top-[75px] flex h-[22px] w-[25px] items-center justify-center rounded-[2px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed]"
            >
              <Search className="h-[15px] w-[15px] text-[#234878]" />
            </button>

            <label className={`${labelClass} left-[24px] top-[110px]`}>
              Tipo Doc. :
            </label>
            <select
              aria-label="Tipo de documento"
              value={documentType}
              onChange={(event) => setDocumentType(event.target.value)}
              className={`${selectClass} left-[106px] top-[109px] w-[118px]`}
            >
              {todoOptions}
            </select>
            <label className={`${labelClass} left-[240px] top-[110px]`}>
              Nro. Doc.:
            </label>
            <input
              aria-label="Número de documento"
              value={documentNumber}
              onChange={(event) => setDocumentNumber(event.target.value)}
              className={`${textInputClass} left-[310px] top-[109px] w-[95px]`}
            />
            <label className={`${labelClass} left-[415px] top-[110px]`}>Ruc :</label>
            <input
              aria-label="RUC"
              value={ruc}
              onChange={(event) => setRuc(event.target.value)}
              className={`${textInputClass} left-[461px] top-[109px] w-[98px]`}
            />

            <label className={`${labelClass} left-[9px] top-[142px]`}>
              Descripción :
            </label>
            <input
              aria-label="Descripción"
              value={description}
              onChange={(event) => setDescription(event.target.value)}
              className={`${textInputClass} left-[99px] top-[141px] w-[460px]`}
            />

            <label className={`${labelClass} left-[46px] top-[174px]`}>
              Rubro :
            </label>
            <select
              aria-label="Rubro"
              value={rubro}
              onChange={(event) => setRubro(event.target.value)}
              className={`${selectClass} left-[99px] top-[172px] w-[125px]`}
            >
              {todoOptions}
            </select>
            <label className={`${labelClass} left-[244px] top-[174px]`}>
              Moneda :
            </label>
            <select
              aria-label="Moneda"
              value={currency}
              onChange={(event) => setCurrency(event.target.value)}
              className={`${selectClass} left-[310px] top-[172px] w-[70px]`}
            >
              {todoOptions}
            </select>
            <label className={`${labelClass} left-[400px] top-[174px]`}>
              Monto :
            </label>
            <input
              aria-label="Monto"
              value={amount}
              onChange={(event) => setAmount(event.target.value)}
              className={`${textInputClass} left-[461px] top-[172px] w-[98px]`}
            />

            <fieldset className="absolute left-[12px] top-[200px] h-[72px] w-[554px] border border-[#7799c5] px-0">
              <label className={`${labelClass} left-[14px] top-[17px]`}>
                Unidad Negocio
              </label>
              <select
                aria-label="Unidad Negocio"
                value={businessUnit}
                onChange={(event) => setBusinessUnit(event.target.value)}
                className={`${selectClass} left-[130px] top-[15px] w-[170px]`}
              >
                {todoOptions}
              </select>
              <label className={`${labelClass} left-[347px] top-[17px]`}>Area</label>
              <select
                aria-label="Área"
                value={area}
                onChange={(event) => setArea(event.target.value)}
                className={`${selectClass} left-[389px] top-[15px] w-[142px]`}
              >
                {todoOptions}
              </select>
              <label className={`${labelClass} left-[15px] top-[46px]`}>
                Centro de Costo
              </label>
              <select
                aria-label="Centro de Costo"
                value={costCenter}
                onChange={(event) => setCostCenter(event.target.value)}
                className={`${selectClass} left-[130px] top-[44px] w-[192px]`}
              >
                {todoOptions}
              </select>
            </fieldset>

            <fieldset className="absolute left-[172px] top-[278px] h-[40px] w-[238px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
                Exportar
              </legend>
              <label className="absolute left-[41px] top-[13px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="gastos-export-type"
                  checked={exportType === "screen"}
                  onChange={() => setExportType("screen")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Pantalla
              </label>
              <label className="absolute left-[146px] top-[13px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="gastos-export-type"
                  checked={exportType === "excel"}
                  onChange={() => setExportType("excel")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Excel
              </label>
            </fieldset>
            </div>
          </div>

          <button
            type="button"
            className="absolute left-[213px] top-[338px] flex h-[27px] w-[83px] items-center justify-center gap-[4px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <CheckCircle2 className="h-[17px] w-[17px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[302px] top-[338px] flex h-[27px] w-[83px] items-center justify-center gap-[4px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <LogOut className="h-[16px] w-[16px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
