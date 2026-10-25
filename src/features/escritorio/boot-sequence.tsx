import { useEffect, useMemo, useRef, useState, type FormEvent } from "react";
import { AnimatePresence, motion, useReducedMotion } from "framer-motion";
import {
  BadgeCheck,
  Building2,
  CalendarDays,
  Check,
  ChevronDown,
  Database,
  DollarSign,
  Eye,
  EyeOff,
  KeyRound,
  Landmark,
  LoaderCircle,
  Monitor,
  LockKeyhole,
  MapPin,
  Moon,
  Network,
  ShieldCheck,
  Sun,
  UserRound,
  UserPlus,
} from "lucide-react";
import { Button } from "@/components/ui/button";

export type SysteckAppState = "boot" | "login" | "workspace-intro" | "workspace";
export type EntryTheme = "dark" | "light";

function ThemePicker({ theme, onThemeChange }: { theme: EntryTheme; onThemeChange: (theme: EntryTheme) => void }) {
  const [open, setOpen] = useState(false);
  const reduceMotion = useReducedMotion();
  return (
    <div className="absolute right-5 top-5 z-30 sm:right-8 sm:top-8">
      <Button type="button" variant="outline" size="icon" title="Cambiar temática" aria-label="Cambiar temática" aria-expanded={open} onClick={() => setOpen((value) => !value)} className="h-10 w-10 border-login-border bg-login-panel text-login-foreground hover:bg-login-input hover:text-login-foreground">
        <motion.span key={theme} className="flex" initial={{ opacity: 0, rotate: reduceMotion ? 0 : -35 }} animate={{ opacity: 1, rotate: 0 }} transition={{ duration: reduceMotion ? 0.1 : 0.25 }}>{theme === "dark" ? <Moon /> : <Sun />}</motion.span>
      </Button>
      <AnimatePresence>{open && <motion.div initial={{ opacity: 0, y: reduceMotion ? 0 : -6 }} animate={{ opacity: 1, y: 0 }} exit={{ opacity: 0, y: reduceMotion ? 0 : -4 }} transition={{ duration: reduceMotion ? 0.1 : 0.18 }} className="absolute right-0 top-12 w-40 rounded-md border border-login-border bg-login-panel p-1 shadow-login-panel" role="group" aria-label="Temática">
        <Button type="button" variant="ghost" onClick={() => { onThemeChange("dark"); setOpen(false); }} aria-pressed={theme === "dark"} className={`w-full justify-start text-xs text-login-foreground hover:bg-login-input hover:text-login-foreground ${theme === "dark" ? "bg-login-input" : ""}`}><Moon /> Oscuro {theme === "dark" && <Check className="ml-auto" />}</Button>
        <Button type="button" variant="ghost" onClick={() => { onThemeChange("light"); setOpen(false); }} aria-pressed={theme === "light"} className={`w-full justify-start text-xs text-login-foreground hover:bg-login-input hover:text-login-foreground ${theme === "light" ? "bg-login-input" : ""}`}><Sun /> Claro {theme === "light" && <Check className="ml-auto" />}</Button>
      </motion.div>}</AnimatePresence>
    </div>
  );
}

export type LoginResult = {
  user: string;
  fecha: string;
  tc: string;
  perfil: string;
  company: string;
  branch: string;
};

const BOOT_MESSAGES = [
  "Iniciando núcleo Systeck MDI Engine v10.6.3...",
  "Conectando con Servidores OSE / SUNAT...",
  "Cargando motor de Inteligencia Predictiva y Auditoría...",
  "Verificando cifrado de seguridad y firmas digitales...",
  "Entorno listo.",
];

const COMPANIES = [
  { value: "C2TECK S.A.C. · 20512345678", label: "C2TECK S.A.C.", ruc: "20512345678" },
  { value: "MINERA ANDINOS DEL SUR S.A. · 20487654321", label: "MINERA ANDINOS DEL SUR S.A.", ruc: "20487654321" },
  { value: "INDUSTRIAS METALMEC S.A.C. · 20601239987", label: "INDUSTRIAS METALMEC S.A.C.", ruc: "20601239987" },
];

const BRANCHES: Record<string, string[]> = {
  "C2TECK S.A.C. · 20512345678": ["Matriz Lima · Sede 001", "Centro Logístico Callao · Sede 002", "Operaciones Arequipa · Sede 003"],
  "MINERA ANDINOS DEL SUR S.A. · 20487654321": ["Unidad Arequipa · Sede 001", "Campamento Sur · Sede 002"],
  "INDUSTRIAS METALMEC S.A.C. · 20601239987": ["Planta Callao · Sede 001", "Almacén Lurín · Sede 002"],
};

const DEMO_EXCHANGE_RATE = "3.406";
const DEMO_WORK_DATE = "10/07/2026";

