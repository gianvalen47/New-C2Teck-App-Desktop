import { useEffect, useMemo, useState } from "react";
import { Check, Search, X } from "lucide-react";
import { fetchSession, type EmpresaAsignada, cambiarEmpresa } from "@/lib/sigecoom-api";
import { useSession } from "@/context/SessionContext";
import { toast } from "sonner";

export type Company = {
  codigo: string;
  nombre: string;
  ruc?: string | null;
  descripcion?: string | null;
};

export function CompanyPickerModal({
  current,
  onCancel,
  onAccept,
}: {
  current: Company | null;
  onCancel: () => void;
  onAccept: (c: Company) => void;
}) {
  const [query, setQuery] = useState("");
  const [selected, setSelected] = useState<Company | null>(current ?? null);
  const [companies, setCompanies] = useState<Company[]>([]);
  const [loading, setLoading] = useState(true);
  const sessionCtx = useSession();

  useEffect(() => {
    let mounted = true;

    fetchSession()
      .then((session) => {
        if (!mounted) return;

        const normalized: Company[] = (session.empresas ?? []).map((empresa: EmpresaAsignada) => ({
          codigo: empresa.codigo || "",
          nombre: empresa.nombre || empresa.descripcion || "",
          ruc: empresa.ruc ?? null,
          descripcion: empresa.descripcion ?? null,
        }));

        setCompanies(normalized);
        const active = normalized.find((item) => item.codigo === session.empresa_actual?.codigo) ?? normalized[0] ?? null;
        setSelected(active);
      })
      .catch(() => {
        if (!mounted) return;
        setCompanies([]);
        setSelected(null);
      })
      .finally(() => {
        if (mounted) setLoading(false);
      });

    const onSessionUpdated = (ev: Event) => {
      try {
        const custom = ev as CustomEvent | undefined;
        const sess = custom && custom.detail ? custom.detail as any : null;
        const normalized: Company[] = ((sess?.empresas ?? sess?.empresas) || []).map((empresa: EmpresaAsignada) => ({
          codigo: empresa.codigo || "",
          nombre: empresa.nombre || empresa.descripcion || "",
          ruc: empresa.ruc ?? null,
          descripcion: empresa.descripcion ?? null,
        }));
        if (mounted && Array.isArray(normalized) && normalized.length > 0) {
          setCompanies(normalized);
          const active = normalized.find((item) => item.codigo === (sess?.empresa_actual?.codigo)) ?? normalized[0] ?? null;
          setSelected(active);
        } else {
          // fallback: re-fetch
          fetchSession().then((session) => {
            if (!mounted) return;
            const normalized2: Company[] = (session.empresas ?? []).map((empresa: EmpresaAsignada) => ({
              codigo: empresa.codigo || "",
              nombre: empresa.nombre || empresa.descripcion || "",
              ruc: empresa.ruc ?? null,
              descripcion: empresa.descripcion ?? null,
            }));
            setCompanies(normalized2);
            const active2 = normalized2.find((item) => item.codigo === session.empresa_actual?.codigo) ?? normalized2[0] ?? null;
            setSelected(active2);
          }).catch(() => {});
        }
      } catch (_) {}
    };
    window.addEventListener('systeck-session-updated', onSessionUpdated as EventListener);
    return () => {
      mounted = false;
      window.removeEventListener('systeck-session-updated', onSessionUpdated as EventListener);
    };
  }, []);

  const filtered = useMemo(() => {
    const term = query.trim().toLowerCase();
    if (!term) return companies;

    return companies.filter((item) => {
      const a = item.codigo.toLowerCase();
      const b = (item.nombre || "").toLowerCase();
      const c = (item.ruc || "").toLowerCase();
      const d = (item.descripcion || "").toLowerCase();
      return a.includes(term) || b.includes(term) || c.includes(term) || d.includes(term);
    });
  }, [companies, query]);

  useEffect(() => {
    const onKey = (event: KeyboardEvent) => {
      if (event.key === "Escape") onCancel();
      if (event.key === "Enter" && selected && (event.target as HTMLElement)?.tagName !== "INPUT") {
        event.preventDefault();
        onAccept(selected);
      }
      if ((event.key === "ArrowDown" || event.key === "ArrowUp") && filtered.length > 0 && selected) {
        const currentIndex = filtered.findIndex((item) => item.codigo === selected.codigo);
        const nextIndex = event.key === "ArrowDown"
          ? Math.min(currentIndex + 1, filtered.length - 1)
          : Math.max(currentIndex - 1, 0);
        const next = filtered[nextIndex];
        if (next) setSelected(next);
      }
    };

    window.addEventListener("keydown", onKey);
    return () => window.removeEventListener("keydown", onKey);
  }, [filtered, selected, onAccept, onCancel]);

  return (
    <div className="fixed inset-0 z-[9998] bg-slate-950/40 backdrop-blur-sm grid place-items-center p-4">
      <div className="w-[420px] max-w-full rounded-md border border-slate-300 bg-white shadow-2xl overflow-hidden">
        <div className="flex items-center justify-end border-b border-slate-200 bg-slate-50 px-2 py-1.5">
          <button
            type="button"
            onClick={onCancel}
            className="inline-flex h-7 w-7 items-center justify-center rounded hover:bg-slate-200"
            aria-label="Cerrar"
          >
            <X className="h-3.5 w-3.5 text-slate-600" />
          </button>
        </div>

        <div className="relative border-b border-slate-200 px-3 py-2">
          <Search className="absolute left-5 top-1/2 h-3.5 w-3.5 -translate-y-1/2 text-slate-400" />
          <input
            autoFocus
            value={query}
            onChange={(event) => setQuery(event.target.value)}
            placeholder="Buscar"
            className="h-8 w-full rounded border border-slate-300 bg-slate-50 pl-8 pr-2 text-[12px] text-slate-800 outline-none focus:border-slate-400"
          />
        </div>

        {!loading && filtered.length === 0 ? null : (
          <div className="max-h-[52vh] overflow-auto bg-white">
            {filtered.map((item) => {
              const active = selected?.codigo === item.codigo;
              return (
                <button
                  key={item.codigo || `${item.nombre}-${item.ruc || "sin-ruc"}`}
                  type="button"
                  onClick={() => setSelected(item)}
                  className={`flex w-full items-start gap-3 border-b border-slate-100 px-3 py-2 text-left transition ${active ? "bg-slate-100" : "hover:bg-slate-50"}`}
                >
                  <div className="min-w-0 flex-1">
                    <div className="text-[11px] font-semibold text-slate-700 font-mono">{item.codigo}</div>
                    <div className="text-[12px] text-slate-800 truncate">{item.nombre}</div>
                    {item.ruc ? <div className="text-[10px] text-slate-500 font-mono">{item.ruc}</div> : null}
                    {item.descripcion ? <div className="text-[10px] text-slate-500 truncate">{item.descripcion}</div> : null}
                  </div>
                  {active ? <span className="mt-1 inline-flex h-4 w-4 items-center justify-center rounded-full bg-slate-700 text-white"><Check className="h-2.5 w-2.5" /></span> : null}
                </button>
              );
            })}
          </div>
        )}

        <div className="flex items-center justify-end gap-2 border-t border-slate-200 bg-slate-50 px-3 py-2">
          <button
            type="button"
            onClick={onCancel}
            className="inline-flex h-8 w-8 items-center justify-center rounded border border-slate-300 bg-white text-slate-700 hover:bg-slate-100"
            aria-label="Cancelar"
          >
            <X className="h-3.5 w-3.5" />
          </button>
          <button
            type="button"
            disabled={!selected}
            onClick={() => selected && onAccept(selected)}
            className="inline-flex h-8 w-8 items-center justify-center rounded border border-emerald-700 bg-emerald-600 text-white disabled:cursor-not-allowed disabled:opacity-40 hover:bg-emerald-500"
            aria-label="Aceptar"
          >
            <Check className="h-3.5 w-3.5" />
          </button>
        </div>
      </div>
    </div>
  );
}

export function CambiarEmpresaList() {
  const [selected, setSelected] = useState<Company | null>(null);
  const [isOpen, setIsOpen] = useState(true);

  if (!isOpen) return null;

  return (
    <CompanyPickerModal
      current={selected}
      onCancel={() => setIsOpen(false)}
      onAccept={async (company) => {
        setSelected(company);
        try {
          // Prefer context-based change to ensure UI updates across app
          if (sessionCtx && sessionCtx.changeCompany) {
            await sessionCtx.changeCompany(company.codigo);
            toast.success(`Empresa ${company.codigo} seleccionada`);
            setIsOpen(false);
            return;
          }
        } catch (err) {
          // fallback: call API directly
          try {
            await cambiarEmpresa(company.codigo);
            toast.success(`Empresa ${company.codigo} seleccionada`);
            setIsOpen(false);
          } catch (e) {
            console.error('cambiarEmpresa failed', e);
            toast.error('No se pudo cambiar la empresa. Verifique permisos o conexión.');
          }
        }
      }}
    />
  );
}

export default CambiarEmpresaList;
