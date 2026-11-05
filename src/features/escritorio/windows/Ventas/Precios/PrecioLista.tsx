import { useMemo, useState } from "react";
import {
  Check,
  Eye,
  LogOut,
  Pencil,
  Plus,
  Printer,
  RefreshCw,
  Save,
  Search,
  Send,
  ThumbsDown,
  ThumbsUp,
  Trash2,
  Undo2,
} from "lucide-react";
import { toast } from "sonner";
import { btn, btnPrimary, iconBtn, inp, tbSep } from "@/features/escritorio/windows/uiStyles";
import { SortableTable } from "@/components/ui/sortable-table";

type PrecioListaDetail = {
  codigo: string;
  descripcion: string;
  precio: string;
  rubro: string;
  estado: string;
  fechaAprobacion: string;
};

type PrecioListaRecipient = {
  nombre: string;
  email: string;
  selected: boolean;
};

type PrecioListaRow = {
  codigo: string;
  nombre: string;
  moneda: string;
  observacion: string;
  fechaVencimiento: string;
  estado: string;
  detalles: PrecioListaDetail[];
  destinatarios: PrecioListaRecipient[];
};

type DialogMode = "new" | "view";

const INITIAL_ROWS: PrecioListaRow[] = [
  {
    codigo: "36",
    nombre: "OTROS / COMPLEMENTOS",
    moneda: "NS",
    observacion: "Productos complementarios externos que no encajan en categorías específicas, pero que son esenciales para la operación y optimización de dispositivos electrónicos.",
    fechaVencimiento: "2024-12-03",
    estado: "Generado",
    detalles: [],
    destinatarios: [{ nombre: "RIOS ROSALES CARLOS", email: "crios@c2teck.com.pe", selected: false }],
  },
  {
    codigo: "37",
    nombre: "CÁMARAS",
    moneda: "NS",
    observacion: "Cámaras de video y accesorios.",
    fechaVencimiento: "2024-12-03",
    estado: "Generado",
    detalles: [],
    destinatarios: [],
  },
  {
    codigo: "38",
    nombre: "REDES DE INTERNET",
    moneda: "NS",
    observacion: "Artículos de redes e internet.",
    fechaVencimiento: "2024-12-03",
    estado: "Generado",
    detalles: [],
    destinatarios: [],
  },
  {
    codigo: "39",
    nombre: "HARDWARE PARA PC",
    moneda: "NS",
    observacion: "Productos que especifican hardware para PC.",
    fechaVencimiento: "2024-12-03",
    estado: "Generado",
    detalles: [],
    destinatarios: [],
  },
  {
    codigo: "40",
    nombre: "CARGADORES",
    moneda: "NS",
    observacion: "Sección dirigida a cargadores.",
    fechaVencimiento: "2024-12-03",
    estado: "Generado",
    detalles: [],
    destinatarios: [],
  },
  {
    codigo: "41",
    nombre: "MEMORIAS",
    moneda: "NS",
    observacion: "Dispositivos de almacenamiento.",
    fechaVencimiento: "2024-12-03",
    estado: "Generado",
    detalles: [],
    destinatarios: [],
  },
  {
    codigo: "42",
    nombre: "ACCESORIOS DE PC",
    moneda: "NS",
    observacion: "Periféricos diseñados para PC.",
    fechaVencimiento: "2024-12-03",
    estado: "Generado",
    detalles: [],
    destinatarios: [],
  },
  {
    codigo: "43",
    nombre: "ENTRETENIMIENTO",
    moneda: "NS",
    observacion: "Sección orientada al ocio y entretenimiento.",
    fechaVencimiento: "2024-12-03",
    estado: "Generado",
    detalles: [],
    destinatarios: [],
  },
];

const LIST_COLUMNS = ["Cód.", "Nombre", "Moneda", "Observación", "Fec. Venc.", "Estado"];
const DETAIL_COLUMNS = ["Código", "Descripción", "Precio", "Rubro", "Estado", "Fecha Aprob."];

function formatDate(value: string) {
  if (!value) return "";
  const [year, month, day] = value.split("-");
  return year && month && day ? `${day}/${month}/${year}` : value;
}

function getLocalDateValue() {
  const today = new Date();
  const month = String(today.getMonth() + 1).padStart(2, "0");
  const day = String(today.getDate()).padStart(2, "0");
  return `${today.getFullYear()}-${month}-${day}`;
}