export function CompanyLogoSlot({ compact = false, micro = false, className = "", label = "Espacio para logotipo de la empresa" }: { compact?: boolean; micro?: boolean; className?: string; label?: string }) {
  const reduceMotion = useReducedMotion();
  return (
    <motion.div
      role="img"
      aria-label={label}
      title={label}
      initial={{ opacity: 0, scale: reduceMotion ? 1 : 0.9 }}
      animate={{ opacity: 1, scale: 1 }}
      transition={{ duration: reduceMotion ? 0.1 : 0.35, ease: "easeOut" }}
      className={`company-logo-slot relative flex shrink-0 items-center justify-center gap-2 overflow-hidden rounded-md border border-dashed border-boot-border bg-boot-panel/60 text-boot-muted ${micro ? "h-6 w-6 rounded-sm" : compact ? "h-11 w-11" : "h-11 min-w-[128px] px-3"} ${className}`}
    >
      <motion.span
        aria-hidden="true"
        animate={reduceMotion ? undefined : { y: [0, -2, 0], opacity: [0.7, 1, 0.7] }}
        transition={{ duration: 3.2, repeat: reduceMotion ? 0 : Infinity, ease: "easeInOut" }}
      >
        <Building2 className={micro ? "h-3 w-3" : "h-4 w-4"} />
      </motion.span>
      {!compact && !micro && <span className="font-mono text-[9px] font-semibold">LOGO EMPRESA</span>}
      <span aria-hidden="true" className="company-logo-slot-sheen pointer-events-none absolute inset-y-0 -left-1/2 w-1/3" />
    </motion.div>
  );
}

function CompanyBrandDeck({ compact = false }: { compact?: boolean }) {
  const reduceMotion = useReducedMotion();
  const slots = [
    { label: "Empresa", icon: Building2 },
    { label: "Marca", icon: Landmark },
    { label: "Sucursal", icon: BadgeCheck },
  ];

  return (
    <div className={`company-brand-deck mx-auto grid w-full max-w-sm grid-cols-3 gap-2 ${compact ? "company-brand-deck-compact" : ""}`} aria-label="Espacios para identidad corporativa">
      {slots.map(({ label, icon: Icon }, index) => (
        <motion.div
          key={label}
          role="img"
          aria-label={`Espacio para logotipo: ${label}`}
          title={`Espacio para logotipo de ${label.toLowerCase()}`}
          initial={{ opacity: 0, y: reduceMotion ? 0 : 8, scale: reduceMotion ? 1 : 0.96 }}
          animate={{ opacity: 1, y: 0, scale: 1 }}
          whileHover={reduceMotion ? undefined : { y: -2, scale: 1.02 }}
          transition={{ duration: reduceMotion ? 0.08 : 0.28, delay: reduceMotion ? 0 : index * 0.07, ease: "easeOut" }}
          className="company-brand-slot relative flex min-h-14 flex-col items-center justify-center gap-1 overflow-hidden rounded-md border border-dashed px-2 py-2 text-center"
        >
          <Icon aria-hidden="true" className="h-4 w-4" />
          <span className="relative z-10 font-mono text-[9px] font-semibold uppercase">{label}</span>
          <span className="company-brand-sheen pointer-events-none absolute inset-y-0 -left-1/2 w-1/3" aria-hidden="true" />
        </motion.div>
      ))}
    </div>
  );
}

function LoadingDetails({ progress, workspace = false }: { progress: number; workspace?: boolean }) {
  const reduceMotion = useReducedMotion();
  const items = workspace
    ? [
        { icon: UserRound, label: "Preferencias de sesión", detail: "Usuario y entorno de trabajo" },
        { icon: Building2, label: "Módulos empresariales", detail: "Ventas · compras · inventarios" },
        { icon: ShieldCheck, label: "Consolas de control", detail: "Riesgo · auditoría · aprobaciones" },
        { icon: Monitor, label: "Escritorio MDI", detail: "Ventanas · indicadores · dock" },
      ]
    : [
        { icon: Database, label: "Núcleo Systeck", detail: "Motor empresarial v10.6.3" },
        { icon: Network, label: "Entorno de integración", detail: "OSE / SUNAT · modo demostración" },
        { icon: ShieldCheck, label: "Motor de control", detail: "Crédito · costos · auditoría" },
        { icon: Monitor, label: "Interfaz de acceso", detail: "Identidad corporativa y preferencias" },
      ];
  return (
    <div className="mt-5 border-t border-boot-border pt-3 text-left" aria-label={workspace ? "Preparación de módulos del escritorio" : "Etapas de inicio del sistema"}>
      <div className="mb-2 flex items-center justify-between font-mono text-[9px] text-boot-muted">
        <span>{workspace ? "ESPACIO DE TRABAJO" : "SECUENCIA DE INICIO"}</span>
        <span className="tabular-nums">{Math.min(4, Math.floor(progress / 25))} / 4</span>
      </div>
      <div className="grid grid-cols-1 gap-x-5 gap-y-2 sm:grid-cols-2">
        {items.map(({ icon: Icon, label, detail }, index) => {
          const localProgress = Math.min(100, Math.max(0, (progress - index * 25) * 4));
          const complete = localProgress === 100;
          const active = !complete && progress >= index * 25;
          return (
            <motion.div key={label} initial={{ opacity: 0, y: reduceMotion ? 0 : 5 }} animate={{ opacity: 1, y: 0 }} transition={{ duration: reduceMotion ? 0.08 : 0.25, delay: reduceMotion ? 0 : index * 0.06 }} className="min-w-0 py-1">
              <div className="flex items-center gap-2">
                <Icon aria-hidden="true" className={`h-3.5 w-3.5 shrink-0 ${complete ? "text-boot-success" : active ? "text-boot-accent" : "text-boot-muted"}`} />
                <span className="min-w-0 flex-1 text-[10px] font-medium text-boot-foreground">{label}</span>
                <span className={`flex h-4 w-4 shrink-0 items-center justify-center ${complete ? "text-boot-success" : "text-boot-muted"}`} title={complete ? "Listo" : active ? "Preparando" : "En espera"}>
                  {complete ? <Check aria-label="Listo" className="h-3 w-3" /> : active ? <LoaderCircle aria-label="Preparando" className={`h-3 w-3 ${reduceMotion ? "" : "animate-spin"}`} /> : <span aria-label="En espera" className="h-1 w-1 rounded-full bg-boot-muted/40" />}
                </span>
              </div>
              <p className="ml-5 mt-0.5 text-[9px] text-boot-muted">{detail}</p>
              <div aria-hidden="true" className="ml-5 mt-1.5 h-px overflow-hidden bg-boot-border">
                <motion.div className={`h-full origin-left ${complete ? "bg-boot-success" : "bg-boot-accent"}`} initial={{ scaleX: 0 }} animate={{ scaleX: localProgress / 100 }} transition={{ duration: reduceMotion ? 0 : 0.12 }} />
              </div>
            </motion.div>
          );
        })}
      </div>
      <div className="mt-3 flex flex-wrap items-center justify-between gap-2 border-t border-boot-border pt-3 font-mono text-[9px] text-boot-muted">
        <span className="flex items-center gap-1.5"><Monitor className="h-3 w-3" /> SYSTECK MDI · V10.6.3</span>
        <span className="flex items-center gap-1.5"><span className="h-1.5 w-1.5 rounded-full bg-boot-accent" /> ENTORNO DEMO</span>
      </div>
    </div>
  );
}

