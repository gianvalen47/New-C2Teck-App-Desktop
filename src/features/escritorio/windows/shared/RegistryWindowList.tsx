import { Search } from "lucide-react";
import {
  btn,
  Field,
  inp,
  ListQueryForm,
  SearchBar,
} from "@/components/ui/desktop-primitives";

export type RegistryWindowListProps = {
  title: string;
  columns?: string[];
};

export function RegistryWindowList({
  title,
  columns = ["Código", "Descripción", "Fecha", "Estado"],
}: RegistryWindowListProps) {
  return (
    <ListQueryForm
      title={title}
      filters={
        <SearchBar>
          <Field label="Buscar" className="w-56">
            <input className={inp} placeholder="Código o descripción" />
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
