import { Link } from '@tanstack/react-router';
import { Button } from '@/components/ui/button';
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card';
import { Search, Filter, Users, Package, FileText, DollarSign, BarChart3 } from 'lucide-react';

export default function BuscadoresModule() {
  const features = [
    { id: 'clientes', label: 'BÃºsqueda de Clientes', icon: Users, description: 'Buscar y filtrar clientes' },
    { id: 'productos', label: 'BÃºsqueda de Productos', icon: Package, description: 'BÃºsqueda de productos' },
    { id: 'documentos', label: 'BÃºsqueda de Documentos', icon: FileText, description: 'Buscar documentos' },
    { id: 'movimientos', label: 'BÃºsqueda de Movimientos', icon: DollarSign, description: 'BÃºsqueda de transacciones' },
    { id: 'filtros-avanzados', label: 'Filtros Avanzados', icon: Filter, description: 'Filtros y bÃºsquedas complejas' },
    { id: 'reportes-busqueda', label: 'Reportes de BÃºsqueda', icon: BarChart3, description: 'Reportes y anÃ¡lisis' },
    { id: 'componentes', label: 'Componentes', icon: Search, description: 'Componentes reutilizables' },
  ];

  return (
    <div className="min-h-screen bg-gradient-to-br from-blue-50 to-teal-50 py-8 px-4">
      <div className="max-w-7xl mx-auto">
        <div className="mb-8">
          <h1 className="text-4xl font-bold text-slate-900 mb-2">MÃ³dulo de Buscadores</h1>
          <p className="text-lg text-slate-600">Componentes de bÃºsqueda reutilizables y filtros avanzados para toda la aplicaciÃ³n</p>
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
                  <Link to={`/dashboard/buscadores/${feature.id}` as any}>
                    <Button className="w-full bg-blue-600 hover:bg-blue-700">Acceder</Button>
                  </Link>
                </CardContent>
              </Card>
            );
          })}
        </div>

        <div className="mt-12 grid grid-cols-3 gap-4 bg-white rounded-lg p-6 shadow">
          <div className="text-center">
            <p className="text-3xl font-bold text-blue-600">7</p>
            <p className="text-sm text-slate-600">Funcionalidades</p>
          </div>
          <div className="text-center">
            <p className="text-3xl font-bold text-green-600">~60</p>
            <p className="text-sm text-slate-600">Componentes</p>
          </div>
          <div className="text-center">
            <p className="text-3xl font-bold text-blue-600">Reutilizable</p>
            <p className="text-sm text-slate-600">Arquitectura</p>
          </div>
        </div>
      </div>
    </div>
  );
}

