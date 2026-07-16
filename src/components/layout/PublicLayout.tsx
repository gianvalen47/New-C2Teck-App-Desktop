import { type ReactNode, useState } from "react";
import { Link, useRouterState } from "@tanstack/react-router";
import { Cpu, ShieldCheck, Menu, X, ArrowUpRight } from "lucide-react";
import { cn } from "@/lib/utils";

const NAV = [
  { to: "/", label: "Inicio" },
  { to: "/nosotros", label: "Nosotros" },
  { to: "/productos", label: "Productos" },
  { to: "/portal", label: "Consulta SUNAT" },
  { to: "/contacto", label: "Contacto" },
] as const;


export function PublicLayout({ children }: { children: ReactNode }) {
  const pathname = useRouterState({ select: (s) => s.location.pathname });
  const [open, setOpen] = useState(false);
  return (
    <div className="min-h-screen flex flex-col bg-background text-foreground">
      <header className="sticky top-0 z-40 border-b border-border/60 bg-background/80 backdrop-blur-xl">
        <div className="mx-auto max-w-7xl px-4 lg:px-8 h-16 flex items-center justify-between gap-4">
          <Link to="/" className="flex items-center gap-2.5 group">
            <div className="h-9 w-9 rounded-lg bg-primary/15 grid place-items-center glow group-hover:bg-primary/25 transition">
              <Cpu className="h-5 w-5 text-primary" />
            </div>
            <div className="leading-none">
              <div className="font-display font-bold tracking-tight text-lg">C2Teck<span className="text-primary">.</span></div>
              <div className="text-[9px] uppercase tracking-[0.2em] text-muted-foreground">S.A.C · Lima, PE</div>
            </div>
          </Link>

          <nav className="hidden md:flex items-center gap-1">
            {NAV.map((n) => {
              const active = n.to === "/" ? pathname === "/" : pathname.startsWith(n.to);
              return (
                <Link
                  key={n.to}
                  to={n.to}
                  className={cn(
                    "px-3.5 py-2 rounded-md text-sm font-medium transition",
                    active ? "text-primary" : "text-muted-foreground hover:text-foreground",
                  )}
                >
                  {n.label}
                </Link>
              );
            })}
          </nav>

          <div className="flex items-center gap-2">
            <Link
              to="/login"
              title="Acceso administradores"
              className="hidden sm:inline-flex items-center gap-2 h-9 px-3 rounded-md border border-primary/40 text-primary hover:bg-primary/10 text-xs font-semibold uppercase tracking-wider"
            >
              <ShieldCheck className="h-4 w-4" />
              Admin
            </Link>
            <Link
              to="/contacto"
              className="hidden sm:inline-flex items-center gap-1.5 h-9 px-4 rounded-md bg-primary text-primary-foreground text-sm font-semibold hover:opacity-90"
            >
              Empezar <ArrowUpRight className="h-4 w-4" />
            </Link>
            <button className="md:hidden p-2 rounded-md hover:bg-accent" onClick={() => setOpen((v) => !v)}>
              {open ? <X className="h-5 w-5" /> : <Menu className="h-5 w-5" />}
            </button>
          </div>
        </div>
        {open && (
          <div className="md:hidden border-t border-border bg-background">
            <div className="px-4 py-3 flex flex-col gap-1">
              {NAV.map((n) => (
                <Link key={n.to} to={n.to} onClick={() => setOpen(false)} className="px-3 py-2 rounded-md hover:bg-accent text-sm">
                  {n.label}
                </Link>
              ))}
              <Link to="/login" onClick={() => setOpen(false)} className="px-3 py-2 rounded-md text-primary text-sm flex items-center gap-2">
                <ShieldCheck className="h-4 w-4" /> Acceso administradores
              </Link>
            </div>
          </div>
        )}
      </header>

      <main className="flex-1">{children}</main>

      <footer className="border-t border-border/60 bg-sidebar/40">
        <div className="mx-auto max-w-7xl px-4 lg:px-8 py-10 grid gap-8 md:grid-cols-4 text-sm">
          <div>
            <div className="flex items-center gap-2">
              <div className="h-8 w-8 rounded-lg bg-primary/15 grid place-items-center"><Cpu className="h-4 w-4 text-primary" /></div>
              <span className="font-display font-bold">C2Teck<span className="text-primary">.</span></span>
            </div>
            <p className="mt-3 text-muted-foreground text-xs leading-relaxed">Tu aliado en transformación digital y soluciones industriales. Fundada en 2021 · Lima, Perú.</p>
          </div>
          <div>
            <p className="text-xs uppercase tracking-widest text-muted-foreground mb-3">Productos</p>
            <ul className="space-y-2">
              <li><Link to="/productos" className="hover:text-primary">ERP Systeck</Link></li>
              <li><Link to="/productos" className="hover:text-primary">Zigma Apps</Link></li>
              <li><Link to="/productos" className="hover:text-primary">ParkView™ TI</Link></li>
              <li><Link to="/productos" className="hover:text-primary">Hideez FIDO2</Link></li>
            </ul>
          </div>
          <div>
            <p className="text-xs uppercase tracking-widest text-muted-foreground mb-3">Compañía</p>
            <ul className="space-y-2">
              <li><Link to="/nosotros" className="hover:text-primary">Nosotros</Link></li>
              <li><Link to="/contacto" className="hover:text-primary">Contacto</Link></li>
              <li><Link to="/portal" className="hover:text-primary">Portal Consulta SUNAT</Link></li>
            </ul>
          </div>
          <div>
            <p className="text-xs uppercase tracking-widest text-muted-foreground mb-3">Sede administrativa</p>
            <p className="text-muted-foreground text-xs leading-relaxed">
              Calle Antonio Ulloa # 2182<br />
              San Martín de Porres, Lima<br />
              crios@c2teck.com.pe
            </p>
          </div>
        </div>
        <div className="border-t border-border/60 py-4 text-center text-xs text-muted-foreground">
          © {new Date().getFullYear()} C2Teck S.A.C. — Todos los derechos reservados.
        </div>
      </footer>
    </div>
  );
}
