import { useCallback, useEffect, useMemo, useState } from "react";
import {
  LogOut,
  Mail,
  MapPin,
  Pencil,
  Phone,
  Plus,
  RefreshCw,
  Save,
  Search,
  Trash2,
  User,
  X,
} from "lucide-react";
import { toast } from "sonner";
import {
  createSigecoomClient,
  deleteSigecoomClient,
  fetchSigecoomClients,
  type SigecoomClient,
  updateSigecoomClient,
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

type ClienteFormProps = {
  cliente?: SigecoomClient;
  onClose: () => void;
  onSaved: () => void;
};

function ClienteForm({ cliente, onClose, onSaved }: ClienteFormProps) {
  const isNew = !cliente;
  const [saving, setSaving] = useState(false);
  const [nombre, setNombre] = useState(cliente?.name ?? "");
  const [ruc, setRuc] = useState(cliente?.ruc ?? "");
  const [direccion, setDireccion] = useState(cliente?.address ?? "");
  const [telefono, setTelefono] = useState(cliente?.phone ?? "");
  const [correo, setCorreo] = useState(cliente?.email ?? "");

  const handleSave = async () => {
    if (!nombre.trim()) {
      toast.error("El nombre del cliente es obligatorio");
      return;
    }

    setSaving(true);
    try {
      const payload = {
        name: nombre.trim(),
        ruc: ruc.trim() || undefined,
        address: direccion.trim() || undefined,
        phone: telefono.trim() || undefined,
        email: correo.trim() || undefined,
      };

      if (isNew) {
        await createSigecoomClient(payload);
        toast.success("Cliente creado");
      } else {
        await updateSigecoomClient(cliente!.id, payload);
        toast.success("Cliente actualizado");
      }
      onSaved();
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo guardar el cliente");
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
        <div className="ml-2 text-[11.5px] font-semibold text-slate-700">{isNew ? "REGISTRAR CLIENTE" : "ACTUALIZAR CLIENTE"}</div>
      </div>

      <div className="p-3 overflow-auto min-h-0">
        <div className="grid grid-cols-12 gap-2 max-w-3xl">
          <Field label="Nombre / Razón social" className="col-span-8">
            <input className={inp} value={nombre} onChange={(e) => setNombre(e.target.value)} placeholder="Ingrese el nombre" />
          </Field>
          <Field label="RUC" className="col-span-4">
            <input className={inp} value={ruc} onChange={(e) => setRuc(e.target.value)} placeholder="00000000000" />
          </Field>
          <Field label="Dirección" className="col-span-8">
            <input className={inp} value={direccion} onChange={(e) => setDireccion(e.target.value)} placeholder="Dirección fiscal" />
          </Field>
          <Field label="Teléfono" className="col-span-4">
            <input className={inp} value={telefono} onChange={(e) => setTelefono(e.target.value)} placeholder="999999999" />
          </Field>
          <Field label="Correo" className="col-span-6">
            <input className={inp} value={correo} onChange={(e) => setCorreo(e.target.value)} placeholder="correo@empresa.com" />
          </Field>
        </div>
      </div>
    </div>
  );
}

export function ClientesList() {
  const [rows, setRows] = useState<SigecoomClient[]>([]);
  const [loading, setLoading] = useState(false);
  const [searched, setSearched] = useState(false);
  const [search, setSearch] = useState("");
  const [selected, setSelected] = useState<SigecoomClient | null>(null);
  const [showForm, setShowForm] = useState(false);
  const [isNew, setIsNew] = useState(false);

  const load = useCallback(async () => {
    setLoading(true);
    try {
      const res = await fetchSigecoomClients(0, 0);
      setRows(res.items);
      setSearched(true);
    } catch (e: any) {
      toast.error(e.message ?? "Error al cargar clientes");
    } finally {
      setLoading(false);
    }
  }, []);

  useEffect(() => {
    load();
  }, [load]);

  const [sortBy, setSortBy] = useState<{ col: string; asc: boolean }>({ col: "name", asc: true });
  const filteredRows = useMemo(() => {
    const q = search.trim().toLowerCase();
    let out = q
      ? rows.filter((row) => [row.name, row.ruc, row.address, row.phone, row.email].filter(Boolean).some((v) => String(v).toLowerCase().includes(q)))
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
    if (!confirm(`¿Eliminar el cliente ${selected.name}?`)) return;
    try {
      await deleteSigecoomClient(selected.id);
      toast.success("Cliente eliminado");
      setSelected(null);
      await load();
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo eliminar el cliente");
    }
  };

  if (showForm) {
    return (
      <ClienteForm
        cliente={isNew ? undefined : selected ?? undefined}
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
        <button className={iconBtn} title="Nuevo cliente" onClick={() => { setIsNew(true); setShowForm(true); }}><Plus className="h-4 w-4" /></button>
        <button className={iconBtn} title="Editar cliente" disabled={!selected} onClick={() => { setIsNew(false); setShowForm(true); }}><Pencil className="h-4 w-4" /></button>
        <button className={iconBtn} title="Eliminar cliente" disabled={!selected} onClick={handleDelete}><Trash2 className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Actualizar" onClick={load}><RefreshCw className="h-4 w-4" /></button>
        <button className={iconBtn} title="Salir" onClick={() => toast.info("Use la X superior para cerrar la ventana")}><LogOut className="h-4 w-4" /></button>
      </div>

      <div className="flex flex-wrap items-end gap-2 px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300">
        <Field label="Buscar" className="w-72">
          <input className={inp} value={search} onChange={(e) => setSearch(e.target.value)} placeholder="Nombre, RUC, correo o teléfono" />
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
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev.col === 'id' ? { col: 'id', asc: !prev.asc } : { col: 'id', asc: true })}>Código {sortBy.col === 'id' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev.col === 'name' ? { col: 'name', asc: !prev.asc } : { col: 'name', asc: true })}>Razón Social / Nombres {sortBy.col === 'name' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev.col === 'ruc' ? { col: 'ruc', asc: !prev.asc } : { col: 'ruc', asc: true })}>RUC {sortBy.col === 'ruc' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">Dirección</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">Teléfono</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">Correo</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">Estado</th>
              </tr>
            </thead>
            <tbody>
              {filteredRows.length === 0 ? (
                <tr>
                  <td colSpan={7} className="text-center py-8 text-slate-400 text-[11px]">
                    {loading ? "Cargando..." : searched ? "Sin resultados" : "Use la búsqueda y pulse Buscar"}
                  </td>
                </tr>
              ) : filteredRows.map((c, i) => {
                const isSel = selected?.id === c.id;
                return (
                  <tr
                    key={c.id}
                    onClick={() => setSelected(c)}
                    onDoubleClick={() => { setSelected(c); setIsNew(false); setShowForm(true); }}
                    className={[
                      "cursor-pointer border-b border-slate-200",
                      i % 2 ? "bg-[#F6F9FC]" : "bg-white",
                      isSel ? "!bg-[#D6E4F4] outline outline-1 outline-[#3E5B7A]" : "hover:bg-[#E8F0F8]/60",
                    ].join(" ")}
                  >
                    <td className="px-2 py-1 text-center border-r border-slate-200 font-mono font-semibold">{String(c.id).slice(0, 8).toUpperCase()}</td>
                    <td className="px-2 py-1 border-r border-slate-200">{c.name}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200 font-mono">{c.ruc || "-"}</td>
                    <td className="px-2 py-1 border-r border-slate-200 max-w-[260px] truncate">{c.address || "-"}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200">{c.phone || "-"}</td>
                    <td className="px-2 py-1 border-r border-slate-200 max-w-[220px] truncate">{c.email || "-"}</td>
                    <td className="px-2 py-1 text-center">{c.active ? "ACTIVO" : "INACTIVO"}</td>
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
