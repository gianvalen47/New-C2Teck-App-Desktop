import { Button } from '@/components/ui/button'
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card'
import { ArrowLeft } from 'lucide-react'
import { Link } from '@tanstack/react-router'

export default function TelefoniaModelosPage() {
  return (
    <div className="min-h-screen bg-slate-50 py-8 px-4">
      <div className="max-w-5xl mx-auto">
        <div className="mb-6 flex items-center justify-between gap-4">
          <div>
            <p className="text-sm text-slate-500">MÃ³dulo Telefonia</p>
            <h1 className="text-3xl font-bold text-slate-900">Modelos</h1>
          </div>
          <Link to="/dashboard/telefonica">
            <Button variant="secondary" className="gap-2">
              <ArrowLeft className="h-4 w-4" /> Volver
            </Button>
          </Link>
        </div>

        <Card>
          <CardHeader>
            <CardTitle>Funcionalidad en construcciÃ³n</CardTitle>
            <CardDescription>
              PÃ¡gina generada automÃ¡ticamente para la secciÃ³n Modelos. Completa esta vista con los datos y formularios correspondientes.
            </CardDescription>
          </CardHeader>
          <CardContent>
            <p className="text-sm text-slate-600">
              Esta pÃ¡gina es un stub creado a partir de la estructura legacy de SIGECOM. Implementa aquÃ­ la tabla, filtros y acciones especÃ­ficas del mÃ³dulo.
            </p>
          </CardContent>
        </Card>
      </div>
    </div>
  )
}

