import { useState, type ReactNode } from "react";
import { Link, useRouterState, useNavigate } from "@tanstack/react-router";
import {
  LayoutDashboard, Boxes, AppWindow, ServerCog, ShieldCheck, Users, Menu, X, Bell,
  Search, Cpu, Settings, ScrollText, ChevronDown, Building2, UserCog, Home,
  LogOut, User, CheckCheck, KeyRound,
} from "lucide-react";
import { cn } from "@/lib/utils";
import { useStore, actions, ROLE_LABEL, type ModuleKey, type Role } from "@/lib/store";
import { toast } from "sonner";

const NAV: { to: string; label: string; icon: typeof LayoutDashboard; mod: ModuleKey }[] = [
  { to: "/dashboard", label: "Global Overview", icon: LayoutDashboard, mod: "overview" },
  { to: "/dashboard/erp", label: "ERP Systeck", icon: Boxes, mod: "erp" },
  { to: "/dashboard/zigma", label: "Zigma Apps", icon: AppWindow, mod: "zigma" },
  { to: "/dashboard/infrastructure", label: "Infraestructura TI", icon: ServerCog, mod: "infrastructure" },
  { to: "/dashboard/security", label: "Seguridad Hideez", icon: ShieldCheck, mod: "security" },
  { to: "/dashboard/crm", label: "Contact & CRM", icon: Users, mod: "crm" },
  { to: "/dashboard/audit", label: "Bitácora de Auditoría", icon: ScrollText, mod: "audit" },
  { to: "/dashboard/settings", label: "Configuración", icon: Settings, mod: "settings" },
];

