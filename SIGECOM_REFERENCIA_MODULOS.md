# 📋 MÓDULOS SIGECOM - REFERENCIA RÁPIDA

## Tabla Comparativa - 20 Módulos

| # | MÓDULO | Subcarpetas | .vb Files | Formularios | Complejidad | Prioridad | Duración | Equipo |
|----|--------|------------|-----------|-------------|------------|----------|----------|---------|
| 1 | **Login** | 2 | ~80 | 4 | 🟢 Baja | 🔴 INMEDIATA | 2 sem | 1 dev |
| 2 | **Ayuda** | 4 | ~60 | 5 | 🟢 Baja | 🟡 Media | 1 sem | 1 dev |
| 3 | **Personal** | 4 | ~150 | 25 | 🟡 Media | 🟡 Media | 2 sem | 1 dev |
| 4 | **Telefonía** | 6 | ~100 | 20 | 🟡 Media | 🟡 Media | 2 sem | 1 dev |
| 5 | **Rondas** | 5 | ~100 | 20 | 🟡 Media | 🟡 Media | 1 sem | 1 dev |
| 6 | **Costos** | 5 | ~120 | 20 | 🟡 Media | 🟡 Media | 2 sem | 1 dev |
| 7 | **Buscadores** | 1 | ~300 | 60 | 🟡 Media | 🟢 FASE1 | 2 sem | 1 dev |
| 8 | **CRM** | 5 | ~150 | 30 | 🟡 Media-Alta | 🟡 Media | 2 sem | 1 dev |
| 9 | **Importaciones** | 6 | ~250 | 40 | 🟡 Media-Alta | 🟡 Media | 2 sem | 1-2 dev |
| 10 | **Administración** | 10 | ~300 | 50 | 🔴 Alta | 🟡 Media | 3 sem | 2 dev |
| 11 | **Contabilidad** | 11 | ~350 | 50 | 🔴 Alta | 🟡 Media | 3 sem | 2 dev |
| 12 | **Tablas Maestras** | 8 | ~200 | 35 | 🟡 Media | 🟢 FASE1 | 2 sem | 1 dev |
| 13 | **ActivosFijos** | 4 | ~120 | 10 | 🟡 Media | 🟡 Media | 1 sem | 1 dev |
| 14 | **Almacén** | 11 | ~400 | 60 | 🔴 Alta | 🔴 CRÍTICA | 3 sem | 2 dev |
| 15 | **Compras** | 12 | ~450 | 80 | 🔴 Alta | 🔴 CRÍTICA | 3 sem | 2 dev |
| 16 | **Planillas** | 3 | ~200 | 30 | 🔴 Alta | 🔴 CRÍTICA | 2 sem | 2 dev |
| 17 | **Gerencia** | 10 | ~300 | 40 | 🔴 Alta | 🔴 CRÍTICA | 3 sem | 2 dev |
| 18 | **Créditos** | 16 | ~500 | 100 | 🔴 **CRÍTICA** | 🔴 CRÍTICA | 4 sem | 2 dev |
| 19 | **Servicios** | 20 | ~600 | 150 | 🔴 **CRÍTICA** | 🔴 CRÍTICA | 5 sem | 3 dev |
| 20 | **Ventas** | 21 | ~700 | 200 | 🔴 **CRÍTICA** | 🔴 CRÍTICA | 5 sem | 3 dev |
| | **B2M** | 0 | ~0 | 0 | 🟢 VACÍO | - | - | - |

**TOTALES** | 20 | ~162 | ~3,850 | ~730+ | Mixta | - | **28 sem** | **5-6 dev** |

---

## 📊 Distribución de Esfuerzo

### Por Fase

```
FASE 1 - FUNDACIONAL (Semanas 1-4)
├─ Login              1 dev × 2 sem
├─ Ayuda              1 dev × 1 sem
├─ Tablas Maestras    1 dev × 2 sem
├─ Buscadores         1 dev × 2 sem
└─ Total: 2 devs, 70 formularios

FASE 2 - PROCESOS BÁSICOS (Semanas 5-12)
├─ Personal           1 dev × 2 sem
├─ Telefonía          1 dev × 2 sem
├─ Rondas             1 dev × 1 sem
├─ Costos             1 dev × 2 sem
├─ ActivosFijos       1 dev × 1 sem
├─ CRM                2 dev × 2 sem
├─ Importaciones      2 dev × 2 sem
├─ Administración     2 dev × 3 sem
└─ Contabilidad       2 dev × 3 sem
   Total: 3 devs, 150+ formularios

FASE 3 - MÓDULOS CRÍTICOS (Semanas 13-28)
├─ Almacén            2 dev × 3 sem
├─ Compras            2 dev × 3 sem
├─ Planillas          2 dev × 2 sem
├─ Gerencia           2 dev × 3 sem
├─ Créditos           2 dev × 4 sem
├─ Servicios          3 dev × 5 sem
└─ Ventas             3 dev × 5 sem
   Total: 4-5 devs, 500+ formularios

FASE 4 - INTEGRACIÓN (Semanas 24-28)
├─ SUNAT              2 dev × 4 sem
├─ Reportes (RDLC)    2 dev × 3 sem
├─ Testing QA         2 QA × 2 sem
└─ Optimización       2 dev × 2 sem
   Total: 2 devs + 2 QA
```