function CinematicBrand({ arrival = false }: { arrival?: boolean }) {
  const reduceMotion = useReducedMotion();
  return (
    <div className={`cinematic-brand relative ${arrival ? "cinematic-arrival" : ""}`}>
      <div className="cinematic-rays pointer-events-none absolute" aria-hidden="true">
        {Array.from({ length: 28 }, (_, index) => <i key={index} />)}
      </div>
      <motion.div
        aria-hidden="true"
        className="cinematic-monogram relative mx-auto mb-6 h-28 w-20 sm:h-36 sm:w-24"
        initial={reduceMotion ? { opacity: 0 } : { opacity: 0, scale: 0.72, rotateY: -28 }}
        animate={reduceMotion ? { opacity: 1 } : { opacity: [0, 1, 1, 0], scale: [0.72, 1, 1, 5], rotateY: [-28, 0, 0, 0] }}
        transition={{ duration: reduceMotion ? 0.1 : 2.2, times: reduceMotion ? undefined : [0, 0.3, 0.72, 1], ease: "easeInOut" }}
      >
        <span className="cinematic-stroke cinematic-stroke-top" />
        <span className="cinematic-stroke cinematic-stroke-middle" />
        <span className="cinematic-stroke cinematic-stroke-bottom" />
      </motion.div>
      <motion.div
        className="relative font-display text-4xl font-bold text-boot-foreground sm:text-5xl"
        initial={{ opacity: 0, scale: reduceMotion ? 1 : 0.94 }}
        animate={{ opacity: 1, scale: 1 }}
        transition={{ delay: reduceMotion ? 0 : 0.4, duration: reduceMotion ? 0.1 : 0.7 }}
      >SYSTECK</motion.div>
      <motion.div className="relative mt-2 text-[11px] font-semibold text-boot-muted" initial={{ opacity: 0 }} animate={{ opacity: 1 }} transition={{ delay: reduceMotion ? 0 : 0.85 }}>
        C2TECK S.A.C. · ENTERPRISE MDI
      </motion.div>
      <CompanyBrandDeck />
    </div>
  );
}

