import { useEffect, useMemo, useState } from "react";
import {
  CalendarDays,
  ChevronDown,
  ChevronUp,
  Clock3,
  FileText,
  LogOut,
  Mail,
  Pencil,
  Plus,
  Printer,
  Receipt,
  RefreshCw,
  Save,
  Search,
  Send,
  Trash2,
  Wrench,
  X,
} from "lucide-react";
import { toast } from "sonner";
import { stdToolbar5 } from "@/features/escritorio/windows/shared/toolbarPresets";
import { actionBtn, btn, btnPrimary, iconBtn, inp, squareIconBtn, tbSep } from "@/features/escritorio/windows/uiStyles";
import { fetchBoletas, fetchSession, getSessionTipoCambioCompra } from "@/lib/sigecoom-api";
import { Field, InlineField, YearSpinner, EstadoBadge, DraggableFormWindow, type BoletaFormWindow, FiltersPanel, ESTADO_FILTER_OPTIONS } from "@/features/escritorio/windows/shared/uiComponents";

type BoletaRow = {
  id: string;
  numero: string;
  fecha: string;
  cliente: string;
  moneda: string;
  total: string;
  estado: string;
  sunat: string;
  codigo: string;
  observacion: string;
};

const formatCurrency = (value: number) =>
  new Intl.NumberFormat("es-PE", {
    style: "currency",
    currency: "PEN",
    minimumFractionDigits: 2,
    maximumFractionDigits: 2,
  }).format(Number.isFinite(value) ? value : 0);

const normalizeBoletaRow = (item: any): BoletaRow => {
  const idValue = item?.id ?? item?.Id ?? item?.numero ?? item?.num_doc ?? item?.serie ?? "boleta";
  const numero = item?.numero ?? item?.num_doc ?? item?.number ?? item?.serie ?? "B001";
  const fecha = String(item?.fecha ?? item?.date ?? item?.fec_emision ?? item?.created_at ?? "").slice(0, 10);
  const cliente = item?.cliente ?? item?.client_name ?? item?.nombre_cliente ?? item?.razon_social ?? item?.cliente_nombre ?? "CLIENTE";
  const totalValue = Number(item?.total ?? item?.tot_venta ?? item?.tot_neto ?? item?.monto_total ?? 0);

  return {
    id: String(idValue),
    numero: String(numero),
    fecha,
    cliente: String(cliente),
    moneda: String(item?.moneda ?? item?.currency ?? "PEN"),
    total: formatCurrency(totalValue),
    estado: String(item?.estado ?? item?.status ?? "GENERADO").toUpperCase(),
    sunat: String(item?.estado_sunat ?? item?.sunat ?? item?.estadoSunat ?? "PENDIENTE").toUpperCase(),
    codigo: String(item?.cod_serie ?? item?.serie ?? item?.codigo ?? "B001"),
    observacion: String(item?.observacion ?? item?.descripcion ?? item?.motivo ?? ""),
  };
};

const initialRows: BoletaRow[] = [
  { id: "B-1001", numero: "B001-1001", fecha: "2026-09-08", cliente: "LUCY VENTAS S.A.C.", moneda: "PEN", total: "1,248.00", estado: "GENERADO", sunat: "ACEPTADO", codigo: "B001", observacion: "Venta al contado" },
  { id: "B-1002", numero: "B001-1002", fecha: "2026-09-08", cliente: "MERCADOS DEL SUR", moneda: "PEN", total: "2,430.50", estado: "APROBADO", sunat: "PENDIENTE", codigo: "B001", observacion: "Entrega programada" },
  { id: "B-1003", numero: "B001-1003", fecha: "2026-09-07", cliente: "INVERSIONES PUNTO DOC", moneda: "USD", total: "518.25", estado: "CREDITOS", sunat: "ENVIADO", codigo: "B001", observacion: "Facturación con tarjeta" },
  { id: "B-1004", numero: "B001-1004", fecha: "2026-09-06", cliente: "ALMACEN DEL NORTE", moneda: "PEN", total: "3,600.00", estado: "ANULADO", sunat: "BAJA", codigo: "B001", observacion: "Cancelado por solicitud" },
  { id: "B-1005", numero: "B001-1005", fecha: "2026-09-05", cliente: "COSTA BRAVA EIRL", moneda: "PEN", total: "820.00", estado: "GENERADO", sunat: "PENDIENTE", codigo: "B001", observacion: "Venta normal" },
];



