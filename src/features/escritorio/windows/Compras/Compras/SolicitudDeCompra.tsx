import { useMemo, useState } from "react";
import {
  Archive,
  Ban,
  Check,
  ClipboardList,
  Eye,
  FileText,
  LogOut,
  Plus,
  Printer,
  RefreshCw,
  Save,
  Search,
  Trash2,
  Undo2,
} from "lucide-react";
import { toast } from "sonner";
import { btnPrimary, iconBtn, inp, tbSep } from "@/features/escritorio/windows/uiStyles";
import {
  CodeDescSelector,
  type CodeDescOption,
  YearSpinner,
} from "@/features/escritorio/windows/shared/SearchFieldControls";
import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";
import { SortableTable } from "@/components/ui/sortable-table";

type SolicitudCompraRow = {
  numero: string;
  fecha: string;
  area: string;
  solicitante: string;
  observacion: string;
  estado: string;
};

type DialogMode = "new" | "view";

const AREA_OPTIONS: CodeDescOption[] = [
  { code: "01", label: "Dirección y Gerencia General", value: "Dirección y Gerencia General" },
  { code: "02", label: "Administración", value: "Administración" },
  { code: "03", label: "Almacén", value: "Almacén" },
  { code: "04", label: "Servicios Técnicos", value: "Servicios Técnicos" },
  { code: "05", label: "Ventas", value: "Ventas" },
];

const STATUS_OPTIONS: CodeDescOption[] = [
  { code: "01", label: "Pendiente", value: "Pendiente" },
  { code: "02", label: "Generada", value: "Generada" },
  { code: "03", label: "Aprobada", value: "Aprobada" },
  { code: "04", label: "Anulada", value: "Anulada" },
];

const COLUMNS = ["Número", "Fecha", "Solicitante", "Observación", "Est."];

function getLocalDateValue() {
  const today = new Date();
  const month = String(today.getMonth() + 1).padStart(2, "0");
  const day = String(today.getDate()).padStart(2, "0");
  return `${today.getFullYear()}-${month}-${day}`;
}

function formatDate(value: string) {
  if (!value) return "";
  const [year, month, day] = value.split("-");
  return year && month && day ? `${day}/${month}/${year}` : value;
}