export function WorkspaceIntro({ user, theme, onComplete }: { user: string; theme: EntryTheme; onComplete: () => void }) {
  const reduceMotion = useReducedMotion();
  const [progress, setProgress] = useState(0);
  const completeRef = useRef(onComplete);
  useEffect(() => { completeRef.current = onComplete; }, [onComplete]);
  useEffect(() => {
    const duration = reduceMotion ? 450 : 2200;
    const started = performance.now();
    let completionTimer: number | undefined;
    const timer = window.setInterval(() => {
      const next = Math.min(100, Math.round((performance.now() - started) / duration * 100));
      setProgress(next);
      if (next === 100) {
        window.clearInterval(timer);
        completionTimer = window.setTimeout(() => completeRef.current(), reduceMotion ? 120 : 400);
      }
    }, 32);
    return () => { window.clearInterval(timer); window.clearTimeout(completionTimer); };
  }, [reduceMotion]);
  const ready = progress === 100;
  const stages = ["Preparando espacio de trabajo", "Organizando módulos y herramientas", "Preparando ventanas e indicadores", "Escritorio listo"];
  const stage = ready ? 3 : Math.min(2, Math.floor(progress / 34));
  return (
    <motion.section
      data-entry-theme={theme}
      aria-label="Preparando escritorio Systeck"
      className="fixed inset-0 z-[10000] overflow-y-auto overflow-x-hidden bg-boot px-5 text-boot-foreground"
      initial={{ opacity: 0 }} animate={{ opacity: 1 }}
      exit={{ opacity: 0 }}
      transition={{ duration: reduceMotion ? 0.1 : 0.32, ease: "easeInOut" }}
    >
      <div aria-hidden="true" className="boot-grid pointer-events-none absolute inset-0 opacity-20" />
      <div className="relative flex min-h-full items-center justify-center py-8">
      <motion.div className="w-full max-w-md text-center"
        initial={{ opacity: 0, y: 10 }} animate={{ opacity: 1, y: 0 }}
        exit={reduceMotion ? { opacity: 0 } : { opacity: 0, y: -12, scale: 0.98 }}
        transition={{ duration: reduceMotion ? 0.1 : 0.3, ease: "easeOut" }}
      >
        <div className="relative mx-auto mb-6 flex h-20 w-20 items-center justify-center">
          <div className="absolute inset-0 rounded-full border-2 border-boot-border" />
          <motion.div aria-hidden="true" className="absolute inset-0 rounded-full border-2 border-transparent border-t-boot-accent border-r-boot-accent/40"
            animate={{ rotate: ready || reduceMotion ? 0 : 360, opacity: ready ? 0 : 1 }}
            transition={{ rotate: { duration: 1.2, repeat: ready || reduceMotion ? 0 : Infinity, ease: "linear" }, opacity: { duration: 0.2 } }}
          />
          <AnimatePresence mode="wait" initial={false}>
            <motion.div key={ready ? "ready" : "loading"} initial={{ opacity: 0 }} animate={{ opacity: 1 }} exit={{ opacity: 0 }} transition={{ duration: 0.1 }}>
              {ready ? <Check className="h-7 w-7 text-boot-success" /> : <Monitor className="h-7 w-7 text-boot-accent" strokeWidth={1.5} />}
            </motion.div>
          </AnimatePresence>
        </div>
        <h2 className="font-display text-2xl font-semibold text-boot-foreground">SYSTECK MDI</h2>
        <p className="mt-2 break-words text-xs text-boot-muted">Bienvenido, {user}</p>
        <div className="mt-4"><CompanyBrandDeck compact /></div>
        <div className="mt-8">
          <div className="mb-2 flex items-center justify-between text-xs">
            <span className="font-medium text-boot-foreground">{ready ? "Carga completada" : "Cargando escritorio…"}</span>
            <span className="font-mono tabular-nums text-boot-muted">{progress}%</span>
          </div>
          <div role="progressbar" aria-label="Carga del escritorio" aria-valuemin={0} aria-valuemax={100} aria-valuenow={progress} className="h-1.5 overflow-hidden rounded-full bg-boot-border">
            <motion.div className="h-full origin-left bg-boot-accent" animate={{ scaleX: progress / 100 }} initial={{ scaleX: 0 }} transition={{ duration: reduceMotion ? 0 : 0.08, ease: "linear" }} />
          </div>
          <p role="status" className="mt-3 h-5 text-left text-[11px] text-boot-muted">{stages[stage]}</p>
        </div>
        <LoadingDetails progress={progress} workspace />
        <div className="mt-6 flex items-center justify-center gap-2 text-[10px] text-boot-muted">
          <ShieldCheck className="h-3.5 w-3.5 text-boot-success" /> Sesión de demostración
        </div>
      </motion.div>
      </div>
    </motion.section>
  );
}