function BoletaEditor({
  row,
  onClose,
  mode,
  onSave,
}: {
  row: BoletaRow;
  onClose: () => void;
  mode: "view" | "edit" | "new";
  onSave: (next: BoletaRow) => void;
}) {
  const [form, setForm] = useState<BoletaRow>(row);
  const [tipoCambio, setTipoCambio] = useState<string>(() => String(getSessionTipoCambioCompra() ?? "3.402"));
  const editable = mode === "edit" || mode === "new";

  useEffect(() => {
    const sessionValue = getSessionTipoCambioCompra();
    if (sessionValue != null) {
      setTipoCambio(String(sessionValue));
      return;
    }

    fetchSession()
      .then((session) => {
        if (session.tipo_cambio_compra != null) {
          setTipoCambio(String(session.tipo_cambio_compra));
        }
      })
      .catch(() => {
        setTipoCambio("3.402");
      });
  }, []);

  return (
    <div className="h-full flex flex-col overflow-hidden bg-[#F3F6FA] text-[11px] select-none">
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-300 shrink-0 overflow-x-auto">
        <button className={iconBtn} title="Editar cabecera">
          <Pencil className="h-4 w-4" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Grabar" onClick={() => { onSave(form); onClose(); }}>
          <Save className="h-4 w-4 text-emerald-700" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Reiniciar" onClick={onClose}>
          <RefreshCw className="h-4 w-4 text-blue-600" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Enviar XML">
          <Send className="h-4 w-4" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Imprimir">
          <Printer className="h-4 w-4" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Salir" onClick={onClose}>
          <LogOut className="h-4 w-4 text-red-600" />
        </button>
      </div>

      <div className="text-center text-[11px] font-semibold text-slate-800 py-1 bg-[#EEF2F7] border-b border-slate-300 shrink-0">
        OFICINA: LIMA &nbsp;-&nbsp; ALMACEN: COMERCIAL
      </div>

      <div className="flex-1 overflow-hidden min-h-0">
        <div className="border border-slate-300 bg-[#F8FBFF] p-2 shadow-sm text-[11px] h-full flex flex-col">
          <div className="space-y-1 flex-1 flex flex-col">
            <div className="grid grid-cols-[110px_130px_120px_110px_130px] gap-2 items-center">
              <InlineField label="Número" labelWidth="w-[55px]">
                <input className={`${inp} font-mono`} value={form.numero} onChange={(e) => setForm((p) => ({ ...p, numero: e.target.value }))} readOnly={!editable} />
              </InlineField>
              <InlineField label="Fecha" labelWidth="w-[45px]">
                <input type="date" className={inp} value={form.fecha} onChange={(e) => setForm((p) => ({ ...p, fecha: e.target.value }))} readOnly={!editable} />
              </InlineField>
              <InlineField label="Moneda" labelWidth="w-[52px]">
                <select className={inp} value={form.moneda} onChange={(e) => setForm((p) => ({ ...p, moneda: e.target.value }))} disabled={!editable}>
                  <option value="PEN">PEN (S/)</option>
                  <option value="USD">USD ($)</option>
                </select>
              </InlineField>
              <InlineField label="Total" labelWidth="w-[38px]">
                <input className={`${inp} font-mono`} value={form.total} onChange={(e) => setForm((p) => ({ ...p, total: e.target.value }))} readOnly={!editable} />
              </InlineField>
              <InlineField label="T.Cambio" labelWidth="w-[60px]">
                <input
                  className={`${inp} font-mono`}
                  value={tipoCambio}
                  readOnly
                  placeholder="Tipo de cambio"
                />
              </InlineField>
            </div>

            <div className="grid grid-cols-[1fr_130px_130px] gap-2 items-center">
              <InlineField label="Cliente" labelWidth="w-[60px]">
                <div className="flex gap-1 items-center w-full">
                  <input className={inp} value={form.cliente} onChange={(e) => setForm((p) => ({ ...p, cliente: e.target.value }))} readOnly={!editable} placeholder="(Buscar cliente…)" />
                  <button type="button" className={iconBtn} title="Buscar Cliente">
                    <Search className="h-3.5 w-3.5" />
                  </button>
                </div>
              </InlineField>
              <InlineField label="Estado" labelWidth="w-[46px]">
                <select className={inp} value={form.estado} onChange={(e) => setForm((p) => ({ ...p, estado: e.target.value }))} disabled={!editable}>
                  <option value="GENERADO">GENERADO</option>
                  <option value="APROBADO">APROBADO</option>
                  <option value="CREDITOS">CREDITOS</option>
                  <option value="ANULADO">ANULADO</option>
                </select>
              </InlineField>
              <InlineField label="Código" labelWidth="w-[42px]">
                <input className={inp} value={form.codigo} onChange={(e) => setForm((p) => ({ ...p, codigo: e.target.value }))} readOnly={!editable} />
              </InlineField>
            </div>

            <div className="grid grid-cols-[1fr_180px] gap-2 items-center">
              <InlineField label="Observación" labelWidth="w-[82px]">
                <div className="flex gap-1 items-center w-full">
                  <input className={inp} value={form.observacion} onChange={(e) => setForm((p) => ({ ...p, observacion: e.target.value }))} readOnly={!editable} />
                  <button type="button" className={iconBtn} title="Editar observación">
                    <FileText className="h-3.5 w-3.5" />
                  </button>
                </div>
              </InlineField>
              <InlineField label="Sunat" labelWidth="w-[40px]">
                <select className={inp} value={form.sunat} onChange={(e) => setForm((p) => ({ ...p, sunat: e.target.value }))} disabled={!editable}>
                  <option value="ACEPTADO">ACEPTADO</option>
                  <option value="PENDIENTE">PENDIENTE</option>
                  <option value="ENVIADO">ENVIADO</option>
                  <option value="BAJA">BAJA</option>
                </select>
              </InlineField>
            </div>

            <div className="rounded border border-slate-300 bg-white px-3 py-2">
              <div className="text-[11px] font-semibold text-slate-700 mb-2">Referencia</div>
              <div className="grid gap-2">
                <div className="grid grid-cols-[150px_150px_1fr] gap-2 items-center">
                  <InlineField label="Tipo Doc" labelWidth="w-[58px]">
                    <select className={inp} defaultValue="FACT">
                      <option value="FACT">FACT</option>
                      <option value="BOL">BOL</option>
                    </select>
                  </InlineField>
                  <InlineField label="Serie" labelWidth="w-[42px]">
                    <input className={inp} defaultValue={form.codigo} readOnly />
                  </InlineField>
                  <InlineField label="N° Doc" labelWidth="w-[42px]">
                    <input className={inp} value={form.numero} readOnly />
                  </InlineField>
                </div>
                <div className="grid grid-cols-[180px_1fr] gap-2 items-center">
                  <InlineField label="Tipo Afectación" labelWidth="w-[86px]">
                    <select className={inp} defaultValue="Gravado - Operación One">
                      <option value="Gravado - Operación One">Gravado - Operación One</option>
                      <option value="Exonerado">Exonerado</option>
                      <option value="Inafecto">Inafecto</option>
                    </select>
                  </InlineField>
                  <InlineField label="Motivo" labelWidth="w-[42px]">
                    <input className={inp} value={form.observacion} readOnly={!editable} />
                  </InlineField>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div className="shrink-0 border-t border-slate-300 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-1.5 flex items-center justify-end gap-2">
        <button className={btn} onClick={onClose}><X className="h-3.5 w-3.5" />Cerrar</button>
        <button className={btnPrimary} onClick={() => { onSave(form); onClose(); }}><Save className="h-3.5 w-3.5" />Guardar</button>
      </div>
    </div>
  );
}

