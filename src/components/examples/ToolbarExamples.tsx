/**
 * EJEMPLOS DE USO DEL COMPONENTE TOOLBAR
 * 
 * Este archivo muestra cómo integrar la barra de herramientas
 * convertida de SIGECOM en diferentes páginas de React.
 */

import { useState } from 'react'
import { Button } from '@/components/ui/button'
import { Toolbar, type ToolbarButton } from '@/components/ui/toolbar'
import { 
  guiasRemisionToolbarButtons, 
  guiasDevolucionToolbarButtons,
  boletasToolbarButtons,
  facturasToolbarButtons
} from '@/lib/toolbar-config'

// ============================================================================
// EJEMPLO 1: Uso básico con botones de Guías de Remisión
// ============================================================================

export function GuiasRemisionExample() {
  const [toolbarButtons] = useState<ToolbarButton[]>(guiasRemisionToolbarButtons)

  const handleToolbarButtonClick = (buttonId: string) => {
    console.log('Botón clickeado:', buttonId)
    // Implementar lógica específica por botón
  }

  return (
    <div>
      <Toolbar 
        buttons={toolbarButtons} 
        onButtonClick={handleToolbarButtonClick}
        className="sticky top-0 z-10"
      />
      <div className="p-4">
        {/* Contenido de la página */}
      </div>
    </div>
  )
}

// ============================================================================
// EJEMPLO 2: Con botones personalizados
// ============================================================================

import { 
  Printer, 
  Plus, 
  Trash2, 
  Save,
  Settings
} from 'lucide-react'

export function CustomToolbarExample() {
  const customButtons: ToolbarButton[] = [
    {
      id: 'guardar',
      label: 'Guardar',
      tooltip: 'Guardar cambios',
      icon: <Save className="w-full h-full" />,
      group: 'edicion',
    },
    {
      id: 'crear',
      label: 'Crear',
      tooltip: 'Crear nuevo registro',
      icon: <Plus className="w-full h-full" />,
      group: 'edicion',
    },
    {
      id: 'eliminar',
      label: 'Eliminar',
      tooltip: 'Eliminar registro',
      icon: <Trash2 className="w-full h-full" />,
      group: 'operaciones',
      disabled: true, // Ejemplo de botón deshabilitado
    },
    {
      id: 'configurar',
      label: 'Configurar',
      tooltip: 'Configuración',
      icon: <Settings className="w-full h-full" />,
      group: 'otros',
    },
  ]

  const handleClick = (buttonId: string) => {
    switch (buttonId) {
      case 'guardar':
        console.log('Guardando...')
        break
      case 'crear':
        console.log('Creando nuevo...')
        break
      case 'configurar':
        console.log('Abriendo configuración...')
        break
    }
  }

  return <Toolbar buttons={customButtons} onButtonClick={handleClick} />
}

// ============================================================================
// EJEMPLO 3: Con estado reactivo
// ============================================================================

export function DynamicToolbarExample() {
  const [isEditing, setIsEditing] = useState(false)
  const [hasSelection, setHasSelection] = useState(false)

  // Copiar los botones y modificar estados según el contexto
  const dynamicButtons = guiasRemisionToolbarButtons.map((btn) => ({
    ...btn,
    // Deshabilitar botones de edición si no estamos en modo edición
    disabled: (btn.group === 'edicion' && !isEditing) || 
              (btn.id === 'eliminar' && !hasSelection),
  }))

  const handleToolbarClick = (buttonId: string) => {
    console.log('Acción:', buttonId)
  }

  return (
    <div>
      <Toolbar buttons={dynamicButtons} onButtonClick={handleToolbarClick} />
      <div className="p-4 space-y-4">
        <Button onClick={() => setIsEditing(!isEditing)}>
          {isEditing ? 'Terminar edición' : 'Editar'}
        </Button>
        <Button onClick={() => setHasSelection(!hasSelection)}>
          {hasSelection ? 'Deseleccionar' : 'Seleccionar'}
        </Button>
      </div>
    </div>
  )
}

// ============================================================================
// EJEMPLO 4: Con múltiples configuraciones
// ============================================================================