export function DashboardLayout({ children }: { children: ReactNode }) {
  const [open, setOpen] = useState(false);
  const pathname = useRouterState({ select: (s) => s.location.pathname });
  const perms = useStore(s => s.permissions[s.currentRole]);
  const visibleNav = NAV.filter(n => perms.includes(n.mod));
  const search = useStore(s => s.searchQuery);

  return (
    <div className="min-h-screen flex w-full bg-background text-foreground">
      <aside
        className={cn(
          "fixed z-40 inset-y-0 left-0 w-64 border-r border-sidebar-border bg-sidebar text-sidebar-foreground transition-transform lg:translate-x-0 flex flex-col",
          open ? "translate-x-0" : "-translate-x-full",
        )}
      >
        <div className="h-16 flex items-center gap-2 px-5 border-b border-sidebar-border shrink-0">
          <div className="h-9 w-9 rounded-lg bg-primary/15 grid place-items-center glow">
            <Cpu className="h-5 w-5 text-primary" />
          </div>
          <div className="min-w-0">
            <div className="font-display font-bold tracking-tight leading-none">C2Teck</div>
            <div className="text-[10px] uppercase tracking-widest text-muted-foreground">S.A.C. — Lima, PE</div>
          </div>
        </div>

        <nav className="p-3 space-y-1 overflow-y-auto flex-1">
          {visibleNav.map((item) => {
            const active = item.to === "/dashboard" ? pathname === "/dashboard" : pathname.startsWith(item.to);
            const Icon = item.icon;
            return (
              <Link
                key={item.to}
                to={item.to}
                onClick={() => setOpen(false)}
                className={cn(
                  "flex items-center gap-3 rounded-lg px-3 py-2.5 text-sm transition-colors",
                  active
                    ? "bg-primary/10 text-primary border border-primary/25"
                    : "text-sidebar-foreground/80 hover:bg-white/5 hover:text-sidebar-foreground",
                )}
              >
                <Icon className="h-4 w-4" />
                <span>{item.label}</span>
                {active && <span className="ml-auto h-1.5 w-1.5 rounded-full bg-primary shadow-[0_0_10px_var(--neon)]" />}
              </Link>
            );
          })}
        </nav>

        <div className="p-4 border-t border-sidebar-border space-y-2 shrink-0">
          <Link to="/" className="flex items-center gap-2 text-xs text-muted-foreground hover:text-primary">
            <Home className="h-3.5 w-3.5" /> Volver al sitio público
          </Link>
          <div className="rounded-lg bg-white/5 p-3 text-xs">
            <div className="flex items-center gap-2">
              <div className="h-2 w-2 rounded-full bg-success animate-pulse" />
              <span className="text-success font-medium">Todos los sistemas operativos</span>
            </div>
            <p className="mt-1 text-muted-foreground">Uptime 99.98% · ParkView™ AI activo</p>
          </div>
        </div>
      </aside>

      {open && <div className="fixed inset-0 bg-black/60 z-30 lg:hidden" onClick={() => setOpen(false)} />}

      <div className="flex-1 flex flex-col lg:ml-64 min-w-0">
        <header className="sticky top-0 z-20 h-16 border-b border-border bg-background/80 backdrop-blur flex items-center gap-3 px-4 lg:px-6">
          <button className="lg:hidden p-2 rounded-md hover:bg-accent" onClick={() => setOpen((v) => !v)} aria-label="Toggle menu">
            {open ? <X className="h-5 w-5" /> : <Menu className="h-5 w-5" />}
          </button>

          <TenantSwitcher />
          <RoleSwitcher />

          <div className="relative flex-1 max-w-sm hidden md:block">
            <Search className="absolute left-3 top-1/2 -translate-y-1/2 h-4 w-4 text-muted-foreground" />
            <input
              value={search}
              onChange={(e) => actions.setSearch(e.target.value)}
              placeholder="Buscar en la vista actual..."
              className="w-full h-9 rounded-md bg-muted pl-9 pr-3 text-sm outline-none focus:ring-2 focus:ring-ring border border-transparent focus:border-border"
            />
          </div>
          <div className="ml-auto flex items-center gap-2">
            <NotificationsBell />
            <ProfileMenu />
          </div>
        </header>
        <div className="md:hidden border-b border-border bg-background/80 px-3 py-2">
          <div className="relative">
            <Search className="absolute left-3 top-1/2 -translate-y-1/2 h-4 w-4 text-muted-foreground" />
            <input
              value={search}
              onChange={(e) => actions.setSearch(e.target.value)}
              placeholder="Buscar..."
              className="w-full h-9 rounded-md bg-muted pl-9 pr-3 text-sm outline-none focus:ring-2 focus:ring-ring border border-transparent focus:border-border"
            />
          </div>
        </div>
        <main className="flex-1 p-3 sm:p-4 lg:p-6 min-w-0 overflow-x-hidden">{children}</main>
      </div>
    </div>
  );
}

function TenantSwitcher() {
  const [open, setOpen] = useState(false);
  const tenants = useStore(s => s.tenants);
  const tid = useStore(s => s.currentTenantId);
  const t = tenants.find(x => x.id === tid)!;
  return (
    <div className="relative">
      <button onClick={() => setOpen(v => !v)} className="inline-flex items-center gap-2 rounded-md border border-primary/30 bg-primary/5 px-3 py-1.5 text-xs hover:bg-primary/10">
        <Building2 className="h-3.5 w-3.5 text-primary" />
        <span className="hidden sm:inline max-w-[140px] truncate">{t.name}</span>
        <ChevronDown className="h-3 w-3 text-muted-foreground" />
      </button>
      {open && (
        <>
          <div className="fixed inset-0 z-30" onClick={() => setOpen(false)} />
          <div className="absolute z-40 mt-2 w-72 rounded-lg border border-border bg-popover shadow-xl overflow-hidden">
            <div className="px-3 py-2 border-b border-border">
              <p className="text-[10px] uppercase tracking-widest text-muted-foreground">Cambiar tenant (aislamiento total)</p>
            </div>
            {tenants.map(x => (
              <button key={x.id} onClick={() => {
                actions.setTenant(x.id); setOpen(false);
                toast.success("Tenant conmutado", { description: `${x.name} · datos aislados cargados` });
              }} className={cn("w-full text-left px-3 py-2.5 hover:bg-accent flex items-start gap-2", x.id === tid && "bg-primary/5")}>
                <Building2 className="h-4 w-4 text-primary mt-0.5" />
                <div className="min-w-0">
                  <p className="text-sm font-medium truncate">{x.name}</p>
                  <p className="text-[10px] text-muted-foreground font-mono">RUC {x.ruc} · {x.industry}</p>
                </div>
              </button>
            ))}
          </div>
        </>
      )}
    </div>
  );
}