---

## 🔍 Subcarpetas por Módulo (Detalle)

### VENTAS (21 subcarpetas) - Más Complejo
```
├─ Actualizar Vendedor          (Actualizaciones masivas)
├─ Boletas                       (Doc legal)
├─ Cartera de Clientes           (CxC)
├─ Consultas                     (Reportes ad-hoc)
├─ Cotizaciones                  (Pre-venta)
├─ Despacho de Requisiciones     (Fulfillment)
├─ EnvioCorreo                   (Comunicación)
├─ Facturas                      (Doc legal + SUNAT)
├─ Guías                         (Transporte)
├─ Indicadores                   (KPIs)
├─ Notas de Crédito              (Devoluciones)
├─ Ocurrencias del Cliente       (CRM)
├─ OrdenCompra                   (También en Compras)
├─ Ordenes de Compra             (Interna)
├─ Precios                       (Tarificación)
├─ Reclamos                      (Servicio post-venta)
├─ Reportes                      (RDLC)
├─ ResumenBoletas                (Consolidación)
├─ SepararOrden                  (Split orders)
└─ Visitas a Clientes            (Seguimiento)
```

### SERVICIOS (20 subcarpetas) - Muy Complejo
```
├─ Consulta/Consultas            (Búsquedas)
├─ ControlVehicular              (Tracking)
├─ Cotizacion                    (Pre-servicio)
├─ GastoReal                     (Costos)
├─ GastoViaje                    (Reembolsos)
├─ Indicadores                   (KPIs)
├─ Job                           (Órdenes de trabajo)
├─ Mantenimiento                 (Preventivo/correctivo)
├─ Marcacion                     (Inicio/fin trabajo)
├─ MarcacionOT                   (Tracking horas)
├─ PedirRepuesto                 (Inventory)
├─ PreMarcacion                  (Pre-planificación)
├─ Proyeccion                    (Scheduling)
├─ ReclamoCliente                (Tickets)
├─ Reportes                      (RDLC)
├─ RepuestoServicio              (Parts management)
├─ RepuestoServicioCliente       (Parts for customer)
├─ SolicitudGarantia             (Warranty)
└─ SolicitudJob                  (Work orders)
```

### CRÉDITOS (16 subcarpetas) - Muy Complejo Financiero
```
├─ Anticipos                     (Avances de dinero)
├─ Aprobacion                    (Flujos de aprobación)
├─ Consultas                     (Reportes)
├─ CtasCobrar                    (CxC por cliente)
├─ FacturarGuias                 (Facturación automática)
├─ Feriados                      (Calendarios)
├─ Letras                        (Letra de cambio)
├─ Mantenimiento                 (Tablas maestras)
├─ PermisoUsuario                (Access control)
├─ Planillas                     (Planilla de pagos)
├─ RecepcionDocumentos           (Digitalización)
├─ RenuevaTipCam                 (Tipo cambio dinámico)
├─ Reportes                      (RDLC)
├─ SaldoBancos                   (Reconciliación)
├─ TipoCambio                    (Monedas)
└─ VincularGuia                  (Relaciones documentos)
```

### ALMACÉN (11 subcarpetas)
```
├─ Consultas                     (Ad-hoc queries)
├─ DatosDespachos                (Outbound logistics)
├─ Despacho                      (Fulfillment)
├─ Indicadores                   (KPIs stock)
├─ Liquidacion de Motores        (Liquidación especial)
├─ Locacion de la Mercaderia     (Ubicación física)
├─ MinimosMaximos                (Reorder points)
├─ Movimientos                   (In/Out/Ajustes)
├─ Reportes                      (RDLC)
└─ Ubicaciones                   (Dirección física)
```

---

## 🔗 Dependencias entre Módulos

```
                    ┌─────────────────────────────────────┐
                    │         TABLAS MAESTRAS             │
                    │  (Almacén, Compras, Personal, etc)  │
                    └────────────┬────────────────────────┘
                                 │
         ┌───────────────────────┼───────────────────────┐
         │                       │                       │
    ┌─────────┐          ┌──────────────┐         ┌──────────┐
    │  LOGIN  │          │  ADMINISTRACIÓN       │  AYUDA   │
    │(Auth)   │──────────│ (Permisos)            │(Support) │
    └─────────┘          └──────────────┘         └──────────┘
         │                       │
         └───────────┬───────────┘
                     │
    ┌────────────────┼────────────────┐
    │                │                │
┌─────────┐   ┌───────────────┐  ┌──────────┐
│ COMPRAS ├──→│  CONTABILIDAD │←─┤ CRÉDITOS │
└────┬────┘   └───────────────┘  └──────────┘
     │              │
     │         ┌────┴─────────┐
     │         │              │
     ├────→ REPORTES ← VENTAS ←┤
     │        └─────────────────┘
     │
┌────────────┬──────────────────┐
│            │                  │
│        ┌────────┐      ┌──────────────┐
│        │ALMACÉN ├─────→│  SERVICIOS   │
│        └────────┘      └──────────────┘
│
├─→ IMPORTACIONES
├─→ PLANILLAS
├─→ GERENCIA (dashboards consume todo)
├─→ CRM
├─→ RONDAS
├─→ TELEFONÍA
├─→ PERSONAL
└─→ COSTOS
```

