import { useEffect, useState } from 'react'
import { Button } from '@/components/ui/button'
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card'
import { ToolbarEnhanced } from '@/components/ui/toolbar-enhanced'
import { ArrowLeft } from 'lucide-react'
import { Link } from '@tanstack/react-router'
import { guiasRemisionToolbarButtons } from '@/lib/toolbar-config'
import { fetchGuiasRemision, type GuiaRemisionRow } from '@/lib/sigecoom-api'
import { toast } from 'sonner'
import type { ToolbarButtonWithIcon } from '@/components/ui/toolbar-enhanced'

export default function VentasGuiasPage() {
  const [toolbarButtons] = useState<ToolbarButtonWithIcon[]>(guiasRemisionToolbarButtons as ToolbarButtonWithIcon[])
  const [rows, setRows] = useState<GuiaRemisionRow[]>([])
  const [loading, setLoading] = useState(false)
  const [anio, setAnio] = useState(String(new Date().getFullYear()))
  const [mes, setMes] = useState(String(new Date().getMonth() + 1))
  const [office, setOffice] = useState('LIMA')
  const [warehouse, setWarehouse] = useState('COMERCIAL')

  const loadGuias = async () => {
    setLoading(true)
    try {
      const data = await fetchGuiasRemision({
        anio: Number(anio) || undefined,
        mes: Number(mes) || undefined,
      })
      setRows(data)
    } catch (error: any) {
      toast.error(error?.message ?? 'Error al cargar guías de remisión')
      setRows([])
    } finally {
      setLoading(false)
    }
  }

  useEffect(() => {
    loadGuias()
  }, [])

  const handleSearch = () => {
    loadGuias()
  }

  const handleToolbarButtonClick = (buttonId: string) => {
    console.log('Button clicked:', buttonId)
    // Aquí iría la lógica específica para cada botón
    switch (buttonId) {
      case 'imprimir':
        console.log('Imprimir guía...')
        break
      case 'ticket':
        console.log('Imprimir ticket...')
        break
      case 'nuevo':
        console.log('Crear nueva guía...')
        break
      case 'mostrar':
        console.log('Mostrar guía...')
        break
      case 'eliminar':
        console.log('Eliminar guía...')
        break
      case 'anular':
        console.log('Anular guía...')
        break
      case 'enviar':
        console.log('Enviar a créditos...')
        break
      case 'generar':
        console.log('Generar Fac/Bol...')
        break
      case 'trasladar':
        console.log('Trasladar guía...')
        break
      case 'b2mining':
        console.log('Enviar B2Mining...')
        break
      case 'sugerir':
        console.log('Sugerir factor/descuento...')
        break
      case 'agregarConsumo':
        console.log('Agregar consumo OT...')
        break
      case 'estado':
        console.log('Mostrar estados...')
        break
      case 'consultarSugerido':
        console.log('Consultar precios sugeridos...')
        break
      case 'bajarNivel':
        console.log('Bajar de nivel...')
        break
      case 'actualizar':
        console.log('Actualizar guías...')
        break
      case 'enviarCorreo':
        console.log('Enviar por correo...')
        break
      case 'generarElectronica':
        console.log('Generar guía electrónica...')
        break
      case 'descargarElectronica':
        console.log('Descargar guía electrónica...')
        break
      case 'listarElectronica':
        console.log('Listar guías electrónicas...')
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
              <input
                type="number"
                value={anio}
                onChange={e => setAnio(e.target.value)}
                className="w-full px-2 py-1 border border-slate-300 rounded text-sm"
              />
            </div>
            <div>
              <label className="text-xs font-semibold text-slate-600 block mb-1">Mes</label>
              <select
                value={mes}
                onChange={e => setMes(e.target.value)}
                className="w-full px-2 py-1 border border-slate-300 rounded text-sm"
              >
                <option value="1">Enero</option>
                <option value="2">Febrero</option>
                <option value="3">Marzo</option>
                <option value="4">Abril</option>
                <option value="5">Mayo</option>
                <option value="6">Junio</option>
                <option value="7">Julio</option>
                <option value="8">Agosto</option>
                <option value="9">Setiembre</option>
                <option value="10">Octubre</option>
                <option value="11">Noviembre</option>
                <option value="12">Diciembre</option>
              </select>
            </div>
            <div>
              <label className="text-xs font-semibold text-slate-600 block mb-1">Oficina</label>
              <select
                value={office}
                onChange={e => setOffice(e.target.value)}
                className="w-full px-2 py-1 border border-slate-300 rounded text-sm"
              >
                <option value="LIMA">LIMA</option>
                <option value="AREQUIPA">AREQUIPA</option>
              </select>
            </div>
            <div>
              <label className="text-xs font-semibold text-slate-600 block mb-1">Almacén</label>
              <select
                value={warehouse}
                onChange={e => setWarehouse(e.target.value)}
                className="w-full px-2 py-1 border border-slate-300 rounded text-sm"
              >
                <option value="COMERCIAL">COMERCIAL</option>
                <option value="TALLER">TALLER</option>
              </select>
            </div>
            <div>
              <label className="text-xs font-semibold text-slate-600 block mb-1">Buscar</label>
              <button
                type="button"
                onClick={handleSearch}
                className="w-full px-2 py-1 bg-slate-200 border border-slate-300 rounded text-sm hover:bg-slate-300 transition-colors"
              >
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
              <h1 className="text-3xl font-bold text-slate-900">Guías de Remisión</h1>
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
              <CardTitle>Registros de Guías ({rows.length})</CardTitle>
              <CardDescription>
                Listado de guías de remisión disponibles en el sistema
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
                      <th className="px-4 py-2 text-left font-semibold text-slate-700">Moneda</th>
                      <th className="px-4 py-2 text-left font-semibold text-slate-700">Total</th>
                      <th className="px-4 py-2 text-left font-semibold text-slate-700">Estado</th>
                    </tr>
                  </thead>
                  <tbody>
                    {loading ? (
                      <tr className="border-t border-slate-200">
                        <td colSpan={6} className="px-4 py-8 text-center text-slate-500">
                          Cargando guías...
                        </td>
                      </tr>
                    ) : rows.length === 0 ? (
                      <tr className="border-t border-slate-200">
                        <td colSpan={6} className="px-4 py-8 text-center text-slate-500">
                          No se encontraron guías para el periodo seleccionado.
                        </td>
                      </tr>
                    ) : (
                      rows.map((row) => (
                        <tr key={row.id} className="border-t border-slate-200 hover:bg-slate-50">
                          <td className="px-4 py-3">{row.cod_serie ? `${row.cod_serie}-${row.num_doc}` : row.num_doc}</td>
                          <td className="px-4 py-3">{new Date(row.fec_doc).toLocaleDateString('es-PE')}</td>
                          <td className="px-4 py-3">{row.cliente_nombre ?? `Cliente ${row.id_cliente}`}</td>
                          <td className="px-4 py-3">{row.cod_mon}</td>
                          <td className="px-4 py-3">{row.tot_neto.toFixed(2)}</td>
                          <td className="px-4 py-3">{row.estado_sunat ?? row.estado}</td>
                        </tr>
                      ))
                    )}
                  </tbody>
                </table>
              </div>

              <div className="mt-4 p-3 bg-slate-50 border border-slate-200 rounded text-sm text-slate-600">
                ℹ️ Esta vista ahora carga el listado de guías desde la API del backend.
              </div>
            </CardContent>
          </Card>
        </div>
      </div>
    </div>
  )
}
