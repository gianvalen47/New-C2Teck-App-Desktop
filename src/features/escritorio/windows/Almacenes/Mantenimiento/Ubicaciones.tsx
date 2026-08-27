// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { useState, useEffect } from "react";
import {
  inp,
  Field,
  WindowShell
} from "@/components/ui/desktop-primitives";
import {
  fetchSigecoomLocations,
  createSigecoomLocation,
  updateSigecoomLocation,
  deleteSigecoomLocation,
  type Location
} from "@/lib/sigecoom-api";

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
    loadLocations();
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
    <WindowShell title="Ubicaciones de Almacén — Configuración geométrica"
    >
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
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
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
    </WindowShell>
  );
}
