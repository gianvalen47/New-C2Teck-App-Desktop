import React from 'react'
import './AgregarDetalles.css'

export default function AgregarDetalles(): JSX.Element {
  return (
    <div className="gd-add-container">
      <header>Lista de Detalles</header>
      <div className="gd-add-top">
        <select disabled aria-label="Clientes"></select>
      </div>
      <div className="gd-add-grid">[Grid placeholder]</div>
      <footer className="gd-add-status">Total: 0</footer>
    </div>
  )
}
