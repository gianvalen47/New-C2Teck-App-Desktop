import { useMemo, useState } from "react";
import {
  Check,
  FileText,
  LogOut,
  Pencil,
  Plus,
  Printer,
  RefreshCw,
  Save,
  Search,
  ThumbsDown,
  ThumbsUp,
  Trash2,
  Undo2,
} from "lucide-react";
import { toast } from "sonner";
import { btn, btnPrimary, iconBtn, inp, tbSep } from "@/features/escritorio/windows/uiStyles";
import {
  CodeDescSelector,
  type CodeDescOption,
} from "@/features/escritorio/windows/shared/SearchFieldControls";
import { SortableTable } from "@/components/ui/sortable-table";

type PrecioClienteRow = {
  codigo: string;
  cliente: string;
  contrato: string;
  observacion: string;
  estado: string;
  fechaVencimiento: string;
  moneda: string;
  numeroLista: string;
};

const STATUS_OPTIONS: CodeDescOption[] = [
  { code: "01", label: "GENERADO", value: "GENERADO" },
  { code: "02", label: "APROBADO", value: "APROBADO" },
  { code: "03", label: "DADO DE BAJA", value: "DADO DE BAJA" },
];

const CURRENCY_OPTIONS: CodeDescOption[] = [
  { code: "USD", label: "USD", value: "USD" },
  { code: "PEN", label: "PEN", value: "PEN" },
];

const COLUMNS = ["Cód.", "Cliente", "N° Contrato", "Observación", "Estado", "Fec. Venc."];

function ListaClienteDialog({
  onClose,
  onSave,
}: {
  onClose: () => void;
  onSave: (row: PrecioClienteRow) => void;
}) {
  const [numeroLista, setNumeroLista] = useState("");
  const [moneda, setMoneda] = useState("USD");
  const [cliente, setCliente] = useState("");
  const [contrato, setContrato] = useState("");
  const [observacion, setObservacion] = useState("");
  const [fechaVencimiento, setFechaVencimiento] = useState("2026-07-26");

  const save = () => {
    if (!numeroLista.trim() || !cliente.trim()) {
      toast.error("Ingrese el número de lista y el cliente.");
      return;
    }

    onSave({
      codigo: numeroLista.trim(),
      cliente: cliente.trim(),
      contrato: contrato.trim(),
      observacion: observacion.trim(),
      estado: "GENERADO",
      fechaVencimiento,
      moneda,
      numeroLista: numeroLista.trim(),
    });
    onClose();
  };

  return (
    <div className="absolute inset-0 z-30 flex items-center justify-center bg-slate-900/30 p-3">
      <section
        role="dialog"
        aria-modal="true"
        aria-labelledby="lista-cliente-dialog-title"
        className="w-full max-w-[760px] border border-slate-400 bg-[#F3F6FA] shadow-xl"
      >
        <header className="flex items-center justify-between border-b border-slate-400/50 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] px-3 py-1.5">
          <h2 id="lista-cliente-dialog-title" className="text-[11px] font-semibold text-slate-700">
            Registrar nueva Lista Cliente
          </h2>
          <button type="button" className={iconBtn} title="Cerrar" onClick={onClose}>
            <LogOut className="h-4 w-4" />
          </button>
        </header>

        <div className="flex items-center gap-1 border-b border-slate-300 px-2 py-1">
          <button type="button" className={iconBtn} title="Guardar" onClick={save}>
            <Save className="h-4 w-4" />
          </button>
          {tbSep}
          <button type="button" className={iconBtn} title="Cancelar" onClick={onClose}>
            <Undo2 className="h-4 w-4" />
          </button>
          {tbSep}
          <button type="button" className={iconBtn} title="Aprobar" onClick={save}>
            <Check className="h-4 w-4" />
          </button>
          {tbSep}
          <button type="button" className={iconBtn} title="Dar de baja" onClick={onClose}>
            <ThumbsDown className="h-4 w-4" />
          </button>
        </div>

        <fieldset className="m-2 border border-[#7A96B4] px-3 pb-3 pt-1">
          <legend className="px-1 text-[10.5px] font-bold text-slate-700">Cabecera</legend>
          <div className="grid gap-x-4 gap-y-3 sm:grid-cols-[1fr_1fr]">
            <div className="flex flex-wrap items-center gap-2">
              <label htmlFor="precio-numero-lista" className="w-[78px] text-[11px] font-semibold text-slate-800">
                N° Lista
              </label>
              <input
                id="precio-numero-lista"
                className={`${inp} w-[68px]`}
                value={numeroLista}
                onChange={(event) => setNumeroLista(event.target.value)}
              />
              <label htmlFor="precio-moneda" className="ml-auto text-[11px] font-semibold text-slate-800">
                Moneda
              </label>
              <div id="precio-moneda" className="w-[70px]">
                <CodeDescSelector value={moneda} onChange={setMoneda} options={CURRENCY_OPTIONS} allLabel="" />
              </div>
            </div>

            <div className="hidden sm:block" />

            <div className="flex min-w-0 items-center gap-2 sm:col-span-2">
              <label htmlFor="precio-cliente" className="w-[78px] shrink-0 text-[11px] font-semibold text-slate-800">
                Cliente
              </label>
              <input
                id="precio-cliente"
                className={`${inp} min-w-0 flex-1`}
                value={cliente}
                onChange={(event) => setCliente(event.target.value)}
              />
              <button
                type="button"
                className={iconBtn}
                title="Buscar cliente"
                onClick={() => toast.info("La búsqueda requiere conexión al servicio de clientes.")}
              >
                <Search className="h-3.5 w-3.5" />
              </button>
              <label htmlFor="precio-contrato" className="ml-auto shrink-0 text-[11px] font-semibold text-slate-800">
                N° Contrato
              </label>
              <input
                id="precio-contrato"
                className={`${inp} w-[220px] max-w-[35%]`}
                value={contrato}
                onChange={(event) => setContrato(event.target.value)}
              />
            </div>

            <label className="flex min-w-0 items-start gap-2 sm:col-span-2">
              <span className="w-[78px] shrink-0 pt-1 text-[11px] font-semibold text-slate-800">Observación</span>
              <textarea
                className={`${inp} h-[42px] min-w-0 flex-1 resize-y`}
                value={observacion}
                onChange={(event) => setObservacion(event.target.value)}
              />
            </label>

            <label className="flex items-center gap-2 sm:col-span-2">
              <span className="w-[106px] shrink-0 text-[11px] font-semibold text-slate-800">Fec. Vencimiento :</span>
              <input
                className={`${inp} w-[112px]`}
                type="date"
                value={fechaVencimiento}
                onChange={(event) => setFechaVencimiento(event.target.value)}
              />
            </label>
          </div>
        </fieldset>
      </section>
    </div>
  );
}

