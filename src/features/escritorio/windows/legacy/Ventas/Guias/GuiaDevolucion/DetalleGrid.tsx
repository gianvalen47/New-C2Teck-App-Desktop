import React from 'react'
import './DetalleGrid.css'

type Column = {
  key: string
  title: string
  visible?: boolean
  width?: number
  align?: 'left' | 'center' | 'right'
  format?: 'n' | 'string'
  hidden?: boolean
}

type Props = { columns?: Column[]; rows?: Record<string, any>[] }

function formatValue(val: any, format?: string) {
  if (val == null) return ''
  if (format === 'n') {
    const num = Number(val)
    if (Number.isNaN(num)) return val
    return new Intl.NumberFormat(undefined, { minimumFractionDigits: 2, maximumFractionDigits: 2 }).format(num)
  }
  return String(val)
}

export default function DetalleGrid({ columns = [], rows = [] }: Props) {
  const visibleCols = columns.filter((c) => c.visible !== false && !c.hidden)

  return (
    <div className="detalle-grid">
      <table>
        <thead>
          <tr>
            {visibleCols.length
              ? visibleCols.map((c) => (
                  <th key={c.key} style={{ textAlign: c.align ?? 'left', width: c.width ? `${c.width}px` : undefined }}>
                    {c.title}
                  </th>
                ))
              : (
                <th>Item</th>
              )}
          </tr>
        </thead>
        <tbody>
          {rows.length ? (
            rows.map((r, i) => (
              <tr key={i}>
                {visibleCols.length
                  ? visibleCols.map((c) => (
                      <td key={c.key} style={{ textAlign: c.align ?? 'left' }}>
                        {formatValue(r[c.key], c.format)}
                      </td>
                    ))
                  : (
                    <td>--</td>
                  )}
              </tr>
            ))
          ) : (
            <tr>
              <td className="empty">No hay detalles</td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  )
}
