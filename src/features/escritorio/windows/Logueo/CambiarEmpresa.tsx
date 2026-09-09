import { useEffect, useMemo, useState } from "react";
import { AlertTriangle, Building2, CheckCircle2, Search, X } from "lucide-react";
import { fetchSession, type EmpresaAsignada } from "@/lib/sigecoom-api";

export type Company = {
  codigo: string;
  ruc: string;
  razonSocial: string;
  alias: string;
  moneda: "PEN" | "USD";
  sucursales: number;
  usuarios: number;
  estado: "Activa" | "Suspendida" | "Auditoría";
  ultimoAcceso: string;
  ejercicio: string;
  ambiente: "Producción" | "Certificación";
  color: string;
};

export const COMPANIES: Company[] = [
  { codigo: "08", ruc: "20512345678", razonSocial: "C2TECK S.A.C.", alias: "Matriz Lima", moneda: "PEN", sucursales: 6, usuarios: 128, estado: "Activa", ultimoAcceso: "20/07/2026 09:14", ejercicio: "2026", ambiente: "Producción", color: "#3E5B7A" },
  { codigo: "12", ruc: "20487654321", razonSocial: "MINERA ANDINOS DEL SUR S.A.", alias: "Unidad Arequipa", moneda: "USD", sucursales: 3, usuarios: 74, estado: "Activa", ultimoAcceso: "19/07/2026 22:08", ejercicio: "2026", ambiente: "Producción", color: "#A16207" },
  { codigo: "15", ruc: "20601239987", razonSocial: "INDUSTRIAS METALMEC S.A.C.", alias: "Planta Callao", moneda: "PEN", sucursales: 2, usuarios: 41, estado: "Activa", ultimoAcceso: "18/07/2026 17:42", ejercicio: "2026", ambiente: "Producción", color: "#0F766E" },
  { codigo: "21", ruc: "20554488990", razonSocial: "LOGÍSTICA PACÍFICO SUR E.I.R.L.", alias: "Aduanas Paita", moneda: "USD", sucursales: 1, usuarios: 12, estado: "Auditoría", ultimoAcceso: "17/07/2026 11:03", ejercicio: "2026", ambiente: "Certificación", color: "#9333EA" },
  { codigo: "27", ruc: "20509988776", razonSocial: "AGROEXPORT VALLE VERDE S.A.C.", alias: "Fundo Ica", moneda: "PEN", sucursales: 4, usuarios: 33, estado: "Activa", ultimoAcceso: "15/07/2026 08:22", ejercicio: "2026", ambiente: "Producción", color: "#15803D" },
  { codigo: "33", ruc: "20144477880", razonSocial: "SERVICIOS CORPORATIVOS DELTA S.A.", alias: "Sucursal Miraflores", moneda: "PEN", sucursales: 2, usuarios: 19, estado: "Suspendida", ultimoAcceso: "02/06/2026 14:51", ejercicio: "2025", ambiente: "Certificación", color: "#B91C1C" },
];

