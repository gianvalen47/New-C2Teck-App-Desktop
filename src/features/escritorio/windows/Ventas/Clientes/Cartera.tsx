import { useMemo, useState } from "react";
import { FileText, LogOut, Plus, Printer, RefreshCw } from "lucide-react";
import { toast } from "sonner";
import { btn, iconBtn, inp, tbSep } from "@/features/escritorio/windows/uiStyles";
import {
  CodeDescSelector,
  type CodeDescOption,
} from "@/features/escritorio/windows/shared/SearchFieldControls";

type ClienteRow = {
  codigo: string;
  cliente: string;
  grupo: string;
  vendedor: string;
  fecha: string;
};

const rows: ClienteRow[] = [
  { codigo: "C-0001", cliente: "LUCY VENTAS S.A.C.", grupo: "COMERCIAL", vendedor: "01", fecha: "2026-09-08" },
  { codigo: "C-0002", cliente: "MERCADOS DEL SUR", grupo: "MINERÍA", vendedor: "02", fecha: "2026-09-07" },
  { codigo: "C-0003", cliente: "ALMACEN DEL NORTE", grupo: "SERVICIOS", vendedor: "03", fecha: "2026-08-22" },
];

const SELLER_OPTIONS: CodeDescOption[] = [
  { code: "01", label: "VENDEDOR 01", value: "01" },
  { code: "02", label: "VENDEDOR 02", value: "02" },
  { code: "03", label: "VENDEDOR 03", value: "03" },
];

export function CarteraList() {
  const [seller, setSeller] = useState("");
  const visibleRows = useMemo(
    () => seller ? rows.filter((row) => row.vendedor === seller) : rows,
    [seller],
  );

  return (
    <div className="relative flex h-full min-h-0 flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex shrink-0 items-center gap-1 overflow-x-auto border-b border-slate-400/50 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] px-2 py-1.5">
        <button type="button" className={iconBtn} title="Imprimir cartera">
          <Printer className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Reporte de cartera">
          <FileText className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Actualizar cartera" onClick={() => setSeller("")}>
          <RefreshCw className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Cerrar ventana">
          <LogOut className="h-4 w-4" />
        </button>
      </div>

      <fieldset className="mx-1.5 mt-1.5 flex min-h-0 flex-1 flex-col border border-[#7A96B4] bg-[#ECF1F7] px-2 pb-2 pt-0">
        <legend className="px-1 text-[10.5px] font-bold text-slate-700">Cartera de Clientes</legend>
        <div className="flex shrink-0 items-center gap-2 px-1 py-1">
          <span className="text-[11px] font-semibold text-slate-800">Vendedor</span>
          <div className="min-w-0 flex-1">
            <CodeDescSelector
              value={seller}
              onChange={setSeller}
              options={SELLER_OPTIONS}
              allLabel=""
              width="w-[280px]"
            />
          </div>
          <button
            type="button"
            className={`${btn} shrink-0`}
            onClick={() => toast.info("Agregar clientes requiere conexión al servicio de clientes.")}
          >
            <Plus className="h-3.5 w-3.5" />
            Agregar Cliente
          </button>
        </div>

        <div className="min-h-0 flex-1 overflow-auto border border-slate-400/60 bg-white">
          <table className="w-full min-w-[560px] border-collapse text-[11.5px]">
            <colgroup>
              <col className="w-[15%]" />
              <col className="w-[45%]" />
              <col className="w-[25%]" />
              <col className="w-[15%]" />
            </colgroup>
            <thead className="sticky top-0 z-10 bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800">
              <tr>
                {["Código", "Cliente", "Grupo Ventas", "Fecha"].map((header) => (
                  <th key={header} className="border border-slate-300/80 px-2 py-0.5 text-center font-semibold whitespace-nowrap">
                    {header}
                  </th>
                ))}
              </tr>
            </thead>
            <tbody>
              {visibleRows.map((row, index) => (
                <tr key={row.codigo} className={index % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]"}>
                  <td className="h-[20px] border border-blue-200 px-2 font-mono">{row.codigo}</td>
                  <td className="h-[20px] border border-blue-200 px-2">{row.cliente}</td>
                  <td className="h-[20px] border border-blue-200 px-2">{row.grupo}</td>
                  <td className="h-[20px] border border-blue-200 px-2">{row.fecha}</td>
                </tr>
              ))}
              {Array.from({ length: Math.max(0, 8 - visibleRows.length) }, (_, index) => (
                <tr key={`empty-${index}`} className={index % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]"}>
                  {Array.from({ length: 4 }, (_, column) => (
                    <td key={column} className="h-[20px] border border-blue-200 px-2" />
                  ))}
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </fieldset>
    </div>
  );
}

export function Cartera() {
  return <CarteraList />;
}
