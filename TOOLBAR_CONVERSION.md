# Conversión de Barras de Herramientas de SIGECOM a React

Este documento explica cómo se han convertido las barras de herramientas de los formularios Windows Forms de SIGECOM a componentes React/TypeScript.

## Archivos Creados

### 1. `src/components/ui/toolbar.tsx`
Componente React reutilizable que renderiza una barra de herramientas con botones agrupados.

**Características:**
- Organiza botones en grupos con separadores visuales
- Soporte para iconos personalizados (lucide-react)
- Tooltips en hover
- Estados disabled
- Callback de eventos para cada botón

**Uso básico:**
```tsx
import { Toolbar, type ToolbarButton } from '@/components/ui/toolbar'

const buttons: ToolbarButton[] = [
  {
    id: 'save',
    label: 'Guardar',
    tooltip: 'Guardar documento',
    icon: <Save className="w-full h-full" />,
    group: 'edicion',
    onClick: () => console.log('Guardando...')
  }
]

<Toolbar buttons={buttons} onButtonClick={(id) => console.log(id)} />
```

### 2. `src/lib/toolbar-config.ts`
Archivo de configuración que contiene los botones para cada módulo de Ventas.

**Configuraciones incluidas:**
- `guiasRemisionToolbarButtons` - Buttons para Guías de Remisión
- `guiasDevolucionToolbarButtons` - Buttons para Guías de Devolución
- `boletasToolbarButtons` - Buttons para Boletas
- `facturasToolbarButtons` - Buttons para Facturas

**Estructura de cada botón:**
```typescript
{
  id: 'imprimir',              // Identificador único
  label: 'Imprimir',            // Texto a mostrar en el botón
  tooltip: 'Imprimir Guía',    // Tooltip en hover
  icon: <Printer />,           // Icono de lucide-react
  group: 'impresion',          // Grupo para agrupar botones
  onClick?: () => void,        // Callback opcional
  disabled?: boolean,          // Estado disabled
  visible?: boolean            // Controla visibilidad
}
```

### 3. Archivos de Páginas Actualizadas

#### `src/modules/Ventas/pages/guias.tsx`
- Integra la toolbar de guías de remisión
- Maneja clicks en los botones
- Ejemplo de implementación completa

#### `src/modules/Ventas/pages/boletas.tsx`
- Integra la toolbar de boletas
- Similar a guias.tsx pero con botones específicos de boletas

#### `src/modules/Ventas/pages/facturas.tsx`
- Integra la toolbar de facturas
- Similar a guias.tsx pero con botones específicos de facturas

## Conversión de SIGECOM

Los botones originales de SIGECOM fueron convertidos de la siguiente forma:

### Ejemplo: De VB.NET a React

**Código Original (VB.NET):**
```vb
'biImprimir
Me.biImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
Me.biImprimir.Name = "biImprimir"
Me.biImprimir.Size = New System.Drawing.Size(28, 28)
Me.biImprimir.Text = "Imprimir Guía"

'biTicket
Me.biTicket.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.biTicket.Image = Global.SIGECOM.My.Resources.Resources.Ticket
Me.biTicket.Name = "biTicket"
Me.biTicket.Size = New System.Drawing.Size(28, 28)
Me.biTicket.Text = "Imprimir Ticket"
```

**Código Convertido (TypeScript):**
```typescript
{
  id: 'imprimir',
  label: 'Imprimir',
  tooltip: 'Imprimir Guía',
  icon: <Printer className="w-full h-full" />,
  group: 'impresion',
}

{
  id: 'ticket',
  label: 'Ticket',
  tooltip: 'Imprimir Ticket',
  icon: <TicketIcon className="w-full h-full" />,
  group: 'impresion',
}
```

## Mapeo de Iconos

Se utilizó la librería `lucide-react` para reemplazar los iconos de SIGECOM:

