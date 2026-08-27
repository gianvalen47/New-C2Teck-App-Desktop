import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ImportacionesDocumentosPage from '@/modules/Importaciones/pages/documentos'

export const Route = createFileRoute('/dashboard/importaciones/documentos')({
  component: () => (
    <DashboardLayout>
      <ImportacionesDocumentosPage />
    </DashboardLayout>
  ),
})
