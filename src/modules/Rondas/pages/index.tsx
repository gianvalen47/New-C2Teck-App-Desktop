import { Link } from '@tanstack/react-router';
import { Button } from '@/components/ui/button';
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card';
import { Map, Navigation, MapPin, Users, Search, BarChart3 } from 'lucide-react';

export default function RondasModule() {
  const features = [
    { id: 'rutas', label: 'Rutas', icon: Map, description: 'Gestión de rutas de distribución' },
    { id: 'ruteadores', label: 'Ruteadores', icon: Navigation, description: 'Asignación de ruteadores' },
    { id: 'puntos', label: 'Puntos de Visita', icon: MapPin, description: 'Puntos de venta y clientes' },
    { id: 'asignaciones', label: 'Asignaciones', icon: Users, description: 'Asignación de personal' },
    { id: 'consultas', label: 'Consultas', icon: Search, description: 'Consultar rondas' },
    { id: 'reportes', label: 'Reportes', icon: BarChart3, description: 'Reportes de rondas' },
  ];

  return (
    <div className="min-h-screen bg-gradient-to-br from-emerald-50 to-teal-50 py-8 px-4">
      <div className="max-w-7xl mx-auto">
        <div className="mb-8">
          <h1 className="text-4xl font-bold text-slate-900 mb-2">Módulo de Rondas</h1>
          <p className="text-lg text-slate-600">Gestión de rutas, puntos de visita y asignación de ruteadores</p>
        </div>

        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          {features.map((feature) => {
            const Icon = feature.icon;
            return (
              <Card key={feature.id} className="hover:shadow-lg transition-shadow">
                <CardHeader>
                  <div className="flex items-center gap-3 mb-2">
                    <div className="p-2 bg-emerald-100 rounded-lg">
                      <Icon className="w-6 h-6 text-emerald-600" />
                    </div>
                    <CardTitle className="text-lg">{feature.label}</CardTitle>
                  </div>
                  <CardDescription>{feature.description}</CardDescription>
                </CardHeader>
                <CardContent>
                  <Link to={`/dashboard/rondas/${feature.id}`}>
                    <Button className="w-full bg-emerald-600 hover:bg-emerald-700">Acceder</Button>
                  </Link>
                </CardContent>
              </Card>
            );
          })}
        </div>

        <div className="mt-12 grid grid-cols-3 gap-4 bg-white rounded-lg p-6 shadow">
          <div className="text-center">
            <p className="text-3xl font-bold text-emerald-600">6</p>
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
