import { useState } from "react";
import { Eye, FilePlus2, LogOut, Pencil, RefreshCw, Save, Search, Undo2 } from "lucide-react";
import { toast } from "sonner";
import { iconBtn, inp, tbSep } from "@/features/escritorio/windows/uiStyles";
import { SortableTable } from "@/components/ui/sortable-table";

type RubroRow = {
  codigo: string;
  rubro: string;
  abreviatura: string;
  factorCosto: string;
  factorVenta: string;
  descuento: string;
};

const INITIAL_ROWS: RubroRow[] = [
  { codigo: "19", rubro: "PARTES INFORMATICAS", abreviatura: "PI", factorCosto: "1.00", factorVenta: "1.00", descuento: "0.00" },
  { codigo: "22", rubro: "REPUESTOS TRI", abreviatura: "TRI", factorCosto: "1.25", factorVenta: "2.00", descuento: "0.00" },
  { codigo: "18", rubro: "SERVICIOS INFORMÁTICOS", abreviatura: "SI", factorCosto: "1.93", factorVenta: "1.00", descuento: "0.00" },
];

const COLUMNS = ["Código", "Rubro", "Abrev.", "FacCos", "FacVen", "Dscto"];

function RubroDialog({
  initialValue,
  isNew,
  onClose,
  onSave,
}: {
  initialValue: RubroRow;
  isNew: boolean;
  onClose: () => void;
  onSave: (row: RubroRow) => boolean;
}) {
  const [form, setForm] = useState(initialValue);
  const [editing, setEditing] = useState(isNew);
  const [savedForm, setSavedForm] = useState(initialValue);

  const update = (key: keyof RubroRow, value: string) => {
    setForm((current) => ({ ...current, [key]: value }));
  };

  const undo = () => {
    setForm(savedForm);
    setEditing(false);
  };

  const save = () => {
    if (!form.codigo.trim() || !form.rubro.trim()) {
      toast.error("Ingrese el código y la descripción del rubro.");
      return;
    }
    const saved = onSave({ ...form, codigo: form.codigo.trim(), rubro: form.rubro.trim() });
    if (!saved) return;
    setSavedForm(form);
    setEditing(false);
    onClose();
  };

  return (
    <div className="absolute inset-0 z-30 flex items-center justify-center bg-slate-900/30 p-3">
      <section
        role="dialog"
        aria-modal="true"
        aria-labelledby="rubro-dialog-title"
        className="w-full max-w-[390px] border border-slate-400 bg-[#F3F6FA] shadow-xl"
      >
        <header className="flex items-center justify-between border-b border-slate-400/50 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] px-3 py-1.5">
          <h2 id="rubro-dialog-title" className="text-[11px] font-semibold text-slate-700">
            {isNew ? "Registrar nuevo Rubro" : `Rubro : "${form.codigo}"`}
          </h2>
          <button type="button" className={iconBtn} title="Cerrar" onClick={onClose}>
            <LogOut className="h-4 w-4" />
          </button>
        </header>

        <div className="flex items-center gap-1 border-b border-slate-300 px-2 py-1">
          <button type="button" className={iconBtn} title="Guardar cambios" disabled={!editing} onClick={save}>
            <Save className="h-4 w-4" />
          </button>
          {tbSep}
          <button
            type="button"
            className={iconBtn}
            title="Editar"
            disabled={editing}
            onClick={() => setEditing(true)}
          >
            <Pencil className="h-4 w-4" />
          </button>
          {tbSep}
          <button type="button" className={iconBtn} title="Deshacer cambios" disabled={!editing} onClick={undo}>
            <Undo2 className="h-4 w-4" />
          </button>
          {tbSep}
          <button type="button" className={iconBtn} title="Seleccionar rubro" onClick={() => toast.info("La búsqueda requiere conexión al servicio de rubros.")}>
            <Search className="h-4 w-4" />
          </button>
        </div>

        <fieldset className="m-2 border border-[#7A96B4] px-3 pb-3 pt-2">
          <div className="grid grid-cols-[96px_minmax(0,1fr)] items-center gap-x-2 gap-y-2">
            <label htmlFor="rubro-codigo" className="text-right text-[11px] font-medium text-slate-800">Código :</label>
            <div className="flex items-center gap-1">
              <input
                id="rubro-codigo"
                className={`${inp} w-[74px]`}
                value={form.codigo}
                readOnly={!isNew}
                onChange={(event) => update("codigo", event.target.value)}
              />
              <button type="button" className={iconBtn} title="Buscar rubro" onClick={() => toast.info("La búsqueda requiere conexión al servicio de rubros.")}>
                <Search className="h-3.5 w-3.5" />
              </button>
            </div>

            <label htmlFor="rubro-descripcion" className="text-right text-[11px] font-medium text-slate-800">Descripción :</label>
            <input
              id="rubro-descripcion"
              className={inp}
              value={form.rubro}
              readOnly={!isNew}
              onChange={(event) => update("rubro", event.target.value)}
            />

            <label htmlFor="rubro-abreviatura" className="text-right text-[11px] font-medium text-slate-800">Abrev. :</label>
            <input
              id="rubro-abreviatura"
              className={`${inp} w-[74px]`}
              value={form.abreviatura}
              readOnly={!isNew}
              onChange={(event) => update("abreviatura", event.target.value)}
            />

            <label htmlFor="rubro-factor-costo" className="text-right text-[11px] font-medium text-slate-800">Factor Costo :</label>
            <input
              id="rubro-factor-costo"
              className={`${inp} w-[58px] text-right font-mono`}
              value={form.factorCosto}
              readOnly={!editing}
              onChange={(event) => update("factorCosto", event.target.value)}
            />

            <label htmlFor="rubro-factor-venta" className="text-right text-[11px] font-medium text-slate-800">Factor Venta :</label>
            <input
              id="rubro-factor-venta"
              className={`${inp} w-[58px] text-right font-mono`}
              value={form.factorVenta}
              readOnly={!editing}
              onChange={(event) => update("factorVenta", event.target.value)}
            />

            <label htmlFor="rubro-descuento" className="text-right text-[11px] font-medium text-slate-800">Descuento :</label>
            <input
              id="rubro-descuento"
              className={`${inp} w-[58px] text-right font-mono`}
              value={form.descuento}
              readOnly={!editing}
              onChange={(event) => update("descuento", event.target.value)}
            />
          </div>
        </fieldset>
      </section>
    </div>
  );
}

