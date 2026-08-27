// Converted from legacy form
// Original: Ventas/Visitas a Clientes/frmVisitasClientes.vb
import React from 'react'
import ListingBrowser from '@/features/escritorio/windows/shared/ListingBrowser'
import { stdToolbar9 } from '@/features/escritorio/windows/shared/toolbarPresets'

export default function FrmVisitasClientes() {
  return (
    <ListingBrowser
      toolbar2={stdToolbar9}
      columns={["Visita", "Fecha", "Cliente", "Vendedor", "Resultado"]}
      rows={10}
      title="Visitas a Clientes"
    />
  )
}
