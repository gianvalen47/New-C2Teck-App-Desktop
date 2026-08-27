// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Play } from "lucide-react";
import {
  btnPrimary,
  WindowShell
} from "@/components/ui/desktop-primitives";
import { Notas } from "@/features/escritorio/windows/Ventas/Documentos/Notas";

export function AcercaList() {
  return (
    <WindowShell title="Acerca de Systeck ERP Pro">
      <div className="max-w-lg mx-auto mt-4 p-5 border border-slate-300 rounded bg-slate-50 space-y-2 text-[12px]">
        <div className="font-display text-2xl font-bold text-[#2A3F55]">Systeck ERP Pro</div>
        <div className="text-slate-600">Versión <b>10.6.3.0</b></div>
        <div className="text-slate-600">Build: 2026.07.08</div>
        <hr className="my-2" />
        <div className="font-semibold text-slate-700">Notas del último parche</div>
        <ul className="list-disc pl-5 text-slate-600 space-y-0.5">
          <li>Nuevo panel de sesiones activas con cierre remoto.</li>
          <li>Mejoras en cálculo de quinta categoría.</li>
          <li>Integración con relojes biométricos de sedes remotas.</li>
        </ul>
        <hr className="my-2" />
        <div className="text-[10.5px] text-slate-500">© 2026 C2TECK S.A.C. — Todos los derechos reservados.</div>
        <div className="pt-2">
          <button
            className={btnPrimary}
            onClick={() => window.dispatchEvent(new Event("systeck-run-desktop-smoke"))}
          >
            <Play className="h-3.5 w-3.5" />Ejecutar recorrido E2E desktop
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
