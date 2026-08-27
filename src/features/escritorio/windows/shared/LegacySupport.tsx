// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
// Utilidades y componentes genéricos reutilizados por múltiples ventanas legacy.
import { type ReactNode } from "react";
import { Save, Search, Plus, Trash2, FileSpreadsheet } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  iconBtn,
  Field,
  DataTable,
  WindowShell,
  SearchBar
} from "@/components/ui/desktop-primitives";
import { Factura } from "@/features/escritorio/windows/Ventas/Documentos/Facturas";

export function downloadBlob(blob: Blob, filename: string) {
  const url = URL.createObjectURL(blob);
  const link = document.createElement("a");
  link.href = url;
  link.download = filename;
  document.body.appendChild(link);
  link.click();
  link.remove();
  URL.revokeObjectURL(url);
}

export function ListingBrowser2({
  toolbar2,
  filters,
  columns,
  rows = 0,
  extraTop,
}: {
  toolbar2: ReactNode;
  filters?: "full" | "compact" | ReactNode;
  columns: string[];
  rows?: number;
  extraTop?: ReactNode;
}) {
  const fullFilters = (
    <SearchBar>
      <Field label="Año" className="w-14"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
      <Field label="Mes" className="w-20"><select className={inp} defaultValue="JULIO"><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
      <Field label="Oficina" className="w-24"><select className={inp}><option>LIMA</option><option>AREQUIPA</option><option>TRUJILLO</option></select></Field>
      <Field label="Almacén" className="w-28"><select className={inp}><option>COMERCIAL</option><option>REPUESTOS</option><option>IMPORTACIÓN</option></select></Field>
      <Field label="Tipo" className="w-28"><select className={inp}><option>Credito</option><option>REPUESTOS</option><option>IMPORTACIÓN</option></select></Field>
      <Field label="Serie" className="w-28"><select className={inp}><option>(Todos)</option><option>REPUESTOS</option><option>IMPORTACIÓN</option></select></Field>
      <Field label="Cliente" className="w-56">
        <div className="flex gap-1">
          <input className={`${inp} flex-1`} defaultValue="(Todos)" />
          <button className={iconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
        </div>
      </Field>
      <Field label="Estado" className="w-24"><select className={inp}><option>(Todos)</option><option>ACEPTADO</option><option>PENDIENTE</option><option>RECHAZADO</option></select></Field>
      <Field label="Número" className="w-20"><input className={`${inp} font-mono`} /></Field>
      <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
    </SearchBar>
  );
  return (
    <WindowShell title="Factura de Venta" toolbar={toolbar2}>
      <div className="h-full min-h-0 flex flex-col">
        {extraTop}
        {filters === "full" || filters === undefined ? fullFilters : filters === "compact" ? null : <div className="mx-1.5 mt-1.5">{filters}</div>}
        <div className="p-1.5 flex-1 min-h-0">
          <DataTable columns={columns} rows={rows} className="h-full overflow-auto" />
        </div>
      </div>
    </WindowShell>
  );
}

export function ListingBrowser3({
  toolbar2,
  filters,
  columns,
  rows = 0,
  extraTop,
}: {
  toolbar2: ReactNode;
  filters?: "full" | "compact" | ReactNode;
  columns: string[];
  rows?: number;
  extraTop?: ReactNode;
}) {
  const fullFilters = (
    <SearchBar>
      <Field label="Año" className="w-14"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
      <Field label="Mes" className="w-20"><select className={inp} defaultValue="JULIO"><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
      <Field label="Oficina" className="w-24"><select className={inp}><option>LIMA</option><option>AREQUIPA</option><option>TRUJILLO</option></select></Field>
      <Field label="Almacén" className="w-28"><select className={inp}><option>COMERCIAL</option><option>REPUESTOS</option><option>IMPORTACIÓN</option></select></Field>
      <Field label="Documento" className="w-28"><select className={inp}><option>Credito</option><option>REPUESTOS</option><option>IMPORTACIÓN</option></select></Field>
      <Field label="Cliente" className="w-56">
        <div className="flex gap-1">
          <input className={`${inp} flex-1`} defaultValue="(Todos)" />
          <button className={iconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
        </div>
      </Field>
      <Field label="Estado" className="w-24"><select className={inp}><option>(Todos)</option><option>ACEPTADO</option><option>PENDIENTE</option><option>RECHAZADO</option></select></Field>
      <Field label="Número" className="w-20"><input className={`${inp} font-mono`} /></Field>
      <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
    </SearchBar>
  );
  return (
    <WindowShell title="Factura de Venta" toolbar={toolbar2}>
      <div className="h-full min-h-0 flex flex-col">
        {extraTop}
        {filters === "full" || filters === undefined ? fullFilters : filters === "compact" ? null : <div className="mx-1.5 mt-1.5">{filters}</div>}
        <div className="p-1.5 flex-1 min-h-0">
          <DataTable columns={columns} rows={rows} className="h-full overflow-auto" />
        </div>
      </div>
    </WindowShell>
  );
}

export function ListingBrowser4({
  toolbar2,
  filters,
  columns,
  rows = 0,
  extraTop,
}: {
  toolbar2: ReactNode;
  filters?: "full" | "compact" | ReactNode;
  columns: string[];
  rows?: number;
  extraTop?: ReactNode;
}) {
  const fullFilters = (
    <SearchBar>
      <Field label="Año" className="w-14"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
      <Field label="Mes" className="w-20"><select className={inp} defaultValue="JULIO"><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
      <Field label="Oficina" className="w-24"><select className={inp}><option>LIMA</option><option>AREQUIPA</option><option>TRUJILLO</option></select></Field>
      <Field label="Almacén" className="w-28"><select className={inp}><option>COMERCIAL</option><option>REPUESTOS</option><option>IMPORTACIÓN</option></select></Field>
      <Field label="Cliente" className="w-56">
        <div className="flex gap-1">
          <input className={`${inp} flex-1`} defaultValue="(Todos)" />
          <button className={iconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
        </div>
      </Field>
      <Field label="Estado" className="w-24"><select className={inp}><option>(Todos)</option><option>ACEPTADO</option><option>PENDIENTE</option><option>RECHAZADO</option></select></Field>
      <Field label="Número" className="w-20"><input className={`${inp} font-mono`} /></Field>
      <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
    </SearchBar>
  );
  return (
    <WindowShell title="Factura de Venta" toolbar={toolbar2}>
      <div className="h-full min-h-0 flex flex-col">
        {extraTop}
        {filters === "full" || filters === undefined ? fullFilters : filters === "compact" ? null : <div className="mx-1.5 mt-1.5">{filters}</div>}
        <div className="p-1.5 flex-1 min-h-0">
          <DataTable columns={columns} rows={rows} className="h-full overflow-auto" />
        </div>
      </div>
    </WindowShell>
  );
}

export function ListingBrowser5({
  toolbar2,
  filters,
  columns,
  rows = 0,
  extraTop,
}: {
  toolbar2: ReactNode;
  filters?: "full" | "compact" | ReactNode;
  columns: string[];
  rows?: number;
  extraTop?: ReactNode;
}) {
  const fullFilters = (
    <SearchBar>
      <Field label="Año" className="w-14"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
      <Field label="Mes" className="w-20"><select className={inp} defaultValue="JULIO"><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
      <Field label="Oficina" className="w-24"><select className={inp}><option>LIMA</option><option>AREQUIPA</option><option>TRUJILLO</option></select></Field>
      <Field label="Almacén" className="w-28"><select className={inp}><option>COMERCIAL</option><option>REPUESTOS</option><option>IMPORTACIÓN</option></select></Field>
      <Field label="Tipo" className="w-28"><select className={inp}><option>Credito</option><option>REPUESTOS</option><option>IMPORTACIÓN</option></select></Field>
      <Field label="Cliente" className="w-56">
        <div className="flex gap-1">
          <input className={`${inp} flex-1`} defaultValue="(Todos)" />
          <button className={iconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
        </div>
      </Field>
      <Field label="Estado" className="w-24"><select className={inp}><option>(Todos)</option><option>ACEPTADO</option><option>PENDIENTE</option><option>RECHAZADO</option></select></Field>
      <Field label="Número" className="w-20"><input className={`${inp} font-mono`} /></Field>
      <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
    </SearchBar>
  );
  return (
    <WindowShell title="Factura de Venta" toolbar={toolbar2}>
      <div className="h-full min-h-0 flex flex-col">
        {extraTop}
        {filters === "full" || filters === undefined ? fullFilters : filters === "compact" ? null : <div className="mx-1.5 mt-1.5">{filters}</div>}
        <div className="p-1.5 flex-1 min-h-0">
          <DataTable columns={columns} rows={rows} className="h-full overflow-auto" />
        </div>
      </div>
    </WindowShell>
  );
}

export function ListingBrowser6({
  toolbar2,
  filters,
  columns,
  rows = 0,
  extraTop,
}: {
  toolbar2: ReactNode;
  filters?: "full" | "compact" | ReactNode;
  columns: string[];
  rows?: number;
  extraTop?: ReactNode;
}) {
  const fullFilters = (
      <div className="flex items-end flex-wrap gap-x-3 gap-y-1 justify-center">
    <SearchBar>
      <Field label="Año" className="w-16"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
      <Field label="Mes" className="w-24"><select className={inp} defaultValue="JULIO"><option>JULIO</option></select></Field>
      <Field label="Cod. Resumen" className="w-44"><input className={inp} /></Field>
      <button className={`${btn} h-[22px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
    </SearchBar>
      </div>
  );
  return (
    <WindowShell title="Factura de Venta" toolbar={toolbar2}>
      <div className="h-full min-h-0 flex flex-col">
        {extraTop}
        {filters === "full" || filters === undefined ? fullFilters : filters === "compact" ? null : <div className="mx-1.5 mt-1.5">{filters}</div>}
        <div className="p-1.5 flex-1 min-h-0">
          <DataTable columns={columns} rows={rows} className="h-full overflow-auto" />
        </div>
      </div>
    </WindowShell>
  );
}

export function FsLegacyList({ legend, children }: { legend: string; children: ReactNode }) {
  return (
    <fieldset className="border border-[#7A96B4] px-2 pb-2 pt-1 bg-[#ECF1F7] rounded-sm">
      <legend className="px-1 text-[10.5px] font-bold text-slate-700">{legend}</legend>
      <div className="mt-2 space-y-2">{children}</div>
    </fieldset>
  );
}

export function RadioLegacyList({ name, label, defaultChecked }: { name: string; label: string; defaultChecked?: boolean }) {
  return (
    <label className="inline-flex items-center gap-1 text-[11.5px] text-slate-800">
      <input type="radio" name={name} defaultChecked={defaultChecked} className="accent-[#2A5590]" />
      {label}
    </label>
  );
}

export function DialogFooterList({ onOk, onCancel }: { onOk: () => void; onCancel: () => void }) {
  return (
    <div className="flex justify-end gap-2 px-3 py-2 border-t border-slate-300 bg-[#F8FAFC]">
      <button className={btn} onClick={onCancel}>Cancelar</button>
      <button className={btnPrimary} onClick={onOk}>Generar</button>
    </div>
  );
}

export function LabRow({ label, children }: { label: string; children: React.ReactNode }) {
  return (
    <div className="flex items-center justify-between gap-2">
      <span className="font-semibold text-slate-700">{label}</span>
      <div className="flex items-center">{children}</div>
    </div>
  );
}

export function LabRowList({ label, children }: { label: string; children: React.ReactNode }) {
  return <LabRow label={label}>{children}</LabRow>;
}

export function ProcesoLoteList({ label, subtitle }: { label: string; subtitle: string }) {
  return (
    <WindowShell title={`Proceso: ${label}`}>
      <div className="text-[12px] text-slate-600 mb-3">{subtitle}</div>
      <div className="grid grid-cols-3 gap-3 mb-4">
        <Field label="Periodo"><input className={inp} type="month" /></Field>
        <Field label="Almacén"><select className={inp}><option>Todos</option><option>Central Lima</option></select></Field>
        <Field label="Método Costeo"><select className={inp}><option>Promedio Ponderado</option><option>PEPS / FIFO</option></select></Field>
      </div>
      <div className="space-y-3">
        <div>
          <div className="flex justify-between text-[11px] text-slate-600 mb-1"><span>Validación de saldos</span><span>0 / 0</span></div>
          <div className="h-2 bg-slate-200 rounded-sm overflow-hidden"><div className="h-full bg-gradient-to-r from-[#4C6E93] to-[#2A3F55] w-0"></div></div>
        </div>
        <div>
          <div className="flex justify-between text-[11px] text-slate-600 mb-1"><span>Recálculo de costos</span><span>0 / 0</span></div>
          <div className="h-2 bg-slate-200 rounded-sm overflow-hidden"><div className="h-full bg-gradient-to-r from-[#4C6E93] to-[#2A3F55] w-0"></div></div>
        </div>
        <div>
          <div className="flex justify-between text-[11px] text-slate-600 mb-1"><span>Cierre y bloqueo del periodo</span><span>0 / 0</span></div>
          <div className="h-2 bg-slate-200 rounded-sm overflow-hidden"><div className="h-full bg-gradient-to-r from-[#4C6E93] to-[#2A3F55] w-0"></div></div>
        </div>
      </div>
      <div className="mt-4 border border-slate-300 rounded-sm bg-slate-950 text-emerald-300 text-[11px] font-mono p-3 h-28 overflow-auto">
        <div>[sistema] Esperando inicio de proceso…</div>
      </div>
    </WindowShell>
  );
}

export function MantenimientoCRUDList({ label, columns }: { label: string; columns: string[] }) {
  return (
    <WindowShell title={"Mantenimiento — " + label}
      toolbar={<>
        <button className={btnPrimary}><Plus className="h-3.5 w-3.5" />Nuevo</button>
        <button className={btn}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Trash2 className="h-3.5 w-3.5" />Eliminar</button>
        <button className={btn}><Search className="h-3.5 w-3.5" />Buscar</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
        <span className="ml-auto text-[11px] text-slate-500">Registros: <b>—</b></span>
      </>}>
      <div className="grid grid-cols-4 gap-3 mb-3">
        <Field label="Código"><input className={inp} /></Field>
        <Field label={label} className="col-span-2"><input className={inp} placeholder={"Descripción de " + label} /></Field>
        <Field label="Estado"><select className={inp}><option>Activo</option><option>Inactivo</option></select></Field>
      </div>
      <DataTable columns={columns} rows={10} />
    </WindowShell>
  );
}

export function ConfigTablaList({ title, columns }: { title: string; columns: string[] }) {
  return (
    <WindowShell title={title + " — Configuración Avanzada"}
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Nuevo</button>
      </>}>
      <DataTable columns={columns} rows={8} />
    </WindowShell>
  );
}
