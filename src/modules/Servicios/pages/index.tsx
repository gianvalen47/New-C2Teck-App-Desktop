import { Link } from '@tanstack/react-router';
import { Button } from '@/components/ui/button';
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card';
import { Wrench, Clock, Quote, Zap, Search, BarChart3 } from 'lucide-react';

export default function ServiciosModule() {
  const features = [
    { id: 'jobs', label: 'Trabajos (Jobs)', icon: Wrench, description: 'Ã“rdenes de servicio' },
    { id: 'marcacion', label: 'MarcaciÃ³n', icon: Clock, description: 'Control de marcaciÃ³n' },
    { id: 'cotizaciones', label: 'Cotizaciones', icon: Quote, description: 'Cotizaciones de servicio' },
    { id: 'mantenimiento', label: 'Mantenimiento', icon: Zap, description: 'Mantenimiento preventivo' },
    { id: 'consultas', label: 'Consultas', icon: Search, description: 'Consultar servicios' },
    { id: 'reportes', label: 'Reportes', icon: BarChart3, description: 'Reportes de servicios' },
  ];

  return (
    <div className="min-h-screen bg-gradient-to-br from-blue-50 to-cyan-50 py-8 px-4">
      <div className="max-w-7xl mx-auto">
        <div className="mb-8">
          <h1 className="text-4xl font-bold text-slate-900 mb-2">MÃ³dulo de Servicios</h1>
          <p className="text-lg text-slate-600">GestiÃ³n integral de Ã³rdenes de servicio, marcaciÃ³n y mantenimiento</p>
        </div>

        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          {features.map((feature) => {
            const Icon = feature.icon;
            return (
              <Card key={feature.id} className="hover:shadow-lg transition-shadow">
                <CardHeader>
                  <div className="flex items-center gap-3 mb-2">
                    <div className="p-2 bg-blue-100 rounded-lg">
                      <Icon className="w-6 h-6 text-blue-600" />
                    </div>
                    <CardTitle className="text-lg">{feature.label}</CardTitle>
                  </div>
                  <CardDescription>{feature.description}</CardDescription>
                </CardHeader>
                <CardContent>
                  <Link to={`/dashboard/servicios/${feature.id}` as any}>
                    <Button className="w-full bg-blue-600 hover:bg-blue-700">Acceder</Button>
                  </Link>
                </CardContent>
              </Card>
            );
          })}
        </div>

        <div className="mt-12 grid grid-cols-3 gap-4 bg-white rounded-lg p-6 shadow">
          <div className="text-center">
            <p className="text-3xl font-bold text-blue-600">6</p>
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

