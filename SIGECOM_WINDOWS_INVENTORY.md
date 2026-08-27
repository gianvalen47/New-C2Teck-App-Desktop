# Inventario: `src/features/escritorio/windows` + Guía de imágenes SIGECOM

Resumen rápido:
- Carpeta objetivo (frontend React): `src/features/escritorio/windows`
- Imágenes de referencia (SIGECOM original): `SIGECOM/SIGECOM/doc_images/` (muchas imágenes nombradas imageNN.png)

Estructura principal (categorías detectadas en `src/features/escritorio/windows`):
- Activos
- Administracion
- Almacen
- Almacenes
- Ayuda
- Compras
- Contabilidad
- Costos
- Creditos
- CRM
- Gerencia
- Importaciones
- Logueo
- Personal
- Precios
- Reportes
- Rondas
- Servicios
- shared
- Tablas
- Telefonia
- Ventas

Notas rápidas sobre `Ventas` (ejemplos de archivos TSX ya presentes):
- `src/features/escritorio/windows/Ventas/Reportes/Cotizaciones.tsx`
- `src/features/escritorio/windows/Ventas/Reportes/Detalle.tsx`
- `src/features/escritorio/windows/Ventas/Registro/RegistroVenta.tsx`
- `src/features/escritorio/windows/Ventas/Precios/PreciosCliente.tsx`
- Más archivos en subcarpetas `Reportes`, `Registro`, `Precios`, etc.

Imágenes de referencia:
- Ruta base: `SIGECOM/SIGECOM/doc_images/`
- Formato: archivos PNG con nombres como `image1.png`, `image2.png`, ...
- Hay ~260+ imágenes detectadas; muchas parecen ser capturas o diagramas de UI del SIGECOM original.

Propuesta de flujo de trabajo (específico para esta tarea):
1. Confirmas que quiero trabajar solo con las carpetas listadas en `src/features/escritorio/windows` y usar `doc_images` como guía visual.
2. Genero un mapeo inicial: por cada subcarpeta/archivo TSX importante crearé un componente React (stub) en `src/features/escritorio/windows/sigecom-migracion/` y enlazaré la(s) imagen(es) de referencia sugeridas.
3. Para cada componente stub incluiré:
   - Título y ruta sugerida
   - Imagen(es) de referencia (copiar/usar vía `assets` o referenciar desde `SIGECOM/.../doc_images`)
   - Props/estructura mínima (tabla/inputs/botones) basada en la vista original, si está claro
4. Iteraremos por prioridad (tú decides: `Ventas` primero, o toda la carpeta).

Siguiente paso sugerido (elige una):
- "Sí, iniciar mapeo completo" — crearé los stubs y sugeriré imágenes para cada uno.
- "Solo Ventas" — empezaré por `src/features/escritorio/windows/Ventas` y sus reportes/cotizaciones.
- "Priorizar X,Y" — dime las subcarpetas prioritarias.

--
Archivo generado automáticamente para acelerar la migración UI desde SIGECOM clásico hacia el proyecto React/TSX.
