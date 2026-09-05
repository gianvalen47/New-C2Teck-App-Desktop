import React from 'react'
import './GuiaDevolucion.css'
import DetalleGrid from './DetalleGrid'
import { ROInput, DateInput, MultiCombo } from './Controls'

export default function GuiaDevolucion(): JSX.Element {
  return (
    <div className="gd-container" role="dialog" aria-label="Guía de Devolución">
      <div className="gd-toolbar-wrap">
        <div className="gd-toolbar-actions">
          <button className="icon" aria-label="Editar">✎</button>
          <button className="icon" aria-label="Grabar">💾</button>
          <button className="icon" aria-label="Deshacer">⤺</button>
          <button className="icon" aria-label="Salir">✖</button>
        </div>
        <div className="gd-title">Guía de Devolución</div>
      </div>

      <section className="gd-datos" aria-label="Datos generales">
        <div className="gb-title">[  Datos Generales  ]</div>
        <div className="row">
          <label htmlFor="gd-numero">Número :</label>
          <input id="gd-numero" readOnly value={""} placeholder="000000" />
          <label htmlFor="gd-fecha">Fecha :</label>
          <DateInput id="gd-fecha" />
          <label htmlFor="gd-moneda">Moneda :</label>
          <MultiCombo />
          <label htmlFor="gd-tipcam">Tip.Cam. :</label>
          <input id="gd-tipcam" readOnly value={""} />
        </div>

        <div className="row">
          <label htmlFor="gd-cliente">Cliente :</label>
          <ROInput id="gd-cliente" className="wide" />
        </div>

        <div className="row">
          <label htmlFor="gd-job"># Job :</label>
          <ROInput id="gd-job" />
          <label htmlFor="gd-motivo">Motivo :</label>
          <ROInput id="gd-motivo" className="wide" />
          <label htmlFor="gd-conpag">Con.Pag. :</label>
          <ROInput id="gd-conpag" />
        </div>

        <div className="row">
          <label htmlFor="gd-obs">Observaciones :</label>
          <textarea id="gd-obs" readOnly className="obs" />
          <button className="small" aria-label="Modificar observación">✎</button>
        </div>

        <div className="row">
          <label htmlFor="gd-vendedor">Vendedor :</label>
          <ROInput id="gd-vendedor" className="wide" />
        </div>
      </section>

      <section className="gd-detalles" aria-label="Detalles">
        <div className="gb-title">[  Detalles  ]</div>
        <div className="gd-grid-placeholder">
          <DetalleGrid
            columns={[
              { key: 'IdGuiaDevDet', title: 'IdGuiaDevDet', visible: false, hidden: true },
              { key: 'Item', title: 'Item', width: 52, align: 'center' },
              { key: 'CodMer', title: 'Código' },
              { key: 'DesMer1', title: 'Descripción', width: 230 },
              { key: 'CanMer', title: 'Cant.', width: 55, align: 'center', format: 'n' },
              { key: 'PreMer', title: 'Precio', width: 90, align: 'right', format: 'n' },
              { key: 'DscMer', title: 'Desc.(%)', width: 78, align: 'center', format: 'n' },
              { key: 'TotalFila', title: 'Total', width: 120, align: 'right', format: 'n' },
            ]}
            rows={[]}
          />
        </div>

        <div className="gd-totales">
          <div className="tot-labels">
            <div className="tot-line">Total Neto</div>
            <div className="tot-line">Total IGV</div>
            <div className="tot-line">Total</div>
          </div>
          <div className="tot-values">
            <input className="tot-input" readOnly value={"0.00"} />
            <input className="tot-input" readOnly value={"0.00"} />
            <input className="tot-input tot-main" readOnly value={"0.00"} />
          </div>
        </div>
      </section>

      <footer className="gd-status">OFICINA - ALMACÉN</footer>
    </div>
  )
}
