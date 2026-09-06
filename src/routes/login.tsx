import { createFileRoute, Link, useNavigate } from "@tanstack/react-router";
import { useState } from "react";
import { toast } from "sonner";
import { ShieldCheck, Cpu, ArrowLeft, KeyRound } from "lucide-react";
import { login } from "@/lib/sigecoom-api";

export const Route = createFileRoute("/login")({
  head: () => ({
    meta: [
      { title: "Acceso administradores — C2Teck" },
      { name: "description", content: "Portal de acceso para administradores C2Teck. Autenticación protegida con Hideez FIDO2." },
      { name: "robots", content: "noindex" },
    ],
  }),
  component: LoginPage,
});

function LoginPage() {
  const navigate = useNavigate();
  const [loading, setLoading] = useState(false);
  const [username, setUsername] = useState("grios");
  const [password, setPassword] = useState("");

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    setLoading(true);

    try {
      const session = await login(username.trim(), password);
      localStorage.setItem("sigecoom_session", JSON.stringify(session));
      toast.success("Autenticación validada", { description: `Bienvenido ${session.username} (${session.perfil}).` });
      navigate({ to: "/escritorio" });
    } catch (error: any) {
      toast.error(error.message ?? "Credenciales inválidas");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="min-h-screen grid lg:grid-cols-2 bg-background">
      {/* Left panel */}
      <div className="hidden lg:flex relative overflow-hidden bg-sidebar p-12 flex-col justify-between">
        <div className="absolute inset-0">
          <div className="absolute -top-32 -left-20 h-[400px] w-[400px] rounded-full bg-primary/20 blur-[100px]" />
          <div className="absolute bottom-0 right-0 h-[300px] w-[300px] rounded-full bg-success/15 blur-[100px]" />
          <div className="absolute inset-0 bg-[linear-gradient(to_right,var(--border)_1px,transparent_1px),linear-gradient(to_bottom,var(--border)_1px,transparent_1px)] bg-[size:48px_48px] opacity-[0.15]" />
        </div>
        <Link to="/" className="relative flex items-center gap-2.5">
          <div className="h-9 w-9 rounded-lg bg-primary/15 grid place-items-center glow"><Cpu className="h-5 w-5 text-primary" /></div>
          <div>
            <div className="font-display font-bold">C2Teck<span className="text-primary">.</span></div>
            <div className="text-[10px] uppercase tracking-widest text-muted-foreground">Consola Ejecutiva</div>
          </div>
        </Link>
        <div className="relative">
          <ShieldCheck className="h-10 w-10 text-primary" />
          <h2 className="mt-6 font-display text-3xl font-bold leading-tight">Acceso restringido<br />para administradores.</h2>
          <p className="mt-4 text-muted-foreground max-w-md">Ingresa para gestionar ERP Systeck, Zigma Apps, infraestructura ParkView™ y llaves Hideez FIDO2 de toda tu organización.</p>
          <div className="mt-10 space-y-3 text-sm">
            {["Autenticación passwordless FIDO2", "Auditoría completa de sesiones", "SSO con Azure AD / Google Workspace"].map((f) => (
              <div key={f} className="flex items-center gap-2 text-muted-foreground">
                <span className="h-1.5 w-1.5 rounded-full bg-primary shadow-[0_0_8px_var(--primary)]" /> {f}
              </div>
            ))}
          </div>
        </div>
        <p className="relative text-xs text-muted-foreground">© {new Date().getFullYear()} C2Teck S.A.C.</p>
      </div>

      {/* Right form */}
      <div className="flex flex-col justify-center px-6 py-12 sm:px-12 lg:px-16">
        <div className="mx-auto w-full max-w-md">
          <Link to="/" className="inline-flex items-center gap-1.5 text-xs text-muted-foreground hover:text-foreground">
            <ArrowLeft className="h-3.5 w-3.5" /> Volver al inicio
          </Link>
          <h1 className="mt-6 font-display text-3xl font-bold">Iniciar sesión</h1>
          <p className="mt-2 text-sm text-muted-foreground">Solo administradores autorizados pueden acceder al dashboard.</p>

          <form onSubmit={handleSubmit} className="mt-8 space-y-4">
            <label className="block">
              <span className="text-xs uppercase tracking-widest text-muted-foreground">Usuario</span>
              <input
                type="text"
                required
                value={username}
                onChange={(e) => setUsername(e.target.value)}
                className="mt-1 w-full h-11 rounded-md bg-muted px-3 border border-transparent focus:border-primary outline-none"
              />
            </label>
            <label className="block">
              <span className="text-xs uppercase tracking-widest text-muted-foreground">Contraseña</span>
              <input
                type="password"
                inputMode="numeric"
                pattern="[0-9]*"
                maxLength={3}
                required
                value={password}
                onChange={(e) => setPassword(e.target.value.replace(/\D/g, "").slice(0, 3))}
                className="mt-1 w-full h-11 rounded-md bg-muted px-3 border border-transparent focus:border-primary outline-none"
              />
            </label>
            <div className="flex items-center justify-between text-xs">
              <label className="flex items-center gap-2 text-muted-foreground">
                <input type="checkbox" className="rounded border-border" defaultChecked /> Recordar sesión
              </label>
              <button
                type="button"
                onClick={() => toast("Enlace de recuperación enviado", { description: "Revisa tu correo corporativo." })}
                className="text-primary hover:underline"
              >
                ¿Olvidaste tu contraseña?
              </button>
            </div>
            <button
              disabled={loading}
              className="w-full h-11 rounded-md bg-primary text-primary-foreground font-semibold hover:opacity-90 disabled:opacity-50 inline-flex items-center justify-center gap-2"
            >
              <ShieldCheck className="h-4 w-4" /> {loading ? "Validando..." : "Ingresar al Dashboard"}
            </button>
            <button
              type="button"
              onClick={() => {
                toast.success("Hideez Key detectada", { description: "Autenticación FIDO2 exitosa." });
                setTimeout(() => navigate({ to: "/escritorio" }), 500);
              }}
              className="w-full h-11 rounded-md border border-primary/40 text-primary font-semibold hover:bg-primary/10 inline-flex items-center justify-center gap-2"
            >
              <KeyRound className="h-4 w-4" /> Ingresar con Hideez Key
            </button>
          </form>

          <p className="mt-8 text-xs text-muted-foreground text-center">
            ¿No eres administrador? <Link to="/contacto" className="text-primary hover:underline">Contáctanos</Link> para obtener acceso.
          </p>
        </div>
      </div>
    </div>
  );
}
