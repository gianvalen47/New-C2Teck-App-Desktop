import { createFileRoute, Outlet, useLocation } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import Ventas from '@/modules/Ventas/pages'

export const Route = createFileRoute('/dashboard/ventas')({
  component: () => {
    const location = useLocation()
    const isIndexRoute = location.pathname === '/dashboard/ventas'

    return (
      <DashboardLayout>
        {isIndexRoute ? <Ventas /> : <Outlet />}
      </DashboardLayout>
    )
  },
})
