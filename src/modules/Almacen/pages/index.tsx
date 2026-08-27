import { Link } from '@tanstack/react-router';
import { Button } from '@/components/ui/button';
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card';
import { Package, Truck, MapPin, AlertCircle, Search, BarChart3 } from 'lucide-react';

export default function AlmacenModule() {
  const features = [
    { id: 'movimientos', label: 'Movimientos', icon: Package, description: 'Registrar movimientos de almacÃ©n' },
    { id: 'despacho', label: 'Despacho', icon: Truck, description: 'Gestionar despachos' },
    { id: 'ubicaciones', label: 'Ubicaciones', icon: MapPin, description: 'Administrar ubicaciones' },
    { id: 'minimos-maximos', label: 'MÃ­nimos/MÃ¡ximos', icon: AlertCircle, description: 'Control de niveles de inventario' },
    { id: 'consultas', label: 'Consultas', icon: Search, description: 'Consultar inventario' },
    { id: 'reportes', label: 'Reportes', icon: BarChart3, description: 'Reportes de almacÃ©n' },
  ];

  return (
    <div className="min-h-screen bg-gradient-to-br from-amber-50 to-orange-50 py-8 px-4">
      <div className="max-w-7xl mx-auto">
        {/* Header */}
        <div className="mb-8">
          <h1 className="text-4xl font-bold text-slate-900 mb-2">MÃ³dulo de AlmacÃ©n</h1>
          <p className="text-lg text-slate-600">Control integral del inventario, movimientos y despachos</p>
        </div>

        {/* Features Grid */}
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          {features.map((feature) => {
            const Icon = feature.icon;
            return (
              <Card key={feature.id} className="hover:shadow-lg transition-shadow">
                <CardHeader>
                  <div className="flex items-center gap-3 mb-2">
                    <div className="p-2 bg-amber-100 rounded-lg">
                      <Icon className="w-6 h-6 text-amber-600" />
                    </div>
                    <CardTitle className="text-lg">{feature.label}</CardTitle>
                  </div>
                  <CardDescription>{feature.description}</CardDescription>
                </CardHeader>
                <CardContent>
                  <Link to={`/dashboard/almacen/${feature.id}` as any}>
                    <Button className="w-full bg-amber-600 hover:bg-amber-700">Acceder</Button>
                  </Link>
                </CardContent>
              </Card>
            );
          })}
        </div>

        {/* Stats Footer */}
        <div className="mt-12 grid grid-cols-3 gap-4 bg-white rounded-lg p-6 shadow">
          <div className="text-center">
            <p className="text-3xl font-bold text-amber-600">6</p>
            <p className="text-sm text-slate-600">Funcionalidades</p>
          </div>
          <div className="text-center">
            <p className="text-3xl font-bold text-green-600">100%</p>
            <p className="text-sm text-slate-600">Control</p>
          </div>
          <div className="text-center">
            <p className="text-3xl font-bold text-purple-600">Real-time</p>
            <p className="text-sm text-slate-600">SincronizaciÃ³n</p>
          </div>
        </div>
      </div>
    </div>
  );
}

