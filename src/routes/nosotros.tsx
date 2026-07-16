import { createFileRoute } from "@tanstack/react-router";
import { Target, Eye, BadgeCheck, Users, Award, Rocket } from "lucide-react";
import { PublicLayout } from "@/components/layout/PublicLayout";

export const Route = createFileRoute("/nosotros")({
  head: () => ({
    meta: [
      { title: "Nosotros — C2Teck S.A.C." },
      { name: "description", content: "Empresa peruana fundada en 2021, con un equipo especializado y más de 25 años de experiencia en desarrollo de software empresarial." },
      { property: "og:title", content: "Nosotros — C2Teck" },
      { property: "og:url", content: "/nosotros" },
    ],
    links: [{ rel: "canonical", href: "/nosotros" }],
  }),
  component: NosotrosPage,
});

function NosotrosPage() {
  return (
    <PublicLayout>
      <section className="mx-auto max-w-7xl px-4 lg:px-8 py-16 lg:py-24">
        <div className="max-w-3xl">
          <p className="text-xs uppercase tracking-widest text-primary">Nosotros</p>
          <h1 className="mt-3 font-display text-4xl lg:text-5xl font-bold">Un equipo joven con 25+ años de experiencia acumulada.</h1>
          <p className="mt-6 text-lg text-muted-foreground leading-relaxed">
            C2Teck es una empresa peruana fundada en <span className="text-foreground font-medium">2021</span>, especializada en el desarrollo de software para todo tipo de empresas. Tenemos el compromiso de atender y satisfacer a nuestros clientes, para lo cual contamos con un selecto grupo de profesionales especializados y con una experiencia de más de 25 años.
          </p>
        </div>

        <div className="mt-12 grid md:grid-cols-3 gap-4">
          {[
            { icon: Target, title: "Misión", body: "Ofrecer servicios de calidad para la satisfacción de nuestros clientes con base al respeto de las normas y principios de sostenibilidad empresarial." },
            { icon: Eye, title: "Visión", body: "Ser una empresa líder, consolidada y reconocida a nivel nacional, a través del mejoramiento y capacitación de nuestro personal para buscar el desarrollo de procesos productivos idóneos para beneficio de nuestros clientes." },
            { icon: BadgeCheck, title: "Política de Calidad", body: "En C2Teck estamos comprometidos a entregar productos que satisfagan los requerimientos técnicos y plazos de entrega de nuestros clientes." },
          ].map((c) => (
            <div key={c.title} className="card-elevated p-6">
              <div className="h-10 w-10 rounded-lg bg-primary/15 grid place-items-center text-primary"><c.icon className="h-5 w-5" /></div>
              <h3 className="mt-4 font-display font-semibold text-lg">{c.title}</h3>
              <p className="mt-2 text-sm text-muted-foreground leading-relaxed">{c.body}</p>
            </div>
          ))}
        </div>

        <div className="mt-16 grid md:grid-cols-3 gap-6">
          {[
            { icon: Users, k: "40+", v: "profesionales certificados" },
            { icon: Award, k: "1,284", v: "empresas activas usando el ecosistema" },
            { icon: Rocket, k: "24/7", v: "soporte y monitoreo ParkView™" },
          ].map((s) => (
            <div key={s.v} className="rounded-xl border border-border p-6 bg-card/40">
              <s.icon className="h-6 w-6 text-primary" />
              <div className="mt-3 font-display text-3xl font-bold">{s.k}</div>
              <p className="text-sm text-muted-foreground mt-1">{s.v}</p>
            </div>
          ))}
        </div>
      </section>
    </PublicLayout>
  );
}
