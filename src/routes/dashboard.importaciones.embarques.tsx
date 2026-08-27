import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ImportacionesEmbarquesPage from '@/modules/Importaciones/pages/embarques'

export const Route = createFileRoute('/dashboard/importaciones/embarques')({
  component: () => (
    <DashboardLayout>
      <ImportacionesEmbarquesPage />
    </DashboardLayout>
  ),
})
