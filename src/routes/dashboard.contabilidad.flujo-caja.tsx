import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ContabilidadFlujoCajaPage from '@/modules/Contabilidad/pages/flujo-caja'

export const Route = createFileRoute('/dashboard/contabilidad/flujo-caja')({
  component: () => (
    <DashboardLayout>
      <ContabilidadFlujoCajaPage />
    </DashboardLayout>
  ),
})