export function MultipleConfigExample() {
  const [activeModule, setActiveModule] = useState<'guias' | 'boletas' | 'facturas'>('guias')

  const moduleConfigs = {
    guias: guiasRemisionToolbarButtons,
    boletas: boletasToolbarButtons,
    facturas: facturasToolbarButtons,
  }

  const handleClick = (buttonId: string) => {
    console.log(`[${activeModule}] Button clicked:`, buttonId)
  }

  return (
    <div>
      <div className="mb-4 flex gap-2">
        <Button 
          variant={activeModule === 'guias' ? 'default' : 'outline'}
          onClick={() => setActiveModule('guias')}
        >
          Guías
        </Button>
        <Button 
          variant={activeModule === 'boletas' ? 'default' : 'outline'}
          onClick={() => setActiveModule('boletas')}
        >
          Boletas
        </Button>
        <Button 
          variant={activeModule === 'facturas' ? 'default' : 'outline'}
          onClick={() => setActiveModule('facturas')}
        >
          Facturas
        </Button>
      </div>
      
      <Toolbar 
        buttons={moduleConfigs[activeModule]} 
        onButtonClick={handleClick}
      />
      
      <div className="p-4">
        <p>Módulo activo: <strong>{activeModule}</strong></p>
      </div>
    </div>
  )
}

// ============================================================================
// EJEMPLO 5: Toolbar con filtros
// ============================================================================

export function FilterToolbarExample() {
  const [filters, setFilters] = useState({
    showPrint: true,
    showDelete: true,
    showEmail: false,
  })

  const filteredButtons = guiasRemisionToolbarButtons.filter((btn) => {
    if (btn.id === 'imprimir' || btn.id === 'ticket') return filters.showPrint
    if (btn.id === 'eliminar' || btn.id === 'anular') return filters.showDelete
    if (btn.id === 'enviarCorreo') return filters.showEmail
    return true
  })

  const handleClick = (buttonId: string) => {
    console.log('Button:', buttonId)
  }

  return (
    <div>
      <div className="mb-4 flex gap-4">
        <label className="flex items-center gap-2">
          <input 
            type="checkbox" 
            checked={filters.showPrint}
            onChange={(e) => setFilters({...filters, showPrint: e.target.checked})}
          />
          Mostrar Impresión
        </label>
        <label className="flex items-center gap-2">
          <input 
            type="checkbox" 
            checked={filters.showDelete}
            onChange={(e) => setFilters({...filters, showDelete: e.target.checked})}
          />
          Mostrar Eliminación
        </label>
        <label className="flex items-center gap-2">
          <input 
            type="checkbox" 
            checked={filters.showEmail}
            onChange={(e) => setFilters({...filters, showEmail: e.target.checked})}
          />
          Mostrar Email
        </label>
      </div>

      <Toolbar buttons={filteredButtons} onButtonClick={handleClick} />
    </div>
  )
}

// ============================================================================
// EJEMPLO 6: Crear nueva configuración basada en existente
// ============================================================================

export function CustomConfigExample() {
  // Crear una configuración personalizada basada en guías de remisión
  const customConfig: ToolbarButton[] = guiasRemisionToolbarButtons
    .filter(btn => ['imprimir', 'ticket', 'nuevo', 'mostrar', 'eliminar', 'salir'].includes(btn.id))
    .map(btn => ({
      ...btn,
      // Personalizar algunos botones
      visible: btn.id === 'salir' ? false : true,
    }))

  const handleClick = (buttonId: string) => {
    console.log('Simplified toolbar action:', buttonId)
  }

  return <Toolbar buttons={customConfig} onButtonClick={handleClick} />
}

// ============================================================================
// NOTAS DE IMPLEMENTACIÓN
// ============================================================================

/*
CARACTERÍSTICAS PRINCIPALES DEL COMPONENTE TOOLBAR:

1. ORGANIZACIÓN POR GRUPOS
   - Los botones se organizan automáticamente en grupos
   - Cada grupo se separa visualmente con líneas verticales
   - Permite una interfaz más organizada y profesional

2. ICONOS REUTILIZABLES
   - Usa lucide-react para iconos consistentes
   - Los iconos se adaptan al tamaño del botón
   - Fácil de cambiar o personalizar

3. ESTADOS DE BOTONES
   - visible: true/false - Controla visibilidad
   - disabled: true/false - Desactiva la interacción
   - onClick: callback personalizado para cada botón
   - También se ejecuta el callback onButtonClick de Toolbar

4. FLEXIBILIDAD
   - Se puede usar con cualquier configuración de botones
   - Fácil de filtrar, modificar o agregar botones dinámicamente
   - Compatible con React hooks como useState

5. RESPONSIVIDAD
   - Se adapta a diferentes tamaños de pantalla
   - Los botones mantienen su tamaño mínimo
   - El texto se envuelve si es necesario

CASOS DE USO:
- Modificar visibilidad de botones según permisos del usuario
- Deshabilitar botones según estado de datos
- Cambiar configuración dinámicamente
- Crear múltiples toolbars con diferentes botones
- Filtrar botones según contexto
*/
