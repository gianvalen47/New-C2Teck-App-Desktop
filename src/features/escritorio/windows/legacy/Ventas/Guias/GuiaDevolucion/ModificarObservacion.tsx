import React from 'react'
import './ModificarObservacion.css'

export default function ModificarObservacion(): JSX.Element {
  return (
    <div className="gd-modobs">
      <h3>Modificar Observación</h3>
      <textarea className="gd-modobs-text" />
      <div className="gd-modobs-actions">
        <button>Guardar</button>
        <button>Cancelar</button>
      </div>
    </div>
  )
}
