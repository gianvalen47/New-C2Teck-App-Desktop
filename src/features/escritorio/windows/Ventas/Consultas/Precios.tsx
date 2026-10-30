import { useState } from "react";
import {
  btn,
  inp,
  WindowShell,
} from "@/components/ui/desktop-primitives";

type DetailField = {
  label: string;
  labelLeft: number;
  inputLeft: number;
  top: number;
  width: number;
  value?: string;
  muted?: boolean;
};

const leftDetails: DetailField[] = [
  { label: "Record Type :", labelLeft: 21, inputLeft: 269, top: 63, width: 58 },
  { label: "Supercession Code", labelLeft: 21, inputLeft: 269, top: 93, width: 58 },
  { label: "Publicacion Code", labelLeft: 21, inputLeft: 269, top: 119, width: 58 },
  { label: "Series Code", labelLeft: 21, inputLeft: 269, top: 145, width: 58 },
  { label: "Functional Comp Code", labelLeft: 21, inputLeft: 269, top: 171, width: 58 },
  { label: "Country of Origen", labelLeft: 21, inputLeft: 269, top: 198, width: 58 },
  { label: "Precio Core", labelLeft: 21, inputLeft: 210, top: 225, width: 117, value: "0.00", muted: true },
  { label: "Precio Ex Work: US$", labelLeft: 21, inputLeft: 210, top: 278, width: 117, value: "0.00", muted: true },
];

const rightDetails: DetailField[] = [
  { label: "Must Buy Quantity", labelLeft: 362, inputLeft: 588, top: 63, width: 58 },
  { label: "Group Code", labelLeft: 362, inputLeft: 531, top: 91, width: 117, value: "0.0000", muted: true },
  { label: "Weight", labelLeft: 364, inputLeft: 531, top: 117, width: 117, value: "0.0000", muted: true },
  { label: "Unit Weight", labelLeft: 364, inputLeft: 531, top: 144, width: 117 },
  { label: "Cubes", labelLeft: 364, inputLeft: 531, top: 171, width: 117, value: "0.0000", muted: true },
  { label: "Unit Cubes", labelLeft: 364, inputLeft: 531, top: 198, width: 117 },
  { label: "Precio SLP :  US$", labelLeft: 362, inputLeft: 531, top: 226, width: 117, value: "0.00", muted: true },
  { label: "Precio Venta :    US$", labelLeft: 362, inputLeft: 531, top: 251, width: 117, value: "0.00", muted: true },
  { label: "Precio Venta        S/.", labelLeft: 362, inputLeft: 531, top: 276, width: 117, value: "0.00", muted: true },
];

export function PrecioConsulta({
  title = "Consulta de Precios",
}: {
  title?: string;
}) {
  return <PrecioConsultaList title={title} />;
}

export function PrecioConsultaList({
  title = "Consulta de Precios",
}: {
  title?: string;
}) {
  const [brand, setBrand] = useState("YANMAR");
  const [itemCode, setItemCode] = useState("");

  const labelClass = "absolute whitespace-nowrap font-bold";

  return (
    <WindowShell title={title}>
      <div className="flex h-full min-h-0 items-start justify-start overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="relative h-[416px] w-[696px] shrink-0">
          <label className={`${labelClass} left-[12px] top-[19px]`}>
            Marca :
          </label>
          <select
            aria-label="Marca"
            value={brand}
            onChange={(event) => setBrand(event.target.value)}
            className={`absolute left-[77px] top-[17px] h-6 w-[186px] px-2 font-semibold ${inp}`}
          >
            <option>YANMAR</option>
            <option>CATERPILLAR</option>
            <option>KOMATSU</option>
          </select>

          <fieldset className="absolute left-[12px] top-[51px] h-[322px] w-[665px] rounded-sm border border-[#7A96B4] bg-[#ECF1F7] px-0">
            <legend className="ml-[5px] px-[3px] text-[10.5px] font-bold text-slate-700">Mercaderia</legend>
            <label className={`${labelClass} left-[21px] top-[25px]`}>
              Código :
            </label>
            <input
              aria-label="Código"
              value={itemCode}
              onChange={(event) => setItemCode(event.target.value.toUpperCase())}
              className={`absolute left-[93px] top-[25px] h-6 w-[152px] px-2 font-semibold uppercase ${inp}`}
            />
            <label className={`${labelClass} left-[272px] top-[25px]`}>
              Descripcion :
            </label>
            <input
              aria-label="Descripción"
              readOnly
              className={`absolute left-[375px] top-[25px] h-6 w-[261px] px-2 font-semibold ${inp}`}
            />

            {[...leftDetails, ...rightDetails].map((field) => (
              <div key={field.label} className="contents">
                <label
                  className={labelClass}
                  style={{ left: field.labelLeft, top: field.top }}
                >
                  {field.label}
                </label>
                <input
                  aria-label={field.label}
                  readOnly
                  value={field.value ?? ""}
                  style={{
                    left: field.inputLeft,
                    top: field.top,
                    width: field.width,
                  }}
                  className={`absolute h-6 rounded-sm border border-slate-400/70 px-2 text-[11.5px] font-semibold outline-none focus:border-[#3E5B7A] focus:ring-1 focus:ring-[#3E5B7A]/30 ${
                    field.value ? "text-right" : "text-left"
                  } ${
                    field.muted
                      ? "bg-[#F7FAFE]"
                      : field.label.includes("Unit ")
                        ? "bg-[#ECF1F7]"
                        : "bg-white"
                  }`}
                />
              </div>
            ))}

            <div className="absolute left-[5px] top-[302px] h-[15px] w-[645px] rounded-sm border border-slate-300 bg-[#F8FBFF]" />
          </fieldset>

          <button
            type="button"
            className={`absolute left-[583px] top-[379px] ${btn}`}
          >
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