| Icono SIGECOM | Lucide Icon | Uso |
|---|---|---|
| Impresora | `Printer` | Imprimir documentos |
| Ticket | `TicketIcon` | Imprimir tickets |
| Pagos/Enviar | `Send` | Enviar a otros módulos |
| Generar | `Zap` | Generar facturas/boletas |
| Trasladar | `Truck` | Trasladar documentos |
| Nuevo | `Plus` | Crear nuevos registros |
| Mostrar | `Eye` | Ver/Mostrar registros |
| Eliminar | `Trash2` | Eliminar registros |
| Anular | `Ban` | Anular registros |
| Sugerir | `Lightbulb` | Sugerir precios/factores |
| Herramientas | `Wrench` | Herramientas/Consumo |
| Búsqueda/Estados | `Search` | Buscar/Ver estados |
| Bajar Nivel | `TrendingDown` | Cambios de estado |
| Actualizar | `RefreshCw` | Refrescar datos |
| Email | `Mail` | Enviar por correo |
| Archivo OK | `FileCheck` | Generar archivo |
| Archivo X | `FileX` | Anular archivo |
| Descargar | `Download` | Descargar archivo |
| Lista | `ListChecks` | Listar registros |
| Salir | `LogOut` | Cerrar/Salir |

## Cómo Extender a Otros Módulos

### Paso 1: Crear configuración de botones

En `src/lib/toolbar-config.ts`, agrega una nueva configuración:

```typescript
export const nuevoModuloToolbarButtons: ToolbarButton[] = [
  {
    id: 'accion1',
    label: 'Acción 1',
    tooltip: 'Descripción de la acción',
    icon: <FileText className="w-full h-full" />,
    group: 'grupo1',
  },
  // ... más botones
]
```

### Paso 2: Importar en la página

```tsx
import { nuevoModuloToolbarButtons } from '@/lib/toolbar-config'

export default function NuevoModuloPage() {
  const [toolbarButtons] = useState<ToolbarButton[]>(nuevoModuloToolbarButtons)

  const handleToolbarButtonClick = (buttonId: string) => {
    switch (buttonId) {
      case 'accion1':
        console.log('Ejecutando acción 1...')
        break
      // ... más casos
    }
  }

  return (
    <div>
      <Toolbar 
        buttons={toolbarButtons} 
        onButtonClick={handleToolbarButtonClick}
      />
      {/* Resto de contenido */}
    </div>
  )
}
```

### Paso 3: Implementar la lógica

En el manejador de clicks, implementa la lógica específica para cada botón.

## Grupos de Botones Estándar

Para mantener consistencia, se usan estos grupos:

- **impresion** - Imprimir, Ticket
- **envios** - Enviar, Generar, Trasladar
- **gestion** - Nuevo, Mostrar, Eliminar, Anular
- **operaciones** - Sugerir, Estados, Actualizar, Email
- **electronico** - Generar/Descargar electrónico
- **control** - Salir

Los botones en el mismo grupo se muestran juntos con separadores visuales entre grupos.

## Características Disponibles

### 1. Tooltips
Cada botón muestra un tooltip al pasar el mouse:
```tsx
{
  tooltip: 'Descripción que aparece en hover'
}
```

### 2. Estados
- `disabled: true` - Desactiva el botón
- `visible: false` - Oculta el botón

### 3. Callbacks
```tsx
const handleClick = (buttonId: string) => {
  // Manejar click
}

<Toolbar 
  buttons={buttons}
  onButtonClick={handleClick}
/>
```

### 4. Grupos
Los botones se organizan automáticamente por grupo con separadores:
```tsx
{
  id: 'btn1',
  group: 'grupo1',  // Se agrupa con otros botones de 'grupo1'
}
```

## Testing

Abre la consola del navegador (F12) y haz clic en los botones para ver los eventos de log que indican qué botón fue presionado.

## Notas de Implementación

- El componente Toolbar usa Tailwind CSS para estilos
- Los iconos usan tamaño completo dentro del botón
- Los grupos se separan automáticamente con líneas verticales
- El componente es completamente reutilizable en cualquier página

## Próximos Pasos

Para implementar funcionalidad real:

1. Conectar con la API backend
2. Agregar diálogos/modales para confirmaciones
3. Implementar validaciones antes de acciones
4. Agregar toasts/notificaciones
5. Manejar errores y estados de carga
6. Persistir datos
