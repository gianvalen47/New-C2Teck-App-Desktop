import { createFileRoute } from "@tanstack/react-router";
import { useState } from "react";
import { toast } from "sonner";
import { Mail, MapPin, Phone, Send } from "lucide-react";
import { PublicLayout } from "@/components/layout/PublicLayout";

export const Route = createFileRoute("/contacto")({
  head: () => ({
    meta: [
      { title: "Contacto — C2Teck S.A.C." },
      { name: "description", content: "Contacta a C2Teck en Lima, Perú. Sede administrativa en San Martín de Porres. Escríbenos a crios@c2teck.com.pe." },
      { property: "og:title", content: "Contacto — C2Teck" },
      { property: "og:url", content: "/contacto" },
    ],
    links: [{ rel: "canonical", href: "/contacto" }],
  }),
  component: ContactoPage,
});

function ContactoPage() {
  const [sending, setSending] = useState(false);
  return (
    <PublicLayout>
      <section className="mx-auto max-w-7xl px-4 lg:px-8 py-16 lg:py-24 grid lg:grid-cols-2 gap-12">
        <div>
          <p className="text-xs uppercase tracking-widest text-primary">Contacto</p>
          <h1 className="mt-3 font-display text-4xl lg:text-5xl font-bold">Hablemos de tu próximo proyecto.</h1>
          <p className="mt-5 text-muted-foreground">Nuestro equipo comercial responde en menos de 24 horas hábiles.</p>

          <div className="mt-10 space-y-5">
            <div className="flex gap-4">
              <div className="h-11 w-11 rounded-lg bg-primary/15 grid place-items-center text-primary"><MapPin className="h-5 w-5" /></div>
              <div>
                <p className="text-sm font-semibold">Sede administrativa</p>
                <p className="text-sm text-muted-foreground">Calle Antonio Ulloa # 2182, San Martín de Porres, Lima — Perú</p>
              </div>
            </div>
            <div className="flex gap-4">
              <div className="h-11 w-11 rounded-lg bg-primary/15 grid place-items-center text-primary"><Mail className="h-5 w-5" /></div>
              <div>
                <p className="text-sm font-semibold">Email comercial</p>
                <a href="mailto:crios@c2teck.com.pe" className="text-sm text-primary hover:underline">crios@c2teck.com.pe</a>
              </div>
            </div>
            <div className="flex gap-4">
              <div className="h-11 w-11 rounded-lg bg-primary/15 grid place-items-center text-primary"><Phone className="h-5 w-5" /></div>
              <div>
                <p className="text-sm font-semibold">Atención al cliente</p>
                <p className="text-sm text-muted-foreground">Lun – Vie · 9:00 a 18:00 (GMT-5)</p>
              </div>
            </div>
          </div>
        </div>

        <form
          onSubmit={(e) => {
            e.preventDefault();
            setSending(true);
            setTimeout(() => {
              setSending(false);
              toast.success("Mensaje enviado", { description: "El equipo de crios@c2teck.com.pe te responderá pronto." });
              (e.target as HTMLFormElement).reset();
            }, 900);
          }}
          className="card-elevated p-6 lg:p-8 space-y-4"
        >
          <div className="grid sm:grid-cols-2 gap-4">
            <label className="block">
              <span className="text-xs uppercase tracking-widest text-muted-foreground">Nombre</span>
              <input required className="mt-1 w-full h-11 rounded-md bg-muted px-3 border border-transparent focus:border-primary outline-none" />
            </label>
            <label className="block">
              <span className="text-xs uppercase tracking-widest text-muted-foreground">Empresa</span>
              <input className="mt-1 w-full h-11 rounded-md bg-muted px-3 border border-transparent focus:border-primary outline-none" />
            </label>
          </div>
          <label className="block">
            <span className="text-xs uppercase tracking-widest text-muted-foreground">Email corporativo</span>
            <input type="email" required className="mt-1 w-full h-11 rounded-md bg-muted px-3 border border-transparent focus:border-primary outline-none" />
          </label>
          <label className="block">
            <span className="text-xs uppercase tracking-widest text-muted-foreground">Producto de interés</span>
            <select className="mt-1 w-full h-11 rounded-md bg-muted px-3 border border-transparent focus:border-primary outline-none">
              <option>ERP Systeck</option>
              <option>Zigma Apps</option>
              <option>ParkView™ TI</option>
              <option>Hideez FIDO2</option>
              <option>Otro / consultoría</option>
            </select>
          </label>
          <label className="block">
            <span className="text-xs uppercase tracking-widest text-muted-foreground">Mensaje</span>
            <textarea required rows={4} className="mt-1 w-full rounded-md bg-muted px-3 py-2 border border-transparent focus:border-primary outline-none" />
          </label>
          <button
            disabled={sending}
            className="inline-flex items-center gap-2 h-11 px-5 rounded-md bg-primary text-primary-foreground font-semibold hover:opacity-90 disabled:opacity-50"
          >
            <Send className="h-4 w-4" /> {sending ? "Enviando..." : "Enviar mensaje"}
          </button>
        </form>
      </section>
    </PublicLayout>
  );
}
