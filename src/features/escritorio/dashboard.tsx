import { createContext, useContext, useState, useRef, useEffect, useCallback, type ReactNode } from "react";
import { createPortal } from "react-dom";
import { AnimatePresence, motion, useReducedMotion } from "framer-motion";
import { Button } from "@/components/ui/button";
import {
  X, Save, Printer, Search, Plus, Trash2, FileDown, FileSpreadsheet,
  Mail, Send, RefreshCw, Filter, Calendar, DollarSign, User, Package,
  Minus, Square, Copy, Zap, LayoutDashboard, EyeOff,
} from "lucide-react";
import {
  ResponsiveContainer, BarChart, Bar, XAxis, YAxis, CartesianGrid, Tooltip, Legend,
  PieChart, Pie, Cell,
} from "recharts";
import { TrendingUp, TrendingDown, FileText, Wrench, AlertTriangle, Activity, Database, Wifi } from "lucide-react";
import { FloatingWindow } from "@/features/escritorio/windows";
import systeckWallpaper from "@/assets/Background/systeck-wallpaper-hd.png";
import {
  useWindows,
} from "@/context/WindowsContext";

export function Workspace() {
  const { windows, active, focus, move, toggleMaximize, minimize, toggleFromTaskbar, close } = useWindows();
  const [dashboardEnabled, setDashboardEnabled] = useState(true);
  const visibleWindows = windows.filter(w => !w.isMinimized);
  const workspaceRef = useRef<HTMLDivElement | null>(null);
  const reduceMotion = useReducedMotion();

  return (
    <div className="mdi-background-surface relative flex-1 min-h-0 flex flex-col">
      {/* Canvas backdrop — floating windows are portaled to <body> so drag is unlimited */}
      <div ref={workspaceRef} className="relative flex-1 min-h-0">


        {/* Grid backdrop */}
        <svg className={`absolute inset-0 w-full h-full opacity-[0.35] pointer-events-none ${dashboardEnabled ? "" : "hidden"}`} xmlns="http://www.w3.org/2000/svg">
          <defs>
            <pattern id="mdi-grid" width="26" height="26" patternUnits="userSpaceOnUse">
              <path d="M 26 0 L 0 0 0 26" fill="none" stroke="#CBD5E1" strokeWidth="0.5" />
            </pattern>
          </defs>
          <rect width="100%" height="100%" fill="url(#mdi-grid)" />
        </svg>
        <AnimatePresence mode="wait" initial={false}>
          {windows.length === 0 && (
            <motion.div
              key={dashboardEnabled ? "operational-dashboard" : "company-logo"}
              className="absolute inset-0 overflow-hidden"
              initial={{ opacity: 0, scale: reduceMotion ? 1 : 0.975, y: reduceMotion ? 0 : 12, filter: reduceMotion ? "blur(0px)" : "blur(6px)" }}
              animate={{ opacity: 1, scale: 1, y: 0, filter: "blur(0px)" }}
              exit={{ opacity: 0, scale: reduceMotion ? 1 : 1.025, y: reduceMotion ? 0 : -8, filter: reduceMotion ? "blur(0px)" : "blur(6px)" }}
              transition={{ duration: reduceMotion ? 0.08 : 0.32, ease: "easeInOut" }}
            >
              {dashboardEnabled ? (
                <DesktopDashboard onDeactivate={() => setDashboardEnabled(false)} />
              ) : (
                <>
                <motion.div
                  className="absolute inset-0 bg-cover bg-center"
                  role="img"
                  aria-label="Fondo de pantalla de Systeck, Logo de la empresa"
                  style={{ backgroundImage: `url(${systeckWallpaper})` }}
                  initial={reduceMotion ? { opacity: 0 } : { opacity: 0, scale: 1.14, filter: "blur(14px) brightness(1.25)", clipPath: "circle(12% at 50% 50%)" }}
                  animate={reduceMotion ? { opacity: 1 } : { opacity: 1, scale: 1, filter: "blur(0px) brightness(1)", clipPath: "circle(150% at 50% 50%)" }}
                  transition={{ duration: reduceMotion ? 0.08 : 1.1, ease: [0.22, 1, 0.36, 1] }}
                />
                <motion.div className="absolute inset-0 flex flex-col items-end justify-end gap-3 p-6" role="region" aria-label="Logo de la empresa" initial={{ opacity: 0, y: reduceMotion ? 0 : 16 }} animate={{ opacity: 1, y: 0 }} transition={{ delay: reduceMotion ? 0 : 0.7, duration: reduceMotion ? 0.08 : 0.4 }}>
                  <Button variant="outline" size="sm" onClick={() => setDashboardEnabled(true)} aria-label="Activar dashboard operativo" title="Activar dashboard operativo" className="border-slate-300 bg-white/80 text-slate-800 shadow-sm transition-colors hover:bg-white hover:text-slate-900">
                    <LayoutDashboard />
                    Activar dashboard operativo
                  </Button>
                </motion.div>
                </>
              )}
            </motion.div>
          )}
        </AnimatePresence>

        {visibleWindows.map(w => (
          <FloatingWindow
            key={w.id}
            win={w}
            isActive={active === w.id}
            containerRef={workspaceRef}
            onFocus={() => focus(w.id)}
            onClose={() => close(w.id)}
            onMove={(pos) => move(w.id, pos)}
            onToggleMaximize={() => toggleMaximize(w.id)}
            onMinimize={() => minimize(w.id)}
          />
        ))}
      </div>


      {/* Bottom taskbar */}
      <motion.div
        initial={{ opacity: 0, y: 12 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ delay: reduceMotion ? 0 : 0.3, duration: reduceMotion ? 0.08 : 0.28 }}
        className="shrink-0 h-9 bg-gradient-to-b from-[#0a1220] to-[#060911] border-t border-[#00E5FF]/20 flex items-center gap-1 px-2 overflow-x-auto"
      >
        <div className="flex items-center gap-1.5 mr-2 pr-2 border-r border-slate-700/60">
          <span className="h-2 w-2 rounded-full bg-emerald-400 shadow-[0_0_6px_#10B981]" />
          <span className="text-[10px] font-mono text-slate-400 tracking-wider uppercase">Systeck MDI</span>
        </div>
        <Button
          variant="ghost"
          size="icon"
          className="mdi-dashboard-toggle h-7 w-7 shrink-0"
          aria-label={dashboardEnabled ? "Desactivar dashboard operativo" : "Activar dashboard operativo"}
          title={dashboardEnabled ? "Desactivar dashboard operativo" : "Activar dashboard operativo"}
          aria-pressed={dashboardEnabled}
          onClick={() => setDashboardEnabled(enabled => !enabled)}
        >
          {dashboardEnabled ? <EyeOff /> : <LayoutDashboard />}
        </Button>
        {windows.length === 0 && (
          <span className="text-[10.5px] font-mono text-slate-600">— sin ventanas abiertas —</span>
        )}
        {windows.map(w => {
          const isActive = active === w.id && !w.isMinimized;
          return (
            <div key={w.id} className={[
              "group shrink-0 flex items-center h-7 rounded-sm border overflow-hidden transition-colors",
              isActive
                ? "bg-[#00E5FF]/15 border-[#00E5FF]/50 shadow-[inset_0_-2px_0_0_#00E5FF]"
                : w.isMinimized
                  ? "bg-slate-800/60 border-slate-700/50 opacity-70 hover:opacity-100"
                  : "bg-slate-800/40 border-slate-700/60 hover:bg-slate-700/60",
            ].join(" ")}>
              <button
                onClick={() => toggleFromTaskbar(w.id)}
                className="flex items-center gap-1.5 px-2 h-full text-[11px] font-mono text-slate-200 max-w-[180px]"
                title={w.isMinimized ? "Restaurar" : (isActive ? "Minimizar" : "Traer al frente")}
              >
                <span className={`h-1.5 w-1.5 rounded-full ${isActive ? "bg-[#00E5FF]" : w.isMinimized ? "bg-amber-400" : "bg-slate-400"}`} />
                <span className="truncate">{w.label}</span>
                {w.isMinimized && <span className="ml-1 text-[9px] px-1 rounded bg-amber-500/20 text-amber-300 border border-amber-500/30">MIN</span>}
              </button>
              <button
                onClick={(e) => { e.stopPropagation(); close(w.id); }}
                className="h-full w-6 grid place-items-center text-slate-500 hover:bg-red-600/80 hover:text-white"
                title="Cerrar"
              >
                <X className="h-3 w-3" />
              </button>
            </div>
          );
        })}
        <div className="ml-auto flex items-center gap-2 pl-2 border-l border-slate-700/60 shrink-0">
          <span className="text-[10px] font-mono text-slate-500">
            {windows.length} ventana{windows.length === 1 ? "" : "s"} · {windows.filter(w => w.isMinimized).length} min.
          </span>
        </div>
      </motion.div>
    </div>
  );
}

