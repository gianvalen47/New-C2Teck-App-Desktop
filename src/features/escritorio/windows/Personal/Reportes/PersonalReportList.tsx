import { Search } from "lucide-react";
import { btn, Field, inp, ListQueryForm, SearchBar } from "@/components/ui/desktop-primitives";

export function PersonalReportList({ title, columns }: { title: string; columns: string[] }) {
  return (
    <ListQueryForm
      title={title}
      filters={
        <SearchBar>
          <Field label="Periodo" className="w-28">
            <input className={inp} type="month" />
          </Field>
          <Field label="Área" className="w-40">
            <input className={inp} placeholder="(Todas)" />
          </Field>
          <Field label="Colaborador" className="w-52">
            <input className={inp} placeholder="(Todos)" />
          </Field>
          <button className={`${btn} h-[28px]`} type="button">
            <Search className="h-3.5 w-3.5" />
            Buscar
          </button>
        </SearchBar>
      }
      columns={columns}
      rows={12}
    />
  );
}
