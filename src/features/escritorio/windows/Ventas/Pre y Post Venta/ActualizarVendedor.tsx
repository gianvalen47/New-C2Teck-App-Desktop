import { useState } from "react";
import type { ReactNode } from "react";
import { FilePenLine, LogOut, Save, Undo2 } from "lucide-react";
import { toast } from "sonner";
import { iconBtn, inp, tbSep } from "@/features/escritorio/windows/uiStyles";
import {
  CodeDescSelector,
  type CodeDescOption,
} from "@/features/escritorio/windows/shared/SearchFieldControls";

const OFFICE_OPTIONS: CodeDescOption[] = [
  { code: "01", label: "LIMA", value: "LIMA" },
  { code: "02", label: "IQUITOS", value: "IQUITOS" },
  { code: "03", label: "AREQUIPA", value: "AREQUIPA" },
];

const WAREHOUSE_OPTIONS: CodeDescOption[] = [
  { code: "01", label: "COMERCIAL", value: "COMERCIAL" },
  { code: "02", label: "PRINCIPAL", value: "PRINCIPAL" },
];

const DOCUMENT_OPTIONS: CodeDescOption[] = [
  { code: "1", label: "Guía de Remisión", value: "1" },
  { code: "2", label: "Factura", value: "2" },
  { code: "3", label: "Boleta", value: "3" },
  { code: "4", label: "Guía de Devolución", value: "4" },
  { code: "5", label: "Nota de Crédito", value: "5" },
];

const INVOICE_TYPE_OPTIONS: CodeDescOption[] = [
  { code: "1", label: "Crédito", value: "1" },
  { code: "2", label: "Contado", value: "2" },
];

const SELLER_OPTIONS: CodeDescOption[] = [
  { code: "01", label: "VENDEDOR 01", value: "01" },
  { code: "02", label: "VENDEDOR 02", value: "02" },
];

const DETAIL_COLUMNS = ["Código", "Descripción", "Cant.", "Desc.", "Precio", "Total"];
const DETAIL_WIDTHS = ["17%", "27%", "7%", "14%", "16%", "19%"];

function Field({
  label,
  className = "",
  children,
}: {
  label: string;
  className?: string;
  children: ReactNode;
}) {
  return (
    <label className={`flex min-w-0 flex-col gap-0.5 ${className}`}>
      <span className="text-[11px] font-semibold text-slate-800">{label}</span>
      {children}
    </label>
  );
}

