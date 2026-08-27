import { useCallback, useEffect, useMemo, useState } from "react";
import {
  LogOut,
  MapPin,
  Package,
  Pencil,
  Plus,
  RefreshCw,
  Save,
  Search,
  Trash2,
} from "lucide-react";
import { toast } from "sonner";
import {
  createSigecoomLocation,
  deleteSigecoomLocation,
  fetchSigecoomLocations,
  type Location,
  updateSigecoomLocation,
} from "@/lib/sigecoom-api";

import { inp, btn, btnPrimary, iconBtn, actionBtn, squareIconBtn, tbSep } from "./uiStyles";

function Field({ label, className = "", children }: { label: string; className?: string; children: React.ReactNode }) {
  return (
    <label className={`flex flex-col gap-0.5 ${className}`}>
      <span className="text-[10.5px] text-slate-600 font-medium">{label}</span>
      {children}
    </label>
  );
}

type UbicacionFormProps = {
  ubicacion?: Location;
  onClose: () => void;
  onSaved: () => void;
};

function UbicacionForm({ ubicacion, onClose, onSaved }: UbicacionFormProps) {
  const isNew = !ubicacion;
  const [saving, setSaving] = useState(false);
  const [code, setCode] = useState(ubicacion?.code ?? "");
  const [warehouse, setWarehouse] = useState(ubicacion?.warehouse ?? "");
  const [aisle, setAisle] = useState(ubicacion?.aisle ?? "");
  const [shelf, setShelf] = useState(ubicacion?.shelf ?? "");
  const [row, setRow] = useState(ubicacion?.row ?? "");
  const [level, setLevel] = useState(ubicacion?.level ?? "");
  const [description, setDescription] = useState(ubicacion?.description ?? "");
  const [capacity, setCapacity] = useState(String(ubicacion?.capacity ?? ""));
  const [occupancy, setOccupancy] = useState(String(ubicacion?.occupancy_percent ?? ""));

  const handleSave = async () => {
    if (!code.trim() || !warehouse.trim()) {
      toast.error("El código y el almacén son obligatorios");
      return;
    }

    setSaving(true);
    try {
      const payload = {
        code: code.trim(),
        warehouse: warehouse.trim(),
        aisle: aisle.trim() || undefined,
        shelf: shelf.trim() || undefined,
        row: row.trim() || undefined,
        level: level.trim() || undefined,
        description: description.trim() || undefined,
        capacity: capacity ? Number(capacity) : undefined,
        occupancy_percent: occupancy ? Number(occupancy) : undefined,
      };

      if (isNew) {
        await createSigecoomLocation(payload);
        toast.success("Ubicación registrada");
      } else {
        await updateSigecoomLocation(ubicacion!.id, payload);
        toast.success("Ubicación actualizada");
      }
      onSaved();
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo guardar la ubicación");
    } finally {
      setSaving(false);
    }
  };

  return (
    <div className="h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0">
        <button className={btnPrimary} onClick={handleSave} disabled={saving}>
          <Save className="h-3.5 w-3.5" />{saving ? "Guardando..." : "Grabar"}
        </button>
        <button className={btn} onClick={onClose}>Deshacer</button>
        <button className={iconBtn} title="Salir" onClick={onClose}><LogOut className="h-4 w-4" /></button>
        <div className="ml-2 text-[11.5px] font-semibold text-slate-700">{isNew ? "REGISTRAR UBICACIÓN" : "ACTUALIZAR UBICACIÓN"}</div>
      </div>

      <div className="p-3 overflow-auto min-h-0">
        <div className="grid grid-cols-12 gap-2 max-w-3xl">
          <Field label="Código" className="col-span-3">
            <input className={inp} value={code} onChange={(e) => setCode(e.target.value)} placeholder="A-01" />
          </Field>
          <Field label="Almacén" className="col-span-5">
            <input className={inp} value={warehouse} onChange={(e) => setWarehouse(e.target.value)} placeholder="ALM01" />
          </Field>
          <Field label="Pasillo" className="col-span-2">
            <input className={inp} value={aisle} onChange={(e) => setAisle(e.target.value)} placeholder="P1" />
          </Field>
          <Field label="Estante" className="col-span-2">
            <input className={inp} value={shelf} onChange={(e) => setShelf(e.target.value)} placeholder="E1" />
          </Field>
          <Field label="Fila" className="col-span-3">
            <input className={inp} value={row} onChange={(e) => setRow(e.target.value)} placeholder="F1" />
          </Field>
          <Field label="Nivel" className="col-span-3">
            <input className={inp} value={level} onChange={(e) => setLevel(e.target.value)} placeholder="N1" />
          </Field>
          <Field label="Capacidad" className="col-span-3">
            <input className={`${inp} font-mono`} value={capacity} onChange={(e) => setCapacity(e.target.value)} placeholder="0" />
          </Field>
          <Field label="Ocupación %" className="col-span-3">
            <input className={`${inp} font-mono`} value={occupancy} onChange={(e) => setOccupancy(e.target.value)} placeholder="0" />
          </Field>
          <Field label="Descripción" className="col-span-12">
            <input className={inp} value={description} onChange={(e) => setDescription(e.target.value)} placeholder="Detalle de la ubicación" />
          </Field>
        </div>
      </div>
    </div>
  );
}

