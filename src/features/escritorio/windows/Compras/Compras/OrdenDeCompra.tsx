import { useMemo, useState } from "react";
import {
  Archive,
  Ban,
  Check,
  ClipboardCheck,
  Eye,
  FileText,
  LogOut,
  Mail,
  Pencil,
  Printer,
  RefreshCw,
  Search,
  Settings,
  Trash2,
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

type OrdenCompraRow = {
  codigo: string;
  fecha: string;
  solicitante: string;
  proveedor: string;
  moneda: string;
  total: string;
  estado: string;
  solicitud: string;
  area: string;
};

const AREA_OPTIONS: CodeDescOption[] = [
  { code: "01", label: "Dirección y Gerencia General", value: "Dirección y Gerencia General" },
  { code: "02", label: "Administración", value: "Administración" },
  { code: "03", label: "Almacén", value: "Almacén" },
  { code: "04", label: "Servicios Técnicos", value: "Servicios Técnicos" },
  { code: "05", label: "Ventas", value: "Ventas" },
];

const STATUS_OPTIONS: CodeDescOption[] = [
  { code: "01", label: "Pendiente", value: "Pendiente" },
  { code: "02", label: "Emitida", value: "Emitida" },
  { code: "03", label: "Parcial", value: "Parcial" },
  { code: "04", label: "Cerrada", value: "Cerrada" },
  { code: "05", label: "Anulada", value: "Anulada" },
];

const COLUMNS = ["Código", "Fecha", "Solicitante", "Proveedor", "Mon.", "Total", "Estado", "Solic."];

function formatDate(value: string) {
  if (!value) return "";
  const [year, month, day] = value.split("-");
  return year && month && day ? `${day}/${month}/${year}` : value;
}

export function OrdenCompraList() {
  const currentYear = String(new Date().getFullYear());
  const [rows] = useState<OrdenCompraRow[]>([]);
  const [year, setYear] = useState(currentYear);
  const [area, setArea] = useState("");
  const [supplier, setSupplier] = useState("");
  const [number, setNumber] = useState("");
  const [status, setStatus] = useState("");
  const [appliedFilters, setAppliedFilters] = useState({
    year: currentYear,
    area: "",
    supplier: "",
    number: "",
    status: "",
  });
  const [selectedCode, setSelectedCode] = useState("");

  const visibleRows = useMemo(() => rows.filter((row) => {
    if (appliedFilters.year && !row.fecha.startsWith(`${appliedFilters.year}-`)) return false;
    if (appliedFilters.area && row.area !== appliedFilters.area) return false;
    if (appliedFilters.supplier && !row.proveedor.toLowerCase().includes(appliedFilters.supplier)) return false;
    if (appliedFilters.number && !row.codigo.toLowerCase().includes(appliedFilters.number)) return false;
    if (appliedFilters.status && row.estado !== appliedFilters.status) return false;
    return true;
  }), [rows, appliedFilters]);

  const search = () => {
    setAppliedFilters({
      year,
      area,
      supplier: supplier.trim().toLowerCase(),
      number: number.trim().toLowerCase(),
      status,
    });
  };

  const requireSelection = (action: string) => {
    if (!selectedCode) {
      toast.info(`Seleccione una orden de compra para ${action}.`);
      return false;
    }
    return true;
  };

  const notConnected = (action: string) => {
    toast.info(`${action} requiere conexión al servicio de órdenes de compra.`);
  };

  const refresh = () => {
    setYear(currentYear);
    setArea("");
    setSupplier("");
    setNumber("");
    setStatus("");
    setAppliedFilters({
      year: currentYear,
      area: "",
      supplier: "",
      number: "",
      status: "",
    });
    setSelectedCode("");
  };

  return (
    <div className="relative flex h-full min-h-0 flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex shrink-0 items-center gap-1 overflow-x-auto border-b border-slate-400/50 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] px-2 py-1.5">
        <button type="button" className={iconBtn} title="Imprimir" onClick={() => notConnected("Imprimir")}>
          <Printer className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Nueva orden" onClick={() => notConnected("Crear una nueva orden")}>
          <FileText className="h-4 w-4" />
        </button>
        {tbSep}
        <button
          type="button"
          className={iconBtn}
          title="Mostrar"
          onClick={() => requireSelection("mostrar") && notConnected("Mostrar la orden")}
        >
          <Eye className="h-4 w-4" />
        </button>
        {tbSep}
        <button
          type="button"
          className={iconBtn}
          title="Eliminar"
          onClick={() => requireSelection("eliminar") && notConnected("Eliminar la orden")}
        >
          <Trash2 className="h-4 w-4" />
        </button>
        {tbSep}
        <button
          type="button"
          className={iconBtn}
          title="Enviar al proveedor"
          onClick={() => requireSelection("enviar") && notConnected("Enviar al proveedor")}
        >
          <Mail className="h-4 w-4" />
        </button>
        {tbSep}
        <button
          type="button"
          className={iconBtn}
          title="Aprobar"
          onClick={() => requireSelection("aprobar") && notConnected("Aprobar la orden")}
        >
          <Check className="h-4 w-4" />
        </button>
        {tbSep}
        <button
          type="button"
          className={iconBtn}
          title="Anular"
          onClick={() => requireSelection("anular") && notConnected("Anular la orden")}
        >
          <Ban className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Generar solicitud de gasto" onClick={() => notConnected("Generar solicitud de gasto")}>
          <ClipboardCheck className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Generar masivo" onClick={() => notConnected("Generar órdenes masivas")}>
          <Pencil className="h-4 w-4" />
        </button>
        {tbSep}
        <button
          type="button"
          className={iconBtn}
          title="Facturación"
          onClick={() => requireSelection("consultar facturación") && notConnected("Consultar facturación")}
        >
          <Settings className="h-4 w-4" />
        </button>
        {tbSep}
        <button
          type="button"
          className={iconBtn}
          title="Archivos"
          onClick={() => requireSelection("consultar archivos") && notConnected("Consultar archivos")}
        >
          <Archive className="h-4 w-4" />
        </button>
        {tbSep}
        <button
          type="button"
          className={iconBtn}
          title="Ver estados"
          onClick={() => requireSelection("ver estados") && notConnected("Consultar estados")}
        >
          <Search className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Estados de solicitud de compra" onClick={() => notConnected("Consultar estados de solicitud")}>
          <Search className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Asignar a gasto manual" onClick={() => notConnected("Asignar a gasto manual")}>
          <Settings className="h-4 w-4" />
        </button>
        {tbSep}
        <button
          type="button"
          className={iconBtn}
          title="Actualizar fecha de entrega"
          onClick={() => requireSelection("actualizar fecha de entrega") && notConnected("Actualizar fecha de entrega")}
        >
          <Pencil className="h-4 w-4" />
        </button>
        {tbSep}
        <button
          type="button"
          className={iconBtn}
          title="Bajar de nivel"
          onClick={() => requireSelection("bajar de nivel") && notConnected("Bajar de nivel")}
        >
          <Pencil className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Actualizar" onClick={refresh}>
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
          <label className="flex w-[78px] flex-col gap-0.5">
            <span className="text-center text-[10.5px] font-semibold text-slate-800">Año</span>
            <YearSpinner value={year} onChange={setYear} />
          </label>

          <label className="flex w-[140px] flex-col gap-0.5">
            <span className="text-center text-[10.5px] font-semibold text-slate-800">Área</span>
            <CodeDescSelector value={area} onChange={setArea} options={AREA_OPTIONS} allLabel="(Todos)" width="w-[280px]" />
          </label>

          <div className="flex w-[210px] flex-col gap-0.5">
            <label htmlFor="orden-compra-proveedor" className="text-center text-[10.5px] font-semibold text-slate-800">
              Proveedor
            </label>
            <div className="flex items-center gap-1">
              <input
                id="orden-compra-proveedor"
                className={inp}
                value={supplier}
                placeholder="(Todos)"
                onChange={(event) => setSupplier(event.target.value)}
                onKeyDown={(event) => {
                  if (event.key === "Enter") search();
                }}
              />
              <button
                type="button"
                className={iconBtn}
                title="Buscar proveedor"
                onClick={() => toast.info("La búsqueda de proveedores requiere conectar el servicio de proveedores.")}
              >
                <Search className="h-3.5 w-3.5" />
              </button>
              <button
                type="button"
                className={iconBtn}
                title="Limpiar proveedor"
                onClick={() => setSupplier("")}
              >
                <Ban className="h-3.5 w-3.5" />
              </button>
            </div>
          </div>

          <label className="flex w-[80px] flex-col gap-0.5">
            <span className="text-center text-[10.5px] font-semibold text-slate-800">Número</span>
            <input
              className={`${inp} text-center`}
              value={number}
              onChange={(event) => setNumber(event.target.value)}
              onKeyDown={(event) => {
                if (event.key === "Enter") search();
              }}
            />
          </label>

          <label className="flex w-[120px] flex-col gap-0.5">
            <span className="text-center text-[10.5px] font-semibold text-slate-800">Estado</span>
            <CodeDescSelector value={status} onChange={setStatus} options={STATUS_OPTIONS} allLabel="(Todos)" width="w-[180px]" />
          </label>

          <button type="button" className={btnPrimary} onClick={search}>
            <Search className="h-3.5 w-3.5" />
            Buscar
          </button>
        </div>
      </fieldset>

      <div className="min-h-0 flex-1 overflow-auto p-1.5">
        <div className="h-full overflow-auto rounded-sm border border-slate-400/60 bg-white">
          <SortableTable className="w-full min-w-[900px] border-collapse text-[11px]">
            <colgroup>
              <col className="w-[3%]" />
              <col className="w-[10%]" />
              <col className="w-[10%]" />
              <col className="w-[19%]" />
              <col className="w-[19%]" />
              <col className="w-[7%]" />
              <col className="w-[10%]" />
              <col className="w-[13%]" />
              <col className="w-[9%]" />
            </colgroup>
            <thead className="sticky top-0 z-10 bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800">
              <tr>
                <th className="border border-slate-300/80 px-1 py-1" />
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
                  key={row.codigo}
                  className={`cursor-pointer ${row.codigo === selectedCode ? "bg-[#DCE8F7] font-semibold text-[#1F3E68]" : index % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]"}`}
                  onClick={() => setSelectedCode(row.codigo)}
                >
                  <td className="h-[20px] border border-slate-200 px-1 text-center">{row.codigo === selectedCode ? "▶" : ""}</td>
                  <td className="h-[20px] border border-slate-200 px-2 font-mono">{row.codigo}</td>
                  <td className="h-[20px] border border-slate-200 px-2 text-center">{formatDate(row.fecha)}</td>
                  <td className="h-[20px] border border-slate-200 px-2">{row.solicitante}</td>
                  <td className="h-[20px] border border-slate-200 px-2">{row.proveedor}</td>
                  <td className="h-[20px] border border-slate-200 px-2 text-center">{row.moneda}</td>
                  <td className="h-[20px] border border-slate-200 px-2 text-right">{row.total}</td>
                  <td className="h-[20px] border border-slate-200 px-2 text-center">{row.estado}</td>
                  <td className="h-[20px] border border-slate-200 px-2 text-center">{row.solicitud}</td>
                </tr>
              ))}
            </tbody>
          </SortableTable>
        </div>
      </div>

      <div className="flex shrink-0 items-center justify-center border-t border-slate-400/50 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-0.5 text-[11px] font-medium text-slate-700">
        Registros : {visibleRows.length}
      </div>
    </div>
  );
}

export function OrdenCompraCompras({ title = "Orden Compra Compras" }: { title?: string }) {
  return <OrdenCompraComprasList title={title} />;
}

export function OrdenCompraComprasList({ title = "Orden Compra Compras " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
