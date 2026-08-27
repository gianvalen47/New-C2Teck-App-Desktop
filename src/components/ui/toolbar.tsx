import React from 'react'
import { Button } from './button'
import { cn } from '@/lib/utils'

interface ToolbarButton {
  id: string
  label: string
  tooltip?: string
  icon: React.ReactNode
  onClick?: () => void
  disabled?: boolean
  visible?: boolean
  group?: string
}

interface ToolbarProps {
  buttons: ToolbarButton[]
  className?: string
  onButtonClick?: (buttonId: string) => void
}

export function Toolbar({ buttons, className, onButtonClick }: ToolbarProps) {
  const visibleButtons = buttons.filter((btn) => btn.visible !== false)
  const groups = new Map<string | undefined, ToolbarButton[]>()

  // Group buttons
  visibleButtons.forEach((btn) => {
    const groupKey = btn.group || 'default'
    if (!groups.has(groupKey)) {
      groups.set(groupKey, [])
    }
    groups.get(groupKey)!.push(btn)
  })

  return (
    <div className={cn(
      'flex items-center gap-0.5 bg-gradient-to-b from-slate-100 to-slate-95 border-b-2 border-slate-300 px-2 py-1.5 flex-wrap shadow-sm',
      className
    )}>
      {Array.from(groups.entries()).map(([groupKey, groupButtons], index) => (
        <React.Fragment key={groupKey || 'default'}>
          {index > 0 && <div className="w-px h-8 bg-slate-400 mx-0.5" />}
          <div className="flex items-center gap-0.5">
            {groupButtons.map((btn) => (
              <div
                key={btn.id}
                className="relative group"
                title={btn.tooltip || btn.label}
              >
                <button
                  disabled={btn.disabled}
                  onClick={() => {
                    btn.onClick?.()
                    onButtonClick?.(btn.id)
                  }}
                  className={cn(
                    'flex flex-col items-center justify-center p-1.5 rounded hover:bg-slate-200 transition-all duration-200',
                    'w-10 h-10 active:bg-slate-300 active:shadow-inset',
                    'border border-transparent hover:border-slate-300',
                    'disabled:opacity-50 disabled:cursor-not-allowed disabled:hover:bg-transparent',
                    'relative'
                  )}
                >
                  {/* Icono principal */}
                  <div className="w-6 h-6 flex items-center justify-center text-slate-700 flex-shrink-0">
                    {btn.icon}
                  </div>
                </button>

                {/* Tooltip que aparece en hover */}
                <div className="absolute bottom-full left-1/2 transform -translate-x-1/2 mb-2 px-2 py-1 bg-slate-800 text-white text-xs rounded whitespace-nowrap opacity-0 group-hover:opacity-100 transition-opacity duration-200 pointer-events-none z-50 shadow-lg">
                  <div className="font-semibold">{btn.label}</div>
                  {btn.tooltip && <div className="text-slate-200 text-xs">{btn.tooltip}</div>}
                  {/* Punta del tooltip */}
                  <div className="absolute top-full left-1/2 transform -translate-x-1/2 w-0 h-0 border-l-4 border-r-4 border-t-4 border-l-transparent border-r-transparent border-t-slate-800" />
                </div>
              </div>
            ))}
          </div>
        </React.Fragment>
      ))}
    </div>
  )
}

export { type ToolbarButton, type ToolbarProps }
