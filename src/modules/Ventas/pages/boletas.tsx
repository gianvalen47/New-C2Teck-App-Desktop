import { useState } from 'react'
import { Button } from '@/components/ui/button'
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card'
import { ToolbarEnhanced } from '@/components/ui/toolbar-enhanced'
import { ArrowLeft } from 'lucide-react'
import { Link } from '@tanstack/react-router'
import { boletasToolbarButtons } from '@/lib/toolbar-config'
import type { ToolbarButtonWithIcon } from '@/components/ui/toolbar-enhanced'

export default function VentasBoletasPage() {
  const [toolbarButtons] = useState<ToolbarButtonWithIcon[]>(boletasToolbarButtons as ToolbarButtonWithIcon[])

  const handleToolbarButtonClick = (buttonId: string) => {
    console.log('Button clicked:', buttonId)
    // Aquí iría la lógica específica para cada botón
    switch (buttonId) {
      case 'imprimir':
        console.log('Imprimir boleta...')
        break
      case 'ticket':
        console.log('Imprimir ticket...')
        break
      case 'nuevo':
        console.log('Crear nueva boleta...')
        break
      case 'mostrar':
        console.log('Mostrar boleta...')
        break
      case 'eliminar':
        console.log('Eliminar boleta...')
        break
      case 'anular':
        console.log('Anular boleta...')
        break
      case 'enviar':
        console.log('Enviar a créditos...')
        break
      case 'generar':
        console.log('Generar Fac/Bol...')
        break
      case 'sugerir':
        console.log('Sugerir factor/descuento...')
        break
      case 'estado':
        console.log('Mostrar estados...')
        break
      case 'actualizar':
        console.log('Actualizar boletas...')
        break
      case 'enviarCorreo':
        console.log('Enviar por correo...')
        break
      case 'generarElectronica':
        console.log('Generar boleta electrónica...')
        break
      case 'descargarElectronica':
        console.log('Descargar boleta electrónica...')
        break
      case 'salir':
        console.log('Cerrar formulario...')
        break
      default:
        console.log('Acción no implementada:', buttonId)
    }
  }

  return (
    <div className="min-h-screen bg-slate-50">
      {/* Toolbar mejorado */}
      <ToolbarEnhanced 
        buttons={toolbarButtons} 
        onButtonClick={handleToolbarButtonClick} 
        className="sticky top-0 z-10"
        iconSize="md"
      />

      {/* Filtros y búsqueda */}
      <div className="bg-white border-b border-slate-200 px-4 py-3">
        <div className="max-w-7xl mx-auto">
          <div className="grid grid-cols-2 sm:grid-cols-3 md:grid-cols-5 gap-3">
            <div>
              <label className="text-xs font-semibold text-slate-600 block mb-1">Año</label>
              <input type="number" defaultValue="2026" className="w-full px-2 py-1 border border-slate-300 rounded text-sm" />
            </div>
            <div>
              <label className="text-xs font-semibold text-slate-600 block mb-1">Mes</label>
              <select className="w-full px-2 py-1 border border-slate-300 rounded text-sm">
                <option>Julio</option>
              </select>
            </div>
            <div>
              <label className="text-xs font-semibold text-slate-600 block mb-1">Oficina</label>
              <select className="w-full px-2 py-1 border border-slate-300 rounded text-sm">
                <option>LIMA</option>
              </select>
            </div>
            <div>
              <label className="text-xs font-semibold text-slate-600 block mb-1">Estado</label>
              <select className="w-full px-2 py-1 border border-slate-300 rounded text-sm">
                <option>Todos</option>
              </select>
            </div>
            <div>
              <label className="text-xs font-semibold text-slate-600 block mb-1">Buscar</label>
              <button className="w-full px-2 py-1 bg-slate-200 border border-slate-300 rounded text-sm hover:bg-slate-300 transition-colors">
                Buscar
              </button>
            </div>
          </div>
        </div>
      </div>

      {/* Contenido principal */}
      <div className="py-8 px-4">
        <div className="max-w-7xl mx-auto">
          <div className="mb-6 flex items-center justify-between gap-4">
            <div>
              <p className="text-sm text-slate-500">Módulo Ventas</p>
              <h1 className="text-3xl font-bold text-slate-900">Boletas</h1>
            </div>
            <Link to="/dashboard/ventas">
              <Button variant="secondary" className="gap-2">
                <ArrowLeft className="h-4 w-4" /> Volver
              </Button>
            </Link>
          </div>

          {/* Tabla de datos */}
          <Card>
            <CardHeader>
              <CardTitle>Registros de Boletas (0)</CardTitle>
              <CardDescription>
                Listado de boletas disponibles en el sistema
              </CardDescription>
            </CardHeader>
            <CardContent>
              <div className="overflow-x-auto border border-slate-200 rounded-lg">
                <table className="w-full text-sm">
                  <thead className="bg-slate-100 border-b border-slate-200">
                    <tr>
                      <th className="px-4 py-2 text-left font-semibold text-slate-700">Número</th>
                      <th className="px-4 py-2 text-left font-semibold text-slate-700">Fecha</th>
                      <th className="px-4 py-2 text-left font-semibold text-slate-700">Cliente</th>
                      <th className="px-4 py-2 text-left font-semibold text-slate-700">Total</th>
                      <th className="px-4 py-2 text-left font-semibold text-slate-700">Estado</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr className="border-t border-slate-200">
                      <td colSpan={5} className="px-4 py-8 text-center text-slate-500">
                        <p>sin registros</p>
                      </td>
                    </tr>
                  </tbody>
                </table>
              </div>

              <div className="mt-4 p-3 bg-slate-50 border border-slate-200 rounded text-sm text-slate-600">
                ℹ️ Utiliza los botones de la barra de herramientas para crear, editar o eliminar boletas.
              </div>
            </CardContent>
          </Card>
        </div>
      </div>
    </div>
  )
}