export function ActualizarVendedorList() {
  const [office, setOffice] = useState("LIMA");
  const [warehouse, setWarehouse] = useState("");
  const [documentType, setDocumentType] = useState("1");
  const [invoiceType, setInvoiceType] = useState("2");
  const [number, setNumber] = useState("");
  const [date, setDate] = useState("");
  const [client, setClient] = useState("");
  const [seller, setSeller] = useState("");
  const [assignToOffice, setAssignToOffice] = useState(false);
  const [editing, setEditing] = useState(false);

  const clearForm = () => {
    setNumber("");
    setDate("");
    setClient("");
    setSeller("");
    setAssignToOffice(false);
  };

  const handleSave = () => {
    if (!editing) return;
    toast.info("La actualización requiere conexión al servicio de documentos.");
  };

  return (
    <div className="relative flex h-full min-h-0 flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex shrink-0 items-center gap-1 border-b border-slate-400/50 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] px-2 py-1.5">
        <button
          type="button"
          className={iconBtn}
          title="Modificar vendedor"
          onClick={() => setEditing(true)}
        >
          <FilePenLine className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Limpiar formulario" onClick={clearForm}>
          <Undo2 className="h-4 w-4" />
        </button>
        {tbSep}
        <button
          type="button"
          className={iconBtn}
          title="Guardar los cambios realizados"
          onClick={handleSave}
          disabled={!editing}
        >
          <Save className="h-4 w-4" />
        </button>
        {tbSep}
        <button
          type="button"
          className={iconBtn}
          title="Salir del formulario"
          onClick={() => toast.info("Use el botón de cerrar la ventana para salir.")}
        >
          <LogOut className="h-4 w-4" />
        </button>
      </div>

      <div className="flex min-h-0 flex-1 flex-col gap-2 overflow-auto px-2 py-2">
        <div className="flex shrink-0 flex-col gap-1.5">
          <div className="flex items-center gap-2">
            <span className="w-[76px] shrink-0 text-[11px] font-semibold text-slate-800">Oficina:</span>
            <div className="w-[150px] shrink-0">
              <CodeDescSelector value={office} onChange={setOffice} options={OFFICE_OPTIONS} />
            </div>
          </div>
          <div className="flex items-center gap-2">
            <span className="w-[76px] shrink-0 text-[11px] font-semibold text-slate-800">Almacén:</span>
            <div className="w-[150px] shrink-0">
              <CodeDescSelector value={warehouse} onChange={setWarehouse} options={WAREHOUSE_OPTIONS} allLabel="" />
            </div>
          </div>
          <div className="flex flex-wrap items-center gap-x-8 gap-y-1.5">
            <div className="flex items-center gap-2">
              <span className="w-[76px] shrink-0 text-[11px] font-semibold text-slate-800">Documento:</span>
              <div className="w-[150px] shrink-0">
                <CodeDescSelector value={documentType} onChange={setDocumentType} options={DOCUMENT_OPTIONS} />
              </div>
            </div>
            <fieldset
              disabled={documentType !== "2"}
              className="flex items-center gap-2 disabled:opacity-60"
            >
              <span className="text-[11px] font-semibold text-slate-700">Tip.Fac:</span>
              <div className="w-28">
                <CodeDescSelector
                  value={invoiceType}
                  onChange={setInvoiceType}
                  options={INVOICE_TYPE_OPTIONS}
                  disabled={documentType !== "2"}
                />
              </div>
            </fieldset>
          </div>
        </div>

        <div className="grid shrink-0 gap-1.5">
          <div className="flex flex-wrap items-center gap-x-5 gap-y-1.5">
            <Field label="Número:" className="w-fit flex-row items-center gap-2">
              <input
                className={`${inp} w-[88px] shrink-0 text-center font-mono`}
                style={{ width: 88 }}
                value={number}
                onChange={(event) => setNumber(event.target.value)}
              />
            </Field>
            <Field label="Fecha:" className="w-fit flex-row items-center gap-2">
              <input className={`${inp} w-[82px] shrink-0`} style={{ width: 82 }} value={date} readOnly />
            </Field>
          </div>
          <Field label="Cliente:" className="w-fit max-w-full flex-row items-center gap-2">
            <input className={`${inp} w-[285px] max-w-full`} style={{ width: 285 }} value={client} readOnly />
          </Field>
          <div className="flex flex-wrap items-center gap-2">
            <span className="text-[11px] font-semibold text-slate-800">Vendedor:</span>
            <div className="w-[285px] max-w-full shrink-0">
              <CodeDescSelector
                value={seller}
                onChange={setSeller}
                options={SELLER_OPTIONS}
                allLabel=""
                disabled={!editing || assignToOffice}
              />
            </div>
            <label className="inline-flex items-center gap-1 text-[11px] text-slate-600">
              <input
                type="checkbox"
                checked={assignToOffice}
                onChange={(event) => setAssignToOffice(event.target.checked)}
                disabled={!editing}
                className="h-3.5 w-3.5 accent-[#2A5590]"
              />
              Asignar a Oficina
            </label>
          </div>
        </div>

        <div className="border border-slate-400/60 bg-white rounded-sm h-full overflow-auto">
          <table className="w-full text-[11.5px]">
            <colgroup>
              {DETAIL_WIDTHS.map((width, index) => <col key={DETAIL_COLUMNS[index]} style={{ width }} />)}
            </colgroup>
            <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 sticky top-0 z-10">
              <tr>
                {DETAIL_COLUMNS.map((column) => (
                  <th
                    key={column}
                    className="border border-slate-300/80 px-2 py-0.5 text-center font-semibold whitespace-nowrap"
                  >
                    {column}
                  </th>
                ))}
              </tr>
            </thead>
            <tbody>
              {Array.from({ length: 11 }, (_, index) => (
                <tr key={index} className={index % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]"}>
                  {DETAIL_COLUMNS.map((column) => (
                    <td key={column} className="h-[24px] border border-slate-300/80 px-2 py-0.5" />
                  ))}
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>

      <div className="shrink-0 border-t border-slate-300 bg-gradient-to-b from-[#F2F4F7] to-[#E2E6EB] px-2 py-1.5">
        <div className="grid grid-cols-2 gap-2 sm:grid-cols-4">
          {["Total Bruto", "Descuentos", "Total Impuesto", "Total Documento"].map((label) => (
            <label key={label} className="flex flex-col gap-0.5 px-1">
              <span className="text-center text-[11px] font-bold text-slate-800">{label}</span>
              <input className={`${inp} max-w-[120px]`} readOnly />
            </label>
          ))}
        </div>
      </div>
    </div>
  );
}

export function ActualizarVendedor() {
  return <ActualizarVendedorList />;
}
