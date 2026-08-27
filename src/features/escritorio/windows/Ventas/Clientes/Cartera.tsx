// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search } from "lucide-react";
import {
  inp,
  btn,
  Field,
  SearchBar,
  ListQueryForm
} from "@/components/ui/desktop-primitives";
import { stdToolbar10 } from "@/features/escritorio/windows/shared/toolbarPresets";

export function CarteraList() {
  return (
    <ListQueryForm
      title="Cartera de Clientes"
      toolbar={stdToolbar10}
      filters={
        <SearchBar>
          <Field label="Código" className="w-28"><input className={`${inp} font-mono`} /></Field>
          <Field label="Cliente" className="w-64"><input className={inp} defaultValue="(Todos)" /></Field>
          <Field label="Grupo" className="w-40"><select className={inp}><option>(Todos)</option><option>MINERÍA</option><option>COMERCIAL</option><option>SERVICIOS</option></select></Field>
          <Field label="Vendedor" className="w-44"><select className={inp}><option>(Todos)</option><option>VENDEDOR 01</option><option>VENDEDOR 02</option></select></Field>
          <Field label="Estado" className="w-28"><select className={inp}><option>ACTIVO</option><option>INACTIVO</option><option>(Todos)</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Código", "RUC", "Razón Social", "Grupo Ventas", "Vendedor", "Cond. Pago", "Límite Crédito", "Estado", "F.Actualización"]}
      rows={0}
    />
  );
}
