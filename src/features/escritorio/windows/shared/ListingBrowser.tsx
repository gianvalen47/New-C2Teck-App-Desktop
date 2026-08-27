import React, { type ReactNode } from "react";
import {
  WindowShell,
  SearchBar,
  Field,
  DataTable,
  inp,
  btn,
  iconBtn,
} from "@/components/ui/desktop-primitives";
import { Search } from "lucide-react";

export type ListingBrowserProps = {
  toolbar2: ReactNode;
  filters?: "full" | "compact" | ReactNode;
  columns: string[];
  rows?: number;
  extraTop?: ReactNode;
  title?: string;
};

export default function ListingBrowser({
  toolbar2,
  filters,
  columns,
  rows = 0,
  extraTop,
  title = "Factura de Venta",
}: ListingBrowserProps) {
  const fullFilters = (
    <SearchBar>
      <Field label="Año" className="w-14">
        <input className={`${inp} font-mono`} defaultValue="2026" />
      </Field>
      <Field label="Mes" className="w-20">
        <select className={inp} defaultValue="JULIO">
          <option>ENERO</option>
          <option>FEBRERO</option>
          <option>MARZO</option>
          <option>ABRIL</option>
          <option>MAYO</option>
          <option>JUNIO</option>
          <option>JULIO</option>
          <option>AGOSTO</option>
          <option>SETIEMBRE</option>
          <option>OCTUBRE</option>
          <option>NOVIEMBRE</option>
          <option>DICIEMBRE</option>
        </select>
      </Field>
      <Field label="Oficina" className="w-24">
        <select className={inp}>
          <option>LIMA</option>
          <option>AREQUIPA</option>
          <option>TRUJILLO</option>
        </select>
      </Field>
      <Field label="Almacén" className="w-28">
        <select className={inp}>
          <option>COMERCIAL</option>
          <option>REPUESTOS</option>
          <option>IMPORTACIÓN</option>
        </select>
      </Field>
      <Field label="Cliente" className="w-56">
        <div className="flex gap-1">
          <input className={`${inp} flex-1`} defaultValue="(Todos)" />
          <button className={iconBtn} title="Buscar">
            <Search className="h-3.5 w-3.5" />
          </button>
        </div>
      </Field>
      <Field label="Estado" className="w-24">
        <select className={inp}>
          <option>(Todos)</option>
          <option>ACEPTADO</option>
          <option>PENDIENTE</option>
          <option>RECHAZADO</option>
        </select>
      </Field>
      <Field label="Número" className="w-20">
        <input className={`${inp} font-mono`} />
      </Field>
      <button className={`${btn} h-[28px]`}>
        <Search className="h-3.5 w-3.5" />Buscar
      </button>
    </SearchBar>
  );

  return (
    <WindowShell title={title} toolbar={toolbar2}>
      <div className="h-full min-h-0 flex flex-col">
        {extraTop}
        {filters === "full" || filters === undefined ? (
          fullFilters
        ) : filters === "compact" ? null : (
          <div className="mx-1.5 mt-1.5">{filters}</div>
        )}
        <div className="p-1.5 flex-1 min-h-0">
          <DataTable columns={columns} rows={rows} className="h-full overflow-auto" />
        </div>
      </div>
    </WindowShell>
  );
}
