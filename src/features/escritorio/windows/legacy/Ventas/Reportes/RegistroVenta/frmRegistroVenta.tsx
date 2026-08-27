// Converted from legacy form
// Original: Ventas/Reportes/RegistroVenta/frmRegistroVenta.vb
import React from 'react'
import ListingBrowser from '@/features/escritorio/windows/shared/ListingBrowser'
import { stdToolbar3 } from '@/features/escritorio/windows/shared/toolbarPresets'

export default function FrmRegistroVenta() {
  return (
    <ListingBrowser
      toolbar2={stdToolbar3}
      columns={["Nro", "Fecha", "Cliente", "Total", "Estado"]}
      rows={20}
      title="Registro de Venta"
    />
  )
}
