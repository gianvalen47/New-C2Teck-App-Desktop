import React from 'react'
import './Generar.css'

export default function Generar(): JSX.Element {
  return (
    <div className="gd-generar">
      <h3>Documento a Devolver</h3>
      <div className="gd-generar-fields">
        <label>Número</label>
        <input readOnly />
        <label>Fecha</label>
        <input readOnly />
        <label>Cliente</label>
        <input readOnly />
      </div>
      <div className="gd-generar-actions">
        <button>Generar</button>
        <button>Cancelar</button>
      </div>
    </div>
  )
}
