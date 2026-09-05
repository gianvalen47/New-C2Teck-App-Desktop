import React from 'react'
import './Procesar.css'

export default function Procesar(): JSX.Element {
  return (
    <div className="gd-procesar">
      <h3>Procesar Guía</h3>
      <label>Observación</label>
      <textarea />
      <div className="gd-procesar-actions">
        <button>Procesar</button>
        <button>Cancelar</button>
      </div>
    </div>
  )
}