function PrecioListaDialog({
  mode,
  initialRow,
  onClose,
  onSave,
}: {
  mode: DialogMode;
  initialRow: PrecioListaRow | null;
  onClose: () => void;
  onSave: (row: PrecioListaRow) => boolean;
}) {
  const [codigo, setCodigo] = useState(initialRow?.codigo ?? "");
  const [nombre, setNombre] = useState(initialRow?.nombre ?? "");
  const [moneda, setMoneda] = useState(initialRow?.moneda ?? "USD");
  const [observacion, setObservacion] = useState(initialRow?.observacion ?? "");
  const [fechaVencimiento, setFechaVencimiento] = useState(
    initialRow?.fechaVencimiento ?? getLocalDateValue(),
  );
  const [estado, setEstado] = useState(initialRow?.estado ?? "Generado");
  const [detalles] = useState<PrecioListaDetail[]>(initialRow?.detalles ?? []);
  const [destinatarios, setDestinatarios] = useState<PrecioListaRecipient[]>(
    initialRow?.destinatarios ?? [],
  );
  const [isEditing, setIsEditing] = useState(mode === "new");
  const isNew = mode === "new";
  const editable = isNew || isEditing;
  const title = isNew ? "Registrar nueva Lista precio" : `LISTA PRECIO N° "${codigo}"`;

  const save = () => {
    if (!codigo.trim() || !nombre.trim()) {
      toast.error("Ingrese el número y el nombre de la lista.");
      return;
    }

    const saved = onSave({
      codigo: codigo.trim(),
      nombre: nombre.trim(),
      moneda,
      observacion: observacion.trim(),
      fechaVencimiento,
      estado,
      detalles,
      destinatarios,
    });
    if (saved) onClose();
  };

  const toggleRecipient = (index: number) => {
    setDestinatarios((current) => current.map((recipient, currentIndex) => (
      currentIndex === index ? { ...recipient, selected: !recipient.selected } : recipient
    )));
  };

  return (
    <div className="absolute inset-0 z-30 flex items-center justify-center bg-slate-900/35 p-2 sm:p-4">
      <section
        role="dialog"
        aria-modal="true"
        aria-labelledby="precio-lista-dialog-title"
        className="flex max-h-full w-full max-w-[940px] flex-col overflow-hidden border border-slate-400 bg-[#F3F6FA] shadow-xl"
      >
        <header className="flex shrink-0 items-center justify-between border-b border-slate-400/50 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] px-3 py-1.5">
          <h2 id="precio-lista-dialog-title" className="text-[11px] font-semibold text-slate-700">{title}</h2>
          <button type="button" className={iconBtn} title="Cerrar" onClick={onClose}>
            <LogOut className="h-4 w-4" />
          </button>
        </header>

        <div className="flex shrink-0 items-center gap-1 overflow-x-auto border-b border-slate-300 px-2 py-1">
          <button type="button" className={iconBtn} title="Guardar" onClick={save}>
            <Save className="h-4 w-4" />
          </button>
          {tbSep}
          <button
            type="button"
            className={iconBtn}
            title={editable ? "Deshacer cambios" : "Editar"}
            onClick={() => {
              if (isNew) {
                onClose();
              } else if (isEditing) {
                setIsEditing(false);
                setCodigo(initialRow?.codigo ?? "");
                setNombre(initialRow?.nombre ?? "");
                setMoneda(initialRow?.moneda ?? "USD");
                setObservacion(initialRow?.observacion ?? "");
                setFechaVencimiento(initialRow?.fechaVencimiento ?? "");
                setEstado(initialRow?.estado ?? "Generado");
              } else {
                setIsEditing(true);
              }
            }}
          >
            {editable ? <Undo2 className="h-4 w-4" /> : <Pencil className="h-4 w-4" />}
          </button>
          {tbSep}
          <button
            type="button"
            className={iconBtn}
            title="Aprobar"
            onClick={() => {
              setEstado("Aprobado");
              if (!isNew) setIsEditing(true);
            }}
          >
            <Check className="h-4 w-4" />
          </button>
          {tbSep}
          <button
            type="button"
            className={iconBtn}
            title="Dar de baja"
            onClick={() => {
              setEstado("Dado de baja");
              if (!isNew) setIsEditing(true);
            }}
          >
            <ThumbsDown className="h-4 w-4" />
          </button>
        </div>

        <div className="min-h-0 flex-1 overflow-y-auto">
          <fieldset className="m-2 border border-[#7A96B4] px-3 pb-3 pt-1">
            <legend className="px-1 text-[10.5px] font-bold text-slate-700">Cabecera</legend>
            <div className="grid gap-x-4 gap-y-2 sm:grid-cols-[1fr_1fr_1fr]">
              <label className="flex min-w-0 items-center gap-2">
                <span className="w-[82px] shrink-0 text-[11px] font-semibold text-slate-800">N° Lista</span>
                <input
                  className={`${inp} w-[68px]`}
                  value={codigo}
                  disabled={!isNew}
                  onChange={(event) => setCodigo(event.target.value)}
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
                  <option value="NS">S/</option>
                </select>
              </label>

              {!isNew && (
                <div className="flex items-center justify-center border border-slate-300 bg-slate-200 px-2 py-1 text-[11px] font-semibold text-slate-800">
                  {estado}
                </div>
              )}

              <label className="flex min-w-0 items-center gap-2 sm:col-span-2">
                <span className="w-[82px] shrink-0 text-[11px] font-semibold text-slate-800">Nombre Lista</span>
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

              <label className="flex items-center gap-2 sm:col-span-3">
                <span className="shrink-0 text-[11px] font-semibold text-slate-800">Fec. Vencimiento :</span>
                <input
                  className={`${inp} w-[120px]`}
                  type="date"
                  value={fechaVencimiento}
                  disabled={!editable}
                  onChange={(event) => setFechaVencimiento(event.target.value)}
                />
              </label>
            </div>
          </fieldset>

          {!isNew && (
            <>
              <fieldset className="mx-2 mb-2 border border-[#7A96B4] px-2 pb-2 pt-1">
                <legend className="px-1 text-[10.5px] font-bold text-slate-700">Detalles</legend>
                <div className="h-[190px] overflow-auto border border-slate-400/70 bg-white">
                  <SortableTable className="w-full min-w-[650px] border-collapse text-[11px]">
                    <thead className="sticky top-0 z-10 bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800">
                      <tr>
                        {DETAIL_COLUMNS.map((column) => (
                          <th key={column} className="border border-slate-300/80 px-2 py-1 text-center font-semibold whitespace-nowrap">
                            {column}
                          </th>
                        ))}
                      </tr>
                    </thead>
                    <tbody>
                      {detalles.length === 0 ? (
                        <tr><td colSpan={DETAIL_COLUMNS.length} className="h-[130px] border border-slate-200" /></tr>
                      ) : detalles.map((detail) => (
                        <tr key={detail.codigo} className="bg-white">
                          <td className="h-[20px] border border-slate-200 px-2">{detail.codigo}</td>
                          <td className="h-[20px] border border-slate-200 px-2">{detail.descripcion}</td>
                          <td className="h-[20px] border border-slate-200 px-2 text-right">{detail.precio}</td>
                          <td className="h-[20px] border border-slate-200 px-2">{detail.rubro}</td>
                          <td className="h-[20px] border border-slate-200 px-2">{detail.estado}</td>
                          <td className="h-[20px] border border-slate-200 px-2">{detail.fechaAprobacion}</td>
                        </tr>
                      ))}
                    </tbody>
                  </SortableTable>
                </div>
                <div className="pt-1 text-right text-[11px] font-semibold text-slate-800">
                  Registros : {detalles.length}
                </div>
              </fieldset>

              <fieldset className="mx-2 mb-2 border border-[#7A96B4] px-2 pb-2 pt-1">
                <legend className="px-1 text-[10.5px] font-bold text-slate-700">Enviar Correos</legend>
                <button
                  type="button"
                  className={`${btn} mb-1 ml-2 h-6`}
                  onClick={() => toast.info("El envío de correos requiere conexión al servicio de listas de precios.")}
                >
                  <Send className="h-3.5 w-3.5" />
                  Enviar
                </button>
                <div className="h-[96px] overflow-auto border border-slate-400/70 bg-white">
                  <SortableTable className="w-full min-w-[520px] border-collapse text-[11px]">
                    <thead className="sticky top-0 z-10 bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800">
                      <tr>
                        <th className="w-8 border border-slate-300/80 px-1 py-1" />
                        <th className="border border-slate-300/80 px-2 py-1 text-left font-semibold">Nombre</th>
                        <th className="border border-slate-300/80 px-2 py-1 text-left font-semibold">Email</th>
                      </tr>
                    </thead>
                    <tbody>
                      {destinatarios.length === 0 ? (
                        <tr><td colSpan={3} className="h-[40px] border border-slate-200" /></tr>
                      ) : destinatarios.map((recipient, index) => (
                        <tr key={recipient.email} className="bg-white">
                          <td className="border border-slate-200 px-2 text-center">
                            <input
                              type="checkbox"
                              aria-label={`Seleccionar ${recipient.nombre}`}
                              checked={recipient.selected}
                              onChange={() => toggleRecipient(index)}
                            />
                          </td>
                          <td className="h-[20px] border border-slate-200 px-2">{recipient.nombre}</td>
                          <td className="h-[20px] border border-slate-200 px-2">{recipient.email}</td>
                        </tr>
                      ))}
                    </tbody>
                  </SortableTable>
                </div>
              </fieldset>
            </>
          )}
        </div>
      </section>
    </div>
  );
}

