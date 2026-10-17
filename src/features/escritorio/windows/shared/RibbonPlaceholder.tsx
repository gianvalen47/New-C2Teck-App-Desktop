export function RibbonPlaceholder({ label }: { label: string }) {
  return (
    <div className="flex h-full min-h-56 items-center justify-center bg-slate-50 p-6">
      <section className="w-full max-w-lg rounded-lg border border-slate-200 bg-white p-6 text-center shadow-sm">
        <h2 className="text-lg font-semibold text-slate-800">{label}</h2>
        <p className="mt-2 text-sm text-slate-500">Este módulo está en construcción.</p>
      </section>
    </div>
  );
}
