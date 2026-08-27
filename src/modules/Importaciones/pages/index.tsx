import { Link } from '@tanstack/react-router';
import { Button } from '@/components/ui/button';
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card';
import { ShoppingCart, FileText, Ship, CheckCircle2, Search, BarChart3 } from 'lucide-react';

export default function ImportacionesModule() {
  const features = [
    { id: 'pedidos', label: 'Pedidos', icon: ShoppingCart, description: 'Pedidos de importaciÃ³n' },
    { id: 'documentos', label: 'Documentos', icon: FileText, description: 'Documentos aduanales' },
    { id: 'embarques', label: 'Embarques', icon: Ship, description: 'Seguimiento de embarques' },
    { id: 'estados', label: 'Estados', icon: CheckCircle2, description: 'Estados de importaciÃ³n' },
    { id: 'consultas', label: 'Consultas', icon: Search, description: 'Consultar importaciones' },
    { id: 'reportes', label: 'Reportes', icon: BarChart3, description: 'Reportes de importaciÃ³n' },
  ];

  return (
    <div className="min-h-screen bg-gradient-to-br from-lime-50 to-green-50 py-8 px-4">
      <div className="max-w-7xl mx-auto">
        <div className="mb-8">
          <h1 className="text-4xl font-bold text-slate-900 mb-2">MÃ³dulo de Importaciones</h1>
          <p className="text-lg text-slate-600">GestiÃ³n de pedidos, documentos y seguimiento de embarques internacionales</p>
        </div>

        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          {features.map((feature) => {
            const Icon = feature.icon;
            return (
              <Card key={feature.id} className="hover:shadow-lg transition-shadow">
                <CardHeader>
                  <div className="flex items-center gap-3 mb-2">
                    <div className="p-2 bg-lime-100 rounded-lg">
                      <Icon className="w-6 h-6 text-lime-600" />
                    </div>
                    <CardTitle className="text-lg">{feature.label}</CardTitle>
                  </div>
                  <CardDescription>{feature.description}</CardDescription>
                </CardHeader>
                <CardContent>
                  <Link to={`/dashboard/importaciones/${feature.id}` as any}>
                    <Button className="w-full bg-lime-600 hover:bg-lime-700">Acceder</Button>
                  </Link>
                </CardContent>
              </Card>
            );
          })}
        </div>

        <div className="mt-12 grid grid-cols-3 gap-4 bg-white rounded-lg p-6 shadow">
          <div className="text-center">
            <p className="text-3xl font-bold text-lime-600">6</p>
            <p className="text-sm text-slate-600">Funcionalidades</p>
          </div>
          <div className="text-center">
            <p className="text-3xl font-bold text-green-600">âœ“</p>
            <p className="text-sm text-slate-600">Disponible</p>
          </div>
          <div className="text-center">
            <p className="text-3xl font-bold text-blue-600">24/7</p>
            <p className="text-sm text-slate-600">Activo</p>
          </div>
        </div>
      </div>
    </div>
  );
}