export function PrecioListaList() {
  const [rows, setRows] = useState<PrecioListaRow[]>(INITIAL_ROWS);
  const [statusFilter, setStatusFilter] = useState("(Todos)");
  const [appliedStatus, setAppliedStatus] = useState("(Todos)");
  const [selectedCode, setSelectedCode] = useState("36");
  const [dialog, setDialog] = useState<{ mode: DialogMode; row: PrecioListaRow | null } | null>(null);

  const visibleRows = useMemo(
    () => appliedStatus === "(Todos)" ? rows : rows.filter((row) => row.estado === appliedStatus),
    [rows, appliedStatus],
  );
  const selectedRow = visibleRows.find((row) => row.codigo === selectedCode) ?? null;

  const openNew = () => setDialog({ mode: "new", row: null });
  const openSelected = () => {
    if (!selectedRow) {
      toast.info("Seleccione una lista para mostrar.");
      return;
    }
    setDialog({ mode: "view", row: selectedRow });
  };
  const saveRow = (row: PrecioListaRow) => {
    const duplicate = rows.some((item) => item.codigo === row.codigo && item.codigo !== dialog?.row?.codigo);
    if (duplicate) {
      toast.error(`Ya existe una lista con el número ${row.codigo}.`);
      return false;
    }

    setRows((current) => {
      const exists = current.some((item) => item.codigo === row.codigo);
      return exists
        ? current.map((item) => item.codigo === row.codigo ? row : item)
        : [...current, row];
    });
    setSelectedCode(row.codigo);
    return true;
  };

  const removeSelected = () => {
    if (!selectedRow) {
      toast.info("Seleccione una lista para eliminar.");
      return;
    }
    setRows((current) => current.filter((row) => row.codigo !== selectedRow.codigo));
    setSelectedCode("");
  };

  const updateSelectedStatus = (status: string) => {
    if (!selectedRow) {
      toast.info("Seleccione una lista para actualizar.");
      return;
    }
    setRows((current) => current.map((row) => (
      row.codigo === selectedRow.codigo ? { ...row, estado: status } : row
    )));
  };

  return (
    <div className="relative flex h-full min-h-0 flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex shrink-0 items-center gap-1 overflow-x-auto border-b border-slate-400/50 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] px-2 py-1.5">
        <button type="button" className={iconBtn} title="Imprimir" onClick={() => toast.info("No hay listas para imprimir.")}>
          <Printer className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Nuevo" onClick={openNew}>
          <Plus className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Mostrar" onClick={openSelected}>
          <Eye className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Eliminar" onClick={removeSelected}>
          <Trash2 className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Aprobar" onClick={() => updateSelectedStatus("Aprobado")}>
          <ThumbsUp className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Dar de baja" onClick={() => updateSelectedStatus("Dado de baja")}>
          <ThumbsDown className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Modificar validez" onClick={openSelected}>
          <Pencil className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Ver estados" onClick={openSelected}>
          <Search className="h-4 w-4" />
        </button>
        {tbSep}
        <button
          type="button"
          className={iconBtn}
          title="Actualizar"
          onClick={() => {
            setStatusFilter("(Todos)");
            setAppliedStatus("(Todos)");
            setSelectedCode(rows[0]?.codigo ?? "");
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
        <div className="flex flex-wrap items-end justify-center gap-x-3 gap-y-1">
          <label className="flex w-[160px] flex-col gap-0.5">
            <span className="text-center text-[10.5px] font-semibold text-slate-800">Estado</span>
            <select
              className={inp}
              value={statusFilter}
              onChange={(event) => setStatusFilter(event.target.value)}
            >
              <option>(Todos)</option>
              <option>Generado</option>
              <option>Aprobado</option>
              <option>Dado de baja</option>
            </select>
          </label>
          <button
            type="button"
            className={btnPrimary}
            onClick={() => {
              setAppliedStatus(statusFilter);
              const nextSelection = rows.find((row) => statusFilter === "(Todos)" || row.estado === statusFilter);
              setSelectedCode(nextSelection?.codigo ?? "");
            }}
          >
            <Search className="h-3.5 w-3.5" />
            Buscar
          </button>
        </div>
      </fieldset>

      <div className="min-h-0 flex-1 overflow-auto p-1.5">
        <div className="h-full overflow-auto rounded-sm border border-slate-400/60 bg-white">
          <SortableTable className="w-full min-w-[720px] border-collapse text-[11px]">
            <colgroup>
              <col className="w-[3%]" />
              <col className="w-[6%]" />
              <col className="w-[23%]" />
              <col className="w-[8%]" />
              <col className="w-[30%]" />
              <col className="w-[15%]" />
              <col className="w-[15%]" />
            </colgroup>
            <thead className="sticky top-0 z-10 bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800">
              <tr>
                <th className="w-6 border border-slate-300/80 px-1 py-1" />
                {LIST_COLUMNS.map((column) => (
                  <th key={column} className="border border-slate-300/80 px-2 py-1 text-center font-semibold whitespace-nowrap">
                    {column}
                  </th>
                ))}
              </tr>
            </thead>
            <tbody>
              {visibleRows.length === 0 ? (
                <tr><td colSpan={LIST_COLUMNS.length + 1} className="h-[180px] border border-slate-200 text-center text-slate-500">No hay listas para el estado seleccionado.</td></tr>
              ) : visibleRows.map((row, index) => (
                <tr
                  key={row.codigo}
                  className={`cursor-pointer ${row.codigo === selectedCode ? "bg-[#DCE8F7] font-semibold text-[#1F3E68]" : index % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]"}`}
                  onClick={() => setSelectedCode(row.codigo)}
                  onDoubleClick={openSelected}
                >
                  <td className="h-[20px] border border-slate-200 px-1 text-center">{row.codigo === selectedCode ? "▶" : ""}</td>
                  <td className="h-[20px] border border-slate-200 px-2 font-mono">{row.codigo}</td>
                  <td className="h-[20px] border border-slate-200 px-2">{row.nombre}</td>
                  <td className="h-[20px] border border-slate-200 px-2 text-center">{row.moneda}</td>
                  <td className="h-[20px] border border-slate-200 px-2" title={row.observacion}>{row.observacion}</td>
                  <td className="h-[20px] border border-slate-200 px-2 text-center">{formatDate(row.fechaVencimiento)}</td>
                  <td className="h-[20px] border border-slate-200 px-2 text-center">{row.estado}</td>
                </tr>
              ))}
              {visibleRows.length > 0 && Array.from({ length: Math.max(0, 12 - visibleRows.length) }, (_, index) => (
                <tr key={`empty-${index}`} className={index % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]"}>
                  {Array.from({ length: LIST_COLUMNS.length + 1 }, (_, cellIndex) => (
                    <td key={cellIndex} className="h-[20px] border border-slate-200 px-2" />
                  ))}
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
        <PrecioListaDialog
          key={`${dialog.mode}-${dialog.row?.codigo ?? "new"}`}
          mode={dialog.mode}
          initialRow={dialog.row}
          onClose={() => setDialog(null)}
          onSave={saveRow}
        />
      )}
    </div>
  );
}

export function PrecioLista() {
  return <PrecioListaList />;
}
