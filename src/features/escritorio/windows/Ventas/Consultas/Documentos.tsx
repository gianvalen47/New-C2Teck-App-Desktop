import { useMemo, useState } from "react";
import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";
import {
  CodeDescSelector,
  MonthSelector,
  YearSpinner,
  type CodeDescOption,
} from "@/features/escritorio/windows/shared/SearchFieldControls";
import type { ReactNode } from "react";
import { iconBtn, inp, btn, tbSep } from "@/features/escritorio/windows/uiStyles";
import {
  FileSearch,
  Eraser,
  LogOut,
  Mail,
  Package,
  Plus,
  Printer,
  RefreshCw,
  Save,
  Search,
  Send,
  Trash2,
  Wrench,
} from "lucide-react";
import { TicketPrinterIcon } from "@/components/ui/icons";

export const stdToolbar14 = (
  <>
    <button className={iconBtn} title="Imprimir Documento"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Imprimir Ticket"><TicketPrinterIcon className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Guía"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar Guías"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Ver Estados"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Buscar"><Search className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Documentos"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mensajería"><Mail className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Cerrar Formulario"><LogOut className="h-4 w-4" /></button>
  </>
);

type DocumentoRow = {
  serie: string;
  numero: string;
  fecha: string;
  nroFactura: string;
  ordenTrabajo: string;
  cliente: string;
  documento: string;
  tipo: string;
  oficina: string;
  almacen: string;
  moneda: string;
  total: string;
  estado: string;
};

const rows: DocumentoRow[] = [
  { serie: "G001", numero: "421", fecha: "2026-10-29", nroFactura: "F001-1001", ordenTrabajo: "1205", cliente: "REMAN CENTER PERU S.A.C.", documento: "Guía de Remisión", tipo: "Todos", oficina: "IQUITOS", almacen: "COMERCIAL", moneda: "S/.", total: "2,847.10", estado: "ENVIADO" },
  { serie: "F001", numero: "1001", fecha: "2026-10-28", nroFactura: "F001-1001", ordenTrabajo: "1204", cliente: "COMERCIAL DEL NORTE S.A.C.", documento: "Factura", tipo: "Contado", oficina: "IQUITOS", almacen: "COMERCIAL", moneda: "S/.", total: "1,560.00", estado: "ACEPTADO" },
  { serie: "B001", numero: "1002", fecha: "2026-10-17", nroFactura: "", ordenTrabajo: "1198", cliente: "SERVICIOS INDUSTRIALES LIMA", documento: "Boleta", tipo: "Contado", oficina: "LIMA", almacen: "PRINCIPAL", moneda: "US$", total: "980.50", estado: "PENDIENTE" },
  { serie: "G001", numero: "418", fecha: "2026-09-30", nroFactura: "F001-0998", ordenTrabajo: "1182", cliente: "MERCADOS DEL SUR", documento: "Guía de Remisión", tipo: "Todos", oficina: "IQUITOS", almacen: "COMERCIAL", moneda: "S/.", total: "4,250.00", estado: "ENVIADO" },
];

const OFFICE_OPTIONS: CodeDescOption[] = [
  { code: "01", label: "IQUITOS", value: "IQUITOS" },
  { code: "02", label: "LIMA", value: "LIMA" },
  { code: "03", label: "AREQUIPA", value: "AREQUIPA" },
];

const WAREHOUSE_OPTIONS: CodeDescOption[] = [
  { code: "01", label: "COMERCIAL", value: "COMERCIAL" },
  { code: "02", label: "PRINCIPAL", value: "PRINCIPAL" },
];

const DOCUMENT_OPTIONS: CodeDescOption[] = [
  { code: "01", label: "Guía de Remisión", value: "Guía de Remisión" },
  { code: "02", label: "Factura", value: "Factura" },
  { code: "03", label: "Boleta", value: "Boleta" },
];

const TYPE_OPTIONS: CodeDescOption[] = [
  { code: "01", label: "Contado", value: "Contado" },
  { code: "02", label: "Crédito", value: "Crédito" },
];

function Field({ label, className = "", children }: { label: string; className?: string; children: ReactNode }) {
  return (
    <label className={`flex flex-col gap-0.5 ${className}`}>
      <span className="text-[10.5px] text-slate-600 font-medium leading-tight">{label}</span>
      {children}
    </label>
  );
}

