import { Link } from '@tanstack/react-router';
import { Button } from '@/components/ui/button';
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card';
import { HelpCircle, BookOpen, MessageSquare, Mail } from 'lucide-react';

export default function AyudaModule() {
  const features = [
    { id: 'manual', label: 'Manual', icon: BookOpen, description: 'DocumentaciÃ³n y guÃ­as' },
    { id: 'acerca', label: 'Acerca De', icon: HelpCircle, description: 'InformaciÃ³n de la aplicaciÃ³n' },
    { id: 'soporte', label: 'Soporte', icon: MessageSquare, description: 'Contactar soporte tÃ©cnico' },
    { id: 'contacto', label: 'Contacto', icon: Mail, description: 'Formulario de contacto' },
  ];

  return (
    <div className="min-h-screen bg-gradient-to-br from-green-50 to-emerald-50 py-8 px-4">
      <div className="max-w-7xl mx-auto">
        <div className="mb-8">
          <h1 className="text-4xl font-bold text-slate-900 mb-2">Centro de Ayuda</h1>
          <p className="text-lg text-slate-600">DocumentaciÃ³n, soporte tÃ©cnico y contacto con el equipo</p>
        </div>

        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          {features.map((feature) => {
            const Icon = feature.icon;
            return (
              <Card key={feature.id} className="hover:shadow-lg transition-shadow">
                <CardHeader>
                  <div className="flex items-center gap-3 mb-2">
                    <div className="p-2 bg-green-100 rounded-lg">
                      <Icon className="w-6 h-6 text-green-600" />
                    </div>
                    <CardTitle className="text-lg">{feature.label}</CardTitle>
                  </div>
                  <CardDescription>{feature.description}</CardDescription>
                </CardHeader>
                <CardContent>
                  <Link to={`/dashboard/ayuda/${feature.id}` as any}>
                    <Button className="w-full bg-green-600 hover:bg-green-700">Acceder</Button>
                  </Link>
                </CardContent>
              </Card>
            );
          })}
        </div>

        <div className="mt-12 grid grid-cols-3 gap-4 bg-white rounded-lg p-6 shadow">
          <div className="text-center">
            <p className="text-3xl font-bold text-green-600">4</p>
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

