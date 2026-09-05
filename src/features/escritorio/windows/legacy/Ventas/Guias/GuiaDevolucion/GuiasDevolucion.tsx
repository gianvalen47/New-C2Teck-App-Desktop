import React, { useState, useRef, useEffect } from 'react'
import './GuiasDevolucion.css'

export default function GuiasDevolucion(): JSX.Element {
  const [rows] = useState<any[]>([])
  const [ctxMenu, setCtxMenu] = useState<{ x: number; y: number } | null>(null)
  const menuRef = useRef<HTMLDivElement | null>(null)

  useEffect(() => {
    function hide(e: MouseEvent) {
      if (menuRef.current && !menuRef.current.contains(e.target as Node)) setCtxMenu(null)
    }
    window.addEventListener('click', hide)
    return () => window.removeEventListener('click', hide)
  }, [])

  function onContextMenu(e: React.MouseEvent) {
    e.preventDefault()
    setCtxMenu({ x: e.clientX, y: e.clientY })
  }

  return (
    <div className="gd-list">
      <div className="gd-toolbar">
        <div className="toolbar-left">
          <button title="Nuevo">📄</button>
          <button title="Guardar">💾</button>
          <button title="Imprimir">🖨️</button>
          <button title="Eliminar">🗑️</button>
        </div>
        <div className="toolbar-right">Guías de Devolución</div>
      </div>

      <header className="gd-list-filters">
        <label>Año <input className="small" placeholder="2026" /></label>
        <label>Mes <select className="med"><option>SEPTIEMBRE</option></select></label>
        <label>Oficina <select className="med"><option>LIMA</option></select></label>
        <label>Almacén <select className="med"><option>COMERCIAL</option></select></label>
        <label>Cliente <select className="big"><option>(Todos)</option></select></label>
        <label>Estado <select className="med"><option>(Todos)</option></select></label>
        <label>Número <input className="med" /></label>
        <button className="btn-search">Buscar</button>
      </header>

      <div className="gd-list-grid" onContextMenu={onContextMenu}>
        <table>
          <thead>
            <tr>
              <th>Número</th>
              <th>Fecha</th>
              <th>Referencia</th>
              <th>Cliente</th>
              <th>Mon.</th>
              <th>Total</th>
              <th>EST</th>
            </tr>
          </thead>
          <tbody>
            {rows.length ? (
              rows.map((r, i) => (
                <tr key={i}>
                  <td>{r.numero}</td>
                  <td>{r.fecha}</td>
                  <td>{r.referencia}</td>
                  <td>{r.cliente}</td>
                  <td>{r.mon}</td>
                  <td style={{ textAlign: 'right' }}>{r.total}</td>
                  <td>{r.estado}</td>
                </tr>
              ))
            ) : (
              <tr className="empty-row">
                <td colSpan={7}>No hay registros</td>
              </tr>
            )}
          </tbody>
        </table>
      </div>

      <footer className="gd-list-status">Registros : {rows.length}</footer>

      {ctxMenu && (
        <div className="ctx-menu" ref={menuRef} style={{ left: ctxMenu.x, top: ctxMenu.y }}>
          <ul>
            <li>Imprimir</li>
            <li>Generar</li>
            <li>Nuevo</li>
            <li>Mostrar</li>
            <li>Eliminar</li>
            <li>Anular</li>
            <li>Procesar Guía</li>
            <li>Estados</li>
            <li className="sep">Actualizar</li>
            <li>Salir</li>
          </ul>
        </div>
      )}
    </div>
  )
}
