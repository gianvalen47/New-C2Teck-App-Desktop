import { Link } from '@tanstack/react-router';
import { Button } from '@/components/ui/button';
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card';
import { Users, Lock, Clock, ClipboardList, BarChart3, Settings } from 'lucide-react';

export default function AdministracionModule() {
  const features = [
    { id: 'usuarios', label: 'Usuarios', icon: Users, description: 'Gestionar usuarios' },
    { id: 'perfiles', label: 'Perfiles', icon: Lock, description: 'Control de perfiles y roles' },
    { id: 'sesiones', label: 'Sesiones', icon: Clock, description: 'Monitorear sesiones activas' },
    { id: 'encuestas', label: 'Encuestas', icon: ClipboardList, description: 'Crear y gestionar encuestas' },
    { id: 'reportes', label: 'Reportes', icon: BarChart3, description: 'Reportes administrativos' },
    { id: 'configuracion', label: 'Configuración', icon: Settings, description: 'Ajustes del sistema' },
  ];

  return (
    <div className="min-h-screen bg-gradient-to-br from-indigo-50 to-purple-50 py-8 px-4">
      <div className="max-w-7xl mx-auto">
        <div className="mb-8">
          <h1 className="text-4xl font-bold text-slate-900 mb-2">Módulo de Administración</h1>
          <p className="text-lg text-slate-600">Control administrativo de usuarios, perfiles y configuración del sistema</p>
        </div>

        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          {features.map((feature) => {
            const Icon = feature.icon;
            return (
              <Card key={feature.id} className="hover:shadow-lg transition-shadow">
                <CardHeader>
                  <div className="flex items-center gap-3 mb-2">
                    <div className="p-2 bg-indigo-100 rounded-lg">
                      <Icon className="w-6 h-6 text-indigo-600" />
                    </div>
                    <CardTitle className="text-lg">{feature.label}</CardTitle>
                  </div>
                  <CardDescription>{feature.description}</CardDescription>
                </CardHeader>
                <CardContent>
                  <Link to={`/dashboard/administracion/${feature.id}`}>
                    <Button className="w-full bg-indigo-600 hover:bg-indigo-700">Acceder</Button>
                  </Link>
                </CardContent>
              </Card>
            );
          })}
        </div>

        <div className="mt-12 grid grid-cols-3 gap-4 bg-white rounded-lg p-6 shadow">
          <div className="text-center">
            <p className="text-3xl font-bold text-indigo-600">6</p>
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
