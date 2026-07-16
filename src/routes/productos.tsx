import { createFileRoute, Link } from "@tanstack/react-router";
import { Boxes, AppWindow, ServerCog, ShieldCheck, Check, ArrowUpRight } from "lucide-react";
import { PublicLayout } from "@/components/layout/PublicLayout";

export const Route = createFileRoute("/productos")({
  head: () => ({
    meta: [
      { title: "Productos — C2Teck S.A.C." },
      { name: "description", content: "ERP Systeck, Zigma Apps, ParkView™ TI y Hideez FIDO2: catálogo completo del ecosistema C2Teck." },
      { property: "og:title", content: "Productos — C2Teck" },
      { property: "og:url", content: "/productos" },
    ],
    links: [{ rel: "canonical", href: "/productos" }],
  }),
  component: ProductosPage,
});

const PRODUCTS = [
  {
    icon: Boxes,
    name: "ERP Systeck",
    tagline: "Sistema Integrado de Gestión hecho a la medida.",
    desc: "Software ERP con todos los procesos centrales para operar una empresa: Intranet, App Android y App Desktop.",
    features: ["Ventas y CRM", "Compras e Inventarios", "Contabilidad y Costos", "Planillas y Nóminas", "Facturación Electrónica SUNAT", "Libros Electrónicos PLE"],
  },
  {
    icon: AppWindow,
    name: "Zigma Apps",
    tagline: "POS verticales por nicho de negocio.",
    desc: "Aplicaciones especializadas listas para operar en 5 verticales del mercado peruano.",
    features: ["Zigma Hoteles", "Zigma Restaurantes", "Zigma Tiendas & Minimarkets", "Zigma SPA & Barberías", "Zigma Gimnasios", "Emisión electrónica integrada"],
  },
  {
    icon: ServerCog,
    name: "ParkView™ TI",
    tagline: "Monitoreo automatizado de hardware.",
    desc: "Servicio de infraestructura TI con IA predictiva y respuesta técnica presencial en Lima.",
    features: ["97% fix rate en 1ra visita", "-31% MTTR", "Alertas predictivas AI", "Inventario de activos", "SLA por sede", "Mesa de ayuda 24/7"],
  },
  {
    icon: ShieldCheck,
    name: "Hideez FIDO2",
    tagline: "Identidad passwordless empresarial.",
    desc: "Llaves de hardware Hideez Key 3 y 4 para acceso sin contraseñas, resistente a phishing.",
    features: ["FIDO2 / WebAuthn", "Auto-lock por proximidad BLE", "OTP + NFC", "Gestión centralizada", "Compatibilidad Azure/Google/Okta", "Cumplimiento ISO 27001"],
  },
];

function ProductosPage() {
  return (
    <PublicLayout>
      <section className="mx-auto max-w-7xl px-4 lg:px-8 py-16 lg:py-20">
        <div className="max-w-2xl">
          <p className="text-xs uppercase tracking-widest text-primary">Productos</p>
          <h1 className="mt-3 font-display text-4xl lg:text-5xl font-bold">Cuatro plataformas complementarias.</h1>
          <p className="mt-5 text-muted-foreground text-lg">Registra todos tus procesos en un solo sistema, protege a tu equipo y monitorea tu infraestructura desde una sola consola.</p>
        </div>

        <div className="mt-12 space-y-6">
          {PRODUCTS.map((p, i) => (
            <div key={p.name} className="card-elevated p-6 lg:p-8 grid lg:grid-cols-[1fr_2fr] gap-8 relative overflow-hidden">
              <div className="absolute -right-20 -top-20 h-56 w-56 rounded-full bg-primary/15 blur-3xl" />
              <div className="relative">
                <div className="h-12 w-12 rounded-lg bg-primary/15 grid place-items-center text-primary"><p.icon className="h-6 w-6" /></div>
                <h2 className="mt-4 font-display text-2xl font-bold">{p.name}</h2>
                <p className="text-primary text-sm mt-1">{p.tagline}</p>
                <p className="mt-4 text-sm text-muted-foreground leading-relaxed">{p.desc}</p>
                <Link to="/contacto" className="mt-6 inline-flex items-center gap-1.5 text-sm font-semibold text-primary hover:underline">
                  Solicitar cotización <ArrowUpRight className="h-4 w-4" />
                </Link>
              </div>
              <div className="relative grid sm:grid-cols-2 gap-3 content-start">
                {p.features.map((f) => (
                  <div key={f} className="flex items-start gap-2.5 rounded-lg border border-border bg-background/40 p-3">
                    <Check className="h-4 w-4 text-success mt-0.5 shrink-0" />
                    <span className="text-sm">{f}</span>
                  </div>
                ))}
              </div>
              <div className="absolute top-4 right-4 text-[10px] font-mono text-muted-foreground/60">0{i + 1}</div>
            </div>
          ))}
        </div>
      </section>
    </PublicLayout>
  );
}