function boletaNumero(row: any): string {
  const num = row.num_doc ?? row.number ?? row.numero;
  if (num === null || num === undefined || num === "") return "";
  return String(num);
}

function boletaFecha(row: any): string {
  const f = row.fec_doc ?? row.date ?? row.fecha;
  if (!f) return "";
  const s = String(f);
  if (s.includes("T")) {
    const [d] = s.split("T");
    const [yy, mm, dd] = d.split("-");
    if (yy && mm && dd) return `${dd}/${mm}/${yy}`;
  }
  if (s.includes("-")) {
    const [yy, mm, dd] = s.slice(0, 10).split("-");
    if (yy && mm && dd) return `${dd}/${mm}/${yy}`;
  }
  return s;
}

function boletaCliente(row: any): string {
  return String(row.cliente_nombre ?? row.cliente?.nombre ?? row.cliente ?? row.client_id ?? "").trim();
}

function boletaMoneda(row: any): string {
  const m = String(row.cod_mon ?? row.moneda ?? "").trim().toUpperCase();
  if (m === "US" || m === "USD" || m.includes("DOL")) return "US";
  if (m === "NS" || m === "PEN" || m.includes("SOL")) return "NS";
  return m || "NS";
}

function boletaTotal(row: any): number {
  const t = Number(row.tot_neto ?? row.total ?? 0);
  return Number.isFinite(t) ? t : 0;
}