function RoleSwitcher() {
  const [open, setOpen] = useState(false);
  const role = useStore(s => s.currentRole);
  const ROLES: Role[] = ["admin", "contador", "cajero", "soporte"];
  return (
    <div className="relative">
      <button onClick={() => setOpen(v => !v)} className="inline-flex items-center gap-2 rounded-md border border-border bg-muted px-3 py-1.5 text-xs hover:bg-accent">
        <UserCog className="h-3.5 w-3.5 text-success" />
        <span className="hidden sm:inline max-w-[160px] truncate">{ROLE_LABEL[role]}</span>
        <ChevronDown className="h-3 w-3 text-muted-foreground" />
      </button>
      {open && (
        <>
          <div className="fixed inset-0 z-30" onClick={() => setOpen(false)} />
          <div className="absolute z-40 mt-2 w-64 rounded-lg border border-border bg-popover shadow-xl overflow-hidden">
            <div className="px-3 py-2 border-b border-border">
              <p className="text-[10px] uppercase tracking-widest text-muted-foreground">Perfil de acceso</p>
            </div>
            {ROLES.map(r => (
              <button key={r} onClick={() => {
                actions.setRole(r); setOpen(false);
                toast.success("Perfil activo", { description: `${ROLE_LABEL[r]} · menú actualizado` });
              }} className={cn("w-full text-left px-3 py-2 hover:bg-accent text-sm", r === role && "bg-primary/5 text-primary")}>
                {ROLE_LABEL[r]}
              </button>
            ))}
          </div>
        </>
      )}
    </div>
  );
}

function NotificationsBell() {
  const [open, setOpen] = useState(false);
  const audit = useStore(s => s.auditLog);
  const tickets = useStore(s => s.infraTickets);
  const readAt = useStore(s => s.notificationsReadAt);
  const items = [
    ...tickets.map(t => ({ id: t.id, ts: t.createdAt, title: `[${t.severity.toUpperCase()}] ${t.issue}`, sub: `${t.server} · ${t.status}` })),
    ...audit.slice(0, 12).map(a => ({ id: a.id, ts: a.ts, title: a.action, sub: `${a.user} · ${a.module}` })),
  ].sort((a, b) => b.ts.localeCompare(a.ts)).slice(0, 20);
  const unread = items.filter(i => i.ts > readAt).length;

  return (
    <div className="relative">
      <button onClick={() => setOpen(v => !v)} className="relative p-2 rounded-md hover:bg-accent" aria-label="Notificaciones">
        <Bell className="h-5 w-5" />
        {unread > 0 && (
          <span className="absolute top-0.5 right-0.5 min-w-[16px] h-4 px-1 rounded-full bg-primary text-[9px] font-bold text-primary-foreground grid place-items-center shadow-[0_0_8px_var(--neon)]">
            {unread}
          </span>
        )}
      </button>
      {open && (
        <>
          <div className="fixed inset-0 z-30" onClick={() => setOpen(false)} />
          <div className="absolute right-0 z-40 mt-2 w-96 rounded-lg border border-border bg-popover shadow-2xl overflow-hidden">
            <div className="px-3 py-2 border-b border-border flex items-center justify-between">
              <p className="text-xs font-semibold">Notificaciones · {items.length}</p>
              <button onClick={() => { actions.markNotificationsRead(); toast.success("Notificaciones marcadas como leídas"); }}
                className="inline-flex items-center gap-1 text-[10px] text-primary hover:underline">
                <CheckCheck className="h-3 w-3" /> Marcar todas como leídas
              </button>
            </div>
            <div className="max-h-96 overflow-y-auto">
              {items.length === 0 && <p className="p-4 text-xs text-muted-foreground">Sin notificaciones</p>}
              {items.map(i => (
                <div key={i.id} className={cn("px-3 py-2.5 border-b border-border/60 hover:bg-accent/40", i.ts > readAt && "bg-primary/5")}>
                  <p className="text-xs font-medium truncate">{i.title}</p>
                  <p className="text-[10px] text-muted-foreground truncate">{i.sub}</p>
                  <p className="text-[10px] text-muted-foreground font-mono mt-0.5">{i.ts}</p>
                </div>
              ))}
            </div>
          </div>
        </>
      )}
    </div>
  );
}

