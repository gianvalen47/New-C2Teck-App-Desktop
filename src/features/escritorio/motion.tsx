/**
 * Sistema global de animaciones — Systeck MDI
 * Regla de los 200ms: ninguna transición de ventana supera 0.2s.
 * Wrappers ligeros sobre framer-motion, reutilizables en todo el ERP.
 */
import { motion, type Variants, type Transition } from "framer-motion";
import type { ComponentProps, ReactNode } from "react";

export const EASE_OUT: Transition = { duration: 0.18, ease: "easeOut" };
export const EASE_FAST: Transition = { duration: 0.12, ease: "easeOut" };
export const SPRING_POP: Transition = { type: "spring", stiffness: 300, damping: 25, mass: 0.6 };

/** Ventanas MDI: apertura scale-up + fade, cierre fade ultra rápido, minimizado hacia el dock. */
export const mdiWindowVariants: Variants = {
  initial: { opacity: 0, scale: 0.96 },
  animate: { opacity: 1, scale: 1, transition: EASE_OUT },
  restore: { opacity: 1, scale: 1, transition: SPRING_POP },
  exit: (kind?: string) =>
    kind === "minimize"
      ? { opacity: 0, scale: 0.6, y: 90, transition: { duration: 0.16, ease: "easeOut" } }
      : { opacity: 0, scale: 0.98, transition: EASE_FAST },
};

/** Modales y pestañas internas: slide-in desde abajo + fade. */
export const panelVariants: Variants = {
  initial: { opacity: 0, y: 10 },
  animate: { opacity: 1, y: 0, transition: EASE_OUT },
  exit: { opacity: 0, y: 6, transition: EASE_FAST },
};

/** Tooltips y popovers: aparición instantánea con escala. */
export const popVariants: Variants = {
  initial: { opacity: 0, scale: 0.95 },
  animate: { opacity: 1, scale: 1, transition: { duration: 0.12, ease: "easeOut" } },
  exit: { opacity: 0, scale: 0.97, transition: { duration: 0.1 } },
};

/** Filas de tabla: entrada escalonada. */
export const listVariants: Variants = {
  initial: {},
  animate: { transition: { staggerChildren: 0.03 } },
};
export const rowVariants: Variants = {
  initial: { opacity: 0, y: 4 },
  animate: { opacity: 1, y: 0, transition: { duration: 0.16, ease: "easeOut" } },
};

/** Contenedor de filas animadas (usar en <tbody>). */
export function MotionTBody({ children, animKey, ...rest }: { children: ReactNode; animKey?: string | number } & ComponentProps<typeof motion.tbody>) {
  return (
    <motion.tbody key={animKey} variants={listVariants} initial="initial" animate="animate" {...rest}>
      {children}
    </motion.tbody>
  );
}

export const MotionRow = (props: ComponentProps<typeof motion.tr>) => (
  <motion.tr variants={rowVariants} {...props} />
);

/** Panel animado para modales / pestañas internas. */
export function MotionPanel({ children, className, ...rest }: { children: ReactNode; className?: string } & ComponentProps<typeof motion.div>) {
  return (
    <motion.div className={className} variants={panelVariants} initial="initial" animate="animate" exit="exit" {...rest}>
      {children}
    </motion.div>
  );
}

/** Botón con micro-feedback táctil (Ribbon, toolbars). */
export function MotionButton({ children, ...rest }: ComponentProps<typeof motion.button>) {
  return (
    <motion.button whileHover={{ scale: 1.03 }} whileTap={{ scale: 0.97 }} transition={{ duration: 0.12 }} {...rest}>
      {children}
    </motion.button>
  );
}

/** Icono de acción que se eleva al pasar el cursor. */
export function MotionIconButton({ children, ...rest }: ComponentProps<typeof motion.button>) {
  return (
    <motion.button whileHover={{ y: -2, scale: 1.04 }} whileTap={{ y: 0, scale: 0.97 }} transition={{ duration: 0.12 }} {...rest}>
      {children}
    </motion.button>
  );
}

/** Icono giratorio para estados de carga / sincronización. */
export function Spinner({ children, spinning = true }: { children: ReactNode; spinning?: boolean }) {
  return (
    <motion.span
      className="inline-flex"
      animate={spinning ? { rotate: 360 } : { rotate: 0 }}
      transition={spinning ? { repeat: Infinity, ease: "linear", duration: 0.9 } : { duration: 0.15 }}
    >
      {children}
    </motion.span>
  );
}

/** Badge / semáforo crítico con pulso brillante continuo. */
export function GlowPulse({ children, className = "", active = true }: { children: ReactNode; className?: string; active?: boolean }) {
  return (
    <motion.span
      className={className}
      animate={active ? { opacity: [1, 0.62, 1], scale: [1, 1.03, 1] } : { opacity: 1, scale: 1 }}
      transition={active ? { repeat: Infinity, duration: 1.5, ease: "easeInOut" } : { duration: 0.15 }}
    >
      {children}
    </motion.span>
  );
}

export { motion, AnimatePresence } from "framer-motion";
