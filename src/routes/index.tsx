import { createFileRoute, Link } from "@tanstack/react-router";
import { ArrowUpRight, Boxes, AppWindow, ServerCog, ShieldCheck, Target, Eye, BadgeCheck, Sparkles, Activity, Building2, Monitor } from "lucide-react";
import { toast } from "sonner";

function downloadDesktopApp() {
  fetch("/c2teck-desktop.zip")
    .then((res) => {
      if (!res.ok) throw new Error("No disponible");
      return res.blob();
    })
    .then((blob) => {
      const a = document.createElement("a");
      a.href = URL.createObjectURL(blob);
      a.download = "c2teck-desktop.zip";
      a.click();
      URL.revokeObjectURL(a.href);
      toast.success("Descarga iniciada", {
        description: "Descomprime y ejecuta: npm install && npm start",
      });
    })
    .catch(() => toast.error("No se pudo descargar el paquete"));
}
import { PublicLayout } from "@/components/layout/PublicLayout";

export const Route = createFileRoute("/")({
  head: () => ({
    meta: [
      { title: "C2Teck S.A.C. — Transformación digital y soluciones industriales" },
      { name: "description", content: "Ecosistema SaaS peruano: ERP Systeck, Zigma Apps, ParkView TI y Hideez FIDO2. Software a medida para empresas." },
      { property: "og:title", content: "C2Teck S.A.C." },
      { property: "og:description", content: "Tu aliado en transformación digital y soluciones industriales." },
      { property: "og:url", content: "/" },
    ],
    links: [{ rel: "canonical", href: "/" }],
  }),
  component: LandingPage,
});

