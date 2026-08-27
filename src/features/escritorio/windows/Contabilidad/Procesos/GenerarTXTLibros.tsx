// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { FileDown } from "lucide-react";
import {
  inp,
  btnPrimary,
  Field,
  DataTable,
  WindowShell
} from "@/components/ui/desktop-primitives";

export function GenerarTXTList() {
  return (
    <WindowShell title="Generar TXT — Libros Electrónicos SUNAT"
      toolbar={<>
        <button className={btnPrimary}><FileDown className="h-3.5 w-3.5" />Generar archivo .TXT</button>
      </>}>
      <div className="grid grid-cols-3 gap-3">
        <Field label="Libro"><select className={inp}><option>Registro de Ventas</option><option>Registro de Compras</option><option>Libro Diario</option><option>Libro Mayor</option></select></Field>
        <Field label="Periodo"><input className={inp} type="month" /></Field>
        <Field label="Formato"><select className={inp}><option>PLE 5.2</option><option>PLE 5.3</option></select></Field>
      </div>
      <div className="mt-3 text-[11px] text-slate-600">Estructura del archivo se validará automáticamente contra el esquema oficial antes de la descarga.</div>
      <div className="mt-3"><DataTable columns={["Archivo", "Registros", "Tamaño", "Estado", "Fecha generación"]} rows={4} /></div>
    </WindowShell>
  );
}
