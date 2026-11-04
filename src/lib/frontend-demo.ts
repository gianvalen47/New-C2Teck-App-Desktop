import type { SessionInfo } from "@/lib/sigecoom-api";

export const FRONTEND_DEMO_MODE_KEY = "systeck_frontend_demo";

const SESSION_STORAGE_KEY = "sigecoom_session";

export function isFrontendDemoMode(): boolean {
  return typeof window !== "undefined"
    && window.localStorage.getItem(FRONTEND_DEMO_MODE_KEY) === "true";
}

export function createFrontendDemoSession(): SessionInfo {
  return {
    username: "Invitado",
    perfil: "Vista previa",
    fecha_transaccion: new Date().toLocaleDateString("es-PE"),
    tipo_cambio_compra: 0,
    tipo_cambio_venta: 0,
    empresa_actual: null,
    empresas: [],
  };
}

export function enableFrontendDemoMode(): void {
  const demoSession = createFrontendDemoSession();
  window.localStorage.removeItem(SESSION_STORAGE_KEY);
  window.localStorage.setItem(SESSION_STORAGE_KEY, JSON.stringify(demoSession));
  window.localStorage.setItem(FRONTEND_DEMO_MODE_KEY, "true");
}

export function clearFrontendDemoMode(): void {
  if (!isFrontendDemoMode()) return;
  window.localStorage.removeItem(FRONTEND_DEMO_MODE_KEY);
  window.localStorage.removeItem(SESSION_STORAGE_KEY);
}
