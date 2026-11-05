import { useMemo, useState } from "react";
import {
  Eye,
  LogOut,
  Pencil,
  Plus,
  Printer,
  RefreshCw,
  Save,
  Search,
  Trash2,
  Undo2,
} from "lucide-react";
import { toast } from "sonner";
import { btn, btnPrimary, iconBtn, inp, tbSep } from "@/features/escritorio/windows/uiStyles";
import { SortableTable } from "@/components/ui/sortable-table";

type PrecioFabricanteRow = {
  numeroLista: string;
  moneda: string;
  listaPrecio: string;
  nombre: string;
  observacion: string;
  fechaVencimiento: string;
  vigente: boolean;
};

type DialogMode = "new" | "view";

const PRICE_LISTS = ["TOGNUM - MTU"];
const COLUMNS = ["Nombre", "Mon.", "Observación", "Fec. Venc.", "Vigente"];

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

function PrecioFabricanteDialog({
  mode,
  initialRow,
  onClose,
  onSave,
}: {
  mode: DialogMode;
  initialRow: PrecioFabricanteRow | null;
  onClose: () => void;
  onSave: (row: PrecioFabricanteRow) => boolean;
}) {
  const [numeroLista, setNumeroLista] = useState(initialRow?.numeroLista ?? "");
  const [moneda, setMoneda] = useState(initialRow?.moneda ?? "USD");
  const [listaPrecio, setListaPrecio] = useState(initialRow?.listaPrecio ?? PRICE_LISTS[0]);
  const [nombre, setNombre] = useState(initialRow?.nombre ?? "");
  const [observacion, setObservacion] = useState(initialRow?.observacion ?? "");
  const [fechaVencimiento, setFechaVencimiento] = useState(initialRow?.fechaVencimiento ?? getLocalDateValue());
  const [vigente, setVigente] = useState(initialRow?.vigente ?? true);
  const [editing, setEditing] = useState(mode === "new");
  const isNew = mode === "new";
  const editable = isNew || editing;

  const save = () => {
    if (!numeroLista.trim() || !nombre.trim()) {
      toast.error("Ingrese el número y el nombre de la lista.");
      return;
    }

    if (onSave({
      numeroLista: numeroLista.trim(),
      moneda,
      listaPrecio,
      nombre: nombre.trim(),
      observacion: observacion.trim(),
      fechaVencimiento,
      vigente,
    })) {
      onClose();
    }
  };

  const cancelOrEdit = () => {
    if (isNew) {
      onClose();
      return;
    }
    if (!editing) {
      setEditing(true);
      return;
    }

    setNumeroLista(initialRow?.numeroLista ?? "");
    setMoneda(initialRow?.moneda ?? "USD");
    setListaPrecio(initialRow?.listaPrecio ?? PRICE_LISTS[0]);
    setNombre(initialRow?.nombre ?? "");
    setObservacion(initialRow?.observacion ?? "");
    setFechaVencimiento(initialRow?.fechaVencimiento ?? "");
    setVigente(initialRow?.vigente ?? true);
    setEditing(false);
  };

  return (
    <div className="absolute inset-0 z-30 flex items-center justify-center bg-slate-900/35 p-2 sm:p-4">
      <section
        role="dialog"
        aria-modal="true"
        aria-labelledby="precio-fabricante-dialog-title"
        className="flex max-h-full w-full max-w-[730px] flex-col overflow-hidden border border-slate-400 bg-[#F3F6FA] shadow-xl"
      >
        <header className="flex shrink-0 items-center justify-between border-b border-slate-400/50 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] px-3 py-1.5">
          <h2 id="precio-fabricante-dialog-title" className="text-[11px] font-semibold text-slate-700">
            {isNew ? "Registrar nueva Lista Precio Fabricante" : `Lista Precio Fabricante N° "${numeroLista}"`}
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
          <button
            type="button"
            className={iconBtn}
            title={editable ? "Deshacer cambios" : "Editar"}
            onClick={cancelOrEdit}
          >
            {editable ? <Undo2 className="h-4 w-4" /> : <Pencil className="h-4 w-4" />}
          </button>
        </div>

        <fieldset className="m-2 border border-[#7A96B4] px-3 pb-3 pt-1">
          <legend className="px-1 text-[10.5px] font-bold text-slate-700">Cabecera</legend>
          <div className="grid gap-x-4 gap-y-3 sm:grid-cols-[1fr_1fr_1.2fr]">
            <label className="flex items-center gap-2">
              <span className="w-[82px] shrink-0 text-[11px] font-semibold text-slate-800">N° Lista</span>
              <input
                className={`${inp} w-[68px]`}
                value={numeroLista}
                disabled={!isNew}
                onChange={(event) => setNumeroLista(event.target.value)}
              />
            </label>

            <label className="flex items-center gap-2">
              <span className="text-[11px] font-semibold text-slate-800">Moneda</span>
              <select
                className={`${inp} w-[70px]`}
                value={moneda}
                disabled={!editable}
                onChange={(event) => setMoneda(event.target.value)}
              >
                <option value="USD">USD</option>
                <option value="PEN">S/</option>
              </select>
            </label>

            <label className="flex min-w-0 items-center gap-2">
              <span className="shrink-0 text-[11px] font-semibold text-slate-800">Lista Precio</span>
              <select
                className={`${inp} min-w-0 flex-1`}
                value={listaPrecio}
                disabled={!editable}
                onChange={(event) => setListaPrecio(event.target.value)}
              >
                {PRICE_LISTS.map((priceList) => <option key={priceList}>{priceList}</option>)}
              </select>
            </label>

            <label className="flex min-w-0 items-center gap-2 sm:col-span-3">
              <span className="w-[82px] shrink-0 text-[11px] font-semibold text-slate-800">Nombre</span>
              <input
                className={`${inp} min-w-0 flex-1`}
                value={nombre}
                disabled={!editable}
                onChange={(event) => setNombre(event.target.value)}
              />
            </label>

            <label className="flex min-w-0 items-start gap-2 sm:col-span-3">
              <span className="w-[82px] shrink-0 pt-1 text-[11px] font-semibold text-slate-800">Observación</span>
              <textarea
                className={`${inp} h-[42px] min-w-0 flex-1 resize-y`}
                value={observacion}
                disabled={!editable}
                onChange={(event) => setObservacion(event.target.value)}
              />
            </label>

            <label className="flex items-center gap-2 sm:col-span-2">
              <span className="shrink-0 text-[11px] font-semibold text-slate-800">Fec. Vencimiento :</span>
              <input
                className={`${inp} w-[120px]`}
                type="date"
                value={fechaVencimiento}
                disabled={!editable}
                onChange={(event) => setFechaVencimiento(event.target.value)}
              />
            </label>

            <label className="flex items-center justify-end gap-2 text-[11px] font-semibold text-slate-800">
              Vigente
              <input
                type="checkbox"
                checked={vigente}
                disabled={!editable}
                onChange={(event) => setVigente(event.target.checked)}
              />
            </label>
          </div>
        </fieldset>
      </section>
    </div>
  );
}

