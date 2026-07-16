import { Link } from '@tanstack/react-router';
import { Button } from '@/components/ui/button';
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card';
import { Grid2x2Plus, FileText, Receipt, Truck, Quote, CreditCard, ShoppingCart, Search, BarChart3 } from 'lucide-react';

export default function VentasModule() {
  const features = [
    { id: 'facturas', label: 'Facturas', icon: FileText, description: 'Gestionar facturas electrónicas' },
    { id: 'boletas', label: 'Boletas', icon: Receipt, description: 'Boletas de venta' },
    { id: 'guias', label: 'Guías de Remisión', icon: Truck, description: 'Guías de despacho' },
    { id: 'cotizaciones', label: 'Cotizaciones', icon: Quote, description: 'Presupuestos y cotizaciones' },
    { id: 'notas-credito', label: 'Notas de Crédito', icon: CreditCard, description: 'Notas de crédito y devoluciones' },
    { id: 'cartera', label: 'Cartera de Clientes', icon: ShoppingCart, description: 'Gestión de clientes' },
    { id: 'ordenes', label: 'Órdenes de Compra', icon: FileText, description: 'Órdenes de compra de clientes' },
    { id: 'consultas', label: 'Consultas', icon: Search, description: 'Consultar documentos' },
    { id: 'reportes', label: 'Reportes', icon: BarChart3, description: 'Reportes y análisis' },
  ];

  return (
    <div className="min-h-screen bg-gradient-to-br from-slate-50 to-slate-100 py-8 px-4">
      <div className="max-w-7xl mx-auto">
        {/* Header */}
        <div className="mb-8">
          <h1 className="text-4xl font-bold text-slate-900 mb-2">Módulo de Ventas</h1>
          <p className="text-lg text-slate-600">Gestión completa de documentos de venta, facturas, boletas y cartera de clientes</p>
        </div>

        {/* Features Grid */}
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
                  <Link to={`/dashboard/ventas/${feature.id}`}>
                    <Button className="w-full bg-blue-600 hover:bg-blue-700">Acceder</Button>
                  </Link>
                </CardContent>
              </Card>
            );
          })}
        </div>

        {/* Stats Footer */}
        <div className="mt-12 grid grid-cols-3 gap-4 bg-white rounded-lg p-6 shadow">
          <div className="text-center">
            <p className="text-3xl font-bold text-blue-600">9</p>
            <p className="text-sm text-slate-600">Funcionalidades</p>
          </div>
          <div className="text-center">
            <p className="text-3xl font-bold text-green-600">∞</p>
            <p className="text-sm text-slate-600">Documentos</p>
          </div>
          <div className="text-center">
            <p className="text-3xl font-bold text-purple-600">24/7</p>
            <p className="text-sm text-slate-600">Disponible</p>
          </div>
        </div>
      </div>
    </div>
  );
}
