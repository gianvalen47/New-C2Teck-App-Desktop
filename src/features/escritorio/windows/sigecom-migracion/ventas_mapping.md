# Mapeo — Ventas (migración desde SIGECOM)

Objetivo: listar las vistas/ventanas de `src/features/escritorio/windows/Ventas` y enlazar cada una con la(s) imagen(es) de referencia en `SIGECOM/SIGECOM/doc_images/` para luego generar stubs React/TSX.

Archivos detectados (principalmente en subcarpetas `Reportes`, `Registro`, `Precios`, `Requisiciones`):

- Requisiciones
  - `src/features/escritorio/windows/Ventas/Requisiciones/Despacho.tsx`

- Reportes
  - `src/features/escritorio/windows/Ventas/Reportes/ValeRequisicion.tsx`
  - `src/features/escritorio/windows/Ventas/Reportes/RegistroDeVenta.tsx`
  - `src/features/escritorio/windows/Ventas/Reportes/Reclamos.tsx`
  - `src/features/escritorio/windows/Ventas/Reportes/PresupuestoVenta.tsx`
  - `src/features/escritorio/windows/Ventas/Reportes/OrdenesCompra.tsx`
  - `src/features/escritorio/windows/Ventas/Reportes/MensualesXCliente.tsx`
  - `src/features/escritorio/windows/Ventas/Reportes/GuiasRemision.tsx`
  - `src/features/escritorio/windows/Ventas/Reportes/GRPendiente.tsx`
  - `src/features/escritorio/windows/Ventas/Reportes/DetalleDescuento.tsx`
  - `src/features/escritorio/windows/Ventas/Reportes/Detalle.tsx`
  - `src/features/escritorio/windows/Ventas/Reportes/Cotizaciones.tsx`
  - `src/features/escritorio/windows/Ventas/Reportes/Consignaciones.tsx`
  - `src/features/escritorio/windows/Ventas/Reportes/Comisiones.tsx`
  - `src/features/escritorio/windows/Ventas/Reportes/Acumulada.tsx`

- Registro
  - `src/features/escritorio/windows/Ventas/Registro/ResumenRegistro.tsx`
  - `src/features/escritorio/windows/Ventas/Registro/RegistroVenta.tsx`
  - `src/features/escritorio/windows/Ventas/Registro/RegistroAuxiliar.tsx`

- Precios
  - `src/features/escritorio/windows/Ventas/Precios/PreciosCliente.tsx`
  - `src/features/escritorio/windows/Ventas/Precios/PrecioOferta.tsx`

Otros (buscar y revisar si existen):
- Formularios de creación/edición, listados, filtros y modales asociados a cada vista.

Guía de uso de `doc_images`:
- Ruta: `SIGECOM/SIGECOM/doc_images/` contiene numerosas capturas (`image1.png`...)
- Para cada componente, abrir las imágenes relevantes y pegarlas en `src/assets/sigecom-doc/ventas/` o referenciarlas directamente desde `SIGECOM/.../doc_images` durante la etapa de diseño.

Propuesta inmediata (pasos próximos):
1. Para cada archivo listado, crearé un stub en `src/features/escritorio/windows/sigecom-migracion/ventas/` con estructura mínima (título, contenedor, props de ejemplo) y añadiré comentario con la(s) imagen(es) de referencia sugeridas.
2. Empezaré por `Reportes/Cotizaciones.tsx` y `Registro/RegistroVenta.tsx` (prioridad: flujo de ventas y cotizaciones).
3. Te avisaré con los stubs creados y ejemplos de uso.

Indica si quieres que: `1) Cree todos los stubs ahora`, `2) Cree solo los stubs de Cotizaciones y RegistroVenta`, o `3) Otro orden`.
