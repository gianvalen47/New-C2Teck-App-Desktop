import { Link } from '@tanstack/react-router';
import { Button } from '@/components/ui/button';
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card';
import { PieChart, GitMerge, TrendingUp, Search, BarChart3 } from 'lucide-react';

export default function CostosModule() {
  const features = [
    { id: 'consolidados', label: 'Consolidados', icon: PieChart, description: 'Costos consolidados' },
    { id: 'importaciones', label: 'Importaciones', icon: GitMerge, description: 'Costos de importación' },
    { id: 'procesos', label: 'Procesos', icon: TrendingUp, description: 'Costeo de procesos' },
    { id: 'consultas', label: 'Consultas', icon: Search, description: 'Consultar costos' },
    { id: 'reportes', label: 'Reportes', icon: BarChart3, description: 'Reportes de costos' },
  ];

  return (
    <div className="min-h-screen bg-gradient-to-br from-orange-50 to-red-50 py-8 px-4">
      <div className="max-w-7xl mx-auto">
        <div className="mb-8">
          <h1 className="text-4xl font-bold text-slate-900 mb-2">Módulo de Costos</h1>
          <p className="text-lg text-slate-600">Análisis y control de costos operacionales</p>
        </div>

        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          {features.map((feature) => {
            const Icon = feature.icon;
            return (
              <Card key={feature.id} className="hover:shadow-lg transition-shadow">
                <CardHeader>
                  <div className="flex items-center gap-3 mb-2">
                    <div className="p-2 bg-orange-100 rounded-lg">
                      <Icon className="w-6 h-6 text-orange-600" />
                    </div>
                    <CardTitle className="text-lg">{feature.label}</CardTitle>
                  </div>
                  <CardDescription>{feature.description}</CardDescription>
                </CardHeader>
                <CardContent>
                  <Link to={`/dashboard/costos/${feature.id}`}>
                    <Button className="w-full bg-orange-600 hover:bg-orange-700">Acceder</Button>
                  </Link>
                </CardContent>
              </Card>
            );
          })}
        </div>

        <div className="mt-12 grid grid-cols-3 gap-4 bg-white rounded-lg p-6 shadow">
          <div className="text-center">
            <p className="text-3xl font-bold text-orange-600">5</p>
            <p className="text-sm text-slate-600">Funcionalidades</p>
          </div>
          <div className="text-center">
            <p className="text-3xl font-bold text-green-600">✓</p>
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
