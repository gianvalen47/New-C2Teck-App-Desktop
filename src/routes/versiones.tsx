import { createFileRoute } from "@tanstack/react-router";
import versionHtml from "@/assets/Debug/version/version.html?raw";
import versionStyles from "@/assets/Debug/version/styles.css?raw";

const versionPage = versionHtml.replace(
  '<link rel="stylesheet" href="styles.css">',
  `<style>${versionStyles}</style>`,
);

export const Route = createFileRoute("/versiones")({
  head: () => ({
    meta: [{ title: "Historial de versiones — SIGECOM" }],
  }),
  component: VersionHistoryPage,
});

function VersionHistoryPage() {
  return (
    <iframe
      title="Historial de versiones de SIGECOM"
      srcDoc={versionPage}
      className="fixed inset-0 h-screen w-screen border-0"
      referrerPolicy="no-referrer"
    />
  );
}
