


export function ValeMaterialesReportList() {
    return <ReportFrame>
        <fieldset className="border border-slate-400 p-3">
            <legend className="text-[11px] font-bold">Datos de Reporte</legend>
            <div className="space-y-2"><DateRange/>
            <div className="grid grid-cols-2 gap-3">
                <Stack label="Oficina:"><Select/></Stack>
                <Stack label="Almacén:"><Select/></Stack>
                <Stack label="# OT:"><input className={inp}/></Stack>
                <Stack label="Personal:"><input className={inp}/></Stack>
                <Stack label="TipMov:"><Select><option>SALIDAS</option></Select></Stack>
                <Stack label="Área:"><Select/></Stack>
                <Stack label="Clase:"><Select/></Stack>
                <Stack label="Estado:"><Select/></Stack>
            </div>
            <Check label="Toda Mercadería" defaultChecked/>
            <fieldset className="border border-slate-400 p-2">
                <legend className="text-[11px] font-bold">Exportar</legend>
                <div className="flex gap-8">
                    <Choice name="val-e" label="Pantalla" defaultChecked/>
                    <Choice name="val-e" label="Excel"/>
                </div>
            </fieldset>
        </div>
    </fieldset>
</ReportFrame>; }

export function ValeMaterialesReport() {
  return <ValeMaterialesReportList />;
}