function SolicitudCompraDialog({
  mode,
  initialRow,
  onClose,
  onSave,
}: {
  mode: DialogMode;
  initialRow: SolicitudCompraRow | null;
  onClose: () => void;
  onSave: (row: SolicitudCompraRow) => boolean;
}) {
  const [numero, setNumero] = useState(initialRow?.numero ?? "");
  const [fecha, setFecha] = useState(initialRow?.fecha ?? getLocalDateValue());
  const [area, setArea] = useState(initialRow?.area ?? AREA_OPTIONS[0].value);
  const [solicitante, setSolicitante] = useState(initialRow?.solicitante ?? "");
  const [observacion, setObservacion] = useState(initialRow?.observacion ?? "");
  const [estado, setEstado] = useState(initialRow?.estado ?? "Pendiente");
  const [editing, setEditing] = useState(mode === "new");
  const isNew = mode === "new";
  const editable = isNew || editing;

  const save = () => {
    if (!area || !solicitante.trim()) {
      toast.error("Seleccione el área e ingrese el solicitante.");
      return;
    }

    if (onSave({
      numero: numero.trim(),
      fecha,
      area,
      solicitante: solicitante.trim(),
      observacion: observacion.trim(),
      estado,
    })) {
      onClose();
    }
  };

  const editOrUndo = () => {
    if (isNew) {
      onClose();
      return;
    }
    if (!editing) {
      setEditing(true);
      return;
    }
    setNumero(initialRow?.numero ?? "");
    setFecha(initialRow?.fecha ?? "");
    setArea(initialRow?.area ?? AREA_OPTIONS[0].value);
    setSolicitante(initialRow?.solicitante ?? "");
    setObservacion(initialRow?.observacion ?? "");
    setEstado(initialRow?.estado ?? "Pendiente");
    setEditing(false);
  };

  return (
    <div className="absolute inset-0 z-30 flex items-center justify-center bg-slate-900/35 p-2 sm:p-4">
      <section
        role="dialog"
        aria-modal="true"
        aria-labelledby="solicitud-compra-dialog-title"
        className="flex max-h-full w-full max-w-[740px] flex-col overflow-hidden border border-slate-400 bg-[#F3F6FA] shadow-xl"
      >
        <header className="flex shrink-0 items-center justify-between border-b border-slate-400/50 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] px-3 py-1.5">
          <h2 id="solicitud-compra-dialog-title" className="text-[11px] font-semibold text-slate-700">
            {isNew ? "Nueva Solicitud de Compra" : `Solicitud de Compra N° "${numero}"`}
          </h2>
          <button type="button" className={iconBtn} title="Cerrar" onClick={onClose}>
            <LogOut className="h-4 w-4" />
          </button>
        </header>

        <div className="flex shrink-0 items-center gap-1 border-b border-slate-300 px-2 py-1">
          <button type="button" className={iconBtn} title="Guardar" onClick={save}>
            <Save className="h-4 w-4" />
          </button>
          {tbSep}
          <button type="button" className={iconBtn} title={editable ? "Deshacer" : "Editar"} onClick={editOrUndo}>
            {editable ? <Undo2 className="h-4 w-4" /> : <FileText className="h-4 w-4" />}
          </button>
          {tbSep}
          <button
            type="button"
            className={iconBtn}
            title="Buscar solicitante"
            onClick={() => toast.info("La búsqueda de solicitantes requiere conectar el servicio de personal.")}
          >
            <Search className="h-4 w-4" />
          </button>
        </div>

        <fieldset className="m-2 border border-[#7A96B4] px-3 pb-3 pt-1">
          <legend className="px-1 text-[10.5px] font-bold text-slate-700">Datos de la Solicitud</legend>
          <div className="grid gap-x-3 gap-y-3 sm:grid-cols-[1fr_1.2fr_1.8fr]">
            <label className="flex items-center gap-2">
              <span className="shrink-0 text-[11px] font-semibold text-slate-800">Número :</span>
              <input
                className={`${inp} min-w-0`}
                value={numero}
                placeholder={isNew ? "Automático" : ""}
                disabled
                onChange={(event) => setNumero(event.target.value)}
              />
            </label>

            <label className="flex items-center gap-2">
              <span className="shrink-0 text-[11px] font-semibold text-slate-800">Fecha :</span>
              <input
                className={`${inp} min-w-0`}
                type="date"
                value={fecha}
                disabled={!editable}
                onChange={(event) => setFecha(event.target.value)}
              />
            </label>

            <label className="flex min-w-0 items-center gap-2">
              <span className="shrink-0 text-[11px] font-semibold text-slate-800">Área :</span>
              <div className="min-w-0 flex-1">
                <CodeDescSelector
                  value={area}
                  onChange={setArea}
                  options={AREA_OPTIONS}
                  allLabel="(Todos)"
                  width="w-[280px]"
                  disabled={!editable}
                />
              </div>
            </label>

            <label className="flex min-w-0 items-center gap-2 sm:col-span-3">
              <span className="shrink-0 text-[11px] font-semibold text-slate-800">Solicitante :</span>
              <input
                className={`${inp} min-w-0 flex-1`}
                value={solicitante}
                disabled={!editable}
                onChange={(event) => setSolicitante(event.target.value)}
              />
              <button
                type="button"
                className={iconBtn}
                title="Buscar solicitante"
                disabled={!editable}
                onClick={() => toast.info("La búsqueda de solicitantes requiere conectar el servicio de personal.")}
              >
                <Search className="h-3.5 w-3.5" />
              </button>
            </label>

            <label className="flex min-w-0 items-start gap-2 sm:col-span-3">
              <span className="shrink-0 pt-1 text-[11px] font-semibold text-slate-800">Observación :</span>
              <textarea
                className={`${inp} h-[48px] min-w-0 flex-1 resize-y`}
                value={observacion}
                disabled={!editable}
                onChange={(event) => setObservacion(event.target.value)}
              />
              <button
                type="button"
                className={`${iconBtn} mt-1`}
                title="Editar observación"
                disabled={!editable}
                onClick={() => toast.info("Escriba la observación en el campo de texto.")}
              >
                <FileText className="h-3.5 w-3.5" />
              </button>
            </label>
          </div>
          {!isNew && (
            <div className="mt-2 text-right text-[11px] font-semibold text-slate-700">
              Estado: {estado}
            </div>
          )}
        </fieldset>
      </section>
    </div>
  );
}

