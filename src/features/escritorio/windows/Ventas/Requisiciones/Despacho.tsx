import React from "react";
import { btn, iconBtn, inp, tbSep } from "@/features/escritorio/windows/uiStyles";
import { Printer, Send, FileSearch, LogOut, Search } from "lucide-react";
import { TicketPrinterIcon } from "@/components/ui/icons";
import { Field, ListQueryForm, SearchBar } from "@/components/ui/desktop-primitives";
import { stdToolbarAlmacen } from "../../shared/toolbarPresets";

const stdToolbar13 = (
  <>
    {/* Grupo principal: Impresión / Envíos / Nuevo */}
    <button className={iconBtn} title="Mostrar los datos del registro seleccionado"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Eliminar Requisicion"><TicketPrinterIcon className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Generar Cierre"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Refrescar"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    {/* Salir / Control */}
    <button className={iconBtn} title="Cerrar la ventana actual"><LogOut className="h-4 w-4" /></button>
  </>
);

export function DespachoList() {
  return (
    <ListQueryForm
      title="Despachos"
      toolbar={stdToolbarAlmacen}
      extraTop={
        <div className="mx-1.5 mt-1.5 grid grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Pendientes:</span> <b className="font-mono text-slate-900">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">En ruta:</span> <b className="font-mono text-slate-900">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Finalizados:</span> <b className="font-mono text-slate-900">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Anulados:</span> <b className="font-mono text-slate-900">0</b></div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Fecha Inicio" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Fecha Fin" className="w-32"><input className={inp} type="date" defaultValue="2026-07-21" /></Field>
          <Field label="Chofer" className="w-56"><input className={inp} defaultValue="(Todos)" /></Field>
          <Field label="Placa" className="w-28"><input className={`${inp} font-mono`} defaultValue="" /></Field>
          <Field label="Estado" className="w-24"><select className={inp}><option>(Todos)</option><option>GENERADO</option><option>EN RUTA</option><option>FINALIZADO</option><option>ANULADO</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Número", "Fecha", "Hora Salida", "Hora Retorno", "Chofer", "Placa", "Destino", "Observación", "Estado"]}
      rows={0}
    />
  );
}