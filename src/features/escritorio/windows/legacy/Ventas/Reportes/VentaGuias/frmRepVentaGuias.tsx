// Converted from legacy form
// Original: Ventas/Reportes/VentaGuias/frmRepVentaGuias.vb
import React from 'react'
import ListingBrowser from '@/features/escritorio/windows/shared/ListingBrowser'
import { stdToolbar4 } from '@/features/escritorio/windows/shared/toolbarPresets'

export default function FrmRepVentaGuias() {
  return (
    <ListingBrowser
      toolbar2={stdToolbar4}
      columns={["Guía", "Fecha", "Cliente", "Estado", "Total"]}
      rows={12}
      title="Reporte - Guías de Remisión"
    />
  )
}
