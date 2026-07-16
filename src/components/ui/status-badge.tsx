import { cn } from "@/lib/utils";

const map: Record<string, string> = {
  Aceptado: "bg-success/15 text-success border-success/30",
  Pendiente: "bg-warning/15 text-warning border-warning/30",
  Rechazado: "bg-destructive/15 text-destructive border-destructive/30",
  Activo: "bg-success/15 text-success border-success/30",
  Vacaciones: "bg-warning/15 text-warning border-warning/30",
  "En Ruta": "bg-primary/15 text-primary border-primary/30",
  Inactivo: "bg-muted text-muted-foreground border-border",
  OK: "bg-success/15 text-success border-success/30",
  Alerta: "bg-warning/15 text-warning border-warning/30",
  Crítica: "bg-destructive/15 text-destructive border-destructive/30",
  Alta: "bg-destructive/15 text-destructive border-destructive/30",
  Media: "bg-warning/15 text-warning border-warning/30",
  Baja: "bg-muted text-muted-foreground border-border",
  Completada: "bg-success/15 text-success border-success/30",
  "En Proceso": "bg-primary/15 text-primary border-primary/30",
  Programada: "bg-muted text-muted-foreground border-border",
  Asignado: "bg-primary/15 text-primary border-primary/30",
  Cerrado: "bg-success/15 text-success border-success/30",
  Nuevo: "bg-primary/15 text-primary border-primary/30",
  "Demo Agendada": "bg-warning/15 text-warning border-warning/30",
  Propuesta: "bg-primary/15 text-primary border-primary/30",
  Negociación: "bg-success/15 text-success border-success/30",
};

export function StatusBadge({ status }: { status: string }) {
  return (
    <span className={cn("inline-flex items-center gap-1.5 rounded-full border px-2.5 py-0.5 text-[11px] font-medium",
      map[status] || "bg-muted text-muted-foreground border-border")}>
      <span className="h-1.5 w-1.5 rounded-full bg-current" />
      {status}
    </span>
  );
}
