

export function MovimientosAlmacenReportList() { 
    return <ReportFrame>
        <fieldset className="border border-slate-400 p-2">
            <legend className="text-[11px] font-bold">Tipo Reporte</legend>
            <div className="flex gap-8">
                <Choice name="mov-r" label="Resumen" defaultChecked/>
                <Choice name="mov-r" label="Detallado"/>
                </div>
                </fieldset>
                <div className="space-y-2 mt-3">
                    <DateRange/>
                    <OficinaAlmacen />
                    <Stack label="Movimiento"><Select /></Stack>
                    <Stack label="Ubicación"><input className={inp}/></Stack>
                    <Stack label="Rubro"><Select /></Stack>
                    <Stack label="Tipo Mov"><Select><option>INGRESOS</option><option>SALIDAS</option></Select></Stack>
                    <fieldset className="border border-slate-400 p-2 w-[150px]">
                        <legend className="text-[11px] font-bold">Reporte</legend>
                        <Choice name="mov-f" label="Formato 1" defaultChecked/>
                        <Choice name="mov-f" label="Formato 2"/>
                    </fieldset>
                    <Check label="Bajo el Máximo"/>
                </div>
            </ReportFrame>; }

export function MovimientosAlmacenReport() {
  return <MovimientosAlmacenReportList />;
}
