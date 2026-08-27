import { Link } from '@tanstack/react-router';
import { Button } from '@/components/ui/button';
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card';
import { Database, Package, Users, Building, Tag, Settings, MapPin, Zap } from 'lucide-react';

export default function TablasModule() {
  const features = [
    { id: 'productos', label: 'Productos', icon: Package, description: 'CatÃ¡logo de productos' },
    { id: 'clientes', label: 'Clientes', icon: Users, description: 'Maestro de clientes' },
    { id: 'proveedores', label: 'Proveedores', icon: Building, description: 'Maestro de proveedores' },
    { id: 'marcas', label: 'Marcas', icon: Tag, description: 'Gestionar marcas' },
    { id: 'ubicaciones', label: 'Ubicaciones', icon: MapPin, description: 'Ubicaciones de almacÃ©n' },
    { id: 'parametros', label: 'ParÃ¡metros', icon: Settings, description: 'ConfiguraciÃ³n del sistema' },
    { id: 'consultas', label: 'Consultas', icon: Database, description: 'Consultar datos maestros' },
    { id: 'reportes', label: 'Reportes', icon: Zap, description: 'Reportes de tablas' },
  ];

  return (
    <div className="min-h-screen bg-gradient-to-br from-purple-50 to-indigo-50 py-8 px-4">
      <div className="max-w-7xl mx-auto">
        <div className="mb-8">
          <h1 className="text-4xl font-bold text-slate-900 mb-2">MÃ³dulo de Tablas</h1>
          <p className="text-lg text-slate-600">GestiÃ³n de datos maestros, catÃ¡logos y parÃ¡metros del sistema</p>
        </div>

        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          {features.map((feature) => {
            const Icon = feature.icon;
            return (
              <Card key={feature.id} className="hover:shadow-lg transition-shadow">
                <CardHeader>
                  <div className="flex items-center gap-3 mb-2">
                    <div className="p-2 bg-purple-100 rounded-lg">
                      <Icon className="w-6 h-6 text-purple-600" />
                    </div>
                    <CardTitle className="text-lg">{feature.label}</CardTitle>
                  </div>
                  <CardDescription>{feature.description}</CardDescription>
                </CardHeader>
                <CardContent>
                  <Link to={`/dashboard/tablas/${feature.id}` as any}>
                    <Button className="w-full bg-purple-600 hover:bg-purple-700">Acceder</Button>
                  </Link>
                </CardContent>
              </Card>
            );
          })}
        </div>

        <div className="mt-12 grid grid-cols-3 gap-4 bg-white rounded-lg p-6 shadow">
          <div className="text-center">
            <p className="text-3xl font-bold text-purple-600">8</p>
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