export function PrecioFabricantesList() {
  const [rows, setRows] = useState<PrecioFabricanteRow[]>([]);
  const [filterList, setFilterList] = useState("");
  const [appliedFilter, setAppliedFilter] = useState("");
  const [selectedNumber, setSelectedNumber] = useState("");
  const [dialog, setDialog] = useState<{ mode: DialogMode; row: PrecioFabricanteRow | null } | null>(null);

  const visibleRows = useMemo(
    () => appliedFilter ? rows.filter((row) => row.listaPrecio === appliedFilter) : rows,
    [rows, appliedFilter],
  );
  const selectedRow = visibleRows.find((row) => row.numeroLista === selectedNumber) ?? null;

  const showSelected = () => {
    if (!selectedRow) {
      toast.info("Seleccione una lista de precio fabricante para mostrar.");
      return;
    }
    setDialog({ mode: "view", row: selectedRow });
  };

  const saveRow = (row: PrecioFabricanteRow) => {
    const duplicate = rows.some((item) => item.numeroLista === row.numeroLista
      && item.numeroLista !== dialog?.row?.numeroLista);
    if (duplicate) {
      toast.error(`Ya existe una lista fabricante con el número ${row.numeroLista}.`);
      return false;
    }

    setRows((current) => {
      const exists = current.some((item) => item.numeroLista === row.numeroLista);
      return exists
        ? current.map((item) => item.numeroLista === row.numeroLista ? row : item)
        : [...current, row];
    });
    setSelectedNumber(row.numeroLista);
    return true;
  };

  const deleteSelected = () => {
    if (!selectedRow) {
      toast.info("Seleccione una lista para eliminar.");
      return;
    }
    setRows((current) => current.filter((row) => row.numeroLista !== selectedRow.numeroLista));
    setSelectedNumber("");
  };

  return (
    <div className="relative flex h-full min-h-0 flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex shrink-0 items-center gap-1 overflow-x-auto border-b border-slate-400/50 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] px-2 py-1.5">
        <button type="button" className={iconBtn} title="Imprimir" onClick={() => toast.info("No hay listas fabricante para imprimir.")}>
          <Printer className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Nuevo" onClick={() => setDialog({ mode: "new", row: null })}>
          <Plus className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Mostrar" onClick={showSelected}>
          <Eye className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Eliminar" onClick={deleteSelected}>
          <Trash2 className="h-4 w-4" />
        </button>
        {tbSep}
        <button
          type="button"
          className={iconBtn}
          title="Actualizar"
          onClick={() => {
            setAppliedFilter("");
            setFilterList("");
            setSelectedNumber("");
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
        <div className="flex flex-wrap items-end gap-x-2 gap-y-1 px-1">
          <label className="flex w-[240px] items-center gap-2">
            <span className="shrink-0 text-[10.5px] font-semibold text-slate-800">Lista Precio :</span>
            <select className={inp} value={filterList} onChange={(event) => setFilterList(event.target.value)}>
              <option value="">(Todos)</option>
              {PRICE_LISTS.map((priceList) => <option key={priceList} value={priceList}>{priceList}</option>)}
            </select>
          </label>
          <button type="button" className={btnPrimary} onClick={() => setAppliedFilter(filterList)}>
            <Search className="h-3.5 w-3.5" />
            Buscar
          </button>
        </div>
      </fieldset>

      <div className="min-h-0 flex-1 overflow-auto p-1.5">
        <div className="h-full overflow-auto rounded-sm border border-slate-400/60 bg-white">
          <SortableTable className="w-full min-w-[680px] border-collapse text-[11px]">
            <colgroup>
              <col className="w-[24%]" />
              <col className="w-[7%]" />
              <col className="w-[41%]" />
              <col className="w-[14%]" />
              <col className="w-[14%]" />
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
              {visibleRows.length === 0 ? (
                Array.from({ length: 12 }, (_, index) => (
                  <tr key={`empty-${index}`} className={index % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]"}>
                    {COLUMNS.map((column) => <td key={column} className="h-[20px] border border-slate-200 px-2" />)}
                  </tr>
                ))
              ) : visibleRows.map((row, index) => (
                <tr
                  key={row.numeroLista}
                  className={`cursor-pointer ${row.numeroLista === selectedNumber ? "bg-[#DCE8F7] font-semibold text-[#1F3E68]" : index % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]"}`}
                  onClick={() => setSelectedNumber(row.numeroLista)}
                  onDoubleClick={showSelected}
                >
                  <td className="h-[20px] border border-slate-200 px-2">{row.nombre}</td>
                  <td className="h-[20px] border border-slate-200 px-2 text-center">{row.moneda}</td>
                  <td className="h-[20px] border border-slate-200 px-2" title={row.observacion}>{row.observacion}</td>
                  <td className="h-[20px] border border-slate-200 px-2 text-center">{formatDate(row.fechaVencimiento)}</td>
                  <td className="h-[20px] border border-slate-200 px-2 text-center">{row.vigente ? "Sí" : "No"}</td>
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
        <PrecioFabricanteDialog
          key={`${dialog.mode}-${dialog.row?.numeroLista ?? "new"}`}
          mode={dialog.mode}
          initialRow={dialog.row}
          onClose={() => setDialog(null)}
          onSave={saveRow}
        />
      )}
    </div>
  );
}

export function PrecioFabricantes() {
  return <PrecioFabricantesList />;
}
