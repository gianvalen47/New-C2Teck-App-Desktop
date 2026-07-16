# C2Teck Systeck — Aplicación de Escritorio Empresarial

Aplicación de escritorio nativa (Electron) del ERP **Systeck** de C2Teck S.A.C.
Incluye backend FastAPI local, base de datos SQLite y la interfaz React completa
con ventanas MDI, cintas de opciones y módulos empresariales.

## Requisitos

- **Node.js** 18 o superior
- **Python** 3.10+ (en Windows: `py` desde Microsoft Store o python.org)
- **npm**

## Instalación (primera vez)

Desde la raíz del proyecto:

```bash
npm run desktop:setup
```

Esto instala dependencias Node, Electron, crea el entorno virtual Python,
instala FastAPI/SQLAlchemy y carga datos de prueba en la base de datos.

## Ejecutar la aplicación

```bash
npm run desktop
```

La aplicación:
1. Inicia el backend API en `http://127.0.0.1:8000`
2. Inicia el frontend React en `http://127.0.0.1:5173`
3. Abre la ventana de escritorio en `/escritorio` (modo pantalla completa)

## Generar ejecutable Windows (.exe)

```bash
# 1. Compilar frontend
npm run build

# 2. Empaquetar con Electron
npm run desktop:build
```

El ejecutable se genera en `electron/dist/C2Teck-Systeck-win32-x64/`.

## Configuración avanzada

| Variable | Descripción |
|----------|-------------|
| `C2TECK_URL` | URL externa (modo standalone, sin servicios locales) |
| `C2TECK_BACKEND_PORT` | Puerto del API (default: 8000) |
| `C2TECK_FRONTEND_PORT` | Puerto del frontend (default: 5173) |
| `C2TECK_PYTHON` | Ruta al ejecutable Python |
| `C2TECK_DESKTOP_PROD` | `1` para usar build de producción |

## Módulos disponibles

Ventas · Almacenes · Créditos · Importaciones · Costos · Gerencia ·
Servicios · Compras · Personal · Rondas · Contabilidad · Telefonía ·
CRM · Activos · Tablas · Administración · Ayuda

## Soporte

- Sitio web: https://www.c2teck.com.pe
- API docs (con backend activo): http://127.0.0.1:8000/docs
