import React, { type ReactNode } from "react";
import { WindowShell, Fs, Field, inp, btn, btnPrimary, SearchBar } from "@/components/ui/desktop-primitives";
import { Search } from "lucide-react";

type Props = {
  label: string;
  title?: string;
  children?: ReactNode;
};

export function GenericReportDialog({ label, title, children }: Props) {
  const t = title ?? `Reporte — ${label}`;
  return (
    <WindowShell title={t} toolbar={null}>
      <div className="p-3 max-w-4xl mx-auto">
        <Fs legend="Filtros">
          <SearchBar>
            <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-08-01" /></Field>
            <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-08-31" /></Field>
            <Field label="Criterio" className="w-64"><input className={inp} /></Field>
            <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
          </SearchBar>
        </Fs>
        <div className="mt-3">
          {children}
        </div>
        <div className="mt-4 flex justify-end gap-2">
          <button className={btn}>Cerrar</button>
          <button className={btnPrimary}>Generar</button>
        </div>
      </div>
    </WindowShell>
  );
}