export function PrecioClienteList() {
  const [rows, setRows] = useState<PrecioClienteRow[]>([]);
  const [clientSearch, setClientSearch] = useState("");
  const [appliedClient, setAppliedClient] = useState("");
  const [status, setStatus] = useState("");
  const [contractSearch, setContractSearch] = useState("");
  const [appliedContract, setAppliedContract] = useState("");
  const [dialogOpen, setDialogOpen] = useState(false);

  const visibleRows = useMemo(() => rows.filter((row) => {
    if (appliedClient && !row.cliente.toLowerCase().includes(appliedClient)) return false;
    if (status && row.estado !== status) return false;
    if (appliedContract && !row.contrato.includes(appliedContract)) return false;
    return true;
  }), [rows, appliedClient, status, appliedContract]);

  const search = () => {
    setAppliedClient(clientSearch.trim().toLowerCase());
    setAppliedContract(contractSearch.trim());
  };

  return (
    <div className="relative flex h-full min-h-0 flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex shrink-0 items-center gap-1 overflow-x-auto border-b border-slate-400/50 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] px-2 py-1.5">
        <button type="button" className={iconBtn} title="Imprimir" onClick={() => toast.info("No hay listas para imprimir.")}>
          <Printer className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Nuevo" onClick={() => setDialogOpen(true)}>
          <Plus className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Mostrar" onClick={() => toast.info("Seleccione una lista para mostrar.")}>
          <FileText className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Eliminar" onClick={() => toast.info("Seleccione una lista para eliminar.")}>
          <Trash2 className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Aprobar" onClick={() => toast.info("Seleccione una lista para aprobar.")}>
          <ThumbsUp className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Dar de baja" onClick={() => toast.info("Seleccione una lista para dar de baja.")}>
          <ThumbsDown className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Modificar validez" onClick={() => toast.info("Seleccione una lista para modificar su validez.")}>
          <Pencil className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Ver estados" onClick={() => toast.info("Seleccione una lista para ver sus estados.")}>
          <Search className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Actualizar" onClick={search}>
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
          <div className="flex w-[300px] flex-col gap-0.5">
            <label htmlFor="precio-filtro-cliente" className="text-center text-[10.5px] font-semibold text-slate-800">
              Cliente
            </label>
            <div className="flex items-center gap-1">
              <input
                id="precio-filtro-cliente"
                className={inp}
                value={clientSearch}
                placeholder="(Todos)"
                onChange={(event) => setClientSearch(event.target.value)}
                onKeyDown={(event) => {
                  if (event.key === "Enter") search();
                }}
              />
              <button type="button" className={iconBtn} title="Buscar cliente" onClick={search}>
                <Search className="h-3.5 w-3.5" />
              </button>
              <button
                type="button"
                className={iconBtn}
                title="Limpiar cliente"
                onClick={() => {
                  setClientSearch("");
                  setAppliedClient("");
                }}
              >
                <Undo2 className="h-3.5 w-3.5" />
              </button>
            </div>
          </div>
          <label className="flex w-[150px] flex-col gap-0.5">
            <span className="text-center text-[10.5px] font-semibold text-slate-800">Estado</span>
            <CodeDescSelector value={status} onChange={setStatus} options={STATUS_OPTIONS} allLabel="(Todos)" />
          </label>
          <label className="flex w-[96px] flex-col gap-0.5">
            <span className="text-center text-[10.5px] font-semibold text-slate-800">N° Contrato</span>
            <input
              className={`${inp} text-center`}
              value={contractSearch}
              onChange={(event) => setContractSearch(event.target.value)}
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
          <SortableTable className="w-full min-w-[720px] border-collapse text-[11px]">
            <colgroup>
              <col className="w-[6%]" />
              <col className="w-[24%]" />
              <col className="w-[10%]" />
              <col className="w-[28%]" />
              <col className="w-[16%]" />
              <col className="w-[16%]" />
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
                    <td className="h-[20px] border border-slate-200 px-2">{row?.cliente}</td>
                    <td className="h-[20px] border border-slate-200 px-2 font-mono">{row?.contrato}</td>
                    <td className="h-[20px] border border-slate-200 px-2">{row?.observacion}</td>
                    <td className="h-[20px] border border-slate-200 px-2">{row?.estado}</td>
                    <td className="h-[20px] border border-slate-200 px-2">{row?.fechaVencimiento}</td>
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

      {dialogOpen && (
        <ListaClienteDialog
          onClose={() => setDialogOpen(false)}
          onSave={(row) => setRows((currentRows) => [...currentRows, row])}
        />
      )}
    </div>
  );
}

export function PrecioCliente() {
  return <PrecioClienteList />;
}
