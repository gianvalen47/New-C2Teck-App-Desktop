import React, { useState, type ReactNode } from "react";
import {
  FilePlus,
  Save,
  Printer,
  Trash2,
  XCircle,
  Search,
  Plus,
  Pencil,
  CheckCircle,
  PlusCircle,
  FileSpreadsheet,
} from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  iconBtn,
  tbSep,
  Field,
  SearchBar,
  Fs,
  Radio,
  DataTable,
  WindowShell,
} from "@/components/ui/desktop-primitives";

export const newGuideToolbar = (
  <>
    <button type="button" className={iconBtn} title="Nuevo"><Plus className="h-4 w-4" /></button>
    <button type="button" className={iconBtn} title="Guardar"><Save className="h-4 w-4" /></button>
    <button type="button" className={iconBtn} title="Imprimir"><Printer className="h-4 w-4" /></button>
    <button type="button" className={iconBtn} title="Buscar"><Search className="h-4 w-4" /></button>
    <button type="button" className={iconBtn} title="Eliminar"><Trash2 className="h-4 w-4" /></button>
  </>
);


export function NewGuideWindow() {
  const inputWide = `${inp} w-full`;
  const inputNarrow = `${inp} w-full font-mono`;
  const iconMini = "inline-flex items-center justify-center h-7 w-7 rounded-sm border border-slate-400/70 bg-gradient-to-b from-[#FDFEFF] to-[#DCE7F4] hover:from-white hover:to-[#CFDDF0] text-slate-700";

  const InlineField = ({ label, children, className = "", labelWidth = "w-[74px]" }: { label: string; children: ReactNode; className?: string; labelWidth?: string }) => (
    <div className={`flex items-center gap-1 ${className}`}>
      <span className={`${labelWidth} shrink-0 text-right text-[11px] font-semibold text-slate-800`}>{label} :</span>
      <div className="min-w-0 flex-1">{children}</div>
    </div>
  );

  return (
    <WindowShell title="Registrar nueva GUÍA DE REMISIÓN" toolbar={newGuideToolbar}>
      <div className="h-full min-h-0 overflow-auto bg-[#F3F6FA] p-1">
        <div className="mb-0.5 flex items-center justify-center text-[13px] font-bold text-slate-900">
          OFICINA: LIMA - ALMACEN: COMERCIAL
        </div>

        <div className="border border-slate-300 bg-[#F8FBFF] p-1 shadow-sm">
          <div className="min-w-[810px]">
            <div className="grid items-start gap-0.5 xl:grid-cols-[minmax(0,1fr)_168px]">
              <div className="grid gap-0.5">
                <div className="grid gap-0.5 md:grid-cols-[150px_170px_146px_104px_120px]">
                <InlineField label="Número" labelWidth="w-[62px]"><input className={inputNarrow} defaultValue="4" /></InlineField>
                <InlineField label="Fecha" labelWidth="w-[52px]"><input className={inputNarrow} defaultValue="25/07/2026" /></InlineField>
                <InlineField label="Moneda" labelWidth="w-[58px]"><select className={inputWide}><option>USD</option><option>PEN</option></select></InlineField>
                <InlineField label="IGV" labelWidth="w-[36px]"><input className={inputNarrow} defaultValue="18.00" /></InlineField>
                <InlineField label="Tip.Cam." labelWidth="w-[58px]"><input className={inputNarrow} defaultValue="3.411" /></InlineField>
              </div>

              <div className="grid gap-0.5 xl:grid-cols-[minmax(0,1.15fr)_minmax(0,1fr)_240px]">
                <InlineField label="Cliente" labelWidth="w-[62px]">
                  <div className="flex gap-1">
                    <input className={inputWide} defaultValue="" />
                    <button type="button" className={iconMini} title="Buscar Cliente"><Search className="h-3.5 w-3.5" /></button>
                  </div>
                </InlineField>
                <InlineField label="Loc.Cliente" labelWidth="w-[74px]">
                  <div className="flex gap-1">
                    <input className={inputWide} defaultValue="" />
                    <button type="button" className={iconMini} title="Buscar Locación"><Search className="h-3.5 w-3.5" /></button>
                    <button type="button" className={iconMini} title="Editar Locación"><Pencil className="h-3 w-3" /></button>
                  </div>
                </InlineField>
                <InlineField label="Motivo" labelWidth="w-[58px]"><input className={inputWide} defaultValue="Venta" /></InlineField>
              </div>

              <div className="grid gap-0.5 xl:grid-cols-[minmax(0,1.1fr)_minmax(0,1fr)_220px]">
                <InlineField label="Dir. Fiscal" labelWidth="w-[70px]">
                  <div className="flex gap-1">
                    <input className={inputWide} defaultValue="" />
                    <button type="button" className={iconMini} title="Buscar Dirección"><Search className="h-3.5 w-3.5" /></button>
                  </div>
                </InlineField>
                <InlineField label="# OT" labelWidth="w-[42px]">
                  <div className="flex gap-1">
                    <input className={inputWide} defaultValue="" />
                    <button type="button" className={iconMini} title="Buscar OT"><Search className="h-3.5 w-3.5" /></button>
                  </div>
                </InlineField>
                <InlineField label="Cotización" labelWidth="w-[64px]"><input className={inputWide} defaultValue="" /></InlineField>
              </div>

              <div className="grid gap-0.5 xl:grid-cols-[minmax(0,1fr)_minmax(0,1.25fr)]">
                <InlineField label="Llegada" labelWidth="w-[62px]"><input className={inputWide} defaultValue="" /></InlineField>
                <InlineField label="Partida" labelWidth="w-[56px]"><input className={inputWide} defaultValue="CAL. ANTONIO ULLOA NRO. 2182 URB. EL FLORES" /></InlineField>
              </div>

              <div className="grid gap-0.5 xl:grid-cols-[minmax(0,1fr)_180px]">
                <InlineField label="Vendedor" labelWidth="w-[74px]"><input className={inputWide} defaultValue="" /></InlineField>
                <InlineField label="O/C" labelWidth="w-[42px]"><input className={inputWide} defaultValue="" /></InlineField>
              </div>

              <div className="grid gap-0.5 xl:grid-cols-[190px_minmax(0,1fr)_250px]">
                <InlineField label="Peso Total" labelWidth="w-[74px]"><input className={inputNarrow} defaultValue="0.000" /></InlineField>
                <InlineField label="Unid. Medida Peso" labelWidth="w-[120px]"><select className={inputWide}><option>Kilogramos</option><option>Toneladas</option></select></InlineField>
                <InlineField label="Cant. Bultos / Palets" labelWidth="w-[128px]"><input className={inputNarrow} defaultValue="1" /></InlineField>
              </div>

              <div className="grid gap-0.5 xl:grid-cols-[minmax(0,1fr)_260px]">
                <InlineField label="Modo Traslado" labelWidth="w-[92px]"><select className={inputWide}><option>Transporte Privado</option><option>Transporte Público</option></select></InlineField>
                <InlineField label="Fecha Inicio Traslado" labelWidth="w-[130px]"><input className={inputNarrow} defaultValue="25/07/2026" /></InlineField>
              </div>
              </div>

              <div className="self-start border border-slate-300 bg-white p-1">
                <div className="mb-0.5 text-[12px] font-semibold text-slate-800">Costos</div>
                <div className="grid gap-0.5">
                <InlineField label="Flete" labelWidth="w-[48px]"><input className={inputNarrow} defaultValue="0.00" /></InlineField>
                <InlineField label="Embarque" labelWidth="w-[64px]"><input className={inputNarrow} defaultValue="0.00" /></InlineField>
                </div>
              </div>
            </div>
          </div>

          <div className="mt-0.5">
            <InlineField label="Observación" labelWidth="w-[92px]" className="items-start">
              <textarea
                className="min-h-[24px] w-full resize-none rounded-none border border-[#8FA9C8] bg-white px-1.5 py-1 text-[11px] text-slate-900 outline-none focus:border-[#3E5B7A]"
                defaultValue=""
              />
            </InlineField>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}