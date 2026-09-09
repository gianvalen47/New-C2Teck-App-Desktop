import { useEffect, useState } from "react";
import { FileDown, LogOut, Plus, RefreshCw, Save, Search, Trash2, X } from "lucide-react";
import { btn, btnPrimary, iconBtn, inp, squareIconBtn, tbSep } from "@/features/escritorio/windows/uiStyles";
import {
  createSigecoomLocation,
  deleteSigecoomLocation,
  fetchSigecoomLocations,
  type Location,
  updateSigecoomLocation,
} from "@/lib/sigecoom-api";

function Field({ label, className = "", children }: { label: string; className?: string; children: React.ReactNode }) {
  return (
    <label className={`flex flex-col gap-0.5 ${className}`}>
      <span className="text-[10.5px] text-slate-600 font-medium leading-tight">{label}</span>
      {children}
    </label>
  );
}

export function UbicacionesList() {
  const [locations, setLocations] = useState<Location[]>([]);
  const [selectedLocationId, setSelectedLocationId] = useState("");
  const [code, setCode] = useState("");
  const [warehouse, setWarehouse] = useState("Central Lima");
  const [aisle, setAisle] = useState("");
  const [shelf, setShelf] = useState("");
  const [row, setRow] = useState("");
  const [level, setLevel] = useState("");
  const [capacity, setCapacity] = useState<number | "">("");
  const [occupancy, setOccupancy] = useState<number | "">("");
  const [loading, setLoading] = useState(true);
  const [saving, setSaving] = useState(false);
  const [message, setMessage] = useState<string | null>(null);

  const resetForm = () => {
    setSelectedLocationId("");
    setCode("");
    setWarehouse("Central Lima");
    setAisle("");
    setShelf("");
    setRow("");
    setLevel("");
    setCapacity("");
    setOccupancy("");
    setMessage(null);
  };

  const loadLocations = async () => {
    setLoading(true);
    setMessage(null);
    try {
      const data = await fetchSigecoomLocations();
      setLocations(data);
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error cargando ubicaciones");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    void loadLocations();
  }, []);

  const handleSave = async () => {
    if (!code.trim() || !warehouse.trim()) {
      setMessage("Código y almacén son obligatorios.");
      return;
    }
    setSaving(true);
    setMessage(null);
    try {
      const payload = {
        code: code.trim(),
        warehouse: warehouse.trim(),
        aisle: aisle.trim() || undefined,
        shelf: shelf.trim() || undefined,
        row: row.trim() || undefined,
        level: level.trim() || undefined,
        description: undefined,
        capacity: capacity === "" ? undefined : Number(capacity),
        occupancy_percent: occupancy === "" ? undefined : Number(occupancy),
      };
      if (selectedLocationId) {
        await updateSigecoomLocation(selectedLocationId, payload);
        setMessage("Ubicación actualizada correctamente.");
      } else {
        await createSigecoomLocation(payload);
        setMessage("Ubicación creada correctamente.");
      }
      resetForm();
      await loadLocations();
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo guardar la ubicación");
    } finally {
      setSaving(false);
    }
  };

  const handleSelect = (location: Location) => {
    setSelectedLocationId(location.id);
    setCode(location.code);
    setWarehouse(location.warehouse);
    setAisle(location.aisle ?? "");
    setShelf(location.shelf ?? "");
    setRow(location.row ?? "");
    setLevel(location.level ?? "");
    setCapacity(location.capacity ?? "");
    setOccupancy(location.occupancy_percent ?? "");
    setMessage(null);
  };

  const handleDelete = async () => {
    if (!selectedLocationId) {
      setMessage("Seleccione primero una ubicación para eliminar.");
      return;
    }
    setSaving(true);
    setMessage(null);
    try {
      await deleteSigecoomLocation(selectedLocationId);
      setMessage("Ubicación eliminada correctamente.");
      resetForm();
      await loadLocations();
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo eliminar la ubicación");
    } finally {
      setSaving(false);
    }
  };

  return (
    <div className="h-full flex flex-col bg-[#EEF3F8] text-slate-800">
      <div className="flex items-center justify-between px-3 py-1.5 bg-gradient-to-b from-[#3E5B7A] to-[#2A3F55] border-b border-[#1F2E3F] text-[12px] text-white">
        <span className="font-medium">Ubicaciones de Almacén — Configuración geométrica</span>
        <div className="flex items-center gap-1">
          <button className={iconBtn} title="Guardar" onClick={() => void handleSave()} disabled={saving}><Save className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Nuevo" onClick={resetForm}><Plus className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Actualizar" onClick={() => void loadLocations()}><RefreshCw className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Eliminar" onClick={() => void handleDelete()}><Trash2 className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Exportar"><FileDown className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4 text-white" /></button>
        </div>
      </div>

      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EDF2F7] to-[#D9E2EC] border-b border-slate-300 text-slate-700 overflow-x-auto">
        <button className={squareIconBtn} title="Guardar" onClick={() => void handleSave()}><Save className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Nuevo" onClick={resetForm}><Plus className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Actualizar" onClick={() => void loadLocations()}><RefreshCw className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Eliminar" onClick={() => void handleDelete()}><Trash2 className="h-3.5 w-3.5" /></button>
        {tbSep}
        <button className={squareIconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Cerrar"><X className="h-3.5 w-3.5" /></button>
      </div>

      <div className="flex-1 min-h-0 overflow-auto p-3">
        {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
        <div className="grid grid-cols-5 gap-2 mb-3">
          <Field label="Código"><input className={inp} value={code} onChange={(e) => setCode(e.target.value)} placeholder="UB-001" /></Field>
          <Field label="Almacén"><select className={inp} value={warehouse} onChange={(e) => setWarehouse(e.target.value)}><option>Central Lima</option><option>Norte</option><option>Sur</option></select></Field>
          <Field label="Pasillo"><input className={inp} value={aisle} onChange={(e) => setAisle(e.target.value)} /></Field>
          <Field label="Estantería"><input className={inp} value={shelf} onChange={(e) => setShelf(e.target.value)} /></Field>
          <Field label="Fila"><input className={inp} value={row} onChange={(e) => setRow(e.target.value)} /></Field>
          <Field label="Nivel"><input className={inp} value={level} onChange={(e) => setLevel(e.target.value)} /></Field>
          <Field label="Capacidad"><input className={inp} type="number" value={capacity} onChange={(e) => setCapacity(e.target.value === "" ? "" : Number(e.target.value))} /></Field>
          <Field label="Ocupación %"><input className={inp} type="number" value={occupancy} onChange={(e) => setOccupancy(e.target.value === "" ? "" : Number(e.target.value))} /></Field>
        </div>

        <div className="border border-slate-300 rounded-sm bg-white overflow-auto shadow-sm">
          <table className="w-full text-[11px] border-collapse">
            <thead className="bg-[#F3F6FA]"><tr>
              <th className="px-2 py-2 text-left border-b border-slate-300">Sel</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Código</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Almacén</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Pasillo</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Estantería</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Fila</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Nivel</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">Capacidad</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">Ocupación</th>
            </tr></thead>
            <tbody>
              {loading ? (
                <tr><td colSpan={9} className="px-2 py-4 text-sm text-slate-500">Cargando ubicaciones...</td></tr>
              ) : locations.length === 0 ? (
                <tr><td colSpan={9} className="px-2 py-4 text-sm text-slate-500">No hay ubicaciones registradas.</td></tr>
              ) : locations.map((location) => (
                <tr key={location.id} className={`hover:bg-slate-50 ${selectedLocationId === location.id ? "bg-slate-100" : ""}`} onClick={() => handleSelect(location)}>
                  <td className="px-2 py-2 border-b border-slate-200 text-center"><input type="radio" name="selectedLocation" checked={selectedLocationId === location.id} readOnly /></td>
                  <td className="px-2 py-2 border-b border-slate-200">{location.code}</td>
                  <td className="px-2 py-2 border-b border-slate-200">{location.warehouse}</td>
                  <td className="px-2 py-2 border-b border-slate-200">{location.aisle}</td>
                  <td className="px-2 py-2 border-b border-slate-200">{location.shelf}</td>
                  <td className="px-2 py-2 border-b border-slate-200">{location.row}</td>
                  <td className="px-2 py-2 border-b border-slate-200">{location.level}</td>
                  <td className="px-2 py-2 text-right border-b border-slate-200">{location.capacity ?? "-"}</td>
                  <td className="px-2 py-2 text-right border-b border-slate-200">{location.occupancy_percent ?? "-"}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}

