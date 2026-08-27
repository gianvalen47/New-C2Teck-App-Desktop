import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import BuscadoresDocumentosPage from '@/modules/Buscadores/pages/documentos'

export const Route = createFileRoute('/dashboard/buscadores/documentos')({
  component: () => (
    <DashboardLayout>
      <BuscadoresDocumentosPage />
    </DashboardLayout>
  ),
})