export function FactoresRubrosList() {
  const [rows, setRows] = useState(INITIAL_ROWS);
  const [selectedCode, setSelectedCode] = useState<string | null>(null);
  const [dialog, setDialog] = useState<{ row: RubroRow; isNew: boolean } | null>(null);

  const showSelected = () => {
    const selected = rows.find((row) => row.codigo === selectedCode);
    if (!selected) {
      toast.info("Seleccione un rubro para mostrar sus datos.");
      return;
    }
    setDialog({ row: selected, isNew: false });
  };

  const addNew = () => {
    setDialog({
      row: { codigo: "", rubro: "", abreviatura: "", factorCosto: "0.00", factorVenta: "0.00", descuento: "0.00" },
      isNew: true,
    });
  };

  const saveRow = (row: RubroRow) => {
    const exists = rows.some((item) => item.codigo === row.codigo);
    if (dialog?.isNew && exists) {
      toast.error(`Ya existe un rubro con código ${row.codigo}.`);
      return false;
    }
    if (exists) {
      setRows((current) => current.map((item) => item.codigo === row.codigo ? row : item));
    } else {
      setRows((current) => [...current, row]);
    }
    setSelectedCode(row.codigo);
    return true;
  };

  return (
    <div className="relative flex h-full min-h-0 flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex h-[31px] shrink-0 items-center gap-1 border-b border-slate-400/50 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] px-1">
        <button type="button" className={iconBtn} title="Nuevo" onClick={addNew}>
          <FilePlus2 className="h-4 w-4" />
        </button>
        <button type="button" className={iconBtn} title="Mostrar" onClick={showSelected}>
          <Eye className="h-4 w-4" />
        </button>
        <button
          type="button"
          className={iconBtn}
          title="Actualizar"
          onClick={() => setSelectedCode(null)}
        >
          <RefreshCw className="h-4 w-4" />
        </button>
        <button type="button" className={iconBtn} title="Cerrar ventana">
          <LogOut className="h-4 w-4" />
        </button>
      </div>

      <div className="min-h-0 flex-1 overflow-auto p-2">
        <div className="h-full overflow-auto rounded-sm border border-slate-400/60 bg-white">
          <SortableTable className="w-full min-w-[560px] border-collapse text-[11px]">
            <colgroup>
              <col className="w-[12%]" />
              <col className="w-[42%]" />
              <col className="w-[11%]" />
              <col className="w-[12%]" />
              <col className="w-[12%]" />
              <col className="w-[11%]" />
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
              {rows.map((row, index) => (
                <tr
                  key={row.codigo}
                  onClick={() => setSelectedCode(row.codigo)}
                  onDoubleClick={showSelected}
                  className={`cursor-pointer ${selectedCode === row.codigo ? "bg-[#D6E4F4]" : index % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]"}`}
                >
                  <td className="h-[20px] border border-slate-200 px-2 text-center font-mono">{row.codigo}</td>
                  <td className="h-[20px] border border-slate-200 px-2">{row.rubro}</td>
                  <td className="h-[20px] border border-slate-200 px-2 text-center">{row.abreviatura}</td>
                  <td className="h-[20px] border border-slate-200 px-2 text-right font-mono">{row.factorCosto}</td>
                  <td className="h-[20px] border border-slate-200 px-2 text-right font-mono">{row.factorVenta}</td>
                  <td className="h-[20px] border border-slate-200 px-2 text-right font-mono">{row.descuento}</td>
                </tr>
              ))}
              {Array.from({ length: 10 }, (_, index) => (
                <tr key={`empty-${index}`} className={index % 2 === 0 ? "bg-[#F6F9FC]" : "bg-white"}>
                  {COLUMNS.map((column) => (
                    <td key={column} className="h-[20px] border border-slate-200 px-2" />
                  ))}
                </tr>
              ))}
            </tbody>
          </SortableTable>
        </div>
      </div>

      {dialog && (
        <RubroDialog
          key={`${dialog.row.codigo}-${dialog.isNew ? "new" : "show"}`}
          initialValue={dialog.row}
          isNew={dialog.isNew}
          onClose={() => setDialog(null)}
          onSave={saveRow}
        />
      )}
    </div>
  );
}

export function FactoresRubros() {
  return <FactoresRubrosList />;
}
