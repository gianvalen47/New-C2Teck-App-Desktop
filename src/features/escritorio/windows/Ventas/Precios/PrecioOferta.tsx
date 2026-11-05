import { useMemo, useState } from "react";
import {
  Check,
  Eye,
  LogOut,
  Pencil,
  Plus,
  Printer,
  RefreshCw,
  Search,
  ThumbsDown,
  ThumbsUp,
  Trash2,
  Undo2,
} from "lucide-react";
import { toast } from "sonner";
import { btnPrimary, iconBtn, inp, tbSep } from "@/features/escritorio/windows/uiStyles";
import {
  CodeDescSelector,
  type CodeDescOption,
} from "@/features/escritorio/windows/shared/SearchFieldControls";
import { SortableTable } from "@/components/ui/sortable-table";

type PrecioOfertaRow = {
  codigo: string;
  nombre: string;
  rubro: string;
  precioDolar: string;
  precioSol: string;
  observacion: string;
  fechaVencimiento: string;
  estado: string;
};

const RUBRO_OPTIONS: CodeDescOption[] = [
  { code: "00", label: "(Todos)", value: "" },
  { code: "01", label: "REPUESTOS", value: "REPUESTOS" },
  { code: "02", label: "SERVICIOS", value: "SERVICIOS" },
  { code: "03", label: "LUBRICANTES", value: "LUBRICANTES" },
];

const STATUS_OPTIONS: CodeDescOption[] = [
  { code: "0", label: "(Todos)", value: "" },
  { code: "1", label: "Generado", value: "Generado" },
  { code: "2", label: "Enviado", value: "Enviado" },
  { code: "3", label: "Aprobado x Jefe Area", value: "Aprobado x Jefe Area" },
  { code: "4", label: "Aprobado", value: "Aprobado" },
  { code: "5", label: "Rechazado", value: "Rechazado" },
  { code: "6", label: "Vencido", value: "Vencido" },
];

const COLUMNS = [
  "Cód.",
  "Nombre",
  "Rubro",
  "Precio Dol.",
  "Precio Sol.",
  "Observación",
  "Fec. Venc.",
  "Estado",
];