export function DesktopDashboard({ onDeactivate }: { onDeactivate: () => void }) {
  const reduceMotion = useReducedMotion();
  const panel = { hidden: { opacity: 0, y: 10 }, visible: { opacity: 1, y: 0, transition: { duration: reduceMotion ? 0.08 : 0.25 } } };
  return (
    <motion.div
      initial="hidden"
      animate="visible"
      variants={{ hidden: {}, visible: { transition: { delayChildren: reduceMotion ? 0 : 0.1, staggerChildren: reduceMotion ? 0 : 0.05 } } }}
      className="absolute inset-0 overflow-auto p-3"
    >
      <motion.div variants={panel} className="mb-2 flex flex-wrap items-end justify-between gap-2">
        <div>
          <div className="text-[10px] uppercase tracking-widest text-slate-500 font-semibold">Consola Ejecutiva · Systeck v10.6.3.0</div>
          <div className="text-[18px] font-bold text-slate-800 leading-tight">Dashboard Operativo — C2TECK S.A.C.</div>
        </div>
        <div className="flex flex-wrap items-center gap-3 text-[10.5px] font-mono text-slate-600">
          <Button variant="outline" size="sm" className="mdi-dashboard-hide h-7 text-[11px]" onClick={onDeactivate} title="Desactivar dashboard operativo">
            <EyeOff /> Desactivar dashboard
          </Button>
          <span className="flex items-center gap-1"><Wifi className="h-3 w-3 text-emerald-600" /> SUNAT · OSE ONLINE</span>
          <span className="flex items-center gap-1"><Database className="h-3 w-3 text-cyan-600" /> DB · 47ms</span>
          <span className="flex items-center gap-1"><Activity className="h-3 w-3 text-amber-600" /> 12 sesiones activas</span>
        </div>
      </motion.div>

      {/* KPI trend cards */}
      <motion.div variants={panel} className="grid grid-cols-1 sm:grid-cols-2 xl:grid-cols-3 gap-2.5">
        <KpiTrend label="Facturación Neta Diaria (S/.)" value="S/. 87,412.30" delta="+14.2%" up color="#0EA5E9" icon={FileText}
          spark={[22, 28, 24, 31, 29, 38, 44, 41, 52]} />
        <KpiTrend label="Órdenes de Trabajo Mina Ejecutadas" value="184" delta="+6.8%" up color="#10B981" icon={Wrench}
          spark={[12, 15, 14, 18, 22, 19, 24, 27, 31]} />
        <KpiTrend label="Alertas de Despacho (G/R Pendiente)" value="27" delta="-3.5%" up={false} color="#F59E0B" icon={AlertTriangle}
          spark={[41, 38, 42, 35, 37, 33, 30, 29, 27]} />
      </motion.div>

      {/* Charts row */}
      <motion.div variants={panel} className="grid grid-cols-1 lg:grid-cols-3 gap-2.5 mt-2.5">
        <div className="lg:col-span-2 rounded-md border border-slate-300 bg-white p-3 shadow-sm">
          <div className="flex items-center justify-between mb-2">
            <div>
              <div className="text-[11px] font-bold uppercase tracking-widest text-slate-700">Ventas Facturadas vs Costos Op. Importación</div>
              <div className="text-[10px] text-slate-500">Últimos 7 meses · PEN</div>
            </div>
            <div className="flex items-center gap-2 text-[10px] font-mono">
              <span className="flex items-center gap-1"><span className="h-2 w-2 rounded-sm bg-[#2563EB]" /> Ventas</span>
              <span className="flex items-center gap-1"><span className="h-2 w-2 rounded-sm bg-[#F59E0B]" /> Costos</span>
            </div>
          </div>
          <div className="h-[210px]">
            <ResponsiveContainer>
              <BarChart data={DASH_BARS} margin={{ top: 4, right: 4, left: -8, bottom: 0 }}>
                <CartesianGrid strokeDasharray="2 3" stroke="#E2E8F0" />
                <XAxis dataKey="m" stroke="#64748B" fontSize={11} />
                <YAxis stroke="#64748B" fontSize={10} tickFormatter={(v) => `${(v/1000).toFixed(0)}k`} />
                <Tooltip contentStyle={{ background: "#fff", border: "1px solid #CBD5E1", borderRadius: 6, fontSize: 11 }} />
                <Legend wrapperStyle={{ fontSize: 10 }} />
                <Bar dataKey="ventas" fill="#2563EB" radius={[3, 3, 0, 0]} />
                <Bar dataKey="costos" fill="#F59E0B" radius={[3, 3, 0, 0]} />
              </BarChart>
            </ResponsiveContainer>
          </div>
        </div>
        <div className="rounded-md border border-slate-300 bg-white p-3 shadow-sm">
          <div className="text-[11px] font-bold uppercase tracking-widest text-slate-700 mb-2">Rendimiento Operativo</div>
          <div className="grid grid-cols-2 gap-2">
            <Donut value={78} label="Capacidad Almacén Utilizada" color="#0EA5E9" />
            <Donut value={97} label="Éxito Transmisión SUNAT (OSE)" color="#10B981" />
            <Donut value={64} label="Cumplimiento OT Programadas" color="#8B5CF6" />
            <Donut value={42} label="Riesgo Cartera Vencida" color="#EF4444" />
          </div>
        </div>
      </motion.div>

      {/* Audit console */}
      <motion.div variants={panel} className="rounded-md border border-slate-300 bg-white shadow-sm mt-2.5 overflow-hidden">
        <div className="flex items-center justify-between px-3 py-1.5 bg-gradient-to-b from-[#243B55] to-[#141E30] text-white">
          <div className="text-[11px] font-bold uppercase tracking-widest flex items-center gap-2">
            <Activity className="h-3.5 w-3.5 text-cyan-300 animate-pulse" /> Consola de Auditoría · Movimientos en Vivo
          </div>
          <div className="text-[10px] font-mono text-cyan-300">// tail -f systeck.audit.log</div>
        </div>
        <table className="w-full text-[11.5px]">
          <thead className="bg-slate-100 text-slate-700">
            <tr>
              <th className="px-2 py-1 text-left font-semibold w-8"></th>
              <th className="px-2 py-1 text-left font-semibold">Usuario</th>
              <th className="px-2 py-1 text-left font-semibold">Acción</th>
              <th className="px-2 py-1 text-left font-semibold font-mono w-[170px]">Timestamp</th>
              <th className="px-2 py-1 text-center font-semibold w-16">Estado</th>
            </tr>
          </thead>
          <tbody>
            {AUDIT_ROWS.map((r, i) => (
              <tr key={i} className={i % 2 ? "bg-slate-50" : "bg-white"}>
                <td className="px-2 py-1 border-b border-slate-200">
                  <span className="inline-grid place-items-center h-6 w-6 rounded-full bg-gradient-to-br from-slate-600 to-slate-800 text-white text-[9.5px] font-bold">{r.u}</span>
                </td>
                <td className="px-2 py-1 border-b border-slate-200 font-medium text-slate-800">{r.n}</td>
                <td className="px-2 py-1 border-b border-slate-200 text-slate-700">{r.a}</td>
                <td className="px-2 py-1 border-b border-slate-200 font-mono text-slate-500">{r.t}</td>
                <td className="px-2 py-1 border-b border-slate-200 text-center">
                  <span className={`inline-block h-3 w-3 rounded-full animate-pulse ${LED[r.p as keyof typeof LED]}`} />
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </motion.div>
    </motion.div>
  );
}

function KpiTrend({ label, value, delta, up, color, spark, icon: Icon }: { label: string; value: string; delta: string; up: boolean; color: string; spark: number[]; icon: any }) {
  return (
    <div className="rounded-md border border-slate-300 bg-white p-3 shadow-sm flex flex-col gap-2">
      <div className="flex items-start justify-between gap-2">
        <div className="min-w-0">
          <div className="flex items-center gap-1.5 text-[10px] uppercase tracking-widest text-slate-500 font-semibold"><Icon className="h-3 w-3" /> {label}</div>
          <div className="text-[22px] font-bold text-slate-800 leading-tight mt-1 font-mono truncate">{value}</div>
        </div>
        <span className={`shrink-0 inline-flex items-center gap-0.5 px-1.5 py-0.5 rounded text-[10.5px] font-semibold ${up ? "bg-emerald-100 text-emerald-800 border border-emerald-300" : "bg-red-100 text-red-800 border border-red-300"}`}>
          {up ? <TrendingUp className="h-3 w-3" /> : <TrendingDown className="h-3 w-3" />}{delta}
        </span>
      </div>
      <Sparkline data={spark} color={color} up={up} />
    </div>
  );
}

const DASH_BARS = [
  { m: "Ene", ventas: 412000, costos: 268000 },
  { m: "Feb", ventas: 438000, costos: 281000 },
  { m: "Mar", ventas: 471000, costos: 304000 },
  { m: "Abr", ventas: 452000, costos: 292000 },
  { m: "May", ventas: 498000, costos: 315000 },
  { m: "Jun", ventas: 536000, costos: 331000 },
  { m: "Jul", ventas: 561000, costos: 348000 },
];

const AUDIT_ROWS = [
  { u: "GR", n: "G. Ríos", a: "Modificación de Precio Lista SKU-1042", t: "2026-07-10 09:14:22", p: "warn" },
  { u: "AS", n: "A. Salcedo", a: "Emisión Factura F001-000487 · CDR OK", t: "2026-07-10 09:11:07", p: "ok" },
  { u: "LP", n: "L. Palomino", a: "Cierre de Mes · Costos JUN-2026", t: "2026-07-10 09:07:53", p: "ok" },
  { u: "MC", n: "M. Cárdenas", a: "OT-2026-0344 → escalada a Crítica", t: "2026-07-10 09:03:41", p: "crit" },
  { u: "RF", n: "R. Flores", a: "Generación PLE 08.1 (Contabilidad)", t: "2026-07-10 08:58:19", p: "ok" },
  { u: "JV", n: "J. Vidal", a: "Aprobación OC-2026-0091 · S/. 24,880.00", t: "2026-07-10 08:52:04", p: "warn" },
  { u: "GR", n: "G. Ríos", a: "Alerta SUNAT · Reintento envío boleta", t: "2026-07-10 08:47:31", p: "crit" },
];

const LED = { ok: "bg-emerald-400 shadow-[0_0_8px_#10B981]", warn: "bg-amber-400 shadow-[0_0_8px_#F59E0B]", crit: "bg-red-500 shadow-[0_0_8px_#EF4444]" };

function Donut({ value, label, color }: { value: number; label: string; color: string }) {
  const data = [{ name: "v", value }, { name: "r", value: 100 - value }];
  return (
    <div className="flex flex-col items-center gap-1">
      <div className="relative h-[92px] w-[92px]">
        <ResponsiveContainer>
          <PieChart>
            <Pie data={data} innerRadius={30} outerRadius={44} dataKey="value" stroke="none" startAngle={90} endAngle={-270}>
              <Cell fill={color} />
              <Cell fill="#E2E8F0" />
            </Pie>
          </PieChart>
        </ResponsiveContainer>
        <div className="absolute inset-0 grid place-items-center">
          <div className="text-[15px] font-bold font-mono text-slate-800">{value}%</div>
        </div>
      </div>
      <div className="text-[10.5px] text-slate-600 text-center leading-tight max-w-[110px]">{label}</div>
    </div>
  );
}

function Sparkline({ data, color = "#0EA5E9", up = true }: { data: number[]; color?: string; up?: boolean }) {
  const min = Math.min(...data), max = Math.max(...data);
  const range = max - min || 1;
  const pts = data.map((v, i) => `${(i / (data.length - 1)) * 100},${100 - ((v - min) / range) * 100}`).join(" ");
  return (
    <svg viewBox="0 0 100 100" preserveAspectRatio="none" className="w-full h-10">
      <defs>
        <linearGradient id={`sg-${color.replace('#','')}-${up ? 1 : 0}`} x1="0" x2="0" y1="0" y2="1">
          <stop offset="0%" stopColor={color} stopOpacity="0.5" />
          <stop offset="100%" stopColor={color} stopOpacity="0" />
        </linearGradient>
      </defs>
      <polyline points={pts} fill="none" stroke={color} strokeWidth="2" vectorEffect="non-scaling-stroke" />
      <polygon points={`0,100 ${pts} 100,100`} fill={`url(#sg-${color.replace('#','')}-${up ? 1 : 0})`} />
    </svg>
  );
}