function ProfileMenu() {
  const [open, setOpen] = useState(false);
  const navigate = useNavigate();
  const role = useStore(s => s.currentRole);
  const tenants = useStore(s => s.tenants);
  const tid = useStore(s => s.currentTenantId);
  const tenant = tenants.find(t => t.id === tid)!;
  return (
    <div className="relative">
      <button onClick={() => setOpen(v => !v)} className="h-8 w-8 rounded-full bg-gradient-to-br from-primary to-success grid place-items-center text-xs font-bold text-primary-foreground hover:ring-2 hover:ring-primary/40">
        CR
      </button>
      {open && (
        <>
          <div className="fixed inset-0 z-30" onClick={() => setOpen(false)} />
          <div className="absolute right-0 z-40 mt-2 w-72 rounded-lg border border-border bg-popover shadow-2xl overflow-hidden">
            <div className="px-4 py-3 border-b border-border bg-gradient-to-br from-primary/10 to-success/5">
              <p className="text-sm font-semibold">Carlos Ríos</p>
              <p className="text-[11px] text-muted-foreground">carlos.rios@c2teck.com.pe</p>
              <p className="text-[10px] text-success mt-1">{ROLE_LABEL[role]}</p>
            </div>
            <div className="px-4 py-2 border-b border-border">
              <p className="text-[10px] uppercase tracking-widest text-muted-foreground flex items-center gap-1.5"><Building2 className="h-3 w-3" /> Tenant activo</p>
              <p className="text-xs font-medium truncate mt-0.5">{tenant.name}</p>
              <p className="text-[10px] text-muted-foreground font-mono">RUC {tenant.ruc}</p>
            </div>
            <div className="py-1">
              <MenuItem icon={User} label="Mi perfil" onClick={() => { setOpen(false); toast("Perfil de usuario", { description: "Panel de perfil en desarrollo" }); }} />
              <MenuItem icon={Settings} label="Configuración" onClick={() => { setOpen(false); navigate({ to: "/dashboard/settings" }); }} />
              <MenuItem icon={KeyRound} label="Gestionar Hideez Keys" onClick={() => { setOpen(false); navigate({ to: "/dashboard/security" }); }} />
              <div className="my-1 border-t border-border" />
              <MenuItem icon={LogOut} label="Cerrar sesión" danger onClick={() => {
                setOpen(false);
                toast.success("Sesión cerrada", { description: "Redirigiendo al portal público…" });
                setTimeout(() => navigate({ to: "/" }), 400);
              }} />
            </div>
          </div>
        </>
      )}
    </div>
  );
}

function MenuItem({ icon: Icon, label, onClick, danger }: { icon: typeof User; label: string; onClick: () => void; danger?: boolean }) {
  return (
    <button onClick={onClick} className={cn(
      "w-full flex items-center gap-2 px-4 py-2 text-xs hover:bg-accent",
      danger && "text-destructive hover:bg-destructive/10",
    )}>
      <Icon className="h-3.5 w-3.5" /> {label}
    </button>
  );
}