export function BootSplashScreen({ onComplete, theme, onThemeChange }: { onComplete: () => void; theme: EntryTheme; onThemeChange: (theme: EntryTheme) => void }) {
  const reduceMotion = useReducedMotion();
  const [progress, setProgress] = useState(0);
  const onCompleteRef = useRef(onComplete);

  useEffect(() => {
    onCompleteRef.current = onComplete;
  }, [onComplete]);

  useEffect(() => {
    const duration = reduceMotion ? 800 : 2800;
    const started = performance.now();
    let completionTimer: number | undefined;
    const tick = window.setInterval(() => {
      const elapsed = performance.now() - started;
      const next = Math.min(100, Math.round((elapsed / duration) * 100));
      setProgress(next);
      if (next >= 100) {
        window.clearInterval(tick);
        completionTimer = window.setTimeout(() => onCompleteRef.current(), reduceMotion ? 80 : 180);
      }
    }, 32);
    return () => { window.clearInterval(tick); window.clearTimeout(completionTimer); };
  }, [reduceMotion]);

  const messageIndex = Math.min(BOOT_MESSAGES.length - 1, Math.floor(progress / 21));

  return (
    <motion.section
      key="boot"
      initial={{ opacity: 0 }}
      animate={{ opacity: 1 }}
      exit={{ opacity: 0, scale: 1.05, filter: "blur(14px)" }}
      transition={{ duration: reduceMotion ? 0.1 : 0.42, ease: "easeInOut" }}
      className="fixed inset-0 z-[10000] overflow-y-auto overflow-x-hidden bg-boot text-boot-foreground"
      data-entry-theme={theme}
      aria-label="Iniciando Systeck MDI"
    >
      <ThemePicker theme={theme} onThemeChange={onThemeChange} />
      <div className="boot-grid absolute inset-0 opacity-40" />
      <div className="boot-ambient absolute inset-0" />
      <div className="relative z-10 flex min-h-full items-center justify-center px-5 pb-16 pt-20">
        <div className="w-full max-w-xl text-center">
           <CinematicBrand />

          <div className="mx-auto mt-6 max-w-md">
            <div className="mb-2 flex items-center justify-between font-mono text-[10px] text-boot-muted">
              <span>SECURE BOOT</span><span className="tabular-nums">{progress}%</span>
            </div>
            <div role="progressbar" aria-label="Carga inicial de Systeck" aria-valuemin={0} aria-valuemax={100} aria-valuenow={progress} className="h-1.5 overflow-hidden rounded-full border border-boot-border bg-boot-panel">
              <motion.div
                className="h-full bg-gradient-to-r from-boot-accent-dim via-boot-accent to-boot-highlight shadow-boot-line"
                animate={{ width: `${progress}%` }}
                transition={{ duration: 0.08, ease: "linear" }}
              />
            </div>
            <div className="mt-5 min-h-12 rounded border border-boot-border bg-boot-panel/60 px-4 py-3 text-left backdrop-blur-md">
              <AnimatePresence mode="wait">
                <motion.div
                  key={messageIndex}
                  initial={{ opacity: 0, y: 4 }}
                  animate={{ opacity: 1, y: 0 }}
                  exit={{ opacity: 0, y: -4 }}
                  className="flex items-center gap-2 font-mono text-[11px] text-boot-muted"
                >
                  {progress === 100 ? <Check className="h-3.5 w-3.5 text-boot-success" /> : <span className="h-1.5 w-1.5 animate-pulse rounded-full bg-boot-accent shadow-boot-dot" />}
                  <span>{BOOT_MESSAGES[messageIndex]}</span>
                </motion.div>
              </AnimatePresence>
            </div>
            <LoadingDetails progress={progress} />
          </div>
        </div>
      </div>
      <div className="pointer-events-none fixed bottom-4 left-5 right-5 text-center font-mono text-[9px] text-boot-muted">
        KERNEL 10.6.3 · BUILD 2026.09 · HARDWARE ACCELERATION ACTIVE
      </div>
    </motion.section>
  );
}

