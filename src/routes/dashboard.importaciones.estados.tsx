import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ImportacionesEstadosPage from '@/modules/Importaciones/pages/estados'

export const Route = createFileRoute('/dashboard/importaciones/estados')({
  component: () => (
    <DashboardLayout>
      <ImportacionesEstadosPage />
    </DashboardLayout>
  ),
})