export function PrecioOfertaList() {
  const [rows] = useState<PrecioOfertaRow[]>([]);
  const [rubro, setRubro] = useState("");
  const [itemSearch, setItemSearch] = useState("");
  const [appliedItemSearch, setAppliedItemSearch] = useState("");
  const [status, setStatus] = useState("");

  const visibleRows = useMemo(() => rows.filter((row) => {
    if (rubro && row.rubro !== rubro) return false;
    if (status && row.estado !== status) return false;
    if (appliedItemSearch && !row.nombre.toLowerCase().includes(appliedItemSearch)) return false;
    return true;
  }), [rows, rubro, status, appliedItemSearch]);

  const search = () => setAppliedItemSearch(itemSearch.trim().toLowerCase());
  const clearItem = () => {
    setItemSearch("");
    setAppliedItemSearch("");
  };
  const notImplemented = (action: string) => toast.info(`${action} requiere conexión al servicio de listas de oferta.`);

  return (
    <div className="relative flex h-full min-h-0 flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex shrink-0 items-center gap-1 overflow-x-auto border-b border-slate-400/50 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] px-2 py-1.5">
        <button type="button" className={iconBtn} title="Imprimir" onClick={() => notImplemented("Imprimir")}>
          <Printer className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Nuevo" onClick={() => notImplemented("Crear oferta")}>
          <Plus className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Mostrar" onClick={() => notImplemented("Mostrar oferta")}>
          <Eye className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Eliminar" onClick={() => notImplemented("Eliminar oferta")}>
          <Trash2 className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Aprobar" onClick={() => notImplemented("Aprobar oferta")}>
          <ThumbsUp className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Rechazar" onClick={() => notImplemented("Rechazar oferta")}>
          <ThumbsDown className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Modificar validez" onClick={() => notImplemented("Modificar validez")}>
          <Pencil className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Ver estados" onClick={() => notImplemented("Consultar estados")}>
          <Check className="h-4 w-4" />
        </button>
        {tbSep}
        <button
          type="button"
          className={iconBtn}
          title="Actualizar"
          onClick={() => {
            setAppliedItemSearch("");
            setItemSearch("");
          }}
        >
          <RefreshCw className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Salir">
          <LogOut className="h-4 w-4" />
        </button>
      </div>

      <fieldset className="mx-1.5 mt-1.5 shrink-0 border border-[#7A96B4] bg-[#ECF1F7] px-2 pb-1.5 pt-0">
        <legend className="px-1 text-[10.5px] font-bold text-slate-700">Datos de Búsqueda</legend>
        <div className="flex flex-wrap items-end gap-x-3 gap-y-1">
          <label className="flex w-[180px] flex-col gap-0.5">
            <span className="text-[10.5px] font-semibold text-slate-800">Rubro</span>
            <CodeDescSelector value={rubro} onChange={setRubro} options={RUBRO_OPTIONS.slice(1)} allLabel="(Todos)" />
          </label>

          <div className="flex w-[300px] flex-col gap-0.5">
            <label htmlFor="precio-oferta-item" className="text-[10.5px] font-semibold text-slate-800">
              Mercadería
            </label>
            <div className="flex items-center gap-1">
              <input
                id="precio-oferta-item"
                className={inp}
                value={itemSearch}
                onChange={(event) => setItemSearch(event.target.value)}
                onKeyDown={(event) => {
                  if (event.key === "Enter") search();
                }}
              />
              <button type="button" className={iconBtn} title="Buscar mercadería" onClick={search}>
                <Search className="h-3.5 w-3.5" />
              </button>
              <button type="button" className={iconBtn} title="Limpiar mercadería" onClick={clearItem}>
                <Undo2 className="h-3.5 w-3.5" />
              </button>
            </div>
          </div>

          <label className="flex w-[160px] flex-col gap-0.5">
            <span className="text-center text-[10.5px] font-semibold text-slate-800">Estado</span>
            <CodeDescSelector value={status} onChange={setStatus} options={STATUS_OPTIONS.slice(1)} allLabel="(Todos)" />
          </label>

          <button type="button" className={btnPrimary} onClick={search}>
            <Search className="h-3.5 w-3.5" />
            Buscar
          </button>
        </div>
      </fieldset>

      <div className="min-h-0 flex-1 overflow-auto p-1.5">
        <div className="h-full overflow-auto rounded-sm border border-slate-400/60 bg-white">
          <SortableTable className="w-full min-w-[860px] border-collapse text-[11px]">
            <colgroup>
              <col className="w-[7%]" />
              <col className="w-[31%]" />
              <col className="w-[10%]" />
              <col className="w-[10%]" />
              <col className="w-[10%]" />
              <col className="w-[17%]" />
              <col className="w-[9%]" />
              <col className="w-[12%]" />
            </colgroup>
            <thead className="sticky top-0 z-10 bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800">
              <tr>
                {COLUMNS.map((column) => (
                  <th key={column} className="border border-slate-300/80 px-2 py-1 text-center font-semibold whitespace-nowrap">
                    {column}
                  </th>
                ))}
              </tr>
            </thead>
            <tbody>
              {Array.from({ length: Math.max(16, visibleRows.length) }, (_, index) => {
                const row = visibleRows[index];
                return (
                  <tr key={row ? `${row.codigo}-${index}` : `empty-${index}`} className={index % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]"}>
                    <td className="h-[20px] border border-slate-200 px-2 font-mono">{row?.codigo}</td>
                    <td className="h-[20px] border border-slate-200 px-2">{row?.nombre}</td>
                    <td className="h-[20px] border border-slate-200 px-2">{row?.rubro}</td>
                    <td className="h-[20px] border border-slate-200 px-2 text-right font-mono">{row?.precioDolar}</td>
                    <td className="h-[20px] border border-slate-200 px-2 text-right font-mono">{row?.precioSol}</td>
                    <td className="h-[20px] border border-slate-200 px-2">{row?.observacion}</td>
                    <td className="h-[20px] border border-slate-200 px-2">{row?.fechaVencimiento}</td>
                    <td className="h-[20px] border border-slate-200 px-2">{row?.estado}</td>
                  </tr>
                );
              })}
            </tbody>
          </SortableTable>
        </div>
      </div>

      <div className="flex shrink-0 items-center justify-center border-t border-slate-400/50 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-0.5 text-[11px] font-medium text-slate-700">
        Registros : {visibleRows.length}
      </div>
    </div>
  );
}

export function PrecioOferta() {
  return <PrecioOfertaList />;
}