export function EnterpriseLoginModal({ onAuthenticated, theme, onThemeChange }: { onAuthenticated: (result: LoginResult) => void; theme: EntryTheme; onThemeChange: (theme: EntryTheme) => void }) {
  const reduceMotion = useReducedMotion();
  const [company, setCompany] = useState(COMPANIES[0].value);
  const branches = useMemo(() => BRANCHES[company] ?? [], [company]);
  const [branch, setBranch] = useState(BRANCHES[COMPANIES[0].value][0]);
  const [user, setUser] = useState("grios");
  const [password, setPassword] = useState("");
  const [showPassword, setShowPassword] = useState(false);
  const [busy, setBusy] = useState(false);
  const [granted, setGranted] = useState(false);
  const authTimer = useRef<number | undefined>(undefined);
  useEffect(() => () => window.clearTimeout(authTimer.current), []);
  const [capsLock, setCapsLock] = useState(false);
  const [mode, setMode] = useState<"login" | "register">("login");
  const [fullName, setFullName] = useState("");
  const [email, setEmail] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [registrationMessage, setRegistrationMessage] = useState("");
  const [exchangeRate, setExchangeRate] = useState(DEMO_EXCHANGE_RATE);
  const [workDate, setWorkDate] = useState(DEMO_WORK_DATE);

  const chooseCompany = (value: string) => {
    setCompany(value);
    setBranch(BRANCHES[value]?.[0] ?? "");
  };

  const submit = (event: FormEvent) => {
    event.preventDefault();
    if (mode === "register") {
      if (!fullName.trim() || !email.trim() || !user.trim() || !password || password !== confirmPassword) return;
      setRegistrationMessage("Registro de demostración completado. No se creó una cuenta real.");
      return;
    }
    if (busy || !user.trim() || !password) return;
    setBusy(true);
    authTimer.current = window.setTimeout(() => {
      setGranted(true);
      authTimer.current = window.setTimeout(() => {
      onAuthenticated({ user: user.trim(), fecha: workDate.trim() || DEMO_WORK_DATE, tc: exchangeRate.trim() || DEMO_EXCHANGE_RATE, perfil: "Consultor", company, branch });
      }, reduceMotion ? 100 : 550);
    }, reduceMotion ? 150 : 760);
  };

  const selectClass = "h-10 w-full appearance-none rounded-md border border-login-border bg-login-input px-9 pr-8 text-[12px] text-login-foreground outline-none transition-shadow focus:border-login-accent focus:ring-2 focus:ring-login-accent/25";
  const inputClass = "h-10 w-full rounded-md border border-login-border bg-login-input px-9 pr-10 text-[12px] text-login-foreground outline-none transition-shadow placeholder:text-login-muted focus:border-login-accent focus:ring-2 focus:ring-login-accent/25";

  return (
    <motion.section
      key="login"
      initial={{ opacity: 0 }}
      animate={{ opacity: 1 }}
      exit={{ opacity: 0 }}
      transition={{ duration: reduceMotion ? 0.1 : 0.3 }}
      className="login-entry fixed inset-0 z-[9999] overflow-y-auto bg-login-bg text-login-foreground"
      data-entry-theme={theme}
    >
      <ThemePicker theme={theme} onThemeChange={onThemeChange} />
      <div className="boot-grid absolute inset-0 opacity-20" />
      <div className="login-ambient absolute inset-0" />
      <div className="relative z-10 grid min-h-full place-items-center px-4 pb-10 pt-20 sm:py-16">
        <motion.form
          layout={reduceMotion ? false : "size"}
          onSubmit={submit}
          aria-busy={busy}
          initial={{ opacity: 0, y: 24, scale: 0.96 }}
          animate={{ opacity: 1, y: 0, scale: 1 }}
          exit={{ opacity: 0, scale: 0.95, filter: "blur(8px)" }}
          transition={{ duration: reduceMotion ? 0.1 : 0.42, type: "spring", stiffness: 180, damping: 20 }}
          className="login-form relative w-full max-w-[520px] overflow-hidden rounded-lg border border-login-border bg-login-panel/80 shadow-login-panel backdrop-blur-xl"
        >
          <div className="login-edge pointer-events-none absolute inset-x-0 top-0 h-px" aria-hidden="true" />
          <header className="border-b border-login-border px-6 pb-5 pt-6">
            <div className="flex items-start justify-between gap-4">
              <div className="flex items-center gap-3">
                <CompanyLogoSlot compact className="border-login-accent/35 bg-login-accent/10 text-login-accent shadow-login-icon" />
                <div>
                  <motion.h1 key={mode} initial={{ opacity: 0, y: reduceMotion ? 0 : 5 }} animate={{ opacity: 1, y: 0 }} transition={{ duration: reduceMotion ? 0.1 : 0.25 }} className="font-display text-xl font-semibold">{mode === "login" ? "Acceso Systeck MDI" : "Registrar usuario"}</motion.h1>
                  <p className="mt-0.5 text-[10px] font-medium tracking-[0.16em] text-login-muted">CONTROL EMPRESARIAL · V10.6.3</p>
                </div>
              </div>
              <span className="inline-flex items-center gap-1.5 rounded border border-login-success/30 bg-login-success/10 px-2 py-1 font-mono text-[9px] text-login-success">
                <span className="h-1.5 w-1.5 animate-pulse rounded-full bg-login-success" /> ONLINE
              </span>
            </div>
          </header>

          <div className="border-b border-login-border px-6 py-3">
            <CompanyBrandDeck compact />
          </div>

          <div className="login-fields space-y-4 p-6">
            <div className="flex items-center justify-between gap-3 border-b border-login-border pb-3 text-[11px] text-login-muted">
              <span className="inline-flex items-center gap-2"><ShieldCheck className="h-4 w-4 text-login-success" /> {mode === "login" ? "Acceso al espacio de trabajo" : "Solicitud de acceso · demostración"}</span>
              <span className="font-mono">SYSTECK MDI · 10.6.3</span>
            </div>
            <div className="grid gap-3 sm:grid-cols-2">
              <label className="space-y-1.5">
                <span className="text-[10px] font-semibold uppercase tracking-[0.13em] text-login-muted">Empresa / RUC</span>
                <div className="relative">
                  <Building2 className="pointer-events-none absolute left-3 top-1/2 h-3.5 w-3.5 -translate-y-1/2 text-login-accent" />
                  <select aria-label="Empresa / RUC" value={company} onChange={(e) => chooseCompany(e.target.value)} className={selectClass}>
                    {COMPANIES.map((item) => <option key={item.ruc} value={item.value}>{item.label} · {item.ruc}</option>)}
                  </select>
                  <ChevronDown className="pointer-events-none absolute right-3 top-1/2 h-3.5 w-3.5 -translate-y-1/2 text-login-muted" />
                </div>
              </label>
              <label className="space-y-1.5">
                <span className="text-[10px] font-semibold uppercase tracking-[0.13em] text-login-muted">Sucursal / Sede</span>
                <div className="relative">
                  <MapPin className="pointer-events-none absolute left-3 top-1/2 h-3.5 w-3.5 -translate-y-1/2 text-login-success" />
                  <select aria-label="Sucursal / Sede" value={branch} onChange={(e) => setBranch(e.target.value)} className={selectClass}>
                    {branches.map((item) => <option key={item}>{item}</option>)}
                  </select>
                  <ChevronDown className="pointer-events-none absolute right-3 top-1/2 h-3.5 w-3.5 -translate-y-1/2 text-login-muted" />
                </div>
              </label>
            </div>

            <div className="h-px bg-login-border" />

            <div className="flex items-start gap-3 rounded-md border border-login-border bg-login-input/50 px-3 py-2.5">
              <Building2 className="mt-0.5 h-4 w-4 shrink-0 text-login-accent" />
              <div className="min-w-0 text-[11px]"><p className="font-semibold text-login-foreground">Ámbito de trabajo seleccionado</p><motion.p key={`${company}-${branch}`} initial={{ opacity: 0, y: reduceMotion ? 0 : 4 }} animate={{ opacity: 1, y: 0 }} transition={{ duration: 0.18 }} className="mt-0.5 truncate text-login-muted">{company} · {branch}</motion.p></div>
            </div>

            <div className="grid gap-3 border-y border-login-border py-3 sm:grid-cols-2">
              <label className="block space-y-1.5">
                <span className="text-[10px] font-semibold uppercase tracking-[0.13em] text-login-muted">Tipo de cambio · USD/PEN</span>
                <div className="relative">
                  <DollarSign className="pointer-events-none absolute left-3 top-1/2 h-3.5 w-3.5 -translate-y-1/2 text-login-accent" />
                  <input
                    aria-label="Tipo de cambio USD/PEN"
                    inputMode="decimal"
                    value={exchangeRate}
                    onChange={(e) => setExchangeRate(e.target.value.replace(/[^0-9.,]/g, ""))}
                    className="h-10 w-full rounded-md border border-login-border bg-login-input px-9 pr-3 font-mono text-[12px] font-semibold tabular-nums text-login-foreground outline-none transition-shadow placeholder:text-login-muted focus:border-login-accent focus:ring-2 focus:ring-login-accent/25"
                    placeholder="3.406"
                  />
                </div>
                <span className="block text-[9px] text-login-muted">Referencial · editable · demo</span>
              </label>
              <label className="block space-y-1.5">
                <span className="text-[10px] font-semibold uppercase tracking-[0.13em] text-login-muted">Fecha de trabajo</span>
                <div className="relative">
                  <CalendarDays className="pointer-events-none absolute left-3 top-1/2 h-3.5 w-3.5 -translate-y-1/2 text-login-success" />
                  <input
                    aria-label="Fecha de trabajo"
                    value={workDate}
                    onChange={(e) => setWorkDate(e.target.value.replace(/[^0-9/]/g, "").slice(0, 10))}
                    className="h-10 w-full rounded-md border border-login-border bg-login-input px-9 pr-3 font-mono text-[12px] font-semibold tabular-nums text-login-foreground outline-none transition-shadow placeholder:text-login-muted focus:border-login-accent focus:ring-2 focus:ring-login-accent/25"
                    placeholder="DD/MM/AAAA"
                  />
                </div>
                <span className="block text-[9px] text-login-muted">Formato DD/MM/AAAA · editable</span>
              </label>
            </div>

            <AnimatePresence initial={false}>{mode === "register" && <motion.div key="registration-details" initial={{ height: 0, opacity: 0 }} animate={{ height: "auto", opacity: 1 }} exit={{ height: 0, opacity: 0 }} transition={{ duration: reduceMotion ? 0.1 : 0.28 }} className="grid gap-3 overflow-hidden sm:grid-cols-2">
              <label className="block space-y-1.5"><span className="text-[10px] font-semibold uppercase text-login-muted">Nombre completo</span><input aria-label="Nombre completo" required value={fullName} onChange={(e) => setFullName(e.target.value)} className={inputClass} /></label>
              <label className="block space-y-1.5"><span className="text-[10px] font-semibold uppercase text-login-muted">Correo electrónico</span><input aria-label="Correo electrónico" type="email" required value={email} onChange={(e) => setEmail(e.target.value)} className={inputClass} /></label>
            </motion.div>}</AnimatePresence>

            <label className="block space-y-1.5">
              <span className="text-[10px] font-semibold uppercase tracking-[0.13em] text-login-muted">{mode === "login" ? "Usuario / DNI" : "Usuario / DNI para registrar"}</span>
              <div className="relative">
                <UserRound className="pointer-events-none absolute left-3 top-1/2 h-3.5 w-3.5 -translate-y-1/2 text-login-muted" />
                <input aria-label="Usuario / DNI" autoFocus required value={user} onChange={(e) => setUser(e.target.value)} className={inputClass} />
              </div>
            </label>
            <label className="block space-y-1.5">
              <span className="text-[10px] font-semibold uppercase tracking-[0.13em] text-login-muted">Contraseña</span>
              <div className="relative">
                <KeyRound className="pointer-events-none absolute left-3 top-1/2 h-3.5 w-3.5 -translate-y-1/2 text-login-muted" />
                <input aria-label="Contraseña" type={showPassword ? "text" : "password"} required value={password} onChange={(e) => setPassword(e.target.value)} onKeyDown={(e) => setCapsLock(e.getModifierState("CapsLock"))} onKeyUp={(e) => setCapsLock(e.getModifierState("CapsLock"))} onBlur={() => setCapsLock(false)} className={inputClass} />
                <Button variant="ghost" size="icon" type="button" onClick={() => setShowPassword((value) => !value)} aria-label={showPassword ? "Ocultar contraseña" : "Mostrar contraseña"} className="absolute right-1.5 top-1/2 h-7 w-7 -translate-y-1/2 text-login-muted hover:bg-login-accent/10 hover:text-login-accent">
                  <motion.span key={String(showPassword)} className="flex" initial={{ opacity: 0, scale: reduceMotion ? 1 : 0.7 }} animate={{ opacity: 1, scale: 1 }} transition={{ duration: 0.15 }}>{showPassword ? <EyeOff className="h-3.5 w-3.5" /> : <Eye className="h-3.5 w-3.5" />}</motion.span>
                </Button>
              </div>
              <AnimatePresence>{capsLock && <motion.span initial={{ opacity: 0, height: 0 }} animate={{ opacity: 1, height: "auto" }} exit={{ opacity: 0, height: 0 }} role="status" className="block overflow-hidden text-[11px] text-login-accent">Bloq Mayús está activado</motion.span>}</AnimatePresence>
            </label>

            <AnimatePresence initial={false}>{mode === "register" && <motion.div key="confirm-password" initial={{ height: 0, opacity: 0 }} animate={{ height: "auto", opacity: 1 }} exit={{ height: 0, opacity: 0 }} transition={{ duration: reduceMotion ? 0.1 : 0.28 }} className="overflow-hidden"><label className="block space-y-1.5"><span className="text-[10px] font-semibold uppercase text-login-muted">Confirmar contraseña</span><input aria-label="Confirmar contraseña" type="password" required value={confirmPassword} onChange={(e) => setConfirmPassword(e.target.value)} className={inputClass} /><AnimatePresence>{confirmPassword && password !== confirmPassword && <motion.span initial={{ opacity: 0 }} animate={{ opacity: 1 }} exit={{ opacity: 0 }} role="status" className="block text-[11px] text-login-accent">Las contraseñas no coinciden</motion.span>}</AnimatePresence></label></motion.div>}</AnimatePresence>

            <Button type="submit" disabled={busy || !user.trim() || !password || (mode === "register" && (!fullName.trim() || !email.trim() || password !== confirmPassword))} className="login-submit relative mt-1 h-11 w-full overflow-hidden bg-login-action text-login-action-foreground shadow-login-button hover:bg-login-action/90">
              <AnimatePresence mode="wait" initial={false}><motion.span key={`${mode}-${busy}-${granted}`} className="inline-flex items-center justify-center gap-2" initial={{ opacity: 0, y: reduceMotion ? 0 : 5 }} animate={{ opacity: 1, y: 0 }} exit={{ opacity: 0, y: reduceMotion ? 0 : -5 }} transition={{ duration: reduceMotion ? 0.05 : 0.12 }}>{mode === "register" ? <><UserPlus /> Registrar</> : granted ? <><Check /> Acceso concedido</> : busy ? <><LoaderCircle className="animate-spin" /> Autenticando credenciales...</> : <><LockKeyhole /> Iniciar Sesión</>}</motion.span></AnimatePresence>
            </Button>
            <AnimatePresence>{((registrationMessage && mode === "register") || granted) && <motion.p initial={{ opacity: 0, height: 0, y: reduceMotion ? 0 : 6 }} animate={{ opacity: 1, height: "auto", y: 0 }} exit={{ opacity: 0, height: 0 }} transition={{ duration: reduceMotion ? 0.1 : 0.25 }} role="status" className="overflow-hidden rounded-md border border-login-success/40 bg-login-success/10 p-2.5 text-center text-[11px] text-login-foreground">{granted ? `Acceso concedido — Bienvenido, ${user}` : registrationMessage}</motion.p>}</AnimatePresence>
            <Button type="button" disabled={busy} variant="ghost" onClick={() => { setMode(mode === "login" ? "register" : "login"); setRegistrationMessage(""); setPassword(""); setConfirmPassword(""); }} className="h-9 w-full text-xs text-login-accent hover:bg-login-input hover:text-login-accent">
              {mode === "login" ? <><UserPlus /> Registrar nuevo usuario</> : "Volver a Iniciar Sesión"}
            </Button>

            <div className="flex flex-wrap items-center justify-center gap-x-3 gap-y-1 rounded-md border border-login-border bg-login-input/50 px-3 py-2 font-mono text-[9px] text-login-muted">
              <span className="inline-flex items-center gap-1.5"><ShieldCheck className="h-3 w-3 text-login-success" /> Conexión Cifrada 256-bit SSL</span>
              <span className="text-login-border">|</span>
              <span className="inline-flex items-center gap-1.5"><Database className="h-3 w-3 text-login-accent" /> DB Online · 47ms</span>
              <span className="text-login-border">|</span>
              <span className="inline-flex items-center gap-1.5"><Network className="h-3 w-3 text-login-success" /> OSE/SUNAT OK</span>
            </div>
          </div>
        </motion.form>
      </div>
    </motion.section>
  );
}