export function DocumentosList() {
  const [year, setYear] = useState("2026");
  const [month, setMonth] = useState("10");
  const [document, setDocument] = useState("Guía de Remisión");
  const [type, setType] = useState("");
  const [office, setOffice] = useState("IQUITOS");
  const [warehouse, setWarehouse] = useState("");
  const [client, setClient] = useState("");
  const [appliedClient, setAppliedClient] = useState("");
  const [workOrder, setWorkOrder] = useState("");
  const [number, setNumber] = useState("");
  const [appliedNumber, setAppliedNumber] = useState("");
  const [status, setStatus] = useState("");

  const visibleRows = useMemo(() => rows.filter((row) => {
    const date = new Date(`${row.fecha}T00:00:00`);
    if (year && date.getFullYear() !== Number(year)) return false;
    if (month && date.getMonth() + 1 !== Number(month)) return false;
    if (document && row.documento !== document) return false;
    if (type && row.tipo !== type) return false;
    if (office && row.oficina !== office) return false;
    if (warehouse && row.almacen !== warehouse) return false;
    if (appliedClient && !row.cliente.toLowerCase().includes(appliedClient)) return false;
    if (workOrder.trim() && !row.ordenTrabajo.includes(workOrder.trim())) return false;
    if (appliedNumber && !row.numero.includes(appliedNumber.trim())) return false;
    if (status && row.estado !== status) return false;
    return true;
  }), [year, month, document, type, office, warehouse, appliedClient, workOrder, appliedNumber, status]);

  const applyNumberSearch = () => setAppliedNumber(number.trim());
  const applyClientSearch = () => setAppliedClient(client.trim().toLowerCase());
  const clearClientSearch = () => {
    setClient("");
    setAppliedClient("");
  };

  return (
    <div className="relative h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0 overflow-x-auto">
        {stdToolbar14}
      </div>

      <fieldset className="mx-1.5 mt-1.5 border border-[#7A96B4] bg-[#ECF1F7] px-2 pb-1.5 pt-0 shrink-0">
        <legend className="px-1 text-[10.5px] font-bold text-slate-700">Datos de Búsqueda</legend>
        <div className="flex flex-wrap items-end gap-x-1.5 gap-y-1">
          <Field label="Período" className="w-[82px]"><YearSpinner value={year} onChange={setYear} /></Field>
          <Field label="Mes" className="w-[100px]"><MonthSelector value={month} onChange={setMonth} /></Field>
          <Field label="Documento" className="w-[106px]">
            <CodeDescSelector value={document} onChange={setDocument} options={DOCUMENT_OPTIONS} allLabel="(Todos)" />
          </Field>
          <Field label="Tipo" className="w-[76px]">
            <CodeDescSelector value={type} onChange={setType} options={TYPE_OPTIONS} allLabel="(Todos)" />
          </Field>
          <Field label="Oficina" className="w-[92px]">
            <CodeDescSelector value={office} onChange={setOffice} options={OFFICE_OPTIONS} allLabel="(Todas)" />
          </Field>
          <Field label="Almacén" className="w-[96px]">
            <CodeDescSelector value={warehouse} onChange={setWarehouse} options={WAREHOUSE_OPTIONS} allLabel="(Todos)" />
          </Field>
          <div className="flex w-[132px] flex-col gap-0.5">
            <span className="text-[10.5px] font-medium leading-tight text-slate-600">Cliente</span>
            <div className="flex items-center gap-0.5">
              <input
                className={inp}
                value={client}
                onChange={(event) => setClient(event.target.value)}
                onKeyDown={(event) => {
                  if (event.key === "Enter") applyClientSearch();
                }}
              />
              <button className={iconBtn} type="button" title="Buscar cliente" onClick={applyClientSearch}><Search className="h-3 w-3" /></button>
              <button className={iconBtn} type="button" title="Limpiar cliente" onClick={clearClientSearch}><Eraser className="h-3 w-3" /></button>
            </div>
          </div>
          <Field label="#OT" className="w-[50px]">
            <input className={`${inp} text-center font-mono`} value={workOrder} onChange={(event) => setWorkOrder(event.target.value)} />
          </Field>
          <Field label="Número" className="w-[62px]">
            <input
              className={`${inp} text-center font-mono`}
              value={number}
              onChange={(event) => setNumber(event.target.value)}
              onKeyDown={(event) => {
                if (event.key === "Enter") applyNumberSearch();
              }}
            />
          </Field>
          <button type="button" className={btn} onClick={applyNumberSearch}>
            <Search className="h-3.5 w-3.5" />Buscar
          </button>
        </div>
      </fieldset>

      <div className="flex-1 min-h-0 overflow-auto p-1.5">
        <div className="border border-slate-400/60 bg-white rounded-sm h-full overflow-auto">
          <table className="w-full min-w-[790px] text-[11.5px]">
            <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 sticky top-0 z-10">
              <tr>
                {["Serie", "Número", "Fecha", "Nro.Fact.", "# OT", "Cliente", "Mon.", "Total", "Est."].map((header) => (
                  <th key={header} className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">
                    {header}
                  </th>
                ))}
              </tr>
            </thead>
            <tbody>
              {Array.from({ length: Math.max(16, visibleRows.length) }, (_, index) => {
                const row = visibleRows[index];
                return (
                  <tr key={row ? `${row.serie}-${row.numero}` : `empty-${index}`} className={index % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]"}>
                    <td className="h-[20px] border border-blue-200 px-2 font-mono">{row?.serie}</td>
                    <td className="h-[20px] border border-blue-200 px-2 font-mono">{row?.numero}</td>
                    <td className="h-[20px] border border-blue-200 px-2">{row?.fecha}</td>
                    <td className="h-[20px] border border-blue-200 px-2 font-mono">{row?.nroFactura}</td>
                    <td className="h-[20px] border border-blue-200 px-2 font-mono">{row?.ordenTrabajo}</td>
                    <td className="h-[20px] border border-blue-200 px-2">{row?.cliente}</td>
                    <td className="h-[20px] border border-blue-200 px-2 text-center">{row?.moneda}</td>
                    <td className="h-[20px] border border-blue-200 px-2 text-right font-mono">{row?.total}</td>
                    <td className="h-[20px] border border-blue-200 px-2">{row?.estado}</td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        </div>
      </div>

      <div className="shrink-0 border-t border-slate-400/50 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-0.5 text-[11px] text-slate-700 text-center font-medium flex items-center justify-center whitespace-nowrap overflow-hidden">
        Registros : {visibleRows.length}
      </div>
    </div>
  );
}

export function ConsultaDocumentosVentaWindow() {
  return <ConsultaDocumentosVentaList />;
}

export function DocumentoConsulta({ title = "Documento Consulta" }: { title?: string }) {
  return <DocumentoConsultaList title={title} />;
}
export function DocumentoConsultaList({ title = "Documento Consulta " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
export function ConsultaDocumentosVentaList({ title = "Consulta Documentos Venta" }: { title?: string }) {
  return <DocumentosList />;
}
