import React from 'react'
import './GenerarNotaCredito.css'

export default function GenerarNotaCredito(): JSX.Element {
  return (
    <div className="gd-nota">
      <h3>Generar Nota Crédito</h3>
      <div className="gd-nota-form">
        <label>Número</label>
        <input />
        <label>Fecha</label>
        <input />
        <label>Tipo Nota</label>
        <select />
        <label>Motivo</label>
        <textarea />
      </div>
      <div className="gd-nota-actions">
        <button>Guardar</button>
        <button>Cancelar</button>
      </div>
    </div>
  )
}
