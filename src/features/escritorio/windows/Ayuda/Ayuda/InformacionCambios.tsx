import { useEffect, useRef } from "react";
import { WindowShell } from "@/components/ui/desktop-primitives";
import versionHtml from "@/assets/Debug/version/version.html?raw";
import versionStyles from "@/assets/Debug/version/styles.css?raw";

export function InfoCambios() {
  const navigationStarted = useRef(false);

  useEffect(() => {
    if (navigationStarted.current) return;
    navigationStarted.current = true;

    const html = versionHtml.replace(
      '<link rel="stylesheet" href="styles.css">',
      `<style>${versionStyles}</style>`,
    );
    const pageUrl = URL.createObjectURL(
      new Blob([html], { type: "text/html" }),
    );
    window.location.replace(pageUrl);
  }, []);

  return (
    <WindowShell title="Información de Cambios">
      <p className="p-4 text-sm text-slate-600">Abriendo el historial de versiones…</p>
    </WindowShell>
  );
}
