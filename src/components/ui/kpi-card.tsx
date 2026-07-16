import type { LucideIcon } from "lucide-react";
import { cn } from "@/lib/utils";

export function KpiCard({
  label,
  value,
  delta,
  icon: Icon,
  accent = "primary",
}: {
  label: string;
  value: string;
  delta?: string;
  icon: LucideIcon;
  accent?: "primary" | "success" | "warning" | "destructive";
}) {
  const ring = {
    primary: "text-primary bg-primary/10 border-primary/25",
    success: "text-success bg-success/10 border-success/25",
    warning: "text-warning bg-warning/10 border-warning/25",
    destructive: "text-destructive bg-destructive/10 border-destructive/25",
  }[accent];
  return (
    <div className="card-elevated p-5 relative overflow-hidden">
      <div className="absolute -right-6 -top-6 h-24 w-24 rounded-full blur-2xl opacity-30 bg-primary" />
      <div className="flex items-start justify-between">
        <div>
          <p className="text-xs uppercase tracking-widest text-muted-foreground">{label}</p>
          <p className="mt-2 text-3xl font-display font-bold">{value}</p>
          {delta && <p className={cn("mt-1 text-xs", accent === "success" ? "text-success" : "text-muted-foreground")}>{delta}</p>}
        </div>
        <div className={cn("h-10 w-10 rounded-lg border grid place-items-center", ring)}>
          <Icon className="h-5 w-5" />
        </div>
      </div>
    </div>
  );
}
