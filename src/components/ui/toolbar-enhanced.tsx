import React from 'react'
import { cn } from '@/lib/utils'

interface ToolbarButtonWithIcon {
  id: string
  label: string
  tooltip?: string
  icon: React.ReactNode
  onClick?: () => void
  disabled?: boolean
  visible?: boolean
  group?: string
}

interface ToolbarEnhancedProps {
  buttons: ToolbarButtonWithIcon[]
  className?: string
  onButtonClick?: (buttonId: string) => void
  showLabels?: boolean
  iconSize?: 'sm' | 'md' | 'lg'
}

const iconSizeMap = {
  sm: 'w-5 h-5',
  md: 'w-6 h-6',
  lg: 'w-8 h-8',
}

const buttonSizeMap = {
  sm: 'h-8 w-8',
  md: 'h-10 w-10',
  lg: 'h-12 w-12',
}

/**
 * Toolbar mejorado con mejor visualización de iconos
 * Diseño similar a SIGECOM
 */
export function ToolbarEnhanced({
  buttons,
  className,
  onButtonClick,
  showLabels = false,
  iconSize = 'md',
}: ToolbarEnhancedProps) {
  const visibleButtons = buttons.filter((btn) => btn.visible !== false)
  const groups = new Map<string | undefined, ToolbarButtonWithIcon[]>()

  // Group buttons
  visibleButtons.forEach((btn) => {
    const groupKey = btn.group || 'default'
    if (!groups.has(groupKey)) {
      groups.set(groupKey, [])
    }
    groups.get(groupKey)!.push(btn)
  })

  const iconClass = iconSizeMap[iconSize]
  const buttonClass = buttonSizeMap[iconSize]

  return (
    <div
      className={cn(
        'flex items-center gap-0.5 bg-gradient-to-b from-slate-50 via-slate-100 to-slate-90 border-b-2 border-slate-300 px-1 py-1 flex-wrap shadow-md',
        'rounded-b-sm',
        className
      )}
    >
      {Array.from(groups.entries()).map(([groupKey, groupButtons], index) => (
        <React.Fragment key={groupKey || 'default'}>
          {index > 0 && (
            <div className="w-px h-9 bg-gradient-to-b from-slate-300 to-slate-400 mx-1 opacity-60" />
          )}

          <div className="flex items-center gap-0">
            {groupButtons.map((btn) => (
              <div key={btn.id} className="relative group">
                <button
                  disabled={btn.disabled}
                  onClick={() => {
                    btn.onClick?.()
                    onButtonClick?.(btn.id)
                  }}
                  className={cn(
                    'flex flex-col items-center justify-center transition-all duration-150 rounded-sm',
                    'border border-slate-300 bg-gradient-to-b from-slate-50 to-slate-100',
                    buttonClass,
                    'hover:from-slate-100 hover:to-slate-150 hover:border-slate-400 hover:shadow-sm',
                    'active:from-slate-150 active:to-slate-200 active:shadow-inner active:border-slate-500',
                    'disabled:opacity-40 disabled:cursor-not-allowed disabled:hover:border-slate-300 disabled:hover:shadow-none disabled:hover:from-slate-50 disabled:hover:to-slate-100',
                    'focus:outline-none focus:ring-1 focus:ring-offset-1 focus:ring-blue-400'
                  )}
                  title={btn.tooltip || btn.label}
                >
                  {/* Icono */}
                  <div
                    className={cn(
                      'flex items-center justify-center text-slate-700 flex-shrink-0 transition-colors duration-150',
                      'group-hover:text-slate-900 group-disabled:text-slate-400',
                      iconClass
                    )}
                  >
                    {btn.icon}
                  </div>

                  {/* Etiqueta opcional debajo del icono */}
                  {showLabels && (
                    <span className="text-xs font-medium text-slate-600 mt-0.5 leading-tight max-w-[35px] text-center truncate">
                      {btn.label}
                    </span>
                  )}
                </button>

                {/* Tooltip mejorado */}
                <div
                  className={cn(
                    'absolute bottom-full left-1/2 transform -translate-x-1/2 mb-2 px-2.5 py-1.5',
                    'bg-slate-900 text-white text-xs rounded-md font-medium',
                    'opacity-0 group-hover:opacity-100 transition-opacity duration-300 pointer-events-none z-[100]',
                    'shadow-lg border border-slate-800',
                    'whitespace-nowrap'
                  )}
                >
                  <div>{btn.label}</div>
                  {btn.tooltip && (
                    <div className="text-slate-300 text-xs font-normal">{btn.tooltip}</div>
                  )}
                  {/* Punta del tooltip */}
                  <div className="absolute top-full left-1/2 transform -translate-x-1/2 w-0 h-0 border-l-3 border-r-3 border-t-3 border-l-transparent border-r-transparent border-t-slate-900" />
                </div>
              </div>
            ))}
          </div>
        </React.Fragment>
      ))}
    </div>
  )
}

export { type ToolbarButtonWithIcon, type ToolbarEnhancedProps }
