import { Link } from '@tanstack/react-router';
import { Button } from '@/components/ui/button';
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card';
import { Lightbulb, Quote, Eye, Search, BarChart3, Users } from 'lucide-react';

export default function CRMModule() {
  const features = [
    { id: 'oportunidades', label: 'Oportunidades', icon: Lightbulb, description: 'Gestionar oportunidades de negocio' },
    { id: 'cotizaciones', label: 'Cotizaciones', icon: Quote, description: 'Crear y gestionar cotizaciones' },
    { id: 'visitas', label: 'Visitas', icon: Eye, description: 'Registrar visitas de clientes' },
    { id: 'consultas', label: 'Consultas', icon: Search, description: 'Consultar informaciÃ³n CRM' },
    { id: 'reportes', label: 'Reportes', icon: BarChart3, description: 'AnÃ¡lisis e indicadores' },
    { id: 'clientes', label: 'Clientes', icon: Users, description: 'GestiÃ³n de cartera de clientes' },
  ];

  return (
    <div className="min-h-screen bg-gradient-to-br from-rose-50 to-pink-50 py-8 px-4">
      <div className="max-w-7xl mx-auto">
        {/* Header */}
        <div className="mb-8">
          <h1 className="text-4xl font-bold text-slate-900 mb-2">MÃ³dulo CRM</h1>
          <p className="text-lg text-slate-600">GestiÃ³n integral de relaciones con clientes, oportunidades y visitas</p>
        </div>

        {/* Features Grid */}
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          {features.map((feature) => {
            const Icon = feature.icon;
            return (
              <Card key={feature.id} className="hover:shadow-lg transition-shadow">
                <CardHeader>
                  <div className="flex items-center gap-3 mb-2">
                    <div className="p-2 bg-rose-100 rounded-lg">
                      <Icon className="w-6 h-6 text-rose-600" />
                    </div>
                    <CardTitle className="text-lg">{feature.label}</CardTitle>
                  </div>
                  <CardDescription>{feature.description}</CardDescription>
                </CardHeader>
                <CardContent>
                  <Link to={`/dashboard/crm/${feature.id}` as any}>
                    <Button className="w-full bg-rose-600 hover:bg-rose-700">Acceder</Button>
                  </Link>
                </CardContent>
              </Card>
            );
          })}
        </div>

        {/* Stats Footer */}
        <div className="mt-12 grid grid-cols-3 gap-4 bg-white rounded-lg p-6 shadow">
          <div className="text-center">
            <p className="text-3xl font-bold text-rose-600">6</p>
            <p className="text-sm text-slate-600">Funcionalidades</p>
          </div>
          <div className="text-center">
            <p className="text-3xl font-bold text-green-600">âˆž</p>
            <p className="text-sm text-slate-600">Clientes</p>
          </div>
          <div className="text-center">
            <p className="text-3xl font-bold text-blue-600">360Â°</p>
            <p className="text-sm text-slate-600">Visibilidad</p>
          </div>
        </div>
      </div>
    </div>
  );
}

