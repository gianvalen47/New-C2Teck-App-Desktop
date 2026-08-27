// Converted from legacy form
// Original: Ventas/Reportes/VentaDetalle/frmRepVentaDetalle.vb
import React from 'react'
import ListingBrowser from '@/features/escritorio/windows/shared/ListingBrowser'
import { stdToolbar3 } from '@/features/escritorio/windows/shared/toolbarPresets'

export default function FrmRepVentaDetalle() {
  return (
    <ListingBrowser
      toolbar2={stdToolbar3}
      columns={["Producto", "Cantidad", "Precio", "Descuento", "Subtotal"]}
      rows={15}
      title="Reporte - Detalle de Venta"
    />
  )
}