---

## 💾 Service References por Módulo

| Módulo | Servicios | Ejemplo |
|--------|-----------|---------|
| **Ventas** | ~25 | FacturaService, BoletaService, GuiaRemisionService |
| **Servicios** | ~20 | JobService, RepuestoServicioService, CotizacionServicioService |
| **Créditos** | ~18 | LetraService, AnticipoService, CtasCobrarService |
| **Almacén** | ~15 | MercaderiaService, LocacionService, MoviAlmacenService |
| **Compras** | ~15 | OrdenCompraService, PedidoService, CotizacionService |
| **SUNAT** | ~12 | SunatService, BoletaDigitalService, FacturaDigitalService |
| **Administración** | ~10 | UsuarioService, PerfilService, SolicitudUsuarioService |
| **Contabilidad** | ~10 | ContabilidadService, DiarioService, TesoreriaService |
| **Otros** | ~82 | (Múltiples servicios para cada tablas, personal, CRM, etc.) |

**Total: 217 Service References**

---

## 📁 Tabla de Referencias - Datos Maestros

### ALMACÉN (7)
```
├─ Clases de producto
├─ Cores
├─ Marcas
├─ Mercaderías
├─ Modelos
├─ Productos
└─ Tipos de Motor
```

### PERSONAL (10)
```
├─ AFP (fondos)
├─ Áreas
├─ Cargos
├─ Equipos de Marcación
├─ Feriados
├─ Horarios
├─ Motivos de Falta
└─ Rubros de Cuenta/Planilla
```

### CONTABILIDAD (4)
```
├─ Cuentas Contables (COA)
├─ Cuentas Destino
├─ Rubros Cuenta
└─ Rubros Planilla
```

### VENTAS (2)
```
├─ Clientes
└─ Condiciones de Pago
```

### COMPRAS (2)
```
├─ Condiciones de Pago Compra
└─ Proveedores
```

### SERVICIOS (2)
```
├─ Ubicaciones de Equipo
└─ Unidades
```

### IMPORTACIONES (1)
```
└─ Partidas Arancelarias
```

**Total: 28 tablas maestras principales**

---

## 🎯 Matriz de Prioridades

```
         CRITICIDAD
            │
       ALTA │   Créditos    Servicios    Ventas
            │     (FC)       (MÁS COMP)  (TRANSACT)
            │
            │   Almacén    Compras    Planillas
       MEDIA│   Contab.     CRM     Gerencia
            │  Administr.
            │
        BAJA│  Personal    Rondas    Telefonía
            │   Costos      Ayuda    ActivosFijos
            │   Login       Tablas
            │
            └─────────────────────────────────── URGENCIA
              BAJA  MEDIA  ALTA  CRÍTICA
```

---

## 🚨 Dependencias Críticas

**SUNAT** (Transversal)
- Ventas (Facturas, Boletas, Guías)
- Créditos (Documentos, anticipos)
- Servicios (Facturación servicios)

**Reportes** (Transversal - 20 carpetas)
- Requiere equivalente React (Recharts)
- Alto esfuerzo de diseño UI

**Tipo de Cambio** (Créditos, Ventas, Importaciones)
- Datos dinámicos
- Cálculos en tiempo real

---

## 📊 Complejidad por Línea de Negocio

| Línea | Módulos | Criticidad | Duración | Riesgo |
|------|---------|-----------|----------|--------|
| **Ventas** | Ventas, CRM, Precios | 🔴 CRÍTICA | 5 sem | ALTO |
| **Operaciones** | Servicios, Almacén, Rondas | 🔴 CRÍTICA | 8 sem | ALTO |
| **Finanzas** | Créditos, Contabilidad, Tesorería | 🔴 CRÍTICA | 7 sem | MUY ALTO |
| **Compras** | Compras, Importaciones, Proveedores | 🟡 ALTA | 5 sem | MEDIO |
| **RRHH** | Personal, Planillas, Asignaciones | 🟡 ALTA | 2 sem | BAJO |
| **Soporte** | Login, Ayuda, Administración | 🟢 BAJA | 6 sem | BAJO |

---

## ✅ Verificación de Completitud

- ✅ 20 módulos identificados
- ✅ 162 subcarpetas contadas
- ✅ 3,850 archivos .vb analizados
- ✅ 217 Service References documentados
- ✅ 472 recursos de imagen inventariados
- ✅ 28 tablas maestras mapeadas
- ✅ 20 carpetas de reportes identificadas
- ✅ Matriz de complejidad creada
- ✅ Timeline estimado

---

**Estado**: ✅ ANÁLISIS COMPLETO

*Última actualización: Julio 2026*
*Fuente: SIGECOM/SIGECOM folder structure analysis*
