import { Link } from '@tanstack/react-router';
import { Button } from '@/components/ui/button';
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card';
import { PieChart, TrendingDown, BarChart3, Search } from 'lucide-react';

export default function ActivosFijosModule() {
  const features = [
    { id: 'compra', label: 'Compra de Activos', icon: PieChart, description: 'Registrar adquisiciones' },
    { id: 'depreciacion', label: 'DepreciaciÃ³n', icon: TrendingDown, description: 'CÃ¡lculo de depreciaciÃ³n' },
    { id: 'consultas', label: 'Consultas', icon: Search, description: 'Consultar activos' },
    { id: 'reportes', label: 'Reportes', icon: BarChart3, description: 'Reportes de activos' },
  ];

  return (
    <div className="min-h-screen bg-gradient-to-br from-cyan-50 to-blue-50 py-8 px-4">
      <div className="max-w-7xl mx-auto">
        <div className="mb-8">
          <h1 className="text-4xl font-bold text-slate-900 mb-2">MÃ³dulo de Activos Fijos</h1>
          <p className="text-lg text-slate-600">GestiÃ³n completa del ciclo de vida de activos fijos y depreciaciÃ³n</p>
        </div>

        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          {features.map((feature) => {
            const Icon = feature.icon;
            return (
              <Card key={feature.id} className="hover:shadow-lg transition-shadow">
                <CardHeader>
                  <div className="flex items-center gap-3 mb-2">
                    <div className="p-2 bg-cyan-100 rounded-lg">
                      <Icon className="w-6 h-6 text-cyan-600" />
                    </div>
                    <CardTitle className="text-lg">{feature.label}</CardTitle>
                  </div>
                  <CardDescription>{feature.description}</CardDescription>
                </CardHeader>
                <CardContent>
                  <Link to={`/dashboard/activos-fijos/${feature.id}` as any}>
                    <Button className="w-full bg-cyan-600 hover:bg-cyan-700">Acceder</Button>
                  </Link>
                </CardContent>
              </Card>
            );
          })}
        </div>

        <div className="mt-12 grid grid-cols-3 gap-4 bg-white rounded-lg p-6 shadow">
          <div className="text-center">
            <p className="text-3xl font-bold text-cyan-600">4</p>
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

