# Mapeo inicial: SIGECOM (Interfaces) → `src/features/escritorio/windows`

Objetivo: relacionar las carpetas y vistas del SIGECOM original con los archivos y carpetas del frontend React existente, para guiar la migración completa.

Instrucciones: este es un mapeo de alto nivel. Puedo desglosar por archivo (cada .vb/.resx/.xml → componente TSX) si confirmas.

--

**Resumen de mapeo (carpetas principales)**

- `SIGECOM/SIGECOM/Interfaces/Ventas` → `src/features/escritorio/windows/Ventas` (coincidencias: `Reportes`, `Registro`, `Precios`, `Documentos`, `Consultas`, `Clientes`, etc.)
- `SIGECOM/SIGECOM/Interfaces/Compras` → `src/features/escritorio/windows/Compras` (coincidencias: `Reportes`, `Compras`, `Control`, `Consultas`)
- `SIGECOM/SIGECOM/Interfaces/Almacen` / `Tablas/Almacen` → `src/features/escritorio/windows/Almacenes` y `src/features/escritorio/windows/Tablas/Almacenes`
- `SIGECOM/SIGECOM/Interfaces/Tablas` → `src/features/escritorio/windows/Tablas` (subcarpetas: `Personal`, `Compras`, `Almacenes`, `Contabilidad`, `Rondas`, `Servicios`)
- `SIGECOM/SIGECOM/Interfaces/Planillas` → `src/features/escritorio/windows/Personal` (reportes y planillas bajo `Personal/Reportes` y `Personal/Planilla Sueldos`)
- `SIGECOM/SIGECOM/Interfaces/Personal` → `src/features/escritorio/windows/Personal` (información, asignaciones, reportes)
- `SIGECOM/SIGECOM/Interfaces/Gerencia` → `src/features/escritorio/windows/Gerencia` (reportes e indicadores)
- `SIGECOM/SIGECOM/Interfaces/Contabilidad` → `src/features/escritorio/windows/Contabilidad` (tesorería, procesos, reportes)
- `SIGECOM/SIGECOM/Interfaces/Costos` → `src/features/escritorio/windows/Costos` (reportes, procesos)
- `SIGECOM/SIGECOM/Interfaces/Créditos` → `src/features/escritorio/windows/Creditos` (reportes, mantenimiento, documentos)
- `SIGECOM/SIGECOM/Interfaces/CRM` → `src/features/escritorio/windows/CRM` (oportunidades, visitas, reportes)
- `SIGECOM/SIGECOM/Interfaces/Servicios` → `src/features/escritorio/windows/Servicios` (OT, garantías, reportes, proyecciones)
- `SIGECOM/SIGECOM/Interfaces/Rondas` → `src/features/escritorio/windows/Rondas` (rutas, puntos, asignaciones)
- `SIGECOM/SIGECOM/Interfaces/Administracion` → `src/features/escritorio/windows/Administracion` (usuarios, seguridad, tablas generales)
- `SIGECOM/SIGECOM/Interfaces/Ayuda` → `src/features/escritorio/windows/Ayuda` (AdminSistemas / indicadores → `Administracion/Reportes/Indicadores` o `Ayuda`)
- `SIGECOM/SIGECOM/Interfaces/Telefonia` → `src/features/escritorio/windows/Telefonia` (mantenimiento, asignación)
- `SIGECOM/SIGECOM/Interfaces/Activos` → `src/features/escritorio/windows/Activos` (activos fijos, reportes)
- `SIGECOM/SIGECOM/Interfaces/Importaciones` → `src/features/escritorio/windows/Importaciones` (reportes, pedidos, embarques)

**Estado de cobertura detectado**
- Coincidencias directas encontradas: Ventas, Compras, Almacenes, Tablas, Planillas/Personal, Gerencia, Contabilidad, Costos, Créditos, CRM, Servicios, Rondas, Administracion, Ayuda, Telefonia, Activos, Importaciones.
- Elementos faltantes / sin equivalente directo: algunas utilerías internas, muchos `frm*.vb` específicos (formularios con nombres diferentes); por eso recomendamos un mapeo por archivo para asegurar correspondencia precisa.

**Siguiente paso (recomendado y opcional)**
1. Generar mapeo detallado por archivo solo para una categoría (ej.: `Ventas`) — salida: tabla `SIGECOM_path -> suggested React path (existing|create stub)` y lista de imágenes de referencia de `SIGECOM/SIGECOM/doc_images`.
2. Repetir para cada carpeta priorizada.

Hecho: inventario global y mapeo de carpetas. Dime si quieres que genere ahora el mapeo por archivo para `Ventas` (recomendado) o para todo el proyecto de una vez (esto puede tardar más y generar muchos archivos).
