import { Link } from '@tanstack/react-router';
import { Button } from '@/components/ui/button';
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card';
import { Users, Briefcase, MessageSquare, FileText, BarChart3, Search } from 'lucide-react';

export default function PersonalModule() {
  const features = [
    { id: 'asignaciones', label: 'Asignaciones', icon: Briefcase, description: 'Asignaciones de personal' },
    { id: 'comunicacion', label: 'ComunicaciÃ³n', icon: MessageSquare, description: 'Comunicaciones internas' },
    { id: 'informacion', label: 'InformaciÃ³n', icon: FileText, description: 'InformaciÃ³n de empleados' },
    { id: 'consultas', label: 'Consultas', icon: Search, description: 'Consultar personal' },
    { id: 'reportes', label: 'Reportes', icon: BarChart3, description: 'Reportes de personal' },
    { id: 'directorio', label: 'Directorio', icon: Users, description: 'Directorio de empleados' },
  ];

  return (
    <div className="min-h-screen bg-gradient-to-br from-yellow-50 to-amber-50 py-8 px-4">
      <div className="max-w-7xl mx-auto">
        <div className="mb-8">
          <h1 className="text-4xl font-bold text-slate-900 mb-2">MÃ³dulo de Personal</h1>
          <p className="text-lg text-slate-600">GestiÃ³n integral de recursos humanos y personal</p>
        </div>

        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          {features.map((feature) => {
            const Icon = feature.icon;
            return (
              <Card key={feature.id} className="hover:shadow-lg transition-shadow">
                <CardHeader>
                  <div className="flex items-center gap-3 mb-2">
                    <div className="p-2 bg-yellow-100 rounded-lg">
                      <Icon className="w-6 h-6 text-yellow-600" />
                    </div>
                    <CardTitle className="text-lg">{feature.label}</CardTitle>
                  </div>
                  <CardDescription>{feature.description}</CardDescription>
                </CardHeader>
                <CardContent>
                  <Link to={`/dashboard/personal/${feature.id}` as any}>
                    <Button className="w-full bg-yellow-600 hover:bg-yellow-700">Acceder</Button>
                  </Link>
                </CardContent>
              </Card>
            );
          })}
        </div>

        <div className="mt-12 grid grid-cols-3 gap-4 bg-white rounded-lg p-6 shadow">
          <div className="text-center">
            <p className="text-3xl font-bold text-yellow-600">6</p>
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