export function SolicitudCompraList() {
  const currentYear = String(new Date().getFullYear());
  const [rows, setRows] = useState<SolicitudCompraRow[]>([]);
  const [year, setYear] = useState(currentYear);
  const [area, setArea] = useState("");
  const [status, setStatus] = useState("");
  const [numberSearch, setNumberSearch] = useState("");
  const [appliedFilters, setAppliedFilters] = useState({
    year: currentYear,
    area: "",
    status: "",
    number: "",
  });
  const [selectedNumber, setSelectedNumber] = useState("");
  const [dialog, setDialog] = useState<{ mode: DialogMode; row: SolicitudCompraRow | null } | null>(null);

  const visibleRows = useMemo(() => rows.filter((row) => {
    if (appliedFilters.year && !row.fecha.startsWith(`${appliedFilters.year}-`)) return false;
    if (appliedFilters.area && row.area !== appliedFilters.area) return false;
    if (appliedFilters.status && row.estado !== appliedFilters.status) return false;
    if (appliedFilters.number && !row.numero.toLowerCase().includes(appliedFilters.number)) return false;
    return true;
  }), [rows, appliedFilters]);
  const selectedRow = visibleRows.find((row) => row.numero === selectedNumber) ?? null;

  const search = () => {
    setAppliedFilters({
      year,
      area,
      status,
      number: numberSearch.trim().toLowerCase(),
    });
  };

  const openSelected = () => {
    if (!selectedRow) {
      toast.info("Seleccione una solicitud para mostrar.");
      return;
    }
    setDialog({ mode: "view", row: selectedRow });
  };

  const saveRow = (row: SolicitudCompraRow) => {
    const numero = row.numero || String(rows.reduce((maximum, item) => Math.max(maximum, Number(item.numero) || 0), 0) + 1);
    const savedRow = { ...row, numero };
    const duplicate = rows.some((item) => item.numero === numero && item.numero !== dialog?.row?.numero);
    if (duplicate) {
      toast.error(`Ya existe una solicitud con el número ${numero}.`);
      return false;
    }
    setRows((current) => {
      const exists = current.some((item) => item.numero === numero);
      return exists
        ? current.map((item) => item.numero === numero ? savedRow : item)
        : [...current, savedRow];
    });
    setSelectedNumber(numero);
    return true;
  };

  const setSelectedStatus = (nextStatus: string) => {
    if (!selectedRow) {
      toast.info("Seleccione una solicitud para actualizar su estado.");
      return;
    }
    setRows((current) => current.map((row) => (
      row.numero === selectedRow.numero ? { ...row, estado: nextStatus } : row
    )));
  };

  const deleteSelected = () => {
    if (!selectedRow) {
      toast.info("Seleccione una solicitud para eliminar.");
      return;
    }
    setRows((current) => current.filter((row) => row.numero !== selectedRow.numero));
    setSelectedNumber("");
  };

  const refresh = () => {
    setYear(currentYear);
    setArea("");
    setStatus("");
    setNumberSearch("");
    setAppliedFilters({ year: currentYear, area: "", status: "", number: "" });
    setSelectedNumber("");
  };

  return (
    <div className="relative flex h-full min-h-0 flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex shrink-0 items-center gap-1 overflow-x-auto border-b border-slate-400/50 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] px-2 py-1.5">
        <button type="button" className={iconBtn} title="Imprimir" onClick={() => toast.info("No hay solicitudes para imprimir.")}>
          <Printer className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Nueva solicitud" onClick={() => setDialog({ mode: "new", row: null })}>
          <Plus className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Mostrar" onClick={openSelected}>
          <Eye className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Eliminar" onClick={deleteSelected}>
          <Trash2 className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Generar" onClick={() => setSelectedStatus("Generada")}>
          <ClipboardList className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Aprobar" onClick={() => setSelectedStatus("Aprobada")}>
          <Check className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Estados" onClick={openSelected}>
          <Search className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Actualizar" onClick={refresh}>
          <RefreshCw className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Archivos" onClick={() => toast.info("La consulta de archivos requiere conectar el servicio de solicitudes.")}>
          <Archive className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Anular" onClick={() => setSelectedStatus("Anulada")}>
          <Ban className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Salir">
          <LogOut className="h-4 w-4" />
        </button>
      </div>

      <fieldset className="mx-1.5 mt-1.5 shrink-0 border border-[#7A96B4] bg-[#ECF1F7] px-2 pb-1.5 pt-0">
        <legend className="px-1 text-[10.5px] font-bold text-slate-700">Datos de Búsqueda</legend>
        <div className="flex flex-wrap items-end justify-center gap-x-4 gap-y-1">
          <label className="flex w-[82px] flex-col gap-0.5">
            <span className="text-center text-[10.5px] font-semibold text-slate-800">Año</span>
            <YearSpinner value={year} onChange={setYear} />
          </label>
          <label className="flex w-[170px] flex-col gap-0.5">
            <span className="text-center text-[10.5px] font-semibold text-slate-800">Área</span>
            <CodeDescSelector value={area} onChange={setArea} options={AREA_OPTIONS} allLabel="(Todos)" width="w-[280px]" />
          </label>
          <label className="flex w-[150px] flex-col gap-0.5">
            <span className="text-center text-[10.5px] font-semibold text-slate-800">Estados</span>
            <CodeDescSelector value={status} onChange={setStatus} options={STATUS_OPTIONS} allLabel="(Todos)" width="w-[200px]" />
          </label>
          <label className="flex w-[90px] flex-col gap-0.5">
            <span className="text-center text-[10.5px] font-semibold text-slate-800">Número</span>
            <input
              className={`${inp} text-center`}
              value={numberSearch}
              onChange={(event) => setNumberSearch(event.target.value)}
              onKeyDown={(event) => {
                if (event.key === "Enter") search();
              }}
            />
          </label>
          <button type="button" className={btnPrimary} onClick={search}>
            <Search className="h-3.5 w-3.5" />
            Buscar
          </button>
        </div>
      </fieldset>

      <div className="min-h-0 flex-1 overflow-auto p-1.5">
        <div className="h-full overflow-auto rounded-sm border border-slate-400/60 bg-white">
          <SortableTable className="w-full min-w-[690px] border-collapse text-[11px]">
            <colgroup>
              <col className="w-[3%]" />
              <col className="w-[8%]" />
              <col className="w-[11%]" />
              <col className="w-[35%]" />
              <col className="w-[29%]" />
              <col className="w-[9%]" />
            </colgroup>
            <thead className="sticky top-0 z-10 bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800">
              <tr>
                <th className="w-6 border border-slate-300/80 px-1 py-1" />
                {COLUMNS.map((column) => (
                  <th key={column} className="border border-slate-300/80 px-2 py-1 text-center font-semibold whitespace-nowrap">
                    {column}
                  </th>
                ))}
              </tr>
            </thead>
            <tbody>
              {visibleRows.length === 0 ? (
                Array.from({ length: 14 }, (_, index) => (
                  <tr key={`empty-${index}`} className={index % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]"}>
                    {Array.from({ length: COLUMNS.length + 1 }, (_, cellIndex) => (
                      <td key={cellIndex} className="h-[20px] border border-slate-200 px-2" />
                    ))}
                  </tr>
                ))
              ) : visibleRows.map((row, index) => (
                <tr
                  key={row.numero}
                  className={`cursor-pointer ${row.numero === selectedNumber ? "bg-[#DCE8F7] font-semibold text-[#1F3E68]" : index % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]"}`}
                  onClick={() => setSelectedNumber(row.numero)}
                  onDoubleClick={openSelected}
                >
                  <td className="h-[20px] border border-slate-200 px-1 text-center">{row.numero === selectedNumber ? "▶" : ""}</td>
                  <td className="h-[20px] border border-slate-200 px-2 font-mono">{row.numero}</td>
                  <td className="h-[20px] border border-slate-200 px-2 text-center">{formatDate(row.fecha)}</td>
                  <td className="h-[20px] border border-slate-200 px-2">{row.solicitante}</td>
                  <td className="h-[20px] border border-slate-200 px-2" title={row.observacion}>{row.observacion}</td>
                  <td className="h-[20px] border border-slate-200 px-2 text-center">{row.estado}</td>
                </tr>
              ))}
            </tbody>
          </SortableTable>
        </div>
      </div>

      <div className="flex shrink-0 items-center justify-center border-t border-slate-400/50 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-0.5 text-[11px] font-medium text-slate-700">
        Registros : {visibleRows.length}
      </div>

      {dialog && (
        <SolicitudCompraDialog
          key={`${dialog.mode}-${dialog.row?.numero ?? "new"}`}
          mode={dialog.mode}
          initialRow={dialog.row}
          onClose={() => setDialog(null)}
          onSave={saveRow}
        />
      )}
    </div>
  );
}

export function SolicitudCompraCompras({ title = "Solicitud Compra Compras" }: { title?: string }) {
  return <SolicitudCompraComprasList title={title} />;
}

export function SolicitudCompraComprasList({ title = "Solicitud Compra Compras " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
