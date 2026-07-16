import React from 'react'

const modules = [
  'ActivosFijos',
  'Administracion',
  'Almacen',
  'Ayuda',
  'B2M',
  'Buscadores',
  'Compras',
  'Contabilidad',
  'Costos',
  'CRM',
  'Créditos',
  'Gerencia',
  'Importaciones',
  'Login',
  'Personal',
  'Planillas',
  'Rondas',
  'Servicios',
  'Tablas',
  'Telefonia',
  'Ventas',
]

export default function SigecoomIndex() {
  return (
    <div style={{ padding: 20 }}>
      <h1>SIGECOM - Módulos (placeholders)</h1>
      <ul>
        {modules.map((m) => (
          <li key={m}>
            <a href={`#/sigecoom/${m}`}>{m}</a>
          </li>
        ))}
      </ul>
      <p>Estos componentes son marcadores de posición. Los archivos fuente originales permanecen en <code>SIGECOM/</code>.</p>
    </div>
  )
}