function boletaTotNetoSug(row: any): number {
  const t = Number(row.tot_neto_sug ?? 0);
  return Number.isFinite(t) ? t : 0;
}

function boletaEst(row: any): string {
  const e = String(row.estado ?? row.status ?? "").trim().toUpperCase();
  if (e === "GENERADO") return "GN";
  if (e === "APROBADO") return "AP";
  if (e === "CREDITOS") return "CR";
  if (e === "ANULADO") return "AN";
  if (e === "IMPRESO") return "IM";
  return e.slice(0, 2);
}

function boletaEstadoSunat(row: any): string {
  return String(row.estado_sunat ?? row.sunat ?? "PENDIENTE").trim().toUpperCase();
}

const MESES = [
  "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO",
  "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE",
];

export function BoletaList() {
  const [rows, setRows] = useState<any[]>([]);
  const [loading, setLoading] = useState(false);
  const [searched, setSearched] = useState(false);
  const [locations, setLocations] = useState<any[]>([]);
  const [anio, setAnio] = useState(() => String(new Date().getFullYear()));
  const [mes, setMes] = useState(() => String(new Date().getMonth() + 1));
  const [officeFilter, setOfficeFilter] = useState("");
  const [warehouseFilter, setWarehouseFilter] = useState("");
  const [tipFac, setTipFac] = useState("1");
  const [serieFilter, setSerieFilter] = useState("");
  const [clientFilterLabel, setClientFilterLabel] = useState("(Todos)");
  const [clientFilterId, setClientFilterId] = useState("");
  const [estado, setEstado] = useState("");
  const [numDoc, setNumDoc] = useState("");
  const [selected, setSelected] = useState<any | null>(null);
  const [showEditor, setShowEditor] = useState(false);
  const [mode, setMode] = useState<"view" | "edit" | "new">("view");
  const [sortBy, setSortBy] = useState<{ col: string; asc: boolean }>({ col: "num_doc", asc: false });
  const [window, setWindow] = useState<BoletaFormWindow>({ id: "boleta-editor", title: "Boleta", x: 170, y: 110, w: 920, h: 560, z: 35 });

  const load = async () => {
    setLoading(true);
    setSearched(true);
    try {
      const payload = await fetchBoletas({
        anio: anio ? Number(anio) : undefined,
        mes: mes ? Number(mes) : undefined,
        tip_fac: tipFac || undefined,
        serie: serieFilter || undefined,
        id_cliente: clientFilterId ? Number(clientFilterId) : undefined,
        estado: estado || undefined,
        num_doc: numDoc ? Number(numDoc) : undefined,
        limit: 500,
      });
      setRows(payload);
      if (payload.length > 0) {
        setSelected(payload[0]);
      } else {
        setSelected(null);
      }
    } catch (error: any) {
      toast.error(error?.message ?? "No se pudieron cargar las boletas");
      setRows([]);
      setSelected(null);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    void load();
  }, []);

  const toggleSortBy = (col: string) => {
    setSortBy((prev) => ({
      col,
      asc: prev.col === col ? !prev.asc : true,
    }));
  };

  const rowsView = useMemo(() => {
    const arr = [...rows];
    const col = sortBy.col;
    arr.sort((a: any, b: any) => {
      let va = a[col];
      let vb = b[col];
      if (col === "total" || col === "tot_neto") {
        va = boletaTotal(a);
        vb = boletaTotal(b);
      }
      if (va == null && vb == null) return 0;
      if (va == null) return sortBy.asc ? -1 : 1;
      if (vb == null) return sortBy.asc ? 1 : -1;
      if (typeof va === "number" && typeof vb === "number") return sortBy.asc ? va - vb : vb - va;
      return sortBy.asc ? String(va).localeCompare(String(vb)) : String(vb).localeCompare(String(va));
    });
    return arr;
  }, [rows, sortBy]);

  const openNew = () => {
    setMode("new");
    setShowEditor(true);
  };

  const openEdit = (row: any) => {
    setSelected(row);
    setMode("edit");
    setShowEditor(true);
  };

  const saveRow = (next: any) => {
    setRows((prev) => {
      const idx = prev.findIndex((row) => row.id === next.id);
      if (idx >= 0) {
        const copy = [...prev];
        copy[idx] = next;
        return copy;
      }
      return [next, ...prev];
    });
    setSelected(next);
  };

  return (
    <div className="relative h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
      {/* Toolbar fiel a frmBoletas.vb */}
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0 overflow-x-auto">
        <button className={iconBtn} title="Imprimir Boleta"><Printer className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Imprimir Ticket"><Printer className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Crear un nuevo registro" onClick={openNew}><Plus className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Mostrar Boleta" onClick={() => selected && openEdit(selected)} disabled={!selected}><Search className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Eliminar el registro seleccionado" disabled={!selected}><Trash2 className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Anular Boleta" disabled={!selected}><X className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Enviar Boleta Electrónica" disabled={!selected}><Send className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Actualizar" onClick={() => void load()}><RefreshCw className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Cerrar la ventana actual"><LogOut className="h-4 w-4" /></button>
      </div>

      {/* Datos de Búsqueda fiel a frmBoletas.vb */}
      <div className="flex items-center gap-1.5 flex-wrap px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300 text-[11px]">
        {/* Año */}
        <div className="flex flex-col gap-0.5">
          <span className="text-[10px] text-slate-600 font-medium">Año</span>
          <input className={`${inp} w-16 font-mono text-center`} value={anio} onChange={(e) => setAnio(e.target.value)} />
        </div>
        {/* Mes */}
        <div className="flex flex-col gap-0.5 w-[110px]">
          <span className="text-[10px] text-slate-600 font-medium">Mes</span>
          <select className={inp} value={mes} onChange={(e) => setMes(e.target.value)}>
            <option value="">(Todos)</option>
            {MESES.map((m, i) => (
              <option key={m} value={String(i + 1)}>{m}</option>
            ))}
          </select>
        </div>
        {/* Tipo */}
        <div className="flex flex-col gap-0.5 w-[90px]">
          <span className="text-[10px] text-slate-600 font-medium">Tipo</span>
          <select className={inp} value={tipFac} onChange={(e) => setTipFac(e.target.value)}>
            <option value="1">Credito</option>
            <option value="2">Contado</option>
            <option value="">(Todos)</option>
          </select>
        </div>
        {/* Serie */}
        <div className="flex flex-col gap-0.5 w-[85px]">
          <span className="text-[10px] text-slate-600 font-medium">Serie</span>
          <select className={inp} value={serieFilter} onChange={(e) => setSerieFilter(e.target.value)}>
            <option value="">(Todos)</option>
            <option value="B001">B001</option>
            <option value="B002">B002</option>
            <option value="B003">B003</option>
            <option value="B005">B005</option>
            <option value="B008">B008</option>
          </select>
        </div>
        {/* Cliente */}
        <div className="flex flex-col gap-0.5 w-[180px]">
          <span className="text-[10px] text-slate-600 font-medium">Cliente</span>
          <div className="flex gap-1">
            <input className={inp} value={clientFilterLabel} placeholder="(Todos)" readOnly />
            <button
              type="button"
              className={actionBtn}
              title="Limpiar Cliente"
              onClick={() => {
                setClientFilterId("");
                setClientFilterLabel("(Todos)");
              }}
            >
              <X className="h-3.5 w-3.5 text-amber-700" />
            </button>
          </div>
        </div>
        {/* Estado */}
        <div className="flex flex-col gap-0.5 w-[100px]">
          <span className="text-[10px] text-slate-600 font-medium">Estado</span>
          <select className={inp} value={estado} onChange={(e) => setEstado(e.target.value)}>
            <option value="">(Todos)</option>
            <option value="GN">GENERADO</option>
            <option value="AP">APROBADO</option>
            <option value="CR">CREDITOS</option>
            <option value="AN">ANULADO</option>
            <option value="IM">IMPRESO</option>
          </select>
        </div>
        {/* Número */}
        <div className="flex flex-col gap-0.5 w-[80px]">
          <span className="text-[10px] text-slate-600 font-medium">Número</span>
          <input className={`${inp} font-mono`} value={numDoc} onChange={(e) => setNumDoc(e.target.value)} placeholder="0" />
        </div>
        {/* Botón Buscar */}
        <div className="flex flex-col justify-end">
          <button className={btnPrimary} onClick={() => void load()} disabled={loading}>
            <Search className="h-3.5 w-3.5" />
            {loading ? "Buscando..." : "Buscar"}
          </button>
        </div>
      </div>

      {/* Grid fiel a frmBoletas.resx */}
      <div className="flex-1 min-h-0 overflow-auto p-1.5">
        <div className="border border-slate-400/60 bg-white rounded-sm h-full overflow-auto">
          <div className="overflow-auto flex-1 h-full">
            <table className="w-full text-[11.5px] border-collapse">
              <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 sticky top-0 z-10 select-none shadow-xs">
                <tr>
                  <th className="w-6 px-1 py-1 text-center border-r border-slate-300 font-semibold"></th>
                  <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy("num_doc")}>
                    Número {sortBy.col === "num_doc" ? (sortBy.asc ? "▲" : "▼") : ""}
                  </th>
                  <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy("fec_doc")}>
                    Fecha {sortBy.col === "fec_doc" ? (sortBy.asc ? "▲" : "▼") : ""}
                  </th>
                  <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy("cliente_nombre")}>
                    Cliente {sortBy.col === "cliente_nombre" ? (sortBy.asc ? "▲" : "▼") : ""}
                  </th>
                  <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy("cod_mon")}>
                    Mon. {sortBy.col === "cod_mon" ? (sortBy.asc ? "▲" : "▼") : ""}
                  </th>
                  <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy("tot_neto")}>
                    Total {sortBy.col === "tot_neto" ? (sortBy.asc ? "▲" : "▼") : ""}
                  </th>
                  <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy("estado")}>
                    EST {sortBy.col === "estado" ? (sortBy.asc ? "▲" : "▼") : ""}
                  </th>
                  <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy("estado_sunat")}>
                    Estado Sunat {sortBy.col === "estado_sunat" ? (sortBy.asc ? "▲" : "▼") : ""}
                  </th>
                  <th className="w-8 px-1 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy("contabilizado")}>
                    C {sortBy.col === "contabilizado" ? (sortBy.asc ? "▲" : "▼") : ""}
                  </th>
                  <th className="w-10 px-1 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy("tiene_notas")}>
                    Nota {sortBy.col === "tiene_notas" ? (sortBy.asc ? "▲" : "▼") : ""}
                  </th>
                  <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy("tot_neto_sug")}>
                    TotNetoSug {sortBy.col === "tot_neto_sug" ? (sortBy.asc ? "▲" : "▼") : ""}
                  </th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-200">
                {rowsView.length === 0 ? (
                  <tr>
                    <td colSpan={11} className="text-center py-8 text-slate-400 text-[11px]">
                      {loading ? "Cargando boletas..." : searched ? "Sin registros para los filtros seleccionados" : "Use los filtros y pulse Buscar"}
                    </td>
                  </tr>
                ) : (
                  rowsView.map((r, i) => {
                    const isSel = selected?.id === r.id;
                    return (
                      <tr
                        key={r.id}
                        onClick={() => setSelected(r)}
                        onDoubleClick={() => openEdit(r)}
                        className={[
                          "cursor-pointer border-b border-slate-200 transition-colors",
                          i % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]",
                          isSel ? "!bg-[#D6E4F4] outline outline-1 outline-[#3E5B7A] font-medium" : "hover:bg-[#E8F0F8]/70",
                        ].join(" ")}
                      >
                        {/* Indicador flecha ▶ */}
                        <td className="w-6 px-1 py-1 text-center border-r border-slate-200 text-[#2D5A88] text-[10px] select-none font-bold">
                          {isSel ? "▶" : ""}
                        </td>
                        {/* Número */}
                        <td className="px-2 py-1 border-r border-slate-200 font-mono text-center font-semibold text-slate-800">
                          {boletaNumero(r)}
                        </td>
                        {/* Fecha */}
                        <td className="px-2 py-1 border-r border-slate-200 text-center whitespace-nowrap font-mono text-slate-700">
                          {boletaFecha(r)}
                        </td>
                        {/* Cliente */}
                        <td className="px-2 py-1 border-r border-slate-200 max-w-[280px] truncate text-slate-800" title={boletaCliente(r)}>
                          {boletaCliente(r)}
                        </td>
                        {/* Mon. */}
                        <td className="px-2 py-1 border-r border-slate-200 text-center font-mono text-slate-700">
                          {boletaMoneda(r)}
                        </td>
                        {/* Total */}
                        <td className="px-2 py-1 border-r border-slate-200 font-mono text-right font-semibold text-slate-800">
                          {boletaTotal(r).toFixed(2)}
                        </td>
                        {/* EST */}
                        <td className="px-2 py-1 border-r border-slate-200 text-center font-mono font-bold text-slate-800">
                          {boletaEst(r)}
                        </td>
                        {/* Estado Sunat */}
                        <td className="px-2 py-1 border-r border-slate-200 text-center font-medium text-slate-700">
                          {boletaEstadoSunat(r)}
                        </td>
                        {/* C (Contabilizado) */}
                        <td className="w-8 px-1 py-1 border-r border-slate-200 text-center">
                          <input
                            type="checkbox"
                            checked={Boolean(r.contabilizado)}
                            readOnly
                            className="h-3.5 w-3.5 accent-blue-700 pointer-events-none rounded-sm border border-slate-400 bg-white"
                            title={r.contabilizado ? "Contabilizado" : "No contabilizado"}
                          />
                        </td>
                        {/* Nota (TieneNotas) */}
                        <td className="w-10 px-1 py-1 border-r border-slate-200 text-center">
                          <input
                            type="checkbox"
                            checked={Boolean(r.tiene_notas)}
                            readOnly
                            className="h-3.5 w-3.5 accent-blue-700 pointer-events-none rounded-sm border border-slate-400 bg-white"
                            title={r.tiene_notas ? "Tiene nota" : "Sin nota"}
                          />
                        </td>
                        {/* TotNetoSug */}
                        <td className="px-2 py-1 border-r border-slate-200 font-mono text-right font-semibold text-slate-700">
                          {boletaTotNetoSug(r).toFixed(2)}
                        </td>
                      </tr>
                    );
                  })
                )}
              </tbody>
            </table>
          </div>
        </div>
      </div>

      {/* Footer fiel a sslTotal */}
      <div className="shrink-0 border-t border-slate-400/50 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-0.5 text-[11px] text-slate-700 font-medium flex items-center justify-between whitespace-nowrap overflow-hidden">
        <div>Registros : {rowsView.length}</div>
        <div className="text-[10.5px] text-slate-500">
          Total Selección: {selected ? `${boletaMoneda(selected)} ${boletaTotal(selected).toFixed(2)}` : "-"}
        </div>
      </div>

      {showEditor && selected && (
        <DraggableFormWindow
          win={window}
          onFocus={() => setWindow((prev) => ({ ...prev, z: prev.z + 1 }))}
          onMove={(id, x, y) => setWindow((prev) => ({ ...prev, id, x, y }))}
          onClose={() => setShowEditor(false)}
        >
          <BoletaEditor
            row={selected}
            mode={mode}
            onClose={() => setShowEditor(false)}
            onSave={saveRow}
          />
        </DraggableFormWindow>
      )}
    </div>
  );
}

export function Boletas() {
  return <BoletaList />;
}

export default Boletas;