export function UbicacionesList() {
  const [rows, setRows] = useState<Location[]>([]);
  const [loading, setLoading] = useState(false);
  const [searched, setSearched] = useState(false);
  const [search, setSearch] = useState("");
  const [selected, setSelected] = useState<Location | null>(null);
  const [showForm, setShowForm] = useState(false);
  const [isNew, setIsNew] = useState(false);

  const load = useCallback(async () => {
    setLoading(true);
    try {
      const data = await fetchSigecoomLocations();
      setRows(data);
      setSearched(true);
    } catch (e: any) {
      toast.error(e.message ?? "Error al cargar ubicaciones");
    } finally {
      setLoading(false);
    }
  }, []);

  useEffect(() => {
    load();
  }, [load]);

  const [sortBy, setSortBy] = useState<{ col: string; asc: boolean }>({ col: "code", asc: true });
  const filteredRows = useMemo(() => {
    const q = search.trim().toLowerCase();
    let out = q
      ? rows.filter((row) => [row.code, row.warehouse, row.aisle, row.shelf, row.row, row.level, row.description].filter(Boolean).some((v) => String(v).toLowerCase().includes(q)))
      : [...rows];

    const col = sortBy.col;
    if (col) {
      out.sort((a: any, b: any) => {
        const va = a[col];
        const vb = b[col];
        if (va == null && vb == null) return 0;
        if (va == null) return sortBy.asc ? -1 : 1;
        if (vb == null) return sortBy.asc ? 1 : -1;
        if (typeof va === "number" && typeof vb === "number") return sortBy.asc ? va - vb : vb - va;
        return sortBy.asc ? String(va).localeCompare(String(vb)) : String(vb).localeCompare(String(va));
      });
    }
    return out;
  }, [rows, search, sortBy]);

  const handleDelete = async () => {
    if (!selected) return;
    if (!confirm(`¿Eliminar la ubicación ${selected.code}?`)) return;
    try {
      await deleteSigecoomLocation(selected.id);
      toast.success("Ubicación eliminada");
      setSelected(null);
      await load();
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo eliminar la ubicación");
    }
  };

  if (showForm) {
    return (
      <UbicacionForm
        ubicacion={isNew ? undefined : selected ?? undefined}
        onClose={() => {
          setShowForm(false);
          setIsNew(false);
        }}
        onSaved={() => {
          setShowForm(false);
          setIsNew(false);
          load();
        }}
      />
    );
  }

  return (
    <div className="h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0 overflow-x-auto">
        <button className={iconBtn} title="Nueva ubicación" onClick={() => { setIsNew(true); setShowForm(true); }}><Plus className="h-4 w-4" /></button>
        <button className={iconBtn} title="Editar ubicación" disabled={!selected} onClick={() => { setIsNew(false); setShowForm(true); }}><Pencil className="h-4 w-4" /></button>
        <button className={iconBtn} title="Eliminar ubicación" disabled={!selected} onClick={handleDelete}><Trash2 className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Actualizar" onClick={load}><RefreshCw className="h-4 w-4" /></button>
        <button className={iconBtn} title="Salir" onClick={() => toast.info("Use la X superior para cerrar la ventana")}><LogOut className="h-4 w-4" /></button>
      </div>

      <div className="flex flex-wrap items-end gap-2 px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300">
        <Field label="Buscar" className="w-72">
          <input className={inp} value={search} onChange={(e) => setSearch(e.target.value)} placeholder="Código, almacén, pasillo o descripción" />
        </Field>
        <button className={btnPrimary} onClick={load} disabled={loading}>
          <Search className="h-3.5 w-3.5" />{loading ? "Buscando..." : "Buscar"}
        </button>
      </div>

      <div className="flex-1 min-h-0 overflow-auto p-1.5">
        <div className="border border-slate-400/60 bg-white rounded-sm h-full overflow-auto">
          <table className="w-full text-[11.5px]">
            <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 sticky top-0 z-10">
              <tr>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev.col === 'code' ? { col: 'code', asc: !prev.asc } : { col: 'code', asc: true })}>Código {sortBy.col === 'code' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev.col === 'warehouse' ? { col: 'warehouse', asc: !prev.asc } : { col: 'warehouse', asc: true })}>Almacén {sortBy.col === 'warehouse' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">Pasillo</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">Estante</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">Fila</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">Nivel</th>
                <th className="px-2 py-1 text-right border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev.col === 'capacity' ? { col: 'capacity', asc: !prev.asc } : { col: 'capacity', asc: false })}>Capacidad {sortBy.col === 'capacity' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-right border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev.col === 'occupancy_percent' ? { col: 'occupancy_percent', asc: !prev.asc } : { col: 'occupancy_percent', asc: false })}>Ocupación % {sortBy.col === 'occupancy_percent' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-slate-300/70 font-semibold whitespace-nowrap">Descripción</th>
              </tr>
            </thead>
            <tbody>
              {filteredRows.length === 0 ? (
                <tr>
                  <td colSpan={9} className="text-center py-8 text-slate-400 text-[11px]">
                    {loading ? "Cargando..." : searched ? "Sin resultados" : "Use la búsqueda y pulse Buscar"}
                  </td>
                </tr>
              ) : filteredRows.map((u, i) => {
                const isSel = selected?.id === u.id;
                return (
                  <tr
                    key={u.id}
                    onClick={() => setSelected(u)}
                    onDoubleClick={() => { setSelected(u); setIsNew(false); setShowForm(true); }}
                    className={[
                      "cursor-pointer border-b border-slate-200",
                      i % 2 ? "bg-[#F6F9FC]" : "bg-white",
                      isSel ? "!bg-[#D6E4F4] outline outline-1 outline-[#3E5B7A]" : "hover:bg-[#E8F0F8]/60",
                    ].join(" ")}
                  >
                    <td className="px-2 py-1 text-center border-r border-slate-200 font-mono font-semibold">{u.code}</td>
                    <td className="px-2 py-1 border-r border-slate-200">{u.warehouse}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200">{u.aisle || "-"}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200">{u.shelf || "-"}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200">{u.row || "-"}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200">{u.level || "-"}</td>
                    <td className="px-2 py-1 text-right border-r border-slate-200 font-mono">{u.capacity ?? "-"}</td>
                    <td className="px-2 py-1 text-right border-r border-slate-200 font-mono">{u.occupancy_percent ?? "-"}</td>
                    <td className="px-2 py-1 border-r border-slate-200 max-w-[260px] truncate">{u.description || "-"}</td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        </div>
      </div>

      <div className="shrink-0 border-t border-slate-400/50 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-0.5 text-[11px] text-slate-700 text-center font-medium flex items-center justify-center whitespace-nowrap overflow-hidden">
        Registros : {filteredRows.length}
      </div>
    </div>
  );
}