function LandingPage() {
  return (
    <PublicLayout>
      {/* HERO */}
      <section className="relative overflow-hidden">
        <div className="absolute inset-0 -z-10">
          <div className="absolute -top-40 -left-32 h-[500px] w-[500px] rounded-full bg-primary/20 blur-[120px]" />
          <div className="absolute top-40 right-0 h-[400px] w-[400px] rounded-full bg-success/10 blur-[100px]" />
          <div className="absolute inset-0 bg-[linear-gradient(to_right,var(--border)_1px,transparent_1px),linear-gradient(to_bottom,var(--border)_1px,transparent_1px)] bg-[size:64px_64px] opacity-[0.15]" />
        </div>
        <div className="mx-auto max-w-7xl px-4 lg:px-8 py-20 lg:py-28 grid lg:grid-cols-2 gap-12 items-center">
          <div>
            <span className="inline-flex items-center gap-2 rounded-full border border-primary/30 bg-primary/10 px-3 py-1 text-xs font-medium text-primary">
              <Sparkles className="h-3.5 w-3.5" /> ERP · SaaS · IoT · Ciberseguridad
            </span>
            <h1 className="mt-5 font-display text-4xl sm:text-5xl lg:text-6xl font-bold tracking-tight leading-[1.05]">
              Tu aliado en <span className="text-primary">transformación digital</span> y soluciones industriales.
            </h1>
            <p className="mt-6 text-lg text-muted-foreground max-w-xl leading-relaxed">
              Consolidamos ERP, apps verticales Zigma, infraestructura TI ParkView™ y autenticación Hideez FIDO2 en una sola plataforma empresarial para el mercado peruano.
            </p>
            <div className="mt-8 flex flex-wrap gap-3">
              <Link to="/contacto" className="inline-flex items-center gap-2 h-12 px-6 rounded-md bg-primary text-primary-foreground font-semibold hover:opacity-90 shadow-[0_0_40px_-8px_var(--primary)]">
                Solicitar Demo de Sistemas <ArrowUpRight className="h-4 w-4" />
              </Link>
              <Link to="/productos" className="inline-flex items-center gap-2 h-12 px-6 rounded-md border border-border bg-card font-semibold hover:bg-accent">
                Explorar Ecosistema SaaS
              </Link>
              <Link
                to="/escritorio"
                className="inline-flex items-center gap-2 h-12 px-6 rounded-md border border-primary/40 bg-primary/10 text-primary font-semibold hover:bg-primary/20"
              >
                <Monitor className="h-4 w-4" /> Ver App de Escritorio
              </Link>
            </div>
            <div className="mt-10 grid grid-cols-3 gap-6 max-w-md">
              {[
                { k: "1,284", v: "Negocios activos" },
                { k: "99.98%", v: "Uptime ParkView™" },
                { k: "25+ años", v: "Experiencia del equipo" },
              ].map((s) => (
                <div key={s.v}>
                  <div className="font-display text-2xl font-bold text-primary">{s.k}</div>
                  <div className="text-xs text-muted-foreground mt-1">{s.v}</div>
                </div>
              ))}
            </div>
          </div>
          <div className="relative">
            <div className="card-elevated p-6 relative overflow-hidden">
              <div className="absolute -right-10 -top-10 h-40 w-40 rounded-full bg-primary/30 blur-3xl" />
              <div className="flex items-center justify-between">
                <div>
                  <p className="text-xs uppercase tracking-widest text-primary">ParkView™</p>
                  <p className="font-display font-bold text-xl">Hardware Monitoring</p>
                </div>
                <div className="flex items-center gap-1.5 text-xs text-success">
                  <span className="h-2 w-2 rounded-full bg-success animate-pulse" /> LIVE
                </div>
              </div>
              <div className="mt-6 grid grid-cols-4 gap-2">
                {Array.from({ length: 16 }).map((_, i) => {
                  const state = i % 7 === 0 ? "warn" : i % 11 === 0 ? "err" : "ok";
                  const c = state === "ok" ? "bg-success/20 border-success/40" : state === "warn" ? "bg-warning/20 border-warning/40" : "bg-destructive/20 border-destructive/40";
                  return <div key={i} className={`aspect-square rounded border ${c}`} />;
                })}
              </div>
              <div className="mt-6 space-y-2 text-xs font-mono">
                <div className="flex justify-between text-muted-foreground"><span>CPU pool</span><span className="text-success">62%</span></div>
                <div className="h-1.5 rounded-full bg-muted overflow-hidden"><div className="h-full w-[62%] bg-success" /></div>
                <div className="flex justify-between text-muted-foreground"><span>Network I/O</span><span className="text-primary">1.4 Gbps</span></div>
                <div className="h-1.5 rounded-full bg-muted overflow-hidden"><div className="h-full w-[78%] bg-primary" /></div>
                <div className="flex justify-between text-muted-foreground"><span>Incident MTTR</span><span className="text-warning">-31%</span></div>
              </div>
              <div className="mt-6 rounded-lg border border-success/30 bg-success/10 p-3 text-xs">
                <span className="text-success font-bold">97% fix rate</span> en la primera visita técnica.
              </div>
            </div>
          </div>
        </div>
      </section>

      {/* NOSOTROS QUICK */}
      <section className="border-y border-border/50 bg-sidebar/30">
        <div className="mx-auto max-w-7xl px-4 lg:px-8 py-16 grid md:grid-cols-3 gap-8">
          {[
            { icon: Target, title: "Misión", body: "Ofrecer servicios de calidad para la satisfacción de nuestros clientes con base al respeto de las normas y principios de sostenibilidad empresarial." },
            { icon: Eye, title: "Visión", body: "Ser una empresa líder, consolidada y reconocida a nivel nacional, a través del mejoramiento y capacitación de nuestro personal para el desarrollo de procesos productivos idóneos." },
            { icon: BadgeCheck, title: "Política de Calidad", body: "En C2Teck estamos comprometidos a entregar productos que satisfagan los requerimientos técnicos y plazos de entrega de nuestros clientes." },
          ].map((c) => (
            <div key={c.title} className="card-elevated p-6">
              <div className="h-10 w-10 rounded-lg bg-primary/15 grid place-items-center text-primary"><c.icon className="h-5 w-5" /></div>
              <h3 className="mt-4 font-display font-semibold text-lg">{c.title}</h3>
              <p className="mt-2 text-sm text-muted-foreground leading-relaxed">{c.body}</p>
            </div>
          ))}
        </div>
      </section>

      {/* PRODUCTOS */}
      <section className="mx-auto max-w-7xl px-4 lg:px-8 py-20">
        <div className="text-center max-w-2xl mx-auto">
          <p className="text-xs uppercase tracking-widest text-primary">Ecosistema C2Teck</p>
          <h2 className="mt-3 font-display text-3xl sm:text-4xl font-bold">Cuatro plataformas. Una sola consola.</h2>
          <p className="mt-4 text-muted-foreground">Todo lo que necesita tu empresa peruana para operar, escalar y proteger su información.</p>
        </div>
        <div className="mt-12 grid md:grid-cols-2 lg:grid-cols-4 gap-4">
          {[
            { icon: Boxes, name: "ERP Systeck", desc: "Ventas, compras, contabilidad, planillas, facturación electrónica SUNAT.", color: "from-primary/30 to-transparent" },
            { icon: AppWindow, name: "Zigma Apps", desc: "POS verticales para hoteles, restaurantes, tiendas, spa y gimnasios.", color: "from-success/30 to-transparent" },
            { icon: ServerCog, name: "ParkView™ TI", desc: "Monitoreo AI de hardware con 97% fix rate en primera visita.", color: "from-warning/30 to-transparent" },
            { icon: ShieldCheck, name: "Hideez FIDO2", desc: "Identidad passwordless y llaves de hardware para tu fuerza laboral.", color: "from-primary/30 to-transparent" },
          ].map((p) => (
            <Link key={p.name} to="/productos" className="card-elevated p-6 group relative overflow-hidden hover:border-primary/40 transition">
              <div className={`absolute -right-10 -top-10 h-32 w-32 rounded-full blur-2xl bg-gradient-to-br ${p.color}`} />
              <p.icon className="h-7 w-7 text-primary" />
              <h3 className="mt-4 font-display font-bold">{p.name}</h3>
              <p className="mt-2 text-xs text-muted-foreground leading-relaxed">{p.desc}</p>
              <div className="mt-4 text-xs text-primary flex items-center gap-1 opacity-0 group-hover:opacity-100 transition">
                Explorar <ArrowUpRight className="h-3 w-3" />
              </div>
            </Link>
          ))}
        </div>
      </section>

      {/* CTA */}
      <section className="mx-auto max-w-7xl px-4 lg:px-8 pb-20">
        <div className="relative overflow-hidden rounded-2xl border border-primary/30 bg-gradient-to-br from-primary/15 via-card to-success/10 p-10 lg:p-14 text-center">
          <div className="absolute inset-0 bg-[radial-gradient(circle_at_top,var(--primary)/20,transparent_60%)] opacity-40" />
          <div className="relative">
            <Building2 className="h-8 w-8 text-primary mx-auto" />
            <h2 className="mt-4 font-display text-3xl lg:text-4xl font-bold">Listos para digitalizar tu operación</h2>
            <p className="mt-3 text-muted-foreground max-w-xl mx-auto">Agenda una demo con nuestro equipo comercial. Implementación acompañada por ingenieros con más de 25 años de experiencia.</p>
            <div className="mt-8 flex flex-wrap gap-3 justify-center">
              <Link to="/contacto" className="inline-flex items-center gap-2 h-12 px-6 rounded-md bg-primary text-primary-foreground font-semibold hover:opacity-90">
                <Activity className="h-4 w-4" /> Solicitar Demo
              </Link>
              <Link to="/login" className="inline-flex items-center gap-2 h-12 px-6 rounded-md border border-border bg-background/50 font-semibold hover:bg-accent">
                <ShieldCheck className="h-4 w-4" /> Portal de clientes
              </Link>
            </div>
          </div>
        </div>
      </section>
    </PublicLayout>
  );
}
