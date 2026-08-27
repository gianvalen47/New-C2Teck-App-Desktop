import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ImportacionesConsultasPage from '@/modules/Importaciones/pages/consultas'

export const Route = createFileRoute('/dashboard/importaciones/consultas')({
  component: () => (
    <DashboardLayout>
      <ImportacionesConsultasPage />
    </DashboardLayout>
  ),
})