export function CompanyPickerModal({ current, onCancel, onAccept }: { current: Company; onCancel: () => void; onAccept: (c: Company) => void }) {
  const [query, setQuery] = useState("");
  const [selected, setSelected] = useState<Company>(current);
  const [ambiente, setAmbiente] = useState<"Todos" | "Producción" | "Certificación">("Todos");
  const [soloActivas, setSoloActivas] = useState(true);
  const [sessionCompanies, setSessionCompanies] = useState<Company[]>([]);
  const [loading, setLoading] = useState(true);

  const normalizeEmpresa = (empresa: EmpresaAsignada, index: number): Company => {
    const now = new Date();
    const colorPalette = ["#3E5B7A", "#A16207", "#0F766E", "#9333EA", "#15803D", "#B91C1C", "#2563EB", "#7C3AED"];
    return {
      codigo: empresa.codigo || `EMP-${index + 1}`,
      ruc: empresa.ruc || "00000000000",
      razonSocial: empresa.nombre || `Empresa ${empresa.codigo || index + 1}`,
      alias: empresa.descripcion || `Empresa asignada ${index + 1}`,
      moneda: "PEN",
      sucursales: 1,
      usuarios: 1,
      estado: "Activa",
      ultimoAcceso: now.toLocaleString("es-PE", { day: "2-digit", month: "2-digit", year: "numeric", hour: "2-digit", minute: "2-digit" }).replace(",", ""),
      ejercicio: String(now.getFullYear()),
      ambiente: "Producción",
      color: colorPalette[index % colorPalette.length],
    };
  };

  useEffect(() => {
    let mounted = true;
    fetchSession()
      .then((session) => {
        if (!mounted) return;
        const empresas = (session.empresas ?? []).map(normalizeEmpresa);
        if (empresas.length) {
          const actual = empresas.find((item) => item.codigo === session.empresa_actual?.codigo) ?? empresas[0];
          setSessionCompanies(empresas);
          setSelected(actual);
        } else {
          setSessionCompanies(COMPANIES);
        }
      })
      .catch(() => {
        if (!mounted) return;
        setSessionCompanies(COMPANIES);
      })
      .finally(() => {
        if (mounted) setLoading(false);
      });

    return () => { mounted = false; };
  }, []);

  const companies = useMemo(() => (sessionCompanies.length ? sessionCompanies : COMPANIES), [sessionCompanies]);

  const filtered = companies.filter(c => {
    if (soloActivas && c.estado === "Suspendida") return false;
    if (ambiente !== "Todos" && c.ambiente !== ambiente) return false;
    if (!query.trim()) return true;
    const q = query.toLowerCase();
    return c.codigo.toLowerCase().includes(q) || c.ruc.toLowerCase().includes(q) || c.razonSocial.toLowerCase().includes(q) || c.alias.toLowerCase().includes(q);
  });

  useEffect(() => {
    const onKey = (e: KeyboardEvent) => {
      if (e.key === "Escape") onCancel();
      if (e.key === "Enter" && (e.target as HTMLElement)?.tagName !== "INPUT") { e.preventDefault(); onAccept(selected); }
      if (e.key === "ArrowDown" || e.key === "ArrowUp") {
        const idx = filtered.findIndex(c => c.codigo === selected.codigo);
        const next = e.key === "ArrowDown" ? Math.min(idx + 1, filtered.length - 1) : Math.max(idx - 1, 0);
        if (filtered[next]) setSelected(filtered[next]);
      }
    };
    window.addEventListener("keydown", onKey);
    return () => window.removeEventListener("keydown", onKey);
  }, [filtered, selected, onAccept, onCancel]);

  const estadoBadge = (e: Company["estado"]) => {
    const map = {
      "Activa": "bg-emerald-50 text-emerald-700 border-emerald-300",
      "Suspendida": "bg-red-50 text-red-700 border-red-300",
      "Auditoría": "bg-amber-50 text-amber-800 border-amber-300",
    } as const;
    return <span className={`inline-flex items-center gap-1 rounded px-1.5 py-[1px] text-[10px] font-semibold border ${map[e]}`}><span className={`h-1.5 w-1.5 rounded-full ${e === "Activa" ? "bg-emerald-500" : e === "Auditoría" ? "bg-amber-500" : "bg-red-500"}`} />{e}</span>;
  };

  return (
    <div className="fixed inset-0 z-[9998] bg-slate-950/55 backdrop-blur-sm grid place-items-center animate-in fade-in duration-150 text-slate-800">
      <div className="w-[960px] max-w-[97vw] max-h-[90vh] rounded-md overflow-hidden border border-slate-500/70 shadow-2xl bg-[#F1F4F9] text-slate-800 flex flex-col">
        <div className="h-8 bg-gradient-to-b from-[#4A6789] via-[#3A5573] to-[#243B55] flex items-center justify-between px-2 text-white text-xs select-none">
          <div className="flex items-center gap-2">
            <div className="h-5 w-5 rounded-sm bg-white/15 grid place-items-center ring-1 ring-white/10"><Building2 className="h-3 w-3 text-amber-300" /></div>
            <span className="font-semibold tracking-tight">Elija la Empresa Activa — Systeck</span>
            <span className="opacity-70 font-mono ml-2 text-[10px]">/ Multi-Tenant · Aislamiento total de datos</span>
          </div>
          <button onClick={onCancel} className="h-8 w-11 hover:bg-red-600 grid place-items-center transition-colors"><X className="h-3.5 w-3.5" /></button>
        </div>

        <div className="shrink-0 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/40 px-3 py-2 flex flex-wrap items-center gap-2">
          <div className="relative flex-1 min-w-[220px]">
            <Search className="h-3.5 w-3.5 absolute left-2 top-1/2 -translate-y-1/2 text-slate-400" />
            <input
              autoFocus
              value={query}
              onChange={(e) => setQuery(e.target.value)}
              placeholder="Buscar por código, RUC, razón social o alias…"
              className="w-full h-7 pl-7 pr-2 rounded border border-slate-400 bg-white text-[12px] outline-none focus:border-[#3A5573] focus:ring-2 focus:ring-[#3A5573]/25"
            />
          </div>
          <select value={ambiente} onChange={e => setAmbiente(e.target.value as any)} className="h-7 rounded border border-slate-400 bg-white text-[11px] px-2 focus:border-[#3A5573] outline-none">
            <option>Todos</option>
            <option>Producción</option>
            <option>Certificación</option>
          </select>
          <label className="flex items-center gap-1.5 text-[11px] text-slate-700 select-none">
            <input type="checkbox" checked={soloActivas} onChange={e => setSoloActivas(e.target.checked)} className="h-3.5 w-3.5 rounded border-slate-400" />
            Ocultar suspendidas
          </label>
          <div className="ml-auto text-[10.5px] text-slate-600 font-mono flex items-center gap-3">
            <span><b className="text-[#243B55]">{filtered.length}</b> / {companies.length} empresas</span>
            <span className="hidden md:inline">↑↓ navegar · ⏎ aceptar · ESC cancelar</span>
          </div>
        </div>

        <div className="flex-1 min-h-0 grid grid-cols-[1fr_280px]">
          <div className="min-h-0 overflow-auto border-r border-slate-300 bg-white">
            <table className="w-full text-[11.5px]">
              <thead className="sticky top-0 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] text-slate-700 border-b border-slate-400 shadow-sm">
                <tr className="text-left">
                  <th className="w-7 px-2 py-1.5"></th>
                  <th className="px-2 py-1.5 font-semibold">Código</th>
                  <th className="px-2 py-1.5 font-semibold">RUC</th>
                  <th className="px-2 py-1.5 font-semibold">Razón Social</th>
                  <th className="px-2 py-1.5 font-semibold">Alias / Sede</th>
                  <th className="px-2 py-1.5 font-semibold text-center">Suc.</th>
                  <th className="px-2 py-1.5 font-semibold text-center">Usr.</th>
                  <th className="px-2 py-1.5 font-semibold text-center">Mon.</th>
                  <th className="px-2 py-1.5 font-semibold">Estado</th>
                  <th className="px-2 py-1.5 font-semibold">Último Acceso</th>
                </tr>
              </thead>
              <tbody className="font-mono">
                {filtered.map((c, i) => {
                  const isSel = c.codigo === selected.codigo;
                  const isCur = c.codigo === current.codigo;
                  return (
                    <tr
                      key={c.codigo}
                      onClick={() => setSelected(c)}
                      onDoubleClick={() => onAccept(c)}
                      className={`cursor-pointer border-b border-slate-100 transition-colors ${isSel ? "bg-[#3A5573] text-white" : i % 2 ? "bg-slate-50/60 hover:bg-[#DDE7F3]" : "bg-white hover:bg-[#DDE7F3]"}`}
                    >
                      <td className="px-2 py-1.5 text-center">
                        {isSel ? <span className="text-amber-300">▶</span> : isCur ? <span className={isSel ? "text-white" : "text-emerald-600"}>●</span> : ""}
                      </td>
                      <td className="px-2 py-1.5 font-bold">{c.codigo}</td>
                      <td className={`px-2 py-1.5 ${isSel ? "text-amber-200" : "text-slate-600"}`}>{c.ruc}</td>
                      <td className="px-2 py-1.5 font-sans font-semibold">
                        <div className="flex items-center gap-2">
                          <span className="h-2 w-2 rounded-sm shrink-0" style={{ background: c.color }} />
                          {c.razonSocial}
                        </div>
                      </td>
                      <td className={`px-2 py-1.5 font-sans ${isSel ? "text-slate-100" : "text-slate-600"}`}>{c.alias}</td>
                      <td className="px-2 py-1.5 text-center">{c.sucursales}</td>
                      <td className="px-2 py-1.5 text-center">{c.usuarios}</td>
                      <td className="px-2 py-1.5 text-center">
                        <span className={`inline-block rounded px-1 text-[10px] font-bold ${isSel ? "bg-white/20 text-white" : c.moneda === "USD" ? "bg-emerald-100 text-emerald-700" : "bg-slate-200 text-slate-700"}`}>{c.moneda}</span>
                      </td>
                      <td className="px-2 py-1.5 font-sans">{estadoBadge(c.estado)}</td>
                      <td className={`px-2 py-1.5 ${isSel ? "text-slate-100" : "text-slate-500"}`}>{c.ultimoAcceso}</td>
                    </tr>
                  );
                })}
                {filtered.length === 0 && (
                  <tr><td colSpan={10} className="text-center py-8 text-slate-400 font-sans text-[11px]">Sin resultados para "{query}"</td></tr>
                )}
                {Array.from({ length: Math.max(0, 8 - filtered.length) }).map((_, i) => (
                  <tr key={`p-${i}`} className={i % 2 ? "bg-slate-50/40" : "bg-white"}>
                    <td colSpan={10} className="h-6"></td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>

          <div className="min-h-0 overflow-auto bg-gradient-to-b from-[#F8FAFC] to-[#EEF2F7] p-3 flex flex-col gap-3">
            <div className="rounded-md border border-slate-300 bg-white shadow-sm overflow-hidden">
              <div className="h-14 relative" style={{ background: `linear-gradient(135deg, ${selected.color}, #1E2E45)` }}>
                <div className="absolute -bottom-5 left-3 h-10 w-10 rounded-full bg-white grid place-items-center shadow-md ring-2 ring-white text-[13px] font-bold" style={{ color: selected.color }}>
                  {selected.razonSocial.split(" ").slice(0, 2).map(w => w[0]).join("")}
                </div>
              </div>
              <div className="pt-6 px-3 pb-3">
                <div className="text-[12.5px] font-semibold text-slate-800 leading-tight">{selected.razonSocial}</div>
                <div className="text-[10.5px] text-slate-500 font-mono mt-0.5">RUC {selected.ruc} · Cód. {selected.codigo}</div>
                <div className="text-[10.5px] text-slate-500 mt-0.5">{selected.alias}</div>
              </div>
            </div>

            <div className="grid grid-cols-2 gap-2">
              <MiniStat label="Sucursales" value={String(selected.sucursales)} />
              <MiniStat label="Usuarios" value={String(selected.usuarios)} />
              <MiniStat label="Moneda" value={selected.moneda} />
              <MiniStat label="Ejercicio" value={selected.ejercicio} />
            </div>

            <div className="rounded-md border border-slate-300 bg-white p-2.5 text-[11px] space-y-1.5">
              <div className="flex justify-between"><span className="text-slate-500">Ambiente</span><span className={`font-semibold ${selected.ambiente === "Producción" ? "text-emerald-700" : "text-amber-700"}`}>{selected.ambiente}</span></div>
              <div className="flex justify-between"><span className="text-slate-500">Estado</span>{estadoBadge(selected.estado)}</div>
              <div className="flex justify-between"><span className="text-slate-500">Último acceso</span><span className="font-mono text-slate-700 text-[10.5px]">{selected.ultimoAcceso}</span></div>
              <div className="flex justify-between"><span className="text-slate-500">Sesión activa</span><span className="text-slate-700">{current.codigo === selected.codigo ? "Sí" : "No"}</span></div>
            </div>

            <div className="rounded-md border border-amber-300 bg-amber-50 p-2 text-[10.5px] text-amber-900 flex gap-2">
              <AlertTriangle className="h-4 w-4 shrink-0 mt-[1px]" />
              <span>Al conmutar de empresa se cerrarán las ventanas MDI abiertas y se recargará el contexto tributario, correlativos SUNAT y tipo de cambio.</span>
            </div>
          </div>
        </div>

        <div className="shrink-0 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-t border-slate-400/40 px-3 py-2 flex items-center gap-2">
          <div className="text-[10.5px] text-slate-600 font-mono">
            Empresa seleccionada: <b className="text-[#243B55]">{selected.codigo}</b> · <span className="text-slate-700">{selected.razonSocial}</span>
          </div>
          <div className="ml-auto flex items-center gap-2">
            <button onClick={onCancel} className="h-7 px-4 rounded border border-slate-400 bg-white hover:bg-slate-100 text-[11.5px] font-medium text-slate-700 inline-flex items-center gap-1.5 shadow-sm">
              <X className="h-3.5 w-3.5" /> Cancelar
            </button>
            <button
              disabled={selected.estado === "Suspendida"}
              onClick={() => onAccept(selected)}
              className="h-7 px-4 rounded border border-emerald-700 bg-gradient-to-b from-emerald-500 to-emerald-700 hover:brightness-110 text-[11.5px] font-semibold text-white inline-flex items-center gap-1.5 shadow-sm disabled:opacity-50 disabled:cursor-not-allowed"
            >
              <CheckCircle2 className="h-3.5 w-3.5" /> Aceptar
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}

function MiniStat({ label, value }: { label: string; value: string }) {
  return (
    <div className="rounded-md border border-slate-300 bg-white p-2">
      <div className="text-[9.5px] uppercase tracking-wider text-slate-500">{label}</div>
      <div className="text-[15px] font-bold text-[#243B55] font-mono leading-tight">{value}</div>
    </div>
  );
}

export function CambiarEmpresaList() {
  const initial = COMPANIES[0];
  const [selected, setSelected] = useState<Company>(initial);
  const [isOpen, setIsOpen] = useState(true);

  if (!isOpen) return null;

  return (
    <CompanyPickerModal
      current={selected}
      onCancel={() => setIsOpen(false)}
      onAccept={(company) => {
        setSelected(company);
        setIsOpen(false);
      }}
    />
  );
}

export default CambiarEmpresaList;
