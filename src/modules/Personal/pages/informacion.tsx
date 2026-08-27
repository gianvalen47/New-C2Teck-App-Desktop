import { Button } from '@/components/ui/button'
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card'
import { ArrowLeft } from 'lucide-react'
import { Link } from '@tanstack/react-router'

export default function PersonalInformacionPage() {
  return (
    <div className="min-h-screen bg-slate-50 py-8 px-4">
      <div className="max-w-5xl mx-auto">
        <div className="mb-6 flex items-center justify-between gap-4">
          <div>
            <p className="text-sm text-slate-500">Módulo Personal</p>
            <h1 className="text-3xl font-bold text-slate-900">Información</h1>
          </div>
          <Link to="/dashboard/personal">
            <Button variant="secondary" className="gap-2">
              <ArrowLeft className="h-4 w-4" /> Volver
            </Button>
          </Link>
        </div>

        <Card>
          <CardHeader>
            <CardTitle>Funcionalidad en construcción</CardTitle>
            <CardDescription>
              Página generada automáticamente para la sección Información. Completa esta vista con los datos y formularios correspondientes.
            </CardDescription>
          </CardHeader>
          <CardContent>
            <p className="text-sm text-slate-600">
              Esta página es un stub creado a partir de la estructura legacy de SIGECOM. Implementa aquí la tabla, filtros y acciones específicas del módulo.
            </p>
          </CardContent>
        </Card>
      </div>
    </div>
  )
}
