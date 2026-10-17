

export function SinMovimientoReport() { 
    return <ReportFrame>
        <div className="space-y-3">
            <DateRange/>
            <div className="grid grid-cols-2 gap-3">
                <Stack label="Oficina:">
                    <Select>
                        <option>LIMA</option>
                    </Select>
                </Stack>
                <Stack label="Almacén:">
                    <Select>
                        <option>COMERCIAL</option>
                    </Select>
                </Stack>
            </div>
            <Stack label="Rubro:">
                <Select/>
            </Stack>
            <fieldset className="border border-slate-400 p-2">
                <legend className="text-[11px] font-bold">Tipo</legend>
                <div className="flex gap-6">
                    <Choice name="sin-t" label="Todos" defaultChecked/>
                    <Choice name="sin-t" label="Por Aplicación"/>
                </div>
            </fieldset>
            <fieldset className="border border-slate-400 p-2">
                <legend className="text-[11px] font-bold">Exportar</legend>
                <div className="flex gap-8">
                    <Choice name="sin-e" label="Pantalla" defaultChecked/>
                    <Choice name="sin-e" label="Excel"/>
                </div>
            </fieldset>
        </div>
    </ReportFrame>; }
