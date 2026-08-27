import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import PlanillasDocumentosPage from '@/modules/Planillas/pages/documentos'

export const Route = createFileRoute('/dashboard/planillas/documentos')({
  component: () => (
    <DashboardLayout>
      <PlanillasDocumentosPage />
    </DashboardLayout>
  ),
})
